using System;
using System.Collections.Generic;
using System.Linq;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using System.Drawing;
using BumedianBM.CrystalReports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;

namespace BumedianBM.ViewHelper
{
    internal class OpeningStockHelper
    {
        internal List<PurchaseObjectClass> ItemList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> FilterItem = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> InventoryList = new List<PurchaseObjectClass>();
        internal OpeningStockBAL objOpeningStockBAL;
        internal Item_Information ObjItemInfo;
        internal bool isPackage, chkSupplier = false;
        internal string ControlName = string.Empty;
        private decimal piececost;
        internal decimal ItemCost, ItemUnitPrice;
        Item_Serial_Number objSerial;
        private int Index = -1;
        internal bool ProgressStatus = false;
        internal System.Data.DataTable datatable = new System.Data.DataTable();
        System.Data.DataTable dt = new DataTable();
        internal DataTable ItemDetails = new DataTable();
        internal List<PurchaseObjectClass> PackageQty = new List<PurchaseObjectClass>();
        internal OpeningStockHelper()
        {
            objOpeningStockBAL = new OpeningStockBAL();
            objSerial = new Item_Serial_Number();
            ObjItemInfo = new Item_Information();
            ObjBALClass.SetObject();
            SetItemDetailsToList();
        }

        //internal System.Data.DataSet dsComCat;
        //internal DataTable dtCat;
        //internal DataTable dtCom;
        //internal DataTable dtAgent;
        //internal DataTable dtGridValues;
        //internal DataTable dtControls;
        //internal DataTable dtItemID;
        //internal DataTable dtItemName;
        //internal void ComCatList()
        //{

        //    using (dsComCat = objOpeningStockBAL.GetComCatList())

        //            dtCat = dsComCat.Tables[0];
        //            dtCom = dsComCat.Tables[1];
        //            dtAgent = dsComCat.Tables[2];
        //            dtItemID = dsComCat.Tables[3];
        //            dtItemName = dsComCat.Tables[4];
        //}
        //internal void GridContent()
        //{
        //    using (dtGridValues = objOpeningStockBAL.GetGridList())
        //    {
        //        //     if(dtGridValues.Rows.Count>0)
        //        objOpeningStockBAL.objOpeningStockObject.Total = dtGridValues.Rows.Count > 0 ? Convert.ToDecimal(dtGridValues.Compute("sum(Total)", "")) : 0;
        //    }
        //}
        //internal void GetControlDetails()
        //{
        //    int status = 0;

        //    using (dtControls = objOpeningStockBAL.GetControlDetails())
        //    {
        //        if (dtControls.Rows.Count > 0)
        //            status = Convert.ToInt16(dtControls.Rows[0]["Status"]);
        //        if (status == 1)
        //            objOpeningStockBAL.objOpeningStockObject.NewIn = 1;
        //        //     objOpeningStockBAL.objOpeningStockObject.Total = Convert.ToDecimal(dtControls.Compute("sum(Total)", ""));
        //        if (Convert.ToInt16(dtControls.Rows[0]["AgentID"]) != 0)
        //        {
        //            objOpeningStockBAL.objOpeningStockObject.SupplierNo = Convert.ToInt16(dtControls.Rows[0]["AgentID"]);
        //        }

        //    }

        //}

        public OpeningStockBAL ObjBALClass
        {
            get { return objOpeningStockBAL; }
            set { objOpeningStockBAL = value; }
        }

        internal void SetItemDetailsToList()
        {
            ObjBALClass.ObjStock.CategoryNo = Convert.ToInt32(CategoryId.Value);
            ObjBALClass.ObjStock.CompanyNo = Convert.ToInt32(CategoryId.Value);  //  101 to 1001 is changed due to default records are changed to 1001 for category and company id. Done by Manoj On June-24
           // ItemList = ObjBALClass.GetItemDetailsForStock().ToList();
            ItemDetails = ObjBALClass.GetItemdetails();
        }

        internal DataTable FilterItemUsingComCat()
        {
            DataTable dtfilteredItem = ObjBALClass.GetItemdetails();
            return dtfilteredItem;
            //if ((ObjBALClass.ObjStock.CategoryNo == 0 || ObjBALClass.ObjStock.CategoryNo == null) && (ObjBALClass.ObjStock.CompanyNo == 0 || ObjBALClass.ObjStock.CompanyNo == null))
            //{
            //    FilterItem = ItemList.Where(a => (a.CategoryNo == Convert.ToInt32(CategoryId.Value)) && (a.CompanyNo == Convert.ToInt32(CompanyId.Value))).ToList();
            //}
            //else
            //{
            //    if (ObjBALClass.ObjStock.CategoryNo != 0 && (ObjBALClass.ObjStock.CompanyNo == Convert.ToInt32(CompanyId.Value)))
            //    {
            //        FilterItem = ItemList.Where(a => (a.CategoryNo == ObjBALClass.ObjStock.CategoryNo) && (a.CompanyNo == Convert.ToInt32(CompanyId.Value))).ToList();
            //    }
            //    else if ((ObjBALClass.ObjStock.CategoryNo == Convert.ToInt32(CategoryId.Value)) && (ObjBALClass.ObjStock.CompanyNo != 0))
            //    {
            //        FilterItem = ItemList.Where(a => (a.CategoryNo == Convert.ToInt32(CategoryId.Value)) && (a.CompanyNo == ObjBALClass.ObjStock.CompanyNo)).ToList();
            //    }
            //    if ((ObjBALClass.ObjStock.CategoryNo != null || ObjBALClass.ObjStock.CategoryNo != Convert.ToInt32(CategoryId.Value)) && (ObjBALClass.ObjStock.CompanyNo != Convert.ToInt32(CompanyId.Value) || ObjBALClass.ObjStock.CompanyNo != null))
            //    {
            //        FilterItem = ItemList.Where(a => (a.CompanyNo == ObjBALClass.ObjStock.CompanyNo) && (a.CategoryNo == ObjBALClass.ObjStock.CategoryNo)).ToList();
            //    }
            //}
        }

        internal void SetDataGridData()
        {
           
            //var list = ObjBALClass.GetInventoryDetails();
            //InventoryList = list;

            foreach (var list in ObjBALClass.GetInventoryDetails())
            {
                ObjBALClass.ObjStock.ItemDescription = list.ItemDescription;
                ObjBALClass.ObjStock.Note = list.Note;
                ObjBALClass.ObjStock.Status = list.Status;
                ObjBALClass.ObjStock.SupplierNo = list.SupplierNo;
                if (InventoryList.Count > 0)
                {
                    Index = InventoryList.FindIndex(a => (a.ItemNo == list.ItemNo) && (a.ItemDescription == list.ItemName) && (a.ItemExpiry == (list.ItemExpiryDate == DateTime.MinValue ? "-" : list.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == list.ItemUnitPrice) && (a.BarcodeID == list.BarcodeID));
                    if (Index != -1)
                    {
                        InventoryList[Index].ItemQuantity = InventoryList[Index].ItemQuantity + list.ItemQuantity;
                        InventoryList[Index].ItemTotal = InventoryList[Index].ItemUnitPrice * InventoryList[Index].ItemQuantity;
                        InventoryList[Index].Box = InventoryList[Index].ItemQuantity / (InventoryList[Index].ItemPackage != 0 ? InventoryList[Index].ItemPackage : 1);
                    }
                }
                if (Index == -1)
                    InventoryList.Add(new PurchaseObjectClass
                    {
                        ItemNo = list.ItemNo,
                        ItemName = list.ItemName,
                        ItemExpiry = list.ItemExpiryDate.ToString() == DateTime.MinValue.ToString() ? "-" : (list.ItemExpiryDate).Value.ToShortDateString(),
                        ItemExpiryDate = list.ItemExpiryDate == DateTime.MinValue ? null : list.ItemExpiryDate,
                        ItemPackage = list.ItemPackage,
                        ItemQuantity = list.ItemQuantity,
                        Box = (list.ItemQuantity % (list.ItemPackage == 0 ? 1 : list.ItemPackage)) == 0 ? list.ItemQuantity / (list.ItemPackage == 0 ? 1 : list.ItemPackage) : 0,
                        ItemUnitPrice = Convert.ToDecimal(list.ItemUnitPrice.ToString("#####0.000")),
                        ItemTotal = Convert.ToDecimal(list.ItemTotal.ToString("#####0.000")),
                        ItemSerialNo = list.ItemSerialNo,
                        ItemCost = Convert.ToDecimal(list.ItemCost.ToString("####0.000")),
                        Time = list.Time,
                        User = list.User,
                        ItemPrice = list.ItemPrice,
                        Note = list.Note,
                        ItemNumber = list.ItemNumber,
                        BarcodeID = list.BarcodeID
                    });
            }

        
            ObjBALClass.ObjStock.ItemTotal = InventoryList.Sum(a => a.ItemTotal);
        }

        internal void ItemNameSelectedIndexChange()
        {
            try
            {
                if (ObjBALClass.ObjStock.ItemName != string.Empty && ObjBALClass.ObjStock.ItemNo != 0)
                {
                    PackageQty.Clear();
                    List<PurchaseObjectClass> ItemList = ObjBALClass.GetItemDetails();
                    foreach (var list in ItemList)
                    {
                        ObjBALClass.ObjStock.ItemNo = list.ItemNo;
                        ObjBALClass.ObjStock.ItemName = list.ItemName;
                        ObjBALClass.ObjStock.ItemBarcode = list.ItemBarcode;
                        ObjBALClass.ObjStock.CategoryNo = list.CategoryNo;
                        ObjBALClass.ObjStock.ItemType = list.ItemType;
                        ObjBALClass.ObjStock.ItemPlaceID = list.ItemPlaceID;
                        //ObjBALClass.ObjStock.ItemDescription = list.ItemDescription;
                        ObjBALClass.ObjStock.ItemUnitPrice = list.ItemUnitPrice;
                        ObjBALClass.ObjStock.CompanyNo = list.CompanyNo;
                        ItemCost = ObjBALClass.ObjStock.ItemCost = list.ItemCost;
                        ObjBALClass.ObjStock.PurchaseCost = list.ItemCost;
                        ObjBALClass.ObjStock.ItemLastCost = list.ItemLastCost;
                        ObjBALClass.ObjStock.ItemPackage = list.ItemPackage;
                        ObjBALClass.ObjStock.ExpiryDate = list.ExpiryDate;
                        ObjBALClass.ObjStock.Reorder = list.Reorder;
                        ObjBALClass.ObjStock.ItemWholeSalePrice = list.ItemWholeSalePrice;
                        ObjBALClass.ObjStock.ItemPrice = list.ItemPrice;
                        ObjBALClass.ObjStock.MaxOrder = list.MaxOrder;
                        ObjBALClass.ObjStock.ItemMinimumPrice = list.ItemMinimumPrice;
                        ObjBALClass.ObjStock.AvgCost = list.AvgCost;
                        ObjBALClass.ObjStock.ItemExpiryDate = list.ItemExpiryDate;
                        ObjBALClass.ObjStock.ItemTotalStock = list.ItemTotalStock;
                        ObjBALClass.ObjStock.ItemStock = (ObjBALClass.ObjStock.ItemTotalStock / (ObjBALClass.ObjStock.ItemPackage != 0 ? ObjBALClass.ObjStock.ItemPackage : 1)) + 1;
                        ObjBALClass.ObjStock.BarcodeID = list.BarcodeID;
                        ObjBALClass.ObjStock.ItemNumber = list.ItemNumber;
                        ObjBALClass.ObjStock.ItemCardItemCost = list.ItemCardItemCost;
                        ObjBALClass.ObjStock.ItemCardPackageQty = list.ItemCardPackageQty;
                        PackageQty.Add(new PurchaseObjectClass
                        {
                            ItemPackage = list.ItemPackage,
                            BarcodeID = ObjBALClass.ObjStock.BarcodeID,
                            ItemPrice = ObjBALClass.ObjStock.ItemPrice,
                            ItemTotalStock=ObjBALClass.ObjStock.ItemTotalStock
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void BoxPieceAction()
        {
            if (isPackage == false)
            {
                //if (ObjBALClass.ObjStock.ItemStock != 0)
                //{
                ObjBALClass.ObjStock.ItemStock = (((ObjBALClass.ObjStock.ItemTotalStock != null) ? ObjBALClass.ObjStock.ItemTotalStock : 0) + ObjBALClass.ObjStock.ItemQuantity);
                piececost = ObjBALClass.ObjStock.ItemCost / ((ObjBALClass.ObjStock.ItemPackage == 0) ? 1 : ObjBALClass.ObjStock.ItemPackage);
                piececost=ObjBALClass.ObjStock.ItemCost = Convert.ToDecimal(piececost.ToString("#######0.000"));
                isPackage = true;
                //}
            }
            else
            {
                int stock = (ObjBALClass.ObjStock.ItemTotalStock != null) ? ObjBALClass.ObjStock.ItemTotalStock : 0;
                ObjBALClass.ObjStock.ItemStock = ((Convert.ToInt32(stock) / ((ObjBALClass.ObjStock.ItemPackage > 0) ? ObjBALClass.ObjStock.ItemPackage : 1)) + ObjBALClass.ObjStock.ItemQuantity);
                decimal strr = ((stock) % (ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage));
                //if (ItemCost == ObjBALClass.ObjStock.PurchaseCost && ItemUnitPrice==0.000m)
                //{
                //    ObjBALClass.ObjStock.ItemCost = ObjBALClass.ObjStock.PurchaseCost;
                //}
                //else
                //{
                //  ItemCost= ObjBALClass.ObjStock.PurchaseCost = ObjBALClass.ObjStock.ItemCost = isPackage == false ? ObjBALClass.ObjStock.ItemCost : Decimal.Parse((ObjBALClass.ObjStock.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage).ToString());
                //}
                if (ItemUnitPrice == piececost)
                {
                    ObjBALClass.ObjStock.ItemCost = ItemCost;
                }
                else
                {
                    ItemCost = ObjBALClass.ObjStock.PurchaseCost = ObjBALClass.ObjStock.ItemCost = isPackage == false ? ObjBALClass.ObjStock.ItemCost : Decimal.Parse((ObjBALClass.ObjStock.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage).ToString());
                }
                //ObjBALClass.ObjStock.ItemCost = ObjBALClass.ObjStock.ItemCost * (ObjBALClass.ObjStock.ItemPackage != 0 ? ObjBALClass.ObjStock.ItemPackage : 1);
                isPackage = false;
            }
        }

        private Boolean ValidatingStock()
        {
            if (chkSupplier)
            {
                if (ObjBALClass.ObjStock.SupplierName.Length == 0)
                {
                    GeneralFunction.Information("EmptySupplierName", "OpeningStock");
                    ControlName = "cmbSupplierName";
                    return false;
                }
            }
            if (ObjBALClass.ObjStock.ItemName.Length == 0 || ObjBALClass.ObjStock.ItemName == string.Empty)
            {
                GeneralFunction.Information("SelectItem", "OpeningStock");
                ControlName = "cmbItem";
                return false;
            }
            else if (ObjBALClass.ObjStock.ItemExpiryDate != null || (ObjBALClass.ObjStock.ItemType == 1))
            {
                DateTime nowdt, itemdt = new DateTime();
                nowdt = DateTime.Now.Date;
                itemdt = Convert.ToDateTime(ObjBALClass.ObjStock.ItemExpiryDate);
                if (ObjBALClass.ObjStock.ExpiryDate == true)
                {
                    if (nowdt >= itemdt)
                    {
                        // GeneralFunction.Information("ItemExpired", "OpeningStock");
                        PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                        frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbuyit");
                        frmExpiry.ShowDialog();
                        ControlName = "dtpExpiry";
                        return false;
                    }
                }
            }
            if (ObjBALClass.ObjStock.ItemCost > ObjBALClass.ObjStock.ItemPrice)
            {
                // if (GeneralFunction.Information("LessthanSellingPricethanCost", ActionType.Information.ToString()) == DialogResult.Yes)
                GeneralFunction.Information("LessthanSellingPricethanCost", ActionType.Information.ToString());
                ControlName = "txtPrice";
                return false;
            }
            if (ObjBALClass.ObjStock.ItemQuantity == 0 || ObjBALClass.ObjStock.ItemQuantity.ToString() == string.Empty)
            {
                GeneralFunction.Information("EmptyQty", "OpeningStock");
                ControlName = "txtQuantity";
                return false;
            }
            return true;
        }

        internal void btnInsertInvoice()
        {
            if (ValidatingStock())
            {
                if (ObjBALClass.ObjStock.ItemType == 2)
                {
                    objSerial.ItemName = ObjBALClass.ObjStock.ItemName;
                    objSerial.ItemID = ObjBALClass.ObjStock.ItemNo;
                    objSerial.ShowDialog();
                    if (objSerial.Status == true)
                    {
                        InsertData();
                    }
                    else
                    { GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("MustSaveItemSerialNo"), "Purchase Invoice"); }
                }
                else
                    InsertData();
            }
        }

        private void InsertData()
        {
            decimal UnitPrice = 0.0m, Total = 0.0m, SalePrice = 0.0m, Cost = 0.0m, NewCost = 0.0m;
            int TotalStock = 0;
            ObjBALClass.ObjStock.ItemPackage = ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage;
            string noww = DateTime.Now.ToShortDateString().ToString();
            string[] exp = ObjBALClass.ObjStock.ItemExpiryDate.ToString().Split(' ');
            //if (ObjBALClass.ObjStock.ItemCost == ObjBALClass.ObjStock.PurchaseCost)
            //{
            //    ObjBALClass.ObjStock.ItemCost = ObjBALClass.ObjStock.PurchaseCost;
            //}
            //else
            //{
            //    ObjBALClass.ObjStock.PurchaseCost = ObjBALClass.ObjStock.ItemCost = isPackage == false ? ObjBALClass.ObjStock.ItemCost : Decimal.Parse((ObjBALClass.ObjStock.ItemCost).ToString()) * Decimal.Parse((ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage).ToString());
            //}
            if (ItemCost == ObjBALClass.ObjStock.PurchaseCost)
            {
                if (decimal.Parse((ItemCost / ObjBALClass.ObjStock.ItemPackage).ToString("#####0.000")) == ItemUnitPrice)
                {
                    ItemCost = ObjBALClass.ObjStock.ItemCost = ObjBALClass.ObjStock.PurchaseCost;
                }
                else
                    ItemCost = ObjBALClass.ObjStock.PurchaseCost = ObjBALClass.ObjStock.ItemCost = isPackage == false ? ItemCost : Decimal.Parse((ItemUnitPrice).ToString()) * Decimal.Parse((ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage).ToString());
            }
            else
            {
                ObjBALClass.ObjStock.PurchaseCost = ObjBALClass.ObjStock.ItemCost = isPackage == false ? ItemCost : Decimal.Parse((ItemUnitPrice).ToString()) * Decimal.Parse((ObjBALClass.ObjStock.ItemPackage == 0 ? 1 : ObjBALClass.ObjStock.ItemPackage).ToString());
            }
            decimal newcost = Convert.ToDecimal(ObjBALClass.ObjStock.ItemCost);
            ObjBALClass.ObjStock.ItemCost = newcost;
            ////****Calculation*****\\\\
            UnitPrice =decimal.Parse((ObjBALClass.ObjStock.ItemCost / ObjBALClass.ObjStock.ItemPackage).ToString("#####0.000"));
            //SalePrice = ObjBALClass.ObjStock.ItemPrice;
            ///Cost = UnitPrice * ObjBALClass.ObjStock.ItemPackage;
            Cost = ObjBALClass.ObjStock.ItemCost;
            NewCost = ObjBALClass.ObjStock.ItemCost;
            //TotalStock = ObjBALClass.ObjPurchase.ItemQuantity * ObjBALClass.ObjPurchase.ItemPackage;
            // Total = UnitPrice * TotalStock;


            ObjBALClass.ObjStock.ItemUnitPrice = UnitPrice;
            //ObjBALClass.ObjStock.SalePrice = SalePrice;
            ObjBALClass.ObjStock.ItemCost = Cost;
            //ObjBALClass.ObjStock.NewCost = NewCost;
            ObjBALClass.ObjStock.ItemTotalStock = TotalStock;
            ObjBALClass.ObjStock.ItemTotal = Total;
            ObjBALClass.ObjStock.Time = DateTime.Now.TimeOfDay.ToString().Split('.')[0];
            ObjBALClass.ObjStock.CreatedBy = GeneralFunction.UserId;
            var list = GeneralObjectClass.UserList.Where(l => l.UserId == ObjBALClass.ObjStock.CreatedBy).ToList();
            ObjBALClass.ObjStock.User = list[0].FirstName;
            if (isPackage == false)
            {
                ObjBALClass.ObjStock.ItemQuantity = ObjBALClass.ObjStock.ItemQuantity * ObjBALClass.ObjStock.ItemPackage;
                ObjBALClass.ObjStock.Box = ObjBALClass.ObjStock.ItemQuantity / ObjBALClass.ObjStock.ItemPackage;
                //ObjBALClass.ObjStock.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjStock.ItemQuantity).ToString());
                ObjBALClass.ObjStock.ItemTotal = (ObjBALClass.ObjStock.ItemCost * ObjBALClass.ObjStock.Box);
            }
            else
            {
                ObjBALClass.ObjStock.ItemQuantity = ObjBALClass.ObjStock.ItemQuantity;
                ObjBALClass.ObjStock.ItemTotal = Decimal.Parse((UnitPrice * ObjBALClass.ObjStock.ItemQuantity).ToString());
                ObjBALClass.ObjStock.Box = 0;
            }

            if (ObjBALClass.ObjStock.ItemType == 2)
            {
                ObjBALClass.ObjStock.ItemSerialNo = objSerial.SerialNo;
            }
            else
            {
                ObjBALClass.ObjStock.ItemSerialNo = "0";
            }
            if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "N")
            {
                if (ObjBALClass.ObjStock.ExpiryDate == true)
                { }
                else { ObjBALClass.ObjStock.ItemExpiryDate = null; }
            }
            else { ObjBALClass.ObjStock.ItemExpiryDate = null; }
            if (InventoryList.Count > 0)
            {
                Index = InventoryList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjStock.ItemNo) && (a.ItemName == ObjBALClass.ObjStock.ItemName) && (a.ItemExpiry == (ObjBALClass.ObjStock.ItemExpiryDate == null ? "-" : ObjBALClass.ObjStock.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == UnitPrice) && (a.ItemSerialNo == ObjBALClass.ObjStock.ItemSerialNo) &&(a.BarcodeID==ObjBALClass.ObjStock.BarcodeID ));
                if (Index != -1)
                {
                    InventoryList[Index].ItemQuantity = InventoryList[Index].ItemQuantity + ObjBALClass.ObjStock.ItemQuantity;
                    InventoryList[Index].ItemTotal = InventoryList[Index].ItemUnitPrice * InventoryList[Index].ItemQuantity;
                    if (!isPackage)
                        InventoryList[Index].Box = InventoryList[Index].ItemQuantity / (InventoryList[Index].ItemPackage != 0 ? ObjBALClass.ObjStock.ItemPackage : 1);
                    InventoryList[Index].ItemExpiryDate = ObjBALClass.ObjStock.ItemExpiryDate;
                }
            }
            if (Index == -1)
                InventoryList.Add(new PurchaseObjectClass
                {
                    ItemNo = ObjBALClass.ObjStock.ItemNo,
                    ItemName = ObjBALClass.ObjStock.ItemName,
                    ItemExpiry = ObjBALClass.ObjStock.ItemType == 1 ? ObjBALClass.ObjStock.ItemExpiryDate == null ? "-" : ObjBALClass.ObjStock.ItemExpiryDate.Value.ToShortDateString() : "-",
                    ItemExpiryDate = ObjBALClass.ObjStock.ItemType == 1 ? ObjBALClass.ObjStock.ItemExpiryDate == null ? null : ObjBALClass.ObjStock.ItemExpiryDate : null,
                    ItemPackage = ObjBALClass.ObjStock.ItemPackage,
                    ItemQuantity = ObjBALClass.ObjStock.ItemQuantity,
                    Box = ObjBALClass.ObjStock.Box,
                    ItemUnitPrice = ObjBALClass.ObjStock.ItemUnitPrice,
                    ItemTotal = ObjBALClass.ObjStock.ItemTotal,
                    ItemSerialNo = ObjBALClass.ObjStock.ItemSerialNo,
                    ItemCost = ObjBALClass.ObjStock.ItemCost,
                    ItemPrice = ObjBALClass.ObjStock.ItemPrice,
                    Time = Convert.ToDateTime(ObjBALClass.ObjStock.Time).ToShortTimeString(),
                    User = ObjBALClass.ObjStock.User.ToString(),
                    ItemNumber = ObjBALClass.ObjStock.ItemNumber,
                    BarcodeID=ObjBALClass.ObjStock.BarcodeID,
                    Note= ObjBALClass.ObjStock.Note

                });
            // ObjBALClass.ObjStock.ItemNet = total;
            ObjBALClass.ObjStock.Time = DateTime.Now.ToString();
            ObjBALClass.ObjStock.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjStock.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjStock.Status = 1;
            ObjBALClass.ObjStock.BatchID = 1;
            if (ObjBALClass.SaveInventoryDetails())
            {
                if (ObjBALClass.SaveStockDetails())
                {
                    //  GeneralFunction.Information("Saved", "Inventory");
                    ProgressStatus = true;
                }
            }
            decimal total = InventoryList.Sum(a => a.ItemTotal);
            ObjBALClass.ObjStock.ItemTotal = total;
        }

        internal void AssignDataSource(DataGridView dgvInventory)
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = null;
            //InventoryList = PurchaseInvoiceHelper.SortList(InventoryList);
            dt =GeneralFunction.SortInvoiceDetails(CommonHelper.ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InventoryList),"ItemName","ItemUnitPrice");
            dgvInventory.DataSource = dt;
            //////To highlight the last inserted record    on 09 jun 2014//////////////////
            if (dgvInventory.Rows.Count > 0)
            {
                dgvInventory.ClearSelection();
                dgvInventory.FirstDisplayedScrollingRowIndex = dgvInventory.Rows.Count - 1;
                dgvInventory.Rows[dgvInventory.Rows.Count - 1].Selected = true;
            }
            
        }
        internal void HighligntText(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dgv.SelectedRows.Count; i++)
                {
                    dgv.SelectedRows[i].Selected = false;
                }
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (ObjBALClass.ObjStock.ItemName == dgv.Rows[i].Cells["Itemname"].Value.ToString())
                {
                    dgv.Rows[i].Selected = true;
                    // dgv.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }
        private Boolean SaveValidation()
        {
            if (chkSupplier)
            {
                if (ObjBALClass.ObjStock.SupplierName.Length == 0)
                {
                    GeneralFunction.Information("EmptySupplierName", "OpeningStock");
                    ControlName = "cmbSupplierName";
                    return false;
                }
            }
            if (ObjBALClass.ObjStock.ItemDescription.Length == 0)
            {
                GeneralFunction.Information("EmptyDescription", "OpeningStock");
                ControlName = "txtDescription";
                return false;
            }
            //if (ObjBALClass.ObjStock.Note.Length == 0)
            //{
            //    if (GeneralFunction.Question("LiketoAddNote", "OpeningStock") == DialogResult.Yes)
            //    {
            //        ControlName = "txtNotes";
            //        return false;
            //    }
            //} ----------- this validation not required as per the client request Commanded on 28/04/2014 By Meena.R
            return true;
        }

        internal void btnSaveInventory()
        {
            if (SaveValidation())
            {
                if (InventoryList.Count > 0)
                {
                    //int count = 0;
                    //for (int i = 0; i < InventoryList.Count; i++)
                    //{
                    //    AssignValueFromList(i);
                    //    ObjBALClass.ObjStock.ModifiedBy = GeneralFunction.UserId;
                    //    if (ObjBALClass.UpdateInventory())
                    //    { count += 1; }
                    //}
                    //if (count == InventoryList.Count)
                    //{
                    //    ObjBALClass.ObjStock.Status = 2;
                    //    ProgressStatus = true;
                    //}//// this commended by Meena.R On 24/06/2014 to fix Description
                    ObjBALClass.ObjStock.ModifiedBy = GeneralFunction.UserId;
                    if (ObjBALClass.ObjStock.ItemNo != 0 && ObjBALClass.ObjStock.ItemName != string.Empty)
                    {
                        List<PurchaseObjectClass> templist = new List<PurchaseObjectClass>();
                        templist = InventoryList.Where(a => (a.ItemNo == ObjBALClass.ObjStock.ItemNo) && (a.ItemName == ObjBALClass.ObjStock.ItemName)).ToList();

                          foreach(var list in templist)
                          {
                            ObjBALClass.ObjStock.ItemName = list.ItemName;
                            ObjBALClass.ObjStock.ItemNo = list.ItemNo;
                            ObjBALClass.ObjStock.ItemQuantity = list.ItemQuantity;
                            ObjBALClass.ObjStock.ItemSerialNo = list.ItemSerialNo;
                            ObjBALClass.ObjStock.ItemExpiryDate = list.ItemExpiryDate == DateTime.MinValue ? null : list.ItemExpiryDate;
                            ObjBALClass.ObjStock.ItemCost =list.ItemCost;
                            ObjBALClass.ObjStock.ItemPrice = list.ItemPrice;
                            ObjBALClass.ObjStock.BarcodeID = list.BarcodeID;
                            if (ObjBALClass.UpdateInventory())
                            {
                                ObjBALClass.ObjStock.Status = 2;
                                ProgressStatus = true;
                            }
                             
                        }
                    }
                    else
                    {
                        ObjBALClass.ObjStock.ItemNo = 0;
                        if (ObjBALClass.UpdateInventory())
                        {
                            ObjBALClass.ObjStock.Status = 2;
                            ProgressStatus = true;
                        }
                    }

                }
                else { GeneralFunction.Information("NoItemtoSave", ActionType.Save.ToString()); }
            }
        }

        private void AssignValueFromList(int i)
        {
            ObjBALClass.ObjStock.ItemName = InventoryList[i].ItemName;
            ObjBALClass.ObjStock.ItemNo = InventoryList[i].ItemNo;
            ObjBALClass.ObjStock.ItemQuantity = InventoryList[i].ItemQuantity;
            ObjBALClass.ObjStock.ItemSerialNo = InventoryList[i].ItemSerialNo;
            ObjBALClass.ObjStock.ItemExpiryDate = InventoryList[i].ItemExpiryDate == DateTime.MinValue ? null : InventoryList[i].ItemExpiryDate;
            ObjBALClass.ObjStock.ItemCost = InventoryList[i].ItemCost;
            ObjBALClass.ObjStock.ItemPrice = InventoryList[i].ItemPrice;
            ObjBALClass.ObjStock.BarcodeID  = InventoryList[i].BarcodeID ;

        }

        internal Boolean btnModifyInvoice()
        {
            ObjBALClass.ObjStock.Status = 1;
            if (ObjBALClass.ModifyInventory())
                return true;
            else
                return false;
        }

        internal void btnUndoInventory()
        {
            int i = InventoryList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjStock.ItemNo) && (a.ItemSerialNo == ObjBALClass.ObjStock.ItemSerialNo) && (a.ItemQuantity == ObjBALClass.ObjStock.ItemQuantity) && (a.ItemExpiryDate == ObjBALClass.ObjStock.ItemExpiryDate) && (a.BarcodeID == ObjBALClass.ObjStock.BarcodeID));
            AssignValueFromList(i);

            int StockLevel = Convert.ToInt32(ObjBALClass.GetDeleteStockCount());
            if (StockLevel < ObjBALClass.objOpeningStockObject.ItemQuantity)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty") + " " + "'" + StockLevel.ToString() + "'", "OpeningStock");
                if (GeneralFunction.Question("Doyouwanttocontinue", "OpeningStock") == DialogResult.Yes)
                {
                    ObjBALClass.ObjStock.Note = "update";
                    ObjBALClass.ObjStock.ItemQuantity = StockLevel;
                    if (ObjBALClass.UndoInventory())
                    {
                        ProgressStatus = true;
                        ObjBALClass.ObjStock.ItemQuantity = StockLevel;
                        InventoryList[i].Box = InventoryList[i].ItemQuantity - StockLevel;
                        InventoryList[i].ItemQuantity = InventoryList[i].ItemQuantity - StockLevel;
                        InventoryList[i].ItemTotal = InventoryList[i].ItemQuantity * ObjBALClass.ObjStock.ItemUnitPrice;
                    }
                }
                else
                    return;
            }
            else
            {
                
                if (i != -1)
                {
                    ObjBALClass.ObjStock.Note = "delete";
                    ObjBALClass.ObjStock.ModifiedBy = GeneralFunction.UserId;
                    if (ObjBALClass.UndoInventory())
                    {
                        InventoryList.RemoveAt(i);
                        ProgressStatus = true;
                    }
                }
            }
            ObjBALClass.ObjStock.ItemTotal = InventoryList.Sum(a => a.ItemTotal);

        }

        internal void GridCellDoubleClick()
        {
            this.ItemNameSelectedIndexChange();
            if (ObjBALClass.ObjStock.ItemType == 2)
            {
                objSerial.ItemName = ObjBALClass.ObjStock.ItemName;
                objSerial.ItemID = ObjBALClass.ObjStock.ItemNo;
                objSerial.ShowDialog();
            }
            else
                return;
        }

        internal void btnExport()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table = ObjBALClass.GetInventoryExport();//datatable; // //CommonHelper.ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InventoryList);
            if (table != null)
            {
                if (table.Columns.Contains("Edit"))
                    table.Columns.Remove("Edit");
                if (table.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.InitialDirectory = @"C:/";                //"C:";
                    saveFileDialog1.Title = "Save Results";
                    saveFileDialog1.Filter = "Microsoft Office Excel Wookbook|.xls";
                    saveFileDialog1.FileName = "OpenStockDetails";

                    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    {

                        Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add();
                        Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];
                        //Excel.Application excelApp = new Excel.Application();
                        //application.Workbooks.Add();
                        // application.Worksheets.Add(datatable).InsertDataTable(datatable, 0, 0, true);
                        // single worksheet
                        Microsoft.Office.Interop.Excel._Worksheet workSheet = application.ActiveSheet;
                        Font f = new Font("Simplified Arabic", 13.0f);
                        application.StandardFont = "Simplified Arabic";
                        application.StandardFontSize = 13.0f;
                        // application.ThisCell.Font.FontStyle = f;
                        // column headings
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            workSheet.Cells[1, (i + 1)] = table.Columns[i].ColumnName;
                            //worksheet.Cells.Font.FontStyle = f;
                            //worksheet.Cells.Font.Color=Color.BlueViolet;
                            workSheet.Cells[1, (i + 1)].Font.Color = Color.BlueViolet.ToArgb();
                        }
                        // rows
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            for (int j = 0; j < table.Columns.Count; j++)
                            {
                                workSheet.Cells[(i + 2), (j + 1)] = table.Rows[i][j];
                                //worksheet.Cells.Font.FontStyle =f;
                            }
                        }
                        // check fielpath
                        if (saveFileDialog1.FileName != null && saveFileDialog1.FileName != "")
                        {
                            workSheet.SaveAs(saveFileDialog1.FileName);
                            application.Quit();
                            // MessageBox.Show("Excel file saved!");
                        }

                        //Obj_InvenDal.ExportOpeningStock(saveFileDialog1.FileName);
                        //GeneralFunction.InfoMsg("ExportDetailsSucces", this.Text);
                        //DataSet dts = new DataSet();
                        ////dts = Obj_InvenDal.ExportOpeningStock(saveFileDialog1.FileName);
                        //if ((Obj_InvenDal.ExportOpeningStock(saveFileDialog1.FileName).Tables[1].Rows.Count > 0) && (Obj_InvenDal.ExportOpeningStock(saveFileDialog1.FileName).Tables[1].Rows[0]["Success"].ToString() == "0"))
                        //    GeneralFunction.InfoMsg("ExportDetailsSucces", this.Text);
                        //else
                        //    GeneralFunction.InfoMsg("FailedExport , Pls Avoid space in filepath,try in another Drive", this.Text);
                    }
                    saveFileDialog1.Dispose();
                    saveFileDialog1 = null;

                }
                else
                { GeneralFunction.Information("NoDatetoExport", ActionType.Save.ToString()); }
            }
            else
            { GeneralFunction.Information("NoDatetoExport", ActionType.Save.ToString()); }
        }

        internal void btnPayReceipt()
        {
            Pay_Receipt pay = new Pay_Receipt();
            pay.strPayTo = ObjBALClass.ObjStock.SupplierName;
            pay.strPayTo1 = ObjBALClass.ObjStock.SupplierNo;
            pay.strDiscription = "OpeningStock";
            pay.strDiscriptionArabic = GeneralFunction.ChangeLanguageforCustomMsg("OpeningStock");
            pay.strValue = ObjBALClass.ObjStock.ItemTotal.ToString();
            pay.strFromInvoice = 0;
            pay.dtPaymentDate = DateTime.Now;
            pay.strFlag = (int)CommonHelper.PayReceiptFor.OpenStock;
            pay.ShowDialog();
        }

        internal void btnPrint()
        {
            DataRow dr;
            if (InventoryList.Count == 0) return;
            Rpt_Inventory summery = new Rpt_Inventory();
            ReportDocument doc = new ReportDocument();
            ReportsView RptView = new ReportsView();
            RptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("InventoryList");
            DataTable tempdt = new DataTable("InventoryList");
            tempdt = ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InventoryList);
            //FillItemDetailsInGrid();
            //InvenDT = (DataTable)Dgv_Inventory.DataSource;
            if (tempdt != null && tempdt.Rows.Count > 0 && tempdt.Columns.Contains("Note") != true)
                tempdt.Columns.Add("Note");
            DataTable InvDT = new DataTable("InventoryList");
            Int32 sumQty = 0;
            if (InvDT.Columns.Count < 4)
            {
                InvDT.Columns.Add("ItemNo");
                InvDT.Columns.Add("ItemName");
                InvDT.Columns.Add("Description");
                InvDT.Columns.Add("ExpiryDate");
                InvDT.Columns.Add("Package");
                InvDT.Columns.Add("Quantity");
                InvDT.Columns.Add("ItemPrice");
                InvDT.Columns.Add("UnitPrice");
                InvDT.Columns.Add("Cost");
                InvDT.Columns.Add("Total");
                InvDT.Columns.Add("Time");
                InvDT.Columns.Add("User");
                InvDT.Columns.Add("SerialNo");
                InvDT.Columns.Add("Note");
            }
            for (int i = 0; i < tempdt.Rows.Count; i++)
            {
                dr = InvDT.NewRow();
                //dr["ItemNo"] = tempdt.Rows[i]["ItemNo"];
                dr["ItemNo"] = tempdt.Rows[i]["ItemNumber"];
                dr["ItemName"] = tempdt.Rows[i]["ItemName"];
                dr["Description"] = tempdt.Rows[i]["ItemDescription"];
                dr["ExpiryDate"] = tempdt.Rows[i]["ItemExpiryDate"];
                dr["Package"] = tempdt.Rows[i]["ItemPackage"];
                dr["Quantity"] = tempdt.Rows[i]["ItemQuantity"];
                dr["Cost"] = tempdt.Rows[i]["ItemCost"];
                dr["UnitPrice"] = tempdt.Rows[i]["ItemUnitPrice"];
                dr["ItemPrice"] = tempdt.Rows[i]["ItemPrice"];
                dr["Total"] = tempdt.Rows[i]["ItemTotal"];
                dr["Time"] = tempdt.Rows[i]["Time"];
                dr["User"] = tempdt.Rows[i]["User"];
                dr["SerialNo"] = tempdt.Rows[i]["ItemSerialNo"];
                dr["Note"] = tempdt.Rows[i]["Note"];
                InvDT.Rows.Add(dr);
            }
            decimal SumTotals = 0, SumItemCost = 0, SumItemPrice = 0;
            if (InvDT != null)
            {
                for (int j = 0; j < InvDT.Rows.Count; j++)
                {
                    sumQty += Convert.ToInt32(InvDT.Rows[j]["Quantity"].ToString());
                    SumTotals += Convert.ToDecimal(InvDT.Rows[j]["Total"].ToString());
                    SumItemCost += Convert.ToDecimal(InvDT.Rows[j]["Cost"].ToString());
                    SumItemPrice += Convert.ToDecimal(InvDT.Rows[j]["UnitPrice"].ToString());
                    //InvDT.Rows[j]["Note"] = ObjBALClass.ObjStock.Note;
                }
                InvDT = GeneralFunction.SortInvoiceDetails(InvDT, "ItemName", "Cost");
                RptView.HTable.Clear();
                RptView.HTable.Add("SumQty", sumQty);
                RptView.HTable.Add("SumTotal", SumTotals);
                RptView.HTable.Add("ItemPrice", SumItemPrice);
                RptView.HTable.Add("ItemCost", SumItemCost);
                RptView.IsItemNo = true;
                RptView.isPackage = true;
                //doc=summery;
                RptView.RptDoc = summery;
                RptView.Report_Table = InvDT;
                /// RptView.Repnum =doc.Database.Tables;
                /// 
                RptView.LoadEvent();
                RptView.ShowDialog();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "OpeningStock", "Inventory", "Print openning stock details", Convert.ToInt32(InvoiceAction.Yes));
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", ActionType.Print.ToString());
            }
        }

        public DataTable GetAppliedIncreaseHelper()
        {
            return ObjBALClass.GetAppliedIncreaseBal();
        }

    }
}
