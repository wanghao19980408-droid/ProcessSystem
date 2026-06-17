using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public static class SqlSugarService
    {

        public static void SetConnectionString(string connectionStr)
        {
            SqlSugarHelper.ConnectionString = connectionStr;
        }

        public static void CreateTable<T>(int tableLength = 100){
            SqlSugarHelper.SqlSugarClient.CodeFirst.SetStringDefaultLength(tableLength).InitTables(typeof(T));
        }
    }
}
