using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;



namespace DataBaseHelper.DALClass
{
    public class ReportDAL
    {

        public DataSet Get_LoadReportDetails()
        {
            try


            {
                DataSet DS = new DataSet();
                SqlParameter[] sqlparam = new SqlParameter[0];
                DS = SQLHelper.Instance.ExecuteQueryDataset("SP_Get_DetailsforReport", sqlparam,"ItemDetails");
                return DS;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable  Get_PurchaseMovement(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate==null ?(object )DBNull.Value :ReportObject.FromDate );
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate==null?(object)DBNull.Value:ReportObject.ToDate  );
           
                sqlparam[2] = new SqlParameter("@ItemNumber", ReportObject.ItemNo );
                sqlparam[3] = new SqlParameter("@UserID", ReportObject.UserId );
                sqlparam[4] = new SqlParameter("@HideExpiry", ReportObject.ExpiryItem);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemPurchase ", sqlparam, "ItemPurchaseMovement");
                return DT;
              

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable Get_ReturnMovement(ReportObjectClass ReportObject)
        {
            try
            {
                  DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[7];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);
           
                sqlparam[2] = new SqlParameter("@ItemID", ReportObject.ItemNo );
                sqlparam[3] = new SqlParameter("@CategoryID", ReportObject.CategoryID  );
                sqlparam[4] = new SqlParameter("@CompanyID", ReportObject.CompanyID );
                sqlparam[5] = new SqlParameter("@AgentID", ReportObject.AgentID );
                sqlparam[6] = new SqlParameter("@HideExpiry", ReportObject.ExpiryItem);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemReturnPurchase ", sqlparam, "PurchaseReturnMovement");
                return DT;
              
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable Get_ItemPriceList(ReportObjectClass ReportObject, bool Barcode = false)
        {

            try
            {
  DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[3];
               sqlparam[0] = new SqlParameter("@ItemType", ReportObject.ItemType );
                sqlparam[1] = new SqlParameter("@CategoryID", ReportObject.CategoryID  );
           
                sqlparam[2] = new SqlParameter("@CompanyID", ReportObject.CompanyID  );

                if (!Barcode)
                {
                    DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemPriceList ", sqlparam, "PriceList");
                }
                else
                {
                    DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemPriceList ", sqlparam, "PriceListBarcode");
                }
                return DT;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable Get_SearchSaleMovement(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@ItemID", ReportObject.ItemNo);
                sqlparam[1] = new SqlParameter("@FromDate", ReportObject.FromDate==null?(object)DBNull.Value :ReportObject.FromDate );
                sqlparam[2] = new SqlParameter("@ToDate",ReportObject.FromDate==null?(object)DBNull.Value : ReportObject.ToDate);
                sqlparam[3] = new SqlParameter("@UserID", ReportObject.UserId );
                sqlparam[4] = new SqlParameter("@HideExpiry", ReportObject.ExpiryItem);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemSales ", sqlparam, "ItemSaleMovement");
                return DT;
            }
            catch (Exception ex)
            {
                
                throw ex ;
            }
        }
        public DataTable Get_SaleReturn(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[7];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);
                sqlparam[2] = new SqlParameter("@ItemID", ReportObject.ItemNo );
                sqlparam[3] = new SqlParameter("@CategoryID", ReportObject.CategoryID );
                sqlparam[4] = new SqlParameter("@CompanyID", ReportObject.CompanyID );
                sqlparam[5] = new SqlParameter("@AgentID", ReportObject.AgentID );
                sqlparam[6] = new SqlParameter("@HideExpiry", ReportObject.ExpiryItem);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemReturnSales ", sqlparam, "SaleReturnMovement");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
                

        }
        public DataTable Get_TotalSaleReturn(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[7];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);
                sqlparam[2] = new SqlParameter("@ItemID", ReportObject.ItemNo);
                sqlparam[3] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[4] = new SqlParameter("@CompanyID", ReportObject.CompanyID);
                sqlparam[5] = new SqlParameter("@AgentID", ReportObject.AgentID);
                sqlparam[6] = new SqlParameter("@HideExpiry", ReportObject.ExpiryItem);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemTotalReturnSales ", sqlparam, "SaleReturnMovement");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public DataTable Get_WellMovingItem(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);             
                sqlparam[2] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[3] = new SqlParameter("@CompanyID", ReportObject.CompanyID);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_SlowQuickMovingItem ", sqlparam, "WellMovingItems");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable Get_SpoiledItem(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);   
                sqlparam[2] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[3] = new SqlParameter("@CompanyID", ReportObject.CompanyID);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_SpoiledItem ", sqlparam, "SpoiledItems");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable Get_InventoryItem(ReportObjectClass ReportObject)
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);   
                sqlparam[2] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[3] = new SqlParameter("@CompanyID", ReportObject.CompanyID);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemInventory ", sqlparam, "InventoryItemList");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable Get_InventoryAtDate(ReportObjectClass ReportObject)
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);   
                sqlparam[2] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[3] = new SqlParameter("@CompanyID", ReportObject.CompanyID);

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ItemInventoryAtDate ", sqlparam, "InventoryItemList");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Get_ExpiryListToADate(ReportObjectClass ReportObject)
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];

                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate == null ? (object)DBNull.Value : ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate == null ? (object)DBNull.Value : ReportObject.ToDate);   

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ExpiryListByDate", sqlparam, "ExpiryListByDate");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Get_ItemCard(ReportObjectClass ReportObject)
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[3];   //This is changed to avoid sqlparameter collection shound not be null as per the following details Done By A.Manoj On July-24-2014
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                sqlparam[2] = new SqlParameter("@ItemID", ReportObject.ItemNo );

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_GetItemStockHistory ", sqlparam, "ItemcardInOutStock");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Get_HourlySalesDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                //sqlparam[2] = new SqlParameter("@ItemID", ReportObject.ItemNo);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Chart_Hourly_Sales", sqlparam, "ChartHourlySales");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_MonthlySalesDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("Usp_Report_Chat_MonthlySales", sqlparam, "ChartMonthlySales");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_UserProductivityDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("Usp_Report_Chart_User_Productivity", sqlparam, "ChartSales");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_ClientListDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[0];
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ClientDetails", sqlparam, "ClientList");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_SuppListDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[0];
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_SupplierList", sqlparam, "SupplierList");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable Get_ClientMovementDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ClentsMovement", sqlparam, "ClientsMovement");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Get_SearchBestWorstDAL(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[0];
                DT = SQLHelper.Instance.ExecuteQueryDatatable("Sp_profitofeachmonth", sqlparam, "Chart_PSProfit_Month");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_ZakatValues()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDataset("usp_Reports_ZakatCalculationReport",param,"Zakat");
        }

        public DataTable Get_AgentBalanceSheet(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@ToDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@AgentType", ObjReport.AgentType);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_AgentBalanceSheet", param, "BalanceSheet");
        }
        public DataTable BankStatement(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@ToDate", ObjReport.ToDate);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_BankBalanceSheet", param, "BankBalanceSheet");
        }
        public DataTable TaxList(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            param[0].Value=ObjReport.FromDate;
            param[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            param[1].Value=ObjReport.ToDate;
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_Taxlist", param, "TaxList");
        }
        public DataSet GetNetProfit(DateTime? FromDate, DateTime? ToDate, string Flag)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", FromDate);
                param[1] = new SqlParameter("@ToDate", ToDate);
                param[2] = new SqlParameter("@Flag", Flag);
                return SQLHelper.Instance.ExecuteQueryDataset("SP_Get_NetProfit", param, "NetProfit");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SaleMovementAccordingTo(ReportObjectClass objreportclass)
        {
            try
            {  
                
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@FromDate",objreportclass.FromDate);
                param[1] = new SqlParameter("@ToDate", objreportclass.ToDate);
                param[2] = new SqlParameter("@AgentID", objreportclass.AgentID );
                param[3]=new SqlParameter("@CategoryID",objreportclass.CategoryID );
                param[4] = new SqlParameter("@CompanyID", objreportclass.CompanyID);
                param[5] = new SqlParameter("@HideExpiry", objreportclass.ExpiryItem );
                param[6] = new SqlParameter("@ItemID", objreportclass.ItemNo);
                //add by thamil on 13july 2016 for user wise filtration.
                param[7] = new SqlParameter("@UserID", objreportclass.UserId);
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_SalesAccordingToCCUT", param, "SaleInvoiceList");
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable Receivable(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
            param[0].Value = ObjReport.FromDate;
            param[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param[1].Value = ObjReport.ToDate;
            param[2] = new SqlParameter("@AgentID",ObjReport.AgentID);
            param[3] = new SqlParameter("@UserID", ObjReport.UserId);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_ReceivedCash", param, "Receivable");
        }
        public DataTable Payable(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StartDate", SqlDbType.DateTime);
            param[0].Value = ObjReport.FromDate;
            param[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
            param[1].Value = ObjReport.ToDate;
            param[2] = new SqlParameter("@AgentID", ObjReport.AgentID);
            param[3] = new SqlParameter("@UserID",SqlDbType.Int);
            param[3].Value=ObjReport.UserId;
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_PaidCash", param, "Payable");
        }
        public DataTable Expense(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StartDate",ObjReport.FromDate);
            param[1] = new SqlParameter("@EndDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@ReceiptNo",0);
            param[3] = new SqlParameter("@UserID", ObjReport.UserId);
            return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ExpensesDetailList", param, "Spending");
        }
        public DataTable Get_ClintPaymentListDal(ReportObjectClass ReportObject)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@FromDate", ReportObject.FromDate);
                sqlparam[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                sqlparam[2] = new SqlParameter("@AgentID", ReportObject.AgentID);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ClientPaymentlist", sqlparam, "ClientPaymentlist");
                return DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetInventoryValue(ReportObjectClass ReportObject)
        {

            try
            {
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@CategoryID", ReportObject.CategoryID );
                sqlparam[1] = new SqlParameter("@CompanyID ", ReportObject.CompanyID );

                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_inventoryvalue", sqlparam, "InventoryValue");
                return DT;
            }
            catch (Exception ex)
            {
                
                throw ex ;
            }
        }
        public DataSet GetInventoryValue_Reports(ReportObjectClass ReportObject)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable DT = new DataTable();
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@CategoryID", ReportObject.CategoryID);
                sqlparam[1] = new SqlParameter("@CompanyID ", ReportObject.CompanyID);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_inventoryvalue_SubSp", sqlparam, "InventoryValue_Sum");
                DataTable DT1 = GetInventoryValue(ReportObject);
                ds.Tables.Add(DT1);
                ds.Tables.Add(DT);               
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetTotalDiscount(DateTime? FromDate, DateTime? ToDate, int AgentID, int UserID, string Flag)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FromDate", FromDate);
                param[1] = new SqlParameter("@ToDate", ToDate);
                param[2] = new SqlParameter("@Flag", Flag);
                param[3] = new SqlParameter("@Agent", AgentID);
                param[4] = new SqlParameter("@User", UserID);
                return SQLHelper.Instance.ExecuteQueryDataset("SP_Get_TotalDiscount", param, "TotalDiscount");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Drawing(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StartDate",ObjReport.FromDate );
            param[1] = new SqlParameter("@EndDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@UserID", ObjReport.UserId);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Drawing", param, "Drawing");
        }
        public DataTable ListOfSales(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StartDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@EndDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@AgentID", ObjReport.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ListOfSales", param, "ListofSales");
        }
        public DataTable Get_PayableReceivable(ReportObjectClass reportobject)
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
        public DataTable Get_ListOfPurchase(ReportObjectClass ReportObject)
        {

            try
            {
                  SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FromDate",ReportObject.FromDate );
            param[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
            param[2] = new SqlParameter("@AgentID", ReportObject.AgentID );
            return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ListOfPurchase", param, "ListOfPurchase");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable Get_DiscountFromClientDAL(ReportObjectClass ReportObject)
        {
            try
            {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FromDate",ReportObject.FromDate );
            param[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
            param[2] = new SqlParameter("@UserId", ReportObject.AgentID);
            param[3] = new SqlParameter("@ClientNo", ReportObject.UserId);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_TotalDiscountforClient", param, "DiscountforClient");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable Get_DiscountProviderDAL(ReportObjectClass ReportObject)
        {
            try
            {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FromDate",ReportObject.FromDate );
            param[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
            param[2] = new SqlParameter("@AgentID", ReportObject.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_TotalDiscount_From_Supplier", param, "DiscountofProvider");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataTable Get_DebtsDetailsDAL(ReportObjectClass ReportObject)
        {
            try
            {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AgentID", ReportObject.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Debts_To_Pay", param, "DebtToPay");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDebtsLatencySuppDal(ReportObjectClass ReportObject)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@AgentID", ReportObject.AgentID);
                param[1] = new SqlParameter("@ToDate", ReportObject.ToDate);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Debt_Latency_of_Supplier", param, "SupplierDebt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListofProfitForClient(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@ToDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@UserID", ObjReport.UserId);
            param[3] = new SqlParameter("@ClientNo", ObjReport.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_TotalDiscountforClient", param, "DiscountforClient");
        }
        public DataTable BranchReturnList(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@ToDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@UserID", ObjReport.UserId);
            param[3] = new SqlParameter("@ClientNo", ObjReport.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_BranchReturnList", param, "BranchReturnList");
        }
        public DataTable ItemByBranch(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[1] = new SqlParameter("@ToDate", ObjReport.ToDate);
            param[2] = new SqlParameter("@AgentID", ObjReport.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Total_PurchaseBy_Branch", param, "ItemTakenbyBranch");
        }
        /// <summary>
        /// Added By Vinoth Oct 14 For Barnches List Report
        /// </summary>
        /// <param name="ObjReport"></param>
        /// <returns></returns>
        public DataTable BranchesList(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[1];          
            param[0] = new SqlParameter("@AgentID", ObjReport.AgentID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Branch_List", param, "AgentList");
        }
        /// <summary>
        /// Added By Vinoth Oct 14 For Barnches List Report
        /// </summary>
        /// <param name="ObjReport"></param>
        /// <returns></returns>
        public DataTable BranchesMovement(ReportObjectClass ObjReport)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@AgentID", ObjReport.AgentID);
            param[1] = new SqlParameter("@FromDate", ObjReport.FromDate);
            param[2] = new SqlParameter("@ToDate", ObjReport.ToDate);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_Branch_Movement", param, "BranchMovement");
        }


    }
}