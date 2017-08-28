using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Common
{
    public class SMPTGMail
    {
        public string UserName { private set; get; }
        public string Password { private set; get; }
        private NetworkCredential mCredential;

        public SMPTGMail(string user,string pass)
        {
            this.UserName = user;
            this.Password = pass;
            mCredential = new NetworkCredential(UserName, Password);
        }
        public bool SendMailOnlyOne(string DescMail, string Subject,string Content)
        {
            bool result = false;
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


                bool check = regex.IsMatch(DescMail);
                if (check == false)
                {
                    return false;
                }
                else
                {
                    System.Net.Mail.SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = mCredential;
                    smtp.EnableSsl = true;
                    System.Net.Mail.MailMessage msg = new MailMessage(UserName, DescMail, Subject, Content);
                    msg.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";//Sử dụng SMTP của gmail
                    smtp.Port = 587;
                    smtp.Send(msg);
                    result = true;
                }
            }
            catch(Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            return result;
        }

    }
}
