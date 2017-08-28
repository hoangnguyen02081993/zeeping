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

namespace ZeepingAdminDashboard.Controller
{
    public class FAQController
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool Refresh(ref List<Web_page_FAQ> lstResult)
        {
            bool result = false;
            try
            {
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`web_page_FAQ`",
                                          "*",
                                          string.Empty)) != null)
                {
                    lstResult = new List<Web_page_FAQ>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Web_page_FAQ item = new Web_page_FAQ()
                        {
                            id = (long)dt.Rows[i]["id"],
                            question = (string)dt.Rows[i]["question"],
                            answer = (string)dt.Rows[i]["answer"]
                        };
                        lstResult.Add(item);
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public bool Delete(Web_page_FAQ Obj)
        {
            bool result = false;

            try
            {
                if (DBHandler.deleteDataBase(ref conn,
                                            "`web_page_FAQ`",
                                            "`id` = " + Obj.id))
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
        public bool Add(Web_page_FAQ Obj)
        {
            bool result = false;
            try
            {
                if (DBHandler.insertDataBase(ref conn,
                                        "`web_page_FAQ`",
                                          "(`question`, `answer`)",
                                          "('" + Obj.question + "'," +
                                          "'" + Obj.answer + "')")) result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public bool Update(Web_page_FAQ Obj)
        {
            bool result = false;
            try
            {
                if (DBHandler.updateDataBase(ref conn, "`web_page_FAQ`", "`question` = '" + Obj.question + "', `answer` = '" + Obj.answer + "'", "`id` = '" + Obj.id + "'"))
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
