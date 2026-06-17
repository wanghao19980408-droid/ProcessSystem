using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    /// <summary>
    /// 箱压自动调节时序参数
    /// </summary>
    public class TimingPressureParam
    {
        /// <summary>
        /// 当前段持续时间 (单位: 毫秒 ms)
        /// </summary>
        public uint DurationMs { get; set; }

        /// <summary>
        /// 氧箱压力设定值 (单位: MPa)
        /// </summary>
        public float OxygenPressure { get; set; }

        /// <summary>
        /// 燃箱压力设定值 (单位: MPa)
        /// </summary>
        public float FuelPressure { get; set; }
    }
}
