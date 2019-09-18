using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using BALHelper;
using ObjectHelper;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace BumedianBM.ViewHelper
{
    public class OrderInvoiceHelper
    {
        OrderInvoiceBALClass objBalClass;

        internal List<PurchaseObjectClass> ItemDetails = new List<PurchaseObjectClass>();
        internal List<long> InvoiceIDDetails = new List<long>();
        internal List<PurchaseObjectClass> InsertOrderList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> PackageQty = new List<PurchaseObjectClass>();
        internal List<long> ID = new List<long>();
        private bool isFromNewInvoice;
        private int Index = -1;
        internal bool isProcessTrue;
        internal bool isPackage = false;
        internal decimal piececost, boxcost = 0;
        internal int IDFlag;
        internal Item_Information ObjItemInfo;
        internal string ControlName = string.Empty;
        public OrderInvoiceHelper()
        {
            objBalClass = new OrderInvoiceBALClass();
            ObjBALClass.SetCommonObject();
            ObjItemInfo = new Item_Information();
            ID = ObjBALClass.GetMinMaxyearValue();
        }

        public OrderInvoiceBALClass ObjBALClass
        {
            get { return objBalClass; }
            set { objBalClass = value; }
        }

        internal List<PurchaseObjectClass> ItemDetailsList()
        {
            ItemDetails = ObjBALClass.GetItemNameDetails();
            return ItemDetails.Where(i => i.IsHide == false).ToList();
        }
        public DataTable AllOrderItems(int c1,int co1)
        {
            return ObjBALClass.GetOrderItemData(c1, co1);
        }
        internal void LoadOrderInvoiceData()
        {
            List<PurchaseObjectClass> OrderList = new List<PurchaseObjectClass>();
            OrderList = ObjBALClass.OrderDetailsLoad();
            if (OrderList.Count > 0)
            {
                //foreach (var list in OrderList)
                //{
                    ObjBALClass.ObjOrder.OrderInvoiceNo = OrderList[0].OrderInvoiceNo;
                    ObjBALClass.ObjOrder.Year = OrderList[0].Year;
                    ObjBALClass.ObjOrder.NewYearInvoiceID = OrderList[0].NewYearInvoiceID;
                //}
                LoadInvoiceDataBasedOnID();
            }
            else
            {
                this.InvoiceIDNewYearID();
                isFromNewInvoice = true;
                SaveOrderDetails();
                ID[1] = ObjBALClass.ObjOrder.OrderInvoiceNo;//this line added to load the 1st ID(Maxid)
            }

            OrderList = null;
        }

        private void LoadInvoiceDataBasedOnID()
        {
            InsertOrderList.Clear();
            List<PurchaseObjectClass> PurDetails = ObjBALClass.GetOrderInvoiceDetails();
            if (PurDetails.Count > 0)
            {
                foreach (var list in PurDetails)
                {
                    int i = -1;
                   
                    if (InsertOrderList.Count > 0)
                    {
                        i = InsertOrderList.FindIndex(a => (a.ItemNo == list.ItemNo) && (a.ItemName == list.ItemName) && (a.ItemExpiry == (list.ItemExpiryDate == DateTime.MinValue ? "-" : list.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == list.ItemUnitPrice) && (a.ItemSerialNo == list.ItemSerialNo) && (a.BarcodeID == list.BarcodeID));
                        if (i != -1)
                        {
                            InsertOrderList[i].ItemQuantity = InsertOrderList[i].ItemQuantity + list.ItemQuantity;
                            InsertOrderList[i].ItemTotal = InsertOrderList[i].ItemUnitPrice * InsertOrderList[i].ItemQuantity;
                            InsertOrderList[i].Box = InsertOrderList[i].ItemQuantity / (InsertOrderList[i].ItemPackage != 0 ? InsertOrderList[i].ItemPackage : 1);
                        }
                    }
                    if (i == -1)
                        InsertOrderList.Add(new PurchaseObjectClass
                        {
                            ItemNo = list.ItemNo,
                            ItemName = list.ItemName,
                            ItemExpiry = list.ItemExpiryDate.ToString() == DateTime.MinValue.ToString() || list.ItemExpiryDate == null ? "-" : (list.ItemExpiryDate).Value.ToShortDateString(),
                            ItemExpiryDate = list.ItemExpiryDate == DateTime.MaxValue || list.ItemExpiryDate == null ? null : list.ItemExpiryDate,
                            ItemPackage = list.ItemPackage,
                            ItemQuantity = list.ItemQuantity,
                            Box = (list.ItemQuantity % (list.ItemPackage == 0 ? 1 : list.ItemPackage)) == 0 ? list.ItemQuantity / (list.ItemPackage == 0 ? 1 : list.ItemPackage) : 0,
                            ItemUnitPrice = Convert.ToDecimal(list.ItemUnitPrice.ToString("#####0.000")),
                            ItemTotal = Convert.ToDecimal(list.ItemTotal.ToString("#####0.000")),
                            ItemSerialNo = list.ItemSerialNo,
                            ItemCost = Convert.ToDecimal(list.ItemCost.ToString("####0.000")),
                            ItemDiscount = Convert.ToDecimal(list.ItemDiscount.ToString("#####0.000")),
                            NewCost = list.NewCost,
                            ItemNumber = list.ItemNumber,
                            Time = list.Time,
                            BarcodeID = list.BarcodeID
                        });
                    
                }

                ObjBALClass.ObjOrder.SupplierName = PurDetails[0].SupplierName;
                ObjBALClass.ObjOrder.SupplierNo = PurDetails[0].SupplierNo;
                ObjBALClass.ObjOrder.ItemNet = PurDetails[0].ItemNet;
                ObjBALClass.ObjOrder.Status = PurDetails[0].Status;
                ObjBALClass.ObjOrder.OrderDate = PurDetails[0].OrderDate;
                ObjBALClass.ObjOrder.DiscountType = PurDetails[0].DiscountType;
                ObjBALClass.ObjOrder.NewYearInvoiceID = PurDetails[0].NewYearInvoiceID;
                ObjBALClass.ObjOrder.Year = PurDetails[0].Year;
                ObjBALClass.ObjOrder.Discount = Convert.ToDecimal(PurDetails[0].Discount.ToString("#####0.000"));
                //ObjBALClass.ObjPurchase.ItemDiscount = list.ItemDiscount;
                ObjBALClass.ObjOrder.originaldiscount = PurDetails[0].originaldiscount;
                //ObjBALClass.ObjOrder.ItemCost = list.ItemCost;
                ObjBALClass.ObjOrder.ItemGrossAmt = PurDetails[0].ItemGrossAmt;
                ObjBALClass.ObjOrder.OrderNote = PurDetails[0].OrderNote;
                ObjBALClass.ObjOrder.OrderDeliveryDate = PurDetails[0].OrderDeliveryDate;
                objBalClass.ObjOrder.ItemNumber = PurDetails[0].ItemNumber;
                objBalClass.ObjOrder.BarcodeID = PurDetails[0].BarcodeID;
                ObjBALClass.ObjOrder.ItemTotal = InsertOrderList.Sum(a => a.ItemTotal);

            }
            else
            {
                ObjBALClass.ObjOrder.InvoiceFlag = "3";//OI Order Remarks
                List<long> ID = ObjBALClass.GetInvoiceNoForEmptyRecord();
                if (ID.Count > 0)
                {
                    ObjBALClass.ObjOrder.OrderInvoiceNo = ID[0];
                    ObjBALClass.ObjOrder.Year = Convert.ToInt32(ID[1]);
                    ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(ID[2]);
                    //ObjBALClass.ObjOrder.SupplierName = string.Empty;
                    //ObjBALClass.ObjOrder.SupplierNo = 0;
                    ObjBALClass.ObjOrder.ItemNet = ObjBALClass.ObjOrder.ItemTotal = ObjBALClass.ObjOrder.originaldiscount = 0;
                    ObjBALClass.ObjOrder.OrderDate = DateTime.Now.Date;
                    ObjBALClass.ObjOrder.OrderDeliveryDate = null;
                    ObjBALClass.ObjOrder.Status = 1;
                }
                else
                    GeneralFunction.ErrInfo("Recordnotfound", "PurchaseInvoice");
            }

            PurDetails = null;
        }

        public void InvoiceIDNewYearID()
        {
            InvoiceIDDetails = ObjBALClass.GetInvoiceID();
            ObjBALClass.ObjOrder.OrderInvoiceNo = InvoiceIDDetails[0];
            ObjBALClass.ObjOrder.Year = Convert.ToInt32(InvoiceIDDetails[1]);
            ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(InvoiceIDDetails[2]);
        }

        internal Boolean SaveOrderDetails()
        {
            if (isFromNewInvoice)
            {
                ObjBALClass.ObjOrder.SupplierNo = 0;
                ObjBALClass.ObjOrder.OrderDate = DateTime.Now;
                ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjOrder.Status = 1;
                ObjBALClass.ObjOrder.Remarks = 3;
                ObjBALClass.ObjOrder.ItemQuantity = 0;
                ObjBALClass.ObjOrder.ItemPackage = 0;
                ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal("0.000");
                ObjBALClass.ObjOrder.SetStatus = 0;
                ObjBALClass.ObjOrder.ItemSerialNo = "0";
                ObjBALClass.ObjOrder.ItemNo = 0;
                if (ObjBALClass.SaveOrderInvoice())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        internal void btnNewInvoice()
        {
            this.InvoiceIDNewYearID();
            isFromNewInvoice = true;
            if (SaveOrderDetails())
            {
                ID[1] = InvoiceIDDetails[0];
                isProcessTrue = true;
                InsertOrderList.Clear();
            }
        }

        internal Boolean Validation()
        {
            if (ObjBALClass.ObjOrder.OrderInvoiceNo == null || ObjBALClass.ObjOrder.OrderInvoiceNo.ToString() == string.Empty)
            {
                GeneralFunction.Information("EmptyInvoiceNo", "OrderInvoice");
                ControlName = "txtNewInvoiceNo";
                return false;
            }
            if (ObjBALClass.ObjOrder.ItemName == string.Empty)
            {
                GeneralFunction.Information("EmptyItemName", "OrderInvoice");
                ControlName = "cmbItemName";
                return false;
            }
            if (ObjBALClass.ObjOrder.SupplierName.Length == 0)
            {
                GeneralFunction.Information("EmptySupplierName", "OrderInvoice");
                ControlName = "cmbSupplierName";
                return false;
            }
            if (ObjBALClass.ObjOrder.ItemQuantity == 0)
            {
                GeneralFunction.Information("EmptyQty", "OrderInvoice");
                ControlName = "txtQuantity";
                return false;
            }
            return true;
        }

        internal void btnAddItemInvoice()
        {
            if (Validation())
            {
                InsertItem();
            }
        }

        internal void ItemNameSelectedIndexChange()
        {

            if (ObjBALClass.ObjOrder.ItemName != string.Empty && ObjBALClass.ObjOrder.ItemNo != 0)
            {
                PackageQty.Clear();
                List<PurchaseObjectClass> ItemList = ObjBALClass.GetItemDetails();
                foreach (var list in ItemList)
                {
                    ObjBALClass.ObjOrder.ItemNo = list.ItemNo;
                    ObjBALClass.ObjOrder.ItemName = list.ItemName;
                    ObjBALClass.ObjOrder.ItemBarcode = list.ItemBarcode;
                    ObjBALClass.ObjOrder.CategoryNo = list.CategoryNo;
                    ObjBALClass.ObjOrder.ItemType = list.ItemType;
                    ObjBALClass.ObjOrder.ItemPlaceID = list.ItemPlaceID;
                    ObjBALClass.ObjOrder.ItemDescription = list.ItemDescription;
                    ObjBALClass.ObjOrder.ItemUnitPrice = list.ItemUnitPrice;
                    ObjBALClass.ObjOrder.CompanyNo = list.CompanyNo;
                    ObjBALClass.ObjOrder.ItemCost = list.ItemCost;
                    ObjBALClass.ObjOrder.PurchaseCost = list.ItemCost;
                    ObjBALClass.ObjOrder.ItemLastCost = list.ItemLastCost;
                    ObjBALClass.ObjOrder.ItemPackage = list.ItemPackage;
                    ObjBALClass.ObjOrder.ExpiryDate = list.ExpiryDate;
                    ObjBALClass.ObjOrder.Reorder = list.Reorder;
                    ObjBALClass.ObjOrder.ItemWholeSalePrice = list.ItemWholeSalePrice;
                    ObjBALClass.ObjOrder.ItemPrice = list.ItemPrice;
                    ObjBALClass.ObjOrder.MaxOrder = list.MaxOrder;
                    ObjBALClass.ObjOrder.ItemMinimumPrice = list.ItemMinimumPrice;
                    ObjBALClass.ObjOrder.AvgCost = list.AvgCost;
                    ObjBALClass.ObjOrder.ItemExpiryDate = list.ItemExpiryDate;
                    ObjBALClass.ObjOrder.ItemTotalStock = list.ItemTotalStock;
                    //ObjBALClass.ObjOrder.ItemStock = (ObjBALClass.ObjOrder.ItemTotalStock / (ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1)) + 1;
                    ObjBALClass.ObjOrder.ItemStock = (ObjBALClass.ObjOrder.ItemTotalStock / (ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1));
                    ObjBALClass.ObjOrder.ItemNumber = list.ItemNumber;
                    ObjBALClass.ObjOrder.BarcodeID = list.BarcodeID;
                    ObjBALClass.ObjOrder.ItemCardItemCost = list.ItemCardItemCost;
                    ObjBALClass.ObjOrder.ItemCardPackageQty = list.ItemCardPackageQty;
                    PackageQty.Add(new PurchaseObjectClass
                    {
                        ItemPackage = ObjBALClass.ObjOrder.ItemPackage,
                        ItemPrice = ObjBALClass.ObjOrder.ItemPrice,
                        BarcodeID = ObjBALClass.ObjOrder.BarcodeID,
                        ItemTotalStock = objBalClass.ObjOrder.ItemTotalStock 
                    });
                }

                ItemList = null;
            }
        }

        internal void BoxPieceAction()
        {
            if (isPackage == false)
            {
                //if (ObjBALClass.ObjOrder.ItemStock != 0)
                //{
                ObjBALClass.ObjOrder.ItemStock = (((ObjBALClass.ObjOrder.ItemTotalStock != null) ? ObjBALClass.ObjOrder.ItemTotalStock : 0) + ObjBALClass.ObjOrder.ItemQuantity);
                piececost = ObjBALClass.ObjOrder.ItemCost / ((ObjBALClass.ObjOrder.ItemPackage == 0) ? 1 : ObjBALClass.ObjOrder.ItemPackage);
                ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(piececost.ToString("#######0.000"));
                isPackage = true;
                // }
            }
            else
            {
                int stock = (ObjBALClass.ObjOrder.ItemTotalStock != null) ? ObjBALClass.ObjOrder.ItemTotalStock : 0;
                ObjBALClass.ObjOrder.ItemStock = ((Convert.ToInt32(stock) / ((ObjBALClass.ObjOrder.ItemPackage > 0) ? ObjBALClass.ObjOrder.ItemPackage : 1)) + ObjBALClass.ObjOrder.ItemQuantity);
                decimal strr = ((stock) % (ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage));
                ObjBALClass.ObjOrder.ItemCost = ObjBALClass.ObjOrder.ItemCost * (ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1);
                isPackage = false;
            }
        }

        internal void InsertItem()
        {
            decimal UnitPrice = 0.0m, Total = 0.0m, SalePrice = 0.0m, Cost = 0.0m, NewCost = 0.0m;
            int TotalStock = 0;
            ObjBALClass.ObjOrder.ItemPackage = ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage;
            string noww = DateTime.Now.ToShortDateString().ToString();
            string[] exp = ObjBALClass.ObjOrder.ItemExpiryDate.ToString().Split(' ');
            decimal dc;

            if (ObjBALClass.ObjOrder.ItemCost == ObjBALClass.ObjOrder.PurchaseCost)
            {
                ObjBALClass.ObjOrder.ItemCost = ObjBALClass.ObjOrder.PurchaseCost;
            }
            else
            {
                ObjBALClass.ObjOrder.PurchaseCost = ObjBALClass.ObjOrder.ItemCost = isPackage == false ? ObjBALClass.ObjOrder.ItemCost : Decimal.Parse((ObjBALClass.ObjOrder.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage).ToString());
            }
            decimal newcost = Convert.ToDecimal(ObjBALClass.ObjOrder.ItemCost);
            ObjBALClass.ObjOrder.ItemCost = newcost;
            dc = (Convert.ToDecimal(ObjBALClass.ObjOrder.ItemPrice)) / ObjBALClass.ObjOrder.ItemPackage;
            ////****Calculation*****\\\\
            UnitPrice = ObjBALClass.ObjOrder.ItemCost / ObjBALClass.ObjOrder.ItemPackage;
            UnitPrice = decimal.Parse((Math.Truncate(UnitPrice * 1000m) / 1000m).ToString("#####0.000"));
            SalePrice = ObjBALClass.ObjOrder.ItemPrice;
            Cost = UnitPrice * ObjBALClass.ObjOrder.ItemPackage;
            NewCost = ObjBALClass.ObjOrder.ItemCost;

            ObjBALClass.ObjOrder.ItemUnitPrice = UnitPrice;
            ObjBALClass.ObjOrder.SalePrice = SalePrice;
            ObjBALClass.ObjOrder.ItemCost = Cost;
            ObjBALClass.ObjOrder.NewCost = NewCost;
            ObjBALClass.ObjOrder.ItemTotalStock = TotalStock;
            ObjBALClass.ObjOrder.ItemTotal = Total;
            if (isPackage == false)
            {
                ObjBALClass.ObjOrder.ItemQuantity = ObjBALClass.ObjOrder.ItemQuantity * ObjBALClass.ObjOrder.ItemPackage;
                ObjBALClass.ObjOrder.Box = ObjBALClass.ObjOrder.ItemQuantity / ObjBALClass.ObjOrder.ItemPackage;
                ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());

            }
            else
            {
                ObjBALClass.ObjOrder.ItemQuantity = ObjBALClass.ObjOrder.ItemQuantity;
                ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());
                ObjBALClass.ObjOrder.Box = 0;
            }

            //if (ObjBALClass.ObjOrder.ItemType == 2)
            //{
            //    ObjBALClass.ObjOrder.ItemSerialNo = ObjOrder.SerialNo;
            //}
            //else
            //{
            //    ObjBALClass.ObjOrder.ItemSerialNo = 0;
            //}
            //if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "N")
            //{
            //    if (ObjBALClass.ObjOrder.ExpiryDate == true)
            //    { }
            //    else { ObjBALClass.ObjOrder.ItemExpiryDate = null; }
            //}
            //else { ObjBALClass.ObjOrder.ItemExpiryDate = null; }
            if (InsertOrderList.Count >= 0)
            {
                Index = InsertOrderList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemName == ObjBALClass.ObjOrder.ItemName) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjOrder.ItemSerialNo) && ((a.BarcodeID == ObjBALClass.ObjOrder.BarcodeID)));
                if (Index != -1)
                {
                    if (!isPackage)
                    {
                        InsertOrderList[Index].ItemQuantity = InsertOrderList[Index].ItemQuantity + ObjBALClass.ObjOrder.ItemQuantity;
                        InsertOrderList[Index].Box = InsertOrderList[Index].ItemQuantity / (InsertOrderList[Index].ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1);
                        InsertOrderList[Index].ItemTotal = InsertOrderList[Index].ItemUnitPrice * InsertOrderList[Index].ItemQuantity;
                    }
                    else if (isPackage)
                    {
                        Index = InsertOrderList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemName == ObjBALClass.ObjOrder.ItemName) && (a.ItemUnitPrice == UnitPrice) && (a.Box == 0));
                        if (Index != -1)
                        {
                            InsertOrderList[Index].ItemQuantity = InsertOrderList[Index].ItemQuantity + ObjBALClass.ObjOrder.ItemQuantity;
                            InsertOrderList[Index].ItemTotal = InsertOrderList[Index].ItemUnitPrice * InsertOrderList[Index].ItemQuantity;
                        }

                    }

                }
            }
            if (Index == -1)
                InsertOrderList.Add(new PurchaseObjectClass
                 {
                     ItemNo = ObjBALClass.ObjOrder.ItemNo,
                     ItemName = ObjBALClass.ObjOrder.ItemName,
                     ItemExpiry = "-",//ObjBALClass.ObjOrder.ItemType == 1 ? ObjBALClass.ObjOrder.ItemExpiryDate == null ? "-" : ObjBALClass.ObjOrder.ItemExpiryDate.Value.ToShortDateString() : "-",
                     ItemExpiryDate = ObjBALClass.ObjOrder.ItemType == 1 ? ObjBALClass.ObjOrder.ItemExpiryDate == null ? null : ObjBALClass.ObjOrder.ItemExpiryDate : null,
                     ItemPackage = ObjBALClass.ObjOrder.ItemPackage,
                     ItemQuantity = ObjBALClass.ObjOrder.ItemQuantity,
                     Box = ObjBALClass.ObjOrder.Box,
                     ItemUnitPrice = ObjBALClass.ObjOrder.ItemUnitPrice,
                     ItemTotal = Decimal.Parse(ObjBALClass.ObjOrder.ItemTotal.ToString("#####0.000")),
                     ItemSerialNo = ObjBALClass.ObjOrder.ItemSerialNo,
                     ItemDiscount = Convert.ToDecimal((0.0).ToString("#####0.000")),
                     ItemCost = ObjBALClass.ObjOrder.ItemCost,
                     NewCost = ObjBALClass.ObjOrder.NewCost,
                     // ItemTax1 = ObjBALClass.ObjOrder.ItemTax1,
                     // ItemTax2 = ObjBALClass.ObjOrder.ItemTax2,
                     SalePrice = ObjBALClass.ObjOrder.SalePrice,
                     ItemNumber = objBalClass.ObjOrder.ItemNumber.ToString(),
                     Time = DateTime.Now.ToLongTimeString(),
                     //included on 30april 2014 to update the record based on the barcode id 
                     BarcodeID = objBalClass.ObjOrder.BarcodeID
                 });

            decimal total = InsertOrderList.Sum(a => a.ItemTotal);
            ObjBALClass.ObjOrder.ItemTotal = total;
            ObjBALClass.ObjOrder.ItemNet = total;
            ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.Status = 1;
            objBalClass.ObjOrder.SetStatus = 0;
            ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(CommonHelper.OrderRemarks.OI);
            if (ObjBALClass.SaveOrderInvoice())
            {
                isProcessTrue = true;
            }
        }

        internal void btnCloseInvoice()
        {
            if (InsertOrderList.Count != 0)
            {
                ObjBALClass.ObjOrder.Status = 2;
                int i = 0;
                AssignValuesFromList(i);
                if (ObjBALClass.SaveOrderInvoice())
                    isProcessTrue = true;
            }
            else
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceList"), GeneralFunction.ChangeLanguageforCustomMsg("OrderInvoice"));

        }


        private void AssignValuesFromList(int i)
        {
            ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(CommonHelper.OrderRemarks.OI);
            ObjBALClass.ObjOrder.ItemNo = InsertOrderList[i].ItemNo;
            ObjBALClass.ObjOrder.ItemPackage = InsertOrderList[i].ItemPackage;
            ObjBALClass.ObjOrder.ItemQuantity = InsertOrderList[i].ItemQuantity;
            ObjBALClass.ObjOrder.ItemUnitPrice = InsertOrderList[i].ItemUnitPrice;
            ObjBALClass.ObjOrder.ItemSerialNo = InsertOrderList[i].ItemSerialNo;
            ObjBALClass.ObjOrder.ItemCost = InsertOrderList[i].ItemCost;
            ObjBALClass.ObjOrder.BarcodeID = InsertOrderList[i].BarcodeID;
        }

        internal Boolean btnModifyInvoice()
        {
            ObjBALClass.ObjOrder.InvoiceFlag = "ORDER";
            if (ObjBALClass.ModifyInvoice())
            {
                ObjBALClass.ObjOrder.Status = 1;
                return true;
            }
            else
                return false;
        }

        internal Boolean btnDeleteInvoice()
        {
            int j = InsertOrderList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemQuantity == ObjBALClass.ObjOrder.ItemQuantity) && (a.ItemUnitPrice == ObjBALClass.ObjOrder.ItemUnitPrice));
            objBalClass.ObjOrder.SetStatus = 1;
            objBalClass.ObjOrder.Status = 0;
            AssignValuesFromList(j);
            InsertOrderList.RemoveAt(j);
            ObjBALClass.ObjOrder.ItemNet = ObjBALClass.ObjOrder.ItemTotal = InsertOrderList.Sum(a => a.ItemTotal);
            if (ObjBALClass.SaveOrderInvoice())
            {
                objBalClass.ObjOrder.Status = 1;
                return true;
            }
            else
                return false;
        }

        internal void NavigationEvent()
        {

            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    ObjBALClass.ObjOrder.OrderInvoiceNo = ID[0];
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Next:
                    if (ObjBALClass.ObjOrder.OrderInvoiceNo != ID[1])
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ObjBALClass.ObjOrder.OrderInvoiceNo + 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ID[1];
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                case InvoiceFlag.Last:
                    ObjBALClass.ObjOrder.OrderInvoiceNo = ID[1];
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Previous:
                    if (ObjBALClass.ObjOrder.OrderInvoiceNo != ID[0])
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ObjBALClass.ObjOrder.OrderInvoiceNo - 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ID[0];
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                default:
                    long tempID = Convert.ToInt64(ObjBALClass.GetInvoiceNoBasedOntheYearValue());
                    if (tempID != null && tempID != 0)
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = tempID;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                        GeneralFunction.Information("Recordnotfound", "OrderInvoice");
                    break;
            }
        }

        internal Boolean SetDeliveryDate()
        {
            if (ObjBALClass.UpdateDeliveryDate())
            {
                GeneralFunction.Information("UpdateDeliveryDate", "OrderInvoice");
                return true;
            }
            else
                return false;
        }

        internal List<PurchaseObjectClass> GetItemsBasedComCatID()
        {
            List<PurchaseObjectClass> objList = ObjBALClass.GetItemNameBasedOnID();
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
        internal void AssignDataGridSource(DataGridView dgvOrderInvoice)
        {
            try
            {

                dgvOrderInvoice.AutoGenerateColumns = false;
                dgvOrderInvoice.DataSource = null;
                dgvOrderInvoice.Rows.Clear();

                //*******This is commented due to avoiding grid refreshing when insert the item
                //dgvOrderInvoice.Refresh();
                //****************************************************************************

                // DataGridView view = new DataGridView();
                // view.DataSource=null;
                //InsertOrderList = PurchaseInvoiceHelper.SortList(InsertOrderList);
                DataTable dt = GeneralFunction.SortInvoiceDetails(CommonHelper.ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InsertOrderList), "ItemName", "ItemUnitPrice");
                dgvOrderInvoice.DataSource = dt;
                if (ObjBALClass.ObjOrder.Status == 1)
                {
                    dgvOrderInvoice.BackgroundColor = Color.Beige;
                    dgvOrderInvoice.DefaultCellStyle.BackColor = Color.White;
                }
                else if (ObjBALClass.ObjOrder.Status == 2)
                {
                    dgvOrderInvoice.BackgroundColor = Color.Gray;
                    dgvOrderInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
                }

                //////To highlight the last inserted record    on 09 jun 2014//////////////////
                if (dgvOrderInvoice.Rows.Count > 0)
                {

                    dgvOrderInvoice.ClearSelection();

                    dgvOrderInvoice.FirstDisplayedScrollingRowIndex = dgvOrderInvoice.Rows.Count - 1;

                    dgvOrderInvoice.Rows[dgvOrderInvoice.Rows.Count - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void btnPrint()
        {
            string hideTaxField = string.Empty, hideDiscountField = string.Empty;
            try
            {
                hideTaxField = GeneralOptionSetting.FlagHideTaxFiled;
                hideDiscountField = GeneralOptionSetting.FlagHideDiscountFiledOnPrint;
                GeneralOptionSetting.FlagHideTaxFiled = GeneralOptionSetting.FlagHideDiscountFiledOnPrint = "Y";
                //ReportDocument summery = new ReportDocument(); //GeneralFunction.ReportSelection();
                //Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount rpt = new Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount(); 
                ReportsView Obj_viewer = new ReportsView();
                CurrencyConverter ObjCC = new CurrencyConverter();
                Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("OrderInvoice");
                decimal Total = 0.000M;
                //string qry = "Select * from View_Order_Inv where MTB_ORDER_INVOICE='" + Txt_OrderNo.Text + "' and MTB_REMARKS='OI'";
                DataTable dt = new DataTable("SimpleInvoice");
                ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(OrderRemarks.OI);
                dt = ObjBALClass.ReturnReportValues();
                if (dt.Rows.Count > 0)
                {
                    dt = GeneralFunction.SortInvoiceDetails(dt, "ItemName", "UnitPrice");
                    GeneralFunction.AgentId.Clear();
                    GeneralFunction.AgentId.Add(dt.Rows[0]["AgentID"].ToString());
                    GeneralFunction.AgentDept();
                }
                DataTable dtLocal = SpoiledItemHelper.SimpleInvoiceDataTable();
                //if (dtLocal.Columns.Count < 19)
                //{
                //    dtLocal.Columns.Add("InvoiceName");
                //    dtLocal.Columns.Add("InvoiceNo");
                //    dtLocal.Columns.Add("InvoiceDate");
                //    dtLocal.Columns.Add("CustomerId");
                //    dtLocal.Columns.Add("CustomerName");
                //    dtLocal.Columns.Add("ItemNo");
                //    dtLocal.Columns.Add("ItemName");
                //    dtLocal.Columns.Add("Expiry");
                //    dtLocal.Columns.Add("Quantity", typeof(int));
                //    dtLocal.Columns.Add("UnitPrice", typeof(decimal));
                //    dtLocal.Columns.Add("Total", typeof(decimal));
                //    dtLocal.Columns.Add("Tax1", typeof(decimal));
                //    dtLocal.Columns.Add("Tax2", typeof(decimal));
                //    dtLocal.Columns.Add("Discount", typeof(decimal));
                //    dtLocal.Columns.Add("MaxDept", typeof(decimal));
                //    dtLocal.Columns.Add("TotalDept", typeof(decimal));
                //    dtLocal.Columns.Add("Users");
                //    dtLocal.Columns.Add("TotalLetters");
                //    dtLocal.Columns.Add("Unit");
                //    dtLocal.Columns.Add("LastInvoiceDate", typeof(DateTime));
                //    dtLocal.Columns.Add("AmountDue", typeof(decimal));
                //    //dtLocal.Columns.Add("StreetAddress");
                //   /// dtLocal.Columns.Add("Address2");
                //   // dtLocal.Columns.Add("PhoneNo2");
                //    dtLocal.Columns.Add("Barcode");
                //    dtLocal.Columns.Add("DiscountPercentage", typeof(decimal));
                //}
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drAdd;
                    drAdd = dtLocal.NewRow();
                    drAdd["InvoiceName"] = "Order Invoice";
                    drAdd["InvoiceNo"] = dt.Rows[i]["YearSequenceNo"].ToString();
                    drAdd["InvoiceDate"] = dt.Rows[i]["OrderDate"].ToString();
                    drAdd["CustomerId"] = dt.Rows[i]["AgentID"].ToString();
                    drAdd["CustomerName"] = dt.Rows[i]["AgentName"].ToString();
                    drAdd["ItemNo"] = dt.Rows[i]["ItemID"].ToString();
                    drAdd["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                    drAdd["Expiry"] = dt.Rows[i]["DemandDate"].ToString();
                    drAdd["Quantity"] = dt.Rows[i]["Quantity"].ToString();
                    drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["unitPrice"].ToString());
                    drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                    drAdd["Tax1"] = Convert.ToDecimal(0.0);
                    drAdd["Tax2"] = Convert.ToDecimal(0.0);
                    drAdd["Discount"] = 0;// Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                    drAdd["MaxDept"] = (dt.Rows[i]["Debt"].ToString() != "") ? Convert.ToDecimal(dt.Rows[i]["Debt"].ToString()) : 0;
                    drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                    drAdd["Users"] = dt.Rows[i]["CreatedBy"].ToString();
                    drAdd["TotalLetters"] = "";
                    drAdd["Unit"] = "0";
                    drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"].ToString() == string.Empty ? dt.Rows[i]["OrderDate"].ToString() : dt.Rows[i]["LastInvoiceDate"].ToString());
                    drAdd["AmountDue"] = Convert.ToDecimal(0.0);
                    //  drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString();
                    ///include this line on 26 jun 2014 for to show the address and phonr number of the agent 
                    drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                    drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();
                   //-------------------------------------------------------------

                    drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                    drAdd["DiscountPercentage"] = 0;//Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                    drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["Package"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["Package"].ToString()) : 1);
                    Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());

                    dtLocal.Rows.Add(drAdd);
                }
                if (dtLocal.Rows.Count > 0)
                {
                    Obj_viewer.Report_Table = dtLocal;
                    Obj_viewer.HTable.Clear();

                    Obj_viewer.HTable.Add("note", ObjBALClass.ObjOrder.CheckNote == true ? ObjBALClass.ObjOrder.OrderNote : string.Empty);
                    if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                    { Obj_viewer.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000"))); }

                    Obj_viewer.HTable.Add("Paid", 0.0);
                    Obj_viewer.HTable.Add("Remaining", 0.0);

                    Obj_viewer.HTable.Add("IncludeTax", "No");
                    Obj_viewer.HTable.Add("Tax1", "0.000");
                    Obj_viewer.HTable.Add("Tax2", "0.000");
                    Obj_viewer.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                    Obj_viewer.HTable.Add("InvoiceName", Additional_Barcode.GetValueByResourceKey("OrderInvoice"));
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
                    Obj_viewer.HideLogo = objBalClass.ObjOrder.Status == 1 ? true : false;
                    //summery = rpt;
                    Obj_viewer.RptDoc = ReportSelection();// summery;
                    //ReportDocument rpt = summery;
                    //Tables tbl = rpt.Database.Tables;
                    // Obj_viewer.Repnum = tbl;
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
                        Obj_viewer.HTable.Add("HideDiscount", true);
                        Obj_viewer.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);
                    }
                    Obj_viewer.isInvoice = true;
                    Obj_viewer.InvoiceName = "OrderInvoice";
                    Obj_viewer.LoadEvent();
                    if (ObjBALClass.ObjOrder.SetStatus == 1)
                    {
                        Obj_viewer.ShowDialog();
                    }
                    else
                    {
                        /// Obj_viewer.LoadReport();
                        Obj_viewer.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                    }
                }
                else { GeneralFunction.Information("NoRecordsFound", "OrderInvoice"); }
            }

            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, "Order Invoice");//Added on 4-July-2014 by Seenivasan
                GeneralFunction.ErrorMessages(ex.Message, "Order Invoice", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                GeneralOptionSetting.FlagHideTaxFiled = hideTaxField;
                GeneralOptionSetting.FlagHideDiscountFiledOnPrint = hideDiscountField;
            }
        }
        public static ReportDocument ReportSelection()
        {
            try
            {
                if (GeneralOptionSetting.FlagInvoiceTemplate == "0")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No();
                    }

                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "2" || GeneralOptionSetting.FlagInvoiceTemplate == "1")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoice();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "3")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_WithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_WithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_WithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "4")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_A4Landscape_WithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_A4Landscape();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "7")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A4Landscape_WithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A4Landscape_WithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A4Landscape_WithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A4Landscape();                 
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "5" || GeneralOptionSetting.FlagInvoiceTemplate == "6")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTaxDiscount_A4Landscape();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTax_A4Landscape();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutDiscount_A4Landscape();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoice_A4Landscape();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "8")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutTaxDiscount_A5();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutTax_A5();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_WithoutDiscount_A5();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_Purchase_Invoice_No_A5();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "11")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A5_WithoutTaxDiscount();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A5_WithoutTax();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_WithoutDiscount();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_CompleteInvoice_A5();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "9" || GeneralOptionSetting.FlagInvoiceTemplate == "10")
                {
                    if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTaxDiscount_A5();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint != "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutTax_A5();
                    }
                    else if (GeneralOptionSetting.FlagHideTaxFiled != "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoiceWithoutDiscount_A5();
                    }
                    else
                    {
                        return new BumedianBM.CrystalReports.Rpt_SimpleInvoice_A5();
                    }
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "12")
                {
                    return new BumedianBM.CrystalReports.Rpt_Invoice_80mm();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "13")
                {
                    return new BumedianBM.CrystalReports.Rpt_Invoice_63mm();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "14") //Added on 7-July-2014 by Seenivasan for New template for Sale and Purchase Receipt BILL
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate1();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "15") //Added on 21-July-2014 by Seenivasan for New template for Sale and Purchase Receipt BILL
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate2();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "16")//this Condition to add New invoice template for invoice function  on 30/07/2014 By Meena.R
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate3();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "17")//this Condition to add New invoice template for invoice function  on 30/07/2014 By Meena.R
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate4();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "18")//this Condition to add New invoice template for invoice function  on 30/07/2014 By Meena.R
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate5();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "19")//this Condition to add New invoice template for invoice function  on 06/12/2018 By
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate6();
                }
                else if (GeneralOptionSetting.FlagInvoiceTemplate == "20")//this Condition to add New invoice template for invoice function  on 06/12/2018 By
                {
                    return new BumedianBM.CrystalReports.Rpt_InvTemplate7();
                }
                else
                {
                    return new BumedianBM.CrystalReports.Rpt_SimpleInvoice();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
