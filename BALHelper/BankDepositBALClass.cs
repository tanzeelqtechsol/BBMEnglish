using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class BankDepositBALClass
    {
        #region Variable Declaration
        BankDespositDALClass ObjBankDespositDALClass;
        public BankObjectClass objBankobjectclass ;
        #endregion

        #region Constructor
        public BankDepositBALClass()
        { ObjBankDespositDALClass = new BankDespositDALClass();}
        #endregion

        #region Methods
        public bool GetReceiptWithYear(out List<BankObjectClass> lstBankDetails)
        { return ObjBankDespositDALClass.getReceiptWithYear(objBankobjectclass, out lstBankDetails); }

        public bool GetRecordForReceiptID(out List<BankObjectClass> lstBankDetails)
        { return ObjBankDespositDALClass.getRecordByReceiptID(objBankobjectclass, out lstBankDetails); }

        public bool DepositDelete()
        {
            if (ObjBankDespositDALClass.DepositDel_BankDepositDetails(objBankobjectclass))
                return true;
            else
                return false;
        }

        public bool DrawDelete()
        {

            if (ObjBankDespositDALClass.DrawDel_BankDepositDetails(objBankobjectclass))
                return true;
            else
                return false;
        }

        public List<int> GetDepositMaxMinReceiptNo()
        { return ObjBankDespositDALClass.Get_MaxMinReceiptNo(objBankobjectclass); }

        public Dictionary<string, object> GetDepositDetails()
        { return ObjBankDespositDALClass.Get_TableByReceipt(objBankobjectclass); }

        public Boolean SaveBankDeposit()
        { return ObjBankDespositDALClass.Insert_BankTransactionDetails(objBankobjectclass); }

        public long GetDrawBankDetailID()
        { return ObjBankDespositDALClass.getDrawBankDetailID(objBankobjectclass); }

        public int GetDepositMaxNY()
        { return ObjBankDespositDALClass.Get_MaxNY(objBankobjectclass); }

        public bool SaveBankTransactionDetails()
        {
            if (ObjBankDespositDALClass.Insert_BankTransactionDetails(objBankobjectclass))
                return true;
            else
                return false;
        }

        public long getMaximumRecptID()
        { return ObjBankDespositDALClass.getMaximumRecptID(objBankobjectclass); }

        public int LoadMinimumReceiptID()
        { return ObjBankDespositDALClass.getMinRecptID(objBankobjectclass); }

        public List<decimal> GetBankBalance()
        { return ObjBankDespositDALClass.getBankBalance(objBankobjectclass); }

        public List<BankObjectClass> LoadMaxRecptIDWithYr()
        { return ObjBankDespositDALClass.getMaxRecptIDWithYear(objBankobjectclass); }


        public List<BankObjectClass> GetMaxIdRecord()
        {
            //List<BankObjectClass> ListOfMaxID = ObjBankDespositDALClass.Get_MaxIdOfRecord(objBankobjectclass );
            //return ListOfMaxID;
            return ObjBankDespositDALClass.Get_MaxIdOfRecord(objBankobjectclass);
        }
        public List<long> GetBankDepositMaxID()
        {

            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankDeposit));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankDeposit));
        }
        public List<BankObjectClass> GetBankDepositRecord()
        {
            //List<BankObjectClass> GetRecord = ObjBankDespositDALClass.Get_RecordByID(objBankobjectclass);
            //return GetRecord;
            return ObjBankDespositDALClass.Get_RecordByID(objBankobjectclass);
        }
        public List<long> GetBankWithDrawMaxID()
        {

            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankWithdraw));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankWithdraw));
        }



        public List<BankObjectClass> GetBankWithDrawRecord()
        {
            //List<BankObjectClass> GetRecord = ObjBankDespositDALClass.Get_RecordByID(objBankobjectclass);
            //return GetRecord;
            return ObjBankDespositDALClass.Get_RecordByID(objBankobjectclass);
        }
        public DataTable GetPrintBankDepositDetails()
        {
            return ObjBankDespositDALClass.Get_BankDepositDetails(objBankobjectclass);
        }
        #endregion
    }
}
