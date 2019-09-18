using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ViewHelper;
using HSB_ObjectHelper;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Pay_Receipt : Form, IDisposable
    {
        #region Variable Declaration
        public PayReceiptHelper objPayReceiptHelper;
        public decimal decBalance, decAmt, decRec, decTotal;
        public string strPayTo, strDiscription, strValue, strDiscriptionArabic;
        public long strFromInvoice, strFromInvoiceID;
        public DateTime dtPaymentDate;
        public string strReceiptNo, strBalance;
        List<PayReceiptObject> lstPayReceipt;
        public long lngCurrentPayReceiptNo = 0, lngYearSequenceNo = 0;
        public int intYear = 0, strFlag, strPayTo1;
        public int ItemIndex = -1;
        string Status;
        //Pay_Receipt frmPayRec;
        // public  Boolean IsPurchaseFormLoad = false;

        #endregion

        #region Constructor
        public Pay_Receipt()
        {
            InitializeComponent();
            objPayReceiptHelper = new PayReceiptHelper();
            lstPayReceipt = new List<PayReceiptObject>();
            SetLanguage();
            setfont();
        }
        #endregion

        #region Events

        #region FormLoad
        private void Pay_Receipt_Load(object sender, EventArgs e)
        {

            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                Dtp_Date.Format = DateTimePickerFormat.Custom;
                Dtp_Date.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                if (objPayReceiptHelper.balancesheetopen == true) {
                    if (frmBalanceSheet.IsNewYear)
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = Convert.ToInt32(strReceiptNo);
                       
                    }
                    else
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = Convert.ToInt32(frmBalanceSheet.BalanceSheetPurchaseID); //Convert.ToInt32(strReceiptNo);
                    }
                }
                // if (objPayReceiptHelper.BindMaxId() != string.Empty) // Include this condition by manoj and commentd by surya

                Status = objPayReceiptHelper.BindMaxId(); //***************************Surya Done
                MTxt_InvoiceNo.Text = objPayReceiptHelper.objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo.ToString();////this line added by Meena.R to fix print function issue on 30062014
                FillAgent();
                GetAllPaymentID();
                // objPayReceiptHelper.GetCurrentYear();
                Btn_Next.Enabled = false;
                Lbl_User.Text = GeneralFunction.UserName;
                // LblStatus.Text = "New";//Commented on 24-jan-2014
                LblStatus.Text = Status;//Added on 24-jan-2014 to get last empty new record status
                                        // LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LblStatus.ForeColor = Color.Blue;

                chkCash.Checked = true;

                FillBankAndBranch();

                //////
                if (strPayTo != null && strDiscription != null && strValue != null)
                {
                    //Cmb_PayTo.SelectedText = strPayTo;
                    //Cmb_PayTo.SelectedValue = strPayTo1;
                    Cmb_PayTo.Text = strPayTo;

                    Cmb_PayTo.Enabled = false;
                    MTxt_Discription.Text = strDiscription;
                    MTxt_Value.Text = strValue != string.Empty ? Convert.ToDecimal(strValue).ToString("#######0.000") : "0.000";
                    //////////// MTxt_Balance.Text = strValue != string.Empty ? (Convert.ToDecimal(strValue)*-1).ToString("#######0.000") : "0.000";
                    ////////// MTxt_Balance.Text = strValue != string.Empty ? (Convert.ToDecimal(strValue) ).ToString("#######0.000") : "0.000";
                    //////////// MTxt_Balance.ForeColor = ((decBalance * -1) < 0) ? Color.Red : Color.Green;
                    ////////// MTxt_Balance.ForeColor = ((decBalance) < 0) ? Color.Red : Color.Green;
                    if (Convert.ToDecimal(MTxt_Balance.Text == string.Empty ? "0" : MTxt_Balance.Text) >= decBalance) { MTxt_Balance.ForeColor = Color.Green; }
                    else { MTxt_Balance.ForeColor = Color.Red; }
                    //MTxt_InvoiceNo.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo.ToString();
                    //MTxt_Value.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.AmountPaid.ToString();
                    //MTxt_Balance.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceAmount.ToString();
                    //MTxt_Discription.Text=objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscription.ToString();
                    // chkCash.check
                    //    objPayReceiptBALClass.objPayReceiptObject.PayReason
                    if (objPayReceiptHelper.balancesheetopen)
                        LoadPayReceipt(objPayReceiptHelper.lstPayFromBalance);
                }
                else
                {

                    MTxt_Discription.Text = "";
                    MTxt_Value.Text = "0.000";
                    MTxt_Balance.Text = "0.000";
                }

                ////////
                ///Need to Add this code ////  btnPrint.Enabled = UserScreenLimidations.Print == "YES" ? true : false;

                ///////  Cmb_PayTo_SelectedIndexChanged(sender, new EventArgs() );// Hidden for the issues as Balance amount shows 0.000 when come from purchase invoice
                if (LblStatus.Text == GeneralFunction.ChangeLanguageforCustomMsg("New"))
                {
                    btnDelete.Enabled = false;
                }


                //---------In purchase invoice to poen the payreceipt didnt show the balance amount 
                //MTxt_Balance.ForeColor = Color.Red;
                //if (MTxt_Value.Text != string.Empty)
                //{

                //    SendKeys.Send("{ENTER}");
                //}
                //------------------------------------------
                //  MTxt_Discription.Focus();
                //    MTxt_Value.Focus();

                //   MTxt_Value.SelectAll();
                //  MTxt_Value.Focus(;
                // Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo.ToString();//commented on 24-Jan-2014

                //Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.CurrentYearStr == null ? "1" : objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.CurrentYearStr.ToString();
                Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.CurrentYearStr.ToString();
                //MTxt_Discription_KeyPress(sender,new KeyPressEventArgs());

                SetFocusToControls();
            }

            catch (Exception)
            {
                throw;
            }

        }

        private void SetFocusToControls()
        {
            if (this.Tag == "PurchaseInvoice")
            {
                ChangeProperties("MTxt_Value");
                MTxt_Value.SelectAll();//Commended  by Meena.R on 27Oct2014
            }
            //else if (this.Tag == "BalanceSheet")
            //{
            //    ChangeProperties("MTxt_Discription");
            //}
            else if (this.Tag == "Pay Receipt")
            {
                ChangeProperties("Cmb_PayTo");

            }
            else
            {
                ChangeProperties("MTxt_Value");
                MTxt_Value.SelectAll();
            }
        }
        #endregion

        #region Cmb_PayTo_SelectedIndexChanged
        private void Cmb_PayTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PayReceiptObject> lstBalance;
            try
            {

                if (Cmb_PayTo.Text != "" && Cmb_PayTo.Text != "System.Data.DataRowView")
                {
                    MTxt_Balance.Text = "0.000";
                    decBalance = 0; decAmt = 0; decRec = 0; decTotal = 0;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceAgent = Cmb_PayTo.SelectedValue.ToString();
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceFromDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceToDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BalanceStatus = "1";
                    objPayReceiptHelper.GetBalanceHelper();
                    lstBalance = objPayReceiptHelper.lstBalance;
                    if (lstBalance.Count > 0)
                    {
                        for (int i = 0; i < lstBalance.Count; i++)
                        {
                            //decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["MTB_NET_AMT"]);
                            //decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["MTB_AMT_RECEIVED"]);
                            if (lstBalance[i].AmountRecieved == 0)
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

                }
                //PurchaseInvoiceHelper.UnderPurchaseInvoice = false ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstBalance = null;
            }
        }
        #endregion

        #region"CheckBox Checked Changed"

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            //lblBank.Visible = chkCheck.Checked;
            //lblBranch.Visible = chkCheck.Checked;
            //Cmb_Bank.Visible = chkCheck.Checked;
            //Cmb_Branch.Visible = chkCheck.Checked;
            //chkCash.Checked = !chkCheck.Checked;
            //Cmb_Bank.Focus();
            try
            {
                if (chkCheck.Checked == true)
                {
                    chkCash.Checked = false;
                    chkCard.Checked = false;
                    Cmb_Bank.Visible = true;
                    Cmb_Branch.Visible = true;
                    lblBank.Visible = true;
                    lblBranch.Visible = true;
                    Cmb_Bank.Focus();
                }
                else if (chkCard.Checked != true && chkCash.Checked != true)
                {
                    chkCash.Checked = true;
                    chkCash.Focus();
                    Cmb_Bank.Visible = false;
                    Cmb_Branch.Visible = false;
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

        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            //lblBank.Visible = !chkCash.Checked;
            //lblBranch.Visible = !chkCash.Checked;
            //Cmb_Bank.Visible = !chkCash.Checked;
            //Cmb_Branch.Visible = !chkCash.Checked;
            //chkCheck.Checked = !chkCash.Checked;
            try
            {
                if (chkCash.Checked == true)
                {
                    chkCheck.Checked = false;
                    chkCard.Checked = false;
                    Cmb_Bank.Visible = false;
                    Cmb_Branch.Visible = false;
                    lblBank.Visible = false;
                    lblBranch.Visible = false;
                }
                else if (chkCard.Checked != true && chkCheck.Checked != true)
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

        #endregion

        #region "Key Press Events"

        //private void MTxt_Discription_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        //if (e.KeyChar == 13) commented on 12 jun 2014
        //        //{
        //        //    MTxt_Value.Focus();
        //        //    MTxt_Value.SelectAll();
        //        //}

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "MTxt_Discription_KeyPress");
        //    }
        //}

        private void MTxt_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {

                    Cmb_Reason.SelectAll();
                    Cmb_Reason.Focus();
                }
                else
                {
                    if (MTxt_Value.Text.Length < 8)
                    {
                        if ((MTxt_Value.Text.Length == 0) && (e.KeyChar == 46))
                        {
                            e.Handled = true;

                        }
                        else if (e.KeyChar > 57 || e.KeyChar < 48 & e.KeyChar != 13 & e.KeyChar != 8 & e.KeyChar != 46)
                        {
                            e.Handled = true;
                        }
                        else if (e.KeyChar > 57 || e.KeyChar < 48 & e.KeyChar != 13 & e.KeyChar != 8 & (e.KeyChar == 46) && (MTxt_Value.Text.Contains(".")))
                        {
                            e.Handled = true;
                        }
                        else
                        {

                            e.Handled = false;
                        }
                    }
                    else
                    {
                        if (e.KeyChar == 8) e.Handled = false;
                        else e.Handled = true;
                    }

                }

                //MTxt_Value.Text = (MTxt_Value.Text == "0.000") ? "" : MTxt_Value.Text;
                // e.Handled = GeneralFunction.IsPrice(sender, e.KeyChar);
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "MTxt_Value_KeyPress");
            }
        }



        private void MTxt_InvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    GetSearchedRecords();
                    MTxt_InvoiceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "MTxt_InvoiceNo_KeyPress");
            }
        }

        private void Mtxt_Description_Arabic_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    MTxt_Value.Focus();
                    MTxt_Value.SelectAll();
                }
                else
                {
                    MTxt_Discription.Text = MTxt_Discription.Text;
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "MTxt_Discription_KeyPress");
            }
        }

        #endregion

        #region "Key Down Events"

        private void Pay_recipt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                    pric = null;
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Pay_recipt_KeyDown");
            }
        }

        private void Cmb_Branch_KeyDown(object sender, KeyEventArgs e)
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
                        if (sender is ComboBox)
                        {
                            if (((ComboBox)sender).DataSource != null)
                            {
                                if (((ComboBox)sender).DroppedDown == true)
                                    ((ComboBox)sender).DroppedDown = false;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_Branch_KeyDown");
            }
        }


        private void MTxt_Balance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        #region chkCheck_KeyDown

        #endregion

        #region chkCash_KeyDown

        #endregion

        #region MTxt_Balance_KeyDown_1
        private void MTxt_Balance_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #endregion

        #region "Key Up Events"

        public void MTxt_Value_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyValue != 13 && e.KeyData!=Keys.Enter)

                // MTxt_Balance.Text = (Convert.ToDecimal(Convert.ToDecimal(decBalance) - Convert.ToDecimal((MTxt_Value.Text != string.Empty) ? Convert.ToDecimal(MTxt_Value.Text) : Convert.ToDecimal("0.000"))) * (-1)).ToString("####0.000");
                if (e.KeyData != Keys.F8)//when press the key f8 ,amount can be calculated double time  on 25 jun 2014
                {
                    BalanceCalaculation(); ////include the method on 15 may 2014
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "MTxt_Value_KeyUp");
            }
        }

        private void BalanceCalaculation()
        {
            decimal value = MTxt_Value.Text == String.Empty ? 0 : Convert.ToDecimal(MTxt_Value.Text);
            if (Convert.ToDecimal(decBalance) != -value)
            {
                MTxt_Balance.Text = (Convert.ToDecimal(Convert.ToDecimal(decBalance) - Convert.ToDecimal((MTxt_Value.Text != string.Empty) ? -Convert.ToDecimal(MTxt_Value.Text) : -Convert.ToDecimal("0.000"))) * (-1)).ToString("####0.000");
                if (Convert.ToDecimal(MTxt_Balance.Text) >= 0) { MTxt_Balance.ForeColor = Color.Green; }
                else { MTxt_Balance.ForeColor = Color.Red; }
            }
            else
            {
                MTxt_Balance.Text = decBalance.ToString("############.000").Replace("-", "");
                if (Convert.ToDecimal(MTxt_Balance.Text) >= 0) { MTxt_Balance.ForeColor = Color.Green; }
                else { MTxt_Balance.ForeColor = Color.Red; }
            }
        }



        #endregion

        #region Text Events
        //  private void Txt_NewYear_No_KeyUp(object sender, KeyEventArgs e)
        //{
        //    // MTxt_InvoiceNo.Text = ((Txt_NewYear_No.Text != string.Empty) && (Txt_NewYear_No.Text.Contains("-") == false)) ? Txt_NewYear_No.Text : MTxt_InvoiceNo.Text;
        //    // MTxt_InvoiceNo.Text = (MTxt_InvoiceNo.Text == string.Empty) ? "1" : MTxt_InvoiceNo.Text;
        //    //  GetSearchedRecords();
        //}


        //private void Txt_NewYear_No_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
        //}

        //private void MTxt_Value_Leave(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (MTxt_Value.Text.Length > 0)
        //    //    {
        //    //        MTxt_Value.Text = Convert.ToDecimal(MTxt_Value.Text).ToString("#######0.000");
        //    //        MTxt_Balance.Text = Convert.ToDecimal(Convert.ToDecimal(MTxt_Balance.Text) + Convert.ToDecimal(MTxt_Value.Text)).ToString("########0.000");
        //    //    }
        //    //    else
        //    //        MTxt_Value.Text = "0.000";
        //    //    //MTxt_Balance.Text = (Convert.ToDecimal(MTxt_Balance.Text) - Convert.ToDecimal(MTxt_Value.Text)).ToString("#######0.000");                
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MTxt_Value.Focus();
        //    //    GeneralFunction.Information("Enter the valid amount", this.Text);
        //    //    // GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserName, "Pay Receipt", "MTxt_Value_Leave");
        //    //}
        //}

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
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        #endregion

        #region Button Click Events

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_Close_Click");
            }

        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                if (objPayReceiptHelper.ValidateReceipt() == true)
                {

                    if (LblStatus.Text != GeneralFunction.ChangeLanguageforCustomMsg("New"))
                    {
                        GeneralFunction.Information("AlreadyReceiptSaved", "PayReceipt");
                        return;
                    }
                    //  objPayReceipt.PayReceiptNo = MTxt_InvoiceNo.Text;
                    if (chkCash.Checked)
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayMethod = "101";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBank = "0";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBranch = "0";
                    }
                    else if (chkCard.Checked)
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayMethod = "103";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBank = "0";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBranch = "0";
                    }
                    else
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayMethod = "102";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBank = Cmb_Bank.SelectedValue.ToString();
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBranch = Cmb_Branch.SelectedValue.ToString();
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BankID = Convert.ToInt32(Cmb_Bank.SelectedValue);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BranchID = Convert.ToInt32(Cmb_Branch.SelectedValue);//this lines are by Meena.R to save the Bank and Branch on 11/04/2014
                    }
                    if (strPayTo1 != 0 && strFromInvoice != 0 && strFromInvoiceID != 0 && dtPaymentDate.ToString() != "")
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayTo = strPayTo1;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayInvoiceID = strFromInvoiceID;
                        //  objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayInvoiceNo = strFromInvoice; // Commented On 24-Jan-2014
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayInvoiceNo = strFromInvoiceID;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayPaymentDate = dtPaymentDate;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayGross = Convert.ToDecimal(strValue);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscription = strDiscription;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic = strDiscriptionArabic;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayFlag = strFlag;
                        //  objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayFlag = Convert.ToInt16(PayReceiptFor.Receipt);
                    }
                    else
                    {
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayTo = Convert.ToInt16(Cmb_PayTo.SelectedValue);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayInvoiceID = 0;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayInvoiceNo = 0;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayPaymentDate = DateTime.Now;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayGross = Convert.ToDecimal(MTxt_Value.Text);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscription = MTxt_Discription.Text.ToString();
                        //string[] SplitedDesc = MTxt_Discription.Text.ToString().Split(' ');
                        //  string Description = GeneralFunction.ChangeLanguageforCustomMsg(SplitedDesc[0]);
                        //  if (SplitedDesc.Length > 1) { Description += " " + MTxt_Discription.Text.Substring(SplitedDesc[0].Length, (MTxt_Discription.Text.Length - SplitedDesc[0].Length)); }

                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic = "";
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayFlag = Convert.ToInt16(PayReceiptFor.Receipt);
                    }
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayBalance = Convert.ToDecimal(MTxt_Balance.Text);
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayCreatedBy = GeneralFunction.UserId;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayCreateDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayModifiedBy = GeneralFunction.UserId;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayModifiedDate = DateTime.Now;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayStatus = 1;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReason = Cmb_Reason.Text.ToString();

                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayUserId = GeneralFunction.UserId;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayValue = Convert.ToDecimal(MTxt_Value.Text);
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDate = Dtp_Date.Value;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayRemarks = "Save";
                    string[] description = MTxt_Discription.Text.Split(' ');
                    //  objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic = (objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic == "") ? GeneralFunction.ChangeLanguageforCustomMsg(description[0]) + " " + MTxt_Discription.Text.Substring(description[0].Length, (MTxt_Discription.Text.Length - description[0].Length)) : objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic;
                    objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscriptionArabic = string.Empty;
                    if (objPayReceiptHelper.SavePayReceiptHelper())
                    {
                        // Payment from Check then this code executed 06-Feb-2019
                        if (chkCheck.Checked == true)
                        {
                            int BankDepositMaxID = Convert.ToInt32(objPayReceiptHelper.GetBankDeposit_MaxID());
                            if (BankDepositMaxID == 0)
                            {
                                objPayReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                                objPayReceiptHelper.Insert_BankTransactionDetailsHelper(false);
                                objPayReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                            }
                            else
                            {
                                objPayReceiptHelper.Insert_BankTransactionDetailsHelper(false);
                                objPayReceiptHelper.Insert_BankTransactionDetailsHelper(true);
                            }
                        }
                        //
                        GeneralFunction.Information("SavePayReceipt", "PayReceipt");
                        LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                        //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        LblStatus.ForeColor = Color.Green;
                        //  GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, MTxt_Discription.Text + " " + "(" + objPayReceipt.PayReceiptNo.ToString() + ")", "MTB_PAYMENT", "Save pay receipt details");
                        List<PayReceiptObject> lstMaxIDs = objPayReceiptHelper.lstBalance;
                        if (lstMaxIDs.Count > 0)
                        {
                            lngCurrentPayReceiptNo = lstMaxIDs[0].MaxpayReceiptNo;
                            lngYearSequenceNo = lstMaxIDs[0].YearSequenceNo;
                            intYear = lstMaxIDs[0].Year;
                        }
                        // string msgvalue = (intYear + "-" + lngYearSequenceNo).ToString();
                        string msgvalue = (lngYearSequenceNo).ToString();
                        // GeneralFunction.Information(GeneralFunction.ChangeLanguageforCustomMsg("SavePayReceipt") + " " + "Your ReceiptNumber is " + msgvalue + "", this.Text); // Commented on 24-Jan-14 
                        // Txt_NewYear_No.Text = msgvalue;  //Commented on 24-Jan-14  
                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        chkCash.Enabled = chkCheck.Enabled = chkCard.Enabled = Cmb_Bank.Enabled = Cmb_Branch.Enabled = Cmb_PayTo.Enabled = false;
                        Cmb_Bank.BackColor = Cmb_Branch.BackColor = Cmb_PayTo.BackColor = Color.White;
                        Cmb_Reason.ReadOnly = MTxt_Balance.ReadOnly = MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = true;
                        Cmb_Reason.BackColor = MTxt_Balance.BackColor = MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                        ItemIndex = lstPayReceipt.Count - 1;
                        if (GeneralOptionSetting.FlagPrintAfterClosingRecipt == "Y")
                        {
                            objPayReceiptHelper.PrintReceipt();
                        }
                        // FillPayReceipt();
                        //this.Close();
                        objPayReceiptHelper.CreateEmptyRecord();
                        GetAllPaymentID();
                        // Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo.ToString();//Commented on 24-Jan-14 for not showing Created Empty record Paymet ID
                    }

                }
                else
                {
                    ChangeProperties(objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.ValidationString);

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "Btn_Save_Click");
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.Question("AlertDeleteReceipt", "PayReceipt") == DialogResult.Yes)
                {
                    SetObjectFromControl();
                    if (objPayReceiptHelper.ValidateReceipt() == true)
                    {
                        if (objPayReceiptHelper.balancesheetopen == true)
                        {
                            ItemIndex = lstPayReceipt.FindIndex(a => a.PayReceiptNo == objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo);
                        }
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = lstPayReceipt[ItemIndex].PayReceiptNo;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayTo = Convert.ToInt16(Cmb_PayTo.SelectedValue);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscription = MTxt_Discription.Text;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayValue = Convert.ToDecimal(MTxt_Value.Text);
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReason = Cmb_Reason.Text.ToString();
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayModifiedBy = GeneralFunction.UserId;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayModifiedDate = DateTime.Now;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayStatus = 0;
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayRemarks = "Delete";

                        if (objPayReceiptHelper.DeleteyReceiptHelper())
                        {
                            LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                            //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            LblStatus.ForeColor = Color.Red;
                            GeneralFunction.Information("DeletePayReceipt", "PayReceipt");
                            //   GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Delete, "PayReceipt", "MTB_PAYMENT", "Delete pay receipt details");
                            btnDelete.Enabled = false;
                            // FillPayReceipt();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "btnDelete_Click");
            }
        }
        #endregion

        #region Btn_Previous_Click
        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            try
            {

                Btn_Next.Enabled = true;
                if (ItemIndex == -1)
                {
                    //   ItemIndex = lstPayReceipt.Count - 1; //Commented on 24-Jan-2014 
                    ItemIndex = lstPayReceipt.Count - 2; //Added on 24-Jan-2014 for avoiding Empty record 
                }
                else if (ItemIndex > 0)
                {
                    ItemIndex--;
                }
                if (ItemIndex >= 0)//Added by meena.R to fix the n index nagative error
                {
                    if (objPayReceiptHelper.balancesheetopen)
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo - 1;
                    else
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = lstPayReceipt[ItemIndex].PayReceiptNo;
                    objPayReceiptHelper.GetPayRecordHelper();
                    GetRecordsAndLoad();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "Btn_Previous_Click");
            }


        }
        #endregion

        #region btnNew_Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                objPayReceiptHelper.balancesheetopen = false;////when click the new button from balancesheet to change the status of balancesheet oin july  11
                ItemIndex = -1;
                Btn_Next.Enabled = false;
                ClearRecords();
                Status = objPayReceiptHelper.BindMaxId();
                Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBALClass.objPayReceiptObject.CurrentYearStr.ToString();
                chkCash.Checked = true;//make a default option of cash 
                ChangeProperties("Cmb_PayTo");
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "btnNew_Click");
            }
        }
        #endregion

        #region Btn_Next_Click
        private void Btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemIndex < lstPayReceipt.Count - 2)
                {
                    ItemIndex++;
                }
                if (ItemIndex > -1)//Added by meena.R to fix the n index nagative error
                {
                    if (objPayReceiptHelper.balancesheetopen)
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo + 1;
                    else
                        objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = lstPayReceipt[ItemIndex].PayReceiptNo;
                    objPayReceiptHelper.GetPayRecordHelper();
                    GetRecordsAndLoad();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "Btn_Next_Click");
            }


        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = MTxt_InvoiceNo.Text == string.Empty ? 0 : Convert.ToInt64(MTxt_InvoiceNo.Text);
                objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PrintPreviewChecked = chkPrintPreview.Checked;
                objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayReason = Cmb_Reason.Text;
                objPayReceiptHelper.PrintReceipt();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "PayReceipt", "RECEIPT", "Print pay receipt details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "btnPrint_Click");
            }
        }
        #endregion


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
            lblPaymentMethod.Text = Additional_Barcode.GetValueByResourceKey("PayMethod");
            lblPayTo.Text = Additional_Barcode.GetValueByResourceKey("PayTo");
            lblReason.Text = Additional_Barcode.GetValueByResourceKey("Reason");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            grbStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            lblReason.Text = Additional_Barcode.GetValueByResourceKey("Reason");
            chkCash.Text = Additional_Barcode.GetValueByResourceKey("Cash");
            chkCheck.Text = Additional_Barcode.GetValueByResourceKey("Check");
            chkCard.Text = Additional_Barcode.GetValueByResourceKey("Card");
            lblValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            this.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");

        }
        #endregion

        #region FillAgent
        public void FillAgent()
        {
            Cmb_PayTo.SelectedIndexChanged -= new EventHandler(Cmb_PayTo_SelectedIndexChanged);
            Cmb_PayTo.DisplayMember = "Name";
            Cmb_PayTo.ValueMember = "AgentId";
            Cmb_PayTo.DataSource = GeneralObjectClass.AgentDetails.Where(a => (!a.AgentType.Contains("104"))).ToList();
            Cmb_PayTo.SelectedIndex = -1;

            Cmb_PayTo.SelectedIndexChanged += new EventHandler(Cmb_PayTo_SelectedIndexChanged);
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCard.Checked == true)
                {
                    chkCheck.Checked = false;
                    chkCash.Checked = false;
                    Cmb_Bank.Visible = false;
                    Cmb_Branch.Visible = false;
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

        #endregion

        #region FillBankAndBranch
        public void FillBankAndBranch()
        {

            Cmb_Bank.DisplayMember = "BankName";
            Cmb_Bank.ValueMember = "BankNameID";
            Cmb_Bank.DataSource = GeneralObjectClass.BankList;

            Cmb_Bank.SelectedIndex = -1;

            Cmb_Branch.DisplayMember = "BranchName";
            Cmb_Branch.ValueMember = "BranchNameID";
            Cmb_Branch.DataSource = GeneralObjectClass.BranchList;

            Cmb_Branch.SelectedIndex = -1;

        }
        #endregion

        #region SetObjectFromControl
        public void SetObjectFromControl()
        {

            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayTo = Convert.ToInt16(Cmb_PayTo.SelectedValue);
            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayDiscription = MTxt_Discription.Text.ToString();
            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.PayValue = Convert.ToDecimal(MTxt_Value.Text);
            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.CheckChecked = chkCheck.Checked;
            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BankSelectedVal = Convert.ToInt32(Cmb_Bank.SelectedValue);
            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.BranchSelectedVal = Convert.ToInt32(Cmb_Branch.SelectedValue);
        }
        #endregion

        #region LoadPayReceipt
        public void LoadPayReceipt(List<PayReceiptObject> lstRecords)
        {
            //  Txt_NewYear_No.TextChanged -= new System.EventHandler(Txt_NewYear_No_TextChanged);
            if (lstRecords.Count > 0)
            {
                MTxt_InvoiceNo.Text = lstRecords[0].PayReceiptNo.ToString();
                lngCurrentPayReceiptNo = lstRecords[0].PayReceiptNo;
                lngYearSequenceNo = lstRecords[0].YearSequenceNo;
                intYear = lstRecords[0].Year;
                Cmb_PayTo.SelectedValue = lstRecords[0].AgentID;
                MTxt_Discription.Text = lstRecords[0].PayDiscription.ToString();
                MTxt_Value.Text = Convert.ToDecimal(lstRecords[0].AmountPaid).ToString("#######0.000");
                MTxt_Balance.Text = Convert.ToDecimal(lstRecords[0].BalanceAmount).ToString("#######0.000");
                Cmb_Reason.Text = lstRecords[0].PayReason.ToString();
                ///Added on 14 may 2014,to get the current year record or previous year record
                Dictionary<string, long> dicofyear = new Dictionary<string, long>();
                dicofyear.Add("Year", lstRecords[0].Year);
                dicofyear.Add("YearSequenceNo", lstRecords[0].YearSequenceNo);
                objPayReceiptHelper.CheckCurrentYear(dicofyear);
                ///----------------------------------------------------------------------------
                Txt_NewYear_No.Text = objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.CurrentYearStr;
                Dtp_Date.Value = Convert.ToDateTime(lstRecords[0].PayDate) == DateTime.MinValue || lstRecords[0].PayDate == null ? DateTime.Now : Convert.ToDateTime(lstRecords[0].PayDate);
                if (lstRecords[0].PayMethodID.ToString() == "101")
                {
                    chkCash.Checked = true;
                }
                else if (lstRecords[0].PayMethodID.ToString() == "103")
                {
                    chkCard.Checked = true;
                }
                else
                {
                    chkCheck.Checked = true;
                    Cmb_Bank.SelectedValue = lstRecords[0].BankID;
                    Cmb_Branch.SelectedValue = lstRecords[0].BranchID;
                }
                // if (lstRecords[0].PayRemarks.ToString().ToLower() == "save")
                if (lstRecords[0].PayStatus == 1 && !(string.IsNullOrEmpty(lstRecords[0].PayDiscription)))
                {
                    LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                    //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    LblStatus.ForeColor = Color.Green;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                }
                //else if (lstRecords[0].PayRemarks.ToString().ToLower() == "delete")
                else if (lstRecords[0].PayStatus == 0)
                {
                    LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    LblStatus.ForeColor = Color.Red;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {

                    LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
                    //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    LblStatus.ForeColor = Color.Blue;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = true;
                }
                if (!btnSave.Enabled)
                {
                    Cmb_PayTo.Enabled = Cmb_Reason.Enabled = false;
                    Cmb_Reason.BackColor = Cmb_PayTo.BackColor = Color.White;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = true;
                    chkCash.Enabled = chkCheck.Enabled =chkCard.Enabled = false;
                    MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                }
                else
                {
                    Cmb_PayTo.Enabled = Cmb_Reason.Enabled = true;
                    MTxt_Discription.ReadOnly = MTxt_Value.ReadOnly = false;
                    chkCash.Enabled = chkCheck.Enabled = chkCard.Enabled = true;
                    MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                }

            }
            else
            {
                GeneralFunction.Information("No Records Found", "PayReceipt");
            }

            //  Txt_NewYear_No.TextChanged += new System.EventHandler(Txt_NewYear_No_TextChanged);
        }
        #endregion


        #region GetRecordsAndLoad
        private void GetRecordsAndLoad()
        {
            try
            {
                List<PayReceiptObject> lstRecord = objPayReceiptHelper.lstBalance;
                LoadPayReceipt(lstRecord);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region ClearRecords

        private void ClearRecords()
        {
            try
            {
                Btn_Next.Enabled = false;
                decBalance = 0;
                MTxt_InvoiceNo.Text = "";
                Lbl_User.Text = GeneralFunction.UserName;
                Cmb_PayTo.Text = "";
                MTxt_Discription.Text = "";
                MTxt_Value.Text = "0.000";
                MTxt_Balance.Text = "0.000";
                Cmb_Reason.Text = "";
                LblStatus.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
                //LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                LblStatus.ForeColor = Color.Blue;
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                Txt_NewYear_No.Text = "";
                Cmb_PayTo.Text = "";
                Cmb_PayTo.SelectedIndex = -1;
                Cmb_PayTo.Enabled = chkCheck.Enabled = chkCash.Enabled = chkCard.Enabled = Cmb_Bank.Enabled = Cmb_Branch.Enabled = true;
                Cmb_Bank.SelectedValue = -1;
                Cmb_Branch.SelectedValue = -1;
                MTxt_Discription.ReadOnly = Cmb_Reason.ReadOnly = MTxt_Value.ReadOnly = MTxt_Discription.ReadOnly = false;
                Cmb_Reason.Enabled = true;
                Cmb_Reason.BackColor = MTxt_Discription.BackColor = MTxt_Value.BackColor = Color.White;
                Dtp_Date.Value = DateTime.Now;
                //Set_NY_New_NO();
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Pay Receipt", "btnNew_Click");
            }
        }

        #endregion

        #region GetAllPaymentID
        private void GetAllPaymentID()
        {
            try
            {
                objPayReceiptHelper.GetAllPaymntIdHelper();
                lstPayReceipt = objPayReceiptHelper.lstAllPayReceiptID;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region GetSearchedRecords

        public void GetSearchedRecords()
        {
            try
            {

                if (Txt_NewYear_No.Text != string.Empty && (Txt_NewYear_No.Text).Contains('-'))
                {
                    string[] NewYearNo = Txt_NewYear_No.Text.Split('-');
                    if (NewYearNo.Length == 2)
                    {
                        if (NewYearNo[1].ToString() != string.Empty)
                        {
                            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.Year = Convert.ToInt32(NewYearNo[0]);
                            objPayReceiptHelper.objPayReceiptBAL.objPayReceiptObject.YearSequenceNo = Convert.ToInt32(NewYearNo[1]);

                            if (NewYearNo[0].Length != 0 && NewYearNo[1].Length != 0)
                            {
                                if (objPayReceiptHelper.GetSearchedRecordHelper())
                                {
                                    int index = lstPayReceipt.FindIndex(x => x.PayReceiptNo == Convert.ToInt64(NewYearNo[1]));
                                    ItemIndex = index;
                                    GetRecordsAndLoad();
                                }
                            }
                            else
                            {
                                //GeneralFunction.Information("Enter valid Payment Id", this.Text);
                                //  ClearRecords();
                            }
                        }
                    }

                }
                else
                {
                    // GeneralFunction.Information("Enter valid Payment Id", this.Text);
                    //ClearRecords();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion




        #endregion

        private void Cmb_PayTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                // cmbR
            }
            else
            {
                if (sender is ComboBox)
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
        }


        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }
        private void setfont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is GroupBox || ctl is RadioButton || ctl is CheckBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control btn in groupBox2.Controls)
                {
                    if (btn is Button || btn is Label || btn is GroupBox || btn is RadioButton || btn is CheckBox)
                        btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

        private void Pay_Receipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }





    }
}
