using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class SaleReturnInvoiceBAL
    {

        #region Declaration

        public SaleReturnObjectClass objSaleReturnObjectClass;
        public SaleReturnDAL objSaleReturnDal;

        #endregion

        #region Constructor
        public SaleReturnInvoiceBAL()
        {
            objSaleReturnObjectClass = new SaleReturnObjectClass();
            objSaleReturnDal = new SaleReturnDAL();
        }
        #endregion

        #region Methods

        #region GetItemList
        public List<SaleReturnObjectClass> GetItemList()
        {

            var items = GeneralObjectClass.ItemDetails.Select(i =>
                        new SaleReturnObjectClass
                        {
                            ID = i.ItemId,
                            Name = i.Items,
                            ItemNumber = i.ItemNumber,
                            IsHide = i.IsHide //////based on hide option the item will be hide 


                        }).Distinct();
            var CheckList = items;
            CheckList = CheckList.GroupBy(x => x.ID).Select(y => y.First());
            return CheckList.Distinct().ToList();
        }
        #endregion

        #region GetUser

        public List<AgentDetailObjectClass> GetUser()
        {

            List<AgentDetailObjectClass> lstClientDetails = new List<AgentDetailObjectClass>();
            var str = "0|102|0|0|0";

            //lstClientDetails = (from a in lstClientDetails
            //                    where a.AgentType != str
            //                   // orderby a.Name //Commented on 30-June-2014 for  -> Already list is ordered from Database
            //                    select a).ToList();commended By Meena.R to fix the Hide agent Issue on 01/07/2014
            lstClientDetails = GeneralObjectClass.AgentDetails.Where(a => ((a.AgentType.Contains("101")) || (a.AgentType.Contains("103"))) && (!a.AgentType.Contains("104"))).ToList();
            //lstClientDetails.Add(new AgentDetailObjectClass
            //{
            //    AgentId = 1001,
            //    Name = "CASH CLIENT",
            //    AgentType = "101|0|0|0"

            //});

            return lstClientDetails;

        }

        #endregion

        #region GetBalance
        public List<SaleReturnObjectClass> GetBalanceBal()
        {

            return objSaleReturnDal.GetBalanceSheetDetails(objSaleReturnObjectClass);

        }
        #endregion

        #region GetSaleReturnDetailsBal
        public List<SaleReturnObjectClass> GetSaleReturnDetailsBal()
        {

            return objSaleReturnDal.GetSaleReturnDetails(objSaleReturnObjectClass);

        }
        #endregion

        #region GetYearSequenceMaxIDBal
        public List<long> GetYearSequenceMaxIDBal()
        {
            //List<long> list = objSaleReturnDal.GetYearSequenceMaxID();
            //return list;
            return objSaleReturnDal.GetYearSequenceMaxID();
        }
        #endregion

        #region SaveSaleReturnDetailsBal
        public bool SaveSaleReturnDetailsBal()
        {

            return objSaleReturnDal.SaveSaleReturnDetails(objSaleReturnObjectClass);

        }
        #endregion

        #region GetMInMaxSaleReturnIdBal
        public List<long> GetMInMaxSaleReturnIdBal()
        {
            List<long> list = objSaleReturnDal.GetMInMaxSaleReturnId();
            return list;
        }
        #endregion

        #region GetCurrentYearBal
        public List<SaleReturnObjectClass> GetCurrentYearBal()
        {

            return objSaleReturnDal.GetCurrentYear();

        }
        #endregion

        #region GetYearSequenceBal
        public List<SaleReturnObjectClass> GetYearSequenceBal()
        {

            return objSaleReturnDal.GetYearSequence(objSaleReturnObjectClass);

        }
        #endregion

        #region GetReturnDetailsBasedOnInvoiceBal
        public List<SaleReturnObjectClass> GetReturnDetailsBasedOnInvoiceBal()
        {

            return objSaleReturnDal.GetReturnDetailsBasedOnInvoice(objSaleReturnObjectClass);

        }
        #endregion

        #region GetStockForUndoBal
        public List<SaleReturnObjectClass> GetStockForUndoBal()
        {
            return objSaleReturnDal.GetStockForUndo(objSaleReturnObjectClass);
        }
        #endregion

        #region UndoReturnPerItemBal
        public bool UndoReturnPerItemBal()
        {

            return objSaleReturnDal.UndoReturnPerItem(objSaleReturnObjectClass);

        }
        #endregion

        #region UndoReturnAllQtyBal
        public bool UndoReturnAllQtyBal()
        {

            return objSaleReturnDal.UndoReturnAllQty(objSaleReturnObjectClass);

        }
        #endregion

        #region SaveReturnInvoiceBal
        public bool SaveReturnInvoiceBal()
        {

            return objSaleReturnDal.SaveReturnInvoice(objSaleReturnObjectClass);

        }
        #endregion

        #region GetSaleIDBal
        public List<long> GetSaleIDBal()
        {
            List<long> list = objSaleReturnDal.GetSaleID(objSaleReturnObjectClass);
            return list;
        }
        #endregion

        #region ModifyReturnInvoiceBal
        public bool ModifyReturnInvoiceBal()
        {

            return objSaleReturnDal.ModifyReturnInvoice(objSaleReturnObjectClass);

        }
        #endregion

        #region CheckBalanceBal
        public List<decimal> CheckBalanceBal()
        {
            List<decimal> list = objSaleReturnDal.CheckBalance(objSaleReturnObjectClass);
            return list;
        }
        #endregion

        #region GetMaxPaymentIDBal

        public List<long> GetMaxPaymentIDBal()
        {
            List<long> list = objSaleReturnDal.GetMaxPaymentID();
            return list;
        }

        #endregion

        #region SavePayReceiptDetailsBal
        public bool SavePayReceiptDetailsBal()
        {
            return objSaleReturnDal.SavePayReceiptDetails(objSaleReturnObjectClass);
        }
        #endregion
        #region UpdatePayReceiptDetailsBal
        public bool UpdatePayReceiptDetailsBal()
        {
            return objSaleReturnDal.UpdatePayReceiptDetails(objSaleReturnObjectClass);
        }
        #endregion
        

        #region GetSaleReturnPrintReportBal
        public DataTable GetSaleReturnPrintReportBal()
        {

            return objSaleReturnDal.GetSaleReturnPrintReport(objSaleReturnObjectClass);

        }
        #endregion
        #endregion
        public List<SaleReturnObjectClass> Get_ExpiryDatesDetails()
        {

            return objSaleReturnDal.DateForExpiredItem(objSaleReturnObjectClass);

        }
        public int check_PaymentAndPaymentDetails()
        {
            return objSaleReturnDal.check_PaymentAndPaymentDetails(objSaleReturnObjectClass);
        }

        public Dictionary<decimal, int> ItemDetailsPrice()
        {

            return objSaleReturnDal.UnitPriceForItem(objSaleReturnObjectClass);
        }
        public int GetSaleDetailsID()
        {

            return objSaleReturnDal.GetSalesDetailsIdOfItem(objSaleReturnObjectClass);
        }
        public List<SaleReturnObjectClass> GetPackageQtyForItemBal()
        {
            return objSaleReturnDal.GetPackageQtyForItem(objSaleReturnObjectClass);
        }
        public List<SaleReturnObjectClass> GetSerialNo()
        {
            return objSaleReturnDal.Get_QuickReturnSerialNo(objSaleReturnObjectClass);
        }
        public int GetItemInformation()
        {
            return objSaleReturnDal.GetItemDetails(objSaleReturnObjectClass);
        }
        public List<SaleReturnObjectClass> GetItemPurchasedList()
        {
            return objSaleReturnDal.GetPurchasedItemDetails(objSaleReturnObjectClass);
        }
        public DataTable GetItemForReturn()
        {
            return objSaleReturnDal.GetSaleReturnItem();
        }
        public int Get_CountOfSaleItem(Boolean isPOS)
        {
            return objSaleReturnDal.GetSalesDetailsItem(objSaleReturnObjectClass, isPOS);
        }
        public object GetMaxIdRecord()
        {
            return objSaleReturnDal.Get_MaxIdOfPaymentRecord();

        }
        public List<long> GetPayReceiptMaxID()
        {

            List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Payment));
            return list;
        }
        public int GetUndoStockCount()
        {
            return objSaleReturnDal.GetUndoStockDetails(objSaleReturnObjectClass);
        }
        public int UndoQuickRetrun()
        {
            return objSaleReturnDal.UndoQuickRetrunItem(objSaleReturnObjectClass);
        }
        public int GetSaleID()
        {
            return objSaleReturnDal.GetSaleIdWithYearSequenceNo(objSaleReturnObjectClass);

        }
        public DataTable GetItemDetails()
        {
            return StoredProcedurers.GetItemsfromSale();
        }
    }
}

