using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using CommonHelper;

namespace BALHelper
{
    public class SalaryPaymentBAL
    {
        #region Variables
        public SalaryPaymentDAL ObjSalDALClass;
        Dictionary<string, List<EmployeeObjectClass>> ObjSalDictBAL = new Dictionary<string, List<EmployeeObjectClass>>();
        public SpendingDALClass ObjSpendingDAL = new SpendingDALClass();
        public EmployeeObjectClass ObjEmployeeObjectClass;
        SpendingObjectClass ObjSpending;
        #endregion
        public EmployeeObjectClass ObjEmployeeObject
        {
            get { return ObjEmployeeObjectClass; }
            set { ObjEmployeeObjectClass = value; }
        }
        public SalaryPaymentBAL()
        {
            ObjSpending = new SpendingObjectClass();
            ObjSpendingDAL = new SpendingDALClass();
            ObjSalDALClass = new SalaryPaymentDAL();
        }
        public void SetCommonObject()
        {
            ObjEmployeeObjectClass = new EmployeeObjectClass();
        }
        public Dictionary<string, List<EmployeeObjectClass>> GetSalaryDetails()
        {
            ObjSalDictBAL = ObjSalDALClass.Get_SalaryDetailsList(ObjEmployeeObjectClass);
            return ObjSalDictBAL;
        }
        public int Save_PaySalaryDetails()
        {
            //int i = ObjSalDALClass.Save_PaySalaryDetails(ObjEmployeeObjectClass);
            //return i;
            return ObjSalDALClass.Save_PaySalaryDetails(ObjEmployeeObjectClass);
        }
        public int Undo_SalaryPaymentDetails()
        {
            //int i = ObjSalDALClass.Undo_SalaryPaymentDetails(ObjEmployeeObjectClass);
            //return i;
            return ObjSalDALClass.Undo_SalaryPaymentDetails(ObjEmployeeObjectClass);
        }
        public void SaveSpendings()
        {
            List<SpendingObjectClass> obj = new List<SpendingObjectClass>();
            List<long> ID = new List<long>();
            try
            {
                obj = ObjSpendingDAL.Get_MaxIdOfSpendingRecord();
                if (ObjEmployeeObjectClass.NetSalary != 0)
                {
                    ObjSpending.ExpensesID = obj[0].ExpensesID;
                    ObjSpending.Description = "SalaryPayment";
                    ObjSpending.Details = ObjEmployeeObject.UserId.ToString();
                    ObjSpending.Notes = "SalaryPayment";
                    ObjSpending.Value = ObjEmployeeObject.NetSalary;
                    ObjSpending.CreatedDate = DateTime.Now.Date;
                    ObjSpending.CreatedBy = ObjEmployeeObject.UserId;
                    ObjSpending.ProcessDate = DateTime.Now.Date;
                    ObjSpending.Status = 1;
                    ObjSpending.Remove = 0;
                    if (ObjSpendingDAL.saveSpendings(ObjSpending))
                    {
                        //ObjSpending = new SpendingObjectClass();
                        ID = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(Table.Expenses));
                        ObjSpending.ExpensesID = ID[0];
                        ObjSpending.Description = string.Empty;
                        ObjSpending.Details = string.Empty;
                        ObjSpending.Notes = string.Empty;
                        ObjSpending.Value = 0.0m;
                        ObjSpending.ProcessDate = DateTime.Now;
                        if (ObjSpendingDAL.saveSpendings(ObjSpending))
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                obj = null;
                ID = null;
            }
        }
        public void UndoSalaryVariables()
        {
            ObjSalDALClass.Undo_SalaryPaymentDetails(ObjEmployeeObject);
        }
        public void UndoSalaryDrawings()
        {
            ObjSalDALClass.Undo_SalaryPaymentDetails(ObjEmployeeObject);
        }

    }
}
