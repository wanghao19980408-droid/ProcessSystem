using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public interface IAirControlValveBase : IElectricControlValveBase
    {
        ushort DqOpenAndClose { get; set; }
        ushort DiOpenAndClose { get; set; }
        bool Enable {  get; set; }
    }
}
