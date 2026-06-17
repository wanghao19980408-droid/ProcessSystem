using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class ProcessDataModel
    {
        //[SugarColumn(ColumnName = "dataTime")]
        public DateTime dataTime { get; set; }
        public string RXD { get; set; }
    }
}
