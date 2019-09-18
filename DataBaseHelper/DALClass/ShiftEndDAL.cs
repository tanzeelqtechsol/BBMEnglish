using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseHelper.DALClass
{
    public class ShiftEndDAL
    {


        public DataTable GetUserData(string endTime)
        {
            DataTable dt = new DataTable();
            //SqlParameter[] sqlParam = new SqlParameter[2];
            //sqlParam[0] = new SqlParameter("@Username", GeneralFunction.LoginUserName);
            //sqlParam[1] = new SqlParameter("@LoginTime", GeneralFunction.UserLoginTime);
            //dt = SQLHelper.Instance.ExecuteQueryDatatabledata("GetShiftData", sqlParam);
            //return dt;
            dt.Columns.Add("TotalSale");
            dt.Columns.Add("TotalReceived");
            dt.Columns.Add("TotalPaid");
            dt.Columns.Add("NetCash");
            dt.Columns.Add("TotalSaleCard");
            dt.Columns.Add("TotalSaleCheck");

            //  try
            //  {
            TimeSpan TsTo = new TimeSpan(GeneralFunction.UserLoginTime.Hour, GeneralFunction.UserLoginTime.Minute, GeneralFunction.UserLoginTime.Second);
            string[] Login = GeneralFunction.UserLoginTime.Date.ToString().Split(' ');
            string LoginTime = "";
            if (Login.Length > 2)
            {
                LoginTime = Login[1] + " " + TsTo.ToString();
            }
            else
            {
                LoginTime = GeneralFunction.UserLoginTime.Date.ToString() + TsTo.ToString();
            }
            SqlParameter[] sqlParam = new SqlParameter[4];
            int value = 1;
            sqlParam[0] = new SqlParameter("@FromDate", LoginTime);
            if (string.IsNullOrEmpty(endTime))
            {
                //TimeSpan TsTo1 = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                //string[] curr_time = DateTime.Now.Date.ToString().Split(' ');
                //string CurrentTime = "";
                //if (curr_time.Length > 2)
                //{
                //    CurrentTime = curr_time[1] + " " + TsTo1.ToString();
                //}
                //else
                //{
                //    CurrentTime = DateTime.Now.Date.ToString() + TsTo1.ToString();
                //}
                //sqlParam[1] = new SqlParameter("@ToDate", CurrentTime);
                sqlParam[1] = new SqlParameter("@ToDate", "");
            }
            else
            {
                DateTime EndTime = Convert.ToDateTime(endTime);
                TimeSpan TsTo2 = new TimeSpan(EndTime.Hour, EndTime.Minute, EndTime.Second);
                string[] curr_time2 = EndTime.Date.ToString().Split(' ');
                string CurrentTime2 = "";
                if (curr_time2.Length > 1)
                {
                    if (string.IsNullOrEmpty(curr_time2[1]))
                    {
                        CurrentTime2 = EndTime.Date.ToString() + TsTo2.ToString();
                    }
                    else
                    {
                        CurrentTime2 = curr_time2[1] + " " + TsTo2.ToString();
                    }
                }
                else
                {
                    CurrentTime2 = EndTime.Date.ToString() + TsTo2.ToString();
                }
                sqlParam[1] = new SqlParameter("@ToDate", CurrentTime2);
            }
            sqlParam[2] = new SqlParameter("@Option", value);
            sqlParam[3] = new SqlParameter("@UserID", GeneralFunction.UserId);
            var ReaderResult = SQLHelper.Instance.GetReader("Sp_Get_EndOfShiftDetails", sqlParam); //Sp_Get_EndOfDayDetails
            while (ReaderResult.Read())
            {
                //  lstEndOfDayDetails.Add(new EndofTheDayObject
                //  {
                // UserId = ReaderResult["UserId"] != DBNull.Value ? Convert.ToInt16(ReaderResult["UserId"]) : 0,
                // UserName = ReaderResult["UserName"] != DBNull.Value ? Convert.ToString(ReaderResult["UserName"]) : string.Empty,
                string TotalSale = ReaderResult["TotalSale"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSale"]).ToString("#########0.000") : "0.000";
                //TotalSaleReturn = ReaderResult["TotalSaleReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleReturn"]).ToString("#########0.000") : "0.000",
                //TotalPurchase = ReaderResult["TotalPurchase"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchase"]).ToString("#########0.000") : "0.000",
                // TotalPurchaseReturn = ReaderResult["TotalPurchaseReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchaseReturn"]).ToString("#########0.000") : "0.000",
                string Expenses = ReaderResult["Expenses"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Expenses"]).ToString("#########0.000") : "0.000";

                //  TotalSpoiled = ReaderResult["Spoiled"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Spoiled"]).ToString("#########0.000") : "0.000",
                string TotalPaid = ReaderResult["Paid"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Paid"]).ToString("#########0.000") : "0.000";
                string TotalReceived = ReaderResult["Received"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Received"]).ToString("#########0.000") : "0.000";

                // TotalRented =ReaderResult["Rents"] != null ? Convert.ToDecimal(ReaderResult["Rents"]):0,
                string TotalNetCash = (decimal.Parse(TotalReceived) - (decimal.Parse(TotalPaid) + decimal.Parse(Expenses))).ToString();

                // TotalSpending = ReaderResult["Spending"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Spending"]).ToString("#########0.000") : "0.000",

                // });

                string TotalSaleCard = ReaderResult["TotalSaleCard"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleCard"]).ToString("#########0.000") : "0.000";

                string TotalSaleCash = ReaderResult["TotalSaleCheck"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleCheck"]).ToString("#########0.000") : "0.000";

                string TotalReceive = ReaderResult["TotalReceived"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalReceived"]).ToString("#########0.000") : "0.000";


                dt.Rows.Add(TotalSale, TotalReceive, TotalPaid, TotalNetCash, TotalSaleCard, TotalSaleCash);
            }

            ReaderResult.NextResult();

            while (ReaderResult.Read())
            {
                // lstEndOfDayTotals.Add(new EndofTheDayObject
                // {
                // string TotalSale = ReaderResult["TotalSale"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSale"]).ToString("#########0.000") : "0.000";
                // TotalPurchase = ReaderResult["TotalPurchase"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchase"]).ToString("#########0.000") : "0.000",
                // string Expenses = ReaderResult["Expenses"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Expenses"]).ToString("#########0.000") : "0.000";
                // TotalCost = ReaderResult["TotalCost"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalCost"]).ToString("#########0.000") : "0.000",
                //string TotalReceived = ReaderResult["TotalReceived"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalReceived"]).ToString("#########0.000") : "0.000";
                //string TotalPaid = ReaderResult["TotalPaid"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPaid"]).ToString("#########0.000") : "0.000";
                // decimal netcash = decimal.Parse(TotalReceived) - (decimal.Parse(TotalPaid) + decimal.Parse(Expenses));
                // dt.Rows.Add(TotalSale, TotalReceived, TotalPaid,netcash.ToString());    
                //TotalSaleReturn = ReaderResult["TotalSaleReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleReturn"]).ToString("#########0.000") : "0.000",
                // TotalPurchaseReturn = ReaderResult["TotalPurchaseReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchaseReturn"]).ToString("#########0.000") : "0.000",
                // TotalSpoiled = ReaderResult["TotalSpoiled"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSpoiled"]).ToString("#########0.000") : "0.000",
                // TotalProfit = ReaderResult["TotalProfit"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalProfit"]).ToString("#########0.000") : "0.000",
                // TotalCharges = ReaderResult["PaymentCharges"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["PaymentCharges"]).ToString("#########0.000") : "0.000",
                //TotalNetCash = (decimal.Parse(ReaderResult["TotalReceived"].ToString()) - (decimal.Parse(ReaderResult["TotalPaid"].ToString()) + decimal.Parse(ReaderResult["Expenses"].ToString()))).ToString()

                //TotalSpending = ReaderResult["TotalSpending"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSpending"]).ToString("#########0.000") : "0.000",
                // });

            }
            //ReaderResult.NextResult();
            //while (ReaderResult.Read())
            //{

            //    Balance = Convert.ToDecimal(ReaderResult["Amount"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Amount"]).ToString("#########0.000") : "0.000");

            //}
            //ReaderResult.NextResult();
            //while (ReaderResult.Read())
            //{
            //    Drawing = Convert.ToDecimal(ReaderResult["Drawing"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Drawing"]).ToString("#########0.000") : "0.000");
            //}
            ReaderResult.Close();
            //dicEndOfDayDetails.Add("EndOfDayDetails", lstEndOfDayDetails);
            //dicEndOfDayDetails.Add("EndOfDayTotals", lstEndOfDayTotals);

            //return dicEndOfDayDetails;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //   // Close();
            //}
            return dt;
        }


        public DataTable Get_ReportValues()
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_TimeAttendenceList", sqlparam, "Attendancelist");
                return (dtLocal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtLocal;
        }

        public string[] Set_LoginTime()
        {


            string[] HoursWorked = new string[2];
            try
            {

                if (GeneralFunction.UserId != 0)
                {
                    DataTable dt = new DataTable();
                    SqlParameter[] GetLoginTime = new SqlParameter[1];
                    GetLoginTime[0] = new SqlParameter("@UserID", GeneralFunction.UserId);
                    // DateTime LoginTime = Convert.ToDateTime((SQLHelper.Instance.GetScalarQuery("select max(UserLogin) as LoginTime from WorkTimeAttendance where UserID = @UserID", GetLoginTime)));
                    // string SPNameGetLoginDetails = "select Top 1 UserLogin,TotalHours from WorkTimeAttendance where UserID = @UserID order by UserLogin desc";
                    dt = SQLHelper.Instance.ExecuteQueryDatatable("GetUserLogin", GetLoginTime, "[UserDet]");
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["UserLogin"].ToString()))
                        {
                            GeneralFunction.UserLoginTime = Convert.ToDateTime(dt.Rows[0]["UserLogin"]);
                            if (dt.Rows[0]["TotalHours"] != null)
                            {
                                HoursWorked[0] = dt.Rows[0]["TotalHours"].ToString();
                            }
                            else
                            {
                                HoursWorked[0] = "";
                            }
                            if (dt.Rows[0]["TimeEnd"] != null)
                            {
                                string CheckNull = HoursWorked[1] = dt.Rows[0]["TimeEnd"].ToString();
                                if (!string.IsNullOrEmpty(CheckNull))
                                {
                                    DateTime TE = Convert.ToDateTime(dt.Rows[0]["TimeEnd"]);
                                    TimeSpan TsTo = new TimeSpan(TE.Hour, TE.Minute, 59);
                                    string[] LogTime = TE.Date.ToString().Split(' ');
                                    string LoginTime = "";
                                    if (LogTime.Length > 2)
                                    {
                                        LoginTime = LogTime[1] + " " + TsTo.ToString();
                                    }
                                    else
                                    {
                                        LoginTime = TE.Date.ToString() + TsTo.ToString();
                                    }
                                    HoursWorked[1] = LoginTime;
                                }
                            }
                            else
                            {
                                HoursWorked[1] = "";
                            }
                            //GeneralFunction.UserLoginTime = LoginTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return HoursWorked;

        }
    }
}
