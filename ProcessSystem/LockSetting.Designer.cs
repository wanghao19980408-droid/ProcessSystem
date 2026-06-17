namespace ProcessSystem
{
    partial class LockSetting
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
            this.btn_ModeSet = new Sunny.UI.UISymbolButton();
            this.lb_Title = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ValueSet = new Sunny.UI.UISymbolButton();
            this.btn_HighSet = new Sunny.UI.UISymbolButton();
            this.btn_LowSet = new Sunny.UI.UISymbolButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ModeValue = new System.Windows.Forms.ComboBox();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.tb_HighValue = new System.Windows.Forms.TextBox();
            this.tb_LowValue = new System.Windows.Forms.TextBox();
            this.pl_Normal = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pl_CPb = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pl_HPb23 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pl_GPb16 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.pl_Save = new System.Windows.Forms.Panel();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.pl_mode = new System.Windows.Forms.Panel();
            this.pl_Set = new System.Windows.Forms.Panel();
            this.pl_high = new System.Windows.Forms.Panel();
            this.pl_low = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pl_Normal.SuspendLayout();
            this.pl_CPb.SuspendLayout();
            this.pl_HPb23.SuspendLayout();
            this.pl_GPb16.SuspendLayout();
            this.pl_Save.SuspendLayout();
            this.pl_mode.SuspendLayout();
            this.pl_Set.SuspendLayout();
            this.pl_high.SuspendLayout();
            this.pl_low.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ModeSet
            // 
            this.btn_ModeSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ModeSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeSet.Location = new System.Drawing.Point(459, 17);
            this.btn_ModeSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_ModeSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ModeSet.Name = "btn_ModeSet";
            this.btn_ModeSet.Size = new System.Drawing.Size(70, 34);
            this.btn_ModeSet.Symbol = 61459;
            this.btn_ModeSet.TabIndex = 20;
            this.btn_ModeSet.Text = "设定";
            this.btn_ModeSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeSet.Click += new System.EventHandler(this.btn_ModeSet_Click);
            // 
            // lb_Title
            // 
            this.lb_Title.ForeColor = System.Drawing.Color.White;
            this.lb_Title.Location = new System.Drawing.Point(175, 0);
            this.lb_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(338, 44);
            this.lb_Title.TabIndex = 2;
            this.lb_Title.Text = "连锁设定";
            this.lb_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.lb_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(620, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(42, 44);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.lb_Title);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 44);
            this.panel1.TabIndex = 17;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_ValueSet
            // 
            this.btn_ValueSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ValueSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ValueSet.Location = new System.Drawing.Point(458, 14);
            this.btn_ValueSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_ValueSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_ValueSet.Name = "btn_ValueSet";
            this.btn_ValueSet.Size = new System.Drawing.Size(70, 34);
            this.btn_ValueSet.Symbol = 61459;
            this.btn_ValueSet.TabIndex = 20;
            this.btn_ValueSet.Text = "设定";
            this.btn_ValueSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ValueSet.Click += new System.EventHandler(this.btn_ValueSet_Click);
            // 
            // btn_HighSet
            // 
            this.btn_HighSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_HighSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Location = new System.Drawing.Point(461, 18);
            this.btn_HighSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_HighSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_HighSet.Name = "btn_HighSet";
            this.btn_HighSet.Size = new System.Drawing.Size(70, 34);
            this.btn_HighSet.Symbol = 61459;
            this.btn_HighSet.TabIndex = 20;
            this.btn_HighSet.Text = "设定";
            this.btn_HighSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Click += new System.EventHandler(this.btn_HighSet_Click);
            // 
            // btn_LowSet
            // 
            this.btn_LowSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LowSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LowSet.Location = new System.Drawing.Point(461, 14);
            this.btn_LowSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_LowSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_LowSet.Name = "btn_LowSet";
            this.btn_LowSet.Size = new System.Drawing.Size(70, 34);
            this.btn_LowSet.Symbol = 61459;
            this.btn_LowSet.TabIndex = 20;
            this.btn_LowSet.Text = "设定";
            this.btn_LowSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LowSet.Click += new System.EventHandler(this.btn_LowSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(137, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "模式设定 ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(136, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "额定设定 ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(132, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "高限报警设定 ：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(132, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "低限报警设定 ：";
            // 
            // cb_ModeValue
            // 
            this.cb_ModeValue.FormattingEnabled = true;
            this.cb_ModeValue.Location = new System.Drawing.Point(268, 17);
            this.cb_ModeValue.Name = "cb_ModeValue";
            this.cb_ModeValue.Size = new System.Drawing.Size(155, 30);
            this.cb_ModeValue.TabIndex = 22;
            // 
            // tb_Value
            // 
            this.tb_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Value.Location = new System.Drawing.Point(267, 17);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(127, 29);
            this.tb_Value.TabIndex = 23;
            // 
            // tb_HighValue
            // 
            this.tb_HighValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_HighValue.Location = new System.Drawing.Point(271, 18);
            this.tb_HighValue.Name = "tb_HighValue";
            this.tb_HighValue.Size = new System.Drawing.Size(127, 29);
            this.tb_HighValue.TabIndex = 23;
            // 
            // tb_LowValue
            // 
            this.tb_LowValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_LowValue.Location = new System.Drawing.Point(271, 19);
            this.tb_LowValue.Name = "tb_LowValue";
            this.tb_LowValue.Size = new System.Drawing.Size(127, 29);
            this.tb_LowValue.TabIndex = 23;
            // 
            // pl_Normal
            // 
            this.pl_Normal.Controls.Add(this.button3);
            this.pl_Normal.Controls.Add(this.button2);
            this.pl_Normal.Controls.Add(this.button1);
            this.pl_Normal.Location = new System.Drawing.Point(3, 324);
            this.pl_Normal.Name = "pl_Normal";
            this.pl_Normal.Size = new System.Drawing.Size(662, 74);
            this.pl_Normal.TabIndex = 25;
            this.pl_Normal.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(469, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 40);
            this.button3.TabIndex = 25;
            this.button3.Tag = "1";
            this.button3.Text = "停止充气";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 40);
            this.button2.TabIndex = 26;
            this.button2.Tag = "3";
            this.button2.Text = "供气2路充气启动";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 40);
            this.button1.TabIndex = 27;
            this.button1.Tag = "2";
            this.button1.Text = "供气1路充气启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // pl_CPb
            // 
            this.pl_CPb.Controls.Add(this.button5);
            this.pl_CPb.Controls.Add(this.button6);
            this.pl_CPb.Location = new System.Drawing.Point(3, 324);
            this.pl_CPb.Name = "pl_CPb";
            this.pl_CPb.Size = new System.Drawing.Size(659, 74);
            this.pl_CPb.TabIndex = 25;
            this.pl_CPb.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(423, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 40);
            this.button5.TabIndex = 26;
            this.button5.Tag = "2";
            this.button5.Text = "放气";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(137, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 40);
            this.button6.TabIndex = 27;
            this.button6.Tag = "1";
            this.button6.Text = "供气";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // pl_HPb23
            // 
            this.pl_HPb23.Controls.Add(this.button9);
            this.pl_HPb23.Controls.Add(this.button8);
            this.pl_HPb23.Controls.Add(this.button4);
            this.pl_HPb23.Controls.Add(this.button7);
            this.pl_HPb23.Location = new System.Drawing.Point(3, 324);
            this.pl_HPb23.Name = "pl_HPb23";
            this.pl_HPb23.Size = new System.Drawing.Size(662, 74);
            this.pl_HPb23.TabIndex = 25;
            this.pl_HPb23.Visible = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(503, 17);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(103, 40);
            this.button9.TabIndex = 26;
            this.button9.Tag = "1";
            this.button9.Text = "停止";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(360, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(103, 40);
            this.button8.TabIndex = 26;
            this.button8.Tag = "4";
            this.button8.Text = "供气启动";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(212, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 40);
            this.button4.TabIndex = 26;
            this.button4.Tag = "3";
            this.button4.Text = "放气2路启动";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(57, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 40);
            this.button7.TabIndex = 27;
            this.button7.Tag = "2";
            this.button7.Text = "放气1路启动";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // pl_GPb16
            // 
            this.pl_GPb16.Controls.Add(this.button13);
            this.pl_GPb16.Controls.Add(this.button12);
            this.pl_GPb16.Controls.Add(this.button14);
            this.pl_GPb16.Controls.Add(this.button11);
            this.pl_GPb16.Controls.Add(this.button15);
            this.pl_GPb16.Location = new System.Drawing.Point(3, 324);
            this.pl_GPb16.Name = "pl_GPb16";
            this.pl_GPb16.Size = new System.Drawing.Size(662, 74);
            this.pl_GPb16.TabIndex = 25;
            this.pl_GPb16.Visible = false;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button13.Location = new System.Drawing.Point(587, 18);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(56, 40);
            this.button13.TabIndex = 26;
            this.button13.Tag = "1";
            this.button13.Text = "停止";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.Location = new System.Drawing.Point(443, 18);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(138, 40);
            this.button12.TabIndex = 26;
            this.button12.Tag = "5";
            this.button12.Text = "25MPa供气2启动";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button14.Location = new System.Drawing.Point(155, 18);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(138, 40);
            this.button14.TabIndex = 26;
            this.button14.Tag = "3";
            this.button14.Text = "10MPa供气2启动";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button11.Location = new System.Drawing.Point(299, 18);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(138, 40);
            this.button11.TabIndex = 27;
            this.button11.Tag = "4";
            this.button11.Text = "25MPa供气1启动";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.Location = new System.Drawing.Point(11, 18);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(138, 40);
            this.button15.TabIndex = 27;
            this.button15.Tag = "2";
            this.button15.Text = "10MPa供气1启动";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // pl_Save
            // 
            this.pl_Save.Controls.Add(this.button16);
            this.pl_Save.Controls.Add(this.button17);
            this.pl_Save.Controls.Add(this.button18);
            this.pl_Save.Location = new System.Drawing.Point(3, 324);
            this.pl_Save.Name = "pl_Save";
            this.pl_Save.Size = new System.Drawing.Size(662, 74);
            this.pl_Save.TabIndex = 25;
            this.pl_Save.Visible = false;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(462, 21);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(110, 40);
            this.button16.TabIndex = 25;
            this.button16.Tag = "1";
            this.button16.Text = "停止";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(270, 21);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(148, 40);
            this.button17.TabIndex = 26;
            this.button17.Tag = "3";
            this.button17.Text = "放气";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(78, 21);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(148, 40);
            this.button18.TabIndex = 27;
            this.button18.Tag = "2";
            this.button18.Text = "供气";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.btn_GaseModeSet_Click);
            // 
            // pl_mode
            // 
            this.pl_mode.Controls.Add(this.cb_ModeValue);
            this.pl_mode.Controls.Add(this.btn_ModeSet);
            this.pl_mode.Controls.Add(this.label1);
            this.pl_mode.Location = new System.Drawing.Point(2, 62);
            this.pl_mode.Name = "pl_mode";
            this.pl_mode.Size = new System.Drawing.Size(663, 67);
            this.pl_mode.TabIndex = 26;
            // 
            // pl_Set
            // 
            this.pl_Set.Controls.Add(this.btn_ValueSet);
            this.pl_Set.Controls.Add(this.label3);
            this.pl_Set.Controls.Add(this.tb_Value);
            this.pl_Set.Location = new System.Drawing.Point(2, 131);
            this.pl_Set.Name = "pl_Set";
            this.pl_Set.Size = new System.Drawing.Size(663, 67);
            this.pl_Set.TabIndex = 27;
            // 
            // pl_high
            // 
            this.pl_high.Controls.Add(this.tb_HighValue);
            this.pl_high.Controls.Add(this.btn_HighSet);
            this.pl_high.Controls.Add(this.label4);
            this.pl_high.Location = new System.Drawing.Point(-1, 195);
            this.pl_high.Name = "pl_high";
            this.pl_high.Size = new System.Drawing.Size(663, 71);
            this.pl_high.TabIndex = 28;
            // 
            // pl_low
            // 
            this.pl_low.Controls.Add(this.tb_LowValue);
            this.pl_low.Controls.Add(this.btn_LowSet);
            this.pl_low.Controls.Add(this.label5);
            this.pl_low.Location = new System.Drawing.Point(-1, 258);
            this.pl_low.Name = "pl_low";
            this.pl_low.Size = new System.Drawing.Size(663, 67);
            this.pl_low.TabIndex = 29;
            // 
            // LockSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 400);
            this.Controls.Add(this.pl_low);
            this.Controls.Add(this.pl_high);
            this.Controls.Add(this.pl_Set);
            this.Controls.Add(this.pl_mode);
            this.Controls.Add(this.pl_Normal);
            this.Controls.Add(this.pl_CPb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pl_GPb16);
            this.Controls.Add(this.pl_Save);
            this.Controls.Add(this.pl_HPb23);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LockSetting";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.pl_Normal.ResumeLayout(false);
            this.pl_CPb.ResumeLayout(false);
            this.pl_HPb23.ResumeLayout(false);
            this.pl_GPb16.ResumeLayout(false);
            this.pl_Save.ResumeLayout(false);
            this.pl_mode.ResumeLayout(false);
            this.pl_mode.PerformLayout();
            this.pl_Set.ResumeLayout(false);
            this.pl_Set.PerformLayout();
            this.pl_high.ResumeLayout(false);
            this.pl_high.PerformLayout();
            this.pl_low.ResumeLayout(false);
            this.pl_low.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UISymbolButton btn_ModeSet;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UISymbolButton btn_ValueSet;
        private Sunny.UI.UISymbolButton btn_HighSet;
        private Sunny.UI.UISymbolButton btn_LowSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ModeValue;
        private System.Windows.Forms.TextBox tb_Value;
        private System.Windows.Forms.TextBox tb_HighValue;
        private System.Windows.Forms.TextBox tb_LowValue;
        private System.Windows.Forms.Panel pl_Normal;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pl_CPb;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel pl_HPb23;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel pl_GPb16;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Panel pl_Save;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Panel pl_mode;
        private System.Windows.Forms.Panel pl_Set;
        private System.Windows.Forms.Panel pl_high;
        private System.Windows.Forms.Panel pl_low;
    }
}