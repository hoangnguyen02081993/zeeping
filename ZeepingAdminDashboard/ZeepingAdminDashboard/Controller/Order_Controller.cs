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
    public class Order_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool getStatusList(ref List<Order_Status_Model> lstResult)
        {
            bool result = false;
            try
            {
                
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_status`",
                                          "*",
                                          "`isenable` = 1")) != null)
                {
                    lstResult = new List<Order_Status_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Order_Status_Model item = new Order_Status_Model()
                        {
                            id = (short)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"]
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
        public bool SearchOrder(ref List<Order_Model> lstResult, DateTime beginTime, DateTime endTime, string User, short IsCompleted)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                condition += "`ischeckoutcompleted` = " + true.ToString() + " " ;
                if(IsCompleted != 1) condition += "and `isOrderCompleted` = '" + IsCompleted + "' ";
                condition += "and `createDate` >= '" + beginTime.ToString("yyyyMMddHHmmss") + "' ";
                condition += "and `createDate` <= '" + endTime.ToString("yyyyMMddHHmmss") + "' ";
                if (User != string.Empty)
                {
                    condition += "and (`username` like '%" + User.Replace("\'", "\\\'") + "' ";
                    condition += " or `username` like '" + User.Replace("\'", "\\\'") + "%' ";
                    condition += " or `username` like '%" + User.Replace("\'", "\\\'") + "%') ";
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order`",
                                          "*",
                                          condition)) != null)
                {
                    lstResult = new List<Order_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Order_Model item = new Order_Model()
                        {
                            order_id = (long)dt.Rows[i]["order_id"],
                            guid = (string)dt.Rows[i]["guid"],
                            product_id = (long)dt.Rows[i]["product_id"],
                            style_id = (long)dt.Rows[i]["style_id"],
                            color_id = (long)dt.Rows[i]["color_id"],
                            size_id = (long)dt.Rows[i]["size_id"],
                            quantity = (int)dt.Rows[i]["quantity"],
                            username = (string)dt.Rows[i]["username"],
                            ischeckoutcompleted = (bool)dt.Rows[i]["ischeckoutcompleted"],
                            createDate = (DateTime)dt.Rows[i]["createDate"],
                            email = (string)dt.Rows[i]["email"],
                            firstname = (string)dt.Rows[i]["firstname"],
                            lastname = (string)dt.Rows[i]["lastname"],
                            street_address = (string)dt.Rows[i]["street_address"],
                            apt_suite_other = (string)dt.Rows[i]["apt_suite_other"],
                            city = (string)dt.Rows[i]["city"],
                            postal_code = (string)dt.Rows[i]["postal_code"],
                            country_id = (int)dt.Rows[i]["country_id"],
                            phone_number = (string)dt.Rows[i]["phone_number"],
                            province = (string)dt.Rows[i]["province"],
                            isOrderCompleted = (short)dt.Rows[i]["isOrderCompleted"]
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
        public bool DeleteOrder(long id)
        {
            bool result = false;

            try
            {
                string sql_insert_deleted_table = "INSERT INTO `order_deleted`(`order_id`, `guid`, `product_id`, `style_id`, `color_id`, `size_id`, `quantity`, `username`, `ischeckoutcompleted`, `createDate`, `isOrderCompleted`, `email`, `firstname`, `lastname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province`) SELECT `order_id`, `guid`, `product_id`, `style_id`, `color_id`, `size_id`, `quantity`, `username`, `ischeckoutcompleted`, `createDate`, `isOrderCompleted`, `email`, `firstname`, `lastname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province` from `order` where order_id = " + id;
                if (DBHandler.SQLcommandExecute(ref conn, sql_insert_deleted_table))
                {
                    if (DBHandler.deleteDataBase(ref conn,
                            "`order`",
                            "`order_id` = " + id))
                    {
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
        public bool ChangeStatusOrder(long id,short statusId)
        {
            bool result = false;

            try
            {
                if (DBHandler.updateDataBase(ref conn,
                        "`order`",
                        "`isOrderCompleted` = '" + statusId + "'" ,
                        "`order_id` = " + id))
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
        public Product_Model getProductbyId(long id)
        {
            Product_Model result = null;
            try
            {
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_product`",
                                          "*",
                                          "`product_id` = " + id)) != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result = new Product_Model()
                        {
                            product_id = (long)dt.Rows[i]["product_id"],
                            product_name = (string)dt.Rows[i]["product_name"],
                            product_title = (string)dt.Rows[i]["product_title"],
                            product_link = (string)dt.Rows[i]["product_link"],
                            product_content = (string)dt.Rows[i]["product_content"],
                            product_iamge_design = (string)dt.Rows[i]["product_image_design"],
                            color_list = (string)dt.Rows[i]["color_list"],
                            style_list = (string)dt.Rows[i]["style_list"],
                            style_design = (string)dt.Rows[i]["style_design"],
                            hashtag = (string)dt.Rows[i]["hashtag"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public Product_Color_Model getColorbyId(long id)
        {
            Product_Color_Model result = null;
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_product_color`", "*", "`color_id` = " + id);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result = new Product_Color_Model()
                        {
                            Id = (long)dt.Rows[i]["color_id"],
                            Name = (string)dt.Rows[i]["color_name"],
                            Colors = Functions.GenerateColor((string)dt.Rows[i]["color_value"]),
                            ColorCode = (string)dt.Rows[i]["color_value"],
                            colorofstyle = (long)dt.Rows[i]["colorofstyle"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public Country getCountrybyId(long id)
        {
            Country result = null;
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_country`", "*", "`country_id` = " + id);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result = new Country()
                        {
                            country_id = (long)dt.Rows[i]["country_id"],
                            country_name = (string)dt.Rows[i]["country_name"],
                            country_region = (int)dt.Rows[i]["country_region"],
                            ship_per_item_cost = (double)dt.Rows[i]["ship_per_item_cost"],
                            ship_cost = (double)dt.Rows[i]["ship_cost"]
                        };
                    }
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
