using ProcessSystemLib;
using ProcessSystemLib.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessControlLib
{

    public partial class FiringIISensor : UserControl, ISensorBase
    {
        public FiringIISensor()
        {
            InitializeComponent();
        }

        private string sensorName { get; set; } = "助燃II传感器";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置传感器名称")]
        public string SensorName
        {
            get
            {
                return sensorName;
            }
            set
            {
                if (sensorName != value)
                {
                    sensorName = value;
                    this.label1.Text = value;
                }

            }
        }

        #region 核心转换参数
        private const double CurrentTolerance = 1.6;
        private const double VoltageTolerance = 0.1;
        private const double PLCTolerance = 1500;
        #endregion

        #region 转换逻辑（核心：压力→液位→立方）
        public double ConvertToPhysical(double inputValue)
        {
            try
            {
                double signalValue = ConvertToStandardSignal(inputValue);
                if (double.IsNaN(signalValue))
                {
                    lb_Value.ForeColor = Color.Red;
                    return double.NaN;
                }

                double physicalValue;

                if (directCalibration)
                {
                    physicalValue = ApplyCalibration(signalValue);
                }
                else
                {
                    physicalValue = SignalToPressure(signalValue);
                    if (double.IsNaN(physicalValue))
                    {
                        lb_Value.ForeColor = Color.Red;
                        return double.NaN;
                    }
                }

                physicalValue = ApplyUnitConversions(physicalValue);

                lb_Value.ForeColor = SensorValueColor;
                return physicalValue;
            }
            catch
            {
                lb_Value.ForeColor = Color.Red;
                return double.NaN;
            }
        }
        private string workStation { get; set; }
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("获取或设置所属工位")]
        public string WorkStation
        {
            get
            {
                return workStation;
            }
            set
            {
                if (workStation != value)
                {
                    workStation = value;
                }
            }
        }
        private double SignalToPressure(double signalValue)
        {
            var (signalMin, signalMax) = InputType == InputValueType.Voltage
                ? GetVoltageRangeParams()
                : GetCurrentRangeParams();

            return MinSensorRange + ((signalValue - signalMin) / (signalMax - signalMin)) *
                  (MaxSensorRange - MinSensorRange);
        }

        private double ConvertToStandardSignal(double inputValue)
        {
            switch (InputType)
            {
                case InputValueType.PLC_Digital:
                    return ConvertPLCToSignal(inputValue);
                case InputValueType.Current:
                    return ValidateCurrent(inputValue);
                case InputValueType.Voltage:
                    return ValidateVoltage(inputValue);
                default:
                    return double.NaN;
            }
        }

        private double ConvertPLCToSignal(double plcValue)
        {
            var (signalMin, signalMax) = GetCurrentRangeParams();
            double plcMin = 0;
            double plcMax = DigitalRange;

            if (plcMax <= plcMin || signalMax <= signalMin)
                return double.NaN;

            if (plcValue < plcMin - PLCTolerance || plcValue > plcMax + PLCTolerance)
                return double.NaN;

            return signalMin + ((plcValue - plcMin) / (plcMax - plcMin)) * (signalMax - signalMin);
        }

        private double ValidateCurrent(double current)
        {
            var (min, max) = GetCurrentRangeParams();
            if (current < min - CurrentTolerance || current > max + CurrentTolerance)
                return double.NaN;
            return current;
        }

        private double ValidateVoltage(double voltage)
        {
            var (min, max) = GetVoltageRangeParams();
            if (voltage < min - VoltageTolerance || voltage > max + VoltageTolerance)
                return double.NaN;
            return voltage;
        }

        private double ApplyCalibration(double value)
        {
            return value * KValue + BValue;
        }


        private double ApplyUnitConversions(double physicalValue)
        {
            if (unit == Unit.m || unit == Unit.mm)
                return CalculateLevel(physicalValue);

            if (unit == Unit.m3_cube)
            {
                return CalculateCube(physicalValue);
            }

            if (tFMState && (unit == Unit.m3h || unit == Unit.Lmin))
                return CalculateFlow(physicalValue);

            return physicalValue;
        }

        private double CalculateLevel(double pressureValue)
        {
            if (Density <= 0 || Gravity <= 0) return double.NaN;

            double pressureInPa = pressureValue;
            switch (OriginalPressureUnit)
            {
                case Unit.KPa:
                    pressureInPa *= 1000;
                    break;
                case Unit.MPa:
                    pressureInPa *= 1000000;
                    break;
                case Unit.Pa:
                default:
                    break;
            }

            double levelInMeters = pressureInPa / (Density * Gravity);

            return unit == Unit.mm ? levelInMeters * 1000 : levelInMeters;
        }
        private double CalculateCube(double levelValue)
        {
            switch (Density)
            {
                case 808:
                    return (407.48 * levelValue / 0.98 - 563.8) / 1000;
                case 1140:
                    return 0.5477 * levelValue - 1.2492;
                case 810:
                    return 0.7564 * levelValue + 3.74;
                default:
                    return levelValue;
            }
        }
        private double CalculateFlow(double flowValue)
        {
            if (speedValue <= 0) return double.NaN;
            double flow = flowValue / speedValue;

            switch (unit)
            {
                case Unit.m3h:
                    return flow * 3600 / 1000;
                case Unit.Lmin:
                    return flow * 60;
                default:
                    return flow;
            }
        }

        private (double min, double max) GetCurrentRangeParams()
        {
            switch (CurrentRange)
            {
                case CurrentRange.ZeroToTwenty:
                    return (0, 20);
                case CurrentRange.ZeroToTen:
                    return (0, 10);
                case CurrentRange.FourToTwenty:
                    return (4, 20);
                default:
                    return (4, 20);
            }
        }

        private (double min, double max) GetVoltageRangeParams()
        {
            switch (VoltageRange)
            {
                case VoltageRange.ZeroToFive:
                    return (0, 5);
                case VoltageRange.NegativeFiveToFive:
                    return (-5, 5);
                case VoltageRange.OneToFive:
                    return (1, 5);
                case VoltageRange.ZeroToTen:
                    return (0, 10);
                default:
                    return (0, 5);
            }
        }
        #endregion

        private bool directCalibration = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("是否直接使用KX+B公式校准（跳过量程转换）")]
        public bool DirectCalibration
        {
            get { return directCalibration; }
            set { directCalibration = value; }
        }

        private bool isPT100 = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取PT100三线制")]
        public bool IsPT100
        {
            get { return isPT100; }
            set { isPT100 = value; }
        }

        public event Action<double> OnConvertedValueChanged;

        private double physicalValue;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器物理量")]
        public double PhysicalValue
        {
            get => physicalValue;
            private set => physicalValue = value;
        }

        private Color sensorNameColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取位号颜色")]
        public Color SensorNameColor
        {
            get => sensorNameColor;
            set
            {
                sensorNameColor = value;
                this.label1.ForeColor = value;
            }
        }

        private Color sensorValueColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器值颜色")]
        public Color SensorValueColor
        {
            get => sensorValueColor;
            set
            {
                sensorValueColor = value;
                this.lb_Value.ForeColor = value;
            }
        }

        private Color sensorUnitColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器单位颜色")]
        public Color SensorUnitColor
        {
            get => sensorUnitColor;
            set
            {
                sensorUnitColor = value;
                this.lb_Unit.ForeColor = value;
            }
        }

        private string sensorValue;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器模拟量值")]
        public string SensorValue
        {
            get => sensorValue;
            set
            {
                sensorValue = value;
                if (!double.TryParse(value, out var parsed))
                    return;

                if (!isPT100)
                {
                    physicalValue = ConvertToPhysical(parsed);
                }
                else
                {
                    physicalValue = parsed / 100.0d;
                }

                lb_Value.Text = ToTruncatedString(physicalValue, decimalPlaces);

                OnConvertedValueChanged?.Invoke(physicalValue);
            }
        }

        private CurrentRange currentRange = CurrentRange.FourToTwenty;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取电流范围（电流模式和PLC数字量模式使用）")]
        public CurrentRange CurrentRange
        {
            get { return currentRange; }
            set { currentRange = value; }
        }

        private VoltageRange voltageRange = VoltageRange.ZeroToFive;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取电压范围（电压模式使用）")]
        public VoltageRange VoltageRange
        {
            get { return voltageRange; }
            set { voltageRange = value; }
        }

        private ushort ai = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器AI")]
        public ushort AI
        {
            get { return ai; }
            set { ai = value; }
        }

        private bool sensorPostion = true;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取位号显示位置")]
        public bool SensorPostion
        {
            get { return sensorPostion; }
            set
            {
                sensorPostion = value;
                if (sensorPostion)
                {
                    this.Size = new Size(200, 25);
                    this.label1.Size = new Size(90, 25);
                    this.label1.Dock = DockStyle.Left;
                    this.lb_Value.Dock = DockStyle.Right;
                    this.lb_Unit.Dock = DockStyle.Right;
                }
                else
                {
                    this.Size = new Size(108, 50);
                    this.label1.Dock = DockStyle.Top;
                    this.lb_Value.Dock = DockStyle.Left;
                    this.lb_Unit.Dock = DockStyle.Right;
                }
            }
        }

        private float speedValue;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("流量计仪表常数")]
        public float SpeedValue
        {
            get { return speedValue; }
            set { speedValue = value; }
        }

        private float minSensorRange;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器最小量程")]
        public float MinSensorRange
        {
            get { return minSensorRange; }
            set { minSensorRange = value; }
        }

        private bool tFMState = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取是否开启涡轮流量计计算")]
        public bool TFMState
        {
            get { return tFMState; }
            set { tFMState = value; }
        }

        private float maxSensorRange = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取传感器最大量程")]
        public float MaxSensorRange
        {
            get { return maxSensorRange; }
            set { maxSensorRange = value; }
        }

        private int digitalRange = 27648;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取数字量范围（PLC数字量模式使用）")]
        public int DigitalRange
        {
            get { return digitalRange; }
            set { digitalRange = value; }
        }

        private Unit unit = Unit.MPa;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取单位")]
        public Unit Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                switch (value)
                {
                    case Unit.Pa:
                        lb_Unit.Text = "Pa";
                        break;
                    case Unit.KPa:
                        lb_Unit.Text = "KPa";
                        break;
                    case Unit.MPa:
                        lb_Unit.Text = "MPa";
                        break;
                    case Unit.cent:
                        lb_Unit.Text = "%";
                        break;
                    case Unit.kg:
                        lb_Unit.Text = "kg/s";
                        break;
                    case Unit.m:
                        lb_Unit.Text = "m";
                        break;
                    case Unit.mm:
                        lb_Unit.Text = "mm";
                        break;
                    case Unit.temp:
                        lb_Unit.Text = "℃";
                        break;
                    case Unit.m3h:
                        lb_Unit.Text = "m³/h";
                        break;
                    case Unit.Lmin:
                        lb_Unit.Text = "L/min";
                        break;
                    case Unit.g:
                        lb_Unit.Text = "g";
                        break;
                    case Unit.RPM:
                        lb_Unit.Text = "RPM";
                        break;
                    case Unit.A:
                        lb_Unit.Text = "A";
                        break;
                    case Unit.m3_cube:
                        lb_Unit.Text = "m³";
                        break;
                    case Unit.KN:
                        lb_Unit.Text = "KN";
                        break;
                    default:
                        break;
                }
            }
        }

        private Unit originalPressureUnit = Unit.Pa;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取压力传感器的原始单位（用于液位/立方计算）")]
        public Unit OriginalPressureUnit
        {
            get { return originalPressureUnit; }
            set { originalPressureUnit = value; }
        }

        private int decimalPlaces = 2;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取保留小数点的位数")]
        public int DecimalPlaces
        {
            get { return decimalPlaces; }
            set
            {
                decimalPlaces = value;
                lb_Value.Text = ToTruncatedString(PhysicalValue, decimalPlaces);
            }
        }
        private static string ToTruncatedString(double value, int decimals)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                return value.ToString();

            if (decimals < 0)
                return value.ToString("G17");

            double factor = Math.Pow(10, decimals);
            double truncated = Math.Truncate(value * factor) / factor;

            return truncated.ToString($"F{decimals}");
        }

        private float zeroOffset = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取零点偏移量")]
        public float ZeroOffset
        {
            get { return zeroOffset; }
            set { zeroOffset = value; }
        }

        private float sensitivityCalibrationFactor = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取灵敏度校准系数")]
        public float SensitivityCalibrationFactor
        {
            get { return sensitivityCalibrationFactor; }
            set { sensitivityCalibrationFactor = value; }
        }

        private float kValue = 1;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取K值，用于公式运算(KX+B)")]
        public float KValue
        {
            get { return kValue; }
            set { kValue = value; }
        }

        private float bValue = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取B值，用于公式运算(KX+B)")]
        public float BValue
        {
            get { return bValue; }
            set { bValue = value; }
        }

        private InputValueType inputType = InputValueType.PLC_Digital;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取输入值的类型（PLC数字量/电流/电压）")]
        public InputValueType InputType
        {
            get { return inputType; }
            set { inputType = value; }
        }

        private float density = 1000f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取液体密度（单位：kg/m³，如水为1000）")]
        public float Density
        {
            get { return density; }
            set { density = value; }
        }

        private float gravity = 9.8f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取重力加速度（单位：m/s²，默认9.8）")]
        public float Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }

        private float tankArea = 1f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取容器底面积（单位：m²，用于立方计算）")]
        public float TankArea
        {
            get { return tankArea; }
            set { tankArea = value; }
        }
    }
}
