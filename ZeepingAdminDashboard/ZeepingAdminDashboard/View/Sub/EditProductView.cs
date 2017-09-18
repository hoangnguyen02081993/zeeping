using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.Model.Local;
using ZeepingAdminDashboard.ObjClass;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class EditProductView : Form
    {
        public bool IsChange { private set; get; }

        private Product_Controller controller = null;
        public Product_Model product { private set; get; }


        private ImageAttachModel FrontDesign = null;
        private ImageAttachModel BehideDesign = null;

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
        #endregion

        private Button btn_BrownFrontImage;
        private Button btn_DeleteFrontImage;

        private Button btn_BrownBehideImage;
        private Button btn_DeleteBehideImage;

        private Sub.PanelImageProduct pn_Image;

        private List<Product_Color_Model> lstColor = null;

        public EditProductView(Product_Controller Controller, Product_Model Product)
        {
            InitializeComponent();
            controller = Controller;
            product = Product;
            this.Load += EditProductView_Load;
        }

        private void EditProductView_Load(object sender, EventArgs e)
        {
            Init();
            InitData();
        }

        private void Init()
        {
            #region Product Info
            pn_Info = new Panel();
            pn_Info.Location = new Point(20, btn_save.Location.Y + btn_save.Height + 5);
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
            tb_TenSP.ReadOnly = true;
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
            this.Controls.Add(pn_Image);

            #endregion
        }

        private void Btn_DeleteBehideImage_Click(object sender, EventArgs e)
        {
            if (pn_Image != null)
            {
                pn_Image.deleteBehideDesign();
                BehideDesign = new ImageAttachModel()
                {
                    IsLocal = true,
                    Link = string.Empty
                };
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
                    BehideDesign = new ImageAttachModel()
                    {
                        IsLocal = true,
                        bm = null,
                        Link = ofd.FileName
                    };
                    if (pn_Image != null)
                    {
                        pn_Image.setBehideDesign(BehideDesign.Link);
                    }

                }
            }
        }

        private void Btn_DeleteFrontImage_Click(object sender, EventArgs e)
        {
            if (pn_Image != null)
            {
                pn_Image.deleteFrontDesign();
                FrontDesign = new ImageAttachModel()
                {
                    IsLocal = true,
                    Link = string.Empty
                };
            }
        }

        private void Btn_BrownFrontImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PNG files (*.png)|*.png";
                ofd.Title = "Vui lòng chọn file";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FrontDesign = new ImageAttachModel()
                    {
                        IsLocal = true,
                        bm = null,
                        Link = ofd.FileName
                    };
                    if (pn_Image != null)
                    {
                        pn_Image.setFrontDesign(FrontDesign.Link);
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
                    pn_Image.AddStyle((Product_Style_Model)clb_style.Items[e.Index], lstColor);
                    if (FrontDesign != null)
                    {
                        if(!FrontDesign.IsLocal)
                        {
                            pn_Image.setFrontDesign(FrontDesign.bm, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                        }
                        else
                        {
                            if(FrontDesign.Link != string.Empty)
                            {
                                pn_Image.setFrontDesign(FrontDesign.Link, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                            }
                        }
                    }
                    if (BehideDesign != null)
                    {
                        if (!BehideDesign.IsLocal)
                        {
                            pn_Image.setBehideDesign(BehideDesign.bm, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                        }
                        else
                        {
                            if (BehideDesign.Link != string.Empty)
                            {
                                pn_Image.setBehideDesign(BehideDesign.Link, ((Product_Style_Model)clb_style.Items[e.Index]).Id);
                            }
                        }
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    pn_Image.RemoveStyle((Product_Style_Model)clb_style.Items[e.Index]);
                }
            }
        }

        public void InitData()
        {
            // Load Style
            clb_style.Items.Clear();
            clb_style.Items.AddRange(controller.getStyleList().ToArray());

            //Load Color
            lstColor = controller.getColorList();

            tb_TenSP.Text = product.product_name;
            tb_LinkSP_direct.Text = product.product_link;
            tb_title.Text = product.product_title;
            rtb_content.Text = product.product_content.Replace("<br/>","\n");

            //Fill Image design
            if (!product.product_image_design.Split(',')[0].Equals("None"))
            {
                byte[] data = null;
                if (FTPAction.getFile(AppConfig.FTPHost,
                                      AppConfig.FTPUser,
                                      AppConfig.FTPPassword,
                                      FTPAction.localPathDesign,
                                      product.product_image_design.Split(',')[0],
                                      ref data))
                {
                    Image i;
                    if ((i = Functions.getImage(data)) != null)
                    {

                        FrontDesign = new ImageAttachModel()
                        {
                            IsLocal = false,
                            bm = (Bitmap)i,
                            Link = string.Empty
                        };
                    }
                    else
                    {
                        FrontDesign = new ImageAttachModel()
                        {
                            IsLocal = true,
                            Link = string.Empty
                        };
                    }
                }
                else
                {
                    FrontDesign = new ImageAttachModel()
                    {
                        IsLocal = true,
                        Link = string.Empty
                    };
                }
            }
            else
            {
                FrontDesign = new ImageAttachModel()
                {
                    IsLocal = true,
                    Link = string.Empty
                };
            }
            if (!product.product_image_design.Split(',')[1].Equals("None"))
            {
                byte[] data = null;
                if (FTPAction.getFile(AppConfig.FTPHost,
                                      AppConfig.FTPUser,
                                      AppConfig.FTPPassword,
                                      FTPAction.localPathDesign,
                                      product.product_image_design.Split(',')[0],
                                      ref data))
                {
                    Image i;
                    if ((i = Functions.getImage(data)) != null)
                    {
                        BehideDesign = new ImageAttachModel()
                        {
                            IsLocal = false,
                            bm = (Bitmap)i,
                            Link = string.Empty
                        };
                    }
                    else
                    {
                        BehideDesign = new ImageAttachModel()
                        {
                            IsLocal = true,
                            Link = string.Empty
                        };
                    }
                }
                else
                {
                    BehideDesign = new ImageAttachModel()
                    {
                        IsLocal = true,
                        Link = string.Empty
                    };
                }
            }
            else
            {
                BehideDesign = new ImageAttachModel()
                {
                    IsLocal = true,
                    Link = string.Empty
                };
            }

            // Fill style and color
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            string json = "{" + product.style_design.Substring(19, product.style_design.Length - 21).Replace(", }","}") + "}";
            var obj = serializer.Deserialize<Dictionary<string, object>>(json);

            foreach (var kv in obj)
            {
                int style = Int32.Parse(kv.Key.Substring(1));
                for (int i = 0; i < clb_style.Items.Count; i++)
                {
                    if((clb_style.Items[i] as Product_Style_Model).Id == style)
                    {
                        clb_style.SetItemChecked(i, true);
                        break;
                    }
                }

                foreach (var item in kv.Value as Dictionary<string, object>)
                {
                    if (item.Key.Equals("cl"))
                    {
                        pn_Image.setChoosenColorListbyId(Functions.GetList(item.Value.ToString(), ','), style);
                    }
                    if (item.Key.Equals("t"))
                    {
                        pn_Image.setLocationandSizeFrontDesignbyId(new Point(Int32.Parse(item.Value.ToString().Split('@')[0].Split('!')[0]),
                                                                             Int32.Parse(item.Value.ToString().Split('@')[0].Split('!')[1])),
                                                                   new Size(Int32.Parse(item.Value.ToString().Split('@')[1].Split('!')[0]),
                                                                            Int32.Parse(item.Value.ToString().Split('@')[1].Split('!')[1])),
                                                                   style);
                    }
                    if (item.Key.Equals("s"))
                    {
                        pn_Image.setLocationandSizeBehindDesignbyId(new Point(Int32.Parse(item.Value.ToString().Split('@')[0].Split('!')[0]),
                                                                             Int32.Parse(item.Value.ToString().Split('@')[0].Split('!')[1])),
                                                                   new Size(Int32.Parse(item.Value.ToString().Split('@')[1].Split('!')[0]),
                                                                            Int32.Parse(item.Value.ToString().Split('@')[1].Split('!')[1])),
                                                                   style);
                    }
                }

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
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


            // Gui anh design lên thu muc
            if (FrontDesign.IsLocal && FrontDesign.Link != string.Empty)
            {
                if (!FTPAction.sendFile(AppConfig.FTPHost,
                                        AppConfig.FTPUser,
                                        AppConfig.FTPPassword,
                                        FTPAction.localPathDesign,
                                        Functions.GetSafeFileName(FrontDesign.Link).Replace(" ", ""),
                                        Functions.GetPathFileName(FrontDesign.Link),
                                        Functions.GetSafeFileName(FrontDesign.Link)))
                {
                    //TODO
                    Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình gửi ảnh design lên web");
                    return;
                }
                if(product.product_image_design.Split(',')[0] != Functions.GetSafeFileName(FrontDesign.Link) && product.product_image_design.Split(',')[0] != "None")
                {
                    FTPAction.deleteFile(AppConfig.FTPHost,
                                         AppConfig.FTPUser,
                                         AppConfig.FTPPassword,
                                         FTPAction.localPathDesign,
                                         product.product_image_design.Split(',')[0]);
                }
            }
            if (BehideDesign.Link != string.Empty && BehideDesign.IsLocal)
            {
                if (!FTPAction.sendFile(AppConfig.FTPHost,
                                        AppConfig.FTPUser,
                                        AppConfig.FTPPassword,
                                        FTPAction.localPathDesign,
                                        Functions.GetSafeFileName(BehideDesign.Link).Replace(" ", ""),
                                        Functions.GetPathFileName(BehideDesign.Link),
                                        Functions.GetSafeFileName(BehideDesign.Link)))
                {
                    //TODO
                    Functions.ShowMessgeError("Có lỗi xảy ra trong quá trình gửi ảnh design lên web");
                    return;
                }
                if (product.product_image_design.Split(',')[1] != Functions.GetSafeFileName(BehideDesign.Link) && product.product_image_design.Split(',')[1] != "None")
                {
                    FTPAction.deleteFile(AppConfig.FTPHost,
                                         AppConfig.FTPUser,
                                         AppConfig.FTPPassword,
                                         FTPAction.localPathDesign,
                                         product.product_image_design.Split(',')[1]);
                }
            }

            // Luu database
            string product_image_design = string.Empty;
            product_image_design += (!FrontDesign.IsLocal) ? product.product_image_design.Split(',')[0] : ((FrontDesign.Link == string.Empty) ? "None" : Functions.GetSafeFileName(FrontDesign.Link).Replace(" ", ""));
            product_image_design += ",";
            product_image_design += (!BehideDesign.IsLocal) ? product.product_image_design.Split(',')[1] : ((BehideDesign.Link == string.Empty) ? "None" : Functions.GetSafeFileName(BehideDesign.Link).Replace(" ", ""));

            Product_Model pd = new Product_Model()
            {
                product_id = product.product_id,
                product_image_design = product_image_design,
                product_link = tb_LinkSP_direct.Text.Replace("\'", "\\\'"),
                product_title = tb_title.Text.Replace("\'", "\\\'"),
                product_content = rtb_content.Text.Replace("\'", "\\\'").Replace("\n", "<br/>"),
                color_list = getColorList(),
                style_list = pn_Image.getStyleList(),
                style_design = pn_Image.getStyleDesign(),
                rangcost = "$" + getMinCostStyle() + " - $" + getMaxCostStyle()
            };

            if (controller.EditProduct(pd))
            {
                Functions.ShowMessgeInfo("Edit success");
                IsChange = true;

                product.product_image_design = pd.product_image_design;
                product.product_link = pd.product_link;
                product.product_title = tb_title.Text;
                product.product_content = rtb_content.Text;
                product.color_list = pd.color_list;
                product.style_list = pd.style_list;
                product.style_design = pd.style_design;
                product.rangcost = pd.rangcost;

                if (FrontDesign.IsLocal && product.product_image_design.Split(',')[0] != Functions.GetSafeFileName(FrontDesign.Link) && product.product_image_design.Split(',')[0] != "None")
                {
                    FTPAction.deleteFile(AppConfig.FTPHost,
                                         AppConfig.FTPUser,
                                         AppConfig.FTPPassword,
                                         FTPAction.localPathDesign,
                                         product.product_image_design.Split(',')[0]);
                }
                if (BehideDesign.IsLocal && product.product_image_design.Split(',')[1] != Functions.GetSafeFileName(BehideDesign.Link) && product.product_image_design.Split(',')[1] != "None")
                {
                    FTPAction.deleteFile(AppConfig.FTPHost,
                                         AppConfig.FTPUser,
                                         AppConfig.FTPPassword,
                                         FTPAction.localPathDesign,
                                         product.product_image_design.Split(',')[1]);
                }
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
        private double getMinCostStyle()
        {
            double result = 999.99;
            foreach (Product_Style_Model item in clb_style.CheckedItems)
            {
                if (double.Parse(item.Cost) < result)
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
