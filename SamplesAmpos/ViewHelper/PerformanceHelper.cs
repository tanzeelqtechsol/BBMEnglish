using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using BALHelper;
using CommonHelper;
using System.Windows.Forms;
using System.Drawing;
using BumedianBM.ArabicView;
using System.Data;
using System.Configuration;
using BumedianBM.CrystalReports;

namespace BumedianBM.ViewHelper
{
    class PerformanceHelper
    {

        #region Declaration
        PerformanceBAL objPerformBAL;
        internal List<AgentDetailObjectClass> lstClientList = new List<AgentDetailObjectClass>();
        public List<SaleObject> lstItemDetails = new List<SaleObject>();
        public List<SaleObject> lstItemExpirydates = new List<SaleObject>();
        internal List<long> InvoiceID = new List<long>();
        SalesInvoiceHelper objSaleInvoiceHelper;
        CustomNotesAlerts objCustomAlert;
        public Boolean ispackage = false;
        public int PackageQty = 0;
        public int StockOnHand = 0;
        public decimal CurrentPrice = 0.000M;
        public List<SaleObject> lstOrderInvDetails = new List<SaleObject>();
        public List<SaleObject> lstGridDetails = new List<SaleObject>();
        public int CurrentYear = 0;
        public DateTime Modifydate;
        internal Item_Information ObjItemInfo;
        internal int IDFlag;
        internal List<long> ID = new List<long>();
        internal List<long> SaleInvoiceID = new List<long>();
        OrderInvoiceBALClass objBalClass;
        #endregion

        #region Constructor
        public PerformanceHelper()
        {
            objPerformBAL = new PerformanceBAL();
            objSaleInvoiceHelper = new SalesInvoiceHelper();
            objCustomAlert = new CustomNotesAlerts();
            ObjItemInfo = new Item_Information();
            objBalClass = new OrderInvoiceBALClass();
        }
        #endregion

        #region Getting Performance BAL Class in Helper
        public PerformanceBAL objPerfrmnceBal
        {
            get { return objPerformBAL; }
            set { objPerformBAL = value; }
        }

        public OrderInvoiceBALClass ObjBALClass
        {
            get { return objBalClass; }
            set { objBalClass = value; }
        }

        #endregion

        #region UIDatabase Methods

        #region LoadClientDetails
        public void LoadClientDetails()
        {
            lstClientList = objPerformBAL.LoadClientDetailsBal();

        }
        #endregion

        #region GetItemInfoHelper
        public List<SaleObject> GetItemInfoHelper()
        {
            return objPerformBAL.GetItemInfoBal();
        }
        #endregion

        #region GetExpiryDatesForItemHelper
        public List<SaleObject> GetExpiryDatesForItemHelper()
        {
            return objPerformBAL.GetExpiryDatesForItemBal();
        }
        #endregion

        #region SavePerformaInvoicehelper
        public bool SavePerformaInvoicehelper()
        {
            return objPerformBAL.SavePerformaInvoiceBal();
        }
        #endregion

        #region GetOrderInvoiceDetailsHelper
        public List<SaleObject> GetOrderInvoiceDetailsHelper()
        {
            return objPerformBAL.GetOrderInvoiceDetailsBal();
        }
        #endregion

        #region LoadItemDetails
        public List<ItemCardObjectClass> LoadItemDetails()
        {
            List<ItemCardObjectClass> ObjListAgent = objPerformBAL.LoadItemDetailsBal();
            return ObjListAgent;
        }

        public DataTable ItemDetailstoPerform()
        {
            return objPerformBAL.GetItemDetails();
        }
        #endregion

        #region ModifyPerformInvoiceHelper
        public bool ModifyPerformInvoiceHelper()
        {
            return objPerformBAL.ModifyPerformInvoiceBal();
        }
        #endregion

        #region GetMaxOrderInvNoHelper
        public void GetMaxOrderInvNoHelper()
        {
            objPerfrmnceBal.objSalObjects.OrderInvoiceNo = objPerformBAL.GetMaxOrderInvNoBal();
        }


        #endregion

        #region GetMinMaxOrderInvNoHelper
        public List<long> GetMinMaxOrderInvNoHelper()
        {
            return objPerformBAL.GetMinMaxOrderInvNoBal();
        }
        #endregion

        #region GetPerformaValueHelper
        public List<SaleObject> GetPerformaValueHelper()
        {
            return objPerformBAL.GetPerformaValueBal();
        }
        #endregion

        #region GetSaleIdOfOrderInvoiceHelper
        public long GetSaleIdOfOrderInvoiceHelper()
        {
            return objPerformBAL.GetSaleIdOfOrderInvoiceBal();
        }
        #endregion

        #region SaveMovetoSalesHelper
        public bool SaveMovetoSalesHelper()
        {
            return objPerformBAL.SaveMovetoSalesBal();
        }
        #endregion

        #region UpdatePerformaInvoiceHelper
        public bool UpdatePerformaInvoiceHelper()
        {
            return objPerformBAL.UpdatePerformaInvoiceBal();
        }
        #endregion

        #region GetYearSequenceForPerformaHelper
        public List<SaleObject> GetYearSequenceForPerformaHelper()
        {
            return objPerformBAL.GetYearSequenceForPerformaBal();
        }
        #endregion

        #endregion

        #region UIHelper Methods

        #region GetCurrentYear
        public void GetCurrentYear()
        {
            CurrentYear = objSaleInvoiceHelper.ReturnCurrentYear();
        }
        #endregion

        #region GetItemDetailsForID
        public void GetItemDetailsForID(RichTextBox RTxt_Notes)
        {
            lstItemDetails = GetItemInfoHelper();

            if (lstItemDetails.Count > 0)
            {
                //New Code
                //lstItemDetails[0].ItemTotalStock --->Stock In Hand
                if (lstItemDetails[0].ItemPackage == 0)
                {
                    lstItemDetails[0].ItemPackage = 1;
                }
                if (lstItemDetails[0].ItemTotalStock != 0)
                {

                    objPerformBAL.objSalObjects.ItemTotalStock = lstItemDetails[0].ItemTotalStock;
                }
                else
                {
                    objPerformBAL.objSalObjects.ItemTotalStock = 0;
                }
                RTxt_Notes.Text = "";
                objPerformBAL.objSalObjects.ItemPackage = lstItemDetails[0].ItemPackage;
                objPerformBAL.objSalObjects.Reorder = lstItemDetails[0].Reorder;
                if ((objPerformBAL.objSalObjects.ItemTotalStock / objPerformBAL.objSalObjects.ItemPackage) <= objPerformBAL.objSalObjects.Reorder)
                {
                    CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(RTxt_Notes);
                }
                objPerformBAL.objSalObjects.ItemType = lstItemDetails[0].ItemType;
                objPerformBAL.objSalObjects.ItemPrice = lstItemDetails[0].ItemPrice;
                objPerformBAL.objSalObjects.PriceText = lstItemDetails[0].ItemPrice.ToString("#######0.000");
                objPerformBAL.objSalObjects.MaxOrder = lstItemDetails[0].MaxOrder;
                objPerformBAL.objSalObjects.ItemMinimumPrice = lstItemDetails[0].ItemMinimumPrice;
                objPerformBAL.objSalObjects.ItemPackage = lstItemDetails[0].ItemPackage;
                objPerformBAL.objSalObjects.ItemCostPer = lstItemDetails[0].ItemCostPer;
                DiscountCalculation(objPerformBAL.objSalObjects.PriceText);

                if ((objPerformBAL.objSalObjects.ItemType != Convert.ToInt16(ItemType.Meals)) && (objPerformBAL.objSalObjects.ItemType != Convert.ToInt16(ItemType.Labour)))
                {
                    objPerformBAL.objSalObjects.RemainingText = (objPerformBAL.objSalObjects.QtyText != "") ? Math.Floor(Convert.ToDecimal(((objPerformBAL.objSalObjects.ItemTotalStock / objPerformBAL.objSalObjects.ItemPackage) - Convert.ToInt32(objPerformBAL.objSalObjects.QtyText)).ToString())).ToString() : Math.Floor(Convert.ToDecimal(((objPerformBAL.objSalObjects.ItemTotalStock / objPerformBAL.objSalObjects.ItemPackage)).ToString())).ToString();

                    if (Convert.ToInt32(objPerformBAL.objSalObjects.RemainingText) < 0) { objPerformBAL.objSalObjects.RemainingText = "0"; }
                }
                else
                {
                    objPerformBAL.objSalObjects.RemainingText = "0";
                }


                objPerformBAL.objSalObjects.PackageText = objPerformBAL.objSalObjects.ItemPackage.ToString();
                // int BoxQty = Math.Ceiling(objPerformBAL.objSalObjects.ItemTotalStock / objPerformBAL.objSalObjects.ItemPackage);
                int BoxQty = (objPerformBAL.objSalObjects.ItemTotalStock / objPerformBAL.objSalObjects.ItemPackage);
                PackageQty = lstItemDetails[0].ItemPackage; //lstItemDetails[0].ItemTotalStock;
                StockOnHand = lstItemDetails[0].ItemTotalStock;
                objPerformBAL.objSalObjects.StockText = BoxQty.ToString();
                //objPurchase.ItemUnitPrice = Convert.ToDecimal(dr[0]["MTB_PRICE"].ToString());
                //objPurchase.ItemCost = Convert.ToDecimal(dr[0]["MTB_ITEM_COST"].ToString());
                //objPurchase.ItemExpiry = dr[0]["MTB_EXPIRY"].ToString();
                //Cmb_PER_Date.Enabled = true;
                //ItemPrice = objPurchase.ItemUnitPrice;
                //BoxQty = objPurchase.InfoItemPackage;
                //StockQty = int.Parse(dr[0]["MTB_STOCK_ON_HAND"].ToString()) / objPurchase.InfoItemPackage

                objPerformBAL.objSalObjects.HasExpiry = lstItemDetails[0].HasExpiry;

                if (objPerformBAL.objSalObjects.HasExpiry)
                {
                    lstItemExpirydates = GetExpiryDatesForItemHelper();

                }



                //****Following are Setting Expiry Notes, Payment Date Notes ,Option Notes and Alerts****//
                CheckForMoreExpiry(RTxt_Notes);
                CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTxt_Notes);
                CustomNotesAlerts.Set_NotesAlertDetails(RTxt_Notes);

                //***************************************************************************************//
                //****Need to implement the following setrow color functionlity******//
                //SetRowColor(Cmb_ItemName.Text);
                //*******************************************************************//


            }
            else
            {
                objPerformBAL.objSalObjects.PriceText = "";
                objPerformBAL.objSalObjects.RemainingText = "";
                objPerformBAL.objSalObjects.PackageText = "";
                objPerformBAL.objSalObjects.StockText = "";
            }

        }
        #endregion

        #region CheckForMoreExpiry
        public void CheckForMoreExpiry(RichTextBox RTxt_Notes)
        {
            try
            {
                if ((objPerformBAL.objSalObjects.ItemDescription != "") && (objPerformBAL.objSalObjects.ItemSelectedIndex > -1))
                {
                    objPerformBAL.objSalObjects.itemid = objPerfrmnceBal.objSalObjects.ItemNo;
                    objPerformBAL.objSalObjects.itemname = objPerformBAL.objSalObjects.ItemDescription;
                    List<SaleObject> lstExpiryCount = objSaleInvoiceHelper.GetExpiryCountHelper();
                    if ((lstExpiryCount.Count > 0) && (GeneralOptionSetting.FlagAlertForMultiExpiry == "Y") && (GeneralOptionSetting.FlagDontAlertForExpiryInNotes != "Y"))
                    {
                        RTxt_Notes.Text = RTxt_Notes.Text + " " + '\n' + "The item" + "    " + objPerformBAL.objSalObjects.itemname + " " + "has the following expiry dates.";
                        for (int i = 0; i < lstExpiryCount.Count; i++)
                        {
                            DateTime da1 = lstExpiryCount[i].ItemExpiryDate;
                            RTxt_Notes.Text = RTxt_Notes.Text + " " + da1.ToShortDateString();
                        }
                        RTxt_Notes.Text = RTxt_Notes.Text + "\n ";
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DiscountCalculation
        public void DiscountCalculation(string Price)
        {
            try
            {
                float fltdiscount = 0.0f;
                float fltacturalprice = 0.0f;
                float fltdiscountedprice = float.Parse(Price);
                if (Price != "")
                    fltacturalprice = float.Parse(Price);
                if (objPerformBAL.objSalObjects.ClientSelectedIndex != -1)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(objPerformBAL.objSalObjects.ClientNoSelectedValue);
                    fltdiscount = objSaleInvoiceHelper.GetDiscountForAgentHelper();
                    if (fltdiscount != 0.0 && fltdiscount != 0)
                    {
                        fltdiscountedprice = fltacturalprice - ((fltacturalprice * fltdiscount) / 100);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.agentdiscount = "Yes";
                    }
                    objPerformBAL.objSalObjects.PriceText = fltdiscountedprice.ToString("#####0.000");
                }
                else
                    objPerformBAL.objSalObjects.PriceText = float.Parse(Price).ToString("#####0.000");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BoxAction
        public void BoxAction()
        {
            if (ispackage == false)
            {
                if (objPerfrmnceBal.objSalObjects.RemainingText != "")
                {
                    if (objPerfrmnceBal.objSalObjects.QtyText != "" && objPerfrmnceBal.objSalObjects.QtyText != "0")
                    {
                        //MTxt_Remaining.Text = ((Convert.ToInt32(MTxt_Remaining.Text) * objPurchase.InfoItemPackage) + Convert.ToInt32(strPiece)).ToString();
                        objPerfrmnceBal.objSalObjects.RemainingText = Math.Floor(Convert.ToDecimal(((StockOnHand) - Convert.ToInt32(objPerfrmnceBal.objSalObjects.QtyText)).ToString())).ToString();

                    }
                    else
                    {
                        objPerfrmnceBal.objSalObjects.RemainingText = StockOnHand.ToString();
                        //strPiece = "value";
                    }
                    objPerfrmnceBal.objSalObjects.PriceText = (CurrentPrice / PackageQty).ToString("#######0.000");
                    objPerfrmnceBal.objSalObjects.BoxText = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                    ispackage = true;
                    objPerfrmnceBal.objSalObjects.StockText = Convert.ToInt32(StockOnHand.ToString()).ToString();
                }

            }
            else
            {
                string st = objPerfrmnceBal.objSalObjects.RemainingText;
                int quantity = (objPerfrmnceBal.objSalObjects.QtyText != "") ? Convert.ToInt32(objPerfrmnceBal.objSalObjects.QtyText) : 0;
                objPerfrmnceBal.objSalObjects.RemainingText = Math.Floor(Convert.ToDecimal(((StockOnHand / PackageQty) - quantity).ToString())).ToString();
                // strPiece = (Convert.ToInt32(st) % PackageQty).ToString();
                objPerfrmnceBal.objSalObjects.BoxText = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                ispackage = false;
                objPerfrmnceBal.objSalObjects.PriceText = CurrentPrice.ToString("#######0.000");
                objPerfrmnceBal.objSalObjects.StockText = Math.Floor(Convert.ToDecimal((StockOnHand / PackageQty).ToString())).ToString();

            }
        }

        #endregion

        #region NewInvoiceHelper
        public void NewInvoiceHelper()
        {
            InvoiceID = objPerformBAL.GetMaxIDAndYearSequenceBal();
            objPerformBAL.objSalObjects.InvoiceText = InvoiceID[0].ToString();
            objPerformBAL.objSalObjects.NewYrInvoiceText = InvoiceID[1].ToString();

        }
        #endregion

        #region InsertEmptyRecord
        public void InsertEmptyRecord(RichTextBox RTxt_Notes)
        {
            SetEmptyRecord();
            SavePerformaInvoicehelper();
            if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTxt_Notes); }
            CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(RTxt_Notes);
            CustomNotesAlerts.Set_NotesAlertDetails(RTxt_Notes);
        }
        #endregion

        #region SetEmptyRecord
        public void SetEmptyRecord()
        {
            objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            objPerformBAL.objSalObjects.SupplierNo = 0;
            objPerformBAL.objSalObjects.netamount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.OrderDate = DateTime.Now;
            objPerformBAL.objSalObjects.OrderDeliveryDate = Convert.ToDateTime("01/01/1900");
            objPerformBAL.objSalObjects.ItemDiscount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.ItemDiscountOne = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.CreatedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.CreatedDate = DateTime.Now;
            objPerformBAL.objSalObjects.ModifiedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.ModifiedDate = DateTime.Now;
            objPerformBAL.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
            objPerformBAL.objSalObjects.InvoiceType = Convert.ToInt16(OrderRemarks.PI);
            objPerformBAL.objSalObjects.itemid = 0;
            objPerformBAL.objSalObjects.quantity = 0;
            objPerformBAL.objSalObjects.ItemPackage = 0;
            objPerformBAL.objSalObjects.unitprice = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.OrderDemandDate = DateTime.Now;
            objPerformBAL.objSalObjects.SetStatus = 0;
            objPerformBAL.objSalObjects.ItemPrice = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.ItemCostPer = 0;
            objPerformBAL.objSalObjects.discounttype = Convert.ToInt16(SalesDiscountType.Value);
            // objPerformBAL.objSalObjects.ItemSerialNo = "";
            objPerformBAL.objSalObjects.OriginalDiscount = 0;
            objPerformBAL.objSalObjects.note = "";
        }
        #endregion

        #region CheckInsertItem
        public void CheckInsertItem()
        {

            if (ValidateItemOnInsert())
            {

                if (objPerformBAL.objSalObjects.HasExpiry)
                {
                    string noww = DateTime.Now.ToShortDateString().ToString();
                    string[] exp = objPerformBAL.objSalObjects.ItemExpiryDate.ToString().Split(' ');

                    DateTime nowdt, exdt = new DateTime();
                    nowdt = Convert.ToDateTime(noww);
                    exdt = Convert.ToDateTime(exp[0]);
                    int diffdt = exdt.CompareTo(nowdt);

                    if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "N")
                    {
                        if (exp[0] != noww && diffdt > 0)
                        {
                            InsertItem();
                            //Cmb_ItemName.Focus();
                        }
                        else
                        {
                            PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                            frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbesold");
                            frmExpiry.ShowDialog();
                        }
                    }
                    else
                    {
                        InsertItem();
                        //Cmb_ItemName.Focus();
                    }
                }
                else
                {
                    //  Cmb_PER_Date.Enabled = false;
                    objPerformBAL.objSalObjects.ItemExpiryDate = DateTime.Now; //Convert.ToDateTime("01/01/1900");
                    InsertItem();
                    // Cmb_ItemName.Focus();
                }
            }

        }
        #endregion

        #region ValidateItemOnInsert
        public Boolean ValidateItemOnInsert()
        {
            if (objPerfrmnceBal.objSalObjects.InvoiceText.Trim() == "" && objPerfrmnceBal.objSalObjects.InvoiceText.Trim() == string.Empty)
            {
                GeneralFunction.Information("EmptyInvoiceNo", "PerformaInvoice");
                return false;
            }
            if (objPerfrmnceBal.objSalObjects.ItemDescription == "")
            {
                GeneralFunction.Information("EmptyItemName", "PerformaInvoice");
                return false;
            }
            if (objPerfrmnceBal.objSalObjects.SupplierName == "")
            {
                GeneralFunction.Information("EmptyClientName", "PerformaInvoice");
                return false;
            }
            if (objPerfrmnceBal.objSalObjects.QtyText == "")
            {
                GeneralFunction.Information("EmptyQty", "PerformaInvoice");
                return false;
            }
            if (objPerfrmnceBal.objSalObjects.QtyText != "")
            {
                if (Convert.ToInt32(objPerfrmnceBal.objSalObjects.QtyText) == 0)
                {
                    GeneralFunction.Information("ZeroQty", "PerformaInvoice");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region InsertItem
        public void InsertItem()
        {
            //First Part
            bool IsUpdate = false;
            string[] Expiry = objPerformBAL.objSalObjects.ItemExpiryDate.ToString().Split(' ');
            if (GeneralOptionSetting.FlagSale_HideExpiryFiled.Trim() == "N")
            {
                if (objPerfrmnceBal.objSalObjects.HasExpiry)
                {
                    objPerformBAL.objSalObjects.ItemExpiryDate = Convert.ToDateTime(Expiry[0]);
                    objPerformBAL.objSalObjects.strItemExpiry = Expiry[0].ToString(); //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25
                }
                else
                {
                    //objPerformBAL.objSalObjects.ItemExpiryDate = DateTime.MinValue;
                    objPerformBAL.objSalObjects.ItemExpiryDate = Convert.ToDateTime("01/01/1900");
                    objPerformBAL.objSalObjects.strItemExpiry = string.Empty; //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25

                }
            }
            else
            {
                // objPerformBAL.objSalObjects.ItemExpiryDate = DateTime.MinValue; 
                objPerformBAL.objSalObjects.ItemExpiryDate = Convert.ToDateTime("01/01/1900");
                objPerformBAL.objSalObjects.strItemExpiry = string.Empty; //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25
            }

            if (lstGridDetails.Count > 0)
            {
                for (int i = 0; i < lstGridDetails.Count; i++)
                {
                    if (lstGridDetails[i].itemid == objPerfrmnceBal.objSalObjects.ItemNo && lstGridDetails[i].ItemExpiryDate == objPerformBAL.objSalObjects.ItemExpiryDate)
                    {

                        if (ispackage == false)
                        {
                            objPerformBAL.objSalObjects.quantity = (Convert.ToInt32(objPerformBAL.objSalObjects.QtyText) * PackageQty);
                        }
                        else
                        {
                            objPerformBAL.objSalObjects.quantity = Convert.ToInt32(objPerformBAL.objSalObjects.QtyText);
                        }
                        objPerformBAL.objSalObjects.quantity = lstGridDetails[i].quantity + objPerformBAL.objSalObjects.quantity;
                        lstGridDetails[i].quantity = objPerformBAL.objSalObjects.quantity;
                        objPerformBAL.objSalObjects.unitprice = ispackage == false ? (Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText)) / PackageQty : Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);
                        objPerformBAL.objSalObjects.price = Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);

                        lstGridDetails[i].unitprice = objPerformBAL.objSalObjects.unitprice;
                        lstGridDetails[i].TotalPrice = (lstGridDetails[i].quantity * lstGridDetails[i].unitprice);
                        objPerformBAL.objSalObjects.TotalPrice = (lstGridDetails[i].quantity * lstGridDetails[i].unitprice);
                        lstGridDetails[i].Time = DateTime.Now; //.ToString("hh:mm:ss tt");
                        lstGridDetails[i].UserId = GeneralFunction.UserId;
                        lstGridDetails[i].ReturnQty = 0;
                        lstGridDetails[i].price = Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);
                        lstGridDetails[i].ItemCostPer = objPerformBAL.objSalObjects.ItemCostPer;
                        lstGridDetails[i].Newexpr = objPerformBAL.objSalObjects.ItemExpiryDate;
                        lstGridDetails[i].ItemDiscount = 0.000M;
                        lstGridDetails[i].Box = lstGridDetails[i].quantity / PackageQty;
                        lstGridDetails[i].strItemExpiry = objPerformBAL.objSalObjects.strItemExpiry; //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25
                        lstGridDetails[i].user = objPerformBAL.objSalObjects.user;
                        lstGridDetails[i].BarcodeID = objPerformBAL.objSalObjects.BarcodeID;
                        IsUpdate = true;
                    }

                }
            }

            if (!IsUpdate)
            {
                //Second Part
                if (ispackage == false)
                {
                    objPerformBAL.objSalObjects.quantity = (Convert.ToInt32(objPerformBAL.objSalObjects.QtyText) * PackageQty);
                }
                else
                {
                    objPerformBAL.objSalObjects.quantity = Convert.ToInt32(objPerformBAL.objSalObjects.QtyText);
                }
                if (objPerformBAL.objSalObjects.QtyText != "")
                {
                    objPerformBAL.objSalObjects.unitprice = ispackage == false ? (Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText)) / PackageQty : Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);
                    objPerformBAL.objSalObjects.TotalPrice = ((objPerformBAL.objSalObjects.quantity) * (objPerformBAL.objSalObjects.unitprice));//"0.0";
                }
                else
                {
                    objPerformBAL.objSalObjects.unitprice = 0.000M;
                    objPerformBAL.objSalObjects.TotalPrice = 0.000M;
                }
                objPerformBAL.objSalObjects.Box = objPerformBAL.objSalObjects.quantity / PackageQty;
                objPerformBAL.objSalObjects.Time = DateTime.Now; // DateTime.Now.ToString("hh:mm:ss tt");
                objPerformBAL.objSalObjects.UserId = GeneralFunction.UserId;
                objPerformBAL.objSalObjects.ReturnQty = 0;
                objPerformBAL.objSalObjects.price = Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);
                objPerformBAL.objSalObjects.ItemCostPer = objPerformBAL.objSalObjects.ItemCostPer;
                objPerformBAL.objSalObjects.Newexpr = objPerformBAL.objSalObjects.ItemExpiryDate;
                objPerformBAL.objSalObjects.ItemDiscount = 0.000M;
                FillGridDetails();
            }


            //Third part
            GetSumofTotal();
            objPerformBAL.objSalObjects.TotalText = objPerformBAL.objSalObjects.SumOfSubTotal.ToString("#######0.000");
            if (GeneralOptionSetting.FlagDisableDiscountFiled != "Y" && UserScreenLimidations.DiscountPerc == true)
            {
                objPerformBAL.objSalObjects.DiscountText = objPerformBAL.objSalObjects.ItemDiscount.ToString("#######0.000");
                if (objPerfrmnceBal.objSalObjects.ClientSelectedIndex > -1)
                    objPerfrmnceBal.objSalObjects.PercentageChecked = true;
            }
            else { objPerformBAL.objSalObjects.DiscountText = "0.000"; }

            //------* Net Amount *----------
            if (GeneralOptionSetting.FlagDisableDiscountFiled != "Y" && Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) >= objPerformBAL.objSalObjects.ItemDiscount)
            {
                if (objPerfrmnceBal.objSalObjects.ValueChecked == true)
                {

                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)).ToString("#######0.000");
                }
                else if (objPerfrmnceBal.objSalObjects.PercentageChecked == true)
                {
                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) * Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText) / 100)).ToString("#######0.000");
                }
                else
                {
                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)).ToString("#######0.000");
                }
            }
            else { objPerformBAL.objSalObjects.NetText = (objPerformBAL.objSalObjects.NetText == string.Empty) ? objPerformBAL.objSalObjects.TotalText : objPerformBAL.objSalObjects.NetText; }


            //Saving Performance Invoice

            objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            objPerformBAL.objSalObjects.SupplierNo = Convert.ToInt16(objPerformBAL.objSalObjects.ClientNoSelectedValue);
            objPerformBAL.objSalObjects.netamount = Convert.ToDecimal(objPerformBAL.objSalObjects.NetText);
            objPerformBAL.objSalObjects.OrderDate = objPerformBAL.objSalObjects.DtpDate;
            objPerformBAL.objSalObjects.OrderDeliveryDate = objPerformBAL.objSalObjects.DtpPerformDate;
            objPerformBAL.objSalObjects.ItemDiscount = Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText);
            objPerformBAL.objSalObjects.ItemDiscountOne = Convert.ToDecimal(objPerformBAL.objSalObjects.ItemDiscount);
            objPerformBAL.objSalObjects.CreatedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.CreatedDate = DateTime.Now;
            objPerformBAL.objSalObjects.ModifiedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.ModifiedDate = DateTime.Now;
            objPerformBAL.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
            objPerformBAL.objSalObjects.InvoiceType = Convert.ToInt16(OrderRemarks.PI);
            objPerformBAL.objSalObjects.itemid = objPerfrmnceBal.objSalObjects.ItemNo;
            objPerformBAL.objSalObjects.quantity = objPerformBAL.objSalObjects.quantity;
            objPerformBAL.objSalObjects.ItemPackage = PackageQty;
            objPerformBAL.objSalObjects.unitprice = objPerformBAL.objSalObjects.unitprice;
            objPerformBAL.objSalObjects.OrderDemandDate = objPerformBAL.objSalObjects.ItemExpiryDate;
            objPerformBAL.objSalObjects.SetStatus = 0;
            objPerformBAL.objSalObjects.ItemPrice = objPerformBAL.objSalObjects.price;
            objPerformBAL.objSalObjects.ItemCostPer = objPerformBAL.objSalObjects.ItemCostPer;
            objPerformBAL.objSalObjects.discounttype = objPerformBAL.objSalObjects.ValueChecked ? Convert.ToInt16(SalesDiscountType.Value) : Convert.ToInt16(SalesDiscountType.Percentage);
            // objPerformBAL.objSalObjects.ItemSerialNo = "";
            objPerformBAL.objSalObjects.OriginalDiscount = (objPerformBAL.objSalObjects.OriginalDiscount == null) ? (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.NetText)) : objPerformBAL.objSalObjects.OriginalDiscount;
            objPerformBAL.objSalObjects.note = "";
            objPerformBAL.objSalObjects.BarcodeID = objPerformBAL.objSalObjects.BarcodeID;

            if (SavePerformaInvoicehelper())
            {

            }


        }
        #endregion

        #region GetSumofTotal
        public void GetSumofTotal()
        {

            if (lstGridDetails.Count > 0)
            {
                objPerformBAL.objSalObjects.SumOfSubTotal = lstGridDetails.Sum(a => a.TotalPrice);
            }
            else
            {
                objPerformBAL.objSalObjects.SumOfSubTotal = 0;
            }
        }
        #endregion

        #region FillGridDetails
        public void FillGridDetails()
        {
            lstGridDetails.Add(new SaleObject
            {
                itemid = objPerfrmnceBal.objSalObjects.ItemNo,
                ItemDescription = objPerfrmnceBal.objSalObjects.ItemDescription,
                ItemExpiryDate = objPerformBAL.objSalObjects.ItemExpiryDate,
                // strItemExpiry = objPerformBAL.objSalObjects.ItemExpiryDate.ToString().Replace("1900/01/01", ""),//Commented on 26-Nov-2014 by Seenivasan to avoid the "1900-01-01" value for Non Stock Items
                strItemExpiry = objPerformBAL.objSalObjects.strItemExpiry,//Added on 26-Nov-2014 by Seenivasan to avoid the "1900-01-01" value for Non Stock Items
                package = PackageQty,
                quantity = objPerformBAL.objSalObjects.quantity,
                Box = objPerformBAL.objSalObjects.Box,
                unitprice = objPerformBAL.objSalObjects.unitprice,
                TotalPrice = Convert.ToDecimal(objPerformBAL.objSalObjects.TotalPrice.ToString("#######0.000")),
                Time = objPerformBAL.objSalObjects.Time,
                UserId = objPerformBAL.objSalObjects.UserId,
                ReturnQty = objPerformBAL.objSalObjects.ReturnQty,
                price = Convert.ToDecimal(objPerformBAL.objSalObjects.price.ToString("#######0.000")),
                ItemCostPer = objPerformBAL.objSalObjects.ItemCostPer,
                Newexpr = objPerformBAL.objSalObjects.Newexpr,
                ItemDiscount = Convert.ToDecimal(objPerformBAL.objSalObjects.ItemDiscount.ToString("#######0.000")),
                ItemNumber = objPerformBAL.objSalObjects.ItemNumber,
                user = objPerformBAL.objSalObjects.user,
                BarcodeID= objPerformBAL.objSalObjects.BarcodeID
            });
        }
        #endregion

        #region SetRecordsOnSave
        public void SetRecordsOnSave()
        {
            objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            objPerformBAL.objSalObjects.SupplierNo = 0;
            objPerformBAL.objSalObjects.netamount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.OrderDate = DateTime.Now;
            objPerformBAL.objSalObjects.OrderDeliveryDate = Convert.ToDateTime("01/01/1900");
            objPerformBAL.objSalObjects.ItemDiscount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.ItemDiscountOne = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.CreatedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.CreatedDate = DateTime.Now;
            objPerformBAL.objSalObjects.ModifiedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.ModifiedDate = DateTime.Now;
            objPerformBAL.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
            objPerformBAL.objSalObjects.InvoiceType = Convert.ToInt16(OrderRemarks.PI);
            objPerformBAL.objSalObjects.itemid = 0;
            objPerformBAL.objSalObjects.quantity = 0;
            objPerformBAL.objSalObjects.ItemPackage = 0;
            objPerformBAL.objSalObjects.unitprice = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.OrderDemandDate = DateTime.Now;
            objPerformBAL.objSalObjects.SetStatus = 0;
            objPerformBAL.objSalObjects.ItemPrice = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.ItemCostPer = 0;
            objPerformBAL.objSalObjects.discounttype = Convert.ToInt16(SalesDiscountType.Value);
            // objPerformBAL.objSalObjects.ItemSerialNo = "";
            objPerformBAL.objSalObjects.OriginalDiscount = 0;
            objPerformBAL.objSalObjects.note = "";
        }
        #endregion

        #region DisplayInvoiceDetHelper
        public void DisplayInvoiceDetHelper()
        {
            //*****Getting newYear Invoice No for OrderInvoice No*************

            List<SaleObject> lstYearSequence = new List<SaleObject>();

            try
            {


                objPerformBAL.objSalObjects.Flag = "PerformaInvoice";
                lstYearSequence = GetYearSequenceForPerformaHelper();
                if (lstYearSequence.Count > 0)
                {
                    if (CurrentYear != lstYearSequence[0].Year)
                    {
                        objPerfrmnceBal.objSalObjects.NewYrInvoiceText = lstYearSequence[0].Year + "-" + lstYearSequence[0].YearSequenceNo;
                    }
                    else
                    {
                        objPerfrmnceBal.objSalObjects.NewYrInvoiceText = lstYearSequence[0].YearSequenceNo.ToString();
                    }
                }

                //******************************************************************

                //*****Getting All Invoice Details for OrderInvoice No*************

                lstOrderInvDetails = GetOrderInvoiceDetailsHelper();

                if (lstOrderInvDetails.Count > 0)
                {
                    lstOrderInvDetails = objSaleInvoiceHelper.SortInvoiceDetails(lstOrderInvDetails, "ItemDescription", "ItemUnitPrice");


                    objPerfrmnceBal.objSalObjects.NotesText = lstOrderInvDetails[0].note;

                    for (int i = 0; i < lstOrderInvDetails.Count; i++)
                    {
                        objPerfrmnceBal.objSalObjects.ClientID = lstOrderInvDetails[i].ClientID;
                        objPerfrmnceBal.objSalObjects.SupplierName = lstOrderInvDetails[i].ClientName;
                        if (lstOrderInvDetails[i].HasExpiry)
                        {
                            objPerfrmnceBal.objSalObjects.ExpiryDateText = lstOrderInvDetails[i].OrderDemandDate.ToString();
                        }
                        else { objPerfrmnceBal.objSalObjects.ExpiryDateText = DateTime.Now.ToShortDateString(); }

                        objPerfrmnceBal.objSalObjects.DtpPerformDate = lstOrderInvDetails[i].OrderDeliveryDate;

                        objPerfrmnceBal.objSalObjects.ItemNo = lstOrderInvDetails[i].ItemNo;
                        objPerfrmnceBal.objSalObjects.ItemDescription = lstOrderInvDetails[i].ItemDescription;
                        objPerfrmnceBal.objSalObjects.ItemExpiryDate = lstOrderInvDetails[i].OrderDemandDate;
                        if (lstOrderInvDetails[i].HasExpiry)
                        {
                            objPerfrmnceBal.objSalObjects.strItemExpiry = lstOrderInvDetails[i].OrderDemandDate.ToString();
                        }
                        else
                        {
                            objPerfrmnceBal.objSalObjects.strItemExpiry = string.Empty;
                        }
                        objPerfrmnceBal.objSalObjects.package = lstOrderInvDetails[i].package;
                        PackageQty = lstOrderInvDetails[i].package;
                        objPerfrmnceBal.objSalObjects.quantity = lstOrderInvDetails[i].quantity;
                        if (PackageQty <= 0) { PackageQty = 1; };
                        objPerfrmnceBal.objSalObjects.Box = objPerfrmnceBal.objSalObjects.quantity / PackageQty;
                        objPerformBAL.objSalObjects.unitprice = lstOrderInvDetails[i].unitprice;
                        objPerformBAL.objSalObjects.TotalPrice = lstOrderInvDetails[i].TotalPrice;
                        objPerformBAL.objSalObjects.Time = lstOrderInvDetails[i].OrderDate;
                        objPerformBAL.objSalObjects.UserId = lstOrderInvDetails[i].UserId;
                        objPerformBAL.objSalObjects.ReturnQty = 0;
                        objPerformBAL.objSalObjects.price = lstOrderInvDetails[i].price;
                        objPerformBAL.objSalObjects.ItemCostPer = lstOrderInvDetails[i].ItemCostPer;
                        objPerformBAL.objSalObjects.Newexpr = lstOrderInvDetails[i].Newexpr;
                        objPerformBAL.objSalObjects.ItemDiscount = lstOrderInvDetails[i].ItemDiscount;
                        objPerformBAL.objSalObjects.ItemNumber = lstOrderInvDetails[i].ItemNumber;
                        objPerformBAL.objSalObjects.user = lstOrderInvDetails[i].user;
                        objPerformBAL.objSalObjects.BarcodeID = lstOrderInvDetails[i].BarcodeID;
                        FillGridDetails();
                        objPerformBAL.objSalObjects.discounttype = lstOrderInvDetails[i].discounttype;
                        objPerformBAL.objSalObjects.Status = lstOrderInvDetails[i].Status;
                        objPerformBAL.objSalObjects.TotalText = lstOrderInvDetails[i].TotalOne.ToString("######0.000");
                        objPerformBAL.objSalObjects.NetText = lstOrderInvDetails[i].netamount.ToString("######0.000");
                        objPerformBAL.objSalObjects.DiscountText = lstOrderInvDetails[i].actualdiscount.ToString("######0.000");


                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstYearSequence = null;
            }
        }
        #endregion

        #region CheckCloseInvoice
        public void CheckCloseInvoice()
        {
            int enable = 0;
            if (objPerfrmnceBal.objSalObjects.DtpPerformDate < DateTime.Now)
            {
                objPerfrmnceBal.objSalObjects.DtpPerformDate = DateTime.Now;
            }
            if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
            {
                if (GeneralFunction.Question("AlertCloseInvoice", "PerformaInvoice") == DialogResult.Yes)
                {
                    enable = 1;
                }
                else
                    enable = 0;
            }
            else
                enable = 1;
            if (enable == 0) return;
            CloseInvoice();

        }
        #endregion

        #region CloseInvoice
        public void CloseInvoice()
        {
            if (objPerfrmnceBal.objSalObjects.DgrBgColorValue != "Color [Gray]")
            {
                objPerfrmnceBal.objSalObjects.SaveFlag = false; // added by manoj due to avoid setting closed record color for empty records shows closed
                if (lstGridDetails.Count > 0)
                {

                    objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
                    objPerformBAL.objSalObjects.SupplierNo = Convert.ToInt16(objPerformBAL.objSalObjects.ClientNoSelectedValue);
                    objPerformBAL.objSalObjects.netamount = Convert.ToDecimal(objPerformBAL.objSalObjects.NetText);
                    objPerformBAL.objSalObjects.OrderDate = objPerformBAL.objSalObjects.DtpDate;
                    objPerformBAL.objSalObjects.OrderDeliveryDate = objPerformBAL.objSalObjects.DtpPerformDate;
                    objPerformBAL.objSalObjects.ItemDiscount = Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText);
                    objPerformBAL.objSalObjects.CreatedBy = GeneralFunction.UserId;
                    objPerformBAL.objSalObjects.CreatedDate = DateTime.Now;
                    objPerformBAL.objSalObjects.ModifiedBy = GeneralFunction.UserId;
                    objPerformBAL.objSalObjects.ModifiedDate = DateTime.Now;
                    objPerformBAL.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.ClosedInvoice);
                    objPerformBAL.objSalObjects.InvoiceType = Convert.ToInt16(OrderRemarks.PI);
                    objPerformBAL.objSalObjects.discounttype = objPerformBAL.objSalObjects.ValueChecked ? Convert.ToInt16(SalesDiscountType.Value) : Convert.ToInt16(SalesDiscountType.Percentage);

                    for (int i = 0; i < lstGridDetails.Count; i++)
                    {
                        objPerformBAL.objSalObjects.itemid = lstGridDetails[i].itemid;
                        objPerformBAL.objSalObjects.quantity = lstGridDetails[i].quantity;
                        objPerformBAL.objSalObjects.ItemPackage = lstGridDetails[i].package;
                        objPerformBAL.objSalObjects.unitprice = lstGridDetails[i].unitprice;
                        objPerformBAL.objSalObjects.OrderDemandDate = lstGridDetails[i].ItemExpiryDate;
                        objPerformBAL.objSalObjects.SetStatus = 0;
                        objPerformBAL.objSalObjects.ItemPrice = lstGridDetails[i].price;
                        objPerformBAL.objSalObjects.ItemCostPer = lstGridDetails[i].ItemCostPer;
                        objPerformBAL.objSalObjects.ItemDiscountOne = lstGridDetails[i].ItemDiscount;
                        objPerformBAL.objSalObjects.OriginalDiscount = (objPerformBAL.objSalObjects.OriginalDiscount == null) ? (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.NetText)) : objPerformBAL.objSalObjects.OriginalDiscount;
                        objPerformBAL.objSalObjects.note = objPerformBAL.objSalObjects.NotesText;
                        objPerformBAL.objSalObjects.BarcodeID = lstGridDetails[i].BarcodeID;

                        if (SavePerformaInvoicehelper())
                        {
                            objPerformBAL.objSalObjects.SaveFlag = true;
                        }
                    }

                }
            }
            else
            {
                GeneralFunction.Information("AlreadyInvoiceClosed", "PerformaInvoice");
            }
        }
        #endregion

        #region CheckDeleteItem
        public void CheckDeleteItem(DataGridView DgvPerInvoice)
        {
            string str = "";
            if (objPerfrmnceBal.objSalObjects.DgrBgColorValue != "Color [Gray]")
            {
                if (lstGridDetails.Count > 0)
                {
                    if (objPerfrmnceBal.objSalObjects.GrdSelectedRowCount > 0)
                    {
                        if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                        {
                            if (str == "")
                            {
                                if ((GeneralFunction.Question("AlertDeleteSelectedRow", "PerformaInvoice")) == DialogResult.Yes)
                                {
                                    DeleteItem("One");
                                    str = "one";
                                }
                                else if (GeneralFunction.Question("AlertDeleteWholeRow", "PerformaInvoice") == DialogResult.Yes)
                                {
                                    DeleteItem("All");
                                    str = "";
                                }
                                else { }
                            }
                            else if (str == "one")
                            {
                                if (GeneralFunction.Question("AlertDeleteSelectedRow", "PerformaInvoice") == DialogResult.Yes)
                                {
                                    DeleteItem("One");
                                    str = "one";
                                }
                            }
                            else { }
                        }
                        else
                        {
                            DeleteItem("All");
                            str = "";
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("SelectRowtodelete", "PerformaInvoice");
                    }

                }
                else
                {
                    GeneralFunction.Information("EmptyInvoiceList", "PerformaInvoice");
                }
            }

        }
        #endregion

        #region DeleteItem
        public void DeleteItem(string Option)
        {

            objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            objPerformBAL.objSalObjects.SetStatus = 1;
            objPerformBAL.objSalObjects.InvoiceType = Convert.ToInt16(OrderRemarks.PI);
            objPerformBAL.objSalObjects.CreatedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.CreatedDate = DateTime.Now;
            objPerformBAL.objSalObjects.ModifiedBy = GeneralFunction.UserId;
            objPerformBAL.objSalObjects.ModifiedDate = DateTime.Now;
            objPerformBAL.objSalObjects.OrderDeliveryDate = DateTime.Now;
            objPerformBAL.objSalObjects.ItemDiscount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.OrderDate = DateTime.Now;
            objPerformBAL.objSalObjects.SupplierNo = 0;
            //   objPerformBAL.objSalObjects.netamount = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
            objPerformBAL.objSalObjects.quantity = 0;
            objPerformBAL.objSalObjects.ItemPackage = 0;
            objPerformBAL.objSalObjects.unitprice = Convert.ToDecimal("0.000");
            objPerformBAL.objSalObjects.discounttype = objPerformBAL.objSalObjects.ValueChecked ? Convert.ToInt16(SalesDiscountType.Value) : Convert.ToInt16(SalesDiscountType.Percentage);

            if (Option == "All")
            {
                for (int i = 0; i < lstGridDetails.Count; i++)
                {
                    objPerformBAL.objSalObjects.itemid = lstGridDetails[i].itemid;
                    objPerformBAL.objSalObjects.OrderDemandDate = lstGridDetails[i].ItemExpiryDate;
                    objPerformBAL.objSalObjects.OriginalDiscount = 0;
                    objPerformBAL.objSalObjects.note = objPerformBAL.objSalObjects.NotesText;
                    objPerformBAL.objSalObjects.netamount = lstGridDetails[i].TotalPrice;
                    if (SavePerformaInvoicehelper())
                    {
                        objPerformBAL.objSalObjects.SaveFlag = true;
                        lstGridDetails.RemoveAt(i);
                    }
                }

            }
            else
            {
                int Index;
                Index = lstGridDetails.FindIndex(a => (a.itemid == objPerfrmnceBal.objSalObjects.GrdSelectedItemID) && (a.Newexpr == objPerfrmnceBal.objSalObjects.GrdSelectedDemandDate));
                objPerformBAL.objSalObjects.itemid = objPerfrmnceBal.objSalObjects.GrdSelectedItemID;
                objPerformBAL.objSalObjects.OrderDemandDate = objPerfrmnceBal.objSalObjects.GrdSelectedDemandDate;
                objPerformBAL.objSalObjects.OriginalDiscount = 0;
                objPerformBAL.objSalObjects.note = objPerformBAL.objSalObjects.NotesText;
                objPerformBAL.objSalObjects.netamount = lstGridDetails[Index].TotalPrice;
                if (SavePerformaInvoicehelper())
                {
                    objPerformBAL.objSalObjects.SaveFlag = true;

                    lstGridDetails.RemoveAt(Index);
                }

            }
            if (objPerformBAL.objSalObjects.SaveFlag)
            {
                GeneralFunction.Information("DeleteItem", "PerformaInvoice");
            }

            GetSumofTotal();
            objPerformBAL.objSalObjects.TotalText = objPerformBAL.objSalObjects.SumOfSubTotal.ToString("#######0.000");

            //------* Net Amount *----------
            if (GeneralOptionSetting.FlagDisableDiscountFiled != "Y" && Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) >= objPerformBAL.objSalObjects.ItemDiscount)
            {
                if (objPerfrmnceBal.objSalObjects.ValueChecked == true)
                {

                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)).ToString("#######0.000");
                }
                else if (objPerfrmnceBal.objSalObjects.PercentageChecked == true)
                {
                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) * Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText) / 100)).ToString("#######0.000");
                }
                else
                {
                    objPerformBAL.objSalObjects.NetText = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)).ToString("#######0.000");
                }
            }
            else { objPerformBAL.objSalObjects.NetText = (objPerformBAL.objSalObjects.NetText == string.Empty) ? objPerformBAL.objSalObjects.TotalText : objPerformBAL.objSalObjects.NetText; }


        }
        #endregion

        #region ModifyInvoice
        public void ModifyInvoice(DataGridView Dgv_PER_Invoice)
        {
            string str = string.Empty;
            objPerfrmnceBal.objSalObjects.SaveFlag = false;
            if (UserScreenLimidations.ModifyInvoice)
            {
                str = "Modify";
            }
            else if (UserScreenLimidations.ModifyTodayInvoice)
            {
                if (Modifydate.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    str = "Modify";
                }
            }
            else { }
            if (str == "Modify" && Dgv_PER_Invoice.BackgroundColor == Color.Gray)
            {

                if (GeneralFunction.Question("AlertModifyInvoice", "PerformaInvoice") == DialogResult.Yes)
                {
                    objPerfrmnceBal.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerfrmnceBal.objSalObjects.InvoiceText);

                    if (ModifyPerformInvoiceHelper())
                    {
                        objPerfrmnceBal.objSalObjects.SaveFlag = true;

                    }
                }

                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Modify), objPerfrmnceBal.objSalObjects.OrderInvoiceNo.ToString(), "Order", "Modify Performa invoice details", Convert.ToInt16(InvoiceAction.Yes));
            }
            else if (Dgv_PER_Invoice.BackgroundColor != Color.Gray) { GeneralFunction.Information("UserCantModifyInvoice", "PerformaInvoice"); }

        }
        #endregion

        #region NavigationEvent
        public void NavigationEvent()
        {
            ID = GetMinMaxOrderInvNoHelper();
            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:

                    objPerfrmnceBal.objSalObjects.OrderInvoiceNo = ID[0];

                    break;
                case InvoiceFlag.Next:
                    if (objPerfrmnceBal.objSalObjects.OrderInvoiceNo != ID[1])
                    {
                        objPerfrmnceBal.objSalObjects.OrderInvoiceNo = objPerfrmnceBal.objSalObjects.OrderInvoiceNo + 1;

                    }
                    else
                    {
                        objPerfrmnceBal.objSalObjects.OrderInvoiceNo = ID[1];

                    }
                    break;
                case InvoiceFlag.Last:
                    objPerfrmnceBal.objSalObjects.OrderInvoiceNo = ID[1];

                    break;
                case InvoiceFlag.Previous:
                    if (objPerfrmnceBal.objSalObjects.OrderInvoiceNo != ID[0])
                    {
                        objPerfrmnceBal.objSalObjects.OrderInvoiceNo = objPerfrmnceBal.objSalObjects.OrderInvoiceNo - 1;

                    }
                    else
                    {
                        objPerfrmnceBal.objSalObjects.OrderInvoiceNo = ID[0];

                    }
                    break;
                default:
                    // objPerfrmnceBal.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objSaleInvoiceBAL.GetPurInvIDBasedOnNewYearID());
                    break;
            }
        }
        #endregion

        #region MoveToSales
        public void MoveToSales()
        {
            string strMove = string.Empty;
            string strSave = string.Empty;
            decimal totalofinvoice = 0;
            if (objPerformBAL.objSalObjects.DgrBgColorValue == "Color [Gray]")
            {
                int count = 0;
                int ENOUGHSTOCK = 0;
                decimal newdiscountforstock = 0;

                for (int i = 0; i < lstGridDetails.Count; i++)
                {
                    strMove = string.Empty;
                    objPerformBAL.objSalObjects.itemid = lstGridDetails[i].itemid;
                    objPerformBAL.objSalObjects.quantity = lstGridDetails[i].quantity;


                    List<SaleObject> lstTotalStock = GetPerformaValueHelper();

                    if (lstTotalStock.Count > 0)
                    {
                        if (lstTotalStock[0].ItemTotalStock.ToString() != "")
                        {
                            objPerformBAL.objSalObjects.ItemTotalStock = lstTotalStock[0].ItemTotalStock;
                        }
                        else
                        {
                            objPerformBAL.objSalObjects.ItemTotalStock = 0;
                        }
                    }
                    if (objPerformBAL.objSalObjects.quantity < objPerformBAL.objSalObjects.ItemTotalStock)
                    {
                        strMove = "Yes";
                    }
                    else if (objPerformBAL.objSalObjects.ItemTotalStock > 0)
                    {
                        strMove = "Yes1";
                        objPerformBAL.objSalObjects.quantity = objPerformBAL.objSalObjects.ItemTotalStock;
                        ENOUGHSTOCK = 1;
                    }
                    else
                    {
                        strMove = "No";
                        ENOUGHSTOCK = 1;
                        objPerformBAL.objSalObjects.quantity = 0;
                    }
                    if ((strMove == "Yes") || (strMove == "Yes1"))
                    {
                        if (((i == 0) && (strMove != "No")) || ((i != 0) && (count == 0)))
                        {
                            //DataTable dtSaleInvNo = new DataTable();
                            //dtSaleInvNo = Dal_Sale.getfirstinvno();
                            //obj_saleinvoice.saleinv = (int.Parse(dtSaleInvNo.Rows[0][1].ToString()) + 1).ToString();
                            SaleInvoiceID = objSaleInvoiceHelper.objSaleInvoiceBAL.GetYearSequenceMaxIDBal();
                            objPerfrmnceBal.objSalObjects.saleid = SaleInvoiceID[0];
                            objPerfrmnceBal.objSalObjects.Year = Convert.ToInt16(SaleInvoiceID[1]);
                            objPerfrmnceBal.objSalObjects.YearSequenceNo = SaleInvoiceID[2];
                            objPerfrmnceBal.objSalObjects.accountid = 101;


                        }

                        long SaleID = GetSaleIdOfOrderInvoiceHelper();
                        if (SaleID.ToString() == "0")
                        {
                            objPerfrmnceBal.objSalObjects.ClientID = objPerfrmnceBal.objSalObjects.ClientID;
                            objPerfrmnceBal.objSalObjects.invoicetime = objPerfrmnceBal.objSalObjects.DtpDate;
                            objPerfrmnceBal.objSalObjects.createdby = GeneralFunction.UserId;
                            objPerfrmnceBal.objSalObjects.Status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
                            objPerfrmnceBal.objSalObjects.SerialNo = "0";
                            strSave = string.Empty;
                            //obj_saleinvoice.itemname = (Dgv_PER_Invoice.Rows[i].Cells["item_name"].Value).ToString();
                            //obj_saleinvoice.itemid = obj_saleinvoice.itemname;
                            // dtST = Dal_Sale.performavaluecheck();
                            int stock = 0;
                            if (lstTotalStock.Count > 0)
                            {
                                if (lstTotalStock[0].ItemTotalStock.ToString() != "")
                                {
                                    stock = lstTotalStock[0].ItemTotalStock;
                                }
                                else
                                {
                                    stock = 0;
                                }
                            }
                            objPerfrmnceBal.objSalObjects.package = lstGridDetails[i].package;
                            objPerfrmnceBal.objSalObjects.price = lstGridDetails[i].unitprice;
                            objPerfrmnceBal.objSalObjects.ItemDiscount = lstGridDetails[i].ItemDiscount;
                            totalofinvoice = totalofinvoice + (objPerfrmnceBal.objSalObjects.quantity * (objPerfrmnceBal.objSalObjects.price + objPerfrmnceBal.objSalObjects.ItemDiscount));
                            objPerfrmnceBal.objSalObjects.ItemExpiryDate = lstGridDetails[i].Newexpr;
                            objPerfrmnceBal.objSalObjects.ItemCostPer = lstGridDetails[i].ItemCostPer;
                            objPerfrmnceBal.objSalObjects.gross = (ENOUGHSTOCK == 1) ? Convert.ToDouble(totalofinvoice) : Convert.ToDouble(objPerfrmnceBal.objSalObjects.TotalText);// totalofinvoice;
                            newdiscountforstock += (lstGridDetails[i].ItemDiscount) * Convert.ToDecimal(objPerfrmnceBal.objSalObjects.quantity);
                            objPerfrmnceBal.objSalObjects.discount = Convert.ToDouble(newdiscountforstock);
                            objPerfrmnceBal.objSalObjects.netamount = (ENOUGHSTOCK == 1) ? (totalofinvoice - Convert.ToDecimal(objPerfrmnceBal.objSalObjects.discount)) : Convert.ToDecimal(objPerfrmnceBal.objSalObjects.NetText);
                            objPerformBAL.objSalObjects.discounttype = objPerformBAL.objSalObjects.ValueChecked ? Convert.ToInt16(SalesDiscountType.Value) : Convert.ToInt16(SalesDiscountType.Percentage);
                            objPerformBAL.objSalObjects.SaleType = Convert.ToInt16(SalesType.Normal);
                            objPerformBAL.objSalObjects.Box = lstGridDetails[i].Box;
                            objPerformBAL.objSalObjects.BarcodeID = lstGridDetails[i].BarcodeID;


                            if (SaveMovetoSalesHelper())
                            {
                                count += 1;
                                strSave = "Yes";
                            }
                        }
                        else { GeneralFunction.Information("AlreadyMovedInvoice", "PerformaInvoice"); }
                    }
                    else
                    {
                        GeneralFunction.Information("ValidItemQty", "PerformaInvoice");
                    }

                }
                if (strSave == "Yes")
                {
                    objPerformBAL.objSalObjects.OrderInvoiceNo = Convert.ToInt64(objPerfrmnceBal.objSalObjects.InvoiceText);
                    objPerformBAL.objSalObjects.Status = Convert.ToInt16(OrderRemarks.PI);
                    if (UpdatePerformaInvoiceHelper())
                    {
                        GeneralFunction.Information("MoveInvoiceSuccess", "PerformaInvoice");
                    }
                }

            }
            else
            {
                GeneralFunction.Information("CloseInvoice", "PerformaInvoice");
            }



        }
        #endregion

        #region StockAdjustment
        public void StockAdjustment()
        {
            if (objPerformBAL.objSalObjects.ItemType != Convert.ToInt16(ItemType.Meals))
            {
                if ((objPerformBAL.objSalObjects.QtyText != string.Empty && int.Parse(objPerformBAL.objSalObjects.QtyText) > 0))
                {

                    if (ispackage == false)
                    {
                        objPerformBAL.objSalObjects.RemainingText = ((objPerformBAL.objSalObjects.ItemTotalStock / PackageQty) - Convert.ToInt32(objPerformBAL.objSalObjects.QtyText)).ToString();
                        objPerformBAL.objSalObjects.RemainingText = (int.Parse((objPerformBAL.objSalObjects.RemainingText != string.Empty) ? objPerformBAL.objSalObjects.RemainingText : "0") < 0) ? "0" : objPerformBAL.objSalObjects.RemainingText;

                    }
                    else
                    {
                        objPerformBAL.objSalObjects.RemainingText = (objPerformBAL.objSalObjects.ItemTotalStock - Convert.ToInt32(objPerformBAL.objSalObjects.QtyText)).ToString();
                        objPerformBAL.objSalObjects.RemainingText = (int.Parse((objPerformBAL.objSalObjects.RemainingText != string.Empty) ? objPerformBAL.objSalObjects.RemainingText : "0") < 0) ? "0" : objPerformBAL.objSalObjects.RemainingText;
                    }

                }
                else
                {
                    if (ispackage == false)
                        objPerformBAL.objSalObjects.RemainingText = (objPerformBAL.objSalObjects.ItemTotalStock / PackageQty).ToString();
                    else
                        objPerformBAL.objSalObjects.RemainingText = Convert.ToInt32(objPerformBAL.objSalObjects.ItemTotalStock).ToString();
                }
            }

        }
        #endregion

        #region DiscountOne
        public void DiscountOne()
        {

            objPerformBAL.objSalObjects.DiscountText = (objPerformBAL.objSalObjects.DiscountText != string.Empty) ? objPerformBAL.objSalObjects.DiscountText : "0";
            decimal net1 = 0;
            for (int i = 0; i < lstGridDetails.Count; i++)
            {
                if (lstGridDetails[i].ItemDiscount.ToString() != "")
                    lstGridDetails[i].unitprice = lstGridDetails[i].unitprice + lstGridDetails[i].ItemDiscount;
                lstGridDetails[i].ItemDiscount = 0.000M;
                int quantity1 = lstGridDetails[i].quantity;
                decimal unitprice1 = lstGridDetails[i].unitprice;
                decimal total1 = quantity1 * unitprice1;
                lstGridDetails[i].TotalPrice = total1;
                net1 = net1 + lstGridDetails[i].TotalPrice;
            }
            objPerformBAL.objSalObjects.NetText = net1.ToString("####0.000");
            objPerformBAL.objSalObjects.TotalText = (objPerformBAL.objSalObjects.TotalText == string.Empty ? "0" : objPerformBAL.objSalObjects.TotalText);



            if ((objPerformBAL.objSalObjects.ValueChecked == true) & (objPerformBAL.objSalObjects.DgrBgColorValue != "Color [Gray]") & (objPerformBAL.objSalObjects.TotalText != ""))
            {
                if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y")
                {
                    string z = (Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) - Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)).ToString("#######0.000");
                    objPerformBAL.objSalObjects.NetText = z;
                }
                else
                {

                    string totper = (Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText) / Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) * 100).ToString("#######0.000");
                    decimal totalpercentage = Convert.ToDecimal(totper);
                    for (int i = 0; i < lstGridDetails.Count; i++)
                    {
                        decimal itemunitprice = lstGridDetails[i].TotalPrice / lstGridDetails[i].quantity;

                        decimal itempercentage = itemunitprice - (itemunitprice * (totalpercentage / 100));
                        decimal itemdiscount = (itemunitprice * (totalpercentage / 100));
                        lstGridDetails[i].ItemDiscount = itemdiscount;
                        lstGridDetails[i].unitprice = itempercentage;
                        decimal net = 0;
                        int quantity = lstGridDetails[i].quantity;
                        decimal unitprice = Convert.ToDecimal(lstGridDetails[i].unitprice.ToString("#######0.000"));
                        decimal total = quantity * unitprice;
                        lstGridDetails[i].TotalPrice = Convert.ToDecimal(total.ToString("#######0.000"));
                        net = net + lstGridDetails[i].TotalPrice;
                        objPerformBAL.objSalObjects.NetText = net.ToString("#######0.000");
                    }
                }
            }
            else if ((objPerformBAL.objSalObjects.PercentageChecked == true) & (objPerformBAL.objSalObjects.DgrBgColorValue != "Color [Gray]") & (objPerformBAL.objSalObjects.TotalText != ""))
            {
                if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y")
                {
                    decimal dis = 0;
                    dis = ((Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) * (Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText))) / 100);
                    string z = ((Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText)) - dis).ToString("#######0.000");
                    objPerformBAL.objSalObjects.NetText = z;
                }
                else
                {
                    decimal totalpercentage = Convert.ToDecimal(objPerformBAL.objSalObjects.TotalText) * ((Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText) / 100));
                    decimal net = 0;
                    for (int i = 0; i < lstGridDetails.Count; i++)
                    {
                        decimal itemunitprice = lstGridDetails[i].TotalPrice / lstGridDetails[i].quantity;

                        decimal itempercentage = itemunitprice - (itemunitprice * (Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)) / 100);
                        decimal itemdiscount = (itemunitprice * (Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText)) / 100);

                        lstGridDetails[i].unitprice = itempercentage;
                        lstGridDetails[i].ItemDiscount = itemdiscount;

                        decimal quantity = lstGridDetails[i].quantity;
                        decimal unitprice = Convert.ToDecimal(lstGridDetails[i].unitprice.ToString("#######0.000"));
                        decimal total = quantity * unitprice;
                        lstGridDetails[i].TotalPrice = Convert.ToDecimal(total.ToString("#######0.000"));
                        net = net + lstGridDetails[i].TotalPrice;

                    }
                    objPerformBAL.objSalObjects.NetText = net.ToString("#######0.000");
                }
            }
            else { }
            if (objPerformBAL.objSalObjects.DiscountText == "0")
            {
                // MTxt_Discount.SelectAll();
            }
        }
        #endregion

        #region DiscountTwo

        public void DiscountTwo()
        {

            float net = 0.0f;
            objPerformBAL.objSalObjects.DiscountText = ((objPerformBAL.objSalObjects.DiscountText == string.Empty) || (objPerformBAL.objSalObjects.DiscountText == ".")) ? "0.000" : objPerformBAL.objSalObjects.DiscountText;

            if ((objPerformBAL.objSalObjects.TotalText != "") && (objPerformBAL.objSalObjects.DiscountText != ""))
            {
                if (objPerformBAL.objSalObjects.ValueChecked == true)
                {

                    net = float.Parse(objPerformBAL.objSalObjects.TotalText) - float.Parse(objPerformBAL.objSalObjects.DiscountText);
                    objPerformBAL.objSalObjects.OriginalDiscount = Convert.ToDecimal(objPerformBAL.objSalObjects.DiscountText);

                }
                else if (objPerformBAL.objSalObjects.PercentageChecked == true)
                {
                    float value = (float.Parse(objPerformBAL.objSalObjects.TotalText) * float.Parse(objPerformBAL.objSalObjects.DiscountText)) / 100;

                    net = float.Parse(objPerformBAL.objSalObjects.TotalText) - value;
                    objPerformBAL.objSalObjects.OriginalDiscount = Convert.ToDecimal(value.ToString());

                }
                objPerformBAL.objSalObjects.NetText = net.ToString("####0.000");

            }

        }
        #endregion

        #region SortGridList
        public void SortGridList()
        {
            lstGridDetails = objSaleInvoiceHelper.SortInvoiceDetails(lstGridDetails, "ItemDescription", "unitprice");
        }
        #endregion

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
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Print
        public void Print()
        {
            ReportsView frmView = new ReportsView();
            CurrencyConverter ObjCC = new CurrencyConverter();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoice");
            DataTable dt = new DataTable("SimpleInvoice");
            //objSaleObject.OrderInvoiceNo
            long InvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            int Remarks = Convert.ToInt32(OrderRemarks.PI);
            dt = ObjBALClass.PerformaReportValues(InvoiceNo, Remarks);
            decimal Total = 0.000M;
            if (dt.Rows.Count > 0)
            {
                dt = GeneralFunction.SortInvoiceDetails(dt, "ItemName", "UnitPrice");
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["AgentID"].ToString());
                GeneralFunction.AgentDept();
            }
            DataTable dtLocal = SpoiledItemHelper.SimpleInvoiceDataTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();
                drAdd["InvoiceName"] = "Proforma Invoice";
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
                // drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                // drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();

                drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                drAdd["DiscountPercentage"] = 0;//Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());

                dtLocal.Rows.Add(drAdd);
            }


            if (dtLocal.Rows.Count > 0)
            {
                frmView.Report_Table = dtLocal;
                frmView.HTable.Clear();

                frmView.HTable.Add("note",objPerfrmnceBal.objSalObjects.ChkNoteChecked==true?objPerfrmnceBal.objSalObjects.NotesText:string.Empty);
                if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                { frmView.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000"))); }
                frmView.HTable.Add("IncludeTax", "No");
                frmView.HTable.Add("Tax1", "0.000");
                frmView.HTable.Add("Tax2", "0.000");
                frmView.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                frmView.HTable.Add("InvoiceName", Additional_Barcode.GetValueByResourceKey("PerformanceInvoice"));
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
                frmView.HideLogo = false;
                //summery = rpt;
                frmView.RptDoc = OrderInvoiceHelper.ReportSelection();// summery;
                //ReportDocument rpt = summery;
                //Tables tbl = rpt.Database.Tables;
                // Obj_viewer.Repnum = tbl;
                frmView.isInvoice = true;
                if (frmView.RptDoc is Rpt_Invoice_80mm || frmView.RptDoc is Rpt_Invoice_63mm)
                {
                    frmView.HTable.Remove("monthformat");
                    frmView.HTable.Remove("dayformat");
                    frmView.HTable.Remove("yearformat");
                    frmView.HTable.Remove("seperatorformat");
                    frmView.HTable.Remove("dateformat");
                    if (frmView.RptDoc is Rpt_Invoice_80mm)
                        frmView.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? true : false);
                }
                if (frmView.RptDoc is Rpt_InvTemplate1 || frmView.RptDoc is Rpt_InvTemplate2 || frmView.RptDoc is Rpt_InvTemplate3 || frmView.RptDoc is Rpt_InvTemplate4 || frmView.RptDoc is Rpt_InvTemplate5 || frmView.RptDoc is Rpt_InvTemplate6) // 10-12-2018 Tanzeel Dev 
                {
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
                frmView.HTable.Add("Paid", 0.0);
                frmView.HTable.Add("Remaining", 0.0);

                frmView.InvoiceName = "PerformaInvoice";
                frmView.LoadEvent();
                frmView.ShowDialog();
                //if (ObjBALClass.ObjOrder.SetStatus == 1)
                //{
                //    Obj_viewer.ShowDialog();
                //}
                //else
                //{
                //    /// Obj_viewer.LoadReport();
                //    Obj_viewer.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                //}
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "PerformaInvoice");
            }


        }
        #endregion

        #region PackageQtySelectionChanged
        public void PackageQtySelectionChanged()
        {
            objPerfrmnceBal.objSalObjects.PriceText = (objPerformBAL.objSalObjects.PackagePrice).ToString("#####0.000");
            DiscountCalculation(objPerformBAL.objSalObjects.PriceText);
            CurrentPrice = Convert.ToDecimal(objPerformBAL.objSalObjects.PriceText);
            objPerfrmnceBal.objSalObjects.QtyText = "1";
            if (ispackage == false)
            {
                objPerfrmnceBal.objSalObjects.StockText = (objPerformBAL.objSalObjects.ItemTotalStock / PackageQty).ToString();
                objPerfrmnceBal.objSalObjects.PriceText = (objPerformBAL.objSalObjects.PackagePrice).ToString("#####0.000");
            }
            else
            {
                objPerfrmnceBal.objSalObjects.StockText = objPerformBAL.objSalObjects.ItemTotalStock.ToString();
                objPerfrmnceBal.objSalObjects.PriceText = (objPerformBAL.objSalObjects.PackagePrice / PackageQty).ToString("#####0.000");
            }

            int reas = 0;
            reas = (ispackage == false) ? ((objPerformBAL.objSalObjects.ItemTotalStock / PackageQty) - Convert.ToInt16(objPerfrmnceBal.objSalObjects.QtyText)) : (objPerformBAL.objSalObjects.ItemTotalStock - Convert.ToInt16(objPerfrmnceBal.objSalObjects.QtyText));
            if (reas < 0)
            {
                objPerfrmnceBal.objSalObjects.RemainingText = "0";
            }
            else
            {
                objPerfrmnceBal.objSalObjects.RemainingText = reas.ToString();
            }

        }
        #endregion
        /// <summary>
        /// Implemented method to filter the item 
        /// Implemented on 11Nov2014 By Meena.R
        /// </summary>
        /// <returns></returns>
        internal List<ItemCardObjectClass> FilterItemBasedonCategory()
        {
            if (objPerfrmnceBal.objSalObjects.CategoryNo == 1001)
            {
                List<ItemCardObjectClass> ObjListAgent = objPerformBAL.LoadItemDetailsBal();
                return ObjListAgent;
            }
            else
            {
                List<ItemCardObjectClass> ObjListAgent = objPerformBAL.LoadItemDetailsBal().ToList().Where(a => a.CategoryId == objPerfrmnceBal.objSalObjects.CategoryNo).ToList(); ;
                return ObjListAgent;
            }
        }
        internal List<ItemCardObjectClass> FilterItemBasedonCompany()
        {
            if (objPerfrmnceBal.objSalObjects.CompanyNo == 1001)
            {
                List<ItemCardObjectClass> ObjListAgent = objPerformBAL.LoadItemDetailsBal();
                return ObjListAgent;
            }
            else
            {
                List<ItemCardObjectClass> ObjListAgent = objPerformBAL.LoadItemDetailsBal().ToList().Where(a => a.CompId == objPerfrmnceBal.objSalObjects.CompanyNo).ToList(); ;
                return ObjListAgent;
            }
        }

        #endregion
    }
}
