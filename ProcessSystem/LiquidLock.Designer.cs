namespace ProcessSystem
{
    partial class LiquidLock
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
            this.pl_high = new System.Windows.Forms.Panel();
            this.lb_Title = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Label();
            this.tb_HighValue = new System.Windows.Forms.TextBox();
            this.btn_HighSet = new Sunny.UI.UISymbolButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pl_Low = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Low = new Sunny.UI.UISymbolButton();
            this.tb_LowValue = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pl_Low.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panel1.Controls.Add(this.pl_high);
            this.panel1.Controls.Add(this.lb_Title);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 44);
            this.panel1.TabIndex = 41;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // pl_high
            // 
            this.pl_high.Location = new System.Drawing.Point(0, 47);
            this.pl_high.Name = "pl_high";
            this.pl_high.Size = new System.Drawing.Size(438, 100);
            this.pl_high.TabIndex = 38;
            this.pl_high.Visible = false;
            // 
            // lb_Title
            // 
            this.lb_Title.ForeColor = System.Drawing.Color.White;
            this.lb_Title.Location = new System.Drawing.Point(47, 0);
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
            this.btn_Close.Location = new System.Drawing.Point(390, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(42, 44);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "X";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tb_HighValue
            // 
            this.tb_HighValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_HighValue.Location = new System.Drawing.Point(160, 78);
            this.tb_HighValue.Name = "tb_HighValue";
            this.tb_HighValue.Size = new System.Drawing.Size(127, 29);
            this.tb_HighValue.TabIndex = 44;
            // 
            // btn_HighSet
            // 
            this.btn_HighSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_HighSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Location = new System.Drawing.Point(332, 73);
            this.btn_HighSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_HighSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_HighSet.Name = "btn_HighSet";
            this.btn_HighSet.Size = new System.Drawing.Size(70, 34);
            this.btn_HighSet.Symbol = 61459;
            this.btn_HighSet.TabIndex = 42;
            this.btn_HighSet.Text = "设定";
            this.btn_HighSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Click += new System.EventHandler(this.btn_HighSet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 43;
            this.label4.Text = "高限报警设定 ：";
            // 
            // pl_Low
            // 
            this.pl_Low.Controls.Add(this.tb_LowValue);
            this.pl_Low.Controls.Add(this.label1);
            this.pl_Low.Controls.Add(this.btn_Low);
            this.pl_Low.Location = new System.Drawing.Point(12, 122);
            this.pl_Low.Name = "pl_Low";
            this.pl_Low.Size = new System.Drawing.Size(408, 60);
            this.pl_Low.TabIndex = 45;
            this.pl_Low.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 22);
            this.label1.TabIndex = 43;
            this.label1.Text = "低限报警设定 ：";
            // 
            // btn_Low
            // 
            this.btn_Low.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Low.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Low.Location = new System.Drawing.Point(320, 14);
            this.btn_Low.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Low.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_Low.Name = "btn_Low";
            this.btn_Low.Size = new System.Drawing.Size(70, 34);
            this.btn_Low.Symbol = 61459;
            this.btn_Low.TabIndex = 42;
            this.btn_Low.Text = "设定";
            this.btn_Low.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Low.Click += new System.EventHandler(this.btn_LowSet_Click);
            // 
            // tb_LowValue
            // 
            this.tb_LowValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_LowValue.Location = new System.Drawing.Point(148, 19);
            this.tb_LowValue.Name = "tb_LowValue";
            this.tb_LowValue.Size = new System.Drawing.Size(127, 29);
            this.tb_LowValue.TabIndex = 44;
            // 
            // LiquidLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 194);
            this.Controls.Add(this.pl_Low);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_HighValue);
            this.Controls.Add(this.btn_HighSet);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "LiquidLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiquidLock";
            this.panel1.ResumeLayout(false);
            this.pl_Low.ResumeLayout(false);
            this.pl_Low.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pl_high;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.TextBox tb_HighValue;
        private Sunny.UI.UISymbolButton btn_HighSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pl_Low;
        private System.Windows.Forms.TextBox tb_LowValue;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISymbolButton btn_Low;
    }
}