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
    public class FAQview : Panel
    {
        private FAQController controller = new FAQController();
        private List<Web_page_FAQ> result = null;

        private Web_page_FAQ selectedItem = null;

        private Button btn_Refresh;
        #region DivPage
        private DivPage dp;
        #endregion
        #region dataView Product
        DataGridView dv;
        #endregion

        private ContextMenuStrip ctm;

        public FAQview(Size sizeParten)
        {
            this.Location = new Point(0, 0);
            this.AutoScroll = true;
            this.Size = new Size(sizeParten.Width - 20, sizeParten.Height - 40);
            Init();
        }

        public void Init()
        {
            btn_Refresh = new Button();
            btn_Refresh.Location = new Point(610, 20);
            btn_Refresh.Size = new Size(100, 30);
            btn_Refresh.Text = "Refresh ";
            btn_Refresh.Click += Btn_Refresh_Click;
            this.Controls.Add(btn_Refresh);

            #region DivPage
            dp = new DivPage(new Point(20, btn_Refresh.Location.Y + btn_Refresh.Height + 10));
            dp.OnIndexChanged += Dp_OnIndexChanged;
            dp.setMaxcount(10);
            this.Controls.Add(dp);
            #endregion

            #region Data
            dv = new DataGridView();
            dv.Location = new Point(10, dp.Location.Y + dp.Height + 10);
            dv.Size = new Size(700, 250);
            dv.Columns.Add("ID", "ID");
            dv.Columns.Add("QT", "Câu hỏi");
            dv.Columns["ID"].Width = 70;
            dv.Columns["QT"].Width = 580;
            dv.Rows.Add(10);
            dv.ReadOnly = true;
            dv.AllowUserToAddRows = false;
            dv.SelectionChanged += Dv_SelectionChanged;
            dv.CellMouseClick += Dv_CellMouseClick;
            dv.MultiSelect = false;
            this.Controls.Add(dv);
            #endregion

            #region Action
            ctm = new ContextMenuStrip();
            ctm.Size = new System.Drawing.Size(105, 26);

            ToolStripMenuItem itemAdd = new ToolStripMenuItem();
            itemAdd.Text = "Add FAQ";
            itemAdd.Click += ItemAdd_Click;
            itemAdd.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemAdd);

            ToolStripMenuItem itemUpdate = new ToolStripMenuItem();
            itemUpdate.Text = "Update FAQ";
            itemUpdate.Click += ItemUpdate_Click;
            itemUpdate.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemUpdate);

            ToolStripMenuItem itemDelete = new ToolStripMenuItem();
            itemDelete.Text = "Delete FAQ";
            itemDelete.Click += ItemDelete_Click;
            itemDelete.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDelete);

            ToolStripMenuItem itemDetail = new ToolStripMenuItem();
            itemDetail.Text = "Detail FAQ";
            itemDetail.Click += ItemDetail_Click;
            itemDetail.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDetail);

            dv.ContextMenuStrip = ctm;

            #endregion
        }

        private void ItemDetail_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                using (FAQActionView view = new FAQActionView(Resources.EnumClass.FAQAction.Detail,
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
                    Btn_Refresh_Click(null, null);
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
                using (FAQActionView view = new FAQActionView(Resources.EnumClass.FAQAction.Update,
                                                             ref controller,
                                                             selectedItem))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        Btn_Refresh_Click(null, null);
                    }
                }
            }
        }

        private void ItemAdd_Click(object sender, EventArgs e)
        {
            using (FAQActionView view = new FAQActionView(Resources.EnumClass.FAQAction.Add,
                                                         ref controller,
                                                         null))
            {
                if (view.ShowDialog() == DialogResult.OK)
                {
                    Btn_Refresh_Click(null, null);
                }
            }
        }

        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            result = null;
            if (controller.Refresh(ref result))
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

        private void Dv_SelectionChanged(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["ID"].Value;
                selectedItem = result.Where(s => s.id == id).FirstOrDefault();
            }
        }

        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add(result[i].id, result[i].question);
            }
        }
    }
}
