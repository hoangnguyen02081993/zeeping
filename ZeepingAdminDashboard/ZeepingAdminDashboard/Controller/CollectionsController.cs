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
    public class CollectionsController
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool SearchCollections(ref List<Web_Collections_Model> lstResult, string Ma,string Name)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                if (Ma != string.Empty)
                {
                    condition += "(`id` like '%" + Ma.Replace("\'", "\\\'") + "' ";
                    condition += " or `id` like '" + Ma.Replace("\'", "\\\'") + "%' ";
                    condition += " or `id` like '%" + Ma.Replace("\'", "\\\'") + "%') ";
                }
                if (Name != string.Empty)
                {
                    if (condition != string.Empty)
                    {
                        condition += "and (`name` like '%" + Name.Replace("\'", "\\\'") + "' ";
                        condition += " or `name` like '" + Name.Replace("\'", "\\\'") + "%' ";
                        condition += " or `name` like '%" + Name.Replace("\'", "\\\'") + "%') ";
                    }
                    else
                    {
                        condition += "(`name` like '%" + Name.Replace("\'", "\\\'") + "' ";
                        condition += " or `name` like '" + Name.Replace("\'", "\\\'") + "%' ";
                        condition += " or `name` like '%" + Name.Replace("\'", "\\\'") + "%') ";
                    }
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`web_collections`",
                                          "*",
                                          condition)) != null)
                {
                    lstResult = new List<Web_Collections_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Web_Collections_Model item = new Web_Collections_Model()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"],
                            title = (string)dt.Rows[i]["title"],
                            content = (string)dt.Rows[i]["content"],
                            isdraft = (bool)dt.Rows[i]["isdraft"],
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
        public bool Delete(Web_Collections_Model Obj)
        {
            bool result = false;

            try
            {
                if (DBHandler.deleteDataBase(ref conn,
                                            "`web_collections`",
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
        public bool Add(Web_Collections_Model Obj)
        {
            bool result = false;
            try
            {
                if (DBHandler.insertDataBase(ref conn,
                                        "`web_collections`",
                                          "(`name`, `title`, `content`, `isdraft`)",
                                          "('" + Obj.name + "'," +
                                          "('" + Obj.title + "'," +
                                          "('" + Obj.content + "'," +
                                          "'" + Obj.isdraft + "')")) result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public bool Save(Web_Collections_Model Obj)
        {
            bool result = false;
            try
            {
                // if Obj.id == -1. It doest't add. Add and save.
                if(Obj.id == -1)
                {
                    Add(Obj);
                }
                else
                {
                    Update(Obj);
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }

        public bool Update(Web_Collections_Model Obj)
        {
            bool result = false;
            try
            {
                if (DBHandler.updateDataBase(ref conn, "`web_collections`", "`name` = '" + Obj.name + "', `content` = '" + Obj.content + "', `isdraft` = '" + Obj.isdraft + "'", "`id` = '" + Obj.id + "'"))
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
