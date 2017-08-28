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

namespace ZeepingAdminDashboard.Tool.SrumBoard
{
    public class ScrumBoardController
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
                            permission = (Resources.EnumClass.PermissionUser)((int)(short)dt.Rows[i]["permission_id"]),
                            Issupper = (bool)dt.Rows[i]["Issupper"]
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
        public List<StatusModel> getStatus()
        {
            List<StatusModel> result = new List<StatusModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_status`", "*", string.Empty);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StatusModel item = new StatusModel()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"]
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
        public List<PriorityModel> getPrioritys()
        {
            List<PriorityModel> result = new List<PriorityModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_priority`", "*", string.Empty);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        PriorityModel item = new PriorityModel()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"]
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
        public List<RelatedModel> getRelateds()
        {
            List<RelatedModel> result = new List<RelatedModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_related`", "*", string.Empty);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RelatedModel item = new RelatedModel()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"]
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
        public List<TicketModel> getAllTicketNotDone()
        {
            List<TicketModel> result = new List<TicketModel>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_ticket`", "*", "`status` < 5");
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
                            createdate = (DateTime)dt.Rows[i]["createdate"]
                        };
                        result.Add(item);
                    }
                    result = result.OrderByDescending(r => r.createdate).ToList();
                }
            }
            catch (Exception ex)
            {
                result = null;
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public long CreateTicket(TicketModel item)
        {
            long result = -1;

            try
            {
                if(DBHandler.insertDataBase(ref conn, 
                                            "`scrum_ticket`", 
                                            "(`name`, `description`, `priority`, `related`, `assigner`, `creater`, `status`)",
                                            "('" + item.name + "','" +
                                            Functions.StringtoUFT8String(item.description) + "','" +
                                            item.priority + "','" +
                                            item.related + "','" +
                                            item.assigner + "','" +
                                            item.creater + "','" +
                                            item.status + "')" ))
                {
                    using (DataTable dt = DBHandler.selectDataBase(ref conn, "`scrum_ticket`", " `id`", "`name` = '" + item.name + "'","order by `id` desc LIMIT 1"))
                    {
                        if(dt.Rows.Count == 1)
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

        public bool AssginTicket(TicketModel item)
        {
            bool result = false;

            try
            {
                if (DBHandler.updateDataBase(ref conn,
                                            "`scrum_ticket`",
                                            "`assigner`= '" + item.assigner + "'",
                                            "`id` = " + item.id))
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
        public bool setStatusTicket(TicketModel item)
        {
            bool result = false;

            try
            {
                if (DBHandler.updateDataBase(ref conn,
                                            "`scrum_ticket`",
                                            "`status`= '" + item.status + "', `reviewdescription`= '" + Functions.StringtoUFT8String(item.reviewdescription) + "'" +
                                            ((item.status == 5) ? " ,`donedate` = NOW()" : ""),
                                            "`id` = " + item.id))
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
        public bool removeTicket(TicketModel item)
        {
            bool result = false;

            try
            {
                if (DBHandler.deleteDataBase(ref conn,
                                            "`scrum_ticket`",
                                            "`id` = " + item.id))
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
                                            "`scrum_ticket`",
                                            "`createdate` < DATE_SUB(NOW(),INTERVAL " + DayCount + " DAY) and `status` = 5"))
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
