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
            this.btnBatchAdd = new Sunny.UI.UIButton();
            this.btnClear = new Sunny.UI.UIButton();
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvValves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvValves.ColumnHeadersHeight = 36;
            this.dgvValves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValveName,
            this.colAction,
            this.colDuration,
            this.colStatus,
            this.colOperate});
            this.dgvValves.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.dgvValves.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvValves.Location = new System.Drawing.Point(15, 50);
            this.dgvValves.Name = "dgvValves";
            this.dgvValves.RowHeadersVisible = false;
            this.dgvValves.Size = new System.Drawing.Size(770, 335);
            this.dgvValves.TabIndex = 0;
            this.dgvValves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValves_CellContentClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRow.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnAddRow.Location = new System.Drawing.Point(15, 405);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(100, 35);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "+添加一项";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnBatchAdd
            // 
            this.btnBatchAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchAdd.FillColor = System.Drawing.Color.Purple;
            this.btnBatchAdd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnBatchAdd.Location = new System.Drawing.Point(125, 405);
            this.btnBatchAdd.Name = "btnBatchAdd";
            this.btnBatchAdd.Size = new System.Drawing.Size(110, 35);
            this.btnBatchAdd.TabIndex = 6;
            this.btnBatchAdd.Text = "批量循环";
            this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FillColor = System.Drawing.Color.OrangeRed;
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClear.Location = new System.Drawing.Point(245, 405);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空全部";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rbParallel
            // 
            this.rbParallel.Checked = true;
            this.rbParallel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbParallel.Location = new System.Drawing.Point(345, 408);
            this.rbParallel.Name = "rbParallel";
            this.rbParallel.Size = new System.Drawing.Size(100, 29);
            this.rbParallel.TabIndex = 4;
            this.rbParallel.Text = "同步执行";
            // 
            // rbSequential
            // 
            this.rbSequential.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbSequential.Location = new System.Drawing.Point(445, 408);
            this.rbSequential.Name = "rbSequential";
            this.rbSequential.Size = new System.Drawing.Size(100, 29);
            this.rbSequential.TabIndex = 5;
            this.rbSequential.Text = "顺序执行";
            // 
            // btnStartAll
            // 
            this.btnStartAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnStartAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnStartAll.Location = new System.Drawing.Point(555, 405);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(110, 35);
            this.btnStartAll.TabIndex = 2;
            this.btnStartAll.Text = "开始执行";
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Enabled = false;
            this.btnStopAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnStopAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnStopAll.Location = new System.Drawing.Point(675, 405);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(110, 35);
            this.btnStopAll.TabIndex = 3;
            this.btnStopAll.Text = "紧急停止";
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // colValveName
            // 
            this.colValveName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValveName.HeaderText = "选择阀门";
            this.colValveName.Name = "colValveName";
            // 
            // colAction
            // 
            this.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAction.HeaderText = "执行动作";
            this.colAction.Items.AddRange(new object[] {
            "开启",
            "关闭",
            "等待"});
            this.colAction.Name = "colAction";
            // 
            // colDuration
            // 
            this.colDuration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuration.HeaderText = "保持时间(秒)";
            this.colDuration.Name = "colDuration";
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "当前状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colOperate
            // 
            this.colOperate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOperate.HeaderText = "操作";
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
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBatchAdd);
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
        private Sunny.UI.UIButton btnBatchAdd;
        private Sunny.UI.UIButton btnClear;
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