namespace ProcessSystem
{
    partial class LocalLock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_InitValue1 = new System.Windows.Forms.TextBox();
            this.btn_Set = new Sunny.UI.UISymbolButton();
            this.lb_SensorSetName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.LockState = new Sunny.UI.UISwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_InitValue2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_InitValue3 = new System.Windows.Forms.TextBox();
            this.lbl_OwnerInfo = new System.Windows.Forms.Label();
            this.btn_TakeOver = new Sunny.UI.UISymbolButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_InitValue1
            // 
            this.tb_InitValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_InitValue1.Location = new System.Drawing.Point(159, 71);
            this.tb_InitValue1.Name = "tb_InitValue1";
            this.tb_InitValue1.Size = new System.Drawing.Size(70, 29);
            this.tb_InitValue1.TabIndex = 23;
            this.tb_InitValue1.Text = " ";
            this.tb_InitValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Set
            // 
            this.btn_Set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Set.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Location = new System.Drawing.Point(197, 232);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Set.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(70, 34);
            this.btn_Set.Symbol = 61459;
            this.btn_Set.TabIndex = 20;
            this.btn_Set.Text = "设定";
            this.btn_Set.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // lb_SensorSetName
            // 
            this.lb_SensorSetName.AutoSize = true;
            this.lb_SensorSetName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SensorSetName.Location = new System.Drawing.Point(12, 75);
            this.lb_SensorSetName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_SensorSetName.Name = "lb_SensorSetName";
            this.lb_SensorSetName.Size = new System.Drawing.Size(141, 21);
            this.lb_SensorSetName.TabIndex = 21;
            this.lb_SensorSetName.Text = "PT226高限设定 ：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.uiSymbolButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 44);
            this.panel1.TabIndex = 30;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ForeHoverColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.ForePressColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.ForeSelectedColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.Location = new System.Drawing.Point(232, 0);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Size = new System.Drawing.Size(50, 44);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 558829;
            this.uiSymbolButton1.SymbolHoverColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.SymbolPressColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.SymbolSelectedColor = System.Drawing.Color.Red;
            this.uiSymbolButton1.SymbolSize = 30;
            this.uiSymbolButton1.TabIndex = 429;
            this.uiSymbolButton1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.TipsForeColor = System.Drawing.Color.Black;
            this.uiSymbolButton1.TipsText = "退出程序";
            this.uiSymbolButton1.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // LockState
            // 
            this.LockState.ActiveText = "自动";
            this.LockState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LockState.InActiveText = "手动";
            this.LockState.Location = new System.Drawing.Point(16, 237);
            this.LockState.MinimumSize = new System.Drawing.Size(1, 1);
            this.LockState.Name = "LockState";
            this.LockState.Size = new System.Drawing.Size(70, 29);
            this.LockState.TabIndex = 31;
            this.LockState.Text = "uiSwitch1";
            this.LockState.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.LockState_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(229, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mpa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "PT226中限设定 ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(229, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Mpa";
            // 
            // tb_InitValue2
            // 
            this.tb_InitValue2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_InitValue2.Location = new System.Drawing.Point(159, 124);
            this.tb_InitValue2.Name = "tb_InitValue2";
            this.tb_InitValue2.Size = new System.Drawing.Size(70, 29);
            this.tb_InitValue2.TabIndex = 23;
            this.tb_InitValue2.Text = " ";
            this.tb_InitValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "PT226底限设定 ：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(229, 189);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mpa";
            // 
            // tb_InitValue3
            // 
            this.tb_InitValue3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_InitValue3.Location = new System.Drawing.Point(159, 177);
            this.tb_InitValue3.Name = "tb_InitValue3";
            this.tb_InitValue3.Size = new System.Drawing.Size(70, 29);
            this.tb_InitValue3.TabIndex = 23;
            this.tb_InitValue3.Text = " ";
            this.tb_InitValue3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_OwnerInfo
            // 
            this.lbl_OwnerInfo.AutoSize = true;
            this.lbl_OwnerInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OwnerInfo.ForeColor = System.Drawing.Color.Gray;
            this.lbl_OwnerInfo.Location = new System.Drawing.Point(12, 280);
            this.lbl_OwnerInfo.Name = "lbl_OwnerInfo";
            this.lbl_OwnerInfo.Size = new System.Drawing.Size(75, 17);
            this.lbl_OwnerInfo.TabIndex = 32;
            this.lbl_OwnerInfo.Text = "当前控制: 无";
            this.lbl_OwnerInfo.Visible = false;
            // 
            // btn_TakeOver
            // 
            this.btn_TakeOver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TakeOver.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TakeOver.Location = new System.Drawing.Point(197, 275);
            this.btn_TakeOver.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_TakeOver.Name = "btn_TakeOver";
            this.btn_TakeOver.Size = new System.Drawing.Size(70, 28);
            this.btn_TakeOver.Symbol = 61473;
            this.btn_TakeOver.TabIndex = 33;
            this.btn_TakeOver.Text = "接管";
            this.btn_TakeOver.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TakeOver.Visible = false;
            this.btn_TakeOver.Click += new System.EventHandler(this.btn_TakeOver_Click);
            // 
            // LocalLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 315);
            this.Controls.Add(this.btn_TakeOver);
            this.Controls.Add(this.lbl_OwnerInfo);
            this.Controls.Add(this.LockState);
            this.Controls.Add(this.tb_InitValue3);
            this.Controls.Add(this.tb_InitValue2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_InitValue1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_SensorSetName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LocalLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LockNew";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // --- 需要在最后补充声明变量 ---
        private System.Windows.Forms.Label lbl_OwnerInfo;
        private Sunny.UI.UISymbolButton btn_TakeOver;

        #endregion
        private System.Windows.Forms.TextBox tb_InitValue1;
        private Sunny.UI.UISymbolButton btn_Set;
        private System.Windows.Forms.Label lb_SensorSetName;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISwitch LockState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_InitValue2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_InitValue3;
    }
}