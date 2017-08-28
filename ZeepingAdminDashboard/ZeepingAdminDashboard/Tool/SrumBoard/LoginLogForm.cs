using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class LoginLogForm : Form
    {
        private LoginLogController controller = new LoginLogController();
        public LoginLogForm()
        {
            InitializeComponent();
            this.Load += LoginLogForm_Load;
        }

        private void LoginLogForm_Load(object sender, EventArgs e)
        {
            List<Login_trackingModel> lst = controller.getAllLoginTracking();
            if(lst != null)
            {
                DateTime current = DateTime.MinValue.Date;
                rtb_log.Text = string.Empty;
                foreach (Login_trackingModel item in lst)
                {
                    if(!item.logindate.Date.Equals(current))
                    {
                        rtb_log.Text += item.logindate.Date.ToString("yyyy-MM-dd") + ":\r\n";
                        current = item.logindate.Date;
                    }
                    rtb_log.Text += "\t+" + item.username + ": (login -> logout) (" + item.logindate.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + item.logoutdate.ToString("yyyy-MM-dd HH:mm:ss") + ")\r\n";
                }
            }
        }
    }
}
