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
    public class Support_Controller
    {
        private MySqlConnection conn = new MySqlConnection(Common.AppConfig.DBconnectString);

        public bool SearchUser(ref List<UserSupport_Model> lstResult,  bool? isreplied = null)
        {
            bool result = false;
            try
            {
                string condition = string.Empty;
                if (isreplied != null)
                {
                    condition += "isreplied = " + isreplied.ToString() + " ";
                }
                DataTable dt;
                if ((dt = DBHandler.selectDataBase(ref conn,
                                        "`order_user_support`",
                                          "`id`, `name`, `mail`, `phonenumber`, `message`, `isreplied`, `repliedmessage`, `repliedsubject`",
                                          condition)) != null)
                {
                    lstResult = new List<UserSupport_Model>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UserSupport_Model item = new UserSupport_Model()
                        {
                            id = (long)dt.Rows[i]["id"],
                            name = (string)dt.Rows[i]["name"],
                            mail = (string)dt.Rows[i]["mail"],
                            phonenumber = (string)dt.Rows[i]["phonenumber"],
                            message = (string)dt.Rows[i]["message"],
                            isreplied = (bool)dt.Rows[i]["isreplied"],
                            repliedsubject = (string)dt.Rows[i]["repliedsubject"],
                            repliedmessage = (string)dt.Rows[i]["repliedmessage"]
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
        /// 
        /// </summary>
        /// <param name="mData"></param>
        /// <returns>-1: false; 0: success; 1: Can't connect DB; 2: Can't sendmail</returns>
        public int ReplySupportRequest(UserSupport_Model mData)
        {
            int result = -1;

            try
            {
                //Ghi DB voi thong tin username
                if (DBHandler.updateDataBase(ref conn, "`order_user_support`", "`isreplied`=" + true.ToString() + ",`repliedsubject`='" + mData.repliedsubject + "',`repliedmessage`='" + mData.repliedmessage + "'", "`id`= " + mData.id))
                {
                    //Gui mai :
                    SMPTGMail mail = new SMPTGMail(AppConfig.UserGmailSupport, AppConfig.PasswordGmailSupport);
                    bool sendmailSuccess = false;
                    for (int i = 0; i < 5; i++)
                    {
                        if (mail.SendMailOnlyOne(mData.mail, mData.repliedsubject, mData.repliedmessage.Replace("\n","<br/>")))
                        {
                            sendmailSuccess = true;
                            break;
                        }
                    }
                    result = (sendmailSuccess) ? 0 : 2;
                    if (result == 2)
                    {
                        DBHandler.updateDataBase(ref conn, "`order_user_support`", "`isreplied`=" + false.ToString() + ",`repliedsubject`='',`repliedmessage`=''", "`id`= " + mData.id);
                    }
                }
                else
                {
                    result = 1;
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
