using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using System.Data;

namespace BumedianBM.ViewHelper
{
    class EndOfDayHelper
    {

        #region Declaration
        EndofDayBal objEndOfDayBal;
        //internal List<AgentDetailObjectClass> lstClientList = new List<AgentDetailObjectClass>();
        internal Dictionary<string, List<EndofTheDayObject>> dicEndfDay = new Dictionary<string, List<EndofTheDayObject>>();
        #endregion

        #region Constructor
        public EndOfDayHelper()
        {
            objEndOfDayBal = new EndofDayBal();
        }
        #endregion

        #region Getting EndOfDay BAL Class in Helper
        public EndofDayBal objEndOfBal
        {
            get { return objEndOfDayBal; }
            set { objEndOfDayBal = value; }
        }

        #endregion

        #region UIDatabase Methods
        public Dictionary<string, List<EndofTheDayObject>> GetEndOfDayDetailsBal(ref decimal Balance, ref decimal Drawing)
        {
            return objEndOfDayBal.GetEndOfDayDetailsBal(ref   Balance, ref Drawing);
        }

        public DataTable GetEndOfTheDayTotalCash(ref decimal Balance, ref decimal Drawing)
        {
            return objEndOfBal.GetEndOfDayTotalCash(ref Balance, ref Drawing);
        }

        #endregion

        #region UIHelper Methods
        public void Print()
        {

        }

        #endregion

    }
}
