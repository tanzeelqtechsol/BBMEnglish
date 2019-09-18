using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;

using DataBaseHelper.DALClass;
using System.Data;


namespace BALHelper
{
  public class CashCapitalBALClass
    {
      public BankObjectClass objBankObjectClass ;
      public DataBaseHelper.DALClass.BankDespositDALClass objBankDespositDALClass=new DataBaseHelper.DALClass.BankDespositDALClass();
    
      public Boolean SaveBankCash()
      { return objBankDespositDALClass.Insert_BankTransactionDetails(objBankObjectClass); }

      public bool DeleteBankCash()
      { return objBankDespositDALClass.DepositDel_BankDepositDetails(objBankObjectClass); }

      public long LoadMaximumReceiptID()
      { return objBankDespositDALClass.getMaximumRecptID(objBankObjectClass); }

      public int LoadMinimumReceiptID()
      { return objBankDespositDALClass.getMinRecptID(objBankObjectClass); }

      public bool GetRecordForReceiptID(out List<BankObjectClass> lstBankDetails)
      { return objBankDespositDALClass.getRecordByReceiptID(objBankObjectClass, out lstBankDetails); }

      public bool GetReceiptWithYear(out List<BankObjectClass> lstBankDetails)
      { return objBankDespositDALClass.getReceiptWithYear(objBankObjectClass, out lstBankDetails); }

      public List<BankObjectClass> LoadMaxRecptIDWithYr()
      { return objBankDespositDALClass.getMaxRecptIDWithYear(objBankObjectClass); }





      public List<BankObjectClass> GetMaxIdRecord()
      {
          //List<BankObjectClass> ListOfMaxID = objBankDespositDALClass.Get_MaxIdOfRecord (objBankObjectClass );
          //return ListOfMaxID;
          return objBankDespositDALClass.Get_MaxIdOfRecord(objBankObjectClass);
      }
      public List<BankObjectClass> GetSCashCapitalRecord()
      {
          //List<BankObjectClass> GetRecord = objBankDespositDALClass.Get_RecordByID(objBankObjectClass);
          //return GetRecord;
          return objBankDespositDALClass.Get_RecordByID(objBankObjectClass);
      }
      public List<long> GetCashCapitalMaxID()
      {

          //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.CashCapital));
          //return list;
          return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.CashCapital));
      }
      public DataTable GetPrintCashCapitalDetails()
      {
          return objBankDespositDALClass.Get_BankCashCapital(objBankObjectClass);
      }
    }
}
