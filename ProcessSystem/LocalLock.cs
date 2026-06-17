using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class LocalLock : Form
    {
        #region 字段

        public Action<int, string> AddLog;

        private readonly string sensorName;
        private readonly LockDataService lockDataService = new LockDataService();

        private LockModel lockModel;

        #endregion

        #region ctor

        public LocalLock(string sensorName)
        {
            InitializeComponent();
            this.sensorName = sensorName;
            Load += LockSetting_Load;
        }

        #endregion

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

        #region Load

        private async void LockSetting_Load(object sender, EventArgs e)
        {
            var res = await Task.Run(() => lockDataService.QueryLockValue(sensorName));
            if (!res.IsSuccess)
            {
                AddLog(1, $"{sensorName}联锁参数读取失败");
                Close();
                return;
            }

            lockModel = res.Content;
            BindToUI(lockModel);
        }

        private void BindToUI(LockModel model)
        {
            lb_SensorSetName.Text = $"{sensorName}高限设定 ：";
            label2.Text = $"{sensorName}中限设定 ：";
            label4.Text = $"{sensorName}底限设定 ：";

            tb_InitValue1.Text = model.AlarmHigh.ToString();
            tb_InitValue2.Text = model.AlarmMid.ToString();
            tb_InitValue3.Text = model.AlarmLow.ToString();

            LockState.ValueChanged -= LockState_ValueChanged;
            LockState.Active = model.IsLocked;
            LockState.ValueChanged += LockState_ValueChanged;

            RefreshOwnerUI();
        }
        private void RefreshOwnerUI()
        {
            if (lockModel.IsLocked)
            {
                lbl_OwnerInfo.Visible = true;
                string owner = string.IsNullOrEmpty(lockModel.LockOwner) ? "未知" : lockModel.LockOwner;

                if (owner == Environment.MachineName)
                {
                    lbl_OwnerInfo.Text = "当前控制: 本机";
                    lbl_OwnerInfo.ForeColor = System.Drawing.Color.Green;
                    btn_TakeOver.Visible = false; 
                }
                else
                {
                    lbl_OwnerInfo.Text = $"当前控制: {owner}";
                    lbl_OwnerInfo.ForeColor = System.Drawing.Color.Red;
                    btn_TakeOver.Visible = true; 
                }
            }
            else
            {
                lbl_OwnerInfo.Visible = false;
                btn_TakeOver.Visible = false;
            }
        }
        #endregion

        #region Close

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Set

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (!TryParseLimit(out float high, out float mid, out float low))
                return;

            if (!HasValueChanged(high, mid, low))
            {
                AddLog(2, $"{sensorName}联锁参数未发生变化");
                return;
            }

            lockModel.AlarmHigh = high;
            lockModel.AlarmMid = mid;
            lockModel.AlarmLow = low;

            var res = lockDataService.UpdateLockValue(lockModel);
            if (!res.IsSuccess)
            {
                AddLog(1, $"{sensorName}联锁参数设定失败");
                return;
            }

           AddLog(0,$"{sensorName}联锁设定成功：高 {high}MPa，中 {mid}MPa，低 {low}MPa");
        }

        private bool TryParseLimit(out float high, out float mid, out float low)
        {
            high = mid = low = 0f;   

            if (!float.TryParse(tb_InitValue1.Text, out high))
            {
                AddLog(1, "高限输入格式错误");
                return false;
            }

            if (!float.TryParse(tb_InitValue2.Text, out mid))
            {
                AddLog(1, "中限输入格式错误");
                return false;
            }

            if (!float.TryParse(tb_InitValue3.Text, out low))
            {
                AddLog(1, "低限输入格式错误");
                return false;
            }

            return true;
        }


        private bool HasValueChanged(float high, float mid, float low)
        {
            return Math.Abs(lockModel.AlarmHigh - high) > 0.0001f
                || Math.Abs(lockModel.AlarmMid - mid) > 0.0001f
                || Math.Abs(lockModel.AlarmLow - low) > 0.0001f;
        }

        #endregion

        #region LockState

        private void LockState_ValueChanged(object sender, bool value)
        {
            lockModel.IsLocked = value;
            lockModel.LockOwner = value ? Environment.MachineName : null;

            var res = lockDataService.UpdateLockValue(lockModel);
            if (!res.IsSuccess)
            {
                AddLog(1, $"{sensorName}联锁模式切换失败");
                LockState.ValueChanged -= LockState_ValueChanged;
                LockState.Active = !value;
                LockState.ValueChanged += LockState_ValueChanged;
                return;
            }

            string action = value ? "自动模式" : "手动模式";
            AddLog(0, $"{sensorName}联锁模式切换为{action}");

            RefreshOwnerUI();
        }
        private void btn_TakeOver_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show($"当前联锁由 [{lockModel.LockOwner}] 控制。\n强行接管可能会导致对方失去控制权。\n\n确认要强制接管吗？",
                "安全警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                lockModel.LockOwner = Environment.MachineName;
                var res = lockDataService.UpdateLockValue(lockModel);

                if (res.IsSuccess)
                {
                    AddLog(0, $"{sensorName} 联锁已成功强制接管到本机");
                    RefreshOwnerUI();
                }
                else
                {
                    AddLog(1, $"{sensorName} 接管失败: {res.Message}");
                }
            }
        }
        #endregion
    }
}
