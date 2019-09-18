using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class EndofDayBal
    {

        #region Declaration
        EndOfDayDAL objEndOfDayDal;
        EndofTheDayObject objEndOfDayObject;
        #endregion

        #region Constructor
        public EndofDayBal()
        {
            objEndOfDayDal = new EndOfDayDAL();
            objEndOfDayObject = new EndofTheDayObject();
        }
        #endregion:

        #region Getting Pos Object Class in BAL Class
        public EndofTheDayObject objEndfDayObject
        {
            get { return objEndOfDayObject; }
            set { objEndOfDayObject = value; }
        }
        #endregion
        //Commit
        #region Methods

        public Dictionary<string, List<EndofTheDayObject>> GetEndOfDayDetailsBal(ref decimal Balance,ref decimal Drawing)
        {

            return objEndOfDayDal.GetEndOfDayDetails(objEndOfDayObject, ref Balance, ref Drawing);
        }

        public DataTable GetEndOftheDayReportTotalRecord()
        {
            return objEndOfDayDal.GetEndOftheReportTatalRecord(objEndOfDayObject);
        }
        
        public DataTable GetEndOftheReportPuchaseInformation()
        {
            return objEndOfDayDal.GetEndOftheReportPuchaseInformation(objEndOfDayObject);
        }

        public DataTable GetEndOftheReportNetCashInHand()
        {
            return objEndOfDayDal.GetEndOftheReportNetCashInHand(objEndOfDayObject);
        }

        public DataTable GetEndOftheReportSaleInformation()
        {
            return objEndOfDayDal.GetEndOftheReportSaleInformation(objEndOfDayObject);
        }

        public DataTable DebtList(int AgentID)
        {
            return objEndOfDayDal.getDebtReportValues(AgentID);
        }

        public DataTable DebtListwithDateRange(DateTime dtFrom, DateTime dtTO, int Option,int AgentID)
        {
            return objEndOfDayDal.getDebtReportValuesWithDateRange(dtFrom, dtTO, Option, AgentID);
        }

        public DataSet GetEndOftheReportNetIncomeInformation()
        {
            return objEndOfDayDal.GetEndOftheReportNetIncomeInformation(objEndOfDayObject);
        }


        public DataTable GetEndOftheDayReportMovementRecord()
        {
            return objEndOfDayDal.GetEndOftheReportMovementRecord(objEndOfDayObject);
        }

        public DataSet GetEndOFTheDayReportZakatInfomation()
        {
            return objEndOfDayDal.GetEndOftheReportZakatCalculation();
        }

        public DataTable GetEndOFTheDayReportNetStockInfomation()
        {
            return objEndOfDayDal.GetEndOFTheDayReportNetStockInfomation();
        }

        public DataTable GetPayableReceivable()
        {
            return objEndOfDayDal.Get_PayableReceivable();
        }
        public DataSet Get_InventoryValue_Reports()
        {
            return objEndOfDayDal.GetInventoryValue_Reports();
        }

        public DataTable GetEndOFTheDayReportZakatInfomation1()
        {
            return objEndOfDayDal.GetEndOftheReportZakatCalculation1();
        }

        public DataTable GetEndOFTheDayReportCashInfomation()
        {
            return objEndOfDayDal.GetEndOftheReportCashInfromation(objEndOfDayObject);
        }

        public DataTable GetEndOfDayTotalCash(ref decimal Balance, ref decimal Drawing)
        {
            return objEndOfDayDal.GetEndOfDayTotalCash(objEndOfDayObject, ref Balance, ref Drawing);
        }
        #endregion

    }
}
