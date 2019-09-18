using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.Interface;
using System.Data;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using BumedianBM.CrystalReports;
using BumedianBM.ArabicView;
using System.Windows.Forms;
//mODIFIED BY:G.SARADHAA(27/11/2013)
//des:Included List and Dic
namespace BumedianBM.ViewHelper
{

    public class BankWithdrawHelperClass
    {
        #region Declaration
        public BankWithdrawBALClass objBankWithdrawBALClass = new BankWithdrawBALClass();
        internal long MaxBankDetailID;
        internal int MinBankDetailID;
        internal int CurrentYear;
        List<long> ReceiptNo = new List<long>();
        #endregion

        #region Constructor
        internal BankWithdrawHelperClass()
        {
            New();

        }
        #endregion
        private void GetMaxMinID()
        {
            List<ObjectHelper.BankObjectClass> lstMaxRecptIDYr = new List<ObjectHelper.BankObjectClass>();
            lstMaxRecptIDYr = objBankWithdrawBALClass.LoadMaxRecptIDWithYr();
            MaxBankDetailID = lstMaxRecptIDYr[0].ReceiptNo;
            MinBankDetailID = objBankWithdrawBALClass.LoadMinimumReceiptID();
            CurrentYear = lstMaxRecptIDYr[0].Year;
        }

        #region Events
        public bool Save()
        {
            if (!Validation())
            {
                if (!CheckTheBankBalance())
                {
                    List<ObjectHelper.BankObjectClass> lstNewYearNo = new List<BankObjectClass>();
                    objBankWithdrawBALClass.objBankObjectClass.Status = 1;
                    objBankWithdrawBALClass.objBankObjectClass.Reason = "";
                    //   objBankWithdrawBALClass.objBankObjectClass.ReasonId = 0;
                    if (objBankWithdrawBALClass.SaveBankDraw())
                    {
                        New();
                        // MaxBankDetailID = lstNewYearNo[0].ReceiptNo;
                        CommonHelper.GeneralFunction.Information("SaveBankWidthDraw", ActionType.Save.ToString());
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objBankWithdrawBALClass.objBankObjectClass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "Save bank withdraw details", Convert.ToInt32(InvoiceAction.No));
                        return true;
                    }
                    else
                    { CommonHelper.GeneralFunction.Information("FailedSaveBankWidthDraw", ActionType.Save.ToString()); }
                }
            }
            return false;
        }

        public void New()
        { objBankWithdrawBALClass.objBankObjectClass = new BankObjectClass(Convert.ToInt32(TransactionType.WithDraw), Convert.ToInt16(Table.BankWithdraw)); }

        public bool Delete()
        {
            if (!Validation())
            {
                objBankWithdrawBALClass.objBankObjectClass.ModifiedBy = GeneralFunction.UserId;
                if (objBankWithdrawBALClass.objBankObjectClass.BankDetailID == 0)
                { return false; }
                else
                {
                    if (objBankWithdrawBALClass.DeleteDrawDetails())
                    {
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objBankWithdrawBALClass.objBankObjectClass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "Delete bank withdraw details", Convert.ToInt32(InvoiceAction.No));
                        GeneralFunction.Information("DeleteBankWidthDraw", ActionType.Delete.ToString());
                        //New();
                        return true;
                    }
                    else
                    {
                        GeneralFunction.Information("FailedDeleteBankWidthDraw", ActionType.Delete.ToString());
                    }
                }
            }
            return false;
        }

        public bool RightNavigation(out string LabelStatus)
        {
            LabelStatus = string.Empty;
            long receiptno = 0;

            receiptno = objBankWithdrawBALClass.objBankObjectClass.ReceiptNo + 1;
            if (MaxBankDetailID > receiptno)
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = receiptno;


                LabelStatus = GettingRecordForReceiptID();
                if (LabelStatus != null)
                    return true;
            }
            else
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = MaxBankDetailID;
                LabelStatus = GettingRecordForReceiptID();
                if (LabelStatus != null)
                    return true;


            }
            return false;
        }

        public bool LeftNavigation(out string labelStatus)
        {
            labelStatus = string.Empty;
            long receiptno = 0;

            receiptno = Convert.ToInt32(objBankWithdrawBALClass.objBankObjectClass.ReceiptNo - 1);
            if (MinBankDetailID > receiptno)
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = MinBankDetailID;
                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;

            }

            else
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = receiptno;
                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;

            }

            return false;
        }
        #endregion

        #region Methods
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
            List<BankObjectClass> lstBankDetail = new List<BankObjectClass>();
            if (objBankWithdrawBALClass.GetReceiptWithYear(out lstBankDetail))
                return AssignFromList(lstBankDetail);
            else
                return null;
        }
        public string GettingRecordForReceiptID()
        {
            List<BankObjectClass> lstBankDetail = new List<BankObjectClass>();
            if (objBankWithdrawBALClass.GetRecordForReceiptID(out lstBankDetail))
                return AssignFromList(lstBankDetail);
            else
                return null;
        }
        public string AssignFromList(List<BankObjectClass> lstBankList)
        {
            if (lstBankList.Count > 0)
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = lstBankList[0].ReceiptNo;
                objBankWithdrawBALClass.objBankObjectClass.BankDetailID = lstBankList[0].BankDetailID;
                objBankWithdrawBALClass.objBankObjectClass.BankNameID = lstBankList[0].BankNameID;
                objBankWithdrawBALClass.objBankObjectClass.BranchNameID = lstBankList[0].BranchNameID;
                objBankWithdrawBALClass.objBankObjectClass.Amount = lstBankList[0].Amount;
                objBankWithdrawBALClass.objBankObjectClass.ProcessDate = lstBankList[0].ProcessDate;
                objBankWithdrawBALClass.objBankObjectClass.Description = lstBankList[0].Description;
                objBankWithdrawBALClass.objBankObjectClass.DepositDoneBy = lstBankList[0].DepositDoneBy;
                objBankWithdrawBALClass.objBankObjectClass.Status = lstBankList[0].Status;
                objBankWithdrawBALClass.objBankObjectClass.Year = lstBankList[0].Year;
                objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo = lstBankList[0].YearSequenceNo;
                if (objBankWithdrawBALClass.objBankObjectClass.Status == 1 && !String.IsNullOrEmpty(objBankWithdrawBALClass.objBankObjectClass.Description))
                    return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                else if (objBankWithdrawBALClass.objBankObjectClass.Status == 0)
                    return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                else
                    return GeneralFunction.ChangeLanguageforCustomMsg("New");
            }
            return null;
        }
        public void LoadMaxMinNumber()
        {
            List<int> lstMinMaxValue = new List<int>();
            lstMinMaxValue = objBankWithdrawBALClass.GetDrawMaxMinReceiptNo();
            if (lstMinMaxValue.Count > 0)
            {
                objBankWithdrawBALClass.objBankObjectClass.MinId = Convert.ToInt32(lstMinMaxValue[0]);
                objBankWithdrawBALClass.objBankObjectClass.MaxId = Convert.ToInt32(lstMinMaxValue[1]);
            }
        }
        private Boolean Validation()
               
        {
            if (objBankWithdrawBALClass.objBankObjectClass.Description == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", ActionType.Save.ToString());
                objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "txtDescription";

                return true;
            }
            if (objBankWithdrawBALClass.objBankObjectClass.DepositDoneBy == string.Empty)
            {
                GeneralFunction.Information("EmptydepositDoneBy", ActionType.Save.ToString());
                objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "txtWithdrawDoneBy";

                return true;
            }
            if (objBankWithdrawBALClass.objBankObjectClass.BankNameID == 0)
            {
                GeneralFunction.Information("EmptyBank", ActionType.Save.ToString());
                objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "cmbBank";

                return true;
            }
            if (objBankWithdrawBALClass.objBankObjectClass.BranchNameID == 0)
            {
                GeneralFunction.Information("EmptyBranch", ActionType.Save.ToString());
                objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "cmbBranch";

                return true;
            }
            if (objBankWithdrawBALClass.objBankObjectClass.Amount == 0)
            {
                GeneralFunction.Information("EmptyAmount", ActionType.Save.ToString());

                //Control ctrl = new Control("txtAmount");
                objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "txtAmount";
                return true;
            }
           
          
         
            return false;
        }

        public Boolean CheckTheBankBalance()
        {
            
                decimal getAmt = objBankWithdrawBALClass.objBankObjectClass.Amount;
                decimal getBankBal = objBankWithdrawBALClass.objBankObjectClass.BalanceAmount;
                if (getAmt > getBankBal)
                {
                    GeneralFunction.Information("AlertWithdrawAmount", ActionType.Save.ToString());
                    objBankWithdrawBALClass.objBankObjectClass.ValidationcontrolName = "txtAmount";
                    return true;
                }
                else
                { return false; }
           

        }
        public void GetBankBalanceDetails()
        {
            if (objBankWithdrawBALClass.objBankObjectClass.BankNameID != 0)
            {
                List<decimal> lstBankBalance = new List<decimal>();
                lstBankBalance = objBankWithdrawBALClass.GetBankBalanceDetails();
                if (lstBankBalance.Count > 0)
                {
                    decimal depo = Convert.ToDecimal(lstBankBalance[0]);
                    decimal draw = Convert.ToDecimal(lstBankBalance[1]);
                    objBankWithdrawBALClass.objBankObjectClass.BalanceAmount = depo - draw;
                }
            }
        }
        public string BindMaxIdToControls(out string Labelstatus)
        {
            Labelstatus = string.Empty;
            List<BankObjectClass> ListObj_BankWithDraw = new List<BankObjectClass>();
            ListObj_BankWithDraw = objBankWithdrawBALClass.GetMaxIdRecord();
            int CheckMaxId = Convert.ToInt32(ListObj_BankWithDraw[0].ReceiptNo);
            if (CheckMaxId != 0)
            {
                objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = ListObj_BankWithDraw[0].ReceiptNo;
                List<BankObjectClass> BankWithDrawRecord = objBankWithdrawBALClass.GetBankWithdrawRecord();
                Labelstatus = AssignFromList(BankWithDrawRecord);
                GetMaxMinID();
                return Labelstatus;

                //objBankDepositBALClass.objBankobjectclass.ReceiptNo = ReceiptNo[0];

            }
            else
            {
                CreateEmptyRecord();
                return Labelstatus =GeneralFunction.ChangeLanguageforCustomMsg("New");
                //return "New";
            }
        }
        internal void CreateEmptyRecord()
        {
            ReceiptNo = objBankWithdrawBALClass.GetBankWithDrawMaxID();
            objBankWithdrawBALClass.objBankObjectClass.ReceiptNo = ReceiptNo[0];
            // objBankWithdrawBALClass.objBankObjectClass.DepositReceiptNo = ReceiptNo[0];
            objBankWithdrawBALClass.objBankObjectClass.Year = Convert.ToInt32(ReceiptNo[1]);
            objBankWithdrawBALClass.objBankObjectClass.YearSequenceNo = ReceiptNo[2];
            objBankWithdrawBALClass.objBankObjectClass.Description = string.Empty;
            objBankWithdrawBALClass.objBankObjectClass.DepositDoneBy = string.Empty;
            objBankWithdrawBALClass.objBankObjectClass.Reason = string.Empty;
            objBankWithdrawBALClass.objBankObjectClass.Amount = 0;
            objBankWithdrawBALClass.objBankObjectClass.TransactionFlag = 2;
            objBankWithdrawBALClass.objBankObjectClass.ProcessDate = DateTime.Now;
            objBankWithdrawBALClass.objBankObjectClass.TransactionType = 1;
            objBankWithdrawBALClass.objBankObjectClass.CreatedBy = GeneralFunction.UserId;
            objBankWithdrawBALClass.objBankObjectClass.ModifiedBy = GeneralFunction.UserId;
            objBankWithdrawBALClass.objBankObjectClass.Status = 1;
            objBankWithdrawBALClass.SaveBankDraw();
            GetMaxMinID();

        }

        public void PrintOptionDetails()
        {
            Rpt_BankWithdraw bankwithdraw = new Rpt_BankWithdraw();
            ReportsView reportview = new ReportsView();
            reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("BankWithDrawDetails");
            DataTable DT = objBankWithdrawBALClass.GetPrintBankWithDrawDetails();
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    DT.Rows[i]["ProcessDate"] = Convert.ToDateTime(DT.Rows[i]["ProcessDate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                }
                reportview.Report_Table = DT;
                reportview.RptDoc = bankwithdraw;
                reportview.LoadEvent();
                reportview.ShowDialog();
            }
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), objBankWithdrawBALClass.objBankObjectClass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "Print bank withdraw details", Convert.ToInt32(InvoiceAction.No));




        }
        #endregion


     
                  

        }

}