using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class AdjustInfo
    {
        public string ValveName { get; set; }
        public string PLCRegion { get; set; }
        public ushort AdjustAI { get; set; }
        public ushort AdjustAQ { get; set; }
        public bool AdjustType { get; set; }
        public string InputValue { get; set; }
    }
}
