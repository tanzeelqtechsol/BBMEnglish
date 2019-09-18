using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class EndShift : Form
    {
        DataTable dtAttenValues = new DataTable("EndShiftDetails");
        EndShiftHelper ObjEndShiftHelper;
        TimeAttendanceStampHelper objTimeAttenStampHelp;
        List<EmployeeObjectClass> ObjWorktimeAttendance = new List<EmployeeObjectClass>();
        public static int resultcount = 0;
        public static string strTimestart = string.Empty;
        public static string strOTimeStart = string.Empty;
        public static string strOTimeBreak = string.Empty;
        public static string strTimeBreak = string.Empty;
        public static string strOTimeEnd = string.Empty;
        public static string strTimeEnd = string.Empty;
        public static int Brkflag = 0;

        public EndShift()
        {
            objTimeAttenStampHelp = new TimeAttendanceStampHelper();
            InitializeComponent();
            SetLanguage();
            ObjEndShiftHelper = new EndShiftHelper();
        }
        #region Method
        public void SetLanguage()
        {
            lblUser.Text = Additional_Barcode.GetValueByResourceKey("For");
            lblTotalPaid.Text = Additional_Barcode.GetValueByResourceKey("cashTotalPaid");
            llbTotalSalesCash.Text = Additional_Barcode.GetValueByResourceKey("TotalCashSales");
            lblTotalRecieved.Text = Additional_Barcode.GetValueByResourceKey("saleTotalReceived");
            llbHours.Text = Additional_Barcode.GetValueByResourceKey("Workinghours");
            lblLoginTime.Text = Additional_Barcode.GetValueByResourceKey("LoginTime");
            lblNetCash.Text = Additional_Barcode.GetValueByResourceKey("netc");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnEndShift.Text = Additional_Barcode.GetValueByResourceKey("EndShift");
            msg1.Text = Additional_Barcode.GetValueByResourceKey("msg1");
            msg2.Text = Additional_Barcode.GetValueByResourceKey("msg2");
            this.Text = Additional_Barcode.GetValueByResourceKey("EndShiftForm");
            msg.Text = Additional_Barcode.GetValueByResourceKey("msg");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");

            lblTotalSale.Text = Additional_Barcode.GetValueByResourceKey("saleTotalSales");
            lblTotalSaleCard.Text = Additional_Barcode.GetValueByResourceKey("totalCardSales");
            lblTotalSaleCheck.Text = Additional_Barcode.GetValueByResourceKey("totalchecksales");
       

        }
        #endregion
        private void EndShift_Load(object sender, EventArgs e)
        {
            FillTimeAttendanceList();
            ButtonEnabled();
            dtAttenValues.Columns.Add("User");
            dtAttenValues.Columns.Add("LoginTime");
            dtAttenValues.Columns.Add("HoursWorked");
            dtAttenValues.Columns.Add("TotalSale");
            dtAttenValues.Columns.Add("TotalReceived");
            dtAttenValues.Columns.Add("TotalPaid");
            dtAttenValues.Columns.Add("TotalCash");


            setUserData();
        }

        private void FillTimeAttendanceList()
        {
            ObjWorktimeAttendance = objTimeAttenStampHelp.GetWorkTimeAttedanceHelper();
           
        }
        private void GetUserattendance(int datevaluepassed)
        {
            var result = ObjWorktimeAttendance;
            if (datevaluepassed == 0)
            {
                int UserId = Convert.ToInt32(GeneralFunction.UserId);
                result = ObjWorktimeAttendance.FindAll(Uid => Uid.UserId == UserId);
            }
            if (datevaluepassed == 1)
            {
                int UserId = Convert.ToInt32(GeneralFunction.UserId);
                DateTime dtime = DateTime.Now;//Convert.ToDateTime(dtpDate.Value);

                result = ObjWorktimeAttendance.FindAll(Uid => (Uid.UserId == UserId) && (Uid.Date.ToShortDateString() == DateTime.Now.ToShortDateString()));
            }
            if (result.Count == 1)
            {
                resultcount = 1;
              //  GStime = result[0].DTimeStart == DateTime.MinValue ? (Convert.ToDateTime(result[0].Date)).Date : result[0].DTimeStart;
              //  strUserId = result[0].UserId == 0 ? string.Empty : result[0].UserId.ToString();
             //   strUsername = result[0].UserName == null ? string.Empty : result[0].UserName.ToString();
              //  strdate = result[0].Date.ToString();
                //-----------------Time----------------------
                strTimestart = result[0].TimeStart.ToString();
                strTimeBreak = result[0].TimeBreak.ToString();
                strTimeEnd = result[0].TimeEnd.ToString();
                //-----------------Over Time----------------------
                strOTimeStart = result[0].OverTimeStart.ToString();
                strOTimeBreak = result[0].OverTimeBreak.ToString();
                strOTimeEnd = result[0].OverTimeEnd.ToString();

               // strTotalHours = result[0].TotalHours.ToString();
               // strOTTotalHours = result[0].OverTimeTotalHours.ToString();

               // DtimeBreak = result[0].DTimeBreak;
              //  DOvertimeBreak = result[0].DOverTimeBreak;
              //  DtimeStart = result[0].DTimeStart;
              //  DtimeEnd = result[0].DTimeEnd;
              //  DOverTimeStart = result[0].DOverTimeStart;
              //  DOverTimeEnd = result[0].DOverTimeEnd;
             //   DateNew = result[0].Date;
                Brkflag = Convert.ToInt32(result[0].Breakflag.ToString());

            }
        }
        private void ButtonEnabled()
        {
            DateTime dtime = DateTime.Now;//Convert.ToDateTime(dtpDate.Value);
            try
            {
                if (ObjWorktimeAttendance.Count != 0)
                {
                   
                        string strExpr;
                        GetUserattendance(0);

                    if (resultcount == 1)
                    {

                        if (strTimestart != DateTime.MinValue.ToString())
                        {
                            btnEndShift.Enabled = true;
                            //if (strTimeBreak == "00:00:00")
                            //{
                            //    btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("StartBreakTime");
                            //    btnBreakTime.Tag = "SBT";
                            //}
                        }
                        if (strOTimeStart == DateTime.MinValue.ToString() & strTimestart == DateTime.MinValue.ToString())
                        {
                            // btnStartTime.Enabled = true;
                            // btnBreakTime.Enabled = true;
                            btnEndShift.Enabled = true;
                        }
                        if ((strOTimeBreak == "00:00:00" & strTimeBreak == "00:00:00") & (strOTimeEnd == DateTime.MinValue.ToString() & strTimeEnd == DateTime.MinValue.ToString()))
                        {
                            // btnStartTime.Enabled = false;
                            // btnBreakTime.Enabled = true;
                            btnEndShift.Enabled = true;
                        }
                        if ((strOTimeEnd == DateTime.MinValue.ToString() & strTimeEnd == DateTime.MinValue.ToString()) & (strTimeBreak != "00:00:00" || strOTimeBreak != "00:00:00"))
                        {
                            // btnStartTime.Enabled = false;
                            // btnBreakTime.Enabled = false;
                            btnEndShift.Enabled = true;
                        }
                        if ((strTimestart != DateTime.MinValue.ToString() & strTimeEnd != DateTime.MinValue.ToString()) & (strOTimeStart == DateTime.MinValue.ToString() & strOTimeEnd == DateTime.MinValue.ToString()))
                        {
                            //btnStartTime.Enabled = true;
                            //btnBreakTime.Enabled = true;
                            btnEndShift.Enabled = true;
                        }
                        if (strTimeBreak != "00:00:00" & strTimeEnd == DateTime.MinValue.ToString())
                        {
                            string sd = strTimeBreak.Substring(6, (strTimeBreak.Length - 6));
                            if (Brkflag == Convert.ToInt32(BreakTimeFlag.StartBreak))
                            {
                                //btnStartTime.Enabled = false;
                                // btnBreakTime.Enabled = true;
                                btnEndShift.Enabled = true;
                                // btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                // btnBreakTime.Tag = "EBT";
                                btnEndShift.Enabled = false;
                            }
                        }
                        if (strOTimeBreak != "00:00:00" & strOTimeEnd == DateTime.MinValue.ToString())
                        {
                            if (Brkflag == Convert.ToInt32(BreakTimeFlag.OTStartBreak))
                            {
                                //btnStartTime.Enabled = false;
                                // btnBreakTime.Enabled = true;
                                btnEndShift.Enabled = true;
                                // btnBreakTime.Text = Additional_Barcode.GetValueByResourceKey("EndBreakTime");
                                // btnBreakTime.Tag = "EBT";
                                btnEndShift.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        // btnStartTime.Enabled = true;
                        //btnBreakTime.Enabled = true;
                        btnEndShift.Enabled = true;
                    }

                }
            }
            catch
            {

            }
         }
        private void setUserData()
        {
            string[] HoursWorked = null;
           // if (GeneralFunction.UserLoginTime == DateTime.MinValue)
           // {
                HoursWorked = ObjEndShiftHelper.SetLoginTime();
           // }
            Txt_User.Text = GeneralFunction.LoginUserName;
            if (GeneralFunction.UserLoginTime != DateTime.MinValue)
            {
                string LoginTime = GeneralFunction.UserLoginTime.ToString();
                string[] uLoginTime = LoginTime.Split(' ');
                if(uLoginTime.Length == 2)
                {
                     LoginTime = GeneralFunction.UserLoginTime.ToString() + " " + GeneralFunction.UserLoginTime.ToShortTimeString();
                }
               
                if (string.IsNullOrEmpty(HoursWorked[0]))
                {
                   // LoginTime = LoginTime + " " + GeneralFunction.UserLoginTime.ToShortTimeString();
                    TimeSpan HoursWored = DateTime.Now - GeneralFunction.UserLoginTime;
                    if (HoursWored != null)
                    {
                        string hourWorked = HoursWored.ToString();
                        string[] hourWork = hourWorked.Split('.');
                        if (hourWork.Count() > 0)
                        {
                            txt_HoursWokred.Text = hourWork[0];
                        }
                    }
                }
                
                else
                {
                   
                    txt_HoursWokred.Text = HoursWorked[0];
                }
                Txt_LoginTime.Text = LoginTime;
            }
            DataTable dt = new DataTable();
            dt = ObjEndShiftHelper.GetUserData(HoursWorked[1]);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    txt_TotalSales.Text = row["TotalSale"].ToString();
                    txt_TotalRecieved.Text = row["TotalReceived"].ToString();
                    txt_TotalPaid.Text = row["TotalPaid"].ToString();
                    txt_NetCash.Text = row["NetCash"].ToString();
                    txtTotalSaleCard.Text = row["TotalSaleCard"].ToString();
                    txtTotalSaleCheck.Text = row["TotalSaleCheck"].ToString();
                    decimal TotalSale = Convert.ToDecimal(row["TotalSale"]) + Convert.ToDecimal(row["TotalSaleCard"]) + Convert.ToDecimal(row["TotalSaleCheck"]);
                    txtAllSale.Text = TotalSale.ToString();
                }
            }

            dtAttenValues.Rows.Add(Txt_User.Text, Txt_LoginTime.Text, txt_HoursWokred.Text, txtAllSale.Text, txt_TotalRecieved.Text, txt_TotalPaid.Text, txt_NetCash.Text);

        }

        private void Txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLoginTime_Click(object sender, EventArgs e)
        {

        }

        private void txt_NetCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtAttenValues.Rows.Count > 0)
                {
                    //dtAtten = (DataTable)dgrTimeAttandance.DataSource;
                    if (dtAttenValues != null)
                    {
                        List<string> SaleTypeList = new List<string>();
                        SaleTypeList.Add(txt_TotalSales.Text);
                        SaleTypeList.Add(txtTotalSaleCard.Text);
                        SaleTypeList.Add(txtTotalSaleCheck.Text);
                        ObjEndShiftHelper.EndShiftReport(dtAttenValues, SaleTypeList);
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message, this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Time Attendance", "btnPrint_Click");
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnEndShift_Click(object sender, EventArgs e)
        {
            try
            {
                
              //  if (GeneralFunction.Question("EndShiftConfirm", "ETA") == DialogResult.Yes)
              //  {
                    Entry_Time_Attandance.IsEndTime = true;
                    Entry_Time_Attandance entryTime = new Entry_Time_Attandance();
                    entryTime.ShowDialog();
                    entryTime = null;
                    Entry_Time_Attandance.IsEndTime = false;
                    //Entry_Time_Attandance stampLogin = new Entry_Time_Attandance();
                    //if (stampLogin.StampEndShift())
                    //{
                    //  //  GeneralFunction.Information("ShiftEndMsg", "ETA");
                    //}
                    //else
                    //{
                    //  //  GeneralFunction.Information("ShiftEndMsg", "ETA");
                    //}

                   // GeneralFunction.isApplnRestart = true; Application.Restart();
                }
          //  }
            catch(Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
