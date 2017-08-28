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
    public class DanhsachDonhangView :Panel
    {
        private Order_Controller controller = new Order_Controller(); 
        private List<Order_Model> result = null;
        private List<Order_Status_Model> lstStatus = null;
        #region Search
        private GroupBox gb_Search;
        private Label lb_begin_date;
        private DateTimePicker dtp_begin_date;
        private Label lb_end_date;
        private DateTimePicker dtp_end_date;
        private Label lb_user;
        private TextBox tb_user;
        private Label lb_status;
        private ComboBox cb_status;
        private Button btn_Search;
        #endregion
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion
        #region Action
        private ContextMenuStrip ctm;
        #endregion


        public DanhsachDonhangView(Size sizeParten) : base()
        {
            //this.BackColor = Color.Red;
            this.Size = new Size(sizeParten.Width - 40, sizeParten.Height - 40);
            this.Location = new Point(20, 20);
            this.AutoScroll = true;
            Init();
        }
        private void Init()
        {
            #region Search

            gb_Search = new GroupBox();
            gb_Search.Location = new Point(10, 10);
            gb_Search.Size = new Size(700, 130);
            gb_Search.Text = "Search";
            this.Controls.Add(gb_Search);

            lb_begin_date = new Label();
            lb_begin_date.Location = new Point(10, 25);
            lb_begin_date.Size = new Size(70, 20);
            lb_begin_date.Text = "Begin Date: ";
            gb_Search.Controls.Add(lb_begin_date);

            dtp_begin_date = new DateTimePicker();
            dtp_begin_date.Location = new Point(lb_begin_date.Location.X + lb_begin_date.Size.Width, 20);
            dtp_begin_date.Size = new Size(250, 20);
            dtp_begin_date.Format = DateTimePickerFormat.Custom;
            dtp_begin_date.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtp_begin_date.Value = DateTime.Now.AddDays(-1);
            gb_Search.Controls.Add(dtp_begin_date);

            lb_end_date = new Label();
            lb_end_date.Location = new Point(dtp_begin_date.Location.X + dtp_begin_date.Size.Width + 10, 25);
            lb_end_date.Size = new Size(70, 20);
            lb_end_date.Text = "End Date: ";
            gb_Search.Controls.Add(lb_end_date);

            dtp_end_date = new DateTimePicker();
            dtp_end_date.Location = new Point(lb_end_date.Location.X + lb_end_date.Size.Width, 20);
            dtp_end_date.Size = new Size(250, 20);
            dtp_end_date.Format = DateTimePickerFormat.Custom;
            dtp_end_date.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtp_end_date.Value = DateTime.Now;
            gb_Search.Controls.Add(dtp_end_date);

            lb_user = new Label();
            lb_user.Location = new Point(10, lb_begin_date.Location.Y + lb_begin_date.Height + 10);
            lb_user.Size = new Size(70, 20);
            lb_user.Text = "User: ";
            gb_Search.Controls.Add(lb_user);

            tb_user = new TextBox();
            tb_user.Location = new Point(lb_user.Location.X + lb_user.Size.Width, lb_user.Location.Y);
            tb_user.Size = new Size(250, 20);
            gb_Search.Controls.Add(tb_user);

            lb_status = new Label();
            lb_status.Location = new Point(tb_user.Location.X + tb_user.Size.Width + 10, lb_user.Location.Y);
            lb_status.Size = new Size(70, 20);
            lb_status.Text = "Status: ";
            gb_Search.Controls.Add(lb_status);

            cb_status = new ComboBox();
            cb_status.Location = new Point(lb_status.Location.X + lb_status.Width, lb_user.Location.Y);
            cb_status.Size = new Size(250, 20);
            cb_status.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_status.DisplayMember = "name";
            gb_Search.Controls.Add(cb_status);


            btn_Search = new Button();
            btn_Search.Size = new Size(100, 30);
            btn_Search.Location = new Point(cb_status.Location.X + cb_status.Width - btn_Search.Width, lb_user.Location.Y + lb_user.Height + 10);
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
            dv.Columns.Add("UN", "User Name");
            dv.Columns.Add("Q", "Quantity");
            dv.Columns.Add("D", "CreateDate");
            dv.Columns.Add("SS", "Status");
            dv.Columns["ID"].Width = 50;
            dv.Columns["UN"].Width = 250;
            dv.Columns["Q"].Width = 70;
            dv.Columns["D"].Width = 150;
            dv.Columns["SS"].Width = 130;
            dv.Rows.Add(10);
            dv.AllowUserToAddRows = false;
            dv.ReadOnly = true;
            this.Controls.Add(dv);
            #endregion

            #region Action
            ctm = new ContextMenuStrip();
            ctm.Size = new System.Drawing.Size(105, 26);

            ToolStripMenuItem itemChangestatus = new ToolStripMenuItem();
            itemChangestatus.Text = "Change status";
            itemChangestatus.Click += ItemChangestatus_Click;
            itemChangestatus.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemChangestatus);

            ToolStripMenuItem itemDelete = new ToolStripMenuItem();
            itemDelete.Text = "Delete Order";
            itemDelete.Click += ItemDelete_Click;
            itemDelete.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDelete);

            ToolStripMenuItem itemDetail = new ToolStripMenuItem();
            itemDetail.Text = "Detail Order";
            itemDetail.Click += ItemDetail_Click;
            itemDetail.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDetail);

            dv.ContextMenuStrip = ctm;

            #endregion
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                if (controller.DeleteOrder(id))
                {
                    Functions.ShowMessgeInfo("Xóa thành công");
                    var itemremove = result.Where(r => r.order_id == id).FirstOrDefault();
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
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["ID"].Value;
                    if (controller.DeleteOrder(id))
                    {
                        Functions.ShowMessgeInfo("Xóa thành công");
                        var itemremove = result.Where(r => r.order_id == id).FirstOrDefault();
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

        private void ItemChangestatus_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                short CurrentStatusId = result.Where(r => r.order_id == id).FirstOrDefault().isOrderCompleted;
                using (ChangeOrderStatusView view = new ChangeOrderStatusView(lstStatus, CurrentStatusId))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.statusID == CurrentStatusId) return;
                        if (controller.ChangeStatusOrder(id,view.statusID))
                        {
                            Functions.ShowMessgeInfo("Thay đổi thành công");
                            result.Where(r => r.order_id == id).FirstOrDefault().isOrderCompleted = view.statusID;
                            Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                        }
                        else
                        {
                            Functions.ShowMessgeError("Thay đổi thất bại");
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["ID"].Value;
                    short CurrentStatusId = result.Where(r => r.order_id == id).FirstOrDefault().isOrderCompleted;
                    using (ChangeOrderStatusView view = new ChangeOrderStatusView(lstStatus, CurrentStatusId))
                    {
                        if (view.ShowDialog() == DialogResult.OK)
                        {
                            if (view.statusID == CurrentStatusId) return;
                            if (controller.ChangeStatusOrder(id, view.statusID))
                            {
                                Functions.ShowMessgeInfo("Thay đổi thành công");
                                result.Where(r => r.order_id == id).FirstOrDefault().isOrderCompleted = view.statusID;
                                Dp_OnIndexChanged((dp.CurrentPage - 1) * dp.ObjCount);
                            }
                            else
                            {
                                Functions.ShowMessgeError("Thay đổi thất bại");
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để thay đổi");
                }
            }
        }

        private void ItemDetail_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                var item = result.Where(o => o.order_id == id).FirstOrDefault();
                using (DetailOrderView view = new DetailOrderView(ref controller, item))
                {
                    view.ShowDialog();
                }

            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["ID"].Value;
                    var item = result.Where(o => o.order_id == id).FirstOrDefault();
                    using (DetailOrderView view = new DetailOrderView(ref controller, item))
                    {
                        view.ShowDialog();
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để xem");
                }
            }
        }  

        public void InitData()
        {
            lstStatus = null;
            if (controller.getStatusList(ref lstStatus))
            {
                cb_status.Items.AddRange(lstStatus.ToArray());
                if(cb_status.Items.Count > 0)
                {
                    cb_status.SelectedIndex = 0;
                }
            }
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            if(cb_status.SelectedIndex == -1)
            {
                Functions.ShowMessgeError("Chưa chọn status");
                return;
            }
            if (controller.SearchOrder(ref result, dtp_begin_date.Value, dtp_end_date.Value, tb_user.Text, ((Order_Status_Model)cb_status.SelectedItem).id))
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
                dv.Rows.Add(result[i].order_id, result[i].username, result[i].quantity.ToString(), result[i].createDate.ToString("yyyy-MM-dd HH:mm:ss"), ((lstStatus != null) ? lstStatus.Where(s => s.id == result[i].isOrderCompleted).FirstOrDefault().name : result[i].isOrderCompleted.ToString()));
            }
        }
    }
}
