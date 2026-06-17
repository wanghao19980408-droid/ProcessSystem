using MiniExcelLibs.Attributes;
using System;


namespace ProcessSystemLib
{
    public class LogReport
    {
        [ExcelColumnName("日期时间")]
        [ExcelFormat("yyyy-MM-dd HH:mm:ss:fff")]
        [ExcelColumnWidth(25)]
        public DateTime InsertTime { get; set; }
        [ExcelColumnName("日志信息")]
        [ExcelColumnWidth(20)]
        public string LogInfo { get; set; }
        [ExcelColumnName("日志类型")]
        [ExcelColumnWidth(12)]
        public string LogType { get; set; }
    }
}
