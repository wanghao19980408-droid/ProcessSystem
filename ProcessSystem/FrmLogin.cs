using ProcessSystemLib.Model;
using ProcessSystemLib.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessSystem
{
    public partial class FrmLogin : Form
    {
        FormMain formMain;
        public FrmLogin(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.Load += FrmLogin_Load;
        }

        UserTableService adminService = new UserTableService();
        public UserTable SysAdmin;

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var res =  adminService.GetAllAdmin();
            if (res.IsSuccess && res.Content.Count > 0)
            {
                foreach (var item in res.Content)
                {
                    this.cb_UserName.Items.Add(item.LoginName);
                }
                this.cb_UserName.SelectedIndex = 0;
            }
            else
            {
                new FrmMsgNoAck("没有可用的登录用户,请联系管理员.", "登陆提示").ShowDialog();
            }

            try { this.AcceptButton = this.btn_Login; } catch { }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_pwd.Text) && !string.IsNullOrEmpty(cb_UserName.Text))
            {
                SysAdmin = new UserTable()
                {
                    LoginName = cb_UserName.Text.Trim(),
                    LoginPwd = tb_pwd.Text.Trim(),
                };

                var res = adminService.LoginIn(SysAdmin);
                if (res.IsSuccess && res.Content != null)
                {
                    this.DialogResult = DialogResult.OK;
                    formMain.UserInfo = res.Content;
                }
                else
                {
                    new FrmMsgNoAck("登陆失败: 密码错误！", "登录提示").ShowDialog();

                }
            }
            else
            {
                new FrmMsgNoAck("密码不得为空！", "登录提示").ShowDialog();
            }
        }

	private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
                e.Handled = true;
            }
        }

    }
}
