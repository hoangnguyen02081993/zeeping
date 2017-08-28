using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Product_Model
    {
        public long product_id { set; get; }
        public string product_name { set; get; }
        public string product_iamge_design { set; get; }
        public string product_title { set; get; }
        public string product_content { set; get; }
        public string product_link { set; get; }
        public string style_list { set; get; }
        public string color_list { set; get; }
        public string style_design { set; get; }
        public DateTime createdDate{ set; get; }
        public bool isFeaturedProduct{ set; get; }
        public string linkFeaturedImage{ set; get; }
        public string linkProduct { set; get; }
        public string Catogarys { set; get; }
        public string rangcost {set; get; }
        public string hashtag { set; get; }
    }
}
