using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class TimeAttendanceStampBAL
    {
        #region List
        List<EmployeeObjectClass> ObjTimeAttendanceListBAL = new List<EmployeeObjectClass>();
        #endregion

        #region Variables
        public EmployeeObjectClass ObjEmployeeObjectClass;
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
            return ObjTimeAttendanceListBAL = ObjAttendanceDALClass.GetWorkTimeAttendanceList();
        }
        public int Save_EmpWorkBrakeTime()
        {
            return ObjAttendanceDALClass.Save_EmpWorkBrakeTime(ObjEmployeeObjectClass);
        }
        public int Save_OverTime_EmpWorkBrakeTime()
        {
            return ObjAttendanceDALClass.Save_OverTime_EmpWorkBrakeTime(ObjEmployeeObjectClass);
        }
        public int Save_OverTime_EmpWorkEndTime()
        {
            return ObjAttendanceDALClass.Save_OverTime_EmpWorkEndTime(ObjEmployeeObjectClass);
        }
        public int Save_EmpWorkEndTime()
        {
            return ObjAttendanceDALClass.Save_EmpWorkEndTime(ObjEmployeeObjectClass);
        }
        public int Save_OverTime_EmpWorkStartTime()
        {
            return ObjAttendanceDALClass.Save_OverTime_EmpWorkStartTime(ObjEmployeeObjectClass);
        }
        public int Save_EmpWorkStartTime()
        {
            return ObjAttendanceDALClass.Save_EmpWorkStartTime(ObjEmployeeObjectClass);
        }
        public int Get_UserGroupID()
        {
            return ObjAttendanceDALClass.Get_UserGroupID(ObjEmployeeObjectClass);
        }
        public int Save_EmpSaveTime(int userid, DateTime datTime, int timeid)
        {
            return ObjAttendanceDALClass.Save_EmpSaveTime(userid, datTime, timeid);
        }
        public DataTable GetReportValuesBAL()
        {
            return ObjAttendanceDALClass.Get_ReportValues();
        }

    }
}
