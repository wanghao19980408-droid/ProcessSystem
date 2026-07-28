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

        public async void FrmLogin_Load(object sender, EventArgs e)
        {
            this.cb_UserName.Items.Add("正在连接数据库...");
            this.cb_UserName.SelectedIndex = 0;
            this.Enabled = false;

            try
            {
                var res = await Task.Run(() => adminService.GetAllAdmin());

                this.cb_UserName.Items.Clear();
                if (res.IsSuccess && res.Content != null && res.Content.Count > 0)
                {
                    foreach (var item in res.Content)
                    {
                        this.cb_UserName.Items.Add(item.LoginName);
                    }
                    this.cb_UserName.SelectedIndex = 0;
                }
            }
            catch (SqlSugar.SqlSugarException ex)
            {
                this.cb_UserName.Items.Clear();
                new FrmMsgNoAck($"数据库连接失败，请检查网络或服务器状态。\n{ex.Message}", "连接异常").ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                this.cb_UserName.Items.Clear();
                new FrmMsgNoAck($"发生未知错误：\n{ex.Message}", "错误").ShowDialog();
                this.Close();
            }
            finally
            {
                this.Enabled = true;
            }
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

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_pwd.Text) && !string.IsNullOrEmpty(cb_UserName.Text))
            {
                SysAdmin = new UserTable()
                {
                    LoginName = cb_UserName.Text.Trim(),
                    LoginPwd = tb_pwd.Text.Trim(),
                };

                btn_Login.Enabled = false;
                btn_Login.Text = "登录中...";

                var res = await Task.Run(() => adminService.LoginIn(SysAdmin));

                btn_Login.Enabled = true;
                btn_Login.Text = "登录";

                if (res.IsSuccess && res.Content != null)
                {
                    this.DialogResult = DialogResult.OK;
                    formMain.UserInfo = res.Content;
                }
                else
                {
                    new FrmMsgNoAck("登陆失败: 密码错误或网络异常！", "登录提示").ShowDialog();
                }
            }
            else
            {
                new FrmMsgNoAck("账号或密码不得为空！", "登录提示").ShowDialog();
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
