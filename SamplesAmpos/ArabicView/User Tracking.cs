using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;
using ObjectHelper;
using BumedianBM.ViewHelper;
using System.Threading;
using System.Globalization;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class User_Tracking : Form,IDisposable
    {
        UserTrackingHelper ObjUserTrackHelp = new UserTrackingHelper();
        List<EmployeeObjectClass> objUsrTrckList = new List<EmployeeObjectClass>();
        public static bool Flag =false;
        public static bool IsDetailedReport = false;
        #region Constructor
        public User_Tracking()
        {
            InitializeComponent();
            Cmb_Action.DataSource = null;
            SetLanguage();
            setFont();
        }
        #endregion

        #region Events
        #region Load
        private void User_Tracking_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.Format = DateTimePickerFormat.Custom;

                dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                UserTrackingLoad();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "User_Tracking_Load");
            }
        }
        #endregion
        #endregion

        #region Private Methods
        private void UserTrackingLoad()
        {
            cmbUserName.DataSource = null;
            cmbUserName.DisplayMember = "FirstName";
            cmbUserName.ValueMember = "UserId";
            cmbUserName.DataSource = GeneralObjectClass.UserList.FindAll(x => x.Status == 1 & x.EmployeeUserFlag==1);
            cmbUserName.SelectedIndex = -1;
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "";
            culture.DateTimeFormat.LongTimePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString() + " " + "hh:mm:ss";
            Thread.CurrentThread.CurrentCulture = culture;
            dtpToTime.CustomFormat = "hh:mm tt";
            dtpFromTime.CustomFormat = "hh:mm tt";
            dtpFromTime.Value = Convert.ToDateTime("12:00 AM");
            dtpToTime.Value = Convert.ToDateTime("11:59 PM");
        }
        #endregion
        
        public void SetLanguage()
        {
            lblFromDate.Text = Additional_Barcode.GetValueByResourceKey("FD");
            lblFromTime.Text = Additional_Barcode.GetValueByResourceKey("FT");
            lblToDate.Text = Additional_Barcode.GetValueByResourceKey("TD");
            lblToTime.Text = Additional_Barcode.GetValueByResourceKey("TT");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            this.Text = Additional_Barcode.GetValueByResourceKey("UserTrack");
            lblAction.Text = Additional_Barcode.GetValueByResourceKey("Action");
            lblUser.Text = Additional_Barcode.GetValueByResourceKey("User");
            btnDetailedReport.Text = Additional_Barcode.GetValueByResourceKey("DetailedReport");
            btnExit.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            chkAllDate.Text = Additional_Barcode.GetValueByResourceKey("All");
            chkAllUser.Text = Additional_Barcode.GetValueByResourceKey("All");

            dgrTrackingUser.Columns["Sno"].HeaderText = Additional_Barcode.GetValueByResourceKey("Sno");
            dgrTrackingUser.Columns["Date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgrTrackingUser.Columns["Time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgrTrackingUser.Columns["UserName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserName");
            dgrTrackingUser.Columns["ActionArabic"].HeaderText = Additional_Barcode.GetValueByResourceKey("ActionArabic");
            dgrTrackingUser.Columns["TableName"].HeaderText = Additional_Barcode.GetValueByResourceKey("TableName");
            dgrTrackingUser.Columns["ActionType"].HeaderText = Additional_Barcode.GetValueByResourceKey("ActionType");
            dgrTrackingUser.Columns["Action"].HeaderText = Additional_Barcode.GetValueByResourceKey("Action");
            dgrTrackingUser.Columns["UserId"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
            dgrTrackingUser.Columns["PerformedOn"].HeaderText = Additional_Barcode.GetValueByResourceKey("PerformedOn");

            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Insert"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Update"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Delete"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Modify"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("CloseSave"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Print"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("New"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Return"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("View"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Login"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Logout"));
            Cmb_Action.Items.Add(Additional_Barcode.GetValueByResourceKey("Undo"));

            if(Thread.CurrentThread.CurrentUICulture.Name=="en-US")
            {
                 dgrTrackingUser.Columns["ActionArabic"].Visible=false;
                 dgrTrackingUser.Columns["Action"].Visible = true;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
            {
                dgrTrackingUser.Columns["ActionArabic"].Visible = true;
                dgrTrackingUser.Columns["Action"].Visible = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // To show loading is inprogress. Done By. A.Manoj On June-30-2014
                IsDetailedReport = false;
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.DetailedReport = false;
                SetObjectFromControls();
                objUsrTrckList.Clear();
                dgrTrackingUser.DataSource = null;
                dgrTrackingUser.AutoGenerateColumns = false;
                objUsrTrckList=ObjUserTrackHelp.GetUsrTrackingActiontBAL();
                if (objUsrTrckList.Count > 0)
                {
                    dgrTrackingUser.DataSource = objUsrTrckList;
                    Cursor.Current = Cursors.Default; // To show loading is inprogress. Done By. A.Manoj On June-30-2014
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "UserTracking");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnFind_Click");
            }
            finally
            {
                Cursor.Current = Cursors.Default;// To show loading is inprogress. Done By. A.Manoj On June-30-2014
            } 
        }

        private void SetObjectFromControls()
        {

            if (!chkAllDate.Checked)
            {
                //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                TimeSpan TsFrom = new TimeSpan(dtpFromTime.Value.Hour, dtpFromTime.Value.Minute, dtpFromTime.Value.Second);
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.FromDate = Convert.ToDateTime(dtpFromDate.Value.Date + TsFrom);
                TimeSpan TsTo = new TimeSpan(dtpToTime.Value.Hour, dtpToTime.Value.Minute, dtpToTime.Value.Second);
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.ToDate = Convert.ToDateTime(dtpToDate.Value.Date + TsTo);
                //Time span is added to search From date as well as from time.
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.Flag = false;
            }
            else
            {
                //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
                TimeSpan TsFrom = new TimeSpan(dtpFromTime.Value.Hour, dtpFromTime.Value.Minute, dtpFromTime.Value.Second);
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.FromDate = Convert.ToDateTime(dtpFromDate.Value.Date + TsFrom);
                TimeSpan TsTo = new TimeSpan(dtpToTime.Value.Hour, dtpToTime.Value.Minute, dtpToTime.Value.Second);
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.ToDate = Convert.ToDateTime(dtpToDate.Value.Date + TsTo);
                //Time span is added to search From date as well as from time.
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.Flag = true;
            }
            int cmbUnameval = -1;
            cmbUnameval=ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.SelectedValue = cmbUserName.SelectedIndex != -1 ? cmbUserName.SelectedIndex : -1;
            ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.chkAllEmployee = chkAllUser.Checked;
            ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.UserId = (chkAllUser.Checked == true) ? 0 : (cmbUnameval!=-1?Convert.ToInt32(cmbUserName.SelectedValue.ToString()):0);
            ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.UserName = (chkAllUser.Checked == true) ? "ALL" : (cmbUnameval != -1 ? (cmbUserName.Text.ToString()) : string.Empty);
            if(!IsDetailedReport)
            ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.SelectedAction = Cmb_Action.SelectedIndex != -1 ? Cmb_Action.SelectedIndex : -1;
            else
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.SelectedAction = 10;
            int actiontype = Convert.ToInt32(UserAction(Convert.ToInt32(Cmb_Action.SelectedIndex.ToString())));
            ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.ActionType = actiontype;
            
            
        }

        private CommonHelper.ActionType UserAction(int selectedValue)
        {
            switch (selectedValue)
            {
                case 0:
                    return CommonHelper.ActionType.Insert;
                case 1:
                    return CommonHelper.ActionType.Update;
                case 2:
                    return CommonHelper.ActionType.Delete;
                case 3:
                    return CommonHelper.ActionType.Modify;
                case 4:
                    return CommonHelper.ActionType.Save;
                case 5:
                    return CommonHelper.ActionType.Print;
                case 6:
                    return CommonHelper.ActionType.New;
                case 7:
                    return CommonHelper.ActionType.Return;
                case 8:
                    return CommonHelper.ActionType.View;
                case 9:
                    return CommonHelper.ActionType.Login;
                case 10:
                    return CommonHelper.ActionType.Logout;
                default:
                    return CommonHelper.ActionType.All;

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearInputs();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }

        private void ClearInputs()
        {
            
                dtpFromDate.Value = DateTime.Now;
                dtpFromTime.Value = DateTime.Now;
                chkAllDate.Checked = false;
                dtpToDate.Value = DateTime.Now;
                dtpToTime.Value = Convert.ToDateTime("11:59 PM");
                cmbUserName.SelectedIndex = -1;
                chkAllUser.Checked = false;
                Cmb_Action.SelectedIndex = -1;
                dgrTrackingUser.DataSource = null;
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;
                this.Close();
            }
            catch (Exception ex)
            {
                
               GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnExit_Click");
            }
        }

        private void btnDetailedReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor; // To show loading is inprogress. Done By. A.Manoj On June-30-2014
                IsDetailedReport = true;
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.DetailedReport = true;
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.FPrint = false;
                SetObjectFromControls();
                objUsrTrckList.Clear();
                dgrTrackingUser.AutoGenerateColumns = false;
                objUsrTrckList = ObjUserTrackHelp.GetUsrTrackingActiontBAL();
                if (objUsrTrckList.Count > 0)
                {
                    dgrTrackingUser.DataSource = null;
                    dgrTrackingUser.DataSource = objUsrTrckList;
                    Cursor.Current = Cursors.Default; // To show loading is inprogress. Done By. A.Manoj On June-30-2014
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "UserTracking");
                    dgrTrackingUser.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDetailedReport_Click");
            }
            finally
            {
                Cursor.Current = Cursors.Default;// To show loading is inprogress. Done By. A.Manoj On June-30-2014
            } 
        }

        #region "KeyPress Events"

        private void Dtp_FromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) { dtpToDate.Focus(); }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDetailedReport_Click");
            }
        }

        private void Dtp_ToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) { chkAllDate.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Dtp_ToDate_KeyPress");
            }
        }

        private void Dtp_FromTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) { dtpToTime.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Dtp_FromTime_KeyPress");
            }
        }

        private void Dtp_ToTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) { cmbUserName.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Dtp_ToTime_KeyPress");
            }
        }

        private void Chk_AllDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) {dtpFromTime.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Chk_AllDate_KeyPress");
            }
        }

        private void Chk_AllUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) {Cmb_Action.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Chk_AllUser_KeyPress");
            }
        }

        private void Cmb_Action_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13) { InvokeOnClick(btnFind, EventArgs.Empty); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Action_KeyPress");
            }
        }

        #endregion

        #region "Key Down Events"

        private void tracking_users_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "tracking_users_KeyDown");
            }
        }

        #endregion
        #region "Key Up Events"
        private void cmbUserName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { chkAllUser.Focus(); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbUserName_KeyUp");
            }
        }
        #endregion

        #region "CheckBox Checked Changed Events"

        private void Chk_AllDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAllDate.Checked == true)
                {
                    dtpFromDate.Enabled = false;
                    dtpFromTime.Enabled = false;
                    dtpToDate.Enabled = false;
                    dtpToTime.Enabled = false;
                }
                else
                {
                    dtpFromDate.Enabled = true;
                    dtpFromTime.Enabled = true;
                    dtpToDate.Enabled = true;
                    dtpToTime.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Chk_AllDate_CheckedChanged");
            }
        }

        private void Chk_AllUser_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkAllUser.Checked == true) { cmbUserName.Enabled = false; } else { cmbUserName.Enabled = true; }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Chk_AllUser_CheckedChanged");
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                IsDetailedReport = false;
                ObjUserTrackHelp.ObjEmployeeBAL.ObjEmployeeObject.FPrint = true;
                SetObjectFromControls();
                if (ObjUserTrackHelp.CheckValidations())
                {
                    DataTable dtUsrTrack = new DataTable("UserTracking");
                    dtUsrTrack = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>(ObjUserTrackHelp.GetUsrTrackingActiontBAL());
                    if (dtUsrTrack != null)
                    {
                        if (dtUsrTrack.Rows.Count > 0)
                        {
                            if (IsDetailedReport == false)
                            {
                                this.InvokeOnClick(btnFind, EventArgs.Empty);
                            }
                            else
                            {
                                this.InvokeOnClick(btnDetailedReport, EventArgs.Empty);
                            }
                            ObjUserTrackHelp.GenerateUsrTrackReport(dtUsrTrack);
                        }
                        else { GeneralFunction.Information("NoRecordsFound", "UserTracking"); }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPrint_Click");
            }
        }
        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }

        private void setFont()
        {
             var Culture = Thread.CurrentThread.CurrentUICulture;
             if (Culture.Name == "en-US")
             {
                 foreach (Control ctl in this.Controls)
                 {
                     if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton)
                         ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                     else if (ctl is GroupBox)
                     {
                         foreach(Control ct in ctl.Controls)
                         if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton)
                             ct.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                     }
                     dgrTrackingUser.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                 }
             }
        }

        private void User_Tracking_FormClosing(object sender, FormClosingEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void User_Tracking_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgrTrackingUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
