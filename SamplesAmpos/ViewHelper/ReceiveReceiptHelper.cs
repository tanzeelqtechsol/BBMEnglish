using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using HSB_ObjectHelper;
using CommonHelper;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace BumedianBM.ViewHelper
{
    public class ReceiveReceiptHelper
    {
        ReceiveReceiptBAL objReceiveReceiptBALClass;
        public List<ReceiveReceiptObject> ListReceiptRecord;
        public List<ReceiveReceiptObject> ListFromBalanceSheet = new List<ReceiveReceiptObject>();
        List<long> ReceiptNo = new List<long>();
        internal int CurrentYear;
        public bool balancesheetopen = false;
        public static bool isReceivedReceipt = false;

        public ReceiveReceiptHelper()
        {
            objReceiveReceiptBALClass = new ReceiveReceiptBAL();
        }
        public ReceiveReceiptBAL objReceiveReceiptBAL
        {
            get { return objReceiveReceiptBALClass; }
            set { objReceiveReceiptBALClass = value; }
        }

        #region Methods

        public bool SaveReceiveReceiptHelper()
        {
            //bool value = objReceiveReceiptBALClass.SaveReceiveReceiptBal();
            //return value;
            return objReceiveReceiptBALClass.SaveReceiveReceiptBal();
        }
        public bool Insert_BankTransactionDetailsHelper(bool IsEmptyRecord)
        {
            //bool value = objReceiveReceiptBALClass.SaveReceiveReceiptBal();
            //return value;
            if (IsEmptyRecord)
            {
                objReceiveReceiptBALClass.GetBankDepositMaxID();
            }
            return objReceiveReceiptBALClass.Insert_BankTransactionDetailsBAL(IsEmptyRecord);
        }
        

        public bool UpdateSaleBalanceHelper()
        {
            //bool value = objReceiveReceiptBALClass.UpdateSaleBalanceBal();
            //return value;
            return objReceiveReceiptBALClass.UpdateSaleBalanceBal();
        }

        public bool UpdateSalePaymentTypeHelper()
        {
            //bool value = objReceiveReceiptBALClass.UpdateSaleBalanceBal();
            //return value;
            return objReceiveReceiptBALClass.UpdateSalePaymentTypeBal();
        }
        public bool UpdateSalePaymentChargesHelper()
        {
            //bool value = objReceiveReceiptBALClass.UpdateSaleBalanceBal();
            //return value;
            return objReceiveReceiptBALClass.UpdateSalePaymentChargesBal();
        }

        public int GetSaleType(string tagValue)
        {
            int id;
            switch (tagValue)
            {
                case "BalanceSheet":
                    id = Convert.ToInt16(ReceiveReceiptFor.BalanceSheet);
                    break;
                case "Receivable":
                    id = Convert.ToInt16(ReceiveReceiptFor.Receivable);
                    break;
                case "POS":
                    id = Convert.ToInt16(ReceiveReceiptFor.POS);
                    break;
                case "PurchaseReturn":
                    id = Convert.ToInt16(ReceiveReceiptFor.PurchaseReturn);
                    break;
                case "SaleInvoice":
                    id = Convert.ToInt16(ReceiveReceiptFor.SaleInvoice);
                    break;

                default:
                    // id = Convert.ToInt16(ReceiveReceiptFor.ReceiveReceipt);Commented on 22April 2014 .wrong updation of receipt for id
                    id = Convert.ToInt16(ReceiveReceiptFor.Receivable);
                    break;

            }
            return id;
        }

        public bool GetPrevNextRecordHelper()
        {
            //bool value = objReceiveReceiptBALClass.GetPrevNextRecordBal(out ListReceiptRecord);
            //return value;
            return objReceiveReceiptBALClass.GetPrevNextRecordBal(out ListReceiptRecord);
        }


        public bool GetSearchedRecordHelper()
        {
            //bool value = objReceiveReceiptBALClass.GetSearchedRecordBal(out ListReceiptRecord);
            //return value;
            return objReceiveReceiptBALClass.GetSearchedRecordBal(out ListReceiptRecord);
        }

        public bool DeleteReceiptDetailsHelper()
        {
            //bool value = objReceiveReceiptBALClass.DeleteReceiptDetailsBal();
            //return value;
            return objReceiveReceiptBALClass.DeleteReceiptDetailsBal();
        }

        public object GetCurrentYearHelper()
        {
            return objReceiveReceiptBALClass.GetCurrentYearBal();

        }

        #region CheckCurrentYear
        public void CheckCurrentYear(Dictionary<string, long> lstRecords)
        {

            if (CurrentYear == lstRecords["Year"])
            {
                objReceiveReceiptBALClass.objReceiveReceiptObject.CurrentYearStr = lstRecords["YearSequenceNo"].ToString();
            }
            else
            {
                objReceiveReceiptBALClass.objReceiveReceiptObject.CurrentYearStr = lstRecords["Year"].ToString() + "-" + lstRecords["YearSequenceNo"].ToString();
            }

        }
        #endregion

        #region GetCurrentYear
        public void GetCurrentYear_MaxID()
        {
            CurrentYear = Convert.ToInt32(objReceiveReceiptBALClass.GetCurrentYearBal());
            // objReceiveReceiptBALClass.GetAllReceiptIdBal(out ListReceiptRecord);//Commented on 24-Jan-2014

        }
        #endregion

        public void GetAllReceiptIdHelper()
        {
            objReceiveReceiptBALClass.GetAllReceiptIdBal(out ListReceiptRecord);//Added on 24-Jan-2014
        }

        #endregion

        #region Validation

        public Boolean ValidateReceipt()
        {

            if (objReceiveReceiptBAL.objReceiveReceiptObject.ReceivedFromName == string.Empty)
            {
                // Cmb_ReceivedFrom.Focus();
                GeneralFunction.Information("EmptyReceivedFrom", "ReceiveReceipt");
                //Control ctrl = new Control("Cmb_ReceivedFrom");
                //Receive_Receipt.ChangeProperties(ctrl);
                objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString = "Cmb_ReceivedFrom";
                return false;
            }
            else if (objReceiveReceiptBAL.objReceiveReceiptObject.discription == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", "ReceiveReceipt");
                //Control ctrl = new Control("MTxt_Discription");
                //Receive_Receipt.ChangeProperties(ctrl);
                // Txt_Discription.Focus();
                objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString = "MTxt_Discription";
                return false;
            }
            else if (objReceiveReceiptBAL.objReceiveReceiptObject.netvalue.ToString() == string.Empty || objReceiveReceiptBAL.objReceiveReceiptObject.netvalue.ToString() == "0.000")
            {
                GeneralFunction.Information("GreaterthanZeroAmount", "ReceiveReceipt");
                //Control ctrl = new Control("MTxt_Value");
                //Receive_Receipt.ChangeProperties(ctrl);
                objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString = "MTxt_Value";
                //  MTxt_Value.Focus();
                return false;
            }
            else if (objReceiveReceiptBAL.objReceiveReceiptObject.CheckChecked && objReceiveReceiptBAL.objReceiveReceiptObject.bank == 0)
            {
                GeneralFunction.Information("EmptyBank", "ReceiveReceipt");
                //Control ctrl = new Control("cmb_bank");
                //Receive_Receipt.ChangeProperties(ctrl);
                objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString = "cmb_bank";
                // Cmb_Bank.Focus();
                return false;
            }
            else if (objReceiveReceiptBAL.objReceiveReceiptObject.CheckChecked && objReceiveReceiptBAL.objReceiveReceiptObject.branch == 0)
            {
                GeneralFunction.Information("EmptyBranch", "ReceiveReceipt");
                //Control ctrl = new Control("cmb_branch");
                //Receive_Receipt.ChangeProperties(ctrl);
                objReceiveReceiptBAL.objReceiveReceiptObject.ValidationString = "cmb_branch";

                return false;
            }
            else
                return true;
        }



        #endregion

        public void BindReceiptMaxID(out string Status)
        {
            List<ReceiveReceiptObject> ListReceiveReceipt;
            try
            {
                ListReceiveReceipt = new List<ReceiveReceiptObject>();
                Status = string.Empty;
                bool checkstatus;
                int MaxID = Convert.ToInt32(objReceiveReceiptBALClass.GetReceiptMaxId());

                if (MaxID != 0)
                {
                    if (balancesheetopen == false)
                    {
                        objReceiveReceiptBALClass.objReceiveReceiptObject.receiptid = Convert.ToInt32(MaxID);
                    }
                    checkstatus = objReceiveReceiptBALClass.GetPrevNextRecordBal(out ListReceiveReceipt);
                    if (ListReceiveReceipt.Count > 0)
                    {
                        Status = AssignFromListToObject(ListReceiveReceipt);
                        ListFromBalanceSheet = ListReceiveReceipt.ToList();
                        GetCurrentYear_MaxID();
                        Dictionary<string, long> dicofyear = new Dictionary<string, long>();
                        dicofyear.Add("Year", ListReceiveReceipt[0].Year);
                        dicofyear.Add("YearSequenceNo", ListReceiveReceipt[0].YearSequenceNo);
                        CheckCurrentYear(dicofyear);
                        // CheckCurrentYear(ListReceiveReceipt);
                    }
                }
                else
                {
                    CreateEmptyRecord();
                    Status = GeneralFunction.ChangeLanguageforCustomMsg("New");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListReceiveReceipt = null;
            }
        }


        public object GetBankDeposit_MaxID()
        {
            return objReceiveReceiptBALClass.GetBankDeposit_MaxID();
        }
        public void CreateEmptyRecord()
        {

            ReceiptNo = objReceiveReceiptBALClass.InsertReceiptID();

            objReceiveReceiptBALClass.objReceiveReceiptObject.Year = Convert.ToInt32(ReceiptNo[1]);
            objReceiveReceiptBALClass.objReceiveReceiptObject.YearSequenceNo = Convert.ToInt64(ReceiptNo[2]);
            objReceiveReceiptBALClass.objReceiveReceiptObject.receiptid = Convert.ToInt32(ReceiptNo[0]);
            objReceiveReceiptBALClass.objReceiveReceiptObject.paymethodid = 101;
            objReceiveReceiptBALClass.objReceiveReceiptObject.saleid = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.saleinv = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.balance = 0;

            objReceiveReceiptBALClass.objReceiveReceiptObject.receiptdate = DateTime.Now;
            objReceiveReceiptBALClass.objReceiveReceiptObject.UserId = GeneralFunction.UserId;


            objReceiveReceiptBALClass.objReceiveReceiptObject.Status = 1;
            objReceiveReceiptBALClass.objReceiveReceiptObject.receivedfrom = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.bank = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.branch = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.discription = string.Empty;
            objReceiveReceiptBALClass.objReceiveReceiptObject.note = string.Empty;
            objReceiveReceiptBALClass.objReceiveReceiptObject.saletype = Convert.ToInt32(ReceiveReceiptFor.Receivable);
            objReceiveReceiptBALClass.objReceiveReceiptObject.discriptionarabic = string.Empty;
            objReceiveReceiptBALClass.objReceiveReceiptObject.grossamount = 0;
            objReceiveReceiptBALClass.objReceiveReceiptObject.netvalue = 0;

            objReceiveReceiptBALClass.SaveReceiveReceiptBal();
            GetCurrentYear_MaxID();
            Dictionary<string, long> dicofyear = new Dictionary<string, long>();
            dicofyear.Add("Year", ReceiptNo[1]);
            dicofyear.Add("YearSequenceNo", ReceiptNo[2]);
            CheckCurrentYear(dicofyear);
        }


        private string AssignFromListToObject(List<ReceiveReceiptObject> List)
        {
            objReceiveReceiptBALClass.objReceiveReceiptObject.Year = List[0].Year;
            objReceiveReceiptBALClass.objReceiveReceiptObject.YearSequenceNo = List[0].YearSequenceNo;
            objReceiveReceiptBALClass.objReceiveReceiptObject.AgentID = List[0].AgentID;
            objReceiveReceiptBALClass.objReceiveReceiptObject.discription = List[0].discription;
            objReceiveReceiptBALClass.objReceiveReceiptObject.note = List[0].note;
            objReceiveReceiptBALClass.objReceiveReceiptObject.balance = List[0].balance;
            objReceiveReceiptBALClass.objReceiveReceiptObject.paymethodid = List[0].paymethodid;
            objReceiveReceiptBALClass.objReceiveReceiptObject.bank = List[0].bank;
            objReceiveReceiptBALClass.objReceiveReceiptObject.branch = List[0].branch;
            objReceiveReceiptBALClass.objReceiveReceiptObject.Status = List[0].Status;
            if (objReceiveReceiptBALClass.objReceiveReceiptObject.Status == 1 && !string.IsNullOrEmpty(objReceiveReceiptBALClass.objReceiveReceiptObject.discription))
                return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
            else if (objReceiveReceiptBALClass.objReceiveReceiptObject.Status == 0)
                return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
            else
                return GeneralFunction.ChangeLanguageforCustomMsg("New");


        }

        public int GetMaxReceiptID()
        {
            int MaxID = Convert.ToInt32(objReceiveReceiptBALClass.GetReceiptMaxId());
            return MaxID;
        }


        internal void PrintReceipt()
        {
            CurrencyConverter cls = new CurrencyConverter();
            ReportsView frmView = new ReportsView();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("ReceiveReceipt");
            Rpt_InvoiceReceipt summery = new Rpt_InvoiceReceipt();
            //summery.Refresh();
            frmView.HTable.Clear();
            string strInvYear = string.Empty;
            string NewYearNo = objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr;
            isReceivedReceipt = true;
            //string[] str;
            //if (NewYearNo != string.Empty)
            //{
            //    str = NewYearNo.Split('-');
            //}
            //if (str.Length > 1)
            //{
            //    strInvYear = str[0] + "-";
            //}

            //   frmView.Report_Table = dt;
            frmView.HTable.Add("ReceiptName", frmView.Text);
            //  frmView.HTable.Add("ReceiptNo", objReceiveReceiptBAL.objReceiveReceiptObject.CurrentYearStr);passing present invoice receipt number 
            frmView.HTable.Add("ReceiptNo", objReceiveReceiptBAL.objReceiveReceiptObject.receiptid);
            frmView.HTable.Add("ReceivedFrom", objReceiveReceiptBAL.objReceiveReceiptObject.AgentName);
            frmView.HTable.Add("Amount", objReceiveReceiptBAL.objReceiveReceiptObject.grossamount);
            frmView.HTable.Add("Description", objReceiveReceiptBAL.objReceiveReceiptObject.discription);
            frmView.HTable.Add("InvoiceNo", objReceiveReceiptBAL.objReceiveReceiptObject.saleid.ToString());
            frmView.HTable.Add("AmountLetter", cls.Convert(objReceiveReceiptBAL.objReceiveReceiptObject.grossamount.ToString("0.000")));
            frmView.HTable.Add("Note", objReceiveReceiptBAL.objReceiveReceiptObject.note);
            //frmView.HTable.Add("Remaining", objReceiveReceiptBAL.objReceiveReceiptObject.balance < 0  ? objReceiveReceiptBAL.objReceiveReceiptObject.balance : Convert.ToDecimal(0.00));
            frmView.HTable.Add("Remaining", objReceiveReceiptBAL.objReceiveReceiptObject.balance);// < 0 ? objReceiveReceiptBAL.objReceiveReceiptObject.balance : Convert.ToDecimal(0.00));

            frmView.RptDoc = summery;
            ReportDocument rpt = summery;
            Tables tbl = rpt.Database.Tables;
            frmView.Repnum = tbl;
            frmView.IsItemNo = false;
            frmView.IsReportFooter = false;

            frmView.LoadEvent();
            if (objReceiveReceiptBAL.objReceiveReceiptObject.PrintPreviewChecked)
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
}
