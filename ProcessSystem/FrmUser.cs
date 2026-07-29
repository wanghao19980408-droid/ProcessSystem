using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class FrmUser : Form
    {
        public FormMain formMain;
        public FrmUser(FormMain formMain)
        {
            InitializeComponent();
            this.dgv_UserManager.AutoGenerateColumns = false;
            this.Load += FrmUser_Load;
            this.formMain = formMain;
        }

        UserTableService adminService = new UserTableService();
        List<UserTable> userTable = new List<UserTable>();

        private void FrmUser_Load(object sender, EventArgs e)
        {
            ReFreshUser();
            if (userTable.Count > 0)
            {
                UpdateUserInfo(userTable.First());
            }
        }

        #region 无边框拖动 
        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void ReFreshUser()
        {
            var result = adminService.GetAllAdmin();
            if (result.IsSuccess)
            {
                if (result.Content.Count > 0)
                {
                    this.userTable = result.Content;
                    this.dgv_UserManager.DataSource = null;
                    this.dgv_UserManager.DataSource = result.Content;
                }
                else
                {
                    this.dgv_UserManager.DataSource = null;
                }
            }
            else
            {
                new FrmMsgNoAck("刷新列表失败", "刷新提示" + result.Message).ShowDialog();
            }
        }

        private void UpdateUserInfo(UserTable ud)
        {
            this.tb_UserName.Text = ud.LoginName;
            this.tb_UserPwd.Text = ud.LoginPwd;
            if (ud.RoleType == "工位1")
            {
                this.rb_Station1.Checked = true;
                this.rb_Station2.Checked = false;
                this.rb_Manager.Checked = false;
            }
            else if (ud.RoleType == "工位2")
            {
                this.rb_Station1.Checked = false;
                this.rb_Station2.Checked = true;
                this.rb_Manager.Checked = false;
            }
            else
            {
                this.rb_Station1.Checked = false;
                this.rb_Station2.Checked = false;
                this.rb_Manager.Checked = true;
            }
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            if (this.tb_UserName.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户名不得为空", "新增提示").ShowDialog();
                return;
            }
            if (this.tb_UserPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("密码不得为空", "新增提示").ShowDialog();
                return;
            }

            if (userTable.Where(c => c.LoginName == this.tb_UserName.Text.Trim()).Count() > 0)
            {
                new FrmMsgNoAck("用户名已存在", "新增提示").ShowDialog();
                return;
            }
            UserTable ud = new UserTable()
            {
                LoginName = this.tb_UserName.Text,
                LoginPwd = this.tb_UserPwd.Text,
                RoleType = this.rb_Station1.Checked ? "工位1" : (this.rb_Station2.Checked ? "工位2" : "管理员")
            };
            var res = adminService.AddUserTable(ud);

            if (res.IsSuccess)
            {
                this.ReFreshUser();
            }
            else
            {
                new FrmMsgNoAck("新增用户失败", "新增提示" + res.Message).ShowDialog();
            }
        }

        private void btn_DeleteUser_Click(object sender, EventArgs e)
        {
            if (this.dgv_UserManager.SelectedRows.Count > 0)
            {
                var selectedUser = userTable[this.dgv_UserManager.SelectedRows[0].Index];

                if (formMain.UserInfo != null && selectedUser.LoginId == formMain.UserInfo.LoginId)
                {
                    new FrmMsgNoAck("无法删除当前正在登录的管理员账号！", "安全提示").ShowDialog();
                    return;
                }

                int LoginId = selectedUser.LoginId;
                var res = adminService.DeleteUserTable(LoginId);
                if (res.IsSuccess)
                {
                    this.ReFreshUser();
                }
                else
                {
                    new FrmMsgNoAck("删除用户失败", "删除提示" + res.Message).ShowDialog();
                }
            }
            else
            {
                new FrmMsgNoAck("请选择需要删除的用户", "删除提示").ShowDialog();
            }
        }

        private void btn_ModifyUser_Click(object sender, EventArgs e)
        {
            if (this.tb_UserName.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户名不得为空", "修改提示").ShowDialog();
                return;
            }
            if (this.tb_UserPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("密码不得为空", "修改提示").ShowDialog();
                return;
            }

            UserTable ud = new UserTable()
            {
                LoginId = userTable[this.dgv_UserManager.SelectedRows[0].Index].LoginId,
                LoginName = this.tb_UserName.Text,
                LoginPwd = this.tb_UserPwd.Text,
                RoleType = this.rb_Station1.Checked ? "工位1" : (this.rb_Station2.Checked ? "工位2" : "管理员")
            };
            var res = adminService.ModifyUserTable(ud);

            if (res.IsSuccess)
            {
                if (formMain.UserInfo != null && formMain.UserInfo.LoginId == ud.LoginId)
                {
                    formMain.UserInfo.LoginName = ud.LoginName;
                    formMain.UserInfo.LoginPwd = ud.LoginPwd;
                    formMain.UserInfo.RoleType = ud.RoleType;
                }

                this.ReFreshUser();
                new FrmMsgNoAck("修改成功", "修改提示").ShowDialog();
            }
            else
            {
                new FrmMsgNoAck("修改用户失败", "修改提示" + res.Message).ShowDialog();
            }
        }

        private void dgv_UserManager_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.UpdateUserInfo(userTable[e.RowIndex]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = new FrmMsgWithAck("请确认是否登出！", "登出确认").ShowDialog();
            if (dr == DialogResult.OK)
            {
                formMain.IsLoginOut = true;
                formMain.AddLog(0, $"用户{formMain.UserInfo.LoginName}登出成功！");
                formMain.UserInfo = null;

                this.adminService = null;
                this.userTable = null;

                this.Close(); 
            }
            else
            {
                formMain.IsLoginOut = false; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formMain.IsLoginOut = false;
            this.adminService = null;
            this.userTable = null;
            this.Close();
        }
    }
}