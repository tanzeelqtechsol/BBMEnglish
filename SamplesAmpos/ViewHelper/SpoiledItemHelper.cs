using System;
using System.Collections.Generic;
using System.Linq;
using ObjectHelper;
using BALHelper;
using CommonHelper;
using System.Windows.Forms;
using System.Data;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using System.Configuration;

namespace BumedianBM.ViewHelper
{
    public class SpoiledItemHelper
    {
        OrderInvoiceBALClass objbalclass;
        internal Item_Information ObjItemInfo;
        internal List<PurchaseObjectClass> SpoiledInvoiceList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> Expiry = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> ItemList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> FilterItemList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> PackageQty = new List<PurchaseObjectClass>();
        List<long> SpoiledInvoiceID = new List<long>();
        internal long MinID, MaxID, CurrentYear;
        private bool isFromNewInvoice;
        internal string ControlName = string.Empty;
        internal decimal ItemCost, ItemUnitPrice;
        private int Index = -1;
        internal bool isProcessTrue;
        internal bool isPackage = false;
        internal int IDFlag;
        public decimal piececost;
        internal object sender;
        public SpoiledItemHelper()
        {
            objbalclass = new OrderInvoiceBALClass();
            ObjItemInfo = new Item_Information();
            objbalclass.SetCommonObject();
            SetYearandIDs();
        }

        private void SetYearandIDs()
        {
            List<long> id = ObjBALClass.GetSpoiledYearMaxID();
            MinID = id[0];
            MaxID = id[1];
            CurrentYear = id[2];
        }

        public OrderInvoiceBALClass ObjBALClass
        {
            get { return objbalclass; }
            set { objbalclass = value; }
        }

        internal List<PurchaseObjectClass> GetItemDetails()
        {
            // ItemList = ObjBALClass.GetItemNameDetails();commented on 22 may 2014
            ItemList = ObjBALClass.Get_ItemDetailsForSpoiled();

            return ItemList;
        }

        internal void LoadSpoiledInvoiceData()
        {
            List<PurchaseObjectClass> OrderList;
            try
            {
                OrderList = new List<PurchaseObjectClass>();
                OrderList = ObjBALClass.SpoiledInvoiceLoad();
                if (OrderList.Count > 0)
                {
                    foreach (var list in OrderList)
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = list.OrderInvoiceNo;
                        ObjBALClass.ObjOrder.Year = list.Year;
                        ObjBALClass.ObjOrder.NewYearInvoiceID = list.NewYearInvoiceID;
                    }
                    LoadInvoiceDataBasedOnID();
                }
                else
                {
                    this.SpoiledInvoiceIDNewYearID();
                    isFromNewInvoice = true;
                    SaveOrderDetails();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                OrderList = null;
            }
        }

        private void LoadInvoiceDataBasedOnID()
        {
            List<PurchaseObjectClass> PurDetails;
            try
            {
                SpoiledInvoiceList.Clear();
                PurDetails = ObjBALClass.GetSpoiledInvoiceData();
                if (PurDetails.Count > 0)
                {
                    foreach (var list in PurDetails)
                    {
                        int i = -1;
                        ObjBALClass.ObjOrder.ItemNet = list.ItemNet;
                        ObjBALClass.ObjOrder.Status = list.Status;
                        ObjBALClass.ObjOrder.OrderDate = list.OrderDate;
                        ObjBALClass.ObjOrder.NewYearInvoiceID = list.NewYearInvoiceID;
                        ObjBALClass.ObjOrder.Year = list.Year;
                        ObjBALClass.ObjOrder.OrderNote = list.OrderNote;
                        if (SpoiledInvoiceList.Count > 0)
                        {
                            i = SpoiledInvoiceList.FindIndex(a => (a.ItemNo == list.ItemNo) && (a.ItemName == list.ItemName) && (a.ItemExpiry == (list.ItemExpiryDate == DateTime.MinValue ? "-" : list.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == list.ItemUnitPrice) && (a.ItemSerialNo == list.ItemSerialNo) && (a.BarcodeID == list.BarcodeID));
                            if (i != -1)
                            {
                                SpoiledInvoiceList[i].ItemQuantity = SpoiledInvoiceList[i].ItemQuantity + list.ItemQuantity;
                                SpoiledInvoiceList[i].ItemTotal = SpoiledInvoiceList[i].ItemUnitPrice * SpoiledInvoiceList[i].ItemQuantity;
                                SpoiledInvoiceList[i].Box = SpoiledInvoiceList[i].ItemQuantity / (SpoiledInvoiceList[i].ItemPackage != 0 ? SpoiledInvoiceList[i].ItemPackage : 1);
                            }
                        }
                        if (i == -1)
                            SpoiledInvoiceList.Add(new PurchaseObjectClass
                            {
                                ItemNo = list.ItemNo,
                                ItemName = list.ItemName,
                                ItemExpiry = list.ItemExpiryDate.ToString() == DateTime.MinValue.ToString() || list.ItemExpiryDate == null || list.ItemExpiryDate.ToString().Trim() == "1/1/1900" ? "-" : (list.ItemExpiryDate).Value.ToString().Split(' ').Length > 2 ? (list.ItemExpiryDate).Value.ToString().Split(' ')[1] : (list.ItemExpiryDate).Value.ToString().Split(' ')[0],
                                ItemExpiryDate = list.ItemExpiryDate == DateTime.MaxValue || list.ItemExpiryDate == null ? null : list.ItemExpiryDate,
                                ItemPackage = list.ItemPackage,
                                ItemQuantity = list.ItemQuantity,
                                Box = (list.ItemQuantity % (list.ItemPackage == 0 ? 1 : list.ItemPackage)) == 0 ? list.ItemQuantity / (list.ItemPackage == 0 ? 1 : list.ItemPackage) : 0,
                                ItemUnitPrice = Convert.ToDecimal(list.ItemUnitPrice.ToString("#####0.000")),
                                ItemTotal = Convert.ToDecimal(list.ItemTotal.ToString("#####0.000")),
                                ItemSerialNo = list.ItemSerialNo,
                                ItemCost = Convert.ToDecimal(list.ItemCost.ToString("####0.000")),
                                User = list.User,
                                Time = list.Time,
                                NewCost = list.NewCost,
                                ItemNumber = list.ItemNumber,
                                BarcodeID = list.BarcodeID
                            });
                        ObjBALClass.ObjOrder.ItemTotal = SpoiledInvoiceList.Sum(a => a.ItemTotal);
                    }
                }
                else
                {
                    ObjBALClass.ObjOrder.InvoiceFlag = "1";//SI Order Remarks
                    List<long> ID = ObjBALClass.GetInvoiceNoForEmptyRecord();
                    ObjBALClass.ObjOrder.OrderInvoiceNo = ID[0];
                    ObjBALClass.ObjOrder.Year = Convert.ToInt32(ID[1]);
                    ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(ID[2]);
                    ObjBALClass.ObjOrder.ItemNet = ObjBALClass.ObjOrder.ItemTotal = ObjBALClass.ObjOrder.originaldiscount = 0;
                    ObjBALClass.ObjOrder.OrderDate = DateTime.Now.Date;
                    ObjBALClass.ObjOrder.Status = 1;
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

        internal Boolean SaveOrderDetails()
        {
            if (isFromNewInvoice)
            {
                ObjBALClass.ObjOrder.SupplierNo = 0;
                ObjBALClass.ObjOrder.OrderDate = DateTime.Now;
                ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjOrder.Status = 1;
                ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(OrderRemarks.SI);
                ObjBALClass.ObjOrder.ItemQuantity = 0;
                ObjBALClass.ObjOrder.ItemPackage = 0;
                ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal("0.000");
                ObjBALClass.ObjOrder.SetStatus = 0;
                ObjBALClass.ObjOrder.ItemSerialNo = string.Empty;
                ObjBALClass.ObjOrder.ItemNo = 0;
                ObjBALClass.ObjOrder.BarcodeID = 0;
                if (ObjBALClass.SaveOrderInvoice())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void SpoiledInvoiceIDNewYearID()
        {
            SpoiledInvoiceID = ObjBALClass.GetSpoiledInvoiceID();
            ObjBALClass.ObjOrder.OrderInvoiceNo = SpoiledInvoiceID[0];
            ObjBALClass.ObjOrder.Year = Convert.ToInt32(SpoiledInvoiceID[1]);
            ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(SpoiledInvoiceID[2]);
        }

        private void ItemNameSelectedIndexChange()
        {
            List<PurchaseObjectClass> ItemList;
            try
            {
                if (ObjBALClass.ObjOrder.ItemName != string.Empty && ObjBALClass.ObjOrder.ItemNo != 0)
                {
                    PackageQty.Clear();
                    // List<PurchaseObjectClass> ItemList = ObjBALClass.Get_PurchasedItemDetails();
                    ItemList = ObjBALClass.GetItemDetails();
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
                        ItemCost = ObjBALClass.ObjOrder.ItemCost = list.ItemCost;
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
                        ObjBALClass.ObjOrder.ItemStock = (ObjBALClass.ObjOrder.ItemTotalStock / (ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1));
                        ObjBALClass.ObjOrder.ItemNumber = list.ItemNumber;
                        ObjBALClass.ObjOrder.BarcodeID = list.BarcodeID;
                        if (list.ItemTotalStock > 0)
                        {
                            PackageQty.Add(new PurchaseObjectClass
                            {
                                ItemPackage = ObjBALClass.ObjOrder.ItemPackage,
                                ItemPrice = ObjBALClass.ObjOrder.ItemPrice,
                                PurchaseCost = ObjBALClass.ObjOrder.PurchaseCost,
                                BarcodeID = ObjBALClass.ObjOrder.BarcodeID,
                                ItemExpiryDate = ObjBALClass.ObjOrder.ItemExpiryDate //include this line on 24 jun 2014 
                            });
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
                ItemList = null;
            }
        }

        internal void ItemBinding()
        {
            List<PurchaseObjectClass> l;
            try
            {
                ItemNameSelectedIndexChange();
                ObjBALClass.ObjOrder.Box = (isPackage == false) ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(ObjBALClass.ObjOrder.ItemTotalStock) / ((ObjBALClass.ObjOrder.ItemPackage != 0) ? ObjBALClass.ObjOrder.ItemPackage : 1))) : (ObjBALClass.ObjOrder.ItemTotalStock);
                if (ObjBALClass.ObjOrder.ItemType == 1 || ObjBALClass.ObjOrder.ExpiryDate == true)
                {
                    ObjBALClass.ObjOrder.InvoiceFlag = "ALLDATE";
                    l = ObjBALClass.GetItemExpiry();
                    Expiry = l.Where(a => a.ItemNo == ObjBALClass.ObjOrder.ItemNo).ToList();
                }
                else
                {
                    if (ObjBALClass.ObjOrder.ItemType == 2)
                    {
                        Expiry = ObjBALClass.GetSerialNo();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                l = null;
            }
        }

        internal void btnNewInvoice()
        {
            this.SpoiledInvoiceIDNewYearID();
            isFromNewInvoice = true;
            if (SaveOrderDetails())
            {
                MaxID = SpoiledInvoiceID[0];
                isProcessTrue = true;
                SpoiledInvoiceList.Clear();
            }
        }

        internal void AssignDataGridSource(DataGridView dgvOrderInvoice)
        {
            dgvOrderInvoice.AutoGenerateColumns = false;
            dgvOrderInvoice.DataSource = null;
            dgvOrderInvoice.Rows.Clear();

            //*******This is commented due to avoiding grid refreshing when insert the item
            //dgvOrderInvoice.Refresh();
            //****************************************************************************
            SpoiledInvoiceList = SortList(SpoiledInvoiceList);
          //  SpoiledInvoiceList = SpoiledInvoiceList.OrderBy(a => a.ItemExpiryDate).ToList();Commended by meena.R on 05/12/2014 to implement invoice sorting
            DataTable dt = CommonHelper.ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(SpoiledInvoiceList);
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
        public List<PurchaseObjectClass> SortList(List<PurchaseObjectClass> list)
        {
            List<PurchaseObjectClass> sort = new List<PurchaseObjectClass>();
            switch (GeneralOptionSetting.FlagItemSorting)
            {
                case "0":
                    sort = (from lst in list
                           orderby lst.ItemName ascending
                           select lst).ToList();
                    break;
                case "1":
                    sort = (from lst in list
                                        orderby lst.ItemName descending
                                        select lst).ToList(); // (from l in list where l.ItemName orderbyDe l.ItemName descending select l).ToList();
                    break;
                case "4":
                    sort = (from lst in list
                           orderby lst.ItemUnitPrice ascending
                           select lst).ToList();;
                    break;
                case "3":
                    sort = (from lst in list
                            orderby lst.ItemUnitPrice descending
                            select lst).ToList();
                    break;
                default:
                    sort = list;
                    break;
            }
            return sort;
        }
        internal void btnAddItemInvoice()
        {
            if (Validation())
            {
                InsertItem();
            }
        }

        internal void InsertItem()
        {
            Index = -1;//added on 14Nov2014
            decimal UnitPrice = 0.0m, Total = 0.0m, SalePrice = 0.0m, Cost = 0.0m, NewCost = 0.0m;
            int TotalStock = 0;
            ObjBALClass.ObjOrder.ItemPackage = ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage;

            TotalStock = isPackage == false ? ObjBALClass.ObjOrder.ItemQuantity * ObjBALClass.ObjOrder.ItemPackage : ObjBALClass.ObjOrder.ItemQuantity;
            //if (ObjBALClass.ObjOrder.ItemCost == ObjBALClass.ObjOrder.PurchaseCost)
            //{
            //    ObjBALClass.ObjOrder.ItemCost = ObjBALClass.ObjOrder.PurchaseCost;
            //}
            //else
            //{
            //    ObjBALClass.ObjOrder.PurchaseCost = ObjBALClass.ObjOrder.ItemCost = isPackage == false ? ObjBALClass.ObjOrder.ItemCost : Decimal.Parse((ObjBALClass.ObjOrder.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage).ToString());
            //}
            // decimal newcost = Convert.ToDecimal(ObjBALClass.ObjOrder.ItemCost);
            // ObjBALClass.ObjOrder.ItemCost = newcost;
            // dc = (Convert.ToDecimal(ObjBALClass.ObjOrder.ItemPrice)) / ObjBALClass.ObjOrder.ItemPackage;

            ////****Calculation*****\\\\
            if (isPackage == false)
            {
                UnitPrice = Decimal.Parse((ObjBALClass.ObjOrder.ItemCost / ObjBALClass.ObjOrder.ItemPackage).ToString("#####0.000"));
            }
            else
            {
                UnitPrice = ObjBALClass.ObjOrder.ItemCost;
            }
            //UnitPrice = ObjBALClass.ObjOrder.ItemCost / ObjBALClass.ObjOrder.ItemPackage;
            SalePrice = ObjBALClass.ObjOrder.ItemPrice;
            //  Cost = UnitPrice * ObjBALClass.ObjOrder.ItemPackage;
            Cost = ItemCost;
            NewCost = ObjBALClass.ObjOrder.ItemCost;

            ObjBALClass.ObjOrder.ItemUnitPrice = UnitPrice;
            ObjBALClass.ObjOrder.SalePrice = SalePrice;
            ObjBALClass.ObjOrder.ItemCost = Cost;
            ObjBALClass.ObjOrder.NewCost = NewCost;
            //ObjBALClass.ObjOrder.ItemTotalStock = TotalStock;
            ObjBALClass.ObjOrder.ItemTotal = Total;
            //if (ObjBALClass.ObjOrder.ItemType == 2 && ObjBALClass.ObjOrder.ItemSerialNo != "0")
            //{
            //    List<PurchaseObjectClass> serial = ObjBALClass.GetStockBasedSerialno();
            //    if (TotalStock > serial[0].ItemStock)
            //        ObjBALClass.ObjOrder.ItemQuantity = serial[0].ItemStock;
            //}
            //else
            //{
            //    List<PurchaseObjectClass> exp = ObjBALClass.GetExpiryBasedStock();
            //    if (TotalStock > exp[0].ItemStock)
            //        ObjBALClass.ObjOrder.ItemQuantity = exp[0].ItemStock;
            //}
            if (isPackage == false)
            {
                ObjBALClass.ObjOrder.ItemQuantity = ObjBALClass.ObjOrder.ItemQuantity * ObjBALClass.ObjOrder.ItemPackage;
                ObjBALClass.ObjOrder.Box = ObjBALClass.ObjOrder.ItemQuantity / ObjBALClass.ObjOrder.ItemPackage;
                //ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());
                ObjBALClass.ObjOrder.ItemTotal = ObjBALClass.ObjOrder.ItemCost * ObjBALClass.ObjOrder.Box;

            }
            else
            {
                ObjBALClass.ObjOrder.ItemQuantity = ObjBALClass.ObjOrder.ItemQuantity;
                ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());
                ObjBALClass.ObjOrder.Box = 0;
            }
            //if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "N")
            //{
            //    if (ObjBALClass.ObjOrder.ExpiryDate == true)
            //    { }
            //    else { ObjBALClass.ObjOrder.ItemExpiryDate = null; }
            //}
            //else { ObjBALClass.ObjOrder.ItemExpiryDate = null; }
            if (SpoiledInvoiceList.Count > 0)
            {
                Index = SpoiledInvoiceList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemName == ObjBALClass.ObjOrder.ItemName) && (a.ItemUnitPrice == UnitPrice) && (a.ItemExpiryDate == ObjBALClass.ObjOrder.ItemExpiryDate) && (a.ItemSerialNo == ObjBALClass.ObjOrder.ItemSerialNo) && (a.BarcodeID == ObjBALClass.ObjOrder.BarcodeID));
                if (Index != -1)
                {
                    if (!isPackage)
                    {
                        SpoiledInvoiceList[Index].ItemQuantity = SpoiledInvoiceList[Index].ItemQuantity + ObjBALClass.ObjOrder.ItemQuantity;
                        SpoiledInvoiceList[Index].Box = SpoiledInvoiceList[Index].ItemQuantity / (SpoiledInvoiceList[Index].ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1);
                        SpoiledInvoiceList[Index].ItemTotal = SpoiledInvoiceList[Index].ItemUnitPrice * SpoiledInvoiceList[Index].ItemQuantity;
                    }
                    else if (isPackage)
                    {
                        Index = SpoiledInvoiceList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemName == ObjBALClass.ObjOrder.ItemName) && (a.ItemUnitPrice == UnitPrice) && (a.Box == 0) && (a.BarcodeID == ObjBALClass.ObjOrder.BarcodeID));
                        if (Index != -1)
                        {
                            SpoiledInvoiceList[Index].ItemQuantity = SpoiledInvoiceList[Index].ItemQuantity + ObjBALClass.ObjOrder.ItemQuantity;
                            SpoiledInvoiceList[Index].ItemTotal = SpoiledInvoiceList[Index].ItemUnitPrice * SpoiledInvoiceList[Index].ItemQuantity;
                        }
                    }
                }
            }
            if (Index == -1)
                AssignValuesToList();
            SaveSpoileInvoice();
        }

        private void SaveSpoileInvoice()
        {
            decimal total = SpoiledInvoiceList.Sum(a => a.ItemTotal);
            ObjBALClass.ObjOrder.ItemTotal = total;
            ObjBALClass.ObjOrder.ItemNet = total;
            ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.Status = 1;
            ObjBALClass.ObjOrder.OrderDemandDate = ObjBALClass.ObjOrder.ItemExpiryDate;
            ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(CommonHelper.OrderRemarks.SI);
            ObjBALClass.ObjOrder.SetStatus = 0;
            if (ObjBALClass.SaveOrderInvoice())
            {
                isProcessTrue = true;
            }
        }

        private void AssignValuesToList()
        {
            SpoiledInvoiceList.Add(new PurchaseObjectClass
            {
                ItemNo = ObjBALClass.ObjOrder.ItemNo,
                ItemName = ObjBALClass.ObjOrder.ItemName,
                ItemExpiry = ObjBALClass.ObjOrder.ItemType == 1 ? ObjBALClass.ObjOrder.ItemExpiryDate == null || ObjBALClass.ObjOrder.ItemExpiryDate == DateTime.MinValue ? "-" : ObjBALClass.ObjOrder.ItemExpiryDate.Value.ToString().Split(' ').Length > 2 ? ObjBALClass.ObjOrder.ItemExpiryDate.Value.ToString().Split(' ')[1] : ObjBALClass.ObjOrder.ItemExpiryDate.Value.ToString().Split(' ')[0] : "-",
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
                User = CommonHelper.GeneralFunction.UserName,
                Time = DateTime.Now.TimeOfDay.ToString().Split('.')[0],
                ItemNumber = ObjBALClass.ObjOrder.ItemNumber,
                BarcodeID = ObjBALClass.ObjOrder.BarcodeID
            });
        }

        private Boolean Validation()
        {
            if (ObjBALClass.ObjOrder.ItemName == string.Empty || ObjBALClass.ObjOrder.ItemName == null)
            {
                GeneralFunction.Information("EmptyItemName", "SpoiledInvoice");
                ControlName = "cmbItem";
                return false;
            }
            else if (ObjBALClass.ObjOrder.ItemQuantity.ToString() == string.Empty || int.Parse(ObjBALClass.ObjOrder.ItemQuantity.ToString()) < 1)
            {
                GeneralFunction.Information("ZeroQty", "SpoiledInvoice");
                ControlName = "txtQty";
                return false;
            }
            else if (ObjBALClass.ObjOrder.ItemQuantity.ToString() != string.Empty)
            {
                int cnt;
                cnt = (ObjBALClass.ObjOrder.ItemQuantity);
                if (!isPackage)
                {
                    if (cnt > (ObjBALClass.ObjOrder.Box))//commented on 24 jun 2014.issues occured while enter the quantity of box 
                    //if (cnt > (ObjBALClass.ObjOrder.ItemStock))
                    {
                        GeneralFunction.Information("ValidItemQty", "SpoiledInvoice");
                        ControlName = "txtQty";
                        return false;
                    }
                }
                else
                {
                    if (cnt > (ObjBALClass.ObjOrder.ItemTotalStock))
                    {
                        GeneralFunction.Information("ValidItemQty", "SpoiledInvoice");
                        ControlName = "txtQty";
                        return false;
                    }
                }
                return true;
            }
            else if (ObjBALClass.ObjOrder.ItemStock < 0)
            {
                GeneralFunction.Information("NoStockItem", "SpoiledInvoice");
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void OnlySpoiledItem()
        {

            ObjBALClass.ObjOrder.InvoiceFlag = string.Empty;//Added to get the expired item from the date on 29/04/2014
            ObjBALClass.ObjOrder.ItemNo = 0;///to get the expired item only on 03 july 2014
            List<PurchaseObjectClass> l = ObjBALClass.GetItemExpiry();
            FilterItemList = (l.Where(a => (a.ItemTotalStock != 0) && (a.ItemName != string.Empty)).ToList()).GroupBy(a => a.ItemNo).Select(a => a.First()).ToList();
            //Expiry = item.GroupBy(a => a.ItemNo).Select(a => a.First()).ToList();
        }

        internal void BoxPieceAction()
        {
            if (isPackage == false)
            {
                //if (ObjBALClass.ObjOrder.ItemStock != 0)
                //{
                ObjBALClass.ObjOrder.ItemStock = ((ObjBALClass.ObjOrder.ItemTotalStock != null) ? ObjBALClass.ObjOrder.ItemTotalStock : 0) - ObjBALClass.ObjOrder.ItemQuantity;
                piececost = ObjBALClass.ObjOrder.ItemCost / ((ObjBALClass.ObjOrder.ItemPackage == 0) ? 1 : ObjBALClass.ObjOrder.ItemPackage);
                piececost = ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(piececost.ToString("#######0.000"));
                isPackage = true;
                // }
            }
            else
            {
                int stock = ((ObjBALClass.ObjOrder.ItemTotalStock != null) ? ObjBALClass.ObjOrder.ItemTotalStock : 0);
                ObjBALClass.ObjOrder.ItemStock = ((Convert.ToInt32(stock) / ((ObjBALClass.ObjOrder.ItemPackage > 0) ? ObjBALClass.ObjOrder.ItemPackage : 1))) - ObjBALClass.ObjOrder.ItemQuantity;
                ObjBALClass.ObjOrder.ItemCost = ObjBALClass.ObjOrder.ItemCost * (ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjBALClass.ObjOrder.ItemPackage : 1);
                if (ItemUnitPrice == piececost)
                {
                    ObjBALClass.ObjOrder.ItemCost = ItemCost;
                }
                else
                {
                    ItemCost = ObjBALClass.ObjOrder.PurchaseCost = ObjBALClass.ObjOrder.ItemCost = isPackage == false ? ObjBALClass.ObjOrder.ItemCost : Decimal.Parse((ObjBALClass.ObjOrder.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage).ToString());
                }
                isPackage = false;
            }
        }

        internal void btnCloseInvoice()
        {
            if (SpoiledInvoiceList.Count != 0)
            {
                ObjBALClass.ObjOrder.Status = 2;
                int i = 0;
                AssignValuesFromList(i);
                if (ObjBALClass.SaveOrderInvoice())
                {
                    ObjBALClass.ObjOrder.Status = 2;
                    isProcessTrue = true;
                }
            }
            else
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceList"), GeneralFunction.ChangeLanguageforCustomMsg("SpoiledInvoice"));
        }

        private void AssignValuesFromList(int i)
        {
            ObjBALClass.ObjOrder.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(CommonHelper.OrderRemarks.SI);
            ObjBALClass.ObjOrder.ItemNo = SpoiledInvoiceList[i].ItemNo;
            ObjBALClass.ObjOrder.ItemPackage = SpoiledInvoiceList[i].ItemPackage;
            ObjBALClass.ObjOrder.ItemQuantity = SpoiledInvoiceList[i].ItemQuantity;
            ObjBALClass.ObjOrder.ItemUnitPrice = SpoiledInvoiceList[i].ItemUnitPrice;
            ObjBALClass.ObjOrder.ItemSerialNo = SpoiledInvoiceList[i].ItemSerialNo;
            ObjBALClass.ObjOrder.OrderDemandDate = SpoiledInvoiceList[i].ItemExpiryDate;
            ObjBALClass.ObjOrder.BarcodeID = SpoiledInvoiceList[i].BarcodeID;
            ObjBALClass.ObjOrder.ItemCost = SpoiledInvoiceList[i].ItemCost;
        }

        internal Boolean btnModifyInvoice()
        {
            ObjBALClass.ObjOrder.InvoiceFlag = "SPOILED";
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
            int j = SpoiledInvoiceList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjOrder.ItemNo) && (a.ItemQuantity == ObjBALClass.ObjOrder.ItemQuantity) && (a.ItemUnitPrice == ObjBALClass.ObjOrder.ItemUnitPrice) && (a.BarcodeID == ObjBALClass.ObjOrder.BarcodeID));
            /// added status as 0 to update the stock 
            ObjBALClass.ObjOrder.Status = 0;
            ObjBALClass.ObjOrder.SetStatus = 1;
            AssignValuesFromList(j);
            if (ObjBALClass.SaveOrderInvoice())
            {
                SpoiledInvoiceList.RemoveAt(j);
                ObjBALClass.ObjOrder.ItemNet = ObjBALClass.ObjOrder.ItemTotal = SpoiledInvoiceList.Sum(a => a.ItemTotal);
                return true;
            }
            else
                return false;
        }

        internal void DeleteWholeData()
        {
            int count = SpoiledInvoiceList.Count, c = 0;
            ObjBALClass.ObjOrder.Status = 0; //Added on 2-June-2014 By Seenivasan ->  for Deleting the Records Status should be in "0"
            ObjBALClass.ObjOrder.SetStatus = 1;
            for (int i = 0; i < SpoiledInvoiceList.Count; i++)
            {
                AssignValuesFromList(i);
                if (ObjBALClass.SaveOrderInvoice())
                {
                    c += 1;
                    isProcessTrue = true;
                }
                else
                    isProcessTrue = false;
            }
            if (count == c)
            {
                SpoiledInvoiceList.Clear();
                ObjBALClass.ObjOrder.ItemTotal = 0.000m;
            }
        }

        internal void NavigationEvent()
        {

            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    ObjBALClass.ObjOrder.OrderInvoiceNo = MinID;
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Next:
                    if (ObjBALClass.ObjOrder.OrderInvoiceNo != MaxID)
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ObjBALClass.ObjOrder.OrderInvoiceNo + 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = MaxID;
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                case InvoiceFlag.Last:
                    ObjBALClass.ObjOrder.OrderInvoiceNo = MaxID;
                    LoadInvoiceDataBasedOnID();
                    break;
                case InvoiceFlag.Previous:
                    if (ObjBALClass.ObjOrder.OrderInvoiceNo != MinID)
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = ObjBALClass.ObjOrder.OrderInvoiceNo - 1;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = MinID;
                        LoadInvoiceDataBasedOnID();
                    }
                    break;
                default:
                    long tempID = Convert.ToInt64(ObjBALClass.GetSpoiledInvoiceNoBasedOntheYearValue());
                    if (tempID != null && tempID != 0)
                    {
                        ObjBALClass.ObjOrder.OrderInvoiceNo = tempID;
                        LoadInvoiceDataBasedOnID();
                    }
                    else
                        GeneralFunction.Information("Recordnotfound", "SpoiledInvoice");
                    break;
            }
        }

        internal void FilterItemBasedonCategory()
        {
            if (ObjBALClass.ObjOrder.CategoryNo == 1001)
                FilterItemList = ItemList;
            else
                FilterItemList = ItemList.Where(a => a.CategoryNo == ObjBALClass.ObjOrder.CategoryNo).ToList();
        }

        internal void FilterItemBasedonCompany()
        {
            if (ObjBALClass.ObjOrder.CompanyNo == 1001)
                FilterItemList = ItemList;
            else
                FilterItemList = ItemList.Where(a => a.CompanyNo == ObjBALClass.ObjOrder.CompanyNo).ToList();
        }

        internal void btnPrint()
        {
            ObjBALClass.ObjOrder.InvoiceNo = ObjBALClass.ObjOrder.OrderInvoiceNo;
            ObjBALClass.ObjOrder.Remarks = Convert.ToInt32(OrderRemarks.SI);
            //ReportDocument summery = new ReportDocument();// GeneralFunction.ReportSelection();
            // Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount rpt=new Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount();
            //Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount rpt = new Rpt_Purchase_Invoice_No_A4Landscape_WithoutTaxDiscount();
            ReportsView Obj_viewer = new ReportsView();
            CurrencyConverter ObjCC = new CurrencyConverter();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SpoiledInvoice");
            decimal Total = 0.000M;

            // string qry = "Select * from View_Order_Inv where MTB_ORDER_INVOICE='" + MTxt_InvoiceNo.Text + "' and MTB_REMARKS='SI'";
            DataTable dt = new DataTable("SimpleInvoice");
            dt = ObjBALClass.ReturnReportValues(); ///objPurchaseDal.Get_ReportValues(qry, "SimpleInvoice");
            if (dt.Rows.Count > 0)
            {
                dt = GeneralFunction.SortInvoiceDetails(dt, "ItemName", "UnitPrice");
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["AgentID"].ToString());
                GeneralFunction.AgentDept();
            }
            DataTable dtLocal = SimpleInvoiceDataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();
                drAdd["InvoiceName"] = "Spoiled Invoice";
                drAdd["InvoiceNo"] = dt.Rows[i]["YearSequenceNo"].ToString();
                drAdd["InvoiceDate"] = dt.Rows[i]["OrderDate"].ToString();
                drAdd["CustomerId"] = dt.Rows[i]["AgentID"].ToString();
                drAdd["CustomerName"] = dt.Rows[i]["AgentName"].ToString();
                drAdd["ItemNo"] = dt.Rows[i]["ItemID"].ToString();
                drAdd["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                drAdd["Expiry"] = dt.Rows[i]["DemandDate"].ToString();
                drAdd["Quantity"] = dt.Rows[i]["Quantity"].ToString();
                drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString());
                drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                drAdd["Tax1"] = Convert.ToDecimal("0.000");
                drAdd["Tax2"] = Convert.ToDecimal("0.000");
                drAdd["Discount"] = 0.000;// Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                drAdd["MaxDept"] = (dt.Rows[i]["Debt"].ToString() != "") ? Convert.ToDecimal(dt.Rows[i]["Debt"].ToString()) : 0;
                drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                drAdd["Users"] = dt.Rows[i]["CreatedBy"].ToString();
                drAdd["TotalLetters"] = "";
                drAdd["Unit"] = "0";
                //  drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"].ToString() == string.Empty ? dt.Rows[i]["MTB_ORDER_DATE"].ToString() : dt.Rows[i]["LastInvoiceDate"].ToString());
                if (dt.Rows[i]["LastInvoiceDate"].ToString() != string.Empty && dt.Rows[i]["LastInvoiceDate"] != DBNull.Value)
                    drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"].ToString());
                else
                    drAdd["LastInvoiceDate"] = DateTime.Now;
                drAdd["AmountDue"] = Convert.ToDecimal(0.0);
                // drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString();
                // drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                //drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();
                drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                //  drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["Package"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["Packageadmin   amin"].ToString()) : 1);//Commented on 29 july 2014
                drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["Package"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["Package"].ToString()) : 1);
                drAdd["DiscountPercentage"] = 0;// Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                dtLocal.Rows.Add(drAdd);
            }
            if (dtLocal.Rows.Count > 0)
            {
                Obj_viewer.Report_Table = dtLocal;
                Obj_viewer.HTable.Clear();
                Obj_viewer.HTable.Add("note", ObjBALClass.ObjOrder.CheckNote == true ? ObjBALClass.ObjOrder.OrderNote : string.Empty);
                if (GeneralOptionSetting.FlagInvoiceTemplate == "0" || GeneralOptionSetting.FlagInvoiceTemplate == "2" || GeneralOptionSetting.FlagInvoiceTemplate == "4" || GeneralOptionSetting.FlagInvoiceTemplate == "8" || GeneralOptionSetting.FlagInvoiceTemplate == "12" || GeneralOptionSetting.FlagInvoiceTemplate == "13" || GeneralOptionSetting.FlagInvoiceTemplate == "9" || GeneralOptionSetting.FlagInvoiceTemplate == "7")
                {
                    Obj_viewer.HTable.Clear();
                    Obj_viewer.HTable.Add("note", ObjBALClass.ObjOrder.Status == 1 ? ObjBALClass.ObjOrder.Note : string.Empty);
                }
                if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                {
                    Obj_viewer.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000")));
                }
                Obj_viewer.HTable.Add("IncludeTax", "No");
                Obj_viewer.HTable.Add("Tax1", "0.000");
                Obj_viewer.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                Obj_viewer.HTable.Add("Tax2", "0.000");
                Obj_viewer.HTable.Add("InvoiceName", "Spoiled Invoice");
                Obj_viewer.HideLogo = ObjBALClass.ObjOrder.CheckNote == true ? true : false;
                //summery=rpt;
                Obj_viewer.RptDoc = OrderInvoiceHelper.ReportSelection();
                Obj_viewer.isInvoice = true;
                Obj_viewer.InvoiceName = "SpoiledInvoice";
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
                //---Below are added temporerly due to print functionality is not working
                //Obj_viewer.HTable.Add("note", ObjBALClass.ObjOrder.Status == 1 ? ObjBALClass.ObjOrder.Note : string.Empty);

                //---------------------------------
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
                if (Obj_viewer.RptDoc is Rpt_InvTemplate1 || Obj_viewer.RptDoc is Rpt_InvTemplate2 || Obj_viewer.RptDoc is Rpt_InvTemplate3 || Obj_viewer.RptDoc is Rpt_InvTemplate4 || Obj_viewer.RptDoc is Rpt_InvTemplate5 || Obj_viewer.RptDoc is Rpt_InvTemplate6)// 10-12-2018 Tanzeel Dev 
                {
                        Obj_viewer.HTable.Add("HideDiscount", true);
                        Obj_viewer.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);
                }
                Obj_viewer.HTable.Add("Paid", 0.0);
                Obj_viewer.HTable.Add("Remaining", 0.0);
                Obj_viewer.LoadEvent();
                //Obj_viewer.ShowDialog();
                //---Below are commented temporerly due to print functionality is not working
                if (ObjBALClass.ObjOrder.Status == 1)
                {
                    Obj_viewer.ShowDialog();
                }
                else
                {
                    try
                    {
                        Obj_viewer.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                    }
                    catch (Exception ex)
                    {
                        GeneralFunction.ErrInfo(ex.Message.ToString(), "Spoiled Items Invoice");
                    }
                }

                //------------------------------------------------------------------------





                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "SpoiledInvoice" + " " + ObjBALClass.ObjOrder.OrderInvoiceNo.ToString(), "MTB_ORDER", "Print spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));

            }
            else { GeneralFunction.Information("NoRecordsFound", "SpoiledInvoice"); }
        }

        public static DataTable SimpleInvoiceDataTable()
        {
            DataTable dtLocal = new DataTable("SimpleInvoice");
            if (dtLocal.Columns.Count < 19)
            {
                dtLocal.Columns.Add("InvoiceName");
                dtLocal.Columns.Add("InvoiceNo");
                dtLocal.Columns.Add("InvoiceDate");
                dtLocal.Columns.Add("CustomerId");
                dtLocal.Columns.Add("CustomerName");
                dtLocal.Columns.Add("ItemNo");
                dtLocal.Columns.Add("ItemName");
                dtLocal.Columns.Add("Expiry");
                dtLocal.Columns.Add("Quantity", typeof(int));
                dtLocal.Columns.Add("UnitPrice", typeof(decimal));
                dtLocal.Columns.Add("Total", typeof(decimal));
                dtLocal.Columns.Add("Tax1");
                dtLocal.Columns.Add("Tax2");
                dtLocal.Columns.Add("Discount", typeof(decimal));
                dtLocal.Columns.Add("MaxDept", typeof(decimal));
                dtLocal.Columns.Add("TotalDept", typeof(decimal));
                dtLocal.Columns.Add("Users");
                dtLocal.Columns.Add("TotalLetters");
                dtLocal.Columns.Add("Unit");
                dtLocal.Columns.Add("LastInvoiceDate", typeof(DateTime));
                dtLocal.Columns.Add("AmountDue", typeof(decimal));
                //dtLocal.Columns.Add("StreetAddress");
                dtLocal.Columns.Add("Address2");
                dtLocal.Columns.Add("PhoneNo2");
                dtLocal.Columns.Add("Barcode");
                dtLocal.Columns.Add("DiscountPercentage", typeof(decimal));
                dtLocal.Columns.Add("Package", typeof(int));//Added on 21/July/2014 by Seenivasan for calculating Box & Piece in Report
                dtLocal.Columns.Add("PaymentCharges", typeof(decimal));
            }
            return dtLocal;
        }
        internal void ExpiryList()
        {
            ReportObjectClass obj = new ReportObjectClass();
            ReportHelper rpthelper = new ReportHelper(obj);
            obj.ToDate = DateTime.Now;
            rpthelper.SearchCondition("ExpiryListToADate");

        }
        internal void InsertSpoiledInvoice()
        {
            int Count = 0;
            DataTable dt = ObjBALClass.SpoiledItemsDetails();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal UnitPrice = 0.0m, Total = 0.0m, SalePrice = 0.0m, Cost = 0.0m, NewCost = 0.0m;
                    int StockInHand = 0, BoxQuantity = 0, PieceQuantity = 0;
                    ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(dt.Rows[i]["ItemID"]);
                    ObjBALClass.ObjOrder.ItemName = dt.Rows[i]["ItemName"].ToString();
                    ObjBALClass.ObjOrder.ItemExpiryDate = Convert.ToDateTime(dt.Rows[i]["Expiry"]);
                    ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(dt.Rows[i]["ItemCost"] == DBNull.Value ? 0.000 : dt.Rows[i]["ItemCost"]);
                    ObjBALClass.ObjOrder.ItemPrice = Convert.ToDecimal(dt.Rows[i]["ItemPrice"] == DBNull.Value ? 0.000 : dt.Rows[i]["ItemPrice"]);
                    StockInHand = Convert.ToInt32(dt.Rows[i]["StockInHand"]);
                    ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"] == DBNull.Value ? 0.000 : dt.Rows[i]["UnitPrice"]);

                    ObjBALClass.ObjOrder.ItemPackage = Convert.ToInt32(dt.Rows[i]["Package"] == DBNull.Value ? 1 : dt.Rows[i]["Package"]);
                    ObjBALClass.ObjOrder.ItemPackage = ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjBALClass.ObjOrder.ItemPackage;
                    UnitPrice = ObjBALClass.ObjOrder.ItemCost / ObjBALClass.ObjOrder.ItemPackage;
                    SalePrice = ObjBALClass.ObjOrder.ItemPrice;
                    Cost = UnitPrice * ObjBALClass.ObjOrder.ItemPackage;
                    NewCost = ObjBALClass.ObjOrder.ItemCost;
                    ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(UnitPrice.ToString("#######.000"));
                    ObjBALClass.ObjOrder.SalePrice = SalePrice;
                    ObjBALClass.ObjOrder.ItemCost = Cost;
                    ObjBALClass.ObjOrder.NewCost = NewCost;
                    // ObjBALClass.ObjOrder.ItemTotal = Total;
                    //ObjBALClass.ObjOrder.ItemSerialNo = string.Empty;
                    ObjBALClass.ObjOrder.ItemSerialNo = "0";
                    ObjBALClass.ObjOrder.BarcodeID = dt.Rows[i]["BarcodeID"] != DBNull.Value ? Convert.ToInt32(dt.Rows[i]["BarcodeID"]) : 0;
                    ObjBALClass.ObjOrder.ItemNumber = dt.Rows[i]["ItemNumber"] != DBNull.Value ? dt.Rows[i]["ItemNumber"].ToString() : string.Empty;
                    BoxQuantity = Math.DivRem(StockInHand, ObjBALClass.ObjOrder.ItemPackage, out PieceQuantity);
                    if (BoxQuantity != 0)
                    {
                        ObjBALClass.ObjOrder.ItemQuantity = BoxQuantity * ObjBALClass.ObjOrder.ItemPackage;
                        ObjBALClass.ObjOrder.Box = BoxQuantity;
                        ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());
                        AssignValuesToList();
                        SaveSpoileInvoice();
                    }
                    if (PieceQuantity != 0)
                    {
                        ObjBALClass.ObjOrder.Box = 0;
                        ObjBALClass.ObjOrder.ItemQuantity = PieceQuantity;
                        ObjBALClass.ObjOrder.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjOrder.ItemQuantity).ToString());
                        AssignValuesToList();
                        SaveSpoileInvoice();
                    }
                    if (isProcessTrue)
                    {
                        Count += 1;
                    }
                }
                if (Count == dt.Rows.Count)
                    isProcessTrue = true;
                else
                    isProcessTrue = false;
            }
            else
                GeneralFunction.Information("NoRecordsFound", "SpoiledInvoice");
        }
        public DataTable GetAllItemInStock()
        {
            return ObjBALClass.GetItems();
        }
    }
}
