using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;

namespace BumedianBM.ViewHelper
{
    public class CleanDBInfoHelper
    {
        CleanDBInformationBAL objCleanDBInformationBALClass;
        public CleanDBInfoHelper()
        {
            objCleanDBInformationBALClass = new CleanDBInformationBAL();
        }

        public CleanDBInformationBAL objCleanDBInformationBAL
        {
            get { return objCleanDBInformationBALClass; }
            set { objCleanDBInformationBALClass = value; }
        }

        public int CleanDbHelper()
        {
            int value = objCleanDBInformationBALClass.CleanDBBal();
            return value;
        }

    }
}
