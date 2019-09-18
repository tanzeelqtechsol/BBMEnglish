using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Data;
using BumedianBM.CrystalReports;
using BumedianBM.ArabicView;

namespace BumedianBM.ViewHelper
{
   public class TimeAttendanceSheetHelper
    {
        #region Variables
        public TimeAttendanceSheetBAL ObjTimeAttendSheetBAL;
        public Int32 getHH = 0, getMM = 0, getSEC = 0, count = 1;
        public Int32 getHHdiff, getMMdiff, getSECdiff = 0; 
        #endregion
        #region List
        List<EmployeeObjectClass> ObjTimeAttendanceSheetHelp = new List<EmployeeObjectClass>();
        #endregion

        public TimeAttendanceSheetHelper()
        {
            ObjTimeAttendSheetBAL = new TimeAttendanceSheetBAL();
            ObjTimeAttendSheetBAL.SetCommonObject();
        }
        public TimeAttendanceSheetBAL ObjTimeAttendSheet
        {
            get { return ObjTimeAttendSheetBAL; }
            set { ObjTimeAttendSheetBAL = value; }
        }
       public List<EmployeeObjectClass> GetWorkTimeAttedanceHelper()
        {
            int Difftothrs = 0; int tothrs = 0; int mm = 0;
            ObjTimeAttendanceSheetHelp = ObjTimeAttendSheet.GetWorkTimeAttedanceBAL();
            if (ObjTimeAttendanceSheetHelp.Count > 0)
            {
                for (int i = 0; i < ObjTimeAttendanceSheetHelp.Count; i++)
                {
                    char[] deter = { ':' };
                    string str2 = ObjTimeAttendanceSheetHelp[i].TotalHours.ToString();
                    string[] splitval = str2.Split(deter);
                    if (str2 != "")
                    {
                        getHH += Convert.ToInt32(splitval[0]);
                        getMM += Convert.ToInt32(splitval[1]);
                        getSEC += Convert.ToInt32(splitval[2]);
                    }
                    char[] deterdiff = { ':' };
                    string strdiff = ObjTimeAttendanceSheetHelp[i].Difference.ToString();
                    string[] diffsplitval = strdiff.Split(deterdiff);
                    if (strdiff != "")
                    {
                        getHHdiff += Convert.ToInt32(diffsplitval[0]);
                        getMMdiff += Convert.ToInt32(diffsplitval[1]);
                        getSECdiff += Convert.ToInt32(diffsplitval[2]);
                    }
                }
                int hh = (getMM / 60);
                mm = (getMM - (hh * 60));
                tothrs = getHH + hh;
                string finalval = (tothrs.ToString("###00") + ":" + mm.ToString("##00") + ":" + getSEC.ToString("##00"));
                ObjTimeAttendSheet.ObjEmployeeObject.TotalHours = finalval;

                int hhdiff = (getMMdiff / 60);
                int mmdiff = (getMMdiff - (hhdiff * 60));
                Difftothrs = getHHdiff + hhdiff;
                string finalvalDiff = (Difftothrs.ToString("###00") + ":" + mmdiff.ToString("##00") + ":" + getSECdiff.ToString("##00"));
                ObjTimeAttendSheet.ObjEmployeeObject.WorkingDifference = finalvalDiff;

            }
            DateTime Todate =ObjTimeAttendSheet.ObjEmployeeObject.ToDate;
            DateTime FromDate = ObjTimeAttendSheet.ObjEmployeeObject.FromDate;
            TimeSpan tp = Todate.Subtract(FromDate);
            int totHR = Convert.ToInt16(tp.TotalDays);
            int HR = totHR == 0 ? 1 : totHR;
            decimal calAverage = Convert.ToDecimal((HR * 8) * 60);
            decimal calTotHrs = Convert.ToDecimal((tothrs * 60) + (mm / 60)) * 8;
            decimal avg = Convert.ToDecimal((calTotHrs / calAverage) / 8);
            ObjTimeAttendSheet.ObjEmployeeObject.DailyAvg = Convert.ToString(avg.ToString("######0.000"));
            getHH = 0; getMM = 0; getSEC = 0; getHHdiff = 0; getMMdiff = 0; getSECdiff = 0;
            return ObjTimeAttendanceSheetHelp;
        }

       public bool checkAttenValidation()
       {
           if (!ObjTimeAttendSheet.ObjEmployeeObject.Flag)
           {
               if (ObjTimeAttendSheet.ObjEmployeeObject.FromDate > ObjTimeAttendSheet.ObjEmployeeObject.ToDate)
               {
                   GeneralFunction.Information("CompareFromDateToDate", ActionType.View.ToString());
                   return false;
               }
           }
           if (ObjTimeAttendSheet.ObjEmployeeObject.SelectedFlag == 0)
           {
               CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKANYONEVARIABLE, ActionType.View.ToString());
               return false;
           }
           else if (ObjTimeAttendSheet.ObjEmployeeObjectClass.SelectedFlag == 2)
           {
               if (ObjTimeAttendSheet.ObjEmployeeObject.SelectedValue == -1)
               {
                   CommonHelper.GeneralFunction.ErrInfo(Constants.GROUPNAMEREQUIRED, ActionType.View.ToString());
                   return false;
               }
           }
           else if (ObjTimeAttendSheet.ObjEmployeeObjectClass.SelectedFlag == 3)
           {
               if (ObjTimeAttendSheet.ObjEmployeeObject.SelectedValue == -1)
               {
                   CommonHelper.GeneralFunction.ErrInfo(Constants.EMPLOYEENAMEREQUIRED, ActionType.View.ToString());
                   return false;
               }
           }
           return true;
       }
       public void GenerateAttendancsheetPrint(DataTable Atten)
       {
           Rpt_AllTimeAttendanceReport summery = new Rpt_AllTimeAttendanceReport();
           ReportsView rptView = new ReportsView();
           rptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("TimeAttendance");
           //summery.Refresh();
           Atten.TableName = "AllTimeAttandanceReport";
           rptView.Report_Table = Atten;
           rptView.RptDoc = summery;
           rptView.IsReportFooter = false;
           rptView.HTable.Clear();
           string TotHours= ObjTimeAttendSheet.ObjEmployeeObject.TotalHours;
           string workDiffer = ObjTimeAttendSheet.ObjEmployeeObject.WorkingDifference;
           rptView.HTable.Add("TotalHours", (TotHours != "") ? TotHours : "00:00:00");
           rptView.HTable.Add("TotalDifference", (workDiffer != "") ? workDiffer : "00:00:00");
           rptView.LoadEvent();
           rptView.ShowDialog();
           GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "TimeAttendance", "MTB_WORK_TIME_ATTENDANCE", "Print time attendance list details", Convert.ToInt32(InvoiceAction.No));
       }

       public void DisposeListObject()
       {
           ObjTimeAttendanceSheetHelp = null;
       }
       
    }
}
