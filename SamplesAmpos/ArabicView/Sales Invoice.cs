using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Sales_Invoice : Form, IDisposable
    {

        #region Variables

        public SalesInvoiceHelper objSaleInvoiceHelper = new SalesInvoiceHelper();
        System.Data.DataSet SaleLoadData = new System.Data.DataSet();
        List<SaleObject> Item;
        Boolean ispackage = false;
        public float boxprice, pieceprice;
        public string find_saleinv = "", Oldfocus = "";
        public long find_saleID = 0;///added on 09 july 2014 for to get the particular transaction id fro the sale while opent he transaction record from balancesheet 
        public List<SaleObject> olstItemDetails = new List<SaleObject>();
        private DateTime ScanLetterStartTime = DateTime.Now;
        private DateTime scanlet = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        DataTable CommondtItem;
        private bool FormLoad = false, isfromPiece = false;
        int buttonclick = 0, iteminbutton = 1, itemkeydown = 0;
        DataTable dtSaleExtended;
        int Index = -1;
        public string deleteditem;
        public static List<Object> GetDetailsFromItem = new List<Object>();

        List<SaleObject> ObjectOfSales = new List<SaleObject>();
        public static int CheckCashClientName = 0;
        public static double salesTotal = 0;
        public static string clientClosedSales = "";
        DataTable dtallBarcode; decimal AvgCostofItem = 0.0m;
        public bool IsFromSave = false;
        public static bool isPaymentMethodOn = false;
        private string RealPrice = "";
        private string RealPackage = "";
        private string RealExpireDate = "";
        public static int PaymentTypeID = 0;
        public static double PaymentChagers = 0;
        #endregion

        #region Constructor
        public Sales_Invoice()
        {
            InitializeComponent();

            //
            // menu appears after rightclicking the control, Price Text
            ContextMenuStrip cmsPrice = new ContextMenuStrip();
            txtPrice.ContextMenuStrip = cmsPrice; //for this form, could be for a button etc.
            cmsPrice.Items.Add(Additional_Barcode.GetValueByResourceKey("NormalPrice"));
            cmsPrice.Items.Add(Additional_Barcode.GetValueByResourceKey("WholeSalePrice")); // add some items to the menu
            cmsPrice.Items.Add(Additional_Barcode.GetValueByResourceKey("MinPrice"));
            cmsPrice.Items[0].Click += new EventHandler(CMSPrice_Click);
            cmsPrice.Items[1].Click += new EventHandler(CMSPrice_Click);
            cmsPrice.Items[2].Click += new EventHandler(CMSPrice_Click);
            //

            // menu appears after rightclicking the control, Form
            ContextMenuStrip myMenu = new ContextMenuStrip();
            dgrSaleInvoice.ContextMenuStrip = myMenu; //for this form, could be for a button etc.
            myMenu.Items.Add(Additional_Barcode.GetValueByResourceKey("DeleteItems"));
            myMenu.Items.Add(Additional_Barcode.GetValueByResourceKey("ItemInfo"));
            myMenu.Items[0].Click += new EventHandler(FormMenu_Click);
            myMenu.Items[1].Click += new EventHandler(FormMenu_Click);
            //

            cmbClient.SelectedIndexChanged -= new EventHandler(cmbClient_SelectedIndexChanged);//Added on 23-June-2014 for checking time consumption
            cmbClientNo.SelectedIndexChanged -= new EventHandler(cmbClientNo_SelectedIndexChanged);//Added on 23-June-2014 for checking time consumption

            SetFont();//Commented on 23-June-2014 for checking time consumption
            SetLanguage();
            objSaleInvoiceHelper.LoadClientDetails();
            objSaleInvoiceHelper.Load();
            objSaleInvoiceHelper.LoadItemDetails();
            olstItemDetails = objSaleInvoiceHelper.lstSaleObject;
            AssignToComboBox();
            //objSaleInvoiceHelper.DatatableAssign();//Commented on 23-June-2014 for this function is not needed
            objSaleInvoiceHelper.GetCurrentYear();
            dgrSaleInvoice.BackgroundColor = Color.Beige;  //''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            //dgrSaleInvoice.BackgroundColor = Color.WhiteSmoke;
            dgrSaleInvoice.DefaultCellStyle.BackColor = Color.White;
            cmbClientNo.SelectedIndex = cmbClient.SelectedIndex = -1;
            btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");//"Box F9";

            tmrBlinkNotes.Tick += blinkTextbox;
            tmrBlinkNotes.Interval = 650;
            tmrBlinkNotes.Enabled = true;

            //Added on 18-Apr-14
            cmbPackageQty.DataSource = null;
            cmbPackageQty.Text = "1";
            txtPackage.Visible = false;
            int CashClientID = Convert.ToInt32(CommonHelper.CashClientID.ID);
            string CashClientIDstr = Convert.ToInt32(CommonHelper.CashClientID.ID).ToString();

            cmbClient.SelectedIndexChanged += new EventHandler(cmbClient_SelectedIndexChanged);//Added on 23-June-2014 for checking time consumption
            cmbClientNo.SelectedIndexChanged += new EventHandler(cmbClientNo_SelectedIndexChanged);//Added on 23-June-2014 for checking time consumption
        }

        // Just two eventhandlers added as an example
        private void FormMenu_Click(object sender, EventArgs e)
        {
            string ClickText = sender.ToString();
            if (ClickText.Trim() == "Delete Item" || ClickText.Trim() == "إلغاء صنف")
            {
                btnDeleteItem_Click(sender, e);
            }
            else if (ClickText == "Item Information" || ClickText.Trim() == "بيانات الصنف")
            {
                btnItemInfo_Click(sender, e);
            }

        }

        private void CMSPrice_Click(object sender, EventArgs e)
        {
            string ClickText = sender.ToString();
            if (cmbItem.SelectedIndex > -1)
            {
                int BC = 0;
                BC = (ClickText.Trim() == "Normal Price" || ClickText.Trim() == "سعر عادي") ? -1 : (ClickText.Trim() == "Whole Sale Price" || ClickText.Trim() == "سعر بيع الجملة") ? 0 : (ClickText.Trim() == "Minimum Price" || ClickText.Trim() == "اقل سعر") ? 2 : -1;
                objSaleInvoiceHelper.ButtonClick = BC;
                PriceClick();
                objSaleInvoiceHelper.ButtonClick = BC;
            }
            else
            {
                objSaleInvoiceHelper.ButtonClick = ClickText == "Normal Price" ? -1 : ClickText == "Whole Sale Price" ? 0 : ClickText == "Minimum Price" ? 2 : -1;
            }
        }

        #endregion

        #region Events

        #region Form Load
        private void Sales_Invoice_Load(object sender, EventArgs e)
        {
            
            cmbItem.MatchingMethod = StringMatchingMethod.UseRegexs;
            cmbClient.MatchingMethod = StringMatchingMethod.UseRegexs;
            //***********Date Format Check by Seenivasan on 13-Oct-2014************************//
            dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//
            FormLoad = true;
            ispackage = false;
            Hidecontrols();

            if (GeneralOptionSetting.FlagchkActivatePaymentType == "Y")
            {
                chkPaymentsTypes.Checked = true;
                chkPaymentsTypes.Visible = true;
                lblPaymentCharges.Visible = true;
                txtPaymentCharges.Visible = true;
            }
            else
            {
                chkPaymentsTypes.Checked = false;
                chkPaymentsTypes.Visible = false;
                lblPaymentCharges.Visible = false;
                txtPaymentCharges.Visible = false;
            }

            chkIncludeTax.Checked = ((GeneralOptionSetting.FlagTax1_ApplySales == "Y") | (GeneralOptionSetting.FlagTax2_ApplySales == "Y")) ? true : false;
            objSaleInvoiceHelper.SetLastSaleID();
            txtInvoiceNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid.ToString();
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid;

            this.Clear(); // Line moved from Line number 117 to 115
            DisplayInvoiceDetailsBasedOnInvNo();
            //---------------

            // Open New Invoice (Added on 22-July-2019 By T)
            if (GeneralOptionSetting.FlagOpenNewInvoice == "Y")
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    btnNewInvoice_Click(null, null);
                }
            }

            //DefaultValue(); //Commented  by prabhakaran.S due to change of color in closed invoice while opening
            txtNewInvoiceNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo;

            //--------------------
            dtpExpiry.Text = "";
            lblSerialNo.Visible = false;
            cmbSerialNo.Visible = false;
            if (find_saleinv != "")
            {
                txtInvoiceNo.Text = find_saleinv;
                DisplayInvoiceDetailsBasedOnInvNo();
            }
            cmbItem.SelectAll();
            cmbItem.Focus();
            dtpDate.Value = DateTime.Now;
            dtpDate.MaxDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            //cmbCategory.SelectedIndex = cmbCompany.SelectedIndex = -1;//Commended By Meena.R on  26/12/2014 to select defaut as ALL
            // cmbItem.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            lblUser.Visible = lblUserName.Visible = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? true : false;
            if (lblUser.Text == string.Empty)
                lblUser.Text = GeneralFunction.UserName;
            ScanValue = "0";
            ScanTimingCheck = true;
            ScanLetterStartTime = DateTime.Now;
            btnExportInvoice.Visible = GeneralOptionSetting.FlagPurchase_HideImportExport == "Y" ? false : true;
            // lblTemp.Text = cmbItem.AutoCompleteMode.ToString();
            txtPrice.Enabled = GeneralOptionSetting.FlagSalePriceReadonly == "Y" ? false : true;
            // GeneralOptionSetting.FlagHideItemCostInSales = UserScreenLimidations.ItemCost == true ? "N" : "Y";

            dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
            dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
           

        }
        #endregion


        #region Index Changed Events

        #region Cmb_Category_SelectedIndexChanged
        private void Cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedIndex != -1)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Value = 1;
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt16(cmbCategory.SelectedValue);
                    SetItemsAndNo();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "Cmb_Category_SelectedIndexChanged");

            }

        }
        #endregion

        #region Cmb_Company_SelectedIndexChanged
        private void Cmb_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompany.SelectedIndex != -1)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Value = 0;
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt16(cmbCompany.SelectedValue);
                    SetItemsAndNo();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "Cmb_Company_SelectedIndexChanged");

            }

        }
        #endregion

        #region cmbItem_SelectedIndexChanged
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                if (!IsFromSave)
                {
                    ItemChanges();
                }
                int intTotalStock = 0;
                decimal ActualPrice;
                if (cmbItem.SelectedIndex > -1)
                {
                    objSaleInvoiceHelper.IsFromGridUpdate = false;
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                    List<SaleObject> lstItemDetails = objSaleInvoiceHelper.GetItemNameInfoHelper();

                    if (lstItemDetails.Count > 0)
                    {
                        //cmbItemNo.Text = (cmbItem.SelectedValue != null) ? cmbItem.SelectedValue.ToString() : string.Empty;--->Commented On 17-Apr-14
                        cmbItemNo.SelectedValue = (cmbItem.SelectedValue != null) ? cmbItem.SelectedValue : 0;
                        intTotalStock = lstItemDetails[0].ItemTotalStock;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock = intTotalStock;
                        if (!IsFromSave)
                            txtQuantity.Text = ((ispackage == false) && (intTotalStock < lstItemDetails[0].ItemPackage)) ? "0" : "1";

                        lstItemDetails[0].ItemPackage = (lstItemDetails[0].ItemPackage.ToString() != "" && lstItemDetails[0].ItemPackage.ToString() != "0") ? lstItemDetails[0].ItemPackage : 1;

                        txtPackage.Text = lstItemDetails[0].ItemPackage.ToString();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType = lstItemDetails[0].ItemType;//Added on 13-May-14
                        if ((lstItemDetails[0].ItemType == Convert.ToInt16(ItemType.Meals)) || (lstItemDetails[0].ItemType == Convert.ToInt16(ItemType.Labour)))
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal = true;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost = lstItemDetails[0].ItemCostPer;
                            if (!IsFromSave)
                                txtQuantity.Text = "1";
                        }
                        else
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal = false;

                        ActualPrice = Convert.ToDecimal(lstItemDetails[0].ItemPrice.ToString());
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice = ActualPrice; //Added on 28-Oct-2014
                        // Price 
                        decimal price = objSaleInvoiceHelper.ButtonClick == -1 ? lstItemDetails[0].ItemPrice : objSaleInvoiceHelper.ButtonClick == 0 ? lstItemDetails[0].ItemWholeSalePrice : objSaleInvoiceHelper.ButtonClick == 2 ? lstItemDetails[0].ItemMinimumPrice : lstItemDetails[0].ItemPrice;
                        //

                        if (ispackage == false)
                        {
                            intTotalStock = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / lstItemDetails[0].ItemPackage);
                            txtTotalStock.Text = intTotalStock.ToString();
                            txtPrice.Text = float.Parse(price.ToString()).ToString("#####0.000");//float.Parse(lstItemDetails[0].ItemPrice.ToString()).ToString("#####0.000");
                        }
                        else
                        {
                            intTotalStock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock;
                            txtTotalStock.Text = intTotalStock.ToString();
                            txtPrice.Text = (float.Parse((float.Parse(intTotalStock.ToString()) / lstItemDetails[0].ItemPackage).ToString()) * (float.Parse(price.ToString()))).ToString("#####0.000"); //(float.Parse(lstItemDetails[0].ItemPrice.ToString()))
                        }

                        boxprice = 0.0f;

                        if ((lstItemDetails[0].ItemType != Convert.ToInt16(ItemType.Meals)) && (lstItemDetails[0].ItemType != Convert.ToInt16(ItemType.Labour)))
                        {
                            txtPrice.Text = ((cmbClientNo.SelectedIndex > -1) && ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch == "branch") && (GeneralOptionSetting.FlagBranchBuyswithCost == "Y"))) ? lstItemDetails[0].AvgCost.ToString("#####0.000") : price.ToString("#####0.000"); // lstItemDetails[0].ItemPrice.ToString("#####0.000")
                        }
                        if (RealPrice != "")
                        {
                            txtPrice.Text = RealPrice;
                        }
                        //DiscountCalculation******//
                        //cmbCategory.SelectedIndexChanged -= new System.EventHandler(Cmb_Category_SelectedIndexChanged);
                        //cmbCompany.SelectedIndexChanged -= new System.EventHandler(this.Cmb_Company_SelectedIndexChanged);
                        //cmbCategory.Text = lstItemDetails[0].category;
                        //cmbCompany.Text = lstItemDetails[0].company;
                        //cmbCategory.SelectedIndexChanged += new System.EventHandler(Cmb_Category_SelectedIndexChanged);
                        //cmbCompany.SelectedIndexChanged += new System.EventHandler(this.Cmb_Company_SelectedIndexChanged);
                        DiscountCalculation(txtPrice.Text);
                        //**************************
                        boxprice = float.Parse(txtPrice.Text);


                        cmbPackageQty.Text = lstItemDetails[0].ItemPackage.ToString();//Added on 20-May-2014
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = lstItemDetails[0].BarcodeID;//Added on 20-May-2014
                        //*Start* Setting Notes , Expiry Date and SerialNo  *Start*//

                        if (lstItemDetails[0].ExpiryDate == true)
                        {
                            NotesArea();
                            //if (GeneralOptionSetting.FlagSale_HideExpiryFiled != "Y")
                            //{Commended By meena.R on 27Oct2014
                            if (GeneralOptionSetting.FlagSale_DontUseExpiry != "Y")
                            {
                                dtpExpiry.Visible = true;
                                lblExpiry.Visible = true;
                                if (dtpExpiry.Items.Count > 0)
                                {
                                    dtpExpiry.SelectedIndex = -1;
                                }

                            }
                            if (lstItemDetails[0].ItemExpiryDate.ToString() != "")
                                if (dtpExpiry.Visible == true)
                                {
                                    if (lstItemDetails[0].ItemTotalStock.ToString() != "0")
                                    {
                                        DateTime dta1 = lstItemDetails[0].ItemExpiryDate;
                                        dtpExpiry.Text = dta1.ToShortDateString().ToString();

                                    }
                                }
                        }
                        else
                        {
                            NotesArea();
                            if (lstItemDetails[0].ItemType == Convert.ToInt16(ItemType.SecondHand))
                            {
                                dtpExpiry.Visible = false;
                                lblExpiry.Visible = false;
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "true";
                                lblSerialNo.Visible = true;
                                cmbSerialNo.Visible = true;
                                // cmbPackageQty.Visible = false;//Added on 20-May-2014
                                //lblPackage.Visible = false;//Added on 20-May-2014
                                SerialNoLoad();
                            }
                            else
                            {
                                dtpExpiry.Visible = false;
                                lblExpiry.Visible = false;
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "false";
                                lblSerialNo.Visible = false;
                                cmbSerialNo.Visible = false;
                            }
                        }

                        //*End* Setting Notes , Expiry Date and SerialNo *End*//

                        //*Start* Setting Remaining Textbox *Start*//
                        if ((dtpExpiry.Visible == false) | (GeneralOptionSetting.FlagSale_DontUseExpiry == "Y"))
                        {
                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                            {
                                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock != 0)
                                {
                                    int serialstock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock;
                                    txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                                    if ((txtQuantity.Text != "") && (txtQuantity.Text != "0"))
                                    {
                                        int intQuantity = Convert.ToInt32(txtQuantity.Text);
                                        int intRemainig = 0;
                                        if (serialstock > 0)
                                            intRemainig = serialstock - intQuantity;
                                        else
                                            intRemainig = serialstock;
                                        if (intRemainig < 0)
                                        {
                                            txtQuantity.Text = serialstock.ToString();
                                            txtRemaining.Text = "0";
                                        }
                                        else
                                            txtRemaining.Text = intRemainig.ToString();
                                    }
                                    if (txtQuantity.Text == "")
                                        txtRemaining.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock.ToString();
                                    if ((txtRemaining.Text != "0") && (txtRemaining.Text != ""))
                                        txtQuantity.Text = "1";
                                    else
                                        txtQuantity.Text = "1";

                                }
                                else
                                    txtRemaining.Text = "0";
                                BoxPrice();
                                txtPackage.Text = lstItemDetails[0].ItemPackage.ToString();
                                StockAdjust();
                            }
                            else
                            {
                                if (lstItemDetails[0].ItemTotalStock.ToString() != "")
                                {
                                    int re = lstItemDetails[0].ItemTotalStock;
                                    if (re != 0)
                                    {

                                    }
                                    txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                                    if ((txtQuantity.Text != ""))
                                    {
                                        int qu = Convert.ToInt32(txtQuantity.Text);
                                        int reas = 0;
                                        reas = re - qu;
                                        if (reas < 0)
                                            txtRemaining.Text = "0";
                                        else
                                            txtRemaining.Text = reas.ToString();
                                    }

                                }
                                else
                                    txtRemaining.Text = "0";
                                BoxPrice();
                                txtPackage.Text = lstItemDetails[0].ItemPackage.ToString();
                                StockAdjust();
                            }

                        }

                        //*End* Setting Remaining Textbox *End*//



                        //Reorderitem//
                        if ((lstItemDetails[0].ItemTotalStock / lstItemDetails[0].ItemPackage) <= (lstItemDetails[0].Reorder))
                        {
                            if ((!rtxtNotesAndAlerts.Text.Contains("ReorderItems :")))
                            {
                                if ((GeneralOptionSetting.FlagMonitorReorderAndMaxpoint == "Y") || (GeneralOptionSetting.FlagAlertForReorders == "Y"))
                                {
                                    SetNotes();
                                    ReorderItems();
                                }
                            }
                        }
                        ///***********

                        //objSaleInvoiceHelper.ButtonClick = 0;

                    }

                    //Added below on 18-April-2014 for Multipackage QTy for One Item
                    //if (lstItemDetails[0].ItemType == Convert.ToInt16(ItemType.Goods) || lstItemDetails[0].ItemType == Convert.ToInt16(ItemType.SecondHand))
                    //{
                    List<SaleObject> lstPackageQtyforItem = objSaleInvoiceHelper.GetPackageQtyForItemHelper();
                    if (lstPackageQtyforItem.Count > 0)
                    {
                        cmbPackageQty.SelectedIndex = -1;
                        cmbPackageQty.DisplayMember = "PackageQuantity";
                        cmbPackageQty.ValueMember = "BarcodeID";
                        cmbPackageQty.DataSource = lstPackageQtyforItem;//Commented on 6-May-2014
                        // cmbPackageQty.DataSource = lstPackageQtyforItem.Select(a => a.PackageQuantity).Distinct().ToList();
                        cmbPackageQty.SelectedIndex = 0;
                    }
                    if (RealPackage != "")
                    {
                        cmbPackageQty.Text = RealPackage;
                    }
                    if (RealExpireDate != "")
                    {
                        dtpExpiry.Text = RealExpireDate;
                    }
                    // }
                    //this condition added on 11Nov2014 By Meena.R to fix the apply avg cost as the price 
                    if ((lstItemDetails[0].ItemType != Convert.ToInt16(ItemType.Meals)) && (lstItemDetails[0].ItemType != Convert.ToInt16(ItemType.Labour)))
                    {
                        if (((cmbClientNo.SelectedIndex > -1) && ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch == "branch") && (GeneralOptionSetting.FlagBranchBuyswithCost == "Y"))))
                            txtPrice.Text = (lstItemDetails[0].AvgCost * Convert.ToInt32(cmbPackageQty.Text)).ToString();
                    }
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                    AvgCostofItem = lstItemDetails[0].AvgCost;
                }
                //commented on 26/30/2014 Should include 

                //  List<SaleObject> ListOfItemDetails = objSaleInvoiceHelper.GetDetailsOfItem();
                //if (ListOfItemDetails.Count > 0)
                //{
                //    ItemDetails Item = new ItemDetails("Sales");

                //    Item.ShowDialog();
                //    AssignItemDetailsToSalesObject();


                //}
                ////txtQuantity.Focus();
                ////txtQuantity.SelectAll();//Added on 27-June-2017 by Seenivasan ///commented on 28 jun 2014 to highlight the item when press the down arrow from keyboard
                SetRowColor(cmbItem.Text);

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbItem_SelectedIndexChanged");
            }
        }
        private void AssignItemDetailsToSalesObject()
        {
            for (int i = 0; i < GetDetailsFromItem.Count; i++)
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemNo = Convert.ToInt32(GetDetailsFromItem[0]);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemName = GetDetailsFromItem[1].ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemPrice = Convert.ToDecimal(GetDetailsFromItem[2]);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost = Convert.ToDecimal(GetDetailsFromItem[3]);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.UnitType = GetDetailsFromItem[4].ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemPackage = Convert.ToInt32(GetDetailsFromItem[5]);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.UnitName = GetDetailsFromItem[6].ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemExpiry = Convert.ToDateTime(GetDetailsFromItem[7]);
                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNo = Convert.ToInt32(GetDetailsFromItem[8]);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNo = GetDetailsFromItem[8].ToString();
                ObjectOfSales.Add(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject);

            }

        }
        #endregion

        #region cmbSerialNo_SelectedIndexChanged
        private void cmbSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmbSerialNo.SelectedIndex != -1)
                {
                    SerialNoChanged();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbSerialNo_SelectedIndexChanged");
            }

        }
        #endregion

        #region dtpExpiry_SelectedIndexChanged
        private void dtpExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((dtpExpiry.Items.Count > 0) && (dtpExpiry.SelectedIndex < 0))
                    dtpExpiry.SelectedIndex = 0;

                if ((dtpExpiry.Visible == true) && (dtpExpiry.Items.Count > 0) && (cmbItem.SelectedIndex > -1) && (dtpExpiry.SelectedIndex > -1) && (dtpExpiry.Text.ToString() != "System.Data.DataRowView"))
                {

                    txtRemaining.Text = "0";
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dtpExpiry.Text != "ObjectHelper.SaleObject" ? dtpExpiry.Text : "");
                    //int expirystock = 0;
                    DataTable dt = new DataTable();
                    //  dt = obj_saleinvoice_dal.get_stock_basedexpiry();
                    List<SaleObject> lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedExpiryHelper();
                    if (lstStockBasedexpiry.Count > 0)
                    {
                        if ((lstStockBasedexpiry[0].ItemTotalStock.ToString() != "") && (lstStockBasedexpiry[0].ItemTotalStock.ToString() != null))
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expstock = lstStockBasedexpiry[0].ItemTotalStock;
                            int re = lstStockBasedexpiry[0].ItemTotalStock;
                            if ((re != 0) && (txtPackage.Text != "") && (txtPackage.Text.ToString() != "System.Data.DataRowView"))

                                txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                            if ((txtQuantity.Text != "") && (txtQuantity.Text != "0"))
                            {
                                int qu = Convert.ToInt32(txtQuantity.Text);
                                int reas = 0;
                                //reas = (ispackage == false) ? ((re / lstStockBasedexpiry[0].ItemPackage) - qu) : (re - qu);//Commented on 18-Apr-14 for Multiple Package Qty 
                                reas = (ispackage == false) ? ((re / Convert.ToInt16(cmbPackageQty.Text)) - qu) : (re - qu); //Added on 18-Apr-14 for Multiple Package Qty

                                if (reas < 0)
                                    txtRemaining.Text = "0";
                                else
                                    txtRemaining.Text = reas.ToString();
                            }
                            if ((txtQuantity.Text == "") || (txtQuantity.Text == "0"))
                                //  txtRemaining.Text = (ispackage == true) ? lstStockBasedexpiry[0].ItemTotalStock.ToString() : (re / lstStockBasedexpiry[0].ItemPackage).ToString();//Commented on 18-Apr-14 for Multiple Package Qty 
                                txtRemaining.Text = (ispackage == true) ? lstStockBasedexpiry[0].ItemTotalStock.ToString() : (re / Convert.ToInt16(cmbPackageQty.Text)).ToString();//Added on 18-Apr-14 for Multiple Package Qty 

                        }
                        else
                            txtRemaining.Text = "0";

                    }
                    else
                    {

                        PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                        frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbesold");
                        frmExpiry.ShowDialog();

                    }



                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "dtp_expiry_SelectedIndexChanged");
            }
        }
        #endregion

        #region cmbItemNo_SelectedIndexChanged
        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                GetItemName();
               // objSaleInvoiceHelper.ButtonClick = 0;
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbItemNo_SelectedIndexChanged");

            }
        }
        #endregion

        #region cmbClient_SelectedIndexChanged
        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbClient.SelectedIndex != -1)
                {
                    ClientNameChange();
                    cmbItem_SelectedIndexChanged(sender, e);
                    //if ((cmbItem.Items.Count > 0) && (cmbClient.SelectedValue.ToString() != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()))
                    //{
                    //    cmbItem_SelectedIndexChanged(sender, e);
                    //}
                    cmbItem.Focus();
                    GeneralFunction.CashClientName = cmbClientNo.Text.ToString();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbClient_SelectedIndexChanged");
            }
        }
        #endregion

        #region cmbClientNo_SelectedIndexChanged
        private void cmbClientNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbClientNo.SelectedIndex != -1)
                {
                    ClientSelected();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbClientNo_SelectedIndexChanged");

            }
        }
        #endregion

        #region cmbPackageQty_SelectedIndexChanged
        private void cmbPackageQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPackageQty.SelectedIndex != -1 && cmbPackageQty.Text != "")
                {
                    int PackageQty = (cmbPackageQty.Text != "0" ? Convert.ToInt16(cmbPackageQty.Text) : 1);
                    List<SaleObject> lstStockBasedexpiry = new List<SaleObject>();
                    List<SaleObject> lstExpiryBasedPackage = new List<SaleObject>();
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = Convert.ToInt32(cmbPackageQty.SelectedValue);//Added on 20-May-2014

                    //******Added on 20-May-2014***********
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType == Convert.ToInt16(ItemType.Goods))
                    {
                        lstExpiryBasedPackage = objSaleInvoiceHelper.GetExpiryBasedPackageHelper();//Added on 20-May-2014
                        if (lstExpiryBasedPackage.Count > 0)
                        {
                            dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
                            dtpExpiry.DataSource = null;
                            dtpExpiry.DisplayMember = "ItemExpiryDate";
                            dtpExpiry.ValueMember = "StockID"; //Added on 20-May-2014
                            dtpExpiry.DataSource = lstExpiryBasedPackage;
                            dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);
                            dtpExpiry.SelectedIndex = 0;
                        }
                    }
                    else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType == Convert.ToInt16(ItemType.SecondHand))
                    {
                        lstExpiryBasedPackage = objSaleInvoiceHelper.GetSerialNoBasedPackageHelper();
                        if (lstExpiryBasedPackage.Count > 0)
                        {
                            cmbSerialNo.SelectedIndexChanged -= new EventHandler(cmbSerialNo_SelectedIndexChanged);
                            cmbSerialNo.DataSource = null;
                            cmbSerialNo.DataSource = lstExpiryBasedPackage;
                            cmbSerialNo.DisplayMember = "SerialNo";
                            cmbSerialNo.ValueMember = "StockID";//Commented on 20-May-2014
                            //txtTotalStock.Text = lstSerialNo[0].ItemTotalStock.ToString();
                            //txtPrice.Text = lstSerialNo[0].ItemPrice.ToString();
                            cmbSerialNo.SelectedIndexChanged += new EventHandler(cmbSerialNo_SelectedIndexChanged);
                            cmbSerialNo.SelectedIndex = 0;
                        }
                    }
                    //************************************
                    //Goods Item Has Expiry Date
                    if ((dtpExpiry.Visible == true) && (dtpExpiry.Items.Count > 0) && (cmbItem.SelectedIndex > -1) && (dtpExpiry.SelectedIndex > -1) && (dtpExpiry.Text.ToString() != "System.Data.DataRowView"))
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dtpExpiry.Text);
                        lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedExpiryHelper();
                    }
                    else if (dtpExpiry.Visible == false && cmbSerialNo.Visible == false && objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                    {
                        lstStockBasedexpiry = objSaleInvoiceHelper.GetItemNameInfoHelper();
                    }
                    else if ((cmbItem.Text.Trim() != "") && (cmbSerialNo.Items.Count > 0) && (cmbSerialNo.Text != string.Empty))
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = cmbSerialNo.Text;
                        lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();
                    }


                    if (lstStockBasedexpiry.Count > 0)
                    {
                        if ((lstStockBasedexpiry[0].ItemTotalStock.ToString() != "") && (lstStockBasedexpiry[0].ItemTotalStock.ToString() != null))
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ButtonClick = objSaleInvoiceHelper.ButtonClick;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = Convert.ToInt32(cmbPackageQty.SelectedValue);
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price = objSaleInvoiceHelper.GetPriceForPackageQtyHelper();
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price;//Added on 28-Oct-2014
                            txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText = txtQuantity.Text;
                            if ((txtQuantity.Text != "") && (txtQuantity.Text != "0"))
                            {
                                DiscountCalculation((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("#####0.000"));
                                if (RealPrice != "")
                                {
                                    txtPrice.Text = RealPrice;
                                }
                                boxprice = float.Parse(txtPrice.Text);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price = Convert.ToDecimal(txtPrice.Text);//Added on 13-May-2014 for Getting Discounted Price
                                float NewPrice = boxprice;
                                if (ispackage == false)
                                {

                                    txtTotalStock.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / PackageQty).ToString(); // Added on 21-Apr-14
                                    //  txtPrice.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("#####0.000");//Commented om 6-June-2014
                                    txtPrice.Text = RoundPrice(NewPrice).ToString("#####0.000");//Added om 6-June-2014
                                }
                                else
                                {

                                    txtTotalStock.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString(); // Added on 21-Apr-14
                                    //  txtPrice.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price / PackageQty).ToString("#####0.000");//Commented om 6-June-2014
                                    txtPrice.Text = RoundPrice(NewPrice / PackageQty).ToString("#####0.000");//Added om 6-June-2014
                                }
                                if (RealPrice != "")
                                {
                                    txtPrice.Text = RealPrice;
                                }
                                int reas = 0;
                                //   objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.RemainingText;
                                reas = (ispackage == false) ? ((lstStockBasedexpiry[0].ItemTotalStock / PackageQty) - Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText)) : (lstStockBasedexpiry[0].ItemTotalStock - Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText));
                                if (reas < 0)
                                    txtRemaining.Text = "0";
                                else
                                    txtRemaining.Text = reas.ToString();
                            }
                            if ((txtQuantity.Text == "") || (txtQuantity.Text == "0"))
                            {
                                txtRemaining.Text = (ispackage == true) ? lstStockBasedexpiry[0].ItemTotalStock.ToString() : (lstStockBasedexpiry[0].ItemTotalStock / PackageQty).ToString();
                            }

                        }
                        else
                        {
                            txtRemaining.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbPackageQty_SelectedIndexChanged");

            }
        }
        #endregion


        #endregion

        #region Button Click Events

        #region btnNewInvoice_Click
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                //  dgrSaleInvoice.DataSource = null; This grid again filled somewhere.
                objSaleInvoiceHelper.ButtonClick = -1;
                NewInvoice();
                DisplayInvoiceDetailsBasedOnInvNo();
                cmbItem.Text = "";//Added on 26-May-2014 fro Adding Focus when click new invoice
                cmbItem.Focus();
                cmbItem.SelectedIndex = -1;
                //**********************The below line is added to net value refresh once I click new

                txtNet.Text = "0";
                //*************************
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.New), txtInvoiceNo.Text, "SALEs", "New sale invoice details", Convert.ToInt32(InvoiceAction.Yes));
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "btnNewInvoice_Click");
            }


        }
        #endregion

        #region btnF9_Click
        private void btnF9_Click(object sender, EventArgs e)
        {
            try
            {
                BoxFunction();
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "button_boxF9_Click");
            }
        }
        #endregion

        #region btnInsertItem_Click
        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            if (cmbClient.Text == "")
            {
                RealPrice = txtPrice.Text;
                RealPackage = cmbPackageQty.Text;
                RealExpireDate = dtpExpiry.Text;
            }
            else
            {
                RealPrice = "";
                RealPackage = "";
                RealExpireDate = "";
            }
            var price = txtPrice.Text;
            InsertItemttoGrid();
            RealPrice = "";
            RealPackage = "";
            RealExpireDate = "";
        }


        private void InsertItemttoGrid()
        {
            List<SaleObject> objDate;
            try
            {
                if (GeneralOptionSetting.FlagAlertForMultiExpiry == "Y")//added this alert on 28Oct2014 By Meena.R
                {
                    if (cmbItem.SelectedIndex != -1 && dtpExpiry.SelectedIndex == 0)
                    {
                        if (dtpExpiry.Items.Count > 1)
                        {
                            string str = GeneralFunction.ChangeLanguageforCustomMsg("TheItem") + Environment.NewLine + cmbItem.Text + "\r\n" + GeneralFunction.ChangeLanguageforCustomMsg("ExpiryDate") + "\r\n";
                            objDate = ((List<SaleObject>)dtpExpiry.DataSource);
                            for (int i = 0; i < objDate.Count; i++)
                            {
                                DateTime Date = Convert.ToDateTime(objDate[i].ItemExpiryDate);
                                str = str + "\n " + Date.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                            }
                            if (MessageBox.Show(str, GeneralFunction.ChangeLanguageforCustomMsg("Sales Invoice"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                    }
                }
                IsFromSave = true;
                StockAdjustOnKeyUp();
                Insert();
                SetLastRowColor();
                IsFromSave = false;
                // objSaleInvoiceHelper.Load();Commended by Meena.R for scanning tunning on 08Jan2015
                CommondtItem = objSaleInvoiceHelper.GetSalesItemDetails();
                LoadItems();
                // Added on 15/12/2014 for Performance Issue when adding menu Item in Sales 
                //Thread obj = new Thread(LoadItems);
                //obj.Start();
                //cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);//added on 11/12/2014
                //cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
                //if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                //{
                //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(a => a.stock > 0).OrderBy(n => n.ItemName).ToList();
                //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty && i.stock > 0).ToList();
                //}
                //else
                //{
                //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();
                //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty).ToList();
                //}
                //cmbItem.SelectedIndex = -1;
                //cmbItemNo.SelectedIndex = -1;
                //cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
                //cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
                // objLoad.BeginInvoke(loadItemDetails, null);
            }

            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "btnInsertItem_Click");
            }
            finally //Added for Performance Tuning on 18-Nov-2014 by Seenivasan
            {
                objDate = null;
            }
        }

        #endregion

        #region btnDeleteItem_Click
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return;
                }
                // datagrid_saleinvoice.MouseMove -= new MouseEventHandler(datagrid_saleinvoice_MouseMove);
                radPercentage.Enabled = true;
                radValue.Enabled = true;
                //Grb_ItemInformation.Visible = false;
                ItemDeletion();
                SetItem();
                NotesArea();

                // objLoad.BeginInvoke(loadItemDetails, null);
                deleteditem = "";


                //  objSaleInvoiceHelper.Load();Commended by Meena.R on 8jan2015
                CommondtItem = objSaleInvoiceHelper.GetSalesItemDetails();
                LoadItems();
                //Thread deleterefresh = new Thread(LoadItems);
                //deleterefresh.Start();//this applied by Meena.R on 19Dec2014
                //if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                //{
                //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(a => a.stock > 0).OrderBy(n => n.ItemName).ToList();
                //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty && i.stock > 0).ToList();
                //}
                //else
                //{
                //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();
                //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty).ToList();
                //}
                //cmbItem.SelectedIndex = -1;
                //cmbItemNo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // GeneralFunction.ErrMsg(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "button_delete_item_Click");
            }
        }
        #endregion

        #region btnNavigation_Click

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            try
            {
                cmbItem.Focus();
                radPercentage.Enabled = false;
                radValue.Enabled = false;
                //*****Naviagtion Part********//
                objSaleInvoiceHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt32(txtInvoiceNo.Text);
                objSaleInvoiceHelper.NavigationEventTesting();
                txtInvoiceNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv.ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv;
                DisplayInvoiceDetailsBasedOnInvNo();
                //*****Naviagtion Part********//
                if (dgrSaleInvoice.Rows.Count <= 0)
                {
                    //cmbCategory.SelectedIndex = cmbCompany.SelectedIndex = cmbItem.SelectedIndex = -1;
                    //cmbItemNo.SelectedIndex = cmbClient.SelectedIndex = cmbClientNo.SelectedIndex = -1;
                    //cmbClient.Focus();
                }
                cmbItem.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "btnNavigation_Click");
            }
        }

        #endregion

        #region btnCloseInvoice_Click
        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            //closeInvLoader.Visible = true;

            SetObjectFromControl();
            //if (GeneralOptionSetting.FlagchkActivatePaymentType == "Y" || chkPaymentsTypes.Checked == true)
            if (chkPaymentsTypes.Checked == true)
            {
                if (dgrSaleInvoice.BackgroundColor == Color.WhiteSmoke)
                {
                    isPaymentMethodOn = true;
                    PaymentTypes form = new PaymentTypes();
                    // add these properties on 26-Feb-2019
                    form.NewYearInvoiceNo = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo.ToString();
                    form.InvoiceNoText = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                    form.ClientText = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText;
                    if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.balance > 0)) //(obj_saleinvoice.balance != null) && 
                    {
                        form.NetAmt = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.balance.ToString();
                        form.Value = Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.balance).ToString("####0.000");
                    }
                    else
                    {
                        form.NetAmt = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText != string.Empty) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText : "0.000";
                        form.Value = Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText != string.Empty) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText : "0.000").ToString("####0.000");
                    }
                    //
                    clientClosedSales = cmbClient.SelectedValue.ToString();
                    PaymentTypes.receiptDesc = txtNewInvoiceNo.Text;
                    salesTotal = txtTotal.Text == null ? 0 : Convert.ToDouble(txtTotal.Text);
                    PaymentTypes.isFromSales = true;
                    form.ShowDialog();
                    // this statement created on 10/27/2018
                    if (PaymentTypes.isCheckSave == false)
                    {
                        txtPaymentCharges.Text = "0.000";
                        return;
                    }
                    else
                        txtPaymentCharges.Text = salesTotal.ToString();
                }
                //  

                //if (PaymentTypes.isCheckSave == false)
                //    return;
            }
            else
                isPaymentMethodOn = false;

            // Added on 13-Mar-2019 By T
            if (GeneralOptionSetting.FlagEnableNetworkSaleControl == "Y")
            {
                Random random = new Random();
                int randomNumber = random.Next(500, 5000);
                Thread.Sleep(randomNumber);
            }
            try
            {
                SetObjectFromControl();
                if (cmbClientNo.SelectedIndex < 0)
                {
                    cmbClientNo.SelectedIndex = 0;
                }
                if (objSaleInvoiceHelper.ValidateCloseInv() == false) return;
                Boolean eligible = false;
                eligible = objSaleInvoiceHelper.DebtCalculation();

                if ((cmbClientNo.Text != "") && (cmbClientNo.Text != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()))
                {
                    if (eligible != false)
                    {
                        GeneralFunction.Information("ExceedClientDebtLimit", "SalesInvoice");

                    }
                    else
                    {
                        if ((GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") && (GeneralFunction.UserName != "Admin") && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                        {
                            if ((txtNet.Text != "") && (txtTotalSaleValue.Text != ""))
                            {
                                if (float.Parse(txtNet.Text) < float.Parse(txtTotalSaleValue.Text))
                                {
                                    GeneralFunction.Information("LessthanTotalCost", "Sales Invoice");
                                    if (GeneralFunction.Question("AlertCloseInvoice", "Sales Invoice") == DialogResult.Yes)
                                        CloseMethod();
                                }
                                else
                                    CloseMethod();
                            }
                        }
                        else
                            CloseMethod();
                    }
                }
                else if (cmbClientNo.Text == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
                {
                    if ((GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                    {
                        if (GeneralFunction.UserName != "Admin")
                        {
                            if ((txtNet.Text != "") && (txtTotalSaleValue.Text != ""))
                            {
                                if (float.Parse(txtNet.Text) < float.Parse(txtTotalSaleValue.Text))
                                {
                                    GeneralFunction.Information("LessthanTotalCost", "Sales Invoice");
                                    if (GeneralFunction.Question("AlertCloseInvoice", "Sales Invoice") == DialogResult.Yes)
                                        CloseMethod();
                                }
                                else
                                    CloseMethod();
                            }
                        }
                        else
                        {
                            CloseMethod();
                        }
                    }
                    else { CloseMethod(); }
                }

                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Save), txtNewInvoiceNo.Text.ToString(), "Sales", "Save(close) sale invoice details", Convert.ToInt32(InvoiceAction.Yes));

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SalesInvoice", "btnCloseInvoice_Click");

            }

            closeInvLoader.Visible = false;
        }
        #endregion

        #region btnModifyInvoice_Click
        private void btnModifyInvoice_Click(object sender, EventArgs e)
        {
            SetObjectFromControl();

            try
            {
                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DgrBgColorValue == "Color [Gray]")
                {
                    if (GeneralFunction.Question("AlertModifyInvoice", "Sales Invoice") == DialogResult.Yes)
                    {
                        if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActiveUserText != string.Empty) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActiveUserText.Trim() != GeneralFunction.UserId.ToString()) && objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActiveUserText != "0" && GeneralFunction.UserId != 101)
                        {
                            GeneralFunction.Information("AnotherUserUsingThisInvoice", "SalesInvoice");
                            return;
                        }
                        radPercentage.Enabled = radValue.Enabled = txtDiscount.Enabled = ((UserScreenLimidations.DiscountAmt) && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false;

                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PercentageChecked = (GeneralOptionSetting.FlagDisableDiscountFiled != "Y") ? true : false;

                        radPercentage.Enabled = radValue.Enabled = txtDiscount.Enabled = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PercentageChecked;
                        int Enable = 0;
                        string OldInvNo = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText.ToString();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                        List<SaleObject> lstSaleDetails = objSaleInvoiceHelper.GetSaleDetailsHelper();
                        if (lstSaleDetails.Count > 0)
                        {
                            {
                                if (UserScreenLimidations.ModifyInvoice)
                                    Enable = 1;
                                else if (UserScreenLimidations.ModifyTodayInvoice)
                                {
                                    String s = DateTime.Now.ToShortDateString();
                                    if (Convert.ToDateTime(lstSaleDetails[0].CreatedDate.ToString()).ToShortDateString() == s)
                                        Enable = 1;
                                    else
                                        Enable = 0;

                                }

                            }

                        }

                        if (Enable == 1)
                        {
                            if (objSaleInvoiceHelper.ModifyInvoiceHelper())
                            {
                                dgrSaleInvoice.BackgroundColor = System.Drawing.Color.Beige;  //''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                                //dgrSaleInvoice.BackgroundColor = System.Drawing.Color.WhiteSmoke;
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv;
                                DisplayInvoiceDetailsBasedOnInvNo();
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Modify), txtNewInvoiceNo.Text, "Sale", "Modify sale invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            }
                            else
                                GeneralFunction.Information("Amountalreadypaidforthissale", "Sales Invoice");
                        }
                        else
                            GeneralFunction.Information("UserCantModifyInvoice", "Sales Invoice");
                    }

                }
                else

                    GeneralFunction.Information("NotClosedInvoice", "Sales Invoice");

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnModifyInvoice_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                radPercentage.Enabled = true;
                radValue.Enabled = true;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = 0;
                objSaleInvoiceHelper.UpdateActiveUserHelper();
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnClose_Click");
            }
        }
        #endregion

        #region btnPriceChange_Click
        private void btnPriceChangeF7_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralOptionSetting.FlagHidePriceChangingButton != "Y")
                {
                    PriceClick();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnPriceChangeF7_Click");
            }
        }
        #endregion

        #region btnExportInvoice_Click
        private void btnExportInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrSaleInvoice.RowCount <= 0)
                {
                    GeneralFunction.Information("NoRecordsFound", "Sales Invoice");
                    return;
                }
                if (dgrSaleInvoice.BackgroundColor == Color.Gray)
                {
                    ExportMessage frmExportMessage = new ExportMessage();
                    frmExportMessage.ShowDialog();
                    if (frmExportMessage.IsExport)
                    {
                        string filename;
                        DataTable dtExport = new DataTable("ExportData");
                        ColumnAdd(ref dtExport);
                        DataRow dr;
                        foreach (DataGridViewRow var in dgrSaleInvoice.Rows)
                        {

                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(var.Cells["ItemNo"].Value.ToString());
                            List<SaleObject> lstItemInfo = objSaleInvoiceHelper.GetItemInfoExportHelper().ToList().Where(a => a.ItemPackage == Convert.ToInt32(var.Cells["Package"].Value)).ToList();
                            //decimal unitprice = decimal.Parse((Math.Truncate(((lstItemInfo[0].ItemCostPer) / ((lstItemInfo[0].ItemPackage == 0 || lstItemInfo[0].ItemPackage == null) ? 1 : lstItemInfo[0].ItemPackage)) * 1000) / 1000m).ToString("#####0.000"));
                            decimal unitprice = (lstItemInfo[0].ItemCostPer);
                            dr = dtExport.NewRow();
                            dr["ItemNo"] = var.Cells["ItemNo"].Value.ToString();
                            dr["Description"] = var.Cells["ItemDesc"].Value.ToString();
                            dr["Expiry"] = var.Cells["ExpiryDate"].Value.ToString();
                            dr["Package"] = var.Cells["Package"].Value.ToString();
                            dr["Quantity"] = var.Cells["Qty"].Value.ToString();
                            if (frmExportMessage.ExportMethod == 1)//Same Cost and price
                                dr["UnitPrice"] = decimal.Parse(var.Cells["Unitprices"].Value.ToString()) * Convert.ToInt32(var.Cells["Package"].Value.ToString());
                            else if (frmExportMessage.ExportMethod == 2)//Actual invoice Cost
                                dr["UnitPrice"] = unitprice;//Commented on 7-May-2014
                            //dr["UnitPrice"] = Convert.ToString(decimal.Parse(var.Cells["Unitprices"].Value.ToString()));
                            dr["Total"] = var.Cells["totalpric"].Value.ToString();
                            dr["Time"] = var.Cells["DateModified"].Value.ToString();
                            dr["User"] = var.Cells["Users"].Value != null ? var.Cells["Users"].Value.ToString() : "0";
                            dr["Returned"] = var.Cells["ReturnQuantity"].Value.ToString();
                            dr["Agent"] = var.Cells["ClientsID"].Value.ToString();
                            dr["SaledetId"] = var.Cells["saledetailid"].Value.ToString();
                            dr["SaleId"] = var.Cells["salesid"].Value.ToString();
                            dr["Discount"] = var.Cells["itemdisc"].Value.ToString();
                            dr["SerialNo"] = var.Cells["serialnumber"].Value != null ? var.Cells["serialnumber"].Value.ToString() : "0";
                            dr["ItemType"] = lstItemInfo[0].ItemType.ToString();
                            dr["IsExpiry"] = lstItemInfo[0].ExpiryDate.ToString();
                            dr["ReOrder"] = lstItemInfo[0].Reorder.ToString();
                            dr["MinimumPrice"] = lstItemInfo[0].ItemMinimumPrice.ToString();
                            dr["WholeSale"] = lstItemInfo[0].ItemWholeSalePrice.ToString();
                            dr["IsHide"] = lstItemInfo[0].Status.ToString();
                            dr["MaxOrder"] = lstItemInfo[0].MaxOrder.ToString();
                            dr["Barcode"] = lstItemInfo[0].ItemBarcode.ToString();
                            //dr["ItemCost"] = Convert.ToString(decimal.Parse(var.Cells["Unitprices"].Value.ToString()));//dtItem.Rows[0]["MTB_AVERAGE_COST"].ToString();
                            if (frmExportMessage.ExportMethod == 1)//Same Cost and price
                                //  dr["ItemCost"] = decimal.Parse(var.Cells["Unitprices"].Value.ToString()) * Convert.ToInt32(var.Cells["Package"].Value.ToString());
                                dr["ItemCost"] = (lstItemInfo[0].ItemPrice);
                            else if (frmExportMessage.ExportMethod == 2)//Actual invoice Cost
                                dr["ItemCost"] = unitprice;
                            dr["CompName"] = lstItemInfo[0].CompanyName.ToString();
                            dr["CategoryName"] = lstItemInfo[0].CategoryName.ToString();
                            dr["AdditionalBarcode"] = lstItemInfo[0].ItemAdditionalBarcode.ToString();
                            dr["ItemPlace"] = lstItemInfo[0].ItemPlaceName.ToString();
                            //SalePrice added by Meena
                            dr["SalePrice"] = decimal.Parse(var.Cells["Unitprices"].Value.ToString()) * Convert.ToInt32(var.Cells["Package"].Value.ToString());
                            dr["IsPackage"] = var.Cells["BoxQty"].Value.ToString();
                            dtExport.Rows.Add(dr);
                        }

                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "XML Files (*.xml)|*.xml";
                        sfd.AddExtension = true;
                        sfd.OverwritePrompt = true;
                        sfd.Title = "Export Item Details";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            filename = sfd.FileName.ToString();
                            StreamWriter myWriter = new StreamWriter(filename, false);
                            XmlSerializer mySerializer = new XmlSerializer(typeof(DataTable));
                            mySerializer.Serialize(myWriter, dtExport);
                            myWriter.Close();
                            GeneralFunction.Information("Item details exported successfully", "Sales Invoice");
                        }
                    }
                }
                else
                {
                    GeneralFunction.Information("CloseInvoice", "Sales Invoice");
                }
            }

            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnExportInvoice_Click");
            }
        }
        #endregion

        #region btnReceiveReceipt_Click
        private void btnReceiveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                salesTotal = string.IsNullOrEmpty(txtNet.Text) ? 0 : Convert.ToDouble(txtNet.Text);
                PaymentTypeID = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID;
                PaymentChagers = string.IsNullOrEmpty(txtPaymentCharges.Text) ? 0 : Convert.ToDouble(txtPaymentCharges.Text);
                objSaleInvoiceHelper.ReceiveReceiptClick();
                PaymentTypeID = 0;
                PaymentChagers = 0;
                DisplayInvoiceDetailsBasedOnInvNo();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnReceiveReceipt_Click");
            }
        }
        #endregion

        #region btnFindInvoice_Click
        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                radPercentage.Enabled = true;
                radValue.Enabled = true;

                Find_Sales_Invoice objFrm = new Find_Sales_Invoice();
                //objFrm.clientno = cmbClientNo.Text;
                //objFrm.clientname = cmbClient.Text;
                objFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnFindInvoice_Click");
            }
        }
        #endregion

        #region btnReturnItem_Click
        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {



                radPercentage.Enabled = true;
                radValue.Enabled = true;
                Sales_Return_Invoice objFrm = new Sales_Return_Invoice();
                objFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnReturnItem_Click");
            }

        }
        #endregion

        #region btnBalanceSheet_Click
        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                radPercentage.Enabled = true;
                radValue.Enabled = true;

                frmBalanceSheet objFrm = new frmBalanceSheet();

                if (cmbClientNo.SelectedValue != null)
                {
                    objFrm.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt16(cmbClientNo.Text);
                }
                if (cmbClient.SelectedValue != null)
                {
                    objFrm.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbClient.Text.ToString();
                }
                objFrm.ShowDialog();

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnBalanceSheet_Click");
            }
        }
        #endregion

        #region btnItemCard_Click
        private void btnItemCard_Click(object sender, EventArgs e)
        {
            try
            {

                radPercentage.Enabled = true;
                radValue.Enabled = true;
                ItemCard objFrm = new ItemCard();
                objFrm.ShowDialog();
                //************Added on 26-Sep-2018***********************************************************
                if (ItemCard.IsItemSave)
                {
                    CommondtItem = objSaleInvoiceHelper.GetSalesItemDetails();
                    LoadItems();

                    this.Clear();
                }
                //***********************************************************************
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnItemCard_Click");
            }
        }
        #endregion

        #region btnItemInfo_Click
        private void btnItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ItemInfo();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnItemInfo_Click");
            }
        }
        #endregion

        #region btnReset_Click
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetFunc();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnReset_Click");
            }

        }
        #endregion


        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") & (dgrSaleInvoice.BackgroundColor != Color.Gray))
                {
                    GeneralFunction.Information("Pleaseclosetheinvoicefirst", "Sales Invoice");
                    return;
                }
                if (Chk_PrintCashClientName.Checked && cmbClientNo.Text == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
                {
                    if (GeneralFunction.Question("Do You Want To Print The Cash Client Name", "Cash Client Name") == DialogResult.Yes)
                    {
                        CheckCashClientName = 1;
                        ExportMessage exportmessage = new ExportMessage();
                        exportmessage.Text = GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name");
                        exportmessage.Tag = "Cash Client Name";
                        exportmessage.ExportMessagePannel.SendToBack();
                        exportmessage.lblMessage.Visible = false;
                        exportmessage.rbnActualCost.Visible = false;
                        exportmessage.rbnSamePrice.Visible = false;
                        exportmessage.ShowDialog();
                        if (GeneralFunction.CashClientName == string.Empty)
                        { GeneralFunction.Information("CashClientNameisRequired", "CashClientName"); return; }
                    }
                }
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NotesText = txtNote.Text;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ChkNoteChecked = chkNote.Checked;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.HideLogChecked = chkHideLogo.Checked;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.HideDebtChecked = chkHideDebt.Checked;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked = chkIncludeTax.Checked;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PrintPreviewChecked = chkPrintPreview.Checked;

                //*******************Added on 15-July-2014 by Seenivasan**************
                if (objSaleInvoiceHelper.CheckBalanceForSaleInvoice())
                {
                    GeneralFunction.IsPaidStamp = false;
                }
                else
                {
                    GeneralFunction.IsPaidStamp = true;
                }
                //*******************Added on 15-July-2014 by Seenivasan**************

                objSaleInvoiceHelper.CheckPrint(dgrSaleInvoice);
                GeneralFunction.CashClientName = string.Empty;
                CheckCashClientName = 0;
                chkHideLogo.Checked = chkPrintPreview.Checked = false;//Added on 24-June-2014 
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "SaleInvoice" + " " + txtNewInvoiceNo.Text, "Sales", "Print sale invoice details", Convert.ToInt32(InvoiceAction.Yes));//Added on 24-June-2014 
                GeneralFunction.IsPaidStamp = false; // Added on 15-July-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "btnPrint_Click");
            }
        }
        #endregion


        #endregion

        #region KeyUp Events

        #region txtQuantity_KeyUp
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {


                if ((cmbItem.SelectedIndex > -1) && ((ScanValue.Length < 2 & DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds > 51)))
                {
                    StockAdjustOnKeyUp();
                }

                Oldfocus = "Qty";


            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "txtQuantity_KeyUp");
            }
        }
        #endregion

        #region txtPrice_KeyUp
        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyValue == 13)
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);

                }
                if (e.KeyCode == Keys.Tab)
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "price_keyup");
            }
        }
        #endregion

        #endregion

        #region KeyDown Events

        #region cmbSerialNo_KeyDown
        private void cmbSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((int)e.KeyValue == 13))
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbSerialNo_KeyDown");
            }

        }
        #endregion

        #region txtPrice_KeyDown
        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyValue == 13)
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);

                }
                if (e.KeyCode == Keys.Tab)
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "txtPrice_KeyDown");
            }
        }

        #endregion

        #region txtQuantity_KeyDown
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((int)e.KeyValue == 13))
                {
                    if (cmbItem.SelectedIndex > -1)
                    {
                        if (cmbClient.Text == "")
                        {
                            RealPrice = txtPrice.Text;
                            RealPackage = cmbPackageQty.Text;
                            RealExpireDate = dtpExpiry.Text;
                        }
                        else
                        {
                            RealPrice = "";
                            RealPackage = "";
                            RealExpireDate = "";
                        }
                        InsertItemttoGrid();
                        RealPrice = "";
                        RealPackage = "";
                        RealExpireDate = "";
                    }
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "quantity_keydown");
            }
        }
        #endregion

        #region client_keydown
        private void client_keydown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyValue == 13)
                {
                    cmbClientNo.Focus();
                }
                //else //Added on 23-June-2014 for Avoiding Performance issue
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}//this Condition Modified on 14Aug2014 By Meena.R to change the Dropdown as Suggest Append
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "client_keydown");
            }
        }
        #endregion

        #region cmbItem_KeyDown

        //bool isFirst, isSuggFirst = false;
        //string appval = "";
        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    //if (((int)e.KeyValue == 13) || (e.KeyCode == Keys.Tab))
            //    if (e.KeyValue == 13)
            //    {
            //        //if (cmbItem.SelectedIndex > -1)
            //        //{
            //        if (((ComboBox)sender).Name == "cmbItem")
            //            cmbItem.AutoCompleteMode = AutoCompleteMode.None;
            //        txtQuantity.Focus();
            //        txtQuantity.Select(0, txtQuantity.Text.Length);
            //        if (isSuggFirst)
            //        {
            //            cmbItem_SelectedIndexChanged(null, null);
            //            isSuggFirst = false;
            //        }
            //        //if (cmbItem.SelectedIndex > -1)
            //        //{
            //        //    txtQuantity.Focus();
            //        //    txtQuantity.Select(0, txtQuantity.Text.Length);
            //        //}

            //        // }

            //    }
            //    else //Added on 23-June-2014 for Avoiding Performance issue  //Changed Condition By Meena.R on 13Aug2014 to Change the DropDown Suggested Append
            //    {
            //        //if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode!=Keys.Shift)&&(e.KeyCode!=Keys.ShiftKey))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
            //        //{
            //        if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //   (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //   && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //   && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //   && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin))
            //        {
            //            if (((ComboBox)sender).DroppedDown == true)
            //                ((ComboBox)sender).DroppedDown = false;
            //            if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            //            {
            //                cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //                cmbItem.SelectedText = ((char)e.KeyValue).ToString();
            //                //cmbItemName.SelectedIndex=
            //                cmbItem.DroppedDown = true;
            //                //cmbItemName.SelectionStart = 1;
            //                isFirst = true;
            //                appval = ((char)e.KeyValue).ToString();
            //                isSuggFirst = true;
            //            }
            //            else
            //            {
            //                cmbItem.DroppedDown = false;
            //                if (isFirst)
            //                {
            //                    cmbItem.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
            //                    isFirst = false;
            //                }
            //                isSuggFirst = false;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbItem_KeyDown");
            //}

            if (e.KeyCode == Keys.F4)
                e.Handled = true;
            //To hide the two drop down in same time done by Praba on 28-Oct
            //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }

            //}

            // else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin))
            // {
            //     if (((ComboBox)sender).DroppedDown == true)
            //         //((ComboBox)sender).DroppedDown = false;
            //     if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            //     {

            //         //cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //         //cmbItem.SelectedText = ((char)e.KeyValue).ToString();
            //         //cmbItem.DroppedDown = true;
            //         //isFirst = true;
            //         //appval = ((char)e.KeyValue).ToString();
            //         //cmbItemName.SelectionStart = 1;
            //         //isSuggFirst = true;
            //     }
            //     else
            //     {
            //         //cmbItem.DroppedDown = false;
            //         //if (isFirst)
            //         //{
            //         //    cmbItem.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
            //         //    isFirst = false;
            //         //}
            //         //isSuggFirst = false;
            //    }
            //}
        }
        #endregion

        #region cmbClientNo_KeyDown
        private void cmbClientNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyValue == 13)
                {
                    cmbItem.Focus();
                }
                else //Added on 23-June-2014 for Avoiding Performance issue
                {
                    if (((ComboBox)sender).DroppedDown == true)
                        ((ComboBox)sender).DroppedDown = false;
                }//this Condition Modified on 14Aug2014 By Meena.R to change the Dropdown as Suggest Append

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbClientNo_KeyDown");
            }
        }
        #endregion

        #region dtpExpiry_KeyDown
        private void dtpExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyValue == 13)
                {
                    if (cmbClient.Text == "")
                    {
                        RealPrice = txtPrice.Text;
                        RealPackage = cmbPackageQty.Text;
                        RealExpireDate = dtpExpiry.Text;
                    }
                    else
                    {
                        RealPrice = "";
                        RealPackage = "";
                        RealExpireDate = "";
                    }
                    InsertItemttoGrid();
                    RealPrice = "";
                    RealPackage = "";
                    RealExpireDate = "";

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "dtpExpiry_KeyDown");
            }
        }

        #endregion

        #region Sales_Invoice_KeyDown
        private void Sales_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Alt && e.KeyCode == Keys.F3)
                {
                    if(UserScreenLimidations.SaleReturnInvoice)
                    {
                        ReturnOrderPopUp retrunorderpopup = new ReturnOrderPopUp();
                        retrunorderpopup.ShowDialog();
                    }
                }
                else if (e.KeyCode == Keys.F3)
                {
                    //InsertItem();this line to fix the Issue when press F3 Client Details are saved
                    InvokeOnClick(btnInsertItem, EventArgs.Empty);//this line added on 04Aug2014 By Meena.R
                }
                else if (e.KeyCode == Keys.F11 && btnItemInfo.Enabled == true)
                {
                    ItemInfo();
                }
                else if (e.KeyCode == Keys.F2 && btnDeleteItem.Enabled == true)
                {
                    btnDeleteItem_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F10)
                {
                    ResetFunc();
                }
                else if (e.KeyCode == Keys.F4 && (!e.Alt))
                {
                    btnNewInvoice_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F8) & (btnReceiveReceipt.Enabled == true))
                {
                    btnReceiveReceipt_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnCloseInvoice_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    if (UserScreenLimidations.Print)
                        btnPrint_Click(sender, e);
                    else
                        return;
                }
                else if ((e.KeyCode == Keys.F9) & (btnF9.Visible == true))
                {
                    BoxFunction();
                }
                else if ((e.KeyCode == Keys.F7) & (btnPriceChangeF7.Enabled == true))
                {
                    btnPriceChangeF7_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "Sales_Invoice_KeyDown");
            }
        }
        #endregion



        #endregion

        #region KeyPress Events

        #region txtPrice_KeyPress
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (e.KeyChar != '.') && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                    e.Handled = true;
                }
                if ((e.KeyChar == 46) & (txtPrice.Text.Contains(".") == true))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "txtPrice_KeyPress");
            }
        }
        #endregion

        bool qtyEnter = false;

        #region txtQuantity_KeyPress
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = (txtQuantity.Text.Length < 8) ? false : true;
                if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                    e.Handled = true;
                }
                else if ((txtQuantity.Text == "0") || ((txtQuantity.Text == "1") && (itemkeydown == 0)))
                {
                    txtQuantity.Select(0, txtQuantity.Text.Length);

                    itemkeydown = 1;
                }

                if (e.KeyChar == 13 && cmbItem.SelectedIndex == -1)
                {
                    cmbItem.Focus();
                    qtyEnter = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "txtQuantity_KeyPress");
            }
        }
        #endregion

        #region cmbClientNo_KeyPress
        private void cmbClientNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "cmbClientNo_KeyPress");
            }
        }
        #endregion

        #region txtTotalSaleValue_KeyPress

        private void txtTotalSaleValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false) && (e.KeyChar != '.'))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "txtTotalSaleValue_KeyPress");
            }
        }

        #endregion

        #region txtNewInvoiceNo_KeyPress
        private void txtNewInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtNewInvoiceNo.Text.Length != 0 && UserScreenLimidations.InvoiceNavigation)
                    {
                        GetInvoiceDetails();
                    }
                }
                else if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || (e.KeyChar == (char)Keys.Escape)) != true)
                {
                    e.Handled = true;
                    CommonHelper.GeneralFunction.ErrInfo("OnlyNumbersAllowed", "Sales Invoice");
                    txtNewInvoiceNo.SelectAll();
                    txtNewInvoiceNo.Focus();
                }
                else
                {
                    txtNewInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "txtNewInvoiceNo_KeyPress");
            }

        }
        #endregion

        #endregion

        #region TextChanged Events

        #region txtDiscount_TextChanged
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtDiscount.Text != "" && txtDiscount.Text != "." && (!txtDiscount.Text.Contains("-")))
                {
                    if (radPercentage.Checked == true)
                    {
                        if (Convert.ToDecimal(txtDiscount.Text) > 100)
                            txtDiscount.Text = "100.000";
                    }
                    else
                    {
                        if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount == 0)
                            if (Convert.ToDecimal(txtDiscount.Text) > Convert.ToDecimal(txtTotal.Text))
                                txtDiscount.Text = "0.000";
                    }

                    //txtDiscount.Text = (Math.Truncate(Convert.ToDecimal(txtDiscount.Text) * 1000M) / 1000M).ToString();
                }
                if (!txtDiscount.Text.Contains("-"))
                {
                    if (dgrSaleInvoice.BackgroundColor != Color.Gray)
                        SetObjectFromControl();
                    DiscountAdjustment();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "txtNewInvoiceNo_KeyPress");
            }

        }
        #endregion

        #endregion

        #region CheckedChanged Events

        #region radValue_CheckedChanged
        private void radValue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrSaleInvoice.BackgroundColor != Color.Gray)
                    SetObjectFromControl();
                DiscountAdjustment();
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "radValue_CheckedChanged");
            }
        }
        #endregion

        #region radPercentage_CheckedChanged
        private void radPercentage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgrSaleInvoice.BackgroundColor != Color.Gray)
                    SetObjectFromControl();
                DiscountAdjustment();
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "radPercentage_CheckedChanged");
            }
        }
        #endregion

        #region chkShowHideInvoiceCost_CheckedChanged
        private void chkShowHideInvoiceCost_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalSaleValue.Visible = (chkShowHideInvoiceCost.Checked);
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "chkShowHideInvoiceCost_CheckedChanged");
            }
        }
        #endregion

        #endregion

        #region Leave Events

        #region txtPrice_Leave
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.Text != "")
                {
                    DataTable dt = new DataTable();

                    if ((txtPrice.Text != "") && (txtPrice.Text != "0"))
                    {
                        try
                        {
                            if (cmbItem.SelectedValue != null)
                            {
                                //  dt = obj_saleinvoice_dal.minimumprice();
                                List<SaleObject> lstItemMinPrice = objSaleInvoiceHelper.GetItemMinPriceHelper();
                                if (lstItemMinPrice.Count > 0)
                                {
                                    int PackageQty = Convert.ToInt16(cmbPackageQty.Text != "" && cmbPackageQty.Text != "0" ? cmbPackageQty.Text : "1");
                                    Decimal MinimumPrice = (ispackage == false ? Convert.ToDecimal(lstItemMinPrice[0].ItemMinimumPrice.ToString()) : Convert.ToDecimal(lstItemMinPrice[0].ItemMinimumPrice.ToString()) / PackageQty);
                                    Decimal AverageCost = (ispackage == false ? Convert.ToDecimal(lstItemMinPrice[0].AvgCost.ToString()) * PackageQty : Convert.ToDecimal(lstItemMinPrice[0].AvgCost.ToString()));
                                    //if (dgrSaleInvoice.BackgroundColor == Color.Beige)  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                                    if (dgrSaleInvoice.BackgroundColor == Color.WhiteSmoke)
                                    {
                                        if ((GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") && (GeneralFunction.UserId != Convert.ToInt32(CommonHelper.Admin.ID)) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch")) //This is changed to remove hardcode Admin User Id is 101
                                        {
                                            if (Convert.ToDecimal(txtPrice.Text) < AverageCost)
                                            {
                                                GeneralFunction.Information("LessthanSellingPricethanCost", "Sales Invoice");
                                            }
                                        }


                                        if ((Convert.ToDecimal(txtPrice.Text) < MinimumPrice) && (GeneralFunction.UserId != Convert.ToInt32(CommonHelper.Admin.ID))) // This is changed to remove hardcode Admin User Id is 101
                                        {
                                            GeneralFunction.Information("LessthanSellingPricethanMinimumPrice", "Sales Invoice");
                                            txtPrice.Text = Convert.ToDecimal(lstItemMinPrice[0].ItemMinimumPrice.ToString()).ToString("#####0.000");
                                        }
                                    }
                                }
                            }


                        }


                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        txtPrice.Text = (txtPrice.Text == string.Empty) ? "0.000" : txtPrice.Text;
                    }
                    Oldfocus = "price";
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "txtPrice_Leave");
            }
        }
        #endregion

        #region cmbItem_Leave
        private void cmbItem_Leave(object sender, EventArgs e)
        {
            try
            {
                Oldfocus = "Item";
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sale Invoice", "cmbItem_Leave");
            }
        }
        #endregion

        #region txtDiscount_Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text != string.Empty && (!txtDiscount.Text.Contains("-")))
                {
                    txtDiscount.Text = (Math.Truncate(Convert.ToDecimal(txtDiscount.Text) * 1000M) / 1000M).ToString("####0.000");
                }
                else if (txtDiscount.Text.Contains("-"))
                {
                    txtDiscount.Text = "0.000";
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "txtDiscount_Leave");
            }
        }
        #endregion

        #endregion

        #region MouseHover Events

        #region txtPrice_MouseHover
        private void txtPrice_MouseHover(object sender, EventArgs e)
        {

        }
        #endregion

        #region cmbItem_MouseHover
        private void cmbItem_MouseHover(object sender, EventArgs e)
        {
            try
            {
                PriceTooltip.RemoveAll();
                if (objSaleInvoiceHelper.ItemHoverCost != "" && cmbItem.SelectedIndex != -1 && (GeneralFunction.UserGroupID == Convert.ToInt16(DefaultUserGroup.Administrator) || GeneralFunction.UserGroupID == Convert.ToInt16(DefaultUserGroup.Admin) || UserScreenLimidations.ItemCost == true))
                {
                    if (GeneralOptionSetting.FlagHideItemCostInSales == "N")//this Condition Added By Meena.R on 11-Sept-2014 based on the QA issue(BBM-995)
                        PriceTooltip.SetToolTip(this.cmbItem, objSaleInvoiceHelper.ItemHoverCost);//Showing Cost Price on Mouse Hover

                }
                else
                {
                    PriceTooltip.RemoveAll();

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "cmbItem_MouseHover");
            }
        }
        #endregion

        #endregion

        #region rtxtNotesAndAlerts_MouseDoubleClick
        private void rtxtNotesAndAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string str = rtxtNotesAndAlerts.SelectedText.Trim();
                if (str == null || str == string.Empty)
                {
                    if (cmbClient.SelectedIndex > -1)
                        str = cmbClient.Text;
                }
                Purchase_Invoice.ReorderandBalance(str);
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Sales Invoice", "rtxtNotesAndAlerts_MouseDoubleClick");
            }
        }
        #endregion

        #region DropDownClosed Events
        private void cmbClient_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                switch (((ComboBox)sender).Name)
                {
                    case "cmbClient":
                        cmbClient_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbCategory":
                        Cmb_Category_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbCompany":
                        Cmb_Company_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbClientNo":
                        cmbClientNo_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbItem":
                        cmbItem_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbItemNo":
                        cmbItemNo_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                    case "cmbSerialNo":
                        cmbSerialNo_SelectedIndexChanged(sender, EventArgs.Empty);
                        break;
                }

            }
            catch (Exception ex)
            {


                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_All_DropDown");
            }
        }

        private void cmbClient_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
                {
                    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_All_DropDownClosed");
            }
        }

        #endregion

        #region FormClosing
        private void Sales_Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = 0;
                objSaleInvoiceHelper.UpdateActiveUserHelper();
                CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.custom);

            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Sales_Invoice_FormClosing");
            }
        }

        #endregion

        #region GridDoubleClick
        private void dgrSaleInvoice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgrSaleInvoice.Rows.Count > 0)
                {
                    if (dgrSaleInvoice.BackgroundColor != Color.Gray && dgrSaleInvoice.SelectedRows.Count > 0)
                    {

                        //*******************Assigning Grid Value to Objects***************************************************************
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription = dgrSaleInvoice.SelectedRows[0].Cells["ItemDesc"].Value.ToString();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["ItemNo"].Value);
                        objSaleInvoiceHelper.XExpiryDate = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemExpiryDate = (dgrSaleInvoice.SelectedRows[0].Cells["StrExpiryDate"].Value.ToString() != "-" ? Convert.ToDateTime(dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value) : Convert.ToDateTime("1/1/1900"));
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemPackage = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["Package"].Value);
                        objSaleInvoiceHelper.XStockInHand = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value);
                        objSaleInvoiceHelper.XBox = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Box = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["BoxQty"].Value);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalPrice = Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["totalpric"].Value);
                        objSaleInvoiceHelper.XPrice = Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["ActualPrices"].Value);
                        objSaleInvoiceHelper.XSerialNo = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = dgrSaleInvoice.SelectedRows[0].Cells["serialnumber"].Value.ToString();
                        objSaleInvoiceHelper.XBarcodeID = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["BarcodeNumber"].Value);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = Convert.ToInt64(dgrSaleInvoice.SelectedRows[0].Cells["saledetailid"].Value);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = Convert.ToInt64(dgrSaleInvoice.SelectedRows[0].Cells["salesid"].Value);
                        objSaleInvoiceHelper.XUnitPrice = Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["Unitprices"].Value);
                        objSaleInvoiceHelper.XF10Total = Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["totalpric"].Value);
                        //*******************Assigning Grid Value to Objects***************************************************************

                        //List<SaleObject> oLstSaleObject = new List<SaleObject>();
                        //SaleObject oSaleObject = new SaleObject();
                        //oSaleObject = olstItemDetails.Where(a => a.ItemName == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription).FirstOrDefault();

                        //objSaleInvoiceHelper.Load();
                        //if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                        //{
                        //    oLstSaleObject = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(a => a.stock > 0).OrderBy(n => n.ItemName).ToList();//Added on 27-June-2014 by Seenivasan For Sorting the list Ascending
                        //}
                        //else
                        //{
                        //    oLstSaleObject = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();//Added on 27-June-2014 by Seenivasan For Sorting the list Ascending

                        //}
                        DataRow[] rowcount = CommondtItem.Select("ItemName='" + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription + "'");
                        //if (oLstSaleObject.Where(a => a.ItemName == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription).ToList().Count == 0)
                        //{
                        if (rowcount.Length == 0)
                        {
                            DataRow[] Filterrow = objSaleInvoiceHelper.dtAllItems.Select("ItemName='" + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription + "'");
                            //oSaleObject = olstItemDetails.Where(a => a.ItemName == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription).FirstOrDefault();
                            if (Filterrow != null && Filterrow.Length != 0)
                            {
                                DataRow dr = CommondtItem.NewRow();
                                dr["ItemsId"] = Convert.ToInt32(Filterrow[0].ItemArray[0]);
                                dr["ItemName"] = Filterrow[0].ItemArray[1].ToString();
                                dr["ItemNumber"] = Filterrow[0].ItemArray[2].ToString();
                                dr["stock"] = Convert.ToDouble(Filterrow[0].ItemArray[3]);
                                CommondtItem.Rows.Add(dr);
                                // oLstSaleObject.Add(oSaleObject);Commended on 08Jan2015
                            }

                            //cmbItem.DataSource = oLstSaleObject.OrderBy(a => a.ItemName).ToList();//Added on 27-June-2014 by Seenivasan For Sorting the list Ascending
                            cmbItem.DataSource = CommondtItem;
                            DataView dv = new DataView(CommondtItem);
                            dv.RowFilter = "ItemNumber<>''";
                            cmbItemNo.DataSource = dv.ToTable();
                            //cmbItemNo.DataSource = oLstSaleObject.Where(i => i.ItemNumber != string.Empty).ToList();
                        }

                        //int i = -1;
                        //foreach (SaleObject obSaleObject in oLstSaleObject)
                        //{
                        //    i = i + 1;
                        //    if (obSaleObject.ItemName == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription)
                        //    {
                        //        cmbItem.SelectedIndex = i;
                        //    }

                        //}


                        //lstStockBasedSerialNo[0].ItemTotalStock = lstStockBasedSerialNo[0].ItemTotalStock +  Convert.ToInt32(oSaleObject.stock);



                        cmbItem.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemDescription;
                        cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
                        dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
                        cmbSerialNo.SelectedIndexChanged -= new EventHandler(cmbSerialNo_SelectedIndexChanged);
                        if (cmbPackageQty.DataSource == null)
                        {
                            cmbItem_SelectedIndexChanged(null, null);
                        }
                        cmbPackageQty.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemPackage != 0 ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemPackage.ToString() : "1");
                        if (dtpExpiry.Visible == true && dgrSaleInvoice.SelectedRows[0].Cells["StrExpiryDate"].Value.ToString() != "-")
                        {
                            // dtpExpiry.SelectedText = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemExpiryDate.ToString();
                            dtpExpiry.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemExpiryDate.ToShortDateString().ToString();
                        }
                        else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                        {
                            cmbSerialNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno;
                        }

                        if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Box != 0)
                        {
                            btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                            txtQuantity.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Box.ToString();
                            txtPrice.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalPrice / objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Box).ToString();
                            ispackage = false;
                        }
                        else
                        {
                            btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                            txtQuantity.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity.ToString();
                            txtPrice.Text = (Math.Truncate((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalPrice / objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity) * 1000m) / 1000m).ToString();
                            ispackage = true;
                        }
                        objSaleInvoiceHelper.IsFromGridUpdate = true;
                        if (rowcount.Length == 0)
                            CheckForMoreExpiry();
                        cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
                        dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);
                        cmbSerialNo.SelectedIndexChanged += new EventHandler(cmbSerialNo_SelectedIndexChanged);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "dgrSaleInvoice_DoubleClick");
            }
        }
        #endregion

        #endregion

        #region Methods
        #region LoadItems
        void LoadItems()
        {
            cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);//added on 11/12/2014
            cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            //if (GeneralOptionSetting.FlagShowNonStockItem != "Y") commented on 08jan2015
            //{
            //    //cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(a => a.stock > 0).OrderBy(n => n.ItemName).ToList();
            //    //cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty && i.stock > 0).ToList();
            //}
            //else
            //{
            //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();
            //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty).ToList();
            //}
            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemsId";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemsId";
            cmbItem.DataSource = CommondtItem;
            DataView dvi = new DataView(CommondtItem);
            dvi.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dvi.ToTable();
            this.Invoke(new MethodInvoker(delegate
            {
                cmbItem.SelectedIndex = -1;
                cmbItemNo.SelectedIndex = -1;
            }));

            cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
            cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);


            //GC.Collect();
        }



        #endregion
        #region AssignControls
        public void AssignControls()
        {
            dgrSaleInvoice.DataSource = objSaleInvoiceHelper.lstSaleTable;
        }
        #endregion

        #region AssignToComboBox
        private void AssignToComboBox()
        {
            CommondtItem = objSaleInvoiceHelper.GetSalesItemDetails();
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "AgentId";
            cmbClient.DataSource = objSaleInvoiceHelper.ClientDetails; //objSaleInvoiceHelper.lstClientList;

            cmbClient.SelectedIndex = -1;
            cmbClientNo.DisplayMember = "AgentId";
            cmbClientNo.ValueMember = "Name";
            objSaleInvoiceHelper.ClientDetails.DefaultView.Sort = "AgentId" + " " + "ASC";// objSaleInvoiceHelper.lstClientList.OrderBy(a => a.AgentId).ToList();
            cmbClientNo.DataSource = objSaleInvoiceHelper.ClientDetails.DefaultView.ToTable();
            cmbClientNo.SelectedIndex = -1;
            cmbCategory.SelectedIndexChanged -= new System.EventHandler(Cmb_Category_SelectedIndexChanged);

            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = GeneralObjectClass.CategoryList;

            // cmbCategory.SelectedIndex = -1;Commended By Meena.R on  26/12/2014 to select defaut as ALL
            cmbCategory.SelectedIndexChanged += new System.EventHandler(Cmb_Category_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged -= new System.EventHandler(this.Cmb_Company_SelectedIndexChanged);

            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = GeneralObjectClass.CompanyList;

            //cmbCompany.SelectedIndex = -1;//Commended By Meena.R on  26/12/2014 to select defaut as ALL
            cmbCompany.SelectedIndexChanged += new System.EventHandler(this.Cmb_Company_SelectedIndexChanged);

            cmbItem.SelectedIndexChanged -= new System.EventHandler(this.cmbItem_SelectedIndexChanged);

            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemsId";
            //cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"];//Commented on 27-June-2014 by Seenivasan For Sorting the list Ascending
            //cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();//Added on 27-June-2014 by Seenivasan For Sorting the list Ascending
            cmbItem.DataSource = CommondtItem;
            cmbItem.SelectedIndex = -1;
            cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);

            cmbItemNo.SelectedIndexChanged -= new EventHandler(cmbItemNo_SelectedIndexChanged);//Added on 23-June-2014 for Avoiding Performance issue
            cmbItemNo.DisplayMember = "ItemNumber"; //Changed On 17-Apr-14 for Displaying AlphaNumeric ItemNo
            cmbItemNo.ValueMember = "ItemsId";
            //cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty).ToList();
            DataView itemdv = new DataView(CommondtItem);
            itemdv.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = itemdv.ToTable();
            cmbItemNo.SelectedIndex = -1;
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);//Added on 23-June-2014 for Avoiding Performance issue

            if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
            {
              //  lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
                //lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }


        }

        #endregion

        #region SetItemsAndNo
        private void SetItemsAndNo()
        {

            if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                objSaleInvoiceHelper.Get_ItemWithStockHelper(out Item);
            else
                objSaleInvoiceHelper.Get_ItemWithNonStockHelper(out Item);
            if (Item.Count > 0)
            {
                cmbItem.SelectedIndexChanged -= new System.EventHandler(cmbItem_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged -= new System.EventHandler(cmbItemNo_SelectedIndexChanged);
                //cmbItem.DataSource = Item;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemNAme ascending

                cmbItem.DisplayMember = "ItemName";
                cmbItem.ValueMember = "ItemsId";
                cmbItem.DataSource = Item.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemNAme ascending


                //cmbItemNo.DisplayMember = "ItemsId";
                //cmbItemNo.ValueMember = "ItemName";
                //cmbItemNo.SelectedIndex = -1;
                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemsId";
                cmbItemNo.DataSource = Item.Where(a => a.ItemNumber != string.Empty).ToList();
                cmbItemNo.SelectedIndex = -1;
                cmbItem.SelectedIndex = -1;
                cmbItem.SelectedIndexChanged += new System.EventHandler(cmbItem_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged += new System.EventHandler(cmbItemNo_SelectedIndexChanged);
            }
            else
            {
                cmbItem.DataSource = null;
                cmbItemNo.DataSource = null;
            }
        }
        #endregion

        #region SetLanguage
        public void SetLanguage()
        {
            lblPaymentCharges.Text = Additional_Barcode.GetValueByResourceKey("PaymentCharges");
            chkPaymentsTypes.Text = Additional_Barcode.GetValueByResourceKey("PaymentType");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Cat");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblClientNo.Text = Additional_Barcode.GetValueByResourceKey("CNo");
            lblClient.Text = Additional_Barcode.GetValueByResourceKey("CName");
            lblNet.Text = Additional_Barcode.GetValueByResourceKey("Net");
            lblRemaining.Text = Additional_Barcode.GetValueByResourceKey("Remaining");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            btnReset.Text = Additional_Barcode.GetValueByResourceKey("ResetF10");
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey("Expiry");
            lblTotalStock.Text = Additional_Barcode.GetValueByResourceKey("TotalStock");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintF6");
            this.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("INo");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            chkHideLogo.Text = Additional_Barcode.GetValueByResourceKey("HidenLogo");
            chkIncludeTax.Text = Additional_Barcode.GetValueByResourceKey("IncludeTax");
            chkHideDebt.Text = Additional_Barcode.GetValueByResourceKey("HideDebt");
            chkShowHideInvoiceCost.Text = Additional_Barcode.GetValueByResourceKey("ShowHideInvCost");
            chkNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");
            grbNoteAndAlert.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInvoice");
            btnFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice");
            btnItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11");
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice");
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInvoice");
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem");
            btnReturnIQuicktem.Text = Additional_Barcode.GetValueByResourceKey("ReturnQuickItem");
            lblPackage.Text = Additional_Barcode.GetValueByResourceKey("Package");
            btnF9.Text = Additional_Barcode.GetValueByResourceKey("BoxF9");
            btnPriceChangeF7.Text = Additional_Barcode.GetValueByResourceKey("BoxF7");
            btnReceiveReceipt.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceiptF8");
            btnExportInvoice.Text = Additional_Barcode.GetValueByResourceKey("ExportInv");
            btnDeleteItem.Text = Additional_Barcode.GetValueByResourceKey("DeleteF2");
            btnInsertItem.Text = Additional_Barcode.GetValueByResourceKey("InsertItemF3");
            lblItemName1.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            radPercentage.Text = Additional_Barcode.GetValueByResourceKey("Persentage");
            radValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblSerialNo.Text = Additional_Barcode.GetValueByResourceKey("SerialNo");
            //Grid Columns Language Setting

            dgrSaleInvoice.Columns["StrItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgrSaleInvoice.Columns["ItemDesc"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgrSaleInvoice.Columns["StrExpiryDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgrSaleInvoice.Columns["Package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgrSaleInvoice.Columns["Qty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Qty");
            dgrSaleInvoice.Columns["Unitprices"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgrSaleInvoice.Columns["totalpric"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgrSaleInvoice.Columns["DateModified"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgrSaleInvoice.Columns["Users"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgrSaleInvoice.Columns["ReturnQuantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Returned");
            dgrSaleInvoice.Columns["ClientsID"].HeaderText = Additional_Barcode.GetValueByResourceKey("Agent");
            dgrSaleInvoice.Columns["itemdisc"].HeaderText = Additional_Barcode.GetValueByResourceKey("Discount");
            dgrSaleInvoice.Columns["serialnumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
            dgrSaleInvoice.Columns["BoxQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            Chk_PrintCashClientName.Text = Additional_Barcode.GetValueByResourceKey(Chk_PrintCashClientName.Tag.ToString());
            //Grid Columns Language Setting

        }
        #endregion

        #region SetFont
        public void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();

                foreach (Control cti in panel1.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control cti in panel2.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control cti in panel3.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control cti in panel4.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control cti in panel6.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                dgrSaleInvoice.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }
        #endregion

        #region DiscountCalculation
        public void DiscountCalculation(string Price)
        {
            try
            {
                float isDiscountOrIncreaes = 0.0f;
                float inscreasedprice = 0.0f;
                float fltdiscount = 0.0f;
                float fltacturalprice = 0.0f;
                float fltdiscountedprice = float.Parse(Price);
                if (Price != "")
                    fltacturalprice = float.Parse(Price);
                if (cmbClientNo.Text != "")
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt32(cmbClientNo.Text);
                    fltdiscount = objSaleInvoiceHelper.GetDiscountForAgentHelper();
                    isDiscountOrIncreaes = objSaleInvoiceHelper.GetIsDiscountOrIncreaseForAgentHelper();
                    if (fltdiscount != 0.0 && fltdiscount != 0)
                    {
                        fltdiscountedprice = fltacturalprice - ((fltacturalprice * fltdiscount) / 100);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.agentdiscount = "Yes";
                    }
                    // if is not discount
                    if (isDiscountOrIncreaes == 1)
                    {
                        if (fltdiscount != 0.0 && fltdiscount != 0)
                        {
                            inscreasedprice = fltacturalprice - fltdiscountedprice;
                            fltdiscountedprice = fltacturalprice + inscreasedprice;
                        }
                    }

                    txtPrice.Text = fltdiscountedprice.ToString("#####0.000");
                }
                else
                    txtPrice.Text = float.Parse(Price).ToString("#####0.000");

                //*****Discount Calculation applied in Discoutn form on 13-May-14*******

                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType != Convert.ToInt16(ItemType.Labour))
                {
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType == Convert.ToInt16(ItemType.Goods))
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType = Convert.ToInt16(DiscountType.Goods);
                    }
                    else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType == Convert.ToInt16(ItemType.SecondHand))
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType = Convert.ToInt16(DiscountType.SecondHand);
                    }
                    else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType == Convert.ToInt16(ItemType.Meals))
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemType = Convert.ToInt16(DiscountType.Meals);
                    }

                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : 101); //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : 101);  //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    List<SaleObject> lstCatComIDForItem = new List<SaleObject>();
                    lstCatComIDForItem = objSaleInvoiceHelper.GetCateComIDForItemBalHelper();

                    //Commented following code on 26-Nov-2014 by Seenivasan for Getting the Item Category and Company ID
                    // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : Convert.ToInt16(CommonHelper.CategoryId.Value));  //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : Convert.ToInt16(CommonHelper.CompanyId.Value));      //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    //***************************************************************************************************

                    //Added following code on 26-Nov-2014 by Seenivasan for Getting the Item Category and Company ID
                    if (lstCatComIDForItem.Count > 0)
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = lstCatComIDForItem[0].CategoryID;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = lstCatComIDForItem[0].CompanyID;
                    }
                    else
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : Convert.ToInt16(CommonHelper.CategoryId.Value));  //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : Convert.ToInt16(CommonHelper.CompanyId.Value));      //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    }
                    //***************************************************************************************************

                    // Item Discount
                    fltacturalprice = float.Parse(txtPrice.Text);
                    fltdiscount = objSaleInvoiceHelper.GetAppliedDiscountHelper();

                    if (fltdiscount != 0)
                    {
                        fltdiscountedprice = fltacturalprice - ((fltacturalprice * fltdiscount) / 100);
                        txtPrice.Text = fltdiscountedprice.ToString("#####0.000");
                    }
                    else
                    {
                        DataTable dt = objSaleInvoiceHelper.GetAppliedIncreaseHelper();
                        if (dt.Rows.Count > 0)
                        {
                            bool HasIncrease = Convert.ToBoolean(dt.Rows[0]["HasIncrease"]);
                            int IncreaseType = Convert.ToInt32(dt.Rows[0]["IncreaseType"]);
                            float itemcost = dt.Rows[0]["ItemCost"] == null ? 0 : float.Parse(dt.Rows[0]["ItemCost"].ToString());
                            fltdiscount = float.Parse(dt.Rows[0]["Discount"].ToString());
                            if (HasIncrease)
                            {
                                if (IncreaseType == 2)
                                {
                                    fltdiscountedprice = fltacturalprice + ((fltacturalprice * fltdiscount) / 100);
                                    txtPrice.Text = fltdiscountedprice.ToString("#####0.000");
                                }
                                else if (IncreaseType == 1)
                                {
                                    fltdiscountedprice = fltacturalprice + ((itemcost * fltdiscount) / 100);
                                    txtPrice.Text = fltdiscountedprice.ToString("#####0.000");
                                }
                            }
                        }
                    }
                    //***********************************************************************
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "DiscountCalculation");
            }
        }
        #endregion

        #region StopDebtSelling
        public Boolean StopDebtSelling()
        {
            if (GeneralOptionSetting.FlagStopDeptSellings == "Y")
            {
                if (cmbClientNo.SelectedIndex > -1)
                {
                    if (cmbClientNo.Text != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())

                        return false;

                    else
                        return true;
                }
                else
                    return true;
            }
            return true;

        }
        #endregion

        #region NotesArea
        public void NotesArea()
        {
            try
            {
                rtxtNotesAndAlerts.Text = "";
                SetNotes();
                if (FormLoad != false)
                    CheckForMoreExpiry();
                //  Obj_Message.Set_NotesAlertDetails(rtxt_notes_and_alerts);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SetNotes
        public void SetNotes()
        {
            try
            {

                rtxtNotesAndAlerts.Text = "";
                if (GeneralOptionSetting.FlagAlertPayDates == "Y")
                {
                    CustomNotesAlerts.SetPaymentDateIn_NoteAlert(rtxtNotesAndAlerts); //Added on 23-June-2014 for calling common function for Getting Payment dates
                    //*********************************Start Commented on 23-June-2014 for calling common function for Getting Payment dates******************************************//
                    //string str;
                    //DataSet dt = new DataSet();
                    //Dictionary<string, List<SaleObject>> dicPaymentDates = objSaleInvoiceHelper.GetPaymentDateHelper();
                    //int paybefor = Convert.ToInt32(GeneralOptionSetting.FlagAlertPayDatesBefore);
                    //if (paybefor > 0)
                    //{

                    //    if (dicPaymentDates["PaymentDates"].Count > 0)
                    //    {
                    //        rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\n";
                    //        rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "Payment Dates :";
                    //        for (int i = 0; i < dicPaymentDates["PaymentDates"].Count; i++)
                    //        {
                    //            TimeSpan tp = dicPaymentDates["PaymentDates"][i].PaymentDate.Subtract(Convert.ToDateTime(DateTime.Now));
                    //            if ((tp.Days <= paybefor) & (tp.Days >= 0))
                    //            {
                    //                string[] paymentday = dicPaymentDates["PaymentDates"][i].PaymentDate.ToString().Split(' ');
                    //                str = dicPaymentDates["PaymentDates"][i].AgentName.ToString() + "---" + Convert.ToDateTime(paymentday[0]).ToShortDateString();
                    //                rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + '\n' + str;
                    //            }
                    //        }

                    //    }
                    //}
                    //else
                    //    if (dicPaymentDates["AgentNames"].Count > 0)
                    //    {
                    //        rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\n";
                    //        rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "Payment Dates :";
                    //        for (int i = 0; i < dicPaymentDates["AgentNames"].Count; i++)
                    //        {
                    //            str = dicPaymentDates["AgentNames"][i].AgentName.ToString();
                    //            rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + '\n' + str;
                    //        }
                    //    }
                    //*********************************End Commented on 23-June-2014 for calling common function for Getting Payment dates******************************************//

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region SerialNoLoad
        public void SerialNoLoad()
        {
            List<SaleObject> lstSerialNo = objSaleInvoiceHelper.GetSerialNoHelper();
            if (lstSerialNo.Count > 0)
            {
                //  cmbSerialNo_SelectedIndexChanged
                cmbSerialNo.SelectedIndexChanged -= new EventHandler(cmbSerialNo_SelectedIndexChanged);
                cmbSerialNo.DataSource = lstSerialNo;
                cmbSerialNo.DisplayMember = "SerialNo";
                // cmbSerialNo.ValueMember = "SerialNo";//Commented on 20-May-2014
                cmbSerialNo.ValueMember = "StockID";//Commented on 20-May-2014
                txtTotalStock.Text = lstSerialNo[0].ItemTotalStock.ToString();
                txtPrice.Text = lstSerialNo[0].ItemPrice.ToString();
                cmbSerialNo.SelectedIndexChanged += new EventHandler(cmbSerialNo_SelectedIndexChanged);
            }
            else
            {
                cmbSerialNo.DataSource = null;
                txtTotalStock.Text = "0";
            }

        }
        #endregion

        #region BoxPrice
        public void BoxPrice()
        {
            try
            {

                DataTable dt = new DataTable();
                if (cmbItem.Text != "")
                {
                    if (cmbItem.SelectedValue != null)
                    {

                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);

                        List<SaleObject> lstMinPrice = objSaleInvoiceHelper.GetItemMinPriceHelper();

                        // dt = obj_saleinvoice_dal.minimumprice();
                        if (lstMinPrice.Count > 0)
                        {
                            float firstprice = 0.0f;
                            if (txtPrice.Text != "")
                                firstprice = float.Parse(txtPrice.Text);
                            int pieces = 0;
                            int quantity = 0;
                            // quantity = lstMinPrice[0].ItemPackage = (lstMinPrice[0].ItemPackage.ToString() != "" && lstMinPrice[0].ItemPackage.ToString() != "0") ? lstMinPrice[0].ItemPackage : 1; // Commented on 18-Apr-2014
                            quantity = (cmbPackageQty.Text != "" && cmbPackageQty.Text != "0") ? Convert.ToInt16(cmbPackageQty.Text) : 1;
                            DataTable dt1 = new DataTable();
                            if (dtpExpiry.Visible == true)
                            {
                                if (dtpExpiry.SelectedIndex > -1)
                                {
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dtpExpiry.Text);
                                    //  dt1 = obj_saleinvoice_dal.get_stock_basedexpiry();
                                    List<SaleObject> lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedExpiryHelper();
                                    if (lstStockBasedexpiry.Count > 0)
                                    {
                                        if (lstStockBasedexpiry[0].ItemTotalStock.ToString() != "")
                                            pieces = lstStockBasedexpiry[0].ItemTotalStock;
                                    }
                                }
                            }
                            else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                            {
                                if ((cmbSerialNo.SelectedIndex > -1) && (cmbSerialNo.Items.Count > 0))
                                {//*A
                                    cmbSerialNo.SelectedIndex = 0;
                                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt64(cmbSerialNo.Text);
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = cmbSerialNo.Text;
                                    //  dt1 = obj_saleinvoice_dal.stockbasedserialno();
                                    List<SaleObject> lstStockBasedSerialNo = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();
                                    if (lstStockBasedSerialNo.Count > 0)
                                    {
                                        if (lstStockBasedSerialNo[0].ItemTotalStock.ToString() != "")
                                            pieces = lstStockBasedSerialNo[0].ItemTotalStock;
                                    }
                                }
                            }
                            else
                                pieces = lstMinPrice[0].ItemTotalStock;
                            int box = 0;
                            if (quantity > 1)
                                box = pieces / quantity;
                            else
                                box = pieces;
                            if (box < 0)
                                box = 0;
                            txtPackage.Text = quantity.ToString();
                            float price = 0.0f;
                            if ((txtPrice.Text != "") && (txtPrice.Text != "0"))
                                price = float.Parse(txtPrice.Text);
                            float newprice = 0.0f;
                            decimal unitprice = Convert.ToDecimal(price / quantity);
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price = unitprice;
                            //if (button_boxF9.Text == "Box F9")
                            if (ispackage == false)
                            {
                                txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                                txtRemaining.Text = ((box) - Convert.ToInt32(txtQuantity.Text)).ToString();
                                txtRemaining.Text = (Convert.ToInt32(txtRemaining.Text) < 0) ? "0" : txtRemaining.Text;
                                int totalstocks = 0;
                                totalstocks = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / quantity);//Commented on 19-Apr-17
                                // totalstocks = (pieces / quantity);
                                txtTotalStock.Text = totalstocks.ToString();

                                newprice = boxprice;
                                //txtPrice.Text = newprice.ToString(); Commented on 14-May-2014 -> Need to clarify to Round the Price on Box
                                txtPrice.Text = RoundPrice(newprice).ToString("#####0.000"); // Added on 14-May-2014 for Round the Discounted Price
                            }
                            else
                            {
                                newprice = boxprice / quantity;
                                if (pieces < 0)
                                    pieces = 0;
                                txtQuantity.Text = ((txtQuantity.Text == "") || (txtQuantity.Text == "0")) ? "1" : txtQuantity.Text;
                                txtRemaining.Text = Convert.ToInt32((pieces - Convert.ToInt32(txtQuantity.Text))).ToString();
                                int totalstocks = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock;//Commented on 19-Apr-17
                                //  int totalstocks = pieces;
                                txtTotalStock.Text = totalstocks.ToString();
                                txtPrice.Text = RoundPrice(newprice).ToString("#####0.000");
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "BoxPrice()");
            }

        }
        #endregion

        #region StockAdjust
        public void StockAdjust()
        {
            try
            {
                if ((txtRemaining.Text != "") && (txtQuantity.Text != ""))
                {

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                    List<SaleObject> lstStock = new List<SaleObject>();
                    if (dtpExpiry.Visible == false)
                    {
                        if (cmbSerialNo.Visible == true)
                        {
                            if (cmbSerialNo.Items.Count > 0)
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "true";
                                // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt32(cmbSerialNo.Text);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = cmbSerialNo.Text;
                                lstStock = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();
                            }
                        }

                    }
                    else
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dtpExpiry.Text);
                        lstStock = objSaleInvoiceHelper.GetStockBasedExpiryHelper();
                    }
                    if (lstStock.Count > 0)
                    {
                        int remainingstock = 0;
                        if (dtpExpiry.Visible == false)
                        {
                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                            {
                                remainingstock = lstStock[0].ItemTotalStock;
                            }

                        }
                        else
                        {
                            if (lstStock[0].ItemTotalStock.ToString() != "")
                                remainingstock = lstStock[0].ItemTotalStock;
                        }
                        if (remainingstock < 0)
                            remainingstock = 0;
                        txtRemaining.Text = remainingstock.ToString();
                        int rem = 0;
                        int stock = 0;
                        if (ispackage == false)
                        {
                            stock = Convert.ToInt32(txtRemaining.Text) / Convert.ToInt32(txtPackage.Text);
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = (float.Parse(remainingstock.ToString()) - (float.Parse(txtQuantity.Text) * float.Parse(txtPackage.Text)));
                            rem = stock - Convert.ToInt32(txtQuantity.Text);
                            if (rem < 0)
                            {
                                rem = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / Convert.ToInt32(txtPackage.Text)) - Convert.ToInt32(txtQuantity.Text);
                                if (rem < 0)
                                {
                                    txtRemaining.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString();
                                    txtQuantity.Text = "0";
                                    btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                                    ispackage = true;
                                    rem = 0;
                                }

                            }

                            txtRemaining.Text = rem.ToString();
                        }
                        else
                        {
                            stock = Convert.ToInt32(txtRemaining.Text);
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = (float.Parse(remainingstock.ToString()) - float.Parse(txtQuantity.Text));
                            if (rem < 0)
                            {
                                rem = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock) - Convert.ToInt32(txtQuantity.Text);
                                if (rem < 0)
                                    txtQuantity.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString();
                                rem = 0;
                            }
                            txtRemaining.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock.ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region ReorderItems
        private void ReorderItems()
        {
            try
            {
                DataTable dt = new DataTable();
                // dt = obj_saleinvoice_dal.get_reorderitems();

                if (dt.Rows.Count > 0)
                {
                    rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\n ";
                    rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\n" + "ReorderItems :";
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region RoundPrice
        public Decimal RoundPrice(float price)
        {
            return CommonRoundPrice(price);
        }

        public static decimal CommonRoundPrice(float price)
        {
            try
            {
                float unitprice1 = price;
                Decimal RoundedPrice = 0;
                if (GeneralOptionSetting.FlagRoundPriceOnDiscount == "Y")
                {
                    string price1 = unitprice1.ToString("#####0.000");

                    price1 = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M).ToString("#####0.000");

                    string[] dr = new string[2];
                    dr = price1.Split('.');
                    if (float.Parse(dr[1].ToString()) > .0)
                    {
                        if (GeneralOptionSetting.FlagRoundPricesOnDiscountValue == "0")
                        {
                            if (((float.Parse(dr[1].ToString()) / 1000) > .0) && (((float.Parse(dr[1].ToString()) / 1000) < .25)))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".25");
                            }
                            else if (((float.Parse(dr[1].ToString()) / 1000) > .25) && ((float.Parse(dr[1].ToString()) / 1000) < .5))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".5");
                            }
                            if (((float.Parse(dr[1].ToString()) / 1000) > .5) && (((float.Parse(dr[1].ToString()) / 1000) < .75)))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".75");
                            }
                            else if (((float.Parse(dr[1].ToString()) / 1000) > .75))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse("1");
                            }
                            RoundedPrice = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M);
                            return RoundedPrice;
                        }
                        else if (GeneralOptionSetting.FlagRoundPricesOnDiscountValue == "1")
                        {
                            if (((float.Parse(dr[1].ToString()) / 1000) > .0) && (((float.Parse(dr[1].ToString()) / 1000) < .25)))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".00");
                            }
                            else if (((float.Parse(dr[1].ToString()) / 1000) > .25) && ((float.Parse(dr[1].ToString()) / 1000) < .5))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".25");
                            }
                            if (((float.Parse(dr[1].ToString()) / 1000) > .5) && (((float.Parse(dr[1].ToString()) / 1000) < .75)))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".5");
                            }
                            else if (((float.Parse(dr[1].ToString()) / 1000) > .75))
                            {
                                unitprice1 = float.Parse(dr[0].ToString()) + float.Parse(".75");
                            }
                            RoundedPrice = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M);
                            return RoundedPrice;
                        }
                        RoundedPrice = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M);
                        return RoundedPrice;
                    }
                    else
                        RoundedPrice = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M);
                    return RoundedPrice;
                }
                else
                    RoundedPrice = (Math.Truncate(Convert.ToDecimal(unitprice1) * 1000M) / 1000M);
                return RoundedPrice;

            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region ItemChanges
        private void ItemChanges()
        {
            // itemkeydown = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "false";
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal = false;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performavalue = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performaserialvalue = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performaexpiryvalue = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = "0";
            lblSerialNo.Visible = false;
            cmbSerialNo.Visible = false;
            dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
            dtpExpiry.DataSource = null;
            dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);
            txtRemaining.Text = "";
            txtQuantity.Text = "";
            btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
            ispackage = false;
            cmbSerialNo.DataSource = null;

        }
        #endregion

        #region StockAdjustOnKeyUp

        public void StockAdjustOnKeyUp()
        {
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = false;
            List<SaleObject> lstStockBasedSerialNo;
            List<SaleObject> lstStock;
            List<SaleObject> lstStockBasedexpiry;
            try
            {
                string strMsg = GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty");
                if (cmbItem.SelectedIndex > -1)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname = cmbItem.Text;

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = "";
                    if ((txtRemaining.Text != "") && (txtQuantity.Text.ToString() != "null"))
                    {
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
                        if (dtpExpiry.Visible == false)
                        {
                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                            {
                                if (cmbSerialNo.Items.Count > 0)
                                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt32(cmbSerialNo.Text);
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = cmbSerialNo.Text;
                                else
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = "0";
                                // dt1 = obj_saleinvoice_dal.stockbasedserialno();
                                lstStockBasedSerialNo = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();
                                if (lstStockBasedSerialNo.Count > 0)
                                {
                                    int stock = 0;
                                    int package = 0;
                                    if ((lstStockBasedSerialNo[0].ItemTotalStock.ToString() != "") && (lstStockBasedSerialNo[0].ItemTotalStock.ToString() != null))
                                    {
                                        stock = lstStockBasedSerialNo[0].ItemTotalStock;
                                        if (objSaleInvoiceHelper.IsFromGridUpdate)
                                            stock = stock + objSaleInvoiceHelper.XStockInHand;
                                    }
                                    //if ((lstStockBasedSerialNo[0].ItemPackage.ToString() != "") && (lstStockBasedSerialNo[0].ItemPackage.ToString() != null))
                                    //    package = lstStockBasedSerialNo[0].ItemPackage;

                                    if ((cmbPackageQty.Text != "") && (cmbPackageQty.Text != null))
                                        package = Convert.ToInt16(cmbPackageQty.Text);//Added on 23-May-14 for Multi Package QTy

                                    if (stock < 1)
                                        stock = 0;
                                    if (package < 1)
                                        package = 1;
                                    if (txtQuantity.Text == "")
                                        txtQuantity.Text = "0";
                                    int totalquantity = stock / package;
                                    int remaining = 0;
                                    //if (button_boxF9.Text == "Box F9")
                                    if (ispackage == false)
                                    {
                                        if (totalquantity < 0)
                                            totalquantity = 0;
                                        if (totalquantity < Convert.ToInt32(txtQuantity.Text))
                                        {
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                            txtRemaining.Text = "0";
                                            if (((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package) < Convert.ToInt32(txtQuantity.Text)) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                                            {

                                                int totalquant = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock);
                                                if (totalquant % package != 0)
                                                {
                                                    //GeneralFunction.Information(strMsg + " " + totalquant.ToString(), "Sales Invoice");//Commented on 23-May-2014
                                                    MessageBox.Show(strMsg + " " + totalquant.ToString(), "Sales Invoice");//Added on 23-May-2014
                                                    btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                                                    ispackage = true;
                                                    txtQuantity.Text = totalquant.ToString();
                                                }
                                                else
                                                {
                                                    //GeneralFunction.Information(strMsg + " " + (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString(), "Sales Invoice");//Commented on 23-May-2014
                                                    MessageBox.Show(strMsg + " " + (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString(), "Sales Invoice");//Added on 23-May-2014
                                                    txtQuantity.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString();
                                                }
                                                if (txtQuantity.Text != "")
                                                    remaining = totalquant - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = totalquant;
                                                // Txt_TotalStock.Text = remaining.ToString();
                                                txtTotalStock.Text = totalquant.ToString();
                                            }
                                            else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                                            {
                                                if (txtQuantity.Text != "")
                                                    remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package) - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package);
                                                txtRemaining.Text = "0";
                                                // Txt_TotalStock.Text = remaining.ToString();
                                                txtTotalStock.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString();
                                            }
                                        }
                                        else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                                        {
                                            remaining = totalquantity - Convert.ToInt32(txtQuantity.Text);
                                            txtRemaining.Text = remaining.ToString();
                                            int packagerem = 1;
                                            if (package.ToString() != "")
                                                packagerem = package;
                                            remaining = remaining * packagerem;
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                            remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package) - Convert.ToInt32(txtQuantity.Text);
                                            //Txt_TotalStock.Text = remaining.ToString();
                                            txtTotalStock.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString();

                                        }
                                    }
                                    else//for pieces
                                    {
                                        if ((txtQuantity.Text != "") && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                                        {
                                            if (stock < Convert.ToInt32(txtQuantity.Text))
                                            {
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = 0;
                                                txtRemaining.Text = "0";
                                                if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock) < Convert.ToInt32(txtQuantity.Text))
                                                {
                                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                    int totalquant = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock);
                                                    //Need to uncomment //GeneralFunction.Information(strMsg + " " + totalquant.ToString(), this.Text);
                                                    MessageBox.Show(strMsg + " " + totalquant.ToString(), "Sales Invoice");
                                                    txtQuantity.Text = totalquant.ToString();
                                                    if (txtQuantity.Text != "")
                                                        remaining = totalquant - Convert.ToInt32(txtQuantity.Text);
                                                    else
                                                        remaining = totalquant;
                                                    //Txt_TotalStock.Text = remaining.ToString();
                                                    txtTotalStock.Text = totalquant.ToString();
                                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                                }
                                                else
                                                {
                                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                    if (txtQuantity.Text != "")
                                                        remaining = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock - Convert.ToInt32(txtQuantity.Text);
                                                    else
                                                        remaining = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock;
                                                    //Txt_TotalStock.Text = remaining.ToString();
                                                    txtTotalStock.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString();

                                                }
                                            }
                                            else
                                            {
                                                if (txtQuantity.Text != "")
                                                    remaining = stock - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = stock;
                                                txtRemaining.Text = remaining.ToString();
                                                remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock - Convert.ToInt32(txtQuantity.Text));
                                                // Txt_TotalStock.Text = remaining.ToString();
                                                txtTotalStock.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString();
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                            //}//Non ExpiryItem
                            else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid;
                                // dt = obj_saleinvoice_dal.getstock();
                                lstStock = objSaleInvoiceHelper.GetStockHelper();
                                if (lstStock.Count > 0)
                                {
                                    int stock = 0;
                                    int package = 0;
                                    if ((lstStock[0].ItemTotalStock.ToString() != "") && (lstStock[0].ItemTotalStock.ToString() != "null"))
                                    {
                                        stock = lstStock[0].ItemTotalStock;
                                        if (objSaleInvoiceHelper.IsFromGridUpdate)
                                            stock = stock + objSaleInvoiceHelper.XStockInHand;
                                    }
                                    txtTotalStock.Text = stock.ToString();
                                    //if ((lstStock[0].ItemPackage.ToString() != "") && (lstStock[0].ItemPackage.ToString() != "null"))
                                    //    package = lstStock[0].ItemPackage;//Commented om 19-Apr-14

                                    if ((cmbPackageQty.Text != "") && (cmbPackageQty.Text != null))
                                        package = Convert.ToInt16(cmbPackageQty.Text);//Added on 19-Apr-14 for Multi Package QTy


                                    if (stock < 1)
                                        stock = 0;
                                    if (package < 1)
                                        package = 1;
                                    int totalquantity = stock / package;
                                    int remaining = 0;
                                    if (txtQuantity.Text == "")
                                        txtQuantity.Text = "0";
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(stock.ToString());
                                    int orginalstock = 0;
                                    //if (float.Parse(stock.ToString()) < Convert.ToInt32(txt_quantity.Text))
                                    orginalstock = (ispackage == true) ? stock : totalquantity;
                                    if (float.Parse(orginalstock.ToString()) < Convert.ToInt32(txtQuantity.Text))
                                    {
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = 0;
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                        //if (button_boxF9.Text == "Box F9")
                                        if (ispackage == false)
                                        {
                                            if (totalquantity < 0)
                                                totalquantity = 0;
                                            if (totalquantity < Convert.ToInt32(txtQuantity.Text))
                                            {
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                //GeneralFunction.Information(strMsg + " " + totalquantity.ToString(), this.Text);
                                                MessageBox.Show(strMsg + " " + totalquantity.ToString(), "Sales Invoice");
                                                txtQuantity.Text = totalquantity.ToString();
                                                if (txtQuantity.Text != "")
                                                    remaining = totalquantity - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = totalquantity;

                                                //}

                                                txtRemaining.Text = remaining.ToString();
                                                txtTotalStock.Text = totalquantity.ToString();
                                            }
                                        } //nonexpiry item piece
                                        else
                                        {
                                            if (stock < Convert.ToInt32(txtQuantity.Text))
                                            {
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                //GeneralFunction.Information(strMsg + " " + stock.ToString(), this.Text);
                                                MessageBox.Show(strMsg + " " + stock.ToString(), "Sales Invoice");
                                                txtQuantity.Text = stock.ToString();
                                                if (txtQuantity.Text != "")
                                                    remaining = stock - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = stock;
                                                txtRemaining.Text = remaining.ToString();
                                                txtTotalStock.Text = stock.ToString();
                                            }
                                        }

                                    }

                                    else//nonexpiry item totalquantity is greater than quantity
                                    {
                                        //if (button_boxF9.Text == "Box F9")
                                        if (ispackage == false)
                                        {
                                            if (txtQuantity.Text != "")
                                                remaining = totalquantity - Convert.ToInt32(txtQuantity.Text);
                                            else
                                                remaining = totalquantity;
                                            txtRemaining.Text = remaining.ToString();
                                            txtTotalStock.Text = totalquantity.ToString();
                                            int packagerem = 1;
                                            //if (txtPackage.Text != "")
                                            //    packagerem = Convert.ToInt32(txtPackage.Text);//Commented on 19-Apr-14

                                            if (package.ToString() != "")
                                                packagerem = package;

                                            int rempiece = remaining * Convert.ToInt32(packagerem);
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(rempiece.ToString());
                                        }
                                        else
                                        {
                                            if (txtQuantity.Text != "")
                                                remaining = stock - Convert.ToInt32(txtQuantity.Text);
                                            else
                                                remaining = stock;
                                            txtRemaining.Text = remaining.ToString();
                                            txtTotalStock.Text = stock.ToString();
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                        }
                                    }
                                }
                            }
                        }//upto here expiry invisible coding
                        else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)//Expiry item coding starts
                        {
                            if (dtpExpiry.Items.Count > 0)
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dtpExpiry.Text);
                            else
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime("1/1/1900");
                            // dt1 = obj_saleinvoice_dal.get_stock_basedexpiry();
                            lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedExpiryHelper();
                            if (lstStockBasedexpiry.Count > 0)
                            {
                                int stock = 0;
                                int package = 0;
                                if ((lstStockBasedexpiry[0].ItemTotalStock.ToString() != "") && (lstStockBasedexpiry[0].ItemTotalStock.ToString() != null))
                                {
                                    stock = lstStockBasedexpiry[0].ItemTotalStock;
                                    if (objSaleInvoiceHelper.IsFromGridUpdate)
                                        stock = stock + objSaleInvoiceHelper.XStockInHand;
                                }
                                //if ((lstStockBasedexpiry[0].ItemPackage.ToString() != "") && (lstStockBasedexpiry[0].ItemPackage.ToString() != null))
                                //    package = lstStockBasedexpiry[0].ItemPackage;//Commented on 18-Apr-14 for Multi Package QTy

                                if ((cmbPackageQty.Text != "") && (cmbPackageQty.Text != null))
                                    package = Convert.ToInt16(cmbPackageQty.Text);//Added on 18-Apr-14 for Multi Package QTy

                                if (stock < 1)
                                    stock = 0;
                                if (package < 1)
                                    package = 1;
                                if (txtQuantity.Text == "")
                                    txtQuantity.Text = "0";

                                int totalquantity = stock / package;
                                int remaining = 0;
                                //if (button_boxF9.Text == "Box F9")
                                if (ispackage == false)
                                {
                                    if (totalquantity < 0)
                                        totalquantity = 0;

                                    if (totalquantity < Convert.ToInt32(txtQuantity.Text))//ExpiryItem totalquantiyty less than required quantity
                                    {
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                        txtRemaining.Text = "0";
                                        bool Flag = false;
                                        if (GeneralOptionSetting.FlagSellExpiryWenNotEnough == "Y" && (lstStockBasedexpiry[0].StockAll / package) >= Convert.ToInt32(txtQuantity.Text))
                                        {
                                            Flag = false;
                                        }
                                        else
                                        {
                                            Flag = true;
                                        }
                                        //*******Checking Option Flag for Selling Different Expiry When Stock is Not Enough**Added on 2-MAy-14
                                        //*************************************************************************

                                        //Commented on 24-Jan-2014 for Taking STock of particular Expiry Item -->if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / Convert.ToInt32(txtPackage.Text)) < Convert.ToInt32(txtQuantity.Text))
                                        // ItemChanges in following If condition are changed from  "objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock"  into "lstStockBasedexpiry[0].ItemTotalStock" 
                                        //{
                                        if ((lstStockBasedexpiry[0].ItemTotalStock / package) < Convert.ToInt32(txtQuantity.Text) && Flag)
                                        {
                                            int totalquant = lstStockBasedexpiry[0].ItemTotalStock;//Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock);

                                            //GeneralFunction.Information(strMsg + " " + (lstStockBasedexpiry[0].ItemTotalStock / Convert.ToInt32(txtPackage.Text)).ToString(), this.Text);
                                            MessageBox.Show(strMsg + " " + (lstStockBasedexpiry[0].ItemTotalStock / package).ToString(), "Sales Invoice");
                                            txtQuantity.Text = (lstStockBasedexpiry[0].ItemTotalStock / package).ToString();
                                            ////}
                                            //if (txt_quantity.Text != "")
                                            //    remaining = totalquant - Convert.ToInt32(txt_quantity.Text);
                                            //else
                                            //    remaining = totalquant;
                                            // txtTotalStock.Text = txtQuantity.Text; //remaining.ToString();
                                            //  txtTotalStock.Text = txtQuantity.Text; // Commented on 2-May-2014 
                                        }
                                        else
                                        {
                                            if (txtQuantity.Text != "")
                                                remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package) - Convert.ToInt32(txtQuantity.Text);
                                            else
                                                remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package);
                                            txtRemaining.Text = "0";
                                            txtTotalStock.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / package).ToString(); //remaining.ToString();

                                        }
                                    }
                                    else//Expiry item stock greater thannrequired
                                    {
                                        remaining = totalquantity - Convert.ToInt32(txtQuantity.Text);
                                        txtRemaining.Text = remaining.ToString();
                                        int packagerem = 1;
                                        if (package.ToString() != "")
                                            packagerem = package;
                                        remaining = remaining * packagerem;
                                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                        remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / Convert.ToInt32(packagerem)) - Convert.ToInt32(txtQuantity.Text);
                                        //Txt_TotalStock.Text = remaining.ToString();
                                        txtTotalStock.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock / Convert.ToInt32(packagerem)).ToString();


                                    }
                                }
                                else//Expiry item box caption is Piece
                                {
                                    if (txtQuantity.Text != "")
                                    {
                                        if (stock < Convert.ToInt32(txtQuantity.Text))
                                        {
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = 0;
                                            txtRemaining.Text = "0";

                                            //*******Checking Option Flag for Selling Different Expiry When Stock is Not Enough**Added on 2-MAy-14
                                            bool Flag = false;
                                            if (GeneralOptionSetting.FlagSellExpiryWenNotEnough == "Y" && (lstStockBasedexpiry[0].StockAll) >= Convert.ToInt32(txtQuantity.Text))
                                            {
                                                Flag = false;
                                            }
                                            else
                                            {
                                                Flag = true;
                                            }
                                            //*************************************************************************

                                            if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock) < Convert.ToInt32(txtQuantity.Text) && Flag)
                                            {
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;

                                                int totalquant = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock);
                                                //GeneralFunction.Information(strMsg + " " + totalquant.ToString(), this.Text);
                                                MessageBox.Show(strMsg + " " + totalquant.ToString(), "Sales Invoice");
                                                txtQuantity.Text = totalquant.ToString();
                                                if (txtQuantity.Text != "")
                                                    remaining = totalquant - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = totalquant;
                                                txtTotalStock.Text = remaining.ToString();
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());

                                            }
                                            else
                                            {
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemexpname = cmbItem.Text;
                                                if (txtQuantity.Text != "")
                                                    remaining = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock - Convert.ToInt32(txtQuantity.Text);
                                                else
                                                    remaining = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock;
                                                txtTotalStock.Text = remaining.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (txtQuantity.Text != "")
                                                remaining = stock - Convert.ToInt32(txtQuantity.Text);
                                            else
                                                remaining = stock;
                                            txtRemaining.Text = remaining.ToString();
                                            remaining = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock - Convert.ToInt32(txtQuantity.Text));
                                            //Txt_TotalStock.Text = remaining.ToString();
                                            txtTotalStock.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock.ToString();
                                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(remaining.ToString());
                                        }
                                    }
                                }
                            }

                        }//Upto here expiry coding 
                    }
                }
            }


            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "StockAdjustOnKeyUp");
            }
            finally //Added finally to release the object for Performance Tuning on 18-Nov-2014 by Seenivasan
            {
                lstStockBasedSerialNo = null;
                lstStock = null;
                lstStockBasedexpiry = null;
            }
        }

        #endregion

        #region CheckForMoreExpiry
        public void CheckForMoreExpiry()
        {
            try
            {
                if ((cmbItem.Text != "") && (cmbItem.SelectedIndex > -1))
                {

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItem.SelectedValue);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname = cmbItem.Text;
                    DataTable dt = new DataTable();
                    // dt = obj_saleinvoice_dal.checkforexpiry();

                    List<SaleObject> lstExpiryCount = new List<SaleObject>();
                    if (objSaleInvoiceHelper.IsFromGridUpdate)
                        lstExpiryCount = objSaleInvoiceHelper.GetExpiryFromGrid(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid, objSaleInvoiceHelper.XExpiryDate);
                    else
                        lstExpiryCount = objSaleInvoiceHelper.GetExpiryCountHelper();

                    if (lstExpiryCount.Count > 0)
                    {
                        int n = lstExpiryCount.Count;
                        dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
                        //dtpExpiry.DataSource = lstExpiryCount;
                        dtpExpiry.DisplayMember = "ItemExpiryDate";
                        //dtpExpiry.ValueMember = "ItemExpiryDate"; //Commented on 20-May-2014
                        dtpExpiry.ValueMember = "StockID"; //Added on 20-May-2014
                        dtpExpiry.DataSource = lstExpiryCount;
                        dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);
                        dtpExpiry.SelectedIndex = 0;
                        int enable = 0;
                        if (GeneralOptionSetting.FlagDontAlertForExpiryInNotes == "Y")
                        {
                            enable = 0;
                        }
                        else
                            if (GeneralOptionSetting.FlagAlertForMultiExpiry == "Y")
                            enable = 1;

                        if (enable == 1)
                        {

                            if ((n > 1) & (GeneralOptionSetting.FlagDontAlertForExpiryInNotes != "Y"))
                            {
                                rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + " " + "\r\n" + "The Item" + "  " + cmbItem.Text + " " + "Expiry dates:" + '\n';
                                for (int i = 0; i < n; i++)
                                {
                                    DateTime da1 = Convert.ToDateTime(lstExpiryCount[i].ItemExpiryDate.ToString());
                                    rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\r\n " + da1.ToString(ConfigurationManager.AppSettings["DateFormat"]);

                                }
                            }
                            rtxtNotesAndAlerts.Text = rtxtNotesAndAlerts.Text + "\n";
                        }
                    }
                    else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand != "true" && !(string.IsNullOrEmpty(txtTotalStock.Text)))
                    {
                        txtQuantity.Text = (txtQuantity.Text == "") ? "1" : txtQuantity.Text;
                        txtRemaining.Text = (ispackage == false) ? Convert.ToInt32((Convert.ToInt32(txtTotalStock.Text)) - Convert.ToInt32(txtQuantity.Text)).ToString() : (Convert.ToInt32(txtTotalStock.Text) - Convert.ToInt32(txtQuantity.Text)).ToString();
                        txtRemaining.Text = (Convert.ToInt32(txtRemaining.Text) < 0) ? "0" : txtRemaining.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region SerialNoChanged
        public void SerialNoChanged()
        {

            try
            {
                if ((cmbItem.Text.Trim() != "") && (cmbSerialNo.Items.Count > 0) && (cmbSerialNo.Text != string.Empty))
                {

                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt64(cmbSerialNo.Text);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = cmbSerialNo.Text;
                    List<SaleObject> lstStock = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();
                    //  DataTable dt = new DataTable();
                    //    dt = obj_saleinvoice_dal.stockbasedserialno();
                    if (lstStock.Count > 0)
                    {
                        if (lstStock[0].ItemTotalStock.ToString() != "")
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock = lstStock[0].ItemTotalStock;
                        else
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock = 0;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstockcon = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock;
                        txtPrice.Text = lstStock[0].ItemPrice.ToString();

                    }
                    txtQuantity.Text = (txtQuantity.Text != "") ? txtQuantity.Text : "1";
                    txtRemaining.Text = (ispackage == false) ? (Convert.ToInt32((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock / (Convert.ToInt32(cmbPackageQty.Text) == 0 ? 1 : Convert.ToInt32(cmbPackageQty.Text))) - Convert.ToInt32(txtQuantity.Text)).ToString()) : Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialstock - Convert.ToInt32(txtQuantity.Text)).ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region Hidecontrols
        public void Hidecontrols()
        {
            txtDiscount.Enabled = radValue.Enabled = radPercentage.Enabled = ((UserScreenLimidations.DiscountAmt) && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false;
            btnModifyInvoice.Enabled = (UserScreenLimidations.ModifyInvoice) ? true : false;
            if (btnModifyInvoice.Enabled == false)
            {
                btnModifyInvoice.Enabled = (UserScreenLimidations.ModifyTodayInvoice) ? true : false;
            }
            chkShowHideInvoiceCost.Visible = (GeneralOptionSetting.FlagShowInvoiceCostFiled == "Y") ? true : false;
            chkShowHideInvoiceCost.Checked = false;
            btnReceiveReceipt.Enabled = (UserScreenLimidations.ReceiveReceipt) ? true : false;
            dtpDate.Enabled = (UserScreenLimidations.DateModification) ? true : false;
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgrSaleInvoice.Columns["StrItemNo"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dtpExpiry.Visible = (GeneralOptionSetting.FlagSale_DontUseExpiry == "Y") ? false : true;
            lblExpiry.Visible = (GeneralOptionSetting.FlagSale_DontUseExpiry == "Y") ? false : true;
            dgrSaleInvoice.Columns["StrExpiryDate"].Visible = (GeneralOptionSetting.FlagSale_DontUseExpiry == "Y") ? false : true;
            //txtPackage.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            cmbPackageQty.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            lblPackage.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgrSaleInvoice.Columns["Package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgrSaleInvoice.Columns["DateModified"].Visible = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice == "Y" ? false : true);//FlagShowTime Changed By Meena.R on 17Nov2014
            btnF9.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            chkNote.Enabled = (UserScreenLimidations.InvoiceNotes) ? true : false;
            txtNote.Enabled = (UserScreenLimidations.InvoiceNotes) ? true : false;
            btnPrint.Enabled = (UserScreenLimidations.Print) ? true : false;
            btnFindInvoice.Enabled = (UserScreenLimidations.FindSaleInvoice) ? true : false;
            btnBalanceSheet.Enabled = (UserScreenLimidations.BalanceSheet) ? true : false;
            btnItemCard.Enabled = (UserScreenLimidations.ItemCard) ? true : false;
            btnReturnItem.Enabled = (UserScreenLimidations.SaleReturnInvoice) ? true : false;
            btnReturnIQuicktem.Enabled = (UserScreenLimidations.SaleReturnInvoice) ? true : false;
            txtDiscount.Enabled = lblDiscount.Enabled = radValue.Enabled = radPercentage.Enabled = ((UserScreenLimidations.DiscountAmt) && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false;
            txtClientTotal.Visible = btnReset.Visible = (GeneralOptionSetting.FlagShowSubTotalFiled == "Y") ? true : false;
            //Need to check // dgrSaleInvoice.Columns[7].Visible = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice == "Y") ? false : true;
            //Need to check // dgrSaleInvoice.Columns[7].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
            btnExportInvoice.Enabled = UserScreenLimidations.Export;
            if (UserScreenLimidations.ModifyPrices)
            {
                if (GeneralOptionSetting.FlagSalePriceReadonly != "Y")
                {
                    txtPrice.ReadOnly = false;
                    btnPriceChangeF7.Visible = (GeneralOptionSetting.FlagHidePriceChangingButton != "Y") ? true : false;
                }
                else
                {
                    txtPrice.ReadOnly = true;
                    btnPriceChangeF7.Visible = (GeneralOptionSetting.FlagHidePriceChangingButton != "Y") ? true : false;
                }
            }
            else
            {
                txtPrice.ReadOnly = true;
                btnPriceChangeF7.Visible = (GeneralOptionSetting.FlagHidePriceChangingButton != "Y") ? true : false;
            }
            if (UserScreenLimidations.InvoiceNavigation)
            {
                //txtNewInvoiceNo.ReadOnly= txtInvoiceNo.ReadOnly = false;
                btnNext.Visible = true;
                btnPrevious.Visible = true;
                btnLast.Visible = true;
                btnFirst.Visible = true;
            }
            else
            {
                //txtNewInvoiceNo.ReadOnly = txtInvoiceNo.ReadOnly = true;
                txtInvoiceNo.BackColor = Color.White;
                btnNext.Visible = false;
                btnPrevious.Visible = false;
                btnLast.Visible = false;
                btnFirst.Visible = false;
            }

            txtTotal.Visible = lblTotal.Visible = txtDiscount.Visible = lblDiscount.Visible = txtNet.Visible = lblNet.Visible = UserScreenLimidations.InvTotalFields;
            //below Added on 28-Oct-2014
            if (UserScreenLimidations.InvTotalFields)
            {
                txtTotal.Visible = lblTotal.Visible = UserScreenLimidations.SubTotalField;
                txtNet.Visible = lblNet.Visible = UserScreenLimidations.TotalField;
            }
            //******

            btnItemInfo.Enabled = UserScreenLimidations.ItemInfo;
            btnDeleteItem.Enabled = UserScreenLimidations.DeleteItem;

        }
        #endregion

        #region BoxFunction
        public void BoxFunction()
        {
            radPercentage.Enabled = true;
            radValue.Enabled = true;
            if (ispackage == false)
            {
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                ispackage = true;
            }
            else
            {
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                ispackage = false;
            }


            List<SaleObject> lstPackageQtyforItem = (List<SaleObject>)cmbPackageQty.DataSource;
            int count = lstPackageQtyforItem.Count;
            int selectedindex = cmbPackageQty.SelectedIndex + 1; ;
            // added on 28-Feb-2019
            if (count > 1)
            {
                ispackage = false;
            }
            //
            if (lstPackageQtyforItem.Count > 0)
            {
                if (count == selectedindex)
                {
                    cmbPackageQty.SelectedIndex = 0;
                }
                else
                {
                    cmbPackageQty.SelectedIndex++;
                }
            }

            BoxPrice();
            StockAdjustOnKeyUp();
            if (Oldfocus == "Item")
                cmbItem.Focus();
            else if (Oldfocus == "Qty")
            {
                txtQuantity.Focus();
                txtQuantity.SelectAll();
            }
            else if (Oldfocus == "price")
            {
                txtPrice.Focus();
                txtQuantity.SelectAll();
            }


        }
        #endregion

        #region DebtCalculation
        public Boolean DebtCalculation()
        {
            try
            {
                float TotalClientValue = 0.0f;
                if (txtNet.Text != "")
                    TotalClientValue = float.Parse(txtNet.Text);
                if (cmbClient.SelectedIndex > -1)

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt32(cmbClientNo.Text);
                //Getting Debtlimit of agent
                List<SaleObject> lstDebtLimit = objSaleInvoiceHelper.GetDebtLimitHelper();
                float debtlimit = 0.0f;
                Boolean eligible = false;
                if ((cmbClientNo.Text != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()) && (cmbClientNo.Text != ""))
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
        }

        #endregion

        #region NewInvoice
        private void NewInvoice()
        {
            try
            {
                objSaleInvoiceHelper.NewbtnYearInvoice();
                txtInvoiceNo.Text = objSaleInvoiceHelper.InvoiceID[0].ToString();
                // txtNewInvoiceNo.Text = objSaleInvoiceHelper.InvoiceID[1].ToString() + '-' + objSaleInvoiceHelper.InvoiceID[2].ToString();
                txtNewInvoiceNo.Text = objSaleInvoiceHelper.InvoiceID[2].ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = objSaleInvoiceHelper.InvoiceID[3];
                SetEmptyRecord();
                if (objSaleInvoiceHelper.SaveSalesHelper())
                {
                    txtInvoiceNo.Text = txtInvoiceNo.Text;
                }
                else
                {
                    txtInvoiceNo.Text = (Convert.ToInt64(txtInvoiceNo.Text) - 1).ToString();
                }
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = Convert.ToInt32(txtInvoiceNo.Text);
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "NewInvoice()");
            }
        }
        #endregion

        #region Clear
        public void Clear()
        {
            cmbItemNo.SelectedIndexChanged -= new EventHandler(cmbItemNo_SelectedIndexChanged);
            cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            cmbPackageQty.SelectedIndexChanged -= new EventHandler(cmbPackageQty_SelectedIndexChanged);
            dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
            ////dtpExpiry.SelectedIndexChanged -= new EventHandler(dtpExpiry_SelectedIndexChanged);
            if (cmbItemNo.Items.Count > 0)
            {
                cmbItemNo.SelectedIndex = -1;
                // cmbItemNo.Text = string.Empty;//Commented on 23-June-2014 for Avoiding Performance issue
            }
            //  cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            if (cmbItem.Items.Count > 0)
            {
                cmbItem.SelectedIndex = -1;
                //  cmbItem.Text = string.Empty;//Commented on 23-June-2014 for Avoiding Performance issue
            }
            //  cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            txtQuantity.Text = "";
            txtPrice.Text = "0";
            txtRemaining.Text = "";
            txtPackage.Text = "";
            cmbPackageQty.DataSource = null;//Added on 05-Sept-2014 By Meena.R
            cmbPackageQty.Text = "1";//Added on 12-May-2014
            txtTotalStock.Text = "0";//Added on 12-May-2014
            dtpExpiry.Text = "";
            cmbSerialNo.Text = "0";
            cmbSerialNo.Visible = false;
            lblSerialNo.Visible = false;
            txtTotal.Text = "0";
            txtPaymentCharges.Text = "0";
            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            txtDiscount.Text = "0";
            txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
            txtNet.Text = "0";
            cmbCategory.SelectedIndexChanged -= new EventHandler(this.Cmb_Category_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged -= new EventHandler(this.Cmb_Company_SelectedIndexChanged);
            cmbCategory.SelectedIndex = 0; // 0 was before -1 //Changed to select all all in Category and company 
            cmbCompany.SelectedIndex = 0;// 0 was before -1
            cmbCategory.SelectedIndexChanged += new EventHandler(this.Cmb_Category_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged += new EventHandler(this.Cmb_Company_SelectedIndexChanged);
            dtpExpiry.DataSource = null;

            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
            cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            cmbPackageQty.SelectedIndexChanged += new EventHandler(cmbPackageQty_SelectedIndexChanged);
            dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);
            ////dtpExpiry.SelectedIndexChanged += new EventHandler(dtpExpiry_SelectedIndexChanged);

        }
        #endregion

        #region DefaultValue
        private void DefaultValue()
        {
            radPercentage.Enabled = true;
            radValue.Enabled = true;
            //Grb_ItemInformation.Visible = false;//need to implement the Group Box for showing Item Information
            Hidecontrols();

            radValue.Checked = true;
            txtTotalSaleValue.Text = "0";
            txtClientTotal.Text = "0";
            cmbClient.Text = "";
            txtNote.Text = "";
            cmbClientNo.SelectedIndex = -1;

            //dtSaleExtended.Rows.Clear();
            objSaleInvoiceHelper.lstInsertDetails.Clear();
            //dgrSaleInvoice.BackgroundColor = Color.Beige;  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            dgrSaleInvoice.BackgroundColor = Color.WhiteSmoke;
            dgrSaleInvoice.DefaultCellStyle.BackColor = Color.White;
            btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
            ispackage = false;
            string temp = txtInvoiceNo.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(txtInvoiceNo.Text);
        }
        #endregion

        #region SetEmptyRecord
        private void SetEmptyRecord()
        {
            cmbClientNo.SelectedIndex = -1;
            cmbClientNo.Text = string.Empty;
            cmbClient.SelectedIndex = -1;
            dtpExpiry.SelectedIndex = -1;
            dtpExpiry.Text = string.Empty;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.accountid = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(txtInvoiceNo.Text);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice == "Y") ? Convert.ToDateTime(dtpDate.Value) : DateTime.Now;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.balance = Convert.ToDecimal(0.0);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.tax = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.tax1 = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount = 0.0f;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.gross = 0.0f;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netamount = Convert.ToDecimal(0.0);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SaleType = Convert.ToInt16(SalesType.Normal);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.createdby = GeneralFunction.UserId;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.modifiedby = GeneralFunction.UserId;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.note = "";
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.actualdiscount = 0;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype = Convert.ToInt16(SalesDiscountType.Value);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.includetax = Convert.ToInt16(SalesIncludeTax.Yes);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID = 0;
        }

        #endregion

        #region ActiveUserGetAndUpdate
        private void ActiveUserGetAndUpdate()
        {
            //****Commented for Performance Tuning on 18-Nov-2014 by Seenivasan*****
            //objSaleInvoiceHelper.UpdateActiveUserHelper();
            //List<SaleObject> lstActiveUser = objSaleInvoiceHelper.GetActiveUserHelper();
            //txtActiveUser.Text = (lstActiveUser.Count > 0) ? lstActiveUser[0].Activuser.ToString() : "";
            //****************************************************************

            //*******Added try catch finally to release the object for Performance Tuning on 18-Nov-2014 by Seenivasan
            List<SaleObject> lstActiveUser;
            try
            {
                objSaleInvoiceHelper.UpdateActiveUserHelper();
                lstActiveUser = objSaleInvoiceHelper.GetActiveUserHelper();
                txtActiveUser.Text = (lstActiveUser.Count > 0) ? lstActiveUser[0].Activuser.ToString() : "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                lstActiveUser = null;
            }
            //********************************************************************

        }
        #endregion

        #region DisplayInvoiceDetailsBasedOnInvNo
        private void DisplayInvoiceDetailsBasedOnInvNo()
        {
            this.Clear();
            DefaultValue();
            if (find_saleID != null && find_saleID != 0)
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt32(find_saleID);
                find_saleID = 0;//added by Meena.R on 12/01/2015
            }
            ActiveUserGetAndUpdate();

            objSaleInvoiceHelper.SetNewYearInvoiceNo();
            if (string.IsNullOrEmpty(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo))
            {
                NewInvoice();
                objSaleInvoiceHelper.SetNewYearInvoiceNo();
            }
            txtNewInvoiceNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NewYearInvoiceNo;
            if (string.IsNullOrEmpty(txtNewInvoiceNo.Text))
            {
                txtNewInvoiceNo.Text = "1";
            }
            var watch = Stopwatch.StartNew();
            List<SaleObject> lstInvDetails = objSaleInvoiceHelper.GetSaleDetailsHelper();
            watch.Stop();
            var elaspsedMS = watch.ElapsedMilliseconds;
            List<SaleObject> lstInvDetailsExtnd = objSaleInvoiceHelper.GetSaleDetailsExtendedHelper();

            //objSaleInvoiceHelper.lstSaleDetailExtended.Clear();
            if (lstInvDetails.Count > 0)
            {

                txtNote.Text = lstInvDetails[0].note.ToString();
                float TotalAmt = 0.0f;
                float Discount = 0.0f;
                float NetAmt = 0.0f;
                decimal PaymentCharges = 0;
                float DiscountPercentage = 0.0f;
                cmbClient.Text = lstInvDetails[0].ClientName.ToString();
                cmbClientNo.Text = lstInvDetails[0].ClientID.ToString();
                NetAmt = float.Parse(lstInvDetails[0].netamount.ToString());
                TotalAmt = float.Parse(lstInvDetails[0].total.ToString());
                PaymentCharges = Convert.ToDecimal(lstInvDetails[0].paymentCharges.ToString());
                Discount = float.Parse(lstInvDetails[0].discount.ToString());
                if (lstInvDetails[0].discounttype == Convert.ToInt16(SalesDiscountType.Percentage))
                {
                    DiscountPercentage = float.Parse(lstInvDetails[0].actualdiscount.ToString());
                    radPercentage.Checked = true;
                    if (Discount > 0)
                    {
                        // Modified by gopi on 27/10/2014
                        //Discount = Discount * 100 / TotalAmt;
                        // Modified by T on 29/04/2019
                        Discount = TotalAmt / 100 * DiscountPercentage;
                    }
                }
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount = Discount;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype = lstInvDetails[0].discounttype;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.actualdiscount = lstInvDetails[0].actualdiscount;
                chkIncludeTax.Checked = (lstInvDetails[0].includetax == 1) ? true : false;
                txtTotal.Text = TotalAmt.ToString("####0.000");
                txtPaymentCharges.Text = PaymentCharges.ToString("####0.000");
                // Commit 17-Dec-2018 I
                //txtDiscount.TextChanged -= new EventHandler(txtDiscount_TextChanged);//Added on 23-June-2014 for Avoiding Performance issue
                //txtDiscount.Text = Discount.ToString();// (lstInvDetails[0].actualdiscount.ToString() != "0" ? lstInvDetails[0].actualdiscount.ToString("#####0.000") : "0.000");  //discountm.ToString();
                //txtDiscount.TextChanged += new EventHandler(txtDiscount_TextChanged);//Added on 23-June-2014 for Avoiding Performance issue

                NetAmt = NetAmt + (float)PaymentCharges;
                txtNet.Text = NetAmt.ToString("####0.000");
                // Comment 17-Dec-2018 I
                txtDiscount.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype == 2 ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.actualdiscount.ToString() : Discount.ToString();
                radValue.Enabled = radPercentage.Enabled = txtDiscount.Enabled = (lstInvDetails[0].Status == 2) ? false : (((UserScreenLimidations.DiscountAmt) && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false);
                //dgrSaleInvoice.BackgroundColor = (lstInvDetails[0].status == 2) ? Color.Gray : Color.Beige; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgrSaleInvoice.BackgroundColor = (lstInvDetails[0].status == 2) ? Color.Gray : Color.WhiteSmoke;
                dgrSaleInvoice.DefaultCellStyle.BackColor = (lstInvDetails[0].status == 2) ? Color.Gainsboro : Color.White;
                lblUser.Visible = lblUserName.Visible = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? true : false;
                lblUser.Text = lstInvDetails[0].user.ToString();

                if (lstInvDetails[0].CreatedDate > DateTime.Now)//Added on 8-May-2014 for When Changing the System date to future dates and Put Invoices on that Date ..here Exception WIll throw, because we set Max Date as Today in Dtp Date field
                {
                    dtpDate.Value = DateTime.Now;
                }
                else
                {
                    dtpDate.Value = lstInvDetails[0].CreatedDate;
                }

                lstInvDetailsExtnd = objSaleInvoiceHelper.SortInvoiceDetails(lstInvDetailsExtnd, "ItemDescription", "ItemUnitPrice");


                dgrSaleInvoice.AutoGenerateColumns = false;
                dgrSaleInvoice.DataSource = null;
                // dgrSaleInvoice.Refresh();
                dgrSaleInvoice.DataSource = lstInvDetailsExtnd;
                CalculateTotalInvoiceCost(lstInvDetails);

                //objSaleInvoiceHelper.SetList(lstInvDetailsExtnd);//Added on 14-May-2014 for setting the List of lstSaleDetailExtended(Grid List) when Intial Load
                // List<SaleObject> lstInvDetailsTest = objSaleInvoiceHelper.lstSaleDetailExtended; //Commented for Performance Tuning on 18-Nov-2014 by Seenivasan

                txtTotalSaleValue.Text = Convert.ToDecimal(lstInvDetailsExtnd.Sum(a => a.Totalcost)).ToString("######0.000");//Commented on 19-May-2014 --- I uncomment this 23-Oct-2018
                //txtTotalSaleValue.Text = (Math.Truncate(Convert.ToDecimal(lstInvDetailsExtnd.Sum(a => a.Totalcost) * 1000M) / 1000M)).ToString("####0.000");//Added on 19-May-2014 --- I comment this

                lblUser.Text = (dgrSaleInvoice.BackgroundColor == Color.Gray) ? lblUser.Text + " " + dtpDate.Value.ToShortTimeString() : lblUser.Text;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID = lstInvDetails[0].receive_paymenttypeID;
            }
            else
            {
                dgrSaleInvoice.AutoGenerateColumns = false;
                dgrSaleInvoice.DataSource = null;
                CalculateTotalInvoiceCost(null);

                // dgrSaleInvoice.Refresh();
                lblUser.Visible = lblUserName.Visible = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? true : false;
                lblUser.Text = GeneralFunction.UserName;
                dtpDate.Value = DateTime.Now;

                // Added on 26-Mar-2019 By T
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.actualdiscount = 0;
                txtNet.Text = "0";
            }

            NotesArea();
            cmbItem.SelectedIndex = -1;
            lstInvDetails = null; //Added for Performance Tuning on 18-Nov-2014 by Seenivasan
            lstInvDetailsExtnd = null; //Added for Performance Tuning on 18-Nov-2014 by Seenivasan
        }
        #endregion

        #region SetObjectFromControl
        private void SetObjectFromControl()
        {

            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemSelectedIndex = cmbItem.SelectedIndex;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemSelectedText = cmbItem.SelectedText;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemSelectedValue = cmbItem.SelectedValue;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname = cmbItem.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientNoSelectedIndex = cmbClientNo.SelectedIndex;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText = txtQuantity.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.RemainingText = txtRemaining.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DgrBgColorValue = dgrSaleInvoice.BackgroundColor.ToString();

            //var dt = dtpExpiry.SelectedText;
            //var dt1 = ((ObjectHelper.SaleObject)dtpExpiry.SelectedItem).ItemExpiryDate;
            //if (cmbClientNo.SelectedIndex < 0) { cmbClientNo.SelectedIndex = 0; }
            //cmbSerialNo.SelectedIndex = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem == true) ? (((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true") && (cmbSerialNo.Items.Count > 0)) ? 0 : -1) : cmbSerialNo.SelectedIndex;
            //if ((dtpExpiry.Items.Count == 0) && (dtpExpiry.Visible == true)) { dtpExpiry.Visible = false; }
            //dtpExpiry.SelectedIndex = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem == true) ? (((dtpExpiry.Items.Count > 0) && (dtpExpiry.Visible == true)) ? 0 : -1) : dtpExpiry.SelectedIndex;

            // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText = txtPackage.Text; \\ Commented On 18-Apr-14
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText = (cmbPackageQty.SelectedIndex != -1 && cmbPackageQty.Text != "" && cmbPackageQty.Text != "0") ? cmbPackageQty.Text : "1";//Added on 18-Apr-14
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage = ispackage;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText = txtPrice.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText = (txtInvoiceNo.Text != "") ? Convert.ToInt64(txtInvoiceNo.Text) : 0;


            //var price = txtPrice.Text;
            //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ExpirySelectedVal = (dtpExpiry.Text != "" ? Convert.ToDateTime(dtpExpiry.Text) : Convert.ToDateTime("1/1/1900"));
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ExpirySelectedVal = (dtpExpiry.Text != "" ? ((ObjectHelper.SaleObject)dtpExpiry.SelectedItem).ItemExpiryDate : DateTime.MinValue);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DtpExpiryCount = dtpExpiry.Items.Count;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientNoSelectedValue = cmbClientNo.SelectedValue;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedIndex = cmbSerialNo.SelectedIndex;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoCount = cmbSerialNo.Items.Count;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText = cmbSerialNo.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemNo = Convert.ToInt32(cmbItem.SelectedValue);
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbItemNoVisible = cmbItemNo.Visible;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbSerialNoNoVisible = cmbSerialNo.Visible;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DtpExpiryVisible = dtpExpiry.Visible;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText = txtNet.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientSelectedIndex = cmbClient.SelectedIndex;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText = cmbClientNo.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DgrRowCount = dgrSaleInvoice.Rows.Count;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActiveUserText = txtActiveUser.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalText = txtTotal.Text;

            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DiscountText = (txtDiscount.Text != "" && txtDiscount.Text != "." ? (Math.Truncate(Convert.ToDecimal(txtDiscount.Text) * 1000M) / 1000M).ToString() : "");
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ValueChecked = radValue.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PercentageChecked = radPercentage.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked = chkIncludeTax.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = cmbClient.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.StrItemNo = cmbItemNo.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = (cmbPackageQty.SelectedIndex != -1 && cmbPackageQty.Text != "") ? Convert.ToInt32(cmbPackageQty.SelectedValue) : 0;//Added on 18-Apr-14
        }
        #endregion

        #region SetRowColor
        public void SetRowColor(string ComboItemName)
        {
            if (dgrSaleInvoice.Rows.Count == 0) return;
            if (dgrSaleInvoice.SelectedRows.Count > 0)
            {
                int rid = dgrSaleInvoice.SelectedRows[0].Cells["ItemNo"].RowIndex;
                dgrSaleInvoice.Rows[rid].Selected = false;
            }

            //  DataRow[] drow = dtSaleExtended.Select("ItemDesc='" + GeneralFunction.RemoveApostrophe(ComboItemName) + "'");
            //if (drow.Length > 0)
            //{
            //    int riid = dtSaleExtended.Rows.IndexOf(drow[0]);
            //    dgrSaleInvoice.Rows[riid].Selected = true;
            //}
            Index = objSaleInvoiceHelper.lstSaleDetailExtended.FindIndex(a => (a.ItemDescription == GeneralFunction.RemoveApostrophe(ComboItemName)));
            if (Index != -1)
            {
                dgrSaleInvoice.Rows[Index].Selected = true;
                dgrSaleInvoice.FirstDisplayedScrollingRowIndex = Index;
            }
        }
        #endregion

        #region InsertItem
        private void
            InsertItem()
        {
            //GeneralFunction.Trace("SetObjectFromControl3 Start");Commended on 23jan2015 to fix performance issue
            //SetObjectFromControl();
            //GeneralFunction.Trace("SetObjectFromControl3 End");

            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true)
            {
                if (Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText) != decimal.Parse((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)).ToString("#####0.000")))
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? (Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText != string.Empty) ? Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText) * Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) : 0.000m)) : (Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText));
                }
            }
            else
            {
                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice != Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText))
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice = Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText);
            }
            if (objSaleInvoiceHelper.ValidateItemInsertion() == false)
            {
                return;
            }
            SetRowColor(" ");

            int count = 0;
            //Following is Getting Total Quantity in Pieces
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText) : (Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText) * Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText));

            while (count < objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty)
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = 1;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.batchid = 1;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemNo;
                //Following is getting Price for one piece
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? (Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText != string.Empty) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText : "0.000")) : (Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText));
                //Following is getting Price for one Package
                //Commented on 28-Oct-2014     // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? (Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText != string.Empty) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText : "0.000")) : (Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText) * Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText));
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPackageprice;   //Added on 28-Oct-2014  
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DtpExpiryCount > 0)) ? Convert.ToDateTime(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ExpirySelectedVal.ToString()) : Convert.ToDateTime("1/1/1900");


                if ((dtpExpiry.Visible == true) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry != Convert.ToDateTime("1/1/1900")))//here the or condition changes into && By Meena.R on 16/10/2014
                {
                    //****Below Functionlity to check expiry Date is Expired or not****//
                    string noww = DateTime.Now.ToShortDateString().ToString();
                    string[] exp = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry.ToString().Split(' ');
                    DateTime nowdt, exdt = new DateTime();
                    nowdt = Convert.ToDateTime(noww);
                    exdt = Convert.ToDateTime(exp[0]);
                    int diffdt = exdt.CompareTo(nowdt);
                    //*****************************************************************//
                    // objSaleInvoiceHelper.CheckDateIsExpiryHelper();Commented on 30-Apr-2014 and Removed from below if condition to check the Date is Expired
                    if (exp[0] != noww && diffdt > 0)
                    {
                        List<SaleObject> lstStockBasedexpiry = objSaleInvoiceHelper.GetStockBasedExpiryHelper();

                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock = (lstStockBasedexpiry.Count > 0 && lstStockBasedexpiry[0].ItemTotalStock.ToString() != "") ? Convert.ToInt32(lstStockBasedexpiry[0].ItemTotalStock.ToString()) : 0;
                        if (objSaleInvoiceHelper.IsFromGridUpdate)
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock += objSaleInvoiceHelper.XStockInHand;
                        if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock >= objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                        {
                            count = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty.ToString());
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty.ToString());
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = false;
                        }
                        else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                        {
                            count = count + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock.ToString());
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expitem = true;
                        }
                    }
                    else
                    {
                        PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                        frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbesold");
                        frmExpiry.ShowDialog();
                        return;
                    }

                }
                else if (cmbSerialNo.Visible == true)
                {

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock = 0;
                    DataTable dt = new DataTable();
                    cmbSerialNo.SelectedIndex = ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedIndex == -1) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoCount > 0)) ? 0 : objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedIndex;
                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt64(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText;
                    List<SaleObject> lstStockBasedSerialNo = objSaleInvoiceHelper.GetStockBasedSerialNoHelper();

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock = (lstStockBasedSerialNo.Count > 0 && lstStockBasedSerialNo[0].ItemTotalStock.ToString() != "") ? Convert.ToInt32(lstStockBasedSerialNo[0].ItemTotalStock.ToString()) : 0;
                    if (objSaleInvoiceHelper.IsFromGridUpdate)
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock += objSaleInvoiceHelper.XStockInHand;
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock >= objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty)
                    {
                        count = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty.ToString());
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;

                    }
                    else
                    {
                        count = count + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemstock.ToString());
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;
                    }

                }

                else
                {
                    count = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText) : Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = Convert.ToDouble(count.ToString());
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == true) ? Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText) : Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.QtyText);
                }



                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemdiscount = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime = (GeneralOptionSetting.FlagHideItemSaleTimeInInvoice == "Y") ? Convert.ToDateTime(dtpDate.Value) : dtpDate.Value;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.createdby = GeneralFunction.UserId;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.modifiedby = GeneralFunction.UserId;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNoText;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id = 1;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText == string.Empty ? "0" : objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientNoSelectedText);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ReturnQty = 0;
                //Getting Average Cost for Particular Selected Item 
                //List<SaleObject> lstitemAvgCost = objSaleInvoiceHelper.GetItemAvgCostHelper();this line commended on 23jan2015 to fix performance issur


                //Checking the Option for GeneralOptionSetting.FlagAlterwhenSellingLessthanCost
                //  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemcost = (lstitemAvgCost.Count > 0) ? Convert.ToDouble((float.Parse(lstitemAvgCost[0].AvgCost.ToString()) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)).ToString()) : Convert.ToDouble("0.000");
                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)//Added to define the Itemcost for the meal item item
                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost = (lstitemAvgCost.Count > 0) ? lstitemAvgCost[0].AvgCost : 0;//---> one piece Average cost Commended By Meena.R on 11Nov2014//Commended on 23jan2015 to fix performance issue
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost = AvgCostofItem;
                // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost=(lstitemAvgCost.Count > 0) ? Convert.ToDecimal((lstitemAvgCost[0].AvgCost) / Convert.ToInt32(cmbPackageQty.Text)) : Convert.ToDecimal("0.000");//need change 
                if ((Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost.ToString("#####0.000")) > Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) & (GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") & (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                {
                    if (GeneralFunction.Question("CostGreaterthanSalePrice", "Sales Invoice") != DialogResult.Yes)

                        return;//this condition Commended By Meena.R on 07/08/2014 to fix when piece wise sale it shows message // This condition again re commented by Seenivasan on 15-Oct-2014 
                }
                //*************************Seenivasan Commented below line added by meena for wrong calculation of Item cost when sellin item as piece on 15-Oct-2014******************* 
                //if (ispackage == false)
                //{
                //    if ((Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost.ToString("#####0.000")) > Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) & (GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") & (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                //    {
                //        if (GeneralFunction.Question("CostGreaterthanSalePrice", "Sales Invoice") != DialogResult.Yes)

                //            return;
                //    }
                //}
                //else
                //{
                //    if (((Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost.ToString("#####0.000")) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)) > Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString("#####0.000"))) & (GeneralOptionSetting.FlagAlterwhenSellingLessthanCost == "Y") & (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch != "branch"))
                //    {
                //        if (GeneralFunction.Question("CostGreaterthanSalePrice", "Sales Invoice") != DialogResult.Yes)

                //            return;
                //    }

                //}
                //*********************************************************************************************************************************************
                decimal totalcost = 0;
                txtTotalSaleValue.Clear();//added by prabhakaran.s to clear the cost while modify on 7th Jan 2016
                //totalcost = float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity.ToString()) * float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemcost.ToString());//Commented on 19-May-2014
                //totalcost = ((lstitemAvgCost.Count > 0) ? Convert.ToDecimal((lstitemAvgCost[0].AvgCost) / Convert.ToInt32(cmbPackageQty.Text)) : Convert.ToDecimal("0.000")) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;//added on 11Nov2014

                //totalcost = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemCost;
                totalcost = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity * Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText);//Added on 19-May-2014///this line commended by meena.R on 11Nov2014 to calculate the exact profit


                totalcost = (txtTotalSaleValue.Text != string.Empty) ? (Convert.ToDecimal(txtTotalSaleValue.Text) + totalcost) : totalcost;//Added on 19-May-2014
                // txtTotalSaleValue.Text = (txtTotalSaleValue.Text != string.Empty) ? (Convert.ToDecimal(txtTotalSaleValue.Text) + totalcost).ToString("######0.000") : totalcost.ToString("######0.000");//Commented on 19-May-2014
                txtTotalSaleValue.Text = (Math.Truncate(totalcost * 1000M) / 1000M).ToString("######0.000");//Added on 19-May-2014
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity;
                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText != string.Empty) ? Convert.ToInt64(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText) : 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText != string.Empty) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedText : "0";
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Box = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage == false ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity / Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) : 0);//Added on 23-May-2014

                if (dgrSaleInvoice.Rows.Count > 0 && GeneralOptionSetting.FlagSale_InsertItemIndividually != "Y")
                {
                    if (!objSaleInvoiceHelper.IsFromGridUpdate)
                        Index = objSaleInvoiceHelper.UpdateSaleDetailList();
                    else
                    {
                        //if (objSaleInvoiceHelper.XBarcodeID == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID)
                        //{
                        //comment by thamil for add the quantity 2 times issus while update
                        //Index = objSaleInvoiceHelper.UpdateSaleDetailList();//added
                        Index = objSaleInvoiceHelper.FindIndex();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = objSaleInvoiceHelper.lstSaleDetailExtended[Index].saledetid;
                        objSaleInvoiceHelper.FillSaleDetailList();
                        //}
                    }

                    dgrSaleInvoice.AutoGenerateColumns = false;
                    dgrSaleInvoice.DataSource = null;
                    // dgrSaleInvoice.Refresh();
                    dgrSaleInvoice.DataSource = objSaleInvoiceHelper.lstSaleDetailExtended;
                    CalculateTotalInvoiceCost(objSaleInvoiceHelper.lstSaleDetailExtended);

                    if (Index != -1)
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id = 2;
                        if (GeneralOptionSetting.FlagHideItemNumber != "Y")
                            dgrSaleInvoice.FirstDisplayedCell = dgrSaleInvoice.Rows[Index].Cells["StrItemNo"];
                        else
                            dgrSaleInvoice.FirstDisplayedCell = dgrSaleInvoice.Rows[Index].Cells["ItemDesc"];
                        dgrSaleInvoice.Rows[Index].Selected = true;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt16((dgrSaleInvoice.Rows[Index].Cells["Qty"].Value.ToString()));
                        string a = dgrSaleInvoice.Rows[Index].Cells["saledetailid"].Value.ToString();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = Convert.ToInt64(dgrSaleInvoice.Rows[Index].Cells["saledetailid"].Value.ToString());
                        ///setting subtotal
                        decimal clienttotal = 0.0m;
                        if (objSaleInvoiceHelper.IsFromGridUpdate)
                        {
                            txtClientTotal.Text = (Decimal.Parse(txtClientTotal.Text) - objSaleInvoiceHelper.XF10Total).ToString();
                        }
                        if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) == 0)
                        {
                            clienttotal = (txtClientTotal.Text != "") ? Decimal.Parse(txtClientTotal.Text) + decimal.Parse((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice)).ToString("####0.000")) : decimal.Parse((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice)).ToString("####0.000"));
                        }
                        else
                        {
                            clienttotal = (txtClientTotal.Text != "") ? Decimal.Parse(txtClientTotal.Text) + Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")) : Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                        }
                        //clienttotal = (txtClientTotal.Text != "") ? float.Parse(txtClientTotal.Text) + float.Parse((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock * float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString())).ToString()) : float.Parse((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock * float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString())).ToString("####0.000"));line commended by Meena.R on 19Dec2014
                        txtClientTotal.Text = clienttotal.ToString();
                        SetTotal();
                        goto Insert;
                    }


                }
                else
                {//this condition added by Meena.R on 18nov2014 to find the updated index when given Insert individual
                    if (objSaleInvoiceHelper.IsFromGridUpdate)
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id = 2;
                        Index = objSaleInvoiceHelper.FindIndex();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = objSaleInvoiceHelper.lstSaleDetailExtended[Index].saledetid;
                        objSaleInvoiceHelper.FillSaleDetailList();
                        txtClientTotal.Text = (Decimal.Parse(txtClientTotal.Text) - objSaleInvoiceHelper.XF10Total).ToString();

                    }
                }
                //Setting Client Sub total Field on 23-April-14
                Decimal clienttotals = 0;
                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity % Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) == 0)
                {
                    clienttotals = (txtClientTotal.Text != "") ? Decimal.Parse(txtClientTotal.Text) + decimal.Parse((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice)).ToString("####0.000")) : decimal.Parse((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText) * (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice)).ToString("####0.000"));
                }
                else
                {
                    clienttotals = (txtClientTotal.Text != "") ? Decimal.Parse(txtClientTotal.Text) + Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000")) : Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IsPackage != true) ? ((Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ActualPrice).ToString("######0.000") : (Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price).ToString("######0.000"));
                }
                //clienttotals = (txtClientTotal.Text != "") ? Convert.ToDecimal(txtClientTotal.Text) + Convert.ToDecimal((Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString())).ToString()) : Convert.ToDecimal((Convert.ToInt16(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock) * Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString())).ToString());
                txtClientTotal.Text = clienttotals.ToString("####0.000");
                //
                objSaleInvoiceHelper.FillSaleDetailList();
                DataGridSource();

                if (GeneralOptionSetting.FlagHideItemNumber != "Y")
                    dgrSaleInvoice.FirstDisplayedCell = dgrSaleInvoice.Rows[dgrSaleInvoice.Rows.Count - 1].Cells["StrItemNo"];
                else
                    dgrSaleInvoice.FirstDisplayedCell = dgrSaleInvoice.Rows[dgrSaleInvoice.Rows.Count - 1].Cells["ItemDesc"];

                SetTotal();

                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.taxofitem = 0;

                ///Saving Sales Details Part
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.package = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText != "" && objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText != "0" ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText : "1");
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ItemTax2 = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SubTax1 = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SubTax2 = 0;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalAmount = 0;

                Insert:
                if (objSaleInvoiceHelper.IsFromGridUpdate)
                {
                    objSaleInvoiceHelper.ItemDetailsUpdation(objSaleInvoiceHelper.XStockInHand, objSaleInvoiceHelper.XPrice, objSaleInvoiceHelper.XBox, objSaleInvoiceHelper.XExpiryDate, objSaleInvoiceHelper.XSerialNo, objSaleInvoiceHelper.XBarcodeID);
                }

                if (objSaleInvoiceHelper.SaveSaleDetailsHelper())
                {
                    objSaleInvoiceHelper.IsFromGridUpdate = false;
                    //CommonHelper.CustomNotesAlerts.CustomerMessage(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString("####0.000"),objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.total, CustomMessages.messageType.sale)
                    // GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid + " " + "[" + txtInvoiceNo.Text + "]", "MTB_SALE", "Insert sale invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname + " " + "[" + txtInvoiceNo.Text + "]", "MTB_SALE", "Insert sale invoice details", Convert.ToInt32(InvoiceAction.Yes));

                    if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id == 2) && (count == objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty)) { goto FieldClear; }
                    else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id == 2) { goto End; }
                }
                else
                {
                    GeneralFunction.Information("NotPossibeInsertItem", "Sales Invoice");
                }

                ///End Part
                End: int selectedindexexp = 0;
                if (count < objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty)
                {
                    //*************Commented for Client Clarification on 2/May/2014***************************************
                    if ((GeneralOptionSetting.FlagSellExpiryWenNotEnough != "Y") && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand != "true"))
                    {

                        MessageBox.Show("Available Stock is '" + count.ToString() + "' Only For this ExpiryDate", "Sales Invoice");
                        break;
                    }
                    //*****************************************************************************************************

                    //*************Commented for Client Clarification on 21/May/2014(Need to remove and Replace above code)***************************************
                    //  MessageBox.Show("Available Stock is '" + count.ToString() + "' Only For this ExpiryDate", "Sales Invoice");
                    //  break;
                    //*****************************************************************************************************

                    count = 0;
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id == 1)
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty - Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity.ToString());
                    else
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty - Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock.ToString());
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand == "true")
                    {
                        selectedindexexp = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoSelectedIndex;

                        if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SerialNoCount > (selectedindexexp + 1)) cmbSerialNo.SelectedIndex = selectedindexexp + 1;
                        else
                            break;
                    }
                    else
                    {
                        //if ((dtp_expiry.Visible != false)|(dtp_expiry.Items.Count>0))
                        if ((dtpExpiry.Items.Count > 0))
                        {
                            selectedindexexp = dtpExpiry.SelectedIndex;
                            //if ((dtp_expiry.Visible == true) && (dtp_expiry.Items.Count == selectedindexexp + 1)) { dtp_expiry.DataSource=null; dtp_expiry.Visible = false; obj_saleinvoice.expiry = Convert.ToDateTime("1/1/1900"); }
                            if ((dtpExpiry.Items.Count == selectedindexexp + 1)) { dtpExpiry.DataSource = null; dtpExpiry.Visible = false; objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime("1/1/1900"); objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty = 0; }
                            else dtpExpiry.SelectedIndex = selectedindexexp + 1;
                        }
                    }
                    if ((count < objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty) && (ispackage == false))
                    {
                        txtQuantity.Text = Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty / Convert.ToInt32(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageText)).ToString();
                    }
                    else if ((count < objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty) && (ispackage == true))
                    {
                        txtQuantity.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expirqty.ToString();
                    }
                    SetObjectFromControl();//Aded on 2-May-2014

                }
            }


            FieldClear:
            this.Clear();
            SetTotal();
        }
        #endregion

        #region DataGridSource
        private void DataGridSource()
        {

            dgrSaleInvoice.AutoGenerateColumns = false;
            dgrSaleInvoice.DataSource = null;
            //dgrSaleInvoice.Refresh();
            objSaleInvoiceHelper.lstSaleDetailExtended = objSaleInvoiceHelper.SortInvoiceDetails(objSaleInvoiceHelper.lstSaleDetailExtended, "ItemDescription", "unitprice");
            dgrSaleInvoice.DataSource = objSaleInvoiceHelper.lstSaleDetailExtended;
            CalculateTotalInvoiceCost(objSaleInvoiceHelper.lstSaleDetailExtended);
            //dgvPurchaseInvoice.Refresh();

        }
        #endregion

        #region SetTotal
        public void SetTotal()
        {
            
            objSaleInvoiceHelper.GetSumofSubTotal();
            txtTotal.Text = float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SumOfSubTotal.ToString()).ToString("####0.000");
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.total = Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SumOfSubTotal);
            txtNet.Text = float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SumOfSubTotal.ToString()).ToString("####0.000");
            txtDiscount.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype == 2 ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DiscountText : objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount.ToString("####0.000");// "0.000";
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.net = Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SumOfSubTotal);
            CommonHelper.CustomNotesAlerts.CustomerMessage(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price.ToString("####0.000"), txtTotal.Text, CustomNotesAlerts.messageType.sale);
            // txtClientTotal.Text = float.Parse(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SumOfSubTotal.ToString()).ToString("####0.000");
        }
        #endregion

        #region Validation
        private Boolean Validation()
        {
            if (cmbClient.SelectedIndex < 0)
            {
                cmbClientNo.Text = "1001";
                //cmbClientNo.SelectedText ="1001";
                //  if (GeneralFunction.Language == "Arabic")
                //  {
                //      cmbClient.Text = "زبون نقدي";

                //  }
                //  else
                //  {
                //      cmbClient.Text = "Cash Client";
                //  }
                //cmbClientNo.SelectedText ="1001";
            }

            if (cmbItem.SelectedIndex < 0)
                return false;
            else if (txtPrice.Text == string.Empty)
                return false;
            //else if (dgrSaleInvoice.BackgroundColor != Color.Beige) ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            else if (dgrSaleInvoice.BackgroundColor != Color.WhiteSmoke)
            {
                GeneralFunction.Information("AlreadyInvoiceClosed", "Sales Invoice");
                return false;
            }
            else if ((txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
            {
                string itemname = cmbItem.Text;
                int qty = (txtQuantity.Text == string.Empty) ? 0 : Convert.ToInt32(txtQuantity.Text);
                decimal price = (txtPrice.Text == string.Empty) ? 0 : Convert.ToDecimal(txtPrice.Text);
                string expiry = (dtpExpiry.Visible == true) ? dtpExpiry.Text : "";
                string serialno = (cmbSerialNo.Visible == true) ? cmbSerialNo.Text : "";

                List<SaleObject> lstActiveUser = objSaleInvoiceHelper.GetActiveUserHelper();
                txtActiveUser.Text = (lstActiveUser.Count > 0) ? lstActiveUser[0].Activuser.ToString() : "";

                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return false;
                }

                else
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv;
                    DisplayInvoiceDetailsBasedOnInvNo();
                    cmbItem.Text = itemname;
                    if (cmbItem.SelectedIndex > -1)
                    {
                        txtQuantity.Text = qty.ToString();
                        StockAdjustOnKeyUp();
                        if ((txtQuantity.Text != string.Empty) && Convert.ToInt32(txtQuantity.Text) > 0)
                        {
                            txtPrice.Text = price.ToString("#######0.000");
                            dtpExpiry.Text = ((expiry != string.Empty) && (dtpExpiry.Items.Contains(expiry.ToString()))) ? expiry : dtpExpiry.Text;
                            cmbSerialNo.Text = ((serialno != string.Empty) && cmbSerialNo.Items.Contains(serialno)) ? serialno : cmbSerialNo.Text;
                            return true;
                        }
                        else return false;
                    }
                    else
                        return false;

                }

            }
            else
                return true;

        }
        #endregion

        #region Insert
        private void Insert()
        {
            //*****Saving New Client*********************//

            if (cmbClient.SelectedIndex == -1 && cmbClient.Text != "")
            {
                string agentname = string.Empty;
                agentname = cmbClient.Text.ToUpper().Trim().Replace(" ", "").ToString();
                if (agentname != "زبون نقدي".Trim().Replace(" ", "") && agentname != "Cash Client".ToUpper().Trim().Replace(" ", ""))
                {
                    if (GeneralFunction.Question("Doyouwanttosavenewuser", "Sales Invoice") == DialogResult.Yes)
                    {
                        string strNewAgent = cmbClient.Text;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = cmbClient.Text;
                        if (objSaleInvoiceHelper.SaveNewAgent())
                        {
                            //cmbClient.DataSource = null;
                            //cmbClientNo.DataSource = null;
                            string qty = txtQuantity.Text;
                            string pack = cmbPackageQty.Text;
                            string price = txtPrice.Text;
                            AssignClientDataSource();
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = strNewAgent;
                            cmbClient.Text = strNewAgent;
                            txtQuantity.Text = qty;//this line added on 12Nov2014
                            cmbPackageQty.Text = pack;
                            txtPrice.Text = price;
                        }

                    }
                    else
                        return;
                }
                else
                {
                    GeneralFunction.Information("ExistsAgentName", "SaleInvoice");
                    return;
                }
            }

            ////////////////////////////////////////////////
            //Following code is to check the Debt limit for the Seleted Agent to restrict Exceeded Debt limit
            if (Validation() != true) { goto end; }
            Boolean eligible = true;
            SetObjectFromControl();
            eligible = objSaleInvoiceHelper.DebtCalculation();
            if (eligible != false)
            {
                GeneralFunction.Information("ExceedClientDebtLimit", "Sales Invoice");
                goto end;
            }

            //Followign Code is to check Stop Debt Selling Option (allow only cash client to sale) 
            eligible = StopDebtSelling();
            if (eligible != true)
            {
                GeneralFunction.Information("NotAllowableDebtSelling", "Sales Invoice");
                goto end;
            }

            int perfovalueremain = -1;
            if (!objSaleInvoiceHelper.IsFromGridUpdate)
            {
                if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock != 0) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                {
                    if (txtQuantity.Text != "")
                    { perfovalueremain = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performavalue); }
                }
                if ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock > 0) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                {
                    if ((perfovalueremain >= 0) && (perfovalueremain >= Convert.ToInt32(txtQuantity.Text)))
                        goto iteminsert;
                    if ((perfovalueremain < Convert.ToInt32(txtQuantity.Text)) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performavalue != 0))
                    {
                        if (GeneralFunction.Question("AlreadyQtyEnteredinProforma", "Sales Invoice") == DialogResult.Yes)
                        {
                            goto iteminsert;
                        }
                        else
                            goto end;
                    }
                }
                else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                {
                    GeneralFunction.Information("NoStockItem", "Sales Invoice");
                    goto end;
                }
            }
            else if (objSaleInvoiceHelper.IsFromGridUpdate)
            {
                if (((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock + objSaleInvoiceHelper.XStockInHand) != 0) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                {
                    if (txtQuantity.Text != "")
                    { perfovalueremain = ((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock + objSaleInvoiceHelper.XStockInHand) - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performavalue); }
                }
                if (((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.totalstock + objSaleInvoiceHelper.XStockInHand) > 0) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true))
                {
                    if ((perfovalueremain >= 0) && (perfovalueremain >= Convert.ToInt32(txtQuantity.Text)))
                        goto iteminsert;
                    if ((perfovalueremain < Convert.ToInt32(txtQuantity.Text)) && (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.performavalue != 0))
                    {
                        if (GeneralFunction.Question("AlreadyQtyEnteredinProforma", "Sales Invoice") == DialogResult.Yes)
                        {
                            goto iteminsert;
                        }
                        else
                            goto end;
                    }
                }
                else if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.nonstocklabourmeal != true)
                {
                    GeneralFunction.Information("NoStockItem", "Sales Invoice");
                    goto end;
                }
            }
            iteminsert:
            //GeneralFunction.Trace("SetObjectFromControl2 Start");this line commented on 23jan2015 due to the performance issue this method calling twice
            //SetObjectFromControl();
            //GeneralFunction.Trace("SetObjectFromControl2 End");
            //Added on 18-Apr-14
            if (cmbPackageQty.SelectedIndex != -1 && cmbPackageQty.Text != "" && cmbPackageQty.Text != "0")
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageQtyText = cmbPackageQty.Text;
            }
            else
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PackageQtyText = "1";
            }
            //

            if (objSaleInvoiceHelper.MinPriceAndCostPriceCheck() == true) //Added  nonstocklabourmeal condition on 17-May-2014.But need verification
            {
                InsertItem();
            }

            end:;
            NotesArea();
            cmbItem.Focus();
        }
        #endregion

        #region Delete Methods


        #region ItemDeletion
        public void ItemDeletion()
        {
            string str = "";
            if (dgrSaleInvoice.BackgroundColor != Color.Gray)
            {
                if (dgrSaleInvoice.Rows.Count != 0)
                {
                    if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                    {
                        //if (GeneralFunction.Question(GeneralFunction.ChangeLanguageforCustomMsg("AlertDeleteSelectedRow"), this.Text) != DialogResult.Yes)
                        if (GeneralFunction.Question("AlertDeleteSelectedRow", "Sales Invoice") != DialogResult.Yes)
                        {
                            if (GeneralFunction.Question("AlertDeleteWholeRow", "Sales Invoice") == DialogResult.Yes)
                            {
                                str = "All";
                                DeleteAll();
                                SetTotal();
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), "InvNo-" + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv.ToString(), "SaleInvoice", "Delete sale invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            }
                        }
                        else
                        {
                            str = "One";
                            DeleteItem(str);
                            SetTotal();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname + " " + "Qty-" + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity + " " + "InvNo-" + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv.ToString(), "SaleInvoice", "Delete sale invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else
                    {
                        str = "One";
                        DeleteItem(str);
                        SetTotal();
                    }
                    //Update Payment Charges when Delete
                    float PaymentCharges = objSaleInvoiceHelper.GetPaymentChargesHelper();
                    float txtnet = float.Parse(txtNet.Text);
                    float totalnet = txtnet + PaymentCharges;
                    txtPaymentCharges.Text = PaymentCharges.ToString("####0.000");
                    txtNet.Text = totalnet.ToString("####0.000");
                }
                else
                {
                    GeneralFunction.Information("EmptyInvoiceList", "Sales Invoice");
                }
                txtRemaining.Text = "";
                txtPrice.Text = "";
            }
            else
                GeneralFunction.Information("CantDeleteafterClosingInvoice", "Sales Invoice");


        }
        #endregion

        #region DeleteAll
        public void DeleteAll()
        {

            int n = dgrSaleInvoice.Rows.Count;
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                DeleteItem("All");
                m = i;
            }
            if (m == (n - 1))
                GeneralFunction.Information("DeleteItem", "Sales Invoice");

        }
        #endregion

        #region DeleteItem
        public void DeleteItem(string str)
        {

            if (str == "All")
                dgrSaleInvoice.Rows[0].Selected = true;
            if (dgrSaleInvoice.SelectedRows.Count > 0)
            {
                if (dgrSaleInvoice.SelectedRows[0].Cells["ReturnQuantity"].Value.ToString() == "0")
                {
                    if ((txtDiscount.Text != string.Empty) & (txtDiscount.Text != "0.000") & (txtDiscount.Text != "0"))
                        txtDiscount.Text = "0.000";
                    if (dgrSaleInvoice.SelectedRows[0].Cells["ItemDesc"].Value.ToString() != null)
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "false";
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["ItemNo"].Value);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname = dgrSaleInvoice.SelectedRows[0].Cells["ItemDesc"].Value.ToString();
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr = Convert.ToDateTime(dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value);//Added on 28-May-2014
                        if ((dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value.ToString() == "-") | (dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value is DBNull) | (dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value.ToString() == DateTime.MinValue.ToString()) | (dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value.ToString() == Convert.ToDateTime("1/1/1900").ToString()) | (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr.ToString("yyyy") == "1900"))
                        {
                            if ((dgrSaleInvoice.SelectedRows[0].Cells["serialnumber"].Value.ToString().Trim() != "") && (dgrSaleInvoice.SelectedRows[0].Cells["serialnumber"].Value.ToString().Trim() != "0"))
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime("1/1/1900");
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr = Convert.ToDateTime("1/1/1900");
                                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = Convert.ToInt64(dgrSaleInvoice.SelectedRows[0].Cells["serialnumber"].Value);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = dgrSaleInvoice.SelectedRows[0].Cells["serialnumber"].Value.ToString();
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "true";
                            }
                            else
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.secondhand = "false";
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime("1/1/1900");
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr = Convert.ToDateTime("1/1/1900");
                            }
                        }
                        else
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dgrSaleInvoice.SelectedRows[0].Cells["ExpiryDate"].Value);
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr = Convert.ToDateTime(dgrSaleInvoice.SelectedRows[0].Cells["Newexpiry"].Value);

                        }
                        DataTable dt = new DataTable();
                        //   dt = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject_dal.get_stock_basedexpiry_invno();

                        List<SaleObject> lstStockBasedExpiryInv = objSaleInvoiceHelper.GetStockBaseExpiryInvNoHelper();
                        if (((lstStockBasedExpiryInv.Count > 0) && (lstStockBasedExpiryInv[0].ItemTotalStock.ToString() != string.Empty)) | ((lstStockBasedExpiryInv[0].ItemType == Convert.ToInt16(ItemType.Meals)) | (lstStockBasedExpiryInv[0].ItemType == Convert.ToInt16(ItemType.Labour))))
                        {
                            if (lstStockBasedExpiryInv[0].ItemTotalStock.ToString() != "")
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = float.Parse(lstStockBasedExpiryInv[0].ItemTotalStock.ToString());
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value);
                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid != null)
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.stock = float.Parse(dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value.ToString());
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(txtInvoiceNo.Text);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = Convert.ToInt64(dgrSaleInvoice.SelectedRows[0].Cells["salesid"].Value); //txt_invoice_number.Text;
                                if (dgrSaleInvoice.SelectedRows[0].Cells["ClientsID"].Value != null)
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(dgrSaleInvoice.SelectedRows[0].Cells["ClientsID"].Value.ToString());
                                if (dgrSaleInvoice.SelectedRows[0].Cells["saledetailid"].Value != null)
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = Convert.ToInt64(dgrSaleInvoice.SelectedRows[0].Cells["saledetailid"].Value.ToString());
                                if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno == null)
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.serialno = "0";
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.TotalPrice = Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["totalpric"].Value.ToString());
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["BarcodeNumber"].Value.ToString() != "" ? dgrSaleInvoice.SelectedRows[0].Cells["BarcodeNumber"].Value : 0);
                                if (objSaleInvoiceHelper.DeleteSaleItemHelper())
                                {
                                    deleteditem = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemname;
                                    int x = dgrSaleInvoice.SelectedRows[0].Cells["ItemNo"].RowIndex;
                                    Decimal clienttotal = 0;
                                    if (dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value.ToString() != "")
                                        //clienttotal = Convert.ToDecimal(Convert.ToDecimal(txtClientTotal.Text) - Convert.ToDecimal((Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value) * Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["Unitprices"].Value)).ToString("#####0.000")));commended By Meena.R
                                        clienttotal = Convert.ToDecimal(Convert.ToDecimal(txtClientTotal.Text) - Convert.ToDecimal((Convert.ToDecimal(dgrSaleInvoice.SelectedRows[0].Cells["totalpric"].Value))));
                                    if (clienttotal < 0)
                                        clienttotal = Convert.ToDecimal("0.000");
                                    txtClientTotal.Text = clienttotal.ToString("#####0.000");
                                    ///////***decreasing cost of invoice when deleteing an item********
                                    DataTable dtitem = new DataTable();
                                    //  dtitem = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject_dal.getitemcost();

                                    List<SaleObject> lstItemAvgCost = objSaleInvoiceHelper.GetItemAvgCostHelper();


                                    decimal totalcost = 0;
                                    decimal unitcost = 0;
                                    decimal itemcost = 0;
                                    int dataquant = 0;
                                    int Packquant = 1;
                                    if (lstItemAvgCost.Count > 0)
                                    {
                                        dataquant = Convert.ToInt16(dgrSaleInvoice.SelectedRows[0].Cells["Qty"].Value.ToString());
                                        Packquant = Convert.ToInt16(dgrSaleInvoice.SelectedRows[0].Cells["Package"].Value) != 0 ? Convert.ToInt16(dgrSaleInvoice.SelectedRows[0].Cells["Package"].Value) : Packquant;
                                        itemcost = lstItemAvgCost[0].AvgCost;
                                        //unitcost = itemcost / Packquant; // Commented on 19-May-2014
                                        unitcost = itemcost;// Added on 19-May-2014
                                        totalcost = dataquant * unitcost;
                                        if (txtTotalSaleValue.Text == "")
                                            txtTotalSaleValue.Text = "0";
                                        totalcost = Convert.ToDecimal(txtTotalSaleValue.Text) - totalcost;
                                        if (totalcost < 0)
                                            totalcost = Convert.ToDecimal("0.000");
                                        // txtTotalSaleValue.Text = totalcost.ToString("####0.000");
                                        txtTotalSaleValue.Text = (Math.Truncate(totalcost * 1000M) / 1000M).ToString("####0.000");
                                    }
                                    //***************
                                    //  dgrSaleInvoice.Rows.RemoveAt(x);
                                    /////////// dtSaleExtended.Rows.RemoveAt(x);///////////
                                    objSaleInvoiceHelper.lstSaleDetailExtended.RemoveAt(x);

                                    dgrSaleInvoice.AutoGenerateColumns = false;
                                    dgrSaleInvoice.DataSource = null;
                                    //dgrSaleInvoice.Refresh();
                                    dgrSaleInvoice.DataSource = objSaleInvoiceHelper.lstSaleDetailExtended;
                                    CalculateTotalInvoiceCost(objSaleInvoiceHelper.lstSaleDetailExtended);

                                    // dgrSaleInvoice.DataSource = dtSaleExtended;
                                    if (str != "All")
                                        GeneralFunction.Information("DeleteItem", "Sales Invoice");
                                }
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("FailedDeleteItem", "Sales Invoice");
                        }
                    }
                }
                else GeneralFunction.Information("FailedDeleteItem", "Sales Invoice");
            }
            else
            {
                GeneralFunction.Information("NotSelectRowtoDelete", "Sales Invoice");
            }

        }
        #endregion

        #endregion

        #region SetItem
        public void SetItem()
        {

            if (GeneralOptionSetting.FlagHidePriceChangingButton == "Y")
                btnPriceChangeF7.Visible = false;
            else
                btnPriceChangeF7.Visible = true;

            if (GeneralOptionSetting.FlagSale_DontUseExpiry == "Y")
            {
                dtpExpiry.Visible = false;
                lblExpiry.Visible = false;
            }
            else
            {
                dtpExpiry.Visible = true;
                lblExpiry.Visible = true;
                dtpExpiry.SelectedIndex = -1;
            }

            //Txt_discount.Visible = Lbl_Discount.Visible = radio_Value.Visible = radio_Percentage.Visible = (GeneralOptionSetting.FlagDisableDiscountFiled == "Y") ? false : true;
            //    txtDiscount.Enabled = lblDiscount.Enabled = radValue.Enabled = radPercentage.Enabled = ((UserScreenLimidations.Discount == "YES") && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false;



            if (GeneralOptionSetting.FlagShowSubTotalFiled == "Y")
            {
                txtClientTotal.Visible = true;
                btnReset.Visible = true;
            }
            else
            {
                txtClientTotal.Visible = false;
                btnReset.Visible = false;
            }

            if (GeneralOptionSetting.FlagShowInvoiceCostFiled == "Y")
            {
                chkShowHideInvoiceCost.Visible = true;
                //txtTotalSaleValue.Visible = true;
            }
            else
            {
                chkShowHideInvoiceCost.Visible = false;
                //txtTotalSaleValue.Visible = false;
                // txt_totalsalevalue.Visible = false;
            }
            //add by thamil for fix teh cost showing even if un check the cost check box
            txtTotalSaleValue.Visible = chkShowHideInvoiceCost.Visible && chkShowHideInvoiceCost.Checked ? true : false;
            txtTotalStock.Text = "";
        }
        #endregion

        #region GetItemName
        public void GetItemName()
        {

            DataTable dt = new DataTable();
            if (cmbItemNo.SelectedIndex > -1)
            {

                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt16(cmbItemNo.Text);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(cmbItemNo.SelectedValue);

                if (objSaleInvoiceHelper.GetItemNameForID() != "")
                {
                    cmbItem.Text = objSaleInvoiceHelper.GetItemNameForID();
                }

            }

        }
        #endregion

        #region ClientSelected
        public void ClientSelected()
        {
            if ((cmbClientNo.SelectedValue != null) && (cmbClientNo.SelectedValue.ToString() != "System.Data.DataRowView"))
                GetClientName();

        }
        #endregion

        #region GetClientName
        public void GetClientName()
        {


            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(cmbClientNo.Text);

            List<SaleObject> lstClientName = objSaleInvoiceHelper.GetClientNameHelper();
            if (lstClientName.Count > 0)
            {
                cmbClient.Text = "";

                cmbClient.ForeColor = System.Drawing.Color.Navy;

                cmbClient.Text = lstClientName[0].AgentName.ToString();

            }

        }
        #endregion

        #region ClientNameChange
        public void ClientNameChange()
        {
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch = "";

            if ((cmbClient.Text != "") && (cmbClient.Text != "System.Data.DataRowView"))
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.clientname = cmbClient.Text;

                List<SaleObject> lstClientNo = objSaleInvoiceHelper.GetClientNoHelper();

                if (lstClientNo.Count > 0)
                {
                    if (lstClientNo[0].branch.ToString() == "branch")
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch = "branch";
                    else
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.branch = "";

                    if (lstClientNo[0].AgentType.ToString() == "client")
                    {
                        cmbClient.ForeColor = System.Drawing.Color.Black;
                        cmbClient.Font = new System.Drawing.Font("Microsoft sans serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    else
                    {
                        cmbClient.ForeColor = System.Drawing.Color.Black;
                    }

                    cmbClientNo.Text = lstClientNo[0].ClientID.ToString();
                }
                else
                {
                    cmbClient.ForeColor = System.Drawing.Color.Black;
                    //cmbClientNo.SelectedValue = "";
                    cmbClientNo.Text = cmbClient.SelectedValue.ToString();

                }

            }
            else
            {
                cmbClientNo.Text = "";
                cmbClientNo.SelectedValue = "";
            }

        }
        #endregion

        #region Close Invoice

        #region ValidationCloseInvoice
        private Boolean ValidationCloseInvoice()
        {
            bool Validate = false;
            SetObjectFromControl();
            if (cmbClientNo.SelectedIndex < 0)
            {
                cmbClientNo.SelectedIndex = 0;
            }

            Validate = objSaleInvoiceHelper.ValidateCloseInv();

            return Validate;
        }
        #endregion
        #region DiscountAdjustment
        public void DiscountAdjustment()
        {

            //  Txt_discount.Text = ((Txt_discount.Text == string.Empty) || (Txt_discount.Text == ".")) ? "0.000" : Txt_discount.Text;
            //if(GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem!="Y")
            {
                decimal sum1 = 0;
                for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
                {
                    //sum1 = sum1 + ((Convert.ToDecimal(datagrid_saleinvoice.Rows[i].Cells["UnitPrice"].Value.ToString()) + Convert.ToDecimal(datagrid_saleinvoice.Rows[i].Cells["mtb_discount"].Value.ToString())) * Convert.ToDecimal(datagrid_saleinvoice.Rows[i].Cells["Quantity"].Value.ToString()));
                    sum1 = sum1 + ((Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString()) / Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["Package"].Value.ToString() == "0" ? 1 : dgrSaleInvoice.Rows[i].Cells["Package"].Value)) * Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["ActualPrices"].Value.ToString()));
                    if (dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString() != "")
                    {
                        float totalitemprice = 0.0f;
                        float itemtotalvalue = 0.0f;
                        totalitemprice = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString()) + float.Parse(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString());
                        dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value = 0;
                        dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = totalitemprice.ToString("#####0.000");
                        itemtotalvalue = (float.Parse(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString()) / float.Parse(dgrSaleInvoice.Rows[i].Cells["Package"].Value.ToString() == "0" ? "1" : dgrSaleInvoice.Rows[i].Cells["Package"].Value.ToString())) * float.Parse(dgrSaleInvoice.Rows[i].Cells["ActualPrices"].Value.ToString());

                        dgrSaleInvoice.Rows[i].Cells["totalpric"].Value = itemtotalvalue.ToString("######0.000");
                    }
                }
                txtNet.Text = float.Parse(sum1.ToString()).ToString("#####0.000");

            }
            objSaleInvoiceHelper.Discount1();
            txtNet.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NetText;
            if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem != "Y")
            {
                if (GeneralOptionSetting.FlagDevideDiscountBeforeClosingInvoice == "Y")
                {
                    DivideDiscountBeforeClosing();
                }
            }
        }
        #endregion

        #region DivideDiscountBeforeClosing
        private void DivideDiscountBeforeClosing()
        {

            float net = 0.0f;
            float totalpercentage = 0.0f;
            float itemunitprice = 0.0f;
            float itemunitprice1 = 0.0f;
            float itemdiscount = 0.0f;
            float itemtotalvalue = 0.0f;

            if ((txtDiscount.Text != "") && (txtDiscount.Text != "0.000") && (txtDiscount.Text != "0") && (txtTotal.Text != "") && (txtTotal.Text != "0.000") && (txtTotal.Text != "0"))
            {
                if (radValue.Checked == true)
                {

                    totalpercentage = (float.Parse(txtDiscount.Text) / float.Parse(txtTotal.Text)) * 100;
                    for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
                    {
                        if (dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString() != "")
                        {
                            float totalitemprice = 0.0f;
                            totalitemprice = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString()) + float.Parse(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString());
                            dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = totalitemprice.ToString("#####0.000");
                        }
                        itemunitprice1 = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString());
                        //***********Added on 9-May-14*********************************
                        Decimal TotalPer = (Convert.ToDecimal(txtDiscount.Text) / Convert.ToDecimal(txtTotal.Text)) * 100;
                        Decimal itemunprice1 = Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString());
                        Decimal itemunprice = itemunprice1 - (itemunprice1 * (Convert.ToDecimal(TotalPer.ToString()) / 100));
                        Decimal itemdiscnt = (itemunprice1 * (Convert.ToDecimal(TotalPer.ToString()) / 100));

                        dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value = itemdiscnt.ToString("#####0.000");
                        dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = itemunprice.ToString("#####0.000");
                        dgrSaleInvoice.Rows[i].Cells["totalpric"].Value = (itemunprice * Convert.ToInt16(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString())).ToString("#####0.000");
                        //*****************************************************************

                        //********************Commented on 9-May-14*********************************************
                        //itemunitprice = itemunitprice1 - (itemunitprice1 * (float.Parse(totalpercentage.ToString()) / 100));
                        //itemdiscount = (itemunitprice1 * (float.Parse(totalpercentage.ToString()) / 100));
                        //dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value = itemdiscount.ToString("#####0.000");
                        //dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = itemunitprice.ToString("#####0.000");
                        //itemtotalvalue = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString()) * float.Parse(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString());
                        //dgrSaleInvoice.Rows[i].Cells["totalpric"].Value = (float.Parse(dgrSaleInvoice.Rows[i].Cells["totalpric"].Value.ToString()) - (float.Parse(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString()) * float.Parse(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString()))).ToString("#####0.000");
                        //**************************************************************************************

                        net = net + float.Parse(dgrSaleInvoice.Rows[i].Cells["totalpric"].Value.ToString());

                    }
                }
                else
                {
                    totalpercentage = float.Parse(txtTotal.Text) * ((float.Parse(txtDiscount.Text) / 100));
                    for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
                    {
                        if (dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString() != "")
                        {
                            float totalitemprice = 0.0f;
                            totalitemprice = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString()) + float.Parse(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString());
                            dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = totalitemprice.ToString("#####0.000");
                        }

                        itemunitprice1 = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString());
                        itemunitprice = itemunitprice1 - (itemunitprice1 * (float.Parse(txtDiscount.Text) / 100));
                        itemdiscount = (itemunitprice1 * (float.Parse(txtDiscount.Text) / 100));
                        dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value = itemdiscount.ToString("#####0.000");
                        dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value = itemunitprice.ToString("#####0.000");
                        itemtotalvalue = float.Parse(dgrSaleInvoice.Rows[i].Cells["Unitprices"].Value.ToString()) * float.Parse(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString());
                        dgrSaleInvoice.Rows[i].Cells["totalpric"].Value = (float.Parse(dgrSaleInvoice.Rows[i].Cells["totalpric"].Value.ToString()) - (float.Parse(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString()) * float.Parse(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString()))).ToString("#####0.000");
                        net = net + float.Parse(dgrSaleInvoice.Rows[i].Cells["totalpric"].Value.ToString());
                    }
                }
                //Txt_net.Text = net.ToString("#####0.000");

            }


        }
        #endregion

        #region TaxCalculationOnEachItem
        public void TaxCalculationOnEachItem()
        {

            decimal totaltax = 0;
            totaltax = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.tax + objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.tax1;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netamount = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netamount + totaltax;
            txtNet.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netamount.ToString("#####0.000");
            decimal taxpercentage = 0, itemunitprice = 0, itemunitprice1 = 0, itemtax = 0;
            taxpercentage = (txtTotal.Text != "0.000") ? (Convert.ToDecimal(totaltax) / Convert.ToDecimal(txtTotal.Text)) * 100 : 0;
            decimal itemdisco = 0;
            decimal totaltaxofitem = 0;
            for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
            {
                itemdisco = Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["itemdisc"].Value.ToString()) * Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["Qty"].Value.ToString());
                itemunitprice1 = Convert.ToDecimal(dgrSaleInvoice.Rows[i].Cells["totalpric"].Value.ToString());
                itemunitprice = itemunitprice1 + ((itemunitprice1 + itemdisco) * (Convert.ToDecimal(taxpercentage.ToString()) / 100));
                itemtax = ((itemunitprice1 + itemdisco) * (Convert.ToDecimal(taxpercentage.ToString()) / 100));
                dgrSaleInvoice.Rows[i].Cells["totalpric"].Value = itemunitprice.ToString("######0.000");
                dgrSaleInvoice.Rows[i].Cells["taxes"].Value = itemtax;
                totaltaxofitem += itemtax;
            }


        }
        #endregion

        #region SaveSaleOnClose
        public void SaveSaleOnClose()
        {
            if (dgrSaleInvoice.BackgroundColor == Color.Gray)
            {
                GeneralFunction.Information("AlreadyInvoiceClosed", "Sales Invoice");
                return;
            }
            if (objSaleInvoiceHelper.CheckValues() == true)
            {
                //
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("SaleID", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("Discount", typeof(decimal));
                dtDetail.Columns.Add("TaxOfItem", typeof(decimal));
                dtDetail.Columns.Add("UserID", typeof(int));
                dtDetail.Columns.Add("CreatedDate", typeof(DateTime));
                dtDetail.Columns.Add("SaleDetailID", typeof(int));
                dtDetail.Columns.Add("ItemID", typeof(int));
                //

                int n = dgrSaleInvoice.Rows.Count;
                int[] j = new int[n];
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.note = txtNote.Text;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.paymentCharges = decimal.Parse(txtPaymentCharges.Text);
                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.paymentCharges = Convert.ToDecimal(txtPaymentCharges.Text == null ? "0" : txtPaymentCharges.Text);

                for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.salecloseid = dgrSaleInvoice.Rows[0].Cells["salesid"].Value.ToString();
                    if (i == 0)
                        goto start;
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.salecloseid != dgrSaleInvoice.Rows[i].Cells["salesid"].Value.ToString())
                    {
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.salecloseid = dgrSaleInvoice.Rows[i].Cells["salesid"].Value.ToString();
                            goto begin;
                        }
                    }
                    else
                    {
                        goto end;
                    }

                    start: i = 0;
                    begin: objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = Convert.ToInt64(dgrSaleInvoice.Rows[i].Cells["salesid"].Value.ToString());
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID = Convert.ToInt16(cmbClientNo.Text);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.accountid = Convert.ToInt16(CommonHelper.CashClientID.ID);


                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(txtInvoiceNo.Text);

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime = Convert.ToDateTime(dtpDate.Value);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime.AddHours(DateTime.Now.TimeOfDay.Hours - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime.TimeOfDay.Hours);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime.AddMinutes(DateTime.Now.TimeOfDay.Minutes - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime.TimeOfDay.Minutes);


                    if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y")
                    {
                        DiscountAdjustment();
                        if (GeneralOptionSetting.FlagDevideDiscountBeforeClosingInvoice != "Y")
                            DivideDiscountBeforeClosing();
                    }
                    if ((GeneralOptionSetting.FlagDevideDiscountBeforeClosingInvoice != "Y") & (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem != "Y"))
                    {
                        DiscountAdjustment();
                        DivideDiscountBeforeClosing();

                    }

                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.paymentCharges = decimal.Parse(txtPaymentCharges.Text);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.gross = float.Parse(txtTotal.Text);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netamount = Convert.ToDecimal(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.gross - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.netAmountPaymentcharges = Convert.ToDecimal((objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.gross + Convert.ToDouble(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.paymentCharges)) - objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discount);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.status = 2;    //"CI".Trim();
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.createdby = GeneralFunction.UserId;
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.modifiedby = GeneralFunction.UserId;
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.SaleType = 1;
                    objSaleInvoiceHelper.Taxcalculation();
                    TaxCalculationOnEachItem();
                    if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype == null) objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.discounttype = 1; //"V";
                    //if (obj_saleinvoice_dal.savesale_m() > 0)
                    if (POS_Screen.selectedPaymentType == "card")
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID = 2;
                    }
                    else if (POS_Screen.selectedPaymentType == "check")
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID = 3;
                    }
                    else
                    {
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.receive_paymenttypeID = 1;
                    }
                    if (objSaleInvoiceHelper.SaveSalesOnCloseHelper())
                    {
                        int inst = 0;
                        for (int ij = 0; ij < dgrSaleInvoice.Rows.Count; ij++)
                        {
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id = 0;
                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid == Convert.ToInt64(dgrSaleInvoice.Rows[ij].Cells["salesid"].Value.ToString()))
                            {
                                //*************Insertion of values into "SaleDetails"************
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid = Convert.ToInt64(dgrSaleInvoice.Rows[ij].Cells["saledetailid"].Value.ToString());
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.batchid = 1;
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(dgrSaleInvoice.Rows[ij].Cells["ItemNo"].Value);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.quantity = Convert.ToInt32(dgrSaleInvoice.Rows[ij].Cells["Qty"].Value);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price = Convert.ToDecimal(dgrSaleInvoice.Rows[ij].Cells["Unitprices"].Value);
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.status = 2;// "CI";
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.id = 0;
                                if ((dgrSaleInvoice.Rows[ij].Cells["itemdisc"].ToString() != "") && (dgrSaleInvoice.Rows[ij].Cells["itemdisc"].Value != null))
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemdiscount = float.Parse(dgrSaleInvoice.Rows[ij].Cells["itemdisc"].Value.ToString());
                                else
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemdiscount = 0.0f;
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr = Convert.ToDateTime(dgrSaleInvoice.Rows[ij].Cells["ExpiryDate"].Value.ToString());//Added on 28-May-2014
                                if (dgrSaleInvoice.Rows[ij].Cells["ExpiryDate"].Value is DBNull | dgrSaleInvoice.Rows[ij].Cells["ExpiryDate"].Value.ToString() == DateTime.MinValue.ToString() | dgrSaleInvoice.Rows[ij].Cells["ExpiryDate"].Value.ToString() == Convert.ToDateTime("1/1/1900").ToString() | objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Newexpr.ToString("yyyy") == "1900")
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime("1/1/1900");
                                else
                                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.expiry = Convert.ToDateTime(dgrSaleInvoice.Rows[ij].Cells["ExpiryDate"].Value.ToString());
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.taxofitem = (dgrSaleInvoice.Rows[ij].Cells["taxes"].Value.ToString() != "") ? Convert.ToDecimal(dgrSaleInvoice.Rows[ij].Cells["taxes"].Value.ToString()) : 0;
                                dtDetail.Rows.Add(objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.price,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemdiscount,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.taxofitem,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.createdby,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.invoicetime,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saledetid,
                                  objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid
                                  );
                                //if (objSaleInvoiceHelper.SaveSaleDetailsOnClosingHelper())
                                //    inst = 1;
                                //else
                                //    inst = 0;
                            }
                        }
                        if (objSaleInvoiceHelper.SaveSaleDetailOnCloseDT(dtDetail))
                            inst = 1;
                        else
                            inst = 0;

                        if (inst == 1)
                        {

                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.net = Convert.ToDecimal(txtNet.Text != "" ? txtNet.Text : "0.000"); //Added on 24-June-2014 for Testing 
                            txtDiscount.Enabled = radPercentage.Enabled = radValue.Enabled = false;
                            dgrSaleInvoice.BackgroundColor = System.Drawing.Color.Gray;
                            dgrSaleInvoice.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;

                            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ClientID == Convert.ToInt16(CommonHelper.CashClientID.ID))
                            {
                                //---------------implemented teh receive receipt functionality for  cash client --------------
                                objSaleInvoiceHelper.GetMaxIDOFReceiptDetails();
                                //------------------------------------------------------------------------
                            }
                            lblUser.Visible = lblUserName.Visible = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? true : false;
                            lblUser.Text = GeneralFunction.UserName + " " + dtpDate.Value.ToShortTimeString();
                            //Need to Uncomment // invoicenochange();
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv;
                            DisplayInvoiceDetailsBasedOnInvNo();
                            if (GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y")
                            {
                                PrintFucntion();
                            }

                            CashDrawer objcashdraw = new CashDrawer();
                            objcashdraw.OpenCashDrawer();
                            if (GeneralOptionSetting.FlagOpenInvioceAfterClosing == "Y")
                            {
                                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv = Convert.ToInt64(txtInvoiceNo.Text);

                                //------This is added to open new Invoice if FlagOpenInvioceAfterClosing is set to true
                                int count = objSaleInvoiceHelper.CheckEmptyInvoiceHelper();
                                if (count == 0)
                                {
                                    btnNewInvoice_Click(null, null);
                                    cmbItem.Focus();
                                }

                            }

                        }
                        else
                        {
                            GeneralFunction.Information("FailedInsertValue", "Sales Invoice");
                            txtDiscount.Enabled = radPercentage.Enabled = radValue.Enabled = ((UserScreenLimidations.GeneralDiscount) && (GeneralOptionSetting.FlagDisableDiscountFiled != "Y")) ? true : false;
                            dgrSaleInvoice.BackgroundColor = System.Drawing.Color.Beige;  //''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                            //dgrSaleInvoice.BackgroundColor = System.Drawing.Color.WhiteSmoke; 
                        }
                    }

                    end:;
                }

            }

        }
        #endregion

        #region CloseMethod
        private void CloseMethod()
        {

            radPercentage.Enabled = true;
            radValue.Enabled = true;
            //Need to Uncomment  Grb_ItemInformation.Visible = false;
            objSaleInvoiceHelper.AgentDiscountCalc();
            txtDiscount.Text = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DiscountText != "") ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.DiscountText : txtDiscount.Text;
            radPercentage.Checked = (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PercentageChecked == true) ? objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PercentageChecked : radPercentage.Checked;
            if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
            {
                if (GeneralFunction.Question("AlertCloseInvoice", "Sales Invoice") == DialogResult.Yes)
                {
                    SaveSaleOnClose();
                }
            }
            else
                SaveSaleOnClose();

        }
        #endregion






        #endregion

        #region PriceClick
        private void PriceClick()
        {
            radPercentage.Enabled = true;
            radValue.Enabled = true;
            SetObjectFromControl();
            objSaleInvoiceHelper.PriceClick();
            txtPrice.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.PriceText;
            boxprice = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BoxPrice;
        }
        #endregion

        #region ColumnAdd
        private DataTable ColumnAdd(ref DataTable dt)
        {
            dt.Columns.Clear();
            dt.Columns.Add("ItemNo");
            dt.Columns.Add("Description");
            dt.Columns.Add("Expiry");
            dt.Columns.Add("Package");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Total");
            dt.Columns.Add("Time");
            dt.Columns.Add("User");
            dt.Columns.Add("Returned");
            dt.Columns.Add("Agent");
            dt.Columns.Add("SaledetId");
            dt.Columns.Add("SaleId");
            dt.Columns.Add("Discount");
            dt.Columns.Add("SerialNo");
            dt.Columns.Add("ItemType");
            dt.Columns.Add("IsExpiry");
            dt.Columns.Add("ReOrder");
            dt.Columns.Add("MinimumPrice");
            dt.Columns.Add("WholeSale");
            dt.Columns.Add("IsHide");
            dt.Columns.Add("MaxOrder");
            dt.Columns.Add("Barcode");
            dt.Columns.Add("ItemCost");
            dt.Columns.Add("CompName");
            dt.Columns.Add("CategoryName");
            dt.Columns.Add("AdditionalBarcode");
            dt.Columns.Add("ItemPlace");
            dt.Columns.Add("SalePrice");
            dt.Columns.Add("IsPackage");
            return dt;
        }
        #endregion

        #region AddNewAgent
        private void AddNewAgent()
        {
            bool value = false;

            if (cmbClient.SelectedIndex == -1)
            {
                if (GeneralFunction.Question("Do you Want To Save New User", "Sales Invoice") == DialogResult.Yes)
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = cmbClient.Text;
                    if (objSaleInvoiceHelper.SaveNewAgent())
                    {
                        cmbClient.DataSource = null;
                        cmbClientNo.DataSource = null;
                        AssignClientDataSource();
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
                else
                    value = false;
            }



        }
        #endregion

        #region AssignClientDataSource
        private void AssignClientDataSource()
        {
            objSaleInvoiceHelper.LoadClientDetails();
            cmbClient.SelectedIndexChanged -= new EventHandler(this.cmbClient_SelectedIndexChanged);
            cmbClientNo.SelectedIndexChanged -= new EventHandler(this.cmbClientNo_SelectedIndexChanged);
            //cmbClientNo.DataSource = null;
            // cmbClient.DataSource = null;
            //objSaleInvoiceHelper.lstClientList;
            //cmbClient.SelectedIndex = -1;
            cmbClientNo.DisplayMember = "AgentId";
            cmbClientNo.ValueMember = "Name";
            objSaleInvoiceHelper.ClientDetails.DefaultView.Sort = "AgentId" + " " + "ASC";// objSaleInvoiceHelper.lstClientList.OrderBy(a => a.AgentId).ToList();
            cmbClientNo.DataSource = objSaleInvoiceHelper.ClientDetails.DefaultView.ToTable();
            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "AgentId";
            cmbClient.DataSource = objSaleInvoiceHelper.ClientDetails;
            cmbClient.SelectedIndexChanged += new EventHandler(this.cmbClient_SelectedIndexChanged);
            cmbClientNo.SelectedIndexChanged += new EventHandler(this.cmbClient_SelectedIndexChanged);

        }
        #endregion

        #region ResetFunction
        private void ResetFunc()
        {

            radPercentage.Enabled = true;
            radValue.Enabled = true;
            txtClientTotal.Text = "0";


        }
        #endregion

        #region GetNewYearReceiptNo
        private void GetNewYearReceiptNo()
        {
            if (txtNewInvoiceNo.Text.Contains('-'))
            {
                string[] strNewYearNo = txtNewInvoiceNo.Text.Split('-');
                if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
                {
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Year = Convert.ToInt32(strNewYearNo[0]);
                    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.YearSequenceNo = Convert.ToInt32(strNewYearNo[1]);
                }
                else
                { GeneralFunction.ErrInfo("Invoice ID Not in Correct format", "Sales Invoice"); }
            }
            else
            {
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.Year = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CurrentYear;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.YearSequenceNo = Convert.ToInt64(txtNewInvoiceNo.Text);
            }
        }
        #endregion

        #region GetInvoiceDetails
        private void GetInvoiceDetails()
        {

            GetNewYearReceiptNo();
            objSaleInvoiceHelper.IDFlag = 0;
            objSaleInvoiceHelper.NavigationEvent();
            if (objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv.ToString() != "0")
            {
                txtInvoiceNo.Text = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv.ToString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.InvoiceNumber = objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleinv;
                DisplayInvoiceDetailsBasedOnInvNo();
            }
            else
            {
                GeneralFunction.Information("InvalidInvoiceNo", "Sales Invoice");
            }
        }
        #endregion

        #region ItemInfo
        private void ItemInfo()
        {
            if (objSaleInvoiceHelper.ObjItemInfo.Visible == false)
            {
                if (cmbItem.Text != string.Empty && cmbItem.Text != null)
                {
                    objSaleInvoiceHelper.ObjItemInfo.ItemNo = Convert.ToInt32(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
                    objSaleInvoiceHelper.ObjItemInfo.ItemName = cmbItem.Text;
                    objSaleInvoiceHelper.ObjItemInfo.ShowDialog();
                }
                else
                {
                    if (dgrSaleInvoice.SelectedRows.Count > 0)
                    {
                        objSaleInvoiceHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgrSaleInvoice.SelectedRows[0].Cells["ItemNo"].Value);
                        objSaleInvoiceHelper.ObjItemInfo.ItemName = dgrSaleInvoice.SelectedRows[0].Cells["ItemDesc"].Value.ToString();
                        objSaleInvoiceHelper.ObjItemInfo.ShowDialog();
                    }
                }

            }
        }
        #endregion

        #region blinkTextbox
        private void blinkTextbox(object sender, EventArgs e)
        {

            try
            {
                GeneralFunction.BlinkText(EventArgs.Empty, rtxtNotesAndAlerts);
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "blinkTextbox");
            }
        }
        #endregion

        #region PrintFucntion
        private void PrintFucntion()
        {
            if (Chk_PrintCashClientName.Checked && cmbClientNo.Text == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
            {
                if (GeneralFunction.Question("Do You Want To Print The Cash Client Name", "Cash Client Name") == DialogResult.Yes)
                {
                    CheckCashClientName = 1;
                    ExportMessage exportmessage = new ExportMessage();
                    exportmessage.Text = GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name");
                    exportmessage.Tag = "Cash Client Name";
                    exportmessage.ExportMessagePannel.SendToBack();
                    exportmessage.lblMessage.Visible = false;
                    exportmessage.rbnActualCost.Visible = false;
                    exportmessage.rbnSamePrice.Visible = false;
                    exportmessage.ShowDialog();
                    if (GeneralFunction.CashClientName == string.Empty)
                    { GeneralFunction.Information("CashClientNameisRequired", "CashClientName"); return; }
                }
            }
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.NotesText = txtNote.Text;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.ChkNoteChecked = chkNote.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.HideLogChecked = chkHideLogo.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.HideDebtChecked = chkHideDebt.Checked;
            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.IncludeTaxChecked = chkIncludeTax.Checked;
            objSaleInvoiceHelper.CheckPrint(dgrSaleInvoice);
            GeneralFunction.CashClientName = string.Empty;
            CheckCashClientName = 0;
        }
        #endregion

        #endregion

        #region Barcode Scanning

        #region Timer Tick Event
        bool isBarcodeScan = false;
        //private void tmrBarcode_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ScannerCount += 1;
        //        if (lastFocusedControl != null)
        //        {
        //            lastFocusedControl.Text = lastfocusedvalue;
        //            lastFocusedControl = null;
        //        }
        //        if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
        //        {
        //            string barcode = Convert.ToString(txtBarcode.Text);

        //            if (ScanValue != "" & ScanValue.Length > 1)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            barcode = barcode.Replace("\r", "");
        //            barcode = barcode.Replace("~", "");
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;


        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                //obj_saleinvoice.itemid = dtBarcode.Rows[0]["MTB_ITEM_ID"].ToString();
        //                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(dtBarcode.Rows[0]["ItemID"]);
        //                DataTable dt = new DataTable();
        //                List<SaleObject> iteminfo = objSaleInvoiceHelper.GetItemNameInfoHelper();
        //                if (((iteminfo[0].ItemTotalStock.ToString() != string.Empty) && ((iteminfo[0].ItemTotalStock) > 0)) | (((iteminfo[0].ItemType == 4) | (iteminfo[0].ItemType == 3))))
        //                {
        //                    cmbItem.SelectedIndex = -1;
        //                    txtQuantity.Text = "1";
        //                    txtPrice.Text = "0.000";
        //                    txtRemaining.Text = "0";
        //                    txtPackage.Text = "1";
        //                    dtpExpiry.Text = "";
        //                    txtTotalStock.Text = "0";
        //                    cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                    ClearBarcodeValues();
        //                    txtQuantity.Text = (txtQuantity.Text == string.Empty) ? "1" : txtQuantity.Text;
        //                    txtQuantity.SelectAll();
        //                    txtQuantity.Focus();
        //                    txtQuantity.SelectAll();
        //                    cmbPackageQty.Text = dtBarcode.Rows[0]["PackageQty"].ToString();

        //                    if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "Y")
        //                    {
        //                        //Insert();
        //                        InsertItemttoGrid();
        //                    }
        //                    ClearBarcodeValues();///include tthis method to clear the barcode value

        //                }
        //                else
        //                {
        //                    ClearBarcodeValues();
        //                    GeneralFunction.Information("NoQtyPurchaseIt", "Sales Invoice");
        //                    cmbItem.SelectAll();
        //                    cmbItem.Focus();
        //                    txtQuantity.Text = "1";

        //                }


        //            }
        //            else
        //            {

        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "Sales Invoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                    }

        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "Sales Invoice");
        //                    // cmbItem.SelectAll();
        //                    // cmbItem.Focus();
        //                    ClearBarcodeValues();
        //                }
        //            }

        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //        }
        //        KeyboardmaxCount = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        //GeneralFunction.ErrMsg(this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "timer1_Tick");
        //    }
        //    finally
        //    {
        //        isBarcodeScan = false;
        //    }

        //}


        private void tmrBarcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null)
                {
                    lastFocusedControl.Text = lastfocusedvalue;
                    lastFocusedControl = null;
                }
                if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
                {
                    tmrBarcode.Enabled = false;
                    string barcode = Convert.ToString(txtBarcode.Text);
                    //if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
                    //{
                    //    barcode = ScanValue + barcode;
                    //}

                    if (barcode.Length < 12)
                    {
                        barcode = ScanValue + barcode;
                        if (barcode.Trim().Length != 13)//added By Meena.R on 14Jan2015 if  we can continue it shown not available lastfocus control value no add
                        {
                            barcode = lastfocusedvalue + ScanValue + Convert.ToString(txtBarcode.Text);
                        }
                    }

                    // DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim()); //Commented for Performance Tuning on 19-Nov-2014 by Seenivasan

                    //*********Commented for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    //obj_saleinvoice.itemid = dtBarcode.Rows[0]["MTB_ITEM_ID"].ToString();
                    //    objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(dtBarcode.Rows[0]["ItemID"]);
                    //    DataTable dt = new DataTable();
                    //    List<SaleObject> iteminfo = objSaleInvoiceHelper.GetItemNameInfoHelper();
                    //    if (((iteminfo[0].ItemTotalStock.ToString() != string.Empty) && ((iteminfo[0].ItemTotalStock) > 0)) | (((iteminfo[0].ItemType == 4) | (iteminfo[0].ItemType == 3))))
                    //    {
                    //        cmbItem.SelectedIndex = -1;
                    //        txtQuantity.Text = "1";
                    //        txtPrice.Text = "0.000";
                    //        txtRemaining.Text = "0";
                    //        txtPackage.Text = "1";
                    //        dtpExpiry.Text = "";
                    //        txtTotalStock.Text = "0";
                    //        cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //        ClearBarcodeValues();
                    //        txtQuantity.Text = (txtQuantity.Text == string.Empty) ? "1" : txtQuantity.Text;
                    //        txtQuantity.SelectAll();
                    //        txtQuantity.Focus();
                    //        txtQuantity.SelectAll();
                    //        cmbPackageQty.Text = dtBarcode.Rows[0]["PackageQty"].ToString();

                    //        if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "Y")
                    //        {
                    //            //Insert();
                    //            InsertItemttoGrid();
                    //        }
                    //        ClearBarcodeValues();///include tthis method to clear the barcode value
                    //    }
                    //    else
                    //    {
                    //        ClearBarcodeValues();
                    //        GeneralFunction.Information("NoQtyPurchaseIt", "Sales Invoice");
                    //        cmbItem.SelectAll();
                    //        cmbItem.Focus();
                    //        txtQuantity.Text = "1";
                    //    }
                    //}
                    //*********************************************************************************************
                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            //obj_saleinvoice.itemid = dtBarcode.Rows[0]["MTB_ITEM_ID"].ToString();
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt32(row1["ItemID"]);
                            DataTable dt = new DataTable();
                            List<SaleObject> iteminfo = objSaleInvoiceHelper.GetItemNameInfoHelper();
                            if (iteminfo.Count > 0)
                            {
                                if (((iteminfo[0].ItemTotalStock.ToString() != string.Empty) && ((iteminfo[0].ItemTotalStock) > 0)) | (((iteminfo[0].ItemType == 4) | (iteminfo[0].ItemType == 3))))
                                {
                                    cmbItem.SelectedIndex = -1;
                                    txtQuantity.Text = "1";
                                    txtPrice.Text = "0.000";
                                    txtRemaining.Text = "0";
                                    txtPackage.Text = "1";
                                    dtpExpiry.Text = "";
                                    txtTotalStock.Text = "0";
                                    cmbItem.Text = row1["ItemName"].ToString();
                                    ClearBarcodeValues();
                                    txtQuantity.Text = (txtQuantity.Text == string.Empty) ? "1" : txtQuantity.Text;
                                    txtQuantity.SelectAll();
                                    txtQuantity.Focus();
                                    txtQuantity.SelectAll();
                                    cmbPackageQty.Text = row1["PackageQty"].ToString();

                                    if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "Y")
                                    {
                                        //Insert();
                                        InsertItemttoGrid();
                                    }
                                    ClearBarcodeValues();///include tthis method to clear the barcode value
                                }
                                else
                                {
                                    ClearBarcodeValues();
                                    GeneralFunction.Information("NoQtyPurchaseIt", "Sales Invoice");
                                    cmbItem.SelectAll();
                                    cmbItem.Focus();
                                    txtQuantity.Text = "1";
                                }
                            }
                        }
                    }
                    //*********************************************************************************************
                    else
                    {

                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "Sales Invoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                                LoadNewItems();
                            }
                            ClearBarcodeValues();
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "Sales Invoice");
                            // cmbItem.SelectAll();
                            // cmbItem.Focus();
                            ClearBarcodeValues();
                        }
                    }

                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
                }
                KeyboardmaxCount = 0;
            }
            catch (Exception ex)
            {
                tmrBarcode.Enabled = false;
                ClearBarcodeValues();
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
                throw ex;
            }

        }
        #endregion

        void ClearBarcodeValues()
        {
            ScanLetterStartTime = DateTime.Now;
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            isBarcodeScan = false;
        }

        private void LoadNewItems()
        {
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }


        #endregion

        private void dgrSaleInvoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dgrSaleInvoice.Rows[e.RowIndex].Selected = true;
                //  SetLastRowColor();
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "dgrSaleInvoice_RowsAdded");
            }
        }

        public void SetLastRowColor()
        {
            for (int i = 0; i < dgrSaleInvoice.Rows.Count; i++)
            {
                dgrSaleInvoice.Rows[i].Selected = false;
                //dgrSaleInvoice.Rows[i].DefaultCellStyle.BackColor = Color.White;
                //if (dgrSaleInvoice.Rows[i].Cells[2].Value.ToString() == ComboItemName)
                //    DgvPerInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                dgrSaleInvoice.Rows[dgrSaleInvoice.Rows.Count - 1].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            }


        }

        //Added on 23-June-2014 for Avoiding Performance issue
        //private void cmbCompany_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        ((ComboBox)sender).DroppedDown = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbCompany_KeyDown");
        //    }
        //}
        //Added on 23-June-2014 for Avoiding Performance issue
        //private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        ((ComboBox)sender).DroppedDown = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbCategory_KeyDown");
        //    }
        //}

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                tmrBarcode.Enabled = true;

                //if (e.KeyCode == Keys.Enter)
                //{
                //    txtQuantity.Focus();
                //    txtQuantity.SelectAll();
                //}
            }
            catch (Exception ex)
            {
                // GeneralFunction.ErrMsg(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "txtBarcode_KeyUp");
            }

        }

        private void btnReturnIQuicktem_Click(object sender, EventArgs e)
        {
            ReturnOrderPopUp retrunorderpopup = new ReturnOrderPopUp();
            retrunorderpopup.ShowDialog();
        }

        private void cmbClient_Leave(object sender, EventArgs e)
        {
            //if ((cmbItem.Items.Count < 1) && (cmbClient.SelectedValue.ToString() == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()))
            if (cmbClient.SelectedValue == null)
            {
                if (cmbClientNo.Text != "")
                    cmbClientNo.Text = "";
                cmbItem_SelectedIndexChanged(sender, e);
            }

        }

        private void lblTotalStock_Click(object sender, EventArgs e)
        {

        }

        private void lblQty_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void dgrSaleInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{

        //    try
        //    {
        //        if (this.ActiveControl.Name == "txtBarcode") return;

        //        if (this.ActiveControl.Name == "txtBarcode")
        //        {
        //            ScanValue = string.Empty;
        //            return;
        //        }
        //        if (ScanValue == string.Empty || ScanValue.Length == 0)
        //        {
        //            //Enable to Timecheck
        //            ScanTimingCheck = true;
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            return;
        //        }
        //        ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //        if (ScanTimingCheck && ScanValue.Length < 7)
        //        {
        //            if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //                KeyboardmaxCount = 0; return;
        //            }
        //            if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //                KeyboardmaxCount = KeyboardmaxCount + 1;
        //            }
        //            else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //            }
        //            else
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //                KeyboardmaxCount = 0; return;
        //            }
        //        }
        //        if (ScanValue.Length == 6)
        //        {
        //            qtyEnter = false;
        //            lastFocusedControl = this.ActiveControl;
        //            if (lastFocusedControl != null)
        //            { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }
        //            // txtBarcode.Text = ScanValue;
        //            txtBarcode.Focus();

        //            //e.Handled = true;
        //        }



        //        base.OnKeyPress(e);
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " OnKeyPress Event");
        //    }
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (this.ActiveControl.Name == "txtBarcode") return;

                if (ScanValue == string.Empty || ScanValue.Length == 0)
                {
                    //Enable to Timecheck
                    ScanTimingCheck = true;
                    ScanLetterStartTime = DateTime.Now;
                    ScanValue = ScanValue + e.KeyChar.ToString();
                    KeyboardmaxCount = 0;
                    return;
                }
                ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
                if (ScanTimingCheck && ScanValue.Length < 7)
                {
                    //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
                    if (KeyboardmaxCount > 4 && ScanValue.Length > 1)
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                    //if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
                    if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds < GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                        KeyboardmaxCount = KeyboardmaxCount + 1;
                    }
                    else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                    }
                    else
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                }
                if (ScanValue.Length == 6)
                {
                    lastFocusedControl = this.ActiveControl;
                    if (lastFocusedControl != null)
                    { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

                    txtBarcode.Focus();
                    //e.Handled = true;
                }
                //Cal Event Again
                base.OnKeyPress(e);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " OnKeyPress Event");
            }
        }

        private void cmbItem_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyValue == 13)
                {
                    if (cmbItem.SelectedIndex > -1)
                    {
                        txtQuantity.Focus();
                        txtQuantity.SelectAll();
                    }
                }
                //if (((int)e.KeyValue == 13) || (e.KeyCode == Keys.Tab))
                //if (((int)e.KeyValue == 13 && qtyEnter == false))
                //{
                //    //if (!isfromPiece)
                //    txtBarcode.Focus();
                //    //else
                //    //    isfromPiece = false;
                //}
                //else
                //{
                //    qtyEnter = false;
                //}
                // MessageBox.Show(e.KeyData.ToString());
                //if ((int.Parse(e.KeyValue.ToString()) == 192)) // 192 == ~
                //{
                //    //if (cmbItem.SelectedIndex > -1)
                //    //{
                //    if (((ComboBox)sender).Name == "cmbItem")
                //        cmbItem.AutoCompleteMode = AutoCompleteMode.None;
                //    //txtQuantity.Focus();
                //    //txtQuantity.Select(0, txtQuantity.Text.Length);

                //    cmbItem.DroppedDown = false;
                //    cmbItem.AutoCompleteMode = AutoCompleteMode.None;
                //    isBarcodeScan = true;
                //    cmbItem.Text = "";
                //    txtBarcode.Focus();

                //    if (isSuggFirst)
                //    {
                //        cmbItem_SelectedIndexChanged(null, null);
                //        isSuggFirst = false;
                //    }
                //    //if (cmbItem.SelectedIndex > -1)
                //    //{
                //    //    txtQuantity.Focus();
                //    //    txtQuantity.Select(0, txtQuantity.Text.Length);
                //    //}

                //    // }

                //}
                //else //Added on 23-June-2014 for Avoiding Performance issue  //Changed Condition By Meena.R on 13Aug2014 to Change the DropDown Suggested Append
                //{
                //    //if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode!=Keys.Shift)&&(e.KeyCode!=Keys.ShiftKey))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
                //    //{
                //    //     if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //    //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //    //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //    //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //    //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin))
                //    //     {
                //    //         if (((ComboBox)sender).DroppedDown == true)
                //    //             ((ComboBox)sender).DroppedDown = false;
                //    //         if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //    //         {

                //    //             cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                //    //             cmbItem.SelectedText = ((char)e.KeyValue).ToString();
                //    //             cmbItem.DroppedDown = true;
                //    //             isFirst = true;
                //    //             appval = ((char)e.KeyValue).ToString();
                //    //             //cmbItemName.SelectionStart = 1;
                //    //             isSuggFirst = true;
                //    //         }
                //    //         else
                //    //         {
                //    //             cmbItem.DroppedDown = false;
                //    //             if (isFirst)
                //    //             {
                //    //                 cmbItem.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //    //                 isFirst = false;
                //    //             }
                //    //             isSuggFirst = false;
                //    //         }
                //    //     }
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbItem_KeyDown");
            }

        }

        private void Sales_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == "cmbCategory")
            {
                if ((cmbCategory.Text.Trim() != string.Empty && cmbCategory.SelectedIndex == -1) || cmbCategory.Text == string.Empty)
                {
                    cmbCategory.SelectedValue = 1001;
                }
            }
            else
            {
                if ((cmbCompany.Text.Trim() != string.Empty && cmbCompany.SelectedIndex == -1) || cmbCompany.Text == string.Empty)
                {
                    cmbCompany.SelectedValue = 1001;
                }
            }
        }
        private void CalculateTotalInvoiceCost(List<SaleObject> lstSaleList)
        {
            decimal tot = 0;
            if (lstSaleList == null)
                txtTotalSaleValue.Text = "0.00";
            else
            {
                if (lstSaleList.Count > 0)
                {
                    for (int i = 0; i <= lstSaleList.Count - 1; i++)
                    {
                        tot += Convert.ToDecimal(lstSaleList[i].ItemCost * (lstSaleList[i].quantity != 0 ? lstSaleList[i].quantity : 1));
                    }
                }
                txtTotalSaleValue.Text = tot.ToString();
                //txtTotalSaleValue.Text = (Math.Truncate(Convert.ToDecimal(lstSaleList.Sum(a => a.Totalcost)) * 1000M) / 1000M).ToString("####0.000");
            }
        }
    }
}
