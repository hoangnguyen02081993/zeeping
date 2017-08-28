using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Database;
using ZeepingAdminDashboard.Model;
using static ZeepingAdminDashboard.Resources.EnumClass;

namespace ZeepingAdminDashboard.Controller
{
    public class Login_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public List<AdminUser_Model> getAllUser()
        {
            List<AdminUser_Model> result = new List<AdminUser_Model>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_admin_user`", "*", string.Empty);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AdminUser_Model item = new AdminUser_Model()
                        {
                            username = (string)dt.Rows[i]["username"],
                            password = (string)dt.Rows[i]["password"],
                            firstname = (string)dt.Rows[i]["firstname"],
                            lastname = (string)dt.Rows[i]["lastname"],
                            permission = (PermissionUser)((int)(short)dt.Rows[i]["permission_id"])
                        };
                        result.Add(item);
                    }
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
