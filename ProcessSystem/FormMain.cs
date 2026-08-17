
using DataConvertLib;
using MiniExcelLibs;
using Newtonsoft.Json.Linq;
using NodeSettings;
using ProcessControlLib;
using ProcessSystemLib;
using ProcessSystemLib.Interface;
using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProcessSystem
{
    public partial class FormMain : Form
    {
        #region 基础配置与字段
        private readonly string iniFilePath = Application.StartupPath + "\\Config";

        private CancellationTokenSource cts = new CancellationTokenSource();

        private Task SensorLockTask;

        private Task UiRefreshTask;
        private int[] FuelArea { get; set; } = null;
        private int[] FiringI { get; set; } = null;
        private int[] FiringII { get; set; } = null;
        private int[] Gase { get; set; } = null;
        private int[] GaseSource { get; set; } = null;
        private int[] HighOne { get; set; } = null;
        private int[] HighTwo { get; set; } = null;

        //中燃
        public UDPManager FuelAreaUDPManager;
        public TCPManager FuelAreaTCPManager;
        private string FuelAreaExcelPath = Application.StartupPath + "\\PlcConfig\\FuelArea.xlsx";
        private List<Dictionary<string, object>> FuelArea_AdjustValve = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> FuelArea_SwitchValve = new List<Dictionary<string, object>>();
        public List<Dictionary<string, object>> FuelArea_Sensor = new List<Dictionary<string, object>>();
        private List<FuelSwitchCombo> FuelSwitchComboList = new List<FuelSwitchCombo>();
        private List<FuelSwitchIcon> FuelSwitchIconList = new List<FuelSwitchIcon>();
        private List<FuelAdjustValve> FuelAdjustValveList = new List<FuelAdjustValve>();
        private List<FuelSensor> FuelSensorList = new List<FuelSensor>();

        //助燃1
        public UDPManager FiringIUDPManager;
        public TCPManager FiringITCPManager;
        private string FiringIExcelPath = Application.StartupPath + "\\PlcConfig\\FiringI.xlsx";
        private List<Dictionary<string, object>> FiringI_AdjustValve = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> FiringI_SwitchValve = new List<Dictionary<string, object>>();
        public List<Dictionary<string, object>> FiringI_Sensor = new List<Dictionary<string, object>>();
        public List<Dictionary<string, object>> HighI = new List<Dictionary<string, object>>();
        private List<FiringIAdjustValve> FiringIAdjustValve = new List<FiringIAdjustValve>();
        private List<FiringISwitchCombo> FiringISwitchCombo = new List<FiringISwitchCombo>();
        private List<FiringISwitchIcon> FiringISwitchIcon = new List<FiringISwitchIcon>();
        private List<FiringISensor> FiringISensorList = new List<FiringISensor>();
        private List<FiringIHighAISensor> HighIList = new List<FiringIHighAISensor>();
        //助燃2
        public UDPManager FiringIIUDPManager;
        public TCPManager FiringIITCPManager;
        private string FiringIIExcelPath = Application.StartupPath + "\\PlcConfig\\FiringII.xlsx";
        public List<Dictionary<string, object>> HighII = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> FiringII_AdjustValve = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> FiringII_SwitchValve = new List<Dictionary<string, object>>();
        public List<Dictionary<string, object>> FiringII_Sensor = new List<Dictionary<string, object>>();
        private List<FiringIIAdjustValve> FiringIIAdjustValveList = new List<FiringIIAdjustValve>();
        private List<FiringIISwitchCombo> FiringIISwitchCombo = new List<FiringIISwitchCombo>();
        private List<FiringIISwitchIcon> FiringIISwitchIcon = new List<FiringIISwitchIcon>();
        private List<FiringIISensor> FiringIISensorList = new List<FiringIISensor>();
        private List<FiringIIHighAISensor> HighIIList = new List<FiringIIHighAISensor>();

        //配气
        private UDPManager GaseUDPManager;
        private TCPManager GaseTCPManager;
        private string GaseSupplyExcelPath = Application.StartupPath + "\\PlcConfig\\GaseSupply.xlsx";
        public List<Dictionary<string, object>> GaseSupply_Sensor = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> GaseSupply_Switch = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> GaseSupply_AdjustValve = new List<Dictionary<string, object>>();
        private List<GaseSupplyElectricSwitchIcon> GaseSupplyElectricSwitchIconList = new List<GaseSupplyElectricSwitchIcon>();
        private List<GaseSupplyElectricSwitchCombo> GaseSupplyElectricSwitchComboList = new List<GaseSupplyElectricSwitchCombo>();
        private List<GaseSupplySolenoid> GaseSupplySolenoidValveList = new List<GaseSupplySolenoid>();
        private List<GaseSupplyAdjustValve> GaseSupplyAdjustValveList = new List<GaseSupplyAdjustValve>();
        private List<GaseSupplySensor> GaseSupplySensorList = new List<GaseSupplySensor>();

        //气源
        private UDPManager GaseSourceUDPManager;
        private TCPManager GaseSourceCPManager;
        private string GaseSourceExcelPath = Application.StartupPath + "\\PlcConfig\\GaseSource.xlsx";
        private List<Dictionary<string, object>> GaseSource_AdjustValve = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> GaseSource_SwitchValve = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> GaseSource_Sensor = new List<Dictionary<string, object>>();
        private List<GaseSourceAdjustValve> GaseSourceAdjustValveList = new List<GaseSourceAdjustValve>();
        private List<GaseSourceElectricSwitchIcon> GaseSourceElectricSwitchIconList = new List<GaseSourceElectricSwitchIcon>();
        private List<GaseSourceElectricSwitchCombo> GaseSourceElectricSwitchComboList = new List<GaseSourceElectricSwitchCombo>();
        private List<GaseSourceSensor> GaseSourceSensorList = new List<GaseSourceSensor>();



        #endregion
        public FormMain(int[] fuelArea, int[] firingI, int[] firingII, int[] gase, int[] source, int[] highOne, int[] highTwo)
        {
            InitializeComponent();

            this.Size = new Size(3440, 1440);
            this.FuelArea = fuelArea;
            this.FiringI = firingI;
            this.FiringII = firingII;
            this.Gase = gase;
            this.GaseSource = source;
            this.HighOne = highOne;
            this.HighTwo = highTwo;
            this.Load += FormMain_Load;
            this.FormClosing += FormMain_FormClosing;
        }
        private class PlcSheets
        {
            public List<Dictionary<string, object>> adjust;
            public List<Dictionary<string, object>> sw;
            public List<Dictionary<string, object>> sensor;
            public List<Dictionary<string, object>> high;
        }

        private PlcSheets ReadPLCConfigAsync_Helper(string path)
        {
            try
            {
                ReadExcel reader = new ReadExcel();
                reader.ReadDeviceExcel(path);
                var res = new PlcSheets
                {
                    adjust = reader.GetSheet("AdjustValve"),
                    sw = reader.GetSheet("SwitchValve"),
                    sensor = reader.GetSheet("Sensor"),
                    high = reader.GetSheet("HighAI")
                };
                return res;
            }
            catch (Exception ex)
            {
                AddLog(2, $"配置文件读取失败  地址：{path} 报错信息： {ex.Message}");
                return new PlcSheets();
            }
        }

        private Task<PlcSheets> ReadPLCConfigAsync(string path)
        {
            return Task.Run(() => ReadPLCConfigAsync_Helper(path));
        }

        #region 初始化
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = new FrmMsgWithAck("请确认是否关闭程序", "退出提醒").ShowDialog();
            if (dr == DialogResult.OK)
            {
                cts?.Cancel();
                FuelDevice?.Stop();
                Firing2Device?.Stop();
                Firing1Device?.Stop();
                GaseSourceDevice?.Stop();
                GaseSupplyDevice?.Stop();
                tr_SonSystem.Enabled = false;
                _heliumGasStation?.Dispose();
                _engineStation?.Dispose();
                _processStation?.Dispose();
                _controlAirStation?.Dispose();
                UiRefreshCts?.Cancel();
                FuelAreaTCPManager?.Stop();
                FiringITCPManager?.Stop();
                FiringIITCPManager?.Stop();
                GaseTCPManager?.Stop();
                GaseSourceCPManager?.Stop();
                FuelAreaUDPManager?.Stop();
                FiringIUDPManager?.Stop();
                FiringIIUDPManager?.Stop();
                GaseUDPManager?.Stop();
                GaseSourceUDPManager?.Stop();
                try { ValveLib.AddLog -= AddLog; } catch { }
                try { AlarmLib.AddAlarmLog -= AddWarLog; } catch { }
                try { FuelAreaUDPManager.DataUpdated -= UDPManager_FuelAreaDataUpdated; } catch { }
                try { FiringIUDPManager.DataUpdated -= UDPManager_FiringIDataUpdated; } catch { }
                try { FiringIIUDPManager.DataUpdated -= UDPManager_FiringIIDataUpdated; } catch { }
                try { GaseUDPManager.DataUpdated -= UDPManager_GaseDataUpdated; } catch { }
                try { GaseSourceUDPManager.DataUpdated -= UDPManager_GaseSourceDataUpdated; } catch { }
                try { IHighAIUDPManager.DataUpdated -= UDPManager_IHighAI; } catch { }
                try { IIHighAIUDPManager.DataUpdated -= UDPManager_IIHighAI; } catch { }
                try { UiRefreshCts?.Dispose(); } catch { }
                try { cts?.Dispose(); } catch { }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private readonly string ThrustConfig = Application.StartupPath + "\\ThrustConfig.ini";
        public double ThrustTwoK { get; set; }
        public double ThrustTwoB { get; set; }
        public double ThrustOneK { get; set; }
        public double ThrustOneB { get; set; }
        private Dictionary<Type, TCPManager> valveTcpMap;
        private void InitValveTcpMap()
        {
            valveTcpMap = new Dictionary<Type, TCPManager>
            {
                { typeof(FuelSwitchCombo), FuelAreaTCPManager },
                { typeof(FuelSwitchIcon), FuelAreaTCPManager },
                { typeof(FiringISwitchCombo), FiringITCPManager },
                { typeof(FiringISwitchIcon), FiringITCPManager },
                { typeof(FiringIISwitchCombo), FiringIITCPManager },
                { typeof(FiringIISwitchIcon), FiringIITCPManager },
                { typeof(GaseSupplySolenoid), GaseTCPManager },
                { typeof(GaseSupplyElectricSwitchCombo), GaseTCPManager },
                { typeof(GaseSupplyElectricSwitchIcon), GaseTCPManager },
                { typeof(GaseSourceElectricSwitchCombo), GaseSourceCPManager },
                { typeof(GaseSourceElectricSwitchIcon), GaseSourceCPManager },
                { typeof(GaseSupplyAdjustValve), GaseTCPManager },
                { typeof(GaseSourceAdjustValve), GaseSourceCPManager },
                { typeof(FiringIAdjustValve), FiringITCPManager },
                { typeof(FiringIIAdjustValve), FiringIITCPManager },
                { typeof(FuelAdjustValve), FuelAreaTCPManager },
            };
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            ValveLib.AddLog += AddLog;
            AlarmLib.AddAlarmLog += AddWarLog;
            this.tbm_Main.SelectedIndex = 0;

            this.ThrustTwoK = IniConfigHelper.ReadIniData("Thrust2", "K", "1", ThrustConfig).ToDouble();
            this.ThrustTwoB = IniConfigHelper.ReadIniData("Thrust2", "B", "0", ThrustConfig).ToDouble();
            this.ThrustOneK = IniConfigHelper.ReadIniData("Thrust1", "K", "1", ThrustConfig).ToDouble();
            this.ThrustOneB = IniConfigHelper.ReadIniData("Thrust1", "B", "0", ThrustConfig).ToDouble();

            this.lv_Log.Columns[1].Width = this.lv_Log.Width - this.lv_Log.Columns[0].Width - 20;
            this.lv_WaLog.Columns[1].Width = this.lv_WaLog.Width - this.lv_WaLog.Columns[0].Width - 20;
            try
            {
                var fuelTask = ReadPLCConfigAsync(FuelAreaExcelPath);
                var firing1Task = ReadPLCConfigAsync(FiringIExcelPath);
                var firing2Task = ReadPLCConfigAsync(FiringIIExcelPath);
                var gaseSupplyTask = ReadPLCConfigAsync(GaseSupplyExcelPath);
                var gaseSourceTask = ReadPLCConfigAsync(GaseSourceExcelPath);

                await Task.WhenAll(fuelTask, firing1Task, firing2Task, gaseSupplyTask, gaseSourceTask);

                var fuelRes = await fuelTask;
                FuelArea_AdjustValve = fuelRes.adjust ?? new List<Dictionary<string, object>>();
                FuelArea_SwitchValve = fuelRes.sw ?? new List<Dictionary<string, object>>();
                FuelArea_Sensor = fuelRes.sensor ?? new List<Dictionary<string, object>>();

                var f1Res = await firing1Task;
                FiringI_AdjustValve = f1Res.adjust ?? new List<Dictionary<string, object>>();
                FiringI_SwitchValve = f1Res.sw ?? new List<Dictionary<string, object>>();
                FiringI_Sensor = f1Res.sensor ?? new List<Dictionary<string, object>>();
                HighI = f1Res.high ?? new List<Dictionary<string, object>>();

                var f2Res = await firing2Task;
                FiringII_AdjustValve = f2Res.adjust ?? new List<Dictionary<string, object>>();
                FiringII_SwitchValve = f2Res.sw ?? new List<Dictionary<string, object>>();
                FiringII_Sensor = f2Res.sensor ?? new List<Dictionary<string, object>>();
                HighII = f2Res.high ?? new List<Dictionary<string, object>>();

                var gsRes = await gaseSupplyTask;
                GaseSupply_AdjustValve = gsRes.adjust ?? new List<Dictionary<string, object>>();
                GaseSupply_Switch = gsRes.sw ?? new List<Dictionary<string, object>>();
                GaseSupply_Sensor = gsRes.sensor ?? new List<Dictionary<string, object>>();

                var gsrcRes = await gaseSourceTask;
                GaseSource_AdjustValve = gsrcRes.adjust ?? new List<Dictionary<string, object>>();
                GaseSource_SwitchValve = gsrcRes.sw ?? new List<Dictionary<string, object>>();
                GaseSource_Sensor = gsrcRes.sensor ?? new List<Dictionary<string, object>>();
                InitNetworkManagers();
                InitValveTcpMap();
                InvokeIfRequired(() =>
                {
                    FuelAreaInit();
                    FiringIInit();
                    FiringIIGaseInit();
                    GaseInit();
                    GaseSourceInit();
                    HighAIInit();
                });

                await Task.Run(() =>
                {
                    this.InitAlarmSettings();
                    var result = SiemensCFG.LoadDevice(S7Path);
                    if (result.IsSuccess)
                    {
                        FuelDevice = result.Content[0];
                        Firing2Device = result.Content[1];
                        Firing1Device = result.Content[2];
                        GaseSourceDevice = result.Content[3];
                        GaseSupplyDevice = result.Content[4];

                        FuelDevice.Start();
                        Firing1Device.Start();
                        Firing2Device.Start();
                        GaseSourceDevice.Start();
                        GaseSupplyDevice.Start();
                    }
                });

                StartUIRefreshLoop();
                tr_SonSystem.Tick += Tr_SonSystem_Tick;
            }
            catch (Exception ex)
            {
                AddLog(2, $"初始化失败: {ex.Message}");
            }
        }
        private UDPManager IHighAIUDPManager;
        private UDPManager IIHighAIUDPManager;

        private void InitNetworkManagers()
        {

            string localIPFuelArea = IniConfigHelper.ReadIniData("FuelArea", "Local", "", iniFilePath);
            string mIPFuelArea = IniConfigHelper.ReadIniData("FuelArea", "MulticastIP", "", iniFilePath);
            int mPortFuelArea = Convert.ToInt32(IniConfigHelper.ReadIniData("FuelArea", "MulticastPort", "", iniFilePath));
            string tcpIPFuelArea = IniConfigHelper.ReadIniData("FuelArea", "TCPIP", "", iniFilePath);
            int tcpPortFuelArea = Convert.ToInt32(IniConfigHelper.ReadIniData("FuelArea", "TCPPort", "", iniFilePath));

            string localIPFiringI = IniConfigHelper.ReadIniData("FiringI", "Local", "", iniFilePath);
            string mIPFiringI = IniConfigHelper.ReadIniData("FiringI", "MulticastIP", "", iniFilePath);
            int mPortFiringI = Convert.ToInt32(IniConfigHelper.ReadIniData("FiringI", "MulticastPort", "", iniFilePath));
            string tcpIPFiringI = IniConfigHelper.ReadIniData("FiringI", "TCPIP", "", iniFilePath);
            int tcpPortFiringI = Convert.ToInt32(IniConfigHelper.ReadIniData("FiringI", "TCPPort", "", iniFilePath));

            string localIPFiringII = IniConfigHelper.ReadIniData("FiringII", "Local", "", iniFilePath);
            string mIPFiringII = IniConfigHelper.ReadIniData("FiringII", "MulticastIP", "", iniFilePath);
            int mPortFiringII = Convert.ToInt32(IniConfigHelper.ReadIniData("FiringII", "MulticastPort", "", iniFilePath));
            string tcpIPFiringII = IniConfigHelper.ReadIniData("FiringII", "TCPIP", "", iniFilePath);
            int tcpPortFiringII = Convert.ToInt32(IniConfigHelper.ReadIniData("FiringII", "TCPPort", "", iniFilePath));

            string localIPGaseSupply = IniConfigHelper.ReadIniData("GaseSupply", "Local", "", iniFilePath);
            string mIPGaseSupply = IniConfigHelper.ReadIniData("GaseSupply", "MulticastIP", "", iniFilePath);
            int mPortGaseSupply = Convert.ToInt32(IniConfigHelper.ReadIniData("GaseSupply", "MulticastPort", "", iniFilePath));
            string tcpIPGaseSupply = IniConfigHelper.ReadIniData("GaseSupply", "TCPIP", "", iniFilePath);
            int tcpPortGaseSupply = Convert.ToInt32(IniConfigHelper.ReadIniData("GaseSupply", "TCPPort", "", iniFilePath));

            string localIPGaseSource = IniConfigHelper.ReadIniData("GaseSource", "Local", "", iniFilePath);
            string mIPGaseSource = IniConfigHelper.ReadIniData("GaseSource", "MulticastIP", "", iniFilePath);
            int mPortGaseSource = Convert.ToInt32(IniConfigHelper.ReadIniData("GaseSource", "MulticastPort", "", iniFilePath));
            string tcpIPGaseSource = IniConfigHelper.ReadIniData("GaseSource", "TCPIP", "", iniFilePath);
            int tcpPortGaseSource = Convert.ToInt32(IniConfigHelper.ReadIniData("GaseSource", "TCPPort", "", iniFilePath));

            string localIPHighI = IniConfigHelper.ReadIniData("HighAI-I", "Local", "", iniFilePath);
            string mIPHighI = IniConfigHelper.ReadIniData("HighAI-I", "MulticastIP", "", iniFilePath);
            int mPortHighI = Convert.ToInt32(IniConfigHelper.ReadIniData("HighAI-I", "MulticastPort", "", iniFilePath));

            string localIPHighII = IniConfigHelper.ReadIniData("HighAI-II", "Local", "", iniFilePath);
            string mIPHighII = IniConfigHelper.ReadIniData("HighAI-II", "MulticastIP", "", iniFilePath);
            int mPortHighII = Convert.ToInt32(IniConfigHelper.ReadIniData("HighAI-II", "MulticastPort", "", iniFilePath));

            FuelAreaUDPManager = new UDPManager(localIPFuelArea, mIPFuelArea, mPortFuelArea, FuelArea);
            FuelAreaUDPManager.DataUpdated += UDPManager_FuelAreaDataUpdated;
            FiringIUDPManager = new UDPManager(localIPFiringI, mIPFiringI, mPortFiringI, FiringI);
            FiringIUDPManager.DataUpdated += UDPManager_FiringIDataUpdated;
            FiringIIUDPManager = new UDPManager(localIPFiringII, mIPFiringII, mPortFiringII, FiringII);
            FiringIIUDPManager.DataUpdated += UDPManager_FiringIIDataUpdated;
            GaseUDPManager = new UDPManager(localIPGaseSupply, mIPGaseSupply, mPortGaseSupply, Gase);
            GaseUDPManager.DataUpdated += UDPManager_GaseDataUpdated;
            GaseSourceUDPManager = new UDPManager(localIPGaseSource, mIPGaseSource, mPortGaseSource, GaseSource);
            GaseSourceUDPManager.DataUpdated += UDPManager_GaseSourceDataUpdated;
            IHighAIUDPManager = new UDPManager(localIPHighI, mIPHighI, mPortHighI, HighOne);
            IHighAIUDPManager.DataUpdated += UDPManager_IHighAI;
            IIHighAIUDPManager = new UDPManager(localIPHighII, mIPHighII, mPortHighII, HighTwo);
            IIHighAIUDPManager.DataUpdated += UDPManager_IIHighAI;

            this.FormClosed += (s, e) =>
            {
                try { FuelAreaUDPManager?.Stop(); } catch { }
                try { FiringIUDPManager?.Stop(); } catch { }
                try { FiringIIUDPManager?.Stop(); } catch { }
                try { GaseUDPManager?.Stop(); } catch { }
                try { GaseSourceUDPManager?.Stop(); } catch { }
            };

            FuelAreaTCPManager = new TCPManager(localIPFuelArea, tcpIPFuelArea, tcpPortFuelArea);
            FuelAreaTCPManager.StartAutoReconnect();
            FiringITCPManager = new TCPManager(localIPFiringI, tcpIPFiringI, tcpPortFiringI);
            FiringITCPManager.StartAutoReconnect();
            FiringIITCPManager = new TCPManager(localIPFiringII, tcpIPFiringII, tcpPortFiringII);
            FiringIITCPManager.StartAutoReconnect();
            GaseTCPManager = new TCPManager(localIPGaseSupply, tcpIPGaseSupply, tcpPortGaseSupply);
            GaseTCPManager.StartAutoReconnect();
            GaseSourceCPManager = new TCPManager(localIPGaseSource, tcpIPGaseSource, tcpPortGaseSource);
            GaseSourceCPManager.StartAutoReconnect();
            BindTcpLevel(FuelAreaTCPManager, us_FuelArea);
            BindTcpLevel(FiringITCPManager, us_FiringI);
            BindTcpLevel(FiringIITCPManager, us_FiringIi);
            BindTcpLevel(GaseTCPManager, us_GaseSupply);
            BindTcpLevel(GaseSourceCPManager, us_GaseSource);
        }
        private void BindTcpLevel(TCPManager mgr, UISignal us)
        {
            void Update(bool connected)
            {
                if (IsDisposed || us.IsDisposed)
                    return;

                if (!IsHandleCreated)
                    return;

                BeginInvoke(new Action(() =>
                {
                    us.Level = connected ? 5 : 0;
                }));
            }
            mgr.ConnectionStateChanged += Update;

            this.FormClosed += (s, e) =>
            {
                try { mgr.ConnectionStateChanged -= Update; } catch { }
            };

            Update(mgr.IsConnected);
        }
        #endregion

        #region 通用方法
        private bool CheckUserLogin()
        {
            if (UserInfo != null)
            {
                return true;
            }
            else
            {
                new FrmMsgNoAck("请先登录！", "登陆提示").ShowDialog();
                return false;
            }
        }

        List<LogReport> logInfos = new List<LogReport>();
        private void btn_ExportLog_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "日志导出";
            saveFileDialog.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件|*.*";
            saveFileDialog.FileName = "日志记录" + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MiniExcel.SaveAs(saveFileDialog.FileName, logInfos);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void InvokeIfRequired(Action action)
        {
            if (IsDisposed || !IsHandleCreated) return;

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    try { action(); }
                    catch (Exception ex)
                    {
                        AddLog(2, $"UI线程异常: {ex}");
                    }
                }));
            }
            else
            {
                try { action(); }
                catch (Exception ex)
                {
                    AddLog(2, $"UI线程异常: {ex}");
                }
            }
        }

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
        private T GetControls<T>(int num, string name)
        {
            string controlName = name + num.ToString();
            return (T)this.GetType().GetField(controlName,
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
        }
        public void AddLog(int index, string log)
        {
            if (lv_Log.InvokeRequired)
            {
                lv_Log.Invoke(new Action<int, string>(AddLog), index, log);
                return;
            }

            DateTime now = DateTime.Now;
            ListViewItem item = new ListViewItem("   " + now.ToString("yyyy-MM-dd HH:mm:ss:fff"), index);
            this.logInfos.Add(new LogReport
            {
                InsertTime = now,
                LogInfo = log,
                LogType = index == 0 ? "成功日志" : "失败日志"
            });
            var user = UserInfo?.LoginName ?? "未登录";
            item.SubItems.Add(log + $"—— 操作者：{user}");
            lv_Log.Items.Add(item);
            lv_Log.EnsureVisible(lv_Log.Items.Count - 1);
        }
        public void AddWarLog(int index, string log)
        {
            if (lv_WaLog.InvokeRequired)
            {
                lv_WaLog.Invoke(new Action<int, string>(AddWarLog), index, log);
                return;
            }

            DateTime now = DateTime.Now;
            ListViewItem item = new ListViewItem("   " + now.ToString("yyyy-MM-dd HH:mm:ss"), index);
            item.SubItems.Add(log);
            lv_WaLog.Items.Add(item);
            lv_WaLog.EnsureVisible(lv_WaLog.Items.Count - 1);
        }

        private bool TryGetTcpManager(Type controlType, out TCPManager tcp)
        {
            return valveTcpMap.TryGetValue(controlType, out tcp);
        }
        private void HandleSpecialValve(SwitchDQCloseAndOpen cmd)
        {
            if (cmd.valveName == "HV212" || cmd.valveName == "HV215")
            {
                var pt226Interlock = _activeInterlocks.FirstOrDefault(x => x.SensorName == "PT226");

                if (pt226Interlock != null)
                {
                    pt226Interlock.ResetState();
                }
            }
        }

        private void MainLOValve_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            var valve = sender as IAirControlValveBase;
            if (valve == null)
                return;

            if (!TryGetTcpManager(sender.GetType(), out TCPManager tcp))
                return;
            if (tcp == null)
                return;

            var cmd = new SwitchDQCloseAndOpen
            {
                valveName = valve.ValveName,
                ValveState = valve.State,
                DQ = Convert.ToUInt16(valve.DqOpenAndClose),
                RegionName = valve.PLCRegion
            };

            HandleSpecialValve(cmd);

            string action;
            if (cmd.ValveState == ValveState.low || cmd.ValveState == ValveState.warning)
            {
                action = "关阀";
            }
            else
            {
                action = cmd.ValveState == ValveState.open ? "关阀" : "开阀";
            }

            DialogResult dr;
            if (tcp.IsConnected)
            {
                dr = new FrmMsgWithAck($"请确认是否操作{cmd.valveName}{action}", "动作确认").ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ValveLib.SendSolenoidValveCommand(tcp, cmd.ValveState == ValveState.close, cmd.DQ, cmd.valveName, action);
                }
            }
            else
            {
                AddLog(2, $"{cmd.valveName}{action}失败 :{cmd.RegionName}连接异常");
            }
        }
        private void Switch2Valve_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            var valve = sender as IElectricControlValveBase ?? sender as IAirControlValveBase;
            if (valve == null)
                return;

            if (!TryGetTcpManager(sender.GetType(), out TCPManager tcp))
                return;
            if (tcp == null)
                return;
            var cmd = new SwitchTwoDQValve
            {
                valveName = valve.ValveName,
                ValveState = valve.State,
                OpenDQ = Convert.ToUInt16(valve.DqOpen),
                CloseDQ = Convert.ToUInt16(valve.DqClose),
                RegionName = valve.PLCRegion
            };
            string action;
            if (cmd.ValveState == ValveState.low || cmd.ValveState == ValveState.warning)
            {
                action = "关阀";
            }
            else
            {
                action = cmd.ValveState == ValveState.open ? "关阀" : "开阀";
            }
            if (tcp.IsConnected)
            {
                DialogResult dr;
                dr = new FrmMsgWithAck($"请确认是否操作{cmd.valveName}{action}", "动作确认").ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ValveLib.SendValveCommand(tcp, cmd.ValveState == ValveState.close, cmd.OpenDQ, cmd.CloseDQ, cmd.valveName, action);
                }
            }
            else
            {
                AddLog(2, $"{cmd.valveName}{action}失败 :{cmd.RegionName}连接异常");
            }
        }
        private void AdjustValve_Click(object sender, AdjustInfo e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (!TryGetTcpManager(sender.GetType(), out TCPManager tcp))
                return;
            if (tcp == null)
                return;
            if (tcp.IsConnected)
            {
                if (!ushort.TryParse(e.InputValue, out ushort input))
                {
                    AddLog(1, $"{e.ValveName}开度输入值格式不正确");
                    return;
                }
                if (input < 0 || input > 100)
                {
                    AddLog(1, "开度值范围在0-100,请确认输入范围");
                    return;
                }
                ValveLib.SendRegulatingValveCommand(tcp, e.AdjustAQ, input, e.ValveName, e.AdjustType);
            }
            else
            {
                AddLog(2, $"{e.ValveName}调节失败: {e.PLCRegion}连接异常");
            }
        }
        #endregion

        #region 中燃区域
        public delegate void FuelDataUpdatedEventHandler(UDPValues e);

        public event FuelDataUpdatedEventHandler FuelDataUpdated;
        private void UDPManager_FuelAreaDataUpdated(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) FuelLatest = e;
            FuelDataUpdated?.Invoke(e);
        }

        private void FuelAreaInit()
        {
            InvokeIfRequired(() =>
            {
                this.InitializeSensor(FuelArea_Sensor, FuelSensorList, "fuelSensor");
                this.InitializeAirControlsValve<FuelSwitchCombo, FuelSwitchIcon>(FuelArea_SwitchValve, FuelSwitchComboList, FuelSwitchIconList, "fuelSwitchCombo", "fuelSwitchIcon");
                this.InitializeAdjust<FuelAdjustValve>(FuelArea_AdjustValve, FuelAdjustValveList, "fuelAdjustValve");
            });
        }
        #endregion
        #region 助燃I区域
        public delegate void FiringIDataUpdatedEventHandler(UDPValues e);

        public event FiringIIDataUpdatedEventHandler FiringIDataUpdated;
        private void UDPManager_FiringIDataUpdated(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) FiringILatest = e;
            FiringIDataUpdated?.Invoke(e);
        }
        private void FiringIInit()
        {
            InvokeIfRequired(() =>
            {
                this.InitializeAirControlsValve<FiringISwitchCombo, FiringISwitchIcon>(FiringI_SwitchValve, FiringISwitchCombo, FiringISwitchIcon, "firingISwitchCombo", "firingISwitchIcon");
                this.InitializeAdjust<FiringIAdjustValve>(FiringI_AdjustValve, FiringIAdjustValve, "firingIAdjustValve");
                this.InitializeSensor<FiringISensor>(FiringI_Sensor, FiringISensorList, "firingISensor");
            });
        }
        #endregion
        #region 助燃II区域

        public delegate void FiringIIDataUpdatedEventHandler(UDPValues e);

        public event FiringIIDataUpdatedEventHandler FiringIIDataUpdated;
        private void UDPManager_FiringIIDataUpdated(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) FiringIILatest = e;
            FiringIIDataUpdated?.Invoke(e);
        }

        private void FiringIIGaseInit()
        {
            InvokeIfRequired(() =>
            {
                this.InitializeAirControlsValve<FiringIISwitchCombo, FiringIISwitchIcon>(FiringII_SwitchValve, FiringIISwitchCombo, FiringIISwitchIcon, "firingIISwitchCombo", "firingIISwitchIcon");
                this.InitializeAdjust<FiringIIAdjustValve>(FiringII_AdjustValve, FiringIIAdjustValveList, "firingIIAdjustValve");
                this.InitializeSensor<FiringIISensor>(FiringII_Sensor, FiringIISensorList, "firingIISensor");
            });
        }
        #endregion
        #region 配气区域

        public delegate void GaseSensorDataUpdatedEventHandler(UDPValues e);

        public event GaseSensorDataUpdatedEventHandler GaseSensorDataUpdated;
        private void UDPManager_GaseDataUpdated(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) GaseLatest = e;
            GaseSensorDataUpdated?.Invoke(e);
        }
        private void GaseInit()
        {
            InvokeIfRequired(() =>
            {
                this.InitializeElectricControlsValve<GaseSupplyElectricSwitchCombo, GaseSupplyElectricSwitchIcon, GaseSupplySolenoid>(GaseSupply_Switch, GaseSupplyElectricSwitchIconList, "gaseSupplyElectricSwitchCombo", "gaseSupplyElectricSwitchIcon", GaseSupplyElectricSwitchComboList, GaseSupplySolenoidValveList, "gaseSupplySolenoid");
                this.InitializeAdjust<GaseSupplyAdjustValve>(GaseSupply_AdjustValve, GaseSupplyAdjustValveList, "gaseSupplyAdjustValve");
                this.InitializeSensor<GaseSupplySensor>(GaseSupply_Sensor, GaseSupplySensorList, "gaseSupplySensor");
            });
        }
        #endregion
        #region 气源区域
        public delegate void GaseSourceDataUpdatedEventHandler(UDPValues e);

        public event GaseSourceDataUpdatedEventHandler GaseSourceDataUpdated;
        private void UDPManager_GaseSourceDataUpdated(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) GaseSourceLatest = e;
            GaseSourceDataUpdated?.Invoke(e);
        }
        private void GaseSourceInit()
        {
            InvokeIfRequired(() =>
            {
                this.InitializeElectricControlsValve<GaseSourceElectricSwitchCombo, GaseSourceElectricSwitchIcon, GaseSupplySolenoid>(GaseSource_SwitchValve, GaseSourceElectricSwitchIconList, "gaseSourceElectricSwitchCombo", "gaseSourceElectricSwitchIcon", GaseSourceElectricSwitchComboList);
                this.InitializeAdjust<GaseSourceAdjustValve>(GaseSource_AdjustValve, GaseSourceAdjustValveList, "gaseSourceAdjustValve");
                this.InitializeSensor<GaseSourceSensor>(GaseSource_Sensor, GaseSourceSensorList, "gaseSourceSensor");
            });
        }
        #endregion
        #region 高速AI
        private void HighAIInit()
        {
            InitializeHighAI<FiringIHighAISensor>(HighI, HighIList, "firingIHighAISensor");
            InitializeHighAI<FiringIIHighAISensor>(HighII, HighIIList, "firingIIHighAISensor");
            SensorLockTask = Task.Run(() => SensorAndValveLock(cts.Token), cts.Token);
        }
        private void UDPManager_IIHighAI(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) High2Latest = e;
        }
        private void UDPManager_IHighAI(object sender, UDPValues e)
        {
            if (e == null) return;
            lock (UiLock) High1Latest = e;
        }
        #endregion
        #region 界面刷新
        private readonly object UiLock = new object();
        private UDPValues FuelLatest;
        private UDPValues FiringILatest;
        private UDPValues FiringIILatest;
        private UDPValues GaseLatest;
        private UDPValues GaseSourceLatest;
        private UDPValues High1Latest;
        private UDPValues High2Latest;
        private CancellationTokenSource UiRefreshCts;

        private void StartUIRefreshLoop()
        {
            UiRefreshCts = new CancellationTokenSource();

            UiRefreshTask = Task.Run(async () =>
            {
                var sw = new Stopwatch();
                UDPValues prevFuel = null, prevF1 = null, prevF2 = null, prevGase = null, prevSource = null, prevHigh1 = null, prevHigh2 = null;

                while (!UiRefreshCts.IsCancellationRequested)
                {
                    sw.Restart();

                    UDPValues fuel, f1, f2, gase, source, high1, high2;
                    lock (UiLock)
                    {
                        fuel = FuelLatest;
                        f1 = FiringILatest;
                        f2 = FiringIILatest;
                        gase = GaseLatest;
                        source = GaseSourceLatest;
                        high1 = High1Latest;
                        high2 = High2Latest;
                    }

                    bool shouldUpdateUI =
                        !object.ReferenceEquals(fuel, prevFuel) ||
                        !object.ReferenceEquals(f1, prevF1) ||
                        !object.ReferenceEquals(f2, prevF2) ||
                        !object.ReferenceEquals(gase, prevGase) ||
                        !object.ReferenceEquals(source, prevSource) ||
                        !object.ReferenceEquals(high1, prevHigh1) ||
                        !object.ReferenceEquals(high2, prevHigh2);

                    if (shouldUpdateUI)
                    {
                        prevFuel = fuel;
                        prevF1 = f1;
                        prevF2 = f2;
                        prevGase = gase;
                        prevSource = source;
                        prevHigh1 = high1;
                        prevHigh2 = high2;

                        double Onetl1 = 0, Onetl2 = 0, Onetl3 = 0, Onetl4 = 0;
                        double Twotl1 = 0, Twotl2 = 0, Twotl3 = 0, Twotl4 = 0;

                        var h1LA2 = HighIList?.FirstOrDefault(s => s.SensorName == "LA1#");
                        var h1LB2 = HighIList?.FirstOrDefault(s => s.SensorName == "LB1#");
                        var h1LC2 = HighIList?.FirstOrDefault(s => s.SensorName == "LC1#");
                        var h1LD2 = HighIList?.FirstOrDefault(s => s.SensorName == "LD1#");

                        var h2LA1 = HighIIList?.FirstOrDefault(s => s.SensorName == "LA2#");
                        var h2LB1 = HighIIList?.FirstOrDefault(s => s.SensorName == "LB2#");
                        var h2LC1 = HighIIList?.FirstOrDefault(s => s.SensorName == "LC2#");
                        var h2LD1 = HighIIList?.FirstOrDefault(s => s.SensorName == "LD2#");

                        Twotl1 = h2LA1?.PhysicalValue ?? 0;
                        Twotl2 = h2LB1?.PhysicalValue ?? 0;
                        Twotl3 = h2LC1?.PhysicalValue ?? 0;
                        Twotl4 = h2LD1?.PhysicalValue ?? 0;

                        Onetl1 = h1LA2?.PhysicalValue ?? 0;
                        Onetl2 = h1LB2?.PhysicalValue ?? 0;
                        Onetl3 = h1LC2?.PhysicalValue ?? 0;
                        Onetl4 = h1LD2?.PhysicalValue ?? 0;

                        if (IsHandleCreated && !IsDisposed)
                        {
                            try
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    try
                                    {
                                        if (high1 != null)
                                        {
                                            SensorLib.PrepareHighSensorValue(high1, HighIList);
                                            this.Total1.Text = (ThrustOneK * (Onetl1 + Onetl2 + Onetl3 + Onetl4) + ThrustOneB).ToString("0.000");
                                        }
                                        if (high2 != null)
                                        {
                                            SensorLib.PrepareHighSensorValue(high2, HighIIList);
                                            this.Total2.Text = (ThrustTwoK * (Twotl1 + Twotl2 + Twotl3 + Twotl4) + ThrustTwoB).ToString("0.000");
                                        }
                                        if (fuel != null)
                                        {
                                            SensorLib.PrepareSensorValue(fuel, FuelSensorList);
                                            ValveLib.ApplySwitchValveUI(FuelSwitchComboList, FuelSwitchIconList, ValveLib.PrepareSwitchValveValues(fuel, FuelSwitchComboList, FuelSwitchIconList));
                                            ValveLib.ApplyAdjustValveUI(FuelAdjustValveList, ValveLib.PrepareAdjustValveValues(fuel, FuelAdjustValveList));
                                        }

                                        if (f1 != null)
                                        {
                                            SensorLib.PrepareSensorValue(f1, FiringISensorList);
                                            ValveLib.ApplySwitchValveUI(FiringISwitchCombo, FiringISwitchIcon, ValveLib.PrepareSwitchValveValues(f1, FiringISwitchCombo, FiringISwitchIcon));
                                            ValveLib.ApplyAdjustValveUI(FiringIAdjustValve, ValveLib.PrepareAdjustValveValues(f1, FiringIAdjustValve));

                                        }
                                        if (f2 != null)
                                        {
                                            SensorLib.PrepareSensorValue(f2, FiringIISensorList);
                                            ValveLib.ApplySwitchValveUI(FiringIISwitchCombo, FiringIISwitchIcon, ValveLib.PrepareSwitchValveValues(f2, FiringIISwitchCombo, FiringIISwitchIcon));
                                            ValveLib.ApplyAdjustValveUI(FiringIIAdjustValveList, ValveLib.PrepareAdjustValveValues(f2, FiringIIAdjustValveList));
                                        }
                                        if (gase != null)
                                        {
                                            SensorLib.PrepareSensorValue(gase, GaseSupplySensorList);
                                            ValveLib.ApplyAdjustValveUI(GaseSupplyAdjustValveList, ValveLib.PrepareAdjustValveValues(gase, GaseSupplyAdjustValveList));
                                            ValveLib.ApplySolenoidValve(ValveLib.PrepareSolenoidValveStates(gase, GaseSupplySolenoidValveList), GaseSupplySolenoidValveList);
                                            ValveLib.ApplyElectricSwitchValveUI(GaseSupplyElectricSwitchComboList, GaseSupplyElectricSwitchIconList, ValveLib.PrepareSwitchValveValuesWithFault(gase, GaseSupplyElectricSwitchComboList, GaseSupplyElectricSwitchIconList));
                                        }
                                        if (source != null)
                                        {
                                            ValveLib.ApplyAdjustValveUI(GaseSourceAdjustValveList, ValveLib.PrepareAdjustValveValues(source, GaseSourceAdjustValveList));
                                            SensorLib.PrepareSensorValue(source, GaseSourceSensorList);
                                            ValveLib.ApplyElectricSwitchValveUI(GaseSourceElectricSwitchComboList, GaseSourceElectricSwitchIconList, ValveLib.PrepareSwitchValveValuesWithFault(source, GaseSourceElectricSwitchComboList, GaseSourceElectricSwitchIconList));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AddLog(2, $"UI 更新内部异常: {ex.Message}");
                                    }
                                }));
                            }
                            catch (InvalidOperationException) { /* 可能窗体已销毁 */ }
                        }
                    }

                    sw.Stop();
                    var elapsedMs = (int)sw.ElapsedMilliseconds;
                    var delay = Math.Max(0, 100 - elapsedMs);
                    try
                    {
                        await Task.Delay(delay, UiRefreshCts.Token);
                    }
                    catch (TaskCanceledException) { break; }
                }
            }, UiRefreshCts.Token);
        }
        #endregion

        #region PID联锁
        private void PID_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                String[] info = btn.Tag.ToString().Split('-');
                string area = info[0];
                byte index = Convert.ToByte(info[1], 10);
                string name = info[2];
                TCPManager tcp = null;
                switch (area)
                {
                    case "中燃":
                        tcp = FuelAreaTCPManager;
                        break;
                    case "助燃I":
                        tcp = FiringITCPManager;
                        break;
                    case "助燃II":
                        tcp = FiringIITCPManager;
                        break;
                    case "气源":
                        tcp = GaseSourceCPManager;
                        break;
                    case "配气":
                        tcp = GaseTCPManager;
                        break;
                    default:
                        break;
                }
                PIDSetting pIDSetting = new PIDSetting(area, tcp, index, name, this);
                pIDSetting.AddLog += AddLog;
                pIDSetting.ShowDialog();
            }
        }
        private void Lock_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                string[] info = btn.Tag.ToString().Split('-');
                string area = info[0];
                byte index = Convert.ToByte(info[1], 10);
                int mIndex = Convert.ToInt32(info[2]);
                string name = info[3];

                TCPManager tcp = null;
                switch (area)
                {
                    case "中燃":
                        tcp = FuelAreaTCPManager;
                        break;
                    case "助燃I":
                        tcp = FiringITCPManager;
                        break;
                    case "助燃II":
                        tcp = FiringIITCPManager;
                        break;
                    case "气源":
                        tcp = GaseSourceCPManager;
                        break;
                    case "配气":
                        tcp = GaseTCPManager;
                        break;
                    default:
                        break;
                }

                LockSetting lockSetting;
                if (info.ContainsIndex(4))
                {
                    string title = info[4];
                    lockSetting = new LockSetting(area, tcp, index, mIndex, name, this, title);
                }
                else
                {
                    lockSetting = new LockSetting(area, tcp, index, mIndex, name, this);
                }

                lockSetting.AddLog += AddLog;
                lockSetting.ShowDialog();
            }
        }
        private void PreLock_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                string[] info = btn.Tag.ToString().Split('-');
                string area = info[0];
                byte index = Convert.ToByte(info[1], 10);
                int mIndex = Convert.ToInt32(info[2]);
                string name = info[3];
                TCPManager tcp = null;
                LockNew pIDSetting;
                switch (area)
                {
                    case "中燃":
                        tcp = FuelAreaTCPManager;
                        break;
                    case "助燃I":
                        tcp = FiringITCPManager;
                        break;
                    case "助燃II":
                        tcp = FiringIITCPManager;
                        break;
                    case "气源":
                        tcp = GaseSourceCPManager;
                        break;
                    case "配气":
                        tcp = GaseTCPManager;
                        break;
                    default:
                        break;
                }
                pIDSetting = new LockNew(area, tcp, index, mIndex, name, this);
                pIDSetting.AddLog += AddLog;
                pIDSetting.ShowDialog();
            }
        }
        private void TempLock_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                string[] info = btn.Tag.ToString().Split('-');
                string area = info[0];
                byte index = Convert.ToByte(info[1], 10);
                int mIndex = Convert.ToInt32(info[2]);
                string name = info[3];
                TCPManager tcp = null;
                switch (area)
                {
                    case "中燃":
                        tcp = FuelAreaTCPManager;
                        break;
                    case "助燃I":
                        tcp = FiringITCPManager;
                        break;
                    case "助燃II":
                        tcp = FiringIITCPManager;
                        break;
                    case "气源":
                        tcp = GaseSourceCPManager;
                        break;
                    default:
                        break;
                }
                TempLock tpl = new TempLock(area, tcp, index, name, this);
                tpl.AddLog += AddLog;
                tpl.ShowDialog();
            }
        }
        private void LiquidLock_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                string[] info = btn.Tag.ToString().Split('-');
                string area = info[0];
                byte index = Convert.ToByte(info[1], 10);
                int mIndex = Convert.ToInt32(info[2]);
                string name = info[3];
                TCPManager tcp = null;
                switch (area)
                {
                    case "中燃":
                        tcp = FuelAreaTCPManager;
                        break;
                    case "助燃I":
                        tcp = FiringITCPManager;
                        break;
                    case "助燃II":
                        tcp = FiringIITCPManager;
                        break;
                    default:
                        break;
                }
                LiquidLock pIDSetting;
                pIDSetting = new LiquidLock(area,tcp, index, name, this);
                pIDSetting.AddLog += AddLog;
                pIDSetting.ShowDialog();
            }
        }
        #endregion

        #region 子系统
        string S7Path = Application.StartupPath + "\\S7config";
        public SiemensDevice FuelDevice = null;
        public SiemensDevice Firing2Device = null;
        public SiemensDevice Firing1Device = null;
        public SiemensDevice GaseSourceDevice = null;
        public SiemensDevice GaseSupplyDevice = null;
        private void Tr_SonSystem_Tick(object sender, EventArgs e)
        {
            InvokeIfRequired(() =>
            {
                this.AddPreTimes();
                this.lbl_SysTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (GaseSourceDevice.IsConnected)
                {
                    this.lb_OutPreOne.Text = Convert.ToSingle(GaseSourceDevice["泵1出气压力远传"]).ToString("f2");
                    this.lb_BackTempOne.Text = Convert.ToSingle(GaseSourceDevice["泵1回气温度远传"]).ToString("f1");
                    this.lb_OutTempOne.Text = Convert.ToSingle(GaseSourceDevice["泵1出气温度远传"]).ToString("f1");
                    this.lb_PumpHzOne.Text = Convert.ToSingle(GaseSourceDevice["泵1频率反馈远传"]).ToString("f2");

                    this.lb_OutPreTwo.Text = Convert.ToSingle(GaseSourceDevice["泵2出气压力远传"]).ToString("f2");
                    this.lb_BackTempTwo.Text = Convert.ToSingle(GaseSourceDevice["泵2回气温度远传"]).ToString("f1");
                    this.lb_OutTempTwo.Text = Convert.ToSingle(GaseSourceDevice["泵2出气温度远传"]).ToString("f1");
                    this.lb_PumpHzTwo.Text = Convert.ToSingle(GaseSourceDevice["泵2频率反馈远传"]).ToString("f2");

                    this.lb_HeatAir.Text = Convert.ToSingle(GaseSourceDevice["气温"]).ToString("f1");
                    this.lb_HeatLiquid.Text = Convert.ToSingle(GaseSourceDevice["液位"]).ToString("f1");
                    this.lb_HeatWater.Text = Convert.ToSingle(GaseSourceDevice["水温"]).ToString("f1");

                    bool pump1State = Convert.ToBoolean(GaseSourceDevice["泵1运行反馈远传"]);
                    bool pump1WindWAR = Convert.ToBoolean(GaseSourceDevice["泵1风机故障反馈远传"]);
                    bool pump1WAR = Convert.ToBoolean(GaseSourceDevice["泵1故障反馈远传"]);

                    if (pump1WindWAR)
                    {
                        this.motor1.PumpState = PumpState.故障;
                        this.lb_Pump1Info.Text = "泵1风机故障";
                        if (this.lb_Pump1Info.ForeColor != Color.Red)
                        {
                            this.lb_Pump1Info.ForeColor = Color.Red;
                        }
                    }
                    else if (pump1WAR)
                    {
                        this.motor1.PumpState = PumpState.故障;
                        this.lb_Pump1Info.Text = "泵1故障";
                        if (this.lb_Pump1Info.ForeColor != Color.Red)
                        {
                            this.lb_Pump1Info.ForeColor = Color.Red;
                        }
                    }
                    else if (pump1State)
                    {
                        this.lb_Pump1Info.Text = "低温液氮泵1#";
                        this.motor1.PumpState = PumpState.运行;
                        if (this.lb_Pump1Info.ForeColor != Color.White)
                        {
                            this.lb_Pump1Info.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        this.lb_Pump1Info.Text = "低温液氮泵1#";
                        this.motor1.PumpState = PumpState.停止;
                        if (this.lb_Pump1Info.ForeColor != Color.White)
                        {
                            this.lb_Pump1Info.ForeColor = Color.White;
                        }
                    }

                    bool pump2State = Convert.ToBoolean(GaseSourceDevice["泵2运行反馈远传"]);
                    bool pump2WindWAR = Convert.ToBoolean(GaseSourceDevice["泵2风机故障反馈远传"]);
                    bool pump2WAR = Convert.ToBoolean(GaseSourceDevice["泵2故障反馈远传"]);

                    if (pump2WindWAR)
                    {
                        this.motor3.PumpState = PumpState.故障;
                        this.lb_Pump2Info.Text = "泵2风机故障";
                        if (this.lb_Pump2Info.ForeColor != Color.Red)
                        {
                            this.lb_Pump2Info.ForeColor = Color.Red;
                        }
                    }
                    else if (pump2WAR)
                    {
                        this.motor3.PumpState = PumpState.故障;
                        this.lb_Pump2Info.Text = "泵2故障";
                        if (this.lb_Pump2Info.ForeColor != Color.Red)
                        {
                            this.lb_Pump2Info.ForeColor = Color.Red;
                        }
                    }
                    else if (pump2State)
                    {
                        this.lb_Pump2Info.Text = "低温液氮泵2#";
                        this.motor3.PumpState = PumpState.运行;
                        if (this.lb_Pump2Info.ForeColor != Color.White)
                        {
                            this.lb_Pump2Info.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        this.lb_Pump2Info.Text = "低温液氮泵2#";
                        this.motor3.PumpState = PumpState.停止;
                        if (this.lb_Pump2Info.ForeColor != Color.White)
                        {
                            this.lb_Pump2Info.ForeColor = Color.White;
                        }
                    }
                    bool disConnectWAR = Convert.ToBoolean(GaseSourceDevice["水温传感器断线报警"]);
                    bool tempHWAR = Convert.ToBoolean(GaseSourceDevice["水温高报警"]);
                    bool tempHHWAR = Convert.ToBoolean(GaseSourceDevice["水温高高报警"]);
                    bool liquidLow = Convert.ToBoolean(GaseSourceDevice["液位低报警"]);
                    bool liquidLLow = Convert.ToBoolean(GaseSourceDevice["液位低低报警"]);
                    bool PLCstopState = Convert.ToBoolean(GaseSourceDevice["PLC柜急停状态报警"]);
                    bool remoteStopWAR = Convert.ToBoolean(GaseSourceDevice["远程急停状态报警"]);
                    bool ControlHzWAR = Convert.ToBoolean(GaseSourceDevice["调功器故障报警"]);
                    bool remoteState = Convert.ToBoolean(GaseSourceDevice["远程运行状态"]);
                    bool localState = Convert.ToBoolean(GaseSourceDevice["本地运行状态"]);
                    bool remoteStartState = Convert.ToBoolean(GaseSourceDevice["远程模式状态"]);
                    bool localStartState = Convert.ToBoolean(GaseSourceDevice["本地模式状态"]);

                    if (disConnectWAR)
                    {
                        this.lb_Heart1Title.Text = "水温传感器断线报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }
                    }
                    else if (tempHWAR)
                    {
                        this.lb_Heart1Title.Text = "水温高报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (tempHHWAR)
                    {
                        this.lb_Heart1Title.Text = "水温高高报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (liquidLow)
                    {
                        this.lb_Heart1Title.Text = "液位低报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }
                    }
                    else if (liquidLLow)
                    {
                        this.lb_Heart1Title.Text = "液位低低报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (PLCstopState)
                    {
                        this.lb_Heart1Title.Text = "PLC柜急停状态报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (remoteStopWAR)
                    {
                        this.lb_Heart1Title.Text = "远程急停状态报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (ControlHzWAR)
                    {
                        this.lb_Heart1Title.Text = "调功器故障报警";
                        if (this.lb_Heart1Title.ForeColor != Color.Red)
                        {
                            this.lb_Heart1Title.ForeColor = Color.Red;
                        }

                    }
                    else if (remoteStartState)
                    {
                        string state = remoteState ? "运行" : "停止";
                        this.lb_Heart1Title.Text = $"水浴加热器远程模式{state}";
                        if (this.lb_Heart1Title.ForeColor != Color.White)
                        {
                            this.lb_Heart1Title.ForeColor = Color.White;
                        }
                        this.heater1.State = state == "运行" ? ValveState.open : ValveState.close;
                    }
                    else if (localStartState)
                    {
                        string state = localState ? "运行" : "停止";
                        this.lb_Heart1Title.Text = $"水浴加热器本地模式{state}";
                        if (this.lb_Heart1Title.ForeColor != Color.White)
                        {
                            this.lb_Heart1Title.ForeColor = Color.White;
                        }
                        this.heater1.State = state == "运行" ? ValveState.open : ValveState.close;
                    }
                    else
                    {
                        this.lb_Heart1Title.Text = "水浴加热器";
                        if (this.lb_Heart1Title.ForeColor != Color.White)
                        {
                            this.lb_Heart1Title.ForeColor = Color.White;
                        }
                        this.heater1.State = ValveState.close;
                    }

                }
                if (GaseSupplyDevice.IsConnected)
                {

                    this.Nitrogen_OutPutCent.Text = Convert.ToSingle(GaseSupplyDevice["加热器输出百分率"]).ToString("f1");
                    this.Nitrogen_CenterTemp.Text = Convert.ToSingle(GaseSupplyDevice["核心温度"]).ToString("f1");
                    this.Nitrogen_OutTemp.Text = Convert.ToSingle(GaseSupplyDevice["出口温度"]).ToString("f1");
                    bool highTrmpWAR = Convert.ToBoolean(GaseSupplyDevice["加热器核心超温"]);
                    bool exithighTrmpWAR = Convert.ToBoolean(GaseSupplyDevice["出口温度超温"]);
                    bool heateState1 = Convert.ToBoolean(GaseSupplyDevice["1#加热器状态"]);
                    bool heateState2 = Convert.ToBoolean(GaseSupplyDevice["2#加热器状态"]);
                    if (highTrmpWAR)
                    {
                        this.lb_Nheater.Text = "加热器核心超温";
                        if (this.lb_Nheater.ForeColor != Color.Red)
                        {
                            this.lb_Nheater.ForeColor = Color.Red;
                        }
                    }
                    else if (exithighTrmpWAR)
                    {
                        this.lb_Nheater.Text = "出口温度超温";
                        if (this.lb_Nheater.ForeColor != Color.Red)
                        {
                            this.lb_Nheater.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        this.lb_Nheater.Text = "氮气加热控制运行";
                        if (this.lb_Nheater.ForeColor != Color.White)
                        {
                            this.lb_Nheater.ForeColor = Color.White;
                        }
                    }
                    if (heateState1 || heateState2)
                    {
                        this.heater2.State = ValveState.open;
                    }
                    else
                    {
                        this.heater2.State = ValveState.close;
                    }
                }
                if (FuelDevice.IsConnected)
                {
                    this.lb_VacuumizeCurrent.Text = Convert.ToSingle(FuelDevice["远程运行电流"]).ToString("0.00");
                    this.lb_VacuumizePressure.Text = Convert.ToSingle(FuelDevice["远程实时压力"]).ToString("0.0");
                    this.lb_VacuumizeLiquidLevel.Text = Convert.ToSingle(FuelDevice["远程实时液位"]).ToString("0.00");
                    this.lt_VaStop.State = Convert.ToBoolean(FuelDevice["远程急停"]) ? UILightState.On : UILightState.Off;
                    lt_VaAuto.State = Convert.ToBoolean(FuelDevice["远程自动运行"]) ? UILightState.On : UILightState.Off;
                    lt_Remote.State = Convert.ToBoolean(FuelDevice["远程信号"]) ? UILightState.On : UILightState.Off;
                    lt_Valve1Open.State = Convert.ToBoolean(FuelDevice["阀1开到位"]) ? UILightState.On : UILightState.Off;
                    lt_Valve1Close.State = Convert.ToBoolean(FuelDevice["阀1关到位"]) ? UILightState.On : UILightState.Off;
                    lt_Valve2Open.State = Convert.ToBoolean(FuelDevice["阀2开到位"]) ? UILightState.On : UILightState.Off;
                    lt_Valve2Close.State = Convert.ToBoolean(FuelDevice["阀2关到位"]) ? UILightState.On : UILightState.Off;
                    lt_InAirOpen.State = Convert.ToBoolean(FuelDevice["进气开到位"]) ? UILightState.On : UILightState.Off;
                    lt_InAirClose.State = Convert.ToBoolean(FuelDevice["进气关到位"]) ? UILightState.On : UILightState.Off;
                    lt_Pump1a.State = Convert.ToBoolean(FuelDevice["泵1运行"]) ? UILightState.On : UILightState.Off;
                    lt_Pump1b.State = Convert.ToBoolean(FuelDevice["泵1过载"]) ? UILightState.On : UILightState.Off;
                    lt_Pump2a.State = Convert.ToBoolean(FuelDevice["泵2运行"]) ? UILightState.On : UILightState.Off;
                    lt_Pump2b.State = Convert.ToBoolean(FuelDevice["泵2过载"]) ? UILightState.On : UILightState.Off;
                    lt_pump1Lock.State = Convert.ToBoolean(FuelDevice["泵1自锁"]) ? UILightState.On : UILightState.Off;
                    lt_pump2Lock.State = Convert.ToBoolean(FuelDevice["泵2自锁"]) ? UILightState.On : UILightState.Off;
                    lt_LiquidLevel.State = Convert.ToBoolean(FuelDevice["液位达到"]) ? UILightState.On : UILightState.Off;
                    lt_Pressure.State = Convert.ToBoolean(FuelDevice["压力达到"]) ? UILightState.On : UILightState.Off;
                    motor2.PumpState = Convert.ToBoolean(FuelDevice["clState"]) ? PumpState.运行 : PumpState.停止;
                    if (Convert.ToBoolean(FuelDevice["clError"]))
                    {
                        lb_jjw.Text = "煤油循环泵报警！";
                        lb_jjw.ForeColor = Color.Red;
                    }
                    else
                    {
                        lb_jjw.Text = "煤油循环泵";
                        lb_jjw.ForeColor = Color.White;
                    }
                    this.lb_gt.Text = (Convert.ToInt16(FuelDevice["硅油出口温度"]) / 100f).ToString();
                    this.lb_bt.Text = (Convert.ToInt16(FuelDevice["煤油回油温度"]) / 100f).ToString();
                    this.tb_Jrs.Text = (Convert.ToInt16(FuelDevice["加热输出百分比"]) / 100f).ToString();
                    this.tb_Lqj.Text = (Convert.ToInt16(FuelDevice["冷却水进水温度"]) / 100f).ToString();
                    if (Convert.ToBoolean(FuelDevice["1#压缩机运行"]) || Convert.ToBoolean(FuelDevice["2#压缩机运行"]) || Convert.ToBoolean(FuelDevice["1#加热器运行"]) || Convert.ToBoolean(FuelDevice["2#加热器运行"]) || Convert.ToBoolean(FuelDevice["硅油循环泵运行"]))
                    {
                        this.pump3.State = ValveState.open;
                    }
                    else
                    {
                        this.pump3.State = ValveState.close;
                    }

                    if (Convert.ToBoolean(FuelDevice["报警停机1"]) || Convert.ToBoolean(FuelDevice["报警停机2"]) || Convert.ToBoolean(FuelDevice["报警不停机"]))
                    {
                        this.lb_jjwState.ForeColor = Color.Red;
                        this.lb_jjwState.Text = "煤油加降温报警!";
                    }
                    else
                    {
                        this.lb_jjwState.ForeColor = Color.White;
                        this.lb_jjwState.Text = "煤油加降温";
                    }
                }
                if (Firing1Device.IsConnected)
                {
                    this.DevelopmentPre1.Text = Convert.ToSingle(Firing1Device["DevelopmentPre1"]).ToString("0.00");
                    this.DevelopmentPre2.Text = Convert.ToSingle(Firing1Device["DevelopmentPre2"]).ToString("0.00");
                    this.GaseCon1.Text = Convert.ToSingle(Firing1Device["GaseCon1"]).ToString("0.00");
                    this.GaseCon2.Text = Convert.ToSingle(Firing1Device["GaseCon2"]).ToString("0.00");

                    this.DeFT.Text = Convert.ToSingle(Firing1Device["DeFT"]).ToString("0.00");
                    this.Depressure.Text = Convert.ToSingle(Firing1Device["Depressure"]).ToString("0.00");
                    this.Detemp.Text = Convert.ToSingle(Firing1Device["Detemp"]).ToString("0.00");


                    this.GaseConHigh.State = Convert.ToBoolean(FuelDevice["GaseConHigh"]) ? UILightState.On : UILightState.Off;
                    this.IgnitionFail1.State = Convert.ToBoolean(FuelDevice["IgnitionFail1"]) ? UILightState.On : UILightState.Off;
                    this.IgnitionFail2.State = Convert.ToBoolean(FuelDevice["IgnitionFail2"]) ? UILightState.On : UILightState.Off;
                }

            });
        }
        private void SetPump(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            PumpSetting1 pumpSetting = new PumpSetting1(GaseSourceDevice, GaseSourceCPManager);
            pumpSetting.Addlog += AddLog;
            pumpSetting.ShowDialog();
        }
        private void pump1_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            PumpSetting2 pumpSetting = new PumpSetting2(GaseSourceDevice, GaseSourceCPManager);
            pumpSetting.Addlog += AddLog;
            pumpSetting.ShowDialog();
        }
        public Action UpdateHeartState;
        private void heater1_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            HeatingSet heatSetting = new HeatingSet(GaseSourceDevice);
            heatSetting.Addlog += AddLog;
            heatSetting.ShowDialog();
        }
        private void heater2_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            Nitrogen_Heat nitrogen_Heat = new Nitrogen_Heat(GaseSupplyDevice);
            nitrogen_Heat.Addlog += AddLog;
            nitrogen_Heat.Show();
        }

        bool result;
        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (!FuelDevice.IsConnected)
            {
                AddLog(2, "PLC连接异常,抽真空系统-泵1开启失败");
                return;
            }
            result = FuelDevice.Write("泵1远程启动", "1").IsSuccess;
            await Task.Delay(50);
            result &= FuelDevice.Write("泵1远程启动", "0").IsSuccess;
            if (result)
            {
                AddLog(0, $"抽真空系统-泵1开启成功");
            }
            else
            {
                AddLog(1, $"抽真空系统-泵1开启失败");
            }
        }
        private async void btn_Pump2start_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (!FuelDevice.IsConnected)
            {
                AddLog(2, "PLC连接异常,抽真空系统-泵2开启失败");
                return;
            }
            result = FuelDevice.Write("泵2远程启动", "1").IsSuccess;
            await Task.Delay(50);
            result &= FuelDevice.Write("泵2远程启动", "0").IsSuccess;
            if (result)
            {
                AddLog(0, $"抽真空系统-泵2开启成功");
            }
            else
            {
                AddLog(1, $"抽真空系统-泵2开启失败");
            }
        }
        private async void btn_end_Click(object sender, EventArgs e)
        {
            if (!FuelDevice.IsConnected)
            {
                AddLog(2, "PLC连接异常,抽真空系统停止失败");
                return;
            }
            result = FuelDevice.Write("远程停止", "1").IsSuccess;
            await Task.Delay(50);
            result &= FuelDevice.Write("远程停止", "0").IsSuccess;
            if (result)
            {
                AddLog(0, $"抽真空系统停止成功");
            }
            else
            {
                AddLog(1, $"抽真空系统停止失败");
            }
        }
        private void pump3_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            Fuelicing pumpSetting = new Fuelicing(FuelDevice);
            pumpSetting.Addlog += AddLog;
            pumpSetting.ShowDialog();
        }

        private void pump_myxhb_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (!FuelDevice.IsConnected)
            {
                AddLog(2, "PLC连接异常,煤油循环泵控制失败");
                return;
            }
            if (sender is Motor motor)
            {
                if (motor.PumpState == PumpState.运行)
                {

                    DialogResult dr = new FrmMsgWithAck($"请确认是否操作煤油循环泵关阀", "动作确认").ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        MyxhbControl("clStop");
                    }
                }
                else
                {
                    DialogResult dr = new FrmMsgWithAck($"请确认是否操作煤油循环泵开阀", "动作确认").ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        MyxhbControl("clStart");
                    }
                }

            }
            else
            {
                return;
            }
        }
        private async void MyxhbControl(string action)
        {
            string res = action == "clStart" ? "启动" : "关闭";
            result = FuelDevice.Write(action, "1").IsSuccess;
            await Task.Delay(50);
            result &= FuelDevice.Write(action, "0").IsSuccess;
            if (result)
            {
                this.motor2.PumpState = res == "启动" ? PumpState.运行 : PumpState.停止;
                AddLog(0, $"煤油循环泵{res}成功");
            }
            else
            {
                AddLog(1, $"煤油循环泵{res}失败");
            }
        }
        #endregion

        #region 配气台
        private HeliumGasStation _heliumGasStation;
        private EngineStation _engineStation;
        private ProcessStation _processStation;
        private ControlAirStation _controlAirStation;
        private PressureStation pressureStation;
        private void btn_OpenHGS_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (_heliumGasStation == null || _heliumGasStation.IsDisposed)
            {
                _heliumGasStation = new HeliumGasStation(GaseTCPManager, this, GaseSupply_Sensor);
                _heliumGasStation.AddLog += this.AddLog;
            }
            _heliumGasStation.Show();
            _heliumGasStation.BringToFront();
        }
        private void btn_OpenEnginrStation_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (_engineStation == null || _engineStation.IsDisposed)
            {
                _engineStation = new EngineStation(GaseTCPManager, this, GaseSupply_Sensor);
                _engineStation.AddLog += this.AddLog;
            }
            _engineStation.Show();
            _engineStation.BringToFront();
        }
        private void btn_OpenControlAirStation_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (_controlAirStation == null || _controlAirStation.IsDisposed)
            {
                _controlAirStation = new ControlAirStation(GaseTCPManager, this, GaseSupply_Sensor);
                _controlAirStation.AddLog += this.AddLog;
            }
            _controlAirStation.Show();
            _controlAirStation.BringToFront();
        }

        private void btn_processStation_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (_processStation == null || _processStation.IsDisposed)
            {
                _processStation = new ProcessStation(GaseTCPManager, this);
                _processStation.AddLog += this.AddLog;
                _processStation.LockClick += Lock_Click;
            }
            _processStation.Show();
            _processStation.BringToFront();
        }
        private void PreStationControl_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            pressureStation = new PressureStation(this);
            pressureStation.Addlog += AddLog;
            pressureStation.Show();
        }
        #endregion

        #region 报警
        private void InitAlarmSettings()
        {
            AlarmLib.ProcessSensors(FuelArea_Sensor);
            AlarmLib.ProcessSensors(FiringI_Sensor);
            AlarmLib.ProcessSensors(FiringII_Sensor);
            AlarmLib.ProcessSensors(GaseSupply_Sensor);
            AlarmLib.ProcessSensors(GaseSource_Sensor);
        }
        #endregion

        #region 发动机回温联锁
        private List<DualValveInterlock> _activeInterlocks = new List<DualValveInterlock>();
        private LockDataService LockDataService = new LockDataService();
        private void InitInterlocks()
        {
            _activeInterlocks.Clear();

            void AddInterlock(string sensorName, string valve1Name, string valve2Name, Func<double> getSensorValue)
            {
                var v1Info = GetValveInfoByName(valve1Name);
                var v2Info = GetValveInfoByName(valve2Name);

                if (!v1Info.found || !v2Info.found)
                {
                    AddLog(1, $"【警告】联锁初始化失败：未在配置表中找到阀门 {valve1Name} 或 {valve2Name} 的配置信息。");
                    return;
                }

                _activeInterlocks.Add(new DualValveInterlock(
                    sensorName: sensorName,
                    valve1Dq: v1Info.dq,
                    tcpManager1: v1Info.tcp,
                    valve2Dq: v2Info.dq,
                    tcpManager2: v2Info.tcp,
                    lockDataService: LockDataService,
                    getSensorValue: getSensorValue
                ));
            }

            AddInterlock("PT226", "HV212", "HV215", () => HighIIList.FirstOrDefault(e => e.SensorName == "PT226")?.PhysicalValue ?? 0);

            AddInterlock("PT231", "HV221", "HV218", () => HighIList.FirstOrDefault(e => e.SensorName == "PT231")?.PhysicalValue ?? 0);

            AddInterlock("PT315", "HV306", "HV307", () => HighIList.FirstOrDefault(e => e.SensorName == "PT315")?.PhysicalValue ?? 0);
        }
        private (ushort dq, TCPManager tcp, bool found) GetValveInfoByName(string valveName)
        {
            ushort GetDq(Dictionary<string, object> dict)
            {
                if (dict.ContainsKey("DQOpenAndClose") && dict["DQOpenAndClose"] != null && ushort.TryParse(dict["DQOpenAndClose"].ToString(), out ushort dq))
                    return dq;
                if (dict.ContainsKey("DQOpen") && dict["DQOpen"] != null && ushort.TryParse(dict["DQOpen"].ToString(), out ushort dqOpen))
                    return dqOpen;
                return 0;
            }

            var v = FuelArea_SwitchValve.FirstOrDefault(x => x["Name"]?.ToString() == valveName);
            if (v != null) return (GetDq(v), FuelAreaTCPManager, true);

            v = FiringI_SwitchValve.FirstOrDefault(x => x["Name"]?.ToString() == valveName);
            if (v != null) return (GetDq(v), FiringITCPManager, true);

            v = FiringII_SwitchValve.FirstOrDefault(x => x["Name"]?.ToString() == valveName);
            if (v != null) return (GetDq(v), FiringIITCPManager, true);

            v = GaseSupply_Switch.FirstOrDefault(x => x["Name"]?.ToString() == valveName);
            if (v != null) return (GetDq(v), GaseTCPManager, true);

            v = GaseSource_SwitchValve.FirstOrDefault(x => x["Name"]?.ToString() == valveName);
            if (v != null) return (GetDq(v), GaseSourceCPManager, true);

            return (0, null, false);
        }
        private void LocalLock_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin())
            {
                return;
            }
            if (sender is Button btn)
            {
                LocalLock localLock = new LocalLock(btn.Tag.ToString());
                localLock.AddLog += AddLog;
                localLock.ShowDialog();
            }
        }
        private async Task SensorAndValveLock(CancellationToken token)
        {
            InitInterlocks();
            DateTime lastDbSyncTime = DateTime.MinValue;

            while (!token.IsCancellationRequested)
            {
                if ((DateTime.Now - lastDbSyncTime).TotalSeconds >= 3)
                {
                    foreach (var interlock in _activeInterlocks)
                    {
                        interlock.SyncDbConfig();
                    }
                    lastDbSyncTime = DateTime.Now;
                }
                foreach (var interlock in _activeInterlocks)
                {
                    interlock.CheckAndExecute();
                }

                try { await Task.Delay(100, token); }
                catch (TaskCanceledException) { break; }
            }
        }
        #endregion

        #region 储罐目标压力计时
        private void AddPreTimes()
        {
            if (pressureStation == null)
                return;
            if (pressureStation.IsFuelTimeRecorded)
            {
                ProcessPressureTime(
                    settingPressure: pressureStation.FuelSettingPre,
                    startDateTime: pressureStation.StartFuelTime,
                    sensorName: pressureStation.FuelSensorName,
                    isFuel: true
                );

            }
            if (pressureStation.IsOxygenTimeRecorded)
            {
                ProcessPressureTime(
                     settingPressure: pressureStation.OxygenSettingPre,
                     startDateTime: pressureStation.StartOxygenTime,
                     sensorName: pressureStation.OxygenSensorName,
                     isFuel: false
                );
            }
        }

        public double FuellastPointPre = 0;
        public double OxygenlastPointPre = 0;
        private void ProcessPressureTime(string settingPressure, DateTime startDateTime, string sensorName, bool isFuel)
        {
            if (string.IsNullOrEmpty(settingPressure) ||
                startDateTime == DateTime.MinValue ||
                string.IsNullOrEmpty(sensorName))
                return;

            if (!double.TryParse(settingPressure, out double targetPressure))
            {
                AddLog(1, $"{(isFuel ? "燃油" : "氧气")}目标压力格式错误: {settingPressure}");
                return;
            }

            double currentPressure = GetCurrentSensorPressure(sensorName);
            if (currentPressure < 0)
                return;

            double val = targetPressure;

            if (isFuel)
            {
                if (FuellastPointPre > val)
                {
                    if (currentPressure <= targetPressure)
                    {
                        RecordPressureReachTime(elapsed: DateTime.Now - startDateTime, targetPressure, isFuel);
                    }
                }
                else if (FuellastPointPre < val)
                {
                    if (currentPressure >= targetPressure)
                    {
                        RecordPressureReachTime(elapsed: DateTime.Now - startDateTime, targetPressure, isFuel);
                    }
                }
            }
            else
            {
                if (OxygenlastPointPre > val)
                {
                    if (currentPressure <= targetPressure)
                    {
                        RecordPressureReachTime(elapsed: DateTime.Now - startDateTime, targetPressure, isFuel);
                    }
                }
                else if (OxygenlastPointPre < val)
                {
                    if (currentPressure >= targetPressure)
                    {
                        RecordPressureReachTime(elapsed: DateTime.Now - startDateTime, targetPressure, isFuel);
                    }
                }
            }
        }
        private void RecordPressureReachTime(TimeSpan elapsed, double targetPressure, bool isFuel)
        {
            if (isFuel && pressureStation.IsFuelPoint)
            {
                pressureStation.IsFuelPoint = false;
                FuellastPointPre = targetPressure;
                AddLog(0, $"燃增压达到目标压力{targetPressure}，耗时: {elapsed.TotalMilliseconds}毫秒");
            }
            else if (!isFuel && pressureStation.IsOxygenPoint)
            {
                pressureStation.IsOxygenPoint = false;
                OxygenlastPointPre = targetPressure;
                AddLog(0, $"氧增压达到目标压力{targetPressure}，耗时: {elapsed.TotalMilliseconds}毫秒");
            }
        }
        private double GetCurrentSensorPressure(string sensorName)
        {
            var fuelSensor = FuelSensorList.FirstOrDefault(e => e.SensorName == sensorName);
            if (fuelSensor != null)
            {
                if (!double.TryParse(fuelSensor.PhysicalValue.ToString(), out double fuelValue))
                {
                    return -1;
                }
                return fuelValue;
            }
            var firingISensor = FiringISensorList.FirstOrDefault(e => e.SensorName == sensorName);
            if (firingISensor != null)
            {
                if (!double.TryParse(firingISensor.PhysicalValue.ToString(), out double firingIValue))
                {
                    return -1;
                }
                return firingIValue;
            }
            var firingIISensor = FiringIISensorList.FirstOrDefault(e => e.SensorName == sensorName);
            if (firingIISensor != null)
            {
                if (!double.TryParse(firingIISensor.PhysicalValue.ToString(), out double firingIIValue))
                {
                    return -1;
                }
                return firingIIValue;
            }
            AddLog(1, $"未找到传感器[{sensorName}]的当前压力数据");
            return -1;
        }
        #endregion

        #region 阀门通用方法
        //调节阀
        private void InitializeAdjust<T>(List<Dictionary<string, object>> config, List<T> controls, string name) where T : IAdjustValve
        {
            if (config == null || controls == null) return;

            for (int i = 0; i < config.Count; i++)
            {
                var item = config[i];

                var control = GetControls<T>(i + 1, name);
                controls.Add(control);

                control.ValveName = item.TryGetValue("Name", out var v) ? v?.ToString() : string.Empty;
                control.AdjustAI = ToUInt16(item, "AI");
                control.AdjustAQ = ToUInt16(item, "AQ");
                control.AdjustType = item.TryGetValue("Type", out var t) && t?.ToString() == "常开";
                control.AdjustFeedback = item.TryGetValue("Feedback", out var f) && f?.ToString() == "0";
                control.AdjustValveClick += AdjustValve_Click;
            }
        }

        private static ushort ToUInt16(Dictionary<string, object> dict, string key)
        {
            if (dict == null)
                return 0;

            if (!dict.TryGetValue(key, out var value) || value == null)
                return 0;

            return ushort.TryParse(value.ToString(), out var result)
                ? result
                : (ushort)0;
        }
        //气动开关阀
        private void InitializeAirControlsValve<T1, T2>(List<Dictionary<string, object>> config, List<T1> comboList, List<T2> iconList, string comboName, string iconName) where T1 : IAirControlValveBase where T2 : IAirControlValveIcon
        {
            if (config == null || config.Count == 0) return;

            for (int i = 0; i < config.Count; i++)
            {
                comboList.Add(GetControls<T1>(i + 1, comboName));
                iconList.Add(GetControls<T2>(i + 1, iconName));

                string valveNo = config[i]["Name"]?.ToString() ?? string.Empty;
                comboList[i].ValveName = valveNo;
                iconList[i].ValveName = valveNo;

                iconList[i].DiOpen = ushort.TryParse(config[i]["DIOpen"]?.ToString(), out var diOpen) ? diOpen : (ushort)0;
                iconList[i].DiClose = ushort.TryParse(config[i]["DIClose"]?.ToString(), out var diClose) ? diClose : (ushort)0;

                string dqOCStr = config[i]["DQOpenAndClose"]?.ToString();
                string diOCStr = config[i]["DIOpenAndClose"]?.ToString();
                ushort dqOpenAndClose = ushort.TryParse(dqOCStr, out var dqOC) ? dqOC : ushort.MaxValue;
                ushort diOpenAndClose = ushort.TryParse(diOCStr, out var diOC) ? diOC : ushort.MaxValue;

                if (config[i].ContainsKey("Station"))
                {
                    comboList[i].WorkStation = config[i]["Station"].ToString();
                    iconList[i].WorkStation = config[i]["Station"].ToString();
                }
                comboList[i].DiOpenAndClose = diOpenAndClose;
                iconList[i].DiOpenAndClose = diOpenAndClose;
                if (config[i]["DQOpenAndClose"] != null)
                {
                    comboList[i].DqOpenAndClose = dqOpenAndClose;
                    iconList[i].DqOpenAndClose = dqOpenAndClose;
                    iconList[i].ValveClick += MainLOValve_Click;
                    comboList[i].ValveClick += MainLOValve_Click;
                }
                else
                {
                    comboList[i].DqOpenAndClose = dqOpenAndClose;
                    comboList[i].DqOpen = ushort.TryParse(config[i]["DQOpen"]?.ToString(), out var dqOpen) ? dqOpen : (ushort)0;
                    comboList[i].DqClose = ushort.TryParse(config[i]["DQClose"]?.ToString(), out var dqClose) ? dqClose : (ushort)0;
                    iconList[i].DqOpen = comboList[i].DqOpen;
                    iconList[i].DqClose = comboList[i].DqClose;
                    iconList[i].ValveClick += Switch2Valve_Click;
                    comboList[i].ValveClick += Switch2Valve_Click;
                }


            }
        }

        private void UpdateValveFromRole<T1, T2>(List<T1> comboList, List<T2> iconList)
    where T1 : IAirControlValveBase
    where T2 : IAirControlValveIcon
        {
            if (comboList == null || iconList == null) return;

            var currentUser = UserInfo;
            string role = currentUser?.RoleType;
            bool isLogged = currentUser != null;
            InvokeIfRequired(() =>
            {
                for (int i = 0; i < comboList.Count; i++)
                {
                    if (i >= iconList.Count) break;

                    var combo = comboList[i];
                    var icon = iconList[i];

                    string station = combo.WorkStation;

                    bool shouldEnable = true;

                    if (role == "工位1" && station == "2")
                    {
                        shouldEnable = false;
                    }
                    else if (role == "工位2" && station == "1")
                    {
                        shouldEnable = false;
                    }
                    if (combo.Enable != shouldEnable)
                    {
                        combo.Enable = shouldEnable;
                    }

                    if (icon.Enable != shouldEnable)
                    {
                        icon.Enable = shouldEnable;
                    }
                }
            });
        }
        //电动开关阀
        private void InitializeElectricControlsValve<T1, T2, T3>(List<Dictionary<string, object>> config, List<T2> iconList, string comboName, string iconName, List<T1> comboList, List<T3> SolenoidList = null, string solenoidName = null) where T1 : IElectricControlValveBase where T2 : IElectricControlValveIcon where T3 : IAirControlValveBase
        {
            if (config == null || comboList == null || iconList == null)
                return;
            int index = 1;
            for (int i = 0; i < config.Count; i++)
            {
                var item = config[i];
                string valveName = item.TryGetValue("Name", out var v) ? v?.ToString() : string.Empty;
                if (item["DQOpenAndClose"] == null)
                {
                    ushort dqClose = ToUInt16(item, "DQClose");
                    ushort dqOpen = ToUInt16(item, "DQOpen");
                    var combo = GetControls<T1>(i + 1, comboName);
                    var icon = GetControls<T2>(i + 1, iconName);
                    iconList.Add(icon);
                    comboList.Add(combo);
                    icon.ValveName = combo.ValveName = valveName;
                    icon.DqClose = combo.DqClose = dqClose;
                    icon.DqOpen = combo.DqOpen = dqOpen;
                    icon.DiClose = ToUInt16(item, "DIClose");
                    icon.DiOpen = ToUInt16(item, "DIOpen");
                    icon.DiFault = ToUInt16(item, "DIFault");
                    icon.ValveClick += Switch2Valve_Click;
                    combo.ValveClick += Switch2Valve_Click;
                }
                else
                {
                    if (SolenoidList != null)
                    {
                        var solenoid = GetControls<T3>(index, solenoidName);

                        if (item["DIOpenAndClose"] != null)
                        {
                            solenoid.DiOpenAndClose = ToUInt16(item, "DIOpenAndClose");
                        }
                        else
                        {
                            solenoid.DiOpenAndClose = UInt16.MaxValue;

                        }
                        solenoid.DqOpenAndClose = ToUInt16(item, "DQOpenAndClose");
                        solenoid.ValveName = valveName;
                        SolenoidList.Add(solenoid);
                        solenoid.ValveClick += MainLOValve_Click;
                        index++;
                    }
                }

            }
        }

        #endregion

        #region 传感器通用方法
        private void InitializeSensor<T>(List<Dictionary<string, object>> config, List<T> controls, string name) where T : ISensorBase
        {
            if (config == null || controls == null) return;

            for (int i = 0; i < config.Count; i++)
            {
                var item = config[i];
                var control = GetControls<T>(i + 1, name);
                controls.Add(control);
                control.InputType = InputValueType.PLC_Digital;
                control.CurrentRange = CurrentRange.FourToTwenty;
                control.DigitalRange = 27648;
                control.SensorName = item.TryGetValue("Name", out var v) ? v?.ToString() : string.Empty;
                control.AI = item.TryGetValue("AI", out var ai) && ushort.TryParse(ai?.ToString(), out ushort aiVal) ? (ushort)(aiVal - 1) : (ushort)0;
                control.MaxSensorRange = item.TryGetValue("MaxSensorRange", out var max) && float.TryParse(max?.ToString(), out float maxVal) ? maxVal : 0;
                control.MinSensorRange = item.TryGetValue("MinSensorRange", out var min) && float.TryParse(min?.ToString(), out float minVal) ? minVal : 0;
                control.DecimalPlaces = item.TryGetValue("DecimalPlaces", out var dp) && int.TryParse(dp?.ToString(), out int dpVal) ? dpVal : 2;

                if (item.TryGetValue("Type", out var type))
                {
                    if (type.ToString() == "液位" || type.ToString() == "体积")
                    {
                        control.Unit = type.ToString() == "液位" ? Unit.m : Unit.m3_cube;
                        control.Density = item.TryGetValue("Density", out var density) && float.TryParse(density.ToString(), out float densityVal) ? densityVal : 0;
                        control.OriginalPressureUnit = item.TryGetValue("Unit", out var opu) && Enum.TryParse<Unit>(opu.ToString(), out Unit result) ? result : Unit.Pa;
                    }
                    else if (type.ToString() == "PT100")
                    {
                        control.IsPT100 = true;
                        control.Unit = item.TryGetValue("Unit", out var opu) && Enum.TryParse<Unit>(opu.ToString(), out Unit result) ? result : Unit.temp;
                    }
                    else
                    {
                        control.Unit = item.TryGetValue("Unit", out var opu) && Enum.TryParse<Unit>(opu.ToString(), out Unit result) ? result : Unit.Pa;
                    }
                }
            }
        }
        private void InitializeHighAI<T>(List<Dictionary<string, object>> config, List<T> controls, string name) where T : ISensorBase
        {
            if (config == null || controls == null) return;
            for (int i = 0; i < config.Count; i++)
            {
                var item = config[i];
                var control = GetControls<T>(i + 1, name);
                controls.Add(control);
                control.InputType = InputValueType.Current;
                control.CurrentRange = CurrentRange.FourToTwenty;
                control.SensorName = item.TryGetValue("Name", out var v) ? v?.ToString() : string.Empty;
                control.AI = item.TryGetValue("AI", out var ai) && ushort.TryParse(ai?.ToString(), out ushort aiVal) ? (ushort)(aiVal - 1) : (ushort)0;
                control.MaxSensorRange = item.TryGetValue("MaxSensorRange", out var max) && float.TryParse(max?.ToString(), out float maxVal) ? maxVal : 0;
                control.MinSensorRange = item.TryGetValue("MinSensorRange", out var min) && float.TryParse(min?.ToString(), out float minVal) ? minVal : 0;
                control.DecimalPlaces = item.TryGetValue("DecimalPlaces", out var dp) && int.TryParse(dp?.ToString(), out int dpVal) ? dpVal : 2;
                if (item.TryGetValue("Type", out var type) && item.TryGetValue("Const", out var ct))
                {
                    if (type.ToString() == "涡轮" && ct != null && float.TryParse(ct.ToString(), out float Val))
                    {
                        control.TFMState = true;
                        control.SpeedValue = Val;
                    }
                }
                control.Unit = item.TryGetValue("Unit", out var opu) && Enum.TryParse<Unit>(opu.ToString(), out Unit result) ? result : Unit.Pa;
            }
        }

        #endregion

        public UserTable UserInfo;
        public bool IsLoginOut = false;

        private void btn_User_Click(object sender, EventArgs e)
        {
            if (this.btn_User.Symbol == 560023)
            {
                if (UserInfo != null && UserInfo.RoleType == "管理员" && UserInfo.LoginName == "刘德华")
                {
                    this.IsLoginOut = false;

                    new FrmUser(this).ShowDialog();

                    if (this.IsLoginOut)
                    {
                        this.tbm_Main.Selecting -= tbm_Main_Selecting;
                        this.tbm_Main.SelectedIndex = 0;
                        this.tbm_Main.Selecting += tbm_Main_Selecting;
                        this.btn_User.Symbol = 61447;
                        this.btn_User.Text = null;

                    }
                }
                else
                {
                    DialogResult dr = new FrmMsgWithAck("请确认是否登出！", "登出确认").ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        this.IsLoginOut = true;
                        this.AddLog(0, $"用户{this.UserInfo.LoginName}登出成功！");
                        this.UserInfo = null;
                        this.tbm_Main.Selecting -= tbm_Main_Selecting;
                        this.tbm_Main.SelectedIndex = 0;
                        this.tbm_Main.Selecting += tbm_Main_Selecting;
                        this.btn_User.Symbol = 61447;
                        this.btn_User.Text = null;

                    }
                    else
                    {
                        this.IsLoginOut = false;
                        return;
                    }
                }
            }
            else
            {
                DialogResult dr = new FrmLogin(this).ShowDialog();
                if (dr == DialogResult.OK)
                {
                    this.btn_User.Symbol = 560023;
                    this.btn_User.Text = UserInfo.LoginName;
                    UpdateValveFromRole(FiringISwitchCombo, FiringISwitchIcon);
                    UpdateValveFromRole(FiringIISwitchCombo, FiringIISwitchIcon);
                    if (UserInfo.RoleType == "工位1")
                    {
                        this.firingIIAdjustValve1.Enabled = false;
                        firingIAdjustValve1.Enabled = true;
                        this.button35.Enabled = false;
                        button76.Enabled = true;
                    }
                    else if (UserInfo.RoleType == "工位2")
                    {
                        this.firingIIAdjustValve1.Enabled = true;
                        firingIAdjustValve1.Enabled = false;
                        this.button35.Enabled = true;
                        button76.Enabled = false;
                    }
                    else
                    {
                        this.firingIIAdjustValve1.Enabled = true;
                        firingIAdjustValve1.Enabled = true;
                        this.button35.Enabled = true;
                        button76.Enabled = true;
                    }
                    AddLog(0, $"用户{UserInfo.LoginName}登入成功！");
                }
            }
        }

        private void tbm_Main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (UserInfo != null)
            {
                if (UserInfo.RoleType == "工位1")
                {
                    if (e.TabPage.Text == "煤油系统")
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else if (UserInfo.RoleType == "工位2")
                {
                    if (e.TabPage.Text == "甲烷系统")
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else
            {
                e.Cancel = true;
                new FrmMsgNoAck($"请先登陆账号！", "权限确认").ShowDialog();
                return;
            }
        }

        private void btn_TimerValve_Click(object sender, EventArgs e)
        {
            if (!CheckUserLogin()) return;

            List<string> allValveNames = new List<string>();

            void ExtractNames(List<Dictionary<string, object>> configList)
            {
                if (configList == null) return;
                foreach (var dict in configList)
                {
                    if (dict["DQOpenAndClose"] == null) continue;
                    if (dict.ContainsKey("Name") && dict["Name"] != null)
                    {
                        string name = dict["Name"].ToString().Trim();
                        if (!string.IsNullOrEmpty(name))
                        {
                            allValveNames.Add(name);
                        }
                    }
                }
            }
            ExtractNames(FuelArea_SwitchValve);
            ExtractNames(FiringI_SwitchValve);
            ExtractNames(FiringII_SwitchValve);

            allValveNames = allValveNames.Distinct().OrderBy(x => x).ToList();

            if (allValveNames.Count == 0)
            {
                MessageBox.Show("配置表中未读取到任何阀门！", "提示");
                return;
            }

            FrmMultiTimedValve timedForm = new FrmMultiTimedValve(allValveNames, GetValveInfoByName);

            timedForm.AddLog += AddLog;

            timedForm.Show();
            timedForm.BringToFront();
        }

    }
}



