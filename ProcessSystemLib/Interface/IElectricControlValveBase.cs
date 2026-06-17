using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public interface IElectricControlValveBase
    {
        ushort DqClose { get; set; }
        ushort DqOpen { get; set; }
        string ValveName { get; set; }
        ValveState State { get; set; }
        string PLCRegion { get; }
        string WorkStation { get; set; }

        event EventHandler ValveClick;
    }
}
