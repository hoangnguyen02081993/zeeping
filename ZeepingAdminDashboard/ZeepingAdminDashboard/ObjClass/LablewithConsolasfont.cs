using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.ObjClass
{
    public class LablewithConsolasfont : Label
    {
        public LablewithConsolasfont():base()
        {            
            this.Font = new Font("Consolas", 8);
        }
    }
}
