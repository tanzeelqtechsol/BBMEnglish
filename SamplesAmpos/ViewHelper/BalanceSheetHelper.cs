using System;
using System.Collections.Generic;
using System.Linq;
using CommonHelper;
using BumedianBM.ArabicView;
using System.Globalization;
using BumedianBM;
using BumedianBM.CrystalReports;
using System.Data;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ViewHelper
{
    public class BalanceSheetHelper
    {
        #region Declaration
        public BALHelper.BalanceSheetBAL objBalanceSheetBAL;
        internal List<ObjectHelper.BalanceSheetObjcetClass> lstBalanceDetail = new List<ObjectHelper.BalanceSheetObjcetClass>();
        internal decimal TotalAmtReceived, TotalAmtPaid, TotalDiscount, TotalBalance;
        internal Dictionary<string, dynamic> dictPayReceipt;
        internal List<object> lst = new List<object>();
        int CurrentYear;
        internal Dictionary<string, string> dictDescription = new Dictionary<string, string>();
        string[] InvoiceEnglish = { "PurchaseInvoice", "SaleInvoice", "PurchaseReturnInvoice", "SaleReturnInvoice", "PayReceipt", "ReceiveReceipt", "Receivable", "Payable", "DebtAdjustment", "DepositPayment", "OpeningStock", "Balance" };
        internal bool AgentForm = false;
        #endregion
        DataTable dt = new DataTable();
        decimal decAmt, decRec, decTotal, decDiscount;
        internal decimal Balance;
        string InvoiceNameKey;
        DataTable dtBalance;
        DataTable dtBalanceTotal;
        public DataTable dtAdd;
        #region Constructor
        internal BalanceSheetHelper()
        {
            NewBalanceClass();
            LoadCurrentYear();
            CreateCurrentLangDesc();

        }
        #endregion

        #region OtherMethods
        internal void CreateCurrentLangDesc()
        {
            if (CultureInfo.CurrentUICulture.ToString() == "en-US")
            {
                foreach (string CurrentCultureInvoice in InvoiceEnglish)
                    dictDescription.Add(CurrentCultureInvoice, CurrentCultureInvoice);
            }
            else
            {
                foreach (string CurrentCultureInvoice in InvoiceEnglish)
                    dictDescription.Add(CurrentCultureInvoice, Additional_Barcode.GetValueByResourceKey(CurrentCultureInvoice));
            }
        }

        internal void NewBalanceClass()
        { objBalanceSheetBAL = new BALHelper.BalanceSheetBAL(); }

        private void LoadCurrentYear()
        { CurrentYear = objBalanceSheetBAL.GetCurrentYear(); }
        #endregion

        #region MainEventMethods
        internal bool Search()
        {
            TotalAmtPaid = TotalAmtReceived = TotalBalance = TotalDiscount = 0;
            string[] InvoiceSlpit = { string.Empty, string.Empty };
            //lstBalanceDetail = objBalanceSheetBAL.GetBalanceDetails();
            dtBalance = objBalanceSheetBAL.GetBalanceDetails();
            decAmt = 0;
            decTotal = 0;
            Balance = 0;
            decRec = 0;
            decDiscount = 0;


            DataSet dsBalance = new DataSet();
            //dsBalance =


            if (dtBalance.Rows.Count > 0)
            {
                dtAdd = new DataTable();
                if (dtAdd.Columns.Count < 6)
                {
                    dtAdd.Columns.Add("Date");
                    dtAdd.Columns.Add("Account");
                    dtAdd.Columns.Add("Description");
                    dtAdd.Columns.Add("Receivable");
                    dtAdd.Columns.Add("Payable");
                    dtAdd.Columns.Add("Balance");
                    dtAdd.Columns.Add("Id");//aDDED ON 09 july 2014 to get the sales invoice  id bcze it genrate  different id for pos sale and normal  sales invoice 
                    dtAdd.Columns.Add("Year");///added on 09 july 2014 to get the transaction year
                    dtAdd.Columns.Add("ArabicDescription");//added By Meena.R On 08Aug2014

                }
                for (int i = 0; i < dtBalance.Rows.Count; i++)
                {
                    DataRow drAdd;
                    drAdd = dtAdd.NewRow();
                    drAdd["Date"] = (dtBalance.Rows[i]["PurchaseDate"].ToString()).Split(' ')[1];
                    //drAdd["Date"] = Convert.ToDateTime(dtBalance.Rows[i]["PurchaseDate"]).ToShortDateString();
                    drAdd["Account"] = (string.IsNullOrEmpty(dtBalance.Rows[i]["Account"].ToString()) || dtBalance.Rows[i]["Account"].ToString() == " ") ? "" : Additional_Barcode.GetValueByResourceKey(dtBalance.Rows[i]["Account"].ToString());// "1";

                    drAdd["Id"] = dtBalance.Rows[i]["Id"].ToString();///Added on 09 july 2014 to get the uniqued id for each transaction
                    drAdd["Year"] = dtBalance.Rows[i]["Year"].ToString();///Added on 09 july 2014 to get the year id for each transaction
                    long year = Convert.ToInt32(dtBalance.Rows[i]["Year"]);
                    long currentyear = Convert.ToInt32(DateTime.Now.ToString("yy"));
                    if (year != currentyear)
                    {
                        int LastIndex = dtBalance.Rows[i]["NewYearNo"].ToString().LastIndexOf(' ');
                        string id = dtBalance.Rows[i]["NewYearNo"].ToString().Substring(LastIndex);
                        drAdd["Description"] = dtBalance.Rows[i]["NewYearNo"].ToString().Substring(0, LastIndex) + " " + year + "-" + id;
                        string[] strSplit = dtBalance.Rows[i]["NewYearNo"].ToString().Split(' ');
                        drAdd["ArabicDescription"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + year + "-" + id : GetInvoiceName(strSplit[0]);//line include to get the arabic description
                    }

                  ///  drAdd["Description"] = dtBalance.Rows[i]["Description"].ToString();/////Commented  on 09 july 2014 sale invoice id and new year sequence is is mismatch
                    else
                    {
                        drAdd["Description"] = dtBalance.Rows[i]["NewYearNo"].ToString();//Commended By Meena.R on 08Aug2014 
                        string[] strSplit = dtBalance.Rows[i]["NewYearNo"].ToString().Split(' ');
                        drAdd["ArabicDescription"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + dtBalance.Rows[i]["NewYearNo"].ToString().Substring(strSplit[0].Length, (dtBalance.Rows[i]["NewYearNo"].ToString().Length - strSplit[0].Length)) : GetInvoiceName(strSplit[0]);
                    }
                    drAdd["Receivable"] = Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"].ToString()).ToString("0.000");
                    drAdd["Payable"] = Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"].ToString()).ToString("0.000");

                    TotalAmtPaid = decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]);
                    TotalAmtReceived = decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]);
                    TotalDiscount = decDiscount = decDiscount + Convert.ToDecimal(dtBalance.Rows[i]["Discount"]);

                    if (Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]) == 0.0m)
                    {
                        decTotal = decTotal + (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]));
                        drAdd["Balance"] = decTotal;

                    }
                    else
                    {
                        if (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]) != 0.0m)
                        {
                            decTotal = decTotal + (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]));
                            drAdd["Balance"] = decTotal;
                        }//added for When clean DB balance sheet shown wrong balance
                        decTotal = decTotal - (Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]));
                        drAdd["Balance"] = decTotal;  ///Commanded by Meena.R to fix the blance mismatch
                    }
                    //if (dtBalance.Rows[i]["AmtReceived"].ToString() == "0.0000")
                    //{
                    //    decTotal = decTotal + (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]));
                    //    drAdd["Balance"] = decTotal;
                    //}
                    //else
                    //{
                    //    if ((Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"])) > 0)
                    //    {
                    //        decTotal = (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"])) - (Convert.ToDecimal((dtBalance.Rows[i]["AmtReceived"].ToString() != string.Empty) ? dtBalance.Rows[i]["AmtReceived"] : "0.000"));
                    //    }
                    //    else
                    //    {
                    //        decTotal = decTotal - (Convert.ToDecimal((dtBalance.Rows[i]["AmtReceived"].ToString() != string.Empty) ? dtBalance.Rows[i]["AmtReceived"] : "0.000"));
                    //    }
                    //    drAdd["Balance"] = decTotal;
                    //}

                    if (drAdd["Balance"].ToString().IndexOf("-") >= 0)
                    {
                        drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"].ToString().Remove(0, 1)).ToString("0.000");
                    }
                    else { drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"]).ToString("0.000"); }

                    dtAdd.Rows.Add(drAdd);

                }

                TotalBalance = Balance = (decRec - decAmt);

                //////// lstBalanceDetail=lstBalanceDetail.
                ////// if (lstBalanceDetail.Count > 0)
                ////// {
                //////     dt = ConvertionHelper.ConvertToDataTable<ObjectHelper.BalanceSheetObjcetClass>(lstBalanceDetail);
                //////     for (int i = 0; i < lstBalanceDetail.Count; i++)
                //////     {
                //////         TotalBalance = TotalBalance + lstBalanceDetail[i].AmountReceived - lstBalanceDetail[i].AmountPaid;
                //////         lstBalanceDetail[i].Balance = TotalBalance < 0 ? -TotalBalance : TotalBalance;
                //////         TotalAmtPaid += lstBalanceDetail[i].AmountPaid;
                //////         TotalAmtReceived += lstBalanceDetail[i].AmountReceived;
                //////         TotalDiscount += lstBalanceDetail[i].Discount;
                //////         lstBalanceDetail[i].Account = 1;
                //////         if (CurrentYear != lstBalanceDetail[i].Year)
                //////             lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo.Insert(lstBalanceDetail[i].YearSquenceNo.IndexOf(" ") + 1, lstBalanceDetail[i].Year.ToString() + "-");
                //////         else lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo;
                //////         //if (lstBalanceDetail[i].Description.Contains("Balance") || lstBalanceDetail[i].Description.Contains("توازن"))
                ////         //{
                ////         //    //lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo.Replace(lstBalanceDetail[i].YearSquenceNo.Substring(lstBalanceDetail[i].YearSquenceNo.IndexOf("-"),lstBalanceDetail[i].YearSquenceNo.IndexOf(" ")),"");
                ////         //    //lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo.Replace(lstBalanceDetail[i].YearSquenceNo.Substring(lstBalanceDetail[i].YearSquenceNo.IndexOf("-"), lstBalanceDetail[i].YearSquenceNo.IndexOf("")), "");
                ////         //    int a = lstBalanceDetail[i].YearSquenceNo.IndexOf("");
                ////         //    int b = lstBalanceDetail[i].YearSquenceNo.IndexOf(" ");
                ////         //    lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo.Substring(lstBalanceDetail[i].YearSquenceNo.IndexOf("-"),13);
                ////         //}
                ////         //else
                ////         //{
                ////         //    lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].YearSquenceNo.Replace(lstBalanceDetail[i].YearSquenceNo.Substring(0, lstBalanceDetail[i].YearSquenceNo.IndexOf(" ")), dictDescription[lstBalanceDetail[i].YearSquenceNo.Substring(0, lstBalanceDetail[i].YearSquenceNo.IndexOf(" ")).ToString()]);
                ////         //}
                ////         //lstBalanceDetail[i].InvoiceNameID = lstBalanceDetail[i].Description .Replace(lstBalanceDetail[i].Description.Substring(0, lstBalanceDetail[i].Description.IndexOf("-")), dictDescription[lstBalanceDetail[i].Description.Substring(0, lstBalanceDetail[i].Description.IndexOf(" ")).ToString()]);
                ////     }
                ////     lstBalanceDetail = lstBalanceDetail.Select(e => new ObjectHelper.BalanceSheetObjcetClass { Balance = Convert.ToDecimal(e.Balance.ToString(".000")), AmountPaid = Convert.ToDecimal(e.AmountPaid.ToString(".000")), AmountReceived = Convert.ToDecimal(e.AmountReceived.ToString(".000")), InvoiceNameID = e.InvoiceNameID, Account = e.Account, ProcessDate = e.ProcessDate.Value.Date }).ToList();
                return true;
            }

            else
            {
                if (AgentForm != true)
                {
                    GeneralFunction.Information("NoBalanceAgent", "Balance Sheet");
                }
                lstBalanceDetail.Clear();
                return false;
            }
        }

        internal bool PayReceipt()
        {
            if (objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName.Length != 0)
            {
                Pay_Receipt objPayReceipt = new Pay_Receipt();
                objPayReceipt.strPayTo = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                objPayReceipt.strPayTo1 = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID;
                objPayReceipt.strDiscription = Additional_Barcode.GetValueByResourceKey("downpayment");

                //Include on 22APril 2014-------------------------------
                //  objPayReceipt.strValue = (TotalBalance != 0 ? TotalBalance : 0).ToString("0.000");commented on 24 may 2014 MTX_value field make a empty while open the payreceipt form through balancesheet 
                // objPayReceipt.MTxt_Balance.Text = (TotalBalance != 0 ? TotalBalance : 0).ToString("0.000");
                //-------------------------------------------------------
                objPayReceipt.strValue = "0.000";
                objPayReceipt.Tag = "BalanceSheet";
                objPayReceipt.ShowDialog();

                return true;
            }
            else
                return false;
        }

        internal bool ReceiveReceipt()
        {
            if (objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName.Length != 0)
            {
                Receive_Receipt objReceiveReceipt = new Receive_Receipt();
                objReceiveReceipt.Tag = "BalanceSheet";
                objReceiveReceipt.Description = Additional_Barcode.GetValueByResourceKey("DepositPayment");
                //commented on 20april2014
                //objReceiveReceipt.ReceiptName = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                objReceiveReceipt.ReceivedFrom = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                objReceiveReceipt.MTxt_Value.Text = "0.000";
                objReceiveReceipt.MTxt_Balance.Text = (TotalBalance != 0 ? TotalBalance : 0).ToString("0.000");
                objReceiveReceipt.NetAmt = "0.000";


                objReceiveReceipt.ShowDialog();
                return true;
            }
            else
                return false;
        }

        internal void OpenInvoice(string[] InvoiceName)
        {
            InvoiceNameKey = string.Empty;
            if (CultureInfo.CurrentUICulture.ToString() != "en-US")
            {

                foreach (KeyValuePair<string, string> KeyValue in dictDescription)
                {
                    if (!InvoiceName[0].Contains("Balance"))
                    {
                        if (KeyValue.Value == Additional_Barcode.GetValueByResourceKey(InvoiceName[0]).ToString())///based on culture to change the form name from english to arabic on 30 jun 2014
                        {
                            InvoiceNameKey = KeyValue.Key;
                            break;
                        }
                    }
                    else
                        InvoiceNameKey = InvoiceName[0];
                }
            }
            else
            {
                InvoiceNameKey = InvoiceName[0];
            }
            switch (InvoiceNameKey)
            {
                case "PurchaseInvoice":
                    if (UserScreenLimidations.PurchaseInvoice)
                    {
                        using (Purchase_Invoice objPurchaseInvoice = new Purchase_Invoice())
                        {
                            objPurchaseInvoice.IDFromBalanceSheet = InvoiceName[1];
                            objPurchaseInvoice.ShowDialog();
                        }
                    }
                    break;
                case "SaleInvoice"://Incomplete( Condition For Selecting POS ans SaleIncoice Screen  ) 
                    if (InvoiceName[1].Contains('P'))
                    {
                        if (UserScreenLimidations.PosScreen)
                        {
                            using (POS_Screen objPOSScreen = new POS_Screen())
                            {
                                // POS Not Completed ( Assign POSInvoiceID )
                                objPOSScreen.FindPosInvoiceNo = InvoiceName[2]; //assign the current pos id to findposinvoice no on 15 july2014
                                objPOSScreen.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        if (UserScreenLimidations.SaleInvoice)
                        {
                            using (Sales_Invoice objSalesInvoice = new Sales_Invoice())
                            {
                                //objBalanceSheetBAL.objBalanceSheetObjcetClass.saleyearsequenceid = "";
                                //objBalanceSheetBAL.objBalanceSheetObjcetClass.saleyear = "";

                                objSalesInvoice.find_saleinv = InvoiceName[2];
                                //objBalanceSheetBAL.objBalanceSheetObjcetClass.saleyearsequenceid = InvoiceName[1];
                                //objBalanceSheetBAL.objBalanceSheetObjcetClass.saleyear = InvoiceName[2];

                                objSalesInvoice.find_saleID = Convert.ToInt32(InvoiceName[2]);
                                objSalesInvoice.ShowDialog();
                            }
                        }
                    }
                    break;
                case "PurchaseReturnInvoice":
                    if (UserScreenLimidations.PurchaseReturnInvoice)
                    {
                        using (PurchaseReturnInvoice objPurchaseReturnInvoice = new PurchaseReturnInvoice())
                        {
                            objPurchaseReturnInvoice.ObjHelper.ObjBALClass.ObjPurchaseReturn.InvoiceNo = Convert.ToInt64(InvoiceName[1]);
                            objPurchaseReturnInvoice.IDFromOthers = InvoiceName[1];
                            objPurchaseReturnInvoice.ShowDialog();
                        }
                    }
                    break;
                case "SaleReturnInvoice":
                    if (UserScreenLimidations.SaleReturnInvoice)
                    {
                        using (Sales_Return_Invoice objSalesReturnInvoice = new Sales_Return_Invoice())
                        {
                            objSalesReturnInvoice.objSalesReturnHelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaleReturnID = Convert.ToInt64(InvoiceName[1]);
                            objSalesReturnInvoice.ShowDialog();
                        }
                    }
                    break;
                case "PayReceipt":
                    if (UserScreenLimidations.PayReceipt)
                    {
                        using (Pay_Receipt objPayReceipt = new Pay_Receipt())
                        {
                            objPayReceipt.strPayTo = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                            objPayReceipt.strPayTo1 = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID;
                            if (dictPayReceipt.Count > 0 && InvoiceName[1].Length > 0)
                            {
                                objPayReceipt.strDiscription = InvoiceName[0] + ' ' + InvoiceName[1];
                                objPayReceipt.strValue = dictPayReceipt["Receivable"];
                                objPayReceipt.strReceiptNo = InvoiceName[1];
                                objPayReceipt.decBalance = dictPayReceipt["Balance"];
                            }
                            objPayReceipt.strFromInvoice = 0;
                            objPayReceipt.strFromInvoiceID = 0;
                            //   objPayReceipt.dtPaymentDate = Convert.ToDateTime();
                            objPayReceipt.objPayReceiptHelper.balancesheetopen = true;////open the pay receipt from balance sheet then condition is true otherwise false 
                            objPayReceipt.ShowDialog();
                            objPayReceipt.objPayReceiptHelper.balancesheetopen = false;
                        }
                    }
                    break;
                case "ReceiveReceipt":
                    if (UserScreenLimidations.ReceiveReceipt)
                    {
                        using (Receive_Receipt objReceiveReceipt = new Receive_Receipt())
                        {
                            objReceiveReceipt.Tag = "BalanceSheet";
                            objReceiveReceipt.ReceiptName = InvoiceName[1];
                            objReceiveReceipt.objReceiveReceiptHelper.balancesheetopen = true;////open the pay receipt from balance sheet then condition is true otherwise false 
                            objReceiveReceipt.ShowDialog();
                            objReceiveReceipt.objReceiveReceiptHelper.balancesheetopen = false;
                        }
                    }
                    break;
                case "Payable":
                    if (UserScreenLimidations.DeptAdjustment)
                    {
                        using (Debt_Adjustment ObjDebtAdjustment = new Debt_Adjustment())
                        {
                            ObjDebtAdjustment.ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt32(InvoiceName[1]);
                            ObjDebtAdjustment.ShowDialog();
                        }
                    }
                    break;
                default:
                    if (UserScreenLimidations.DeptAdjustment)
                    {
                        using (Debt_Adjustment ObjDebtAdjustment1 = new Debt_Adjustment())
                        {
                            ObjDebtAdjustment1.ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt32(InvoiceName[1] == " " ? "0" : InvoiceName[1]);
                            ObjDebtAdjustment1.IsFromBalance = true;
                            ObjDebtAdjustment1.ShowDialog();
                        }
                    }
                    break;
            }
        }

        internal void DisplayAgentDetailForm()
        {
            if (objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID != 0 && objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName.Length != 0)
            {
                Agent_Details objAgentDetails = new Agent_Details();
                objAgentDetails.ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID;
                objAgentDetails.ObjHelper.ObjbalClass.ObjAgentDetailObject.Name = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;
                objAgentDetails.ObjHelper.AgentNameSelectedIndexChanged();
                objAgentDetails.AgentFileSplit();

                objAgentDetails.setControlFromObject();
                objAgentDetails.ShowDialog();
            }
            else
            { GeneralFunction.Information("EmptyAgentName", "Balance Sheet"); }
        }

        internal void DisplayEndOfDayForm()
        {
            End_of_the_Day objEndofDay = new End_of_the_Day();
            objEndofDay.ShowDialog();
        }

        internal void printBalanceSheet()
        {
            decimal decAmt = 0, decRec = 0, decTotal = 0, decDiscount = 0;
            DataTable dtLocal = new DataTable("BalanceSheet");
            if (dtBalance.Rows.Count > 0)
            {
                if (dtLocal.Columns.Count < 6)
                {
                    dtLocal.Columns.Add("Date");
                    dtLocal.Columns.Add("Account");
                    dtLocal.Columns.Add("Description");
                    dtLocal.Columns.Add("Receivable", typeof(decimal));
                    dtLocal.Columns.Add("Payable", typeof(decimal));
                    dtLocal.Columns.Add("Balance", typeof(decimal));
                    dtLocal.Columns.Add("AgentID");
                    dtLocal.Columns.Add("AgentName");
                }
                for (int i = 0; i < dtBalance.Rows.Count; i++)
                {
                    DataRow drAdd;
                    drAdd = dtLocal.NewRow();
                    drAdd["Date"] = Convert.ToDateTime(dtBalance.Rows[i]["PurchaseDate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                    drAdd["Account"] = "1";
                    long year = Convert.ToInt32(dtBalance.Rows[i]["Year"]);
                    long currentyear = Convert.ToInt32(DateTime.Now.ToString("yy"));
                    if (year != currentyear)
                    {
                        int LastIndex = dtBalance.Rows[i]["NewYearNo"].ToString().LastIndexOf(' ');
                        string id = dtBalance.Rows[i]["NewYearNo"].ToString().Substring(LastIndex);
                        //drAdd["Description"] = dtBalance.Rows[i]["NewYearNo"].ToString().Substring(0, LastIndex) + " " + year + "-" + id;
                        string[] strSplit = dtBalance.Rows[i]["NewYearNo"].ToString().Split(' ');
                        //drAdd["ArabicDescription"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + year + "-" + id : GetInvoiceName(strSplit[0]);//line include to get the arabic description
                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        {
                            drAdd["Description"] = dtBalance.Rows[i]["NewYearNo"].ToString().Substring(0, LastIndex) + " " + year + "-" + id; //dtBalance.Rows[i]["Description"];
                        }
                        else
                        {
                            drAdd["Description"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + year + "-" + id : GetInvoiceName(strSplit[0]);//line include to get the arabic description
                        }
                    }

///  drAdd["Description"] = dtBalance.Rows[i]["Description"].ToString();/////Commented  on 09 july 2014 sale invoice id and new year sequence is is mismatch
                    else
                    {
                        string[] strSplit = dtBalance.Rows[i]["NewYearNo"].ToString().Split(' ');
                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        {
                            drAdd["Description"] = dtBalance.Rows[i]["NewYearNo"].ToString();
                        }
                        else
                        {
                            drAdd["Description"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + dtBalance.Rows[i]["NewYearNo"].ToString().Substring(strSplit[0].Length, (dtBalance.Rows[i]["NewYearNo"].ToString().Length - strSplit[0].Length)) : GetInvoiceName(strSplit[0]);
                        }
                    }

                    drAdd["Receivable"] = dtBalance.Rows[i]["AmtReceived"];
                    drAdd["Payable"] = dtBalance.Rows[i]["NetAmount"];

                    decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]);
                    decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]);
                    decDiscount = decDiscount + Convert.ToDecimal(dtBalance.Rows[i]["Discount"]);

                    if (Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"].ToString()) == 0.0m)
                    {
                        decTotal = decTotal + Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]);
                        drAdd["Balance"] = decTotal;
                    }
                    else
                    {
                        if (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]) != 0.0m)
                        {
                            decTotal = decTotal + (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]));
                            drAdd["Balance"] = decTotal;
                        }//added for When clean DB balance sheet shown wrong balance
                        decTotal = decTotal - (Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]));
                        drAdd["Balance"] = decTotal;
                    }

                    if (drAdd["Balance"].ToString().IndexOf("-") >= 0)
                    {
                        drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"].ToString().Remove(0, 1));
                    }
                    else { drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"]); }

                    drAdd["AgentID"] = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID;
                    drAdd["AgentName"] = objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName;

                    dtLocal.Rows.Add(drAdd);
                }
                if (dtLocal != null)
                {
                    if (dtLocal.Rows.Count > 0)
                    {
                        Rpt_BalanceSheet summery = new Rpt_BalanceSheet();
                        ReportsView RptView = new ReportsView();
                        RptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("BalanceSheet");
                        RptView.Report_Table = dtLocal;
                        RptView.HTable.Clear();
                        if (objBalanceSheetBAL.objBalanceSheetObjcetClass.Status==1)
                        {
                            RptView.HTable.Add("FromDate", DateTime.Now);
                            RptView.HTable.Add("ToDate", DateTime.Now);
                            RptView.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            RptView.HTable.Add("FromDate", objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceFromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            RptView.HTable.Add("ToDate", objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            RptView.HTable.Add("HideDate", false);
                        }
                        RptView.HTable.Add("AgentName", objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName);
                        // Sheet Total Fields
                        dtBalanceTotal = objBalanceSheetBAL.GetBalanceTotalDetails();
                        RptView.HTable.Add("TotalReceivable", dtBalanceTotal.Rows[0][0]);
                        RptView.HTable.Add("Balance", dtBalanceTotal.Rows[0][2]);
                        RptView.HTable.Add("TotalPayable", dtBalanceTotal.Rows[0][1]);
                        RptView.HTable.Add("UserName", GeneralFunction.UserName.ToUpper());
                        RptView.HTable.Add("IssueDateTime", DateTime.Now.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()+"-hh:mm:ss tt"));
                        // Invoices
                        int SaleInvoiceTotal = Convert.ToInt32(dtBalanceTotal.Rows[0][3]);
                        int PurchaseInvoiceTotal= Convert.ToInt32(dtBalanceTotal.Rows[0][4]);
                        string PurchaseText = PurchaseInvoiceTotal == 0 ? "" : "/" + PurchaseInvoiceTotal;
                        string InvoiceText = SaleInvoiceTotal + PurchaseText;
                        RptView.HTable.Add("TotalInvoice", InvoiceText);
                        //
                        // Receipt
                        int PayReceiptTotal = Convert.ToInt32(dtBalanceTotal.Rows[0][5]);
                        int ReceivedReceiptTotal = Convert.ToInt32(dtBalanceTotal.Rows[0][6]);
                        string Text = ReceivedReceiptTotal == 0 ? "" : "/" + ReceivedReceiptTotal;
                        string ReceiptText = PayReceiptTotal + Text;
                        RptView.HTable.Add("TotalReceipt", ReceiptText);
                        //
                        var lstAmount = dtBalanceTotal.Rows[0][7];
                        if (lstAmount.ToString() == string.Empty)
                        {
                            lstAmount = "0";
                        }
                        RptView.HTable.Add("LastAmount", lstAmount);

                        var lastDate = (dtBalanceTotal.Rows[0][8]).ToString();
                        if (lastDate == null) {
                        }else{ RptView.HTable.Add("LastDate", lastDate );}
                        
                        //

                        RptView.RptDoc = summery;
                        RptView.LoadEvent();
                        RptView.ShowDialog();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "BalanceSheet", " ", "Print balance sheet details", Convert.ToInt32(InvoiceAction.No));
                    }

                }

            }
        }

        private string GetInvoiceName(string strKey)
        {
            try
            {

                if (strKey.Contains("PurchaseInvoice"))
                    return "فاتورة مشتريات";
                else if (strKey.Contains("SaleInvoice"))
                    return "فاتورة مبيعات";
                else if (strKey.Contains("PurchaseReturnInvoice"))
                    return "ترجيع مشتريات ";
                else if (strKey.Contains("SaleReturnInvoice"))
                    return "ترجيع مبيعات ";
                else if (strKey.Contains("RentInvoice"))
                    return "فاتورة ايجار";
                else if (strKey.Contains("PayReceipt"))
                    return "ايصال صرف";
                else if (strKey.Contains("ReceiveReceipt"))
                    return "ايصال قبض";
                else if (strKey.Contains("Receivable"))
                    return "المقبوضات";
                else if (strKey.Contains("Payable"))
                    return "المدفوعات";
                else if (strKey.Contains("Balance"))
                {
                    string[] str = strKey.Split('-');
                    return "تعديل ارصدة" + "-" + str[1];
                }
                else if (strKey.Contains("DepositPayment"))
                    return "دفعة على الحساب";
                else if (strKey.Contains("OpeningStock"))
                    return "بضاعة اول المدة";
                else
                    return strKey;
            }

            catch (Exception ex)
            {
                return strKey;
            }
        }
        #endregion
    }
}
