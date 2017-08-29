using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model.Local
{
    public class ImageAttachModel
    {
        public Guid id = Guid.NewGuid();
        public bool IsLocal { set; get; }
        public string Link { set; get; }
    }
}
