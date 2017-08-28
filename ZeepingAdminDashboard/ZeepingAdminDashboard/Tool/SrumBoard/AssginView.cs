using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class AssginView : Form
    {
        public string UserName = string.Empty;
        public AssginView()
        {
            InitializeComponent();
        }
        public void setUserList(string User)
        {
            cb_userlist.Items.Add(User);
            if(cb_userlist.Items.Count > 0)
            {
                cb_userlist.SelectedIndex = 0;
            }
        }
        public void setUserList(List<AdminUser_Model> lst)
        {
            cb_userlist.Items.AddRange(lst.ToArray());
            cb_userlist.DisplayMember = "username";
            if (cb_userlist.Items.Count > 0)
            {
                cb_userlist.SelectedIndex = 0;
            }
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            UserName = cb_userlist.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
