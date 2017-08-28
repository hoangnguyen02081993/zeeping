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

namespace ZeepingAdminDashboard.View
{
    public partial class ReplySupportForm : Form
    {
        private UserSupport_Model mData = null;
        private Support_Controller mController = null;

        private bool IsSetForm = false;

        public ReplySupportForm()
        {
            InitializeComponent();
        }
        public void setFrom(UserSupport_Model data ,Support_Controller controller)
        {
            IsSetForm = true;
            mData = data;
            mController = controller;
            setData();
        }
        private void setData()
        {
            tb_from.Text = AppConfig.UserGmailSupport;
            tb_to.Text = mData.mail;
            if(mData.isreplied)
            {
                tb_subject.Text = mData.repliedsubject;
                tb_subject.ReadOnly = true;

                rtb_content.Text = mData.repliedmessage;
                rtb_content.ReadOnly = true;

                btn_send.Visible = false;
            }
            else
            {
                tb_subject.Text = AppConfig.SubjectSupportForm;

                rtb_content.Text = string.Empty;
                rtb_content.Text += "Dear " + mData.name + ",\n\n";
                rtb_content.Text += "(Viết nội dung vào đây)";
                rtb_content.Text += "\n\n";
                rtb_content.Text += "Thanks & Best Regards,\nZeeping Support Team.\n\n";
                rtb_content.Text += "<img src=\"http://zeeping.com/image/common/logo.jpg\" style=\"width:200px;height:100px\" />";

                rtb_content.Select(rtb_content.Text.IndexOf("(Viết nội dung vào đây)"), "(Viết nội dung vào đây)".Length);
                rtb_content.Focus();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (IsSetForm)
            {
                UserSupport_Model item = new UserSupport_Model()
                {
                    id = mData.id,
                    mail = mData.mail,
                    message = mData.message,
                    name = mData.name,
                    phonenumber = mData.phonenumber,
                    isreplied = true,
                    repliedsubject = tb_subject.Text,
                    repliedmessage = rtb_content.Text
                };
                int result = mController.ReplySupportRequest(item);
                if (result == -1)
                {
                    Functions.ShowMessgeError("Lỗi không xác định");
                }
                else if (result == 0)
                {
                    Functions.ShowMessgeInfo("Thành công");
                    mData = item;
                    tb_subject.ReadOnly = true;
                    rtb_content.ReadOnly = true;
                    btn_send.Visible = false;
                }
                else if (result == 1)
                {
                    Functions.ShowMessgeError("Không có kết nối Database");
                }
                else if (result == 2)
                {
                    Functions.ShowMessgeError("Không thể send mail");
                }
            }
        }
    }
}
