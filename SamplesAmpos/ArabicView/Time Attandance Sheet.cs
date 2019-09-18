using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ViewHelper;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Time_Attandance_Sheet : Form, IDisposable
    {
        #region "Variables"

        TimeAttendanceSheetHelper objTimeAttenSheetHelp;
        List<EmployeeObjectClass> objTimeAttenSheetList = new List<EmployeeObjectClass>();
        public string setval, dateCompare;
        public Int32 getval1 = 0, getval2 = 0, getval3 = 0, count = 1;
        public Int32 getvaldiff1, getvaldiff2, getvaldiff3 = 0;
        BindingSource BindSource;

        #endregion

        #region Constructor
        public Time_Attandance_Sheet()
        {
            objTimeAttenSheetHelp = new TimeAttendanceSheetHelper();
            InitializeComponent();
            btnUserAdmin.Enabled = UserScreenLimidations.Users;
            btnPaySalary.Enabled = UserScreenLimidations.SalaryPayment;
            btnUserTracking.Enabled = UserScreenLimidations.UserTracking;
            SetLanguage();
            setFont();
            TimeAttendanceLoad();
        }
        #endregion

        private void TimeAttendanceLoad()
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.Format = DateTimePickerFormat.Custom;

                dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                cmbUserName.DataSource = null;
                cmbUserName.DisplayMember = "FirstName";
                cmbUserName.ValueMember = "UserId";
                cmbUserName.DataSource = GeneralObjectClass.UserList.FindAll(x => x.Status == 1);

                cmbUserName.SelectedIndex = -1;

                cmbGroup.DataSource = null;
                cmbGroup.DisplayMember = "UserGroupName";
                cmbGroup.ValueMember = "UserGrpId";
                cmbGroup.DataSource = GeneralObjectClass.UserGroupList;

                cmbGroup.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public void SetLanguage()
        {
            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            this.Text = Additional_Barcode.GetValueByResourceKey("TimeAttSheet");
            radUser.Text = Additional_Barcode.GetValueByResourceKey("User");
            radGroup.Text = Additional_Barcode.GetValueByResourceKey("UserGroup");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            chkDateAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            radUserAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            lblTotalWorkingDiff.Text = Additional_Barcode.GetValueByResourceKey("TWorkingDiff");
            lblTotalWorkingHrs.Text = Additional_Barcode.GetValueByResourceKey("TWorkingHrs");
            lblDailyAverage.Text = Additional_Barcode.GetValueByResourceKey("DailyAvg");
            btnPaySalary.Text = Additional_Barcode.GetValueByResourceKey("PaySal");
            btnUserAdmin.Text = Additional_Barcode.GetValueByResourceKey("UserAdmin");
            btnUserTracking.Text = Additional_Barcode.GetValueByResourceKey("UserTrack");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");

            dgrAttendanceList.Columns["Sno"].HeaderText = Additional_Barcode.GetValueByResourceKey("Sno");
            dgrAttendanceList.Columns["UserName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserName");
            dgrAttendanceList.Columns["UserDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserDate");
            dgrAttendanceList.Columns["Day"].HeaderText = Additional_Barcode.GetValueByResourceKey("Day");
            dgrAttendanceList.Columns["EntryTime"].HeaderText = Additional_Barcode.GetValueByResourceKey("EntryTime");
            dgrAttendanceList.Columns["ExitTime"].HeaderText = Additional_Barcode.GetValueByResourceKey("ExitTime");
            dgrAttendanceList.Columns["TotalHours"].HeaderText = Additional_Barcode.GetValueByResourceKey("Totalhours");
            dgrAttendanceList.Columns["Difference"].HeaderText = Additional_Barcode.GetValueByResourceKey("Differ");
        }

        #region Events

        #region New Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                chkDateAll.Checked = false;
                cmbUserName.SelectedIndex = -1;
                txtWorkingHours.Text = "";
                txtWorkingDifference.Text = "";
                txtDailyAvarage.Text = "";
                ClearDatagrid();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Find
        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                SetObjectFromControls();
                if (objTimeAttenSheetHelp.checkAttenValidation())
                {
                    dgrAttendanceList.AutoGenerateColumns = false;
                    objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.TotalHours = string.Empty;
                    objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.WorkingDifference = string.Empty;
                    objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.DailyAvg = string.Empty;
                    BindSource = new BindingSource();
                    BindSource.DataSource = null;
                    dgrAttendanceList.DataSource = null;
                    BindSource.DataSource = objTimeAttenSheetHelp.GetWorkTimeAttedanceHelper();
                    dgrAttendanceList.DataSource = BindSource;
                    dgrAttendanceList.Refresh();
                    string workHrs = objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.TotalHours;
                    string workDiffer = objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.WorkingDifference;
                    string Dailyavg = objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.DailyAvg;
                    if (workHrs != null)
                        txtWorkingHours.Text = workHrs;
                    else
                        txtWorkingHours.Text = string.Empty;
                    if (workDiffer != null)
                        txtWorkingDifference.Text = workDiffer;
                    else
                        txtWorkingDifference.Text = string.Empty;
                    if (Dailyavg != null)
                        txtDailyAvarage.Text = Dailyavg;
                    else
                        txtDailyAvarage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region PaySalary
        private void btnPaySalary_Click(object sender, EventArgs e)
        {
            Salary_Payment Salpay = new Salary_Payment();
            Salpay.ShowDialog();
        }
        #endregion

        #region UserAdmin
        private void btnUserAdmin_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Tag = "ALL";
            emp.ShowDialog();
        }
        #endregion

        #region UserTracking
        private void btnUserTracking_Click(object sender, EventArgs e)
        {
            User_Tracking objTrackUser = new User_Tracking();
            //tracking_users TrackUser = new tracking_users();
            objTrackUser.ShowDialog();
        }
        #endregion

        #region Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<EmployeeObjectClass> objlist;
            try
            {
                DataTable Atten = new DataTable("AllTimeAttandanceReport");
                if (dgrAttendanceList.DataSource != null)
                {
                    objlist = ((List<EmployeeObjectClass>)BindSource.DataSource).Cast<EmployeeObjectClass>().ToList();

                    Atten = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>((List<EmployeeObjectClass>)objlist);
                    //Atten = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>((List<EmployeeObjectClass>)dgrAttendanceList.DataSource);
                }
                //  Atten= Atten.Merge((DataTable)dgrAttendanceList.DataSource);
                if (Atten != null)
                {
                    if (Atten.Rows.Count > 0)
                    {
                        objTimeAttenSheetHelp.GenerateAttendancsheetPrint(Atten);
                    }
                }
                else
                {
                    GeneralFunction.Information("No Items Found", this.Text);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                objlist = null;
            }

        }
        #endregion

        #region Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Key Press Events"
        private void Chk_DateAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }

        }
        private void Chk_UserAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region "Key Up Events"

        private void Dtp_FromDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dtpToDate.Focus();
            }
        }

        private void Dtp_ToDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Cmb_UserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Key Down Events"

        private void time_attandance_rep_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region "Checked Changed event"

        private void Rbn_Notes_CheckedChanged(object sender, EventArgs e)
        {
            if (radGroup.Checked == true)
            {
                cmbUserName.Enabled = false;
                cmbGroup.Enabled = true;
            }
            else if (radUser.Checked == true)
            {
                cmbGroup.Enabled = false;
                cmbUserName.Enabled = true;
            }
            else
            {
                cmbUserName.Enabled = false;
                cmbGroup.Enabled = false;
            }
        }

        private void Chk_DateAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateAll.Checked == true)
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

        #endregion

        #endregion

        #region Private Methods
        private void ClearDatagrid()
        {
            dgrAttendanceList.DataSource = null;
            txtWorkingHours.Text = "";
            txtWorkingDifference.Text = "";
            txtDailyAvarage.Text = "";
        }
        #endregion

        private void SetObjectFromControls()
        {
            if (radUserAll.Checked)
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedFlag = 1;   // ALL User Selected
            }
            else if (radGroup.Checked)
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedFlag = 2;    // Group Selected 
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.UserGrpId = cmbGroup.SelectedValue != null ? Convert.ToInt32(cmbGroup.SelectedValue.ToString()) : -1;
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedValue = cmbGroup.SelectedValue != null ? Convert.ToInt32(cmbGroup.SelectedValue.ToString()) : -1;
            }
            else if (radUser.Checked)
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedFlag = 3;   // User Selected 
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.UserId = cmbUserName.SelectedValue != null ? Convert.ToInt32(cmbUserName.SelectedValue.ToString()) : -1;
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedValue = cmbUserName.SelectedValue != null ? Convert.ToInt32(cmbUserName.SelectedValue.ToString()) : -1;
            }
            else
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.SelectedFlag = 0;
            }
            if (chkDateAll.Checked)
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.Flag = true;
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.From = null;
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.To = null;
            }
            else
            {
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.From = Convert.ToDateTime(dtpFromDate.Value);
                objTimeAttenSheetHelp.ObjTimeAttendSheet.ObjEmployeeObject.To = Convert.ToDateTime(dtpToDate.Value);
            }
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                foreach (Control ct in this.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                    else if (ct is GroupBox)
                    {
                        foreach (Control btn in ct.Controls)
                        {
                            if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                        }
                    }
                }
                dgrAttendanceList.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void Time_Attandance_Sheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            objTimeAttenSheetHelp.DisposeListObject();
            this.Dispose();
        }
    }
}
