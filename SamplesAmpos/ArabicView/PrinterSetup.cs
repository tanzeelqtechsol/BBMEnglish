using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class PrinterSetup : Form, IDisposable
    {

        public PrinterSetup()
        {
            InitializeComponent();
            SetLanguage();
        }
        #region Variables

        public PrinterSetupHelper objPrinterSetupHelper = new PrinterSetupHelper();

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("PrinterSetup");
            lblDefault.Text = Additional_Barcode.GetValueByResourceKey("Default");
            lblInvoice.Text = Additional_Barcode.GetValueByResourceKey("BtnInvoice");
            lblPos.Text = Additional_Barcode.GetValueByResourceKey("POS");
            lblReceipts.Text = Additional_Barcode.GetValueByResourceKey("BtnReceipt");
            lblReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            lblBarcode.Text = Additional_Barcode.GetValueByResourceKey("BarcodeHeading");
            btnApply.Text = Additional_Barcode.GetValueByResourceKey("Apply");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            lblHeading.Text= Additional_Barcode.GetValueByResourceKey("PrinterSetupHeading");
        }
        #endregion

        private void GetPrinterlist()
        {
            String InstalledPrinters;
            cmbDefault.Items.Add("N/A");
            cmbInvoice.Items.Add("N/A");
            cmbPos.Items.Add("N/A");
            cmbReceipt.Items.Add("N/A");
            cmbReport.Items.Add("N/A");
            cmbBarcode.Items.Add("N/A");

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                InstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbDefault.Items.Add(InstalledPrinters);
                cmbInvoice.Items.Add(InstalledPrinters);
                cmbPos.Items.Add(InstalledPrinters);
                cmbReceipt.Items.Add(InstalledPrinters);
                cmbReport.Items.Add(InstalledPrinters);
                cmbBarcode.Items.Add(InstalledPrinters);

            }
        }
        private void SetObjectFromControl()
        {

            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.Default = cmbDefault.Text;
            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.Invoice = cmbInvoice.Text;
            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.POS = cmbPos.Text;
            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.Receipt = cmbReceipt.Text;
            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.Report = cmbReport.Text;
            objPrinterSetupHelper.objPrinterSetupBAL.objPrinterObject.Barcode = cmbBarcode.Text;
        }

        private void SetControlFromObject()
        {

            cmbDefault.Text = GeneralOptionSetting.FlagPrinterDefault;
            cmbInvoice.Text = GeneralOptionSetting.FlagPrinterInvoice;
            cmbPos.Text = GeneralOptionSetting.FlagPrinterPOS;
            cmbReceipt.Text = GeneralOptionSetting.FlagPrinterReceipt;
            cmbReport.Text = GeneralOptionSetting.FlagPrinterReport;
            cmbBarcode.Text = GeneralOptionSetting.FlagPrinterBarcode;
        }

        #endregion

        private void PrinterSetup_Load(object sender, EventArgs e)
        {
            GetPrinterlist();
            SetControlFromObject();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SetObjectFromControl();
            objPrinterSetupHelper.UpdatePrinterSetupHelper();
            GeneralFunction.GetOptionDatas();
            this.Close();
        }
    }
}
