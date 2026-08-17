using DataConvertLib;
using ProcessSystemLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class LiquidLock : Form
    {
        #region 字段属性
        public Action<int, string> AddLog;
        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private string SensorName { get; set; }
        private string Area { get; set; }
        private FormMain formMain { get; set; }
        public bool FirstOpen { get; set; } = false;
        #endregion

        public LiquidLock(string area, TCPManager tcp, byte index, string name, FormMain formMain)
        {
            InitializeComponent();
            this.Tcp = tcp;
            this.Index = index;
            this.SensorName = name;
            this.Area = area;
            this.formMain = formMain;

            this.Load += LiquidLock_Load;
            this.FormClosed += LiquidLock_FormClosed;
        }

        private void LiquidLock_Load(object sender, EventArgs e)
        {
            this.lb_Title.Text = $"{this.SensorName}联锁";

            this.pl_Low.Visible = (SensorName == "LT206");

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
                    int lowIndex = Index * 4;

                    if (e.Lock_Value != null && e.Lock_Value.Length > highIndex)
                    {
                        this.tb_HighValue.Text = (Convert.ToSingle(e.Lock_Value[highIndex]) / 100).ToString();

                        if (SensorName == "LT206" && e.Lock_Value.Length > lowIndex)
                        {
                            this.tb_LowValue.Text = e.Lock_Value[lowIndex].ToString();
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

        private void LiquidLock_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            ApplyLimitSetting(tb_HighValue.Text, LockParamSeq.HighLimit, "高限");
        }

        private void btn_LowSet_Click(object sender, EventArgs e)
        {
            ApplyLimitSetting(tb_LowValue.Text, LockParamSeq.LowLimit, "低限");
        }


        private void ApplyLimitSetting(string uiValue, LockParamSeq seq, string limitName)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{this.SensorName}{limitName}设定失败");
                return;
            }

            if (!float.TryParse(uiValue, out _))
            {
                AddLog(1, $"{this.SensorName}{limitName}格式输入错误");
                return;
            }

            OperateResult result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: seq,
                lockParamValue: uiValue);

            if (result.IsSuccess)
            {
                AddLog(0, $"{this.SensorName}{limitName}设定{uiValue}成功");
            }
            else
            {
                AddLog(1, $"{this.SensorName}{limitName}设定{uiValue}失败");
            }
        }
        #endregion
    }
}