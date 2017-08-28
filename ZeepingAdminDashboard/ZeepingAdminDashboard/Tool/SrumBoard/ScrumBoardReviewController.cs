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
    public class ScrumBoardReviewController
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public List<TicketModel> getAllTicketDone()
        {
            List<TicketModel> result = new List<TicketModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_ticket`", "*", "`status` = 5");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TicketModel item = new TicketModel()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"],
                            assigner = (string)dt.Rows[i]["assigner"],
                            creater = (string)dt.Rows[i]["creater"],
                            description = Functions.UFT8StringtoString((string)dt.Rows[i]["description"]),
                            priority = (int)dt.Rows[i]["priority"],
                            related = (int)dt.Rows[i]["related"],
                            status = (int)dt.Rows[i]["status"],
                            reviewdescription = Functions.UFT8StringtoString((string)dt.Rows[i]["reviewdescription"]),
                            createdate = (DateTime)dt.Rows[i]["createdate"],
                            donedate = (DateTime)dt.Rows[i]["donedate"]
                        };
                        result.Add(item);
                    }
                    result = result.OrderBy(r => r.createdate).ToList();
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
