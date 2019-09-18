using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ObjectHelper;
using System.Data.SqlClient;

namespace DataBaseHelper.DALClass
{
    public class SalaryPaymentDAL
    {
        #region Variables
        private const string SPNameGetSalaryDetailList_PayType_Percentage = "SP_Get_SalaryDetailList__PayType_Percentage";
        private const string SPNameSavePaySalaryDetail = "SP_Save_SalaryPaymentDetails";
        private const string SPNameUndoSalaryPaymentDetail = "SP_Undo_SalaryPayment";
        private const string SPNameSaveEmployeeVariablesDetails = "SP_Undo_SalaryPaymentVariableAmount";
        private const string SPNameSaveEmployeeDrawingDetails = "SP_Undo_SalaryPaymentDrawingAmount";
        #endregion
        public Dictionary<string, List<EmployeeObjectClass>> Get_SalaryDetailsList(EmployeeObjectClass ObjEmployeeClass)
        {
            Dictionary<string, List<EmployeeObjectClass>> dicSalary = new Dictionary<string, List<EmployeeObjectClass>>();
            List<EmployeeObjectClass> objEmpBasicdetails = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objEmpVariabledetails = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objEmpSalDetails = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objEmpWeekOffDetails = new List<EmployeeObjectClass>();
            List<EmployeeObjectClass> objEmpPercentDetails = new List<EmployeeObjectClass>();
            objEmpBasicdetails.Clear();
            objEmpVariabledetails.Clear();
            objEmpSalDetails.Clear();
            objEmpWeekOffDetails.Clear();
            objEmpPercentDetails.Clear();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FromDate", ObjEmployeeClass.FromDate);
                param[1] = new SqlParameter("@ToDate", ObjEmployeeClass.ToDate);
                //param[0] = new SqlParameter("@FromDate", Convert.ToDateTime("2013-12-01 15:02:01.557"));
                //param[1] = new SqlParameter("@ToDate", Convert.ToDateTime("2013-12-31 15:02:01.557"));
                var result = SQLHelper.Instance.GetReader(SPNameGetSalaryDetailList_PayType_Percentage, param);
               // var result = SQLHelper.Instance.GetReader(SPNameGetSalaryDetailList_PayType_Percentage, param);

                while (result.Read())
                {
                    objEmpBasicdetails.Add(new EmployeeObjectClass
                    {
                        UserId = Convert.ToInt32(result["UserId"])
                        ,
                        FirstName = result["FirstName"].ToString()
                        ,
                        BasicSalary = (result["BasicSalary"] != DBNull.Value && result["BasicSalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["BasicSalary"].ToString()) : Convert.ToDecimal(0)
                        ,
                        PercSales = (result["PercSales"] != DBNull.Value && result["PercSales"].ToString() != string.Empty) ? Convert.ToDecimal(result["PercSales"].ToString()) : Convert.ToDecimal(0)
                        ,
                        CalcType = Convert.ToInt32(result["CalcType"])
                        ,
                        OverTimeSal = (result["OverTimeSalary"] != DBNull.Value && result["OverTimeSalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["OverTimeSalary"].ToString()) : Convert.ToDecimal(0)
                        ,
                        HolidaySal = (result["HolidaySalary"] != DBNull.Value && result["HolidaySalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["HolidaySalary"].ToString()) : Convert.ToDecimal(0)

                      //  EmployeeVariablesID = (result["EmployeeVariablesID"] != DBNull.Value && result["EmployeeVariablesID"].ToString() != string.Empty) ? Convert.ToInt32(result["EmployeeVariablesID"].ToString()) : -1
                        ,DrawAmt=(result["DRAWING_AMT"]!=DBNull.Value && result["DRAWING_AMT"].ToString()!=string.Empty)? Convert.ToDecimal(result["DRAWING_AMT"].ToString()):Convert.ToDecimal(0)
                        ,
                        StartMonthDeduction = result["START_MONTH_DEDUCT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["START_MONTH_DEDUCT"].ToString())
                        ,TotalSales=(result["TOTAL_SALES"] != DBNull.Value && result["TOTAL_SALES"].ToString() != string.Empty) ? Convert.ToDecimal(result["TOTAL_SALES"].ToString()) : Convert.ToDecimal(0)
                        ,
                        EmpWorkHrs = result["EMPWorkHRS"].ToString()
                        ,FromDate= result["FromDate"] == DBNull.Value?DateTime.MinValue:Convert.ToDateTime(result["FromDate"].ToString())
                        ,ToDate=result["ToDate"] == DBNull.Value?DateTime.MinValue:Convert.ToDateTime(result["ToDate"].ToString())
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    objEmpVariabledetails.Add(new EmployeeObjectClass
                    {
                        EmployeeVariablesID=Convert.ToInt32(result["EmployeeVariablesID"])
                        ,VariableID=Convert.ToInt32(result["VariableID"])
                        ,UserId = Convert.ToInt32(result["UserId"])
                       ,VariableName = result["VariableName"].ToString()
                       ,VariableAmount=(result["VariableAmount"]!=DBNull.Value && result["VariableAmount"].ToString()!=string.Empty)? Convert.ToDecimal(result["VariableAmount"].ToString()):Convert.ToDecimal(0)
                       ,MonthlyDeduction=(result["MonthlyDeduction"]!=DBNull.Value && result["MonthlyDeduction"].ToString()!=string.Empty)? Convert.ToDecimal(result["MonthlyDeduction"].ToString()):Convert.ToDecimal(0)
                       ,GroupID=Convert.ToInt32(result["GroupID"])
                       ,
                        GroupName = (result["GroupName"] != DBNull.Value && result["GroupName"].ToString() != string.Empty) ? result["GroupName"].ToString() : string.Empty
                       ,StartMonthDeduction = result["StartMonthDeduction"] != DBNull.Value?DateTime.MinValue:Convert.ToDateTime(result["StartMonthDeduction"].ToString())
                        ,Remarks=(result["Remarks"] != DBNull.Value && result["Remarks"].ToString() != string.Empty) ? result["Remarks"].ToString() : string.Empty
                        ,CalcType = Convert.ToInt32(result["CalcType"])
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    objEmpSalDetails.Add(new EmployeeObjectClass
                    {
                       UserId = Convert.ToInt32(result["UserId"])
                       ,BasicSalary = (result["BasicSalary"] != DBNull.Value && result["BasicSalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["BasicSalary"].ToString()) : Convert.ToDecimal(0)
                       ,PercSales = (result["PercSales"] != DBNull.Value && result["PercSales"].ToString() != string.Empty) ? Convert.ToDecimal(result["PercSales"].ToString()) : Convert.ToDecimal(0)
                       ,StartDate = result["StartDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["StartDate"].ToString())
                       ,CalcType = Convert.ToInt32(result["CalcType"])
                       ,OverTimeSal = (result["OverTimeSalary"] != DBNull.Value && result["OverTimeSalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["OverTimeSalary"].ToString()) : Convert.ToDecimal(0)
                       ,HolidaySal = (result["HolidaySalary"] != DBNull.Value && result["HolidaySalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["HolidaySalary"].ToString()) : Convert.ToDecimal(0)
                       ,WorkingDays=Convert.ToInt32(result["WORKINGDAYS"])
                       ,WorkedDays = Convert.ToInt32(result["EMPWORKDAYS"])
                       ,WorkTimings = result["WORKTIMINGS"].ToString()
                       ,
                       OverTimings = result["OVERTIMINGS"].ToString()
                       ,
                       HolidayTimings = result["HOLIDAYTIMINGS"].ToString()
                       ,
                       LatencyHours = result["LATENCYHOURS"].ToString()
                       ,
                       LatencyMin = result["LATENCYMINUTE"].ToString()
                       ,
                       DayofOverTime = result["DAYOFOVERTIME"].ToString()
                      ,SalaryForPerDay = (result["SalaryForPerDay"] != DBNull.Value && result["SalaryForPerDay"].ToString() != string.Empty) ? Convert.ToDecimal(result["SalaryForPerDay"].ToString()) : Convert.ToDecimal(0)
                      ,SalaryForPercent = (result["SalaryForPercent"] != DBNull.Value && result["SalaryForPercent"].ToString() != string.Empty) ? Convert.ToDecimal(result["SalaryForPercent"].ToString()) : Convert.ToDecimal(0)
                      ,SalaryForPerHour = (result["SalaryForPerHour"] != DBNull.Value && result["SalaryForPerHour"].ToString() != string.Empty) ? Convert.ToDecimal(result["SalaryForPerHour"].ToString()) : Convert.ToDecimal(0)
                      ,SalaryForWeek = (result["SalaryForWeek"] != DBNull.Value && result["SalaryForWeek"].ToString() != string.Empty) ? Convert.ToDecimal(result["SalaryForWeek"].ToString()) : Convert.ToDecimal(0)
                       
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    objEmpWeekOffDetails.Add(new EmployeeObjectClass
                    {
                         UserId = Convert.ToInt32(result["UserId"])
                        
                        ,FirstName = result["FirstName"].ToString()
                        ,
                         WeekEnd =Convert.ToInt32(result["WeekendDay"])
                        
                         ,MonthDays=Convert.ToInt32(result["WeekendDay"])
                        ,
                         Suncount = Convert.ToInt32(result["SUNDAY"])
                        ,
                         Moncount = Convert.ToInt32(result["MONDAY"])
                        ,
                         Tuescount = Convert.ToInt32(result["TUESDAY"])
                       ,
                         Wedcount = Convert.ToInt32(result["WEDNESDAY"])
                       ,
                         Thurscount = Convert.ToInt32(result["THURSDAY"])
                       ,
                         Fricount = Convert.ToInt32(result["FRIDAY"])
                       ,
                         Satcount = Convert.ToInt32(result["SATURDAY"])
                         ,
                         CalcType = Convert.ToInt32(result["CalcType"])
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    objEmpWeekOffDetails.Add(new EmployeeObjectClass
                    {
                        UserId = Convert.ToInt32(result["UserId"])

                        ,
                        UserName = result["UserName"].ToString()
                        ,
                        SaleId = Convert.ToInt32(result["TotalSale"])
                        ,
                        Netamount = Convert.ToInt32(result["TotalAmount"])
                        ,
                        PercSales = (result["PercentSale"] != DBNull.Value && result["PercentSale"].ToString() != string.Empty) ? Convert.ToDecimal(result["PercentSale"].ToString()) : Convert.ToDecimal(0)

                       ,
                        BasicSalary = (result["BaseSalary"] != DBNull.Value && result["BaseSalary"].ToString() != string.Empty) ? Convert.ToDecimal(result["BaseSalary"].ToString()) : Convert.ToDecimal(0)
                       ,
                        CalcType = Convert.ToInt32(result["PayType"])
                    });
                }
                result.Close();
                dicSalary.Add("EmpBasicdetails", objEmpBasicdetails);
                dicSalary.Add("EmpVariabledetails", objEmpVariabledetails);
                dicSalary.Add("EmpSalDetails", objEmpSalDetails);
                dicSalary.Add("EmpWeekOffDetails", objEmpWeekOffDetails);
                dicSalary.Add("EmpPercentDetails", objEmpPercentDetails);
                return dicSalary;
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

        public int Undo_SalaryPaymentDetails(EmployeeObjectClass ObjEmployeeClass)
        {
            int i;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserID", ObjEmployeeClass.UserId);
                i = SQLHelper.Instance.ExecuteNonQuery(SPNameUndoSalaryPaymentDetail, param);
                return i;
            }
            catch (Exception ex) { throw ex; }
        }

        public int Save_PaySalaryDetails(EmployeeObjectClass ObjempProp)
        {
            int i;
            try
            {
                SqlParameter[] param = new SqlParameter[14];
                param[0] = new SqlParameter("@SalaryId", ObjempProp.SalaryId);
                param[1] = new SqlParameter("@UserID", ObjempProp.UserId);
                param[2] = new SqlParameter("@SalaryTotalAmount", ObjempProp.TotalAmount);
                param[3] = new SqlParameter("@PunishmentAmountMT", ObjempProp.VariableAmount);
                param[4] = new SqlParameter("@DrawingAmount", ObjempProp.DrawAmt);
                param[5] = new SqlParameter("@LatencyAmount", ObjempProp.LatencyAmt);
                param[6] = new SqlParameter("@AbsenceAmount", ObjempProp.AmountAbsence);
                param[7] = new SqlParameter("@PaidNetAmount", ObjempProp.NetSalary);
                param[8] = new SqlParameter("@PaidDate", ObjempProp.PaidDate);
                param[9] = new SqlParameter("@FromDate", ObjempProp.FromDate);
                param[10] = new SqlParameter("@ToDate",  ObjempProp.ToDate);
                param[11] = new SqlParameter("@CreatedDate", ObjempProp.CreatedDate);
                param[12] = new SqlParameter("@CreatedBy", ObjempProp.CreatedBy);
                param[13] = new SqlParameter("@Status", ObjempProp.Status);
                i=SQLHelper.Instance.ExecuteNonQuery(SPNameSavePaySalaryDetail, param);
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }
        public int Save_EmployeeVariableDetails(EmployeeObjectClass Obj_empProp)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[16];
                sqlparam[0] = new SqlParameter("@EmpVarID", Obj_empProp.EmployeeVariablesID);
                sqlparam[1] = new SqlParameter("@UserID", Obj_empProp.UserId);
                sqlparam[2] = new SqlParameter("@VariableID", Obj_empProp.VariableID);
                sqlparam[3] = new SqlParameter("@GroupID", Obj_empProp.GroupID);
                sqlparam[4] = new SqlParameter("@GroupName", Obj_empProp.GroupName);
                sqlparam[5] = new SqlParameter("@EffectiveDate", Obj_empProp.EffectiveDate);
                sqlparam[6] = new SqlParameter("@VariableAmount", Obj_empProp.VariableAmount);
                sqlparam[7] = new SqlParameter("@MonthlyDeduction", Obj_empProp.MonthlyDeduction);
                sqlparam[8] = new SqlParameter("@StartMonthDeduction", Obj_empProp.StartMonthDeduction);
                sqlparam[9] = new SqlParameter("@Remarks", Obj_empProp.Remarks);
                sqlparam[10] = new SqlParameter("@CreatedBy", Obj_empProp.CreatedBy);
                sqlparam[11] = new SqlParameter("@ModifiedBy", Obj_empProp.ModifiedBy);
                sqlparam[12] = new SqlParameter("@DrawingFlag", Obj_empProp.DrawingFlag);
                sqlparam[13] = new SqlParameter("@Description", "Variable");
                sqlparam[14] = new SqlParameter("@Status", Obj_empProp.Status);
                sqlparam[15] = new SqlParameter("@Remove", Obj_empProp.Remove);
                if ((i = SQLHelper.Instance.ExecuteNonQuery(SPNameSaveEmployeeVariablesDetails, sqlparam)) > 0)
                { return i; }
                else
                {
                    return i;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public int Save_EmployeeDrawingDetails(EmployeeObjectClass Obj_empProp)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[17];
                sqlparam[0] = new SqlParameter("@UserID", Obj_empProp.UserId);
                sqlparam[1] = new SqlParameter("@EmpVarID", Obj_empProp.EmployeeVariablesID);
                sqlparam[2] = new SqlParameter("@VariableID", 101);
                sqlparam[3] = new SqlParameter("@GroupID", 0);
                sqlparam[4] = new SqlParameter("@GroupName", Obj_empProp.Description);
                sqlparam[5] = new SqlParameter("@EffectiveDate", Obj_empProp.EffectiveDate);
                sqlparam[6] = new SqlParameter("@VariableAmount", Obj_empProp.DrawAmt);
                sqlparam[7] = new SqlParameter("@MonthlyAmount", Obj_empProp.MonthlyDeduction);
                sqlparam[8] = new SqlParameter("@NoOfInstallment", Obj_empProp.NoOfInstallment);
                sqlparam[9] = new SqlParameter("@StartMonthDeduction", Obj_empProp.StartMonthDeduction);
                sqlparam[10] = new SqlParameter("@Remarks", Obj_empProp.Remarks);
                sqlparam[11] = new SqlParameter("@CreatedBy", Obj_empProp.CreatedBy);
                sqlparam[12] = new SqlParameter("@ModifiedBy", Obj_empProp.ModifiedBy);
                sqlparam[13] = new SqlParameter("@DrawingFlag", 1);
                sqlparam[14] = new SqlParameter("@Description", Obj_empProp.Description);
                sqlparam[15] = new SqlParameter("@Status", Obj_empProp.Status);
                sqlparam[16] = new SqlParameter("@Remove", Obj_empProp.Remove);
                if ((i = SQLHelper.Instance.ExecuteNonQuery(SPNameSaveEmployeeDrawingDetails, sqlparam)) > 0)
                { return i; }
                else
                {
                    return i;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
