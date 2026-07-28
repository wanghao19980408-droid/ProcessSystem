namespace ProcessSystem
{
    partial class FormSequenceSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btn_CLose = new Sunny.UI.UISymbolButton();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnSetting = new Sunny.UI.UISymbolButton();
            this.btnDelete = new Sunny.UI.UISymbolButton();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvSequence = new Sunny.UI.UIDataGridView();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSequence)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(59)))), ((int)(((byte)(138)))));
            this.panelTop.Controls.Add(this.btn_CLose);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(896, 40);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
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
            this.btn_CLose.Location = new System.Drawing.Point(842, 0);
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
            this.btn_CLose.TabIndex = 426;
            this.btn_CLose.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btn_CLose.TipsFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CLose.TipsForeColor = System.Drawing.Color.Black;
            this.btn_CLose.TipsText = "关闭";
            this.btn_CLose.Click += new System.EventHandler(this.btn_CLose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(14, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(254, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "箱压自动调节时序设置";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelBottom.Controls.Add(this.uiSymbolButton1);
            this.panelBottom.Controls.Add(this.btnSetting);
            this.panelBottom.Controls.Add(this.btnDelete);
            this.panelBottom.Controls.Add(this.btnAdd);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(2, 538);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(896, 60);
            this.panelBottom.TabIndex = 1;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.SeaGreen;
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.MediumSeaGreen;
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.DarkGreen;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(567, 12);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton1.Size = new System.Drawing.Size(120, 38);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 61459;
            this.uiSymbolButton1.TabIndex = 2;
            this.uiSymbolButton1.Text = "设定";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FillColor = System.Drawing.Color.Gray;
            this.btnSetting.FillHoverColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSetting.FillPressColor = System.Drawing.Color.DarkGreen;
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Location = new System.Drawing.Point(707, 12);
            this.btnSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.RectColor = System.Drawing.Color.Transparent;
            this.btnSetting.Size = new System.Drawing.Size(173, 38);
            this.btnSetting.Style = Sunny.UI.UIStyle.Custom;
            this.btnSetting.Symbol = 61639;
            this.btnSetting.TabIndex = 2;
            this.btnSetting.Text = "投入";
            this.btnSetting.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FillColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FillHoverColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FillPressColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(155, 12);
            this.btnDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RectColor = System.Drawing.Color.Transparent;
            this.btnDelete.Size = new System.Drawing.Size(120, 38);
            this.btnDelete.Style = Sunny.UI.UIStyle.Custom;
            this.btnDelete.Symbol = 61460;
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除选中段";
            this.btnDelete.TipsFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FillHoverColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdd.FillPressColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(18, 12);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RectColor = System.Drawing.Color.Transparent;
            this.btnAdd.Size = new System.Drawing.Size(120, 38);
            this.btnAdd.Style = Sunny.UI.UIStyle.Custom;
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增段";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvSequence);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(2, 42);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(896, 496);
            this.panelMain.TabIndex = 2;
            // 
            // dgvSequence
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvSequence.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSequence.BackgroundColor = System.Drawing.Color.White;
            this.dgvSequence.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSequence.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSequence.ColumnHeadersHeight = 32;
            this.dgvSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSequence.EnableHeadersVisualStyles = false;
            this.dgvSequence.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSequence.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvSequence.Location = new System.Drawing.Point(0, 0);
            this.dgvSequence.Name = "dgvSequence";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSequence.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSequence.RowHeadersWidth = 62;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSequence.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSequence.RowTemplate.Height = 29;
            this.dgvSequence.SelectedIndex = -1;
            this.dgvSequence.Size = new System.Drawing.Size(896, 496);
            this.dgvSequence.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvSequence.TabIndex = 0;
            // 
            // FormSequenceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormSequenceSettings";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSequenceSettings";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSequence)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMain;
        private Sunny.UI.UISymbolButton btn_CLose;
        private System.Windows.Forms.Label labelTitle;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSetting;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UIDataGridView dgvSequence;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
    }
}