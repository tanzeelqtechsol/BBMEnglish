using System;
using BumedianBM.ArabicView;
using BALHelper;
using ObjectHelper;
using System.Data;
using System.Drawing;
using CommonHelper;
using BumedianBM.Interface;
using System.Collections.Generic;
using BumedianBM.CrystalReports;
using System.Windows.Forms;


namespace BumedianBM.ViewHelper
{
    public class BankDepositHelperClass
    {
        #region Variable Declaration
        public bool moveAccount = false;
        public BankDepositBALClass objBankDepositBALClass = new BankDepositBALClass();
        public int ReceiptMinNo;
        public long ReceiptMaxNo;
        public int ReceiptYear;
        internal decimal Balance1;
        internal decimal Balance2;
        internal int CurrentYear;
        List<long> ReceiptNo = new List<long>();
        #endregion

        #region Constructor
        public BankDepositHelperClass()
        {
            New();

        }
        #endregion
        private void GetMaxMinID()
        {
            List<ObjectHelper.BankObjectClass> lstMaxRecptIDYr = new List<ObjectHelper.BankObjectClass>();
            try
            {
                lstMaxRecptIDYr = objBankDepositBALClass.LoadMaxRecptIDWithYr();
                ReceiptMaxNo = lstMaxRecptIDYr[0].ReceiptNo;
                ReceiptMinNo = objBankDepositBALClass.LoadMinimumReceiptID();
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

        #region Validation
        public Boolean Validation()
        {
            if (objBankDepositBALClass.objBankobjectclass.Description == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "txtDescription";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.DepositDoneBy == string.Empty)
            {
                GeneralFunction.Information("EmptydepositDoneBy", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "txtDepositDoneBy";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.Amount == 0)
            {
                GeneralFunction.Information("EmptyAmount", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "txtAmount";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.Reason == string.Empty)
            {
                GeneralFunction.Information("EmptyReason", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "cmbReason";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.BankNameID == 0)
            {
                GeneralFunction.Information("EmptyBank", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "cmbBank";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.BranchNameID == 0)
            {
                GeneralFunction.Information("EmptyBranch", ActionType.Save.ToString());
                objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "cmbBranch";

                return true;
            }
            else if (objBankDepositBALClass.objBankobjectclass.ReasonId == 2)
            {
                if (objBankDepositBALClass.objBankobjectclass.BankToMoveID == 0)
                {
                    GeneralFunction.Information("Bank to Move" + Constants.REQUIRED, ActionType.Save.ToString());
                    objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "cmb_BanktoMove";

                    return true;
                }
                else if (objBankDepositBALClass.objBankobjectclass.BranchToMoveID == 0)
                {
                    GeneralFunction.Information("Branch to Move" + Constants.REQUIRED, ActionType.Save.ToString());
                    objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "cmb_BranchtoMove";

                    return true;
                }
                else if (Balance2 < Balance1)
                {
                    GeneralFunction.Information("Amount should not be less than BankBalance", ActionType.Save.ToString());
                    objBankDepositBALClass.objBankobjectclass.ValidationcontrolName = "txtAmount";

                    return true;
                }
                moveAccount = true;
            }
            return false;

        }
        #endregion

        #region Event Methods

        public Boolean Save()
        {
            List<BankObjectClass> lstNewYearNo = new List<BankObjectClass>();
            try
            {
                if (!Validation())
                {
                    objBankDepositBALClass.objBankobjectclass.Status = 1;
                    objBankDepositBALClass.objBankobjectclass.CreatedBy = objBankDepositBALClass.objBankobjectclass.ModifiedBy = GeneralFunction.UserId;
                    if (moveAccount)
                    {
                        objBankDepositBALClass.objBankobjectclass.TableID = Convert.ToInt16(Table.BankWithdraw);
                        objBankDepositBALClass.objBankobjectclass.TransactionFlag = 2;
                        BindWithDrawMaxIdToControls();
                        int Bank2move = objBankDepositBALClass.objBankobjectclass.BankToMoveID;
                        int Branch2move = objBankDepositBALClass.objBankobjectclass.BranchToMoveID;
                        int Bankname = objBankDepositBALClass.objBankobjectclass.BankNameID;
                        int Branchname = objBankDepositBALClass.objBankobjectclass.BranchNameID;
                        objBankDepositBALClass.objBankobjectclass.BankNameID = objBankDepositBALClass.objBankobjectclass.BankToMoveID;
                        objBankDepositBALClass.objBankobjectclass.BranchNameID = objBankDepositBALClass.objBankobjectclass.BranchToMoveID;
                        objBankDepositBALClass.objBankobjectclass.BankToMoveID = 0;
                        objBankDepositBALClass.objBankobjectclass.BranchToMoveID = 0;
                        objBankDepositBALClass.objBankobjectclass.Reason = "MOVEACCOUNT";
                        if (objBankDepositBALClass.SaveBankDeposit())
                        {


                            long DrawBankID = objBankDepositBALClass.GetDrawBankDetailID();
                            if (DrawBankID > 0)
                            {
                                objBankDepositBALClass.objBankobjectclass.BankNameID = Bankname;
                                objBankDepositBALClass.objBankobjectclass.BranchNameID = Branchname;
                                objBankDepositBALClass.objBankobjectclass.BankToMoveID = Bank2move;
                                objBankDepositBALClass.objBankobjectclass.BranchToMoveID = Branch2move;
                                objBankDepositBALClass.objBankobjectclass.TransactionFlag = 1;
                                objBankDepositBALClass.objBankobjectclass.TableID = Convert.ToInt16(Table.BankDeposit);
                                objBankDepositBALClass.objBankobjectclass.Reason = "[" + DrawBankID + "]" + objBankDepositBALClass.objBankobjectclass.Reason;
                                objBankDepositBALClass.objBankobjectclass.ReceiptNo = objBankDepositBALClass.objBankobjectclass.DepositReceiptNo;


                            }
                            else
                            {
                                CommonHelper.GeneralFunction.Information("Error in Saving Details ", ActionType.Save.ToString());
                                //New();
                                return false;
                            }
                        }
                        else
                        {
                            CommonHelper.GeneralFunction.Information("Error in Saving Details ", ActionType.Save.ToString());
                            //New();
                            return false;
                        }
                        ///////////////////////////////////////////// moveAccount = false;
                    }
                    if (objBankDepositBALClass.SaveBankDeposit())
                    {

                        New();
                        //ReceiptMaxNo = lstNewYearNo[0].ReceiptNo;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objBankDepositBALClass.objBankobjectclass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "save bank deposit details", Convert.ToInt32(InvoiceAction.No));
                        CommonHelper.GeneralFunction.Information("SaveBankDeposite", ActionType.Save.ToString());
                        return true;
                    }
                    else
                    { CommonHelper.GeneralFunction.Information("FailedSaveBankDeposite", ActionType.Save.ToString()); }
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
        public void New()
        { objBankDepositBALClass.objBankobjectclass = new BankObjectClass(Convert.ToInt32(TransactionType.Deposit), Convert.ToInt16(Table.BankDeposit)); }

        public Boolean Delete()
        {
            objBankDepositBALClass.objBankobjectclass.ModifiedBy = GeneralFunction.UserId;
            bool deleted = false;
            if (objBankDepositBALClass.objBankobjectclass.BankDetailID == 0)
            { return false; }

            if (objBankDepositBALClass.objBankobjectclass.ReasonId == 2)
            { deleted = objBankDepositBALClass.DrawDelete(); }
            else
            { deleted = objBankDepositBALClass.DepositDelete(); }
            if (deleted)
            {
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objBankDepositBALClass.objBankobjectclass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "Delete bank deposit details", Convert.ToInt32(InvoiceAction.No));
                GeneralFunction.Information("DeleteBankDeposite", ActionType.Delete.ToString());
                // New();
                return true;
            }
            else
            { CommonHelper.GeneralFunction.Information("FailedDeleteBankDeposite", ActionType.Delete.ToString()); }

            return false;
        }




        public bool RightNavigation(out string LabelStatus)
        {
            LabelStatus = string.Empty;
            long receiptno = 0;
            receiptno = objBankDepositBALClass.objBankobjectclass.ReceiptNo + 1;
            if (ReceiptMaxNo > receiptno)
            {
                objBankDepositBALClass.objBankobjectclass.ReceiptNo = receiptno;

                LabelStatus = GettingRecordForReceiptID();
                if (LabelStatus != null)
                {
                    return true;
                }

            }
            else
            {
                objBankDepositBALClass.objBankobjectclass.ReceiptNo = ReceiptMaxNo;
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

            receiptno = Convert.ToInt32(objBankDepositBALClass.objBankobjectclass.ReceiptNo - 1);
            if (ReceiptMinNo < receiptno)
            {
                objBankDepositBALClass.objBankobjectclass.ReceiptNo = receiptno;

                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;
            }
            else
            {
                objBankDepositBALClass.objBankobjectclass.ReceiptNo = ReceiptMinNo;

                labelStatus = GettingRecordForReceiptID();
                if (labelStatus != null)
                    return true;
            }

            return false;
        }
        #endregion

        #region Other Methods

        public void LoadMaxMinNumber()
        {
            List<int> lstMinMaxValue = new List<int>();
            try
            {
                lstMinMaxValue = objBankDepositBALClass.GetDepositMaxMinReceiptNo();
                if (lstMinMaxValue.Count > 0)
                {
                    objBankDepositBALClass.objBankobjectclass.MinId = Convert.ToInt32(lstMinMaxValue[0]);
                    objBankDepositBALClass.objBankobjectclass.MaxId = Convert.ToInt32(lstMinMaxValue[1]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstMinMaxValue = null;
            }
        }

        public string GetRecordForNewYrNo()
        {
            List<BankObjectClass> lstBankDetail = new List<BankObjectClass>();
            try
            {
                if (objBankDepositBALClass.GetReceiptWithYear(out lstBankDetail))
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

        public string GettingRecordForReceiptID()
        {
            List<BankObjectClass> lstBankDetail = new List<BankObjectClass>();
            try
            {
                if (objBankDepositBALClass.GetRecordForReceiptID(out lstBankDetail))
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

        public string AssignFromList(List<BankObjectClass> lstBankList)
        {
            if (lstBankList.Count > 0)
            {
                objBankDepositBALClass.objBankobjectclass.ReceiptNo = lstBankList[0].ReceiptNo;
                objBankDepositBALClass.objBankobjectclass.BankDetailID = lstBankList[0].BankDetailID;
                objBankDepositBALClass.objBankobjectclass.BankNameID = lstBankList[0].BankNameID;
                objBankDepositBALClass.objBankobjectclass.BranchNameID = lstBankList[0].BranchNameID;
                objBankDepositBALClass.objBankobjectclass.BankToMoveID = lstBankList[0].BankToMoveID;
                objBankDepositBALClass.objBankobjectclass.BranchToMoveID = lstBankList[0].BranchToMoveID;
                objBankDepositBALClass.objBankobjectclass.Amount = lstBankList[0].Amount;
                objBankDepositBALClass.objBankobjectclass.ProcessDate = lstBankList[0].ProcessDate;
                objBankDepositBALClass.objBankobjectclass.Description = lstBankList[0].Description;
                objBankDepositBALClass.objBankobjectclass.DepositDoneBy = lstBankList[0].DepositDoneBy;
                objBankDepositBALClass.objBankobjectclass.Status = lstBankList[0].Status;
                objBankDepositBALClass.objBankobjectclass.Year = lstBankList[0].Year;
                objBankDepositBALClass.objBankobjectclass.YearSequenceNo = lstBankList[0].YearSequenceNo;
                objBankDepositBALClass.objBankobjectclass.Reason = lstBankList[0].Reason;
                objBankDepositBALClass.objBankobjectclass.ReasonId = lstBankList[0].ReasonId;
                if (objBankDepositBALClass.objBankobjectclass.Status == 1 && !string.IsNullOrEmpty(objBankDepositBALClass.objBankobjectclass.Description))
                    return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                else if (objBankDepositBALClass.objBankobjectclass.Status == 0)
                    return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                else
                {
                    return GeneralFunction.ChangeLanguageforCustomMsg("New");
                }
            }
            return null;
        }

        public decimal GetBankBalance()
        {
            List<decimal> lstDepoDraw = new List<decimal>();
            lstDepoDraw = objBankDepositBALClass.GetBankBalance();
            return (lstDepoDraw[0] - lstDepoDraw[1]);
        }

        #endregion

        #region LoadEmptyRecord

        internal string BindMaxIdToControls(out string Labelstatus)
        {
            Labelstatus = string.Empty;
            List<BankObjectClass> ListObj_BankDepositCapital = new List<BankObjectClass>();
            try
            {
                ListObj_BankDepositCapital = objBankDepositBALClass.GetMaxIdRecord();
                int CheckMaxId = Convert.ToInt32(ListObj_BankDepositCapital[0].ReceiptNo);
                if (CheckMaxId != 0)
                {
                    objBankDepositBALClass.objBankobjectclass.ReceiptNo = ListObj_BankDepositCapital[0].ReceiptNo;
                    List<BankObjectClass> BankDepositRecord = objBankDepositBALClass.GetBankDepositRecord();
                    Labelstatus = AssignFromList(BankDepositRecord);
                    GetMaxMinID();
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
                ListObj_BankDepositCapital = null;
            }

        }


        internal void CreateEmptyRecord()
        {
            objBankDepositBALClass.objBankobjectclass.TableID = Convert.ToInt16(Table.BankDeposit);

            ReceiptNo = objBankDepositBALClass.GetBankDepositMaxID();
            objBankDepositBALClass.objBankobjectclass.ReceiptNo = ReceiptNo[0];
            objBankDepositBALClass.objBankobjectclass.DepositReceiptNo = ReceiptNo[0];
            objBankDepositBALClass.objBankobjectclass.Year = Convert.ToInt32(ReceiptNo[1]);
            objBankDepositBALClass.objBankobjectclass.YearSequenceNo = ReceiptNo[2];
            objBankDepositBALClass.objBankobjectclass.Description = string.Empty;
            objBankDepositBALClass.objBankobjectclass.DepositDoneBy = string.Empty;
            objBankDepositBALClass.objBankobjectclass.Reason = string.Empty;
            objBankDepositBALClass.objBankobjectclass.Amount = 0;
            objBankDepositBALClass.objBankobjectclass.TransactionFlag = 1;
            objBankDepositBALClass.objBankobjectclass.ProcessDate = DateTime.Now;
            objBankDepositBALClass.objBankobjectclass.TransactionType = 1;
            objBankDepositBALClass.objBankobjectclass.CreatedBy = GeneralFunction.UserId;
            objBankDepositBALClass.objBankobjectclass.ModifiedBy = GeneralFunction.UserId;
            objBankDepositBALClass.objBankobjectclass.Status = 1;
            objBankDepositBALClass.SaveBankDeposit();
            GetMaxMinID();

        }



        internal void BindWithDrawMaxIdToControls()
        {
            List<BankObjectClass> ListObj_BankWithDraw = new List<BankObjectClass>();
            try
            {
                ListObj_BankWithDraw = objBankDepositBALClass.GetMaxIdRecord();
                int CheckMaxId = Convert.ToInt32(ListObj_BankWithDraw[0].ReceiptNo);
                if (CheckMaxId == 0)
                {
                    ReceiptNo = objBankDepositBALClass.GetBankWithDrawMaxID();
                    objBankDepositBALClass.objBankobjectclass.ReceiptNo = ReceiptNo[0];
                    objBankDepositBALClass.objBankobjectclass.Year = Convert.ToInt32(ReceiptNo[1]);

                }
                else
                {
                    objBankDepositBALClass.objBankobjectclass.ReceiptNo = ListObj_BankWithDraw[0].ReceiptNo;
                    objBankDepositBALClass.objBankobjectclass.TransactionFlag = 2;
                    List<BankObjectClass> BankDepositRecord = objBankDepositBALClass.GetBankWithDrawRecord();
                    objBankDepositBALClass.objBankobjectclass.ReceiptNo = BankDepositRecord[0].ReceiptNo;
                    objBankDepositBALClass.objBankobjectclass.Year = Convert.ToInt32(BankDepositRecord[0].Year);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListObj_BankWithDraw = null;
            }
        }
        internal void CreateEmptyRecordForWithDraw()
        {
            objBankDepositBALClass.objBankobjectclass.TableID = Convert.ToInt16(Table.BankWithdraw);

            objBankDepositBALClass.GetBankWithDrawMaxID();
            objBankDepositBALClass.objBankobjectclass.Description = string.Empty;
            objBankDepositBALClass.objBankobjectclass.DepositDoneBy = string.Empty;
            objBankDepositBALClass.objBankobjectclass.Reason = string.Empty;
            objBankDepositBALClass.objBankobjectclass.Amount = 0;
            objBankDepositBALClass.objBankobjectclass.TransactionFlag = 2;
            objBankDepositBALClass.objBankobjectclass.ProcessDate = DateTime.Now;
            objBankDepositBALClass.objBankobjectclass.TransactionType = 1;
            objBankDepositBALClass.objBankobjectclass.CreatedBy = GeneralFunction.UserId;
            objBankDepositBALClass.objBankobjectclass.ModifiedBy = GeneralFunction.UserId;
            objBankDepositBALClass.objBankobjectclass.Status = 1;
            objBankDepositBALClass.SaveBankDeposit();

        }
        public void PrintOptionDetails()
        {
            Rpt_BankDeposit bankdeposit = new Rpt_BankDeposit();
            ReportsView reportview = new ReportsView();
            try
            {
                reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("BankDepositDetails");
                DataTable DT = objBankDepositBALClass.GetPrintBankDepositDetails();
                if (DT.Rows.Count > 0)
                {
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        DT.Rows[i]["ProcessDate"] = Convert.ToDateTime(DT.Rows[i]["ProcessDate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                    }
                    reportview.Report_Table = DT;
                    reportview.RptDoc = bankdeposit;
                    reportview.LoadEvent();
                    reportview.ShowDialog();
                }
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), objBankDepositBALClass.objBankobjectclass.ReceiptNo.ToString(), "BANK_TRANSACTION_DETAILS", "Print bank deposit details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bankdeposit = null;
                reportview = null;
            }
        }



        #endregion
    }

}




