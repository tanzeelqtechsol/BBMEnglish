using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public enum NavButtonClicked
    {
        First,
        Next,
        Previous,
        Last,
        Index
    }

    public class NavCommonObject : EntityBase
    {
        private int itemIndex;

        public int ItemIndex
        {
            get { return itemIndex; }
            set { itemIndex = value; }
        }

        public int GetNavIndexIndex(NavButtonClicked navButtonClicked, int currentIndex, int listCount)
        {
            if (navButtonClicked == NavButtonClicked.Last)
            {
                currentIndex = listCount - 1;
            }
            else if (navButtonClicked == NavButtonClicked.First)
            {
                currentIndex = 0;
            }
            else if (navButtonClicked == NavButtonClicked.Next)
            {
                currentIndex++;
            }
            else if (navButtonClicked == NavButtonClicked.Previous)
            {
                currentIndex--;
            }
            return currentIndex;
        }
    }

    public class EmployeeObjectClass : NavCommonObject
    {
        #region String datatype property
        public string GroupName { get; set; }
        public string Remarks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassportNo { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Designation { get; set; }
        public string Notes { get; set; }
        public string PerformedBy { get; set; }
        
        
        
        public string HealthCertificate { get; set; }
        public string UserGroupName { get; set; }
        public string EmpName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PwdReminder { get; set; }
        public string EmpType { get; set; }
        
        public string Description { get; set; }
        public string SaveDescription { get; set; }
        public string SalaryType { get; set; }
        public string VariableName { get; set; }
        public string Message { get; set; }
        public string TempUserId { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }

        public string TotalHours { get; set; }
        public string DayofLatency { get; set; }
        public string DayofOverTime { get; set; }
        public string OverTimeTotalHours { get; set; }
        public string Date1 { get; set; }
        public string TimeStart1 { get; set; }
        public string TimeEnd1 { get; set; }
        public string TimeBreak1 { get; set; }
        public string OverTimeStart1 { get; set; }
        public string OverTimeEnd1 { get; set; }
        public string EmpWorkHrs { get; set; }
        public string WorkTimings { get; set; }
        public string OverTimings { get; set; }
        public string HolidayTimings { get; set; }

        public string LatencyHours { get; set; }
        public string LatencyMin { get; set; }
        public string HolidayOverTime { get; set; }
        public string TotalSaleText { get; set; }
        public string saltype { get; set; }
        public string Details { get; set; }
        public string TotalSalaryText { get; set; }
        public string OverTimeBreak1 { get; set; }
        public string Day { get; set; }
        public string Difference { get; set; }
        public string WorkingDifference { get; set; }
        public string DailyAvg { get; set; }
        public string ScreenName { get; set; }

        
        

        //public string Note { get; set; }

        #endregion

        #region Numeric datatype property
        public int EmployeeVariablesID { get; set; }
        public int UserId { get; set; }
        public int VariableID { get; set; }
        public int GroupID { get; set; }
        public int NoOfInstallment { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int Status { get; set; }
        
        public int EmployeeUserFlag { get; set; }
        
        public int SalaryId { get; set; }
        public int CalcType { get; set; }
        public int UserGrpId { get; set; }
        public int UserGrpType { get; set; }
        public int WeekEnd { get; set; }
        public int EmpId { get; set; }
        public int AmountCutOption { get; set; }
        public int UserGrpOption { get; set; }
        public int AlertId { get; set; }
        
        public int NoOfTimes { get; set; }
        public int AlertLoginFlag { get; set; }
        public int OptionID { get; set; }
        public int ScreenID { get; set; }
        public int DrawingFlag { get; set; }
        public int Notescheckedtype { get; set; }
        public int NotesforEmployee { get; set; }
        public int NotesforGroup { get; set; }
        public int EmployeeSelectedVaue { get; set; }
        public int GroupSelectedVaue { get; set; }
        public int WeekEndDayFlag { get; set; }
        public int Workstation { get; set; }
        public int InvoiceAction { get; set; }
        public int WorkingDays { get; set; }
        public int WorkedDays { get; set; }

        public int Suncount { get; set; }
        public int Moncount { get; set; }
        public int Tuescount { get; set; }
        public int Wedcount { get; set; }
        public int Thurscount { get; set; }
        public int Fricount { get; set; }
        public int Satcount { get; set; }
        public int MonthDays { get; set; }
        public int SaleId { get; set; }
        public int cmbPayEmpOf { get; set; }
        public int SalaryIds { get; set; }
        public int ExpensesID { get; set; }
        public int BrakeTimeFlag { get; set; }
        public int Breakflag { get; set; }
        public int SelectedFlag { get; set; }
        public int SelectedValue { get; set; }
        public int Sno { get; set; }
        public int TotalDays { get; set; }
        
        
        #endregion

        #region Datetime datatype property
        public DateTime EffectiveDate { get; set; }
        public DateTime StartMonthDeduction { get; set; }
        public DateTime StartWorkHour{ get; set; }
        public DateTime EndWorkHour{ get; set; }
        public DateTime dtFromDate{ get; set; }
        public DateTime dtToDate{ get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AlertDate { get; set; }
        public DateTime? NotesDate { get; set; }
        public DateTime DateNew { get; set; }
        public DateTime TimeStart { get; set; } //
        //public DateTime TimeBreak { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime OverTimeStart { get; set; }
        //public DateTime OverTimeBreak { get; set; }
        public DateTime OverTimeEnd { get; set; }
        public DateTime DTimeStart { get; set; } //
        public DateTime DTimeEnd { get; set; }//
        public DateTime DOverTimeStart { get; set; }
        public DateTime DOverTimeEnd { get; set; }
        public DateTime DTimeBreak { get; set; }
        public DateTime DOverTimeBreak { get; set; }//
        public DateTime Date { get; set; }
        public TimeSpan testdate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime PaidDate { get; set; }

        public TimeSpan TimeBreak { get; set; }
        public TimeSpan OverTimeBreak { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public String strDate { get; set; }
        
       
        
       
        
        #endregion

        #region Decimal datatype property
        public decimal VariableAmount { get; set; }
        public decimal MonthlyDeduction { get; set; }
        public decimal BasicSalary{ get; set; }
        public bool ShowEndTime { get; set; }
        public decimal PercSales{ get; set; }
        public decimal OverTimeSal{ get; set; }
        public decimal HolidaySal{ get; set; }
        public decimal TotalSales { get; set; }
        public decimal SalaryForPerDay { get; set; }
        public decimal SalaryForPerHour { get; set; }

        public decimal SalaryForWeek { get; set; }
        public decimal SalaryForPercent { get; set; }
        public decimal Netamount { get; set; }
        public decimal EmpSalary { get; set; }
        public decimal Average { get; set; }
        public decimal EmpOverSalary { get; set; }
        public decimal EmpHoliSalary { get; set; }
        public decimal DrawAmt { get; set; }

        public decimal Advance { get; set; }
        public decimal Punishment { get; set; }
        public decimal Neglect { get; set; }
        public decimal Reward { get; set; }
        public decimal Incentive { get; set; }
        public decimal Others { get; set; }
        public decimal LatencyAmt { get; set; }
        public decimal NetSalary { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountAbsence { get; set; }
        public decimal Value { get; set; }
        

        
        #endregion

        #region Boolean datatype property
        
        public bool Remove { get; set; }
        public bool UserToSystem { get; set; }
        public bool Flag { get; set; }
        
        public bool chkAllEmployee { get; set; }
        public bool Select { get; set; }
        public string DefaultScreenID { get; set; }

        #endregion

        #region Float
     
        #endregion


        public string PerformedOn { get; set; }

        public string Action { get; set; }

        public string TableName { get; set; }

        public DateTime Time { get; set; }

        public int ActionType { get; set; }

        public string ActionArabic { get; set; }

        public bool chkAllDate { get; set; }

        public int SelectedAction { get; set; }

        public bool DetailedReport { get; set; }

        public bool FPrint { get; set; }

        public string strTime { get; set; }

        public string ValidationString { get; set; }

        public string MessageTo { get; set; }


        public DateTime StartWorkHours { get; set; }

        public DateTime EndWorkHours { get; set; }

        public string SocialId { get; set; }

        public int CurrentUserID { get; set; }

        public string WorkStationName { get; set; }
    }
}
