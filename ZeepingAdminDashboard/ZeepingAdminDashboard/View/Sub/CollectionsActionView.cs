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
    public partial class CollectionsActionView : Form
    {
        private CollectionsAction action = CollectionsAction.Detail;
        private CollectionsController controller = null;
        private Web_Collections_Model Obj = null;
        public CollectionsActionView(CollectionsAction Action, ref CollectionsController Controller, Web_Collections_Model obj)
        {
            InitializeComponent();

            action = Action;
            controller = Controller;
            Obj = obj;
            this.Load += CollectionsActionView_Load;
        }

        private void CollectionsActionView_Load(object sender, EventArgs e)
        {
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
                    rtb_title.ReadOnly = true;
                    rtb_content.ReadOnly = true;
                    btn_apply.Visible = false;
                    break;
            }
        }
        private void LoadData()
        {
            if (Obj != null)
            {
                rtb_title.Text = Obj.title;
                rtb_content.Text = Obj.content;
                tb_name.Text = Obj.name;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Web_Collections_Model obj = new Web_Collections_Model()
            {
                id = (Obj == null) ? -1 : Obj.id,
                name = tb_name.Text,
                title = rtb_title.Text,
                content = rtb_content.Text,
                isdraft = (Obj == null) ? false: Obj.isdraft
            };
            if(controller.Save(obj))
            {
                Obj = obj;
                Common.Functions.ShowMessgeInfo("Success");
                //TODO preview
            }
            else
            {
                Common.Functions.ShowMessgeInfo("Fail");
            }
        }

        private void btn_action_Click(object sender, EventArgs e)
        {
            Web_Collections_Model obj = new Web_Collections_Model()
            {
                id = (Obj == null) ? -1 : Obj.id,
                name = tb_name.Text,
                title = rtb_title.Text,
                content = rtb_content.Text,
                isdraft = true
            };
            if (controller.Save(obj))
            {
                Obj = obj;
                Common.Functions.ShowMessgeInfo("Success");
            }
            else
            {
                Common.Functions.ShowMessgeInfo("Fail");
            }
        }
    }
}
