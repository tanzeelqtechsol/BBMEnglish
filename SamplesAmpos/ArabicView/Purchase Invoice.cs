using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using BumedianBM.ViewHelper;
using System.Collections.Generic;
using System.Drawing;
using CommonHelper;
using ObjectHelper;
using System.Data;
using System.Diagnostics;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Purchase_Invoice : Form, IDisposable
    {
        #region Variables
        internal PurchaseInvoiceHelper ObjHelper;
        // IPurchaseView purchaseView = PurchaseViewAbstract.GetPurchaseView("PurchaseInvoice");
        internal string IDFromBalanceSheet = string.Empty;
        bool isFromLoad, CheckStatus = false;
        private DateTime ScanLetterStartTime = DateTime.Now.AddSeconds(-2);
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, check;//, isfrominsert = false;
        int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        private DateTime? LocalDatime = DateTime.Now;
        DataTable dtallBarcode; int itemnoforrowfocus;
        private decimal actualCostVal = 0;
        private string lastExchangeRateValue = "";

        #endregion

        #region Constructor
        public Purchase_Invoice()
        {
            //GeneralFunction.Trace("Puchase Constr Start");
            InitializeComponent();
            SetFont();
            SetLanguage();
            ObjHelper = new PurchaseInvoiceHelper();
            // ObjHelper.SAMPLE();
            this.LoadData();
            UserLimitation();
            cmbItemName.Select();
            cmbItemName.Focus();
            timer1.Tick += blinkTextbox;
            timer1.Interval = 650;
            timer1.Enabled = true;
            //GeneralFunction.Trace("Puchase Constr End");
        }

        ~Purchase_Invoice()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of 
            // readability and maintainability.
            Dispose(false);
        }

        #endregion

        #region Load Method
        //private void LoadData()
        //{
        //    List<ObjectHelper.PurchaseObjectClass> LoadDataList;
        //    try
        //    {
        //        //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
        //        dtpPaymentDate.Format = DateTimePickerFormat.Custom;
        //        dtpDate.Format = DateTimePickerFormat.Custom;
        //        dtpExpiry.Format = DateTimePickerFormat.Custom;
        //        dtpPaymentDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
        //        dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
        //        dtpExpiry.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
        //        //***********Date Format Check*****************************************************//

        //        // ds = ObjHelper.ds;
        //        isFromLoad = true;
        //        LoadDataList = ObjHelper.FillItemDetails();
        //        AssignSupplierDataSource();
        //        cmbCategory.SelectedIndexChanged -= new EventHandler(this.cmbCategory_SelectedIndexChanged);
        //        cmbCategory.DisplayMember = "Category";
        //        cmbCategory.ValueMember = "CategoryID";
        //        cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;
        //        cmbCompany.SelectedIndexChanged -= new EventHandler(this.cmbCompany_SelectedIndexChanged);
        //        cmbCompany.DisplayMember = "Company";
        //        cmbCompany.ValueMember = "CompanyID";
        //        cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;

        //        //cmbCompany.Refresh();
        //        cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
        //        cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
        //        cmbItemName.DisplayMember = "ItemName";
        //        cmbItemName.ValueMember = "ItemNo";
        //        cmbItemName.DataSource = LoadDataList;
        //        cmbItemNo.DisplayMember = "ItemNumber";
        //        cmbItemNo.ValueMember = "ItemNo";
        //        //commented on 25 april 2014,to filter the place on item number list 
        //        // cmbItemNo.DataSource = LoadDataList
        //        cmbItemNo.DataSource = LoadDataList.Where(i => i.ItemNumber != string.Empty).ToList();
        //        //cmbItemNo.DisplayMember = "ItemNo";
        //        // cmbItemNo.ValueMember = "ItemName";

        //        if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
        //        {
        //            lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
        //            lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
        //        }
        //        cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = -1;
        //        txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
        //        ObjHelper.LoadPurchseInvoiceData();
        //        if (ObjHelper.isFromelse)
        //        {
        //            txtInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString();
        //            txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID.ToString();
        //        }
        //        else
        //        {

        //            if (ObjHelper.ObjBALClass.ObjPurchase.Status == 2)
        //            {
        //                this.ClearAll();
        //                ClosedStatus();
        //            }
        //            else
        //            {
        //                //txtDiscount.ReadOnly = txtDiscount.Enabled = false;
        //                lblUservalue.Text = GeneralFunction.UserName;
        //                dtpDate.Value = Convert.ToDateTime(DateTime.Now);
        //                PurchaseOptionSetting();
        //                this.ClearAll();
        //            }
        //            SetControlfromObject();
        //            DataGridSource();
        //        }
        //        isFromLoad = false;
        //        this.cmbCategory.SelectedIndexChanged += new EventHandler(this.cmbCategory_SelectedIndexChanged);
        //        this.cmbCompany.SelectedIndexChanged += new EventHandler(this.cmbCompany_SelectedIndexChanged);
        //        rbnPercentage.CheckedChanged += new EventHandler(this.rbnPercentage_CheckedChanged);
        //        txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
        //        cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
        //        cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
        //        ////added on 22042014
        //        // cmbItemName.SelectedIndexChanged+=new EventHandler(cmbItemName_SelectedIndexChanged);
        //        ///
        //        // this.cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
        //        if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts); }
        //        //CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(Rtxt_NotesAndAlerts); this to be Implemented
        //        //CustomNotesAlerts.Set_NotesAlertDetails(Rtxt_NotesAndAlerts);
        //        ScanValue = "0";
        //        ScanTimingCheck = true;
        //        ScanLetterStartTime = DateTime.Now;

        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }

        //    finally
        //    {
        //        LoadDataList = null;
        //    }

        //}
        // reinitailze

        private void ReInitialize()
        {
            //InitializeComponent();

            string invoice = txtNewInvoiceNo.Text;
            SetFont();
            SetLanguage();
            ObjHelper = new PurchaseInvoiceHelper();
            // ObjHelper.SAMPLE();
            this.LoadData();
            UserLimitation();
            cmbItemName.Select();
            cmbItemName.Focus();
            timer1.Tick += blinkTextbox;
            timer1.Interval = 650;
            timer1.Enabled = true;
            txtNewInvoiceNo.Text = invoice;
            GetInvoiceDetails();

        }

        // New Load Data done by Praba on 07-Jan

        //New
        private void LoadData()
        {
            //List<ObjectHelper.PurchaseObjectClass> LoadDataList;
            DataTable DtItem;
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpPaymentDate.Format = DateTimePickerFormat.Custom;
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpExpiry.Format = DateTimePickerFormat.Custom;
                dtpPaymentDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpExpiry.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                // ds = ObjHelper.ds;
                isFromLoad = true;
                //LoadDataList = ObjHelper.FillItemDetails(); // Commented by Praba on 07-Jan-2015 for Barcode Testing ****************************88
                DtItem = ObjHelper.LoadItem();
                AssignSupplierDataSource();
                AssignCategoryCompany();

                //cmbCompany.Refresh();
                cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
                cmbItemName.DisplayMember = "ItemName";
                cmbItemName.ValueMember = "ItemNo";
                //cmbItemName.DataSource = LoadDataList; // Commented by Praba on 07-Jan-2015 for Barcode Testing ****************************88
                cmbItemName.DataSource = DtItem;

                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemNo";
                //commented on 25 april 2014,to filter the place on item number list 
                // cmbItemNo.DataSource = LoadDataList
                // cmbItemNo.DataSource = LoadDataList.Where(i => i.ItemNumber != string.Empty).ToList(); // Commented by Praba on 07-Jan-2015 for Barcode Testing ****************************88
                DataView dv = new DataView(DtItem);
                dv.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dv.ToTable();
                //cmbItemNo.DisplayMember = "ItemNo";
                // cmbItemNo.ValueMember = "ItemName";

                if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
                {
                   // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
                   // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
                }
                cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = -1;
                txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);

                ObjHelper.LoadPurchseInvoiceData();

                if (ObjHelper.isFromelse)
                {
                    txtInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString();
                    txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID.ToString();
                }
                else
                {

                    if (ObjHelper.ObjBALClass.ObjPurchase.Status == 2)
                    {
                        this.ClearAll();
                        ClosedStatus();
                    }
                    else
                    {
                        //txtDiscount.ReadOnly = txtDiscount.Enabled = false;
                        lblUservalue.Text = GeneralFunction.UserName;
                        dtpDate.Value = Convert.ToDateTime(DateTime.Now);
                        PurchaseOptionSetting();
                        this.ClearAll();
                    }
                    SetControlfromObject();
                    DataGridSource();
                }
                isFromLoad = false;
                this.cmbCategory.SelectedIndexChanged += new EventHandler(this.cmbCategory_SelectedIndexChanged);
                this.cmbCompany.SelectedIndexChanged += new EventHandler(this.cmbCompany_SelectedIndexChanged);
                rbnPercentage.CheckedChanged += new EventHandler(this.rbnPercentage_CheckedChanged);
                txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
                cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
                ////added on 22042014
                // cmbItemName.SelectedIndexChanged+=new EventHandler(cmbItemName_SelectedIndexChanged);
                ///
                // this.cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
                if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts); }
                //CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(Rtxt_NotesAndAlerts); this to be Implemented
                //CustomNotesAlerts.Set_NotesAlertDetails(Rtxt_NotesAndAlerts);
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            finally
            {
                //LoadDataList = null; // Commented by Praba on 07-Jan-2015 for Barcode Testing ****************************88
            }

        }

        private void AssignCategoryCompany()
        {
            cmbCategory.SelectedIndexChanged -= new EventHandler(this.cmbCategory_SelectedIndexChanged);
            cmbCategory.DataSource = null;
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;
            cmbCompany.SelectedIndexChanged -= new EventHandler(this.cmbCompany_SelectedIndexChanged);
            cmbCompany.DataSource = null;
            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;
        }

        private void ClosedStatus()
        {
            rbnPercentage.CheckedChanged -= new EventHandler(this.rbnPercentage_CheckedChanged);
            dtpDate.Value = Convert.ToDateTime(ObjHelper.ObjBALClass.ObjPurchase.PurchaseItemDate);
            dgvPurchaseInvoiceData.BackgroundColor = Color.Gray;
            dgvPurchaseInvoiceData.DefaultCellStyle.BackColor = Color.Gainsboro;
            txtDiscount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = txtExtraCost.Enabled = false;
            lblUservalue.Text = GeneralFunction.UserName;
            lblUservalue.ForeColor = Color.Blue;
            ObjHelper.ObjBALClass.ObjPurchase.ItemCost = 0;
        }
        #endregion

        #region SetObject Methods

        private void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim() == string.Empty ? "0" : txtInvoiceNo.Text);
            ObjHelper.ObjBALClass.ObjPurchase.InNo = string.IsNullOrEmpty(txtInNo.Text) ? "" : txtInNo.Text;
            ObjHelper.ObjBALClass.ObjPurchase.ItemName = cmbItemName.Text.ToString();
            itemnoforrowfocus = ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(cmbItemName.SelectedValue == null ? "0" : cmbItemName.SelectedValue);
            ObjHelper.ObjBALClass.ObjPurchase.SupplierName = cmbSupplierName.Text.ToString();
            ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = Convert.ToInt32(cmbSupplierNo.Text == string.Empty ? "0" : cmbSupplierNo.Text); //Convert.ToInt32(cmbSupplierName.SelectedValue == null ? "0" : cmbSupplierName.SelectedValue);
            ObjHelper.ObjBALClass.ObjPurchase.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty || txtCost.Text.Trim() == "." ? "0" : txtCost.Text.Trim());
            if (!string.IsNullOrEmpty(txtExchangeRate.Text))
                ObjHelper.ObjBALClass.ObjPurchase.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
            else
                ObjHelper.ObjBALClass.ObjPurchase.ExchangeRate = 0;
            if (ObjHelper.ObjBALClass.ObjPurchase.ItemType == 1)
            {
                LocalDatime = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = (Convert.ToDateTime(dtpExpiry.Value)).Date;
                ObjHelper.ObjBALClass.ObjPurchase.ItemExpiry = dtpExpiry.Value.ToShortDateString();
            }
            else
            {
                ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = null;
                ObjHelper.ObjBALClass.ObjPurchase.ItemExpiry = null;
            }
            ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity = Convert.ToInt32(txtQuantity.Text == string.Empty ? "0" : txtQuantity.Text);
            ObjHelper.ObjBALClass.ObjPurchase.ItemStock = Convert.ToInt32(txtStock.Text == String.Empty ? "0" : txtStock.Text);
            ObjHelper.ObjBALClass.ObjPurchase.ItemPrice = Convert.ToDecimal(txtPrice.Text == String.Empty || txtPrice.Text == "." ? "0" : txtPrice.Text);

            ObjHelper.ObjBALClass.ObjPurchase.ItemTotal = Convert.ToDecimal(txtTotal.Text == string.Empty ? "0" : txtTotal.Text);
            ObjHelper.ObjBALClass.ObjPurchase.ItemPackage = Convert.ToInt32(txtTotalStock.Text == string.Empty ? "0" : txtTotalStock.Text);
            ObjHelper.ObjBALClass.ObjPurchase.ItemDiscount = Convert.ToDecimal(txtDiscount.Text == string.Empty ? "0" : txtDiscount.Text);
            ObjHelper.ObjBALClass.ObjPurchase.Discount = Convert.ToDecimal(txtDiscount.Text == string.Empty ? "0" : txtDiscount.Text);
            ObjHelper.ObjBALClass.ObjPurchase.Note = txtNote.Text.Trim();
            ObjHelper.ObjBALClass.ObjPurchase.originaldiscount = Convert.ToDecimal(txtDiscount.Text.Trim() != string.Empty ? txtDiscount.Text : "0");
            ObjHelper.ObjBALClass.ObjPurchase.ItemNet = Convert.ToDecimal(txtNet.Text == string.Empty ? "0" : txtNet.Text);
            ObjHelper.ObjBALClass.ObjPurchase.PurchaseItemDate = dtpDate.Value;
            if (rbnPercentage.Checked == true)
                ObjHelper.ObjBALClass.ObjPurchase.DiscountType = 0;
            else
                ObjHelper.ObjBALClass.ObjPurchase.DiscountType = 1;
            ObjHelper.ObjBALClass.ObjPurchase.IncludeTax = chkIncludeTax.Checked == true ? true : false;
            ObjHelper.ObjBALClass.ObjPurchase.SetPaymentDate = chkPaymentDate.Checked == true ? true : false;
            ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate = chkPaymentDate.Checked == true ? dtpPaymentDate.Value.Date : Convert.ToDateTime(null);
            ObjHelper.ObjBALClass.ObjPurchase.ItemGrossAmt = Convert.ToDecimal(txtExtraCost.Text == string.Empty ? "0" : txtExtraCost.Text);
            ObjHelper.ObjBALClass.ObjPurchase.ItemNumber = cmbItemNo.Text;
            if (ObjHelper.isPackage == false)
            {
                ObjHelper.ItemCost = Convert.ToDecimal((txtCost.Text == string.Empty || txtCost.Text == null || txtCost.Text == ".") ? "0" : txtCost.Text);
                //ObjHelper.ItemUnitPrice = 0.000m;
            }
            else
            {
                ObjHelper.ItemUnitPrice = Convert.ToDecimal((txtCost.Text == string.Empty || txtCost.Text == null || txtCost.Text == ".") ? "0" : txtCost.Text);
                // ObjHelper.ItemCost = 0.000m;
            }
        }

        private void SetControlfromObject()
        {
            txtInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString();
            txtInNo.Text = ObjHelper.ObjBALClass.ObjPurchase.InNo;
            if (ObjHelper.ID[2] == ObjHelper.ObjBALClass.ObjPurchase.Year)
            {
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID.ToString();
            }
            else
            {
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchase.Year.ToString() + '-' + ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID.ToString();
            }
            // cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
            isFromLoad = true;
            cmbItemName.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemName;//ObjHelper.ObjBALClass.ObjPurchase.ItemNo == null ? 0 : ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
            // cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            cmbSupplierName.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierName == null ? string.Empty : ObjHelper.ObjBALClass.ObjPurchase.SupplierName;
            cmbSupplierNo.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierNo.ToString() == string.Empty ? "0" : ObjHelper.ObjBALClass.ObjPurchase.SupplierNo == 0 ? string.Empty : ObjHelper.ObjBALClass.ObjPurchase.SupplierNo.ToString();
            isFromLoad = false;
            txtExchangeRate.Text = ObjHelper.ObjBALClass.ObjPurchase.ExchangeRate.ToString();
            txtCost.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemCost * 1000m) / 1000m).ToString("#####0.000");

            actualCostVal = string.IsNullOrEmpty(txtCost.Text) ? 0 : decimal.Parse(txtCost.Text);

            //dtpExpiry.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.ToString();
            txtQuantity.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity.ToString();
            txtStock.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemStock.ToString();

            // Update Price on 19-Feb-2019
            if (ObjHelper.PackageQty.Count > 0)
            {
                var ip = ObjHelper.PackageQty.Where(a => a.ItemPackage == ObjHelper.ObjBALClass.ObjPurchase.ItemPackage).FirstOrDefault();
                ObjHelper.ObjBALClass.ObjPurchase.ItemPrice = ip == null ? ObjHelper.ObjBALClass.ObjPurchase.ItemPrice : ip.ItemPrice;
            }
            //
            AutoPriceCalculation();
            //txtPrice.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemPrice * 1000m) / 1000m).ToString("#####0.000");
            //dtpPaymentDate.Text = ObjHelper.ObjBALClass.ObjPurchase.SetPaymentDate.ToString();
            txtTotal.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
            txtTotalStock.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemPackage.ToString();

            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            txtDiscount.Text = ((ObjHelper.ObjBALClass.ObjPurchase.originaldiscount * 1000) / 1000m).ToString("#####0.000");
            txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
            txtNote.Text = ObjHelper.ObjBALClass.ObjPurchase.Note;
            txtNet.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemNet * 1000m) / 1000m).ToString("#####0.000");
            if (ObjHelper.ObjBALClass.ObjPurchase.DiscountType == 1)
                rbnValue.Checked = true;
            else
                rbnPercentage.Checked = true;
            dtpDate.Value = ObjHelper.ObjBALClass.ObjPurchase.PurchaseItemDate.Value == DateTime.MinValue ? DateTime.Now : Convert.ToDateTime(ObjHelper.ObjBALClass.ObjPurchase.PurchaseItemDate);
            txtExtraCost.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemGrossAmt * 1000m) / 1000m).ToString("#####0.000");
            // cmbItemNo.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemName == null ? string.Empty : ObjHelper.ObjBALClass.ObjPurchase.ItemName;
            /////cmbItemNo.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemNo.ToString() == "0" ? string.Empty : ObjHelper.ObjBALClass.ObjPurchase.ItemNo.ToString();
            /////cmbItemNo.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo.ToString() == "0" ? string.Empty : ObjHelper.ObjBALClass.ObjPurchase.ItemNo.ToString();
            //cmbItemNo.SelectedValue = cmbItemName.SelectedValue == null ? string.Empty : cmbItemName.SelectedValue;Commended on 23/05/2014
            cmbItemNo.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemNumber;
            dtpPaymentDate.Value = Convert.ToDateTime(ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate == DateTime.MinValue || ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate == null ? DateTime.Now : ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate);//Changed (Convert.ToDatetime)on 29-May-2014 for Date Format issue
            chkIncludeTax.Checked = ((GeneralOptionSetting.FlagTax1_ApplyPurchase == "Y") | (GeneralOptionSetting.FlagTax2_ApplyPurchase == "Y")) ? true : false;
            if (ObjHelper.isFromGridUpdate)
                chkIncludeTax.Checked = false;
            //if (ObjHelper.isPackage == false)
            //    ObjHelper.ItemCost = Convert.ToDecimal(txtCost.Text);
            //else
            //    ObjHelper.ItemUnitPrice = Convert.ToDecimal(txtCost.Text);
        }

        private void SetLanguage()
        {
            // IPurchaseView purchaseView = PurchaseViewAbstract.GetPurchaseView("Invoice");
            // purchaseView.CloseInvoice();
            var cat = Additional_Barcode.GetValueByResourceKey("Category");
            lblCategory.Text = cat;

            var com = Additional_Barcode.GetValueByResourceKey("Company");
            lblCompany.Text = com;
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "        ";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintF6") + "       ";
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnI");
            this.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            lblSupplier.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            lblSupplierNo.Text = Additional_Barcode.GetValueByResourceKey("SupplierNo");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            chkHideLogo.Text = Additional_Barcode.GetValueByResourceKey("HidenLogo");
            chkNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            chkPrintPerview.Text = Additional_Barcode.GetValueByResourceKey("PP");
            chkIncludeTax.Text = Additional_Barcode.GetValueByResourceKey("IncludeTax");
            rbnPercentage.Text = Additional_Barcode.GetValueByResourceKey("Persentage");
            rbnValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            btnBox.Text = Additional_Barcode.GetValueByResourceKey("BoxF9");
            grbNotesAndAlert.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            btnInsertItem.Text = Additional_Barcode.GetValueByResourceKey("InsertItemF3") + "        ";
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet") + "     ";
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInvoice") + "        ";
            btnFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice") + "     ";
            btnItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11") + "   ";
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice") + "      ";
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInvoice") + "     ";
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem") + "        ";
            btnDeleteItem.Text = Additional_Barcode.GetValueByResourceKey("DeleteF2") + "        ";
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnPayReceipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceiptF8");
            btnPrintBarcode.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            btnImportInvoice.Text = Additional_Barcode.GetValueByResourceKey("ImportInvoice");
            lblExtraCost.Text = Additional_Barcode.GetValueByResourceKey("ExtraCost");
            chkPaymentDate.Text = Additional_Barcode.GetValueByResourceKey("PayDate");
            btnSet.Text = Additional_Barcode.GetValueByResourceKey("Set");
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblNet.Text = Additional_Barcode.GetValueByResourceKey("Net");
            lblExchangeRate.Text = Additional_Barcode.GetValueByResourceKey("ExchangeRate");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            chkHideDebt.Text = Additional_Barcode.GetValueByResourceKey("HideDebt");
            lblInNo.Text = Additional_Barcode.GetValueByResourceKey("InNo");
            dgvPurchaseInvoiceData.Columns["item_name"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvPurchaseInvoiceData.Columns["exp_date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvPurchaseInvoiceData.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvPurchaseInvoiceData.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgvPurchaseInvoiceData.Columns["unit_Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvPurchaseInvoiceData.Columns["sub_total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvPurchaseInvoiceData.Columns["serialno"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
            dgvPurchaseInvoiceData.Columns["box"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            dgvPurchaseInvoiceData.Columns["itemno"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvPurchaseInvoiceData.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvPurchaseInvoiceData.Columns["in_time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
        }

        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {

                Properties.Settings.Default.Save();
                //foreach (Control cti in tableLayoutPanel1.Controls)
                //{
                //    (from Control ctrl in cti.Controls
                //     select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                //}
                //foreach (Control cti in TableLayout2.Controls)
                //{

                //    (from Control ctrl in cti.Controls
                //     select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                //}
                //for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                //{
                //    for (int j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                //    {
                //        Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                //        if (c != null)
                //        {
                //            foreach (Control ct in c.Controls)
                //            {
                //                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                //                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                //                else if (ct is Panel)
                //                {
                //                   foreach(Control ctl in c.Controls)
                //                       if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox || ctl is TabControl || ctl is TabPage)
                //                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                //                }
                //            }
                //        }
                //    }
                //}


                foreach (Control ctl in panel1.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);

                }
                foreach (Control ctl in panel5.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                //foreach (Control ctl in panel3.Controls)
                //{
                //    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox || ctl is TabControl || ctl is TabPage)
                //        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                //}
                foreach (Control ctl in panel4.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);

                }
                dgvPurchaseInvoiceData.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }
        #endregion

        #region Events

        #region Button Events
        private void Purchase_Invoice_Load(object sender, EventArgs e)
        {
            cmbItemName.MatchingMethod = StringMatchingMethod.UseRegexs;
            cmbSupplierName.MatchingMethod = StringMatchingMethod.UseRegexs;
            //GeneralFunction.Trace("Purchase_Invoice_Load Start");
            if (IDFromBalanceSheet.Length != 0 && IDFromBalanceSheet != null)
            {
                // txtNewInvoiceNo.Text = IDFromBalanceSheet; this line Commended on 12/06/2014
                this.GetInvoiceDetails();

            }

            //cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dtallBarcode = new DataTable();
            dtallBarcode = GeneralFunction.GetAllBarcode();

            this.btnImportInvoice.Visible = GeneralOptionSetting.FlagPurchase_HideImportExport == "Y" ? false : true;
            //GeneralFunction.Trace("Purchase_Invoice_Load End");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                this.DefaultValue();
                ////ObjectHelper.PurchaseObjectClass obj = new PurchaseObjectClass();   // Performance issue tuning by praba on 18Nov
                ////obj = null;
                dgvPurchaseInvoiceData.DataSource = null;
                ObjHelper.InsertDetails.Clear();
                ObjHelper.NewbtnYearInvoice();
                txtInvoiceNo.Text = ObjHelper.InvoiceID[0].ToString();
                txtNewInvoiceNo.Text = ObjHelper.InvoiceID[2].ToString();// ObjHelper.InvoiceID[1].ToString() //+ '-' +
                ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(ObjHelper.InvoiceID[2]);
                if (dgvPurchaseInvoiceData.Rows.Count <= 0)
                {
                    ObjHelper.IsfromNewInv = true;
                    this.SetObjectFromControl();
                    ObjHelper.SavePurchaseDetails();
                    dgvPurchaseInvoiceData.BackgroundColor = Color.WhiteSmoke; //''Commented on 27 Feb 2017 based on client requirements
                    //dgvPurchaseInvoiceData.BackgroundColor = Color.WhiteSmoke;
                    dgvPurchaseInvoiceData.DefaultCellStyle.BackColor = Color.White;
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.New), ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Purchase", "New purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    txtDiscount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = (GeneralOptionSetting.FlagShowDiscountFiled == "Y") ? true : false;
                    txtExtraCost.Enabled = true;
                }
                cmbItemName.Focus();//Added on 30-June-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        //bool IsAfterInsertItem = false;
        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    ObjHelper.DgvColor = dgvPurchaseInvoiceData.BackgroundColor.ToString();
                    ObjHelper.DgvCount = dgvPurchaseInvoiceData.Rows.Count;
                    txtDiscount.Text = "0.000";
                    if (cmbSupplierName.SelectedIndex == -1 && ObjHelper.ObjBALClass.ObjPurchase.SupplierName != string.Empty)
                    {
                        if (GeneralFunction.Question("Doyouwanttosavenewuser", "PurchaseInvoice") == DialogResult.Yes)
                        {
                            if (ObjHelper.SaveNewAgent())
                            {
                                cmbSupplierName.DataSource = null;
                                cmbSupplierNo.DataSource = null;
                                AssignSupplierDataSource();
                                ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = ObjectHelper.GeneralObjectClass.SupplierDetails.Max(a => a.AgentId);
                                cmbSupplierNo.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierNo.ToString();
                            }
                            else
                                return;
                        }
                        else
                            return;
                    }
                    if (cmbItemName.SelectedIndex != -1)
                        ObjHelper.CheckInsertItem();
                    if (ObjHelper.ProgressStatus == true)
                    {
                        cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                        DefaultValue();
                        this.DataGridSource();
                        cmbSupplierName.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierName;
                        cmbSupplierNo.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierNo.ToString();
                        cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                        cmbItemNo.SelectedIndex = cmbItemName.SelectedIndex = -1;
                        ObjHelper.ProgressStatus = false;
                        cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                        txtDiscount.Text = ObjectHelper.GeneralObjectClass.SupplierDetails.Where(a => a.AgentId == ObjHelper.ObjBALClass.ObjPurchase.SupplierNo).ToList()[0].Discount.ToString("#####0.000");
                        rbnPercentage.Checked = true;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), ObjHelper.ObjBALClass.ObjPurchase.ItemName + " " + ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Insert purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        if (ObjHelper.ObjBALClass.ObjPurchase.ItemCost > ObjHelper.ObjBALClass.ObjPurchase.ItemPrice)
                            GeneralFunction.Information("CostGreaterthanSalePrice", "PurchaseInvoice");
                        //SetLastRowColor(); // Comment on 25-Dec-2018
                        //isfrominsert = true;
                        cmbItemName.Focus();
                        //isfrominsert = false;
                        //IsAfterInsertItem = true;
                        // if (ObjHelper.StockSold != 0)
                        // {
                        //this.Controls.Clear();
                        ReInitialize();
                        // LoadData();
                        SetLastRowColor();
                        //  }
                    }
                    else
                    {
                        if (ObjHelper.ControlName != null && ObjHelper.ControlName != string.Empty)
                        {
                            if (ObjHelper.ControlName.Contains("txt"))
                            {
                                foreach (MaskedTextBox cti in panel5.Controls.OfType<MaskedTextBox>())
                                {
                                    if (cti.Name == ObjHelper.ControlName)
                                        cti.Focus();
                                }
                            }
                            else if (ObjHelper.ControlName.Contains("cmb"))
                            {
                                foreach (ComboBox cti in panel5.Controls.OfType<ComboBox>())
                                {
                                    if (cti.Name == ObjHelper.ControlName)
                                        cti.Focus();
                                }
                            }
                            else
                            {
                                foreach (DateTimePicker cti in panel5.Controls.OfType<DateTimePicker>())
                                {
                                    if (cti.Name == ObjHelper.ControlName)
                                        cti.Focus();
                                }
                            }
                            ObjHelper.ControlName = string.Empty;
                        }

                        //this.Controls[ObjHelper.ControlName].Focus();
                        //((ObjHelper.ControlName) as Control).Focus();
                        // this.Controls.Find(ObjHelper.ControlName, true)
                        // this.Controls.Find(ObjHelper.ControlName, true)[0].Focus();
                        //foreach (Control c in this.Controls)
                        //{
                        //    //Control c = this.Controls.Find(ObjHelper.ControlName, true).Focu;

                        //    //if (c is Label)
                        //    //    continue;
                        //    if (c.Name == ObjHelper.ControlName)
                        //        c.Focus();
                        //}
                        //this.Controls.Find(ObjHelper.ControlName, true);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                ObjHelper.DgvCount = dgvPurchaseInvoiceData.Rows.Count;
                ObjHelper.DgvColor = dgvPurchaseInvoiceData.BackgroundColor.ToString();
                ObjHelper.btnCloseInvoice();
                if (ObjHelper.ProgressStatus)
                {
                    this.DataGridSource();
                    dgvPurchaseInvoiceData.BackgroundColor = Color.Gray;
                    dgvPurchaseInvoiceData.DefaultCellStyle.BackColor = Color.Gainsboro;
                    //  this.DefaultValue();
                    ObjHelper.ProgressStatus = txtDiscount.Enabled = rbnPercentage.Enabled = rbnValue.Enabled = txtExtraCost.Enabled = false;
                    if (GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y")
                    {
                        btnPrint_Click(sender, EventArgs.Empty);
                    }
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Save(close) purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void btnModifyInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserScreenLimidations.ModifyInvoice == true)
                    check = true;
                else if (UserScreenLimidations.ModifyTodayInvoice == true)
                {

                    // if (dtpDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString()) //Commented on 29-May-2014 for date Format Issue
                    if (DateTime.Compare(Convert.ToDateTime(dtpDate.Value.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString())) == 0)
                        check = true;
                }
                else { check = false; }
                if (check)
                {
                    if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                    {
                        GeneralFunction.Information("NotClosedInvoice", "PurchaseInvoice"); return;
                    }
                    else
                    {
                        ObjHelper.ProgressStatus = false;
                        ObjHelper.btnModifyInvoice();
                        if (ObjHelper.ProgressStatus)
                        {
                            dgvPurchaseInvoiceData.BackgroundColor = Color.WhiteSmoke; //''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                            //dgvPurchaseInvoiceData.BackgroundColor = Color.WhiteSmoke;
                            dgvPurchaseInvoiceData.DefaultCellStyle.BackColor = Color.White;
                            ObjHelper.ObjBALClass.ObjPurchase.Status = 1;
                            dtpPaymentDate.Enabled = btnSet.Enabled = false;
                            ObjHelper.ProgressStatus = txtDiscount.ReadOnly = false;
                            txtExtraCost.Enabled = true;
                            txtDiscount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = (GeneralOptionSetting.FlagShowDiscountFiled == "Y") ? true : false;
                            rbnPercentage.Enabled = UserScreenLimidations.DiscountPerc ? true : false;
                            rbnValue.Enabled = UserScreenLimidations.DiscountAmt ? true : false;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Modify), ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Modify Purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            this.DataGridSource();
                        }
                    }
                }
                else { GeneralFunction.Information("RightsModifyInvoice", "PurchaseInvoice"); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoiceData.BackgroundColor == Color.WhiteSmoke) //''Commented on 27 Feb 2017 based on client requirements
                //if(dgvPurchaseInvoiceData.BackgroundColor == Color.WhiteSmoke) 
                {
                    if (dgvPurchaseInvoiceData.Rows.Count > 0)
                    {
                        if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                        {
                            if (GeneralFunction.Question("AlertDeleteSelectedRow", "PurchaseInvoice") == DialogResult.Yes)
                            {
                                GetGridData();
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjHelper.ObjBALClass.ObjPurchase.ItemName + " " + "Qty-" + ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity + " " + "InvNo-" + ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Delete purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            }
                            else if (GeneralFunction.Question("AlertDeleteWholeRow", "PurchaseInvoice") == DialogResult.Yes)
                            {
                                GetWholeGridData();
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), "InvNo-" + ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Delete purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            }
                        }
                        else
                        {
                            GetWholeGridData();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), "InvNo-" + ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo.ToString(), "Order", "Delete purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }

                    }
                    else
                        GeneralFunction.Information("EmptyInvoiceList", "PurchaseInvoice");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjHelper.ObjItemInfo.Visible == false)
                {
                    if (cmbItemName.Text != string.Empty && cmbItemName.Text != null)
                    {
                        ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt16(cmbItemName.SelectedValue == null ? "0" : cmbItemName.SelectedValue);
                        ObjHelper.ObjItemInfo.ItemName = cmbItemName.Text;
                        ObjHelper.ObjItemInfo.ShowDialog();
                    }
                    else
                    {
                        if (dgvPurchaseInvoiceData.SelectedRows.Count > 0)
                        {
                            ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[0].Cells["itemno"].Value);
                            ObjHelper.ObjItemInfo.ItemName = dgvPurchaseInvoiceData.SelectedRows[0].Cells["item_name"].Value.ToString();
                            ObjHelper.ObjItemInfo.ShowDialog();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Btn_First_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.SetCommonObject();
                ObjHelper.isFromGridUpdate = false;
                ObjHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                ObjHelper.NavigationEvent();
                if (RtxtNotesAndAlerts.Text != string.Empty)
                    RtxtNotesAndAlerts.Text = string.Empty;
                ClearAll();
                ObjHelper.ObjBALClass.ObjPurchase.ItemCost = 0.0m;
                cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                this.SetControlfromObject();
                cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                this.DataGridSource();
                Status();
                cmbItemName.Focus();//Added on 30-June-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate = chkPaymentDate.Checked == true ? Convert.ToDateTime(dtpPaymentDate.Value.Date) : Convert.ToDateTime(null);
                ObjHelper.SetPaymentDate();
                NotesandAlert();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard ObjItemCard = new ItemCard();
            ObjItemCard.ShowDialog();
            LoadNewItems();
        }

        private void LoadNewItems()
        {
            cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
            cmbItemName.DataSource = cmbItemNo.DataSource = null;
            cmbItemName.DisplayMember = "ItemName";
            cmbItemName.ValueMember = "ItemNo";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";
            // List<ObjectHelper.PurchaseObjectClass> lstPurObjCls = ObjHelper.FillItemDetails();
            DataTable data = ObjHelper.LoadItem();
            cmbItemName.DataSource = data;
            DataView dv = new DataView(data);
            dv.RowFilter = "ItemNumber<>''";
            //cmbItemNo.DataSource = lstPurObjCls.Where(a => a.ItemNumber != string.Empty).ToList();
            cmbItemNo.DataSource = dv.ToTable();
            //cmbItemName.DataSource = ObjHelper.FillItemDetails();
            //cmbItemNo.DataSource = (ObjHelper.FillItemDetails()).Where(a => a.ItemNumber != string.Empty).ToList();
            cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            frmBalanceSheet balanceSheet = new frmBalanceSheet();
            if (cmbSupplierName.Text.Length != 0)
            {
                balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmbSupplierNo.Text == string.Empty ? "1001" : cmbSupplierNo.Text);
                balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbSupplierName.Text;
                balanceSheet.ShowDialog();
            }
            else
                balanceSheet.ShowDialog();
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice ObjPurchaseReturn = new PurchaseReturnInvoice();
            ObjPurchaseReturn.ShowDialog();
        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            Find_Purchase_Invoice ObjFindPurchase = new Find_Purchase_Invoice();
            ObjFindPurchase.isOpenFromPurchase = true;
            ObjFindPurchase.ShowDialog();
        }

        private void btnImportInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.ObjPurchase.SupplierName = cmbSupplierName.Text;
                ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = string.IsNullOrEmpty(cmbSupplierNo.Text) ? 0 : Convert.ToInt32(cmbSupplierNo.Text);
                ObjHelper.ObjBALClass.ObjPurchase.InNo = string.IsNullOrEmpty(txtInNo.Text) ? "" : txtInNo.Text;
                if (dgvPurchaseInvoiceData.BackgroundColor == Color.Gray)
                {

                    GeneralFunction.Information("OpenNewInvoice", "PurchaseInvoice");
                    return;
                }
                else
                {
                    ObjHelper.ImportInvoice();
                    LoadNewItems();
                    AssignCategoryCompany();
                    if (ObjHelper.ProgressStatus == true)
                    {
                        cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                        DefaultValue();
                        this.DataGridSource();
                        cmbSupplierName.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierName;
                        cmbSupplierNo.Text = ObjHelper.ObjBALClass.ObjPurchase.SupplierNo.ToString();
                        ObjHelper.ProgressStatus = false;
                    }
                }


            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "Btn_ImportInvoice_Click");
            }

        }

        private void btnPayReceipt_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvPurchaseInvoiceData.BackgroundColor == Color.Gray)
                {
                    if (txtInvoiceNo.Text.ToString() != string.Empty)
                    {
                        //ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                        //ObjHelper.ObjBALClass.ObjPurchase.ItemPaymentDate = chkPaymentDate.Checked == true ? dtpPaymentDate.Value.Date : DateTime.Now;
                        this.SetObjectFromControl();
                        ObjHelper.PayReceipt();
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(this.Text, "");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "Btn_PayRecipt_Click");
            }
        }
        // Update this Function on 18-Feb-2019 Unit change on Button Click
        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.Text = (txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0";
                if (ObjHelper.isPackage == false)
                {
                    //this.SetObjectFromControl();
                    //ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                    ObjHelper.isPackage = true;
                    //this.SetControlfromObject();
                }
                else
                {
                    //this.SetObjectFromControl();
                    //ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                    ObjHelper.isPackage = false;
                    //this.SetControlfromObject();
                }

                int count = txtTotalStock.Items.Count;
                ObjHelper.ObjBALClass.ObjPurchase.TotalPackageCount = count;
                int selectedindex = txtTotalStock.SelectedIndex + 1;
                if (txtTotalStock.Items.Count > 0)
                {
                    if (count == selectedindex)
                    {
                        txtTotalStock.SelectedIndex = 0;
                    }
                    else
                    {
                        txtTotalStock.SelectedIndex++;
                    }
                }

                this.SetObjectFromControl();
                // added this 28-Feb-2019 
                if (ObjHelper.ObjBALClass.ObjPurchase.TotalPackageCount == 1)
                {
                    if (ObjHelper.ObjBALClass.ObjPurchase.ItemPackage > 1)
                        ObjHelper.isPackage = ObjHelper.isPackage == true ? false : true;
                }
                //
                ObjHelper.BoxPieceAction();
                this.SetControlfromObject();

                txtCost.Focus();
                txtCost.SelectAll();

                // 
                cmbItemName.Select(0, 0);
                cmbSupplierName.Select(0, 0);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Key Events

        #region KeyPress Event

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter && cmbItemName.SelectedIndex > -1)
                {
                    string name = ((MaskedTextBox)sender).Name;
                    switch (name)
                    {
                        case "txtCost":
                            if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                            {
                                if (txtCost.Text == ".")
                                    return;
                                if (txtCost.Text != string.Empty && Decimal.Parse(txtCost.Text.ToString()) != 0 && Decimal.Parse(txtCost.Text.ToString()) > Convert.ToDecimal(txtPrice.Text.ToString()))
                                {
                                    if (GeneralFunction.Question("CostGreaterthanSalePrice", "PurchaseInvoice") == DialogResult.Yes)
                                    {
                                        if (GeneralOptionSetting.FlagTabToPrice == "Y")
                                        {
                                            txtPrice.Focus();
                                            txtPrice.SelectAll();
                                        }
                                        else
                                        {
                                            txtQuantity.Focus();
                                            txtQuantity.SelectAll();
                                        }
                                    }
                                    else
                                    {
                                        txtCost.Focus();
                                        txtCost.SelectAll();
                                    }
                                }
                                else
                                {
                                    if (txtCost.Text.Trim() == string.Empty)
                                    {
                                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("ItemCostGreaterthanZero"), "Purchase Invoice");
                                    }
                                    if (GeneralOptionSetting.FlagTabToPrice == "Y")
                                    {
                                        txtPrice.Focus();
                                        txtPrice.SelectAll();
                                    }
                                    else
                                    {
                                        txtQuantity.Focus();
                                        txtQuantity.SelectAll();
                                    }
                                }
                            }
                            else
                            {
                                // GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CantModifyClosedInvoice"), "Purchase Invoice");
                            }
                            break;
                        case "txtPrice":
                            if (cmbItemName.SelectedIndex > -1)
                            {
                                txtQuantity.Focus();
                                txtQuantity.SelectAll();
                            }
                            else
                                cmbItemName.Focus();
                            break;
                        case "txtExtraCost":
                            btnInsertItem.Focus();
                            break;
                        case "txtDiscount":
                            rbnValue.Focus();
                            break;
                    }
                }
                else if (e.KeyChar == (Char)Keys.Enter && cmbItemName.SelectedIndex == -1)
                {

                    txtBarcode.Focus();
                }
                else if (CheckNumbericOnly(e))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 46 && (((MaskedTextBox)sender).Text.Contains('.')))
                    e.Handled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        bool qtyEnter = false;
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (cmbItemName.SelectedIndex > -1 && dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                    {
                        if (dtpExpiry.Visible == true)
                        {
                            dtpExpiry.Focus();
                        }
                        else
                        {
                            this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                            e.Handled = false;
                            qtyEnter = true;
                            cmbItemName.Focus();
                        }
                    }
                    else
                    {
                        qtyEnter = true;
                        cmbItemName.Focus();

                    }

                }
                else if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\u0008') && (e.KeyChar != '\u007f') || (txtQuantity.Text.Length > 7))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Purchase Invoice");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void dtpExpiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                {
                    this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                    qtyEnter = true;
                }
                else if (CheckNumbericOnly(e) == true)
                {
                    e.Handled = true;
                    dtpExpiry.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbSupplierNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string name = ((ComboBox)sender).Name;
                //if (e.KeyChar != 13 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
                //    ((ComboBox)sender).DroppedDown = true; this Line Commended to change the DropDown suggest Append by Meena.R on 18Aug2014 t
                //if (((int)e.KeyChar != 13) && (e.KeyChar != (char)Keys.Tab) && (e.KeyChar < 111 || e.KeyChar > 126) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back))
                //{
                //    if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                //    {
                //        if (((ComboBox)sender).DroppedDown == true)
                //            ((ComboBox)sender).DroppedDown = false;
                //    }
                //}
                if (e.KeyChar == 13)
                {
                    switch (name)
                    {
                        case "cmbSupplierNo":
                            cmbItemName.Focus();
                            break;
                        case "cmbSupplierName":
                            cmbItemName.Focus();
                            break;
                        case "cmbItemName":
                            if (cmbItemName.SelectedIndex > -1)
                            {
                                txtCost.Focus();
                                txtCost.SelectAll();
                            }
                            break;
                        case "cmbItemNo":
                            txtCost.Focus();
                            txtCost.SelectAll();
                            break;
                    }
                }
                //else
                //{
                //    switch (name)
                //    {
                //        case "cmbSupplierNo":
                //            if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back))
                //            {
                //                GeneralFunction.Information("OnlyNumbersAllowed", "PurchaseInvoice");
                //                e.Handled = true;
                //            }
                //            break;
                //            //case "cmbItemNo": To allow alpha numeric char Commended on 24/06/2014 By Meena.R
                //            //    if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Delete))
                //            //    {
                //            //        GeneralFunction.Information("OnlyNumbersAllowed", "PurchaseInvoice");
                //            //        e.Handled = true;
                //            //    }
                //            //    break;
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        bool isFirst = false;
        string appval = "";
        //private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {

        //        string name = ((ComboBox)sender).Name;

        //        if (e.KeyValue == 13)
        //        {
        //            switch (name)
        //            {
        //                case "cmbSupplierNo":
        //                    cmbItemName.Focus();
        //                    break;
        //                case "cmbSupplierName":
        //                    cmbItemName.Focus();
        //                    break;
        //                case "cmbItemName":
        //                    //if (cmbItemName.SelectedIndex == -1)
        //                    cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
        //                    //if (cmbItemName.SelectedIndex > -1)
        //                    //{

        //                    //Invoke((Action)(() => { changeAutoMode(); }));
        //                    txtCost.Focus();
        //                    txtCost.SelectAll();

        //                    //}
        //                    //else
        //                    //{
        //                    //    cmbItemName.DroppedDown = false;
        //                    //}
        //                    break;
        //                case "cmbItemNo":
        //                    txtCost.Focus();
        //                    txtCost.SelectAll();
        //                    break;
        //            }
        //        }
        //        else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey) && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control) && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock))
        //        {
        //            if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
        //            {

        //                if (((ComboBox)sender).Name == "cmbItemName" && cmbItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
        //                {

        //                    cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        //                    cmbItemName.SelectedText = ((char)e.KeyValue).ToString();
        //                    //cmbItemName.SelectedIndex=
        //                    cmbItemName.DroppedDown = true;
        //                    //cmbItemName.SelectionStart = 1;
        //                    isFirst = true;
        //                    appval = ((char)e.KeyValue).ToString();
        //                }

        //                else
        //                {
        //                    cmbItemName.DroppedDown = false;
        //                    if (isFirst)
        //                    {
        //                        cmbItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
        //                        isFirst = false;
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        bool isSuggFirst = false;

        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                string name = ((ComboBox)sender).Name;

                if (e.KeyValue == 13)
                {
                    switch (name)
                    {
                        case "cmbSupplierNo":
                            cmbItemName.Focus();
                            break;
                        case "cmbSupplierName":
                            if ((((Control)sender).Name == "cmbSupplierName") && (e.KeyValue == 13) && (cmbSupplierName.SelectedIndex != -1))
                            {
                                cmbItemName.Focus();
                                cmbItemName.Select(0, cmbItemName.Text.Length);
                            }
                            break;
                        case "cmbItemName":
                            ////if (cmbItemName.SelectedIndex == -1)

                            //cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
                            ////if (cmbItemName.SelectedIndex > -1)
                            ////{
                            //txtCost.Focus();
                            //txtCost.SelectAll();
                            //if (isSuggFirst)
                            //{
                            //    cmbItemName_SelectedIndexChanged(null, null);
                            //    isSuggFirst = false;
                            //}

                            ////}
                            ////else
                            ////{
                            ////    cmbItemName.DroppedDown = false;
                            ////}
                            //if (e.KeyValue == 13)
                            //IsAfterInsertItem = false;



                            break;
                        case "cmbItemNo":
                            txtCost.Focus();
                            txtCost.SelectAll();
                            break;
                    }
                }
                //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126)&&(e.KeyCode!=Keys.Shift) &&(e.KeyCode!=Keys.ShiftKey) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))
                //{
                if (e.KeyCode == Keys.F4)
                    e.Handled = true;

                //To hide the two drop down in same time done by Praba on 28-Oct
                //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))
                //{
                //    if (((ComboBox)sender).DataSource != null)
                //    {
                //        if (((ComboBox)sender).DroppedDown == true)
                //            ((ComboBox)sender).DroppedDown = false;
                //    }

                //}

                //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //    (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //    && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //    && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //    && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
                //{


                //if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //    if (((ComboBox)sender).Name == "cmbItemName" && cmbItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //    {
                //        cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //        cmbItemName.SelectedText = ((char)e.KeyValue).ToString();
                //        cmbItemName.DroppedDown = true;
                //        isFirst = true;
                //        appval = ((char)e.KeyValue).ToString();
                //        //cmbItemName.SelectionStart = 1;
                //        isSuggFirst = true;
                //        //cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //        //cmbItemName.Text = ((char)e.KeyValue).ToString();
                //    }
                //    else
                //    {
                //        cmbItemName.DroppedDown = false;
                //        if (isFirst)
                //        {
                //            cmbItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //            isFirst = false;
                //        }
                //        isSuggFirst = false;
                //    }
                //}
                //cmbItemName.AutoCompleteSource = AutoCompleteSource.None;
                //txtCost.Focus();
                //txtCost.SelectAll();
                //switch (name)
                //{
                //    case "cmbSupplierNo":
                //        if (!(e.KeyValue >= 48 && e.KeyValue <= 57) && (e.KeyData != Keys.Delete) && (e.KeyData != Keys.Back))
                //        {
                //           e.Handled = true;
                //           GeneralFunction.ErrInfo("OnlyNumbersAllowed", this.Text);
                //        }
                //        break;
                //    case "cmbItemNo":
                //        if(!(e.KeyValue>=48 && e.KeyValue<=57)&&(e.KeyData!=Keys.Delete)&&(e.KeyData!=Keys.Back))
                //        {
                //            e.Handled = true;
                //            GeneralFunction.ErrInfo("OnlyNumbersAllowed", this.Text);
                //        }
                //        break;
                //}
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtNewInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13 && UserScreenLimidations.InvoiceNavigation)
                {
                    if (txtNewInvoiceNo.Text.Length != 0)
                    {
                        GetInvoiceDetails();
                    }
                }
                else if ((!char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && (e.KeyChar != (char)Keys.Escape))
                //else if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || (e.KeyChar == (char)Keys.Escape)) != true)
                {
                    e.Handled = true;
                    CommonHelper.GeneralFunction.Information("OnlyNumbersAllowed", "PurchaseInvoice");
                    txtNewInvoiceNo.SelectAll();
                    txtNewInvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void GetInvoiceDetails()
        {
            this.GetNewYearReceiptNo();
            ObjHelper.IDFlag = 0;
            if (IDFromBalanceSheet.Length != 0 && IDFromBalanceSheet != null)
            {
                if (frmBalanceSheet.IsNewYear)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(IDFromBalanceSheet);
                    ObjHelper.LoadInvoiceDataBasedOnID();

                }
                else
                {
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(frmBalanceSheet.BalanceSheetPurchaseID);
                    ObjHelper.LoadInvoiceDataBasedOnID();
                }

            }
            else
                ObjHelper.NavigationEvent();
            ClearAll();
            this.SetControlfromObject();
            this.DataGridSource();
            Status();
        }


        #endregion

        #region KeyUp Event
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbItemName.SelectedIndex > -1)
            {
                if ((cmbItemName.Text != string.Empty) && (cmbItemName.SelectedIndex > -1))
                {
                    if (ObjHelper.isPackage == false)
                    {
                        txtStock.Text = ((int.Parse(txtQuantity.Text != string.Empty ? txtQuantity.Text : "0")) + (ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock / (ObjHelper.ObjBALClass.ObjPurchase.ItemPackage != 0 ? ObjHelper.ObjBALClass.ObjPurchase.ItemPackage : 1))).ToString();
                    }
                    else
                    {
                        txtStock.Text = Convert.ToString(int.Parse((txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0") + int.Parse((ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock).ToString()));
                    }
                }
            }
        }
        #endregion

        #region KeyDown Event
        private void Purchase_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
                if (e.KeyCode == Keys.F11 && btnItemInfo.Enabled)
                {
                    this.InvokeOnClick(btnItemInfo, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    if (ObjHelper.ObjItemInfo.Visible == true) ObjHelper.ObjItemInfo.Visible = false;
                }
                if (e.KeyCode == Keys.F4 && btnNewInvoice.Enabled && (!e.Alt))
                {
                    this.InvokeOnClick(btnNewInvoice, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F3 && btnInsertItem.Enabled)
                {
                    this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F2 && btnDeleteItem.Enabled)
                {
                    this.InvokeOnClick(btnDeleteItem, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F5 && btnCloseInvoice.Enabled)
                {
                    this.InvokeOnClick(btnCloseInvoice, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F9 && btnBox.Enabled)
                {
                    this.InvokeOnClick(btnBox, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F6 && btnPrint.Enabled)
                {
                    this.InvokeOnClick(btnPrint, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F8 && btnPayReceipt.Enabled)
                {
                    this.InvokeOnClick(btnPayReceipt, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.F1)
                {
                    PurchaseItemPanel pip = new PurchaseItemPanel();
                    GeneralFunction.PurchaseBarcode = ObjHelper.GenerateBarCode();
                    pip.ShowDialog();
                    GeneralFunction.PurchaseBarcode = string.Empty;
                    ClearBarcodeValues();
                    LoadNewItems();

                    if (pip.IsSaved)
                    {
                        //
                        cmbItemName.SelectedValue = pip.ItemID;
                        txtPrice.Text = pip.Price.ToString();
                        txtCost.Text = pip.Cost.ToString();
                        txtQuantity.Text = pip.Quantity.ToString();
                        if (pip.IsExpiry)
                            dtpExpiry.Value = pip.ExpiryDate;
                        this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                        //
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "purches_invoice_KeyDown");
            }
        }
        #endregion

        #region Leave
        private void txtCost_Leave(object sender, EventArgs e)
        {
            // last code
            #region
            try
            {
                string name = ((MaskedTextBox)sender).Name;
                if (((MaskedTextBox)sender).Text == ".")
                    return;
                Decimal a = ((MaskedTextBox)sender).Text == string.Empty ? 0 : Convert.ToDecimal(((MaskedTextBox)sender).Text);
                switch (name)
                {
                    case "txtCost":
                        if (txtCost.Text != string.Empty && txtCost.Text != null && txtCost.Text.Length <= 9)
                        {
                            a = decimal.Parse(txtCost.Text);
                            // txtCost.Text = Math.Round(a, 11).ToString("N3");
                            txtCost.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                            //txtCost.Text = a.ToString("#####0.0000");

                            // Calculation of Exchange Rate
                            CostCalcuation();
                            // Calculation of auto price
                            AutoPriceCalculation(true);

                        }
                        else
                            txtCost.Text = "0.000";
                        break;
                    case "txtPrice":
                        if (txtPrice.Text != string.Empty && txtPrice.Text != null && txtPrice.Text.Length <= 9)
                            //txtPrice.Text = Decimal.Parse(txtPrice.Text).ToString("#####0.0000");
                            txtPrice.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                        else
                            txtPrice.Text = "0.000";
                        break;
                    case "txtExtraCost":
                        if (txtExtraCost.Text != string.Empty && txtExtraCost.Text != null && txtExtraCost.Text.Length <= 11)
                            // txtExtraCost.Text = Decimal.Parse(txtExtraCost.Text).ToString("#####0.0000");
                            txtExtraCost.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                        else
                            txtExtraCost.Text = "0.000";
                        btnInsertItem.Focus();
                        break;
                    case "txtQuantity":
                        if (txtQuantity.Text == string.Empty && txtQuantity.Text != null && txtQuantity.Text.Length <= 8)
                            txtQuantity.Text = "0";
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            #endregion
        }

        #endregion

        #endregion

        #region CheckBox,ComboBox Change Events
        private void chkNote_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNote.Checked == true)
            {
                txtNote.Enabled = true;
            }
        }

        private void txtNote_MouseClick(object sender, MouseEventArgs e)
        {
            chkNote.Checked = true;
            txtNote.Enabled = true;
        }

        private void txtDiscount_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                {
                    if (UserScreenLimidations.DiscountPerc || UserScreenLimidations.DiscountAmt)
                    {
                        ObjHelper.ObjBALClass.ObjPurchase.Discount = Convert.ToDecimal(txtDiscount.Text == string.Empty ? "0" : txtDiscount.Text);
                        ObjHelper.ObjBALClass.ObjPurchase.DiscountType = rbnValue.Checked == true ? 1 : 0;
                        ObjHelper.DiscountAdjustment();
                        //this.DataGridSource(); //on 26/04/2014 to fix blinking grid data
                        txtTotal.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
                        txtNet.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemNet * 1000m) / 1000m).ToString("######0.000");
                        ObjHelper.InsertDetails = PurchaseInvoiceHelper.SortList(ObjHelper.InsertDetails);
                        //  DataTable dt = GeneralFunction.SortInvoiceDetails(ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(InsertDetails), "ItemDescription", "ItemUnitPrice");
                        DataTable dt = ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(ObjHelper.InsertDetails);
                        dgvPurchaseInvoiceData.DataSource = new BindingContext();
                        dgvPurchaseInvoiceData.DataSource = dt;
                    }
                    else
                        GeneralFunction.Information("NoRightstoDiscount", "PurchaseInvoice");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != -1 && cmbCategory.Text != string.Empty)
            {
                ObjHelper.ObjBALClass.ObjPurchase.AccountID = 1;
                ObjHelper.ObjBALClass.ObjPurchase.CategoryNo = Convert.ToInt32(cmbCategory.SelectedValue);
                BindItemNameCatComID();
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompany.SelectedIndex != -1 && cmbCompany.Text != string.Empty)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.AccountID = 0;
                    ObjHelper.ObjBALClass.ObjPurchase.CategoryNo = (Convert.ToInt32(cmbCompany.SelectedValue));
                    this.BindItemNameCatComID();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chkPaymentDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaymentDate.Checked == true)
            {
                dtpPaymentDate.Enabled = true;
                DateTime dtp = dtpPaymentDate.Value;
                btnSet.Enabled = true;
            }
            else
            {
                dtpPaymentDate.Enabled = false;
                btnSet.Enabled = false;
            }
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFromLoad)
            {
                cmbSupplierNo.Text = (cmbSupplierName.SelectedValue == null || cmbSupplierName.SelectedValue == string.Empty) ? string.Empty : cmbSupplierName.SelectedValue.ToString();
                txtDiscount.Text = (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray && dgvPurchaseInvoiceData.Rows.Count > 0) ? ObjectHelper.GeneralObjectClass.SupplierDetails.Where(a => a.AgentId == Convert.ToInt32(cmbSupplierName.SelectedValue)).ToList()[0].Discount.ToString("#####0.000") : "0.000";
                rbnPercentage.Checked = true;
            }

        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFromLoad)
            {
                //cmbItemNo.Text = cmbItemName.SelectedValue.ToString();
                ObjHelper.PackageQty.Clear();
                this.SetObjectFromControl();
                if (cmbItemName.SelectedIndex > -1)
                {
                    if (cmbItemName.Text != string.Empty)
                    {
                        //  cmbItemName.Text = cmbItemNo.SelectedValue.ToString();
                        this.DefaultValue();
                        ObjHelper.ItemNameSelectedIndexChange();
                        if (ObjHelper.ObjBALClass.ObjPurchase.ExpiryDate == true)
                        {
                            //if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "N")
                            //{
                            if (GeneralOptionSetting.FlagPurchase_DontUseExpiry.Trim() == "N")
                            {
                                dtpExpiry.Visible = true;
                                lblExpiry.Visible = true;
                                ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = LocalDatime.Value;
                            }
                            else
                            {
                                dtpExpiry.Visible = false;
                                lblExpiry.Visible = false;
                                dtpExpiry.Value = LocalDatime.Value;
                            }
                        }
                        else
                        {
                            dtpExpiry.Visible = false;
                            lblExpiry.Visible = false;
                            dtpExpiry.Value = LocalDatime.Value;
                        }
                        ObjHelper.isFromGridUpdate = false;
                        ObjHelper.objSerial.objHelper.isSaveorUpdate = false;
                    }
                    else
                        this.DefaultValue();
                    NotesandAlert();
                    this.ClearAll();
                    this.SetControlfromObject();
                    txtQuantity.Text = "1";
                    if (ObjHelper.PackageQty.Count > 0)
                    {
                        /// txtTotalStock.DataSource = null;
                        txtTotalStock.DisplayMember = "ItemPackage";
                        txtTotalStock.ValueMember = "ItemPackage";
                        //txtTotalStock.SelectedIndexChanged -= new EventHandler(this.txtTotalStock_SelectedIndexChanged);
                        txtTotalStock.DataSource = ObjHelper.PackageQty.Select(a => a.ItemPackage).Distinct().ToList();
                        // txtTotalStock.SelectedIndexChanged += new EventHandler(this.txtTotalStock_SelectedIndexChanged);
                    }
                    SetRowColor(cmbItemName.Text);
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
                else
                {
                    this.DefaultValue();
                    RtxtNotesAndAlerts.Text = string.Empty;
                    if (dgvPurchaseInvoiceData.Rows.Count > 0)
                    {
                        txtTotal.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
                        txtNet.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemNet * 1000m) / 1000m).ToString("######0.000");
                        txtDiscount.Text = ((ObjHelper.ObjBALClass.ObjPurchase.originaldiscount * 1000) / 1000m).ToString("#####0.000");
                    }
                }
                ////////if (cmbItemName.SelectedIndex > -1) This command line to disable the popup 
                ////////{
                ////////    ObjHelper.ObjItemDetails.ShowDialog();///line include for Item pop
                ////////    if (ObjHelper.ObjItemDetails.ItemBound.Count > 0)
                ////////    {
                ////////        ObjHelper.DgvColor = dgvPurchaseInvoiceData.BackgroundColor.ToString();
                ////////        ObjHelper.DgvCount = dgvPurchaseInvoiceData.Rows.Count;
                ////////        ObjHelper.InsertPopupItem();
                ////////        ObjHelper.ObjItemDetails.ItemBound.Clear();
                ////////        if (ObjHelper.ProgressStatus == true)
                ////////            this.DataGridSource();
                ////////    }
                ////////}
                //cmbItemNo.SelectedItem = cmbItemName.SelectedValue.ToString();
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemNo.Text != string.Empty && cmbItemNo.SelectedIndex > -1)
            {
                cmbItemName.SelectedValue = cmbItemNo.SelectedValue;
                //cmbItemNo.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
                cmbItemNo.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemNumber;
            }
        }

        private void NotesandAlert()
        {
            try
            {
                RtxtNotesAndAlerts.Text = string.Empty;

                if (cmbItemName.SelectedIndex > -1)
                {
                    if (ObjHelper.CheckExpiry.Count > 0)
                    {
                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + " " + '\n' + GeneralFunction.ChangeLanguageforCustomMsg("TheItem") + Environment.NewLine + cmbItemName.Text + "\r\n" + GeneralFunction.ChangeLanguageforCustomMsg("ExpiryDate") + "\r\n";
                        for (int i = 0; i < ObjHelper.CheckExpiry.Count; i++)
                        {
                            DateTime Date = Convert.ToDateTime(ObjHelper.CheckExpiry[i].ItemExpiryDate);
                            //string str=string.Empty;
                            //if(Date.ToString().Split(' ').Length>2)
                            //{
                            //    str=Date.ToString().Split(' ')[1];
                            //}
                            //else if (Date.ToString().Split(' ').Length == 2)
                            //{
                            //    str = Date.ToString().Split(' ')[0];
                            //}
                            //else
                            //{
                            //    str = Date.ToString();
                            //}
                            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n " + Date.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                        }
                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n ";

                    }
                    else
                        RtxtNotesAndAlerts.Text = string.Empty;
                    if (ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock >= ObjHelper.ObjBALClass.ObjPurchase.MaxOrder)
                    {
                        RtxtNotesAndAlerts.Text = "";
                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + GeneralFunction.ChangeLanguageforCustomMsg("MaxOrderPoint");
                        RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n";
                    }
                    else
                    {
                        if (RtxtNotesAndAlerts.Text.Contains(GeneralFunction.ChangeLanguageforCustomMsg("MaxOrderPoint")))
                            RtxtNotesAndAlerts.Text.Replace(GeneralFunction.ChangeLanguageforCustomMsg("MaxOrderPoint"), string.Empty);
                    }
                    if (ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock <= ObjHelper.ObjBALClass.ObjPurchase.Reorder)
                    {

                        CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(RtxtNotesAndAlerts);
                    }
                    else
                    {
                        if (RtxtNotesAndAlerts.Text.Contains(GeneralFunction.ChangeLanguageforCustomMsg("ReorderItems")))
                            RtxtNotesAndAlerts.Text.Replace(GeneralFunction.ChangeLanguageforCustomMsg("ReorderItems"), string.Empty);

                    }
                }
                if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts); }
                // Obj_Message.Set_ReorderItemsIn_NoteAlert(Rtxt_NotesAndAlerts);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void rbnPercentage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.Discount = txtDiscount.Text == string.Empty ? 0 : Convert.ToDecimal(txtDiscount.Text);
                    if (UserScreenLimidations.DiscountAmt || UserScreenLimidations.DiscountPerc)
                    {
                        ObjHelper.ObjBALClass.ObjPurchase.DiscountType = rbnValue.Checked == true ? 1 : 0;
                        ObjHelper.DiscountAdjustment();
                        txtTotal.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
                        txtNet.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemNet * 1000m) / 1000m).ToString("######0.000");
                    }
                    else
                    {
                        //rbnPercentage.Checked = true;
                        //ObjHelper.ObjBALClass.ObjPurchase.DiscountType = rbnPercentage.Checked == true ? 1 : 0;
                        //ObjHelper.DiscountAdjustment();
                        txtDiscount.Enabled = false;
                        //GeneralFunction.Information("NoRightstoDiscount", "PurchaseInvoice");
                    }

                    //this.DataGridSource();//15/03/2014 By Meena.R 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region Methods
        private void ClearAll()
        {
            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            //cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
            //cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            //txtInvoiceNo.Text = cmbSupplierName.Text = cmbItemName.Text = cmbItemNo.Text = txtNewInvoiceNo.Text = string.Empty;
            txtInvoiceNo.Text = txtNewInvoiceNo.Text = string.Empty;
            isFromLoad = true;
            cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = -1;
            cmbItemName.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            isFromLoad = false;
            dtpExpiry.Value = LocalDatime.Value; //(ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == null || ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == DateTime.MinValue) ? DateTime.Now : ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value; dtpPaymentDate.Value = DateTime.Now;
            txtCost.Text = txtPrice.Text = string.Empty;
            txtQuantity.Text = txtStock.Text = txtTotalStock.Text = string.Empty;
            chkPaymentDate.Checked = chkIncludeTax.Checked = false;
            chkHideDebt.Checked = chkHideLogo.Checked = chkNote.Checked = false;
            txtNote.Text = txtTotal.Text = string.Empty; //txtDiscount.Enabled = true;
            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            txtDiscount.Text = string.Empty;
            txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
            txtNet.Text = txtExtraCost.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            //cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            //cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            txtTotalStock.DataSource = null;
            txtExchangeRate.Text = string.Empty;
            txtInNo.Text = string.Empty;
        }

        private void DefaultValue()
        {
            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray)
            { rbnValue.Enabled = rbnPercentage.Enabled = (GeneralOptionSetting.FlagShowDiscountFiled == "Y" ? true : false); }
            else { rbnValue.Enabled = rbnPercentage.Enabled = txtExtraCost.Enabled = false; }
            txtCost.Text = txtPrice.Text = "0.000";
            txtDiscount.TextChanged -= new EventHandler(this.txtDiscount_TextChanged);
            txtDiscount.Text = txtQuantity.Text = txtStock.Text = "0";
            txtDiscount.TextChanged += new EventHandler(this.txtDiscount_TextChanged);
            txtTotal.Text = txtNet.Text = "0.000";
            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
            ObjHelper.isPackage = false;
            txtNote.Enabled = false;
            txtTotalStock.SelectedIndexChanged -= new EventHandler(this.txtTotalStock_SelectedIndexChanged);
            txtTotalStock.DataSource = null;
            txtTotalStock.SelectedIndexChanged += new EventHandler(this.txtTotalStock_SelectedIndexChanged);
            RtxtNotesAndAlerts.Text = string.Empty;//added on 03/06/2014
        }

        private void GetGridData()
        {
            try
            {
                for (int i = 0; i < dgvPurchaseInvoiceData.SelectedRows.Count; i++)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                    //i = dgvPurchaseInvoiceData.SelectedRows[0].Index;
                    AssignValuesForObject(i);
                    ObjHelper.DeleteItem();
                }
                ObjHelper.isFromGridUpdate = false;
                if (ObjHelper.ProgressStatus)
                {
                    DataGridSource();
                    ObjHelper.ProgressStatus = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void AssignValuesForObject(int i)
        {
            if (dgvPurchaseInvoiceData.SelectedRows.Count > 0)
            {
                ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[i].Cells["itemno"].Value);
                ObjHelper.ObjBALClass.ObjPurchase.ItemName = dgvPurchaseInvoiceData.SelectedRows[i].Cells["item_name"].Value.ToString();
                ObjHelper.XQuantity = ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[i].Cells["quantity"].Value.ToString());
                if ((dgvPurchaseInvoiceData.SelectedRows[i].Cells["exp_date"].Value.ToString() == "-") | (dgvPurchaseInvoiceData.SelectedRows[i].Cells["exp_date"].Value == null))
                {
                    ObjHelper.XExpiry = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = null;
                }
                else
                {
                    // DateTime expdate = Convert.ToDateTime(Convert.ToDateTime(dgvPurchaseInvoiceData.SelectedRows[i].Cells["exp_date"].Value.ToString()).ToShortDateString());Commended on 13Nov2014
                    DateTime expdate = Convert.ToDateTime(dgvPurchaseInvoiceData.SelectedRows[i].Cells["exp_date"].Value.ToString() == string.Empty ? DateTime.MinValue : dgvPurchaseInvoiceData.SelectedRows[i].Cells["exp_date"].Value);
                    ObjHelper.XExpiry = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = Convert.ToDateTime(expdate);
                }
                ObjHelper.ItemCost = ObjHelper.XCost = ObjHelper.XItemCost = ObjHelper.ObjBALClass.ObjPurchase.ItemCost = Convert.ToDecimal(dgvPurchaseInvoiceData.SelectedRows[i].Cells["Cost"].Value.ToString());
                ObjHelper.objSerial.objHelper.XSerialNo = ObjHelper.XSerialNo = ObjHelper.ObjBALClass.ObjPurchase.ItemSerialNo = dgvPurchaseInvoiceData.SelectedRows[i].Cells["SerialNo"].Value.ToString();
                ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice = Convert.ToDecimal(dgvPurchaseInvoiceData.SelectedRows[i].Cells["unit_price"].Value);
                ObjHelper.ObjBALClass.ObjPurchase.ItemPackage = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[i].Cells["package"].Value);
                ////added
                ObjHelper.XBox = ObjHelper.ObjBALClass.ObjPurchase.Box = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[0].Cells["Box"].Value);
                ObjHelper.listIndex = ObjHelper.InsertDetails.FindIndex(a => (a.ItemNo == ObjHelper.ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjHelper.ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == ((ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == null || ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == DateTime.MinValue) ? "-" : ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ').Length > 2 ? ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[1] : ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToString().Split(' ')[0])) && (a.ItemUnitPrice == ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice) && (a.Box == ObjHelper.ObjBALClass.ObjPurchase.Box) && (a.ItemPackage == ObjHelper.ObjBALClass.ObjPurchase.ItemPackage));
                ObjHelper.XBarcodeID = ObjHelper.InsertDetails[ObjHelper.listIndex].BarcodeID;
            }
            else
                return;
        }

        private void GetWholeGridData()
        {
            try
            {
                //for (int i = 0; i < dgvPurchaseInvoiceData.Rows.Count; i++)
                //{
                //    ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dgvPurchaseInvoiceData.Rows[i].Cells["itemno"].Value);
                //    ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity = Convert.ToInt32(dgvPurchaseInvoiceData.Rows[i].Cells["quantity"].Value.ToString());
                ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                //    if ((dgvPurchaseInvoiceData.Rows[i].Cells["exp_date"].Value.ToString() == "-") | (dgvPurchaseInvoiceData.Rows[i].Cells["exp_date"].Value is DBNull) | (Convert.ToInt64(dgvPurchaseInvoiceData.Rows[i].Cells["SerialNo"].Value) != 0))
                //    {
                //        ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = null;
                //    }
                //    else
                //    {
                //        DateTime expdate = Convert.ToDateTime(Convert.ToDateTime(dgvPurchaseInvoiceData.Rows[i].Cells["exp_date"].Value.ToString()).ToShortDateString());
                //        ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate = Convert.ToDateTime(expdate);
                //    }
                //    ObjHelper.ObjBALClass.ObjPurchase.ItemCost = Convert.ToDecimal(dgvPurchaseInvoiceData.Rows[i].Cells["unit_price"].Value.ToString());
                //    ObjHelper.ObjBALClass.ObjPurchase.ItemSerialNo = Convert.ToInt64(dgvPurchaseInvoiceData.Rows[i].Cells["SerialNo"].Value);
                //    ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice = Convert.ToDecimal(dgvPurchaseInvoiceData.Rows[i].Cells["unit_price"].Value);
                //    ObjHelper.DeleteItem();
                ObjHelper.DeleteWholeRecord();
                ObjHelper.isFromGridUpdate = false;
                if (ObjHelper.ProgressStatus)
                {
                    DataGridSource();
                    ObjHelper.ProgressStatus = false;
                }
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DataGridSource()
        {
            try
            {
                ///1000m/1000m for exact 3 digit
                txtTotal.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
                txtNet.Text = (Math.Truncate(ObjHelper.ObjBALClass.ObjPurchase.ItemNet * 1000m) / 1000m).ToString("######0.000");
                ObjHelper.AssignDataSource(dgvPurchaseInvoiceData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PurchaseOptionSetting()
        {
            dtpExpiry.Visible = lblExpiry.Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry.Trim() == "N" ? true : false);
            txtDiscount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = ((GeneralOptionSetting.FlagShowDiscountFiled == "Y")) ? true : false;
        }

        private void BindItemNameCatComID()
        {
            List<PurchaseObjectClass> ItemList = ObjHelper.GetItemsBasedComCatID();
            if (ItemList.Count > 0)
            {
                this.cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemName.DataSource = cmbItemNo.DataSource = null;
                cmbItemName.DisplayMember = "ItemName";
                cmbItemName.ValueMember = "ItemNo";
                //cmbItemName.DataSource = ItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                cmbItemName.DataSource = ItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending

                cmbItemNo.DisplayMember = "ItemNumber";
                //cmbItemNo.ValueMember = "ItemName";
                cmbItemNo.ValueMember = "ItemNo";
                cmbItemNo.DataSource = ItemList.Where(i => i.ItemNumber != string.Empty).ToList(); ;
                this.cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
            else
            {
                cmbItemName.DataSource = cmbItemNo.DataSource = null;
            }
            // this.DefaultValue();
        }

        private void AssignSupplierDataSource()
        {
            cmbSupplierName.DisplayMember = "Name";
            cmbSupplierName.ValueMember = "AgentID";
            cmbSupplierName.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;
            cmbSupplierNo.DisplayMember = "AgentID";
            cmbSupplierNo.ValueMember = "Name";
            cmbSupplierNo.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;
        }

        private Boolean CheckNumbericOnly(KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)ConsoleKey.Backspace) && (e.KeyChar != (char)ConsoleKey.Delete))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetNewYearReceiptNo()
        {
            if (txtNewInvoiceNo.Text.Contains('-'))
            {
                string[] strNewYearNo = txtNewInvoiceNo.Text.Split('-');
                if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
                {
                    ObjHelper.ObjBALClass.ObjPurchase.Year = Convert.ToInt32(strNewYearNo[0]);
                    ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(strNewYearNo[1]);
                }
                else
                { GeneralFunction.ErrInfo("Invoice ID is not in correct format", "Purchase Invoice"); }
            }
            else
            {
                ObjHelper.ObjBALClass.ObjPurchase.Year = ObjHelper.ObjBALClass.ObjPurchase.Year;
                ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(txtNewInvoiceNo.Text);
            }
        }

        private void Status()
        {
            if (ObjHelper.ObjBALClass.ObjPurchase.Status == 2)
            {
                ClosedStatus();
            }
            else
            {
                //dgvPurchaseInvoiceData.BackgroundColor = Color.Beige; ''Modified on 27 Feb 2017 based on client requirements
                dgvPurchaseInvoiceData.BackgroundColor = Color.WhiteSmoke;
                dgvPurchaseInvoiceData.DefaultCellStyle.BackColor = Color.White;
                txtExtraCost.Enabled = true;
                txtDiscount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = (GeneralOptionSetting.FlagShowDiscountFiled == "Y") ? true : false;
            }
            if (cmbItemName.SelectedIndex != -1)
            {
                cmbItemName.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemName.ToString();
                txtQuantity.Text = "1";
            }
            if (ObjHelper.ObjBALClass.ObjPurchase.originaldiscount != 0.000m)
            { }
            else if (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray && dgvPurchaseInvoiceData.Rows.Count > 0)
            {
                txtDiscount.Text = GeneralObjectClass.SupplierDetails.Where(a => a.AgentId == ObjHelper.ObjBALClass.ObjPurchase.SupplierNo).ToList()[0].Discount.ToString("#####0.000");
                rbnPercentage.Checked = true;
            }
        }
        #endregion

        private void Purchase_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ObjectHelper.PurchaseObjectClass obj = new PurchaseObjectClass();
            this.Dispose();
        }

        private void dgvPurchaseInvoiceData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoiceData.Rows.Count > 0)
                {
                    if (dgvPurchaseInvoiceData.SelectedRows.Count > 0)
                    {
                        ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dgvPurchaseInvoiceData.SelectedRows[0].Cells["itemno"].Value);
                        ObjHelper.ObjBALClass.ObjPurchase.ItemName = dgvPurchaseInvoiceData.SelectedRows[0].Cells["item_name"].Value.ToString();
                        ObjHelper.GridCellDoubleClick();
                    }
                    else
                        return;
                    //ClearAll();
                    if (dgvPurchaseInvoiceData.BackgroundColor == Color.WhiteSmoke)
                    {
                        AssignValuesForObject(0);
                        cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                        ClearAll();
                        //  SetControlfromObject();
                        if (ObjHelper.ObjBALClass.ObjPurchase.Box == 0)
                        {
                            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                            ObjHelper.isPackage = false;
                            ObjHelper.ItemUnitPrice = ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice;
                            //ObjHelper.ItemCost = ObjHelper.ObjBALClass.ObjPurchase.ItemCost;
                            /// ObjHelper.ItemCost = 0.000m;
                            ObjHelper.BoxPieceAction();
                            cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                            SetControlfromObject();
                            cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                            ObjHelper.isPackage = true;
                        }
                        else
                        {
                            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                            ObjHelper.isPackage = true;
                            //ObjHelper.ObjBALClass.ObjPurchase.ItemCost = ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice;
                            ObjHelper.ItemCost = ObjHelper.ObjBALClass.ObjPurchase.ItemCost;
                            //ObjHelper.ItemUnitPrice = 0.000m; ObjHelper.piececost = 0.000m;
                            ObjHelper.BoxPieceAction();
                            cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                            SetControlfromObject();
                            cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                            ObjHelper.isPackage = false;
                        }
                        if (!ObjHelper.isPackage)
                        {
                            // txtStock.Text = (ObjHelper.ObjBALClass.ObjPurchase.ItemStock + ObjHelper.ObjBALClass.ObjPurchase.Box - 1).ToString();
                            txtStock.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemStock.ToString();
                            txtQuantity.Text = ObjHelper.ObjBALClass.ObjPurchase.Box.ToString();
                        }
                        else
                        {
                            //txtStock.Text = (ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock + ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity).ToString();
                            txtStock.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock.ToString();
                            txtQuantity.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemQuantity.ToString();
                        }
                        if (ObjHelper.PackageQty.Count > 0)
                        {
                            /// txtTotalStock.DataSource = null;
                            txtTotalStock.DisplayMember = txtTotalStock.ValueMember = "ItemPackage";
                            txtTotalStock.DataSource = ObjHelper.PackageQty.Select(a => a.ItemPackage).Distinct().ToList();
                            txtTotalStock.Text = ObjHelper.InsertDetails[ObjHelper.listIndex].ItemPackage.ToString();
                        }
                        ObjHelper.isFromGridUpdate = true;
                        ObjHelper.objSerial.objHelper.isSaveorUpdate = true;
                        // ObjHelper.listIndex = ObjHelper.InsertDetails.FindIndex(a => (a.ItemNo == ObjHelper.ObjBALClass.ObjPurchase.ItemNo) && (a.ItemDescription == ObjHelper.ObjBALClass.ObjPurchase.ItemName) && (a.ItemExpiry == ((ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == null || ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate == DateTime.MinValue) ? "-" : ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value.ToShortDateString())) && (a.ItemUnitPrice == ObjHelper.ObjBALClass.ObjPurchase.ItemUnitPrice));
                        cmbItemName.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemName.ToString();
                        cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);
                        if (ObjHelper.ObjBALClass.ObjPurchase.ExpiryDate == false)
                            lblExpiry.Visible = dtpExpiry.Visible = false;
                        else
                        {
                            lblExpiry.Visible = dtpExpiry.Visible = true;
                            //dtpExpiry.Value = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value;commended on 27Aug2014
                            dtpExpiry.Value = ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate != null ? ObjHelper.ObjBALClass.ObjPurchase.ItemExpiryDate.Value : DateTime.Now;//line added to fix null exception
                        }
                        //ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                        //ObjHelper.GridDataUpdate();
                        chkIncludeTax.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "Btn_PayRecipt_Click");
            }
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            ObjHelper.btnPrintBarcode();
        }

        private void blinkTextbox(object sender, EventArgs e)
        {
            //if (RtxtNotesAndAlerts.ForeColor == Color.Blue)
            //    RtxtNotesAndAlerts.ForeColor = Color.Beige;
            //else
            //    RtxtNotesAndAlerts.ForeColor = Color.Blue;
            GeneralFunction.BlinkText(EventArgs.Empty, RtxtNotesAndAlerts);
        }

        private void UserLimitation()
        {
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = UserScreenLimidations.Print == true ? true : false;
            btnFindInvoice.Enabled = UserScreenLimidations.FindPurchaseInvoice == true ? true : false;
            btnReturnItem.Enabled = UserScreenLimidations.PurchaseReturnInvoice == true ? true : false;
            btnBalanceSheet.Enabled = UserScreenLimidations.BalanceSheet == true ? true : false;
            btnItemCard.Enabled = UserScreenLimidations.ItemCard == true ? true : false;
            btnModifyInvoice.Enabled = ((UserScreenLimidations.ModifyInvoice == true) || (UserScreenLimidations.ModifyTodayInvoice == true)) ? true : false;
            btnPrintBarcode.Enabled = UserScreenLimidations.PrintBarcode == true ? true : false;
            Btn_Next.Visible = Btn_Pervious.Visible = Btn_First.Visible = Btn_Last.Visible = UserScreenLimidations.InvoiceNavigation == true ? true : false;
            txtInvoiceNo.ReadOnly = UserScreenLimidations.InvoiceNavigation == true ? false : true;
            txtInvoiceNo.BackColor = Color.White;
            //dgvPurchaseInvoiceData.Columns["itemno"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvPurchaseInvoiceData.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvPurchaseInvoiceData.Columns["exp_date"].Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry == "Y") ? false : true;
            txtTotalStock.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvPurchaseInvoiceData.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            btnBox.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            lblUserName.Visible = (GeneralOptionSetting.FlagPurchase_SaveUsernameOnInvoice == "Y") ? true : false;
            lblUservalue.Visible = (GeneralOptionSetting.FlagPurchase_SaveUsernameOnInvoice == "Y") ? true : false;
            btnPayReceipt.Enabled = (UserScreenLimidations.PayReceipt == true) ? true : false;
            dgvPurchaseInvoiceData.Columns["in_time"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
            rbnValue.Enabled = UserScreenLimidations.DiscountAmt == false ? false : true;
            rbnPercentage.Enabled = UserScreenLimidations.DiscountPerc == false ? false : true;
            if (UserScreenLimidations.DiscountAmt != true && UserScreenLimidations.DiscountPerc != true)
                txtDiscount.Enabled = false;
            btnImportInvoice.Enabled = UserScreenLimidations.Import;
            btnImportInvoice.Visible = GeneralOptionSetting.FlagPurchase_HideImportExport == "Y" ? false : true;
            btnItemInfo.Enabled = UserScreenLimidations.ItemInfo;
            txtTotal.Visible = lblTotal.Visible = txtDiscount.Visible = lblDiscount.Visible = txtNet.Visible = lblNet.Visible = UserScreenLimidations.InvTotalFields;
            //below Added on 30-Oct-2014
            if (UserScreenLimidations.InvTotalFields)
            {
                txtTotal.Visible = lblTotal.Visible = UserScreenLimidations.SubTotalField;
                txtNet.Visible = lblNet.Visible = UserScreenLimidations.TotalField;
            }
            dtpExpiry.Visible = lblExpiry.Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry == "Y") ? false : true;//added on 21Nov2014
            btnDeleteItem.Enabled = UserScreenLimidations.DeleteItem;
        }

        //Live
        //private void tmrBarcode_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ScannerCount += 1;
        //        if (lastFocusedControl != null && lastFocusedControl.Name != "dtpExpiry")  // Purchase invoice scanning exception throws fixed by Praba on 30-Oct
        //        {
        //            lastFocusedControl.Text = lastfocusedvalue;
        //            lastFocusedControl = null;
        //        }
        //        if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
        //        {


        //            tmrBarcode.Enabled = false;
        //            string barcode = Convert.ToString(txtBarcode.Text);
        //            //if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            //{
        //            //    barcode = ScanValue + barcode;
        //            //}

        //            if (barcode.Length < 12)
        //            {
        //                barcode = ScanValue + barcode;
        //            }

        //            //New code changes for Barcode scanning for Performance Fine Tune by Praba on 19Nov2014
        //            //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");

        //            if (DRBarcode != null && DRBarcode.Count() > 0)
        //            {
        //                foreach (DataRow row1 in DRBarcode)
        //                {
        //                    ScanValue = "";
        //                    //cmbItemName.SelectedItem = ObjHelper.ObjBALClass.ObjPurchase.ItemName = dtBarcode.Rows[0]["ItemName"].ToString();
        //                    // cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);this line comment to fix the selected index called More Time on 21Aug2014 by Meena.R
        //                    txtTotalStock.SelectedIndexChanged += new EventHandler(txtTotalStock_SelectedIndexChanged);
        //                    ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(row1["ItemID"]);
        //                    cmbItemName.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
        //                    txtTotalStock.Text = row1["PackageQty"].ToString();
        //                    ObjHelper.ObjBALClass.ObjPurchase.BarcodeID = Convert.ToInt32(row1["BarcodeID"]);
        //                    txtCost.SelectAll();
        //                    txtCost.Focus();
        //                    //txtCost.Text = "0.000";
        //                    //cmbItemName.SelectAll();
        //                    //cmbItemName.Focus();Commended on 08Oct2014 for bacodescanning
        //                    txtCost.SelectAll();
        //                    ClearBarcodeValues();
        //                    if (GeneralOptionSetting.FlagPurchase_AddItemDirectlywithBarcode == "Y")
        //                    {
        //                        btnInsertItem_Click(null, null);
        //                    }
        //                }
        //            }

        //                //The Code for Barcode scanning for Performance Fine Tune by Praba on 19Nov2014
        //            //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            //{
        //            //    ScanValue = "";
        //            //    //cmbItemName.SelectedItem = ObjHelper.ObjBALClass.ObjPurchase.ItemName = dtBarcode.Rows[0]["ItemName"].ToString();
        //            //    // cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);this line comment to fix the selected index called More Time on 21Aug2014 by Meena.R
        //            //    txtTotalStock.SelectedIndexChanged += new EventHandler(txtTotalStock_SelectedIndexChanged);
        //            //    ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dtBarcode.Rows[0]["ItemID"]);
        //            //    cmbItemName.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
        //            //    txtTotalStock.Text = dtBarcode.Rows[0]["PackageQty"].ToString();
        //            //    ObjHelper.ObjBALClass.ObjPurchase.BarcodeID = Convert.ToInt32(dtBarcode.Rows[0]["BarcodeID"]);
        //            //    txtCost.SelectAll();
        //            //    txtCost.Focus();
        //            //    //txtCost.Text = "0.000";
        //            //    //cmbItemName.SelectAll();
        //            //    //cmbItemName.Focus();Commended on 08Oct2014 for bacodescanning
        //            //    txtCost.SelectAll();
        //            //    ClearBarcodeValues();
        //            //    if (GeneralOptionSetting.FlagPurchase_AddItemDirectlywithBarcode == "Y")
        //            //    {
        //            //        btnInsertItem_Click(null, null);
        //            //    }
        //            //}
        //            else
        //            {

        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "PurchaseInvoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                        LoadNewItems();
        //                    }
        //                    else
        //                    {
        //                        txtBarcode.Text = "";
        //                        txtCost.Text = "0.000";
        //                        cmbItemName.Focus();//Added on 30-June-2014 by Seenivasan for BArcode scanning focus
        //                    }
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "PurchaseInvoice");
        //                    txtBarcode.Text = "";
        //                    txtCost.Text = "0.000";
        //                    cmbItemName.Focus();
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
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
        //        throw ex;
        //    }

        //    finally
        //    {
        //        GeneralFunction.Trace("Barcode End");
        //    }
        //}


        //New Barcode

        private void tmrBarcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null && lastFocusedControl.Name != "dtpExpiry")  // Purchase invoice scanning exception throws fixed by Praba on 30-Oct
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

                    //New code changes for Barcode scanning for Performance Fine Tune by Praba on 19Nov2014
                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    //DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");

                    //if (DRBarcode != null && DRBarcode.Count() > 0)
                    //{
                    //    foreach (DataRow row1 in DRBarcode)
                    //    {
                    //        ScanValue = "";
                    //        //cmbItemName.SelectedItem = ObjHelper.ObjBALClass.ObjPurchase.ItemName = dtBarcode.Rows[0]["ItemName"].ToString();
                    //        // cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);this line comment to fix the selected index called More Time on 21Aug2014 by Meena.R
                    //        txtTotalStock.SelectedIndexChanged += new EventHandler(txtTotalStock_SelectedIndexChanged);
                    //        ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(row1["ItemID"]);
                    //        cmbItemName.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
                    //        txtTotalStock.Text = row1["PackageQty"].ToString();
                    //        ObjHelper.ObjBALClass.ObjPurchase.BarcodeID = Convert.ToInt32(row1["BarcodeID"]);
                    //        txtCost.SelectAll();
                    //        txtCost.Focus();
                    //        //txtCost.Text = "0.000";
                    //        //cmbItemName.SelectAll();
                    //        //cmbItemName.Focus();Commended on 08Oct2014 for bacodescanning
                    //        txtCost.SelectAll();
                    //        ClearBarcodeValues();
                    //        if (GeneralOptionSetting.FlagPurchase_AddItemDirectlywithBarcode == "Y")
                    //        {
                    //            btnInsertItem_Click(null, null);
                    //        }
                    //    }
                    //}

                    //The Code for Barcode scanning for Performance Fine Tune by Praba on 19Nov2014
                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        ScanValue = "";
                        //cmbItemName.SelectedItem = ObjHelper.ObjBALClass.ObjPurchase.ItemName = dtBarcode.Rows[0]["ItemName"].ToString();
                        // cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);this line comment to fix the selected index called More Time on 21Aug2014 by Meena.R
                        txtTotalStock.SelectedIndexChanged += new EventHandler(txtTotalStock_SelectedIndexChanged);
                        ObjHelper.ObjBALClass.ObjPurchase.ItemNo = Convert.ToInt32(dtBarcode.Rows[0]["ItemID"]);
                        cmbItemName.SelectedValue = ObjHelper.ObjBALClass.ObjPurchase.ItemNo;
                        txtTotalStock.Text = dtBarcode.Rows[0]["PackageQty"].ToString();
                        ObjHelper.ObjBALClass.ObjPurchase.BarcodeID = Convert.ToInt32(dtBarcode.Rows[0]["BarcodeID"]);
                        txtCost.SelectAll();
                        txtCost.Focus();
                        //txtCost.Text = "0.000";
                        //cmbItemName.SelectAll();
                        //cmbItemName.Focus();Commended on 08Oct2014 for bacodescanning
                        txtCost.SelectAll();
                        ClearBarcodeValues();
                        if (GeneralOptionSetting.FlagPurchase_AddItemDirectlywithBarcode == "Y")
                        {
                            btnInsertItem_Click(null, null);
                        }
                    }
                    else
                    {

                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "PurchaseInvoice") == DialogResult.Yes)
                            {
                                //ItemCard frmItem = new ItemCard();
                                //GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                //frmItem.ShowDialog();
                                //GeneralFunction.PurchaseBarcode = string.Empty;
                                //ClearBarcodeValues();
                                //LoadNewItems();

                                PurchaseItemPanel pip = new PurchaseItemPanel();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                pip.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                                LoadNewItems();

                                if (pip.IsSaved)
                                {
                                    //
                                    cmbItemName.SelectedValue = pip.ItemID;
                                    txtPrice.Text = pip.Price.ToString();
                                    txtCost.Text = pip.Cost.ToString();
                                    txtQuantity.Text = pip.Quantity.ToString();
                                    if (pip.IsExpiry)
                                        dtpExpiry.Value = pip.ExpiryDate;
                                    this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                                    //
                                }
                            }
                            else
                            {
                                txtBarcode.Text = "";
                                txtCost.Text = "0.000";
                                cmbItemName.Focus();//Added on 30-June-2014 by Seenivasan for BArcode scanning focus
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "PurchaseInvoice");
                            txtBarcode.Text = "";
                            txtCost.Text = "0.000";
                            cmbItemName.Focus();
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

            finally
            {
                //GeneralFunction.Trace("Barcode End");
            }
        }

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            ScanLetterStartTime = DateTime.Now;
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {


                //if (txtBarcode.Text.Length > 12)
                //{
                //    GeneralFunction.Trace("Barcode Scanning" + e.KeyValue);
                if (tmrBarcode.Enabled == false)
                {
                    tmrBarcode.Enabled = true;
                }
                // isfromitem = false;
                //}

                //if (e.KeyValue == 13)
                //{
                //    txtCost.Focus();
                //    //txtCost.SelectAll();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode")
        //    {
        //        return;
        //    }
        //    if (ScanValue == string.Empty || ScanValue.Length == 0)
        //    {
        //        //Enable to Timecheck
        //        ScanTimingCheck = true;
        //        ScanLetterStartTime = DateTime.Now;
        //        ScanValue = ScanValue + e.KeyChar.ToString();
        //        return;
        //    }
        //    ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //    if (ScanTimingCheck && ScanValue.Length < 7)
        //    {
        //        //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //        if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //        if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            KeyboardmaxCount = KeyboardmaxCount + 1;
        //        }
        //        else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //        }
        //        else
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //    }
        //    if (ScanValue.Length == 6)
        //    {
        //        qtyEnter = false;
        //        lastFocusedControl = this.ActiveControl;
        //        if (lastFocusedControl != null)
        //        { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

        //        txtBarcode.Focus();
        //        //e.Handled = true;
        //    }
        //    //Cal Event Again

        //    base.OnKeyPress(e);
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                //GeneralFunction.Trace("Barcode Start" + ScanValue);
                if (this.ActiveControl.Name == "txtBarcode") return;
                //GeneralFunction.Errorlogfile("Top Line, ScanValue = " + ScanValue + " ScanLetterStartTime" + ScanLetterStartTime + " TotalMillisecond " + ScanLetterEndTime.TotalMilliseconds, 0, "", "", true);
                if (ScanValue == string.Empty || ScanValue.Length == 0)
                {
                    //Enable to Timecheck
                    ScanTimingCheck = true;
                    ScanLetterStartTime = DateTime.Now;
                    ScanValue = ScanValue + e.KeyChar.ToString();
                    KeyboardmaxCount = 0;
                   // GeneralFunction.Errorlogfile("First Condition, ScanValue = " + ScanValue, 0, "", "", true);
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
                        KeyboardmaxCount = 0;
                        //GeneralFunction.Errorlogfile("Second Condition, ScanValue = " + ScanValue, 0, "", "", true);
                       return;
                    }
                    //if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
                    if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds < GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                        KeyboardmaxCount = KeyboardmaxCount + 1;
                        //GeneralFunction.Errorlogfile("Third Condition, ScanValue = " + ScanValue + " KeyboardmaxCount = " + KeyboardmaxCount + " TotalMillisecond = " + ScanLetterEndTime.TotalMilliseconds, 0, "", "", true);
                    }
                    else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                        //GeneralFunction.Errorlogfile("Foruth Condition, ScanValue = " + ScanValue +  " TotalMillisecond = " + ScanLetterEndTime.TotalMilliseconds, 0, "", "", true);
                    }
                    else
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0;
                        //GeneralFunction.Errorlogfile("Fifth Condition, ScanValue = " + ScanValue + " TotalMillisecond = " + ScanLetterEndTime.TotalMilliseconds, 0, "", "", true);
                        return;
                    }
                }
                if (ScanValue.Length == 6)
                {
                    lastFocusedControl = this.ActiveControl;
                    if (lastFocusedControl != null)
                    { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

                    txtBarcode.Focus();
                    //GeneralFunction.Errorlogfile("Sixth Condition, Active Control = " + lastFocusedControl.Name + " lastfocusedvalue = " + lastfocusedvalue, 0, "", "", true);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") & (dgvPurchaseInvoiceData.BackgroundColor != Color.Gray))
                {
                    GeneralFunction.Information("Pleaseclosetheinvoicefirst", "PurchaseInvoice");
                    return;
                }
                ObjHelper.ObjBALClass.ObjPurchase.Status = chkPrintPerview.Checked ? 1 : 0;
                ObjHelper.ObjBALClass.ObjPurchase.CheckNote = chkNote.Checked ? true : false;
                ObjHelper.ObjBALClass.ObjPurchase.SetStatus = chkHideLogo.Checked ? 1 : 0;
                ObjHelper.ObjBALClass.ObjPurchase.SetPaymentDate = chkHideDebt.Checked ? true : false;
                ObjHelper.ObjBALClass.ObjPurchase.IncludeTax = chkIncludeTax.Checked ? true : false;
                ObjHelper.btnPrint();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "PurchaseInvoice" + " " + ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo, "MTB_ORDER", "Print Purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
            }
            catch (Exception ex)
            {
                // GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void RtxtNotesAndAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = RtxtNotesAndAlerts.SelectedText.Trim();
            if (str == null || str == string.Empty)
            {
                if (cmbSupplierName.SelectedIndex > -1)
                    str = cmbSupplierName.Text;
                else
                    str = ObjectHelper.GeneralObjectClass.SupplierDetails[0].Name;
            }
            ReorderandBalance(str);
        }

        public static void ReorderandBalance(string str)
        {

            if (str.Contains(Additional_Barcode.GetValueByResourceKey("ReOrder")) == true || str.Contains("تنبيه! هذا الصنف وصل الى نقطة اعادة الطلب") && !string.IsNullOrEmpty(str))
            {
                PurchaseInvoiceHelper.ReorderItems();
            }
            else
            {
                if (UserScreenLimidations.BalanceSheet)
                {
                    frmBalanceSheet balanceSheet = new frmBalanceSheet();
                    var l = GeneralObjectClass.AgentDetails.Where(a => a.Name.Contains(str)).ToList();
                    if (l.Count > 0)
                    {
                        balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = l[0].Name;
                        balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = l[0].AgentId;
                        balanceSheet.ShowDialog();
                    }
                    else
                        return;
                }
                else return;
            }
        }

        //private void cmbItemName_DropDown(object sender, EventArgs e) //Commended on 23/06/2014 to fix the combo box blinking
        //{
        //    if (((ComboBox)(sender)).DroppedDown == false)
        //    {
        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //        //cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
        //    }
        //}

        //private void cmbItemName_DropDownClosed(object sender, EventArgs e)
        //{

        //    //cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    switch (((ComboBox)sender).Name)
        //    {
        //        case "cmbItemName":

        //            cmbItemName_SelectedIndexChanged(cmbItemName, new EventArgs());
        //            break;
        //        case "cmbItemNo":
        //            cmbItemNo_SelectedIndexChanged(cmbItemNo, EventArgs.Empty);
        //            break;
        //        case "cmbSupplierName":
        //            cmbSupplierName_SelectedIndexChanged(cmbSupplierName, EventArgs.Empty);
        //            break;
        //        case "cmbSupplierNo":

        //            break;
        //    }
        //}

        private void txtTotalStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTotalStock.SelectedIndex > -1 && txtTotalStock.Text != string.Empty)
            {
                var ItemPrice = ObjHelper.PackageQty.Where(a => a.ItemPackage == Convert.ToInt32(txtTotalStock.Text)).ToList();// == string.Empty ? "0" : txtTotalStock.Text)).ToList();
                if (ItemPrice.Count > 0)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.ItemPrice = ItemPrice[0].ItemPrice;
                    AutoPriceCalculation();
                    //txtPrice.Text = ItemPrice[0].ItemPrice.ToString();
                    ObjHelper.ObjBALClass.ObjPurchase.BarcodeID = ItemPrice[0].BarcodeID;
                    //ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock = ItemPrice[0].ItemTotalStock;//this line commended by Meena.R On 02Aug2014 to Implement the piece can form a Package
                    ObjHelper.ObjBALClass.ObjPurchase.ItemPackage = ItemPrice[0].ItemPackage;//this line added on 20Aug2014
                    ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock = ObjHelper.PackageQty.Sum(a => a.ItemTotalStock);//this line added on 20Aug2014
                    decimal UnitItemCost = Convert.ToDecimal((((ObjHelper.ObjBALClass.ObjPurchase.ItemCardItemCost / (ObjHelper.ObjBALClass.ObjPurchase.ItemCardPackageQty == 0 ? 1 : ObjHelper.ObjBALClass.ObjPurchase.ItemCardPackageQty)) * 1000m) / 1000m).ToString("#####0.000"));
                    if (!ObjHelper.isPackage)
                    {
                        if (ObjHelper.ObjBALClass.ObjPurchase.ItemCardPackageQty == Convert.ToInt32(txtTotalStock.Text))
                            txtCost.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemCardItemCost.ToString();
                        else
                            txtCost.Text = (UnitItemCost * (Convert.ToInt32(txtTotalStock.Text) == 0 ? 1 : Convert.ToInt32(txtTotalStock.Text))).ToString();
                        txtStock.Text = (ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock / (ItemPrice[0].ItemPackage == 0 ? 1 : ItemPrice[0].ItemPackage)).ToString();
                    }
                    else
                    {
                        txtCost.Text = UnitItemCost.ToString();
                        txtStock.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemTotalStock.ToString();
                    }
                    txtQuantity_KeyUp(null, null);
                }
            }
            // Add this line Cost not effecting when Pakcage Change 19-Feb-2019
            actualCostVal = string.IsNullOrEmpty(txtCost.Text) ? 0 : decimal.Parse(txtCost.Text);
            //
            CostCalcuation();
            //
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rbnValue.Focus();
            }
            e.Handled = (txtDiscount.Text.Contains(".") && (e.KeyChar == '.')) || (GeneralFunction.NumericOnly(e)) || ((txtDiscount.Text == string.Empty) && (e.KeyChar == '.')) || (txtDiscount.Text.Length > 10);
        }

        public void SetRowColor(string ComboItemName)
        {
            if (dgvPurchaseInvoiceData.Rows.Count == 0)
                return;
            for (int i = 0; i < dgvPurchaseInvoiceData.Rows.Count; i++)
            {
                dgvPurchaseInvoiceData.Rows[i].Selected = false;
                if (dgvPurchaseInvoiceData.Rows[i].Cells["item_name"].Value.ToString() == ComboItemName)
                {
                    dgvPurchaseInvoiceData.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                    dgvPurchaseInvoiceData.FirstDisplayedScrollingRowIndex = i;
                }
            }

        }



        //private void cmbItemName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if (e.KeyChar != 13)
        //    //{
        //    //    if (cmbItemName.AutoCompleteMode == AutoCompleteMode.None)
        //    //    {
        //    //        cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    //        cmbItemName.AutoCompleteSource = AutoCompleteSource.ListItems;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
        //    //    cmbItemName.AutoCompleteSource = AutoCompleteSource.None;
        //    //}

        //}

        /// <summary>
        /// to hight light tha last inserted item on a grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //private void dgvPurchaseInvoiceData_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvPurchaseInvoiceData.SelectedRows.Count > 0)
        //    {
        //        if (dgvPurchaseInvoiceData.SelectedRows[0].Cells["item_name"].Value.ToString() != "")
        //        {
        //            DataSet dsItem = new DataSet();
        //            dsItem = dgvPurchaseInvoiceData.GetItemNameInfo(GeneralFunction.RemoveApostrophe(dgvPurchaseInvoiceData.SelectedRows[0].Cells["item_name"].Value.ToString()));
        //            dt = dsItem.Tables[0];
        //            dr = new DataRow[0];
        //            if (dt.Rows.Count > 0)
        //            {
        //                dr = dt.Select("MTB_ITEM ='" + GeneralFunction.RemoveApostrophe(dt.Rows[0]["MTB_ITEM"].ToString().Trim()) + "'");
        //            }
        //            ClearItemInfo();
        //            LoadItemInfo();

        //        }
        //    }
        //}

        public void SetLastRowColor()
        {
            //for (int i = 0; i < dgvPurchaseInvoiceData.Rows.Count; i++)
            //{
            //    dgvPurchaseInvoiceData.Rows[i].Selected = false;
            //    //dgrSaleInvoice.Rows[i].DefaultCellStyle.BackColor = Color.White;
            //    //if (dgrSaleInvoice.Rows[i].Cells[2].Value.ToString() == ComboItemName)
            //    //    DgvPerInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            //    dgvPurchaseInvoiceData.Rows[dgvPurchaseInvoiceData.Rows.Count - 1].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            //}

            if (dgvPurchaseInvoiceData.Rows.Count == 0) return;
            if (dgvPurchaseInvoiceData.SelectedRows.Count > 0)
            {
                int rid = dgvPurchaseInvoiceData.SelectedRows[0].Cells["ItemNo"].RowIndex;
                dgvPurchaseInvoiceData.Rows[rid].Selected = false;
            }
            int Index = ObjHelper.InsertDetails.FindIndex(a => (a.ItemNo == itemnoforrowfocus));
            if (Index != -1)
            {
                dgvPurchaseInvoiceData.Rows[Index].Selected = true;
                dgvPurchaseInvoiceData.FirstDisplayedScrollingRowIndex = Index;
            }


        }

        private void cmbItemName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                //string name = ((ComboBox)sender).Name;

                if (e.KeyValue == 13 && cmbItemName.SelectedIndex > -1)
                {
                    //switch (name)
                    //{
                    //    case "cmbItemName":
                    //if (isfrominsert == false && IsAfterInsertItem == false)
                    //    txtBarcode.Focus();
                    //else
                    //{
                    //    isfrominsert = false;
                    //    IsAfterInsertItem = false;
                    //    cmbItemName.Focus();
                    //}

                    //if (((int)e.KeyValue == 13 && qtyEnter == false))
                    //{
                    //    txtBarcode.Focus();
                    //}
                    //else
                    //    qtyEnter = false;
                    //break;

                    //if (e.KeyValue == 13)
                    //{
                    //   if (cmbItemName.SelectedIndex > -1)
                    //   {
                    txtCost.Focus();
                    txtCost.SelectAll();
                    //  }
                    //}

                    //break;
                    //}
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbItemName.SelectedIndex > -1)
                {
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
            }
        }

        private void dtpExpiry_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
            }
        }

        private void txtExchangeRate_Leave(object sender, EventArgs e)
        {
            // Calculation of Exchange Rate
            CostCalcuation();
        }

        private void txtExtraCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckNumbericOnly(e) || txtExtraCost.Text.Length > 6)
            {
                e.Handled = true;
            }
        }

        private void txtCost_KeyUp(object sender, KeyEventArgs e)
        {
            actualCostVal = string.IsNullOrEmpty(txtCost.Text) ? 0 : Convert.ToDecimal(txtCost.Text);
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

        private void txtCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AutoPriceCalculation(true);
        }

        private void cmbSupplierName_Leave(object sender, EventArgs e)
        {
            if (!isFromLoad)
            {
                int SelectedIndex = cmbSupplierName.FindString(cmbSupplierName.Text);
                cmbSupplierName.SelectedIndex = SelectedIndex;
            }
        }

        private void txtInNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && UserScreenLimidations.InvoiceNavigation)
                {
                    if (txtInNo.Text.Length != 0)
                    {
                        //GetInvoiceDetails();
                    }
                }
                else if ((!char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && (e.KeyChar != (char)Keys.Escape))
                {
                    e.Handled = true;
                    CommonHelper.GeneralFunction.Information("OnlyNumbersAllowed", "PurchaseInvoice");
                    txtInNo.SelectAll();
                    txtInNo.Focus();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInvoiceNo_Click(object sender, EventArgs e)
        {

        }

        private void txtNewInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CostCalcuation()
        {

            //Decimal cost = string.IsNullOrEmpty(txtCost.Text) ? 0 : Convert.ToDecimal(txtCost.Text);
            Decimal exchangerate = string.IsNullOrEmpty(txtExchangeRate.Text) ? 0 : Convert.ToDecimal(txtExchangeRate.Text);
            if (exchangerate != 0)
            {
                //decimal c = cost * exchangerate;
                decimal c = actualCostVal * exchangerate;

                txtCost.Text = (Math.Truncate(c * 1000m) / 1000m).ToString("#####0.000");
            }
            else
                txtCost.Text = (Math.Truncate(actualCostVal * 1000m) / 1000m).ToString("#####0.000");


        }

        private void AutoPriceCalculation(bool isFromCostTextBox = false)
        {
            if (GeneralOptionSetting.FlagCHKAutoPriceItem != null && GeneralOptionSetting.FlagCHKAutoPriceItem.ToString() == "Y")
            {
                decimal cost = Convert.ToDecimal(txtCost.Text);
                if (cost > 0)
                {
                    decimal AutoPrice = Convert.ToDecimal(GeneralOptionSetting.FlagTxtAutoPriceItem.ToString());
                    decimal Price = cost + ((cost * AutoPrice) / 100);
                    // Added on 8-Mar-2019 By T
                    if (isFromCostTextBox && cost!= ObjHelper.ObjBALClass.ObjPurchase.ItemCost)
                    {
                        txtPrice.Text = ((Price * 1000m) / 1000m).ToString("#####0.000");
                        ObjHelper.ObjBALClass.ObjPurchase.ItemPrice = Convert.ToDecimal(txtPrice.Text);
                    }
                    else
                    {
                        txtPrice.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemPrice * 1000m) / 1000m).ToString("#####0.000");
                    }
                }
                else
                {
                    if (ObjHelper.ObjBALClass.ObjPurchase.ItemPrice > 0)
                        txtPrice.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemPrice * 1000m) / 1000m).ToString("#####0.000");
                    else
                        txtPrice.Text = "0.000";
                }
            }
            else
            {
                txtPrice.Text = ((ObjHelper.ObjBALClass.ObjPurchase.ItemPrice * 1000m) / 1000m).ToString("#####0.000");
            }
        }
    }
}
