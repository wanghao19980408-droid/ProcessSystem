namespace ProcessSystem
{
    partial class Nitrogen_Heat
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
            this.btn_end1 = new System.Windows.Forms.Button();
            this.btn_start1 = new System.Windows.Forms.Button();
            this.btn_point_CoreAlarm_T = new System.Windows.Forms.Button();
            this.btn_point_outAlarm_T = new System.Windows.Forms.Button();
            this.btn_point_ReturnDiff = new System.Windows.Forms.Button();
            this.btn_point_Goal_T = new System.Windows.Forms.Button();
            this.txt_CoreAlarm_T = new System.Windows.Forms.TextBox();
            this.txt_outAlarm_T = new System.Windows.Forms.TextBox();
            this.txt_ReturnDiff = new System.Windows.Forms.TextBox();
            this.txt_Goal_T = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PumpState = new Sunny.UI.UISwitch();
            this.btn_start2 = new System.Windows.Forms.Button();
            this.btn_end2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_end1
            // 
            this.btn_end1.Location = new System.Drawing.Point(348, 248);
            this.btn_end1.Name = "btn_end1";
            this.btn_end1.Size = new System.Drawing.Size(131, 44);
            this.btn_end1.TabIndex = 20;
            this.btn_end1.Text = "1#加热器停止";
            this.btn_end1.UseVisualStyleBackColor = true;
            this.btn_end1.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // btn_start1
            // 
            this.btn_start1.Location = new System.Drawing.Point(158, 248);
            this.btn_start1.Name = "btn_start1";
            this.btn_start1.Size = new System.Drawing.Size(131, 44);
            this.btn_start1.TabIndex = 19;
            this.btn_start1.Text = "1#加热器启动";
            this.btn_start1.UseVisualStyleBackColor = true;
            this.btn_start1.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_point_CoreAlarm_T
            // 
            this.btn_point_CoreAlarm_T.Location = new System.Drawing.Point(362, 184);
            this.btn_point_CoreAlarm_T.Name = "btn_point_CoreAlarm_T";
            this.btn_point_CoreAlarm_T.Size = new System.Drawing.Size(58, 29);
            this.btn_point_CoreAlarm_T.TabIndex = 15;
            this.btn_point_CoreAlarm_T.Text = "设定";
            this.btn_point_CoreAlarm_T.UseVisualStyleBackColor = true;
            this.btn_point_CoreAlarm_T.Click += new System.EventHandler(this.btn_point_CoreAlarm_T_Click);
            // 
            // btn_point_outAlarm_T
            // 
            this.btn_point_outAlarm_T.Location = new System.Drawing.Point(362, 143);
            this.btn_point_outAlarm_T.Name = "btn_point_outAlarm_T";
            this.btn_point_outAlarm_T.Size = new System.Drawing.Size(58, 29);
            this.btn_point_outAlarm_T.TabIndex = 16;
            this.btn_point_outAlarm_T.Text = "设定";
            this.btn_point_outAlarm_T.UseVisualStyleBackColor = true;
            this.btn_point_outAlarm_T.Click += new System.EventHandler(this.btn_point_outAlarm_T_Click);
            // 
            // btn_point_ReturnDiff
            // 
            this.btn_point_ReturnDiff.Location = new System.Drawing.Point(362, 102);
            this.btn_point_ReturnDiff.Name = "btn_point_ReturnDiff";
            this.btn_point_ReturnDiff.Size = new System.Drawing.Size(58, 29);
            this.btn_point_ReturnDiff.TabIndex = 17;
            this.btn_point_ReturnDiff.Text = "设定";
            this.btn_point_ReturnDiff.UseVisualStyleBackColor = true;
            this.btn_point_ReturnDiff.Click += new System.EventHandler(this.btn_point_ReturnDiff_Click);
            // 
            // btn_point_Goal_T
            // 
            this.btn_point_Goal_T.Location = new System.Drawing.Point(362, 61);
            this.btn_point_Goal_T.Name = "btn_point_Goal_T";
            this.btn_point_Goal_T.Size = new System.Drawing.Size(58, 29);
            this.btn_point_Goal_T.TabIndex = 18;
            this.btn_point_Goal_T.Text = "设定";
            this.btn_point_Goal_T.UseVisualStyleBackColor = true;
            this.btn_point_Goal_T.Click += new System.EventHandler(this.btn_point_Goal_T_Click);
            // 
            // txt_CoreAlarm_T
            // 
            this.txt_CoreAlarm_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CoreAlarm_T.Location = new System.Drawing.Point(240, 183);
            this.txt_CoreAlarm_T.Name = "txt_CoreAlarm_T";
            this.txt_CoreAlarm_T.Size = new System.Drawing.Size(100, 29);
            this.txt_CoreAlarm_T.TabIndex = 13;
            // 
            // txt_outAlarm_T
            // 
            this.txt_outAlarm_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_outAlarm_T.Location = new System.Drawing.Point(240, 141);
            this.txt_outAlarm_T.Name = "txt_outAlarm_T";
            this.txt_outAlarm_T.Size = new System.Drawing.Size(100, 29);
            this.txt_outAlarm_T.TabIndex = 11;
            // 
            // txt_ReturnDiff
            // 
            this.txt_ReturnDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ReturnDiff.Location = new System.Drawing.Point(240, 99);
            this.txt_ReturnDiff.Name = "txt_ReturnDiff";
            this.txt_ReturnDiff.Size = new System.Drawing.Size(100, 29);
            this.txt_ReturnDiff.TabIndex = 14;
            // 
            // txt_Goal_T
            // 
            this.txt_Goal_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Goal_T.Location = new System.Drawing.Point(240, 57);
            this.txt_Goal_T.Name = "txt_Goal_T";
            this.txt_Goal_T.Size = new System.Drawing.Size(100, 29);
            this.txt_Goal_T.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(14, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "核心温度上限设定SV2(绝对值)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(22, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "出口温度上限设定AL1(差值)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(74, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "回差值设定HC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(66, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "目标温度设定SV";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 40);
            this.panel1.TabIndex = 21;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(821, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 40);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(373, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "氮气加热控制";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // PumpState
            // 
            this.PumpState.ActiveText = "远程";
            this.PumpState.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PumpState.InActiveText = "本地";
            this.PumpState.Location = new System.Drawing.Point(33, 257);
            this.PumpState.MinimumSize = new System.Drawing.Size(1, 1);
            this.PumpState.Name = "PumpState";
            this.PumpState.Size = new System.Drawing.Size(75, 29);
            this.PumpState.TabIndex = 22;
            this.PumpState.Text = "uiSwitch1";
            this.PumpState.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.PumpState_ValueChanged);
            // 
            // btn_start2
            // 
            this.btn_start2.Location = new System.Drawing.Point(538, 248);
            this.btn_start2.Name = "btn_start2";
            this.btn_start2.Size = new System.Drawing.Size(131, 44);
            this.btn_start2.TabIndex = 19;
            this.btn_start2.Text = "2#加热器启动";
            this.btn_start2.UseVisualStyleBackColor = true;
            this.btn_start2.Click += new System.EventHandler(this.btn_start2_Click);
            // 
            // btn_end2
            // 
            this.btn_end2.Location = new System.Drawing.Point(728, 248);
            this.btn_end2.Name = "btn_end2";
            this.btn_end2.Size = new System.Drawing.Size(131, 44);
            this.btn_end2.TabIndex = 20;
            this.btn_end2.Text = "2#加热器停止";
            this.btn_end2.UseVisualStyleBackColor = true;
            this.btn_end2.Click += new System.EventHandler(this.btn_end2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(426, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(437, 184);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "=>加热器加热升温的最终目标值\n\n=>1#加热器在>SV-HC时停，<SV-HC时延时20S自动启动。2#加热器超温（出口温度>SV+AL1）后，会在（出口温度<" +
    "SV-HC）自动启动\n=>出口温度>SV+AL1后，1#、2#加热器都会通知，直到出口温度<SV-HC后自动启动\n=>加热器核心温度>SV2后，1#、2#加热器" +
    "都会停止，需要用户确认后再手动重启";
            // 
            // Nitrogen_Heat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 304);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.PumpState);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_end2);
            this.Controls.Add(this.btn_start2);
            this.Controls.Add(this.btn_end1);
            this.Controls.Add(this.btn_start1);
            this.Controls.Add(this.btn_point_CoreAlarm_T);
            this.Controls.Add(this.btn_point_outAlarm_T);
            this.Controls.Add(this.btn_point_ReturnDiff);
            this.Controls.Add(this.btn_point_Goal_T);
            this.Controls.Add(this.txt_CoreAlarm_T);
            this.Controls.Add(this.txt_outAlarm_T);
            this.Controls.Add(this.txt_ReturnDiff);
            this.Controls.Add(this.txt_Goal_T);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Nitrogen_Heat";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_end1;
        private System.Windows.Forms.Button btn_start1;
        private System.Windows.Forms.Button btn_point_CoreAlarm_T;
        private System.Windows.Forms.Button btn_point_outAlarm_T;
        private System.Windows.Forms.Button btn_point_ReturnDiff;
        private System.Windows.Forms.Button btn_point_Goal_T;
        private System.Windows.Forms.TextBox txt_CoreAlarm_T;
        private System.Windows.Forms.TextBox txt_outAlarm_T;
        private System.Windows.Forms.TextBox txt_ReturnDiff;
        private System.Windows.Forms.TextBox txt_Goal_T;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btn_Close;
        private Sunny.UI.UISwitch PumpState;
        private System.Windows.Forms.Button btn_start2;
        private System.Windows.Forms.Button btn_end2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}