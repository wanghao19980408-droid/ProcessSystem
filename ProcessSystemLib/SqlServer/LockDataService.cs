using DataConvertLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.SqlServer
{
    public class LockDataService
    {
        public OperateResult<LockModel> QueryLockValue(string sensorName)
        {
            try
            {
                var result = SqlSugarHelper.SqlSugarClient
                .Queryable<LockModel>()
                .Where(it => it.SensorName == sensorName)
                .First();
                return result != null
                    ? OperateResult.CreateSuccessResult(result)
                    : OperateResult.CreateFailResult<LockModel>("联锁参数未找到");
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<LockModel>(ex.Message);
            }
        }

        public OperateResult UpdateLockValue(LockModel model)
        {
            var count = SqlSugarHelper.SqlSugarClient.Updateable<LockModel>()
                .SetColumns(it => new LockModel()
                {
                    AlarmHigh = model.AlarmHigh,
                    AlarmMid = model.AlarmMid,
                    AlarmLow = model.AlarmLow,
                    IsLocked = model.IsLocked,
                    LockOwner = model.LockOwner
                })
                .Where(it => it.SensorName == model.SensorName)
                .ExecuteCommand();
            if (count > 0)
            {
                return OperateResult.CreateSuccessResult();
            }
            else
            {
                return OperateResult.CreateFailResult("更新失败");
            }
        }

        public bool TryAcquireExecutionLock(string sensorName, string hostName)
        {
            try
            {
                var count = SqlSugarHelper.SqlSugarClient.Updateable<LockModel>()
                    .SetColumns(it => new LockModel() { LockOwner = hostName })
                    .Where(it => it.SensorName == sensorName &&
                                (it.LockOwner == null || it.LockOwner == "" || it.LockOwner == hostName))
                    .ExecuteCommand();

                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        public void ReleaseExecutionLock(string sensorName, string hostName)
        {
            try
            {
                SqlSugarHelper.SqlSugarClient.Updateable<LockModel>()
                    .SetColumns(it => new LockModel() { LockOwner = "" })
                    .Where(it => it.SensorName == sensorName && it.LockOwner == hostName)
                    .ExecuteCommand();
            }
            catch { }
        }

    }
}
