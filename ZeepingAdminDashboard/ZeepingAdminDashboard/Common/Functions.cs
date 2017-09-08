using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeepingAdminDashboard.Common
{
    public class Functions
    {
        public static Color GenerateColor(string ColorCode)
        {
            int R = int.Parse(ColorCode.Substring(1,2), System.Globalization.NumberStyles.HexNumber);
            int G = int.Parse(ColorCode.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            int B = int.Parse(ColorCode.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(R, G, B);
        }
        public static string GetSafeFileName(string FileName)
        {
            string result = string.Empty;

            int LastIndexOf1 = FileName.LastIndexOf('/');
            int LastIndexOf2 = FileName.LastIndexOf('\\');
            int LastIndexOf = (LastIndexOf1 >= LastIndexOf2) ? LastIndexOf1 : LastIndexOf2;
            if(LastIndexOf > 0)
            {
                result = FileName.Remove(0, LastIndexOf + 1);
            }

            return result;
        }
        public static string GetExtension(string FileName)
        {
            string result = string.Empty;

            int LastIndexOf = FileName.LastIndexOf('.');
            if(LastIndexOf >= 0)
                result = FileName.Remove(0, LastIndexOf);

            return result;
        }
        public static string GetPathFileName(string FileName)
        {
            string result = string.Empty;

            int LastIndexOf1 = FileName.LastIndexOf('/');
            int LastIndexOf2 = FileName.LastIndexOf('\\');
            int LastIndexOf = (LastIndexOf1 >= LastIndexOf2) ? LastIndexOf1 : LastIndexOf2;
            if (LastIndexOf > 0)
            {
                result = FileName.Remove(LastIndexOf);
            }

            return result;
        }
        public static string getURLFile(string SafeFileName)
        {
            string result = string.Empty;
            result += AppConfig.PathImageURL + SafeFileName;
            return result;
        }
        public static void ShowMessgeError(string Message)
        {
            MessageBox.Show(Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowMessgeInfo(string Message)
        {
            MessageBox.Show(Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowYesNoQuestion(string Question)
        {
            return MessageBox.Show(Question, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void ShowMaiQuynhAnh()
        {
            if (Directory.Exists(Application.StartupPath + "/MaiQuynhAnh"))
            {
                string[] FileName = Directory.GetFiles(Application.StartupPath + "/MaiQuynhAnh");
                if(FileName.Length > 0)
                {
                    int index = 0;
                    Random rd = new Random();
                    index = rd.Next(0, FileName.Length - 1);
                    using (ShowImage show = new ShowImage(FileName[index], "Mai Quynh Anh ne"))
                    {
                        show.ShowDialog();
                    }
                }
                FileName = null;
            }
        }
        public static string GetMD5(string str)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }

            return sbHash.ToString();

        }
        public static string StringEndcoder(string input)
        {
            string result = string.Empty;

            result += "ps";

            for (int i = 0; i < input.Length; i++)
            {
                char tmp = input.Substring(i, 1).ToCharArray()[0];
                result += (char)((tmp * 3 - 50) / 2 + 128);
                result += (char)((tmp * 4 - 50) / 2 + 64);
                result += (char)((tmp >= 128) ? tmp - 128 : tmp + 128);
            }
            return result;
        }
        public static string StringDecoder(string input)
        {
            string result = string.Empty;

            for (int i = 0; i < (input.Length - 2) / 3; i++)
            {
                char tmp = input.Substring(2 + i * 3, 3).ToCharArray()[2];
                result += (char)((tmp >= 128) ? tmp - 128 : tmp + 128);
            }
            return result;
        }
        public static string StringtoUFT8String(string input)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                result += (char)(input[i] /256);
                result += (char)(input[i] & 0xFF);
            }

            return result;
        } 
        public static string UFT8StringtoString(string input)
        {
            string result = string.Empty;
            try
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    result += (char)((int)input[i] + (int)input[i + 1]);
                }
            }
            catch { }

            return result;
        }
        public static Image getImage(byte[] Data)
        {
            Image bm = null;
            try
            {
                using (MemoryStream ms = new MemoryStream(Data))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    bm = Image.FromStream(ms);
                }

                //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                //bm = (Image)converter.ConvertFrom(Data);

            }
            catch(Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "Exception" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }

            return bm;
        }
        public static string getValueinJoin(string json, string name)
        {
            string result = string.Empty;

            if(json.IndexOf(name + " :\"") > 0)
            {
                json = json.Substring(json.IndexOf(name + " :\"") + name.Length + 3);
                if(json.IndexOf("\",") > 0)
                {
                    result = json.Substring(0, json.IndexOf("\","));
                }
            }

            return result;
        }
        public static string getWebNameValid(string Str)
        {
            string result = string.Empty;

            if(Str != null)
            {
                result = Str.ToLower().Replace(' ', '-');
            }

            return result;
        }
        public static string getHashTagString(string str)
        {
            if (str == null)
                return string.Empty;
            while(str.IndexOf(",,") >= 0)
            {
                str = str.Replace(",,", ",");
            }
            return str.ToLower().Replace(" ", "");
        }
        public static bool getValidHashTagString(string str)
        {
            bool result = false;
            if (str == null || str == string.Empty) return true;
            result = Regex.IsMatch(str, @"^[a-z0-9]{1}[a-z0-9,]{1,}[a-z0-9]{1}$");
            return result;
        }

        public static List<int> GetList(string arraystring, char SplitChar)
        {
            List<int> result = new List<int>();

            foreach (string item in arraystring.Split(SplitChar))
            {
                result.Add(int.Parse(item));
            }

            return result;
        }
    }
}
