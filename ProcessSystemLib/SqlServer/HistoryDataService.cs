using DataConvertLib;
using ProcessSystemLib.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessSystemLib.SqlServer
{
    public class HistoryDataService
    {
        private readonly int[] Struct_count;
        private readonly string Region;

        private bool IsHighSpeedRegion => Region == "高速1" || Region == "高速2";

        public HistoryDataService(string region)
        {
            InitPLCDataStruct();
            TryGetPLCDataStruct(region, out Struct_count);
            Region = region;
        }

        public OperateResult<List<ProcessDataModel>> GetHistoryData(
            DateTime start, DateTime end)
        {
            try
            {
                string tableName = GetTableName();

                var list = SqlSugarHelper.SqlSugarClient
                    .Queryable<ProcessDataModel>()
                    .AS(tableName)
                    .Where(e => SqlFunc.Between(e.dataTime, start, end))
                    .OrderBy(e => e.dataTime)
                    .ToList();

                return OperateResult.CreateSuccessResult(list);
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<List<ProcessDataModel>>(ex.Message);
            }
        }

        public OperateResult<UDPValues> DecodeData(ProcessDataModel model)
        {
            try
            {
                if (model == null)
                    return OperateResult.CreateFailResult<UDPValues>("未查询到数据");
                byte[] bytes = ByteArrayLib.GetByteArrayFromString(model.RXD, Encoding.UTF8);
                var values = new UDPValues();

                if (IsHighSpeedRegion)
                {
                    byte[] highAI = new byte[Struct_count[6]];
                    Array.Copy(bytes, 2, highAI, 0, Struct_count[6]);
                    values.InsertTime = model.dataTime;
                    values.HIGH_AI_value = ShortLib.GetShortArrayFromByteArray(highAI);
                }
                else
                {
                    byte[] DI = new byte[Struct_count[1]];
                    byte[] DQ = new byte[Struct_count[2]];
                    byte[] AQ = new byte[Struct_count[3]];
                    byte[] AI = new byte[Struct_count[5]];

                    Array.Copy(bytes, 2, DI, 0, Struct_count[1]);
                    Array.Copy(bytes, 2 + Struct_count[1], DQ, 0, Struct_count[2]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2], AQ, 0, Struct_count[3]);
                    Array.Copy(bytes, 2 + Struct_count[1] + Struct_count[2] + Struct_count[3], AI, 0, Struct_count[5]);
                    values.InsertTime = model.dataTime;
                    values.DI_value = BitLib.GetBitArrayFromByteArray(DI);
                    values.DQ_value = BitLib.GetBitArrayFromByteArray(DQ);
                    values.AQ_value = ShortLib.GetShortArrayFromByteArray(AQ);
                    values.AI_value = ShortLib.GetShortArrayFromByteArray(AI);
                }

                return OperateResult.CreateSuccessResult(values);
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<UDPValues>(
                    $"Decode failed: {ex.Message}");
            }
        }
        private Dictionary<string, int[]> PLCDataStruct;
        private void InitPLCDataStruct()
        {
            PLCDataStruct = new Dictionary<string, int[]>
            {
                {"中燃",new int[]{197, 12, 8, 16, 1, 160, 0}},
                {"助燃1",new int[]{225, 10, 6, 16, 1, 128, 64}},
                {"配气",new int[]{246, 10, 26, 8, 1, 216, 0 }},
                {"助燃2",new int[]{183, 8, 6, 16, 1, 88, 64 }},
                {"气源",new int[]{89, 4, 4, 16, 1, 64, 0 }},
                {"高速1",new int[]{64, 0, 0, 0, 1, 0, 64}},
                {"高速2",new int[]{64, 0, 0, 0, 1, 0, 64}}
            };
        }
        private bool TryGetPLCDataStruct(string region, out int[] plcStruct)
        {
            return PLCDataStruct.TryGetValue(region, out plcStruct);
        }

        public void InsertTableByteArray(DateTime dt, byte[] data)
        {
            try
            {
                var model = new ProcessDataModel
                {
                    dataTime = DateTime.Now,
                    RXD = data.ToString()
                };
                SqlSugarHelper.SqlSugarClient
                    .Insertable(model)
                    .ExecuteCommand();
            }
            catch (Exception)
            {
            }
        }
        private static readonly Dictionary<string, string> RegionTableMap =
    new Dictionary<string, string>
{
    { "中燃",  "FuelArea" },
    { "助燃1", "FiringI" },
    { "配气",  "Gase" },
    { "助燃2", "FiringII" },
    { "气源",  "GaseSource" },
    { "高速1", "HighOne" },
    { "高速2", "HighTwo" }
};

        private string GetTableName()
        {
            if (!RegionTableMap.TryGetValue(Region, out var table))
                throw new Exception($"未配置区域 {Region} 对应的数据表");

            return table;
        }
    }

}
