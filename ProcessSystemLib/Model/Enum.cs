using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public enum CurrentRange
    {
        ZeroToTwenty,
        ZeroToTen,
        FourToTwenty
    }
    public enum InterlockState
    {
        None = 0,
        Low = 1,
        HighBoth = 2,
        HighSingle = 3
    }
    public enum VoltageRange
    {
        ZeroToFive,
        NegativeFiveToFive,
        OneToFive,
        ZeroToTen
    }

    public enum InputValueType
    {
        PLC_Digital,
        Current,
        Voltage
    }

    public enum ValveState
    {
        open,
        close,
        warning,
        low
    }
    public enum CMD
    {
        single_control = 1,
        q_control = 2,
        reset = 3,
        pid_command = 4,
        lock_command = 5,
        pressurization_command = 6
    };

    public enum PIDParamSeq : byte
    {
        Auto = 0x01,
        SetPoint = 0x02,
        KP = 0x03,
        KI = 0x04,
        KD = 0x05,
        DeadZone = 0x06
    }

    public enum LockParamSeq : byte
    {
        Mode = 0x01,
        SetValue = 0x02,
        HighLimit = 0x03,
        LowLimit = 0x04,
    }

    public enum Unit
    {
        Pa,
        KPa,
        MPa,
        cent,
        kg,
        m,
        mm,
        temp,
        m3h,
        Lmin,
        A,
        RPM,
        g,
        m3_cube,
        KN
    }

    public enum PressureSettingType
    {
        OneOxygen,   // 工位1氧增压
        TwoOxygen,   // 工位2氧增压
        Methane,  // 甲烷增压 (燃)
        Kerosene  // 煤油增压 (燃)
    }
}
