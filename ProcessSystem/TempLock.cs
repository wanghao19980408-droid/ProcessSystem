using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using System;
using System.Drawing;
using System.Windows.Forms;
using static ProcessSystemLib.TCPManager;

namespace ProcessSystem
{
    public partial class TempLock : Form
    {
        #region 字段属性
        public Action<int, string> AddLog;
        private TCPManager Tcp = null;
        private byte Index { get; set; }
        private string SensorName { get; set; }
        private FormMain formMain { get; set; }
        private string Area { get; set; }
        public bool FirstOpen { get; set; } = false;

        private readonly bool IsLowLimitMode;
        #endregion

        public TempLock(string area, TCPManager tcp, byte index, string name, FormMain mainForm)
        {
            InitializeComponent();
            this.Tcp = tcp;
            this.Index = index;
            this.Area = area;
            this.SensorName = name;
            this.formMain = mainForm;
            this.lb_Title.Text = $"{this.SensorName}联锁";

            this.IsLowLimitMode = (SensorName == "TT222" || SensorName == "TT215");

            this.Load += TempLock_Load;
            this.FormClosed += TempLock_FormClosed;
        }

        private void TempLock_Load(object sender, EventArgs e)
        {
            if (IsLowLimitMode)
            {
                this.label4.Text = "低限报警设定 ：";
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
                case "气源":
                    this.formMain.GaseSourceDataUpdated += FormMain_DataUpdated;
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

                    int dataIndex = IsLowLimitMode ? (Index * 4 + 3) : (Index * 4 + 2);

                    if (e.Lock_Value != null && e.Lock_Value.Length > dataIndex)
                    {
                        this.tb_HighValue.Text = (Convert.ToSingle(e.Lock_Value[dataIndex]) / 100).ToString();
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

        private void TempLock_FormClosed(object sender, FormClosedEventArgs e)
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
                case "气源":
                    this.formMain.GaseSourceDataUpdated -= FormMain_DataUpdated;
                    break;
            }
            SensorName = null;
            Tcp = null;
        }

        #region 参数下发逻辑


        private void btn_HighSet_Click(object sender, EventArgs e)
        {
            string limitName = IsLowLimitMode ? "低限" : "高限";
            LockParamSeq seq = IsLowLimitMode ? LockParamSeq.LowLimit : LockParamSeq.HighLimit;

            ApplyLimitSetting(tb_HighValue.Text, seq, limitName);
        }


        private void ApplyLimitSetting(string uiValue, LockParamSeq seq, string limitName)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"网络连接异常,传感器{SensorName}{limitName}设定{uiValue}失败");
                return;
            }

            if (!float.TryParse(uiValue, out _))
            {
                AddLog(1, $"传感器{SensorName}{limitName}格式输入错误");
                return;
            }

            OperateResult result = Tcp.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: Index,
                lockParamSeq: seq,
                lockParamValue: uiValue);

            if (result.IsSuccess)
            {
                AddLog(0, $"传感器{SensorName}{limitName}设定{uiValue}成功");
            }
            else
            {
                AddLog(1, $"传感器{SensorName}{limitName}设定{uiValue}失败");
            }
        }
        #endregion
    }
}