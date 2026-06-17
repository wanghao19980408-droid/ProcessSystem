using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeSettings
{
    public class SiemensVariable : VariableBase
    {
        [ExcelIgnore]
        public string VarAddress { get; set; }
    }
}
