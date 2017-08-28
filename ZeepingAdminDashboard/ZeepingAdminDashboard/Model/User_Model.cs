using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Model
{
    public class User_Model
    {        
        public string username {  set; get; }
        public string password {  set; get; }
        public double promosion_money {  set; get; }
        public string email {  set; get; }
        public string fullname {  set; get; }
        public string street_address {  set; get; }
        public string apt_suite_other {  set; get; }
        public string city {  set; get; }
        public string postal_code {  set; get; }
        public int country_id {  set; get; }
        public string phone_number {  set; get; }
        public string province { set; get; }
        //public string choosen_payment_card {  set; get; }
        //public string payment_card_list {  set; get; }
        public bool isenable { set; get; }
    }
}
