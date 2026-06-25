using DataConvertLib;
using ProcessSystemLib.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.SqlServer
{
    public class PidDataService
    {
        public OperateResult<PID> QueryPIDInfo(string valveName)
        {
            var result = SqlSugarHelper.SqlSugarClient.Queryable<PID>()
            .Where(it => it.ValveName == valveName)
            .First();
            if (result!=null)
            {
                return OperateResult.CreateSuccessResult(result);
            }
            else
            {
                return OperateResult.CreateFailResult<PID>("查询失败");
            }
        }

        public OperateResult UpdatePIDInfo(string valveName, PID pidList)
        {
            try
            {
                int result = SqlSugarHelper.SqlSugarClient.Updateable<PID>().SetColumns(it => new PID()
                {
                    SetPoint = pidList.SetPoint,
                    SensorSetting = pidList.SensorSetting,
                    Kp = pidList.Kp,
                    Ki = pidList.Ki,
                    Kd = pidList.Kd,
                    IsAuto = pidList.IsAuto
                }).Where(it => it.ValveName == valveName)
                    .ExecuteCommand();
                if (result == 1)
                {
                    return OperateResult.CreateSuccessResult();

                }
                else
                {
                    return OperateResult.CreateFailResult("Update failed");
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult(ex.Message);
            }
        }
        public OperateResult InsertPIDInfo(string valveName, PID pidInfo)
        {
            try
            {
                var insertObj = new PID()
                {
                    ValveName = valveName,
                    SetPoint = pidInfo.SetPoint,
                    SensorSetting = pidInfo.SensorSetting,
                    Kp = pidInfo.Kp,
                    Ki = pidInfo.Ki,
                    Kd = pidInfo.Kd,
                    IsAuto = pidInfo.IsAuto
                };

                int result = SqlSugarHelper.SqlSugarClient.Insertable<PID>(insertObj).ExecuteCommand();

                if (result > 0)
                {
                    return OperateResult.CreateSuccessResult();
                }
                else
                {
                    return OperateResult.CreateFailResult("Insert failed");
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult(ex.Message);
            }
        }
    }
}
