using DataBaseHelper.DALClass;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BALHelper
{
   public class PrinterSetupBAL
    {
        public PrinterSetupObject objPrinterObject = new PrinterSetupObject();
        PrinterSetupDAL objPrinterSetupDALClass;
        public PrinterSetupBAL()
        {

            objPrinterSetupDALClass = new PrinterSetupDAL();
        }

        public bool UpdatePrinterSetupBal()
        {
            bool Value = objPrinterSetupDALClass.UpdatePrinterSetupDAL(objPrinterObject);
            return Value;
        }
    }
}
