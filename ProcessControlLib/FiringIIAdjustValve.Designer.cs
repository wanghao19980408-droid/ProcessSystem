namespace ProcessControlLib
{
    partial class FiringIIAdjustValve
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucComboBoxcs1 = new ProcessControlLib.UCComboBoxcs();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new Sunny.UI.UIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucComboBoxcs1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "调节阀";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucComboBoxcs1
            // 
            this.ucComboBoxcs1.BackColor = System.Drawing.Color.Transparent;
            this.ucComboBoxcs1.BValue = 0F;
            this.ucComboBoxcs1.CurrentRange = ProcessSystemLib.CurrentRange.FourToTwenty;
            this.ucComboBoxcs1.DecimalPlaces = 2;
            this.ucComboBoxcs1.Density = 1000F;
            this.ucComboBoxcs1.DigitalRange = 27648;
            this.ucComboBoxcs1.DirectCalibration = false;
            this.ucComboBoxcs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucComboBoxcs1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucComboBoxcs1.Gravity = 9.8F;
            this.ucComboBoxcs1.InputType = ProcessSystemLib.InputValueType.PLC_Digital;
            this.ucComboBoxcs1.KValue = 1F;
            this.ucComboBoxcs1.Location = new System.Drawing.Point(64, 0);
            this.ucComboBoxcs1.Margin = new System.Windows.Forms.Padding(0);
            this.ucComboBoxcs1.MaxSensorRange = 1F;
            this.ucComboBoxcs1.MinSensorRange = 0F;
            this.ucComboBoxcs1.Name = "ucComboBoxcs1";
            this.ucComboBoxcs1.OriginalPressureUnit = ProcessSystemLib.Unit.Pa;
            this.ucComboBoxcs1.Padding = new System.Windows.Forms.Padding(1);
            this.ucComboBoxcs1.SensitivityCalibrationFactor = 1F;
            this.ucComboBoxcs1.SensorName = null;
            this.ucComboBoxcs1.SensorValue = null;
            this.ucComboBoxcs1.Size = new System.Drawing.Size(80, 32);
            this.ucComboBoxcs1.SpeedValue = 0F;
            this.ucComboBoxcs1.TabIndex = 6;
            this.ucComboBoxcs1.TankArea = 1F;
            this.ucComboBoxcs1.TFMState = false;
            this.ucComboBoxcs1.Unit = ProcessSystemLib.Unit.cent;
            this.ucComboBoxcs1.VoltageRange = ProcessSystemLib.VoltageRange.ZeroToFive;
            this.ucComboBoxcs1.ZeroOffset = 0F;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(147, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(225, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.Radius = 1;
            this.button1.Size = new System.Drawing.Size(55, 32);
            this.button1.Style = Sunny.UI.UIStyle.Custom;
            this.button1.TabIndex = 4;
            this.button1.Text = "调节";
            this.button1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FiringIIAdjustValve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FiringIIAdjustValve";
            this.Size = new System.Drawing.Size(280, 32);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton button1;
        private UCComboBoxcs ucComboBoxcs1;
        private System.Windows.Forms.TextBox textBox1;
    }
}