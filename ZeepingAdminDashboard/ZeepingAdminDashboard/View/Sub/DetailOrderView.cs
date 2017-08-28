using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.View
{
    public partial class DetailOrderView : Form
    {
        private Order_Controller controller = null;
        private Order_Model order = null;
        private Product_Model product = null;
        private Product_Color_Model product_color = null;
        public DetailOrderView(ref Order_Controller Controller, Order_Model Order)
        {
            InitializeComponent();
            controller = Controller;
            order = Order;
            this.Load += DetailOrderView_Load;
        }


        private void DetailOrderView_Load(object sender, EventArgs e)
        {
            product = controller.getProductbyId(order.product_id);
            product_color = controller.getColorbyId(order.color_id);

            InitData();
        }
        private void InitData()
        {
            pn_color.BackColor = product_color.Colors;
            pn_style.BackgroundImage = Image.FromFile(Application.StartupPath + "/ImageModel/s" + order.style_id + ".png");
            if(!product.product_iamge_design.Split(',')[0].Equals("None"))
            {
                byte[] data = null;
                if (FTPAction.getFile(AppConfig.FTPHost,
                                      AppConfig.FTPUser,
                                      AppConfig.FTPPassword,
                                      FTPAction.localPathDesign,
                                      product.product_iamge_design.Split(',')[0],
                                      ref data))
                {
                    Image i;
                    if ((i = Functions.getImage(data)) != null)
                    {
                        pic_design.Image = i;
                        string style_desgn = Functions.getValueinJoin(product.style_design, "t");
                        if (style_desgn.Equals(string.Empty))
                        {
                            pic_design.Visible = false;
                        }
                        else
                        {
                            pic_design.Location = new Point(Int32.Parse(style_desgn.Split('@')[0].Split('!')[0]) / 2,
                                                            Int32.Parse(style_desgn.Split('@')[0].Split('!')[1]) / 2);
                            pic_design.Size = new Size(Int32.Parse(style_desgn.Split('@')[1].Split('!')[0]) / 2,
                                                            Int32.Parse(style_desgn.Split('@')[1].Split('!')[1]) / 2);
                        }
                    }
                    else
                    {
                        pic_design.Visible = false;
                    }
                }
                else
                {
                    pic_design.Visible = false;
                }
            }
            else
            {
                pic_design.Visible = false;
            }


            llb_product_link.Text = product.product_link;
            llb_product_link.LinkClicked += Llb_product_link_LinkClicked;
            lb_quantity.Text = "Số lượng: " + order.quantity;
            lb_user.Text = "User: " + order.username;
            lb_createdate.Text = "Thời gian: " + order.createDate.ToString("yyyy-MM-dd HH:mm:ss");
            lb_email.Text = "Email: " + order.email;
            lb_firstname.Text = "Họ: " + order.firstname;
            lb_lastname.Text = "Tên: " + order.lastname;
            lb_streetaddress.Text = "địa chỉ: " + order.street_address;
            lb_optional.Text = "Địa chỉ (optional): " + order.apt_suite_other;
            lb_city.Text = "Thành phố: " + order.city;
            lb_postcode.Text = "Mã bưu chính: " + order.postal_code;
            lb_country.Text = "Quốc gia: " + ((controller.getCountrybyId(order.country_id) == null) ? string.Empty : controller.getCountrybyId(order.country_id).country_name);
            lb_phonenum.Text = "Số điện thoại: " + order.phone_number;
            lb_provine.Text = "Bang: " + order.province;
        }

        private void Llb_product_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            llb_product_link.LinkVisited = true;
            System.Diagnostics.Process.Start(llb_product_link.Text);
        }
    }
}
