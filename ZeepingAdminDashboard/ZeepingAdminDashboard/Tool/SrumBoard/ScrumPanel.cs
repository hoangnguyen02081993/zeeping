using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public class ScrumPanel : Panel
    {
        public event Resources.DelegateClass.PanelClick OnPanelClick;
        private bool _Istransverse;
        private string UserName;
        public ScrumPanel(bool Istransverse,string UserName) : base()
        {
            _Istransverse = Istransverse;
            this.UserName = UserName;
        }
        public void AddTicket(TicketModel model)
        {
            TicketView Tview = new TicketView(model, UserName);
            Tview.OnTicketViewClick += Tview_OnTicketViewClick;
            this.Controls.Add(Tview);
            OnAddorRemoveticket();
        }

        private void Tview_OnTicketViewClick(TicketModel mode)
        {
            if (OnPanelClick != null)
                OnPanelClick(mode);
        }

        public void AddTicket(TicketView view)
        {
            this.Controls.Add(view);
            OnAddorRemoveticket();
        }
        public TicketView RemoveTicket(TicketModel model)
        {
            foreach (TicketView item in this.Controls)
            {
                if(model.id == item._Model.id)
                {
                    this.Controls.Remove(item);
                    OnAddorRemoveticket();
                    return item;
                }
            }
            return null;
        }
        public TicketView RemoveTicket(TicketView view)
        {
            this.Controls.Remove((Control)view);
            OnAddorRemoveticket();
            return view;
        }
        public void setColor(TicketModel mode)
        {
            foreach (TicketView item in this.Controls)
            {
                if(item._Model.id == mode.id)
                {
                    item.BackColor = Color.FromArgb(236,135,14);
                }
                else
                {
                    item.BackColor = Color.FromArgb(250, 206, 156);
                }
            }
        }
        private void OnAddorRemoveticket()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (_Istransverse)
                {
                    this.Controls[i].Location = new System.Drawing.Point(i * 215 + i* 5, 0);
                }
                else
                {
                    this.Controls[i].Location = new System.Drawing.Point(0, i * 152 + i*5);
                }
            }
        }
        public PriorityModel getPriorityModelbyId(int id)
        {
            //Control control = this.Parent;
            //while(!(control is ScrumBoardView) || !(control is ScrumBoardReviewDone))
            //{
            //    control = control.Parent;
            //}
            PriorityModel model = new PriorityModel();
            Control control = GetParentForm();
            if(control is ScrumBoardView)
                model = ((ScrumBoardView)control).lstPriority.Where(p => p.id == id).FirstOrDefault();
            else if (control is ScrumBoardReviewDone)
                model = ((ScrumBoardReviewDone)control).lstPriority.Where(p => p.id == id).FirstOrDefault();

            return model;
        }
        public AdminUser_Model getAdminUser_ModelbyUser(string username)
        {
            //Control control = this.Parent;
            //while (!(control is ScrumBoardView))
            //{
            //    control = control.Parent;
            //}

            //AdminUser_Model model = ((ScrumBoardView)control).lstUser.Where(p => p.username == username).FirstOrDefault();

            //return model;


            AdminUser_Model model = new AdminUser_Model();
            Control control = GetParentForm();
            if (control is ScrumBoardView)
                model = ((ScrumBoardView)control).lstUser.Where(p => p.username == username).FirstOrDefault();
            else if (control is ScrumBoardReviewDone)
                model = ((ScrumBoardReviewDone)control).lstUser.Where(p => p.username == username).FirstOrDefault();


            return model;
        }
        public StatusModel getStatusModelbyId(int id)
        {
            //Control control = this.Parent;
            //while (!(control is ScrumBoardView))
            //{
            //    control = control.Parent;
            //}

            //StatusModel model = ((ScrumBoardView)control).lstStatus.Where(p => p.id == id).FirstOrDefault();

            //return model;

            StatusModel model = new StatusModel();
            Control control = GetParentForm();
            if (control is ScrumBoardView)
                model = ((ScrumBoardView)control).lstStatus.Where(p => p.id == id).FirstOrDefault();
            else if (control is ScrumBoardReviewDone)
                model = ((ScrumBoardReviewDone)control).lstStatus.Where(p => p.id == id).FirstOrDefault();


            return model;
        }
        public RelatedModel getRelatedModelbyId(int id)
        {
            //Control control = this.Parent;
            //while (!(control is ScrumBoardView))
            //{
            //    control = control.Parent;
            //}

            //RelatedModel model = ((ScrumBoardView)control).lstRelated.Where(p => p.id == id).FirstOrDefault();

            //return model;

            RelatedModel model = new RelatedModel();
            Control control = GetParentForm();
            if (control is ScrumBoardView)
                model = ((ScrumBoardView)control).lstRelated.Where(p => p.id == id).FirstOrDefault();
            else if (control is ScrumBoardReviewDone)
                model = ((ScrumBoardReviewDone)control).lstRelated.Where(p => p.id == id).FirstOrDefault();


            return model;
        }
        public ScrumBoardView getForm()
        {
            Control control = this.Parent;
            while (!(control is ScrumBoardView))
            {
                if (control.Parent == null)
                    return null;
                control = control.Parent;
            }

            return ((ScrumBoardView)control);

        }
        public List<AdminUser_Model> getAdminUser_Model()
        {
            //Control control = this.Parent;
            //while (!(control is ScrumBoardView))
            //{
            //    control = control.Parent;
            //}

            //return ((ScrumBoardView)control).lstUser;

            Control control = GetParentForm();
            if (control is ScrumBoardView)
                return ((ScrumBoardView)control).lstUser;
            else if (control is ScrumBoardReviewDone)
                return ((ScrumBoardReviewDone)control).lstUser;
            else return null;
        }

        private Control GetParentForm()
        {
            Control control = this.Parent;
            while (!(control is ScrumBoardView| control is ScrumBoardReviewDone) )
            {
                control = control.Parent;
            }
            return control;
        }
    }
}
