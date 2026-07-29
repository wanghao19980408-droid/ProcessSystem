namespace ProcessSystem
{
    partial class FrmUser
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
            this.xbdHeadPanel1 = new xbd.ControlLib.xbdHeadPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_Manager = new System.Windows.Forms.RadioButton();
            this.rb_Station2 = new System.Windows.Forms.RadioButton();
            this.rb_Station1 = new System.Windows.Forms.RadioButton();
            this.btn_ModifyUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
            this.btn_DeleteUser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_UserPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_UserManager = new System.Windows.Forms.DataGridView();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.xbdHeadPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManager)).BeginInit();
            this.SuspendLayout();
            // 
            // xbdHeadPanel1
            // 
            this.xbdHeadPanel1.BorderColor = System.Drawing.Color.Gray;
            this.xbdHeadPanel1.Controls.Add(this.panel1);
            this.xbdHeadPanel1.Controls.Add(this.button2);
            this.xbdHeadPanel1.Controls.Add(this.btn_ModifyUser);
            this.xbdHeadPanel1.Controls.Add(this.btn_AddUser);
            this.xbdHeadPanel1.Controls.Add(this.btn_DeleteUser);
            this.xbdHeadPanel1.Controls.Add(this.label4);
            this.xbdHeadPanel1.Controls.Add(this.label3);
            this.xbdHeadPanel1.Controls.Add(this.tb_UserPwd);
            this.xbdHeadPanel1.Controls.Add(this.label2);
            this.xbdHeadPanel1.Controls.Add(this.tb_UserName);
            this.xbdHeadPanel1.Controls.Add(this.label1);
            this.xbdHeadPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xbdHeadPanel1.HeadHeight = 30;
            this.xbdHeadPanel1.LinearGradientRate = 0.4F;
            this.xbdHeadPanel1.Location = new System.Drawing.Point(28, 37);
            this.xbdHeadPanel1.Name = "xbdHeadPanel1";
            this.xbdHeadPanel1.Size = new System.Drawing.Size(295, 421);
            this.xbdHeadPanel1.TabIndex = 0;
            this.xbdHeadPanel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xbdHeadPanel1.ThemeColor = System.Drawing.Color.DodgerBlue;
            this.xbdHeadPanel1.ThemeForeColor = System.Drawing.Color.White;
            this.xbdHeadPanel1.TitleText = "用户信息";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_Manager);
            this.panel1.Controls.Add(this.rb_Station2);
            this.panel1.Controls.Add(this.rb_Station1);
            this.panel1.Location = new System.Drawing.Point(3, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 61);
            this.panel1.TabIndex = 2;
            // 
            // rb_Manager
            // 
            this.rb_Manager.AutoSize = true;
            this.rb_Manager.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Manager.ForeColor = System.Drawing.Color.White;
            this.rb_Manager.Location = new System.Drawing.Point(198, 21);
            this.rb_Manager.Name = "rb_Manager";
            this.rb_Manager.Size = new System.Drawing.Size(76, 25);
            this.rb_Manager.TabIndex = 2;
            this.rb_Manager.TabStop = true;
            this.rb_Manager.Text = "管理员";
            this.rb_Manager.UseVisualStyleBackColor = true;
            // 
            // rb_Station2
            // 
            this.rb_Station2.AutoSize = true;
            this.rb_Station2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Station2.ForeColor = System.Drawing.Color.White;
            this.rb_Station2.Location = new System.Drawing.Point(109, 21);
            this.rb_Station2.Name = "rb_Station2";
            this.rb_Station2.Size = new System.Drawing.Size(69, 25);
            this.rb_Station2.TabIndex = 2;
            this.rb_Station2.TabStop = true;
            this.rb_Station2.Text = "工位2";
            this.rb_Station2.UseVisualStyleBackColor = true;
            // 
            // rb_Station1
            // 
            this.rb_Station1.AutoSize = true;
            this.rb_Station1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_Station1.ForeColor = System.Drawing.Color.White;
            this.rb_Station1.Location = new System.Drawing.Point(20, 21);
            this.rb_Station1.Name = "rb_Station1";
            this.rb_Station1.Size = new System.Drawing.Size(69, 25);
            this.rb_Station1.TabIndex = 2;
            this.rb_Station1.TabStop = true;
            this.rb_Station1.Text = "工位1";
            this.rb_Station1.UseVisualStyleBackColor = true;
            // 
            // btn_ModifyUser
            // 
            this.btn_ModifyUser.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg03;
            this.btn_ModifyUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ModifyUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModifyUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModifyUser.ForeColor = System.Drawing.Color.Black;
            this.btn_ModifyUser.Location = new System.Drawing.Point(162, 254);
            this.btn_ModifyUser.Name = "btn_ModifyUser";
            this.btn_ModifyUser.Size = new System.Drawing.Size(109, 64);
            this.btn_ModifyUser.TabIndex = 8;
            this.btn_ModifyUser.Text = "修改用户";
            this.btn_ModifyUser.UseVisualStyleBackColor = true;
            this.btn_ModifyUser.Click += new System.EventHandler(this.btn_ModifyUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg05;
            this.btn_AddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddUser.ForeColor = System.Drawing.Color.Black;
            this.btn_AddUser.Location = new System.Drawing.Point(23, 254);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(109, 64);
            this.btn_AddUser.TabIndex = 9;
            this.btn_AddUser.Text = "新增用户";
            this.btn_AddUser.UseVisualStyleBackColor = true;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
            // 
            // btn_DeleteUser
            // 
            this.btn_DeleteUser.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg04;
            this.btn_DeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteUser.ForeColor = System.Drawing.Color.Black;
            this.btn_DeleteUser.Location = new System.Drawing.Point(23, 334);
            this.btn_DeleteUser.Name = "btn_DeleteUser";
            this.btn_DeleteUser.Size = new System.Drawing.Size(109, 64);
            this.btn_DeleteUser.TabIndex = 9;
            this.btn_DeleteUser.Text = "删除用户";
            this.btn_DeleteUser.UseVisualStyleBackColor = true;
            this.btn_DeleteUser.Click += new System.EventHandler(this.btn_DeleteUser_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 1);
            this.label4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 1);
            this.label3.TabIndex = 2;
            // 
            // tb_UserPwd
            // 
            this.tb_UserPwd.Location = new System.Drawing.Point(117, 106);
            this.tb_UserPwd.Name = "tb_UserPwd";
            this.tb_UserPwd.Size = new System.Drawing.Size(142, 26);
            this.tb_UserPwd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(19, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户密码 :";
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(117, 52);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(142, 26);
            this.tb_UserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名称 :";
            // 
            // dgv_UserManager
            // 
            this.dgv_UserManager.AllowUserToAddRows = false;
            this.dgv_UserManager.AllowUserToDeleteRows = false;
            this.dgv_UserManager.AllowUserToResizeColumns = false;
            this.dgv_UserManager.AllowUserToResizeRows = false;
            this.dgv_UserManager.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.dgv_UserManager.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_UserManager.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManager.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_UserManager.ColumnHeadersHeight = 45;
            this.dgv_UserManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_UserManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginName,
            this.Column2,
            this.UserManager});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserManager.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_UserManager.EnableHeadersVisualStyles = false;
            this.dgv_UserManager.Location = new System.Drawing.Point(343, 37);
            this.dgv_UserManager.Name = "dgv_UserManager";
            this.dgv_UserManager.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManager.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_UserManager.RowHeadersWidth = 62;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            this.dgv_UserManager.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_UserManager.RowTemplate.Height = 30;
            this.dgv_UserManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserManager.Size = new System.Drawing.Size(400, 421);
            this.dgv_UserManager.TabIndex = 1;
            this.dgv_UserManager.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserManager_CellClick);
            // 
            // LoginName
            // 
            this.LoginName.DataPropertyName = "LoginName";
            this.LoginName.HeaderText = "用户名称";
            this.LoginName.MinimumWidth = 8;
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoginName.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LoginPwd";
            this.Column2.HeaderText = "用户密码";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 105;
            // 
            // UserManager
            // 
            this.UserManager.DataPropertyName = "RoleType";
            this.UserManager.HeaderText = "权限管理";
            this.UserManager.MinimumWidth = 8;
            this.UserManager.Name = "UserManager";
            this.UserManager.ReadOnly = true;
            this.UserManager.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserManager.Width = 80;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg03;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(162, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 64);
            this.button1.TabIndex = 8;
            this.button1.Text = "修改用户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_ModifyUser_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ProcessSystem.Properties.Resources.btnbg02;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(162, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 64);
            this.button2.TabIndex = 8;
            this.button2.Text = "登出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(751, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(776, 489);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgv_UserManager);
            this.Controls.Add(this.xbdHeadPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.xbdHeadPanel1.ResumeLayout(false);
            this.xbdHeadPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private xbd.ControlLib.xbdHeadPanel xbdHeadPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_UserPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ModifyUser;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_DeleteUser;
        private System.Windows.Forms.DataGridView dgv_UserManager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_Manager;
        private System.Windows.Forms.RadioButton rb_Station2;
        private System.Windows.Forms.RadioButton rb_Station1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}