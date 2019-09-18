using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace BBM_LicensceGenerator
{
    /// <summary>
    /// This Class will help to connect the BBM database and run the SP_DataMigration Stored procedure for copy the Old database data into New Database
    /// </summary>
    class SQLHelper
    {
        public readonly SqlConnection conn;
        private string _connectionString;
        public string ConnectionString { get; set; }


        public SQLHelper(String ServerName, String DatabaseName, String UserID, String UsrPasswor)
        {
            _connectionString = string.Format("server={0};database={1};uid={2};pwd={3};", ServerName, DatabaseName, UserID, UsrPasswor);
             conn = new SqlConnection(_connectionString);
            
        }


        // This function will help to connect the BBM database and run the SP_DataMigration Stored procedure
        public String GetReader(string procName, SqlParameter SqlPara)
        {
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();
                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        
                        sqlCmd.CommandTimeout = 0;
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add(SqlPara);
                        sqlCmd.ExecuteNonQuery();
                      string result = sqlCmd.Parameters["@ErrorReason"].Value.ToString();
                      return result;
                       // return "DATA MIGRATED SUCCESSFULLY";
                    }
                    else
                    {
                        return "Connection Failed. Please check Server name and login credential";
                    }
                 
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }


        public bool OpenConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains ("Cannot open database"))
                {
                    MessageBox.Show("Please run the New database (BBM) script in the server machine", "Database Missing");
                }
                else
                {
                    MessageBox.Show("The server is disconnected! please check the network connection", "Connection Warning");
                }
                return false;
            }
        }
    }
}
