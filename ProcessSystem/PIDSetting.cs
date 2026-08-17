using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class PIDSetting : Form
    {
        #region 字段
        public Action<int, string> AddLog;
        private TCPManager Tcp;
        private readonly byte Index;
        private readonly string TitleName;
        private string Area;
        public FormMain formMain { get; set; }
        public bool FirstOpen { get; set; } = false;

        private static readonly Dictionary<string, (string[] sensors, byte tag)> sensorMap =
            new Dictionary<string, (string[] sensors, byte tag)>()
            {
                ["PCV401"] = (new[] { "PT401", "PT401a", "PT401b" }, 12),
                ["PV202"] = (new[] { "PT214", "PT215", "PT216" }, 5),
                ["PV201"] = (new[] { "PT218", "PT219", "PT220" }, 3),
            };
        #endregion

        public PIDSetting(string area, TCPManager tcp, byte index, string valveName, FormMain formMain)
        {
            InitializeComponent();
            Tcp = tcp;
            Index = index;
            TitleName = valveName;
            this.Area = area;
            this.formMain = formMain;

            Load += PIDSetting_Load;

            FormClosed += PIDSetting_FormClosed;
        }

        private void SelectSensor(string name)
        {
            if (!sensorMap.TryGetValue(name, out var cfg))
            {
                pl_Sensor.Visible = false;
                return;
            }
            pl_Sensor.Visible = true;

            cb_SelectSensor.Items.Clear();
            cb_SelectSensor.Items.AddRange(cfg.sensors);
            cb_SelectSensor.Tag = cfg.tag;

            if (cb_SelectSensor.Items.Count > 0 && cb_SelectSensor.SelectedIndex == -1)
            {
                cb_SelectSensor.SelectedIndex = 0;
            }
        }

        private void PIDSetting_Load(object sender, EventArgs e)
        {
            ValveName.Text = TitleName;
            SelectSensor(TitleName);

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

        private OperateResult ApplySensorSetting()
        {
            if (cb_SelectSensor.SelectedIndex == -1)
            {
                AddLog(1, $"{TitleName}未选择传感器");
                return OperateResult.CreateFailResult();
            }

            byte index = Convert.ToByte(cb_SelectSensor.Tag);
            if (!Tcp.Send_PLC_Command(
                    (byte)CMD.lock_command,
                    lockIndex: index,
                    lockParamSeq: LockParamSeq.Mode,
                    lockParamValue: cb_SelectSensor.SelectedIndex).IsSuccess)
            {
                AddLog(1, $"{TitleName}模式设定失败");
                return OperateResult.CreateFailResult();
            }

            AddLog(0, $"{TitleName}模式设定成功");
            return OperateResult.CreateSuccessResult();
        }

        private void FormMain_DataUpdated(UDPValues e)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            if (!FirstOpen)
            {
                formMain.InvokeIfRequired(() =>
                {
                    if (this.IsDisposed) return;

                    int offset = Index * 6;
                    int lockOffset = Convert.ToByte(cb_SelectSensor.Tag) * 4;

                    tb_PressureSet.Text = (Convert.ToSingle(e.PID_Value[offset + 1]) / 100).ToString("f3");
                    Kp.Text = (Convert.ToSingle(e.PID_Value[offset + 2]) / 100).ToString();
                    Ki.Text = (Convert.ToSingle(e.PID_Value[offset + 3]) / 100).ToString();
                    Kd.Text = (Convert.ToSingle(e.PID_Value[offset + 4]) / 100).ToString();

                    if (TitleName == "PCV401" || TitleName == "PV202" || TitleName == "PV201")
                    {
                        if (e.Lock_Value[lockOffset] >= 0 && e.Lock_Value[lockOffset] < cb_SelectSensor.Items.Count)
                        {
                            this.cb_SelectSensor.SelectedIndex = e.Lock_Value[lockOffset];
                        }
                    }

                    PIDAuto.ValueChanged -= PIDAuto_ValueChanged;
                    PIDAuto.Active = Convert.ToBoolean(e.PID_Value[offset]);
                    PIDAuto.ValueChanged += PIDAuto_ValueChanged;
                });
            }
            FirstOpen = true;
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
                Location = new Point(
                    Location.X + e.X - mPoint.X,
                    Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PIDSetting_FormClosed(object sender, FormClosedEventArgs e)
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
                case "配气":
                    formMain.GaseSensorDataUpdated -= FormMain_DataUpdated;
                    break;
            }
            Tcp = null;
        }

        #region 参数下发逻辑
        private void PIDAuto_ValueChanged(object sender, bool value)
        {
            if (!SetAuto(value).IsSuccess)
            {
                PIDAuto.ValueChanged -= PIDAuto_ValueChanged;
                PIDAuto.Active = !value;
                PIDAuto.ValueChanged += PIDAuto_ValueChanged;
            }
        }

        private OperateResult SetAuto(bool value)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{TitleName}手自动切换失败");
                return OperateResult.CreateFailResult();
            }

            string action = value ? "开启" : "关闭";
            if (!Tcp.Send_PLC_Command(
                    (byte)CMD.pid_command,
                    pidIndex: Index,
                    pidParamSeq: PIDParamSeq.Auto,
                    pidParamValue: value).IsSuccess)
            {
                AddLog(1, $"{TitleName}自动模式{action}失败");
                return OperateResult.CreateFailResult();
            }

            AddLog(0, $"{TitleName}自动模式{action}成功");
            return OperateResult.CreateSuccessResult();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{TitleName}PID设置失败");
                return;
            }

            bool allSuccess = true;
            allSuccess &= ApplyPidValue(tb_PressureSet.Text, PIDParamSeq.SetPoint, $"压力设定 {tb_PressureSet.Text}Mpa");
            allSuccess &= ApplyPidValue(Kp.Text, PIDParamSeq.KP, "P值");
            allSuccess &= ApplyPidValue(Ki.Text, PIDParamSeq.KI, "I值");
            allSuccess &= ApplyPidValue(Kd.Text, PIDParamSeq.KD, "D值");

            if (TitleName == "PCV401" || TitleName == "PV202" || TitleName == "PV201")
            {
                allSuccess &= ApplySensorSetting().IsSuccess;
            }

            if (allSuccess)
                AddLog(0, $"{TitleName}PID参数全部设定完成");
            else
                AddLog(1, $"{TitleName}PID参数部分或全部设定失败");
        }

        private bool ApplyPidValue(string uiValue, PIDParamSeq seq, string logName)
        {
            if (!float.TryParse(uiValue, out _))
            {
                AddLog(1, $"{TitleName} {logName} 格式输入错误");
                return false;
            }

            if (!Tcp.Send_PLC_Command(
                    (byte)CMD.pid_command,
                    pidIndex: Index,
                    pidParamSeq: seq,
                    pidParamValue: uiValue).IsSuccess)
            {
                AddLog(1, $"{TitleName} {logName}设定失败");
                return false;
            }

            AddLog(0, $"{TitleName} {logName}设定成功");
            return true;
        }
        #endregion
    }
}