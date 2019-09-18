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
    public partial class CustomMessageBox : Form
    {
        public string ButtonClick;

        #region SetLanguage
        public void SetLanguage()
        {

            btnPrintAll.Text = Additional_Barcode.GetValueByResourceKey("PrintAll");
            btnPrintNew.Text = Additional_Barcode.GetValueByResourceKey("PrintNew");
            btnPrintReceipt.Text = Additional_Barcode.GetValueByResourceKey("PrintReceipt");
            this.Text = Additional_Barcode.GetValueByResourceKey("POSInvoice");
            lblMsg.Text = Additional_Barcode.GetValueByResourceKey("POSPrintMsg");
        }
        #endregion
        public CustomMessageBox()
        {
            InitializeComponent();
            SetLanguage();
        }

        private void btnClickEvent_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Tag.ToString();
            if (s == "Print All")
                ButtonClick = s;
            else if (s == "Print New")
                ButtonClick = s;
            else if (s == "Print Receipt")
                ButtonClick = s;
            else
                ButtonClick = s;

            this.Close();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }
    }
}
