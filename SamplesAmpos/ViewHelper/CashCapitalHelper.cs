using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using ObjectHelper;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Data;
using System.Windows.Forms;


namespace BumedianBM.ViewHelper
{
    class CashCapitalHelper
    {
        #region Declaration
        internal Int16 CashType;
        private long MaxReceiptNo;
        private long MinReceiptNo;
        internal int CurrentYear;
        internal enum CashTypes
        {
            Cash = 1,
            Bank
        }
        internal BALHelper.CashCapitalBALClass objCashCapitalBALClass = new BALHelper.CashCapitalBALClass();
        List<long> ReceiptNo = new List<long>();
        #endregion

        #region Constructor
        internal CashCapitalHelper()
        {
            New();

        }
        #endregion
        internal void GetMinMaxID()
        {
            List<ObjectHelper.BankObjectClass> lstMaxRecptIDYr = new List<ObjectHelper.BankObjectClass>();
            try
            {
                lstMaxRecptIDYr = objCashCapitalBALClass.LoadMaxRecptIDWithYr();
                MaxReceiptNo = lstMaxRecptIDYr[0].ReceiptNo;

                MinReceiptNo = objCashCapitalBALClass.LoadMinimumReceiptID();
                CurrentYear = lstMaxRecptIDYr[0].Year;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstMaxRecptIDYr = null;
            }

        }

        #region EventMethods

        internal void New()
        { objCashCapitalBALClass.objBankObjectClass = new ObjectHelper.BankObjectClass(Convert.ToInt32(TransactionType.Cash), Convert.ToInt16(Table.CashCapital)); }

        internal bool SaveCashDetails()
        {
            List<ObjectHelper.BankObjectClass> lstNewYearNo = new List<ObjectHelper.BankObjectClass>();
            try
            {
                if (Validate())
                {
                    objCashCapitalBALClass.objBankObjectClass.CreatedBy = GeneralFunction.UserId;
                    objCashCapitalBALClass.objBankObjectClass.CreatedDate = DateTime.Now;
                    if (CashType == Convert.ToInt32(CashTypes.Bank))
                    { objCashCapitalBALClass.objBankObjectClass.DepositDoneBy = CashTypes.Bank.ToString(); }
                    else
                    { objCashCapitalBALClass.objBankObjectClass.DepositDoneBy = CashTypes.Cash.ToString(); }
                    objCashCapitalBALClass.objBankObjectClass.Status = 1;
                    if (objCashCapitalBALClass.SaveBankCash())
                    {
                        New();
                        CreateEmptyRecord();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objCashCapitalBALClass.objBankObjectClass.ReceiptNo.ToString(), "Cash Capital", "Save cash capital details", Convert.ToInt32(InvoiceAction.No));
                        GeneralFunction.Information("SaveCashCapital", ActionType.Save.ToString());
                        return true;
                    }
                    else
                    {
                        GeneralFunction.Information("FailedSaveCashCapital", ActionType.Save.ToString());
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstNewYearNo = null;
            }
        }

        public bool Delete()
        {
            if (Validate())
            {
                objCashCapitalBALClass.objBankObjectClass.ModifiedBy = GeneralFunction.UserId;
                if (objCashCapitalBALClass.objBankObjectClass.BankDetailID == 0)
                { return false; }
                else
                {
                    if (objCashCapitalBALClass.DeleteBankCash())
                    {
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objCashCapitalBALClass.objBankObjectClass.ReceiptNo.ToString(), "Cash Capital Details", "Delete cash capital details", Convert.ToInt32(InvoiceAction.No));
                        CommonHelper.GeneralFunction.Information("DeleteCashCapital", ActionType.Delete.ToString());
                        // New();
                        return true;
                    }
                    else
                    { GeneralFunction.Information("FailedDeleteCashCapital", "Cash Capital"); }
                }
            }
            return false;
        }

        public bool RightNavigation(out string LabelStatus)
        {
            LabelStatus = string.Empty;
            long receiptno = 0;
            receiptno = objCashCapitalBALClass.objBankObjectClass.ReceiptNo + 1;
            if (MaxReceiptNo > receiptno)
            {
                objCashCapitalBALClass.objBankObjectClass.ReceiptNo = receiptno;
                LabelStatus = GettingRecordForReceiptID();
                if (LabelStatus != null)
                {
                    return true;
                }
            }

            else
            {
                objCashCapitalBALClass.objBankObjectClass.ReceiptNo = MaxReceiptNo;
                LabelStatus = GettingRecordForReceiptID();
                if (LabelStatus != null)
                {
                    return true;
                }

            }

            return false;
        }



        public bool LeftNavigation(out string labelStatus)
        {
            labelStatus = string.Empty;
            long receiptno = 0;

            receiptno = objCashCapitalBALClass.objBankObjectClass.ReceiptNo - 1;
            if (MinReceiptNo > receiptno)
            {
                objCashCapitalBALClass.objBankObjectClass.ReceiptNo = MinReceiptNo;
                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;
            }
            else
            {
                objCashCapitalBALClass.objBankObjectClass.ReceiptNo = receiptno;
                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;
            }

            return false;


        }
        #endregion

        #region Methods

        public string GettingRecordForReceiptID()
        {
            List<ObjectHelper.BankObjectClass> lstBankDetail = new List<ObjectHelper.BankObjectClass>();
            try
            {
                if (objCashCapitalBALClass.GetRecordForReceiptID(out lstBankDetail))
                    return AssignFromList(lstBankDetail);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstBankDetail = null;
            }
        }

        public string AssignFromList(List<ObjectHelper.BankObjectClass> lstBankList)
        {
            if (lstBankList.Count > 0)
            {
                objCashCapitalBALClass.objBankObjectClass.ReceiptNo = lstBankList[0].ReceiptNo;
                objCashCapitalBALClass.objBankObjectClass.BankDetailID = lstBankList[0].BankDetailID;
                objCashCapitalBALClass.objBankObjectClass.BankNameID = lstBankList[0].BankNameID;
                objCashCapitalBALClass.objBankObjectClass.BranchNameID = lstBankList[0].BranchNameID;
                objCashCapitalBALClass.objBankObjectClass.Amount = lstBankList[0].Amount;
                objCashCapitalBALClass.objBankObjectClass.ProcessDate = lstBankList[0].ProcessDate;
                objCashCapitalBALClass.objBankObjectClass.Description = lstBankList[0].Description;
                objCashCapitalBALClass.objBankObjectClass.DepositDoneBy = lstBankList[0].DepositDoneBy;
                objCashCapitalBALClass.objBankObjectClass.Status = lstBankList[0].Status;
                objCashCapitalBALClass.objBankObjectClass.Year = lstBankList[0].Year;
                objCashCapitalBALClass.objBankObjectClass.YearSequenceNo = lstBankList[0].YearSequenceNo;
                objCashCapitalBALClass.objBankObjectClass.Reason = lstBankList[0].Reason;
                if (objCashCapitalBALClass.objBankObjectClass.Status == 1 && !string.IsNullOrEmpty(objCashCapitalBALClass.objBankObjectClass.Description))
                    return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                else if (objCashCapitalBALClass.objBankObjectClass.Status == 0)
                    return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                else
                    return GeneralFunction.ChangeLanguageforCustomMsg("New");
            }
            return null;
        }

        private bool Validate()
        {
            if (objCashCapitalBALClass.objBankObjectClass.Description.Length == 0)
            {
                GeneralFunction.Information("EmptyDescription", ActionType.Save.ToString());
                objCashCapitalBALClass.objBankObjectClass.ValidationcontrolName = "txtDescription";

                return false;
            }
            if (objCashCapitalBALClass.objBankObjectClass.Amount == 0)
            {
                GeneralFunction.Information("AmountShouldnotbeEmpty", ActionType.Save.ToString());
                objCashCapitalBALClass.objBankObjectClass.ValidationcontrolName = "txtAmount";

                return false;
            }
            if (!(CashType == Convert.ToInt32(CashTypes.Bank) || CashType == Convert.ToInt32(CashTypes.Cash)))
            {
                GeneralFunction.Information("Select Mode Of Payment(Bank/Cash)", ActionType.Save.ToString());
                //Control ctrl = new Control("txtAmount");
                //frmCashCapital.ChangeProperties(ctrl);
                return false;
            }
            if (CashType == Convert.ToInt32(CashTypes.Bank))
            {
                if (objCashCapitalBALClass.objBankObjectClass.BankNameID == 0)
                {
                    GeneralFunction.Information("Bank Name and Branch Name Mandatary for Bank Payment", ActionType.Save.ToString());
                    objCashCapitalBALClass.objBankObjectClass.ValidationcontrolName = "cmbBank";
                    //frmCashCapital.ChangeProperties(ctrl);
                    return false;
                }
                if (objCashCapitalBALClass.objBankObjectClass.BranchNameID == 0)
                {
                    GeneralFunction.Information("Bank Name and Branch Name Mandatary for Bank Payment", ActionType.Save.ToString());
                    objCashCapitalBALClass.objBankObjectClass.ValidationcontrolName = "cmbBranch";
                    return false;
                }
            }
            return true;
        }

        public bool KeyPress(out string labelStatus)
        {
            labelStatus = GetRecordForNewYrNo();
            if (labelStatus != null)
                return true;
            else
                return false;
        }

        public string GetRecordForNewYrNo()
        {
            List<ObjectHelper.BankObjectClass> lstBankDetail = new List<ObjectHelper.BankObjectClass>();
            try
            {
                if (objCashCapitalBALClass.GetReceiptWithYear(out lstBankDetail))
                    return AssignFromList(lstBankDetail);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstBankDetail = null;
            }
        }
        #endregion


        #region LoadEmptyRecord

        internal string BindMaxIdToControls(out string Labelstatus)
        {
            Labelstatus = string.Empty;
            List<BankObjectClass> ListObj_CashCapital = new List<BankObjectClass>();
            List<BankObjectClass> CashCapitalRecord;
            try
            {
                ListObj_CashCapital = objCashCapitalBALClass.GetMaxIdRecord();
                int CheckMaxId = Convert.ToInt32(ListObj_CashCapital[0].ReceiptNo);
                if (CheckMaxId != 0)
                {
                    objCashCapitalBALClass.objBankObjectClass.ReceiptNo = ListObj_CashCapital[0].ReceiptNo;
                    CashCapitalRecord = objCashCapitalBALClass.GetSCashCapitalRecord();
                    Labelstatus = AssignFromList(CashCapitalRecord);
                    GetMinMaxID();
                    return Labelstatus;
                }
                else
                {
                    CreateEmptyRecord();
                    Labelstatus = GeneralFunction.ChangeLanguageforCustomMsg("New");
                    return Labelstatus;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListObj_CashCapital = null;
                CashCapitalRecord = null;
            }

        }


        internal void CreateEmptyRecord()
        {

            ReceiptNo = objCashCapitalBALClass.GetCashCapitalMaxID();
            objCashCapitalBALClass.objBankObjectClass.ReceiptNo = ReceiptNo[0];
            objCashCapitalBALClass.objBankObjectClass.Year = Convert.ToInt32(ReceiptNo[1]);
            objCashCapitalBALClass.objBankObjectClass.YearSequenceNo = ReceiptNo[2];
            objCashCapitalBALClass.objBankObjectClass.Description = string.Empty;
            objCashCapitalBALClass.objBankObjectClass.DepositDoneBy = "Cash";
            objCashCapitalBALClass.objBankObjectClass.Reason = string.Empty;
            objCashCapitalBALClass.objBankObjectClass.Amount = 0;
            objCashCapitalBALClass.objBankObjectClass.TransactionFlag = 3;
            objCashCapitalBALClass.objBankObjectClass.ProcessDate = DateTime.Now;
            objCashCapitalBALClass.objBankObjectClass.TransactionType = 1;
            objCashCapitalBALClass.objBankObjectClass.CreatedBy = GeneralFunction.UserId;
            objCashCapitalBALClass.objBankObjectClass.ModifiedBy = GeneralFunction.UserId;
            objCashCapitalBALClass.objBankObjectClass.Status = 1;
            objCashCapitalBALClass.SaveBankCash();
            GetMinMaxID();

        }
        public void PrintOptionDetails()
        {
            Rpt_CashCapital cashcapital = new Rpt_CashCapital();
            ReportsView reportview = new ReportsView();
            try
            {
                reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("CashCapitalDetails");
                DataTable DT = objCashCapitalBALClass.GetPrintCashCapitalDetails();
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        DT.Rows[i]["ProcessDate"] = Convert.ToDateTime(DT.Rows[i]["ProcessDate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                    }
                    reportview.Report_Table = DT;
                    reportview.RptDoc = cashcapital;
                    reportview.LoadEvent();
                    reportview.ShowDialog();
                }
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), objCashCapitalBALClass.objBankObjectClass.ReceiptNo.ToString(), "CASH CAPITAL", "Print cash capital details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cashcapital = null;
                reportview = null;
            }
        }




    }






        #endregion
}

