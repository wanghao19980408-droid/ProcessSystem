using NodeSettings;
using ProcessSystemLib;
using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xbd.ControlLib;

namespace ProcessSystem
{


    public partial class FormSequenceSettings : Form
    {
        private BindingList<PressureStage>  StageList = new BindingList<PressureStage>();

        private PressureStageService PressureStageService = new PressureStageService();

        private PressureSettingType CurrentSettingType;

        private FormMain FormMain;

        private TCPManager TCPManager;

        private SiemensDevice Device;
        public FormSequenceSettings(PressureSettingType settingType, FormMain formMain)
        {
            InitializeComponent();
            CurrentSettingType = settingType;
            FormMain = formMain;
            if (CurrentSettingType == PressureSettingType.OneOxygen)
            {
                labelTitle.Text = "工位1氧箱自动调节时序设置";
                TCPManager = FormMain.FiringITCPManager;
                Device = formMain.Firing1Device;
            }
            
            else if (CurrentSettingType == PressureSettingType.TwoOxygen)
            {
                labelTitle.Text = "工位2氧箱自动调节时序设置";
                TCPManager = FormMain.FiringIITCPManager;
                Device = formMain.Firing2Device;

            }
            else if (CurrentSettingType == PressureSettingType.Methane)
            {
                labelTitle.Text = "燃箱(甲烷)自动调节时序设置";
                TCPManager = FormMain.FuelAreaTCPManager;
                Device = formMain.FuelDevice;

            }
            else if (CurrentSettingType == PressureSettingType.Kerosene)
            {
                labelTitle.Text = "燃箱(煤油)自动调节时序设置";
                TCPManager = FormMain.FuelAreaTCPManager;
                Device = formMain.FuelDevice;
            }

            LoadDataFromDatabase();
            bool isSequenceActive = Convert.ToBoolean(Device["Sequence"]);
            if (isSequenceActive)
            {
                this.btnSetting.Text = "停用自动时序";
                this.btnSetting.FillColor = Color.Red;
                this.btnSetting.Symbol = 61534;
            }
            else
            {
                this.btnSetting.Text = "启用自动时序";
                this.btnSetting.FillColor = Color.SeaGreen;
                this.btnSetting.Symbol = 61515;
            }
            InitGrid();
        }
        private void LoadDataFromDatabase()
        {
            var result = PressureStageService.QueryPressureSetting(CurrentSettingType);

            if (result.IsSuccess && result.Content != null && result.Content.StageList != null)
            {
                StageList = result.Content.StageList;
            }
            else
            {
                StageList = new BindingList<PressureStage>();

            }
        }
        private void InitGrid()
        {
            dgvSequence.DataSource = StageList;
            dgvSequence.ReadOnly = false;
            dgvSequence.AllowUserToAddRows = false;
            dgvSequence.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSequence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvSequence.Columns["StepId"] != null)
            {
                dgvSequence.Columns["StepId"].ReadOnly = true;
                dgvSequence.Columns["StepId"].FillWeight = 10;
            }
            if (dgvSequence.Columns["StartTime"] != null) dgvSequence.Columns["StartTime"].FillWeight = 20;
            if (dgvSequence.Columns["EndTime"] != null) dgvSequence.Columns["EndTime"].FillWeight = 20;

            if (dgvSequence.Columns["TargetPressure"] != null)
            {
                if (CurrentSettingType == PressureSettingType.OneOxygen)
                    dgvSequence.Columns["TargetPressure"].HeaderText = "工位1氧箱压力(MPa)";
                else if (CurrentSettingType == PressureSettingType.TwoOxygen)
                    dgvSequence.Columns["TargetPressure"].HeaderText = "工位2氧箱压力(MPa)";
                else if (CurrentSettingType == PressureSettingType.Methane)
                    dgvSequence.Columns["TargetPressure"].HeaderText = "甲烷压力(MPa)";
                else
                    dgvSequence.Columns["TargetPressure"].HeaderText = "煤油压力(MPa)";

                dgvSequence.Columns["TargetPressure"].FillWeight = 25;
            }

            if (dgvSequence.Columns["TimeRange"] != null)
            {
                dgvSequence.Columns["TimeRange"].ReadOnly = true;
                dgvSequence.Columns["TimeRange"].FillWeight = 25;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int nextStepId = StageList.Count > 0 ? StageList.Count + 1 : 1;
            int lastEndTime = StageList.Count > 0 ? StageList[StageList.Count - 1].EndTime : 0;

            StageList.Add(new PressureStage
            {
                StepId = nextStepId,
                StartTime = lastEndTime,
                EndTime = lastEndTime + 50,
                TargetPressure = 0.5
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSequence.CurrentRow != null && dgvSequence.CurrentRow.Index >= 0)
            {
                int selectedIndex = dgvSequence.CurrentRow.Index;
                StageList.RemoveAt(selectedIndex);
                ReindexStages();
            }
            else
            {
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请先在表格中选中要删除的行！", "提示");
                frmMsg.ShowDialog();
            }
        }

        private void ReindexStages()
        {
            for (int i = 0; i < StageList.Count; i++)
            {
                StageList[i].StepId = i + 1;
            }
            dgvSequence.Refresh();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            var stagesToPLC = StageList.ToList();
            if (stagesToPLC.Count == 0)
            {
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请至少设置一个阶段！", "提示");
                frmMsg.ShowDialog();
                return;
            }
            var result = TCPManager.Send_PLC_Command(
                cmd: (byte)CMD.pressurization_command,
                lockIndex: (byte)CurrentSettingType,
                pressurizationValue: stagesToPLC
            );
            if (result.IsSuccess)
            {
                var saveResult = PressureStageService.UpdatePressureSetting(StageList, CurrentSettingType);

                if (saveResult.IsSuccess)
                {
                    string msgType = CurrentSettingType == PressureSettingType.OneOxygen ? "工位1氧箱" :
                                     (CurrentSettingType == PressureSettingType.TwoOxygen ? "工位2氧箱" :
                                     (CurrentSettingType == PressureSettingType.Methane ? "甲烷" : "煤油"));
                    FormMain.AddLog(0, $"{msgType}时序设置已成功保存！");
                    FrmMsgNoAck frmMsgSuccess = new FrmMsgNoAck($"{msgType}时序设置已成功保存！", "保存成功");
                    frmMsgSuccess.ShowDialog();

                }
                else
                {
                    FormMain.AddLog(2, $"下发成功，但数据库保存失败：{saveResult.Message}");
                    FrmMsgNoAck frmMsgFail = new FrmMsgNoAck($"下发成功，但数据库保存失败：{saveResult.Message}", "数据库错误");
                    frmMsgFail.ShowDialog();
                }
            }
            else
            {
                FormMain.AddLog(2, $"下发失败：{result.Message}");
                FrmMsgNoAck frmMsgFail = new FrmMsgNoAck($"下发失败：{result.Message}", "通信错误");
                frmMsgFail.ShowDialog();
            }
        }

        private void btn_CLose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var stagesToPLC = StageList.ToList();
            if (stagesToPLC.Count == 0)
            {
                FormMain.AddLog(2, "请至少设置一个阶段！");
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请至少设置一个阶段！", "提示");
                frmMsg.ShowDialog();
                return;
            }

            if (btnSetting.Text == "启用自动时序")
            {
                var res = Device.Write("Sequence", "1");
                if (res.IsSuccess)
                {
                    btnSetting.Text = "停用自动时序";
                    btnSetting.FillColor = Color.Red;
                    this.btnSetting.Symbol = 61534;
                    FormMain.AddLog(0, "时序已成功启用！");
                }
                else
                {
                    FormMain.AddLog(2, $"时序启用失败：{res.Message}");
                    FrmMsgNoAck frmMsgFail = new FrmMsgNoAck($"启用失败：{res.Message}", "通信错误");
                    frmMsgFail.ShowDialog();
                }
            }
            else
            {
                var res = Device.Write("Sequence", "0");
                if (res.IsSuccess)
                {
                    btnSetting.Text = "启用自动时序";
                    btnSetting.FillColor = Color.SeaGreen;
                    this.btnSetting.Symbol = 61515;
                    FormMain.AddLog(0, "时序已成功停用！");
                }
                else
                {
                    FormMain.AddLog(2, $"时序停用失败：{res.Message}");
                    FrmMsgNoAck frmMsgFail = new FrmMsgNoAck($"停用失败：{res.Message}", "通信错误");
                    frmMsgFail.ShowDialog();
                }
            }
        }
    }

}  