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
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class ChangeHashTagView : Form
    {
        private Product_Controller controller = null;
        private long msp;
        public string NewHashTag = string.Empty;
        public ChangeHashTagView(Product_Controller Controller, long MSP)
        {
            InitializeComponent();
            controller = Controller;
            msp = MSP;
            this.Load += ChangeHashTagView_Load;
        }

        private void ChangeHashTagView_Load(object sender, EventArgs e)
        {
            List<Product_Model> lstPros = null;
            if (controller.Searchproduct(ref lstPros, msp.ToString(), string.Empty))
            {
                if (lstPros.Count == 1)
                {
                    tb_hashtag.Text = lstPros[0].hashtag;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string hashtagstring = string.Empty;
            if (!tb_hashtag.Equals(string.Empty))
            {
                hashtagstring = Functions.getHashTagString(tb_hashtag.Text);
                if (!Functions.getValidHashTagString(hashtagstring))
                {
                    hashtagstring = string.Empty;
                    Functions.ShowMessgeError("HashTag không đúng định dạng");
                    return;
                }
                NewHashTag = hashtagstring;
                DialogResult = DialogResult.OK;
            }

        }
    }
}
