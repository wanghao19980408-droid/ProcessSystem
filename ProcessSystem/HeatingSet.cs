using NodeSettings;
using Sunny.UI;
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
    public partial class HeatingSet : Form
    {
        public Action<int, String> Addlog;
        SiemensDevice NewDevice = null;

        public HeatingSet(SiemensDevice device)
        {
            InitializeComponent();
            this.NewDevice = device;
            this.Load += HeatSetting_Load;
        }

        private void HeatSetting_Load(object sender, EventArgs e)
        {
            if (NewDevice != null && NewDevice.IsConnected)
            {
                this.txt_WaterTHigh.Text = NewDevice["水温高设定"]?.ToString();
                this.txt_WaterTHighHigh.Text = NewDevice["水温高高设定"]?.ToString();
                this.txt_LiquidLowLow.Text = NewDevice["液位低低设定"]?.ToString();
                this.txt_LiquidLow.Text = NewDevice["液位低设定"]?.ToString();
                this.txt_Exit_T.Text = NewDevice["加热器出口温度目标值"]?.ToString();
            }
        }
        #region 无边框拖动

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.NewDevice = null;
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
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-加热器2#启动失败");
                return;
            }
            DialogResult dr = MessageBox.Show($"请确认是否启动加热器？", "参数修改确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                result = NewDevice.Write("加热器启停开关", "1").IsSuccess;
                if (result)
                {
                    Addlog(0, $"水浴加热器-加热器2#启动成功");
                }
                else
                {
                    Addlog(1, $"水浴加热器-加热器2#启动失败");
                }
            }
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-加热器2#停止失败");
                return;
            }

            result = NewDevice.Write("加热器启停开关", "0").IsSuccess;
            if (result)
            {
                Addlog(0, $"水浴加热器-加热器2#停止成功");
            }
            else
            {
                Addlog(1, $"水浴加热器-加热器2#停止失败");
            }
        }

        private void btn_point_WaterTHigh_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-水温高报警修改失败");
                return;
            }
            if (float.TryParse(this.txt_WaterTHigh.Text, out float WaterTHigh))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将水温高报警修改为 {WaterTHigh}？", "报警设定确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("水温高设定", WaterTHigh.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"水浴加热器-水温高报警修改为 {WaterTHigh} 成功");
                    }
                    else
                    {
                        Addlog(1, $"水浴加热器-水温高报警修改为 {WaterTHigh} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_WaterTHighHigh_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,浴加热器-水温高高报警设定失败");
                return;
            }
            if (float.TryParse(this.txt_WaterTHighHigh.Text, out float WaterTHighHigh))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将水温高高报警设定为 {WaterTHighHigh}？", "报警设定确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("水温高高设定", WaterTHighHigh.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"水浴加热器-水温高高报警设定为 {WaterTHighHigh} 成功");
                    }
                    else
                    {
                        Addlog(1, $"水浴加热器-水温高高报警设定为 {WaterTHighHigh} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_LiquidLow_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-液位低报警设定失败");
                return;
            }
            if (float.TryParse(this.txt_LiquidLow.Text, out float LiquidLow))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液位低报警设定为 {LiquidLow}？", "报警设定确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("液位低设定", LiquidLow.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"水浴加热器-液位低报警设定为 {LiquidLow} 成功");
                    }
                    else
                    {
                        Addlog(1, $"水浴加热器-液位低报警设定为 {LiquidLow} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_LiquidLowLow_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-液位低低报警设定失败");
                return;
            }
            if (float.TryParse(this.txt_LiquidLowLow.Text, out float LiquidLowLow))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将液位低低报警设定为 {LiquidLowLow}？", "报警设定确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("液位低低设定", LiquidLowLow.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"水浴加热器-液位低低报警设定为 {LiquidLowLow} 成功");
                    }
                    else
                    {
                        Addlog(1, $"水浴加热器-液位低低报警设定为 {LiquidLowLow} 失败: {res.Message}");
                    }
                }
            }
        }

        private void btn_point_Exit_T_Click(object sender, EventArgs e)
        {
            if (!NewDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,水浴加热器-加热器出口温度目标值设定失败");
                return;
            }
            if (float.TryParse(this.txt_Exit_T.Text, out float Exit_T))
            {
                DialogResult dr = MessageBox.Show($"请确认是否将加热器出口温度目标值设定为 {Exit_T}？", "参数设定确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    var res = NewDevice.Write("加热器出口温度目标值", Exit_T.ToString());
                    if (res.IsSuccess)
                    {
                        Addlog(0, $"水浴加热器-加热器出口温度目标值设定为 {Exit_T} 成功");
                    }
                    else
                    {
                        Addlog(1, $"水浴加热器-加热器出口温度目标值设定为 {Exit_T} 失败: {res.Message}");
                    }
                }
            }
        }
    }
}
