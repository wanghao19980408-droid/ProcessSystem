using CommunicationLib;
using DataConvertLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NodeSettings
{
    public class SiemensDevice : DeviceBase
    {
        public string IPAddress { get; set; }

        public int Port { get; set; }

        public CpuType CpuType { get; set; }

        public short Rack { get; set; }

        public short Slot { get; set; }

        public List<SiemensGroup> GroupList { get; set; } = new List<SiemensGroup>();

        private S7NetLib siemens;

        public Dictionary<string, SiemensVariable> VariableDicList = new Dictionary<string, SiemensVariable>();
        /// <summary>
        /// 初始化变量字典集合
        /// </summary>
        public void Init()
        {
            foreach (var gp in this.GroupList)
            {
                foreach (var variable in gp.VarList)
                {
                    if (VariableDicList.ContainsKey(variable.VarName))
                    {
                        VariableDicList[variable.VarName] = variable;
                    }
                    else
                    {
                        VariableDicList.Add(variable.VarName, variable);
                    }
                }
            }
        }

        /// <summary>
        /// 开启多线程
        /// </summary>
        public void Start()
        {
            Init();

            Cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                GetSiemensValue();
            }, Cts.Token);
        }

        private void GetSiemensValue()
        {
            while (!Cts.IsCancellationRequested)
            {
                if (IsConnected)
                {
                    this.StopWatch = Stopwatch.StartNew();
                    foreach (var gp in GroupList)
                    {
                        gp.IsOK = GetGroupValue(gp);

                        if (!gp.IsOK)
                        {
                            this.IsConnected = false;
                            break;
                        }
                    }
                    this.CommPeriod = this.StopWatch.ElapsedMilliseconds;
                }
                else
                {
                    if (!FirstConnectSign)
                    {
                        this.siemens.DisConnect();
                        Thread.Sleep(this.ReConnectTime);
                    }
                    this.siemens = new S7NetLib(this.CpuType, this.IPAddress, this.Port, this.Rack, this.Slot);
                    IsConnected = siemens.Connect().IsSuccess;
                    if (FirstConnectSign)
                    {
                        FirstConnectSign = false;
                    }
                }
                Thread.Sleep(150);
            }
        }

        private bool GetGroupValue(SiemensGroup gp)
        {
            for (int i = 0; i < gp.ReadTimes; i++)
            {
                var result = this.siemens.ReadByteArray(gp.StoreArea, gp.DBNo, gp.Start, gp.Count);
                if (result.IsSuccess && result.Content.Length == gp.Count)
                {
                    foreach (var variable in gp.VarList)
                    {
                        var add = AnalysisAddress(variable.Address);
                        if (add.IsSuccess == false)
                        {
                            continue;
                        }
                        int start = add.Content1 - gp.Start;
                        int offsetOrLength = add.Content2;

                        switch (variable.DataType)
                        {
                            case DataConvertLib.DataType.Bool:
                                variable.VarValue = BitLib.GetBitFromByteArray(result.Content, start, offsetOrLength);
                                break;
                            case DataConvertLib.DataType.Byte:
                                variable.VarValue = ByteLib.GetByteFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.Short:
                                variable.VarValue = ShortLib.GetShortFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.UShort:
                                variable.VarValue = UShortLib.GetUShortFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.Int:
                                variable.VarValue = IntLib.GetIntFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.UInt:
                                variable.VarValue = UIntLib.GetUIntFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.Float:
                                variable.VarValue = FloatLib.GetFloatFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.Double:
                                variable.VarValue = DoubleLib.GetDoubleFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.Long:
                                variable.VarValue = LongLib.GetLongFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.ULong:
                                variable.VarValue = ULongLib.GetULongFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.String:
                                variable.VarValue = StringLib.GetSiemensStringFromByteArray(result.Content, start);
                                break;
                            case DataConvertLib.DataType.ByteArray:
                                variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(result.Content, start, offsetOrLength);
                                break;
                            case DataConvertLib.DataType.HexString:
                                variable.VarValue = StringLib.GetHexStringFromByteArray(result.Content, start, offsetOrLength);
                                break;
                            default:
                                break;
                        }
                        variable.VarValue = MigrationLib.GetMigrationValue(variable.VarValue, variable.Scale, variable.Offset).Content;
                        this.UpdateVariable(variable);
                    }
                    return true;
                }

            }
            return false;
        }

        private OperateResult<ushort, ushort> AnalysisAddress(string VarAddress)
        {
            ushort start = 0;
            ushort offsetOrLength = 0;

            if (VarAddress.Contains('.'))
            {
                string[] result = VarAddress.Split('.');

                if (result.Length == 2)
                {
                    if (ushort.TryParse(result[0], out start) && ushort.TryParse(result[1], out offsetOrLength))
                    {
                        return OperateResult.CreateSuccessResult(start, offsetOrLength);
                    }
                    else
                    {
                        return OperateResult.CreateFailResult<ushort, ushort>("地址格式不正确：" + VarAddress);
                    }
                }
                else
                {
                    return OperateResult.CreateFailResult<ushort, ushort>("地址格式不正确：" + VarAddress);
                }
            }
            else
            {
                if (ushort.TryParse(VarAddress, out start))
                {
                    return OperateResult.CreateSuccessResult(start, offsetOrLength);
                }
                else
                {
                    return OperateResult.CreateFailResult<ushort, ushort>("地址格式不正确：" + VarAddress);
                }
            }
        }
        /// <summary>
        /// 停止多线程
        /// </summary>
        public void Stop()
        {
            Cts?.Cancel();

            if (IsConnected)
            {
                siemens?.DisConnect();
            }
        }


        /// <summary>
        /// 通用写入
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="varValue"></param>
        /// <returns></returns>
        public OperateResult Write(string varName, string varValue)
        {
            if (!VariableDicList.ContainsKey(varName))
            {
                return OperateResult.CreateFailResult("无法通过变量名称找到变量对象");
            }
            SiemensVariable variable = VariableDicList[varName];

            var result = AnalysisAddress(variable.Address);
            if (!result.IsSuccess)
            {
                return result;
            }

            ushort start = result.Content1;
            ushort offsetOrLength = result.Content2;

            var migartionResult = MigrationLib.SetMigrationValue(varValue, variable.DataType, variable.Scale, variable.Offset);
            if (migartionResult.IsSuccess == false)
            {
                return migartionResult;
            }
            varValue = migartionResult.Content;
            switch (variable.DataType)
            {
                case DataType.Bool:
                    return siemens.WriteVariable(variable.VarAddress, varValue == "1" || varValue.ToLower() == "true");
                case DataType.Short:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToInt16(varValue));
                case DataType.UShort:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToUInt16(varValue));
                case DataType.Int:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToInt32(varValue));
                case DataType.UInt:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToUInt32(varValue));
                case DataType.Float:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToSingle(varValue));
                case DataType.Double:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToDouble(varValue));

                case DataType.Long:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToInt64(varValue));

                case DataType.ULong:
                    return siemens.WriteVariable(variable.VarAddress, Convert.ToUInt64(varValue));

                case DataType.String:
                    return siemens.WriteVariable(variable.VarAddress, varValue);

                case DataType.ByteArray:
                    List<byte> value = ByteArrayLib.GetByteArrayFromHexString(varValue).ToList();
                    return siemens.WriteVariable(variable.VarAddress, value.ToArray());
                default:
                    return OperateResult.CreateFailResult("暂不支持该数据类型");
            }
        }
    }
}
