using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.View
{
    public class HuongdanView : Panel
    {
        public HuongdanView(Size sizeParten) :base()
        {
            this.Location = new Point(20, 20);
            this.Size = new Size(sizeParten.Width - 40, sizeParten.Height - 40);


            Label lb_huongdan = new Label();
            lb_huongdan.Location = new Point(0, 0);
            lb_huongdan.Text = "Hướng dẫn sử dụng: ";
            lb_huongdan.Font = new Font("Consolas", 18);
            lb_huongdan.Size = new Size(300, 30);
            this.Controls.Add(lb_huongdan);

            RichTextBox rtb = new RichTextBox();
            rtb.Location = new Point(0, lb_huongdan.Location.Y + lb_huongdan.Height + 10);
            rtb.Size = new Size(this.Width, this.Height - lb_huongdan.Location.Y + lb_huongdan.Height - 10);
            rtb.Text = "(Viết hướng dẫn sử dụng vào đây)";
            rtb.ReadOnly = true;
            this.Controls.Add(rtb);
        }
    }
}
