using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using CommonHelper;
using System.Data;

namespace BALHelper
{
    public class DebtAdjustBALClass
    {

         AgentDetailDAL ObjDebtAdjustDAL;
         AgentDetailObjectClass objDebtAdjustObject;

        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        public DebtAdjustBALClass()
        {
            ObjDebtAdjustDAL = new AgentDetailDAL();
          
        }
        public void SetComObject()
        {

            objDebtAdjustObject = new AgentDetailObjectClass();
        }
        

        public AgentDetailObjectClass ObjDebtAdjustObject
        {
            get { return objDebtAdjustObject; }
            set { objDebtAdjustObject = value; }
        }


       
        //public DataTable GetAgentNameandID()
        //{
        //    dt1 = ObjDebtAdjustDAL.Get_AgentNameandID();
        //    return dt1;
        //}
        public List<int> GetMinMaxID()
        {
            //List<int> minmaxID = ObjDebtAdjustDAL.Get_MinMaxID();
            //return minmaxID;
            return ObjDebtAdjustDAL.Get_MinMaxID();
        }

        public bool DebtSavePayable()
        {
            if (ObjDebtAdjustDAL.Save_DebtAdjustmentDetails_Payable(ObjDebtAdjustObject))
                return true;
            else
                return false;
        }
        public bool DebtSaveReceivable()
        {
            if (ObjDebtAdjustDAL.Save_DebtAdjustmentDetails_Receivable(ObjDebtAdjustObject))
                return true;
            else
                return false;
        }

        public List<AgentDetailObjectClass> GetDetailsByID()
        {
           //List<AgentDetailObjectClass> DebtDetails = ObjDebtAdjustDAL.Get_DebtAdjustmentDetails(ObjDebtAdjustObject);
           //return DebtDetails;  
            return ObjDebtAdjustDAL.Get_DebtAdjustmentDetails(ObjDebtAdjustObject);
        }

        public List<AgentDetailObjectClass> GetBalance()
        {
            //List<AgentDetailObjectClass> GetBalanceList = ObjDebtAdjustDAL.GetBalanceSheet(ObjDebtAdjustObject);
            //return GetBalanceList;
            return ObjDebtAdjustDAL.GetBalanceSheet(ObjDebtAdjustObject);
        }

        public List<AgentDetailObjectClass> IDForDebt()
        {
            //List<AgentDetailObjectClass> ID = ObjDebtAdjustDAL.Get_MaxIDDebt();
            //return ID;
            return ObjDebtAdjustDAL.Get_MaxIDDebt();
        }

        public List<AgentDetailObjectClass> GetDebtRecord()
        {
            //List<AgentDetailObjectClass> GetDebtRecord = ObjDebtAdjustDAL.Get_DebtAdjustmentDetails(ObjDebtAdjustObject);
            //return GetDebtRecord;
            return ObjDebtAdjustDAL.Get_DebtAdjustmentDetails(ObjDebtAdjustObject);
        }
        public List<long> GetDebtKeySequenceID()
        {
            //List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.DebitPayableReceivable));
            //return list;
            return StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.DebitPayableReceivable));
        }
        public Boolean DeleteDebtRecord()
        {
            if (ObjDebtAdjustDAL.DebtDeleteReceipt(ObjDebtAdjustObject))
                return true;
            else
                return false;
        }
        public object GetReceiptIDBasedonyearvalue()
        {
            //object obj = StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjDebtAdjustObject.Year, ObjDebtAdjustObject.YearSequenceNo, Convert.ToInt32(Table.DebitPayableReceivable));
            //return obj;
            return StoredProcedurers.GetInvoiceIDBasedonNewYearID(ObjDebtAdjustObject.Year, ObjDebtAdjustObject.YearSequenceNo, Convert.ToInt32(Table.DebitPayableReceivable));
        }
        public DataTable GetDebtAdjustReport()
        {
            return ObjDebtAdjustDAL.DebtAdjustDetails(ObjDebtAdjustObject.ReceiptID);
        }
        public List<int> GetYearandYearValue()
        {
            List<int> ID = new List<int>();
            DataTable dt = StoredProcedurers.Get_NewYearNo(ObjDebtAdjustObject.ReceiptID, "Debt");
            if (dt != null && dt.Rows.Count > 0)
            {
                ID.Add(Convert.ToInt32(dt.Rows[0]["Year"]));
                ID.Add(Convert.ToInt32(dt.Rows[0]["YearSequenceNo"]));
            }
            return ID;
        }

        public DataTable DebtBalanceSheet()
        {
            return ObjDebtAdjustDAL.DebtGetBalanceSheet(ObjDebtAdjustObject);
        }
    }

}
