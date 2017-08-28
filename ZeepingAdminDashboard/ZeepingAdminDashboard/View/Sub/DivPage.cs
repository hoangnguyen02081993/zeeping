using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using static ZeepingAdminDashboard.Resources.DelegateClass;

namespace ZeepingAdminDashboard.View.Sub
{
    public class DivPage : Panel
    {
        bool IsHaveEnter = false;

        private Button btn_FirstPage;
        private Button btn_PrevPage;
        private Button btn_NextPage;
        private Button btn_LastPage;
        private TextBox tb_CurrentPage;
        private Label lb_MaxPage;

        public int CurrentPage { private set; get; }
        public int MaxRow { private set; get; }
        public int ObjCount { private set; get; }
        private int _MaxPage;
        public int MaxPage {
            private set {
                _MaxPage = value;
                lb_MaxPage.Text = "/" + value;
             }
            get
            {
                return _MaxPage;
            }
        }

        public event IndexChanged OnIndexChanged;
        public DivPage(Point location):base()
        {
            this.Location = location;
            this.Size = new Size(201, 30);

            btn_FirstPage = new Button();
            btn_FirstPage.Location = new Point(0, 0);
            btn_FirstPage.Size = new Size(30, 30);
            btn_FirstPage.Text = "<<";
            btn_FirstPage.Click += Btn_FirstPage_Click;
            this.Controls.Add(btn_FirstPage);

            btn_PrevPage = new Button();
            btn_PrevPage.Location = new Point(btn_FirstPage.Location.X + btn_FirstPage.Width + 2, 0);
            btn_PrevPage.Size = new Size(30, 30);
            btn_PrevPage.Text = "<";
            btn_PrevPage.Click += Btn_PrevPage_Click;
            this.Controls.Add(btn_PrevPage);

            tb_CurrentPage = new TextBox();
            tb_CurrentPage.Location = new Point(btn_PrevPage.Location.X + btn_PrevPage.Width + 2, 0);
            tb_CurrentPage.Size = new Size(30, 30);
            tb_CurrentPage.Font = new Font("consolas", 14);
            tb_CurrentPage.KeyDown += Tb_CurrentPage_KeyDown;
            this.Controls.Add(tb_CurrentPage);

            lb_MaxPage = new Label();
            lb_MaxPage.Location = new Point(tb_CurrentPage.Location.X + tb_CurrentPage.Width + 2, 5);
            lb_MaxPage.Size = new Size(40, 30);
            lb_MaxPage.Text = "/x";
            lb_MaxPage.Font = new Font("consolas", 14);
            this.Controls.Add(lb_MaxPage);

            btn_NextPage = new Button();
            btn_NextPage.Location = new Point(lb_MaxPage.Location.X + lb_MaxPage.Width + 2, 0);
            btn_NextPage.Size = new Size(30, 30);
            btn_NextPage.Text = ">";
            btn_NextPage.Click += Btn_NextPage_Click;
            this.Controls.Add(btn_NextPage);

            btn_LastPage = new Button();
            btn_LastPage.Location = new Point(btn_NextPage.Location.X + btn_NextPage.Width + 2, 0);
            btn_LastPage.Size = new Size(30, 30);
            btn_LastPage.Text = ">>";
            btn_LastPage.Click += Btn_LastPage_Click;
            this.Controls.Add(btn_LastPage);
        }

        private void Tb_CurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                IsHaveEnter = true;
                int result = 0;
                if (int.TryParse(tb_CurrentPage.Text, out result))
                {
                    if (!(result > 0 && result <= MaxPage))
                    {
                        Functions.ShowMessgeError("Current page không đúng chuẩn");
                        tb_CurrentPage.Text = CurrentPage.ToString();
                    }
                    else
                    {
                        CurrentPage = result;
                        if (OnIndexChanged != null)
                            OnIndexChanged((CurrentPage - 1) * MaxRow);
                    }
                }
                else
                {
                    Functions.ShowMessgeError("Current page không đúng chuẩn");
                    tb_CurrentPage.Text = CurrentPage.ToString();
                }
                tb_CurrentPage.Text = tb_CurrentPage.Text.Substring(0, tb_CurrentPage.Text.Length);
            }
        }
        private void Btn_LastPage_Click(object sender, EventArgs e)
        {
            if (MaxPage > 0 && CurrentPage < MaxPage)
            {
                CurrentPage = MaxPage;
                tb_CurrentPage.Text = CurrentPage.ToString();
                if (OnIndexChanged != null)
                    OnIndexChanged((CurrentPage - 1) * MaxRow);
            }
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            if (MaxPage > 0 && CurrentPage < MaxPage)
            {
                CurrentPage += 1;
                tb_CurrentPage.Text = CurrentPage.ToString();
                if (OnIndexChanged != null)
                    OnIndexChanged((CurrentPage - 1) * MaxRow);
            }
        }

        private void Btn_PrevPage_Click(object sender, EventArgs e)
        {
            if (MaxPage > 0 && CurrentPage > 1)
            {
                CurrentPage -= 1;
                tb_CurrentPage.Text = CurrentPage.ToString();
                if (OnIndexChanged != null)
                    OnIndexChanged((CurrentPage - 1) * MaxRow);
            }
        }

        private void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            if(MaxPage > 0)
            {
                CurrentPage = 1;
                tb_CurrentPage.Text = CurrentPage.ToString();
                if (OnIndexChanged != null)
                    OnIndexChanged((CurrentPage - 1) * MaxRow);
            }
        }
        public bool setObjCount(int count, int maxrow)
        {
            if (count <= 0) return false;
            if (maxrow <= 0) return false;
            ObjCount = count;
            MaxRow = maxrow;
            MaxPage = (ObjCount / maxrow) + ((ObjCount % maxrow == 0) ? 0 : 1);
            CurrentPage = 1;
            tb_CurrentPage.Text = CurrentPage.ToString();
            if (OnIndexChanged != null)
                OnIndexChanged((CurrentPage - 1) * MaxRow);
            return true;
        }
        public bool setMaxcount(int maxrow)
        {
            if (maxrow <= 0) return false;
            MaxRow = maxrow;
            return true;
        }
    }
}
