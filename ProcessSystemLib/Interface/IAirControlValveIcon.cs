using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public interface IAirControlValveIcon:IAirControlValveBase
    {
        ushort DiOpen { get; set; }
        ushort DiClose { get; set; }

    }
}
