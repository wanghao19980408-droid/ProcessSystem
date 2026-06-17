using DataConvertLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.SqlServer
{
    public class TitleDataService
    {
        public OperateResult<List<string>> QueryTitles(string stationName)
        {
            var model = SqlSugarHelper.SqlSugarClient
                .Queryable<GasSupplyStationModel>()
                .Where(x => x.StationName == stationName)
                .First();

            if (model == null)
                return OperateResult.CreateFailResult<List<string>>("配气台不存在");

            return OperateResult.CreateSuccessResult(model.Titles);
        }

        public OperateResult UpdateTitles(string stationName, List<string> titles)
        {
            if (titles == null || titles.Count == 0)
                return OperateResult.CreateFailResult("标题不能为空");

            if (titles.Count > 10)
                return OperateResult.CreateFailResult("最多支持 10 个标题");

            var model = new GasSupplyStationModel
            {
                StationName = stationName
            };

            model.SetTitles(titles);

            var count = SqlSugarHelper.SqlSugarClient
                .Updateable(model)
                .UpdateColumns(x => new
                {
                    x.TitleName1,
                    x.TitleName2,
                    x.TitleName3,
                    x.TitleName4,
                    x.TitleName5,
                    x.TitleName6,
                    x.TitleName7,
                    x.TitleName8,
                    x.TitleName9,
                    x.TitleName10
                })
                .Where(x => x.StationName == stationName)
                .ExecuteCommand();

            return count > 0
                ? OperateResult.CreateSuccessResult()
                : OperateResult.CreateFailResult("更新失败");
        }


    }
}
