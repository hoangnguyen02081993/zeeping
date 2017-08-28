using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ZeepingAdminDashboard.Model;
using ZeepingAdminDashboard.Common;
using System.Data;
using ZeepingAdminDashboard.Database;

namespace ZeepingAdminDashboard.Controller
{
    public class Product_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public List<Product_Color_Model> getColorList()
        {
            List<Product_Color_Model> result = new List<Product_Color_Model>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_product_color`", "*", string.Empty);
                if(dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Product_Color_Model item = new Product_Color_Model()
                        {
                            Id = (long)dt.Rows[i]["color_id"],
                            Name = (string)dt.Rows[i]["color_name"],
                            Colors = Functions.GenerateColor((string)dt.Rows[i]["color_value"]),
                            ColorCode = (string)dt.Rows[i]["color_value"],
                            colorofstyle = (long)dt.Rows[i]["colorofstyle"]
                        };
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public List<Product_Style_Model> getStyleList()
        {
            List<Product_Style_Model> result = new List<Product_Style_Model>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_product_style`", "*", string.Empty);
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Product_Style_Model item = new Product_Style_Model()
                        {
                            Id = (long)dt.Rows[i]["style_id"],
                            Name = (string)dt.Rows[i]["style_name"],
                            Cost = (string)dt.Rows[i]["style_cost"],
                            ishavebehide = (bool)dt.Rows[i]["ishavebehide"]
                        };
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public bool Addproduct(Product_Model product)
        {
            bool result = false;
            try
            {
                if (DBHandler.insertDataBase(ref conn,
                                        "`order_product`",
                                          "(`product_name`, `product_image_design`, `product_title`, `product_content`, `product_link`, `style_list`, `color_list`, `style_design`, `isFeaturedProduct`, `linkFeaturedImage`, `linkProduct`, `Catogarys`,`rangcost`,`hashtag`)",
                                          "('" + product.product_name + "'," +
                                          "'" + product.product_iamge_design + "'," +
                                          "'" + product.product_title + "'," +
                                          "'" + product.product_content + "'," +
                                          "'" + product.product_link + "'," +
                                          "'" + product.style_list + "'," +
                                          "'" + product.color_list + "'," +
                                          "'" + product.style_design + "'," +
                                          "" + product.isFeaturedProduct + "," +
                                          "'" + product.linkFeaturedImage + "'," +
                                          "'" + product.linkProduct + "'," +
                                          "'" + product.Catogarys + "'," +
                                          "'" + product.rangcost + "'," +
                                          "'" + product.hashtag + "')")) result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }
        public bool Searchproduct(ref List<Product_Model> lstResult,string MSP,string TSP)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                if(MSP != string.Empty)
                {
                    condition += "(`product_id` like '%" + MSP.Replace("\'","\\\'") + "' ";
                    condition += " or `product_id` like '" + MSP.Replace("\'", "\\\'") + "%' ";
                    condition += " or `product_id` like '%" + MSP.Replace("\'", "\\\'") + "%') ";
                }
                if(TSP != string.Empty)
                {
                    if (condition != string.Empty)
                    {
                        condition += "and (`product_name` like '%" + TSP.Replace("\'", "\\\'") + "' ";
                        condition += " or `product_name` like '" + TSP.Replace("\'", "\\\'") + "%' ";
                        condition += " or `product_name` like '%" + TSP.Replace("\'", "\\\'") + "%') ";
                    }
                    else
                    {
                        condition += "(`product_name` like '%" + TSP.Replace("\'", "\\\'") + "' ";
                        condition += " or `product_name` like '" + TSP.Replace("\'", "\\\'") + "%' ";
                        condition += " or `product_name` like '%" + TSP.Replace("\'", "\\\'") + "%') ";
                    }
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_product`",
                                          "*",
                                          condition)) != null)
                {
                    lstResult = new List<Product_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Product_Model item = new Product_Model()
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
                            createdDate = (DateTime)dt.Rows[i]["createdDate"],
                            isFeaturedProduct = (bool)dt.Rows[i]["isFeaturedProduct"],
                            linkFeaturedImage = (string)dt.Rows[i]["linkFeaturedImage"],
                            linkProduct = (string)dt.Rows[i]["linkProduct"],
                            Catogarys = (string)dt.Rows[i]["Catogarys"],
                            rangcost = (string)dt.Rows[i]["rangcost"],
                            hashtag = (string)dt.Rows[i]["hashtag"]
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
        public bool CheckExistProductLink(ref bool rs, string ProductLink)
        {
            bool result = false;
            result = false;
            try
            {
                DataTable dt = null;
                if ((dt = DBHandler.selectDataBase(ref conn, "`order_product`", "*", "`linkProduct` = '" + ProductLink + "'")) != null)
                {
                    if(dt.Rows.Count == 0)
                    {
                        dt = null;
                        if ((dt = DBHandler.selectDataBase(ref conn, "`web_menu_group`", "*", "`link` = '" + ProductLink + "'")) != null)
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
        public bool getAllCatogary(ref List<Web_Menu_Model> lstResult)
        {
            bool result = false;
            try
            {
                
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`web_menu_group`",
                                          "*",
                                          "`isPage` = '0'")) != null)
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
        public bool ChangeCatogary(long MSP, string NewCatogarys)
        {
            bool result = false;
            try
            {

                if(DBHandler.updateDataBase(ref conn,
                    "`order_product`",
                    "`Catogarys` = '" + NewCatogarys + "'",
                    "`product_id` = " + MSP))
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
        public bool ChangeHashTag(long MSP, string NewHashTag)
        {
            bool result = false;
            try
            {

                if (DBHandler.updateDataBase(ref conn,
                    "`order_product`",
                    "`hashtag` = '" + NewHashTag + "'",
                    "`product_id` = " + MSP))
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
