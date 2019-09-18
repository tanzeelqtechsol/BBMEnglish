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
    public partial class PaymentTypesCharges : Form
    {
        public PaymentTypesCharges()
        {
            InitializeComponent();
            SetLanguage();
        }

        #region custom methods
        private void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("PaymentMethod");
            btnClear.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnSubmit.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            lblCard.Text = "% " + Additional_Barcode.GetValueByResourceKey("Card");
            lblCheck.Text = "% " + Additional_Barcode.GetValueByResourceKey("Check");
        }
        private void bindTextfields()
        {
            txtPercentageCheck.Text = GeneralOptionSetting.FlagtxtPaymentPercentageCheck.ToString();
            txtPercentageCard.Text = GeneralOptionSetting.FlagtxtPaymentPercentageCard.ToString();
        }
        private void onSave()
        {
            Option_Seeting.paymentTypeChargesValueCheck = txtPercentageCheck.Text;
            Option_Seeting.paymentTypeChargesNameCheck = txtPercentageCheck.Name;
            Option_Seeting.paymentTypeChargesValueCard = txtPercentageCard.Text;
            Option_Seeting.paymentTypeChargesNameCard = txtPercentageCard.Name;
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentTypesCharges_Load(object sender, EventArgs e)
        {
            bindTextfields();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            onSave();
            this.Close();
        }
    }
}
