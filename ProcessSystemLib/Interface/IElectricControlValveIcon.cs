using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public interface IElectricControlValveIcon : IElectricControlValveBase
    {
        ushort DiClose { get; set; }
        ushort DiFault { get; set; }
        ushort DiOpen { get; set; }
    }
}
