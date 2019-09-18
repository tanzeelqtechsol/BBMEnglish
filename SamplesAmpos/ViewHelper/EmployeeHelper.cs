using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using BumedianBM.ArabicView;
using ObjectHelper;
using CommonHelper;
using System.Data;
using System.Windows.Forms;

namespace BumedianBM.ViewHelper
{
    public class EmployeeHelper
    {
        #region Variables
        //    EmployeeObjectClass ObjEmployeeObjectClass = new EmployeeObjectClass();
        public EmployeeBALClass ObjEmployeeBALClass;
        public System.Data.DataSet Loadds = new DataSet();
        DataTable dtEmp = new DataTable();
        List<EmployeeObjectClass> ObjempListHelper = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjempDrawHelper = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjempNotesHelper = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjempListByOption = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjempLoginDetails = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjTempUserDetails = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> ObjEmpVariableList = new List<EmployeeObjectClass>();
        //  List<EmployeeObjectClass> Obj = new List<EmployeeObjectClass>();
        Dictionary<string, List<EmployeeObjectClass>> ObjempDictHelper = new Dictionary<string, List<EmployeeObjectClass>>();
        internal static List<EmployeeObjectClass> SaveUserGroupList = new List<EmployeeObjectClass>();
        internal bool IsfromVar = false;

        #endregion

        public EmployeeHelper()
        {
            ObjEmployeeBALClass = new EmployeeBALClass();
            ObjEmployeeBALClass.SetCommonObject();
        }
        public EmployeeBALClass ObjEmployeeBAL
        {
            get { return ObjEmployeeBALClass; }
            set { ObjEmployeeBALClass = value; }
        }

        // Load Employee Notes Details in the Employee Notes Form.
        public List<EmployeeObjectClass> LoadEmployeeNotesDetails()
        {
            ObjempNotesHelper = ObjEmployeeBALClass.GetEmpNotesData();
            return ObjempNotesHelper;
        }

        //Load Employee Drawings Details in the Employee Drawings Form.
        public List<EmployeeObjectClass> LoadEmployeeDrawingsDetails()
        {
            ObjempDrawHelper = ObjEmployeeBALClass.GetEmpDrawingsData();
            return ObjempDrawHelper;

        }
        internal void FindCutMonth()//Changed Method to find cut month for var drawing by Meena.R on 11Nov2014
        {
            int index, com;
            if (!IsfromVar)
            {
                index = ObjempDrawHelper.FindIndex(a => (a.EmployeeVariablesID == ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID) && (a.UserId == ObjEmployeeBAL.ObjEmployeeObject.UserId));
                if (index > -1)
                {
                    com = DateTime.Compare(ObjempDrawHelper[index].StartMonthDeduction, ObjempDrawHelper[index].EffectiveDate);
                    if (com == 0)
                        ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 1;
                    else if (com == 1)
                        ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 2;
                }
            }
            else
            {
                IsfromVar = false;
                index = ObjEmpVariableList.FindIndex(a => (a.EmployeeVariablesID == ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID) && (a.UserId == ObjEmployeeBAL.ObjEmployeeObject.UserId));

                if (index > -1)
                {
                    com = DateTime.Compare(ObjEmpVariableList[index].StartMonthDeduction, ObjEmpVariableList[index].EffectiveDate);
                    if (com == 0)
                        ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 1;
                    else if (com == 1)
                        ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 2;
                }
            }
        }
        //Load Employee Variables Details in the Employee Drawings Form.
        public List<EmployeeObjectClass> LoadEmployeeVariablesDetails()
        {
            return ObjEmpVariableList = ObjEmployeeBALClass.GetEmpVariablesData();
        }
        public List<EmployeeObjectClass> LoadEmployeeDetailsList()
        {
            ObjempListHelper = ObjEmployeeBALClass.GetEmpDetailsData();

            //if (Loadds != null && Loadds.Tables.Count > 0)
            //    dtEmp = Loadds.Tables[0];
            //else
            //    return;
            //if (dtEmp.Rows.Count > 0)
            //{
            //    obj_Paging.Merge(dtEmp);
            //    obj_Paging.Row_Count = 16;
            //    Dgv_EmpList.DataSource = dtEmp;
            //}
            return ObjempListHelper;

           
        }

        //Load All Combox Values in the Employee Form.
        public Dictionary<string, List<EmployeeObjectClass>> LoadAllComboBoxDetails()
        {
            ObjempDictHelper = ObjEmployeeBALClass.GetComboBoxValues();
            return ObjempDictHelper;
        }
        //Assign all Controls values to object.
        //public void dgrEmployeeDrawingsCellClick()
        //{
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableAmount = Convert.ToDecimal(ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.Description = ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString();
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.Remarks = ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString();
        //    if (ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = ObjEmployeeForm.dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString();
        //}
        //public void dgrEmployeeVariableCellClick()
        //{
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableAmount = Convert.ToDecimal(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.Remarks = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString();
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString();
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupName = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString();
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.MonthlyDeduction = Convert.ToDecimal(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
        //    if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
        //        ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
        //}
        public void dgrEmployeeListCellClick()
        {
            //DataTable dtLocal = new DataTable();
            //dtLocal = (DataTable)ObjEmployeeForm.dgrEmpList.DataSource;
            //if (dtLocal != null)
            //{
            //    if (dtLocal.Rows.Count > 0)
            //    {
            //        DataRow[] drow = dtLocal.Select("UserId='" + ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString());
            //        ObjEmployeeForm.TabEmployee.SelectedTab = ObjEmployeeForm.TabEmpList;
            //        ObjEmployeeForm.chkSuspendUser.Enabled = true;
            //        if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString() != string.Empty)
            //            ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString());
            //        if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString() != string.Empty)
            //            ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString();
            //        if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString() != string.Empty)
            //            ObjEmployeeBALClass.ObjEmployeeObjectClass.PassportNo = ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString();
            //        if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString() != string.Empty)
            //            ObjEmployeeBALClass.ObjEmployeeObjectClass.PhoneNo = ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString();
            //        if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString() != string.Empty)
            //            ObjEmployeeBALClass.ObjEmployeeObjectClass.MobileNo = ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString();
            //        //if(ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString() != string.Empty)

            //    }
            //}


            //Dtp_StartDate.Value = ((drow[0]["MTB_JOIN_DATE"] == "") | (drow[0]["MTB_JOIN_DATE"] is DBNull)) ? DateTime.Now : Convert.ToDateTime(drow[0]["MTB_JOIN_DATE"].ToString());
            //Txt_HealthCertificate.Text = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_HEALTH_CERTI"].Value).ToString();
            //Txt_SocialNo.Text = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["SocialId"].Value).ToString();
            //string strBS = (Dgv_EmpList.SelectedRows[0].Cells["Salary"].Value).ToString();
            //if (strBS == null || strBS == "") { Txt_BaseSalary.Text = "0.000"; }
            //else
            //{ Txt_BaseSalary.Text = Convert.ToDecimal(Dgv_EmpList.SelectedRows[0].Cells["Salary"].Value).ToString("0.000"); }
            //string strSP = (Dgv_EmpList.SelectedRows[0].Cells["MTB_PERC_SALES"].Value).ToString();
            //if (strSP == null || strSP == "") { Txt_SalesPercentage.Text = "0.000"; }
            //else { Txt_SalesPercentage.Text = Convert.ToDecimal(Dgv_EmpList.SelectedRows[0].Cells["MTB_PERC_SALES"].Value).ToString("0.##"); }
            //if (Dgv_EmpList.SelectedRows[0].Cells["MTB_START_WORK_HRS"].Value.ToString() != "")
            //{
            //    DateTime dtWHF = Convert.ToDateTime(Dgv_EmpList.SelectedRows[0].Cells["MTB_START_WORK_HRS"].Value);
            //    Dtp_WorkingHoursFrom.Text = (dtWHF).ToString("hh:mm tt");
            //}
            //else
            //{
            //    Dtp_WorkingHoursFrom.Text = ("09:00 AM");
            //}

            //if (Dgv_EmpList.SelectedRows[0].Cells["MTB_END_WORK_HRS"].Value.ToString() != "")
            //{
            //    DateTime dtWHT = Convert.ToDateTime(Dgv_EmpList.SelectedRows[0].Cells["MTB_END_WORK_HRS"].Value);
            //    Dtp_WorkingHoursTo.Text = (dtWHT).ToString("hh:mm tt");
            //}
            //else
            //{
            //    Dtp_WorkingHoursTo.Text = ("02:00 PM");
            //}

            //string CalcType = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_CALC_TYPE"].Value).ToString();
            //Cmb_CalculationType.Text = CalcType;

            //SalaryID = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_SALARY_ID"].Value).ToString();
            //string val = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_EMP_USER_FLG"].Value).ToString();
            //if (val == "USR")
            //{
            //    Chk_UserToSystem.Checked = true;
            //    Txt_UserName.Text = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_USER_NAME"].Value).ToString();
            //    Txt_Reminder.Text = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_PWD_REMINDER"].Value).ToString();
            //    Txt_Password.Text = GeneralFunction.Decrypt(Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_PASSWORD"].Value).ToString());
            //    Txt_ConfirmPassword.Text = GeneralFunction.Decrypt(Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_PASSWORD"].Value).ToString());
            //}
            //else
            //{
            //    Chk_UserToSystem.Checked = false;
            //    Txt_UserName.Text = "";
            //    Txt_Reminder.Text = "";
            //    Txt_Password.Text = "";
            //    Txt_ConfirmPassword.Text = "";
            //}


            //string DayName = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_WEEKEND_DAY"].Value).ToString();

            //if (DayName.Trim() == "SATURDAY") { Cmb_Weekend.Text = "Sat"; }
            //if (DayName.Trim() == "SUNDAY") { Cmb_Weekend.Text = "Sun"; }
            //if (DayName.Trim() == "MUNDAY") { Cmb_Weekend.Text = "Mun"; }
            //if (DayName.Trim() == "TUESDAY") { Cmb_Weekend.Text = "Tus"; }
            //if (DayName.Trim() == "WEDNESDAY") { Cmb_Weekend.Text = "Wed"; }
            //if (DayName.Trim() == "THURSDAY") { Cmb_Weekend.Text = "Thu"; }
            //if (DayName.Trim() == "FRIDAY") { Cmb_Weekend.Text = "Fri"; }



            //Rbn_ExistingUserGroup.Checked = (Dgv_EmpList.SelectedRows[0].Cells["MTB_USER_GRP_NAME"].Value == null || Dgv_EmpList.SelectedRows[0].Cells["MTB_USER_GRP_NAME"].Value.ToString() == string.Empty || Dgv_EmpList.SelectedRows[0].Cells["MTB_USER_GRP_NAME"].Value.ToString() == "Ptlteam") ? false : true;
            //Cmb_UserGroup.SelectedIndex = -1;
            //Cmb_UserGroup.Text = Convert.ToString(Dgv_EmpList.SelectedRows[0].Cells["MTB_USER_GRP_NAME"].Value).ToString();
            //string strHOT = (Dgv_EmpList.SelectedRows[0].Cells["MTB_HOLIDAY_SALARY"].Value).ToString();
            //if (strHOT == null || strHOT == "") { Txt_HolidayOverTime.Text = "0.000"; }
            //else { Txt_HolidayOverTime.Text = Convert.ToDecimal(Dgv_EmpList.SelectedRows[0].Cells["MTB_HOLIDAY_SALARY"].Value).ToString("0.000"); }
            //string strOT = (Dgv_EmpList.SelectedRows[0].Cells["MTB_OVERTIME_SALARY"].Value).ToString();
            //if (strOT == null || strOT == "") { Txt_OverTime.Text = "0.000"; }
            //else { Txt_OverTime.Text = Convert.ToDecimal(Dgv_EmpList.SelectedRows[0].Cells["MTB_OVERTIME_SALARY"].Value).ToString("0.000"); }

            //string Status = (Dgv_EmpList.SelectedRows[0].Cells["MTB_STATUS"].Value).ToString();


            //Chk_SuspendUser.Checked = (Status == "N") ? true : false;
            //if (Status == "N")
            //{
            //    Txt_EmpId.ReadOnly = Txt_Name.ReadOnly = Txt_PassportNo.ReadOnly =
            //    Txt_Phone.ReadOnly = Txt_Mobile.ReadOnly = true;
            //    Txt_Name.BackColor = System.Drawing.SystemColors.Control;
            //    Txt_Name.ForeColor = Color.Red;

            //    Txt_UserName.ReadOnly = Txt_Reminder.ReadOnly = Txt_Password.ReadOnly =
            //    Txt_ConfirmPassword.ReadOnly = true;
            //    Txt_HealthCertificate.ReadOnly = Txt_SocialNo.ReadOnly = true;
            //    Txt_OverTime.ReadOnly = Txt_HolidayOverTime.ReadOnly = true;
            //    Rbn_ExistingUserGroup.Enabled = false;
            //    //Rbn_ExistingUserGroup.Checked = Rbn_NewUserGroup.Checked = false;
            //    Txt_BaseSalary.ReadOnly = true;
            //    Cmb_CalculationType.Enabled = Cmb_UserGroup.Enabled =
            //       Dtp_StartDate.Enabled = Dtp_WorkingHoursFrom.Enabled = Dtp_WorkingHoursTo.Enabled = Cmb_Weekend.Enabled = Rbn_NewUserGroup.Enabled = false;
            //    Chk_CalculateSalaryFrom.Enabled = Chk_UserToSystem.Enabled = false;
            //}
            //else
            //{
            //    Txt_Name.BackColor = System.Drawing.SystemColors.Window;
            //    Txt_Name.ForeColor = System.Drawing.SystemColors.WindowText;
            //    Txt_Name.ReadOnly = Txt_PassportNo.ReadOnly =
            //    Txt_Phone.ReadOnly = Txt_Mobile.ReadOnly = false;
            //    Txt_UserName.ReadOnly = Txt_Reminder.ReadOnly = Txt_Password.ReadOnly =
            //    Txt_ConfirmPassword.ReadOnly = false;
            //    Txt_HealthCertificate.ReadOnly = Txt_SocialNo.ReadOnly = false;
            //    Txt_OverTime.ReadOnly = Txt_HolidayOverTime.ReadOnly = false;
            //    Rbn_NewUserGroup.Enabled = Rbn_ExistingUserGroup.Enabled = true;
            //    Txt_BaseSalary.ReadOnly = false;
            //    Cmb_CalculationType.Enabled = Cmb_UserGroup.Enabled =
            //       Dtp_StartDate.Enabled = Dtp_WorkingHoursFrom.Enabled = Dtp_WorkingHoursTo.Enabled = Cmb_Weekend.Enabled = Rbn_NewUserGroup.Enabled = true;
            //    Chk_CalculateSalaryFrom.Enabled = Chk_UserToSystem.Enabled = true;
            //}


            //if (ObjEmployeeForm.dgrEmpList.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableAmount = Convert.ToDecimal(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.Remarks = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString();
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString();
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString() != string.Empty)
            //   ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupName = ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString();
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString() != string.Empty)
            //  ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.MonthlyDeduction = Convert.ToDecimal(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
            //if (ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
            //    ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(ObjEmployeeForm.dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
        }
        public bool SaveDrawingClick()
        {
            bool result = false;
            if (DrawingValidation())
            {
                if (ObjEmployeeBALClass.SaveDrawingDetails())
                {

                    CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                    result = true;
                    //GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, Obj_EmpProp.EmpId, "MTB_USER", "Save user drawing details");

                }
            }
            return result;
        }
        public bool SaveNotesClick()
        {
            bool result = false; int Rowcheck = 0;
            //if (!NotesValidation())
            //{
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Notescheckedtype == 3)
            {
                ObjEmployeeBAL.SaveNotesDetails();

                CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                result = true;
                //GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, Obj_EmpProp.EmpId, "MTB_USER", "Save user drawing details");
            }
            else if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Notescheckedtype == 2)
            {
                //if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId)
                ObjempListByOption = ObjEmployeeBAL.Get_UserNameListByOptionID();
                if (ObjempListByOption != null)
                {
                    for (int i = 0; i < ObjempListByOption.Count; i++)
                    {
                        Rowcheck += 1;
                        ObjEmployeeBAL.ObjEmployeeObject.EmpId = (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty) ? ObjempListByOption[i].UserId : Convert.ToInt32(ObjEmployeeBAL.ObjEmployeeObject.TempUserId);
                        if (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty)
                            ObjEmployeeBAL.ObjEmployeeObject.EmpId = ObjempListByOption[i].UserId;
                        if (ObjEmployeeBAL.SaveNotesDetails())
                        {
                            if (Rowcheck == ObjempListByOption.Count)
                            {

                                CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                                result = true;
                                //GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, Obj_EmpProp.EmpName, "MTB_USER", "Save user notes details");
                            }
                        }

                    }
                }
            }
            else
            {
                ObjempListByOption = ObjEmployeeBAL.Get_UserNameListByOptionID();
                if (ObjempListByOption != null)
                {
                    for (int i = 0; i < ObjempListByOption.Count; i++)
                    {
                        Rowcheck += 1;
                        ObjEmployeeBAL.ObjEmployeeObject.EmpId = (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty) ? ObjempListByOption[i].UserId : Convert.ToInt32(ObjEmployeeBAL.ObjEmployeeObject.TempUserId);
                        if (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty)
                            ObjEmployeeBAL.ObjEmployeeObject.EmpId = ObjempListByOption[i].UserId;
                        if (ObjEmployeeBAL.SaveNotesDetails())
                        {
                            if (Rowcheck == ObjempListByOption.Count)
                            {

                                CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                                result = true;
                                //GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, Obj_EmpProp.EmpName, "MTB_USER", "Save user notes details");
                            }
                        }

                    }
                }

            }
            //}
            return result;
        }
        public bool SaveVariableClick()
        {
            bool result = false;
            if (VariableValidation())
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 1) // For All
                {
                    var index = ObjempDictHelper["UserDetail"]; int Rowcheck = 0;
                    for (int i = 0; i < index.Count; i++)
                    {
                        Rowcheck++;
                        ObjEmployeeBAL.ObjEmployeeObject.EmpId = (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty) ? index[i].UserId : Convert.ToInt32(ObjEmployeeBAL.ObjEmployeeObject.TempUserId);
                        ObjEmployeeBALClass.SaveVariableDetails();
                        if (Rowcheck == index.Count)
                        {

                            CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                            result = true;
                        }
                    }
                }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 2)  // For Group
                {
                    int UsergroupId = ObjEmployeeBAL.ObjEmployeeObjectClass.GroupSelectedVaue;
                    var index = ObjempDictHelper["UserDetail"].FindAll(x => x.UserGrpId == UsergroupId);
                    int Rowcheck = 0;
                    for (int i = 0; i < index.Count; i++)
                    {
                        Rowcheck++;
                        ObjEmployeeBAL.ObjEmployeeObject.EmpId = (ObjEmployeeBAL.ObjEmployeeObject.TempUserId == string.Empty) ? index[i].UserId : Convert.ToInt32(ObjEmployeeBAL.ObjEmployeeObject.TempUserId);
                        ObjEmployeeBALClass.SaveVariableDetails();
                        if (Rowcheck == index.Count)
                        {

                            CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                            result = true;
                        }
                    }
                }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 3)  // For Employee
                {
                    if (ObjEmployeeBALClass.SaveVariableDetails())
                    {

                        CommonHelper.GeneralFunction.Information("SaveUser", "User Administrator");
                        result = true;
                    }
                }
            }
            return result;
        }
        public int FindMaxUserGroupId()
        {
            return (ObjEmployeeBALClass.FindMaxUserGroupIdBAL());
        }
        public bool DeleteEmp()
        {
            bool result = false;

            if (ObjEmployeeBAL.CheckUserhasActioninInvoice() == 0)
            {
                if (ObjEmployeeBAL.Delete_EmployeeFormList() > 0)
                {
                    result = true;
                }
            }
            else
                result = false;
            return result;
        }
        public bool DeleteEmpParticulars()
        {
            bool result = false;
            if (ObjEmployeeBAL.DeleteEmpParticulars() > 0)
            {
                result = true;
            }
            else
                result = false;
            return result;
        }

        public bool SaveEmpDetailsClick()
        {
            bool result = false;
            if (EmpDetailsUGrpValidation())
            {
                DataTable TempTable = new DataTable();
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 1 & ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName == string.Empty)
                {
                    if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName == string.Empty)
                        GeneralFunction.Information("GROUPNAMEREQUIRED", "User Administrator");
                    else
                    {

                        int UserId = ObjEmployeeBALClass.SaveEmployeeLimitationDetails(SaveUserGroupList);
                        if (UserId > 0)
                        {
                            //GeneralFunction.InfoMsg("SaveUser", this.Text);
                            //ObjEmployeeForm.FillComboBoxDetails();
                            //ObjEmployeeForm.ClearCheckBoxs();
                            //ObjEmployeeForm.radNewUserGroup.Checked = false;
                            //ObjEmployeeForm.txtNewUserGroup.Visible = false;
                            //ObjEmployeeForm.radExistingUserGroup.Checked = true;
                            //ObjEmployeeForm.cmbUserGroup.Visible = true;
                            //ObjEmployeeForm.txtNewUserGroup.Text = string.Empty;
                            //ObjEmployeeForm.cmbUserGroup.SelectedIndex = -1;
                            result = true;
                            ObjEmployeeBAL.ObjEmployeeObject.SaveDescription = "UsergroupSaved";
                        }
                    }
                }
                else if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 2 & ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName == string.Empty)
                {
                    if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpId == 0) { CommonHelper.GeneralFunction.ErrInfo(Constants.GROUPNAMEREQUIRED, ActionType.Save.ToString()); }
                    else
                    {
                        int UserId = ObjEmployeeBALClass.SaveEmployeeLimitationDetails(SaveUserGroupList);
                        if (UserId > 0)
                        {
                            //GeneralFunction.InfoMsg("SaveUser", this.Text);
                            //ObjEmployeeForm.FillComboBoxDetails();
                            //ObjEmployeeForm.ClearCheckBoxs();
                            //ObjEmployeeForm.radNewUserGroup.Checked = false;
                            //ObjEmployeeForm.txtNewUserGroup.Visible = false;
                            //ObjEmployeeForm.radExistingUserGroup.Checked = true;
                            //ObjEmployeeForm.cmbUserGroup.Visible = true;
                            //ObjEmployeeForm.txtNewUserGroup.Text = string.Empty;
                            //ObjEmployeeForm.cmbUserGroup.SelectedIndex = -1;
                            result = true;
                            ObjEmployeeBAL.ObjEmployeeObject.SaveDescription = "UsergroupSaved";
                        }
                    }
                }
                else
                {
                    if (EmpDetailsUserValidation())
                    {
                        //if (Rbn_ExistingUserGroup.Checked == true)
                        //{
                        //    if (Cmb_UserGroup.SelectedValue == null || Cmb_UserGroup.SelectedValue.ToString() == "")
                        //    { Obj_EmpProp.UserGrpId = "106"; }
                        //    else { Obj_EmpProp.UserGrpId = Cmb_UserGroup.SelectedValue.ToString(); }

                        //    Obj_EmpProp.UserGrpName = (Cmb_UserGroup.Text != "") ? Cmb_UserGroup.Text.ToString() : "Ptlteam";

                        //}
                        //else
                        //{
                        //    Obj_EmpProp.UserGrpId = "000";
                        //    Obj_EmpProp.UserGrpName = Txt_NewUserGroup.Text.ToString();
                        //}


                        ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpId = ObjEmployeeBALClass.SaveEmployeeLimitationDetails(SaveUserGroupList);
                        if (ObjEmployeeBALClass.SaveEmployeeDetails())
                        {
                            if (ObjEmployeeBALClass.SaveEmployeeSalaryDetails())
                            {
                                result = true;
                                ObjEmployeeBAL.ObjEmployeeObject.SaveDescription = "SalarySaved";
                                //if (Txt_EmpId.Text == "")
                                //{
                                //    CommonHelper.GeneralFunction.Information(Constants.EMPLOYEEDETAILSSAVED, ActionType.Save.ToString());
                                //}
                                //else
                                //{
                                //    CommonHelper.GeneralFunction.Information(Constants.EMPLOYEEDETAILSSAVED, ActionType.Save.ToString());
                                //}
                            }
                        }
                    }
                }


                //if (ObjEmployeeBALClass.SaveVariableDetails())
                //{
                //    CommonHelper.GeneralFunction.Information(Constants.EMPLOYEEDETAILSSAVED, ActionType.Save.ToString());
                //}
            }
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjEmployeeBAL.ObjEmployeeObject.EmpName, "Employee Details", "Save user details", Convert.ToInt32(InvoiceAction.No));
            return result;
        }
        private Boolean EmpDetailsUGrpValidation()
        {

            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.DateOfJoin > DateTime.Now.AddDays(1))
            {

                CommonHelper.GeneralFunction.Information("InvalidDate", ActionType.Save.ToString());
                return false;

            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 0)
            {
                CommonHelper.GeneralFunction.Information("CHECKANYONEGROUPTYPE", ActionType.Save.ToString());
                return false;
            }

            if ((ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType != 0 && ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName == string.Empty))
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName == string.Empty)
                {
                    CommonHelper.GeneralFunction.Information("GROUPNAMEEMPLOYEENAMEREQUIRED", ActionType.Save.ToString());
                    return false;
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 1 & ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName == string.Empty)
            {
                //    if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName == string.Empty)
                //    {
                CommonHelper.GeneralFunction.Information(Constants.GROUPNAMEREQUIRED, ActionType.Save.ToString());
                return false;
                //}
            }

            //------------This is commented by Manoj since client asked for "User should be able to change the group privlages without selecting a user name"
            //if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName == string.Empty)
            //{

            //    CommonHelper.GeneralFunction.Information("GROUPNAMEEMPLOYEENAMEREQUIRED", ActionType.Save.ToString());
            //    return false;
            //}
            //--------------------------------------------------------------------------------------------------------------------------------------


            return true;
        }
        private bool EmpDetailsUserValidation()
        {
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName == string.Empty)
            {
                CommonHelper.GeneralFunction.Information("GROUPNAMEEMPLOYEENAMEREQUIRED", ActionType.Save.ToString());
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem == true)
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpOption == 2 && ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 2)
                {
                    if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName == string.Empty)
                    {
                        CommonHelper.GeneralFunction.Information("GROUPNAMEEMPLOYEENAMEREQUIRED", ActionType.Save.ToString());
                        return false;
                    }
                }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpOption == 1 && ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 1)
                {
                    //Error
                    var result = ObjempDictHelper["Usergroup"].Exists(x => x.UserGroupName.ToLower() == ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName.Trim().ToLower());
                    //var test = ObjempDictHelper.FirstOrDefault(x =>
                    //  x.Value.Any(z => z.UserGroupName.Trim().ToLower() == ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName.Trim().ToLower()));
                    if (result == true)
                    {
                        CommonHelper.GeneralFunction.Information("Usergroupalreadyexist", ActionType.Save.ToString());
                        return false;
                    }

                }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName == string.Empty)
                { CommonHelper.GeneralFunction.Information("GROUPNAMEEMPLOYEENAMEREQUIRED", ActionType.Save.ToString()); }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Password != string.Empty)
                {
                    if (ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword != string.Empty)
                    {
                        string str1, str2;
                        str1 = ObjEmployeeBALClass.ObjEmployeeObjectClass.Password;
                        str2 = ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword;
                        if (str1 != str2)
                        {
                            GeneralFunction.Information("PasswordMismatched", ActionType.Save.ToString());
                            ObjEmployeeBALClass.ObjEmployeeObjectClass.Password = string.Empty;
                            // ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword = string.Empty;
                            //ObjEmployeeForm.txtConfirmPassword.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("PasswordMismatched", ActionType.Save.ToString());
                    }
                    if ((ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType == 2) & (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpId == 0))
                    {
                        CommonHelper.GeneralFunction.ErrInfo(Constants.USERGROUPREQUIRED, ActionType.Save.ToString());
                        return false;
                    }
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType == 3)
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem == false)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.HOURLYEMPLOYEECREATEUSERACCOUNT, ActionType.Save.ToString());
                    ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem = true;
                    // ObjEmployeeForm.chkUserToSystem.Checked = true;
                    // ObjEmployeeForm.txtUserName.Focus();
                    return false;
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName != string.Empty)
            {
                if (ObjempListHelper != null)
                {
                    if (ObjempListHelper.Count > 0)
                    {
                        // *******This is changed to check suspened users' and active user name should not be used for new user but deleted users' user name can be used.
                        var findRow = ObjempListHelper.FindAll(x => x.UserName == ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName && x.UserId != ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId);
                        if (findRow.Count > 0)
                        {
                            findRow = findRow.FindAll(x => x.Status >= 1);
                            if (findRow.Count > 0)
                            {
                                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId == 0 || ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpType == "New")
                                {
                                    CommonHelper.GeneralFunction.ErrInfo(Constants.USERNAMEEXISTS, ActionType.Save.ToString());
                                    //  ObjEmployeeForm.txtUserName.SelectAll();
                                    //  ObjEmployeeForm.txtUserName.Focus();
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        //*********************
                    }
                }
            }

            return true;
        }
        public List<EmployeeObjectClass> Get_EmployeeRunTimeScreenLimt()
        {
            return ObjEmployeeBAL.Get_EmployeeRunTimeScreenLimt();
        }
        public Boolean DrawingValidation()
        {
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId == -1)
            {
                // CommonHelper.GeneralFunction.ErrInfo(Constants.USERNAMEREQUIRED, ActionType.Save.ToString());
                GeneralFunction.Information("UserNameIsRequired", ActionType.Save.ToString());
                Control ctl = new Control("cmbDrawForEmployee");
                Employee.ChangeProperties(ctl);
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableAmount == 0)
            {
                // CommonHelper.GeneralFunction.ErrInfo(Constants.AMOUNTREQUIRED, ActionType.Save.ToString());
                GeneralFunction.Information("AmountisRequired", ActionType.Save.ToString());
                Control ctl = new Control("txtDrawAmount");
                Employee.ChangeProperties(ctl);
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Description == string.Empty)
            {
                //CommonHelper.GeneralFunction.ErrInfo(Constants.DESCRIPTIONREQUIRED, ActionType.Save.ToString());
                GeneralFunction.Information("DescriptionisRequired", ActionType.Save.ToString());
                Control ctl = new Control("txtDrawDescription");
                Employee.ChangeProperties(ctl);
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId != 0)
            {
                if (ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 0 && ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId != 101)
                {
                    // CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKAMOUNTCUTOPTION, ActionType.Save.ToString());\
                    GeneralFunction.Information("Pleasecheckanyoneofmonthlycutoption", ActionType.Save.ToString());
                    //Control ctl = new Control("txtDrawAmount");
                    //Employee.ChangeProperties(ctl);
                    return false;
                }
            }
            return true;

        }
        public Boolean NotesValidation()
        {

            if (ObjEmployeeBAL.ObjEmployeeObject.Notescheckedtype == 0)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKANYONEVARIABLE, ActionType.Save.ToString());

                return false;
            }
            else if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Notescheckedtype == 2)
            {
                if (ObjEmployeeBAL.ObjEmployeeObject.NotesforGroup == -1)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.GROUPNAMEREQUIRED, ActionType.Save.ToString());
                    Control ctl = new Control("cmbNotesForGroup");
                    Employee.ChangeProperties(ctl);
                    return false;
                }
            }
            else if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Notescheckedtype == 3)
            {
                if (ObjEmployeeBAL.ObjEmployeeObject.NotesforEmployee == -1)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.EMPLOYEENAMEREQUIRED, ActionType.Save.ToString());
                    Control ctl = new Control("cmbNotesForEmployee");
                    Employee.ChangeProperties(ctl);
                    return false;
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.NoOfTimes == 0)
            {
                GeneralFunction.ErrInfo(Constants.NOOFTIMEREQUIRED, ActionType.Save.ToString());
                Control ctl = new Control("txtNoteTime");
                Employee.ChangeProperties(ctl);
            }

            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.Message == string.Empty)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.MESSAGEREQUIRED, ActionType.Save.ToString());
                Control ctl = new Control("txtNotesMessage");
                Employee.ChangeProperties(ctl);
                return false;
            }
            if (DateTime.Now.Date > Convert.ToDateTime(ObjEmployeeBALClass.ObjEmployeeObjectClass.NotesDate).Date)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.SETVALIDDATE, ActionType.Save.ToString());
                //Dtp_NotesDate.Select();
                //Dtp_NotesDate.Focus();
                return false;
            }
            //if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpId != 0)
            //{
            //    if (ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 0)
            //    {
            //         CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKAMOUNTCUTOPTION, ActionType.Save.ToString());
            //        return false;
            //    }
            //}
            return true;
        }

        public Boolean VariableValidation()
        {
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableID == 0)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.VARIABLEREQUIRED, ActionType.Save.ToString());
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableAmount == 0)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.AMOUNTREQUIRED, ActionType.Save.ToString());
                Control ctl = new Control("txtVarAmount");
                Employee.ChangeProperties(ctl);
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 0)
            {
                CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKANYONEGROUP, ActionType.Save.ToString());
                return false;
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 2)
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupSelectedVaue == -1)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.GROUPNAMEREQUIRED, ActionType.Save.ToString());
                    return false;
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.GroupID == 3)
            {
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeSelectedVaue == -1)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.EMPLOYEENAMEREQUIRED, ActionType.Save.ToString());
                    return false;
                }
            }
            if (ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableID != 104 && ObjEmployeeBALClass.ObjEmployeeObjectClass.VariableID != 105) //104 for Reward and 105 for Incentives
            {
                if (ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 0)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.CHECKAMOUNTCUTOPTION, ActionType.Save.ToString());
                    return false;
                }
                if (ObjEmployeeBALClass.ObjEmployeeObjectClass.MonthlyDeduction == 0)
                {
                    CommonHelper.GeneralFunction.ErrInfo(Constants.AMOUNTCUTOPTIONREQUIRED, ActionType.Save.ToString());
                    return false;
                }
            }
            return true;

        }

        public List<EmployeeObjectClass> Check_UserLogin()
        {
            return ObjempLoginDetails = ObjEmployeeBAL.Check_UserLogin();
        }
        public int Save_UserLoginTimeDetails()
        {
            return ObjEmployeeBAL.Save_UserLoginTimeDetails();
        }
        public int Save_UserLogoutTimeDetails()
        {
            return ObjEmployeeBAL.Save_UserLogoutTimeDetails();
        }
        public void RememberPassword_User()
        {

            ObjEmployeeBALClass.Get_RememberPassword();
        }
        public DataTable Check_WorkStation()
        {
            //GeneralFunction.Trace("Check_WorkStation Start");
            return ObjEmployeeBAL.Get_RegistrationWorkStation();
            //GeneralFunction.Trace("Check_WorkStation End");
        }

        public void DisposeAllListObjects()
        {
            ObjEmployeeBALClass = null;
            Loadds = null;
            dtEmp = null;
            ObjempListHelper = null;
            ObjempDrawHelper = null;
            ObjempNotesHelper = null;
            ObjempListByOption = null;
            ObjempLoginDetails = null;
            ObjTempUserDetails = null;
            ObjEmpVariableList = null;
            //  List<EmployeeObjectClass> Obj = new List<EmployeeObjectClass>();
            ObjempDictHelper = null;
            SaveUserGroupList = null;
        }
    }
}
