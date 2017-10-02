using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Controller;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.View.Sub
{
    public partial class ChangeDefaultVisionProductView : Form
    {
        private Product_Controller controller = null;
        private long msp;
        public bool IsFront { private set; get; }
        public ChangeDefaultVisionProductView(Product_Controller Controller, long MSP)
        {
            InitializeComponent();
            controller = Controller;
            msp = MSP;
        }

        private void ChangeDefaultVisionProductView_Load(object sender, EventArgs e)
        {
            cb_vision.SelectedIndex = 0;

            List<Product_Model> lstPros = null;
            if (controller.Searchproduct(ref lstPros, msp.ToString(), string.Empty))
            {
                if (lstPros.Count == 1)
                {
                    if(!lstPros[0].isFrontVision)
                    {
                        cb_vision.SelectedIndex = 1;
                    }
                }
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if(cb_vision.SelectedIndex == 0)
            {
                IsFront = true;
            }
            else
            {
                IsFront = false;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
