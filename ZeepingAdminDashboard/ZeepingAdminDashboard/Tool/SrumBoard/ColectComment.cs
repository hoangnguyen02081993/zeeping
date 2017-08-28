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
    public partial class ColectComment : Form
    {
        public string Comment { private set; get; }
        public ColectComment()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Comment = rtb_comment.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
