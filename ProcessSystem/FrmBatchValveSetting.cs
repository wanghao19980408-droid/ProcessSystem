using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sunny.UI;

namespace ProcessSystem
{
    public partial class FrmBatchValveSetting : UIForm
    {
        private UIComboBox cmbValve;
        private UITextBox txtTotalMinutes;
        private UITextBox txtOpenSeconds;
        private UITextBox txtCloseSeconds;
        private UIButton btnOK;
        private UIButton btnCancel;

        public string SelectedValve => cmbValve.SelectedItem?.ToString();
        public int TotalMinutes => txtTotalMinutes.Text.ToInt();
        public int OpenDuration => txtOpenSeconds.Text.ToInt();
        public int CloseDuration => txtCloseSeconds.Text.ToInt();

        public FrmBatchValveSetting(List<string> valves)
        {
            this.Text = "阀门批量循环设置";
            this.Size = new Size(380, 380);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowRadius = true;

            InitControls(valves);
        }

        private void InitControls(List<string> valves)
        {
            int startY = 50;
            int stepY = 55;

            this.Controls.Add(new UILabel { Text = "操作阀门:", Location = new Point(30, startY), Size = new Size(130, 30) });
            cmbValve = new UIComboBox { Location = new Point(170, startY), Size = new Size(160, 30), DropDownStyle = UIDropDownStyle.DropDownList };
            cmbValve.Items.AddRange(valves.ToArray());
            if (cmbValve.Items.Count > 0) cmbValve.SelectedIndex = 0;
            this.Controls.Add(cmbValve);

            startY += stepY;
            this.Controls.Add(new UILabel { Text = "总时长(分钟):", Location = new Point(30, startY), Size = new Size(130, 30) });
            txtTotalMinutes = new UITextBox { Text = "300", Location = new Point(170, startY), Size = new Size(160, 30) };
            this.Controls.Add(txtTotalMinutes);

            startY += stepY;
            this.Controls.Add(new UILabel { Text = "开阀时间(秒):", Location = new Point(30, startY), Size = new Size(130, 30) });
            txtOpenSeconds = new UITextBox { Text = "200", Location = new Point(170, startY), Size = new Size(160, 30) };
            this.Controls.Add(txtOpenSeconds);

            startY += stepY;
            this.Controls.Add(new UILabel { Text = "关阀时间(秒):", Location = new Point(30, startY), Size = new Size(130, 30) });
            txtCloseSeconds = new UITextBox { Text = "80", Location = new Point(170, startY), Size = new Size(160, 30) };
            this.Controls.Add(txtCloseSeconds);

            startY += 70;
            btnOK = new UIButton { Text = "确定生成", Location = new Point(60, startY), Size = new Size(100, 35) };
            btnOK.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(btnOK);

            btnCancel = new UIButton { Text = "取消", FillColor = Color.Gray, Location = new Point(200, startY), Size = new Size(100, 35) };
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }
    }
}