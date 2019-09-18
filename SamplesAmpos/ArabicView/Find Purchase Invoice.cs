using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using BALHelper;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial  class Find_Purchase_Invoice : Form, IDisposable
    {
        #region Initialization and Variable
        FindPurchaseInvoiceHelper ObjHelper;
        internal Boolean isOpenFromPurchase = false, iscount = false;
        MasterDataBALClass ObjMasterDataBALClass;
        #endregion

        #region Constructor
        public Find_Purchase_Invoice()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjHelper = new FindPurchaseInvoiceHelper();
            ObjMasterDataBALClass = new MasterDataBALClass();
            LoadData();
            if (GeneralOptionSetting.FlagAlertPayDates == "Y")
                CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts);
            UserLimitation();
            timer1.Enabled = true;
            timer1.Interval = 650;
            timer1.Tick += new EventHandler(timer1_Tick);
            dtpFromTime.Value = Convert.ToDateTime("12:00 AM");
            dtpToTime.Value = Convert.ToDateTime("11:59 PM");
        }
        #endregion

        #region Events
        #region LoadEvent
        private void Find_Purchase_Invoice_Load(object sender, EventArgs e)
        {
            cmbSupplierName.MatchingMethod = StringMatchingMethod.UseRegexs;
            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//
        }

        #endregion

        #region IndexChanged Event

        private void cmbSupplierNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).Name == "cmbSupplierNo" && cmbSupplierNo.SelectedValue != null)
                    cmbSupplierName.Text = cmbSupplierNo.SelectedValue == null ? string.Empty : cmbSupplierNo.SelectedValue.ToString();
                // else
                //    cmbSupplierNo.Text = cmbSupplierName.SelectedValue == null ? string.Empty : cmbSupplierName.SelectedValue.ToString();
                ////else if (((ComboBox)sender).Name == "cmbSupplierName")
                ////    cmbSupplierNo.Text = cmbSupplierName.SelectedValue == null ? string.Empty : cmbSupplierName.SelectedValue.ToString();
                //// cmbSupplierName.Text = cmbSupplierNo.SelectedValue == null ? string.Empty : cmbSupplierNo.SelectedValue.ToString();
                //SetObjectFromControl();
                //ObjHelper.BalanceAmountofAgent();
                //txtBalance.ForeColor = (GeneralFunction.ClientDebt >= 0) ? Color.Green : Color.Red;
                //txtBalance.Text = GeneralFunction.ClientDebt.ToString("########0.000");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUser.SelectedIndex != -1 && cmbUser.Text != string.Empty)
                {
                    this.SetObjectFromControl();
                    ObjHelper.InvoiceTypeIndex = -1;
                    ObjHelper.FindPurchasList();
                    AssignDataSourcs();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void SupplierTextChange(object sender, EventArgs e)
        {
            if (cmbSupplierName.Text == string.Empty || cmbSupplierNo.Text == string.Empty)
                cmbSupplierNo.Text = cmbSupplierName.Text = string.Empty;
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == "cmbSupplierName" && cmbSupplierName.SelectedValue != null)
                cmbSupplierNo.Text = cmbSupplierName.SelectedValue == null ? string.Empty : cmbSupplierName.SelectedValue.ToString();
            //else if (((ComboBox)sender).Name == "cmbSupplierName")
            //    cmbSupplierNo.Text = cmbSupplierName.SelectedValue == null ? string.Empty : cmbSupplierName.SelectedValue.ToString();
            // cmbSupplierName.Text = cmbSupplierNo.SelectedValue == null ? string.Empty : cmbSupplierNo.SelectedValue.ToString();
            SetObjectFromControl();
            ObjHelper.BalanceAmountofAgent();
            txtBalance.ForeColor = (GeneralFunction.ClientDebt >= 0) ? Color.Green : Color.Red;
            txtBalance.Text = GeneralFunction.ClientDebt.ToString("########0.000");
        }
        #endregion

        #region GridEvent
        private void dgvFindInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt64(dgvFindInvoice.SelectedRows[0].Cells["invoiceno"].Value);
                ObjHelper.ObjBALClass.ObjPurchase.SetStatus = Convert.ToInt32(dgvFindInvoice.SelectedRows[0].Cells["Status1"].Value);
                ObjHelper.GridCellDoubleClick();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void dgvFindInvoice_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFindInvoice.SelectedRows.Count > 0)
                {
                    if (dgvFindInvoice.SelectedRows[0].Cells["invoiceno"].Value.ToString() != string.Empty)
                    {
                        ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt64(dgvFindInvoice.SelectedRows[0].Cells["invoiceno"].Value);
                        ObjHelper.ObjBALClass.ObjPurchase.SetStatus = Convert.ToInt32(dgvFindInvoice.SelectedRows[0].Cells["status1"].Value);
                        if (dgvFindInvoice.SelectedRows[0].Cells["status"].Value.ToString() != null)
                        {
                            ObjHelper.GetFindItemInvoiceDetails();
                        }
                    }
                    AssigndgvFindItemSource();
                }
                else
                {
                    dgvFindItem.DataSource = null;
                    //dgvFindItem.BackgroundColor = Color.Beige;''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    dgvFindItem.BackgroundColor = Color.WhiteSmoke; 
                    dgvFindItem.DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region KeyEvent
        private void Find_Purchase_KeyDown(object sender, KeyEventArgs e)
        {
            Quick_Price_Information pric;
            try
            {
                if (e.KeyCode == Keys.F11 && btnItemInformation.Enabled == true)
                {
                    btnItemInformation_Click(sender, e);
                }
                if (e.KeyData == Keys.F12)
                {
                    pric = new Quick_Price_Information();  // Performance issue fixed by Praba on 19-Nov
                    pric.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                pric = null;
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (dgvFindInvoice.Rows.Count != 0)
                {
                    SplidInvoiceID();
                    ObjHelper.InvoiceNoSearch();
                    AssignDataSourcs();
                }
                else { return; }
            }
            else if ((e.KeyChar < 47 || e.KeyChar > 58) && (e.KeyChar != 45))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Button Event
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                ObjHelper.FindPurchasList();
                AssignDataSourcs();
                if (ObjHelper.PurchaseInvoiceDetails.Count == 0)
                    ObjHelper.ItemGridSource(dgvFindItem);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnGoToInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFindInvoice.SelectedRows.Count > 0)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt64(dgvFindInvoice.SelectedRows[0].Cells["invoiceno"].Value);
                    ObjHelper.ObjBALClass.ObjPurchase.SetStatus = Convert.ToInt32(dgvFindInvoice.SelectedRows[0].Cells["Status1"].Value);
                    ObjHelper.GridCellDoubleClick();
                }
                else
                    GeneralFunction.Information("EmptyInvoiceNo", "FindPurchaseInvoice");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard frmItem = new ItemCard();
            frmItem.ShowDialog();
            frmItem = null;
        }

        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            frmBalanceSheet balanceSheet;
            try
            {
                balanceSheet = new frmBalanceSheet(); //Performance fine tune by praba on 19-Nov
                if (cmbSupplierName.Text.Length != 0)
                {
                    balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmbSupplierNo.Text);
                    balanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbSupplierName.Text;
                    balanceSheet.ShowDialog();
                }
                else
                    balanceSheet.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                balanceSheet = null;
            }
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            if (isOpenFromPurchase)
                this.Close();
            else
            {
                Purchase_Invoice frmPurchase = new Purchase_Invoice();
                frmPurchase.ShowDialog();
                frmPurchase = null;
            }
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            PurchaseReturnInvoice frmReturn = new PurchaseReturnInvoice();
            frmReturn.ShowDialog();
            frmReturn = null;
        }

        private void btnItemInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjHelper.ObjItemInfo.Visible == false)
                {
                    if (dgvFindItem.SelectedRows.Count > 0)
                    {
                        ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgvFindItem.SelectedRows[0].Cells["itemno"].Value);
                        ObjHelper.ObjItemInfo.ItemName = dgvFindItem.SelectedRows[0].Cells["item"].Value.ToString();
                        ObjHelper.ObjItemInfo.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
        #endregion

        #region Method
        private void SetLanguage()
        {

            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            lblFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice");
            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblFromTime.Text = Additional_Barcode.GetValueByResourceKey("FT");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblInvoiceType.Text = Additional_Barcode.GetValueByResourceKey("IType");
            lblProfit.Text = Additional_Barcode.GetValueByResourceKey("Profit");
            lblSale.Text = Additional_Barcode.GetValueByResourceKey("Sales");
            lblSupplier.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            lblSupplierNo.Text = Additional_Barcode.GetValueByResourceKey("SupplierNo");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblToTime.Text = Additional_Barcode.GetValueByResourceKey("TT");
            lblUser.Text = Additional_Barcode.GetValueByResourceKey("User");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet")+"        ";
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "        ";
            btnDetailedReport.Text = Additional_Barcode.GetValueByResourceKey("DetailedReport");
            btnEndOfTheDay.Text = Additional_Barcode.GetValueByResourceKey("EndOfDay") + "        ";
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find") + "        ";
            btnGoToInvoice.Text = Additional_Barcode.GetValueByResourceKey("GoToInvoice") + "        ";
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard") + "        ";
            btnItemInformation.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11") + "        ";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print") + "        ";
            btnPurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurInvoice") + "        ";
            btnReport.Text = Additional_Barcode.GetValueByResourceKey("Report") + "        ";
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem") + "        ";
            this.grbNotes.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            this.Text = Additional_Barcode.GetValueByResourceKey("FindPurchaseInvoice");
            chkAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            Lbl_Net.Text = Additional_Barcode.GetValueByResourceKey("Net");
            Lbl_Paid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
            Lbl_Remaining.Text = Additional_Barcode.GetValueByResourceKey("Remaining");
            Lbl_Total.Text = Additional_Barcode.GetValueByResourceKey("Total");
            Lbl_TotalDiscount.Text = Additional_Barcode.GetValueByResourceKey("TDiscount");
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("AllInvoice"));
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("New"));
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("Closed"));
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("ITPur"));
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("ITReturn"));
            cmbInvoiceType.Items.Add(Additional_Barcode.GetValueByResourceKey("ITOrder"));
            dgvFindInvoice.Columns["newinvno"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            dgvFindInvoice.Columns["date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgvFindInvoice.Columns["supplier"].HeaderText = Additional_Barcode.GetValueByResourceKey("Supplier");
            dgvFindItem.Columns["itemtotal"].HeaderText = dgvFindInvoice.Columns["total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvFindInvoice.Columns["discount"].HeaderText = Additional_Barcode.GetValueByResourceKey("Discount");
            dgvFindInvoice.Columns["net"].HeaderText = Additional_Barcode.GetValueByResourceKey("Net");
            dgvFindItem.Columns["created"].HeaderText = dgvFindInvoice.Columns["user"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgvFindItem.Columns["itemtime"].HeaderText = dgvFindInvoice.Columns["time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgvFindItem.Columns["returnqty"].HeaderText = dgvFindInvoice.Columns["returned"].HeaderText = Additional_Barcode.GetValueByResourceKey("Returned");
            dgvFindInvoice.Columns["Status1"].HeaderText = dgvFindInvoice.Columns["status"].HeaderText = Additional_Barcode.GetValueByResourceKey("Status");
            dgvFindInvoice.Columns["Paid"].HeaderText = Additional_Barcode.GetValueByResourceKey("Paid");
            dgvFindInvoice.Columns["invoiceno"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            dgvFindItem.Columns["item"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvFindItem.Columns["exp_date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvFindItem.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvFindItem.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgvFindItem.Columns["UnitPrice"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvFindItem.Columns["Sale"].HeaderText = Additional_Barcode.GetValueByResourceKey("Sale");
            dgvFindItem.Columns["Cost"].HeaderText = Additional_Barcode.GetValueByResourceKey("Cost");
            dgvFindItem.Columns["ItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvFindItem.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
        }

        private void LoadData()
        {
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;

            cmbCategory.DisplayMember = "Company";
            cmbCategory.ValueMember = "CompanyID";
            cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;

            cmbSupplierName.DisplayMember = "Name";
            cmbSupplierName.ValueMember = "AgentID";
            cmbSupplierName.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;

            cmbSupplierNo.DisplayMember = "AgentID";
            cmbSupplierNo.ValueMember = "Name";
            cmbSupplierNo.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;

            cmbUser.DisplayMember = "FirstName";
            cmbUser.ValueMember = "UserId";
           // cmbUser.DataSource = ObjectHelper.GeneralObjectClass.UserList;//Commented on 25-Nov-2014
            //*****'Added on 25-Nov-2014******************
            List<EmployeeObjectClass> lstUser = new List<EmployeeObjectClass>();
            lstUser = ObjMasterDataBALClass.UserDetailsBal();
            lstUser = lstUser.Where(a => (a.Status == 1)).ToList();
            cmbUser.DataSource = lstUser;
            //********************************************

            cmbSupplierName.SelectedIndex = cmbSupplierNo.SelectedIndex = cmbUser.SelectedIndex = -1;
            cmbSupplierNo.SelectedIndexChanged += new EventHandler(cmbSupplierNo_SelectedIndexChanged);
            cmbSupplierName.SelectedIndexChanged += new EventHandler(this.cmbSupplierName_SelectedIndexChanged);
            cmbUser.SelectedIndexChanged += new EventHandler(cmbUser_SelectedIndexChanged);
            cmbInvoiceType.SelectedIndex = Convert.ToInt32(InvoiceType.PurchaseInvoice);
            cmbUser.SelectedIndexChanged += new EventHandler(cmbUser_SelectedIndexChanged);
            //cmbSupplierName.TextChanged += new EventHandler(this.SupplierTextChange);
            //cmbSupplierNo.TextChanged += new EventHandler(this.SupplierTextChange);
            lbl_UserName.Text = GeneralFunction.UserName;
        }

        private void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjPurchase.SupplierName = cmbSupplierName.Text.ToString();
            if (cmbSupplierName.SelectedIndex != -1)
                ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = Convert.ToInt32(cmbSupplierNo.Text == string.Empty ? "0" : cmbSupplierNo.Text);
            else
                ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = 1;
            ObjHelper.ObjBALClass.ObjPurchase.SetStatus = chkAll.Checked == true ? 1 : 0;
            ObjHelper.ObjBALClass.ObjPurchase.FromDate = Convert.ToDateTime(dtpFromDate.Value.ToShortDateString() + " " + dtpFromTime.Value.ToShortTimeString());
            ObjHelper.ObjBALClass.ObjPurchase.ToDate = Convert.ToDateTime(dtpToDate.Value.ToShortDateString() + " " + dtpToTime.Value.ToShortTimeString());
            ObjHelper.InvoiceTypeIndex = cmbInvoiceType.SelectedIndex;
            ObjHelper.ObjBALClass.ObjPurchase.UserId = Convert.ToInt32(cmbUser.SelectedValue == null ? 0 : cmbUser.SelectedValue);
            SplidInvoiceID();
        }

        private void SetControlFromObject()
        {
            txtTotal.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemTotal.ToString();
            txtTotalDiscount.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemDiscount.ToString("#####0.000");
            txtPaid.Text = ObjHelper.ObjBALClass.ObjPurchase.Paid.ToString("#####0.000");
            txtNet.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemNet.ToString();
            txtRemaining.Text = ObjHelper.ObjBALClass.ObjPurchase.Remaining.ToString("#####0.000");//(decimal.Parse(txtNet.Text) - decimal.Parse(txtPaid.Text)).ToString("#######0.000"); //(decimal.Parse(txtNet.Text) - decimal.Parse(txtPaid.Text)).ToString(); // 
            txtCost.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemCost.ToString();
            txtSale.Text = ObjHelper.ObjBALClass.ObjPurchase.SalePrice.ToString();
            txtDiscount.Text = ObjHelper.ObjBALClass.ObjPurchase.Discount.ToString("#####0.000");
            if (!ObjHelper.InvStatus)
                txtProfit.Text = ObjHelper.ObjBALClass.ObjPurchase.ItemGrossAmt.ToString(); //(decimal.Parse(txtSale.Text) - decimal.Parse(txtCost.Text)).ToString();Commended on 06/06/2014
            else
                txtProfit.Text = "0.000";
        }

        private void AssignDataSourcs()
        {
            ObjHelper.GridSource(dgvFindInvoice);
            SetControlFromObject();
        }

        private void SplidInvoiceID()
        {
            if (txtInvoiceNo.Text.Length != 0 && txtInvoiceNo.Text != string.Empty)
            {
                if (txtInvoiceNo.Text.Contains('-'))
                {
                    string[] str = txtInvoiceNo.Text.Split('-');
                    ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(str[0]);
                    ObjHelper.ObjBALClass.ObjPurchase.Year = Convert.ToInt32(str[1]);
                }
                else
                {
                    ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = Convert.ToInt32(txtInvoiceNo.Text);
                    ObjHelper.ObjBALClass.ObjPurchase.Year = ObjHelper.CurrentYear;
                }
            }
            else
                ObjHelper.ObjBALClass.ObjPurchase.NewYearInvoiceID = 0;
        }

        private void AssigndgvFindItemSource()
        {
            ObjHelper.ItemGridSource(dgvFindItem);
            SetControlFromObject();
        }

        private void UserLimitation()
        {
            btnPrint.Enabled = (UserScreenLimidations.Print == true) ? true : false;
            btnPurchaseInvoice.Enabled = (UserScreenLimidations.PurchaseInvoice == true) ? true : false;
            btnReturnItem.Enabled = (UserScreenLimidations.PurchaseReturnInvoice == true) ? true : false;
            btnBalanceSheet.Enabled = (UserScreenLimidations.BalanceSheet == true) ? true : false;
            btnItemCard.Enabled = (UserScreenLimidations.ItemCard == true) ? true : false;
            btnReport.Enabled = (UserScreenLimidations.Reports == true) ? true : false;
            btnEndOfTheDay.Enabled = (UserScreenLimidations.EndOfDays == true) ? true : false;
            btnGoToInvoice.Enabled = (UserScreenLimidations.PurchaseReturnInvoice == true) ? true : false;
            btnItemInformation.Enabled = (UserScreenLimidations.ItemInfo);
            // dgvFindItem.Columns["itemno"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvFindItem.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvFindItem.Columns["exp_date"].Visible = (GeneralOptionSetting.FlagPurchase_HideExpiryFiled == "Y") ? false : true;
            dgvFindItem.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;

        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            GeneralFunction.BlinkText(e, RtxtNotesAndAlerts);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvFindInvoice.Rows.Count > 0)
            {
                if (cmbSupplierName.Text != string.Empty)
                    ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = Convert.ToInt32(cmbSupplierName.SelectedValue);
                else
                    ObjHelper.ObjBALClass.ObjPurchase.SupplierNo = 0;
                ObjHelper.ObjBALClass.ObjPurchase.SetStatus = chkAll.Checked == true ? 1 : 0;

                if (chkAll.Checked)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.ToDate = ObjHelper.ObjBALClass.ObjPurchase.FromDate = null;
                }
                else
                {
                    ObjHelper.ObjBALClass.ObjPurchase.FromDate = dtpFromDate.Value;
                    ObjHelper.ObjBALClass.ObjPurchase.ToDate = dtpToDate.Value;
                    ObjHelper.ObjBALClass.ObjPurchase.ToTime = dtpToTime.Value;
                    ObjHelper.ObjBALClass.ObjPurchase.FromTime = dtpFromTime.Value;
                }
                if (cmbInvoiceType.SelectedIndex != -1)
                {
                    ObjHelper.InvoiceTypeIndex = cmbInvoiceType.SelectedIndex;
                }
                if (txtInvoiceNo.Text.Length != 0)
                {
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                }
                else
                    ObjHelper.ObjBALClass.ObjPurchase.InvoiceNo = 0;
                ObjHelper.btnPrint();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "FindPurchaseInvoice", "", "Print find purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
            }
            else return;
        }

        private void RtxtNotesAndAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = RtxtNotesAndAlerts.SelectedText.Trim();
            Purchase_Invoice.ReorderandBalance(str);
        }

        private void btnEndOfTheDay_Click(object sender, EventArgs e)
        {
            End_of_the_Day frmEOD = new End_of_the_Day();
            frmEOD.ShowDialog();
            frmEOD = null;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report frmReport = new Report();
            frmReport.ShowDialog();
            frmReport = null;
        }

        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            if (dgvFindInvoice.Rows.Count > 0)
            {
                ObjHelper.ObjBALClass.ObjPurchase.Remarks = Convert.ToInt32(dgvFindInvoice.SelectedRows[0].Cells["Status1"].Value);
                ObjHelper.DetailedPurchaseInvoice();
            }
            else
            {
                GeneralFunction.Information("EmptyInvoiceNo", "FindPurchaseInvoice");
            }
        }

        //private void cmbSupplierName_DropDown(object sender, EventArgs e)
        //{
        //    //if (((ComboBox)(sender)).DroppedDown == false)
        //    //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //    // }
        //}

        //private void cmbSupplierName_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    switch (((ComboBox)sender).Name)
        //    {
        //        case "cmbSupplierName":
        //            if (!iscount)
        //                cmbSupplierName_SelectedIndexChanged(cmbSupplierName, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //        case "cmbSupplierNo":
        //            if (!iscount)
        //                cmbSupplierNo_SelectedIndexChanged(cmbSupplierNo, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //        case "cmbUser":
        //            if (!iscount)
        //                cmbUser_SelectedIndexChanged(sender, EventArgs.Empty);
        //            else
        //                iscount = false;
        //            break;
        //    }
        //}

        private void cmbSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
            //else if (e.KeyValue != 13 && e.KeyData!=Keys.Delete&& e.KeyData!=Keys.Back)
            //    ((ComboBox)sender).DroppedDown = true;
            //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))
            //{
            else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                    (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                    && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                    && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                    && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock))
            {
                if (((ComboBox)sender).DataSource != null) //no need to open the when the item list is empty
                {
                    if (((ComboBox)sender).DroppedDown == true)
                        ((ComboBox)sender).DroppedDown = false;
                }
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
                dgvFindInvoice.Font = dgvFindItem.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void lbl_UserName_Click(object sender, EventArgs e)
        {

        }

        private void Find_Purchase_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
