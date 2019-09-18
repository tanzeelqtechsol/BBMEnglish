using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class PaymentTypes : Form
    {

        public PaymentTypes()
        {
            InitializeComponent();
            SetLanguage();
        }
        public static bool fromPaymentTypesCheck = false;
        public static bool isCheckSave = false;
        public static bool isFromSales = false;
        public static string receiptDesc = string.Empty;
        double PercCard = 0;
        double PercCheck = 0;
        double fromTotal = 0;
        public long InvoiceNoText = 0;
        public string NewYearInvoiceNo = "";
        public string ClientText = "";
        public string NetAmt = "";
        public string Value = "";
        //public double paymentCharges = 0;

        private void onCheck()
        {
            Sales_Invoice.PaymentTypeID = 3;
            if (isFromSales)
                Sales_Invoice.salesTotal = fromTotal + calculatePercentage(PercCheck);
            else
                POS_Screen.posTotal = fromTotal + calculatePercentage(PercCheck);

            Receive_Receipt form = new Receive_Receipt();
            //
            form.ReceivedFrom = ClientText;
            form.Tag = isFromSales == true ? "SaleInvoice" : "POS";
            form.Description = isFromSales == true ? GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoiceNo") + " " + NewYearInvoiceNo : "POSInvoice " + NewYearInvoiceNo;
            form.ReceiptNo = InvoiceNoText;
            form.NetAmt = NetAmt;
            form.Value = Value;
            //
            fromPaymentTypesCheck = true;
            form.ShowDialog();
            fromPaymentTypesCheck = false;
            if (isCheckSave)
            {
                if (isFromSales)
                    Sales_Invoice.salesTotal = calculatePercentage(PercCheck);
                else
                    POS_Screen.posTotal = calculatePercentage(PercCheck);

                POS_Screen.selectedPaymentType = "check";
                this.Close();
            }
            else
            {
                if (isFromSales)
                    Sales_Invoice.salesTotal = 0;
                else
                    POS_Screen.posTotal = 0;
            }
        }
        private void onCash()
        {
            Sales_Invoice.PaymentTypeID = 1;
            POS_Screen.selectedPaymentType = "cash";
            isCheckSave = true;
            if (isFromSales)
                Sales_Invoice.salesTotal = 0;
            else
                POS_Screen.posTotal = 0;
            this.Close();
        }
        private void onCard()
        {
            Sales_Invoice.PaymentTypeID = 2;
            if (isFromSales)
                Sales_Invoice.salesTotal = calculatePercentage(PercCard);
            else
                POS_Screen.posTotal = calculatePercentage(PercCard);

            isCheckSave = true;
            POS_Screen.selectedPaymentType = "card";
            this.Close();
        }

        #region custom methods
        public void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("SelectPaymentMethod");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnCard.Text = Additional_Barcode.GetValueByResourceKey("Card");
            btnCheck.Text = Additional_Barcode.GetValueByResourceKey("Check");
            btnCash.Text = Additional_Barcode.GetValueByResourceKey("Cash");
        }
        private double calculatePercentage(double percentage)
        {
            double value = (fromTotal * percentage) / 100;
            //paymentCharges = value;
            //fromTotal = value;
            //value += saletotal_;
            return value;
        }
        #endregion

        #region events handler
        private void btnCash_Click(object sender, EventArgs e)
        {
            onCash();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            onCheck();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            onCard();
        }

        private void PaymentTypes_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;

            isCheckSave = false;
            PercCard = Convert.ToDouble(GeneralOptionSetting.FlagtxtPaymentPercentageCard);
            PercCheck = Convert.ToDouble(GeneralOptionSetting.FlagtxtPaymentPercentageCheck);

            if (isFromSales)
            {
                fromTotal = Sales_Invoice.salesTotal;
            }
            else
            {
                fromTotal = POS_Screen.posTotal;
            }
            //fromTotal = calculatePercentage(PercCheck);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCheckSave = false;
            if (isFromSales)
                Sales_Invoice.salesTotal = 0;
            else
                POS_Screen.posTotal = 0;
            this.Close();
        }
        #endregion

        private void PaymentTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // cash
                onCash();
            }
            else if (e.KeyCode == Keys.F2)
            {
                // card
                onCard();
            }
            else if (e.KeyCode == Keys.F3)
            {
                // check
                onCheck(); 
            }
        }
    }
}