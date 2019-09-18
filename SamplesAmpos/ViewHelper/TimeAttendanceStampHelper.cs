using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using BumedianBM.ArabicView;
using ObjectHelper;
using CommonHelper;
using System.Data.SqlClient;
using System.Data;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
namespace BumedianBM.ViewHelper
{
    class TimeAttendanceStampHelper
    {
        #region Variables
        public TimeAttendanceStampBAL ObjTimeAttendStampBAL;
        #endregion

        #region List
        List<EmployeeObjectClass> ObjTimeAttendanceListHelp = new List<EmployeeObjectClass>();
        #endregion

        public TimeAttendanceStampHelper()
        {
            ObjTimeAttendStampBAL = new TimeAttendanceStampBAL();
            ObjTimeAttendStampBAL.SetCommonObject();
        }
        public TimeAttendanceStampBAL ObjTimeAttendStamp
        {
            get { return ObjTimeAttendStampBAL; }
            set { ObjTimeAttendStampBAL = value; }
        }
        public List<EmployeeObjectClass> GetWorkTimeAttedanceHelper()
        {
            return ObjTimeAttendanceListHelp = ObjTimeAttendStamp.GetWorkTimeAttedanceBAL();
        }
        public int Save_EmpWorkBrakeTime()
        {
            return ObjTimeAttendStamp.Save_EmpWorkBrakeTime();
        }
        public int Save_OverTime_EmpWorkBrakeTime()
        {
            return ObjTimeAttendStamp.Save_OverTime_EmpWorkBrakeTime();
        }
        public int Save_OverTime_EmpWorkEndTime()
        {
            return ObjTimeAttendStamp.Save_OverTime_EmpWorkEndTime();
        }
        public int Save_EmpWorkEndTime()
        {
            return ObjTimeAttendStamp.Save_EmpWorkEndTime();
        }
        public int Save_OverTime_EmpWorkStartTime()
        {
            return ObjTimeAttendStamp.Save_OverTime_EmpWorkStartTime();
        }
        public int Save_EmpWorkStartTime()
        {
            return ObjTimeAttendStamp.Save_EmpWorkStartTime();
        }
        public int AttendanceReport(DataTable dtAttend)
        {
            Rpt_AttendanceReport summery = new Rpt_AttendanceReport();
            ReportsView rptView = new ReportsView();
            //summery.Refresh();
            dtAttend = new DataTable("Attendancelist");
            //string qry = "Select * from View_timeattendencelist ";
            DataTable dtAtten1 = new DataTable();
            dtAtten1 = ObjTimeAttendStamp.GetReportValuesBAL();
            rptView.Report_Table = dtAtten1;
            rptView.RptDoc = summery;
            rptView.IsReportFooter= false;
            ReportDocument rpt = summery;
            Tables tbl = rpt.Database.Tables;
            rptView.Repnum = tbl;
            rptView.LoadEvent();
            rptView.ShowDialog();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "TimeAttendance", "MTB_WORK_TIME_ATTENDANCE", "Print time attendance details", Convert.ToInt32(InvoiceAction.No));
            return 1;
        }

        public int UserGroupID()
        {
            return ObjTimeAttendStamp.Get_UserGroupID();
        }
    }
}
