namespace ProcessSystem
{
    partial class TempLock
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
            this.panel1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(438, 44);
            this.panel1.TabIndex = 37;
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
            this.btn_Close.Location = new System.Drawing.Point(396, 0);
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
            this.tb_HighValue.Location = new System.Drawing.Point(170, 85);
            this.tb_HighValue.Name = "tb_HighValue";
            this.tb_HighValue.Size = new System.Drawing.Size(127, 29);
            this.tb_HighValue.TabIndex = 40;
            // 
            // btn_HighSet
            // 
            this.btn_HighSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_HighSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Location = new System.Drawing.Point(332, 80);
            this.btn_HighSet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_HighSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_HighSet.Name = "btn_HighSet";
            this.btn_HighSet.Size = new System.Drawing.Size(70, 34);
            this.btn_HighSet.Symbol = 61459;
            this.btn_HighSet.TabIndex = 38;
            this.btn_HighSet.Text = "设定";
            this.btn_HighSet.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_HighSet.Click += new System.EventHandler(this.btn_HighSet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "高限报警设定 ：";
            // 
            // TempLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 149);
            this.Controls.Add(this.tb_HighValue);
            this.Controls.Add(this.btn_HighSet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TempLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempLock";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Label btn_Close;
        private System.Windows.Forms.Panel pl_high;
        private System.Windows.Forms.TextBox tb_HighValue;
        private Sunny.UI.UISymbolButton btn_HighSet;
        private System.Windows.Forms.Label label4;
    }
}