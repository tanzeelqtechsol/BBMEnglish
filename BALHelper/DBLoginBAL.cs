using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;

namespace BALHelper
{
    public class DBLoginBAL
    {
        EmployeeObjectClass objEmployeeObj;

        public DBLoginBAL()
        {
            objEmployeeObj = new EmployeeObjectClass();
        }

        public EmployeeObjectClass objEmployeeObjectClass
        {
            get { return objEmployeeObj; }
            set { objEmployeeObj = value; }
        }


        public List<EmployeeObjectClass> GetFilteredUser()
        {
            List<EmployeeObjectClass> lstUser = GeneralObjectClass.UserList;

            lstUser = (from a in lstUser
                       where a.UserName == objEmployeeObjectClass.UserName && a.Password == objEmployeeObjectClass.Password
                       select a).ToList();

            return lstUser;
        }
    }
}
