using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
   public class InventoryAdjustBALClass
   {
       #region Lists
       List<InventAdjustObjectClass> objInventAdjlistBal = new List<InventAdjustObjectClass>();
       Dictionary<string, List<InventAdjustObjectClass>> InvAdjDictBal = new Dictionary<string, List<InventAdjustObjectClass>>();
       InventoryAdjustDAL ObjInventAdjDal = new InventoryAdjustDAL();
       #endregion
       public InventAdjustObjectClass ObjInvAdjObjectClass;
       public InventAdjustObjectClass ObjInvAdjObject
       {
           get { return ObjInvAdjObjectClass; }
           set { ObjInvAdjObjectClass = value; }
       }
       public void SetCommonObject()
       {
           ObjInvAdjObjectClass = new InventAdjustObjectClass();
       }
       public List<InventAdjustObjectClass> InventoryAdjustmentload()
       {
           return objInventAdjlistBal = ObjInventAdjDal.InventoryAdjustmentload(ObjInvAdjObject);
       }
       public List<InventAdjustObjectClass> InventAdjust_InvoiceNoBAL()
       {
           return objInventAdjlistBal = ObjInventAdjDal.InventAdjust_InvoiceNoDAL(ObjInvAdjObject);
       }
       public bool UpdateInventoryAdjustmentDetailsHelp()
       {
           //bool res = false;
           //return res = ObjInventAdjDal.UpdateInventoryAdjustmentDetailsDAL(ObjInvAdjObject);
          return ObjInventAdjDal.UpdateInventoryAdjustmentDetailsDAL(ObjInvAdjObject);
       }
       public int GetCurrentYearBal()
       {
           return ObjInventAdjDal.GetCurrentYear();
       }
       public List<long> GetMaxMinInvoiceID()
       {
           //List<long> ID = StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.StockAdjustment));
           //return ID;
           return StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.StockAdjustment));
       }
       public int GetInvoiveNewYearNoBal()
       {
           //int NewYearNo = ObjInventAdjDal.Get_Invoice_NewYearNo(ObjInvAdjObject);
           //return NewYearNo;

           return ObjInventAdjDal.Get_Invoice_NewYearNo(ObjInvAdjObject);
       }
       public DataSet  PayableReceivable()
       {
           DataSet ds = new DataSet();
           ds = ObjInventAdjDal.Get_PayableReceivable();
           return ds;
       }
       public DataTable GetAllitem(int catid,int comid)
       {
           DataSet dstable = StoredProcedurers.GetItemListByCategoryORCompany(catid,comid);
           DataTable dti =new DataTable() ;
           if (GeneralOptionSetting.FlagShowHidenItem == "N")
           {
               DataView dataview = new DataView(dstable.Tables[0]);
               dataview.RowFilter = "IsHide='" + 0 + "'";
               dti = dataview.ToTable();
           }
           else
           {
               //dataview.RowFilter = "IsHide='" + 0 + "' OR IsHide='" + 1 + "'";
               //dti = dataview.ToTable();
               dti = dstable.Tables[0];
           }
           return dti;
       }
    }
}
