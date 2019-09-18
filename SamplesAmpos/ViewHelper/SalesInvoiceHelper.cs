using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.Interface;
using BALHelper;
using System.Data;
using ObjectHelper;
using CommonHelper;
using System.Drawing;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using System.Globalization;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;

namespace BumedianBM.ViewHelper
{
    public class SalesInvoiceHelper
    {
        #region Variables
        public SaleInvoiceBAL objSaleInvoiceBAL;
        internal Dictionary<string, List<SaleObject>> dicLoad = new Dictionary<string, List<SaleObject>>();
        internal List<SaleObject> lstSaleObject = new List<SaleObject>();
        internal List<object> lstSaleTable;
        internal List<AgentDetailObjectClass> lstClientList;
        internal List<long> InvoiceID = new List<long>();
        DataTable dtSaleExtended;
        internal List<SaleObject> lstInsertDetails = new List<SaleObject>();
        internal List<SaleObject> lstInvoiceDetails = new List<SaleObject>();
        internal List<SaleObject> lstSaleDetailExtended = new List<SaleObject>();
        int Index = -1;
        internal int IDFlag;
        internal List<int> ID = new List<int>();
        internal string PriceType = "NormalPrice";
        internal int ButtonClick = -1;
        internal string ItemHoverCost = "";
        internal Item_Information ObjItemInfo;
        internal List<long> IDS = new List<long>();
        internal bool IsFromGridUpdate = false;
        internal int XStockInHand, XBox, XBarcodeID;
        internal DateTime? XExpiryDate; internal string XSerialNo;
        internal decimal XPrice, XUnitPrice, XF10Total;
        internal DataTable dtAllItems = new DataTable();
        internal DataTable ClientDetails = new DataTable();
        #endregion

        #region Constrcutor
        public SalesInvoiceHelper()
        {
            objSaleInvoiceBAL = new SaleInvoiceBAL();
            ObjItemInfo = new Item_Information();
        }


        #endregion

        #region UIDatabaseMethods
        public void Load()
        {
            dicLoad = new Dictionary<string, List<SaleObject>>();
            dicLoad = objSaleInvoiceBAL.Get_LoadDetails();

        }
        public void LoadItemDetails()
        {
            //lstSaleObject = new List<SaleObject>();
            //lstSaleObject = objSaleInvoiceBAL.getItemDetails();
            dtAllItems = objSaleInvoiceBAL.getItemDetails();

        }
        public void LoadClientDetails()
        {
            //lstClientList = objSaleInvoiceBAL.LoadClientDetailsBal();
            ClientDetails = objSaleInvoiceBAL.GetAllClients();
        }

        public void LoadGrid()
        {
            lstSaleTable = objSaleInvoiceBAL.Get_Grid();
        }
        public void NewInvoiceClick()
        {
            List<int> lst = new List<int>();
            // lst = objSaleInvoiceBAL.GetS();
            int a = 0;
            // int t;
            a = lst[0];

        }

        public void Get_ItemWithStockHelper(out List<SaleObject> ItemList)
        {

            ItemList = objSaleInvoiceBAL.Get_ItemForCategory();
        }

        public void Get_ItemWithNonStockHelper(out List<SaleObject> ItemList)
        {

            ItemList = objSaleInvoiceBAL.Get_ItemForCategoryWithNonStock();
        }

        public List<SaleObject> GetItemNameInfoHelper()
        {
            List<SaleObject> lstItemInfo = objSaleInvoiceBAL.GetItemNameInfoBal();
            if (lstItemInfo.Count > 0)
            {
                //ItemHoverCost = lstItemInfo[0].itemcost.ToString();
                //comment by thamil as per client requirement on 21_aug_2016
                //ItemHoverCost = lstItemInfo[0].ItemCostPer.ToString();
                ItemHoverCost = lstItemInfo[0].AvgCost.ToString();
            }
            return lstItemInfo;
        }

        public float GetDiscountForAgentHelper()
        {
            return objSaleInvoiceBAL.GetDiscountForAgentBal();
        }
        public float GetIsDiscountOrIncreaseForAgentHelper()
        {
            return objSaleInvoiceBAL.GetIsDiscountOrIncreaseForAgentBal();
        }

        public float GetPaymentChargesHelper()
        {
            return objSaleInvoiceBAL.GetPaymentChargesBal();
        }

        public Dictionary<string, List<SaleObject>> GetPaymentDateHelper()
        {
            return objSaleInvoiceBAL.GetPaymentDateBal();
        }


        public List<SaleObject> GetSerialNoHelper()
        {
            return objSaleInvoiceBAL.GetSerialNoBal();
        }

        public List<SaleObject> GetItemMinPriceHelper()
        {
            return objSaleInvoiceBAL.GetItemMinPriceBal();
        }

        public List<SaleObject> GetStockBasedExpiryHelper()
        {
            return objSaleInvoiceBAL.GetStockBasedExpiryBal();
        }

        public List<SaleObject> GetStockBasedSerialNoHelper()
        {
            return objSaleInvoiceBAL.GetStockBasedSerialNoBal();
        }

        public List<SaleObject> GetStockHelper()
        {
            return objSaleInvoiceBAL.GetStockBal();
        }

        public List<SaleObject> GetExpiryCountHelper()
        {
            return objSaleInvoiceBAL.GetExpiryCountBal();
        }
        public List<SaleObject> GetExpiryFromGrid(int ID, DateTime? Expiry)
        {
            return objSaleInvoiceBAL.GetExpiryForUpdate(ID, Expiry);
        }
        public List<SaleObject> GetDebtLimitHelper()
        {
            return objSaleInvoiceBAL.GetDebtLimitBal();
        }

        public List<SaleObject> GetActiveUserHelper()
        {
            return objSaleInvoiceBAL.GetActiveUserBal();
        }

        public void NewbtnYearInvoice()
        {
            InvoiceID = objSaleInvoiceBAL.GetYearSequenceMaxIDBal();
        }

        public bool SaveSalesHelper()
        {
            bool Value = objSaleInvoiceBAL.SaveSalesBal();
            return Value;
        }

        public bool SaveSalesOnCloseHelper()
        {
            bool Value = objSaleInvoiceBAL.SaveSalesOnCloseBal();
            return Value;
        }

        public bool SaveSaleDetailsHelper()
        {
            bool Value = objSaleInvoiceBAL.SaveSaleDetailsBal();
            return Value;
        }

        public bool SaveSaleDetailsOnClosingHelper()
        {
            bool Value = objSaleInvoiceBAL.SaveSaleDetailsOnClosingBal();
            return Value;
        }

        public bool SaveSaleDetailOnCloseDT(DataTable dt)
        {
            bool Value = objSaleInvoiceBAL.SaveSaleDetailOnCloseDT(dt);
            return Value;
        }

        public bool UpdateActiveUserHelper()
        {
            bool Value = objSaleInvoiceBAL.UpdateActiveUserBal();
            return Value;
        }

        public bool CheckDateIsExpiryHelper()
        {

            return objSaleInvoiceBAL.CheckDateIsExpiryBal();
        }

        public List<SaleObject> GetSaleDetailsHelper()
        {
            return objSaleInvoiceBAL.GetSaleDetailsBal();
        }

        public List<SaleObject> GetSaleDetailsExtendedHelper()
        {
            try
            {
                lstSaleDetailExtended = objSaleInvoiceBAL.GetSaleDetailsExtendedBal();

                if (lstSaleDetailExtended.Count > 0)
                {
                    objSaleInvoiceBAL.objSaleObject.SumOfTotal = lstSaleDetailExtended.Sum(a => a.Totalcost);
                }
                else
                {
                    objSaleInvoiceBAL.objSaleObject.SumOfTotal = 0;
                }

                return lstSaleDetailExtended;
            }
            catch (Exception)
            {

                throw;
            }





        }

        public List<SaleObject> GetItemAvgCostHelper()
        {
            return objSaleInvoiceBAL.GetItemAvgCostBal();
        }

        public DataTable GetSaleDetailIDHelper()
        {

            return objSaleInvoiceBAL.GetSaleDetailIDBal();

        }

        public List<int> GetSaleIDHelper()
        {

            return objSaleInvoiceBAL.GetSaleIdBal();

        }

        public List<SaleObject> GetYearSequenceHelper()
        {

            return objSaleInvoiceBAL.GetYearSequenceBal();

        }

        public List<SaleObject> GetStockBaseExpiryInvNoHelper()
        {
            return objSaleInvoiceBAL.GetStockBaseExpiryInvNoBal();

        }

        public bool DeleteSaleItemHelper()
        {

            return objSaleInvoiceBAL.DeleteSaleItemBal();

        }

        public List<SaleObject> GetItemNameForIDHelper()
        {
            return objSaleInvoiceBAL.GetItemNameForIDBal();

        }

        public List<SaleObject> GetClientNoHelper()
        {
            return objSaleInvoiceBAL.GetClientNoBal();

        }

        public List<SaleObject> GetClientNameHelper()
        {
            return objSaleInvoiceBAL.GetClientNameBal();

        }

        public List<SaleObject> GetCurrentYearHelper(int TID)
        {
            return objSaleInvoiceBAL.GetCurrentYearBal(TID);

        }

        public List<SaleObject> GetCateComIDForItemBalHelper()
        {
            return objSaleInvoiceBAL.GetCateComIDForItemBal();

        }

        public Decimal GetAgentDiscountHelper()
        {

            return objSaleInvoiceBAL.GetAgentDiscountBal();

        }

        public float GetAppliedDiscountHelper()
        {

            return objSaleInvoiceBAL.GetAppliedDiscountBal();

        }

        public DataTable GetAppliedIncreaseHelper()
        {

            return objSaleInvoiceBAL.GetAppliedIncreaseBal();

        }

        public int CheckEmptyInvoiceHelper()
        {

            return objSaleInvoiceBAL.CheckEmptyInvoiceBal();

        }

        public bool ModifyInvoiceHelper()
        {

            return objSaleInvoiceBAL.ModifyInvoiceBal();

        }

        public int CheckClosedInvoiceHelper()
        {
            return objSaleInvoiceBAL.CheckClosedInvoiceBal();
        }

        public List<SaleObject> GetBalanceForSaleInvoiceHelper()
        {

            return objSaleInvoiceBAL.GetBalanceForSaleInvoiceBal();

        }

        public List<SaleObject> GetItemInfoExportHelper()
        {

            return objSaleInvoiceBAL.GetItemInfoExportBal();

        }

        internal bool SaveNewAgent()
        {
            if (objSaleInvoiceBAL.SaveAgentDetails())
            {
                GeneralFunction.Information("New AgentDetails Saved Successfully", "Sales Invoice");
                return true;
            }
            else
                return false;

        }

        public List<SaleObject> GetPackageQtyForItemHelper()
        {
            return objSaleInvoiceBAL.GetPackageQtyForItemBal();
        }

        public List<SaleObject> GetExpiryBasedPackageHelper()
        {
            return objSaleInvoiceBAL.GetExpiryBasedPackageBal();
        }

        public List<SaleObject> GetSerialNoBasedPackageHelper()
        {
            return objSaleInvoiceBAL.GetSerialNoBasedPackageBal();
        }

        public decimal GetPriceForPackageQtyHelper()
        {
            return objSaleInvoiceBAL.GetPriceForPackageQtyBal();
        }
        #endregion

        #region UIHelperMethods

        #region GetCurrentYear
        public void GetCurrentYear()
        {
            List<SaleObject> lstCurrentYear = GetCurrentYearHelper(Convert.ToInt32(CommonHelper.Table.Sales));
            if (lstCurrentYear.Count > 0)
            {
                objSaleInvoiceBAL.objSaleObject.CurrentYear = (lstCurrentYear[0].CurrentYear != null) ? lstCurrentYear[0].CurrentYear : 0;
            }
        }
        #endregion

        #region ReturnCurrentYear
        public int ReturnCurrentYear()
        {
            List<SaleObject> lstCurrentYear = GetCurrentYearHelper(Convert.ToInt32(CommonHelper.Table.PerformaInvoice));
            if (lstCurrentYear.Count > 0)
            {
                objSaleInvoiceBAL.objSaleObject.CurrentYear = (lstCurrentYear[0].CurrentYear != null) ? lstCurrentYear[0].CurrentYear : 0;
            }
            return objSaleInvoiceBAL.objSaleObject.CurrentYear;
        }
        #endregion

        #region DatatableAssign
        public void DatatableAssign()
        {
            if (dtSaleExtended != null) return;
            dtSaleExtended = new DataTable();
            dtSaleExtended.Columns.Add("ItemNo");
            dtSaleExtended.Columns.Add("Discription");
            dtSaleExtended.Columns.Add("Expiry");
            dtSaleExtended.Columns.Add("Package");
            dtSaleExtended.Columns.Add("Quantity");
            dtSaleExtended.Columns.Add("UnitPrice");
            dtSaleExtended.Columns.Add("Total");
            dtSaleExtended.Columns.Add("Time");
            dtSaleExtended.Columns.Add("Username");
            dtSaleExtended.Columns.Add("Returned");
            dtSaleExtended.Columns.Add("Agent");
            dtSaleExtended.Columns.Add("mtb_sale_det_id");
            dtSaleExtended.Columns.Add("saleid");
            dtSaleExtended.Columns.Add("mtb_discount");
            dtSaleExtended.Columns.Add("Serialno");
            dtSaleExtended.Columns.Add("NewExpr");
            dtSaleExtended.Columns.Add("ActualPrice");
            dtSaleExtended.Columns.Add("Itemtax");
            dtSaleExtended.Columns.Add("ItemCost");
            DatacolumAdd();
        }
        #endregion

        #region DatacolumAdd
        public void DatacolumAdd()
        {
            if (dtSaleExtended.Columns.Contains("Totalcost"))
            {
                dtSaleExtended.Columns.Remove("Totalcost");
            }
            if (dtSaleExtended.Columns.Contains("Subtotal"))
            {
                dtSaleExtended.Columns.Remove("Subtotal");
            }
            DataColumn dcUnitcost = new DataColumn("Totalcost", typeof(decimal));
            dcUnitcost.Expression = "itemcost*Quantity";
            DataColumn dcSubtotal = new DataColumn("Subtotal", typeof(decimal));
            dcSubtotal.Expression = "(Quantity/Package)*ActualPrice";
            dtSaleExtended.Columns.Add(dcUnitcost);
            dtSaleExtended.Columns.Add(dcSubtotal);
        }
        #endregion

        #region SortInvoiceDetails
        public List<SaleObject> SortInvoiceDetails(List<SaleObject> lstInvDetail, string ItemColumnName, string PriceColumnName)
        {
            try
            {

                switch (GeneralOptionSetting.FlagItemSorting)
                {
                    case "0":
                        // dt.DefaultView.Sort = ItemColumnName;
                        lstInvDetail = objSaleInvoiceBAL.SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "asc");
                        break;
                    case "1":
                        //dt.DefaultView.Sort = ItemColumnName + " " + "desc";
                        lstInvDetail = objSaleInvoiceBAL.SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "desc");
                        break;
                    case "4":
                        // dt.DefaultView.Sort = PriceColumnName;
                        lstInvDetail = objSaleInvoiceBAL.SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "asc");
                        break;
                    case "3":
                        //dt.DefaultView.Sort = PriceColumnName + " " + "desc";
                        lstInvDetail = objSaleInvoiceBAL.SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "desc");
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
        #endregion

        #region ValidateItemInsertion
        public Boolean ValidateItemInsertion()
        {

            if (objSaleInvoiceBAL.objSaleObject.ItemSelectedIndex <= -1 && objSaleInvoiceBAL.objSaleObject.ItemSelectedValue == null)
            {
                if (objSaleInvoiceBAL.objSaleObject.ItemSelectedText != objSaleInvoiceBAL.objSaleObject.itemname)
                {
                    GeneralFunction.Information("EmptyItemName", "Sales Invoice");
                    return false;
                }
            }

            if (String.IsNullOrEmpty(objSaleInvoiceBAL.objSaleObject.QtyText))
            {
                GeneralFunction.Information("EmptyQty", "Sales Invoice");
                return false;
            }
            else
                objSaleInvoiceBAL.objSaleObject.expirqty = Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.QtyText);
            if (objSaleInvoiceBAL.objSaleObject.RemainingText == string.Empty)
            {
                GeneralFunction.Information("NoStockItem", "Sales Invoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.ItemSelectedValue == null)
            {
                GeneralFunction.Information("EmptyItemName", "Sales Invoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.DgrBgColorValue == "Color [Gray]")
            {
                GeneralFunction.Information("CantInsertafterClosingInvoice", "Sales Invoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.QtyText == "")
            {
                GeneralFunction.Information("EmptyQty", "Sales Invoice");
                return false;
            }
            else return true;

        }
        #endregion

        #region InsertionItemCalculation
        public void InsertionItemCalc()
        {

            int count = 0;
            objSaleInvoiceBAL.objSaleObject.expirqty = (objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.QtyText) : (Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.QtyText) * Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText));


        }

        #endregion

        #region FillSaleDetailList
        public void FillSaleDetailList()
        {
            //List<SaleObject> lstSaledetId;
            try
            {
                int SaleDetId = 0, SaleId = 0;
                DataTable dt_detail = new DataTable();
                objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText == string.Empty ? "0" : objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText);
                objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                // dt_detail = obj_saleinvoice_dal.get_sale_det_id();
                //lstSaledetId = GetSaleDetailIDHelper();
                DataTable dtSaleID = GetSaleDetailIDHelper();
                DateTime dt;
                string[] DateTimeSplit = DateTime.Now.TimeOfDay.ToString().Split('.');
                //if (lstSaledetId.Count > 0)
                //{
                //    if ((lstSaledetId[0].saledetid.ToString() != ""))
                //    {
                //        SaleDetId = (Convert.ToInt32(lstSaledetId[0].saledetid.ToString()) + 1);
                //    }
                //    if (lstSaledetId[0].saleid.ToString() == "" || lstSaledetId[0].saleid == 0)
                //    {
                //        SaleId = Convert.ToInt32(lstSaledetId[0].maxsaleid);
                //    }
                //    else
                //        SaleId = Convert.ToInt32(lstSaledetId[0].saleid);
                //}
                if (dtSaleID != null && dtSaleID.Rows.Count > 0)
                {
                    if ((dtSaleID.Rows[0]["SaleDetailID"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["SaleDetailID"]).ToString() != "")
                    {
                        SaleDetId = (Convert.ToInt32((dtSaleID.Rows[0]["SaleDetailID"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["SaleDetailID"]).ToString()) + 1);
                    }
                    if ((dtSaleID.Rows[0]["saleid"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["saleid"]).ToString() == "" || Convert.ToInt32(dtSaleID.Rows[0]["saleid"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["saleid"]) == 0)
                    {
                        SaleId = Convert.ToInt32((dtSaleID.Rows[0]["maxsaleid"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["maxsaleid"]));
                    }
                    else
                        SaleId = Convert.ToInt32((dtSaleID.Rows[0]["saleid"] == DBNull.Value ? 0 : dtSaleID.Rows[0]["saleid"]));
                }
                Decimal TotalPriceCalc = 0.00M;
                Decimal SubTotalPriceCalc = 0.00M;
                if (objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText) == 0)
                {
                    TotalPriceCalc = (objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPackageprice;
                    SubTotalPriceCalc = TotalPriceCalc;
                }
                else
                {
                    TotalPriceCalc = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                    SubTotalPriceCalc = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) && ((objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) == 0) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                }
                if (!IsFromGridUpdate)
                {

                    lstSaleDetailExtended.Add(new SaleObject
                    {
                        //itemid = Convert.ToInt16((objSaleInvoiceBAL.objSaleObject.CmbItemNoVisible == false) ? 0 : objSaleInvoiceBAL.objSaleObject.ItemNo),
                        itemid = objSaleInvoiceBAL.objSaleObject.ItemNo,
                        ItemDescription = objSaleInvoiceBAL.objSaleObject.itemname,
                        //ItemExpiryDate = (Expiryformat(objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString()) == false) ? Convert.ToDateTime(null) : objSaleInvoiceBAL.objSaleObject.expiry,
                        ItemExpiryDate = objSaleInvoiceBAL.objSaleObject.expiry,//Added on 28-May-2014 for Replacing the above condition to work for all the Date Formats
                        ItemPackage = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText),
                        quantity = objSaleInvoiceBAL.objSaleObject.quantity,
                        unitprice = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000")),

                        //Commented on 28-Oct-2014 by Seenivasan                   //TotalPrice = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),
                        TotalPrice = TotalPriceCalc,
                        // ModifiedDate = Convert.ToDateTime((GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTime.Now.ToLongTimeString() : "00:00"),//Commented on 28-May-2014
                        //StrModifiedDate = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTime.Now.ToLongTimeString() : "00:00",//Added on 28-May-2014 to work for all the Date Formats
                        StrModifiedDate = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTimeSplit[0] : "00:00",//Added on 28-May-2014 to work for all the Date Formats
                        user = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? GeneralFunction.UserName : "",
                        ReturnQty = 0,
                        ClientID = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText == string.Empty ? "0" : objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText),
                        saledetid = Convert.ToInt64(SaleDetId),
                        saleid = Convert.ToInt64(SaleId),
                        itemdiscount = Convert.ToDouble(objSaleInvoiceBAL.objSaleObject.itemdiscount),
                        //serialno = Convert.ToInt64(objSaleInvoiceBAL.objSaleObject.serialno),
                        serialno = objSaleInvoiceBAL.objSaleObject.serialno,
                        Newexpr = objSaleInvoiceBAL.objSaleObject.expiry,
                        ActualPrice = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.ActualPrice.ToString("#####0.000")),
                        tax = 0,
                        //Totalcost = Convert.ToDecimal(list.ItemCost * list.Quantity),
                        // Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText)) * Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.ActualPrice.ToString("#####0.000"))),
                        //Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),//Modified on 14-May-2014
                        //Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true && (objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) != 0) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),//Added on 14-May-2014 this line commended to fix total cal on 21Aug2014 by Meena.R
                        //Commented on 28-Oct-2014 by Seenivasan                   //Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) && ((objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) == 0) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),
                        Subtotal = SubTotalPriceCalc,
                        Box = (objSaleInvoiceBAL.objSaleObject.IsPackage == false ? objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText) : 0),
                        StrItemNo = objSaleInvoiceBAL.objSaleObject.StrItemNo,
                        //StrExpiryDate = (Expiryformat(objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString()) == false) ? "-" : objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString(),

                        StrExpiryDate = (objSaleInvoiceBAL.objSaleObject.expiry == Convert.ToDateTime("1/1/1900") ? "-" : objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString()),
                        BarcodeID = objSaleInvoiceBAL.objSaleObject.BarcodeID, //Added on 22-May-2014

                        //add by thamil 
                        ItemCost = objSaleInvoiceBAL.objSaleObject.ItemCost,
                        ItemCostPer = objSaleInvoiceBAL.objSaleObject.ItemCostPer,
                        Totalcost = objSaleInvoiceBAL.objSaleObject.ItemCost * objSaleInvoiceBAL.objSaleObject.ItemCostPer,
                    });
                }
                else
                {
                    lstSaleDetailExtended[Index].itemid = objSaleInvoiceBAL.objSaleObject.ItemNo;
                    lstSaleDetailExtended[Index].ItemDescription = objSaleInvoiceBAL.objSaleObject.itemname;
                    //ItemExpiryDate = (Expiryformat(objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString()) == false) ? Convert.ToDateTime(null) : objSaleInvoiceBAL.objSaleObject.expiry,
                    lstSaleDetailExtended[Index].ItemExpiryDate = objSaleInvoiceBAL.objSaleObject.expiry;//Added on 28-May-2014 for Replacing the above condition to work for all the Date Formats
                    lstSaleDetailExtended[Index].ItemPackage = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText);
                    lstSaleDetailExtended[Index].quantity = objSaleInvoiceBAL.objSaleObject.quantity;
                    lstSaleDetailExtended[Index].unitprice = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"));
                    //Commented on 28-Oct-2014    //  lstSaleDetailExtended[Index].TotalPrice = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));

                    lstSaleDetailExtended[Index].TotalPrice = TotalPriceCalc;//Added on 28-Oct-2014

                    // ModifiedDate = Convert.ToDateTime((GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTime.Now.ToLongTimeString() : "00:00"),//Commented on 28-May-2014
                    //StrModifiedDate = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTime.Now.ToLongTimeString() : "00:00",//Added on 28-May-2014 to work for all the Date Formats
                    lstSaleDetailExtended[Index].StrModifiedDate = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTimeSplit[0] : "00:00";//Added on 28-May-2014 to work for all the Date Formats
                    lstSaleDetailExtended[Index].user = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? GeneralFunction.UserName : "";
                    lstSaleDetailExtended[Index].ReturnQty = 0;
                    lstSaleDetailExtended[Index].ClientID = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText == string.Empty ? "0" : objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText);
                    lstSaleDetailExtended[Index].saledetid = lstSaleDetailExtended[Index].saledetid;
                    lstSaleDetailExtended[Index].saleid = Convert.ToInt64(SaleId);
                    lstSaleDetailExtended[Index].itemdiscount = Convert.ToDouble(objSaleInvoiceBAL.objSaleObject.itemdiscount);
                    //serialno = Convert.ToInt64(objSaleInvoiceBAL.objSaleObject.serialno),
                    lstSaleDetailExtended[Index].serialno = objSaleInvoiceBAL.objSaleObject.serialno;
                    lstSaleDetailExtended[Index].Newexpr = objSaleInvoiceBAL.objSaleObject.expiry;
                    lstSaleDetailExtended[Index].ActualPrice = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.ActualPrice.ToString("#####0.000"));
                    lstSaleDetailExtended[Index].tax = 0;
                    //Totalcost = Convert.ToDecimal(list.ItemCost * list.Quantity),
                    // Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText)) * Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.ActualPrice.ToString("#####0.000"))),
                    //Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),//Modified on 14-May-2014
                    //Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true && (objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) != 0) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")),//Added on 14-May-2014 this line commended to fix total cal on 21Aug2014 by Meena.R
                    //Commented on 28-Oct-2014    //  lstSaleDetailExtended[Index].Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) && ((objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) == 0) ? ((objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                    lstSaleDetailExtended[Index].Subtotal = SubTotalPriceCalc;
                    lstSaleDetailExtended[Index].Box = (objSaleInvoiceBAL.objSaleObject.IsPackage == false ? objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText) : 0);
                    lstSaleDetailExtended[Index].StrItemNo = objSaleInvoiceBAL.objSaleObject.StrItemNo;
                    //StrExpiryDate = (Expiryformat(objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString()) == false) ? "-" : objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString(),
                    lstSaleDetailExtended[Index].StrExpiryDate = (objSaleInvoiceBAL.objSaleObject.expiry == Convert.ToDateTime("1/1/1900") ? "-" : objSaleInvoiceBAL.objSaleObject.expiry.ToShortDateString());
                    lstSaleDetailExtended[Index].BarcodeID = objSaleInvoiceBAL.objSaleObject.BarcodeID; //Added on 22-May-2014
                    //add by thamil on 29_Aug_2016
                    lstSaleDetailExtended[Index].ItemCost = objSaleInvoiceBAL.objSaleObject.ItemCost;
                    lstSaleDetailExtended[Index].ItemCostPer = objSaleInvoiceBAL.objSaleObject.ItemCostPer;
                    lstSaleDetailExtended[Index].Totalcost = objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceBAL.objSaleObject.ItemCost;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally  //Added finally to release the "lstSaledetId" object for Performance Tuning on 18
            {
                //lstSaledetId = null;
            }
        }
        #endregion

        #region GetSumOfSubTotal
        public void GetSumofSubTotal()
        {

            if (lstSaleDetailExtended.Count > 0)
            {
                objSaleInvoiceBAL.objSaleObject.SumOfSubTotal = lstSaleDetailExtended.Sum(a => a.Subtotal);
            }
            else
            {
                objSaleInvoiceBAL.objSaleObject.SumOfSubTotal = 0;
            }
        }
        #endregion

        #region Expiryformat
        public bool Expiryformat(string dateformat)
        {
            try
            {
                char ch;
                if (dateformat.Contains("/"))
                    ch = '/';
                else if (dateformat.Contains("-"))
                    ch = '-';
                else if (dateformat.Contains("."))
                    ch = '.';
                //else if (dateformat.Contains("\"))
                //    ch = '\';
                else ch = ' ';
                string[] datesplit = dateformat.Split(ch);

                if (datesplit.Length >= 3)
                {
                    if ((datesplit[0] == "01") || (datesplit[0] == "1") || (datesplit[0] == "Jan") || (datesplit[0] == "00") || (datesplit[0] == "1900"))
                    {
                        if ((datesplit[1] == "01") || (datesplit[1] == "1") || (datesplit[1] == "Jan") || (datesplit[0] == "00") || (datesplit[0] == "1900"))
                        {
                            if ((datesplit[2].Contains("01")) || (datesplit[2].Contains("1")) || (datesplit[2].Contains("Jan")) || (datesplit[2].Contains("00")) || (datesplit[2].Contains("1900")))
                            {
                                return false;
                            }
                            else return true;
                        }
                        else return true;
                    }
                    else return true;


                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region MinPriceAndCostPriceCheck
        public Boolean MinPriceAndCostPriceCheck()
        {
            Boolean flag = false;
            try
            {
                float price = 0.0f;
                int package = 1;
                float minprice = 0.0f;
                float cost = 0.0f;
                if (objSaleInvoiceBAL.objSaleObject.ItemSelectedIndex > -1)
                {
                    if (objSaleInvoiceBAL.objSaleObject.PriceText != "")
                    {
                        price = float.Parse(objSaleInvoiceBAL.objSaleObject.PriceText);
                        objSaleInvoiceBAL.objSaleObject.itemid = objSaleInvoiceBAL.objSaleObject.ItemNo;
                        //  DataTable dt = new DataTable();
                        //  dt = obj_saleinvoice_dal.minimumprice();
                        List<SaleObject> lstMinPrice = GetItemMinPriceHelper();
                        if (lstMinPrice.Count > 0)
                        {
                            //package = lstMinPrice[0].ItemPackage; //Commented on 18-Apr-14
                            package = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageQtyText);//Added on 18-Apr-14
                            minprice = (objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? float.Parse(lstMinPrice[0].ItemMinimumPrice.ToString()) / package : float.Parse(lstMinPrice[0].ItemMinimumPrice.ToString());
                            cost = (objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? float.Parse(lstMinPrice[0].AvgCost.ToString()) / package : float.Parse(lstMinPrice[0].AvgCost.ToString()); // Added on 24-Jan-2014 for calculating Cost Price for --> Piece and Box
                            if (cost > price)
                            {
                                if ((GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") && (GeneralFunction.UserName != "Admin") && (objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                                {
                                    GeneralFunction.Information("LessthanSellingPricethanCost", "Sales Invoice");

                                    if (GeneralFunction.OKCancelMsg("AlertSellingPrice", "Sales Invoice") == DialogResult.OK)
                                    { flag = true; }
                                    else
                                        flag = false;
                                }
                                else
                                    flag = true;
                            }
                            else
                                flag = true;

                            if (flag != false)
                            {
                                if ((minprice > price) & (GeneralFunction.UserId != 101))
                                {

                                    GeneralFunction.Information("LessthanSellingPricethanMinimumPrice", "Sales Invoice");

                                    if (GeneralFunction.OKCancelMsg("AlertSellingPrice", "Sales Invoice") == DialogResult.OK)
                                    {
                                        flag = true;
                                    }
                                    else
                                        flag = false;
                                }
                                else
                                    flag = true;
                            }

                        }
                    }
                }

                //************Added on 17-May-2014 for Testing need clarification******
                if (objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal || objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                {
                    flag = true;
                }
                //************Added on 17-May-2014 for Testing need clarification******
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return flag;


        }
        #endregion

        #region UpdateSaleDetailList
        public int UpdateSaleDetailList()
        {

            if (lstSaleDetailExtended.Count > 0)
            {
                if (objSaleInvoiceBAL.objSaleObject.DtpExpiryVisible == true && objSaleInvoiceBAL.objSaleObject.expiry != Convert.ToDateTime("1/1/1900"))
                {

                    Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.ItemExpiryDate == objSaleInvoiceBAL.objSaleObject.expiry) && (a.unitprice == Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) && (a.ItemPackage == Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText))); //&& (objSaleInvoiceBAL.objSaleObject.IsPackage != true ? a.Box != 0 : a.Box == 0) // Commit this to insert in same row on 11-Sept-2019

                }
                else if (objSaleInvoiceBAL.objSaleObject.CmbSerialNoNoVisible == true && objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                {
                    Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.serialno == objSaleInvoiceBAL.objSaleObject.serialno) && (a.unitprice == Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) && (a.ItemPackage == Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)));//&& (objSaleInvoiceBAL.objSaleObject.IsPackage != true ? a.Box != 0 : a.Box == 0) // Commit this to insert in same row on 11-Sept-2019
                }
                else
                {
                    Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.unitprice == Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) && (a.ItemPackage == Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)));//&& (objSaleInvoiceBAL.objSaleObject.IsPackage != true ? a.Box != 0 : a.Box == 0) // Commit this to insert in same row on 11-Sept-2019
                }
                if (Index != -1)
                {
                    Decimal TotalPriceCalc = 0.00M;
                    lstSaleDetailExtended[Index].quantity = lstSaleDetailExtended[Index].quantity + objSaleInvoiceBAL.objSaleObject.quantity;
                    if (lstSaleDetailExtended[Index].quantity % Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText) == 0)
                    {
                        TotalPriceCalc = (lstSaleDetailExtended[Index].quantity / Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPackageprice;

                    }
                    else
                    {
                        TotalPriceCalc = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((lstSaleDetailExtended[Index].quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (lstSaleDetailExtended[Index].quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                    }

                    //Commented on 28-Oct-2014    // lstSaleDetailExtended[Index].TotalPrice = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((lstSaleDetailExtended[Index].quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (lstSaleDetailExtended[Index].quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                    lstSaleDetailExtended[Index].TotalPrice = TotalPriceCalc;//Added on 28-Oct-2014
                    // Added on 11-Sept-2019 By T
                    if (objSaleInvoiceBAL.objSaleObject.IsPackage != true || (lstSaleDetailExtended[Index].quantity % lstSaleDetailExtended[Index].ItemPackage) == 0)
                    {
                        lstSaleDetailExtended[Index].Box = lstSaleDetailExtended[Index].quantity / (lstSaleDetailExtended[Index].ItemPackage != 0 ? Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText) : 1);
                        objSaleInvoiceBAL.objSaleObject.Box = lstSaleDetailExtended[Index].Box;//Added on 22-May-2014 to update the Box Calculationm and Update it into SaleDetail table
                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.Box = lstSaleDetailExtended[Index].Box;
                    }
                    //

                    // Commit this on 11-Sept-2019 By T
                    //lstSaleDetailExtended[Index].Box = ((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? lstSaleDetailExtended[Index].quantity / (lstSaleDetailExtended[Index].ItemPackage != 0 ? Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText) : 1) : 0);
                    //objSaleInvoiceBAL.objSaleObject.Box = lstSaleDetailExtended[Index].Box;//Added on 22-May-2014 to update the Box Calculationm and Update it into SaleDetail table
                    //
                    lstSaleDetailExtended[Index].Totalcost = Convert.ToDecimal((lstSaleDetailExtended[Index].ItemCostPer != null ? lstSaleDetailExtended[Index].ItemCostPer : 1) * lstSaleDetailExtended[Index].quantity);
                    //lstSaleDetailExtended[Index].Subtotal = (lstSaleDetailExtended[Index].quantity / (lstSaleDetailExtended[Index].ItemPackage != 0 ? Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText) : 1)) * objSaleInvoiceBAL.objSaleObject.ActualPrice;//Commented on 29-April-2014
                    //Commented on 28-Oct-2014  // lstSaleDetailExtended[Index].Subtotal = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((lstSaleDetailExtended[Index].quantity / Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (lstSaleDetailExtended[Index].quantity * objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                    lstSaleDetailExtended[Index].Subtotal = TotalPriceCalc;//Added on 28-Oct-2014
                }
            }

            return Index;

        }

        public int FindIndex()
        {
            if (objSaleInvoiceBAL.objSaleObject.DtpExpiryVisible == true && objSaleInvoiceBAL.objSaleObject.expiry != Convert.ToDateTime("1/1/1900"))
            {

                Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.ItemExpiryDate == XExpiryDate) && (a.unitprice == XUnitPrice) && (a.BarcodeID == Convert.ToInt32(XBarcodeID)) && (a.Box == XBox));

            }
            else if (objSaleInvoiceBAL.objSaleObject.CmbSerialNoNoVisible == true && objSaleInvoiceBAL.objSaleObject.secondhand == "true")
            {
                Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.serialno == XSerialNo) && (a.unitprice == XUnitPrice) && (a.BarcodeID == Convert.ToInt32(XBarcodeID)) && (a.Box == XBox));
            }
            else
            {
                Index = lstSaleDetailExtended.FindIndex(a => (a.itemid == objSaleInvoiceBAL.objSaleObject.itemid) && (a.ItemDescription == objSaleInvoiceBAL.objSaleObject.itemname) && (a.unitprice == XUnitPrice) && (a.BarcodeID == Convert.ToInt32(XBarcodeID)) && (a.Box == XBox));
            }
            return Index;
        }
        #endregion

        #region SetLastSaleID

        public void SetLastSaleID()
        {
            //List<SaleObject> lstYearSeq = new List<SaleObject>(); //Commented for Performance Tuning on 18-Nov-2014 by Seenivasan

            List<int> lst = GetSaleIDHelper();

            if (lst.Count > 0)
            {
                objSaleInvoiceBAL.objSaleObject.saleid = (lst[0] == 1) ? lst[0] : (lst[0] - 1); // Commented on 10-June-2014
                //objSaleInvoiceBAL.objSaleObject.saleid = (lst[1] == 1) ? lst[1] : (lst[1] - 1);// Added on 10-June-2014
                objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.saleid;
                //objSaleInvoiceBAL.objSaleObject.Flag = "SaleInvoice";
                //lstYearSeq = GetYearSequenceHelper();
                //if (lstYearSeq.Count > 0)
                //{
                //    objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo = lstYearSeq[0].Year + "-" + lstYearSeq[0].YearSequenceNo;
                //}

            }



        }
        #endregion

        #region SetNewYearInvoiceNo
        public void SetNewYearInvoiceNo()
        {
            List<SaleObject> lstYearSeq = new List<SaleObject>();
            try //Added try catch finally to release the "lstYearSeq" object for Performance Tuning on 18-Nov-2014 by Seenivasan
            {
                objSaleInvoiceBAL.objSaleObject.Flag = "SaleInvoice";
                lstYearSeq = GetYearSequenceHelper();
                if (lstYearSeq.Count > 0)
                {
                    if (objSaleInvoiceBAL.objSaleObject.CurrentYear != lstYearSeq[0].Year)
                    {
                        objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo = lstYearSeq[0].Year + "-" + lstYearSeq[0].YearSequenceNo;
                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo = lstYearSeq[0].YearSequenceNo.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstYearSeq = null;
            }

        }
        #endregion

        #region GetItemNameForID
        public string GetItemNameForID()
        {
            string ItemName = string.Empty;
            if (objSaleInvoiceBAL.objSaleObject.itemid.ToString() != string.Empty)
            {

                List<SaleObject> lstItemName = GetItemNameForIDHelper();
                if (lstItemName.Count > 0)
                {
                    ItemName = lstItemName[0].itemname.ToString();
                }
            }

            return ItemName;
        }
        #endregion

        #region NavigationEvent
        public void NavigationEvent()
        {
            ID = objSaleInvoiceBAL.GetMinMaxSaleIDBal();
            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    objSaleInvoiceBAL.objSaleObject.saleinv = ID[0];

                    break;
                case InvoiceFlag.Next:
                    if (objSaleInvoiceBAL.objSaleObject.saleinv != ID[1])
                    {
                        objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.saleinv + 1;

                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.saleinv = ID[1];

                    }
                    break;
                case InvoiceFlag.Last:
                    objSaleInvoiceBAL.objSaleObject.saleinv = ID[1];

                    break;
                case InvoiceFlag.Previous:
                    if (objSaleInvoiceBAL.objSaleObject.saleinv != ID[0])
                    {
                        objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceBAL.objSaleObject.saleinv - 1;

                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.saleinv = ID[0];

                    }
                    break;
                default:
                    objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(objSaleInvoiceBAL.GetPurInvIDBasedOnNewYearID());
                    break;
            }
        }
        #endregion

        #region NavigationEventTesting
        public void NavigationEventTesting()
        {

            try
            {
                // Added on 15/12/2014 for Performance Issue when invoice navigation
                int saleCount = objSaleInvoiceBAL.GetSaleIDCountWithoutPOSBAl();
                if (saleCount != IDS.Count)
                    IDS = objSaleInvoiceBAL.GetSaleIDWithoutPOSBAl();
                int IdIndex = 0;
                int MaxIDIndex = IDS.Count - 1;
                int MinIDIndex = 0;
                switch ((InvoiceFlag)IDFlag)
                {
                    case InvoiceFlag.First:
                        //objSaleInvoiceBAL.objSaleObject.saleinv = ID[0];
                        IdIndex = IdIndex;

                        break;
                    case InvoiceFlag.Next:
                        if (objSaleInvoiceBAL.objSaleObject.saleinv != IDS[MaxIDIndex])
                        {
                            IdIndex = IDS.IndexOf(objSaleInvoiceBAL.objSaleObject.saleinv);
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
                        if (objSaleInvoiceBAL.objSaleObject.saleinv != IDS[0])
                        {
                            IdIndex = IDS.IndexOf(objSaleInvoiceBAL.objSaleObject.saleinv);
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

                objSaleInvoiceBAL.objSaleObject.saleinv = IDS[IdIndex];
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "Navigation", " SaleInvoiceHelper");
                //throw;
            }

        }
        #endregion

        #region DebtCalculation
        public Boolean DebtCalculation()
        {
            List<SaleObject> lstDebtLimit;
            try
            {
                float TotalClientValue = 0.0f;

                if (objSaleInvoiceBAL.objSaleObject.NetText != "")
                    TotalClientValue = float.Parse(objSaleInvoiceBAL.objSaleObject.NetText);
                if (objSaleInvoiceBAL.objSaleObject.ClientSelectedIndex > -1)

                    if (objSaleInvoiceBAL.objSaleObject.clientname == "زبون نقدي" || objSaleInvoiceBAL.objSaleObject.clientname == "CASH CLIENT")
                    {
                        objSaleInvoiceBAL.objSaleObject.ClientID = 1001;
                        objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText = "1001";
                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt32(objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText);
                    }

                //Getting Debtlimit of agent
                lstDebtLimit = GetDebtLimitHelper();
                float debtlimit = 0.0f;
                Boolean eligible = false;
                if ((objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()) && (objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText != ""))
                {
                    if (lstDebtLimit.Count > 0)
                        debtlimit = float.Parse(lstDebtLimit[0].DebtLimit.ToString());
                    if (debtlimit > 0)
                    {
                        if (TotalClientValue >= debtlimit)
                        { eligible = true; }
                    }
                    else
                        eligible = false;
                }
                return eligible;
            }
            catch (Exception ex) { throw ex; }
            finally //Added finally to release the object for Performance Tuning on 18
            {
                lstDebtLimit = null;
            }
        }

        #endregion

        #region CloseInvoice

        /// <summary>
        /// Created On: 26/12/2013
        /// Created By: Seenivasan B
        /// </summary>
        /// <returns></returns>
        /// 

        #region ValidateCloseInv
        public Boolean ValidateCloseInv()
        {

            if (objSaleInvoiceBAL.objSaleObject.DgrBgColorValue == "Color [Grey]")//Changed from "Color [NavajoWhite]" to "Color [Grey]" on 20-Jan-14
            {
                GeneralFunction.Information("AlreadyInvoiceClosed", "SalesInvoice");
                return false;
            }
            else if (DebtCalculation() == true)
            {
                GeneralFunction.Information("ExceedClientDebtLimit", "SalesInvoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.DgrRowCount == 0)
            {
                GeneralFunction.Information("EmptyInvoiceList", "SalesInvoice");
                return false;
            }
            else if ((objSaleInvoiceBAL.objSaleObject.ActiveUserText != string.Empty) && (objSaleInvoiceBAL.objSaleObject.ActiveUserText.Trim() != GeneralFunction.UserId.ToString()) && (objSaleInvoiceBAL.objSaleObject.ActiveUserText != "0"))// && (GeneralFunction.UserId != 101))removed 101 By Meena On 03/06/2015 //Here UserID 101 added By Meena.R on 18Nov2014 to close the Invoice 
            {
                GeneralFunction.Information("AnotherUserUsingThisInvoice", "SalesInvoice");
                return false;
            }

            else
                return true;


        }
        #endregion

        #region CheckValues
        public Boolean CheckValues()
        {
            if (objSaleInvoiceBAL.objSaleObject.DgrRowCount == 0)
            {
                GeneralFunction.Information("EmptyInvoiceList", "SalesInvoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.ClientNoSelectedValue == null)
            {
                GeneralFunction.Information("EmptyClientName", "SalesInvoice");
                return false;
            }
            else if (objSaleInvoiceBAL.objSaleObject.InvoiceNoText.ToString() == "")
            {
                GeneralFunction.Information("EmptyInvoiceNo", "SalesInvoice");
                return false;
            }
            else
                return true;

        }
        #endregion

        #region NetDiscountCalc
        public void Discount1()
        {
            try
            {
                float net = 0.0f;
                objSaleInvoiceBAL.objSaleObject.DiscountText = ((objSaleInvoiceBAL.objSaleObject.DiscountText == string.Empty) || (objSaleInvoiceBAL.objSaleObject.DiscountText == ".")) ? "0.000" : objSaleInvoiceBAL.objSaleObject.DiscountText;
                objSaleInvoiceBAL.objSaleObject.actualdiscount = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.DiscountText);
                if ((objSaleInvoiceBAL.objSaleObject.TotalText != "") && (objSaleInvoiceBAL.objSaleObject.DiscountText != ""))
                {
                    if (objSaleInvoiceBAL.objSaleObject.ValueChecked == true)
                    {
                        objSaleInvoiceBAL.objSaleObject.totalpercentage = float.Parse(objSaleInvoiceBAL.objSaleObject.DiscountText);
                        net = float.Parse(objSaleInvoiceBAL.objSaleObject.TotalText) - float.Parse(objSaleInvoiceBAL.objSaleObject.DiscountText);
                        objSaleInvoiceBAL.objSaleObject.discount = objSaleInvoiceBAL.objSaleObject.totalpercentage;
                        objSaleInvoiceBAL.objSaleObject.discounttype = 1; //"V";
                    }
                    else if (objSaleInvoiceBAL.objSaleObject.PercentageChecked == true)
                    {
                        float value = (float.Parse(objSaleInvoiceBAL.objSaleObject.TotalText) * float.Parse(objSaleInvoiceBAL.objSaleObject.DiscountText)) / 100;
                        objSaleInvoiceBAL.objSaleObject.totalpercentage = float.Parse(value.ToString());
                        net = float.Parse(objSaleInvoiceBAL.objSaleObject.TotalText) - value;
                        objSaleInvoiceBAL.objSaleObject.discount = objSaleInvoiceBAL.objSaleObject.totalpercentage;
                        objSaleInvoiceBAL.objSaleObject.discounttype = 2; // "P";
                    }
                    //Txt_net.Text = net.ToString("####0.000");
                    objSaleInvoiceBAL.objSaleObject.NetText = net.ToString("####0.000");

                }

            }
            catch (Exception ex) { throw ex; }

        }
        #endregion

        #region Taxcalculation
        public void Taxcalculation()
        {
            try
            {
                string Tax1percent, Tax1subpercent, Tax2percent, Tax2subpercent;
                decimal Tax1amountpercent = 0, Tax1amountsubpercent = 0, Tax2amountpercent = 0, Tax2amountsubpercent = 0;
                Tax1percent = GeneralOptionSetting.FlagTax1_Percentage;
                Tax1subpercent = GeneralOptionSetting.FlagTax1_SubPercentage;
                Tax2percent = GeneralOptionSetting.FlagTax2_Percentage;
                Tax2subpercent = GeneralOptionSetting.FlagTax2_SubPercentage;
                if ((objSaleInvoiceBAL.objSaleObject.TotalText != "") && (objSaleInvoiceBAL.objSaleObject.NetText != "") && (objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked == true))
                {
                    if ((GeneralOptionSetting.FlagTax1_ApplySales == "Y") && (Tax1percent != "0"))
                    {

                        Tax1amountpercent = (GeneralOptionSetting.FlagTax1_ApplyBeforeDiscount == "Y") ? ((Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.TotalText) * Convert.ToDecimal(Tax1percent)) / 100) : ((Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.NetText) * Convert.ToDecimal(Tax1percent)) / 100);
                        Tax1amountsubpercent = (Tax1amountpercent != 0) ? ((Tax1amountpercent * Convert.ToDecimal(Tax1subpercent)) / 100) : 0;
                        objSaleInvoiceBAL.objSaleObject.taxsub = Tax1amountsubpercent;
                        objSaleInvoiceBAL.objSaleObject.tax = Tax1amountpercent + Tax1amountsubpercent;
                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.tax = 0;
                        objSaleInvoiceBAL.objSaleObject.taxsub = 0;
                    }
                    if ((GeneralOptionSetting.FlagTax2_ApplySales == "Y") && (Tax2percent != "0"))
                    {

                        Tax2amountpercent = (GeneralOptionSetting.FlagTax2_ApplyBeforeDiscount == "Y") ? ((Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.TotalText) * Convert.ToDecimal(Tax2percent)) / 100) : ((Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.NetText) * Convert.ToDecimal(Tax2percent)) / 100);
                        Tax2amountsubpercent = (Tax2amountpercent != 0) ? ((Tax2amountpercent * Convert.ToDecimal(Tax2subpercent)) / 100) : 0;
                        objSaleInvoiceBAL.objSaleObject.tax1sub = Tax2amountsubpercent;
                        objSaleInvoiceBAL.objSaleObject.tax1 = Tax2amountpercent + Tax2amountsubpercent;
                    }
                    else
                    {
                        objSaleInvoiceBAL.objSaleObject.tax1 = 0;
                        objSaleInvoiceBAL.objSaleObject.tax1sub = 0;
                    }
                }
                else
                {
                    objSaleInvoiceBAL.objSaleObject.tax = 0;
                    objSaleInvoiceBAL.objSaleObject.taxsub = 0;
                    objSaleInvoiceBAL.objSaleObject.tax1 = 0;
                    objSaleInvoiceBAL.objSaleObject.tax1sub = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region AgentDiscountCalc
        public void AgentDiscountCalc()
        {
            if (objSaleInvoiceBAL.objSaleObject.agentdiscount != null)
            {
                if (objSaleInvoiceBAL.objSaleObject.agentdiscount.ToString() != "Yes")
                {
                    if (objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText != "")
                        objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText);
                    Decimal Discount = 0;
                    Discount = GetAgentDiscountHelper();
                    if (Discount != 0)
                    {
                        objSaleInvoiceBAL.objSaleObject.DiscountText = (Discount != 0) ? Discount.ToString() : "";
                        //Txt_discount.Text = dt.Rows[0]["mtb_discount"].ToString();
                        objSaleInvoiceBAL.objSaleObject.PercentageChecked = true;
                        //  radio_Percentage.Checked = true;

                    }
                }
            }
            objSaleInvoiceBAL.objSaleObject.includetax = (objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked == true) ? 1 : 0;


        }
        #endregion

        #endregion

        #region Modify Invoice





        #endregion

        #region PriceClick

        public void PriceClick()
        {
            try
            {
                if (objSaleInvoiceBAL.objSaleObject.itemname != "")
                {
                    objSaleInvoiceBAL.objSaleObject.itemid = objSaleInvoiceBAL.objSaleObject.ItemNo;

                    if (ButtonClick == -1)
                    {
                        ButtonClick = 0;
                        PriceType = "NormalPrice";
                        PriceChanging();
                    }
                    else if (ButtonClick == 0)
                    {
                        ButtonClick = 2;
                        PriceType = "WholeSalePrice";
                        if (UserScreenLimidations.WholeSale)
                            PriceChanging();
                        else
                            GeneralFunction.Information("NoRightsWholesalePrice", "SalesInvoice");

                    }
                    else if (ButtonClick == 2)
                    {
                        ButtonClick = -1;
                        PriceType = "MinimumPrice";

                        if (UserScreenLimidations.MinimumPrice)
                            PriceChanging();
                        else
                            GeneralFunction.Information("NoRightsMinimumPrice", "SalesInvoice");

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region PriceChanging
        public void PriceChanging()
        {
            try
            {
                List<SaleObject> lstAllPrices = GetItemMinPriceHelper();
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
                    ModPrice = (objSaleInvoiceBAL.objSaleObject.IsPackage == false) ? Price : (Price / Package);
                    // objSaleInvoiceBAL.objSaleObject.PriceText = ModPrice.ToString("#####0.000"); // Commented on 16/May-2014
                    //objSaleInvoiceBAL.objSaleObject.BoxPrice = Price; // Commented on 16/May-2014
                    objSaleInvoiceBAL.objSaleObject.PriceText = (Math.Truncate(Convert.ToDecimal(ModPrice) * 1000M) / 1000M).ToString();
                    objSaleInvoiceBAL.objSaleObject.BoxPrice = Price;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        #endregion

        #region CheckBalanceForSaleInvoice
        public Boolean CheckBalanceForSaleInvoice()
        {

            objSaleInvoiceBAL.objSaleObject.balance = 0;

            List<SaleObject> lstBalance = GetBalanceForSaleInvoiceHelper();

            if (lstBalance.Count > 0)
            {

                Decimal Balance = lstBalance[0].balance;
                if (Balance > 0)
                {
                    objSaleInvoiceBAL.objSaleObject.balance = Balance;
                    return true;
                }
                else
                    return false;

            }
            else
            {
                return false;
            }

        }
        #endregion

        #region CheckClosedInvoice
        public Boolean CheckClosedInvoice()
        {
            int Status = 1;
            Status = CheckClosedInvoiceHelper();
            if (Status == 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region ReceiveReceiptClick

        public void ReceiveReceiptClick()
        {
            objSaleInvoiceBAL.objSaleObject.balance = 0;

            if (CheckClosedInvoice())
            {
                if (CheckBalanceForSaleInvoice())
                {
                    Receive_Receipt ObjFrm = new Receive_Receipt();
                    ObjFrm.ReceivedFrom = objSaleInvoiceBAL.objSaleObject.CmbClientText;  //cmb_client.Text;
                    if ((objSaleInvoiceBAL.objSaleObject.balance > 0)) //(obj_saleinvoice.balance != null) && 
                    {
                        ObjFrm.NetAmt = objSaleInvoiceBAL.objSaleObject.balance.ToString();
                        // ObjFrm.MTxt_Value.Text = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.balance).ToString("####0.000");
                        ObjFrm.Value = Convert.ToDecimal(objSaleInvoiceBAL.objSaleObject.balance).ToString("####0.000");
                    }
                    else
                    {
                        ObjFrm.NetAmt = (objSaleInvoiceBAL.objSaleObject.NetText != string.Empty) ? objSaleInvoiceBAL.objSaleObject.NetText : "0.000";
                        //  ObjFrm.MTxt_Value.Text = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.NetText != string.Empty) ? objSaleInvoiceBAL.objSaleObject.NetText : "0.000").ToString("####0.000");
                        ObjFrm.Value = Convert.ToDecimal((objSaleInvoiceBAL.objSaleObject.NetText != string.Empty) ? objSaleInvoiceBAL.objSaleObject.NetText : "0.000").ToString("####0.000");
                    }

                    ObjFrm.Tag = "SaleInvoice";
                    //  ObjFrm.MTxt_Discription.Text = "SaleInvoice" + " " + objSaleInvoiceBAL.objSaleObject.InvoiceNoText.ToString();
                    //ObjFrm.Description = GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoiceNo") + " " + objSaleInvoiceBAL.objSaleObject.InvoiceNoText.ToString();
                    ObjFrm.Description = GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoiceNo") + " " + objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo.ToString();
                    ObjFrm.ReceiptNo = objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                    // ObjFrm.MTxt_Balance.Text = "0.000";
                    // ObjFrm.Balance = "0.000";
                    ObjFrm.ShowDialog();
                }
            }
        }

        #endregion

        #region Print

        #region CheckPrint
        public void CheckPrint(DataGridView datagrid_saleinvoice)
        {
            try
            {
                if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") & (datagrid_saleinvoice.BackgroundColor == Color.Gray))
                    Print();
                else if (GeneralOptionSetting.FlagPrintAfterClosingInvoice != "Y")
                    Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
        #endregion


        #region Print
        public void Print()
        {
            ReportsView frmView = new ReportsView();
            //Rpt_SimpleInvoiceWithoutDiscount_A4Landscape Summary = new Rpt_SimpleInvoiceWithoutDiscount_A4Landscape();
            //Rpt_SimpleInvoiceWithoutTax Summary = new Rpt_SimpleInvoiceWithoutTax();
            CurrencyConverter ObjCC = new CurrencyConverter();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("SalesInvoice");
            //  Summary.Refresh();
            DataTable dt = new DataTable("SimpleInvoice");
            dt = objSaleInvoiceBAL.GetSalesPrintReportBal();
            decimal Total = 0.000M;
            DataTable dtLocal = new DataTable("SimpleInvoice");
            if (dt.Rows.Count > 0)
            {
                dt = GeneralFunction.SortInvoiceDetails(dt, "item", "saleprice");
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["client"].ToString());
                GeneralFunction.AgentDept();
            }
            if (dtLocal.Columns.Count < 22)
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
                dtLocal.Columns.Add("StreetAddress");
                dtLocal.Columns.Add("Address2");
                dtLocal.Columns.Add("PhoneNo2");
                dtLocal.Columns.Add("Barcode");
                dtLocal.Columns.Add("DiscountPercentage", typeof(decimal));
                dtLocal.Columns.Add("Package", typeof(int));
                dtLocal.Columns.Add("PaymentCharges", typeof(decimal));
                dtLocal.Columns.Add("PaidAmount",typeof(decimal));
                dtLocal.Columns.Add("Remaining",typeof(decimal));
                dtLocal.Columns.Add("UnitAndPakg");
                //dtLocal.Columns.Add("AdvanceAmount", typeof(decimal));
            }


            string tax1 = "0.000", tax2 = "0.000", paramtax1 = "0.000", paramtax2 = "0.000", actualtotal1, actualtotal2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();

                drAdd["InvoiceName"] = "Sale Invoice";
                drAdd["InvoiceNo"] = dt.Rows[i]["newinvno"].ToString();
                drAdd["InvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["sdate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);//.ToShortDateString();
                drAdd["CustomerId"] = dt.Rows[i]["client"].ToString();
                string ClientName = string.Empty;
                if (Convert.ToInt32(CommonHelper.CashClientID.ID) == Convert.ToInt32(dt.Rows[i]["client"]))
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        ClientName = "CASH CLIENT";
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                        ClientName = "زبون نقدي";
                }
                if (ClientName == string.Empty)
                    drAdd["CustomerName"] = dt.Rows[i]["clientname"].ToString();
                else
                    drAdd["CustomerName"] = ClientName;
                drAdd["ItemNo"] = dt.Rows[i]["itemno"].ToString();
                drAdd["ItemName"] = dt.Rows[i]["item"].ToString();
                if (dt.Rows[i]["expiry"].ToString() == "-" || dt.Rows[i]["expiry"] == DBNull.Value)
                {
                    drAdd["Expiry"] = dt.Rows[i]["expiry"];
                }
                else
                {
                    drAdd["Expiry"] = Convert.ToDateTime(dt.Rows[i]["expiry"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                }
                drAdd["Quantity"] = dt.Rows[i]["qty"].ToString();
                drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["saleprice"].ToString());
                //// Code Commit by T (try to fixed discount issue) on 13-June-2019
                //decimal dis = GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y" ? 0 : Convert.ToDecimal(dt.Rows[i]["discount"]);
                ////

                //if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y" || dis == 0)
                //{
                //    if (Convert.ToInt32(dt.Rows[i]["qty"]) % Convert.ToInt32(dt.Rows[i]["Package"]) == 0) //Added on 28-Oct-2014
                //    {
                //        drAdd["Total"] = (Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) / (Convert.ToDecimal(dt.Rows[i]["Package"]) != 0 ? Convert.ToDecimal(dt.Rows[i]["Package"]) : 1)) * Convert.ToDecimal(dt.Rows[i]["ActualPrice"].ToString()); 
                //    }
                //    else
                //    {
                //        drAdd["Total"] = (Convert.ToDecimal(dt.Rows[i]["qty"]) * Convert.ToDecimal(dt.Rows[i]["saleprice"].ToString()));
                //    }
                //}
                //else if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem != "Y" && dis != 0)
                //{
                //    drAdd["Total"] = (Convert.ToDecimal(dt.Rows[i]["qty"]) * Convert.ToDecimal(dt.Rows[i]["saleprice"].ToString()));
                //}
                //drAdd["AdvanceAmount"] = Convert.ToDecimal(dt.Rows[i]["Package"]) > 1 ? ((Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) / Convert.ToDecimal(dt.Rows[i]["Package"].ToString())) * Convert.ToDecimal(dt.Rows[i]["ActualPrice"].ToString())) : Convert.ToDecimal(dt.Rows[i]["total"].ToString());
                ////// End Now
                drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["Package"]) > 1 ? ((Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) / Convert.ToDecimal(dt.Rows[i]["Package"].ToString()))* Convert.ToDecimal(dt.Rows[i]["ActualPrice"].ToString())): Convert.ToDecimal(dt.Rows[i]["total"].ToString());// Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) * Convert.ToDecimal(dt.Rows[i]["saleprice"].ToString());  (It was add 4May2019) on 10-June-2019 By T Commit this because it causing issue// //Convert.ToDecimal(dt.Rows[i]["total"].ToString());//


                actualtotal1 = (GeneralOptionSetting.FlagTax1_ApplyBeforeDiscount == "Y") ? Convert.ToDecimal(dt.Rows[i]["netamount1"].ToString()).ToString("#####0.000") : Convert.ToDecimal(dt.Rows[i]["actualnet"].ToString()).ToString("#####0.000");
                actualtotal2 = (GeneralOptionSetting.FlagTax2_ApplyBeforeDiscount == "Y") ? Convert.ToDecimal(dt.Rows[i]["netamount1"].ToString()).ToString("#####0.000") : Convert.ToDecimal(dt.Rows[i]["actualnet"].ToString()).ToString("#####0.000");
                decimal secondtax = Convert.ToDecimal(dt.Rows[i]["mtb_tax1"].ToString()) - Convert.ToDecimal(Convert.ToDecimal(dt.Rows[i]["mtb_tax1_sub"].ToString()).ToString("######0.000"));
                decimal firsttax = Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()) - Convert.ToDecimal(dt.Rows[i]["mtb_tax_sub"].ToString());
                if (actualtotal1 != "0.000")
                {

                    if (firsttax != 0)
                    {
                        if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "0")
                            tax1 = Convert.ToDecimal((firsttax / (Convert.ToDecimal(actualtotal1) - firsttax - secondtax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax_sub"].ToString()) / Convert.ToDecimal(firsttax)) * 100).ToString("0.000") + "" + "%";
                        else if ((GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "-1"))
                            tax1 = Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()).ToString("#####0.000");
                        else if (GeneralOptionSetting.FlagTax1_ShowTaxInvoice == "2")
                            tax1 = Convert.ToDecimal((firsttax / (Convert.ToDecimal(actualtotal1) - firsttax - secondtax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax_sub"].ToString()) / Convert.ToDecimal(firsttax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()).ToString("#####0.000");
                        else
                            //tax1 = "0.000";//Commented on 1-July-2014 by Seenivasan for giving empty for "Dont Show Tax" Option Setting 
                            tax2 = "";
                    }
                    paramtax1 = Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString()).ToString("#####0.000");
                }
                else
                    tax1 = "0.000";


                if (actualtotal2 != "0.00")
                {

                    if (secondtax != 0)
                    {
                        if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "0")
                            tax2 = Convert.ToDecimal((secondtax / (Convert.ToDecimal(actualtotal2) - firsttax - secondtax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax1_sub"].ToString()) / Convert.ToDecimal(secondtax)) * 100).ToString("0.000") + "" + "%";
                        else if ((GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "1") || (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "-1"))
                            tax2 = Convert.ToDecimal(dt.Rows[i]["mtb_tax1"].ToString()).ToString("#####0.000");
                        else if (GeneralOptionSetting.FlagTax2_ShowTaxInvoice == "2")
                            tax2 = Convert.ToDecimal((secondtax / (Convert.ToDecimal(actualtotal2) - firsttax - secondtax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["mtb_tax1_sub"].ToString()) / Convert.ToDecimal(secondtax)) * 100).ToString("0.000") + "" + "%" + "," + Convert.ToDecimal(dt.Rows[i]["mtb_tax1"].ToString()).ToString("#####0.000");
                        else
                            tax2 = "";
                    }
                    paramtax2 = Convert.ToDecimal(dt.Rows[i]["mtb_tax1"].ToString()).ToString("#####0.000");
                }
                else
                    tax2 = "0.000";

                drAdd["Tax1"] = tax1;
                drAdd["Tax2"] = tax2;
                drAdd["Discount"] = Convert.ToDecimal(dt.Rows[i]["discount"].ToString());
                drAdd["MaxDept"] = Convert.ToDecimal(dt.Rows[i]["debtlimit"].ToString() != "" ? dt.Rows[i]["debtlimit"] : 0);
                drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                drAdd["Users"] = dt.Rows[i]["users"].ToString();
                drAdd["TotalLetters"] = "";
                String UnitName = dt.Rows[i]["UnitName"].ToString();
                drAdd["Unit"] = UnitName != null ? UnitName.Split('-').First().ToString() : "";
                drAdd["LastInvoiceDate"] = (dt.Rows[i]["LastInvoiceDate"].ToString() != "") ? Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"].ToString()) : Convert.ToDateTime(dt.Rows[i]["sdate"].ToString());
                drAdd["AmountDue"] = (dt.Rows[i]["lastinvoice"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["lastinvoice"].ToString()) : Convert.ToDecimal(0.0));
                // drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString(); 
                drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();
                drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                //drAdd["DiscountPercentage"] = (Convert.ToDecimal(dt.Rows[i]["discount"].ToString()) /Total)*100;
                Total += Convert.ToDecimal(dt.Rows[i]["total"].ToString());
                Total = Convert.ToDecimal(dt.Rows[i]["NetAmount"].ToString());
                if (Total == 0) { Total = 1; }
                // drAdd["DiscountPercentage"] = (Convert.ToDecimal(dt.Rows[i]["mtb_total_discount"].ToString()) / Total) * 100;
                drAdd["DiscountPercentage"] = Convert.ToDecimal(dt.Rows[i]["mtb_total_discount"].ToString());
                drAdd["Package"] = (Convert.ToInt32((dt.Rows[i]["Package"] != DBNull.Value ? dt.Rows[i]["Package"] : "0").ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["Package"].ToString()) : 1);
                drAdd["PaymentCharges"] = Convert.ToDecimal(dt.Rows[i]["PaymentCharges"].ToString());
                drAdd["PaidAmount"] = Convert.ToDecimal(dt.Rows[i]["balance"].ToString());
                drAdd["Remaining"] = Convert.ToDecimal((Convert.ToDecimal(dt.Rows[i]["qty"].ToString()) * Convert.ToDecimal(dt.Rows[i]["saleprice"].ToString())) -Convert.ToDecimal(dt.Rows[i]["balance"].ToString()));

                UnitName = dt.Rows[i]["UnitName"].ToString();
                drAdd["UnitAndPakg"] = UnitName != "" ? UnitName.Split('-').First().ToString() : Convert.ToString(dt.Rows[i]["Package"].ToString()); /*(dt.Rows[i]["UnitName"].ToString().Split('-').First());*/
                
                dtLocal.Rows.Add(drAdd);
            }


            if (dtLocal.Rows.Count > 0)
            {
                OptionSettingBAL objOptionBal = new OptionSettingBAL();
                DataTable Dt_CompanyInfo = new DataTable();
                //Dt_CompanyInfo = objOptionBal.Get_CompanyLogoDetails();this Function moved into General Function
                if (GeneralFunction.CashClientName != string.Empty && Sales_Invoice.CheckCashClientName == 1)
                {
                    dtLocal.Rows[0]["CustomerName"] = GeneralFunction.CashClientName;
                }
                //else if (GeneralFunction.CashClientName == string.Empty && Sales_Invoice.CheckCashClientName == 1)
                //{

                //    frmView.HTable.Add("InvoiceName", "Cash Client");
                //}
                frmView.Report_Table = dtLocal;
                // frmView.CompanyLogo_Table = Dt_CompanyInfo;Commented On 17-March-2014
                frmView.HTable.Clear();
                //if (GeneralOptionSetting.FlagInvoiceTemplate == "0" || GeneralOptionSetting.FlagInvoiceTemplate == "4" || GeneralOptionSetting.FlagInvoiceTemplate == "8" || GeneralOptionSetting.FlagInvoiceTemplate == "12" || GeneralOptionSetting.FlagInvoiceTemplate == "13")
                //{
                frmView.HTable.Add("note", objSaleInvoiceBAL.objSaleObject.ChkNoteChecked == true ? objSaleInvoiceBAL.objSaleObject.NotesText : "");
                // frmView.HTable.Add("note", "");
                //}
                //else
                //{
                if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                {
                    decimal TotalWithpaymentCharges = (Convert.ToDecimal((dt.Rows[0]["PaymentCharges"].ToString()))+Total);
                    frmView.HTable.Add("TotalLetters", ObjCC.Convert(TotalWithpaymentCharges.ToString("####0.000")));
                }

                DataTable dtPaidRemain = new DataTable("PaidRemain");
                dtPaidRemain = objSaleInvoiceBAL.GetSalesPaidRemainingBal();

                if (dtPaidRemain.Rows.Count > 0 )
                {
                    frmView.HTable.Add("Paid", dtPaidRemain.Rows.Count > 0 ? dtPaidRemain.Rows[0][2] : 0.0);
                    frmView.HTable.Add("Remaining", dtPaidRemain.Rows.Count > 0 ? dtPaidRemain.Rows[0][0] : 0.0);

                    

                }
                else
                {
                    frmView.HTable.Add("Paid", 0.0);
                    frmView.HTable.Add("Remaining", 0.0);
                    if (frmView.RptDoc is Rpt_Invoice_80mm)
                    {
                        frmView.HTable.Add("PaidAmount",0.0);
                        frmView.HTable.Add("Refund", 0.0);
                    }
                }

                frmView.HTable.Add("IncludeTax", objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked ? "Yes" : "No");
                frmView.HTable.Add("Tax1", paramtax1 != string.Empty ? paramtax1 : "0.000");
                frmView.HTable.Add("Tax2", paramtax2 != string.Empty ? paramtax2 : "0.000");
                frmView.HTable.Add("optionnote", GeneralOptionSetting.FlagNoteSaleInvoice);
                frmView.HTable.Add("InvoiceName", Additional_Barcode.GetValueByResourceKey("SalesInvoice"));
                if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                {
                    frmView.HTable.Add("monthformat", 0);
                    frmView.HTable.Add("dayformat", 0);
                    frmView.HTable.Add("yearformat", 0);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 0);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 1);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "-");
                    frmView.HTable.Add("dateformat", 0);
                }
                else
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 0);
                }
                frmView.HideLogo = objSaleInvoiceBAL.objSaleObject.HideLogChecked;
                var debtValue = GeneralOptionSetting.FlagShowDeptOnPrint;
                frmView.HideDebt = objSaleInvoiceBAL.objSaleObject.HideDebtChecked;
                if (GeneralOptionSetting.FlagShowDeptOnPrint == "Y")
                    GeneralOptionSetting.FlagShowDeptOnPrint = frmView.HideDebt == true ? "N" : "Y";
                frmView.RptDoc = OrderInvoiceHelper.ReportSelection();

                if (frmView.RptDoc is Rpt_Invoice_80mm)
                {
                    frmView.HTable.Add("PaidAmount", dtPaidRemain.Rows[0][2]);
                    frmView.HTable.Add("Refund", dtPaidRemain.Rows[0][0]);
                }
                if (frmView.RptDoc is Rpt_Invoice_80mm || frmView.RptDoc is Rpt_Invoice_63mm)
                {
                    frmView.HTable.Remove("monthformat");
                    frmView.HTable.Remove("dayformat");
                    frmView.HTable.Remove("yearformat");
                    frmView.HTable.Remove("seperatorformat");
                    frmView.HTable.Remove("dateformat");
                    if (frmView.RptDoc is Rpt_Invoice_80mm)
                    {
                        frmView.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? true : false);
                        frmView.RptDoc.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(100, 250, 144, 250));
                    }
                }
                if (frmView.RptDoc is Rpt_InvTemplate1 || frmView.RptDoc is Rpt_InvTemplate2 || frmView.RptDoc is Rpt_InvTemplate3 || frmView.RptDoc is Rpt_InvTemplate4 || frmView.RptDoc is Rpt_InvTemplate5 || frmView.RptDoc is Rpt_InvTemplate6 || frmView.RptDoc is Rpt_InvTemplate7)
                {
                    //if (Convert.ToDecimal(dt.Rows[0]["Discount"]) != 0.0m && GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y" && GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
                    //{
                    //    frmView.HTable.Add("HideDiscount", false);
                    //}
                    //else
                    if (Convert.ToDecimal(dt.Rows[0]["Discount"]) != 0.0m && GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem != "Y")
                    {
                        frmView.HTable.Add("HideDiscount", false);
                    }
                    else
                    {
                        frmView.HTable.Add("HideDiscount", true);
                    }
                    frmView.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);

                }
                frmView.isInvoice = true; // Edited by MRS 12/27/2018
                //frmView.InvoiceName = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
                frmView.InvoiceName = "SaleInvoice";
                frmView.LoadEvent();
                //Following code Added on 24-June-2014 for Printing Receipt when PrintPreview Checked false by Seenivasan
                if (objSaleInvoiceBAL.objSaleObject.PrintPreviewChecked)
                {
                    frmView.ShowDialog();
                }
                else
                {
                    // Printer Setup Handling Add these Lines
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = GeneralFunction.PrinterName("Invoice");
                    printerSettings.Copies = Convert.ToInt16(GeneralFunction.NoofPrint);
                    frmView.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false);
                    // 

                    //frmView.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                }
                GeneralOptionSetting.FlagShowDeptOnPrint = debtValue;

            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "Sales Invoice");
            }


        }
        #endregion


        #endregion

        #region SetList
        public void SetList(List<SaleObject> lstInvDetailsExtnd)
        {
            if (lstInvDetailsExtnd.Count > 0)
            {
                for (int i = 0; i <= lstInvDetailsExtnd.Count; i--)
                {
                    lstSaleDetailExtended.Add(new SaleObject
                    {
                        itemid = lstInvDetailsExtnd[i].itemid,
                        ItemDescription = lstInvDetailsExtnd[i].ItemDescription,
                        ItemExpiryDate = (Expiryformat(lstInvDetailsExtnd[i].ItemExpiryDate.ToShortDateString()) == false) ? Convert.ToDateTime(null) : lstInvDetailsExtnd[i].ItemExpiryDate,
                        ItemPackage = Convert.ToInt16(lstInvDetailsExtnd[i].ItemPackage),
                        quantity = lstInvDetailsExtnd[i].quantity,
                        unitprice = Convert.ToDecimal(lstInvDetailsExtnd[i].unitprice.ToString("#####0.000")),
                        TotalPrice = Convert.ToDecimal(lstInvDetailsExtnd[i].TotalPrice.ToString("######0.000")),
                        ModifiedDate = Convert.ToDateTime((GeneralOptionSetting.FlagHideItemSaleTimeInInvoice != "Y") ? DateTime.Now.ToLongTimeString() : "00:00"),
                        user = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? GeneralFunction.UserName : "",
                        ReturnQty = lstInvDetailsExtnd[i].ReturnQty,
                        ClientID = lstInvDetailsExtnd[i].ClientID,
                        saledetid = lstInvDetailsExtnd[i].saledetid,
                        saleid = lstInvDetailsExtnd[i].saleid,
                        itemdiscount = lstInvDetailsExtnd[i].itemdiscount,
                        serialno = lstInvDetailsExtnd[i].serialno,
                        Newexpr = lstInvDetailsExtnd[i].Newexpr,
                        ActualPrice = Convert.ToDecimal(lstInvDetailsExtnd[i].ActualPrice.ToString("#####0.000")),
                        tax = lstInvDetailsExtnd[i].tax,
                        Subtotal = Convert.ToDecimal(lstInvDetailsExtnd[i].TotalPrice.ToString("######0.000")),//Added on 14-May-2014
                        Box = lstInvDetailsExtnd[i].quantity / (lstInvDetailsExtnd[i].ItemPackage != 0 ? lstInvDetailsExtnd[i].ItemPackage : 1),
                        StrItemNo = lstInvDetailsExtnd[i].StrItemNo,
                        StrExpiryDate = lstInvDetailsExtnd[i].StrExpiryDate
                    });
                }
            }
        }
        #endregion


        #region GetDetailsOfItem
        public List<SaleObject> GetDetailsOfItem()
        {

            return objSaleInvoiceBAL.Get_ItemDetails();
        }
        #endregion

        #endregion




        public void GetMaxIDOFReceiptDetails()
        {

            object GetMaxID;
            GetMaxID = objSaleInvoiceBAL.GetReceiptMaxId();///get the  max id of receive receipt details 
            int CheckMaxId = Convert.ToInt32(GetMaxID);
            if (CheckMaxId == 0)
            {

                //objSaleInvoiceBAL.InsertReceiptID();//Commented on 11-June-2014
                EmptyRecordForReceiveReceipt();//Added on 11-June-2014
                CashClientDetails();
                EmptyRecordForReceiveReceipt();
            }
            else
            {
                if (objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID != 3)
                {
                    CashClientDetails();
                    EmptyRecordForReceiveReceipt();
                }

            }

        }



        public void EmptyRecordForReceiveReceipt()
        {

            objSaleInvoiceBAL.InsertReceiptID();
            objSaleInvoiceBAL.objSaleObject.receiptdiscription = string.Empty;
            objSaleInvoiceBAL.objSaleObject.receiptdiscriptionarabic = string.Empty;
            objSaleInvoiceBAL.objSaleObject.mtbreceiptfor = Convert.ToInt32(ReceiveReceiptFor.Receivable);
            objSaleInvoiceBAL.objSaleObject.status = 1;
            objSaleInvoiceBAL.objSaleObject.createdby = GeneralFunction.UserId;
            objSaleInvoiceBAL.objSaleObject.modifiedby = GeneralFunction.UserId;

            //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************
            long SaleID = objSaleInvoiceBAL.objSaleObject.saleid;
            long SaleInvoice = objSaleInvoiceBAL.objSaleObject.saleinv;
            Decimal Netamount = objSaleInvoiceBAL.objSaleObject.netamount;
            int ClientID = objSaleInvoiceBAL.objSaleObject.ClientID;
            objSaleInvoiceBAL.objSaleObject.saleid = 0;
            objSaleInvoiceBAL.objSaleObject.saleinv = 0;
            objSaleInvoiceBAL.objSaleObject.netamount = 0;
            objSaleInvoiceBAL.objSaleObject.ClientID = 0;
            objSaleInvoiceBAL.objSaleObject.receive_amtreceived = 0;
            //**************Added on 4-June-2014 for Creating Empty Receipt Record in Customer Receipt Table*****************
            objSaleInvoiceBAL.Savecashclientreceipt();

            objSaleInvoiceBAL.objSaleObject.saleid = SaleID;
            objSaleInvoiceBAL.objSaleObject.saleinv = SaleInvoice;
            objSaleInvoiceBAL.objSaleObject.netamount = Netamount;
            objSaleInvoiceBAL.objSaleObject.ClientID = ClientID;
        }
        public void CashClientDetails()
        {

            BalanceCalculation();
            objSaleInvoiceBAL.objSaleObject.PaymentMethodID = objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID == 1 ? 101 : objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID == 2 ? 103 : 101;
            objSaleInvoiceBAL.objSaleObject.receive_amtreceived = objSaleInvoiceBAL.objSaleObject.net + objSaleInvoiceBAL.objSaleObject.paymentCharges;//Should calculate balance amount

            objSaleInvoiceBAL.objSaleObject.createdby = GeneralFunction.UserId;
            objSaleInvoiceBAL.objSaleObject.modifiedby = GeneralFunction.UserId;
            // Comment on 13 Dec 2018
            //objSaleInvoiceBAL.objSaleObject.receiptdiscription = "SaleInvoice " + objSaleInvoiceBAL.objSaleObject.saleid;
            //objSaleInvoiceBAL.objSaleObject.receiptdiscriptionarabic = "فاتورة مبيعات" + objSaleInvoiceBAL.objSaleObject.saleid;

            objSaleInvoiceBAL.objSaleObject.receiptdiscription = "SaleInvoice " + objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo;
            objSaleInvoiceBAL.objSaleObject.receiptdiscriptionarabic = "فاتورة مبيعات" + objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo;

            //objSaleInvoiceBAL.objSaleObject.mtbreceiptfor = Convert.ToInt32(ReceiveReceiptFor.Receivable);//Commented on 26-June-2014 by Seenivasan for Sale Invoice Recipt for should be "5" not as "2"
            objSaleInvoiceBAL.objSaleObject.mtbreceiptfor = Convert.ToInt32(ReceiveReceiptFor.SaleInvoice);//Added on 26-June-2014 by Seenivasan
            objSaleInvoiceBAL.objSaleObject.status = 1;

            objSaleInvoiceBAL.Savecashclientreceipt();


        }
        public void BalanceCalculation()
        {


            decimal decBalance = 0, decTotal = 0;

            objSaleInvoiceBAL.objSaleObject.BalanceAgent = objSaleInvoiceBAL.objSaleObject.ClientID;
            objSaleInvoiceBAL.objSaleObject.BalanceFromDate = DateTime.Now;
            objSaleInvoiceBAL.objSaleObject.BalanceToDate = DateTime.Now;
            objSaleInvoiceBAL.objSaleObject.BalanceStatus = 1;
            // List<SaleObject> lstBalance = objSaleInvoiceBAL.GetBalanceBal();//commented by Prabhakaran.S due to delay
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

            decimal Balance = objSaleInvoiceBAL.GetBalance(); //added new sp for getting balancesheet for cash client
            objSaleInvoiceBAL.objSaleObject.netamount = Balance;
        }
        public void ItemDetailsUpdation(int XStockInHand, decimal XPrice, int XBox, DateTime? XExpiryDate, string XSerialNo, int XBarcodeID)
        {
            objSaleInvoiceBAL.UpdateSalesDetails(XStockInHand, XPrice, XBox, XExpiryDate, XSerialNo, XBarcodeID);
        }
        public DataTable GetSalesItemDetails()
        {
            return objSaleInvoiceBAL.GetSaleItem();
        }
    }
}
