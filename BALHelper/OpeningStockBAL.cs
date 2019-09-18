using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using System.Data;
using ObjectHelper;
using System.Diagnostics;

namespace BALHelper
{
    public class OpeningStockBAL
    {
        OpeningStockDAL ObjStockDAL;
        public PurchaseObjectClass objOpeningStockObject;
        DataTable dt;
        DataSet ds;
        public OpeningStockBAL()
        {
            ObjStockDAL = new OpeningStockDAL();
        }
        public void SetObject()
        {
            objOpeningStockObject = new PurchaseObjectClass();
        }

        public PurchaseObjectClass ObjStock
        {
            get { return objOpeningStockObject; }
            set { objOpeningStockObject = value; }

        }

        public List<PurchaseObjectClass> GetItemDetailsForStock()
        {
            List<PurchaseObjectClass> list = new List<PurchaseObjectClass>();
            DataSet ds = new DataSet();
            ds = ObjStockDAL.GetItemListByCategoryORCompany(ObjStock);
            DataTable dt = ds.Tables[0];

       

          //  IList<PurchaseObjectClass> list = CommonHelper.ConvertionHelper.ConvertToList<PurchaseObjectClass>(dt);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    list.Add(new PurchaseObjectClass
            //    {
            //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
            //        ItemName = dt.Rows[i]["ItemName"].ToString(),
            //        CategoryNo = Convert.ToInt32(dt.Rows[i]["CategoryID"]),
            //        CompanyNo = Convert.ToInt32(dt.Rows[i]["CompanyID"]),
            //        IsHide = Convert.ToBoolean(dt.Rows[i]["IsHide"] == DBNull.Value ? false : dt.Rows[i]["IsHide"]),
            //        ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
            //    });
            //}
                 
            //Converting from Datarow to List done by Praba on 21-Jun-2014 (Performance Issue)

            //List<PurchaseObjectClass> Lst1 = dt.Select().ToList();



            list = (from DataRow row in dt.Rows
                    select new PurchaseObjectClass
                    {
                        ItemNo = Convert.ToInt32(row["ItemID"]),
                        ItemName = row["ItemName"].ToString(),
                        CategoryNo = Convert.ToInt32(row["CategoryID"]),
                        CompanyNo = Convert.ToInt32(row["CompanyID"]),
                        IsHide = Convert.ToBoolean(row["IsHide"] == DBNull.Value ? false : row["IsHide"]),
                        ItemNumber = row["ItemNumber"].ToString()

                    }).ToList();


           


            return list;
        }

        public DataTable GetItemdetails()
        {
            DataSet dstbl = ObjStockDAL.GetItemListByCategoryORCompany(ObjStock);
            DataTable dtitems = new DataTable();
            ///below condition added to fix the hide and show the hid items
            if (GeneralOptionSetting.FlagShowHidenItem == "N")
            {
                DataView dataview = new DataView(dstbl.Tables[0]);
                dataview.RowFilter = "IsHide='" + 0 + "'";
                dtitems = dataview.ToTable();
            }
            else
            {
                //dataview.RowFilter = "IsHide='" + 0 + "' OR IsHide='" + 1 + "'";
                dtitems = dstbl.Tables[0]; //dataview.ToTable();
            }
            return dtitems;
        }
        public List<PurchaseObjectClass> GetItemDetails()
        {
            //List<PurchaseObjectClass> ItemDetailsList = StoredProcedurers.GetItemNameInfo(ObjStock);
            return StoredProcedurers.GetItemNameInfo(ObjStock); //Performance fine tune by praba on 20-Nov
        }

        public Boolean SaveInventoryDetails()
        {
            if (ObjStockDAL.Save_InventoryDetailsList(ObjStock))
                return true;
            else
                return false;
        }

        public Boolean SaveStockDetails()
        {
            if (ObjStockDAL.Save_Stock_Details(ObjStock) > 0)
                return true;
            else
                return false;
        }

        public Boolean ModifyInventory()
        {
            ObjStock.InvoiceFlag = "INVENTORY";
            if (StoredProcedurers.ModifyInvoice(ObjStock.InvoiceNo, ObjStock.InvoiceFlag) > 0)
                return true;
            else
                return false;
        }

        public Boolean UpdateInventory()
        {
            if (ObjStockDAL.Update_InventoryDetails(ObjStock))
                return true;
            else
                return false;
        }
        public Boolean UndoInventory()
        {
            if (ObjStockDAL.Undo_InventoryDetails(ObjStock))
                return true;
            else
                return false;
        }

        public Object GetDeleteStockCount()
        {
            object Stock = ObjStockDAL.stock_for_Delete(ObjStock);
            return Stock;
        }

        public List<PurchaseObjectClass> GetInventoryDetails()
        {
            List<PurchaseObjectClass> ObjList = new List<PurchaseObjectClass>();
            ObjStock.CompanyNo = Convert.ToInt32(CommonHelper.CategoryId.Value); //This is changed to set categoryid and company id as 1001
            ObjStock.CategoryNo = Convert.ToInt32(CommonHelper.CompanyId.Value); //This is changed to set categoryid and company id as 1001
            dt = ObjStockDAL.Get_All_InventoryofItemList_Extended(ObjStock);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ObjList.Add(new PurchaseObjectClass
            //    {
            //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
            //        ItemName =dt.Rows[i]["ItemName"].ToString(),
            //        ItemDescription=dt.Rows[i]["Description"]== DBNull.Value?string.Empty:dt.Rows[i]["Description"].ToString(),
            //        ItemPackage=Convert.ToInt32(dt.Rows[i]["PackageQty"]== DBNull.Value?1:dt.Rows[i]["PackageQty"]),
            //        ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]) ,
            //        ItemUnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"] == DBNull.Value ? 0.000 : dt.Rows[i]["UnitPrice"]),
            //        ItemPrice = Convert.ToDecimal(dt.Rows[i]["ItemPrice"] == DBNull.Value ? 0.000 : dt.Rows[i]["ItemPrice"]),
            //        ItemTotal=Convert.ToDecimal(dt.Rows[i]["Total"]==DBNull.Value?0.000:dt.Rows[i]["Total"]),
            //        Time=Convert.ToDateTime(dt.Rows[i]["Time"]).ToShortTimeString(),
            //        User=dt.Rows[i]["User"]==DBNull.Value?string.Empty:dt.Rows[i]["User"].ToString(),
            //        ItemCost = Convert.ToDecimal(dt.Rows[i]["ItemCost"] == DBNull.Value ? 0.000 : dt.Rows[i]["ItemCost"]),
            //        ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"] == DBNull.Value ? null : dt.Rows[i]["ExpiryDate"]),
            //        //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
            //        ItemSerialNo = dt.Rows[i]["SerialNo"].ToString(),
            //        Status=Convert.ToInt32(dt.Rows[i]["Status"]),
            //        ItemNumber =dt.Rows[i]["ItemNumber"].ToString(),
            //        BarcodeID = Convert.ToInt32(dt.Rows[i]["BarcodeID"] == DBNull.Value ? 0 : dt.Rows[i]["BarcodeID"]),
            //        Note = dt.Rows[i]["Notes"] == DBNull.Value ? string.Empty : dt.Rows[i]["Notes"].ToString()
            //    });
            //}


            ObjList = (from DataRow row in dt.Rows

                    select new PurchaseObjectClass
                    {
                        ItemNo = Convert.ToInt32(row["ItemID"]==DBNull.Value?0:row["ItemID"]),
                        ItemName = row["ItemName"].ToString(),
                        ItemDescription = row["Description"] == DBNull.Value ? string.Empty : row["Description"].ToString(),
                        ItemPackage = Convert.ToInt32(row["PackageQty"] == DBNull.Value ? 1 : row["PackageQty"]),
                        ItemQuantity = Convert.ToInt32(row["Quantity"]),
                        ItemUnitPrice = Convert.ToDecimal(row["UnitPrice"] == DBNull.Value ? 0.000 : row["UnitPrice"]),
                        ItemPrice = Convert.ToDecimal(row["ItemPrice"] == DBNull.Value ? 0.000 : row["ItemPrice"]),
                        ItemTotal = Convert.ToDecimal(row["Total"] == DBNull.Value ? 0.000 : row["Total"]),
                        Time = Convert.ToDateTime(row["Time"]).ToShortTimeString(),
                        User = row["User"] == DBNull.Value ? string.Empty : row["User"].ToString(),
                        ItemCost = Convert.ToDecimal(row["ItemCost"] == DBNull.Value ? 0.000 : row["ItemCost"]),
                        ItemExpiryDate = Convert.ToDateTime(row["ExpiryDate"] == DBNull.Value ? null : row["ExpiryDate"]),
                        //ItemSerialNo = Convert.ToInt64(row["SerialNo"]),
                        ItemSerialNo = row["SerialNo"].ToString(),
                        Status = Convert.ToInt32(row["Status"]),
                        ItemNumber = row["ItemNumber"].ToString(),
                        BarcodeID = Convert.ToInt32(row["BarcodeID"] == DBNull.Value ? 0 : row["BarcodeID"]),
                        Note = row["Notes"] == DBNull.Value ? string.Empty : row["Notes"].ToString()

                    }).ToList();

            return ObjList;
        }

        public DataTable GetInventoryExport()
        {
            DataTable dt = ObjStockDAL.GetDetailsforExport();
            return dt;
        }

        public DataTable GetAppliedIncreaseBal()
        {
            return ObjStockDAL.GetAppliedIncrease(ObjStock);
        }

        //public DataSet GetComCatList()
        // {

        //     using(ds = objOpeningStockDAL.getComCatList())
        //     return ds;
        // }
        //public DataTable GetGridList()
        //{
        //    u sing (dt = objOpeningStockDAL.getGridList())
        //        return dt;
        //}
        //public DataTable GetControlDetails()
        //{
        //    using (dt = objOpeningStockDAL.getGridList())
        //        return dt;
        //}

    }
}
