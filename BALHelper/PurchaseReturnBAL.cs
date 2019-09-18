using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;
namespace BALHelper
{
    public class PurchaseReturnBAL
    {
        PurchaseReturnDAL ObjPurReturnDAL;
        public List<PurchaseReturnObject> ObjReturnPurchaseList = new List<PurchaseReturnObject>();
        PurchaseObjectClass objPurReturnObject;
        object StockCount;
        int index = -1;

        public PurchaseReturnBAL()
        {
            ObjPurReturnDAL = new PurchaseReturnDAL();
        }

        public void SetCommonObject()
        {
            objPurReturnObject = new PurchaseObjectClass();
        }

        public PurchaseObjectClass ObjPurchaseReturn
        {
            get
            {
                return objPurReturnObject;
            }
            set { objPurReturnObject = value; }
        }

        public List<PurchaseObjectClass> GetItemList()
        {
            List<PurchaseObjectClass> ItemList = new List<PurchaseObjectClass>();
            DataSet ds = StoredProcedurers.GetItemDetails();
            DataTable dt = ds.Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ItemList.Add(new PurchaseObjectClass
            //    {
            //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
            //        ItemName = dt.Rows[i]["ItemName"].ToString(),
            //        CategoryNo = Convert.ToInt32(dt.Rows[i]["CategoryID"]),
            //        CompanyNo = Convert.ToInt32(dt.Rows[i]["CompanyID"]),
            //        Reorder = Convert.ToInt32(dt.Rows[i]["Reorder"]),
            //        ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"]),
            //        ItemTotalStock = Convert.ToInt32(dt.Rows[i]["StockInHand"]),
            //        CategoryName = dt.Rows[i]["CategoryFieldName"].ToString(),
            //        CompanyName = dt.Rows[i]["CompanyFieldName"].ToString(),
            //        ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
            //    });
            //}
           if(dt!=null && dt.Rows.Count>0)
            {
                ItemList = (from DataRow Rows in dt.Rows
                            select new PurchaseObjectClass
                                {
                                    ItemNo = Convert.ToInt32(Rows["ItemID"]),
                                    ItemName = Rows["ItemName"].ToString(),
                                    CategoryNo = Convert.ToInt32(Rows["CategoryID"]),
                                    CompanyNo = Convert.ToInt32(Rows["CompanyID"]),
                                    Reorder = Convert.ToInt32(Rows["Reorder"]),
                                    ItemPackage = Convert.ToInt32(Rows["PackageQty"] == DBNull.Value ? 0 : Rows["PackageQty"]),
                                    ItemTotalStock = Convert.ToInt32(Rows["StockInHand"]),
                                    CategoryName = Rows["CategoryFieldName"].ToString(),
                                    CompanyName = Rows["CompanyFieldName"].ToString(),
                                    ItemNumber = Rows["ItemNumber"].ToString(),
                                    IsHide =Convert.ToBoolean (Rows["IsHide"])////added on 10 july 2014 to get ishide valued from tab;e
                                }).ToList();
            } 
            return ItemList;
        }
        public DataTable ReturnItems()
        {
            return StoredProcedurers.GetCommonItemDetails();
        }
        public List<long> GetInvoiceID()
        {
            List<long> InvoiceID = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.PurchaseReturn));
            return InvoiceID;
        }

        public List<long> GetMaxMinInvoiceID()
        {
            List<long> ID = StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.PurchaseReturn));
            //return (List<int>)ConvertionHelper.ConvertToList<int>(dt);
            //List<long> ID = new List<long>();
            //ID.Add(Convert.ToInt64(ds.Tables[0].Rows[0]["MinID"] == DBNull.Value ? 0 : ds.Tables[0].Rows[0]["MinID"]));
            //ID.Add(Convert.ToInt64(ds.Tables[0].Rows[0]["MaxID"] == DBNull.Value ? 0 : ds.Tables[0].Rows[0]["MaxID"]));
            //ID.Add(Convert.ToInt64(ds.Tables[1].Rows[0]["YearValue"] == DBNull.Value ? 0 : ds.Tables[1].Rows[0]["YearValue"]));
            return ID;
        }

        public List<PurchaseObjectClass> GetReturnDetails()
        {
            List<PurchaseObjectClass> ReturnDetailsList = new List<PurchaseObjectClass>();
            DataTable dt = ObjPurReturnDAL.GetReturnPurchaseInvoice(ObjPurchaseReturn);
            LoadInvoiceDataByInvoiceItem(ReturnDetailsList, dt);
            return ReturnDetailsList;
        }

        public List<PurchaseObjectClass> GetReturnDetailsByInvoice()
        {
            List<PurchaseObjectClass> ReturnDetailsList = new List<PurchaseObjectClass>();
            DataSet ds = ObjPurReturnDAL.GetReturnPurchaseInvoice_byinvoice(ObjPurchaseReturn);
            DataTable dt = ds.Tables[0];
            LoadInvoiceDataByInvoiceItem(ReturnDetailsList, dt);
            return ReturnDetailsList;
        }

        private void LoadInvoiceDataByInvoiceItem(List<PurchaseObjectClass> ReturnDetailsList, DataTable dt)
        {
            ReturnDetailsList.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (index == -1)
                    ReturnDetailsList.Add(new PurchaseObjectClass
                    {
                        InvoiceNo = Convert.ToInt32(dt.Rows[i]["PurchaseInvoiceID"]),
                        PurchaseDetailsId = Convert.ToInt32(dt.Rows[i]["PurchaseDetailID"]),
                        PurchaseItemDate = Convert.ToDateTime(dt.Rows[i]["PurchaseDate"]).Date,
                        SupplierName = dt.Rows[i]["AgentName"] == DBNull.Value ? String.Empty : dt.Rows[i]["AgentName"].ToString(),
                        ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"]),
                        PurchaseQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                        ItemNet = Convert.ToDecimal(dt.Rows[i]["NetAmount"]),
                        ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"] == DBNull.Value ? null : dt.Rows[i]["ExpiryDate"]),
                        ItemExpiry = dt.Rows[i]["ExpiryDate"] == DBNull.Value ? "-" :Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).ToString().Split(' ').Length > 2 ? Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).ToString().Split(' ')[1] : Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).ToString().Split(' ')[0],
                        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"] == DBNull.Value ? 0 : dt.Rows[i]["ItemID"]),
                        PurchaseID = Convert.ToInt32(dt.Rows[i]["PurchaseID"]),
                        ReturnQty = Convert.ToInt32((dt.Rows[i]["ReturnQuantity"] == DBNull.Value) ? 0 : dt.Rows[i]["ReturnQuantity"]),
                        ExpiryDate = Convert.ToBoolean(dt.Rows[i]["Expiry"] == DBNull.Value ? 0 : dt.Rows[i]["Expiry"]),
                        ItemCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(dt.Rows[i]["Cost"]) * 1000m) / 1000m).ToString("#####0.000")),
                        PurchaseCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(dt.Rows[i]["PurchaseCost"]) * 1000m) / 1000m).ToString("#####0.000")),
                        NewCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(dt.Rows[i]["Newcost"]) * 1000m) / 1000m).ToString("#####0.000")),
                        ItemTotal = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["Quantity"]) * Decimal.Parse((Math.Truncate(Convert.ToDecimal(dt.Rows[i]["PurchaseCost"]) * 1000m) / 1000m).ToString("#####0.000"))),
                        // ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
                        ItemSerialNo = dt.Rows[i]["SerialNo"].ToString(),
                        User = CommonHelper.GeneralFunction.UserName,
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
                    });
            }
            //if (dt!=null && dt.Rows.Count > 0)
            //{
            //    if (index == -1)
            //        ReturnDetailsList = (from DataRow Row in dt.Rows
            //                             select new PurchaseObjectClass
            //                                 {
            //                                     InvoiceNo = Convert.ToInt32(Row["PurchaseInvoiceID"]),
            //                                     PurchaseDetailsId = Convert.ToInt32(Row["PurchaseDetailID"]),
            //                                     PurchaseItemDate = Convert.ToDateTime(Row["PurchaseDate"]).Date,
            //                                     SupplierName = Row["AgentName"] == DBNull.Value ? String.Empty : Row["AgentName"].ToString(),
            //                                     ItemPackage = Convert.ToInt32(Row["PackageQty"] == DBNull.Value ? 0 : Row["PackageQty"]),
            //                                     PurchaseQuantity = Convert.ToInt32(Row["Quantity"]),
            //                                     ItemNet = Convert.ToDecimal(Row["NetAmount"]),
            //                                     ItemExpiryDate = Convert.ToDateTime(Row["ExpiryDate"] == DBNull.Value ? null : Row["ExpiryDate"]),
            //                                     ItemExpiry = Row["ExpiryDate"] == DBNull.Value ? "-" : Convert.ToDateTime(Row["ExpiryDate"]).ToShortDateString(),
            //                                     ItemNo = Convert.ToInt32(Row["ItemID"] == DBNull.Value ? 0 : Row["ItemID"]),
            //                                     PurchaseID = Convert.ToInt32(Row["PurchaseID"]),
            //                                     ReturnQty = Convert.ToInt32((Row["ReturnQuantity"] == DBNull.Value) ? 0 : Row["ReturnQuantity"]),
            //                                     ExpiryDate = Convert.ToBoolean(Row["Expiry"] == DBNull.Value ? 0 : Row["Expiry"]),
            //                                     ItemCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(Row["Cost"]) * 1000m) / 1000m).ToString("#####0.000")),
            //                                     PurchaseCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(Row["PurchaseCost"]) * 1000m) / 1000m).ToString("#####0.000")),
            //                                     NewCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(Row["Newcost"]) * 1000m) / 1000m).ToString("#####0.000")),
            //                                     ItemTotal = Convert.ToDecimal(Convert.ToDecimal(Row["Quantity"]) * Decimal.Parse((Math.Truncate(Convert.ToDecimal(Row["PurchaseCost"]) * 1000m) / 1000m).ToString("#####0.000"))),
            //                                     // ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
            //                                     ItemSerialNo = Row["SerialNo"].ToString(),
            //                                     User = CommonHelper.GeneralFunction.UserName,
            //                                     ItemName = Row["ItemName"].ToString(),
            //                                     ItemNumber = Row["ItemNumber"].ToString()
            //                                 }).ToList();
            //}
        }


        public List<PurchaseObjectClass> GetInvoiceReturnDetailsID()
        {
            List<PurchaseObjectClass> InvoiceReturnDetails = new List<PurchaseObjectClass>();
            DataTable dt = ObjPurReturnDAL.GetPurchaseLoadData();
            if (dt != null)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    InvoiceReturnDetails.Add(new PurchaseObjectClass
                //    {
                //        ReturnInvoiceID = Convert.ToInt64(dt.Rows[i]["ReturnID"]),
                //        PurchaseReturnID = Convert.ToInt64(dt.Rows[i]["PurchaseReturnID"]),
                //        PurchaseID = Convert.ToInt32(dt.Rows[i]["PurchaseID"]),
                //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                //        AccountID = Convert.ToInt32(dt.Rows[i]["AccountID"]),
                //        ReturnDate = Convert.ToDateTime(dt.Rows[i]["ReturnDate"]),
                //        ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                //        ItemUnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]),
                //        Reason = dt.Rows[i]["Reason"].ToString(),
                //        ItemCost = Convert.ToDecimal(dt.Rows[i]["Cost"]),
                //        ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["Expiry"] == DBNull.Value ? null : dt.Rows[i]["Expiry"]),
                //        //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
                //        ItemSerialNo = dt.Rows[i]["SerialNo"].ToString(),
                //        Year = Convert.ToInt32(dt.Rows[i]["Year"]),
                //        NewYearInvoiceID = Convert.ToInt32(dt.Rows[i]["YearSequenceNo"]),
                //        SupplierNo = Convert.ToInt32(dt.Rows[i]["AgentID"] == DBNull.Value ? 0 : dt.Rows[i]["AgentID"]),
                //        NewCost = Convert.ToDecimal(dt.Rows[i]["NewCost"]),
                //        Status = Convert.ToInt32(dt.Rows[i]["Status"]),

                //    });
                //}
                if (dt!= null && dt.Rows.Count > 0)
                {
                    InvoiceReturnDetails = (from DataRow row in dt.Rows
                                            select new PurchaseObjectClass
                                                {
                                                    ReturnInvoiceID = Convert.ToInt64(row["ReturnID"]),
                                                    PurchaseReturnID = Convert.ToInt64(row["PurchaseReturnID"]),
                                                    //PurchaseID = Convert.ToInt32(row["PurchaseID"]),
                                                    //ItemNo = Convert.ToInt32(row["ItemID"]),
                                                    //AccountID = Convert.ToInt32(row["AccountID"]),
                                                    //ReturnDate = Convert.ToDateTime(row["ReturnDate"]),
                                                    //ItemQuantity = Convert.ToInt32(row["Quantity"]),
                                                    //ItemUnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                                                    //Reason = row["Reason"].ToString(),
                                                    //ItemCost = Convert.ToDecimal(row["Cost"]),
                                                    //ItemExpiryDate = Convert.ToDateTime(row["Expiry"] == DBNull.Value ? null : row["Expiry"]),
                                                    ////ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
                                                    //ItemSerialNo = row["SerialNo"].ToString(),
                                                    Year = Convert.ToInt32(row["Year"]),
                                                    NewYearInvoiceID = Convert.ToInt32(row["YearSequenceNo"]),
                                                    SupplierNo = Convert.ToInt32(row["AgentID"] == DBNull.Value ? 0 : row["AgentID"]),
                                                    //NewCost = Convert.ToDecimal(row["NewCost"]),
                                                    //Status = Convert.ToInt32(row["Status"]),

                                                }).ToList();
                }

            }
            return InvoiceReturnDetails;
        }

        public Boolean SavePurchaseReturn()
        {
            if (ObjPurReturnDAL.Save_Return_Purchase_Invoice(ObjPurchaseReturn))
                return true;
            else
                return false;
        }

        public List<PurchaseObjectClass> GetReturnInvoiceList()
        {
            List<PurchaseObjectClass> ReturnDetails = new List<PurchaseObjectClass>();
            DataTable dt = ObjPurReturnDAL.GetReturnInvoiceDetailsDAL(ObjPurchaseReturn.PurchaseReturnID);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ReturnDetails.Add(new PurchaseObjectClass
            //    {
            //        PurchaseReturnID = Convert.ToInt64(dt.Rows[i]["PurchaseReturnID"]),
            //        Year = Convert.ToInt32(dt.Rows[i]["Year"]),
            //        NewYearInvoiceID = Convert.ToInt32(dt.Rows[i]["YearSequenceNo"]),
            //        ItemName = dt.Rows[i]["ItemName"].ToString(),
            //        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
            //        ReturnDate = Convert.ToDateTime(dt.Rows[i]["ReturnDate"]),
            //        ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"] == DBNull.Value ? null : dt.Rows[i]["ExpiryDate"]),
            //        ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"]),
            //        ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
            //        //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
            //        ItemSerialNo = dt.Rows[i]["SerialNo"].ToString(),
            //        ItemUnitPrice = Convert.ToDecimal(dt.Rows[i]["Price"]),
            //        ItemTotal = Convert.ToDecimal(dt.Rows[i]["Total"]),
            //        ExpiryDate = Convert.ToBoolean(dt.Rows[i]["ExpiryDate1"]),
            //        User = dt.Rows[i]["CreatedBy"].ToString(),
            //        InvoiceNo = Convert.ToInt64(dt.Rows[i]["PurchaseInvoiceID"]),
            //        PurchaseDetailsId = Convert.ToInt32(dt.Rows[i]["PurchaseDetailID"]),
            //        Status = Convert.ToInt32(dt.Rows[i]["Status"]),
            //        NewCost = Convert.ToDecimal(dt.Rows[i]["NewCost"]),
            //        SupplierName = dt.Rows[i]["AgentName"].ToString(),
            //        ItemTotalStock = Convert.ToInt32(dt.Rows[i]["StockInHand"]),
            //        ItemCost = Convert.ToDecimal(dt.Rows[i]["Cost"]),
            //        PurchaseID = Convert.ToInt32(dt.Rows[i]["PurchaseID"]),
            //        ItemNumber = dt.Rows[i]["ItemNumber"].ToString(),
            //        Time = dt.Rows[i]["Time"].ToString()
            //    });
            //}
            if (dt!=null && dt.Rows.Count > 0)
            {
                ReturnDetails = (from DataRow row in dt.Rows
                                 select new PurchaseObjectClass
                                     {
                                         PurchaseReturnID = Convert.ToInt64(row["PurchaseReturnID"]),
                                         Year = Convert.ToInt32(row["Year"]),
                                         NewYearInvoiceID = Convert.ToInt32(row["YearSequenceNo"]),
                                         ItemName = row["ItemName"].ToString(),
                                         ItemNo = Convert.ToInt32(row["ItemID"]),
                                         ReturnDate = Convert.ToDateTime(row["ReturnDate"]),
                                         ItemExpiryDate = Convert.ToDateTime(row["ExpiryDate"] == DBNull.Value ? null : row["ExpiryDate"]),
                                         ItemExpiry = Convert.ToDateTime(row["ExpiryDate"] == DBNull.Value ? null : row["ExpiryDate"]) == DateTime.MinValue ? "-" : Convert.ToDateTime(row["ExpiryDate"]).ToString().Split(' ').Length > 2 ? Convert.ToDateTime(row["ExpiryDate"]).ToString().Split(' ')[1] : Convert.ToDateTime(row["ExpiryDate"]).ToString().Split(' ')[0],
                                         ItemPackage = Convert.ToInt32(row["PackageQty"] == DBNull.Value ? 0 : row["PackageQty"]),
                                         ItemQuantity = Convert.ToInt32(row["Quantity"]),
                                         //ItemSerialNo = Convert.ToInt64(dt.Rows[i]["SerialNo"]),
                                         ItemSerialNo = row["SerialNo"].ToString(),
                                         ItemUnitPrice =Convert.ToDecimal(Convert.ToDecimal(row["Price"]).ToString("#####0.000")),
                                         ItemTotal =Convert.ToDecimal(Convert.ToDecimal(row["Total"]).ToString("#####0.000")),
                                         ExpiryDate = Convert.ToBoolean(row["ExpiryDate1"]),
                                         User = row["CreatedBy"].ToString(),
                                         InvoiceNo = Convert.ToInt64(row["PurchaseInvoiceID"]),
                                         PurchaseDetailsId = Convert.ToInt32(row["PurchaseDetailID"]),
                                         Status = Convert.ToInt32(row["Status"]),
                                         NewCost = Convert.ToDecimal(Convert.ToDecimal(row["NewCost"]).ToString("#####0.000")),
                                         SupplierName = row["AgentName"].ToString(),
                                         ItemTotalStock = Convert.ToInt32(row["StockInHand"]),
                                         ItemCost = Convert.ToDecimal(Convert.ToDecimal(row["Cost"]).ToString("#####0.000")),
                                         PurchaseID = Convert.ToInt32(row["PurchaseID"]),
                                         ItemNumber = row["ItemNumber"].ToString(),
                                         Time = row["Time"].ToString()
                                     }).ToList();
            }
            return ReturnDetails;
        }

        public object GetStockInCount()
        {
            DataTable dt = ObjPurReturnDAL.GetItemNameCostInfo(ObjPurchaseReturn);
            if (dt != null && dt.Rows.Count > 0)
            {
                StockCount = dt.Rows[0]["StockInHand"];
            }
            return StockCount;
        }

        public List<PurchaseObjectClass> LoadPurchaseReturnList()
        {
            DataTable dt = ObjPurReturnDAL.GetReturnPurchase(ObjPurchaseReturn.PurchaseReturnID);
            List<PurchaseObjectClass> returnDetails = new List<PurchaseObjectClass>();
            this.LoadInvoiceDataByInvoiceItem(returnDetails, dt);
            return returnDetails;
        }

        public Boolean CloseInvoice()
        {
            if (ObjPurReturnDAL.Close_Purchase_Return(ObjPurchaseReturn))
                return true;
            else
                return false;
        }

        public Boolean ModifyInvoice()
        {
            if (ObjPurReturnDAL.Modify_Purchase_Return(ObjPurchaseReturn.PurchaseReturnID))
                return true;
            else
                return false;
        }

        public Boolean UndoReturnPurchaseInvoice()
        {
            if (ObjPurReturnDAL.Undo_Purchase_Return(ObjPurchaseReturn))
                return true;
            else
                return false;
        }

        public object GetReturnInvoiceNoBasedID()
        {
            object ReturnID = StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjPurchaseReturn.Year, ObjPurchaseReturn.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.PurchaseReturn));
            return ReturnID;
        }

        public List<float> CheckBalance()
        {
            List<float> ballist = new List<float>();
            DataTable dt = ObjPurReturnDAL.BalanceCheck(ObjPurchaseReturn.PurchaseReturnID);
            if (dt != null)
            {
                ballist.Add(float.Parse(dt.Rows[0]["Net"].ToString()));
                ballist.Add(float.Parse(dt.Rows[0]["Balance"].ToString()));
                ballist.Add(float.Parse(dt.Rows[0]["Paid"].ToString()));
            }
            return ballist;
        }
        public List<long> GetInvoiceNoForEmptyRecord()
        {
            DataTable dt = StoredProcedurers.Get_NewYearNo(ObjPurchaseReturn.PurchaseReturnID, ObjPurchaseReturn.InvoiceFlag);
            List<long> EmptyRecordId = new List<long>();
            if (dt != null && dt.Rows.Count > 0)
            {
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["PurchaseReturnID"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["Year"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["YearSequenceNo"]));
            }
            return EmptyRecordId;
        }

        public DataTable GetReportValue()
        {
            return ObjPurReturnDAL.ReportValues(ObjPurchaseReturn.PurchaseReturnID);
        }
        public int GetPurchaseID()
        {
            return ObjPurReturnDAL.GetPurchaseIdWithYearSequenceNo(ObjPurchaseReturn);
        }
    }
}
