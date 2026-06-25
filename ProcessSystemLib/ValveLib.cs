using DataConvertLib;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public static class ValveLib
    {
        public static Action<int, String> AddLog;
        private static bool IsValidIndex(int index, int length)
        {
            return index >= 0 && index < length;
        }

        public static List<(int index, ValveState buttonState, ValveState iconstate)> PrepareSwitchValveValues<TCombo, TIcon>(UDPValues e, IList<TCombo> comboList, IList<TIcon> iconList) where TCombo : IAirControlValveBase where TIcon : IAirControlValveIcon
        {
            var result = new List<(int, ValveState, ValveState)>();

            int count = Math.Min(comboList.Count, iconList.Count);

            for (int i = 0; i < count; i++)
            {
                var combo = comboList[i];
                var icon = iconList[i];



                ValveState buttonState;

                if (combo.DqOpenAndClose != ushort.MaxValue)
                {
                    buttonState = e.DQ_value[combo.DqOpenAndClose - 1] ? ValveState.open : ValveState.close;
                }
                else
                {
                    bool dqOpen = e.DQ_value[combo.DqOpen - 1];
                    bool dqClose = e.DQ_value[combo.DqClose - 1];

                    buttonState = dqOpen && !dqClose ? ValveState.open : ValveState.close; ;
                }
                ValveState iconstate;
                if (combo.DiOpenAndClose != ushort.MaxValue)
                {
                     iconstate = e.DI_value[combo.DiOpenAndClose - 1] ? ValveState.open : ValveState.close;
                }
                else
                {
                    bool openSN = e.DI_value[icon.DiOpen - 1];
                    bool closeSN = e.DI_value[icon.DiClose - 1];
                     iconstate =
                        !openSN && !closeSN ? ValveState.low :
                        openSN && closeSN ? ValveState.warning :
                        openSN ? ValveState.open :
                          ValveState.close;
                }

                result.Add((i, buttonState, iconstate));

            }

            return result;
        }

        public static void ApplySwitchValveUI<TCombo, TIcon>(IList<TCombo> comboList, IList<TIcon> iconList, List<(int index, ValveState buttonState, ValveState state)> states) where TCombo : IAirControlValveBase where TIcon : IAirControlValveIcon
        {
            foreach (var s in states)
            {
                var combo = comboList[s.index];
                var icon = iconList[s.index];

                if (combo.State != s.buttonState)
                    combo.State = s.buttonState;

                if (icon.State != s.state)
                    icon.State = s.state;
            }
        }

        public static void ApplyElectricSwitchValveUI<TCombo, TIcon>(IList<TCombo> comboList, IList<TIcon> iconList, List<(int index, ValveState buttonState, ValveState state)> states) where TCombo : IElectricControlValveBase where TIcon : IElectricControlValveIcon
        {
            foreach (var s in states)
            {
                var combo = comboList[s.index];
                var icon = iconList[s.index];

                if (combo.State != s.buttonState)
                    combo.State = s.buttonState;

                if (icon.State != s.state)
                    icon.State = s.state;
            }
        }
        public static List<(int index, string value)> PrepareAdjustValveValues<TAdjust>(UDPValues e, IList<TAdjust> adjustList) where TAdjust : IAdjustValve
        {
            var result = new List<(int, string)>();
            int aiLen = e.AI_value?.Length ?? 0;

            for (int i = 0; i < adjustList.Count; i++)
            {
                if (!UInt16.TryParse(adjustList[i].AdjustAI.ToString(), out UInt16 ai))
                    continue;

                if (ai >= aiLen)
                    continue;

                result.Add((i, e.AI_value[ai].ToString()));
            }
            return result;
        }


        public static void ApplyAdjustValveUI<TAdjust>(IList<TAdjust> adjustList, List<(int index, string value)> values) where TAdjust : IAdjustValve
        {
            Task.Run(() =>
            {
                foreach (var item in values)
                {
                    adjustList[item.index].AdjustValue = item.value;
                }
            });
        }

        public static List<(int index, ValveState buttonState, ValveState state)> PrepareSwitchValveValuesWithFault<TCombo, TIcon>(UDPValues e, IList<TCombo> comboList, IList<TIcon> iconList) where TCombo : IElectricControlValveBase where TIcon : IElectricControlValveIcon
        {
            var result = new List<(int, ValveState, ValveState)>();
            int dqLen = e.DQ_value?.Length ?? 0;
            int diLen = e.DI_value?.Length ?? 0;

            int count = Math.Min(comboList.Count, iconList.Count);

            for (int i = 0; i < count; i++)
            {
                var combo = comboList[i];
                var icon = iconList[i];

                if (!IsValidIndex(combo.DqOpen - 1, dqLen) ||
                    !IsValidIndex(combo.DqClose - 1, dqLen) ||
                    !IsValidIndex(icon.DiOpen - 1, diLen) ||
                    !IsValidIndex(icon.DiClose - 1, diLen) ||
                    !IsValidIndex(icon.DiFault - 1, diLen))
                    continue;

                bool openDQ = e.DQ_value[combo.DqOpen - 1];
                bool closeDQ = e.DQ_value[combo.DqClose - 1];

                bool openDI = e.DI_value[icon.DiOpen - 1];
                bool closeDI = e.DI_value[icon.DiClose - 1];
                bool faultDI = e.DI_value[icon.DiFault - 1];

                ValveState buttonState = openDQ ? ValveState.open : ValveState.close;
                ValveState state;
                if (!openDI && !closeDI && !faultDI)
                {
                    state = ValveState.low;
                }
                else
                {
                    state = faultDI ? ValveState.warning : openDI && !closeDI ? ValveState.open : ValveState.close;
                }
                result.Add((i, buttonState, state));
            }
            return result;
        }
        private static short InvaertedPercentageToCurrent(float percentage)
        {
            percentage = Math.Max(0, Math.Min(100, percentage));
            double invaertedPercentage = 100 - percentage;
            double currentmA = 4 + percentage * 16.0 / 100.0;
            double plcValue = invaertedPercentage * 27648.0 / 100.0;

            int roundedValue = (int)Math.Round(plcValue, MidpointRounding.AwayFromZero);
            if (roundedValue < short.MinValue) roundedValue = short.MinValue;
            if (roundedValue > short.MaxValue) roundedValue = short.MaxValue;
            return (short)roundedValue;
        }
        private static short PercentageToCurrent(float percentage)
        {
            percentage = Math.Max(0, Math.Min(100, percentage));
            double currentmA = 4 + percentage * 16.0 / 100.0;
            double plcValue = (currentmA - 4) * 27648.0 / 16.0;
            int roundedValue = (int)Math.Round(plcValue, MidpointRounding.AwayFromZero);
            if (roundedValue < short.MinValue) roundedValue = short.MinValue;
            if (roundedValue > short.MaxValue) roundedValue = short.MaxValue;
            return (short)roundedValue;
        }
        public static void SendValveCommand(TCPManager tcpManager, bool state, ushort openSN, ushort closeSN, string valveName, string action)
        {
            try
            {
                SendResult = tcpManager.Send_PLC_Command(1, closeSN, !state).IsSuccess;
                Thread.Sleep(50);
                SendResult &= tcpManager.Send_PLC_Command(1, openSN, state).IsSuccess;

                if (SendResult)
                    AddLog(0, $"{valveName}{action}成功");
                else
                    AddLog(1, $"{valveName}{action}失败");
            }
            catch (Exception ex)
            {
                AddLog(2, $"阀门命令发送异常: {ex.Message}");
            }
        }

        private static bool SendResult;
        public static void SendSolenoidValveCommand(TCPManager tcpManager, bool state, ushort sn, string valveName, string action)
        {
            try
            {
                SendResult = tcpManager.Send_PLC_Command(1, sn, state).IsSuccess;
                if (SendResult)
                    AddLog(0, $"{valveName}{action}成功");
                else
                    AddLog(1, $"{valveName}{action}失败");
            }
            catch (Exception ex)
            {
                AddLog(2, $"电磁阀命令发送异常: {ex.Message}");
            }
        }
        public static void SendRegulatingValveCommand(TCPManager tcpManager, ushort sn, ushort percentage, string valveName, bool adjustType)
        {
            try
            {
                short currentValue = 0;
                if (adjustType)
                {
                    currentValue = InvaertedPercentageToCurrent(percentage);
                }
                else
                {
                    currentValue = PercentageToCurrent(percentage);
                }
                byte[] valueBytes = BitConverter.GetBytes(currentValue);
                byte[] aqIndexBytes = BitConverter.GetBytes(sn);
                if (BitConverter.IsLittleEndian) Array.Reverse(aqIndexBytes);
                if (BitConverter.IsLittleEndian) Array.Reverse(valueBytes);
                List<byte> data = new List<byte>();
                data.AddRange(aqIndexBytes);
                data.AddRange(valueBytes);

                OperateResult result = tcpManager.Send_PLC_Command(2, sn, true, data);
                if (result.IsSuccess)
                    AddLog(0, $"{valveName}开度值输入{percentage}%成功");
                else
                    AddLog(1, $"{valveName}开度值输入{percentage}%失败: {result.Message}");
            }
            catch (Exception ex)
            {
                AddLog(2, $"调节阀命令发送异常: {ex.Message}");
            }
        }

        public static List<(int index, ValveState state)> PrepareSolenoidValveStates<T>(UDPValues e, IList<T> solenoid) where T : IAirControlValveBase
        {
            var result = new List<(int, ValveState)>();

            for (int i = 0; i < solenoid.Count; i++)
            {
                if (solenoid[i].DiOpenAndClose != UInt16.MaxValue)
                {
                    int index = solenoid[i].DiOpenAndClose - 1;
                    result.Add((i, e.DI_value[index] ? ValveState.open : ValveState.close));
                }
                else
                {
                    int index = solenoid[i].DqOpenAndClose - 1;
                    result.Add((i, e.DQ_value[index] ? ValveState.open : ValveState.close));
                }
            }
            return result;
        }

        public static void ApplySolenoidValve<T>(List<(int index, ValveState state)> data, IList<T> solenoid) where T : IAirControlValveBase
        {
            foreach (var item in data)
            {
                solenoid[item.index].State = item.state;
            }
        }
    }
}
