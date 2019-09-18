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
using System.IO;
using AlmaqarPOS.English;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class POS_Screen : Form, IDisposable
    {

        #region Declaration
        PosScreenHelper objPosHelper;
        SalesInvoiceHelper objSaleInvoiceHelper;
        PosShortcutHelper objPosShortcutHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, isfromitem = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        public string FindPosInvoiceNo = "";
        public int CurrInvNo = 0;
        public int NewInvNo = 0;
        private bool KeyUpDown = false, isfrominsert = false, isfirst = false;
        DataTable dtallBarcode;
        DataTable dtPOSItems;
        internal int ButtonClick = 0;
        public int CurrentRowIndex = 0;
        public static double posTotal = 0;
        public static string clientClosedPos = "";
        public static string selectedPaymentType = "";
        public static bool isPaymentMethodOn = false;
        public static decimal PosItemPriceVal = 0;
        DataTable CommondtItem;
        //List<ItemCardObjectClass> updatedItem = new List<ItemCardObjectClass>();
        #endregion

        #region Constructor
        public POS_Screen()
        {
            //GeneralFunction.Trace("POS_Screen Start");
            objPosHelper = new PosScreenHelper();
            objSaleInvoiceHelper = new SalesInvoiceHelper();
            objPosShortcutHelper = new PosShortcutHelper();
            InitializeComponent();
            SetLanguage();
            setFont();
            //GeneralFunction.Trace("POS_Screen End");
        }
        #endregion

        #region Events

        #region Form Load
        private void POS_Screen_Load(object sender, EventArgs e)
        {
            try
            {
                Cmb_Client.MatchingMethod = StringMatchingMethod.UseRegexs;
                Cmb_Item.MatchingMethod = StringMatchingMethod.UseRegexs;

                //CommondtItem = objSaleInvoiceHelper.GetSalesItemDetails();
                //LoadItems();

                //GeneralFunction.Trace("POS_Screen_Load Start");
                //***********Date Format Check by Seenivasan on 13-Oct-2014************************//      
                Dtp_Pos.Format = DateTimePickerFormat.Custom;
                Dtp_Pos.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                if (GeneralOptionSetting.FlagchkActivatePaymentType == "Y")
                {
                    chkPaymentsTypes.Checked = true;
                    chkPaymentsTypes.Visible = true;
                    lblPaymentCharges.Visible = true;
                    txtPaymentCharges.Visible = true;
                }
                else
                {
                    chkPaymentsTypes.Checked = false;
                    chkPaymentsTypes.Visible = false;
                    lblPaymentCharges.Visible = false;
                    txtPaymentCharges.Visible = false;
                }

                HideControls();
                //objPosHelper.GetAllItemDetails(0);
                objPosHelper.GetPOSItems();
                AssignToComboBox();
                BindDetailsToButton();
                objPosHelper.GetCurrentYear();
                if (GeneralOptionSetting.FlagchkActivatePaymentType == "Y")
                    chkPaymentsTypes.Checked = true;
                else chkPaymentsTypes.Checked = false;

                if (FindPosInvoiceNo != "")
                {
                    Txt_InvoiceNo.Text = FindPosInvoiceNo;
                    FillGrid();
                }
                else
                {
                    SetMaxSaleID();
                }
                //------------This is added to new invoice should not be opened immediately once Closed when already we have new
                if (Txt_InvoiceNo.Text != string.Empty)
                {
                    CurrInvNo = NewInvNo = Convert.ToInt32(Txt_InvoiceNo.Text.ToString());
                }
                // Active User Handling 15-Feb-2019
                ActiveUserGetAndUpdate();
                //---------------
                //FillGrid();
                // List<SaleObject> lstCurrentYear = objSaleInvoiceHelper.GetCurrentYearHelper();
                chkPrintpreview.Checked = GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y";
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = 0;//Added on 22-Apr-14
                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = 0;//Added on 22-Apr-14
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan

                Cmb_Item.SelectAll();
                Cmb_Item.Focus();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "POS_Screen_Load");
            }
            finally
            {
                //GeneralFunction.Trace("POS_Screen_Load End");
            }

        }


        #endregion

        #region Button Click

        #region btnNew_Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTextFeilds();
                ClearInputs();
                objPosHelper.lstGridItems.Clear();
                AssignGridSource();
                //Dg_Sales.BackgroundColor = Color.NavajoWhite; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                Dg_Sales.BackgroundColor = Color.WhiteSmoke; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black;
                objPosHelper.NewbtnYearInvoice();
                Txt_InvoiceNo.Text = objPosHelper.InvoiceID[0].ToString();
                //------------This is added to new invoice should not be opened immediately once Closed when already we have new
                if (Txt_InvoiceNo.Text != string.Empty)
                {
                    CurrInvNo = NewInvNo = Convert.ToInt32(Txt_InvoiceNo.Text.ToString());
                }
                //---------------------
                Txt_NewInvoiceNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.NewInvoiceNoText = "P" + objPosHelper.InvoiceID[2].ToString();
                Dtp_Pos.Value = DateTime.Now;
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = objPosHelper.InvoiceID[0];
                SetObjectFromControl();
                objPosHelper.GetOrderNoHelper();
                Lbl_OrderNo.Text = objPosHelper.OrderNo.ToString();
                if (GeneralOptionSetting.FlagResetPOSOrder == "Y")//This is implemented on 03Mar2015
                {
                    if (Convert.ToInt32(GeneralOptionSetting.FlagPOSOrderResetCount) > 0)
                    {
                        if (Dtp_Pos.Value.Date == DateTime.Now.Date)
                        {
                            if (objPosHelper.OrderNo > Convert.ToInt32(GeneralOptionSetting.FlagPOSOrderResetCount))
                            {
                                objPosHelper.OrderNo = 1;
                                Lbl_OrderNo.Text = "1";
                            }
                        }
                    }
                }
                objPosHelper.AssignInvoice(Convert.ToInt16(SalesInvoiceType.NormalInvoice));
                objPosHelper.SaveSaleInvoiceHelper();
                // Active User Handling 15-Feb-2019
                ActiveUserGetAndUpdate();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnNew_Click");
            }
        }
        #endregion


        void LoadItems()
        {
            Cmb_Item.SelectedIndexChanged -= new EventHandler(this.Cmb_Item_SelectedIndexChanged);//added on 11/12/2014
            cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            //if (GeneralOptionSetting.FlagShowNonStockItem != "Y") commented on 08jan2015
            //{
            //    //cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(a => a.stock > 0).OrderBy(n => n.ItemName).ToList();
            //    //cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty && i.stock > 0).ToList();
            //}
            //else
            //{
            //    cmbItem.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].OrderBy(n => n.ItemName).ToList();
            //    cmbItemNo.DataSource = objSaleInvoiceHelper.dicLoad["ItemIDName"].Where(i => i.ItemNumber != string.Empty).ToList();
            //}
            //cmbItem.DisplayMember = "ItemName";
            // cmbItem.ValueMember = "ItemsId";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemsId";
            // cmbItem.DataSource = CommondtItem;
            DataView dvi = new DataView(CommondtItem);
            dvi.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dvi.ToTable();
            this.Invoke(new MethodInvoker(delegate
            {
                // cmbItem.SelectedIndex = -1;
                cmbItemNo.SelectedIndex = -1;
            }));

            Cmb_Item.SelectedIndexChanged += new EventHandler(this.Cmb_Item_SelectedIndexChanged);
            cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);


            //GC.Collect();
        }


        #region Navigation
        #region Invoice Navigation
        private void btnNavigation_Click(object sender, EventArgs e)
        {
            try
            {

                objPosHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                objPosHelper.objPOSScreenBal.objPOSObject.SaleId = Convert.ToInt64(Txt_InvoiceNo.Text);
                objPosHelper.NavigationEvent();
                Txt_InvoiceNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.SaleId.ToString();
                //------------This is added to new invoice should not be opened immediately once Closed when already we have new
                if (Txt_InvoiceNo.Text != string.Empty)
                {
                    CurrInvNo = Convert.ToInt32(Txt_InvoiceNo.Text.ToString());
                }
                //------------------------
                FillGrid();
                // Active User Handling 15-Feb-2019
                ActiveUserGetAndUpdate();

                ClearFields();//Added on 16-May-2014
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnNavigation_Click");
            }

        }
        #endregion

        #region Tab Navigation

        #region Btn_Previous1_Click
        private void Btn_Previous1_Click(object sender, EventArgs e)
        {
            try
            {
                int Tabindex;
                Tabindex = Tab_Buttons.SelectedIndex;
                if (Tabindex != 0) Tab_Buttons.SelectedIndex = Tabindex - 1;
                if (Tabindex <= 0) Btn_Previous.Enabled = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Previous1_Click");
            }
        }
        #endregion

        #region Btn_Next1_Click
        private void Btn_Next1_Click(object sender, EventArgs e)
        {
            try
            {
                int Tabindex;
                Tabindex = Tab_Buttons.SelectedIndex;
                if (Tabindex != 7) Tab_Buttons.SelectedIndex = Tabindex + 1;
                if ((Tabindex + 1) >= Tab_Buttons.TabCount) Btn_Next1.Enabled = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Next1_Click");
            }
        }
        #endregion

        #endregion

        #region Grid Navigation

        #region Btn_Up_Click
        private void Btn_Up_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dg_Sales.RowCount <= 0) return;
                int rowindex = Dg_Sales.CurrentRow.Index;
                CurrencyManager cm = (CurrencyManager)this.BindingContext[Dg_Sales.DataSource, Dg_Sales.DataMember];
                if (rowindex != 0 && Dg_Sales.SelectedRows.Count != 0) cm.Position = rowindex - 1;
                else cm.Position = rowindex;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Up_Click");
            }
        }
        #endregion

        #region Btn_Down_Click
        private void Btn_Down_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dg_Sales.RowCount <= 0) return;
                int rowindex = Dg_Sales.CurrentRow.Index;
                CurrencyManager cm = (CurrencyManager)this.BindingContext[Dg_Sales.DataSource, Dg_Sales.DataMember];
                if (rowindex != Dg_Sales.RowCount - 1)
                {
                    cm.Position = rowindex + 1;
                }
                else if (Dg_Sales.SelectedRows.Count == 0 && Dg_Sales.RowCount != 0) cm.Position = 0;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Down_Click");
            }
        }
        #endregion

        #endregion

        #endregion

        #region btnClear_Click
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                int index;
                if (Txt_Qty.Enabled)
                {
                    index = Txt_Qty.Text.Length;
                    Txt_Qty.Text = (Txt_Qty.Text != string.Empty) ? Txt_Qty.Text.Remove(index - 1) : Txt_Qty.Text;
                }
                else
                {
                    index = Txt_Paid.Text.Length;
                    Txt_Paid.Text = (Txt_Paid.Text != string.Empty) ? Txt_Paid.Text.Remove(index - 1) : Txt_Paid.Text;
                    if (Txt_Paid.Text != string.Empty) Txt_Refund.Text = Convert.ToString((Convert.ToDecimal(Txt_Total.Text) - Convert.ToDecimal(Txt_Paid.Text)));
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnClear_Click");
            }

        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return;
                }

                SetObjectFromControl();
                double total = 0;
                double charges = 0;
                if (chkPaymentsTypes.Checked == true)
                {
                    if (Dg_Sales.BackgroundColor != Color.Gray)
                    {

                        charges = string.IsNullOrEmpty(txtPaymentCharges.Text) ? 0 : Convert.ToDouble(txtPaymentCharges.Text);
                        total = Txt_Total.Text == null ? 0 : Convert.ToDouble(Txt_Total.Text);
                        total = total - charges;
                        Txt_Total.Text = total.ToString("####0.000");
                        isPaymentMethodOn = true;
                        PaymentTypes form = new PaymentTypes();
                        // add these properties on 26-Feb-2019
                        form.NewYearInvoiceNo = objPosHelper.objPOSScreenBal.objPOSObject.NewInvoiceNoText;
                        form.InvoiceNoText = objPosHelper.objPOSScreenBal.objPOSObject.SaleId;
                        form.ClientText = objPosHelper.objPOSScreenBal.objPOSObject.CmbClientText; ;
                        if (objPosHelper.objPOSScreenBal.objPOSObject.ClientID.ToString() != Convert.ToInt16(CommonHelper.CashClientID.ID).ToString())
                            form.Value = Convert.ToDecimal((objPosHelper.objPOSScreenBal.objPOSObject.PaidText != string.Empty) ? objPosHelper.objPOSScreenBal.objPOSObject.PaidText : "0.000").ToString("####0.000");
                        else
                            form.Value = Convert.ToDecimal((objPosHelper.objPOSScreenBal.objPOSObject.TotalText != string.Empty) ? objPosHelper.objPOSScreenBal.objPOSObject.TotalText : "0.000").ToString("####0.000");
                        form.NetAmt = (objPosHelper.objPOSScreenBal.objPOSObject.TotalText != string.Empty) ? objPosHelper.objPOSScreenBal.objPOSObject.TotalText : "0.000";
                        //
                        clientClosedPos = Cmb_Client.SelectedValue.ToString();
                        posTotal = total;
                        PaymentTypes.isFromSales = false;
                        PaymentTypes.receiptDesc = Txt_NewInvoiceNo.Text;
                        form.ShowDialog();
                        if (PaymentTypes.isCheckSave == false)
                        {
                            txtPaymentCharges.Text = "0.000";
                            return;
                        }
                        else
                        {
                            txtPaymentCharges.Text = posTotal.ToString("####0.000");
                            charges = string.IsNullOrEmpty(txtPaymentCharges.Text) ? 0 : Convert.ToDouble(txtPaymentCharges.Text);
                        }
                    }
                }
                else
                    isPaymentMethodOn = false;

                SetObjectFromControl();
                if (PaymentTypes.isCheckSave)
                {
                    total += charges;
                    Txt_Total.Text = total.ToString("####0.000");
                }
                //Dg_Sales.Rows[0].Cells["paymentCharges"] = txtPaymentCharges;
                objPosHelper.CloseSale(Dg_Sales);
                // Added on 13-Mar-2019 By T
                if (GeneralOptionSetting.FlagEnableNetworkSaleControl == "Y")
                {
                    Random random = new Random();
                    int randomNumber = random.Next(500, 5000);
                    Thread.Sleep(randomNumber);
                }
                //objPosHelper.objPOSScreenBal.objPOSObject.SaleId = Convert.ToInt64(Txt_InvoiceNo.Text);
                objPosHelper.IsNotPrintKitchenReceipt = objPosHelper.objPOSScreenBal.objPOSObject.ShortCut == 0 ? false : true;
                objPosHelper.objPOSScreenBal.objPOSObject.ShortCut = 0;
                objPosHelper.UpdateSaleIDForTableHelper();
                // Active User Handling 15-Feb-2019
                objPosHelper.GetActiveUserHelper();
                if (objPosHelper.objPOSScreenBal.objPOSObject.DialogueResultOK)
                {
                    Txt_Paid.Text = GeneralFunction.Paid.ToString("####0.000");
                    Txt_Refund.Text = GeneralFunction.Refund.ToString("####0.000");
                    Btn_Receipt.Enabled = objPosHelper.objPOSScreenBal.objPOSObject.BtnReceiptEnabled;
                    if (objPosHelper.PrintReceipt)
                    {
                        if (chkPrintpreview.Checked)
                        {
                            btnPrint_Click(sender, e);
                        }
                        CashDrawer objcashdraw = new CashDrawer();
                        objcashdraw.OpenCashDrawer();
                    }
                    if (GeneralOptionSetting.FlagOpenInvioceAfterClosing == "Y" && CurrInvNo >= NewInvNo)
                    {
                        btnNew_Click(sender, e);
                    }
                    GeneralFunction.Paid = 0;
                    GeneralFunction.Refund = 0;
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnClose_Click");
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return;
                }
                SetObjectFromControl();
                objPosHelper.DeleteSale(Dg_Sales);
                // Dg_Sales.Rows.RemoveAt(Dg_Sales.CurrentRow.Index);
                AssignGridSource();
                if (objPosHelper.objPOSScreenBal.objPOSObject.EnableButton)
                {
                    EnableButton();
                }
                AssignTaxTotal();
                BindDetailsToButton();
                FocusLastRow();
                Txt_Price.Text = "0.000";
                //updatedItem = objPosHelper.GetItemDetailsHelper();
                dtPOSItems = objPosHelper.NewGetItemDetailsHelper();

                //Thread ItemRefresh = new Thread(RefreshItem);
                //ItemRefresh.Start();
                RefreshItem();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnDelete_Click");
            }
        }
        #endregion

        #region Btn_Adjust_Click
        private void Btn_Adjust_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return;
                }
                SetObjectFromControl();
                objPosHelper.AdjustSale(Dg_Sales);
                AssignTaxTotal();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Adjust_Click");
            }

        }
        #endregion

        #region BtnShortCuts_Click
        private void BtnShortCuts_Click(object sender, EventArgs e)
        {
            try
            {
                //Txt_Price.Text = "10000";
                Control ctr = (Control)sender;

                objPosHelper.IsFromItemSelection = false; //Added on 17-June-2014
                if (ctr.BackColor == Color.Red) return;
                int Seleectedbuttonid = objPosHelper.GetButtonItemId(ctr.Text);
                if (objPosHelper.ShowPricePopup(0, Seleectedbuttonid) && PosItemPriceVal == 0)
                {
                    PosItemPrice showDial = new PosItemPrice();
                    var ActionResult = showDial.ShowDialog();
                    if (ActionResult != null)
                    {
                        if (ActionResult.ToString() != "OK")
                        {
                            return;
                        }
                    }
                    if (PosItemPriceVal < 1)
                    {
                        PosItemPriceVal = -1;
                    }

                }
                SetObjectFromControl();
                if (ctr.Name.Length >= 7)
                {
                    bool isexist = false;
                    int CurrentRowItemID = Convert.ToInt32(Dg_Sales.CurrentRow.Cells["ItemID"].Value.ToString());
                    int buttonid = Seleectedbuttonid;//objPosHelper.GetButtonItemId(ctr.Text);
                    int CurrentItemInsertionNo = Convert.ToInt32(Dg_Sales.CurrentRow.Cells["ItemInsertionNo"].Value.ToString());
                    if (CurrentRowItemID == 0)
                    {
                        GeneralFunction.Information("SelectItemRow", "POS Screen");
                        return;
                    }
                    for (int i = 0; i < Dg_Sales.Rows.Count; i++)
                    {
                        int RowButtonItemID = Convert.ToInt32(Dg_Sales.Rows[i].Cells["ButtonItemID"].Value.ToString());
                        int RowButtonID = Convert.ToInt32(Dg_Sales.Rows[i].Cells["ButtonID"].Value.ToString());
                        int ItemInsertionNo = Convert.ToInt32(Dg_Sales.Rows[i].Cells["ItemInsertionNo"].Value.ToString());
                        if (RowButtonItemID == CurrentRowItemID && RowButtonID == buttonid && ItemInsertionNo == CurrentItemInsertionNo)
                        {
                            isexist = true;
                            break;
                        }
                    }

                    if (!isexist)
                    {

                        objPosHelper.objPOSScreenBal.objPOSObject.ItemName = ctr.Text;
                        objPosHelper.objPOSScreenBal.objPOSObject.AdditionFlag = 1;
                        objPosHelper.objPOSScreenBal.objPOSObject.ButtonId = buttonid;
                        objPosHelper.objPOSScreenBal.objPOSObject.ButtonItemId = CurrentRowItemID;// Convert.ToInt32(Dg_Sales.CurrentRow.Cells["ItemID"].Value.ToString());
                        objPosHelper.objPOSScreenBal.objPOSObject.ItemInsertionNo = CurrentItemInsertionNo;
                        objPosHelper.objPOSScreenBal.objPOSObject.ItemID = 0;
                        objPosHelper.AddGridSaleDetails(Dg_Sales);
                        AssignGridSource();
                        Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);
                        Cmb_Item.SelectedItem = null;
                        Txt_Refund.Text = "";
                        Txt_Price.Text = Txt_Qty.Text = string.Empty;
                        Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);
                    }
                }
                else
                {
                    if (ctr.Tag.ToString() != "" && Cmb_Item.Text != ctr.Tag.ToString())
                    {
                        objPosHelper.IsBtnShortcutClick = true;//Added on 17-June-2014 for Inserting the item on ButtonShorcut Click Only 
                        Cmb_Item.Text = ctr.Tag.ToString();
                        objPosHelper.IsBtnShortcutClick = false;//Added on 17-June-2014 for Inserting the item on ButtonShorcut Click Only 
                    }
                    else
                    {
                        SetObjectFromControl();
                        objPosHelper.objPOSScreenBal.objPOSObject.AdditionFlag = 0;
                        objPosHelper.AddGridSaleDetails(Dg_Sales);
                        if (objPosHelper.StockFinished)
                        {
                            ChangeRedColorButton();
                        }
                        AssignTaxTotal();
                        AssignAfterAddGrid();
                    }
                }
                Txt_Qty.Text = string.Empty;
                ClearFields();//Added on 16-May-2014
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "BtnShortCuts_Click");
            }
        }
        #endregion

        #region Button_Numbers_Click
        private void Button_Numbers_Click(object sender, EventArgs e)
        {
            try
            {
                Control name = (Control)sender;
                if (Txt_Qty.Enabled && Txt_Qty.Text.Length <= 8)
                {
                    if (name.Name != "Btn_Dot")
                    {

                        if (!isfirst)
                        {
                            Txt_Qty.Text = int.Parse(name.Text).ToString();
                            isfirst = true;
                        }
                        else
                            Txt_Qty.Text = ((Txt_Qty.Text != string.Empty) ? Txt_Qty.Text : "") + int.Parse(name.Text).ToString();
                    }
                }
                else
                {
                    if (Txt_Paid.Focused == true)
                    {
                        if (Txt_Paid.Text == string.Empty)
                        {
                            if (name.Name != "Btn_Dot") Txt_Paid.Text = Txt_Paid.Text + name.Text;
                        }
                        else
                        { Txt_Paid.Text = Txt_Paid.Text + name.Text; }

                        if (Txt_Paid.Text != string.Empty) Txt_Refund.Text = Convert.ToString((Convert.ToDecimal(Txt_Total.Text) - Convert.ToDecimal(Txt_Paid.Text)));
                    }
                }
                Txt_Refund.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Button_Numbers_Click");
            }
        }
        #endregion

        #region Btn_Plus_Click
        private void Btn_Plus_Click(object sender, EventArgs e)
        {
            try
            {
                objPosHelper.IsFromItemSelection = false; //Added on 17-June-2014
                SetObjectFromControl();
                // int rowindex = Dg_Sales.CurrentRow.Index;
                objPosHelper.PlusQty(Dg_Sales, CurrentRowIndex);
                if (objPosHelper.objPOSScreenBal.objPOSObject.RegularItemFlag)
                {
                    AssignGridSource();
                    AssignTaxTotal();
                    //  FocusLastRow();
                }
                //RefreshItem();
                //updatedItem = objPosHelper.GetItemDetailsHelper();
                dtPOSItems = objPosHelper.NewGetItemDetailsHelper();
                RefreshItem();
                // Thread ItemLoad = new Thread(RefreshItem);
                // ItemLoad.Start();
                if (Dg_Sales.SelectedRows.Count > 0)
                {
                    Dg_Sales.Rows[0].Selected = false;
                    Dg_Sales.Rows[CurrentRowIndex].Selected = true;
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Plus_Click");
            }

        }
        #endregion

        #region Btn_Minus_Click
        private void Btn_Minus_Click(object sender, EventArgs e)
        {
            try
            {
                objPosHelper.IsFromItemSelection = false; //Added on 17-June-2014
                SetObjectFromControl();
                objPosHelper.MinusQty(Dg_Sales, CurrentRowIndex);
                if (objPosHelper.objPOSScreenBal.objPOSObject.RegularItemFlag)
                {
                    if (objPosHelper.objPOSScreenBal.objPOSObject.DeleteItemFlag)
                    {
                        Txt_Qty.Text = string.Empty;
                        Txt_Price.Text = string.Empty;
                    }
                    AssignGridSource();
                    AssignTaxTotal();
                    BindDetailsToButton();
                    //updatedItem = objPosHelper.GetItemDetailsHelper();
                    dtPOSItems = objPosHelper.NewGetItemDetailsHelper();
                    //Thread ItemRefresh = new Thread(RefreshItem);
                    //ItemRefresh.Start();
                    RefreshItem();
                    // FocusLastRow();

                    if (Dg_Sales.SelectedRows.Count > 0)
                    {
                        Dg_Sales.Rows[0].Selected = false;
                        Dg_Sales.Rows[CurrentRowIndex].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Minus_Click");
            }

        }
        #endregion

        #region btnEnter_Click
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtActiveUser.Text != "0") && (txtActiveUser.Text != string.Empty) && (txtActiveUser.Text.Trim() != GeneralFunction.UserId.ToString()))
                {
                    GeneralFunction.Information("AnotherUserUsingThisInvoice", "Sales Invoice");
                    return;
                }
                objPosHelper.IsItemSaveInGrid = false;
                Enter();
                isfrominsert = false;
                //RefreshItem();Changed Refresh method to solve the performance issue.
                //updatedItem = objPosHelper.GetItemDetailsHelper();
                GeneralFunction.Trace("POS_Screen_Load End");
                dtPOSItems = objPosHelper.NewGetItemDetailsHelper();
                //Thread Itemstart = new Thread(RefreshItem);
                //Itemstart.Start();
                RefreshItem();
                if (objPosHelper.IsItemSaveInGrid)
                {
                    FocusLastRow();
                }
                GeneralFunction.Trace("POS_Screen_Load End");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnEnter_Click");
            }
        }
        #endregion

        #region btnExit_Click
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnExit_Click");
            }


        }
        #endregion

        #region Btn_Receipt_Click
        private void Btn_Receipt_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                posTotal = string.IsNullOrEmpty(Txt_Total.Text) ? 0 : Convert.ToDouble(Txt_Total.Text);
                Sales_Invoice.PaymentTypeID = objPosHelper.objPOSScreenBal.objPOSObject.PaymentTypeId;
                Sales_Invoice.PaymentChagers = string.IsNullOrEmpty(txtPaymentCharges.Text) ? 0 : Convert.ToDouble(txtPaymentCharges.Text);
                objPosHelper.ReceiveReceipt(Dg_Sales);
                Sales_Invoice.PaymentTypeID = 0;
                Sales_Invoice.PaymentChagers = 0;
                FillGrid();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_Receipt_Click");
            }
        }
        #endregion

        #region btnNotes_Click
        private void btnNotes_Click(object sender, EventArgs e)
        {
            try
            {

                FrmNotes objfrm = new FrmNotes();
                objfrm.ShowDialog();
                if (GeneralFunction.POSNotes != "")
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.Notes = GeneralFunction.POSNotes;
                    objPosHelper.objPOSScreenBal.objPOSObject.IsNotes = 1;
                    objPosHelper.objPOSScreenBal.objPOSObject.Status = Convert.ToInt16(SalesType.POS);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnNotes_Click");
            }
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                objPosHelper.PrintAllItemInKitchenReceipt = true;
                if (Dg_Sales.BackgroundColor == Color.Gray)
                {

                    GeneralFunction.CashClientName = Cmb_Client.Text;
                    if (Chk_PrintCashClientName.Checked && Convert.ToInt32(Cmb_Client.SelectedValue) == Convert.ToInt16(CommonHelper.CashClientID.ID))
                    {
                        if (GeneralFunction.Question("Do You Want To Print The Cash Client Name", "Cash Client Name") == DialogResult.Yes)
                        {
                            ExportMessage exportmessage = new ExportMessage();
                            exportmessage.Text = GeneralFunction.ChangeLanguageforCustomMsg("Cash Client Name");
                            exportmessage.Tag = "Cash Client Name";
                            exportmessage.ExportMessagePannel.SendToBack();
                            exportmessage.lblMessage.Visible = false;
                            exportmessage.rbnActualCost.Visible = false;
                            exportmessage.rbnSamePrice.Visible = false;
                            exportmessage.ShowDialog();
                            if (GeneralFunction.CashClientName == string.Empty)
                            { GeneralFunction.Information("CashClientNameisRequired", "CashClientName"); return; }
                        }
                    }
                    if (Chk_PrintCashClientName.Checked)
                        objPosHelper.PrintPreview = true;
                    else
                        objPosHelper.PrintPreview = false;
                    SetObjectFromControl();
                    if (!objPosHelper.IsNotPrintKitchenReceipt)
                        objPosHelper.IsNotPrintKitchenReceipt = objPosHelper.objPOSScreenBal.objPOSObject.ShortCut == 0 ? false : true;
                    objPosHelper.Print(Dg_Sales);
                    GeneralFunction.CashClientName = string.Empty;
                }
                else
                {
                    if (Dg_Sales.Rows.Count > 0 && ((GeneralOptionSetting.FlagPosCategoryVicePrint == "Y") ? true : false) && objPosHelper.objPOSScreenBal.objPOSObject.ShortCut != 0)
                    {
                        objPosHelper.IsNotPrintKitchenReceipt = false;
                        objPosHelper.IsForKitchentSlip = true;
                        SetObjectFromControl();
                        DataSet dt = objPosHelper.GetItemPrintInfo();
                        if (dt.Tables.Count > 0)
                        {
                            int TotalItems = Convert.ToInt32(dt.Tables[0].Rows[0]["TotalItems"]);
                            int ItemPrinted = Convert.ToInt32(dt.Tables[0].Rows[0]["ItemPrinted"]);
                            int ItemNotPrinted = Convert.ToInt32(dt.Tables[0].Rows[0]["ItemNotPrinted"]);

                            if (TotalItems == ItemNotPrinted)
                            {
                                objPosHelper.Print(Dg_Sales);
                            }
                            else
                            {
                                CustomMessageBox cmb = new CustomMessageBox();
                                cmb.ShowDialog();
                                //if (GeneralFunction.Question("PrintAllItem", "POS Screen") == DialogResult.Yes)
                                if (cmb.ButtonClick == "Print All")
                                {
                                    objPosHelper.Print(Dg_Sales);
                                }
                                else if (cmb.ButtonClick == "Print New")
                                {
                                    if (dt.Tables[1].Rows.Count > 0 || ItemNotPrinted != 0)
                                    {
                                        objPosHelper.KitchenReciptRemainingQuantity = dt.Tables[1];
                                        objPosHelper.PrintAllItemInKitchenReceipt = false;
                                        objPosHelper.Print(Dg_Sales);
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("NoPrintItem", "POS Screen");
                                    }
                                }
                                else if (cmb.ButtonClick == "Print Receipt")
                                {
                                    objPosHelper.IsNotPrintKitchenReceipt = true;
                                    objPosHelper.IsForKitchentSlip = false;
                                    objPosHelper.Print(Dg_Sales);
                                }
                            }
                        }
                        

                    }
                    else
                        GeneralFunction.Information("NotClosedInvoice", "POS Screen");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnPrint_Click");
            }
        }
        #endregion

        #region Btn_OpenDrawer_Click
        private void Btn_OpenDrawer_Click(object sender, EventArgs e)
        {
            try
            {
                CashDrawer objCashDraw = new CashDrawer();
                objCashDraw.OpenCashDrawer();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Btn_OpenDrawer_Click");
            }
        }
        #endregion

        #region btnTables_Click
        private void btnTables_Click(object sender, EventArgs e)
        {
            try
            {
                //  long SaleID = objPosHelper.TableButtonClick();
                long SaleID = 0;
                GeneralFunction.IsTableSelected = false;
                GeneralFunction.TableShortCut = 0;
                TablePOS ObjTablePos = new TablePOS();
                ObjTablePos.ShowDialog();

                if (GeneralFunction.IsTableSelected)
                {
                    if (GeneralFunction.TableShortCut > 0)
                    {
                        objPosHelper.objPOSScreenBal.objPOSObject.ShortCut = GeneralFunction.TableShortCut;
                        SaleID = objPosHelper.GetSaleIDForTableHelper();
                        if (SaleID == 0)
                        {
                            btnNew_Click(sender, e);
                            objPosHelper.objPOSScreenBal.objPOSObject.SaleId = Convert.ToInt64(Txt_InvoiceNo.Text);
                            objPosHelper.UpdateSaleIDForTableHelper();
                        }
                        else if (SaleID > 0)
                        {
                            Txt_InvoiceNo.Text = SaleID.ToString();
                            FillGrid();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnTables_Click");
            }
        }
        #endregion

        #endregion

        #region Index Changed Event

        #region Cmb_Client_SelectedIndexChanged
        private void Cmb_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Btn_Receipt.Enabled = !(Cmb_Client.SelectedValue != null && Cmb_Client.SelectedValue.ToString() == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString());
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Cmb_Client_SelectedIndexChanged");
            }
        }
        #endregion

        #region Cmb_Item_SelectedIndexChanged
        private void Cmb_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // string NewValue = "";
                if (Cmb_Item.SelectedValue != null)
                {
                    int SelectedItemID = Convert.ToInt32(Cmb_Item.SelectedValue);
                    bool FromShortCut = false;
                    if (PosItemPriceVal > 0)
                    {
                        FromShortCut = true;
                    }
                    else
                    {
                        if (PosItemPriceVal < 0)
                        {
                            FromShortCut = true;
                        }
                    }
                    if (objPosHelper.ShowPricePopup(SelectedItemID, 0) && FromShortCut == false)
                    {
                        PosItemPrice showDial = new PosItemPrice();
                        var ActionResult = showDial.ShowDialog();
                        if (ActionResult != null)
                        {
                            if (ActionResult.ToString() != "OK")
                            {
                                return;
                            }
                        }
                        //if (result == DialogResult.OK)
                        //{
                        //    if(PosItemPriceVal != null && PosItemPriceVal != 0)
                        //    {
                        //        NewValue = PosItemPriceVal.ToString();
                        //        objPosHelper.objPOSScreenBal.objPOSObject.ShowPricePopup = true;
                        //        //PosItemPriceVal = 0;
                        //    }


                        //}


                    }

                    if (PosItemPriceVal < 0)
                    {
                        PosItemPriceVal = 0;
                    }

                }

                //**************Commented on  17-June-2014**************************************
                //List<POSObject> objlistPos = new List<POSObject>();
                //SetObjectFromControl();
                //objPosHelper.objPOSScreenBal.objPOSObject.AdditionFlag = 0;
                //objPosHelper.AddGridSaleDetails(Dg_Sales);
                //if (objPosHelper.StockFinished)
                //{
                //    ChangeRedColorButton();
                //}
                //AssignTaxTotal();
                //AssignAfterAddGrid();
                //if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode != "N" && objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice != 0 && objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty != 0)//Added on 15-May-14 for Testing
                //{
                //    ClearFields();//Added on 15-May-14 for Testing
                //}
                //**************Commented on  17-June-2014**************************************


                //**************Added on  17-June-2014**************************************

                if (KeyUpDown)
                {
                    KeyUpDown = false;
                    return;
                }
                List<POSObject> objlistPos = new List<POSObject>();
                SetObjectFromControl();
                objPosHelper.objPOSScreenBal.objPOSObject.AdditionFlag = 0;
                if (!objPosHelper.IsBtnShortcutClick)
                {
                    objPosHelper.IsFromItemSelection = true; //Added on 16-June-2014
                }
                objPosHelper.Package.Clear();

                FillPackage(PosItemPriceVal);//this method added on 15-Sept-2014 for Package selection
                PosItemPriceVal = 0;
                objPosHelper.AddGridSaleDetails(Dg_Sales);
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                objPosHelper.IsPackage = false;
                if (objPosHelper.StockFinished)
                {
                    ChangeRedColorButton();
                }
                AssignTaxTotal();
                AssignAfterAddGrid();
                Txt_Qty.Focus();//Added on 16-June-2014
                Txt_Qty.Text = "1";//Added on 16-June-2014
                Txt_Qty.SelectAll();//Added on 27-June-2014
                if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode != "N" && objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice != 0 && objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty != 0)//Added on 15-May-14 for Testing
                {
                    ClearFields();//Added on 15-May-14 for Testing
                    Cmb_Item.Focus();//Added on  17-June-2014
                }
                //**************Added on  17-June-2014**************************************

                //*************Added on 29-Oct-2014************************************
                if (Dg_Sales.SelectedRows.Count > 0)
                {
                    int SelectedIndex = Dg_Sales.SelectedRows[0].Index;
                    Dg_Sales.Rows[SelectedIndex].Selected = false;
                }
                string text = Cmb_Item.Text;

                int Index = objPosHelper.lstGridItems.FindIndex(a => (a.ItemName == GeneralFunction.RemoveApostrophe(text)));
                if (Index != -1)
                {
                    Dg_Sales.Rows[Index].Selected = true;
                    //Dg_Sales.SelectionMode= Index;
                }
                ButtonClick = 0;
                isfirst = false;
                //*********************************************************************
                //if (!string.IsNullOrEmpty(NewValue))
                //{
                //    Txt_Price.Text = NewValue;
                //    Txt_Price_KeyUp(sender, null);
                //}

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Tab_Buttons_SelectedIndexChanged
        private void Tab_Buttons_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindDetailsToButton();
                if ((Tab_Buttons.SelectedIndex + 1) < (Tab_Buttons.TabCount))
                    Btn_Next1.Enabled = true;
                else
                    Btn_Next1.Enabled = false;
                if (Tab_Buttons.SelectedIndex == 0)
                    Btn_Previous1.Enabled = false;
                else
                    Btn_Previous1.Enabled = true;
                //if (ITEMNAM != String.Empty) NonStockItem(ITEMNAM);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Tab_Buttons_SelectedIndexChanged");
            }
        }
        #endregion


        #endregion

        #region Key Down Events

        #region POS_Screen_KeyDown
        private void POS_Screen_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    //if (Cmb_Item.SelectedItem != null)
                    //{ Enter(); }
                }
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }

                if (e.Alt && e.KeyCode == Keys.F3)//this condition Changed based on client requirement on 28Aug2014 By Meena.R
                {
                    if (UserScreenLimidations.SaleReturnInvoice)
                    {
                        ReturnOrderPopUp retrunorderpopup = new ReturnOrderPopUp();
                        retrunorderpopup.isfromPOS = true;
                        retrunorderpopup.ShowDialog();
                    }
                }
                else
                {
                    chkBox.Checked = false;
                    chkPiece.Checked = true;
                }

                if (e.KeyData == Keys.F9 && btnF9.Visible == true)
                {
                    //chkBox.Checked = true;
                    //chkPiece.Checked = false;//Commented on 22-Apr-14

                    //if (objPosHelper.IsPackage)
                    //{
                    //    objPosHelper.IsPackage = false;
                    //}
                    //else  Commended By Meena.R on 15-Sept-2014 
                    //{
                    //    objPosHelper.IsPackage = true;
                    //}
                    BoxFunction();
                }
                ///Implemented the quick return functionlaity on 07 April 2014  
                ///
                //if (e.KeyData == Keys.F7)
                //{
                //    chkBox.Checked = false;
                //    chkPiece.Checked = true;
                //}
                if (e.KeyData == Keys.F4)
                    InvokeOnClick(btnNew, EventArgs.Empty);
                if (e.KeyData == Keys.F5)
                    InvokeOnClick(btnClose, EventArgs.Empty);
                if (e.KeyData == Keys.F6)
                    InvokeOnClick(btnPrint, EventArgs.Empty);
                if (e.KeyData == Keys.F2)
                    InvokeOnClick(btnDelete, EventArgs.Empty);
                if (e.KeyData == Keys.F3)
                    InvokeOnClick(btnEnter, EventArgs.Empty);
                if (e.KeyData == Keys.F8)
                    InvokeOnClick(Btn_Receipt, EventArgs.Empty);
                if (e.KeyData == Keys.F7)
                {
                    if (GeneralOptionSetting.FlagHidePriceChangingButton != "Y")
                    {
                        PriceChanging();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "POS_Screen_KeyDown");
            }
        }
        #endregion

        #region Txt_InvoiceNo_KeyDown
        private void Txt_InvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    //*****Need to iMplement search functionlity
                    //FillGrid();
                    //******************************************
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Txt_InvoiceNo_KeyDown");
            }
        }
        #endregion



        //bool isFirst = false;
        //string appval = "";
        private void Cmb_Item_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyValue == 13 && Cmb_Item.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //{
                //    txtBarcode.Focus();
                //    return;
                //}

                //if (e.KeyValue == 13)
                //{
                //    if (Cmb_Item.AutoCompleteMode != AutoCompleteMode.None)
                //        Cmb_Item.AutoCompleteMode = AutoCompleteMode.None;
                //    Txt_Qty.Focus();
                //}
                //else
                //{
                //if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back)&&(e.KeyCode!=Keys.Shift)&&(e.KeyCode!=Keys.ShiftKey))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
                //{
                if (e.KeyCode == Keys.F4)
                    e.Handled = true;


                //To hide the two drop down in same time done by Praba on 28-Oct
                //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))
                //{
                //    if (((ComboBox)sender).DataSource != null)
                //    {
                //        if (((ComboBox)sender).DroppedDown == true)
                //            ((ComboBox)sender).DroppedDown = false;
                //    }

                //}

                //        else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin))
                //        {
                //            if (((ComboBox)sender).DroppedDown == true)
                //                ((ComboBox)sender).DroppedDown = false;
                //            if (Cmb_Item.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //            {
                //                Cmb_Item.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //                Cmb_Item.SelectedText = ((char)e.KeyValue).ToString();
                //                //cmbItemName.SelectedIndex=
                //                Cmb_Item.DroppedDown = true;
                //                //cmbItemName.SelectionStart = 1;
                //                isFirst = true;
                //                appval = ((char)e.KeyValue).ToString();
                //            }
                //            else
                //            {
                //                Cmb_Item.DroppedDown = false;
                //                if (isFirst)
                //                {
                //                    Cmb_Item.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //                    isFirst = false;
                //                }
                //            }
                //        }
                //if (e.KeyValue == 40 || e.KeyValue == 37 || e.KeyValue == 38 || e.KeyValue == 39)
                //{
                //    KeyUpDown = true;
                //}

                //if (e.KeyValue == 13 && Cmb_Item.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //{
                //    isfromitem = true;
                //    txtBarcode.Focus();
                //}

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Cmb_Item_KeyDown");
            }
        }

        #endregion

        #region KeyPress Event

        #region Cmb_Item_KeyPress
        private void Cmb_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            int lLength = Cmb_Item.Text.Length;
            if (lLength == 0 && e.KeyChar == 32)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                if (Cmb_Item.SelectedIndex > -1)
                {
                    Txt_Qty.Focus();
                    Txt_Qty.SelectAll();
                }
            }

        }
        #endregion

        #region Txt_Qty_KeyPress
        private void Txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GeneralFunction.NumericOnly(e) == true)
                e.Handled = true;
            else if (e.KeyChar == 13)
            {
                if (Cmb_Item.SelectedIndex > -1)
                {//Enter(); 
                    btnEnter_Click(null, null);
                }
            }

        }
        #endregion

        #region Txt_Price_KeyPress
        private void Txt_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (GeneralFunction.NumericOnly(e) == true) e.Handled = true;

        }
        #endregion

        #endregion

        #region Try Catch
        private void TryCatch()
        {
            try
            {

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "POS_Screen_Load");
            }
        }

        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {

            lblPaymentCharges.Text = Additional_Barcode.GetValueByResourceKey("PaymentCharges");
            chkPaymentsTypes.Text = Additional_Barcode.GetValueByResourceKey("PaymentType");
            lblPaid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
            lblRefund.Text = Additional_Barcode.GetValueByResourceKey("Refund");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            this.Text = Additional_Barcode.GetValueByResourceKey("POSScreen");
            btnExit.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            Btn_Adjust.Text = Additional_Barcode.GetValueByResourceKey("Adjust");
            btnClear.Text = Additional_Barcode.GetValueByResourceKey("Clear");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            chkPrintpreview.Text = Additional_Barcode.GetValueByResourceKey("PrintAfterClose");
            Btn_OpenDrawer.Text = Additional_Barcode.GetValueByResourceKey("CashDraw");
            btnNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            btnEnter.Text = Additional_Barcode.GetValueByResourceKey("Enter");
            Btn_Previous1.Text = Additional_Barcode.GetValueByResourceKey("Pre");
            Btn_Next1.Text = Additional_Barcode.GetValueByResourceKey("Next");
            lblClient.Text = Additional_Barcode.GetValueByResourceKey("Client");
            lblItem.Text = Additional_Barcode.GetValueByResourceKey("Item");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            lblOrederNo.Text = Additional_Barcode.GetValueByResourceKey("OrderNo");
            Btn_Receipt.Text = Additional_Barcode.GetValueByResourceKey("RecReceipt");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            lblTax.Text = Additional_Barcode.GetValueByResourceKey("Tax");
            btn_QuickItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnQuickItem");
            // lbl_ItemDescriptionQtyPriceTotal.Text = Additional_Barcode.GetValueByResourceKey("IDQP");

            Dg_Sales.Columns["Item"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            Dg_Sales.Columns["Qty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Qty");
            Dg_Sales.Columns["Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("Price");
            Dg_Sales.Columns["Box"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            Dg_Sales.Columns["Package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            Dg_Sales.Columns["Total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");

            chkBox.Text = Additional_Barcode.GetValueByResourceKey("Box");
            chkPiece.Text = Additional_Barcode.GetValueByResourceKey("Piece");
            tabPage1.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage2.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage3.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage4.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage5.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage6.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage7.Text = Additional_Barcode.GetValueByResourceKey("Items");
            tabPage8.Text = Additional_Barcode.GetValueByResourceKey("Items");
            btnTables.Text = Additional_Barcode.GetValueByResourceKey("Tables");
            Chk_PrintCashClientName.Text = Additional_Barcode.GetValueByResourceKey("CashClientPrint");
        }
        #endregion

        #region HideControls
        private void HideControls()
        {
            Btn_First.Visible = Btn_Next.Visible = Btn_Previous.Visible = Btn_Last.Visible = UserScreenLimidations.InvoiceNavigation == true ? true : false;
            Txt_InvoiceNo.ReadOnly = UserScreenLimidations.InvoiceNavigation == true ? false : true;
            Txt_InvoiceNo.BackColor = Color.White;
            Btn_Adjust.Enabled = UserScreenLimidations.ModifyInvoice == true ? true : false;
            Btn_Receipt.Enabled = UserScreenLimidations.ReceiveReceipt == true ? true : false;
            //  RTxt_Queue.Visible = Lbl_Queue.Visible = Btn_Notes.Visible = GeneralOptionSetting.FlagHideKitchenWindow != "Y";
            Btn_Previous1.Enabled = false;
            Btn_OpenDrawer.Visible = (GeneralOptionSetting.FlagUseCashDrawer == "Y") ? true : false;
            btnF9.Visible = cmbPackage.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            Dg_Sales.Columns["Package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            btn_QuickItem.Enabled = (UserScreenLimidations.SaleReturnInvoice) ? true : false;
            bool DisableItemNumber = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;

            if (!DisableItemNumber)
            {
                this.cmbItemNo.Enabled = false;
                //this.Cmb_Item.DropDownWidth = 378;
                //this.Cmb_Item.Location = new System.Drawing.Point(3, 74);
                //this.Cmb_Item.Size = new System.Drawing.Size(378, 26);
            }

        }
        #endregion

        #region AssignToComboBox
        private void AssignToComboBox()
        {
            List<ItemCardObjectClass> lstItemdet = new List<ItemCardObjectClass>();
            try
            {
                Cmb_Client.SelectedIndexChanged -= new EventHandler(Cmb_Client_SelectedIndexChanged);
                Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
                AssignClientDataSource();

                //------This is commented by Manoj since client has asked to get itemdetails with package qty of different barcode.
                //GeneralObjectClass.ItemDetails = objPosShortcutHelper.LoadItemDetails();
                //Cmb_Item.DataSource = GeneralObjectClass.ItemDetails;

                // Below lines instead of above



                //---------------------------
                // lstItemdet.Sort(delegate(ItemCardObjectClass Item1, ItemCardObjectClass Item2)
                // {
                //     return Item1.Items.CompareTo(Item2.Items);
                //});

                //----------------------------


                // lstItemdet = objPosHelper.GetItemDetailsHelper();

                dtPOSItems = objPosHelper.NewGetItemDetailsHelper();

                Cmb_Item.DisplayMember = "Items";
                Cmb_Item.ValueMember = "ItemId";
                Cmb_Item.DataSource = dtPOSItems;

                Cmb_Item.SelectedIndex = -1;

                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemID";
                // cmbItem.DataSource = CommondtItem;
                DataView dvi = new DataView(dtPOSItems);
                dvi.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dvi.ToTable();
                this.Invoke(new MethodInvoker(delegate
                {
                    // cmbItem.SelectedIndex = -1;
                    cmbItemNo.SelectedIndex = -1;
                }));

                Cmb_Client.SelectedIndexChanged += new EventHandler(Cmb_Client_SelectedIndexChanged);
                Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);
                cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstItemdet = null;
            }

        }

        private void AssignClientDataSource()
        {
            objSaleInvoiceHelper.LoadClientDetails();
            Cmb_Client.ValueMember = "AgentId";
            Cmb_Client.DisplayMember = "Name";
            Cmb_Client.DataSource = objSaleInvoiceHelper.ClientDetails;
            Cmb_Client.SelectedIndex = -1;
        }
        #endregion

        #region ClearInputs
        private void ClearInputs()
        {
            try
            {
                txtPaymentCharges.Text = "0.000";
                Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);
                Cmb_Item.SelectedItem = null;
                Cmb_Item.Text = string.Empty;
                Cmb_Client.SelectedValue = Convert.ToInt32(CommonHelper.CashClientID.ID);//This is changed to bind case client is default when click new also. Done by A.Manoj. On July-07
                Txt_Paid.Text = Txt_Price.Text = Txt_Qty.Text = Txt_Refund.Text = Txt_Total.Text = Txt_Tax.Text = string.Empty;
                Txt_Qty.Enabled = true;
                Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SetObjectFromControl

        private void SetObjectFromControl()
        {
            try
            {
                objPosHelper.objPOSScreenBal.objPOSObject.GridBgColor = Dg_Sales.BackgroundColor.ToString();
                objPosHelper.objPOSScreenBal.objPOSObject.CurrentQty = (Txt_Qty.Text != string.Empty && int.Parse(Txt_Qty.Text) > 0) ? int.Parse(Txt_Qty.Text) : 1;
                //objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails = (List<ItemCardObjectClass>)Cmb_Item.DataSource;
                objPosHelper.objPOSScreenBal.objPOSObject.ItemName = (Cmb_Item.SelectedIndex != -1 ? Cmb_Item.Text : "");

                objPosHelper.objPOSScreenBal.objPOSObject.ItemID = (Cmb_Item.SelectedIndex != -1 ? Convert.ToInt16(Cmb_Item.SelectedValue) : 0);

                objPosHelper.GetAllItemDetails(objPosHelper.objPOSScreenBal.objPOSObject.ItemID);
                objPosHelper.AllItems[0].Price = 100;
                objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails = objPosHelper.AllItems;
                objPosHelper.objPOSScreenBal.objPOSObject.TaxText = Txt_Tax.Text;
                objPosHelper.objPOSScreenBal.objPOSObject.TotalText = Txt_Total.Text;
                objPosHelper.objPOSScreenBal.objPOSObject.PaymentCharges = Convert.ToDecimal(txtPaymentCharges.Text == string.Empty ? "0" : txtPaymentCharges.Text);
                objPosHelper.objPOSScreenBal.objPOSObject.SaleId = (Txt_InvoiceNo.Text != "" ? Convert.ToInt64(Txt_InvoiceNo.Text) : 0);
                objPosHelper.objPOSScreenBal.objPOSObject.ClientID = (Cmb_Client.SelectedIndex == -1) ? Convert.ToInt16(CommonHelper.CashClientID.ID) : Convert.ToInt16(Cmb_Client.SelectedValue);
                objPosHelper.objPOSScreenBal.objPOSObject.PosDate = Dtp_Pos.Value.ToString();
                objPosHelper.objPOSScreenBal.objPOSObject.RefundText = string.IsNullOrEmpty(Txt_Refund.Text) ? "0.000": Txt_Refund.Text;
                objPosHelper.objPOSScreenBal.objPOSObject.PaidText = string.IsNullOrEmpty(Txt_Paid.Text) ? "0.000" : Txt_Paid.Text;
                objPosHelper.objPOSScreenBal.objPOSObject.ItemSelectedIndex = Cmb_Item.SelectedIndex;
                objPosHelper.objPOSScreenBal.objPOSObject.CmbClientText = (Cmb_Client.SelectedIndex == -1) ? "" : Cmb_Client.Text;
                objPosHelper.ActualPrice = Convert.ToDecimal(Txt_Price.Text == string.Empty ? "0" : Txt_Price.Text);
                objPosHelper.objPOSScreenBal.objPOSObject.ButtonId = 0;
                objPosHelper.objPOSScreenBal.objPOSObject.ButtonItemId = 0;
                objPosHelper.objPOSScreenBal.objPOSObject.ItemType = objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails[0].ItemType;
                //objPosHelper.objPOSScreenBal.objPOSObject.ItemType = objPosHelper.AllItems.FindAll(x=> x.ItemId == objPosHelper.objPOSScreenBal.objPOSObject.ItemID).ItemType;
                objPosHelper.objPOSScreenBal.objPOSObject.ItemInsertionNo = GenerateItemInsertionNo(objPosHelper.objPOSScreenBal.objPOSObject.ItemID);
                //
                if (POS_Screen.selectedPaymentType == "card")
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.PaymentTypeId = 2;
                }
                else if (POS_Screen.selectedPaymentType == "check")
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.PaymentTypeId = 3;
                }
                else
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.PaymentTypeId = 1;
                }

                // objPosHelper.IsPackage = chkBox.Checked != true ? true : false;ommented on 22-Apr-14



            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "SetObjectFromControl");
            }
        }


        #endregion

        #region BindDetailsToButton
        private int GenerateItemInsertionNo(int ItemID)
        {
            int Number = 0;
            if (ItemID != 0)
            {
                Number = 1;
                for (int i = 0; i < objPosHelper.lstGridItems.Count; i++)
                {
                    if (objPosHelper.lstGridItems[i].ItemID == ItemID)
                    {
                        Number += Number;
                    }
                }
            }
            return Number;
        }
        #endregion

        #region BindDetailsToButton
        private void BindDetailsToButton()
        {

            int btnindex = 0;
            Control.ControlCollection ctr = Tab_Buttons.SelectedTab.Controls;
            Control.ControlCollection addctr = Grb_AdditionButton.Controls;
            //List<ItemCardObjectClass> lstItem;
            try
            {
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom = (Tab_Buttons.SelectedIndex * 18) + 1;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutTo = objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom + 17;
                objPosShortcutHelper.GetButtonDetailsHelper();

                if (objPosShortcutHelper.lstButtonDetailsOne.Count > 0)
                {
                    objPosShortcutHelper.AddImage("N", ImgLstButton);
                    for (int i = 0; i < objPosShortcutHelper.lstButtonDetailsOne.Count; i++)
                    {

                        if (objPosShortcutHelper.lstButtonDetailsOne[i].AdditionFlag == 0)
                        {
                            Control[] cn;
                            string str = "Btn" + objPosShortcutHelper.lstButtonDetailsOne[i].ShortCut;
                            System.Windows.Forms.Button Btn;
                            cn = ctr.Find(str, true);
                            Btn = (Button)cn[0];

                            //lstItem = new List<ItemCardObjectClass>();
                            //lstItem = (List<ItemCardObjectClass>)Cmb_Item.DataSource;

                            //lstItem = (from a in lstItem
                            //           where a.ItemId == objPosShortcutHelper.lstButtonDetailsOne[i].ItemID
                            //           select a).ToList();

                            DataRow[] lstItem = dtPOSItems.Select("ItemId=" + objPosShortcutHelper.lstButtonDetailsOne[i].ItemID);

                            if (lstItem.Length <= 0)
                            {

                                Btn.BackColor = Color.Red;
                                Btn.ImageList = null;
                                if (objPosShortcutHelper.lstButtonDetailsOne[i].Discription == string.Empty) Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName; else Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].Discription;
                                // Btn.Tag = objPosShortcutHelper.lstButtonDetailsOne[i].ItemID;
                                Btn.Tag = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName;
                            }
                            else
                            {
                                Btn.Enabled = true;
                                Btn.BackColor = Color.Transparent;
                                if (objPosShortcutHelper.lstButtonDetailsOne[i].Discription == string.Empty) Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName; else Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].Discription;
                                //  Btn.Tag = objPosShortcutHelper.lstButtonDetailsOne[i].ItemID;
                                Btn.Tag = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName;
                            }

                            byte[] imgbyte = objPosShortcutHelper.lstButtonDetailsOne[i].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])objPosShortcutHelper.lstButtonDetailsOne[i].ImageByte : new byte[0];
                            if (imgbyte.Length > 1)
                            {
                                Btn.ImageList = ImgLstButton;
                                Btn.ImageList.ImageSize = new Size(75, 50);
                                Btn.ImageAlign = ContentAlignment.TopCenter;
                                Btn.ImageIndex = btnindex;
                                btnindex += 1;
                            }

                        }
                        else
                        {
                            Control[] cn;
                            string str = "Btn_Add" + objPosShortcutHelper.lstButtonDetailsOne[i].ShortCut;
                            System.Windows.Forms.Button Btn;
                            cn = addctr.Find(str, true);
                            Btn = (Button)cn[0];
                            Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName;
                            Btn.Tag = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName;
                        }

                    }

                }
                DisableButtons();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ctr = null;
                addctr = null;
                //lstItem = null;
            }


        }
        #endregion

        #region DisableButton
        private void DisableButtons()
        {
            System.Windows.Forms.Button Btn;
            try
            {
                Control.ControlCollection[] Array = new Control.ControlCollection[2];
                Array[0] = Tab_Buttons.SelectedTab.Controls;
                Array[1] = Grb_AdditionButton.Controls;
                for (int i = 0; i < Array.Length; i++)
                {
                    foreach (Control ctrbutton in Array[i])
                    {
                        if (ctrbutton.GetType().ToString() == "System.Windows.Forms.Button")
                        {
                            Btn = (Button)ctrbutton;
                            if (Btn.Text == string.Empty)
                                Btn.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region AssignGridSource
        private void AssignGridSource()
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = objPosHelper.SortInvoiceDetails(objPosHelper.lstGridItems, "ItemName", "Price");
            Dg_Sales.AutoGenerateColumns = false;
            Dg_Sales.DataSource = null;
            Dg_Sales.DataSource = bs;
            FocusLastRow();
        }
        #endregion

        #region SetMaxSaleID
        private void SetMaxSaleID()
        {
            objPosHelper.GetMaxSaleIDHelper();
            if (objPosHelper.objPOSScreenBal.objPOSObject.SaleId == 0)//First time Sale ID will be zero.So that time Invoice 1 will be created
            {
                NewInvoice();
            }
            else
            {
                Txt_InvoiceNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.SaleId.ToString();
                FillGrid();
            }
        }
        #endregion

        #region FillGrid
        private void FillGrid()
        {
            try
            {
                objPosHelper.objPOSScreenBal.objPOSObject.SaleId = Convert.ToInt64(Txt_InvoiceNo.Text);

                objPosHelper.lstGridItems.Clear();
                Txt_Total.Text = Txt_Refund.Text = Txt_Paid.Text = Txt_Tax.Text = string.Empty;
                ClearTextFeilds();
                objPosHelper.FillDetailsForInvoiceNo(Dg_Sales);
                AssignGridSource();
                Txt_NewInvoiceNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.NewInvoiceNoText;
                Dtp_Pos.Value = Convert.ToDateTime(objPosHelper.objPOSScreenBal.objPOSObject.PosDate);
                Lbl_OrderNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.OrderNo.ToString();
                //Cmb_Client.SelectedValue = Convert.ToInt16(objPosHelper.objPOSScreenBal.objPOSObject.ClientSelectedVal);
                Cmb_Client.SelectedValue = objPosHelper.objPOSScreenBal.objPOSObject.ClientSelectedVal;
                Btn_Receipt.Enabled = objPosHelper.objPOSScreenBal.objPOSObject.BtnReceiptEnabled;
                txtPaymentCharges.Text = objPosHelper.objPOSScreenBal.objPOSObject.PaymentCharges.ToString();
                Txt_Tax.Text = objPosHelper.objPOSScreenBal.objPOSObject.TaxText;
                Txt_Total.Text = objPosHelper.objPOSScreenBal.objPOSObject.TotalText;
                Txt_Paid.Text = objPosHelper.objPOSScreenBal.objPOSObject.PaidText;
                Txt_Refund.Text = objPosHelper.objPOSScreenBal.objPOSObject.RefundText;
                Refundamount(Convert.ToDecimal(objPosHelper.objPOSScreenBal.objPOSObject.PaidText));

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region EnableButton
        void EnableButton()
        {
            System.Windows.Forms.Button Btn;
            try
            {
                Control.ControlCollection[] Array = new Control.ControlCollection[9];
                Array[0] = tabPage1.Controls;
                Array[1] = tabPage2.Controls;
                Array[2] = tabPage3.Controls;
                Array[3] = tabPage4.Controls;
                Array[4] = tabPage5.Controls;
                Array[5] = tabPage6.Controls;
                Array[6] = tabPage7.Controls;
                Array[7] = tabPage8.Controls;
                Array[8] = Grb_AdditionButton.Controls;

                for (int i = 0; i < Array.Length; i++)
                {
                    foreach (Control ctrbutton in Array[i])
                    {
                        if (ctrbutton.GetType().ToString() == "System.Windows.Forms.Button")
                        {
                            Btn = (Button)ctrbutton;
                            if (Btn.Tag != null && Btn.Tag.ToString() == Dg_Sales.SelectedRows[0].Cells["Item"].Value.ToString())
                            {
                                Btn.Enabled = true;
                                Btn.BackColor = System.Drawing.SystemColors.Control;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FocusLastRow
        void FocusLastRow()
        {
            try
            {
                if (Dg_Sales.RowCount <= 0) return;
                int rowindex = Dg_Sales.RowCount;
                CurrencyManager cm = (CurrencyManager)this.BindingContext[Dg_Sales.DataSource, Dg_Sales.DataMember];
                int lastrow = 1;
                for (int i = 1; i < Dg_Sales.RowCount + 1; i++)
                {
                    string[] arr = new string[2];
                    int ItemID = Convert.ToInt32(Dg_Sales.Rows[i - 1].Cells["ItemID"].Value);
                    //string Name =Dg_Sales.Rows[i + 1].Cells["ItemName"].Value.ToString();
                    if (ItemID != 0)
                    {
                        lastrow = Dg_Sales.Rows[i - 1].Index;
                    }

                }
                // Added on 8-April-2019 By T
                if (Dg_Sales.RowCount == 1 && Dg_Sales.Rows[0].Cells["ItemID"].Value.ToString() == "0")
                {
                    lastrow = 0;
                }
                //

                //cm.Position = rowindex - 1;
                cm.Position = lastrow;
                //Dg_Sales.Rows[rowindex - 1].Selected = true;
                Dg_Sales.Rows[lastrow].Selected = true;

                //CurrentRowIndex = rowindex - 1;
                CurrentRowIndex = lastrow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region AssignTaxTotal
        private void AssignTaxTotal()
        {
            Txt_Tax.Text = objPosHelper.objPOSScreenBal.objPOSObject.TaxText;
            Txt_Total.Text = objPosHelper.objPOSScreenBal.objPOSObject.TotalText;
        }

        #endregion

        #region AssignAfterAddGrid
        private void AssignAfterAddGrid()
        {
            Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.objPOSScreenBal.objPOSObject.ItemPackagePrice.ToString("####0.000"))).ToString();
            //**************Added on 26-Sep-2108 Discounted Price******************************************************* 
            DiscountCalculation(Txt_Price.Text);
            //*********************************************************************
            PriceValue(Txt_Price.Text, objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails[0].CategoryId, objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails[0].CompId, objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails[0].ItemType, objPosHelper.objPOSScreenBal.objPOSObject.lstSelectedItemDetails[0].ItemId);
            //*********************************************************************
            //**************Added on 15-Feb-2109 Discounted Price******************************************************* 
            objPosHelper.setPrice(Txt_Price.Text);
            //*********************************************************************
            Txt_Qty.Text = objPosHelper.objPOSScreenBal.objPOSObject.QtyText;
            Txt_Tax.Text = objPosHelper.objPOSScreenBal.objPOSObject.TaxText;
            Txt_Total.Text = objPosHelper.objPOSScreenBal.objPOSObject.TotalText;
            AssignGridSource();
            CommonHelper.CustomNotesAlerts.CustomerMessage(Txt_Price.Text, Txt_Total.Text, CustomNotesAlerts.messageType.sale);



        }
        #endregion

        #region Enter
        private void Enter()
        {
            objPosHelper.IsFromItemSelection = false; //Added on 17-June-2014
            SetObjectFromControl();
            if (Cmb_Client.SelectedIndex == -1 && Cmb_Client.Text != "")
            {
                string agentname = string.Empty;
                agentname = Cmb_Client.Text.ToUpper().Trim().Replace(" ", "").ToString();
                if (agentname != "زبون نقدي".Trim().Replace(" ", "") && agentname != "Cash Client".ToUpper().Trim().Replace(" ", ""))
                {
                    if (GeneralFunction.Question("Doyouwanttosavenewuser", "Sales Invoice") == DialogResult.Yes)
                    {
                        string strNewAgent = Cmb_Client.Text;
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CmbClientText = Cmb_Client.Text;
                        if (objSaleInvoiceHelper.SaveNewAgent())
                        {
                            AssignClientDataSource();
                            objPosHelper.objPOSScreenBal.objPOSObject.CmbClientText = strNewAgent;
                            Cmb_Client.Text = strNewAgent;
                            objPosHelper.objPOSScreenBal.objPOSObject.ClientID = (Cmb_Client.SelectedIndex == -1) ? Convert.ToInt16(CommonHelper.CashClientID.ID) : Convert.ToInt16(Cmb_Client.SelectedValue);

                        }

                    }
                    else
                        return;
                }
                else
                {
                    GeneralFunction.Information("ExistsAgentName", "SaleInvoice");
                    return;
                }
            }
            objPosHelper.EnterItem(Dg_Sales);
            if (objPosHelper.objPOSScreenBal.objPOSObject.QtyGreaterZero)
            {
                AssignTaxTotal();
                AssignAfterAddGrid();
                Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);
                cmbPackage.SelectedIndexChanged -= new EventHandler(cmbPackage_SelectedIndexChanged);
                Cmb_Item.SelectedItem = null;
                cmbPackage.DataSource = null;
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                objPosHelper.IsPackage = false;
                Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);
                cmbPackage.SelectedIndexChanged += new EventHandler(cmbPackage_SelectedIndexChanged);
                Txt_Price.Text = string.Empty;
                isfrominsert = true;

                // added for item number 2-3-019
                cmbItemNo.SelectedIndexChanged -= new EventHandler(cmbItemNo_SelectedIndexChanged);
                cmbItemNo.SelectedIndex = -1;
                cmbItemNo.Text = string.Empty;
                cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
                // added for item number 2-3-019

                Cmb_Item.Focus();//Added on 17-June-2014
            }
            else
            {
                Txt_Qty.Focus();
            }
        }
        #endregion

        #region ClearTextFeilds
        private void ClearTextFeilds()
        {
            objPosHelper.objPOSScreenBal.objPOSObject.TaxText = "0.000";
            objPosHelper.objPOSScreenBal.objPOSObject.TotalText = "0.000";
            objPosHelper.objPOSScreenBal.objPOSObject.PaidText = "0.000";
            objPosHelper.objPOSScreenBal.objPOSObject.RefundText = "0.000";
            objPosHelper.objPOSScreenBal.objPOSObject.PaymentCharges = 0.000M;
            objPosHelper.objPOSScreenBal.objPOSObject.Tax = 0.000M;
            objPosHelper.objPOSScreenBal.objPOSObject.Tax1 = 0.000M;
            objPosHelper.objPOSScreenBal.objPOSObject.Tax2 = 0.000M;
            objPosHelper.objPOSScreenBal.objPOSObject.SubTax1 = 0.000M;
            objPosHelper.objPOSScreenBal.objPOSObject.SubTax2 = 0.000M;
        }

        #endregion

        #region NewInvoice

        private void NewInvoice()
        {
            try
            {
                ClearTextFeilds();
                ClearInputs();
                objPosHelper.lstGridItems.Clear();
                AssignGridSource();
                //Dg_Sales.BackgroundColor = Color.NavajoWhite; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                Dg_Sales.BackgroundColor = Color.WhiteSmoke; Dg_Sales.DefaultCellStyle.BackColor = Color.White; Dg_Sales.ForeColor = Color.Black;
                objPosHelper.NewbtnYearInvoice();
                Txt_InvoiceNo.Text = objPosHelper.InvoiceID[0].ToString();
                Txt_NewInvoiceNo.Text = objPosHelper.objPOSScreenBal.objPOSObject.NewInvoiceNoText = "P" + objPosHelper.InvoiceID[2].ToString();
                Dtp_Pos.Text = DateTime.Now.ToShortDateString();
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.saleid = objPosHelper.InvoiceID[0];
                SetObjectFromControl();
                objPosHelper.GetOrderNoHelper();
                Lbl_OrderNo.Text = objPosHelper.OrderNo.ToString();
                objPosHelper.AssignInvoice(Convert.ToInt16(SalesInvoiceType.NormalInvoice));
                objPosHelper.SaveSaleInvoiceHelper();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region Barcode
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
        //            //ClearFields();Commended by Meena.R this methos rasied two time one in keyup
        //            tmrBarcode.Enabled = false;
        //            string barcode = Convert.ToString(txtBarcode.Text);
        //            if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            // barcode = barcode.Replace("\r", "");
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                // Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
        //                //if ((ConvertionHelper.ConvertToDataTable<ItemCardObjectClass>(objPosShortcutHelper.LoadItemDetails())).Select("ItemID='" + GeneralFunction.RemoveApostrophe(dtBarcode.Rows[0]["ItemID"].ToString()) + "'").Length > 0)
        //                //{Changed Condition By Meena.R on 24/09/2014
        //                if (objPosHelper.lstItemDetails.Where(a => a.ItemId == Convert.ToInt32(dtBarcode.Rows[0]["ItemID"].ToString())).ToList().Count > 0)
        //                {
        //                    objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = Convert.ToInt16(dtBarcode.Rows[0]["PackageQty"]);
        //                    objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = Convert.ToDecimal(dtBarcode.Rows[0]["Price"]);
        //                    Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                    cmbPackage.Text = dtBarcode.Rows[0]["PackageQty"].ToString();//added to fix the scanned package qty not added
        //                    objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = 0;
        //                    objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = 0;
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("NotValidItemPOS", "POS Screen");
        //                }

        //                //if (Cmb_Item.SelectedItem != null)//Commented on 22-Apr-14
        //                //{
        //                //    //Txt_Price.Text = Convert.ToDecimal(Cmb_Item.SelectedValue).ToString("####0.000");
        //                //    Txt_Qty.Focus();
        //                //    objPosHelper.AddGridSaleDetails(Dg_Sales);
        //                //    //AddDetailstoGrid(Cmb_Item.Text.Trim(), "N");
        //                //    Txt_Refund.Text = "";
        //                //}
        //                Txt_Qty.Focus();//Commented on 17-June-2014//Modified By Meena.R on 24-Sept-2014

        //                ClearBarcodeValues();
        //                //Cmb_Item.Focus();//Added on 17-June-2014//Modified By Meena.R on 24-Sept-2014
        //                // Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
        //            }
        //            else
        //            {
        //                //GeneralFunction.MessageBoxDisplay(this.Text,"There is no item found for this barcode.",GeneralFunction.MessageType .Information);
        //                //ClearBarcodeValues();

        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "POS Screen") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = ScanValue + txtBarcode.Text.Trim();
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;

        //                    }
        //                    ClearBarcodeValues();
        //                    Cmb_Item.Focus();
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "POS Screen");
        //                    txtBarcode.Text = string.Empty;
        //                    ClearBarcodeValues();
        //                    Cmb_Item.Focus();
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
        //        ClearBarcodeValues();
        //        tmrBarcode.Enabled = false;
        //        //GeneralFunction.ErrMsg(this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "pos_screen", "tmrBarcode_Tick");
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
                        if (barcode.Trim().Length != 13)//added By T on 25Mar2019 if  we can continue it shown not available lastfocus control value no add
                        {
                            barcode = lastfocusedvalue + ScanValue + Convert.ToString(txtBarcode.Text);
                        }
                    }

                    //*********Commented for Performance Tuning on 19-Nov-2014 by Seenivasan*********//

                    //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    // Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
                    //    //if ((ConvertionHelper.ConvertToDataTable<ItemCardObjectClass>(objPosShortcutHelper.LoadItemDetails())).Select("ItemID='" + GeneralFunction.RemoveApostrophe(dtBarcode.Rows[0]["ItemID"].ToString()) + "'").Length > 0)
                    //    //{Changed Condition By Meena.R on 24/09/2014
                    //    if (objPosHelper.lstItemDetails.Where(a => a.ItemId == Convert.ToInt32(dtBarcode.Rows[0]["ItemID"].ToString())).ToList().Count > 0)
                    //    {
                    //        objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = Convert.ToInt16(dtBarcode.Rows[0]["PackageQty"]);
                    //        objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = Convert.ToDecimal(dtBarcode.Rows[0]["Price"]);
                    //        Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //        cmbPackage.Text = dtBarcode.Rows[0]["PackageQty"].ToString();//added to fix the scanned package qty not added
                    //        objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = 0;
                    //        objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = 0;
                    //    }
                    //    else
                    //    {
                    //        GeneralFunction.Information("Thereisnoiteminstock", "POS Screen");//Changed messaged on 30Oct2014 By Meena.R
                    //    }

                    //    //if (Cmb_Item.SelectedItem != null)//Commented on 22-Apr-14
                    //    //{
                    //    //    //Txt_Price.Text = Convert.ToDecimal(Cmb_Item.SelectedValue).ToString("####0.000");
                    //    //    Txt_Qty.Focus();
                    //    //    objPosHelper.AddGridSaleDetails(Dg_Sales);
                    //    //    //AddDetailstoGrid(Cmb_Item.Text.Trim(), "N");
                    //    //    Txt_Refund.Text = "";
                    //    //}
                    //    Txt_Qty.Focus();//Commented on 17-June-2014//Modified By Meena.R on 24-Sept-2014

                    //    ClearBarcodeValues();
                    //    //Cmb_Item.Focus();//Added on 17-June-2014//Modified By Meena.R on 24-Sept-2014
                    //    // Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
                    //}
                    //*********************************************************************************************

                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {

                            // Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
                            //if ((ConvertionHelper.ConvertToDataTable<ItemCardObjectClass>(objPosShortcutHelper.LoadItemDetails())).Select("ItemID='" + GeneralFunction.RemoveApostrophe(dtBarcode.Rows[0]["ItemID"].ToString()) + "'").Length > 0)
                            //{Changed Condition By Meena.R on 24/09/2014

                            DataRow[] drBarcodeRow = objPosHelper.DtPOSItem.Select("ItemId =" + Convert.ToInt32(row1["ItemID"].ToString()));
                            //if (objPosHelper.lstItemDetails.Where(a => a.ItemId == Convert.ToInt32(row1["ItemID"].ToString())).ToList().Count > 0)
                            if (drBarcodeRow.Length > 0)
                            {
                                int Quantity = string.IsNullOrEmpty(Txt_Qty.Text) ? 1 : Convert.ToInt32(Txt_Qty.Text);
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedQuantity =Quantity * Convert.ToInt16(row1["PackageQty"]);
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty =  Convert.ToInt16(row1["PackageQty"]);
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = Convert.ToDecimal(row1["Price"]);
                                Cmb_Item.Text = row1["ItemName"].ToString();
                                cmbPackage.Text = row1["PackageQty"].ToString();//added to fix the scanned package qty not added
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPackageQty = 0;
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedPrice = 0;
                                objPosHelper.objPOSScreenBal.objPOSObject.ScannedQuantity = 0;
                            }
                            else
                            {
                                GeneralFunction.Information("Thereisnoiteminstock", "POS Screen");//Changed messaged on 30Oct2014 By Meena.R
                            }

                            //if (Cmb_Item.SelectedItem != null)//Commented on 22-Apr-14
                            //{
                            //    //Txt_Price.Text = Convert.ToDecimal(Cmb_Item.SelectedValue).ToString("####0.000");
                            //    Txt_Qty.Focus();
                            //    objPosHelper.AddGridSaleDetails(Dg_Sales);
                            //    //AddDetailstoGrid(Cmb_Item.Text.Trim(), "N");
                            //    Txt_Refund.Text = "";
                            //}
                            if (GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode == "Y")// Addedd on 13-Mar-2019
                            {
                                Cmb_Item.Focus();// Addedd on 13-Mar-2019
                            }
                            else
                            {
                                Txt_Qty.Focus();//Commented on 17-June-2014//Modified By Meena.R on 24-Sept-2014
                            }

                            ClearBarcodeValues();
                            //Cmb_Item.Focus();//Added on 17-June-2014//Modified By Meena.R on 24-Sept-2014
                            // Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);//Commented on 22-Apr-14
                        }
                    }
                    //*********************************************************************************************
                    else
                    {
                        //GeneralFunction.MessageBoxDisplay(this.Text,"There is no item found for this barcode.",GeneralFunction.MessageType .Information);
                        //ClearBarcodeValues();

                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "POS Screen") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = ScanValue + txtBarcode.Text.Trim();
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                LoadNewItems();
                            }
                            ClearBarcodeValues();
                            Cmb_Item.Focus();
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "POS Screen");
                            txtBarcode.Text = string.Empty;
                            ClearBarcodeValues();
                            Cmb_Item.Focus();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "POS Screen", "timer1_Tick");
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
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                tmrBarcode.Enabled = true;
                //if (isfromitem)
                //{
                //    if (txtBarcode.Text.Length > 12)
                //    {
                //        ClearFields();
                //        tmrBarcode.Enabled = true;
                //        isfromitem = false;
                //    }
                //}
                //else if(txtBarcode.Text.Length >= 4)
                //{
                //    ClearFields();
                //    tmrBarcode.Enabled = true;
                //}
                //if (e.KeyCode == Keys.Enter && Cmb_Item.SelectedIndex > -1)
                //{
                //    Txt_Qty.Focus();
                //}
            }
            catch (Exception ex)
            {
                // GeneralFunction.ErrMsg(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "pos_screen", "txtBarcode_KeyUp");
            }
        }
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode")
        //    {
        //        return;
        //    }

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
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Txt_Paid_KeyPress");
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
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "Txt_Paid_KeyUp");
            }
        }
        #endregion

        #region Refundamount
        void Refundamount(decimal paidamt)
        {
            try
            {
                if (paidamt > 0)
                {
                    Txt_Refund.Text = Convert.ToDecimal(Convert.ToDecimal((Txt_Total.Text != string.Empty) ? Txt_Total.Text : "0") - paidamt).ToString("####0.000");
                }
                //if (paidamt < Convert.ToDecimal(Convert.ToDecimal(Txt_Total.Text)))
                //{
                //    Txt_Refund.ForeColor = Color.Red;
                //}
                //else
                //    Txt_Refund.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "PaidRefund_KeyDown");
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

        #region ChangeRedColorButton
        private void ChangeRedColorButton()
        {
            List<POSObject> lstBtn = objPosShortcutHelper.lstButtonDetailsOne;

            lstBtn = (from p in lstBtn
                      where p.ItemID == objPosHelper.objPOSScreenBal.objPOSObject.ItemID
                      select p).ToList();

            if (lstBtn.Count > 0)
            {
                if (lstBtn[0].AdditionFlag == 1)
                {
                    string shortcut = lstBtn[0].ShortCut.ToString();
                    string btnname = "Btn_Add" + shortcut;
                    Control.ControlCollection MTB_ITEM = Grb_AdditionButton.Controls;
                    Control[] ctr = MTB_ITEM.Find(btnname, true);
                    ctr[0].BackColor = Color.Red;
                }
                else
                {

                    string shortcut = lstBtn[0].ShortCut.ToString();
                    string btnname = "Btn" + shortcut;
                    Control.ControlCollection MTB_ITEM = Tab_Buttons.Controls;
                    Control[] ctr = MTB_ITEM.Find(btnname, true);
                    Button btn = (Button)ctr[0];
                    btn.BackColor = Color.Red;
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region ClearFields
        private void ClearFields()
        {
            Cmb_Item.SelectedIndexChanged -= new EventHandler(Cmb_Item_SelectedIndexChanged);
            Cmb_Item.SelectedIndex = -1;
            Cmb_Item.Text = string.Empty;
            Txt_Price.Text = string.Empty;
            Cmb_Item.SelectedIndexChanged += new EventHandler(Cmb_Item_SelectedIndexChanged);

            // item number clear

            cmbItemNo.SelectedIndexChanged -= new EventHandler(cmbItemNo_SelectedIndexChanged);
            cmbItemNo.SelectedIndex = -1;
            cmbItemNo.Text = string.Empty;
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
        }
        #endregion

        #region setFont
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
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control btn in c.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
                Dg_Sales.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }
        #endregion

        private void Cmb_Client_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
        }
        /// <summary>
        /// Created On 15-Sept_2014 By Meena.R
        /// Fill Package Quantity fot the Item
        /// </summary>
        private void FillPackage(decimal i_Price = 0)
        {
            objPosHelper.PackageQty(i_Price);
            if (objPosHelper.Package.Count > 0)
            {
                cmbPackage.DisplayMember = "PackageQty";
                cmbPackage.ValueMember = "BarcodeID";
                cmbPackage.DataSource = objPosHelper.Package;
            }
        }

        public void BoxFunction()
        {
            if (!objPosHelper.IsPackage)
            {
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                objPosHelper.IsPackage = true;
            }
            else
            {
                btnF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                objPosHelper.IsPackage = false;
            }
            List<POSObject> lstPackageQtyforItem = (List<POSObject>)cmbPackage.DataSource;
            if (lstPackageQtyforItem != null)
            {
                if (lstPackageQtyforItem.Count > 0)
                {
                    int count = lstPackageQtyforItem.Count;
                    if (count > 1)
                    {
                        objPosHelper.IsPackage = false;
                    }
                    int selectedindex = cmbPackage.SelectedIndex + 1; ;
                    if (lstPackageQtyforItem.Count > 0)
                    {
                        if (count == selectedindex)
                        {
                            cmbPackage.SelectedIndex = 0;
                            cmbPackage_SelectedIndexChanged(null, null);//added on 11Nov2014 By Meena.R unable to load price when only one package
                        }
                        else
                        {
                            cmbPackage.SelectedIndex++;
                        }
                    }
                }
            }
        }
        #endregion

        private void btnF9_Click(object sender, EventArgs e)
        {
            BoxFunction();

        }

        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPackage.SelectedIndex > -1)
            {
                objPosHelper.packageqty = objPosHelper.Package.Where(a => a.BarcodeID == Convert.ToInt32(cmbPackage.SelectedValue)).ToList()[0].PackageQty;
                //Txt_Price.Text = objPosHelper.Package.Where(a => a.BarcodeID == Convert.ToInt32(cmbPackage.SelectedValue)).ToList()[0].Price.ToString();
                try
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.BarcodeID = Convert.ToInt32(cmbPackage.SelectedValue);
                }
                catch (Exception)
                {

                    objPosHelper.objPOSScreenBal.objPOSObject.BarcodeID = 0;
                }
                if (objPosHelper.PriceType == "NormalPrice")
                {
                    if (!objPosHelper.IsPackage)
                    {
                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.Package.Where(a => a.BarcodeID == Convert.ToInt32(cmbPackage.SelectedValue)).ToList()[0].Price.ToString())).ToString();
                    }
                    else
                    {

                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse((Math.Truncate(Convert.ToDecimal((objPosHelper.Package.Where(a => a.BarcodeID == Convert.ToInt32(cmbPackage.SelectedValue)).ToList()[0].Price) / (Convert.ToInt32(cmbPackage.Text) == 0 ? 1 : Convert.ToInt32(cmbPackage.Text))) * 1000M) / 1000M).ToString())).ToString();
                    }
                }
                else if (objPosHelper.PriceType == "WholeSalePrice" || objPosHelper.PriceType == "MinimumPrice")
                {
                    objPosHelper.GetMultiPrice();
                    if (!objPosHelper.IsPackage)
                    {
                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.objPOSScreenBal.objPOSObject.ItemPackagePrice.ToString())).ToString();
                    }
                    else
                    {
                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.objPOSScreenBal.objPOSObject.Price.ToString())).ToString();
                    }
                }

            }
        }

        private void POS_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Active User Handling 15-Feb-2019
            objPosHelper.objPOSScreenBal.objPOSObject.SaleId = 0;
            objPosHelper.UpdateActiveUserHelper();
            //
            CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.custom);
        }

        private void Cmb_Item_KeyUp(object sender, KeyEventArgs e)
        {
            //if (((int)e.KeyValue == 13))
            //{
            //    if (isfrominsert == false)
            //    {
            //        isfromitem = true;
            //        txtBarcode.Focus();
            //    }
            //    else
            //        isfrominsert = false;
            //}

            if (e.KeyValue == 13)
            {
                if (Cmb_Item.SelectedIndex > -1)
                {
                    Txt_Qty.Focus();
                    Txt_Qty.SelectAll();
                }
            }
        }

        private void POS_Screen_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPosHelper.lstGridItems = null;
            objPosHelper.lstItemDetails = null;
            objPosHelper.dicSalesDetails = null;
            objPosHelper.Package = null;
            this.Dispose();
        }
        private void RefreshItem()
        {
            Cmb_Item.SelectedIndexChanged -= new EventHandler(this.Cmb_Item_SelectedIndexChanged);
            Cmb_Item.DisplayMember = "Items";
            Cmb_Item.ValueMember = "ItemId";
            Cmb_Item.DataSource = dtPOSItems;
            this.Invoke(new MethodInvoker(delegate
            {
                Cmb_Item.SelectedIndex = -1;
            }));
            Cmb_Item.SelectedIndexChanged += new EventHandler(this.Cmb_Item_SelectedIndexChanged);
            GC.Collect();
        }

        private void Txt_Price_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Price.Text))
                objPosHelper.setPrice(Txt_Price.Text);
        }

        private void Txt_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Enter();
                    isfrominsert = false;
                    //RefreshItem();Changed Refresh method to solve the performance issue.
                    //updatedItem = objPosHelper.GetItemDetailsHelper();
                    GeneralFunction.Trace("POS_Screen_Load End");
                    dtPOSItems = objPosHelper.NewGetItemDetailsHelper();
                    //Thread Itemstart = new Thread(RefreshItem);
                    //Itemstart.Start();
                    RefreshItem();
                    GeneralFunction.Trace("POS_Screen_Load End");
                }
                catch (Exception ex)
                {
                    GeneralFunction.ErrorMessages(ex.Message, "POS Screen", "btnEnter_Click");
                }
            }

        }


        private void PriceChanging()
        {
            PriceClick();
        }

        private void Txt_Price_Enter(object sender, EventArgs e)
        {
            Txt_Price.SelectAll();
        }

        private void Dg_Sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentRowIndex = e.RowIndex;
        }

        private void btn_QuickItem_Click(object sender, EventArgs e)
        {
            ReturnOrderPopUp retrunorderpopup = new ReturnOrderPopUp();
            retrunorderpopup.ShowDialog();
        }

        public void PriceClick()
        {
            try
            {
                if (Cmb_Item.SelectedIndex > -1 && Cmb_Item.Text != string.Empty)
                {
                    if (ButtonClick == -1)
                    {
                        ButtonClick = 0;
                        objPosHelper.PriceType = "NormalPrice";
                        objPosHelper.GetMultiPrice();
                    }
                    else if (ButtonClick == 0)
                    {
                        ButtonClick = 2;
                        objPosHelper.PriceType = "WholeSalePrice";
                        if (UserScreenLimidations.WholeSale)
                            objPosHelper.GetMultiPrice();
                        else
                            GeneralFunction.Information("NoRightsWholesalePrice", "SalesInvoice");

                    }
                    else if (ButtonClick == 2)
                    {
                        ButtonClick = -1;
                        objPosHelper.PriceType = "MinimumPrice";

                        if (UserScreenLimidations.MinimumPrice)
                            objPosHelper.GetMultiPrice();
                        else
                            GeneralFunction.Information("NoRightsMinimumPrice", "SalesInvoice");

                    }
                    if (!objPosHelper.IsPackage)
                    {
                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.objPOSScreenBal.objPOSObject.ItemPackagePrice.ToString())).ToString();
                    }
                    else
                    {

                        Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(objPosHelper.objPOSScreenBal.objPOSObject.Price.ToString())).ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Dg_Sales.BackgroundColor != Color.Gray)
            {
                if (Convert.ToInt32(Lbl_OrderNo.Text) != 1)
                {
                    if (Dtp_Pos.Value.Date == DateTime.Now.Date)
                    {
                        List<long> ID = objPosHelper.GetPOSIDHelper();
                        int MaxIDIndex = ID.Count - 1;
                        if (Convert.ToInt64(Txt_InvoiceNo.Text) == ID[MaxIDIndex])
                        {

                            if (objPosHelper.ResetOrderNoSequence(Convert.ToInt64(Txt_InvoiceNo.Text)) > 0)
                                Lbl_OrderNo.Text = "1";
                        }
                        else
                            MessageBox.Show("Can't allowed to reset for intermediate invoice");
                    }
                    else
                        MessageBox.Show("Can't Allowed to reset existing day record");
                }
                else
                    MessageBox.Show("Already Reseted");
            }
            else
                MessageBox.Show("Invoice is already close can't reset");
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetItemName();
                objSaleInvoiceHelper.ButtonClick = 0;
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "cmbItemNo_SelectedIndexChanged");

            }
        }

        #region GetItemName
        public void GetItemName()
        {

            DataTable dt = new DataTable();
            if (cmbItemNo.SelectedIndex > -1)
            {

                //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt16(cmbItemNo.Text);
                objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.itemid = Convert.ToInt16(cmbItemNo.SelectedValue);

                if (objSaleInvoiceHelper.GetItemNameForID() != "")
                {
                    Cmb_Item.Text = objSaleInvoiceHelper.GetItemNameForID();
                }

            }

        }
        #endregion

        #region DiscountCalculation
        public void DiscountCalculation(string Price)
        {
            try
            {
                float isDiscountOrIncreaes = 0.0f;
                float inscreasedprice = 0.0f;
                float fltdiscount = 0.0f;
                float fltacturalprice = 0.0f;
                float fltdiscountedprice = float.Parse(Price);
                if (Price != "")
                    fltacturalprice = float.Parse(Price);
                if (Cmb_Client.Text != "")
                {
                    objPosHelper.objPOSScreenBal.objPOSObject.ClientID = Convert.ToInt32(Cmb_Client.SelectedValue);
                    fltdiscount = objPosHelper.GetDiscountForAgentHelper();
                    isDiscountOrIncreaes = objPosHelper.GetIsDiscountOrIncreaseForAgentHelper();
                    if (fltdiscount != 0.0 && fltdiscount != 0)
                    {
                        fltdiscountedprice = fltacturalprice - ((fltacturalprice * fltdiscount) / 100);
                        objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.agentdiscount = "Yes";
                    }
                    // if is not discount
                    if (isDiscountOrIncreaes == 1)
                    {
                        if (fltdiscount != 0.0 && fltdiscount != 0)
                        {
                            inscreasedprice = fltacturalprice - fltdiscountedprice;
                            fltdiscountedprice = fltacturalprice + inscreasedprice;
                        }
                    }

                    Txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse(fltdiscountedprice.ToString("#####0.000"))).ToString();

                    // Set Value in Package Object
                    if (!string.IsNullOrEmpty(Txt_Price.Text))
                        objPosHelper.setPrice(Txt_Price.Text);
                }
                else
                    Txt_Price.Text = float.Parse(Price).ToString("#####0.000");

                #region ------------- new Item Discount Adding From here MRS
                //***********************************************************************
                // Item Discount

                if (objPosHelper.objPOSScreenBal.objPOSObject.ItemType != Convert.ToInt16(CommonHelper.ItemType.Labour))
                {
                    if (objPosHelper.objPOSScreenBal.objPOSObject.ItemType == Convert.ToInt16(CommonHelper.ItemType.Goods))
                    {
                        objPosHelper.objPOSScreenBal.objPOSObject.ItemType = Convert.ToInt16(DiscountType.Goods);
                    }
                    else if (objPosHelper.objPOSScreenBal.objPOSObject.ItemType == Convert.ToInt16(CommonHelper.ItemType.SecondHand))
                    {
                        objPosHelper.objPOSScreenBal.objPOSObject.ItemType = Convert.ToInt16(DiscountType.SecondHand);
                    }
                    else if (objPosHelper.objPOSScreenBal.objPOSObject.ItemType == Convert.ToInt16(CommonHelper.ItemType.Meals))
                    {
                        objPosHelper.objPOSScreenBal.objPOSObject.ItemType = Convert.ToInt16(DiscountType.Meals);
                    }

                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : 101); //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : 101);  //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    List<POSObject> lstCatComIDForItem = new List<POSObject>();
                    lstCatComIDForItem = objPosHelper.GetCateComIDForItemBalHelper();

                    //Commented following code on 26-Nov-2014 by Seenivasan for Getting the Item Category and Company ID
                    // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : Convert.ToInt16(CommonHelper.CategoryId.Value));  //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    // objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : Convert.ToInt16(CommonHelper.CompanyId.Value));      //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    //***************************************************************************************************

                    //Added following code on 26-Nov-2014 by Seenivasan for Getting the Item Category and Company ID
                    if (lstCatComIDForItem.Count > 0)
                    {
                        objPosHelper.objPOSScreenBal.objPOSObject.CategoryId = lstCatComIDForItem[0].CategoryId;
                        objPosHelper.objPOSScreenBal.objPOSObject.CompId = lstCatComIDForItem[0].CompId;
                    }
                    else
                    {
                        //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CategoryId = Convert.ToInt32(cmbCategory.SelectedIndex != -1 && cmbCategory.Text != "" ? cmbCategory.SelectedValue : Convert.ToInt16(CommonHelper.CategoryId.Value));  //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                        //objSaleInvoiceHelper.objSaleInvoiceBAL.objSaleObject.CompanyId = Convert.ToInt32(cmbCompany.SelectedIndex != -1 && cmbCompany.Text != "" ? cmbCompany.SelectedValue : Convert.ToInt16(CommonHelper.CompanyId.Value));      //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                    }
                    //***************************************************************************************************

                    // Item Discount
                    fltacturalprice = float.Parse(Txt_Price.Text);
                    fltdiscount = objPosHelper.GetAppliedDiscountHelper();

                    if (fltdiscount != 0)
                    {
                        fltdiscountedprice = fltacturalprice - ((fltacturalprice * fltdiscount) / 100);
                        Txt_Price.Text = fltdiscountedprice.ToString("#####0.000");
                    }
                    else
                    {
                        DataTable dt = objPosHelper.GetAppliedIncreaseHelper();
                        if (dt.Rows.Count > 0)
                        {
                            bool HasIncrease = Convert.ToBoolean(dt.Rows[0]["HasIncrease"]);
                            int IncreaseType = Convert.ToInt32(dt.Rows[0]["IncreaseType"]);
                            float itemcost = dt.Rows[0]["ItemCost"] == null ? 0 : float.Parse(dt.Rows[0]["ItemCost"].ToString());
                            fltdiscount = float.Parse(dt.Rows[0]["Discount"].ToString());
                            if (HasIncrease)
                            {
                                if (IncreaseType == 2)
                                {
                                    fltdiscountedprice = fltacturalprice + ((fltacturalprice * fltdiscount) / 100);
                                    Txt_Price.Text = fltdiscountedprice.ToString("#####0.000");
                                }
                                else if (IncreaseType == 1)
                                {
                                    fltdiscountedprice = fltacturalprice + ((itemcost * fltdiscount) / 100);
                                    Txt_Price.Text = fltdiscountedprice.ToString("#####0.000");
                                }
                            }
                        }
                    }
                    //***********************************************************************
                }

                #endregion


            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Invoice", "DiscountCalculation");
            }
        }
        #endregion
        // Active User Handling 15-Feb-2019
        #region ActiveUserGetAndUpdate
        private void ActiveUserGetAndUpdate()
        {
            List<POSObject> lstActiveUser;
            try
            {
                objPosHelper.UpdateActiveUserHelper();
                lstActiveUser = objPosHelper.GetActiveUserHelper();
                txtActiveUser.Text = (lstActiveUser.Count > 0) ? lstActiveUser[0].Activuser.ToString() : "";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                lstActiveUser = null;
            }
        }
        #endregion

        private void PriceValue(string Price, int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            decimal actualprice = Convert.ToDecimal(Price);
            DataTable dt = objPosHelper.GetAppliedIncreaseHelper(CategoryID, CompanyID, ItemType, ItemNo);
            if (dt.Rows.Count > 0)
            {
                bool HasIncrease = Convert.ToBoolean(dt.Rows[0]["HasIncrease"]);
                int IncreaseType = Convert.ToInt32(dt.Rows[0]["IncreaseType"]);
                decimal itemcost = dt.Rows[0]["ItemCost"] == null ? 0 : Convert.ToDecimal(dt.Rows[0]["ItemCost"].ToString());
                decimal fltdiscount = Convert.ToDecimal(dt.Rows[0]["Discount"].ToString());
                if (HasIncrease)
                {
                    if (IncreaseType == 2)
                    {
                        actualprice = actualprice + ((actualprice * fltdiscount) / 100);
                        Txt_Price.Text = actualprice.ToString("#####0.000");
                    }
                    else if (IncreaseType == 1)
                    {
                        actualprice = actualprice + ((itemcost * fltdiscount) / 100);
                        Txt_Price.Text = actualprice.ToString("#####0.000");
                    }
                }
            }
            else
            {
                Txt_Price.Text = actualprice.ToString("#####0.000");
            }
        }



    }
}
