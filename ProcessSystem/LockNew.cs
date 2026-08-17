using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ProcessSystemLib.TCPManager;

namespace ProcessSystem
{
    public partial class LockNew : Form
    {
        #region 字段与配置

        private static readonly Dictionary<int, string[]> ModeMap = new Dictionary<int, string[]>()
        {
            { 1, new[] { "无设定模式" } },
            { 6, new[] { "PT214", "PT215", "PT216" } },
            { 7, new[] { "PT218", "PT219", "PT220", "PT223" } },
            { 9, new[] { "PT401", "PT401a", "PT401b" } },
            { 10, new[] { "PT202", "PT203" } },
            { 11, new[] { "PT306", "PT307", "PT308" } },
            { 12, new[] { "PT401", "PT401a", "PT401b", "PT306", "PT307", "PT308" } }
        };

        public Action<int, string> AddLog;
        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private int Mindex { get; set; }
        private string SensorName { get; set; }
        private string Area { get; set; }
        private FormMain formMain { get; set; }
        public bool FirstOpen { get; set; } = false;

        #endregion

        public LockNew(string area, TCPManager tcp, byte index, int modeIndex, string name, FormMain mainForm, string titleName = null)
        {
            InitializeComponent();
            this.Tcp = tcp;
            this.Index = index;
            this.Mindex = modeIndex;
            this.SensorName = name;
            this.Area = area;
            this.formMain = mainForm;

            this.lb_Title.Text = titleName ?? $"{this.SensorName}联锁";

            this.Load += LockSetting_Load;
            this.FormClosed += LockNew_FormClosed;
        }

        private void LockSetting_Load(object sender, EventArgs e)
        {
            cb_ModeValue.Items.Clear();

            if (Mindex == 0)
            {
                btn_ModeSet.Enabled = false;
                this.cb_ModeValue.Items.Add("无可设定模式");
                this.cb_ModeValue.SelectedIndex = 0;
            }
            else if (ModeMap.TryGetValue(Mindex, out string[] modes))
            {
                this.cb_ModeValue.Items.AddRange(modes);
            }

            switch (Area)
            {
                case "助燃II":
                    this.formMain.FiringIIDataUpdated += FormMain_DataUpdated;
                    break;
                case "助燃I":
                    this.formMain.FiringIDataUpdated += FormMain_DataUpdated;
                    break;
                case "中燃":
                    this.formMain.FuelDataUpdated += FormMain_DataUpdated;
                    break;
            }
        }

        private void FormMain_DataUpdated(UDPValues e)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            if (!FirstOpen)
            {
                formMain.InvokeIfRequired(() =>
                {
                    if (this.IsDisposed) return; 

                    int highIndex = Index * 4 + 2;
                    int modeIndex = Index * 4;

                    if (e.Lock_Value != null && e.Lock_Value.Length > highIndex)
                    {
                        this.tb_HighValue.Text = (Convert.ToSingle(e.Lock_Value[highIndex]) / 100).ToString();

                        int selectIndex = Convert.ToInt32(e.Lock_Value[modeIndex]);

                        if (selectIndex >= 0 && selectIndex < cb_ModeValue.Items.Count)
                        {
                            this.cb_ModeValue.SelectedIndex = selectIndex;
                        }
                    }
                });
                FirstOpen = true; 
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
            this.Close();
        }

        private void LockNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch (Area)
            {
                case "助燃II":
                    this.formMain.FiringIIDataUpdated -= FormMain_DataUpdated;
                    break;
                case "助燃I":
                    this.formMain.FiringIDataUpdated -= FormMain_DataUpdated;
                    break;
                case "中燃":
                    this.formMain.FuelDataUpdated -= FormMain_DataUpdated;
                    break;
            }
            Tcp = null;
            SensorName = null;
        }

        #region 参数下发逻辑

        private void btn_ModeSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{SensorName}模式设定失败");
                return;
            }

            if (cb_ModeValue.SelectedIndex == -1 || cb_ModeValue.SelectedItem == null)
            {
                AddLog(1, $"{SensorName}未选择模式");
                return;
            }

            OperateResult result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: cb_ModeValue.SelectedIndex);

            if (result.IsSuccess)
            {
                AddLog(0, $"{SensorName}模式设定为{cb_ModeValue.SelectedItem}成功");
            }
            else
            {
                AddLog(1, $"{SensorName}模式设定为{cb_ModeValue.SelectedItem}失败");
            }
        }

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{SensorName}高限设定失败");
                return;
            }

            if (!float.TryParse(tb_HighValue.Text, out _))
            {
                AddLog(1, $"{SensorName}高限格式输入错误");
                return;
            }

            OperateResult result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.HighLimit,
                lockParamValue: tb_HighValue.Text);

            if (result.IsSuccess)
            {
                AddLog(0, $"{SensorName}高限设定{tb_HighValue.Text}成功");
            }
            else
            {
                AddLog(1, $"{SensorName}高限设定{tb_HighValue.Text}失败");
            }
        }

        #endregion
    }
}