using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Data;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Threading;

namespace BumedianBM.ViewHelper
{
    public class UserTrackingHelper
    {
        public UserTrackingBAL ObjusrTrackBALClass;
        EmployeeObjectClass ObjEmployeeObjectClass = new EmployeeObjectClass();
        public UserTrackingHelper()
        {
            ObjusrTrackBALClass = new UserTrackingBAL();
            //ObjusrTrackBALClass.SetCommonObject();
        }
        public UserTrackingBAL ObjEmployeeBAL
        {
            get { return ObjusrTrackBALClass; }
            set { ObjusrTrackBALClass = value; }
        }
        public List<EmployeeObjectClass> GetUsrTrackingActiontBAL()
        {
            List<EmployeeObjectClass> ObjUsrTrackListHelp = new List<EmployeeObjectClass>();
            if (CheckValidations())
            {
                ObjUsrTrackListHelp = ObjusrTrackBALClass.GetUsrTrackingActiontBAL();
            }
            return ObjUsrTrackListHelp;
        }
        public bool CheckValidations()
        {

            if (ObjusrTrackBALClass.ObjEmployeeObject.chkAllDate != true)
            {
                if (ObjusrTrackBALClass.ObjEmployeeObject.FromDate > ObjusrTrackBALClass.ObjEmployeeObject.ToDate)
                {
                    GeneralFunction.Information("CompareFromDateToDate", "User Tracking");
                    ObjusrTrackBALClass.ObjEmployeeObjectClass.ValidationString = "Dtp_FromDate";
                    //Dtp_FromDate.Focus();
                    return false;
                }
            }
            if (ObjusrTrackBALClass.ObjEmployeeObject.chkAllEmployee != true)
            {
                if (ObjusrTrackBALClass.ObjEmployeeObject.SelectedValue == -1)
                {
                    GeneralFunction.Information("Empty User", "User Tracking");
                    ObjusrTrackBALClass.ObjEmployeeObjectClass.ValidationString = "Cmb_UserName";
                    //Cmb_UserName.Focus();
                    return false;
                }

            }
            if ((ObjusrTrackBALClass.ObjEmployeeObject.DetailedReport == false) & (ObjusrTrackBALClass.ObjEmployeeObject.FPrint == false))
            {
                if (ObjusrTrackBALClass.ObjEmployeeObject.SelectedAction == -1)
                {
                    GeneralFunction.Information("Empty Action", "User Tracking");
                    ObjusrTrackBALClass.ObjEmployeeObjectClass.ValidationString = "Cmb_Action";
                    //Cmb_Action.Focus();
                    return false;
                }
            }
            return true;
        }
        public void GenerateUsrTrackReport(DataTable dtUsrTrack)
        {
            Rpt_UserTrackingList summery = new Rpt_UserTrackingList();
            ReportsView rptView = new ReportsView();
            rptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("UserTracking");
            DataTable UserTable = new DataTable("UserTracking");
            if (UserTable.Columns.Count < 10)
            {
                UserTable.Columns.Add("UserID");
                UserTable.Columns.Add("UserName");
                UserTable.Columns.Add("PerformedOn");
                UserTable.Columns.Add("Action");
                UserTable.Columns.Add("TableName");
                UserTable.Columns.Add("Date");
                UserTable.Columns.Add("Time");
                UserTable.Columns.Add("ActionType");
                UserTable.Columns.Add("ActionArabic");

            }
            for (int i = 0; i < dtUsrTrack.Rows.Count; i++)
            {
                DataRow dr;
                dr = UserTable.NewRow();
                dr["UserID"] = dtUsrTrack.Rows[i]["UserID"];
                dr["UserName"] = dtUsrTrack.Rows[i]["UserName"];
                dr["PerformedOn"] = dtUsrTrack.Rows[i]["PerformedOn"];
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    dr["Action"] = dtUsrTrack.Rows[i]["Action"];
                else if(Thread.CurrentThread.CurrentUICulture.Name=="ar-SA")
                    dr["Action"] = dtUsrTrack.Rows[i]["ActionArabic"];
                dr["TableName"] = dtUsrTrack.Rows[i]["TableName"];
                dr["Date"] = Convert.ToDateTime(dtUsrTrack.Rows[i]["Date"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]);
                dr["Time"] = (dtUsrTrack.Rows[i]["strTime"]);
                dr["ActionType"] = dtUsrTrack.Rows[i]["ActionType"];
                dr["ActionArabic"] = dtUsrTrack.Rows[i]["ActionArabic"];
                UserTable.Rows.Add(dr);
            }
            if (UserTable != null)
            {
                //summery.Refresh();
                rptView.HTable.Clear();
                rptView.Report_Table = UserTable;
                rptView.RptDoc = summery;
                rptView.IsReportFooter = false;
                rptView.HTable.Add("FromDate", ObjusrTrackBALClass.ObjEmployeeObject.FromDate);
                rptView.HTable.Add("ToDate", ObjusrTrackBALClass.ObjEmployeeObject.ToDate);
                rptView.HTable.Add("User", ObjusrTrackBALClass.ObjEmployeeObject.UserName);

                if (ObjusrTrackBALClass.ObjEmployeeObject.chkAllDate)
                {
                    rptView.HTable.Add("HideDate", true);
                }
                else
                {
                    rptView.HTable.Add("HideDate", false);
                }
                rptView.LoadEvent();
                rptView.ShowDialog();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "UserTracking", "", "Print the tracking User details", Convert.ToInt32(InvoiceAction.No));
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "User Tracking");
            }
            ObjusrTrackBALClass.ObjEmployeeObject.FPrint = false;
        }
    }
}
