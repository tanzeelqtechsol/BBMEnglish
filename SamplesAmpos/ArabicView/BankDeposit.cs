using System;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using CommonHelper;
using System.Data;
using System.Drawing;
using BumedianBM.Interface;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;



namespace BumedianBM.ArabicView
{
    public partial class BankDeposit : Form, IDisposable
    {
        #region Declaration
        string Status = string.Empty;
        BankDepositHelperClass objBankDepositHelper;
        #endregion

        #region Constructor
        public BankDeposit()
        {
            InitializeComponent();
            SetLanguage();
            objBankDepositHelper = new BankDepositHelperClass();
            //AccountAbstract.GetAccountForm(GeneralFunction.FormName);
            setFont();

        }
        #endregion


        #region Methods

        private void SetLanguage()
        {
            lblAmount.Text = Additional_Barcode.GetValueByResourceKey("Amount");
            lblBank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            lblBranch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblReceiptNo.Text = Additional_Barcode.GetValueByResourceKey("ReceiptNo");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            grpStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            lblDepositDoneBy.Text = Additional_Barcode.GetValueByResourceKey("DepoDoneBy");
            lblReason.Text = Additional_Barcode.GetValueByResourceKey("Reason");
            grpChooseBankBranch.Text = Additional_Barcode.GetValueByResourceKey("ChoBankBranch");
            lbl_Bank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            Lbl_Branch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            this.Text = Additional_Barcode.GetValueByResourceKey("Bankde");
            cmbReason.Items.Add(Additional_Barcode.GetValueByResourceKey("CashSales"));
            cmbReason.Items.Add(Additional_Barcode.GetValueByResourceKey("ReceiveAccountsReceivable"));
            cmbReason.Items.Add(Additional_Barcode.GetValueByResourceKey("MovedFromAnotherAccount"));
        }

        private void Clear()
        {
            txtAmount.Text = "0.000";
            txtDepositDoneBy.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);
            cmb_BanktoMove.SelectedIndexChanged -= new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
            cmb_BranchtoMove.SelectedIndexChanged -= new System.EventHandler(cmbBranchtoMove_SelectedIndexChanged);
            cmbBank.SelectedIndex = -1;
            cmb_BanktoMove.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            cmb_BranchtoMove.SelectedIndex = -1;
            cmbReason.SelectedIndex = -1;
            cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);
            cmb_BanktoMove.SelectedIndexChanged += new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
            cmb_BranchtoMove.SelectedIndexChanged += new System.EventHandler(cmbBranchtoMove_SelectedIndexChanged);
            dtpDate.Value = DateTime.Now;
            grpChooseBankBranch.Visible = false;
            txtBalance1.Text = string.Empty;
            txtBalance2.Text = string.Empty;
        }

        private void AssignToComboBox()
        {
            if (GeneralObjectClass.BankList.Count > 0)//modified by saradhaa.G(27/11/2013)
            {
                cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmbBank.DisplayMember = "BankName";
                cmbBank.ValueMember = "BankNameID";
                cmbBank.DataSource = GeneralObjectClass.BankList;

                cmbBank.SelectedIndex = -1;
                cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmb_BanktoMove.SelectedIndexChanged -= new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
                cmb_BanktoMove.BindingContext = new BindingContext();
                cmb_BanktoMove.DisplayMember = "BankName";
                cmb_BanktoMove.ValueMember = "BankNameID";
                cmb_BanktoMove.DataSource = GeneralObjectClass.BankList;

                cmb_BanktoMove.SelectedIndex = -1;
                cmb_BanktoMove.SelectedIndexChanged += new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
            }
            if (GeneralObjectClass.BranchList.Count > 0)
            {
                cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchNameID";
                cmbBranch.DataSource = GeneralObjectClass.BranchList;

                cmbBranch.SelectedIndex = -1;
                cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);
                cmb_BranchtoMove.SelectedIndexChanged -= new System.EventHandler(cmbBranchtoMove_SelectedIndexChanged);
                cmb_BranchtoMove.BindingContext = new BindingContext();
                cmb_BranchtoMove.DisplayMember = "BranchName";
                cmb_BranchtoMove.ValueMember = "BranchNameID";
                cmb_BranchtoMove.DataSource = GeneralObjectClass.BranchList;

                cmb_BranchtoMove.SelectedIndex = -1;
                cmb_BranchtoMove.SelectedIndexChanged += new System.EventHandler(cmbBranchtoMove_SelectedIndexChanged);
            }
        }

        private void GetReceiptNo()
        {
            string[] strNewYearNo = txtReceiptNo.Text.Split('-');
            if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
            {
                objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Year = Convert.ToInt16(strNewYearNo[0]);
                objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.YearSequenceNo = Convert.ToInt16(strNewYearNo[1]);
            }
            else
            { GeneralFunction.Information("Bill NO is Not in correct format", this.Tag.ToString()); }
        }

        public void SetReceiptStatus()
        {

            if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
            {
                Clear();

                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                lblStatusName.ForeColor = Color.Green;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;
                AssignToControls();
            }
            else if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("Deleted"))
            {
                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                lblStatusName.ForeColor = Color.Red;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                AssignToControls();
            }
            else if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("New"))
            {
                Clear();

                txtReceiptNo.Text = string.Empty;
                // objBankDepositHelper.New();
                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("New");
                lblStatusName.ForeColor = Color.Blue;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                txtDescription.Focus();
                AssignToControls();
                BindReceiptID();
            }
            else
                GeneralFunction.ErrInfo("This Receipt No doesn't exist", this.Tag.ToString().ToString());

        }

        private void BindReceiptID()
        {
            if (objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Year == objBankDepositHelper.CurrentYear)
                txtReceiptNo.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.YearSequenceNo.ToString();
            else
                txtReceiptNo.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Year.ToString() + '-' + objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.YearSequenceNo.ToString();
        }
        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {

                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    (from Control ctrl in cti.Controls
                     select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                }

            }
        }





        public void ChangeProperties(string ctrl)
        {
            int i = 0;

            foreach (Control controls in grpChooseBankBranch.Controls)
            {

                if (controls.Name == ctrl)
                {
                    controls.Focus();
                    controls.Select();
                    i += 1;
                    break;
                }

            }
            if (i == 0)
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }

        #endregion

        #region Values Assigning
        // Desc : Setting values from control
        public void AssignFromControls()
        {
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.CreatedDate = dtpDate.Value;
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ProcessDate = dtpDate.Value.Date;
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Description = txtDescription.Text.Trim();
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.DepositDoneBy = txtDepositDoneBy.Text.Trim();
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID = cmbBank.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmbBank.SelectedValue);
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID = cmbBranch.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmbBranch.SelectedValue);
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankToMoveID = cmb_BanktoMove.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmb_BanktoMove.SelectedValue);
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchToMoveID = cmb_BranchtoMove.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmb_BranchtoMove.SelectedValue);
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Amount = txtAmount.Text == string.Empty ? 0 : Convert.ToDecimal(txtAmount.Text.Trim());
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Reason = cmbReason.Text.Trim();
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ReasonId = cmbReason.SelectedIndex;
            if (cmbReason.SelectedIndex == 2)
            {
                objBankDepositHelper.Balance1 = txtBalance1.Text == string.Empty ? 0 : Convert.ToDecimal(txtBalance1.Text);
                objBankDepositHelper.Balance2 = txtBalance2.Text == string.Empty ? 0 : Convert.ToDecimal(txtBalance2.Text);
            }
        }
        // Desc : Seeting values to control
        public void AssignToControls()
        {
            this.dtpDate.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ProcessDate.ToShortDateString();
            this.txtDescription.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Description;
            this.txtDepositDoneBy.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.DepositDoneBy;
            cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
            this.cmbBank.SelectedValue = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID;
            this.cmbBranch.SelectedValue =objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID;
            cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
            this.txtAmount.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Amount.ToString("######0.000");
            this.cmbReason.SelectedIndex = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Reason == string.Empty ? objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ReasonId = -1 : objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ReasonId;
            cmb_BanktoMove.SelectedIndexChanged -= new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
            this.cmb_BanktoMove.SelectedValue = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankToMoveID == 0 ? 0 : objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankToMoveID;
            this.cmb_BranchtoMove.SelectedValue = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchToMoveID == 0 ? 0 : objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchToMoveID;
            cmb_BanktoMove.SelectedIndexChanged += new System.EventHandler(cmbBanktoMove_SelectedIndexChanged);
            // txtReceiptNo.Text = objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ReceiptNo.ToString();
        }
        private void SetYearForRcptNo()
        {
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.Year = objBankDepositHelper.CurrentYear;
            objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.YearSequenceNo = Convert.ToInt64(txtReceiptNo.Text);
        }
        #endregion

        #region Load

        private void BankDeposit_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                btnPrint.Enabled = UserScreenLimidations.Print;
                objBankDepositHelper.BindMaxIdToControls(out Status);
                //Status = "New";
                AssignToComboBox();
                lbl_UName.Text = CommonHelper.GeneralFunction.UserName;
                SetReceiptStatus();
                //    Focus("txtDepositDoneBy");
                //   object ct = txtDepositDoneBy;
                //   focus( ref ct);
                //   setfocus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "BankDeposit_Load");
            }
        }


        #endregion

        #region EventMethods

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objBankDepositHelper.BindMaxIdToControls(out Status);
                SetReceiptStatus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }

        private void btnNextReciept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objBankDepositHelper.RightNavigation(out Status))
                {
                    SetReceiptStatus();
                    BindReceiptID();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNextReciept_Click");
            }
        }

        private void btnPreviousReciept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objBankDepositHelper.LeftNavigation(out Status))
                {

                    SetReceiptStatus();
                    BindReceiptID();

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPreviousReciept_Click");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssignFromControls();
                if (objBankDepositHelper.Save())
                {

                    if (objBankDepositHelper.moveAccount == true)
                    {

                        objBankDepositHelper.CreateEmptyRecordForWithDraw();
                        objBankDepositHelper.moveAccount = false;
                    }
                    objBankDepositHelper.CreateEmptyRecord();

                    SetReceiptStatus();
                }
                else
                {
                    ChangeProperties(objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.ValidationcontrolName);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (objBankDepositHelper.Delete())
                {

                    Status =GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    SetReceiptStatus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDelete_Click");
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnClose_Click");
            }
        }
        #endregion

        #region OtherEvents
        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text != "" || txtAmount.Text != "0.000")
                {
                    decimal dec = txtAmount.Text == string.Empty ? 0 : Convert.ToDecimal(txtAmount.Text);
                    txtAmount.Text = dec.ToString("########0.000");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtAmount_Leave");
            }
        }

        #region KeyPress Event

        private void txtNewYearNo_KeyPress(object sender, KeyPressEventArgs e)
        {// e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
        }


        private void txtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtReceiptNo.Text.Length != 0)
                        if (txtReceiptNo.Text.Contains('-'))
                            GetReceiptNo();
                        else SetYearForRcptNo();
                    Status = objBankDepositHelper.GetRecordForNewYrNo();
                    SetReceiptStatus();
                }
                else if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                {
                    e.Handled = true;
                    GeneralFunction.Warning("Only Numbers Allowed", this.Tag.ToString());
                    txtReceiptNo.SelectAll();
                    txtReceiptNo.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtReceiptNo_KeyPress");
            }

        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                { SendKeys.Send("{TAB}"); }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || e.KeyChar == 127) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Warning("OnlyNumbersAllowed", this.Tag.ToString());
                        txtAmount.SelectAll();
                        txtAmount.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtAmount_KeyPress");
            }
        }
        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtDepositDoneBy.Focus();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtDescription_KeyPress");
            }
        }

        private void txtDepositDoneBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtAmount.Focus();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtDepositDoneBy_KeyPress");
            }
        }


        #endregion

        #region KeyDown Events

        private void BankDeposit_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "BankDeposit_KeyDown");
            }
        }
        #endregion

        #region KeyUP Events

        private void txtNewYearNo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtReceiptNo.Text = ((txtNewYearNo.Text != string.Empty) && (txtNewYearNo.Text.Contains("-") == false)) ? txtNewYearNo.Text : txtReceiptNo.Text;
                txtReceiptNo.Text = (txtNewYearNo.Text == string.Empty) ? "1" : txtReceiptNo.Text;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtNewYearNo_KeyUp");
            }
        }


        private void cmbBranchtoMove_KeyUp(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Bank,Branch,Reason SelectedIndexChanged
        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbBank.SelectedIndex != -1 && cmbBranch.SelectedIndex != -1)
                {
                    txtBalance1.Text = string.Empty;
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID = Convert.ToInt32(cmbBank.SelectedValue);
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID = Convert.ToInt32(cmbBranch.SelectedValue);
                    txtBalance1.Text = objBankDepositHelper.GetBankBalance().ToString("0.000");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_SelectedIndexChanged");
            }
        }
        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBank.SelectedIndex != -1 && cmbBranch.SelectedIndex != -1)
                {
                    txtBalance1.Text = string.Empty;
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID = Convert.ToInt32(cmbBank.SelectedValue);
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID = Convert.ToInt32(cmbBranch.SelectedValue);
                    txtBalance1.Text = objBankDepositHelper.GetBankBalance().ToString("0.000");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_SelectedIndexChanged");
            }
        }

        private void cmbBanktoMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_BanktoMove.SelectedIndex != -1 && cmb_BranchtoMove.SelectedIndex != -1)
                {
                    txtBalance2.Text = string.Empty;
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID = Convert.ToInt32(cmb_BanktoMove.SelectedValue);
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID = Convert.ToInt32(cmb_BranchtoMove.SelectedValue);
                    txtBalance2.Text = objBankDepositHelper.GetBankBalance().ToString("0.000");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBanktoMove_SelectedIndexChanged");
            }
        }

        private void cmbBranchtoMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_BanktoMove.SelectedIndex != -1 && cmb_BranchtoMove.SelectedIndex != -1)
                {
                    txtBalance2.Text = string.Empty;
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BankNameID = Convert.ToInt32(cmb_BanktoMove.SelectedValue);
                    objBankDepositHelper.objBankDepositBALClass.objBankobjectclass.BranchNameID = Convert.ToInt32(cmb_BranchtoMove.SelectedValue);
                    txtBalance2.Text = objBankDepositHelper.GetBankBalance().ToString("0.000");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranchtoMove_SelectedIndexChanged");
            }
        }
        // Desc : Reason SelectedIndexChanged
        public void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grpChooseBankBranch.Visible = (cmbReason.SelectedIndex == 2) ? true : false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbReason_SelectedIndexChanged");
            }
        }
        #endregion






        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
                {

                    objBankDepositHelper.PrintOptionDetails();
                }
                else if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("New"))
                {

                    GeneralFunction.Information("NoRecordsFound", ActionType.Print.ToString());
                }
                else
                {
                    GeneralFunction.Information("DeleteReceiptCannotPrint", ActionType.Print.ToString());
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_Print_Click");
            }

        }

        private void cmbReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    cmbBank.Focus();
                }
                else
                {
                    if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
                    {
                            if (((ComboBox)sender).DroppedDown == true)
                                ((ComboBox)sender).DroppedDown = false;
                        
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbReason_KeyDown");
            }
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    cmbBranch.Focus();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_KeyDown");
            }
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if ((cmbReason.SelectedIndex != 2))
                    {
                        btnSave_Click(sender, e);
                    }
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
                    cmb_BanktoMove.Focus();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_KeyDown");
            }
        }

        private void cmbBanktoMove_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                { cmb_BranchtoMove.Focus(); }
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBanktoMove_KeyDown");
            }
        }

        private void cmbBranchtoMove_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    InvokeOnClick(btnSave, EventArgs.Empty);
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranchtoMove_KeyDown");
            }
        }

        //private void cmbReason_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbReason.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbReason_DropDown");
        //    }
        //}

        //private void cmbReason_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbReason.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbReason_SelectedIndexChanged(sender, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbReason_DropDownClosed");
        //    }

        //}

        //private void cmbBank_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbBank_SelectedIndexChanged(sender, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_DropDownClosed");
        //    }
        //}

        //private void cmbBank_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbBank.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_DropDown");
        //    }

        //}

        //private void cmbBranch_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbBranch.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_DropDown");
        //    }
        //}

        //private void cmbBranch_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbBranch_SelectedIndexChanged(sender, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_DropDownClosed");
        //    }
        //}

        //private void cmb_BanktoMove_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmb_BanktoMove.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbBanktoMove_SelectedIndexChanged(sender, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmb_BanktoMove_DropDownClosed");
        //    }
        //}

        //private void cmb_BanktoMove_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmb_BanktoMove.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmb_BanktoMove_DropDown");
        //    }
        //}

        //private void cmb_BranchtoMove_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmb_BranchtoMove.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmb_BranchtoMove_DropDown");
        //    }
        //}

        //private void cmb_BranchtoMove_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmb_BranchtoMove.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbBranchtoMove_SelectedIndexChanged(sender, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmb_BranchtoMove_DropDownClosed");
        //    }

        //}

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                //List<Control> controls = new List<Control>();
                //controls = (from Control ctl in this.Controls select ctl).ToList();
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is GroupBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control lbl in grpChooseBankBranch.Controls)
                {
                    if (lbl is Button || lbl is Label || lbl is GroupBox)
                        lbl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control btn in groupBox2.Controls)
                {
                    if (btn is Button || btn is Label || btn is GroupBox)
                        btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                //for (int i = 0; i < controls.Count; i++)
                //{
                //    if (controls[i].Controls == Controls.OfType<Button>() || controls[i].Controls == Controls.OfType<Label>() || controls[i].Controls == Controls.OfType<GroupBox>())
                //        controls[i].Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                //}
                //for (int i = 0; i < controls.Count; i++)
                //{
                //    if ((controls[i].Controls is Button) || (controls[i].Controls is Label) || (controls[i].Controls is GroupBox))
                //        controls[i].Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                //}
                //controls.Where(a => (a.Controls == a.Controls.OfType<Button>()) | (a.Controls == a.Controls.OfType<Label>()) | (a.Controls == a.Controls.OfType<GroupBox>()));
            }
        }

        private void BankDeposit_FormClosed(object sender, FormClosedEventArgs e)
        {
           // objBankDepositHelper.objBankDepositBALClass = null;
            //objBankDepositHelper = null;
            this.Dispose();
        }
    }
}
