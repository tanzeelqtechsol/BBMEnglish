using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace BALHelper
{
    public class OrderInvoiceBALClass
    {
        OrderInvoiceDAL ObjDALClass;
        PurchaseObjectClass OrderObject;

        public OrderInvoiceBALClass()
        {
            ObjDALClass = new OrderInvoiceDAL();
        }

        public PurchaseObjectClass ObjOrder
        {
            get { return OrderObject; }
            set { OrderObject = value; }
        }

        public void SetCommonObject()
        {
            OrderObject = new PurchaseObjectClass();
        }
        public List<PurchaseObjectClass> GetItemNameDetails()
        {
            List<PurchaseObjectClass> ItemDetailsList = new List<PurchaseObjectClass>();
            DataSet ds = StoredProcedurers.GetItemDetails();
            DataTable dt = ds.Tables[0];

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //ItemDetailsList.Add(new PurchaseObjectClass
            //{
            //    ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
            //    ItemName = dt.Rows[i]["ItemName"].ToString(),
            //    CategoryNo = Convert.ToInt32(dt.Rows[i]["CategoryID"]),
            //    CompanyNo = Convert.ToInt32(dt.Rows[i]["CompanyID"]),
            //    Reorder = Convert.ToInt32(Convert.ToInt32(dt.Rows[i]["Reorder"]) == 0 ? 1 : dt.Rows[i]["Reorder"]),
            //    ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 1 : dt.Rows[i]["PackageQty"]),
            //    ItemTotalStock = Convert.ToInt32(dt.Rows[i]["StockInHand"]),
            //    CategoryName = dt.Rows[i]["CategoryFieldName"].ToString(),
            //    CompanyName = dt.Rows[i]["CompanyFieldName"].ToString(),
            //    ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
            //});
            //}

            foreach (DataRow row in dt.Rows)
            {
                ItemDetailsList.Add(new PurchaseObjectClass
                {
                    ItemNo = Convert.ToInt32(row["ItemID"]),
                    ItemName = row["ItemName"].ToString(),
                    CategoryNo = Convert.ToInt32(row["CategoryID"]),
                    CompanyNo = Convert.ToInt32(row["CompanyID"]),
                    Reorder = Convert.ToInt32(Convert.ToInt32(row["Reorder"]) == 0 ? 1 : row["Reorder"]),
                    ItemPackage = Convert.ToInt32(row["PackageQty"] == DBNull.Value ? 1 : row["PackageQty"]),
                    ItemTotalStock = Convert.ToInt32(row["StockInHand"]),
                    CategoryName = row["CategoryFieldName"].ToString(),
                    CompanyName = row["CompanyFieldName"].ToString(),
                    ItemNumber = row["ItemNumber"].ToString(),
                    IsHide  =Convert.ToBoolean ( row["IsHide"])

                });
            }

            return ItemDetailsList;
        }
        public List<PurchaseObjectClass> OrderDetailsLoad()
        {
            //List<PurchaseObjectClass> orderlist = ObjDALClass.GetOrderDetails();
            //return orderlist;
            return ObjDALClass.GetOrderDetails();
        }
        public List<long> GetInvoiceID()
        {
            //List<long> InvoiceID = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Order));
            //return InvoiceID;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Order));
        }
        public Boolean SaveOrderInvoice()
        {
            if (ObjDALClass.Save_Order_Invoice(ObjOrder))
                return true;
            else
                return false;
        }
        public List<PurchaseObjectClass> GetOrderInvoiceDetails()
        {
            DataTable dt = ObjDALClass.GetOrderInvoiceDetails(ObjOrder.OrderInvoiceNo, Convert.ToInt32(CommonHelper.OrderRemarks.OI));
            List<PurchaseObjectClass> objdetails = new List<PurchaseObjectClass>();
            FillOrderInvoiceDetails(dt, objdetails);
            return objdetails;
        }

        private void FillOrderInvoiceDetails(DataTable dt, List<PurchaseObjectClass> objdetails)
        {
            try
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    objdetails.Add(new PurchaseObjectClass
                //    {
                //        OrderInvoiceNo = Convert.ToInt64(dt.Rows[i]["OrderInvoice"]),
                //        NewYearInvoiceID = Convert.ToInt32(dt.Rows[i]["YearSequenceNo"]),
                //        Year = Convert.ToInt32(dt.Rows[i]["Year"]),
                //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                //        SupplierNo = Convert.ToInt32(dt.Rows[i]["AgentID"]),
                //        SupplierName = dt.Rows[i]["AgentName"].ToString(),
                //        ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                //        ItemUnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]),
                //        ItemTotal = Convert.ToDecimal(dt.Rows[i]["Total"]),
                //        OrderDemandDate = Convert.ToDateTime(dt.Rows[i]["DemandDate"] == DBNull.Value ? null : dt.Rows[i]["DemandDate"]),
                //        ItemNet = Convert.ToDecimal(dt.Rows[i]["NetAmount"]),
                //        OrderDeliveryDate = Convert.ToDateTime(dt.Rows[i]["DeliveryDate"] == DBNull.Value ? null : dt.Rows[i]["DeliveryDate"]),
                //        Discount = Convert.ToDecimal(dt.Rows[i]["Discount"]),
                //        Status = Convert.ToInt32(dt.Rows[i]["Status"]),
                //        ItemName = dt.Rows[i]["ItemName"].ToString(),
                //        ItemPackage = Convert.ToInt32(dt.Rows[i]["Package"]),
                //        ItemPrice = Convert.ToInt32(dt.Rows[i]["Price"] == DBNull.Value ? 0 : dt.Rows[i]["Price"]),
                //        ItemGrossAmt = Convert.ToDecimal(dt.Rows[i]["TOTAL"]),
                //        //ItemCost = Convert.ToDecimal(dt.Rows[i]["ItemCost"] == DBNull.Value ? 0.000m : dt.Rows[i]["ItemCost"]),
                //        ItemCost = Convert.ToDecimal(dt.Rows[i]["Cost"] == DBNull.Value ? 0.000m : dt.Rows[i]["Cost"]),
                //        OrderDate = Convert.ToDateTime(dt.Rows[i]["OrderDate"]),
                //        User = dt.Rows[i]["CreatedBy"].ToString(),
                //        DiscountType = Convert.ToInt32(dt.Rows[i]["DiscountType"] == DBNull.Value ? null : dt.Rows[i]["DiscountType"]),
                //        ItemDiscount = Convert.ToDecimal(dt.Rows[i]["ItemDiscount"] == DBNull.Value ? null : dt.Rows[i]["ItemDiscount"]),
                //        OrderNote = dt.Rows[i]["Note"] == DBNull.Value ? string.Empty : dt.Rows[i]["Note"].ToString(),
                //        //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["Serialno"]),
                //        ItemSerialNo = dt.Rows[i]["Serialno"].ToString(),
                //        ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["NewExpiry"] == DBNull.Value ? null : dt.Rows[i]["NewExpiry"]),
                //        Time = dt.Rows[i]["Time"].ToString(),
                //        ItemNumber = dt.Rows[i]["ItemNumber"] == DBNull.Value ? string.Empty : dt.Rows[i]["ItemNumber"].ToString(),
                //        BarcodeID = dt.Rows[i]["BarcodeID"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[i]["BarcodeID"]) // This is changed to avoid DBNull exception. Done by Manoj On June 21
                //    });
                //}

                foreach (DataRow row in dt.Rows)
                {
                    objdetails.Add(new PurchaseObjectClass
                    {
                        OrderInvoiceNo = Convert.ToInt64(row["OrderInvoice"]),
                        NewYearInvoiceID = Convert.ToInt32(row["YearSequenceNo"]),
                        Year = Convert.ToInt32(row["Year"]),
                        ItemNo = Convert.ToInt32(row["ItemID"]),
                        SupplierNo = Convert.ToInt32(row["AgentID"]),
                        SupplierName = row["AgentName"].ToString(),
                        ItemQuantity = Convert.ToInt32(row["Quantity"]),
                        ItemUnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                        ItemTotal = Convert.ToDecimal(row["Total"]),
                        OrderDemandDate = Convert.ToDateTime(row["DemandDate"] == DBNull.Value ? null : row["DemandDate"]),
                        ItemNet = Convert.ToDecimal(row["NetAmount"]),
                        OrderDeliveryDate = Convert.ToDateTime(row["DeliveryDate"] == DBNull.Value ? null : row["DeliveryDate"]),
                        Discount = Convert.ToDecimal(row["Discount"]),
                        Status = Convert.ToInt32(row["Status"]),
                        ItemName = row["ItemName"].ToString(),
                        ItemPackage = Convert.ToInt32(row["Package"]),
                        ItemPrice = Convert.ToInt32(row["Price"] == DBNull.Value ? 0 : row["Price"]),
                        ItemGrossAmt = Convert.ToDecimal(row["TOTAL"]),
                        //ItemCost = Convert.ToDecimal(row["ItemCost"] == DBNull.Value ? 0.000m : row["ItemCost"]),
                        ItemCost = Convert.ToDecimal(row["Cost"] == DBNull.Value ? 0.000m : row["Cost"]),
                        OrderDate = Convert.ToDateTime(row["OrderDate"]),
                        User = row["CreatedBy"].ToString(),
                        DiscountType = Convert.ToInt32(row["DiscountType"] == DBNull.Value ? null : row["DiscountType"]),
                        ItemDiscount = Convert.ToDecimal(row["ItemDiscount"] == DBNull.Value ? null : row["ItemDiscount"]),
                        OrderNote = row["Note"] == DBNull.Value ? string.Empty : row["Note"].ToString(),
                        //ItemSerialNo = Convert.ToInt64(row["Serialno"]),
                        ItemSerialNo = row["Serialno"].ToString(),
                        ItemExpiryDate = Convert.ToDateTime(row["NewExpiry"] == DBNull.Value ? null : row["NewExpiry"]),
                        Time = row["Time"].ToString(),
                        ItemNumber = row["ItemNumber"] == DBNull.Value ? string.Empty : row["ItemNumber"].ToString(),
                        BarcodeID = row["BarcodeID"] == DBNull.Value ? 0 : Convert.ToInt32(row["BarcodeID"]) // This is changed to avoid DBNull exception. Done by Manoj On June 21
                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<long> GetInvoiceNoForEmptyRecord()
        {
            DataTable dt = StoredProcedurers.Get_NewYearNo(ObjOrder.OrderInvoiceNo, ObjOrder.InvoiceFlag);
            List<long> EmptyRecordId = new List<long>();
            if (dt != null && dt.Rows.Count > 0)
            {
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["OrderInvoice"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["Year"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["YearSequenceNo"]));
            }
            return EmptyRecordId;
        }

        public List<PurchaseObjectClass> GetItemDetails()
        {
            //List<PurchaseObjectClass> ItemDetailsList = StoredProcedurers.GetItemNameInfo(ObjOrder);
            //return ItemDetailsList;
            return StoredProcedurers.GetItemNameInfo(ObjOrder);
        }

        public Boolean ModifyInvoice()
        {
            if (StoredProcedurers.ModifyInvoice(ObjOrder.OrderInvoiceNo, ObjOrder.InvoiceFlag) > 0)
                return true;
            else
                return false;

        }
        public List<long> GetMinMaxyearValue()
        {
            //List<long> IDs = StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.Order));
            //return IDs;
            return StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.Order));
        }
        public object GetInvoiceNoBasedOntheYearValue()
        {
            //object Id = StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjOrder.Year, ObjOrder.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.Order));
            //return Id;
            return StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjOrder.Year, ObjOrder.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.Order));
        }
        public Boolean UpdateDeliveryDate()
        {
            object obj = ObjDALClass.CheckDeliveryDate(ObjOrder);
            if (Convert.ToInt32(obj) == 0)
            {
                if (ObjDALClass.Update_Order_Invoice(ObjOrder))
                    return true;
                else
                    return false;
            }
            else
            {
                if (GeneralFunction.OKCancelMsg("AnotherDeliverySet", "OrderInvoice") == DialogResult.OK)
                {
                    if (ObjDALClass.Update_Order_Invoice(ObjOrder))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public List<PurchaseObjectClass> GetItemNameBasedOnID()
        {
            List<PurchaseObjectClass> objItemName = new List<PurchaseObjectClass>();
            DataTable dt = StoredProcedurers.GetItemBasedOnComCat(ObjOrder.CategoryNo, ObjOrder.AccountID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objItemName.Add(new PurchaseObjectClass
                {
                    ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                    ItemName = dt.Rows[i]["ItemName"].ToString(),
                    IsHide = Convert.ToBoolean(dt.Rows[i]["IsHide"]),
                    ItemNumber=dt.Rows[i]["ItemNumber"].ToString()
                });
            }
            return objItemName;

        }


        ///// Spoiled Item Invoice \\\\\\
        public List<PurchaseObjectClass> SpoiledInvoiceLoad()
        {
            //List<PurchaseObjectClass> orderlist = ObjDALClass.SpoiledInvoiceList();
            //return orderlist;
            return ObjDALClass.SpoiledInvoiceList();
        }

        public List<long> GetSpoiledInvoiceID()
        {
            //List<long> InvoiceID = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
            //return InvoiceID;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
        }
        public List<long> GetSpoiledYearMaxID()
        {
            //List<long> IDs = StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
            //return IDs;
            return StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
        }
        public List<PurchaseObjectClass> GetItemExpiry()
        {
            List<PurchaseObjectClass> ObjList = new List<PurchaseObjectClass>();
            DataTable dt = new DataTable();
           // ObjOrder.InvoiceFlag = "ALLDATE"; on 28/04/2014 to load only expiryed item
           // ObjOrder.InvoiceFlag = string.Empty;
            dt = ObjDALClass.GetItemExpiry(ObjOrder.InvoiceFlag,ObjOrder.ItemNo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ObjList.Add(new PurchaseObjectClass
                {
                    ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["Expiry"] == DBNull.Value ? null : dt.Rows[i]["Expiry"]).Date,
                    ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"] == DBNull.Value ? 0 : dt.Rows[i]["ItemID"]),
                    ItemTotalStock = Convert.ToInt32(dt.Rows[i]["StockInHand"] == DBNull.Value ?0: dt.Rows[i]["StockInHand"]),
                    ItemName = dt.Rows[i]["ItemName"].ToString(),
                    BarcodeID=Convert.ToInt32(dt.Rows[i]["BarcodeID"]==DBNull.Value?0:dt.Rows[i]["BarcodeID"]),
                    ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"])
                });
            }
            return ObjList;
        }

        public List<PurchaseObjectClass> GetSerialNo()
        {
            List<PurchaseObjectClass> ItemSerialNo = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetSerialNo(ObjOrder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemSerialNo.Add(new PurchaseObjectClass
                {
                   // ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
                    ItemSerialNo =dt.Rows[i]["SerialNo"].ToString(),
                    ItemPrice = Convert.ToDecimal(dt.Rows[i]["Price"]),
                    ItemTotalStock = Convert.ToInt32(dt.Rows[i]["totalstock"]),
                    BarcodeID=Convert.ToInt32(dt.Rows[i]["BarcodeID"])
                });
            }
            return ItemSerialNo;
        }
        public List<PurchaseObjectClass> GetSpoiledInvoiceData()
        {
            DataTable dt = ObjDALClass.GetOrderInvoiceDetails(ObjOrder.OrderInvoiceNo, Convert.ToInt32(CommonHelper.OrderRemarks.SI));
            List<PurchaseObjectClass> ObjSpoiledList = new List<PurchaseObjectClass>();
            FillOrderInvoiceDetails(dt, ObjSpoiledList);
            return ObjSpoiledList;
        }
        public List<PurchaseObjectClass> GetExpiryBasedStock()
        {
            List<PurchaseObjectClass> ExpiryStock = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.get_stock_basedexpiry(ObjOrder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ExpiryStock.Add(new PurchaseObjectClass
                {
                    ItemStock = Convert.ToInt32(dt.Rows[i]["ExpiryStock"] == DBNull.Value ? null : dt.Rows[i]["ExpiryStock"]),
                    ItemPackage = Convert.ToInt32(dt.Rows[i]["Package"] == DBNull.Value ? null : dt.Rows[i]["Package"])
                });
            }
            return ExpiryStock;
        }
        public List<PurchaseObjectClass> GetStockBasedSerialno()
        {
            List<PurchaseObjectClass> SerialNoStock = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.SerialNoBasedonStock(ObjOrder);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SerialNoStock.Add(new PurchaseObjectClass
                {
                    ItemStock = Convert.ToInt32(dt.Rows[i]["SerialNoStock"] == DBNull.Value ? 0 : dt.Rows[i]["SerialNoStock"]),
                    //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["Price"]),
                    ItemSerialNo =dt.Rows[i]["Price"].ToString(),
                    ItemPackage = Convert.ToInt32(dt.Rows[i]["Package"])
                });
            }
            return SerialNoStock;
        }
        public object GetSpoiledInvoiceNoBasedOntheYearValue()
        {
            //object Id = StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjOrder.Year, ObjOrder.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
            //return Id;
            return StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjOrder.Year, ObjOrder.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.SpoiledInvoice));
        }
        public DataTable SpoiledItemsDetails()
        {
            return ObjDALClass.Get_SpoiledItemDetails();
        }
        public DataTable ReturnReportValues()
        {
            return ObjDALClass.GetReportValues(ObjOrder.InvoiceNo, ObjOrder.Remarks);
        }
        public DataTable PerformaReportValues(long InvoiceNo, int Remarks)
        {
            return ObjDALClass.GetReportValues(InvoiceNo, Remarks);
        }
        public List<PurchaseObjectClass> Get_PurchasedItemDetails()
        {
            return ObjDALClass.GetPurchasedItem(ObjOrder);
        }
        public List<PurchaseObjectClass> Get_ItemDetailsForSpoiled()
        {
            return ObjDALClass.Get_SpoiledItemDetailsLoad(ObjOrder);
        }
        public DataTable GetItems()
        {
            return ObjDALClass.GetAllItemOnlyinStock();
        }
        public DataTable GetOrderItemData(int caID,int coID)
        {
            return ObjDALClass.GetAllItemforOrder(caID, coID);
        }
    }
}
