using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;
using System.Data.SqlClient;
using CommonHelper;

namespace BALHelper
{
    public class PurchaseBALClass
    {
        PurchaseDALClass ObjDALClass;
        PurchaseObjectClass purchaseObjectClass;
        SpendingObjectClass ObjSpending;
        SpendingDALClass ObjSpendingDAL;
        DataSet ds = new DataSet();

        object InvNo;

        public PurchaseBALClass()
        {
            ObjDALClass = new PurchaseDALClass();
            //ObjSpending = new SpendingObjectClass();Commended on 23/06/2014 to fix the performance issue By Meena.R
            //ObjSpendingDAL = new SpendingDALClass();
            //ObjDALClass.LoadPurchaseData();Commanded on 21/06/2014
        }

        public PurchaseObjectClass ObjPurchase
        {
            get { return purchaseObjectClass; }
            set { purchaseObjectClass = value; }
        }

        public void SetCommonObject()
        {
            purchaseObjectClass = new PurchaseObjectClass();
        }
        /// <summary>
        /// Key Sequence ID Generation
        /// </summary>
        /// <returns></returns>
        public List<PurchaseObjectClass> GetPurchaseLoad()
        {
            List<PurchaseObjectClass> list = ObjDALClass.GetPurchaseLoadData();
            return list;
        }

        public List<long> GetInvoiceID()
        {
            List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Purchase));
            return list;
        }

        public List<PurchaseObjectClass> GetLoadData()
        {
            // PurchaseDALClass.LoadPurchaseData();
            //List<PurchaseObjectClass> List = new List<PurchaseObjectClass>(); // Performance Fine tuning done by Praba on 18Nov
            //List = PurchaseDALClass.PurchaseItemLoad(List, result);
           // List = ObjDALClass.LoadPurchaseData();

            return ObjDALClass.LoadNewPurchaseData();

            //ds= ObjDALClass.GetPurchaseLoad();
            //return ds;
        }


        public DataTable LoadItem()
        {
            // PurchaseDALClass.LoadPurchaseData();
            //List<PurchaseObjectClass> List = new List<PurchaseObjectClass>(); // Performance Fine tuning done by Praba on 18Nov
            //List = PurchaseDALClass.PurchaseItemLoad(List, result);
            // List = ObjDALClass.LoadPurchaseData();

            return ObjDALClass.LoadItem();

            //ds= ObjDALClass.GetPurchaseLoad();
            //return ds;
        }


        public List<PurchaseObjectClass> GetPurchaseListDetails()
        {
            ObjDALClass.LoadPurchaseData();
            ///List<PurchaseObjectClass> PurchaseDetails = PurchaseDALClass.PurchaseDetails;
            /// Performance Fine tuning done by Praba on 18Nov
            //List<PurchaseObjectClass> PurchaseDetails = ObjDALClass.PurchaseInvoiceDetails();
            //return PurchaseDetails;
            return ObjDALClass.PurchaseInvoiceDetails();
        }

        //public List<int> LoadInvoiceNo()
        //{
        //    List<int> List = PurchaseDALClass.MaxMinNo;
        //    return List;

        //}
        public object GetInvoiceNo()
        {
            InvNo = ObjDALClass.GetNewInvoiceNo();
            return InvNo;
        }

        public void LoadItemDetails()
        {
            ObjDALClass.GetItemDetails();
        }

        public Boolean SavePurchase()
        {
            if (ObjDALClass.Save_Purchase_Invoice(ObjPurchase) > 0)
                return true;
            else
                return false;
        }

        public Boolean SavePurchaseDetailDT(DataTable dt)
        {
            if (ObjDALClass.SaveSaleDetailOnCloseDT(dt))
                return true;
            else
                return false;
        }

        public Boolean ModifyPurchase()
        {
            if (StoredProcedurers.ModifyInvoice(ObjPurchase.InvoiceNo, ObjPurchase.InvoiceFlag) > 0)
                return true;
            else
                return false;
        }

        public List<PurchaseObjectClass> GetItemDetails()
        {
            List<PurchaseObjectClass> ItemDetailsList = StoredProcedurers.GetItemNameInfo(ObjPurchase);
            return ItemDetailsList;
        }

        public List<PurchaseObjectClass> InvoiceDetails()
        {
            List<PurchaseObjectClass> PurDetails = ObjDALClass.GetPurchaseInvoiceDetails(ObjPurchase);
            return PurDetails;
        }

        public List<PurchaseObjectClass> CheckExpiry()
        {
            List<PurchaseObjectClass> Expiry = ObjDALClass.checkforexpiry(ObjPurchase);
            return Expiry;
        }

        public Object GetDeleteStockCount()
        {
            object Stock = ObjDALClass.stock_for_Delete(ObjPurchase);
            return Stock;
        }

        public Boolean StockDelete()
        {
            if (ObjDALClass.Delete_Stock_Details(ObjPurchase) > 0)
                return true;
            else
                return false;
        }
        public Boolean SaveStock()
        {
            if (ObjDALClass.Save_Stock_Details(ObjPurchase) > 0)
                return true;
            else
                return false;

        }

        public List<long> GetMaxMinInvoiceID()
        {
            List<long> ID = StoredProcedurers.GetMinMaxID(Convert.ToInt32(CommonHelper.Table.Purchase));
            //return (List<int>)ConvertionHelper.ConvertToList<int>(dt);
            //List<long> ID = new List<long>();
            //ID.Add(Convert.ToInt64(ds.Tables[0].Rows[0]["MinID"] == DBNull.Value ? 0 : ds.Tables[0].Rows[0]["MinID"]));
            //ID.Add(Convert.ToInt64(ds.Tables[0].Rows[0]["MaxID"] == DBNull.Value ? 0 : ds.Tables[0].Rows[0]["MaxID"]));
            //ID.Add(Convert.ToInt64(ds.Tables[1].Rows[0]["YearValue"] == DBNull.Value ? 0 : ds.Tables[1].Rows[0]["YearValue"]));
            return ID;
        }

        public DataTable GetPurchasePaidRemainingBal()
        {
            return ObjDALClass.GetPurchasePaidRemainingByID(ObjPurchase);
        }
        public List<long> GetInvoiceNoForEmptyRecord()
        {
            DataTable dt = StoredProcedurers.Get_NewYearNo(ObjPurchase.InvoiceNo, ObjPurchase.InvoiceFlag);
            List<long> EmptyRecordId = new List<long>();
            if (dt != null && dt.Rows.Count > 0)
            {
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["PurchaseInvoiceID"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["Year"]));
                EmptyRecordId.Add(Convert.ToInt64(dt.Rows[0]["YearSequenceNo"]));
                ObjPurchase.SupplierNo = Convert.ToInt32(dt.Rows[0]["AgentID"]);
            }
            return EmptyRecordId;
        }

        public Boolean GetPaymentDate()
        {
            DataTable dt = new DataTable();
            dt = ObjDALClass.CheckPayment(ObjPurchase);
            if (dt.Rows.Count == 0)
                return true;
            else
                return false;
        }

        public Boolean UpdatePayment()
        {
            if (ObjDALClass.Update_PurchasePaymentDate(ObjPurchase) > 0)
                return true;
            else
                return false;
        }

        public List<PurchaseObjectClass> GetPurchaseBalance()
        {
            ObjPurchase.AccountID = 2;
            List<PurchaseObjectClass> purlist = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetPurchaseBalance(ObjPurchase.InvoiceNo, ObjPurchase.AccountID);
            if (dt != null && dt.Rows.Count > 0)
            {
                purlist.Add(new PurchaseObjectClass
                {
                    PurchaseID = Convert.ToInt32(dt.Rows[0]["PurchaseID"]),
                    SupplierNo = Convert.ToInt32(dt.Rows[0]["AgentID"]),
                    Balance = Convert.ToDecimal(dt.Rows[0]["Balance"]),
                    Status = Convert.ToInt32(dt.Rows[0]["Status"])
                });
            }
            return purlist;
        }

        public List<PurchaseObjectClass> GetItemNameBasedOnID()
        {
            List<PurchaseObjectClass> objItemName = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetItemBasedOnComCat(ObjPurchase.CategoryNo, ObjPurchase.AccountID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objItemName.Add(new PurchaseObjectClass
                {
                    ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                    ItemName = dt.Rows[i]["ItemName"].ToString(),
                    IsHide = Convert.ToBoolean(dt.Rows[i]["IsHide"]),
                    ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
                });
            }
            return objItemName;

        }

        public object GetPurInvIDBasedOnNewYearID()
        {
            object Obj = StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjPurchase.Year, ObjPurchase.NewYearInvoiceID, Convert.ToInt32(CommonHelper.Table.Purchase));
            //ObjDALClass.GetInvoiceIDBasedonNewYearID(ObjPurchase);
            return Obj;
        }
        public List<PurchaseObjectClass> GetSerialNo()
        {
            List<PurchaseObjectClass> list = ObjDALClass.Get_ItemSerialNo_stock(ObjPurchase.ItemNo);
            return list;
        }

        public Boolean SerialNoSave()
        {
            if (ObjDALClass.Save_ItemSerialNo(ObjPurchase) > 0)
                return true;
            else
                return false;

        }

        public Boolean UpdateSerialNo(string XSerialNo)
        {
            if (ObjDALClass.Update_ItemSerialNo(ObjPurchase, XSerialNo) > 0)
                return true;
            else
                return false;
        }

        public List<PurchaseObjectClass> GetStockCount()
        {
            List<PurchaseObjectClass> StockNo = ObjDALClass.StockBasedSerialNo(ObjPurchase);
            return StockNo;
        }


        public List<PurchaseObjectClass> GetItemInfor()
        {
            List<PurchaseObjectClass> itemlist = ObjDALClass.GetItemInformation(ObjPurchase);
            return itemlist;
        }

        public DataTable GetAppliedIncreaseHelper(int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            return ObjDALClass.GetAppliedIncrease(CategoryID, CompanyID, ItemType, ItemNo);
        }

        public List<DateTime> GetExpiryDates()
        { return ObjDALClass.getExpiryDates(purchaseObjectClass); }

        public bool SaveAgentDetails()
        {
            AgentDetailObjectClass Obj = new AgentDetailObjectClass();
            AgentDetailDAL ObjDAL = new AgentDetailDAL();

            Obj.Name = ObjPurchase.SupplierName;
            Obj.AgtSupplier = "102";
            Obj.AgentType = "0|102|0|0";
            Obj.CreatedBy = GeneralFunction.UserId;
            Obj.ModifiedBy = GeneralFunction.UserId;
            Obj.Address = string.Empty;
            Obj.AgtBranch = "0";
            Obj.AgtClient = "0";
            Obj.AgtHideAgent = "0";
            Obj.DebtLimt = 0;
            Obj.Phoneno = string.Empty;
            Obj.PaymentDay = string.Empty;
            List<object> AgentAvailable = ObjDAL.Check_AgentNameAvailable(Obj);
            if (AgentAvailable != null && AgentAvailable.Count > 0)
            {
                GeneralFunction.Information("ExistsAgentName", "PurchaseInvoice");
                return false;
            }
            else
            {//return true;
                if (ObjDAL.SaveAgentdetails(Obj) > 0)
                    return true;
                else
                    return false;
            }
        }

        public void SaveExtraCost()
        {
            List<SpendingObjectClass> obj = new List<SpendingObjectClass>();
            ObjSpending = new SpendingObjectClass();
            ObjSpendingDAL = new SpendingDALClass();
            List<long> ID = new List<long>();
            ObjSpending.CreatedBy = GeneralFunction.UserId;
            ObjSpending.ModifiedBy = GeneralFunction.UserId;
            if (ObjPurchase.Extracost != 0)
            {
                obj = ObjSpendingDAL.Get_MaxIdOfSpendingRecord();
                if (obj[0].ExpensesID == 0)
                {
                    List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Expenses));
                    ObjSpending.ExpensesID = list[0];
                    ObjSpending.Year = Convert.ToInt32(list[1]);
                    ObjSpending.YearSequence = list[2];
                    ObjSpending.Description = string.Empty;
                    ObjSpending.Details = string.Empty;
                    ObjSpending.Notes = string.Empty;
                    ObjSpending.Value = 0.0m;
                    ObjSpending.ProcessDate = DateTime.Now;
                    if (ObjSpendingDAL.saveSpendings(ObjSpending))
                    {

                    }
                }
                obj.Clear();
                obj = ObjSpendingDAL.Get_MaxIdOfSpendingRecord();
                if (ObjPurchase.Extracost != 0)
                {
                    ObjSpending.ExpensesID = obj[0].ExpensesID;
                    ObjSpending.Description =GeneralFunction.ChangeLanguageforCustomMsg("ExtraCost");
                    ObjSpending.Details =GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoice")+" "+ ObjPurchase.InvoiceNo;
                    ObjSpending.Notes = GeneralFunction.ChangeLanguageforCustomMsg("Purchasesinvoiceextracost");
                    ObjSpending.Value = ObjPurchase.ItemGrossAmt;
                    ObjSpending.CreatedDate = DateTime.Now.Date;
                    ObjSpending.CreatedBy = GeneralFunction.UserId;
                    ObjSpending.ProcessDate = DateTime.Now.Date;
                    ObjSpending.Status = 1;
                    ObjSpending.Remove = 0;
                    if (ObjSpendingDAL.saveSpendings(ObjSpending))
                    {
                        //ObjSpending = new SpendingObjectClass();
                        ID = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(Table.Expenses));
                        ObjSpending.ExpensesID = ID[0];
                        ObjSpending.Description = string.Empty;
                        ObjSpending.Details = string.Empty;
                        ObjSpending.Notes = string.Empty;
                        ObjSpending.Value = 0.0m;
                        ObjSpending.ProcessDate = DateTime.Now;
                        if (ObjSpendingDAL.saveSpendings(ObjSpending))
                        {

                        }
                    }
                }
            }
        }

        public DataTable ReportValues()
        {
            return ObjDALClass.GetPurchaseReportValues(ObjPurchase.InvoiceNo);
        }

        public int SaveExportData(int OverWrite)
        {
            return ObjDALClass.Save_ExportItemDetails(ObjPurchase, OverWrite);
        }

        public DataTable BarcodeExistForItem()
        {
            return ObjDALClass.GetBarcodeExist(ObjPurchase);
        }

        public bool UpdateBarcode(int BarcodeID,string Barcode)
        {
            if (ObjDALClass.UpdateBarcode(BarcodeID, Barcode))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean UpdateStock(decimal ItemCost, DateTime? ExpiryDate, string SerialNo, int XBarcode, int XQuantity)
        {
            if (ObjDALClass.Update_Stock_Details(ObjPurchase, ItemCost, ExpiryDate, SerialNo, XBarcode, XQuantity) > 0)
                return true;
            else
                return false;
        }
        public Boolean AddStock(decimal ItemCost, DateTime? ExpiryDate, string SerialNo, int XBarcode, int XQuantity,int DiffQty)
        {
            if (ObjDALClass.AddStockOnly(ObjPurchase, ItemCost, ExpiryDate, SerialNo, XBarcode, XQuantity, DiffQty) > 0)
                return true;
            else
                return false;
        }
        public Boolean UpdatePurchase(decimal Cost, DateTime? ExpiryDate, string SerialNo, int XBarcode, int XBox, int StockSold, int older_box, int ExpiryInsert, int DeleteItem)
        {
            if (ObjDALClass.Update_Purchase_Invoice(ObjPurchase, Cost, ExpiryDate, SerialNo, XBarcode, XBox, StockSold, older_box, ExpiryInsert, DeleteItem) > 0)
                return true;
            else
                return false;
        }

        public List<PurchaseObjectClass> ItemDetailspopup()
        {
            DataSet ds = StoredProcedurers.Get_PackageItemDetails(ObjPurchase.ItemNo);
            DataTable dt = ds.Tables[0];
            List<PurchaseObjectClass> ItempopupDetails = new List<PurchaseObjectClass>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ItempopupDetails.Add(new PurchaseObjectClass
                    {
                        ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        ItemPrice = Convert.ToDecimal(dt.Rows[i]["Price"]),
                        UnitType = dt.Rows[i]["UnitType"] == DBNull.Value ? string.Empty : dt.Rows[i]["UnitType"].ToString(),
                        UnitName = dt.Rows[i]["UnitName"] == DBNull.Value ? string.Empty : dt.Rows[i]["UnitName"].ToString(),
                        ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"]),
                        ItemCost = Convert.ToDecimal(dt.Rows[i]["ItemCost"] == DBNull.Value ? 0.000m : dt.Rows[i]["ItemCost"]),
                        ItemType = Convert.ToInt32(dt.Rows[i]["ItemType"]),
                        BarcodeID = Convert.ToInt32(dt.Rows[i]["BarcodeID"]),
                        UnitTypeID = Convert.ToInt32(dt.Rows[i]["UnitTypesID"]),
                        ItemExpiry = string.Empty,
                        ItemQuantity = 0

                    });
                }
            }
            return ItempopupDetails;
        }
        ///////FIND PURCHASE INVOICE BAL CLASS\\\\\\\
        public List<PurchaseObjectClass> FindPurchaseList()
        {
            DataTable FindDt = ObjDALClass.GetFindPurchaseInvoice(ObjPurchase);
            List<PurchaseObjectClass> FindList = new List<PurchaseObjectClass>();
            for (int i = 0; i < FindDt.Rows.Count; i++)
            {
                FindList.Add(new PurchaseObjectClass
                {
                    PurchaseID = Convert.ToInt32(FindDt.Rows[i]["PurchaseID"]),
                    InvoiceNo = Convert.ToInt64(FindDt.Rows[i]["PurchaseInvoiceID"]),
                    PurchaseItemDate = Convert.ToDateTime(FindDt.Rows[i]["PurchaseDate"]).Date,
                    SupplierName = FindDt.Rows[i]["AgentName"].ToString(),
                    ReturnQty = Convert.ToInt32(FindDt.Rows[i]["Return"]),
                    ItemTotal = Convert.ToDecimal(Convert.ToDecimal(FindDt.Rows[i]["Total"]).ToString("#####0.000")),
                    Discount = Convert.ToDecimal(Convert.ToDecimal(FindDt.Rows[i]["Discount"]).ToString("#####0.000")),
                    ItemNet = Convert.ToDecimal(FindDt.Rows[i]["NetAmount"]),
                    Status = Convert.ToInt32(FindDt.Rows[i]["Status"]),
                    CreatedBy = Convert.ToInt32(FindDt.Rows[i]["CreatedBy"]),
                    User = FindDt.Rows[i]["Users"].ToString(),
                    Paid = Convert.ToDecimal(FindDt.Rows[i]["paid"]),
                    SetStatus = Convert.ToInt32(FindDt.Rows[i]["STATUS1"]),
                    NewYearInvoiceID = Convert.ToInt32(FindDt.Rows[i]["NEWINVNO"]),
                    Time = Convert.ToDateTime(FindDt.Rows[i]["PurchaseDate"]).TimeOfDay.ToString().Split('.')[0],
                    Year = Convert.ToInt32(FindDt.Rows[i]["Year"])
                });
            }
            return FindList;
        }

        public List<PurchaseObjectClass> FindReturnDetails()
        {
            List<PurchaseObjectClass> ReturnDetails = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetFindReturnInvoiceDetails(ObjPurchase.InvoiceNo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetValuesFromTable(ReturnDetails, dt, i);
                ReturnDetails[i].PurchaseReturnID = Convert.ToInt64(dt.Rows[i]["PurchaseReturnID"]);
            }
            return ReturnDetails;
        }

        private void GetValuesFromTable(List<PurchaseObjectClass> ReturnDetails, DataTable dt, int i)
        {
            ReturnDetails.Add(new PurchaseObjectClass
            {

                ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                SupplierNo = Convert.ToInt32(dt.Rows[i]["AgentID"] == DBNull.Value ? 0 : dt.Rows[i]["AgentID"]),
                ReturnQty = Convert.ToInt32(dt.Rows[i]["ReturnQty"]),
                Discount = Convert.ToDecimal(dt.Rows[i]["Discount"]),
                SetStatus = Convert.ToInt32(dt.Rows[i]["Status"]),
                ItemName = dt.Rows[i]["ItemName"].ToString(),
                ReturnDate = Convert.ToDateTime(dt.Rows[i]["ReturnDate"]),
                ItemExpiryDate = Convert.ToDateTime((dt.Rows[i]["ExpiryDate"] == DBNull.Value || Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]) == DateTime.MinValue) ? null : dt.Rows[i]["ExpiryDate"]),
                ItemExpiry = dt.Rows[i]["ExpiryDate"] == DBNull.Value ? "-" : Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).ToShortDateString(),
                ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"]),
                ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                ItemUnitPrice = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["UnitPrice"]).ToString("#####0.000")),
                ItemTotal = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["Total"]).ToString("####0.000")),
                User = dt.Rows[i]["CreatedBy"] == DBNull.Value ? "101" : dt.Rows[i]["CreatedBy"].ToString(),
                SalePrice = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["SalePrice"]).ToString("#####0.000")),
                ItemCost = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["Cost"]).ToString("#####0.000")),
                Status = Convert.ToInt32(dt.Rows[i]["STATUS1"]),
                Time = Convert.ToDateTime(dt.Rows[i]["ReturnDate"]).TimeOfDay.ToString().Split('.')[0],
                ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
            });
        }

        public List<PurchaseObjectClass> FindorderDetails()
        {
            List<PurchaseObjectClass> objorderList = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetFindOrderInvoiceDetails(ObjPurchase.InvoiceNo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetValuesFromTable(objorderList, dt, i);
                objorderList[i].PurchaseReturnID = Convert.ToInt64(dt.Rows[i]["OrderID"]);
            }
            return objorderList;
        }

        public List<PurchaseObjectClass> FindPurchaseInvoiceDetails()
        {
            List<PurchaseObjectClass> objPurchaseList = new List<PurchaseObjectClass>();
            DataTable dt = ObjDALClass.GetFindPurchaseInvoiceDetails(ObjPurchase.InvoiceNo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objPurchaseList.Add(new PurchaseObjectClass
                {
                    PurchaseReturnID = Convert.ToInt64(dt.Rows[i]["PurchaseInvoiceID"]),
                    ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]),
                    SupplierNo = Convert.ToInt32(dt.Rows[i]["AgentID"] == DBNull.Value ? 0 : dt.Rows[i]["AgentID"]),
                    ReturnQty = Convert.ToInt32(dt.Rows[i]["ReturnQuantity"] == DBNull.Value ? 0 : dt.Rows[i]["ReturnQuantity"]),
                    //Discount = Convert.ToDecimal(dt.Rows[i]["OriginalDiscount"]),Commanded on 06/06/2014
                    Discount = Convert.ToDecimal(dt.Rows[i]["Discount"]),
                    Status = Convert.ToInt32(dt.Rows[i]["Status"]),
                    ItemName = dt.Rows[i]["ItemName"].ToString(),
                    ReturnDate = Convert.ToDateTime(dt.Rows[i]["PurchaseDate"]),
                    ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"] == DBNull.Value ? null : dt.Rows[i]["ExpiryDate"]),
                    ItemExpiry = dt.Rows[i]["ExpiryDate"] == DBNull.Value ? "-" : Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).ToShortDateString(),
                    ItemPackage = Convert.ToInt32(dt.Rows[i]["PackageQty"] == DBNull.Value ? 0 : dt.Rows[i]["PackageQty"]),
                    ItemQuantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                    ItemUnitPrice = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["UnitPrice"]).ToString("#####0.000")),
                    ItemTotal = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["Total"]).ToString("#####0.000")),
                    User = dt.Rows[i]["UserName"].ToString(),
                    SalePrice = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["SalePrice"]).ToString("#####0.000")),
                    ItemCost = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["Cost"]).ToString("#####0.000")),
                    //Time = Convert.ToDateTime(dt.Rows[i]["PurchaseDate"]).TimeOfDay.ToString().Split('.')[0],
                    Time = dt.Rows[i]["Time"].ToString(),
                    ItemNumber = dt.Rows[i]["ItemNumber"].ToString()
                });
            }
            return objPurchaseList;
        }

        public DataTable GetBarcodeGetBarcode(int ItemID, int PackageQty, int BarcodeID)
        {
            return ObjDALClass.GetBarcode(ItemID, PackageQty, BarcodeID);
        }

        public DataTable FindReportDetails()
        {
            return ObjDALClass.GetReportfotFind(ObjPurchase);
        }

        public static DataTable ReorderItems()
        {
            return PurchaseDALClass.GetReorderItems();
        }

        public DataTable FindPurchaseInvoice()
        { return ObjDALClass.DetailedPurchaseInvoice(ObjPurchase.Reason); }

        public DataTable ItemSerialNo()
        {
            return ObjDALClass.GetItemSerialNo();
        }

        public DataSet updatestatus(decimal cost,DateTime? Expiry,string serial,int barcode,int Oqty)
        {
            return ObjDALClass.CheckForUpdate(ObjPurchase, cost, Expiry, serial, barcode, Oqty);
        }

        public float IsIncreaseForAgent()
        {
            return ObjDALClass.IsIncreaseForAgent(ObjPurchase);
        }

        public Boolean CheckDuplicateBarCode(string Barcode)
        {
            if (ObjDALClass.Check_DuplicateBarCode(Barcode))
            {
                return true;

            }
            return false;

        }
    }
}
