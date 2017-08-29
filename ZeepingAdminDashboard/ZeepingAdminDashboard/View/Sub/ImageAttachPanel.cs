﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Model.Local;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class ImageAttachPanel : UserControl
    {
        private bool _IsEnable;
        public bool IsEnable
        {
            set
            {
                _IsEnable = value;
                btn_browser.Enabled = _IsEnable;
                btn_delete.Enabled = _IsEnable;
                foreach (ImageAttachModelView item in pn_image.Controls)
                {
                    item.IsEnable = value;
                }
            }
            get
            {
                return _IsEnable;
            }
        }
        public ImageAttachPanel()
        {
            InitializeComponent();
            IsEnable = true;
        }
        public void AddImage(ImageAttachModel imgM)
        {
            ImageAttachModelView view = new ImageAttachModelView();
            view.ImageAttach = new Model.Local.ImageAttachModel()
            {
                IsLocal = imgM.IsLocal,
                Link = imgM.Link,
            };
            view.OnImageAttachChoosed += View_OnImageAttachChoosed;
            view.IsEnable = IsEnable;
            pn_image.Controls.Add(view);
            OnAddorRemoveImage();
        }

        public void AddImage(List<ImageAttachModel> lstimgM)
        {
            foreach (var item in lstimgM)
            {
                ImageAttachModelView view = new ImageAttachModelView();
                view.ImageAttach = item;
                view.OnImageAttachChoosed += View_OnImageAttachChoosed;
                view.IsEnable = IsEnable;
                pn_image.Controls.Add(view);
            }
            OnAddorRemoveImage();
        }
        public List<ImageAttachModel> GetImageAttachList()
        {
            List<ImageAttachModel> result = new List<ImageAttachModel>();

            for (int i = 0; i < pn_image.Controls.Count; i++)
            {
                result.Add((pn_image.Controls[i] as ImageAttachModelView).ImageAttach);
            }

            return result;
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
                            Link = item,
                        };
                        view.OnImageAttachChoosed += View_OnImageAttachChoosed;
                        view.IsEnable = IsEnable;
                        pn_image.Controls.Add(view);
                    }
                    OnAddorRemoveImage();

                }
            }
        }

        private void View_OnImageAttachChoosed(ImageAttachModelView view, Guid id)
        {
            foreach (var item in pn_image.Controls)
            {
                if (item is ImageAttachModelView)
                {
                    if ((item as ImageAttachModelView).ImageAttach.id != id)
                    {
                        (item as ImageAttachModelView).IsChoose = false;
                    }
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
                        (item as Control).Dispose();
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
                pn_image.Controls[i].Location = new System.Drawing.Point(3 + i * 69 + i * 10, 3);
            }
        }
    }
}