using ProcessControlLib;
using ProcessSystemLib;
using ProcessSystemLib.SqlServer;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class ProcessStation : Form
    {
        public Action<int, string> AddLog;

        public Action<object, EventArgs> LockClick;

        private FormMain FormMain;
        private TCPManager TCP { get; set; }

        private List<Dictionary<string, object>> List;
        public ProcessStation(TCPManager tcp, FormMain formMain)
        {
            InitializeComponent();
            this.FormMain = formMain;
            this.List = formMain.GaseSupply_Sensor;
            this.TCP = tcp;
            this.Load += ProcessStation_Load;
            FormMain.GaseSensorDataUpdated += MainForm_GaseSensorDataUpdated;
        }
        TitleDataService titleDataService = new TitleDataService();

        private void ProcessStation_Load(object sender, EventArgs e)
        {
            this.btn_Allow.Symbol = 61475;
            this.btn_Allow.SymbolColor = Color.Red;
        }

        public void MainForm_GaseSensorDataUpdated(UDPValues e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (var item in panel2.Controls.OfType<UCComboBoxcs>())
                    {
                        if (item.Tag == null)
                        {
                            AddLog(2, "控件Tag为空，跳过处理");
                            continue;
                        }

                        string[] tagParts = item.Tag.ToString().Split('-');
                        if (tagParts.Length < 2)
                        {
                            AddLog(2, $"控件Tag格式错误: {item.Tag}（需格式：位号-索引）");
                            continue;
                        }

                        foreach (var sensor in List)
                        {
                            if (sensor.TryGetValue("Name", out object tagObj) && tagObj.ToString() == tagParts[0])
                            {
                                if (sensor.TryGetValue("MaxSensorRange", out object maxObj) &&
                                    sensor.TryGetValue("MinSensorRange", out object minObj))
                                {
                                    item.MaxSensorRange = Convert.ToSingle(maxObj);
                                    item.MinSensorRange = Convert.ToSingle(minObj);
                                }

                                if (int.TryParse(tagParts[1], out int aiIndex) &&
                                    aiIndex >= 0 && aiIndex < e.AI_value.Length)
                                {
                                    item.SensorValue = e.AI_value[aiIndex].ToString();
                                }
                                else
                                {
                                    AddLog(2, $"AI索引无效: {tagParts[1]}（超出范围）");
                                }
                                break;
                            }
                        }
                    }

                    foreach (var item in panel2.Controls.OfType<radiotube>())
                    {
                        if (item.Tag == null)
                        {
                            AddLog(2, "控件Tag为空，跳过处理");
                            continue;
                        }

                        if (int.TryParse(item.Tag.ToString(), out int dqSn) &&
                            dqSn - 1 >= 0 && dqSn - 1 < e.DQ_value.Length)
                        {
                            item.State = e.DQ_value[dqSn - 1];
                        }
                        else
                        {
                            AddLog(2, $"DQ序号无效: {item.Tag}（超出范围）");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                AddLog(2, $"数据刷新异常: {ex.Message}");
            }
        }
        #region 无边框拖动

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + e.X - mPoint.X, Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private bool Result;
        private string ValveName;
        private ushort DQsn;
        private bool ValveState;
        private string Action;
        private void Radiotube_Click(object sender, EventArgs e)
        {
            if (sender is radiotube radiotube)
            {
                ValveName = radiotube.ValveName;
                DQsn = Convert.ToUInt16(radiotube.Tag);
                ValveState = radiotube.State;
                Action = ValveState ? "关阀" : "开阀";
                if (TCP != null && TCP.IsConnected)
                {
                    Result = TCP.Send_PLC_Command(1, DQsn, !ValveState).IsSuccess;
                    if (Result)
                    {
                        AddLog(0, $"{ValveName}{Action}成功");
                    }
                    else
                    {
                        AddLog(1, $"{ValveName}{Action}失败");
                    }
                }
                else
                {
                    AddLog(2, $"{ValveName}{Action}失败,配气TCP连接异常");
                }
            }
        }

        private void btn_OpenLock_Click(object sender, EventArgs e)
        {
            this.LockClick(sender, e);
        }
        public bool IsAllow { get; set; } = true;
        private readonly string iniFilePath = Application.StartupPath + "\\GaseSupplyTitle";
        private void Btn_Allow_Click(object sender, EventArgs e)
        {
            if (IsAllow)
            {
                IsAllow = false;
                this.btn_Allow.Symbol = 61758;
                this.btn_Allow.SymbolColor = Color.Lime;
                foreach (var item in this.panel2.Controls.OfType<UITextBox>())
                {
                    item.Enabled = true;
                }
            }
            else
            {

                this.btn_Allow.Symbol = 61475;
                this.btn_Allow.SymbolColor = Color.Red;
                IsAllow = true;

                var titles = panel2.Controls
                                   .OfType<UITextBox>()
                                   .OrderBy(t => t.TabIndex)
                                   .Select(t => t.Text.Trim())
                                   .Where(t => !string.IsNullOrEmpty(t))
                                   .ToList();

                var res = titleDataService.UpdateTitles("ProcessStation", titles);

                if (res.IsSuccess)
                {
                    AddLog(0, "配气台标题保存成功");
                }
                else
                {
                    AddLog(1, res.Message);
                }

                foreach (var item in panel2.Controls.OfType<UITextBox>())
                {
                    item.Enabled = false;
                }
            }
        }

        private async void ProcessStation_VisibleChanged(object sender, EventArgs e)
        {
            var res = await Task.Run(() => titleDataService.QueryTitles("ProcessStation"));
            if (!res.IsSuccess) return;
            var titles = res.Content;
            int i = 0;
            foreach (var item in panel2.Controls.OfType<UITextBox>().OrderBy(t => t.TabIndex))
            {
                item.Text = i < titles.Count ? titles[i] : string.Empty;
                item.Enabled = false;
                i++;
            }
        }
    }
}
