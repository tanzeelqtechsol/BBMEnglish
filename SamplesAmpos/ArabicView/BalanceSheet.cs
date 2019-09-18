using System;
using CommonHelper;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using BumedianBM.View;
using System.Threading;
using System.Globalization;
using System.Configuration;
using SergeUtils;

//*** Created By :G.Saradhaa
namespace BumedianBM.ArabicView
{
    public partial class frmBalanceSheet : Form, IDisposable
    {
        #region Declaration
        string Logintext = string.Empty;
        string AgentName = string.Empty;
        public static bool IsNewYear = false;
        public static long BalanceSheetPurchaseID = 0;
        enum Type { Receipt, Invoice, Both }
        public BumedianBM.ViewHelper.BalanceSheetHelper objBalanceSheetHelper = new ViewHelper.BalanceSheetHelper();
        #endregion

        #region Constructor
        public frmBalanceSheet()
        {
            //  setfocus();
            InitializeComponent();
            SetLanguage();
            setFont();
            UserScreenLimitation();
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "";
            culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
            Thread.CurrentThread.CurrentCulture = culture;
            dtpToTime.CustomFormat = "hh:mm tt";
            dtpFromTime.CustomFormat = "hh:mm tt";

            dtpFromTime.Value = Convert.ToDateTime("12:00 AM");
            dtpToTime.Value = Convert.ToDateTime("11:59 PM");
        }
        #endregion

        #region Load
        private void BalanceSheet_Load(object sender, EventArgs e)
        {
            try
            {
                cmbAgentName.MatchingMethod = StringMatchingMethod.UseRegexs;
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.Format = DateTimePickerFormat.Custom;

                dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                cmbAgentID.DisplayMember = "AgentID";
                cmbAgentID.ValueMember = "Name";
                cmbAgentID.DataSource = ObjectHelper.GeneralObjectClass.AgentDetails.Where(a => (!a.AgentType.Contains("104"))).ToList().Select(i => i.AgentId).ToList();



                cmbAgentName.DisplayMember = "Name";
                cmbAgentName.ValueMember = "AgentID";
                cmbAgentName.DataSource = new BindingSource();
                cmbAgentName.DataSource = ObjectHelper.GeneralObjectClass.AgentDetails.Where(a => (!a.AgentType.Contains("104"))).ToList().Select(i => i.Name).ToList();

                if (objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID != 0 && objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName.Length != 0)
                {
                    cmbAgentID.Text = objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID.ToString();
                    cmbAgentName.Text = objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                }
                else
                    cmbAgentID.SelectedIndex = cmbAgentName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region SetLanguageMethod
        public void SetLanguage()
        {
            lblAgentNo.Text = Additional_Barcode.GetValueByResourceKey("AgentNo");
            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            lblBSForAgent.Text = Additional_Barcode.GetValueByResourceKey("BSForAgent");
            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblFromTime.Text = Additional_Barcode.GetValueByResourceKey("FT");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblTotalDiscount.Text = Additional_Barcode.GetValueByResourceKey("TDiscount");
            lblToTime.Text = Additional_Barcode.GetValueByResourceKey("TT");
            lblTotalPayable.Text = Additional_Barcode.GetValueByResourceKey("TPayable");
            lblTotalReceivable.Text = Additional_Barcode.GetValueByResourceKey("TReceivable");
            btnAgentDetails.Text = Additional_Barcode.GetValueByResourceKey("AgentDetails");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnEndOfTheDay.Text = Additional_Barcode.GetValueByResourceKey("EndOfDay");
            btnOpenInvoice.Text = Additional_Barcode.GetValueByResourceKey("OInvoice");
            btnOpenReceipt.Text = Additional_Barcode.GetValueByResourceKey("OReceipt");
            btnPayMoneyRecipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnReciveMoneyRecipt.Text = Additional_Barcode.GetValueByResourceKey("RecReceipt");
            btnReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            btnReturnItems.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem");
            btnSearch.Text = Additional_Barcode.GetValueByResourceKey("Search");
            chkAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            dgvBalanceSheet.Columns["Date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgvBalanceSheet.Columns["Account"].HeaderText = Additional_Barcode.GetValueByResourceKey("Account");
            dgvBalanceSheet.Columns["Description"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvBalanceSheet.Columns["Receivable"].HeaderText = Additional_Barcode.GetValueByResourceKey("Receivable");
            dgvBalanceSheet.Columns["Payable"].HeaderText = Additional_Barcode.GetValueByResourceKey("Payable");
            dgvBalanceSheet.Columns["Balance"].HeaderText = Additional_Barcode.GetValueByResourceKey("Balance");
            dgvBalanceSheet.Columns["ArabicDescription"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            this.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                dgvBalanceSheet.Columns["Description"].Visible = true;
                dgvBalanceSheet.Columns["ArabicDescription"].Visible = false;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
            {
                dgvBalanceSheet.Columns["ArabicDescription"].Visible = true;
                dgvBalanceSheet.Columns["Description"].Visible = false;
            }
        }
        #endregion

        #region MainMethods
        private void Number_Click(object sender, EventArgs e)
        {
            try
            {
                Button text = sender as Button;
                Logintext += text.Text;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            try
            {
                if (Logintext != string.Empty)
                {
                    MasterFrom master = new MasterFrom();
                    master.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter your password");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgentID.SelectedIndex != -1)
                {
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID != 0 ? objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID : Convert.ToInt32(cmbAgentID.Text);
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmbAgentID.Text == string.Empty ? "0" : cmbAgentID.Text);
                    if (chkAll.Checked)
                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = 1;
                    else
                    {
                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = 0;
                        //Time span is added to search based on From date as well as from time.  On july 1
                        TimeSpan TsFrom = new TimeSpan(dtpFromTime.Value.Hour, dtpFromTime.Value.Minute, dtpFromTime.Value.Second);
                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceFromDate = Convert.ToDateTime(dtpFromDate.Value.Date + TsFrom);
                        TimeSpan TsTo = new TimeSpan(dtpToTime.Value.Hour, dtpToTime.Value.Minute, dtpToTime.Value.Second);
                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceToDate = Convert.ToDateTime(dtpToDate.Value.Date + TsTo);
                    }
                    if (objBalanceSheetHelper.Search())
                    {
                        dgvBalanceSheet.AutoGenerateColumns = false;
                        dgvBalanceSheet.DataSource = objBalanceSheetHelper.dtAdd;
                        AssignMoney(objBalanceSheetHelper.TotalBalance, objBalanceSheetHelper.TotalDiscount, objBalanceSheetHelper.TotalAmtPaid, objBalanceSheetHelper.TotalAmtReceived);
                        objBalanceSheetHelper.NewBalanceClass();
                    }
                    else
                    {
                        dgvBalanceSheet.DataSource = null;
                        AssignMoney(0, 0, 0, 0);
                    }
                }
                else
                {
                    GeneralFunction.Information("EmptyAgentName", this.Tag.ToString());
                    cmbAgentName.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                objBalanceSheetHelper.NewBalanceClass();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnEndOfTheDay_Click(object sender, EventArgs e)
        {
            try
            { objBalanceSheetHelper.DisplayEndOfDayForm(); }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnAgentDetails_Click(object sender, EventArgs e)
        {
            try
            {
                AssignNameID();
                objBalanceSheetHelper.DisplayAgentDetailForm();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnReturnItems_Click(object sender, EventArgs e)
        {
            try
            {
                frmattention objattention = new frmattention();
                objattention.ShowDialog();

                string getval = objattention.strFormName;

                if (getval.Trim() == "SALE")
                {
                    if (UserScreenLimidations.SaleReturnInvoice)
                    {
                        Sales_Return_Invoice returnInvoice = new Sales_Return_Invoice();
                        returnInvoice.ShowDialog();
                        returnInvoice = null;
                    }
                }
                else if (getval.Trim() == "PURCHASE")
                {
                    if (UserScreenLimidations.PurchaseReturnInvoice)
                    {
                        PurchaseReturnInvoice returnInvoice = new PurchaseReturnInvoice();
                        returnInvoice.ShowDialog();
                        returnInvoice = null;
                    }
                }
                objattention = null;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void btnOpenInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                DateCultureWithoutTime();
                OpenBySplit(Convert.ToInt16(Type.Invoice));
                DateCultureWithTime();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void MoneyReceipt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            object tag = bt.Tag;
            string ButtonName = bt.Name;
            try
            {
                bool Success = false;
                AssignNameID();
                if (tag.ToString() == "RecReceipt")
                    Success = objBalanceSheetHelper.ReceiveReceipt();
                else if (tag.ToString() == "PayReceipt")
                    Success = objBalanceSheetHelper.PayReceipt();
                if (Success)
                { btnSearch_Click(sender, e); }
                else
                {
                    GeneralFunction.Information("EmptyAgentName", this.Tag.ToString());
                    cmbAgentName.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        private void btnOpenReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                DateCultureWithoutTime();
                OpenBySplit(Convert.ToInt16(Type.Receipt));
                DateCultureWithTime();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                Report frmReport = new Report();
                frmReport.ShowDialog();
                frmReport = null;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region OtherMethods
        private void OpenBySplit(Int16 TypeID)
        {
            string BalanceSheetMessage = string.Empty;
            if (TypeID == 1) { BalanceSheetMessage = "SelectInvoice"; }
            else { BalanceSheetMessage = "SelectReceipt"; }

            string[] InvoiceNameID = new string[3] { string.Empty, string.Empty, string.Empty };
            int LastIndex;
            if (dgvBalanceSheet.Rows.Count > 0)
            {
                LastIndex = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().LastIndexOf(' ');
                if (LastIndex == -1)
                    return;
                InvoiceNameID[0] = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().Substring(0, LastIndex);
                InvoiceNameID[1] = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().Substring(LastIndex);
                //////----------------To get the particular transaction id based on year sequence and get the transaction year ------------------
                // InvoiceNameID[2] = dgvBalanceSheet.SelectedRows[0].Cells["Year"].Value.ToString();

                InvoiceNameID[2] = dgvBalanceSheet.SelectedRows[0].Cells["Id"].Value.ToString();
                BalanceSheetPurchaseID = Convert.ToInt64(dgvBalanceSheet.SelectedRows[0].Cells["Id"].Value);
                long year = Convert.ToInt32(dgvBalanceSheet.SelectedRows[0].Cells["Year"].Value);
                long currentyear = Convert.ToInt32(DateTime.Now.ToString("yy"));
                if (year != currentyear)
                {
                    IsNewYear = true;
                }
                else
                {
                    IsNewYear = false;
                }
                    ///-------------------------------------------------------------------------------------------
                    if (InvoiceNameID[0].Contains("-"))
                {
                    int index = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().IndexOf(" ");
                    InvoiceNameID[0] = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().Substring(0, index);
                    InvoiceNameID[1] = dgvBalanceSheet.SelectedRows[0].Cells["Description"].Value.ToString().Substring(LastIndex);
                }
                if (dgvBalanceSheet.SelectedRows.Count > 0 && InvoiceNameID[0].Length > 0)
                {
                    if (InvoiceNameID[0] == objBalanceSheetHelper.dictDescription.Keys.ToArray()[4])
                    {
                        AssignNameID();
                        objBalanceSheetHelper.dictPayReceipt = new Dictionary<string, dynamic>();
                        objBalanceSheetHelper.dictPayReceipt.Add("Receivable", dgvBalanceSheet.SelectedRows[0].Cells["Receivable"].Value.ToString());
                        objBalanceSheetHelper.dictPayReceipt.Add("Balance", Convert.ToDecimal(dgvBalanceSheet.SelectedRows[0].Cells["Balance"].Value));
                    }
                    if ((TypeID == Convert.ToInt16(Type.Invoice) && InvoiceNameID[0] != objBalanceSheetHelper.dictDescription.Keys.ToArray()[5] && InvoiceNameID[0] != objBalanceSheetHelper.dictDescription.Keys.ToArray()[4]) || (TypeID == Convert.ToInt16(Type.Receipt) && (InvoiceNameID[0] == objBalanceSheetHelper.dictDescription.Keys.ToArray()[5] || InvoiceNameID[0] == objBalanceSheetHelper.dictDescription.Keys.ToArray()[4])) || (TypeID == Convert.ToInt16(Type.Both)))
                    {
                        objBalanceSheetHelper.OpenInvoice(InvoiceNameID);
                    }
                    else GeneralFunction.Information(BalanceSheetMessage, this.Tag.ToString());
                }
                else GeneralFunction.Information(BalanceSheetMessage, this.Tag.ToString());
            }
        }
        private void AssignMoney(decimal Balance, decimal Discounts, decimal AmountPaid, decimal AmountReceived)
        {
            txtBalance.Text = Balance.ToString("0.000");
            txtBalance.ForeColor = Convert.ToDecimal(txtBalance.Text) < 0 ? Color.Red : Color.Green;
            txtTotalDiscounts.Text = Discounts.ToString("0.000");
            txtTotalPaid.Text = AmountPaid.ToString("0.000");
            txtTotalRecived.Text = AmountReceived.ToString("0.000");
        }

        private void AssignNameID()
        {
            objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = cmbAgentID.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbAgentID.Text);
            objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbAgentName.SelectedIndex == -1 ? string.Empty : cmbAgentName.Text;
        }
        #endregion

        #region OtherEvents

        #region SelectedIndexChanged
        private void cmbAgentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgentID.SelectedIndex != -1)
                    cmbAgentName.Text = ObjectHelper.GeneralObjectClass.AgentDetails.Where(a => a.AgentId == Convert.ToInt32(cmbAgentID.Text)).ToList()[0].Name;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgentName.SelectedIndex != -1)
                    cmbAgentID.Text = ObjectHelper.GeneralObjectClass.AgentDetails.Where(a => a.Name == cmbAgentName.Text).ToList()[0].AgentId.ToString();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        private void dgvBalanceSheet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DateCultureWithoutTime();
                OpenBySplit(Convert.ToInt16(Type.Both));
                DateCultureWithTime();
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
               // GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void frmBalanceSheet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information objQuickPriceInformation = new Quick_Price_Information();
                    objQuickPriceInformation.ShowDialog();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsDigit(e.KeyChar) == false) && e.KeyChar != 8 && e.KeyChar != 127)
                { e.Handled = true; }
                else
                { e.Handled = false; }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                InvokeOnClick(btnSearch, EventArgs.Empty);
                if (cmbAgentName.SelectedIndex > -1)
                {
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmbAgentID.Text == string.Empty ? "0" : cmbAgentID.Text);
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbAgentName.Text;
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceFromDate = dtpFromDate.Value.Date;
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceToDate = dtpToDate.Value.Date;
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = chkAll.Checked ? 1 : 0;
                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Balance = chkAll.Checked ? 1 : 0;
                    //objBalanceSheetHelper.TotalAmtReceived = Convert.ToDecimal(txtTotalRecived.Text == string.Empty ? "0" : txtTotalRecived.Text);
                    //objBalanceSheetHelper.TotalBalance= Convert.ToDecimal(txtBalance.Text == string.Empty ? "0" : txtBalance.Text);
                    //objBalanceSheetHelper.TotalAmtPaid= Convert.ToDecimal(txtTotalPaid.Text == string.Empty ? "0" : txtTotalPaid.Text);
                    objBalanceSheetHelper.printBalanceSheet();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void dtpFromDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentID_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                cmbAgentID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbAgentID_SelectedIndexChanged(cmbAgentID, new EventArgs());

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentID_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
                {
                    cmbAgentID.AutoCompleteMode = AutoCompleteMode.None;
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        //private void cmbAgentName_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbAgentName.AutoCompleteMode = AutoCompleteMode.None;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }
        //}

        //private void cmbAgentName_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbAgentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbAgentName_SelectedIndexChanged(cmbAgentName, new EventArgs());

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }
        //}

        private void cmbAgentName_TextChanged(object sender, EventArgs e)
        {
            //    List<int > text = new List<int >();
            //    text.Add(1);
            //  List<string>name=new List<string>();
            //name=    ObjectHelper.GeneralObjectClass.AgentDetails.Sort().ToList();



        }
        #endregion


        private void cmbAgentName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    cmbAgentName.DroppedDown = false;
                }
                else
                {
                    if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
                    {
                        if (((ComboBox)sender).DataSource != null)
                        {
                            if (((ComboBox)sender).DroppedDown == true)
                                ((ComboBox)sender).DroppedDown = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    cmbAgentID.DroppedDown = false;
                }
                else
                {
                    if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
                    {
                        if (((ComboBox)sender).DataSource != null)
                        {
                            if (((ComboBox)sender).DroppedDown == true)
                                ((ComboBox)sender).DroppedDown = false;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToTime.Enabled = dtpFromTime.Enabled = dtpToDate.Enabled = dtpFromDate.Enabled = (!chkAll.Checked);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control ct in panel3.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ct in groupBox2.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ct in panel2.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ct in tableLayoutPanel2.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                dgvBalanceSheet.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void frmBalanceSheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DateCultureWithoutTime();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void UserScreenLimitation()
        {
            btnReciveMoneyRecipt.Enabled = UserScreenLimidations.ReceiveReceipt;
            btnPayMoneyRecipt.Enabled = UserScreenLimidations.PayReceipt;
            btnEndOfTheDay.Enabled = UserScreenLimidations.EndOfDays;
            btnAgentDetails.Enabled = UserScreenLimidations.AgentFile;
            btnReports.Enabled = UserScreenLimidations.Reports;
        }


        #region Date Format Culture Changes
        private void DateCultureWithoutTime()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void DateCultureWithTime()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "";
            culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
            Thread.CurrentThread.CurrentCulture = culture;
            dtpToTime.CustomFormat = "hh:mm tt";
            dtpFromTime.CustomFormat = "hh:mm tt";
        }

        #endregion

        private void frmBalanceSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgvBalanceSheet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
