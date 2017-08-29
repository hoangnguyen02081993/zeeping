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
using ZeepingAdminDashboard.ObjClass;
using ZeepingAdminDashboard.Resources;
using ZeepingAdminDashboard.View.Sub;

namespace ZeepingAdminDashboard.View
{
    public class CollectionsView : Panel
    {
        private CollectionsController controller = new CollectionsController();


        private List<Web_Collections_Model> result = null;

        private Web_Collections_Model selectedItem = null;

        #region Search
        private GroupBox gb_Search;
        private Label lb_MaSP;
        private Label lb_TenSP;
        private TextBox tb_MaSP;
        private TextBox tb_TenSP;
        private Button btn_Search;
        #endregion
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion

        private ContextMenuStrip ctm;

        public CollectionsView(Size sizeParten)
        {
            this.Location = new Point(20, 20);
            this.AutoScroll = true;
            this.Size = new Size(sizeParten.Width - 40, sizeParten.Height - 40);
            Init();
        }
        public void Init()
        {

            #region Search

            gb_Search = new GroupBox();
            gb_Search.Location = new Point(10, 10);
            gb_Search.Size = new Size(700, 50);
            gb_Search.Text = "Search";
            this.Controls.Add(gb_Search);

            lb_MaSP = new Label();
            lb_MaSP.Location = new Point(10, 25);
            lb_MaSP.Size = new Size(100, 20);
            lb_MaSP.Text = "Mã Collections: ";
            gb_Search.Controls.Add(lb_MaSP);

            tb_MaSP = new TextBox();
            tb_MaSP.Location = new Point(lb_MaSP.Location.X + lb_MaSP.Size.Width, 20);
            tb_MaSP.Size = new Size(170, 20);
            gb_Search.Controls.Add(tb_MaSP);

            lb_TenSP = new Label();
            lb_TenSP.Location = new Point(tb_MaSP.Location.X + tb_MaSP.Size.Width + 10, 25);
            lb_TenSP.Size = new Size(120, 20);
            lb_TenSP.Text = "Tên Collections: ";
            gb_Search.Controls.Add(lb_TenSP);

            tb_TenSP = new TextBox();
            tb_TenSP.Location = new Point(lb_TenSP.Location.X + lb_TenSP.Size.Width, 20);
            tb_TenSP.Size = new Size(170, 20);
            gb_Search.Controls.Add(tb_TenSP);

            btn_Search = new Button();
            btn_Search.Location = new Point(tb_TenSP.Location.X + tb_TenSP.Size.Width + 10, 15);
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
            dv.Columns.Add("MC", "Mã collection");
            dv.Columns.Add("NC", "Tên collection");
            dv.Columns.Add("TC", "Title collection");
            dv.Columns.Add("SS", "Bản chính thức");
            dv.Columns["MC"].Width = 50;
            dv.Columns["NC"].Width = 200;
            dv.Columns["TC"].Width = 350;
            dv.Columns["SS"].Width = 50;
            dv.Rows.Add(10);
            dv.ReadOnly = true;
            dv.AllowUserToAddRows = false;
            dv.MultiSelect = false;
            dv.CellMouseClick += Dv_CellMouseClick;
            dv.SelectionChanged += Dv_SelectionChanged;
            this.Controls.Add(dv);
            #endregion

            #region Action
            ctm = new ContextMenuStrip();
            ctm.Size = new System.Drawing.Size(105, 26);

            ToolStripMenuItem itemAdd = new ToolStripMenuItem();
            itemAdd.Text = "Add";
            itemAdd.Click += ItemAdd_Click;
            itemAdd.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemAdd);

            ToolStripMenuItem itemUpdate = new ToolStripMenuItem();
            itemUpdate.Text = "Update";
            itemUpdate.Click += ItemUpdate_Click;
            itemUpdate.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemUpdate);

            ToolStripMenuItem itemDelete = new ToolStripMenuItem();
            itemDelete.Text = "Delete";
            itemDelete.Click += ItemDelete_Click;
            itemDelete.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDelete);

            ToolStripMenuItem itemDetail = new ToolStripMenuItem();
            itemDetail.Text = "Detail";
            itemDetail.Click += ItemDetail_Click;
            itemDetail.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDetail);

            dv.ContextMenuStrip = ctm;

            #endregion
        }

        private void Dv_SelectionChanged(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                selectedItem = result.Where(s => s.id == id).FirstOrDefault();
            }
        }

        private void Dv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    long id = (long)dv.Rows[e.RowIndex].Cells["ID"].Value;
                    selectedItem = result.Where(s => s.id == id).FirstOrDefault();
                }
                catch { }
            }
        }

        private void ItemDetail_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                using (CollectionsActionView view = new CollectionsActionView(Resources.EnumClass.CollectionsAction.Detail,
                                                 ref controller,
                                                 selectedItem))
                {
                    view.ShowDialog();
                }
            }
        }

        private void ItemDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                if (controller.Delete(selectedItem))
                {
                    Common.Functions.ShowMessgeInfo("Delete Success");
                    Btn_Search_Click(null, null);
                }
                else
                {
                    Common.Functions.ShowMessgeInfo("Delete Fail");
                }
            }
        }

        private void ItemUpdate_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                using (CollectionsActionView view = new CollectionsActionView(Resources.EnumClass.CollectionsAction.Update,
                                                             ref controller,
                                                             selectedItem))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        Btn_Search_Click(null, null);
                    }
                }
            }
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            using (CollectionsActionView view = new CollectionsActionView(Resources.EnumClass.CollectionsAction.Add,
                                             ref controller,
                                             null))
            {
                if (view.ShowDialog() == DialogResult.OK)
                {
                    Btn_Search_Click(null, null);
                }
            }
        }

        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add(result[i].id, result[i].name, result[i].title, result[i].isdraft);
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            if (controller.SearchCollections(ref result, tb_MaSP.Text, tb_TenSP.Text))
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
            selectedItem = null;
        }
    }
}
