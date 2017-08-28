using ReleaseDownloader.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReleaseDownloader
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        private string AppVersion = string.Empty;
        private bool IsSystemRun = false;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAppVersion();
            //Load config
            AppConfig.LoadConfigFromFile();
            IsSystemRun = AppConfig.LoadConfig();
            Text = AppConfig.Version;

            chb_autoupdate.Checked = AppConfig.AutoUpdate;
            chb_autorun.Checked = AppConfig.AutoRun;

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            if (AppConfig.AutoUpdate)
            {
                btn_update_Click(null, null);
            }
        }

        private void chb_autoupdate_CheckedChanged(object sender, EventArgs e)
        {
            if(chb_autoupdate.Checked != AppConfig.AutoUpdate)
            {
                AppConfig.AutoUpdate = chb_autoupdate.Checked;
                AppConfig.SaveConfigToFile(AppConfig.DBServer, AppConfig.DBPort, AppConfig.DBDatabase, AppConfig.DBUser, AppConfig.DBPassword, chb_autoupdate.Checked, AppConfig.AutoRun);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(AppConfig.WebVersion != AppVersion)
            {
                //TODO Update
                try
                {
                    Update();
                    Functions.ShowMessgeInfo("Update thành công");
                    if (AppConfig.AutoRun)
                    {
                        Process.Start(Application.StartupPath + "/ZeepingAdminDashboard.exe");
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    Functions.ShowMessgeError("Update thất bại. Exeption: " + ex.Message);
                }
                
            }
            else
            {
                Functions.ShowMessgeError("Phiên bản hiện tại là phiên bản mới nhất. Không cần phải cập nhật");
            }
        }
        private void Update()
        {
            List<string> lstFile = null;
            lstFile = FTPAction.getListFiles(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword, AppConfig.releaseLocation, string.Empty);
            if(lstFile != null)
            {
                if(lstFile.Count > 0)
                {
                    //Backup các file cũ
                    if (!Directory.Exists(Application.StartupPath + "/tmp")) Directory.CreateDirectory(Application.StartupPath + "/tmp");
                    int index = 0;
                    foreach (var item in lstFile)
                    {
                        SetStatustoLable(lb_process, "Backup file: " + item);
                        SetProcessBar(progress_update, 60 * ( (index * 2) / (lstFile.Count *2)));
                        //Backup các file cũ
                        try
                        {
                            File.Copy(Application.StartupPath + "/" + item, Application.StartupPath + "/tmp/" + item);
                            File.Delete(Application.StartupPath + "/" + item);
                        }
                        catch { }

                        SetStatustoLable(lb_process, "Get file: " + item);
                        SetProcessBar(progress_update, 60 * ((index * 2 + 1) / (lstFile.Count * 2)));
                        //Get các file mới
                        if (!FTPAction.getFile(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword, AppConfig.releaseLocation, item, Application.StartupPath, item))
                        {
                            SetStatustoLable(lb_process, "Rollback previous Version");
                            SetProcessBar(progress_update, 0);
                            //Rollback phiên bản cũ
                            Rollback();
                            SetStatustoLable(lb_process, "UpdateFail");
                            SetProcessBar(progress_update, 0);
                            throw new Exception("Lỗi trong quá trình lấy file");
                        }
                        index++;
                    }
                    SetStatustoLable(lb_process, "Delete tmp file");
                    SetProcessBar(progress_update, 60);
                    DeleteTmp();

                    SetStatustoLable(lb_process, "UpdateSucess");
                    SetProcessBar(progress_update, 100);
                }
                else
                {
                    throw new Exception("Không có file nào để update");
                }
            }
            else
            {
                throw new Exception("Không thể kết nối đến server FTP");
            }
        }
        private void Rollback()
        {
            if (!Directory.Exists(Application.StartupPath + "/tmp/"))
                return;

            string[] Files = Directory.GetFiles(Application.StartupPath + "/tmp/");
            int index = 0;
            foreach (var item in Files)
            {
                SetStatustoLable(lb_process, "Rollback file: " + item);
                SetProcessBar(progress_update, 100 * index / Files.Length);
                try
                {
                    File.Copy(item, Application.StartupPath + "/" + Functions.GetSafeFileName(item));
                    File.Delete(item);
                }
                catch { }
                index++;
            }
            SetStatustoLable(lb_process, "Delete Directory tmp");
            try
            {
                Directory.Delete(Application.StartupPath + "/tmp/");
            }
            catch { }
        }
        private void DeleteTmp()
        {
            if (!Directory.Exists(Application.StartupPath + "/tmp/"))
                return;

            string[] Files = Directory.GetFiles(Application.StartupPath + "/tmp/");
            int index = 0;
            foreach (var item in Files)
            {
                SetStatustoLable(lb_process, "Delete file: " + item);
                SetProcessBar(progress_update, 60 + (30 * index / Files.Length));
                try
                {
                    File.Delete(item);
                }
                catch { }
                index++;
            }
            SetStatustoLable(lb_process, "Delete Directory tmp");
            try
            {
                Directory.Delete(Application.StartupPath + "/tmp/");
            }
            catch { }
        }
        private void SetStatustoLable(Label refLable, string Status)
        {
            if (Status == null) return;
            try
            {
                refLable.Invoke((Action)delegate () {
                    refLable.Text = Status;
                });
            }
            catch
            {
                refLable.Text = Status;
            }
        }
        private void SetProcessBar(ProgressBar refProcessBar,int Status)
        {
            if (Status < 0 || Status > 100) return;
            try
            {
                refProcessBar.Invoke((Action)delegate () {
                    refProcessBar.Value = Status;
                });
            }
            catch
            {
                refProcessBar.Value = Status;
            }
        }
        private void LoadAppVersion()
        {
            try
            {
                AppVersion = File.ReadAllText(Application.StartupPath + "/Version.txt");
                File.Delete(Application.StartupPath + "/Version.txt");
            }
            catch { this.Close(); }
        }

        private void chb_autorun_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_autorun.Checked != AppConfig.AutoRun)
            {
                AppConfig.AutoRun = chb_autorun.Checked;
                AppConfig.SaveConfigToFile(AppConfig.DBServer, AppConfig.DBPort, AppConfig.DBDatabase, AppConfig.DBUser, AppConfig.DBPassword, AppConfig.AutoUpdate, chb_autorun.Checked);
            }
        }
    }
}
