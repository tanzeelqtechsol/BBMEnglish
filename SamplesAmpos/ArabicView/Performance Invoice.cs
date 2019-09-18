using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using CommonHelper;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Performance_Invoice : Form, IDisposable
    {

        #region Declaration
        PerformanceHelper objPerformHelper;
        public SalesInvoiceHelper objSaleInvoiceHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        DataTable dtallBarcode;
        #endregion

        #region Constructor
        public Performance_Invoice()
        {
            InitializeComponent();
            objPerformHelper = new PerformanceHelper();
            objSaleInvoiceHelper = new SalesInvoiceHelper();
            SetLanguage();
            setFont();
            tmrBlinkNotes.Tick += blinkTextbox;
            tmrBlinkNotes.Interval = 650;
            tmrBlinkNotes.Enabled = true;
        }
        #endregion

        #region Events

        #region Form Load
        private void Performance_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format Check by Seenivasan on 13-Oct-2014************************//
                DTP_PER_ValidDate.Format = DateTimePickerFormat.Custom;
                DTP_Date.Format = DateTimePickerFormat.Custom;
                DTP_PER_ValidDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                DTP_Date.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                AssignToComboBox();
                Cmb_Category.SelectedIndexChanged += new EventHandler(Cmb_Category_SelectedIndexChanged);
                Cmb_Company.SelectedIndexChanged += new EventHandler(Cmb_Company_SelectedIndexChanged);
                UserLimitation();
                PerformaOptionSetting();
                objPerformHelper.GetCurrentYear();
                objPerformHelper.GetMaxOrderInvNoHelper();




                //This is commented due to Performa Invoice No started from zero and changed as below

                //txtInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.OrderInvoiceNo.ToString();
                //objPerformHelper.lstGridDetails.Clear();
                //DisplayInvoiceDetails();
                //DgvPerInvoice.Refresh();


                //////
                long InvNO = objPerformHelper.objPerfrmnceBal.objSalObjects.OrderInvoiceNo;
                if (InvNO == 0)
                {
                    btnNewInvoice_Click(null, null);
                }
                else
                {
                    txtInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.OrderInvoiceNo.ToString();
                    objPerformHelper.lstGridDetails.Clear();
                    DisplayInvoiceDetails();
                    DgvPerInvoice.Refresh();
                }
                //////

                //--------------------------------------------------------

                Lbl_user.Text = GeneralFunction.UserName;
                CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTxt_Notes);
                CustomNotesAlerts.Set_NotesAlertDetails(RTxt_Notes);
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                Cmb_ItemName.SelectAll();
                Cmb_ItemName.Focus();
                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "Performance_Invoice_Load");
            }

        }
        #endregion

        #region Button Click

        #region btnBox_Click
        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.BoxAction();
                SetBoxPieceValue();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnBox_Click");
            }
        }
        #endregion

        #region btnNewInvoice_Click
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                GridClear();
                ClearAll();
                ClearTextFields(); // To added by manoj for the issue of stock, package qty is not refreshing once click new button.
                objPerformHelper.NewInvoiceHelper();
                txtInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.InvoiceText;
                Txt_NewInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NewYrInvoiceText;
                MTxt_Discount.Text = "0.000";
                btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                //  strPiece = "";
                rbnValue.Enabled = rbnPercentage.Enabled = rbnValue.Checked = (GeneralOptionSetting.FlagDisableDiscountFiled != "Y" ? true : false);
                Cmb_SupplierName.SelectedIndex = Cmb_SupplierNo.SelectedIndex = -1;
                Cmb_SupplierNo.Focus();
                objPerformHelper.InsertEmptyRecord(RTxt_Notes);
                MTxt_Discount.ReadOnly = false;
                RTxt_Notes.Text = "";
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.New), txtInvoiceNo.Text, "Order", "New proforma invoice details", Convert.ToInt16(InvoiceAction.Yes));

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnNewInvoice_Click");
            }
        }
        #endregion

        #region btnAddItem_Click
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //*****Saving New Client*********************//

                if (Cmb_SupplierName.SelectedIndex == -1 && Cmb_SupplierName.Text != "")
                {
                    if (GeneralFunction.Question("Doyouwanttosavenewuser", "Performa Invoice") == DialogResult.Yes)
                    {
                        string strNewAgent = Cmb_SupplierName.Text;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = Cmb_SupplierName.Text;
                        if (objSaleInvoiceHelper.SaveNewAgent())
                        {
                            Cmb_SupplierName.DataSource = null;
                            Cmb_SupplierNo.DataSource = null;
                            AssignClientDataSource();
                            objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = strNewAgent;
                            Cmb_SupplierName.Text = strNewAgent;
                        }

                    }
                    else
                        return;
                }

                SetObjectFromControl();
                objPerformHelper.CheckInsertItem();
                AssignGridSource();
                SetTotal();
                if (objPerformHelper.lstGridDetails.Count > 0)
                {
                    DgvPerInvoice.Rows[0].Selected = true;
                }
                //////To highlight the last inserted record    on 09 jun 2014//////////////////
                if (DgvPerInvoice.Rows.Count > 0)
                {

                    DgvPerInvoice.ClearSelection();

                    DgvPerInvoice.FirstDisplayedScrollingRowIndex = DgvPerInvoice.Rows.Count - 1;

                    DgvPerInvoice.Rows[DgvPerInvoice.Rows.Count - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnAddItem_Click");
            }
        }
        #endregion

        #region btnCloseInvoice_Click
        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.CheckCloseInvoice();
                if (GeneralOptionSetting.FlagOpenInvioceAfterClosing == "Y")
                {
                    btnNewInvoice_Click(sender, e);
                }
                if (objPerformHelper.objPerfrmnceBal.objSalObjects.SaveFlag)
                {
                    DgvPerInvoice.BackgroundColor = Color.Gray;
                    DgvPerInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
                    // AssignToComboBox();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnCloseInvoice_Click");
            }
        }
        #endregion

        #region btnDeleteItem_Click
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.CheckDeleteItem(DgvPerInvoice);
                AssignGridSource();
                MTxt_Total.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.TotalText;
                txtNet.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NetText;

                if (objPerformHelper.lstGridDetails.Count == 0)
                {
                    MTxt_Discount.Text = "0.000";
                    txtNet.Text = "0.000";
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnDeleteItem_Click");
            }
        }
        #endregion

        #region btnModifyInvoice_Click
        private void btnModifyInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.ModifyInvoice(DgvPerInvoice);
                if (objPerformHelper.objPerfrmnceBal.objSalObjects.SaveFlag == true)
                {
                    MTxt_Discount.ReadOnly = false;
                    //DgvPerInvoice.BackgroundColor = Color.NavajoWhite;  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    DgvPerInvoice.BackgroundColor = Color.WhiteSmoke;
                    DgvPerInvoice.DefaultCellStyle.BackColor = Color.White;
                    rbnValue.Enabled = rbnPercentage.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnModifyInvoice_Click");
            }

        }
        #endregion

        #region btnItemInfo_Click
        private void btnItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (objPerformHelper.ObjItemInfo.Visible == false)
                {
                    if (Cmb_ItemName.Text != string.Empty && Cmb_ItemName.Text != null)
                    {
                        objPerformHelper.ObjItemInfo.ItemNo = Convert.ToInt16(Cmb_ItemName.SelectedValue == null ? "0" : Cmb_ItemName.SelectedValue.ToString());
                        objPerformHelper.ObjItemInfo.ItemName = Cmb_ItemName.Text;
                        objPerformHelper.ObjItemInfo.ShowDialog();
                    }
                    else
                    {
                        if (DgvPerInvoice.SelectedRows.Count > 0)
                        {
                            objPerformHelper.ObjItemInfo.ItemNo = Convert.ToInt32(DgvPerInvoice.SelectedRows[0].Cells["itemno"].Value);
                            objPerformHelper.ObjItemInfo.ItemName = DgvPerInvoice.SelectedRows[0].Cells["item_name"].Value.ToString();
                            objPerformHelper.ObjItemInfo.ShowDialog();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnItemInfo_Click");
            }

        }
        #endregion

        #region btn_NavigationClick
        private void btn_NavigationClick(object sender, EventArgs e)
        {
            try
            {
                objPerformHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                objPerformHelper.objPerfrmnceBal.objSalObjects.OrderInvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                objPerformHelper.NavigationEvent();
                txtInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.OrderInvoiceNo.ToString();
                DisplayInvoiceDetails();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btn_NavigationClick");
            }

        }
        #endregion

        #region btnMoveToSale_Click
        private void btnMoveToSale_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.MoveToSales();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnMoveToSale_Click");
            }

        }
        #endregion

        #region btnBalanceSheet_Click
        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                frmBalanceSheet objBalanceSheet = new frmBalanceSheet();
                if (Cmb_SupplierName.Text.Length != 0)
                {
                    objBalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(Cmb_SupplierNo.Text);
                    objBalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = Cmb_SupplierName.Text;
                    objBalanceSheet.ShowDialog();
                }
                else
                    objBalanceSheet.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnBalanceSheet_Click");
            }
        }
        #endregion

        #region btnReturnItem_Click
        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sales_Return_Invoice objFrm = new Sales_Return_Invoice();
                objFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnReturnItem_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region btnFindInvoice_Click
        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Find_Sales_Invoice objFrm = new Find_Sales_Invoice();
                objFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnFindInvoice_Click");
            }
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                objPerformHelper.objPerfrmnceBal.objSalObjects.NotesText = MTxt_Note.Text;
                objPerformHelper.objPerfrmnceBal.objSalObjects.ChkNoteChecked = chkNote.Checked;
                objPerformHelper.CheckPrint(DgvPerInvoice);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "btnPrint_Click");
            }
        }
        #endregion


        #endregion

        #region IndexChanged

        #region Cmb_ItemNo_SelectedIndexChanged
        private void Cmb_ItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Cmb_ItemNo.SelectedIndex > -1) && (Cmb_ItemNo.Text != "System.Data.DataRowView"))
                {
                    // Cmb_ItemName.Text = Cmb_ItemNo.SelectedValue.ToString();
                    Cmb_ItemName.SelectedValue = Cmb_ItemNo.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "Cmb_ItemNo_SelectedIndexChanged");
            }

        }
        #endregion

        #region Cmb_ItemName_SelectedIndexChanged
        private void Cmb_ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Cmb_ItemName.SelectedIndex > -1))
                {
                    SetIntialValues();
                    SetObjectFromControl();
                    objPerformHelper.GetItemDetailsForID(RTxt_Notes);
                    MTxt_Remaining.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.RemainingText;
                    MTxt_Price.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText;
                    MTxt_Stock.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.StockText;
                    MTxt_Box.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.PackageText;
                    objPerformHelper.CurrentPrice = Convert.ToDecimal(objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText);
                    if (objPerformHelper.objPerfrmnceBal.objSalObjects.HasExpiry)
                    {
                        if (objPerformHelper.lstItemExpirydates.Count > 0)
                        {
                            //Changed to disable the Expiries When item is in second hand. Done By:A.Manoj On June-25
                            //Cmb_PER_Date.Enabled = false;
                            //Cmb_PER_Date.Text = DateTime.Now.ToShortDateString();
                            Cmb_PER_Date.Visible = true;
                            lblExpiryDate.Visible = true;
                            //****************

                            Cmb_PER_Date.DisplayMember = "ItemExpiryDate";
                            Cmb_PER_Date.ValueMember = "ItemExpiryDate";
                            Cmb_PER_Date.DataSource = objPerformHelper.lstItemExpirydates;

                        }
                        else
                            Cmb_PER_Date.DataSource = null;
                    }
                    else
                    {
                        //Changed to disable the Expiries When item is in second hand. Done By:A.Manoj On June-25
                        //Cmb_PER_Date.Enabled = false;
                        //Cmb_PER_Date.Text = DateTime.Now.ToShortDateString();
                        Cmb_PER_Date.Visible = false;
                        lblExpiryDate.Visible = false;
                        //****************
                    }

                    //Added on 19-Apr-14
                    if (objPerformHelper.lstItemDetails.Count > 0)
                    {
                        cmbPackageQty.SelectedIndex = -1;
                        cmbPackageQty.DisplayMember = "ItemPackage";
                        cmbPackageQty.ValueMember = "BarcodeID";
                        cmbPackageQty.DataSource = objPerformHelper.lstItemDetails;
                        cmbPackageQty.SelectedValue = objPerformHelper.lstItemDetails[0].BarcodeID;
                    }
                    SetRowColor(Cmb_ItemName.Text);
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
                else
                {
                    ClearTextFields();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "Cmb_ItemName_SelectedIndexChanged");
            }
        }

        #endregion

        #region Cmb_SupplierName_SelectedIndexChanged
        private void Cmb_SupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_SupplierName.SelectedIndex != -1)
                {

                    if ((Cmb_ItemName.Items.Count > 0) && (Cmb_SupplierName.SelectedValue.ToString() != "1001")) { Cmb_ItemName_SelectedIndexChanged(sender, e); }
                    Cmb_ItemName.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "Cmb_SupplierName_SelectedIndexChanged");
            }
        }
        #endregion

        #region cmbPackageQty_SelectedIndexChanged
        private void cmbPackageQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objPerformHelper.PackageQty = Convert.ToInt16(cmbPackageQty.Text==string.Empty?"1":cmbPackageQty.Text);
                objPerformHelper.objPerfrmnceBal.objSalObjects.itemid = Convert.ToInt32(Cmb_ItemName.SelectedValue);
                objPerformHelper.objPerfrmnceBal.objSalObjects.BarcodeID = Convert.ToInt32(cmbPackageQty.SelectedValue);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.BarcodeID = Convert.ToInt32(cmbPackageQty.SelectedValue);
                objPerformHelper.objPerfrmnceBal.objSalObjects.PackagePrice = objSaleInvoiceHelper.GetPriceForPackageQtyHelper();
                objPerformHelper.PackageQtySelectionChanged();
                // objPerformHelper.CurrentPrice = Convert.ToDecimal(objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText);
                MTxt_Remaining.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.RemainingText;
                MTxt_Price.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText;
                MTxt_Stock.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.StockText;
                txtQuantity.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.QtyText;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "cmbPackageQty_SelectedIndexChanged");
            }
        }
        #endregion


        #endregion

        #region Checked Changed

        #region rbnPercentage_CheckedChanged
        private void rbnPercentage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DiscountCalculation();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "rbnPercentage_CheckedChanged");
            }
        }
        #endregion
        #region rbnValue_CheckedChanged
        private void rbnValue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DiscountCalculation();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "rbnValue_CheckedChanged");
            }
        }
        #endregion


        #endregion

        #region Text Leave
        private void MTxt_Price_Leave(object sender, EventArgs e)
        {
            if (MTxt_Price.Text != "" && MTxt_Price.Text != string.Empty)
            {
                MTxt_Price.Text = Convert.ToDecimal(MTxt_Price.Text).ToString("#######0.000");
                objPerformHelper.CurrentPrice = Convert.ToDecimal(MTxt_Price.Text);
            }
        }
        #endregion

        #region KeyUp Events

        #region txtQuantity_KeyUp
        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ((Cmb_ItemName.SelectedIndex > -1) && ((ScanValue.Length < 2 & DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds > 20)))
                {
                    SetObjectFromControl();
                    objPerformHelper.StockAdjustment();
                    MTxt_Remaining.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.RemainingText;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "txtQuantity_KeyUp");
            }
        }
        #endregion


        #endregion

        #region Text Changed

        #region MTxt_Discount_TextChanged
        private void MTxt_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DiscountCalculation();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "MTxt_Discount_TextChanged");
            }
        }
        #endregion
        #endregion

        #region RTxt_Notes_MouseDoubleClick
        private void RTxt_Notes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = RTxt_Notes.SelectedText.Trim();
            Purchase_Invoice.ReorderandBalance(str);
        }
        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {

            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "       ";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintF6") + "       ";
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnI") + "       ";
            this.Text = Additional_Barcode.GetValueByResourceKey("Performance") + "       ";
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("INo");
            lblClient.Text = Additional_Barcode.GetValueByResourceKey("Client");
            lblClientNo.Text = Additional_Barcode.GetValueByResourceKey("ClientNo");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblThisInvValidUntil.Text = Additional_Barcode.GetValueByResourceKey("ValidUntill");
            lblRemaining.Text = Additional_Barcode.GetValueByResourceKey("Remaining");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            lblPackage.Text = Additional_Barcode.GetValueByResourceKey("Package");
            chkHideLogo.Text = Additional_Barcode.GetValueByResourceKey("HidenLogo");
            chkNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            chkPrintPerview.Text = Additional_Barcode.GetValueByResourceKey("PP");
            chkTax.Text = Additional_Barcode.GetValueByResourceKey("IncludeTax");
            rbnPercentage.Text = Additional_Barcode.GetValueByResourceKey("Persentage");
            rbnValue.Text = Additional_Barcode.GetValueByResourceKey("Value");
            btnBox.Text = Additional_Barcode.GetValueByResourceKey("BoxF9");
            grpNotesAndAlert.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            lblExpiryDate.Text = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            btnAddItem.Text = Additional_Barcode.GetValueByResourceKey("AddItem") + "       ";
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet") + "       ";
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInvoice") + "       ";
            btnFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice") + "       ";
            btnItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11")+"        ";
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice") + "       ";
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInvoice") + "       ";
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem") + "       ";
            btnDeleteItem.Text = Additional_Barcode.GetValueByResourceKey("DeleteF2") + "       ";
            btnMoveToSale.Text = Additional_Barcode.GetValueByResourceKey("MoveToSale") + "       ";
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblNet.Text = Additional_Barcode.GetValueByResourceKey("Net");


            //Grid Columns Language Setting

            DgvPerInvoice.Columns["itemno"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            DgvPerInvoice.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            DgvPerInvoice.Columns["item_name"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            DgvPerInvoice.Columns["ItemExpiry"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry"); //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25
            DgvPerInvoice.Columns["exp_date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            DgvPerInvoice.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            DgvPerInvoice.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Qty");
            DgvPerInvoice.Columns["unit_price"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            DgvPerInvoice.Columns["sub_total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            DgvPerInvoice.Columns["in_time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            DgvPerInvoice.Columns["user"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            DgvPerInvoice.Columns["ReturnQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Returned");
            DgvPerInvoice.Columns["Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("Price");
            DgvPerInvoice.Columns["Cost"].HeaderText = Additional_Barcode.GetValueByResourceKey("Cost");
            DgvPerInvoice.Columns["Discount1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Discount");
            DgvPerInvoice.Columns["BoxQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");

            //Grid Columns Language Setting


        }
        #endregion

        #region AssignToComboBox
        private void AssignToComboBox()
        {
            objPerformHelper.LoadClientDetails();
            DataTable dtDetails = objPerformHelper.ItemDetailstoPerform();//add on 09jan2015 to load item details 
            Cmb_SupplierName.DisplayMember = "Name";
            Cmb_SupplierName.ValueMember = "AgentId";

            Cmb_SupplierName.DataSource = objPerformHelper.lstClientList;
            Cmb_SupplierName.SelectedIndex = -1;

            Cmb_SupplierNo.DisplayMember = "AgentId";
            Cmb_SupplierNo.ValueMember = "Name";
            Cmb_SupplierNo.DataSource = objPerformHelper.lstClientList;
            Cmb_SupplierNo.SelectedIndex = -1;

            if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
            {
                //lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
                //lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }

            Cmb_Category.DisplayMember = "Category";
            Cmb_Category.ValueMember = "CategoryID";

            Cmb_Category.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;
            Cmb_Category.SelectedIndex = -1;

            Cmb_Company.DisplayMember = "Company";
            Cmb_Company.ValueMember = "CompanyID";

            Cmb_Company.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;
            Cmb_Company.SelectedIndex = -1;


            Cmb_ItemName.SelectedIndexChanged -= new EventHandler(Cmb_ItemName_SelectedIndexChanged);
            Cmb_ItemNo.SelectedIndexChanged -= new EventHandler(Cmb_ItemNo_SelectedIndexChanged);
            //Cmb_ItemName.DataSource = GeneralObjectClass.ItemDetails;//Commented on 21-May-2014

            Cmb_ItemName.DisplayMember = "Name";
            Cmb_ItemName.ValueMember = "ID";

            Cmb_ItemName.DataSource = dtDetails; // objPerformHelper.LoadItemDetails();//Added on 21-May-2014 Changed on 09Jan2015
            Cmb_ItemName.SelectedIndex = -1;

            //Cmb_ItemNo.DataSource = GeneralObjectClass.ItemDetails.Where(i => i.ItemNumber != string.Empty).ToList();//Commented on 21-May-2014
            Cmb_ItemNo.DisplayMember = "ItemNumber";
            Cmb_ItemNo.ValueMember = "ID";
            DataView dvfilter = new DataView(dtDetails);
            dvfilter.RowFilter = "ItemNumber<>''";
            Cmb_ItemNo.DataSource = dvfilter.ToTable(); //objPerformHelper.LoadItemDetails().Where(i => i.ItemNumber != string.Empty).ToList();//Added on 21-May-2014 Changed on 09jan2015 for barcode scanning tuning
            Cmb_ItemNo.SelectedIndex = -1;
            Cmb_ItemName.SelectedIndexChanged += new EventHandler(Cmb_ItemName_SelectedIndexChanged);
            Cmb_ItemNo.SelectedIndexChanged += new EventHandler(Cmb_ItemNo_SelectedIndexChanged);

        }
        #endregion

        #region EnableDisableButton
        private void EnableDisableButton()
        {
            btnNewInvoice.Enabled = btnCloseInvoice.Enabled = btnAddItem.Enabled = btnDeleteItem.Enabled = btnMoveToSale.Enabled = btnClose.Enabled = true;/// !Gb_ItemInformation.Visible;
            btnPrint.Enabled = (UserScreenLimidations.Print == true) ? true : false;
            btnFindInvoice.Enabled = (UserScreenLimidations.FindSaleInvoice == true) ? true : false;
            btnReturnItem.Enabled = (UserScreenLimidations.SaleReturnInvoice == true) ? true : false;
            btnBalanceSheet.Enabled = (UserScreenLimidations.BalanceSheet == true) ? true : false;
            btnModifyInvoice.Enabled = (UserScreenLimidations.ModifyInvoice == true) ? true : false;

        }
        #endregion

        #region SetObjectFromControl
        private void SetObjectFromControl()
        {

            objPerformHelper.objPerfrmnceBal.objSalObjects.ClientSelectedIndex = Cmb_SupplierName.SelectedIndex;
            objPerformHelper.objPerfrmnceBal.objSalObjects.ItemNo = (Cmb_ItemName.SelectedIndex != -1 ? Convert.ToInt16(Cmb_ItemName.SelectedValue.ToString()) : 0);
            objPerformHelper.objPerfrmnceBal.objSalObjects.QtyText = txtQuantity.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.ItemSelectedIndex = Cmb_ItemName.SelectedIndex;
            objPerformHelper.objPerfrmnceBal.objSalObjects.ItemDescription = Cmb_ItemName.SelectedIndex != -1 ? Cmb_ItemName.Text : "";
            objPerformHelper.objPerfrmnceBal.objSalObjects.ClientNoSelectedValue = Cmb_SupplierName.SelectedIndex != -1 ? Cmb_SupplierName.SelectedValue : 0;
            objPerformHelper.objPerfrmnceBal.objSalObjects.RemainingText = MTxt_Remaining.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText = MTxt_Price.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.StockText = MTxt_Stock.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.InvoiceText = txtInvoiceNo.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.SupplierName = Cmb_SupplierName.SelectedIndex != -1 ? Cmb_SupplierName.Text : "";
            objPerformHelper.objPerfrmnceBal.objSalObjects.ItemExpiryDate = (Cmb_PER_Date.Text != "") ? Convert.ToDateTime(Cmb_PER_Date.Text) : Convert.ToDateTime("1/1/1900");
            objPerformHelper.objPerfrmnceBal.objSalObjects.ValueChecked = rbnValue.Checked;
            objPerformHelper.objPerfrmnceBal.objSalObjects.PercentageChecked = rbnPercentage.Checked;
            objPerformHelper.objPerfrmnceBal.objSalObjects.DtpDate = Convert.ToDateTime(DTP_Date.Value);
            objPerformHelper.objPerfrmnceBal.objSalObjects.DtpPerformDate = Convert.ToDateTime(DTP_PER_ValidDate.Value);
            objPerformHelper.objPerfrmnceBal.objSalObjects.ClientID = Convert.ToInt16(Cmb_SupplierName.SelectedIndex != -1 ? Cmb_SupplierName.SelectedValue : 0);
            objPerformHelper.objPerfrmnceBal.objSalObjects.DgrBgColorValue = DgvPerInvoice.BackgroundColor.ToString();
            objPerformHelper.objPerfrmnceBal.objSalObjects.NotesText = MTxt_Note.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.GrdSelectedRowCount = DgvPerInvoice != null ? (DgvPerInvoice.Rows.Count > 0 ? DgvPerInvoice.SelectedRows.Count : 0) : 0;
            objPerformHelper.objPerfrmnceBal.objSalObjects.GrdSelectedItemID = DgvPerInvoice != null ? (DgvPerInvoice.Rows.Count > 0 ? (DgvPerInvoice.SelectedRows.Count > 0 ? Convert.ToInt16(DgvPerInvoice.SelectedRows[0].Cells["itemno"].Value) : 0) : 0) : 0;
            objPerformHelper.objPerfrmnceBal.objSalObjects.GrdSelectedDemandDate = DgvPerInvoice != null ? (DgvPerInvoice.Rows.Count > 0 ? (DgvPerInvoice.SelectedRows.Count > 0 ? Convert.ToDateTime(DgvPerInvoice.SelectedRows[0].Cells["Newexpr"].Value) : DateTime.MinValue) : DateTime.MinValue) : DateTime.MinValue;
            objPerformHelper.objPerfrmnceBal.objSalObjects.TotalText = MTxt_Total.Text == string.Empty ? "0.000" : Convert.ToDecimal(MTxt_Total.Text).ToString("#######0.000");
            objPerformHelper.objPerfrmnceBal.objSalObjects.NetText = txtNet.Text == string.Empty ? "0.000" : Convert.ToDecimal(txtNet.Text).ToString("#######0.000");
            objPerformHelper.objPerfrmnceBal.objSalObjects.DiscountText = MTxt_Discount.Text == string.Empty ? "0.000" : Convert.ToDecimal(MTxt_Discount.Text).ToString("#######0.000");
            objPerformHelper.objPerfrmnceBal.objSalObjects.BarcodeID = (cmbPackageQty.SelectedIndex != -1 && cmbPackageQty.SelectedValue.ToString() != "0" && cmbPackageQty.SelectedValue.ToString() != "" ? Convert.ToInt32(cmbPackageQty.SelectedValue) : 1);
            objPerformHelper.objPerfrmnceBal.objSalObjects.ItemNumber = Cmb_ItemNo.Text;
            objPerformHelper.objPerfrmnceBal.objSalObjects.user = GeneralFunction.UserName;

        }
        #endregion

        #region ClearTextFields
        private void ClearTextFields()
        {
            txtQuantity.Text = "";
            MTxt_Remaining.Text = "";
            MTxt_Price.Text = "";
            Cmb_PER_Date.Text = DateTime.Now.ToShortDateString();
            MTxt_Stock.Text = "0";
            MTxt_Box.Text = "1";
            cmbPackageQty.SelectedIndexChanged -= new System.EventHandler(this.cmbPackageQty_SelectedIndexChanged);
            cmbPackageQty.SelectedIndex = -1;
            cmbPackageQty.SelectedIndexChanged += new System.EventHandler(this.cmbPackageQty_SelectedIndexChanged);

        }
        #endregion

        #region SetIntialValues
        private void SetIntialValues()
        {
            Cmb_ItemNo.SelectedValue = Cmb_ItemName.SelectedValue;
            EnableDisableButton();
            txtQuantity.Text = "1";
            RTxt_Notes.Text = "";
            MTxt_Remaining.Text = "";
            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
        }
        #endregion

        #region SetBoxPieceValue
        private void SetBoxPieceValue()
        {
            MTxt_Remaining.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.RemainingText;
            MTxt_Price.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.PriceText;
            MTxt_Stock.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.StockText;
            MTxt_Box.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.PackageText;
            btnBox.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.BoxText;
        }
        #endregion

        #region GridClear
        private void GridClear()
        {
            objPerformHelper.lstGridDetails.Clear();
            //DgvPerInvoice.BackgroundColor = Color.NavajoWhite;  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            DgvPerInvoice.BackgroundColor = Color.WhiteSmoke;
            DgvPerInvoice.DefaultCellStyle.BackColor = Color.White;
            DgvPerInvoice.AutoGenerateColumns = false;
            DgvPerInvoice.DataSource = null;
            DgvPerInvoice.DataSource = objPerformHelper.lstGridDetails;

        }

        #endregion

        #region ClearAll
        public void ClearAll()
        {
            //this.Cmb_ItemName.SelectedIndexChanged -= new System.EventHandler(this.Cmb_ItemName_SelectedIndexChanged);
            DTP_Date.Value = DateTime.Now;
            //txtInvoiceNo.Text = "";
            Cmb_SupplierName.Text = "";
            Cmb_ItemName.Text = "";
            Cmb_SupplierNo.Text = "";
            Cmb_ItemNo.Text = "";
            //   Cmb_Category.SelectedIndexChanged -= new EventHandler(Cmb_Category_SelectedIndexChanged);
            // Cmb_Company.SelectedIndexChanged -= new EventHandler(Cmb_Company_SelectedIndexChanged);
            Cmb_Category.SelectedIndex = Cmb_Company.SelectedIndex = -1;
            Cmb_Category.Text = "";
            Cmb_Company.Text = "";
            //   Cmb_Company.SelectedIndexChanged += new EventHandler(Cmb_Company_SelectedIndexChanged);
            //   Cmb_Category.SelectedIndexChanged += new EventHandler(Cmb_Category_SelectedIndexChanged);
            DTP_PER_ValidDate.Value = DateTime.Now;
            Cmb_PER_Date.Text = DateTime.Now.ToShortDateString();
            MTxt_Price.Text = "";
            txtQuantity.Text = "";
            MTxt_Remaining.Text = "";

            chkPrintPerview.Checked = false;
            chkHideLogo.Checked = false;
            chkNote.Checked = false;
            MTxt_Note.Text = "";
            MTxt_Total.Text = "";
            txtQuantity.Text = "";
            MTxt_Remaining.Text = "";
            txtNet.Text = "";
            RTxt_Notes.Text = "";
            //this.Cmb_ItemName.SelectedIndexChanged += new System.EventHandler(this.Cmb_ItemName_SelectedIndexChanged);


        }
        #endregion

        #region AssignGridSource
        private void AssignGridSource()
        {
            objPerformHelper.SortGridList();
            BindingSource bs = new BindingSource();
            bs.DataSource = objPerformHelper.lstGridDetails;
            DgvPerInvoice.AutoGenerateColumns = false;
            DgvPerInvoice.DataSource = null;
            DgvPerInvoice.DataSource = bs;
            DgvPerInvoice.ClearSelection();
            DgvPerInvoice.Refresh();
        }
        #endregion

        #region SetTotal
        private void SetTotal()
        {
            //alter by thamil for net amount not saved
            objPerformHelper.GetSumofTotal();
            txtNet.Text = float.Parse(objPerformHelper.objPerfrmnceBal.objSalObjects.SumOfSubTotal.ToString()).ToString("####0.000");
           // txtNet.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NetText;
            MTxt_Discount.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.DiscountText;
            MTxt_Total.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.TotalText;
        }
        private void SetTotalFromDisc()
        {
            txtNet.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NetText;
            //  MTxt_Discount.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.DiscountText;
            MTxt_Total.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.TotalText;
        }
        #endregion

        #region DisplayInvoiceDetails
        private void DisplayInvoiceDetails()
        {
            try
            {
                GridClear();
                ClearAll();
                objPerformHelper.objPerfrmnceBal.objSalObjects.InvoiceText = txtInvoiceNo.Text;
                objPerformHelper.objPerfrmnceBal.objSalObjects.InvoiceType = 2;
                objPerformHelper.DisplayInvoiceDetHelper();
                Txt_NewInvoiceNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NewYrInvoiceText;
                AssignGridSource();
                if (objPerformHelper.lstOrderInvDetails.Count > 0)
                {
                    Cmb_SupplierNo.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.ClientID.ToString();
                    Cmb_SupplierName.SelectedValue = objPerformHelper.objPerfrmnceBal.objSalObjects.ClientID;
                    //Cmb_SupplierName.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.SupplierName;
                    Cmb_PER_Date.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.ExpiryDateText;
                    DTP_PER_ValidDate.Value = objPerformHelper.objPerfrmnceBal.objSalObjects.DtpPerformDate;
                    if (objPerformHelper.objPerfrmnceBal.objSalObjects.Status == Convert.ToInt16(SalesInvoiceType.ClosedInvoice))
                    {
                        DgvPerInvoice.BackgroundColor = Color.Gray;
                        DgvPerInvoice.DefaultCellStyle.BackColor = Color.Gainsboro;
                        DTP_Date.Value = Convert.ToDateTime(objPerformHelper.objPerfrmnceBal.objSalObjects.Time);
                        objPerformHelper.Modifydate = Convert.ToDateTime(objPerformHelper.objPerfrmnceBal.objSalObjects.Time);
                        rbnValue.Enabled = rbnPercentage.Enabled = false;
                    }
                    else
                    {
                        DTP_Date.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        objPerformHelper.Modifydate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        rbnValue.Enabled = rbnPercentage.Enabled = true;
                        PerformaOptionSetting();
                    }

                    MTxt_Total.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.TotalText;
                    txtNet.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.NetText;
                    MTxt_Discount.Text = objPerformHelper.objPerfrmnceBal.objSalObjects.DiscountText;
                    rbnValue.Checked = objPerformHelper.objPerfrmnceBal.objSalObjects.discounttype == Convert.ToInt16(SalesDiscountType.Value) ? true : false;
                    rbnPercentage.Checked = objPerformHelper.objPerfrmnceBal.objSalObjects.discounttype == Convert.ToInt16(SalesDiscountType.Percentage) ? true : false;
                }
                else
                {
                    MTxt_Discount.Text = "0.000";
                    //DgvPerInvoice.BackgroundColor = Color.NavajoWhite;  ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    DgvPerInvoice.BackgroundColor = Color.WhiteSmoke;
                    DgvPerInvoice.DefaultCellStyle.BackColor = Color.White;
                    rbnValue.Enabled = rbnPercentage.Enabled = true;

                }
                DgvPerInvoice.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region PerformaOptionSetting
        public void PerformaOptionSetting()
        {
            Cmb_PER_Date.Enabled = (GeneralOptionSetting.FlagSale_HideExpiryFiled.Trim() == "N" ? true : false);
            MTxt_Discount.Enabled = rbnValue.Enabled = rbnPercentage.Enabled = (GeneralOptionSetting.FlagDisableDiscountFiled != "Y" ? true : false);
        }

        #endregion

        #region DiscountCalculation
        private void DiscountCalculation()
        {
            SetObjectFromControl();
            objPerformHelper.DiscountOne();
            objPerformHelper.DiscountTwo();
            AssignGridSource();
            SetTotalFromDisc();
        }
        #endregion

        #region UserLimitation
        void UserLimitation()
        {
            Cmb_ItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = UserScreenLimidations.Print ? true : false;
            btnFindInvoice.Enabled = UserScreenLimidations.FindSaleInvoice ? true : false;
            btnReturnItem.Enabled = UserScreenLimidations.SaleReturnInvoice ? true : false;
            btnBalanceSheet.Enabled = UserScreenLimidations.BalanceSheet ? true : false;
            btnModifyInvoice.Enabled = UserScreenLimidations.ModifyInvoice ? true : UserScreenLimidations.ModifyTodayInvoice ? true : false;
            Btn_Next.Visible = Btn_Previous.Visible = Btn_Start.Visible = Btn_Last.Visible = UserScreenLimidations.InvoiceNavigation ? true : false;
            txtInvoiceNo.ReadOnly = (UserScreenLimidations.InvoiceNavigation) ? false : true;
            txtInvoiceNo.BackColor = Color.White;
            MTxt_Discount.Enabled = (UserScreenLimidations.DiscountAmt) ? true : false;
            rbnPercentage.Enabled = (UserScreenLimidations.DiscountAmt) ? true : false;
            rbnValue.Enabled = (UserScreenLimidations.DiscountAmt) ? true : false;

            lblExpiryDate.Visible = (GeneralOptionSetting.FlagSale_HideExpiryFiled == "Y") ? false : true;
            Cmb_PER_Date.Visible = (GeneralOptionSetting.FlagSale_HideExpiryFiled == "Y") ? false : true;
            DgvPerInvoice.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            DgvPerInvoice.Columns["ItemExpiry"].Visible = (GeneralOptionSetting.FlagSale_HideExpiryFiled == "Y") ? false : true; //This added to show expiry as empty when comes in 1900/01/01. Done By: Manoj On June-25

            //  MTxt_Box.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;//Commente on 19-Apr-14 for Multiple PackageQty for One Item
            cmbPackageQty.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            lblPackage.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            DgvPerInvoice.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            btnBox.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            DgvPerInvoice.Columns["in_time"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
            btnItemInfo.Enabled = UserScreenLimidations.ItemInfo;
            MTxt_Total.Visible = lblTotal.Visible = MTxt_Discount.Visible = lblDiscount.Visible = txtNet.Visible = lblNet.Visible = UserScreenLimidations.InvTotalFields;
            //below Added on 28-Oct-2014
            if (UserScreenLimidations.InvTotalFields)
            {
                MTxt_Total.Visible = lblTotal.Visible = UserScreenLimidations.SubTotalField;
                txtNet.Visible = lblNet.Visible = UserScreenLimidations.TotalField;
            }

        }
        #endregion

        #region blinkTextbox
        private void blinkTextbox(object sender, EventArgs e)
        {

            GeneralFunction.BlinkText(EventArgs.Empty, RTxt_Notes);
        }
        #endregion

        #region AssignClientDataSource
        private void AssignClientDataSource()
        {
            objPerformHelper.LoadClientDetails();
            Cmb_SupplierName.DisplayMember = "Name";
            Cmb_SupplierName.ValueMember = "AgentId";

            Cmb_SupplierName.DataSource = objPerformHelper.lstClientList;
            Cmb_SupplierName.SelectedIndex = -1;

            Cmb_SupplierNo.DisplayMember = "AgentId";
            Cmb_SupplierNo.ValueMember = "Name";
            Cmb_SupplierNo.DataSource = objPerformHelper.lstClientList;
            Cmb_SupplierNo.SelectedIndex = -1;
        }
        #endregion

        #endregion

        #region Barcode
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "pos_screen", "txtBarcode_KeyUp");
            }
        }
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode") return;

        //    if (ScanValue == string.Empty || ScanValue.Length == 0)
        //    {
        //        //Enable to Timecheck
        //        ScanTimingCheck = true;
        //        ScanLetterStartTime = DateTime.Now;
        //        ScanValue = ScanValue + e.KeyChar.ToString();
        //        return;
        //    }
        //    ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //    if (ScanTimingCheck && ScanValue.Length < 7)
        //    {
        //        //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //        if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //        if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            KeyboardmaxCount = KeyboardmaxCount + 1;
        //        }
        //        else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //        }
        //        else
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //    }
        //    if (ScanValue.Length == 6)
        //    {
        //        lastFocusedControl = this.ActiveControl;
        //        if (lastFocusedControl != null)
        //        { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

        //        txtBarcode.Focus();
        //        //e.Handled = true;
        //    }
        //    //Cal Event Again
        //    base.OnKeyPress(e);
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (this.ActiveControl.Name == "txtBarcode") return;

                if (ScanValue == string.Empty || ScanValue.Length == 0)
                {
                    //Enable to Timecheck
                    ScanTimingCheck = true;
                    ScanLetterStartTime = DateTime.Now;
                    ScanValue = ScanValue + e.KeyChar.ToString();
                    KeyboardmaxCount = 0;
                    return;
                }
                ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
                if (ScanTimingCheck && ScanValue.Length < 7)
                {
                    //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
                    if (KeyboardmaxCount > 4 && ScanValue.Length > 1)
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                    //if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
                    if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds < GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                        KeyboardmaxCount = KeyboardmaxCount + 1;
                    }
                    else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                    }
                    else
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                }
                if (ScanValue.Length == 6)
                {
                    lastFocusedControl = this.ActiveControl;
                    if (lastFocusedControl != null)
                    { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

                    txtBarcode.Focus();
                    //e.Handled = true;
                }
                //Cal Event Again
                base.OnKeyPress(e);

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " OnKeyPress Event");
            }
        }

        //private void tmrBarcode_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ScannerCount += 1;
        //        if (lastFocusedControl != null)
        //        {
        //            lastFocusedControl.Text = lastfocusedvalue;
        //            lastFocusedControl = null;
        //        }
        //        if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
        //        {
        //            string barcode = Convert.ToString(txtBarcode.Text);
        //            if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                Cmb_ItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                cmbPackageQty.Text = dtBarcode.Rows[0]["PackageQty"].ToString();
        //                ClearBarcodeValues();
        //            }
        //            else
        //            {

        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "Performa Invoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        ////FillDetails();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                    }
        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "Performa Invoice");
        //                    ClearBarcodeValues();
        //                }
        //            }

        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //        }
        //        KeyboardmaxCount = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        //GeneralFunction.ErrMsg(this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
        //    }

        //}


        private void tmrBarcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null)
                {
                    lastFocusedControl.Text = lastfocusedvalue;
                    lastFocusedControl = null;
                }
                if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
                {


                    tmrBarcode.Enabled = false;
                    string barcode = Convert.ToString(txtBarcode.Text);
                    //if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
                    //{
                    //    barcode = ScanValue + barcode;
                    //}

                    if (barcode.Length < 12)
                    {
                        barcode = ScanValue + barcode;
                    }

                    //*********Commented for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());


                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    Cmb_ItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    cmbPackageQty.Text = dtBarcode.Rows[0]["PackageQty"].ToString();
                    //    ClearBarcodeValues();
                    //}
                    //*********************************************************************************************

                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            Cmb_ItemName.Text = row1["ItemName"].ToString();
                            cmbPackageQty.Text = row1["PackageQty"].ToString();
                            ClearBarcodeValues();
                        }
                    }
                    //*********************************************************************************************
                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "Performa Invoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                ////FillDetails();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                LoadNewItems();
                            }
                            ClearBarcodeValues();
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "Performa Invoice");
                            ClearBarcodeValues();
                        }
                    }

                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
                }
                KeyboardmaxCount = 0;
            }
            catch (Exception ex)
            {
                tmrBarcode.Enabled = false;
                ClearBarcodeValues();
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
                throw ex;
            }
        }

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
        }

        private void LoadNewItems()
        {
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }

        #endregion



        #region KeyDown Events

        private void proforma_invoce_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
                if (e.KeyCode == Keys.F11 && btnItemInfo.Enabled)
                {
                    btnItemInfo_Click(sender, e);
                }

                else if (e.KeyCode == Keys.F4 && btnNewInvoice.Enabled && (!e.Alt))
                {
                    this.InvokeOnClick(btnNewInvoice, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F3 && btnAddItem.Enabled)
                {
                    this.InvokeOnClick(btnAddItem, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F2 && btnDeleteItem.Enabled)
                {
                    this.InvokeOnClick(btnDeleteItem, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F5 && btnCloseInvoice.Enabled)
                {
                    this.InvokeOnClick(btnCloseInvoice, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F9 && btnBox.Enabled)
                {
                    btnBox_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6 && btnPrint.Enabled)
                {
                    this.InvokeOnClick(btnPrint, EventArgs.Empty);
                }
                else { }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Performa Invoice", "proforma_invoce_KeyPress");
            }
        }
        #endregion
        bool isFirst = false;
        string appval = "";
        private void Cmb_ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                if (((ComboBox)sender).Name == "Cmb_ItemName")
                {
                    //Cmb_ItemName.AutoCompleteMode = AutoCompleteMode.None;
                    //txtQuantity.SelectAll();
                    //txtQuantity.Focus();
                }
                else if (((ComboBox)sender).Name == "Cmb_SupplierName")
                    Cmb_ItemName.Focus();
                else if (((ComboBox)sender).Name == "Cmb_SupplierNo")
                    Cmb_SupplierName.Focus();
            }
            //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //      (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //      && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //      && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //      && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
            //{
            //    if (((ComboBox)sender).DroppedDown == true)
            //        ((ComboBox)sender).DroppedDown = false;
            //    if (((ComboBox)sender).Name == "Cmb_ItemName" && Cmb_ItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            //    {
            //        Cmb_ItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        Cmb_ItemName.SelectedText = ((char)e.KeyValue).ToString();
            //        Cmb_ItemName.DroppedDown = true;
            //        isFirst = true;
            //        appval = ((char)e.KeyValue).ToString();
            //    }
            //    else
            //    {
            //        Cmb_ItemName.DroppedDown = false;
            //        if (isFirst)
            //        {
            //            Cmb_ItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
            //            isFirst = false;
            //        }

            //    }
            //}//this codition modified to change the DropDown By Meena.R on 14Aug2014
        }

        private void MTxt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtQuantity.Focus();
                txtQuantity.SelectAll();
            }
            else if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 13) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Cmb_PER_Date.Visible == true)
                {
                    Cmb_PER_Date.Focus();
                }
                else
                {
                    InvokeOnClick(btnAddItem, EventArgs.Empty);
                }
            }
            else if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8) && (e.KeyChar != 46))
                e.Handled = true;

        }

        private void Cmb_PER_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                InvokeOnClick(btnAddItem, EventArgs.Empty);
            }
        }
        //private void cmbItemName_DropDown(object sender, EventArgs e)
        //{
        //    if (((ComboBox)(sender)).DroppedDown == false)
        //    {
        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //        //cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
        //    }
        //}

        //private void cmbItemName_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    //cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    switch (((ComboBox)sender).Name)
        //    {
        //        case "Cmb_ItemName":
        //            Cmb_ItemName_SelectedIndexChanged(Cmb_ItemName, new EventArgs());
        //            break;
        //    }
        //}
        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
                for (int i = 0; i <= this.tableLayoutPanel2.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel2.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel2.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
        }
        public void SetRowColor(string ComboItemName)
        {
            for (int i = 0; i < DgvPerInvoice.Rows.Count; i++)
            {
                DgvPerInvoice.Rows[i].Selected = false;
                DgvPerInvoice.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (DgvPerInvoice.Rows[i].Cells[2].Value.ToString() == ComboItemName)
                    DgvPerInvoice.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
            }

        }

        private void Cmb_ItemName_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //    txtBarcode.Focus();
        }

        private void Cmb_ItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Cmb_ItemName.SelectedIndex > -1)
                {
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
            }
        }

        private void Cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Category.SelectedIndex != -1 && Cmb_Category.Text != string.Empty)
                {
                    objPerformHelper.objPerfrmnceBal.objSalObjects.CategoryNo = Convert.ToInt32(Cmb_Category.SelectedValue);
                    List<ItemCardObjectClass> filter = objPerformHelper.FilterItemBasedonCategory();
                    Cmb_ItemName.SelectedIndexChanged -= new EventHandler(Cmb_ItemName_SelectedIndexChanged);
                    Cmb_ItemNo.SelectedIndexChanged -= new EventHandler(Cmb_ItemNo_SelectedIndexChanged);

                    Cmb_ItemName.DisplayMember = "Items";
                    Cmb_ItemName.ValueMember = "ItemId";

                    Cmb_ItemName.DataSource = filter;
                    Cmb_ItemName.SelectedIndex = -1;

                    Cmb_ItemNo.DisplayMember = "ItemNumber";
                    Cmb_ItemNo.ValueMember = "ItemId";

                    Cmb_ItemNo.DataSource = filter;
                    Cmb_ItemNo.SelectedIndex = -1;
                    Cmb_ItemName.SelectedIndexChanged += new EventHandler(Cmb_ItemName_SelectedIndexChanged);
                    Cmb_ItemNo.SelectedIndexChanged += new EventHandler(Cmb_ItemNo_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Performa Invoice", "Cmb_Category_SelectedIndexChanged");

            }
        }

        private void Cmb_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Company.SelectedIndex != -1 && Cmb_Company.Text != string.Empty)
                {
                    objPerformHelper.objPerfrmnceBal.objSalObjects.CompanyNo = Convert.ToInt32(Cmb_Company.SelectedValue);
                    List<ItemCardObjectClass> filter = objPerformHelper.FilterItemBasedonCompany();
                    Cmb_ItemName.SelectedIndexChanged -= new EventHandler(Cmb_ItemName_SelectedIndexChanged);
                    Cmb_ItemNo.SelectedIndexChanged -= new EventHandler(Cmb_ItemNo_SelectedIndexChanged);

                    Cmb_ItemName.DisplayMember = "Items";
                    Cmb_ItemName.ValueMember = "ItemId";

                    Cmb_ItemName.DataSource = filter;
                    Cmb_ItemName.SelectedIndex = -1;

                    Cmb_ItemNo.DisplayMember = "ItemNumber";
                    Cmb_ItemNo.ValueMember = "ItemId";

                    Cmb_ItemNo.DataSource = filter;
                    Cmb_ItemNo.SelectedIndex = -1;
                    Cmb_ItemName.SelectedIndexChanged += new EventHandler(Cmb_ItemName_SelectedIndexChanged);
                    Cmb_ItemNo.SelectedIndexChanged += new EventHandler(Cmb_ItemNo_SelectedIndexChanged);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Performa Invoice", "Cmb_Company_SelectedIndexChanged");

            }
        }

        private void Performance_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPerformHelper.lstOrderInvDetails = null;
            objPerformHelper.lstGridDetails = null;
            objPerformHelper.lstClientList = null;
            objPerformHelper.lstItemDetails = null;
            objPerformHelper.lstItemExpirydates = null;
            this.Dispose();
        }

        private void Cmb_Category_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == "Cmb_Category")
            {
                if ((Cmb_Category.Text.Trim() != string.Empty && Cmb_Category.SelectedIndex == -1) || Cmb_Category.Text == string.Empty)
                {
                    Cmb_Category.SelectedValue = 1001;
                }
            }
            else
            {
                if ((Cmb_Company.Text.Trim() != string.Empty && Cmb_Company.SelectedIndex == -1) || Cmb_Company.Text == string.Empty)
                {
                    Cmb_Company.SelectedValue = 1001;
                }
            }
        }

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
