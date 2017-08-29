using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Resources
{
    public class EnumClass
    {
        public enum PermissionUser
        {
            Unknown = -1,
            Guest = 1,
            Administrator = 2,
            Addproducter = 3,
            OrderExer = 4,
            UserManager = 5
        };
        public enum Functions
        {
            Huongdansudung,
            Thanhtoan,
            Danhsachdonhang,
            Sanpham,
            Collections,
            User,
            HotroKhachhang,
            FAQ,
            Khac
        };
        public enum FAQAction
        {
            Add,
            Update,
            Detail
        };
        public enum CollectionsAction
        {
            Add,
            Update,
            Detail
        };
    }
}
