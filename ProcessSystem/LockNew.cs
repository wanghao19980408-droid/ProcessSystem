using DataConvertLib;
using NodeSettings;

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
using ProcessSystemLib;
namespace ProcessSystem
{
    public partial class LockNew : Form
    {
        string[] mode1 = { "无设定模式" };
        string[] mode6 = { "PT214", "PT215", "PT216" };
        string[] mode7 = { "PT218", "PT219", "PT220", "PT223" };
        string[] mode9 = { "PT401", "PT401a", "PT401b" };
        string[] mode10 = { "PT202", "PT203" };
        string[] mode11 = { "PT306", "PT307", "PT308" };
        string[] mode12 = { "PT401", "PT401a", "PT401b", "PT306", "PT307", "PT308" };

        public Action<int, string> AddLog;

        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private int Mindex { get; set; }
        private string SensorName { get; set; }
        private SiemensDevice siemensDevice { get; set; }
        public LockNew(TCPManager tcp, byte index, int modeIndex, string name, SiemensDevice device, string titleName = null)
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
                    btn_ModeSet.Enabled = false;
                    this.cb_ModeValue.Items.Add("无可设定模式");
                    this.cb_ModeValue.SelectedIndex = 0;
                    break;
                case 1:
                    this.cb_ModeValue.Items.AddRange(mode1);
                    break;
                case 6:
                    this.cb_ModeValue.Items.AddRange(mode6);
                    break;
                case 7:
                    this.cb_ModeValue.Items.AddRange(mode7);
                    break;
                case 9:
                    this.cb_ModeValue.Items.AddRange(mode9);
                    break;
                case 10:
                    this.cb_ModeValue.Items.AddRange(mode10);
                    break;
                case 11:
                    this.cb_ModeValue.Items.AddRange(mode11);
                    break;
                case 12:
                    this.cb_ModeValue.Items.AddRange(mode12);
                    break;
                default:
                    break;
            }
            if (siemensDevice.IsConnected)
            {
                this.tb_HighValue.Text = siemensDevice?[$"{SensorName}High"].ToString();
                int selectIndex = Convert.ToInt32(siemensDevice?[$"{SensorName}Start"]);
                this.cb_ModeValue.SelectedIndex = selectIndex;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            SensorName = null;
            Tcp = null;
            this.siemensDevice = null;
            this.Close();
        }

        private OperateResult LockControlResult;

        private void btn_ModeSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{SensorName}模式设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: cb_ModeValue.SelectedIndex);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{SensorName}模式设定为{cb_ModeValue.SelectedItem.ToString()}成功");
            }
            else
            {
                AddLog(1, $"{SensorName}模式设定为{cb_ModeValue.SelectedItem.ToString()}失败");
            }
            LockControlResult = null;
        }

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{SensorName}高限设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.HighLimit,
                lockParamValue: tb_HighValue.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"{SensorName}高限设定{tb_HighValue.Text}成功");
            }
            else
            {
                AddLog(1, $"{SensorName}高限设定{tb_HighValue.Text}失败");
            }
            LockControlResult = null;
        }
    }
}
