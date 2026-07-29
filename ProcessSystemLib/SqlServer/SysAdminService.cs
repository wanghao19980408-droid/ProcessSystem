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
                

        public OperateResult<int> AddUserTable(UserTable ud)
        {
            try
            {
                return OperateResult<int>.CreateSuccessResult(SqlSugarHelper.SqlSugarClient.Insertable(ud).ExecuteCommand());

            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<int>(ex.Message);
            }
        }

        public OperateResult<int> DeleteUserTable(int loginId)
        {
            try
            {
                return OperateResult<int>.CreateSuccessResult(SqlSugarHelper.SqlSugarClient.Deleteable<UserTable>().Where(e => e.LoginId == loginId).ExecuteCommand());

            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<int>(ex.Message);
            }
        }

        public OperateResult<int> ModifyUserTable(UserTable ud)
        {
            try
            {
                return OperateResult<int>.CreateSuccessResult(SqlSugarHelper.SqlSugarClient.Updateable(ud).WhereColumns(e => e.LoginId).ExecuteCommand());

            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<int>(ex.Message);
            }
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
