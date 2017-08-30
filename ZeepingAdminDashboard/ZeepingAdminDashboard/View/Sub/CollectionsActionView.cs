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
using ZeepingAdminDashboard.Model.Local;
using static ZeepingAdminDashboard.Resources.EnumClass;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class CollectionsActionView : Form
    {
        private CollectionsAction action = CollectionsAction.Detail;
        private CollectionsController controller = null;
        private Web_Collections_Model Obj = null;

        private ImageAttachModel FeatureImage = null;

        public CollectionsActionView(CollectionsAction Action, ref CollectionsController Controller, Web_Collections_Model obj)
        {
            InitializeComponent();

            action = Action;
            controller = Controller;
            if(obj != null)
            {
                Obj = new Web_Collections_Model()
                {
                    id = obj.id,
                    content = obj.content,
                    createdDate = obj.createdDate,
                    description = obj.description,
                    featureimage = obj.featureimage,
                    name = obj.name,
                    relatedmenu = obj.relatedmenu,
                    title = obj.title,
                    isdraft = obj.isdraft
                };
            }
            this.Load += CollectionsActionView_Load;
        }

        private void CollectionsActionView_Load(object sender, EventArgs e)
        {
            List<Web_Menu_Model> result = null;
            if (controller.getAllCatogary(ref result))
            {
                chlb_catogary.Items.AddRange(result.ToArray());
            }
            chlb_catogary.DisplayMember = "name";


            switch (action)
            {
                case CollectionsAction.Add:
                    btn_action.Text = "Add";
                    break;
                case CollectionsAction.Update:
                    btn_action.Text = "Update";
                    tb_name.ReadOnly = true;
                    LoadData();
                    break;
                case CollectionsAction.Detail:
                    btn_action.Text = "Close";
                    LoadData();
                    tb_name.ReadOnly = true;
                    rtb_description.ReadOnly = true;
                    rtb_content.ReadOnly = true;
                    btn_apply.Visible = false;
                    btn_browser.Enabled = false;
                    chlb_catogary.Enabled = false;
                    tb_title.ReadOnly = true;
                    pn_imageattach.IsEnable = false;
                    break;
            }
            pn_imageattach.OnImageAttachDeleted += Pn_imageattach_OnImageAttachDeleted;
        }

        private void Pn_imageattach_OnImageAttachDeleted(ImageAttachModel view)
        {
            rtb_content.Text = rtb_content.Text.Replace("[~" + view.id.ToString() + "]", string.Empty);
        }

        private void LoadData()
        {
            if (Obj != null)
            {
                LoadImageAttach();

                Obj.content = Obj.content.Replace("<br/>", "\n");
                Obj.description = Obj.description.Replace("<br/>", "\n");

                rtb_description.Text = Obj.description;
                rtb_content.Text = Obj.content;
                tb_name.Text = Obj.name;
                tb_title.Text = Obj.title;
                FeatureImage = new ImageAttachModel()
                {
                    IsLocal = false,
                    Link = Obj.featureimage
                };
                pic_feature.Load(AppConfig.WebUrl + "/" + Common.AppConfig.PathImageCollections + "/" + Obj.id + "/" + Obj.featureimage);

                for (int i = 0; i < chlb_catogary.Items.Count; i++)
                {
                    if((chlb_catogary.Items[i] as Web_Menu_Model).id == Obj.relatedmenu)
                    {
                        chlb_catogary.SetItemChecked(i, true);
                    }
                }
            }
        }
        private void LoadImageAttach()
        {
            List<string> lstImage = FTPAction.getListFiles(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword, FTPAction.localSourceWeb + "/" + Common.AppConfig.PathImageCollections + "/" + Obj.id, string.Empty);
            foreach (var item in lstImage)
            {
                if (item == Obj.featureimage) continue;
                var ImageItem = new ImageAttachModel()
                {
                    IsLocal = false,
                    Link = AppConfig.WebUrl + "/" + Common.AppConfig.PathImageCollections + "/" + Obj.id + "/" + item
                };
                pn_imageattach.AddImage(ImageItem);
                if(action != Resources.EnumClass.CollectionsAction.Detail)
                    Obj.content = Obj.content.Replace(ImageItem.Link, "[~" + ImageItem.id.ToString() + "]");
            }
        }
        private bool SendImage(ref Web_Collections_Model obj, ref List<ImageAttachModel> lstImage,ref List<ImageAttachModel> DeleteImageList)
        {
            bool result = true;

            if (FeatureImage.IsLocal)
            {
                if (!FTPAction.sendFile(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword,
                          FTPAction.localSourceWeb + "/" + Common.AppConfig.PathImageCollections + "/" + obj.id, obj.name + Common.Functions.GetExtension(FeatureImage.Link),
                          Common.Functions.GetPathFileName(FeatureImage.Link), Common.Functions.GetSafeFileName(FeatureImage.Link)))
                {
                    return false;
                }
                FeatureImage.IsLocal = false;
                FeatureImage.Link = AppConfig.WebUrl + "/" + Common.AppConfig.PathImageCollections + "/" + obj.id + "/" + obj.name + Common.Functions.GetExtension(FeatureImage.Link);
            }
            obj.featureimage = obj.name + Common.Functions.GetExtension(FeatureImage.Link);

            foreach (var item in lstImage)
            {
                if (item.IsLocal)
                {
                    if (!FTPAction.sendFile(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword,
                                          FTPAction.localSourceWeb + "/" + Common.AppConfig.PathImageCollections + "/" + obj.id, Common.Functions.GetSafeFileName(item.Link),
                                          Common.Functions.GetPathFileName(item.Link), Common.Functions.GetSafeFileName(item.Link)))
                    {
                        return false;
                    }
                    item.IsLocal = false;
                    item.Link = AppConfig.WebUrl + "/" + Common.AppConfig.PathImageCollections + "/" + obj.id + "/" + Common.Functions.GetSafeFileName(item.Link);
                }
                obj.content = obj.content.Replace("[~" + item.id.ToString() + "]", item.Link);
            }
            foreach (var item in DeleteImageList)
            {
                if (!item.IsLocal)
                {
                    FTPAction.deleteFile(AppConfig.FTPHost, AppConfig.FTPUser, AppConfig.FTPPassword,
                                          FTPAction.localSourceWeb + "/" + Common.AppConfig.PathImageCollections + "/" + obj.id, Common.Functions.GetSafeFileName(item.Link));
                }
            }
            return result;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if(tb_name.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"name\"");
                return;
            }
            if (tb_title.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"title\"");
                return;
            }
            if (rtb_description.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"description\"");
                return;
            }
            if (rtb_content.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"content\"");
                return;
            }
            if(FeatureImage.Equals(null))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"Feature Image\"");
                return;
            }
            if(chlb_catogary.CheckedItems.Count == 0)
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"catogary\"");
                return;
            }

            string CollectionLink = string.Empty;
            if (Obj == null)
            {
                CollectionLink = CheckExistCollectionLink(Common.Functions.getWebNameValid(tb_name.Text));
                if (CollectionLink.Equals(string.Empty))
                {
                    Common.Functions.ShowMessgeError("Không có kết nối đến máy chủ");
                    return;
                }
            }
            else
            {
                CollectionLink = Obj.name;
            }



            var lstImage = pn_imageattach.GetImageAttachList();
            var DeletedImageAttachList = pn_imageattach.DeletedImageAttachList;

            Web_Collections_Model obj = new Web_Collections_Model()
            {
                id = (Obj == null) ? -1 : Obj.id,
                name = CollectionLink,
                title = tb_title.Text,
                content = rtb_content.Text,
                featureimage = FeatureImage.Link,
                description = rtb_description.Text,
                relatedmenu = (int)(chlb_catogary.CheckedItems[0] as Web_Menu_Model).id,
                isdraft = (Obj == null) ? true: Obj.isdraft
            };

            long id = -1;
            if(controller.Save(obj, ref id))
            {
                obj.id = id;
                if (SendImage(ref obj, ref lstImage, ref DeletedImageAttachList))
                {
                    controller.Update(obj);
                    pn_imageattach.ClearDeletedImageAttachList();
                    //pn_imageattach.StoreImageAttachList(lstImage);
                    Obj = obj;
                    Common.Functions.ShowMessgeInfo("Success");
                    //TODO preview
                    System.Diagnostics.Process.Start(AppConfig.WebUrl + "/other/collectionPreview.php?id=" + obj.id);
                }
                else
                {
                    controller.Delete(obj);
                    Common.Functions.ShowMessgeInfo("Fail");
                }
            }
            else
            {
                Common.Functions.ShowMessgeInfo("Fail");
            }
        }

        private void btn_action_Click(object sender, EventArgs e)
        {

            if (tb_name.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"name\"");
                return;
            }
            if (tb_title.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"title\"");
                return;
            }
            if (rtb_description.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"description\"");
                return;
            }
            if (rtb_content.Equals(string.Empty))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"content\"");
                return;
            }
            if (FeatureImage.Equals(null))
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"Feature Image\"");
                return;
            }
            if (chlb_catogary.CheckedItems.Count == 0)
            {
                Common.Functions.ShowMessgeError("Chưa nhập thông tin \"catogary\"");
                return;
            }

            string CollectionLink = string.Empty;
            if (Obj == null)
            {
                CollectionLink = CheckExistCollectionLink(Common.Functions.getWebNameValid(tb_name.Text));
                if (CollectionLink.Equals(string.Empty))
                {
                    Common.Functions.ShowMessgeError("Không có kết nối đến máy chủ");
                    return;
                }
            }
            else
            {
                CollectionLink = Obj.name;
            }

            var lstImage = pn_imageattach.GetImageAttachList();
            var DeletedImageAttachList = pn_imageattach.DeletedImageAttachList;

            Web_Collections_Model obj = new Web_Collections_Model()
            {
                id = (Obj == null) ? -1 : Obj.id,
                name = CollectionLink,
                title = tb_title.Text,
                content = rtb_content.Text,
                featureimage = FeatureImage.Link,
                description = rtb_description.Text,
                relatedmenu = (int)(chlb_catogary.CheckedItems[0] as Web_Menu_Model).id,
                isdraft = false
            };
            long id = -1;
            if (controller.Save(obj, ref id))
            {
                obj.id = id;
                if (SendImage(ref obj, ref lstImage, ref DeletedImageAttachList))
                {
                    controller.Update(obj);
                    pn_imageattach.ClearDeletedImageAttachList();
                    //pn_imageattach.StoreImageAttachList(lstImage);
                    Obj = obj;
                    Common.Functions.ShowMessgeInfo("Success");
                }
                else
                {
                    controller.Delete(obj);
                    Common.Functions.ShowMessgeInfo("Fail");
                }
            }
            else
            {
                Common.Functions.ShowMessgeInfo("Fail");
            }
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FeatureImage = new ImageAttachModel()
                    {
                        IsLocal = true,
                        Link = ofd.FileName
                    };
                    pic_feature.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private string CheckExistCollectionLink(string Str)
        {
            string result = string.Empty;
            if (Str != null)
            {
                result = Str;
                int stt = 0;
                bool rs = false;
                while (rs == false)
                {
                    stt++;
                    if (!controller.CheckExistCollectionLink(ref rs, result))
                    {
                        result = string.Empty;
                        break;
                    }
                    if(!rs) result = Str + "-" + stt;
                }
            }

            return result;
        }
    }
}
