using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class PID
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public float SetPoint { get; set; }
        public string ValveName { get; set; }
        public float Kp { get; set; }
        public float Ki { get; set; }
        public float Kd { get; set; }
        public bool IsAuto { get; set; }

        [SugarColumn(IsNullable = true)]
        public int SensorSetting { get; set; }
    }
}
