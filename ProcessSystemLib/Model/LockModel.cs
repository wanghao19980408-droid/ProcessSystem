using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class LockModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string SensorName { get; set; }

        public float AlarmLow { get; set; }

        public float AlarmMid { get; set; }

        public float AlarmHigh { get; set; }

        public bool IsLocked { get; set; }

        public string LockOwner { get; set; }
    }
}
