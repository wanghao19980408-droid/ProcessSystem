using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class PressureStage
    {
        [System.ComponentModel.DisplayName("序号")]
        public int StepId { get; set; }

        [System.ComponentModel.DisplayName("起始时间(s)")]
        public int StartTime { get; set; }

        [System.ComponentModel.DisplayName("结束时间(s)")]
        public int EndTime { get; set; }

        [System.ComponentModel.DisplayName("目标压力(MPa)")]
        public double TargetPressure { get; set; }

        [System.ComponentModel.DisplayName("时序范围")]
        public string TimeRange => $"{StartTime}s ~ {EndTime}s";
    }
}
