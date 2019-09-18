using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System.Threading;
using System.Configuration;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Sales_Return_Invoice : Form, IDisposable
    {
        
        #region Declaration

        public SalesReturnHelper objSalesReturnHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        public string FindReturnInvoice = "";
        DataTable dtallBarcode;

        public static int paymentID = 0;
        #endregion

        #region Constructor

        public Sales_Return_Invoice()
        {

            InitializeComponent();
            objSalesReturnHelper = new SalesReturnHelper();
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.QuickReturn = false;
            setFont();
            SetLanguage();
        }

        #endregion

        #region Events

        #region Form Load
        private void Sales_Return_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_client.MatchingMethod = StringMatchingMethod.UseRegexs;
                //***********Date Format Check by Seenivasan on 13-Oct-2014************************//
                dtp_todate.Format = DateTimePickerFormat.Custom;
                dtp_fromdate.Format = DateTimePickerFormat.Custom;
                dtp_returndate.Format = DateTimePickerFormat.Custom;
                dtp_todate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtp_fromdate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtp_returndate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                objSalesReturnHelper.Load();
                FIllComboBox();
                txt_balance.Text = "";
                Hidecontrols();
                objSalesReturnHelper.GetCurrentYearHelper();
                if (FindReturnInvoice != "")
                {
                    txt_returninvoiceno.Text = FindReturnInvoice;
                }
                else
                {
                    SetMaxReturnID();
                }
                Lbl_user.Visible = lblUserName.Visible = (GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice == "Y") ? true : false;
                Lbl_user.Text = GeneralFunction.UserName;
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                //cmb_item.SelectAll();//Commented on 3-July-2014 for clearing Item name when open the invoice as per client comment
                //cmb_item.Focus(); //Commented on 3-July-2014 for clearing Item name when open the invoice as per client comment
                cmb_item.SelectedIndex = -1;//Added on 3-July-2014 for clearing Item name when open the invoice as per client comment
                cmb_client.SelectedIndex = -1;//Added on 3-July-2014 for clearing client name when open the invoice as per client comment
                cmb_item.Focus();//Added on 3-July-2014

                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "Sales_Return_Invoice_Load");
            }


        }
        #endregion

        #region KeyPress Events

        #region cmb_clientno_KeyPress
        private void cmb_clientno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "SaleReturnInvoice");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "cmb_clientno_KeyPress");
            }

        }
        #endregion

        #endregion

        #region SelectedIndexChanged Events

        #region cmb_client_SelectedIndexChanged
        private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_client.SelectedIndex != -1)
                {
                    cmb_clientno.SelectedValue = cmb_client.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "cmb_client_SelectedIndexChanged");
            }

        }
        #endregion

        #region cmb_clientno_SelectedIndexChanged
        private void cmb_clientno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_clientno.SelectedIndex != -1)
                {
                    cmb_client.Text = cmb_clientno.SelectedValue.ToString();
                    SetBalance();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "cmb_clientno_SelectedIndexChanged");
            }

        }
        #endregion

        #region cmb_item_SelectedIndexChanged
        private void cmb_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmb_itemno.SelectedValue = cmb_item.SelectedValue;
                SetRowColor(cmb_item.Text);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "cmb_item_SelectedIndexChanged");
            }

        }
        public void SetRowColor(string ComboItemName)
        {
            if (dgrReturnDetails.Rows.Count == 0)
                return;
            for (int i = 0; i < dgrReturnDetails.Rows.Count; i++)
            {
                dgrReturnDetails.Rows[i].Selected = false;
                if (dgrReturnDetails.Rows[i].Cells["Description"].Value.ToString() == ComboItemName)
                {
                    dgrReturnDetails.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                    dgrReturnDetails.FirstDisplayedScrollingRowIndex = i;
                }
            }

        }
        #endregion

        #region cmb_itemno_SelectedIndexChanged
        private void cmb_itemno_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                cmb_item.SelectedValue = cmb_itemno.SelectedValue;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "cmb_itemno_SelectedIndexChanged");
            }


        }

        #endregion

        #endregion

        #region ButtonClick Events

        #region btnFind_Click
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objSalesReturnHelper.GetSaleReturnDetailsHelper();
                dgrFindReturn.AutoGenerateColumns = false;
                dgrFindReturn.DataSource = null;
                dgrFindReturn.Refresh();
                txt_Invoiceno.Clear();
                if (objSalesReturnHelper.lstFindDetails.Count > 0)
                {
                    if (txt_Invoiceno.Text == string.Empty)
                    {
                        dgrFindReturn.DataSource = objSalesReturnHelper.lstFindDetails;
                    }
                    else
                    {
                        GetNewYearReceiptNo();//this method add on 09Oct2015 to fix issue in search by Meena.R
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno = objSalesReturnHelper.SaleIDFromyearSequence();
                        dgrFindReturn.DataSource = objSalesReturnHelper.lstFindDetails.Where(a => a.saleid == objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno).ToList();
                    }
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "SaleReturnInvoice");
                }
                if (rbnItem.Checked == true) //Added on 3-July-2014 for setting focus when finding the details by Seenivasan
                {
                    txt_returnquantity.Focus();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnFind_Click");
            }
        }

        #endregion

        #region btnNewInvoice_Click
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                NewInvoice();
                //dgrReturnDetails.BackgroundColor = Color.Beige; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgrReturnDetails.BackgroundColor = Color.WhiteSmoke;
                dtp_returndate.Value = DateTime.Now;
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.New), Txt_NewInvoiceNo.Text, "SaleReturn", "New sale return invoice details", Convert.ToInt16(InvoiceAction.Yes));
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnNewInvoice_Click");
            }
        }
        #endregion

        #region btnReturn_Click
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnItem();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnReturn_Click");
            }
        }
        #endregion

        #region btnExit_Click
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region btnUndoReturn_Click
        private void btnUndoReturn_Click(object sender, EventArgs e)
        {
            try
            {
                UndoReturnItem();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnUndoReturn_Click");
            }

        }
        #endregion

        #region btnCloseInvoice_Click
        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                if (dgrReturnDetails != null && dgrReturnDetails.Rows.Count > 0)
                {
                    objSalesReturnHelper.lstReturnedDetails = (List<SaleReturnObjectClass>)dgrReturnDetails.DataSource;
                }
                objSalesReturnHelper.CloseInvoice();


                if (dgrReturnDetails.Rows.Count > 0)
                {
                    if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaveReturnInvoice)
                    {
                        dgrReturnDetails.AutoGenerateColumns = false;
                        dgrReturnDetails.DataSource = null;
                        dgrReturnDetails.DataSource = objSalesReturnHelper.lstReturnedDetails;
                        //if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno != null)
                        //{
                        //    if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno.ToString() == "101")
                        //    {
                        //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceAgent = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno;
                        //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceFromDate = DateTime.Now;
                        //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceToDate = DateTime.Now;
                        //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceStatus = "1";
                        //objSalesReturnHelper.PayReceiptForCashClient();
                        // objSalesReturnHelper.GetMaxIDOFPaymentDetails();//Commented on 4-June-2014 
                        //    }
                        //}
                        dgrReturnDetails.BackgroundColor = System.Drawing.Color.Gray;
                        dgrReturnDetails.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
                        Lbl_user.Text = GeneralFunction.UserName + " " + dtp_returndate.Value.ToShortTimeString();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Save), Txt_NewInvoiceNo.Text, "SaleReturn", "Save(close) sale return invoice details", Convert.ToInt16(InvoiceAction.Yes));
                    }
                    else
                    {
                        GeneralFunction.Information("FailedSaveInvoice", "SaleReturnInvoice");
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnCloseInvoice_Click");
            }
        }
        #endregion

        #region btnModifyInvoice_Click
        private void btnModifyInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Reason != "Quick Return")
                {
                    bool enable = false;

                    if (UserScreenLimidations.ModifyInvoice)
                    {
                        enable = true;
                    }
                    else if (UserScreenLimidations.ModifyTodayInvoice)
                    {
                        String s = DateTime.Now.ToShortDateString();
                        // if (Convert.ToDateTime(dtp_returndate.Value).ToShortDateString() == s)//Commented on 29-May-2014
                        if (DateTime.Compare(Convert.ToDateTime(dtp_returndate.Value.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString())) == 0)
                            enable = true;
                        else
                            enable = false;
                    }
                    if (enable)
                    {
                        SetObjectFromControl();
                        objSalesReturnHelper.ModifyInvoice();
                        if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ModifyReturnInvoice)
                        {
                            dgrReturnDetails.AutoGenerateColumns = false;
                            dgrReturnDetails.DataSource = null;
                            dgrReturnDetails.DataSource = objSalesReturnHelper.lstReturnedDetails;

                            //dgrReturnDetails.BackgroundColor = System.Drawing.Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                            dgrReturnDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
                            dgrReturnDetails.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Modify), Txt_NewInvoiceNo.Text, "SaleReturn", "Modify sale return invoice details", Convert.ToInt16(InvoiceAction.Yes));
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("UserCantModifyInvoice", "SaleReturnInvoice");
                    }
                }
                else
                {
                    GeneralFunction.Information("UserCantModifyQuickReturnInvoice", "SaleReturnInvoice");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnModifyInvoice_Click");
            }
        }
        #endregion

        #region btnNavigation_Click
        private void btnNavigation_Click(object sender, EventArgs e)
        {
            try
            {
                objSalesReturnHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt64(txt_returninvoiceno.Text);
                ClearAll();
                objSalesReturnHelper.NavigationEvent();
                txt_returninvoiceno.Text = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno.ToString();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnNavigation_Click");
            }
        }
        #endregion

        #region btnPayReciept_Click
        private void btnPayReciept_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrReturnDetails.BackgroundColor == System.Drawing.Color.Gray)
                {
                    SetObjectFromControl();
                    objSalesReturnHelper.PayReceipt();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnPayReciept_Click");
            }
        }
        #endregion


        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if ((GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") & (dgrReturnDetails.BackgroundColor != Color.Gray))
                {
                    GeneralFunction.Information("Pleaseclosetheinvoicefirst", "SaleReturnInvoice");
                    return;
                }
                SetObjectFromControl();
                objSalesReturnHelper.Print();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "SaleReturnInvoice", "SALE_RETURN", "Print sale return invoice details", Convert.ToInt32(InvoiceAction.Yes));
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "btnPrint_Click");
            }

        }
        #endregion


        #endregion

        #region Text Changed Events

        #region txt_returninvoiceno_TextChanged
        private void txt_returninvoiceno_TextChanged(object sender, EventArgs e)
        {
            int Status = 0;

            if (txt_returninvoiceno.Text != "")
            {
                objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaleReturnID = Convert.ToInt64(txt_returninvoiceno.Text);
                objSalesReturnHelper.SetNewYearInvoiceNo();
                Txt_NewInvoiceNo.Text = (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.NewYearInvoiceNo != "" ? objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.NewYearInvoiceNo : "");
                objSalesReturnHelper.lstReturnedDetails.Clear();
                //objSalesReturnHelper.GetReturnDetails();

                //   List<SaleReturnObjectClass> lstReturnDetails = objSalesReturnHelper.lstReturnedDetails;
                List<SaleReturnObjectClass> lstReturnDetails = objSalesReturnHelper.GetReturnDetails();

                if (lstReturnDetails.Count > 0)
                {
                    txt_returnclient.Text = lstReturnDetails[0].ClientName;
                    string[] returndetail = new string[15];
                    Decimal totalretvalue = 0;//Added on 23-June-2014 for Avoiding Performance Issues
                    for (int i = 0; i < lstReturnDetails.Count; i++)
                    {
                        if (lstReturnDetails[i].SaleDate != DateTime.MinValue)
                        {
                            dtp_returndate.Value = lstReturnDetails[i].SaleDate;
                        }
                        else
                        {
                            dtp_returndate.Value = DateTime.Now;
                        }


                        //  returndetail[0] = dt.Rows[i]["itemno"].ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = lstReturnDetails[i].itemno;
                        //  returndetail[1] = dt.Rows[i]["item"].ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName = lstReturnDetails[i].ItemName;
                        // cmb_item.Text = lstReturnDetails[i].ItemName;//Commented on 23-June-2014 for Avoiding Performance issue-> it is calling Item selection changed event every time for every row


                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = lstReturnDetails[i].expiry;

                        // returndetail[3] = dt.Rows[i]["package"].ToString();

                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.package = lstReturnDetails[i].package;
                        //returndetail[4] = dt.Rows[i]["quantiy"].ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = lstReturnDetails[i].Quantity;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = (lstReturnDetails[i].unitprice.ToString() != "") ? Convert.ToDecimal(lstReturnDetails[i].unitprice.ToString("#####0.000")) : 0;

                        //  returndetail[6] = (dt.Rows[i]["total"].ToString() != "") ? Convert.ToDecimal(dt.Rows[i]["total"].ToString()).ToString("#####0.000") : "0.000";
                        //  returndetail[7] = dt.Rows[i]["mtb_time"].ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Time = lstReturnDetails[i].Time;
                        //  returndetail[8] = dt.Rows[i]["ruser"].ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.UserName = lstReturnDetails[i].UserName;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user = lstReturnDetails[i].user;

                        // returndetail[9] = "Returned";

                        // returndetail[10] = dt.Rows[i]["saleid"].ToString();

                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid = lstReturnDetails[i].saleid;


                        if (lstReturnDetails[i].status == Convert.ToInt16(SalesInvoiceType.ClosedInvoice))
                        {
                            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaleReturnID = lstReturnDetails[i].SaleReturnID;
                            Lbl_user.Text = lstReturnDetails[i].UserName;
                        }
                        else
                        {
                            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaleReturnID = 0;
                            Lbl_user.Text = GeneralFunction.UserName;
                        }

                        Status = lstReturnDetails[i].status;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = lstReturnDetails[i].serialno;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid = lstReturnDetails[i].saledetid;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Newexpr = lstReturnDetails[i].Newexpr;

                        //--------------This is added due to Item number binding into grid
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemNumber = lstReturnDetails[i].ItemNumber;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BarcodeID = lstReturnDetails[i].BarcodeID;
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Reason = lstReturnDetails[i].Reason;

                        //--------------------
                        // Below code Added  on 23-June-2014 for calculating txt_totalreturnvalue.Text value when reading the list itself instead of looping again Grid after grid assignment and Avoiding Performance issue
                        totalretvalue = totalretvalue + Convert.ToDecimal(objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity);
                        objSalesReturnHelper.AddReturnedListFromDB();
                    }

                    dgrReturnDetails.AutoGenerateColumns = false;
                    dgrReturnDetails.DataSource = null;
                    dgrReturnDetails.DataSource = objSalesReturnHelper.SortInvoiceDetails(objSalesReturnHelper.lstReturnedDetails, "ItemName", "unitprice");

                    //Total Returned Value Calculation//

                    //float totalretvalue = 0.0f; // Commented on 23-June-2014 for Avoiding Performance issue
                    if (dgrReturnDetails.Rows.Count > 0)
                    {
                        //**************Commented on 23-June-2014 for Avoiding Performance issue*****************************
                        //for (int i = 0; i < dgrReturnDetails.Rows.Count; i++)
                        //{
                        //    totalretvalue = totalretvalue + float.Parse(dgrReturnDetails.Rows[i].Cells["TotalPrice"].Value.ToString());
                        //    txt_totalreturnvalue.Text = totalretvalue.ToString("####0.000");
                        //}
                        // **************************************************************************************************

                        //Added on 23-June-2014 for Avoiding Performance issue instead of above looping to calculate totatlreturn value
                        txt_totalreturnvalue.Text = totalretvalue.ToString("####0.000");

                        if (dgrReturnDetails.SelectedRows[0].Cells["SaleID"].Value.ToString() != "")
                        {
                            cmb_item.Text = dgrReturnDetails.SelectedRows[0].Cells["Description"].Value.ToString();
                            txt_Invoiceno.Text = "";
                            //txt_Invoiceno.Text = dgrReturnDetails.SelectedRows[0].Cells["SaleID"].Value.ToString();Commended by Meena.R on 03/02/2015
                            txt_Invoiceno.Text = dgrReturnDetails.Rows[0].Cells["SaleID"].Value.ToString();

                        }

                    }

                    else
                    {
                        txt_returnclient.Text = "";
                        txt_totalreturnvalue.Text = "";
                    }

                    //******************************************************************************************//

                    if (Status == Convert.ToInt16(SalesInvoiceType.ClosedInvoice))
                    {
                        dgrReturnDetails.BackgroundColor = System.Drawing.Color.Gray;
                        dgrReturnDetails.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
                        Lbl_user.Text = Lbl_user.Text + " " + dtp_returndate.Value.ToShortTimeString();

                    }
                    else
                    {
                        //dgrReturnDetails.BackgroundColor = System.Drawing.Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                        dgrReturnDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
                        dgrReturnDetails.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        Lbl_user.Text = Lbl_user.Text;
                    }
                }
                else
                {
                    //dgrReturnDetails.BackgroundColor = System.Drawing.Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    dgrReturnDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
                    dgrReturnDetails.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    Lbl_user.Text = Lbl_user.Text;
                }

            }

        }
        #endregion

        #region txt_Invoiceno_TextChanged
        private void txt_Invoiceno_TextChanged(object sender, EventArgs e)
        {

            try
            {
                invoicenokeydown();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "txt_Invoiceno_TextChanged");
            }
        }
        #endregion



        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {

            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find") + "        ";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print") + "         ";
            this.Text = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
            chkAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblClient.Text = Additional_Barcode.GetValueByResourceKey("Client");
            lblClientName.Text = Additional_Barcode.GetValueByResourceKey("ClientName");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            lblReturnInvoice.Text = Additional_Barcode.GetValueByResourceKey("ReturnInv");
            lblReturnQty.Text = Additional_Barcode.GetValueByResourceKey("ReturnQty");
            lblSearchIn.Text = Additional_Barcode.GetValueByResourceKey("SearchIn");
            lblTotalReturnedValue.Text = Additional_Barcode.GetValueByResourceKey("TReturnValue");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInv") + "        ";
            btnExit.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "          ";
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModInv") + "         ";
            btnNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("NewInv") + "        ";
            btnPayReciept.Text = Additional_Barcode.GetValueByResourceKey("SaleReturnReceipt") + "        ";
            btnReturn.Text = Additional_Barcode.GetValueByResourceKey("Return") + "        ";
            btnUndoReturn.Text = Additional_Barcode.GetValueByResourceKey("UndoReturn") + "   ";
            rbnInvoice.Text = Additional_Barcode.GetValueByResourceKey("ReturnByInvoice");
            rbnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnByItem");
            lblClientNo.Text = Additional_Barcode.GetValueByResourceKey("ClientNo");


            dgrFindReturn.Columns["newinvno"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            dgrFindReturn.Columns["NewYearInvoiceNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            dgrFindReturn.Columns["Item1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Item");
            dgrFindReturn.Columns["date1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgrFindReturn.Columns["client1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Client");
            dgrFindReturn.Columns["package1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgrFindReturn.Columns["Qty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgrFindReturn.Columns["Total1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgrFindReturn.Columns["Expiry1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgrFindReturn.Columns["User1"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgrFindReturn.Columns["Returned1"].HeaderText = Additional_Barcode.GetValueByResourceKey("ReturnQty");
            dgrFindReturn.Columns["ItemID"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemId");
            dgrFindReturn.Columns["serialno"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");

            dgrReturnDetails.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNumber");
            dgrReturnDetails.Columns["Description"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgrReturnDetails.Columns["Expirys"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgrReturnDetails.Columns["PackageQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgrReturnDetails.Columns["Quanty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgrReturnDetails.Columns["UnitPrices"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgrReturnDetails.Columns["TotalPrice"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgrReturnDetails.Columns["Times"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");

            //dgrFindReturn.Columns["newinvno"].ToolTipText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            //dgrFindReturn.Columns["Item1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Item");
            //dgrFindReturn.Columns["date1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Date");
            //dgrFindReturn.Columns["client1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Client");
            //dgrFindReturn.Columns["package1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Package");
            //dgrFindReturn.Columns["Qty"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Quantity");
            //dgrFindReturn.Columns["Total1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Total");
            //dgrFindReturn.Columns["Expiry1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Expiry");
            //dgrFindReturn.Columns["User1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("User");
            //dgrFindReturn.Columns["Returned1"].ToolTipText = Additional_Barcode.GetValueByResourceKey("ReturnQty");
            //dgrFindReturn.Columns["ItemID"].ToolTipText = Additional_Barcode.GetValueByResourceKey("ItemId");

            //dgrReturnDetails.Columns["ItemNumber"].ToolTipText = Additional_Barcode.GetValueByResourceKey("ItemNumber");
            //dgrReturnDetails.Columns["Description"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Description");
            //dgrReturnDetails.Columns["Expirys"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Expiry");
            //dgrReturnDetails.Columns["PackageQty"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Package");
            //dgrReturnDetails.Columns["Quanty"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Pieces");
            //dgrReturnDetails.Columns["UnitPrices"].ToolTipText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            //dgrReturnDetails.Columns["TotalPrice"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Total");
            //dgrReturnDetails.Columns["Times"].ToolTipText = Additional_Barcode.GetValueByResourceKey("Time");


        }

        #endregion

        #region FIllComboBox
        private void FIllComboBox()
        {
            DataTable dtDetails = objSalesReturnHelper.GetItemLoadDetails();//add on 09jan2015 to load item details 
            cmb_client.SelectedIndexChanged -= new EventHandler(cmb_client_SelectedIndexChanged);
            cmb_clientno.SelectedIndexChanged -= new EventHandler(cmb_clientno_SelectedIndexChanged);
            cmb_item.SelectedIndexChanged -= new EventHandler(cmb_item_SelectedIndexChanged);
            cmb_itemno.SelectedIndexChanged -= new EventHandler(cmb_itemno_SelectedIndexChanged);

            cmb_item.DisplayMember = "Name";
            cmb_item.ValueMember = "ID";
            cmb_item.DataSource = dtDetails;//objSalesReturnHelper.lstItem.Where(i => i.IsHide == false).ToList();
            cmb_item.SelectedIndex = -1;

            cmb_itemno.DisplayMember = "ItemNumber";
            cmb_itemno.ValueMember = "ID";
            DataView dvData = new DataView(dtDetails);
            dvData.RowFilter = "ItemNumber<>''";
            cmb_itemno.DataSource = dvData.ToTable(); //objSalesReturnHelper.lstItem.Where(i => i.ItemNumber != string.Empty & i.IsHide == false).ToList();
            cmb_itemno.SelectedIndex = -1;

            cmb_clientno.DisplayMember = "AgentId";
            cmb_clientno.ValueMember = "Name";
            cmb_clientno.DataSource = objSalesReturnHelper.lstClient;
            cmb_client.SelectedIndex = -1;

            cmb_client.DisplayMember = "Name";
            cmb_client.ValueMember = "AgentId";
            cmb_client.DataSource = objSalesReturnHelper.lstClient;
            cmb_clientno.SelectedIndex = -1;

            cmb_client.SelectedIndexChanged += new EventHandler(cmb_client_SelectedIndexChanged);
            cmb_clientno.SelectedIndexChanged += new EventHandler(cmb_clientno_SelectedIndexChanged);
            cmb_item.SelectedIndexChanged += new EventHandler(cmb_item_SelectedIndexChanged);
            cmb_itemno.SelectedIndexChanged += new EventHandler(cmb_itemno_SelectedIndexChanged);
        }
        #endregion

        #region Hidecontrols
        public void Hidecontrols()
        {
            dgrFindReturn.Columns["package1"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgrReturnDetails.Columns["PackageQty"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgrReturnDetails.Columns["ItemNumber"].Visible = lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            cmb_itemno.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = (UserScreenLimidations.Print) ? true : false;
            btnModifyInvoice.Enabled = ((UserScreenLimidations.ModifyInvoice) || (UserScreenLimidations.ModifyTodayInvoice)) ? true : false;
            button_increase.Enabled = button_decrease.Enabled = button_invoice_start.Enabled = button_invoice_end.Enabled = (UserScreenLimidations.InvoiceNavigation) ? true : false;
            txt_Invoiceno.ReadOnly = (UserScreenLimidations.InvoiceNavigation) ? false : true; //Commented on 5-May-2014
            btnPayReciept.Enabled = (UserScreenLimidations.PayReceipt) ? true : false;
            dgrReturnDetails.Columns["Times"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;

        }

        #endregion

        #region SetBalance
        private void SetBalance()
        {

            SetObjectFromControl();
            objSalesReturnHelper.GetBalance();
            txt_balance.ForeColor = (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Balance >= 0) ? Color.Green : Color.Red;
            txt_balance.Text = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Balance.ToString("#######0.000");

        }
        #endregion

        #region SetObjectFromControl
        private void SetObjectFromControl()
        {

            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceAgent = (cmb_clientno.Text != "" ? Convert.ToInt16(cmb_clientno.Text) : 0);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceFromDate = Convert.ToDateTime(dtp_fromdate.Value.ToString());
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceToDate = Convert.ToDateTime(dtp_todate.Value.ToString());
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceStatus = "1";

            //***************FInd Method Object Binding*******************************//
            //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16((cmb_itemno.SelectedIndex > -1 && cmb_itemno.Text != "") ? cmb_itemno.SelectedValue.ToString() : "0");//Commented on 30-June-2014 for Avoiding itemno assigned as "0" by Seenivasan
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16((cmb_item.SelectedIndex > -1 && cmb_item.Text != "") ? cmb_item.SelectedValue.ToString() : "0");//Added on 30-June-2014 for Avoiding itemno assigned as "0" by Seenivasan
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16((rbnInvoice.Checked == true) ? 0 : objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.fromdate = Convert.ToDateTime(dtp_fromdate.Value.Date);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.todate = Convert.ToDateTime(dtp_todate.Value.Date);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno = Convert.ToInt16((cmb_clientno.SelectedIndex > -1 && cmb_clientno.Text != "") ? cmb_clientno.Text : "0");
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno = 0;
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.all = (chkAll.Checked == true) ? "YES" : "NO";
            //***********************************************************************//

            //Return Button Method object binding
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemSelectedVal = (cmb_item.SelectedIndex != -1 ? cmb_item.SelectedValue : 0);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.RadInvoiceCheked = rbnInvoice.Checked;
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.RadItemCheked = rbnItem.Checked;
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.dgrSelectedRowCount = (dgrFindReturn != null && dgrFindReturn.Rows.Count > 0 ? dgrFindReturn.SelectedRows.Count : 0);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SelectedRowQty = (dgrFindReturn != null && dgrFindReturn.Rows.Count > 0 ? (dgrFindReturn.SelectedRows.Count > 0 ? Convert.ToInt16(dgrFindReturn.SelectedRows[0].Cells["Qty"].Value) : 0) : 0);
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ReturnQtyText = txt_returnquantity.Text;

            //Undo Return Object binding
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DgrReturnBacgrndColor = dgrReturnDetails.BackgroundColor.ToString();
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DgrReturnSelectdRowCount = (dgrReturnDetails != null && dgrReturnDetails.Rows.Count > 0 ? dgrReturnDetails.SelectedRows.Count : 0);

            //Close Invoice Object Binding
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DtpReturnedDateEnabled = dtp_returndate.Enabled;
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returndate = dtp_returndate.Value;
            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = (txt_returninvoiceno.Text != "" ? Convert.ToInt64(txt_returninvoiceno.Text) : 0);


            //Modify Invoice Object Binding

            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SelectedRowCount = (dgrReturnDetails != null && dgrReturnDetails.Rows.Count > 0 ? dgrReturnDetails.SelectedRows.Count : 0);

        }
        #endregion

        #region NewInvoice
        private void NewInvoice()
        {
            try
            {
                objSalesReturnHelper.NewbtnYearInvoice();
                txt_returninvoiceno.Text = objSalesReturnHelper.InvoiceID[0].ToString();
                Txt_NewInvoiceNo.Text = objSalesReturnHelper.InvoiceID[2].ToString();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }


        }
        #endregion

        #region ReturnItem

        private void ReturnItem()
        {
            List<SaleReturnObjectClass> lstFind;
            List<SaleReturnObjectClass> lstNew;
            try
            {
                bool updatequant = false;
                bool IsSaved = false;
                int lstCount = 0;
                if (dgrReturnDetails.BackgroundColor != Color.Gray)
                {
                    SetObjectFromControl();

                    if (objSalesReturnHelper.ValidateReturnItem())
                    {

                        DataGridViewRow _dgvRow = new DataGridViewRow();
                        _dgvRow = dgrFindReturn.SelectedRows[0];
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedInvoice = "";
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedDetailID = "";
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedInvoice = _dgvRow.Cells["sale_id"].Value.ToString();
                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedDetailID = _dgvRow.Cells["saledet_id"].Value.ToString();

                        //txt_Invoiceno.Text = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedInvoice;unable return the invoice Changed By Meena.R on 25Nov2014
                        txt_Invoiceno.Text = _dgvRow.Cells["NewYearInvoiceNo"].Value.ToString();

                        lstFind = objSalesReturnHelper.FilterFindList();

                        lstNew = (List<SaleReturnObjectClass>)dgrFindReturn.DataSource;
                        int datarowno = lstNew.FindIndex(a => (a.saledetid == Convert.ToInt64(objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedDetailID)));
                        dgrFindReturn.Rows[datarowno].Selected = true;
                        _dgvRow = dgrFindReturn.SelectedRows[0];

                        int count = 0;

                        #region For Loop

                        for (int i = 0; i < lstFind.Count; i++)
                        {

                            if ((lstFind[i].saleid.ToString() == objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedInvoice))
                            {
                                count += 1;

                                if ((rbnInvoice.Checked == true))
                                {
                                    long selectedrow = lstFind[i].saledetid;
                                    int noofrow = dgrFindReturn.Rows.Count;
                                    lstNew = (List<SaleReturnObjectClass>)dgrFindReturn.DataSource;
                                    datarowno = lstNew.FindIndex(a => (a.saledetid == selectedrow));
                                    dgrFindReturn.Rows[datarowno].Selected = true;
                                    _dgvRow = dgrFindReturn.SelectedRows[0];
                                }


                                if (dgrFindReturn.SelectedRows[0].Cells["Qty"].Value.ToString() != "0")
                                {

                                    if (dgrReturnDetails.Rows.Count == 0)
                                    {
                                        txt_returnclient.Text = dgrFindReturn.SelectedRows[0].Cells["client1"].Value.ToString();
                                    }


                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ClientName = txt_returnclient.Text;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt64(txt_returninvoiceno.Text);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid = Convert.ToInt64(_dgvRow.Cells["sale_id"].Value);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName = _dgvRow.Cells["Item1"].Value.ToString();
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16(_dgvRow.Cells["ItemID"].Value);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid = Convert.ToInt64(_dgvRow.Cells["saledet_id"].Value);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = (rbnItem.Checked) ? int.Parse((txt_returnquantity.Text != string.Empty) ? txt_returnquantity.Text : "1") : int.Parse(_dgvRow.Cells["Qty"].Value.ToString());
                                    float unitprice = float.Parse(dgrFindReturn.SelectedRows[0].Cells["Total1"].Value.ToString()) / (float.Parse(dgrFindReturn.SelectedRows[0].Cells["Qty"].Value.ToString()));
                                    float total = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity * unitprice;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = Convert.ToDecimal(unitprice);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returndate = DateTime.Now;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.mtb_updation = 0;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user = GeneralFunction.UserId;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = Convert.ToInt16(SalesInvoiceType.NormalInvoice);

                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = Convert.ToDateTime((_dgvRow.Cells["Expiry1"].Value.ToString() != DateTime.MinValue.ToString()) ? _dgvRow.Cells["Expiry1"].Value.ToString() : "01/01/1900");
                                    //if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry.ToString() == "1/1/1900 12:00:00 AM")
                                    if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry.ToString() == "1/1/1900 12:00:00 AM" || objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry.Value.ToString("yyyy") == "1900")
                                    {
                                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = null;
                                    }
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = _dgvRow.Cells["serialno"].Value.ToString();
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid = Convert.ToInt64(_dgvRow.Cells["saledet_id"].Value);
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.package = Convert.ToInt32(_dgvRow.Cells["package1"].Value.ToString());

                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Newexpr = Convert.ToDateTime((_dgvRow.Cells["Newexpr"].Value.ToString() != DateTime.MinValue.ToString()) ? _dgvRow.Cells["Newexpr"].Value.ToString() : "01/01/1900");
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.createdby = GeneralFunction.UserId;
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.modifiedby = GeneralFunction.UserId;


                                    // This is added due to Binding the  Item  Number in the grid
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemNumber = _dgvRow.Cells["ItemNum"].Value.ToString();
                                    //

                                    // This is added due to Binding the BarcodeID in the grid
                                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BarcodeID = Convert.ToInt32(_dgvRow.Cells["Barcode"].Value);
                                    //
                                    //*************Updation******************//

                                    for (int ij = 0; ij < dgrReturnDetails.Rows.Count; ij++)
                                    {
                                        if (dgrFindReturn.SelectedRows[0].Cells["client1"].Value.ToString() != txt_returnclient.Text)
                                        {
                                            GeneralFunction.ErrInfo("NotPossibleReturnInvoice", "SaleReturnInvoice");
                                            goto end;
                                        }
                                        else if (dgrReturnDetails.Rows[ij].Cells["SaleDetId"].Value.ToString() == _dgvRow.Cells["saledet_id"].Value.ToString())
                                        {
                                            //_dtReturnedData.AcceptChanges();
                                            //_dtReturnedData.Rows[ij]["Quantity"] = int.Parse(_dtReturnedData.Rows[ij]["Quantity"].ToString()) + obj_return_sale.returnquantity;
                                            //_dtReturnedData.Rows[ij]["Total"] = (int.Parse(_dtReturnedData.Rows[ij]["Quantity"].ToString()) * float.Parse(_dtReturnedData.Rows[ij]["UnitPrice"].ToString())).ToString("#####0.000");

                                            objSalesReturnHelper.lstReturnedDetails[ij].returnquantity = objSalesReturnHelper.lstReturnedDetails[ij].returnquantity + objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity;
                                            objSalesReturnHelper.lstReturnedDetails[ij].Total = Convert.ToDecimal(objSalesReturnHelper.lstReturnedDetails[ij].unitprice * objSalesReturnHelper.lstReturnedDetails[ij].returnquantity);
                                            updatequant = true;
                                            objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.mtb_updation = 1;
                                            goto updation;
                                        }

                                    }


                                    //*************Upto Here*****************//
                                    lstCount = objSalesReturnHelper.lstReturnedDetails.Count;
                                    if (updatequant != true) { objSalesReturnHelper.AddReturnedListOnReturn(); }

                                    updation: if (objSalesReturnHelper.SaveSaleReturnDetailsHelper())
                                    {
                                        IsSaved = true;
                                        dgrFindReturn.SelectedRows[0].Cells["Qty"].Value = int.Parse(dgrFindReturn.SelectedRows[0].Cells["Qty"].Value.ToString()) - objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity;
                                        dgrFindReturn.SelectedRows[0].Cells["Total1"].Value = (int.Parse(dgrFindReturn.SelectedRows[0].Cells["Qty"].Value.ToString()) * Convert.ToDecimal(objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice)).ToString("#####0.000");
                                        dgrFindReturn.SelectedRows[0].Cells["Returned1"].Value = int.Parse(dgrFindReturn.SelectedRows[0].Cells["Returned1"].Value.ToString()) + objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity;
                                    }
                                    else
                                    {
                                        if (objSalesReturnHelper.lstReturnedDetails.Count > 0)
                                        {
                                            if (lstCount != objSalesReturnHelper.lstReturnedDetails.Count)
                                            {
                                                objSalesReturnHelper.lstReturnedDetails.RemoveAt(objSalesReturnHelper.lstReturnedDetails.Count - 1);
                                            }
                                        }

                                    }

                                }
                                if (rbnItem.Checked == true)
                                {
                                    break;
                                }

                            }

                        }

                        #endregion
                        if (IsSaved)
                        {
                            dgrReturnDetails.AutoGenerateColumns = false;
                            dgrReturnDetails.DataSource = null;
                            dgrReturnDetails.DataSource = objSalesReturnHelper.SortInvoiceDetails(objSalesReturnHelper.lstReturnedDetails, "ItemName", "unitprice");
                        }
                        //else
                        //{
                        //    int index = -1;
                        //    index = objSalesReturnHelper.lstReturnedDetails.FindIndex(a => (a.itemno == objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno));
                        //    if (index != -1)
                        //    {
                        //        objSalesReturnHelper.lstReturnedDetails.RemoveAt(index);
                        //    }
                        //}
                        //dgrReturnDetails.SelectionChanged += new System.EventHandler(this.salereturn2_selectionchange);
                        if (dgrReturnDetails.Rows.Count > 0)
                        {
                            dgrReturnDetails.Rows[0].Selected = false;
                            dgrReturnDetails.Rows[0].Selected = true;
                        }

                        TotalReturnValue();

                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Return), Txt_NewInvoiceNo.Text, "Sale Return", "Return sale return invoice details", Convert.ToInt16(InvoiceAction.Yes));

                    }


                }

                else
                {
                    GeneralFunction.Information("CantModifyClosedInvoice", "SaleReturnInvoice");
                }
                end:;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "ReturnItem");
            }
            finally
            {
                lstFind = null;
                lstNew = null;
            }
        }

        #endregion

        #region UndoReturnItem

        private void UndoReturnItem()
        {
            List<SaleReturnObjectClass> lstStock;
            try
            {
                SetObjectFromControl();
                if (objSalesReturnHelper.ValidateUndoReturnItem())
                {
                    string selectedinv;
                    if (dgrReturnDetails.SelectedRows.Count > 0)
                        selectedinv = dgrReturnDetails.SelectedRows[0].Cells["SaleID"].Value.ToString();
                    else
                        selectedinv = dgrReturnDetails.Rows[0].Cells["SaleID"].Value.ToString();

                    for (int i = 0; i < dgrFindReturn.Rows.Count; i++)
                    {
                        int remaining = 0;
                        for (int j = 0; j < dgrReturnDetails.Rows.Count; j++)
                        {

                            if ((dgrReturnDetails.Rows[j].Cells["SaleID"].Value.ToString() == selectedinv))
                            {
                                if ((rbnInvoice.Checked == true))
                                {
                                    dgrReturnDetails.Rows[j].Selected = true;

                                }
                                if (dgrReturnDetails.SelectedRows.Count > 0)
                                {
                                    if ((dgrFindReturn.Rows[i].Cells["saledet_id"].Value.ToString() == dgrReturnDetails.SelectedRows[0].Cells["SaleDetId"].Value.ToString()))
                                    {

                                        int x = int.Parse(dgrReturnDetails.SelectedRows[0].Index.ToString());
                                        int quantity = (rbnItem.Checked) ? (int.Parse((txt_returnquantity.Text != string.Empty) ? txt_returnquantity.Text : "1")) : int.Parse(dgrReturnDetails.SelectedRows[0].Cells["Quanty"].Value.ToString());
                                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid = Convert.ToInt64(dgrReturnDetails.SelectedRows[0].Cells["SaleDetId"].Value);

                                        //**********************Stock For Undo Return****************************************
                                        int stockqtyforundo = 0;
                                        lstStock = objSalesReturnHelper.GetStockForUndoHelper();
                                        stockqtyforundo = ((lstStock.Count > 0) && (lstStock[0].Stock.ToString() != "0")) ? lstStock[0].Stock : 0;
                                        int type = ((lstStock.Count > 0) && (lstStock[0].ItemType.ToString() != "")) ? lstStock[0].ItemType : 1;
                                        if (type == Convert.ToInt16(ItemType.Meals) | type == Convert.ToInt16(ItemType.Labour)) { stockqtyforundo = quantity; }
                                        if (stockqtyforundo < quantity)
                                        {
                                            string strMsg = GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty");
                                            GeneralFunction.ErrInfo(strMsg + " " + stockqtyforundo.ToString(), "SaleReturnInvoice");
                                            if (GeneralFunction.Question("Doyouwanttocontinue", "SaleReturnInvoice") != DialogResult.Yes)
                                                return;
                                        }

                                        quantity = (stockqtyforundo >= quantity) ? quantity : stockqtyforundo;


                                        //********************Upto Here******************************************************

                                        remaining = (rbnInvoice.Checked != true) ? (int.Parse(dgrReturnDetails.SelectedRows[0].Cells["Quanty"].Value.ToString()) - int.Parse((txt_returnquantity.Text != string.Empty) ? txt_returnquantity.Text : "1")) : int.Parse(dgrReturnDetails.SelectedRows[0].Cells["Quanty"].Value.ToString());
                                        if (remaining < 0)
                                        {
                                            GeneralFunction.Information("UndoReturnQtylessthanReturnedQty", "SaleReturnInvoice");
                                            return;
                                        }
                                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = quantity;
                                        float unitprice = float.Parse(dgrReturnDetails.SelectedRows[0].Cells["UnitPrices"].Value.ToString());
                                        int qu = Convert.ToInt32(dgrReturnDetails.SelectedRows[0].Cells["Quanty"].Value.ToString()) - (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity);

                                        dgrFindReturn.Rows[i].Cells["Total1"].Value = (float.Parse(dgrFindReturn.Rows[i].Cells["Total1"].Value.ToString()) + (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity * unitprice)).ToString("#####0.000");
                                        dgrFindReturn.Rows[i].Cells["Returned1"].Value = int.Parse(dgrFindReturn.Rows[i].Cells["Returned1"].Value.ToString()) - quantity;
                                        dgrFindReturn.Rows[i].Cells["Qty"].Value = int.Parse(dgrFindReturn.Rows[i].Cells["Qty"].Value.ToString()) + quantity;
                                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt64(txt_returninvoiceno.Text);
                                        objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16(dgrReturnDetails.SelectedRows[0].Cells["ItemNo"].Value);

                                        Boolean ur = false;

                                        if ((rbnInvoice.Checked == true) || (rbnItem.Checked == true))
                                        {
                                            int retqtyavail = 0;

                                            if (quantity < Convert.ToInt32(dgrReturnDetails.SelectedRows[0].Cells["Quanty"].Value.ToString()))

                                                ur = objSalesReturnHelper.UndoReturnPerItemHelper();
                                            else //for all quantity undo
                                                ur = objSalesReturnHelper.UndoReturnAllQtyHelper();
                                            if ((qu >= 0))
                                            {

                                                objSalesReturnHelper.lstReturnedDetails[x].returnquantity = qu;
                                                decimal total = Convert.ToDecimal(qu * unitprice);
                                                objSalesReturnHelper.lstReturnedDetails[x].Total = total;
                                            }

                                        }

                                        if (ur)
                                        {
                                            if ((objSalesReturnHelper.lstReturnedDetails[x].returnquantity == 0))
                                            {
                                                objSalesReturnHelper.lstReturnedDetails.RemoveAt(x); j = 0;
                                            }
                                        }
                                        dgrReturnDetails.AutoGenerateColumns = false;
                                        dgrReturnDetails.DataSource = null;
                                        dgrReturnDetails.DataSource = objSalesReturnHelper.lstReturnedDetails;
                                        if (rbnItem.Checked == true) { goto endofloop; }


                                    }
                                }
                                else
                                {
                                    if (rbnItem.Checked)
                                    {
                                        GeneralFunction.Information("NotSelectRowtoReturn", "SaleReturnInvoice");
                                        return;
                                    }
                                }
                            }

                        }
                    }
                    endofloop: TotalReturnValue();

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "UndoReturnItem");
            }
            finally
            {
                lstStock = null;
            }

        }
        #endregion

        #region TotalReturnValue
        public void TotalReturnValue()
        {
            txt_totalreturnvalue.Text = "";
            float total = 0.0f;
            if (dgrReturnDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dgrReturnDetails.Rows.Count; i++)
                {
                    total = total + float.Parse(dgrReturnDetails.Rows[i].Cells["TotalPrice"].Value.ToString());

                }

            }
            txt_totalreturnvalue.Text = total.ToString("#####0.000");
        }
        #endregion

        #region SetMaxReturnID
        private void SetMaxReturnID()
        {
            List<long> lstMaxID = objSalesReturnHelper.GetMInMaxSaleReturnIDHelper();

            if (lstMaxID.Count > 0)
            {
                if (lstMaxID[0] > 0 && lstMaxID[1] > 0)
                {
                    txt_returninvoiceno.Text = (lstMaxID[1] > 0) ? lstMaxID[1].ToString() : "1";

                }
                else
                {
                    NewInvoiceGenerate();
                }
            }


        }
        #endregion

        #region invoicenokeydown
        public void invoicenokeydown()
        {
            //dgrFindReturn.Rows.Clear();
            try
            {
                if (txt_Invoiceno.Text != "")
                {
                    GetNewYearReceiptNo();
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = 0;
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno = objSalesReturnHelper.SaleIDFromyearSequence();
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.fromdate = Convert.ToDateTime(dtp_fromdate.Value);
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.todate = Convert.ToDateTime(dtp_todate.Value);
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno = 0;
                    //objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno = Convert.ToInt64(txt_Invoiceno.Text);
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.all = "NO";
                    objSalesReturnHelper.GetSaleReturnDetailsHelper();
                    dgrFindReturn.AutoGenerateColumns = false;
                    dgrFindReturn.DataSource = null;
                    dgrFindReturn.Refresh();
                    if (objSalesReturnHelper.lstFindDetails.Count > 0)
                    {

                        if (objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.invoiceno != 0 || (objSalesReturnHelper.lstFindDetails.FindIndex(a => a.saleid == Convert.ToInt32(dgrReturnDetails.Rows[0].Cells["SaleID"].Value)) != -1))
                            dgrFindReturn.DataSource = objSalesReturnHelper.lstFindDetails;
                    }
                }
                else
                {
                    txt_Invoiceno.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "invoicenokeydown");
            }
        }
        #endregion

        #region ClearAll
        private void ClearAll()
        {

            try
            {
                //Start : Added on 20-Jan-14 
                if (objSalesReturnHelper.lstFindDetails != null) { objSalesReturnHelper.lstFindDetails.Clear(); }
                if (objSalesReturnHelper.lstReturnedDetails != null) { objSalesReturnHelper.lstReturnedDetails.Clear(); }

                dgrReturnDetails.AutoGenerateColumns = false;
                dgrReturnDetails.DataSource = null;

                dgrFindReturn.AutoGenerateColumns = false;
                dgrFindReturn.DataSource = null;
                //End : 
                //Added on 23-June-2014 for Avoiding Performance issue
                txt_Invoiceno.TextChanged -= new EventHandler(txt_Invoiceno_TextChanged);
                txt_returninvoiceno.TextChanged -= new EventHandler(txt_returninvoiceno_TextChanged);
                cmb_item.SelectedIndexChanged -= new EventHandler(cmb_item_SelectedIndexChanged);
                cmb_itemno.SelectedIndexChanged -= new EventHandler(cmb_itemno_SelectedIndexChanged);
                cmb_client.SelectedIndexChanged -= new EventHandler(cmb_client_SelectedIndexChanged);
                cmb_clientno.SelectedIndexChanged -= new EventHandler(cmb_clientno_SelectedIndexChanged);
                //Added on 23-June-2014 for Avoiding Performance issue

                txt_returnclient.Text = "";
                txt_balance.Text = "";
                txt_returnquantity.Text = "1";
                txt_totalreturnvalue.Text = "";
                txt_Invoiceno.Text = "";
                txt_returninvoiceno.Text = "";

                // cmb_item.Text = "";//Commented on 23-June-2014 for Avoiding Performance issue
                cmb_item.SelectedIndex = -1;//Added on 23-June-2014 for Avoiding Performance issue
                cmb_itemno.SelectedIndex = -1;
                Lbl_PageNo.Text = "";
                cmb_client.Text = "";
                cmb_clientno.Text = string.Empty;

                //Added on 23-June-2014 for Avoiding Performance issue
                txt_Invoiceno.TextChanged += new EventHandler(txt_Invoiceno_TextChanged);
                txt_returninvoiceno.TextChanged += new EventHandler(txt_returninvoiceno_TextChanged);
                cmb_item.SelectedIndexChanged += new EventHandler(cmb_item_SelectedIndexChanged);
                cmb_itemno.SelectedIndexChanged += new EventHandler(cmb_itemno_SelectedIndexChanged);
                cmb_client.SelectedIndexChanged += new EventHandler(cmb_client_SelectedIndexChanged);
                cmb_clientno.SelectedIndexChanged += new EventHandler(cmb_clientno_SelectedIndexChanged);
                //Added on 23-June-2014 for Avoiding Performance issue
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "SaleReturnInvoice", "ClearAll");
            }
        }
        #endregion

        #region NewInvoiceGenerate
        private void NewInvoiceGenerate()
        {
            try
            {
                ClearAll();
                NewInvoice();
                //dgrReturnDetails.BackgroundColor = Color.Beige; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgrReturnDetails.BackgroundColor = Color.WhiteSmoke;
                dtp_returndate.Value = DateTime.Now;
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.New), Txt_NewInvoiceNo.Text, "SaleReturn", "New sale return invoice details", Convert.ToInt16(InvoiceAction.Yes));
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion





        #endregion

        #region "Barcode"

        #region KeyPress
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode")
        //    {
        //        ScanValue = string.Empty;
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

        #region "KeyUPEvents"
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                // GeneralFunction.ErrMsg(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "SaleReturn", "txtBarcode_KeyUp");
            }
        }
        #endregion

        #region Timer Tick Event

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
        //            string barcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //            barcode = barcode.Replace("\r", "").Trim();//Added on 25-June-2014 for Avoidng Newline and Spaces by Seenivasan 

        //            barcode = barcode.Replace("\r", "");
        //            barcode = barcode.Replace("~", "");
        //            if (barcode.Length > 13)
        //            {
        //                barcode = barcode.Substring(1, barcode.Length - 1);
        //            }

        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode);
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmb_item.SelectedIndexChanged -= new System.EventHandler(cmb_item_SelectedIndexChanged);
        //                cmb_item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                ClearBarcodeValues();
        //                cmb_item.SelectedIndexChanged += new System.EventHandler(cmb_item_SelectedIndexChanged);
        //            }
        //            else
        //            {
        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "SaleReturnInvoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                    }
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "SaleReturnInvoice");
        //                    ClearBarcodeValues();
        //                }
        //            }

        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //        //.ErrMsg(this.Text);
        //        //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
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
                    //    cmb_item.SelectedIndexChanged -= new System.EventHandler(cmb_item_SelectedIndexChanged);
                    //    cmb_item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    ClearBarcodeValues();
                    //    cmb_item.SelectedIndexChanged += new System.EventHandler(cmb_item_SelectedIndexChanged);
                    //}
                    //*********************************************************************************************

                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan

                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            cmb_item.SelectedIndexChanged -= new System.EventHandler(cmb_item_SelectedIndexChanged);
                            cmb_item.Text = row1["ItemName"].ToString();
                            ClearBarcodeValues();
                            cmb_item.SelectedIndexChanged += new System.EventHandler(cmb_item_SelectedIndexChanged);
                        }
                    }

                    //*********************************************************************************************

                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "SaleReturnInvoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                                LoadNewItems();
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "SaleReturnInvoice");
                            ClearBarcodeValues();
                        }
                    }

                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
                }
            }
            catch (Exception ex)
            {
                tmrBarcode.Enabled = false;
                ClearBarcodeValues();
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Return Invoice", "timer1_Tick");
                throw ex;
            }

        }
        #endregion

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

        # endregion

        private void Return_Quantity_keypress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
            {
                GeneralFunction.Information("OnlyNumbersAllowed", "SaleReturnInvoice");
                e.Handled = true;
            }


        }

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
                                    foreach (Control btn in ct.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i <= this.TableLayout2.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.TableLayout2.RowCount; j++)
                    {
                        Control c = this.TableLayout2.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control btn in ct.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
                dgrFindReturn.Font = dgrReturnDetails.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        //Added on 23-June-2014 for Avoiding Performance issue
        private void DropDown_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13) //Added following code on 24-June-2014 for setting focus to next control when enter on DropDown
                {
                    ////switch (((ComboBox)sender).Name)
                    ////{
                    ////    case "cmb_item":
                    ////        //cmb_itemno.Focus();
                    ////        dgrFindReturn.Focus();
                    ////        break;
                    ////    case "cmb_itemno":
                    ////        //txt_Invoiceno.Focus();
                    ////        dgrFindReturn.Focus();
                    ////        break;
                    ////    case "cmb_client":
                    ////        //cmb_clientno.Focus();
                    ////        dgrFindReturn.Focus();
                    ////        break;
                    ////    case "cmb_clientno":
                    ////        //txt_balance.Focus();
                    ////        dgrFindReturn.Focus();
                    ////        break;
                    ////}
                    txtBarcode.Focus();
                    //dgrFindReturn.Focus();//Added on 25-June-2014 for setting focus to avoid the Barcode scan issues by Seenivasan
                }
                else
                {
                    if (((ComboBox)sender).DroppedDown == true)
                        ((ComboBox)sender).DroppedDown = false;
                }//this Condition Modified on 14Aug2014 By Meena.R to change the Dropdown as Suggest Append

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Sales Return", "cmb_item_KeyDown");
            }
        }


        private void GetNewYearReceiptNo()
        {
            if (txt_Invoiceno.Text.Contains('-'))
            {
                string[] strNewYearNo = txt_Invoiceno.Text.Split('-');
                if (!(strNewYearNo[0].Length == 0 && strNewYearNo[1].Length == 0))
                {
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Year = Convert.ToInt32(strNewYearNo[0]);
                    objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.YearSequenceNo = Convert.ToInt32(strNewYearNo[1]);
                }
                else
                { GeneralFunction.ErrInfo("Invoice ID Not in Correct format", "Sales Invoice"); }
            }
            else
            {
                objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Year = objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.CurrentYear;
                objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.YearSequenceNo = Convert.ToInt64(txt_Invoiceno.Text);
            }

        }

        private void Sales_Return_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSalesReturnHelper.objSaleReturnInvoiceBAL = null;
            objSalesReturnHelper.lstItem = null;
            objSalesReturnHelper.lstClient = null;
            objSalesReturnHelper.lstFindDetails = null;
            objSalesReturnHelper.lstReturnedDetails = null;

            objSalesReturnHelper.GetSerialNoList = null;
            objSalesReturnHelper.GetPackagQuantityList = null;
            objSalesReturnHelper.GetExpiryDate = null;
            this.Dispose();
        }

        private void dgrFindReturn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgrFindReturn.RowCount > 0 && dgrFindReturn.SelectedRows.Count > 0)
            {
                //  txt_Invoiceno.TextChanged -= new EventHandler(txt_Invoiceno_TextChanged);
                // txt_Invoiceno.Text = dgrFindReturn.SelectedRows[0].Cells["NewYearInvoiceNo"].Value.ToString();
                // txt_Invoiceno.TextChanged += new EventHandler(txt_Invoiceno_TextChanged);
            }
        }

        private void txt_Invoiceno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 58 || e.KeyChar < 47 && e.KeyChar != 35 && e.KeyChar != 45 && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dtp_todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgrFindReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
