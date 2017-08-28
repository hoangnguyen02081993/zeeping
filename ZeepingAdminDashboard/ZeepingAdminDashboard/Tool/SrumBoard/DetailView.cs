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
    public partial class DetailView : Form
    {
        public DetailView()
        {
            InitializeComponent();
        }
        public void setForm(string Creater,string Assigner,string status,string priority,string related,string nameticket, string description,string reviewdecription)
        {
            tb_creater.Text = Creater;
            tb_assginer.Text = Assigner;
            tb_status.Text = status;
            tb_priority.Text = priority;
            tb_related.Text = related;
            tb_name.Text = nameticket;
            rtb_description.Text = description;
            rtb_comment.Text = reviewdecription;
        }
    }
}
