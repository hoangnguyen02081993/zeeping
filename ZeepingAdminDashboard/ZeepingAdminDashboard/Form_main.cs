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
using ZeepingAdminDashboard.Resources;
using ZeepingAdminDashboard.View;
using ZeepingAdminDashboard.Controller;
using System.Diagnostics;
using System.IO;

namespace ZeepingAdminDashboard
{
    public partial class Form_main : Form
    {
        View.ProductView proView;
        private Main_Controller controller = null;

        private string User;
        private string Password;
        private long Id;
        private EnumClass.PermissionUser Permission;
        private bool IsDB;
        private bool IsFTP;
        private bool IsSystemRun = false;


        public Form_main()
        {
            InitializeComponent();
            this.Load += Form_main_Load;
            this.Disposed += Form_main_Disposed;
        }

        private void Form_main_Disposed(object sender, EventArgs e)
        {
            if (Id >= 0)
            {
                controller.endLogin(Id);
                Id = -1;
            }
        }

        ~Form_main()
        {
            if (Id >= 0)
            {
                controller.endLogin(Id);
                Id = -1;
            }
        }
        private void Form_main_Load(object sender, EventArgs e)
        {
            //Load config
            AppConfig.LoadConfigFromFile();
            IsSystemRun = AppConfig.LoadConfig();
            controller = new Main_Controller();
            controller.removeTicketbyDate(AppConfig.DateClearLogin);

            CheckSystem();
            logoutToolStripMenuItem.Enabled = false;
            Init();
            Text = AppConfig.Version;

            if(!AppConfig.CheckVersion())
            {
                Functions.ShowMessgeError("Sai phiên bản. Vui lòng cập nhật phiên bản mới. Phiên bản hiện tại là: " + AppConfig.WebVersion);
                File.WriteAllText(Application.StartupPath + "/Version.txt", AppConfig.VersionNumber);
                Process.Start(Application.StartupPath + "/ReleaseDownloader.exe");
                Application.Exit();
            }
        }

        public void Init()
        {
            proView = new View.ProductView(gbContent.Size);
            this.gbContent.Controls.Add(proView);
            proView.Name = "proView";
            proView.InitData();

            HuongdanView hdView = new HuongdanView(gbContent.Size);
            hdView.Name = "hdView";
            this.gbContent.Controls.Add(hdView);

            ThanhtoanView ttView = new ThanhtoanView();
            ttView.Name = "ttView";
            this.gbContent.Controls.Add(ttView);

            DanhsachDonhangView ddView = new DanhsachDonhangView(gbContent.Size);
            ddView.Name = "ddView";
            this.gbContent.Controls.Add(ddView);
            ddView.InitData();

            KhacView kView = new KhacView();
            kView.Name = "kView";
            this.gbContent.Controls.Add(kView);

            UserView uView = new UserView(gbContent.Size);
            uView.Name = "uView";
            this.gbContent.Controls.Add(uView);
            uView.InitData();

            HoTroView htView = new HoTroView(gbContent.Size);
            htView.Name = "htView";
            this.gbContent.Controls.Add(htView);

            FAQview FAQView = new FAQview(gbContent.Size);
            FAQView.Name = "FAQView";
            this.gbContent.Controls.Add(FAQView);

            CollectionsView clsView = new CollectionsView(gbContent.Size);
            clsView.Name = "clsView";
            this.gbContent.Controls.Add(clsView);

            setContent(EnumClass.Functions.Huongdansudung);

            Permission = EnumClass.PermissionUser.Unknown;
        }
        private void CheckSystem()
        {
            User = string.Empty;
            IsDB = DBHandler.CheckConnetion(AppConfig.DBconnectString);
            //IsFTP = FTPAction.isValidConnection(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword);
            if(User != string.Empty)
            {
                loginToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Enabled = false;
            }

            lb_DB.Text = "Database (" + AppConfig.DBDatabase + "): " + IsDB.ToString();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDB)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        User = login.UserName;
                        Password = login.Password;
                        Permission = login.GetPermission();
                        lb_user.Text = "User: " + User;
                        logoutToolStripMenuItem.Enabled = true;
                        loginToolStripMenuItem.Enabled = false;
                        chagnepassToolStripMenuItem.Enabled = true;
                        setContent(EnumClass.Functions.Huongdansudung);
                        Id = controller.createLogin(User);
                    }
                }
            }
            else
            {
                Functions.ShowMessgeError("Không có kết nối database. Vui lòng kiểm tra lại");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User = string.Empty;
            Permission = EnumClass.PermissionUser.Unknown;
            lb_user.Text = "User: " + Permission.ToString();
            logoutToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Enabled = true;
            chagnepassToolStripMenuItem.Enabled = false;
            setContent(EnumClass.Functions.Huongdansudung);

            if(Id >=0 )
            {
                controller.endLogin(Id);
                Id = -1;
            }
        }
        private void setContent(EnumClass.Functions function)
        {
            if(!IsSystemRun)
            {
                Functions.ShowMessgeError("Không có thông tin cấu hình. Vui lòng cấu hình lại và khởi động lại chương trình");
                return;
            }

            switch(function)
            {
                case EnumClass.Functions.Huongdansudung:
                    foreach (Control item in gbContent.Controls)
                    {
                        if(item.Name == "hdView")
                        {
                            item.Visible = true;
                        }
                        else
                        {
                            item.Visible = false;
                        }
                    }
                    break;
                case EnumClass.Functions.Thanhtoan:
                    if(Permission == EnumClass.PermissionUser.Administrator || Permission == EnumClass.PermissionUser.OrderExer)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "ttView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.Danhsachdonhang:
                    //if(true)
                    if (Permission == EnumClass.PermissionUser.Administrator || Permission == EnumClass.PermissionUser.OrderExer)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "ddView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.Sanpham:
                    //if(true)
                    if (Permission == EnumClass.PermissionUser.Administrator || Permission == EnumClass.PermissionUser.Addproducter)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "proView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.Khac:
                    foreach (Control item in gbContent.Controls)
                    {
                        if (item.Name == "kView")
                        {
                            item.Visible = true;
                        }
                        else
                        {
                            item.Visible = false;
                        }
                    }
                    break;
                case EnumClass.Functions.User:
                    //if(true)
                    if (Permission == EnumClass.PermissionUser.Administrator || Permission == EnumClass.PermissionUser.UserManager)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "uView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.HotroKhachhang:
                    //if(true)
                    if (Permission != EnumClass.PermissionUser.Unknown)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "htView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.FAQ:
                    //if(true)
                    if (Permission != EnumClass.PermissionUser.Unknown)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "FAQView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
                case EnumClass.Functions.Collections:
                    //if(true)
                    if (Permission != EnumClass.PermissionUser.Unknown)
                    {
                        foreach (Control item in gbContent.Controls)
                        {
                            if (item.Name == "clsView")
                            {
                                item.Visible = true;
                            }
                            else
                            {
                                item.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Functions.ShowMessgeError("Bạn không có quyền truy cập");
                    }
                    break;
            }
        }

        private void btn_intro_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Huongdansudung);
        }

        private void btn_charge_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Thanhtoan);
        }

        private void btn_listorder_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Danhsachdonhang);
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Sanpham);
        }

        private void btn_other_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Khac);
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.User);
        }

        private void btn_support_customer_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.HotroKhachhang);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConfigForm form = new ConfigForm())
            {
                form.ShowDialog();
                if(form.IsSaveSucces)
                {
                    IsSystemRun = AppConfig.LoadConfig();
                    IsDB = DBHandler.CheckConnetion(AppConfig.DBconnectString);
                    lb_DB.Text = "Database (" + AppConfig.DBDatabase + "): " + IsDB.ToString();
                }
            }
        }

        private void scrumBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (User == string.Empty)
            {
                Functions.ShowMessgeInfo("Bạn chưa đăng nhập. Không thể sử dụng");
                return;
            }
            if (Permission == EnumClass.PermissionUser.Guest)
            {
                Functions.ShowMessgeInfo("Bạn không đủ quyền truy cập");
                return;
            }
            using (Tool.SrumBoard.ScrumBoardView board = new Tool.SrumBoard.ScrumBoardView(User))
            {
                board.ShowDialog();
            }
        }

        private void chagnepassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePasswordView view = new ChangePasswordView(Password))
            {
                if(view.ShowDialog() == DialogResult.OK)
                {
                    if(controller.ChangePass(User, Functions.GetMD5(view.NewPassword)))
                    {
                        Password = Functions.GetMD5(view.NewPassword);
                        Functions.ShowMessgeInfo("Đổi password thành công");
                    }
                    else
                    {
                        Functions.ShowMessgeError("Đổi password thất bại");
                    }
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_FAQ_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.FAQ);
        }

        private void btn_collections_Click(object sender, EventArgs e)
        {
            setContent(EnumClass.Functions.Collections);
        }
    }
}
