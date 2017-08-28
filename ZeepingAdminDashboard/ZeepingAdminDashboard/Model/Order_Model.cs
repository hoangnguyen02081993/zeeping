using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class Order_Model
    {
        public long order_id {  set; get; }
        public string guid {  set; get; }
        public long product_id {  set; get; }
        public long style_id {  set; get; }
        public long color_id {  set; get; }
        public long size_id {  set; get; }
        public int quantity {  set; get; }
        public string username {  set; get; }
        public bool ischeckoutcompleted { set; get; }
        public DateTime createDate { set; get; }
        public short isOrderCompleted { set; get; }
        public string email { set; get; }
        public string firstname { set; get; }
        public string lastname { set; get; }
        public string street_address { set; get; }
        public string apt_suite_other { set; get; }
        public string city { set; get; }
        public string postal_code { set; get; }
        public int country_id { set; get; }
        public string phone_number { set; get; }
        public string province { set; get; }
    }
    public class Order_Status_Model
    {
        public short id { set; get; }
        public string name { set; get; }
    }
}
