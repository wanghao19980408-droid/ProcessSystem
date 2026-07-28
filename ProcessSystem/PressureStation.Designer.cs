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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_FuelFlow = new System.Windows.Forms.ComboBox();
            this.CB_OxygenSensorMain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_Fuel = new System.Windows.Forms.ComboBox();
            this.CB_Station = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.MainSensor2 = new System.Windows.Forms.Label();
            this.lb_MainSensor2 = new System.Windows.Forms.Label();
            this.lb_MainSensor1 = new System.Windows.Forms.Label();
            this.wy = new System.Windows.Forms.Label();
            this.lb_CurrentSensor = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MainSensor1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rb_MainSensor = new System.Windows.Forms.RadioButton();
            this.rb_BackupSensor = new System.Windows.Forms.RadioButton();
            this.CB_OxygenSensorBackup = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FuelBackupSensor = new System.Windows.Forms.Label();
            this.lb_FuelBackupSensor = new System.Windows.Forms.Label();
            this.lb_FuelMainSensor = new System.Windows.Forms.Label();
            this.lb_FuelWY = new System.Windows.Forms.Label();
            this.lb_FuelCurrentSensor = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.FuelMainSensor = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CB_FuelSensorMain = new System.Windows.Forms.ComboBox();
            this.rb_FuelBackupSensor = new System.Windows.Forms.RadioButton();
            this.rb_FuelMainSensor = new System.Windows.Forms.RadioButton();
            this.CB_FuelSensorBackup = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(881, 40);
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
            this.btn_CLose.Location = new System.Drawing.Point(827, 0);
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
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(608, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 26);
            this.label10.TabIndex = 1;
            this.label10.Text = "氧增压控制阀台";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(167, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "燃增压控制阀台";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_endFuel
            // 
            this.btn_endFuel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_endFuel.Location = new System.Drawing.Point(229, 401);
            this.btn_endFuel.Name = "btn_endFuel";
            this.btn_endFuel.Size = new System.Drawing.Size(93, 44);
            this.btn_endFuel.TabIndex = 79;
            this.btn_endFuel.Text = "停止增压";
            this.btn_endFuel.UseVisualStyleBackColor = true;
            this.btn_endFuel.Click += new System.EventHandler(this.btn_endFuel_Click);
            // 
            // btn_startFuel
            // 
            this.btn_startFuel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_startFuel.Location = new System.Drawing.Point(120, 401);
            this.btn_startFuel.Name = "btn_startFuel";
            this.btn_startFuel.Size = new System.Drawing.Size(93, 44);
            this.btn_startFuel.TabIndex = 78;
            this.btn_startFuel.Text = "开始增压";
            this.btn_startFuel.UseVisualStyleBackColor = true;
            this.btn_startFuel.Click += new System.EventHandler(this.btn_startFuel_Click);
            // 
            // btn_pointFuel
            // 
            this.btn_pointFuel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pointFuel.Location = new System.Drawing.Point(11, 401);
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
            this.txt_Fuel_P.Location = new System.Drawing.Point(224, 175);
            this.txt_Fuel_P.Name = "txt_Fuel_P";
            this.txt_Fuel_P.Size = new System.Drawing.Size(137, 29);
            this.txt_Fuel_P.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(101, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 68;
            this.label3.Text = "工况选择(流量)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 69;
            this.label1.Text = "燃增压目标设定";
            // 
            // CB_FuelFlow
            // 
            this.CB_FuelFlow.FormattingEnabled = true;
            this.CB_FuelFlow.Items.AddRange(new object[] {
            "小流量",
            "大流量"});
            this.CB_FuelFlow.Location = new System.Drawing.Point(222, 123);
            this.CB_FuelFlow.Name = "CB_FuelFlow";
            this.CB_FuelFlow.Size = new System.Drawing.Size(137, 29);
            this.CB_FuelFlow.TabIndex = 80;
            // 
            // CB_OxygenSensorMain
            // 
            this.CB_OxygenSensorMain.FormattingEnabled = true;
            this.CB_OxygenSensorMain.Location = new System.Drawing.Point(127, 12);
            this.CB_OxygenSensorMain.Name = "CB_OxygenSensorMain";
            this.CB_OxygenSensorMain.Size = new System.Drawing.Size(80, 29);
            this.CB_OxygenSensorMain.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(143, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 67;
            this.label4.Text = "燃料介质";
            // 
            // CB_Fuel
            // 
            this.CB_Fuel.FormattingEnabled = true;
            this.CB_Fuel.Items.AddRange(new object[] {
            "煤油",
            "甲烷"});
            this.CB_Fuel.Location = new System.Drawing.Point(222, 71);
            this.CB_Fuel.Name = "CB_Fuel";
            this.CB_Fuel.Size = new System.Drawing.Size(137, 29);
            this.CB_Fuel.TabIndex = 81;
            this.CB_Fuel.SelectedIndexChanged += new System.EventHandler(this.CB_Fuel_SelectedIndexChanged);
            // 
            // CB_Station
            // 
            this.CB_Station.FormattingEnabled = true;
            this.CB_Station.Location = new System.Drawing.Point(671, 71);
            this.CB_Station.Name = "CB_Station";
            this.CB_Station.Size = new System.Drawing.Size(137, 29);
            this.CB_Station.TabIndex = 84;
            this.CB_Station.SelectedIndexChanged += new System.EventHandler(this.CB_Station_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(586, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 83;
            this.label6.Text = "工位选择";
            // 
            // txt_Oxygen_P
            // 
            this.txt_Oxygen_P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Oxygen_P.Location = new System.Drawing.Point(671, 175);
            this.txt_Oxygen_P.Name = "txt_Oxygen_P";
            this.txt_Oxygen_P.Size = new System.Drawing.Size(135, 29);
            this.txt_Oxygen_P.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(538, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 88;
            this.label8.Text = "氧增压目标设定";
            // 
            // CB_OxygenFlow
            // 
            this.CB_OxygenFlow.FormattingEnabled = true;
            this.CB_OxygenFlow.Items.AddRange(new object[] {
            "小流量",
            "大流量"});
            this.CB_OxygenFlow.Location = new System.Drawing.Point(671, 123);
            this.CB_OxygenFlow.Name = "CB_OxygenFlow";
            this.CB_OxygenFlow.Size = new System.Drawing.Size(137, 29);
            this.CB_OxygenFlow.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(544, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 21);
            this.label9.TabIndex = 89;
            this.label9.Text = "工况选择(流量)";
            // 
            // label276
            // 
            this.label276.BackColor = System.Drawing.Color.Black;
            this.label276.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label276.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label276.Location = new System.Drawing.Point(448, 42);
            this.label276.Name = "label276";
            this.label276.Size = new System.Drawing.Size(2, 403);
            this.label276.TabIndex = 257;
            // 
            // btn_endOxygen
            // 
            this.btn_endOxygen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_endOxygen.Location = new System.Drawing.Point(674, 401);
            this.btn_endOxygen.Name = "btn_endOxygen";
            this.btn_endOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_endOxygen.TabIndex = 260;
            this.btn_endOxygen.Text = "停止增压";
            this.btn_endOxygen.UseVisualStyleBackColor = true;
            this.btn_endOxygen.Click += new System.EventHandler(this.btn_endOxygen_Click);
            // 
            // btn_startOxygen
            // 
            this.btn_startOxygen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_startOxygen.Location = new System.Drawing.Point(568, 401);
            this.btn_startOxygen.Name = "btn_startOxygen";
            this.btn_startOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_startOxygen.TabIndex = 259;
            this.btn_startOxygen.Text = "开始增压";
            this.btn_startOxygen.UseVisualStyleBackColor = true;
            this.btn_startOxygen.Click += new System.EventHandler(this.btn_startOxygen_Click);
            // 
            // btn_pointOxygen
            // 
            this.btn_pointOxygen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_pointOxygen.Location = new System.Drawing.Point(462, 401);
            this.btn_pointOxygen.Name = "btn_pointOxygen";
            this.btn_pointOxygen.Size = new System.Drawing.Size(93, 44);
            this.btn_pointOxygen.TabIndex = 258;
            this.btn_pointOxygen.Text = "设定参数";
            this.btn_pointOxygen.UseVisualStyleBackColor = true;
            this.btn_pointOxygen.Click += new System.EventHandler(this.btn_pointOxygen_Click);
            // 
            // btn_OxygenTime
            // 
            this.btn_OxygenTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OxygenTime.Location = new System.Drawing.Point(780, 401);
            this.btn_OxygenTime.Name = "btn_OxygenTime";
            this.btn_OxygenTime.Size = new System.Drawing.Size(93, 44);
            this.btn_OxygenTime.TabIndex = 260;
            this.btn_OxygenTime.Text = "时序设定";
            this.btn_OxygenTime.UseVisualStyleBackColor = true;
            this.btn_OxygenTime.Click += new System.EventHandler(this.btn_OxygenTime_Click);
            // 
            // btn_FuelTime
            // 
            this.btn_FuelTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FuelTime.Location = new System.Drawing.Point(338, 401);
            this.btn_FuelTime.Name = "btn_FuelTime";
            this.btn_FuelTime.Size = new System.Drawing.Size(93, 44);
            this.btn_FuelTime.TabIndex = 260;
            this.btn_FuelTime.Text = "时序设定";
            this.btn_FuelTime.UseVisualStyleBackColor = true;
            this.btn_FuelTime.Click += new System.EventHandler(this.btn_FuelTime_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MainSensor2);
            this.panel2.Controls.Add(this.lb_MainSensor2);
            this.panel2.Controls.Add(this.lb_MainSensor1);
            this.panel2.Controls.Add(this.wy);
            this.panel2.Controls.Add(this.lb_CurrentSensor);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.MainSensor1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(462, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 124);
            this.panel2.TabIndex = 261;
            // 
            // MainSensor2
            // 
            this.MainSensor2.AutoSize = true;
            this.MainSensor2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainSensor2.Location = new System.Drawing.Point(232, 82);
            this.MainSensor2.Name = "MainSensor2";
            this.MainSensor2.Size = new System.Drawing.Size(66, 21);
            this.MainSensor2.TabIndex = 89;
            this.MainSensor2.Text = "PT223b";
            // 
            // lb_MainSensor2
            // 
            this.lb_MainSensor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_MainSensor2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MainSensor2.Location = new System.Drawing.Point(304, 80);
            this.lb_MainSensor2.Name = "lb_MainSensor2";
            this.lb_MainSensor2.Size = new System.Drawing.Size(59, 25);
            this.lb_MainSensor2.TabIndex = 90;
            this.lb_MainSensor2.Text = "0.00";
            this.lb_MainSensor2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_MainSensor1
            // 
            this.lb_MainSensor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_MainSensor1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_MainSensor1.Location = new System.Drawing.Point(86, 80);
            this.lb_MainSensor1.Name = "lb_MainSensor1";
            this.lb_MainSensor1.Size = new System.Drawing.Size(59, 25);
            this.lb_MainSensor1.TabIndex = 91;
            this.lb_MainSensor1.Text = "0.00";
            this.lb_MainSensor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wy
            // 
            this.wy.AutoSize = true;
            this.wy.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wy.Location = new System.Drawing.Point(355, 19);
            this.wy.Name = "wy";
            this.wy.Size = new System.Drawing.Size(42, 21);
            this.wy.TabIndex = 92;
            this.wy.Text = "稳压";
            // 
            // lb_CurrentSensor
            // 
            this.lb_CurrentSensor.AutoSize = true;
            this.lb_CurrentSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_CurrentSensor.Location = new System.Drawing.Point(166, 19);
            this.lb_CurrentSensor.Name = "lb_CurrentSensor";
            this.lb_CurrentSensor.Size = new System.Drawing.Size(58, 21);
            this.lb_CurrentSensor.TabIndex = 93;
            this.lb_CurrentSensor.Text = "传感器";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(13, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 21);
            this.label14.TabIndex = 94;
            this.label14.Text = "当前使用传感器为 :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(362, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 15);
            this.label13.TabIndex = 95;
            this.label13.Text = "MPa";
            // 
            // MainSensor1
            // 
            this.MainSensor1.AutoSize = true;
            this.MainSensor1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainSensor1.Location = new System.Drawing.Point(26, 82);
            this.MainSensor1.Name = "MainSensor1";
            this.MainSensor1.Size = new System.Drawing.Size(56, 21);
            this.MainSensor1.TabIndex = 96;
            this.MainSensor1.Text = "PT223";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(144, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 15);
            this.label11.TabIndex = 97;
            this.label11.Text = "MPa";
            // 
            // rb_MainSensor
            // 
            this.rb_MainSensor.AutoSize = true;
            this.rb_MainSensor.Location = new System.Drawing.Point(30, 13);
            this.rb_MainSensor.Name = "rb_MainSensor";
            this.rb_MainSensor.Size = new System.Drawing.Size(92, 25);
            this.rb_MainSensor.TabIndex = 262;
            this.rb_MainSensor.Tag = "1";
            this.rb_MainSensor.Text = "主传感器";
            this.rb_MainSensor.UseVisualStyleBackColor = true;
            this.rb_MainSensor.CheckedChanged += new System.EventHandler(this.rb_MainSensor_CheckedChanged);
            // 
            // rb_BackupSensor
            // 
            this.rb_BackupSensor.AutoSize = true;
            this.rb_BackupSensor.Location = new System.Drawing.Point(222, 13);
            this.rb_BackupSensor.Name = "rb_BackupSensor";
            this.rb_BackupSensor.Size = new System.Drawing.Size(92, 25);
            this.rb_BackupSensor.TabIndex = 266;
            this.rb_BackupSensor.Tag = "2";
            this.rb_BackupSensor.Text = "备传感器";
            this.rb_BackupSensor.UseVisualStyleBackColor = true;
            this.rb_BackupSensor.CheckedChanged += new System.EventHandler(this.rb_MainSensor_CheckedChanged);
            // 
            // CB_OxygenSensorBackup
            // 
            this.CB_OxygenSensorBackup.FormattingEnabled = true;
            this.CB_OxygenSensorBackup.Location = new System.Drawing.Point(317, 12);
            this.CB_OxygenSensorBackup.Name = "CB_OxygenSensorBackup";
            this.CB_OxygenSensorBackup.Size = new System.Drawing.Size(80, 29);
            this.CB_OxygenSensorBackup.TabIndex = 265;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.FuelBackupSensor);
            this.panel3.Controls.Add(this.lb_FuelBackupSensor);
            this.panel3.Controls.Add(this.lb_FuelMainSensor);
            this.panel3.Controls.Add(this.lb_FuelWY);
            this.panel3.Controls.Add(this.lb_FuelCurrentSensor);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.FuelMainSensor);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Location = new System.Drawing.Point(22, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(411, 124);
            this.panel3.TabIndex = 261;
            // 
            // FuelBackupSensor
            // 
            this.FuelBackupSensor.AutoSize = true;
            this.FuelBackupSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FuelBackupSensor.Location = new System.Drawing.Point(232, 82);
            this.FuelBackupSensor.Name = "FuelBackupSensor";
            this.FuelBackupSensor.Size = new System.Drawing.Size(66, 21);
            this.FuelBackupSensor.TabIndex = 89;
            this.FuelBackupSensor.Text = "PT223b";
            // 
            // lb_FuelBackupSensor
            // 
            this.lb_FuelBackupSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_FuelBackupSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FuelBackupSensor.Location = new System.Drawing.Point(304, 80);
            this.lb_FuelBackupSensor.Name = "lb_FuelBackupSensor";
            this.lb_FuelBackupSensor.Size = new System.Drawing.Size(59, 25);
            this.lb_FuelBackupSensor.TabIndex = 90;
            this.lb_FuelBackupSensor.Text = "0.00";
            this.lb_FuelBackupSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_FuelMainSensor
            // 
            this.lb_FuelMainSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_FuelMainSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FuelMainSensor.Location = new System.Drawing.Point(86, 80);
            this.lb_FuelMainSensor.Name = "lb_FuelMainSensor";
            this.lb_FuelMainSensor.Size = new System.Drawing.Size(59, 25);
            this.lb_FuelMainSensor.TabIndex = 91;
            this.lb_FuelMainSensor.Text = "0.00";
            this.lb_FuelMainSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_FuelWY
            // 
            this.lb_FuelWY.AutoSize = true;
            this.lb_FuelWY.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FuelWY.Location = new System.Drawing.Point(355, 19);
            this.lb_FuelWY.Name = "lb_FuelWY";
            this.lb_FuelWY.Size = new System.Drawing.Size(42, 21);
            this.lb_FuelWY.TabIndex = 92;
            this.lb_FuelWY.Text = "稳压";
            // 
            // lb_FuelCurrentSensor
            // 
            this.lb_FuelCurrentSensor.AutoSize = true;
            this.lb_FuelCurrentSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_FuelCurrentSensor.Location = new System.Drawing.Point(166, 19);
            this.lb_FuelCurrentSensor.Name = "lb_FuelCurrentSensor";
            this.lb_FuelCurrentSensor.Size = new System.Drawing.Size(58, 21);
            this.lb_FuelCurrentSensor.TabIndex = 93;
            this.lb_FuelCurrentSensor.Text = "传感器";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(13, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(147, 21);
            this.label18.TabIndex = 94;
            this.label18.Text = "当前使用传感器为 :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(362, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 15);
            this.label19.TabIndex = 95;
            this.label19.Text = "MPa";
            // 
            // FuelMainSensor
            // 
            this.FuelMainSensor.AutoSize = true;
            this.FuelMainSensor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FuelMainSensor.Location = new System.Drawing.Point(25, 82);
            this.FuelMainSensor.Name = "FuelMainSensor";
            this.FuelMainSensor.Size = new System.Drawing.Size(56, 21);
            this.FuelMainSensor.TabIndex = 96;
            this.FuelMainSensor.Text = "PT223";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(144, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 15);
            this.label21.TabIndex = 97;
            this.label21.Text = "MPa";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CB_FuelSensorMain);
            this.panel4.Controls.Add(this.rb_FuelBackupSensor);
            this.panel4.Controls.Add(this.rb_FuelMainSensor);
            this.panel4.Controls.Add(this.CB_FuelSensorBackup);
            this.panel4.Location = new System.Drawing.Point(23, 210);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(411, 52);
            this.panel4.TabIndex = 267;
            // 
            // CB_FuelSensorMain
            // 
            this.CB_FuelSensorMain.FormattingEnabled = true;
            this.CB_FuelSensorMain.Location = new System.Drawing.Point(120, 12);
            this.CB_FuelSensorMain.Name = "CB_FuelSensorMain";
            this.CB_FuelSensorMain.Size = new System.Drawing.Size(80, 29);
            this.CB_FuelSensorMain.TabIndex = 267;
            // 
            // rb_FuelBackupSensor
            // 
            this.rb_FuelBackupSensor.AutoSize = true;
            this.rb_FuelBackupSensor.Location = new System.Drawing.Point(214, 13);
            this.rb_FuelBackupSensor.Name = "rb_FuelBackupSensor";
            this.rb_FuelBackupSensor.Size = new System.Drawing.Size(92, 25);
            this.rb_FuelBackupSensor.TabIndex = 270;
            this.rb_FuelBackupSensor.Tag = "2";
            this.rb_FuelBackupSensor.Text = "备传感器";
            this.rb_FuelBackupSensor.UseVisualStyleBackColor = true;
            this.rb_FuelBackupSensor.CheckedChanged += new System.EventHandler(this.rb_FuelBackupSensor_CheckedChanged);
            // 
            // rb_FuelMainSensor
            // 
            this.rb_FuelMainSensor.AutoSize = true;
            this.rb_FuelMainSensor.Location = new System.Drawing.Point(22, 13);
            this.rb_FuelMainSensor.Name = "rb_FuelMainSensor";
            this.rb_FuelMainSensor.Size = new System.Drawing.Size(92, 25);
            this.rb_FuelMainSensor.TabIndex = 268;
            this.rb_FuelMainSensor.Tag = "1";
            this.rb_FuelMainSensor.Text = "主传感器";
            this.rb_FuelMainSensor.UseVisualStyleBackColor = true;
            this.rb_FuelMainSensor.CheckedChanged += new System.EventHandler(this.rb_FuelBackupSensor_CheckedChanged);
            // 
            // CB_FuelSensorBackup
            // 
            this.CB_FuelSensorBackup.FormattingEnabled = true;
            this.CB_FuelSensorBackup.Location = new System.Drawing.Point(309, 12);
            this.CB_FuelSensorBackup.Name = "CB_FuelSensorBackup";
            this.CB_FuelSensorBackup.Size = new System.Drawing.Size(80, 29);
            this.CB_FuelSensorBackup.TabIndex = 269;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.CB_OxygenSensorMain);
            this.panel5.Controls.Add(this.rb_BackupSensor);
            this.panel5.Controls.Add(this.rb_MainSensor);
            this.panel5.Controls.Add(this.CB_OxygenSensorBackup);
            this.panel5.Location = new System.Drawing.Point(462, 210);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(411, 52);
            this.panel5.TabIndex = 267;
            // 
            // PressureStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 448);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
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
            this.Controls.Add(this.CB_Station);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CB_Fuel);
            this.Controls.Add(this.CB_FuelFlow);
            this.Controls.Add(this.btn_endFuel);
            this.Controls.Add(this.btn_startFuel);
            this.Controls.Add(this.btn_pointFuel);
            this.Controls.Add(this.txt_Fuel_P);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_FuelFlow;
        private System.Windows.Forms.ComboBox CB_OxygenSensorMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_Fuel;
        private System.Windows.Forms.ComboBox CB_Station;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rb_MainSensor;
        private System.Windows.Forms.RadioButton rb_BackupSensor;
        private System.Windows.Forms.ComboBox CB_OxygenSensorBackup;
        private System.Windows.Forms.Label MainSensor2;
        private System.Windows.Forms.Label lb_MainSensor2;
        private System.Windows.Forms.Label lb_MainSensor1;
        private System.Windows.Forms.Label wy;
        private System.Windows.Forms.Label lb_CurrentSensor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label MainSensor1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label FuelBackupSensor;
        private System.Windows.Forms.Label lb_FuelBackupSensor;
        private System.Windows.Forms.Label lb_FuelMainSensor;
        private System.Windows.Forms.Label lb_FuelWY;
        private System.Windows.Forms.Label lb_FuelCurrentSensor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label FuelMainSensor;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CB_FuelSensorMain;
        private System.Windows.Forms.RadioButton rb_FuelBackupSensor;
        private System.Windows.Forms.RadioButton rb_FuelMainSensor;
        private System.Windows.Forms.ComboBox CB_FuelSensorBackup;
        private System.Windows.Forms.Panel panel5;
    }
}