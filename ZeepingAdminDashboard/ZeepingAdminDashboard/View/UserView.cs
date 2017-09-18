using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.Resources;
using ZeepingAdminDashboard.View.Sub;

namespace ZeepingAdminDashboard.View
{
    public class UserView : Panel
    {
        private AddUser aU;
        private DisplayUser du;
        private DisplayMailTracking dm;
        public User_Controller controller = new User_Controller();
        public UserView(Size sizeParten) :base()
        {
            this.Location = new Point(20, 20);
            this.Size = new Size(sizeParten.Width - 40, sizeParten.Height - 40);
            this.AutoScroll = true;
            Init();

        }
        private void Init()
        {
            dm = new View.DisplayMailTracking(this.Size);
            dm.Location = new Point(0, 0);
            this.Controls.Add(dm);

            aU = new AddUser(this.Size);
            aU.Location = new Point(0, dm.Location.Y + dm.Height + 10);
            this.Controls.Add(aU);

            du = new DisplayUser(this.Size);
            du.Location = new Point(0, aU.Location.Y + aU.Height + 10);
            this.Controls.Add(du);
        }
        public void InitData()
        {
            dm.InitData();
        }
        public void EventSizeChanged()
        {
            aU.Location = new Point(0, dm.Location.Y + dm.Height + 10);
            du.Location = new Point(0, aU.Location.Y + aU.Height + 10);
        }
        public int AddUser(string email)
        {
            int result = -1;
            dm.HideForm();
            du.HideForm();
            aU.ShowForm();
            result = aU.AddUserbyMail(email);
            aU.HideForm();
            dm.ShowForm();
            return result;
        }
    }
    public class DisplayMailTracking : Panel
    {
        private Button btn_ShowCloseProduct;
        private List<TrackingMail_Model> result = null;
        private List<Product_Style_Model> lstStyle;
        private List<Product_Color_Model> lstColor;
        private int MaxHeight = 500;

        #region Search
        private GroupBox gb_Search;
        private Label lb_email;
        private TextBox tb_email;
        private Label lb_style;
        private ComboBox cb_style;
        private Label lb_color;
        private ComboBox cb_color;
        private Button btn_Search;

        #endregion
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion
        #region Action
        private Button btn_delete;
        private Button btn_addUser;
        #endregion

        public DisplayMailTracking(Size sizeParten) : base()
        {
            this.Size = new Size(sizeParten.Width, Cons.MinHeight);
            //this.BackColor = Color.Black;
            Init();
        }
        private void Init()
        {
            btn_ShowCloseProduct = new Button();
            btn_ShowCloseProduct.Text = Cons.User_btnHideTrackingMail;
            btn_ShowCloseProduct.Location = new Point(20, 5);
            btn_ShowCloseProduct.Size = new Size(300, 30);
            btn_ShowCloseProduct.Click += Btn_ShowCloseProduct_Click;
            this.Controls.Add(btn_ShowCloseProduct);

            #region Search

            gb_Search = new GroupBox();
            gb_Search.Location = new Point(10, 60);
            gb_Search.Size = new Size(700, 50);
            gb_Search.Text = "Search";
            this.Controls.Add(gb_Search);

            lb_email = new Label();
            lb_email.Location = new Point(10, 25);
            lb_email.Size = new Size(50, 20);
            lb_email.Text = "Mail: ";
            gb_Search.Controls.Add(lb_email);

            tb_email = new TextBox();
            tb_email.Location = new Point(lb_email.Location.X + lb_email.Size.Width, 20);
            tb_email.Size = new Size(200, 20);
            gb_Search.Controls.Add(tb_email);

            lb_style = new Label();
            lb_style.Location = new Point(tb_email.Location.X + tb_email.Size.Width + 10, 25);
            lb_style.Size = new Size(40, 20);
            lb_style.Text = "Style: ";
            gb_Search.Controls.Add(lb_style);

            cb_style = new ComboBox();
            cb_style.Location = new Point(lb_style.Location.X + lb_style.Size.Width, 20);
            cb_style.Size = new Size(100, 20);
            cb_style.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_style.DisplayMember = "Name";
            gb_Search.Controls.Add(cb_style);

            lb_color = new Label();
            lb_color.Location = new Point(cb_style.Location.X + cb_style.Size.Width + 10, 25);
            lb_color.Size = new Size(40, 20);
            lb_color.Text = "Color: ";
            gb_Search.Controls.Add(lb_color);

            cb_color = new ComboBox();
            cb_color.Location = new Point(lb_color.Location.X + lb_color.Size.Width, 20);
            cb_color.Size = new Size(100, 20);
            cb_color.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_color.DisplayMember = "Name";
            gb_Search.Controls.Add(cb_color);

            btn_Search = new Button();
            btn_Search.Location = new Point(cb_color.Location.X + cb_color.Size.Width + 10, 15);
            btn_Search.Size = new Size(100, 30);
            btn_Search.Text = "Search ";
            btn_Search.Click += Btn_Search_Click;
            gb_Search.Controls.Add(btn_Search);
            #endregion

            #region DivPage
            dp = new DivPage(new Point(20, gb_Search.Location.Y + gb_Search.Height + 10));
            dp.OnIndexChanged += Dp_OnIndexChanged;
            dp.setMaxcount(10);
            this.Controls.Add(dp);
            #endregion

            #region Data
            dv = new DataGridView();
            dv.Location = new Point(10, dp.Location.Y + dp.Height + 10);
            dv.Size = new Size(700, 250);
            dv.Columns.Add("ID", "ID");
            dv.Columns.Add("TM", "Tracking mail");
            dv.Columns.Add("Pro", "Mã sản phẩm");
            dv.Columns.Add("Style", "Style");
            dv.Columns.Add("Color", "Color");
            dv.Columns.Add("Date", "Ngày");
            dv.Columns["ID"].Width = 30;
            dv.Columns["TM"].Width = 170;
            dv.Columns["Pro"].Width = 100;
            dv.Columns["Style"].Width = 130;
            dv.Columns["Color"].Width = 100;
            dv.Columns["Date"].Width = 120;
            dv.Rows.Add(10);
            dv.AllowUserToAddRows = false;
            dv.MultiSelect = false;
            dv.ReadOnly = true;
            this.Controls.Add(dv);
            #endregion

            #region Action
            btn_addUser = new Button();
            btn_addUser.Location = new Point(20, dv.Location.Y + dv.Height + 20);
            btn_addUser.Size = new Size(100, 50);
            btn_addUser.Text = "Thêm User";
            btn_addUser.Click += Btn_addUser_Click;
            this.Controls.Add(btn_addUser);

            btn_delete = new Button();
            btn_delete.Location = new Point(btn_addUser.Location.X + btn_addUser.Width + 20, btn_addUser.Location.Y);
            btn_delete.Size = new Size(100, 50);
            btn_delete.Text = "Xóa Tracking Mail";
            btn_delete.Click += Btn_delete_Click;
            this.Controls.Add(btn_delete);
            #endregion

        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                if (getParent().controller.DeleteTrackingMail(id))
                {
                    Functions.ShowMessgeInfo("Xóa thành công");
                    var itemremove = result.Where(r => r.id == id).FirstOrDefault();
                    result.Remove(itemremove);
                    Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                }
                else
                {
                    Functions.ShowMessgeError("Xóa thất bại");
                }
            }
            else
            {
                if(dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["ID"].Value;
                    if (getParent().controller.DeleteTrackingMail(id))
                    {
                        Functions.ShowMessgeInfo("Xóa thành công");
                        var itemremove = result.Where(r => r.id == id).FirstOrDefault();
                        result.Remove(itemremove);
                        Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                    }
                    else
                    {
                        Functions.ShowMessgeError("Xóa thất bại");
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để xóa");
                }
            }
        }

        private void Btn_addUser_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                string email = (string)dv.SelectedRows[0].Cells["TM"].Value;
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                int rs = getParent().AddUser(email);
                if (rs == 0)
                {
                    Functions.ShowMessgeInfo("Add user thành công");
                    getParent().controller.DeleteTrackingMail(id);
                    var itemremove = result.Where(r => r.id == id).FirstOrDefault();
                    result.Remove(itemremove);
                    Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                }
                else
                {
                    if (rs == -1)
                    {
                        Functions.ShowMessgeError("Lỗi không xác định");
                    }
                    else if (rs == 1)
                    {
                        Functions.ShowMessgeError("Không có kết nối Database");
                    }
                    else if (rs == 2)
                    {
                        Functions.ShowMessgeError("Không thể send mail");
                    }
                    else if (rs == 3)
                    {
                        Functions.ShowMessgeError("User đã được sử dụng.");
                    }
                    else if (rs == 4)
                    {
                        Functions.ShowMessgeError("Định dạng mail không hợp lệ");
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    string email = (string)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["TM"].Value;
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["ID"].Value;
                    int rs = getParent().AddUser(email);
                    if (rs == 0)
                    {
                        Functions.ShowMessgeInfo("Add user thành công");
                        getParent().controller.DeleteTrackingMail(id);
                        var itemremove = result.Where(r => r.id == id).FirstOrDefault();
                        result.Remove(itemremove);
                        Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                    }
                    else
                    {
                        if (rs == -1)
                        {
                            Functions.ShowMessgeError("Lỗi không xác định");
                        }
                        else if (rs == 1)
                        {
                            Functions.ShowMessgeError("Không có kết nối Database");
                        }
                        else if (rs == 2)
                        {
                            Functions.ShowMessgeError("Không thể send mail");
                        }
                        else if (rs == 3)
                        {
                            Functions.ShowMessgeError("User đã được sử dụng.");
                        }
                        else if (rs == 4)
                        {
                            Functions.ShowMessgeError("Định dạng mail không hợp lệ");
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để add User");
                }
            }
        }

        public void InitData()
        {
            // Load Style
            cb_style.Items.Clear();
            cb_style.Items.Add(new Product_Style_Model() { Id = -1, Name = "Tất cả" });
            lstStyle = getParent().controller.getStyleList();
            cb_style.Items.AddRange(lstStyle.ToArray());
            cb_style.SelectedIndex = 0;

            //Load Color
            cb_color.Items.Clear();
            cb_color.Items.Add(new Product_Color_Model() { Id = -1, Name = "Tất cả" });
            lstColor = getParent().controller.getColorList();
            cb_color.Items.AddRange(lstColor.ToArray());
            cb_color.SelectedIndex = 0;


        }
        private void Btn_ShowCloseProduct_Click(object sender, EventArgs e)
        {
            if (btn_ShowCloseProduct.Text == Resources.Cons.User_btnShowTrackingMail) // Thuc hien chuc nang hide
            {
                this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideTrackingMail;
            }
            else // thuc hien chuc nang show
            {
                this.Size = new Size(this.Size.Width, MaxHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowTrackingMail;
            }
            ((UserView)this.Parent).EventSizeChanged();
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            if (getParent().controller.SearchTrackingMail(ref result, tb_email.Text, ((Product_Style_Model)cb_style.SelectedItem).Id, ((Product_Color_Model)cb_color.SelectedItem).Id))
            {
                dv.Rows.Clear();
                dp.setObjCount(result.Count, 10);
                if (result.Count == 0)
                {
                    Functions.ShowMessgeInfo("Không có dữ liệu nào phù hợp");
                }
                Functions.ShowMaiQuynhAnh();
            }
            else
            {
                Functions.ShowMessgeError("Search thất bại");
            }
        }
        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add(result[i].id, result[i].email, result[i].product_id , lstStyle.Where(s => s.Id == result[i].style_id).FirstOrDefault().Name, lstColor.Where(s => s.Id == result[i].color_id).FirstOrDefault().Name, result[i].date.ToString("yyyy-MM-dd HH:mm:ss"));
                Color c = lstColor.Where(s => s.Id == result[i].color_id).FirstOrDefault().Colors;
                dv.Rows[dv.Rows.Count - 1].Cells[3].Style.BackColor = c;
                if((c.R + c.G + c.B) /3 <128)
                {
                    dv.Rows[dv.Rows.Count - 1].Cells[3].Style.ForeColor = Color.White;
                }
                
            }
        }
        private UserView getParent()
        {
            return (UserView)this.Parent;
        }
        public void HideForm()
        {
            this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideTrackingMail;
            ((UserView)this.Parent).EventSizeChanged();
        }
        public void ShowForm()
        {
            this.Size = new Size(this.Size.Width, MaxHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowTrackingMail;
            ((UserView)this.Parent).EventSizeChanged();
        }
    }
    public class AddUser: Panel
    {
        private Button btn_ShowCloseProduct;

        private TextBox tb_mailnUser;
        private Button btn_addUser;
        private int MaxHeight = 100;
        public AddUser(Size sizeParten) : base()
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(sizeParten.Width , Cons.MinHeight);
            Init();
        }
        private void Init()
        {
            btn_ShowCloseProduct = new Button();
            btn_ShowCloseProduct.Text = Cons.User_btnHideThem;
            btn_ShowCloseProduct.Location = new Point(20, 5);
            btn_ShowCloseProduct.Size = new Size(300, 30);
            btn_ShowCloseProduct.Click += Btn_ShowCloseProduct_Click;
            this.Controls.Add(btn_ShowCloseProduct);


            tb_mailnUser = new TextBox();
            tb_mailnUser.Location = new Point(50, btn_ShowCloseProduct.Location.Y + btn_ShowCloseProduct.Height + 17);
            tb_mailnUser.Size = new Size(500, 50);
            tb_mailnUser.Font = new Font("consolas", 16);
            this.Controls.Add(tb_mailnUser);

            btn_addUser = new Button();
            btn_addUser.Location = new Point(tb_mailnUser.Location.X + tb_mailnUser.Width + 10, tb_mailnUser.Location.Y - 7);
            btn_addUser.Size = new Size(100, 50);
            btn_addUser.Text = "Thêm user mới";
            btn_addUser.Font = new Font("consolas", 12);
            btn_addUser.Click += Btn_addUser_Click;
            this.Controls.Add(btn_addUser);
        }

        private void Btn_addUser_Click(object sender, EventArgs e)
        {
            int result = getParent().controller.AddUser(tb_mailnUser.Text);
            if(result == -1)
            {
                Functions.ShowMessgeError("Lỗi không xác định");
            }
            else if (result == 0)
            {
                Functions.ShowMessgeInfo("Add user thành công");
                tb_mailnUser.Text = string.Empty;
            }
            else if (result == 1)
            {
                Functions.ShowMessgeError("Không có kết nối Database");
            }
            else if (result == 2)
            {
                Functions.ShowMessgeError("Không thể send mail");
            }
            else if (result == 3)
            {
                Functions.ShowMessgeError("User đã được sử dụng.");
            }
            else if (result == 4)
            {
                Functions.ShowMessgeError("Định dạng mail không hợp lệ");
            }
        }
        private UserView getParent()
        {
            return (UserView)this.Parent;
        }
        private void Btn_ShowCloseProduct_Click(object sender, EventArgs e)
        {
            if (btn_ShowCloseProduct.Text == Resources.Cons.User_btnShowThem) // Thuc hien chuc nang hide
            {
                this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideThem;
            }
            else // thuc hien chuc nang show
            {
                this.Size = new Size(this.Size.Width, MaxHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowThem;
            }
            ((UserView)this.Parent).EventSizeChanged();
        }
        public void ShowForm()
        {
            this.Size = new Size(this.Size.Width, MaxHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowThem;
            ((UserView)this.Parent).EventSizeChanged();
        }
        public void HideForm()
        {
            this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideThem;
            ((UserView)this.Parent).EventSizeChanged();
        }
        public int AddUserbyMail(string email)
        {
            int result = -1;

            tb_mailnUser.Text = email;
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            result = getParent().controller.AddUser(tb_mailnUser.Text);
            tb_mailnUser.Text = string.Empty;

            return result;
        }
    }
    public class DisplayUser : Panel
    {
        private Button btn_ShowCloseProduct;
        private List<User_Model> result = null;
        private int MaxHeight = 500;

        #region Search
        private GroupBox gb_Search;
        private Label lb_username;
        private Label lb_TenKH;
        private TextBox tb_username;
        private TextBox tb_TenKH;
        private Button btn_Search;

        private Label lb_Enable;
        private ComboBox cb_Enable;
        #endregion
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion

        public DisplayUser(Size sizeParten) : base()
        {
            this.Size = new Size(sizeParten.Width, Cons.MinHeight);
            //this.BackColor = Color.Black;
            Init();
        }
        private void Init()
        {
            btn_ShowCloseProduct = new Button();
            btn_ShowCloseProduct.Text = Cons.User_btnHideXem;
            btn_ShowCloseProduct.Location = new Point(20, 5);
            btn_ShowCloseProduct.Size = new Size(300, 30);
            btn_ShowCloseProduct.Click += Btn_ShowCloseProduct_Click;
            this.Controls.Add(btn_ShowCloseProduct);

            #region Search

            gb_Search = new GroupBox();
            gb_Search.Location = new Point(10, 60);
            gb_Search.Size = new Size(700, 90);
            gb_Search.Text = "Search";
            this.Controls.Add(gb_Search);

            lb_username = new Label();
            lb_username.Location = new Point(10, 25);
            lb_username.Size = new Size(70, 20);
            lb_username.Text = "User KH: ";
            gb_Search.Controls.Add(lb_username);

            tb_username = new TextBox();
            tb_username.Location = new Point(lb_username.Location.X + lb_username.Size.Width, 20);
            tb_username.Size = new Size(200, 20);
            gb_Search.Controls.Add(tb_username);

            lb_TenKH = new Label();
            lb_TenKH.Location = new Point(tb_username.Location.X + tb_username.Size.Width + 10, 25);
            lb_TenKH.Size = new Size(70, 20);
            lb_TenKH.Text = "Tên KH: ";
            gb_Search.Controls.Add(lb_TenKH);

            tb_TenKH = new TextBox();
            tb_TenKH.Location = new Point(lb_TenKH.Location.X + lb_TenKH.Size.Width, 20);
            tb_TenKH.Size = new Size(200, 20);
            gb_Search.Controls.Add(tb_TenKH);

            btn_Search = new Button();
            btn_Search.Location = new Point(tb_TenKH.Location.X + tb_TenKH.Size.Width + 10, 15);
            btn_Search.Size = new Size(100, 30);
            btn_Search.Text = "Search ";
            btn_Search.Click += Btn_Search_Click;
            gb_Search.Controls.Add(btn_Search);

            lb_Enable = new Label();
            lb_Enable.Location = new Point(10, lb_username.Location.Y + lb_username.Height + 10);
            lb_Enable.Size = new Size(70, 20);
            lb_Enable.Text = "Chế độ: ";
            gb_Search.Controls.Add(lb_Enable);

            cb_Enable = new ComboBox();
            cb_Enable.Location = new Point(lb_Enable.Location.X + lb_username.Width, lb_Enable.Location.Y - 2);
            cb_Enable.Size = new Size(200, 20);
            cb_Enable.Items.Add("Tất cả");
            cb_Enable.Items.Add("Đã kích hoạt");
            cb_Enable.Items.Add("Chưa kích hoạt");
            cb_Enable.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Enable.SelectedIndex = 0;
            gb_Search.Controls.Add(cb_Enable);
            #endregion

            #region DivPage
            dp = new DivPage(new Point(20, gb_Search.Location.Y + gb_Search.Height + 10));
            dp.OnIndexChanged += Dp_OnIndexChanged;
            dp.setMaxcount(10);
            this.Controls.Add(dp);
            #endregion

            #region Data
            dv = new DataGridView();
            dv.Location = new Point(10, dp.Location.Y + dp.Height + 10);
            dv.Size = new Size(700, 250);            
            dv.Columns.Add("TU", "User name");
            dv.Columns.Add("NU", "Họ tên");
            dv.Columns.Add("DTLU", "Điểm tích lũy");
            dv.Columns.Add("EU", "Isenable");            
            dv.Columns["TU"].Width = 150;
            dv.Columns["NU"].Width = 170;
            dv.Columns["DTLU"].Width = 280;
            dv.Columns["EU"].Width = 50;
            dv.Rows.Add(10);
            dv.AllowUserToAddRows = false;
            dv.ReadOnly = true;
            this.Controls.Add(dv);
            #endregion
        }
        private void Btn_ShowCloseProduct_Click(object sender, EventArgs e)
        {
            if (btn_ShowCloseProduct.Text == Resources.Cons.User_btnShowXem) // Thuc hien chuc nang hide
            {
                this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideXem;
            }
            else // thuc hien chuc nang show
            {
                this.Size = new Size(this.Size.Width, MaxHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowXem;
            }
            ((UserView)this.Parent).EventSizeChanged();
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            bool? isenable = null;
            if(cb_Enable.SelectedIndex == 1)
            {
                isenable = true;
            }
            else if(cb_Enable.SelectedIndex == 2)
            {
                isenable = false;
            }
            if (getParent().controller.SearchUser(ref result, tb_username.Text, tb_TenKH.Text, "", isenable))
            {
                dv.Rows.Clear();
                dp.setObjCount(result.Count, 10);
                if(result.Count == 0)
                {
                    Functions.ShowMessgeInfo("Không có dữ liệu nào phù hợp");
                }
                Functions.ShowMaiQuynhAnh();
            }
            else
            {
                Functions.ShowMessgeError("Search thất bại");
            }
        }
        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add( result[i].username, result[i].fullname, "$" + result[i].promosion_money.ToString(), result[i].isenable.ToString());
            }
        }
        private UserView getParent()
        {
            return (UserView)this.Parent;
        }
        public void ShowForm()
        {
            this.Size = new Size(this.Size.Width, MaxHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnShowThem;
            ((UserView)this.Parent).EventSizeChanged();
        }
        public void HideForm()
        {
            this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
            btn_ShowCloseProduct.Text = Resources.Cons.User_btnHideThem;
            ((UserView)this.Parent).EventSizeChanged();
        }
    }
}
