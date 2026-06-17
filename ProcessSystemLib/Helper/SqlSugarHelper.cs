using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib
{
    public class SqlSugarHelper
    {
        public static string ConnectionString { get; set; } = string.Empty;

        public static SqlSugarClient SqlSugarClient
        {
            get
            {
                SqlSugarClient sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                });
                sqlSugarClient.Aop.OnLogExecuted = (sql,pars) =>
                {
                    //获取原生SQL推荐 5.1.4.63  性能OK
                    //Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

                    //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                    //Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars))
                };
                return sqlSugarClient;
            }
        }

    }
}
