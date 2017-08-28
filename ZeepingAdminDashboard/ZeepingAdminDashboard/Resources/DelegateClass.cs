using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepingAdminDashboard.Tool.SrumBoard;

namespace ZeepingAdminDashboard.Resources
{
    public class DelegateClass
    {
        public delegate void ResizeChanged(object obj);
        public delegate void IndexChanged(int Index);

        public delegate void PanelClick(TicketModel mode);
        public delegate void TicketViewClick(TicketModel mode);
    }
}
