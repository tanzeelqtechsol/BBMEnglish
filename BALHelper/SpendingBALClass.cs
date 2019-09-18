using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;

using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class SpendingBALClass
    {
        #region Declaration
        private DataBaseHelper.DALClass.SpendingDALClass objSpendingDALClass = new DataBaseHelper.DALClass.SpendingDALClass();
        public ObjectHelper.SpendingObjectClass objSpendingObjectClass ;
        #endregion


        #region Constructor

      
        #endregion

        #region Methods
        public List<string> GetDescriptionList()
        { return objSpendingDALClass.get_Description(); }

        public bool SaveSpendings()
        {

            if (objSpendingDALClass.saveSpendings(objSpendingObjectClass))
            {
                return true;
            }
            else
                return false;

        }
        public List<SpendingObjectClass> GetExpensesIDWithYr()
        { return objSpendingDALClass.getMaxRecptIDWithYear(objSpendingObjectClass); }

        public List<SpendingObjectClass> GetExpensesTable()
        { return objSpendingDALClass.getExpensesTable(objSpendingObjectClass); }


        //public List<SpendingObjectClass> GetObjectByID()
        //{ return objSpendingDALClass.GetRecordById(objSpendingObjectClass); }
        //public bool FetchLastObject(out List<SpendingObjectClass> lstLastRecord)
        //{ return objSpendingDALClass.FetchLastRecord(out lstLastRecord); }
                //public long FetchMaxID()
        //{ return objSpendingDALClass.getMaxValue(); }

      

        public bool Delete()
        { return objSpendingDALClass.deleteInDB(objSpendingObjectClass); }

        public bool AddDescription()
        { return objSpendingDALClass.AddDescDB(objSpendingObjectClass); }

      

        public long FetchMinID()
        { return objSpendingDALClass.getMinValue(); }

        public List<SpendingObjectClass> GetMaxIdRecord()
        {
            //List<SpendingObjectClass> ListOfMaxID = objSpendingDALClass.Get_MaxIdOfSpendingRecord();
            //return ListOfMaxID;
            return objSpendingDALClass.Get_MaxIdOfSpendingRecord();
        }
        public List<long> GetExpensesMaxID()
        {
               
            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Expenses));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Expenses));
        }
        public List<SpendingObjectClass> GetSpendingRecord()
        {
            //List<SpendingObjectClass> GetRecord = objSpendingDALClass.Get_SpendingRecord(objSpendingObjectClass);
            //return GetRecord;
            return objSpendingDALClass.Get_SpendingRecord(objSpendingObjectClass);
        }
        public DataTable GetExpensesPrintDetails()
        {
           return  objSpendingDALClass.Get_ExpensesPrintdetails(objSpendingObjectClass);
        }
        #endregion
    }
}
