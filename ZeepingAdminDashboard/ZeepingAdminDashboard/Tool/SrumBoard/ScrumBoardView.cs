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
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class ScrumBoardView : Form
    {
        private ScrumBoardController controller = new ScrumBoardController();
        public List<AdminUser_Model> lstUser;
        public List<StatusModel> lstStatus;
        public List<PriorityModel> lstPriority;
        public List<RelatedModel> lstRelated;
        public List<TicketModel> lstTickets;


        private ScrumPanel pn_todo;
        private ScrumPanel pn_pending;
        private ScrumPanel pn_progress;
        private ScrumPanel pn_review;


        private string UserName = string.Empty;
        public ScrumBoardView(string user)
        {
            InitializeComponent();
            UserName = user;
            this.Load += ScrumBoardView_Load;
        }

        private void ScrumBoardView_Load(object sender, EventArgs e)
        {
            Init();


            lstUser = controller.getAllUser();
            lstStatus = controller.getStatus();
            lstPriority = controller.getPrioritys();
            lstRelated = controller.getRelateds();
            lstTickets = controller.getAllTicketNotDone();
            controller.removeTicketbyDate(AppConfig.DateClearTicket);
            if(lstTickets != null)
                MoveTicketToBoard();

            try
            {
                if (lstUser.Where(u => u.username == UserName).FirstOrDefault().Issupper)
                {
                    btn_logintracking.Visible = true;
                }
            }
            catch { }
        }
        private void Init()
        {
            pn_pending = new ScrumPanel(true,UserName);
            this.pn_pending.AutoScroll = true;
            this.pn_pending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_pending.Location = new System.Drawing.Point(3, 16);
            this.pn_pending.Name = "pn_pending";
            this.pn_pending.Size = new System.Drawing.Size(878, 131);
            this.pn_pending.TabIndex = 0;
            this.groupBox3.Controls.Add(pn_pending);
            // 
            // pn_todo
            // 
            pn_todo = new ScrumPanel(false, UserName);
            this.pn_todo.AutoScroll = true;
            this.pn_todo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_todo.Location = new System.Drawing.Point(3, 16);
            this.pn_todo.Name = "pn_todo";
            this.pn_todo.Size = new System.Drawing.Size(234, 483);
            this.pn_todo.TabIndex = 0;
            this.groupBox2.Controls.Add(pn_todo);
            // 
            // pn_progress
            // 
            pn_progress = new ScrumPanel(false, UserName);
            this.pn_progress.AutoScroll = true;
            this.pn_progress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_progress.Location = new System.Drawing.Point(3, 16);
            this.pn_progress.Name = "pn_progress";
            this.pn_progress.Size = new System.Drawing.Size(234, 483);
            this.pn_progress.TabIndex = 0;
            this.groupBox4.Controls.Add(pn_progress);
            // 
            // pn_review
            // 
            pn_review = new ScrumPanel(false, UserName);
            this.pn_review.AutoScroll = true;
            this.pn_review.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_review.Location = new System.Drawing.Point(3, 16);
            this.pn_review.Name = "pn_review";
            this.pn_review.Size = new System.Drawing.Size(234, 483);
            this.pn_review.TabIndex = 0;
            this.groupBox5.Controls.Add(pn_review);
        }
        private void MoveTicketToBoard()
        {
            foreach (TicketModel item in lstTickets)
            {
                if(item.status == 1)
                {
                    pn_todo.AddTicket(item);
                }
                else if(item.status == 2)
                {
                    pn_progress.AddTicket(item);
                }
                else if(item.status == 3)
                {
                    pn_review.AddTicket(item);
                }
                else if(item.status == 4)
                {
                    pn_pending.AddTicket(item);
                }
            }
        }

        private void btn_createticket_Click(object sender, EventArgs e)
        {
            using (CreateTicketView view = new CreateTicketView(UserName))
            {
                view.setPriority(lstPriority);
                view.setRelated(lstRelated);
                if(view.ShowDialog() == DialogResult.OK)
                {
                    long id = controller.CreateTicket(view.Ticket);
                    if (id > 0)
                    {
                        Functions.ShowMessgeInfo("Create ticket success");
                        view.Ticket.id = id;
                        lstTickets.Add(view.Ticket);
                        pn_todo.AddTicket(view.Ticket);
                    }
                    else
                    {
                        Functions.ShowMessgeError("Create ticket failed");
                    }
                }                
            }
        }
        public bool AssginTicket(TicketModel item)
        {
            bool result = false;

            try
            {
                if (controller.AssginTicket(item))
                {
                    lstTickets.Where(t => t.id == item.id).First().assigner = item.assigner;
                    result = true;
                }
            }
            catch(Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public bool setStatus(TicketView sender, TicketModel item)
        {
            bool result = false;
            try
            {
                if (controller.setStatusTicket(item))
                {
                    int currentStatus = lstTickets.Where(t => t.id == item.id).First().status;
                    setTicket(sender, currentStatus, item.status);
                    lstTickets.Where(t => t.id == item.id).First().status = item.status;
                    lstTickets.Where(t => t.id == item.id).First().reviewdescription = item.reviewdescription;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public bool setStatusDone(TicketView sender, TicketModel item)
        {
            bool result = false;
            try
            {
                if (controller.setStatusTicket(item))
                {
                    foreach (TicketModel ticket in lstTickets)
                    {
                        if(ticket.id == item.id)
                        {
                            lstTickets.Remove(ticket);

                            pn_review.RemoveTicket(sender);

                            if (sender != null)
                            {
                                sender.Dispose();
                                sender = null;
                            }

                            break;
                        }
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        private void setTicket(TicketView sender,int currentstatus, int newstatus)
        {
            switch(currentstatus)
            {
                case 1:
                    pn_todo.RemoveTicket(sender);
                    break;
                case 2:
                    pn_progress.RemoveTicket(sender);
                    break;
                case 3:
                    pn_review.RemoveTicket(sender);
                    break;
                case 4:
                    pn_pending.RemoveTicket(sender);
                    break;
            }

            addTicket(sender, newstatus);
        }
        private void addTicket(TicketView sender , int newstatus)
        {
            switch (newstatus)
            {
                case 1:
                    pn_todo.AddTicket(sender);
                    break;
                case 2:
                    pn_progress.AddTicket(sender);
                    break;
                case 3:
                    pn_review.AddTicket(sender);
                    break;
                case 4:
                    pn_pending.AddTicket(sender);
                    break;
            }
        }

        private void btn_doneticket_Click(object sender, EventArgs e)
        {
            using (ScrumBoardReviewDone view = new ScrumBoardReviewDone(UserName))
            {
                view.lstPriority = lstPriority;
                view.lstRelated = lstRelated;
                view.lstStatus = lstStatus;
                view.lstUser = lstUser;
                view.ShowDialog();
            }
        }

        private void btn_logintracking_Click(object sender, EventArgs e)
        {
            using (LoginLogForm view = new LoginLogForm())
            {
                view.ShowDialog();
            }
        }
    }
}
