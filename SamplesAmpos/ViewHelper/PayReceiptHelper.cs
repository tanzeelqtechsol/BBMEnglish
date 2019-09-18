using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using HSB_ObjectHelper;
using CommonHelper;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using ObjectHelper;
using System.Drawing.Printing;

namespace BumedianBM.ViewHelper
{
    public class PayReceiptHelper
    {
        #region Declaration
        public PayReceiptBAL objPayReceiptBALClass;
        public List<PayReceiptObject> lstBalance = new List<PayReceiptObject>();
        public List<PayReceiptObject> lstAllPayReceiptID = new List<PayReceiptObject>();
        public List<PayReceiptObject> lstPayFromBalance = new List<PayReceiptObject>();
        List<long> PayReceipt = new List<long>();
        long CurrentYear;
        public bool balancesheetopen = false, IsFromQuickReturn = false;
        #endregion

        #region Constructor
        public PayReceiptHelper()
        {
            objPayReceiptBALClass = new PayReceiptBAL();

        }
        #endregion

        #region Getting Bal Class
        public PayReceiptBAL objPayReceiptBAL
        {
            get { return objPayReceiptBALClass; }
            set { objPayReceiptBALClass = value; }
        }
        #endregion

        #region Methods

        #region GetBalanceHelper
        public void GetBalanceHelper()
        {
            lstBalance = objPayReceiptBALClass.GetBalanceBal();

        }
        #endregion

        #region SavePayReceiptHelper
        public bool SavePayReceiptHelper()
        {
            //bool value = objPayReceiptBALClass.SavePayReceiptBal();
            //return value;
            return objPayReceiptBALClass.SavePayReceiptBal();
        }
        public bool Insert_BankTransactionDetailsHelper(bool IsEmptyRecord)
        {
            //bool value = objReceiveReceiptBALClass.SaveReceiveReceiptBal();
            //return value;
            if (IsEmptyRecord)
            {
                objPayReceiptBALClass.GetBankDepositMaxID();
            }
            return objPayReceiptBALClass.Insert_BankTransactionDetailsBAL(IsEmptyRecord);
        }
        public object GetBankDeposit_MaxID()
        {
            return objPayReceiptBALClass.GetBankDeposit_MaxID();
        }
        #endregion

        #region DeleteyReceiptHelper
        public bool DeleteyReceiptHelper()
        {
            //bool value = objPayReceiptBALClass.DeletePayReceiptBal();
            //return value;
            return objPayReceiptBALClass.DeletePayReceiptBal();
        }
        #endregion

        #region  GetLastInsertedRecordHelper
        public bool GetLastInsertedRecordHelper()
        {
            //bool value = objPayReceiptBALClass.GetLastInsertedRecord(out lstBalance);
            //return value;
            return objPayReceiptBALClass.GetLastInsertedRecord(out lstBalance);
        }
        #endregion

        #region GetPayRecordHelper
        public bool GetPayRecordHelper()
        {
            //bool value = objPayReceiptBALClass.GetPayRecordBal(out lstBalance);
            //return value;
            return objPayReceiptBALClass.GetPayRecordBal(out lstBalance);
        }
        #endregion

        #region GetSearchedRecordHelper
        public bool GetSearchedRecordHelper()
        {
            //bool value = objPayReceiptBALClass.GetSearchedRecordBal(out lstBalance);
            //return value;
            return objPayReceiptBALClass.GetSearchedRecordBal(out lstBalance);
        }
        #endregion

        #region CheckCurrentYear
        public void CheckCurrentYear(Dictionary<string, long> lstRecords)
        {

            if (CurrentYear == lstRecords["Year"])
            {
                objPayReceiptBAL.objPayReceiptObject.CurrentYearStr = lstRecords["YearSequenceNo"].ToString();
            }
            else
            {
                objPayReceiptBAL.objPayReceiptObject.CurrentYearStr = lstRecords["Year"].ToString() + "-" + lstRecords["YearSequenceNo"].ToString();
            }

        }
        #endregion

        #region GetCurrentYear
        public void GetCurrentYearAndMaxID()
        {
            List<PayReceiptObject> ListPaymentMaxIdList = new List<PayReceiptObject>();
            CurrentYear = Convert.ToInt32(objPayReceiptBALClass.GetCurrentYearBal());
            ListPaymentMaxIdList = objPayReceiptBALClass.GetAllPaymntIdBal();

        }
        #endregion

        #region GetAllPaymntIdHelper
        public void GetAllPaymntIdHelper()
        {
            lstAllPayReceiptID = objPayReceiptBALClass.GetAllPaymntIdBal();
        }
        #endregion

        public void PrintReceipt()
        {
                ReportsView frmView;
                Rpt_InvoiceReceipt summery;
                try
                {
                    CurrencyConverter cls = new CurrencyConverter();
                    frmView = new ReportsView();
                    frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("PayReceipt");
                    summery = new Rpt_InvoiceReceipt();
                    //summery.Refresh();
                    DataTable dt = new DataTable();
                    dt = objPayReceiptBAL.GetPayReceiptPrintReportBal();
                    frmView.HTable.Clear();
                if (dt.Rows.Count > 0)
                {
                    string strInvYear = string.Empty;
                    string[] str = dt.Rows[0]["NewYearNo"].ToString().Split('-');
                    if (str.Length > 1)
                    {
                        strInvYear = str[0] + "-";
                    }
                    string AmtinWords = string.Empty;
                    //if()
                    //frmView.HTable.Add("ReceiptName", "Pay Receipt");
                    frmView.HTable.Add("ReceiptName", frmView.Text);
                    frmView.HTable.Add("ReceiptNo", dt.Rows[0]["NewYearNo"].ToString());
                    frmView.HTable.Add("ReceivedFrom", dt.Rows[0]["AgentName"].ToString());
                    frmView.HTable.Add("Amount", dt.Rows[0]["AmountPaid"] == DBNull.Value ? "0" : decimal.Parse(dt.Rows[0]["AmountPaid"].ToString()).ToString());
                    frmView.HTable.Add("Description", dt.Rows[0]["Description"].ToString());
                    frmView.HTable.Add("InvoiceNo", strInvYear + dt.Rows[0]["Purchase"].ToString());
                    frmView.HTable.Add("AmountLetter", dt.Rows[0]["AmountPaid"] == DBNull.Value ? "0" : cls.Convert(decimal.Parse(dt.Rows[0]["AmountPaid"].ToString()).ToString("0.000")));
                    frmView.HTable.Add("Note", objPayReceiptBAL.objPayReceiptObject.PayReason);
                    frmView.HTable.Add("Remaining", objPayReceiptBAL.objPayReceiptObject.BalanceAmount);

                    frmView.RptDoc = summery;
                    ReportDocument rpt = summery;
                    Tables tbl = rpt.Database.Tables;
                    frmView.Repnum = tbl;
                    frmView.IsItemNo = false;
                    frmView.IsReportFooter = false;
                    frmView.LoadEvent();
                    if (IsFromQuickReturn)
                    {
                        if (GeneralOptionSetting.FlagPrintAfterClosingRecipt == "Y")
                        {
                            frmView.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                        }
                        else
                        {
                            frmView.ShowDialog();
                        }
                        IsFromQuickReturn = false;
                    }
                    else
                    {
                        if (objPayReceiptBAL.objPayReceiptObject.PrintPreviewChecked)
                        {
                            frmView.ShowDialog();
                        }
                        else
                        {
                            // Printer Setup Handling Add these Lines
                            PrinterSettings printerSettings = new PrinterSettings();
                            printerSettings.PrinterName = GeneralFunction.PrinterName("Receipt");
                            frmView.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false);
                            // 

                        }

                    }
                }
                else
                {
                    GeneralFunction.Information("NotSaveReceipt", "PayReceipt");

                }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    frmView = null;
                    summery = null;
                }
        }

        #endregion

        #region Validation

        public Boolean ValidateReceipt()
        {

            if (objPayReceiptBAL.objPayReceiptObject.PayTo == 0)
            {
                GeneralFunction.Information("EmptyPayTo", "PayReceipt");
                // Cmb_PayTo.Focus();
                objPayReceiptBALClass.objPayReceiptObject.ValidationString = "Cmb_PayTo";
                return false;
            }
            else if (objPayReceiptBAL.objPayReceiptObject.PayDiscription == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", "PayReceipt");
                //  MTxt_Discription.Focus();
                objPayReceiptBALClass.objPayReceiptObject.ValidationString = "MTxt_Discription";
                return false;
            }
            else if (objPayReceiptBAL.objPayReceiptObject.PayValue.ToString() == string.Empty || objPayReceiptBAL.objPayReceiptObject.PayValue.ToString() == "0.000")
            {
                GeneralFunction.Information("GreaterthanZeroAmount", "PayReceipt");
                //  MTxt_Value.Focus();
                objPayReceiptBALClass.objPayReceiptObject.ValidationString = "MTxt_Value";
                return false;
            }
            else if (objPayReceiptBAL.objPayReceiptObject.CheckChecked && objPayReceiptBAL.objPayReceiptObject.BankSelectedVal == 0)
            {
                GeneralFunction.Information("EmptyBank", "PayReceipt");
                // Cmb_Bank.Focus();
                objPayReceiptBALClass.objPayReceiptObject.ValidationString = "Cmb_Bank";
                return false;
            }
            else if (objPayReceiptBAL.objPayReceiptObject.CheckChecked && objPayReceiptBAL.objPayReceiptObject.BranchSelectedVal == 0)
            {
                GeneralFunction.Information("EmptyBranch", "PayReceipt");
                //  Cmb_Bank.Focus();
                objPayReceiptBALClass.objPayReceiptObject.ValidationString = "Cmb_Branch";
                return false;
            }
            else
                return true;
        }


        public string BindMaxId()
        {
            List<PayReceiptObject> PayReceiptRecord = new List<PayReceiptObject>();
            String Status = string.Empty;
            bool LabelStatus;
            object GetMaxID;
            GetMaxID = objPayReceiptBALClass.GetMaxIdRecord();

            int CheckMaxId = Convert.ToInt32(GetMaxID);
            if (CheckMaxId != 0)
            {
                if (balancesheetopen == false)
                {
                    objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo = CheckMaxId;
                }

                LabelStatus = objPayReceiptBALClass.GetPayRecordBal(out PayReceiptRecord);//this line commanded by Meena.R on 10/06/2014
                lstPayFromBalance = PayReceiptRecord.ToList();
                if (AssignFromListToObject(PayReceiptRecord) != string.Empty)
                    Status = AssignFromListToObject(PayReceiptRecord);
                GetCurrentYearAndMaxID();
                if (PayReceiptRecord.Count > 0)
                {
                    Dictionary<string, long> dicofyear = new Dictionary<string, long>();
                    dicofyear.Add("Year", PayReceiptRecord[0].Year);
                    dicofyear.Add("YearSequenceNo", PayReceiptRecord[0].YearSequenceNo);
                    CheckCurrentYear(dicofyear);
                }
                //  CheckCurrentYear(PayReceiptRecord); ///              
                return Status;

            }
            else
            {
                CreateEmptyRecord();
                Status = GeneralFunction.ChangeLanguageforCustomMsg("New");
                return Status;

            }



        }
        private String AssignFromListToObject(List<PayReceiptObject> payreceipt)
        {
            if (payreceipt.Count > 0)
            {
                objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo = Convert.ToInt32(payreceipt[0].PayReceiptNo);
                objPayReceiptBALClass.objPayReceiptObject.AgentID = Convert.ToInt16(payreceipt[0].AgentID);
                objPayReceiptBALClass.objPayReceiptObject.PayDiscription = payreceipt[0].PayDiscription.ToString();
                objPayReceiptBALClass.objPayReceiptObject.AmountPaid = Convert.ToDecimal(payreceipt[0].AmountPaid);
                objPayReceiptBALClass.objPayReceiptObject.BalanceAmount = Convert.ToDecimal(payreceipt[0].BalanceAmount);
                objPayReceiptBALClass.objPayReceiptObject.PayReason = payreceipt[0].PayReason.ToString();
                objPayReceiptBALClass.objPayReceiptObject.Year = Convert.ToInt32(payreceipt[0].Year);
                objPayReceiptBALClass.objPayReceiptObject.YearSequenceNo = Convert.ToInt64(payreceipt[0].YearSequenceNo);
                objPayReceiptBALClass.objPayReceiptObject.PayDate = Convert.ToDateTime(payreceipt[0].PayDate);
                objPayReceiptBALClass.objPayReceiptObject.PayMethodID = Convert.ToInt16(payreceipt[0].PayMethodID);
                objPayReceiptBALClass.objPayReceiptObject.BankID = Convert.ToInt16(payreceipt[0].BankID);
                objPayReceiptBALClass.objPayReceiptObject.BranchID = Convert.ToInt16(payreceipt[0].BranchID);
                objPayReceiptBALClass.objPayReceiptObject.PayRemarks = payreceipt[0].PayRemarks;
                objPayReceiptBALClass.objPayReceiptObject.PayStatus = Convert.ToInt16(payreceipt[0].PayStatus);
                if (string.IsNullOrEmpty(objPayReceiptBALClass.objPayReceiptObject.PayDiscription) && objPayReceiptBALClass.objPayReceiptObject.PayStatus == 1)
                    return GeneralFunction.ChangeLanguageforCustomMsg("New");
                else if (objPayReceiptBALClass.objPayReceiptObject.PayStatus == 0)
                    return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                else
                    return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
            }
            return "";
        }



        public void CreateEmptyRecord()
        {
            PayReceipt = objPayReceiptBALClass.GetPayReceiptMaxID();
            objPayReceiptBALClass.objPayReceiptObject.Year = Convert.ToInt32(PayReceipt[1]);
            objPayReceiptBALClass.objPayReceiptObject.YearSequenceNo = PayReceipt[2];
            objPayReceiptBALClass.objPayReceiptObject.PayReceiptNo = PayReceipt[0];
            objPayReceiptBALClass.objPayReceiptObject.PayMethod = "101";
            objPayReceiptBALClass.objPayReceiptObject.PayTo = 0;
            objPayReceiptBALClass.objPayReceiptObject.PayInvoiceID = 0;
            objPayReceiptBALClass.objPayReceiptObject.PayInvoiceNo = 0;
            objPayReceiptBALClass.objPayReceiptObject.PayBalance = 0;
            objPayReceiptBALClass.objPayReceiptObject.PayPaymentDate = DateTime.Now;
            objPayReceiptBALClass.objPayReceiptObject.PayDate = DateTime.Now;
            objPayReceiptBALClass.objPayReceiptObject.PayCreatedBy = GeneralFunction.UserId;
            objPayReceiptBALClass.objPayReceiptObject.PayModifiedBy = GeneralFunction.UserId;
            objPayReceiptBALClass.objPayReceiptObject.PayStatus = 1;
            objPayReceiptBALClass.objPayReceiptObject.PayDiscription = string.Empty;
            objPayReceiptBALClass.objPayReceiptObject.PayReason = string.Empty;
            objPayReceiptBALClass.objPayReceiptObject.BankID = 0;
            objPayReceiptBALClass.objPayReceiptObject.BranchID = 0;
            objPayReceiptBALClass.objPayReceiptObject.PayFlag = Convert.ToInt16(PayReceiptFor.Receipt);
            objPayReceiptBALClass.objPayReceiptObject.PayDiscriptionArabic = string.Empty;
            objPayReceiptBALClass.objPayReceiptObject.PayRemarks = string.Empty;

            objPayReceiptBALClass.SavePayReceiptBal();
            GetCurrentYearAndMaxID();
            Dictionary<string, long> dicofyear = new Dictionary<string, long>();
            dicofyear.Add("Year", PayReceipt[1]);
            dicofyear.Add("YearSequenceNo", PayReceipt[2]);
            CheckCurrentYear(dicofyear);

        }




        #endregion


    }
}
