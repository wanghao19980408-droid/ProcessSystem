using DataConvertLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.SqlServer
{
    public class UserTableService
    {
        public OperateResult<UserTable> LoginIn(UserTable ud)
        {
            return OperateResult.CreateSuccessResult(SqlSugarHelper.SqlSugarClient.Queryable<UserTable>().Where(e =>
                e.LoginName == ud.LoginName && e.LoginPwd == ud.LoginPwd
            ).First());
        }

        public OperateResult<List<UserTable>> GetAllAdmin()
        {
            try
            {
                return OperateResult.CreateSuccessResult(SqlSugarHelper.SqlSugarClient.Queryable<UserTable>().ToList());
            }
            catch (Exception ex)
            {

                return OperateResult.CreateFailResult<List<UserTable>>(ex.Message);
            }
        }
                

        public int AddUserTable(UserTable ud)
        {
            return SqlSugarHelper.SqlSugarClient.Insertable(ud).ExecuteCommand();
        }

        public int DeleteUserTable(int loginId)
        {
            return SqlSugarHelper.SqlSugarClient.Deleteable<UserTable>().Where(e => e.LoginId == loginId).ExecuteCommand();
        }

        public int ModifyUserTable(UserTable ud)
        {
            return SqlSugarHelper.SqlSugarClient.Updateable(ud).WhereColumns(e => e.LoginId).ExecuteCommand();
        }

        public int GetCountFromLoginId(int loginId)
        {
            return SqlSugarHelper.SqlSugarClient.Queryable<UserTable>().Where(e => e.LoginId == loginId).Count();
        }

        public UserTable GetUserTableFromLoginId(int loginId)
        {
            return SqlSugarHelper.SqlSugarClient.Queryable<UserTable>().Where(e => e.LoginId == loginId).First();
        }

    }
}
