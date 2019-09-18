using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ObjectHelper;
using System.Data.SqlClient;
using CommonHelper;

namespace DataBaseHelper.DALClass
{
    public class EmployeeDALClass
    {
        #region Variables
        private const string GET_EMPNOTES_DETAILS = "SP_Get_EmployeeNotesDetails";
        private const string GET_EMPDRAWINGS_DETAILS = "SP_Get_EmployeeDrawingDetails";
        private const string GET_ALLCOMBOBOXVALUES = "SP_Get_EmpUserGroup_EmployeeName";
        private const string SAVE_EMPDRAWINGSORVARIABLE_DETAILS = "SP_Save_EmployeeDrawingDetails";
        private const string SAVE_EMPNOTES_DETAILS = "SP_Save_EmployeeNotesDetails";
        private const string GET_EMPVARIABLES_DETAILS = "SP_Get_EmployeeVariableDetails";
        private const string GET_EMP_DETAILS = "SP_Get_EmployeeDetails";
        private const string SAVE_EMPLIMITATIONS_DETAILS = "SP_Save_EmployeeLimitations";
        private const string SAVE_EMPLOYEEDETAILS = "SP_Save_EmployeeDetails";
        private const string SAVE_EMPLOYEESALARYDETAILS = "SP_Save_EmployeeSalaryDetails";
        private const string SPNAMEGETUSERNAMELIST = "SP_Get_UserNameListByOption";
        private const string SPNAMEGETLOGINDETAILS = "SP_Check_LoginUser";
        private const string SPNAMESAVEUSERLOGINTIME = "SP_Save_UserLoginTimeDetails";
        private const string SPNAMESAVEUSERLOGOUTTIME = "SP_Save_LogoutTimeDetails";
        private const string SPNAMEDELETEEMPNOTES = "Delete_EmployeeNotesDetail";
        private const string SPNAMEDELETEEMPLOYEES = "SP_Delete_Employees";
        private const string SPNameEmpRunTimeScreenLimt = "SP_Get_EmployeeRunTimeScreenLimitation";
        private const string SPNameGetWorkStationDetails = "SP_SAVE_WORKSTATION";
        //public static List<EmployeeObjectClass> objUsergrouptDAL=new List<EmployeeObjectClass>();
        //public static List<EmployeeObjectClass> objUserDAL = new List<EmployeeObjectClass>();
        public List<EmployeeObjectClass> EmpDetailListDal = new List<EmployeeObjectClass>();
        public List<EmployeeObjectClass> EmpDrawListDal = new List<EmployeeObjectClass>();
        public List<EmployeeObjectClass> EmpNotesListDal = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> EmpUserListByOption = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> ObjEmpVariableList = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> ObjeEmpLoginDetails = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> ObjScreenRightsLimit = new List<EmployeeObjectClass>();



        #endregion
        public List<EmployeeObjectClass> Get_EmpNotesDetailsAll()
        {
            try
            {
                var query = "SELECT ISNULL(alt.AlertID,0) AS AlertID, ISNULL(alt.UserId,0) AS UserId,ISNULL(Usr.FirstName,'') AS UserName, ISNULL(alt.AlertDate,'') AS AlertDate,ISNULL(alt.[Message],'') AS [Message], ISNULL(alt.MessageTo,0) AS [MessageTo], ISNULL(alt.NoOfTimes,0) AS NoOfTimes, ISNULL(alt.AlertLoginFlag,0) AS AlertLoginFlag, ISNULL(alt.OptionID, 0) AS OptionID,( select UserGroupID From [User] Where UserID=alt.UserID)  AS UserGroupID  FROM AlertUser alt JOIN dbo.[User] Usr ON alt.UserId=Usr.[UserId]";
                var result = SQLHelper.Instance.GetReader(query);
                EmpNotesListDal.Clear();
                while (result.Read())
                {
                    EmpNotesListDal.Add(new EmployeeObjectClass
                    {
                        AlertId = Convert.ToInt32(result["AlertID"]),
                        UserId = Convert.ToInt32(result["UserId"]),
                        FirstName = result["UserName"].ToString(),
                        //AlertDate = Convert.ToDateTime(result["AlertDate"].ToString()),
                        AlertDate = Convert.ToDateTime(result["AlertDate"]).Date,
                        Message = result["Message"].ToString(),
                        MessageTo = result["MessageTo"] == DBNull.Value ? string.Empty : result["MessageTo"].ToString(),
                        NoOfTimes = Convert.ToInt32(result["NoOfTimes"].ToString()),
                        AlertLoginFlag = Convert.ToInt32(result["AlertLoginFlag"].ToString()),
                        OptionID = Convert.ToInt32(result["OptionID"].ToString()),
                        UserGrpId = Convert.ToInt32(result["UserGroupID"])
                    });
                }
                return EmpNotesListDal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<EmployeeObjectClass> Get_EmpDrawingsDetailsAll()
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(GET_EMPDRAWINGS_DETAILS, sqlparam);
                EmpDrawListDal.Clear();
                while (result.Read())
                {
                    EmpDrawListDal.Add(new EmployeeObjectClass
                    {

                        EmployeeVariablesID = Convert.ToInt32(result["EmployeeVariablesID"]),
                        UserName = result["UserName"].ToString(),
                        VariableName = result["VariableName"].ToString(),
                        GroupName = result["GroupName"].ToString(),
                        EffectiveDate = result["EffectiveDate"] == DBNull.Value || result["EffectiveDate"].ToString() == "" ? DateTime.MinValue : Convert.ToDateTime(result["EffectiveDate"]).Date,
                        VariableAmount = Convert.ToDecimal(result["VariableAmount"].ToString()),
                        MonthlyDeduction = Convert.ToDecimal(result["MonthlyDeduction"].ToString()),
                        Remarks = result["Remarks"].ToString(),
                        Description = result["Description"].ToString(),
                        StartMonthDeduction = result["StartMonthDeduction"].ToString() == "" ? DateTime.Now : Convert.ToDateTime(result["StartMonthDeduction"])
                    });
                }
                return EmpDrawListDal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<EmployeeObjectClass> Get_EmpVariablesDetailsAll()
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(GET_EMPVARIABLES_DETAILS, sqlparam);
                ObjEmpVariableList.Clear();
                while (result.Read())
                {
                    ObjEmpVariableList.Add(new EmployeeObjectClass
                    {
                        EmployeeVariablesID = Convert.ToInt32(result["EmployeeVariablesID"]),
                        UserId = Convert.ToInt32(result["UserId"]),
                        UserName = result["UserName"].ToString(),
                        VariableName = result["VariabeName"].ToString(),
                        VariableID = Convert.ToInt32(result["VariableID"].ToString()),
                        GroupID = Convert.ToInt32(result["GroupID"].ToString()),
                        GroupName = result["GroupName"].ToString(),
                        EffectiveDate = result["EffectiveDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["EffectiveDate"]).Date,
                        VariableAmount = Convert.ToDecimal(result["VariableAmount"].ToString()),
                        MonthlyDeduction = Convert.ToDecimal(result["MonthlyDeduction"].ToString()),
                        Remarks = result["Remarks"].ToString(),
                        StartMonthDeduction = result["StartMonthDeduction"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["StartMonthDeduction"]).Date
                    });
                }
                return ObjEmpVariableList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<EmployeeObjectClass> Get_EmpDetailsAll()
        {
            try
            {
                //return SQLHelper.Instance.ExecuteWithoutQueryDatatable(GET_EMP_DETAILS);
                SqlParameter[] sqlparam = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(GET_EMP_DETAILS, sqlparam);
                string saltype = string.Empty;
                EmpDetailListDal.Clear();
                while (result.Read())
                {
                    if (result["CalcType"].ToString() == "0") saltype = "Monthly";
                    if (result["CalcType"].ToString() == "1") saltype = "Weekly";
                    if (result["CalcType"].ToString() == "2") saltype = "Hourly";
                    if (result["CalcType"].ToString() == "3") saltype = "Percentage";
                    EmpDetailListDal.Add(new EmployeeObjectClass
                    {
                        UserId = Convert.ToInt32(result["UserId"]),
                        FirstName = result["FirstName"].ToString(),
                        UserName = result["UserName"].ToString(),
                        Password = result["Password"].ToString(),
                        PwdReminder = result["PasswordReminder"].ToString(),
                        EmployeeUserFlag = Convert.ToInt32(result["EmployeeUserFlag"]),
                        PassportNo = result["PassportNo"].ToString(),
                        HealthCertificate = result["HealthCertificate"].ToString(),
                        SocialId = result["SocialID"].ToString(),
                        MobileNo = result["MobileNo"].ToString(),
                        PhoneNo = result["PhoneNo"].ToString(),
                        Designation = result["Designation"].ToString(),
                        //DateOfJoin = Convert.ToDateTime(result["DateOfJoin"].ToString()),//Commented on 31-May-2014 for DateFormat Issues
                        //StartWorkHours = Convert.ToDateTime(result["StartWorkHours"].ToString()),//Commented on 31-May-2014 for DateFormat Issues
                        //EndWorkHours = Convert.ToDateTime(result["EndWorkHours"].ToString()),//Commented on 31-May-2014 for DateFormat Issues
                        DateOfJoin = (result["DateOfJoin"].ToString() != "" ? Convert.ToDateTime(result["DateOfJoin"]) : DateTime.Now),
                        StartWorkHours = (result["StartWorkHours"].ToString() != "" ? Convert.ToDateTime(result["StartWorkHours"]) : DateTime.Now),
                        EndWorkHours = (result["EndWorkHours"].ToString() != "" ? Convert.ToDateTime(result["EndWorkHours"]) : DateTime.Now),
                        WeekEnd = Convert.ToInt16(result["WeekendDay"].ToString()),
                        UserGrpId = Convert.ToInt32(result["UserGroupID"]),
                        UserGroupName = result["UserGroupName"].ToString(),
                        //ScreenID = result["ScreenID"].ToString(),
                        SalaryIds = Convert.ToInt32(result["SalaryID"].ToString()),
                        SalaryType = saltype,
                        BasicSalary = Convert.ToDecimal(result["BasicSalary"].ToString()),
                        PercSales = Convert.ToDecimal(result["PercSales"].ToString()),
                        StartDate = Convert.ToDateTime(result["StartDate"].ToString()),
                        CalcType = Convert.ToInt16(result["CalcType"].ToString()),
                        OverTimeSal = Convert.ToDecimal(result["OvertimeSalary"]),
                        HolidaySal = Convert.ToDecimal(result["Holiday_Salary"].ToString()),
                        Status = Convert.ToInt32(result["Status"]),
                        ShowEndTime = Convert.ToBoolean(result["ShowEndTime"])
                    });
                    saltype = string.Empty;
                }
                return EmpDetailListDal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public Dictionary<string, List<EmployeeObjectClass>> Get_EmpComboBoxValuesAll()
        {
            Dictionary<string, List<EmployeeObjectClass>> dicUserLoad = new Dictionary<string, List<EmployeeObjectClass>>();
            List<EmployeeObjectClass> objUsergrouptDAL = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objUserDetailDAL = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objUsergroupcombobox = new List<EmployeeObjectClass>();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                //sqlparam[0]=null
                var result = SQLHelper.Instance.GetReader(GET_ALLCOMBOBOXVALUES, sqlparam);

                while (result.Read())
                {
                    objUsergrouptDAL.Add(new EmployeeObjectClass
                    {
                        UserGrpId = Convert.ToInt32(result["UserGroupID"])
                        ,
                        UserGroupName = result["UserGroupName"].ToString()
                        ,
                        ScreenID = Convert.ToInt32(result["ScreenID"])
                        ,
                        DefaultScreenID = result["DefaultScreenID"].ToString()
                        ,
                        Status = Convert.ToInt32(result["Status"])
                        ,
                        Flag = Convert.ToBoolean(result["Flag"])
                        // ,FirstName = result["FirstName"].ToString()
                        // ,LastName = result["LastName"].ToString()
                        //,UserId = Convert.ToInt32(result["UserId"])
                        //CompanyNo = result.GetOrdinal("CompanyID"),
                        //SupplierNo = result.GetOrdinal("AgentID"),
                        //ItemCost = result.GetOrdinal("ItemCost"),
                        //ItemLastCost = result.GetOrdinal("ItemLastCost"),
                        //ItemPackage = result.GetOrdinal("PackageQty"),
                        //ExpiryDate = Convert.ToBoolean(result.GetOrdinal("ExpiryDate")),
                        //Reorder = result.GetOrdinal("Reorder"),
                        //ItemWholeSalePrice = result.GetOrdinal("WholeSalePrice"),
                        //ItemPrice = result.GetOrdinal("Price"),
                        //MaxOrder = result.GetOrdinal("MaxOrder"),
                        //ItemMinimumPrice = result.GetOrdinal("MinPrice"),
                        //AvgCost = result.GetOrdinal("AverageCost"),
                        //CreatedBy = result.GetOrdinal("CreatedBy"),
                        //ModifiedBy = result.GetOrdinal("ModifiedBy"),
                        //Status = result.GetOrdinal("Status"),
                        //IsHide = Convert.ToBoolean(result.GetOrdinal("IsHide")),
                        //ItemExpiryDate = Convert.ToDateTime(result.GetOrdinal("ExpiryDate")),
                        //ItemTotalStock = result.GetOrdinal("StockInHand")
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    objUserDetailDAL.Add(new EmployeeObjectClass
                    {
                        FirstName = result["FirstName"].ToString()
                       ,
                        LastName = result["LastName"] == DBNull.Value ? string.Empty : result["LastName"].ToString()
                       ,
                        UserId = Convert.ToInt32(result["UserId"])
                        ,
                        UserGrpId = Convert.ToInt32(result["UserGroupID"])
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    String GroupName; int GroupID;
                    GroupID = Convert.ToInt32(result["UserGroupID"]);
                    GroupName = GeneralFunction.GroupTranslation(GroupID);
                    objUsergroupcombobox.Add(new EmployeeObjectClass
                    {
                        UserGrpId = Convert.ToInt32(result["UserGroupID"])
                       ,
                        UserGroupName = (GroupName == string.Empty ? result["UserGroupName"].ToString() : GroupName)
                    });
                }
                result.Close();
                dicUserLoad.Add("Usergroup", objUsergrouptDAL);
                dicUserLoad.Add("UserDetail", objUserDetailDAL);
                dicUserLoad.Add("ComboBoxUsergroup", objUsergroupcombobox);

                return dicUserLoad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public int FindMaxUserGroupIdDAL()
        {
            var query = "SELECT MAX(ISNULL(UserGroupID,0))+1 AS UserGroupID from dbo.UserGroup";
            return Convert.ToInt32((SQLHelper.Instance.GetScalar(query)));
        }


        public int SaveNotesDetails(EmployeeObjectClass ObjEmployeeClass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@AlertID", ObjEmployeeClass.AlertId);
                param[1] = new SqlParameter("@UserID", ObjEmployeeClass.EmpId);
                param[2] = new SqlParameter("@AlertDate", ObjEmployeeClass.NotesDate);
                param[3] = new SqlParameter("@Message", ObjEmployeeClass.Message);
                param[4] = new SqlParameter("@MessageTo", ObjEmployeeClass.MessageTo);
                param[5] = new SqlParameter("@NoOfTimes", ObjEmployeeClass.NoOfTimes);
                param[6] = new SqlParameter("@AlertLoginFlag", ObjEmployeeClass.AlertLoginFlag);
                param[7] = new SqlParameter("@OptionID", ObjEmployeeClass.Notescheckedtype);
                param[8] = new SqlParameter("@Status", ObjEmployeeClass.Status);
                param[9] = new SqlParameter("@CreatedBy ", ObjEmployeeClass.CreatedBy);
                param[10] = new SqlParameter("@ModifiedBy ", ObjEmployeeClass.ModifiedBy);
                param[11] = new SqlParameter("@Remove", ObjEmployeeClass.Remove);
                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_EMPNOTES_DETAILS, param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int SaveDrawingorVariable(EmployeeObjectClass ObjEmployeeClass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[17];
                param[0] = new SqlParameter("@EmployeeVariablesID", ObjEmployeeClass.EmployeeVariablesID);
                param[1] = new SqlParameter("@UserID", ObjEmployeeClass.EmpId);
                param[2] = new SqlParameter("@VariableID", ObjEmployeeClass.VariableID);
                param[3] = new SqlParameter("@GroupID", ObjEmployeeClass.GroupID);
                param[4] = new SqlParameter("@GroupName", ObjEmployeeClass.GroupName);
                param[5] = new SqlParameter("@EffectiveDate", ObjEmployeeClass.EffectiveDate);
                param[6] = new SqlParameter("@VariableAmount", ObjEmployeeClass.VariableAmount);
                param[7] = new SqlParameter("@MonthlyDeduction", ObjEmployeeClass.MonthlyDeduction);
                param[8] = new SqlParameter("@NoOfInstallment", ObjEmployeeClass.NoOfInstallment);
                if (ObjEmployeeClass.StartMonthDeduction == DateTime.MinValue)
                    param[9] = new SqlParameter("@StartMonthDeduction ", null);
                else
                    param[9] = new SqlParameter("@StartMonthDeduction ", ObjEmployeeClass.StartMonthDeduction);
                param[10] = new SqlParameter("@Remarks ", ObjEmployeeClass.Remarks);
                param[11] = new SqlParameter("@CreatedBy ", ObjEmployeeClass.CreatedBy);
                param[12] = new SqlParameter("@ModifiedBy ", ObjEmployeeClass.ModifiedBy);
                param[13] = new SqlParameter("@DrawingFlag ", ObjEmployeeClass.DrawingFlag);
                param[14] = new SqlParameter("@Description ", ObjEmployeeClass.Description);
                param[15] = new SqlParameter("@Status", ObjEmployeeClass.Status);
                param[16] = new SqlParameter("@Remove", ObjEmployeeClass.Remove);
                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_EMPDRAWINGSORVARIABLE_DETAILS, param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }

        }
        public List<EmployeeObjectClass> Get_UserNameListByOptionID(EmployeeObjectClass ObjEmployeeClass)
        {
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[2];
                Sqlparam[0] = new SqlParameter("@OptionID", ObjEmployeeClass.Notescheckedtype);
                Sqlparam[1] = new SqlParameter("@UserGroupID", ObjEmployeeClass.UserGrpId);
                var result = SQLHelper.Instance.GetReader(SPNAMEGETUSERNAMELIST, Sqlparam);
                EmpUserListByOption.Clear();
                while (result.Read())
                {
                    EmpUserListByOption.Add(new EmployeeObjectClass
                    {
                        UserGrpId = Convert.ToInt32(result["UserGroupID"])
                       ,
                        UserId = Convert.ToInt32(result["UserId"].ToString())
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return EmpUserListByOption;

        }
        public bool SaveEmployeeDetails(EmployeeObjectClass ObjEmployeeClass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@UserID", ObjEmployeeClass.UserId);
                param[1] = new SqlParameter("@FirstName", ObjEmployeeClass.EmpName);
                param[2] = new SqlParameter("@UserName", ObjEmployeeClass.UserName);
                param[3] = new SqlParameter("@UserGroupID", ObjEmployeeClass.UserGrpId);
                param[4] = new SqlParameter("@EmployeeUserFlag", ObjEmployeeClass.EmployeeUserFlag);
                param[5] = new SqlParameter("@PassportNo", ObjEmployeeClass.PassportNo);
                param[6] = new SqlParameter("@SocialID", ObjEmployeeClass.SocialId);
                param[7] = new SqlParameter("@HealthCertificate", ObjEmployeeClass.HealthCertificate);
                param[8] = new SqlParameter("@MobileNo", ObjEmployeeClass.MobileNo);
                param[9] = new SqlParameter("@PhoneNo", ObjEmployeeClass.PhoneNo);
                param[10] = new SqlParameter("@Designation", ObjEmployeeClass.Designation);
                param[11] = new SqlParameter("@CreatedBy ", ObjEmployeeClass.CreatedBy);
                param[12] = new SqlParameter("@ModifiedBy ", ObjEmployeeClass.ModifiedBy);
                param[13] = new SqlParameter("@DateOfJoin", ObjEmployeeClass.DateOfJoin);
                param[14] = new SqlParameter("@StartWorkHours ", ObjEmployeeClass.StartWorkHour);
                param[15] = new SqlParameter("@Status", ObjEmployeeClass.Status);
                param[16] = new SqlParameter("@Remove", ObjEmployeeClass.Remove);
                param[17] = new SqlParameter("@EndWorkHours", ObjEmployeeClass.EndWorkHour);
                param[18] = new SqlParameter("@WeekendDay", ObjEmployeeClass.WeekEnd);
                param[19] = new SqlParameter("@Password", ObjEmployeeClass.Password);
                param[20] = new SqlParameter("@PasswordReminder", ObjEmployeeClass.PwdReminder);
                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_EMPLOYEEDETAILS, param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }

        }
        public bool SaveEmployeeSalaryDetails(EmployeeObjectClass ObjEmployeeClass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[14];

                sqlparam[0] = new SqlParameter("@SalaryID", ObjEmployeeClass.SalaryId);
                sqlparam[1] = new SqlParameter("@UserID", ObjEmployeeClass.EmpId);
                sqlparam[2] = new SqlParameter("@BasicSalary", ObjEmployeeClass.BasicSalary);
                sqlparam[3] = new SqlParameter("@PercSales", ObjEmployeeClass.PercSales);
                sqlparam[4] = new SqlParameter("@StartDate", ObjEmployeeClass.DateOfJoin);
                sqlparam[5] = new SqlParameter("@CalcType", ObjEmployeeClass.CalcType);
                sqlparam[6] = new SqlParameter("@CreatedBy", ObjEmployeeClass.CreatedBy);
                sqlparam[7] = new SqlParameter("@ModifiedBy", ObjEmployeeClass.ModifiedBy);
                sqlparam[8] = new SqlParameter("@Status", ObjEmployeeClass.Status);
                sqlparam[9] = new SqlParameter("@Remove", ObjEmployeeClass.Remove);
                sqlparam[10] = new SqlParameter("@UserName", ObjEmployeeClass.EmpName);
                sqlparam[11] = new SqlParameter("@OverTimeSalary", ObjEmployeeClass.OverTimeSal);
                sqlparam[12] = new SqlParameter("@HolidaySalary", ObjEmployeeClass.HolidaySal);
                sqlparam[13] = new SqlParameter("@ShowEndTime", ObjEmployeeClass.ShowEndTime);
                //sqlparam[13] = new SqlParameter("@MTB_USER_LOGIN_NAME", Obj_EmpProp.UserName);

                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_EMPLOYEESALARYDETAILS, sqlparam) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int CheckUserhasActioninInvoice(EmployeeObjectClass objEmp)
        {
            int result = -1;
            try
            {
                var query = "SELECT COUNT(*) from dbo.UserTracking where UserId=" + objEmp.UserId + "" + " and " + "IsInvoiceAction=" + objEmp.InvoiceAction + "";
                SqlDataReader sqldr = SQLHelper.Instance.GetReader(query);
                if (sqldr.Read())
                {
                    result = Convert.ToInt16(sqldr[0].ToString());
                }
                //SqlParameter[] Sqlparam = new SqlParameter[2];
                //Sqlparam[0] = new SqlParameter("@UserId", objLogin.UserId);
                //Sqlparam[1] = new SqlParameter("@Password", objLogin.LoginPassword);
                //var result = SQLHelper.Instance.GetReader(SPNAMEGETLOGINDETAILS, Sqlparam);
                //while (result.Read())
                //{
                //    ObjeEmpLoginDetails.Add(new EmployeeObjectClass
                //    {
                //        Notes = result["Message"].ToString()
                //        ,
                //        NotesDate = Convert.ToDateTime((result["ALERTDATE"] == DBNull.Value ? null : result["ALERTDATE"]))
                //    });
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return result;
        }
        public int SaveEmployeeDetailsLimitation(List<EmployeeObjectClass> EmpObject)
        {
            object usergroupid = 0;

            //using (SQLHelper.Instance.conn)
            //{
            if (SQLHelper.Instance.conn.State == ConnectionState.Closed)
                SQLHelper.Instance.conn.Open();
            SqlCommand command = SQLHelper.Instance.conn.CreateCommand();
            SqlTransaction transaction;
            transaction = SQLHelper.Instance.conn.BeginTransaction();
            command.Connection = SQLHelper.Instance.conn;
            command.Transaction = transaction;
            try
            {
                command.CommandText = SAVE_EMPLIMITATIONS_DETAILS;
                command.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < EmpObject.Count; i++)
                {
                    command.Parameters.Add("@UserGroupID", EmpObject[i].UserGrpId);
                    command.Parameters.Add("@UserGroupName", EmpObject[i].UserGroupName);
                    command.Parameters.Add("@ScreenID", EmpObject[i].ScreenID);
                    command.Parameters.Add("@Status", 1);
                    command.Parameters.Add("@Remove", 0);
                    command.Parameters.Add("@UserId", EmpObject[i].UserId);
                    command.Parameters.Add("@Flag", EmpObject[i].Flag);
                    usergroupid = command.ExecuteScalar();
                    command.Parameters.Clear();
                }
                int result = 0;
                var query = "SELECT COUNT(*) from dbo.[OptionDetails] where UserGroupID=" + EmpObject[0].UserGrpId + "";
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Transaction = transaction;
                SqlDataReader sqldr = command.ExecuteReader(); //SQLHelper.Instance.GetReaderCommandText(query); // Remove the Transaction for this Query. 
                
                if (sqldr.Read())
                {
                    
                    result = Convert.ToInt16(sqldr[0].ToString());
                }
                sqldr.Close();
                if (Convert.ToInt16(result) == 0)
                {
                    command.CommandText = "Usp_Save_DefaultOptionSettings";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserGroupID", EmpObject[0].UserGrpId);
                    command.Parameters.Add("@UserID", EmpObject[0].UserId);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return Convert.ToInt32(usergroupid);
            // }

        }
        public List<EmployeeObjectClass> Get_EmployeeRunTimeScreenLimt(EmployeeObjectClass Obj_EmpProp)
        {
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[2];
                Sqlparam[0] = new SqlParameter("@UserID", Obj_EmpProp.UserId);
                Sqlparam[1] = new SqlParameter("@FirstName", Obj_EmpProp.UserName);
                var result = SQLHelper.Instance.GetReader(SPNameEmpRunTimeScreenLimt, Sqlparam);
                ObjScreenRightsLimit.Clear();
                while (result.Read())
                {
                    ObjScreenRightsLimit.Add(new EmployeeObjectClass
                    {
                        UserId = result["UserId"] == null ? 0 : Convert.ToInt32(result["UserId"].ToString()),
                        FirstName = result["FirstName"] == null ? string.Empty : result["FirstName"].ToString(),
                        ScreenID = result["ScreenID"] == null ? 0 : Convert.ToInt32(result["ScreenID"].ToString()),
                        Flag = Convert.ToBoolean(result["Flag"].ToString()),
                        //  ScreenName = result["ScreenName"].ToString()

                    });
                }
                return ObjScreenRightsLimit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<EmployeeObjectClass> Check_UserLoginDAL(EmployeeObjectClass objLogin)
        {
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[2];
                Sqlparam[0] = new SqlParameter("@UserName", objLogin.LoginUserName);
                Sqlparam[1] = new SqlParameter("@Password", objLogin.LoginPassword);
                var result = SQLHelper.Instance.GetReader(SPNAMEGETLOGINDETAILS, Sqlparam);
                while (result.Read())
                {
                    ObjeEmpLoginDetails.Add(new EmployeeObjectClass
                    {
                        Notes = result["Message"].ToString()
                        ,
                        NotesDate = Convert.ToDateTime((result["ALERTDATE"] == DBNull.Value ? null : result["ALERTDATE"]))
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ObjeEmpLoginDetails;
        }
        public int Save_UserLoginTimeDetails(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[9];
                Sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                Sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                Sqlparam[2] = new SqlParameter("@UserLogin", objempclass.TimeStart);
                Sqlparam[3] = new SqlParameter("@Latency", objempclass.DayofLatency);
                Sqlparam[4] = new SqlParameter("@OverTime", objempclass.DayofOverTime);
                Sqlparam[5] = new SqlParameter("@Flag", objempclass.WeekEndDayFlag);
                Sqlparam[6] = new SqlParameter("@WorkStation", (objempclass.Workstation == null) ? 0 : objempclass.Workstation);
                Sqlparam[7] = new SqlParameter("@Status", 1);
                Sqlparam[8] = new SqlParameter("@WorkStationName", GeneralFunction.workstationName);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEUSERLOGINTIME, Sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex) { throw ex; }
        }
        public int Save_UserLogoutTimeDetails(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[3];
                Sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                Sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                Sqlparam[2] = new SqlParameter("@UserLogout", objempclass.TimeEnd);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEUSERLOGOUTTIME, Sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex) { throw ex; }
        }
        public int DeleteEmpParticulars(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[2];
                Sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                Sqlparam[1] = new SqlParameter("@OptionID", objempclass.OptionID);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMEDELETEEMPNOTES, Sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }
        public int Delete_EmployeeFormList(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[2];
                Sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                Sqlparam[1] = new SqlParameter("@CreatedBy", objempclass.CreatedBy);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMEDELETEEMPLOYEES, Sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }



        /// <summary>
        /// Include this method on 07/01/2014
        /// </summary>
        /// <param name="Obj_Employee"></param>
        /// <returns></returns>
        public List<EmployeeObjectClass> GetRemember_Password(EmployeeObjectClass Obj_Employee)
        {
            try
            {

                SqlParameter[] Sqlparam = new SqlParameter[1];
                Sqlparam[0] = new SqlParameter("@UserName", Obj_Employee.UserName);
                object result = SQLHelper.Instance.GetScalar("SP_Get_UserReminderDetails", Sqlparam);
                Obj_Employee.PwdReminder = result == null ? string.Empty : result.ToString();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ObjeEmpLoginDetails;

        }
        public List<EmployeeObjectClass> GetUsrTrackingActiontDAL(EmployeeObjectClass Obj_Employee)
        {
            List<EmployeeObjectClass> objUsrTrackList = new List<EmployeeObjectClass>();
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[5];
                Sqlparam[0] = new SqlParameter("@UserID", Obj_Employee.UserId);
                Sqlparam[1] = new SqlParameter("@FromDate", Obj_Employee.FromDate);
                Sqlparam[2] = new SqlParameter("@ToDate", Obj_Employee.ToDate);
                Sqlparam[3] = new SqlParameter("@ActionType", Obj_Employee.ActionType);
                Sqlparam[4] = new SqlParameter("@Flag", Obj_Employee.Flag);
                var result = SQLHelper.Instance.GetReader("SP_Get_UserTracking_ActionsList", Sqlparam);
                while (result.Read())
                {
                    objUsrTrackList.Add(new EmployeeObjectClass
                    {
                        Sno = Convert.ToInt32(result["SNo"]),
                        UserId = Convert.ToInt32(result["UId"]),
                        UserName = result["UName"].ToString(),
                        PerformedOn = result["PerformedOn"].ToString(),
                        Action = result["Action"].ToString(),
                        TableName = result["TableName"].ToString(),
                        Date = result["Date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["Date"]).Date,
                        strTime = result["Time"] == DBNull.Value ? DateTime.MinValue.ToString("hh:mm:ss") : Convert.ToDateTime(result["Time"]).ToString("hh:mm:ss"),
                        //  Time = result["Time"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["Time"]),
                        ActionType = Convert.ToInt32(result["Actiontype"]),
                        ActionArabic = result["ActionArabic"].ToString(),
                        strDate = result["Date"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["Date"]).ToString().Split()[1]
                    });
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return objUsrTrackList;
        }
        public DataTable Get_WorkStation()
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetWorkStationDetails, param, "LoginDetails");

                return dtLocal;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
    }
}

