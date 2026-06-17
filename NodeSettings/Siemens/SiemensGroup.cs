using CommunicationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeSettings
{
    public class SiemensGroup :GroupBase
    {
        public StoreType StoreArea { get; set; }

        public int DBNo { get; set; }

        public int Start { get; set; }

        public int Count { get; set; }

        public List<SiemensVariable> VarList { get; set; } = new List<SiemensVariable>();
    }
}
