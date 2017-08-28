using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class CreateTicketView : Form
    {
        private string UserName;
        public TicketModel Ticket { private set; get; }
        public CreateTicketView(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.Load += CreateTicketView_Load;
        }

        private void CreateTicketView_Load(object sender, EventArgs e)
        {
            tb_creater.Text = UserName;
        }
        public void setPriority(List<PriorityModel> lst)
        {
            cb_priority.Items.AddRange(lst.ToArray());
            if(cb_priority.Items.Count > 0)
            {
                cb_priority.SelectedIndex = 0;
            }
        }
        public void setRelated(List<RelatedModel> lst)
        {
            cb_related.Items.AddRange(lst.ToArray());
            if (cb_priority.Items.Count > 0)
            {
                cb_related.SelectedIndex = 0;
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Ticket = new TicketModel()
            {
                name = tb_name.Text,
                priority = (int)((PriorityModel)cb_priority.SelectedItem).id,
                related = (int)((RelatedModel)cb_related.SelectedItem).id,
                creater = UserName,
                assigner = "Unknown",
                status = 1,
                description = rtb_description.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
