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

namespace ProcessSystem
{
    public partial class TempLock : Form
    {

        public Action<int, string> AddLog;

        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private string SensorName { get; set; }
        private SiemensDevice siemensDevice { get; set; }
        public TempLock(TCPManager tcp, byte index, string name, SiemensDevice device)
        {
            InitializeComponent();
            this.Tcp = tcp;
            this.Index = index;
            this.SensorName = name;
            this.lb_Title.Text = $"{this.SensorName}联锁";
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

            if (SensorName == "TT222" || SensorName == "TT215")
            {
                this.label4.Text = "低限报警设定 ：";
                this.btn_HighSet.Click += btn_LowSet_Click;
                if (siemensDevice.IsConnected)
                {
                    this.tb_HighValue.Text = siemensDevice?[$"{SensorName}Low"].ToString();
                }
            }
            else
            {
                this.btn_HighSet.Click += btn_HighSet_Click;
                if (siemensDevice.IsConnected)
                {
                    this.tb_HighValue.Text = siemensDevice?[$"{SensorName}High"].ToString();
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            SensorName = null;
            siemensDevice = null;
            Tcp = null;
            this.Close();
        }

        private OperateResult LockControlResult;

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"网络连接异常,传感器{SensorName}高限设定{tb_HighValue.Text}失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.HighLimit,
                lockParamValue: tb_HighValue.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"传感器{SensorName}高限设定{tb_HighValue.Text}成功");
            }
            else
            {
                AddLog(1, $"传感器{SensorName}高限设定{tb_HighValue.Text}失败");
            }
            LockControlResult = null;
        }

        private void btn_LowSet_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,传感器{SensorName}低限设定失败");
                return;
            }
            LockControlResult = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: LockParamSeq.LowLimit,
                lockParamValue: tb_HighValue.Text);
            if (LockControlResult.IsSuccess)
            {
                AddLog(0, $"传感器{SensorName}低限设定{tb_HighValue.Text}成功");
            }
            else
            {
                AddLog(1, $"传感器{SensorName}低限设定{tb_HighValue.Text}失败");
            }
            LockControlResult = null;
        }
    }
}
