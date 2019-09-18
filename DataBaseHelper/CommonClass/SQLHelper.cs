using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CommonHelper;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Threading;



namespace DataBaseHelper
{
    public class SQLHelper
    {
        SqlConnection con;
        public readonly SqlConnection conn;
        static SQLHelper objSqlHelper;
        //private SqlConnection sqlcon;
        private string _connectionString;
        public string ConnectionString { get; set; }
        //SqlDataReader sqldr

        #region  -- Constructor --

        public SQLHelper()
        {
            //conn = new SqlConnection(this.ConnectionString = this.ConnectionString ?? ConfigurationSettings.AppSettings["BumedianConnectionString"]);
            System.Collections.Specialized.NameValueCollection _values = ConfigurationSettings.AppSettings;
            string _connectionstring = string.Format("server={0};database={1};uid={2};pwd={3};MultipleActiveResultSets=True;", _values["Server"], _values["Database"], _values["UserId"], _values["Password"]);
            conn = new SqlConnection(_connectionstring);
            InitialObject();
        }
        public void InitialObject()
        {
            GeneralFunction._server = ConfigurationSettings.AppSettings["Server"].ToString();
            GeneralFunction._database = ConfigurationSettings.AppSettings["Database"].ToString();
            GeneralFunction._UserId = ConfigurationSettings.AppSettings["UserId"].ToString();
            GeneralFunction._password = GeneralFunction.Decrypt(ConfigurationSettings.AppSettings["Password"].ToString());
        }

        public static SQLHelper Instance
        {
            get { return objSqlHelper ?? (objSqlHelper = new SQLHelper()); }
        }
        //-------------
        //public static SQLHelper 
        //{
        //    get { return objSqlHelper ?? (objSqlHelper = new SQLHelper()); }
        //}


        #endregion

        #region -- Get Methods --

        public DataSet GetExecuteDataSet(string commandText, params string[] tableNames)
        {
            try
            {
                return GetExecuteDataSet(commandText, null, tableNames);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet GetExecuteDataSet(string procName, SqlParameter[] param, params string[] tableNames)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    sqlCmd.CommandType = CommandType.Text;
                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                    {
                        if (tableNames.Length > 0) da.TableMappings.AddRange(tableNames);
                        da.Fill(ds);

                    }

                }
                return ds;
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }


        }
        public T GetExecuteType<T>(string commandText, params SqlParameter[] param) where T : class
        {
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(commandText, conn))
                {
                    if (OpenConnection())
                    {
                        sqlCmd.CommandType = CommandType.Text;
                        if (param.Length > 0)
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                            sqlCmd.Parameters.Insert(0, new SqlParameter("@option", typeof(T) is System.Collections.Generic.IList<T> ? default(T).ToString() : typeof(T).Name));
                        }
                    }
                    return GenericSerializer<T>.DeSerialize(sqlCmd.ExecuteXmlReader());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }


        public T GetExecuteType<T>(params SqlParameter[] param) where T : class
        {
            try
            {
                return GetExecuteType<T>("Sp_Check_Agent_ID", param);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region -- DML Methods --

        public object GetScalar(string procName, SqlParameter[] param)
        {
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        if (param != null)
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                        }
                        //  sqlCmd.CommandText
                    }
                    return sqlCmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }

        public object GetScalarQuery(string procName, SqlParameter[] param)
        {
            try
            {
                // if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        if (param.Length > 0)
                        {
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    return sqlCmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }

        public object GetScalar(string commandText)
        {
            // SqlTransaction sqltrans = conn.BeginTransaction(); ;
            object result = -1;
            try
            {

                result = GetScalar(commandText, null);
                // sqltrans.Commit();

            }
            catch (Exception)
            {
                // sqltrans.Rollback();
            }
            return result;
        }
        //public int GetScalar(SqlParameter[] param,string procedure )
        //{
        //    try
        //    {
        //        if (conn.State != ConnectionState.Open) conn.Open();
        //        using (SqlCommand sqlCmd = new SqlCommand(procedure, conn))
        //        {
        //            if (param != null)
        //            {
        //                sqlCmd.CommandType = CommandType.StoredProcedure;
        //                sqlCmd.Parameters.AddRange(param);
        //            }
        //            return (int)sqlCmd.ExecuteScalar();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn.State != ConnectionState.Closed) conn.Close();
        //    }
        //}
        public SqlDataReader GetReader(string procName, SqlParameter[] param)
        {
            try
            {
                //Ritujeet
                //using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", conn))
                //{
                //    comm.ExecuteNonQuery();
                //}

                //if (conn.State != ConnectionState.Open) conn.Open();
                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        if (param != null)
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    sqlCmd.CommandTimeout = 0;
                    return sqlCmd.ExecuteReader();

                }
            }
            catch
            {
                string str;
                if (ConfigurationSettings.AppSettings["Language"] == "Arabic")
                    str = "هذه مشكلة متعلقة بقاعدة البيانات التي لم أتمكن من ربطها بالخادم تأكد أن القاعدة البيانات موجودة و صحيحة";
                else
                    str = "Server Disconnected";
                throw new ApplicationException(str);
            }
        }

        //public Dictionary<int,string> Reader(string procName, SqlParameter[] param)
        //{
        //    int Id; string Name;

        //    try
        //    {

        //        Dictionary<int, string> objlist = new Dictionary<int, string>();
        //        //List<KeyValuePair<int, string>> objlist = new List<KeyValuePair<int, string>>();
        //       // List<string> objlist = new List<string>();
        //        if (conn.State != ConnectionState.Open) conn.Open();
        //        using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
        //        {
        //            if (param != null)
        //            {
        //                sqlCmd.CommandType = CommandType.StoredProcedure;
        //                sqlCmd.Parameters.AddRange(param);
        //            }


        //            // return  sqlCmd.ExecuteReader();
        //            SqlDataReader read = sqlCmd.ExecuteReader();
        //            while (read.Read())
        //            {
        //               // objlist.Add(KeyValuePair<SqlDataReader
        //                Id=Convert.ToInt32((read[0].ToString()));
        //                Name=(read[1].ToString());
        //               // GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierName=read[1].ToString(),SupplierNo=Convert.ToInt16(read[0])});
        //                //foreach (string item in read)
        //                //{
        //                //    obj.Add(item);
        //                //}
        //                objlist.Add(Id,Name);

        //            }

        //        }
        //        return objlist;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn.State != ConnectionState.Closed) conn.Close();
        //    }
        //}


        public SqlDataReader GetReader(string commandText)
        {
            try
            {
                return GetReader(commandText, null);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public SqlDataReader GetDataReader(string commandtext, SqlParameter[] param)
        {
            try
            {
                
                using (SqlCommand sqlCmd = new SqlCommand(commandtext, conn))
                {
                    if (OpenConnection())
                    {
                        if (param != null)
                        {
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    sqlCmd.CommandTimeout = 0;
                    return sqlCmd.ExecuteReader();

                }
            }
            catch
            {
                string str;
                if (ConfigurationSettings.AppSettings["Language"] == "Arabic")
                    str = "هذه مشكلة متعلقة بقاعدة البيانات التي لم أتمكن من ربطها بالخادم تأكد أن القاعدة البيانات موجودة و صحيحة";
                else
                    str = "Server Disconnected";
                throw new ApplicationException(str);
            }
        }

        public SqlDataReader GetReaderCommandText(string commandText)
        {
            try
            {
                return GetDataReader(commandText, null);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public SqlDataReader GetReaderwithTransaction(string commandText, SqlTransaction trans)
        {
            try
            {
                return GetReader(commandText, null, trans);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader GetReader(string procName, SqlParameter[] param, SqlTransaction trans)
        {
            try
            {

                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(procName, conn, trans))
                {
                    if (OpenConnection())
                    {
                        if (param != null)
                        {
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    return sqlCmd.ExecuteReader();

                }
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
            //finally
            //{
            //    if (conn.State != ConnectionState.Closed) conn.Close();
            //}
        }

        public SqlDataReader GetReaderWithQuery(string commandText, SqlParameter[] Param)
        {
            try
            {

                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(commandText, conn))
                {
                    if (OpenConnection())
                    {
                        if (Param.Length != 0)
                        {

                            sqlCmd.Parameters.AddRange(Param);
                        }
                    }
                    return sqlCmd.ExecuteReader();

                }
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
        }


        public int ExecuteNonQuery<T>(T obj) where T : class
        {
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand("BBM_PROC_DML_ROUTER", conn))
                {
                    if (OpenConnection())
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(new SqlParameter[2]
                            {
                                new SqlParameter("@option",obj.ToString()),
                                new SqlParameter("@xmlData",System.Text.ASCIIEncoding.Default.GetString(GenericSerializer<T>.Serialize(obj)))
                            });
                    }
                    return sqlCmd.ExecuteNonQuery();
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }
        public void conopen()
        {
            System.Collections.Specialized.NameValueCollection _values = ConfigurationSettings.AppSettings;
            string _connectionstring = string.Format("server={0};database={1};uid={2};pwd={3};", _values["Server"], _values["Database"], _values["UserId"], _values["Password"]);
            con = new SqlConnection(_connectionstring);
            con.Open();
        }
        public int ExecuteQuerey(string str)
        {

            SqlCommand sqlCmd = new SqlCommand(str, con);
            return sqlCmd.ExecuteNonQuery();
        }
        public void close()
        {
            con.Close();
        }


        public DataTable ExecuteQueryDatatabledata(string procName, params SqlParameter[] param)
        {
            try
            {

                conopen();
                SqlCommand sqlCmd = new SqlCommand(procName, con);


                //  sqlCmd.CommandType = CommandType.StoredProcedure;
                //  sqlCmd.Parameters.AddRange(param);

                //  sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                //dt.Load(sqlCmd.ExecuteReader());
                //return dt;

                sqlCmd.CommandText = procName;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = con;
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlCmd;
                sqlda.SelectCommand.CommandTimeout = 1800;
                if (param != null && param.Length > 0)
                {
                    sqlda.SelectCommand.Parameters.AddRange(param);
                }
                sqlda.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
        }
        public int ExecuteScalar(string procName, params SqlParameter[] param)
        {
            try
            {


                SqlCommand sqlCmd = new SqlCommand(procName, con);


                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddRange(param);

                return Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
        }

        public int ExecuteNon(string procName, params SqlParameter[] param)
        {
            try
            {


                SqlCommand sqlCmd = new SqlCommand(procName, con);


                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddRange(param);



                return sqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }

        }
        public int ExecuteNonQuery(string procName, params SqlParameter[] param)
        {
            try
            {
                //if (conn.State != ConnectionState.Open) SQLHelper.Instance.conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        if (param != null)
                        {
                            if (procName == "SP_CleanDB")
                            {
                                sqlCmd.CommandTimeout = 0;
                            }

                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }

        public int ExecuteNonQueryWithParameter(string procName, params SqlParameter[] param)
        {
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
                {
                    if (OpenConnection())
                    {
                        if (param.Length > 0)
                        {
                            sqlCmd.CommandType = CommandType.Text;
                            sqlCmd.Parameters.AddRange(param);
                        }
                    }
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }

        public DataTable ExecuteQueryDatatable(string procedurename, SqlParameter[] sqlparam, string tablename)
        {
            SqlDataAdapter sqlda;
            SqlCommand sqlcmd;
            DataTable dt = new DataTable(tablename);
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();
                if (OpenConnection())
                {
                    sqlcmd = new SqlCommand();
                    sqlcmd.CommandText = procedurename;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Connection = conn;
                    sqlda = new SqlDataAdapter();
                    sqlda.SelectCommand = sqlcmd;
                    sqlda.SelectCommand.CommandTimeout = 1800;
                    if (sqlparam != null && sqlparam.Length > 0)
                    {
                        sqlda.SelectCommand.Parameters.AddRange(sqlparam);
                    }
                    sqlda.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;

            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();

            }
        }
        public DataTable ExecuteDatatableWithQuery(string queryname, SqlParameter[] sqlparam, string tablename)
        {
            try
            {
                DataTable datatable = new DataTable(tablename);
                //if (conn.State != ConnectionState.Open) conn.Open();
                if (OpenConnection())
                {
                    SqlCommand sqlcommand = new SqlCommand(queryname, conn);

                    SqlDataAdapter sqldatadapater = new SqlDataAdapter();
                    sqlcommand.CommandType = CommandType.Text;
                    sqldatadapater.SelectCommand = sqlcommand;
                    if (sqlparam.Length > 0)
                    {
                        sqlcommand.Parameters.AddRange(sqlparam);
                    }

                    sqldatadapater.Fill(datatable);
                }
                return datatable;
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }

        public DataSet ExecuteQueryDataset(string procedurename, SqlParameter[] sqlparam, string tablename)
        {
            SqlDataAdapter sqlda;
            SqlCommand sqlcmd;
            DataSet ds = new DataSet(tablename);
            try
            {
                //if (conn.State != ConnectionState.Open) conn.Open();
                if (OpenConnection())
                {
                    sqlcmd = new SqlCommand();
                    sqlcmd.CommandText = procedurename;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Connection = conn;
                    sqlda = new SqlDataAdapter();
                    sqlda.SelectCommand = sqlcmd;
                    sqlda.SelectCommand.CommandTimeout = 1800;
                    if (sqlparam.Length > 0)
                    {
                        sqlda.SelectCommand.Parameters.AddRange(sqlparam);
                    }

                    sqlda.Fill(ds);
                }
                return ds;

            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }
        }
        public DataSet ExecuteWithoutQueryDatatable(string Procedure)
        {
            try
            {
                DataSet ds = new DataSet();

                SqlDataAdapter sqldatadapater = new SqlDataAdapter();
                if (OpenConnection())
                {
                    SqlCommand sqlcommand = new SqlCommand(Procedure, conn);



                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqldatadapater.SelectCommand = sqlcommand;
                    //if (Paramters.Length > 0)                                               
                    //{
                    //    sqlcommand.Parameters.AddRange(Paramters);
                    //}
                    //OpenConnection();
                    sqldatadapater.Fill(ds);

                }
                return ds;
            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }


            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
            }

        }

        public bool OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                return true;
            }
            catch (Exception ex)
            {

                GeneralFunction.Information("serverisdisconnected", ActionType.DBConnection.ToString());
                return false;
            }
        }


        #endregion
        public SqlConnectionStringBuilder ReportConnectionString()
        {

            SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder(conn.ConnectionString);

            return ConnectionBuilder;


        }

        public List<string> GetActiveServers()
        {
            List<string> list = new List<string>();
            DataTable dtServers = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            if (dtServers != null && dtServers.Rows.Count > 0)
            {
                foreach (DataRow oRow in dtServers.Rows)
                {
                    string item = string.Empty;
                    if (oRow["InstanceName"].ToString() == string.Empty) item = oRow["ServerName"].ToString();
                    else item = oRow["ServerName"].ToString() + "\\" + oRow["InstanceName"].ToString();
                    if (!list.Contains(item)) list.Add(item);
                }
            }
            return list;
        }

        public List<string> GetServerDatabases(string server, string UserId, string password)
        {
            List<string> list = new List<string>();
            using (SqlConnection con = new SqlConnection(string.Format("Server = {0}; Database = {1}; User ID = {2}; Password = {3}", server, "master", UserId, password)))
            {
                DataTable dtDatabases = null;
                try
                {
                    con.Open();
                    dtDatabases = con.GetSchema("Databases");
                }
                catch (SqlException ex)
                {
                    GeneralFunction.ErrInfo(ex.Message, GeneralFunction.ChangeLanguageforCustomMsg("DBConnection"));
                }
                finally
                {
                    con.Close();
                }
                if (dtDatabases != null && dtDatabases.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDatabases.Rows)
                    {
                        list.Add(row["database_name"].ToString());
                    }
                }
            }

            return list;
        }

        public bool CheckActiveConnection(string server, string UserId, string password)
        {
            bool check = false;

            using (SqlConnection con = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};Connection Timeout=30;", server, "master", UserId, password)))
            {
                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        check = true;
                    }
                }
                catch
                {
                    //  GeneralFunction.ErrInfo(ex.Message, GeneralFunction.ChangeLanguageforCustomMsg("DBConnection"));
                }
                finally
                {
                    con.Close();
                }

            }
            return check;
        }

        public DataTable UserQuery_ExecuteCustomQueryFlyringQuery(string queryText)
        {
            DataTable dt = new DataTable();
            try
            {
                System.Collections.Specialized.NameValueCollection _values = ConfigurationSettings.AppSettings;
                string _connectionstring = string.Format("server={0};database={1};uid={2};pwd={3};MultipleActiveResultSets=True;", _values["Server"], _values["Database"], _values["UserId"], _values["Password"]);
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {

                    SqlDataAdapter adpt = new SqlDataAdapter(queryText, conn);
                    adpt.Fill(dt);
                }
            }
            catch
            {


            }
            return dt;
        }

        public DataTable ExecuteQueryDatatabledataWithFunction(string procName, params SqlParameter[] param)
        {
            try
            {

                conopen();
                SqlCommand sqlCmd = new SqlCommand(procName, con);


                //  sqlCmd.CommandType = CommandType.StoredProcedure;
                //  sqlCmd.Parameters.AddRange(param);

                //  sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                //dt.Load(sqlCmd.ExecuteReader());
                //return dt;

                sqlCmd.CommandText = procName;
                sqlCmd.Connection = con;
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlCmd;
                sqlda.SelectCommand.CommandTimeout = 1800;
                if (param != null && param.Length > 0)
                {
                    sqlda.SelectCommand.Parameters.AddRange(param);
                }
                sqlda.Fill(dt);

                return dt;

            }
            catch (Exception ex)
            {
                string str;
                if (ex.ToString().Contains("A transport-level error has occurred when sending the request to the server. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.)"))
                {
                    GeneralFunction.Information("ServerDisconnected", ActionType.DBConnection.ToString());
                    str = GeneralFunction.ChangeLanguageforCustomMsg("ServerDisconnected");
                    throw new ApplicationException(str);
                }
                else
                    throw ex;
            }
        }

    }

}
