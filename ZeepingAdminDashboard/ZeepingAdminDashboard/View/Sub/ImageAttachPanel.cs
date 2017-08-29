using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class ImageAttachPanel : UserControl
    {
        public ImageAttachPanel()
        {
            InitializeComponent();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in ofd.FileNames)
                    {
                        ImageAttachModelView view = new ImageAttachModelView();
                        view.ImageAttach = new Model.Local.ImageAttachModel()
                        {
                            IsLocal = true,
                            Link = item
                        };
                        pn_image.Controls.Add(view);
                    }
                    OnAddorRemoveImage();

                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            foreach (var item in pn_image.Controls)
            {
                if(item is ImageAttachModelView)
                {
                    if((item as ImageAttachModelView).IsChoose)
                    {
                        pn_image.Controls.Remove(item as Control);
                        OnAddorRemoveImage();
                        break;
                    }
                }
            }
        }

        private void OnAddorRemoveImage()
        {
            for (int i = 0; i < pn_image.Controls.Count; i++)
            {
                pn_image.Controls[i].Location = new System.Drawing.Point(3, 3 + i * 152 + i * 10);
            }
        }
    }
}
