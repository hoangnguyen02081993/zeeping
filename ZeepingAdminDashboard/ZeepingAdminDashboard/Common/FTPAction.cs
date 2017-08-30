using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.Common
{
    public class FTPAction
    {

        public const string localPathDesign = "public_html/image/Design";
        public const string localPathFeaturedImage = "public_html/image/productimage";
        public const string localSourceWeb = "public_html";
        public static bool sendFile(string Ihost, string Iuser, string Ipassword, string localPath, string localFileName, string pathfile, string SafeFileName)
        {
            bool result = false;
            try
            {
                byte[] fileContents;
                try
                {
                    fileContents = File.ReadAllBytes(((pathfile == "") ? "" : pathfile + "\\") + SafeFileName);
                }
                catch
                {
                    System.Threading.Thread.Sleep(200);
                    fileContents = File.ReadAllBytes(((pathfile == "") ? "" : pathfile + "\\") + SafeFileName);
                }
                MakeFTPDir(Ihost, Iuser, Ipassword, localPath);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Ihost + "/" + localPath + "/" + localFileName);
                string tmp = "ftp://" + Ihost + "/" + localPath + "/" + localFileName;
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(Iuser, Ipassword);
                request.ContentLength = fileContents.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                if (response.StatusDescription.IndexOf("File successfully transferred") >= 0)
                {
                    result = true;
                }
                response.Close();
                LogFile.writeLog(LogFile.DIR, "FTPRecived_" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, "FILE :" + localPath + "/" + localFileName + "(response.StatusDescription: " + response.StatusDescription + ")");
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SendFile_" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, "Không thể đồng bộ file: " + localFileName + " (Error: " + ex.Message + " )");
            }
            return result;
        }
        public static bool deleteFile(string Ihost, string Iuser, string Ipassword, string localPath, string localFileName)
        {
            bool result = false;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Ihost + "/" + localPath + "/" + localFileName);
                string tmp = "ftp://" + Ihost + "/" + localPath + "/" + localFileName;
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                request.Credentials = new NetworkCredential(Iuser, Ipassword);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                if (response.StatusDescription.IndexOf("DELE command successful") >= 0)
                {
                    result = true;
                }
                response.Close();
                LogFile.writeLog(LogFile.DIR, "FTPRecived_" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, "FILE :" + localPath + "/" + localFileName + "(response.StatusDescription: " + response.StatusDescription + ")");
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SendFile_" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, "Không thể đồng bộ file: " + localFileName + " (Error: " + ex.Message + " )");
            }
            return result;
        }
        public static bool getFile(string Ihost, string Iuser, string Ipassword, string localPath, string localFileName, string pathfile, string SafeFileName)
        {
            bool result = false;
            try
            {
                string URL = "ftp://" + Ihost + "/" + localPath + "/" + localFileName;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(Iuser, Ipassword);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                string data = string.Empty;
                while (response.StatusCode != FtpStatusCode.ClosingData)
                {
                    data += sr.ReadToEnd();
                    System.Threading.Thread.Sleep(10);
                }

                if (SafeFileName.IndexOf('.') < 0)
                {
                    SafeFileName = SafeFileName.Remove(SafeFileName.LastIndexOf('.')) + response.ContentType;
                }
                LogFile.writeLog(LogFile.DIR, "FTPRecived_" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, "FILE :" + localPath + "/" + localFileName + "(response.StatusDescription: " + response.StatusDescription + ")");
                CheckExistDirandCreate(localPath);
                File.WriteAllText(pathfile + "/" + SafeFileName, data);
                data = null;
                sr.Dispose();
                responseStream.Dispose();
                response.Close();
                result = true;
            }
            catch { }
            return result;
        }
        public static bool getFileSpe(string Ihost, string Iuser, string Ipassword, string localPath, string localFileName, string pathfile, string SafeFileName)
        {
            bool result = false;
            WebClient request = new WebClient();
            string URL = "ftp://" + Ihost + "/" + localPath + "/" + localFileName;
            request.Credentials = new NetworkCredential(Iuser, Ipassword);

            try
            {
                byte[] Data = request.DownloadData(URL);
                File.WriteAllBytes(pathfile + "/" + SafeFileName, Data);
                Data = null;
                result = true;
            }
            catch (WebException e)
            {
                // Do something such as log error, but this is based on OP's original code
                // so for now we do nothing.
            }
            finally
            {
                request.Dispose();
            }
            return result;
        }
        public static bool getFile(string Ihost, string Iuser, string Ipassword, string localPath, string localFileName, ref byte[] Data)
        {
            bool result = false;
            WebClient request = new WebClient();
            string URL = "ftp://" + Ihost + "/" + localPath + "/" + localFileName;
            request.Credentials = new NetworkCredential(Iuser, Ipassword);

            try
            {
                Data = request.DownloadData(URL);
                result = true;
            }
            catch (WebException e)
            {
                // Do something such as log error, but this is based on OP's original code
                // so for now we do nothing.
            }
            return result;
        }
        public static List<string> getListFiles(string Ihost, string Iuser, string Ipassword, string localPath, string key)
        {
            List<string> result = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + Ihost + "/" + localPath + "/");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(Iuser, Ipassword);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(responseStream);
                string data = string.Empty;
                while ((data = sr.ReadLine()) != null)
                {
                    if (data.IndexOf("<DIR>") < 0)
                    {
                        string child = data.Substring(data.LastIndexOf(' ') + 1, data.Length - data.LastIndexOf(' ') - 1);
                        if (child.IndexOf(key) >= 0 || key == string.Empty)
                        {
                            if(!child.Equals(".") && !child.Equals(".."))
                            {
                                result.Add(child);
                            }
                        }
                    }
                }
                sr.Close();
                response.Close();
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public static bool deleteDirectory(string Ihost, string Iuser, string Ipassword, string directoryName)
        {
            bool result = false;
            try
            {
                /* Create an FTP Request */
                FtpWebRequest  ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + Ihost + "/" + directoryName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(Iuser, Ipassword);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                /* Establish Return Communication with the FTP Server */
                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        public static bool FtpDirectoryExists(string directoryPath, string ftpUser, string ftpPassword)
        {
            bool IsExists = true;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch
            {
                IsExists = false;
            }
            return IsExists;
        }
        public static void MakeFTPDir(string ftpAddress, string login, string password, string pathToCreate)
        {
            FtpWebRequest reqFTP = null;
            Stream ftpStream = null;

            string[] subDirs = pathToCreate.Split('/');

            string currentDir = string.Format("ftp://{0}", ftpAddress);

            for (int i = 0; i < subDirs.Length; i++)
            {
                try
                {
                    if (subDirs[i] == "") continue;
                    currentDir = currentDir + "/" + subDirs[i];
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Timeout = 200;
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(login, password);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch
                {
                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
        private static void CheckExistDirandCreate(string dir)
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        }
        public static bool isValidConnection(string url, string user, string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + url);
            try
            {

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, password);
                request.GetResponse();
            }
            catch
            {
                return false;
            }
            finally
            {
                request = null;
            }
            return true;
        }
    }
}
