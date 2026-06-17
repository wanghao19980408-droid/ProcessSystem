using ProcessSystemLib;

namespace ProcessControlLib
{
    partial class GaseSourceAdjustValve
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ucComboBoxcs1 = new UCComboBoxcs();
            this.button1 = new Sunny.UI.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(165, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 29);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucComboBoxcs1
            // 
            this.ucComboBoxcs1.BackColor = System.Drawing.Color.Transparent;
            this.ucComboBoxcs1.BValue = 0F;
            this.ucComboBoxcs1.CurrentRange = CurrentRange.FourToTwenty;
            this.ucComboBoxcs1.DecimalPlaces = 1;
            this.ucComboBoxcs1.Density = 1000F;
            this.ucComboBoxcs1.DigitalRange = 27648;
            this.ucComboBoxcs1.DirectCalibration = false;
            this.ucComboBoxcs1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucComboBoxcs1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucComboBoxcs1.Gravity = 9.8F;
            this.ucComboBoxcs1.InputType = InputValueType.PLC_Digital;
            this.ucComboBoxcs1.KValue = 1F;
            this.ucComboBoxcs1.Location = new System.Drawing.Point(85, 0);
            this.ucComboBoxcs1.Margin = new System.Windows.Forms.Padding(5);
            this.ucComboBoxcs1.MaxSensorRange = 1F;
            this.ucComboBoxcs1.MinSensorRange = 0F;
            this.ucComboBoxcs1.Name = "ucComboBoxcs1";
            this.ucComboBoxcs1.OriginalPressureUnit = Unit.Pa;
            this.ucComboBoxcs1.Padding = new System.Windows.Forms.Padding(1);
            this.ucComboBoxcs1.SensitivityCalibrationFactor = 1F;
            this.ucComboBoxcs1.SensorName = null;
            this.ucComboBoxcs1.SensorValue = null;
            this.ucComboBoxcs1.Size = new System.Drawing.Size(80, 30);
            this.ucComboBoxcs1.SpeedValue = 0F;
            this.ucComboBoxcs1.TabIndex = 22;
            this.ucComboBoxcs1.TankArea = 1F;
            this.ucComboBoxcs1.TFMState = false;
            this.ucComboBoxcs1.Unit = Unit.cent;
            this.ucComboBoxcs1.VoltageRange = VoltageRange.ZeroToFive;
            this.ucComboBoxcs1.ZeroOffset = 0F;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(233, 0);
            this.button1.MinimumSize = new System.Drawing.Size(1, 1);
            this.button1.Name = "button1";
            this.button1.Radius = 1;
            this.button1.Size = new System.Drawing.Size(49, 30);
            this.button1.Style = Sunny.UI.UIStyle.Custom;
            this.button1.TabIndex = 21;
            this.button1.Text = "调节";
            this.button1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 20;
            this.label1.Text = "调节阀";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GaseSourceAdjustValve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ucComboBoxcs1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "GaseSourceAdjustValve";
            this.Size = new System.Drawing.Size(282, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private UCComboBoxcs ucComboBoxcs1;
        private Sunny.UI.UIButton button1;
        private System.Windows.Forms.Label label1;
    }
}
