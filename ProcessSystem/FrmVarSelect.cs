using ProcessSystemLib;
using ProcessSystemLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProcessSystem
{
    public partial class FrmVarSelect : Form
    {
        private Dictionary<string, List<Dictionary<string, object>>> DataConfig;

        public Dictionary<string, SensorConfig> ParamList { get; private set; } = new Dictionary<string, SensorConfig>();

        public FrmVarSelect(FormMain formMain, Dictionary<string, SensorConfig> param)
        {
            InitializeComponent();
            this.TopMost = true;
            this.cb_Region.SelectedIndex = 0;
            this.ParamList = param;
            DataConfig = new Dictionary<string, List<Dictionary<string, object>>>
            {
                {"中燃",formMain.FuelArea_Sensor},
                {"助燃1",formMain.FiringI_Sensor},
                {"配气",formMain.GaseSupply_Sensor},
                {"助燃2",formMain.FiringII_Sensor},
                {"气源",formMain.FuelArea_Sensor},
                {"高速1",formMain.HighI},
                {"高速2",formMain.HighII}
            };
            this.uiCheckBoxGroup1.ValueChanged += UiCheckBoxGroup1_ValueChanged;
            this.Load += FrmVarSelect_Load;
        }

        private void UiCheckBoxGroup1_ValueChanged(object sender, Sunny.UI.CheckBoxGroupEventArgs e)
        {
            if (e.Index < 0 || e.Index >= uiCheckBoxGroup1.Items.Count) return;

            string name = uiCheckBoxGroup1.Items[e.Index].ToString();
            string region = cb_Region.Text.Trim();

            if (e.Checked)
            {
                if (!ParamList.ContainsKey(name))
                {
                    var sensor = LoadSensorConfig(region, name);
                    if (sensor != null)
                        ParamList.Add(name, sensor);
                }
            }
            else
            {
                if (ParamList.ContainsKey(name))
                    ParamList.Remove(name);

                this.BeginInvoke((Action)(() =>
                {
                    var selectedIndexes = uiCheckBoxGroup1.SelectedIndexes.ToList();

                    uiCheckBoxGroup1.Items.RemoveAt(e.Index);

                    List<int> newSelectedIndexes = new List<int>();
                    foreach (int idx in selectedIndexes)
                    {
                        if (idx < e.Index)
                            newSelectedIndexes.Add(idx);
                        else if (idx > e.Index)
                            newSelectedIndexes.Add(idx - 1);
                    }

                    uiCheckBoxGroup1.SelectedIndexes = newSelectedIndexes;
                }));
            }
        }

        private void FrmVarSelect_Load(object sender, EventArgs e)
        {
            if (ParamList.Count > 0)
            {
                foreach (var item in ParamList.Keys)
                {
                    this.uiCheckBoxGroup1.ValueChanged -= UiCheckBoxGroup1_ValueChanged;
                    uiCheckBoxGroup1.Items.Add(item);
                    int newIndex = uiCheckBoxGroup1.Items.IndexOf(item);
                    if (newIndex >= 0)
                    {
                        var indexes = uiCheckBoxGroup1.SelectedIndexes.ToList();
                        indexes.Add(newIndex);
                        uiCheckBoxGroup1.SelectedIndexes = indexes;
                    }
                    this.uiCheckBoxGroup1.ValueChanged += UiCheckBoxGroup1_ValueChanged;
                }
            }
        }

        #region 添加传感器
        private void btn_OK_Click(object sender, EventArgs e)
        {
            string region = cb_Region.Text.Trim();
            string name = tb_name.Text.Trim();

            if (string.IsNullOrEmpty(region) || string.IsNullOrEmpty(name)) return;

            if (ParamList.ContainsKey(name) || uiCheckBoxGroup1.Items.Contains(name))
            {
                new FrmMsgNoAck($"传感器 {name} 已存在！", "输入确认").ShowDialog();
                return;
            }

            var sensor = LoadSensorConfig(region, name);
            if (sensor == null)
            {
                new FrmMsgNoAck($"未查询到传感器 {name}", "检索确认").ShowDialog();
                return;
            }

            uiCheckBoxGroup1.Items.Add(name);

            int newIndex = uiCheckBoxGroup1.Items.IndexOf(name);
            if (newIndex >= 0)
            {
                var indexes = uiCheckBoxGroup1.SelectedIndexes.ToList();
                indexes.Add(newIndex);
                uiCheckBoxGroup1.SelectedIndexes = indexes;
            }

            if (!ParamList.ContainsKey(name))
                ParamList.Add(name, sensor);

            tb_name.Clear();
        }
        #endregion

        #region 读取传感器配置
        private bool TryGetDataConfig(string region, out List<Dictionary<string, object>> config)
        {
            return DataConfig.TryGetValue(region, out config);
        }

        private SensorConfig LoadSensorConfig(string region, string name)
        {
            if (!TryGetDataConfig(region, out var cfg)) return null;

            var item = cfg.Find(c => c["Name"].ToString().Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
            if (item == null) return null;

            SensorConfig sc = new SensorConfig
            {
                Name = item.TryGetValue("Name", out var n) ? n.ToString() : string.Empty,
                Region = region,
                AIIndex = item.TryGetValue("AI", out var ai) && ushort.TryParse(ai?.ToString(), out ushort aiVal) ? (ushort)(aiVal - 1) : (ushort)0,
                MaxRange = item.TryGetValue("MaxSensorRange", out var max) && float.TryParse(max?.ToString(), out float maxVal) ? maxVal : 0,
                MinRange = item.TryGetValue("MinSensorRange", out var min) && float.TryParse(min?.ToString(), out float minVal) ? minVal : 0
            };

            if (item.TryGetValue("Type", out var type))
            {
                switch (type.ToString())
                {
                    case "液位":
                        sc.Unit = Unit.m;
                        sc.Density = item.TryGetValue("Density", out var den) && float.TryParse(den?.ToString(), out float d) ? d : 1000;
                        sc.Gravity = item.TryGetValue("Gravity", out var g) && float.TryParse(g?.ToString(), out float gv) ? gv : 9.81f;
                        sc.OriginalPressureUnit = item.TryGetValue("Unit", out var u) && Enum.TryParse<Unit>(u.ToString(), out Unit res) ? res : Unit.Pa;
                        break;
                    case "PT100":
                        sc.IsPT100 = true;
                        sc.Unit = Unit.temp;
                        break;
                    case "涡轮":
                        if (item.TryGetValue("Const", out var ct) && float.TryParse(ct.ToString(), out float val))
                        {
                            sc.IsTurbine = true;
                            sc.Const = val;
                            sc.Unit = Unit.m3h;
                        }
                        break;
                    default:
                        sc.Unit = item.TryGetValue("Unit", out var opu) && Enum.TryParse<Unit>(opu.ToString(), out Unit result) ? result : Unit.Pa;
                        break;
                }
            }

            return sc;
        }
        #endregion

        #region 无边框拖动
        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e) => mPoint = e.Location;
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
        }
        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
