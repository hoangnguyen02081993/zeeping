using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Database;

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public class LoginLogController
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public List<Login_trackingModel> getAllLoginTracking()
        {
            List<Login_trackingModel> result = new List<Login_trackingModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_admin_tracking_login`", "*", "");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Login_trackingModel item = new Login_trackingModel()
                        {
                            id = (long)dt.Rows[i]["id"],
                            username = (string)dt.Rows[i]["username"],
                            logindate = (DateTime)dt.Rows[i]["logindate"],
                            logoutdate = (DateTime)dt.Rows[i]["logoutdate"]
                        };
                        result.Add(item);
                    }
                    result = result.OrderBy(r => r.logindate).ToList();
                }
            }
            catch (Exception ex)
            {
                result = null;
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
    }
}
