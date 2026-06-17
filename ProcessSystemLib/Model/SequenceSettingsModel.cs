using SqlSugar;
using System.ComponentModel;

namespace ProcessSystemLib.Model
{
    public class SequenceSettingsModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(IsNullable = false)]
        public PressureSettingType SettingType { get; set; }

        [SugarColumn(IsNullable = false, IsJson = true)]
        public BindingList<PressureStage> StageList { get; set; }
    }
}