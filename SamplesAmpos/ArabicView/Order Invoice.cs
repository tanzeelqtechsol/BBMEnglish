using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Order_Invoice : Form, IDisposable
    {
        #region Object Initialization
        OrderInvoiceHelper ObjHelper;
        internal string IDFromOthers = string.Empty;
        private DateTime ScanLetterStartTime = DateTime.Now.AddSeconds(-1);
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, iscount = false, isfrominsert = false;
        int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        private bool check;

        private List<PurchaseObjectClass> lstItemDetailsList;
        DataTable OrderItems = new DataTable();
        #endregion

        #region Constructor
        public Order_Invoice()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjHelper = new OrderInvoiceHelper();
            lstItemDetailsList = new List<PurchaseObjectClass>();
            LoadData();
            UserLimitation();
            timer1.Tick += blinkTextbox;
            timer1.Enabled = true;
            timer1.Interval = 650;
        }
        #endregion

        #region SetObject Method
        public void SetLanguage()
        {
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblSupplier.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            lblSupplierNo.Text = Additional_Barcode.GetValueByResourceKey("SupplierNo");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintF6");
            this.Text = Additional_Barcode.GetValueByResourceKey("OrderInvoice");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("DeleteF2");
            chkHideLogo.Text = Additional_Barcode.GetValueByResourceKey("HidenLogo");
            chkNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");
            chkSetDeliveryDate.Text = Additional_Barcode.GetValueByResourceKey("SetDeliDate");
            rbnItemLessthan.Text = Additional_Barcode.GetValueByResourceKey("ItemLessthan");
            rbnReorderItems.Text = Additional_Barcode.GetValueByResourceKey("ReorderItem");
            rbnShowAll.Text = Additional_Barcode.GetValueByResourceKey("ShowAll");
            btnAddItem.Text = Additional_Barcode.GetValueByResourceKey("AddItem");
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInvoice");
            btnFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice");
            btnItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11");
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice");
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInvoice");
            btnPurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem");
            btnSet.Text = Additional_Barcode.GetValueByResourceKey("Set");
            lblPackage.Text = Additional_Barcode.GetValueByResourceKey("Package");
            lblOrderNo.Text = Additional_Barcode.GetValueByResourceKey("OrderNo");
            grpNoteAndAlert.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            grpShowItems.Text = Additional_Barcode.GetValueByResourceKey("ShowItem");
            btnBox.Text = Additional_Barcode.GetValueByResourceKey("BoxF9");
            dgvOrderInvoice.Columns["item_name"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvOrderInvoice.Columns["exp_date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvOrderInvoice.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvOrderInvoice.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgvOrderInvoice.Columns["unit_Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvOrderInvoice.Columns["sub_total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvOrderInvoice.Columns["box"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            dgvOrderInvoice.Columns["itemno"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvOrderInvoice.Columns["in_time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgvOrderInvoice.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
        }

        private void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt32(txtOrderInvoiceNo.Text.Trim() == string.Empty ? "0" : txtOrderInvoiceNo.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemName = cmbItemName.Text.ToString();
            ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(cmbItemName.SelectedValue == null ? "0" : cmbItemName.SelectedValue);
            ObjHelper.ObjBALClass.ObjOrder.SupplierName = cmbSupplierName.Text.ToString();
            ObjHelper.ObjBALClass.ObjOrder.SupplierNo = Convert.ToInt32(cmbSupplierNo.Text == string.Empty ? "0" : cmbSupplierNo.Text); //Convert.ToInt32(cmbSupplierName.SelectedValue == null ? "0" : cmbSupplierName.SelectedValue);
            ObjHelper.ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty ? "0" : txtCost.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(txtQuantity.Text == string.Empty ? "0" : txtQuantity.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemStock = Convert.ToInt32(txtStock.Text == String.Empty ? "0" : txtStock.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemTotal = Convert.ToDecimal(txtOrderTotal.Text == string.Empty ? "0" : txtOrderTotal.Text);
            ObjHelper.ObjBALClass.ObjOrder.OrderNote = txtNote.Text.Trim();
            ObjHelper.ObjBALClass.ObjOrder.OrderDate = dtpOrderDate.Value.Date;
            ObjHelper.ObjBALClass.ObjOrder.ItemNumber = cmbItemNo.Text.Trim().ToString();
            if (chkSetDeliveryDate.Checked)
                ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate = dtpSetDeliveryDate.Value.Date;
            else
                ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate = null;

            //ObjHelper.ObjBALClass.ObjOrder.BarcodeID = txtPackage.SelectedIndex == -1 ? 0 : ObjHelper.PackageQty[txtPackage.SelectedIndex].BarcodeID ; 
            ObjHelper.ObjBALClass.ObjOrder.ItemPackage = txtPackage.Text == string.Empty ? 0 : Convert.ToInt32(txtPackage.Text);
        }

        private void SetControlFromObject()
        {
            txtOrderInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo.ToString();
            if (ObjHelper.ObjBALClass.ObjOrder.Year == ObjHelper.ID[2])
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString();
            else
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString() + '-' + ObjHelper.ObjBALClass.ObjOrder.Year.ToString();
            cmbItemName.SelectedValue = ObjHelper.ObjBALClass.ObjOrder.ItemNo == null ? 0 : ObjHelper.ObjBALClass.ObjOrder.ItemNo;
            // cmbItemNo.Text = ObjHelper.ObjBALClass.ObjOrder.ItemNo.ToString() == "0" ? string.Empty : ObjHelper.ObjBALClass.ObjOrder.ItemNo.ToString();
            // cmbItemNo.Text = string.Empty;
            // cmbItemNo.SelectedValue = ObjHelper.ObjBALClass.ObjOrder.ItemNo == null ? 0 : ObjHelper.ObjBALClass.ObjOrder.ItemNo;
            cmbSupplierName.Text = ObjHelper.ObjBALClass.ObjOrder.SupplierName == null ? string.Empty : ObjHelper.ObjBALClass.ObjOrder.SupplierName;
            cmbSupplierNo.Text = ObjHelper.ObjBALClass.ObjOrder.SupplierNo.ToString() == string.Empty ? "0" : ObjHelper.ObjBALClass.ObjOrder.SupplierNo == 0 ? string.Empty : ObjHelper.ObjBALClass.ObjOrder.SupplierNo.ToString();
            txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("#####0.000");
            txtQuantity.Text = ObjHelper.ObjBALClass.ObjOrder.ItemQuantity == 0 ? "1" : ObjHelper.ObjBALClass.ObjOrder.ItemQuantity.ToString();
            txtStock.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
            txtOrderTotal.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString();
            // txtPackage.Text = ObjHelper.ObjBALClass.ObjOrder.ItemPackage.ToString();
            txtNote.Text = ObjHelper.ObjBALClass.ObjOrder.OrderNote;
            if (ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate == DateTime.MinValue || ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate == null)
            {
                dtpSetDeliveryDate.Value = DateTime.Now.Date;
                chkSetDeliveryDate.Checked = dtpSetDeliveryDate.Enabled = btnSet.Enabled = false;
            }
            else
            {
                dtpSetDeliveryDate.Value = Convert.ToDateTime(ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate == DateTime.MinValue || ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate == null ? DateTime.Now: ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate.Value);
                chkSetDeliveryDate.Checked = dtpSetDeliveryDate.Enabled = btnSet.Enabled = true;
            }
            dtpOrderDate.Value = Convert.ToDateTime(ObjHelper.ObjBALClass.ObjOrder.OrderDate == null ? DateTime.Now: ObjHelper.ObjBALClass.ObjOrder.OrderDate);
            cmbItemNo.Text = ObjHelper.ObjBALClass.ObjOrder.ItemNumber;
            if (ObjHelper.PackageQty.Count > 0)
            {
                txtPackage.ValueMember = "BarcodeID";
                txtPackage.DisplayMember = "ItemPackage";
                txtPackage.DataSource = ObjHelper.PackageQty.Select(a => a.ItemPackage).Distinct().ToList();
                txtPackage.SelectedIndex = 0;
            }
        }
        #endregion

        #region Load Method
        private void LoadData()
        {
            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
            dtpSetDeliveryDate.Format = DateTimePickerFormat.Custom;
            dtpOrderDate.Format = DateTimePickerFormat.Custom;
            dtpSetDeliveryDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpOrderDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//

            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;
            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;
            cmbSupplierName.DisplayMember = "Name";
            cmbSupplierName.ValueMember = "AgentID";
            cmbSupplierName.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;
            cmbSupplierNo.DisplayMember = "AgentID";
            cmbSupplierNo.ValueMember = "Name";
            cmbSupplierNo.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;
            //cmbItemName.DisplayMember = "ItemName";
            //cmbItemName.ValueMember = "ItemNo";
            //cmbItemName.DataSource = ObjHelper.ItemDetailsList();
           // lstItemDetailsList = ObjHelper.ItemDetailsList();
           // cmbItemName.DataSource = lstItemDetailsList;
           // cmbItemNo.BindingContext = new BindingContext();
            //cmbItemNo.DisplayMember = "ItemNumber";
           // cmbItemNo.ValueMember = "ItemNo";
            //cmbItemNo.DataSource = ObjHelper.ItemDetailsList().Where(i => i.ItemNumber != string.Empty).ToList();
           // cmbItemNo.DataSource = lstItemDetailsList.Where(i => i.ItemNumber != string.Empty).ToList();
            AssignItemsource();
            cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = -1;
            //lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
            //lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            ObjHelper.LoadOrderInvoiceData();
            SetControlFromObject();
            this.AssignDataGridSource();
            rbnShowAll.Checked = true;
            cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
            txtNote.MouseClick += new MouseEventHandler(txtNote_MouseClick);
            txtQuantity.KeyUp += new KeyEventHandler(txtQuantity_KeyUp);
            chkSetDeliveryDate.CheckedChanged += new EventHandler(chkSetDeliveryDate_CheckedChanged);
            rbnShowAll.CheckedChanged += new EventHandler(rbnShowAll_CheckedChanged);
            rbnReorderItems.CheckedChanged += new EventHandler(rbnReorderItems_CheckedChanged);
            rbnItemLessthan.CheckedChanged += new EventHandler(rbnItemLessthan_CheckedChanged);
            cmbCategory.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged += new EventHandler(cmbCompany_SelectedIndexChanged);
            cmbSupplierName.SelectedIndexChanged += new EventHandler(cmbSupplier_SelectedIndexChanged);
            cmbSupplierNo.SelectedIndexChanged += new EventHandler(cmbSupplierNo_SelectedIndexChanged);
            cmbItemName.Select();
            cmbItemName.Focus();
            lblUser.Text = GeneralFunction.UserName;
            if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTX_Notes); }
            ScanValue = "0";
            ScanTimingCheck = true;
            ScanLetterStartTime = DateTime.Now;
        }

        private void cmbSupplierNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplierNo.SelectedIndex > -1)
                cmbSupplierName.Text = cmbSupplierNo.SelectedValue.ToString();
        }
        #endregion

        #region Events

        #region Button Click
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            ObjectHelper.PurchaseObjectClass obj;
            try
            {
                obj = new PurchaseObjectClass(); //Performance fine tune by praba on 19-Nov
                ObjHelper.btnNewInvoice();
                if (ObjHelper.isProcessTrue)
                {
                    ClearAll();
                    SetControlFromObject();
                    AssignDataGridSource();
                    this.DefaultValue();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.New), txtOrderInvoiceNo.Text, "Order", "New order invoice details", Convert.ToInt32(InvoiceAction.Yes));
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                obj = null;
            }
        }
        bool IsAfterInsertItem = false;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderInvoice.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    if (cmbItemName.SelectedIndex > -1)
                        ObjHelper.btnAddItemInvoice();
                    if (ObjHelper.isProcessTrue)
                    {
                        DefaultValue();
                        this.AssignDataGridSource();
                        cmbItemNo.SelectedIndex = cmbItemName.SelectedIndex = -1;
                        ObjHelper.isProcessTrue = false;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), ObjHelper.ObjBALClass.ObjOrder.ItemName, "Order", "Insert order invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        isfrominsert = true;
                        cmbItemName.Focus();
                        isfrominsert = false;
                        IsAfterInsertItem = true;
                    }
                    else
                    {
                        if (ObjHelper.ControlName != string.Empty && ObjHelper.ControlName.Length != 0)
                        {
                            foreach (Control cti in panel3.Controls)
                            {
                                if (cti.Name == ObjHelper.ControlName)
                                    cti.Focus();
                            }
                            ObjHelper.ControlName = string.Empty;
                        }
                    }
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
                        if (dgvOrderInvoice.SelectedRows.Count > 0)
                        {
                            ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgvOrderInvoice.SelectedRows[0].Cells["itemno"].Value);
                            ObjHelper.ObjItemInfo.ItemName = dgvOrderInvoice.SelectedRows[0].Cells["item_name"].Value.ToString();
                            ObjHelper.ObjItemInfo.ShowDialog();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.Text = (txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0";
                if (ObjHelper.isPackage == false)
                {
                    this.SetObjectFromControl();
                    ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                    ObjHelper.isPackage = true;
                    //  this.SetControlFromObject();
                    if (ObjHelper.isPackage)
                        txtStock.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                    else
                        txtStock.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();

                }
                else
                {
                    this.SetObjectFromControl();
                    ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                    ObjHelper.isPackage = false;
                    // this.SetControlFromObject();
                    if (ObjHelper.isPackage)
                        txtStock.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                    else
                        txtStock.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();

                }
                txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderInvoice.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                    {
                        if (GeneralFunction.Question("AlertCloseInvoice", "OrderInvoice") == DialogResult.Yes)
                        {
                            ObjHelper.btnCloseInvoice();
                        }
                        else
                            return;
                    }
                    else
                        ObjHelper.btnCloseInvoice();
                    if (ObjHelper.isProcessTrue)
                    {
                        AssignDataGridSource();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), txtOrderInvoiceNo.Text, "Order", "Save(close) order invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    }
                }
                else
                    GeneralFunction.Information("AlreadyInvoiceClosed", "OrderInvoice");

            }
            catch (Exception ex)
            {
                throw ex;
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
                    if (DateTime.Compare(Convert.ToDateTime(dtpOrderDate.Value), Convert.ToDateTime(DateTime.Now.ToShortDateString())) == 0)
                        check = true;
                    else
                        check = false;
                }
                else
                    check = false;
                if (check)
                {
                    //if (dgvOrderInvoice.BackgroundColor != Color.Beige)''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    if (dgvOrderInvoice.BackgroundColor != Color.WhiteSmoke)
                    {
                        ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt64(txtOrderInvoiceNo.Text);
                        if (ObjHelper.btnModifyInvoice())
                        {
                            //dgvOrderInvoice.BackgroundColor = Color.Beige; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                            dgvOrderInvoice.BackgroundColor = Color.WhiteSmoke;
                            dgvOrderInvoice.DefaultCellStyle.BackColor = Color.White;
                            txtNote.Enabled = true;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Modify), txtOrderInvoiceNo.Text, "Order", "Modify order invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NotClosedInvoice"), this.Text);
                }
                else
                    GeneralFunction.Information("RightsModifyInvoice", "OrderInvoice");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderInvoice.BackgroundColor != Color.Gray)
                {
                    if (dgvOrderInvoice.Rows.Count > 0)
                    {
                        if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                        {
                            if (GeneralFunction.Question("AlertDeleteSelectedRow", "OrderInvoice") == DialogResult.Yes)
                            {
                                SetSelectedGridData();
                            }
                            else if (GeneralFunction.Question("AlertDeleteWholeRow", "OrderInvoice") == DialogResult.Yes)
                            {
                                SetWholeGridData();
                            }

                        }
                        else
                        {
                            if (GeneralFunction.Question("AlertDeleteSelectedRow", "OrderInvoice") == DialogResult.Yes)
                            {
                                SetSelectedGridData();
                            }
                        }
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjHelper.ObjBALClass.ObjOrder.ItemName + " " + "Qty-" + ObjHelper.ObjBALClass.ObjOrder.ItemQuantity + " " + "InvNo-" + txtOrderInvoiceNo.Text, "Order", "Delete order invoice details", Convert.ToInt32(InvoiceAction.Yes));

                    }
                    else
                    {
                        GeneralFunction.Information("EmptyInvoiceList", "OrderInvoice");
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ObjHelper.ObjBALClass.ObjOrder.OrderDeliveryDate = dtpSetDeliveryDate.Value.Date;
            if (ObjHelper.SetDeliveryDate())
            { }
            else
                dtpSetDeliveryDate.Focus();
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            frmBalanceSheet balanceSheet = new frmBalanceSheet();
            if (cmbSupplierName.Text.Length != 0)
            {
                balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmbSupplierNo.Text==string.Empty?"0":cmbSupplierNo.Text);
                balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbSupplierName.Text;
                balanceSheet.ShowDialog();
            }
            else
                balanceSheet.ShowDialog();

            balanceSheet = null;
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice PurReturn = new PurchaseReturnInvoice();
            PurReturn.ShowDialog();

            PurReturn = null;
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            Purchase_Invoice purchase = new Purchase_Invoice();
            purchase.ShowDialog();
            purchase = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderStrat_Click(object sender, EventArgs e)
        {
            ObjHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
            ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt64(txtOrderInvoiceNo.Text);
            Navigation();
        }

        private void txtNote_MouseClick(object sender, MouseEventArgs e)
        {
            chkNote.Checked = true;
            txtNote.Enabled = true;
        }
        #endregion

        #region Changed Event
        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemName.SelectedIndex != -1)
                {
                    this.SetObjectFromControl();
                    ObjHelper.ItemNameSelectedIndexChange();
                    this.DefaultValue();
                    this.SetControlFromObject();
                    RTX_Notes.Text = string.Empty;
                    if (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock <= ObjHelper.ObjBALClass.ObjOrder.Reorder)
                    {
                        CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(RTX_Notes);
                    }
                    if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTX_Notes); }
                    SetRowColor(cmbItemName.Text);
                    txtQuantity.Text = "1";
                    txtCost.Focus();//added on 08Oct2014
                    txtCost.SelectAll();
                }
                else
                    RTX_Notes.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetRowColor(string ComboItemName)
        {
            if (dgvOrderInvoice.Rows.Count == 0)
                return;
            for (int i = 0; i < dgvOrderInvoice.Rows.Count; i++)
            {
                dgvOrderInvoice.Rows[i].Selected = false;
                if (dgvOrderInvoice.Rows[i].Cells["item_name"].Value.ToString() == ComboItemName)
                {
                    dgvOrderInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                    dgvOrderInvoice.FirstDisplayedScrollingRowIndex = i;
                }
            }

        }
        private void rbnShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnShowAll.Checked == true)
            {
               // AssignDataSourceForItem();
                cmbCategory.SelectedValue = cmbCompany.SelectedValue = 1001;
                //cmbItemName.DataSource = cmbItemNo.DataSource = ObjHelper.ItemDetailsList();
                AssignItemsource();
                cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
        }

        private void rbnReorderItems_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnReorderItems.Checked == true)
            {
               // List<PurchaseObjectClass> Items = ObjHelper.ItemDetails.Where(a => (a.ItemTotalStock / (a.ItemPackage == 0 ? 1 : a.ItemPackage)) <= a.Reorder).ToList();
                DataView dvFilterReorder = new DataView(OrderItems);
                dvFilterReorder.RowFilter = "(StockInHand/ISNULL(PackageQty,1))<=Reorder";
                DataTable Filtered = dvFilterReorder.ToTable(); // OrderItems.Select("(StockInHand/ISNULL(NULLIF(PackageQty,0),1))<=Reorder").CopyToDataTable();
                AssignDataSourceForItem();
                cmbItemName.DataSource = Filtered;
                DataView dvitemno = new DataView(Filtered);
                dvitemno.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource =dvitemno.ToTable();// ObjHelper.ItemDetails.Select(a => (a.ItemTotalStock / a.ItemPackage) <= a.Reorder);
                cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
        }

        private void rbnItemLessthan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnItemLessthan.Checked)
            {
                int level = Convert.ToInt32(Txt_ItemLessthan.Text==string.Empty?"1":Txt_ItemLessthan.Text);
                AssignDataSourceForItem();
                DataView dvItemLessthan = new DataView(OrderItems);
                dvItemLessthan.RowFilter = "StockInHand<'" + level + "'";
               // cmbItemName.DataSource = cmbItemNo.DataSource = ObjHelper.ItemDetails.Where(a => (a.ItemTotalStock) < level).ToList();
                DataTable filtertable = dvItemLessthan.ToTable();
                cmbItemName.DataSource = filtertable;
                DataView dvitemno = new DataView(filtertable);
                dvitemno.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dvitemno.ToTable();
                cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
        }

        private void chkSetDeliveryDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetDeliveryDate.Checked == true)
            {
                dtpSetDeliveryDate.Enabled = true;
                dtpSetDeliveryDate.Value = DateTime.Now.Date;
                btnSet.Enabled = true;
            }
            else
                btnSet.Enabled = dtpSetDeliveryDate.Enabled = false;

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != -1 && cmbCategory.Text != string.Empty)
            {
                this.cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                //ObjHelper.ObjBALClass.ObjOrder.AccountID = 1;
                //ObjHelper.ObjBALClass.ObjOrder.CategoryNo = Convert.ToInt32(cmbCategory.SelectedValue);
                //BindItemNameCatComID();
                AssignItemsource();
                this.cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompany.SelectedIndex != -1 && cmbCompany.Text != string.Empty)
                {
                    //ObjHelper.ObjBALClass.ObjOrder.AccountID = 0;
                    //ObjHelper.ObjBALClass.ObjOrder.CategoryNo = (Convert.ToInt32(cmbCompany.SelectedValue));
                    //this.BindItemNameCatComID();
                    this.cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                    AssignItemsource();
                    this.cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplierName.SelectedIndex != -1)
                cmbSupplierNo.Text = cmbSupplierName.SelectedValue.ToString();

        }
        #endregion

        #region Key Events

        #region keyUp
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbItemName.SelectedIndex > -1)
            {
                if ((cmbItemName.Text != string.Empty) && (cmbItemName.SelectedIndex > -1))
                {
                    if (ObjHelper.isPackage == false)
                    {
                        txtStock.Text = ((int.Parse(txtQuantity.Text != string.Empty ? txtQuantity.Text : "0")) + (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage != 0 ? ObjHelper.ObjBALClass.ObjOrder.ItemPackage : 1))).ToString();
                    }
                    else
                    {
                        txtStock.Text = Convert.ToString(int.Parse((txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0") + int.Parse((ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock).ToString()));
                    }
                }
            }
        }

        #endregion

        #region KeyDown
        private void Order_Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information Qprice = new Quick_Price_Information();
                    Qprice.ShowDialog();
                    Qprice = null;
                }
                if (e.KeyCode == Keys.F11 && btnItemInfo.Enabled)
                {
                    this.InvokeOnClick(btnItemInfo, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F4 && btnNewInvoice.Enabled && (!e.Alt))
                {
                    this.btnNewInvoice_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3 && btnAddItem.Enabled)
                {
                    this.InvokeOnClick(btnAddItem, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F2 && btnDelete.Enabled)
                {
                    btnDelete_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5 && btnCloseInvoice.Enabled)
                {
                    this.InvokeOnClick(btnCloseInvoice, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F9 && btnBox.Enabled)
                {
                    btnBox_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6 && btnPrint.Enabled)
                {
                    this.InvokeOnClick(btnPrint, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (ObjHelper.ObjItemInfo.Visible == true)
                    {
                        ObjHelper.ObjItemInfo.Visible = false;
                    }
                }
                else { }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        bool isFirst = false;
        string appval = "";
        private void MoveNext_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((((Control)sender).Name == "cmbItemName") && (e.KeyValue == 13))
                {
                    //cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
                    //txtCost.Focus();
                    //txtCost.Select(0, txtCost.Text.Length);
                    IsAfterInsertItem =false;
                }
                //else if (e.KeyValue != 13 && (((Control)sender).Name == "cmbItemName") && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) &&(e.KeyValue<111||e.KeyValue>126))
                //    ((ComboBox)sender).DroppedDown = true;
                //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (((Control)sender).Name == "cmbItemName"))
                //{
                //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //    (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //    && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //    && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //    && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (((Control)sender).Name == "cmbItemName") && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
                //{
                //    if (sender is ComboBox)
                //        if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                //        {
                //            if (((ComboBox)sender).DroppedDown == true)
                //                ((ComboBox)sender).DroppedDown = false;
                //            if (((ComboBox)sender).Name == "cmbItemName" && cmbItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //            {
                //                cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //                cmbItemName.SelectedText = ((char)e.KeyValue).ToString();
                //                //cmbItemName.SelectedIndex=
                //                cmbItemName.DroppedDown = true;
                //                //cmbItemName.SelectionStart = 1;
                //                isFirst = true;
                //                appval = ((char)e.KeyValue).ToString();
                //                //cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //                //cmbItemName.Text = ((char)e.KeyValue).ToString();
                //            }
                //            else
                //            {
                //                cmbItemName.DroppedDown = false;
                //                if (isFirst)
                //                {
                //                    cmbItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //                    isFirst = false;
                //                }
                //            }
                //        }
                //}
                if ((((Control)sender).Name == "txtCost") && (e.KeyValue == 13))
                {
                    txtQuantity.Focus();
                    txtQuantity.Select(0, txtQuantity.Text.Length);
                }
                if ((((Control)sender).Name == "txtQuantity") && (e.KeyValue == 13))
                {
                    btnAddItem_Click(sender, e);
                }
                if ((((Control)sender).Name == "cmbSupplierName") && (e.KeyValue == 13) && (cmbSupplierName.SelectedIndex != -1))
                {
                    cmbItemName.Focus();
                    cmbItemName.Select(0, cmbItemName.Text.Length);
                }
                //else if (e.KeyValue != 13 && (((Control)sender).Name == "cmbSupplierName") && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))
                //    ((ComboBox)sender).DroppedDown = true;
                else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                     (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                     && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                     && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                     && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (((Control)sender).Name == "cmbSupplierName"))
                {
                    if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                    {
                        if (((ComboBox)sender).DroppedDown == true)
                            ((ComboBox)sender).DroppedDown = false;
                    }
                }
                //if ((((Control)sender).Name == "cmbSupplierName") && (e.KeyValue == 13) && (cmbSupplierName.SelectedIndex == -1))
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}
                //else if (e.KeyValue == 40 || e.KeyValue == 38)
                //    iscount = true;
                //if ((((Control)sender).Name == "cmbItemName") && (e.KeyValue == 13) && (cmbItemName.SelectedIndex == -1))
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}
                //else if (e.KeyValue == 40 || e.KeyValue == 38)
                //    iscount = true;
                //if (((Control)sender).Name == "cmbSupplierNo" && cmbSupplierNo.SelectedIndex == -1 && e.KeyValue == 13)
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}
                //if (((Control)sender).Name == "cmbItemNo" && cmbItemNo.SelectedIndex == -1 && e.KeyValue == 13)
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region KeyPress
        private void Txt_ItemLessthan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rbnItemLessthan.Checked == true)
                {
                    if (Txt_ItemLessthan.Text != string.Empty)
                    {
                        rbnItemLessthan_CheckedChanged(sender, e);
                    }
                    else
                    {
                        GeneralFunction.Information("MustEnterValue", "OrderInvoice");
                        Txt_ItemLessthan.Focus();
                    }
                }
                else
                {
                    GeneralFunction.Information("MustEnterValue", "OrderInvoice");
                    Txt_ItemLessthan.Focus();
                }
            }
            else
            {
                if (GeneralFunction.NumericOnly(e))
                    e.Handled = true;
            }
        }

        private void txtOrderInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 45) && (e.KeyChar != 13))
                e.Handled = true;
            else if (e.KeyChar == 13 && UserScreenLimidations.InvoiceNavigation)
            {
                SplitID();
                ObjHelper.IDFlag = 0;

            }
        }

        #endregion

        #region Leave
        private void txtCost_Leave(object sender, EventArgs e)
        {
            try
            {
                string name = ((MaskedTextBox)sender).Name;
                switch (name)
                {
                    case "txtCost":
                        if (txtCost.Text != string.Empty && txtCost.Text != null && txtCost.Text.Length <= 8)
                        {
                            Decimal a = decimal.Parse(txtCost.Text);
                            // txtCost.Text = Math.Round(a, 11).ToString("N4");
                            txtCost.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                            //txtCost.Text = a.ToString("#####0.0000");
                        }
                        else
                            txtCost.Text = "0.000";
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
        }
        #endregion
        #endregion

        #region Load Event
        private void Order_Invoice_Load(object sender, EventArgs e)
        {
            if (IDFromOthers.Length != 0 && IDFromOthers != null)
            {
                txtNewInvoiceNo.Text = IDFromOthers;
                SplitID();
            }


        }
        #endregion


        #endregion

        #region Method
        private void AssignDataGridSource()
        {
            //try
            //{
            txtOrderTotal.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString("######0.000");
            ObjHelper.AssignDataGridSource(dgvOrderInvoice);
            //if (dgvOrderInvoice.BackgroundColor == Color.Beige)''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            if (dgvOrderInvoice.BackgroundColor == Color.WhiteSmoke)
                txtNote.Enabled = true;
            else
                txtNote.Enabled = false;
            //    dgvOrderInvoice.AutoGenerateColumns = false;
            //    dgvOrderInvoice.DataSource = null;
            //    dgvOrderInvoice.Rows.Clear();
            //    dgvOrderInvoice.DataSource = new BindingSource();
            //    dgvOrderInvoice.Refresh();
            //    DataGridView view = new DataGridView();
            //    view.DataSource = null;
            //    dgvOrderInvoice.DataSource = ObjHelper.InsertOrderList;
            //    if (ObjHelper.ObjBALClass.ObjOrder.Status == 1)
            //    {
            //        dgvOrderInvoice.BackgroundColor = Color.Beige;
            //        dgvOrderInvoice.DefaultCellStyle.BackColor = Color.White;
            //        txtNote.Enabled = true;
            //    }
            //    else
            //    {
            //        dgvOrderInvoice.BackgroundColor = Color.Gray;
            //        dgvOrderInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
            //        txtNote.Enabled = false;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void DefaultValue()
        {
            txtCost.Text = "0.000";
            //txtPackage.Text = "0";
            txtQuantity.Text = "0";
            txtStock.Text = "0";
            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
            ObjHelper.isPackage = false;
            txtPackage.DataSource = null;// commented on 07 may 2014
            txtPackage.SelectedIndex = -1;
            txtOrderTotal.Text = "0.000";
            //cmbSupplierName.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
        }

        private void ClearAll()
        {
            dtpOrderDate.Value = DateTime.Now;
            txtOrderInvoiceNo.Text = cmbItemNo.Text = cmbItemName.Text = cmbSupplierNo.Text = cmbSupplierName.Text = "";
            dtpSetDeliveryDate.Value = DateTime.Now;
            chkSetDeliveryDate.Checked = chkHideLogo.Checked = chkNote.Checked = false;
            txtCost.Text = txtQuantity.Text = txtStock.Text = txtNote.Text = txtOrderTotal.Text = string.Empty;
            //txtOrderTotal.Text = string.Empty;
        }

        private void SetSelectedGridData()
        {
            for (int i = 0; i < dgvOrderInvoice.SelectedRows.Count; i++)
            {
                ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(dgvOrderInvoice.SelectedRows[i].Cells["itemno"].Value);
                ObjHelper.ObjBALClass.ObjOrder.InvoiceNo = Convert.ToInt32(txtOrderInvoiceNo.Text);
                ObjHelper.ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(dgvOrderInvoice.SelectedRows[i].Cells["unit_price"].Value);
                ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(dgvOrderInvoice.SelectedRows[i].Cells["quantity"].Value);
                ObjHelper.ObjBALClass.ObjOrder.BarcodeID = Convert.ToInt32(dgvOrderInvoice.SelectedRows[i].Cells["BarcodeID"].Value);

                if (ObjHelper.btnDeleteInvoice())
                    AssignDataGridSource();
            }
        }

        private void SetWholeGridData()
        {
            for (int i = 0; i <= dgvOrderInvoice.Rows.Count; i++)
            {
                i = 0;
                dgvOrderInvoice.Rows[i].Selected = true;
                ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(dgvOrderInvoice.Rows[i].Cells["itemno"].Value);
                ObjHelper.ObjBALClass.ObjOrder.InvoiceNo = Convert.ToInt32(txtOrderInvoiceNo.Text);
                ObjHelper.ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(dgvOrderInvoice.Rows[i].Cells["unit_price"].Value);
                ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(dgvOrderInvoice.Rows[i].Cells["quantity"].Value);
                ObjHelper.btnDeleteInvoice();
                AssignDataGridSource();
            }

        }

        private void AssignDataSourceForItem()
        {
            cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
            cmbItemName.DisplayMember = "ItemName";
            cmbItemName.ValueMember = "ItemNo";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";
            cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            // cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
        }

        private void NotesandAlert()
        {
            try
            {
                RTX_Notes.Text = string.Empty;
                if (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock >= ObjHelper.ObjBALClass.ObjOrder.MaxOrder)
                {
                    RTX_Notes.Text = "";
                    RTX_Notes.Text = RTX_Notes.Text + "This item have reached the max order point";
                    RTX_Notes.Text = RTX_Notes.Text + "\n";
                }
                if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTX_Notes); }
                // Obj_Message.Set_ReorderItemsIn_NoteAlert(Rtxt_NotesAndAlerts);
                // Obj_Message.Set_NotesAlertDetails(Rtxt_NotesAndAlerts);Need To Implement
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Navigation()
        {
            ObjHelper.NavigationEvent();
            ClearAll();
            chkSetDeliveryDate.CheckedChanged -= new EventHandler(chkSetDeliveryDate_CheckedChanged);
            this.SetControlFromObject();
            AssignDataGridSource();
            chkSetDeliveryDate.CheckedChanged += new EventHandler(chkSetDeliveryDate_CheckedChanged);
        }

        private void SplitID()
        {
            if (txtNewInvoiceNo.Text.Contains('-'))
            {
                string[] id = txtNewInvoiceNo.Text.Split('-');
                ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(id[1]);
                ObjHelper.ObjBALClass.ObjOrder.Year = Convert.ToInt32(id[0]);
                Navigation();
            }
            else
            {
                ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(txtNewInvoiceNo.Text);
                Navigation();
            }
        }

        private void BindItemNameCatComID()
        {
            //List<PurchaseObjectClass> ItemList = ObjHelper.GetItemsBasedComCatID();
            List<PurchaseObjectClass> ItemList = lstItemDetailsList.Where(a => a.AccountID == ObjHelper.ObjBALClass.ObjOrder.AccountID && a.CategoryNo == ObjHelper.ObjBALClass.ObjOrder.CategoryNo).ToList();
            if (ItemList.Count > 0)
            {
                this.cmbItemName.SelectedIndexChanged -= new EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemName.DataSource = cmbItemNo.DataSource = null;
                cmbItemName.DisplayMember = "ItemName";
                cmbItemName.ValueMember = "ItemNo";
                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemNo";
                //cmbItemName.DataSource = ItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                cmbItemName.DataSource = ItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                cmbItemNo.DataSource = ItemList.Where(i => i.ItemNumber != string.Empty).ToList(); ;
                this.cmbItemName.SelectedIndexChanged += new EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
            else
            {
                cmbItemName.DataSource = cmbItemNo.DataSource = null;
            }

            ItemList = null;
            // this.DefaultValue();
        }

        private void UserLimitation()
        {
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = UserScreenLimidations.Print == true ? true : false;
            btnFindInvoice.Enabled = UserScreenLimidations.FindPurchaseInvoice == true ? true : false;
            btnReturnItem.Enabled = UserScreenLimidations.PurchaseReturnInvoice == true ? true : false;
            btnBalanceSheet.Enabled = UserScreenLimidations.BalanceSheet == true ? true : false;
            btnPurchaseInvoice.Enabled = UserScreenLimidations.PurchaseInvoice == true ? true : false;
            btnModifyInvoice.Enabled = ((UserScreenLimidations.ModifyInvoice == true) || (UserScreenLimidations.ModifyTodayInvoice == true)) ? true : false;
            btnOrderNext.Visible = btnOrderPrevious.Visible = btnOrderStrat.Visible = btnOrderEnd.Visible = UserScreenLimidations.InvoiceNavigation == true ? true : false;
            txtOrderInvoiceNo.ReadOnly = (UserScreenLimidations.InvoiceNavigation == true) ? false : true;
            txtOrderInvoiceNo.BackColor = Color.White;
            //dgvOrderInvoice.Columns["itemno"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvOrderInvoice.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvOrderInvoice.Columns["exp_date"].Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry == "Y") ? false : true;
            dgvOrderInvoice.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            lblPackage.Visible = txtPackage.Visible = btnBox.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvOrderInvoice.Columns["in_time"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
            btnItemInfo.Enabled = UserScreenLimidations.ItemInfo;
            //ReorderItems();
            btnDelete.Enabled = UserScreenLimidations.DeleteItem;
        }
        #endregion

        private void blinkTextbox(object sender, EventArgs e)
        {
            GeneralFunction.BlinkText(EventArgs.Empty, RTX_Notes);
        }

        #region Barcode
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;
                //if (e.KeyValue == 13)
                //{
                //    txtCost.Focus();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode") return;

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
        //                cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                txtPackage.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
        //                ClearBarcodeValues();
        //                txtCost.Focus();
        //            }
        //            else
        //            {
        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "OrderInvoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                    }
        //                    else
        //                    {
        //                        GeneralFunction.Information("ItemNotRegisteredInformAdmin", "OrderInvoice");
        //                        ClearBarcodeValues();
        //                    }
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
        //        GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //        //throw ex;
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
                    }

                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());

                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                        txtPackage.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
                        ClearBarcodeValues();
                        txtCost.Focus();
                    }
                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "OrderInvoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                            }
                            else
                            {
                                GeneralFunction.Information("ItemNotRegisteredInformAdmin", "OrderInvoice");
                                ClearBarcodeValues();
                            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") && (dgvOrderInvoice.BackgroundColor != Color.Gray))
            {
                GeneralFunction.Information("Pleaseclosetheinvoicefirst", "OrderInvoice");
                return;
            }
            ObjHelper.ObjBALClass.ObjOrder.CheckNote = chkNote.Checked == true ? true : false;
            ObjHelper.ObjBALClass.ObjOrder.SetStatus = chkPrintPreview.Checked == true ? 1 : 0;
            ObjHelper.ObjBALClass.ObjOrder.Status = chkHideLogo.Checked == false ? 0 : 1;
            ObjHelper.ObjBALClass.ObjOrder.InvoiceNo = ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo;
            ObjHelper.ObjBALClass.ObjOrder.OrderNote = txtNote.Text;
            ObjHelper.btnPrint();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "OrderInvoice" + " " + txtOrderInvoiceNo.Text, "Order", "Print order invoice details", Convert.ToInt32(InvoiceAction.Yes));
        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            Find_Purchase_Invoice frmFind = new Find_Purchase_Invoice();
            frmFind.ShowDialog();
            frmFind = null;
        }

        private void RTX_Notes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = RTX_Notes.SelectedText.Trim();
            Purchase_Invoice.ReorderandBalance(str);
        }

        //private void cmbItemName_DropDown(object sender, EventArgs e)
        //{
        //    if (((ComboBox)(sender)).DroppedDown == false)
        //    {
        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //    }
        //}

        //private void cmbItemName_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    switch (((ComboBox)sender).Name)
        //    {
        //        case "cmbItemName":
        //            if (!iscount)

        //                cmbItemName_SelectedIndexChanged(sender, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //        case "cmbSupplierNo":
        //            if (!iscount)
        //                cmbSupplierNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //        case "cmbSupplierName":
        //            if (!iscount)
        //                cmbSupplier_SelectedIndexChanged(sender, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //        case "cmbItemNo":
        //            if (!iscount)
        //                cmbItemNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;

        //    }
        //}

        private void cmbItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back))
            //{
            //    //commeneted on 17 april 2014  to allow the alpha numeric value
            //    //GeneralFunction.Information("OnlyNumbersAllowed", "OrderInvoice");
            //    //e.Handled = true;
            //}
            //else
            //{
            //    if (((ComboBox)sender).DroppedDown == true)
            //        ((ComboBox)sender).DroppedDown = false;
            //}
            //if (e.KeyChar != 13 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            //{
            //    ((ComboBox)sender).DroppedDown = true;
            //}
            //if (((int)e.KeyChar != 13) && (e.KeyChar != (char)Keys.Tab) && (e.KeyChar < 111 || e.KeyChar > 126) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back))
            //{
            if (((int)e.KeyChar != 13) && (e.KeyChar != (char)Keys.Tab) && (e.KeyChar != (char)Keys.Escape) &&
                   (e.KeyChar != 18) && (e.KeyChar != (char)Keys.Up) && (e.KeyChar != (char)Keys.Down) && (e.KeyChar != (char)Keys.Right)
                   && (e.KeyChar != (char)Keys.Left) && (e.KeyChar != (char)Keys.End) && (e.KeyChar != (char)Keys.Home) && (e.KeyChar < 111 || e.KeyChar > 126) && (e.KeyChar != (char)Keys.Space) && (e.KeyChar != (char)Keys.ShiftKey)
                   && (e.KeyChar != 16) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 17)
                   && (e.KeyChar != (char)Keys.ControlKey) && (e.KeyChar != (char)Keys.CapsLock))
            {
                if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                {
                    if (((ComboBox)sender).DroppedDown == true)
                        ((ComboBox)sender).DroppedDown = false;
                }
            }

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)ConsoleKey.Backspace) && (e.KeyChar != (char)ConsoleKey.Delete))
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

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemNo.SelectedIndex > -1)
                {
                    int value = Convert.ToInt32(cmbItemNo.SelectedValue);
                    cmbItemName.SelectedValue = value;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void txtPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPackage.Text != string.Empty && txtPackage.SelectedIndex > -1)
            {
                var items = ObjHelper.PackageQty.Where(a => a.ItemPackage == Convert.ToInt32(txtPackage.Text)).ToList();
                ObjHelper.ObjBALClass.ObjOrder.ItemPrice = items[0].ItemPrice;
                ObjHelper.ObjBALClass.ObjOrder.BarcodeID = items[0].BarcodeID;
                //ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = items[0].ItemTotalStock;//this line Commended to fix Piece can form a Package on 02Aug2014  By Meena.R
                ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = ObjHelper.PackageQty.Sum(a => a.ItemTotalStock);//this line added to fix Piece can form a Package on 02Aug2014  By Meena.R
                ObjHelper.ObjBALClass.ObjOrder.ItemPackage = items[0].ItemPackage;
                decimal UnitItemCost = Convert.ToDecimal((((ObjHelper.ObjBALClass.ObjOrder.ItemCardItemCost / (ObjHelper.ObjBALClass.ObjOrder.ItemCardPackageQty == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemCardPackageQty)) * 1000m) / 1000m).ToString("#####0.000"));
                if (!ObjHelper.isPackage)
                {
                    if (ObjHelper.ObjBALClass.ObjOrder.ItemCardPackageQty == Convert.ToInt32(txtPackage.Text))
                        txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCardItemCost.ToString();
                    else
                        txtCost.Text = (UnitItemCost * (Convert.ToInt32(txtPackage.Text) == 0 ? 1 : Convert.ToInt32(txtPackage.Text))).ToString();
                    txtStock.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();
                }
                else
                {
                    txtCost.Text = UnitItemCost.ToString();
                    txtStock.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                }
                txtQuantity_KeyUp(null, null);
            }
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
                for (int i = 0; i <= this.tableLayoutPanel2.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel2.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel2.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
                dgvOrderInvoice.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void cmbItemName_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if (isfrominsert == false && IsAfterInsertItem == false)
            //        txtBarcode.Focus();
            //    else
            //    {
            //        isfrominsert = false;
            //        IsAfterInsertItem = false;
            //    }
            //}

            if (e.KeyValue == 13)
            {
                if (cmbItemName.SelectedIndex > -1)
                {
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
            }
        }

        private void Order_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GeneralFunction.NumericOnly(e) == true || e.KeyChar == 46 ||txtQuantity.Text.Length>8) e.Handled = true;
        }

        //private void cmbItemName_TextChanged(object sender, EventArgs e)
        //{
        //    if (((ComboBox)sender).DroppedDown == true)
        //    {
        //        List<PurchaseObjectClass> filter =(from l in ObjHelper.ItemDetails where l.ItemName.Contains(cmbItemName.Text) select l).ToList();
        //        cmbItemName.DataSource = filter;
        //    }
        //}

        private void AssignItemsource()
        {
            int CatId = 0, CompId = 0;
            cmbItemName.DisplayMember = "ItemName";
            cmbItemName.ValueMember = "ItemNo";
            cmbItemNo.BindingContext = new BindingContext();
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";
            if (cmbCategory.SelectedIndex != -1)
                CatId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
            else
                CatId = 1001;
            if (cmbCompany.SelectedIndex != -1)
                CompId = Convert.ToInt32(cmbCompany.SelectedValue.ToString());
            else
                CompId = 1001;
            OrderItems = ObjHelper.AllOrderItems(CatId, CompId);
            cmbItemName.DataSource = OrderItems;
            DataView dvfilter = new DataView(OrderItems);
            dvfilter.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dvfilter.ToTable();
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
    }
}
