namespace ProcessSystem
{
    partial class DualFault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DualFault));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btn_CLose = new Sunny.UI.UISymbolButton();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.MainPanel.Controls.Add(this.btn_OK);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Controls.Add(this.lbl_Message);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(1, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(512, 291);
            this.MainPanel.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.btn_CLose);
            this.TopPanel.Controls.Add(this.lbl_Title);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(512, 52);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // btn_CLose
            // 
            this.btn_CLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CLose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CLose.FillColor = System.Drawing.Color.Transparent;
            this.btn_CLose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CLose.Location = new System.Drawing.Point(468, 0);
            this.btn_CLose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_CLose.Name = "btn_CLose";
            this.btn_CLose.RectColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectHoverColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectPressColor = System.Drawing.Color.Transparent;
            this.btn_CLose.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btn_CLose.Size = new System.Drawing.Size(44, 51);
            this.btn_CLose.Style = Sunny.UI.UIStyle.Custom;
            this.btn_CLose.Symbol = 558829;
            this.btn_CLose.SymbolHoverColor = System.Drawing.Color.Red;
            this.btn_CLose.SymbolPressColor = System.Drawing.Color.Lime;
            this.btn_CLose.SymbolSelectedColor = System.Drawing.Color.Lime;
            this.btn_CLose.SymbolSize = 40;
            this.btn_CLose.TabIndex = 430;
            this.btn_CLose.TipsColor = System.Drawing.Color.Transparent;
            this.btn_CLose.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CLose.TipsForeColor = System.Drawing.Color.Red;
            this.btn_CLose.Click += new System.EventHandler(this.btn_CLose_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(61, 15);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(191, 39);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "双路故障提示";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProcessSystem.Properties.Resources.Question;
            this.pictureBox1.Location = new System.Drawing.Point(18, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 1);
            this.label1.TabIndex = 1;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Message.ForeColor = System.Drawing.Color.White;
            this.lbl_Message.Location = new System.Drawing.Point(3, 81);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(503, 133);
            this.lbl_Message.TabIndex = 3;
            this.lbl_Message.Text = "严重警告】煤油系统双路传感器均发生严重偏差，自动增压已挂起，请立即人工介入！";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OK
            // 
            this.btn_OK.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg03;
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(194, 225);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(124, 40);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "确 定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click_1);
            // 
            // DualFault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 293);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DualFault";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "窗体确认";
            this.MainPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Message;
        private Sunny.UI.UISymbolButton btn_CLose;
        private System.Windows.Forms.Button btn_OK;
    }
}