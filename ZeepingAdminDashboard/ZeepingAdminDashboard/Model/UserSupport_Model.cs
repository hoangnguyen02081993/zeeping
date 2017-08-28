using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class UserSupport_Model
    {
        public long id { set; get; }
        public string name { set; get; }
        public string mail { set; get; }
        public string phonenumber { set; get; }
        public string message { set; get; }
        public string repliedsubject { set; get; }
        public string repliedmessage { set; get; }
        public bool isreplied { set; get; }
    }
}
