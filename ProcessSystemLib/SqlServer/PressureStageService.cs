using DataConvertLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ProcessSystemLib.SqlServer
{
    public class PressureStageService
    {
        public OperateResult<SequenceSettingsModel> QueryPressureSetting(PressureSettingType SettingType)
        {
            try
            {
                var result = SqlSugarHelper.SqlSugarClient.Queryable<SequenceSettingsModel>()
                    .Where(it => it.SettingType == SettingType)
                    .First();

                if (result != null)
                {
                    return OperateResult.CreateSuccessResult(result);
                }
                else
                {
                    return OperateResult.CreateFailResult<SequenceSettingsModel>("暂无数据");
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<SequenceSettingsModel>($"查询异常: {ex.Message}");
            }
        }

        public OperateResult UpdatePressureSetting(BindingList<PressureStage> StageList, PressureSettingType SettingType)
        {
            try
            {
                var db = SqlSugarHelper.SqlSugarClient;

                bool isExists = db.Queryable<SequenceSettingsModel>().Any(it => it.SettingType == SettingType);

                if (isExists)
                {
                    int result = db.Updateable<SequenceSettingsModel>()
                        .SetColumns(it => it.StageList == StageList)
                        .Where(it => it.SettingType == SettingType)
                        .ExecuteCommand();

                    return result > 0 ? OperateResult.CreateSuccessResult() : OperateResult.CreateFailResult("更新受影响行数为0");
                }
                else
                {
                    var newRecord = new SequenceSettingsModel
                    {
                        SettingType = SettingType,
                        StageList = StageList
                    };

                    int result = db.Insertable(newRecord).ExecuteCommand();

                    return result > 0 ? OperateResult.CreateSuccessResult() : OperateResult.CreateFailResult("新增数据失败");
                }
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult($"保存异常: {ex.Message}");
            }
        }
    }
}