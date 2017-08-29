using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Web_Collections_Model
    {
        public long id { set; get; }
        public string name { set; get; }
        public string featureimage { set; get; }
        public string title { set; get; }
        public string description { set; get; }
        public string content { set; get; }
        public int relatedmenu { set; get; }
        public DateTime createdDate { set; get; }
        public bool isdraft { set; get; }
    }
}
