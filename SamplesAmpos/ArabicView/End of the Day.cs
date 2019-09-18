using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.ViewHelper;
using ObjectHelper;
using System.Threading;
using BumedianBM.CrystalReports;
using System.Globalization;
using System.Configuration;
using BALHelper;

namespace BumedianBM.ArabicView
{
    public partial class End_of_the_Day : Form, IDisposable
    {

        #region Declaration
        EndOfDayHelper ObjEndHelper;
        internal Dictionary<string, List<EndofTheDayObject>> dicEndofDay = new Dictionary<string, List<EndofTheDayObject>>();
        decimal Balance = 0;
        decimal Drawing = 0;
        int Dateoption = 0;
        DataTable dtCashTotal;
        public static int endofTheReportFlag = 0;
        DataTable Get_Details;

        #endregion

        #region Constructor
        public End_of_the_Day()
        {
            ObjEndHelper = new EndOfDayHelper();
            InitializeComponent();
            SetLanguage();
            setFont();
        }
        #endregion

        #region Events

        #region Form Load
        private void End_of_the_Day_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Value = DateTime.Now;
                dtpToDate.Value = DateTime.Now;

                //***********Date Format for DatetimPicker control by Seenivasan on 15-Oct-2014************************//
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.Format = DateTimePickerFormat.Custom;

                dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//


                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = "";
                culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
                Thread.CurrentThread.CurrentCulture = culture;
                dtpToTime.CustomFormat = "hh:mm tt";
                dtpFromTime.CustomFormat = "hh:mm tt";
                dtpFromTime.Value = Convert.ToDateTime("12:00 AM");
                dtpToTime.Value = Convert.ToDateTime("11:59 PM");

                DateTime dtfrom = new DateTime();
                dtfrom = dtpFromDate.Value.Date;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Button Click

        #region btnView_Click
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Chk_DateValidation() == true)
                {
                    FillTheDatasourceIn_Gridview();
                    FillTextBoxes();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void FillTextBoxes()
        {
            if (dicEndofDay != null)
                txtTotalSales.Text = dicEndofDay["EndOfDayTotals"][0].TotalSale.ToString();//

            txtTotalPurchases.Text = dicEndofDay["EndOfDayTotals"][0].TotalPurchase.ToString();
            txtSalereturn.Text = dicEndofDay["EndOfDayTotals"][0].TotalSaleReturn.ToString();
            txtPurchaseReturned.Text = dicEndofDay["EndOfDayTotals"][0].TotalPurchaseReturn.ToString();


            txtTotalSpoiled.Text = dicEndofDay["EndOfDayTotals"][0].TotalSpoiled.ToString();//

            txtTotalCost.Text = dicEndofDay["EndOfDayTotals"][0].TotalCost.ToString();//
            txtTotalPaid.Text = dicEndofDay["EndOfDayTotals"][0].TotalPaid.ToString();//
            txtTotalReceived.Text = dicEndofDay["EndOfDayTotals"][0].TotalReceived.ToString();//
            txtTotalExpenses.Text = dicEndofDay["EndOfDayTotals"][0].Expenses.ToString();//
            txtPaymentCharges.Text = dicEndofDay["EndOfDayTotals"][0].TotalCharges.ToString();
            

            decimal profits = (decimal.Parse(txtTotalSales.Text) - decimal.Parse(txtSalereturn.Text)) - (decimal.Parse(txtTotalCost.Text) + decimal.Parse(txtTotalExpenses.Text) + decimal.Parse(txtTotalSpoiled.Text));
            decimal netcash = decimal.Parse(txtTotalReceived.Text) - (decimal.Parse(txtTotalPaid.Text) + decimal.Parse(txtTotalExpenses.Text));
            netcash = (netcash - Drawing);//added on 03Dec2014
            txtProfit.Text = profits.ToString("#####0.000");
            txtAvailableCost.Text = (netcash+Balance).ToString("#####0.000");
            txtDraw.Text = Drawing.ToString("#####0.000");

            dtCashTotal = new DataTable();
            dtCashTotal = ObjEndHelper.GetEndOfTheDayTotalCash(ref Balance, ref Drawing);
            if (dtCashTotal.Rows.Count > 0)
            {
                decimal Totalcash = decimal.Parse(dtCashTotal.Rows[0][4].ToString()) - (decimal.Parse(dtCashTotal.Rows[0][5].ToString()) + decimal.Parse(dtCashTotal.Rows[0][2].ToString()));
                Totalcash = (Totalcash - Drawing);
                Totalcash = (Totalcash + Balance);
                txtTotalcash.Text = Totalcash.ToString();
            }
        }

        private void FillTheDatasourceIn_Gridview()
        {
            SetObjectFromControl();
              Balance=0;
              dicEndofDay = ObjEndHelper.GetEndOfDayDetailsBal(ref   Balance, ref Drawing);
              
            dgrEndofDay.DataSource = null;
            dgrEndofDay.AutoGenerateColumns = false;
            txtOpenBalance.Text = Balance.ToString();
            if (dicEndofDay != null)
                dgrEndofDay.DataSource = dicEndofDay["EndOfDayDetails"];
        }

        private void SetObjectFromControl()
        {
            try
            {
                //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                TimeSpan TsFrom = new TimeSpan(dtpFromTime.Value.Hour, dtpFromTime.Value.Minute, dtpFromTime.Value.Second);
                ObjEndHelper.objEndOfBal.objEndfDayObject.FromDate = Convert.ToDateTime(dtpFromDate.Value.Date + TsFrom);
                TimeSpan TsTo = new TimeSpan(dtpToTime.Value.Hour, dtpToTime.Value.Minute, dtpToTime.Value.Second);
                ObjEndHelper.objEndOfBal.objEndfDayObject.ToDate = Convert.ToDateTime(dtpToDate.Value.Date + TsTo);
                //Time span is added to search From date as well as from time.
                if (chkDateALL.Checked == true)
                    ObjEndHelper.objEndOfBal.objEndfDayObject.CheckedStatus = 0;
                else
                    ObjEndHelper.objEndOfBal.objEndfDayObject.CheckedStatus = 1;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region btnPrint_Click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime frDate = dtpFromTime.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;
                TimeSpan sp = new TimeSpan(23, 59, 59);
                toDate.Add(sp);

                

                
                if (Chk_DateValidation())
                {
                    FillTheDatasourceIn_Gridview();
                    FillTextBoxes();
                }
                DataTable InvenDT = new DataTable("EndOfDay");
                InvenDT = CommonHelper.ConvertionHelper.ConvertToDataTable<ObjectHelper.EndofTheDayObject>(dicEndofDay["EndOfDayDetails"]);
                if (InvenDT != null)
                {
                    DataTable dtLocal = new DataTable("EndOfDay");
                    DataRow dr;
                    dtLocal.Columns.Add("UserID");
                    dtLocal.Columns.Add("UserName");
                    dtLocal.Columns.Add("Sale");
                    dtLocal.Columns.Add("SaleReturn");
                    dtLocal.Columns.Add("Purchase");
                    dtLocal.Columns.Add("PurchaseReturn");
                    dtLocal.Columns.Add("Spoiled");
                    dtLocal.Columns.Add("Rent");
                    dtLocal.Columns.Add("Received");
                    dtLocal.Columns.Add("Paid");
                    dtLocal.Columns.Add("Expenses");


                    for (int g = 0; g < InvenDT.Rows.Count; g++)
                    {

                        dr = dtLocal.NewRow();
                        dr["UserID"] = InvenDT.Rows[g]["UserId"].ToString() != "" ? InvenDT.Rows[g]["UserId"].ToString() : "0";
                        dr["UserName"] = InvenDT.Rows[g]["UserName"].ToString() != "" ? InvenDT.Rows[g]["UserName"].ToString() : "0";
                        decimal sale = InvenDT.Rows[g]["TotalSale"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalSale"]) : 0;
                        dr["Sale"] = sale.ToString("########0.000");
                        decimal saleRTN = InvenDT.Rows[g]["TotalSaleReturn"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalSaleReturn"]) : 0;
                        dr["SaleReturn"] = saleRTN.ToString("########0.000");
                        decimal purch = InvenDT.Rows[g]["TotalPurchase"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalPurchase"]) : 0;
                        dr["Purchase"] = purch.ToString("########0.000");
                        decimal purchRTN = InvenDT.Rows[g]["TotalPurchaseReturn"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalPurchaseReturn"]) : 0;
                        dr["PurchaseReturn"] = purchRTN.ToString("########0.000");
                        decimal Spoil = InvenDT.Rows[g]["TotalSpoiled"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalSpoiled"]) : 0;
                        dr["Spoiled"] = Spoil.ToString("########0.000");
                        decimal Rent = InvenDT.Rows[g]["TotalRented"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalRented"]) : 0;
                        dr["Rent"] = Rent.ToString("########0.000");



                        decimal recCost = InvenDT.Rows[g]["TotalReceived"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalReceived"].ToString()) : 0;
                        decimal paiCost = InvenDT.Rows[g]["TotalPaid"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["TotalPaid"].ToString()) : 0;
                        decimal expCost = InvenDT.Rows[g]["Expenses"].ToString() != "" ? Convert.ToDecimal(InvenDT.Rows[g]["Expenses"].ToString()) : 0;

                        dr["Received"] = recCost.ToString("########0.000");
                        dr["Paid"] = paiCost.ToString("########0.000");
                        dr["Expenses"] = expCost.ToString("########0.000");




                        dtLocal.Rows.Add(dr);
                    }
                    Rpt_EndOfDays summery = new Rpt_EndOfDays();
                    
                    
                    ReportsView RptView = new ReportsView();
                    RptView.HTable.Clear();
                    //summery.Refresh();
                    RptView.Report_Table = dtLocal;
                    RptView.RptDoc = summery;

                    RptView.HTable.Add("SALE", txtTotalSales.Text);
                    RptView.HTable.Add("PURCHASE", txtTotalPurchases.Text);
                    RptView.HTable.Add("RETURN", txtPurchaseReturned.Text);
                    RptView.HTable.Add("purchaseNetPurchase",(Convert.ToDecimal(txtTotalPurchases.Text)-Convert.ToDecimal(txtPurchaseReturned.Text)));
                    RptView.HTable.Add("RENT", 0);
                    RptView.HTable.Add("SPOILED", txtTotalSpoiled.Text);
                    RptView.HTable.Add("RECEIVED", txtTotalReceived.Text);
                    RptView.HTable.Add("COST", txtTotalCost.Text);
                    RptView.HTable.Add("PAID", txtTotalPaid.Text);
                    RptView.HTable.Add("EXPENSES", txtTotalExpenses.Text);
                    RptView.HTable.Add("PROFIT", txtProfit.Text);
                    RptView.HTable.Add("SaleReturn", txtSalereturn.Text);
                    RptView.HTable.Add("NetCash", txtAvailableCost.Text);
                    RptView.HTable.Add("FromDate",frDate.ToString("dd/MM/yyyy"));
                    RptView.HTable.Add("ToDate",toDate.ToString("dd/MM/yyyy"));
                    RptView.HTable.Add("DateAndTime", DateTime.Now.ToString());
                    RptView.HTable.Add("userName1",GeneralFunction.UserName.ToUpper());
                    RptView.HTable.Add("HideDate", false);
                    RptView.HTable.Add("totalpurchase", 20.10);

                    SetObjectFromControl();
                    DataTable dt = new DataTable();
                    dt = ObjEndHelper.objEndOfBal.GetEndOftheDayReportTotalRecord();

                    if (chkDateALL.Checked)
                    {
                        Dateoption = 0;
                    }
                    else
                    {
                        Dateoption = 1;
                    }

                    DataTable dtMovement = new DataTable();
                    dtMovement = ObjEndHelper.objEndOfBal.GetEndOftheDayReportMovementRecord();

                    DataTable dtCashInformation = new DataTable();
                    dtCashInformation = ObjEndHelper.objEndOfBal.GetEndOFTheDayReportCashInfomation();

                    DataTable dtPurchaseInformation = new DataTable();
                    dtPurchaseInformation = ObjEndHelper.objEndOfBal.GetEndOftheReportPuchaseInformation();

                    DataTable dtSaleInformation = new DataTable();
                    dtSaleInformation = ObjEndHelper.objEndOfBal.GetEndOftheReportSaleInformation();

                    DataSet DsNetProfit = new DataSet();
                    DsNetProfit = ObjEndHelper.objEndOfBal.GetEndOftheReportNetIncomeInformation();

                    int novalue = 0;
                    for (int j = 0; j < DsNetProfit.Tables.Count; j++)
                    {
                        for (int k = 0; k < DsNetProfit.Tables[j].Columns.Count; k++)
                        {
                            if (DsNetProfit.Tables[j].Rows[0][k].ToString() == string.Empty)
                                DsNetProfit.Tables[j].Rows[0][k] = 0;
                            if (Convert.ToDecimal(DsNetProfit.Tables[j].Rows[0][k].ToString()) > 0)
                            {
                                novalue = 1;
                            }
                        }

                    }
                    if (DsNetProfit != null && DsNetProfit.Tables.Count >= 4)
                    {

                        //RptView.HTable.Add("TotalSales", DsNetProfit.Tables[0].Rows[0]["TotalSales"]);
                        //RptView.HTable.Add("SaleReturn", DsNetProfit.Tables[0].Rows[0]["SaleReturn"]);
                        //RptView.HTable.Add("SaleCost", DsNetProfit.Tables[0].Rows[0]["SaleCost"]);
                        //RptView.HTable.Add("SpoiledItems", DsNetProfit.Tables[1].Rows[0]["SpoiledItems"]);
                        //RptView.HTable.Add("Salary", DsNetProfit.Tables[4].Rows[0]["Salary"]);
                        //RptView.HTable.Add("Spending", DsNetProfit.Tables[2].Rows[0]["Spending"]);
                        //RptView.HTable.Add("RentSpending", DsNetProfit.Tables[3].Rows[0]["RentSpending"]);

                        //TotalSales - SaleReturn = NetSales
                        //NetSales - SaleCost = TotalIncome
                        // Spending + Salary = TotalSpend
                        // TotalIncome - totalSpend = Profit
                        // Profit - SpoiledItems = NetProfit
                        // {@TotalIncome}-({@TotalSpend}+{?SpoiledItems})

                        Decimal NetSales = Convert.ToDecimal(DsNetProfit.Tables[0].Rows[0]["TotalSales"])-Convert.ToDecimal(DsNetProfit.Tables[0].Rows[0]["SaleReturn"]);
                        Decimal TotalIncome = Convert.ToDecimal(NetSales) - Convert.ToDecimal(DsNetProfit.Tables[0].Rows[0]["SaleCost"]);
                        Decimal TotalSpend = Convert.ToDecimal(DsNetProfit.Tables[2].Rows[0]["Spending"]) + Convert.ToDecimal(DsNetProfit.Tables[4].Rows[0]["Salary"]);
                        Decimal Profit = TotalIncome - TotalSpend;
                        Decimal NetProfit = TotalIncome - (TotalSpend + Convert.ToDecimal(DsNetProfit.Tables[1].Rows[0]["SpoiledItems"]));

                        RptView.HTable.Add("profitNetIncome", TotalIncome);
                        RptView.HTable.Add("SaleReturnPaid", DsNetProfit.Tables[0].Rows[0]["SaleReturn"]);
                       
                        RptView.IsItemNo = false;
                        RptView.IsReportFooter = false;
                        DataTable Get_Details = new DataTable();
                        Get_Details = DsNetProfit.Tables[0];
                        DsNetProfit.Tables.RemoveAt(0);
                    }


                    DataTable dtDebtPayRecInformationForCreditSale = new DataTable("DeptList1");
                    int AgentID = 0;
                    Decimal debtReceivbleWithCredit = 0;
                    Decimal debtPayableWithCredit = 0;
                    if (Dateoption == 0)
                    {
                        dtDebtPayRecInformationForCreditSale = ObjEndHelper.objEndOfBal.DebtList(AgentID);
                    }
                    else
                    {
                        dtDebtPayRecInformationForCreditSale = ObjEndHelper.objEndOfBal.DebtListwithDateRange(Convert.ToDateTime(dtpFromDate.Value), Convert.ToDateTime(dtpToDate.Value), Dateoption, AgentID);
                    }
                    if (dtDebtPayRecInformationForCreditSale.Rows.Count > 0)
                    {
                        if (dtDebtPayRecInformationForCreditSale.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtDebtPayRecInformationForCreditSale.Rows.Count; i++)
                            {
                                if (Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"]) < Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"]))
                                {
                                    dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"] = Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"]) - Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"]);
                                    debtReceivbleWithCredit += Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"]);
                                    //if { DeptList.Receivable}<{ DeptList.Payable}
                                    //then { DeptList.Payable}-{ DeptList.Receivable}
                                    //Else 0

                                }
                                else if (Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"]) > Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"]))
                                {
                                    dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"] = Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"]) - Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Receivable"]);
                                    debtPayableWithCredit += Convert.ToDecimal(dtDebtPayRecInformationForCreditSale.Rows[i]["Payable"]);
                                }
                            }

                            if (debtReceivbleWithCredit < 0) { debtReceivbleWithCredit = debtReceivbleWithCredit * (-1); }
                            
                        }
                        RptView.HTable.Add("DebtReceivbleWithCredit", Convert.ToDecimal(debtReceivbleWithCredit));
                    }
                    else
                    {
                        RptView.HTable.Add("DebtReceivbleWithCredit", 0.0);
                    }
                    
                    DataTable dtDebtPayRecInformation = new DataTable("DeptList");
                    dtDebtPayRecInformation = ObjEndHelper.objEndOfBal.DebtList(AgentID);
                    Decimal debtReceivble = 0;
                    Decimal debtPayable = 0;

                    if (dtDebtPayRecInformation.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtDebtPayRecInformation.Rows.Count; i++)
                        {
                            if (Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Receivable"]) < Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Payable"]))
                            {
                                dtDebtPayRecInformation.Rows[i]["Receivable"] = Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Receivable"]) - Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Payable"]);
                                debtReceivble += Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Receivable"]);
                                //if { DeptList.Receivable}<{ DeptList.Payable}
                                //then { DeptList.Payable}-{ DeptList.Receivable}
                                //Else 0

                            }
                            else if (Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Receivable"]) > Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Payable"]))
                            {
                                dtDebtPayRecInformation.Rows[i]["Payable"] = Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Payable"]) - Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Receivable"]);
                                debtPayable += Convert.ToDecimal(dtDebtPayRecInformation.Rows[i]["Payable"]);
                            }
                        }

                        if (debtReceivble < 0) { debtReceivble = debtReceivble*(-1); }
                        RptView.HTable.Add("CashTotalDebtPayable", Convert.ToDecimal(debtPayable)); //dtDebtPayRecInformation.Rows[0][1]));
                        RptView.HTable.Add("CashTotalDebtReceive", Convert.ToDecimal(debtReceivble)); // dtDebtPayRecInformation.Rows[0][0]));

                    }else
                    {
                        RptView.HTable.Add("CashTotalDebtPayable", Convert.ToDecimal(0.0));
                        RptView.HTable.Add("CashTotalDebtReceive", Convert.ToDecimal(0.0));
                    }


                    // Agent_Details frm = new Agent_Details();
                    // frm.ObjHelper.ObjbalClass.ObjAgentDetailObject.Number = obj_report.Number;
                    //frm.ObjHelper.DebtList();
                    // isfromdebt = true;
                    if (ArabicView.Report.isAllDateSelected)
                    {
                        // Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                    }
                    else { } //Obj_viewer.HTable.Add("AllDates", ""); }





                    if (dtMovement.Rows.Count > 0)
                    {
                        RptView.HTable.Add("MovementNoOFSaleInvoices", dtMovement.Rows[0][0]);
                        RptView.HTable.Add("MovementNoOFNotSavesales", dtMovement.Rows[0][1]);
                        RptView.HTable.Add("MovementNoOFPurchaseinvoice", dtMovement.Rows[0][2]);
                        RptView.HTable.Add("MovementNoNotSavePurchases", dtMovement.Rows[0][3]);
                        RptView.HTable.Add("MovementNoOfSaleInvoiceModified", dtMovement.Rows[0][4]);
                    }
                    else
                    {
                        RptView.HTable.Add("MovementNoOFSaleInvoices", 0.0);
                        RptView.HTable.Add("MovementNoOFNotSavesales", 0.0);
                        RptView.HTable.Add("MovementNoOFPurchaseinvoice", 0.0);
                        RptView.HTable.Add("MovementNoNotSavePurchases", 0.0);
                        RptView.HTable.Add("MovementNoOfSaleInvoiceModified", 0.0);
                    }

                    if (dtSaleInformation.Rows.Count > 0 && dtPurchaseInformation.Rows.Count > 0)
                    {
                        RptView.HTable.Add("purchaseTotalCashPurchases", dtPurchaseInformation.Rows[0][2]);
                        RptView.HTable.Add("purchaseTotalcreditpurchase", Convert.ToDecimal(txtTotalPurchases.Text) - Convert.ToDecimal(txtTotalPaid.Text));
                        RptView.HTable.Add("purchaseTotalReturn", dtPurchaseInformation.Rows[0][1]);
                        RptView.HTable.Add("purchaseTotalPaid", dtPurchaseInformation.Rows[0][4]);
                        RptView.HTable.Add("SaleTotalCashSales", dtSaleInformation.Rows[0][1]);
                        RptView.HTable.Add("SaleTotalCardSales", dtSaleInformation.Rows[0][3]);
                        RptView.HTable.Add("SaleTotalCreditSales", dtSaleInformation.Rows[0][2]);
                        RptView.HTable.Add("SaleTotalDiscount", dtSaleInformation.Rows[0][6]);
                        RptView.HTable.Add("SaleTotalReceived", dtSaleInformation.Rows[0][7]);
                        RptView.HTable.Add("SaleTotalCheckSales", dtSaleInformation.Rows[0][4]);

                    }
                    else
                    {
                        RptView.HTable.Add("purchaseTotalCashPurchases", 0.0);
                        RptView.HTable.Add("purchaseTotalcreditpurchase", 0.0);
                        RptView.HTable.Add("purchaseTotalReturn", 0.0);
                        RptView.HTable.Add("purchaseTotalPaid", 0.0);
                        RptView.HTable.Add("SaleTotalCashSales", 0.0);
                        RptView.HTable.Add("SaleTotalCardSales", 0.0);
                        RptView.HTable.Add("SaleTotalCreditSales", 0.0);
                        RptView.HTable.Add("SaleTotalDiscount", 0.0);
                        RptView.HTable.Add("SaleTotalReceived", 0.0);
                        RptView.HTable.Add("SaleTotalCheckSales", 0.0);
                    }
                    // Net Cash in Hand
                    DataTable dtNetCashinHand = new DataTable();
                    dtNetCashinHand = ObjEndHelper.objEndOfBal.GetEndOftheReportNetCashInHand();
                    if (dtNetCashinHand.Rows.Count > 0) 
                    RptView.HTable.Add("NetCashInHand", dtNetCashinHand.Rows[0]["NetCash"]);
                    else
                        RptView.HTable.Add("NetCashInHand", 0.000);
                    DataSet dtZakat = new DataSet();
                    dtZakat = ObjEndHelper.objEndOfBal.GetEndOFTheDayReportZakatInfomation();

                    if (dtZakat.Tables[0].Rows.Count > 0 && dtZakat.Tables[1].Rows.Count > 0)
                    {
                        //RptView.HTable.Add("purchaseNetPurchase", (Convert.ToDecimal(txtTotalPurchases.Text)-Convert.ToDecimal(txtPurchaseReturned.Text)).ToString());


                        DataTable dtz = new DataTable("Zakat");
                        DataTable dt1 = new DataTable();
                        dtz = dtZakat.Tables[0];
                        dtz.TableName = "Zakat";
                        dt1 = dtZakat.Tables[1];
                        // dtZakat.Tables.Remove(dtZakat.Tables[0]);
                        //if (dt == null || dt.Rows.Count <= 0)
                        //{
                        //    GeneralFunction.Information("NoRecordsFound", "Reports");
                        //    return;
                        //}
                        float payable = 0;
                        float receivable = 0;
                        if (dt.Rows.Count > 0)
                        {
                            float pa = 0.0f;
                            float re = 0.0f;
                            float paid = 0.0f;
                            float rec = 0.0f;
                            //pa = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Payable)", string.Empty).ToString()) : 0.0f;
                            //re = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Receivable)", string.Empty).ToString()) : 0.0f;
                            //paid = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Paid)", string.Empty).ToString()) : 0.0f;
                            //rec = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Received)", string.Empty).ToString()) : 0.0f;
                            //payable = pa - paid;
                            //receivable = re - rec;
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                if (float.Parse(dt1.Rows[i]["Payable"].ToString()) > float.Parse(dt1.Rows[i]["Receivable"].ToString()))
                                {
                                    receivable += float.Parse(dt1.Rows[i]["Payable"].ToString()) - float.Parse(dt1.Rows[i]["Receivable"].ToString());
                                }
                                else
                                {
                                    payable += float.Parse(dt1.Rows[i]["Receivable"].ToString()) - float.Parse(dt1.Rows[i]["Payable"].ToString());
                                }
                            }
                        }
                        //RptView.HTable.Clear();
                        //RptView.HTable.Add("Tot_Receivable", receivable);
                        //RptView.HTable.Add("Tot_Payable", payable);
                        //RptView.HTable.Add("MovementMovementZakat", Convert.ToDecimal(((Convert.ToDouble((Convert.ToDecimal(dtZakat.Tables[0].Rows[0][5]) - Convert.ToDecimal(payable))) * 2.5) / 100)));

                        Decimal inventryvalue = Convert.ToDecimal(dtZakat.Tables[0].Rows[0][5]);

                        decimal subt = inventryvalue - Convert.ToDecimal(payable);
                        double multiple = (Convert.ToDouble(subt) * 2.5);
                        double divide = multiple / 100;


                        var zakatamout = Convert.ToDecimal((Convert.ToDouble(Convert.ToDecimal(dtZakat.Tables[0].Rows[0][5]) - Convert.ToDecimal(payable))*2.5)/100);
                        RptView.HTable.Add("MovementMovementZakat", (zakatamout).ToString());
                        }else
                        {
                        RptView.HTable.Add("MovementMovementZakat", (0).ToString());
                         }
                    if (dtZakat.Tables[0].Rows.Count > 0 && dtZakat.Tables[1].Rows.Count > 0)
                    {
                        DataTable dtZakat1 = new DataTable();
                        dtZakat1 = ObjEndHelper.objEndOfBal.GetEndOFTheDayReportZakatInfomation1();

                        RptView.HTable.Add("stockNetPurchase", Convert.ToDecimal(dtZakat1.Rows[0][0]) - Convert.ToDecimal(dtZakat1.Rows[0][3]));
                        RptView.HTable.Add("stockNetSales", Convert.ToDecimal(dtZakat1.Rows[0][1]) - Convert.ToDecimal(dtZakat1.Rows[0][2]));
                        RptView.HTable.Add("stockTotalReturn", dtZakat1.Rows[0][2]);
                    }else
                    {
                        RptView.HTable.Add("stockNetPurchase", 0);
                        RptView.HTable.Add("stockNetSales", 0);
                        RptView.HTable.Add("stockTotalReturn", 0);
                    }
                        //var zakat = Convert.ToDecimal(((Convert.ToDouble((Convert.ToDecimal(dtZakat.Rows[0][5]) - Convert.ToDecimal(dtZakat.Rows[0][8]))) * 2.5) / 100));
                        //var inventroryValue = Convert.ToDouble((Convert.ToDecimal(dtZakat.Rows[0][5])));
                        //var payable = Convert.ToDecimal(dtZakat.Rows[0][8]);
                        //var Subtract = (Convert.ToDecimal(inventroryValue) - Convert.ToDecimal(payable));


                       
                        //RptView.HTable.Add("CashTotalDebtReceive", dtZakat.Rows[0][7]);
                        //RptView.HTable.Add("CashTotalDebtPayable", dtZakat.Rows[0][8]);
                        //CashTotalDebtPayable
                    //}
                    //else
                    //{
                    //    RptView.HTable.Add("stockNetPurchase", 0.0);
                    //    RptView.HTable.Add("stockNetSales", 0.0);
                    //    RptView.HTable.Add("stockTotalReturn", 0.0);
                    //    RptView.HTable.Add("MovementMovementZakat", 0.0);
                    //    RptView.HTable.Add("CashTotalDebtReceive", 0.0);
                    //    RptView.HTable.Add("CashTotalDebtPayable", 0.0);
                    //}
                    if (dtCashInformation.Rows.Count > 0)
                    {
                        RptView.HTable.Add("CashTotalReceived", dtCashInformation.Rows[0][0]);
                        RptView.HTable.Add("CashTotalPaid", dtCashInformation.Rows[0][1]);
                    }else
                    {
                        RptView.HTable.Add("CashTotalReceived", 0.0);
                        RptView.HTable.Add("CashTotalPaid", 0.0);
                    }
                    
                    RptView.HTable.Add("SaleTotalPaid", 0.0);
                    //RptView.HTable.Add("SaleNetSales", Convert.ToDecimal(txtTotalSales.Text)-Convert.ToDecimal(txtSalereturn.Text));
                    RptView.HTable.Add("SaleNetSales", Convert.ToDecimal(txtTotalSales.Text) - Convert.ToDecimal(txtTotalPaid.Text) - Convert.ToDecimal(dtSaleInformation.Rows[0][5]));

                    RptView.HTable.Add("CashTotalSpent", Convert.ToDecimal(txtTotalExpenses.Text.ToString()));
                    RptView.HTable.Add("CashTotalDraw", Convert.ToDecimal(txtDraw.Text).ToString());
                    RptView.HTable.Add("CashNetCashForAllTime", Convert.ToDecimal(txtTotalcash.Text.ToString()));
                    RptView.HTable.Add("profitNetSales", 0.0);
                    //RptView.HTable.Add("profitNetIncome", 0.0);
                    RptView.HTable.Add("profitTotalSpent", 0.0);
                    RptView.HTable.Add("profitnetProfit", 0.0);



                    #region --- Net Stock Value ---

                    DataTable dtBalance = new DataTable();
                    //comment by thami on 29 aug 2016
                    //decAmt = 0;
                    //decRec = 0;
                    //dtBalance = reportbal.GetPayableReceivable();

                    //if (dtBalance.Rows.Count > 0)
                    //{
                    //    decAmt = Convert.ToDecimal(dtBalance.Compute("SUM(Payable)", String.Empty)) - Convert.ToDecimal(dtBalance.Compute("SUM(Paid)", String.Empty));
                    //    decRec = Convert.ToDecimal(dtBalance.Compute("SUM(Receivable)", String.Empty)) - Convert.ToDecimal(dtBalance.Compute("SUM(Received)", String.Empty));
                    //}

                    //add by thamil 
                    dtBalance = ObjEndHelper.objEndOfBal.GetPayableReceivable();
                    //if (dtBalance == null || dtBalance.Rows.Count <= 0)
                    //{
                    //    GeneralFunction.Information("NoRecordsFound", "Reports");
                    //    return;
                    //}
                    float _payable = 0;
                    float _receivable = 0;
                    if (dtBalance.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtBalance.Rows.Count; i++)
                        {
                            if (float.Parse(dtBalance.Rows[i]["Payable"].ToString()) > float.Parse(dtBalance.Rows[i]["Receivable"].ToString()))
                            {
                                _receivable += float.Parse(dtBalance.Rows[i]["Payable"].ToString()) - float.Parse(dtBalance.Rows[i]["Receivable"].ToString());
                            }
                            else
                            {
                                _payable += float.Parse(dtBalance.Rows[i]["Receivable"].ToString()) - float.Parse(dtBalance.Rows[i]["Payable"].ToString());
                            }
                        }
                    }


                    DataSet ds1 = ObjEndHelper.objEndOfBal.Get_InventoryValue_Reports();
                    Get_Details = ds1.Tables[0];
                    DataTable dt_sub = ds1.Tables.Count > 1 ? ds1.Tables[1] : null;

                    if (Get_Details.Rows.Count > 0)
                    {
                        DataTable sumoftotal = Get_Details.Clone();
                        DataRow dr1 = sumoftotal.NewRow();
                        for (int i = 1; i < Get_Details.Columns.Count; i++)
                        {
                            string columnname = Get_Details.Columns[i].ColumnName;
                            dr1[columnname] = Get_Details.Compute("Sum(" + columnname + ")", "").ToString();
                        }
                        sumoftotal.Rows.Add(dr1);
                        Get_Details = sumoftotal;

                        if (Get_Details.Rows.Count > 0)
                        {
                            RptView.HTable.Add("stockNetstock", Convert.ToDecimal(Get_Details.Rows[0][10]));
                        }
                        
                    }
                    else
                    {
                        RptView.HTable.Add("stockNetstock", 0);
                    }
                    //Obj_viewer.Report_Table = Get_Details;
                    //Obj_viewer.HTable.Clear();
                    //string category = obj_report.CategoryName;
                    //string company = obj_report.CompanyName;
                    //Obj_viewer.HTable.Add("Category", category);
                    //Obj_viewer.HTable.Add("Company", company);
                    ////Obj_viewer.HTable.Add("Payable", decAmt);
                    ////Obj_viewer.HTable.Add("Receivable", decRec);
                    //Obj_viewer.HTable.Add("Payable", _payable);
                    //Obj_viewer.HTable.Add("Receivable", _receivable);
                    //Obj_viewer.IsReportFooter = false;

                    #endregion



                    //    DataTable dtNetStock = new DataTable();
                    //ObjEndHelper = new EndOfDayHelper();
                    //dtNetStock = ObjEndHelper.objEndOfBal.GetEndOFTheDayReportNetStockInfomation();



                    //RptView.HTable.Add("UserName1", GeneralFunction.UserName.ToUpper());
                    RptView.isReportFooter = false;
                    endofTheReportFlag = 1;
                    RptView.LoadEvent();
                    
                    RptView.ShowDialog();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "EndofDay", " ", "Print end of days details", Convert.ToInt32(InvoiceAction.No));
                }
                else
                { GeneralFunction.Information("NoRecordsFound", "EndoftheDay"); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion


        #endregion

        #region "KeyPress Events"

        #region Dtp_FromDate_KeyPress
        private void Dtp_FromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    dtpToDate.Focus();

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Dtp_ToDate_KeyPress
        private void Dtp_ToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    chkDateALL.Focus();
                    chkDateALL.Checked = false;

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Dtp_FromTime_KeyPress
        private void Dtp_FromTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    dtpToTime.Focus();

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Dtp_ToTime_KeyPress
        private void Dtp_ToTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnView.Focus();

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Chk_DateALL_KeyPress
        private void Chk_DateALL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    dtpFromTime.Focus();

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #endregion

        #region"Key Down Events"

        #region end_of_day_KeyDown
        private void end_of_day_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            lblFromTime.Text = Additional_Barcode.GetValueByResourceKey("FT");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblToTime.Text = Additional_Barcode.GetValueByResourceKey("TT");
            lblNetCash.Text = Additional_Barcode.GetValueByResourceKey("NetCash");
            lblPaid.Text = Additional_Barcode.GetValueByResourceKey("Paid");
            lblReturnPurchase.Text = Additional_Barcode.GetValueByResourceKey("RPurchase");
            lblTotalCost.Text = Additional_Barcode.GetValueByResourceKey("TCost");
            lblTotalProfit.Text = Additional_Barcode.GetValueByResourceKey("TProfit");
            lblTotalPurchases.Text = Additional_Barcode.GetValueByResourceKey("TPurchase");
            lblTotalReceived.Text = Additional_Barcode.GetValueByResourceKey("TReceived");
            lblTotalsales.Text = Additional_Barcode.GetValueByResourceKey("TSales");
            lblTotalSpending.Text = Additional_Barcode.GetValueByResourceKey("TSpending");
            lblTotalSpoiled.Text = Additional_Barcode.GetValueByResourceKey("TotalSpoiled");
            btnView.Text = Additional_Barcode.GetValueByResourceKey("View");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            chkDateALL.Text = Additional_Barcode.GetValueByResourceKey("All");
            grpTotal.Text = Additional_Barcode.GetValueByResourceKey("Totals");
            this.Text = Additional_Barcode.GetValueByResourceKey("EndOfDay");
            lblSaleReturn.Text = Additional_Barcode.GetValueByResourceKey("ReturnSale");
            lblOpenBalance.Text = Additional_Barcode.GetValueByResourceKey("CashCapital");
            lblDrawing.Text = Additional_Barcode.GetValueByResourceKey("Draw");
            lblTotalCashAllTime.Text = Additional_Barcode.GetValueByResourceKey("TotalCash");
            lblePaymentCharges.Text = Additional_Barcode.GetValueByResourceKey("lblePaymentCharges");

            dgrEndofDay.Columns["UserName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserName");
            dgrEndofDay.Columns["Sales"].HeaderText = Additional_Barcode.GetValueByResourceKey("Sales");
            dgrEndofDay.Columns["SalesReturned"].HeaderText = Additional_Barcode.GetValueByResourceKey("SalesReturned");
            dgrEndofDay.Columns["Purchases"].HeaderText = Additional_Barcode.GetValueByResourceKey("Purchase");
            dgrEndofDay.Columns["PurchasesReturned"].HeaderText = Additional_Barcode.GetValueByResourceKey("PurchasesReturned");
            dgrEndofDay.Columns["Spoiled"].HeaderText = Additional_Barcode.GetValueByResourceKey("SpoiledInv");
            dgrEndofDay.Columns["Received"].HeaderText = Additional_Barcode.GetValueByResourceKey("Received");
            dgrEndofDay.Columns["Paid"].HeaderText = Additional_Barcode.GetValueByResourceKey("Paid");
            dgrEndofDay.Columns["Expenses"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expenses");
            dgrEndofDay.Columns["UserId"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
            

        }
        #endregion

        #region Chk_DateValidation
        private Boolean Chk_DateValidation()
        {
            try
            {
                DateTime dt1, dt2;

                if (chkDateALL.Checked == false)
                {

                    dt1 = Convert.ToDateTime(dtpFromDate.Value.Date);
                    dt2 = Convert.ToDateTime(dtpToDate.Value.Date);

                    if (dt1 > dt2)
                    {
                        GeneralFunction.Information("CompareFromDateToDate", this.Tag.ToString());
                        dtpFromDate.Select();
                        return false;
                    }
                }

            }
            catch (Exception ex) { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }
            return true;
        }

        #endregion

        #endregion

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button || ctrl is Label || ctrl is CheckBox || ctrl is RadioButton || ctrl is TabControl || ctrl is TabPage)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);

                }
                foreach (Control ctr in tableLayoutPanel4.Controls)
                {
                    if (ctr is Button || ctr is Label || ctr is CheckBox || ctr is RadioButton || ctr is TabControl || ctr is TabPage)
                        ctr.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }


            }
        }

        private void End_of_the_Day_FormClosing(object sender, FormClosingEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void chkDateALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateALL.Checked)
            {
                dtpFromDate.Enabled = dtpFromTime.Enabled = dtpToDate.Enabled = dtpToTime.Enabled = false;
            }
            else
                dtpFromDate.Enabled = dtpFromTime.Enabled = dtpToDate.Enabled = dtpToTime.Enabled = true;
        }

        private void End_of_the_Day_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjEndHelper.dicEndfDay = null;
            dicEndofDay = null;
            ObjEndHelper = null;
            this.Dispose();
        }

        private void txtTotalcash_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPaymentCharges_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
