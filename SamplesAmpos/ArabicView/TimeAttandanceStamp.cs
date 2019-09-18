using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System.Threading;
using System.Configuration;
using System.Globalization;

namespace BumedianBM.ArabicView
{
    public partial class Entry_Time_Attandance : Form, IDisposable
    {
        #region Variables
        TimeAttendanceStampHelper objTimeAttenStampHelp;
        List<EmployeeObjectClass> ObjWorktimeAttendance = new List<EmployeeObjectClass>();
        DateTime GStime;
        string buttonclick = "start";
        string WorkHRSchek = string.Empty;
        DateTime GetStartBrkTime;
        DateTime DGetStartBrkTime;
        string GetEndBrkTime;
        DateTime DGetEndBrkTime;
        public static int time = 0;
        public static int resultcount = 0;
        public static string strUserId = string.Empty;
        public static string strUsername = string.Empty;
        public static string strdate = string.Empty;
        public static string strTimestart = string.Empty;
        public static string strTimeBreak = string.Empty;
        public static string strTimeEnd = string.Empty;
        public static string strOTimeStart = string.Empty;
        public static string strOTimeBreak = string.Empty;
        public static string strOTimeEnd = string.Empty;
        public static string strTotalHours = string.Empty;
        public static string strOTTotalHours = string.Empty;
        public static DateTime DtimeBreak;
        public static DateTime DOvertimeBreak;
        public static DateTime DtimeStart;
        public static DateTime DtimeEnd;
        public static DateTime DOverTimeStart;
        public static DateTime DOverTimeEnd;
        //public static string strDOvertimeBreak = string.Empty;
        public static DateTime DateNew;
        public static int Brkflag = 0;
        public int WeekEnd = 0;
        public static bool IsEndTime = false;
        #endregion

        #region Constructor Part
        public Entry_Time_Attandance()
        {
            objTimeAttenStampHelp = new TimeAttendanceStampHelper();
            InitializeComponent();
            SetLanguage();

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "";
            culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
            Thread.CurrentThread.CurrentCulture = culture;



            setFont();
            if (IsEndTime)
            {
                this.Size = new Size(0, 0);
            }
        }
        #endregion

        #region Load
        private void Entry_Time_Attandance_Load(object sender, EventArgs e)
        {
            try
            {
               
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                LoadAttendanceList();
                if (IsEndTime)
                {
                    btnEndTime_Click(sender, e);
                    this.Close();
                }
                IsEndTime = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Attendance_Load");
            }
        }
        #endregion

        #region Private Methods

        #region Load Methods
        private void LoadAttendanceList()
        {
            GStime = DateTime.Now;
            timer1.Enabled = true;
            dtpDate.Value = DateTime.Now.Date;
            AttendanceTime.Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
            TimeSpan TsTo = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
            AttendanceTime.Value = Convert.ToDateTime(dtpDate.Value.Date + TsTo);

            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DateNew = dtpDate.Value;
            if (GeneralObjectClass.UserList != null)
            {
                cmbUserName.DisplayMember = "FirstName";
                cmbUserName.ValueMember = "UserId";
                cmbUserName.DataSource = GeneralObjectClass.UserList.FindAll(x => x.Status == 1);
                cmbUserName.SelectedIndex = -1;
                lblEntryHrs.Text = DateTime.Now.ToString("hh:mm tt");
                btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                btnBreakTime.Tag = "SBT";
            }
            FillTimeAttendanceList();
            cmbUserName.SelectedValue = GeneralFunction.LoginUserId;
            ButtonEnabled();
        }
        private void GetUserattendance(int datevaluepassed)
        {
            var result = ObjWorktimeAttendance;
            if (datevaluepassed == 0)
            {
                int UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                result = ObjWorktimeAttendance.FindAll(Uid => Uid.UserId == UserId);
            }
            if (datevaluepassed == 1)
            {
                int UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                DateTime dtime = Convert.ToDateTime(dtpDate.Value);

                result = ObjWorktimeAttendance.FindAll(Uid => (Uid.UserId == UserId) && (Uid.Date.ToShortDateString() == dtpDate.Value.ToShortDateString()));
            }
            if (result.Count == 1)
            {
                resultcount = 1;
                GStime = result[0].DTimeStart == DateTime.MinValue ? (Convert.ToDateTime(result[0].Date)).Date : result[0].DTimeStart;
                strUserId = result[0].UserId == 0 ? string.Empty : result[0].UserId.ToString();
                strUsername = result[0].UserName == null ? string.Empty : result[0].UserName.ToString();
                strdate = result[0].Date.ToString();
                //-----------------Time----------------------
                strTimestart = result[0].TimeStart.ToString();
                strTimeBreak = result[0].TimeBreak.ToString();
                strTimeEnd = result[0].TimeEnd.ToString();
                //-----------------Over Time----------------------
                strOTimeStart = result[0].OverTimeStart.ToString();
                strOTimeBreak = result[0].OverTimeBreak.ToString();
                strOTimeEnd = result[0].OverTimeEnd.ToString();

                strTotalHours = result[0].TotalHours.ToString();
                strOTTotalHours = result[0].OverTimeTotalHours.ToString();

                DtimeBreak = result[0].DTimeBreak;
                DOvertimeBreak = result[0].DOverTimeBreak;
                DtimeStart = result[0].DTimeStart;
                DtimeEnd = result[0].DTimeEnd;
                DOverTimeStart = result[0].DOverTimeStart;
                DOverTimeEnd = result[0].DOverTimeEnd;
                DateNew = result[0].Date;
                Brkflag = Convert.ToInt32(result[0].Breakflag.ToString());

            }
            else
            {
                resultcount = 0;
            }
        }
        private void ButtonEnabled()
        {
            //DateTime t = DateTime.MinValue;
            //DateTime s = DateTime.MaxValue;
            DateTime dtime = Convert.ToDateTime(dtpDate.Value);
            try
            {
                if (ObjWorktimeAttendance.Count != 0)
                {
                    if (CheckValidation() == true)
                    {
                        string strExpr;
                        GetUserattendance(0);
                        //(MODIFIED FOR EMPLOY LOGOUT AFTER 11.59 PM OF tHAT DAY) strExpr = ("MTB_USER_ID" + " ='" + Cmb_UserName.SelectedValue.ToString() + "' and " + "MTB_DATE " + "='" + dtime.ToString("dd/MM/yyyy") + "'");
                        if (resultcount == 1)
                        {

                            if (strTimestart != DateTime.MinValue.ToString())
                            {
                                btnStartTime.Enabled = false; btnBreakTime.Enabled = true; btnEndTime.Enabled = true;
                                if (strTimeBreak == "00:00:00")
                                {
                                    btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                                    btnBreakTime.Tag = "SBT";
                                }
                            }
                            if (strOTimeStart == DateTime.MinValue.ToString() & strTimestart == DateTime.MinValue.ToString())
                            {
                                btnStartTime.Enabled = true;
                                btnBreakTime.Enabled = true;
                                btnEndTime.Enabled = true;
                            }
                            if ((strOTimeBreak == "00:00:00" & strTimeBreak == "00:00:00") & (strOTimeEnd == DateTime.MinValue.ToString() & strTimeEnd == DateTime.MinValue.ToString()))
                            {
                                btnStartTime.Enabled = false;
                                btnBreakTime.Enabled = true;
                                btnEndTime.Enabled = true;
                            }
                            if ((strOTimeEnd == DateTime.MinValue.ToString() & strTimeEnd == DateTime.MinValue.ToString()) & (strTimeBreak != "00:00:00" || strOTimeBreak != "00:00:00"))
                            {
                                btnStartTime.Enabled = false;
                                btnBreakTime.Enabled = false;
                                btnEndTime.Enabled = true;
                            }
                            if ((strTimestart != DateTime.MinValue.ToString() & strTimeEnd != DateTime.MinValue.ToString()) & (strOTimeStart == DateTime.MinValue.ToString() & strOTimeEnd == DateTime.MinValue.ToString()))
                            {
                                btnStartTime.Enabled = true;
                                btnBreakTime.Enabled = true;
                                btnEndTime.Enabled = true;
                            }
                            if (strTimeBreak != "00:00:00" & strTimeEnd == DateTime.MinValue.ToString())
                            {
                                string sd = strTimeBreak.Substring(6, (strTimeBreak.Length - 6));
                                if (Brkflag == Convert.ToInt32(BreakTimeFlag.StartBreak))
                                {
                                    btnStartTime.Enabled = false;
                                    btnBreakTime.Enabled = true;
                                    btnEndTime.Enabled = true;
                                    btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                    btnBreakTime.Tag = "EBT";
                                    btnEndTime.Enabled = false;
                                }
                            }
                            if (strOTimeBreak != "00:00:00" & strOTimeEnd == DateTime.MinValue.ToString())
                            {
                                if (Brkflag == Convert.ToInt32(BreakTimeFlag.OTStartBreak))
                                {
                                    btnStartTime.Enabled = false;
                                    btnBreakTime.Enabled = true;
                                    btnEndTime.Enabled = true;
                                    btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                    btnBreakTime.Tag = "EBT";
                                    btnEndTime.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            btnStartTime.Enabled = true;
                            btnBreakTime.Enabled = true;
                            btnEndTime.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message,this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Btn_BoxF9_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private bool CheckValidation()
        {
            if (cmbUserName.SelectedIndex == -1)
            {
                GeneralFunction.Information("EmptyUser", "ETA");
                return false;
            }
            return true;
        }

        private void FillTimeAttendanceList()
        {
            dgrTimeAttandance.DataSource = null;
            ObjWorktimeAttendance = objTimeAttenStampHelp.GetWorkTimeAttedanceHelper();
            dgrTimeAttandance.AutoGenerateColumns = false;
            dgrTimeAttandance.DataSource = ObjWorktimeAttendance;
            dgrTimeAttandance.Refresh();
        }
        #endregion

        #region Set Language Methods
        public void SetLanguage()
        {
            try
            {
                lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
                lblEntryHrs.Text = Additional_Barcode.GetValueByResourceKey("EntryHrs");
                lblTime.Text = Additional_Barcode.GetValueByResourceKey("Time");
                lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
                btnAttandanceReport.Text = Additional_Barcode.GetValueByResourceKey("AttReport");
                btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("BT");
                btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
                btnEndTime.Text = Additional_Barcode.GetValueByResourceKey("ET");
                btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
                btnStartTime.Text = Additional_Barcode.GetValueByResourceKey("ST");
                this.Text = Additional_Barcode.GetValueByResourceKey("ETA");

                dgrTimeAttandance.Columns["User_ID"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
                dgrTimeAttandance.Columns["AttendUserName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserName");
                dgrTimeAttandance.Columns["AttendTimeStart"].HeaderText = Additional_Barcode.GetValueByResourceKey("ST");
                dgrTimeAttandance.Columns["AttendTimeBreak"].HeaderText = Additional_Barcode.GetValueByResourceKey("BT");
                dgrTimeAttandance.Columns["AttendTimeEnd"].HeaderText = Additional_Barcode.GetValueByResourceKey("ET");
                dgrTimeAttandance.Columns["AttendOverTimeStart"].HeaderText = Additional_Barcode.GetValueByResourceKey("OverTimeStart");
                dgrTimeAttandance.Columns["AttendOverTimeBreak"].HeaderText = Additional_Barcode.GetValueByResourceKey("OverTimeBreak");
                dgrTimeAttandance.Columns["AttendOverTimeEnd"].HeaderText = Additional_Barcode.GetValueByResourceKey("OverTimeEnd");
                dgrTimeAttandance.Columns["AttendDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Set_Language");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        private void btnStartTime_Click(object sender, EventArgs e)
        {
            try
            {
                //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                TimeSpan TsTo = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
                AttendanceTime.Value = Convert.ToDateTime(dtpDate.Value.Date + TsTo);
                Get_CalculateLatencyAndOverTime();
                if (WorkHRSchek == "LAT")
                {
                    Save_StartWorkTime();
                }
                else if (WorkHRSchek == "OVR")
                {
                    Save_StartWorkTime();
                }
                else if (WorkHRSchek == "ABEOVR")
                {
                    Save_Over_StartWorkTime();
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "btnStartTime_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public bool StampEndShift()
        {
            try
            {
                // AttendanceTime.Value = DateTime.Now;
                //dtpDate.Value = DateTime.Now;
                Entry_Time_Attandance_Load(null, null);
                //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                TimeSpan TsTo = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
                AttendanceTime.Value = Convert.ToDateTime(dtpDate.Value.Date + TsTo);
                buttonclick = "end";
                Get_CalculateLatencyAndOverTime();

                if (WorkHRSchek == "LAT")
                {
                    Save_EndWorkTime();
                }
                else if (WorkHRSchek == "OVR")
                {
                    Save_EndWorkTime();
                }
                else if (WorkHRSchek == "ABEOVR")
                {
                    Save_Over_EndWorkTime();
                }

                buttonclick = "start";

                return true;
            }

            catch (Exception ex)
            {
                
                //GeneralFunction.ErrInfo(ex.Message,this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "btnEndTime_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return false;
            }
            return false;
        }


        private void Save_Over_StartWorkTime()
        {
            try
            {
                
                if (CheckValidation() == true)
                {
                    string strExpr, srtTime = "0";
                    GetUserattendance(1);
                    if (resultcount != 0)
                    {
                        if (strTimestart == "")
                        {
                            if (WeekEnd == (int)dtpDate.Value.DayOfWeek + 1) //---holiday of employee time
                            {
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.CurrentUserID = GeneralFunction.UserId;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WorkStationName = GeneralFunction.workstationName;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                                //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                                //{
                                //    DateTime time = Convert.ToDateTime(DateTime.Now);
                                //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                                //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                                //    DateTime Gettime = Convert.ToDateTime(ggg);
                                //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                                //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                                //}
                                //else
                                //{
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                                // }
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WeekEndDayFlag = Convert.ToInt32(CommonHelper.WeekendDay.Holi);

                                if (objTimeAttenStampHelp.Save_EmpWorkStartTime() > 0)
                                {
                                    FillTimeAttendanceList(); btnStartTime.Enabled = false;
                                }
                                else
                                {
                                    GeneralFunction.Information("CheckStartTime", "ETA");
                                }
                            }

                            else
                            {
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;

                                //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                                //{
                                //    DateTime time = Convert.ToDateTime(DateTime.Now);
                                //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                                //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                                //    DateTime Gettime = Convert.ToDateTime(ggg);
                                //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                                //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                                //}
                                //else
                                //{
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                                //}
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WeekEndDayFlag = Convert.ToInt32(CommonHelper.WeekendDay.Work);

                                if (objTimeAttenStampHelp.Save_OverTime_EmpWorkStartTime() > 0)
                                { FillTimeAttendanceList(); btnStartTime.Enabled = false; }
                                else
                                {
                                    GeneralFunction.Information("CheckStartTime", "ETA");
                                }
                            }
                        }
                        else
                        {
                            if (strOTimeStart == DateTime.MinValue.ToString())
                            {

                                if (GeneralFunction.Question("StartNewSession", "ETA") == DialogResult.Yes)
                                {
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                                    //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                                    //{
                                    //    DateTime time = Convert.ToDateTime(DateTime.Now);
                                    //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                                    //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                                    //    DateTime Gettime = Convert.ToDateTime(ggg);
                                    //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                                    //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                                    //}
                                    //else
                                    //{
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                                    //}

                                    if (objTimeAttenStampHelp.Save_OverTime_EmpWorkStartTime() > 0)
                                    {
                                        FillTimeAttendanceList();
                                        btnStartTime.Enabled = false;
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("CheckStartTime", "ETA");
                                    }

                                }
                                // else { }
                            }
                            else
                            {
                                if ((strOTimeStart != DateTime.MinValue.ToString()))
                                {
                                    GeneralFunction.Information("CantUpdateOverTime", "ETA");
                                }
                            }

                        }
                    }
                    else
                    {
                        if (GeneralFunction.Question("LikeStartNewSession", "ETA") == DialogResult.Yes)
                        {
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue);
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.CurrentUserID = GeneralFunction.UserId;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WorkStationName = GeneralFunction.workstationName;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                            //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                            //{
                            //    DateTime time = Convert.ToDateTime(DateTime.Now);
                            //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                            //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                            //    DateTime Gettime = Convert.ToDateTime(ggg);
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                            //}
                            //else
                            //{
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                            //   }
                            if (objTimeAttenStampHelp.Save_OverTime_EmpWorkStartTime() > 0)
                            { FillTimeAttendanceList(); btnStartTime.Enabled = false; }
                            else
                            {
                                GeneralFunction.Information("CheckStartTime", "ETA");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Save_StartWorkTime()
        {
            try
            {
                if (CheckValidation() == true)
                {
                    GetUserattendance(1);
                    if (resultcount == 0)
                    {
                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.CurrentUserID = GeneralFunction.UserId;
                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WorkStationName = GeneralFunction.workstationName;
                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                        if (WeekEnd == (int)dtpDate.Value.DayOfWeek + 1) //---holiday of employee time
                        {
                            //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                            //{
                            //    DateTime time = Convert.ToDateTime(DateTime.Now);
                            //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                            //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                            //    DateTime Gettime = Convert.ToDateTime(ggg);
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                            //}
                            //else
                            //{
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                            //  }

                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WeekEndDayFlag = Convert.ToInt32(CommonHelper.WeekendDay.Holi);
                            if (objTimeAttenStampHelp.Save_EmpWorkStartTime() > 0)
                            { FillTimeAttendanceList(); btnStartTime.Enabled = false; }
                            else
                            {
                                GeneralFunction.Information("CheckStartTime", "ETA");
                            }
                        }

                        else
                        {
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DateNew = dtpDate.Value.Date;
                            //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                            //{
                            //    DateTime time = Convert.ToDateTime(DateTime.Now);
                            //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                            //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                            //    DateTime Gettime = Convert.ToDateTime(ggg);
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = Convert.ToDateTime(Gettime.ToShortTimeString());
                            //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = Gettime;
                            //}
                            //else
                            //{
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeStart = AttendanceTime.Value;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeStart = AttendanceTime.Value;
                            // }
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.WeekEndDayFlag = Convert.ToInt32(CommonHelper.WeekendDay.Work);

                            if (objTimeAttenStampHelp.Save_EmpWorkStartTime() > 0)
                            { FillTimeAttendanceList(); btnStartTime.Enabled = false; }
                            else
                            {
                                GeneralFunction.Information("CheckStartTime", "ETA");
                            }

                        }
                    }
                    else
                    {
                        Save_Over_StartWorkTime();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Get_CalculateLatencyAndOverTime()
        {

            try
            {
                string getval = GeneralFunction.WeekEndDay;
                DateTime StartTime = Convert.ToDateTime(GeneralFunction.StartWorkHrs);
                DateTime EndTime = GeneralFunction.EndWorkHrs;

                DateTime Stime, Etime, CurrentTime;
                double StimeTotalMin, EtimeTotalMin, CurrentTime1;
                DateTime Stime2, Etime2, CurrentTime2;
                TimeSpan TStime1, TEtime1, TGettime1;
                if (Convert.ToDateTime(StartTime) > Convert.ToDateTime(EndTime))
                {
                    EndTime = Convert.ToDateTime(EndTime).AddDays(1);
                }

                Stime = Convert.ToDateTime(StartTime);
                Etime = Convert.ToDateTime(EndTime);
                //*************This is commented due to FlagCountSystemStarupMinutes comes under Employee tab in option but it is removed as per client requirement.

                //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
                //{
                //    DateTime time = Convert.ToDateTime(AttendanceTime.Value.ToString());
                //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
                //    string ggg = Convert.ToString(span.Hours + ":" + span.Minutes + ":" + span.Seconds);
                //    DateTime ptl = Convert.ToDateTime(ggg);
                //    CurrentTime = Convert.ToDateTime(ptl.ToShortTimeString());
                //}
                //else
                //{
                CurrentTime = Convert.ToDateTime(AttendanceTime.Value);
                // }
                //*************

                string ssss = Convert.ToString(Stime.ToString("HH:mm tt"));
                string eeee = Convert.ToString(Etime.ToString("HH:mm tt"));
                string gggg = Convert.ToString(CurrentTime.ToString("HH:mm tt"));

                int daydiff = ((Convert.ToDateTime(GStime.Date) - Convert.ToDateTime(Stime.Date)).Days);
                Stime2 = Stime.AddDays(daydiff);
                Etime2 = Etime.AddDays(daydiff);
                CurrentTime2 = Convert.ToDateTime(gggg);

                StimeTotalMin = Convert.ToDouble(Stime.TimeOfDay.TotalMinutes);
                EtimeTotalMin = Convert.ToDouble(Etime.TimeOfDay.TotalMinutes);
                CurrentTime1 = Convert.ToDouble(CurrentTime.TimeOfDay.TotalMinutes);

                objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = string.Empty;
                objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = string.Empty;


                if ((GStime.Date.ToShortDateString() != DateTime.Now.Date.ToShortDateString()) & (buttonclick == "end"))
                {
                    int days = (Convert.ToDateTime(GStime.Date) - Convert.ToDateTime(Stime.Date)).Days;
                    Stime2 = Stime.AddDays(days); //Stime.AddDays(((TimeSpan)(GStime.Subtract(Stime))).Days);
                    if (Stime > Etime)
                    {
                        Etime2 = Etime.AddDays(days + 1);
                    }
                    else if (Etime.Date.ToShortDateString() != Etime2.Date.ToShortDateString())
                    {
                        Etime2 = Etime.AddDays(days);
                    }

                }
                else if (Stime2 > Etime2)
                {
                    int days = (Convert.ToDateTime(GStime.Date) - Convert.ToDateTime(Stime.Date)).Days;
                    Etime2 = Etime.AddDays(days);
                }
                if ((Etime2.Date.ToShortDateString() != GStime.Date.ToShortDateString()) & buttonclick == "end")
                {
                    WorkHRSchek = "OVR";
                    TimeSpan datediffovertime = CurrentTime2.Subtract(Etime2);
                    string aaa = (datediffovertime.Days * 24 + datediffovertime.Hours) + ":" + datediffovertime.Minutes;
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = string.Empty;
                    if (aaa.Contains("-"))
                        aaa = "";
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = aaa;
                }
                else if (Stime2 >= CurrentTime2)//----overTime
                {
                    WorkHRSchek = "OVR";
                    string aaa = Stime2.Subtract(CurrentTime2).ToString();
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = "";
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = aaa;

                }
                ////else if (Stime1 < Gettime1 & Etime1 > Gettime1)  //----latency0
                else if (Stime2 < CurrentTime2 & Etime2 > CurrentTime2)  //----latency
                {
                    string aaa = CurrentTime2.Subtract(Stime2).ToString();
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = aaa;
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = "";
                    WorkHRSchek = "LAT";
                }

               // else if (Gettime1 >= Etime1)
                else if (CurrentTime2 >= Etime2)
                {
                    WorkHRSchek = "OVR";
                    string aaa = CurrentTime2.Subtract(Etime2).ToString();
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = "";
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = ((CurrentTime2.Subtract(Etime2)).Days * 24 + (CurrentTime2.Subtract(Etime2)).Hours) + ":" + (CurrentTime2.Subtract(Etime2)).Minutes;
                }

                // if (Gettime1 > Stime1 & Gettime1 > Etime1)  //----latency
                if ((CurrentTime2 > Stime2 & CurrentTime2 > Etime2) & buttonclick != "end")  //----latency
                {
                    string aaa = CurrentTime2.Subtract(Stime2).ToString();
                    // gg string bbb = Stime2.Subtract(Gettime2).ToString();
                    string bbb = CurrentTime2.Subtract(Etime2).ToString();
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofLatency = aaa;
                    objTimeAttenStampHelp.ObjTimeAttendStampBAL.ObjEmployeeObject.DayofOverTime = bbb;
                    WorkHRSchek = "ABEOVR";
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        private void Cmb_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonEnabled();
        }

        private void btnBreakTime_Click(object sender, EventArgs e)
        {
            DateTime GetSTime, GetETime;
            TimeSpan GetTotTime;
            GetSTime = Convert.ToDateTime(GetStartBrkTime);
            GetSTime = DGetStartBrkTime;
            //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
            TimeSpan TsTo = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
            AttendanceTime.Value = Convert.ToDateTime(dtpDate.Value.Date + TsTo);

            try
            {
                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                if (btnBreakTime.Tag == "SBT")
                {
                    DataTable dt = new DataTable();
                    if (CheckValidation() == true)
                    {
                        GetUserattendance(1);
                        if (resultcount == 1)
                        {
                            if (strOTimeStart == DateTime.MinValue.ToString())
                            {
                                if ((strTimestart == DateTime.MinValue.ToString()))
                                {
                                    GeneralFunction.Information("EmptyStartTime", "ETA");
                                }
                                else
                                {
                                    GetStartBrkTime = AttendanceTime.Value;
                                    DGetStartBrkTime = Convert.ToDateTime(AttendanceTime.Value);
                                    if ((strTimeBreak == "00:00:00"))
                                    {
                                        if ((strTimeEnd == DateTime.MinValue.ToString()))
                                        {
                                            if (AttendanceTime.Value > DtimeStart)
                                            {
                                                TimeSpan TStimebreak = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = TStimebreak;
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = AttendanceTime.Value;
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.StartBreak);

                                                if (objTimeAttenStampHelp.Save_EmpWorkBrakeTime() > 0)
                                                {
                                                    FillTimeAttendanceList(); btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                                    btnBreakTime.Tag = "EBT";
                                                    btnEndTime.Enabled = false;
                                                    btnStartTime.Enabled = false;

                                                }
                                                else
                                                {
                                                    GeneralFunction.Information("CheckBreakTime", "ETA");
                                                    cmbUserName.Focus();
                                                    //   GeneralFunction.BrakeBtn = 0;
                                                }
                                            }
                                            else
                                            {
                                                GeneralFunction.Information("CheckBreakTime", "ETA");
                                                cmbUserName.Focus();
                                                //   GeneralFunction.BrakeBtn = 0;
                                            }
                                        }
                                        else
                                        {
                                            GeneralFunction.Information("ExistsBreakTime", "ETA");
                                            btnBreakTime.Enabled = false;
                                            btnStartTime.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        if (Brkflag == Convert.ToInt32(BreakTimeFlag.StartBreak))
                                        {
                                            if (AttendanceTime.Value > DtimeBreak)
                                            {
                                                GetSTime = DtimeBreak;
                                                GetETime = Convert.ToDateTime(AttendanceTime.Value);
                                                GetTotTime = (GetETime - GetSTime);
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = GetTotTime;
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = AttendanceTime.Value;
                                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.EndBreak);
                                                if (objTimeAttenStampHelp.Save_EmpWorkBrakeTime() > 0)
                                                { FillTimeAttendanceList(); btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime"); btnBreakTime.Tag = "SBT"; }
                                                else
                                                {
                                                    GeneralFunction.Information("CheckBreakTime", "ETA");
                                                    cmbUserName.Focus();
                                                    //GeneralFunction.BrakeBtn = 0; 
                                                }
                                            }
                                        }
                                        else
                                        {
                                            GeneralFunction.Information("ExistsBreakTime", "ETA");
                                            btnBreakTime.Enabled = false;
                                            btnStartTime.Enabled = false;
                                        }
                                    }
                                }
                            }

                            else
                            {
                                if ((strOTimeBreak == "00:00:00"))
                                {
                                    if (AttendanceTime.Value > DOverTimeStart)
                                    {
                                        TimeSpan TStimebreak = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
                                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = TStimebreak;
                                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = AttendanceTime.Value;
                                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.OTStartBreak);
                                        if (objTimeAttenStampHelp.Save_OverTime_EmpWorkBrakeTime() > 0)
                                        {
                                            FillTimeAttendanceList();
                                            btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                            btnBreakTime.Tag = "EBT";
                                            btnEndTime.Enabled = false;
                                            btnStartTime.Enabled = false;
                                        }
                                        else
                                        {
                                            GeneralFunction.Information("CheckBreakTime", "ETA"); cmbUserName.Focus();// GeneralFunction.BrakeBtn = 0; 
                                        }
                                    }
                                }
                                else
                                {
                                    if (Brkflag == Convert.ToInt32(BreakTimeFlag.OTStartBreak))
                                    {
                                        if (AttendanceTime.Value > DOvertimeBreak)
                                        {
                                            GetSTime = DOvertimeBreak;
                                            GetETime = Convert.ToDateTime(AttendanceTime.Value);
                                            GetTotTime = (GetETime - GetSTime);
                                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = GetTotTime;
                                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = dtpDate.Value;
                                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.OTEndBreak);
                                            if (objTimeAttenStampHelp.Save_OverTime_EmpWorkBrakeTime() > 0)
                                            {
                                                FillTimeAttendanceList();
                                                btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                                                btnBreakTime.Tag = "SBT";
                                            }
                                            else
                                            {
                                                GeneralFunction.Information("CheckBreakTime", "ETA"); cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                            }
                                        }
                                        else
                                        {
                                            GeneralFunction.Information("CheckBreakTime", "ETA"); cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                        }
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("ExistsOverTimeofBreakTime", "ETA");
                                        btnBreakTime.Enabled = false;
                                        btnStartTime.Enabled = false;
                                    }
                                }


                            }
                        }
                        else
                        {
                            GeneralFunction.Information("StartTimeEmpty", "ETA");
                        }
                    }
                }
                else     //===========Button Text = End Brake Time
                {
                    GetEndBrkTime = AttendanceTime.Text;
                    // DGetEndBrkTime = DateTime.Now;
                    DGetEndBrkTime = AttendanceTime.Value;
                    GetUserattendance(1);
                    if (resultcount == 1)
                    {
                        if (strOTimeBreak == "00:00:00")
                        {
                            if (Brkflag == Convert.ToInt32(BreakTimeFlag.StartBreak))
                            {
                                if (AttendanceTime.Value > DtimeBreak)
                                {
                                    GetSTime = DtimeBreak;
                                    //string endTime = DateTime.Now;
                                    GetETime = AttendanceTime.Value;
                                    GetTotTime = (GetETime - GetSTime);

                                    //DateTime time = Convert.ToDateTime(DateTime.Now).Date;
                                    //  TimeSpan span = new TimeSpan(GetTotTime.Hours,GetTotTime.Minutes,GetTotTime.Seconds);
                                    // string ggg = Convert.ToString(GetTotTime.Hours + ":" + GetTotTime.Minutes + ":" + GetTotTime.Seconds);
                                    // DateTime Gettime = Convert.ToDateTime(ggg);

                                    //   objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak =Convert.ToDateTime(span.to);

                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = GetTotTime;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = AttendanceTime.Value;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.EndBreak);
                                    if (objTimeAttenStampHelp.Save_EmpWorkBrakeTime() > 0)
                                    {
                                        FillTimeAttendanceList();
                                        btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                                        btnBreakTime.Tag = "SBT";
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("CheckBreakTime", "ETA"); cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                    }
                                }
                                else
                                {
                                    GeneralFunction.Information("CheckBreakTime", "ETA"); cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                }
                            }
                        }
                        else
                        {
                            if (Brkflag == Convert.ToInt32(BreakTimeFlag.OTStartBreak))
                            {
                                if (AttendanceTime.Value > DOvertimeBreak)
                                {
                                    GetSTime = DOvertimeBreak;
                                    //GetETime = DateTime.Now;
                                    GetETime = AttendanceTime.Value;
                                    GetTotTime = (GetETime - GetSTime);

                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeBreak = GetTotTime;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeBreak = AttendanceTime.Value;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.BrakeTimeFlag = Convert.ToInt32(BreakTimeFlag.OTEndBreak);
                                    if (objTimeAttenStampHelp.Save_OverTime_EmpWorkBrakeTime() > 0)
                                    {
                                        FillTimeAttendanceList();
                                        btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                                        btnBreakTime.Tag = "SBT";
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("CheckBreakTime", "ETA");
                                        cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                    }
                                }
                                else
                                {
                                    GeneralFunction.Information("CheckBreakTime", "ETA");
                                    cmbUserName.Focus(); //GeneralFunction.BrakeBtn = 0; 
                                }
                            }
                            else
                            {
                                GeneralFunction.Information("ExistsOverTimeofBreakTime", "ETA");
                                btnBreakTime.Enabled = false;
                                btnStartTime.Enabled = false;
                            }
                        }

                    }

                    btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                    btnBreakTime.Tag = "SBT";
                    btnBreakTime.Enabled = false;
                    btnEndTime.Enabled = true;
                    btnStartTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message,this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Btn_BrakeTime_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnEndTime_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.Question("EndShiftConfirm", "ETA") == DialogResult.Yes)
                {

                    //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                    TimeSpan TsTo = new TimeSpan(AttendanceTime.Value.Hour, AttendanceTime.Value.Minute, AttendanceTime.Value.Second);
                    AttendanceTime.Value = Convert.ToDateTime(dtpDate.Value.Date + TsTo);
                    buttonclick = "end";
                    Get_CalculateLatencyAndOverTime();

                    if (WorkHRSchek == "LAT")
                    {
                        Save_EndWorkTime();
                    }
                    else if (WorkHRSchek == "OVR")
                    {
                        Save_EndWorkTime();
                    }
                    else if (WorkHRSchek == "ABEOVR")
                    {
                        Save_Over_EndWorkTime();
                    }

                    buttonclick = "start";
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message,this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "btnEndTime_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Save_Over_EndWorkTime()
        {
            try
            {
                if (CheckValidation() == true)
                {
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId = objTimeAttenStampHelp.UserGroupID();
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                    GetUserattendance(1);
                    if (resultcount == 1)
                    {
                        if (strOTimeStart != DateTime.MinValue.ToString())
                        {
                            if ((strOTimeStart == DateTime.MinValue.ToString()))
                            {
                                GeneralFunction.Information("EmptyOverTime", "ETA");
                            }
                            else
                            {
                                if (strOTimeStart != DateTime.MinValue.ToString() & strOTimeEnd == DateTime.MinValue.ToString())
                                {
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = AttendanceTime.Value;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = AttendanceTime.Value;
                                    if (objTimeAttenStampHelp.Save_OverTime_EmpWorkEndTime() > 0)
                                    {
                                        FillTimeAttendanceList(); ButtonEnabled(); btnBreakTime.Enabled = true; btnStartTime.Enabled = true; GeneralFunction.Information("ShiftEndMsg", "ETA");
                                        if (objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId != 0)
                                        { GeneralFunction.isApplnRestart = true; Application.Restart(); }
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("CheckEndTime", "ETA"); cmbUserName.Focus();
                                    }
                                }
                                else
                                {
                                    GeneralFunction.Information("CantChageEndTime", "ETA"); cmbUserName.Focus();
                                }


                            } //-------------------
                        }
                        else
                        {
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = AttendanceTime.Value;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = AttendanceTime.Value;
                            objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DayofLatency = "";
                            if (objTimeAttenStampHelp.Save_EmpWorkEndTime() > 0)
                            { FillTimeAttendanceList(); ButtonEnabled(); btnBreakTime.Enabled = true; btnStartTime.Enabled = true; }
                            else
                            {
                                GeneralFunction.Information("CheckEndTime", "ETA"); cmbUserName.Focus();
                            }

                        }
                    }
                }
                else
                {
                    GeneralFunction.Information("EmptyStartTime", "ETA"); cmbUserName.Focus();
                }
            }

            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
                //GeneralFunction.ErrInfo(ex.Message,this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Save_Over_EndWorkTime");
            }
        }

        private void Save_EndWorkTime()
        {
            try
            {
                if (CheckValidation() == true)
                {
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId = objTimeAttenStampHelp.UserGroupID();
                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.Date = dtpDate.Value;
                    GetUserattendance(0);
                    if (resultcount == 1)
                    {
                        objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DateNew = DateNew;
                        if (strOTimeStart == DateTime.MinValue.ToString())
                        {
                            if ((strTimestart == DateTime.MinValue.ToString()))
                            {
                                GeneralFunction.Information("EmptyStartTime", "ETA");
                            }
                            else 
                                //if ((strTimeEnd == DateTime.MinValue.ToString() & strOTimeStart == DateTime.MinValue.ToString()))
                            {
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = AttendanceTime.Value;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = AttendanceTime.Value;
                                if (objTimeAttenStampHelp.Save_EmpWorkEndTime() > 0)
                                {
                                    FillTimeAttendanceList(); ButtonEnabled(); btnBreakTime.Enabled = true; btnStartTime.Enabled = true; GeneralFunction.Information("ShiftEndMsg", "ETA");
                                    if (objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId != 0)
                                    { GeneralFunction.isApplnRestart = true; Application.Restart(); }
                                }
                                else
                                {
                                    GeneralFunction.Information("CheckEndTime", "ETA"); cmbUserName.Focus();
                                }
                            }
                        }
                        else
                        {
                            if ((strTimeEnd == DateTime.MinValue.ToString() & strOTimeStart == DateTime.MinValue.ToString()))
                            {
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = AttendanceTime.Value;
                                objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = AttendanceTime.Value;
                                if (objTimeAttenStampHelp.Save_EmpWorkEndTime() > 0)
                                { FillTimeAttendanceList(); ButtonEnabled(); btnBreakTime.Enabled = true; btnStartTime.Enabled = true; GeneralFunction.Information("ShiftEndMsg", "ETA");
                                    if (objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId != 0)
                                    { GeneralFunction.isApplnRestart = true; Application.Restart(); }
                                }
                                else
                                {
                                    GeneralFunction.Information("CheckEndTime", "ETA"); cmbUserName.Focus();
                                }

                            }
                            else
                            {
                                if (strOTimeStart != DateTime.MinValue.ToString() & strOTimeEnd == DateTime.MinValue.ToString())
                                {
                                    //if (time > 0)
                                    //{
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = AttendanceTime.Value;
                                    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = AttendanceTime.Value;
                                    //}
                                    //else
                                    //{
                                    //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.TimeEnd = Convert.ToDateTime(DateTime.Now);
                                    //    objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.DTimeEnd = Convert.ToDateTime(DateTime.Now);
                                    //}
                                    if (objTimeAttenStampHelp.Save_OverTime_EmpWorkEndTime() > 0)
                                    {
                                        FillTimeAttendanceList();
                                        ButtonEnabled();
                                        btnBreakTime.Enabled = true;
                                        btnStartTime.Enabled = true;
                                        GeneralFunction.Information("ShiftEndMsg", "ETA");
                                        if (objTimeAttenStampHelp.ObjTimeAttendStamp.ObjEmployeeObject.UserGrpId != 0)
                                        {
                                            GeneralFunction.isApplnRestart = true; Application.Restart();
                                        }
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("CheckEndTime", "ETA"); cmbUserName.Focus();
                                    }
                                }
                                else
                                {
                                    GeneralFunction.Information("CantChangeEndTime", "ETA"); cmbUserName.Focus();
                                }

                            }
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("EmptyStartTime", "ETA");
                        cmbUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "Save_EndWorkTime");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            this.Close();
        }

        private void btnAttandanceReport_Click(object sender, EventArgs e)
        {
            Time_Attandance_Sheet AttenSheet = new Time_Attandance_Sheet();
            AttenSheet.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAtten = new DataTable("Attendancelist");
                //DT = CommonHelper.ConvertionHelper.ConvertToDataTable<ItemCardObjectClass>(ObjBarcodeLogo);
                dtAtten = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>((List<EmployeeObjectClass>)dgrTimeAttandance.DataSource);
                //dtAtten = (DataTable)dgrTimeAttandance.DataSource;
                if (dtAtten != null)
                {
                    objTimeAttenStampHelp.AttendanceReport(dtAtten);
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "btnPrint_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dtime = Convert.ToDateTime(DateTime.Now);
           // string str = Convert.ToString(dtime);
            dtpDate.Value = dtime;
            AttendanceTime.Value = dtime;
        }

        #region Events

        #endregion

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                //List<Control> controls = new List<Control>();
                //controls = (from Control ctl in this.Controls select ctl).ToList();
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is GroupBox)
                        ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control lbl in panel1.Controls)
                {
                    if (lbl is Button || lbl is Label || lbl is GroupBox)
                        lbl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control lbl in panel2.Controls)
                {
                    if (lbl is Button || lbl is Label || lbl is GroupBox)
                        lbl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control lbl in panel3.Controls)
                {
                    if (lbl is Button || lbl is Label || lbl is GroupBox)
                        lbl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                dgrTimeAttandance.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                //foreach (Control btn in groupBox2.Controls)
                //{
                //    if (btn is Button || btn is Label || btn is GroupBox)
                //        btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                //}
                //for (int i = 0; i < controls.Count; i++)
                //{
                //    if (controls[i].Controls == Controls.OfType<Button>() || controls[i].Controls == Controls.OfType<Label>() || controls[i].Controls == Controls.OfType<GroupBox>())
                //        controls[i].Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                //}
                //for (int i = 0; i < controls.Count; i++)
                //{
                //    if ((controls[i].Controls is Button) || (controls[i].Controls is Label) || (controls[i].Controls is GroupBox))
                //        controls[i].Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                //}
                //controls.Where(a => (a.Controls == a.Controls.OfType<Button>()) | (a.Controls == a.Controls.OfType<Label>()) | (a.Controls == a.Controls.OfType<GroupBox>()));
            }
        }

        private void Entry_Time_Attandance_FormClosing(object sender, FormClosingEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

    }
}
