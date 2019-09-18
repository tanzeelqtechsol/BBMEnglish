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
// Created By : G.Saradhaa(30/11/2013)
namespace BumedianBM.ArabicView
{
    public partial class frmSpending : Form, IDisposable
    {
        #region Declaration
        private ViewHelper.SpendingHelperClass objSpendingHelperClass = new ViewHelper.SpendingHelperClass();
        private int LabelStatus = 1;
        #endregion

        #region Constructor
        public frmSpending()
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
        }
        #endregion

        #region Load
        private void Spending_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                btnPrint.Enabled = UserScreenLimidations.Print;
                objSpendingHelperClass.BindMaxIdToControls();///Added on 10Jan2014
                SetButtons(1);
                cmbDescription.SelectedIndex = -1;
                lblUName.Text = GeneralFunction.UserName;
                dtpDate.MaxDate = DateTime.Now;
                cmbDescription.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Spending_Load");
            }
        }
        #endregion

        #region Methods
        public void SetLanguage()
        {
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            lblNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            grbStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            lblBillNo.Text = Additional_Barcode.GetValueByResourceKey("BillNo");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDetails.Text = Additional_Barcode.GetValueByResourceKey("Details");
            lblExpensesDescription.Text = Additional_Barcode.GetValueByResourceKey("SpendingDes");
            lblValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            this.Text = Additional_Barcode.GetValueByResourceKey("Spending");
        }

        private void AssignValuesFromControls()
        {
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Description = cmbDescription.Text;
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Details = txtDetails.Text;
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Notes = txtNote.Text;
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Value = Convert.ToDecimal(txtValue.Text == "" ? "0" : txtValue.Text);
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ProcessDate = Convert.ToDateTime(dtpDate.Value);


            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Remove = 0;

        }

        private void ClearControls()
        {
            txtBillNo.Text = "";
            txtDetails.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtValue.Text = "0.000";

            cmbDescription.SelectedIndex = -1;
            cmbDescription.Text = "";
            dtpDate.Text = DateTime.Now.ToShortDateString();
            cmbDescription.Focus();
            //  SetButtons(1);
        }

        private void SetButtons(int LabelType)
        {
            switch (LabelType)
            {
                case 0:
                    break;
                case 1:
                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
                    lblStatusName.ForeColor = Color.Blue;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                    cmbDescription.DataSource = objSpendingHelperClass.lstDescriptionList;
                    cmbDescription.SelectedIndex = -1;
                    cmbDescription.Focus();

                    if (objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year == objSpendingHelperClass.CurrentYear)
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                    else
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year.ToString() + '-' + objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                    // txtBillNo .Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ExpensesID.ToString();
                    break;
                case 2:

                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                    lblStatusName.ForeColor = Color.Green;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    break;
                case 3:
                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    lblStatusName.ForeColor = Color.Red;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        private void AssignValuesToControls()
        {
            txtValue.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Value.ToString();
            txtDetails.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Details;
            txtNote.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Notes;
            cmbDescription.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Description;
            dtpDate.Value = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ProcessDate.Date;
        }


        private void GetBillNo()
        {
            string[] strNewYearNo = txtBillNo.Text.Split('-');

            if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
            {
                objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year = Convert.ToInt32(strNewYearNo[0]);
                objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence = Convert.ToInt64(strNewYearNo[1]);
            }
            else
            { GeneralFunction.Information("This Receipt No doesn't exist", this.Tag.ToString()); }
        }

        private void SetYearForBillNo()
        {
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year = objSpendingHelperClass.CurrentYear;
            objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence = Convert.ToInt64(txtBillNo.Text);
        }
        #endregion

        #region MainEvents
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (objSpendingHelperClass.DeleteByID())
                {
                    SetButtons(3);
                    // ClearControls();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ExpensesID.ToString(), "EXPENSES", "Delete spending details", Convert.ToInt32(InvoiceAction.No));
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDelete_Click");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssignValuesFromControls();
                if (cmbDescription.SelectedIndex == -1)
                { objSpendingHelperClass.isAddDes = true; }
                if (objSpendingHelperClass.SaveSpendingDetails())
                {
                    if (objSpendingHelperClass.isAddDes)
                    {
                        objSpendingHelperClass.isAddDes = false;
                        cmbDescription.Text = "";
                    }
                    if (objSpendingHelperClass.CheckNavigation == true) { SetButtons(2); }
                    else { ClearControls(); SetButtons(1); }
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ExpensesID.ToString(), "EXPENSES", "Save spending details", Convert.ToInt32(InvoiceAction.No));
                }
                else
                {
                    ChangeProperties(objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ValidationString);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objSpendingHelperClass.CheckNavigation = false;
                // objSpendingHelperClass.New();
                objSpendingHelperClass.BindMaxIdToControls();
                ClearControls();
                SetButtons(1);

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                objSpendingHelperClass.CheckNavigation = true;
                if (txtBillNo.Text.Length != 0)
                    if (txtBillNo.Text.Contains('-'))
                        GetBillNo();
                    else SetYearForBillNo();
                if (objSpendingHelperClass.Previous(out LabelStatus))
                {
                    ClearControls();
                    AssignValuesToControls();
                    SetButtons(LabelStatus);
                    if (objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year == objSpendingHelperClass.CurrentYear)
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                    else
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year.ToString() + '-' + objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();

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
                objSpendingHelperClass.CheckNavigation = true;
                if (txtBillNo.Text.Length != 0)
                    if (txtBillNo.Text.Contains('-'))
                        GetBillNo();
                    else SetYearForBillNo();
                if (objSpendingHelperClass.Next(out LabelStatus))
                {
                    ClearControls();
                    AssignValuesToControls();
                    SetButtons(LabelStatus);
                    if (objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year == objSpendingHelperClass.CurrentYear)
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                    else
                        txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year.ToString() + '-' + objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();

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
        #endregion

        #region Key Events
        private void txtValue_Leave(object sender, EventArgs e)
        {
            try
            {
                if ((txtValue.Text).Length != 0 || txtValue.Text != "0.000")
                {
                    txtValue.Text = txtValue.Text == string.Empty ? "0.000" : Convert.ToDecimal(txtValue.Text).ToString("######0.000");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtValue_Leave");
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 127))
                    {
                        e.Handled = true;
                        GeneralFunction.Warning("OnlyNumbersAllowed", this.Tag.ToString());
                        txtValue.SelectAll();
                        txtValue.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtValue_KeyPress");
            }
        }

        private void frmSpending_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Spendings", "frmSpending_KeyDown");
            }
        }

        private void txtValue_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtValue.SelectAll();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtValue_MouseClick");
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (!(txtBillNo.Text.Length == 0))
                    {
                        if ((txtBillNo.Text).Contains('-'))
                            GetBillNo();
                        else SetYearForBillNo();
                        if (objSpendingHelperClass.TextChanged(out LabelStatus))
                        {
                            ClearControls();
                            if (objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year == objSpendingHelperClass.CurrentYear)
                                txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                            else
                                txtBillNo.Text = objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.Year.ToString() + '-' + objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.YearSequence.ToString();
                            SetButtons(LabelStatus);
                            AssignValuesToControls();
                            return;
                        }
                        // else GeneralFunction.Information("Enter Valid Bill NO", this.Tag.ToString());
                    }
                    else
                        GeneralFunction.Information("This Receipt No doesn't exist", this.Tag.ToString());
                }
                else
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Warning("Only Numbers Allowed", this.Tag.ToString());
                        txtBillNo.SelectAll();
                        txtBillNo.Focus();
                    }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtBillNo_KeyPress");
            }
        }

        private void txtDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                { SendKeys.Send("{TAB}"); }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtDetails_KeyPress");
            }
        }

        private void txtNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                { SendKeys.Send("{TAB}"); }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtNote_KeyPress");
            }
        }
        #endregion

        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStatusName.Text == GeneralFunction.ChangeLanguageforCustomMsg("Saved"))
                {
                    objSpendingHelperClass.PrintOptionDetails();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), objSpendingHelperClass.objSpendingBALClass.objSpendingObjectClass.ExpensesID.ToString(), "EXPENSES", "print spending details", Convert.ToInt32(InvoiceAction.No));

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
                //foreach (Control cti in this.Controls)
                //{
                //    (from Control ctrl in cti.Controls
                //     select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                //}
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button || ctrl is Label || ctrl is GroupBox || ctrl is CheckBox || ctrl is RadioButton)
                        ctrl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control btn in groupBox2.Controls)
                {
                    if (btn is Button || btn is Label || btn is GroupBox || btn is CheckBox || btn is RadioButton)
                        btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }

            }
        }
        public void ChangeProperties(string ctrl)
        {

            this.Controls[ctrl].Focus();
            this.Controls[ctrl].Select();

        }

        private void cmbDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    txtValue.SelectAll();
                    txtValue.Focus();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbDescription_KeyDown");
            }
        }

        private void frmSpending_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSpendingHelperClass.objSpendingBALClass = null;
            objSpendingHelperClass.lstDescriptionList = null;
            objSpendingHelperClass.lstYySeqWithMaxID = null;
            objSpendingHelperClass.ExpensesID = null;
            this.Dispose();
        }

        //private void cmbDescription_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbDescription.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    }
        //    catch (Exception ex)
        //    {

        //       GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //       GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbDescription_DropDownClosed");
        //    }
        //}

        //private void cmbDescription_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbDescription.AutoCompleteMode = AutoCompleteMode.None;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbDescription_DropDown");
        //    }
        //}


    }
}
