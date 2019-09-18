using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class BalanceSheetBAL
    {
        #region Declaration
        public BalanceSheetObjcetClass objBalanceSheetObjcetClass = new ObjectHelper.BalanceSheetObjcetClass();
        DataBaseHelper.DALClass.BalanceSheetDAL objBalanceSheetDAL = new DataBaseHelper.DALClass.BalanceSheetDAL();
        #endregion

        #region Methods

        public int GetCurrentYear()
        { return objBalanceSheetDAL.getCurrentYear(); }

        public DataTable GetBalanceDetails()
        {return objBalanceSheetDAL.getBalanceSheet(objBalanceSheetObjcetClass); }

        public DataTable GetBalanceTotalDetails()
        { return objBalanceSheetDAL.getBalanceSheetTotal(objBalanceSheetObjcetClass); }

        #endregion
    }
}
