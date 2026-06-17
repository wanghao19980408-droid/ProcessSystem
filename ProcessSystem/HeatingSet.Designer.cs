namespace ProcessSystem
{
    partial class HeatingSet
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
            this.btn_Close = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_point_Exit_T = new System.Windows.Forms.Button();
            this.txt_Exit_T = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_point_LiquidLowLow = new System.Windows.Forms.Button();
            this.btn_point_LiquidLow = new System.Windows.Forms.Button();
            this.btn_point_WaterTHighHigh = new System.Windows.Forms.Button();
            this.btn_point_WaterTHigh = new System.Windows.Forms.Button();
            this.txt_LiquidLowLow = new System.Windows.Forms.TextBox();
            this.txt_LiquidLow = new System.Windows.Forms.TextBox();
            this.txt_WaterTHighHigh = new System.Windows.Forms.TextBox();
            this.txt_WaterTHigh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 40);
            this.panel1.TabIndex = 52;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(458, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 40);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(198, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "水浴加热器";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_point_Exit_T
            // 
            this.btn_point_Exit_T.Location = new System.Drawing.Point(336, 222);
            this.btn_point_Exit_T.Name = "btn_point_Exit_T";
            this.btn_point_Exit_T.Size = new System.Drawing.Size(58, 29);
            this.btn_point_Exit_T.TabIndex = 82;
            this.btn_point_Exit_T.Text = "设定";
            this.btn_point_Exit_T.UseVisualStyleBackColor = true;
            this.btn_point_Exit_T.Click += new System.EventHandler(this.btn_point_Exit_T_Click);
            // 
            // txt_Exit_T
            // 
            this.txt_Exit_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Exit_T.Location = new System.Drawing.Point(207, 224);
            this.txt_Exit_T.Name = "txt_Exit_T";
            this.txt_Exit_T.Size = new System.Drawing.Size(100, 29);
            this.txt_Exit_T.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(36, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 80;
            this.label6.Text = "加热器出口温度设定";
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(274, 259);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(93, 44);
            this.btn_end.TabIndex = 79;
            this.btn_end.Text = "停止";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(124, 261);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(93, 44);
            this.btn_start.TabIndex = 78;
            this.btn_start.Text = "启动";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_point_LiquidLowLow
            // 
            this.btn_point_LiquidLowLow.Location = new System.Drawing.Point(336, 179);
            this.btn_point_LiquidLowLow.Name = "btn_point_LiquidLowLow";
            this.btn_point_LiquidLowLow.Size = new System.Drawing.Size(58, 29);
            this.btn_point_LiquidLowLow.TabIndex = 74;
            this.btn_point_LiquidLowLow.Text = "设定";
            this.btn_point_LiquidLowLow.UseVisualStyleBackColor = true;
            this.btn_point_LiquidLowLow.Click += new System.EventHandler(this.btn_point_LiquidLowLow_Click);
            // 
            // btn_point_LiquidLow
            // 
            this.btn_point_LiquidLow.Location = new System.Drawing.Point(336, 136);
            this.btn_point_LiquidLow.Name = "btn_point_LiquidLow";
            this.btn_point_LiquidLow.Size = new System.Drawing.Size(58, 29);
            this.btn_point_LiquidLow.TabIndex = 75;
            this.btn_point_LiquidLow.Text = "设定";
            this.btn_point_LiquidLow.UseVisualStyleBackColor = true;
            this.btn_point_LiquidLow.Click += new System.EventHandler(this.btn_point_LiquidLow_Click);
            // 
            // btn_point_WaterTHighHigh
            // 
            this.btn_point_WaterTHighHigh.Location = new System.Drawing.Point(336, 93);
            this.btn_point_WaterTHighHigh.Name = "btn_point_WaterTHighHigh";
            this.btn_point_WaterTHighHigh.Size = new System.Drawing.Size(58, 29);
            this.btn_point_WaterTHighHigh.TabIndex = 76;
            this.btn_point_WaterTHighHigh.Text = "设定";
            this.btn_point_WaterTHighHigh.UseVisualStyleBackColor = true;
            this.btn_point_WaterTHighHigh.Click += new System.EventHandler(this.btn_point_WaterTHighHigh_Click);
            // 
            // btn_point_WaterTHigh
            // 
            this.btn_point_WaterTHigh.Location = new System.Drawing.Point(336, 50);
            this.btn_point_WaterTHigh.Name = "btn_point_WaterTHigh";
            this.btn_point_WaterTHigh.Size = new System.Drawing.Size(58, 29);
            this.btn_point_WaterTHigh.TabIndex = 77;
            this.btn_point_WaterTHigh.Text = "设定";
            this.btn_point_WaterTHigh.UseVisualStyleBackColor = true;
            this.btn_point_WaterTHigh.Click += new System.EventHandler(this.btn_point_WaterTHigh_Click);
            // 
            // txt_LiquidLowLow
            // 
            this.txt_LiquidLowLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LiquidLowLow.Location = new System.Drawing.Point(207, 178);
            this.txt_LiquidLowLow.Name = "txt_LiquidLowLow";
            this.txt_LiquidLowLow.Size = new System.Drawing.Size(100, 29);
            this.txt_LiquidLowLow.TabIndex = 72;
            // 
            // txt_LiquidLow
            // 
            this.txt_LiquidLow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LiquidLow.Location = new System.Drawing.Point(207, 136);
            this.txt_LiquidLow.Name = "txt_LiquidLow";
            this.txt_LiquidLow.Size = new System.Drawing.Size(100, 29);
            this.txt_LiquidLow.TabIndex = 70;
            // 
            // txt_WaterTHighHigh
            // 
            this.txt_WaterTHighHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_WaterTHighHigh.Location = new System.Drawing.Point(207, 94);
            this.txt_WaterTHighHigh.Name = "txt_WaterTHighHigh";
            this.txt_WaterTHighHigh.Size = new System.Drawing.Size(100, 29);
            this.txt_WaterTHighHigh.TabIndex = 73;
            // 
            // txt_WaterTHigh
            // 
            this.txt_WaterTHigh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_WaterTHigh.Location = new System.Drawing.Point(207, 52);
            this.txt_WaterTHigh.Name = "txt_WaterTHigh";
            this.txt_WaterTHigh.Size = new System.Drawing.Size(100, 29);
            this.txt_WaterTHigh.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(84, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "液位低低设定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(100, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 67;
            this.label4.Text = "液位低设定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(84, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "水温高高设定";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(100, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "水温高设定";
            // 
            // HeatingSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 316);
            this.Controls.Add(this.btn_point_Exit_T);
            this.Controls.Add(this.txt_Exit_T);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_end);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_point_LiquidLowLow);
            this.Controls.Add(this.btn_point_LiquidLow);
            this.Controls.Add(this.btn_point_WaterTHighHigh);
            this.Controls.Add(this.btn_point_WaterTHigh);
            this.Controls.Add(this.txt_LiquidLowLow);
            this.Controls.Add(this.txt_LiquidLow);
            this.Controls.Add(this.txt_WaterTHighHigh);
            this.Controls.Add(this.txt_WaterTHigh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HeatingSet";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HeatingSet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_point_Exit_T;
        private System.Windows.Forms.TextBox txt_Exit_T;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_point_LiquidLowLow;
        private System.Windows.Forms.Button btn_point_LiquidLow;
        private System.Windows.Forms.Button btn_point_WaterTHighHigh;
        private System.Windows.Forms.Button btn_point_WaterTHigh;
        private System.Windows.Forms.TextBox txt_LiquidLowLow;
        private System.Windows.Forms.TextBox txt_LiquidLow;
        private System.Windows.Forms.TextBox txt_WaterTHighHigh;
        private System.Windows.Forms.TextBox txt_WaterTHigh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}