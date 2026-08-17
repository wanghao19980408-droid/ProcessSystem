using DataConvertLib;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public class UDPManager
    {
        private UdpEx UdpClient;

        private readonly ConcurrentQueue<byte[]> Queue = new ConcurrentQueue<byte[]>();
        private CancellationTokenSource Cts = new CancellationTokenSource();
        private Task DecodeTask;

        public bool IsConnected { get; private set; }
        public IPAddress LocalIP { get; }
        private IPAddress MulticastAddress { get; }
        private int MulticastPort { get; }

        private readonly int[] Struct_count;

        public event EventHandler<UDPValues> DataUpdated;

        public UDPManager(string local, string multicastAddress, int multicastPort, int[] data_struct)
        {
            LocalIP = IPAddress.Parse(local);
            MulticastAddress = IPAddress.Parse(multicastAddress);
            MulticastPort = multicastPort;
            Struct_count = data_struct;

            Task.Run(ConnectionLoop, Cts.Token);
        }

        #region 连接管理

        private async Task ConnectionLoop()
        {
            int retryDelay = 500;
            const int maxRetryDelay = 10000;

            while (!Cts.IsCancellationRequested)
            {
                if (!IsConnected)
                {
                    try
                    {
                        DisconnectInternal();

                        var result = ConnectInternal();
                        IsConnected = result;

                        if (IsConnected)
                        {
                            retryDelay = 500;
                            StartDecodeLoop();
                        }
                        else
                        {
                            retryDelay = Math.Min(retryDelay * 2, maxRetryDelay);
                        }
                    }
                    catch
                    {
                        retryDelay = Math.Min(retryDelay * 2, maxRetryDelay);
                    }
                }

                await Task.Delay(retryDelay, Cts.Token);
            }
        }

        private bool ConnectInternal()
        {
            try
            {
                UdpClient = new UdpEx(LocalIP, MulticastPort);
                UdpClient.JoinMulticastGroup(MulticastAddress, MulticastPort);
                UdpClient.DataArrived += UdpClient_DataArrived;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DisconnectInternal()
        {
            try
            {
                UdpClient?.Close();
                UdpClient = null;
            }
            catch { }

            IsConnected = false;
        }

        #endregion

        #region UDP 接收
        private void UdpClient_DataArrived(object sender, UdpTransmissionEventArgs e)
        {
            Queue.Enqueue(e.Data);
        }

        #endregion

        #region 解码线程
        private void StartDecodeLoop()
        {
            if (DecodeTask != null && !DecodeTask.IsCompleted)
                return;

            DecodeTask = Task.Run(async () =>
            {
                while (!Cts.IsCancellationRequested)
                {
                    if (Queue.TryDequeue(out var bytes))
                    {
                        DecodeOnce(bytes);
                    }
                    else
                    {
                        await Task.Delay(1, Cts.Token);
                    }
                }
            }, Cts.Token);
        }

        #endregion

        #region 解码

        private void DecodeOnce(byte[] bytes)
        {
            try
            {
                var values = new UDPValues();

                if (MulticastPort == 8061 || MulticastPort == 8060)
                {
                    byte[] highAI = new byte[Struct_count[6]];
                    Array.Copy(bytes, 2, highAI, 0, Struct_count[6]);
                    values.HIGH_AI_value = ShortLib.GetShortArrayFromByteArray(highAI);
                }
                else
                {
                    byte[] DI = new byte[Struct_count[1]];
                    byte[] DQ = new byte[Struct_count[2]];
                    byte[] AQ = new byte[Struct_count[3]];
                    byte[] AI = new byte[Struct_count[5]];
                    byte[] Lock = new byte[Struct_count[7]];
                    byte[] pid = new byte[Struct_count[8]];


                    Array.Copy(bytes, 2, DI, 0, Struct_count[1]);
                    Array.Copy(bytes, 2 + Struct_count[1], DQ, 0, Struct_count[2]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2], AQ, 0, Struct_count[3]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2] + Struct_count[3], AI, 0, Struct_count[5]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2] + Struct_count[3] + Struct_count[5], Lock, 0, Struct_count[7]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2] + Struct_count[3] + Struct_count[5] + Struct_count[7], pid, 0, Struct_count[8]);

                    values.DI_value = BitLib.GetBitArrayFromByteArray(DI);
                    values.DQ_value = BitLib.GetBitArrayFromByteArray(DQ);
                    values.AQ_value = ShortLib.GetShortArrayFromByteArray(AQ);
                    values.AI_value = ShortLib.GetShortArrayFromByteArray(AI);
                    values.Lock_Value = ShortLib.GetShortArrayFromByteArray(Lock);
                    values.PID_Value = ShortLib.GetShortArrayFromByteArray(pid);

                }

                DataUpdated?.Invoke(this, values);
            }
            catch
            {
            }
        }

        #endregion

        #region 关闭

        public void Stop()
        {
            try
            {
                Cts.Cancel();

                if (UdpClient != null)
                {
                    UdpClient.DataArrived -= UdpClient_DataArrived;
                }
              }
            catch { }
        }

        #endregion
    }
}
