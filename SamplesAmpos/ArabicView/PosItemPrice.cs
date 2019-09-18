using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;

namespace BumedianBM.ArabicView
{
    public partial class PosItemPrice : Form
    {
        public PosItemPrice()
        {
            InitializeComponent();
            SetLanguage();

        }

        public void SetLanguage()
        {
            //lblPaid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
           // lblRefund.Text = Additional_Barcode.GetValueByResourceKey("Refund");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Price");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
           // btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
           // btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnExactAmount.Text = Additional_Barcode.GetValueByResourceKey("Enter");
            this.Text = Additional_Barcode.GetValueByResourceKey("ItemPrice");
        }

        private void Button_NumberClick(object sender, EventArgs e)
        {
            try
            {
                bool IsMouse = (e is System.Windows.Forms.MouseEventArgs);
                if (!IsMouse)
                {
                    btnExactAmount_Click(null, null);
                }
                Control name = (Control)sender;
                if (Txt_Paid.Text == string.Empty)
                {
                    if (name.Name != "Btn_Dot") Txt_Paid.Text = Txt_Paid.Text + name.Text;
                   // Txt_Refund.Text = string.Empty;
                }
                else if (Txt_Paid.Text.Length <= 8)
                {
                    if (name.Name == "Btn_Dot" & Txt_Paid.Text.Contains(".") == true)
                    { Txt_Paid.Text = Txt_Paid.Text; }
                    else
                    { Txt_Paid.Text = Txt_Paid.Text + name.Text; }
                }
                decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty) ? Txt_Paid.Text : "0");
                
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Button_NumberClick");
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
        
            try
            {
                int index = Txt_Paid.Text.Length;
                Txt_Paid.Text = (Txt_Paid.Text != string.Empty) ? Txt_Paid.Text.Remove(index - 1) : Txt_Paid.Text;
                decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty) ? Txt_Paid.Text : "0");
                //Refundamount(amt);
                if (Txt_Paid.Text == string.Empty)
                {
                    // Txt_Refund.Text = string.Empty;
                    Txt_Paid.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Btn_Clear_Click");
            }
        }

        private void Btn_Equal_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Paid.Text != string.Empty && Txt_Paid.Text != string.Empty)
                {
                    Txt_Paid.Text = Convert.ToDecimal(Txt_Paid.Text).ToString("####0.000");
                    // Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal(Txt_Total.Text) - Convert.ToDecimal(Txt_Total.Text)).ToString("####0.000");
                }
                else if (Txt_Paid.Text != string.Empty && Txt_Paid.Text == string.Empty)
                {
                    //Txt_Refund.Text = "0.000";
                }
                else if (Txt_Paid.Text == string.Empty || Txt_Paid.Text != string.Empty)
                {
                    Txt_Paid.Text = Convert.ToDecimal(Txt_Paid.Text).ToString("####0.000");
                    //Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal((Txt_Total.Text == string.Empty) ? "0.00" : Txt_Total.Text) - Convert.ToDecimal((Txt_Total.Text == string.Empty) ? "0.000" : Txt_Total.Text)).ToString("####0.000");
                }
                //else Txt_Refund.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Btn_Equal_Click");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExactAmount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Paid.Text))
            {
               // MessageBox.Show("Please Enter Valid Price");
                return;
            }
            else
            {
                POS_Screen.PosItemPriceVal = Convert.ToDecimal(Txt_Paid.Text);
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void Txt_Total_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnExactAmount_Click(null, null);
                }
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

        private void Txt_Total_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Txt_Paid.Text != string.Empty)
                {
                    decimal amt = Convert.ToDecimal((Txt_Paid.Text != string.Empty && Txt_Paid.Text != ".") ? Txt_Paid.Text : "0");
                    //Refundamount(amt);
                }
                
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Txt_Paid_KeyUp");
            }
        }
    }
    
}
