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
    public class User_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);
        public bool SearchUser (ref List<User_Model> lstResult, string UserName,string Fullname, string mLevel, bool? enable)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                if (enable != null)
                {
                    condition += "`isenable` = " + enable.ToString() + " and ";
                }
                if (UserName != string.Empty)
                {
                    condition += "(`username` like '%" + UserName.Replace("\'", "\\\'") + "' ";
                    condition += " or `username` like '" + UserName.Replace("\'", "\\\'") + "%' ";
                    condition += " or `username` like '%" + UserName.Replace("\'", "\\\'") + "%') ";
                }
                if (Fullname != string.Empty)
                {
                    condition += "(`fullname` like '%" + Fullname.Replace("\'", "\\\'") + "' ";
                    condition += " or `fullname` like '" + Fullname.Replace("\'", "\\\'") + "%' ";
                    condition += " or `fullname` like '%" + Fullname.Replace("\'", "\\\'") + "%') ";
                }
                if (mLevel != string.Empty)
                {

                    condition += "(`fullname` like '%" + mLevel.Replace("\'", "\\\'") + "' ";
                    condition += " or `fullname` like '" + mLevel.Replace("\'", "\\\'") + "%' ";
                    condition += " or `fullname` like '%" + mLevel.Replace("\'", "\\\'") + "%') ";
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_user`",
                                          "`username`, `password`, `promosion_money`, `email`, `fullname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province`, `isenable`",
                                          condition)) != null)
                {
                    lstResult = new List<User_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        User_Model item = new User_Model()
                        {
                            username = (string)dt.Rows[i]["username"],
                            password = (string)dt.Rows[i]["password"],
                            apt_suite_other = (string)dt.Rows[i]["apt_suite_other"],
                            city = (string)dt.Rows[i]["city"],
                            country_id = (int)dt.Rows[i]["country_id"],
                            email = (string)dt.Rows[i]["email"],
                            fullname = (string)dt.Rows[i]["fullname"],
                            phone_number = (string)dt.Rows[i]["phone_number"],
                            postal_code = (string)dt.Rows[i]["postal_code"],
                            promosion_money = (double)dt.Rows[i]["promosion_money"],
                            street_address = (string)dt.Rows[i]["street_address"],
                            province = (string)dt.Rows[i]["province"],
                            isenable = (bool)dt.Rows[i]["isenable"]
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
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="UserName">User name need add</param>
        /// <returns>0: success; -1: Unknown; 1: Can't not DB; 2: Can not send mail; 3: User đã được sử dụng; 4: Dinh dang mail khong dung</returns>
        public int AddUser(string UserName)
        {
            int result = -1;

            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


                bool check = regex.IsMatch(UserName);
                if (check == false)
                {
                    result = 4;
                    return result;
                }

                bool IsHave = false;
                // Kiểm tra username có được sử dụng hay chưa
                using (DataTable dt = DBHandler.selectDataBase(ref conn, "`order_user`", "*", "`username` = '" + UserName + "'"))
                {
                    if(dt.Rows.Count > 0)
                    {
                        IsHave = true;
                    }
                }
                if (IsHave)
                {
                    result = 3;
                }
                else
                {
                    //Ghi DB voi thong tin username
                    if (DBHandler.insertDataBase(ref conn, "`order_user`", "(`username`,`usernamemd5`,`email`)", "('" + UserName + "','" + Functions.GetMD5(UserName) + "','" + UserName + "')"))
                    {
                        //Gui mai :
                        SMPTGMail mail = new SMPTGMail(AppConfig.UserGmailNoReply, AppConfig.PasswordGmailNoReply);
                        bool sendmailSuccess = false;
                        for (int i = 0; i < 5; i++)
                        {
                            if (mail.SendMailOnlyOne(UserName, getSubject(), getContent(UserName)))
                            {
                                sendmailSuccess = true;
                                break;
                            }
                        }
                        result = (sendmailSuccess) ? 0 : 2;
                        if(result == 2)
                        {
                            DBHandler.deleteDataBase(ref conn, "`order_user`", "`username` = '" + UserName + "'");
                        }
                    }
                    else
                    {
                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        private string getSubject()
        {
            return "Zeeping Shop : Active your account";
        }
        private string getContent(string UserName)
        {
            string result = string.Empty;
            result += "Dear " + UserName.Remove((UserName.IndexOf('@') < 0) ? UserName.Length - 1 : UserName.IndexOf('@')) + ",<br/><br/>";
            result += "Congratulation to you!<br/>";
            result += "After you were buying completely at zeeping store, we are supplying your Zeeping’s account which support and bring you superior advantages to new customer.<br/>";
            result += "Ex: You will get a 10% discount on the next product<br/><br/>";
            result += "Click here to active your zeeping acccount:<br/>";
            result += "<a href=\"http://zeeping.com/customer/register.php?u=" + Functions.GetMD5(UserName) + "\" >http://zeeping.com/customer/register.php?u=" + Functions.GetMD5(UserName) + "</a><br/><br/>"; // link kich hoat
            result += "Please read particular zeeping guide for more useful. This link is below: <br/>";
            result += "<a href=\"http://zeeping.com/about-us\">http://zeeping.com/about-us</a><br/>"; // link huong dan
            result += "If you wanna design any product, don’t worry and please contact us to help you in anytime.<br/>";
            result += "Your happiness is my fun!<br/>";
            result += "The Zeeping Team!<br/><br/>";
            result += "Support Link: <a href=\"http://zeeping.com/customer/support.php\">http://zeeping.com/customer/support.php</a><br/>";// link ho tro khac hang
            result += "<span style=\"font-size:8pt;font-style:italic\">(This is an automatic mail. Doesn't reply. Thanks)</span><br/><br/>";
            result += "<img src=\"http://zeeping.com/image/common/logo.jpg\" style=\"width:200px;height:100px\" />";
            return result;
        }
        public List<Product_Color_Model> getColorList()
        {
            List<Product_Color_Model> result = new List<Product_Color_Model>();
            try
            {
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_product_color`", "*", string.Empty);
                if (dt != null)
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
        public bool SearchTrackingMail(ref List<TrackingMail_Model> lstResult, string email,long style_id,long color_id)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                condition += "`id` > 0";
                if (email != string.Empty)
                {
                    condition += " and (`email` like '%" + email.Replace("\'", "\\\'") + "' ";
                    condition += " or `email` like '" + email.Replace("\'", "\\\'") + "%' ";
                    condition += " or `email` like '%" + email.Replace("\'", "\\\'") + "%')";
                }
                if (style_id != -1)
                {
                    condition += " and `style_id` = " + style_id ;
                }
                if (color_id != -1)
                {
                    condition += " and `color_id` = " + color_id ;
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_mail_tracking`",
                                          "`id`, `email`, `product_id` , `style_id`, `color_id`, `date`",
                                          condition)) != null)
                {
                    lstResult = new List<TrackingMail_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TrackingMail_Model item = new TrackingMail_Model()
                        {
                            id = (long)dt.Rows[i]["id"],
                            email = (string)dt.Rows[i]["email"],
                            product_id = (long)dt.Rows[i]["product_id"],
                            style_id = (long)dt.Rows[i]["style_id"],
                            color_id = (long)dt.Rows[i]["color_id"],
                            date = (DateTime)dt.Rows[i]["date"],
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
        public bool DeleteTrackingMail(long id)
        {
            bool result = false;

            try
            {
                if (DBHandler.deleteDataBase(ref conn,
                                            "`order_mail_tracking`",
                                            "`id` = " + id))
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
