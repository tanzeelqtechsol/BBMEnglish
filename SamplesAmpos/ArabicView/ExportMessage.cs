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
    public partial class ExportMessage : Form
    {
        internal int ExportMethod = 0;
        internal bool IsExport = false;
        public ExportMessage()
        {
            InitializeComponent();
            SetLanguage();
           

        }

        private void SetLanguage()
        {
            lblMessage.Text = Additional_Barcode.GetValueByResourceKey("ExportMethod");
            rbnSamePrice.Text = Additional_Barcode.GetValueByResourceKey("SameCostandPrice");
            rbnActualCost.Text = Additional_Barcode.GetValueByResourceKey("ActualCostandPrice");
            btnExportInvoice.Text = Additional_Barcode.GetValueByResourceKey("ExportInv");
            chkSameSalePrice.Text = Additional_Barcode.GetValueByResourceKey("KeepSalePriceCurrentSalePrice");
            chkOverrideSalePrice.Text = Additional_Barcode.GetValueByResourceKey("OverwriteSalePricewithImportedPrice");
            lbl_CashClientName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name");
            this.Text = Additional_Barcode.GetValueByResourceKey("ExportMessage");
        }

        private void rbnSamePrice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSamePrice.Checked)
                ExportMethod = 1;
            else if (rbnActualCost.Checked)
                ExportMethod = 2;
        }

        private void ExportMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ExportMethod != 0 || ExportMethod != null)
                this.Close();
        }

        private void ExportMessage_KeyPress(object sender, KeyPressEventArgs e)
        {

            CommonHelper.GeneralFunction.CashClientName = txt_CashClientName.Text.ToString();
            if (e.KeyChar == 13 || e.KeyChar == (char)Keys.Escape)
            {
                IsExport = true;
                this.Close();
            }

        }

        private void ExportMessage_Load(object sender, EventArgs e)
        {
            rbnSamePrice.Checked = true;
            if (this.Tag == "Cash Client Name")
            {
                btnExportInvoice.Visible = false;
                PurchaseImport.Visible = false;
            }
            else if (this.Tag != "PurchaseImport")
            {
                btnExportInvoice.Visible = true;
                PurchaseImport.Visible = false;
            }
            else
            {

            }
        }

        private void btnExportInvoice_Click(object sender, EventArgs e)
        {
            IsExport = true;
            this.Close();
        }

        private void chkOverrideSalePrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSameSalePrice.Checked)
                ExportMethod = 1;
            else if (chkOverrideSalePrice.Checked)
                ExportMethod = 2;
            this.Close();
        }

    }
}
