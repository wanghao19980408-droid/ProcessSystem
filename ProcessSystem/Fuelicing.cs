using DataConvertLib;
using NodeSettings;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class Fuelicing : Form
    {
        public Action<int, string> Addlog;
        SiemensDevice NewDevice = null;
        public Fuelicing(SiemensDevice device)
        {
            InitializeComponent();
            this.NewDevice = device;

            this.Load += PumpSetting1_Load;
        }
        private void PumpSetting1_Load(object sender, EventArgs e)
        {
           this.timer1.Interval = 100;
            this.timer1.Tick += Timer1_Tick;
            this.timer1.Enabled = true;
            if (NewDevice.IsConnected)
            {
                this.tb_TEMP.Text = Convert.ToSingle(NewDevice["煤油温度设定"]).ToString("f2");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.lt_Ys1.State = Convert.ToBoolean(NewDevice["1#压缩机运行"]) ? UILightState.On : UILightState.Off;
            this.lt_Ys2.State = Convert.ToBoolean(NewDevice["2#压缩机运行"]) ? UILightState.On : UILightState.Off;
            this.lt_Jr1.State = Convert.ToBoolean(NewDevice["1#加热器运行"]) ? UILightState.On : UILightState.Off;
            this.lt_Jr2.State = Convert.ToBoolean(NewDevice["2#加热器运行"]) ? UILightState.On : UILightState.Off;
            this.lt_Gy.State = Convert.ToBoolean(NewDevice["硅油循环泵运行"]) ? UILightState.On : UILightState.Off;
            this.lt_Tj1.State = Convert.ToBoolean(NewDevice["报警停机1"]) ? UILightState.On : UILightState.Off;
            this.lt_Tj2.State = Convert.ToBoolean(NewDevice["报警停机2"]) ? UILightState.On : UILightState.Off;
            this.lt_Btj.State = Convert.ToBoolean(NewDevice["报警不停机"]) ? UILightState.On : UILightState.Off;
            this.PumpState.Active = Convert.ToBoolean(NewDevice["jjw远程信号"]) ? true : false;
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
                Addlog(2, "PLC连接异常,煤油加降温启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否启动煤油加降温？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("jjw远程启动", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("jjw远程启动", "0").IsSuccess;
                if (result)
                {
                    Addlog(0, $"煤油加降温启动成功");
                }
                else
                {
                    Addlog(1, $"煤油加降温启动失败");
                }
            }
        }
        private async void btn_end_Click(object sender, EventArgs e)
        {
            if(!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,煤油加降温停止失败");
                return;
            }
            result = NewDevice.Write("jjw远程停止", "1").IsSuccess;
            await Task.Delay(50);
            result &= NewDevice.Write("jjw远程停止", "0").IsSuccess;
            if (result)
            {
                Addlog(0, $"煤油加降温停止成功");
            }
            else
            {
                Addlog(1, $"煤油加降温停止失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewDevice = null;
            this.timer1.Enabled = false;
            this.Close();
        }


        private async void ControlTemp_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,煤油控温模式启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否启动煤油控温模式？", "模式确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("煤油控温模式", "1").IsSuccess;
                await Task.Delay(50);
                result &= NewDevice.Write("煤油控温模式", "0").IsSuccess;
                if (result)
                {
                    this.btn_One.BackColor = Color.Green;
                    Addlog(0, $"煤油控温模式启动成功");
                }
                else
                {
                    this.btn_One.BackColor = Color.White;
                    Addlog(1, $"煤油控温模式启动失败");
                }
            }
        }

        private void btn_St_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,煤油温度设定失败");
                return;
            }
            if (float.TryParse(this.tb_TEMP.Text, out float TEMP))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将煤油温度设定为 {TEMP}℃？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("煤油温度设定", TEMP.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"煤油温度设定为 {TEMP}℃ 成功");
                    }
                    else
                    {
                        Addlog(1, $"煤油温度设定为 {TEMP}℃ 失败: {res.Message}");
                    }
                }
            }
        }
    }
}
