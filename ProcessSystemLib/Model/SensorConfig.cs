namespace ProcessSystemLib.Model
{
    /// <summary>
    /// 传感器配置模型（建议来自数据库）
    /// </summary>
    public class SensorConfig
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public int AIIndex { get; set; }
        public InputValueType InputType { get; set; }
        public VoltageRange voltageRange { get; set; }
        public CurrentRange currentRange { get; set; }
        public bool IsPT100 { get; set; }
        /// <summary>
        /// 工程量范围
        /// </summary>
        public float MinRange { get; set; }
        public float MaxRange { get; set; }

        /// <summary>
        /// PLC 原始信号映射范围
        /// </summary>
        public short RawMin { get; set; }
        public short RawMax { get; set; }

        /// <summary>
        /// 最终显示单位
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// 原始压力单位
        /// </summary>
        public Unit OriginalPressureUnit { get; set; }

        /// <summary>
        /// 液位计算参数
        /// </summary>
        public float Density { get; set; }
        public float Gravity { get; set; }

        /// <summary>
        /// 流量系数
        /// </summary>
        public float Const { get; set; }

        public bool IsTurbine { get; set; }
    }
}
