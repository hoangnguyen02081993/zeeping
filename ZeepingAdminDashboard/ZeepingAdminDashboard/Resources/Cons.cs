using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.Resources
{
    public class Cons
    {
        public const int MinHeight = 40;
        public const int DeltaWidth = 20;
        public const int DeltaLableandTextBoxHieght = 5;
        public const string Test_btnHideXem = "Xem Products";
        public const string Test_btnShowXem = "Ẩn Products";
        public const string Test_btnHideThem = "Xem Add Products";
        public const string Test_btnShowThem = "Ẩn Add Products";

        public const string User_btnHideTrackingMail = "Xem Tracking Mail";
        public const string User_btnShowTrackingMail = "Ẩn Tracking Mail";
        public const string User_btnHideThem = "Xem Add User";
        public const string User_btnShowThem = "Ẩn Add User";
        public const string User_btnHideXem = "Xem List User";
        public const string User_btnShowXem = "Ẩn List User";

        public const int ImageGenarateWidth = 530;
        public const int ImageGenarateHeight = 630;

        public static string ReleaseNoteLink = Application.StartupPath + "/Release.note";
    }
}
