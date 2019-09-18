using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataBaseHelper.DALClass
{
    public class TimeAttendanceStampDAL
    {
        #region List
        List<EmployeeObjectClass> ObjTimeAttendanceListDAL = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjTimeAttendanceSheetDAL = new List<EmployeeObjectClass>();
        EmployeeObjectClass objempclass = new EmployeeObjectClass();
        #endregion

        #region Variables
        private const string GET_EMPATTENDANCE_DETAILS = "SP_Get_WorkTimeAttendanceList";
        private const string SPNAMESAVEWORKBRAKETIME = "SP_Save_WorkBrakeTime";
        private const string SPNAMESAVEWORKBRAKETIMEOFOVERTIME = "SP_Save_OverTime_WorkBrakeTime";
        private const string SPNAMESAVEWORKENDTIMEOFOVERTIME = "SP_Save_OverTime_WorkEndTime";
        private const string SPNAMESAVEWORKENDTIME = "SP_Save_WorkEndTime";
        private const string SPNAMESAVEWORKSTARTTIMEOFOVERTIME = "SP_Save_OverTime_WorkStartTime";
        private const string SPNAMESAVEWORKSTARTTIME = "SP_Save_WorkStartTime";
        private const string SPGetUserGroup = "SP_Get_UserGroup";
        private const string SPGETUSERATTENDANCELIST = "SP_Get_UserAttendanceList";
        private const string SPNAMESAVEWORKTIME = "SP_Save_WorkTime";
        #endregion

        #region Time Attendance Stamp Form

        public List<EmployeeObjectClass> GetWorkTimeAttendanceList()
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(GET_EMPATTENDANCE_DETAILS, sqlparam);
                ObjTimeAttendanceListDAL.Clear();
                while (result.Read())
                {
                    string strTimebreak1 = string.Empty; string strOverTimebreak1 = string.Empty;
                    TimeSpan TStimebreak = new TimeSpan(); TimeSpan TSovertimebreak = new TimeSpan();
                    if (result["TimeBreak"] != DBNull.Value)
                    {
                        DateTime dt = Convert.ToDateTime(result["TimeBreak"].ToString());
                        //int hh = Convert.ToInt32(dt.Hour);
                        //int mm = Convert.ToInt32(dt.Minute);
                        //int ss = Convert.ToInt32(dt.Second);
                        //TStimebreak = new TimeSpan(hh, mm, ss);
                        TStimebreak = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                    }
                    else
                    {
                        TStimebreak = new TimeSpan(DateTime.MinValue.Hour, DateTime.MinValue.Minute, DateTime.MinValue.Second);
                    }
                    if (result["OverTimeBreak"] != DBNull.Value)
                    {
                        DateTime dt = Convert.ToDateTime(result["OverTimeBreak"].ToString());
                        TSovertimebreak = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                    }
                    //TimeSpan TStimebreak = new TimeSpan(result["TimeBreak"] == DBNull.Value ? DateTime.MinValue.Ticks : Convert.ToDateTime(result["TimeBreak"]).Ticks);
                    // TimeSpan TSovertimebreak = new TimeSpan(result["OverTimeBreak"] == DBNull.Value ? DateTime.MinValue.Ticks : Convert.ToDateTime(result["OverTimeBreak"]).Ticks);
                    if (result["Flag"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(result["Flag"].ToString()) == 1 || TStimebreak.ToString() != "00:00:00")
                        {
                            strTimebreak1 = result["DTimeBreak"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["DTimeBreak"]).ToString("hh:mm tt");
                        }
                        if (Convert.ToInt32(result["Flag"].ToString()) == 2 || TStimebreak.ToString() != "00:00:00")
                        {
                            strTimebreak1 = TStimebreak.ToString();
                        }
                        if (Convert.ToInt32(result["Flag"].ToString()) == 3 || TSovertimebreak.ToString() != "00:00:00")
                        {
                            strOverTimebreak1 = result["DOverTimeBreak"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["DOverTimeBreak"]).ToString("hh:mm tt");
                        }
                        if (Convert.ToInt32(result["Flag"].ToString()) == 4 || TSovertimebreak.ToString() != "00:00:00")
                        {
                            strOverTimebreak1 = TSovertimebreak.ToString();
                        }
                    }
                    // string strTimebreak1 = result["Flag"] == DBNull.Value ? string.Empty : (Convert.ToInt32(result["Flag"].ToString()) % 2 == 0 ? TStimebreak.ToString() : result["DTimeBreak"].ToString());
                    //  string strOverTimebreak1 = result["Flag"] == DBNull.Value ? string.Empty : (result["OverTimeStart"].ToString() == "1" ? TStimebreak.ToString() : result["DTimeBreak"].ToString());
                    string strdate = string.Empty;
                    if (result["Date"] == DBNull.Value)
                    {
                        strdate = string.Empty;
                    }
                    else
                    {
                        string[] date = Convert.ToDateTime(result["Date"]).Date.ToString().Trim().Split(' ');
                        strdate = date[0].ToString();
                    }
                    ObjTimeAttendanceListDAL.Add(new EmployeeObjectClass
                    {

                        UserId = Convert.ToInt32(result["UserId"]),
                        UserName = result["UserName"].ToString(),
                        // TimeStart = result["TimeStart"]== DBNull.Value ? DateTime.MinValue :Convert.ToDateTime(result["TimeStart"].ToString()),
                        TimeStart = result["TimeStart"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["TimeStart"]),  //
                        TimeBreak = TStimebreak,
                        //TimeBreak = result["TimeBreak"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["TimeBreak"]), //
                        TimeEnd = result["TimeEnd"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["TimeEnd"]),
                        OverTimeStart = result["OverTimeStart"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["OverTimeStart"]),
                        //OverTimeBreak = (TimeSpan)result["OverTimeBreak"],
                        OverTimeBreak = TSovertimebreak,
                        OverTimeEnd = result["OverTimeEnd"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["OverTimeEnd"]),
                        TotalHours = result["TotalHours"] == DBNull.Value ? string.Empty : result["TotalHours"].ToString(),
                        OverTimeTotalHours = result["OverTimeTotalHours"] == DBNull.Value ? string.Empty : result["OverTimeTotalHours"].ToString(),
                        ////DTimeStart = Convert.ToDateTime((result["DTimeStart"] == DBNull.Value ? null : result["DTimeStart"])),
                        DTimeStart = result["DTimeStart"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DTimeStart"]),
                        DTimeEnd = result["DTimeEnd"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DTimeEnd"]),
                        DOverTimeStart = result["DOverTimeStart"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DOverTimeStart"]),
                        DOverTimeEnd = result["DOverTimeEnd"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DOverTimeEnd"]),
                        DTimeBreak = result["DTimeBreak"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DTimeBreak"]),
                        DOverTimeBreak = result["DOverTimeBreak"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DOverTimeBreak"]),
                        Date = result["Date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["Date"]),
                        Date1 = strdate,
                        TimeStart1 = result["TimeStart"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["TimeStart"]).ToString("hh:mm tt"),
                        TimeEnd1 = result["TimeEnd"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["TimeEnd"]).ToString("hh:mm tt"),
                        TimeBreak1 = strTimebreak1,
                        OverTimeBreak1 = strOverTimebreak1,
                        OverTimeStart1 = result["OverTimeStart"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["OverTimeStart"]).ToString("hh:mm tt"),
                        OverTimeEnd1 = result["OverTimeEnd"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["OverTimeEnd"]).ToString("hh:mm tt"),
                        Breakflag = result["Flag"] != DBNull.Value ? Convert.ToInt32(result["Flag"].ToString()) : 0,
                        WeekEnd = Convert.ToInt32(result["WeekendDay"].ToString()),

                    });
                }
                return ObjTimeAttendanceListDAL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public int Save_EmpWorkBrakeTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[5];

                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                sqlparam[2] = new SqlParameter("@DTimeBreak", objempclass.DTimeBreak);
                sqlparam[3] = new SqlParameter("@TimeBreak", objempclass.TimeBreak);
                sqlparam[4] = new SqlParameter("@FLAG", objempclass.BrakeTimeFlag);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKBRAKETIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int Save_OverTime_EmpWorkBrakeTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                sqlparam[2] = new SqlParameter("@OverTimeBreak", objempclass.TimeBreak);
                sqlparam[3] = new SqlParameter("@DOverTimeBreak", objempclass.DTimeBreak);
                sqlparam[4] = new SqlParameter("@Flag", objempclass.BrakeTimeFlag);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKBRAKETIMEOFOVERTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int Save_OverTime_EmpWorkEndTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                sqlparam[2] = new SqlParameter("@OverTimeEnd", objempclass.TimeEnd);
                sqlparam[3] = new SqlParameter("@DOverTimeEnd", objempclass.DTimeEnd);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKENDTIMEOFOVERTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int Save_EmpWorkEndTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.Date);
                sqlparam[2] = new SqlParameter("@EndTime", objempclass.TimeEnd);
                sqlparam[3] = new SqlParameter("@OverTime", objempclass.DayofOverTime);
                sqlparam[4] = new SqlParameter("@DEndTime", objempclass.DTimeEnd);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKENDTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int Save_OverTime_EmpWorkStartTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.DateNew);
                sqlparam[2] = new SqlParameter("@OverTimeStart", objempclass.TimeStart);
                sqlparam[3] = new SqlParameter("@DOverTimeStart", objempclass.DTimeStart);
                sqlparam[4] = new SqlParameter("@CurrentUserID", objempclass.CurrentUserID);
                sqlparam[5] = new SqlParameter("@WorkStationName", objempclass.WorkStationName);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKSTARTTIMEOFOVERTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public int Save_EmpWorkStartTime(EmployeeObjectClass objempclass)
        {
            int i;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[9];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@Date", objempclass.DateNew);
                sqlparam[2] = new SqlParameter("@StartTime", objempclass.TimeStart);
                sqlparam[3] = new SqlParameter("@Flag", objempclass.WeekEndDayFlag);
                sqlparam[4] = new SqlParameter("@Lantency", objempclass.DayofLatency);
                sqlparam[5] = new SqlParameter("@OverTime", objempclass.DayofOverTime);
                sqlparam[6] = new SqlParameter("@DStartTime", objempclass.DTimeStart);
                sqlparam[7] = new SqlParameter("@CurrentUserID", objempclass.CurrentUserID);
                sqlparam[8] = new SqlParameter("@WorkStationName", objempclass.WorkStationName);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKSTARTTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }

        public int Get_UserGroupID(EmployeeObjectClass objempclass)
        {
            int i = 0;

            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable(SPGetUserGroup, sqlparam, "Attendancelist");
                i = dtLocal.Rows.Count > 0 ? Convert.ToInt32(dtLocal.Rows[0][0]) : 0;
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Save_EmpSaveTime(int userid , DateTime  datTime ,int timeid)
        {
            
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@UserID", userid);
                sqlparam[1] = new SqlParameter("@Date", datTime);
                sqlparam[2] = new SqlParameter("@timeid", timeid);
                
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEWORKTIME, sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Time Attendance Sheet Form

        public List<EmployeeObjectClass> GetTimeAttendanceSheet(EmployeeObjectClass objempclass)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@UserID", objempclass.UserId);
                sqlparam[1] = new SqlParameter("@FromDate", objempclass.From);
                sqlparam[2] = new SqlParameter("@ToDate", objempclass.To);
                sqlparam[3] = new SqlParameter("@UserGroupId", objempclass.UserGrpId);
                sqlparam[4] = new SqlParameter("@Flag", objempclass.SelectedFlag);
                //DataTable dt = new DataTable();
                //dt = SQLHelper.Instance.ExecuteDatatableWithQuery(SPGETUSERATTENDANCELIST, sqlparam, "Hi");
                var result = SQLHelper.Instance.GetReader(SPGETUSERATTENDANCELIST, sqlparam);


                ObjTimeAttendanceListDAL.Clear();
                int i = 1;
                while (result.Read())
                {
                    //string dates = string.Empty;
                    //DateTime dt;
                    //dt =Convert.ToDateTime(result["Date"]);
                    //dates = dt.Date.ToString();
                    ObjTimeAttendanceListDAL.Add(new EmployeeObjectClass
                        {
                            Sno = i++,
                            UserId = Convert.ToInt32(result["UserId"]),
                            UserName = result["UserName"].ToString(),
                            Date1 = result["Date"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["Date"]).Date.ToString(ConfigurationSettings.AppSettings["DateFormat"].ToString()),
                            // Date1 = Convert.ToDateTime(result["Date"]).Date.ToShortDateString(),
                            Day = result["Day"].ToString(),
                            TimeStart1 = result["TimeStart"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["TimeStart"]).ToShortTimeString(),
                            TimeBreak1 = result["TimeBreak"] == DBNull.Value ? string.Empty : result["TimeBreak"].ToString(),
                            TimeEnd1 = result["TimeEnd"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["TimeEnd"]).ToShortTimeString(),
                            TotalHours = result["TotalTime"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["TotalTime"]).ToString("hh:mm:ss"),
                            //OverTimeStart1 = result["OverTimeStart"] == DBNull.Value ? string.Empty : result["OverTimeStart"].ToString(),
                            OverTimeStart1 = result["OverTimeStart"] == DBNull.Value ? string.Empty :Convert.ToDateTime(result["OverTimeStart"]).ToShortTimeString(), 
                            OverTimeEnd1 = result["OverTimeEnd"] == DBNull.Value ? string.Empty :Convert.ToDateTime(result["OverTimeEnd"]).ToShortTimeString(),
                            OverTimeTotalHours = result["OverTimeTotalHours"] == DBNull.Value ? string.Empty : result["OverTimeTotalHours"].ToString(),
                            Difference = result["Difference"] == DBNull.Value ? string.Empty : result["Difference"].ToString(),
                            TotalDays = result["TotalDays"] == DBNull.Value ? 0 : Convert.ToInt32(result["TotalDays"].ToString())
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ObjTimeAttendanceListDAL;
        }

        #endregion

        public DataTable Get_ReportValues()
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_TimeAttendenceList", sqlparam, "Attendancelist");
                return (dtLocal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtLocal;
        }
    }
}
