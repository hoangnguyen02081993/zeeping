using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Product_Color_Model
    {
        public long Id { set; get; }
        public string Name { set; get; }
        public Color Colors { set; get; }
        public string ColorCode { set; get; }
        public long colorofstyle { set; get; }
    }
}
