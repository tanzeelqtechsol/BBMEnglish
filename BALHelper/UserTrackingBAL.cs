using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;

namespace BALHelper
{
   public class UserTrackingBAL
    {
        public EmployeeDALClass ObjEmployeeDALClass = new EmployeeDALClass();
        public EmployeeObjectClass ObjEmployeeObjectClass = new EmployeeObjectClass();
        public EmployeeObjectClass ObjEmployeeObject
        {
            get { return ObjEmployeeObjectClass; }
            set { ObjEmployeeObjectClass = value; }
        }
        public List<EmployeeObjectClass> GetUsrTrackingActiontBAL()
        {
            List<EmployeeObjectClass> ObjUsrTrackListBal = new List<EmployeeObjectClass>();
            ObjUsrTrackListBal = ObjEmployeeDALClass.GetUsrTrackingActiontDAL(ObjEmployeeObject);
            return ObjUsrTrackListBal;
        }
    }
}
