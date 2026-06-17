namespace ProcessSystem
{
    partial class Fuelicing
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
            this.components = new System.ComponentModel.Container();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_One = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lt_Gy = new Sunny.UI.UILight();
            this.lt_Jr2 = new Sunny.UI.UILight();
            this.lt_Jr1 = new Sunny.UI.UILight();
            this.lt_Ys2 = new Sunny.UI.UILight();
            this.lt_Ys1 = new Sunny.UI.UILight();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.lt_Btj = new Sunny.UI.UILight();
            this.label6 = new System.Windows.Forms.Label();
            this.lt_Tj2 = new Sunny.UI.UILight();
            this.label7 = new System.Windows.Forms.Label();
            this.lt_Tj1 = new Sunny.UI.UILight();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PumpState = new Sunny.UI.UISwitch();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_TEMP = new System.Windows.Forms.TextBox();
            this.btn_St = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(344, 361);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(93, 44);
            this.btn_end.TabIndex = 20;
            this.btn_end.Text = "停止";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(241, 361);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(93, 44);
            this.btn_start.TabIndex = 19;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 40);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(391, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 40);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(182, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "煤油加降温";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_One
            // 
            this.btn_One.Location = new System.Drawing.Point(115, 361);
            this.btn_One.Name = "btn_One";
            this.btn_One.Size = new System.Drawing.Size(120, 44);
            this.btn_One.TabIndex = 23;
            this.btn_One.Tag = "2";
            this.btn_One.Text = "煤油控温";
            this.btn_One.UseVisualStyleBackColor = true;
            this.btn_One.Click += new System.EventHandler(this.ControlTemp_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 246);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lt_Gy);
            this.tabPage2.Controls.Add(this.lt_Jr2);
            this.tabPage2.Controls.Add(this.lt_Jr1);
            this.tabPage2.Controls.Add(this.lt_Ys2);
            this.tabPage2.Controls.Add(this.lt_Ys1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "运行信号";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lt_Gy
            // 
            this.lt_Gy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Gy.Location = new System.Drawing.Point(147, 174);
            this.lt_Gy.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Gy.Name = "lt_Gy";
            this.lt_Gy.Radius = 24;
            this.lt_Gy.Size = new System.Drawing.Size(24, 28);
            this.lt_Gy.TabIndex = 252;
            this.lt_Gy.Text = "ul_Gy";
            // 
            // lt_Jr2
            // 
            this.lt_Jr2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Jr2.Location = new System.Drawing.Point(147, 134);
            this.lt_Jr2.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Jr2.Name = "lt_Jr2";
            this.lt_Jr2.Radius = 24;
            this.lt_Jr2.Size = new System.Drawing.Size(24, 28);
            this.lt_Jr2.TabIndex = 252;
            this.lt_Jr2.Text = "uiLight1";
            // 
            // lt_Jr1
            // 
            this.lt_Jr1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Jr1.Location = new System.Drawing.Point(147, 94);
            this.lt_Jr1.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Jr1.Name = "lt_Jr1";
            this.lt_Jr1.Radius = 24;
            this.lt_Jr1.Size = new System.Drawing.Size(24, 28);
            this.lt_Jr1.TabIndex = 252;
            this.lt_Jr1.Text = "uiLight1";
            // 
            // lt_Ys2
            // 
            this.lt_Ys2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Ys2.Location = new System.Drawing.Point(147, 54);
            this.lt_Ys2.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Ys2.Name = "lt_Ys2";
            this.lt_Ys2.Radius = 24;
            this.lt_Ys2.Size = new System.Drawing.Size(24, 28);
            this.lt_Ys2.TabIndex = 252;
            this.lt_Ys2.Text = "uiLight1";
            // 
            // lt_Ys1
            // 
            this.lt_Ys1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Ys1.Location = new System.Drawing.Point(147, 14);
            this.lt_Ys1.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Ys1.Name = "lt_Ys1";
            this.lt_Ys1.Radius = 24;
            this.lt_Ys1.Size = new System.Drawing.Size(24, 28);
            this.lt_Ys1.TabIndex = 252;
            this.lt_Ys1.Text = "uiLight1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "2#压缩机运行";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "硅油循环泵运行";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "2#加热器运行";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "1#加热器运行";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "1#压缩机运行";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(241, 48);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(200, 246);
            this.tabControl2.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lt_Btj);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lt_Tj2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lt_Tj1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 212);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "报警信号";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "报警停机2";
            // 
            // lt_Btj
            // 
            this.lt_Btj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Btj.Location = new System.Drawing.Point(126, 115);
            this.lt_Btj.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Btj.Name = "lt_Btj";
            this.lt_Btj.OnColor = System.Drawing.Color.Red;
            this.lt_Btj.Radius = 24;
            this.lt_Btj.Size = new System.Drawing.Size(24, 28);
            this.lt_Btj.TabIndex = 252;
            this.lt_Btj.Text = "uiLight1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "报警停机1";
            // 
            // lt_Tj2
            // 
            this.lt_Tj2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Tj2.Location = new System.Drawing.Point(126, 70);
            this.lt_Tj2.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Tj2.Name = "lt_Tj2";
            this.lt_Tj2.OnColor = System.Drawing.Color.Red;
            this.lt_Tj2.Radius = 24;
            this.lt_Tj2.Size = new System.Drawing.Size(24, 28);
            this.lt_Tj2.TabIndex = 252;
            this.lt_Tj2.Text = "uiLight1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "报警不停机";
            // 
            // lt_Tj1
            // 
            this.lt_Tj1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lt_Tj1.Location = new System.Drawing.Point(126, 25);
            this.lt_Tj1.MinimumSize = new System.Drawing.Size(1, 1);
            this.lt_Tj1.Name = "lt_Tj1";
            this.lt_Tj1.OnColor = System.Drawing.Color.Red;
            this.lt_Tj1.Radius = 24;
            this.lt_Tj1.Size = new System.Drawing.Size(24, 28);
            this.lt_Tj1.TabIndex = 252;
            this.lt_Tj1.Text = "uiLight1";
            // 
            // PumpState
            // 
            this.PumpState.ActiveText = "远程";
            this.PumpState.Enabled = false;
            this.PumpState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PumpState.InActiveText = "本地";
            this.PumpState.Location = new System.Drawing.Point(18, 369);
            this.PumpState.MinimumSize = new System.Drawing.Size(1, 1);
            this.PumpState.Name = "PumpState";
            this.PumpState.Size = new System.Drawing.Size(75, 29);
            this.PumpState.TabIndex = 25;
            this.PumpState.Text = "uiSwitch1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "煤油温度设定 : ";
            // 
            // tb_TEMP
            // 
            this.tb_TEMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_TEMP.Location = new System.Drawing.Point(146, 316);
            this.tb_TEMP.Name = "tb_TEMP";
            this.tb_TEMP.Size = new System.Drawing.Size(79, 29);
            this.tb_TEMP.TabIndex = 26;
            this.tb_TEMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_St
            // 
            this.btn_St.Location = new System.Drawing.Point(277, 312);
            this.btn_St.Name = "btn_St";
            this.btn_St.Size = new System.Drawing.Size(57, 34);
            this.btn_St.TabIndex = 20;
            this.btn_St.Text = "设定";
            this.btn_St.UseVisualStyleBackColor = true;
            this.btn_St.Click += new System.EventHandler(this.btn_St_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "℃";
            // 
            // Fuelicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 426);
            this.Controls.Add(this.tb_TEMP);
            this.Controls.Add(this.PumpState);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_One);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_St);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_start);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Fuelicing";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.Button btn_One;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Sunny.UI.UILight lt_Jr2;
        private Sunny.UI.UILight lt_Jr1;
        private Sunny.UI.UILight lt_Ys2;
        private Sunny.UI.UILight lt_Ys1;
        private Sunny.UI.UILight lt_Btj;
        private Sunny.UI.UILight lt_Tj2;
        private Sunny.UI.UILight lt_Tj1;
        private Sunny.UI.UILight lt_Gy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UISwitch PumpState;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_TEMP;
        private System.Windows.Forms.Button btn_St;
        private System.Windows.Forms.Label label11;
    }
}