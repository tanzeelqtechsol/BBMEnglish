using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Windows.Forms;
using System.Drawing;
using BumedianBM.ArabicView;
using System.Data;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using POS;


namespace BumedianBM.ViewHelper
{
    public class PosScreenHelper
    {

        #region Declaration
        PosScreenBAL objPosBal;
        internal List<long> InvoiceID = new List<long>();
        public List<POSObject> lstGridItems = new List<POSObject>();
        public List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();
        public DataTable DtPOItems = new DataTable();
        public SalesInvoiceHelper objSaleInvoiceHelper;
        internal Dictionary<string, List<POSObject>> dicSalesDetails = new Dictionary<string, List<POSObject>>();
        internal List<POSObject> Package = new List<POSObject>();
        internal List<ItemCardObjectClass> AllItems = new List<ItemCardObjectClass>();
        internal DataTable DtPOSItem = new DataTable();
        public int OrderNo = 0;
        public int CurrentYear;
        public int Index = 0;
        internal int IDFlag, packageqty;
        internal List<long> ID = new List<long>();
        internal Boolean IsPackage = false;
        public bool StockFinished = false;
        public bool PrintReceipt = false;
        public bool IsFromItemSelection = false; //Added on 17-June-2014 
        public bool IsBtnShortcutClick = false; //Added on 17-June-2014 
        string ItemBasePrinter = string.Empty;
        public bool PrintPreview = false;
        internal decimal ActualPrice = 0.0m;
        internal string PriceType = "NormalPrice";
        List<SaleObject> lstAllPrices = new List<SaleObject>();
        public bool IsItemSaveInGrid = false;
        public bool IsForKitchentSlip = false;
        public bool PrintAllItemInKitchenReceipt = false;
        public bool IsNotPrintKitchenReceipt = false;
        public DataTable KitchenReciptRemainingQuantity = new DataTable();
        #endregion

        #region Constructor
        public PosScreenHelper()
        {
            objPosBal = new PosScreenBAL();
            objSaleInvoiceHelper = new SalesInvoiceHelper();
        }
        #endregion

        #region Getting POS BAL Class in Helper
        public PosScreenBAL objPOSScreenBal
        {
            get { return objPosBal; }
            set { objPosBal = value; }
        }

        #endregion

        #region UIDatabaseMethods

        #region GetOrderNoHelper
        public void GetOrderNoHelper()
        {
            OrderNo = Convert.ToInt16(objPosBal.GetOrderNoBal());
        }

        public int ResetOrderNoSequence(long ID)
        {
            return objPosBal.ResetOrder(ID);
        }

        #endregion

        #region SaveSaleInvoiceHelper
        public bool SaveSaleInvoiceHelper()
        {
            return objPosBal.SaveSaleInvoiceBal();
        }
        #endregion

        #region SaveSaleInvoiceDetailsHelper
        public bool SaveSaleInvoiceDetailsHelper()
        {
            return objPosBal.SaveSaleInvoiceDetailsBal();
        }
        #endregion

        #region GetStockOnItemHelper
        public int GetStockOnItemHelper()
        {
            return Convert.ToInt32(objPosBal.GetStockOnItemBal());
        }
        #endregion

        #region UpdateSerialNohelper
        public bool UpdateSerialNohelper()
        {
            return objPosBal.UpdateSerialNoBal();
        }
        #endregion

        #region GetCurrentYear
        public void GetCurrentYear()
        {
            List<SaleObject> lstCurrentYear;
            try
            {
                lstCurrentYear = objSaleInvoiceHelper.GetCurrentYearHelper(Convert.ToInt32(CommonHelper.Table.POSSaleID));

                if (lstCurrentYear.Count > 0)
                {
                    CurrentYear = (lstCurrentYear[0].CurrentYear != null) ? lstCurrentYear[0].CurrentYear : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCurrentYear = null;
            }

        }
        #endregion

        #region GetMaxSaleIDHelper
        public void GetMaxSaleIDHelper()
        {
            objPosBal.objPOSObject.SaleId = Convert.ToInt64(objPosBal.GetMaxSaleIDBal());
        }
        #endregion

        #region GetSalesDetailsHelper
        public void GetSalesDetailsHelper()
        {
            dicSalesDetails = objPosBal.GetSalesDetailsBal();
        }
        #endregion


        #region GetItemDetailsWithParcodeqty
        public List<ItemCardObjectClass> GetItemDetailsHelper()
        {
            lstItemDetails = objPosBal.GetItemDetailsBAL();
            return lstItemDetails;
        }

        public DataTable NewGetItemDetailsHelper()
        {
            DtPOSItem = objPosBal.NewGetItemDetailsBAL();
            return DtPOSItem;
        }
        #endregion

        #region DeleteSaleInvoiceDetailsHelper
        public bool DeleteSaleInvoiceDetailsHelper()
        {
            return objPosBal.DeleteSaleInvoiceDetailsBal();
        }
        #endregion

        #region ModifySaleDetailsHelper
        public bool ModifySaleDetailsHelper()
        {
            return objPosBal.ModifySaleDetailsBal();
        }
        #endregion

        #region GetPOSIDHelper
        public List<long> GetPOSIDHelper()
        {
            return objPosBal.GetPOSIDBal();
        }
        #endregion

        #region UpdateSaleIDForTableHelper
        public bool UpdateSaleIDForTableHelper()
        {
            return objPosBal.UpdateSaleIDForTableBal();
        }
        #endregion

        #region GetSaleIDForTableHelper
        public long GetSaleIDForTableHelper()
        {
            return objPosBal.GetSaleIDForTableBal();
        }
        #endregion

        #endregion

        #region UIHelperMethods

        #region NewbtnYearInvoice
        public void NewbtnYearInvoice()
        {
            InvoiceID = objPosBal.GetYearSequenceMaxIDBal();
        }
        #endregion

        #region AddGridSaleDetails
        public void AddGridSaleDetails(DataGridView Dg_Sale)
        {

            List<ItemCardObjectClass> lstItem; //Added for Performance Tuning on 19-Nov-2014 by Seenivasan
            List<POSObject> lstExpiryCount; //Added for Performance Tuning on 19-Nov-2014 by Seenivasan
            List<POSObject> lstFilteredGridSale; //Added for Performance Tuning on 19-Nov-2014 by Seenivasan
            try//Added try catch finally to release the object for Performance Tuning on 19-Nov-2014
            {
                bool Goods = false;
                StockFinished = false;
                if (objPosBal.objPOSObject.GridBgColor == "Color [Gray]") return;
                if (objPosBal.objPOSObject.AdditionFlag == 1)
                {

                    if (Dg_Sale.RowCount <= 0) return;
                    int rowindex = Dg_Sale.CurrentRow.Index;

                    lstGridItems.Insert(rowindex + 1, new POSObject
                    {
                        RowID = rowindex + 1,
                        ItemID = 0,
                        ItemName = objPosBal.objPOSObject.ItemName,
                        Qty = 0,
                        Price = 0,
                        TotalPrice = 0,
                        ItemType = Convert.ToInt16(PosItemType.AdditionalItem),//"RegularItem",
                        Box = 0,
                        PackageQty = 0,
                        ButtonId = objPosBal.objPOSObject.ButtonId,
                        ButtonItemId = objPosBal.objPOSObject.ButtonItemId,
                        ItemInsertionNo = objPosBal.objPOSObject.ItemInsertionNo
                    });
                    objPosBal.objPOSObject.QtyText = string.Empty;
                    for (int i = rowindex + 2; i < lstGridItems.Count; i++)
                    {
                        objPosBal.objPOSObject.ItemName = lstGridItems[i].ItemName;
                        objPosBal.objPOSObject.ItemSno = lstGridItems[i].RowID;
                        objPosBal.objPOSObject.ItemID = lstGridItems[i].ItemID;
                        //objPosBal.objPOSObject.ButtonId = lstGridItems[i].ButtonId;
                        //objPosBal.objPOSObject.ButtonItemId = lstGridItems[i].ButtonItemId;
                        lstGridItems[i].RowID = i;
                        UpdateSerialNohelper();
                    }

                    AssignInvoiceDetails(objPosBal.objPOSObject.ItemID, objPosBal.objPOSObject.CurrentQty, Convert.ToDecimal(0.000), Convert.ToInt16(SalesInvoiceType.NormalInvoice), Convert.ToInt16(PosItemType.AdditionalItem), rowindex + 1, Convert.ToDecimal(0.000), objPosBal.objPOSObject.Box);


                }

                else
                {
                    lstItem = new List<ItemCardObjectClass>();
                    lstItem = objPosBal.objPOSObject.lstSelectedItemDetails;

                    lstItem = (from a in lstItem
                               where a.ItemId == objPosBal.objPOSObject.ItemID
                               select a).ToList();
                    if (Package.Count > 0)
                    {
                        lstItem[0].PackageQuantity = packageqty;
                        //lstItem[0].Price = Package.Where(a => a.PackageQty == packageqty).ToList()[0].Price;
                        lstItem[0].Price = Package.Where(a => a.PackageQty == packageqty).ToList()[0].Price;
                        // here
                    }
                    if (lstItem.Count > 0)
                    {

                        #region ExpiryDate Check
                        //**********************Added by Seenivasan on 9-OCT-2014 to check the item with one expiry date is expiry or not*******************************************//

                        if (lstItem[0].ExpiryDate && IsFromItemSelection == false)
                        {
                            lstExpiryCount = new List<POSObject>();
                            lstExpiryCount = objPosBal.GetStockDetailsBAL();
                            if (lstExpiryCount.Count == 1 && (lstExpiryCount[0].ExpiryDate != DateTime.MinValue))
                            {
                                string noww = DateTime.Now.ToShortDateString().ToString();
                                string[] exp = lstExpiryCount[0].ExpiryDate.ToString().Split(' ');
                                DateTime nowdt, exdt = new DateTime();
                                nowdt = Convert.ToDateTime(noww);
                                exdt = Convert.ToDateTime(exp[0]);
                                int diffdt = exdt.CompareTo(nowdt);

                                // objSaleInvoiceHelper.CheckDateIsExpiryHelper();Commented on 30-Apr-2014 and Removed from below if condition to check the Date is Expired
                                if (exp[0] != noww && diffdt > 0)
                                {

                                }
                                else
                                {
                                    PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                                    frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbesold");
                                    frmExpiry.ShowDialog();
                                    return;
                                }
                            }
                        }

                        //*************************************Added by Seenivasan on 9-OCT-2014 to check the item with one expiry date is expiry or not****************************************************************************************************

                        #endregion
                        if (IsFromItemSelection)
                        {
                            PriceType = "NormalPrice";
                        }
                        if (PriceType == "WholeSalePrice")
                        {
                            lstItem[0].Price = lstAllPrices[0].ItemWholeSalePrice;
                        }
                        else if (PriceType == "MinimumPrice")
                        {
                            lstItem[0].Price = lstAllPrices[0].ItemMinimumPrice;
                        }

                        if (lstItem[0].PackageQuantity == 0)
                        {
                            lstItem[0].PackageQuantity = 1;
                        }
                        if (objPosBal.objPOSObject.ScannedPrice != 0 && objPosBal.objPOSObject.ScannedPackageQty != 0)//Added on 22-Apr-14 for Scanned Package QTy and its Price
                        {
                            lstItem[0].Price = Convert.ToDecimal(objPosBal.objPOSObject.ScannedPrice.ToString("####0.000"));
                            lstItem[0].PackageQuantity = objPosBal.objPOSObject.ScannedPackageQty;
                        }

                        objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;

                        objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);

                        if (IsFromItemSelection && GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "N")
                            return;
                        if (IsPackage)
                        {
                            if (ActualPrice == objPosBal.objPOSObject.Price)
                            {
                                if ((objPosBal.objPOSObject.CurrentQty % lstItem[0].PackageQuantity) == 0)//added on 24/11/2014
                                {
                                    if (ActualPrice == Decimal.Parse((Math.Truncate(Convert.ToDecimal(objPosBal.objPOSObject.ItemPackagePrice / lstItem[0].PackageQuantity) * 1000M) / 1000M).ToString()))
                                        objPosBal.objPOSObject.ItemPackagePrice = objPosBal.objPOSObject.ItemPackagePrice;
                                    else
                                        objPosBal.objPOSObject.ItemPackagePrice = objPosBal.objPOSObject.Price * lstItem[0].PackageQuantity;
                                }
                                else
                                    objPosBal.objPOSObject.ItemPackagePrice = objPosBal.objPOSObject.Price * lstItem[0].PackageQuantity;
                            }
                        }
                        else
                        {
                            if (ActualPrice == objPosBal.objPOSObject.ItemPackagePrice)
                            {
                                objPosBal.objPOSObject.Price = Decimal.Parse((Math.Truncate(Convert.ToDecimal(objPosBal.objPOSObject.ItemPackagePrice / lstItem[0].PackageQuantity) * 1000M) / 1000M).ToString());
                            }
                            else
                            {
                                objPosBal.objPOSObject.ItemPackagePrice = objPosBal.objPOSObject.Price * lstItem[0].PackageQuantity;
                            }

                        }

                        objPosBal.objPOSObject.Cost = (!(lstItem[0].ItemCost is DBNull)) ? lstItem[0].AverageCost : Convert.ToDecimal(0.000);
                        if (IsPackage)
                        {
                            objPosBal.objPOSObject.CurrentQty = objPosBal.objPOSObject.CurrentQty;
                            if ((objPosBal.objPOSObject.CurrentQty % lstItem[0].PackageQuantity) == 0)//added on 24/11/2014
                            {
                                //objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                                //objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;
                            }
                            else
                            {
                                //objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                                //objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;
                            }
                        }
                        else
                        {
                            objPosBal.objPOSObject.CurrentQty = objPosBal.objPOSObject.CurrentQty * lstItem[0].PackageQuantity;
                            //objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                            //objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;//Added on 17-June-2014
                        }

                        if (objPosBal.objPOSObject.ScannedPrice != 0 && objPosBal.objPOSObject.ScannedPackageQty != 0)//Added on 15-May-14 for Scanned Package QTy and its Price
                        {
                            objPosBal.objPOSObject.CurrentQty = objPosBal.objPOSObject.ScannedQuantity;//bjPosBal.objPOSObject.ScannedPackageQty;
                            objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                        }

                        objPosBal.objPOSObject.PackageQty = lstItem[0].PackageQuantity;

                        //************************Moved below line from on 17-June-2014***************************************************************
                        if (IsFromItemSelection && objPosBal.objPOSObject.ScannedPrice == 0 && objPosBal.objPOSObject.ScannedPackageQty == 0)
                        {
                            return;
                        }
                        if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "N" && objPosBal.objPOSObject.ScannedPrice != 0 && objPosBal.objPOSObject.ScannedPackageQty != 0)
                        {
                            return;
                        }
                        //*************************************************************************************************************


                        if (lstItem[0].ItemType == Convert.ToInt16(ItemType.Goods))
                        {
                            Goods = true;
                            objPosBal.objPOSObject.StockOnHand = GetStockOnItemHelper();
                            //Commented on 29-oct-2014****************
                            //if (objPosBal.objPOSObject.StockOnHand < objPosBal.objPOSObject.CurrentQty)
                            //{
                            //    objPosBal.objPOSObject.QtyText = string.Empty;
                            //    GeneralFunction.Information("ValidItemQty", "POS Screen"); return;
                            //}
                            //****************************************

                            //Following code added on 29-Oct-2014
                            if (objPosBal.objPOSObject.StockOnHand == 0)
                            {
                                objPosBal.objPOSObject.QtyText = string.Empty;
                                GeneralFunction.Information("NoStockItem", "POS Screen"); return;
                            }
                            else if (objPosBal.objPOSObject.StockOnHand < objPosBal.objPOSObject.CurrentQty)
                            {
                                objPosBal.objPOSObject.QtyText = string.Empty;
                                GeneralFunction.Information("ValidItemQty", "POS Screen"); return;
                            }
                            //******************************
                        }
                        else
                        {
                            Goods = false;
                        }

                        lstFilteredGridSale = new List<POSObject>();
                        lstFilteredGridSale = (from a in lstGridItems
                                               where a.ItemID == objPosBal.objPOSObject.ItemID && a.PackageQty == objPosBal.objPOSObject.PackageQty && a.Price == objPosBal.objPOSObject.Price && (IsPackage == true ? a.Box == 0 : a.Box != 0)
                                               select a).ToList();

                        int index = 0;
                        int i = 0;
                        string addition = "N";
                        for (i = 0; i < lstFilteredGridSale.Count; i++)
                        {
                            index = lstGridItems.IndexOf(lstFilteredGridSale[i]);
                            if (lstGridItems.Count == index + 1 || lstGridItems[index + 1].ItemType != Convert.ToInt16(PosItemType.AdditionalItem))
                            {
                                addition = "Y";
                                break;
                            }
                        }
                        if (lstFilteredGridSale.Count > 0 && addition == "Y") //Update the Gridetails when inserting already added Item
                        {
                            decimal price = lstFilteredGridSale[i].Price;
                            int Qty = lstFilteredGridSale[i].Qty + objPosBal.objPOSObject.CurrentQty;
                            decimal Total = price * Qty;
                            lstGridItems[index].Qty = Qty;
                            lstGridItems[index].TotalPrice = Total;
                            lstGridItems[index].ItemType = Convert.ToInt16(PosItemType.RegularItem);
                            if (IsPackage)//added on 16Mar2015
                            {
                                objPosBal.objPOSObject.Box = 0;
                            }
                            else
                            {
                                objPosBal.objPOSObject.Box = (objPosBal.objPOSObject.CurrentQty != 0 ? lstGridItems[index].Qty / objPosBal.objPOSObject.PackageQty : 0);
                            }
                            lstGridItems[index].Box = objPosBal.objPOSObject.Box;
                            objPosBal.objPOSObject.ItemPrice = objPosBal.objPOSObject.Price * objPosBal.objPOSObject.CurrentQty;
                            TaxCalculation();
                            TotalSales();
                            AssignInvoiceDetails(objPosBal.objPOSObject.ItemID, Qty, price, Convert.ToInt16(SalesInvoiceType.NormalInvoice), Convert.ToInt16(PosItemType.RegularItem), lstGridItems[index].RowID, objPosBal.objPOSObject.Cost, objPosBal.objPOSObject.Box);
                            objPosBal.objPOSObject.QtyText = string.Empty;
                        }
                        else //Insert New Item
                        {
                            int rowindex = lstGridItems.Count;
                            decimal TotalPrice = 0.000m;
                            if (IsPackage)//added on 24Nov2014
                            {
                                if ((objPosBal.objPOSObject.CurrentQty % objPosBal.objPOSObject.PackageQty) == 0)
                                {
                                    TotalPrice = (objPosBal.objPOSObject.ItemPackagePrice * (objPosBal.objPOSObject.CurrentQty / objPosBal.objPOSObject.PackageQty));
                                }
                                else
                                {
                                    TotalPrice = (objPosBal.objPOSObject.Price * objPosBal.objPOSObject.CurrentQty);
                                }
                                objPosBal.objPOSObject.Box = 0;
                            }
                            else
                            {
                                TotalPrice = (objPosBal.objPOSObject.ItemPackagePrice * (objPosBal.objPOSObject.CurrentQty / objPosBal.objPOSObject.PackageQty));
                                objPosBal.objPOSObject.Box = (objPosBal.objPOSObject.CurrentQty != 0 ? objPosBal.objPOSObject.CurrentQty / objPosBal.objPOSObject.PackageQty : 0);
                            }
                            lstGridItems.Add(new POSObject
                            {
                                RowID = rowindex,
                                ItemID = objPosBal.objPOSObject.ItemID,
                                ItemName = objPosBal.objPOSObject.ItemName,
                                Qty = objPosBal.objPOSObject.CurrentQty,
                                Price = Convert.ToDecimal(objPosBal.objPOSObject.Price.ToString("####0.000")),
                                //  TotalPrice = Convert.ToDecimal((objPosBal.objPOSObject.Price * objPosBal.objPOSObject.CurrentQty).ToString("####0.000")),Commended By Meena.R on 24Nov2014
                                TotalPrice = Convert.ToDecimal(TotalPrice.ToString("#####0.000")),
                                ItemType = Convert.ToInt16(PosItemType.RegularItem),//"RegularItem",
                                // Box = (objPosBal.objPOSObject.CurrentQty != 0 ? objPosBal.objPOSObject.CurrentQty / objPosBal.objPOSObject.PackageQty : 0),
                                Box = objPosBal.objPOSObject.Box,
                                PackageQty = objPosBal.objPOSObject.PackageQty,
                                ItemPackagePrice = objPosBal.objPOSObject.ItemPackagePrice,
                                ButtonId = objPosBal.objPOSObject.ButtonId,
                                ButtonItemId = objPosBal.objPOSObject.ButtonItemId,
                                ItemInsertionNo = objPosBal.objPOSObject.ItemInsertionNo

                            });
                            //objPosBal.objPOSObject.ItemPrice = objPosBal.objPOSObject.Price * objPosBal.objPOSObject.CurrentQty;Commended By Meena.R on 24Nov2014
                            objPosBal.objPOSObject.ItemPrice = Convert.ToDecimal(TotalPrice.ToString("#####0.000"));
                            TaxCalculation();
                            TotalSales();
                            AssignInvoiceDetails(objPosBal.objPOSObject.ItemID, objPosBal.objPOSObject.CurrentQty, objPosBal.objPOSObject.Price, Convert.ToInt16(SalesInvoiceType.NormalInvoice), Convert.ToInt16(PosItemType.RegularItem), rowindex, objPosBal.objPOSObject.Cost, objPosBal.objPOSObject.Box);
                            objPosBal.objPOSObject.QtyText = string.Empty;
                        }

                    }
                }

                SplitTax();
                AssignInvoice(Convert.ToInt16(SalesInvoiceType.NormalInvoice));
                SaveSaleInvoiceHelper();
                SaveSaleInvoiceDetailsHelper();
                if (objPosBal.objPOSObject.StockOnHand == objPosBal.objPOSObject.CurrentQty)
                {
                    if (Goods)
                    {
                        StockFinished = true;
                    }
                    // NonStockItem(ItemName); //for changeing the color to red for non stock item Button
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstItem = null;
                lstExpiryCount = null;
                lstFilteredGridSale = null;
            }
        }
        #endregion

        #region GetPrice
        public decimal GetPrice(decimal Price, int Qty)
        {
            try
            {
                if (Price != 0 && Qty != 0)
                {
                    // return Price / Qty;
                    /// return (Math.Truncate(Convert.ToDecimal(Price / Qty) * 1000M) / 1000M);//Added on 15-May-2014
                    float price = float.Parse((Math.Truncate(Convert.ToDecimal(Price / Qty) * 1000M) / 1000M).ToString());
                    return Convert.ToDecimal(Sales_Invoice.CommonRoundPrice(price));

                }
                else { return Price; }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region AssignInvoice
        public void AssignInvoice(int status)
        {
            try
            {
                decimal netAmt = 0.000M, taxAmt = 0.000M;
                netAmt = (objPOSScreenBal.objPOSObject.TotalText == string.Empty) ? Convert.ToDecimal(0.000) : Convert.ToDecimal(objPOSScreenBal.objPOSObject.TotalText);
                taxAmt = (objPOSScreenBal.objPOSObject.TaxText == string.Empty) ? Convert.ToDecimal(0.000) : Convert.ToDecimal(objPOSScreenBal.objPOSObject.TaxText);

                objPOSScreenBal.objPOSObject.AgentId = objPOSScreenBal.objPOSObject.ClientID;

                objPOSScreenBal.objPOSObject.AccountId = 1;
                objPOSScreenBal.objPOSObject.Balance = Convert.ToDecimal(objPOSScreenBal.objPOSObject.RefundText != string.Empty ? objPOSScreenBal.objPOSObject.RefundText : "0.000");//float.Parse(Cmb_Client.SelectedValue.ToString() == "1001" ? (Txt_Refund.Text != string.Empty ? Txt_Refund.Text : "0.000") : (Txt_Total.Text != string.Empty ? Txt_Total.Text : "0.000"));
                //Obj_PosProp.Tax = Convert.ToDecimal(0.00);
                objPOSScreenBal.objPOSObject.GrossAmount = netAmt - taxAmt;
                objPOSScreenBal.objPOSObject.SaleId = objPosBal.objPOSObject.SaleId;
                objPOSScreenBal.objPOSObject.Discount = Convert.ToDecimal(0.000);
                objPOSScreenBal.objPOSObject.NetAmount = netAmt;
                objPOSScreenBal.objPOSObject.PaymentCharges = objPOSScreenBal.objPOSObject.PaymentCharges;
                objPOSScreenBal.objPOSObject.PaidAmount = (objPOSScreenBal.objPOSObject.PaidText == string.Empty) ? Convert.ToDecimal(0.00) : Convert.ToDecimal(objPOSScreenBal.objPOSObject.PaidText);
                objPOSScreenBal.objPOSObject.Status = status;
                objPOSScreenBal.objPOSObject.SaleType = 2;  // "POS";
                objPOSScreenBal.objPOSObject.CreatdBy = GeneralFunction.UserId;
                objPOSScreenBal.objPOSObject.ModifiedBy = GeneralFunction.UserId;
                objPOSScreenBal.objPOSObject.OrderNo = OrderNo;
                //objPosHelper.objPOSScreenBal.objPOSObject.KitchenStatus = kitchen;
                objPOSScreenBal.objPOSObject.SaleDate = objPOSScreenBal.objPOSObject.PosDate != string.Empty ? Convert.ToDateTime(objPOSScreenBal.objPOSObject.PosDate) : Convert.ToDateTime(DateTime.Now.ToShortDateString());

                if (POS_Screen.selectedPaymentType == "card")
                {
                    objPOSScreenBal.objPOSObject.PaymentTypeId = 2;
                }
                else if (POS_Screen.selectedPaymentType == "check")
                {
                    objPOSScreenBal.objPOSObject.PaymentTypeId = 3;
                }
                else
                {
                    objPOSScreenBal.objPOSObject.PaymentTypeId = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region AssignInvoiceDetails
        private void AssignInvoiceDetails(int ItemID, int Qty, decimal price, int status, int itemtype, int sno, decimal cost, int Box)
        {
            try
            {
                objPOSScreenBal.objPOSObject.BatchId = 1;
                objPOSScreenBal.objPOSObject.ItemID = ItemID;
                objPOSScreenBal.objPOSObject.Qty = Qty;
                objPOSScreenBal.objPOSObject.Price = price;
                objPOSScreenBal.objPOSObject.ReturnQty = 0;
                objPOSScreenBal.objPOSObject.ExpiryDate = DateTime.Now;
                objPOSScreenBal.objPOSObject.SaleId = objPosBal.objPOSObject.SaleId;
                objPOSScreenBal.objPOSObject.Discount = Convert.ToDecimal(0.00);
                objPOSScreenBal.objPOSObject.Status = status;
                objPOSScreenBal.objPOSObject.SaleType = 2;  //"POS";
                objPOSScreenBal.objPOSObject.CreatdBy = GeneralFunction.UserId;
                objPOSScreenBal.objPOSObject.ModifiedBy = GeneralFunction.UserId;
                objPOSScreenBal.objPOSObject.ItemType = itemtype;
                objPOSScreenBal.objPOSObject.ItemSno = sno;
                objPOSScreenBal.objPOSObject.Cost = cost;
                objPOSScreenBal.objPOSObject.Box = Box;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region TaxCalculation
        public void TaxCalculation()
        {

            try
            {
                decimal Tax = 0.000M, totalTax1 = 0.000M, totalTax2 = 0.000M, Tax1 = 0.000M, Tax2 = 0.000M, subTax1 = 0.000M, subTax2 = 0.000M;
                if (GeneralOptionSetting.FlagTax1_ApplySales == "Y")
                {
                    Tax1 = (objPosBal.objPOSObject.ItemPrice * decimal.Parse(GeneralOptionSetting.FlagTax1_Percentage)) / 100;
                    subTax1 = (Tax1 * decimal.Parse(GeneralOptionSetting.FlagTax1_SubPercentage)) / 100;
                    totalTax1 = Tax1 + subTax1;
                }
                if (GeneralOptionSetting.FlagTax2_ApplySales == "Y")
                {
                    Tax2 = (objPosBal.objPOSObject.ItemPrice * decimal.Parse(GeneralOptionSetting.FlagTax2_Percentage)) / 100;
                    subTax2 = (Tax2 * decimal.Parse(GeneralOptionSetting.FlagTax2_SubPercentage)) / 100;
                    totalTax2 = Tax2 + subTax2;
                }
                Tax = totalTax1 + totalTax2;
                objPosBal.objPOSObject.ItemTax = Tax;
                //  Txt_Tax.Text --->  objPosBal.objPOSObject.TotalTax
                objPosBal.objPOSObject.TaxText = (((objPosBal.objPOSObject.TaxText != string.Empty) ? Convert.ToDecimal(objPosBal.objPOSObject.TaxText) : 0) + Tax).ToString("####0.000");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region TotalSales()
        public void TotalSales()
        {
            try
            {
                objPosBal.objPOSObject.ItemPrice = objPosBal.objPOSObject.ItemPrice + objPosBal.objPOSObject.ItemTax;
                //Txt_Total.Text ---> objPosBal.objPOSObject.SaleTotal
                objPosBal.objPOSObject.TotalText = (((objPosBal.objPOSObject.TotalText != string.Empty) ? Convert.ToDecimal(objPosBal.objPOSObject.TotalText) : 0) + objPosBal.objPOSObject.ItemPrice).ToString("####0.000");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SplitTax
        public void SplitTax()
        {
            try
            {
                decimal Tax1 = 0.000M, Tax2 = 0.000M, subTax1 = 0.000M, subTax2 = 0.000M;
                if (objPOSScreenBal.objPOSObject.TaxText != string.Empty && objPOSScreenBal.objPOSObject.TotalText != string.Empty && decimal.Parse(objPOSScreenBal.objPOSObject.TaxText) > 0)
                {
                    decimal totalWithoutTax = decimal.Parse(objPOSScreenBal.objPOSObject.TotalText) - decimal.Parse(objPOSScreenBal.objPOSObject.TaxText);
                    if (GeneralOptionSetting.FlagTax1_ApplySales == "Y")
                    {
                        Tax1 = (totalWithoutTax * decimal.Parse(GeneralOptionSetting.FlagTax1_Percentage)) / 100;
                        subTax1 = (Tax1 * decimal.Parse(GeneralOptionSetting.FlagTax1_SubPercentage)) / 100;
                    }
                    if (GeneralOptionSetting.FlagTax2_ApplySales == "Y")
                    {
                        Tax2 = (totalWithoutTax * decimal.Parse(GeneralOptionSetting.FlagTax2_Percentage)) / 100;
                        subTax2 = (Tax2 * decimal.Parse(GeneralOptionSetting.FlagTax2_SubPercentage)) / 100;
                    }
                }
                objPOSScreenBal.objPOSObject.Tax1 = Tax1;
                objPOSScreenBal.objPOSObject.Tax2 = Tax2;
                objPOSScreenBal.objPOSObject.SubTax1 = subTax1;
                objPOSScreenBal.objPOSObject.SubTax2 = subTax2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FillDetailsForInvoiceNo
        public void FillDetailsForInvoiceNo(DataGridView Dg_Sales)
        {
            GetSalesDetailsHelper();
            decimal totalTax = 0.000M;
            if (dicSalesDetails.Count > 0 && dicSalesDetails["Sales"].Count > 0)
            {
                if (CurrentYear != dicSalesDetails["Sales"][0].Year)
                {
                    objPosBal.objPOSObject.NewInvoiceNoText = dicSalesDetails["Sales"][0].Year + "-" + "P" + dicSalesDetails["Sales"][0].YearSequenceNo;
                }
                else
                {
                    objPosBal.objPOSObject.NewInvoiceNoText = "P" + dicSalesDetails["Sales"][0].YearSequenceNo;
                }
                objPosBal.objPOSObject.PosDate = dicSalesDetails["Sales"][0].SaleDate.ToString();
                objPosBal.objPOSObject.OrderNo = dicSalesDetails["Sales"][0].OrderNo;
                objPosBal.objPOSObject.ClientSelectedVal = dicSalesDetails["Sales"][0].AgentId;
                objPosBal.objPOSObject.BtnReceiptEnabled = (dicSalesDetails["Sales"][0].AgentId.ToString() != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString());
                objPosBal.objPOSObject.ShortCut = dicSalesDetails["Sales"][0].ShortCut;
            }
            else
            {
                return;
            }

            if (dicSalesDetails["SalesDetails"].Count > 0)
            {
                decimal Total = 0;

                for (int i = 0; i < dicSalesDetails["SalesDetails"].Count; i++)
                {

                    if (dicSalesDetails["SalesDetails"][i].ItemType == Convert.ToInt16(PosItemType.AdditionalItem))
                    {
                        if (dicSalesDetails["SalesDetails"][i].ButtonId != 0)
                        {
                            dicSalesDetails["SalesDetails"][i].ItemName = dicSalesDetails["SalesDetails"][i].AdditionItemName;
                        }
                        lstGridItems.Add(new POSObject
                        {
                            RowID = dicSalesDetails["SalesDetails"][i].ItemSno,
                            ItemID = 0,
                            ItemName = dicSalesDetails["SalesDetails"][i].ItemName,
                            Qty = 0,
                            Price = 0,
                            TotalPrice = 0,
                            ItemType = Convert.ToInt16(PosItemType.AdditionalItem),//"RegularItem",
                            Box = 0,
                            PackageQty = 0,
                            CategoryName = dicSalesDetails["SalesDetails"][i].CategoryName, ///Include teh ctaegory details on 30 july 2014
                            ButtonId = dicSalesDetails["SalesDetails"][i].ButtonId,
                            ButtonItemId = dicSalesDetails["SalesDetails"][i].ButtonItemId,
                            ItemInsertionNo = dicSalesDetails["SalesDetails"][i].ItemInsertionNo
                        });
                    }
                    else
                    {
                        lstGridItems.Add(new POSObject
                        {
                            RowID = dicSalesDetails["SalesDetails"][i].ItemSno,
                            ItemID = dicSalesDetails["SalesDetails"][i].ItemID,
                            ItemName = dicSalesDetails["SalesDetails"][i].ItemName,
                            Qty = dicSalesDetails["SalesDetails"][i].Qty,
                            Price = Convert.ToDecimal(dicSalesDetails["SalesDetails"][i].Price.ToString("####0.000")),
                            TotalPrice = dicSalesDetails["SalesDetails"][i].Box == 0 ? (dicSalesDetails["SalesDetails"][i].Qty % dicSalesDetails["SalesDetails"][i].PackageQty) == 0 ? Convert.ToDecimal(((dicSalesDetails["SalesDetails"][i].Qty / dicSalesDetails["SalesDetails"][i].PackageQty) * dicSalesDetails["SalesDetails"][i].ItemPackagePrice).ToString("#####0.000")) : Convert.ToDecimal((dicSalesDetails["SalesDetails"][i].Price * dicSalesDetails["SalesDetails"][i].Qty).ToString("####0.000")) : dicSalesDetails["SalesDetails"][i].ItemPackagePrice * dicSalesDetails["SalesDetails"][i].Box,
                            ItemType = Convert.ToInt16(PosItemType.RegularItem),//"RegularItem",
                            //Box = (dicSalesDetails["SalesDetails"][i].Qty != 0 ? dicSalesDetails["SalesDetails"][i].Qty / dicSalesDetails["SalesDetails"][i].PackageQty : 0),
                            Box = dicSalesDetails["SalesDetails"][i].Box,
                            PackageQty = dicSalesDetails["SalesDetails"][i].PackageQty,
                            CategoryName = dicSalesDetails["SalesDetails"][i].CategoryName, ///Include teh ctaegory details on 30 july 2014
                            ItemPackagePrice = dicSalesDetails["SalesDetails"][i].ItemPackagePrice,
                            AdditionItemName = dicSalesDetails["SalesDetails"][i].AdditionItemName,
                            ButtonId = dicSalesDetails["SalesDetails"][i].ButtonId,
                            ButtonItemId = dicSalesDetails["SalesDetails"][i].ButtonItemId,
                            ItemInsertionNo = dicSalesDetails["SalesDetails"][i].ItemInsertionNo
                        });

                        Total += dicSalesDetails["SalesDetails"][i].Box == 0 ? (dicSalesDetails["SalesDetails"][i].Qty % dicSalesDetails["SalesDetails"][i].PackageQty) == 0 ? Convert.ToDecimal(((dicSalesDetails["SalesDetails"][i].Qty / dicSalesDetails["SalesDetails"][i].PackageQty) * dicSalesDetails["SalesDetails"][i].ItemPackagePrice).ToString("#####0.000")) : Convert.ToDecimal((dicSalesDetails["SalesDetails"][i].Price * dicSalesDetails["SalesDetails"][i].Qty).ToString("####0.000")) : dicSalesDetails["SalesDetails"][i].ItemPackagePrice * dicSalesDetails["SalesDetails"][i].Box;
                    }
                }
                totalTax = decimal.Parse(dicSalesDetails["Sales"][0].Tax.ToString()) + decimal.Parse(dicSalesDetails["Sales"][0].Tax1.ToString()) + decimal.Parse(dicSalesDetails["Sales"][0].SubTax1.ToString()) + decimal.Parse(dicSalesDetails["Sales"][0].SubTax2.ToString());
                objPosBal.objPOSObject.TaxText = totalTax.ToString("######0.000");
                objPosBal.objPOSObject.PaymentCharges = dicSalesDetails["Sales"][0].PaymentCharges;
                objPosBal.objPOSObject.TotalText = (Convert.ToDecimal(Total + totalTax + objPosBal.objPOSObject.PaymentCharges)).ToString("######0.000");
                objPosBal.objPOSObject.PaidText = (Convert.ToDecimal(dicSalesDetails["Sales"][0].PaidAmount).ToString("####0.000"));
                objPosBal.objPOSObject.RefundText = ((Convert.ToDecimal(objPosBal.objPOSObject.PaidText) > 0) ? Convert.ToDecimal(Convert.ToDecimal(objPosBal.objPOSObject.TotalText) - Convert.ToDecimal(objPosBal.objPOSObject.PaidText)).ToString() : "0.000");
                SplitTax();
                if (dicSalesDetails["SalesDetails"][0].Status == Convert.ToInt16(SalesInvoiceType.ClosedInvoice))
                {
                    Dg_Sales.BackgroundColor = Color.Gray; Dg_Sales.DefaultCellStyle.BackColor = Color.Gainsboro; Dg_Sales.ForeColor = Color.Red;
                }
                else
                {
                    Dg_Sales.BackgroundColor = Color.NavajoWhite; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black;
                }
            }
            else
            {
                Dg_Sales.BackgroundColor = Color.NavajoWhite; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black;
            }
        }
        #endregion

        #region AddReceipt
        public bool AddReceipt()
        {

            ReceiveReceiptHelper objReceiveHelper = new ReceiveReceiptHelper();
            int ReceiptNo = Convert.ToInt32(objReceiveHelper.objReceiveReceiptBAL.GetReceiptMaxId());
            if (ReceiptNo == 0)
            {
                objReceiveHelper.objReceiveReceiptBAL.InsertReceiptID();
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discriptionarabic = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saletype = Convert.ToInt16(SalesType.POS);
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Status = 1;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.UserId = GeneralFunction.UserId;

                //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = objPOSScreenBal.objPOSObject.PaymentTypeId == 1 ? 101 : objPOSScreenBal.objPOSObject.PaymentTypeId == 2 ? 103 : 101;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleinv = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptdate = DateTime.Now;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receivedfrom = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue = 0;
                //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************


                objReceiveHelper.SaveReceiveReceiptHelper();
            }
            BalanceCalculation();
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = objPosBal.objPOSObject.SaleId;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleinv = objPosBal.objPOSObject.SaleId;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receivedfrom = objPosBal.objPOSObject.ClientID;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = objPOSScreenBal.objPOSObject.PaymentTypeId == 1 ? 101 : objPOSScreenBal.objPOSObject.PaymentTypeId == 2 ? 103 : 101;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = objPosBal.objPOSObject.GrossAmount;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.UserId = GeneralFunction.UserId;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Status = 1;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptdate = DateTime.Now;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = 0;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = 0;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = "POSInvoice " + objPosBal.objPOSObject.NewInvoiceNoText;
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discriptionarabic = "فاتورة البيع السريع  " + objPosBal.objPOSObject.NewInvoiceNoText;
            //objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = (objPosBal.objPOSObject.TotalText != "" ? Convert.ToDecimal(objPosBal.objPOSObject.TotalText) : 0);
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = (objPosBal.objPOSObject.PaidText != "" ? Convert.ToDecimal(objPosBal.objPOSObject.PaidText) : 0);
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue = (objPosBal.objPOSObject.PaidText != "" ? Convert.ToDecimal(objPosBal.objPOSObject.PaidText) : 0);
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saletype = Convert.ToInt16(SalesType.POS);
            objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = "Closed";
            if (objReceiveHelper.SaveReceiveReceiptHelper())
            {

                objReceiveHelper.objReceiveReceiptBAL.InsertReceiptID();
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discriptionarabic = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saletype = Convert.ToInt16(SalesType.POS);
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Status = 1;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.UserId = GeneralFunction.UserId;

                //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = objPOSScreenBal.objPOSObject.PaymentTypeId == 1 ? 101 : objPOSScreenBal.objPOSObject.PaymentTypeId == 2 ? 103 : 101;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleinv = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptdate = DateTime.Now;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receivedfrom = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = string.Empty;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = 0;
                objReceiveHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue = 0;
                //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************


                objReceiveHelper.SaveReceiveReceiptHelper();
                return true;
            }
            else
            {
                return false;
            }


        }
        #endregion
        public void BalanceCalculation()
        {

            List<POSObject> lstBalance;

            try
            {
                decimal decBalance = 0, decTotal = 0;
                objPosBal.objPOSObject.BalanceAgent = objPosBal.objPOSObject.ClientID;
                objPosBal.objPOSObject.BalanceFromDate = DateTime.Now;
                objPosBal.objPOSObject.BalanceToDate = DateTime.Now;
                objPosBal.objPOSObject.BalanceStatus = 1;


                lstBalance = objPosBal.GetBalanceBal();
                //if (lstBalance.Count > 0)
                //{
                //    for (int i = 0; i < lstBalance.Count; i++)
                //    {
                //        if (lstBalance[i].AmountRecieved.ToString() == "0.0000" || lstBalance[i].AmountRecieved == 0)
                //        {
                //            decTotal = decTotal + (Convert.ToDecimal(lstBalance[i].NetAmount));
                //            decBalance = decTotal;
                //        }
                //        else
                //        {
                //            decTotal = decTotal - (Convert.ToDecimal(lstBalance[i].AmountRecieved));
                //            decBalance = decTotal;
                //        }
                //    }

                //}

                if (lstBalance.Count > 0)
                {
                    for (int i = 0; i < lstBalance.Count; i++)
                    {
                        decBalance = lstBalance[i].NetAmount - lstBalance[i].AmountRecieved;
                    }
                }

                objPosBal.objPOSObject.GrossAmount = (decBalance * Convert.ToDecimal(-1));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstBalance = null;
            }
        }

        #region CloseSale

        public void CloseSale(DataGridView Dg_Sales)
        {
            List<POSObject> lstCurrentSaleStatus;
            try
            {


                PrintReceipt = false;
                objPosBal.objPOSObject.DialogueResultOK = false;
                if (objPOSScreenBal.objPOSObject.SaleId == 0) return;
                if (objPOSScreenBal.objPOSObject.ClientID == null)
                {
                    GeneralFunction.Information("EmptyClientName", "POS Screen");
                    // result = false;
                    return;
                }
                if (Dg_Sales.BackgroundColor == Color.Gray) { GeneralFunction.Information("AlreadyInvoiceClosed", "POS Screen"); return; }

                lstCurrentSaleStatus = new List<POSObject>();
                if (dicSalesDetails.Count != 0)
                {
                    lstCurrentSaleStatus = (from a in dicSalesDetails["Sales"]
                                            where a.SaleId == objPOSScreenBal.objPOSObject.SaleId && a.Status == Convert.ToInt16(SalesInvoiceType.ClosedInvoice)
                                            select a).ToList();
                }

                if (lstCurrentSaleStatus.Count == 0)
                {
                    if (Dg_Sales.RowCount > 0)
                    {

                        if (POS_Screen.isPaymentMethodOn == true)
                        {

                            if (POS_Screen.selectedPaymentType == "cash")
                            {
                                if (GeneralOptionSetting.FlagSale_HidePaidRefund != "Y")
                                    savePosUsingPaidRefundForm(Dg_Sales);
                                else
                                    savePosWithoutUsingPaidRefundForm(Dg_Sales);
                            }
                            else if (POS_Screen.selectedPaymentType == "card")
                            {
                                savePosWithoutUsingPaidRefundForm(Dg_Sales);
                            }

                            else if (POS_Screen.selectedPaymentType == "check")
                            {
                                //Txt_Total.Text = posTotal.ToString();
                                if (PaymentTypes.isCheckSave == false)
                                    return;
                                savePosWithoutUsingPaidRefundForm(Dg_Sales);
                            }
                        }
                        else
                        {
                            if (GeneralOptionSetting.FlagSale_HidePaidRefund != "Y")
                                savePosUsingPaidRefundForm(Dg_Sales);
                            else
                                savePosWithoutUsingPaidRefundForm(Dg_Sales);
                        }
                        //if (GeneralOptionSetting.FlagSale_HidePaidRefund != "Y" && POS_Screen.selectedPaymentType != "card")
                        //{
                        //    savePosUsingPaidRefundForm(Dg_Sales);
                        //}
                        //else if (GeneralOptionSetting.FlagSale_HidePaidRefund != "Y" && POS_Screen.selectedPaymentType != "card")
                        //{
                        //
                        //}
                        //
                        //else
                        //{
                        //    savePosWithoutUsingPaidRefundForm(Dg_Sales);
                        //}

                    }
                    else { GeneralFunction.Information("NoIteminInvoice", "POS Screen"); return; }

                }
                else
                {
                    GeneralFunction.Information("AlreadyInvoiceClosed", "POS Screen");
                    //result = false;
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstCurrentSaleStatus = null;
            }
        }
        #endregion

        #region DeleteSale
        public void DeleteSale(DataGridView Dg_Sales)
        {
            objPosBal.objPOSObject.EnableButton = false;
            if (Dg_Sales.BackgroundColor == Color.Gray) return;
            if (Dg_Sales.SelectedRows.Count > 0)
            {
                if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                {
                    if (GeneralFunction.Question("AlertDeleteSelectedRow", "POS Screen") == DialogResult.No) return;
                }
                //if (Dg_Sales.SelectedRows[0].Cells["Price"].Value.ToString() == string.Empty) Obj_PosProp.ItemType = "AdditionalItem";
                //else Obj_PosProp.ItemType = "RegularlItem";
                objPosBal.objPOSObject.ItemID = Convert.ToInt16(Dg_Sales.CurrentRow.Cells["ItemID"].Value);
                objPosBal.objPOSObject.ItemName = Dg_Sales.CurrentRow.Cells["Item"].Value.ToString();
                objPosBal.objPOSObject.SaleId = objPosBal.objPOSObject.SaleId;
                objPosBal.objPOSObject.SaleType = Convert.ToInt16(SalesType.POS);
                objPosBal.objPOSObject.RowID = int.Parse(Dg_Sales.CurrentRow.Cells["Id"].Value.ToString());
                objPosBal.objPOSObject.ItemType = Convert.ToInt16(Dg_Sales.CurrentRow.Cells["ItemType"].Value);
                objPosBal.objPOSObject.ButtonId = Convert.ToInt32(Dg_Sales.CurrentRow.Cells["ButtonID"].Value);
                if (Convert.ToDecimal(Dg_Sales.SelectedRows[0].Cells["Total"].Value) != 0)
                {
                    objPosBal.objPOSObject.NetAmount = (Convert.ToDecimal(Dg_Sales.SelectedRows[0].Cells["Total"].Value) != 0) ? Convert.ToDecimal(Dg_Sales.SelectedRows[0].Cells["Total"].Value) : Convert.ToDecimal(0.000);
                    objPosBal.objPOSObject.ItemPrice = objPosBal.objPOSObject.NetAmount * -1;
                    TaxCalculation();
                    objPosBal.objPOSObject.ItemPrice = Convert.ToDecimal(Dg_Sales.SelectedRows[0].Cells["Total"].Value) * -1;
                    TotalSales();
                }

                objPosBal.objPOSObject.NetAmount += (objPosBal.objPOSObject.ItemTax * -1);
                SplitTax();
                if (DeleteSaleInvoiceDetailsHelper())
                {
                    lstGridItems.RemoveAt(Dg_Sales.CurrentRow.Index);
                }
                //
                if (Dg_Sales.RowCount > 0)
                {
                    int rowindex = Dg_Sales.CurrentRow.Index;
                    for (int i = rowindex + 2; i < lstGridItems.Count; i++)
                    {
                        objPosBal.objPOSObject.ItemName = lstGridItems[i].ItemName;
                        objPosBal.objPOSObject.ItemSno = lstGridItems[i].RowID;
                        objPosBal.objPOSObject.ItemID = lstGridItems[i].ItemID;
                        //objPosBal.objPOSObject.ButtonId = lstGridItems[i].ButtonId;
                        //objPosBal.objPOSObject.ButtonItemId = lstGridItems[i].ButtonItemId;
                        lstGridItems[i].RowID = i;
                        UpdateSerialNohelper();
                    }
                }
                //
                GetSalesDetailsHelper();
                if (Dg_Sales.SelectedRows[0].Cells["Item"].Value != null && Dg_Sales.SelectedRows[0].Cells["Item"].Value.ToString() != "")
                    objPosBal.objPOSObject.EnableButton = true;

                // Dg_Sales.Rows.RemoveAt(Dg_Sales.CurrentRow.Index);
                //FillItems();modified for  asynchronous load of item
                //BindButtonDetails();
                // objLoad.BeginInvoke(loadItemDetails, null);
                //   FocusLastRow();

                //  Txt_Price.Text = "0.000";
                //GetSaleDetails();
            }
            else GeneralFunction.Information("EmptyItemName", "POS Screen");


        }
        #endregion

        #region AdjustSale
        public void AdjustSale(DataGridView Dg_Sales)
        {
            if (Dg_Sales.BackgroundColor == Color.Gray)
            {
                bool FLAG = false;
                FLAG = (UserScreenLimidations.ModifyInvoice);

                if ((UserScreenLimidations.ModifyTodayInvoice) & (FLAG != true))
                {
                    if (DateTime.Compare(Convert.ToDateTime(objPosBal.objPOSObject.PosDate), Convert.ToDateTime(DateTime.Now.ToShortDateString())) != 0)
                    {
                        GeneralFunction.Information("RightsModifyInvoice", "POS Screen");
                        return;
                    }
                }

                if (ModifySaleDetailsHelper())
                {
                    GetSalesDetailsHelper();
                    SplitTax();
                    Dg_Sales.BackgroundColor = Color.NavajoWhite;
                    Dg_Sales.DefaultCellStyle.BackColor = Color.White;
                    Dg_Sales.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region PlusQty
        public void PlusQty(DataGridView Dg_Sales, int CurrentRowIndex)
        {
            int Qty;
            Decimal Price, Total, ItemCost;
            objPosBal.objPOSObject.RegularItemFlag = false;
            List<ItemCardObjectClass> lstItem;
            try
            {

                if (Dg_Sales.BackgroundColor == Color.Gray) return;
                if (Dg_Sales.SelectedRows.Count > 0)
                {
                    //  BindingManagerBase bm = Dg_Sales.BindingContext[Dg_Sales.DataSource, Dg_Sales.DataMember];
                    // DataRowView dr = (DataRowView)bm.Current;
                    int rowindex = CurrentRowIndex;// Dg_Sales.CurrentRow.Index; // Commented on 29-Oct-2104
                    //int rowindex = 0; // Commented on 29-Oct-2104
                    //if (Dg_Sales.SelectedRows.Count > 0)// Commented on 29-Oct-2104
                    //{
                    //    rowindex = Dg_Sales.SelectedRows[0].Index;
                    //}
                    //else
                    //{
                    //    rowindex = Dg_Sales.CurrentRow.Index;
                    //}

                    //if (Convert.ToInt16(dr["Price"]) == 0)
                    //{
                    //    //    string ItemName = Dg_Sales.CurrentRow.Cells[1].Value.ToString();
                    //    //    Qty = int.Parse(dr["Qty"].ToString()) + 1;
                    //    //    Dg_Sales.CurrentRow.Cells[3].Value = Qty;
                    //    //    AssignInvoiceDetails(ItemName, 1, Convert.ToDecimal(0.00), "NI", "AdditionalItem");
                    //}
                    //below line added by Meena.R on 09/24/2015 to fix + - button not working 
                    POSObject selectedobject = (POSObject)Dg_Sales.Rows[CurrentRowIndex].DataBoundItem;//Dg_Sales.CurrentRow.DataBoundItem;
                    rowindex = lstGridItems.FindIndex(a => a.ItemID == selectedobject.ItemID && a.Qty == selectedobject.Qty && a.Price == selectedobject.Price);
                    if (lstGridItems[rowindex].Price == 0)
                    {
                        //    string ItemName = Dg_Sales.CurrentRow.Cells[1].Value.ToString();
                        //    Qty = int.Parse(dr["Qty"].ToString()) + 1;
                        //    Dg_Sales.CurrentRow.Cells[3].Value = Qty;
                        //    AssignInvoiceDetails(ItemName, 1, Convert.ToDecimal(0.00), "NI", "AdditionalItem");
                    }
                    else
                    {
                        objPosBal.objPOSObject.RegularItemFlag = true;
                        lstItem = new List<ItemCardObjectClass>();
                        lstItem = objPosBal.objPOSObject.lstSelectedItemDetails;
                        //
                        if (lstGridItems[rowindex].PackageQty == 0)
                        {
                            lstGridItems[rowindex].PackageQty = 1;
                        }
                        //
                        objPosBal.objPOSObject.ItemID = lstGridItems[rowindex].ItemID;
                        lstItem = (from a in lstItem
                                   where a.ItemId == lstGridItems[rowindex].ItemID
                                   select a).ToList();

                        if (lstItem.Count > 0)
                        {
                            objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;
                            objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                            objPosBal.objPOSObject.PackageQty = lstItem[0].PackageQuantity;
                            IsPackage = lstGridItems[rowindex].Box == 0 ? true : false;
                            objPosBal.objPOSObject.Cost = (!(lstItem[0].ItemCost is DBNull)) ? lstItem[0].AverageCost : Convert.ToDecimal(0.000);

                            if (lstItem[0].ItemType == Convert.ToInt16(ItemType.Goods))
                            {

                                objPosBal.objPOSObject.StockOnHand = GetStockOnItemHelper();
                                if (objPosBal.objPOSObject.StockOnHand < 1)
                                {
                                    objPosBal.objPOSObject.QtyText = string.Empty;
                                    GeneralFunction.Information("There is no item in stock", "POS Screen"); return;
                                }
                            }

                            if (IsPackage)
                            {
                                Qty = lstGridItems[rowindex].Qty + 1;
                                objPosBal.objPOSObject.Box = 0;
                            }
                            else
                            {
                                Qty = lstGridItems[rowindex].Qty + lstGridItems[rowindex].PackageQty;
                                objPosBal.objPOSObject.Box = (Qty / (lstGridItems[rowindex].PackageQty == 0 ? 1 : lstGridItems[rowindex].PackageQty));
                            }
                            Price = lstGridItems[rowindex].Price;
                            if (IsPackage)
                            {
                                if ((Qty % lstGridItems[rowindex].PackageQty) == 0)
                                    Total = (Qty / lstGridItems[rowindex].PackageQty) * lstGridItems[rowindex].ItemPackagePrice;
                                else
                                    Total = Qty * Price;
                            }
                            else
                            {
                                Total = lstGridItems[rowindex].ItemPackagePrice * objPosBal.objPOSObject.Box;
                            }
                            objPosBal.objPOSObject.Cost = (!(lstItem[0].ItemCost is DBNull)) ? lstItem[0].AverageCost : Convert.ToDecimal(0.000);
                            //Dg_Sales.CurrentRow.Cells["Qty"].Value = Qty;
                            //Dg_Sales.CurrentRow.Cells["Total"].Value = Total.ToString("####0.000");

                            lstGridItems[rowindex].Qty = Qty;
                            lstGridItems[rowindex].TotalPrice = Convert.ToDecimal(Total.ToString("####0.000"));
                            lstGridItems[rowindex].Box = objPosBal.objPOSObject.Box;
                            if (IsPackage)
                            {
                                objPosBal.objPOSObject.ItemPrice = Price;
                            }
                            else
                            {
                                objPosBal.objPOSObject.ItemPrice = Price * lstGridItems[rowindex].PackageQty;
                            }
                            TaxCalculation();
                            TotalSales();
                            AssignInvoice(Convert.ToInt16(SalesInvoiceType.NormalInvoice));
                            SplitTax();
                            SaveSaleInvoiceHelper();
                            AssignInvoiceDetails(objPosBal.objPOSObject.ItemID, Qty, Price, Convert.ToInt16(SalesInvoiceType.NormalInvoice), Convert.ToInt16(PosItemType.RegularItem), Convert.ToInt16(Dg_Sales.CurrentRow.Cells["Id"].Value), objPosBal.objPOSObject.Cost, objPosBal.objPOSObject.Box);
                            SaveSaleInvoiceDetailsHelper();
                        }
                    }
                    // FocusLastRow();
                    //GetSaleDetails();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstItem = null;
            }


        }
        #endregion

        #region MinusQty
        public void MinusQty(DataGridView Dg_Sales, int CurrentRowIndex)
        {
            int Qty;
            Decimal Price, Total, ItemCost;
            objPosBal.objPOSObject.RegularItemFlag = false;
            objPosBal.objPOSObject.DeleteItemFlag = false;
            List<ItemCardObjectClass> lstItem;
            try
            {
                if (Dg_Sales.BackgroundColor == Color.Gray) return;
                if (Dg_Sales.SelectedRows.Count > 0)
                {

                    // BindingManagerBase bm = Dg_Sales.BindingContext[Dg_Sales.DataSource, Dg_Sales.DataMember];
                    //  DataRowView dr = (DataRowView)bm.Current;
                    int rowindex = CurrentRowIndex;// Dg_Sales.CurrentRow.Index;
                    POSObject selectedobject = (POSObject)Dg_Sales.Rows[CurrentRowIndex].DataBoundItem; //Dg_Sales.CurrentRow.DataBoundItem;
                    rowindex = lstGridItems.FindIndex(a => a.ItemID == selectedobject.ItemID && a.Qty == selectedobject.Qty && a.Price == selectedobject.Price);
                    string ItemName = Dg_Sales.Rows[CurrentRowIndex].Cells["Item"].Value.ToString();
                    if (lstGridItems[rowindex].Price == 0)
                    {
                        //    string ItemName = Dg_Sales.CurrentRow.Cells[1].Value.ToString();
                        //    Qty = int.Parse(dr["Qty"].ToString()) + 1;
                        //    Dg_Sales.CurrentRow.Cells[3].Value = Qty;
                        //    AssignInvoiceDetails(ItemName, 1, Convert.ToDecimal(0.00), "NI", "AdditionalItem");
                    }
                    else
                    {
                        objPosBal.objPOSObject.RegularItemFlag = true;
                        lstItem = new List<ItemCardObjectClass>();
                        //
                        if (lstGridItems[rowindex].PackageQty == 0)
                        {
                            lstGridItems[rowindex].PackageQty = 1;
                        }
                        //
                        lstItem = objPosBal.objPOSObject.lstSelectedItemDetails;
                        objPosBal.objPOSObject.ItemID = lstGridItems[rowindex].ItemID;
                        lstItem = (from a in lstItem
                                   where a.ItemId == lstGridItems[rowindex].ItemID
                                   select a).ToList();
                        if (lstItem.Count <= 0)
                        {
                            ItemCardObjectClass ObjItem = new ItemCardObjectClass();
                            ObjItem = AllItems.Where(a => a.ItemId == objPosBal.objPOSObject.ItemID && a.PackageQuantity == lstGridItems[rowindex].PackageQty).FirstOrDefault();
                            if (ObjItem != null)
                            {
                                lstItem.Add(ObjItem);
                            }
                        }
                        if (lstItem.Count > 0)
                        {
                            objPosBal.objPOSObject.ItemPackagePrice = lstItem[0].Price;
                            objPosBal.objPOSObject.Price = GetPrice(lstItem[0].Price, lstItem[0].PackageQuantity);
                            objPosBal.objPOSObject.PackageQty = lstItem[0].PackageQuantity;
                            IsPackage = lstGridItems[rowindex].Box == 0 ? true : false;
                            objPosBal.objPOSObject.Cost = (!(lstItem[0].ItemCost is DBNull)) ? lstItem[0].AverageCost : Convert.ToDecimal(0.000);

                            //if (lstItem[0].ItemType == Convert.ToInt16(ItemType.Goods))
                            //{

                            //}
                            if (IsPackage)
                            {
                                Qty = lstGridItems[rowindex].Qty - 1;
                                objPosBal.objPOSObject.Box = 0;
                            }
                            else
                            {
                                Qty = lstGridItems[rowindex].Qty - lstGridItems[rowindex].PackageQty;
                                objPosBal.objPOSObject.Box = (Qty / (lstGridItems[rowindex].PackageQty == 0 ? 1 : lstGridItems[rowindex].PackageQty));
                            }

                            Price = lstGridItems[rowindex].Price;
                            if (IsPackage)
                            {
                                if ((Qty % lstGridItems[rowindex].PackageQty) == 0)
                                    Total = (Qty / lstGridItems[rowindex].PackageQty) * lstGridItems[rowindex].ItemPackagePrice;
                                else
                                    Total = Qty * Price;
                            }
                            else
                            {
                                Total = lstGridItems[rowindex].ItemPackagePrice * objPosBal.objPOSObject.Box;
                            }

                            objPosBal.objPOSObject.Cost = (!(lstItem[0].ItemCost is DBNull)) ? lstItem[0].AverageCost : Convert.ToDecimal(0.000);
                            AssignInvoiceDetails(objPosBal.objPOSObject.ItemID, Qty, Price, Convert.ToInt16(SalesInvoiceType.NormalInvoice), Convert.ToInt16(PosItemType.RegularItem), Convert.ToInt16(Dg_Sales.CurrentRow.Cells["Id"].Value), objPosBal.objPOSObject.Cost, objPosBal.objPOSObject.Box);
                            if (IsPackage)
                            {
                                objPosBal.objPOSObject.ItemPrice = Price * -1;
                            }
                            else
                            {
                                objPosBal.objPOSObject.ItemPrice = Price * -(lstGridItems[rowindex].PackageQty);
                            }
                            TaxCalculation();
                            TotalSales();
                            SplitTax();
                            if (Qty != 0)
                            {
                                //Dg_Sales.CurrentRow.Cells["Qty"].Value = Qty;
                                //Dg_Sales.CurrentRow.Cells["Total"].Value = Total.ToString("####0.000");
                                lstGridItems[rowindex].Qty = Qty;
                                lstGridItems[rowindex].TotalPrice = Convert.ToDecimal(Total.ToString("####0.000"));
                                lstGridItems[rowindex].Box = objPosBal.objPOSObject.Box;
                                AssignInvoice(Convert.ToInt16(SalesInvoiceType.NormalInvoice));
                                SaveSaleInvoiceHelper();
                                SaveSaleInvoiceDetailsHelper();

                            }
                            else
                            {
                                objPosBal.objPOSObject.DeleteItemFlag = true;
                                objPosBal.objPOSObject.NetAmount = (Convert.ToInt16(Dg_Sales.SelectedRows[0].Cells["Total"].Value) != 0 && Dg_Sales.SelectedRows[0].Cells["Total"].Value.ToString() != "-") ? Convert.ToDecimal(Dg_Sales.SelectedRows[0].Cells["Total"].Value.ToString()) : Convert.ToDecimal(0.000);
                                objPosBal.objPOSObject.NetAmount += (objPosBal.objPOSObject.ItemTax * -1);
                                objPosBal.objPOSObject.ItemName = ItemName;
                                objPosBal.objPOSObject.SaleType = Convert.ToInt16(SalesType.POS);
                                objPosBal.objPOSObject.ItemType = Convert.ToInt16(PosItemType.RegularItem);
                                objPosBal.objPOSObject.RowID = Convert.ToInt16(Dg_Sales.SelectedRows[0].Cells["Id"].Value);
                                DeleteSaleInvoiceDetailsHelper();
                                Index = CurrentRowIndex;// Dg_Sales.CurrentRow.Index;
                                lstGridItems.RemoveAt(Index);
                                // dr.Delete();

                            }

                        }
                    }
                    // FocusLastRow();
                    //GetSaleDetails();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstItem = null;
            }


        }
        #endregion

        #region EnterItem
        public void EnterItem(DataGridView Dg_Sales)
        {

            objPosBal.objPOSObject.QtyGreaterZero = false;
            if (objPosBal.objPOSObject.ItemSelectedIndex != -1)
            {
                if (objPosBal.objPOSObject.CurrentQty != 0 && objPosBal.objPOSObject.CurrentQty > 0)
                {
                    objPosBal.objPOSObject.QtyGreaterZero = true;
                    objPOSScreenBal.objPOSObject.AdditionFlag = 0;
                    AddGridSaleDetails(Dg_Sales);
                    IsItemSaveInGrid = true;
                }
                else
                {
                    objPosBal.objPOSObject.QtyGreaterZero = false;
                    GeneralFunction.Information("ZeroQty", "POS Screen");

                }
            }
            else
            {
                GeneralFunction.Information("NoIteminInvoice", "POS Screen");
            }

        }

        #endregion

        #region NavigationEvent
        public void NavigationEvent()
        {
            ID = GetPOSIDHelper();
            int IdIndex = 0;
            int MaxIDIndex = ID.Count - 1;
            int MinIDIndex = 0;
            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    //objSaleInvoiceBAL.objSaleObject.saleinv = ID[0];
                    IdIndex = IdIndex;

                    break;
                case InvoiceFlag.Next:
                    if (objPosBal.objPOSObject.SaleId != ID[MaxIDIndex])
                    {
                        IdIndex = ID.IndexOf(objPosBal.objPOSObject.SaleId);
                        IdIndex = IdIndex + 1;
                        //Index = ID.FindIndex(objPosBal.objPOSObject.SaleId);
                        //objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.saleinv + 1;

                    }
                    else
                    {
                        //  objSaleInvoiceBAL.objSaleObject.saleinv = ID[1];
                        IdIndex = MaxIDIndex;
                    }
                    break;
                case InvoiceFlag.Last:
                    //objSaleInvoiceBAL.objSaleObject.saleinv = ID[MaxIDIndex];
                    IdIndex = MaxIDIndex;
                    break;
                case InvoiceFlag.Previous:
                    if (objPosBal.objPOSObject.SaleId != ID[0])
                    {
                        IdIndex = ID.IndexOf(objPosBal.objPOSObject.SaleId);
                        IdIndex = IdIndex - 1;
                        // objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.saleinv - 1;

                    }
                    else
                    {
                        // objSaleInvoiceBAL.objSaleObject.saleinv = ID[0];
                        IdIndex = 0;
                    }
                    break;
                default:
                    //  objPosBal.objPOSObject.SaleId = Convert.ToInt64(objSaleInvoiceBAL.GetPurInvIDBasedOnNewYearID());
                    break;
            }

            objPosBal.objPOSObject.SaleId = ID[IdIndex];

        }
        #endregion

        #region ReceiveReceipt
        public void ReceiveReceipt(DataGridView Dg_Sales)
        {
            GetSalesDetailsHelper();
            if (dicSalesDetails["Sales"].Count > 0)
            {
                if (Dg_Sales.BackgroundColor == Color.Gray)
                {
                    Receive_Receipt ObjFrm = new Receive_Receipt();
                    ObjFrm.Tag = "POS";
                    //ObjFrm.Description = "POSInvoice " + objPosBal.objPOSObject.SaleId; Changed By Meena.R on 27/11/2014 description mismatch
                    ObjFrm.Description = "POSInvoice " + objPosBal.objPOSObject.NewInvoiceNoText;
                    ObjFrm.ReceiptNo = objPosBal.objPOSObject.SaleId;
                    ObjFrm.ReceivedFrom = objPosBal.objPOSObject.CmbClientText;
                    if (objPosBal.objPOSObject.ClientID.ToString() != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
                        ObjFrm.Value = objPosBal.objPOSObject.PaidText == "0.000" ? Convert.ToDecimal((objPosBal.objPOSObject.TotalText != string.Empty) ? objPosBal.objPOSObject.TotalText : "0.000").ToString("####0.000") : Convert.ToDecimal((objPosBal.objPOSObject.PaidText != string.Empty) ? objPosBal.objPOSObject.PaidText : "0.000").ToString("####0.000");
                    else
                        ObjFrm.Value = Convert.ToDecimal((objPosBal.objPOSObject.TotalText != string.Empty) ? objPosBal.objPOSObject.TotalText : "0.000").ToString("####0.000");
                    //ObjFrm.txt_Balance.Text = Convert.ToDecimal((Txt_Refund.Text != string.Empty) ? Txt_Refund.Text : "0.000").ToString("####0.000");
                    ObjFrm.NetAmt = (objPosBal.objPOSObject.TotalText != string.Empty) ? objPosBal.objPOSObject.TotalText : "0.000";
                    ObjFrm.ShowDialog();
                    GetSalesDetailsHelper();

                }
                else { GeneralFunction.Information("CloseInvoice", "POS Screen"); }
            }
        }
        #endregion

        #region Print
        public void Print(DataGridView Dg_Sales)
        {

            ReportsView frmView = new ReportsView();
            CurrencyConverter ObjCC = new CurrencyConverter();
            //Rpt_Receipt1 summery = new Rpt_Receipt1();
            Rpt_Receipt3 summery = new Rpt_Receipt3();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("Receipt");
            DataTable dt = new DataTable("SimpleInvoice");
            dt = objPosBal.GetPOSPrintReportBal();
            // Added on 11-Mar-2019 bt T
            string AgentName = "";
            string AgentID = "";
            if (dt.Rows.Count > 0)
            {
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["AgentID"].ToString());
                GeneralFunction.AgentDept();
                AgentName = dt.Rows[0]["AgentName"].ToString();
                AgentID = dt.Rows[0]["AgentID"].ToString();
            }
            //
            // Committ on 28-Dec-2018 // UnCommit this code on 05-April-2019 By T
            if ((GeneralOptionSetting.FlagPosCategoryVicePrint == "Y") ? true : false)
            {
                if (!IsNotPrintKitchenReceipt)
                {
                    //string defaultPrint = WindowsPrinter.GetDefaultPrinter();
                    CategoryBasePrinter(dt);/////////Call the method for category wise printer on 30 july 2014
                                            // WindowsPrinter.SetDefaultPrinter(defaultPrint);
                    if (IsForKitchentSlip)
                    {
                        IsForKitchentSlip = false;
                        return;
                    }
                }
                else { IsNotPrintKitchenReceipt = false; }
            }
            //
            frmView.HTable.Clear();
            decimal Total = 0.000M;
            if (dt == null || dt.Rows.Count <= 0)
            {
                GeneralFunction.Information("NoRecordsFound", "POS Screen");
                return;
            }

            DataTable dtAttend = CommonHelper.ConvertionHelper.ConvertToDataTable<POSObject>(lstGridItems);
            // DataTable dtAtten = CommonHelper.ConvertionHelper.ConvertToDataTable<POSObject>((List<POSObject>)Dg_Sales.DataSource);
            DataView dv = new DataView(dtAttend);
            //  dv.RowFilter = "Qty <>'-'";
            DataTable dtGetTotal = dv.ToTable();
            DataColumn dc = new DataColumn("Qty1", typeof(int));
            dc.Expression = "Qty";
            dtGetTotal.Columns.Add(dc);
            object objTotalQty = dtGetTotal.Compute("sum(Qty1)", string.Empty);

            DataTable dtLocal = new DataTable("SimpleInvoice");
            if (dtLocal.Columns.Count < 19)
            {
                dtLocal.Columns.Add("Id");
                dtLocal.Columns.Add("ItemName");
                dtLocal.Columns.Add("Price");
                dtLocal.Columns.Add("Qty");
                dtLocal.Columns.Add("Total", typeof(decimal));
                dtLocal.Columns.Add("Category");
                dtLocal.Columns.Add("PaymentCharges", typeof(decimal));

            }

            for (int i = 0; i < dtGetTotal.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();
                //drAdd["Id"] = "0";
                drAdd["Id"] = dt.Rows[0]["ReceiptNo"].ToString();
                drAdd["ItemName"] = dtGetTotal.Rows[i]["ItemName"].ToString();
                drAdd["Price"] = Convert.ToDecimal(dtGetTotal.Rows[i]["Price"]).ToString("#######0.000");
                drAdd["Qty"] = dtGetTotal.Rows[i]["Qty"].ToString();
                drAdd["Total"] = Convert.ToDecimal(Convert.ToDecimal(dtGetTotal.Rows[i]["Qty"]) * Convert.ToDecimal(dtGetTotal.Rows[i]["Price"]));
                // drAdd["Category"] = "";
                drAdd["Category"] = dtGetTotal.Rows[i]["CategoryName"].ToString();
                drAdd["PaymentCharges"] = Convert.ToDecimal(dtGetTotal.Rows[i]["PaymentCharges"]);
                dtLocal.Rows.Add(drAdd);

            }

            decimal grandTotal = 0.000M;
            grandTotal = (objPOSScreenBal.objPOSObject.TotalText != string.Empty ? decimal.Parse(objPOSScreenBal.objPOSObject.TotalText) : 0.000M) - (objPOSScreenBal.objPOSObject.TaxText != string.Empty ? decimal.Parse(objPOSScreenBal.objPOSObject.TaxText) : 0.000M) - (objPOSScreenBal.objPOSObject.PaymentCharges);
            frmView.HTable.Add("UserNote", GeneralOptionSetting.FlagNoteSaleInvoice);
            frmView.HTable.Add("CompanyName", GeneralOptionSetting.FlagCompanyName);
            frmView.HTable.Add("GrandTotal", grandTotal.ToString("######0.000"));
            frmView.HTable.Add("Tax", objPOSScreenBal.objPOSObject.TaxText);
            frmView.HTable.Add("NetAmt", objPOSScreenBal.objPOSObject.TotalText);
            frmView.HTable.Add("PaidAmount", objPOSScreenBal.objPOSObject.PaidText);
            frmView.HTable.Add("Refund", objPOSScreenBal.objPOSObject.RefundText);
            frmView.HTable.Add("OrderNo", dt.Rows[0]["OrderNo"].ToString());
            //frmView.HTable.Add("ReceiptNo", dt.Rows[0]["ReceiptNo"].ToString());
            frmView.HTable.Add("ReceiptNo", "P" + dt.Rows[0]["NewYearNo"].ToString());//Changed on 03mar2015
            frmView.HTable.Add("CashierName", dt.Rows[0]["UserID"].ToString());
            frmView.HTable.Add("CashierNo", dt.Rows[0]["CreatedBy"].ToString());

            // Due to client request we disable this option in the Receipt print Total hide done by Praba on 03-Oct-2014
            frmView.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? Convert.ToInt32(objTotalQty).ToString() : string.Empty);
            //frmView.HTable.Add("TotalSold", objTotalQty.ToString());

            //frmView.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? objTotalQty.ToString() : string.Empty);
            //frmView.HTable.Add("TotalSold",  objTotalQty.ToString());

            frmView.HTable.Add("IsLogo", GeneralOptionSetting.HeaderLogo.Length > 1);
            frmView.HTable.Add("IncludeTax", GeneralOptionSetting.FlagHideTaxFiled == "Y" ? true : false);
            if (string.IsNullOrEmpty(dt.Rows[0]["PaymentCharges"].ToString()))
            {
                frmView.HTable.Add("PaymentCharges", "0.000");
            }
            else
            {
                frmView.HTable.Add("PaymentCharges", dt.Rows[0]["PaymentCharges"].ToString());

            }
            if (AgentID != "1001")
            {
                frmView.HTable.Add("TotalDept", GeneralFunction.ClientDebt);
                frmView.HTable.Add("CashClientName", GeneralFunction.ChangeLanguageforCustomMsg("ClientName") + " : " + AgentName);
                frmView.HTable.Add("TotalDeptLbl", GeneralFunction.ChangeLanguageforCustomMsg("TotalDebt"));
            }
            else
            {
                if (!PrintPreview)
                {
                    frmView.HTable.Add("TotalDept", "");
                    frmView.HTable.Add("CashClientName", "");
                    frmView.HTable.Add("TotalDeptLbl", "");
                }
                else if (GeneralFunction.CashClientName != string.Empty)
                {
                    frmView.HTable.Add("TotalDept", "");
                    frmView.HTable.Add("CashClientName", GeneralFunction.CashClientName + ":" + GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name"));
                    frmView.HTable.Add("TotalDeptLbl", "");
                }
                else
                {
                    frmView.HTable.Add("TotalDept", "");
                    frmView.HTable.Add("CashClientName", "Cash Client" + ":" + GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name"));
                    frmView.HTable.Add("TotalDeptLbl", "");
                }
            }
            string TableNo = dt.Rows[0]["ItemType"].ToString();
            frmView.HTable.Add("TableNo", TableNo);
            DataTable dtReceipt = new DataTable();
            //  FillGrid(Txt_InvoiceNo.Text);
            dtReceipt.Merge(dtLocal);
            dtReceipt.TableName = "Receipt";
            //HideOptioninReport(summery);

            frmView.Report_Table = GeneralFunction.SortInvoiceDetails(dtReceipt, "ItemName", "Price");
            frmView.RptDoc = summery;
            FieldObject field;
            field = frmView.RptDoc.ReportDefinition.Sections["ReportHeaderLogo"].ReportObjects["objCompanyName"] as FieldObject;
            Font font = new System.Drawing.Font("Al-Kharashi 3", field.Font.Size, FontStyle.Bold);
            field.ApplyFont(font);
            ReportDocument rpt = summery;
            GeneralFunction.PosPrint = true;
            Tables tbl = rpt.Database.Tables;
            frmView.Repnum = tbl;
            frmView.CompLogo = false;
            frmView.isReportFooter = false;
            //frmView.isSubReport = (GeneralOptionSetting.FlagPosCategoryVicePrint == "Y") ? true : false;//commended on 22Aug2014 By Meena.R
            frmView.LoadEvent();
            if (PrintPreview)
            {
                frmView.ShowDialog();
            }
            else
            {
                try
                {
                    // Printer Setup Handling Add these Lines
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = GeneralFunction.PrinterName("POS");
                    printerSettings.Copies = Convert.ToInt16(GeneralFunction.NoofReceiptPrint);
                    frmView.RptDoc.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(100, 250, 100, 250));
                    summery.PrintToPrinter(printerSettings, new PageSettings(), false);
                    // 

                    //frmView.RptDoc.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(100, 250, 100, 250));
                    //summery.PrintToPrinter(GeneralFunction.NoofReceiptPrint, true, 0, 0);
                    summery.Close();
                    summery.Dispose();
                    summery = null;
                    // Added on 28-Dec-2018 // Comment this Code on 05-April-2019 By T 
                    //if ((GeneralOptionSetting.FlagPosCategoryVicePrint == "Y") ? true : false)
                    //{
                    //    //string defaultPrint = WindowsPrinter.GetDefaultPrinter();
                    //    CategoryBasePrinter(dt);//////Call the method for category wise printer on 30 july 2014
                    //                            // WindowsPrinter.SetDefaultPrinter(defaultPrint);
                    //}
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.StackTrace);
                    MessageBox.Show(exe.Message);
                    GeneralFunction.ErrInfo("Configure the printer", "POSScreen");
                }
                finally
                {
                    GeneralFunction.PosPrint = false;
                }
            }

        }
        /// <summary>
        /// method for to print the category based item  on 30 july 2014
        /// </summary>
        /// <param name="DVOfItem"></param>
        private void CategoryBasePrinter(DataTable TableOfTransactionItem)
        {
            ReportsView reportview = new ReportsView();
            Rpt_CategoryBasePrinter categorybaseprinter = new Rpt_CategoryBasePrinter();
            reportview.HTable.Clear();
            //string TableNo = TableOfTransactionItem.Rows.Count > 0 ? Additional_Barcode.GetValueByResourceKey("T") + " : " + TableOfTransactionItem.Rows[0]["TableNo"].ToString() : "";
            //reportview.HTable.Add("TableNo", TableNo);
            reportview.RptDoc = categorybaseprinter;
            reportview.SetLanguageForReport();

            List<string> CheckPrinter = new List<string>();
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                CheckPrinter.Add(strPrinter);

            }

            if (!PrintAllItemInKitchenReceipt)
            {
                for (int i = 0; i < KitchenReciptRemainingQuantity.Rows.Count; i++)
                {
                    long UniqueID = Convert.ToInt64(KitchenReciptRemainingQuantity.Rows[i]["UniqueID"]);
                    int QuantityPrint = Convert.ToInt32(KitchenReciptRemainingQuantity.Rows[i]["QuantityToPrint"]);
                    for (int j = 0; j < TableOfTransactionItem.Rows.Count; j++)
                    {
                        if (Convert.ToInt64(TableOfTransactionItem.Rows[j]["UniqueID"]) == UniqueID)
                        {
                            TableOfTransactionItem.Rows[j]["Qty"] = QuantityPrint;
                            TableOfTransactionItem.Rows[j]["IsItemPrint"] = false;
                            break;
                        }
                    }

                }
            }

            DataView dv = new DataView(TableOfTransactionItem);

            DataTable distinctValues = new DataTable();
            distinctValues = dv.ToTable(true, "Printer");
            string catValue = string.Empty;
            var cat = dv.ToTable(true, "CategoryID");
            foreach (DataRow item in cat.Rows)
            {
                catValue = item.ItemArray[0].ToString();
            }


            foreach (DataRow row in distinctValues.Rows)
            {
                ItemBasePrinter = row.ItemArray[0].ToString();
                if (catValue == "1001" && ItemBasePrinter == string.Empty)
                {
                    var printerName = CommonFunction.GetDefaultPrinter();
                    PrintCategory(categorybaseprinter, dv, catValue, printerName);
                }
                else
                {
                    foreach (var item in CheckPrinter)
                    {
                        if (ItemBasePrinter.ToLower() == item.ToString().ToLower())
                        {
                            PrintCategory(categorybaseprinter, dv, item, ItemBasePrinter);
                        }

                    }
                }
            }
        }
        private void PrintCategory(Rpt_CategoryBasePrinter categorybaseprinter, DataView dv, string item, string printerName)
        {
            ReportDocument reportdocument = new ReportDocument();

            DataTable tableofprinterbaseItem = new DataTable();
            if (item == "1001")
            {
                dv.RowFilter = "CategoryID='" + item + "'";
            }
            else
            {
                dv.RowFilter = "Printer='" + item + "'";
            }
            if (!PrintAllItemInKitchenReceipt)
            {
                dv.RowFilter = "IsItemPrint = 0";
            }
            tableofprinterbaseItem = dv.ToTable("Receipt");
            reportdocument = categorybaseprinter;
            reportdocument.SetDataSource(tableofprinterbaseItem);
            reportdocument.PrintOptions.PrinterName = printerName;
            //MessageBox.Show(reportdocument.PrintOptions.PrinterName); 
            //WindowsPrinter.SetDefaultPrinter(ItemBasePrinter); 
            //reportdocument.PrintToPrinter(1, true, 0, 0); 
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
            printerSettings.PrinterName = printerName;
            reportdocument.PrintToPrinter(printerSettings, new PageSettings(), false);
            reportdocument.Close();
            reportdocument.Dispose();
            reportdocument = null;
            //categorybaseprinter.PrintOptions.PrinterName = ItemBasePrinter; 
            //categorybaseprinter.PrintToPrinter(1, true, 0, 0); 
            PrintAllItemInKitchenReceipt = false;
        }


        #endregion

        #region HideOptioninReport
        void HideOptioninReport(ReportDocument RptDoc)
        {
            CrystalDecisions.CrystalReports.Engine.ReportObject objTax = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_TaxColon"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Tax = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Tax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject objPaid = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_PaidColon"];
            CrystalDecisions.CrystalReports.Engine.ReportObject PaidAmt = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["PaidAmt"];
            CrystalDecisions.CrystalReports.Engine.ReportObject objRefund = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_RefundColon"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Refund = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Refund"];
            CrystalDecisions.CrystalReports.Engine.ReportObject objNet = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_NetColon"];
            CrystalDecisions.CrystalReports.Engine.ReportObject NetAmt = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["NetAmt"];

            CrystalDecisions.CrystalReports.Engine.ReportObject CompLogo = RptDoc.ReportDefinition.Sections["ReportHeaderLogo"].ReportObjects["objCompanyLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject CompName = RptDoc.ReportDefinition.Sections["ReportHeaderLogo"].ReportObjects["objCompanyName"];
            CrystalDecisions.CrystalReports.Engine.Section AddressFooter = RptDoc.ReportDefinition.Sections["ReportFooterAddress"];
            if (GeneralOptionSetting.FlagHideTaxFiled == "Y")
            {
                objTax.ObjectFormat.EnableSuppress = Tax.ObjectFormat.EnableSuppress = true;
                objRefund.Top = objPaid.Top;
                Refund.Top = PaidAmt.Top;
                objPaid.Top = objNet.Top;
                PaidAmt.Top = NetAmt.Top;
                objNet.Top = objTax.Top;
                NetAmt.Top = Tax.Top;
            }
            if (GeneralOptionSetting.FlagShowCompanyNameOnly == "Y")
            {
                if (AddressFooter != null) AddressFooter.SectionFormat.EnableSuppress = true;
                if (CompLogo != null) CompLogo.Height = 0;
                if (CompName != null)
                {
                    CompName.Width += CompLogo.Width;
                    CompName.Left = 75;
                }
            }

        }
        #endregion

        #region BoxFunction
        private void BoxFunction()
        {
            List<ItemCardObjectClass> BoxPiece = new List<ItemCardObjectClass>();
            BoxPiece = objPosBal.objPOSObject.lstSelectedItemDetails;
            BoxPiece = (from a in BoxPiece
                        where a.ItemId == objPosBal.objPOSObject.ItemID
                        select a).ToList();
            if (BoxPiece.Count > 0)
            {
                objPosBal.objPOSObject.ItemPackagePrice = BoxPiece[0].Price;
                objPosBal.objPOSObject.Price = GetPrice(BoxPiece[0].Price, BoxPiece[0].PackageQuantity);

                objPosBal.objPOSObject.Cost = (!(BoxPiece[0].ItemCost is DBNull)) ? BoxPiece[0].AverageCost : Convert.ToDecimal(0.000);
            }

        }
        #endregion

        #region PieceFunction
        private void PieceFunction()
        {

        }
        #endregion

        #region TableButtonClick
        public long TableButtonClick()
        {
            long SaleID = 0;
            GeneralFunction.IsTableSelected = false;
            GeneralFunction.TableShortCut = 0;
            TablePOS ObjTablePos = new TablePOS();
            ObjTablePos.ShowDialog();

            if (GeneralFunction.IsTableSelected)
            {
                if (GeneralFunction.TableShortCut > 0)
                {
                    objPosBal.objPOSObject.ShortCut = GeneralFunction.TableShortCut;
                    SaleID = GetSaleIDForTableHelper();
                }
            }
            return SaleID;
        }
        #endregion

        #region GetPackage
        public List<POSObject> PackageQty(decimal i_Price = 0)
        {
            Package = new List<POSObject>();
            return Package = objPosBal.GetPackageQty(i_Price);
        }
        #endregion

        public void GetAllItemDetails(int itemId)
        {
            AllItems = objPosBal.GetHoleItem(itemId);
        }

        public void GetPOSItems()
        {
            DtPOSItem = objPosBal.GetPOSItems();
        }

        public bool ShowPricePopup(int i, int bi)
        {
            return objPosBal.ShowPricePopup(i, bi);
        }

        public int GetButtonItemId(string buttontxt)
        {
            return objPosBal.GetButtonItemId(buttontxt);
        }

        #endregion

        private void savePosUsingPaidRefundForm(DataGridView Dg_Sales)
        {
            #region with refund_form
            Paid_Refund objPaidRefund = new Paid_Refund();
            objPaidRefund.Txt_Total.Text = (objPosBal.objPOSObject.TotalText != string.Empty) ? Convert.ToDecimal(objPosBal.objPOSObject.TotalText).ToString("####0.000") : "0.000";
            objPaidRefund.Txt_Paid.Select();
            objPaidRefund.Txt_Paid.Focus();
            objPaidRefund.clientID = objPOSScreenBal.objPOSObject.ClientID.ToString();
            objPaidRefund.Tag = objPOSScreenBal.objPOSObject.SaleId;
            objPaidRefund.ShowDialog();
            objPosBal.objPOSObject.BtnReceiptEnabled = true;// Added on 19-May-2014
            if (objPaidRefund.DialogResult != DialogResult.Cancel)
            {
                objPosBal.objPOSObject.DialogueResultOK = true;
                objPosBal.objPOSObject.PaidText = GeneralFunction.Paid.ToString("####0.000");//
                objPosBal.objPOSObject.RefundText = GeneralFunction.Refund.ToString("####0.000");//
                AssignInvoice(Convert.ToInt16(SalesInvoiceType.ClosedInvoice));
                if (objPOSScreenBal.objPOSObject.ClientID.ToString() == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
                {
                    objPosBal.objPOSObject.BtnReceiptEnabled = false;//
                    if (POS_Screen.selectedPaymentType != "check")
                        if (!AddReceipt()) return;
                }
                if (SaveSaleInvoiceHelper())
                {
                    Dg_Sales.BackgroundColor = Color.Gray;
                    Dg_Sales.DefaultCellStyle.BackColor = Color.Gainsboro;
                    Dg_Sales.ForeColor = Color.Red;
                    PrintReceipt = true;
                    //*****Need to implement following functionlity for Printing report*****
                    //if (Chk_Printpreview.Checked)
                    //{
                    //    Receipt();
                    //}
                    // GeneralFunction.OpenCashDrawer();
                    //*****Need to implement above functionlity for Printing report*****
                }

            }
            #endregion
        }

        private void savePosWithoutUsingPaidRefundForm(DataGridView Dg_Sales)
        {
            #region without refund_form
            objPosBal.objPOSObject.DialogueResultOK = true;
            objPosBal.objPOSObject.BtnReceiptEnabled = true;
            if (objPOSScreenBal.objPOSObject.ClientID.ToString() == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
            {
                GeneralFunction.Paid = (objPosBal.objPOSObject.TotalText != string.Empty) ? Convert.ToDecimal(objPosBal.objPOSObject.TotalText.ToString()) + objPosBal.objPOSObject.PaymentCharges : 0;
                GeneralFunction.Refund = 0;
                objPosBal.objPOSObject.PaidText = GeneralFunction.Paid.ToString("####0.000");
                objPosBal.objPOSObject.RefundText = GeneralFunction.Refund.ToString("####0.000");
                objPosBal.objPOSObject.BtnReceiptEnabled = false;//
                AssignInvoice(Convert.ToInt16(SalesInvoiceType.ClosedInvoice));
                if (POS_Screen.selectedPaymentType != "check")
                    if (!AddReceipt()) return;
            }
            else
            {
                AssignInvoice(Convert.ToInt16(SalesInvoiceType.ClosedInvoice));
            }
            if (SaveSaleInvoiceHelper())
            {
                Dg_Sales.BackgroundColor = Color.Gray;
                Dg_Sales.DefaultCellStyle.BackColor = Color.Gainsboro;
                Dg_Sales.ForeColor = Color.Red;
                PrintReceipt = true;
                //*****Need to implement following functionlity for Printing report*****
                //if (Chk_Printpreview.Checked)
                //{
                //    Receipt();
                //}
                // GeneralFunction.OpenCashDrawer();
                //*****Need to implement above functionlity for Printing report*****
            }
            #endregion
        }

        public void GetMultiPrice()
        {
            try
            {
                lstAllPrices = objPosBal.GetItemMinPriceBal();
                int Package = 1;
                float ModPrice = 0.0f;
                float Price = 0.0f;
                if (lstAllPrices.Count > 0)
                {

                    switch (PriceType)
                    {
                        case "NormalPrice":

                            Price = float.Parse(lstAllPrices[0].ItemPrice.ToString());

                            break;

                        case "MinimumPrice":

                            if (lstAllPrices[0].ItemMinimumPrice.ToString() != "")
                            {

                                Price = float.Parse(lstAllPrices[0].ItemMinimumPrice.ToString());

                            }

                            break;

                        case "WholeSalePrice":

                            if (lstAllPrices[0].ItemWholeSalePrice.ToString() != "")
                            {

                                Price = float.Parse(lstAllPrices[0].ItemWholeSalePrice.ToString());

                            }

                            break;

                        default:
                            break;
                    }

                    string RoundPrice = ((Math.Truncate(Convert.ToDecimal(Price) * 1000M) / 1000M)).ToString("#####0.000");
                    Package = (lstAllPrices[0].ItemPackage != 0 ? lstAllPrices[0].ItemPackage : 1);
                    ModPrice = (Price / Package);
                    // objSaleInvoiceBAL.objSaleObject.PriceText = ModPrice.ToString("#####0.000"); // Commented on 16/May-2014
                    //objSaleInvoiceBAL.objSaleObject.BoxPrice = Price; // Commented on 16/May-2014
                    objPosBal.objPOSObject.Price = (Math.Truncate(Convert.ToDecimal(ModPrice) * 1000M) / 1000M);
                    objPosBal.objPOSObject.ItemPackagePrice = Convert.ToDecimal(RoundPrice);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<POSObject> SortInvoiceDetails(List<POSObject> lstInvDetail, string ItemColumnName, string PriceColumnName)
        {
            try
            {

                switch (GeneralOptionSetting.FlagItemSorting)
                {
                    case "0":
                        // dt.DefaultView.Sort = ItemColumnName;
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "asc");
                        break;
                    case "1":
                        //dt.DefaultView.Sort = ItemColumnName + " " + "desc";
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "desc");
                        break;
                    case "4":
                        // dt.DefaultView.Sort = PriceColumnName;
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "asc");
                        break;
                    case "3":
                        //dt.DefaultView.Sort = PriceColumnName + " " + "desc";
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "desc");
                        break;
                    default:
                        return lstInvDetail;
                }
                return lstInvDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<POSObject> SortInvoiceDetailsBal(List<POSObject> lstInvDetail, string SortColumnName, string SortOrder)
        {

            switch (SortOrder)
            {
                case "asc":
                    if (SortColumnName == "ItemName")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemName ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "Price" || SortColumnName == "unitprice")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.Price ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    break;
                case "desc":
                    if (SortColumnName == "ItemName")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemName descending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "Price" || SortColumnName == "unitprice")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.Price descending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    break;

                default:
                    return lstInvDetail;
            }


            return lstInvDetail;

        }

        public float GetDiscountForAgentHelper()
        {
            return objPOSScreenBal.GetDiscountForAgentBal();
        }
        public float GetIsDiscountOrIncreaseForAgentHelper()
        {
            return objPOSScreenBal.GetIsDiscountOrIncreaseForAgentBal();
        }
        public DataTable GetAppliedIncreaseHelper(int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            return objPOSScreenBal.GetAppliedIncreaseBal(CategoryID, CompanyID, ItemType, ItemNo);
        }

        public bool UpdateActiveUserHelper()
        {
            bool Value = objPOSScreenBal.UpdateActiveUserBal();
            return Value;
        }
        public List<POSObject> GetActiveUserHelper()
        {
            return objPOSScreenBal.GetActiveUserBal();
        }

        public void setPrice(string txtprice)
        {
            if (Package.Count > 0)
            {
                Package.Where(a => a.PackageQty == packageqty).ToList()[0].Price = Convert.ToDecimal(txtprice);
            }
        }

        public List<POSObject> GetCateComIDForItemBalHelper()
        {
            return objPOSScreenBal.GetCateComIDForItemBal();

        }

        public float GetAppliedDiscountHelper()
        {

            return objPOSScreenBal.GetAppliedDiscountBal();

        }
        public DataTable GetAppliedIncreaseHelper()
        {

            return objPOSScreenBal.GetAppliedIncreaseBal();

        }

        public DataSet GetItemPrintInfo()
        {

            return objPOSScreenBal.GetItemPrintInfoBal();

        }
    }
}
