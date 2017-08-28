using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Country
    {
        public long country_id { set; get; }
        public string country_name { set; get; }
        public int country_region { set; get; }
        public double ship_cost { set; get; }
        public double ship_per_item_cost { set; get; }
    }
}
