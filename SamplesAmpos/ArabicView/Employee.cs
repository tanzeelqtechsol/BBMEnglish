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
using BALHelper;
using System.Threading;
using System.Configuration;



namespace BumedianBM.ArabicView
{
    public partial class Employee : Form, IDisposable
    {
        #region Variables
        EmployeeHelper ObjEmployeeHelper;
        //  EmployeeObjectClass EmployeeObjectClass;
        //   public static List<EmployeeObjectClass> objUsergrouptDAL = new List<EmployeeObjectClass>();

        Dictionary<string, List<EmployeeObjectClass>> dicUserLoad = new Dictionary<string, List<EmployeeObjectClass>>();
        List<EmployeeObjectClass> ObjempLoginDetails = new List<EmployeeObjectClass>();
        //List<EmployeeObjectClass> ObjEmpVariableList = new List<EmployeeObjectClass>();
        List<EmployeeObjectClass> objEmpList;
        MasterDataBALClass ObjMasterDataBALClass = new MasterDataBALClass();
        int DrawEmpID;
        public int NewUserGroupId = 0;
        Boolean saltoweek = false, OTtoWHF = false, rbnTocmb = false;
        //   Paging obj_Paging = new Paging();
        public int SalId = 0, SalaryId = 0;
        public static bool Isaccessrights = true;
        List<EmployeeObjectClass> ObjScreenRightsLimit = new List<EmployeeObjectClass>();
        #endregion

        #region Constructor
        public Employee()
        {
            ObjEmployeeHelper = new EmployeeHelper();
            objEmpList = new List<EmployeeObjectClass>();
            InitializeComponent();
            SetLanguage();
            HideShowControls();
            SetFont();
            // EmployeeObjectClass = new EmployeeObjectClass();
        }

        private void HideShowControls()
        {
            if (!UserScreenLimidations.Notes)
                TabNotes.Dispose();
            btnEmpListNotes.Enabled = UserScreenLimidations.Notes;
            btnEmpListAttendance.Enabled = UserScreenLimidations.TimeAttandance;
            if (!UserScreenLimidations.Drawings)
                TabDrawings.Dispose();
        }
        #endregion

        #region Events

        #region Employee_Load Event


        private void Employee_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpStartDate.Format = DateTimePickerFormat.Custom;
                dtpNotesDate.Format = DateTimePickerFormat.Custom;
                dtpEffectiveDate.Format = DateTimePickerFormat.Custom;
                dtpDrawDate.Format = DateTimePickerFormat.Custom;
                dtpStartDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpNotesDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpEffectiveDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpDrawDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                FillComboBoxDetails();

                LoadEmployeeDetailsList();
                LoadEmployeeNotesList();
                LoadDrawingDetails();
                LoadEmployeeVariableList();
                ClearInputText();
                SelectedTabPage();

                //string startSalary = GeneralOptionSetting.FlagCalculateSalaryFromStartDay.Trim();
                //Lbl_PageNo.Text = obj_Paging.Index_Current + "/" + obj_Paging.Index_Total;

                if (this.Tag.ToString() == "EmpNote")
                {
                    this.TabEmpList.Dispose(); this.TabEmpDetails.Dispose();
                    this.TabEmpVariables.Dispose(); this.TabDrawings.Dispose();
                }
                if (this.Tag.ToString() == "EmpVariable")
                {
                    this.TabEmpList.Dispose(); this.TabEmpDetails.Dispose();
                    this.TabNotes.Dispose(); this.TabDrawings.Dispose();
                }
                if (this.Tag.ToString() == "EmpDraw")
                {

                    this.TabEmpList.Dispose(); this.TabEmpDetails.Dispose();
                    this.TabNotes.Dispose(); this.TabEmpVariables.Dispose();
                    // dtpDrawDate.MaxDate = DateTime.Now.Date;
                }
                txtNewUserGroup.Visible = false;
                SetGrid_color();
            }
            catch (Exception ex)
            {
                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Employee_Load");
            }
        }
        #endregion

        #region Save Events


        private void btnDrawingSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControlForDrawing();
                if (ObjEmployeeHelper.SaveDrawingClick())
                {
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy, "USER", "Save user drawing details", Convert.ToInt32(InvoiceAction.No));
                    LoadDrawingDetails();
                    ClearInputstextDraw();
                }
                else
                {
                    // GeneralFunction.ErrInfo(Constants.EMPLOYEEDETAILSNOTSAVED, ActionType.Information.ToString());
                    GeneralFunction.Information("Employeedetailsnotsaved", ActionType.Information.ToString());
                }
            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnDrawingSave_Click");
            }
        }

        private void btnNotesSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControlForNotes();
                if (ObjEmployeeHelper.NotesValidation())
                {
                    if (ObjEmployeeHelper.SaveNotesClick())
                    {

                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy, "USER", "Save user notes details", Convert.ToInt32(InvoiceAction.No));
                        //  LoadEmployeeNotesList();
                        ClearNotesFormtext();
                        txtUserIdFromGrid.Text = "";
                        LoadEmployeeNotesList();
                        get_NotesAlret();
                    }
                    else
                    {
                        GeneralFunction.ErrInfo(Constants.EMPLOYEEDETAILSNOTSAVED, ActionType.Information.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_NotesSave_Click");
            }
        }


        private void ClearInputstextDraw()
        {

            cmbDrawForEmployee.SelectedIndex = -1;
            dtpDrawDate.Text = "";
            txtDrawAmount.Text = "0.000";
            txtDrawDescription.Text = "";
            txtDrawNote.Text = "";
            radDrawCutThisMonthSalary.Enabled = true;
            radDrawCutNextMonthSalary.Enabled = true;
            radDrawCutThisMonthSalary.Checked = false;
            radDrawCutNextMonthSalary.Checked = false;
        }
        //Desc: Save Functionality for Variable Form.
        private void btnVarSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControlForVariable();
                if (ObjEmployeeHelper.SaveVariableClick())
                {
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy, "USER", "Save user variable details", Convert.ToInt32(InvoiceAction.No));
                    LoadEmployeeVariableList();
                    ClearVariableFormText();
                }
                else
                {
                    GeneralFunction.ErrInfo(Constants.EMPLOYEEDETAILSNOTSAVED, ActionType.Information.ToString());
                }
            }
            catch (Exception ex)
            {
                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnVarSave_Click");
            }
        }


        private void btnDetailSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControlForEmpDetail();
                if (ObjEmployeeHelper.SaveEmpDetailsClick())
                {
                    GeneralObjectClass.UserGroupList = ObjMasterDataBALClass.UserGroupDetailsBal();
                    GeneralObjectClass.UserList = ObjMasterDataBALClass.UserDetailsBal();
                    if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.SaveDescription == "SalarySaved")
                    {
                        ClearInputText();
                        LoadEmployeeDetailsList();
                        FillComboBoxDetails();
                        ClearCheckBoxs();
                        EnableRadioButtonValues();
                        Fill_CurrentEmployeeScreenLimidation();
                        GeneralFunction.Information("SaveUser", this.Text);
                    }
                    else if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.SaveDescription == "UsergroupSaved")
                    {

                        FillComboBoxDetails();
                        ClearCheckBoxs();
                        radNewUserGroup.Checked = false;
                        txtNewUserGroup.Visible = false;
                        radExistingUserGroup.Checked = true;
                        cmbUserGroup.Visible = true;
                        txtNewUserGroup.Text = "";
                        cmbUserGroup.SelectedIndex = -1;
                        GeneralFunction.Information("SaveUser", this.Text);
                    }
                    else
                    {

                        GeneralFunction.Information("Employeedetailsnotsaved", this.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnDetailSave_Click");
            }
        }

        private void Fill_CurrentEmployeeScreenLimidation()
        {

            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserName = GeneralFunction.UserName;
            ObjScreenRightsLimit = ObjEmployeeHelper.Get_EmployeeRunTimeScreenLimt();
            if (ObjScreenRightsLimit.Count > 0)
            {
                SetTheUserScreenLimidations();
            }

        }

        private void SetTheUserScreenLimidations()
        {
            if (ObjScreenRightsLimit.Count > 0)
            {
                int i = 1;
                UserScreenLimidations.SaleInvoice = ObjScreenRightsLimit[i].Flag;
                UserScreenLimidations.SaleReturnInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.FindSaleInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ProformaInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PosScreen = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PosShortcuts = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PurchaseInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PurchaseReturnInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.FindPurchaseInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OrderInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ItemCard = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PrimaryInfo = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OpeningStock = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InventoryAdjustment = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.SpoiledItems = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.AgentFile = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.DeptAdjustment = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Debts = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.BalanceSheet = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ReceiveReceipt = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PayReceipt = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Spending = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Drawings = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.CashCapital = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.BankDeposit = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.BankWithdraw = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.GenPrintBarcode = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Users = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.TimeAttandance = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.SalaryPayment = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Notes = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.UserTracking = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Reports = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Option = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.GeneralDiscount = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.EndOfDays = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.FirstPrice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.WholeSale = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.MinimumPrice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.DateModification = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ModifyInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ModifyTodayInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ModifyPrices = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.TotalField = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.SubTotalField = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InvoiceNavigation = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.DiscountPerc = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.DiscountAmt = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InvoiceNotes = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ExtraCost = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Export = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Import = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ItemCost = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InvPayReceipt = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InvReceiveReceipt = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.InvTotalFields = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PrintBarcode = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Print = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.DeleteItem = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ModifyCost = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ModifyQty = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.ItemInfo = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.RestoreBackUp = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.CleanDB = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabGeneral = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabInvoice = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabPrint = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabItem = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabBackUp = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabPeripherals = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabTax = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabNotification = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabOthers = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.OptionTabChangePass = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.StartNewYear = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.PaySalary = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.SaveBackUp = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.CashDrawer = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Accounts = ObjScreenRightsLimit[i++].Flag;
                UserScreenLimidations.Employee = ObjScreenRightsLimit[i++].Flag;
                // UserScreenLimidations.TotalField
            }
        }

        private void EnableRadioButtonValues()
        {
            radExistingUserGroup.Checked = true;
            radNewUserGroup.Checked = false;
            radNewUserGroup.Enabled = radExistingUserGroup.Enabled = true;
        }
        private void ClearInputText()
        {
            // txtName

            txtName.Text = "";
            txtEmpId.Text = "New";
            txtPassportNo.Text = "";
            txtMobile.Text = "";
            txtPhone.Text = "";
            txtHealthCertificate.Text = "";
            txtSocialNo.Text = "";
            txtBaseSalary.Text = "0.000";
            txtSalesPercentage.Text = "";
            txtOverTime.Text = "0.000";
            // Txt_WorkingHoursFrom.Text = "";
            // Txt_WorkingHoursTo.Text = "";
            txtHolidayOverTime.Text = "0.000";
            txtUserName.Text = "";
            txtReminder.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtNewUserGroup.Text = "";
            cmbWeekend.SelectedIndex = 5;
            cmbCalculationType.SelectedIndex = 0;
            cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
            cmbUserGroup.SelectedIndex = -1;
            cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
            dtpStartDate.Value = DateTime.Now;
            dtpWorkingHoursFrom.Value = Convert.ToDateTime("09:00 AM");
            dtpWorkingHoursTo.Value = Convert.ToDateTime("02:00 PM");
            chkEndTimeShow.Checked = false;

            //Genreal
            chkSaleInvoice.Checked = false;
            chkSaleReturnInvoice.Checked = false;
            chkFindSaleInvoice.Checked = false;
            chkProformaInvoice.Checked = false;
            chkPosScreen.Checked = false;
            chkPosShortcut.Checked = false;
            chkPurchaseInvoice.Checked = false;
            chkPurchaseReturnInvoice.Checked = false;
            chkFindpurchaseInvoice.Checked = false;
            chkOrderInvoice.Checked = false;
            chkItemCard.Checked = false;
            chkPrimaryInfo.Checked = false;
            chkOpenStock.Checked = false;
            chkInventoryadjustment.Checked = false;
            chkSpoiledItems.Checked = false;
            chkAgentFile.Checked = false;
            chkDeptadjust.Checked = false;
            chkDebts.Checked = false;
            chkBalanceSheet.Checked = false;
            chkReceiveReceipt.Checked = false;
            chkPayReceipt.Checked = false;
            chkSpending.Checked = false;
            chkDrawings.Checked = false;
            chkCashCapital.Checked = false;
            chkBankDeposit.Checked = false;
            chkBankWithdraw.Checked = false;
            chkSpoiledItems.Checked = false;
            chkUsers.Checked = false;
            chkTimeAttandance.Checked = false;
            chkSalaryPayment.Checked = false;
            chkNotes.Checked = false;
            chkUserTracking.Checked = false;
            chkReports.Checked = false;
            chkOption.Checked = false;
            chkDiscount.Checked = false;
            chkEndOfDays.Checked = false;

            //Invoice
            chkFirstPrice.Checked = false;
            chkWholeSale.Checked = false;
            chkMinimumPrice.Checked = false;
            chkDateModification.Checked = false;
            chkModifyInvoice.Checked = false;
            chkModifyTodaysInvoice.Checked = false;
            chkModifyPrices.Checked = false;
            chkTotalField.Checked = false;
            chkSubTotalField.Checked = false;
            chkInvoiceNavigation.Checked = false;
            chkDisCountPerc.Checked = false;
            chkDiscountamt.Checked = false;
            chkInvoiceNotes.Checked = false;
            chkExtraCost.Checked = false;
            chkExport.Checked = false;
            chkImport.Checked = false;
            chkItemCost.Checked = false;
            chkInvPayReceipt.Checked = false;
            chkInvRecivRecpt.Checked = false;
            chkInvTotFields.Checked = false;
            chkInvPrintBar.Checked = false;
            chkPrint.Checked = false;
            chkDeleteItem.Checked = false;
            chkModifyCost.Checked = false;
            chkModifyQty.Checked = false;
            chkItemInfo.Checked = false;

            //Functions
            chkRestoreBackUp.Checked = false;
            chkCleanDB.Checked = false;
            chkFunGeneral.Checked = false;
            chkfunInvoice.Checked = false;
            chkFunPrint.Checked = false;
            chkFunItems.Checked = false;
            chkFunBackUp.Checked = false;
            chkFunPeripherals.Checked = false;
            chkFunTax.Checked = false;
            chkFunNotification.Checked = false;
            chkFunOthers.Checked = false;
            chkChangePass.Checked = false;
            chkStartNewYear.Checked = false;
            chkPaySalary.Checked = false;
            chkSaveBackUp.Checked = false;
            chkCashdrawer.Checked = false;
            chkEmployee.Checked = false;
            chkAccounts.Checked = false;
        }
        #endregion

        #region New Events


        private void btnNotesNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearNotesFormtext();
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnNotesNew_Click");
            }
        }

        #endregion

        #region Delete Events
        private void ToolStrip_DeleteEmpList_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrEmpList.SelectedRows.Count > 0)
                {
                    if ((GeneralFunction.Question("AlertDeleteEmployee", this.Text) == DialogResult.Yes))
                    {
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString());
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.InvoiceAction = Convert.ToInt32(InvoiceAction.Yes);
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
                        bool result = ObjEmployeeHelper.DeleteEmp();
                        if (result)
                        {
                            GeneralFunction.Information("DeleteUser", this.Text);
                            LoadEmployeeDetailsList();
                        }
                        else
                        {
                            GeneralFunction.Information("InvolvedInInvoice", this.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "ToolStrip_DeleteEmpList_Click");
            }


        }
        #endregion

        #region RadioButtonEvent


        private void radNewUserGroup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radNewUserGroup.Checked == true)
                {
                    cmbUserGroup.Visible = false;
                    txtNewUserGroup.Visible = true;
                    ClearCheckBoxs();
                }
                else if (radExistingUserGroup.Checked == true)
                {
                    cmbUserGroup.Visible = true;
                    txtNewUserGroup.Visible = false;
                    cmbUserGroup.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "radNewUserGroup_CheckedChanged");
            }
        }
        private void Rbn_Notes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radNotesForGroup.Checked == true)
                {
                    cmbNotesForEmployee.Enabled = false;
                    cmbNotesForGroup.Enabled = true;
                }
                else if (radNotesForEmployee.Checked == true)
                {
                    cmbNotesForGroup.Enabled = false;
                    cmbNotesForEmployee.Enabled = true;
                }
                else
                {
                    cmbNotesForEmployee.Enabled = false;
                    cmbNotesForGroup.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Rbn_Notes_CheckedChanged");
            }
        }
        private void RadVarType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radVarForGroup.Checked == true)
                {
                    cmbVarForEmployee.Enabled = false;
                    cmbVarForGroup.Enabled = true;
                }
                else if (radVarForEmployee.Checked == true)
                {
                    cmbVarForGroup.Enabled = false;
                    cmbVarForEmployee.Enabled = true;
                }
                else
                {
                    cmbVarForGroup.Enabled = false;
                    cmbVarForEmployee.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "RadVarType_CheckedChanged");
            }
        }
        #endregion

        #region Leave Events
        private void Txt_ConfirmPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                string str1, str2;
                str1 = txtPassword.Text;
                str2 = txtConfirmPassword.Text;
                if (str1 != str2)
                {
                    GeneralFunction.Information("PasswordMismatched", this.Text);
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtConfirmPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_ConfirmPassword_Leave");
            }

        }
        private void Txt_BaseSalary_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBaseSalary.Text != "")
                {
                    txtBaseSalary.Text = Convert.ToDecimal(txtBaseSalary.Text).ToString("#######0.000");
                }
            }
            catch (Exception ex)
            {
                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_BaseSalary_Leave");
            }
        }
        private void Txt_OverTime_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtOverTime.Text != "")
                {
                    txtOverTime.Text = Convert.ToDecimal(txtOverTime.Text).ToString("#######0.000");
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_OverTime_Leave");
            }
        }
        private void Txt_DrawAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDrawAmount.Text != "")
                {
                    decimal decDrawAmt = Convert.ToDecimal(txtDrawAmount.Text);
                    txtDrawAmount.Text = decDrawAmt.ToString("#####0.000");
                }
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_DrawAmount_Leave");
            }
        }
        private void Txt_VarAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtVarAmount.Text != "")
                {
                    double decVarAmt = Convert.ToDouble(txtVarAmount.Text);
                    txtVarAmount.Text = decVarAmt.ToString("######0.000");
                }
                else
                {
                    txtVarAmount.Text = "0.000";
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_VarAmount_Leave");
            }
        }
        private void Txt_MonthlyCut_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMonthlyCut.Text != "")
                {
                    double decMonCut = Convert.ToDouble(txtMonthlyCut.Text);
                    double decVarAmt = Convert.ToDouble(txtMonthlyCut.Text);
                    if (decVarAmt > decMonCut)
                    {
                        txtMonthlyCut.Text = decMonCut.ToString("#####0.000");
                    }
                    else
                    {
                        if (decMonCut != 0.0)
                        {
                            if (decVarAmt != decMonCut)
                            {
                                GeneralFunction.Information("MonthlyCutAmountlessthanVariable", this.Text);
                                txtMonthlyCut.SelectAll();
                                txtMonthlyCut.Focus();
                            }
                        }
                        else
                        { txtMonthlyCut.Text = decMonCut.ToString("#####0.000"); }
                    }
                }
            }
            catch (Exception ex)
            {

                //  //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_MonthlyCut_Leave");
            }
        }
        #endregion

        #region "Combo Box Events"
        private void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearCheckBoxs();
                DefaultGroup("0");
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "cmbUserGroup_SelectedIndexChanged");
            }
        }
        private void Cmb_DrawForEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDrawForEmployee.SelectedIndex != -1)
                {
                    if (cmbDrawForEmployee.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        if (cmbDrawForEmployee.SelectedValue.ToString() == "101")
                        {
                            radDrawCutNextMonthSalary.Enabled = radDrawCutThisMonthSalary.Enabled = false;
                            radDrawCutNextMonthSalary.Checked = radDrawCutThisMonthSalary.Checked = false;
                        }
                        else
                        {
                            radDrawCutThisMonthSalary.Enabled = true;
                            radDrawCutNextMonthSalary.Enabled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_DrawForEmployee_SelectedIndexChanged");

            }
        }


        #endregion

        #region Browse Event
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //TabEmployee
            try
            {
                TabEmployee.SelectedTab = TabEmpList;
            }
            catch (Exception ex)
            {

                //   //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnBrowse_Click");
            }
        }
        #endregion

        #region Key Press Events
        private void Txt_DrawAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    e.Handled = (txtDrawAmount.Text.Length < 10) ? false : true;
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((MaskedTextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }


                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);
                    //    Txt_DrawAmount.Focus();
                    //}
                }
            }
            catch (Exception ex)
            {

                //  //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_DrawAmount_KeyPress");
            }
        }

        private void Txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Name_KeyPress");
            }
        }
        private void Txt_PassportNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_PassportNo_KeyPress");
            }
        }

        private void Txt_HealthCertificate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_HealthCertificate_KeyPress");
            }
        }

        private void Txt_SocialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    txtBaseSalary.Focus();
                }
            }
            catch (Exception ex)
            {


                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_SocialNo_KeyPress");
            }
        }

        private void Txt_SalesPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    cmbWeekend.Focus();
                    saltoweek = true;
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_SalesPercentage_KeyPress");
            }
        }

        private void Txt_OverTime_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    txtHolidayOverTime.SelectAll();
                    txtHolidayOverTime.Focus();
                }
                else
                {

                    e.Handled = ((txtOverTime.Text.Length < 8)) ? false : true;
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((MaskedTextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
                //if (e.KeyChar == 46)
                //{
                //    string lDot = Convert.ToString(e.KeyChar);
                //    if (Txt_OverTime.Text.Contains(lDot) == true)
                //    {
                //        e.Handled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_OverTime_KeyPress");
            }
        }

        private void Txt_HolidayOverTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {

                    dtpWorkingHoursFrom.Focus();
                    OTtoWHF = true;

                }
                else
                {
                    e.Handled = ((txtHolidayOverTime.Text.Length < 8)) ? false : true;
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((MaskedTextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
                //if (e.KeyChar == 46)
                //{
                //    string lDot = Convert.ToString(e.KeyChar);
                //    if (Txt_HolidayOverTime.Text.Contains(lDot) == true)
                //    {
                //        e.Handled = true;
                //    }
                //}
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_HolidayOverTime_KeyPress");
            }
        }

        private void Txt_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_UserName_KeyPress");
            }
        }

        private void Txt_Reminder_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Reminder_KeyPress");
            }
        }

        private void Txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                ////GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Password_KeyPress");
            }
        }

        private void Txt_ConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                // //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_ConfirmPassword_KeyPress");
            }
        }

        private void Chk_CalculateSalaryFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    chkUserToSystem.Focus();
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Chk_CalculateSalaryFrom_KeyPress");
            }

        }

        private void Txt_VarNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnVarSave.Focus();
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_VarNote_KeyPress");
            }

        }

        private void Chk_UserToSystem_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (chkUserToSystem.Checked == true)
                    { txtUserName.Focus(); }
                    else { radExistingUserGroup.Focus(); }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Chk_UserToSystem_KeyPress");
            }

        }

        private void Rbn_ExistingUserGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    cmbUserGroup.Focus();
                    rbnTocmb = true;
                }

            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Rbn_ExistingUserGroup_KeyPress");
            }
        }

        private void Txt_BaseSalary_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {

                    if (txtSalesPercentage.Visible == true)
                    {
                        txtSalesPercentage.Focus();
                    }
                    else
                    {
                        cmbWeekend.Focus();
                        saltoweek = true;
                    }

                }
                else
                {
                    e.Handled = ((txtBaseSalary.Text.Length < 10)) ? false : true;
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((TextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }
                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);
                    //}
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_BaseSalary_KeyPress");
            }
        }

        private void Txt_Mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);

                    }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Mobile_KeyPress");
            }
        }

        private void Txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    {
                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_Phone_KeyPress");
            }

        }

        private void Txt_VarAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((TextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }


                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
            }
            catch (Exception ex)
            {


                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_VarAmount_KeyPress");
            }
        }

        private void Txt_MonthlyCut_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.Information("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((TextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }


                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Txt_MonthlyCut_KeyPress");
            }
        }
        private void txtNoteTime_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "txtNoteTime_KeyPress");
            }

        }


        private void txtMonthlyCut_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != 46) && (e.KeyChar != 8))
                    {

                        e.Handled = true;
                        GeneralFunction.ErrInfo("OnlyNumbersAllowed", this.Text);
                    }
                    else
                    {
                        if (e.KeyChar == 46 && ((TextBox)sender).Text.Contains("."))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                    }


                    //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    //{
                    //    e.Handled = true;
                    //    GeneralFunction.InfoMsg("OnlyNumbersAllowed", this.Text);

                    //}
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "txtMonthlyCut_KeyPress");
            }
        }
        private void txtVarNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnVarSave.Focus();
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "txtVarNote_KeyPress");
            }
        }
        #endregion
        #region New Click Events
        private void btnDrawingNew_Click(object sender, EventArgs e)
        {
            try { ClearInputstextDraw(); }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_DrawingNew_Click");
            }
        }

        private void btnEmpListNew_Click(object sender, EventArgs e)
        {
            try
            {
                TabEmployee.SelectedTab = TabEmpDetails;
                ClearInputText();
                radNewUserGroup.Checked = false;
                txtNewUserGroup.Visible = false;
                radExistingUserGroup.Checked = true;
                cmbUserGroup.Visible = true;
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListNew_Click");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearInputText();
                chkSuspendUser.Enabled = false;
                radNewUserGroup.Checked = false;
                txtNewUserGroup.Visible = false;
                radExistingUserGroup.Checked = true;
                cmbUserGroup.Visible = true;
                cmbUserGroup.Enabled = true;
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_New_Click");
            }
        }
        private void btnVarNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearVariableFormText();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnVarNew_Click");
            }
        }

        private void ClearVariableFormText()
        {
            radAdvances.Checked = false;
            radPunishment.Checked = false;
            radNeglect.Checked = false;
            radReward.Checked = false;
            radIncentives.Checked = false;
            radOthers.Checked = false;
            radVarForAll.Checked = false;
            radVarForGroup.Checked = false;
            radVarForEmployee.Checked = false;
            cmbVarForEmployee.Enabled = true;
            cmbVarForGroup.Enabled = true;
            cmbVarForEmployee.SelectedIndex = -1;
            cmbVarForGroup.SelectedIndex = -1;
            txtVarAmount.Text = "0.000";
            txtMonthlyCut.Text = "0.000";
            txtVarNote.Text = string.Empty;
            radCutFromNextMonthVar.Checked = false;
            radCutFromThisMonthVar.Checked = false;
        }
        #endregion

        #region Close Click events
        private void btnDrawingClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnDrawingClose_Click");
            }
        }

        private void btnEmpListClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListClose_Click");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnClose_Click");
            }
        }

        private void btnNotesClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnNotesClose_Click");
            }
        }
        private void btnVarClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnVarClose_Click");
            }
        }
        #endregion

        #region Employee List Details event
        private void btnEmpListDetails_Click(object sender, EventArgs e)
        {
            try
            {
                AssignToEmpDetailsControl();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListDetails_Click");
            }
        }
        #endregion



        #region Default Event
        private void btnDefaultGroup_Click(object sender, EventArgs e)
        {
            try
            {
                ClearCheckBoxs();
                DefaultGroup("1");
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnDefaultGroup_Click");
            }
        }
        #endregion



        private void chkAlertLogin_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAlertLogin.Checked == true)
                { dtpNotesDate.Enabled = false; }
                else { dtpNotesDate.Enabled = true; }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Chk_AlertLogin_CheckedChanged");
            }
        }

        #region Employee List Attendance Event
        private void btnEmpListAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                Entry_Time_Attandance objtimeattandance = new Entry_Time_Attandance();
                objtimeattandance.Show();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListAttendance_Click");
            }
        }
        #endregion

        #region Click Event

        private void ToolStrip_DeleteEmpDrawing_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrEmployeeDrawings.SelectedRows.Count > 0)
                {
                    if ((GeneralFunction.Question("AlertDeleteEmployee", this.Text) == DialogResult.Yes))
                    {
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = Convert.ToInt32(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString());
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.OptionID = Convert.ToInt32(Optiontype.Drawing);
                        bool result = ObjEmployeeHelper.DeleteEmpParticulars();
                        if (result)
                        {
                            GeneralFunction.Information("DeleteUser", this.Text);
                            LoadDrawingDetails();
                        }
                        else
                        {
                            GeneralFunction.Information("InvolvedInInvoice", this.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Employee_Delete");
            }
        }

        private void ToolStrip_DeleteEmpVariable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrEmployeeVariables.SelectedRows.Count > 0)
                {
                    if ((GeneralFunction.Question("AlertDeleteEmployee", this.Text) == DialogResult.Yes))
                    {
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString());
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.OptionID = Convert.ToInt32(Optiontype.Variable);
                        bool result = ObjEmployeeHelper.DeleteEmpParticulars();
                        if (result)
                        {
                            GeneralFunction.Information("DeleteUser", this.Text);
                            LoadEmployeeVariableList();
                        }
                        else
                        {
                            GeneralFunction.Information("InvolvedInInvoice", this.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Employee_Delete");
            }
        }

        private void ToolStrip_DeleteEmpNotes_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrEmployeeNotes.SelectedRows.Count > 0)
                {
                    if ((GeneralFunction.Question("AlertDeleteEmployee", this.Text) == DialogResult.Yes))
                    {
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = Convert.ToInt32(dgrEmployeeNotes.SelectedRows[0].Cells["UserId"].Value.ToString());
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.OptionID = Convert.ToInt32(Optiontype.Notes);
                        bool result = ObjEmployeeHelper.DeleteEmpParticulars();
                        if (result)
                        {
                            GeneralFunction.Information("DeleteUser", this.Text);
                            LoadEmployeeNotesList();
                        }
                        else
                        {
                            GeneralFunction.Information("InvolvedInInvoice", this.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Employee_Delete");
            }
        }
        #endregion
        #region CheckBox Event
        private void chkInvSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (CheckBox chkbox in tabInvoices.Controls)
                {
                    chkbox.Checked = chkInvSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkInvSelectAll_CheckedChanged");
            }
        }

        private void chkFunSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (CheckBox chkbox in tabFunctions.Controls)
                {
                    chkbox.Checked = chkFunSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkFunSelectAll_CheckedChanged");
            }
        }

        private void chkGenSelectdCount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbUserGroup.SelectedValue == null ? 0 : cmbUserGroup.SelectedValue) != 2)//admin
                {
                    int chkedcount = 0;
                    if (!((CheckBox)sender).Checked == true)
                    {
                        chkGenSelectAll.CheckedChanged -= new EventHandler(chkGenSelectAll_CheckedChanged);
                        chkGenSelectAll.Checked = false;
                        chkGenSelectAll.CheckedChanged += new EventHandler(chkGenSelectAll_CheckedChanged);
                    }
                    else
                    {
                        foreach (CheckBox chkbox in tabgeneral.Controls)
                        {
                            string selectAllName = chkbox.Name.ToString();
                            if (selectAllName != "chkGenSelectAll")
                            {
                                if (chkbox.Checked != true)
                                {
                                    return;
                                }
                                else
                                {
                                    chkedcount++;
                                }
                            }
                        }
                        if (chkedcount == tabgeneral.Controls.Count - 1)  // except select all
                        {
                            chkGenSelectAll.CheckedChanged -= new EventHandler(chkGenSelectAll_CheckedChanged);
                            chkGenSelectAll.Checked = true;
                            chkGenSelectAll.CheckedChanged += new EventHandler(chkGenSelectAll_CheckedChanged);
                        }
                    }
                }
                else
                {
                    if (!((CheckBox)sender).Checked == true)
                    {
                        ((CheckBox)sender).Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkGenSelectdCount_CheckedChanged");
            }
        }
        private void chkInvSelectdCount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbUserGroup.SelectedValue == null ? 0 : cmbUserGroup.SelectedValue) != 2)//admin
                {
                    if (((CheckBox)sender).Name == "chkSubTotalField" || ((CheckBox)sender).Name == "chkTotalField")//Added on 30Oct2014 by Meena.R
                    {
                        if (((CheckBox)sender).Checked == true)
                        {
                            chkInvTotFields.Checked = true;
                        }
                    }
                    int chkedcount = 0;
                    if (!((CheckBox)sender).Checked == true)
                    {
                        chkInvSelectAll.CheckedChanged -= new EventHandler(chkInvSelectAll_CheckedChanged);
                        chkInvSelectAll.Checked = false;
                        chkInvSelectAll.CheckedChanged += new EventHandler(chkInvSelectAll_CheckedChanged);

                    }
                    else
                    {

                        foreach (CheckBox chkbox in tabInvoices.Controls)
                        {
                            string selectAllName = chkbox.Name.ToString();
                            if (selectAllName != "chkInvSelectAll")
                            {
                                if (chkbox.Checked != true)
                                {
                                    return;
                                }
                                else
                                {
                                    chkedcount++;
                                }
                            }
                        }
                        if (chkedcount == tabInvoices.Controls.Count - 1)  // except select all
                        {
                            chkInvSelectAll.CheckedChanged -= new EventHandler(chkInvSelectAll_CheckedChanged);
                            chkInvSelectAll.Checked = true;
                            chkInvSelectAll.CheckedChanged += new EventHandler(chkInvSelectAll_CheckedChanged);
                        }
                    }
                }
                else
                {
                    if (!((CheckBox)sender).Checked == true)
                    {
                        ((CheckBox)sender).Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkInvSelectdCount_CheckedChanged");
            }
        }
        private void chkFunSelectdCount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbUserGroup.SelectedValue == null ? 0 : cmbUserGroup.SelectedValue) != 2)//admin
                {
                    int chkedcount = 0;
                    if (!((CheckBox)sender).Checked == true)
                    {
                        chkFunSelectAll.CheckedChanged -= new EventHandler(chkFunSelectAll_CheckedChanged);
                        chkFunSelectAll.Checked = false;
                        chkFunSelectAll.CheckedChanged += new EventHandler(chkFunSelectAll_CheckedChanged);
                    }
                    else
                    {
                        foreach (CheckBox chkbox in tabFunctions.Controls)
                        {
                            string selectAllName = chkbox.Name.ToString();
                            if (selectAllName != "chkFunSelectAll")
                            {
                                if (chkbox.Checked != true)
                                {
                                    return;
                                }
                                else
                                {
                                    chkedcount++;
                                }
                            }
                        }
                        if (chkedcount == tabFunctions.Controls.Count - 1)  // except select all
                        {
                            chkFunSelectAll.CheckedChanged -= new EventHandler(chkFunSelectAll_CheckedChanged);
                            chkFunSelectAll.Checked = true;
                            chkFunSelectAll.CheckedChanged += new EventHandler(chkFunSelectAll_CheckedChanged);
                        }
                    }
                }
                else 
                {
                    if (!((CheckBox)sender).Checked == true)
                    {
                        ((CheckBox)sender).Checked = true;
                    }
                }
            }

            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkFunSelectdCount_CheckedChanged");
            }
        }
        #endregion


        #region KeyLeave event
        private void txtMonthlyCut_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtMonthlyCut.Text != "")
                {
                    double decMonCut = Convert.ToDouble(txtMonthlyCut.Text);
                    double decVarAmt = Convert.ToDouble(txtVarAmount.Text);
                    if (decVarAmt > decMonCut)
                    {
                        txtMonthlyCut.Text = decMonCut.ToString("#####0.000");
                    }
                    else
                    {
                        if (decMonCut != 0.0)
                        {
                            if (decVarAmt != decMonCut)
                            {
                                GeneralFunction.Information("MonthlyCutAmountlessthanVariable", this.Text);
                                txtMonthlyCut.SelectAll();
                                txtMonthlyCut.Focus();
                            }
                        }
                        else
                        { txtMonthlyCut.Text = decMonCut.ToString("#####0.000"); }
                    }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "txtMonthlyCut_Leave");
            }
        }
        #endregion



        #region Employee Note Event
        private void btnEmpListNotes_Click(object sender, EventArgs e)
        {
            try
            {
                TabEmployee.SelectedTab = TabNotes;
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListNotes_Click");
            }
        }
        #endregion

        #region Employee List Month Variable
        private void btnEmpListMonthlyVariables_Click(object sender, EventArgs e)
        {
            try
            {
                TabEmployee.SelectedTab = TabEmpVariables;
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnEmpListMonthlyVariables_Click");
            }
        }
        #endregion

        #region Tab Event
        private void TabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetGrid_color();
                if (TabEmployee.SelectedIndex == 0)
                {
                    if (UserScreenLimidations.Users == true || UserScreenLimidations.Drawings == true || UserScreenLimidations.Employee == true)
                    {
                        txtEmpId.ReadOnly = true;
                        radNewUserGroup.Checked = false;
                        txtNewUserGroup.Visible = false;
                        radExistingUserGroup.Checked = true;
                        cmbUserGroup.Visible = true;
                        dtpWorkingHoursFrom.Text = "09:00 AM";
                        dtpWorkingHoursTo.Text = "02:00 PM";
                    }
                    else
                    {
                        GeneralFunction.ErrInfo(Constants.NORIGHTSTOOPENTAB, ActionType.Information.ToString());
                        TabEmployee.SelectedIndex = 1;
                    }
                }
                dtpDrawDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "TabEmployee_SelectedIndexChanged");
            }
        }
        #endregion

        #endregion

        #region Private Methods

        // Desc: Load Employee Notes into grid
        void LoadEmployeeNotesList()
        {
            dgrEmployeeNotes.AutoGenerateColumns = false;
            dgrEmployeeNotes.DataSource = null;
            BindingSource bindSourceNotes = new BindingSource();
            bindSourceNotes.DataSource = ObjEmployeeHelper.LoadEmployeeNotesDetails();
            dgrEmployeeNotes.DataSource = bindSourceNotes;
        }

        //Desc: Load Employee Drawings into grid 
        void LoadDrawingDetails()
        {
            try
            {
                dgrEmployeeDrawings.AutoGenerateColumns = false;
                dgrEmployeeDrawings.DataSource = null;
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = ObjEmployeeHelper.LoadEmployeeDrawingsDetails();
                dgrEmployeeDrawings.DataSource = bindingSource;
                //dgrEmployeeDrawings.Refresh();
                //string drawdate = DateTime.Now.ToShortDateString();//Commented on 31-May-2014 for Date Format Issues
                //dtpDrawDate.Text = drawdate;//Commented on 31-May-2014 for Date Format Issues
                dtpDrawDate.Value = DateTime.Now;
                //DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Employee", "LoadDrawingDetails");
            }
        }

        //Desc: Load Employee Variables into grid 
        void LoadEmployeeVariableList()
        {
            dgrEmployeeVariables.AutoGenerateColumns = false;
            dgrEmployeeVariables.DataSource = null;

            BindingSource bindSourceVar = new BindingSource();
            bindSourceVar.DataSource = ObjEmployeeHelper.LoadEmployeeVariablesDetails();
            dgrEmployeeVariables.DataSource = bindSourceVar;
            //dtpEffectiveDate.Text = DateTime.Now.ToString();//Commented on 31-May-2014 for Date Format Issues
            dtpEffectiveDate.Value = DateTime.Now;
        }
        void LoadEmployeeDetailsList()
        {
            try
            {
                dgrEmpList.AutoGenerateColumns = false;
                dgrEmpList.DataSource = null;
                dgrEmpList.DataSource = ObjEmployeeHelper.LoadEmployeeDetailsList();
                // Color clr = dgrEmpList.Rows[8].DefaultCellStyle.ForeColor;
                // Color clr = dgrEmpList.Rows[8].DefaultCellStyle.ForeColor;
                SetGrid_color();

                // Color clr1 = dgrEmpList.Rows[8].DefaultCellStyle.ForeColor;
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Employee", "dgrEmployeeList_CellClick");
            }
        }
        public void SetGrid_color()
        {

            for (int k = 0; k < dgrEmpList.RowCount; k++)
            {
                if (dgrEmpList.Rows[k].Cells["Status"].Value != null)
                {
                    string Chk = dgrEmpList.Rows[k].Cells["Status"].Value.ToString();

                    if (Chk == "2")
                    {
                        dgrEmpList.Rows[k].DefaultCellStyle.BackColor = Color.LightGray;
                        dgrEmpList.Rows[k].DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                        dgrEmpList.Rows[k].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        //Desc: Fill All Employee Combo Box
        public void FillComboBoxDetails()
        {
            dicUserLoad = ObjEmployeeHelper.LoadAllComboBoxDetails();
            if (dicUserLoad != null)
            {
                //cmbDrawForEmployee.DataSource = dicUserLoad["Usergroup"];
                //cmbDrawForEmployee.DisplayMember = "UserGroupName";
                //cmbDrawForEmployee.ValueMember = "UserGrpID";
                //cmbDrawForEmployee.SelectedIndex = -1;

                cmbNotesForGroup.DisplayMember = "UserGroupName";
                cmbNotesForGroup.ValueMember = "UserGrpID";
                cmbNotesForGroup.DataSource = dicUserLoad["ComboBoxUsergroup"];

                cmbNotesForGroup.SelectedIndex = -1;

                cmbVarForGroup.DisplayMember = "UserGroupName";
                cmbVarForGroup.ValueMember = "UserGrpID";
                cmbVarForGroup.DataSource = dicUserLoad["ComboBoxUsergroup"];

                cmbVarForGroup.SelectedIndex = -1;

                cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
                cmbUserGroup.DisplayMember = "UserGroupName";
                cmbUserGroup.ValueMember = "UserGrpID";
                cmbUserGroup.DataSource = dicUserLoad["ComboBoxUsergroup"];

                cmbUserGroup.SelectedIndex = -1;
                cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
            }
            if (dicUserLoad != null)
            {
                cmbDrawForEmployee.DisplayMember = "FirstName";
                cmbDrawForEmployee.ValueMember = "UserId";
                cmbDrawForEmployee.DataSource = dicUserLoad["UserDetail"];

                cmbDrawForEmployee.SelectedIndex = -1;
                cmbVarForEmployee.DataSource = dicUserLoad["UserDetail"];
                cmbVarForEmployee.DisplayMember = "FirstName";
                cmbVarForEmployee.ValueMember = "UserId";


                cmbVarForEmployee.SelectedIndex = -1;
                cmbNotesForEmployee.DisplayMember = "FirstName";
                cmbNotesForEmployee.ValueMember = "UserId";
                cmbNotesForEmployee.DataSource = dicUserLoad["UserDetail"];

                cmbNotesForEmployee.SelectedIndex = -1;
            }
            //dtpStartDate.Text = DateTime.Today.Date.ToString();//Commented on 31-May-2014
            //dtpNotesDate.Text = DateTime.Today.Date.ToString();//Commented on 31-May-2014
            dtpStartDate.Value = DateTime.Today.Date;
            dtpNotesDate.Value = DateTime.Today.Date;

        }

        //Desc: Clear all Text box and Radio Button Check Boxes in Employee Notes Form 
        private void ClearNotesFormtext()
        {
            dtpNotesDate.Text = "";
            txtNotesMessage.Text = "";
            txtNoteTime.Text = "1";
            chkAlertLogin.Checked = false;
            radNotesForAll.Checked = false;
            radNotesForGroup.Checked = false;
            radNotesForEmployee.Checked = false;
            cmbNotesForGroup.SelectedIndex = -1;
            cmbNotesForEmployee.SelectedIndex = -1;
            cmbNotesForGroup.Enabled = true;
            cmbNotesForEmployee.Enabled = true;
            txtUserIdFromGrid.Text = "";
            txtAlertIdFromGrid.Text = "";
        }

        //Desc: Set Arabic Language for all Controls.
        private void SetLanguage()
        {
            lblAmountD.Text = Additional_Barcode.GetValueByResourceKey("Amount");
            lblBaseSalary.Text = Additional_Barcode.GetValueByResourceKey("BaseSalary");
            lblCalculationType.Text = Additional_Barcode.GetValueByResourceKey("CalType");
            lblConfirmPassword.Text = Additional_Barcode.GetValueByResourceKey("CPSW");
            lblAmountV.Text = Additional_Barcode.GetValueByResourceKey("Amount");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDateD.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDateV.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDrawDescriptions.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblDrawings.Text = Additional_Barcode.GetValueByResourceKey("Draw");
            lblEmployeeID.Text = Additional_Barcode.GetValueByResourceKey("EmpId");
            lblFrom.Text = Additional_Barcode.GetValueByResourceKey("From");
            lblHealthCertificate.Text = Additional_Barcode.GetValueByResourceKey("HC");
            lblHolidayOverTime.Text = Additional_Barcode.GetValueByResourceKey("HOT");
            lblMobileNo.Text = Additional_Barcode.GetValueByResourceKey("MobNo");
            lblMonthlyCutV.Text = Additional_Barcode.GetValueByResourceKey("MCut");
            lblName.Text = Additional_Barcode.GetValueByResourceKey("Name");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblDrawNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            lblNoteV.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblOterInformation.Text = Additional_Barcode.GetValueByResourceKey("OI");
            lblOverTime.Text = Additional_Barcode.GetValueByResourceKey("OT");
            lblPassportNo.Text = Additional_Barcode.GetValueByResourceKey("PassNo");
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
            lblPercent.Text = Additional_Barcode.GetValueByResourceKey("Percent");
            lblPersonalInformation.Text = Additional_Barcode.GetValueByResourceKey("PI");
            lblPhoneNo.Text = Additional_Barcode.GetValueByResourceKey("PhNo");
            lblReminder.Text = Additional_Barcode.GetValueByResourceKey("Remainder");



            lblSocialID.Text = Additional_Barcode.GetValueByResourceKey("SocialId");
            lblStartDate.Text = Additional_Barcode.GetValueByResourceKey("SD");
            lblSystemUser.Text = Additional_Barcode.GetValueByResourceKey("SU");
            lblTimesToShow.Text = Additional_Barcode.GetValueByResourceKey("TTS");
            lblTo.Text = Additional_Barcode.GetValueByResourceKey("To");
            lblUserGroup.Text = Additional_Barcode.GetValueByResourceKey("UG");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UN");
            lblDrawUserName.Text = Additional_Barcode.GetValueByResourceKey("UN");
            lblVariables.Text = Additional_Barcode.GetValueByResourceKey("Var");
            lblWeekend.Text = Additional_Barcode.GetValueByResourceKey("WE");
            lblWorkingHours.Text = Additional_Barcode.GetValueByResourceKey("WHrs");

            chkAgentFile.Text = Additional_Barcode.GetValueByResourceKey("AgentFile");
            chkAlertLogin.Text = Additional_Barcode.GetValueByResourceKey("AlertLogin");
            chkBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            chkBankDeposit.Text = Additional_Barcode.GetValueByResourceKey("Bankde");
            chkBankWithdraw.Text = Additional_Barcode.GetValueByResourceKey("Bankwith");
            chkCalculateSalaryFrom.Text = Additional_Barcode.GetValueByResourceKey("Calculate");
            chkEndTimeShow.Text = Additional_Barcode.GetValueByResourceKey("ShowET");
            chkCashCapital.Text = Additional_Barcode.GetValueByResourceKey("CashCapital");
            chkDateModification.Text = Additional_Barcode.GetValueByResourceKey("DM");
            chkDebts.Text = Additional_Barcode.GetValueByResourceKey("Debts");
            chkDiscount.Text = Additional_Barcode.GetValueByResourceKey("DiscountForm");
            chkDrawings.Text = Additional_Barcode.GetValueByResourceKey("Drawing");
            chkEndOfDays.Text = Additional_Barcode.GetValueByResourceKey("EndDay");
            chkFindpurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("FPI");
            chkFindSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("FSI");
            chkInventoryadjustment.Text = Additional_Barcode.GetValueByResourceKey("InventoryAdjust");
            chkInvoiceNavigation.Text = Additional_Barcode.GetValueByResourceKey("IN");
            chkInvoiceNotes.Text = Additional_Barcode.GetValueByResourceKey("INotes");
            chkItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            chkMinimumPrice.Text = Additional_Barcode.GetValueByResourceKey("MP");
            chkModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModInv");
            chkModifyPrices.Text = Additional_Barcode.GetValueByResourceKey("Mod");
            chkModifyTodaysInvoice.Text = Additional_Barcode.GetValueByResourceKey("MTI");
            chkNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            chkOption.Text = Additional_Barcode.GetValueByResourceKey("Option");
            chkOrderInvoice.Text = Additional_Barcode.GetValueByResourceKey("OrderInvoice");
            chkPayReceipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            chkPaySalary.Text = Additional_Barcode.GetValueByResourceKey("PaySalary");
            chkPosScreen.Text = Additional_Barcode.GetValueByResourceKey("POSScreen");
            chkPrimaryInfo.Text = Additional_Barcode.GetValueByResourceKey("PrimaryInfo");
            chkPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            chkPrintBarcode.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            chkProformaInvoice.Text = Additional_Barcode.GetValueByResourceKey("PerformanceInvoice");
            chkPurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            chkPurchaseReturnInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurchaseReturnInvoice");
            chkReceiveReceipt.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceipt");
            chkReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            chkSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            chkSaleReturnInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
            chkSaveBackUp.Text = Additional_Barcode.GetValueByResourceKey("SaveBackUp");
            chkSpoiledItems.Text = Additional_Barcode.GetValueByResourceKey("SItem");
            chkSubTotalField.Text = Additional_Barcode.GetValueByResourceKey("STF");
            chkSuspendUser.Text = Additional_Barcode.GetValueByResourceKey("SUSER");
            chkTimeAttandance.Text = Additional_Barcode.GetValueByResourceKey("TA");
            chkUsers.Text = Additional_Barcode.GetValueByResourceKey("UA");
            chkUserToSystem.Text = Additional_Barcode.GetValueByResourceKey("U2S");
            chkUserTracking.Text = Additional_Barcode.GetValueByResourceKey("UserTracking");
            chkWholeSale.Text = Additional_Barcode.GetValueByResourceKey("WS");

            chkPosShortcut.Text = Additional_Barcode.GetValueByResourceKey("POSShortCut");
            chkOpenStock.Text = Additional_Barcode.GetValueByResourceKey("OpeningStock");
            chkDeptadjust.Text = Additional_Barcode.GetValueByResourceKey("DebtAdjustment");
            chkSpending.Text = Additional_Barcode.GetValueByResourceKey("Spending");
            chkSalaryPayment.Text = Additional_Barcode.GetValueByResourceKey("SalaryPayment");
            chkNotes.Text = Additional_Barcode.GetValueByResourceKey("NotesAlert");
            chkFirstPrice.Text = Additional_Barcode.GetValueByResourceKey("FirstPrice");
            chkTotalField.Text = Additional_Barcode.GetValueByResourceKey("TotalField");
            chkDisCountPerc.Text = Additional_Barcode.GetValueByResourceKey("DisCountPrice");
            chkExtraCost.Text = Additional_Barcode.GetValueByResourceKey("ExtraCost");
            chkExport.Text = Additional_Barcode.GetValueByResourceKey("ExportInv");
            chkImport.Text = Additional_Barcode.GetValueByResourceKey("ImportInvoice");
            chkItemCost.Text = Additional_Barcode.GetValueByResourceKey("ItemCostMouse");
            chkInvPayReceipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            chkInvRecivRecpt.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceipt");
            chkInvTotFields.Text = Additional_Barcode.GetValueByResourceKey("InvTotFields");
            chkDeleteItem.Text = Additional_Barcode.GetValueByResourceKey("DeleteItems");
            chkModifyCost.Text = Additional_Barcode.GetValueByResourceKey("ModifyCost");
            chkModifyQty.Text = Additional_Barcode.GetValueByResourceKey("ModifyQty");
            chkItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfo");
            chkRestoreBackUp.Text = Additional_Barcode.GetValueByResourceKey("RestoreBackup");
            chkCleanDB.Text = Additional_Barcode.GetValueByResourceKey("CleanDB");
            chkFunGeneral.Text = Additional_Barcode.GetValueByResourceKey("General");
            chkfunInvoice.Text = Additional_Barcode.GetValueByResourceKey("Invoice");
            chkFunPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            chkFunItems.Text = Additional_Barcode.GetValueByResourceKey("Items");
            chkFunBackUp.Text = Additional_Barcode.GetValueByResourceKey("Backup");
            chkFunPeripherals.Text = Additional_Barcode.GetValueByResourceKey("Peripherals");
            chkFunTax.Text = Additional_Barcode.GetValueByResourceKey("Tax");
            chkFunNotification.Text = Additional_Barcode.GetValueByResourceKey("Notification");
            chkFunOthers.Text = Additional_Barcode.GetValueByResourceKey("Others");
            chkStartNewYear.Text = Additional_Barcode.GetValueByResourceKey("StartNewYear");
            chkCashdrawer.Text = Additional_Barcode.GetValueByResourceKey("OpenCashdrawer");
            chkDiscountamt.Text = Additional_Barcode.GetValueByResourceKey("DiscountAmt");
            chkPrintBarcode.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            chkInvPrintBar.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            chkChangePass.Text = Additional_Barcode.GetValueByResourceKey("ChangePsw");
            chkAccounts.Text = Additional_Barcode.GetValueByResourceKey("Accounts");
            chkEmployee.Text = Additional_Barcode.GetValueByResourceKey("Emp");


            TabEmpDetails.Text = Additional_Barcode.GetValueByResourceKey("EmpDetails");
            TabEmpVariables.Text = Additional_Barcode.GetValueByResourceKey("EmpVar");
            TabEmpList.Text = Additional_Barcode.GetValueByResourceKey("EmpList");
            TabNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            TabDrawings.Text = Additional_Barcode.GetValueByResourceKey("Draw");
            radAdvances.Text = Additional_Barcode.GetValueByResourceKey("Adv");
            radCutFromNextMonthVar.Text = Additional_Barcode.GetValueByResourceKey("CutF");
            radCutFromThisMonthVar.Text = Additional_Barcode.GetValueByResourceKey("CutT");
            radDrawCutNextMonthSalary.Text = Additional_Barcode.GetValueByResourceKey("CutF");
            radDrawCutThisMonthSalary.Text = Additional_Barcode.GetValueByResourceKey("CutT");
            radExistingUserGroup.Text = Additional_Barcode.GetValueByResourceKey("EUG");
            radIncentives.Text = Additional_Barcode.GetValueByResourceKey("Incentives");
            radNeglect.Text = Additional_Barcode.GetValueByResourceKey("Neglect");
            radNewUserGroup.Text = Additional_Barcode.GetValueByResourceKey("NUG");
            radNotesForAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            radNotesForEmployee.Text = Additional_Barcode.GetValueByResourceKey("ForEmp");
            radNotesForGroup.Text = Additional_Barcode.GetValueByResourceKey("NFG");
            radOthers.Text = Additional_Barcode.GetValueByResourceKey("Other");
            radPunishment.Text = Additional_Barcode.GetValueByResourceKey("Punish");
            radReward.Text = Additional_Barcode.GetValueByResourceKey("Reward");
            radVarForAll.Text = Additional_Barcode.GetValueByResourceKey("All");
            radVarForEmployee.Text = Additional_Barcode.GetValueByResourceKey("VarEmp");
            radVarForGroup.Text = Additional_Barcode.GetValueByResourceKey("VarG");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDrawingClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnDrawingNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnDrawingSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnEmpListAttendance.Text = Additional_Barcode.GetValueByResourceKey("EAttList");
            btnEmpListClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnEmpListDetails.Text = Additional_Barcode.GetValueByResourceKey("EDetail");
            btnEmpListMonthlyVariables.Text = Additional_Barcode.GetValueByResourceKey("MonthlyVar");
            btnEmpListNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnEmpListNotes.Text = Additional_Barcode.GetValueByResourceKey("Notes");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnNotesClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnNotesNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnNotesSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnDetailSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnVarClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnVarNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnVarSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnDefaultGroup.Text = Additional_Barcode.GetValueByResourceKey("DG");
            //this.Text = Additional_Barcode.GetValueByResourceKey("UserAdminstrator");

            dgrEmpList.Columns["EmpID"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpId");
            dgrEmpList.Columns["EmpName"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpName");
            dgrEmpList.Columns["ContactNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ContactNo");
            dgrEmpList.Columns["Designation"].HeaderText = Additional_Barcode.GetValueByResourceKey("Designation");
            dgrEmpList.Columns["SocialId"].HeaderText = Additional_Barcode.GetValueByResourceKey("SocialId");
            dgrEmpList.Columns["Salary"].HeaderText = Additional_Barcode.GetValueByResourceKey("Salary");
            dgrEmpList.Columns["MobileNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("MobNo");
            dgrEmpList.Columns["SalaryType"].HeaderText = Additional_Barcode.GetValueByResourceKey("SalaryType");
            dgrEmpList.Columns["Status"].HeaderText = Additional_Barcode.GetValueByResourceKey("Status");
            dgrEmpList.Columns["PassportNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("PassNo");
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Sunday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Monday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Tuesday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Wednesday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Thursday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Friday"));
            cmbWeekend.Items.Add(Additional_Barcode.GetValueByResourceKey("Saturday"));

            cmbCalculationType.Items.Add(Additional_Barcode.GetValueByResourceKey("Monthly"));
            cmbCalculationType.Items.Add(Additional_Barcode.GetValueByResourceKey("Weekly"));
            cmbCalculationType.Items.Add(Additional_Barcode.GetValueByResourceKey("Hourly"));
            cmbCalculationType.Items.Add(Additional_Barcode.GetValueByResourceKey("PercentofSale"));
            dgrEmployeeDrawings.Columns["DrawEmpVariableId"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
            dgrEmployeeDrawings.Columns["DrawUserName"].HeaderText = Additional_Barcode.GetValueByResourceKey("Name");
            dgrEmployeeDrawings.Columns["DrawEffectiveDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("EffectiveDate");
            dgrEmployeeDrawings.Columns["DrawVariableAmount"].HeaderText = Additional_Barcode.GetValueByResourceKey("VariableAmount");
            dgrEmployeeDrawings.Columns["DrawDescription"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgrEmployeeDrawings.Columns["DrawRemarks"].HeaderText = Additional_Barcode.GetValueByResourceKey("Remarks");

            dgrEmployeeVariables.Columns["VarUserId"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
            dgrEmployeeVariables.Columns["VarUName"].HeaderText = Additional_Barcode.GetValueByResourceKey("Name");
            dgrEmployeeVariables.Columns["VariableName"].HeaderText = Additional_Barcode.GetValueByResourceKey("Var");
            dgrEmployeeVariables.Columns["VarEffectiveDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("EffectiveDate");
            dgrEmployeeVariables.Columns["VariableAmount"].HeaderText = Additional_Barcode.GetValueByResourceKey("VariableAmount");
            dgrEmployeeVariables.Columns["VarRemarks"].HeaderText = Additional_Barcode.GetValueByResourceKey("Remarks");
            dgrEmployeeVariables.Columns["VarMonthlyDeduction"].HeaderText = Additional_Barcode.GetValueByResourceKey("MCut");

            dgrEmployeeNotes.Columns["UserId"].HeaderText = Additional_Barcode.GetValueByResourceKey("UserId");
            dgrEmployeeNotes.Columns["UName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UName");
            dgrEmployeeNotes.Columns["MessageTo"].HeaderText = Additional_Barcode.GetValueByResourceKey("MessageTo");
            dgrEmployeeNotes.Columns["NoteDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("Date");
            dgrEmployeeNotes.Columns["NoOfNoteTime"].HeaderText = Additional_Barcode.GetValueByResourceKey("NoOfTimes");
            dgrEmployeeNotes.Columns["NoteMessage"].HeaderText = Additional_Barcode.GetValueByResourceKey("Notes");

            tabgeneral.Text = Additional_Barcode.GetValueByResourceKey("Generaltab");
            tabInvoices.Text = Additional_Barcode.GetValueByResourceKey("Invoicestab");
            tabFunctions.Text = Additional_Barcode.GetValueByResourceKey("Functions");

            chkGenSelectAll.Text = Additional_Barcode.GetValueByResourceKey("SelectAll");
            chkInvSelectAll.Text = Additional_Barcode.GetValueByResourceKey("SelectAll");
            chkFunSelectAll.Text = Additional_Barcode.GetValueByResourceKey("SelectAll");

        }

        //Desc: Set control to object for Drawings
        private void SetControlFromObjectForDrawings()
        {
            cmbDrawForEmployee.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID.ToString();
            DateTime dt = new DateTime();
            dt = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate;
            if (dt != DateTime.MinValue)
                //dtpDrawDate.Text = dt.ToString();//Commented on 31-May-2014 for Date Format Issues
                dtpDrawDate.Value = dt;
            txtDrawAmount.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount.ToString();
            txtDrawDescription.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Description.ToString();
            txtDrawNote.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Remarks.ToString();
        }
        //Desc: Set Object to Control for Drawing
        private void SetObjectFromControlForDrawing()
        {
            if (cmbDrawForEmployee.SelectedValue == null)
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EmpId = -1;
            else
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EmpId = Convert.ToInt32(cmbDrawForEmployee.SelectedValue.ToString()) == -1 ? -1 : Convert.ToInt32(cmbDrawForEmployee.SelectedValue.ToString());
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = cmbDrawForEmployee.Text.ToString() != string.Empty ? cmbDrawForEmployee.Text.ToString() : string.Empty;
            }
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.VariableID = 101;     // By Default Id is 101 For Advance and Drawing.
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EffectiveDate = Convert.ToDateTime(dtpDrawDate.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EffectiveDate = Convert.ToDateTime(dtpDrawDate.Value);
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.VariableAmount = txtDrawAmount.Text.Trim() != string.Empty ? (Convert.ToDecimal(txtDrawAmount.Text.Trim().ToString()) == 0 ? 0 : Convert.ToDecimal(txtDrawAmount.Text.Trim().ToString())) : 0;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = 1;
            if (radDrawCutThisMonthSalary.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.Date;
            }
            if (radDrawCutNextMonthSalary.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 2;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.AddMonths(1);
            }
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remarks = txtDrawNote.Text.Trim().ToString() == string.Empty ? string.Empty : txtDrawNote.Text.Trim().ToString();
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Description = txtDrawDescription.Text.Trim().ToString() == string.Empty ? string.Empty : txtDrawDescription.Text.Trim().ToString();
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.DrawingFlag = 1;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Status = 1;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ModifiedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remove = false;

        }

        private void SetObjectFromControlForNotes()
        {
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.TempUserId = txtUserIdFromGrid.Text != string.Empty ? txtUserIdFromGrid.Text.ToString() : string.Empty;
            if (radNotesForAll.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Notescheckedtype = 1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = "ForALL";
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MessageTo = "ForALL"; //This is added to aviod exception as MessageTo was not supplied. Done By A.Manoj On June28
            }
            else if (radNotesForGroup.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MessageTo = cmbNotesForGroup.SelectedValue != null ? cmbNotesForGroup.Text.ToString() : string.Empty;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Notescheckedtype = 2;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesforGroup = cmbNotesForGroup.SelectedValue != null ? Convert.ToInt32(cmbNotesForGroup.SelectedValue.ToString()) : -1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpId = Convert.ToInt32(cmbNotesForGroup.SelectedIndex.ToString()) != -1 ? Convert.ToInt32(cmbNotesForGroup.SelectedValue.ToString()) : -1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = cmbNotesForGroup.Text.ToString() != string.Empty ? cmbNotesForGroup.Text.ToString() : string.Empty;
            }
            else if (radNotesForEmployee.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesforEmployee = cmbNotesForEmployee.SelectedIndex != -1 ? Convert.ToInt32(cmbNotesForEmployee.SelectedValue.ToString()) : -1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Notescheckedtype = 3;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MessageTo = cmbNotesForEmployee.Text.ToString() != string.Empty ? cmbNotesForEmployee.Text.ToString() : string.Empty;
                // if()
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EmpId = (txtUserIdFromGrid.Text == string.Empty) ? (Convert.ToInt32(cmbNotesForEmployee.SelectedValue.ToString()) != -1 ? Convert.ToInt32(cmbNotesForEmployee.SelectedValue.ToString()) : 0) : Convert.ToInt32(txtUserIdFromGrid.Text.ToString());
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = cmbNotesForEmployee.Text.ToString() != string.Empty ? cmbNotesForEmployee.Text.ToString() : string.Empty;
            }
            else { ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Notescheckedtype = 0; }


            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AlertId = (txtAlertIdFromGrid.Text != "") ? Convert.ToInt32(txtAlertIdFromGrid.Text.ToString()) : 0;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesDate = Convert.ToDateTime(dtpNotesDate.Text.ToString());
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesDate = Convert.ToDateTime(dtpNotesDate.Value);
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfTimes = txtNoteTime.Text.ToString() != string.Empty ? Convert.ToInt32(txtNoteTime.Text.ToString()) : 0;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Message = txtNotesMessage.Text != string.Empty ? txtNotesMessage.Text.ToString() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Status = 1;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remove = false;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ModifiedBy = GeneralFunction.UserId;
            if (chkAlertLogin.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AlertLoginFlag = 1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesDate = DateTime.Now;
            }
            else
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AlertLoginFlag = 0;
                //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesDate = Convert.ToDateTime(dtpNotesDate.Text).Date;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NotesDate = Convert.ToDateTime(dtpNotesDate.Value);
            }




            //if (cmbDrawForEmployee.SelectedValue == null)
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EmpId= -1;
            //else
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EmpId = Convert.ToInt32(cmbDrawForEmployee.SelectedValue.ToString()) == -1 ? -1 : Convert.ToInt32(cmbDrawForEmployee.SelectedValue.ToString());
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.VariableID = 101;     // By Default Id is 101 For Advance and Drawing.
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.EffectiveDate = Convert.ToDateTime(dtpDrawDate.Text.ToString());
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.VariableAmount =txtDrawAmount.Text.Trim()!=string.Empty?(Convert.ToDecimal(txtDrawAmount.Text.Trim().ToString()) == 0 ? 0 : Convert.ToDecimal(txtDrawAmount.Text.Trim().ToString())):0;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = 1;
            //if (radDrawCutThisMonthSalary.Checked == true)
            //{
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 1;
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.Date;
            //}
            //if (radDrawCutNextMonthSalary.Checked == true)
            //{
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 2;
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.AddMonths(1);
            //}
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remarks = txtDrawNote.Text.Trim().ToString() == string.Empty ? string.Empty : txtDrawNote.Text.Trim().ToString();
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Description = txtDrawDescription.Text.Trim().ToString() == string.Empty ? string.Empty : txtDrawDescription.Text.Trim().ToString();
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.DrawingFlag = 1;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Status = 1;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ModifiedBy = GeneralFunction.UserId;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remove = false;

        }

        // Set Object to Control for Variable
        private void SetObjectFromControlForVariable()
        {
            int VarId = 0; int grpID = 0; string grpName = string.Empty; decimal varamt = 0;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.TempUserId = txtVarUserId.Text != string.Empty ? txtVarUserId.Text.ToString() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID = txtVarEmpID.Text.Trim().ToString() != string.Empty ? (Convert.ToInt32(txtVarEmpID.Text) == 0 ? 0 : Convert.ToInt32(txtVarEmpID.Text)) : 0;
            // ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmpId = txtVarUserId.Text.Trim().ToString() != string.Empty ? (Convert.ToInt32(txtVarUserId.Text) == 0 ? 0 : Convert.ToInt32(txtVarUserId.Text)) : 0;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount = txtVarAmount.Text.Trim().ToString() != string.Empty ? (Convert.ToDecimal(txtVarAmount.Text) == 0 ? 0 : Convert.ToDecimal(txtVarAmount.Text)) : 0;
            varamt = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount;
            //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(dtpEffectiveDate.Text);//Commented on 31-May-2014 for Date Format Issues
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(dtpEffectiveDate.Value);
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Remarks = txtVarNote.Text.Trim() == string.Empty ? string.Empty : txtVarNote.Text.Trim();
            if (txtMonthlyCut.Text.Trim() != string.Empty)
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.MonthlyDeduction = Convert.ToDecimal(txtMonthlyCut.Text) == 0 ? 0 : Convert.ToDecimal(txtMonthlyCut.Text);
            if (radAdvances.Checked == true) { VarId = 101; }
            if (radPunishment.Checked == true) { VarId = 102; }
            if (radNeglect.Checked == true) { VarId = 103; }
            if (radReward.Checked == true) { VarId = 104; }
            if (radIncentives.Checked == true) { VarId = 105; }
            if (radOthers.Checked == true) { VarId = 106; }
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableID = VarId;
            if (radVarForAll.Checked == true)
            {
                grpID = 1; grpName = "ForAll";
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = "ForAll";
            }
            if (radVarForGroup.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = cmbVarForGroup.Text.ToString() != string.Empty ? cmbVarForGroup.Text.ToString() : string.Empty;
                grpName = cmbVarForGroup.SelectedText.ToString();
                grpID = 2;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupSelectedVaue = Convert.ToInt32(cmbVarForGroup.SelectedIndex.ToString()) != -1 ? Convert.ToInt32(cmbVarForGroup.SelectedValue.ToString()) : -1;
            }
            if (radVarForEmployee.Checked == true)
            {
                grpID = 3;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.PerformedBy = cmbVarForEmployee.Text.ToString() != string.Empty ? cmbVarForEmployee.Text.ToString() : string.Empty;
                grpName = cmbVarForEmployee.SelectedText.ToString();
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeSelectedVaue = Convert.ToInt32(cmbVarForEmployee.SelectedIndex.ToString()) != -1 ? Convert.ToInt32(cmbVarForEmployee.SelectedValue.ToString()) : -1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmpId = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeSelectedVaue;
            }
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupID = grpID;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupName = grpName;
            if (radCutFromThisMonthVar.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 1;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.Date;
            }
            else
            {
                if (radReward.Checked == true || radIncentives.Checked == true)
                {
                    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.Date;
                }
                else
                {
                    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.AddMonths(1);
                }
            }
            if (radCutFromNextMonthVar.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption = 2;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.StartMonthDeduction = DateTime.Now.AddMonths(1);
            }
            if (radReward.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction = Convert.ToDecimal(0.000);
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = 1;
            }
            else if (radPunishment.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction = txtMonthlyCut.Text.Trim().ToString() != string.Empty ? Convert.ToDecimal(txtMonthlyCut.Text.ToString()) : 0;
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = 1;
            }
            // This is commented by Manoj due to Monthly deduction was updated updated with variable amount
            //else
            //{
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction = (radIncentives.Checked == true) ? Convert.ToDecimal(0.000) : Convert.ToDecimal(ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount);
            //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = (radIncentives.Checked == true) ? Convert.ToInt16(1) : Convert.ToInt16((Convert.ToDecimal(varamt) / Convert.ToDecimal(varamt)));
            //}

            //------------------------------------ This below lines are added due to above issue

            else if (radIncentives.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction = Convert.ToDecimal(0.000);
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = Convert.ToInt16(1);
            }
            else
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction = Convert.ToDecimal(ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.MonthlyDeduction);
                if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction != 0)
                {
                    decimal monthlydeduct = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.MonthlyDeduction;
                    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.NoOfInstallment = Convert.ToInt16((Convert.ToDecimal(varamt) / Convert.ToDecimal(monthlydeduct)));
                }

            }

            //-----------------------------------------------

            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.DrawingFlag = 0;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Status = 1;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ModifiedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remove = false;
        }
        private void SetControlFromObjectForVariable()
        {
            int VarId = 0; int grpID = 0; string grpName = string.Empty;
            txtVarEmpID.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID.ToString();
            txtVarAmount.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount.ToString();
            if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate != DateTime.MinValue)
            {
                //dtpEffectiveDate.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate.ToString();//Commented on 31-May-2014 for Date Format Issues
                dtpEffectiveDate.Value = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate;
            }
            txtVarNote.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Remarks;
            VarId = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableID;
            if (VarId == 101) { radAdvances.Checked = true; }
            if (VarId == 102) { radPunishment.Checked = true; }
            if (VarId == 103) { radNeglect.Checked = true; }
            if (VarId == 104) { radReward.Checked = true; }
            if (VarId == 105) { radIncentives.Checked = true; }
            if (VarId == 106) { radOthers.Checked = true; }
            grpID = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupID;
            grpName = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupName;
            if (grpID == 1) { radVarForAll.Checked = true; }
            if (grpID == 2) { radVarForGroup.Checked = true; cmbVarForGroup.SelectedText = grpName; }
            if (grpID == 3) { radVarForEmployee.Checked = true; cmbVarForEmployee.Text = grpName; }
            txtMonthlyCut.Text = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.MonthlyDeduction.ToString();
        }
        private void SetObjectFromControlForEmpDetail()
        {
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.DateOfJoin = Convert.ToDateTime(dtpStartDate.Value.Date);
            if (radNewUserGroup.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpOption = 1;
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType = 1;
                NewUserGroupId = ObjEmployeeHelper.FindMaxUserGroupId();
                cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
                cmbUserGroup.SelectedIndex = -1;
                cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
            }
            if (radExistingUserGroup.Checked == true)
            {

                ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpOption = 2;
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpType = 2;
            }
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGrpId = Convert.ToInt32(cmbUserGroup.SelectedValue) != 0 ? Convert.ToInt32(cmbUserGroup.SelectedValue) : 0;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserGroupName = cmbUserGroup.Text != string.Empty ? cmbUserGroup.Text.ToString() : (txtNewUserGroup.Text != string.Empty ? txtNewUserGroup.Text : string.Empty);
            if (txtEmpId.Text != string.Empty)
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpType = txtEmpId.Text.Trim() == "New" ? "New" : txtEmpId.Text.Trim();
            // ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.ScreenID = GetCheckBoxsValues();
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PassportNo = txtPassportNo.Text != string.Empty ? txtPassportNo.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.HealthCertificate = txtHealthCertificate.Text != string.Empty ? txtHealthCertificate.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.SocialId = txtSocialNo.Text != string.Empty ? txtSocialNo.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.MobileNo = txtMobile.Text != string.Empty ? txtMobile.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PhoneNo = txtPhone.Text != string.Empty ? txtPhone.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EmpName = txtName.Text != string.Empty ? txtName.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = txtUserName.Text != string.Empty ? txtUserName.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Password = GeneralFunction.Encrypt(txtPassword.Text.Trim());
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PwdReminder = txtReminder.Text != string.Empty ? txtReminder.Text.Trim() : string.Empty;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword = GeneralFunction.Encrypt(txtConfirmPassword.Text.Trim());
            if (txtSalesPercentage.Text.Trim() != string.Empty)
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PercSales = Convert.ToDecimal(txtSalesPercentage.Text.Trim()) != 0 ? Convert.ToDecimal(txtSalesPercentage.Text.ToString()) : 0;
            else
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PercSales = 0;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.OverTimeSal = txtOverTime.Text.Trim() != string.Empty ? Convert.ToDecimal(txtOverTime.Text.ToString()) : 0;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.HolidaySal = txtHolidayOverTime.Text.Trim() != string.Empty ? Convert.ToDecimal(txtHolidayOverTime.Text.ToString()) : 0;
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = txtEmpId.Text.Trim() == "New" ? 0 : Convert.ToInt32(txtEmpId.Text.Trim());
            // ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.ScreenID = GetCheckBoxsValues();
            if ((txtUserName.Text != string.Empty) && (radNewUserGroup.Checked || radExistingUserGroup.Checked)) { chkUserToSystem.Checked = true; ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem = true; }
            if (chkUserToSystem.Checked == true) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeUserFlag = 1; } // 1 means User.
            else { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EmployeeUserFlag = 0; } // 0 means Employee if so employee does not have rights to login.
            if (cmbWeekend.SelectedIndex == 0) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 1; }
            if (cmbWeekend.SelectedIndex == 1) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 2; }
            if (cmbWeekend.SelectedIndex == 2) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 3; }
            if (cmbWeekend.SelectedIndex == 3) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 4; }
            if (cmbWeekend.SelectedIndex == 4) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 5; }
            if (cmbWeekend.SelectedIndex == 5) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 6; }
            if (cmbWeekend.SelectedIndex == 6) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = 7; }
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = cmbCalculationType.SelectedIndex;

            //if (cmbCalculationType.SelectedIndex == 0) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = 1; }
            //if (cmbCalculationType.SelectedIndex == 1) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = 2; }
            //if (cmbCalculationType.SelectedIndex == 2) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = 3; }
            //if (cmbCalculationType.SelectedIndex == 3) { ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = 4; }
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Designation = cmbUserGroup.Text != string.Empty ? cmbUserGroup.Text.ToString() : (txtNewUserGroup.Text != string.Empty ? txtNewUserGroup.Text : string.Empty);
            //ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.StartWorkHour = Convert.ToDateTime(dtpWorkingHoursFrom.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            //ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EndWorkHour = Convert.ToDateTime(dtpWorkingHoursTo.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.StartWorkHour = Convert.ToDateTime(dtpWorkingHoursFrom.Value);
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EndWorkHour = Convert.ToDateTime(dtpWorkingHoursTo.Value);
            ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.SalaryId = SalId == 0 ? 0 : SalId;
            if (txtBaseSalary.Text.Trim().ToString() != string.Empty)
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.BasicSalary = Convert.ToDecimal(txtBaseSalary.Text) == 0 ? 0 : Convert.ToDecimal(txtBaseSalary.Text);
            else
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.BasicSalary = 0;
            if (chkSuspendUser.Checked == true)
            {
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Status = 2;
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Remove = true;
            }
            else
            {
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Status = 1;
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Remove = false;
            }
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.CreatedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ModifiedBy = GeneralFunction.UserId;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.ShowEndTime = chkEndTimeShow.Checked;
            GetCheckBoxsValues();
        }

        private void AssignToEmpDetailsControl()
        {

            cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
            cmbUserGroup.SelectedIndex = -1;
            cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
            //cmbUserGroup.Text = Convert.ToString(dgrEmpList.SelectedRows[0].Cells["UserGroupName"].Value).ToString();this line commended by Meena.R on 11Nov2014 unable to  see the user group
            cmbUserGroup.SelectedValue = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["UserGroupID"].Value);
            if (Isaccessrights)
            {
                TabEmployee.SelectedTab = TabEmpDetails;
                chkSuspendUser.Enabled = true;

                if (dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString() != string.Empty)
                    txtEmpId.Text = dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString() != string.Empty)
                    txtName.Text = dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString() != string.Empty)
                    txtPassportNo.Text = dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString() != string.Empty)
                    txtPhone.Text = dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString() != string.Empty)
                    txtMobile.Text = dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString();
                //dtpStartDate.Text = (((dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value == "") | (dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value is DBNull)) ? DateTime.Now : Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value.ToString())).ToString();//Commented on 31-May-2014 for Date Format issues
                dtpStartDate.Value = (((dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value == "") | (dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value is DBNull)) ? DateTime.Now : Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value));
                if (dgrEmpList.SelectedRows[0].Cells["HealthCertificate"].Value.ToString() != string.Empty)
                    txtHealthCertificate.Text = dgrEmpList.SelectedRows[0].Cells["HealthCertificate"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["SocialId"].Value.ToString() != string.Empty)
                    txtSocialNo.Text = dgrEmpList.SelectedRows[0].Cells["SocialId"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString() != null)
                    txtBaseSalary.Text = dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString() != null)
                    txtSalesPercentage.Text = dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString();
                if (dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value != null)
                {
                    if (dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value.ToString() != string.Empty)
                    {
                        //dtpWorkingHoursFrom.Text = dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value.ToString();//Commented on 31-May-2014 for Date Format Issues
                        dtpWorkingHoursFrom.Value = Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value);
                    }
                }
                else
                    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.StartWorkHour = Convert.ToDateTime("09:00 AM");
                if (dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value != null)
                {
                    if (dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value.ToString() != string.Empty)
                    {
                        //dtpWorkingHoursTo.Text = dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value.ToString();//Commented on 31-May-2014 for Date Format Issues
                        dtpWorkingHoursTo.Value = Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value);
                    }
                }
                else
                    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EndWorkHour = Convert.ToDateTime("02:00 PM");

                if (Convert.ToBoolean(dgrEmpList.SelectedRows[0].Cells["ShowEndTime"].Value))
                    chkEndTimeShow.Checked = true;
                else
                    chkEndTimeShow.Checked = false;

                int salaryType = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["CalcType"].Value.ToString());
                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = salaryType;
                cmbCalculationType.SelectedIndex = salaryType;
                SalId = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["SalaryIds"].Value.ToString());
                int val = Convert.ToInt16(dgrEmpList.SelectedRows[0].Cells["EmployeeUserFlag"].Value);
                if (val == 1)
                {
                    chkUserToSystem.Checked = true;
                    txtUserName.Text = dgrEmpList.SelectedRows[0].Cells["EmpListUName"].Value != null ?
                                       (dgrEmpList.SelectedRows[0].Cells["EmpListUName"].Value.ToString() != string.Empty
                                       ? dgrEmpList.SelectedRows[0].Cells["EmpListUName"].Value.ToString() : string.Empty) : string.Empty;

                    txtReminder.Text = dgrEmpList.SelectedRows[0].Cells["PasswordReminder"].Value != null ?
                                       (dgrEmpList.SelectedRows[0].Cells["PasswordReminder"].Value.ToString() != string.Empty
                                       ? dgrEmpList.SelectedRows[0].Cells["PasswordReminder"].Value.ToString() : string.Empty) : string.Empty;
                    string password = string.Empty;
                    password = GeneralFunction.Decrypt(dgrEmpList.SelectedRows[0].Cells["Password"].Value.ToString());

                    txtPassword.Text = password != string.Empty ? password : string.Empty;

                    txtConfirmPassword.Text = password != string.Empty ? password : string.Empty;
                }
                else
                {
                    chkUserToSystem.Checked = false;
                    txtUserName.Text = string.Empty;
                    txtReminder.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }
                int Day = 0;
                if (dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value != null)
                {
                    Day = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["WeekendDay"].Value.ToString());
                    Day--; // 
                }

                ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = Day;
                cmbWeekend.SelectedIndex = Day;
                if (dgrEmpList.SelectedRows[0].Cells["Holiday_Salary"].Value != null)
                {
                    string HolSal = dgrEmpList.SelectedRows[0].Cells["Holiday_Salary"].Value.ToString();

                    txtHolidayOverTime.Text = HolSal;
                }
                if (dgrEmpList.SelectedRows[0].Cells["Holiday_Salary"].Value != null)
                {
                    string OverSal = dgrEmpList.SelectedRows[0].Cells["OverTimeSalary"].Value.ToString();
                    txtOverTime.Text = OverSal;
                }
            }
            Isaccessrights = true;
            //if (dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserId = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["EmpID"].Value.ToString());
            //if (dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = dgrEmpList.SelectedRows[0].Cells["EmpName"].Value.ToString();
            //if (dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PassportNo = dgrEmpList.SelectedRows[0].Cells["PassportNo"].Value.ToString();
            //if (dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PhoneNo = dgrEmpList.SelectedRows[0].Cells["ContactNo"].Value.ToString();
            //if (dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.MobileNo = dgrEmpList.SelectedRows[0].Cells["MobileNo"].Value.ToString();
            //ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.DateOfJoin = ((dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value == "") | (dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value is DBNull)) ? DateTime.Now : Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["DateOfJoin"].Value.ToString());
            //if (dgrEmpList.SelectedRows[0].Cells["HealthCertificate"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.HealthCertificate = dgrEmpList.SelectedRows[0].Cells["HealthCertificate"].Value.ToString();
            //if (dgrEmpList.SelectedRows[0].Cells["SocialId"].Value.ToString() != string.Empty)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.SocialId = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["SocialId"].Value.ToString());
            //if (dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString() != null)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.BasicSalary = Convert.ToDecimal(dgrEmpList.SelectedRows[0].Cells["Salary"].Value.ToString());
            //else
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.BasicSalary = 0;
            //if (dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString() != null)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PercSales = Convert.ToDecimal(dgrEmpList.SelectedRows[0].Cells["PercSales"].Value.ToString());
            //else
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PercSales = 0;
            //if (dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value.ToString() != null)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.StartWorkHour = Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["StartWorkHours"].Value.ToString());
            //else
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.StartWorkHour = Convert.ToDateTime("09:00 AM");

            //if (dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value.ToString() != string.Empty || dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value.ToString() != null)
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EndWorkHour = Convert.ToDateTime(dgrEmpList.SelectedRows[0].Cells["EndWorkHours"].Value.ToString());
            //else
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.EndWorkHour = Convert.ToDateTime("02:00 PM");
            //int CalcType = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["CalcType"].Value.ToString());
            //ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.CalcType = CalcType;


            //SalaryId = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["SalaryID"].Value.ToString());
            //int val = Convert.ToInt16(dgrEmpList.SelectedRows[0].Cells["EmployeeUserFlag"].Value);
            //if (val == 1)
            //{
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem = true;
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = dgrEmpList.SelectedRows[0].Cells["EmpListUName"].Value.ToString();
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PwdReminder = dgrEmpList.SelectedRows[0].Cells["PasswordReminder"].Value.ToString();
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Password = dgrEmpList.SelectedRows[0].Cells["Password"].Value.ToString();
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword = dgrEmpList.SelectedRows[0].Cells["Password"].Value.ToString();
            //}
            //else
            //{
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserToSystem = false;
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = string.Empty;
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PwdReminder = string.Empty;
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.Password = string.Empty;
            //    ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.ConfirmPassword = string.Empty;
            //}

            //int Day = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["MTB_WEEKEND_DAY"].Value.ToString());
            //ObjEmployeeHelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.WeekEnd = Day;






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

            //}
            // }
            chkSuspendUser.Checked = dgrEmpList.SelectedRows[0].Cells["Status"].Value.ToString() == "2" ? true : false;
            cmbUserGroup.Enabled = Convert.ToInt32(dgrEmpList.SelectedRows[0].Cells["EmpID"].Value)==101?false:true;
        }

        void get_NotesAlret()
        {
            string msg = string.Empty;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.LoginUserName = GeneralFunction.UserName;
            ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.LoginPassword = GeneralFunction.LoginPassword;
            ObjempLoginDetails = ObjEmployeeHelper.Check_UserLogin();
            for (int i = 0; i < ObjempLoginDetails.Count; i++)
            {
                if (ObjempLoginDetails[i].Notes.ToString() != null && ObjempLoginDetails[i].Notes.ToString() != string.Empty)
                {
                    msg = msg + "\n\r\n\r" + ObjempLoginDetails[i].Notes.ToString() + "\n" + "Date- " + Convert.ToDateTime(ObjempLoginDetails[i].NotesDate);
                }
            }
            if (msg != string.Empty)
            {
                GeneralFunction.Message = msg;
            }
            //if (dt.Rows.Count > 0)
            //{
            //    GeneralFunction.Message = dt.Rows[0]["DTB_MESSAGE"].ToString();
            //}


        }

        private void SelectedTabPage()
        {

            string strTag = this.Tag.ToString();
            if (strTag != null && strTag != "")
            {
                switch (strTag)
                {
                    case "EmpList":
                        {
                            TabEmployee.SelectedIndex = 4;
                            break;
                        }
                    case "EmpDetail":
                        {
                            TabEmployee.SelectedIndex = 0;
                            break;
                        }
                    case "EmpNote":
                        {
                            TabEmployee.SelectedIndex = 1;

                            break;
                        }
                    case "EmpVariable":
                        {
                            TabEmployee.SelectedIndex = 2;

                            break;
                        }
                    case "EmpDraw":
                        {
                            TabEmployee.SelectedIndex = 3;
                            break;
                        }
                    default:
                        {
                            TabEmployee.SelectedIndex = 0;
                            break;
                        }
                }
            }


        }
        public void ClearCheckBoxs()
        {
            //Genreal
            chkSaleInvoice.Checked = false;
            chkSaleReturnInvoice.Checked = false;
            chkFindSaleInvoice.Checked = false;
            chkProformaInvoice.Checked = false;
            chkPosScreen.Checked = false;
            chkPosShortcut.Checked = false;
            chkPurchaseInvoice.Checked = false;
            chkPurchaseReturnInvoice.Checked = false;
            chkFindpurchaseInvoice.Checked = false;
            chkOrderInvoice.Checked = false;
            chkItemCard.Checked = false;
            chkPrimaryInfo.Checked = false;
            chkOpenStock.Checked = false;
            chkInventoryadjustment.Checked = false;
            chkSpoiledItems.Checked = false;
            chkAgentFile.Checked = false;
            chkDeptadjust.Checked = false;
            chkDebts.Checked = false;
            chkBalanceSheet.Checked = false;
            chkReceiveReceipt.Checked = false;
            chkPayReceipt.Checked = false;
            chkSpending.Checked = false;
            chkDrawings.Checked = false;
            chkCashCapital.Checked = false;
            chkBankDeposit.Checked = false;
            chkBankWithdraw.Checked = false;
            chkSpoiledItems.Checked = false;
            chkUsers.Checked = false;
            chkTimeAttandance.Checked = false;
            chkSalaryPayment.Checked = false;
            chkNotes.Checked = false;
            chkUserTracking.Checked = false;
            chkReports.Checked = false;
            chkOption.Checked = false;
            chkDiscount.Checked = false;
            chkEndOfDays.Checked = false;

            //Invoice
            chkFirstPrice.Checked = false;
            chkWholeSale.Checked = false;
            chkMinimumPrice.Checked = false;
            chkDateModification.Checked = false;
            chkModifyInvoice.Checked = false;
            chkModifyTodaysInvoice.Checked = false;
            chkModifyPrices.Checked = false;
            chkTotalField.Checked = false;
            chkSubTotalField.Checked = false;
            chkInvoiceNavigation.Checked = false;
            chkDisCountPerc.Checked = false;
            chkDiscountamt.Checked = false;
            chkInvoiceNotes.Checked = false;
            chkExtraCost.Checked = false;
            chkExport.Checked = false;
            chkImport.Checked = false;
            chkItemCost.Checked = false;
            chkInvPayReceipt.Checked = false;
            chkInvRecivRecpt.Checked = false;
            chkInvTotFields.Checked = false;
            chkInvPrintBar.Checked = false;
            chkPrint.Checked = false;
            chkDeleteItem.Checked = false;
            chkModifyCost.Checked = false;
            chkModifyQty.Checked = false;
            chkItemInfo.Checked = false;

            //Functions
            chkRestoreBackUp.Checked = false;
            chkCleanDB.Checked = false;
            chkFunGeneral.Checked = false;
            chkfunInvoice.Checked = false;
            chkFunPrint.Checked = false;
            chkFunItems.Checked = false;
            chkFunBackUp.Checked = false;
            chkFunPeripherals.Checked = false;
            chkFunTax.Checked = false;
            chkFunNotification.Checked = false;
            chkFunOthers.Checked = false;
            chkChangePass.Checked = false;
            chkStartNewYear.Checked = false;
            chkPaySalary.Checked = false;
            chkSaveBackUp.Checked = false;
            chkCashdrawer.Checked = false;
            chkAccounts.Checked = false;
            chkEmployee.Checked = false;
        }
        private void GetCheckBoxsValues()
        {
            if (EmployeeHelper.SaveUserGroupList != null)
            {
                EmployeeHelper.SaveUserGroupList.Clear();
            }
            bool flag; int screenid;
            UpdateList(screenid = Convert.ToInt32(chkSaleInvoice.Tag.ToString()), flag = (chkSaleInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSaleReturnInvoice.Tag.ToString()), flag = (chkSaleReturnInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFindSaleInvoice.Tag.ToString()), flag = (chkFindSaleInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkProformaInvoice.Tag.ToString()), flag = (chkProformaInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPosScreen.Tag.ToString()), flag = (chkPosScreen.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPosShortcut.Tag.ToString()), flag = (chkPosShortcut.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPurchaseInvoice.Tag.ToString()), flag = (chkPurchaseInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPurchaseReturnInvoice.Tag.ToString()), flag = (chkPurchaseReturnInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFindpurchaseInvoice.Tag.ToString()), flag = (chkFindpurchaseInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkOrderInvoice.Tag.ToString()), flag = (chkOrderInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkItemCard.Tag.ToString()), flag = (chkItemCard.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPrimaryInfo.Tag.ToString()), flag = (chkPrimaryInfo.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkOpenStock.Tag.ToString()), flag = (chkOpenStock.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInventoryadjustment.Tag.ToString()), flag = (chkInventoryadjustment.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSpoiledItems.Tag.ToString()), flag = (chkSpoiledItems.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkAgentFile.Tag.ToString()), flag = (chkAgentFile.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDeptadjust.Tag.ToString()), flag = (chkDeptadjust.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDebts.Tag.ToString()), flag = (chkDebts.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkBalanceSheet.Tag.ToString()), flag = (chkBalanceSheet.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkReceiveReceipt.Tag.ToString()), flag = (chkReceiveReceipt.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPayReceipt.Tag.ToString()), flag = (chkPayReceipt.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSpending.Tag.ToString()), flag = (chkSpending.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDrawings.Tag.ToString()), flag = (chkDrawings.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkCashCapital.Tag.ToString()), flag = (chkCashCapital.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkBankDeposit.Tag.ToString()), flag = (chkBankDeposit.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkBankWithdraw.Tag.ToString()), flag = (chkBankWithdraw.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPrintBarcode.Tag.ToString()), flag = (chkPrintBarcode.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkUsers.Tag.ToString()), flag = (chkUsers.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkTimeAttandance.Tag.ToString()), flag = (chkTimeAttandance.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSalaryPayment.Tag.ToString()), flag = (chkSalaryPayment.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkNotes.Tag.ToString()), flag = (chkNotes.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkUserTracking.Tag.ToString()), flag = (chkUserTracking.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkReports.Tag.ToString()), flag = (chkReports.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkOption.Tag.ToString()), flag = (chkOption.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDiscount.Tag.ToString()), flag = (chkDiscount.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkEndOfDays.Tag.ToString()), flag = (chkEndOfDays.Checked == true) ? true : false);

            UpdateList(screenid = Convert.ToInt32(chkFirstPrice.Tag.ToString()), flag = (chkFirstPrice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkWholeSale.Tag.ToString()), flag = (chkWholeSale.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkMinimumPrice.Tag.ToString()), flag = (chkMinimumPrice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDateModification.Tag.ToString()), flag = (chkDateModification.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkModifyInvoice.Tag.ToString()), flag = (chkModifyInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkModifyTodaysInvoice.Tag.ToString()), flag = (chkModifyTodaysInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkModifyPrices.Tag.ToString()), flag = (chkModifyPrices.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkTotalField.Tag.ToString()), flag = (chkTotalField.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSubTotalField.Tag.ToString()), flag = (chkSubTotalField.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvoiceNavigation.Tag.ToString()), flag = (chkInvoiceNavigation.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDisCountPerc.Tag.ToString()), flag = (chkDisCountPerc.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDiscountamt.Tag.ToString()), flag = (chkDiscountamt.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvoiceNotes.Tag.ToString()), flag = (chkInvoiceNotes.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkExtraCost.Tag.ToString()), flag = (chkExtraCost.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkExport.Tag.ToString()), flag = (chkExport.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkImport.Tag.ToString()), flag = (chkImport.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkItemCost.Tag.ToString()), flag = (chkItemCost.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvPayReceipt.Tag.ToString()), flag = (chkInvPayReceipt.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvRecivRecpt.Tag.ToString()), flag = (chkInvRecivRecpt.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvTotFields.Tag.ToString()), flag = (chkInvTotFields.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkInvPrintBar.Tag.ToString()), flag = (chkInvPrintBar.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPrint.Tag.ToString()), flag = (chkPrint.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkDeleteItem.Tag.ToString()), flag = (chkDeleteItem.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkModifyCost.Tag.ToString()), flag = (chkModifyCost.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkModifyQty.Tag.ToString()), flag = (chkModifyQty.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkItemInfo.Tag.ToString()), flag = (chkItemInfo.Checked == true) ? true : false);

            UpdateList(screenid = Convert.ToInt32(chkRestoreBackUp.Tag.ToString()), flag = (chkRestoreBackUp.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkCleanDB.Tag.ToString()), flag = (chkCleanDB.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunGeneral.Tag.ToString()), flag = (chkFunGeneral.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkfunInvoice.Tag.ToString()), flag = (chkfunInvoice.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunPrint.Tag.ToString()), flag = (chkFunPrint.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunItems.Tag.ToString()), flag = (chkFunItems.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunBackUp.Tag.ToString()), flag = (chkFunBackUp.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunPeripherals.Tag.ToString()), flag = (chkFunPeripherals.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunTax.Tag.ToString()), flag = (chkFunTax.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunNotification.Tag.ToString()), flag = (chkFunNotification.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkFunOthers.Tag.ToString()), flag = (chkFunOthers.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkChangePass.Tag.ToString()), flag = (chkChangePass.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkStartNewYear.Tag.ToString()), flag = (chkStartNewYear.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkPaySalary.Tag.ToString()), flag = (chkPaySalary.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkSaveBackUp.Tag.ToString()), flag = (chkSaveBackUp.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkCashdrawer.Tag.ToString()), flag = (chkCashdrawer.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkAccounts.Tag.ToString()), flag = (chkAccounts.Checked == true) ? true : false);
            UpdateList(screenid = Convert.ToInt32(chkEmployee.Tag.ToString()), flag = (chkEmployee.Checked == true) ? true : false);



        }
        private void UpdateList(int Screenid, bool Flag)
        {
            if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpType != 0 && ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGroupName != string.Empty)
            {
                int GroupId = 0;
                if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpType == 1)
                {
                    GroupId = NewUserGroupId;
                }
                else
                {
                    GroupId = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGrpId;
                }

                string GrounName = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.UserGroupName;
                if (EmployeeHelper.SaveUserGroupList == null)
                {
                    EmployeeHelper.SaveUserGroupList = new List<EmployeeObjectClass>();
                }
                EmployeeHelper.SaveUserGroupList.Add(new EmployeeObjectClass
                {
                    UserGrpId = GroupId
                    ,
                    UserGroupName = GrounName == string.Empty || GrounName == null ? string.Empty :GrounName
                    ,
                    ScreenID = Screenid
                    ,
                    Flag = Flag
                    ,
                    Status = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Status
                    ,
                    Remove = ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.Remove
                    ,
                    UserId = GeneralFunction.UserId
                });
            }

        }
        private void DefaultGroup(string type)
        {
            try
            {

                if (cmbUserGroup.SelectedIndex != -1 && cmbUserGroup.Text != "System.Data.DataRowView" & cmbUserGroup.Text != "")
                {
                    int selectedvalue = Convert.ToInt32(cmbUserGroup.SelectedValue.ToString());
                    int LoginUserGrpId = GeneralFunction.UserGroupID;
                    //if (LoginUserGrpId == 1 && selectedvalue == 1 || LoginUserGrpId != 1 && selectedvalue != 1)
                    //{
                    //}
                    //else
                    //{
                    //}
                    bool rights = LoginUserGrpId == 1 ? true : (selectedvalue != 1) ? true : false;
                    //else if (LoginUserGrpId != 1 && selectedvalue != 1)
                    //{
                    //}
                    if (rights)
                    {
                        string screenids = string.Empty; var flag = false;

                        var index = dicUserLoad["Usergroup"].FindAll(x => x.UserGrpId == selectedvalue);
                        for (int i = 0; i < index.Count; i++)
                        {
                            screenids = index[i].ScreenID.ToString();
                            if (type == "0")  // When user group combo box selected changed, fill check box from screen id column in Usergroup table
                            {
                                flag = index[i].Flag;
                            }
                            else            // When click default button, fill check box from default screen id column in Usergroup table
                            {
                                if (index[i].DefaultScreenID != null)
                                    flag = Convert.ToBoolean(index[i].DefaultScreenID);
                            }
                            if (flag != null)
                            {
                                if (chkSaleInvoice.Tag == "1" && screenids == "1" && flag == true) { chkSaleInvoice.Checked = true; }
                                if (chkSaleReturnInvoice.Tag == "2" && screenids == "2" && flag == true) { chkSaleReturnInvoice.Checked = true; }
                                if (chkFindSaleInvoice.Tag == "3" && screenids == "3" && flag == true) { chkFindSaleInvoice.Checked = true; }
                                if (chkProformaInvoice.Tag == "4" && screenids == "4" && flag == true) { chkProformaInvoice.Checked = true; }
                                if (chkPosScreen.Tag == "5" && screenids == "5" && flag == true) { chkPosScreen.Checked = true; }
                                if (chkPosShortcut.Tag == "6" && screenids == "6" && flag == true) { chkPosShortcut.Checked = true; }
                                if (chkPurchaseInvoice.Tag == "7" && screenids == "7" && flag == true) { chkPurchaseInvoice.Checked = true; }
                                if (chkPurchaseReturnInvoice.Tag == "8" && screenids == "8" && flag == true) { chkPurchaseReturnInvoice.Checked = true; }
                                if (chkFindpurchaseInvoice.Tag == "9" && screenids == "9" && flag == true) { chkFindpurchaseInvoice.Checked = true; }
                                if (chkOrderInvoice.Tag == "10" && screenids == "10" && flag == true) { chkOrderInvoice.Checked = true; }
                                if (chkItemCard.Tag == "11" && screenids == "11" && flag == true) { chkItemCard.Checked = true; }
                                if (chkPrimaryInfo.Tag == "12" && screenids == "12" && flag == true) { chkPrimaryInfo.Checked = true; }
                                if (chkOpenStock.Tag == "13" && screenids == "13" && flag == true) { chkOpenStock.Checked = true; }
                                if (chkInventoryadjustment.Tag == "14" && screenids == "14" && flag == true) { chkInventoryadjustment.Checked = true; }
                                if (chkSpoiledItems.Tag == "15" && screenids == "15" && flag == true) { chkSpoiledItems.Checked = true; }
                                if (chkAgentFile.Tag == "16" && screenids == "16" && flag == true) { chkAgentFile.Checked = true; }
                                if (chkDeptadjust.Tag == "17" && screenids == "17" && flag == true) { chkDeptadjust.Checked = true; }
                                if (chkDebts.Tag == "18" && screenids == "18" && flag == true) { chkDebts.Checked = true; }
                                if (chkBalanceSheet.Tag == "19" && screenids == "19" && flag == true) { chkBalanceSheet.Checked = true; }
                                if (chkReceiveReceipt.Tag == "20" && screenids == "20" && flag == true) { chkReceiveReceipt.Checked = true; }
                                if (chkPayReceipt.Tag == "21" && screenids == "21" && flag == true) { chkPayReceipt.Checked = true; }
                                if (chkSpending.Tag == "22" && screenids == "22" && flag == true) { chkSpending.Checked = true; }
                                if (chkDrawings.Tag == "23" && screenids == "23" && flag == true) { chkDrawings.Checked = true; }
                                if (chkCashCapital.Tag == "24" && screenids == "24" && flag == true) { chkCashCapital.Checked = true; }
                                if (chkBankDeposit.Tag == "25" && screenids == "25" && flag == true) { chkBankDeposit.Checked = true; }
                                if (chkBankWithdraw.Tag == "26" && screenids == "26" && flag == true) { chkBankWithdraw.Checked = true; }
                                if (chkPrintBarcode.Tag == "27" && screenids == "27" && flag == true) { chkPrintBarcode.Checked = true; }
                                if (chkUsers.Tag == "28" && screenids == "28" && flag == true) { chkUsers.Checked = true; }
                                if (chkTimeAttandance.Tag == "29" && screenids == "29" && flag == true) { chkTimeAttandance.Checked = true; }
                                if (chkSalaryPayment.Tag == "30" && screenids == "30" && flag == true) { chkSalaryPayment.Checked = true; }
                                if (chkNotes.Tag == "31" && screenids == "31" && flag == true) { chkNotes.Checked = true; }
                                if (chkUserTracking.Tag == "32" && screenids == "32" && flag == true) { chkUserTracking.Checked = true; }
                                if (chkReports.Tag == "33" && screenids == "33" && flag == true) { chkReports.Checked = true; }
                                if (chkOption.Tag == "34" && screenids == "34" && flag == true) { chkOption.Checked = true; }
                                if (chkDiscount.Tag == "35" && screenids == "35" && flag == true) { chkDiscount.Checked = true; }
                                if (chkEndOfDays.Tag == "36" && screenids == "36" && flag == true) { chkEndOfDays.Checked = true; }

                                if (chkFirstPrice.Tag == "37" && screenids == "37" && flag == true) { chkFirstPrice.Checked = true; }
                                if (chkWholeSale.Tag == "38" && screenids == "38" && flag == true) { chkWholeSale.Checked = true; }
                                if (chkMinimumPrice.Tag == "39" && screenids == "39" && flag == true) { chkMinimumPrice.Checked = true; }
                                if (chkDateModification.Tag == "40" && screenids == "40" && flag == true) { chkDateModification.Checked = true; }
                                if (chkModifyInvoice.Tag == "41" && screenids == "41" && flag == true) { chkModifyInvoice.Checked = true; }
                                if (chkModifyTodaysInvoice.Tag == "42" && screenids == "42" && flag == true) { chkModifyTodaysInvoice.Checked = true; }
                                if (chkModifyPrices.Tag == "43" && screenids == "43" && flag == true) { chkModifyPrices.Checked = true; }
                                if (chkTotalField.Tag == "44" && screenids == "44" && flag == true) { chkTotalField.Checked = true; }
                                if (chkSubTotalField.Tag == "45" && screenids == "45" && flag == true) { chkSubTotalField.Checked = true; }
                                if (chkInvoiceNavigation.Tag == "46" && screenids == "46" && flag == true) { chkInvoiceNavigation.Checked = true; }
                                if (chkDisCountPerc.Tag == "47" && screenids == "47" && flag == true) { chkDisCountPerc.Checked = true; }
                                if (chkDiscountamt.Tag == "48" && screenids == "48" && flag == true) { chkDiscountamt.Checked = true; }
                                if (chkInvoiceNotes.Tag == "49" && screenids == "49" && flag == true) { chkInvoiceNotes.Checked = true; }
                                if (chkExtraCost.Tag == "50" && screenids == "50" && flag == true) { chkExtraCost.Checked = true; }
                                if (chkExport.Tag == "51" && screenids == "51" && flag == true) { chkExport.Checked = true; }
                                if (chkImport.Tag == "52" && screenids == "52" && flag == true) { chkImport.Checked = true; }
                                if (chkItemCost.Tag == "53" && screenids == "53" && flag == true) { chkItemCost.Checked = true; }
                                if (chkInvPayReceipt.Tag == "54" && screenids == "54" && flag == true) { chkInvPayReceipt.Checked = true; }
                                if (chkInvRecivRecpt.Tag == "55" && screenids == "55" && flag == true) { chkInvRecivRecpt.Checked = true; }
                                if (chkInvTotFields.Tag == "56" && screenids == "56" && flag == true) { chkInvTotFields.Checked = true; }
                                if (chkInvPrintBar.Tag == "57" && screenids == "57" && flag == true) { chkInvPrintBar.Checked = true; }
                                if (chkPrint.Tag == "58" && screenids == "58" && flag == true) { chkPrint.Checked = true; }
                                if (chkDeleteItem.Tag == "59" && screenids == "59" && flag == true) { chkDeleteItem.Checked = true; }
                                if (chkModifyCost.Tag == "60" && screenids == "60" && flag == true) { chkModifyCost.Checked = true; }
                                if (chkModifyQty.Tag == "61" && screenids == "61" && flag == true) { chkModifyQty.Checked = true; }
                                if (chkItemInfo.Tag == "62" && screenids == "62" && flag == true) { chkItemInfo.Checked = true; }

                                if (chkRestoreBackUp.Tag == "63" && screenids == "63" && flag == true) { chkRestoreBackUp.Checked = true; }
                                if (chkCleanDB.Tag == "64" && screenids == "64" && flag == true) { chkCleanDB.Checked = true; }
                                if (chkFunGeneral.Tag == "65" && screenids == "65" && flag == true) { chkFunGeneral.Checked = true; }
                                if (chkfunInvoice.Tag == "66" && screenids == "66" && flag == true) { chkfunInvoice.Checked = true; }
                                if (chkFunPrint.Tag == "67" && screenids == "67" && flag == true) { chkFunPrint.Checked = true; }
                                if (chkFunItems.Tag == "68" && screenids == "68" && flag == true) { chkFunItems.Checked = true; }
                                if (chkFunBackUp.Tag == "69" && screenids == "69" && flag == true) { chkFunBackUp.Checked = true; }
                                if (chkFunPeripherals.Tag == "70" && screenids == "70" && flag == true) { chkFunPeripherals.Checked = true; }
                                if (chkFunTax.Tag == "71" && screenids == "71" && flag == true) { chkFunTax.Checked = true; }
                                if (chkFunNotification.Tag == "72" && screenids == "72" && flag == true) { chkFunNotification.Checked = true; }
                                if (chkFunOthers.Tag == "73" && screenids == "73" && flag == true) { chkFunOthers.Checked = true; }
                                if (chkChangePass.Tag == "74" && screenids == "74" && flag == true) { chkChangePass.Checked = true; }
                                if (chkStartNewYear.Tag == "75" && screenids == "75" && flag == true) { chkStartNewYear.Checked = true; }
                                if (chkPaySalary.Tag == "76" && screenids == "76" && flag == true) { chkPaySalary.Checked = true; }
                                if (chkSaveBackUp.Tag == "77" && screenids == "77" && flag == true) { chkSaveBackUp.Checked = true; }
                                if (chkCashdrawer.Tag == "78" && screenids == "78" && flag == true) { chkCashdrawer.Checked = true; }
                                if (chkAccounts.Tag == "79" && screenids == "79" && flag == true) { chkAccounts.Checked = true; }
                                if (chkEmployee.Tag == "80" && screenids == "80" && flag == true) { chkEmployee.Checked = true; }

                            }
                            else
                            {

                                GeneralFunction.Information("NotUserGroupHaveDefaultvalues", this.Text);
                            }
                        }
                    }
                    else
                    {
                        cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
                        cmbUserGroup.SelectedIndex = -1;
                        cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
                        CommonHelper.GeneralFunction.ErrInfo(Constants.NORIGHTSTOCHANGEADMINPRIVILEGES, ActionType.Save.ToString());
                        Isaccessrights = false;
                    }
                }
                else
                {
                    GeneralFunction.Information("GROUPNAMEREQUIRED", this.Text);
                }

            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_UserGroup_SelectedIndexChanged");
            }
        }

        public static void ChangeProperties(Control ctrl)
        {
            ctrl.Select();
            ctrl.Focus();

        }

        #endregion

        #region Grid Events
        //Desc: Assign a values into corresponding textbox and chkbox when double click row in Employee Notes grid..
        private void dgrEmployeeNotes_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                // DataTable dtLocal = new DataTable();
                //  dtLocal = (DataTable)dgrEmployeeNotes.DataSource;

                if (dgrEmployeeNotes.Rows.Count > 0)
                {
                    txtAlertIdFromGrid.Text = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["AlertID"].Value).ToString();
                    txtUserIdFromGrid.Text = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["UserId"].Value).ToString();
                    txtNotesMessage.Text = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["NoteMessage"].Value).ToString();
                    txtNoteTime.Text = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["NoOfNoteTime"].Value).ToString();
                    //dtpNotesDate.Text = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["NoteDate"].Value).ToString();//Commented on 31-May-2014 for Date Foprmat issues
                    dtpNotesDate.Value = Convert.ToDateTime(dgrEmployeeNotes.SelectedRows[0].Cells["NoteDate"].Value);
                    string flag = (dgrEmployeeNotes.SelectedRows[0].Cells["LoginFlag"].Value).ToString();
                    int grpID = Convert.ToInt32(dgrEmployeeNotes.SelectedRows[0].Cells["DropUserGroupID"].Value);
                    chkAlertLogin.Checked = (flag == "Y");
                    string val = Convert.ToString(dgrEmployeeNotes.SelectedRows[0].Cells["UName"].Value).ToString();
                    int opnID = Convert.ToInt16(dgrEmployeeNotes.SelectedRows[0].Cells["OptionID"].Value);
                    if (opnID == 1)
                    {
                        radNotesForAll.Checked = true;
                        cmbNotesForEmployee.SelectedValue = Convert.ToInt32(txtUserIdFromGrid.Text);
                    }
                    else if (opnID == 2)
                    {
                        radNotesForGroup.Checked = true;
                        cmbNotesForGroup.SelectedValue = grpID;
                    }
                    else
                    {
                        radNotesForEmployee.Checked = true;
                        cmbNotesForEmployee.SelectedValue = Convert.ToInt32(txtUserIdFromGrid.Text);
                    }

                    // Rbn_NotesForEmployee.Checked = true; Cmb_NotesForEmployee.Text = val;
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "dgrEmployeeNotes_DoubleClick");
            }
        }

        //Desc: Assign a values into corresponding textbox and chkbox when double click row in Employee Drawings grid..
        private void dgrEmployeeDrawings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDrawNote.Text = string.Empty;
                if (dgrEmployeeDrawings.Rows.Count > 0)
                {
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString() != string.Empty)
                        cmbDrawForEmployee.Text = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString();
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString() != string.Empty)
                        txtDrawAmount.Text = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString();
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString() != string.Empty)
                        //dtpDrawDate.Text = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString();//Commented on 31-May-2014 for Date Format Issues
                        dtpDrawDate.Value = Convert.ToDateTime(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value);
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString() != string.Empty)
                        txtDrawDescription.Text = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString();
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString() != string.Empty)
                        txtDrawNote.Text = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString();
                    if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.UserName = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString();
                    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString());
                    ObjEmployeeHelper.FindCutMonth();
                    if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 1)
                        radDrawCutThisMonthSalary.Checked = true;
                    else if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 2)
                        radDrawCutNextMonthSalary.Checked = true;
                    //SetControlFromObjectForDrawings();
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEmpVariableId"].Value.ToString());
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount = Convert.ToDecimal(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawVariableAmount"].Value.ToString());
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(dgrEmployeeDrawings.SelectedRows[0].Cells["DrawEffectiveDate"].Value.ToString());
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Description = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawDescription"].Value.ToString();
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Remarks = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawRemarks"].Value.ToString();
                    //if (dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString() != string.Empty)
                    //    ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.UserName = dgrEmployeeDrawings.SelectedRows[0].Cells["DrawUserName"].Value.ToString();
                    //SetControlFromObjectForDrawings();
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Employee", "dgrEmployeeDrawings_CellClick");
            }
        }

        // Desc: Assign a values into corresponding textbox and chkbox when double click row in Employee Variable grid..
        private void dgrEmployeeVariables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrEmployeeVariables.RowCount > 0)
                {
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EmployeeVariablesID = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["EmployeeVariablesID"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableAmount = Convert.ToDecimal(dgrEmployeeVariables.SelectedRows[0].Cells["VariableAmount"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString() != string.Empty)
                        //ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value.ToString());//Commented on 31-May-2014 for Date FOrmat Issues
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.EffectiveDate = Convert.ToDateTime(dgrEmployeeVariables.SelectedRows[0].Cells["VarEffectiveDate"].Value);
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.Remarks = dgrEmployeeVariables.SelectedRows[0].Cells["VarRemarks"].Value.ToString();
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.UserName = dgrEmployeeVariables.SelectedRows[0].Cells["VarUName"].Value.ToString();
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.VariableID = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["VariableID"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupName = dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupName"].Value.ToString();
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.GroupID = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["VarGroupID"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.MonthlyDeduction = Convert.ToDecimal(dgrEmployeeVariables.SelectedRows[0].Cells["VarMonthlyDeduction"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.UserId = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
                    if (dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString() != string.Empty)
                        ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObjectClass.UserId = Convert.ToInt32(dgrEmployeeVariables.SelectedRows[0].Cells["VarUserId"].Value.ToString());
                    SetControlFromObjectForVariable();
                    ObjEmployeeHelper.IsfromVar = true;
                    ObjEmployeeHelper.FindCutMonth();
                    if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 1)
                        radCutFromThisMonthVar.Checked = true;
                    else if (ObjEmployeeHelper.ObjEmployeeBAL.ObjEmployeeObject.AmountCutOption == 2)
                        radCutFromNextMonthVar.Checked = true;
                }
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Employee", "dgrEmployeeDrawings_CellClick");
            }
        }
        // Desc: Assign a values into corresponding textbox and chkbox in Employee Details Form when double click row in Employee List grid..
        private void dgrEmpList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AssignToEmpDetailsControl();

            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Employee", "dgrEmployeeList_CellClick");
            }
        }

        private void dgrEmpList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AssignToEmpDetailsControl();
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "dgrEmpList_DoubleClick");
            }
        }


        #endregion

        #region KeyUp Events
        private void Cmb_Weekend_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (saltoweek == true)
                    { cmbWeekend.Focus(); saltoweek = false; }
                    else { SendKeys.Send("{TAB}"); }

                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_Weekend_KeyUp");
            }
        }
        private void Dtp_StartDate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Dtp_StartDate_KeyUp");
            }
        }
        private void Cmb_CalculationType_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    txtOverTime.SelectAll();
                    txtOverTime.Focus();
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_CalculationType_KeyUp");
            }
        }
        private void Dtp_WorkingHoursFrom_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    if (OTtoWHF == true)
                    { dtpWorkingHoursFrom.Focus(); OTtoWHF = false; }
                    else
                    { SendKeys.Send("{TAB}"); }
                }
            }

            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Dtp_WorkingHoursFrom_KeyUp");
            }
        }
        private void Dtp_WorkingHoursTo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Dtp_WorkingHoursTo_KeyUp");
            }
        }
        private void Cmb_UserGroup_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (rbnTocmb == true)
                    { cmbUserGroup.Focus(); rbnTocmb = false; }
                    else { btnDetailSave.Focus(); }
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_UserGroup_KeyUp");
            }
        }
        #endregion


        #region Select All
        private void chkGenSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (CheckBox chkbox in tabgeneral.Controls)
                {
                    chkbox.Checked = chkGenSelectAll.Checked;
                }
            }
            catch (Exception ex)
            {

                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "chkGenSelectAll_CheckedChanged");
            }
        }

        #endregion

        private void cmbCalculationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPercent.Visible = (cmbCalculationType.SelectedIndex == 3);
            txtSalesPercentage.Visible = (cmbCalculationType.SelectedIndex == 3);

            if (chkUserToSystem.Checked == false)
            { chkUserToSystem.Checked = (cmbCalculationType.SelectedIndex == 2); }
        }

        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {

                Properties.Settings.Default.Save();
                foreach (Control cti in TabEmployee.Controls)
                {
                    cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton)
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                    else if (cti is Panel || cti is GroupBox || cti is TabPage)
                    {
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                        foreach (Control ctrl in cti.Controls)
                        {
                            if (ctrl is Button || ctrl is Label || ctrl is CheckBox || ctrl is RadioButton)
                                ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            else if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl || ctrl is TabPage)
                            {
                                foreach (Control cl in ctrl.Controls)
                                {
                                    if (cl is Button || cl is Label || cl is CheckBox || cl is RadioButton)
                                        cl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                }
                            }

                        }
                    }

                }
                foreach (Control i in General.Controls)
                {
                    if (i is Button || i is Label || i is CheckBox || i is RadioButton)
                        i.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                    else if (i is Panel || i is GroupBox || i is TabControl || i is TabPage)
                    {
                        foreach (Control c in i.Controls)
                        {
                            if (c is Button || c is Label || c is CheckBox || c is RadioButton)
                                c.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                        }
                    }
                }
                dgrEmpList.Font = dgrEmployeeNotes.Font = dgrEmployeeVariables.Font = dgrEmployeeDrawings.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void tabgeneral_Click(object sender, EventArgs e)
        {

        }

        private void Pnl_OtherInformation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radAdvances_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            string controlname = btn.Tag.ToString();
            if (controlname == "Reward" || controlname == "Incentives")
            {
                radCutFromThisMonthVar.Enabled = false;
                radCutFromNextMonthVar.Enabled = false;
                txtMonthlyCut.Enabled = false;
            }
            else
            {
                radCutFromThisMonthVar.Enabled = true;
                radCutFromNextMonthVar.Enabled = true;
                txtMonthlyCut.Enabled = true;
            }
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjEmployeeHelper.DisposeAllListObjects();
            this.Dispose();
        }

        private void chkSuspendUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtEmpId.Text)==101)//admin
            {
                if (((CheckBox)sender).Checked == true)
                {
                    ((CheckBox)sender).Checked =false;
                }
            }
        }


    }
}

