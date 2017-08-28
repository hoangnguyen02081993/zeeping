using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZeepingAdminDashboard.Resources.EnumClass;

namespace ZeepingAdminDashboard.Model
{
    public class AdminUser_Model
    {
        public string username { set; get; }
        public string password { set; get; }
        public PermissionUser permission { set; get; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public bool Issupper { set; get; }
    }
}
