using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard
{
    public partial class ShowImage : Form
    {
        public ShowImage(string FileName,string Title)
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Text = Title;
            try
            {
                this.BackgroundImage = Image.FromFile(FileName);
            }
            catch { this.Close(); }
        }
    }
}
