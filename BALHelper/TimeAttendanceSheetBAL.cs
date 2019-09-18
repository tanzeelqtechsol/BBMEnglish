using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class TimeAttendanceSheetBAL
    {
        #region Variables
        public EmployeeObjectClass ObjEmployeeObjectClass;
        List<EmployeeObjectClass> ObjTimeAttendanceListBAL = new List<EmployeeObjectClass>();
        public TimeAttendanceStampDAL ObjAttendanceDALClass = new TimeAttendanceStampDAL();
        #endregion

        public EmployeeObjectClass ObjEmployeeObject
        {
            get { return ObjEmployeeObjectClass; }
            set { ObjEmployeeObjectClass = value; }
        }

        public void SetCommonObject()
        {
            ObjEmployeeObjectClass = new EmployeeObjectClass();
        }
        public List<EmployeeObjectClass> GetWorkTimeAttedanceBAL()
        {
            return ObjTimeAttendanceListBAL = ObjAttendanceDALClass.GetTimeAttendanceSheet(ObjEmployeeObjectClass);
        }
        
    }
}
