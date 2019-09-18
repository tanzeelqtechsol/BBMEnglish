using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data;
using DataBaseHelper.DALClass;

namespace BALHelper
{
    public class ReportBAL
    {
        ReportObjectClass reportobject;
        ReportDAL reportdal;

        public ReportBAL(ReportObjectClass report_object)
        {
            reportobject = report_object;
            reportdal = new ReportDAL();

        }
        public DataSet GetDefaultItemDetails()
        {

            return reportdal.Get_LoadReportDetails();

        }
        public DataTable Get_SearchPurchaseMovement()
        {
            return reportdal.Get_PurchaseMovement(reportobject);
        }
        public DataTable Get_SearchReturnMovement()
        {
            return reportdal.Get_ReturnMovement(reportobject);
        }
        public DataTable Get_SearchItemPriceList(bool Barcode = false)
        {
            return reportdal.Get_ItemPriceList(reportobject, Barcode);
        }
        public DataTable Get_SearchItemSaleMovement()
        {
            return reportdal.Get_SearchSaleMovement(reportobject);
        }
        public DataTable Get_SearchSaleReturnMovement()
        {
            return reportdal.Get_SaleReturn(reportobject);
        }
        public DataTable Get_TotalSaleReturnMovement()
        {
            return reportdal.Get_TotalSaleReturn(reportobject);
        }
        public DataTable Get_SearchWellMovingItem()
        {
            return reportdal.Get_WellMovingItem(reportobject);
        }
        public DataTable Get_SearchSpoiledItem()
        {

            return reportdal.Get_SpoiledItem(reportobject);
        }
        public DataTable Get_SearchInventoryItem()
        {

            return reportdal.Get_InventoryItem(reportobject);
        }

        public DataTable Get_SearchInventoryAtDate()
        {

            return reportdal.Get_InventoryAtDate(reportobject);
        }
        public DataTable Get_SearchExpiryListToADate()
        {
            return reportdal.Get_ExpiryListToADate(reportobject);
        }
        public DataTable Get_SearchItemCardInOutStock()
        {
            return reportdal.Get_ItemCard(reportobject);
        }
        public DataTable Get_SearchHourlySalesBAL()
        {
            return reportdal.Get_HourlySalesDAL(reportobject);
        }
        public DataTable Get_SearchMonthlySalesBAL()
        {
            return reportdal.Get_MonthlySalesDAL(reportobject);
        }
        public DataTable Get_SearchUserProductivityBAL()
        {
            return reportdal.Get_UserProductivityDAL(reportobject);
        }
        public DataTable Get_SearchBestWorstBAL()
        {
            return reportdal.Get_SearchBestWorstDAL(reportobject);
        }
        public DataSet Get_Zakat()
        {
            return reportdal.Get_ZakatValues();
        }
        public DataTable Get_BalanceSheetBAL()
        {
            return reportdal.Get_AgentBalanceSheet(reportobject);
        }
        public DataTable Get_BankBalanceSheet()
        {
            return reportdal.BankStatement(reportobject);
        }
        public DataTable Get_TaxList()
        {
            return reportdal.TaxList(reportobject);
        }
        public DataSet Get_NetProfit()
        {
            return reportdal.GetNetProfit(reportobject.FromDate, reportobject.ToDate, reportobject.Flag);
        }
        public DataTable Get_SaleMovementAccordingTo()
        {
            return reportdal.SaleMovementAccordingTo(reportobject);
        }
        public DataTable Get_Receivables()
        {
            return reportdal.Receivable(reportobject);
        }
        public DataTable Get_ClintPaymentList()
        {
            return reportdal.Get_ClintPaymentListDal(reportobject);
        }
        public DataTable Get_Payable()
        {
            return reportdal.Payable(reportobject);
        }
        public DataTable Get_ExpenseDetails()
        {
            return reportdal.Expense(reportobject);
        }
        public DataTable Get_InventoryValue()
        {
            return reportdal.GetInventoryValue(reportobject);
        }
        public DataSet Get_InventoryValue_Reports()
        {
            return reportdal.GetInventoryValue_Reports(reportobject);
        }
        public DataTable GetPayableReceivable()
        {
            return reportdal.Get_PayableReceivable(reportobject);
        }
        public DataSet Get_TotalDiscount()
        {
            return reportdal.GetTotalDiscount(reportobject.FromDate, reportobject.ToDate, reportobject.AgentID, reportobject.UserId, reportobject.Flag);
        }
        public DataTable Get_Drawing()
        {
            return reportdal.Drawing(reportobject);
        }
        public DataTable Get_ListOfSales()
        {
            return reportdal.ListOfSales(reportobject);
        }
        public DataTable Get_ClintList()
        {
            return reportdal.Get_ClientListDAL(reportobject);
        }
        public DataTable Get_SuppList()
        {
            return reportdal.Get_SuppListDAL(reportobject);
        }
        public DataTable Get_ClientMovement()
        {
            return reportdal.Get_ClientMovementDAL(reportobject);
        }
        public DataTable GetListOfPurchase()
        {
            return reportdal.Get_ListOfPurchase(reportobject);
        }
        public DataTable Get_DiscountFromClient()
        {
            return reportdal.Get_DiscountFromClientDAL(reportobject);
        }
        public DataTable Get_DiscountProvider()
        {
            return reportdal.Get_DiscountProviderDAL(reportobject);
        }
        public DataTable Get_DebtsDetails()
        {
            return reportdal.Get_DebtsDetailsDAL(reportobject);
        }
        public DataTable GetDebtsLatencySuppBal()
        {
            return reportdal.GetDebtsLatencySuppDal(reportobject);
        }
        public DataTable GetListofProfitClient()
        {
            return reportdal.ListofProfitForClient(reportobject);
        }
        public DataTable GetBranchReturnList()
        {
            return reportdal.BranchReturnList(reportobject);
        }
        public DataTable GetItemByBranch()
        {
            return reportdal.ItemByBranch(reportobject);
        }
        /// <summary>
        /// Added By Vinoth Oct 14 For Barnches List Report
        /// </summary>       
        /// <returns></returns>
        public DataTable GetBranchesList()
        {
            return reportdal.BranchesList(reportobject);
        }
        /// <summary>
        /// Added By Vinoth Oct 14 For Barnches Movement Report
        /// </summary>       
        /// <returns></returns>
        public DataTable GetBranchesMovement()
        {
            return reportdal.BranchesMovement(reportobject);
        }
    }
}
