using BALHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BumedianBM.ViewHelper
{
   public  class PrinterSetupHelper
    {
        #region Variables
        public PrinterSetupBAL objPrinterSetupBAL;
        #endregion

        #region Constrcutor
        public PrinterSetupHelper()
        {
            objPrinterSetupBAL = new PrinterSetupBAL();
        }
        #endregion

        public bool UpdatePrinterSetupHelper()
        {
            bool Value = objPrinterSetupBAL.UpdatePrinterSetupBal();
            return Value;
        }
    }
}
