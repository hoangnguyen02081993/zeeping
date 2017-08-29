using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeepingAdminDashboard.Common;
using ZeepingAdminDashboard.Database;
using ZeepingAdminDashboard.Model;

namespace ZeepingAdminDashboard.Controller
{
    public class CollectionsController
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool getAllCatogary(ref List<Web_Menu_Model> lstResult)
        {
            bool result = false;
            try
            {

                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`web_menu_group`",
                                          "*",
                                          "`isPage` = '0' and `Isflash` = 1")) != null)
                {
                    lstResult = new List<Web_Menu_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Web_Menu_Model item = new Web_Menu_Model()
                        {
                            id = (int)dt.Rows[i]["id"],
                            stt = (int)dt.Rows[i]["stt"],
                            floor = (short)dt.Rows[i]["floor"],
                            name = (string)dt.Rows[i]["name"],
                            childof = (string)dt.Rows[i]["childof"],
                            isPage = (bool)dt.Rows[i]["isPage"],
                            link = (string)dt.Rows[i]["link"]
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
                            featureimage = (string)dt.Rows[i]["featureimage"],
                            title = (string)dt.Rows[i]["title"],
                            description = (string)dt.Rows[i]["description"],
                            content = (string)dt.Rows[i]["content"],
                            relatedmenu = (int)dt.Rows[i]["relatedmenu"],
                            createdDate = (DateTime)dt.Rows[i]["createdDate"],
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
        public bool GetCollectionbyName(ref Web_Collections_Model collection,string name)
        {
            bool result = false;
            try
            {
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`web_collections`",
                                          "*",
                                          "`name` = '" + name + "'",
                                          "LIMIT 1")) != null)
                {
                    if(dt.Rows.Count == 1)
                    {
                        collection = new Web_Collections_Model()
                        {
                            id = (long)dt.Rows[0]["id"],
                            name = (string)dt.Rows[0]["name"],
                            featureimage = (string)dt.Rows[0]["featureimage"],
                            title = (string)dt.Rows[0]["title"],
                            description = (string)dt.Rows[0]["description"],
                            content = (string)dt.Rows[0]["content"],
                            relatedmenu = (int)dt.Rows[0]["relatedmenu"],
                            createdDate = (DateTime)dt.Rows[0]["createdDate"],
                            isdraft = (bool)dt.Rows[0]["isdraft"],
                        };
                        result = true;
                    }
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
                                          "(`name`, `title`, `featureimage`, `description`, `relatedmenu`, `content`, `isdraft`)",
                                          "('" + Obj.name + "'," +
                                          "'" + Obj.title.Replace("'","\'").Replace("\n", "<br/>") + "'," +
                                          "'" + Obj.featureimage.Replace("'", "\'") + "'," +
                                          "'" + Obj.description.Replace("'", "\'") + "'," +
                                          "'" + Obj.relatedmenu + "'," +
                                          "'" + Obj.content.Replace("'", "\'").Replace("\n","<br/>") + "'," +
                                          "" + ((Obj.isdraft) ? 1 : 0) + ")")) result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public bool Save(Web_Collections_Model Obj, ref long id)
        {
            bool result = false;
            try
            {
                // if Obj.id == -1. It doest't add. Add and save.
                if(Obj.id == -1)
                {
                    Add(Obj);
                    id = -1;
                    Web_Collections_Model rs = null;
                    if (GetCollectionbyName(ref rs, Obj.name))
                    {
                        id = rs.id;
                    }
                }
                else
                {
                    Update(Obj);
                    id = Obj.id;
                }
                result = true;
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
                if (DBHandler.updateDataBase(ref conn, "`web_collections`", 
                                            "`name` = '" + Obj.name +
                                            "', `title` = '" + Obj.title.Replace("'", "\'") +
                                            "', `featureimage` = '" + Obj.featureimage.Replace("'", "\'") +
                                            "', `description` = '" + Obj.description.Replace("'", "\'").Replace("\n", "<br/>") +
                                            "', `relatedmenu` = '" + Obj.relatedmenu +
                                            "', `content` = '" + Obj.content.Replace("'", "\'").Replace("\n", "<br/>") +
                                            "', `isdraft` = " + ((Obj.isdraft) ? 1: 0) , "`id` = '" + Obj.id + "'"))
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

        public bool CheckExistCollectionLink(ref bool rs, string CollectionLink)
        {
            bool result = false;
            result = false;
            try
            {
                DataTable dt = null;
                if ((dt = DBHandler.selectDataBase(ref conn, "`web_collections`", "*", "`name` = '" + CollectionLink + "'")) != null)
                {
                    if (dt.Rows.Count == 0)
                    {
                        dt = null;
                        if ((dt = DBHandler.selectDataBase(ref conn, "`web_menu_group`", "*", "`link` = '" + CollectionLink + "'")) != null)
                        {
                            if (dt.Rows.Count == 0)
                            {
                                rs = true;
                            }
                            result = true;
                        }
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
    }
}
