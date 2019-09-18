using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

//using System.Xml;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
//using System.IO;
//using System.Collections;
//using HSB_ObjectHelper;
////using HSB_DataHelper;
////using AlmaqarPOS.CrystalReports.EnglishReports;
////using CustomResolution;
using System;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;
using System.Threading;
using System.Globalization;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Report : Form, IDisposable
    {
        #region "Variables"


        string TabPageName = string.Empty;
        bool CheckRadioButton = false;
        ReportHelper reporthelper;
        ReportObjectClass reportobject;
        System.Data.DataSet ds_Details;
        String SelectedOption = string.Empty;

        Boolean IsFormLoad = false;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        DataTable dtallBarcode;
        public static bool  isAllDateSelected { set; get; }
        public ReportDocument RptDoc;





        #region "Constructor"
        #endregion

        public Report()
        {
            //GeneralFunction.Trace("Report Const Start");
            IsFormLoad = true;
            InitializeComponent();
            SetLanguages();
            setFont();
            DisableAllControls();
            reportobject = new ReportObjectClass();
            //GeneralFunction.Trace("reporthelper init Start");
            reporthelper = new ReportHelper(reportobject);
            //GeneralFunction.Trace("reporthelper init ENd");

            Dtp_FromDate.Value = DateTime.Now;
            // Dtp_FromDate.MaxDate = DateTime.Today;//Commented on 27-June-2014 by Seenivasan ->  Date should show all future dates .it should not restrict only till today date
            Dtp_ToDate.Value = DateTime.Now;
            //Dtp_ToDate.MaxDate = DateTime.Today; //Commented on 27-June-2014 by Seenivasan ->  Date should show all future dates .it should not restrict only till today date
            IsFormLoad = false;
            //GeneralFunction.Trace("Report Const End");
        }


        #endregion

        DataTable dt = new DataTable();

        #region "Form Load Event"

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                Cmb_Item.MatchingMethod = StringMatchingMethod.UseRegexs;
                //GeneralFunction.Trace("Report Load Start");
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                Dtp_ToDate.Format = DateTimePickerFormat.Custom;
                Dtp_FromDate.Format = DateTimePickerFormat.Custom;

                Dtp_ToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                Dtp_FromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                //GeneralFunction.Trace("Report LoadReportDetails Start");
                ds_Details = reporthelper.LoadReportDetails();
                //GeneralFunction.Trace("Report LoadReportDetails End");

                //GeneralFunction.Trace("Report AssignToControls Start");
                AssignToControls();
                //GeneralFunction.Trace("Report AssignToControls End");
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = "";
                culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
                Thread.CurrentThread.CurrentCulture = culture;
                Dtp_FromTime.CustomFormat = "hh:mm tt";
                Dtp_ToTime.CustomFormat = "hh:mm tt";
                Dtp_FromTime.Value = Convert.ToDateTime("12:00 AM");
                Dtp_ToTime.Value = Convert.ToDateTime("11:59 PM");
                Cmb_ItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
                Lbl_ItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 21-Nov-2014 by Seenivasan
                //GeneralFunction.Trace("Barcode Load Start");
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 21-Nov-2014 by Seenivasan
                //GeneralFunction.Trace("Barcode Load End");
                //GeneralFunction.Trace("Report Load End");
                chkPrintPreview.Checked = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Report_Load");
            }
        }

        #endregion
        private void populateRtb_FromListBox()
        {
            Rtb_FromListBox.DataSource = null;
            UserFavoriteQueryHelper userFavoriteHelper = new UserFavoriteQueryHelper();
            dt = userFavoriteHelper.ObjBALClass.GetFavoriteUserQuery();
            Rtb_FromListBox.DataSource = dt;
            Rtb_FromListBox.DisplayMember = "Description";
            Rtb_FromListBox.ValueMember = "QueryText";
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string listName = dt.Rows[i].Field<string>(2);
            //    Rtb_FromListBox.Items.Add(listName);
            //}
            //Rtb_FromListBox.Items.Add("Item name");
            //Rtb_FromListBox.Items.Add("Item no");
            //Rtb_FromListBox.Items.Add("Client");
            //Rtb_FromListBox.Items.Add("Agent");
            //Rtb_FromListBox.Items.Add("Supplier");
            //Rtb_FromListBox.Items.Add("Price");
            //Rtb_FromListBox.Items.Add("Minimum price");
            //Rtb_FromListBox.Items.Add("Wholesale");
            //Rtb_FromListBox.Items.Add("Date");
            //Rtb_FromListBox.Items.Add("Number");
            //Rtb_FromListBox.Items.Add("Quantity");
            //Rtb_FromListBox.Items.Add("Sold");
            //Rtb_FromListBox.Items.Add("Purchased");
            //Rtb_FromListBox.Items.Add("Rented");
            //Rtb_FromListBox.Items.Add("Sales returned");
            //Rtb_FromListBox.Items.Add("Purchase returned");
            //Rtb_FromListBox.Items.Add("User");
            //Rtb_FromListBox.Items.Add("Employee");
            //Rtb_FromListBox.Items.Add("Time");
            //Rtb_FromListBox.Items.Add("Stock");
            //Rtb_FromListBox.Items.Add("Debt");
            //Rtb_FromListBox.Items.Add("Payable");
            //Rtb_FromListBox.Items.Add("Receivable");
            //Rtb_FromListBox.Items.Add("Balance");
            //Rtb_FromListBox.Items.Add("Discount");
            //Rtb_FromListBox.Items.Add("Tax");
            //Rtb_FromListBox.Items.Add("Company");
            //Rtb_FromListBox.Items.Add("Category");
            //Rtb_FromListBox.Items.Add("Place");
            //Rtb_FromListBox.Items.Add("Expiry");
            //Rtb_FromListBox.Items.Add("Account");
            //Rtb_FromListBox.Items.Add("Bank");
            //Rtb_FromListBox.Items.Add("Branch");
            //Rtb_FromListBox.Items.Add("Cash");
        }
        private void AssignToControls()
        {
            DataView dv = new DataView(ds_Details.Tables[0]);
            dv.RowFilter = "ISHide=0";
            Cmb_Item.DataSource = dv.ToTable();
            Cmb_Item.SelectedIndex = -1;
            DataView dv1 = new DataView(ds_Details.Tables[1]);
            dv1.RowFilter = "ItemNumber<>'' and IsHide=0";

            Cmb_ItemNo.DataSource = dv1.ToTable();
            Cmb_ItemNo.SelectedIndex = -1;
            Cmb_Category.DataSource = ds_Details.Tables[2];
            Cmb_Category.SelectedIndex = -1;
            //  Lbl_Category.Text = ds_Details.Tables[2].Rows[0]["FieldName"].ToString();
            Cmb_Company.DataSource = ds_Details.Tables[3];
            Cmb_Company.SelectedIndex = -1;
            // Lbl_Company.Text = ds_Details.Tables[3].Rows[0]["FieldName"].ToString();
            Cmb_Agent.DataSource = ds_Details.Tables[4];
            Cmb_Agent.SelectedIndex = -1;
            Cmb_User.DataSource = ds_Details.Tables[5];
            Cmb_User.SelectedIndex = -1;
            cmbBank.DataSource = ds_Details.Tables[6];
            cmbBank.SelectedIndex = -1;

        }




        #region SetLanguage

        public void SetLanguages()
        {

            //foreach (TabPage tabPage in Tab_Reports.TabPages)
            //{
            //    tabPage.Text = Additional_Barcode.GetValueByResourceKey(tabPage.Tag.ToString());
            //    if (tabPage.Tag == "Customized")
            //    {
            //        //Tab_Reports.TabPages.Remove(tabPage);
            //    }
            //}
            Grb_Selections.Text = Additional_Barcode.GetValueByResourceKey("Favorites");
            btn_CustomReport.Text = Additional_Barcode.GetValueByResourceKey("CustomReport");
            Btn_QueryForm.Text = Additional_Barcode.GetValueByResourceKey("Query");

            populateRtb_FromListBox();

            //Btn_NewReport.Text = Btn_NewReport.Tag.ToString();
            //Btn_DeleteReport.Text = Btn_DeleteReport.Tag.ToString();
            //Btn_Save.Text = Btn_Save.Tag.ToString();
            //btn_Add.Text = btn_Add.Tag.ToString();
            //Btn_Remove.Text = Btn_Remove.Tag.ToString();
            //Lbl_ReportName.Text = Lbl_ReportName.Tag.ToString();

            Lbl_ItemInformation.Text = Additional_Barcode.GetValueByResourceKey(Lbl_ItemInformation.Tag.ToString());
            Rbn_ItemMovementPurchase.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ItemMovementPurchase.Tag.ToString());
            Rbn_ItemMovementSales.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ItemMovementSales.Tag.ToString());
            Rbn_Liner.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Liner.Tag.ToString());
            Rbn_Acc_AgentBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Acc_AgentBalanceSheet.Tag.ToString());
            Rbn_BankStatement.Text = Additional_Barcode.GetValueByResourceKey(Rbn_BankStatement.Tag.ToString());
            Rbn_BestWorstSalesPeriod.Text = Additional_Barcode.GetValueByResourceKey(Rbn_BestWorstSalesPeriod.Tag.ToString());

            Rbn_Branch_BranchBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Branch_BranchBalanceSheet.Tag.ToString());
            Rbn_BranchMovement.Text = Additional_Barcode.GetValueByResourceKey(Rbn_BranchMovement.Tag.ToString());
            Rbn_BranchReturningList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_BranchReturningList.Tag.ToString());
            Rbn_BranchsList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_BranchsList.Tag.ToString());
            Rbn_Chart.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Chart.Tag.ToString());
            Rbn_Client_AgentBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Client_AgentBalanceSheet.Tag.ToString());
            Rbn_ClientList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ClientList.Tag.ToString());
            Rbn_ClientPaymentList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ClientPaymentList.Tag.ToString());
            Rbn_DeptList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_DeptList.Tag.ToString());
            Rbn_DeptsToBePaid.Text = Additional_Barcode.GetValueByResourceKey(Rbn_DeptsToBePaid.Tag.ToString());
            Rbn_Drawings.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Drawings.Tag.ToString());
            Rbn_Expenses.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Expenses.Tag.ToString());
            Rbn_ExpiryListToADate.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ExpiryListToADate.Tag.ToString());
            Rbn_HourlySales.Text = Additional_Barcode.GetValueByResourceKey(Rbn_HourlySales.Tag.ToString());
            Rbn_IAI_TotalDiscounts.Text = Additional_Barcode.GetValueByResourceKey(Rbn_IAI_TotalDiscounts.Tag.ToString());
            Rbn_Inventory.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Inventory.Tag.ToString());
            Rbn_InventoryAtDate.Text = Additional_Barcode.GetValueByResourceKey(Rbn_InventoryAtDate.Tag.ToString());
            Rbn_InventoryValue.Text = Additional_Barcode.GetValueByResourceKey(Rbn_InventoryValue.Tag.ToString());
            Rbn_ItemCardInOutStock.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ItemCardInOutStock.Tag.ToString());
            Rbn_ItemMovementPurchase.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ItemMovementPurchase.Tag.ToString());
            Rbn_ItemMovementSales.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ItemMovementSales.Tag.ToString());
            Rbn_List.Text = Additional_Barcode.GetValueByResourceKey(Rbn_List.Tag.ToString());
            Rbn_ListOfSalesAndprofitOfEachClient.Text = Additional_Barcode.GetValueByResourceKey(Rbn_ListOfSalesAndprofitOfEachClient.Tag.ToString());
            Rbn_MaintanancePriceList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_MaintanancePriceList.Tag.ToString());
            Rbn_MonthsComparison.Text = Additional_Barcode.GetValueByResourceKey(Rbn_MonthsComparison.Tag.ToString());
            Rbn_NetProfit.Text = Additional_Barcode.GetValueByResourceKey(Rbn_NetProfit.Tag.ToString());
            Rbn_Payables.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Payables.Tag.ToString());
            Rbn_PriceList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_PriceList.Tag.ToString());
            Rbn_PriceListBarcode.Text = Additional_Barcode.GetValueByResourceKey(Rbn_PriceListBarcode.Tag.ToString());
            Rbn_PurchaseInvoiceList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_PurchaseInvoiceList.Tag.ToString());
            Rbn_PurchaseReturnMovement.Text = Additional_Barcode.GetValueByResourceKey(Rbn_PurchaseReturnMovement.Tag.ToString());
            Rbn_Receivables.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Receivables.Tag.ToString());
            Rbn_SaleInvoiceList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SaleInvoiceList.Tag.ToString());
            Rbn_SaleMovementAccordingTo.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SaleMovementAccordingTo.Tag.ToString());
            Rbn_SalsReturnMovement.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SalsReturnMovement.Tag.ToString());
            Rbn_SpoiledItems.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SpoiledItems.Tag.ToString());
            Rbn_Supplier_AgentBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Supplier_AgentBalanceSheet.Tag.ToString());
            Rbn_SupplierList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SupplierList.Tag.ToString());
            Rbn_SuppliersLatePayments.Text = Additional_Barcode.GetValueByResourceKey(Rbn_SuppliersLatePayments.Tag.ToString());
            Rbn_Table.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Table.Tag.ToString());
            Rbn_TaxList.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TaxList.Tag.ToString());
            Rbn_TotalClientsMovement.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalClientsMovement.Tag.ToString());
            Rbn_TotalDiscountFromSupplier.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalDiscountFromSupplier.Tag.ToString());
            Rbn_TotalDiscountFromTheClients.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalDiscountFromTheClients.Tag.ToString());
            Rbn_TotalDiscounts.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalDiscounts.Tag.ToString());
            Rbn_TotalPurchaseOfBranch.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalPurchaseOfBranch.Tag.ToString());
            Rbn_TotalReturningPurchase.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalReturningPurchase.Tag.ToString());
            Rbn_TotalReturningSale.Text = Additional_Barcode.GetValueByResourceKey(Rbn_TotalReturningSale.Tag.ToString());
            Rbn_UserProductivity.Text = Additional_Barcode.GetValueByResourceKey(Rbn_UserProductivity.Tag.ToString());
            Rbn_WellMovingItems.Text = Additional_Barcode.GetValueByResourceKey(Rbn_WellMovingItems.Tag.ToString());
            Rbn_Zakat.Text = Additional_Barcode.GetValueByResourceKey(Rbn_Zakat.Tag.ToString());
            Lbl_Agent.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Agent.Tag.ToString());
            lbl_Branches.Text = Additional_Barcode.GetValueByResourceKey(lbl_Branches.Tag.ToString());
            Lbl_Cash.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Cash.Tag.ToString());
            Lbl_Category.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Category.Tag.ToString());
            Lbl_Chats.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Chats.Tag.ToString());
            Lbl_Clients.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Clients.Tag.ToString());

            Lbl_Company.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Company.Tag.ToString());

            Lbl_From.Text = Additional_Barcode.GetValueByResourceKey(Lbl_From.Tag.ToString());
            Lbl_FromDate.Text = Additional_Barcode.GetValueByResourceKey(Lbl_FromDate.Tag.ToString());
            Lbl_FromTime.Text = Additional_Barcode.GetValueByResourceKey(Lbl_FromTime.Tag.ToString());
            Lbl_InvoiceAndItems.Text = Additional_Barcode.GetValueByResourceKey(Lbl_InvoiceAndItems.Tag.ToString());

            Lbl_ItemName.Text = Additional_Barcode.GetValueByResourceKey(Lbl_ItemName.Tag.ToString());
            Lbl_ItemNo.Text = Additional_Barcode.GetValueByResourceKey(Lbl_ItemNo.Tag.ToString());
            Lbl_Number.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Number.Tag.ToString());
            // Lbl_ReportName.Text=  Additional_Barcode.GetValueByResourceKey(Lbl_ReportName.Tag.ToString());
            Lbl_Sheets.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Sheets.Tag.ToString());
            Lbl_Sorting.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Sorting.Tag.ToString());
            Lbl_Stock.Text = Additional_Barcode.GetValueByResourceKey(Lbl_Stock.Tag.ToString());
            lbl_Suppliers.Text = Additional_Barcode.GetValueByResourceKey(lbl_Suppliers.Tag.ToString());
            Lbl_ToDate.Text = Additional_Barcode.GetValueByResourceKey(Lbl_ToDate.Tag.ToString());
            Lbl_ToTime.Text = Additional_Barcode.GetValueByResourceKey(Lbl_ToTime.Tag.ToString());
            Lbl_User.Text = Additional_Barcode.GetValueByResourceKey(Lbl_User.Tag.ToString());
            lblBank.Text = Additional_Barcode.GetValueByResourceKey(lblBank.Tag.ToString());
            //MTxt_From.Text=  Additional_Barcode.GetValueByResourceKey(MTxt_From.Tag.ToString());
            //  txtBarcode.Text=  Additional_Barcode.GetValueByResourceKey(txtBarcode.Tag.ToString());
            Chk_AllAgent.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllAgent.Tag.ToString());
            Chk_AllCategory.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllCategory.Tag.ToString());
            Chk_AllCompany.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllCompany.Tag.ToString());
            Chk_AllDateTime.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllDateTime.Tag.ToString());
            Chk_AllItem.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllItem.Tag.ToString());
            Chk_AllUser.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllUser.Tag.ToString());
            Chk_Default.Text = Additional_Barcode.GetValueByResourceKey(Chk_Default.Tag.ToString());
            Chk_ExpiryItem.Text = Additional_Barcode.GetValueByResourceKey(Chk_ExpiryItem.Tag.ToString());
            Chk_Logo.Text = Additional_Barcode.GetValueByResourceKey(Chk_Logo.Tag.ToString());
            Chk_AllBank.Text = Additional_Barcode.GetValueByResourceKey(Chk_AllBank.Tag.ToString());
            Gb_Details.Text = Additional_Barcode.GetValueByResourceKey(Gb_Details.Tag.ToString());
            Gb_Item.Text = Additional_Barcode.GetValueByResourceKey(Gb_Item.Tag.ToString());
            Gb_Period.Text = Additional_Barcode.GetValueByResourceKey(Gb_Period.Tag.ToString());
            Gb_SearchSelection.Text = Additional_Barcode.GetValueByResourceKey(Gb_SearchSelection.Tag.ToString());
            Btn_Close.Text = Additional_Barcode.GetValueByResourceKey(Btn_Close.Tag.ToString());
            Btn_ViewReports.Text = Additional_Barcode.GetValueByResourceKey(Btn_ViewReports.Tag.ToString());
            this.Text = Additional_Barcode.GetValueByResourceKey("Report");
            Cmb_Sorting.Items.Clear();

            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("AtoZ"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("ZtoA"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Date"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Time"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Supplier"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Category"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Company"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Client"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Package"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("ItemplaceandAtoZ"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Balance"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Quantity"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Cost"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Price"));
            //Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("Ceaper"));
            Cmb_Sorting.Items.Add(Additional_Barcode.GetValueByResourceKey("MostExpensive"));
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");



        }


        #endregion

        private void Rbn_ItemMovementSales_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                isAllDateSelected = false;
                if (((RadioButton)sender).Checked == true)
                {
                    // ControlClear(); Commended by Meena.R on 03Feb2015 as per client request
                    ControlVisible(((RadioButton)sender).Tag.ToString());

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Rbn_ItemMovementSales_CheckedChanged");
            }

        }
        private void ControlVisible(String Option)
        {
            SelectedOption = Option;
            IsFormLoad = true;
            DisableAllControls();
            IsFormLoad = false;
            DefaultOption();
            switch (Option)
            {
                //-------------------------Stock Information------------------
                case "ItemSaleMovement":
                case "ItemPurchaseMovement":
                    Gb_Period.Enabled = true;
                    Gb_Details.Enabled = true;
                    User();
                    Item();
                    break;
                case "SaleReturnMovement":
                case "PurchaseReturnMovement":
                    Agent(); Category(); Company(); Item();
                    Gb_Details.Enabled = true;
                    break;
                case "TotalSaleReturning":
                case "TotalPurchaseReturning":
                    Agent(); Category(); Company();
                    Gb_Item.Enabled = false;
                    Gb_Period.Enabled = true;
                    Gb_Details.Enabled = true;
                    break;

                case "SecondHandPriceList":
                case "Inventory":
                case "SpoiledItems":
                case "WellMovingItems":
                    // case "InventoryValue":
                    //Commented by Ritu on 05-11-2014.The code is replaced below
                    //Gb_Period.Enabled = true;
                    //Gb_Item.Enabled = false;
                    //Category(); Company();
                    //Gb_Details.Enabled = true;
                    if (Option == "Inventory")
                    {
                        Gb_Period.Enabled = false;
                        Gb_Item.Enabled = false;
                        Category(); Company();
                        Gb_Details.Enabled = true;
                    }
                    else
                    {
                        Gb_Period.Enabled = true;
                        Gb_Item.Enabled = false;
                        Category(); Company();
                        Gb_Details.Enabled = true;
                    }
                    break;

                case "PriceList":
                case "InventoryAtDate":
                case "PriceListBarcode":
                    Gb_Period.Enabled = true;
                    Dtp_FromDate.Enabled = false;
                    Dtp_FromTime.Enabled = false;
                    Dtp_ToTime.Enabled = false;
                    Chk_AllDateTime.Enabled = false;
                    Gb_Item.Enabled = false;
                    Category(); Company();
                    Gb_Details.Enabled = true;
                    break;
                case "ItemCardInOutStock":
                    Gb_Period.Enabled = true;

                    Gb_SearchSelection.Enabled = false;
                    Gb_Details.Enabled = true;
                    Item();
                    break;

                case "ExpiryListToADate":
                    Gb_Period.Enabled = true;
                    Dtp_FromDate.Enabled = false;
                    Dtp_FromTime.Enabled = false;
                    Dtp_ToTime.Enabled = false;
                    Chk_AllDateTime.Enabled = false;
                    Gb_Item.Enabled = false;
                    Gb_SearchSelection.Enabled = false;
                    Gb_Details.Enabled = true;
                    break;
                //--------------------------------------------------------------------             

                case "TaxList":
                case "NetProfit":
                case "TotalClientsMovement":
                    // case "BankStatement":
                    Gb_Period.Enabled = true;
                    Gb_SearchSelection.Enabled = false;
                    Gb_Details.Enabled = true;
                    Gb_Item.Enabled = false;///need to be adjust 
                    break;
                case "BankStatement":
                    Gb_Period.Enabled = true;
                    Gb_Details.Enabled = true;
                    Gb_Item.Enabled = false;
                    Bank();
                    break;

                case "Zakat":
                case "SuppliersList":
                case "ClientList":
                    Gb_Details.Enabled = Gb_Item.Enabled = Gb_Period.Enabled = Gb_SearchSelection.Enabled = false;
                    break;

                case "AgentBalanceSheet":
                case "BranchBalanceSheet":
                case "TotalPurchaseOfABranch":
                case "DebtList":
                case "ClientPaymentList":
                case "TotalDiscountFromTheSupplier":
                case "BranchMovement":
                case "BranchesList":
                case "DebtsToBePaid":
                case "Client_AgentBalanceSheet":
                case "Supplier_AgentBalanceSheet":
                    Gb_Period.Enabled = true;
                    Gb_Details.Enabled = true;
                    Gb_Item.Enabled = false;
                    Agent();
                    break;

                case "Spendings":
                case "Drawings":
                    // case "ListOfSaleAndProfitOfEachClient":
                    Gb_Period.Enabled = true;
                    Gb_Item.Enabled = false;
                    Gb_Details.Enabled = true;
                    User();

                    break;
                case "Payables":
                case "Receivables":
                case "SaleInvoiceList":
                case "PurchaseInvoiceList":
                case "BranchReturningList":
                case "TotalDiscountFromTheClients":
                case "ListOfSaleAndProfitOfEachClient":
                    Gb_Period.Enabled = true;
                    Gb_Item.Enabled = false;
                    Gb_Details.Enabled = true;
                    User(); Agent();
                    break;
                case "TotalDiscounts":
                    Gb_Period.Enabled = true;
                    Gb_Item.Enabled = false;
                    Gb_Details.Enabled = true;
                    User(); Agent();
                    break;
                case "SaleMovementAccordingTo":
                    Gb_Period.Enabled = true;
                    // Gb_Item.Enabled = true ;
                    Gb_Details.Enabled = true;
                    Item();
                    Category(); Company(); User(); Agent();
                    break;

                case "IAITotalDiscounts":
                    Gb_Period.Enabled = true;
                    Gb_Item.Enabled = false;
                    Gb_Details.Enabled = true;
                    Category(); Company(); User();
                    break;
                case "InventoryValue":
                    Gb_Period.Enabled = false;
                    Gb_Item.Enabled = false;
                    Company(); Category();
                    Gb_Details.Enabled = true;
                    break;
                //-------------------------------------------------------------

                case "SuppliersLatePayments":
                    Gb_Period.Enabled = true;
                    Dtp_FromDate.Enabled = false;
                    Dtp_FromTime.Enabled = false;
                    Dtp_ToTime.Enabled = false;
                    Chk_AllDateTime.Enabled = false;
                    Gb_Item.Enabled = false;
                    Gb_SearchSelection.Enabled = false;
                    Gb_Details.Enabled = true;
                    Agent();
                    break;
                case "ClientPurchaseList":
                    Gb_Period.Enabled = true;
                    Gb_Details.Enabled = true;
                    Gb_Item.Enabled = false;
                    Agent(); Company(); Category();
                    break;

                case "UserProductivity":
                case "BestWorstSalesPeriod":
                case "MonthssComparison":
                case "HourlySales":
                    Gb_Period.Enabled = true;
                    Gb_SearchSelection.Enabled = false;
                    Gb_Details.Enabled = true;
                    Gb_Item.Enabled = false;
                    Rbn_Liner.Enabled = true;
                    Rbn_Chart.Enabled = Rbn_Liner.Checked = true;
                    Rbn_List.Enabled = false;
                    Rbn_Table.Enabled = false;
                    break;


            }



        }


        private void DefaultOption()
        {
            Dtp_FromDate.Enabled = true; Dtp_FromTime.Enabled = true;
            Dtp_ToDate.Enabled = true; Dtp_ToTime.Enabled = true;
            Chk_AllDateTime.Enabled = true;
            Lbl_FromTime.Enabled = true;
            Lbl_ToTime.Enabled = true;
            Lbl_FromDate.Enabled = true;
            Lbl_ToDate.Enabled = true;
            Cmb_Sorting.Enabled = true;
            Lbl_Sorting.Enabled = true;
            Chk_Default.Enabled = true;
            Chk_Default.Checked = true;
            Chk_Logo.Enabled = true;
            Rbn_Table.Enabled = Rbn_Table.Checked = true;
            Rbn_List.Enabled = true;

        }
        /// <summary>
        /// Get the controls from filter panel then diasble the controls.
        /// </summary>
        private void DisableAllControls()
        {

            foreach (Control control in TableLayoutFilterPanel.Controls)
            {
                foreach (Control name in control.Controls)
                {
                    if (name is GroupBox)
                    {
                        foreach (Control controlsname in name.Controls)
                        {
                            if (controlsname is RadioButton)
                            {
                                ((RadioButton)controlsname).Enabled = ((RadioButton)controlsname).Checked = false;

                            }


                            if (controlsname is CheckBox)
                            {
                                ((CheckBox)controlsname).Enabled = ((CheckBox)controlsname).Checked = false;
                            }

                            if (controlsname is MaskedTextBox)
                            {
                                ((MaskedTextBox)controlsname).Text = string.Empty;
                                ((MaskedTextBox)controlsname).Enabled = false;

                            }
                            if (controlsname is DateTimePicker)
                            {
                                ((DateTimePicker)controlsname).Enabled = false;
                                // ((DateTimePicker)controlsname).Value = DateTime.Now;
                            }

                            if (controlsname is Label)
                            {
                                ((Label)controlsname).Enabled = false;
                            }
                            if (controlsname is ComboBox)
                            {
                                ((ComboBox)controlsname).Enabled = false;

                            }
                        }
                    }
                }
            }

        }




        void User()
        {
            Gb_SearchSelection.Enabled = true;
            Lbl_User.Enabled = true;
            Cmb_User.Enabled = true;
            Chk_AllUser.Enabled = true;
            Chk_AllUser.Checked = true;
        }
        void Item()
        {
            Gb_Item.Enabled = true;
            Gb_Item.Enabled = true;
            Chk_AllItem.Enabled = true;
            Cmb_Item.Enabled = true;
            Cmb_ItemNo.Enabled = true;
            Lbl_ItemNo.Enabled = true;
            Lbl_ItemName.Enabled = true;
            Chk_ExpiryItem.Enabled = true;

        }
        void Agent()
        {
            Gb_SearchSelection.Enabled = true;
            Lbl_Agent.Enabled = true;
            Cmb_Agent.Enabled = true;
            Chk_AllAgent.Enabled = true;
            Chk_AllAgent.Checked = true;
        }
        void Category()
        {
            Gb_SearchSelection.Enabled = true;
            Lbl_Category.Enabled = true;
            Cmb_Category.Enabled = true;
            Chk_AllCategory.Enabled = true;
            Chk_AllCategory.Checked = true;
        }
        void Company()
        {
            Gb_SearchSelection.Enabled = true;
            Lbl_Company.Enabled = true;
            Cmb_Company.Enabled = true;
            Chk_AllCompany.Enabled = true;
            Chk_AllCompany.Checked = true;
        }
        void Bank()
        {
            Gb_SearchSelection.Enabled = true;
            lblBank.Enabled = true;
            cmbBank.Enabled = true;
            Chk_AllBank.Enabled = true;
            Chk_AllBank.Checked = true;
        }



        private void Chk_Default_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsFormLoad)
                {
                    CheckBox checkbox = (CheckBox)sender;
                    //   if (((RadioButton)sender).Checked == true)

                    switch (checkbox.Name.Replace("Chk_", "").ToString())
                    {
                        case "Default":
                            Cmb_Sorting.SelectedIndex = -1;
                            Cmb_Sorting.Enabled = !Chk_Default.Checked;
                            Lbl_Sorting.Enabled = !Chk_Default.Checked;
                            break;

                        case "AllItem":

                            Cmb_Item.SelectedIndex = -1;
                            Cmb_ItemNo.SelectedIndex = -1;
                            Lbl_ItemName.Enabled = !Chk_AllItem.Checked;
                            Lbl_ItemNo.Enabled = !Chk_AllItem.Checked;
                            Cmb_Item.Enabled = !Chk_AllItem.Checked;
                            Cmb_ItemNo.Enabled = !Chk_AllItem.Checked;
                            // Chk_ExpiryItem.Enabled=Chk_ExpiryItem.Checked = !Chk_AllItem.Checked;
                            //if (Cmb_Item.Enabled == true)
                            //Cmb_Item.Text = itemnam;

                            break;
                        case "AllDateTime":
                            Dtp_FromDate.Enabled = !Chk_AllDateTime.Checked;
                            Dtp_FromTime.Enabled = !Chk_AllDateTime.Checked;
                            Dtp_ToDate.Enabled = !Chk_AllDateTime.Checked;
                            Dtp_ToTime.Enabled = !Chk_AllDateTime.Checked;
                            isAllDateSelected = Chk_AllDateTime.Checked;

                            Lbl_FromTime.Enabled = !Chk_AllDateTime.Checked;
                            Lbl_ToTime.Enabled = !Chk_AllDateTime.Checked;
                            Lbl_FromDate.Enabled = !Chk_AllDateTime.Checked;
                            Lbl_ToDate.Enabled = !Chk_AllDateTime.Checked;
                            break;

                        case "AllCategory":
                            Cmb_Category.SelectedIndex = -1;
                            Cmb_Category.Enabled = !Chk_AllCategory.Checked;
                            Lbl_Category.Enabled = !Chk_AllCategory.Checked;
                            break;

                        case "AllCompany":
                            Cmb_Company.SelectedIndex = -1;
                            Cmb_Company.Enabled = !Chk_AllCompany.Checked;
                            Lbl_Company.Enabled = !Chk_AllCompany.Checked;
                            break;
                        case "AllUser":
                            Cmb_User.SelectedIndex = -1;
                            Cmb_User.Enabled = !Chk_AllUser.Checked;
                            Lbl_User.Enabled = !Chk_AllUser.Checked;
                            break;

                        case "AllAgent":
                            Cmb_Agent.SelectedIndex = -1;
                            Cmb_Agent.Enabled = !Chk_AllAgent.Checked;
                            Lbl_Agent.Enabled = !Chk_AllAgent.Checked;
                            break;
                        case "AllBank":
                            cmbBank.SelectedIndex = -1;
                            cmbBank.Enabled = lblBank.Enabled = !Chk_AllBank.Checked;
                            break;



                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Chk_Default_CheckedChanged");
            }
        }




        private void Tab_Reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                TabPageName = ((TabControl)sender).SelectedTab.Tag.ToString();
                CheckSelectedStatement();
                if (CheckRadioButton == false) { DisableAllControls(); }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Tab_Reports_SelectedIndexChanged");
            }

        }
        private void CheckSelectedStatement()
        {

            foreach (Control ctrl in Tab_Reports.TabPages)
            {
                if (ctrl.Tag == TabPageName)
                {
                    foreach (Control control in ctrl.Controls)///Get table Layout Panel 
                    {
                        foreach (Control panel in control.Controls)//Get Panel Controls From Table Layout
                        {
                            foreach (Control radiobutton in panel.Controls) //Get controls From Panel 
                            {
                                if (radiobutton is RadioButton)
                                {
                                    if (((RadioButton)radiobutton).Checked == true)
                                    {

                                        ControlVisible(radiobutton.Tag.ToString());
                                        CheckRadioButton = true;
                                        break;
                                    }
                                    else { CheckRadioButton = false; }



                                }


                            }

                        }

                    }

                    break;
                }
            }


        }

        private void Btn_ViewReports_Click(object sender, EventArgs e)
        {
            try
            {
                //MasterFrom ms = new MasterFrom();
                //string userNam = ms;
                //EmployeeHelper empHelper = new EmployeeHelper();
                //empHelper.ObjEmployeeBALClass.Check_UserLogin();
                AssginFromControls();
                if (Validation())
                {
                    if (Chk_AllDateTime.Checked)
                    {
                        isAllDateSelected = true;
                    }else { isAllDateSelected = false; }
                    reporthelper.SearchCondition(SelectedOption);

                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_ViewReports_Click");
            }


        }
        private void AssginFromControls()
        {
            if (Chk_AllDateTime.Checked != true & Gb_Period.Enabled == true)
            {
                TimeSpan FromTime = new TimeSpan(Dtp_FromTime.Value.Hour, Dtp_FromTime.Value.Minute, Dtp_FromTime.Value.Second);
                reportobject.FromDate = Convert.ToDateTime(Dtp_FromDate.Value.Date + FromTime);
                TimeSpan ToTime = new TimeSpan(Dtp_ToTime.Value.Hour, Dtp_ToTime.Value.Minute, Dtp_ToTime.Value.Second);
                reportobject.ToDate = Convert.ToDateTime(Dtp_ToDate.Value.Date + ToTime);

                //reportobject.FromDate = Convert.ToDateTime(Dtp_FromDate.Value.AddHours(Dtp_FromTime.Value.TimeOfDay.Hours - Dtp_FromDate.Value.TimeOfDay.Hours));
                //reportobject.ToDate = Convert.ToDateTime(Dtp_ToDate.Value.AddHours(Dtp_ToTime.Value.TimeOfDay.Hours - Dtp_ToDate.Value.TimeOfDay.Hours));

                reportobject.FromTime = reportobject.FromDate.Value; //Convert.ToDateTime(Dtp_FromTime.Value);
                reportobject.ToTime = reportobject.ToDate.Value; //Convert.ToDateTime(Dtp_ToTime.Value);
                reportobject.CheckDateField = false;
            }
            else
            {
                reportobject.FromDate = null;
                reportobject.ToDate = null;
                reportobject.CheckDateField = true;
            }
            reportobject.ItemName = Cmb_Item.Text;
            //reportobject.ItemNo = Convert.ToInt32(Cmb_ItemNo.SelectedValue);
            reportobject.ItemNo = Convert.ToInt32(Cmb_Item.SelectedValue);
            reportobject.ExpiryItem = Chk_ExpiryItem.Checked == true ? 1 : 0;
            reportobject.CompanyName = Cmb_Company.Text;
            reportobject.CategoryName = Cmb_Category.Text;
            reportobject.AgentName = Cmb_Agent.Text;
            reportobject.UserId = Convert.ToInt32(Cmb_User.SelectedValue);
            reportobject.BankName = cmbBank.Text;
            reportobject.Number = Convert.ToInt32(Cmb_Number.SelectedValue);
            reportobject.SortingType = Chk_Default.Checked == true ? "ALL" : Cmb_Sorting.Text.ToString().Trim();
            reportobject.List = Rbn_List.Checked;
            reportobject.Linear = Rbn_Liner.Checked;
            reportobject.Table = Rbn_Table.Checked;
            reportobject.Chart = Rbn_Chart.Checked;
            reportobject.IncludeLogo = Chk_Logo.Checked;
            reportobject.FromField = Cmb_Number.Text;
            reportobject.CategoryID = Convert.ToInt32(Cmb_Category.SelectedValue);
            reportobject.CompanyID = Convert.ToInt32(Cmb_Company.SelectedValue);
            reportobject.AgentID = Convert.ToInt32(Cmb_Agent.SelectedValue);
            reportobject.PrintPreviewChecked = chkPrintPreview.Checked ? true : false;
            if (SelectedOption == "TotalDiscounts")
            {
                if (Chk_AllUser.Checked && Chk_AllDateTime.Checked) reportobject.Flag = "All";
                else if (Chk_AllAgent.Checked && !Chk_AllUser.Checked && !Chk_AllDateTime.Checked) reportobject.Flag = "Agent";
                else if (!Chk_AllAgent.Checked && Chk_AllUser.Checked && !Chk_AllDateTime.Checked) reportobject.Flag = "User";
                else if (!Chk_AllAgent.Checked && !Chk_AllUser.Checked && Chk_AllDateTime.Checked) reportobject.Flag = "Date";
                else if (Chk_AllAgent.Checked && Chk_AllUser.Checked && !Chk_AllDateTime.Checked) reportobject.Flag = "AgentUser";
                else if (!Chk_AllAgent.Checked && Chk_AllUser.Checked && !Chk_AllDateTime.Checked) reportobject.Flag = "DateUser";
                else if (Chk_AllAgent.Checked && !Chk_AllUser.Checked && Chk_AllDateTime.Checked) reportobject.Flag = "DateAgent";
                else if (Chk_AllAgent.Checked && Chk_AllUser.Checked && Chk_AllDateTime.Checked) reportobject.Flag = "Selected";
            }

        }
        private Boolean Validation()
        {

            if (Dtp_FromDate.Enabled == true && Dtp_FromDate.Text == string.Empty)
            {
                GeneralFunction.Information("FromDateIsRequired", "Reports");
                Dtp_FromDate.Focus();
                return false;
            }
            else if (Dtp_ToDate.Enabled == true && Dtp_ToDate.Text == string.Empty)
            {
                GeneralFunction.Information(("ToDateIsRequired"), ("Reports"));
                Dtp_ToDate.Focus();
                return false;
            }
            else if (Dtp_FromDate.Enabled == true && Convert.ToDateTime(Dtp_FromDate.Value.Date) > Convert.ToDateTime(Dtp_ToDate.Value.Date))
            {
                GeneralFunction.Information(("SelectProperDate"), ("Reports"));
                Dtp_FromDate.Focus();
                return false;
            }
            else if (Dtp_FromTime.Enabled == true && Dtp_FromTime.Text == string.Empty)
            {
                GeneralFunction.Information(("FromTimeIsREquired"), ("Reports"));
                Dtp_FromTime.Focus();
                return false;
            }
            else if (Dtp_ToTime.Enabled == true && Dtp_ToTime.Text == string.Empty)
            {
                GeneralFunction.Information(("ToTimeIsRequired"), ("Reports"));
                Dtp_ToTime.Focus();
                return false;
            }
            else if (Cmb_Item.Enabled == true && Cmb_Item.Text == string.Empty)
            {
                GeneralFunction.Information(("ItemNameIsRequired"), ("Reports"));
                Cmb_Item.Focus();
                return false;
            }
            else if (Cmb_Category.Enabled == true && Cmb_Category.Text == string.Empty)
            {
                GeneralFunction.Information(("CategoryNameisRequired"), ("Reports"));
                Cmb_Category.Focus();
                return false;
            }
            else if (Cmb_Company.Enabled == true && Cmb_Company.Text == string.Empty)
            {
                GeneralFunction.Information(("CompanyNameIsRequired"), ("Reports"));
                Cmb_Company.Focus();
                return false;
            }
            else if (Cmb_Agent.Enabled == true && Cmb_Agent.Text == string.Empty)
            {
                GeneralFunction.Information(("AgentNameIsRequired"), ("Reports"));
                Cmb_Agent.Focus();
                return false;
            }
            else if (Cmb_User.Enabled == true && Cmb_User.Text == string.Empty)
            {

                GeneralFunction.Information(("UserNameIsRequired"), ("Reports"));
                Cmb_User.Focus();
                return false;
            }
            else if (Cmb_Number.Enabled == true && Cmb_Number.Text == string.Empty)
            {

                GeneralFunction.Information(("NumberIsRequired"), ("Reports"));
                Cmb_Number.Focus();
                return false;
            }
            else if (MTxt_From.Enabled == true && MTxt_From.Text == string.Empty)
            {

                GeneralFunction.Information(("ValueIsRequired"), ("Reports"));
                MTxt_From.Focus();
                return false;
            }
            else if (Cmb_Sorting.Enabled == true && Cmb_Sorting.Text == string.Empty)
            {

                GeneralFunction.Information(("SelectTheTypeOfSorting"), ("Reports"));
                Cmb_Sorting.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void Dtp_ToDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Dtp_ToDate.MaxDate = DateTime.Today;
            //  dateTimePicker1.MinDate = DateTime.Today.AddDays(-2);
            //  dateTimePicker1.MaxDate = DateTime.Today.AddDays(2);

        }

        private void Cmb_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int itemno = Convert.ToInt32(Cmb_Item.SelectedValue);
                Cmb_ItemNo.SelectedValue = itemno;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Item_SelectedIndexChanged");
            }
        }

        private void Cmb_ItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int itemno = Convert.ToInt32(Cmb_ItemNo.SelectedValue);
                Cmb_Item.SelectedValue = itemno;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_ItemNo_SelectedIndexChanged");
            }
        }

        private void Dtp_FromDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Dtp_ToDate.MinDate = Dtp_FromDate.Value;
                //Dtp_ToDate.Value = Dtp_FromDate.Value;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Dtp_FromDate_Validating");
            }
        }

        //private void Cmb_Item_DropDown(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //    //}
        //    //catch (Exception ex)
        //    //{


        //    //    GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
        //    //    GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Item_DropDown");
        //    //}
        //}

        //private void Cmb_Item_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        //((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        switch (((ComboBox)sender).Name)
        //        {
        //            case "Cmb_Item":
        //                Cmb_Item_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;
        //            case "Cmb_ItemNo":
        //                Cmb_ItemNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;



        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Item_DropDownClosed");
        //    }
        //}

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
        //            if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            {
        //                barcode = ScanValue + barcode;
        //            }

        //            barcode = barcode.Replace("\r", "");
        //            barcode = barcode.Replace("~", "");
        //            if (barcode.Length > 13)
        //            {
        //                barcode = barcode.Substring(1, barcode.Length - 1);
        //            }

        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;
        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {

        //                Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                Cmb_Item.SelectAll();
        //                Cmb_Item.Focus();


        //                ClearBarcodeValues();

        //            }
        //            else
        //            {
        //                if (GeneralFunction.Question("BarcodeIsNotSaved", this.Tag.ToString()) == DialogResult.Yes)
        //                {
        //                    // txtBarcodes.Text = ScanValue + txtBarcode.Text;
        //                    //Cmb_ItemNo.Focus(); 
        //                    Cmb_Item.SelectAll();
        //                    Cmb_Item.Focus();
        //                    // InvokeOnClick(btnSave, EventArgs.Empty);
        //                }
        //                else { txtBarcode.Text = ""; }
        //                ClearBarcodeValues();
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
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " tmrBarcode_Tick");
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
                        if (barcode.Trim().Length != 13)//added By T on 25Mar2019 if  we can continue it shown not available lastfocus control value no add
                        {
                            barcode = lastfocusedvalue + ScanValue + Convert.ToString(txtBarcode.Text);
                        }
                    }
                    //*********Commented for Performance Tuning on 21-Nov-2014 by Seenivasan*********//
                    //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    Cmb_Item.SelectAll();
                    //    Cmb_Item.Focus();
                    //    ClearBarcodeValues();
                    //}
                    //********************************************************************************
                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Length > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            Cmb_Item.Text = row1["ItemName"].ToString();
                            Cmb_Item.SelectAll();
                            Cmb_Item.Focus();
                            ClearBarcodeValues();
                        }
                    }
                    //******************************************************************************
                    else
                    {
                        if (GeneralFunction.Question("BarcodeIsNotSaved", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            // txtBarcodes.Text = ScanValue + txtBarcode.Text;
                            //Cmb_ItemNo.Focus(); 
                            Cmb_Item.SelectAll();
                            Cmb_Item.Focus();
                            // InvokeOnClick(btnSave, EventArgs.Empty);
                        }
                        else { txtBarcode.Text = ""; }
                        ClearBarcodeValues();
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

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            ScanLetterStartTime = DateTime.Now;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            //cmbItemName.Focus();

        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (txtBarcode.Text.Length > 4)
                //{
                tmrBarcode.Enabled = true;
                //}

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " tmrBarcode_Tick");
            }
        }
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    try
        //    {


        //        if (this.ActiveControl.Name == "txtBarcode") return;

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
        //            //  if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //            if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval) | ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1)))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //            }
        //            else
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //            }
        //        }
        //        if (ScanValue.Length == 6)
        //        {
        //            lastFocusedControl = this.ActiveControl;
        //            if (lastFocusedControl != null)
        //            { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }
        //            txtBarcode.Focus();
        //            //e.Handled = true;
        //        }
        //        //Cal Event Again
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
        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is Button || ctrl is CheckBox || ctrl is Label || ctrl is RadioButton || ctrl is GroupBox)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ctrl in panel7.Controls)
                {
                    if (ctrl is Button || ctrl is CheckBox || ctrl is Label || ctrl is RadioButton || ctrl is GroupBox)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ctrl in panel8.Controls)
                {
                    if (ctrl is Button || ctrl is CheckBox || ctrl is Label || ctrl is RadioButton || ctrl is GroupBox)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ctrl in panel9.Controls)
                {
                    if (ctrl is Button || ctrl is CheckBox || ctrl is Label || ctrl is RadioButton || ctrl is GroupBox)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ctr in TableLayoutPanel1.Controls)
                {
                    if (ctr is Button || ctr is CheckBox || ctr is Label || ctr is RadioButton || ctr is GroupBox || ctr is TabPage)
                        ctr.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                for (int i = 0; i <= this.TableLayoutFilterPanel.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.TableLayoutFilterPanel.RowCount; j++)
                    {
                        Control c = this.TableLayoutFilterPanel.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control btn in c.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is GroupBox)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
                Tab_Accounts.Font = Tab_Agents.Font = Tab_Charts.Font = Tab_Customized.Font = Tab_Stock.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmb_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 13 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && (e.KeyChar < 111 || e.KeyChar > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }

            //}
            //else
            //{
            //    if (((ComboBox)sender).SelectedIndex > -1)
            //    {
            //        ((ComboBox)sender).DroppedDown = false;
            //    }
            //}
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void Cmb_Category_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }

            //}
        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            reporthelper = null;
            reportobject = null;
            this.Dispose();
        }

        private void ControlClear()
        {
            Dtp_FromDate.Value = DateTime.Now;
            Dtp_ToDate.Value = DateTime.Now;
            Dtp_FromTime.Value = Convert.ToDateTime("12:00 AM");
            Dtp_ToTime.Value = Convert.ToDateTime("11:59 PM");
            Chk_AllDateTime.Checked = false;
            Cmb_Item.SelectedIndex = Cmb_ItemNo.SelectedIndex = -1;
            Chk_AllItem.Checked = false;
            Chk_ExpiryItem.Checked = false;
            Chk_AllCategory.Checked = Chk_AllCompany.Checked = Chk_AllBank.Checked = Chk_AllAgent.Checked = Chk_AllUser.Checked = false;
            Cmb_Number.SelectedIndex = -1;
            MTxt_From.Text = string.Empty;
            Cmb_Sorting.SelectedIndex = -1;
            Chk_Default.Checked = true;
            Rbn_Chart.Checked = Rbn_Liner.Checked = Rbn_List.Checked = false;
            Rbn_Table.Checked = true;
        }

        private void Grb_Selections_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CustomReport form = new CustomReport();
            form.ShowDialog();
            populateRtb_FromListBox();
        }

        private void Btn_NewReport_Click(object sender, EventArgs e)
        {

        }

        private void Btn_DeleteReport_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Up_Click(object sender, EventArgs e)
        {
            if (Rtb_FromListBox.Items.Count > 0)
                Rtb_FromListBox.SelectedIndex = 0;
        }
        private void Gb_Details_Enter(object sender, EventArgs e)
        {
        }
        private void Btn_Down_Click(object sender, EventArgs e)
        {
            if (Rtb_FromListBox.Items.Count > 0)
            {
                int lastindex = Rtb_FromListBox.Items.Count;
                lastindex = lastindex - 1;
                Rtb_FromListBox.SelectedIndex = lastindex;
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            CustomReport.passQuery = "";
            FormQuery form = new FormQuery();
            form.ShowDialog();
            populateRtb_FromListBox();
        }

        private void Rtb_FromListBox_DoubleClick(object sender, EventArgs e)
        {
            if (Rtb_FromListBox.Items.Count == 0)
            {
                return;
            }
            if (!string.IsNullOrEmpty(Rtb_FromListBox.SelectedValue.ToString()))
            {
                string selectedItem = Rtb_FromListBox.SelectedValue.ToString();
                string selectedQueryName = Rtb_FromListBox.GetItemText(Rtb_FromListBox.SelectedItem);

                CustomReport.passQuery = selectedItem;
                ShowFavoritesUserQuery.selectedQueryName = selectedQueryName;
                ShowFavoritesUserQuery.isFromFav = true;
                FormQuery form = new FormQuery();
                form.ShowDialog();
            }

        }
    }
}