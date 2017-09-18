using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class TrackingMail_Model
    {
        public long id { set; get; }
        public string email { set; get; }
        public long product_id { set; get; }
        public long style_id { set; get; }
        public long color_id { set; get; }
        public DateTime date { set; get; }
    }
}
