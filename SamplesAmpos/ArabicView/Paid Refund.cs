using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CommonHelper;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class Paid_Refund : Form,IDisposable
    {

        #region Declaration
        public string clientID = string.Empty;
        #endregion

        #region Constructor
        public Paid_Refund()
        {
            InitializeComponent();
            SetLanguage();

        }
        #endregion

        #region Events

        #region Form Load
        private void Paid_Refund_Load(object sender, EventArgs e)
        {
            try
            {
                Txt_Paid.SelectAll();
                Txt_Paid.Focus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Paid_Refund_Load");
            }
        }
        #endregion

        #region Button Click

        #region btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnCancel_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0.000M;
                total = (Txt_Total.Text != string.Empty) ? Convert.ToDecimal(Txt_Total.Text) : Convert.ToDecimal(0.000);
                GeneralFunction.Paid = (Txt_Paid.Text != string.Empty) ? Convert.ToDecimal(Txt_Paid.Text) : Convert.ToDecimal(0.000);
                GeneralFunction.Refund = (Txt_Refund.Text != string.Empty) ? Convert.ToDecimal(Txt_Refund.Text) : Convert.ToDecimal(0.000);
                if (clientID == "1001" && GeneralFunction.Paid < total)
                {
                    GeneralFunction.Information("PaidLessthanTotal", this.Text);
                    Txt_Paid.Focus();
                    this.DialogResult = DialogResult.None;
                    return;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnClose_Click");
            }

        }
        #endregion

        #region btnExactAmount_Click
        private void btnExactAmount_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Paid.Text = Txt_Total.Text;
                Txt_Refund.Text = "0.000";
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnClose_Click");
            }

        }
        #endregion

        #region Button_NumberClick
        private void Button_NumberClick(object sender, EventArgs e)
        {
            try
            {
                Control name = (Control)sender;
                if (Txt_Paid.Text == string.Empty)
                {
                    if (name.Name != "Btn_Dot") Txt_Paid.Text = Txt_Paid.Text + name.Text;
                    Txt_Refund.Text = string.Empty;
                }
                else if (Txt_Paid.Text.Length <= 8)
                {
                    if (name.Name == "Btn_Dot" & Txt_Paid.Text.Contains(".") == true)
                    { Txt_Paid.Text = Txt_Paid.Text; }
                    else
                    { Txt_Paid.Text = Txt_Paid.Text + name.Text; }
                }
                decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty) ? Txt_Paid.Text : "0");
                Refundamount(amt);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Button_NumberClick");
            }
        }
        #endregion

        #region Btn_Clear_Click
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Txt_Paid.Text.Length;
                Txt_Paid.Text = (Txt_Paid.Text != string.Empty) ? Txt_Paid.Text.Remove(index - 1) : Txt_Paid.Text;
                decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty) ? Txt_Paid.Text : "0");
                Refundamount(amt);
                if (Txt_Paid.Text == string.Empty)
                {
                    Txt_Refund.Text = string.Empty;
                    Txt_Paid.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Btn_Clear_Click");
            }
        }
        #endregion

        #region Btn_Equal_Click
        private void Btn_Equal_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Total.Text != string.Empty && Txt_Paid.Text != string.Empty)
                {
                    Txt_Paid.Text = Convert.ToDecimal(Txt_Paid.Text).ToString("####0.000");
                    Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal(Txt_Total.Text) - Convert.ToDecimal(Txt_Paid.Text)).ToString("####0.000");
                }
                else if (Txt_Total.Text != string.Empty && Txt_Paid.Text == string.Empty)
                {
                    Txt_Refund.Text = "0.000";
                }
                else if (Txt_Total.Text == string.Empty || Txt_Paid.Text != string.Empty)
                {
                    Txt_Paid.Text = Convert.ToDecimal(Txt_Paid.Text).ToString("####0.000");
                    Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal((Txt_Total.Text == string.Empty) ? "0.00" : Txt_Total.Text) - Convert.ToDecimal((Txt_Paid.Text == string.Empty) ? "0.000" : Txt_Paid.Text)).ToString("####0.000");
                }
                else Txt_Refund.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Btn_Equal_Click");
            }
        }
        #endregion

        #endregion

        #region "Text chaned Events
        private void Txt_Refund_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Refund.Text != string.Empty && decimal.Parse(Txt_Refund.Text) >= 0)
                {
                    Txt_Refund.ForeColor = Color.Red;
                }
                else
                {
                    Txt_Refund.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Txt_Refund_TextChanged");
            }
            
        }
        #endregion

        #region "Key press Events
        private void Txt_Paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (NumericOnly(sender, e) | (Txt_Paid.Text.Length > 8))
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Txt_Paid_KeyPress");
            }
        }
        #endregion

        #region "Key up Events
        private void Txt_Paid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Txt_Paid.Text != string.Empty)
                {
                    decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty && Txt_Paid.Text != ".") ? Txt_Paid.Text : "0");
                    Refundamount(amt);
                }
                else
                {
                    Txt_Refund.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Txt_Paid_KeyUp");
            }
        }
        #endregion

        #region "Key Down Events"
        private void PaidRefund_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
                else if (e.KeyData == Keys.Enter)
                {
                    this.InvokeOnClick(btnClose, EventArgs.Empty);
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "PaidRefund_KeyDown");
            }
        }
        #endregion


        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            lblPaid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
            lblRefund.Text = Additional_Barcode.GetValueByResourceKey("Refund");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnExactAmount.Text = Additional_Barcode.GetValueByResourceKey("ExactAmount");
            this.Text = Additional_Barcode.GetValueByResourceKey("PaidRefund");
        }
        #endregion

        #region Refundamount
        void Refundamount(decimal paidamt)
        {
            try
            {
                Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal((Txt_Total.Text != string.Empty) ? Txt_Total.Text : "0") - paidamt).ToString("####0.000");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region NumericOnly
        private Boolean NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
            {
                return true;
            }
            else
            {
                if (e.KeyChar == 46 && ((MaskedTextBox)sender).Text.Contains("."))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

            GeneralFunction.Information("NotClosedInvoice", "POS Screen");
        }



        #endregion


    }
}
