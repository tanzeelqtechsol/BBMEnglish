using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using HSB_ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class PayReceiptBAL
    {

        PayReceiptDAL objPayReceiptDALClass;
        PayReceiptObject objPayReceiptObjectClass;

        public PayReceiptBAL()
        {
            objPayReceiptDALClass = new PayReceiptDAL();
            objPayReceiptObjectClass = new PayReceiptObject();
           
        }

        public PayReceiptObject objPayReceiptObject
        {
            get { return objPayReceiptObjectClass; }
            set { objPayReceiptObjectClass = value; }
        }

        public List<PayReceiptObject> GetBalanceBal()
        {
            //List<PayReceiptObject> lstBalance = objPayReceiptDALClass.GetBalanceSheetDetails(objPayReceiptObjectClass);
            //return lstBalance;
            return objPayReceiptDALClass.GetBalanceSheetDetails(objPayReceiptObjectClass);
        }

        public bool SavePayReceiptBal()
        {
            if (objPayReceiptDALClass.SavePayReceiptDetails(objPayReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object GetBankDeposit_MaxID()
        {
            return objPayReceiptDALClass.GetBankDeposit_MaxID();
        }
        public bool Insert_BankTransactionDetailsBAL(bool isEmptyRecord)
        {
            if (objPayReceiptDALClass.Insert_BankTransactionDetails(objPayReceiptObjectClass, isEmptyRecord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<long> GetBankDepositMaxID()
        {
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankWithdraw));
        }
        public bool DeletePayReceiptBal()
        {
            if (objPayReceiptDALClass.DeletePayReceiptDetails(objPayReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetLastInsertedRecord(out List<PayReceiptObject> lst)
        {
            if (objPayReceiptDALClass.FetchLastRecord( out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetPayRecordBal(out List<PayReceiptObject> lst)
        {
            if (objPayReceiptDALClass.GetPayRecord(objPayReceiptObjectClass, out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetSearchedRecordBal(out List<PayReceiptObject> lst)
        {
            if (objPayReceiptDALClass.GetSearchedRecord(objPayReceiptObjectClass, out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<PayReceiptObject> GetAllPaymntIdBal()
        {
         return  objPayReceiptDALClass.GetAllPaymentID();
        }

        public object   GetCurrentYearBal()
        {
           return  objPayReceiptDALClass.GetCurrentYear();
            
        }
        public List<long> GetPayReceiptMaxID()
        {
            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Payment));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.Payment));
        }
        public object   GetMaxIdRecord()
        {
           return objPayReceiptDALClass .Get_MaxIdOfPaymentRecord();
        }

        public DataTable GetPayReceiptPrintReportBal()
        {
            return objPayReceiptDALClass.GetPayReceiptPrintReport(objPayReceiptObjectClass);
        }

    }
}
