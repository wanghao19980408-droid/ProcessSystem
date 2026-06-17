using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class AlarmState
    {
        public bool HighAlarmTriggered { get; set; }
        public bool LowAlarmTriggered { get; set; }
        public bool HHighAlarmTriggered { get; set; }
    }
}
