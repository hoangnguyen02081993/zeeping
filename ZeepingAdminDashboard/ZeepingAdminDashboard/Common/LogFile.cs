using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeepingAdminDashboard.Common
{
    public class LogFile
    {
        public static string DIR = System.Windows.Forms.Application.StartupPath + @"\LogFile\";
        public enum Filemode
        {
            GHIDE = 0,
            GHIMOI = 1
        };
        public static void writeLog(string dir, string filename, Filemode filemode, string message)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            if (filemode.Equals(Filemode.GHIMOI))
            {
                if (File.Exists(dir + filename)) File.Delete(dir + filename);
                FileStream fs = File.Open(dir + filename, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : " + message);
                sw.Write("\r\n");
                sw.Write("----------------------------------------------------------------------------------------");
                sw.Write("\r\n");
                sw.Dispose();
                fs.Close();
                fs.Dispose();
            }
            else if (filemode.Equals(Filemode.GHIDE))
            {
                try
                {
                    FileStream fs = File.Open(dir + filename, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : " + message);
                    sw.Write("\r\n");
                    sw.Write("----------------------------------------------------------------------------------------");
                    sw.Write("\r\n");
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch { }
            }
        }
        public static string getTimeStringNow()
        {
            string result = string.Empty;

            result = DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "");

            return result;
        }
    }
}
