using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class frmCashCapital : Form, IDisposable
    {
        #region Declaration
        ViewHelper.CashCapitalHelper objCashCapitalHelper = new ViewHelper.CashCapitalHelper();
        string Status = string.Empty;
        #endregion

        #region Constructor
        public frmCashCapital()
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
        }
        #endregion

        #region SetLanguage
        public void SetLanguage()
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
            lblBank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            lblBranch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            lblNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            radBank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            radCash.Text = Additional_Barcode.GetValueByResourceKey("Cash");
            this.Text = Additional_Barcode.GetValueByResourceKey("CashCapital");

        }
        #endregion

        #region LoadEvent
        private void Cash_Capital_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                btnPrint.Enabled = UserScreenLimidations.Print;
                objCashCapitalHelper.BindMaxIdToControls(out Status);
                lblUName.Text = GeneralFunction.UserName;
                dtpDate.MaxDate = DateTime.Now.AddDays(1).AddMilliseconds(-1);
                radCash.Checked = true;
                cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);
                cmbBank.DisplayMember = "BankName";
                cmbBank.ValueMember = "BankNameID";
                cmbBank.DataSource = ObjectHelper.GeneralObjectClass.BankList;
                cmbBranch.ValueMember = "BranchNameID";
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.DataSource = ObjectHelper.GeneralObjectClass.BranchList;

                cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
                cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);

                //SetButtons();
                ReceiptNoTextChanged();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cash_Capital_Load");
            }
        }
        #endregion

        #region MainClickEvents
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssignValuesFromControls();
                if (objCashCapitalHelper.SaveCashDetails())
                {
                    //Status = "New";
                    // SetButtons();
                    ReceiptNoTextChanged();
                }
                else
                {
                    ChangeProperties(objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.ValidationcontrolName);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objCashCapitalHelper.LeftNavigation(out Status))
                {

                    ReceiptNoTextChanged();
                    if (objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year == objCashCapitalHelper.CurrentYear)
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                    else
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year.ToString() + '-' + objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPrevious_Click");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptNo.Text.Length != 0)
                    if (txtReceiptNo.Text.Contains('-'))
                        GetReceiptNo();
                    else SetYearForRcptNo();
                if (objCashCapitalHelper.RightNavigation(out Status))
                {
                    ReceiptNoTextChanged();
                    if (objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year == objCashCapitalHelper.CurrentYear)
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                    else
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year.ToString() + '-' + objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNext_Click");
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnClose_Click");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objCashCapitalHelper.BindMaxIdToControls(out Status);
                //Status = "New";
                ReceiptNoTextChanged();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (objCashCapitalHelper.Delete())
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

        #region Methods
        private void Clear()
        {
            txtReceiptNo.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtNotes.Text = string.Empty;
            radCash.Checked = true;
            radBank.Checked = false;
            txtAmount.Text = "0.000";
            cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);
            cmbBank.SelectedIndex = cmbBranch.SelectedIndex = -1;
            cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);
            dtpDate.Value = DateTime.Now;
        }

        private void AssignValuesFromControls()
        {
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.ProcessDate = Convert.ToDateTime(dtpDate.Value).Date; // changed due to format exception. Done By A.Manoj On June-26
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Description = txtDescription.Text;
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Reason = txtNotes.Text;
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Amount = Convert.ToDecimal(txtAmount.Text = txtAmount.Text == "" ? "0" : txtAmount.Text);
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BankNameID = cmbBank.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbBank.SelectedValue);
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BranchNameID = cmbBranch.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbBranch.SelectedValue);

        }



        private void GetReceiptNo()
        {
            try
            {
                string[] strNewYearNo = txtReceiptNo.Text.Split('-');
                if (!(strNewYearNo[0].Length == 0 || strNewYearNo[1].Length == 0))
                {
                    objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year = Convert.ToInt16(strNewYearNo[0]);
                    objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo = Convert.ToInt64(strNewYearNo[1]);
                }
                else
                { GeneralFunction.Information("Bill NO is Not in correct format", this.Tag.ToString()); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "GetReceiptNO");
            }
        }

        private void SetYearForRcptNo()
        {
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year = objCashCapitalHelper.CurrentYear;
            objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo = Convert.ToInt64(txtReceiptNo.Text);
        }

        private void ReceiptNoTextChanged()
        {
            try
            {

                if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
                {
                    Clear();

                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                    lblStatusName.ForeColor = Color.Green;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    AssignToControls();
                }
                else if (Status == GeneralFunction.ChangeLanguageforCustomMsg("Deleted"))
                {

                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    lblStatusName.ForeColor = Color.Red;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    AssignToControls();
                }
                else if (Status ==GeneralFunction.ChangeLanguageforCustomMsg("New"))
                {
                    Clear();
                    //objCashCapitalHelper.New();
                    lblStatusName.Text =GeneralFunction.ChangeLanguageforCustomMsg("New");
                    lblStatusName.ForeColor = Color.Blue;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    txtDescription.Focus();
                    AssignToControls();
                    if (objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year == objCashCapitalHelper.CurrentYear)
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                    else
                        txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year.ToString() + '-' + objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ReceiptTextChanged");
            }
        }

        public void AssignToControls()
        {
            dtpDate.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.ProcessDate.ToShortDateString();
            txtDescription.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Description;
            cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);
            cmbBranch.SelectedValue = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BranchNameID;
            cmbBank.SelectedValue = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BankNameID;
            cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
            cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);
            txtAmount.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Amount.ToString("######0.000");
            txtNotes.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Reason;
            radCash.Checked = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.DepositDoneBy == ViewHelper.CashCapitalHelper.CashTypes.Cash.ToString() ? true : false;
            radBank.Checked = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.DepositDoneBy == ViewHelper.CashCapitalHelper.CashTypes.Bank.ToString() ? true : false;

        }
        #endregion

        #region OtherEvents

        #region SelectedIndexChanged
        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(cmbBranch.SelectedIndex == -1))
                    objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BranchNameID = Convert.ToInt16(cmbBranch.SelectedValue);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBranch_SelectedIndexChanged");
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(cmbBank.SelectedIndex == -1))
                {
                    objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BankNameID = Convert.ToInt16(cmbBank.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbBank_SelectedIndexChanged");
            }
        }


        #endregion

        #region KeyPressEvents

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
                        if (objCashCapitalHelper.KeyPress(out Status))
                        {
                            //AssignToControls();
                            ReceiptNoTextChanged();
                            if (objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year == objCashCapitalHelper.CurrentYear)
                                txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();
                            else
                                txtReceiptNo.Text = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.Year.ToString() + '-' + objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.YearSequenceNo.ToString();

                        }
                        else
                        { GeneralFunction.Information("This Receipt No doesn't exist", this.Tag.ToString()); }
                    }
                    else
                    { GeneralFunction.Information("Enter Proper Receipt NO", this.Tag.ToString()); }
                }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45 || e.KeyChar == 127) != true)
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "frmCashCapital_KeyDown");
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    txtNotes.Focus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "txtDescription_KeyPress");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    InvokeOnClick(btnSave, EventArgs.Empty);
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 127) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Warning("Only Numbers Allowed", this.Tag.ToString());
                        txtAmount.SelectAll();
                        txtAmount.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "txtAmount_KeyPress");
            }
        }

        private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {


                if (e.KeyChar == 13)
                    SendKeys.Send("{TAB}");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "txtNotes_KeyPress");
            }
        }

        private void radBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    cmbBank.Focus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "radBank_KeyPress");
            }
        }

        private void radCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtAmount.SelectAll();
                    txtAmount.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "radCash_KeyPress");
            }
        }

        private void btnNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    InvokeOnClick(btnNew, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "btnNew_KeyPress");
            }
        }

        #endregion

        private void radCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radCash.Checked)
                {
                    cmbBank.Enabled = cmbBranch.Enabled = false;
                    objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BankNameID = objCashCapitalHelper.objCashCapitalBALClass.objBankObjectClass.BranchNameID = 0;

                    cmbBank.SelectedIndexChanged -= new System.EventHandler(cmbBank_SelectedIndexChanged);
                    cmbBranch.SelectedIndexChanged -= new System.EventHandler(cmbBranch_SelectedIndexChanged);

                    cmbBank.SelectedIndex = cmbBranch.SelectedIndex = -1;

                    cmbBank.SelectedIndexChanged += new System.EventHandler(cmbBank_SelectedIndexChanged);
                    cmbBranch.SelectedIndexChanged += new System.EventHandler(cmbBranch_SelectedIndexChanged);

                    objCashCapitalHelper.CashType = Convert.ToInt16(ViewHelper.CashCapitalHelper.CashTypes.Cash);
                }
                else
                {
                    cmbBank.Enabled = cmbBranch.Enabled = true;
                    objCashCapitalHelper.CashType = Convert.ToInt16(ViewHelper.CashCapitalHelper.CashTypes.Bank);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "radCash_CheckedChanged");
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAmount.Text) || txtAmount.Text != "0.000")
                { txtAmount.Text = txtAmount.Text == string.Empty ? "0.000" : Convert.ToDecimal(txtAmount.Text).ToString("0.000"); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "txtAmount_Leave");
            }
        }

        private void frmCashCapital_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information objQuickPriceInfo = new Quick_Price_Information();
                    objQuickPriceInfo.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "frmCashCapital_KeyDown");
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (Status == GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
                {

                    objCashCapitalHelper.PrintOptionDetails();
                }
                else if (Status == GeneralFunction.ChangeLanguageforCustomMsg("New"))
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPrint_Click");
            }
        }
        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {

                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    //(from Control ctrl in cti.Controls
                    // select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    if (cti is Button || cti is Label || cti is GroupBox || cti is RadioButton)
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control ctl in groupBox2.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is GroupBox || ctl is RadioButton)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }

            }
        }

        public void ChangeProperties(string ctrl)
        {

            this.Controls[ctrl].Focus();
            this.Controls[ctrl].Select();

        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                    cmbBranch.Focus();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBank_KeyDown");
            }
        }

        private void cmbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txtAmount.SelectAll();
                    txtAmount.Focus();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBranch_KeyDown");
            }
        }

        private void frmCashCapital_FormClosed(object sender, FormClosedEventArgs e)
        {
           // objCashCapitalHelper.objCashCapitalBALClass = null;
            //objCashCapitalHelper = null;
            this.Dispose();
        }

        //private void cmbBank_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false )
        //        {
        //            cmbBank.AutoCompleteMode = AutoCompleteMode.None;
        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBank_DropDown");
        //    }
        //}

        //private void cmbBank_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBank_DropDownClosed");
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
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBranch_DropDown");
        //    }
        //}

        //private void cmbBranch_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Cash Capital", "cmbBranch_DropDownClosed");

        //    }
        //}


    }
}
