using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CommonHelper;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using System.Threading;


namespace BumedianBM.ArabicView
{
    public partial class Bank_Withdraw : Form,IDisposable
    {
        #region Declaration
        BankWithdrawHelperClass objBankWithdrawHelperClass = new BankWithdrawHelperClass();
        Boolean valBank = false;
        string Status = "New";
        #endregion

        #region Constructor
        public Bank_Withdraw()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
        }
        #endregion

        #region Load
        private void Bank_Withdraw_Load(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = UserScreenLimidations.Print;
                objBankWithdrawHelperClass.BindMaxIdToControls(out Status);
                AssignToComboBox();
                Lbl_UName.Text = GeneralFunction.UserName;
                ReceiptNoTextChanged();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Bank_Withdraw_Load");
            }
        }
        #endregion

        #region Methods
        public void SetLanguage()
        {
            lblAmount.Text = Additional_Barcode.GetValueByResourceKey("Amount");
            lblBank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            lblBranch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblReceiptNo.Text = Additional_Barcode.GetValueByResourceKey("ReceiptNo");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblWithdrawDone.Text = Additional_Barcode.GetValueByResourceKey("WDDoneBy");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            grpStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            this.Text = Additional_Barcode.GetValueByResourceKey("Bankwith");

        }

        private void AssignToComboBox()
        {
            if (ObjectHelper.GeneralObjectClass.BankList.Count > 0)
            {
                cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmbBank.DisplayMember = "BankName";
                cmbBank.ValueMember = "BankNameID";
                cmbBank.DataSource = ObjectHelper.GeneralObjectClass.BankList;
               
                cmbBank.SelectedIndex = -1;
                cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
            }
            if (ObjectHelper.GeneralObjectClass.BankList.Count > 0)
            {
                cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchNameID";
                cmbBranch.DataSource = ObjectHelper.GeneralObjectClass.BranchList;
                
                cmbBranch.SelectedIndex = -1;

            }
        }
        private void Clear()
        {
            txtReceiptNo.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtWithdrawDoneBy.Text = string.Empty;
            cmbBank.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            txtAmount.Text = "0.000";
            txtBankBalance.Text = "0.00";
            dtpDate.Value = DateTime.Now;
        }

        private void GetReceiptNo()
        {
            string[] strNewYearNo = txtReceiptNo.Text.Split('-');
            if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
            {
                objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year = Convert.ToInt32(strNewYearNo[0]);
                objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo = Convert.ToInt64(strNewYearNo[1]);
            }
            else
            { GeneralFunction.Information("Bill NO is Not in correct format", this.Tag.ToString()); }
        }
        private void ReceiptNoTextChanged()
        {

            if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
            {
                Clear();
                //if (objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year == objBankWithdrawHelperClass.CurrentYear)
                //    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                //else
                //    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year.ToString() + '-' + objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                lblStatusName.ForeColor = Color.Green;
                btnSave.Enabled = false;
                btnDelete.Enabled = true;
                AssignToControls();
            }
            else if (Status == GeneralFunction.ChangeLanguageforCustomMsg("Deleted"))
            {
                //if (objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year == objBankWithdrawHelperClass.CurrentYear)
                //    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                //else
                //    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year.ToString() + '-' + objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                lblStatusName.ForeColor = Color.Red;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                AssignToControls();
            }
            else if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("New"))
            {
                Clear();
                // objBankWithdrawHelperClass.New();
                lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("New");
                lblStatusName.ForeColor = Color.Blue;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                txtDescription.Focus();
                AssignToControls();
                if (objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year == objBankWithdrawHelperClass.CurrentYear)
                    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                else
                    txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year.ToString() + '-' + objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
            }


        }
        public void AssignToControls()
        {
            dtpDate.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.ProcessDate.ToShortDateString();
            txtDescription.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Description;
            txtWithdrawDoneBy.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.DepositDoneBy;
            cmbBranch.SelectedValue = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BranchNameID;
            cmbBank.SelectedValue = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BankNameID;
            txtAmount.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Amount.ToString("######0.000");
            txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.ReceiptNo.ToString();
        }
        public void AssignFromControls()
        {
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.ProcessDate = dtpDate.Value;
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.CreatedDate = dtpDate.Value;
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Description = txtDescription.Text.Trim();
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.DepositDoneBy = txtWithdrawDoneBy.Text.Trim();
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BankNameID = cmbBank.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmbBank.SelectedValue);
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BranchNameID = cmbBranch.SelectedIndex == -1 ? 0 : Convert.ToInt16(cmbBranch.SelectedValue);
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BalanceAmount = Convert.ToDecimal(txtBankBalance.Text.Trim());
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.CreatedBy = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.ModifiedBy = GeneralFunction.UserId;
        }

        private void SetYearForRcptNo()
        {
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year = objBankWithdrawHelperClass.CurrentYear;
            objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo = Convert.ToInt64(txtReceiptNo.Text);
        }
        //private void SetFont()
        //{
        //    var Culture = Thread.CurrentThread.CurrentUICulture;
        //    if (Culture.Name == "en-US")
        //    {

        //        Properties.Settings.Default.Save();
        //        foreach (Control cti in this.Controls)
        //        {
        //            (from Control ctrl in cti.Controls
        //             select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
        //        }

        //    }
        //}





        public void ChangeProperties(string ctrl)
        {
            this.Controls[ctrl].Focus();
            this.Controls[ctrl].Select();



        }

        #endregion

        #region Main Events
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objBankWithdrawHelperClass.BindMaxIdToControls(out Status);

                ReceiptNoTextChanged();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }

        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objBankWithdrawHelperClass.LeftNavigation(out Status))
                {
                    ReceiptNoTextChanged();
                    if (objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year == objBankWithdrawHelperClass.CurrentYear)
                        txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                    else
                        txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year.ToString() + '-' + objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_Previous_Click");
            }
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objBankWithdrawHelperClass.RightNavigation(out Status))
                {
                    ReceiptNoTextChanged();
                    if (objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year == objBankWithdrawHelperClass.CurrentYear)
                        txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                    else
                        txtReceiptNo.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.Year.ToString() + '-' + objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo.ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_Next_Click");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssignFromControls();
                if (objBankWithdrawHelperClass.Save())
                {
                    objBankWithdrawHelperClass.CreateEmptyRecord();
                    ReceiptNoTextChanged();
                }
                else
                {
                    ChangeProperties(objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName);

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
                if (objBankWithdrawHelperClass.Delete())
                {
                    Status =GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    ReceiptNoTextChanged();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDelete_Click");
            }
        }
        #endregion

        #region OtherEvents
        private void txtNewYear_No_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtReceiptNo.Text = ((txtNewYear_No.Text != string.Empty) && (txtNewYear_No.Text.Contains("-") == false)) ? txtNewYear_No.Text : txtReceiptNo.Text;
                txtReceiptNo.Text = (txtNewYear_No.Text == string.Empty) ? "1" : txtReceiptNo.Text;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtNewYear_No_KeyUp");
            }
        }

        private void txtNewYear_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtNewYear_No_KeyPress");
            }
        }
        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BankBranch();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Branch_SelectedIndexChanged");
            }
        }

        private void BankBranch()
        {
            if (cmbBank.SelectedIndex != -1 | cmbBranch.SelectedIndex != -1)
            {
                objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BankNameID = cmbBank.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbBank.SelectedValue);
                objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BranchNameID = cmbBranch.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbBranch.SelectedValue);
                objBankWithdrawHelperClass.GetBankBalanceDetails();
                txtBankBalance.Text = objBankWithdrawHelperClass.objBankWithdrawBALClass.objBankObjectClass.BalanceAmount.ToString("########0.000");
            }
        }

        private void cmbBank_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyValue == 13)
                {
                    if (valBank)
                    {
                        cmbBranch.Focus();
                        valBank = false;
                    }
                    else
                    {
                        valBank = true;
                        cmbBank.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_KeyUp");
            }
        }



        private void Bank_Withdraw_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "bank_withdrow_KeyDown");
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text != "" || txtAmount.Text != "0.000")

                { txtAmount.Text = txtAmount.Text == string.Empty ? "0.000" : Convert.ToDecimal(txtAmount.Text).ToString(".000"); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Amount_Leave");
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    txtWithdrawDoneBy.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtDescription_KeyPress");
            }
        }

        private void txtWithdrawDoneBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                { cmbBank.Focus(); }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtWithdrawDoneBy_KeyPress");
            }
        }

        private void txtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (!(txtReceiptNo.Text.Length == 0))
                    {
                        if (txtReceiptNo.Text.Contains('-'))
                            GetReceiptNo();
                        else
                            SetYearForRcptNo();
                        if (objBankWithdrawHelperClass.KeyPress(out Status))
                        {
                            ReceiptNoTextChanged();
                            AssignToControls();
                        }
                        else
                        { GeneralFunction.Information("ThisReceiptNodoesntexist", this.Tag.ToString()); }
                    }
                    else { GeneralFunction.Warning("Enter Proper Receipt NO", this.Tag.ToString()); }
                }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Warning("Only Numbers Allowed", this.Tag.ToString());
                        txtReceiptNo.SelectAll();
                        txtReceiptNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_ReceiptNo_KeyPress");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                { InvokeOnClick(btnSave, EventArgs.Empty); }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
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

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Amount_KeyPress");
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Status == GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
                {

                    objBankWithdrawHelperClass.PrintOptionDetails();
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



        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txtAmount.Focus();
                    txtAmount.SelectAll();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "KeyDown");
            }
        }

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

        //private void cmbBank_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbBank_SelectedIndexChanged(cmbBank, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_DropDownClosed");
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
        //        cmbBank_SelectedIndexChanged(cmbBank, new EventArgs());
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_DropDownClosed");
        //    }

        //}

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                foreach (Control lable in this.Controls.OfType<Label>())
                {
                    lable.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control button in this.Controls.OfType<Button>())
                {
                    button.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control btn in groupBox2.Controls.OfType<Button>())
                {
                    btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                grpStatus.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
            }
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankBranch();
        }

    }

}


