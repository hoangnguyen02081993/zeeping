using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class ScrumBoardReviewDone : Form
    {
        private ScrumPanel pn_done;
        private string UserName;
        private List<TicketModel> lstTickets = null;
        public List<AdminUser_Model> lstUser;
        public List<StatusModel> lstStatus;
        public List<PriorityModel> lstPriority;
        public List<RelatedModel> lstRelated;

        private ScrumBoardReviewController controller = new ScrumBoardReviewController();
        public ScrumBoardReviewDone(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.Load += ScrumBoardReviewDone_Load;
        }

        private void ScrumBoardReviewDone_Load(object sender, EventArgs e)
        {
            Init();

            lstTickets = controller.getAllTicketDone();
            TicketModel fist = null;
            if(lstTickets != null)
            {
                foreach (TicketModel item in lstTickets)
                {
                    pn_done.AddTicket(item);
                    if(fist == null)
                    {
                        fist = item;
                    }
                }
                if (fist != null)
                {
                    Pn_done_OnPanelClick(fist);
                }
            }
        }

        private void Init()
        {
            pn_done = new ScrumPanel(false, UserName);
            this.pn_done.AutoScroll = true;
            this.pn_done.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_done.Location = new System.Drawing.Point(3, 16);
            this.pn_done.Name = "pn_done";
            this.pn_done.Size = new System.Drawing.Size(234, 483);
            this.pn_done.TabIndex = 0;
            this.pn_done.OnPanelClick += Pn_done_OnPanelClick;
            this.groupBox2.Controls.Add(pn_done);
        }

        private void Pn_done_OnPanelClick(TicketModel mode)
        {
            pn_done.setColor(mode);
            tb_creater.Text = mode.creater;
            tb_createdate.Text = mode.createdate.ToString("HH:mm:ss dd:MM:yyyy");
            tb_donedate.Text = mode.donedate.ToString("HH:mm:ss dd:MM:yyyy");
            tb_assginer.Text = mode.assigner;
            tb_status.Text = lstStatus.Where(s => s.id == mode.status).FirstOrDefault().name;
            tb_name.Text = mode.name;
            tb_priority.Text = lstPriority.Where(p => p.id == mode.priority).FirstOrDefault().name;
            tb_related.Text = lstRelated.Where(r => r.id == mode.related).FirstOrDefault().name;
            rtb_description.Text = mode.description;
            rtb_comment.Text = mode.reviewdescription;
        }
    }
}
