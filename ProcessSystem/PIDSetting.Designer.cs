namespace ProcessSystem
{
    partial class PIDSetting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ValveName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Label();
            this.label353 = new System.Windows.Forms.Label();
            this.tb_PressureSet = new System.Windows.Forms.TextBox();
            this.label375 = new System.Windows.Forms.Label();
            this.PIDAuto = new Sunny.UI.UISwitch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Kd = new System.Windows.Forms.TextBox();
            this.Ki = new System.Windows.Forms.TextBox();
            this.Kp = new System.Windows.Forms.TextBox();
            this.label378 = new System.Windows.Forms.Label();
            this.label377 = new System.Windows.Forms.Label();
            this.label376 = new System.Windows.Forms.Label();
            this.pl_Sensor = new System.Windows.Forms.Panel();
            this.cb_SelectSensor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Set = new Sunny.UI.UISymbolButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pl_Sensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.ValveName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 52);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // ValveName
            // 
            this.ValveName.AutoSize = true;
            this.ValveName.ForeColor = System.Drawing.Color.White;
            this.ValveName.Location = new System.Drawing.Point(71, 16);
            this.ValveName.Name = "ValveName";
            this.ValveName.Size = new System.Drawing.Size(60, 21);
            this.ValveName.TabIndex = 2;
            this.ValveName.Text = "#####";
            this.ValveName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.ValveName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(136, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "PID设定";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(234, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 52);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label353
            // 
            this.label353.Location = new System.Drawing.Point(5, 69);
            this.label353.Name = "label353";
            this.label353.Size = new System.Drawing.Size(83, 21);
            this.label353.TabIndex = 1;
            this.label353.Text = "设定压力 :";
            // 
            // tb_PressureSet
            // 
            this.tb_PressureSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PressureSet.Location = new System.Drawing.Point(117, 67);
            this.tb_PressureSet.Name = "tb_PressureSet";
            this.tb_PressureSet.Size = new System.Drawing.Size(75, 29);
            this.tb_PressureSet.TabIndex = 0;
            this.tb_PressureSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label375
            // 
            this.label375.Location = new System.Drawing.Point(198, 69);
            this.label375.Name = "label375";
            this.label375.Size = new System.Drawing.Size(56, 21);
            this.label375.TabIndex = 4;
            this.label375.Text = "Mpa";
            // 
            // PIDAuto
            // 
            this.PIDAuto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PIDAuto.Location = new System.Drawing.Point(9, 314);
            this.PIDAuto.MinimumSize = new System.Drawing.Size(1, 1);
            this.PIDAuto.Name = "PIDAuto";
            this.PIDAuto.Size = new System.Drawing.Size(75, 29);
            this.PIDAuto.TabIndex = 7;
            this.PIDAuto.Text = "uiSwitch1";
            this.PIDAuto.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.PIDAuto_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Kd);
            this.groupBox1.Controls.Add(this.Ki);
            this.groupBox1.Controls.Add(this.Kp);
            this.groupBox1.Controls.Add(this.label378);
            this.groupBox1.Controls.Add(this.label377);
            this.groupBox1.Controls.Add(this.label376);
            this.groupBox1.Location = new System.Drawing.Point(9, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 89);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PID";
            // 
            // Kd
            // 
            this.Kd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Kd.Location = new System.Drawing.Point(228, 39);
            this.Kd.Name = "Kd";
            this.Kd.Size = new System.Drawing.Size(40, 29);
            this.Kd.TabIndex = 11;
            this.Kd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ki
            // 
            this.Ki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ki.Location = new System.Drawing.Point(138, 39);
            this.Ki.Name = "Ki";
            this.Ki.Size = new System.Drawing.Size(40, 29);
            this.Ki.TabIndex = 12;
            this.Ki.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Kp
            // 
            this.Kp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Kp.Location = new System.Drawing.Point(48, 39);
            this.Kp.Name = "Kp";
            this.Kp.Size = new System.Drawing.Size(40, 29);
            this.Kp.TabIndex = 13;
            this.Kp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label378
            // 
            this.label378.Location = new System.Drawing.Point(6, 41);
            this.label378.Name = "label378";
            this.label378.Size = new System.Drawing.Size(55, 21);
            this.label378.TabIndex = 10;
            this.label378.Text = "Kp ：";
            // 
            // label377
            // 
            this.label377.Location = new System.Drawing.Point(103, 41);
            this.label377.Name = "label377";
            this.label377.Size = new System.Drawing.Size(46, 21);
            this.label377.TabIndex = 9;
            this.label377.Text = "Ki ：";
            // 
            // label376
            // 
            this.label376.Location = new System.Drawing.Point(191, 41);
            this.label376.Name = "label376";
            this.label376.Size = new System.Drawing.Size(46, 21);
            this.label376.TabIndex = 8;
            this.label376.Text = "Kd：";
            // 
            // pl_Sensor
            // 
            this.pl_Sensor.Controls.Add(this.cb_SelectSensor);
            this.pl_Sensor.Controls.Add(this.label1);
            this.pl_Sensor.Location = new System.Drawing.Point(2, 158);
            this.pl_Sensor.Name = "pl_Sensor";
            this.pl_Sensor.Size = new System.Drawing.Size(397, 37);
            this.pl_Sensor.TabIndex = 17;
            this.pl_Sensor.Visible = false;
            // 
            // cb_SelectSensor
            // 
            this.cb_SelectSensor.FormattingEnabled = true;
            this.cb_SelectSensor.Location = new System.Drawing.Point(115, 3);
            this.cb_SelectSensor.Name = "cb_SelectSensor";
            this.cb_SelectSensor.Size = new System.Drawing.Size(137, 29);
            this.cb_SelectSensor.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "传感器设定 :";
            // 
            // btn_Set
            // 
            this.btn_Set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Set.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Location = new System.Drawing.Point(207, 309);
            this.btn_Set.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Set.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(70, 34);
            this.btn_Set.Symbol = 61459;
            this.btn_Set.TabIndex = 21;
            this.btn_Set.Text = "设定";
            this.btn_Set.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // PIDSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 358);
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.pl_Sensor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PIDAuto);
            this.Controls.Add(this.tb_PressureSet);
            this.Controls.Add(this.label375);
            this.Controls.Add(this.label353);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PIDSetting";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PIDSetting";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pl_Sensor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ValveName;
        private System.Windows.Forms.Label label353;
        private System.Windows.Forms.TextBox tb_PressureSet;
        private System.Windows.Forms.Label label375;
        private Sunny.UI.UISwitch PIDAuto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label378;
        private System.Windows.Forms.Label label377;
        private System.Windows.Forms.TextBox Kd;
        private System.Windows.Forms.Label label376;
        private System.Windows.Forms.TextBox Ki;
        private System.Windows.Forms.TextBox Kp;
        private System.Windows.Forms.Panel pl_Sensor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_SelectSensor;
        private Sunny.UI.UISymbolButton btn_Set;
    }
}