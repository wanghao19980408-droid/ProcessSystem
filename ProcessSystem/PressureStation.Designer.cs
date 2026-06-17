namespace ProcessSystem
{
    partial class PressureStation
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
            this.btn_CLose = new Sunny.UI.UISymbolButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_endFuel = new System.Windows.Forms.Button();
            this.btn_startFuel = new System.Windows.Forms.Button();
            this.btn_pointFuel = new System.Windows.Forms.Button();
            this.txt_Fuel_P = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_FuelFlow = new System.Windows.Forms.ComboBox();
            this.CB_OxygenSensor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Fuel = new System.Windows.Forms.ComboBox();
            this.CB_Station = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_FuelSensor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Oxygen_P = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_OxygenFlow = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label276 = new System.Windows.Forms.Label();
            this.btn_endOxygen = new System.Windows.Forms.Button();
            this.btn_startOxygen = new System.Windows.Forms.Button();
            this.btn_pointOxygen = new System.Windows.Forms.Button();
            this.btn_OxygenTime = new System.Windows.Forms.Button();
            this.btn_FuelTime = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.btn_CLose);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 40);
            this.panel1.TabIndex = 52;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_CLose
            // 
            this.btn_CLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CLose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CLose.FillColor = System.Drawing.Color.Transparent;
            this.btn_CLose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CLose.ForeHoverColor = System.Drawing.Color.Red;
            this.btn_CLose.ForePressColor = System.Drawing.Color.Red;
            this.btn_CLose.ForeSelectedColor = System.Drawing.Color.Red;
            this.btn_CLose.Location = new System.Drawing.Point(824, 0);
            this.btn_CLose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CLose.Name = "btn_CLose";
            this.btn_CLose.RectColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CLose.Size = new System.Drawing.Size(54, 40);
            this.btn_CLose.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CLose.Symbol = 558829;
            this.btn_CLose.SymbolHoverColor = System.Drawing.Color.Red;
            this.btn_CLose.SymbolPressColor = System.Drawing.Color.Red;
            this.btn_CLose.SymbolSelectedColor = System.Drawing.Color.Red;
            this.btn_CLose.SymbolSize = 30;
            this.btn_CLose.TabIndex = 425;
            this.btn_CLose.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btn_CLose.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CLose.TipsForeColor = System.Drawing.Color.Black;
            this.btn_CLose.TipsText = "退出程序";
            this.btn_CLose.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(608, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "氧增压控制阀台";
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(167, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "燃增压控制阀台";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_endFuel
            // 
            this.btn_endFuel.Location = new System.Drawing.Point(229, 265);
            this.btn_endFuel.Name = "btn_endFuel";
            this.btn_endFuel.Size = new System.Drawing.Size(93, 44);
            this.btn_endFuel.TabIndex = 79;
            this.btn_endFuel.Text = "停止增压";
            this.btn_endFuel.UseVisualStyleBackColor = true;
            this.btn_endFuel.Click += new System.EventHandler(this.btn_endFuel_Click);
            // 
            // btn_startFuel
            // 
            this.btn_startFuel.Location = new System.Drawing.Point(120, 265);
            this.btn_startFuel.Name = "btn_startFuel";
            this.btn_startFuel.Size = new System.Drawing.Size(93, 44);
            this.btn_startFuel.TabIndex = 78;
            this.btn_startFuel.Text = "开始增压";
            this.btn_startFuel.UseVisualStyleBackColor = true;
            this.btn_startFuel.Click += new System.EventHandler(this.btn_startFuel_Click);
            // 
            // btn_pointFuel
            // 
            this.btn_pointFuel.Location = new System.Drawing.Point(11, 265);
            this.btn_pointFuel.Name = "btn_pointFuel";
            this.btn_pointFuel.Size = new System.Drawing.Size(93, 44);
            this.btn_pointFuel.TabIndex = 77;
            this.btn_pointFuel.Text = "设定参数";
            this.btn_pointFuel.UseVisualStyleBackColor = true;
            this.btn_pointFuel.Click += new System.EventHandler(this.btn_pointFuel_Click);
            // 
            // txt_Fuel_P
            // 
            this.txt_Fuel_P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Fuel_P.Location = new System.Drawing.Point(224, 163);
            this.txt_Fuel_P.Name = "txt_Fuel_P";
            this.txt_Fuel_P.Size = new System.Drawing.Size(137, 29);
            this.txt_Fuel_P.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(528, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 66;
            this.label5.Text = "氧增压目标传感器";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(95, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "工况选择(流量)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(95, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "燃增压目标设定";
            // 
            // CB_FuelFlow
            // 
            this.CB_FuelFlow.FormattingEnabled = true;
            this.CB_FuelFlow.Items.AddRange(new object[] {
            "小流量",
            "大流量"});
            this.CB_FuelFlow.Location = new System.Drawing.Point(222, 115);
            this.CB_FuelFlow.Name = "CB_FuelFlow";
            this.CB_FuelFlow.Size = new System.Drawing.Size(137, 29);
            this.CB_FuelFlow.TabIndex = 80;
            // 
            // CB_OxygenSensor
            // 
            this.CB_OxygenSensor.FormattingEnabled = true;
            this.CB_OxygenSensor.Location = new System.Drawing.Point(669, 211);
            this.CB_OxygenSensor.Name = "CB_OxygenSensor";
            this.CB_OxygenSensor.Size = new System.Drawing.Size(137, 29);
            this.CB_OxygenSensor.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(143, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 67;
            this.label4.Text = "燃料介质";
            // 
            // CB_Fuel
            // 
            this.CB_Fuel.FormattingEnabled = true;
            this.CB_Fuel.Items.AddRange(new object[] {
            "煤油",
            "甲烷"});
            this.CB_Fuel.Location = new System.Drawing.Point(222, 67);
            this.CB_Fuel.Name = "CB_Fuel";
            this.CB_Fuel.Size = new System.Drawing.Size(137, 29);
            this.CB_Fuel.TabIndex = 81;
            this.CB_Fuel.SelectedIndexChanged += new System.EventHandler(this.CB_Fuel_SelectedIndexChanged);
            // 
            // CB_Station
            // 
            this.CB_Station.FormattingEnabled = true;
            this.CB_Station.Location = new System.Drawing.Point(669, 67);
            this.CB_Station.Name = "CB_Station";
            this.CB_Station.Size = new System.Drawing.Size(137, 29);
            this.CB_Station.TabIndex = 84;
            this.CB_Station.SelectedIndexChanged += new System.EventHandler(this.CB_Station_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(592, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "工位选择";
            // 
            // CB_FuelSensor
            // 
            this.CB_FuelSensor.FormattingEnabled = true;
            this.CB_FuelSensor.Location = new System.Drawing.Point(222, 211);
            this.CB_FuelSensor.Name = "CB_FuelSensor";
            this.CB_FuelSensor.Size = new System.Drawing.Size(137, 29);
            this.CB_FuelSensor.TabIndex = 86;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(79, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 16);
            this.label7.TabIndex = 85;
            this.label7.Text = "燃增压目标传感器";
            // 
            // txt_Oxygen_P
            // 
            this.txt_Oxygen_P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Oxygen_P.Location = new System.Drawing.Point(669, 163);
            this.txt_Oxygen_P.Name = "txt_Oxygen_P";
            this.txt_Oxygen_P.Size = new System.Drawing.Size(135, 29);
            this.txt_Oxygen_P.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(544, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 16);
            this.label8.TabIndex = 88;
            this.label8.Text = "氧增压目标设定";
            // 
            // CB_OxygenFlow
            // 
            this.CB_OxygenFlow.FormattingEnabled = true;
            this.CB_OxygenFlow.Items.AddRange(new object[] {
            "小流量",
            "大流量"});
            this.CB_OxygenFlow.Location = new System.Drawing.Point(669, 115);
            this.CB_OxygenFlow.Name = "CB_OxygenFlow";
            this.CB_OxygenFlow.Size = new System.Drawing.Size(137, 29);
            this.CB_OxygenFlow.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(544, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 16);
            this.label9.TabIndex = 89;
            this.label9.Text = "工况选择(流量)";
            // 
            // label276
            // 
            this.label276.BackColor = System.Drawing.Color.Black;
            this.label276.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label276.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label276.Location = new System.Drawing.Point(446, 43);
            this.label276.Name = "label276";
            this.label276.Size = new System.Drawing.Size(1, 294);
            this.label276.TabIndex = 257;
            // 
            // btn_endOxygen
            // 
            this.btn_endOxygen.Location = new System.Drawing.Point(674, 265);
            this.btn_endOxygen.Name = "btn_endOxygen";
            this.btn_endOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_endOxygen.TabIndex = 260;
            this.btn_endOxygen.Text = "停止增压";
            this.btn_endOxygen.UseVisualStyleBackColor = true;
            this.btn_endOxygen.Click += new System.EventHandler(this.btn_endOxygen_Click);
            // 
            // btn_startOxygen
            // 
            this.btn_startOxygen.Location = new System.Drawing.Point(568, 265);
            this.btn_startOxygen.Name = "btn_startOxygen";
            this.btn_startOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_startOxygen.TabIndex = 259;
            this.btn_startOxygen.Text = "开始增压";
            this.btn_startOxygen.UseVisualStyleBackColor = true;
            this.btn_startOxygen.Click += new System.EventHandler(this.btn_startOxygen_Click);
            // 
            // btn_pointOxygen
            // 
            this.btn_pointOxygen.Location = new System.Drawing.Point(462, 265);
            this.btn_pointOxygen.Name = "btn_pointOxygen";
            this.btn_pointOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_pointOxygen.TabIndex = 258;
            this.btn_pointOxygen.Text = "设定参数";
            this.btn_pointOxygen.UseVisualStyleBackColor = true;
            this.btn_pointOxygen.Click += new System.EventHandler(this.btn_pointOxygen_Click);
            // 
            // btn_OxygenTime
            // 
            this.btn_OxygenTime.Location = new System.Drawing.Point(780, 265);
            this.btn_OxygenTime.Name = "btn_OxygenTime";
            this.btn_OxygenTime.Size = new System.Drawing.Size(93, 44);
            this.btn_OxygenTime.TabIndex = 260;
            this.btn_OxygenTime.Text = "时序设定";
            this.btn_OxygenTime.UseVisualStyleBackColor = true;
            this.btn_OxygenTime.Click += new System.EventHandler(this.btn_OxygenTime_Click);
            // 
            // btn_FuelTime
            // 
            this.btn_FuelTime.Location = new System.Drawing.Point(338, 265);
            this.btn_FuelTime.Name = "btn_FuelTime";
            this.btn_FuelTime.Size = new System.Drawing.Size(93, 44);
            this.btn_FuelTime.TabIndex = 260;
            this.btn_FuelTime.Text = "时序设定";
            this.btn_FuelTime.UseVisualStyleBackColor = true;
            this.btn_FuelTime.Click += new System.EventHandler(this.btn_FuelTime_Click);
            // 
            // PressureStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 316);
            this.Controls.Add(this.btn_FuelTime);
            this.Controls.Add(this.btn_OxygenTime);
            this.Controls.Add(this.btn_endOxygen);
            this.Controls.Add(this.btn_startOxygen);
            this.Controls.Add(this.btn_pointOxygen);
            this.Controls.Add(this.label276);
            this.Controls.Add(this.CB_OxygenFlow);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Oxygen_P);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CB_FuelSensor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CB_Station);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CB_OxygenSensor);
            this.Controls.Add(this.CB_Fuel);
            this.Controls.Add(this.CB_FuelFlow);
            this.Controls.Add(this.btn_endFuel);
            this.Controls.Add(this.btn_startFuel);
            this.Controls.Add(this.btn_pointFuel);
            this.Controls.Add(this.txt_Fuel_P);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PressureStation";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeatingSet";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_endFuel;
        private System.Windows.Forms.Button btn_startFuel;
        private System.Windows.Forms.Button btn_pointFuel;
        private System.Windows.Forms.TextBox txt_Fuel_P;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_FuelFlow;
        private System.Windows.Forms.ComboBox CB_OxygenSensor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Fuel;
        private System.Windows.Forms.ComboBox CB_Station;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_FuelSensor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Oxygen_P;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CB_OxygenFlow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label276;
        private System.Windows.Forms.Button btn_endOxygen;
        private System.Windows.Forms.Button btn_startOxygen;
        private System.Windows.Forms.Button btn_pointOxygen;
        private Sunny.UI.UISymbolButton btn_CLose;
        private System.Windows.Forms.Button btn_OxygenTime;
        private System.Windows.Forms.Button btn_FuelTime;
    }
}