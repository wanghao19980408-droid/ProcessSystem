using DataConvertLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public class TCPManager
    {
        private TcpClient TcpClient;
        private NetworkStream Stream;
        private readonly object SendLock = new object();
        public event Action<bool> ConnectionStateChanged;
        public bool IsConnected { get; private set; }

        private string LocalIPaddress;
        private string TargetIP;
        public int Port { get; }
        private CancellationTokenSource Cts;
        private Task ReconnectTask;
        private readonly TimeSpan ReconnectInterval = TimeSpan.FromSeconds(3);
        public int SendTimeOut { get; set; } = 100;
        public int ReceiveTimeOut { get; set; } = 100;
        public int ConnectTimeOut { get; set; } = 2000;

        private const uint KeepAliveIdleMs = 5000;
        private const uint KeepAliveIntervalMs = 1000;

        private CRC_Check CRC = new CRC_Check();

        public TCPManager(string localIPaddress, string ip, int port)
        {
            LocalIPaddress = localIPaddress;
            TargetIP = ip;
            Port = port;
        }

        private void ConfigureKeepAlive(Socket socket)
        {
            try
            {
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                byte[] keepAliveValues = new byte[12];
                BitConverter.GetBytes(1u).CopyTo(keepAliveValues, 0);              
                BitConverter.GetBytes(KeepAliveIdleMs).CopyTo(keepAliveValues, 4); 
                BitConverter.GetBytes(KeepAliveIntervalMs).CopyTo(keepAliveValues, 8);
                socket.IOControl(IOControlCode.KeepAliveValues, keepAliveValues, null);
            }
            catch {  }
        }

        private void CheckSocketAlive()
        {
            try
            {
                var s = TcpClient?.Client;
                if (s == null || !s.Connected)
                {
                    Disconnect();
                    return;
                }
                if (s.Poll(0, SelectMode.SelectRead) && s.Available == 0)
                {
                    Disconnect();
                }
            }
            catch
            {
                Disconnect();
            }
        }

        private void SetConnected(bool connected)
        {
            if (IsConnected == connected) return;
            IsConnected = connected;
            ConnectionStateChanged?.Invoke(IsConnected);
        }

        public async Task<OperateResult> ConnectAsync()
        {
            try
            {
                Disconnect();

                TcpClient = new TcpClient(new IPEndPoint(IPAddress.Parse(LocalIPaddress), 0))
                {
                    SendTimeout = SendTimeOut,
                    ReceiveTimeout = ReceiveTimeOut
                };

                var connectTask = Task.Run(() =>
                {
                    TcpClient.Connect(IPAddress.Parse(TargetIP), Port);
                });

                var timeoutTask = Task.Delay(ConnectTimeOut);

                if (await Task.WhenAny(connectTask, timeoutTask) != connectTask)
                {
                    Disconnect();

                    _ = connectTask.ContinueWith(t => _ = t.Exception, TaskContinuationOptions.OnlyOnFaulted);

                    return OperateResult.CreateFailResult("TCP连接超时");
                }

                await connectTask;

                if (TcpClient == null || !TcpClient.Connected)
                    return OperateResult.CreateFailResult("TCP连接失败");

                ConfigureKeepAlive(TcpClient.Client);
                Stream = TcpClient.GetStream();
                SetConnected(true);

                return OperateResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                Disconnect();
                return OperateResult.CreateFailResult(ex.Message);
            }
        }

        public void StartAutoReconnect()
        {
            if (ReconnectTask != null) return;
            Cts = new CancellationTokenSource();
            ReconnectTask = Task.Run(() => ReconnectLoop(Cts.Token));
        }

        private async Task ReconnectLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!IsConnected)
                {
                    await ConnectAsync();
                }
                else
                {
                    CheckSocketAlive();
                }

                try { await Task.Delay(ReconnectInterval, token); }
                catch (TaskCanceledException) { break; }
            }
        }

        public void Stop()
        {
            Cts?.Cancel();
            ReconnectTask = null;
            Disconnect();
        }

        public void Disconnect()
        {
            SetConnected(false);
            try { Stream?.Close(); } catch { }
            try { TcpClient?.Close(); } catch { }
            Stream = null;
            TcpClient = null;
        }

        public OperateResult Send_PLC_Command(
            byte cmd,
            ushort bm = 0,
            bool on = false,
            List<byte> plc_cmd_sequence = null,
            byte pidIndex = 0,
            PIDParamSeq? pidParamSeq = null,
            object pidParamValue = null,
            byte lockIndex = 0,
            LockParamSeq? lockParamSeq = null,
            object lockParamValue = null,
            object pressurizationValue = null
            )
        {
            if (!IsConnected)
                return OperateResult.CreateFailResult("PLC未连接");

            byte[] frame;

            try
            {
                switch ((CMD)cmd)
                {
                    case CMD.single_control:
                        frame = CreateSingleControlFrame(bm, on);
                        break;
                    case CMD.q_control:
                        frame = CreateQControlFrame(plc_cmd_sequence);
                        break;
                    case CMD.reset:
                        frame = CreateResetFrame();
                        break;
                    case CMD.pid_command:
                        if (!pidParamSeq.HasValue || pidParamValue == null)
                            return OperateResult.CreateFailResult("PID参数不完整");
                        frame = CreateSinglePIDParamFrame(pidIndex, pidParamSeq.Value, pidParamValue).Content;
                        break;
                    case CMD.lock_command:
                        if (!lockParamSeq.HasValue || lockParamValue == null)
                            return OperateResult.CreateFailResult("连锁参数不完整");
                        frame = CreateLockFrame(lockIndex, lockParamSeq.Value, lockParamValue).Content;
                        break;
                    case CMD.pressurization_command:
                        if (pressurizationValue == null || !(pressurizationValue is List<ProcessSystemLib.Model.PressureStage>))
                            return OperateResult.CreateFailResult("批量增压参数必须为列表(List<PressureStage>)");
                        var pressResult = CreateBatchPressurizationFrame(lockIndex, (List<ProcessSystemLib.Model.PressureStage>)pressurizationValue);
                        if (!pressResult.IsSuccess) return pressResult;
                        frame = pressResult.Content;
                        break;
                    default:
                        return OperateResult.CreateFailResult("未知命令类型");
                }

                return SendFrame(frame);
            }
            catch (Exception ex)
            {
                Disconnect();
                return OperateResult.CreateFailResult($"发送异常: {ex.Message}");
            }
        }
        private OperateResult<byte[]> CreateBatchPressurizationFrame(byte settingType, List<ProcessSystemLib.Model.PressureStage> stages)
        {
            try
            {
                int stageCount = stages.Count;

                int dataLength = 1 + 1 + (stageCount * 4);

                byte[] senddata = new byte[6 + dataLength + 2];
                senddata[0] = 0x4E;
                senddata[1] = 0x4A;
                senddata[2] = cmd_list_high[(byte)CMD.pressurization_command - 1];
                senddata[3] = cmd_list_low[(byte)CMD.pressurization_command - 1];
                senddata[4] = (byte)(dataLength >> 8);
                senddata[5] = (byte)dataLength;

                senddata[6] = settingType;
                senddata[7] = (byte)stageCount;

                int offset = 8;
                foreach (var stage in stages)
                {
                    ushort time = (ushort)(stage.EndTime - stage.StartTime);
                    short pressure = (short)Math.Round((decimal)stage.TargetPressure * 1000m, MidpointRounding.AwayFromZero);

                    byte[] timeBytes = BitConverter.GetBytes(time);
                    byte[] pressBytes = BitConverter.GetBytes(pressure);

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(timeBytes);
                        Array.Reverse(pressBytes);
                    }

                    senddata[offset] = timeBytes[0];     
                    senddata[offset + 1] = timeBytes[1]; 
                    senddata[offset + 2] = pressBytes[0]; 
                    senddata[offset + 3] = pressBytes[1]; 

                    offset += 4; 
                }

                AddCrcChecksum(senddata);

                return OperateResult.CreateSuccessResult(senddata);
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<byte[]>($"批量组帧异常: {ex.Message}");
            }
        }
        private OperateResult SendFrame(byte[] frame)
        {
            if (!IsConnected || Stream == null || !Stream.CanWrite)
            {
                Disconnect();
                return OperateResult.CreateFailResult("TCP不可写");
            }

            try
            {
                lock (SendLock)
                {
                    Stream.Write(frame, 0, frame.Length);
                    Stream.Flush();
                }
                return OperateResult.CreateSuccessResult();
            }
            catch
            {
                Disconnect();
                return OperateResult.CreateFailResult("发送失败，连接已断开");
            }
        }

        private byte[] cmd_list_high = { 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00 };
        private byte[] cmd_list_low = { 0x01, 0x02, 0xFF, 0x04, 0x05, 0x06 };

        private byte[] CreateSingleControlFrame(UInt16 bm, bool onoff)
        {
            byte[] senddata = new byte[12];
            senddata[0] = 0x4E;
            senddata[1] = 0x4A;
            senddata[2] = cmd_list_high[(byte)CMD.single_control - 1];
            senddata[3] = cmd_list_low[(byte)CMD.single_control - 1];
            senddata[4] = 0x00;
            senddata[5] = 0x04;
            senddata[6] = (byte)(bm >> 8);
            senddata[7] = (byte)bm;
            senddata[8] = onoff ? (byte)0xFF : (byte)0x00;
            senddata[9] = onoff ? (byte)0xFF : (byte)0x00;
            AddCrcChecksum(senddata);
            return senddata;
        }

        private byte[] CreateQControlFrame(List<byte> plc_cmd_sequence)
        {
            byte[] senddata = new byte[12];
            senddata[0] = 0x4E;
            senddata[1] = 0x4A;
            senddata[2] = cmd_list_high[(byte)CMD.q_control - 1];
            senddata[3] = cmd_list_low[(byte)CMD.q_control - 1];
            senddata[4] = 0x00;
            senddata[5] = 0x04;
            plc_cmd_sequence.CopyTo(0, senddata, 6, Math.Min(plc_cmd_sequence.Count, 4));
            AddCrcChecksum(senddata);
            return senddata;
        }

        private OperateResult<byte[]> CreateSinglePIDParamFrame(byte pidIndex, PIDParamSeq paramSeq, object paramValue)
        {
            byte[] valueBytes;
            int valueLength;

            switch (paramSeq)
            {
                case PIDParamSeq.Auto:
                    if (!(paramValue is bool))
                        return OperateResult.CreateFailResult<byte[]>("Auto参数必须为bool类型");
                    bool isAuto = (bool)paramValue;
                    valueBytes = isAuto ? new byte[] { 0xFF, 0xFF } : new byte[] { 0x00, 0x00 };
                    valueLength = 2;
                    break;
                case PIDParamSeq.SetPoint:
                case PIDParamSeq.KP:
                case PIDParamSeq.KI:
                case PIDParamSeq.KD:
                case PIDParamSeq.DeadZone:
                    if (((string)paramValue) == "")
                        return OperateResult.CreateFailResult<byte[]>("设定参数不得为空");
                    if (!decimal.TryParse((string)paramValue, out decimal decValue))
                        return OperateResult.CreateFailResult<byte[]>("设定参数有误");
                    short scaledValue = (short)(decValue * 100m);
                    valueBytes = BitConverter.GetBytes(scaledValue);
                    if (BitConverter.IsLittleEndian) Array.Reverse(valueBytes);
                    valueLength = 2;
                    break;
                default:
                    throw new ArgumentException("无效的参数序号");
            }

            int dataLength = 1 + 1 + valueLength;
            byte[] senddata = new byte[6 + dataLength + 2];
            senddata[0] = 0x4E; senddata[1] = 0x4A;
            senddata[2] = cmd_list_high[(byte)CMD.pid_command - 1];
            senddata[3] = cmd_list_low[(byte)CMD.pid_command - 1];
            senddata[4] = (byte)(dataLength >> 8);
            senddata[5] = (byte)dataLength;
            senddata[6] = pidIndex;
            senddata[7] = (byte)paramSeq;
            Array.Copy(valueBytes, 0, senddata, 8, valueLength);
            AddCrcChecksum(senddata);
            return OperateResult.CreateSuccessResult(senddata);
        }

        private OperateResult<byte[]> CreateLockFrame(byte lockIndex, LockParamSeq paramSeq, object paramValue)
        {
            byte[] valueBytes;
            int valueLength;

            switch (paramSeq)
            {
                case LockParamSeq.Mode:
                    if (!(paramValue is int))
                        return OperateResult.CreateFailResult<byte[]>("Mode参数必须为整数");
                    int modeIndex = (int)paramValue;
                    if (modeIndex < 0 || modeIndex > 255)
                        return OperateResult.CreateFailResult<byte[]>("Mode索引超出有效范围（0-255）");
                    valueBytes = BitConverter.GetBytes((ushort)modeIndex);
                    if (BitConverter.IsLittleEndian) Array.Reverse(valueBytes);
                    valueLength = 2;
                    break;
                case LockParamSeq.SetValue:
                case LockParamSeq.HighLimit:
                case LockParamSeq.LowLimit:
                    if (((string)paramValue) == "")
                        return OperateResult.CreateFailResult<byte[]>("设定参数不得为空");
                    if (!decimal.TryParse((string)paramValue, out decimal decValue))
                        return OperateResult.CreateFailResult<byte[]>("设定参数有误");
                    short scaledValue = (short)(decValue * 100m);

                    valueBytes = BitConverter.GetBytes(scaledValue);
                    if (BitConverter.IsLittleEndian) Array.Reverse(valueBytes);
                    valueLength = 2;
                    break;
                default:
                    return OperateResult.CreateFailResult<byte[]>("无效的连锁参数序号");
            }

            int dataLength = 1 + 1 + valueLength;
            byte[] senddata = new byte[6 + dataLength + 2];
            senddata[0] = 0x4E; senddata[1] = 0x4A;
            senddata[2] = cmd_list_high[(byte)CMD.lock_command - 1];
            senddata[3] = cmd_list_low[(byte)CMD.lock_command - 1];
            senddata[4] = (byte)(dataLength >> 8);
            senddata[5] = (byte)dataLength;
            senddata[6] = lockIndex;
            senddata[7] = (byte)paramSeq;
            Array.Copy(valueBytes, 0, senddata, 8, valueLength);
            AddCrcChecksum(senddata);
            return OperateResult.CreateSuccessResult(senddata);
        }

        private byte[] CreateResetFrame()
        {
            byte[] senddata = new byte[12];
            senddata[0] = 0x4E; senddata[1] = 0x4A;
            senddata[2] = cmd_list_high[(byte)CMD.reset - 1];
            senddata[3] = cmd_list_low[(byte)CMD.reset - 1];
            senddata[4] = 0x00; senddata[5] = 0x04;
            for (int i = 6; i <= 9; i++) senddata[i] = 0x00;
            AddCrcChecksum(senddata);
            return senddata;
        }

        private void AddCrcChecksum(byte[] data)
        {
            UInt16 crc16 = CRC.Crc16(data, data.Length - 2);
            byte[] tmp = BitConverter.GetBytes(crc16);
            data[data.Length - 2] = tmp[1];
            data[data.Length - 1] = tmp[0];
        }
    }
}