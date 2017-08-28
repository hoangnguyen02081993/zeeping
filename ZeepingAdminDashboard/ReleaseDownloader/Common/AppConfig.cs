using MySql.Data.MySqlClient;
using ReleaseDownloader.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReleaseDownloader.Common
{
    public class AppConfig
    {
        public static string VersionNumber = "v1.0";
        public static string Version = "Zeeping.com - Auto Update " + VersionNumber;

        private const string ConfigFileName = "config.data";
        public static bool AutoUpdate = false;
        public static bool AutoRun = false;

        public static string DBServer;
        public static int DBPort;
        public static string DBDatabase;
        public static string DBUser;
        public static string DBPassword;
        public static string DBconnectString = Database.DBHandler.GetDBConnectionString(DBServer, DBPort, DBDatabase, DBUser, DBPassword);


        public static string WebUrl = string.Empty;
        public static string FTPHost = string.Empty;
        public static string FTPUser = string.Empty;
        public static string FTPPassword = string.Empty;
        public static string PathImageURL = string.Empty;

        public static string UserGmailNoReply = string.Empty;
        public static string PasswordGmailNoReply = string.Empty;

        public static string UserGmailSupport = string.Empty;
        public static string PasswordGmailSupport = string.Empty;

        public static string SubjectSupportForm = string.Empty;

        public static int DateClearTicket = 30;
        public static int DateClearLogin = 7;

        public static string WebVersion = string.Empty;
        public static string releaseLocation = string.Empty;

        public static bool LoadConfig()
        {
            bool result = false;

            if (DBHandler.CheckConnetion(DBconnectString))
            {
                MySqlConnection conn = new MySqlConnection(DBconnectString);
                DataTable dt = DBHandler.selectDataBase(ref conn, "`order_options`", "`option_name`, `option_value`", "");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((string)dt.Rows[i][0] == "WebUrl")
                        {
                            WebUrl = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "FTPHost")
                        {
                            FTPHost = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "FTPUser")
                        {
                            FTPUser = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "FTPPassword")
                        {
                            FTPPassword = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "PathImageURL")
                        {
                            PathImageURL = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "UserGmailNoReply")
                        {
                            UserGmailNoReply = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "PasswordGmailNoReply")
                        {
                            PasswordGmailNoReply = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "UserGmailSupport")
                        {
                            UserGmailSupport = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "PasswordGmailSupport")
                        {
                            PasswordGmailSupport = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "SubjectSupportForm")
                        {
                            SubjectSupportForm = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "DateClearTicket")
                        {
                            DateClearTicket = Int32.Parse((string)dt.Rows[i][1]);
                        }
                        else if ((string)dt.Rows[i][0] == "DateClearLogin")
                        {
                            DateClearLogin = Int32.Parse((string)dt.Rows[i][1]);
                        }
                        else if ((string)dt.Rows[i][0] == "Version")
                        {
                            WebVersion = (string)dt.Rows[i][1];
                        }
                        else if ((string)dt.Rows[i][0] == "releaseLocation")
                        {
                            releaseLocation = (string)dt.Rows[i][1];
                        }
                    }

                    if (WebUrl != string.Empty)
                    {
                        PathImageURL = WebUrl + PathImageURL;
                    }

                    result = true;
                }
            }

            return result;
        }
        public static bool SaveConfigToFile(string host, int port, string database, string username, string password, bool AutoUpdate = false, bool AutoRun = false)
        {
            bool result = false;

            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("ROOT");
                doc.AppendChild(root);
                XmlElement rootStation = doc.CreateElement("DBConfig");
                root.AppendChild(rootStation);
                rootStation.SetAttribute("DBServer", host);
                rootStation.SetAttribute("DBPort", port.ToString());
                rootStation.SetAttribute("DBDatabase", database);
                rootStation.SetAttribute("DBUser", username);
                rootStation.SetAttribute("DBPassword", password);
                rootStation.SetAttribute("AutoUpdate", AutoUpdate.ToString());
                rootStation.SetAttribute("AutoRun", AutoRun.ToString());

                string ConfigString = doc.InnerXml;
                ConfigString = Functions.StringEndcoder(ConfigString);
                File.WriteAllText(ConfigFileName, ConfigString);

                result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return result;
        }
        public static bool LoadConfigFromFile()
        {
            bool result = false;

            if (File.Exists(ConfigFileName))
            {
                try
                {
                    string ConfigString = File.ReadAllText(ConfigFileName);
                    ConfigString = Functions.StringDecoder(ConfigString);
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(ConfigString);
                    XmlElement root = xml.DocumentElement;

                    DBServer = ((XmlElement)root.ChildNodes[0]).GetAttribute("DBServer");
                    DBPort = Int32.Parse(((XmlElement)root.ChildNodes[0]).GetAttribute("DBPort"));
                    DBDatabase = ((XmlElement)root.ChildNodes[0]).GetAttribute("DBDatabase");
                    DBUser = ((XmlElement)root.ChildNodes[0]).GetAttribute("DBUser");
                    DBPassword = ((XmlElement)root.ChildNodes[0]).GetAttribute("DBPassword");
                    AutoUpdate = bool.Parse(((XmlElement)root.ChildNodes[0]).GetAttribute("AutoUpdate"));
                    AutoRun = bool.Parse(((XmlElement)root.ChildNodes[0]).GetAttribute("AutoRun"));
                    ExecConfig();
                }
                catch (Exception ex)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlElement root = doc.CreateElement("ROOT");
                        doc.AppendChild(root);
                        XmlElement rootStation = doc.CreateElement("DBConfig");
                        root.AppendChild(rootStation);
                        rootStation.SetAttribute("DBServer", "zeeping.com");
                        rootStation.SetAttribute("DBPort", "3306");
                        rootStation.SetAttribute("DBDatabase", "livescor_hht91");
                        rootStation.SetAttribute("DBUser", "livescor_hht91_u");
                        rootStation.SetAttribute("DBPassword", "cafe91hht");
                        rootStation.SetAttribute("AutoUpdate", false.ToString());
                        rootStation.SetAttribute("AutoRun", false.ToString());

                        string ConfigString = doc.InnerXml;
                        ConfigString = Functions.StringEndcoder(ConfigString);
                        File.WriteAllText(ConfigFileName, ConfigString);

                    }
                    catch (Exception ex1)
                    {
                        LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex1.Message);
                    }

                    DBServer = "zeeping.com";
                    DBPort = 3306;
                    DBDatabase = "livescor_hht91";
                    DBUser = "livescor_hht91_u";
                    DBPassword = "cafe91hht";
                    AutoUpdate = false;
                    AutoRun = false;
                    ExecConfig();
                    LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
                }

            }
            else
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement root = doc.CreateElement("ROOT");
                    doc.AppendChild(root);
                    XmlElement rootStation = doc.CreateElement("DBConfig");
                    root.AppendChild(rootStation);
                    rootStation.SetAttribute("DBServer", "zeeping.com");
                    rootStation.SetAttribute("DBPort", "3306");
                    rootStation.SetAttribute("DBDatabase", "livescor_hht91");
                    rootStation.SetAttribute("DBUser", "livescor_hht91_u");
                    rootStation.SetAttribute("DBPassword", "cafe91hht");
                    rootStation.SetAttribute("AutoUpdate", false.ToString());
                    rootStation.SetAttribute("AutoRun", false.ToString());

                    string ConfigString = doc.InnerXml;
                    ConfigString = Functions.StringEndcoder(ConfigString);
                    File.WriteAllText(ConfigFileName, ConfigString);

                }
                catch (Exception ex)
                {
                    LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
                }

                DBServer = "zeeping.com";
                DBPort = 3306;
                DBDatabase = "livescor_hht91";
                DBUser = "livescor_hht91_u";
                DBPassword = "cafe91hht";
                AutoUpdate = false;
                AutoRun = false;
                ExecConfig();
            }
            result = true;

            return result;
        }
        public static bool CheckVersion()
        {
            return VersionNumber.Equals(WebVersion);
        }
        public static void ExecConfig()
        {
            DBconnectString = Database.DBHandler.GetDBConnectionString(DBServer, DBPort, DBDatabase, DBUser, DBPassword);
        }
    }
}
