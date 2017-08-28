using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public class TicketModel
    {
        public long id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string reviewdescription { set; get; }
        public int priority { set; get; }
        public int related { set; get; }
        public string assigner { set; get; }
        public string creater { set; get; }
        public int status { set; get; }
        public DateTime createdate { set; get; }
        public DateTime donedate { set; get; }
    }
}
