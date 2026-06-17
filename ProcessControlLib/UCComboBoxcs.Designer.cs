namespace ProcessControlLib
{
    partial class UCComboBoxcs
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
            this.lb_Value = new System.Windows.Forms.Label();
            this.lb_Unit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Value
            // 
            this.lb_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Value.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Value.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_Value.ForeColor = System.Drawing.Color.White;
            this.lb_Value.Location = new System.Drawing.Point(1, 1);
            this.lb_Value.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Value.Name = "lb_Value";
            this.lb_Value.Size = new System.Drawing.Size(61, 29);
            this.lb_Value.TabIndex = 0;
            this.lb_Value.Text = "0.00";
            this.lb_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Unit
            // 
            this.lb_Unit.BackColor = System.Drawing.Color.Transparent;
            this.lb_Unit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Unit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_Unit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Unit.ForeColor = System.Drawing.Color.White;
            this.lb_Unit.Location = new System.Drawing.Point(62, 1);
            this.lb_Unit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lb_Unit.Name = "lb_Unit";
            this.lb_Unit.Size = new System.Drawing.Size(47, 29);
            this.lb_Unit.TabIndex = 0;
            this.lb_Unit.Text = "L/Min";
            this.lb_Unit.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // UCComboBoxcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lb_Unit);
            this.Controls.Add(this.lb_Value);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UCComboBoxcs";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(107, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_Value;
        private System.Windows.Forms.Label lb_Unit;
    }
}
