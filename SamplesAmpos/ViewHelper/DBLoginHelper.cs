using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;

namespace BumedianBM.ViewHelper
{
    class DBLoginHelper
    {
        DBLoginBAL objDBLoginBALClass;

        public DBLoginHelper()
        {
            objDBLoginBAL = new DBLoginBAL();
        }

        public DBLoginBAL objDBLoginBAL
        {
            get { return objDBLoginBALClass; }
            set { objDBLoginBALClass = value; }
        }

        public List<EmployeeObjectClass> GetUser()
        {
            return objDBLoginBALClass.GetFilteredUser();
        }

    }
}
