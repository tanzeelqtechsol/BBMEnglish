using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataBaseHelper.DALClass;
using ObjectHelper;
//Modified By G.Saradhaa
namespace BALHelper
{
    public class BankWithdrawBALClass
    {
        #region Declaration
        BankDespositDALClass ObjBankDespositDALClass;
        public BankObjectClass objBankObjectClass;
        #endregion

        #region Constructor
        public BankWithdrawBALClass()
        { ObjBankDespositDALClass = new BankDespositDALClass(); }
        #endregion

        #region Methods

        public bool GetReceiptWithYear(out List<BankObjectClass> lstBankDetails)
        { return ObjBankDespositDALClass.getReceiptWithYear(objBankObjectClass, out lstBankDetails); }

        public bool GetRecordForReceiptID(out List<BankObjectClass> lstBankDetails)
        { return ObjBankDespositDALClass.getRecordByReceiptID(objBankObjectClass, out lstBankDetails); }

        public void GetBankBranchListNEW()
        {
            //   Get_BankAndBranchListNEW();
        }
        public List<int> GetDrawMaxMinReceiptNo()
        { return ObjBankDespositDALClass.Get_MaxMinReceiptNo(objBankObjectClass); }

        public Dictionary<string, object> GetDrawDetails()
        { return ObjBankDespositDALClass.Get_TableByReceipt(objBankObjectClass); }


        public int GetDepositMaxNY()
        { return ObjBankDespositDALClass.Get_MaxNY(objBankObjectClass); }

        public bool SaveBankDraw()
        {
            ObjBankDespositDALClass.Insert_BankTransactionDetails(objBankObjectClass);
            //if (lstBankObjectClass.Count > 0)
            return true; 
            //else
            //    return false;
          
        }

        public bool DeleteDrawDetails()
        {
            if (ObjBankDespositDALClass.DepositDel_BankDepositDetails(objBankObjectClass))
                return true;
            else
                return false;
        }
        public List<decimal> GetBankBalanceDetails()
        { return ObjBankDespositDALClass.getBankBalance(objBankObjectClass); }

        public long LoadMaximumReceiptID()
        { return ObjBankDespositDALClass.getMaximumRecptID(objBankObjectClass); }

        public int LoadMinimumReceiptID()
        { return ObjBankDespositDALClass.getMinRecptID(objBankObjectClass); }

        public List<BankObjectClass> LoadMaxRecptIDWithYr()
        { return ObjBankDespositDALClass.getMaxRecptIDWithYear(objBankObjectClass); }
        public List<BankObjectClass> GetMaxIdRecord()
        {
            List<BankObjectClass> ListOfMaxID = ObjBankDespositDALClass.Get_MaxIdOfRecord(objBankObjectClass);
            return ListOfMaxID;
        }
        public List<BankObjectClass> GetBankWithdrawRecord()
        {
            List<BankObjectClass> GetRecord = ObjBankDespositDALClass.Get_RecordByID(objBankObjectClass);
            return GetRecord;
        }
        public List<long> GetBankWithDrawMaxID()
        {

            List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankWithdraw));
            return list;
        }
        public DataTable GetPrintBankWithDrawDetails()
        {
            return ObjBankDespositDALClass.Get_BankWithDrawDetails(objBankObjectClass);
        }
        #endregion

        


       
    }
}
