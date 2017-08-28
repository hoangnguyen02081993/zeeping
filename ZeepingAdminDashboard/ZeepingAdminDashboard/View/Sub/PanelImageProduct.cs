using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.ObjClass;
using ZeepingAdminDashboard.Resources;

namespace ZeepingAdminDashboard.View.Sub
{
    public class PanelImageProduct : Panel
    {
        public event Resources.DelegateClass.ResizeChanged OnReSizeChanged;
        private List<Product_Color_Model> lstColor;

        public PanelImageProduct(Size partenSize):base()
        {
            this.Size = new Size(partenSize.Width, 0);
            //this.BackColor = Color.Aquamarine;
        }
        public void AddStyle(Product_Style_Model Style, List<Product_Color_Model> lstColor)
        {
            ImageStyle item = new ImageStyle(this.Size);
            item.setLstColor(lstColor.Where(c => c.colorofstyle == Style.Id).ToList());
            item.SetStyle(Style);
            this.Controls.Add(item);
            CalculateSize();
            this.lstColor = lstColor;
        }
        public void RemoveStyle(Product_Style_Model Style)
        {
            foreach (Control item in this.Controls)
            {
                if(item is ImageStyle)
                {
                    ImageStyle rmItem = (ImageStyle)item;
                    if(rmItem.Style.Id == Style.Id)
                    {
                        this.Controls.Remove(rmItem);
                        rmItem.Dispose();
                        break;
                    }
                }
            }
            CalculateSize();
        }
        public void SetStyle(List<Product_Style_Model> lstStyle)
        {
            foreach (Control item in this.Controls)
            {
                item.Dispose();
            }

            foreach (Product_Style_Model item in lstStyle)
            {
                this.Controls.Clear();
                ImageStyle style = new ImageStyle(this.Size);
                style.SetStyle(item);
                this.Controls.Add(style);
            }

            CalculateSize();
        }
        public int StyleCount()
        {
            return Controls.Count;
        }
        public void setFrontDesign(string FileName)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle)
                {
                    ((ImageStyle)item).AddFrontDesign(FileName);
                }
            }
        }
        public void deleteFrontDesign()
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle)
                {
                    ((ImageStyle)item).RemoveFrontDesign();
                }
            }
        }
        public void setBehideDesign(string FileName)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle)
                {
                    ((ImageStyle)item).AddBehideDesign(FileName);
                }
            }
        }
        public void deleteBehideDesign()
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle)
                {
                    ((ImageStyle)item).RemoveBehideDesign();
                }
            }
        }
        public void setFrontDesign(string FileName, long StyleId)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle )
                {
                    if(((ImageStyle)item).Style.Id == StyleId)
                    {
                        ((ImageStyle)item).AddFrontDesign(FileName);
                        break;
                    }
                }
            }
        }
        public void setBehideDesign(string FileName, long StyleId)
        {
            foreach (Control item in this.Controls)
            {
                if (item is ImageStyle)
                {
                    if (((ImageStyle)item).Style.Id == StyleId)
                    {
                        ((ImageStyle)item).AddBehideDesign(FileName);
                        break;
                    }
                }
            }
        }
        public void setColor(Product_Color_Model color)
        {
            if (color != null)
            {
                this.BackColor = color.Colors;
            }
        }
        public string getStyleDesign()
        {
            string result = string.Empty;
            if (this.Controls.Count > 0)
            {
                result += "var product_pro = {";
                foreach (Control item in this.Controls)
                {
                    if (item is ImageStyle)
                    {
                        result += ((ImageStyle)item).getStyleDesign();
                    }
                }
                result += "}";
            }

            return result;
        }    
        public string getStyleList()
        {
            string result = string.Empty;
            if (this.Controls.Count > 0)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is ImageStyle)
                    {
                        result += ((ImageStyle)item).Style.Id + ",";
                    }
                }
                if(result != string.Empty)
                {
                    result = result.Substring(0, result.Length - 1);
                }
            }
            return result;
        }
        private void CalculateSize()
        {
            int mHeight = 0;
            foreach (Control item in this.Controls)
            {
                item.Location = new Point(0, mHeight);
                mHeight += item.Height;
            }
            this.Height = mHeight;
            if (OnReSizeChanged != null)
                OnReSizeChanged(this);
        }
        private void TearDownIamge()
        {
            if (Directory.Exists(Application.StartupPath + "/Image"))
            {
                foreach (var item in Directory.GetFiles(Application.StartupPath + "/Image"))
                {
                    File.Delete(item);
                }
                Directory.Delete(Application.StartupPath + "/Image");
            }
        }
        public string getColorList()
        {
            string result = string.Empty;

            foreach (ImageStyle item in this.Controls)
            {
                string[] ColorListItem = item.getColorList().Split(',');
                for (int i = 0; i < ColorListItem.Length; i++)
                {
                    if(result.IndexOf("," + ColorListItem[i] + "," ) >= 0)
                    {
                        continue;
                    }
                    else if(result.IndexOf("," + ColorListItem[i]) >= 0)
                    {
                        if(result.IndexOf("," + ColorListItem[i]) + ColorListItem[i].Length + 1 == result.Length)
                        {
                            continue;
                        }
                    }
                    else if(result.IndexOf(ColorListItem[i] + ",") == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result += ColorListItem[i] + ",";
                    }
                }
            }
            if (result != string.Empty)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
    }
    public class ImageStyle : Panel
    {
        private bool IsBehide = false;

        private string FileName = string.Empty;
        private LablewithConsolasfont lb_Name;
        private Panel ColorPanel = null;
        private PictureBox Stylepic = null;
        private DesignView AddFrontpic = null;
        private DesignView AddBehidepic = null;

        private Image FrontImage = null;
        private Image BehideImage = null;

        private CustomCheckListBox clb_color;
        private LablewithConsolasfont lb_ColorList;
        private ComboBox cb_Color_Selected;

        private Button btn_FronImage = null;
        private Button btn_BehideImage = null;

        public Product_Style_Model Style { private set; get; }
        public ImageStyle(Size ParentSize):base()
        {
            this.Size = new Size(ParentSize.Width, 630);

            ColorPanel = new Panel();
            ColorPanel.Location = new Point(0, 0);
            ColorPanel.Size = new Size(530, 630);
            this.Controls.Add(ColorPanel);

            Stylepic = new PictureBox();
            Stylepic.Location = new Point(0, 0);
            Stylepic.Size = new Size(530, 630);
            ColorPanel.Controls.Add(Stylepic);

            lb_Name = new LablewithConsolasfont();
            lb_Name.BackColor = Color.White;
            lb_Name.Location = new Point(540, 20);
            lb_Name.Size = new Size(100, 20);
            this.Controls.Add(lb_Name);

            lb_ColorList = new LablewithConsolasfont();
            lb_ColorList.Location = new Point(lb_Name.Location.X, lb_Name.Location.Y + lb_Name.Size.Height + 10);
            lb_ColorList.Size = new Size(100, 20);
            lb_ColorList.Text = "Color List: ";
            this.Controls.Add(lb_ColorList);

            clb_color = new CustomCheckListBox();
            clb_color.Location = new Point(lb_ColorList.Location.X, lb_ColorList.Location.Y + lb_ColorList.Size.Height);
            clb_color.DisplayMember = "Name";
            clb_color.ItemCheck += Clb_color_ItemCheck;
            clb_color.Size = new Size(150, 400);
            clb_color.CheckOnClick = true;
            this.Controls.Add(clb_color);

            cb_Color_Selected = new ComboBox();
            cb_Color_Selected.Location = new Point(clb_color.Location.X, clb_color.Location.Y + clb_color.Size.Height);
            cb_Color_Selected.Size = new Size(150, 40);
            cb_Color_Selected.DisplayMember = "Name";
            cb_Color_Selected.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Color_Selected.SelectedIndexChanged += Cb_Color_Selected_SelectedIndexChanged;
            Product_Color_Model DefaultItem = new Product_Color_Model()
            {
                Id = -1,
                Name = "(Default)",
                Colors = Color.Black
            };
            cb_Color_Selected.Items.Add(DefaultItem);
            cb_Color_Selected.SelectedIndex = 0;
            this.Controls.Add(cb_Color_Selected);

            btn_FronImage = new Button();
            btn_FronImage.Location = new Point(cb_Color_Selected.Location.X, cb_Color_Selected.Location.Y + cb_Color_Selected.Size.Height);
            btn_FronImage.Size = new Size(70, 40);
            btn_FronImage.Click += Btn_FronImage_Click;
            btn_FronImage.Text = "Trước";
            
            this.Controls.Add(btn_FronImage);

            btn_BehideImage = new Button();
            btn_BehideImage.Location = new Point(btn_FronImage.Location.X + btn_FronImage.Width + 10, btn_FronImage.Location.Y);
            btn_BehideImage.Size = new Size(70, 40);
            btn_BehideImage.Text = "Sau";
            btn_BehideImage.Click += Btn_BehideImage_Click;
            this.Controls.Add(btn_BehideImage);
        }

        private void Btn_BehideImage_Click(object sender, EventArgs e)
        {
            if (!IsBehide)
            {
                Stylepic.Image = BehideImage;
                if (AddFrontpic != null)
                {
                    AddFrontpic.Visible = false;
                }
                if (AddBehidepic != null)
                {
                    AddBehidepic.Visible = true;
                }
                IsBehide = true;
            }
        }

        private void Btn_FronImage_Click(object sender, EventArgs e)
        {
            if (IsBehide)
            {
                Stylepic.Image = FrontImage;
                if (AddFrontpic != null)
                {
                    AddFrontpic.Visible = true;
                }
                if (AddBehidepic != null)
                {
                    AddBehidepic.Visible = false;
                }
                IsBehide = false;
            }
        }

        public void SetStyle(Product_Style_Model Style)
        {
            this.Style = Style;
            lb_Name.Text = "Style: " + Style.Name;

            FrontImage = getBitmapById(Style.Id, false);
            BehideImage = getBitmapById(Style.Id, true);

            Stylepic.Image = FrontImage;
        }
        public void setLstColor(List<Product_Color_Model> lstColor)
        {
            clb_color.Items.AddRange(lstColor.ToArray());
        }
        public void AddFrontDesign(string FileName)
        {
            if (File.Exists(FileName))
            {
                if (AddFrontpic == null)
                {
                    AddFrontpic = new DesignView(Image.FromFile(FileName));
                    AddFrontpic.Location = new Point(0, 0);
                    AddFrontpic.Size = new Size(50, 50);
                    AddFrontpic.BackgroundImageLayout = ImageLayout.Stretch;
                    AddFrontpic.setmainHeight(this.Height);
                    AddFrontpic.setmainWidth(this.Width);
                    Stylepic.Controls.Add(AddFrontpic);
                    AddFrontpic.BackgroundImage = Image.FromFile(FileName);
                    if(IsBehide)
                    {
                        AddFrontpic.Visible = false;
                    }
                }
                else
                {
                    AddFrontpic.BackgroundImage = Image.FromFile(FileName);
                }
            }
            else
            {
                //TODO
            }
        }
        public void AddBehideDesign(string FileName)
        {
            if (File.Exists(FileName) && Style.ishavebehide)
            {
                if (AddBehidepic == null)
                {
                    AddBehidepic = new DesignView(Image.FromFile(FileName));
                    AddBehidepic.Location = new Point(0, 0);
                    AddBehidepic.Size = new Size(50, 50);
                    AddBehidepic.BackgroundImageLayout = ImageLayout.Stretch;
                    AddBehidepic.setmainHeight(this.Height);
                    AddBehidepic.setmainWidth(this.Width);
                    Stylepic.Controls.Add(AddBehidepic);
                    AddBehidepic.BackgroundImage = Image.FromFile(FileName);
                    if (!IsBehide)
                    {
                        AddBehidepic.Visible = false;
                    }
                }
                else
                {
                    AddBehidepic.BackgroundImage = Image.FromFile(FileName);
                }
            }
            else
            {
                //TODO
            }
        }
        public void RemoveFrontDesign()
        {
            if(AddFrontpic != null)
            {
                this.Controls.Remove(AddFrontpic);
                AddFrontpic.Dispose();
                AddFrontpic = null;
            }
        }
        public void RemoveBehideDesign()
        {
            if (AddBehidepic != null)
            {
                this.Controls.Remove(AddBehidepic);
                AddBehidepic.Dispose();
                AddBehidepic = null;
            }
        }
        public string getStyleDesign()
        {
            string StyleDesignString = string.Empty;
            StyleDesignString += "s" + Style.Id + " :{";
            StyleDesignString += "cl :\"" + getColorList() + "\", ";
            StyleDesignString += "t :\"" + ((AddFrontpic == null) ? "0!0@0!0" : AddFrontpic.Location.X + "!" + AddFrontpic.Location.Y + "@" + AddFrontpic.Width + "!" + AddFrontpic.Height) + "\", ";
            StyleDesignString += "s :\"" + ((AddBehidepic == null) ? "0!0@0!0" : AddBehidepic.Location.X + "!" + AddBehidepic.Location.Y + "@" + AddBehidepic.Width + "!" + AddBehidepic.Height) + "\", ";
            StyleDesignString += "},";
            return StyleDesignString;
        }
        public string getColorList()
        {
            string result = string.Empty;

            foreach (Product_Color_Model item in cb_Color_Selected.Items)
            {
                if (item.Id != -1)
                {
                    result += item.Id + ",";
                }
            }
            if (result != string.Empty)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }
        private Bitmap getBitmapById(long id,bool IsBehide)
        {

            Bitmap result = new Bitmap(Cons.ImageGenarateWidth, Cons.ImageGenarateHeight);

            if(Directory.Exists(Application.StartupPath + "/ImageModel"))
            {
                if (!IsBehide)
                {
                    foreach (string item in Directory.GetFiles(Application.StartupPath + "/ImageModel"))
                    {
                        string SafeFileName = Functions.GetSafeFileName(item);
                        if (SafeFileName.Contains("s" + id))
                        {
                            result = new Bitmap(item);
                            FileName = item;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (string item in Directory.GetFiles(Application.StartupPath + "/ImageModel"))
                    {
                        string SafeFileName = Functions.GetSafeFileName(item);
                        if (SafeFileName.Contains("sh" + id))
                        {
                            result = new Bitmap(item);
                            FileName = item;
                            break;
                        }
                    }
                }
            }

            return result;
        }
        private void Clb_color_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index >= 0 && cb_Color_Selected != null)
            {
                Product_Color_Model color = (Product_Color_Model)clb_color.Items[e.Index];
                if (e.NewValue == CheckState.Checked)
                {
                    cb_Color_Selected.Items.Add(color);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    foreach (Product_Color_Model item in cb_Color_Selected.Items)
                    {
                        if (item.Id == color.Id)
                        {
                            cb_Color_Selected.Items.Remove(item);
                            break;
                        }
                    }
                }
                if (cb_Color_Selected.SelectedIndex == -1)
                    cb_Color_Selected.SelectedIndex = 0;
            }
        }
        private void Cb_Color_Selected_SelectedIndexChanged(object sender, EventArgs e)
        {
                ColorPanel.BackColor = ((Product_Color_Model)cb_Color_Selected.SelectedItem).Colors;
        }
        private void listView1_Refresh()
        {
            
        }
    }
}
