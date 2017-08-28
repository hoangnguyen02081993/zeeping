using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Web_Menu_Model
    {
        public long id { set; get; }
        public int stt { set; get; }
        public short floor { set; get; }
        public string childof { set; get; }
        public string name { set; get; }
        public string link { set; get; }
        public bool isPage { set; get; }
    }
}
