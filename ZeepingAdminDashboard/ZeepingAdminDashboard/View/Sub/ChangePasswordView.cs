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

namespace ZeepingAdminDashboard.View
{
    public partial class ChangePasswordView : Form
    {
        private string Password;
        public string NewPassword { private set; get; }
        public ChangePasswordView(string password)
        {
            InitializeComponent();
            Password = password;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if(Functions.GetMD5(tb_old.Text).Equals(Password))
            {
                if(tb_new.Text.Equals(tb_again_new.Text) && tb_new.Text.Length > 0)
                {
                    NewPassword = tb_new.Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Functions.ShowMessgeInfo("Password mới và password confirm không trùng nhau hoặc password mới đang được để trống");
                }
            }
            else
            {
                Functions.ShowMessgeInfo("Password cũ không đúng");
            }
        }
    }
}
