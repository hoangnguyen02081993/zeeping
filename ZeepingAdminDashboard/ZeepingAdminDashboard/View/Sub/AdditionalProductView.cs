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
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class AdditionalProductView : Form
    {
        public string ImageFileName = string.Empty;
        public bool IsFeaturedProduct = false;
        public string ExtensionImage = string.Empty;
        private Product_Controller _controller = null;
        public string AllCatogary = string.Empty;
        public string HashTagString = string.Empty;
        public bool IsFront = true;
        public AdditionalProductView(Product_Controller controller)
        {
            InitializeComponent();
            _controller = controller;
            this.Load += AdditionalProductView_Load;
        }

        private void AdditionalProductView_Load(object sender, EventArgs e)
        {
            List<Web_Menu_Model> lst = null;
            if(!_controller.getAllCatogary(ref lst))
            {
                Functions.ShowMessgeError("Không có kết nối DB");
                this.Close();
            }
            chlb_catogary.Items.AddRange(lst.ToArray());
            chlb_catogary.DisplayMember = "name";
            cb_vision.SelectedIndex = 0;
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                ofd.Title = "Vui lòng chọn file";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pc_featuredimage.Image = Image.FromFile(ofd.FileName);
                    ExtensionImage = Functions.GetExtension(ofd.FileName);
                    ImageFileName = ofd.FileName;
                }
            }
        }

        private void chb_isfeaturedimage_CheckedChanged(object sender, EventArgs e)
        {
            IsFeaturedProduct = chb_isfeaturedimage.Checked;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(IsFeaturedProduct.Equals(string.Empty))
            {
                Functions.ShowMessgeError("Bạn chưa chọn Featured Image");
                return;
            }
            if(chlb_catogary.SelectedItems.Count == 0)
            {
                Functions.ShowMessgeError("Chưa chọn Catogary");
                return;
            }
            string hashtagstring = string.Empty;
            if(!tb_hashtag.Equals(string.Empty))
            {
                hashtagstring = Functions.getHashTagString(tb_hashtag.Text);
                if(!Functions.getValidHashTagString(hashtagstring))
                {
                    hashtagstring = string.Empty;
                    Functions.ShowMessgeError("HashTag không đúng định dạng");
                    return;
                }
            }
            foreach (Web_Menu_Model item in chlb_catogary.SelectedItems)
            {
                AllCatogary += item.id + ",";
            }
            AllCatogary = AllCatogary.Substring(0, AllCatogary.Length - 1);
            HashTagString = hashtagstring;
            DialogResult = DialogResult.OK;
        }

        private void cb_vision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_vision.SelectedIndex == 0)
            {
                IsFront = true;
            }
            else
            {
                IsFront = false;
            }
        }
    }
}
