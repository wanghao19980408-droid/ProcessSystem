using DataConvertLib;
using Newtonsoft.Json.Linq;
using NodeSettings;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class PressureStation : Form
    {
        public Action<int, String> Addlog;
        SiemensDevice FuelDevice = null;
        SiemensDevice OneDevice = null;
        SiemensDevice Tw0Device = null;

        string[] Kerosene = { "PT401", "PT401a", "PT401b" };
        string[] Methane = { "PT306", "PT307", "PT308" };
        string[] Station1 = { "PT214", "PT215", "PT216" };
        string[] Station2 = { "PT218", "PT219", "PT220" };
        string[] Station = { "工位1", "工位2" };
        FormMain Control = null;

        public PressureStation( FormMain control)
        {
            InitializeComponent();
            this.FuelDevice = control.FuelDevice;
            this.OneDevice = control.Firing1Device;
            this.Tw0Device = control.Firing2Device;
            this.Control = control;
            this.Load += Pressurize_Load;
        }

        private void Pressurize_Load(object sender, EventArgs e)
        {
            this.CB_Station.Items.AddRange(Station);

            if (FuelDevice.IsConnected)
            {
                int fuelMediumIndex = Convert.ToInt32(this.FuelDevice?["FuelMedium"]) - 1;
                if (fuelMediumIndex >= 0 && fuelMediumIndex < CB_Fuel.Items.Count)
                {
                    this.CB_Fuel.SelectedIndex = fuelMediumIndex;
                }

                this.txt_Fuel_P.Text = this.FuelDevice?["Pressure"].ToString();

                int flowIndex = Convert.ToInt32(this.FuelDevice?["WorkState"]) - 1;
                if (flowIndex >= 0 && flowIndex < CB_FuelFlow.Items.Count)
                {
                    this.CB_FuelFlow.SelectedIndex = flowIndex;
                }

                int sensorIndex = Convert.ToInt32(this.FuelDevice?["Sensor"]) - 1;
                if (sensorIndex >= 0 && sensorIndex < CB_FuelSensor.Items.Count)
                {
                    CB_FuelSensor.SelectedIndex = sensorIndex;
                }
            }

            if (this.CB_Station.SelectedIndex == -1)
            {
                this.CB_Station.SelectedIndex = 0;
            }

            ApplyUserPermissions();
        }

        /// <summary>
        /// 根据登录用户的角色分配权限
        /// </summary>
        private void ApplyUserPermissions()
        {
            if (Control.UserInfo == null) return;

            string role = Control.UserInfo.RoleType;

            switch (role)
            {
                case "工位1": 
                    this.CB_Fuel.SelectedIndex = 1;
                    this.CB_Fuel.Enabled = false;
                    this.CB_Station.SelectedIndex = 0;
                    this.CB_Station.Enabled = false;
                    break;

                case "工位2": 
                    this.CB_Fuel.SelectedIndex = 0;
                    this.CB_Fuel.Enabled = false;

                    this.CB_Station.SelectedIndex = 1;
                    this.CB_Station.Enabled = false;
                    break;

                case "管理员": 
                default:
                    this.CB_Fuel.Enabled = true;
                    this.CB_Station.Enabled = true;
                    break;
            }
        }
        #region 无边框拖动

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            FuelDevice = null;
            OneDevice = null;
            Tw0Device = null;
            this.Control = null;
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
        public DateTime StartFuelTime { get; set; } = DateTime.MinValue;
        public string FuelSensorName { get; set; } = null;
        public string FuelSettingPre { get; set; } = null;
        public bool IsFuelTimeRecorded { get; set; } = false;

        public bool IsFuelPoint{ get; set; } = false;

        public DateTime StartOxygenTime { get; set; } = DateTime.MinValue;
        public string OxygenSensorName { get; set; } = null;
        public string OxygenSettingPre { get; set; } = null;
        public bool IsOxygenTimeRecorded { get; set; } = false;

        public bool IsOxygenPoint { get; set; } = false;

        private void btn_startFuel_Click(object sender, EventArgs e)
        {

            if (!this.FuelDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,燃增压阀台开启增压失败");
                return;
            }
            var res = this.FuelDevice?.Write("PressureStart", "1");
            if (res.IsSuccess)
            {
                IsFuelTimeRecorded = true;
                Addlog(0, $"{CB_Fuel.SelectedItem.ToString()}燃增压阀台开启增压成功");
            }
            else
            {
                IsFuelTimeRecorded = false;
                Addlog(1, $"{CB_Fuel.SelectedItem.ToString()}燃增压阀台开启增压失败");
            }

        }

        private void btn_endFuel_Click(object sender, EventArgs e)
        {
            if (!this.FuelDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,燃增压阀台停止增压失败");
                return;
            }
            var res = this.FuelDevice?.Write("PressureStart", "0");
            if (res.IsSuccess)
            {
                IsFuelTimeRecorded = false;
                this.StartFuelTime = DateTime.MinValue;
                Addlog(0, $"{CB_Fuel.SelectedItem.ToString()}燃增压阀台停止增压成功");
            }
            else
            {
                Addlog(1, $"{CB_Fuel.SelectedItem.ToString()}燃增压阀台停止增压失败");
            }
        }

        private void btn_pointFuel_Click(object sender, EventArgs e)
        {
            if (!this.FuelDevice.IsConnected)
            {
                Addlog(2, "PLC连接异常,燃增压配置设定失败");
                return;
            }
            if (this.txt_Fuel_P.Text.Length <= 0)
            {
                Addlog(2, "燃增压设定压力不得为空");
                return;
            }
            result = this.FuelDevice.Write("FuelMedium", (this.CB_Fuel.SelectedIndex + 1).ToString()).IsSuccess;
            result &= this.FuelDevice.Write("Sensor", (this.CB_FuelSensor.SelectedIndex + 1).ToString()).IsSuccess;
            result &= this.FuelDevice.Write("WorkState", (this.CB_FuelFlow.SelectedIndex + 1).ToString()).IsSuccess;
            result &= this.FuelDevice.Write("Pressure", txt_Fuel_P.Text).IsSuccess;
            if (result)
            {
                Addlog(0, $"设定介质 : {CB_Fuel.SelectedItem.ToString()} 设定工况: {this.CB_FuelFlow.SelectedItem.ToString()} 设定压力: {this.txt_Fuel_P.Text} 设定目标传感器: {this.CB_FuelSensor.SelectedItem.ToString()} 设定结果: 成功");
                if (IsFuelTimeRecorded)
                {
                    this.StartFuelTime = DateTime.Now;
                    this.FuelSensorName = CB_FuelSensor.SelectedItem.ToString();
                    FuelSettingPre = txt_Fuel_P.Text;
                    this.IsFuelPoint = true;
                }
                else
                {
                    this.Control.FuellastPointPre = Convert.ToDouble(txt_Fuel_P.Text);
                }
            }
            else
            {
                Addlog(1, $"设定介质 : {CB_Fuel.SelectedItem.ToString()} 设定工况: {this.CB_FuelFlow.SelectedItem.ToString()} 设定压力: {this.txt_Fuel_P.Text} 设定目标传感器: {this.CB_FuelSensor.SelectedItem.ToString()} 设定结果: 失败");
            }
        }

        private void CB_Fuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CB_FuelSensor.Items.Clear();
            if (this.CB_Fuel.SelectedIndex == 0)
            {
                this.CB_FuelSensor.Items.AddRange(Kerosene);
                CB_FuelSensor.SelectedIndex = Convert.ToInt32(this.FuelDevice?["Sensor"]) - 1;

            }
            else if (this.CB_Fuel.SelectedIndex == 1)
            {
                this.CB_FuelSensor.Items.AddRange(Methane);
                CB_FuelSensor.SelectedIndex = Convert.ToInt32(this.FuelDevice?["Sensor"]) - 1;

            }
        }

        private void CB_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CB_OxygenSensor.Items.Clear();
            if (this.CB_Station.SelectedIndex == 0)
            {
                this.CB_OxygenSensor.Items.AddRange(Station1);
                if (OneDevice.IsConnected)
                {
                    this.CB_OxygenFlow.SelectedIndex = Convert.ToInt32(this.OneDevice?["WorkState"]) - 1;
                    this.txt_Oxygen_P.Text = this.OneDevice?["Pressure"].ToString();
                    this.CB_OxygenSensor.SelectedIndex = Convert.ToInt32(this.OneDevice?["Sensor"]) - 1;
                }
            }
            else
            {
                this.CB_OxygenSensor.Items.AddRange(Station2);
                if (Tw0Device.IsConnected)
                {
                    this.CB_OxygenFlow.SelectedIndex = Convert.ToInt32(this.Tw0Device?["WorkState"]) - 1;
                    this.txt_Oxygen_P.Text = this.Tw0Device?["Pressure"].ToString();
                    this.CB_OxygenSensor.SelectedIndex = Convert.ToInt32(this.Tw0Device?["Sensor"]) - 1;
                }
            }
        }

        private void btn_pointOxygen_Click(object sender, EventArgs e)
        {
            if (!this.OneDevice.IsConnected && !this.Tw0Device.IsConnected)
            {
                Addlog(2, "PLC连接异常,氧增压配置设定失败");
                return;
            }
            if (this.txt_Oxygen_P.Text.Length <= 0)
            {
                Addlog(2, "设定压力不得为空");
                return;
            }
            if (this.CB_Station.SelectedIndex == 0)
            {
                result = this.OneDevice.Write("Sensor", (this.CB_OxygenSensor.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.OneDevice.Write("WorkState", (this.CB_OxygenFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.OneDevice.Write("Pressure", txt_Oxygen_P.Text).IsSuccess;
            }
            else
            {
                result = this.Tw0Device.Write("Sensor", (this.CB_OxygenSensor.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.Tw0Device.Write("WorkState", (this.CB_OxygenFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.Tw0Device.Write("Pressure", txt_Oxygen_P.Text).IsSuccess;
            }

            if (result)
            {
                Addlog(0, $"{this.CB_Station.SelectedItem.ToString()} 设定工况: {this.CB_OxygenFlow.SelectedItem.ToString()} 设定压力: {this.txt_Oxygen_P.Text} 设定目标传感器: {this.CB_OxygenSensor.SelectedItem.ToString()} 设定结果: 成功");
                if (IsOxygenTimeRecorded)
                {
                    this.OxygenSensorName = CB_OxygenSensor.SelectedItem.ToString();
                    this.StartOxygenTime = DateTime.Now;
                    OxygenSettingPre = txt_Oxygen_P.Text;
                    this.IsOxygenPoint = true;
                }
                else
                {
                    this.Control.OxygenlastPointPre = Convert.ToDouble(txt_Oxygen_P.Text);
                }
            }
            else
            {
                Addlog(1, $"{this.CB_Station.SelectedItem.ToString()} 设定工况: {this.CB_OxygenFlow.SelectedItem.ToString()} 设定压力: {this.txt_Oxygen_P.Text} 设定目标传感器: {this.CB_OxygenSensor.SelectedItem.ToString()} 设定结果: 失败");
            }
        }

        private void btn_startOxygen_Click(object sender, EventArgs e)
        {

            if (this.CB_Station.SelectedIndex == 0)
            {
                var res = this.OneDevice?.Write("PressureStart", "1");
                if (res.IsSuccess)
                {
                    IsOxygenTimeRecorded = true;
                    Addlog(0, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台开启增压成功");
                }
                else
                {
                    IsOxygenTimeRecorded = false;
                    Addlog(1, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台开启增压失败");
                }
            }
            else
            {
                var res = this.Tw0Device?.Write("PressureStart", "1");
                if (res.IsSuccess)
                {
                    IsOxygenTimeRecorded = true;
                    Addlog(0, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台开启增压成功");
                }
                else
                {
                    IsOxygenTimeRecorded = false;
                    Addlog(1, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台开启增压失败");
                }
            }

        }

        private void btn_endOxygen_Click(object sender, EventArgs e)
        {
            if (this.CB_Station.SelectedIndex == 0)
            {
                var res = this.OneDevice?.Write("PressureStart", "0");
                if (res.IsSuccess)
                {
                    this.StartOxygenTime = DateTime.MinValue;
                    IsOxygenTimeRecorded = false;
                    Addlog(0, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台停止增压成功");
                }
                else
                {
                    Addlog(1, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台停止增压失败");
                }
            }
            else
            {
                var res = this.Tw0Device?.Write("PressureStart", "0");
                if (res.IsSuccess)
                {
                    IsOxygenTimeRecorded = false;
                    this.StartOxygenTime = DateTime.MinValue;
                    Addlog(0, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台停止增压成功");
                }
                else
                {
                    Addlog(1, $"{this.CB_Station.SelectedItem.ToString()}氧增压阀台停止增压失败");
                }
            }
        }
        private void ShowChildForm(Form frm)
        {
            this.TopMost = false;

            frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog(this);

            this.TopMost = true;
        }

        private void btn_OxygenTime_Click(object sender, EventArgs e)
        {
            string selectedOxygen = CB_Station.Text;
            if (selectedOxygen == "工位1")
            {
                FormSequenceSettings frm = new FormSequenceSettings(PressureSettingType.OneOxygen, Control);
                ShowChildForm(frm);
            }
            else if (selectedOxygen == "工位2")
            {
                FormSequenceSettings frm = new FormSequenceSettings(PressureSettingType.TwoOxygen, Control);
                ShowChildForm(frm);
            }
            else
            {
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请先选择工位（工位1或工位2）！", "提示");
                frmMsg.ShowDialog();
            }
        }

        private void btn_FuelTime_Click(object sender, EventArgs e)
        {
            string selectedFuel = CB_Fuel.Text;

            if (selectedFuel == "甲烷")
            {
                FormSequenceSettings frm = new FormSequenceSettings(PressureSettingType.Methane, Control);
                ShowChildForm(frm); 
            }
            else if (selectedFuel == "煤油")
            {
                FormSequenceSettings frm = new FormSequenceSettings(PressureSettingType.Kerosene, Control);
                ShowChildForm(frm); 
            }
            else
            {
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请先选择燃料介质（甲烷或煤油）！", "提示");
                frmMsg.ShowDialog();
            }
        }
    }
}
