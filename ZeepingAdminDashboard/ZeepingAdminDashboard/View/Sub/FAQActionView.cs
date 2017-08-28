using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;
using static ZeepingAdminDashboard.Resources.EnumClass;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class FAQActionView : Form
    {
        private FAQAction action = FAQAction.Detail;
        private FAQController controller = null;
        private Web_page_FAQ Obj = null;
        public FAQActionView(FAQAction Action,ref FAQController Controller, Web_page_FAQ obj)
        {
            InitializeComponent();
            action = Action;
            controller = Controller;
            Obj = obj;
            this.Load += FAQActionView_Load;
        }

        private void FAQActionView_Load(object sender, EventArgs e)
        {
            switch(action)
            {
                case FAQAction.Add:
                    btn_action.Text = "Add";
                    break;
                case FAQAction.Update:
                    btn_action.Text = "Update";
                    LoadData();
                    break;
                case FAQAction.Detail:
                    btn_action.Text = "Close";
                    LoadData();
                    rtb_answer.ReadOnly = true;
                    rtb_question.ReadOnly = true;
                    break;
            }
        }
        private void LoadData()
        {
            if(Obj != null)
            {
                rtb_question.Text = Obj.question;
                rtb_answer.Text = Obj.answer;
            }
        }
        private bool AddFAQ()
        {
            bool result = false;

            if(rtb_question.Text.Equals(string.Empty))
            {
                return false;
            }
            if(rtb_answer.Text.Equals(string.Empty))
            {
                return false;
            }

            result = controller.Add(new Web_page_FAQ() { question = rtb_question.Text, answer = rtb_answer.Text});

            return result;
        }
        private bool UpdateFAQ()
        {
            bool result = false;
            if (rtb_question.Text.Equals(string.Empty))
            {
                return false;
            }
            if (rtb_answer.Text.Equals(string.Empty))
            {
                return false;
            }
            result = controller.Update(new Web_page_FAQ() {id = Obj.id, question = rtb_question.Text, answer = rtb_answer.Text });

            return result;
        }

        private void btn_action_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case FAQAction.Add:
                    if(AddFAQ())
                    {
                        Common.Functions.ShowMessgeInfo("Add Success");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Common.Functions.ShowMessgeInfo("Add Fail");
                    }
                    break;
                case FAQAction.Update:
                    if(UpdateFAQ())
                    {
                        Common.Functions.ShowMessgeInfo("Update Success");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Common.Functions.ShowMessgeInfo("Update Fail");
                    }
                    break;
                case FAQAction.Detail:
                    this.Close();
                    break;
            }
        }
    }
}
