using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessControlLib;

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

        private SiemensDevice siemensDevice { get; set; }
        public LockSetting(TCPManager tcp, byte index, int modeIndex, string name, SiemensDevice device, string titleName = null)
        {
            InitializeComponent();
            this.Tcp = tcp;
            this.Index = index;
            this.Mindex = modeIndex;
            this.SensorName = name;
            if (titleName != null)
            {
                this.lb_Title.Text = titleName;
            }
            else
            {
                this.lb_Title.Text = $"{this.SensorName}联锁";
            }
            this.siemensDevice = device;
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

            if (siemensDevice != null && siemensDevice.IsConnected)
            {
                if (siemensDevice.DeviceName == "配气区")
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
                else
                {
                    int selectIndex = Convert.ToInt32(siemensDevice?[$"{SensorName}Start"]) -1  ;
                    this.cb_ModeValue.SelectedIndex = selectIndex;
                }
                if (this.pl_mode.Visible)
                {

                }
                this.tb_LowValue.Text = siemensDevice?[$"{SensorName}Low"].ToString();
                this.tb_HighValue.Text = siemensDevice?[$"{SensorName}High"].ToString();
                this.tb_Value.Text = siemensDevice?[$"{SensorName}Point"].ToString();
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.siemensDevice = null;
            SensorName = null;
            this.Close();
        }

        private OperateResult LockControlResult;

        private void btn_ModeSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}模式设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: cb_ModeValue.SelectedIndex);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{this.SensorName}模式设定为{cb_ModeValue.SelectedItem.ToString()}成功");
            }
            else
            {
                AddLog(1, $"{this.SensorName}模式设定为{cb_ModeValue.SelectedItem.ToString()}失败");
            }
            LockControlResult = null;
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
                LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: modeIndex);
                if (LockControlResult.IsSuccess)
                {
                    AddLog(0, $"{this.SensorName}{btn.Text}成功");
                }
                else
                {
                    AddLog(1, $"{this.SensorName}{btn.Text}失败");
                }
            }

            LockControlResult = null;
        }
        private void btn_ValueSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}数值设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.SetValue,
                lockParamValue: tb_Value.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{this.SensorName}数值设定{tb_Value.Text}成功");
            }
            else
            {
                AddLog(1, $"{this.SensorName}数值设定{tb_Value.Text}失败");
            }
            LockControlResult = null;
        }

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}高限设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.HighLimit,
                lockParamValue: tb_HighValue.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{this.SensorName}高限设定{tb_HighValue.Text}成功");
            }
            else
            {
                AddLog(1, $"{this.SensorName}高限设定{tb_HighValue.Text}失败");
            }
            LockControlResult = null;
        }

        private void btn_LowSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}低限设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.LowLimit,
                lockParamValue: tb_LowValue.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{this.SensorName}低限设定{tb_LowValue.Text}成功");
            }
            else
            {
                AddLog(1, $"{this.SensorName}低限设定{tb_LowValue.Text}失败");
            }
            LockControlResult = null;
        }
    }
}
