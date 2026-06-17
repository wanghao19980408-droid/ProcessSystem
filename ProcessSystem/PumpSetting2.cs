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
    public partial class PumpSetting2 : Form
    {
        public Action<int, String> Addlog;
        SiemensDevice NewDevice = null;
        private TCPManager TCP = null;

        public PumpSetting2(SiemensDevice device, TCPManager tcp)
        {
            InitializeComponent();
            this.NewDevice = device;
            this.TCP = tcp;
            this.Load += PumpSetting2_Load;
            
        }

        private void PumpSetting2_Load(object sender, EventArgs e)
        {
            if (this.NewDevice.IsConnected)
            {
                this.PumpState.ValueChanged -= PumpState_ValueChanged;
                this.PumpState.Active = Convert.ToBoolean(NewDevice["远程本地选择"]);
                this.PumpState.ValueChanged += PumpState_ValueChanged;
                this.txt_electricity_HZ.Text = NewDevice["泵2频率远程给定"]?.ToString();
                this.txt_outAir_P.Text = NewDevice["泵2出气压力远程给定"]?.ToString();
                this.txt_outAir_T.Text = NewDevice["泵2出气温度远程给定"]?.ToString();
                this.txt_returnAir_T.Text = NewDevice["泵2回气温度远程给定"]?.ToString();
                this.btn_One.Text = NewDevice["Pump2Tank1Start"]?.ToString() == "1" ? "1#液氮泵退出" : "1#液氮泵投入";
                this.btn_Two.Text = NewDevice["Pump2Tank2Start"]?.ToString() == "1" ? "2#液氮泵退出" : "2#液氮泵投入";

                if (!PumpState.Active)
                {
                    foreach (Button control in this.Controls.OfType<Button>())
                    {
                        control.Enabled = false;
                    }
                }
                else
                {
                    foreach (Button control in this.Controls.OfType<Button>())
                    {
                        control.Enabled = true;
                    }
                }
            }
        }
        #region 无边框拖动

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.NewDevice = null;
            this.TCP = null;
            this.Close();
        }
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
        private void btn_point_returnAir_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, $"PLC连接异常,液氮泵2#回气温度修改失败");
                return;
            }
            if (float.TryParse(this.txt_returnAir_T.Text, out float returnAir_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#回气温度修改为 {returnAir_T}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("泵2回气温度远程给定", returnAir_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"液氮泵2#回气温度修改为 {returnAir_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"液氮泵2#回气温度修改为 {returnAir_T} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_outAir_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, $"PLC连接异常,液氮泵2#出气温度修改失败");
                return;
            }
            if (float.TryParse(this.txt_outAir_T.Text, out float returnAir_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#出气温度修改为 {returnAir_T}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("泵2出气温度远程给定", returnAir_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"液氮泵2#出气温度修改为 {returnAir_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"液氮泵2#出气温度修改为 {returnAir_T} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_outAir_P_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,液氮泵2#出气压力修改失败");
                return;
            }
            if (float.TryParse(this.txt_outAir_P.Text, out float outAir_P))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#出气压力修改为 {outAir_P}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("泵2出气压力远程给定", outAir_P.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"液氮泵2#出气压力修改为 {outAir_P} 成功");
                    }
                    else
                    {
                        Addlog(1, $"液氮泵2#出气压力修改为 {outAir_P} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_electricity_HZ_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,液氮泵2#电机频率修改失败");
                return;
            }
            if (float.TryParse(this.txt_electricity_HZ.Text, out float electricity_HZ))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#电机频率修改为 {electricity_HZ}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("泵2频率远程给定", electricity_HZ.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"液氮泵2#电机频率修改为 {electricity_HZ} 成功");
                    }
                    else
                    {
                        Addlog(1, $"液氮泵2#电机频率修改为 {electricity_HZ} 失败: {res.Message}");
                    }
                }
            }
        }
        bool result;
        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮泵2#启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#启动？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("泵2远程启动", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("泵2远程启动", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"液氮泵2#启动成功");
                }
                else
                {
                    Addlog(1, $"液氮泵2#启动失败");
                }
            }
        }

        private async void btn_end_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,请检查液氮泵2#停止失败");
                return;
            }
            result = NewDevice.Write("泵2远程停止", "1").IsSuccess;
            await Task.Delay(50);
            result &= NewDevice.Write("泵2远程停止", "0").IsSuccess;
            if (result)
            {
                Addlog(0, "液氮泵2#停止成功");
            }
            else
            {
                Addlog(1, "液氮泵2#停止失败");
            }
        }

        private void PumpState_ValueChanged(object sender, bool value)
        {
            if (!SendState(value))
            {
                return;
            }
            if (!value)
            {
                
                foreach (Button control in this.Controls.OfType<Button>())
                {
                    control.Enabled = false;
                }
            }
            else
            {
                foreach (Button control in this.Controls.OfType<Button>())
                {
                    control.Enabled = true;
                }
            }
        }
        private bool SendState(bool value)
        {
            string state;
            if (!NewDevice.IsConnected)
            {
                this.PumpState.ValueChanged -= PumpState_ValueChanged;
                PumpState.Active = !value;
                this.PumpState.ValueChanged += PumpState_ValueChanged;
                Addlog(2, "PLC连接异常,液氮泵2#状态切换失败");
                return false;
            }
            if (value)
            {
                state = "远程";
            }
            else
            {
                state = "本地";
            }
            DialogResult dr = MessageBox.Show($"请确认是否将液氮泵2#切换到{state}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (value)
                {
                    result = NewDevice.Write("远程本地选择", "1").IsSuccess;
                }
                else
                {
                    result = NewDevice.Write("远程本地选择", "0").IsSuccess;
                }
                if (result)
                {
                    Addlog(0, $"液氮泵2#状态切换成功");
                    return true;
                }
                else
                {
                    Addlog(1, $"液氮泵2#状态切换失败");
                    this.PumpState.ValueChanged -= PumpState_ValueChanged;
                    PumpState.Active = !value;
                    this.PumpState.ValueChanged += PumpState_ValueChanged;
                    return false;
                }
            }
            else
            {
                this.PumpState.ValueChanged -= PumpState_ValueChanged;
                PumpState.Active = !value;
                this.PumpState.ValueChanged += PumpState_ValueChanged;
                return false;
            }
        }
        OperateResult LockControlResult;
        private void ControlTank_Click(object sender, EventArgs e)
        {
            if (TCP == null && !TCP.IsConnected)
            {
                Addlog(2, "TCP连接异常");
                return;
            }
            if (sender is Button btn)
            {
                string state = btn.Text.Substring(5, 2);
                byte index = Convert.ToByte(btn.Tag.ToString(), 10);
                int modeIndex = state == "投入" ? 1 : 0;
                LockControlResult = TCP.Send_PLC_Command(
                (byte)CMD.lock_command,
                lockIndex: index,
                lockParamSeq: LockParamSeq.Mode,
                lockParamValue: modeIndex);
                if (LockControlResult.IsSuccess)
                {
                    Addlog(0, $"{btn.Text}成功");
                    string action = modeIndex == 1 ? "退出" : "投入";
                    btn.Text = btn.Text.Remove(5, 2) + action;
                }
                else
                {
                    Addlog(1, $"{btn.Text}失败");
                }
            }
        }
    }
}
