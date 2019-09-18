using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using HSB_ObjectHelper;

namespace BALHelper
{
    public class ReceiveReceiptBAL
    {
        ReceiveReceiptDAL objReceiveReceiptDAL;
        ReceiveReceiptObject objReceiveReceiptObjectClass;

        public ReceiveReceiptBAL()
        {
            objReceiveReceiptDAL = new ReceiveReceiptDAL();
            objReceiveReceiptObjectClass = new ReceiveReceiptObject();
        }
        public ReceiveReceiptObject objReceiveReceiptObject
        {
            get { return objReceiveReceiptObjectClass; }
            set { objReceiveReceiptObjectClass = value; }
        }

        public bool SaveReceiveReceiptBal()
        {
            if (objReceiveReceiptDAL.SaveReceiveReceiptDetails(objReceiveReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Insert_BankTransactionDetailsBAL(bool isEmptyRecord)
        {
            if (objReceiveReceiptDAL.Insert_BankTransactionDetails(objReceiveReceiptObjectClass,isEmptyRecord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public bool UpdateSaleBalanceBal()
        {
            if (objReceiveReceiptDAL.UpdateSaleBalance(objReceiveReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSalePaymentTypeBal()
        {
            if (objReceiveReceiptDAL.UpdatePaymentType(objReceiveReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateSalePaymentChargesBal()
        {
            if (objReceiveReceiptDAL.UpdatePaymentCharges(objReceiveReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool GetPrevNextRecordBal(out List<ReceiveReceiptObject> lst)
        {
            if (objReceiveReceiptDAL.GetPrevNextRecord(objReceiveReceiptObjectClass, out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetAllReceiptIdBal(out List<ReceiveReceiptObject> lst)
        {
            if (objReceiveReceiptDAL.GetAllReceiptID(out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetSearchedRecordBal(out List<ReceiveReceiptObject> lst)
        {
            if (objReceiveReceiptDAL.GetSearchedRecord(objReceiveReceiptObjectClass, out lst))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteReceiptDetailsBal()
        {
            if (objReceiveReceiptDAL.DeleteReceiptDetails(objReceiveReceiptObjectClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object  GetCurrentYearBal()
        {
           return objReceiveReceiptDAL.GetCurrentYear();
          
        }




        public List<long> InsertReceiptID()
        {
            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.CustomerReceipt ));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.CustomerReceipt));     
        }
        public object GetReceiptMaxId()
        {
            return objReceiveReceiptDAL.GetReceipt_MaxID();
        }

        public object GetBankDeposit_MaxID()
        {
            return objReceiveReceiptDAL.GetBankDeposit_MaxID();
        }
        public List<long> GetBankDepositMaxID()
        {

            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankDeposit));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.BankDeposit));
        }

        public List<BankObjectClass> GetBankDetailsBal()
        {
            List<BankObjectClass> ObjListBank = objReceiveReceiptDAL.GetBankDetails();
            return ObjListBank;
        }

        public List<BankObjectClass> BranchDetailsBal()
        {
            List<BankObjectClass> ObjListBank = objReceiveReceiptDAL.BranchDetails();
            return ObjListBank;
        }
    }
}
