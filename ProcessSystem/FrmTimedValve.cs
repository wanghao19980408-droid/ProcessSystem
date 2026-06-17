using ProcessSystemLib;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI; 

namespace ProcessSystem
{
    public partial class FrmMultiTimedValve : UIForm
    {
        private Func<string, (ushort dq, TCPManager tcp, bool found)> _getValveInfo;
        public Action<int, string> AddLog;

        private CancellationTokenSource _cts;

        public FrmMultiTimedValve(List<string> allValveNames, Func<string, (ushort dq, TCPManager tcp, bool found)> getValveInfoDelegate)
        {
            InitializeComponent();

            this.ZoomScaleDisabled = true;

            _getValveInfo = getValveInfoDelegate;

            colValveName.Items.AddRange(allValveNames.ToArray());

            this.FormClosing += FrmMultiTimedValve_FormClosing;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            int index = dgvValves.Rows.Add();
            DataGridViewRow row = dgvValves.Rows[index];

            if (colValveName.Items.Count > 0)
                row.Cells["colValveName"].Value = colValveName.Items[0];

            row.Cells["colAction"].Value = "开启";
            row.Cells["colDuration"].Value = "10";
            row.Cells["colStatus"].Value = "等待启动";
        }

        private void dgvValves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colOperate.Index && e.RowIndex >= 0)
            {
                if (_cts != null && !_cts.IsCancellationRequested)
                {
                    FrmMsgNoAck frmMsg = new FrmMsgNoAck("任务正在执行中，无法删除行！", "提示");
                    frmMsg.ShowDialog();
                    return;
                }
                dgvValves.Rows.RemoveAt(e.RowIndex);
            }
        }

        private async void btnStartAll_Click(object sender, EventArgs e)
        {
            if (dgvValves.Rows.Count == 0)
            {
                FrmMsgNoAck frmMsg = new FrmMsgNoAck("请先添加需要操作的阀门！", "提示");
                frmMsg.ShowDialog();
                return;
            }

            btnStartAll.Enabled = false;
            btnAddRow.Enabled = false;
            dgvValves.ReadOnly = true;
            btnStopAll.Enabled = true;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            bool isSequential = rbSequential.Checked;
            string modeStr = isSequential ? "顺序" : "同步";

            AddLog?.Invoke(0, $"--- 开始批量执行 {dgvValves.Rows.Count} 个阀门的定时任务 ({modeStr}执行) ---");

            try
            {
                if (isSequential)
                {
                    foreach (DataGridViewRow row in dgvValves.Rows)
                    {
                        if (row.IsNewRow) continue;

                        await ProcessRowAsync(row, token);

                        if (token.IsCancellationRequested) break;
                    }
                }
                else
                {
                    List<Task> tasks = new List<Task>();
                    foreach (DataGridViewRow row in dgvValves.Rows)
                    {
                        if (row.IsNewRow) continue;
                        tasks.Add(ProcessRowAsync(row, token));
                    }
                    await Task.WhenAll(tasks);
                }

                if (!token.IsCancellationRequested)
                {
                    AddLog?.Invoke(0, $"--- 批量定时任务执行结束 ---");
                    FrmMsgNoAck frmMsg = new FrmMsgNoAck("所有阀门定时动作执行完毕！", "提示");
                    frmMsg.ShowDialog();
                }
                else
                {
                    AddLog?.Invoke(0, $"--- 批量定时任务已人工终止 ---");
                }
            }
            catch (Exception ex)
            {
                AddLog?.Invoke(1, $"批量执行任务发生异常: {ex.Message}");
                FrmMsgNoAck frmMsg = new FrmMsgNoAck($"执行期间发生错误: {ex.Message}", "提示");
                frmMsg.ShowDialog();
            }
            finally
            {
                btnStartAll.Enabled = true;
                btnAddRow.Enabled = true;
                dgvValves.ReadOnly = false;
                btnStopAll.Enabled = false;

                _cts?.Dispose();
                _cts = null;
            }
        }

        private async Task ProcessRowAsync(DataGridViewRow row, CancellationToken token)
        {
            string valveName = row.Cells["colValveName"].Value?.ToString();
            string actionStr = row.Cells["colAction"].Value?.ToString();
            string durationStr = row.Cells["colDuration"].Value?.ToString();

            if (string.IsNullOrEmpty(valveName) || string.IsNullOrEmpty(actionStr) || !int.TryParse(durationStr, out int duration) || duration <= 0)
            {
                row.Cells["colStatus"].Value = "参数无效，跳过";
                return;
            }

            var vInfo = _getValveInfo(valveName);
            if (!vInfo.found || vInfo.tcp == null || !vInfo.tcp.IsConnected)
            {
                row.Cells["colStatus"].Value = "PLC断开或未找到";
                AddLog?.Invoke(1, $"[{valveName}] 执行失败：PLC未连接或配置错误");
                return;
            }

            bool isTargetOpen = (actionStr == "开启");
            string targetActionName = isTargetOpen ? "开启" : "关闭";
            string revertActionName = isTargetOpen ? "关闭" : "开启";

            try
            {
                row.Cells["colStatus"].Value = $"已{targetActionName}，倒计时 {duration}s";
                vInfo.tcp.Send_PLC_Command(1, vInfo.dq, isTargetOpen);

                await Task.Delay(duration * 1000, token);

                row.Cells["colStatus"].Value = $"完成，已复位({revertActionName})";
                vInfo.tcp.Send_PLC_Command(1, vInfo.dq, !isTargetOpen);
            }
            catch (TaskCanceledException)
            {
                row.Cells["colStatus"].Value = $"中止，紧急复位({revertActionName})";
                vInfo.tcp.Send_PLC_Command(1, vInfo.dq, !isTargetOpen);
            }
            catch (Exception ex)
            {
                row.Cells["colStatus"].Value = "执行异常";
                AddLog?.Invoke(1, $"[{valveName}] 运行期间发生异常: {ex.Message}");
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private void FrmMultiTimedValve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }
    }
}