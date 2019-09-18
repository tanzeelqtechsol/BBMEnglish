using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using System.Data;

namespace BumedianBM.ViewHelper
{
   public class ItemInformationHelper
    {
       PurchaseBALClass objbalClass;
       internal List<DateTime> lstExpiryDates;
    
      
        public ItemInformationHelper()
        {
            objbalClass = new PurchaseBALClass();
            objbalClass.SetCommonObject();

        }

        public PurchaseBALClass ObjBALClass
        {
            get { return objbalClass; }
            set { objbalClass = value; }
        }

        // This is commented by manoj due this functionality implemeneted in code behind itself
        //public void GetInfo()
        //{
        //    try
        //    {
        //        if (ObjBALClass.ObjPurchase.ItemName != string.Empty && ObjBALClass.ObjPurchase.ItemNo != 0)
        //        {

        //            List<PurchaseObjectClass> ItemList = objbalClass.GetItemInfor();
        //           lstExpiryDates = objbalClass.GetExpiryDates();
        //            foreach (var list in ItemList)
        //            {

        //                objbalClass.ObjPurchase.ItemName = list.ItemName;
        //                objbalClass.ObjPurchase.CategoryName = list.CategoryName;
        //                objbalClass.ObjPurchase.PlaceName = list.PlaceName;
        //                objbalClass.ObjPurchase.CompanyName = list.CompanyName;
        //                ObjBALClass.ObjPurchase.ItemPrice = list.ItemPrice;
        //                ObjBALClass.ObjPurchase.ItemLastCost = list.ItemLastCost;
        //                ObjBALClass.ObjPurchase.ItemPackage=list.ItemPackage;
        //                ObjBALClass.ObjPurchase.ItemCost=list.ItemCost; 
        //                ObjBALClass.ObjPurchase.ItemWholeSalePrice = list.ItemWholeSalePrice;
        //                ObjBALClass.ObjPurchase.ItemLastCost=list.ItemLastCost;
        //                ObjBALClass.ObjPurchase.ItemMinimumPrice = list.ItemMinimumPrice;
        //                ObjBALClass.ObjPurchase.AvgCost = list.AvgCost;
        //                ObjBALClass.ObjPurchase.ItemExpiryDate = list.ItemExpiryDate;
        //                ObjBALClass.ObjPurchase.ItemTotalStock = list.ItemTotalStock;
        //                ObjBALClass.ObjPurchase.ItemExpiryDate=list.ItemExpiryDate;

        //            }


        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
