using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;
using System.Threading;
using System.Globalization;
using System.Configuration;
using BALHelper;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Find_Sales_Invoice : Form, IDisposable
    {

        #region Variables
        FindSaleInvoiceHelper objFindSaleInvoiceHelper;
        FindSaleInvoiceObject objFindSaleInvoiceObject;
        MasterDataBALClass ObjMasterDataBALClass;
        #endregion

        #region Constructor
        public Find_Sales_Invoice()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            objFindSaleInvoiceHelper = new FindSaleInvoiceHelper();
            objFindSaleInvoiceObject = new FindSaleInvoiceObject();
            ObjMasterDataBALClass = new MasterDataBALClass();
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "";
            culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "HH:mm:ss";
            Thread.CurrentThread.CurrentCulture = culture;
            dtp_totime.CustomFormat = "HH:mm tt";
            dtp_fromdate.CustomFormat = "HH:mm tt";
            dtp_fromtime.Value = Convert.ToDateTime("12:00 AM");
            dtp_totime.Value = Convert.ToDateTime("11:59 PM");

            timer1.Enabled = true;
            timer1.Interval = 650;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        #endregion

        #region Events

        #region FormLoad Event
        private void Find_Sales_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_client.MatchingMethod = StringMatchingMethod.UseRegexs;
                //***********Date Format Check by Seenivasan on 13-Oct-2014************************//
                dtp_Todate.Format = DateTimePickerFormat.Custom;
                dtp_fromdate.Format = DateTimePickerFormat.Custom;
                dtp_Todate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtp_fromdate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                FillComboBoxes();
                //SetNotesAndAlerts();
                //if (GeneralOptionSetting.FlagAlertPayDates == "Y")//Commended by Meena.R alert came twice
                CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts);
                Hidecontrols();
                dtp_fromtime.Text = "12:00 AM";
                dtp_totime.Text = "11:59 PM";
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Selection Changed Event

        #region cmb_client_SelectedIndexChanged
        private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_total.Text = "0.000";
            txt_total_discount.Text = "0.000";
            txt_paid.Text = "0.000";
            txt_remaining.Text = "0.000";
            txt_net.Text = "0.000";
            ClientNameChange();
        }
        #endregion

        #region cmb_clientno_SelectedIndexChanged
        private void cmb_clientno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_balance.Text = "";
                if (cmb_clientno.SelectedIndex > -1)
                {
                    GetClientName();
                    SetBalance();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region datagrid_saleinv1_SelectionChanged
        private void datagrid_saleinv1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_sale.Text = txt_cost.Text = txt_discount.Text = Txt_profit.Text = "0.000";
                DataGridSelectionChange();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "datagrid_saleinv1_SelectionChanged");
            }
        }
        #endregion

        #region cmb_user_SelectedIndexChanged
        private void cmb_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //add by thamil on 13jult2016 for load grid while change the user .
                if (cmb_user.SelectedIndex != -1 && cmb_user.Text != string.Empty)
                {
                    btnFind_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #endregion

        #region Button Click Events

        #region btnFind_Click
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                ClearAmount();
                datagrid_saleinvoice2.DataSource = null;
                FindInvoiceUI();
                TotalCalculationUI();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnFind_Click");
            }

        }
        #endregion

        #region btnGoToInvoice_Click
        private void btnGoToInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                GoToInvoice();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnGoToInvoice_Click");
            }

        }
        #endregion

        #region btnItemInformation_Click
        private void btnItemInformation_Click(object sender, EventArgs e)
        {
            try
            {

                if (objFindSaleInvoiceHelper.ObjItemInfo.Visible == false)
                {

                    if (datagrid_saleinvoice2.SelectedRows.Count > 0)
                    {
                        objFindSaleInvoiceHelper.ObjItemInfo.ItemNo = Convert.ToInt32(datagrid_saleinvoice2.SelectedRows[0].Cells["ItemNo"].Value);
                        objFindSaleInvoiceHelper.ObjItemInfo.ItemName = datagrid_saleinvoice2.SelectedRows[0].Cells["Description"].Value.ToString();
                        objFindSaleInvoiceHelper.ObjItemInfo.ShowDialog();
                    }


                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnItemInformation_Click");
            }


        }
        #endregion

        #region datagrid_saleinv1_CellDoubleClick
        private void datagrid_saleinv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GoToInvoice();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnGoToInvoice_Click");
            }
        }
        #endregion

        #region btnReturnItem_Click

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sales_Return_Invoice objSaleReturn = new Sales_Return_Invoice();
                objSaleReturn.ShowDialog();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnReturnItem_Click");
            }
        }
        #endregion

        #region btnEndOfTheDay_Click
        private void btnEndOfTheDay_Click(object sender, EventArgs e)
        {
            try
            {
                End_of_the_Day objEndofTheDay = new End_of_the_Day();
                objEndofTheDay.ShowDialog();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnEndOfTheDay_Click");
            }
        }
        #endregion

        #region btnSaleInvoice_Click
        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Sales_Invoice objSalesInvoice = new Sales_Invoice();
                objSalesInvoice.ShowDialog();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnSaleInvoice_Click");
            }
        }
        #endregion

        #region btnSaleInvoice_Click
        private void btnItemCard_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCard objItemCard = new ItemCard();
                objItemCard.ShowDialog();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnItemCard_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            this.Close();
        }
        #endregion

        #region btnBalanceSheet_Click
        private void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                frmBalanceSheet objBalanceSheet = new frmBalanceSheet();
                if (cmb_client.Text.Length != 0)
                {
                    objBalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(cmb_clientno.Text);
                    objBalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmb_client.Text;
                    objBalanceSheet.ShowDialog();
                }
                else
                    objBalanceSheet.ShowDialog();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnBalanceSheet_Click");
            }
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                objFindSaleInvoiceHelper.Print();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Find Sales Invoice", "btnPrint_Click");
            }
        }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {

            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            lblFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice");
            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblFromTime.Text = Additional_Barcode.GetValueByResourceKey("FT");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblInvoiceType.Text = Additional_Barcode.GetValueByResourceKey("IType");
            lblProfit.Text = Additional_Barcode.GetValueByResourceKey("Profit");
            lblSale.Text = Additional_Barcode.GetValueByResourceKey("Sale");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblToTime.Text = Additional_Barcode.GetValueByResourceKey("TT");
            lblUser.Text = Additional_Barcode.GetValueByResourceKey("User");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblClientNo.Text = Additional_Barcode.GetValueByResourceKey("CNo");
            lblClient.Text = Additional_Barcode.GetValueByResourceKey("CName");
            lblNet.Text = Additional_Barcode.GetValueByResourceKey("Net");
            lblPaid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
            lblRemining.Text = Additional_Barcode.GetValueByResourceKey("Remaining");
            lblTotalDiscount.Text = Additional_Barcode.GetValueByResourceKey("TDiscount");
            lblTotal.Text = Additional_Barcode.GetValueByResourceKey("Total");
            btnSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDetailedReport.Text = Additional_Barcode.GetValueByResourceKey("DetailedReport");
            btnEndOfTheDay.Text = Additional_Barcode.GetValueByResourceKey("EndOfDay");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find");
            btnGoToInvoice.Text = Additional_Barcode.GetValueByResourceKey("GoToInvoice");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            btnItemInformation.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem");
            this.grbNotes.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            chkAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            this.Text = Additional_Barcode.GetValueByResourceKey("FindSalesInvoice");

            //Grid Columns Language Setting

            datagrid_saleinv1.Columns["newyearinv"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            datagrid_saleinv1.Columns["NewYearSequenceNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            datagrid_saleinv1.Columns["Date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            datagrid_saleinv1.Columns["client"].HeaderText = Additional_Barcode.GetValueByResourceKey("Client");
            datagrid_saleinv1.Columns["total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            datagrid_saleinv1.Columns["discount"].HeaderText = Additional_Barcode.GetValueByResourceKey("Discount");
            datagrid_saleinv1.Columns["net"].HeaderText = Additional_Barcode.GetValueByResourceKey("Net");
            datagrid_saleinv1.Columns["user"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            datagrid_saleinv1.Columns["time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            datagrid_saleinv1.Columns["returned"].HeaderText = Additional_Barcode.GetValueByResourceKey("Returned");
            datagrid_saleinv1.Columns["paid"].HeaderText = Additional_Barcode.GetValueByResourceKey("Paid");
            datagrid_saleinv1.Columns["Invtype2"].HeaderText = Additional_Barcode.GetValueByResourceKey("Invoice");


            datagrid_saleinvoice2.Columns["ItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            datagrid_saleinvoice2.Columns["ItemNumber"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            datagrid_saleinvoice2.Columns["Description"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            datagrid_saleinvoice2.Columns["ExpiryDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            datagrid_saleinvoice2.Columns["PackageQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            datagrid_saleinvoice2.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            datagrid_saleinvoice2.Columns["PriceAmt"].HeaderText = Additional_Barcode.GetValueByResourceKey("Price");
            datagrid_saleinvoice2.Columns["TotalAmt"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            datagrid_saleinvoice2.Columns["MTPTime"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            datagrid_saleinvoice2.Columns["serialno"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");

            //Grid Columns Language Setting


            //Invoice types items

            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("SalesInvoice"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("AllInvoice"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("New"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("Closed"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("SpoiledItem"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("ReturnInvoice"));
            cmb_invtype.Items.Add(Additional_Barcode.GetValueByResourceKey("POS"));
        }
        #endregion

        #region  SetNotesAndAlerts
        public void SetNotesAndAlerts()
        {
            try
            {

                if (GeneralOptionSetting.FlagAlertPayDates == "Y")
                    CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RtxtNotesAndAlerts);

                #region OldCode
                //if ("Y" == "Y")
                //{
                //    List<FindSaleInvoiceObject> lstPaymentDate = objFindSaleInvoiceHelper.lstPaymentDate;
                //    List<FindSaleInvoiceObject> lstAgentPayment = objFindSaleInvoiceHelper.lstAgentPayment;
                //    const int paybefor = 0;
                //    string str = string.Empty;
                //    if (paybefor > 0)
                //    {


                //        if (lstPaymentDate.Count > 0)
                //        {
                //            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n";
                //            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "Payment Dates :";
                //            for (int i = 0; i < lstPaymentDate.Count; i++)
                //            {
                //                TimeSpan tp = Convert.ToDateTime(lstPaymentDate[i].PaymentDate.ToString()).Subtract(Convert.ToDateTime(DateTime.Now));
                //                if ((tp.Days <= paybefor) & (tp.Days >= 0))
                //                {
                //                    str = lstPaymentDate[i].AgentName.ToString() + "---" + Convert.ToDateTime(lstPaymentDate[i].PaymentDate.ToString()).ToShortDateString();
                //                    RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + '\n' + str;
                //                }
                //            }

                //        }
                //    }
                //    else
                //        if (lstAgentPayment.Count > 0)
                //        {

                //            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "\n";
                //            RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + "Payment Dates :";
                //            // rtxt_notes_and_alerts.Text = rtxt_notes_and_alerts.Text + "\n" + "--------------------";

                //            for (int i = 0; i < lstAgentPayment.Count; i++)
                //            {
                //                str = lstAgentPayment[i].AgentName.ToString();
                //                RtxtNotesAndAlerts.Text = RtxtNotesAndAlerts.Text + '\n' + str;
                //            }
                //        }

                //}
                #endregion
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region SetObjectFromControl

        private void SetObjectFromControl()
        {
            //binding Objects for Find button functionlity
            //objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.fromdate = Convert.ToDateTime(dtp_fromdate.Value.ToShortDateString() + " " + dtp_fromtime.Value.ToShortTimeString());
            //objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.todate = Convert.ToDateTime(dtp_Todate.Value.ToShortDateString() + " " + dtp_totime.Value.ToShortTimeString());

            //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
            TimeSpan TsFrom = new TimeSpan(dtp_fromtime.Value.Hour, dtp_fromtime.Value.Minute, dtp_fromtime.Value.Second);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.fromdate = Convert.ToDateTime(dtp_fromdate.Value.Date + TsFrom);
            TimeSpan TsTo = new TimeSpan(dtp_totime.Value.Hour, dtp_totime.Value.Minute, dtp_totime.Value.Second);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.todate = Convert.ToDateTime(dtp_Todate.Value.Date + TsTo);
            //Time span is added to search From date as well as from time.


            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.clientid = (cmb_clientno.SelectedIndex != -1) ? Convert.ToInt16(cmb_clientno.Text) : 0;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.ChkAllChecked = chkAll.Checked;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex = cmb_invtype.SelectedIndex;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedIndex = cmb_user.SelectedIndex;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedValue = (cmb_user.SelectedIndex != -1 ? Convert.ToInt16(cmb_user.SelectedValue) : 0);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.ClientSelectedIndex = cmb_client.SelectedIndex;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.NetAmount = Convert.ToDecimal(txt_net.Text);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.Paid = Convert.ToDecimal(txt_paid.Text);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.Balance = (txt_balance.Text != "" ? Convert.ToDecimal(txt_balance.Text) : 0);

            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeText = cmb_invtype.Text;
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNoText = txt_invoice_no.Text;

            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.BalanceAgent = (cmb_clientno.Text != "" ? Convert.ToInt16(cmb_clientno.Text) : 0);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.BalanceFromDate = Convert.ToDateTime(dtp_fromdate.Value);//CultureInfo.CurrentCulture
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.BalanceToDate = Convert.ToDateTime(dtp_Todate.Value);
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.BalanceStatus = "1";
            objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedText = cmb_user.Text;
        }

        #endregion

        #region  Hidecontrols
        void Hidecontrols()
        {
            try
            {
                datagrid_saleinvoice2.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
                datagrid_saleinvoice2.Columns["PackageQty"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
                btnPrint.Enabled = (UserScreenLimidations.Print) ? true : false;
                btnReports.Enabled = (UserScreenLimidations.Reports) ? true : false;
                btnDetailedReport.Enabled = (UserScreenLimidations.Print) ? true : false;
                btnSaleInvoice.Enabled = (UserScreenLimidations.SaleInvoice) ? true : false;
                btnBalanceSheet.Enabled = (UserScreenLimidations.BalanceSheet) ? true : false;
                btnReturnItem.Enabled = (UserScreenLimidations.SaleReturnInvoice) ? true : false;
                btnItemCard.Enabled = (UserScreenLimidations.ItemCard) ? true : false;
                btnEndOfTheDay.Enabled = (UserScreenLimidations.EndOfDays) ? true : false;
                datagrid_saleinv1.Columns["time"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
                datagrid_saleinvoice2.Columns["MTPTime"].Visible = (GeneralOptionSetting.FlagShowTime == "Y") ? true : false;
                btnItemInformation.Enabled = UserScreenLimidations.ItemInfo;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region FillComboBoxes
        private void FillComboBoxes()
        {

            //cmb_category.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;
            //cmb_category.DisplayMember = "Category";
            //cmb_category.ValueMember = "CategoryID";

            //cmb_company.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;
            //cmb_company.DisplayMember = "Company";
            //cmb_company.ValueMember = "CompanyID";

            cmb_user.SelectedIndexChanged -= new System.EventHandler(this.cmb_user_SelectedIndexChanged);
            cmb_user.DisplayMember = "FirstName";
            cmb_user.ValueMember = "UserId";
            // cmb_user.DataSource = ObjectHelper.GeneralObjectClass.UserList; 'Commented on 25-Nov-2014
            //*****'Added on 25-Nov-2014******************
            List<EmployeeObjectClass> lstUser = new List<EmployeeObjectClass>();
            lstUser = ObjMasterDataBALClass.UserDetailsBal();
            //alter by thamil on 13jult2016 for first name is the display member.
            lstUser.Insert(0,new EmployeeObjectClass() { UserId = 0, FirstName = "All User" });
            lstUser = lstUser.Where(a => (a.Status == 1 || a.UserId==0)).ToList();
            cmb_user.DataSource = lstUser;
            //********************************************

            cmb_user.SelectedIndexChanged += new System.EventHandler(this.cmb_user_SelectedIndexChanged);
            //cmb_user.SelectedIndex = 0;

            objFindSaleInvoiceHelper.Load();
            cmb_client.SelectedIndexChanged -= new EventHandler(cmb_client_SelectedIndexChanged);
            cmb_clientno.SelectedIndexChanged -= new EventHandler(cmb_clientno_SelectedIndexChanged);
            cmb_client.DisplayMember = "Name";
            cmb_client.ValueMember = "AgentId";
            cmb_client.DataSource = objFindSaleInvoiceHelper.lstUser;

            cmb_clientno.DisplayMember = "AgentId";
            cmb_clientno.ValueMember = "Name";
            cmb_clientno.DataSource = objFindSaleInvoiceHelper.lstUser;

            cmb_client.SelectedIndexChanged += new EventHandler(cmb_client_SelectedIndexChanged);
            cmb_clientno.SelectedIndexChanged += new EventHandler(cmb_clientno_SelectedIndexChanged);
            cmb_client.SelectedIndex = -1;
            cmb_clientno.SelectedIndex = -1;
            cmb_invtype.SelectedIndex = 0;
        }
        #endregion

        #region ClientNameChange
        public void ClientNameChange()
        {
            try
            {
                if (cmb_client.SelectedIndex > -1)
                    cmb_clientno.Text = cmb_client.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region GetClientName
        public void GetClientName()
        {
            try
            {
                float debt = 0.0f;
                objFindSaleInvoiceObject.ClientID = cmb_clientno.Text;
                // obj_findsaleinvoice.clientid = cmb_clientno.Text;
                if (cmb_client.Text != cmb_clientno.SelectedValue.ToString())
                    cmb_client.Text = cmb_clientno.SelectedValue.ToString();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
        }
        #endregion

        #region SetBalance
        private void SetBalance()
        {
            try
            {
                SetObjectFromControl();
                objFindSaleInvoiceHelper.GetBalance();
                //txt_balance.ForeColor = (GeneralFunction.ClientDebt >= 0) ? Color.Green : Color.Red;
                //txt_balance.Text = GeneralFunction.ClientDebt.ToString("########0.000");//Commented on 20-Apr-2014
                txt_balance.ForeColor = (objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.Balance >= 0) ? Color.Green : Color.Red;
                txt_balance.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.Balance.ToString("#######0.000");
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region ClearAmount
        private void ClearAmount()
        {
            txt_cost.Text = txt_sale.Text = txt_discount.Text = Txt_profit.Text = txt_net.Text = "0.000";
            txt_total.Text = txt_total_discount.Text = txt_paid.Text = txt_remaining.Text = txt_net.Text = "0.000";
        }
        #endregion

        #region TotalCalculationUI
        private void TotalCalculationUI()
        {
            objFindSaleInvoiceHelper.TotalCalculationHelper();
            txt_total.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.SumOfTotalAmt.ToString("#####0.000");
            txt_net.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.SumOfNetAmt.ToString("#####0.000");
            txt_paid.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.SumOfPaidAmt.ToString("#####0.000");
            txt_total_discount.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.SumOfDiscountAmt.ToString("#####0.000");
            txt_remaining.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.RemainingAmt.ToString("#####0.000");
        }
        #endregion

        #region FindInvoiceUI
        private void FindInvoiceUI()
        {
            //   datagrid_saleinv1.SelectionChanged -= new System.EventHandler(this.datagrid_saleinv1_SelectionChanged);  // This is commented by Manoj due to display the detailed records in second grid
            objFindSaleInvoiceHelper.FindInvoice();
            objFindSaleInvoiceHelper.GridSource(datagrid_saleinv1);
            //   datagrid_saleinv1.SelectionChanged += new System.EventHandler(this.datagrid_saleinv1_SelectionChanged);  // This is commented by Manoj due to display the detailed records in second grid
            if (datagrid_saleinv1.Rows.Count > 0)
            {
                datagrid_saleinv1.Rows[0].Selected = true;
            }
            //SetGridRowColor();
        }
        #endregion

        #region SetGridRowColor
        public void SetGridRowColor()
        {
            for (int i = 0; i < datagrid_saleinv1.RowCount; i++)
            {
                datagrid_saleinv1.Rows[i].DefaultCellStyle.ForeColor = (datagrid_saleinv1.Rows[i].Cells["Invtype"].Value.ToString() == "Normal") ? GridRowColor(datagrid_saleinv1.Rows[i].Cells["Status"].Value.ToString().Trim()) : GridRowColor(datagrid_saleinv1.Rows[i].Cells["Invtype"].Value.ToString().Trim());
            }
        }
        #endregion

        #region SetGridRowColor
        private Color GridRowColor(string strStatus)
        {
            switch (strStatus)
            {

                case "NI":
                    return Color.Blue;
                case "CI":
                    return Color.Navy;
                case "RI":
                    return Color.DarkOrange;
                case "SI":
                    return Color.Red;
                case "POS":
                    return Color.Chocolate;
                case "Rent":
                    return Color.Magenta;
                default:
                    return Color.Blue;

            }
        }
        #endregion

        #region DataGridSelectionChange
        public void DataGridSelectionChange()
        {
            try
            {

                if (datagrid_saleinvoice2.Rows.Count > 0)
                {
                    datagrid_saleinvoice2.DataSource = null;
                }

                if (datagrid_saleinv1.SelectedRows.Count > 0)
                {
                    objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceType = Convert.ToInt16(datagrid_saleinv1.SelectedRows[0].Cells["Invtype"].Value);
                    objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo = Convert.ToInt64(datagrid_saleinv1.SelectedRows[0].Cells["invoiceno"].Value);
                    objFindSaleInvoiceHelper.DataGridSelectionChangeHelper();
                    //datagrid_saleinvoice2.BackgroundColor = ((objFindSaleInvoiceHelper.lstInvoiceItemDetails.Count > 0) && (objFindSaleInvoiceHelper.lstInvoiceItemDetails[0].Status == 2)) ? Color.Gray : Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    datagrid_saleinvoice2.BackgroundColor = ((objFindSaleInvoiceHelper.lstInvoiceItemDetails.Count > 0) && (objFindSaleInvoiceHelper.lstInvoiceItemDetails[0].Status == 2)) ? Color.Gray : Color.WhiteSmoke; 
                    datagrid_saleinvoice2.DefaultCellStyle.BackColor = ((objFindSaleInvoiceHelper.lstInvoiceItemDetails.Count > 0) && (objFindSaleInvoiceHelper.lstInvoiceItemDetails[0].Status == 2)) ? Color.Gainsboro : Color.White;
                    AssignItemGridSource();
                    TotalInvoiceItemCalcUI();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region AssignItemGridSource
        private void AssignItemGridSource()
        {

            datagrid_saleinvoice2.AutoGenerateColumns = false;
            datagrid_saleinvoice2.DataSource = null;
            datagrid_saleinvoice2.Rows.Clear();
            datagrid_saleinvoice2.DataSource = objFindSaleInvoiceHelper.lstInvoiceItemDetails;

        }

        #endregion

        #region TotalInvoiceItemCalcUI
        private void TotalInvoiceItemCalcUI()
        {
            objFindSaleInvoiceHelper.TotalInvoieItemsCalc();
            txt_sale.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.TotalSale.ToString("######0.000");
            txt_cost.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.TotalCostAmt.ToString("######0.000");
            txt_discount.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.TotalDiscount.ToString("####0.000");
            Txt_profit.Text = objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.TotalProfit.ToString("####0.000");
        }
        #endregion

        #region GoToInvoice
        private void GoToInvoice()
        {
            if (datagrid_saleinv1.SelectedRows.Count > 0)
            {
                objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceType = Convert.ToInt16(datagrid_saleinv1.SelectedRows[0].Cells["Invtype"].Value);
                objFindSaleInvoiceHelper.objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo = Convert.ToInt64(datagrid_saleinv1.SelectedRows[0].Cells["invoiceno"].Value);
                objFindSaleInvoiceHelper.GoToInvoice();

            }
        }
        #endregion

        private void RtxtNotesAndAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = RtxtNotesAndAlerts.SelectedText.Trim();
            Purchase_Invoice.ReorderandBalance(str);
        }



        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            GeneralFunction.BlinkText(e, RtxtNotesAndAlerts);
        }

        #region Detailed Report
        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            SetObjectFromControl();
            objFindSaleInvoiceHelper.DetailedReport();
        }


        #endregion

        private void btnReports_Click(object sender, EventArgs e)
        {
            Report rpts = new Report();
            rpts.ShowDialog();
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
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control ctl in ct.Controls)
                                    {
                                        if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton)
                                            ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
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
                datagrid_saleinv1.Font = datagrid_saleinvoice2.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void Find_Sales_Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void cmb_client_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
            //{
            if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                   (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                   && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                   && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                   && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock))
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
        }

        private void Find_Sales_Invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFindSaleInvoiceHelper.lstUser = null;
            objFindSaleInvoiceHelper.lstPaymentDate = null;
            objFindSaleInvoiceHelper.lstAgentPayment = null;
            objFindSaleInvoiceHelper.lstInvoiceDetails = null;
            objFindSaleInvoiceHelper.lstInvoiceItemDetails = null;
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
