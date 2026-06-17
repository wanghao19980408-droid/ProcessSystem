using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSystemLib.Model
{
    public class GasSupplyStationModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [SugarColumn(IsNullable = true)]
        public string StationName { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName1 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName2 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName3 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName4 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName5 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName6 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName7 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName8 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName9 { get; set; }
        [SugarColumn(IsNullable = true)]
        public string TitleName10 { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<string> Titles
        {
            get => new List<string>()
            {
                TitleName1,
                TitleName2,
                TitleName3,
                TitleName4,
                TitleName5,
                TitleName6,
                TitleName7,
                TitleName8,
                TitleName9,
                TitleName10
            }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public void SetTitles(List<string> titles)
        {
            TitleName1 = titles.ElementAtOrDefault(0);
            TitleName2 = titles.ElementAtOrDefault(1);
            TitleName3 = titles.ElementAtOrDefault(2);
            TitleName4 = titles.ElementAtOrDefault(3);
            TitleName5 = titles.ElementAtOrDefault(4);
            TitleName6 = titles.ElementAtOrDefault(5);
            TitleName7 = titles.ElementAtOrDefault(6);
            TitleName8 = titles.ElementAtOrDefault(7);
            TitleName9 = titles.ElementAtOrDefault(8);
            TitleName10 = titles.ElementAtOrDefault(9);
        }
    }
}
