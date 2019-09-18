using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.Interface;
using System.Windows.Forms;
using BALHelper;
using System.Data;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using System.Configuration;
using System.Drawing.Printing;

namespace BumedianBM.ViewHelper
{
    public class PurchaseInvoiceHelper
    {

        PurchaseBALClass objbalClass;
        public System.Data.DataSet ds = new DataSet();
        internal Item_Serial_Number objSerial;
        internal Item_Information ObjItemInfo;
        internal ItemDetails ObjItemDetails;
        //internal int MAXNO, MINNO;
        internal int IDFlag;
        internal bool IsfromNewInv;
        internal object InvoiceNo;
        internal List<PurchaseObjectClass> InsertDetails = new List<PurchaseObjectClass>();
        //internal List<PurchaseObjectClass> DataGridList = new List<PurchaseObjectClass>();  // Memory Leak tuning by Praba on 18Nov2014
        internal List<PurchaseObjectClass> CheckExpiry = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> PackageQty = new List<PurchaseObjectClass>();
        internal List<long> ID = new List<long>();
        internal List<long> InvoiceID = new List<long>();
        internal string DgvColor, ControlName;
        internal int DgvCount, EnableExpiry, Index = -1, XBarcodeID, XQuantity, XBox, ImportMethod;
        internal bool isFromelse, isFromGridUpdate = false, isPackage = false, ProgressStatus;
        decimal Sum, TotalExtraCost, t1, t2;
        internal decimal piececost, boxcost = 0, XItemCost, XCost, ItemCost, ItemUnitPrice, itemtax;
        internal DateTime? XExpiry;
        public int listIndex;
        public int StockSold = 0;
        DataTable dt;
        ReportsView Obj_viewer;
        // internal long XSerialNo;
        internal string XSerialNo;
        //payreceipt form open through purchase invoice to set the focus of payreceipt controls 
        public static bool UnderPurchaseInvoice = true;
        public PurchaseInvoiceHelper()
        {
            objbalClass = new PurchaseBALClass();
            objbalClass.SetCommonObject();
            //NewButtonInvoiceNo();
            objSerial = new Item_Serial_Number();
            ObjItemInfo = new Item_Information();
            ObjItemDetails = new ItemDetails("Purchase");
            ID = ObjBALClass.GetMaxMinInvoiceID();
        }

        public PurchaseBALClass ObjBALClass
        {
            get { return objbalClass; }
            set { objbalClass = value; }
        }

        //internal void NewButtonInvoiceNo() Hide to solve the Performance Issue
        //{
        //    List<int> mmlist = ObjBALClass.LoadInvoiceNo();
        //    // MAXNO = mmlist[0];
        //    // MINNO = mmlist[1];
        //}

        internal void NewbtnYearInvoice()
        {
            InvoiceID = ObjBALClass.GetInvoiceID();
            ID[1] = InvoiceID[0];
        }

        internal void LoadPurchseInvoiceData()
        {
            List<PurchaseObjectClass> LoadPurData = new List<PurchaseObjectClass>();
            try
            {
                LoadPurData = ObjBALClass.GetPurchaseLoad();
                if (LoadPurData.Count > 0)
                {
                    //foreach (var list in LoadPurData)
                    //{
                    //    ObjBALClass.ObjPurchase.InvoiceNo = list.InvoiceNo;
                    //    ObjBALClass.ObjPurchase.Year = list.Year;
                    //    ObjBALClass.ObjPurchase.NewYearInvoiceID = list.NewYearInvoiceID;
                    //    ObjBALClass.ObjPurchase.SupplierNo = list.SupplierNo;
                    //}

                    ObjBALClass.ObjPurchase.InvoiceNo = LoadPurData[0].InvoiceNo;
                    ObjBALClass.ObjPurchase.Year = LoadPurData[0].Year;
                    ObjBALClass.ObjPurchase.NewYearInvoiceID = LoadPurData[0].NewYearInvoiceID;
                    ObjBALClass.ObjPurchase.SupplierNo = LoadPurData[0].SupplierNo;
                    objbalClass.ObjPurchase.ExchangeRate = LoadPurData[0].ExchangeRate;
                    ObjBALClass.ObjPurchase.InNo = LoadPurData[0].InNo;
                    LoadInvoiceDataBasedOnID();


                }
                else
                {
                    InvoiceID = ObjBALClass.GetInvoiceID();
                    if (InvoiceID.Count > 0)
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(InvoiceID[0]);
                        ObjBALClass.ObjPurchase.Year = Convert.ToInt32(InvoiceID[1]);
                        ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(InvoiceID[2]);
                        IsfromNewInv = true;
                        SavePurchaseDetails();
                        ID[1] = ObjBALClass.ObjPurchase.InvoiceNo;
                        isFromelse = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                LoadPurData = null;
            }
        }

        internal void LoadInvoiceDataBasedOnID()
        {

            List<PurchaseObjectClass> PurDetails;
            try
            {
                InsertDetails.Clear();

                PurDetails = ObjBALClass.InvoiceDetails();
                if (PurDetails.Count > 0)
                {
                    InsertDetails = PurDetails.ToList();
                    //foreach (var list in PurDetails)
                    //{
                    //    //int i = -1;
                    //    //ObjBALClass.ObjPurchase.SupplierName = list.SupplierName;
                    //    //ObjBALClass.ObjPurchase.SupplierNo = list.SupplierNo;
                    //    //ObjBALClass.ObjPurchase.ItemNet = list.ItemNet;
                    //    //ObjBALClass.ObjPurchase.Status = list.Status;
                    //    //ObjBALClass.ObjPurchase.PurchaseItemDate = list.PurchaseItemDate;Commanded on 21/06/2014 to fix the performance Issue Done by Meena.R
                    //    //ObjBALClass.ObjPurchase.DiscountType = list.DiscountType;
                    //    //ObjBALClass.ObjPurchase.NewYearInvoiceID = list.NewYearInvoiceID;
                    //    //ObjBALClass.ObjPurchase.Year = list.Year;
                    //    //ObjBALClass.ObjPurchase.Discount = Convert.ToDecimal(list.Discount.ToString("#####0.000"));
                    //    //ObjBALClass.ObjPurchase.ItemDiscount = list.ItemDiscount;
                    //    //ObjBALClass.ObjPurchase.originaldiscount = list.originaldiscount;
                    //    //ObjBALClass.ObjPurchase.ItemCost = list.ItemCost;
                    //    //ObjBALClass.ObjPurchase.ItemGrossAmt = list.ItemGrossAmt;
                    //    //ObjBALClass.ObjPurchase.Note = list.Note;
                    //    //ObjBALClass.ObjPurchase.ItemPaymentDate = list.ItemPaymentDate;
                    //    if (InsertDetails.Count > 0)
                    //    {
                    //        i = InsertDetails.FindIndex(a => (a.ItemNo == list.ItemNo) && (a.ItemDescription == list.ItemName) && (a.ItemExpiry == (list.ItemExpiryDate == DateTime.MinValue ? "-" : list.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == list.ItemUnitPrice) && (a.ItemSerialNo == list.ItemSerialNo));
                    //        if (i != -1)
                    //        {
                    //            InsertDetails[i].ItemQuantity = InsertDetails[i].ItemQuantity + list.ItemQuantity;
                    //            InsertDetails[i].ItemTotal = InsertDetails[i].ItemUnitPrice * InsertDetails[i].ItemQuantity;
                    //            InsertDetails[i].Box = InsertDetails[i].ItemQuantity / (InsertDetails[i].ItemPackage != 0 ? InsertDetails[i].ItemPackage : 1);
                    //        }
                    //    }
                    //    if (i == -1)
                    //    InsertDetails.Add(new PurchaseObjectClass
                    //    {
                    //        ItemNo = list.ItemNo,
                    //        ItemDescription = list.ItemName,
                    //        ItemExpiry = list.ItemExpiryDate.ToString() == DateTime.MinValue.ToString() ? "-" : (list.ItemExpiryDate).Value.ToShortDateString(),
                    //        ItemExpiryDate = list.ItemExpiryDate == DateTime.MinValue ? null : list.ItemExpiryDate,
                    //        ItemPackage = list.ItemPackage,
                    //        ItemQuantity = list.ItemQuantity,
                    //        Box = (list.ItemQuantity % (list.ItemPackage == 0 ? 1 : list.ItemPackage)) == 0 ? list.ItemQuantity / (list.ItemPackage == 0 ? 1 : list.ItemPackage) : 0, On 16/05/2014
                    //        Box = list.Box,
                    //        ItemUnitPrice = Convert.ToDecimal(list.ItemUnitPrice.ToString("#####0.000")),
                    //        ItemTotal = Convert.ToDecimal(list.ItemTotal.ToString("#####0.000")),
                    //        ItemSerialNo = list.ItemSerialNo,
                    //        ItemCost = Convert.ToDecimal(list.ItemCost.ToString("####0.000")),
                    //        ItemDiscount = Convert.ToDecimal(list.ItemDiscount.ToString("#####0.000")),
                    //        NewCost = list.NewCost,
                    //        SalePrice = list.SalePrice,
                    //        ItemNumber = list.ItemNumber,
                    //        Time = list.Time,
                    //        BarcodeID = list.BarcodeID,
                    //        ItemTax1 = list.ItemTax1,
                    //        ItemTax2 = list.ItemTax2,
                    //        ItemTax1SubAmount = list.ItemTax1SubAmount,
                    //        ItemTax2SubAmount = list.ItemTax2SubAmount
                    //    });

                    //}
                    ObjBALClass.ObjPurchase.SupplierName = PurDetails[0].SupplierName;
                    ObjBALClass.ObjPurchase.SupplierNo = PurDetails[0].SupplierNo;
                    ObjBALClass.ObjPurchase.ItemNet = PurDetails[0].ItemNet;
                    ObjBALClass.ObjPurchase.Status = PurDetails[0].Status;
                    ObjBALClass.ObjPurchase.PurchaseItemDate = PurDetails[0].PurchaseItemDate;
                    ObjBALClass.ObjPurchase.DiscountType = PurDetails[0].DiscountType;
                    ObjBALClass.ObjPurchase.NewYearInvoiceID = PurDetails[0].NewYearInvoiceID;
                    ObjBALClass.ObjPurchase.Year = PurDetails[0].Year;
                    ObjBALClass.ObjPurchase.Discount = Convert.ToDecimal(PurDetails[0].Discount.ToString("#####0.000"));
                    ObjBALClass.ObjPurchase.ItemDiscount = PurDetails[0].ItemDiscount;
                    ObjBALClass.ObjPurchase.originaldiscount = PurDetails[0].originaldiscount;
                    ObjBALClass.ObjPurchase.ItemCost = PurDetails[0].ItemCost;
                    ObjBALClass.ObjPurchase.ItemGrossAmt = PurDetails[0].ItemGrossAmt;
                    ObjBALClass.ObjPurchase.Note = PurDetails[0].Note;
                    ObjBALClass.ObjPurchase.ItemPaymentDate = PurDetails[0].ItemPaymentDate;
                    ObjBALClass.ObjPurchase.ExchangeRate = PurDetails[0].ExchangeRate;
                    objbalClass.ObjPurchase.InNo= PurDetails[0].InNo;
                    decimal total = 0.000m;
                    for (int i = 0; i < InsertDetails.Count; i++)
                    {
                        if (InsertDetails[i].Box == 0)
                        {
                            total = total + ((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount) * InsertDetails[i].ItemQuantity);
                        }
                        else if (InsertDetails[i].Box != 0)
                        {
                            total = total + ((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount) * InsertDetails[i].ItemQuantity); //total = total + ((InsertDetails[i].ItemCost) * InsertDetails[i].Box);
                        }
                    }
                    if (ObjBALClass.ObjPurchase.Status == 2 && ObjBALClass.ObjPurchase.Discount >= 0)
                    {
                        ObjBALClass.ObjPurchase.ItemTotal = 0;
                        ObjBALClass.ObjPurchase.ItemTotal = total;
                        //for (int i = 0; i < InsertDetails.Count; i++)
                        //{
                        //    ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemTotal + (InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount) * InsertDetails[i].ItemQuantity;
                        //}

                    }
                    else
                    {
                        // ObjBALClass.ObjPurchase.Discount = ObjBALClass.ObjPurchase.originaldiscount = ObjBALClass.ObjPurchase.ItemCost = 0;// commended on 08/05/2014
                        ObjBALClass.ObjPurchase.ItemCost = 0;
                        if (ObjBALClass.ObjPurchase.Discount == 0)
                            this.DiscountAdjustment();
                        else
                        {
                            ObjBALClass.ObjPurchase.ItemTotal = total;
                            ObjBALClass.ObjPurchase.Discount = ObjBALClass.ObjPurchase.originaldiscount;
                            Discount();
                        }
                    }
                    if ((GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem == "Y" && ObjBALClass.ObjPurchase.Discount > 0) || ObjBALClass.ObjPurchase.Status != 2)
                    {
                        RevertDiscount();
                    }
                }
                else
                {
                    ObjBALClass.ObjPurchase.InvoiceFlag = "PurchaseInvoice";
                    List<long> ID = ObjBALClass.GetInvoiceNoForEmptyRecord();
                    if (ID.Count > 0)
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = ID[0];
                        ObjBALClass.ObjPurchase.Year = Convert.ToInt32(ID[1]);
                        ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(ID[2]);
                        //ObjBALClass.ObjPurchase.SupplierName = string.Empty;
                        //ObjBALClass.ObjPurchase.SupplierNo = 0;
                        ObjBALClass.ObjPurchase.ItemNet = ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.originaldiscount = 0;
                        ObjBALClass.ObjPurchase.PurchaseItemDate = DateTime.Now.Date;
                        ObjBALClass.ObjPurchase.Status = 1;
                    }
                    else
                    {

                        //GeneralFunction.Information("Recordnotfound", "PurchaseInvoice");

                        switch ((InvoiceFlag)invFlagStatus)
                        {
                            case InvoiceFlag.First:
                                ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo + 1;
                                break;
                            case InvoiceFlag.Next:
                                ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo + 1;
                                break;
                            case InvoiceFlag.Last:
                                ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo - 1;
                                break;
                            case InvoiceFlag.Previous:
                                ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo - 1;
                                break;
                        }

                        if (ObjBALClass.ObjPurchase.InvoiceNo > 0)
                        {
                            LoadInvoiceDataBasedOnID();
                        }
                        else
                        {
                            GeneralFunction.Information("Recordnotfound", "PurchaseInvoice");
                        }
                        ObjBALClass.ObjPurchase.Status = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PurDetails = null;
            }
        }

        internal List<ObjectHelper.PurchaseObjectClass> FillItemDetails()
        {

            //List<PurchaseObjectClass> LoadItemList = objbalClass.GetLoadData();

            List<PurchaseObjectClass> LoadItemList = objbalClass.GetLoadData();
            ///below condition added to fix the hide and show the hid items
            if (GeneralOptionSetting.FlagShowHidenItem == "N")
            {
                LoadItemList = LoadItemList.Where(a => a.IsHide == false).ToList();
            }
            else
            {
                LoadItemList = LoadItemList.Where(a => a.IsHide == true || a.IsHide == false).ToList();
            }
            return LoadItemList;

        }


        internal DataTable LoadItem()
        {

            //List<PurchaseObjectClass> LoadItemList = objbalClass.GetLoadData();

            DataTable LoadItemList = objbalClass.LoadItem();
            DataView dataview = new DataView(LoadItemList);
            ///below condition added to fix the hide and show the hid items
            if (GeneralOptionSetting.FlagShowHidenItem == "N")
            {
                dataview.RowFilter = "IsHide='" + 0 + "'";
                LoadItemList = dataview.ToTable();
            }
            else
            {
                dataview.RowFilter = "IsHide='" + 0 + "' OR IsHide='" + 1 + "'";
                LoadItemList = dataview.ToTable();
            }

            return LoadItemList;

        }

        internal object NewInvoiceNo()
        {
            InvoiceNo = ObjBALClass.GetInvoiceNo();
            return InvoiceNo;
        }

        internal void SavePurchaseDetails()
        {
            if (IsfromNewInv)
            {
                InsertDetails.Clear();
                ObjBALClass.ObjPurchase.ItemName = string.Empty;
                ObjBALClass.ObjPurchase.ItemNo = 0;
                ObjBALClass.ObjPurchase.AccountID = 1;
                ObjBALClass.ObjPurchase.ItemBalance = Convert.ToDecimal(0.0);
                ObjBALClass.ObjPurchase.ItemGrossAmt = Convert.ToDecimal(0.0);
                ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(0.0);
                ObjBALClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.Status = 1;
                ObjBALClass.ObjPurchase.SetStatus = 0;
                ObjBALClass.ObjPurchase.BatchID = 1;
                ObjBALClass.ObjPurchase.ItemUnitPrice = Convert.ToDecimal(0.0);
                ObjBALClass.ObjPurchase.ItemSerialNo = "0";
                ObjBALClass.ObjPurchase.originaldiscount = 0;
                ObjBALClass.ObjPurchase.ItemPaymentDate = DateTime.Now.Date;
                ObjBALClass.ObjPurchase.PurchaseItemDate = DateTime.Now;
                ObjBALClass.ObjPurchase.ExchangeRate = 0;
                ObjBALClass.ObjPurchase.InNo = "";

                if (objbalClass.SavePurchase())
                {
                    // MessageBox.Show("");
                }
            }
        }

        internal void CheckInsertItem()
        {
            List<PurchaseObjectClass> PurInvoice;
            try
            {
                PurInvoice = new List<PurchaseObjectClass>();
                PurInvoice = ObjBALClass.InvoiceDetails();
                if (ValidateItem() == true)
                {
                    if (DgvColor == "Color [WhiteSmoke]")
                    {
                        if (ObjBALClass.ObjPurchase.ItemType == 2)
                        {
                            if (PurInvoice.Count == 0 || DgvColor == "Color [WhiteSmoke]")
                            {
                                objSerial.ItemName = ObjBALClass.ObjPurchase.ItemName;
                                objSerial.ItemID = ObjBALClass.ObjPurchase.ItemNo;
                                objSerial.ShowDialog();
                                if (objSerial.Status == true)
                                {
                                    CheckandInsertData();
                                }
                                else
                                { GeneralFunction.Information("MustSaveItemSerialNo", "PurchaseInvoice"); }
                            }
                            else
                                GeneralFunction.Information("CantModifyClosedInvoice", "PurchaseInvoice");
                        }
                        else
                        {
                            if (PurInvoice.Count == 0 || DgvColor == "Color [WhiteSmoke]")
                            {
                                CheckandInsertData();
                            }
                        }
                    }
                    else
                        GeneralFunction.Information("CantModifyClosedInvoice", "PurchaseInvoice");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PurInvoice = null;
            }
        }

        internal void CheckandInsertData()
        {
            if (ObjBALClass.ObjPurchase.ExpiryDate == true)
            {
                //string noww = DateTime.Now.ToShortDateString().ToString();Commended on 13Nov2014 it shows the datetime exception
                string noww = string.Empty;
                string[] check = DateTime.Now.ToString().Split(' ');
                if (check.Length > 2)
                    noww = check[1];
                else if (check.Length == 2)
                    noww = check[0];
                else
                    noww = DateTime.Now.ToString();
                string[] exp = ObjBALClass.ObjPurchase.ItemExpiryDate.ToString().Split(' ');
                DateTime nowdt, exdt = new DateTime();
                nowdt = Convert.ToDateTime(noww);
                if (exp.Length > 2)
                    exdt = Convert.ToDateTime(exp[1]);
                else if (exp.Length == 2)
                    exdt = Convert.ToDateTime(exp[0]);
                else
                    exdt = Convert.ToDateTime(ObjBALClass.ObjPurchase.ItemExpiryDate);
                int diffdt = exdt.CompareTo(nowdt);

                if (GeneralOptionSetting.FlagPurchase_DontUseExpiry.Trim() == "N")
                {
                    if (exp[1] != noww && diffdt > 0)
                    {
                        InsertItem();
                    }
                    else
                    {
                        //GeneralFunction.Information("ItemExpired", "PurchaseInvoice");
                        PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                        frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbuyit");
                        frmExpiry.ShowDialog();
                        ControlName = "dtpExpiry";
                        return;
                    }
                }
                else
                {
                    InsertItem();
                }
            }
            else
            {
                InsertItem();
            }
        }

        internal void InsertItem()
        {
            try
            {
                //if (!isFromGridUpdate)
                //{
                decimal UnitPrice = 0.0m, Total = 0.0m, SalePrice = 0.0m, Cost = 0.0m, NewCost = 0.0m;
                int TotalStock = 0;
                ObjBALClass.ObjPurchase.ItemPackage = ObjBALClass.ObjPurchase.ItemPackage == 0 ? 1 : ObjBALClass.ObjPurchase.ItemPackage;
                string noww = DateTime.Now.ToShortDateString().ToString();
                string[] exp = ObjBALClass.ObjPurchase.ItemExpiryDate.ToString().Split(' ');
                decimal dc;
                if (ItemCost == ObjBALClass.ObjPurchase.PurchaseCost)//Itemcost object into local itemcost variable
                {
                    if (decimal.Parse((ItemCost / ObjBALClass.ObjPurchase.ItemPackage).ToString("#####0.000")) == ItemUnitPrice)
                    {
                        ItemCost = ObjBALClass.ObjPurchase.ItemCost = ObjBALClass.ObjPurchase.PurchaseCost;
                    }
                    else
                        ItemCost = ObjBALClass.ObjPurchase.PurchaseCost = ObjBALClass.ObjPurchase.ItemCost = isPackage == false ? ItemCost : Decimal.Parse((ItemUnitPrice).ToString()) * Decimal.Parse((ObjBALClass.ObjPurchase.ItemPackage == 0 ? 1 : ObjBALClass.ObjPurchase.ItemPackage).ToString());
                }
                else
                {
                    // ItemCost=ObjBALClass.ObjPurchase.PurchaseCost = ObjBALClass.ObjPurchase.ItemCost = isPackage == false ? ObjBALClass.ObjPurchase.ItemCost : Decimal.Parse((ObjBALClass.ObjPurchase.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjPurchase.ItemPackage == 0 ? 1 : ObjBALClass.ObjPurchase.ItemPackage).ToString());
                    ItemCost = ObjBALClass.ObjPurchase.PurchaseCost = ObjBALClass.ObjPurchase.ItemCost = isPackage == false ? ItemCost : Decimal.Parse((ItemUnitPrice).ToString()) * Decimal.Parse((ObjBALClass.ObjPurchase.ItemPackage == 0 ? 1 : ObjBALClass.ObjPurchase.ItemPackage).ToString());
                }
                ObjBALClass.ObjPurchase.ActualUnitPrice = decimal.Parse(Math.Truncate((ObjBALClass.ObjPurchase.ItemCost / ObjBALClass.ObjPurchase.ItemPackage) * 1000m / 1000m).ToString("#####0.000"));
                decimal totaltax = Taxcalcitem();
                decimal newcost = (ObjBALClass.ObjPurchase.ItemCost + totaltax);
                newcost = decimal.Parse((Math.Truncate(newcost * 1000m) / 1000m).ToString("#####0.000"));//decimal.Parse(((newcost * 1000m) / 1000m).ToString("#####0.000"));
                ObjBALClass.ObjPurchase.ItemCost = newcost;
                dc = (Convert.ToDecimal(ObjBALClass.ObjPurchase.ItemPrice)) / ObjBALClass.ObjPurchase.ItemPackage;
                // ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemCost * ObjBALClass.ObjPurchase.ItemQuantity;
                ////****Calculation*****\\\\
                UnitPrice = decimal.Parse((ObjBALClass.ObjPurchase.ItemCost / ObjBALClass.ObjPurchase.ItemPackage).ToString("#####0.000"));
                //UnitPrice = Decimal.Parse((Math.Truncate(UnitPrice * 1000m) / 1000m).ToString("#####0.000"));
                SalePrice = ObjBALClass.ObjPurchase.ItemPrice;
                //Cost =decimal.Parse((Math.Truncate((UnitPrice * ObjBALClass.ObjPurchase.ItemPackage)*1000m)/1000m).ToString("#####0.000"));
                ///above line Command to solve the itemcost Issue

                Cost = ObjBALClass.ObjPurchase.ItemCost;
                NewCost = ObjBALClass.ObjPurchase.ItemCost;
                //TotalStock = ObjBALClass.ObjPurchase.ItemQuantity * ObjBALClass.ObjPurchase.ItemPackage;
                // Total = UnitPrice * TotalStock;


                ObjBALClass.ObjPurchase.ItemUnitPrice = UnitPrice;
                ObjBALClass.ObjPurchase.SalePrice = SalePrice;
                ObjBALClass.ObjPurchase.ItemCost = Cost;
                ObjBALClass.ObjPurchase.NewCost = NewCost;
                ObjBALClass.ObjPurchase.ItemTotalStock = TotalStock;
                ObjBALClass.ObjPurchase.ItemTotal = Total;
                ObjBALClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.CreatedDate = DateTime.Now;
                ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.ModifiedDate = DateTime.Now;
                ObjBALClass.ObjPurchase.Status = 1;
                ObjBALClass.ObjPurchase.SetStatus = 0;
                ObjBALClass.ObjPurchase.BatchID = 1;
                if (isPackage == false)
                {
                    ObjBALClass.ObjPurchase.ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity * ObjBALClass.ObjPurchase.ItemPackage;
                    ObjBALClass.ObjPurchase.Box = ObjBALClass.ObjPurchase.ItemQuantity / ObjBALClass.ObjPurchase.ItemPackage;
                    //ObjBALClass.ObjPurchase.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjPurchase.ItemQuantity).ToString());
                    //above line command to fix the Cost issue 
                    //ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemCost * ObjBALClass.ObjPurchase.ItemQuantity;
                    ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemCost * ObjBALClass.ObjPurchase.Box;
                }
                else
                {
                    ObjBALClass.ObjPurchase.ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity;
                    ObjBALClass.ObjPurchase.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjPurchase.ItemQuantity).ToString());
                    ObjBALClass.ObjPurchase.Box = 0;
                }

                if (ObjBALClass.ObjPurchase.ItemType == 2)
                {
                    ObjBALClass.ObjPurchase.ItemSerialNo = objSerial.SerialNo;
                }
                else
                {
                    ObjBALClass.ObjPurchase.ItemSerialNo = "0";
                }
                if (GeneralOptionSetting.FlagPurchase_DontUseExpiry.Trim() == "N")
                {
                    if (ObjBALClass.ObjPurchase.ExpiryDate == true)
                    { }
                    else { ObjBALClass.ObjPurchase.ItemExpiryDate = null; }
                }
                else { ObjBALClass.ObjPurchase.ItemExpiryDate = null; }
                //bool IsStockSold = false;
                //if (ObjBALClass.ObjPurchase.ExpiryDate == true && XExpiry != ObjBALClass.ObjPurchase.ItemExpiryDate && isFromGridUpdate == true)
                //{
                //    // updating price for the old record
                //    if (ObjBALClass.ObjPurchase.ItemCost == XCost)
                //    {
                //         int Qty = 0; //int ReturnQty = 0;

                //        DataSet ds = ObjBALClass.updatestatus(XCost, XExpiry, XSerialNo, XBarcodeID, XQuantity);
                //        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                //            Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["StockInHand"]);
                //        //if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                //        //    ReturnQty = Convert.ToInt32(ds.Tables[1].Rows[0]["ReturnQuantity"]);
                //        if (Qty >= XQuantity)
                //        {

                //           // follow = false;

                //        }
                //        else
                //        {
                //            if (Qty == 0)
                //            {
                //                GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                //                return;
                //            }

                //            IsStockSold = true;
                //        }

                //    }
                //}
                if (!isFromGridUpdate)
                {
                    if (InsertDetails.Count >= 0)
                    {
                        if (!isPackage)
                            Index = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == (ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ').Length > 2 ? ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[1] : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[0])) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjPurchase.ItemSerialNo) && (a.BarcodeID == ObjBALClass.ObjPurchase.BarcodeID));//&& (a.Box != 0)
                        else
                            Index = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == (ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjPurchase.ItemSerialNo) && (a.BarcodeID == ObjBALClass.ObjPurchase.BarcodeID)); //&& (a.Box == 0)
                        if (Index != -1)
                        {
                            InsertDetails[Index].ItemQuantity = InsertDetails[Index].ItemQuantity + ObjBALClass.ObjPurchase.ItemQuantity;
                            InsertDetails[Index].ItemTotal = InsertDetails[Index].ItemUnitPrice * InsertDetails[Index].ItemQuantity;
                            if (!isPackage || (InsertDetails[Index].ItemQuantity % InsertDetails[Index].ItemPackage) == 0) // added by T on 7-Spet-2019
                                InsertDetails[Index].Box = InsertDetails[Index].ItemQuantity / (InsertDetails[Index].ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1);
                            else if (InsertDetails[Index].ItemQuantity == InsertDetails[Index].ItemPackage) // Start added by T on 3-Spet-2019
                            {
                                ObjBALClass.ObjPurchase.Box = InsertDetails[Index].Box = InsertDetails[Index].ItemQuantity / (InsertDetails[Index].ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1);
                            }
                            InsertDetails[Index].ItemExpiryDate = ObjBALClass.ObjPurchase.ItemExpiryDate;
                        }
                    }
                    if (Index == -1)
                        InsertDetails.Add(new PurchaseObjectClass
                        {
                            ItemNo = ObjBALClass.ObjPurchase.ItemNo,
                            ItemDescription = ObjBALClass.ObjPurchase.ItemName,
                            ItemExpiry = ObjBALClass.ObjPurchase.ItemType == 1 ? ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ').Length > 2 ? ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[1] : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[0] : "-",
                            ItemExpiryDate = ObjBALClass.ObjPurchase.ItemType == 1 ? ObjBALClass.ObjPurchase.ItemExpiryDate == null ? null : ObjBALClass.ObjPurchase.ItemExpiryDate : null,
                            ItemPackage = ObjBALClass.ObjPurchase.ItemPackage,
                            ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity,
                            Box = ObjBALClass.ObjPurchase.Box,
                            ItemUnitPrice = ObjBALClass.ObjPurchase.ItemUnitPrice,
                            ItemTotal = ObjBALClass.ObjPurchase.ItemTotal,
                            ItemSerialNo = ObjBALClass.ObjPurchase.ItemSerialNo,
                            ItemDiscount = Convert.ToDecimal((0.0).ToString("#####0.000")),
                            ItemCost = ObjBALClass.ObjPurchase.ItemCost,
                            NewCost = ObjBALClass.ObjPurchase.NewCost,
                            ItemTax1 = ObjBALClass.ObjPurchase.ItemTax1,
                            ItemTax2 = ObjBALClass.ObjPurchase.ItemTax2,
                            SalePrice = ObjBALClass.ObjPurchase.SalePrice,
                            ItemNumber = ObjBALClass.ObjPurchase.ItemNumber,
                            Time = DateTime.Now.TimeOfDay.ToString().Split('.')[0],
                            BarcodeID = ObjBALClass.ObjPurchase.BarcodeID,
                            ItemTax1SubAmount = ObjBALClass.ObjPurchase.ItemTax1SubAmount,
                            ItemTax2SubAmount = ObjBALClass.ObjPurchase.ItemTax2SubAmount
                        });

                    decimal total = InsertDetails.Sum(a => a.ItemTotal);
                    ObjBALClass.ObjPurchase.ItemTotal = total;
                    ObjBALClass.ObjPurchase.ItemNet = total;
                    if (ObjBALClass.SaveStock())
                    {
                        ///
                    }
                    ObjBALClass.ObjPurchase.AccountID = 1;
                    ObjBALClass.ObjPurchase.ItemBalance = Convert.ToDecimal(0.0);
                    ObjBALClass.ObjPurchase.ItemGrossAmt = Convert.ToDecimal(0.0);
                    if (ObjBALClass.ObjPurchase.IncludeTax == true)
                    {
                        ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(1.0);
                    }
                    else
                    {
                        ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(0.0);
                    }

                    if (GeneralOptionSetting.FlagShowDiscountFiled == "Y")
                    {
                        if (ObjBALClass.ObjPurchase.ItemTotal >= ObjBALClass.ObjPurchase.ItemDiscount)
                        {

                        }
                        else
                        {
                            ObjBALClass.ObjPurchase.ItemDiscount = Convert.ToDecimal(0.0);
                        }
                    }
                    else { ObjBALClass.ObjPurchase.ItemDiscount = Convert.ToDecimal(0.0); }
                    /////int i = InsertDetails.Count - 1;Commended on 16/05/2014
                    int i;
                    if (Index == -1)
                        i = InsertDetails.Count - 1;
                    else
                        i = Index;
                    AssignListValuesToObject(i);
                    if (ObjBALClass.SavePurchase()) { ProgressStatus = true; }

                    //else
                    //{
                    //    InsertDetails[listIndex].ItemNo = ObjBALClass.ObjPurchase.ItemNo;
                    //    InsertDetails[listIndex].ItemName = ObjBALClass.ObjPurchase.ItemName;
                    //    InsertDetails[listIndex].ItemUnitPrice = ObjBALClass.ObjPurchase.ItemUnitPrice;
                    //    AssignListValuesToObject(listIndex);
                    //    if (ObjBALClass.SavePurchase())
                    //        ProgressStatus = true;
                    //}
                }
                else
                {
                    int addQuantity = 0; bool follow = false; int Qty = 0; //int ReturnQty = 0;
                    StockSold = 0;
                    int Current_Qty = 0;
                    int Current_Box = 0;
                    int older_box = 0;
                    int ExpiryInsert = 0;
                    int DeleteItem = 0;
                    int CurrentItemType = ObjBALClass.ObjPurchase.ItemType;
                    int itemType = ObjBALClass.ObjPurchase.ItemType = 1;
                    DateTime? xDate = ObjBALClass.ObjPurchase.ItemExpiryDate;
                    DataSet ds = ObjBALClass.updatestatus(XCost, XExpiry, XSerialNo, XBarcodeID, XQuantity);
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        Qty = Convert.ToInt32(ds.Tables[0].Rows[0]["StockInHand"]);
                    //if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    //    ReturnQty = Convert.ToInt32(ds.Tables[1].Rows[0]["ReturnQuantity"]);
                    if (Qty >= XQuantity)
                    {

                        follow = false;

                    }
                    else
                    {
                        if (Qty == 0)
                        {
                            GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                            return;
                        }
                        StockSold = XQuantity - Qty;
                        if (ObjBALClass.ObjPurchase.ItemQuantity <= StockSold)
                        {
                            GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                            return;
                        }

                        if (ObjBALClass.ObjPurchase.ItemCost == XCost && ObjBALClass.ObjPurchase.ItemExpiryDate == XExpiry)
                        {
                            addQuantity = ObjBALClass.ObjPurchase.ItemQuantity - XQuantity;
                            follow = true;
                        }
                        else
                        {
                            addQuantity = ObjBALClass.ObjPurchase.ItemQuantity - XQuantity;
                            if (addQuantity <= 0)
                            {

                                //GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                                //return;
                            }
                        }

                        Current_Qty = ObjBALClass.ObjPurchase.ItemQuantity;
                        Current_Box = ObjBALClass.ObjPurchase.Box;

                        if (isPackage == false)
                        {
                            if (XQuantity != ObjBALClass.ObjPurchase.ItemQuantity)
                            {
                                ObjBALClass.ObjPurchase.ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity - StockSold;
                            }
                            else
                            {
                                ObjBALClass.ObjPurchase.ItemQuantity = Qty;
                            }
                            ObjBALClass.ObjPurchase.Box = ObjBALClass.ObjPurchase.ItemQuantity / ObjBALClass.ObjPurchase.ItemPackage;
                            ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemCost * ObjBALClass.ObjPurchase.Box;

                            older_box = StockSold / ObjBALClass.ObjPurchase.ItemPackage;
                        }
                        else
                        {
                            if (XQuantity != ObjBALClass.ObjPurchase.ItemQuantity)
                            {
                                ObjBALClass.ObjPurchase.ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity - StockSold;
                            }
                            else
                            {
                                ObjBALClass.ObjPurchase.ItemQuantity = Qty;
                            }
                            ObjBALClass.ObjPurchase.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjPurchase.ItemQuantity).ToString());
                            ObjBALClass.ObjPurchase.Box = 0;
                            older_box = 0;
                        }


                    }
                    //if (ReturnQty != 0)
                    //{
                    //    if ((ObjBALClass.ObjPurchase.ItemQuantity - XQuantity) == addQuantity)//return+sold 
                    //    {
                    //        addQuantity =addQuantity-ReturnQty;
                    //        if (addQuantity <= 0)
                    //        {
                    //            GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                    //            return;
                    //        }
                    //        follow = true;
                    //    }
                    //    else
                    //    {//only return
                    //        addQuantity = (ObjBALClass.ObjPurchase.ItemQuantity - XQuantity) - ReturnQty;
                    //        if (addQuantity <= 0)
                    //        {
                    //            GeneralFunction.Information("Stockareupdate", "PurchaseInvoice");
                    //            return;
                    //        }
                    //        follow = true;
                    //    }

                    //}
                    if (ObjBALClass.ObjPurchase.IncludeTax == true)
                    {
                        ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(1.0);
                    }
                    else
                    {
                        ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(0.0);
                    }


                    int addtolist = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == (ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjPurchase.ItemSerialNo) && (a.BarcodeID == ObjBALClass.ObjPurchase.BarcodeID));

                    InsertDetails[listIndex].ItemNo = ObjBALClass.ObjPurchase.ItemNo;
                    InsertDetails[listIndex].ItemDescription = ObjBALClass.ObjPurchase.ItemName;
                    InsertDetails[listIndex].ItemUnitPrice = ObjBALClass.ObjPurchase.ItemUnitPrice;
                    InsertDetails[listIndex].ItemExpiry = ObjBALClass.ObjPurchase.ItemType == 1 ? ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToShortDateString() : "-";
                    InsertDetails[listIndex].ItemExpiryDate = ObjBALClass.ObjPurchase.ItemType == 1 ? ObjBALClass.ObjPurchase.ItemExpiryDate == null ? null : ObjBALClass.ObjPurchase.ItemExpiryDate : null;
                    InsertDetails[listIndex].ItemPackage = ObjBALClass.ObjPurchase.ItemPackage;
                    InsertDetails[listIndex].ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity;
                    InsertDetails[listIndex].Box = ObjBALClass.ObjPurchase.Box;
                    InsertDetails[listIndex].ItemUnitPrice = ObjBALClass.ObjPurchase.ItemUnitPrice;
                    InsertDetails[listIndex].ItemTotal = ObjBALClass.ObjPurchase.ItemTotal;
                    InsertDetails[listIndex].ItemSerialNo = ObjBALClass.ObjPurchase.ItemSerialNo;
                    InsertDetails[listIndex].ItemDiscount = Convert.ToDecimal((0.0).ToString("#####0.000"));
                    InsertDetails[listIndex].ItemCost = ObjBALClass.ObjPurchase.ItemCost;
                    InsertDetails[listIndex].NewCost = ObjBALClass.ObjPurchase.NewCost;
                    InsertDetails[listIndex].ItemTax1 = ObjBALClass.ObjPurchase.ItemTax1;
                    InsertDetails[listIndex].ItemTax2 = ObjBALClass.ObjPurchase.ItemTax2;
                    InsertDetails[listIndex].SalePrice = ObjBALClass.ObjPurchase.SalePrice;
                    InsertDetails[listIndex].BarcodeID = ObjBALClass.ObjPurchase.BarcodeID;
                    InsertDetails[listIndex].ItemTax1SubAmount = ObjBALClass.ObjPurchase.ItemTax1SubAmount;
                    InsertDetails[listIndex].ItemTax2SubAmount = ObjBALClass.ObjPurchase.ItemTax2SubAmount;
                    AssignListValuesToObject(listIndex);
                    //int addtolist =InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == (ObjBALClass.ObjPurchase.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjPurchase.ItemSerialNo)&&(a.BarcodeID==ObjBALClass.ObjPurchase.BarcodeID));

                    //if (addtolist != -1)
                    //{
                    //    InsertDetails[addtolist].ItemQuantity = InsertDetails[addtolist].ItemQuantity + ObjBALClass.ObjPurchase.ItemQuantity;
                    //    InsertDetails[addtolist].ItemTotal = InsertDetails[addtolist].ItemUnitPrice * InsertDetails[addtolist].ItemQuantity;
                    //    if (!isPackage)
                    //        InsertDetails[addtolist].Box = InsertDetails[addtolist].ItemQuantity / (InsertDetails[addtolist].ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1);
                    //    InsertDetails[addtolist].ItemExpiryDate = ObjBALClass.ObjPurchase.ItemExpiryDate;
                    //    InsertDetails.RemoveAt(listIndex);
                    //}

                    //if (ObjBALClass.ObjPurchase.ExpiryDate == true && XExpiry != ObjBALClass.ObjPurchase.ItemExpiryDate && StockSold != 0)
                    //{

                    //   int quan = ObjBALClass.ObjPurchase.ItemQuantity;
                    //   DateTime? exp_date = ObjBALClass.ObjPurchase.ItemExpiryDate;
                    //   int i_box = ObjBALClass.ObjPurchase.Box;
                    //    ObjBALClass.ObjPurchase.ItemQuantity = Qty;
                    //    ObjBALClass.ObjPurchase.ItemExpiryDate = XExpiry;
                    //    ObjBALClass.ObjPurchase.Box = Qty;
                    //    // updating price for the old record
                    //    if (ObjBALClass.ObjPurchase.ItemCost == XCost)
                    //    {
                    //        ObjBALClass.ObjPurchase.ItemQuantity = quan - Qty;
                    //        ObjBALClass.ObjPurchase.ItemExpiryDate = exp_date;
                    //        ObjBALClass.ObjPurchase.Box = quan - Qty;
                    //    }
                    //    ObjBALClass.UpdateStock(XItemCost, XExpiry, XSerialNo, XBarcodeID, XQuantity);

                    //     ObjBALClass.ObjPurchase.ItemQuantity = quan;
                    //     ObjBALClass.ObjPurchase.ItemExpiryDate = exp_date;
                    //     ObjBALClass.ObjPurchase.Box = i_box;

                    //    ObjBALClass.ObjPurchase.ItemQuantity = ObjBALClass.ObjPurchase.ItemQuantity - Qty;
                    //    if (isPackage == false)
                    //    {
                    //        ObjBALClass.ObjPurchase.Box = ObjBALClass.ObjPurchase.ItemQuantity / ObjBALClass.ObjPurchase.ItemPackage;
                    //    }
                    //    else
                    //    {
                    //        ObjBALClass.ObjPurchase.Box = 0;
                    //    }
                    //}
                    if (!follow)
                    {
                        if (ObjBALClass.UpdateStock(XItemCost, XExpiry, XSerialNo, XBarcodeID, XQuantity))
                        { ProgressStatus = true; }
                    }
                    else if (follow)
                    {
                        if (ObjBALClass.AddStock(XItemCost, XExpiry, XSerialNo, XBarcodeID, XQuantity, addQuantity))
                        {
                            ProgressStatus = true;
                            ObjBALClass.ObjPurchase.ItemQuantity = Current_Qty;
                            ObjBALClass.ObjPurchase.Box = Current_Box;
                        }
                    }
                    ProgressStatus = false;


                    //if (StockSold != 0)
                    //{
                    //     ObjBALClass.ObjPurchase.ItemQuantity = BackupItem;
                    //     ObjBALClass.ObjPurchase.Box = BackupBox;
                    //}
                    // in case of expiry is changed

                    if (InsertDetails.Count > 1)
                    {
                        if (ObjBALClass.ObjPurchase.ExpiryDate)
                        {
                            Index = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo && a.ItemCost == ObjBALClass.ObjPurchase.NewCost && a.PurchaseItemdDetail_ID != ObjBALClass.ObjPurchase.PurchaseItemdDetail_ID && a.ItemExpiryDate == ObjBALClass.ObjPurchase.ItemExpiryDate));
                        }
                        else if (CurrentItemType == 2)
                        {
                            Index = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo && a.ItemCost == ObjBALClass.ObjPurchase.NewCost && a.PurchaseItemdDetail_ID != ObjBALClass.ObjPurchase.PurchaseItemdDetail_ID && a.ItemSerialNo == objbalClass.ObjPurchase.ItemSerialNo));
                        }
                        else
                        {
                            Index = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo && a.ItemCost == ObjBALClass.ObjPurchase.NewCost && a.PurchaseItemdDetail_ID != ObjBALClass.ObjPurchase.PurchaseItemdDetail_ID));
                        }
                        if (Index >= 0)
                        {
                            ObjBALClass.ObjPurchase.ItemQuantity = InsertDetails[Index].ItemQuantity + ObjBALClass.ObjPurchase.ItemQuantity;
                            ObjBALClass.ObjPurchase.ItemTotal = ObjBALClass.ObjPurchase.ItemUnitPrice * ObjBALClass.ObjPurchase.ItemQuantity;
                            if (!isPackage)
                                ObjBALClass.ObjPurchase.Box = ObjBALClass.ObjPurchase.ItemQuantity / (ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1);
                            ObjBALClass.ObjPurchase.ItemExpiryDate = ObjBALClass.ObjPurchase.ItemExpiryDate;
                            DeleteItem = 1;
                        }
                    }

                    if (ObjBALClass.ObjPurchase.ExpiryDate == true && XExpiry != ObjBALClass.ObjPurchase.ItemExpiryDate)
                    {
                        // updating price for the old record
                        if (ObjBALClass.ObjPurchase.ItemCost == XCost)
                        {
                            if (DeleteItem != 1)
                            {
                                ExpiryInsert = 1;
                            }
                        }
                        else
                        {
                            ExpiryInsert = 0;
                        }
                    }
                    if (ObjBALClass.UpdatePurchase(XCost, XExpiry, XSerialNo, XBarcodeID, XBox, StockSold, older_box, ExpiryInsert, DeleteItem))
                    {
                        //if(ObjBALClass.ObjPurchase.ExpiryDate == true && XExpiry != ObjBALClass.ObjPurchase.ItemExpiryDate && StockSold != 0)
                        //{
                        //    if (ObjBALClass.ObjPurchase.ItemCost == XCost)
                        //    {
                        //        ExpiryInsert = 1;

                        //    }
                        //    else
                        //    {
                        //        ObjBALClass.ObjPurchase.ItemExpiryDate = XExpiry;
                        //    }
                        //    ObjBALClass.ObjPurchase.ItemQuantity =  Qty;

                        //    if (isPackage == false)
                        //    {
                        //        ObjBALClass.ObjPurchase.Box = Qty / ObjBALClass.ObjPurchase.ItemPackage;

                        //    }
                        //    else
                        //    {
                        //        ObjBALClass.ObjPurchase.Box = 0;
                        //    }

                        //    if (ObjBALClass.UpdatePurchase(XCost, XExpiry, XSerialNo, XBarcodeID, XBox, StockSold, older_box, ExpiryInsert, DeleteItem))
                        //    {
                        //        ProgressStatus = true;
                        //    }
                        //}
                        // else
                        // {
                        ProgressStatus = true;
                        // }

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AssignListValuesToObject(int i)
        {
            ObjBALClass.ObjPurchase.ItemQuantity = InsertDetails[i].ItemQuantity;
            ObjBALClass.ObjPurchase.ItemNo = InsertDetails[i].ItemNo;
            ObjBALClass.ObjPurchase.ItemName = InsertDetails[i].ItemDescription;
            ObjBALClass.ObjPurchase.ItemUnitPrice = InsertDetails[i].ItemUnitPrice;
            ObjBALClass.ObjPurchase.SalePrice = InsertDetails[i].SalePrice;
            ObjBALClass.ObjPurchase.PurchaseCost = InsertDetails[i].ItemCost;
            ObjBALClass.ObjPurchase.ItemSerialNo = InsertDetails[i].ItemSerialNo;
            ObjBALClass.ObjPurchase.ItemDiscount = InsertDetails[i].ItemDiscount;
            ObjBALClass.ObjPurchase.ItemExpiryDate = InsertDetails[i].ItemExpiryDate;
            ObjBALClass.ObjPurchase.Box = InsertDetails[i].Box;
            ObjBALClass.ObjPurchase.ItemTotalAmount = InsertDetails[i].ItemTotal;
            ObjBALClass.ObjPurchase.ItemTax1SubAmount = InsertDetails[i].ItemTax1SubAmount;
            ObjBALClass.ObjPurchase.ItemTax2SubAmount = InsertDetails[i].ItemTax2SubAmount;
            ObjBALClass.ObjPurchase.PurchaseItemdDetail_ID = InsertDetails[i].PurchaseItemdDetail_ID;

        }

        internal Boolean ValidateItem()
        {
            if (objbalClass.ObjPurchase.InvoiceNo.ToString() == string.Empty)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceNo"), ActionType.Insert.ToString());
                ControlName = "txtNewInvoiceNo";
                return false;
            }
            else if (objbalClass.ObjPurchase.ItemName == string.Empty)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyItemName"), ActionType.Insert.ToString());
                ControlName = "cmbItemName";
                return false;
            }
            else if (objbalClass.ObjPurchase.SupplierName == String.Empty)
            {

                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptySupplierName"), ActionType.Insert.ToString());
                ControlName = "cmbSupplierName";
                return false;
            }
            else if (objbalClass.ObjPurchase.ItemQuantity == 0)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("ZeroQty"), ActionType.Insert.ToString());
                ControlName = "txtQuantity";
                return false;
            }

            else if (objbalClass.ObjPurchase.ItemCost.ToString() == string.Empty)//this validation changed on 16/04/2014 to insert the item with 0 cost
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyCost"), ActionType.Insert.ToString());
                ControlName = "txtCost";
                return false;
            }
            //else if (objbalClass.ObjPurchase.ItemPrice <= 0)
            //{
            //    if (GeneralFunction.Question(GeneralFunction.ChangeLanguageforCustomMsg("ItemCostGreaterthanZero"), ActionType.Insert.ToString()) == DialogResult.No)
            //    {
            //        ControlName = "txtPrice";
            //        return false;
            //    }

            //}

            return true;
        }

        internal void ItemNameSelectedIndexChange()
        {
            List<PurchaseObjectClass> ItemList;
            try
            {
                if (objbalClass.ObjPurchase.ItemName != string.Empty && ObjBALClass.ObjPurchase.ItemNo != 0)
                {
                    PackageQty.Clear();
                    ItemList = objbalClass.GetItemDetails();
                    foreach (var list in ItemList)
                    {
                        ObjBALClass.ObjPurchase.ItemNo = list.ItemNo;
                        ObjBALClass.ObjPurchase.ItemName = list.ItemName;
                        ObjBALClass.ObjPurchase.ItemBarcode = list.ItemBarcode;
                        ObjBALClass.ObjPurchase.CategoryNo = list.CategoryNo;
                        ObjBALClass.ObjPurchase.ItemType = list.ItemType;
                        ObjBALClass.ObjPurchase.ItemPlaceID = list.ItemPlaceID;
                        ObjBALClass.ObjPurchase.ItemDescription = list.ItemDescription;
                        ObjBALClass.ObjPurchase.ItemUnitPrice = list.ItemUnitPrice;
                        ObjBALClass.ObjPurchase.CompanyNo = list.CompanyNo;
                        ObjBALClass.ObjPurchase.ItemCost = list.ItemCost;
                        ItemCost = ObjBALClass.ObjPurchase.PurchaseCost = list.ItemCost;
                        ObjBALClass.ObjPurchase.ItemLastCost = list.ItemLastCost;
                        ObjBALClass.ObjPurchase.ItemPackage = list.ItemPackage;
                        ObjBALClass.ObjPurchase.ExpiryDate = list.ExpiryDate;
                        ObjBALClass.ObjPurchase.Reorder = list.Reorder;
                        ObjBALClass.ObjPurchase.ItemWholeSalePrice = list.ItemWholeSalePrice;
                        ObjBALClass.ObjPurchase.ItemPrice = list.ItemPrice;
                        ObjBALClass.ObjPurchase.MaxOrder = list.MaxOrder;
                        ObjBALClass.ObjPurchase.ItemMinimumPrice = list.ItemMinimumPrice;
                        ObjBALClass.ObjPurchase.AvgCost = list.AvgCost;
                        ObjBALClass.ObjPurchase.ItemExpiryDate = list.ItemExpiryDate;
                        ObjBALClass.ObjPurchase.ItemTotalStock = list.ItemTotalStock;
                        ObjBALClass.ObjPurchase.ItemStock = (ObjBALClass.ObjPurchase.ItemTotalStock / (ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1)) + 1;
                        ObjBALClass.ObjPurchase.BarcodeID = list.BarcodeID;
                        ObjBALClass.ObjPurchase.ItemNumber = list.ItemNumber;
                        ObjBALClass.ObjPurchase.ItemCardItemCost = list.ItemCardItemCost;
                        ObjBALClass.ObjPurchase.ItemCardPackageQty = list.ItemCardPackageQty;
                        PackageQty.Add(new PurchaseObjectClass
                        {
                            ItemPackage = list.ItemPackage,
                            BarcodeID = ObjBALClass.ObjPurchase.BarcodeID,
                            ItemPrice = ObjBALClass.ObjPurchase.ItemPrice,
                            ItemCost = ObjBALClass.ObjPurchase.ItemCost,
                            ItemTotalStock = ObjBALClass.ObjPurchase.ItemTotalStock
                        });
                    }
                    // ObjItemDetails.Itempopup = ObjBALClass.ItemDetailspopup();
                }
                checkformoreexpiry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ItemList = null;
            }
        }

        internal void checkformoreexpiry()
        {
            try
            {
                if (ObjBALClass.ObjPurchase.ItemName != String.Empty)
                {
                    CheckExpiry = ObjBALClass.CheckExpiry();
                    if (CheckExpiry.Count > 1)
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal decimal Taxcalcitem()
        {
            try
            {
                // string Tax1, Tax2;
                string Tax1percent, Tax1subpercent, Tax2percent, Tax2subpercent;
                decimal Tax1amountpercent = 0, Tax1amountsubpercent = 0, Tax2amountpercent = 0, Tax2amountsubpercent = 0, tax1cost = 0, tax2cost = 0;
                Tax1percent = GeneralOptionSetting.FlagTax1_Percentage;
                Tax1subpercent = GeneralOptionSetting.FlagTax1_SubPercentage;
                Tax2percent = GeneralOptionSetting.FlagTax2_Percentage;
                Tax2subpercent = GeneralOptionSetting.FlagTax2_SubPercentage;
                ObjBALClass.ObjPurchase.ItemTax1 = tax1cost;
                ObjBALClass.ObjPurchase.ItemTax2 = tax2cost;
                if ((ObjBALClass.ObjPurchase.ItemCost != Convert.ToDecimal(0.000)) && (ObjBALClass.ObjPurchase.IncludeTax == true))
                {
                    if ((Tax1percent != "0") && (GeneralOptionSetting.FlagTax1_ApplyPurchase == "Y"))
                    {
                        Tax1amountpercent = ((Decimal.Parse(ObjBALClass.ObjPurchase.ItemCost.ToString()) * Decimal.Parse(Tax1percent)) / 100);
                        Tax1amountpercent = decimal.Parse(((Tax1amountpercent) * 1000m / 1000m).ToString("#####0.000"));
                        Tax1amountsubpercent = (Tax1amountpercent != 0) ? ((Tax1amountpercent * Convert.ToDecimal(Tax1subpercent)) / 100) : 0;
                        Tax1amountsubpercent = Decimal.Parse(((Tax1amountsubpercent) * 1000m / 1000m).ToString("#####0.000"));
                        ObjBALClass.ObjPurchase.ItemTax1SubAmount = Tax1amountsubpercent;
                        tax1cost = (Tax1amountsubpercent != 0) ? (Tax1amountsubpercent + Tax1amountpercent) : Tax1amountpercent;
                        ObjBALClass.ObjPurchase.ItemTax1 = decimal.Parse((Math.Truncate(tax1cost * 1000m) / 1000m).ToString("#####0.000"));
                        ObjBALClass.ObjPurchase.FlagTax1Percentage = Decimal.Parse(GeneralOptionSetting.FlagTax1_Percentage);
                        ObjBALClass.ObjPurchase.FlagTax1SubPercentage = Decimal.Parse(GeneralOptionSetting.FlagTax1_SubPercentage);
                    }
                    else
                        tax1cost = 0;

                    if ((GeneralOptionSetting.FlagTax2_ApplyPurchase == "Y") && (Tax2percent != "0"))
                    {
                        //the below line Commended on 09-05-2014 to fix Tax2 not added
                        //  Tax2amountpercent = (GeneralOptionSetting.FlagTax2_ApplyBeforeDiscount == "Y") ? ((ObjBALClass.ObjPurchase.ItemCost* Decimal.Parse(Tax2percent)) / 100) : 0;
                        Tax2amountpercent = ((ObjBALClass.ObjPurchase.ItemCost * Decimal.Parse(Tax2percent))) / 100;
                        Tax2amountpercent = decimal.Parse(((Tax2amountpercent) * 1000m / 1000m).ToString("#####0.000"));
                        Tax2amountsubpercent = (Tax2amountpercent != 0) ? ((Tax2amountpercent * Decimal.Parse(Tax2subpercent)) / 100) : 0;
                        ObjBALClass.ObjPurchase.ItemTax2SubAmount = Tax2amountsubpercent = decimal.Parse(((Tax2amountsubpercent) * 1000m / 1000m).ToString("#####0.000"));
                        tax2cost = (Tax2amountsubpercent != 0) ? (Tax2amountsubpercent + Tax2amountpercent) : Tax2amountpercent;
                        ObjBALClass.ObjPurchase.ItemTax2 = decimal.Parse((Math.Truncate(tax2cost * 1000m) / 1000m).ToString("#####0.000"));
                        ObjBALClass.ObjPurchase.FlagTax2Percentage = Decimal.Parse(GeneralOptionSetting.FlagTax2_Percentage);
                        ObjBALClass.ObjPurchase.FlagTax2SubPercentage = Decimal.Parse(GeneralOptionSetting.FlagTax2_SubPercentage);
                    }
                    else
                        tax2cost = 0;

                    //return tax1cost + tax2cost; commanded to get the exact items original cost
                    return ObjBALClass.ObjPurchase.ItemTax1 + ObjBALClass.ObjPurchase.ItemTax2;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        internal void btnCloseInvoice()
        {
            try
            {
                if (DgvCount > 0)
                {
                    if (DgvColor == "Color [WhiteSmoke]")
                    {
                        if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                        {
                            if (GeneralFunction.Question("AlertCloseInvoice", "PurchaseInvoice") == DialogResult.Yes)
                            {
                                CloseInvoice();
                            }
                        }
                        else
                        {
                            CloseInvoice();
                        }

                    }
                    else
                    {
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("AlreadyInvoiceClosed"), GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoice"));
                    }

                }
                else
                {
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceList"), GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoice"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CloseInvoice()
        {
            List<PurchaseObjectClass> DeleteList;
            try
            {
                //
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("PurchaseInvID", typeof(int));
                dtDetail.Columns.Add("AgentID", typeof(int));
                dtDetail.Columns.Add("AccountID", typeof(int));
                dtDetail.Columns.Add("PurchaseDate", typeof(DateTime));
                dtDetail.Columns.Add("Balance", typeof(decimal));
                dtDetail.Columns.Add("GrossAmt", typeof(decimal));
                dtDetail.Columns.Add("Tax", typeof(decimal));
                dtDetail.Columns.Add("Tax1", typeof(decimal));
                dtDetail.Columns.Add("NetAmt", typeof(decimal));
                dtDetail.Columns.Add("Discount", typeof(decimal));
                dtDetail.Columns.Add("PaymentDate", typeof(DateTime));
                dtDetail.Columns.Add("CreatedBy", typeof(int));
                dtDetail.Columns.Add("ModifiedBy", typeof(int));
                dtDetail.Columns.Add("Status", typeof(int));
                dtDetail.Columns.Add("SetStatus", typeof(int));
                dtDetail.Columns.Add("BatchID", typeof(string));
                dtDetail.Columns.Add("ItemID", typeof(string));
                dtDetail.Columns.Add("Qty", typeof(int));
                dtDetail.Columns.Add("UnitPrice", typeof(decimal));
                dtDetail.Columns.Add("ExpiryDate", typeof(DateTime));
                dtDetail.Columns.Add("ItemCost", typeof(decimal));
                dtDetail.Columns.Add("ItemlastCost", typeof(decimal));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("SalePrice", typeof(decimal));
                dtDetail.Columns.Add("Cost", typeof(decimal));
                dtDetail.Columns.Add("SerialNo", typeof(int));
                dtDetail.Columns.Add("DiscountType", typeof(string));
                dtDetail.Columns.Add("ItemDiscount", typeof(decimal));
                dtDetail.Columns.Add("ItemExtraCost", typeof(decimal));
                dtDetail.Columns.Add("DiscountCost", typeof(decimal));
                dtDetail.Columns.Add("ItemTax1", typeof(decimal));
                dtDetail.Columns.Add("ItemTax2", typeof(decimal));
                dtDetail.Columns.Add("TaxPer", typeof(decimal));
                dtDetail.Columns.Add("TaxSub", typeof(decimal));
                dtDetail.Columns.Add("Tax1_PER", typeof(decimal));
                dtDetail.Columns.Add("Tax1_SUB", typeof(decimal));
                dtDetail.Columns.Add("OriginalDis", typeof(decimal));
                dtDetail.Columns.Add("Note", typeof(string));
                dtDetail.Columns.Add("BarcodeID", typeof(int));
                dtDetail.Columns.Add("Box", typeof(int));
                dtDetail.Columns.Add("SubTax1", typeof(decimal));
                dtDetail.Columns.Add("SubTax2", typeof(decimal));
                dtDetail.Columns.Add("TotalAmount", typeof(decimal));
                dtDetail.Columns.Add("ActualUnitPrice", typeof(decimal));
                dtDetail.Columns.Add("YearSequenceNo", typeof(int));
                dtDetail.Columns.Add("ExchangeRate", typeof(decimal));
                dtDetail.Columns.Add("PurchaseDetail_ID", typeof(int));
                dtDetail.Columns.Add("InNo", typeof(string));
                //
                DeleteList = new List<PurchaseObjectClass>();
                DeleteList = ObjBALClass.InvoiceDetails();

                if (DeleteList.Count == 0 || DgvColor == "Color [WhiteSmoke]")
                {
                    if (DgvCount > 0)
                    {
                        DivideDiscountBeforeClosing();
                        Discount();
                        ObjBALClass.ObjPurchase.AccountID = 1;
                        ObjBALClass.ObjPurchase.ItemBalance = Convert.ToDecimal(0.0);

                        if (ObjBALClass.ObjPurchase.IncludeTax == true)
                        {
                            ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(1.0);
                        }
                        else
                        {
                            ObjBALClass.ObjPurchase.ItemTax = Convert.ToDecimal(0.0);
                        }

                        if (ObjBALClass.ObjPurchase.ItemTotal >= ObjBALClass.ObjPurchase.originaldiscount)
                        {
                            ObjBALClass.ObjPurchase.ItemDiscount = ObjBALClass.ObjPurchase.originaldiscount;
                        }
                        else
                        {
                            ObjBALClass.ObjPurchase.ItemDiscount = Convert.ToDecimal(0.0);
                        }

                        ObjBALClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                        ObjBALClass.ObjPurchase.CreatedDate = DateTime.Now;
                        ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                        ObjBALClass.ObjPurchase.ModifiedDate = DateTime.Now;
                        ObjBALClass.ObjPurchase.Status = 2;
                        ObjBALClass.ObjPurchase.SetStatus = 0;
                        decimal extracost = 0;
                        if ((ObjBALClass.ObjPurchase.ItemGrossAmt != null) && (ObjBALClass.ObjPurchase.ItemGrossAmt.ToString() != "0.000"))
                        {
                            TotalExtraCost = ObjBALClass.ObjPurchase.ItemGrossAmt;
                            int totquant = 0;
                            totquant = InsertDetails.Sum(q => q.ItemQuantity);
                            extracost = Convert.ToDecimal(ObjBALClass.ObjPurchase.ItemGrossAmt) / totquant;
                            extracost = (extracost < 0) ? 0 : extracost;
                            ObjBALClass.ObjPurchase.Extracost = extracost;
                        }
                        else { ObjBALClass.ObjPurchase.Extracost = 0.000M; }
                        for (int i = 0; i < InsertDetails.Count; i++)
                        {
                            ObjBALClass.ObjPurchase.ItemNo = InsertDetails[i].ItemNo;
                            ObjBALClass.ObjPurchase.ItemName = InsertDetails[i].ItemDescription;
                            ObjBALClass.ObjPurchase.ItemQuantity = InsertDetails[i].ItemQuantity;
                            ObjBALClass.ObjPurchase.ItemUnitPrice = InsertDetails[i].ItemUnitPrice;
                            ObjBALClass.ObjPurchase.BarcodeID = InsertDetails[i].BarcodeID;
                            ObjBALClass.ObjPurchase.Box = InsertDetails[i].Box;
                            ObjBALClass.ObjPurchase.ItemTotalAmount = InsertDetails[i].ItemTotal;//added on 19/05/2014
                            if ((InsertDetails[i].ItemExpiry == "-") | (InsertDetails[i].ItemExpiry == null))
                            {
                                ObjBALClass.ObjPurchase.ItemExpiryDate = null;

                            }
                            else { ObjBALClass.ObjPurchase.ItemExpiryDate = Convert.ToDateTime(InsertDetails[i].ItemExpiryDate); }//ItemExpiry into ItemexpiryDate on 20Nov2014
                            if (ObjBALClass.ObjPurchase.Extracost != null && ObjBALClass.ObjPurchase.Extracost != 0)
                            {
                                decimal ItemCostExtra = (((InsertDetails[i].ItemUnitPrice) * ObjBALClass.ObjPurchase.ItemQuantity) + TotalExtraCost);
                                // ObjBALClass.ObjPurchase.ItemCost = Convert.ToDecimal(ItemCostExtra / (ObjBALClass.ObjPurchase.ItemQuantity == 0 ? 1 : ObjBALClass.ObjPurchase.ItemQuantity));
                                ObjBALClass.ObjPurchase.ItemCost = InsertDetails[i].ItemCost;
                            }
                            else
                            {
                                ObjBALClass.ObjPurchase.ItemCost = InsertDetails[i].ItemCost;
                            }
                            ObjBALClass.ObjPurchase.SalePrice = InsertDetails[i].SalePrice;
                            ObjBALClass.ObjPurchase.ItemSerialNo = InsertDetails[i].ItemSerialNo;
                            ObjBALClass.ObjPurchase.ItemDiscount = InsertDetails[i].ItemDiscount;
                            ObjBALClass.ObjPurchase.PurchaseCost = InsertDetails[i].NewCost;
                            ObjBALClass.ObjPurchase.ItemTax1 = InsertDetails[i].ItemTax1;
                            ObjBALClass.ObjPurchase.ItemTax2 = InsertDetails[i].ItemTax2;
                            ObjBALClass.ObjPurchase.PurchaseDetailsId = InsertDetails[i].PurchaseItemdDetail_ID;
                            TaxCalculation();
                            decimal extravalue = ((TotalExtraCost != 0) && (TotalExtraCost.ToString() != string.Empty)) ? TotalExtraCost : 0.0m;
                            decimal totalextra = (ObjBALClass.ObjPurchase.ItemTotal != 0) ? ((extravalue / ObjBALClass.ObjPurchase.ItemTotal) * 100) : 0.0m;
                            ObjBALClass.ObjPurchase.PurchaseExtraCost = totalextra;
                            if (totalextra != 0)
                                ObjBALClass.ObjPurchase.EachItemExtraCost = (InsertDetails[i].ItemUnitPrice) + ((InsertDetails[i].ItemUnitPrice * totalextra) / 100);

                            dtDetail.Rows.Add(ObjBALClass.ObjPurchase.InvoiceNo, ObjBALClass.ObjPurchase.SupplierNo, ObjBALClass.ObjPurchase.AccountID, ObjBALClass.ObjPurchase.PurchaseItemDate, ObjBALClass.ObjPurchase.ItemBalance, ObjBALClass.ObjPurchase.ItemGrossAmt,
                                ObjBALClass.ObjPurchase.Tax, ObjBALClass.ObjPurchase.Tax1, ObjBALClass.ObjPurchase.ItemNet, ObjBALClass.ObjPurchase.Discount, ObjBALClass.ObjPurchase.SetPaymentDate == true ? (object)ObjBALClass.ObjPurchase.ItemPaymentDate : DBNull.Value,
                                ObjBALClass.ObjPurchase.CreatedBy, ObjBALClass.ObjPurchase.ModifiedBy, ObjBALClass.ObjPurchase.Status, ObjBALClass.ObjPurchase.SetStatus, ObjBALClass.ObjPurchase.BatchID, ObjBALClass.ObjPurchase.ItemNo, ObjBALClass.ObjPurchase.ItemQuantity,
                                ObjBALClass.ObjPurchase.ItemUnitPrice, ObjBALClass.ObjPurchase.ItemExpiryDate == null ? DBNull.Value : (object)ObjBALClass.ObjPurchase.ItemExpiryDate, ObjBALClass.ObjPurchase.ItemCost, ObjBALClass.ObjPurchase.ItemCost, ObjBALClass.ObjPurchase.ItemUnitPrice,
                                 ObjBALClass.ObjPurchase.SalePrice, ObjBALClass.ObjPurchase.PurchaseCost, ObjBALClass.ObjPurchase.ItemSerialNo == null || ObjBALClass.ObjPurchase.ItemSerialNo == string.Empty ? "0" : ObjBALClass.ObjPurchase.ItemSerialNo, ObjBALClass.ObjPurchase.DiscountType,
                                 ObjBALClass.ObjPurchase.ItemDiscount, ObjBALClass.ObjPurchase.Extracost, ObjBALClass.ObjPurchase.EachItemExtraCost, ObjBALClass.ObjPurchase.ItemTax1, ObjBALClass.ObjPurchase.ItemTax2, ObjBALClass.ObjPurchase.FlagTax1Percentage == null ? Convert.ToDecimal("0") : ObjBALClass.ObjPurchase.FlagTax1Percentage,
                                  ObjBALClass.ObjPurchase.FlagTax1SubPercentage == null ? Convert.ToDecimal("0") : ObjBALClass.ObjPurchase.FlagTax1SubPercentage, ObjBALClass.ObjPurchase.FlagTax2Percentage == null ? Convert.ToDecimal("0") : ObjBALClass.ObjPurchase.FlagTax2Percentage, ObjBALClass.ObjPurchase.FlagTax2SubPercentage == null ? Convert.ToDecimal("0") : ObjBALClass.ObjPurchase.FlagTax2SubPercentage,
                                  ObjBALClass.ObjPurchase.originaldiscount, ObjBALClass.ObjPurchase.Note != null ? ObjBALClass.ObjPurchase.Note : "", ObjBALClass.ObjPurchase.BarcodeID, ObjBALClass.ObjPurchase.Box, ObjBALClass.ObjPurchase.ItemTax1SubAmount, ObjBALClass.ObjPurchase.ItemTax2SubAmount,
                                  ObjBALClass.ObjPurchase.ItemTotalAmount, ObjBALClass.ObjPurchase.ActualUnitPrice, ObjBALClass.ObjPurchase.NewYearInvoiceID, ObjBALClass.ObjPurchase.ExchangeRate, ObjBALClass.ObjPurchase.PurchaseItemdDetail_ID, ObjBALClass.ObjPurchase.InNo);
                            //if (ObjBALClass.SavePurchase())
                            //{
                            //    ProgressStatus = true;
                            //}
                        }
                        if (ObjBALClass.SavePurchaseDetailDT(dtDetail))
                        {
                            ProgressStatus = true;
                        }
                        if (ProgressStatus == true)
                        {
                            if (ObjBALClass.ObjPurchase.Extracost != 0 && TotalExtraCost != 0)
                            {
                                ObjBALClass.SaveExtraCost();
                            }
                            if (GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem == "Y")
                            {
                                RevertDiscount();
                            }
                        }
                    }

                }
                else
                {
                    GeneralFunction.Information("AlreadyInvoiceClosed", "PurchaseInvoice");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DeleteList = null;
            }
        }

        internal void btnModifyInvoice()
        {
            try
            {
                if (GeneralFunction.Question("AlertModifyInvoice", "PurchaseInvoice") == DialogResult.Yes)
                {

                    ObjBALClass.ObjPurchase.InvoiceFlag = "PURCHASE";
                    if (ObjBALClass.ModifyPurchase())
                    {
                        ProgressStatus = true;
                    }
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void btnDeleteInvoice()
        //{
        //       if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
        //        {

        //           if(DgvCount>1)
        //           {
        //            if (GeneralFunction.Question("AlertDeleteSelectedRow", "Purchase Invoice") == DialogResult.Yes)
        //            {
        //                DeleteItem("One");
        //            }
        //           }
        //            else
        //           {
        //            if (GeneralFunction.Question("AlertDeleteWholeRow", "Purchase Invoice") == DialogResult.Yes)
        //            {
        //                DeleteItem("All");
        //            }
        //           }

        //        }
        //        else
        //        {
        //            DeleteItem("All");


        //        }
        //    }

        internal void DeleteWholeRecord()
        {
            List<PurchaseObjectClass> objlist;
            try
            {
                objlist = InsertDetails.ToList();
                for (int i = 0; i < objlist.Count; i++)
                {
                    ObjBALClass.ObjPurchase.ItemNo = objlist[i].ItemNo;
                    ObjBALClass.ObjPurchase.ItemQuantity = objlist[i].ItemQuantity;
                    ObjBALClass.ObjPurchase.BarcodeID = objlist[i].BarcodeID;//added on 30-04-2014
                    if ((objlist[i].ItemExpiry == "-") | (objlist[i].ItemExpiry == null) | ((objlist[i].ItemSerialNo) != "0"))
                    {
                        ObjBALClass.ObjPurchase.ItemExpiryDate = null;
                    }
                    else
                    {
                        DateTime expdate = Convert.ToDateTime(objlist[i].ItemExpiryDate.Value);
                        ObjBALClass.ObjPurchase.ItemExpiryDate = Convert.ToDateTime(expdate);
                    }
                    ObjBALClass.ObjPurchase.ItemCost = objlist[i].ItemCost; //Convert.ToDecimal(dgvPurchaseInvoiceData.Rows[i].Cells["unit_price"].Value.ToString());
                    ObjBALClass.ObjPurchase.ItemSerialNo = objlist[i].ItemSerialNo;
                    ObjBALClass.ObjPurchase.ItemUnitPrice = objlist[i].ItemUnitPrice;
                    ObjBALClass.ObjPurchase.ItemPackage = objlist[i].ItemPackage;
                    ObjBALClass.ObjPurchase.Box = objlist[i].Box;
                    DeleteItem();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlist = null;
            }

        }

        internal void DeleteItem()
        {
            try
            {
                //  int listIndex = InsertDetails.FindIndex(a =>(a.ItemNo == ObjBALClass.ObjPurchase.ItemNo && a.ItemUnitPrice == ObjBALClass.ObjPurchase.ItemUnitPrice && a.ItemQuantity == ObjBALClass.ObjPurchase.ItemQuantity));
                int listIndex = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo & a.ItemUnitPrice == ObjBALClass.ObjPurchase.ItemUnitPrice & a.ItemQuantity == ObjBALClass.ObjPurchase.ItemQuantity && (a.Box == ObjBALClass.ObjPurchase.Box) && (a.ItemPackage == ObjBALClass.ObjPurchase.ItemPackage)));

                ObjBALClass.ObjPurchase.BarcodeID = InsertDetails[listIndex].BarcodeID;///added on 30-04-2014
                                                                                       ///
                //discount.Select(a => { a.ModifiedBy = GeneralFunction.UserId; a.SaleID = saleInfo.SaleID; a.ModifiedDate = BenseronEntityModels.GetLocalDateTime(); a.UploadTime = BenseronEntityModels.GetLocalDateTime(); return a; }).ToList();
                int StockLevel = Convert.ToInt32(ObjBALClass.GetDeleteStockCount());
                if (StockLevel < ObjBALClass.ObjPurchase.ItemQuantity)
                {
                    //string ms = GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty");
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty") + " " + "'" + StockLevel.ToString() + "'", "PurhcaseInvoice");
                    if (GeneralFunction.Question("Doyouwanttocontinue", "PurchaseInvoice") == DialogResult.Yes)
                    {
                        ObjBALClass.ObjPurchase.deletestatus = "update";
                        ObjBALClass.ObjPurchase.ItemQuantity = StockLevel;
                        if (ObjBALClass.StockDelete())
                        {
                            ProgressStatus = true;
                            ObjBALClass.ObjPurchase.ItemQuantity = StockLevel;
                            InsertDetails[listIndex].Box = InsertDetails[listIndex].ItemQuantity - StockLevel;
                            InsertDetails[listIndex].ItemQuantity = InsertDetails[listIndex].ItemQuantity - StockLevel;
                            InsertDetails[listIndex].ItemTotal = InsertDetails[listIndex].ItemQuantity * ObjBALClass.ObjPurchase.ItemUnitPrice;
                        }
                    }
                    else
                        return;
                }
                else
                {
                    ObjBALClass.ObjPurchase.deletestatus = "delete";
                    ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                    if (ObjBALClass.StockDelete())
                    {
                        ProgressStatus = true;
                        var item = InsertDetails.Find(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemQuantity == ObjBALClass.ObjPurchase.ItemQuantity) && (a.ItemUnitPrice == ObjBALClass.ObjPurchase.ItemUnitPrice));
                        InsertDetails.RemoveAt(listIndex);

                    }

                }
                ObjBALClass.ObjPurchase.ItemNet = ObjBALClass.ObjPurchase.ItemTotal = InsertDetails.Sum(a => a.ItemTotal);
                if (ObjBALClass.ObjPurchase.Discount != 0)
                {
                    ObjBALClass.ObjPurchase.Discount = ObjBALClass.ObjPurchase.originaldiscount;
                    Discount();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        int invFlagStatus = 0;

        internal void NavigationEvent()
        {



            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    invFlagStatus = (int)InvoiceFlag.First;
                    ObjBALClass.ObjPurchase.InvoiceNo = ID[0];
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Next:

                    invFlagStatus = (int)InvoiceFlag.Next;
                    if (ObjBALClass.ObjPurchase.InvoiceNo != ID[1])
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo + 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = ID[1];
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                case InvoiceFlag.Last:
                    invFlagStatus = (int)InvoiceFlag.Last;
                    ObjBALClass.ObjPurchase.InvoiceNo = ID[1];
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Previous:

                    invFlagStatus = (int)InvoiceFlag.Previous;
                    if (ObjBALClass.ObjPurchase.InvoiceNo != ID[0])
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = ObjBALClass.ObjPurchase.InvoiceNo - 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = ID[0];
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                default:

                    invFlagStatus = 1;
                    long tempID = Convert.ToInt64(ObjBALClass.GetPurInvIDBasedOnNewYearID());
                    if (tempID != null && tempID != 0)
                    {
                        ObjBALClass.ObjPurchase.InvoiceNo = tempID;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        GeneralFunction.Information("Recordnotfound", "PurchaseInvoice");
                    }
                    break;
            }
        }

        internal void SetPaymentDate()
        {

            DateTime nowdt, todaydt = new DateTime();
            nowdt = Convert.ToDateTime(ObjBALClass.ObjPurchase.ItemPaymentDate.Value.ToShortDateString());
            todaydt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            int todaydiff = nowdt.CompareTo(todaydt);
            if (todaydiff >= 0)
            {
                if (ObjBALClass.GetPaymentDate())
                {
                    if (ObjBALClass.UpdatePayment())
                    {
                        GeneralFunction.Information("UpdatePaymentDate", "Purchase Invoice");
                    }
                    else
                    {
                        GeneralFunction.ErrInfo("MustClosePurchaseInvoice", "Purchase Invoice");
                    }
                }
                else
                {
                    if (GeneralFunction.OKCancelMsg("AnotherPaymentSetThisDate", "Purchase Invoice") == DialogResult.OK)
                    {
                        if (ObjBALClass.UpdatePayment())
                        {

                            GeneralFunction.Information("UpdatePaymentDate", "Purchase Invoice");
                        }
                        else
                        {
                            GeneralFunction.ErrInfo("MustClosePurchaseInvoice", "Purchase Invoice");
                        }
                    }
                }
            }
            else
            {
                GeneralFunction.ErrInfo("Selecte Valid Date", "Purchase Invoice");
            }

        }

        internal void ImportInvoice()
        {
            if (!ValidateImportItem()) return;
            string filename = string.Empty;
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "XML Files (*.xml)|*.xml";
            opfd.AddExtension = true;
            opfd.Title = "Open Barcode";
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(opfd.FileName);
                DataTable dtImport = new DataTable("ImportData");
                filename = opfd.FileName.ToString();
                StreamReader myReader = new StreamReader(filename, false);
                XmlSerializer mySerializer = new XmlSerializer(typeof(DataTable));
                if (xmldoc.DocumentElement.Name == "DataTable")
                {
                    dtImport = (DataTable)mySerializer.Deserialize(myReader);
                    if (dtImport.TableName != "ExportData")
                    {
                        GeneralFunction.ErrInfo("Incompatible file, please select the item related exported file", "");
                        return;
                    }
                }
                else
                {
                    GeneralFunction.ErrInfo("Incompatible file, please select the item related exported file", "");
                    return;
                }
                ExportMessage frmExportMessage = new ExportMessage();
                frmExportMessage.Tag = "PurchaseImport";
                frmExportMessage.ShowDialog();
                foreach (DataRow var in dtImport.Rows)
                {
                    ImportMethod = frmExportMessage.ExportMethod;
                    if (AssignValues(var))
                    {
                        ObjBALClass.ObjPurchase.ItemExpiryDate = Convert.ToDateTime(var["Expiry"]);
                        if (ValidateItem())
                        {
                            CheckandInsertData();
                        }
                    }
                }
            }
        }

        internal bool ValidateImportItem()
        {
            if (ObjBALClass.ObjPurchase.InvoiceNo.ToString() == string.Empty)
            {
                GeneralFunction.Information("EmptyInvoiceNo", "PurchaseInvoice");
                ControlName = "txtNewInvoiceNo";
                return false;
            }
            else if (ObjBALClass.ObjPurchase.SupplierName == string.Empty)
            {
                GeneralFunction.Information("EmptySupplierName", "PurchaseInvoice");
                ControlName = "cmbSupplierName";
                return false;
            }
            else return true;

        }

        private bool AssignValues(DataRow dr)
        {
            try
            {

                ObjBALClass.ObjPurchase.ItemPackage = int.Parse(dr["Package"].ToString());
                ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dr["ItemNo"]);
                ObjBALClass.ObjPurchase.ItemBarcode = dr["Barcode"].ToString();
                ObjBALClass.ObjPurchase.ItemName = dr["Description"].ToString();
                ObjBALClass.ObjPurchase.ItemType = Convert.ToInt32(dr["ItemType"]);
                ObjBALClass.ObjPurchase.ItemType = Convert.ToInt32(dr["ItemType"]);
                ObjBALClass.ObjPurchase.ItemPlaceID = 0;
                ObjBALClass.ObjPurchase.ItemCost = 0.000M;
                ObjBALClass.ObjPurchase.ItemMinimumPrice = Convert.ToDecimal(dr["MinimumPrice"].ToString());
                ObjBALClass.ObjPurchase.ItemQuantity = int.Parse(dr["Quantity"].ToString());
                ObjBALClass.ObjPurchase.Reorder = int.Parse(dr["ReOrder"].ToString());
                ObjBALClass.ObjPurchase.MaxOrder = int.Parse(dr["MaxOrder"].ToString());

                ObjBALClass.ObjPurchase.ItemWholeSalePrice = Convert.ToDecimal(dr["WholeSale"].ToString());
                ObjBALClass.ObjPurchase.CategoryNo = 0;

                ObjBALClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.CompanyName = dr["CompName"].ToString();
                ObjBALClass.ObjPurchase.CategoryName = dr["CategoryName"].ToString();
                //ObjBALClass.ObjPurchase.ItemBarcode = dr["AdditionalBarcode"].ToString();
                ObjBALClass.ObjPurchase.PlaceName = dr["ItemPlace"].ToString();
                ObjBALClass.ObjPurchase.ExpiryDate = Convert.ToBoolean(dr["IsExpiry"]);
                //ObjBALClass.ObjPurchase.ItemSerialNo = Convert.ToInt64(dr["SerialNo"]);
                if (ImportMethod == 2)
                {
                    ObjBALClass.ObjPurchase.ItemPrice = Convert.ToDecimal(dr["SalePrice"]);
                    ImportMethod = 1;
                }
                else
                    ImportMethod = 0;
                // Handling If Barcode Exist for Other Item
                DataTable BarcodeDT = ObjBALClass.BarcodeExistForItem();
                if (BarcodeDT.Rows.Count > 0)
                {
                    UserBarcodeSelection user = new UserBarcodeSelection(BarcodeDT, ObjBALClass.ObjPurchase.ItemBarcode, ObjBALClass.ObjPurchase.ItemName);
                    user.ShowDialog();
                    if (!user.IsClose)
                    {
                        if (user.BarcodeId != 0)
                        {
                            Random ran = new Random();
                            ObjBALClass.ObjPurchase.ItemBarcode = GetBarcodeWithCheckSum("21" + Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999))); ;
                            for (int i = 0; i < BarcodeDT.Rows.Count; i++)
                            {
                                int BarcodeID = Convert.ToInt32(BarcodeDT.Rows[i][1]);
                                string Barcode = GetBarcodeWithCheckSum("21" + Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999)));
                                if (BarcodeID != user.BarcodeId)
                                    ObjBALClass.UpdateBarcode(BarcodeID, Barcode);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < BarcodeDT.Rows.Count; i++)
                            {
                                Random ran = new Random();
                                int BarcodeID = Convert.ToInt32(BarcodeDT.Rows[i][1]);
                                string Barcode = GetBarcodeWithCheckSum("21" + Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999)));
                                ObjBALClass.UpdateBarcode(BarcodeID, Barcode);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                //
                ObjBALClass.ObjPurchase.ItemNo = ObjBALClass.SaveExportData(ImportMethod);
                //  CheckInsertItem();
                ItemNameSelectedIndexChange();
                isPackage = (Convert.ToInt32(dr["Ispackage"]) != 0) ? false : true;
                if (isPackage == false)
                    ObjBALClass.ObjPurchase.ItemQuantity = Convert.ToInt32(dr["Ispackage"]);
                else
                    ObjBALClass.ObjPurchase.ItemQuantity = int.Parse(dr["Quantity"].ToString());
                ItemCost = Convert.ToDecimal(dr["ItemCost"]);
                ObjBALClass.ObjPurchase.ItemPackage = int.Parse(dr["Package"].ToString());
                ObjBALClass.ObjPurchase.ItemUnitPrice = Convert.ToDecimal(dr["UnitPrice"].ToString());
                ObjBALClass.ObjPurchase.ExpiryDate = Convert.ToBoolean(dr["IsExpiry"]);
                objSerial.SerialNo = ObjBALClass.ObjPurchase.ItemSerialNo = dr["SerialNo"].ToString();
                if (ImportMethod == 1)
                    ObjBALClass.ObjPurchase.ItemPrice = Convert.ToDecimal(dr["SalePrice"]);
                ObjBALClass.ObjPurchase.ItemExpiryDate = (ObjBALClass.ObjPurchase.ExpiryDate != false) ? DateTime.Parse(dr["Expiry"].ToString()) : DateTime.Now;
                if (PackageQty.Count > 0)
                    ObjBALClass.ObjPurchase.BarcodeID = PackageQty.Where(a => a.ItemPackage == ObjBALClass.ObjPurchase.ItemPackage).ToList()[0].BarcodeID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public string GetBarcodeWithCheckSum(string barcode)
        {

            int index, checksum = 0;
            for (index = 1; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }
            checksum *= 3;
            for (index = 0; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }

            return barcode += (10 - checksum % 10) % 10;

        }
        internal void PayReceipt()
        {

            List<PurchaseObjectClass> objPurlist;
            List<PurchaseObjectClass> Details;
            List<PurchaseObjectClass> PurDetails;
            try
            {
                DataTable dtBalance = new DataTable();

                objPurlist = ObjBALClass.GetPurchaseBalance();
                Details = ObjBALClass.GetPurchaseListDetails();
                PurDetails = Details.Where(a => a.InvoiceNo == ObjBALClass.ObjPurchase.InvoiceNo).ToList();
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(Convert.ToInt32(objPurlist[0].SupplierNo));
                GeneralFunction.AgentDept();
                if (GeneralFunction.ClientDebt != 0)
                {

                    if (objPurlist.Count > 0)
                    {
                        ObjBALClass.ObjPurchase.Balance = Convert.ToDecimal(objPurlist[0].Balance);
                        if ((Convert.ToDecimal(objPurlist[0].Balance) > 0.000m) && (Convert.ToInt32((objPurlist[0].Status)) != 1))
                        {
                            PayReceiptfun(objPurlist, PurDetails);
                        }
                    }
                    else
                    {
                        if (PurDetails.Count > 0)
                        {
                            if (Convert.ToInt32(PurDetails.Select(a => a.Status)) != 1)
                            {
                                PayReceiptfun(objPurlist, PurDetails);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPurlist = null;
                Details = null;
                PurDetails = null;
            }
        }

        private void PayReceiptfun(List<PurchaseObjectClass> objPurlist, List<PurchaseObjectClass> PurDetails)
        {
            Pay_Receipt pay = new Pay_Receipt();
            pay.strPayTo = ObjBALClass.ObjPurchase.SupplierName;
            pay.strPayTo1 = ObjBALClass.ObjPurchase.SupplierNo;
            pay.strDiscription = Additional_Barcode.GetValueByResourceKey("PurInvoiceNo") + " " + ObjBALClass.ObjPurchase.InvoiceNo;
            pay.strDiscriptionArabic = GetInvoiceName("PurchaseInvoice") + " " + ObjBALClass.ObjPurchase.InvoiceNo;
            pay.strValue = objPurlist[0].Balance.ToString();
            pay.strFromInvoice = ObjBALClass.ObjPurchase.InvoiceNo;
            pay.strFlag = (int)CommonHelper.PayReceiptFor.Purchase;
            //DataRow[] drPay;
            //drPay = dtInv.Select("MTB_PURCHASE_INV_ID='" + Txt_InvoiceNo.Text + "'");
            if (PurDetails.Count > 0)
            {
                pay.strFromInvoiceID = Convert.ToInt64(PurDetails[0].InvoiceNo);
                pay.dtPaymentDate = ObjBALClass.ObjPurchase.SetPaymentDate == true ? Convert.ToDateTime(PurDetails[0].ItemPaymentDate) : DateTime.Now;

            }

            pay.Tag = "PurchaseInvoice"; //set the focus on value field (13 may 2014)
            pay.ShowDialog();

            UnderPurchaseInvoice = false;
        }

        internal List<PurchaseObjectClass> GetItemsBasedComCatID()
        {

            List<PurchaseObjectClass> objList;
            try
            {
                objList = ObjBALClass.GetItemNameBasedOnID();
                List<PurchaseObjectClass> ItemList = new List<PurchaseObjectClass>();
                if (GeneralOptionSetting.FlagShowHidenItem == "N")
                {
                    ItemList = objList.Where(a => a.IsHide == false).ToList();
                }
                else
                {
                    ItemList = objList.Where(a => a.IsHide == true || a.IsHide == false).ToList();
                }
                return ItemList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                objList = null;
            }
        }

        internal void DiscountAdjustment()
        {
            Sum = 0;
            if (ObjBALClass.ObjPurchase.Discount == 0)
            {
                RevertDiscount();
                ObjBALClass.ObjPurchase.ItemTotal = Sum;
                ObjBALClass.ObjPurchase.ItemNet = Sum;
            }
            else
            {
                //ObjBALClass.ObjPurchase.ItemTotal = InsertDetails.Sum(a => a.ItemTotal);
                //ObjBALClass.ObjPurchase.ItemNet = InsertDetails.Sum(a => a.ItemTotal);
                decimal totalamount = 0.0m;
                for (int i = 0; i < InsertDetails.Count; i++)
                {
                    if (InsertDetails[i].Box == 0)
                    {
                        totalamount = totalamount + ((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount) * InsertDetails[i].ItemQuantity);
                    }
                    else if (InsertDetails[i].Box != 0)
                    {
                        totalamount = totalamount + ((InsertDetails[i].ItemCost) * InsertDetails[i].Box);
                    }
                }
                ObjBALClass.ObjPurchase.ItemNet = ObjBALClass.ObjPurchase.ItemTotal = totalamount;
            }
            Discount();
        }

        private void RevertDiscount()
        {
            for (int i = 0; i < InsertDetails.Count; i++)
            {
                //    if ((InsertDetails[i].ItemDiscount == null) | InsertDetails[i].ItemDiscount == 0)
                //        InsertDetails[i].ItemDiscount = 0;
                //    Sum = Sum + ((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount) * InsertDetails[i].ItemQuantity);
                //if (InsertDetails[i].ItemDiscount != null)
                //{
                decimal totalitemprice = 0.0m;
                decimal itemtotalvalue = 0.0m;
                //    totalitemprice = Decimal.Parse((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount).ToString());
                //    InsertDetails[i].ItemDiscount = 0;
                //    InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(totalitemprice.ToString("#####0.000"));
                //    itemtotalvalue = Decimal.Parse(((InsertDetails[i].ItemUnitPrice) * (InsertDetails[i].ItemQuantity)).ToString());
                //    InsertDetails[i].ItemTotal = Convert.ToDecimal(itemtotalvalue.ToString("#####0.000"));
                //}
                if (InsertDetails[i].Box == 0)
                {
                    totalitemprice = Decimal.Parse((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount).ToString());
                    InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(totalitemprice.ToString("#####0.000"));
                    itemtotalvalue = Decimal.Parse(((InsertDetails[i].ItemUnitPrice) * (InsertDetails[i].ItemQuantity)).ToString());
                    InsertDetails[i].ItemTotal = Convert.ToDecimal(itemtotalvalue.ToString("#####0.000"));
                    InsertDetails[i].ItemDiscount = 0;
                }
                else if (InsertDetails[i].Box != 0)
                {
                    totalitemprice = Decimal.Parse(((InsertDetails[i].ItemCost / (InsertDetails[i].ItemPackage == 0 ? 1 : InsertDetails[i].ItemPackage)) * 1000m / 1000m).ToString());
                    InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(totalitemprice.ToString("#####0.000"));
                    itemtotalvalue = Decimal.Parse(((InsertDetails[i].ItemUnitPrice) * (InsertDetails[i].ItemQuantity)).ToString()); // added by T on 7-Spet-2019 //Decimal.Parse(((InsertDetails[i].ItemCost) * (InsertDetails[i].Box)).ToString());  // Commit by T on 7-Spet-2019
                    InsertDetails[i].ItemTotal = Convert.ToDecimal(itemtotalvalue.ToString("#####0.000"));
                    InsertDetails[i].ItemDiscount = 0;
                }
            }
            Sum = InsertDetails.Sum(a => a.ItemTotal);
        }

        private void Discount()
        {
            float IsIncreaes = 0.0f;
            if ((ObjBALClass.ObjPurchase.ItemTotal.ToString() != string.Empty) && (ObjBALClass.ObjPurchase.Discount.ToString() != string.Empty))
            {
                IsIncreaes = ObjBALClass.IsIncreaseForAgent();
                if (ObjBALClass.ObjPurchase.DiscountType == 1)
                {
                    ObjBALClass.ObjPurchase.TotalPercentage = ObjBALClass.ObjPurchase.Discount;
                    if (IsIncreaes == 1)
                        ObjBALClass.ObjPurchase.ItemNet = Decimal.Parse((ObjBALClass.ObjPurchase.ItemTotal + ObjBALClass.ObjPurchase.Discount).ToString());
                    else
                        ObjBALClass.ObjPurchase.ItemNet = Decimal.Parse((ObjBALClass.ObjPurchase.ItemTotal - ObjBALClass.ObjPurchase.Discount).ToString());
                    ObjBALClass.ObjPurchase.Discount = ObjBALClass.ObjPurchase.TotalPercentage;
                }
                else if (ObjBALClass.ObjPurchase.DiscountType == 0)
                {
                    ObjBALClass.ObjPurchase.TotalPercentage = Decimal.Parse((ObjBALClass.ObjPurchase.ItemTotal * ObjBALClass.ObjPurchase.Discount / 100).ToString());
                    if (IsIncreaes == 1)
                        ObjBALClass.ObjPurchase.ItemNet = Decimal.Parse((ObjBALClass.ObjPurchase.ItemTotal + ObjBALClass.ObjPurchase.TotalPercentage).ToString());
                    else
                        ObjBALClass.ObjPurchase.ItemNet = Decimal.Parse((ObjBALClass.ObjPurchase.ItemTotal - ObjBALClass.ObjPurchase.TotalPercentage).ToString());
                    ObjBALClass.ObjPurchase.Discount = ObjBALClass.ObjPurchase.TotalPercentage;

                }
            }
        }

        private void DivideDiscountBeforeClosing()
        {
            try
            {
                decimal net = 0.000m;
                decimal totalpercentage = 0;
                decimal itemunitprice = 0.000m;
                decimal itemunitprice1 = 0.000m;
                decimal itemdiscount = 0.000m;
                decimal itemtotalvalue = 0.000m;

                if ((ObjBALClass.ObjPurchase.ItemDiscount != 0) && (ObjBALClass.ObjPurchase.ItemDiscount.ToString() != string.Empty) && (ObjBALClass.ObjPurchase.ItemTotal != 0) && (ObjBALClass.ObjPurchase.ItemTotal.ToString() != string.Empty))
                {
                    if (ObjBALClass.ObjPurchase.DiscountType == 1)
                    {
                        decimal.TryParse(((((ObjBALClass.ObjPurchase.ItemDiscount) / (ObjBALClass.ObjPurchase.ItemTotal)) * 100).ToString()), out totalpercentage);
                        // totalpercentage = ((ObjBALClass.ObjPurchase.ItemDiscount) / (ObjBALClass.ObjPurchase.ItemTotal)) * 100;
                        for (int i = 0; i < InsertDetails.Count; i++)
                        {
                            if (InsertDetails[i].ItemDiscount.ToString() != string.Empty)
                            {
                                InsertDetails[i].ItemUnitPrice = (InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount);
                            }

                            itemunitprice1 = InsertDetails[i].ItemUnitPrice;
                            itemunitprice = Decimal.Parse((itemunitprice1 - (itemunitprice1 * (totalpercentage / 100))).ToString());
                            itemdiscount = Decimal.Parse((itemunitprice1 * (totalpercentage / 100)).ToString());
                            InsertDetails[i].ItemDiscount = Convert.ToDecimal(itemdiscount.ToString("#####0.000"));
                            InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(itemunitprice.ToString("#####0.000"));
                            if (InsertDetails[i].Box == 0)
                            {
                                itemtotalvalue = Decimal.Parse((InsertDetails[i].ItemUnitPrice * InsertDetails[i].ItemQuantity).ToString());
                            }
                            else if (InsertDetails[i].Box != 0)
                            {
                                itemtotalvalue = ((InsertDetails[i].ItemCost - (InsertDetails[i].ItemDiscount * InsertDetails[i].ItemPackage)) * InsertDetails[i].Box);
                            }
                            InsertDetails[i].ItemTotal = Convert.ToDecimal(itemtotalvalue.ToString("#####0.000"));
                            net = net + InsertDetails[i].ItemTotal;

                        }
                    }
                    else
                    {
                        totalpercentage = (ObjBALClass.ObjPurchase.ItemTotal * (ObjBALClass.ObjPurchase.ItemDiscount / 100));
                        for (int i = 0; i < InsertDetails.Count; i++)
                        {
                            if (InsertDetails[i].ItemDiscount != null)
                            {
                                decimal totalitemprice = 0.000m;
                                totalitemprice = Decimal.Parse((InsertDetails[i].ItemUnitPrice + InsertDetails[i].ItemDiscount).ToString());
                                InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(totalitemprice.ToString("#####0.000"));
                            }
                            itemunitprice1 = InsertDetails[i].ItemUnitPrice;
                            itemunitprice = Decimal.Parse((itemunitprice1 - (itemunitprice1 * (ObjBALClass.ObjPurchase.ItemDiscount / 100))).ToString());
                            itemdiscount = Decimal.Parse((itemunitprice1 * (ObjBALClass.ObjPurchase.ItemDiscount / 100)).ToString());
                            InsertDetails[i].ItemDiscount = Convert.ToDecimal(itemdiscount.ToString("#####0.000"));
                            InsertDetails[i].ItemUnitPrice = Convert.ToDecimal(itemunitprice.ToString("#####0.000"));
                            //itemtotalvalue = Decimal.Parse((InsertDetails[i].ItemUnitPrice * InsertDetails[i].ItemQuantity).ToString());Commaneded on 30/05/2014
                            if (InsertDetails[i].Box == 0)
                            {
                                itemtotalvalue = Decimal.Parse((InsertDetails[i].ItemUnitPrice * InsertDetails[i].ItemQuantity).ToString());
                            }
                            else if (InsertDetails[i].Box != 0)
                            {
                                itemtotalvalue = ((InsertDetails[i].ItemCost - (InsertDetails[i].ItemDiscount * InsertDetails[i].ItemPackage)) * InsertDetails[i].Box);
                            }
                            InsertDetails[i].ItemTotal = Convert.ToDecimal(itemtotalvalue.ToString("#####0.000"));
                            net = net + InsertDetails[i].ItemTotal;
                        }
                    }
                    ObjBALClass.ObjPurchase.ItemNet = (GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem == "Y") ? ObjBALClass.ObjPurchase.ItemNet : net;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetInvoiceName(string strKey)
        {
            try
            {
                switch (strKey)
                {
                    case "PurchaseInvoice":
                        return "ÝÇÊæÑÉ ãÔÊÑíÇÊ";
                    case "SaleInvoice":
                        return "ÝÇÊæÑÉ ãÈíÚÇÊ";
                    case "PurchaseReturnInvoice":
                        return "ÊÑÌíÚ ãÔÊÑíÇÊ ";
                    case "SaleReturnInvoice":
                        return "ÊÑÌíÚ ãÈíÚÇÊ ";
                    case "RentInvoice":
                        return "ÝÇÊæÑÉ ÇíÌÇÑ";
                    case "PayReceipt":
                        return "ÇíÕÇá ÕÑÝ";
                    case "ReceiveReceipt":
                        return "ÇíÕÇá ÞÈÖ";
                    case "Receivable":
                        return "ÇáãÞÈæÖÇÊ";
                    case "Payable":
                        return "ÇáãÏÝæÚÇÊ";
                    case "DebtAdjustment":
                        return "ÊÚÏíá ÇÑÕÏÉ";
                    default:
                        return strKey;
                }

            }
            catch (Exception)
            {
                return strKey;
            }
        }

        internal void BoxPieceAction()
        {
            if (isPackage == false)
            {
                //if (ObjBALClass.ObjPurchase.ItemStock != 0)//
                //{
                ObjBALClass.ObjPurchase.ItemStock = (((ObjBALClass.ObjPurchase.ItemTotalStock != null) ? ObjBALClass.ObjPurchase.ItemTotalStock : 0) + ObjBALClass.ObjPurchase.ItemQuantity);
                piececost = ObjBALClass.ObjPurchase.ItemCost / ((ObjBALClass.ObjPurchase.ItemPackage == 0) ? 1 : ObjBALClass.ObjPurchase.ItemPackage);
                piececost = ObjBALClass.ObjPurchase.ItemCost = Convert.ToDecimal(piececost.ToString("#####0.000"));
                isPackage = true;
                //}
            }
            else
            {
                int stock = (ObjBALClass.ObjPurchase.ItemTotalStock != null) ? ObjBALClass.ObjPurchase.ItemTotalStock : 0;
                ObjBALClass.ObjPurchase.ItemStock = ((Convert.ToInt32(stock) / ((ObjBALClass.ObjPurchase.ItemPackage > 0) ? ObjBALClass.ObjPurchase.ItemPackage : 1)) + ObjBALClass.ObjPurchase.ItemQuantity);
                decimal strr = ((stock) % (ObjBALClass.ObjPurchase.ItemPackage == 0 ? 1 : ObjBALClass.ObjPurchase.ItemPackage));
                //ObjBALClass.ObjPurchase.ItemCost = ObjBALClass.ObjPurchase.ItemCost * (ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1);
                //above line to solve 
                if (piececost == ItemUnitPrice)
                {
                    if (ObjBALClass.ObjPurchase.ItemCardPackageQty == ObjBALClass.ObjPurchase.ItemPackage)
                    {
                        ObjBALClass.ObjPurchase.ItemCost = ItemCost;
                    }
                    else
                        ObjBALClass.ObjPurchase.ItemCost = (ItemUnitPrice * (ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1));
                }
                else
                {
                    // added this 28-Feb-2019 if statement
                    if (ObjBALClass.ObjPurchase.TotalPackageCount == 1)
                        ObjBALClass.ObjPurchase.ItemCost = ItemCost = ItemUnitPrice;
                    else
                        ObjBALClass.ObjPurchase.ItemCost = ItemCost = (ItemUnitPrice * (ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjBALClass.ObjPurchase.ItemPackage : 1));
                }
                isPackage = false;
            }
        }

        internal bool SaveNewAgent()
        {
            if (ObjBALClass.SaveAgentDetails())
            {
                CommonHelper.GeneralFunction.Information("Agentdetailsaresaved", "PurchaseInvoice");
                return true;
            }
            else
                return false;

        }

        private void TaxCalculation()
        {
            ObjBALClass.ObjPurchase.Tax = 0;
            ObjBALClass.ObjPurchase.Tax1 = 0;

            ObjBALClass.ObjPurchase.Tax = InsertDetails.Sum(a => a.ItemTax1);
            ObjBALClass.ObjPurchase.Tax1 = InsertDetails.Sum(a => a.ItemTax2);
        }

        internal void GridCellDoubleClick()
        {
            this.ItemNameSelectedIndexChange();
            if (ObjBALClass.ObjPurchase.ItemType == 2)
            {
                //objSerial.ItemName = ObjBALClass.ObjPurchase.ItemName;
                //objSerial.ItemID = ObjBALClass.ObjPurchase.ItemNo;
                //objSerial.ShowDialog();
            }
            else
                return;
        }

        internal void GridDataUpdate()
        {
            int listIndex = InsertDetails.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchase.ItemNo) && (a.ItemUnitPrice == ObjBALClass.ObjPurchase.ItemUnitPrice) && (a.ItemQuantity == ObjBALClass.ObjPurchase.ItemQuantity));
            AssignListValuesToObject(listIndex);
            if (ObjBALClass.SavePurchase())
                ProgressStatus = true;
        }
        internal void AssignDataSource(DataGridView dgvPurchaseInvoiceData)
        {
            dgvPurchaseInvoiceData.AutoGenerateColumns = false;
            dgvPurchaseInvoiceData.DataSource = null;
            dgvPurchaseInvoiceData.Rows.Clear();
            //dgvPurchaseInvoiceData.DataSource = new BindingSource();

            InsertDetails = SortList(InsertDetails);
            //  DataTable dt = GeneralFunction.SortInvoiceDetails(ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InsertDetails), "ItemDescription", "ItemUnitPrice");
            DataTable dt = ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InsertDetails);
            //  dgvPurchaseInvoiceData.DataSource = new BindingContext();

            //  dgvPurchaseInvoiceData.Refresh();  This is commented to avoid blinking when insert the item into grid.
            dgvPurchaseInvoiceData.DataSource = dt;
            //////To highlight the last inserted record    on 06 jun 2014//////////////////
            //if (dgvPurchaseInvoiceData.Rows.Count > 0)
            //{

            //    //dgvPurchaseInvoiceData.ClearSelection();

            //    //dgvPurchaseInvoiceData.FirstDisplayedScrollingRowIndex = dgvPurchaseInvoiceData.Rows.Count - 1;

            //    //dgvPurchaseInvoiceData.Rows[dgvPurchaseInvoiceData.Rows.Count - 1].Selected = true;
            //    for (int i = 0; i < dgvPurchaseInvoiceData.Rows.Count; i++)
            //    {
            //        dgvPurchaseInvoiceData.Rows[i].Selected = false;
            //        //dgrSaleInvoice.Rows[i].DefaultCellStyle.BackColor = Color.White;
            //        //if (dgrSaleInvoice.Rows[i].Cells[2].Value.ToString() == ComboItemName)
            //        //    DgvPerInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            //        dgvPurchaseInvoiceData.Rows[dgvPurchaseInvoiceData.Rows.Count - 1].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            //    }
            //}
            /////////////////////////////////////////////////////////////////////////////////////
        }

        public static List<PurchaseObjectClass> SortList(List<PurchaseObjectClass> list)
        {
            List<PurchaseObjectClass> sort = new List<PurchaseObjectClass>();
            switch (GeneralOptionSetting.FlagItemSorting)
            {
                case "0":
                    sort = list.OrderBy(a => a.ItemDescription).ToList();
                    break;
                case "1":
                    sort = list.OrderByDescending(a => a.ItemDescription).ToList(); // (from l in list where l.ItemName orderbyDe l.ItemName descending select l).ToList();
                    break;
                case "4":
                    sort = list.OrderBy(a => a.ItemUnitPrice).ToList();
                    break;
                case "3":
                    sort = list.OrderByDescending(a => a.ItemUnitPrice).ToList();
                    break;
                default:
                    sort = list.OrderBy(a => a.Time == string.Empty ? DateTime.MinValue : Convert.ToDateTime(a.Time)).ToList();
                    break;
            }
            return sort;
        }

        public void btnPrint()
        {
            //PurchaseInvoiceDetails ObjInvoiceDetails = new PurchaseInvoiceDetails();
            // Rpt_SimpleInvoice rptdesign = new Rpt_SimpleInvoice();
            // Rpt_Purchase_Invoice_No_WithoutTaxDiscount_A5 rpt = new Rpt_Purchase_Invoice_No_WithoutTaxDiscount_A5();
            //Rpt_Purchase_Invoice_No_WithoutTaxDiscount rpt = new Rpt_Purchase_Invoice_No_WithoutTaxDiscount();
            //Rpt_Purchase_Invoice_No_WithoutTax_A5 rpt = new Rpt_Purchase_Invoice_No_WithoutTax_A5();
            //Rpt_Purchase_Invoice_No_WithoutTax rpt = new Rpt_Purchase_Invoice_No_WithoutTax();
            //Rpt_Purchase_Invoice_No_WithoutDiscount_A5 rpt = new Rpt_Purchase_Invoice_No_WithoutDiscount_A5();
            // Rpt_Purchase_Invoice_No_WithoutDiscount rpt = new Rpt_Purchase_Invoice_No_WithoutDiscount();
            //Rpt_Purchase_Invoice_No_A5 rpt = new Rpt_Purchase_Invoice_No_A5();
            //Rpt_Purchase_Invoice_No rpt = new Rpt_Purchase_Invoice_No();
            //Rpt_Purchase_Invoice_No_A4Landscape rpt = new Rpt_Purchase_Invoice_No_A4Landscape();
            //Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount rpt = new Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount();
            // Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount rpt = new Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount();
            //  Rpt_Purchase_Invoice_No_WithoutTax rpt = new Rpt_Purchase_Invoice_No_WithoutTax();
            //Rpt_Purchase_Invoice_No_A5 rpt = new Rpt_Purchase_Invoice_No_A5();
            //Rpt_SimpleInvoiceWithoutTaxDiscount_A5 rpt = new Rpt_SimpleInvoiceWithoutTaxDiscount_A5();
            //Rpt_SimpleInvoiceWithoutTaxDiscount_A4Landscape rpt = new Rpt_SimpleInvoiceWithoutTaxDiscount_A4Landscape();
            //Rpt_SimpleInvoiceWithoutTax_A5 rpt = new Rpt_SimpleInvoiceWithoutTax_A5();
            //Rpt_SimpleInvoiceWithoutTax_A4Landscape rpt = new Rpt_SimpleInvoiceWithoutTax_A4Landscape();
            //Rpt_SimpleInvoiceWithoutTaxDiscount rpt = new Rpt_SimpleInvoiceWithoutTaxDiscount();
            // Rpt_SimpleInvoiceWithoutTax_A5 rpt = new Rpt_SimpleInvoiceWithoutTax_A5();
            //Rpt_SimpleInvoiceWithoutTax_A4Landscape rpt = new Rpt_SimpleInvoiceWithoutTax_A4Landscape();
            // Rpt_SimpleInvoiceWithoutTax rpt = new Rpt_SimpleInvoiceWithoutTax();
            //Rpt_SimpleInvoiceWithoutDiscount_A5 rpt = new Rpt_SimpleInvoiceWithoutDiscount_A5();
            //Rpt_SimpleInvoiceWithoutDiscount_A4Landscape rpt = new Rpt_SimpleInvoiceWithoutDiscount_A4Landscape();
            //Rpt_SimpleInvoiceWithoutDiscount rpt = new Rpt_SimpleInvoiceWithoutDiscount();
            // Rpt_SimpleInvoice_A5 rpt = new Rpt_SimpleInvoice_A5();
            // Rpt_SimpleInvoice_A4Landscape rpt = new Rpt_SimpleInvoice_A4Landscape();
            //Rpt_CompleteInvoice_WithoutTaxDiscount  rpt = new Rpt_CompleteInvoice_WithoutTaxDiscount();
            //Rpt_CompleteInvoice_WithoutTax rpt = new Rpt_CompleteInvoice_WithoutTax();
            // Rpt_CompleteInvoice_WithoutDiscount rpt = new Rpt_CompleteInvoice_WithoutDiscount();
            // Rpt_CompleteInvoice_A5_WithoutTaxDiscount rpt = new Rpt_CompleteInvoice_A5_WithoutTaxDiscount();
            //Rpt_CompleteInvoice_A5_WithoutTax rpt = new Rpt_CompleteInvoice_A5_WithoutTax();
            //Rpt_CompleteInvoice_A5_WithoutDiscount rpt = new Rpt_CompleteInvoice_A5_WithoutDiscount();
            //Rpt_CompleteInvoice_A5 rpt = new Rpt_CompleteInvoice_A5();
            //Rpt_CompleteInvoice_A4Landscape_WithoutTaxDiscount rpt = new Rpt_CompleteInvoice_A4Landscape_WithoutTaxDiscount();
            //Rpt_CompleteInvoice_A4Landscape_WithoutTax rpt = new Rpt_CompleteInvoice_A4Landscape_WithoutTax();
            //Rpt_CompleteInvoice_A4Landscape_WithoutDiscount rpt = new Rpt_CompleteInvoice_A4Landscape_WithoutDiscount();
            //Rpt_CompleteInvoice_A4Landscape rpt = new Rpt_CompleteInvoice_A4Landscape();
            //Rpt_CompleteInvoice rpt = new Rpt_CompleteInvoice();
            // Rpt_Invoice_63mm rpt = new Rpt_Invoice_63mm();
            // Rpt_Invoice_80mm rpt = new Rpt_Invoice_80mm();
            CurrencyConverter ObjCC = new CurrencyConverter();
            ReportDocument summery = new ReportDocument();
            Obj_viewer = new ReportsView();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoice");
            //summery = rpt;
            // summery.Refresh();
            decimal Total = 0.000M, packTax1 = 0.000m, packTax2 = 0.000m, TotalTax1 = 0.000m, TotalTax2 = 0.000m;
            dt = new DataTable("PurchaseInvoice");
            dt = ObjBALClass.ReportValues();
            if (dt.Rows.Count > 0)
            {
                dt = GeneralFunction.SortInvoiceDetails(dt, "ItemName", "UnitPrice");
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["AgentID"].ToString());
                GeneralFunction.AgentDept();
            }
            DataTable dtLocal = SpoiledItemHelper.SimpleInvoiceDataTable();
            string actualtotal1, actualtotal2, tax1 = "0.000", tax2 = "0.000", paramtax1 = "0.000", paramtax2 = "0.000";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["Box"]) == 0)
                {
                    //itemtax = Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) + Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString());
                    TotalTax1 += (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString());
                    TotalTax2 += (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString());
                }
                else
                {
                    // packTax1 = (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                    // packTax2 = (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                    // itemtax = packTax1 + packTax2;
                    //TotalTax1 += (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString())* Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString());
                    //TotalTax2 += (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString())* Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString());
                    TotalTax1 += (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) * Convert.ToInt32(dt.Rows[i]["Box"]));
                    TotalTax2 += (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) * Convert.ToInt32(dt.Rows[i]["Box"]));
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();
                drAdd["InvoiceName"] = "Purchase Invoice";
                drAdd["InvoiceNo"] = dt.Rows[i]["YearSequenceNo"].ToString();
                drAdd["InvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["PurchaseDate"].ToString()).ToShortDateString(); ;
                drAdd["CustomerId"] = dt.Rows[i]["AgentID"].ToString();
                drAdd["CustomerName"] = dt.Rows[i]["AgentName"].ToString();
                drAdd["ItemNo"] = dt.Rows[i]["ItemID"].ToString();
                drAdd["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                // drAdd["Expiry"] = dt.Rows[i]["ExpiryDate"].ToString();
                if (dt.Rows[i]["ExpiryDate"].ToString() == "-" || dt.Rows[i]["ExpiryDate"] == DBNull.Value)
                {
                    drAdd["Expiry"] = "-";
                }
                else
                {
                    drAdd["Expiry"] = Convert.ToDateTime(dt.Rows[i]["ExpiryDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                }
                drAdd["Quantity"] = dt.Rows[i]["Quantity"].ToString();
                if (Convert.ToInt32(dt.Rows[i]["Box"]) == 0)
                {
                    itemtax = Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString()) * ((Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) + (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())));
                    // TotalTax1+= Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString());
                    // TotalTax2 += Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString());
                }
                else
                {
                    //packTax1 = (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                    //packTax2 = (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                    packTax1 = (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) * Convert.ToInt32(dt.Rows[i]["Box"]));
                    packTax2 = (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) * Convert.ToInt32(dt.Rows[i]["Box"]));
                    itemtax = (packTax1 + packTax2);
                    // TotalTax1 += (Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                    //TotalTax2 += (Convert.ToDecimal(dt.Rows[i]["Itemtax2"].ToString()) / Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString())) * Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                }
                //drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString()) - Decimal.Parse(((itemtax / Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString())) * 1000m / 1000m).ToString("#####0.000"));///Quantity include to fix the Tax not calculated properly
                drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString()) - Decimal.Parse(((itemtax / Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString())) * 1000m / 1000m).ToString("#####0.000"));///Quantity include to fix the Tax not calculated properly
                //drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString()) - itemtax; //Decimal.Parse(((itemtax / Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString())) * 1000m / 1000m).ToString("#####0.000"));///Quantity include to fix the Tax not calculated properly
                drAdd["Total"] = (Convert.ToDecimal(drAdd["UnitPrice"].ToString()) + Convert.ToDecimal(dt.Rows[i]["Discount"].ToString())) * Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString()); //Convert.ToDecimal(dt.Rows[i]["MTB_TOTAL"].ToString());
                //drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["Total"]) - Convert.ToDecimal(dt.Rows[i]["ItemTax1"]);
                actualtotal1 = (GeneralOptionSetting.FlagTax1_ApplyBeforeDiscount == "Y") ? Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()).ToString("#####0.000") : Convert.ToDecimal(dt.Rows[i]["NetAmount"].ToString()).ToString("#####0.000");
                if (actualtotal1 != "0.000")
                {
                    //if (Convert.ToInt32(dt.Rows[i]["Box"]) != 0)
                    //{
                    if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "0")
                        //tax1 = Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()) / Convert.ToDecimal(actualtotal1)) * 100).ToString("0.00") + "" + "%";
                        tax1 = Convert.ToDecimal(dt.Rows[i]["TaxPercentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["TaxSub"].ToString()).ToString("0.00") + "" + "%";
                    else if ((GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "-1"))
                        // tax1 = Convert.ToDecimal(dt.Rows[i]["Tax"].ToString()).ToString("#####0.000");
                        tax1 = TotalTax1.ToString("#####0.000");
                    else if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "2")
                        tax1 = Convert.ToDecimal(dt.Rows[i]["TaxPercentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["TaxSub"].ToString()).ToString("0.00") + "" + "%" + "," + TotalTax1.ToString("#####0.000"); //Convert.ToDecimal(dt.Rows[i]["Tax"].ToString()).ToString("#####0.000");
                    else
                        tax1 = "0.000";
                    paramtax1 = Convert.ToDecimal(dt.Rows[i]["Tax"].ToString()).ToString("#####0.000");

                    //}
                    //else
                    //{
                    //    if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "0")
                    //        tax1 = Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()) / Convert.ToDecimal(actualtotal1)) * 100).ToString("0.00") + "" + "%";
                    //        tax1 = Convert.ToDecimal(dt.Rows[i]["TaxPercentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["TaxSub"].ToString()).ToString("0.00") + "" + "%";
                    //    else if ((GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "-1"))
                    //        tax1 = packTax1.ToString();
                    //    else if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "2")
                    //        tax1 = Convert.ToDecimal(dt.Rows[i]["TaxPercentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["TaxSub"].ToString()).ToString("0.00") + "" + "%" + "," + packTax1.ToString();
                    //    else
                    //        tax1 = "0.000";
                    //    paramtax1 = packTax1.ToString();
                    //}

                    //if (tax1 == "0.000" && ObjBALClass.ObjPurchase.Status == 1)
                    //{
                    //    t1 = +Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString());
                    //    paramtax1 = t1.ToString();
                    //}
                    //else
                }
                else tax1 = "0.000";


                actualtotal2 = (GeneralOptionSetting.FlagTax2_ApplyBeforeDiscount == "Y") ? Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()).ToString("#####0.000") : Convert.ToDecimal(dt.Rows[i]["NetAmount"].ToString()).ToString("#####0.000");
                if (actualtotal2 != "0.000")
                {
                    //if (Convert.ToInt32(dt.Rows[i]["Box"]) != 0)
                    //{
                    if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "0")
                        tax2 = Convert.ToDecimal(dt.Rows[i]["Tax1Percentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["Tax1Sub"].ToString()).ToString("0.00") + "" + "%";
                    else if ((GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "-1"))
                        // tax2 = Convert.ToDecimal(dt.Rows[i]["Tax1"].ToString()).ToString("#####0.000");
                        tax2 = TotalTax2.ToString("#####0.000");
                    else if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "2")
                        tax2 = Convert.ToDecimal(dt.Rows[i]["Tax1Percentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["Tax1Sub"].ToString()).ToString("0.00") + "" + "%" + "," + TotalTax2.ToString("#####0.000"); //Convert.ToDecimal(dt.Rows[i]["Tax1"].ToString()).ToString("#####0.000");
                    else
                        tax2 = "0.000";
                    //if (tax1 == "0.000" && ObjBALClass.ObjPurchase.Status == 1 && Convert.ToDecimal(dt.Rows[i]["Tax1"])==0.0m)
                    //{

                    //    t2 = +Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString());
                    //    paramtax2 = t2.ToString();
                    //}
                    //else
                    paramtax2 = Convert.ToDecimal(dt.Rows[i]["Tax1"].ToString()).ToString("#####0.000");
                    // paramtax2 = Convert.ToDecimal(dt.Rows[i]["Tax1"].ToString()).ToString("#####0.000");
                    //}
                    //else
                    //{
                    //    if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "0")
                    //        tax2 = Convert.ToDecimal(dt.Rows[i]["Tax1Percentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["Tax1Sub"].ToString()).ToString("0.00") + "" + "%";
                    //    else if ((GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "-1"))
                    //        tax2 = packTax2.ToString();
                    //    else if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "2")
                    //        tax2 = Convert.ToDecimal(dt.Rows[i]["Tax1Percentage"].ToString()).ToString("0.00") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["Tax1Sub"].ToString()).ToString("0.00") + "" + "%" + "," + packTax2.ToString();
                    //    else
                    //        tax2 = "0.000";
                    //    //if (tax1 == "0.000" && ObjBALClass.ObjPurchase.Status == 1 && Convert.ToDecimal(dt.Rows[i]["Tax1"])==0.0m)
                    //    //{

                    //    //    t2 = +Convert.ToDecimal(dt.Rows[i]["Itemtax1"].ToString());
                    //    //    paramtax2 = t2.ToString();
                    //    //}
                    //    //else
                    //    paramtax2 = packTax2.ToString();
                    //}
                }
                else
                    tax2 = "0.000";
                //if (tax1 == "0.000" && ObjBALClass.ObjPurchase.Status == 1 && Convert.ToDecimal(dt.Rows[i]["Tax1"]) == 0.0m && Convert.ToDecimal(dt.Rows[i]["Itemtax1"]) != 0.0m)
                //    drAdd["Tax1"] = t1.ToString();
                //else
                drAdd["Tax1"] = tax1;
                //if (tax2 == "0.000" && ObjBALClass.ObjPurchase.Status == 1 && Convert.ToDecimal(dt.Rows[i]["Tax1"]) == 0.0m && Convert.ToDecimal(dt.Rows[i]["Itemtax2"]) != 0.0m)
                //    drAdd["Tax1"] = t2.ToString();
                //else
                drAdd["Tax2"] = tax2;
                drAdd["Discount"] = Convert.ToDecimal(dt.Rows[i]["Discount"].ToString());
                drAdd["MaxDept"] = Convert.ToDecimal(dt.Rows[i]["Debt"].ToString());
                drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                drAdd["Users"] = dt.Rows[i]["CreatedBy"].ToString();
                drAdd["TotalLetters"] = "";
                drAdd["Unit"] = "0";
                drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"].ToString() == string.Empty ? dt.Rows[i]["PurchaseDate"] : dt.Rows[i]["LastInvoiceDate"]).Date;
                drAdd["AmountDue"] = Convert.ToDecimal(dt.Rows[i]["LastInvoice"].ToString()).ToString("######0.000");
                //drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString();
                drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();
                drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                // drAdd["DiscountPercentage"] = Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                drAdd["DiscountPercentage"] = Convert.ToDecimal(dt.Rows[i]["TotalDiscount"].ToString());
                drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString()) : 1);
                Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                drAdd["PaymentCharges"] = 0;
                dtLocal.Rows.Add(drAdd);
            }
            if (dtLocal.Rows.Count > 0)
            {
                Obj_viewer.Report_Table = dtLocal;
                Obj_viewer.HTable.Clear();
                if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                {
                    Obj_viewer.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000")));

                }

                DataTable dtPaidRemain = new DataTable("PaidRemain");
                dtPaidRemain = ObjBALClass.GetPurchasePaidRemainingBal();

                if (dtPaidRemain.Rows.Count > 0)
                {
                    Obj_viewer.HTable.Add("Paid", dtPaidRemain.Rows[0][0]);
                    //Obj_viewer.HTable.Add("Remaining", dtPaidRemain.Rows[0][0]);
                }
                else
                {
                    Obj_viewer.HTable.Add("Paid", 0.0);
                    //Obj_viewer.HTable.Add("Remaining", 0.0);
                }

                Obj_viewer.HTable.Add("note", ObjBALClass.ObjPurchase.CheckNote == true ? ObjBALClass.ObjPurchase.Note : "");
                Obj_viewer.HTable.Add("IncludeTax", ObjBALClass.ObjPurchase.IncludeTax == true ? "Yes" : "No");
                //Obj_viewer.HTable.Add("Tax1", paramtax1 != string.Empty ? paramtax1 : "0.000");
                //Obj_viewer.HTable.Add("Tax2", paramtax2 != string.Empty ? paramtax2 : "0.000");
                Obj_viewer.HTable.Add("Tax1", TotalTax1 != 0 ? TotalTax1.ToString() : "0.000");
                Obj_viewer.HTable.Add("Tax2", TotalTax2 != 0 ? TotalTax2.ToString() : "0.000");
                Obj_viewer.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                Obj_viewer.HTable.Add("InvoiceName", GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoice"));

                if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                {
                    Obj_viewer.HTable.Add("monthformat", 0);
                    Obj_viewer.HTable.Add("dayformat", 0);
                    Obj_viewer.HTable.Add("yearformat", 0);
                    Obj_viewer.HTable.Add("seperatorformat", "/");
                    Obj_viewer.HTable.Add("dateformat", 0);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                {
                    Obj_viewer.HTable.Add("monthformat", 1);
                    Obj_viewer.HTable.Add("dayformat", 1);
                    Obj_viewer.HTable.Add("yearformat", 1);
                    Obj_viewer.HTable.Add("seperatorformat", "/");
                    Obj_viewer.HTable.Add("dateformat", 1);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                {
                    Obj_viewer.HTable.Add("monthformat", 1);
                    Obj_viewer.HTable.Add("dayformat", 1);
                    Obj_viewer.HTable.Add("yearformat", 1);
                    Obj_viewer.HTable.Add("seperatorformat", "-");
                    Obj_viewer.HTable.Add("dateformat", 0);
                }
                else
                {
                    Obj_viewer.HTable.Add("monthformat", 1);
                    Obj_viewer.HTable.Add("dayformat", 1);
                    Obj_viewer.HTable.Add("yearformat", 1);
                    Obj_viewer.HTable.Add("seperatorformat", "/");
                    Obj_viewer.HTable.Add("dateformat", 0);
                }
                Obj_viewer.HideLogo = ObjBALClass.ObjPurchase.SetStatus == 1 ? true : false;
                var debtValue = GeneralOptionSetting.FlagShowDeptOnPrint;
                Obj_viewer.HideDebt = ObjBALClass.ObjPurchase.SetPaymentDate == true ? true : false;
                if (GeneralOptionSetting.FlagShowDeptOnPrint == "Y")
                    GeneralOptionSetting.FlagShowDeptOnPrint = Obj_viewer.HideDebt == true ? "N" : "Y";

                Obj_viewer.RptDoc = OrderInvoiceHelper.ReportSelection();
                Obj_viewer.isInvoice = true;
                if (Obj_viewer.RptDoc is Rpt_Invoice_80mm || Obj_viewer.RptDoc is Rpt_Invoice_63mm)
                {
                    Obj_viewer.HTable.Remove("monthformat");
                    Obj_viewer.HTable.Remove("dayformat");
                    Obj_viewer.HTable.Remove("yearformat");
                    Obj_viewer.HTable.Remove("seperatorformat");
                    Obj_viewer.HTable.Remove("dateformat");
                    if (Obj_viewer.RptDoc is Rpt_Invoice_80mm)
                        Obj_viewer.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? true : false);
                }
                if (Obj_viewer.RptDoc is Rpt_InvTemplate1 || Obj_viewer.RptDoc is Rpt_InvTemplate2 || Obj_viewer.RptDoc is Rpt_InvTemplate3 || Obj_viewer.RptDoc is Rpt_InvTemplate4 || Obj_viewer.RptDoc is Rpt_InvTemplate5 || Obj_viewer.RptDoc is Rpt_InvTemplate6) // 10-12-2018 Tanzeel Dev 
                {
                    //if (Convert.ToDecimal(dt.Rows[0]["TotalDiscount"]) != 0.0m && GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    //{
                    //    Obj_viewer.HTable.Add("HideDiscount", false);
                    //}
                    //else if (Convert.ToDecimal(dt.Rows[0]["TotalDiscount"]) != 0.0m && GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem == "N" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "N")
                    //{
                    //    Obj_viewer.HTable.Add("HideDiscount", false);
                    //}
                    if (Convert.ToDecimal(dt.Rows[0]["TotalDiscount"]) != 0.0m && GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem != "Y")
                    {
                        Obj_viewer.HTable.Add("HideDiscount", false);
                    }
                    else
                    {
                        Obj_viewer.HTable.Add("HideDiscount", true);
                    }
                    Obj_viewer.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);

                }
                Obj_viewer.InvoiceName = "PurchaseInvoice";
                Obj_viewer.LoadEvent();
                if (ObjBALClass.ObjPurchase.Status == 1)
                {
                    Obj_viewer.ShowDialog();
                }
                else
                {
                    // Printer Setup Handling Add these Lines
                    //PrinterSettings printerSettings = new PrinterSettings();
                    //printerSettings.PrinterName = GeneralFunction.PrinterName("Invoice");
                    //printerSettings.Copies = Convert.ToInt16(GeneralFunction.NoofPrint);
                    //Obj_viewer.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false);
                    // 

                    // Printer Setup Handling Add these Lines
                    CrystalDecisions.Shared.PrintLayoutSettings s = new CrystalDecisions.Shared.PrintLayoutSettings();
                    s.Scaling = CrystalDecisions.Shared.PrintLayoutSettings.PrintScaling.Scale;
                    s.Centered = true;
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = GeneralFunction.PrinterName("Invoice");
                    Obj_viewer.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false, s);
                    // 

                    //Obj_viewer.LoadReport();
                    //Obj_viewer.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                }
                GeneralOptionSetting.FlagShowDeptOnPrint = debtValue;

            }
            else { GeneralFunction.Information("NoRecordsFound", "PurchaseInvoice"); }
        }

        internal void btnPrintBarcode()
        {
            DataTable AddDT = new DataTable();
            DataTable BarcodeDetails = new DataTable();
            DataRow drr;
            ReportDocument summery;
            Obj_viewer = new ReportsView();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("BarcodePrint");

            if (BarcodeDetails.Columns.Count < 4)
            {
                BarcodeDetails.Columns.Add("Id");
                BarcodeDetails.Columns.Add("ItemName");
                BarcodeDetails.Columns.Add("Barcode");
                BarcodeDetails.Columns.Add("Price");
                BarcodeDetails.Columns.Add("BigPrice");
                BarcodeDetails.Columns.Add("NormalPrice");
                BarcodeDetails.Columns.Add("Logo", typeof(byte[]));
                BarcodeDetails.Columns.Add("CompanyName");
            }
            DataTable dt = ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InsertDetails);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AddDT = ObjBALClass.GetBarcodeGetBarcode(Convert.ToInt32(dt.Rows[i]["ItemNo"]), Convert.ToInt32(dt.Rows[i]["ItemPackage"]), Convert.ToInt32(dt.Rows[i]["BarcodeID"]));
                    if (AddDT.Rows.Count > 0)
                    {
                        for (int j = 0; j < Convert.ToInt32(dt.Rows[i]["ItemQuantity"]); j++)
                        {
                            drr = BarcodeDetails.NewRow();
                            drr["Id"] = dt.Rows[i]["ItemNo"];
                            drr["ItemName"] = dt.Rows[i]["ItemDescription"];
                            drr["Barcode"] = GeneralFunction.EAN13(AddDT.Rows[0]["Barcode"].ToString());
                            drr["Price"] = dt.Rows[i]["SalePrice"];
                            drr["Bigprice"] = dt.Rows[i]["SalePrice"];
                            drr["NormalPrice"] = dt.Rows[i]["SalePrice"];
                            drr["Logo"] = GeneralOptionSetting.HeaderLogo;
                            drr["CompanyName"] = GeneralOptionSetting.FlagCompanyName;
                            BarcodeDetails.Rows.Add(drr);
                        }
                    }
                }
            }

            if (BarcodeDetails.Rows.Count > 0)
            {
                #region Print Barcode
                Obj_viewer = new ReportsView();
                //DataTable BarcodeDetails1 = new DataTable();
                BarcodeDetails.Merge(BarcodeDetails);
                if (BarcodeDetails.Rows.Count <= 0)
                {
                    GeneralFunction.Information("NoBarcodeDetailstoPrint", "Purchase");
                    return;
                }
                if (GeneralOptionSetting.FlagBarcodePrinter == "1")
                {
                    summery = new Rpt_Barcode_BarcodePapper();
                }
                else if (GeneralOptionSetting.FlagBarcodePaperSize == "1")
                {
                    summery = new Rpt_Barcode68();
                }
                else if (GeneralOptionSetting.FlagBarcodePaperSize == "2")
                {

                    summery = new Rpt_Barcode145();
                }
                else
                {
                    summery = new Rpt_Barcode();
                }
                CrystalDecisions.CrystalReports.Engine.ReportObject CompanyName = null;
                CompanyName = ((GeneralOptionSetting.FlagBarcodePrinter == "0") && (GeneralOptionSetting.FlagBarcodePaperSize == "2")) ? null : summery.ReportDefinition.Sections["Details"].ReportObjects["CompanyName1"];
                if (CompanyName != null) CompanyName.ObjectFormat.EnableSuppress = true;
                Obj_viewer.CompLogo = false;
                BarcodeDetails.TableName = "BarcodePrint";
                Obj_viewer.Report_Table = BarcodeDetails;
                Obj_viewer.HTable.Clear();
                Obj_viewer.HTable.Add("IsBigPrice", true);
                Obj_viewer.HTable.Add("Islogo", GeneralOptionSetting.HeaderLogo.Length < 1);
                Obj_viewer.RptDoc = summery;
                Obj_viewer.Repnum = summery.Database.Tables;
                Obj_viewer.IsReportFooter = false;
                Obj_viewer.Report_Table = BarcodeDetails;
                Obj_viewer.LoadReport();
                Obj_viewer.ShowDialog();
                #endregion
            }
            else
            {
                GeneralFunction.Information("NoGeneratedBarcodeItems", "Purchase Invoice");
            }
        }
        internal static void ReorderItems()
        {
            ReportsView Obj_viewer = new ReportsView();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ReorderItemList");
            DataTable dt = new DataTable("ReorderItem");
            dt = PurchaseBALClass.ReorderItems();
            if (dt == null || dt.Rows.Count <= 0)
            {
                GeneralFunction.Information("NoRecordsFound", "ReorderItemList");
                return;
            }
            Obj_viewer.Report_Table = dt;
            Obj_viewer.HTable.Clear();
            Obj_viewer.RptDoc = new Rpt_ReorderItems();
            Obj_viewer.IsItemNo = true;
            Obj_viewer.IsReportFooter = false;
            Obj_viewer.LoadEvent();
            Obj_viewer.ShowDialog();
        }
        /// <summary>
        /// this method for to insert the item from the popup
        /// </summary>
        internal void InsertPopupItem()
        {
            for (int j = 0; j < (ObjItemDetails.ItemBound.Count); j++)
            {
                ObjBALClass.ObjPurchase.ItemNo = ObjItemDetails.Itempopup[j].ItemNo;
                ObjBALClass.ObjPurchase.ItemName = ObjItemDetails.Itempopup[j].ItemName;
                ObjBALClass.ObjPurchase.ItemPackage = ObjItemDetails.Itempopup[j].ItemPackage;
                ObjBALClass.ObjPurchase.UnitType = ObjItemDetails.Itempopup[j].UnitType;
                ObjBALClass.ObjPurchase.UnitName = ObjItemDetails.Itempopup[j].UnitName;
                ObjBALClass.ObjPurchase.ItemQuantity = ObjItemDetails.Itempopup[j].ItemQuantity;
                ObjBALClass.ObjPurchase.ItemPrice = ObjItemDetails.Itempopup[j].ItemPrice;
                ObjBALClass.ObjPurchase.ItemCost = ObjItemDetails.Itempopup[j].ItemCost;
                ObjBALClass.ObjPurchase.BarcodeID = ObjItemDetails.Itempopup[j].BarcodeID;
                ObjBALClass.ObjPurchase.UnitTypeID = ObjItemDetails.Itempopup[j].UnitTypeID;
                if (ObjBALClass.ObjPurchase.UnitTypeID == 0 || ObjBALClass.ObjPurchase.UnitTypeID == 2)
                    isPackage = true;
                else
                    isPackage = false;
                CheckInsertItem();
            }
        }

        internal bool CheckUpdate()
        {
            int Qty = Convert.ToInt32(ObjBALClass.updatestatus(XCost, XExpiry, XSerialNo, XBarcodeID, XQuantity));
            if (Qty >= XQuantity)
            {
                return true;
            }
            else
                return false;
        }

        private decimal AutoPriceCalculation(decimal cost)
        {
            decimal Price = 0;
            if (GeneralOptionSetting.FlagCHKAutoPriceItem.ToString() == "Y")
            {
                if (cost > 0)
                {
                    decimal AutoPrice = Convert.ToDecimal(GeneralOptionSetting.FlagTxtAutoPriceItem.ToString());
                    Price = cost + ((cost * AutoPrice) / 100);
                }
            }
            return Price;
        }

        public string GenerateBarCode()
        {
            string barcode;
            Random ran = new Random();
            barcode = GetBarcodeWithCheckSum("21" + Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999)));
            if (!objbalClass.CheckDuplicateBarCode(barcode))
            {
                 return barcode;
            }
            else
            {
                return GenerateBarCode();
                
            }


        }
    }
}



