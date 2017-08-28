using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Database;

namespace ZeepingAdminDashboard.Controller
{
    public class Main_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool ChangePass(string username,string pass)
        {
            bool result = false;
            try
            {
                if(DBHandler.updateDataBase(ref conn, "`order_admin_user`", "`password` = '" + pass + "'", "`username` = '" + username + "'"))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public long createLogin(string username)
        {
            long result = -1;

            try
            {
                if (DBHandler.insertDataBase(ref conn,
                                            "`order_admin_tracking_login`",
                                            "(`username`)",
                                            "('" + username + "')"))
                {
                    using (DataTable dt = DBHandler.selectDataBase(ref conn, "`order_admin_tracking_login`", " `id`", "`username` = '" + username + "'", "order by `id` desc LIMIT 1"))
                    {
                        if (dt.Rows.Count == 1)
                        {
                            result = (long)dt.Rows[0]["id"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public bool endLogin(long id)
        {
            bool result = false;
            try
            {
                if (DBHandler.updateDataBase(ref conn, "`order_admin_tracking_login`", "`logoutdate` = NOW()", "`id` = " + id + ""))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public bool removeTicketbyDate(int DayCount)
        {
            bool result = false;

            try
            {
                if (DBHandler.deleteDataBase(ref conn,
                                            "`order_admin_tracking_login`",
                                            "`logindate` < DATE_SUB(NOW(),INTERVAL " + DayCount + " DAY)"))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
    }
}
