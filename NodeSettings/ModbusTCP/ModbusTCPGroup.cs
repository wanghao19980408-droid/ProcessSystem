using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeSettings
{
    /// <summary>
    /// ModbusRTUGroup通信组
    /// </summary>
    public class ModbusTCPGroup:GroupBase
    {
        /// <summary>
        /// 存储区
        /// </summary>
        public ModbusStore StoreArea { get; set; }

        /// <summary>
        /// 开始地址
        /// </summary>
        public ushort Start { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public ushort  Length { get; set; }

        /// <summary>
        /// 变量集合
        /// </summary>
        public List<ModbusTCPVariable> VarList { get; set; } = new List<ModbusTCPVariable>();



    }
}
