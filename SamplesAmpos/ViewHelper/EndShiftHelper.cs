using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using System.Data;
using BumedianBM.CrystalReports;
using BumedianBM.ArabicView;
using CrystalDecisions.CrystalReports.Engine;
using CommonHelper;

namespace BumedianBM.ViewHelper
{
    class EndShiftHelper
    {
        private EndShiftBAL EndShifBALHelper;

        public EndShiftHelper()
        {
            EndShifBALHelper = new EndShiftBAL();
        }
        public DataTable GetUserData(string endTime)
        {
            DataTable dt = new DataTable();
            dt = EndShifBALHelper.GetShiftData(endTime);
            return dt;

        }

        public string[] SetLoginTime()
        {
            return EndShifBALHelper.SetLoginTime();
        }

        public int EndShiftReport(DataTable dtShift,List<string> saleTypeList)
        {
            Rpt_EndShiftReport summery = new Rpt_EndShiftReport();
            ReportsView rptView = new ReportsView();
          
            //summery.Refresh();
            // dtShift = new DataTable("EndShiftDetails");
            //string qry = "Select * from View_timeattendencelist ";
            DataTable dtAtten1 = new DataTable();
            dtAtten1 = EndShifBALHelper.GetReportValuesBAL();
            rptView.HTable.Clear();
            rptView.HTable.Add("TotalCash", saleTypeList[0]);
            rptView.HTable.Add("TotalCard", saleTypeList[1]);
            rptView.HTable.Add("TotalCheck", saleTypeList[2]);
            rptView.Report_Table = dtShift;
            rptView.RptDoc = summery;
            rptView.IsReportFooter = false;
            ReportDocument rpt = summery;
            Tables tbl = rpt.Database.Tables;
            rptView.Repnum = tbl;
            rptView.LoadEvent();
            rptView.ShowDialog();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "EndShift", "MTB_WORK_SHIFT_ATTENDANCE", "Print time end shift details", Convert.ToInt32(InvoiceAction.No));
            return 1;
        }
    }
}
