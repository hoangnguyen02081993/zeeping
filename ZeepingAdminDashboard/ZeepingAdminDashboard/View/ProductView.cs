using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZeepingAdminDashboard.ObjClass;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Resources;
using ZeepingAdminDashboard.View.Sub;

namespace ZeepingAdminDashboard.View
{
    public class ProductView : Panel
    {
        public Product_Controller controller = new Product_Controller();

        private DisPlayProduct showProduct;
        private AddProduct addProduct;
        public ProductView(Size sizeParten)
        {
            // Init
            this.Location = new Point(20, 20);
            this.Size = new Size(sizeParten.Width - 40, sizeParten.Height - 40);
            this.AutoScroll = true;
            Init();
        }
        private void Init()
        {
            showProduct = new DisPlayProduct(this.Size);
            this.Controls.Add(showProduct);

            addProduct = new AddProduct(this.Size);
            addProduct.Location = new Point(0, showProduct.Height);
            addProduct.OnResizeChanged += AddProduct_OnResizeChanged;
            this.Controls.Add(addProduct);
        }
        public void InitData()
        {
            addProduct.InitData();
        }
        private void AddProduct_OnResizeChanged(object obj)
        {
            if (obj is DisPlayProduct)
            {
                EventSizeChanged();
            }
        }

        public void EventSizeChanged()
        {
            addProduct.Location = new Point(0, showProduct.Height);            
        }
    }
    public class DisPlayProduct : Panel
    {
        private int MaxHeight = 500;
        private List<Product_Model> result = null;

        private Button btn_ShowCloseProduct;
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

        public DisPlayProduct(Size sizeParten)
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(sizeParten.Width - 20, Resources.Cons.MinHeight);
            Init();
        }
        public void Init()
        {
            btn_ShowCloseProduct = new Button();
            btn_ShowCloseProduct.Text = Cons.Test_btnHideXem;
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

            lb_MaSP = new Label();
            lb_MaSP.Location = new Point(10, 25);
            lb_MaSP.Size = new Size(70, 20);
            lb_MaSP.Text = "Mã SP: ";
            gb_Search.Controls.Add(lb_MaSP);

            tb_MaSP = new TextBox();
            tb_MaSP.Location = new Point(lb_MaSP.Location.X + lb_MaSP.Size.Width, 20);
            tb_MaSP.Size = new Size(200, 20);
            gb_Search.Controls.Add(tb_MaSP);

            lb_TenSP = new Label();
            lb_TenSP.Location = new Point(tb_MaSP.Location.X + tb_MaSP.Size.Width + 10, 25);
            lb_TenSP.Size = new Size(70, 20);
            lb_TenSP.Text = "Tên SP: ";
            gb_Search.Controls.Add(lb_TenSP);

            tb_TenSP = new TextBox();
            tb_TenSP.Location = new Point(lb_TenSP.Location.X + lb_TenSP.Size.Width, 20);
            tb_TenSP.Size = new Size(200, 20);
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
            dv.Columns.Add("MSP","Mã sản phẩm");
            dv.Columns.Add("TSP","Tên sản phẩm");
            dv.Columns.Add("HTG","Hash Tag");
            dv.Columns["TSP"].Width = 270;
            dv.Columns["HTG"].Width = 280;
            dv.Rows.Add(10);
            dv.ReadOnly = true;
            dv.AllowUserToAddRows = false;
            this.Controls.Add(dv);
            #endregion

            #region Action
            ctm = new ContextMenuStrip();
            ctm.Size = new System.Drawing.Size(105, 26);

            ToolStripMenuItem itemEditProduct = new ToolStripMenuItem();
            itemEditProduct.Text = "Edit";
            itemEditProduct.Click += ItemEditProduct_Click;
            itemEditProduct.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemEditProduct);

            ToolStripMenuItem itemDeleteProduct = new ToolStripMenuItem();
            itemDeleteProduct.Text = "Delete";
            itemDeleteProduct.Click += ItemDeleteProduct_Click;
            itemDeleteProduct.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemDeleteProduct);

            ToolStripMenuItem itemChangeHashtag = new ToolStripMenuItem();
            itemChangeHashtag.Text = "Change HashTag";
            itemChangeHashtag.Click += ItemChangeHashtag_Click;
            itemChangeHashtag.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemChangeHashtag);

            ToolStripMenuItem itemChangestatus = new ToolStripMenuItem();
            itemChangestatus.Text = "Change Catogary";
            itemChangestatus.Click += ItemChangestatus_Click;
            itemChangestatus.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemChangestatus);

            ToolStripMenuItem itemFeatureImage = new ToolStripMenuItem();
            itemFeatureImage.Text = "Change Feature Image";
            itemFeatureImage.Click += ItemFeatureImage_Click;
            itemFeatureImage.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemFeatureImage);

            ToolStripMenuItem itemVision = new ToolStripMenuItem();
            itemVision.Text = "Change Default Vision (Front or Behide)";
            itemVision.Click += ItemVision_Click;
            itemVision.Size = new System.Drawing.Size(104, 22);
            ctm.Items.Add(itemVision);

            dv.ContextMenuStrip = ctm;

            #endregion
        }

        private void ItemVision_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;
                using (ChangeDefaultVisionProductView view = new ChangeDefaultVisionProductView(getParent().controller, id))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (getParent().controller.ChangeDefaultVision(id, view.IsFront))
                        {
                            result.Where(p => p.product_id == id).FirstOrDefault().isFrontVision = view.IsFront;
                            Functions.ShowMessgeInfo("Thay đổi bề mặt mặc định thành công");
                        }
                        else
                        {
                            Functions.ShowMessgeError("Thay đổi bề mặt mặc định thất bại");
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;
                    using (ChangeDefaultVisionProductView view = new ChangeDefaultVisionProductView(getParent().controller, id))
                    {
                        if (view.ShowDialog() == DialogResult.OK)
                        {
                            if (getParent().controller.ChangeDefaultVision(id, view.IsFront))
                            {
                                result.Where(p => p.product_id == id).FirstOrDefault().isFrontVision = view.IsFront;
                                Functions.ShowMessgeInfo("Thay đổi bề mặt mặc định thành công");
                            }
                            else
                            {
                                Functions.ShowMessgeError("Thay đổi bề mặt mặc định thất bại");
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void ItemDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;
                if(Functions.ShowYesNoQuestion("Bạn có chắc chắn muốn Delete không ?") == DialogResult.Yes)
                {
                    var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                    if(Product != null)
                    {
                        if(getParent().controller.DeleteProduct(Product))
                        {
                            Functions.ShowMessgeInfo("Delete success");
                            Btn_Search_Click(null, null);
                        }
                        else
                        {
                            Functions.ShowMessgeError("Delete Failed");
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;
                    if (Functions.ShowYesNoQuestion("Bạn có chắc chắn muốn Delete không ?") == DialogResult.Yes)
                    {
                        var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                        if (Product != null)
                        {
                            if (getParent().controller.DeleteProduct(Product))
                            {
                                Functions.ShowMessgeInfo("Delete success");
                                Btn_Search_Click(null, null);
                            }
                            else
                            {
                                Functions.ShowMessgeError("Delete Failed");
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void ItemEditProduct_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;
                var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                if (Product != null)
                {
                    using (EditProductView view = new EditProductView(getParent().controller, Product))
                    {
                        view.ShowDialog();
                        if(view.IsChange)
                        {
                            Product = view.product;
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;
                    var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                    if (Product != null)
                    {
                        using (EditProductView view = new EditProductView(getParent().controller, Product))
                        {
                            view.ShowDialog();
                            if (view.IsChange)
                            {
                                Product = view.product;
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void ItemFeatureImage_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;

                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    ofd.Title = "Vui lòng chọn file";
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                        if(Product != null)
                        {
                            if (getParent().controller.ChangeFeatureImage(Product, ofd.FileName))
                            {
                                Functions.ShowMessgeInfo("Change Feature Image success");
                            }
                            else
                            {
                                Functions.ShowMessgeError("Change Feature Image Failed");
                            }
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;

                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                        ofd.Title = "Vui lòng chọn file";
                        ofd.Multiselect = false;
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                            if (Product != null)
                            {
                                if (getParent().controller.ChangeFeatureImage(Product, ofd.FileName))
                                {
                                    Functions.ShowMessgeInfo("Change Feature Image success");
                                }
                                else
                                {
                                    Functions.ShowMessgeError("Change Feature Image Failed");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void ItemChangeHashtag_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;
                using (ChangeHashTagView view = new ChangeHashTagView(getParent().controller, id))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (getParent().controller.ChangeHashTag(id, view.NewHashTag))
                        {
                            result.Where(p => p.product_id == id).FirstOrDefault().hashtag = view.NewHashTag;
                            for (int i = 0; i < dv.Rows.Count; i++)
                            {
                                if(dv.Rows[i].Cells[0].Value.Equals(id))
                                {
                                    dv.Rows[i].Cells[2].Value = view.NewHashTag;
                                    break;
                                }
                            }
                            Functions.ShowMessgeInfo("Thay đổi HashTag thành công");
                        }
                        else
                        {
                            Functions.ShowMessgeError("Thay đổi HashTag thất bại");
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;
                    using (ChangeHashTagView view = new ChangeHashTagView(getParent().controller, id))
                    {
                        if (view.ShowDialog() == DialogResult.OK)
                        {
                            if (getParent().controller.ChangeHashTag(id, view.NewHashTag))
                            {
                                result.Where(p => p.product_id == id).FirstOrDefault().hashtag = view.NewHashTag;
                                for (int i = 0; i < dv.Rows.Count; i++)
                                {
                                    if (dv.Rows[i].Cells[0].Value.Equals(id))
                                    {
                                        dv.Rows[i].Cells[2].Value = view.NewHashTag;
                                        break;
                                    }
                                }
                                Functions.ShowMessgeInfo("Thay đổi HashTag thành công");
                            }
                            else
                            {
                                Functions.ShowMessgeError("Thay đổi HashTag thất bại");
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void ItemChangestatus_Click(object sender, EventArgs e)
        {
            if (dv.SelectedRows.Count == 1)
            {
                long id = (long)dv.SelectedRows[0].Cells["MSP"].Value;
                using (ChangeCatogarys view = new ChangeCatogarys(getParent().controller, id))
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (getParent().controller.ChangeCatogary(id, view.NewCatogarys))
                        {
                            var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                            if(Product != null)
                            {
                                Product.Catogarys = view.NewCatogarys;
                            }

                            Functions.ShowMessgeInfo("Thay đổi catogarys thành công");
                        }
                        else
                        {
                            Functions.ShowMessgeError("Thay đổi catogarys thất bại");
                        }
                    }
                }
            }
            else
            {
                if (dv.SelectedCells.Count == 1)
                {
                    long id = (long)dv.Rows[dv.SelectedCells[0].RowIndex].Cells["MSP"].Value;
                    using (ChangeCatogarys view = new ChangeCatogarys(getParent().controller, id))
                    {
                        if(view.ShowDialog() == DialogResult.OK)
                        {
                            if(getParent().controller.ChangeCatogary(id,view.NewCatogarys))
                            {
                                var Product = result.Where(p => p.product_id == id).FirstOrDefault();
                                if (Product != null)
                                {
                                    Product.Catogarys = view.NewCatogarys;
                                }
                                Functions.ShowMessgeInfo("Thay đổi catogarys thành công");
                            }
                            else
                            {
                                Functions.ShowMessgeError("Thay đổi catogarys thất bại");
                            }
                        }
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Chưa chọn dữ liệu để đổi");
                }
            }
        }

        private void Dp_OnIndexChanged(int Index)
        {
            dv.Rows.Clear();
            int condition = (Index + 10 > result.Count) ? result.Count : Index + 10;
            for (int i = Index; i < condition; i++)
            {
                dv.Rows.Add(result[i].product_id, result[i].product_name, result[i].hashtag);
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            result = null;
            if(getParent().controller.Searchproduct(ref result,tb_MaSP.Text,tb_TenSP.Text))
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

        private void Btn_ShowCloseProduct_Click(object sender, EventArgs e)
        {
            if(btn_ShowCloseProduct.Text == Resources.Cons.Test_btnShowXem) // Thuc hien chuc nang hide
            {
                this.Size = new Size(this.Size.Width, Resources.Cons.MinHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.Test_btnHideXem;
            }
            else // thuc hien chuc nang show
            {
                this.Size = new Size(this.Size.Width, MaxHeight);
                btn_ShowCloseProduct.Text = Resources.Cons.Test_btnShowXem;
            }
            ((ProductView)this.Parent).EventSizeChanged();
        }
        private ProductView getParent()
        {
            return (ProductView)this.Parent;
        }
    }
    public class AddProduct : Panel
    {
        private string FrontDesignFileName = string.Empty;
        private string BehideDesignFileName = string.Empty;

        public event Resources.DelegateClass.ResizeChanged OnResizeChanged;

        private Button btn_ShowCloseProduct;

        private List<Product_Color_Model> lstColor = null;


        #region Product Infos
        private Panel pn_Info;
        private LablewithConsolasfont lb_TenSP;
        private LablewithConsolasfont lb_LinkSP_direct;
        private LablewithConsolasfont lb_title;
        private LablewithConsolasfont lb_content;
        private LablewithConsolasfont lb_StyleList;
        private LablewithConsolasfont lb_ColorList;
        private TextBox tb_TenSP;
        private TextBox tb_LinkSP_direct;
        private TextBox tb_title;
        private RichTextBox rtb_content;
        private CheckedListBox clb_style;
        private CheckedListBox clb_color;
        #endregion

        private Sub.PanelImageProduct pn_Image;

        private Button btn_BrownFrontImage;
        private Button btn_DeleteFrontImage;

        private Button btn_BrownBehideImage;
        private Button btn_DeleteBehideImage;

        private Button btn_Addproduct;

        public AddProduct(Size sizeParten)
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(sizeParten.Width - 20, Resources.Cons.MinHeight);
            Init();


        }
        private void Init()
        {
            btn_ShowCloseProduct = new Button();
            btn_ShowCloseProduct.Text = Cons.Test_btnHideThem;
            btn_ShowCloseProduct.Location = new Point(20, 5);
            btn_ShowCloseProduct.Size = new Size(300, 30);
            btn_ShowCloseProduct.Click += Btn_ShowCloseProduct_Click;
            this.Controls.Add(btn_ShowCloseProduct);

            btn_Addproduct = new Button();
            btn_Addproduct.Location = new Point(20, 50);
            btn_Addproduct.Size = new Size(200, 50);
            btn_Addproduct.Click += Btn_Addproduct_Click;
            btn_Addproduct.BackgroundImage = Properties.Resources.addproductico;
            btn_Addproduct.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(btn_Addproduct);

            #region Product Info
            pn_Info = new Panel();
            pn_Info.Location = new Point(20, btn_Addproduct.Location.Y + btn_Addproduct.Height + 5);
            pn_Info.Size = new Size(this.Width, 450);
            this.Controls.Add(pn_Info);

            lb_TenSP = new LablewithConsolasfont();
            lb_TenSP.Location = new Point(10, 5);
            lb_TenSP.Size = new Size(70, 20);
            lb_TenSP.Text = "Tên SP: ";
            pn_Info.Controls.Add(lb_TenSP);

            tb_TenSP = new TextBox();
            tb_TenSP.Location = new Point(lb_TenSP.Location.X + lb_TenSP.Size.Width, lb_TenSP.Location.Y - Resources.Cons.DeltaLableandTextBoxHieght);
            tb_TenSP.Size = new Size(580, 20);
            pn_Info.Controls.Add(tb_TenSP);

            lb_LinkSP_direct = new LablewithConsolasfont();
            lb_LinkSP_direct.Location = new Point(10, lb_TenSP.Location.Y + lb_TenSP.Size.Height + 10);
            lb_LinkSP_direct.Size = new Size(70, 20);
            lb_LinkSP_direct.Text = "Link SP: ";
            pn_Info.Controls.Add(lb_LinkSP_direct);

            tb_LinkSP_direct = new TextBox();
            tb_LinkSP_direct.Location = new Point(lb_LinkSP_direct.Location.X + lb_LinkSP_direct.Size.Width, lb_LinkSP_direct.Location.Y - Resources.Cons.DeltaLableandTextBoxHieght);
            tb_LinkSP_direct.Size = new Size(580, 20);
            pn_Info.Controls.Add(tb_LinkSP_direct);

            lb_title = new LablewithConsolasfont();
            lb_title.Location = new Point(10, lb_LinkSP_direct.Location.Y + lb_LinkSP_direct.Size.Height + 10);
            lb_title.Size = new Size(70, 20);
            lb_title.Text = "Title SP: ";
            pn_Info.Controls.Add(lb_title);

            tb_title = new TextBox();
            tb_title.Location = new Point(lb_title.Location.X + lb_title.Size.Width, lb_title.Location.Y - Resources.Cons.DeltaLableandTextBoxHieght);
            tb_title.Size = new Size(580, 20);
            pn_Info.Controls.Add(tb_title);

            lb_content = new LablewithConsolasfont();
            lb_content.Location = new Point(10, lb_title.Location.Y + lb_title.Size.Height + 10);
            lb_content.Size = new Size(70, 20);
            lb_content.Text = "Content SP: ";
            pn_Info.Controls.Add(lb_content);

            rtb_content = new RichTextBox();
            rtb_content.Location = new Point(10, lb_content.Location.Y + lb_content.Size.Height);
            rtb_content.Size = new Size(650, 200);
            pn_Info.Controls.Add(rtb_content);


            lb_StyleList = new LablewithConsolasfont();
            lb_StyleList.Location = new Point(10, rtb_content.Location.Y + rtb_content.Size.Height + 10);
            lb_StyleList.Size = new Size(100, 20);
            lb_StyleList.Text = "Style List: ";
            pn_Info.Controls.Add(lb_StyleList);

            clb_style = new CheckedListBox();
            clb_style.Location = new Point(10, lb_StyleList.Location.Y + lb_StyleList.Size.Height);
            clb_style.DisplayMember = "Name";
            clb_style.ItemCheck += Clb_style_ItemCheck;
            clb_style.Size = new Size(200, 100);
            clb_style.CheckOnClick = true;
            pn_Info.Controls.Add(clb_style);

            btn_BrownFrontImage = new Button();
            btn_BrownFrontImage.Location = new Point(lb_StyleList.Location.X + lb_StyleList.Size.Width + 120, rtb_content.Location.Y + rtb_content.Size.Height + 30);
            btn_BrownFrontImage.Size = new Size(150, 40);
            btn_BrownFrontImage.Text = "Browser Front Design";
            btn_BrownFrontImage.Click += Btn_BrownFrontImage_Click;
            pn_Info.Controls.Add(btn_BrownFrontImage);

            btn_DeleteFrontImage = new Button();
            btn_DeleteFrontImage.Location = new Point(lb_StyleList.Location.X + lb_StyleList.Size.Width + 300, lb_StyleList.Location.Y + lb_StyleList.Size.Height);
            btn_DeleteFrontImage.Size = new Size(150, 40);
            btn_DeleteFrontImage.Click += Btn_DeleteFrontImage_Click;
            btn_DeleteFrontImage.Text = "Delete Front Design";
            pn_Info.Controls.Add(btn_DeleteFrontImage);

            btn_BrownBehideImage = new Button();
            btn_BrownBehideImage.Location = new Point(lb_StyleList.Location.X + lb_StyleList.Size.Width + 120, btn_BrownFrontImage.Location.Y + btn_BrownFrontImage.Size.Height);
            btn_BrownBehideImage.Size = new Size(150, 40);
            btn_BrownBehideImage.Text = "Browser Behide Design";
            btn_BrownBehideImage.Click += Btn_BrownBehideImage_Click;
            pn_Info.Controls.Add(btn_BrownBehideImage);

            btn_DeleteBehideImage = new Button();
            btn_DeleteBehideImage.Location = new Point(lb_StyleList.Location.X + lb_StyleList.Size.Width + 300, btn_DeleteFrontImage.Location.Y + btn_DeleteFrontImage.Size.Height);
            btn_DeleteBehideImage.Size = new Size(150, 40);
            btn_DeleteBehideImage.Click += Btn_DeleteBehideImage_Click;
            btn_DeleteBehideImage.Text = "Delete Behide Design";
            pn_Info.Controls.Add(btn_DeleteBehideImage);

            #endregion

            #region Image Region

            pn_Image = new Sub.PanelImageProduct(this.Size);
            pn_Image.Location = new Point(20, pn_Info.Location.Y + pn_Info.Height + 5);
            pn_Image.OnReSizeChanged += Pn_Image_OnReSizeChanged;
            this.Controls.Add(pn_Image);

            #endregion
        }

        private void Btn_DeleteBehideImage_Click(object sender, EventArgs e)
        {
            if (pn_Image != null)
            {
                pn_Image.deleteBehideDesign();
                BehideDesignFileName = string.Empty;
            }
        }

        private void Btn_BrownBehideImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PNG files (*.png)|*.png";
                ofd.Title = "Vui lòng chọn file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BehideDesignFileName = ofd.FileName;
                    if (pn_Image != null)
                    {
                        pn_Image.setBehideDesign(BehideDesignFileName);
                    }

                }
            }
        }

        private void Btn_Addproduct_Click(object sender, EventArgs e)
        {
            if(pn_Image != null)
            {
                if(tb_TenSP.Text.Equals(string.Empty))
                {
                    // TODO
                    Functions.ShowMessgeError("Chưa nhập thông tin \"tên sản phẩm\"");
                    return;
                }
                if (tb_LinkSP_direct.Text.Equals(string.Empty))
                {
                    // TODO
                    Functions.ShowMessgeError("Chưa nhập thông tin \"link sản phẩm\"");
                    return;
                }
                if (tb_title.Text.Equals(string.Empty))
                {
                    // TODO
                    Functions.ShowMessgeError("Chưa nhập thông tin \"title sản phẩm\"");
                    return;
                }
                if (rtb_content.Text.Equals(string.Empty))
                {
                    // TODO
                    Functions.ShowMessgeError("Chưa nhập thông tin \"content sản phẩm\"");
                    return;
                }
                if (clb_style.CheckedItems.Count == 0)
                {
                    // TODO
                    Functions.ShowMessgeError("Chưa chọn bất cứ style nào cho sản phẩm");
                    return;
                }
                string FeaturedImage = string.Empty;
                bool IsFeaturedProduct = false;
                string ExtensionFeaturedImage = string.Empty;
                string Catogarys = string.Empty;
                string HashTagString = string.Empty;
                bool IsFront;
                using (AdditionalProductView view = new AdditionalProductView(getParent().controller))
                {
                    if(view.ShowDialog() == DialogResult.OK)
                    {
                        FeaturedImage = view.ImageFileName;
                        IsFeaturedProduct = view.IsFeaturedProduct;
                        ExtensionFeaturedImage = view.ExtensionImage;
                        Catogarys = view.AllCatogary;
                        HashTagString = view.HashTagString;
                        IsFront = view.IsFront;
                    }
                    else
                    {
                        return;
                    }
                }
                string ProductLink = CheckExistProductLink(Functions.getWebNameValid(tb_TenSP.Text));
                if(ProductLink == string.Empty)
                {
                    Functions.ShowMessgeError("Không có kết nối DB");
                    return;
                }
                // Gui anh Feature lên thu muc
                if (FeaturedImage != string.Empty)
                {
                    if (!FTPAction.sendFile(AppConfig.FTPHost,
                        AppConfig.FTPUser,
                        AppConfig.FTPPassword,
                        FTPAction.localPathFeaturedImage,
                        ProductLink + ExtensionFeaturedImage,
                        Functions.GetPathFileName(FeaturedImage),
                        Functions.GetSafeFileName(FeaturedImage)))
                    {
                        //TODO
                        Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình gửi ảnh Featured lên web");
                        return;
                    }
                }

                // Gui anh design lên thu muc
                if (FrontDesignFileName != string.Empty)
                {
                    if (!FTPAction.sendFile(AppConfig.FTPHost,
                                            AppConfig.FTPUser,
                                            AppConfig.FTPPassword,
                                            FTPAction.localPathDesign,
                                            Functions.GetSafeFileName(FrontDesignFileName).Replace(" ", ""),
                                            Functions.GetPathFileName(FrontDesignFileName),
                                            Functions.GetSafeFileName(FrontDesignFileName)))
                    {
                        //TODO
                        Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình gửi ảnh design lên web");
                        return;
                    }
                }
                if (BehideDesignFileName != string.Empty)
                {
                    if (!FTPAction.sendFile(AppConfig.FTPHost,
                                            AppConfig.FTPUser,
                                            AppConfig.FTPPassword,
                                            FTPAction.localPathDesign,
                                            Functions.GetSafeFileName(BehideDesignFileName).Replace(" ", ""),
                                            Functions.GetPathFileName(BehideDesignFileName),
                                            Functions.GetSafeFileName(BehideDesignFileName)))
                    {
                        //TODO
                        Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình gửi ảnh design lên web");
                        return;
                    }
                }



                // Luu database
                string product_image_design = string.Empty;
                product_image_design += (FrontDesignFileName == string.Empty) ? "None" : Functions.GetSafeFileName(FrontDesignFileName).Replace(" ", "");
                product_image_design += ",";
                product_image_design += (BehideDesignFileName == string.Empty) ? "None" : Functions.GetSafeFileName(BehideDesignFileName).Replace(" ", "");

                Product_Model pd = new Product_Model()
                {
                    product_name = tb_TenSP.Text.Replace("\'", "\\\'"),
                    product_image_design = product_image_design,
                    product_link = tb_LinkSP_direct.Text.Replace("\'", "\\\'"),
                    product_title = tb_title.Text.Replace("\'", "\\\'"),
                    product_content = rtb_content.Text.Replace("\'", "\\\'").Replace("\n", "<br/>"),
                    color_list = getColorList(),
                    style_list = pn_Image.getStyleList(),
                    style_design = pn_Image.getStyleDesign(),
                    linkFeaturedImage = ProductLink + ExtensionFeaturedImage,
                    linkProduct = ProductLink,
                    isFeaturedProduct = IsFeaturedProduct,
                    Catogarys = Catogarys,
                    rangcost = "$" + getMinCostStyle() + " - $" + getMaxCostStyle(),
                    hashtag = HashTagString,
                    isFrontVision = IsFront
                };
                if(!getParent().controller.Addproduct(pd))
                {
                    //TODO
                    Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình ghi Database");
                    return;
                }

                //TODO Info
                Functions.ShowMessgeInfo("Add product thành công");
                Functions.ShowMaiQuynhAnh();

            }
        }
        private string getColorList()
        {
            string result = string.Empty;



            result += "var color_pro = {";

            string ColorUseList = pn_Image.getColorList();

            foreach (string item in ColorUseList.Split(','))
            {
                Product_Color_Model color = lstColor.Where(c => c.Id == long.Parse(item)).FirstOrDefault();
                if (color != null)
                {
                    result += "c" + color.Id + ":\"" + color.ColorCode + "\",";
                }
            }

            result += "};";

            return result;
        }
        public void InitData()
        {
            // Load Style
            clb_style.Items.Clear();
            clb_style.Items.AddRange(getParent().controller.getStyleList().ToArray());

            //Load Color
            lstColor = getParent().controller.getColorList();

        }

        private void Btn_DeleteFrontImage_Click(object sender, EventArgs e)
        {
            if (pn_Image != null)
            {
                pn_Image.deleteFrontDesign();
                FrontDesignFileName = string.Empty;
            }
        }

        private void Btn_BrownFrontImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PNG files (*.png)|*.png";
                ofd.Title = "Vui lòng chọn file";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    FrontDesignFileName = ofd.FileName;
                    if(pn_Image != null)
                    {
                        pn_Image.setFrontDesign(FrontDesignFileName);
                    }

                }
            }
        }

        private void Clb_style_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index >= 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    pn_Image.AddStyle((Product_Style_Model)clb_style.Items[e.Index],lstColor);
                    if (FrontDesignFileName != string.Empty)
                    {
                        pn_Image.setFrontDesign(FrontDesignFileName, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                    }
                    if (BehideDesignFileName != string.Empty)
                    {
                        pn_Image.setBehideDesign(BehideDesignFileName, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    pn_Image.RemoveStyle((Product_Style_Model)clb_style.Items[e.Index]);
                }
            }
        }

        private void Pn_Image_OnReSizeChanged(object obj)
        {
            this.Height = 20 + btn_ShowCloseProduct.Height + btn_Addproduct.Height + pn_Info.Height + pn_Image.Height + 5;
            if(OnResizeChanged != null)
            {
                OnResizeChanged(this);
            }
        }

        private void Btn_ShowCloseProduct_Click(object sender, EventArgs e)
        {
            if (btn_ShowCloseProduct.Text == Resources.Cons.Test_btnShowThem) // Thuc hien chuc nang hide
            {
                this.Height = Resources.Cons.MinHeight;
                btn_ShowCloseProduct.Text = Resources.Cons.Test_btnHideThem;
            }
            else // thuc hien chuc nang show
            {
                this.Height = 20 + btn_ShowCloseProduct.Height + btn_Addproduct.Height + pn_Info.Height + pn_Image.Height + 5;
                btn_ShowCloseProduct.Text = Resources.Cons.Test_btnShowThem;
            }
            ((ProductView)this.Parent).EventSizeChanged();
        }
        private ProductView getParent()
        {
            return (ProductView)this.Parent;
        }
        private string CheckExistProductLink(string Str)
        {
            string result = string.Empty;
            if (Str != null)
            {
                result = Str;
                int stt = 0;
                bool rs = false;    
                while(rs == false)
                {
                    stt++;
                    if(!getParent().controller.CheckExistProductLink(ref rs, result))
                    {
                        result = string.Empty;
                        break;
                    }
                    if (!rs) result = Str + "-" + stt;
                }
            }

            return result;
        }
        private double getMinCostStyle()
        {
            double result = 999.99;
            foreach (Product_Style_Model item in clb_style.CheckedItems)
            {
                if(double.Parse(item.Cost) < result)
                {
                    result = double.Parse(item.Cost);
                } 
            }
            return result;
        }
        private double getMaxCostStyle()
        {
            double result = 0;
            foreach (Product_Style_Model item in clb_style.CheckedItems)
            {
                if (double.Parse(item.Cost) > result)
                {
                    result = double.Parse(item.Cost);
                }
            }
            return result;
        }
    }

}
