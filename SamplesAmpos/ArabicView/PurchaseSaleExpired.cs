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
    public partial class PurchaseSaleExpired : Form
    {
        internal String lblText = string.Empty;
        public PurchaseSaleExpired()
        {
            InitializeComponent();
            Btn_Close.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            this.Text = Additional_Barcode.GetValueByResourceKey("ExpiryAlert");
        }

        private void PurchaseExpired_Load(object sender, EventArgs e)
        {
            Lbl_PurchaseExpiredMsg.Text = lblText;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseSaleExpired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == (Char)Keys.Escape)
                this.Close();
        }
    }
}
