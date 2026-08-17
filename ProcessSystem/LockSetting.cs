using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class LockSetting : Form
    {
        string[] mode1 = { "自动模式" };
        string[] mode2 = { "手动模式" };
        public Action<int, string> AddLog;

        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private int Mindex { get; set; }
        private string SensorName { get; set; }
        private string Area { get; set; }
        public FormMain formMain { get; set; }
        public bool FirstOpen { get; set; } = false;

        public LockSetting(string area, TCPManager tcp, byte index, int modeIndex, string name, FormMain formMain, string titleName = null)
        {
            InitializeComponent();
            this.Area = area;
            this.Tcp = tcp;
            this.Index = index;
            this.Mindex = modeIndex;
            this.SensorName = name;
            this.formMain = formMain;

            if (titleName != null)
            {
                this.lb_Title.Text = titleName;
            }
            else
            {
                this.lb_Title.Text = $"{this.SensorName}联锁";
            }

            this.Load += LockSetting_Load;
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

        private void LockSetting_Load(object sender, EventArgs e)
        {
            switch (Mindex)
            {
                case 0:
                    this.cb_ModeValue.Items.Add("无可设定模式");
                    this.cb_ModeValue.SelectedIndex = 0;
                    break;
                case 1:
                    this.cb_ModeValue.Items.AddRange(mode1);
                    break;
                case 2:
                    this.cb_ModeValue.Items.AddRange(mode2);
                    break;
                case 6:
                default:
                    break;
            }

            if (this.Area == "配气") 
            {
                this.cb_ModeValue.SelectedIndex = 0;
                if (SensorName.Substring(0, 3) == "CPb")
                {
                    this.pl_CPb.Visible = true;
                }
                else if (SensorName == "HPb2" || SensorName == "HPb3")
                {
                    this.pl_HPb23.Visible = true;
                }
                else if (SensorName == "GPb16")
                {
                    this.pl_GPb16.Visible = true;
                }
                else
                {
                    this.pl_Normal.Visible = true;
                }
            }

            switch (Area)
            {
                case "助燃II":
                    formMain.FiringIIDataUpdated += FormMain_DataUpdated;
                    break;
                case "助燃I":
                    formMain.FiringIDataUpdated += FormMain_DataUpdated;
                    break;
                case "中燃":
                    formMain.FuelDataUpdated += FormMain_DataUpdated;
                    break;
                case "气源":
                    formMain.GaseSourceDataUpdated += FormMain_DataUpdated;
                    break;
                case "配气":
                    formMain.GaseSensorDataUpdated += FormMain_DataUpdated;
                    break;
            }
        }

        private void FormMain_DataUpdated(UDPValues e)
        {
            if (!FirstOpen)
            {
                formMain.InvokeIfRequired(() =>
                {
                    int offset = Index * 4;

                    if (e.Lock_Value != null && e.Lock_Value.Length >= offset + 4)
                    {
                        if (Area != "配气")
                        {
                            int selectIndex = Convert.ToInt32(e.Lock_Value[offset]) - 1;
                            if (selectIndex >= 0 && selectIndex < this.cb_ModeValue.Items.Count)
                            {
                                this.cb_ModeValue.SelectedIndex = selectIndex;
                            }
                        }
                        this.tb_Value.Text = (Convert.ToSingle(e.Lock_Value[offset + 1]) / 100f).ToString("f2");
                        this.tb_HighValue.Text = (Convert.ToSingle(e.Lock_Value[offset + 2]) / 100f).ToString("f2");
                        this.tb_LowValue.Text = (Convert.ToSingle(e.Lock_Value[offset + 3]) / 100f).ToString("f2");
                    }
                });
            }
            FirstOpen = true;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            switch (Area)
            {
                case "助燃II":
                    formMain.FiringIIDataUpdated -= FormMain_DataUpdated;
                    break;
                case "助燃I":
                    formMain.FiringIDataUpdated -= FormMain_DataUpdated;
                    break;
                case "中燃":
                    formMain.FuelDataUpdated -= FormMain_DataUpdated;
                    break;
                case "气源":
                    formMain.GaseSourceDataUpdated -= FormMain_DataUpdated;
                    break;
            }

            Tcp = null;
            SensorName = null;
            this.Close();
        }

        #region 参数设定下发逻辑

        private void btn_ModeSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}模式设定失败");
                return;
            }
            var result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: cb_ModeValue.SelectedIndex);

            if (result.IsSuccess)
                AddLog(0, $"{this.SensorName}模式设定为{cb_ModeValue.SelectedItem}成功");
            else
                AddLog(1, $"{this.SensorName}模式设定为{cb_ModeValue.SelectedItem}失败");
        }

        private void btn_GaseModeSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}额定设定失败");
                return;
            }
            if (sender is Button btn)
            {
                int modeIndex = Convert.ToInt32(btn.Tag.ToString());
                var result = Tcp.Send_PLC_Command(
                    (byte)CMD.lock_command,
                    lockIndex: Index,
                    lockParamSeq: LockParamSeq.Mode,
                    lockParamValue: modeIndex);

                if (result.IsSuccess)
                    AddLog(0, $"{this.SensorName}{btn.Text}成功");
                else
                    AddLog(1, $"{this.SensorName}{btn.Text}失败");
            }
        }

        private void btn_ValueSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}数值设定失败");
                return;
            }
            var result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.SetValue,
                lockParamValue: tb_Value.Text);

            if (result.IsSuccess)
                AddLog(0, $"{this.SensorName}数值设定{tb_Value.Text}成功");
            else
                AddLog(1, $"{this.SensorName}数值设定{tb_Value.Text}失败");
        }

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}高限设定失败");
                return;
            }
            var result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.HighLimit,
                lockParamValue: tb_HighValue.Text);

            if (result.IsSuccess)
                AddLog(0, $"{this.SensorName}高限设定{tb_HighValue.Text}成功");
            else
                AddLog(1, $"{this.SensorName}高限设定{tb_HighValue.Text}失败");
        }

        private void btn_LowSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}低限设定失败");
                return;
            }
            var result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.LowLimit,
                lockParamValue: tb_LowValue.Text);

            if (result.IsSuccess)
                AddLog(0, $"{this.SensorName}低限设定{tb_LowValue.Text}成功");
            else
                AddLog(1, $"{this.SensorName}低限设定{tb_LowValue.Text}失败");
        }

        #endregion
    }
}