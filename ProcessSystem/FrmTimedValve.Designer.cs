namespace ProcessSystem
{
    partial class FrmMultiTimedValve
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvValves = new Sunny.UI.UIDataGridView();
            this.btnAddRow = new Sunny.UI.UIButton();
            this.btnStartAll = new Sunny.UI.UIButton();
            this.btnStopAll = new Sunny.UI.UIButton();
            this.rbParallel = new Sunny.UI.UIRadioButton();
            this.rbSequential = new Sunny.UI.UIRadioButton();
            this.colValveName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperate = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValves)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValves
            // 
            this.dgvValves.AllowUserToAddRows = false;
            this.dgvValves.AllowUserToDeleteRows = false;
            this.dgvValves.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvValves.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValves.BackgroundColor = System.Drawing.Color.White;
            this.dgvValves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvValves.ColumnHeadersHeight = 36;
            this.dgvValves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvValves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValveName,
            this.colAction,
            this.colDuration,
            this.colStatus,
            this.colOperate});
            this.dgvValves.EnableHeadersVisualStyles = false;
            this.dgvValves.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvValves.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvValves.Location = new System.Drawing.Point(15, 50);
            this.dgvValves.Name = "dgvValves";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValves.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvValves.RowHeadersVisible = false;
            this.dgvValves.RowHeadersWidth = 62;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValves.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvValves.RowTemplate.Height = 32;
            this.dgvValves.SelectedIndex = -1;
            this.dgvValves.Size = new System.Drawing.Size(770, 335);
            this.dgvValves.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvValves.TabIndex = 0;
            this.dgvValves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValves_CellContentClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Location = new System.Drawing.Point(15, 405);
            this.btnAddRow.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(110, 35);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "+ 添加一项";
            this.btnAddRow.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnStartAll.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnStartAll.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnStartAll.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnStartAll.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnStartAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartAll.Location = new System.Drawing.Point(540, 405);
            this.btnStartAll.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnStartAll.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnStartAll.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnStartAll.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnStartAll.Size = new System.Drawing.Size(120, 35);
            this.btnStartAll.TabIndex = 2;
            this.btnStartAll.Text = "开始执行";
            this.btnStartAll.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopAll.Enabled = false;
            this.btnStopAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnStopAll.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnStopAll.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnStopAll.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnStopAll.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnStopAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopAll.Location = new System.Drawing.Point(665, 405);
            this.btnStopAll.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnStopAll.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnStopAll.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnStopAll.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnStopAll.Size = new System.Drawing.Size(120, 35);
            this.btnStopAll.TabIndex = 3;
            this.btnStopAll.Text = "紧急停止";
            this.btnStopAll.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // rbParallel
            // 
            this.rbParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbParallel.Checked = true;
            this.rbParallel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbParallel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbParallel.Location = new System.Drawing.Point(310, 408);
            this.rbParallel.MinimumSize = new System.Drawing.Size(1, 1);
            this.rbParallel.Name = "rbParallel";
            this.rbParallel.Size = new System.Drawing.Size(110, 29);
            this.rbParallel.TabIndex = 4;
            this.rbParallel.Text = "同步执行";
            // 
            // rbSequential
            // 
            this.rbSequential.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSequential.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSequential.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbSequential.Location = new System.Drawing.Point(420, 408);
            this.rbSequential.MinimumSize = new System.Drawing.Size(1, 1);
            this.rbSequential.Name = "rbSequential";
            this.rbSequential.Size = new System.Drawing.Size(110, 29);
            this.rbSequential.TabIndex = 5;
            this.rbSequential.Text = "顺序执行";
            // 
            // colValveName
            // 
            this.colValveName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colValveName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValveName.FillWeight = 110F;
            this.colValveName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colValveName.HeaderText = "选择阀门";
            this.colValveName.MaxDropDownItems = 4;
            this.colValveName.MinimumWidth = 11;
            this.colValveName.Name = "colValveName";
            this.colValveName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colAction
            // 
            this.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAction.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAction.FillWeight = 110F;
            this.colAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colAction.HeaderText = "执行动作";
            this.colAction.Items.AddRange(new object[] {
            "开启",
            "关闭"});
            this.colAction.MaxDropDownItems = 4;
            this.colAction.MinimumWidth = 11;
            this.colAction.Name = "colAction";
            this.colAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDuration
            // 
            this.colDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuration.FillWeight = 90F;
            this.colDuration.HeaderText = "保持时间(秒)";
            this.colDuration.MinimumWidth = 11;
            this.colDuration.Name = "colDuration";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.FillWeight = 130F;
            this.colStatus.HeaderText = "当前状态";
            this.colStatus.MinimumWidth = 11;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colOperate
            // 
            this.colOperate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(15, 2, 15, 2);
            this.colOperate.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOperate.FillWeight = 70F;
            this.colOperate.HeaderText = "操作";
            this.colOperate.MinimumWidth = 11;
            this.colOperate.Name = "colOperate";
            this.colOperate.Text = "删除";
            this.colOperate.UseColumnTextForButtonValue = true;
            // 
            // FrmMultiTimedValve
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.rbSequential);
            this.Controls.Add(this.rbParallel);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStartAll);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.dgvValves);
            this.MaximizeBox = false;
            this.Name = "FrmMultiTimedValve";
            this.Text = "阀门批量定时控制器";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 460);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dgvValves;
        private Sunny.UI.UIButton btnAddRow;
        private Sunny.UI.UIButton btnStartAll;
        private Sunny.UI.UIButton btnStopAll;
        private Sunny.UI.UIRadioButton rbParallel;
        private Sunny.UI.UIRadioButton rbSequential;
        private System.Windows.Forms.DataGridViewComboBoxColumn colValveName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colOperate;
    }
}