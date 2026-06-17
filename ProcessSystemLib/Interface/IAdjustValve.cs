using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public interface IAdjustValve
    {
        string ValveName { get; set; }
        string PLCRegion { get; }
        ushort AdjustAI { get; set; }
        ushort AdjustAQ { get; set; }
        bool AdjustType { get; set; }
        string AdjustValue { get; set; }
        bool AdjustFeedback { get; set; }

        event EventHandler<AdjustInfo> AdjustValveClick;
    }
}

