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
    public partial class ChangeCatogarys : Form
    {
        private Product_Controller controller = null;
        private long msp;
        public string NewCatogarys = string.Empty;
        public ChangeCatogarys(Product_Controller Controller, long MSP)
        {
            InitializeComponent();
            controller = Controller;
            msp = MSP;
            this.Load += ChangeCatogarys_Load;
        }

        private void ChangeCatogarys_Load(object sender, EventArgs e)
        {
            chlb_catogary.DisplayMember = "name";
            List<Web_Menu_Model> lstCatogary = null;
            if(controller.getAllCatogary(ref lstCatogary))
            {
                chlb_catogary.Items.AddRange(lstCatogary.ToArray());
            }

            List<Product_Model> lstPros = null;
            if(controller.Searchproduct(ref lstPros, msp.ToString(), string.Empty))
            {
                if(lstPros.Count == 1)
                {
                    string[] lstcatogary = lstPros[0].Catogarys.Split(',');
                    foreach (string item in lstcatogary)
                    {
                        for (int i = 0; i < chlb_catogary.Items.Count; i++)
                        {
                            if(long.Parse(item) == ((Web_Menu_Model)chlb_catogary.Items[i]).id)
                            {
                                chlb_catogary.SetItemChecked(i, true);
                            }
                            else
                            {
                                chlb_catogary.SetItemChecked(i, false);
                            }
                        }
                    }
                }
            }
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            NewCatogarys = string.Empty;
            foreach (Web_Menu_Model item in chlb_catogary.CheckedItems)
            {
                NewCatogarys += item.id + ",";
            }
            if(!NewCatogarys.Equals(string.Empty))
            {
                NewCatogarys = NewCatogarys.Substring(0, NewCatogarys.Length - 1);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
