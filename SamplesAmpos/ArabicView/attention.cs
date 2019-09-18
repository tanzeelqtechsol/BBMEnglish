using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelper;


namespace BumedianBM.ArabicView
{
    public partial class frmattention : Form
    {

        #region"Variables"

        public string strFormName = "";

        #endregion

        #region"Constructors"

        public frmattention()
        {
            try
            {
                InitializeComponent();
                SetLanguage();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void SetLanguage()
        {
            lblOneRtnInvoice.Text = Additional_Barcode.GetValueByResourceKey("OneRtnInvoice");
            btnSaleRtnItem.Text = Additional_Barcode.GetValueByResourceKey("SalesReturn");
            btnPurchaseRtn.Text = Additional_Barcode.GetValueByResourceKey("PurchaseReturnInvoice");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            this.Text = Additional_Barcode.GetValueByResourceKey("Openform");
        }

        #endregion

        #region"Events"

        #region"Button Click Events"

        private void Btn_SaleRtnItem_Click(object sender, EventArgs e)
        {
            try
            {
                strFormName = "SALE";
                this.Close();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Btn_PurchaseRtnItem_Click(object sender, EventArgs e)
        {
            try
            {
                strFormName = "PURCHASE";
                this.Close();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion
    }
}