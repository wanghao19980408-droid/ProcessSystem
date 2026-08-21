using NodeSettings;
using ProcessSystemLib;
using System;
using System.Drawing;
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

        private CancellationTokenSource cts;
        string[] Kerosene = { "PT401", "PT401a", "PT401b", "PT403", "待新增" };
        string[] Methane = { "PT306", "PT307", "PT308" };
        string[] Station1 = { "PT214", "PT215", "PT216" };
        string[] Station2 = { "PT218", "PT219", "PT220", "PT222", "PT223", "待新增" };
        string[] Station = { "工位1", "工位2" };
        FormMain Control = null;

        private DualFault dualFaultFormInstance = null;
        private DualFault singleFaultFormInstance = null;


        private class SystemDataDTO
        {
            public string MainSensorValue { get; set; }
            public string BackupSensorValue { get; set; }
            public bool IsDualFault { get; set; }
            public bool MainSensorFlag { get; set; }
            public bool BackupSensorFlag { get; set; }
            public bool IsSteady { get; set; }
            public int BaseSensor { get; set; } 
        }

        private class SystemStatusTracker
        {
            public bool IsDualFault { get; set; } = false;
            public bool LastMainSensorStatus { get; set; } = true;
            public bool LastBackupSensorStatus { get; set; } = true;
            public bool IsFirstSteadyState { get; set; } = true;
            public string LastWy { get; set; } = "未稳态";
        }

        private SystemStatusTracker oxygenTracker = new SystemStatusTracker();
        private SystemStatusTracker fuelTracker = new SystemStatusTracker();

        public PressureStation(FormMain control)
        {
            InitializeComponent();
            this.FuelDevice = control.FuelDevice;
            this.OneDevice = control.Firing1Device;
            this.Tw0Device = control.Firing2Device;
            this.Control = control;
            this.Load += Pressurize_Load;
            this.FormClosing += (s, e) => cts?.Cancel();

            if (Convert.ToInt32(Tw0Device?["初始增压目标传感器"]) == 1)
            {
                rb_MainSensor.Checked = true;
            }
            else
            {
                rb_BackupSensor.Checked = true;
            }
            cts = new CancellationTokenSource();
        }

        private void Pressurize_Load(object sender, EventArgs e)
        {
            this.CB_Station.Items.AddRange(Station);
            this.CB_FuelSensorBackup.Items.AddRange(Kerosene);
            if (FuelDevice != null && FuelDevice.IsConnected)
            {
                int fuelMediumIndex = Convert.ToInt32(this.FuelDevice?["FuelMedium"]) - 1;
                if (fuelMediumIndex >= 0 && fuelMediumIndex < CB_Fuel.Items.Count)
                {
                    this.CB_Fuel.SelectedIndex = fuelMediumIndex;
                }

                this.txt_Fuel_P.Text = this.FuelDevice?["Pressure"]?.ToString() ?? "";

                int flowIndex = Convert.ToInt32(this.FuelDevice?["WorkState"]) - 1;
                if (flowIndex >= 0 && flowIndex < CB_FuelFlow.Items.Count)
                {
                    this.CB_FuelFlow.SelectedIndex = flowIndex;
                }

                int sensorMainIndex = Convert.ToInt32(this.FuelDevice?["MainSensor"]) - 1;
                int sensorBackupIndex = Convert.ToInt32(this.FuelDevice?["BackupSensor"]) - 1;

                if (sensorMainIndex >= 0 && sensorMainIndex < CB_FuelSensorMain.Items.Count)
                {
                    CB_FuelSensorMain.SelectedIndex = sensorMainIndex;
                }
                if (sensorBackupIndex >= 0 && sensorBackupIndex < CB_FuelSensorBackup.Items.Count)
                {
                    CB_FuelSensorBackup.SelectedIndex = sensorBackupIndex;
                }
                if (Convert.ToInt32(FuelDevice?["BaseSensor"]) == 1)
                {
                    rb_FuelMainSensor.Checked = true;
                }
                else
                {
                    rb_FuelBackupSensor.Checked = true;
                }
            }

            if (this.CB_Station.SelectedIndex == -1)
            {
                this.CB_Station.SelectedIndex = 0;
            }

            ApplyUserPermissions();
            _ = UpdateUIAsync();
        }

        #region UI 更新

        private async Task UpdateUIAsync()
        {
            try
            {
                while (!cts.IsCancellationRequested)
                {
                    SystemDataDTO oxygenData = null;
                    SystemDataDTO fuelData = null;

                    if (Tw0Device != null && Tw0Device.IsConnected && CB_Station.SelectedIndex == 1)
                    {
                        oxygenData = ReadOxygenData();
                    }

                    if (FuelDevice != null && FuelDevice.IsConnected && CB_Fuel.SelectedIndex == 0)
                    {
                        fuelData = ReadFuelData();
                    }

                    Control.InvokeIfRequired(() =>
                    {
                        if (this.IsDisposed || Control.IsDisposed) return;

                        if (oxygenData != null)
                        {
                            MainSensor1.Text = this.CB_OxygenSensorMain.SelectedItem?.ToString() ?? "未选择";
                            MainSensor2.Text = this.CB_OxygenSensorBackup.SelectedItem?.ToString() ?? "未选择";
                            this.lb_CurrentSetting2.Text = $"当前设定压力: {this.Tw0Device?["Pressure"]?.ToString()}" ?? "当前设定压力: 0.000";
                            ProcessSystemUI(oxygenData, oxygenTracker, "液氧", Tw0Device,
                                lb_MainSensor1, lb_MainSensor2, wy,
                                MainSensor1.Text, MainSensor2.Text,
                                lb_CurrentSensor, rb_MainSensor, rb_BackupSensor,
                                () =>
                                {
                                    this.panel5.Enabled = true;
                                },
                                () =>
                                {
                                    this.panel5.Enabled = false;
                                });
                        }

                        if (fuelData != null)
                        {
                            FuelMainSensor.Text = this.CB_FuelSensorMain.SelectedItem?.ToString() ?? "未选择";
                            FuelBackupSensor.Text = this.CB_FuelSensorBackup.SelectedItem?.ToString() ?? "未选择";
                            this.lb_CurrentSetting1.Text = $"当前设定压力: {this.FuelDevice?["Pressure"]?.ToString()}" ?? "当前设定压力: 0.000";
                            ProcessSystemUI(fuelData, fuelTracker, "煤油", FuelDevice,
                                lb_FuelMainSensor, lb_FuelBackupSensor, lb_FuelWY,
                                FuelMainSensor.Text, FuelBackupSensor.Text,
                                lb_FuelCurrentSensor, rb_FuelMainSensor, rb_FuelBackupSensor,
                                () => 
                                {
                                    this.panel4.Enabled = true;
                                },
                                () => 
                                {
                                    this.panel4.Enabled = false;
                                });
                        }
                    });

                    await Task.Delay(500, cts.Token);
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                Addlog?.Invoke(2, $"更新界面时出现异常: {ex.Message}");
            }
        }

        private SystemDataDTO ReadOxygenData()
        {
            try
            {
                return new SystemDataDTO
                {
                    MainSensorValue = Tw0Device["MainSensor"]?.ToString() ?? "0",
                    BackupSensorValue = Tw0Device["BackupSensor"]?.ToString() ?? "0",
                    IsDualFault = Convert.ToBoolean(Tw0Device["DualFalut"]),
                    MainSensorFlag = Convert.ToBoolean(Tw0Device["MainSensorFlag"]),
                    BackupSensorFlag = Convert.ToBoolean(Tw0Device["BackupSensorFlag"]),
                    IsSteady = Convert.ToBoolean(Tw0Device["稳压"]),
                    BaseSensor = Convert.ToInt32(Tw0Device["初始增压目标传感器"])
                };
            }
            catch { return null; }
        }

        private SystemDataDTO ReadFuelData()
        {
            try
            {
                return new SystemDataDTO
                {
                    MainSensorValue = FuelDevice["MainSensorValue"]?.ToString() ?? "0",
                    BackupSensorValue = FuelDevice["BackupSensorValue"]?.ToString() ?? "0",
                    IsDualFault = Convert.ToBoolean(FuelDevice["DualFlat"]),
                    MainSensorFlag = Convert.ToBoolean(FuelDevice["MainSensorFlag"]),
                    BackupSensorFlag = Convert.ToBoolean(FuelDevice["BackupSensorFlag"]),
                    IsSteady = Convert.ToBoolean(FuelDevice["WY"]),
                    BaseSensor = Convert.ToInt32(FuelDevice["BaseSensor"])
                };
            }
            catch { return null; }
        }

        private void ProcessSystemUI(
            SystemDataDTO data, SystemStatusTracker tracker, string sysName, SiemensDevice device,
            Label lblMainVal, Label lblBackupVal, Label lblWy,
            string mainSensorName, string backupSensorName,
            Label lblCurrent, RadioButton rbMain, RadioButton rbBackup,
            Action onNotSteadyAction = null, Action onSteadyAction = null)
        {
            lblMainVal.Text = data.MainSensorValue;
            lblBackupVal.Text = data.BackupSensorValue;

            string currentWyStatus = data.IsSteady ? "稳态" : "未稳态";
            lblWy.Text = currentWyStatus;

            if (data.IsDualFault && data.IsDualFault != tracker.IsDualFault && currentWyStatus != tracker.LastWy)
            {
                string dualFaultMsg = $"【严重警告】{sysName}系统双路传感器均发生严重偏差，请立即人工介入！";
                Addlog?.Invoke(2, dualFaultMsg);

                if (dualFaultFormInstance == null || dualFaultFormInstance.IsDisposed)
                {
                    device?.Write("DualFalut", "0"); 
                    dualFaultFormInstance = new DualFault(dualFaultMsg, "双路故障提示") { TopMost = true };
                    dualFaultFormInstance.Show();
                }
            }

            if (currentWyStatus == "稳态")
            {
                if (!tracker.IsFirstSteadyState)
                {
                    string alarmMsg = "";
                    string titleMsg = "";

                    if (tracker.LastMainSensorStatus && !data.MainSensorFlag && data.BackupSensorFlag)
                    {
                        lblCurrent.Text = backupSensorName;
                        rbBackup.Checked = true;
                        alarmMsg = $"【{sysName}系统警告】{sysName}主传感器异常, 已自动切至备用";
                        titleMsg = "单路故障报警";
                        Addlog?.Invoke(2, alarmMsg);
                    }
                    else if (tracker.LastBackupSensorStatus && !data.BackupSensorFlag && data.MainSensorFlag)
                    {
                        lblCurrent.Text = mainSensorName;
                        rbMain.Checked = true;
                        alarmMsg = $"【{sysName}系统警告】{sysName}备用传感器异常, 使用主路增压";
                        titleMsg = "单路故障报警";
                        Addlog?.Invoke(2, alarmMsg);
                    }
                    else if (!tracker.LastMainSensorStatus && !tracker.LastBackupSensorStatus && data.MainSensorFlag && !data.BackupSensorFlag)
                    {
                        lblCurrent.Text = mainSensorName;
                        rbMain.Checked = true;
                        alarmMsg = $"【{sysName}系统提示】主传感器恢复正常, 已自动恢复至主路";
                        titleMsg = "系统恢复提示";
                        Addlog?.Invoke(0, alarmMsg);
                    }
                    else if (data.MainSensorFlag && data.BackupSensorFlag && (!tracker.LastMainSensorStatus || !tracker.LastBackupSensorStatus))
                    {
                        lblCurrent.Text = mainSensorName;
                        rbMain.Checked = true;
                        alarmMsg = $"【{sysName}系统提示】双路传感器均正常, 已自动恢复至主路";
                        titleMsg = "系统恢复提示";
                        Addlog?.Invoke(0, alarmMsg);
                    }

                    if (!string.IsNullOrEmpty(alarmMsg))
                    {
                        if (singleFaultFormInstance == null || singleFaultFormInstance.IsDisposed)
                        {
                            singleFaultFormInstance = new DualFault(alarmMsg, titleMsg) { TopMost = true };
                            singleFaultFormInstance.Show();
                        }
                    }
                }
                else
                {
                    if (data.MainSensorFlag && data.BackupSensorFlag && !rbMain.Checked)
                    {
                        lblCurrent.Text = mainSensorName;
                        rbMain.Checked = true;
                    }
                }

                tracker.LastMainSensorStatus = data.MainSensorFlag;
                tracker.LastBackupSensorStatus = data.BackupSensorFlag;
                tracker.IsFirstSteadyState = false;

                onSteadyAction?.Invoke(); 
            }
            else 
            {
                tracker.IsFirstSteadyState = true;
                tracker.LastMainSensorStatus = true;
                tracker.LastBackupSensorStatus = true;

                lblCurrent.Text = data.BaseSensor == 1 ? mainSensorName : backupSensorName;
                rbMain.Enabled = true;
                rbBackup.Enabled = true;

                onNotSteadyAction?.Invoke(); 
            }

            tracker.LastWy = currentWyStatus;
            tracker.IsDualFault = data.IsDualFault;
        }

        #endregion

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

        public bool IsFuelPoint { get; set; } = false;

        public DateTime StartOxygenTime { get; set; } = DateTime.MinValue;
        public string OxygenSensorName { get; set; } = null;
        public string OxygenSettingPre { get; set; } = null;
        public bool IsOxygenTimeRecorded { get; set; } = false;

        public bool IsOxygenPoint { get; set; } = false;

        private void btn_startFuel_Click(object sender, EventArgs e)
        {
            if (this.FuelDevice == null || !this.FuelDevice.IsConnected)
            {
                Addlog?.Invoke(2, "PLC连接异常,燃增压阀台开启增压失败");
                return;
            }
            var res = this.FuelDevice.Write("PressureStart", "1");
            string fuelName = CB_Fuel.SelectedItem?.ToString() ?? "未选择燃料";

            if (res.IsSuccess)
            {
                IsFuelTimeRecorded = true;
                Addlog?.Invoke(0, $"{fuelName}燃增压阀台开启增压成功");
            }
            else
            {
                IsFuelTimeRecorded = false;
                Addlog?.Invoke(1, $"{fuelName}燃增压阀台开启增压失败");
            }
        }

        private void btn_endFuel_Click(object sender, EventArgs e)
        {
            if (this.FuelDevice == null || !this.FuelDevice.IsConnected)
            {
                Addlog?.Invoke(2, "PLC连接异常,燃增压阀台停止增压失败");
                return;
            }
            var res = this.FuelDevice.Write("PressureStart", "0");
            string fuelName = CB_Fuel.SelectedItem?.ToString() ?? "未选择燃料";

            if (res.IsSuccess)
            {
                IsFuelTimeRecorded = false;
                this.StartFuelTime = DateTime.MinValue;
                Addlog?.Invoke(0, $"{fuelName}燃增压阀台停止增压成功");
            }
            else
            {
                Addlog?.Invoke(1, $"{fuelName}燃增压阀台停止增压失败");
            }
        }

        private void btn_pointFuel_Click(object sender, EventArgs e)
        {
            if (this.FuelDevice == null || !this.FuelDevice.IsConnected)
            {
                Addlog?.Invoke(2, "PLC连接异常,燃增压配置设定失败");
                return;
            }
            if (string.IsNullOrEmpty(this.txt_Fuel_P.Text))
            {
                Addlog?.Invoke(2, "燃增压设定压力不得为空");
                return;
            }
            string fuelName = this.CB_Fuel.SelectedItem?.ToString() ?? "未选择";
            string flowName = this.CB_FuelFlow.SelectedItem?.ToString() ?? "未选择";
            string mainSensorName = this.CB_FuelSensorMain.SelectedItem?.ToString() ?? "未选择";
            string backupSensorName = this.CB_FuelSensorBackup.SelectedItem?.ToString() ?? "未选择";

            if (this.CB_Fuel.SelectedIndex == 0)
            {
                result = this.FuelDevice.Write("FuelMedium", (this.CB_Fuel.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("MainSensor", (this.CB_FuelSensorMain.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("BackupSensor", (this.CB_FuelSensorBackup.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("WorkState", (this.CB_FuelFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("Pressure", txt_Fuel_P.Text).IsSuccess;

                if (result)
                {
                    Addlog?.Invoke(0, $"设定介质 : {fuelName} 设定工况: {flowName} 设定压力: {this.txt_Fuel_P.Text} 设定主传感器: {mainSensorName} 设定备份传感器: {backupSensorName} 设定结果: 成功");
                }
                else
                {
                    Addlog?.Invoke(1, $"设定介质 : {fuelName} 设定工况: {flowName} 设定压力: {this.txt_Fuel_P.Text} 设定主传感器: {mainSensorName} 设定备份传感器: {backupSensorName} 设定结果: 失败");
                }
            }
            else
            {
                result = this.FuelDevice.Write("FuelMedium", (this.CB_Fuel.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("LNGSensor", (this.CB_FuelSensorMain.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("WorkState", (this.CB_FuelFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.FuelDevice.Write("Pressure", txt_Fuel_P.Text).IsSuccess;

                if (result)
                {
                    Addlog?.Invoke(0, $"设定介质 : {fuelName} 设定工况: {flowName} 设定压力: {this.txt_Fuel_P.Text} 设定传感器: {mainSensorName} 设定结果: 成功");
                }
                else
                {
                    Addlog?.Invoke(1, $"设定介质 : {fuelName} 设定工况: {flowName} 设定压力: {this.txt_Fuel_P.Text} 设定传感器: {mainSensorName} 设定结果: 失败");
                }
            }

            if (result)
            {
                if (IsFuelTimeRecorded)
                {
                    this.StartFuelTime = DateTime.Now;
                    this.FuelSensorName = mainSensorName;
                    FuelSettingPre = txt_Fuel_P.Text;
                    this.IsFuelPoint = true;
                }
                else
                {
                    if (double.TryParse(txt_Fuel_P.Text, out double parseValue))
                    {
                        this.Control.FuellastPointPre = parseValue;
                    }
                }
            }
        }
        private void CB_Fuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CB_FuelSensorMain.Items.Clear();
            if (this.CB_Fuel.SelectedIndex == 0)
            {
                this.CB_FuelSensorMain.Items.AddRange(Kerosene);
                this.CB_FuelSensorBackup.Enabled = true;
                this.CB_FuelSensorMain.Enabled = true;
                this.rb_FuelBackupSensor.Enabled = true;
                this.panel3.Enabled = true;
                this.lb_CurrentSetting1.Visible = true;
                if (FuelDevice != null && FuelDevice.IsConnected)
                {
                    CB_FuelSensorMain.SelectedIndex = Convert.ToInt32(this.FuelDevice?["MainSensor"]) - 1;
                    CB_FuelSensorBackup.SelectedIndex = Convert.ToInt32(this.FuelDevice?["BackupSensor"]) - 1;
                    if (Convert.ToInt32(FuelDevice?["BaseSensor"]) == 1)
                    {
                        rb_FuelMainSensor.Checked = true;
                    }
                    else
                    {
                        rb_FuelBackupSensor.Checked = true;
                    }
                }
            }   
            else
            {
                this.CB_FuelSensorMain.Items.AddRange(Methane);
                this.CB_FuelSensorBackup.Enabled = false;
                this.rb_FuelBackupSensor.Enabled = false;
                this.rb_FuelMainSensor.Checked = true;
                this.panel3.Enabled = false;
                this.lb_CurrentSetting1.Visible = false;
                if (FuelDevice != null && FuelDevice.IsConnected)
                {
                    this.CB_FuelFlow.SelectedIndex = Convert.ToInt32(this.FuelDevice?["WorkState"]) - 1;
                    this.txt_Fuel_P.Text = this.FuelDevice?["Pressure"]?.ToString() ?? "";
                    CB_FuelSensorMain.SelectedIndex = Convert.ToInt32(this.FuelDevice?["LNGSensor"]) - 1;
                }
            }
        }

        private void CB_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CB_OxygenSensorMain.Items.Clear();
            this.CB_OxygenSensorBackup.Items.Clear();
            if (this.CB_Station.SelectedIndex == 0)
            {
                this.CB_OxygenSensorMain.Items.AddRange(Station1);
                this.CB_OxygenSensorBackup.Items.Clear();
                this.CB_OxygenSensorBackup.Enabled = false;
                this.rb_BackupSensor.Enabled = false;
                this.rb_MainSensor.Checked = true;
                this.panel2.Enabled = false;
                this.lb_CurrentSetting2.Visible = false;
                if (OneDevice != null && OneDevice.IsConnected)
                {
                    this.CB_OxygenFlow.SelectedIndex = Convert.ToInt32(this.OneDevice?["WorkState"]) - 1;
                    this.txt_Oxygen_P.Text = this.OneDevice?["Pressure"]?.ToString() ?? "";
                    this.CB_OxygenSensorMain.SelectedIndex = Convert.ToInt32(this.OneDevice?["Sensor"]) - 1;
                }
            }
            else
            {
                this.CB_OxygenSensorMain.Items.AddRange(Station2);
                this.CB_OxygenSensorBackup.Items.AddRange(Station2);
                if (Tw0Device != null && Tw0Device.IsConnected)
                {
                    this.lb_CurrentSetting2.Visible = true;
                    this.CB_OxygenFlow.SelectedIndex = Convert.ToInt32(this.Tw0Device?["WorkState"]) - 1;
                    this.txt_Oxygen_P.Text = this.Tw0Device?["Pressure"]?.ToString() ?? "";
                    this.CB_OxygenSensorMain.SelectedIndex = Convert.ToInt32(this.Tw0Device?["目标传感器主"]) - 1;
                    this.CB_OxygenSensorBackup.SelectedIndex = Convert.ToInt32(this.Tw0Device?["目标传感器备"]) - 1;
                    this.CB_OxygenSensorBackup.Enabled = true;
                    this.panel2.Enabled = true;
                    if (Convert.ToInt32(Tw0Device?["初始增压目标传感器"]) == 1)
                    {
                        rb_MainSensor.Checked = true;
                    }
                    else
                    {
                        rb_BackupSensor.Checked = true;
                    }
                }
            }
        }

        private void btn_pointOxygen_Click(object sender, EventArgs e)
        {
            if ((this.OneDevice == null || !this.OneDevice.IsConnected) &&
                (this.Tw0Device == null || !this.Tw0Device.IsConnected))
            {
                Addlog?.Invoke(2, "PLC连接异常,氧增压配置设定失败");
                return;
            }
            if (string.IsNullOrEmpty(this.txt_Oxygen_P.Text))
            {
                Addlog?.Invoke(2, "设定压力不得为空");
                return;
            }

            string stationName = this.CB_Station.SelectedItem?.ToString() ?? "未选择";
            string flowName = this.CB_OxygenFlow.SelectedItem?.ToString() ?? "未选择";
            string mainSensorName = this.CB_OxygenSensorMain.SelectedItem?.ToString() ?? "未选择";
            string backupSensorName = this.CB_OxygenSensorBackup.SelectedItem?.ToString() ?? "未选择";

            if (this.CB_Station.SelectedIndex == 0)
            {
                result = this.OneDevice.Write("Sensor", (this.CB_OxygenSensorMain.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.OneDevice.Write("WorkState", (this.CB_OxygenFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.OneDevice.Write("Pressure", txt_Oxygen_P.Text).IsSuccess;
                if (result)
                {
                    Addlog?.Invoke(0, $"{stationName} 设定工况: {flowName} 设定压力: {this.txt_Oxygen_P.Text} 设定主目标传感器: {mainSensorName} 设定结果: 成功");
                }
            }
            else
            {
                result = this.Tw0Device.Write("目标传感器主", (this.CB_OxygenSensorMain.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.Tw0Device.Write("目标传感器备", (this.CB_OxygenSensorBackup.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.Tw0Device.Write("WorkState", (this.CB_OxygenFlow.SelectedIndex + 1).ToString()).IsSuccess;
                result &= this.Tw0Device.Write("Pressure", txt_Oxygen_P.Text).IsSuccess;
                if (result)
                {
                    Addlog?.Invoke(0, $"{stationName} 设定工况: {flowName} 设定压力: {this.txt_Oxygen_P.Text} 设定主目标传感器: {mainSensorName} 设定备目标传感器: {backupSensorName} 设定结果: 成功");
                }
            }

            if (result)
            {
                if (IsOxygenTimeRecorded)
                {
                    this.OxygenSensorName = mainSensorName;
                    this.StartOxygenTime = DateTime.Now;
                    OxygenSettingPre = txt_Oxygen_P.Text;
                    this.IsOxygenPoint = true;
                }
                else
                {
                    if (double.TryParse(txt_Oxygen_P.Text, out double parseValue))
                    {
                        this.Control.OxygenlastPointPre = parseValue;
                    }
                }
            }
            else
            {
                Addlog?.Invoke(1, $"{stationName} 设定工况: {flowName} 设定压力: {this.txt_Oxygen_P.Text} 设定目标传感器: {mainSensorName} 设定结果: 失败");
            }
        }

        private void btn_startOxygen_Click(object sender, EventArgs e)
        {
            string stationName = this.CB_Station.SelectedItem?.ToString() ?? "未选择";

            if (this.CB_Station.SelectedIndex == 0)
            {
                var res = this.OneDevice?.Write("PressureStart", "1");
                if (res != null && res.IsSuccess)
                {
                    IsOxygenTimeRecorded = true;
                    Addlog?.Invoke(0, $"{stationName}氧增压阀台开启增压成功");
                }
                else
                {
                    IsOxygenTimeRecorded = false;
                    Addlog?.Invoke(1, $"{stationName}氧增压阀台开启增压失败");
                }
            }
            else
            {
                var res = this.Tw0Device?.Write("PressureStart", "1");
                if (res != null && res.IsSuccess)
                {
                    IsOxygenTimeRecorded = true;
                    Addlog?.Invoke(0, $"{stationName}氧增压阀台开启增压成功");
                }
                else
                {
                    IsOxygenTimeRecorded = false;
                    Addlog?.Invoke(1, $"{stationName}氧增压阀台开启增压失败");
                }
            }
        }

        private void btn_endOxygen_Click(object sender, EventArgs e)
        {
            string stationName = this.CB_Station.SelectedItem?.ToString() ?? "未选择";

            if (this.CB_Station.SelectedIndex == 0)
            {
                var res = this.OneDevice?.Write("PressureStart", "0");
                if (res != null && res.IsSuccess)
                {
                    this.StartOxygenTime = DateTime.MinValue;
                    IsOxygenTimeRecorded = false;
                    Addlog?.Invoke(0, $"{stationName}氧增压阀台停止增压成功");
                }
                else
                {
                    Addlog?.Invoke(1, $"{stationName}氧增压阀台停止增压失败");
                }
            }
            else
            {
                var res = this.Tw0Device?.Write("PressureStart", "0");
                if (res != null && res.IsSuccess)
                {
                    IsOxygenTimeRecorded = false;
                    this.StartOxygenTime = DateTime.MinValue;
                    Addlog?.Invoke(0, $"{stationName}氧增压阀台停止增压成功");
                }
                else
                {
                    Addlog?.Invoke(1, $"{stationName}氧增压阀台停止增压失败");
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

        private void rb_MainSensor_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (CB_Station.SelectedIndex == 1)
                {
                    Tw0Device?.Write("初始增压目标传感器", rb.Tag?.ToString() ?? "");
                }
            }
        }

        private void rb_FuelBackupSensor_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (CB_Fuel.SelectedIndex == 0)
                {
                    FuelDevice?.Write("BaseSensor", rb.Tag?.ToString() ?? "");
                }
                else
                {
                    FuelDevice?.Write("BaseSensor", "1");
                }
            }
        }
    }
}