using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class PosScreenBAL
    {

        #region Declaration
        PosDalClass objPOSDalClass;
        POSObject objPOSObjectClass;
        #endregion

        #region Constructor
        public PosScreenBAL()
        {
            objPOSDalClass = new PosDalClass();
            objPOSObjectClass = new POSObject();
        }
        #endregion

        #region Getting Pos Object Class in BAL Class
        public POSObject objPOSObject
        {
            get { return objPOSObjectClass; }
            set { objPOSObjectClass = value; }
        }
        #endregion

        #region Methods

        #region GetYearSequenceMaxIDBal
        public List<long> GetYearSequenceMaxIDBal()
        {
            List<long> list = objPOSDalClass.GetYearSequenceMaxID();
            return list;
        }
        #endregion

        #region GetOrderNoBal
        public object GetOrderNoBal()
        {
            return objPOSDalClass.GetOrderNo();
        }
        #endregion

        #region SaveSaleInvoiceBal
        public bool SaveSaleInvoiceBal()
        {
            return objPOSDalClass.SaveSaleInvoice(objPOSObjectClass);
        }
        #endregion

        #region SaveSaleInvoiceDetailsBal
        public bool SaveSaleInvoiceDetailsBal()
        {
            return objPOSDalClass.SaveSaleInvoiceDetails(objPOSObjectClass);
        }
        #endregion

        #region GetStockOnItemBal
        public object GetStockOnItemBal()
        {
            return objPOSDalClass.GetStockOnItem(objPOSObjectClass);
        }
        #endregion

        #region UpdateSerialNoBal
        public bool UpdateSerialNoBal()
        {
            return objPOSDalClass.UpdateSerialNo(objPOSObjectClass);
        }
        #endregion

        #region GetMaxSaleIDBal
        public object GetMaxSaleIDBal()
        {
            return objPOSDalClass.GetMaxSaleID();
        }
        #endregion

        #region GetSalesDetailsBal
        public Dictionary<string, List<POSObject>> GetSalesDetailsBal()
        {
            return objPOSDalClass.GetSalesDetails(objPOSObjectClass);
        }
        #endregion

        #region DeleteSaleInvoiceDetailsBal
        public bool DeleteSaleInvoiceDetailsBal()
        {
            return objPOSDalClass.DeleteSaleInvoiceDetails(objPOSObjectClass);
        }
        #endregion

        #region ModifySaleDetailsBal
        public bool ModifySaleDetailsBal()
        {
            return objPOSDalClass.ModifySaleDetails(objPOSObjectClass);
        }
        #endregion

        #region GetPOSIDBal
        public List<long> GetPOSIDBal()
        {
            return objPOSDalClass.GetPOSID();
        }
        #endregion

        #region GetPOSPrintReportBal
        public DataTable GetPOSPrintReportBal()
        {
           return objPOSDalClass.GetPOSPrintReport(objPOSObject);
        }
        #endregion

        #region GetSaleIDForTableBal
        public long GetSaleIDForTableBal()
        {
            return objPOSDalClass.GetSaleIDForTable(objPOSObject);
        }
        #endregion

        #region UpdateSaleIDForTableBal
        public bool UpdateSaleIDForTableBal()
        {
            return objPOSDalClass.UpdateSaleIDForTable(objPOSObjectClass);
        }
        #endregion

        #endregion


        #region GetItemDetailsWithPackageQty
        public List<ItemCardObjectClass> GetItemDetailsBAL()
        {
            List<ItemCardObjectClass> objItemList = new List<ItemCardObjectClass>();
            objItemList = objPOSDalClass.GetItemDetails();
            return objItemList;
        }

        public DataTable NewGetItemDetailsBAL()
        {
            return objPOSDalClass.NewGetItemDetails();
        }

        
        public List<POSObject> GetPackageQty(decimal i_Price = 0)
        {
            List<POSObject> objpack = objPOSDalClass.GetPackageQtyForItem(objPOSObject, i_Price);
            return objpack;
        }
        #endregion
        public List<POSObject > GetBalanceBal()
        {
            return objPOSDalClass.GetBalanceSheetDetails(objPOSObjectClass);

        }

        public List<POSObject> GetStockDetailsBAL()
        {
            return objPOSDalClass.GetStockDetails(objPOSObjectClass);

        }
        public List<ItemCardObjectClass> GetHoleItem(int itemId)
        {
            return objPOSDalClass.GetAllItems(itemId);
        }
        public DataTable GetPOSItems()
        {
            return objPOSDalClass.GetPOSItems(); 
        }

        public bool ShowPricePopup(int i, int bi)
        {
            return objPOSDalClass.ShowPricePopup(i,bi);
        }

        public int GetButtonItemId(string buttontxt)
        {
            return objPOSDalClass.GetButtonItemId(buttontxt);
        }


        public List<SaleObject> GetItemMinPriceBal()
        {
            return objPOSDalClass.GetItemMinimumPrice(objPOSObjectClass);
        }

        public int ResetOrder(long SaleID)
        {
            return objPOSDalClass.ResetOrderNo(SaleID);
        }
        public float GetDiscountForAgentBal()
        {
            return objPOSDalClass.GetDiscountForAgent(objPOSObject);
        }
        public float GetIsDiscountOrIncreaseForAgentBal()
        {
            return objPOSDalClass.GetIsDiscountOrIncreaseForAgent(objPOSObject);
        }
        public DataTable GetAppliedIncreaseBal(int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            return objPOSDalClass.GetAppliedIncrease(CategoryID, CompanyID, ItemType, ItemNo);
        }
        public bool UpdateActiveUserBal()
        {
            bool Value = objPOSDalClass.UpdateActiveUser(objPOSObject);
            return Value;
        }
        public List<POSObject> GetActiveUserBal()
        {
            return objPOSDalClass.GetActiveUser(objPOSObject);
        }

        //Nto
        public List<POSObject> GetCateComIDForItemBal()
        {
            return objPOSDalClass.GetCateComIDForItem(objPOSObject);
        }
        public float GetAppliedDiscountBal()
        {

            return objPOSDalClass.GetAppliedDiscount(objPOSObject);

        }
        public DataTable GetAppliedIncreaseBal()
        {

            return objPOSDalClass.GetAppliedIncrease(objPOSObject);

        }

        public DataSet GetItemPrintInfoBal()
        {

            return objPOSDalClass.GetItemPrintInfoDal(objPOSObject);

        }
        
    }
}
