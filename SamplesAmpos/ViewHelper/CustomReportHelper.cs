using BALHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BumedianBM.ViewHelper
{
    public class CustomReportHelper
    {
        CustomReportBALLClass objbalclass;
        public CustomReportHelper()
        {
            objbalclass = new CustomReportBALLClass();
            ObjBALClass = new CustomReportBALLClass();
        }
        public CustomReportBALLClass ObjBALClass
        {
            get { return objbalclass; }
            set { objbalclass = value; }
        }
    }
}
