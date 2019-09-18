using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;
using ObjectHelper;
using HSB_ObjectHelper;
using BumedianBM.ViewHelper;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BumedianBM.ArabicView
{
    public partial class Receive_Receipt : Form, IDisposable
    {

        #region "Variables"
       
        public ReceiveReceiptHelper objReceiveReceiptHelper;
        public string[] getval, clientid, invid, getval2;
        public string invno;
        public decimal netvalue, balance;
        public string ReceivedFrom = string.Empty;
        public string NetAmt = "0.000";
        public string BalanceAmt = "0.000";
        public string Value = "0.000";
        public string Description = string.Empty;
        
        public string Balance = "0.000";
        public long ReceiptNo;
        // DataTable dtLocal = new DataTable();
        DataTable DtClient = new DataTable();
        //Receive_Receipt obj_recieve_receipt;
        public string ReceiptName = string.Empty;
        public decimal decBalance, decAmt, decRec, decTotal;
        bool boolbank = false, boolRecivedFrom = false;
        PayReceiptHelper objPayReceiptHelper;

        public int ItemIndex = -1;
        List<ReceiveReceiptObject> lstReceiveReceipt;
        string Status = string.Empty;
        bool isFromNavigator = false;
        #endregion

        #region Constructor
        public Receive_Receipt()
        {
            InitializeComponent();
            objPayReceiptHelper = new PayReceiptHelper();
            objReceiveReceiptHelper = new ReceiveReceiptHelper();
            lstReceiveReceipt = new List<ReceiveReceiptObject>();
            SetLanguage();
            SetFont();
        }
        #endregion

        #region Events

        #region Form Load
        private void Receive_Receipt_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                Dtp_Date.Format = DateTimePickerFormat.Custom;
                Dtp_Date.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                if (objReceiveReceiptHelper.balancesheetopen == true)
                {

                    if (frmBalanceSheet.IsNewYear)
                    {
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = Convert.ToInt32(ReceiptName);

                    }
                    else
                    {
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = Convert.ToInt32(frmBalanceSheet.BalanceSheetPurchaseID);

                    }
                }
                btnPrint.Enabled = UserScreenLimidations.Print;
                objReceiveReceiptHelper.BindReceiptMaxID(out Status);
                FillAgent();
                FillBankAndBranch();
                GetAllReceiptID();
                // objReceiveReceiptHelper.GetCurrentYear();
                btnNext.Enabled = false;
                if (ReceiptName == string.Empty && Value != "")
                {
                    Lbl_User.Text = GeneralFunction.UserName;
                    //   receiptno();
                    LabelStatus();
                    Cmb_ReceivedFrom.Text = ReceivedFrom;
                    // this.txt_receipt_no.TextChanged += new System.EventHandler(this.receiptno_textchanged);
                    // Set_NY_New_NO();
                    MTxt_Value.Text = Value;
                    //   MTxt_Balance.Text = Balance;
                    MTxt_Discription.Text = Description;
                    btnDelete.Enabled = false;
                    Cmb_ReceivedFrom.Enabled = (ReceivedFrom == string.Empty) ? true : false;
                    Cmb_ReceivedFrom.BackColor = Color.White;

                    chkCash.Checked = Sales_Invoice.PaymentTypeID == 0 || Sales_Invoice.PaymentTypeID == 1 ? true : false;
                    chkCard.Checked = Sales_Invoice.PaymentTypeID == 2 ? true : false;
                    chkCheck.Checked = Sales_Invoice.PaymentTypeID == 3 ? true : false;

                }
                else
                {
                    LabelStatus();
                    Lbl_User.Text = GeneralFunction.UserName;
                    // this.txt_receipt_no.TextChanged += new System.EventHandler(this.receiptno_textchanged);
                    txt_receipt_no.Text = ReceiptName;
                    if (objReceiveReceiptHelper.balancesheetopen)//added by Meena.R on 14/06/2014 to Open the Receive from the Balance Sheet
                        LoadReceiptDetails(objReceiveReceiptHelper.ListFromBalanceSheet);
                }
                HideControls();
                boolRecivedFrom = true;
                Dtp_Date.MaxDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
                //***********************Need to uncomment**************************************//
                //if (MTxt_Value.Text != string.Empty)
                //{
                //    SendKeys.Send("{ENTER}");
                //}
                //***********************Need to uncomment**************************************//

                // Txt_NewYear_No.Text = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.MaxpayReceiptNo.ToString(); // Commented on 24-Jan-14
                Txt_NewYear_No.Text = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr == null ? string.Empty : objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr.ToString();

                SetFocusToControls();

                if (PaymentTypes.fromPaymentTypesCheck)
                {
                    //Cmb_ReceivedFrom.Enabled = false;
                    if (PaymentTypes.isFromSales)
                    {
                    //    Cmb_ReceivedFrom.SelectedValue = Convert.ToInt32(Sales_Invoice.clientClosedSales);
                        MTxt_Value.Text = Sales_Invoice.salesTotal.ToString("####0.000");
                    }
                    else
                    {
                    //    Cmb_ReceivedFrom.SelectedValue = Convert.ToInt32(POS_Screen.clientClosedPos);
                        MTxt_Value.Text = POS_Screen.posTotal.ToString("####0.000");
                    }
                    //MTxt_Discription.Text = PaymentTypes.receiptDesc;
                    chkCash.Checked = false;
                    chkCard.Checked = false;
                    chkCheck.Checked = true;
                    BalanceCalculation();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Recive_recipt_Load");
            }
        }

        private void SetFocusToControls()
        {
            if (this.Tag == "SaleInvoice")
            {
                ChangeProperties("MTxt_Value");
                MTxt_Value.SelectAll();

            }
            //else if (this.Tag == "BalanceSheet")
            //{
            //    ChangeProperties("MTxt_Discription");
            //}
            else if (this.Tag == "ReceiveReceipt")
            {
                ChangeProperties("Cmb_ReceivedFrom");
            }
            else
            {
                ChangeProperties("MTxt_Value");
                MTxt_Value.SelectAll();

            }
        }
        #endregion

        #region Cmb_ReceivedFrom_SelectedIndexChanged
        private void Cmb_ReceivedFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_ReceivedFrom.Text != "" && Cmb_ReceivedFrom.Text != "System.Data.DataRowView")
                {
                    MTxt_Balance.Text = "0.000";
                    decBalance = 0; decAmt = 0; decRec = 0; decTotal = 0;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceAgent = Cmb_ReceivedFrom.SelectedValue.ToString();
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceFromDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceToDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceStatus = "1";
                    objPayReceiptHelper.GetBalanceHelper();
                    List<PayReceiptObject> lstBalance = objPayReceiptHelper.lstBalance;
                    if (lstBalance.Count > 0)
                    {
                        for (int i = 0; i < lstBalance.Count; i++)
                        {
                            decAmt = decAmt + (Convert.ToDecimal(lstBalance[i].NetAmount));
                            decRec = decRec + (Convert.ToDecimal(lstBalance[i].AmountRecieved));
                            //decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["MTB_NET_AMT"]);
                            //decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["MTB_AMT_RECEIVED"]);
                            if (lstBalance[i].AmountRecieved.ToString() == "0.0000" || lstBalance[i].AmountRecieved == 0)
                            {
                                decTotal = decTotal + (Convert.ToDecimal(lstBalance[i].NetAmount));
                                decBalance = decTotal;
                            }
                            else
                            {
                                if (lstBalance[i].NetAmount != 0)
                                {
                                    decTotal = decTotal + (Convert.ToDecimal(lstBalance[i].NetAmount));
                                    decBalance = decTotal;
                                }
                                decTotal = decTotal - (Convert.ToDecimal(lstBalance[i].AmountRecieved));
                                decBalance = decTotal;
                            }
                        }
                        //MTxt_Balance.Text = "-"+decBalance.ToString("#######0.000");

                        MTxt_Balance.Text = (decBalance * -1).ToString("#######0.000");
                        MTxt_Balance.ForeColor = ((decBalance * -1) < 0) ? Color.Red : Color.Green;
                    }
                    BalanceAmt = MTxt_Balance.Text;
                    if (!string.IsNullOrEmpty(MTxt_Value.Text))
                        BalanceCalculation();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_ReceivedFrom_SelectedIndexChanged");
            }

        }

        #endregion

        #region"CheckBox Checked Change Events"

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCash.Checked == true)
                {
                    chkCheck.Checked = false;
                    chkCard.Checked = false;
                    cmb_bank.Visible = false;
                    cmb_branch.Visible = false;
                    lblBank.Visible = false;
                    lblBranch.Visible = false;
                }
                else if (chkCard.Checked != true && chkCheck.Checked!=true)
                {
                    chkCard.Checked = true;
                    chkCard.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chk_cash_CheckedChanged");
            }

        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCheck.Checked == true)
                {
                    chkCash.Checked = false;
                    chkCard.Checked = false;
                    cmb_bank.Visible = true;
                    cmb_branch.Visible = true;
                    lblBank.Visible = true;
                    lblBranch.Visible = true;
                    cmb_bank.Focus();
                }
                else if (chkCard.Checked != true && chkCash.Checked != true)
                {
                    chkCash.Checked = true;
                    chkCash.Focus();
                    cmb_bank.Visible = false;
                    cmb_branch.Visible = false;
                    lblBank.Visible = false;
                    lblBranch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chk_check_CheckedChanged");
            }
        }




        #endregion

        #region Button Click Events

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                ReceiveReceiptHelper.isReceivedReceipt = false;
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_Close_Click");
            }

        }
        #endregion

        #region btnNew_Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objReceiveReceiptHelper.balancesheetopen = false;////when click the new button from balancesheet to change the status of balancesheet oin july  11
                ItemIndex = -1;
                btnNext.Enabled = false;
                ClearRecords();
                objReceiveReceiptHelper.BindReceiptMaxID(out Status);
                Txt_NewYear_No.Text = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr.ToString();
                chkCash.Checked = true;//make a default option of cash 
                ChangeProperties("Cmb_ReceivedFrom");

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnNew_Click");
            }

        }
        #endregion

        #region btnSave_Click

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Added on 26-Feb-2019
                if (Sales_Invoice.PaymentTypeID == 1 && !chkCash.Checked)
                {
                    if (chkCard.Checked)
                    {
                        double PercCard = Convert.ToDouble(GeneralOptionSetting.FlagtxtPaymentPercentageCard);
                        double CurrentValue = Convert.ToDouble(MTxt_Value.Text);
                        double value = (CurrentValue * PercCard) / 100;
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentCharges = value;
                        double ActualValue = CurrentValue + value;
                        MTxt_Value.Text = ActualValue.ToString("####0.000");
                    }
                    else if (chkCheck.Checked)
                    {
                        double PercCheck = Convert.ToDouble(GeneralOptionSetting.FlagtxtPaymentPercentageCheck);
                        double CurrentValue = Convert.ToDouble(MTxt_Value.Text);
                        double value = (CurrentValue * PercCheck) / 100;
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentCharges = value;
                        double ActualValue = CurrentValue + value;
                        MTxt_Value.Text = ActualValue.ToString("####0.000");
                    }
                    BalanceCalculation();
                }
                else if (Sales_Invoice.PaymentTypeID != 1 && chkCash.Checked)
                {
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentCharges = 0;
                    double CurrentValue = Convert.ToDouble(MTxt_Value.Text);
                    double value = Sales_Invoice.PaymentChagers;
                    double ActualValue = CurrentValue - value;
                    MTxt_Value.Text = ActualValue.ToString("####0.000");
                    BalanceCalculation();
                }
                else if (Sales_Invoice.PaymentTypeID == 2 && !chkCard.Checked)
                {
                    if (chkCheck.Checked)
                    {
                        double PercCheck = Convert.ToDouble(GeneralOptionSetting.FlagtxtPaymentPercentageCheck);
                        double CurrentValue = Convert.ToDouble(MTxt_Value.Text);
                        double CardCharges= Sales_Invoice.PaymentChagers;
                        double CheckCharges = (CurrentValue * PercCheck) / 100;
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentCharges = CheckCharges;
                        double ActualValue = (CurrentValue - CardCharges) + CheckCharges;
                        MTxt_Value.Text = ActualValue.ToString("####0.000");
                    }
                    BalanceCalculation();
                }

                    //
                    SetObjectFromControl();
                if (objReceiveReceiptHelper.ValidateReceipt())
                {
                    setvalues();
                    if (POS_Screen.isPaymentMethodOn || Sales_Invoice.isPaymentMethodOn)
                    {
                        PaymentTypes.isCheckSave = true;
                        this.Close();
                    }
                }
                else
                {
                    ChangeProperties(objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString);

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnSave_Click");
            }
        }

        #endregion

        #region button_decrease_Click
        private void button_decrease_Click(object sender, EventArgs e)
        {
            try
            {
                btnNext.Enabled = true;
                if (ItemIndex == -1)
                {
                    //  ItemIndex = lstReceiveReceipt.Count - 1;  //Commented on 24-Jan-2014 
                    ItemIndex = lstReceiveReceipt.Count - 2; //Added on 24-Jan-2014 for avoiding Empty record 
                }
                else if (ItemIndex > 0)
                {
                    ItemIndex--;
                }
                if (ItemIndex > -1)//Added by meena.R to fix the n Index nagative error
                {
                    if (objReceiveReceiptHelper.balancesheetopen)
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid - 1;
                    else
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = lstReceiveReceipt[ItemIndex].receiptid;
                    objReceiveReceiptHelper.GetPrevNextRecordHelper();
                    GetRecordsAndLoad();
                }
                isFromNavigator = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "button_decrease_Click");
            }
        }
        #endregion

        #region btnNext_Click
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemIndex < lstReceiveReceipt.Count - 2)
                {
                    ItemIndex++;
                }
                if (ItemIndex > -1)////Added by meena.R to fix the n index nagative error
                {
                    if (objReceiveReceiptHelper.balancesheetopen)
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid + 1;
                    else
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = lstReceiveReceipt[ItemIndex].receiptid;
                    objReceiveReceiptHelper.GetPrevNextRecordHelper();
                    GetRecordsAndLoad();
                }
                isFromNavigator = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnNext_Click");
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.Question("AlertDeleteReceipt", "ReceiveReceipt") == DialogResult.Yes)
                {
                    if (objReceiveReceiptHelper.balancesheetopen == true)
                    {
                        ItemIndex = lstReceiveReceipt.FindIndex(a => a.receiptid == objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid);
                    }
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = lstReceiveReceipt[ItemIndex].receiptid;


                    if (objReceiveReceiptHelper.DeleteReceiptDetailsHelper())
                    {
                        lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Delete");
                        //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        lblStatus.ForeColor = Color.Red;
                        GeneralFunction.Information("DeletePayReceipt", "ReceiveReceipt");
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid.ToString(), "RECEIPT", "Delete receive receipt details", Convert.ToInt32(InvoiceAction.No));
                        btnDelete.Enabled = false;
                        // FillPayReceipt();
                    }
                    else
                    {
                        GeneralFunction.Information("FailedDeleteReceiveReceipt", "ReceiveReceipt");
                    }

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnDelete_Click");
            }


        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStatus.Text != GeneralFunction.ChangeLanguageforCustomMsg("New"))
                {
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.AgentName = Cmb_ReceivedFrom.Text != string.Empty ? Cmb_ReceivedFrom.Text.ToString() : string.Empty;
                    //Cmb_ReceivedFrom.SelectedText!=string.Empty? Cmb_ReceivedFrom.SelectedText.ToString():string.Empty;
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = MTxt_Value.Text != string.Empty ? Convert.ToDecimal(MTxt_Value.Text) : Convert.ToDecimal(0.000);
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = MTxt_Discription.Text;
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = MTxt_Balance.Text != string.Empty ? Convert.ToDecimal(MTxt_Balance.Text) : Convert.ToDecimal(0.000);
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = Txt_Reason.Text;
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = Convert.ToInt32(Txt_NewYear_No.Text);
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PrintPreviewChecked = chkPrintPreview.Checked;
                    if (ReceivedFrom != string.Empty && Description != string.Empty && (!isFromNavigator) && (Description != Additional_Barcode.GetValueByResourceKey("DepositPayment")))
                        objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = int.Parse(Regex.Match(Description, @"\d+").ToString());
                    objReceiveReceiptHelper.PrintReceipt();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "ReceiveReceipt", "RECEIPT", "Print receive receipt details", Convert.ToInt32(InvoiceAction.No));
                }
                else
                {
                    GeneralFunction.Information("NotSaveReceipt", "ReceiveReceipt");
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "ReceiveReceipt", "btnPrint_Click");
            }
        }
        #endregion

        #endregion

        #region"Key Press Events"

        private void MTxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else if (GeneralFunction.NumericOnly(e) == true)
                {
                    e.Handled = true;
                }
                else
                {
                    if ((MTxt_Value.Text.Contains(".")) && (e.KeyChar == 46)) { e.Handled = true; }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "MTxt_Value_KeyPress");
            }
        }

        private void Txt_Discription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Discription_KeyPress");
            }
        }

        //private void chkCash_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (chkCash.Checked && e.KeyChar == 13)
        //        {
        //            this.InvokeOnClick(btnSave, EventArgs.Empty);
        //        }
        //        else if (e.KeyChar == 13)
        //        {
        //            SendKeys.Send("{TAB}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCash_KeyPress");
        //    }
        //}

        //private void chkCheck_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        if (chkCheck.Checked && e.KeyChar == 13)
        //        {
        //            SendKeys.Send("{TAB}");
        //        }
        //        else if (e.KeyChar == 13)
        //        {
        //            this.InvokeOnClick(btnSave, EventArgs.Empty);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCheck_KeyPress");
        //    }
        //}

        private void Receiptno_keypress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "ReceiveReceipt");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Receiptno_keypress");
            }
        }

        #region Txt_NewYear_No_KeyPress
        private void Txt_NewYear_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    GetSearchedRecords();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_NewYear_No_KeyPress");
            }

        }
        #endregion

        //private void Txt_Reason_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {

        //        if (e.KeyChar == 13)
        //        {
        //            chkCash.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Reason_KeyPress");
        //    }
        //}

        #endregion

        #region"Key Up Events"

        //private void cmb_bank_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (boolbank && e.KeyData == Keys.Enter)
        //        {
        //            boolbank = false;
        //            SendKeys.Send("{TAB}");
        //        }
        //        else if (e.KeyData == Keys.Enter)
        //        {
        //            boolbank = true;
        //            cmb_bank.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmb_bank_KeyUp");
        //    }
        //}

        //private void cmb_branch_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyData == Keys.Enter)
        //        {
        //            this.InvokeOnClick(btnSave, EventArgs.Empty);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmb_branch_KeyUp");
        //    }
        //}

        private void Cmb_ReceivedFrom_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void MTxt_Value_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData != Keys.F8)///include this condition to avoid the double time balance calcuation while open the receive receipt  from sales  
                {
                    BalanceCalculation();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Recive_recipt", "Txt_Value_KeyPress");
            }
        }

        private void BalanceCalculation()
        {
            if (Cmb_ReceivedFrom.Text != string.Empty && MTxt_Value.Text != ".")
            {
                // MTxt_Balance.Text = Convert.ToDecimal(Convert.ToDecimal(BalanceAmt) - Convert.ToDecimal((MTxt_Value.Text != string.Empty) ? Convert.ToDecimal(MTxt_Value.Text) : Convert.ToDecimal("0.000"))).ToString("####0.000");
                decimal value = MTxt_Value.Text == String.Empty ? 0 : Convert.ToDecimal(MTxt_Value.Text);
                if (Convert.ToDecimal(BalanceAmt) != -value)
                {
                    MTxt_Balance.Text = Convert.ToDecimal(Convert.ToDecimal(BalanceAmt) - Convert.ToDecimal((MTxt_Value.Text != string.Empty) ? -Convert.ToDecimal(MTxt_Value.Text) : Convert.ToDecimal("0.000"))).ToString("####0.000");
                    if (Convert.ToDecimal(MTxt_Balance.Text) >= 0)
                    {

                        MTxt_Balance.ForeColor = Color.Green;
                    }
                    else
                    {
                        MTxt_Balance.ForeColor = Color.Red;
                    }

                }
                else
                {
                    MTxt_Balance.Text = BalanceAmt;
                    if (Convert.ToDecimal(MTxt_Balance.Text) >= 0)
                    {

                        MTxt_Balance.ForeColor = Color.Green;
                    }
                    else
                    {
                        MTxt_Balance.ForeColor = Color.Red;
                    }
                }
            }
            if (MTxt_Value.Text == "")
            {
                MTxt_Value.Text = "0.000";
            }
        }

        #endregion

        #region"Key Down Events"

        private void Recive_Recipt_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Recive_Recipt_KeyDown");
            }
        }

        //private void MTxt_Discription_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        //if (((int)e.KeyValue == 13) && (lblStatus.Text == "New"))
        //        //{
        //        //    MTxt_Value.Text = "0.000";
        //        //    MTxt_Value.Focus();
        //        //    MTxt_Value.Select(0, MTxt_Value.Text.Length);

        //        //}
        //        //if ((e.KeyCode == Keys.Tab) && (lblStatus.Text == "New"))
        //        //{
        //        //    MTxt_Value.Text = "0.000";
        //        //    MTxt_Value.Focus();
        //        //    MTxt_Value.Select(0, MTxt_Value.Text.Length);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "MTxt_Discription_KeyDown");
        //    }
        //}

        //private void chkCash_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyData == Keys.Enter)
        //        {
        //            SendKeys.Send("{TAB}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCash_KeyDown");
        //    }
        //}

        private void chkCheck_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (chkCheck.Checked && e.KeyValue == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyValue == 13)
                {
                    this.InvokeOnClick(btnSave, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCheck_KeyPress");
            }
        }

        private void MTxt_Balance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "MTxt_Balance_KeyDown");
            }
        }

        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
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
            grbStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            lblBank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            lblBranch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            this.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceipt");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblPaymentMethod.Text = Additional_Barcode.GetValueByResourceKey("PayMethod");
            lblReceivedFrom.Text = Additional_Barcode.GetValueByResourceKey("ReceiveFrom");
            chkCash.Text = Additional_Barcode.GetValueByResourceKey("Cash");
            chkCheck.Text = Additional_Barcode.GetValueByResourceKey("Check");
            chkCard.Text = Additional_Barcode.GetValueByResourceKey("Card");
            lblValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");
        }
        #endregion

        #region FillAgent
        public void FillAgent()
        {
            Cmb_ReceivedFrom.SelectedIndexChanged -= new EventHandler(Cmb_ReceivedFrom_SelectedIndexChanged);
            Cmb_ReceivedFrom.DisplayMember = "Name";
            Cmb_ReceivedFrom.ValueMember = "AgentId";
            Cmb_ReceivedFrom.DataSource = GeneralObjectClass.AgentDetails.Where(a => (!a.AgentType.Contains("104"))).ToList();

            Cmb_ReceivedFrom.SelectedIndex = -1;
            Cmb_ReceivedFrom.SelectedIndexChanged += new EventHandler(Cmb_ReceivedFrom_SelectedIndexChanged);
        }

        #endregion

        #region FillBankAndBranch
        public void FillBankAndBranch()
        {
            if (GeneralObjectClass.BankList.Count > 0)
            {
                cmb_bank.DisplayMember = "BankName";
                cmb_bank.ValueMember = "BankNameID";
                cmb_bank.DataSource = GeneralObjectClass.BankList;
                cmb_bank.SelectedIndex = 0;
            }
            //if (GeneralObjectClass.BankList.Count == 0)
            //{
            //    DialogResult dialogResult = MessageBox.Show("There is no bank would you like to add?", "Alert", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        using (PrimaryInfo frm = new PrimaryInfo())
            //        {
            //            frm.IsReciept = "Bank";
            //            frm.ShowDialog();
            //            GeneralObjectClass.BankList = objReceiveReceiptHelper.objReceiveReceiptBAL.GetBankDetailsBal();
            //            if (GeneralObjectClass.BankList.Count == 0)
            //                FillBankAndBranch();
            //            else
            //            {
            //                cmb_bank.DataSource = GeneralObjectClass.BankList;
            //                cmb_bank.SelectedIndex = 0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        this.Close();
            //        return;
            //    }
            //}
            //else
            //{
            //    cmb_bank.DataSource = GeneralObjectClass.BankList;
            //    cmb_bank.SelectedIndex = 0;
            //}


            if (GeneralObjectClass.BranchList.Count > 0)
            {
                cmb_branch.DisplayMember = "BranchName";
                cmb_branch.ValueMember = "BranchNameID";
                cmb_branch.DataSource = GeneralObjectClass.BranchList;
                cmb_branch.SelectedIndex = 0;
            }
            //if (GeneralObjectClass.BranchList.Count == 0)
            //{
            //    DialogResult dialogResult = MessageBox.Show("There is no Branch would you like to add?", "Alert", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        using (PrimaryInfo frm = new PrimaryInfo())
            //        {
            //            frm.IsReciept = "Branch";
            //            frm.ShowDialog();
            //            GeneralObjectClass.BranchList = objReceiveReceiptHelper.objReceiveReceiptBAL.BranchDetailsBal();
            //            if (GeneralObjectClass.BranchList.Count == 0)
            //                FillBankAndBranch();
            //            else
            //            {
            //                cmb_branch.DataSource = GeneralObjectClass.BranchList;
            //                cmb_branch.SelectedIndex = 0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        this.Close();
            //        return;
            //    }
            //}
            //else
            //{
            //    cmb_branch.DataSource = GeneralObjectClass.BranchList;
            //    cmb_branch.SelectedIndex = 0;
            //}

        }
        #endregion

        #region HideControls
        void HideControls()
        {
            // btnPrint.Enabled = (UserScreenLimidations.Print == "YES") ? true : false;

        }
        #endregion

        #region LabelStatus
        private void LabelStatus()
        {
            lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
            //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStatus.ForeColor = Color.Blue;
        }
        #endregion

        #region ClearRecords
        private void ClearRecords()
        {
            btnNext.Enabled = false;
            decBalance = 0;
            txt_receipt_no.Text = "";
            Lbl_User.Text = GeneralFunction.UserName;
            Cmb_ReceivedFrom.Text = "";
            MTxt_Discription.Text = "";
            MTxt_Value.Text = "0.000";
            MTxt_Balance.Text = "0.000";
            Txt_Reason.Text = "";
            lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
            //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblStatus.ForeColor = Color.Blue;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            Txt_NewYear_No.Text = "";
            Cmb_ReceivedFrom.Text = "";
            Cmb_ReceivedFrom.SelectedIndex = -1;
            Cmb_ReceivedFrom.Enabled = chkCheck.Enabled = chkCash.Enabled = cmb_bank.Enabled = cmb_branch.Enabled = chkCard.Enabled = true;
            cmb_bank.SelectedValue = -1;
            cmb_branch.SelectedValue = -1;
            MTxt_Discription.ReadOnly = Txt_Reason.ReadOnly = MTxt_Value.ReadOnly = MTxt_Discription.ReadOnly = false;
            Txt_Reason.Enabled = true;
            Txt_Reason.BackColor = MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
            Dtp_Date.Value = DateTime.Now;
            //Set_NY_New_NO();

        }
        #endregion

        #region SetObjectFromControl
        public void SetObjectFromControl()
        {
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.ReceivedFromName = Cmb_ReceivedFrom.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = MTxt_Discription.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue = Convert.ToDecimal(MTxt_Value.Text);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CheckChecked = chkCheck.Checked;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = Convert.ToInt32(cmb_bank.SelectedValue);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = Convert.ToInt32(cmb_branch.SelectedValue);
        }
        #endregion

        #region GetInvoiceName
        private string GetInvoiceName(string strKey)
        {
            switch (strKey)
            {
                case "PurchaseInvoice":
                    return "ÝÇÊæÑÉ ãÔÊÑíÇÊ";
                case "SaleInvoice":
                    return "ÝÇÊæÑÉ ãÈíÚÇÊ";
                case "PurchaseReturnInvoice":
                    return "ÊÑÌíÚ ãÔÊÑíÇÊ ";
                case "SaleReturnInvoice":
                    return "ÊÑÌíÚ ãÈíÚÇÊ ";
                case "RentInvoice":
                    return "ÝÇÊæÑÉ ÇíÌÇÑ";
                case "PayReceipt":
                    return "ÇíÕÇá ÕÑÝ";
                case "ReceiveReceipt":
                    return "ÇíÕÇá ÞÈÖ";
                case "Receivable":
                    return "ÇáãÞÈæÖÇÊ";
                case "Payable":
                    return "ÇáãÏÝæÚÇÊ";
                case "DebtAdjustment":
                    return "ÊÚÏíá ÇÑÕÏÉ";
                case "DepositPayment":
                    return "ÏÝÚÉ Úáì ÇáÍÓÇÈ";
                case "OpeningStock":
                    return "ÈÖÇÚÉ Çæá ÇáãÏÉ";
                case "RentBack":
                    return "ÈíÇäÇÊ ÇÑÌÇÚ ÇáÇÕäÇÝ ÇáãÄÌÑÉ";
                default:
                    return strKey;
            }


        }
        #endregion

        #region setvalues
        public void setvalues()
        {
            //objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receivedfrom = Cmb_ReceivedFrom.Text.ToString();
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = (ReceiptNo != 0) ? ReceiptNo : 0;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleinv = (ReceiptNo != 0) ? ReceiptNo : 0;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = Convert.ToDecimal(MTxt_Balance.Text);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue = Convert.ToDecimal(MTxt_Value.Text);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.grossamount = Convert.ToDecimal(MTxt_Value.Text);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = Txt_Reason.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptdate = Dtp_Date.Value;
            if (chkCash.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = 101; else if (chkCheck.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = 102; else if (chkCard.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.paymethodid = 103;
            // objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receiptid = txt_receipt_no.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.receivedfrom = Convert.ToInt16(Cmb_ReceivedFrom.SelectedValue);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.username = Convert.ToString(GeneralFunction.UserId);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discription = MTxt_Discription.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.note = Txt_Reason.Text;
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.UserId = GeneralFunction.UserId;

            int saletype = objReceiveReceiptHelper.GetSaleType(this.Tag.ToString());
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saletype = saletype; // Convert.ToInt32(ReceiveReceiptFor.Receivable);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Status = 1;
            string[] descr = MTxt_Discription.Text.Split(' ');
            string desr = (descr.Length > 1) ? GetInvoiceName(descr[0].Trim()) + MTxt_Discription.Text.Substring(descr[0].Length, (MTxt_Discription.Text.Length - descr[0].Length)) : GetInvoiceName(descr[0]);
            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.discriptionarabic = desr;
            if (chkCheck.Checked == true)
            {
                if (cmb_bank.SelectedItem != null)
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = Convert.ToInt16(cmb_bank.SelectedValue);
                if (cmb_branch.SelectedItem != null)
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = Convert.ToInt16(cmb_branch.SelectedValue);

            }
            else
            {
                objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.bank = 0;
                objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.branch = 0;
            }

            if (objReceiveReceiptHelper.SaveReceiveReceiptHelper())
            {
                // Payment from Check then this code executed 06-Feb-2019
                if (chkCheck.Checked == true)
                {
                    int BankDepositMaxID = Convert.ToInt32(objReceiveReceiptHelper.GetBankDeposit_MaxID());
                    if (BankDepositMaxID == 0)
                    {
                        objReceiveReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                        objReceiveReceiptHelper.Insert_BankTransactionDetailsHelper(false);
                        objReceiveReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                    }
                    else
                    {
                        objReceiveReceiptHelper.Insert_BankTransactionDetailsHelper(false);
                        objReceiveReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                    }
                }
                //
                if (this.Tag.ToString() == "POS" || this.Tag.ToString() == "SaleInvoice")
                {
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.balance = Convert.ToDecimal(NetAmt) - objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.netvalue;
                    objReceiveReceiptHelper.UpdateSaleBalanceHelper();
                    if (chkCash.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentTypeID = 1; else if (chkCheck.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentTypeID = 3; else if (chkCard.Checked) objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.PaymentTypeID = 2;
                    objReceiveReceiptHelper.UpdateSalePaymentTypeHelper();
                    if ((Sales_Invoice.PaymentTypeID == 1 && !chkCash.Checked) || (Sales_Invoice.PaymentTypeID != 1 && chkCash.Checked) || (Sales_Invoice.PaymentTypeID == 2 && !chkCard.Checked))
                    {
                        objReceiveReceiptHelper.UpdateSalePaymentChargesHelper();
                    }
                }

                ///////////////////////////////////////////////////
                List<ReceiveReceiptObject> lstMaxIDs = objReceiveReceiptHelper.ListReceiptRecord;
                long lngCurrentPayReceiptNo = lstMaxIDs[0].MaxpayReceiptNo;
                long lngYearSequenceNo = lstMaxIDs[0].YearSequenceNo;
                int intYear = lstMaxIDs[0].Year;

                string msgvalue = (intYear + "-" + lngYearSequenceNo).ToString();
                // GeneralFunction.Information(GeneralFunction.ChangeLanguageforCustomMsg("SaveReceiveReceipt") + " " + "Your ReceiptNumber is " + msgvalue + "", this.Text);//Commented on 24-Jan-2014
                //  Txt_NewYear_No.Text = msgvalue; //Commented on 24-Jan-2014
                /////////////////////////////////////////////////////

                cmb_bank.Enabled = cmb_branch.Enabled = chkCash.Enabled = chkCheck.Enabled = Cmb_ReceivedFrom.Enabled = chkCard.Enabled = false;
                MTxt_Value.ReadOnly = txt_receipt_no.ReadOnly = Txt_NewYear_No.ReadOnly = MTxt_Discription.ReadOnly = Txt_Reason.ReadOnly = true;
                MTxt_Value.BackColor = txt_receipt_no.BackColor = Txt_NewYear_No.BackColor = MTxt_Discription.BackColor = Txt_Reason.BackColor = Color.White;

                btnSave.Enabled = false;

                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), MTxt_Discription.Text + " " + "(" + objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr.ToString() + ")", "RECEIPT", "Save receive receipt details", Convert.ToInt32(InvoiceAction.No));
                lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                btnDelete.Enabled = true;
                lblStatus.ForeColor = Color.Green;

                ItemIndex = lstReceiveReceipt.Count - 1;
                if (GeneralOptionSetting.FlagPrintAfterClosingRecipt == "Y")
                {
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.AgentName = Cmb_ReceivedFrom.Text != string.Empty ? Cmb_ReceivedFrom.Text.ToString() : string.Empty;
                    objReceiveReceiptHelper.PrintReceipt(); //include print functionality on receive receipt on 02 july 2014
                }
                //this.Close();
                objReceiveReceiptHelper.CreateEmptyRecord();
                GetAllReceiptID();
                // Txt_NewYear_No.Text = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.MaxpayReceiptNo.ToString(); //Commented on 24-Jan-2014
            }


        }
        #endregion

        #region LoadReceiptDetails
        public void LoadReceiptDetails(List<ReceiveReceiptObject> lstRecords)
        {

            if (lstRecords.Count > 0)
            {
                ///Added on 15 may 2014,to get the current year record or previous year record
                Dictionary<string, long> dicofyear = new Dictionary<string, long>();
                dicofyear.Add("Year", lstRecords[0].Year);
                dicofyear.Add("YearSequenceNo", lstRecords[0].YearSequenceNo);
                objReceiveReceiptHelper.CheckCurrentYear(dicofyear);

                //objReceiveReceiptHelper.CheckCurrentYear(lstRecords);
                //-------------------------------------------------------------------------------
                // Txt_NewYear_No.Text = lstRecords[0].Year.ToString() + "-" + lstRecords[0].YearSequenceNo.ToString();
                Txt_NewYear_No.Text = objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr;
                objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.saleid = lstRecords[0].saleid;
                Cmb_ReceivedFrom.SelectedValue = lstRecords[0].AgentID;
                MTxt_Discription.Text = lstRecords[0].discription.ToString();
                MTxt_Value.Text = Convert.ToDecimal(lstRecords[0].AmountReceived).ToString("####0.000");
                Txt_Reason.Text = lstRecords[0].note.ToString();
                MTxt_Balance.Text = Convert.ToDecimal(lstRecords[0].balance).ToString("####0.000");
                Dtp_Date.Value = (lstRecords[0].receiptdate != null) ? Convert.ToDateTime(lstRecords[0].receiptdate) : DateTime.Now;
                if (lstRecords[0].Status == 1 && !string.IsNullOrEmpty(lstRecords[0].discription.ToString()))
                {
                    lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                    //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblStatus.ForeColor = Color.Green;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = Txt_Reason.ReadOnly = MTxt_Balance.ReadOnly = true;
                    MTxt_Discription.BackColor = Txt_Reason.BackColor = MTxt_Value.BackColor = Color.White;
                    chkCash.Enabled = chkCheck.Enabled = chkCard.Enabled = false;
                }
                else if (lstRecords[0].Status == 0)
                {
                    lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblStatus.ForeColor = Color.Red;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = Txt_Reason.ReadOnly = MTxt_Balance.ReadOnly = true;
                    MTxt_Discription.BackColor = Txt_Reason.BackColor = MTxt_Value.BackColor = Color.White;
                    chkCash.Enabled = chkCheck.Enabled = chkCard.Enabled = false;
                }
                else
                {
                    lblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
                    //lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblStatus.ForeColor = Color.Blue;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = Txt_Reason.ReadOnly = MTxt_Balance.ReadOnly = false;
                    MTxt_Discription.BackColor = Txt_Reason.BackColor = MTxt_Value.BackColor = Color.White;
                    chkCash.Enabled = chkCheck.Enabled = chkCard.Enabled = true;

                }

                if (lstRecords[0].paymethodid.ToString() == "102")
                {
                    chkCheck.Checked = true;
                    chkCash.Checked = false;
                    chkCard.Checked = false;
                    cmb_bank.SelectedValue = lstRecords[0].BankSelectedVal;
                    cmb_branch.SelectedValue = lstRecords[0].BranchSelectedVal;
                }
                else if (lstRecords[0].paymethodid.ToString() == "103")
                {
                    chkCash.Checked = false;
                    chkCheck.Checked = false;
                    chkCard.Checked = true;
                }
                else
                {
                    chkCash.Checked = true;
                    chkCheck.Checked = false;
                    chkCard.Checked = false;
                }
                Cmb_ReceivedFrom.SelectedIndexChanged -= new EventHandler(Cmb_ReceivedFrom_SelectedIndexChanged);
                // Cmb_ReceivedFrom.Text = lstRecords[0].AgentName.ToString();
                Cmb_ReceivedFrom.SelectedIndexChanged += new EventHandler(Cmb_ReceivedFrom_SelectedIndexChanged);
                if (!btnSave.Enabled)
                {
                    Cmb_ReceivedFrom.Enabled = Txt_Reason.Enabled = false;
                    Txt_Reason.BackColor = Cmb_ReceivedFrom.BackColor = Color.White;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = true;
                    chkCash.Enabled = chkCheck.Enabled = false;
                    MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                }
                else
                {
                    Cmb_ReceivedFrom.Enabled = Txt_Reason.Enabled = true;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = false;
                    chkCash.Enabled = chkCheck.Enabled = true;
                    MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                }
            }
            else
            {
                lblStatus.ForeColor = Color.Blue;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = Txt_Reason.ReadOnly = MTxt_Balance.ReadOnly = false;
                MTxt_Discription.BackColor = Txt_Reason.BackColor = MTxt_Value.BackColor = Color.White;
                chkCash.Enabled = chkCheck.Enabled = true;
            }


        }

        #endregion

        #region GetRecordsAndLoad
        private void GetRecordsAndLoad()
        {

            List<ReceiveReceiptObject> lstRecord = objReceiveReceiptHelper.ListReceiptRecord;
            LoadReceiptDetails(lstRecord);


        }

        #endregion

        #region GetAllReceiptID
        private void GetAllReceiptID()
        {

            objReceiveReceiptHelper.GetAllReceiptIdHelper();
            lstReceiveReceipt = objReceiveReceiptHelper.ListReceiptRecord;


        }
        #endregion

        #region GetSearchedRecords

        public void GetSearchedRecords()
        {
            if (Txt_NewYear_No.Text != string.Empty)
            {
                if ((Txt_NewYear_No.Text).Contains('-'))
                {
                    string[] NewYearNo = Txt_NewYear_No.Text.Split('-');
                    if (NewYearNo.Length == 2)
                    {
                        if (NewYearNo[1].ToString() != string.Empty)
                        {
                            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Year = Convert.ToInt32(NewYearNo[0]);
                            objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.YearSequenceNo = Convert.ToInt32(NewYearNo[1]);

                            if (NewYearNo[0].Length != 0 && NewYearNo[1].Length != 0)
                            {
                                if (objReceiveReceiptHelper.GetSearchedRecordHelper())
                                {
                                    int index = lstReceiveReceipt.FindIndex(x => x.receiptid == Convert.ToInt64(NewYearNo[1]));
                                    ItemIndex = index;
                                    GetRecordsAndLoad();
                                }
                            }
                            else
                            {
                                //GeneralFunction.Information("Enter valid Receipt Id", this.Text);
                                //  ClearRecords();
                            }
                        }
                    }
                }
                else
                {
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.Year = objReceiveReceiptHelper.CurrentYear;
                    objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.YearSequenceNo = Convert.ToInt32((Txt_NewYear_No.Text));
                    if (objReceiveReceiptHelper.GetSearchedRecordHelper())
                    {
                        int index = lstReceiveReceipt.FindIndex(x => x.receiptid == Convert.ToInt64(objReceiveReceiptHelper.objReceiveReceiptBAL.objReceiveReceiptObject.YearSequenceNo));
                        ItemIndex = index;
                        GetRecordsAndLoad();
                    }
                }

            }
            else
            {
                //  GeneralFunction.Information("Enter valid Receipt Id", this.Text);
                //ClearRecords();
            }
        }

        private void Receive_Receipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReceiveReceiptHelper.isReceivedReceipt = false;
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCard.Checked == true)
                {
                    chkCheck.Checked = false;
                    chkCash.Checked = false;
                    cmb_bank.Visible = false;
                    cmb_branch.Visible = false;
                    lblBank.Visible = false;
                    lblBranch.Visible = false;
                }
                else if (chkCheck.Checked != true && chkCash.Checked != true)
                {
                    chkCash.Checked = true;
                    chkCash.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCard_CheckedChanged");
            }
        }

        private void Lbl_User_Click(object sender, EventArgs e)
        {

        }



        #endregion

        #region ChangeProperties
        public static void ChangeProperties(Control ctrl)
        {
            ctrl.Select();
            ctrl.Focus();

        }
        #endregion

        #region SetFont
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
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is Button || ctl is Label || ctl is GroupBox || ctl is CheckBox || ctl is RadioButton)
                            ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                    foreach (Control btn in groupBox2.Controls)
                    {
                        if (btn is Button || btn is Label || btn is GroupBox || btn is CheckBox)
                            btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                }

            }
        }

        #endregion

        private void Cmb_ReceivedFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (boolRecivedFrom && e.KeyData == Keys.Enter)
                {
                    boolRecivedFrom = false;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyData == Keys.Enter)
                {
                    boolRecivedFrom = true;
                    Cmb_ReceivedFrom.Focus();
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

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmb_branch_KeyUp");
            }
        }


        #endregion

        private void MTxt_Discription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Discription_KeyPress");
            }
        }

        private void chkCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (chkCash.Checked && e.KeyValue == 13)
                {
                    this.InvokeOnClick(btnSave, EventArgs.Empty);
                }
                else if (e.KeyValue == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkCash_KeyPress");
            }
        }

        private void cmb_bank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (boolbank && e.KeyData == Keys.Enter)
                {
                    boolbank = false;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyData == Keys.Enter)
                {
                    boolbank = true;
                    cmb_bank.Focus();
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

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmb_bank_KeyUp");
            }
        }

        private void cmb_branch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.InvokeOnClick(btnSave, EventArgs.Empty);
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

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmb_branch_KeyUp");
            }
        }
        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }

    }
}
