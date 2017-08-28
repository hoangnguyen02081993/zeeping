using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public class Login_trackingModel
    {
        public long id { set; get; }
        public string username { set; get; }
        public DateTime logindate { set; get; }
        public DateTime logoutdate { set; get; }
    }
}
