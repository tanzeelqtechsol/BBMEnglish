using System;
using System.Drawing;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;
using System.Data;
using System.Linq;
using System.Threading;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class PurchaseReturnInvoice : Form, IDisposable
    {

        #region Variables
        public PurchaseReturnHelper ObjHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        internal string IDFromOthers = string.Empty;
        private bool check;
        #endregion

        #region Constructor
        public PurchaseReturnInvoice()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjHelper = new PurchaseReturnHelper();
            LoadData();
            cmbItemName.Select();
            cmbItemName.Focus();
        }
        #endregion

        #region Method
        public void SetLanguage()
        {

            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblInvNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find") + "       "; ;
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print") + "        "; ;
            this.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoices");
            chkAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            lblReturnQty.Text = Additional_Barcode.GetValueByResourceKey("ReturnQty");
            lblTotalReturnedValue.Text = Additional_Barcode.GetValueByResourceKey("TReturnValue");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInv") + "      ";
            btnExit.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "        "; ;
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModInv") + "      ";
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInv") + "       ";
            btnReciveRecipt.Text = Additional_Barcode.GetValueByResourceKey("RecReceipt");
            btnReturn.Text = Additional_Barcode.GetValueByResourceKey("Return") + "       ";
            btnUndoReturn.Text = Additional_Barcode.GetValueByResourceKey("UndoReturn") + "       ";
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblsearchIn.Text = Additional_Barcode.GetValueByResourceKey("SearchIn");
            lblSupplier.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            rbnReturnbyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ReturnByInvoice");
            rbnReturnnbyItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnByItem");
            lblReturnInvNo.Text = Additional_Barcode.GetValueByResourceKey("ReturnInv");
            lblSupplierR.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            lblSupplierNo.Text = Additional_Barcode.GetValueByResourceKey("SupplierNo");
            dgvReturnItemInvoice.Columns["invoiceno"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            dgvReturnItemInvoice.Columns["date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgvReturnItemInvoice.Columns["supplier"].HeaderText = Additional_Barcode.GetValueByResourceKey("Supplier");
            dgvReturnItemInvoice.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvReturnItemInvoice.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgvReturnItemInvoice.Columns["total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvReturnItemInvoice.Columns["expiry"].HeaderText = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            dgvReturnItemInvoice.Columns["user"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgvReturnItemInvoice.Columns["returned"].HeaderText = Additional_Barcode.GetValueByResourceKey("Returned");
            dgvReturnItemInvoice.Columns["SerialNo1"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");

            dgvReturnInvoice.Columns["itemname"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvReturnInvoice.Columns["ExpiryDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            dgvReturnInvoice.Columns["itempackage"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvReturnInvoice.Columns["ReturnQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgvReturnInvoice.Columns["unitprice"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvReturnInvoice.Columns["ReturnTotal"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvReturnInvoice.Columns["Serialno"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
            dgvReturnInvoice.Columns["time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgvReturnInvoice.Columns["itemno1"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvReturnInvoice.Columns["ItemNumber1"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
        }

        public void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjPurchaseReturn.FromDate = dtpFromDate.Value.Date;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ToDate = dtpToDate.Value.Date;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemName = cmbItemName.Text;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemNo = Convert.ToInt32(cmbItemName.SelectedValue);
            ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierName = txtSupplierName.Text;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierNo = cmbSupplierName.Text.Length == 0 ? 1 : Convert.ToInt32(cmbSupplierName.SelectedValue);
            ObjHelper.ObjBALClass.ObjPurchaseReturn.SetStatus = chkAll.Checked == true ? 1 : 0;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.CheckNote = rbnReturnbyInvoice.Checked == true ? true : false;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ReturnQty = Convert.ToInt32(txtReturnQty.Text == string.Empty ? "0" : txtReturnQty.Text);
            ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = Convert.ToInt32(txtReturnInvoiceNo.Text);
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ReturnDate = dtpDate.Value;
            ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemNumber = cmbItemNo.Text;
        }

        public void SetControlFromObject()
        {
            txtReturnInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseReturnID.ToString();
            if (ObjHelper.ID[2] == ObjHelper.ObjBALClass.ObjPurchaseReturn.Year)
            {
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID.ToString();
            }
            else
            {
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjPurchaseReturn.Year.ToString() + '-' + ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID.ToString();
            }
            txtSupplierName.Text = ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierName;
            txtTotalReturnValue.Text = ((ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemTotal * 1000m) / 1000m).ToString("#####0.000");
            dtpDate.Value = Convert.ToDateTime(ObjHelper.ObjBALClass.ObjPurchaseReturn.ReturnDate == null ? DateTime.Now.ToString() : ObjHelper.ObjBALClass.ObjPurchaseReturn.ReturnDate.Value.ToString());
        }

        private void LoadData()
        {
            DataTable dtItems = ObjHelper.GetItemDetails();//add on 09jan2015 to load item details
            cmbSupplierName.DisplayMember = "Name";
            cmbSupplierName.ValueMember = "AgentID";
            cmbSupplierName.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;

            cmbSupplierNo.DisplayMember = "AgentID";
            cmbSupplierNo.ValueMember = "Name";
            cmbSupplierNo.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;

            cmbItemName.DisplayMember = "ItemName";
            cmbItemName.ValueMember = "ItemNo";
            // cmbItemName.DataSource = ObjHelper.ItemListDetails.Where(i => i.IsHide == false).ToList();
            cmbItemName.DataSource = dtItems;
            //commented on 25 april 2014 ,to  reomove the  space on item number list 
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";
            //cmbItemNo.DataSource = ObjHelper.ItemListDetails.Where(i => ((i.ItemNumber != string.Empty) & (i.IsHide == false))).ToList();
            DataView dvfilter = new DataView(dtItems);
            dvfilter.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dvfilter.ToTable();
            //cmbItemNo.DisplayMember = "ItemNo";
            //cmbItemNo.ValueMember = "ItemName";

            cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = cmbItemName.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            ObjHelper.LoadInvoiceIDNewYearID();
            StatusForInvoice();
            SetControlFromObject();
            if (!ObjHelper.isFromElse)
            {
                AssignDataSourceforReturn();
                AssignDataSourceforItem();
            }
            cmbSupplierName.SelectedIndexChanged += new EventHandler(cmbSupplierName_SelectedIndexChanged);
            cmbItemName.SelectedIndexChanged += new EventHandler(cmbItemName_SelectedIndexChanged);
            cmbSupplierNo.SelectedIndexChanged += new EventHandler(cmbSupplierNo_SelectedIndexChanged);
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
            ScanValue = "0";
            ScanTimingCheck = true;
            ScanLetterStartTime = DateTime.Now;
        }

        private void StatusForInvoice()
        {
            if (ObjHelper.ObjBALClass.ObjPurchaseReturn.Status == 2)
            {
                dgvReturnInvoice.BackgroundColor = Color.Gray;
                dgvReturnInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
            }
            else
            {
                //dgvReturnInvoice.BackgroundColor = Color.Beige;''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgvReturnInvoice.BackgroundColor = Color.WhiteSmoke;
                dgvReturnInvoice.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void Clear()
        {
            cmbSupplierName.SelectedIndex = -1;
            cmbSupplierNo.SelectedIndex = -1;
            cmbItemName.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            txtReturnQty.Text = String.Empty;
            txtReturnInvoiceNo.Text = String.Empty;
            txtInvoiceNo.Text = String.Empty;
            txtSupplierName.Text = String.Empty;
            txtTotalReturnValue.Text = String.Empty;
            txtBalance.Text = string.Empty;
            dgvReturnInvoice.DataSource = null;
            dgvReturnItemInvoice.DataSource = null;
        }

        private void AssignDataSourceforReturn()
        {
            dgvReturnInvoice.AutoGenerateColumns = false;
            dgvReturnInvoice.DataSource = null;
            DataTable dt = GeneralFunction.SortInvoiceDetails(ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(ObjHelper.ReturnPurchaseList), "ItemName", "ItemUnitPrice");
            // ObjHelper.ReturnPurchaseList = PurchaseInvoiceHelper.SortList(ObjHelper.ReturnPurchaseList);
            dgvReturnInvoice.DataSource = dt;// ObjHelper.ReturnPurchaseList;
        }

        private void AssignDataSourceforItem()
        {
            dgvReturnItemInvoice.AutoGenerateColumns = false;
            dgvReturnItemInvoice.DataSource = null;
            DataTable dt = GeneralFunction.SortInvoiceDetails(ConvertionHelper.ConvertToDataTable<PurchaseObjectClass>(ObjHelper.ReturnItemDetailsList), "ItemName", "ItemTotal");
            dgvReturnItemInvoice.DataSource = dt;// ObjHelper.ReturnItemDetailsList;
            if (dgvReturnItemInvoice.Rows.Count == 0)
            {
                txtInvoiceNo.Text = string.Empty;
                txtSupplierName.Text = String.Empty;
                txtTotalReturnValue.Text = "0.000";
            }
        }

        private void GetInvoiceRecord()
        {
            SplitYearandID();
            ObjHelper.IDFlag = 0;
            if (IDFromOthers.Length != 0 && IDFromOthers != null)
            {
                ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = Convert.ToInt32(IDFromOthers);
                ObjHelper.GetInvoiceRecordBasedOnID();
            }
            else
                ObjHelper.NavigationEvent();
            Clear();
            SetControlFromObject();
            AssignDataSourceforReturn();
            AssignDataSourceforItem();
            StatusForInvoice();
        }

        private void SplitYearandID()
        {
            if (txtNewInvoiceNo.Text.Contains("-"))
            {
                string[] id = txtNewInvoiceNo.Text.Split('-');
                if (id[0].Length != 0 && id[1].Length != 0)
                {
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.Year = Convert.ToInt32(id[0]);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(id[1]);
                }
                else
                    GeneralFunction.ErrInfo("ID Not in a Correct Format", this.Text);
            }
            else
                ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(txtNewInvoiceNo.Text);
        }

        private void HideControls()
        {
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = (UserScreenLimidations.Print == true) ? true : false;
            btnModifyInvoice.Enabled = ((UserScreenLimidations.ModifyInvoice == true) || (UserScreenLimidations.ModifyTodayInvoice == true)) ? true : false;
            btnReciveRecipt.Enabled = (UserScreenLimidations.ReceiveReceipt == true) ? true : false;
            btnPervious.Visible = btnNext.Visible = btnEnd.Enabled = btnFirst.Enabled = (UserScreenLimidations.InvoiceNavigation == true) ? true : false;
            txtReturnInvoiceNo.ReadOnly = (UserScreenLimidations.InvoiceNavigation == true) ? false : true;
            //dgvReturnInvoice.Columns["itemno1"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true; ;
            dgvReturnInvoice.Columns["ItemNumber1"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true; ;
            dgvReturnInvoice.Columns["ExpiryDate"].Visible = (GeneralOptionSetting.FlagPurchase_HideExpiryFiled == "Y") ? false : true;
            dgvReturnItemInvoice.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvReturnInvoice.Columns["itempackage"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvReturnInvoice.Columns["time"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
        }
        #endregion

        #region Event
        #region Button Event
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                ObjHelper.FindReturnInvoice();
                AssignDataSourceforItem();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {

            ObjectHelper.PurchaseObjectClass obj;
            try
            {
                Clear();
                obj = new PurchaseObjectClass();
                ObjHelper.btnNewInvoice();
                if (ObjHelper.isProcessTrue)
                {
                    SetControlFromObject();
                    txtSupplierName.Text = string.Empty;
                    //dgvReturnInvoice.BackgroundColor = Color.Beige;''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    dgvReturnInvoice.BackgroundColor = Color.WhiteSmoke;
                    dgvReturnInvoice.DefaultCellStyle.BackColor = Color.White;
                    if (!ObjHelper.isFromNewElse)
                    {
                        ObjHelper.ReturnPurchaseList.Clear();
                        ObjHelper.ReturnItemDetailsList.Clear();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.New), ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo.ToString(), "Purchase Return", "New purchase return invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    }
                    else
                    {
                        AssignDataSourceforReturn();
                        AssignDataSourceforItem();
                        ObjHelper.isFromNewElse = false;
                    }

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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                if (dgvReturnItemInvoice.SelectedRows.Count > 0)
                {
                    //if (dgvReturnInvoice.BackgroundColor == Color.Beige) ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    if (dgvReturnInvoice.BackgroundColor == Color.WhiteSmoke)
                    {
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo = Convert.ToInt32(dgvReturnItemInvoice.SelectedRows[0].Cells["invoiceno"].Value);
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemNo = Convert.ToInt32(dgvReturnItemInvoice.SelectedRows[0].Cells["itemno"].Value);
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemCost = Decimal.Parse((Math.Truncate(Decimal.Parse(dgvReturnItemInvoice.SelectedRows[0].Cells["Cost1"].Value.ToString()) * 1000m) / 1000m).ToString("#####0.000"));
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.NewCost = Decimal.Parse((Math.Truncate(Convert.ToDecimal(dgvReturnItemInvoice.SelectedRows[0].Cells["NewCost"].Value) * 1000m) / 1000m).ToString("#####0.000"));
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemQuantity = Convert.ToInt32(dgvReturnItemInvoice.SelectedRows[0].Cells["quantity"].Value);
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = Convert.ToDateTime(dgvReturnItemInvoice.SelectedRows[0].Cells["expiry"].Value.ToString() == "-" || dgvReturnItemInvoice.SelectedRows[0].Cells["expiry"].Value.ToString() == string.Empty ? null : dgvReturnItemInvoice.SelectedRows[0].Cells["expiry"].Value);
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = Convert.ToInt32(dgvReturnItemInvoice.SelectedRows[0].Cells["DETID"].Value);
                        cmbSupplierName.SelectedIndexChanged -= new EventHandler(this.cmbSupplierName_SelectedIndexChanged);
                        cmbSupplierNo.SelectedIndexChanged -= new EventHandler(this.cmbSupplierNo_SelectedIndexChanged);
                        cmbSupplierName.SelectedText = ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierName;
                        cmbSupplierNo.SelectedValue = ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierName;
                        ObjHelper.ObjBALClass.ObjPurchaseReturn.SupplierNo = Convert.ToInt32(cmbSupplierNo.Text == String.Empty ? "0" : cmbSupplierNo.Text);
                        cmbSupplierNo.SelectedIndex = cmbSupplierName.SelectedIndex = -1;
                        cmbSupplierName.Text = cmbSupplierNo.Text = string.Empty;
                        ObjHelper.btnReturnInvoice();
                        if (ObjHelper.isProcessTrue)
                        {
                            AssignDataSourceforReturn();
                            AssignDataSourceforItem();
                            SetControlFromObject();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Return), ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemName + " " + "Qty-" + ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemQuantity + " " + "InvNo-" + ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo.ToString(), "Purchase Return", "Return purchase return invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            ObjHelper.isProcessTrue = false;
                        }
                        cmbSupplierName.SelectedIndexChanged -= new EventHandler(this.cmbSupplierName_SelectedIndexChanged);
                        cmbSupplierNo.SelectedIndexChanged -= new EventHandler(this.cmbSupplierNo_SelectedIndexChanged);
                    }
                    else
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CantInsertafterClosingInvoice"), "Return Invoice");
                }
                else
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceList"), "Return Invoice");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnUndoReturn_Click(object sender, EventArgs e)
        {
            if (dgvReturnInvoice.BackgroundColor != Color.Gray)
            {
                //if (dgvReturnInvoice.SelectedRows.Count > 0 && dgvReturnInvoice.BackgroundColor == Color.Beige)   ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                if (dgvReturnInvoice.SelectedRows.Count > 0 && dgvReturnInvoice.BackgroundColor == Color.WhiteSmoke)
                {
                    SetObjectFromControl();
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo = Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["Invoiceno1"].Value);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseID = Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["PurchaseId1"].Value);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemNo = Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["itemno1"].Value);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemCost = Convert.ToDecimal(dgvReturnInvoice.SelectedRows[0].Cells["Cost"].Value);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["DETID1"].Value);
                    ObjHelper.btnUndoReturn();
                    if (ObjHelper.isProcessTrue)
                    {
                        AssignDataSourceforItem();
                        AssignDataSourceforReturn();
                        ObjHelper.isProcessTrue = false;
                        SetControlFromObject();
                        if (ObjHelper.ReturnPurchaseList.Count == 0)
                            txtSupplierName.Text = String.Empty;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Undo), ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemName + " " + "Qty-" +

                            ObjHelper.ObjBALClass.ObjPurchaseReturn.ItemQuantity + " " + "InvNo-" + ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo.ToString(), "Purchase Return", "Undo purchase return invoice details",

                        Convert.ToInt32(InvoiceAction.Yes));
                    }
                }
                else
                    GeneralFunction.Information("NotSelectRowtoReturn", "PurchaseReturnInvoice");
            }
            else
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CantModifyClosedInvoice"), this.Text);
        }

        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReturnInvoice.Rows.Count > 0)
                {
                    this.SetObjectFromControl();
                    //if (dgvReturnInvoice.BackgroundColor == Color.Beige)  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    if (dgvReturnInvoice.BackgroundColor == Color.WhiteSmoke)
                    {
                        ObjHelper.btnCloseInvoice();
                        if (ObjHelper.isProcessTrue)
                        {
                            dgvReturnInvoice.BackgroundColor = Color.Gray;
                            dgvReturnInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
                            ObjHelper.isProcessTrue = false;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo.ToString(), "Purchase Return", "Save(close) purchase return invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                }
                else
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyInvoiceList"), "Return Invoice");
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
                //if ((txtReturnInvoiceNo.Text != string.Empty) && (dgvReturnInvoice.BackgroundColor != Color.Beige))  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                if ((txtReturnInvoiceNo.Text != string.Empty) && (dgvReturnInvoice.BackgroundColor != Color.WhiteSmoke))
                {
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = Convert.ToInt64(txtReturnInvoiceNo.Text);
                    if (UserScreenLimidations.ModifyInvoice == true)
                        check = true;
                    else if (UserScreenLimidations.ModifyTodayInvoice == true)
                    {
                        if (DateTime.Compare(Convert.ToDateTime(dtpDate.Value.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString())) == 0)
                            check = true;
                    }
                    else { check = false; }
                    if (check)
                    {
                        ObjHelper.btnModifyInvoice();
                        if (ObjHelper.isProcessTrue)
                        {
                            //dgvReturnInvoice.BackgroundColor = Color.Beige;  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                            dgvReturnInvoice.BackgroundColor = Color.WhiteSmoke;
                            dgvReturnInvoice.DefaultCellStyle.BackColor = Color.White;
                            ObjHelper.isProcessTrue = false;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Modify), ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo.ToString(), "Purchase Return", "Modify purchase return invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else { GeneralFunction.ErrInfo("RightsModifyInvoice", "PurchaseReturnInvoice"); }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReciveRecipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReturnInvoice.BackgroundColor == Color.Gray && txtReturnInvoiceNo.Text.Length != 0)
                {
                    this.SetObjectFromControl();
                    ObjHelper.btnReceiveReceipt();
                }
                else
                {
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CloseInvoice"), this.Text);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                ObjHelper.ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = Convert.ToInt32(txtReturnInvoiceNo.Text == string.Empty ? "0" : txtReturnInvoiceNo.Text);
                ObjHelper.NavigationEvent();
                Clear();
                this.SetControlFromObject();
                this.AssignDataSourceforReturn();
                this.AssignDataSourceforItem();
                StatusForInvoice();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Load Event
        private void PurchaseReturnInvoice_Load(object sender, EventArgs e)
        {
            cmbSupplierName.MatchingMethod = StringMatchingMethod.UseRegexs;
            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//

            rbnReturnnbyItem.Checked = true;
            txtReturnQty.Text = "1";
            lblUser.Text = GeneralFunction.UserName;
            HideControls();
            if (IDFromOthers.Length != 0 && IDFromOthers != null)
            {
                //txtNewInvoiceNo.Text = IDFromOthers;this line commended By Meena.R on 12/06/2014          
                GetInvoiceRecord();
            }
        }
        #endregion

        #region Key Event
        private void txtReturnQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnReturn_Click(sender, e);
            }
            if (GeneralFunction.IntegerOnly(e) == true) e.Handled = true;

        }

        private void txtNewInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetInvoiceRecord();
            }
            if (e.KeyChar > 58 || e.KeyChar < 47 && e.KeyChar != 35 && e.KeyChar != 45 && e.KeyChar != 8)
                e.Handled = true;

        }

        private void PurchaseReturnInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region Changed Event
        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSupplierNo.Text = cmbSupplierName.SelectedValue == null ? string.Empty : cmbSupplierName.SelectedValue.ToString();
                SetObjectFromControl();
                ObjHelper.BalanceAmount();
                txtBalance.ForeColor = (GeneralFunction.ClientDebt >= 0) ? Color.Green : Color.Red;
                txtBalance.Text = GeneralFunction.ClientDebt.ToString("########0.000");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemName.Text.Length != 0 && cmbItemName.SelectedIndex > -1)
            {
                //cmbItemNo.Text = (cmbItemName.SelectedValue == null || cmbItemName.SelectedValue == string.Empty) ? string.Empty : cmbItemName.SelectedValue.ToString();
                //cmbItemNo.Text=string.Empty;
                cmbItemNo.SelectedValue = (cmbItemName.SelectedValue == null || cmbItemName.SelectedValue == string.Empty) ? string.Empty : cmbItemName.SelectedValue;
                SetRowColor(cmbItemName.Text);
            }
        }
        public void SetRowColor(string ComboItemName)
        {
            if (dgvReturnInvoice.Rows.Count == 0)
                return;
            for (int i = 0; i < dgvReturnInvoice.Rows.Count; i++)
            {
                dgvReturnInvoice.Rows[i].Selected = false;
                if (dgvReturnInvoice.Rows[i].Cells["itemname"].Value.ToString() == ComboItemName)
                {
                    dgvReturnInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                    dgvReturnInvoice.FirstDisplayedScrollingRowIndex = i;
                }
            }

        }
        private void cmbSupplierNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSupplierNo.Text != string.Empty)
                {
                    cmbSupplierName.Text = (cmbSupplierNo.SelectedValue == null || cmbSupplierNo.SelectedValue == string.Empty) ? string.Empty : cmbSupplierNo.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemNo.Text != String.Empty && cmbItemNo.SelectedIndex > -1)
                //cmbItemName.Text = (cmbItemNo.SelectedValue == null || cmbItemNo.SelectedValue == string.Empty) ? string.Empty : cmbItemNo.SelectedValue.ToString();
                cmbItemName.SelectedValue = (cmbItemNo.SelectedValue == null || cmbItemNo.SelectedValue == string.Empty) ? string.Empty : cmbItemNo.SelectedValue;
        }
        #endregion

        #region DataGrid Event
        private void dgvReturnItemInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Purchase_Invoice frm;
            try
            {
                if (dgvReturnItemInvoice.Rows.Count > 0)
                {
                    frm = new Purchase_Invoice();  //Performance fine tuning done by Praba on 19-Nov
                    frm.IDFromBalanceSheet = dgvReturnItemInvoice.SelectedRows[0].Cells["InvoiceNo"].Value.ToString();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                frm = null;
            }
        }

        private void dgvReturnInvoice_DoubleClick(object sender, EventArgs e)
        {
            Item_Serial_Number ObjSerial;
            try
            {
                if (dgvReturnInvoice.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["serialno"].Value) != 0)
                    {
                        ObjSerial = new Item_Serial_Number();
                        ObjSerial.ItemID = Convert.ToInt32(dgvReturnInvoice.SelectedRows[0].Cells["itemno1"].Value);
                        ObjSerial.ItemName = dgvReturnInvoice.SelectedRows[0].Cells["itemname"].Value.ToString();
                        ObjSerial.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                ObjSerial = null;
            }
        }

        private void dgvReturnItemInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReturnItemInvoice.RowCount > 0 && dgvReturnItemInvoice.SelectedRows.Count > 0)
            {
                txtInvoiceNo.Text = dgvReturnItemInvoice.SelectedRows[0].Cells["InvoiceNo"].Value.ToString();
            }
        }

        #endregion

        #region Barcode Scanning
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
        //            //string barcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //            string barcode = (ScanValue != "" && ScanValue != "0" ? Convert.ToString(ScanValue + txtBarcode.Text) : txtBarcode.Text);
        //            barcode = barcode.Replace("\r", "").Trim();//Added on 25-June-2014 for Avoidng Newline and Spaces by Seenivasan 
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode);
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                ClearBarcodeValues();
        //                cmbItemName.SelectAll();
        //                cmbItemName.Focus();
        //            }
        //            else
        //            {
        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "PurchaseReturnInvoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                    }
        //                    else
        //                    {
        //                        GeneralFunction.Information("ItemNotRegisteredInformAdmin", "PurchaseReturnInvoice");
        //                        ClearBarcodeValues();
        //                        cmbItemName.SelectAll();
        //                        cmbItemName.Focus();
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
                        ClearBarcodeValues();
                        cmbItemName.SelectAll();
                        cmbItemName.Focus();
                    }
                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "PurchaseReturnInvoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                                frmItem = null;
                            }
                            else
                            {
                                GeneralFunction.Information("ItemNotRegisteredInformAdmin", "PurchaseReturnInvoice");
                                ClearBarcodeValues();
                                cmbItemName.SelectAll();
                                cmbItemName.Focus();
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

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

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
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") & (dgvReturnInvoice.BackgroundColor != Color.Gray))
            {
                GeneralFunction.Information("Pleaseclosetheinvoicefirst", "PurchaseReturnInvoice");
                return;
            }
            ObjHelper.printfunction();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "PurchaseReturnInvoice" + " " + txtInvoiceNo.Text, "Purchase Return", "Print Purchase return invoice details", Convert.ToInt32(InvoiceAction.Yes));
        }
        #endregion

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
        //            cmbSupplierNo_SelectedIndexChanged(cmbSupplierNo, EventArgs.Empty);
        //            break;
        //    }
        //}

        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    //if (((ComboBox)sender).DroppedDown == true)
            //    //((ComboBox)sender).DroppedDown = false;
            //    txtBarcode.Focus();//Added on 25-June-2014 for setting focus to avoid the Barcode scan issues by Seenivasan
            //}
            ////else if(e.KeyValue!=13 && e.KeyData!=Keys.Back && e.KeyData!=Keys.Delete)
            ////{
            ////    ((ComboBox)sender).DroppedDown = true;
            ////}this Condition commended to fix the DropDown Suggest Append
            ////else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))
            ////{
            //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //        (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //        && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //        && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //        && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock))
            //{
            //    if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }
            //}
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
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control btn in c.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
                dgvReturnInvoice.Font = dgvReturnItemInvoice.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtInvoiceNo.Text != string.Empty)
                {
                    ObjHelper.FindByInvoiceNo();
                    GetNewYearReceiptNo();
                    int InvoiceNo = ObjHelper.GetPurID();
                    ObjHelper.ReturnItemDetailsList = ObjHelper.ReturnItemDetailsList.Where(a => a.InvoiceNo == Convert.ToInt32(InvoiceNo)).ToList();
                    AssignDataSourceforItem();
                }
            }
            else if (e.KeyChar > 58 || e.KeyChar < 47 && e.KeyChar != 35 && e.KeyChar != 45 && e.KeyChar != 8)
                e.Handled = true;
        }

        private void cmbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GetNewYearReceiptNo()
        {
            if (txtInvoiceNo.Text.Contains('-'))
            {
                string[] strNewYearNo = txtInvoiceNo.Text.Split('-');
                if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
                {
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.Year = Convert.ToInt32(strNewYearNo[0]);
                    ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(strNewYearNo[1]);
                }
                else
                { GeneralFunction.ErrInfo("Invoice ID Not in Correct format", "PurchaseInvoice"); }
            }
            else
            {
                ObjHelper.ObjBALClass.ObjPurchaseReturn.Year = ObjHelper.ObjBALClass.ObjPurchaseReturn.Year;
                ObjHelper.ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(txtInvoiceNo.Text);
            }
        }

        private void PurchaseReturnInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtReturnQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbnReturnnbyItem.Checked == true)
            {
                if (dgvReturnItemInvoice.SelectedRows.Count > 0)
                {
                    if (!(Convert.ToInt32(txtReturnQty.Text == string.Empty ? "0" : txtReturnQty.Text) <= Convert.ToInt32(dgvReturnItemInvoice.SelectedRows[0].Cells["quantity"].Value)))
                    {
                        GeneralFunction.Information("ReturnQtyEqual", "PurchaseReturnInvoice");
                    }
                }
            }

        }
    }
}
