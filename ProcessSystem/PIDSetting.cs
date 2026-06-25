using DataConvertLib;
using NodeSettings;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading.Tasks;
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
        private readonly PidDataService pidDataService = new PidDataService();
        private PID pidMode = new PID();
        private OperateResult<float> pidParseResult;

        #endregion

        public PIDSetting(TCPManager tcp, byte index, string valveName)
        {
            InitializeComponent();

            Tcp = tcp;
            Index = index;
            TitleName = valveName;
            pl_Sensor.Visible = true;
            Load += PIDSetting_Load;
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

        private async void PIDSetting_Load(object sender, EventArgs e)
        {
            ValveName.Text = TitleName;
            SelectSensor(TitleName);

            var result = await Task.Run(() => pidDataService.QueryPIDInfo(TitleName));
            if (!result.IsSuccess)
            {
                pidMode.ValveName = TitleName;
                pidMode.SensorSetting = -1;
                pidDataService.InsertPIDInfo(TitleName, pidMode);
                if (new FrmMsgNoAck("PID参数获取失败，请检查数据库连接！", "查询提醒")
                    .ShowDialog() == DialogResult.OK)
                {
                    Close();
                }
                return;
            }

            pidMode = result.Content;

            BindPidToUI(pidMode);
        }

        private void BindPidToUI(PID pid)
        {
            tb_PressureSet.Text = pid.SetPoint.ToString();
            Kp.Text = pid.Kp.ToString();
            Ki.Text = pid.Ki.ToString();
            Kd.Text = pid.Kd.ToString();

            PIDAuto.ValueChanged -= PIDAuto_ValueChanged;
            PIDAuto.Active = pid.IsAuto;
            PIDAuto.ValueChanged += PIDAuto_ValueChanged;

            if (pid.SensorSetting >= 0)
                cb_SelectSensor.SelectedIndex = pid.SensorSetting;
        }

        private readonly Dictionary<string, (string[] sensors, byte tag)> sensorMap =
            new Dictionary<string, (string[] sensors, byte tag)>()
            {
                ["PCV401"] = (new[] { "PT401", "PT401a", "PT401b" }, 12),
                ["PV202"] = (new[] { "PT214", "PT215", "PT216" }, 5),
                ["PV201"] = (new[] { "PT218", "PT219", "PT220" }, 3),
            };

        private void SelectSensor(string name)
        {
            if (!sensorMap.TryGetValue(name, out var cfg))
            {
                pl_Sensor.Visible = false;
                return;
            }
            cb_SelectSensor.Items.AddRange(cfg.sensors);
            cb_SelectSensor.Tag = cfg.tag;
        }



        private void btn_Close_Click(object sender, EventArgs e)
        {
            Tcp = null;
            pidMode = null;
            Close();
        }


        private void PIDAuto_ValueChanged(object sender, bool value)
        {
            if (!SettingPIDInfo().IsSuccess)
            {

                PIDAuto.ValueChanged -= PIDAuto_ValueChanged;
                PIDAuto.Active = !value;
                PIDAuto.ValueChanged += PIDAuto_ValueChanged;
                return;
            }

            if (SetAuto(value).IsSuccess)
            {
                pidDataService.UpdatePIDInfo(TitleName, pidMode);
            }
        }

        private OperateResult SetAuto(bool value)
        {
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
            pidMode.IsAuto = value;
            return OperateResult.CreateSuccessResult();
        }



        private OperateResult SettingPIDInfo()
        {
            if (Tcp == null || !Tcp.IsConnected)
            {
                AddLog(2, $"TCP连接异常,{TitleName}PID设置失败");
                return OperateResult.CreateFailResult();
            }

            if (!ApplyPidValue(tb_PressureSet.Text, pidMode.SetPoint,
                    PIDParamSeq.SetPoint,
                    v => pidMode.SetPoint = v,
                    $"压力设定{tb_PressureSet.Text}Mpa"))
                return OperateResult.CreateFailResult();

            if (!ApplyPidValue(Kp.Text, pidMode.Kp,
                    PIDParamSeq.KP,
                    v => pidMode.Kp = v,
                    "P值"))
                return OperateResult.CreateFailResult();

            if (!ApplyPidValue(Ki.Text, pidMode.Ki,
                    PIDParamSeq.KI,
                    v => pidMode.Ki = v,
                    "I值"))
                return OperateResult.CreateFailResult();

            if (!ApplyPidValue(Kd.Text, pidMode.Kd,
                    PIDParamSeq.KD,
                    v => pidMode.Kd = v,
                    "D值"))
                return OperateResult.CreateFailResult();

            return ApplySensorSetting();
        }


        private bool ApplyPidValue(
            string uiValue,
            float oldValue,
            PIDParamSeq seq,
            Action<float> onSuccess,
            string logName)
        {
            pidParseResult = TryParse(uiValue, oldValue);
            if (!pidParseResult.IsSuccess)
                return true;

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
            onSuccess(pidParseResult.Content);
            return true;
        }

        private OperateResult ApplySensorSetting()
        {
            if (pidMode.SensorSetting == cb_SelectSensor.SelectedIndex)
                return OperateResult.CreateSuccessResult();

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
            pidMode.SensorSetting = cb_SelectSensor.SelectedIndex;
            return OperateResult.CreateSuccessResult();
        }


        private bool HasPidValueChanged()
        {
            return TryParse(tb_PressureSet.Text, pidMode.SetPoint).IsSuccess
                || TryParse(Kp.Text, pidMode.Kp).IsSuccess
                || TryParse(Ki.Text, pidMode.Ki).IsSuccess
                || TryParse(Kd.Text, pidMode.Kd).IsSuccess
                || pidMode.SensorSetting != cb_SelectSensor.SelectedIndex;
        }
        private OperateResult<float> TryParse(string text, float oldValue)
        {
            if (float.TryParse(text, out float v) && Math.Abs(v - oldValue) > 0.0001f)
                return OperateResult.CreateSuccessResult(v);

            return OperateResult.CreateFailResult<float>("无变化");
        }


        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (!HasPidValueChanged())
            {
                AddLog(2, $"{TitleName}PID参数未发生变化");
                return;
            }

            if (!SettingPIDInfo().IsSuccess)
            {
                AddLog(1, $"{TitleName}PID参数设定失败");
                return;
            }

            pidDataService.UpdatePIDInfo(TitleName, pidMode);
            AddLog(0, $"{TitleName}PID参数设定成功");
        }
    }
}
