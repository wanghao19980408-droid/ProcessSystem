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

namespace ProcessSystem
{
    public partial class Nitrogen_Heat : Form
    {
        public Action<int, string> Addlog;
        SiemensDevice NewDevice = null;
        public Nitrogen_Heat(SiemensDevice device)
        {
            InitializeComponent();
            this.NewDevice = device;
            this.Load += Nitrogen_Heat_Load;
            if (NewDevice != null && NewDevice.IsConnected)
            {
                this.txt_ReturnDiff.Text = NewDevice["回差值设定"]?.ToString();
                this.txt_Goal_T.Text = NewDevice["目标温度设定"]?.ToString();
                this.txt_outAlarm_T.Text = NewDevice["出口温度设定值"]?.ToString();
                this.txt_CoreAlarm_T.Text = NewDevice["核心温度上限值"]?.ToString();
            }
        }

        private void Nitrogen_Heat_Load(object sender, EventArgs e)
        {
            this.PumpState.ValueChanged -= PumpState_ValueChanged;
            this.PumpState.Active = Convert.ToBoolean(NewDevice["远程本地"]);
            this.PumpState.ValueChanged += PumpState_ValueChanged;

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
        #region 无边框拖动

        private void btn_Exit_Click(object sender, EventArgs e)
        {
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
        bool result;
        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-1#加热器启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否将1#加热器启动？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("1#加热器启动", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("1#加热器启动", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"氮气加热控制-1#加热器启动成功");
                }
                else
                {
                    Addlog(1, $"氮气加热控制-1#加热器启动失败");
                }
            }
        }

        private async void btn_end_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-1#加热器停止失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否将1#加热器停止？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("1#加热器停止", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("1#加热器停止", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"氮气加热控制-1#加热器停止成功");
                }
                else
                {
                    Addlog(1, $"氮气加热控制-1#加热器停止失败");
                }
            }
        }
        private async void btn_start2_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-2#加热器启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否将2#加热器启动？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("2#加热器启动", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("2#加热器启动", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"氮气加热控制-2#加热器启动成功");
                }
                else
                {
                    Addlog(1, $"氮气加热控制-2#加热器启动失败");
                }
            }
        }

        private async void btn_end2_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,气加热控制-2#加热器停止失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否将2#加热器停止？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("2#加热器停止", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("2#加热器停止", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"氮气加热控制-2#加热器停止成功");
                }
                else
                {
                    Addlog(1, $"氮气加热控制-2#加热器停止失败");
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.NewDevice = null;
            this.Close();
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
                Addlog(2, "PLC连接异常,氮气加热状态切换失败");
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
            DialogResult dr = MessageBox.Show($"请确认是否将氮气加热切换到{state}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (value)
                {
                    result = NewDevice.Write("远程本地", "1").IsSuccess;
                }
                else
                {
                    result = NewDevice.Write("远程本地", "0").IsSuccess;
                }
                if (result)
                {
                    Addlog(0, $"氮气加热状态切换成功");
                    return true;
                }
                else
                {
                    this.PumpState.ValueChanged -= PumpState_ValueChanged;
                    PumpState.Active = !value;
                    this.PumpState.ValueChanged += PumpState_ValueChanged;
                    Addlog(1, $"氮气加热状态切换失败");
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

        private void btn_point_Goal_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-目标温度设定失败");
                return;
            }
            if (float.TryParse(this.txt_Goal_T.Text, out float Goal_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将目标温度设定为 {Goal_T}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("目标温度设定", Goal_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"氮气加热控制-目标温度设定为 {Goal_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"氮气加热控制-目标温度设定为 {Goal_T} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_ReturnDiff_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,气加热控制-回差值设定失败");
                return;
            }
            if (float.TryParse(this.txt_ReturnDiff.Text, out float ReturnDiff))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将回差值设定为 {ReturnDiff}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("回差值设定", ReturnDiff.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"氮气加热控制-回差值设定为 {ReturnDiff} 成功");
                    }
                    else
                    {
                        Addlog(1, $"氮气加热控制-回差值设定为 {ReturnDiff} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_outAlarm_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-出口温度上限值设定失败");
                return;
            }
            if (float.TryParse(this.txt_outAlarm_T.Text, out float outAlarm_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将出口温度上限值设定为 {outAlarm_T}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("出口温度设定值", outAlarm_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"氮气加热控制-出口温度上限值设定为 {outAlarm_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"氮气加热控制-出口温度上限值设定为 {outAlarm_T} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_CoreAlarm_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,氮气加热控制-核心温度上限值设定失败");
                return;
            }
            if (float.TryParse(this.txt_CoreAlarm_T.Text, out float CoreAlarm_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将核心温度上限值设定为 {CoreAlarm_T}？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("核心温度上限值", CoreAlarm_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"氮气加热控制-核心温度上限值设定为 {CoreAlarm_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"氮气加热控制-核心温度上限值设定为 {CoreAlarm_T} 失败: {res.Message}");
                    }
                }
            }
        }
    }
}
