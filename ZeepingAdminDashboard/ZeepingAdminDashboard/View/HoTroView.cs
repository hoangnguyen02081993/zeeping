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
using ZeepingAdminDashboard.View.Sub;

namespace ZeepingAdminDashboard.View
{
    public class HoTroView : Panel
    {
        private Support_Controller controller = new Support_Controller();
        private List<UserSupport_Model> result = null;

        private UserSupport_Model selectedItem = null;

        #region Search
        private GroupBox gb_Search;
        //private Label lb_MaSP;
        //private Label lb_TenSP;
        //private TextBox tb_MaSP;
        //private TextBox tb_TenSP;

        private RadioButton rdb_All;
        private RadioButton rdb_Replied;
        private RadioButton rdb_NotReplied;


        private Button btn_Search;
        #endregion
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion
        #region Message
        private Label lb_message;
        private RichTextBox rtb_message;

        private Button btn_reviewReply;
        private Button btn_Reply;
        #endregion

        public HoTroView(Size sizeParten)
        {
            this.Location = new Point(0, 0);
            this.AutoScroll = true;
            this.Size = new Size(sizeParten.Width - 20, sizeParten.Height - 40);
            Init();
        }

        public void Init()
        {
            #region Search

            gb_Search = new GroupBox();
            gb_Search.Location = new Point(10, 20);
            gb_Search.Size = new Size(700, 50);
            gb_Search.Text = "Search";
            this.Controls.Add(gb_Search);

            rdb_All = new RadioButton();
            rdb_All.Location = new Point(10, 25);
            rdb_All.Size = new Size(150, 20);
            rdb_All.Text = "Tất cả";
            rdb_All.Checked = true;
            gb_Search.Controls.Add(rdb_All);

            rdb_Replied = new RadioButton();
            rdb_Replied.Location = new Point(rdb_All.Location.X + rdb_All.Size.Width + 10, 25);
            rdb_Replied.Size = new Size(150, 20);
            rdb_Replied.Text = "Đã trả lời";
            gb_Search.Controls.Add(rdb_Replied);

            rdb_NotReplied = new RadioButton();
            rdb_NotReplied.Location = new Point(rdb_Replied.Location.X + rdb_Replied.Size.Width + 10, 25);
            rdb_NotReplied.Size = new Size(150, 20);
            rdb_NotReplied.Text = "Chưa trả lời";
            gb_Search.Controls.Add(rdb_NotReplied);

            //lb_MaSP = new Label();
            //lb_MaSP.Location = new Point(10, 25);
            //lb_MaSP.Size = new Size(70, 20);
            //lb_MaSP.Text = "Mã SP: ";
            //gb_Search.Controls.Add(lb_MaSP);

            //tb_MaSP = new TextBox();
            //tb_MaSP.Location = new Point(lb_MaSP.Location.X + lb_MaSP.Size.Width, 20);
            //tb_MaSP.Size = new Size(200, 20);
            //gb_Search.Controls.Add(tb_MaSP);

            //lb_TenSP = new Label();
            //lb_TenSP.Location = new Point(tb_MaSP.Location.X + tb_MaSP.Size.Width + 10, 25);
            //lb_TenSP.Size = new Size(70, 20);
            //lb_TenSP.Text = "Tên SP: ";
            //gb_Search.Controls.Add(lb_TenSP);

            //tb_TenSP = new TextBox();
            //tb_TenSP.Location = new Point(lb_TenSP.Location.X + lb_TenSP.Size.Width, 20);
            //tb_TenSP.Size = new Size(200, 20);
            //gb_Search.Controls.Add(tb_TenSP);

            btn_Search = new Button();
            btn_Search.Location = new Point(rdb_NotReplied.Location.X + rdb_NotReplied.Size.Width + 10, 15);
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
            dv.Columns.Add("TNG", "Tên người gửi");
            dv.Columns.Add("MNG", "Mail người gửi");
            dv.Columns.Add("PNG", "SDT người gửi");
            dv.Columns.Add("IR", "Trạng thái");
            dv.Columns["ID"].Width = 70;
            dv.Columns["TNG"].Width = 150;
            dv.Columns["MNG"].Width = 200;
            dv.Columns["PNG"].Width = 100;
            dv.Columns["IR"].Width = 130;
            dv.Rows.Add(10);
            dv.ReadOnly = true;
            dv.AllowUserToAddRows = false;
            dv.SelectionChanged += Dv_SelectionChanged;
            dv.CellMouseClick += Dv_CellMouseClick;
            dv.MultiSelect = false;
            this.Controls.Add(dv);
            #endregion

            lb_message = new Label();
            lb_message.Location = new Point(10, dv.Location.Y + dv.Height + 10);
            lb_message.Size = new Size(200, 30);
            lb_message.Text = "Nội dung:";
            lb_message.Font = new Font("consolas", 18);
            this.Controls.Add(lb_message);

            btn_reviewReply = new Button();
            btn_reviewReply.Location = new Point(gb_Search.Width - 110, dv.Location.Y + dv.Height + 10);
            btn_reviewReply.Size = new Size(100, 30);
            btn_reviewReply.Text = "Xem lại Trả lời";
            //btn_reviewReply.Font = new Font("consolas", 18);
            btn_reviewReply.Click += Btn_reviewReply_Click;
            btn_reviewReply.Visible = false;
            this.Controls.Add(btn_reviewReply);

            btn_Reply = new Button();
            btn_Reply.Location = new Point(gb_Search.Width - 110, dv.Location.Y + dv.Height + 10);
            btn_Reply.Size = new Size(100, 30);
            btn_Reply.Text = "Trả lời";
            //btn_Reply.Font = new Font("consolas", 18);
            btn_Reply.Click += Btn_Reply_Click;
            btn_Reply.Visible = false;
            this.Controls.Add(btn_Reply);

            rtb_message = new RichTextBox();
            rtb_message.Location = new Point(10, lb_message.Location.Y + lb_message.Height + 10);
            rtb_message.Size = new Size(gb_Search.Width, 200);
            this.Controls.Add(rtb_message);
        }

        private void Btn_Reply_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                using (ReplySupportForm form = new ReplySupportForm())
                {
                    form.setFrom(selectedItem, controller);
                    form.ShowDialog();
                }
                Btn_Search_Click(null, null);

                selectedItem = result.Where(s => s.id == selectedItem.id).FirstOrDefault();
                if (selectedItem != null)
                {
                    rtb_message.Text = selectedItem.message;
                    if (selectedItem.isreplied)
                    {
                        btn_reviewReply.Visible = true;
                        btn_Reply.Visible = false;
                    }
                    else
                    {
                        btn_reviewReply.Visible = false;
                        btn_Reply.Visible = true;
                    }
                }
                else
                {
                    rtb_message.Text = string.Empty;
                    btn_reviewReply.Visible = false;
                    btn_Reply.Visible = false;
                }
            }
        }

        private void Btn_reviewReply_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                using (ReplySupportForm form = new ReplySupportForm())
                {
                    form.setFrom(selectedItem, controller);
                    form.ShowDialog();
                }
            }
        }

        private void Dv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                try
                {
                    long id = (long)dv.Rows[e.RowIndex].Cells["ID"].Value;
                    selectedItem = result.Where(s => s.id == id).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        rtb_message.Text = selectedItem.message;
                    }
                    if (selectedItem.isreplied)
                    {
                        btn_reviewReply.Visible = true;
                        btn_Reply.Visible = false;
                    }
                    else
                    {
                        btn_reviewReply.Visible = false;
                        btn_Reply.Visible = true;
                    }
                }
                catch { }
            }
        }

        private void Dv_SelectionChanged(object sender, EventArgs e)
        {
            if(dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                selectedItem = result.Where(s => s.id == id).FirstOrDefault();
                if(selectedItem != null)
                {
                    rtb_message.Text = selectedItem.message;
                }
                if (selectedItem.isreplied)
                {
                    btn_reviewReply.Visible = true;
                    btn_Reply.Visible = false;
                }
                else
                {
                    btn_reviewReply.Visible = false;
                    btn_Reply.Visible = true;
                }
            }
        }

        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add(result[i].id, result[i].name, result[i].mail, result[i].phonenumber,(result[i].isreplied)? "Đã trả lời" : "Chưa trả lời");
            }
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            bool? isreplied = null;
            if (rdb_NotReplied.Checked) isreplied = false;
            else if (rdb_Replied.Checked) isreplied = true;
            if (controller.SearchUser(ref result, isreplied))
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
                Functions.ShowMessgeInfo("Search thất bại");
            }
        }
    }
}
