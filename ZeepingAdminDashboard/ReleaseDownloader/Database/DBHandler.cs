using MySql.Data.MySqlClient;
using ReleaseDownloader.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseDownloader.Database
{
    public class DBHandler
    {
        public static string GetDBConnectionString(string host, int port, string database, string username, string password)
        {
            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";convert zero datetime=True";
            return connString;
        }
        public static bool CheckConnetion(string ConnectionString)
        {
            bool result = false;

            MySqlConnection conn = new MySqlConnection(ConnectionString);

            try
            {
                conn.Open();
                result = true;
            }
            catch { }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return result;
        }
        public static bool CheckConnetion(ref MySqlConnection conn)
        {
            bool result = false;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    result = true;
                }
                catch { }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else result = true;

            return result;
        }
        public static bool SQLcommandExecute(ref MySqlConnection conn, string cmd)
        {
            bool result = false;

            MySqlCommand scmd = new MySqlCommand(cmd, conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                scmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static DataTable selectDataBase(ref MySqlConnection conn, string TableName, string getObjects, string Condition, string Others = "")
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = string.Empty;
                cmd = "select " + getObjects + " " +
                      "from " + TableName + " " +
                      ((Condition == "") ? "" : " where ") + Condition + " " +
                      Others;
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = conn;
                Scmd.CommandText = cmd;
                MySqlDataAdapter Sda = new MySqlDataAdapter(Scmd);
                Sda.Fill(dt);
                Scmd.Dispose();
                Sda.Dispose();
            }
            catch (Exception ex)
            {
                dt = null;
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return dt;
        }
        public static bool insertDataBase(ref MySqlConnection conn, string TableName, string colunmNameString, string colunmValueString)
        {
            bool result = false;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = string.Empty;
                cmd = "INSERT INTO " + TableName + " " +
                      colunmNameString +
                      " VALUES " + colunmValueString;
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = conn;
                Scmd.CommandText = cmd;
                if (Scmd.ExecuteNonQuery() > 0) result = true;
                Scmd.Dispose();
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static bool updateDataBase(ref MySqlConnection conn, string TableName, string set, string where)
        {
            bool result = false;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = string.Empty;
                cmd += "UPDATE " + TableName + " " +
                       "SET " + set + " " +
                       "WHERE " + where;
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = conn;
                Scmd.CommandText = cmd;
                if (Scmd.ExecuteNonQuery() > 0) result = true;
                Scmd.Dispose();
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static bool deleteDataBase(ref MySqlConnection conn, string TableName, string where)
        {
            bool result = false;
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = string.Empty;
                cmd = "DELETE FROM " + TableName + " " +
                      "WHERE " + where;
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = conn;
                Scmd.CommandText = cmd;
                if (Scmd.ExecuteNonQuery() > 0) result = true;
                Scmd.Dispose();
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static Guid getNewGuid(ref MySqlConnection conn)
        {
            Guid result = new Guid();
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string cmd = string.Empty;
                cmd = "select uuid()";
                MySqlCommand Scmd = new MySqlCommand();
                Scmd.Connection = conn;
                Scmd.CommandText = cmd;
                MySqlDataAdapter Sda = new MySqlDataAdapter(Scmd);
                Sda.Fill(dt);
                result = (Guid)dt.Rows[0].ItemArray[0];
                dt.Dispose();
                Scmd.Dispose();
                Sda.Dispose();
            }
            catch (Exception ex)
            {
                LogFile.writeLog(LogFile.DIR, "SQLException" + LogFile.getTimeStringNow() + ".txt", LogFile.Filemode.GHIDE, ex.Message);
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
