using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.View.Sub
{
    public class DesignView : Panel
    {
        public struct MoveControl
        {
            public bool IsMouseMovepanel1;
            public string namecontrol;
        };

        private MoveControl control;
        private Point Movelocation;
        private int Stype_Cursor;
        private const int max_DIV = 100;
        /*------------------main---------------------*/
        private int mainWidth;
        private int mainHeight = 0;
        public void setmainWidth(int Width)
        {
            mainWidth = Width;
        }
        public void setmainHeight(int Height)
        {
            mainHeight = Height;
        }

        Timer tm;
        public DesignView(Image background)
        {
            this.BackgroundImage = background;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Location = new Point(0, 0);
            this.Size = new Size(100, 100);

            Init();
        }
        public void Init()
        {
            this.Size = new Size(200, 200);
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.divMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.divMouseUp);
            this.MouseLeave += new System.EventHandler(this.divLeave);
            this.MouseMove += new MouseEventHandler(this.divMouseMove);
            this.Resize += new EventHandler(divresize);
            tm = new Timer();
            tm.Interval = 1;
            tm.Tick += new EventHandler(tm_tick);
            tm.Enabled = true;
        }
        private void divMouseDown(object sender, MouseEventArgs e)
        {
            control.IsMouseMovepanel1 = true;
            control.namecontrol = this.Name;
            Movelocation.X = Cursor.Position.X;
            Movelocation.Y = Cursor.Position.Y;

        }
        private void divLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        private void divMouseUp(object sender, MouseEventArgs e)
        {
            control.IsMouseMovepanel1 = false;
        }
        private void divMouseMove(object sender, MouseEventArgs e)
        {
            if (control.IsMouseMovepanel1 == false)
            {
                if (e.X < 10)
                {
                    if (e.Y < 10 && e.Y > 0)
                    {
                        Cursor = Cursors.SizeNWSE;
                        Stype_Cursor = 0;
                    }
                    else if (e.Y > 10 && e.Y < (this.Height - 10))
                    {
                        Cursor = Cursors.SizeWE;
                        Stype_Cursor = 1;
                    }
                    else if (e.Y > (this.Height - 10) && e.Y < this.Height)
                    {
                        Cursor = Cursors.SizeNESW;
                        Stype_Cursor = 2;
                    }
                }
                else if (e.X > 10 && e.X < (this.Width - 10))
                {
                    if (e.Y < 10 && e.Y > 0)
                    {
                        Cursor = Cursors.SizeNS;
                        Stype_Cursor = 3;
                    }
                    else if (e.Y > 10 && e.Y < (this.Height - 10))
                    {
                        Cursor = Cursors.SizeAll;
                        Stype_Cursor = 4;
                    }
                    else if (e.Y > (this.Height - 10) && e.Y < this.Height)
                    {
                        Cursor = Cursors.SizeNS;
                        Stype_Cursor = 5;
                    }
                }
                else if (e.X > (this.Width - 10) && e.X < this.Width)
                {
                    if (e.Y < 10 && e.Y > 0)
                    {
                        Cursor = Cursors.SizeNESW;
                        Stype_Cursor = 6;
                    }
                    else if (e.Y > 10 && e.Y < (this.Height - 10))
                    {
                        Cursor = Cursors.SizeWE;
                        Stype_Cursor = 7;
                    }
                    else if (e.Y > (this.Height - 10) && e.Y < this.Height)
                    {
                        Cursor = Cursors.SizeNWSE;
                        Stype_Cursor = 8;
                    }
                }
            }
        }
        private void divresize(object sender, EventArgs e)
        {
            try
            {
                if ((this.Size.Width * 100) / mainWidth > 100)
                {
                    this.Size = new Size(mainWidth, Height);
                }
                else if ((this.Size.Width * 100) / mainWidth < 5)
                {
                    this.Size = new Size(mainWidth / 20, Height);
                }
            }
            catch { }
            try
            {
                if ((this.Size.Height * 100) / mainHeight > 100)
                {
                    this.Size = new Size(Width, mainHeight);
                }
                else if ((this.Size.Height * 100) / mainHeight < 5)
                {
                    this.Size = new Size(Width, mainHeight / 20);
                }
            }
            catch { }
        }
        private void tm_tick(object sender, EventArgs e)
        {
            /*--------------------- Control DIV------------------------------*/
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            int dX = Movelocation.X - X;
            int dY = Movelocation.Y - Y;
            Movelocation.X = X;
            Movelocation.Y = Y;
            if ((control.IsMouseMovepanel1))
            {
                if (Cursor == Cursors.SizeAll)
                {
                    this.Location = new Point((this.Location.X - dX < 0) ? 0 :
                                                                          ((this.Location.X - dX + this.Size.Width > this.mainWidth) ? this.mainWidth - this.Size.Width :
                                                                                                                                           this.Location.X - dX),
                                              (this.Location.Y - dY < 0) ? 0 :
                                                                            ((this.Location.Y - dY + this.Size.Height > mainHeight) ? mainHeight - this.Size.Height : this.Location.Y - dY));
                }
                else if (Cursor == Cursors.SizeNWSE)
                {
                    this.Location = new Point((Stype_Cursor == 0) ? ((this.Location.X - dX < 0) ? 0 : this.Location.X - dX) :
                                                                     this.Location.X,
                                              (Stype_Cursor == 0) ? ((this.Location.Y - dY < 0) ? 0 : this.Location.Y - dY) :
                                                                     this.Location.Y);
                    this.Size = new Size((Stype_Cursor == 0) ? ((this.Location.X == 0) ? this.Size.Width : this.Size.Width + dX) :
                                                               ((this.Size.Width - dX + this.Location.X > this.mainWidth) ? this.Size.Width : this.Size.Width - dX),
                                         (Stype_Cursor == 0) ? ((this.Location.Y == 0) ? this.Size.Height : this.Size.Height + dY) :
                                                               (this.Size.Height - dY));

                }
                else if (Cursor == Cursors.SizeNS)
                {
                    this.Location = new Point(this.Location.X,
                                             (Stype_Cursor == 3) ? ((this.Location.Y - dY < 0) ? 0 : this.Location.Y - dY) :
                                                                    this.Location.Y);
                    this.Size = new Size(this.Size.Width,
                                        (Stype_Cursor == 3) ? ((this.Location.Y == 0) ? this.Height : this.Height + dY) :
                                                              (this.Height - dY));
                }
                else if (Cursor == Cursors.SizeNESW)
                {
                    this.Location = new Point((Stype_Cursor == 6) ? (this.Location.X) :
                                                                    ((this.Location.X - dX < 0) ? 0 : this.Location.X - dX),
                                              (Stype_Cursor == 6) ? ((this.Location.Y - dY < 0) ? 0 : this.Location.Y - dY) :
                                                                     this.Location.Y);
                    this.Size = new Size((Stype_Cursor == 6) ? ((this.Size.Width - dX + this.Location.X > this.mainWidth) ? this.mainWidth - this.Location.X : this.Size.Width - dX) :
                                                               ((this.Location.X == 0) ? this.Size.Width : this.Size.Width + dX),
                                         (Stype_Cursor == 6) ? ((this.Location.Y == 0) ? this.Size.Height : this.Size.Height + dY) :
                                                               (this.Size.Height - dY));
                }
                else if (Cursor == Cursors.SizeWE)
                {
                    this.Location = new Point((Stype_Cursor == 1) ? ((this.Location.X - dX < 0) ? 0 : this.Location.X - dX) :
                                                                     this.Location.X,
                                               this.Location.Y);
                    this.Size = new Size((Stype_Cursor == 1) ? ((this.Location.X == 0) ? this.Size.Width : this.Size.Width + dX) :
                                                               ((this.Size.Width - dX + this.Location.X > this.mainWidth) ? this.mainWidth - this.Location.X : this.Size.Width - dX),
                                          this.Size.Height);
                }
            }
        }
    }
}
