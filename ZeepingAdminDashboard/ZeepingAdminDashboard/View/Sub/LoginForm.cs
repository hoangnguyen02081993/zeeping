using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.Resources;

namespace ZeepingAdminDashboard.View
{
    public partial class LoginForm : Form
    {
        private List<AdminUser_Model> lstUser = null;
        public bool IsSucess { private set; get; }
        public string UserName { private set; get; }
        public string Password { private set; get;
        }

        private EnumClass.PermissionUser permission;

        public EnumClass.PermissionUser GetPermission()
        {
            return permission;
        }

        private void SetPermission(EnumClass.PermissionUser value)
        {
            permission = value;
        }
        Login_Controller controller = new Login_Controller();

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lstUser = controller.getAllUser();
            if(lstUser == null)
            {
                Functions.ShowMessgeError("Không có kết nối đến database");
                this.Close();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(tb_user.Text == string.Empty)
            {
                Functions.ShowMessgeError("User name không được rỗng");
                return;
            }
            if(tb_pass.Text == string.Empty)
            {
                Functions.ShowMessgeError("Password không được rỗng");
                return;
            }
            if(CheckLogin())
            {
                IsSucess = true;                
                DialogResult = DialogResult.OK;
            }
        }
        private bool CheckLogin()
        {
            bool result = false;
            string passmd5 = Functions.GetMD5(tb_pass.Text);
            AdminUser_Model adminCheck = lstUser.Where(u => u.username == tb_user.Text && u.password == passmd5).FirstOrDefault();
            if(adminCheck != null)
            {
                UserName = adminCheck.username;
                Password = adminCheck.password;
                SetPermission(adminCheck.permission);
                result = true;
            }
            else
            {
                Functions.ShowMessgeError("Tài khoản hoặc mật khẩu không đúng!");
            }

            return result;
        }

        private void tb_user_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tb_pass.Focus();
                tb_pass.SelectionStart = tb_pass.Text.Length;
            }
        }

        private void tb_pass_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(null, null);
            }
        }
    }
}
