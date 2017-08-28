using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public partial class TicketView : UserControl
    {
        public event Resources.DelegateClass.TicketViewClick OnTicketViewClick;
        public TicketModel _Model { private set; get; }
        private string UserName;
        public TicketView(TicketModel model,string UserName)
        {
            InitializeComponent();
            _Model = model;
            this.UserName = UserName;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = Color.FromArgb(250,206,156);
            this.Load += TicketView_Load;
        }

        private void TicketView_Load(object sender, EventArgs e)
        {
            rtb_ticketname.Text = _Model.name;
            lb_perority.Text =  _Model.priority + " - " + getParent().getPriorityModelbyId(_Model.priority).name;
            lb_relatied.Text =  getParent().getRelatedModelbyId(_Model.related).name;
            lb_assginer.Text =  _Model.assigner;
            lb_creater.Text =  _Model.creater;

            if(UserName == _Model.assigner && !getParent().getAdminUser_ModelbyUser(UserName).Issupper)
            {
                btn_assign.Visible = false;
            }


            setFormbyStatus(_Model.status);
        }
        private ScrumPanel getParent()
        {
            return (ScrumPanel)this.Parent;
        }
        private void setFormbyStatus(int status)
        {
            if(status == 5)
            {
                btn_assign.Visible = false;
                btn_pre.Visible = false;
                btn_pend.Visible = false;
                btn_next.Visible = false;
                return;
            }
            if(_Model.assigner != UserName)
            {
                btn_pre.Visible = false;
                btn_pend.Visible = false;
                if (getParent().getAdminUser_ModelbyUser(UserName).Issupper && status == 3)
                {
                    btn_next.Visible = true;
                    btn_next.Text = "> Done";
                }
                else
                {
                    btn_next.Visible = false;
                }
                return;
            }
            if (status == 1)
            {
                btn_pre.Visible = false;
                btn_next.Text = "> progress";
                btn_pend.Visible = false;
                btn_next.Visible = true;
            }
            else if(status == 2)
            {
                btn_pre.Text = "To do <";
                btn_pend.Text = "Pending";
                btn_next.Text = "> Review";
                btn_pre.Visible = true;
                btn_pend.Visible = true;
                btn_next.Visible = true;
            }
            else if(status == 3)
            {
                btn_pend.Visible = false;
                btn_pre.Visible = true;
                btn_pre.Text = "Progress <";
                if(getParent().getAdminUser_ModelbyUser(UserName).Issupper)
                {
                    btn_next.Visible = true;
                    btn_next.Text = "> Done";
                }
                else
                {
                    btn_next.Visible = false;
                }

            }
            else if(status == 4)
            {
                btn_pre.Visible = false;
                btn_pend.Visible = false;
                btn_next.Visible = true;
                btn_next.Text = "> Progress";
            }
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            using (AssginView view = new AssginView())
            {
                if(getParent().getAdminUser_ModelbyUser(UserName).Issupper)
                {
                    view.setUserList(getParent().getAdminUser_Model());
                }
                else
                {
                    view.setUserList(UserName);
                }
                if(view.ShowDialog() == DialogResult.OK)
                {
                    string assginer = _Model.assigner;
                    _Model.assigner = view.UserName;

                    if(getParent().getForm().AssginTicket(_Model))
                    {
                        Functions.ShowMessgeInfo("Assgin ticket success");
                        lb_assginer.Text = _Model.assigner;
                        setFormbyStatus(_Model.status);
                    }
                    else
                    {
                        Functions.ShowMessgeError("Assgin ticket failed");
                        _Model.assigner = assginer;
                    }
                }
            }
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            if(_Model.status == 2)
            {
                int status = 2;
                _Model.status = 1;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
            else if(_Model.status == 3)
            {
                int status = 3;
                _Model.status = 2;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
        }

        private void btn_pend_Click(object sender, EventArgs e)
        {
            if(_Model.status == 2)
            {
                int status = 2;
                _Model.status = 4;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if(view.ShowDialog() == DialogResult.OK)
                    {
                        if(view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (_Model.status == 1)
            {
                int status = 1;
                _Model.status = 2;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
            else if (_Model.status == 2)
            {
                int status = 2;
                _Model.status = 3;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
            else if (_Model.status == 3)
            {
                int status = 3;
                _Model.status = 5;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatusDone(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    //setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
            else if (_Model.status == 4)
            {
                int status = 4;
                _Model.status = 2;
                string recomment = _Model.reviewdescription;
                using (ColectComment view = new ColectComment())
                {
                    if (view.ShowDialog() == DialogResult.OK)
                    {
                        if (view.Comment != string.Empty)
                        {
                            if (recomment != string.Empty)
                            {
                                _Model.reviewdescription += "\r\n" + UserName + " : " + view.Comment + "\r\n";
                            }
                            else
                            {
                                _Model.reviewdescription = UserName + " : " + view.Comment + "\r\n";
                            }
                        }
                    }
                }
                if (getParent().getForm().setStatus(this, _Model))
                {
                    Functions.ShowMessgeInfo("Move Ticket Success");
                    setFormbyStatus(_Model.status);
                }
                else
                {
                    Functions.ShowMessgeError("Move ticket Failed");
                    _Model.status = status;
                    _Model.reviewdescription = recomment;
                }
            }
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DetailView view = new DetailView())
            {
                view.setForm(lb_creater.Text, lb_assginer.Text, getParent().getStatusModelbyId(_Model.status).name, lb_perority.Text, lb_relatied.Text,_Model.name, _Model.description, _Model.reviewdescription);
                view.ShowDialog();
            }
        }

        private void TicketView_Click(object sender, EventArgs e)
        {
            if (OnTicketViewClick != null)
                OnTicketViewClick(this._Model);
        }
    }
}
