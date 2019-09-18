using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class EndOfDayDAL
    {
        #region Constant Variables
        private const string SpGetEndOfDayDetails = "Sp_Get_EndOfDayDetails";
        private const string spGetEndOfTheDayTotalRecord = "SpReportEndOftheDayTotalRecord";
        private const string spGetEndOfTheDayMovementRecord = "Sp_Get_EndOfTheReportMovemenetInformation";
        private const string spGetZakatCalculation = "Sp_Get_EndOfTheReportZakatInformation";
        private const string spGetCashInformation = "Sp_Get_EndOfTheReportCashInformation";
        private const string spGetEndOftheDayTotalCash = "Sp_Get_EndOfDayDetailsTotalCash";
        private const string spGetEndOftheDayPurchaseInformation = "Sp_Get_EndOfTheReportPurchaseInformation";
        private const string spGetEndOftheDaySaleInformation = "Sp_Get_EndOfTheReportSalesInformation";
        private const string spGetEndOftheDayNetIncomeInformation = "SP_Get_EndOfTheDayNetProfit";






        #endregion


        #region Methods

        #region GetEndOfDayDetails
        public Dictionary<string, List<EndofTheDayObject>> GetEndOfDayDetails(EndofTheDayObject objPos, ref decimal Balance, ref decimal Drawing)
        {
            try
            {
                Dictionary<string, List<EndofTheDayObject>> dicEndOfDayDetails = new Dictionary<string, List<EndofTheDayObject>>();
                List<EndofTheDayObject> lstEndOfDayDetails = new List<EndofTheDayObject>();
                List<EndofTheDayObject> lstEndOfDayTotals = new List<EndofTheDayObject>();
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
                sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
                sqlParam[2] = new SqlParameter("@Option",objPos.CheckedStatus);
                var ReaderResult = SQLHelper.Instance.GetReader(SpGetEndOfDayDetails, sqlParam);
                while (ReaderResult.Read())
                {
                    lstEndOfDayDetails.Add(new EndofTheDayObject
                    {
                        UserId = ReaderResult["UserId"] != DBNull.Value ? Convert.ToInt16(ReaderResult["UserId"]) : 0,
                        UserName = ReaderResult["UserName"] != DBNull.Value ? Convert.ToString(ReaderResult["UserName"]) : string.Empty,
                        TotalSale = ReaderResult["TotalSale"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSale"]).ToString("#########0.000") : "0.000",
                        TotalSaleReturn = ReaderResult["TotalSaleReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleReturn"]).ToString("#########0.000") : "0.000",
                        TotalPurchase = ReaderResult["TotalPurchase"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchase"]).ToString("#########0.000") : "0.000",
                        TotalPurchaseReturn = ReaderResult["TotalPurchaseReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchaseReturn"]).ToString("#########0.000") : "0.000",
                        Expenses = ReaderResult["Expenses"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Expenses"]).ToString("#########0.000") : "0.000",

                        TotalSpoiled = ReaderResult["Spoiled"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Spoiled"]).ToString("#########0.000") : "0.000",
                        TotalPaid = ReaderResult["Paid"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Paid"]).ToString("#########0.000") : "0.000",
                        TotalReceived = ReaderResult["Received"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Received"]).ToString("#########0.000") : "0.000",
                        
                        // TotalRented =ReaderResult["Rents"] != null ? Convert.ToDecimal(ReaderResult["Rents"]):0,
                       // TotalNetCash = (decimal.Parse(ReaderResult["Received"].ToString()) - (decimal.Parse(ReaderResult["Paid"].ToString()) + decimal.Parse(ReaderResult["Expenses"].ToString()))).ToString(),
                        
                   // TotalSpending = ReaderResult["Spending"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Spending"]).ToString("#########0.000") : "0.000",

                    });

                }

                ReaderResult.NextResult();

                while (ReaderResult.Read())
                {
                    lstEndOfDayTotals.Add(new EndofTheDayObject
                    {
                        TotalSale = ReaderResult["TotalSale"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSale"]).ToString("#########0.000") : "0.000",
                        TotalPurchase = ReaderResult["TotalPurchase"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchase"]).ToString("#########0.000") : "0.000",
                        Expenses = ReaderResult["Expenses"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Expenses"]).ToString("#########0.000") : "0.000",
                        TotalCost = ReaderResult["TotalCost"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalCost"]).ToString("#########0.000") : "0.000",
                        TotalReceived = ReaderResult["TotalReceived"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalReceived"]).ToString("#########0.000") : "0.000",
                        TotalPaid = ReaderResult["TotalPaid"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPaid"]).ToString("#########0.000") : "0.000",

                        TotalSaleReturn = ReaderResult["TotalSaleReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSaleReturn"]).ToString("#########0.000") : "0.000",
                        TotalPurchaseReturn = ReaderResult["TotalPurchaseReturn"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalPurchaseReturn"]).ToString("#########0.000") : "0.000",
                        TotalSpoiled = ReaderResult["TotalSpoiled"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSpoiled"]).ToString("#########0.000") : "0.000",
                        TotalProfit = ReaderResult["TotalProfit"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalProfit"]).ToString("#########0.000") : "0.000",
                        TotalCharges = ReaderResult["PaymentCharges"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["PaymentCharges"]).ToString("#########0.000") : "0.000",
                        //TotalNetCash = (decimal.Parse(ReaderResult["TotalReceived"].ToString()) - (decimal.Parse(ReaderResult["TotalPaid"].ToString()) + decimal.Parse(ReaderResult["Expenses"].ToString()))).ToString()

                        //TotalSpending = ReaderResult["TotalSpending"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["TotalSpending"]).ToString("#########0.000") : "0.000",
                    });

                }
                ReaderResult.NextResult();
                while (ReaderResult.Read())
                {

                    Balance = Convert.ToDecimal(ReaderResult["Amount"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Amount"]).ToString("#########0.000") : "0.000");
                    
                }
                ReaderResult.NextResult();
                while (ReaderResult.Read())
                {
                    Drawing = Convert.ToDecimal(ReaderResult["Drawing"] != DBNull.Value ? Convert.ToDecimal(ReaderResult["Drawing"]).ToString("#########0.000") : "0.000");
                }
                ReaderResult.Close();
                dicEndOfDayDetails.Add("EndOfDayDetails", lstEndOfDayDetails);
                dicEndOfDayDetails.Add("EndOfDayTotals", lstEndOfDayTotals);

                return dicEndOfDayDetails;
            }
            catch
            {
                throw;
            }
            finally
            {
                Close();
            }
        }
        #endregion

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

        #endregion

        #region -- Sp to Call Total Of the End Of the Report
        public DataTable GetEndOftheReportTatalRecord(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", 1);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledataWithFunction("Select * from Get_ReportEndOftheDayTotalRecord(@FromDate,@ToDate,@Option)", sqlParam);

            return Result;
        }
        public DataTable GetEndOftheReportPuchaseInformation(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", objPos.CheckedStatus);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata(spGetEndOftheDayPurchaseInformation,sqlParam);

            return Result;
        }

        public DataTable GetEndOftheReportNetCashInHand(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", objPos.CheckedStatus);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata("Sp_Get_NETCash", sqlParam);

            return Result;
        }
        public DataTable GetEndOftheReportSaleInformation(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", objPos.CheckedStatus);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata(spGetEndOftheDaySaleInformation, sqlParam);

            return Result;
        }
        public DataTable getDebtReportValues(int AgentID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", AgentID);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_DeptList", param, "DeptList");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable getDebtReportValuesWithDateRange(DateTime dtFrom, DateTime dtTo, int Option,int AgentID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@dtStart", dtFrom);
                param[1] = new SqlParameter("@dtEnd", dtTo);
                param[2] = new SqlParameter("@option", Option);
                param[3] = new SqlParameter("@AgentID", AgentID);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_DeptList1ByDateRange", param, "DeptList1");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet GetEndOftheReportNetIncomeInformation(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Flag", objPos.CheckedStatus == 0 ? "All" : "");

            DataSet Result = SQLHelper.Instance.ExecuteQueryDataset(spGetEndOftheDayNetIncomeInformation, sqlParam,"EndOfTheDay");

            return Result;
        }



        public DataTable GetEndOftheReportMovementRecord(EndofTheDayObject objPos)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", objPos.CheckedStatus);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata(spGetEndOfTheDayMovementRecord, sqlParam);

            return Result;
        }
        public DataSet GetEndOftheReportZakatCalculation()
        {

            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDataset(spGetZakatCalculation, param, "Zakat");
        }

        public DataTable GetEndOFTheDayReportNetStockInfomation()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CategoryID", 0);
            param[1] = new SqlParameter("@CompanyID ", 0);
            return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_inventoryvalue", param, "Zakat");
        }
        public DataTable Get_PayableReceivable()
        {

            try
            {

                SqlParameter[] param = new SqlParameter[0];

                //return SQLHelper.Instance.ExecuteQueryDatatable("Sp_payable_receivable", param, "PayableReceivable");

                //as per client requierment alter by thamil on 29aug 2016
                //return SQLHelper.Instance.ExecuteQueryDatatable("SpGetPayableReceivable", param, "PayableReceivable");
                return SQLHelper.Instance.ExecuteQueryDatatable("Sp_payable_receivable", param, "PayableReceivable");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataSet GetInventoryValue_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@CategoryID", 0);
                sqlparam[1] = new SqlParameter("@CompanyID ", 0);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_inventoryvalue_SubSp", sqlparam, "InventoryValue_Sum");
                DataTable DT1 = GetInventoryValue();
                ds.Tables.Add(DT1);
                ds.Tables.Add(DT);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable GetInventoryValue()
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@CategoryID", 0);
                sqlparam[1] = new SqlParameter("@CompanyID ", 0);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_inventoryvalue", sqlparam, "InventoryValue");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable GetEndOftheReportZakatCalculation1()
        {

            SqlParameter[] sqlParam = new SqlParameter[0];
                       
            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata(spGetZakatCalculation, sqlParam);

            return Result;
        }

        public DataTable GetEndOftheReportCashInfromation(EndofTheDayObject objPos)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option",objPos.CheckedStatus);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata(spGetCashInformation,sqlParam);

            return Result;
        }


        public DataTable GetEndOftheReportMovementBlock(DateTime dtFrom, DateTime dtTo)
        {

            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", dtFrom);
            sqlParam[1] = new SqlParameter("@ToDate", dtTo);
            sqlParam[2] = new SqlParameter("@Option", 1);

            DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledataWithFunction("Select * from Get_ReportEndOftheDayTotalRecord(@FromDate,@ToDate,@Option)", sqlParam);

            return Result;
        }

        public DataTable GetEndOfDayTotalCash(EndofTheDayObject objPos, ref decimal Balance, ref decimal Drawing)
        {
            objPos.CheckedStatus = 0;
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@FromDate", objPos.FromDate);
            sqlParam[1] = new SqlParameter("@ToDate", objPos.ToDate);
            sqlParam[2] = new SqlParameter("@Option", objPos.CheckedStatus);

            DataSet ds = SQLHelper.Instance.ExecuteQueryDataset(spGetEndOftheDayTotalCash, sqlParam, "EndOfDay");

            DataTable res = ds.Tables[0]; //SQLHelper.Instance.ExecuteQueryDatatabledata(spGetEndOftheDayTotalCash,sqlParam);
            Balance = Convert.ToDecimal(ds.Tables[1].Rows[0][0].ToString());
            Drawing = Convert.ToDecimal(ds.Tables[2].Rows[0][0].ToString());


            return res;
        }
        #endregion


        #endregion
    }
}
