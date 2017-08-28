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
using ZeepingAdminDashboard.Database;

namespace ZeepingAdminDashboard.View
{
    public partial class ConfigForm : Form
    {
        public bool IsSaveSucces = false;

        public ConfigForm()
        {
            InitializeComponent();
            this.Load += ConfigForm_Load;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            tb_DBServer.Text = AppConfig.DBServer;
            tb_DBPort.Text = AppConfig.DBPort.ToString();
            tb_DBDatabase.Text = AppConfig.DBDatabase;
            tb_DBUser.Text = AppConfig.DBUser;
            tb_DBPassword.Text = AppConfig.DBPassword;
            chb_autorun.Checked = AppConfig.AutoRun;
            chb_autoupdate.Checked = AppConfig.AutoUpdate;
        }

        private void btn_check_DBServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBHandler.CheckConnetion(DBHandler.GetDBConnectionString(tb_DBServer.Text, Int32.Parse(tb_DBPort.Text), tb_DBDatabase.Text, tb_DBUser.Text, tb_DBPassword.Text)))
                {
                    Functions.ShowMessgeInfo("Kết nối thành công");
                }
                else
                {
                    Functions.ShowMessgeError("Không thể kết nối DB với cấu hình này");
                }
            }
            catch
            {
                Functions.ShowMessgeError("Có thông số cấu hình nào đó không đúng");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(AppConfig.SaveConfigToFile(tb_DBServer.Text, Int32.Parse(tb_DBPort.Text), tb_DBDatabase.Text, tb_DBUser.Text, tb_DBPassword.Text,chb_autoupdate.Checked,chb_autorun.Checked))
            {
                AppConfig.DBServer = tb_DBServer.Text;
                AppConfig.DBPort = Int32.Parse(tb_DBPort.Text);
                AppConfig.DBDatabase = tb_DBDatabase.Text;
                AppConfig.DBUser = tb_DBUser.Text;
                AppConfig.DBPassword = tb_DBPassword.Text;
                AppConfig.AutoRun = chb_autorun.Checked;
                AppConfig.AutoUpdate = chb_autoupdate.Checked;
                AppConfig.ExecConfig();

                IsSaveSucces = true;
                Functions.ShowMessgeInfo("Lưu cấu hình thành công");
            }
            else
            {
                Functions.ShowMessgeError("Lưu thất bại");
            }
        }
    }
}
