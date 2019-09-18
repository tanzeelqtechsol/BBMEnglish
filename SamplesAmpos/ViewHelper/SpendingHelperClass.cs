using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using CommonHelper;
using ObjectHelper;
using BumedianBM.CrystalReports;
using BumedianBM.ArabicView;
using System.Data;
using System.Windows.Forms;

namespace BumedianBM.ViewHelper
{
    class SpendingHelperClass
    {
        #region Declaration
        internal SpendingBALClass objSpendingBALClass = new SpendingBALClass();

        internal List<string> lstDescriptionList = new List<string>();
        internal List<ObjectHelper.SpendingObjectClass> lstYySeqWithMaxID = new List<ObjectHelper.SpendingObjectClass>();
        internal bool isAddDes = false;
        internal long MaxExpenseID = 0;
        internal long MinExpenseID = 0;
        internal int CurrentYear;
        internal List<long> ExpensesID = new List<long>();
        public bool CheckNavigation = false;

        #endregion

        #region Constructor
        public SpendingHelperClass()
        {

            New();
            LoadDescription();

        }
        #endregion
        private void GetMaxMinID()
        {
            List<ObjectHelper.SpendingObjectClass> lstSpendingObjectClass = new List<ObjectHelper.SpendingObjectClass>();
            try
            {
                GetMinID();
                lstSpendingObjectClass = objSpendingBALClass.GetExpensesIDWithYr();
                MaxExpenseID = lstSpendingObjectClass[0].ExpensesID;
                CurrentYear = lstSpendingObjectClass[0].Year;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstSpendingObjectClass = null;
            }
        }

        #region Helper Methods

        void LoadDescription()
        { lstDescriptionList = objSpendingBALClass.GetDescriptionList(); }

        internal void New()
        { objSpendingBALClass.objSpendingObjectClass = new ObjectHelper.SpendingObjectClass(Convert.ToInt16(Table.Expenses)); }

        private void GetMinID()
        { MinExpenseID = objSpendingBALClass.FetchMinID(); }

        public bool AssignListsToObject(List<ObjectHelper.SpendingObjectClass> lstTemp)
        {
            if (lstTemp.Count > 0)
            {
                objSpendingBALClass.objSpendingObjectClass.ExpensesID = lstTemp[0].ExpensesID;
                objSpendingBALClass.objSpendingObjectClass.Description = lstTemp[0].Description;
                objSpendingBALClass.objSpendingObjectClass.Value = lstTemp[0].Value;
                objSpendingBALClass.objSpendingObjectClass.Details = lstTemp[0].Details;
                objSpendingBALClass.objSpendingObjectClass.Notes = lstTemp[0].Notes;
                objSpendingBALClass.objSpendingObjectClass.Status = lstTemp[0].Status;
                objSpendingBALClass.objSpendingObjectClass.Year = lstTemp[0].Year;
                objSpendingBALClass.objSpendingObjectClass.ProcessDate = lstTemp[0].ProcessDate;
                objSpendingBALClass.objSpendingObjectClass.YearSequence = lstTemp[0].YearSequence;
                objSpendingBALClass.objSpendingObjectClass.CreatedBy = lstTemp[0].CreatedBy;
                objSpendingBALClass.objSpendingObjectClass.ModifiedBy = lstTemp[0].ModifiedBy;

                return true;
            }
            else
                return false;
        }

        public int CheckStatus()
        {
            if (objSpendingBALClass.objSpendingObjectClass.Status == 1 && !string.IsNullOrEmpty(objSpendingBALClass.objSpendingObjectClass.Description))
            { return 2; }
            else if (objSpendingBALClass.objSpendingObjectClass.Status == 0)
            { return 3; }
            else
            { return 1; }
            return 0;
        }


        internal bool Validation()
        {

            if ((objSpendingBALClass.objSpendingObjectClass.Description).Length == 0)//Fastest Way For String
            {
                GeneralFunction.Information("EmptyDescription", ActionType.Save.ToString());
                objSpendingBALClass.objSpendingObjectClass.ValidationString = "cmbDescription";

                return false;
            }
            if (objSpendingBALClass.objSpendingObjectClass.Value == 0)
            {
                GeneralFunction.Information("EmptyValue", ActionType.Save.ToString());
                objSpendingBALClass.objSpendingObjectClass.ValidationString = "txtValue";

                return false;
            }
            return true;

        }
        #endregion

        #region Event Methods
        public bool TextChanged(out int GetLableStatus)
        {
            List<ObjectHelper.SpendingObjectClass> lstFilterByID = new List<ObjectHelper.SpendingObjectClass>();
            try
            {
                lstFilterByID = objSpendingBALClass.GetExpensesTable();
                if (AssignListsToObject(lstFilterByID))
                {
                    GetLableStatus = CheckStatus();
                    return true;
                }
                else
                {
                    GeneralFunction.Information("Enter Valid Bill NO", "Expenses");
                    GetLableStatus = 1;
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstFilterByID = null;
            }

        }


        internal bool SaveSpendingDetails()
        {
            objSpendingBALClass.objSpendingObjectClass.Status = 1;
            if (objSpendingBALClass.objSpendingObjectClass != null)
            {
                if (Validation())
                {
                    if (isAddDes == true)
                    {
                        if (!objSpendingBALClass.AddDescription())
                        {
                            GeneralFunction.Information("Description  not saved", "Save");
                            return false;
                        }
                    }

                    if (objSpendingBALClass.SaveSpendings())
                    {
                        GeneralFunction.Information("SaveSpending", ActionType.Save.ToString());
                        LoadDescription();
                        if (CheckNavigation == false || objSpendingBALClass.objSpendingObjectClass.Status == 1)
                        {
                            New();
                            CreateEmptyRecord();
                        }
                        return true;
                    }
                    else
                    {
                        GeneralFunction.Information("FailedSaveSpending", ActionType.Save.ToString());
                        New();
                        return false;
                    }
                }
            }
            return false;
        }

        internal bool DeleteByID()
        {
            if (GeneralFunction.Question("AlertDeleteSpending", ActionType.Delete.ToString()) == DialogResult.Yes)
            {
                objSpendingBALClass.objSpendingObjectClass.Status = 0;
                objSpendingBALClass.objSpendingObjectClass.CreatedBy = GeneralFunction.UserId;

                if (objSpendingBALClass.Delete())
                {
                    GeneralFunction.Information("DeleteSpending", ActionType.Delete.ToString());
                    LoadDescription();
                    // New();
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedDeleteSpending", ActionType.Delete.ToString());
                    New();
                    return false;
                }
            }
            return false;

        }
        public bool Next(out int LabelStatus)
        {
            LabelStatus = 0;
            long expensesid = 0;
            expensesid = objSpendingBALClass.objSpendingObjectClass.ExpensesID + 1;
            List<SpendingObjectClass> FetchNextRecord;
            List<SpendingObjectClass> FetchRecord;
            try
            {
                if (MaxExpenseID > expensesid)
                {
                    objSpendingBALClass.objSpendingObjectClass.ExpensesID = expensesid;
                    FetchNextRecord = objSpendingBALClass.GetSpendingRecord();
                    if (!AssignListsToObject(FetchNextRecord))
                    {
                        CheckNavigation = false;
                        return false;

                    }
                }
                else
                {
                    objSpendingBALClass.objSpendingObjectClass.ExpensesID = MaxExpenseID;
                    FetchRecord = objSpendingBALClass.GetSpendingRecord();
                    if (!AssignListsToObject(FetchRecord))
                    {
                        //GeneralFunction.Information("Error Occured while fetching record", "Previous");
                        CheckNavigation = false;
                        return false;
                    }

                }
                LabelStatus = CheckStatus();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FetchNextRecord = null;
                FetchRecord = null;
            }
        }

        public bool Previous(out int LabelStatus)
        {
            LabelStatus = 0;
            long expensesid = 0;

            expensesid = objSpendingBALClass.objSpendingObjectClass.ExpensesID - 1;
            if (MinExpenseID > expensesid)
            {
                objSpendingBALClass.objSpendingObjectClass.ExpensesID = MinExpenseID;
                List<SpendingObjectClass> FetchLastRecord = objSpendingBALClass.GetSpendingRecord();

                if (!AssignListsToObject(FetchLastRecord))
                {
                    //GeneralFunction.Information("Error Occured while fetching record", "Previous");
                    return false;
                }

            }
            else
            {
                objSpendingBALClass.objSpendingObjectClass.ExpensesID = expensesid;
                List<SpendingObjectClass> FetchLastRecord = objSpendingBALClass.GetSpendingRecord();

                if (!AssignListsToObject(FetchLastRecord))
                {
                    return false;
                }

            }

            LabelStatus = CheckStatus();
            return true;
        }
        #endregion



        #region LoadEmptyRecord

        internal void BindMaxIdToControls()
        {
            List<SpendingObjectClass> ListObj_spending = new List<SpendingObjectClass>();
            List<SpendingObjectClass> SpendingRecord;
            try
            {
                ListObj_spending = objSpendingBALClass.GetMaxIdRecord();
                int CheckMaxId = Convert.ToInt32(ListObj_spending[0].ExpensesID);
                if (CheckMaxId != 0)
                {
                    objSpendingBALClass.objSpendingObjectClass.ExpensesID = ListObj_spending[0].ExpensesID;
                    SpendingRecord = objSpendingBALClass.GetSpendingRecord();
                    AssignListsToObject(SpendingRecord);
                    GetMaxMinID();
                }
                else
                {
                    CreateEmptyRecord();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListObj_spending = null;
                SpendingRecord = null; 
            }
        }


        internal void CreateEmptyRecord()
        {
            ExpensesID = objSpendingBALClass.GetExpensesMaxID();
            objSpendingBALClass.objSpendingObjectClass.ExpensesID = ExpensesID[0];
            objSpendingBALClass.objSpendingObjectClass.Year = Convert.ToInt32(ExpensesID[1]);
            objSpendingBALClass.objSpendingObjectClass.YearSequence = ExpensesID[2];
            objSpendingBALClass.objSpendingObjectClass.Description = string.Empty;
            objSpendingBALClass.objSpendingObjectClass.Details = string.Empty;
            objSpendingBALClass.objSpendingObjectClass.Notes = string.Empty;
            objSpendingBALClass.objSpendingObjectClass.Value = 0;
            objSpendingBALClass.objSpendingObjectClass.ProcessDate = DateTime.Now;
            objSpendingBALClass.objSpendingObjectClass.CreatedBy = GeneralFunction.UserId;
            objSpendingBALClass.objSpendingObjectClass.Status = 1;
            objSpendingBALClass.objSpendingObjectClass.ModifiedBy = GeneralFunction.UserId;
            objSpendingBALClass.objSpendingObjectClass.Remove = 0;
            objSpendingBALClass.SaveSpendings();
            GetMaxMinID();
        }





        public void PrintOptionDetails()
        {
            Rpt_ExpensesDetails expensesreport = new Rpt_ExpensesDetails();
            ReportsView rptView = new ReportsView();
            rptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("ExpensesDetailList");

            DataTable dt = objSpendingBALClass.GetExpensesPrintDetails();

            if (dt.Rows.Count > 0)
            {
                rptView.RptDoc = expensesreport;

                rptView.Report_Table = dt;

                rptView.HTable.Clear();
                rptView.HTable.Add("FromDate", "");
                rptView.HTable.Add("ToDate", "");
                rptView.HTable.Add("HideDate", true);
                rptView.LoadEvent();
                rptView.ShowDialog();
            }

        }


    }

        #endregion



}


