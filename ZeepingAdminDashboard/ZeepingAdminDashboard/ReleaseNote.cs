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
    public partial class ReleaseNote : Form
    {
        private string releasenoteString = string.Empty;
        public ReleaseNote(string ReleaseNoteString)
        {
            InitializeComponent();
            releasenoteString = ReleaseNoteString;
            this.Load += ReleaseNote_Load;
        }

        private void ReleaseNote_Load(object sender, EventArgs e)
        {
            rtb_releasenote.Text = releasenoteString;
        }
    }
}
