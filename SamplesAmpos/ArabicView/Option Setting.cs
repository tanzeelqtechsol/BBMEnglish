using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.ViewHelper;
using ObjectHelper;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using BALHelper;
using System.Threading;

namespace BumedianBM.ArabicView
{
    public partial class Option_Seeting : Form
    {
        bool Loaded = false;

        #region Variables
        public static string paymentTypeChargesValueCheck = "";
        public static string paymentTypeChargesNameCheck = "";
        public static string paymentTypeChargesValueCard = "";
        public static string paymentTypeChargesNameCard = "";
        OptionSettingHelper objOptionSettingHelper;

        OptionSettingsObject objOption;
        bool isRestart = false;
        public static bool isfromRestore = false;
        string strValue = string.Empty;
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        bool isvalidation = true;
        #endregion

        #region Constructor

        public Option_Seeting()
        {
            InitializeComponent();
            objOptionSettingHelper = new OptionSettingHelper();
            objOption = new OptionSettingsObject();
            SetLanguage();
            setFont();
            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
            DTP_LicenserenewalDate.Format = DateTimePickerFormat.Custom;
            DTP_MedicalInsuranceDate.Format = DateTimePickerFormat.Custom;
            DTP_CertificateofHealthDate.Format = DateTimePickerFormat.Custom;
            DTP_AttendancePermitDate.Format = DateTimePickerFormat.Custom;
            DTP_ZakatDate.Format = DateTimePickerFormat.Custom;
            DTP_TechnicalDisclosureDate.Format = DateTimePickerFormat.Custom;
            DTP_PricingDate.Format = DateTimePickerFormat.Custom;
            DTP_PayrentDate.Format = DateTimePickerFormat.Custom;
            DTP_DisbursementSalaryDate.Format = DateTimePickerFormat.Custom;
            DTP_AnnualInventoryDate.Format = DateTimePickerFormat.Custom;

            DTP_LicenserenewalDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_MedicalInsuranceDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_CertificateofHealthDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_AttendancePermitDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_ZakatDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_TechnicalDisclosureDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_PricingDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_PayrentDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_DisbursementSalaryDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            DTP_AnnualInventoryDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//
        }

        #endregion

        #region Events

        #region FormLoad
        private void Option_Seeting_Load(object sender, EventArgs e)
        {
            try
            {

                int UserId = GeneralFunction.UserId;
                CtrlTab_OptionSetting.TabPages.Remove(Tab_Employee);
                LoadUserGroup();
                LoadCOMPorts();
                LoadOptionDatas();
                NotifyVisible();
                string strTag = this.Tag.ToString();
                Cmb_Langage.Text = GeneralFunction.Language;
                //cmbDateFormat.SelectedIndex = 5;//Added on 28-May-2014 for Default Date Format
                if (strTag != null && strTag != "")
                {
                    switch (strTag)
                    {
                        case "General":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_General;
                                Txt_Companyname.Focus();
                                break;
                            }
                        case "Invoice":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Invoice;
                                break;
                            }
                        case "Print":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Print;
                                break;
                            }
                        case "Item":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Items;
                                break;
                            }
                        case "Backup":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Backup;
                                break;
                            }
                        case "Employee":
                            {
                                // CtrlTab_OptionSetting.SelectedIndex = 4;
                                break;
                            }
                        case "Tax":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Tax;
                                break;
                            }
                        case "Others":
                            {
                                CtrlTab_OptionSetting.SelectedTab = Tab_Other;
                                break;
                            }
                        default:
                            {
                                CtrlTab_OptionSetting.SelectedIndex = 0;
                                Txt_Companyname.Focus();
                                break;
                            }
                    }
                }

                CheckBox_CheckedChanged(sender, e);
                rbnDrawerTypeCOM.CheckedChanged += new EventHandler(rbnDrawerTypeCOM_CheckedChanged);

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "OptionSetting", "Option_Seeting_Load");
            }
            finally
            {
                Loaded = true;
            }
        }
        #endregion

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {

            try
            {
                //switch ((Options)CtrlTab_OptionSetting.SelectedIndex)
                //{
                //    case Options.General:
                //        {
                //            SaveOption_General();
                //            break;
                //        }
                //    case Options.Invoice:
                //        {
                //            SaveOption_Invoice();
                //            break;
                //        }
                //    case Options.Print:
                //        {
                //            SaveOption_Print();
                //            break;
                //        }
                //    case Options.Item:
                //        {
                //            SaveOption_Item();
                //            break;
                //        }
                //    //case Options.Employee:
                //    //    {
                //    //        // SaveOption_Employee();
                //    //        break;
                //    //    }
                //    case Options.Backup:
                //        {
                //            SaveOption_Backup();
                //            break;
                //        }
                //    case Options.Peripherals:
                //        {
                //            SaveOption_Peripherals();
                //            break;
                //        }
                //    case Options.Tax:
                //        {
                //            SaveOption_Tax();
                //            break;
                //        }
                //    case Options.Notification:
                //        {
                //            SaveOption_Notification();
                //            break;
                //        }
                //    case Options.Others:
                //        {
                //            SaveOption_Other();
                //            break;
                //        }
                //}

                // Item --Auto Price Validation
                if (ckhAutoItemPrice.Checked)
                {
                    if (string.IsNullOrEmpty(txtAutoItemPrice.Text) || txtAutoItemPrice.Text == "0")
                    {
                        MessageBox.Show(Additional_Barcode.GetValueByResourceKey("ValueZeroMsg"), "Option Item", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                //
                SaveOption_General();
                SaveOption_Invoice();
                SaveOption_Print();
                SaveOption_Item();
                SaveOption_Backup();
                SaveOption_Peripherals();
                SaveOption_Tax();
                SaveOption_Notification();
                SaveOption_Other();

                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.HeaderLogo = Txt_LogoHeader.Text == string.Empty && Pic_Header.Image != null ? GeneralOptionSetting.HeaderLogo : objOptionSettingHelper.PathtoByte(Txt_LogoHeader.Text);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FooterLogo = Txt_LogoFooter.Text == string.Empty && Pic_Footer.Image != null ? GeneralOptionSetting.FooterLogo : objOptionSettingHelper.PathtoByte(Txt_LogoFooter.Text);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.UserId = GeneralFunction.UserId;

                if (isRestart)
                {
                    objOptionSettingHelper.SaveOptionSettingDet();
                    objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionLangage = Cmb_Langage.SelectedIndex.ToString();
                    objOptionSettingHelper.Update_CashClientNameDet();
                    GeneralFunction.isApplnRestart = true;
                    objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.UserId = GeneralFunction.UserId;
                    objOptionSettingHelper.LogOut_UserProc();
                    objOptionSettingHelper.objOptionSettingsBAl.UpdateuserUnlock();
                    GeneralFunction.SetConfigValue("Restart", "True");
                    Application.Restart();
                }
                else
                {
                    string msg = string.Empty;
                    if (cmbUserGroup.SelectedValue.ToString() == "101")
                        msg = "Changeswillapplyforall";
                    else
                        msg = "Areyousuretosavethissettings";
                    if (GeneralFunction.Question(msg, "OptionSetting".ToString()) == DialogResult.Yes)
                    {
                        if (objOptionSettingHelper.SaveOptionSettingDet() > 0)
                        {
                            GeneralFunction.Information("Option details saved successfully", "OptionSetting".ToString());
                            //  dataOption.GetOptionDatas();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), "Option", "OPTION", "save option setting details", Convert.ToInt32(InvoiceAction.No));
                            if (cmbUserGroup.SelectedValue.ToString() == GeneralFunction.UserGroupID.ToString() || cmbUserGroup.SelectedValue.ToString() == "101")
                            {
                                GeneralFunction.GetOptionDatas();
                            }

                            GeneralFunction.NoofReceiptPrint = int.Parse(GeneralOptionSetting.FlagReciptCopies == string.Empty || GeneralOptionSetting.FlagReciptCopies == "0" ? "1" : GeneralOptionSetting.FlagReciptCopies);
                            GeneralFunction.NoofPrint = int.Parse(GeneralOptionSetting.FlagInvoiceCopies == string.Empty || GeneralOptionSetting.FlagInvoiceCopies == "0" ? "1" : GeneralOptionSetting.FlagInvoiceCopies);
                            this.Close();
                        }
                    }
                    else
                    {
                        //  dataOption.GetOptionDatas();
                        //  Dal_Common.GetOptionDatas();
                        if (cmbUserGroup.SelectedValue.ToString() == GeneralFunction.UserGroupID.ToString() || cmbUserGroup.SelectedValue.ToString() == "101")
                        {
                            GeneralFunction.GetOptionDatas();
                        }
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Btn_Ok_Click");
            }
        }
        #endregion

        #region btnApply_Click
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                this.InvokeOnClick(btnOk, EventArgs.Empty);
                //switch ((Options)CtrlTab_OptionSetting.SelectedIndex)
                //{
                //    case Options.General:
                //        {
                //            SaveOption_General();
                //            break;
                //        }
                //    case Options.Invoice:
                //        {
                //            SaveOption_Invoice();
                //            break;
                //        }
                //    case Options.Print:
                //        {
                //            // SaveOption_Print();
                //            break;
                //        }
                //    case Options.Item:
                //        {
                //            // SaveOption_Item();
                //            break;
                //        }
                //    //case Options.Employee:
                //    //    {
                //    //        // SaveOption_Employee();
                //    //        break;
                //    //    }
                //    case Options.Backup:
                //        {
                //            // SaveOption_Backup();
                //            break;
                //        }
                //    case Options.Peripherals:
                //        {
                //            //  SaveOption_Peripherals();
                //            break;
                //        }
                //    case Options.Tax:
                //        {
                //            // SaveOption_Tax();
                //            break;
                //        }
                //    case Options.Notification:
                //        {
                //            // SaveOption_Notification();
                //            break;
                //        }
                //    case Options.Others:
                //        {
                //            //SaveOption_Other();
                //            break;
                //        }
                // }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Setting", "btnApply_Click");
            }

        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Setting", "Btn_Close_Click");
            }
        }
        #endregion

        #region btnRestore_Click
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                switch ((Options)CtrlTab_OptionSetting.SelectedIndex)
                {
                    case Options.General:
                        {
                            RestoreOption_General();
                            break;
                        }
                    case Options.Invoice:
                        {
                            RestoreOption_Invoice();
                            break;
                        }
                    case Options.Print:
                        {
                            RestoreOption_Print();
                            break;
                        }
                    case Options.Item:
                        {
                            RestoreOption_Item();
                            break;
                        }
                    //case Options.Employee:
                    //    {
                    //        RestoreOption_Employee();
                    //        break;
                    //    }
                    case Options.Backup:
                        {
                            RestoreOption_Backup();
                            break;
                        }
                    case Options.Peripherals:
                        {
                            RestoreOption_Peripherals();
                            break;
                        }
                    case Options.Tax:
                        {
                            RestoreOption_Tax();
                            break;
                        }
                    case Options.Notification:
                        {
                            RestoreOption_Notification();
                            break;
                        }
                    case Options.Others:
                        {
                            RestoreOption_Other();
                            break;
                        }
                }
                if (GeneralFunction.Question("Do you want to Restore the default values", "OptionSetting") == DialogResult.Yes)
                {
                    btnApply_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnRestore_Click");
            }
        }

        #endregion

        #region btnBrowseHeader_Click
        private void btnBrowseHeader_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog OpenHeader = new OpenFileDialog())
                {
                    OpenHeader.Title = "Open Image Files";
                    OpenHeader.Filter = "Image Files(JPEG,BMP,ICO,PNG,GIF)|*.jpg;*.bmp;*.ico;*.png;*.gif";
                    if (OpenHeader.ShowDialog() == DialogResult.OK)
                    {
                        Pic_Header.Image = new Bitmap(OpenHeader.FileName);
                        Txt_LogoHeader.Text = OpenHeader.FileName;
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnBrowseHeader_Click");
            }
        }
        #endregion

        #region btnBrowseFooter_Click
        private void btnBrowseFooter_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog OpenFooter = new OpenFileDialog())
                {
                    OpenFooter.Title = "Open Image Files";
                    OpenFooter.Filter = "Image Files(JPEG,BMP,ICO,PNG,GIF)|*.jpg;*.bmp;*.ico;*.png;*.gif";
                    if (OpenFooter.ShowDialog() == DialogResult.OK)
                    {
                        Pic_Footer.Image = new Bitmap(OpenFooter.FileName);
                        Txt_LogoFooter.Text = OpenFooter.FileName;
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnBrowseFooter_Click");
            }
        }
        #endregion

        #region Delete Header & Footer Logo
        private void btnDeleteHeader_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralOptionSetting.HeaderLogo = objOptionSettingHelper.PathtoByte(Txt_LogoHeader.Text);
                Pic_Header.Image = null;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnDeleteHeader_Click");
            }
        }

        private void btnDeleteFooter_Click(object sender, EventArgs e)
        {
            try
            {

                GeneralOptionSetting.FooterLogo = objOptionSettingHelper.PathtoByte(Txt_LogoFooter.Text);
                Pic_Footer.Image = null;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnDeleteFooter_Click");
            }
        }

        #endregion

        #region btnRestore_Backup_Click
        private void btnRestore_Backup_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Login ObjFrm = new DB_Login();

                ObjFrm.Text = GeneralFunction.ChangeLanguageforCustomMsg("Restore DB Login");
                ObjFrm.Tag = "Clean DB";
                if (GeneralFunction.OKCancelMsg("InsDbRestore", "OptionSetting") == DialogResult.OK)
                {
                    if (ObjFrm.ShowDialog() == DialogResult.Cancel) return;

                    this.Cursor = Cursors.WaitCursor;
                    if (GeneralFunction.Question("AlertDbRestore", "OptionSetting") == DialogResult.Yes)
                    {


                        string res = "";
                        pnlLoading.Visible = true;
                        //Thread.Sleep(2000);
                        res = GeneralFunction.RestoreDB(Txt_SaveBackup.Text);
                        pnlLoading.Visible = false;
                        if (res == "Success")
                        {
                            objOptionSettingHelper.UpdateLoginStatus();
                            // MessageBox.Show("Database restored successfully. \n You have to restart the application after Database Restore", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                            isfromRestore = true;
                            string FileName = System.Windows.Forms.Application.StartupPath + "\\" + "Updatescript.bat";
                            System.Diagnostics.Process _process = new System.Diagnostics.Process();
                            _process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\" + "Updatescript.bat";
                            if (File.Exists(_process.StartInfo.FileName))
                            {
                                _process.StartInfo.RedirectStandardError = false;
                                _process.StartInfo.RedirectStandardOutput = false;
                                _process.StartInfo.UseShellExecute = false;
                                _process.StartInfo.CreateNoWindow = true;
                                _process.StartInfo.Verb = "runas";
                                Cursor.Current = Cursors.WaitCursor;
                                _process.Start();
                                _process.WaitForExit();
                                GeneralFunction.Information("DbRestoreSuccess", "Database Restore");
                                GeneralFunction.Information("Restarttheapplication", "Database Restore");
                            }
                            else
                            {
                               MessageBox.Show("Update database file not found to be executed, Please run updated script file before use App");
                            }
                            Application.Restart();

                        }
                        else if (res != string.Empty)
                        {
                            MessageBox.Show(res, "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnRestore_Backup_Click");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                pnlLoading.Visible = false;
            }
        }



        #endregion

        #region btnSave_Backup_Click
        public void btnSave_Backup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_SaveBackup.Text)) GeneralFunction._backuppath = Txt_SaveBackup.Text.ToString();
                this.Cursor = Cursors.WaitCursor;
                GeneralFunction.isAutobackup = false;
                if (chkSaveAutomaticBackupInAlternativePath.Checked)
                    GeneralFunction._alternateBackuppath = Txt_AlternativePath.Text.ToString();
                else
                    GeneralFunction._alternateBackuppath = string.Empty;

                GeneralFunction.BackupDB();
                objOptionSettingHelper.UpdateLastBackupDate();
                LoadOptionDatas();
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnSave_Backup_Click");
            }
        }
        #endregion

        #region btnStartNewYear_Click
        private void btnStartNewYear_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Login ObjFrm = new DB_Login();
                //ObjFrm.Text = "ÊÃßíÏ ÊØÈíÞ ÈÏÇíÉ ÓäÉ ÊÚÏÇÏíÉ ÌÏíÏÉ";
                ObjFrm.Tag = "Clean DB";
                if (GeneralFunction.Question("AlertStartNewYear", "OptionSetting") == DialogResult.Yes)
                {
                    if (ObjFrm.ShowDialog() == DialogResult.Cancel) return;
                    //  Dal_Common.Update_StartNewyear();
                    if (objOptionSettingHelper.StartNewYearHelper())
                        GeneralFunction.Information("UpdateData", "OptionSetting");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                //GeneralFunction.ErrInfo(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_StartNewYear_Click");
            }
        }
        #endregion

        #region Btn_Browse_Click
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_SaveBackup.Text)) Fbd.SelectedPath = Txt_SaveBackup.Text.ToString();
                if (Fbd.ShowDialog() == DialogResult.OK) Txt_SaveBackup.Text = Fbd.SelectedPath.ToString();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Btn_Browse_Click");
            }
        }
        #endregion

        #region Btn_Browse1_Click
        private void Btn_Browse1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Txt_AlternativePath.Text)) Fbd.SelectedPath = Txt_AlternativePath.Text.ToString();
                if (Fbd.ShowDialog() == DialogResult.OK) Txt_AlternativePath.Text = Fbd.SelectedPath.ToString();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Btn_Browse1_Click");
            }
        }
        #endregion

        #region Leave Events
        private void Leave(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "UD_Tax1_Percentage":
                    UD_Tax1_Percentage.Value = (((Control)sender).Text == "") ? 0 : UD_Tax1_Percentage.Value;
                    break;
                case "UD_Tax1_SubPercentage":
                    UD_Tax1_SubPercentage.Value = (((Control)sender).Text == "") ? 0 : UD_Tax1_SubPercentage.Value;
                    break;
                case "UD_Tax2_Percentage":
                    UD_Tax2_Percentage.Value = (((Control)sender).Text == "") ? 0 : UD_Tax2_Percentage.Value;
                    break;
                case "UD_Tax2_SubPercentage":
                    UD_Tax2_SubPercentage.Value = (((Control)sender).Text == "") ? 0 : UD_Tax2_SubPercentage.Value;
                    break;

            }
            ((Control)sender).Text = ((NumericUpDown)sender).Value.ToString();
        }
        #endregion

        #region KeyPress Event

        private void Txt_Companyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_Phone.Focus();
                    Txt_Phone.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Companyname_KeyPress");
            }
        }

        private void Txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_Cell.Focus();
                    Txt_Cell.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Phone_KeyPress");
            }
        }

        private void Txt_Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_Fax.Focus();
                    Txt_Fax.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Cell_KeyPress");
            }
        }

        private void Txt_Fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_POBox.Focus();
                    Txt_POBox.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Fax_KeyPress");
            }
        }

        private void Txt_POBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_Email.Focus();
                    Txt_Email.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_POBox_KeyPress");
            }
        }

        private void Txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_Address.Focus();
                    Txt_Address.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Email_KeyPress");
            }
        }

        private void Txt_Address_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_WorkNote.Focus();
                    Txt_WorkNote.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_Address_KeyPress");
            }
        }

        private void Txt_SystemNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Txt_WorkNote.Focus();
                    Txt_WorkNote.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Txt_SystemNote_KeyPress");
            }
        }

        #endregion

        #region CheckBox_CheckedChanged
        public void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DTP_LicenserenewalDate.Enabled = UD_LicenserenewalNotifyBefore.Enabled = Chk_Licenserenewal.Checked;
                DTP_MedicalInsuranceDate.Enabled = UD_MedicalInsuranceNotifyBefore.Enabled = Chk_MedicalInsurance.Checked;
                DTP_CertificateofHealthDate.Enabled = UD_CertificateofHealthNotifyBefore.Enabled = Chk_CertificateofHealth.Checked;
                DTP_AttendancePermitDate.Enabled = UD_AttendancePermitNotifyBefore.Enabled = Chk_AttendancePermit.Checked;
                DTP_ZakatDate.Enabled = UD_ZakatNotifyBefore.Enabled = Chk_Zakat.Checked;

                Txt_TextBox1.Enabled = DTP_TechnicalDisclosureDate.Enabled = UD_TechnicalDisclosureNotifyBefore.Enabled = Chk_TechnicalDisclosure.Checked;
                Txt_TextBox2.Enabled = DTP_PricingDate.Enabled = UD_PricingNotifyBefore.Enabled = Chk_Pricing.Checked;
                Txt_TextBox3.Enabled = DTP_PayrentDate.Enabled = UD_PayrentNotifyBefore.Enabled = Chk_Payrent.Checked;
                Txt_TextBox4.Enabled = DTP_DisbursementSalaryDate.Enabled = UD_DisbursementSalaryNotifyBefore.Enabled = Chk_DisbursementSalary.Checked;
                Txt_TextBox5.Enabled = DTP_AnnualInventoryDate.Enabled = UD_AnnualInventoryNotifyBefore.Enabled = Chk_AnnualInventory.Checked;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "CheckBox_CheckedChanged");
            }

        }
        #endregion

        #region btnCommunicate_Click
        private void btnCommunicate_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralOptionSetting.FlagUseCustomerDisplay = "Y";
                GeneralFunction.SetConfigValue("COMPort", Cmb_COMPort.Text != string.Empty ? Cmb_COMPort.Text : string.Empty);
                GeneralOptionSetting.FlagFirstLineWelcomeNote = Txt_FirstLineWelcomeNote.Text;
                GeneralOptionSetting.FlagSecondLineWelcomeNote = Txt_SecondLineWelcomeNote.Text;
                //  GeneralFunction.CustomerMessage(string.Empty, string.Empty, GeneralFunction.messageType.custom);
                CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.custom);


            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Btn_Communicate_Click");
            }
        }
        #endregion

        #region btnopenDrawer_Click
        private void btnopenDrawer_Click(object sender, EventArgs e)
        {

            try
            {
                CashDrawer objcashdraw = new CashDrawer();
                objcashdraw.OpenCashDrawer();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "btnopenDrawer_Click");
            }
        }

        #endregion

        #region Chk_RoundPriceOnDiscount_CheckedChanged
        private void Chk_RoundPriceOnDiscount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Chk_RoundPriceOnDiscount.Checked == true)
                {
                    Cmb_RoundPricesOnDiscountValue.Enabled = true;
                }
                else
                {
                    Cmb_RoundPricesOnDiscountValue.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "Chk_RoundPriceOnDiscount_CheckedChanged");
            }
        }

        #endregion

        #region cmbUserGroup_SelectedIndexChanged
        private void cmbUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserGroup != null)
                {
                    objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.UserGroupID = Convert.ToInt32(cmbUserGroup.SelectedValue);

                    LoadOptionDatas();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "OptionSetting");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "cmbUserGroup_SelectedIndexChanged");
            }
        }
        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            btnPercentage.Text = Additional_Barcode.GetValueByResourceKey("PaymentMethodPercentage");
            chkActivatePaymentType.Text = Additional_Barcode.GetValueByResourceKey("PaymentType");
            lblAddress.Text = Additional_Barcode.GetValueByResourceKey("Address");
            lblCell.Text = Additional_Barcode.GetValueByResourceKey("Cell");
            lblCompanyName.Text = Additional_Barcode.GetValueByResourceKey("ComName");
            lblEmail.Text = Additional_Barcode.GetValueByResourceKey("EMail");
            lblFax.Text = Additional_Barcode.GetValueByResourceKey("Fax");
            lblLanguage.Text = Additional_Barcode.GetValueByResourceKey("Language");
            lblLoadingSysNote.Text = Additional_Barcode.GetValueByResourceKey("LoadingSysNotes");
            lblPhone.Text = Additional_Barcode.GetValueByResourceKey("Phone");
            lblPOBox.Text = Additional_Barcode.GetValueByResourceKey("POBox");
            lblPort.Text = Additional_Barcode.GetValueByResourceKey("Port");
            lblStartWorkNote.Text = Additional_Barcode.GetValueByResourceKey("SWN");
            lblAlertForPayDatesBefore.Text = Additional_Barcode.GetValueByResourceKey("AlertPayDate");
            lblAlertForReOrderItemsEvery.Text = Additional_Barcode.GetValueByResourceKey("AlertforReorderItem");
            lblAlternativePathIn.Text = Additional_Barcode.GetValueByResourceKey("AlterPath");
            lblBarcodePaperSize.Text = Additional_Barcode.GetValueByResourceKey("BarPaperSize");
            lblBarcodePrinter.Text = Additional_Barcode.GetValueByResourceKey("BarcodePrinter");
            lblCalculateSalaryAs.Text = Additional_Barcode.GetValueByResourceKey("CalSalAs");
            lblCashDrawerPassword.Text = Additional_Barcode.GetValueByResourceKey("CashDrawerPassword");
            lblCompanyName.Text = Additional_Barcode.GetValueByResourceKey("ComName");
            lblCopies1.Text = Additional_Barcode.GetValueByResourceKey("Copies");
            lblCopies2.Text = Additional_Barcode.GetValueByResourceKey("Copies");
            lblday.Text = Additional_Barcode.GetValueByResourceKey("Day");
            lblDay1.Text = Additional_Barcode.GetValueByResourceKey("Day");
            lblDay3.Text = Additional_Barcode.GetValueByResourceKey("Day");
            lblDayFromDate.Text = Additional_Barcode.GetValueByResourceKey("DaysFromDate");
            lblFirstLine.Text = Additional_Barcode.GetValueByResourceKey("FL");
            lblfmm.Text = Additional_Barcode.GetValueByResourceKey("mm");
            lblFooter.Text = Additional_Barcode.GetValueByResourceKey("Footer");
            lblForExpiryFor.Text = Additional_Barcode.GetValueByResourceKey("AlertforExpiry");
            lblHeader.Text = Additional_Barcode.GetValueByResourceKey("Header");
            lblHoliDay.Text = Additional_Barcode.GetValueByResourceKey("Hoilday");
            lblInvTemplate.Text = Additional_Barcode.GetValueByResourceKey("InvTemplate");
            lblIssueOrderInvoiceEvery.Text = Additional_Barcode.GetValueByResourceKey("IssueOrderInv");
            lblItemSorting.Text = Additional_Barcode.GetValueByResourceKey("ItemSort");
            lblLogoFooter.Text = Additional_Barcode.GetValueByResourceKey("LogoFooter");
            lblLogoHeader.Text = Additional_Barcode.GetValueByResourceKey("LogoHeader");
            lblMakeAutomaticBackUpEvery.Text = Additional_Barcode.GetValueByResourceKey("MakeAutoBackup");
            lblmm.Text = Additional_Barcode.GetValueByResourceKey("mm");
            lblMonthsFromToday.Text = Additional_Barcode.GetValueByResourceKey("MonthToday");
            lblNoOfInvoiceCopies.Text = Additional_Barcode.GetValueByResourceKey("NoInvCopies");
            lblNoOfReceiptCopies.Text = Additional_Barcode.GetValueByResourceKey("NoRecCopies");
            lblNoteOnSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("NoteSalesInv");
            lblPercentage1.Text = Additional_Barcode.GetValueByResourceKey("Persentage");
            lblPercentage2.Text = Additional_Barcode.GetValueByResourceKey("Persentage");
            lblPrinterLogo.Text = Additional_Barcode.GetValueByResourceKey("PrintLogo");
            lblRoundTo.Text = Additional_Barcode.GetValueByResourceKey("RoundTo");
            lblSaveBackupIn.Text = Additional_Barcode.GetValueByResourceKey("SaveBackupIn");
            lblSecondLine.Text = Additional_Barcode.GetValueByResourceKey("SecondLine");
            lblShowTaxInTheInvoice1.Text = Additional_Barcode.GetValueByResourceKey("ShowTaxInvoice");
            lblShowTaxInTheInvoice2.Text = Additional_Barcode.GetValueByResourceKey("ShowTaxInvoice");
            lblSubPercentage1.Text = Additional_Barcode.GetValueByResourceKey("SupPercentage");
            lblSubPercentage2.Text = Additional_Barcode.GetValueByResourceKey("SupPercentage");
            lblTaxName1.Text = Additional_Barcode.GetValueByResourceKey("TaxName");
            lblTaxName2.Text = Additional_Barcode.GetValueByResourceKey("TaxName");
            lblTimesADay.Text = Additional_Barcode.GetValueByResourceKey("TimesDay");
            lblTimesADay2.Text = Additional_Barcode.GetValueByResourceKey("TimesDay");
            lblTimestoAlertOnExpiry.Text = Additional_Barcode.GetValueByResourceKey("TimeToExpiry");
            lblTimesToAlertOnReOrderitems.Text = Additional_Barcode.GetValueByResourceKey("TimeToReorder");
            lblType.Text = Additional_Barcode.GetValueByResourceKey("Type");
            lblVerify.Text = Additional_Barcode.GetValueByResourceKey("Verify");
            lblWelcomeNote.Text = Additional_Barcode.GetValueByResourceKey("WelComeNote");
            lblWelcomeNote2.Text = Additional_Barcode.GetValueByResourceKey("WelComeNote");
            lblDays1.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays10.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays2.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays3.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays4.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays5.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays6.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays7.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays8.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDays9.Text = Additional_Barcode.GetValueByResourceKey("Days");
            lblDateFormat.Text = Additional_Barcode.GetValueByResourceKey("DateFormat");
            lblUserGroup.Text = Additional_Barcode.GetValueByResourceKey("UG");
            Chk_AutoStartwithWindow.Text = Additional_Barcode.GetValueByResourceKey("ASW");
            Chk_HideDiscountWindow.Text = Additional_Barcode.GetValueByResourceKey("HCF");//HDW
            Chk_HideWelcomeWindow.Text = Additional_Barcode.GetValueByResourceKey("HWW");
            Chk_ShowCompanyNameOnly.Text = Additional_Barcode.GetValueByResourceKey("SCN");
            Chk_ShowCompanyOnInvoice.Text = Additional_Barcode.GetValueByResourceKey("SCI");
            chkShowDiscountFiled.Text = Additional_Barcode.GetValueByResourceKey("SDF");
            chkShowHidenItem.Text = Additional_Barcode.GetValueByResourceKey("SHI");
            chkShowNonStockItem.Text = Additional_Barcode.GetValueByResourceKey("ShowNonStockItem");
            Chk_HideNoteFiled.Text = Additional_Barcode.GetValueByResourceKey("HNF");

            chkAlterwhenSellingLessthanCost.Text = Additional_Barcode.GetValueByResourceKey("WhenAlertLC");
            chkDevideDiscountBeforeClosingInvoice.Text = Additional_Barcode.GetValueByResourceKey("DivideDiscount");
            chkDisableDiscountFiled.Text = Additional_Barcode.GetValueByResourceKey("DDF");
            chkHidePriceChangingButton.Text = Additional_Barcode.GetValueByResourceKey("HidePrice");
            chkOpenInvioceAfterClosing.Text = Additional_Barcode.GetValueByResourceKey("OpenInvoice");
            chkPurchase_AddItemDirectlywithBarcode.Text = Additional_Barcode.GetValueByResourceKey("AddItemDB");
            chkPurchase_HideDevidingDiscountOnItem.Text = Additional_Barcode.GetValueByResourceKey("HDonItem");
            Chk_Purchase_HideExpiryFiled.Text = Additional_Barcode.GetValueByResourceKey("HEF");
            Chk_HideExpiryFiled.Text = Additional_Barcode.GetValueByResourceKey("HEF");
            ckhAutoItemPrice.Text = Additional_Barcode.GetValueByResourceKey("AutoPriceItem");
            chkPurchase_SaveUsernameOnInvoice.Text = Additional_Barcode.GetValueByResourceKey("SaveUN");
            Chk_Sale_AddItemDirectlywithBarcode.Text = Additional_Barcode.GetValueByResourceKey("AddItemDB");
            chkSale_HideDevidingDiscountOnItem.Text = Additional_Barcode.GetValueByResourceKey("HDonItem");
            chkSale_HideExpiryFiled.Text = Additional_Barcode.GetValueByResourceKey("HEF");
            chkSale_SaveUsernameOnInvoice.Text = Additional_Barcode.GetValueByResourceKey("SaveUN");
            chkSalePriceReadonly.Text = Additional_Barcode.GetValueByResourceKey("MakeSalesPrice");
            chkShowInvoiceCostFiled.Text = Additional_Barcode.GetValueByResourceKey("ShowInvoiceCF");
            chkShowSubTotalFiled.Text = Additional_Barcode.GetValueByResourceKey("ShowSTF");
            Chk_TabToPrice.Text = Additional_Barcode.GetValueByResourceKey("TTPrice");
            chk24HourWorkSystem.Text = Additional_Barcode.GetValueByResourceKey("WorkSys");
            chkAlertForMultiExpiry.Text = Additional_Barcode.GetValueByResourceKey("MultiExpiry");
            chkAlertForReorders.Text = Additional_Barcode.GetValueByResourceKey("AlertforReorder");
            chkAlertPayDates.Text = Additional_Barcode.GetValueByResourceKey("AlertPayDate");
            chkAlertSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("AlertSaleInvoice");
            chkAlertWhenNotMakingBackup.Text = Additional_Barcode.GetValueByResourceKey("AlertNotBackup");
            chkAlertWithSound.Text = Additional_Barcode.GetValueByResourceKey("AlertWithSound");
            chkAskWhenReplacingFile.Text = Additional_Barcode.GetValueByResourceKey("AskReplaceFile");
            Chk_AttendancePermit.Text = Additional_Barcode.GetValueByResourceKey("AttandancePermit");
            chkAskWhenLeavingSystem.Text = Additional_Barcode.GetValueByResourceKey("AskWhenLive");
            chkAutomaticBackupWhenClosing.Text = Additional_Barcode.GetValueByResourceKey("MABClosing");
            chkBranchBuyswithCost.Text = Additional_Barcode.GetValueByResourceKey("BuyswithCost");
            chkCalculateSalaryFromStartDay.Text = Additional_Barcode.GetValueByResourceKey("CalSalSD");
            Chk_CertificateofHealth.Text = Additional_Barcode.GetValueByResourceKey("CertificateHealth");
            chkUnifyOptionForallWorkStations.Text = Additional_Barcode.GetValueByResourceKey("UnifyOption");
            chkCountOverTimeAutomatically.Text = Additional_Barcode.GetValueByResourceKey("CountAutoOT");
            chkCountOverTimeForHolidays.Text = Additional_Barcode.GetValueByResourceKey("CountEmpOT");
            chkCountSalaryFromRegistrationPoint.Text = Additional_Barcode.GetValueByResourceKey("CountSal");
            chkCountSystemStarupMinutes.Text = Additional_Barcode.GetValueByResourceKey("CountSys");
            chkCutDeficits.Text = Additional_Barcode.GetValueByResourceKey("CutDeficits");
            chkCutLatencyAutomatically.Text = Additional_Barcode.GetValueByResourceKey("CutLatency");
            chkDontAlertDeleteItemFromInvoice.Text = Additional_Barcode.GetValueByResourceKey("DontAlertDelete");
            chkDontAlertForExpiryInNotes.Text = Additional_Barcode.GetValueByResourceKey("DontAlertExpiry");
            chkDontAlertOnSave.Text = Additional_Barcode.GetValueByResourceKey("DontAlertOnSave");
            chkDontAskClosingSystem.Text = Additional_Barcode.GetValueByResourceKey("DontAskClosingSystem");
            chkDontIssueReorderInvoice.Text = Additional_Barcode.GetValueByResourceKey("DontIssue");
            chkDontTabToReorderandMaxpoint.Text = Additional_Barcode.GetValueByResourceKey("DontTap");
            chkDrawerOpenDirectlyAfterPrint.Text = Additional_Barcode.GetValueByResourceKey("OpenDirectelyAfterPrint");
            chkDrawerProtectWithPassword.Text = Additional_Barcode.GetValueByResourceKey("ProtectWithPassword");
            chkHideDiscountFiledOnPrint.Text = Additional_Barcode.GetValueByResourceKey("HDonPrint");
            chkHideItemCostInSales.Text = Additional_Barcode.GetValueByResourceKey("HideItemCost");
            chkHideItemNumber.Text = Additional_Barcode.GetValueByResourceKey("HideItem");
            chkHideItemSaleTimeInInvoice.Text = Additional_Barcode.GetValueByResourceKey("HideItemSales");
            chkHideLogoOnPrint.Text = Additional_Barcode.GetValueByResourceKey("HLonPrint");
            chkHidePeaceBoxInPrint.Text = Additional_Barcode.GetValueByResourceKey("HidePeaceBox");
            chkHidePackageQuantity.Text = Additional_Barcode.GetValueByResourceKey("HidePackageQty");
            chkHidePackageReport.Text = Additional_Barcode.GetValueByResourceKey("HidePackageReport");
            chkHidePOSScreen.Text = Additional_Barcode.GetValueByResourceKey("HidePOSScreen");
            chkHidePOSShortcut.Text = Additional_Barcode.GetValueByResourceKey("HidePOSShortCut");
            chkHideTaxFiled.Text = Additional_Barcode.GetValueByResourceKey("HTF");
            chkIgnoreNonStockItem.Text = Additional_Barcode.GetValueByResourceKey("INonStock");
            Chk_Licenserenewal.Text = Additional_Barcode.GetValueByResourceKey("LicensenceRenewal");
            Chk_MedicalInsurance.Text = Additional_Barcode.GetValueByResourceKey("MedicalInsurance");
            chkMonitorReorderAndMaxpoint.Text = Additional_Barcode.GetValueByResourceKey("MonitorReorder");
            chkPosCategoryVicePrint.Text = Additional_Barcode.GetValueByResourceKey("POSCatPrint");
            chkPrintAfterClosingInvoice.Text = Additional_Barcode.GetValueByResourceKey("PrintAfterClose");
            chkPrintAfterClosingRecipt.Text = Additional_Barcode.GetValueByResourceKey("PClosingReceipt");
            chkPrintTotalQuantity.Text = Additional_Barcode.GetValueByResourceKey("PTQty");
            chkQuitWithoutAsking.Text = Additional_Barcode.GetValueByResourceKey("Quit");
            Chk_RoundPriceOnDiscount.Text = Additional_Barcode.GetValueByResourceKey("RoundPrice");
            chkSaveAutomaticBackupInAlternativePath.Text = Additional_Barcode.GetValueByResourceKey("SaveBackupAlertPath");
            chkSaveFilenameWithDatetime.Text = Additional_Barcode.GetValueByResourceKey("SavewithDT");
            chkSellExpiryWenNotEnough.Text = Additional_Barcode.GetValueByResourceKey("SellExpiry");
            chkShowDeptOnPrint.Text = Additional_Barcode.GetValueByResourceKey("SDonPrint");
            chkShowTime.Text = Additional_Barcode.GetValueByResourceKey("STonIR");
            chkShowTipDayWhenStart.Text = Additional_Barcode.GetValueByResourceKey("ShowTip");
            chkStopDeptSellings.Text = Additional_Barcode.GetValueByResourceKey("StopDebtSelling");
            chkStopEmployeeCalculations.Text = Additional_Barcode.GetValueByResourceKey("StopEmpCal");
            chkTax1_ApplyBeforeDiscount.Text = Additional_Barcode.GetValueByResourceKey("ApplyBeforeDiscount");
            chkTax1_ApplyMaintains.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnMaintance");
            chkTax1_ApplyPurchase.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnPurchase");
            chkTax1_ApplySales.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnSales");
            chkTax2_ApplyBeforeDiscount.Text = Additional_Barcode.GetValueByResourceKey("ApplyBeforeDiscount");
            chkTax2_ApplyMaintains.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnMaintance");
            chkTax2_ApplyPurchase.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnPurchase");
            chkTax2_ApplySales.Text = Additional_Barcode.GetValueByResourceKey("ApplyOnSales");
            chkTrackUsers.Text = Additional_Barcode.GetValueByResourceKey("TrackUser");
            chkUseCashDrawer.Text = Additional_Barcode.GetValueByResourceKey("UseCD");
            chkUseCustomerDisplay.Text = Additional_Barcode.GetValueByResourceKey("UseCustDisplay");
            chkUseExpiryDefaultInItemCard.Text = Additional_Barcode.GetValueByResourceKey("UseExpiry");
            chkUseItemPhoto.Text = Additional_Barcode.GetValueByResourceKey("UseItemPhoto");
            chkHideExportImport.Text = Additional_Barcode.GetValueByResourceKey("Hideexportimportbuttonsfrominvoices");
            Chk_Zakat.Text = Additional_Barcode.GetValueByResourceKey("Zakat");
            chkInsertItemIndividually.Text = Additional_Barcode.GetValueByResourceKey("InsertIndividually");
            chkHidePaidRefund.Text = Additional_Barcode.GetValueByResourceKey("HidePaidRefund");
            chkSaleDontUseExpiry.Text = chkPurchaseDontUseExpiry.Text = Additional_Barcode.GetValueByResourceKey("DontUseExpiryintheSystem");
            grbCustDisplay.Text = Additional_Barcode.GetValueByResourceKey("CustDisplay");
            grbBackup.Text = Additional_Barcode.GetValueByResourceKey("BackupOption");
            grbCashDraw.Text = Additional_Barcode.GetValueByResourceKey("CashDrawer");
            grbEmployeeOption.Text = Additional_Barcode.GetValueByResourceKey("EmpOption");
            grbItem.Text = Additional_Barcode.GetValueByResourceKey("Item");
            grbLastBackupDate.Text = Additional_Barcode.GetValueByResourceKey("LastBackup");
            grbNotesArea.Text = Additional_Barcode.GetValueByResourceKey("NotesArea");
            grbNotifyBefore.Text = Additional_Barcode.GetValueByResourceKey("NotifyBefore");
            grbNotifyDate.Text = Additional_Barcode.GetValueByResourceKey("NotifyDate");
            grbNotifyOn.Text = Additional_Barcode.GetValueByResourceKey("NotifyOn");
            grbOtherOption.Text = Additional_Barcode.GetValueByResourceKey("OtherOption");
            grbPheripheralOption.Text = Additional_Barcode.GetValueByResourceKey("PeripheralOption");
            grbPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintOption");
            grbPurchaseInv.Text = Additional_Barcode.GetValueByResourceKey("PurInvoice");
            grbSaleInv.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            grbTax1.Text = Additional_Barcode.GetValueByResourceKey("Tax1");
            grbTax2.Text = Additional_Barcode.GetValueByResourceKey("Tax2");
            grbTaxOption.Text = Additional_Barcode.GetValueByResourceKey("TaxOption");
            grbWindowOptions.Text = Additional_Barcode.GetValueByResourceKey("WinOption");
            grbNotify.Text = Additional_Barcode.GetValueByResourceKey("Notification");
            grbCompanyInfo.Text = Additional_Barcode.GetValueByResourceKey("CompanyInfo");

            btnApply.Text = Additional_Barcode.GetValueByResourceKey("Apply");
            btnBrowseFooter.Text = Additional_Barcode.GetValueByResourceKey("Browse");
            btnBrowseHeader.Text = Additional_Barcode.GetValueByResourceKey("Browse");
            btnCleanDB.Text = Additional_Barcode.GetValueByResourceKey("CleanDB");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnCommunicate.Text = Additional_Barcode.GetValueByResourceKey("Communicate");
            btnDeleteFooter.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnDeleteHeader.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnOk.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            btnopenDrawer.Text = Additional_Barcode.GetValueByResourceKey("OpenDrawer");
            btnRestore.Text = Additional_Barcode.GetValueByResourceKey("RestoreDefault");
            btnRestore_Backup.Text = Additional_Barcode.GetValueByResourceKey("RestoreBackup");
            btnSave_Backup.Text = Additional_Barcode.GetValueByResourceKey("SaveBackUp");
            btnStartNewYear.Text = Additional_Barcode.GetValueByResourceKey("StartNewYear");
            btnImport.Text = Additional_Barcode.GetValueByResourceKey("ImportInv");
            rbnDrawerTypeCOM.Text = Additional_Barcode.GetValueByResourceKey("C");
            rbnDrawerTypeRJ11.Text = Additional_Barcode.GetValueByResourceKey("RJ11");
            rbnDrawerTypeUSP.Text = Additional_Barcode.GetValueByResourceKey("USB");

            Tab_Backup.Text = Additional_Barcode.GetValueByResourceKey("Backup");
            Tab_Employee.Text = Additional_Barcode.GetValueByResourceKey("Emp");
            Tab_General.Text = Additional_Barcode.GetValueByResourceKey("General");
            Tab_Invoice.Text = Additional_Barcode.GetValueByResourceKey("Invoice");
            Tab_Items.Text = Additional_Barcode.GetValueByResourceKey("Item");
            Tab_Notifications.Text = Additional_Barcode.GetValueByResourceKey("Notification");
            Tab_Other.Text = Additional_Barcode.GetValueByResourceKey("Other");
            Tab_Peripherals.Text = Additional_Barcode.GetValueByResourceKey("Peripherals");
            Tab_Print.Text = Additional_Barcode.GetValueByResourceKey("Print");
            Tab_Tax.Text = Additional_Barcode.GetValueByResourceKey("Tax");
            this.Text = Additional_Barcode.GetValueByResourceKey("OptionSetting");

            //This is added to display tax mode for both language. Done By A.Manoj On June-25
            Cmb_Tax1_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("Percentage"));
            Cmb_Tax1_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("TAmount"));
            Cmb_Tax1_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("PercentTotalAmt"));
            Cmb_Tax1_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("DoNotShow"));

            Cmb_RoundPricesOnDiscountValue.Items.Add(Additional_Barcode.GetValueByResourceKey("RoundUp"));
            Cmb_RoundPricesOnDiscountValue.Items.Add(Additional_Barcode.GetValueByResourceKey("RoundDown"));
            //******************************************************************************

            //****Below resources are added on 4-July-2014 by Seenivasan***********************************

            //Tax 2
            Cmb_Tax2_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("Percentage"));
            Cmb_Tax2_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("TAmount"));
            Cmb_Tax2_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("PercentTotalAmt"));
            Cmb_Tax2_ShowTaxInvoice.Items.Add(Additional_Barcode.GetValueByResourceKey("DoNotShow"));

            //Invoice Template
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4Base"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4Detailed"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4Simple"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4Complete"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4BaseLandscape"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4DetailedLandscape"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4SimpleLandscape"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4CompleteLandscape"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A5Base"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A5Detailed"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A5Simple"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A5Complete"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("RoolPaper80mm"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("RoolPaper63mm"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill2"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill3"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill4"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill5"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill6"));
            Cmb_InvoiceTemplate.Items.Add(Additional_Barcode.GetValueByResourceKey("A4NewBill7"));
            //Barcode Paper Size
            Cmb_BarcodePaperSize.Items.Add(Additional_Barcode.GetValueByResourceKey("SixtyFivesticker"));
            Cmb_BarcodePaperSize.Items.Add(Additional_Barcode.GetValueByResourceKey("SixtyEightsticker"));
            Cmb_BarcodePaperSize.Items.Add(Additional_Barcode.GetValueByResourceKey("OneFourFivesticker"));

            //Barcode Printer
            Cmb_BarcodePrinter.Items.Add(Additional_Barcode.GetValueByResourceKey("LaserPrinter"));
            Cmb_BarcodePrinter.Items.Add(Additional_Barcode.GetValueByResourceKey("BarcodePrinter"));

            //Print Logo
            Cmb_PrintingLogo.Items.Add(Additional_Barcode.GetValueByResourceKey("CompanyInfo"));
            Cmb_PrintingLogo.Items.Add(Additional_Barcode.GetValueByResourceKey("LogoHeaderandFooter"));
            Cmb_PrintingLogo.Items.Add(Additional_Barcode.GetValueByResourceKey("LogoHeaderonly"));
            Cmb_PrintingLogo.Items.Add(Additional_Barcode.GetValueByResourceKey("CompanyNameonly"));
            Cmb_PrintingLogo.Items.Add(Additional_Barcode.GetValueByResourceKey("CompanyNameandPhone"));

            //Item Sorting
            Cmb_ItemSorting.Items.Add(Additional_Barcode.GetValueByResourceKey("AtoZ"));
            Cmb_ItemSorting.Items.Add(Additional_Barcode.GetValueByResourceKey("ZtoA"));
            Cmb_ItemSorting.Items.Add(Additional_Barcode.GetValueByResourceKey("AsInserted"));
            Cmb_ItemSorting.Items.Add(Additional_Barcode.GetValueByResourceKey("HigherPrice"));
            Cmb_ItemSorting.Items.Add(Additional_Barcode.GetValueByResourceKey("LessPrice"));

            //**********************************************************************************************
            ///Added on 15/10/2014 By Meena.R
            btnAddedQuantity.Text = Additional_Barcode.GetValueByResourceKey("AddRandomQuantity");
            btnExport.Text = Additional_Barcode.GetValueByResourceKey("ItemExport");
            chkResetPOSOrder.Text = Additional_Barcode.GetValueByResourceKey("ResetPOSordernumber");
            lblCount.Text = Additional_Barcode.GetValueByResourceKey("MaxPOSordernumber");

            // Added on 13-Mar-2019 By T
            chkEnableNetworkSaleControl.Text = Additional_Barcode.GetValueByResourceKey("EnableNetwork");
            chkConfirmEndShift.Text = Additional_Barcode.GetValueByResourceKey("ConfirmEndShift");
            ChkOpenNewInvoice.Text = Additional_Barcode.GetValueByResourceKey("OpenNewInvoiceNetwork");

            btnPrinters.Text = Additional_Barcode.GetValueByResourceKey("PrinterOption");
            lblBarcodeSize.Text= Additional_Barcode.GetValueByResourceKey("BarcodeSize");
            // Added on 14-Sept-2019 By T
            chkPriceCheckerActive.Text = Additional_Barcode.GetValueByResourceKey("PriceChecker");

        }
        #endregion

        #region  NotifyVisible
        public void NotifyVisible()
        {
            DTP_LicenserenewalDate.Enabled = UD_LicenserenewalNotifyBefore.Enabled = Chk_Licenserenewal.Checked;
            DTP_MedicalInsuranceDate.Enabled = UD_MedicalInsuranceNotifyBefore.Enabled = Chk_MedicalInsurance.Checked;
            DTP_CertificateofHealthDate.Enabled = UD_CertificateofHealthNotifyBefore.Enabled = Chk_CertificateofHealth.Checked;
            DTP_AttendancePermitDate.Enabled = UD_AttendancePermitNotifyBefore.Enabled = Chk_AttendancePermit.Checked;
            DTP_TechnicalDisclosureDate.Enabled = UD_TechnicalDisclosureNotifyBefore.Enabled = Chk_TechnicalDisclosure.Checked;
            DTP_PricingDate.Enabled = UD_PricingNotifyBefore.Enabled = Chk_Pricing.Checked;
            DTP_PayrentDate.Enabled = UD_PayrentNotifyBefore.Enabled = Chk_Payrent.Checked;
            DTP_DisbursementSalaryDate.Enabled = UD_DisbursementSalaryNotifyBefore.Enabled = Chk_DisbursementSalary.Checked;
            DTP_AnnualInventoryDate.Enabled = UD_AnnualInventoryNotifyBefore.Enabled = Chk_AnnualInventory.Checked;
            DTP_ZakatDate.Enabled = UD_ZakatNotifyBefore.Enabled = Chk_Zakat.Checked;
            //--------Others--------
            if (Chk_RoundPriceOnDiscount.Checked == true)
            {
                Cmb_RoundPricesOnDiscountValue.Enabled = true;
            }
            else
            {
                Cmb_RoundPricesOnDiscountValue.Enabled = false;
            }
            //----------------------
        }
        #endregion

        #region LoadCOMPorts
        void LoadCOMPorts()
        {
            string[] strPorts = System.IO.Ports.SerialPort.GetPortNames();
            Cmb_COMPort.Items.AddRange(strPorts);


        }
        #endregion

        #region CheckBox_CheckedChanged
        //public void CheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    DTP_LicenserenewalDate.Enabled = UD_LicenserenewalNotifyBefore.Enabled = Chk_Licenserenewal.Checked;
        //    DTP_MedicalInsuranceDate.Enabled = UD_MedicalInsuranceNotifyBefore.Enabled = Chk_MedicalInsurance.Checked;
        //    DTP_CertificateofHealthDate.Enabled = UD_CertificateofHealthNotifyBefore.Enabled = Chk_CertificateofHealth.Checked;
        //    DTP_AttendancePermitDate.Enabled = UD_AttendancePermitNotifyBefore.Enabled = Chk_AttendancePermit.Checked;
        //    DTP_ZakatDate.Enabled = UD_ZakatNotifyBefore.Enabled = Chk_Zakat.Checked;

        //    Txt_TextBox1.Enabled = DTP_TechnicalDisclosureDate.Enabled = UD_TechnicalDisclosureNotifyBefore.Enabled = Chk_TechnicalDisclosure.Checked;
        //    Txt_TextBox2.Enabled = DTP_PricingDate.Enabled = UD_PricingNotifyBefore.Enabled = Chk_Pricing.Checked;
        //    Txt_TextBox3.Enabled = DTP_PayrentDate.Enabled = UD_PayrentNotifyBefore.Enabled = Chk_Payrent.Checked;
        //    Txt_TextBox4.Enabled = DTP_DisbursementSalaryDate.Enabled = UD_DisbursementSalaryNotifyBefore.Enabled = Chk_DisbursementSalary.Checked;
        //    Txt_TextBox5.Enabled = DTP_AnnualInventoryDate.Enabled = UD_AnnualInventoryNotifyBefore.Enabled = Chk_AnnualInventory.Checked;

        //}
        #endregion

        #region LoadOptionDatas
        public void LoadOptionDatas()
        {
            List<OptionSettingsObject> lstOptions;
            List<OptionSettingsObject> lstLogo;

            #region Code
            try
            {
                if (UserScreenLimidations.OptionTabGeneral == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_General);

                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_General)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_General);
                }
                if (UserScreenLimidations.OptionTabInvoice == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Invoice);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Invoice)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Invoice);
                }
                if (UserScreenLimidations.OptionTabPrint == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Print);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Print)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Print);
                }
                if (UserScreenLimidations.OptionTabItem == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Items);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Items)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Items);
                }
                if (UserScreenLimidations.OptionTabBackUp == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Backup);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Backup)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Backup);
                }
                if (UserScreenLimidations.OptionTabPeripherals == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Peripherals);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Peripherals)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Peripherals);
                }
                if (UserScreenLimidations.OptionTabTax == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Tax);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Tax)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Tax);
                }
                if (UserScreenLimidations.OptionTabNotification == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Notifications);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Notifications)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Notifications);
                }
                if (UserScreenLimidations.OptionTabOthers == false)
                {
                    CtrlTab_OptionSetting.TabPages.Remove(Tab_Other);
                }
                else if (!(CtrlTab_OptionSetting.TabPages.Contains(Tab_Other)))
                {
                    CtrlTab_OptionSetting.TabPages.Add(Tab_Notifications);
                }
                if (UserScreenLimidations.RestoreBackUp == false)
                {
                    btnRestore_Backup.Visible = false;
                }
                else
                {
                    btnRestore_Backup.Visible = true;
                }
                if (UserScreenLimidations.SaveBackUp == false)
                {
                    btnSave_Backup.Visible = false;
                }
                else
                {
                    btnSave_Backup.Visible = true;
                }
                if (UserScreenLimidations.StartNewYear == false)
                {
                    btnStartNewYear.Visible = false;
                }
                else
                {
                    btnStartNewYear.Visible = true;
                }
                if (UserScreenLimidations.CleanDB == false)
                {
                    btnCleanDB.Visible = false;
                }
                else
                {
                    btnCleanDB.Visible = true;
                }
                if (UserScreenLimidations.CashDrawer == false)
                {
                    btnopenDrawer.Visible = false;
                }
                else
                {
                    btnopenDrawer.Visible = true;
                }
                objOptionSettingHelper.LoadOptions();
                objOptionSettingHelper.LoadLogo();
                lstOptions = objOptionSettingHelper.lstOptions;
                lstLogo = objOptionSettingHelper.lstLogo;
                if (lstLogo.Count > 0)
                {
                    if ((lstLogo[0].HeaderLogo.ToString()) != "" && ((byte[])(lstLogo[0].HeaderLogo)).Length > 1) Pic_Header.Image = new Bitmap(new MemoryStream((byte[])lstLogo[0].HeaderLogo));
                    if ((lstLogo[0].FooterLogo.ToString()) != "" && ((byte[])(lstLogo[0].FooterLogo)).Length > 1) Pic_Footer.Image = new Bitmap(new MemoryStream((byte[])lstLogo[0].FooterLogo));
                }

                if (lstOptions.Count > 0)
                {
                    //----------General--------------------------
                    Txt_Companyname.Text = lstOptions[0].OptionFlag.Trim().ToString();
                    Txt_Phone.Text = lstOptions[1].OptionFlag.ToString();
                    Txt_Cell.Text = lstOptions[2].OptionFlag.ToString();
                    Txt_Fax.Text = lstOptions[3].OptionFlag.ToString();
                    Txt_POBox.Text = lstOptions[4].OptionFlag.ToString();
                    Txt_Email.Text = lstOptions[5].OptionFlag.ToString();
                    Txt_Address.Text = lstOptions[6].OptionFlag.ToString();
                    Txt_SystemNote.Text = lstOptions[7].OptionFlag.ToString();
                    Txt_WorkNote.Text = lstOptions[8].OptionFlag.ToString();
                    Cmb_Langage.SelectedItem = lstOptions[9].OptionFlag.ToString();
                    cmbDateFormat.SelectedItem = lstOptions[177].OptionFlag.ToString();//Added on 28-May-2014
                    if (lstOptions[10].OptionFlag.ToString() == "Y")
                    {
                        Chk_HideDiscountWindow.Checked = true;
                    }
                    else
                    {
                        Chk_HideDiscountWindow.Checked = false;
                    }
                    if (lstOptions[11].OptionFlag.ToString() == "Y")
                    {
                        Chk_HideWelcomeWindow.Checked = true;
                    }
                    else
                    {
                        Chk_HideWelcomeWindow.Checked = false;
                    }
                    if (lstOptions[12].OptionFlag.ToString() == "Y")
                    {
                        Chk_HideNoteFiled.Checked = true;
                    }
                    else
                    {
                        Chk_HideNoteFiled.Checked = false;
                    }
                    //if (dtOption.Rows[13][2].ToString() == "Y")
                    //{
                    //    Chk_HideRentingInvoice.Checked = true;
                    //}
                    //else
                    //{
                    //    Chk_HideRentingInvoice.Checked = false;
                    //}
                    if (lstOptions[14].OptionFlag.ToString() == "Y")
                    {
                        Chk_ShowCompanyOnInvoice.Checked = true;
                    }
                    else
                    {
                        Chk_ShowCompanyOnInvoice.Checked = false;
                    }
                    //if (dtOption.Rows[15][2].ToString() == "Y")
                    //{
                    //    Chk_HideKitchenWindow.Checked = true;
                    //}
                    //else
                    //{
                    //    Chk_HideKitchenWindow.Checked = false;
                    //}
                    if (lstOptions[16].OptionFlag.ToString() == "Y")
                    {
                        Chk_ShowCompanyNameOnly.Checked = true;
                    }
                    else
                    {
                        Chk_ShowCompanyNameOnly.Checked = false;
                    }
                    if (lstOptions[17].OptionFlag.ToString() == "Y")
                    {
                        Chk_AutoStartwithWindow.Checked = true;
                    }
                    else
                    {
                        Chk_AutoStartwithWindow.Checked = false;
                    }
                    //-------------------------------------------
                    //--------Invoice----------------------------

                    if (lstOptions[18].OptionFlag.ToString() == "Y")
                    {
                        Chk_Purchase_HideExpiryFiled.Checked = true;
                    }
                    else
                    {
                        Chk_Purchase_HideExpiryFiled.Checked = false;
                    }
                    if (lstOptions[19].OptionFlag.ToString() == "Y")
                    {
                        chkPurchase_HideDevidingDiscountOnItem.Checked = true;
                    }
                    else
                    {
                        chkPurchase_HideDevidingDiscountOnItem.Checked = false;
                    }
                    if (lstOptions[20].OptionFlag.ToString() == "Y")
                    {
                        chkPurchase_AddItemDirectlywithBarcode.Checked = true;
                    }
                    else
                    {
                        chkPurchase_AddItemDirectlywithBarcode.Checked = false;
                    }
                    if (lstOptions[21].OptionFlag.ToString() == "Y")
                    {
                        Chk_TabToPrice.Checked = true;
                    }
                    else
                    {
                        Chk_TabToPrice.Checked = false;
                    }
                    if (lstOptions[22].OptionFlag.ToString() == "Y")
                    {
                        chkShowDiscountFiled.Checked = true;
                    }
                    else
                    {
                        chkShowDiscountFiled.Checked = false;
                    }
                    if (lstOptions[23].OptionFlag.ToString() == "Y")
                    {
                        chkShowHidenItem.Checked = true;
                    }
                    else
                    {
                        chkShowHidenItem.Checked = false;
                    }
                    if (lstOptions[24].OptionFlag.ToString() == "Y")
                    {
                        chkPurchase_SaveUsernameOnInvoice.Checked = true;
                    }
                    else
                    {
                        chkPurchase_SaveUsernameOnInvoice.Checked = false;
                    }
                    if (lstOptions[25].OptionFlag.ToString() == "Y")
                    {
                        chkHidePriceChangingButton.Checked = true;
                    }
                    else
                    {
                        chkHidePriceChangingButton.Checked = false;
                    }
                    if (lstOptions[26].OptionFlag.ToString() == "Y")
                    {
                        chkSalePriceReadonly.Checked = true;
                    }
                    else
                    {
                        chkSalePriceReadonly.Checked = false;
                    }
                    if (lstOptions[27].OptionFlag.ToString() == "Y")
                    {
                        Chk_Sale_AddItemDirectlywithBarcode.Checked = true;
                    }
                    else
                    {
                        Chk_Sale_AddItemDirectlywithBarcode.Checked = false;
                    }
                    if (lstOptions[28].OptionFlag.ToString() == "Y")
                    {
                        chkOpenInvioceAfterClosing.Checked = true;
                    }
                    else
                    {
                        chkOpenInvioceAfterClosing.Checked = false;
                    }
                    if (lstOptions[29].OptionFlag.ToString() == "Y")
                    {
                        chkSale_HideExpiryFiled.Checked = true;
                    }
                    else
                    {
                        chkSale_HideExpiryFiled.Checked = false;
                    }
                    if (lstOptions[30].OptionFlag.ToString() == "Y")
                    {
                        chkDevideDiscountBeforeClosingInvoice.Checked = true;
                    }
                    else
                    {
                        chkDevideDiscountBeforeClosingInvoice.Checked = false;
                    }
                    if (lstOptions[31].OptionFlag.ToString() == "Y")
                    {
                        chkAlterwhenSellingLessthanCost.Checked = true;
                    }
                    else
                    {
                        chkAlterwhenSellingLessthanCost.Checked = false;
                    }
                    if (lstOptions[32].OptionFlag.ToString() == "Y")
                    {
                        chkShowSubTotalFiled.Checked = true;
                    }
                    else
                    {
                        chkShowSubTotalFiled.Checked = false;
                    }
                    if (lstOptions[33].OptionFlag.ToString() == "Y")
                    {
                        chkShowNonStockItem.Checked = true;
                    }
                    else
                    {
                        chkShowNonStockItem.Checked = false;
                    }
                    if (lstOptions[34].OptionFlag.ToString() == "Y")
                    {
                        chkSale_SaveUsernameOnInvoice.Checked = true;
                    }
                    else
                    {
                        chkSale_SaveUsernameOnInvoice.Checked = false;
                    }
                    if (lstOptions[35].OptionFlag.ToString() == "Y")
                    {
                        chkShowInvoiceCostFiled.Checked = true;
                    }
                    else
                    {
                        chkShowInvoiceCostFiled.Checked = false;
                    }
                    if (lstOptions[36].OptionFlag.ToString() == "Y")
                    {
                        chkDisableDiscountFiled.Checked = true;
                    }
                    else
                    {
                        chkDisableDiscountFiled.Checked = false;
                    }
                    if (lstOptions[37].OptionFlag.ToString() == "Y")
                    {
                        chkSale_HideDevidingDiscountOnItem.Checked = true;
                    }
                    else
                    {
                        chkSale_HideDevidingDiscountOnItem.Checked = false;
                    }
                    if (lstOptions[175].OptionFlag.ToString() == "Y")
                    {
                        chkInsertItemIndividually.Checked = true;
                    }
                    else
                    {
                        chkInsertItemIndividually.Checked = false;
                    }
                    if (lstOptions[176].OptionFlag.ToString() == "Y")
                    {
                        chkHidePaidRefund.Checked = true;
                    }
                    else
                    {
                        chkHidePaidRefund.Checked = false;
                    }
                    if (lstOptions[178].OptionFlag.ToString() == "Y")
                    {
                        chkHideExportImport.Checked = true;
                    }
                    else
                    {
                        chkHideExportImport.Checked = false;
                    }
                    if (lstOptions[179].OptionFlag.ToString() == "Y")
                    {
                        chkPurchaseDontUseExpiry.Checked = true;
                    }
                    else
                    {
                        chkPurchaseDontUseExpiry.Checked = false;
                    }
                    if (lstOptions[180].OptionFlag.ToString() == "Y")
                    {
                        chkSaleDontUseExpiry.Checked = true;
                    }
                    else
                    {
                        chkSaleDontUseExpiry.Checked = false;
                    }
                    if (lstOptions[18].OptionFlag.ToString() == "Y")
                    {
                        Chk_HideExpiryFiled.Checked = true;
                    }
                    else
                    {

                        Chk_HideExpiryFiled.Checked = false;
                    }
                    if (lstOptions[186].OptionFlag.ToString() == "Y")
                    {
                        chkActivatePaymentType.Checked = true;
                    }
                    else
                    {

                        chkActivatePaymentType.Checked = false;
                    }
                    //------------------------------------
                    //--------Print-----------------------

                    Cmb_InvoiceTemplate.SelectedIndex = int.Parse(lstOptions[38].OptionFlag.ToString());
                    Cmb_BarcodePaperSize.SelectedIndex = int.Parse(lstOptions[39].OptionFlag.ToString());
                    Cmb_BarcodePrinter.SelectedIndex = int.Parse(lstOptions[40].OptionFlag.ToString());
                    Cmb_PrintingLogo.SelectedIndex = int.Parse(lstOptions[41].OptionFlag.ToString());
                    Cmb_ItemSorting.SelectedIndex = int.Parse(lstOptions[42].OptionFlag.ToString());
                    txtBarcodeSize.Text = lstOptions[198].OptionFlag.ToString();
                    if (lstOptions[43].OptionFlag.ToString() != "")
                    {
                        UD_InvoiceCopies.Value = Convert.ToDecimal(lstOptions[43].OptionFlag.ToString());
                    }
                    if (lstOptions[44].OptionFlag.ToString() != "")
                    {
                        UD_ReciptCopies.Value = Convert.ToDecimal(lstOptions[44].OptionFlag.ToString());
                    }
                    if (lstOptions[45].OptionFlag.ToString() != "")
                    {
                        UD_Header.Value = Convert.ToDecimal(lstOptions[45].OptionFlag.ToString());
                    }
                    if (lstOptions[46].OptionFlag.ToString() != "")
                    {
                        UD_Footer.Value = Convert.ToDecimal(lstOptions[46].OptionFlag.ToString());
                    }
                    //Txt_LogoHeader.Text = dtOption.Rows[47][2].ToString();
                    //Txt_LogoFooter.Text = dtOption.Rows[48][2].ToString();
                    //if (Txt_LogoHeader.Text != string.Empty) Pic_Header.Image = new Bitmap(Txt_LogoHeader.Text.Trim());
                    //if (Txt_LogoFooter.Text != string.Empty) Pic_Footer.Image = new Bitmap(Txt_LogoFooter.Text.Trim());
                    Txt_NoteSaleInvoice.Text = lstOptions[49].OptionFlag.ToString();
                    if (lstOptions[50].OptionFlag.ToString() == "Y")
                    {
                        chkPrintAfterClosingInvoice.Checked = true;
                    }
                    else
                    {
                        chkPrintAfterClosingInvoice.Checked = false;
                    }
                    if (lstOptions[51].OptionFlag.ToString() == "Y")
                    {
                        chkPrintAfterClosingRecipt.Checked = true;
                    }
                    else
                    {
                        chkPrintAfterClosingRecipt.Checked = false;
                    }
                    if (lstOptions[52].OptionFlag.ToString() == "Y")
                    {
                        chkPrintTotalQuantity.Checked = true;
                    }
                    else
                    {
                        chkPrintTotalQuantity.Checked = false;
                    }
                    if (lstOptions[53].OptionFlag.ToString() == "Y")
                    {
                        chkHideDiscountFiledOnPrint.Checked = true;
                    }
                    else
                    {
                        chkHideDiscountFiledOnPrint.Checked = false;
                    }
                    if (lstOptions[54].OptionFlag.ToString() == "Y")
                    {
                        chkShowTime.Checked = true;
                    }
                    else
                    {
                        chkShowTime.Checked = false;
                    }
                    if (lstOptions[55].OptionFlag.ToString() == "Y")
                    {
                        chkHideTaxFiled.Checked = true;
                    }
                    else
                    {
                        chkHideTaxFiled.Checked = false;
                    }
                    if (lstOptions[56].OptionFlag.ToString() == "Y")
                    {
                        chkHideLogoOnPrint.Checked = true;
                    }
                    else
                    {
                        chkHideLogoOnPrint.Checked = false;
                    }
                    if (lstOptions[189].OptionFlag.ToString() == "Y")
                    {
                        chkHidePeaceBoxInPrint.Checked = true;
                    }
                    else
                    {
                        chkHidePeaceBoxInPrint.Checked = false;
                    }
                    if (lstOptions[57].OptionFlag.ToString() == "Y")
                    {
                        chkShowDeptOnPrint.Checked = true;
                    }
                    else
                    {
                        chkShowDeptOnPrint.Checked = false;
                    }
                    if (lstOptions[58].OptionFlag.ToString() == "Y")
                    {
                        chkIgnoreNonStockItem.Checked = true;
                    }
                    else
                    {
                        chkIgnoreNonStockItem.Checked = false;
                    }
                    if (lstOptions[174].OptionFlag.ToString() == "Y")
                    {
                        chkPosCategoryVicePrint.Checked = true;
                    }
                    else
                    {
                        chkPosCategoryVicePrint.Checked = false;
                    }


                    //------------------------------------
                    //--------Item-----------------------

                    if (lstOptions[59].OptionFlag.ToString() != "")
                    {
                        UD_AlertExpiry.Value = Convert.ToDecimal(lstOptions[59].OptionFlag.ToString());
                    }
                    if (lstOptions[60].OptionFlag.ToString() != "")
                    {
                        UD_AlertReorderItem.Value = Convert.ToDecimal(lstOptions[60].OptionFlag.ToString());
                    }
                    if (lstOptions[61].OptionFlag.ToString() != "")
                    {
                        UD_IssueOrderInvoice.Value = Convert.ToDecimal(lstOptions[61].OptionFlag.ToString());
                    }
                    if (lstOptions[62].OptionFlag.ToString() == "Y")
                    {
                        chkAlertForReorders.Checked = true;
                    }
                    else
                    {
                        chkAlertForReorders.Checked = false;
                    }
                    if (lstOptions[63].OptionFlag.ToString() == "Y")
                    {
                        chkDontIssueReorderInvoice.Checked = true;
                    }
                    else
                    {
                        chkDontIssueReorderInvoice.Checked = false;
                    }
                    if (lstOptions[64].OptionFlag.ToString() == "Y")
                    {
                        chkHideItemSaleTimeInInvoice.Checked = true;
                    }
                    else
                    {
                        chkHideItemSaleTimeInInvoice.Checked = false;
                    }
                    if (lstOptions[65].OptionFlag.ToString() == "Y")
                    {
                        chkHideItemCostInSales.Checked = true;
                    }
                    else
                    {
                        chkHideItemCostInSales.Checked = false;
                    }
                    if (lstOptions[66].OptionFlag.ToString() == "Y")
                    {
                        chkHideItemNumber.Checked = true;
                    }
                    else
                    {
                        chkHideItemNumber.Checked = false;
                    }
                    if (lstOptions[67].OptionFlag.ToString() == "Y")
                    {
                        chkDontTabToReorderandMaxpoint.Checked = true;
                    }
                    else
                    {
                        chkDontTabToReorderandMaxpoint.Checked = false;
                    }
                    if (lstOptions[68].OptionFlag.ToString() == "Y")
                    {
                        chkDontAlertForExpiryInNotes.Checked = true;
                    }
                    else
                    {
                        chkDontAlertForExpiryInNotes.Checked = false;
                    }
                    if (lstOptions[69].OptionFlag.ToString() == "Y")
                    {
                        chkQuitWithoutAsking.Checked = true;
                    }
                    else
                    {
                        chkQuitWithoutAsking.Checked = false;
                    }
                    if (lstOptions[70].OptionFlag.ToString() == "Y")
                    {
                        chkSellExpiryWenNotEnough.Checked = true;
                    }
                    else
                    {
                        chkSellExpiryWenNotEnough.Checked = false;
                    }
                    if (lstOptions[71].OptionFlag.ToString() == "Y")
                    {
                        chkAlertForMultiExpiry.Checked = true;
                    }
                    else
                    {
                        chkAlertForMultiExpiry.Checked = false;
                    }
                    if (lstOptions[72].OptionFlag.ToString() == "Y")
                    {
                        chkUseExpiryDefaultInItemCard.Checked = true;
                    }
                    else
                    {
                        chkUseExpiryDefaultInItemCard.Checked = false;
                    }
                    if (lstOptions[73].OptionFlag.ToString() == "Y")
                    {
                        chkHidePackageQuantity.Checked = true;
                    }
                    else
                    {
                        chkHidePackageQuantity.Checked = false;
                    }
                    if (lstOptions[74].OptionFlag.ToString() == "Y")
                    {
                        chkMonitorReorderAndMaxpoint.Checked = true;
                    }
                    else
                    {
                        chkMonitorReorderAndMaxpoint.Checked = false;
                    }
                    if (lstOptions[183].OptionFlag.ToString() == "Y")
                    {
                        ckhAutoItemPrice.Checked = true;
                        txtAutoItemPrice.Text = lstOptions[184].OptionFlag.ToString();
                        txtAutoItemPrice.Enabled = true;
                    }
                    else
                    {
                        ckhAutoItemPrice.Checked = false;
                        txtAutoItemPrice.Text = "";
                        txtAutoItemPrice.Enabled = false;
                    }

                    //------------------------------------
                    //--------Employee-----------------------

                    Cmb_CalculateSalary.SelectedIndex = int.Parse(lstOptions[75].OptionFlag.ToString());
                    Cmb_Holiday.SelectedIndex = int.Parse(lstOptions[76].OptionFlag.ToString());
                    if (lstOptions[77].OptionFlag.ToString() == "Y")
                    {
                        chkCalculateSalaryFromStartDay.Checked = true;
                    }
                    else
                    {
                        chkCalculateSalaryFromStartDay.Checked = false;
                    }
                    if (lstOptions[78].OptionFlag.ToString() == "Y")
                    {
                        chkCutLatencyAutomatically.Checked = true;
                    }
                    else
                    {
                        chkCutLatencyAutomatically.Checked = false;
                    }
                    if (lstOptions[79].OptionFlag.ToString() == "Y")
                    {
                        chkCountSalaryFromRegistrationPoint.Checked = true;
                    }
                    else
                    {
                        chkCountSalaryFromRegistrationPoint.Checked = false;
                    }
                    if (lstOptions[80].OptionFlag.ToString() == "Y")
                    {
                        chkCutDeficits.Checked = true;
                    }
                    else
                    {
                        chkCutDeficits.Checked = false;
                    }
                    if (lstOptions[81].OptionFlag.ToString() == "Y")
                    {
                        chkTrackUsers.Checked = true;
                    }
                    else
                    {
                        chkTrackUsers.Checked = false;
                    }
                    if (lstOptions[82].OptionFlag.ToString() == "Y")
                    {
                        chkCountSystemStarupMinutes.Checked = true;
                    }
                    else
                    {
                        chkCountSystemStarupMinutes.Checked = false;
                    }
                    if (lstOptions[83].OptionFlag.ToString() == "Y")
                    {
                        chkCountOverTimeAutomatically.Checked = true;
                    }
                    else
                    {
                        chkCountOverTimeAutomatically.Checked = false;
                    }
                    if (lstOptions[84].OptionFlag.ToString() == "Y")
                    {
                        chkCountOverTimeForHolidays.Checked = true;
                    }
                    else
                    {
                        chkCountOverTimeForHolidays.Checked = false;
                    }
                    if (lstOptions[85].OptionFlag.ToString() == "Y")
                    {
                        chkStopEmployeeCalculations.Checked = true;
                    }
                    else
                    {
                        chkStopEmployeeCalculations.Checked = false;
                    }

                    //------------------------------------
                    //--------Backup-----------------------

                    if (lstOptions[86].OptionFlag.ToString() == "Y")
                    {
                        chkAskWhenLeavingSystem.Checked = true;
                    }
                    else
                    {
                        chkAskWhenLeavingSystem.Checked = false;
                    }
                    if (lstOptions[87].OptionFlag.ToString() == "Y")
                    {
                        chkAutomaticBackupWhenClosing.Checked = true;
                    }
                    else
                    {
                        chkAutomaticBackupWhenClosing.Checked = false;
                    }
                    if (lstOptions[88].OptionFlag.ToString() == "Y")
                    {
                        chkAskWhenReplacingFile.Checked = true;
                    }
                    else
                    {
                        chkAskWhenReplacingFile.Checked = false;
                    }
                    if (lstOptions[89].OptionFlag.ToString() == "Y")
                    {
                        chkSaveAutomaticBackupInAlternativePath.Checked = true;
                    }
                    else
                    {
                        chkSaveAutomaticBackupInAlternativePath.Checked = false;
                    }
                    if (lstOptions[90].OptionFlag.ToString() == "Y")
                    {
                        chkSaveFilenameWithDatetime.Checked = true;
                    }
                    else
                    {
                        chkSaveFilenameWithDatetime.Checked = false;
                    }
                    if (lstOptions[91].OptionFlag.ToString() == "Y")
                    {
                        chkAlertWhenNotMakingBackup.Checked = true;
                    }
                    else
                    {
                        chkAlertWhenNotMakingBackup.Checked = false;
                    }

                    if (lstOptions[92].OptionFlag.ToString() != "")
                    {
                        UD_AutomaticBackupDays.Value = Convert.ToDecimal(lstOptions[92].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AutomaticBackupDays.Value = 0;
                    }
                    Txt_SaveBackup.Text = lstOptions[93].OptionFlag.ToString();
                    Txt_AlternativePath.Text = lstOptions[94].OptionFlag.ToString();
                    Txt_LastBackupDate.Text = lstOptions[95].OptionFlag.ToString();
                    //Txt_LastBackupDate.Text = Convert.ToDateTime(lstOptions[95].OptionFlag).ToString();

                    //------------------------------------
                    //--------Peripherals-----------------------

                    Cmb_COMPort.Text = System.Configuration.ConfigurationManager.AppSettings["COMPort"].ToString();


                    if (lstOptions[96].OptionFlag.ToString() == "Y")
                    {
                        chkUseCustomerDisplay.Checked = true;
                    }
                    else
                    {
                        chkUseCustomerDisplay.Checked = false;
                    }
                    Txt_FirstLineWelcomeNote.Text = lstOptions[97].OptionFlag.ToString();
                    Txt_SecondLineWelcomeNote.Text = lstOptions[98].OptionFlag.ToString();
                    if (lstOptions[99].OptionFlag.ToString() == "Y")
                    {
                        chkUseCashDrawer.Checked = true;
                    }
                    else
                    {
                        chkUseCashDrawer.Checked = false;
                    }
                    if (lstOptions[100].OptionFlag.ToString() == "Y")
                    {
                        rbnDrawerTypeUSP.Checked = true;
                    }
                    else
                    {
                        rbnDrawerTypeUSP.Checked = false;
                    }
                    if (lstOptions[101].OptionFlag.ToString() == "Y")
                    {
                        rbnDrawerTypeCOM.Checked = true;
                    }
                    else
                    {
                        rbnDrawerTypeCOM.Checked = false;
                    }
                    if (lstOptions[102].OptionFlag.ToString() == "Y")
                    {
                        rbnDrawerTypeRJ11.Checked = true;
                    }
                    else
                    {
                        rbnDrawerTypeRJ11.Checked = false;
                    }
                    if (lstOptions[103].OptionFlag.ToString() == "Y")
                    {
                        chkDrawerOpenDirectlyAfterPrint.Checked = true;
                    }
                    else
                    {
                        chkDrawerOpenDirectlyAfterPrint.Checked = false;
                    }
                    if (lstOptions[104].OptionFlag.ToString() == "Y")
                    {
                        chkDrawerProtectWithPassword.Checked = true;
                    }
                    else
                    {
                        chkDrawerProtectWithPassword.Checked = false;
                    }
                    if (lstOptions[199].OptionFlag.ToString() == "Y")
                    {
                        chkPriceCheckerActive.Checked = true;
                    }
                    else
                    {
                        chkPriceCheckerActive.Checked = false;
                    }
                    Txt_CashDrawerPassword.Text = lstOptions[105].OptionFlag.ToString();
                    Txt_CashDrawerVerifyPassword.Text = lstOptions[106].OptionFlag.ToString();

                    //------------------------------------
                    //--------Tax-----------------------

                    Txt_Tax1_TaxName.Text = lstOptions[107].OptionFlag.ToString();

                    if (lstOptions[108].OptionFlag.ToString() != "")
                    {
                        UD_Tax1_Percentage.Value = Convert.ToDecimal(lstOptions[108].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_Tax1_Percentage.Value = 0;
                    }
                    if (lstOptions[109].OptionFlag.ToString() != "")
                    {
                        UD_Tax1_SubPercentage.Value = Convert.ToDecimal(lstOptions[109].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_Tax1_SubPercentage.Value = 0;
                    }

                    Cmb_Tax1_ShowTaxInvoice.SelectedIndex = int.Parse(lstOptions[110].OptionFlag.ToString());

                    if (lstOptions[111].OptionFlag.ToString() == "Y")
                    {
                        chkTax1_ApplySales.Checked = true;
                    }
                    else
                    {
                        chkTax1_ApplySales.Checked = false;
                    }
                    if (lstOptions[112].OptionFlag.ToString() == "Y")
                    {
                        chkTax1_ApplyPurchase.Checked = true;
                    }
                    else
                    {
                        chkTax1_ApplyPurchase.Checked = false;
                    }
                    if (lstOptions[113].OptionFlag.ToString() == "Y")
                    {
                        chkTax1_ApplyMaintains.Checked = true;
                    }
                    else
                    {
                        chkTax1_ApplyMaintains.Checked = false;
                    }
                    if (lstOptions[114].OptionFlag.ToString() == "Y")
                    {
                        chkTax1_ApplyBeforeDiscount.Checked = true;
                    }
                    else
                    {
                        chkTax1_ApplyBeforeDiscount.Checked = false;
                    }

                    Txt_Tax2_TaxName.Text = lstOptions[115].OptionFlag.ToString();

                    if (lstOptions[116].OptionFlag.ToString() != "")
                    {
                        UD_Tax2_Percentage.Value = Convert.ToDecimal(lstOptions[116].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_Tax2_Percentage.Value = 0;
                    }
                    if (lstOptions[117].OptionFlag.ToString() != "")
                    {
                        UD_Tax2_SubPercentage.Value = Convert.ToDecimal(lstOptions[117].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_Tax2_SubPercentage.Value = 0;
                    }

                    Cmb_Tax2_ShowTaxInvoice.SelectedIndex = int.Parse(lstOptions[118].OptionFlag.ToString());

                    if (lstOptions[119].OptionFlag.ToString() == "Y")
                    {
                        chkTax2_ApplySales.Checked = true;
                    }
                    else
                    {
                        chkTax2_ApplySales.Checked = false;
                    }
                    if (lstOptions[120].OptionFlag.ToString() == "Y")
                    {
                        chkTax2_ApplyPurchase.Checked = true;
                    }
                    else
                    {
                        chkTax2_ApplyPurchase.Checked = false;
                    }
                    if (lstOptions[121].OptionFlag.ToString() == "Y")
                    {
                        chkTax2_ApplyMaintains.Checked = true;
                    }
                    else
                    {
                        chkTax2_ApplyMaintains.Checked = false;
                    }
                    if (lstOptions[122].OptionFlag.ToString() == "Y")
                    {
                        chkTax2_ApplyBeforeDiscount.Checked = true;
                    }
                    else
                    {
                        chkTax2_ApplyBeforeDiscount.Checked = false;
                    }

                    //------------------------------------
                    //--------Notification-----------------------

                    if (lstOptions[123].OptionFlag.ToString() == "Y")
                    {
                        Chk_Licenserenewal.Checked = true;

                    }
                    else
                    {
                        Chk_Licenserenewal.Checked = false;
                    }
                    if (lstOptions[124].OptionDateNotify.ToString() != "")
                    {
                        //string fDate = DateFormate(dtOption.Rows[124][2].ToString());
                        ////DTP_LicenserenewalDate.Value = Convert.ToDateTime(fDate);
                        DTP_LicenserenewalDate.Value = Convert.ToDateTime(lstOptions[124].OptionDateNotify);
                        // DateTime dt=DateTime.Now;
                        //if(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.StartsWith("MM") )
                        // DateTime.ParseExact(dtOption.Rows[124][2].ToString(),,null);
                        // DTP_LicenserenewalDate.Value = dt;
                    }

                    if (lstOptions[125].OptionFlag.ToString() != "")
                    {
                        UD_LicenserenewalNotifyBefore.Value = Convert.ToDecimal(lstOptions[125].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_LicenserenewalNotifyBefore.Value = 0;
                    }

                    if (lstOptions[126].OptionFlag.ToString() == "Y")
                    {
                        Chk_MedicalInsurance.Checked = true;
                    }
                    else
                    {
                        Chk_MedicalInsurance.Checked = false;
                    }
                    if (lstOptions[127].OptionDateNotify.ToString() != "")
                    {
                        //string fDate = DateFormate(dtOption.Rows[127][2].ToString());
                        //DTP_MedicalInsuranceDate.Value = Convert.ToDateTime(fDate);
                        DTP_MedicalInsuranceDate.Value = Convert.ToDateTime(lstOptions[127].OptionDateNotify);
                    }

                    if (lstOptions[128].OptionFlag.ToString() != "")
                    {
                        UD_MedicalInsuranceNotifyBefore.Value = Convert.ToDecimal(lstOptions[128].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_MedicalInsuranceNotifyBefore.Value = 0;
                    }

                    if (lstOptions[129].OptionFlag.ToString() == "Y")
                    {
                        Chk_CertificateofHealth.Checked = true;
                    }
                    else
                    {
                        Chk_CertificateofHealth.Checked = false;
                    }
                    if (lstOptions[130].OptionDateNotify.ToString() != "")
                    {
                        DTP_CertificateofHealthDate.Value = Convert.ToDateTime(lstOptions[130].OptionDateNotify);
                    }

                    if (lstOptions[131].OptionFlag.ToString() != "")
                    {
                        UD_CertificateofHealthNotifyBefore.Value = Convert.ToDecimal(lstOptions[131].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_CertificateofHealthNotifyBefore.Value = 0;
                    }

                    if (lstOptions[132].OptionFlag.ToString() == "Y")
                    {
                        Chk_AttendancePermit.Checked = true;
                    }
                    else
                    {
                        Chk_AttendancePermit.Checked = false;
                    }
                    if (lstOptions[133].OptionDateNotify.ToString() != "")
                    {

                        DTP_AttendancePermitDate.Value = Convert.ToDateTime(lstOptions[133].OptionDateNotify);
                    }

                    if (lstOptions[134].OptionFlag.ToString() != "")
                    {
                        UD_AttendancePermitNotifyBefore.Value = Convert.ToDecimal(lstOptions[134].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AttendancePermitNotifyBefore.Value = 0;
                    }

                    if (lstOptions[135].OptionFlag.ToString().Contains("Y/"))
                    {
                        Chk_TechnicalDisclosure.Checked = true;
                        //Txt_TextBox1.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[135].OptionFlag.ToString().Remove(0, 2).Trim()); Removed for avoid Multilangauge..Need to do this code
                        Txt_TextBox1.Text = lstOptions[135].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    else
                    {
                        Chk_TechnicalDisclosure.Checked = false;
                        //Txt_TextBox1.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[135].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox1.Text = lstOptions[135].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    if (lstOptions[136].OptionDateNotify.ToString() != "")
                    {

                        DTP_TechnicalDisclosureDate.Value = Convert.ToDateTime(lstOptions[136].OptionDateNotify);
                    }

                    if (lstOptions[137].OptionFlag.ToString() != "")
                    {
                        UD_TechnicalDisclosureNotifyBefore.Value = Convert.ToDecimal(lstOptions[137].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_TechnicalDisclosureNotifyBefore.Value = 0;
                    }

                    if (lstOptions[138].OptionFlag.ToString().Contains("Y/"))
                    {
                        Chk_Pricing.Checked = true;
                        //Txt_TextBox2.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[138].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox2.Text = lstOptions[138].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    else
                    {
                        Chk_Pricing.Checked = false;
                        //Txt_TextBox2.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[138].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox2.Text = lstOptions[138].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    if (lstOptions[139].OptionDateNotify.ToString() != "")
                    {

                        DTP_PricingDate.Value = Convert.ToDateTime(lstOptions[139].OptionDateNotify);
                    }

                    if (lstOptions[140].OptionFlag.ToString() != "")
                    {
                        UD_PricingNotifyBefore.Value = Convert.ToDecimal(lstOptions[140].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_PricingNotifyBefore.Value = 0;
                    }

                    if (lstOptions[141].OptionFlag.ToString().Contains("Y/"))
                    {
                        Chk_Payrent.Checked = true;
                        //Txt_TextBox3.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[141].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox3.Text = lstOptions[141].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    else
                    {
                        Chk_Payrent.Checked = false;
                        //Txt_TextBox3.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[141].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox3.Text = lstOptions[141].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    if (lstOptions[142].OptionDateNotify.ToString() != "")
                    {

                        DTP_PayrentDate.Value = Convert.ToDateTime(lstOptions[142].OptionDateNotify);
                    }

                    if (lstOptions[143].OptionFlag.ToString() != "")
                    {
                        UD_PayrentNotifyBefore.Value = Convert.ToDecimal(lstOptions[143].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_PayrentNotifyBefore.Value = 0;
                    }

                    if (lstOptions[144].OptionFlag.ToString().Contains("Y/"))
                    {
                        Chk_DisbursementSalary.Checked = true;
                        //Txt_TextBox4.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[144].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox4.Text = lstOptions[144].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    else
                    {
                        Chk_DisbursementSalary.Checked = false;
                        //Txt_TextBox4.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[144].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox4.Text = lstOptions[144].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    if (lstOptions[145].OptionDateNotify.ToString() != "")
                    {

                        DTP_DisbursementSalaryDate.Value = Convert.ToDateTime(lstOptions[145].OptionDateNotify);
                    }

                    if (lstOptions[146].OptionFlag.ToString() != "")
                    {
                        UD_DisbursementSalaryNotifyBefore.Value = Convert.ToDecimal(lstOptions[146].OptionFlag);
                    }
                    else
                    {
                        UD_DisbursementSalaryNotifyBefore.Value = 0;
                    }

                    if (lstOptions[147].OptionFlag.ToString().Contains("Y/"))
                    {
                        Chk_AnnualInventory.Checked = true;
                        //Txt_TextBox5.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[147].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox5.Text = lstOptions[147].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    else
                    {
                        Chk_AnnualInventory.Checked = false;
                        //Txt_TextBox5.Text = GeneralFunction.ChangeLanguageforCustomMsg(lstOptions[147].OptionFlag.ToString().Remove(0, 2).Trim());
                        Txt_TextBox5.Text = lstOptions[147].OptionFlag.ToString().Remove(0, 2).Trim();
                    }
                    if (lstOptions[148].OptionDateNotify.ToString() != "")
                    {
                        //string fDate = DateFormate(dtOption.Rows[133][2].ToString());
                        //DTP_AnnualInventoryDate.Value = Convert.ToDateTime(fDate);
                        DTP_AnnualInventoryDate.Value = Convert.ToDateTime(lstOptions[148].OptionDateNotify);
                    }

                    if (lstOptions[149].OptionFlag.ToString() != "")
                    {
                        UD_AnnualInventoryNotifyBefore.Value = Convert.ToDecimal(lstOptions[149].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AnnualInventoryNotifyBefore.Value = 0;
                    }

                    if (lstOptions[150].OptionFlag.ToString() == "Y")
                    {
                        Chk_Zakat.Checked = true;
                    }
                    else
                    {
                        Chk_Zakat.Checked = false;
                    }
                    if (lstOptions[151].OptionDateNotify.ToString() != "")
                    {
                        //string fDate = DateFormate(dtOption.Rows[133][2].ToString());
                        //DTP_ZakatDate.Value = Convert.ToDateTime(fDate);
                        DTP_ZakatDate.Value = Convert.ToDateTime(lstOptions[151].OptionDateNotify);
                    }

                    if (lstOptions[152].OptionFlag.ToString() != "")
                    {
                        UD_ZakatNotifyBefore.Value = Convert.ToDecimal(lstOptions[152].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_ZakatNotifyBefore.Value = 0;
                    }

                    //------------------------------------
                    //--------Others-----------------------

                    if (lstOptions[153].OptionFlag.ToString() == "Y")
                    {
                        chkDontAskClosingSystem.Checked = true;
                    }
                    else
                    {
                        chkDontAskClosingSystem.Checked = false;
                    }
                    if (lstOptions[154].OptionFlag.ToString() == "Y")
                    {
                        chk24HourWorkSystem.Checked = true;
                    }
                    else
                    {
                        chk24HourWorkSystem.Checked = false;
                    }
                    if (lstOptions[155].OptionFlag.ToString() == "Y")
                    {
                        chkStopDeptSellings.Checked = true;
                    }
                    else
                    {
                        chkStopDeptSellings.Checked = false;
                    }
                    if (lstOptions[156].OptionFlag.ToString() == "Y")
                    {
                        chkHidePackageReport.Checked = true;
                    }
                    else
                    {
                        chkHidePackageReport.Checked = false;
                    }
                    if (lstOptions[157].OptionFlag.ToString() == "Y")
                    {
                        chkShowTipDayWhenStart.Checked = true;
                    }
                    else
                    {
                        chkShowTipDayWhenStart.Checked = false;
                    }
                    if (lstOptions[158].OptionFlag.ToString() == "Y")
                    {
                        chkBranchBuyswithCost.Checked = true;
                    }
                    else
                    {
                        chkBranchBuyswithCost.Checked = false;
                    }
                    if (lstOptions[159].OptionFlag.ToString() == "Y")
                    {
                        chkUseItemPhoto.Checked = true;
                    }
                    else
                    {
                        chkUseItemPhoto.Checked = false;
                    }
                    //if (dtOption.Rows[160][2].ToString() == "Y")
                    //{
                    //    chkUseRentingInvoice.Checked = true;
                    //}
                    //else
                    //{
                    //    chkUseRentingInvoice.Checked = false;
                    //}
                    if (lstOptions[161].OptionFlag.ToString() == "Y")
                    {
                        chkDontAlertOnSave.Checked = true;
                    }
                    else
                    {
                        chkDontAlertOnSave.Checked = false;
                    }
                    if (lstOptions[162].OptionFlag.ToString() == "Y")
                    {
                        chkDontAlertDeleteItemFromInvoice.Checked = true;
                    }
                    else
                    {
                        chkDontAlertDeleteItemFromInvoice.Checked = false;
                    }
                    if (lstOptions[163].OptionFlag.ToString() == "Y")
                    {
                        chkUnifyOptionForallWorkStations.Checked = true;
                    }
                    else
                    {
                        chkUnifyOptionForallWorkStations.Checked = false;
                    }
                    if (lstOptions[164].OptionFlag.ToString() == "Y")
                    {
                        Chk_RoundPriceOnDiscount.Checked = true;
                    }
                    else
                    {
                        Chk_RoundPriceOnDiscount.Checked = false;
                    }

                    Cmb_RoundPricesOnDiscountValue.SelectedIndex = int.Parse(lstOptions[165].OptionFlag.ToString());

                    if (lstOptions[166].OptionFlag.ToString() != "")
                    {
                        UD_AlertReorderItemsPerDay.Value = Convert.ToDecimal(lstOptions[166].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AlertReorderItemsPerDay.Value = 0;
                    }
                    if (lstOptions[167].OptionFlag.ToString() != "")
                    {
                        UD_AlertExpiryPerDay.Value = Convert.ToDecimal(lstOptions[167].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AlertExpiryPerDay.Value = 0;
                    }
                    if (lstOptions[168].OptionFlag.ToString() != "")
                    {
                        UD_AlertPayDatesBefore.Value = Convert.ToDecimal(lstOptions[168].OptionFlag.ToString());
                    }
                    else
                    {
                        UD_AlertPayDatesBefore.Value = 0;
                    }

                    if (lstOptions[169].OptionFlag.ToString() == "Y")
                    {
                        chkAlertPayDates.Checked = true;
                    }
                    else
                    {
                        chkAlertPayDates.Checked = false;
                    }
                    if (lstOptions[170].OptionFlag.ToString() == "Y")
                    {
                        chkAlertWithSound.Checked = true;
                    }
                    else
                    {
                        chkAlertWithSound.Checked = false;
                    }
                    if (lstOptions[171].OptionFlag.ToString() == "Y")
                    {
                        chkAlertSaleInvoice.Checked = true;
                    }
                    else
                    {
                        chkAlertSaleInvoice.Checked = false;
                    }

                    chkHidePOSShortcut.Checked = (lstOptions[172].OptionFlag.ToString() == "Y");
                    chkHidePOSScreen.Checked = (lstOptions[173].OptionFlag.ToString() == "Y");
                    chkResetPOSOrder.Checked = (lstOptions[181].OptionFlag == "Y");
                    txtResetPOSOrderCount.Text = lstOptions[182].OptionFlag.ToString();
                    //------------------------------------
                    //}
                    //    catch{
                    //    }
                    // Added on 13-Mar-2019 By T
                    if (lstOptions[188].OptionFlag.ToString() == "Y")
                    {
                        chkEnableNetworkSaleControl.Checked = true;
                    }
                    else
                    {
                        chkEnableNetworkSaleControl.Checked = false;
                    }
                    if (lstOptions[190].OptionFlag.ToString() == "Y")
                    {
                        chkConfirmEndShift.Checked = true;
                    }
                    else
                    {
                        chkConfirmEndShift.Checked = false;
                    }
                    // Added on 22-July-2019 By T
                    if (lstOptions[197].OptionFlag.ToString() == "Y")
                    {
                        ChkOpenNewInvoice.Checked = true;
                    }
                    else
                    {
                        ChkOpenNewInvoice.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstOptions = null;
                lstLogo = null;
            }
            #endregion
        }
        #endregion

        #region Validation_ForNotifications
        private Boolean Validation_ForNotifications()
        {


            isvalidation = false;
            if (Chk_TechnicalDisclosure.Checked == true)
            {
                if (Txt_TextBox1.Text.Trim() == "")
                { GeneralFunction.Information(("EmptyValue"), "OptionSetting".ToString()); Txt_TextBox1.Focus(); return false; }
            }

            if (Chk_Pricing.Checked == true)
            {
                if (Txt_TextBox2.Text.Trim() == "")
                { GeneralFunction.Information(("EmptyValue"), "OptionSetting".ToString()); Txt_TextBox2.Focus(); return false; }
            }
            if (Chk_Payrent.Checked == true)
            {
                if (Txt_TextBox3.Text.Trim() == "")
                { GeneralFunction.Information(("EmptyValue"), "OptionSetting".ToString()); Txt_TextBox3.Focus(); return false; }
            }
            if (Chk_DisbursementSalary.Checked == true)
            {
                if (Txt_TextBox4.Text.Trim() == "")
                { GeneralFunction.Information(("EmptyValue"), "OptionSetting".ToString()); Txt_TextBox4.Focus(); return false; }
            }
            if (Chk_AnnualInventory.Checked == true)
            {
                if (Txt_TextBox5.Text.Trim() == "")
                { GeneralFunction.Information(("EmptyValue"), "OptionSetting".ToString()); Txt_TextBox5.Focus(); return false; }
            }
            isvalidation = true;
            return true;


        }
        #endregion

        #region Save All Tabs

        #region SaveOption_General
        public void SaveOption_General()
        {
            if (GeneralFunction.Language != Cmb_Langage.Text)
            {
                if (GeneralFunction.Question("You have to restart the application to change the Language", "OptionSetting".ToString()) == DialogResult.Yes)
                {
                    GeneralFunction.SetConfigValue("Language", Cmb_Langage.Text);
                    GeneralFunction.Language = ConfigurationSettings.AppSettings["Language"].ToString();
                    isRestart = true;
                }
                else
                {
                    Cmb_Langage.Text = GeneralFunction.Language;
                    isRestart = false;
                }
            }
            objOption.OptionCompanyName = Txt_Companyname.Name;
            objOption.OptionPhone = Txt_Phone.Name;
            objOption.OptionCell = Txt_Cell.Name;
            objOption.OptionFax = Txt_Fax.Name;
            objOption.OptionPOBox = Txt_POBox.Name;
            objOption.OptionEmail = Txt_Email.Name;
            objOption.OptionAddress = Txt_Address.Name;
            objOption.OptionSystemNote = Txt_SystemNote.Name;
            objOption.OptionWorkNote = Txt_WorkNote.Name;
            objOption.OptionLangage = Cmb_Langage.Name;
            objOption.OptionHideDiscountWindow = Chk_HideDiscountWindow.Name;
            objOption.OptionHideWelcomeWindow = Chk_HideWelcomeWindow.Name;
            objOption.OptionHideNoteFiled = Chk_HideNoteFiled.Name;
            objOption.OptionShowCompanyOnInvoice = Chk_ShowCompanyOnInvoice.Name;
            objOption.OptionShowCompanyNameOnly = Chk_ShowCompanyNameOnly.Name;
            objOption.OptionAutoStartwithWindow = Chk_AutoStartwithWindow.Name;
            // objOption.OptionDateFormat = cmbDateFormat.Name;//Added on 28-May-2014

            objOption.FlagCompanyName = Txt_Companyname.Text;
            objOption.FlagPhone = Txt_Phone.Text;
            objOption.FlagCell = Txt_Cell.Text;
            objOption.FlagFax = Txt_Fax.Text;
            objOption.FlagPOBox = Txt_POBox.Text;
            objOption.FlagEmail = Txt_Email.Text;
            objOption.FlagAddress = Txt_Address.Text;
            objOption.FlagSystemNote = Txt_SystemNote.Text;
            objOption.FlagWorkNote = Txt_WorkNote.Text;
            if (Cmb_Langage.SelectedIndex >= 0)
            {
                objOption.FlagLangage = Cmb_Langage.SelectedItem.ToString();
            }
            else
            {
                objOption.FlagLangage = "Arabic";
            }

            if (Chk_HideDiscountWindow.Checked == true)
            {
                objOption.FlagHideDiscountWindow = "Y";
            }
            else
            {
                objOption.FlagHideDiscountWindow = "N";
            }
            if (Chk_HideWelcomeWindow.Checked == true)
            {
                objOption.FlagHideWelcomeWindow = "Y";
            }
            else
            {
                objOption.FlagHideWelcomeWindow = "N";
            }
            if (Chk_HideNoteFiled.Checked == true)
            {
                objOption.FlagHideNoteFiled = "Y";
            }
            else
            {
                objOption.FlagHideNoteFiled = "N";
            }

            if (Chk_ShowCompanyOnInvoice.Checked == true)
            {
                objOption.FlagShowCompanyOnInvoice = "Y";
            }
            else
            {
                objOption.FlagShowCompanyOnInvoice = "N";
            }

            if (Chk_ShowCompanyNameOnly.Checked == true)
            {
                objOption.FlagShowCompanyNameOnly = "Y";
            }
            else
            {
                objOption.FlagShowCompanyNameOnly = "N";
            }
            if (Chk_AutoStartwithWindow.Checked == true)
            {
                objOption.FlagAutoStartwithWindow = "Y";
            }
            else
            {
                objOption.FlagAutoStartwithWindow = "N";
            }


            strValue = "";
            strValue = objOption.OptionCompanyName + "|" + objOption.FlagCompanyName + "~" + objOption.OptionPhone + "|" + objOption.FlagPhone;
            strValue = strValue + "~" + objOption.OptionCell + "|" + objOption.FlagCell + "~" + objOption.OptionFax + "|" + objOption.FlagFax;
            strValue = strValue + "~" + objOption.OptionPOBox + "|" + objOption.FlagPOBox + "~" + objOption.OptionEmail + "|" + objOption.FlagEmail;
            strValue = strValue + "~" + objOption.OptionAddress + "|" + objOption.FlagAddress + "~" + objOption.OptionSystemNote + "|" + objOption.FlagSystemNote;
            strValue = strValue + "~" + objOption.OptionWorkNote + "|" + objOption.FlagWorkNote + "~" + objOption.OptionLangage + "|" + objOption.FlagLangage;
            strValue = strValue + "~" + objOption.OptionHideDiscountWindow + "|" + objOption.FlagHideDiscountWindow + "~" + objOption.OptionHideWelcomeWindow + "|" + objOption.FlagHideWelcomeWindow;
            strValue = strValue + "~" + objOption.OptionHideNoteFiled + "|" + objOption.FlagHideNoteFiled;
            strValue = strValue + "~" + objOption.OptionShowCompanyOnInvoice + "|" + objOption.FlagShowCompanyOnInvoice;
            strValue = strValue + "~" + objOption.OptionShowCompanyNameOnly + "|" + objOption.FlagShowCompanyNameOnly + "~" + objOption.OptionAutoStartwithWindow + "|" + objOption.FlagAutoStartwithWindow + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            if (Chk_AutoStartwithWindow.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("MyApp", Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("MyApp", false);
                //MessageBox.Show(rkApp.GetValue("MyApp").ToString());
            }
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan

        }
        #endregion

        #region SaveOption_Invoice
        public void SaveOption_Invoice()
        {

            objOption.OptiontxtPercentageCheck = paymentTypeChargesNameCheck;
            objOption.OptiontxtPercentageCard = paymentTypeChargesNameCard;
            objOption.OptionchkActivatePaymentType = chkActivatePaymentType.Name;
            objOption.OptionPurchase_HideExpiryFiled = Chk_Purchase_HideExpiryFiled.Name;
            objOption.OptionPurchase_HideDevidingDiscountOnItem = chkPurchase_HideDevidingDiscountOnItem.Name;
            objOption.OptionPurchase_AddItemDirectlywithBarcode = chkPurchase_AddItemDirectlywithBarcode.Name;
            objOption.OptionTabToPrice = Chk_TabToPrice.Name;
            objOption.OptionShowDiscountFiled = chkShowDiscountFiled.Name;
            objOption.OptionShowHidenItem = chkShowHidenItem.Name;
            objOption.OptionPurchase_SaveUsernameOnInvoice = chkPurchase_SaveUsernameOnInvoice.Name;
            objOption.OptionHidePriceChangingButton = chkHidePriceChangingButton.Name;
            objOption.OptionSalePriceReadonly = chkSalePriceReadonly.Name;
            objOption.OptionSale_AddItemDirectlywithBarcode = Chk_Sale_AddItemDirectlywithBarcode.Name;
            objOption.OptionOpenInvioceAfterClosing = chkOpenInvioceAfterClosing.Name;
            objOption.OptionSale_HideExpiryFiled = chkSale_HideExpiryFiled.Name;
            objOption.OptionDevideDiscountBeforeClosingInvoice = chkDevideDiscountBeforeClosingInvoice.Name;
            objOption.OptionAlterwhenSellingLessthanCost = chkAlterwhenSellingLessthanCost.Name;
            objOption.OptionShowSubTotalFiled = chkShowSubTotalFiled.Name;
            objOption.OptionShowNonStockItem = chkShowNonStockItem.Name;
            objOption.OptionSale_SaveUsernameOnInvoice = chkSale_SaveUsernameOnInvoice.Name;
            objOption.OptionShowInvoiceCostFiled = chkShowInvoiceCostFiled.Name;
            objOption.OptionDisableDiscountFiled = chkDisableDiscountFiled.Name;
            objOption.OptionSale_HideDevidingDiscountOnItem = chkSale_HideDevidingDiscountOnItem.Name;
            objOption.OptionSale_InsertItemIndividually = chkInsertItemIndividually.Name;
            objOption.OptionPurchase_HideImportExport = chkHideExportImport.Name;

            objOption.FlagtxtPercentageCheck = paymentTypeChargesValueCheck;
            objOption.FlagtxtPercentageCard = paymentTypeChargesValueCard;


            if (chkActivatePaymentType.Checked == true)
            {
                objOption.FlagchkActivatePaymentType = "Y";
            }
            else
            {
                objOption.FlagchkActivatePaymentType = "N";
            }
            if (chkPurchase_HideDevidingDiscountOnItem.Checked == true)
            {
                objOption.FlagPurchase_HideDevidingDiscountOnItem = "Y";
            }
            else
            {
                objOption.FlagPurchase_HideDevidingDiscountOnItem = "N";
            }
            if (chkPurchase_AddItemDirectlywithBarcode.Checked == true)
            {
                objOption.FlagPurchase_AddItemDirectlywithBarcode = "Y";
            }
            else
            {
                objOption.FlagPurchase_AddItemDirectlywithBarcode = "N";
            }
            if (Chk_TabToPrice.Checked == true)
            {
                objOption.FlagTabToPrice = "Y";
            }
            else
            {
                objOption.FlagTabToPrice = "N";
            }
            if (chkShowDiscountFiled.Checked == true)
            {
                objOption.FlagShowDiscountFiled = "Y";
            }
            else
            {
                objOption.FlagShowDiscountFiled = "N";
            }
            if (chkShowHidenItem.Checked == true)
            {
                objOption.FlagShowHidenItem = "Y";
            }
            else
            {
                objOption.FlagShowHidenItem = "N";
            }
            if (chkPurchase_SaveUsernameOnInvoice.Checked == true)
            {
                objOption.FlagPurchase_SaveUsernameOnInvoice = "Y";
            }
            else
            {
                objOption.FlagPurchase_SaveUsernameOnInvoice = "N";
            }
            if (chkHidePriceChangingButton.Checked == true)
            {
                objOption.FlagHidePriceChangingButton = "Y";
            }
            else
            {
                objOption.FlagHidePriceChangingButton = "N";
            }
            if (chkSalePriceReadonly.Checked == true)
            {
                objOption.FlagSalePriceReadonly = "Y";
            }
            else
            {
                objOption.FlagSalePriceReadonly = "N";
            }
            if (Chk_Sale_AddItemDirectlywithBarcode.Checked == true)
            {
                objOption.FlagSale_AddItemDirectlywithBarcode = "Y";
            }
            else
            {
                objOption.FlagSale_AddItemDirectlywithBarcode = "N";
            }
            if (chkOpenInvioceAfterClosing.Checked == true)
            {
                objOption.FlagOpenInvioceAfterClosing = "Y";
            }
            else
            {
                objOption.FlagOpenInvioceAfterClosing = "N";
            }
            if (chkSale_HideExpiryFiled.Checked == true)
            {
                objOption.FlagSale_HideExpiryFiled = "Y";
            }
            else
            {
                objOption.FlagSale_HideExpiryFiled = "N";
            }
            if (chkDevideDiscountBeforeClosingInvoice.Checked == true)
            {
                objOption.FlagDevideDiscountBeforeClosingInvoice = "Y";
            }
            else
            {
                objOption.FlagDevideDiscountBeforeClosingInvoice = "N";
            }
            if (chkAlterwhenSellingLessthanCost.Checked == true)
            {
                objOption.FlagAlterwhenSellingLessthanCost = "Y";
            }
            else
            {
                objOption.FlagAlterwhenSellingLessthanCost = "N";
            }
            if (chkShowSubTotalFiled.Checked == true)
            {
                objOption.FlagShowSubTotalFiled = "Y";
            }
            else
            {
                objOption.FlagShowSubTotalFiled = "N";
            }
            if (chkShowNonStockItem.Checked == true)
            {
                objOption.FlagShowNonStockItem = "Y";
            }
            else
            {
                objOption.FlagShowNonStockItem = "N";
            }
            if (chkSale_SaveUsernameOnInvoice.Checked == true)
            {
                objOption.FlagSale_SaveUsernameOnInvoice = "Y";
            }
            else
            {
                objOption.FlagSale_SaveUsernameOnInvoice = "N";
            }
            if (chkShowInvoiceCostFiled.Checked == true)
            {
                objOption.FlagShowInvoiceCostFiled = "Y";
            }
            else
            {
                objOption.FlagShowInvoiceCostFiled = "N";
            }
            if (chkDisableDiscountFiled.Checked == true)
            {
                objOption.FlagDisableDiscountFiled = "Y";
            }
            else
            {
                objOption.FlagDisableDiscountFiled = "N";
            }
            if (chkSale_HideDevidingDiscountOnItem.Checked == true)
            {
                objOption.FlagSale_HideDevidingDiscountOnItem = "Y";
            }
            else
            {
                objOption.FlagSale_HideDevidingDiscountOnItem = "N";
            }

            if (chkInsertItemIndividually.Checked == true)
            {
                objOption.FlagSale_InsertItemIndividually = "Y";
            }
            else
            {
                objOption.FlagSale_InsertItemIndividually = "N";
            }
            if (chkHideExportImport.Checked == true)
            {
                objOption.FlagPurchase_HideImportExport = "Y";
            }
            else
            {
                objOption.FlagPurchase_HideImportExport = "N";
            }
            if (chkSaleDontUseExpiry.Checked == true)
            {
                objOption.FlagSale_DontUseExpiry = "Y";
            }
            else
            {
                objOption.FlagSale_DontUseExpiry = "N";
            }
            if (chkPurchaseDontUseExpiry.Checked == true)
            {
                objOption.FlagPurchase_DontUseExpiry = "Y";
            }
            else
            {
                objOption.FlagPurchase_DontUseExpiry = "N";
            }
            strValue = "";

            strValue = objOption.OptiontxtPercentageCard + "|" + objOption.FlagtxtPercentageCard + "~" + objOption.OptiontxtPercentageCheck + "|" + objOption.FlagtxtPercentageCheck + "~" + objOption.OptionchkActivatePaymentType + "|" + objOption.FlagchkActivatePaymentType + "~" + objOption.OptionPurchase_HideExpiryFiled + "|" + objOption.FlagPurchase_HideExpiryFiled + "~" + objOption.OptionPurchase_HideDevidingDiscountOnItem + "|" + objOption.FlagPurchase_HideDevidingDiscountOnItem;
            strValue = strValue + "~" + objOption.OptionPurchase_AddItemDirectlywithBarcode + "|" + objOption.FlagPurchase_AddItemDirectlywithBarcode + "~" + objOption.OptionTabToPrice + "|" + objOption.FlagTabToPrice;
            strValue = strValue + "~" + objOption.OptionShowDiscountFiled + "|" + objOption.FlagShowDiscountFiled + "~" + objOption.OptionShowHidenItem + "|" + objOption.FlagShowHidenItem;
            strValue = strValue + "~" + objOption.OptionPurchase_SaveUsernameOnInvoice + "|" + objOption.FlagPurchase_SaveUsernameOnInvoice + "~" + objOption.OptionHidePriceChangingButton + "|" + objOption.FlagHidePriceChangingButton;
            strValue = strValue + "~" + objOption.OptionSalePriceReadonly + "|" + objOption.FlagSalePriceReadonly + "~" + objOption.OptionSale_AddItemDirectlywithBarcode + "|" + objOption.FlagSale_AddItemDirectlywithBarcode;
            strValue = strValue + "~" + objOption.OptionOpenInvioceAfterClosing + "|" + objOption.FlagOpenInvioceAfterClosing + "~" + objOption.OptionSale_HideExpiryFiled + "|" + objOption.FlagSale_HideExpiryFiled;
            strValue = strValue + "~" + objOption.OptionDevideDiscountBeforeClosingInvoice + "|" + objOption.FlagDevideDiscountBeforeClosingInvoice + "~" + objOption.OptionAlterwhenSellingLessthanCost + "|" + objOption.FlagAlterwhenSellingLessthanCost;
            strValue = strValue + "~" + objOption.OptionShowSubTotalFiled + "|" + objOption.FlagShowSubTotalFiled + "~" + objOption.OptionShowNonStockItem + "|" + objOption.FlagShowNonStockItem;
            strValue = strValue + "~" + objOption.OptionSale_SaveUsernameOnInvoice + "|" + objOption.FlagSale_SaveUsernameOnInvoice + "~" + objOption.OptionShowInvoiceCostFiled + "|" + objOption.FlagShowInvoiceCostFiled;
            strValue = strValue + "~" + objOption.OptionDisableDiscountFiled + "|" + objOption.FlagDisableDiscountFiled + "~" + objOption.OptionSale_HideDevidingDiscountOnItem + "|" + objOption.FlagSale_HideDevidingDiscountOnItem + "~" + objOption.OptionSale_InsertItemIndividually + "|" + objOption.FlagSale_InsertItemIndividually + "~";
            strValue = strValue + objOption.OptionPurchase_HideImportExport + "|" + objOption.FlagPurchase_HideImportExport + "~";
            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }
        #endregion

        #region SaveOption_Print
        public void SaveOption_Print()
        {
            objOption.OptionInvoiceTemplate = Cmb_InvoiceTemplate.Name;
            objOption.OptionBarcodePaperSize = Cmb_BarcodePaperSize.Name;
            objOption.OptionBarcodePrinter = Cmb_BarcodePrinter.Name;
            objOption.OptionPrintingLogo = Cmb_PrintingLogo.Name;
            objOption.OptionBarcodeSize = txtBarcodeSize.Name;
            objOption.OptionItemSorting = Cmb_ItemSorting.Name;
            objOption.OptionInvoiceCopies = UD_InvoiceCopies.Name;
            objOption.OptionReciptCopies = UD_ReciptCopies.Name;
            objOption.OptionHeader = UD_Header.Name;
            objOption.OptionFooter = UD_Footer.Name;
            objOption.OptionLogoHeader = Txt_LogoHeader.Name;
            objOption.OptionLogoFooter = Txt_LogoFooter.Name;
            objOption.OptionNoteSaleInvoice = Txt_NoteSaleInvoice.Name;
            objOption.OptionPrintAfterClosingInvoice = chkPrintAfterClosingInvoice.Name;
            objOption.OptionPrintAfterClosingRecipt = chkPrintAfterClosingRecipt.Name;
            objOption.OptionPrintTotalQuantity = chkPrintTotalQuantity.Name;
            objOption.OptionHideDiscountFiledOnPrint = chkHideDiscountFiledOnPrint.Name;
            objOption.OptionShowTime = chkShowTime.Name;
            objOption.OptionHideTaxFiled = chkHideTaxFiled.Name;
            objOption.OptionHideLogoOnPrint = chkHideLogoOnPrint.Name;
            objOption.OptionHidePeaceBoxOnPrint = chkHidePeaceBoxInPrint.Name;
            objOption.OptionShowDeptOnPrint = chkShowDeptOnPrint.Name;
            objOption.OptionIgnoreNonStockItem = chkIgnoreNonStockItem.Name;
            objOption.OptionPosCategoryVicePrint = chkPosCategoryVicePrint.Name;

            if (Cmb_InvoiceTemplate.SelectedIndex >= 0)
            {
                objOption.FlagInvoiceTemplate = Cmb_InvoiceTemplate.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagInvoiceTemplate = "-1";
            }
            if (Cmb_BarcodePaperSize.SelectedIndex >= 0)
            {
                objOption.FlagBarcodePaperSize = Cmb_BarcodePaperSize.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagBarcodePaperSize = "-1";
            }

            if (Cmb_BarcodePrinter.SelectedIndex >= 0)
            {
                objOption.FlagBarcodePrinter = Cmb_BarcodePrinter.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagBarcodePrinter = "-1";
            }

            if (Cmb_PrintingLogo.SelectedIndex >= 0)
            {
                objOption.FlagPrintingLogo = Cmb_PrintingLogo.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagPrintingLogo = "-1";
            }

            if (string.IsNullOrEmpty(txtBarcodeSize.Text))
            {
                objOption.FlagBarcodeSize = "75";
            }
            else
            {
                objOption.FlagBarcodeSize = txtBarcodeSize.Text;
            }

            if (Cmb_ItemSorting.SelectedIndex >= 0)
            {
                objOption.FlagItemSorting = Cmb_ItemSorting.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagItemSorting = "2";
            }
            objOption.FlagInvoiceCopies = UD_InvoiceCopies.Value.ToString();
            objOption.FlagReciptCopies = UD_ReciptCopies.Value.ToString();
            objOption.FlagHeader = UD_Header.Value.ToString();
            objOption.FlagFooter = UD_Footer.Value.ToString();
            objOption.FlagLogoHeader = Txt_LogoHeader.Text;
            objOption.FlagLogoFooter = Txt_LogoFooter.Text;
            objOption.FlagNoteSaleInvoice = Txt_NoteSaleInvoice.Text;
            if (chkPrintAfterClosingInvoice.Checked == true)
            {
                objOption.FlagPrintAfterClosingInvoice = "Y";
            }
            else
            {
                objOption.FlagPrintAfterClosingInvoice = "N";
            }
            if (chkPrintAfterClosingRecipt.Checked == true)
            {
                objOption.FlagPrintAfterClosingRecipt = "Y";
            }
            else
            {
                objOption.FlagPrintAfterClosingRecipt = "N";
            }
            if (chkPrintTotalQuantity.Checked == true)
            {
                objOption.FlagPrintTotalQuantity = "Y";
            }
            else
            {
                objOption.FlagPrintTotalQuantity = "N";
            }
            if (chkHideDiscountFiledOnPrint.Checked == true)
            {
                objOption.FlagHideDiscountFiledOnPrint = "Y";
            }
            else
            {
                objOption.FlagHideDiscountFiledOnPrint = "N";
            }
            if (chkShowTime.Checked == true)
            {
                objOption.FlagShowTime = "Y";
            }
            else
            {
                objOption.FlagShowTime = "N";
            }
            if (chkHideTaxFiled.Checked == true)
            {
                objOption.FlagHideTaxFiled = "Y";
            }
            else
            {
                objOption.FlagHideTaxFiled = "N";
            }
            if (chkHideLogoOnPrint.Checked == true)
            {
                objOption.FlagHideLogoOnPrint = "Y";
            }
            else
            {
                objOption.FlagHideLogoOnPrint = "N";
            }

            if (chkHidePeaceBoxInPrint.Checked == true)
            {
                objOption.FlagHidePeaceBoxOnPrint = "Y";
            }
            else
            {
                objOption.FlagHidePeaceBoxOnPrint = "N";
            }
            if (chkShowDeptOnPrint.Checked == true)
            {
                objOption.FlagShowDeptOnPrint = "Y";
            }
            else
            {
                objOption.FlagShowDeptOnPrint = "N";
            }
            if (chkIgnoreNonStockItem.Checked == true)
            {
                objOption.FlagIgnoreNonStockItem = "Y";
            }
            else
            {
                objOption.FlagIgnoreNonStockItem = "N";
            }
            if (chkPosCategoryVicePrint.Checked == true)
            {
                objOption.FlagPosCategoryVicePrint = "Y";
            }
            else
            {
                objOption.FlagPosCategoryVicePrint = "N";
            }
            strValue = "";
            strValue = objOption.OptionInvoiceTemplate + "|" + objOption.FlagInvoiceTemplate + "~" + objOption.OptionBarcodePaperSize + "|" + objOption.FlagBarcodePaperSize;
            strValue = strValue + "~" + objOption.OptionBarcodePrinter + "|" + objOption.FlagBarcodePrinter + "~" + objOption.OptionPrintingLogo + "|" + objOption.FlagPrintingLogo;
            strValue = strValue + "~" + objOption.OptionItemSorting + "|" + objOption.FlagItemSorting + "~" + objOption.OptionInvoiceCopies + "|" + objOption.FlagInvoiceCopies;
            strValue = strValue + "~" + objOption.OptionReciptCopies + "|" + objOption.FlagReciptCopies + "~" + objOption.OptionHeader + "|" + objOption.FlagHeader;
            strValue = strValue + "~" + objOption.OptionFooter + "|" + objOption.FlagFooter + "~" + objOption.OptionLogoHeader + "|" + objOption.FlagLogoHeader;
            strValue = strValue + "~" + objOption.OptionLogoFooter + "|" + objOption.FlagLogoFooter + "~" + objOption.OptionNoteSaleInvoice + "|" + objOption.FlagNoteSaleInvoice;
            strValue = strValue + "~" + objOption.OptionPrintAfterClosingInvoice + "|" + objOption.FlagPrintAfterClosingInvoice + "~" + objOption.OptionPrintAfterClosingRecipt + "|" + objOption.FlagPrintAfterClosingRecipt;
            strValue = strValue + "~" + objOption.OptionPrintTotalQuantity + "|" + objOption.FlagPrintTotalQuantity + "~" + objOption.OptionHideDiscountFiledOnPrint + "|" + objOption.FlagHideDiscountFiledOnPrint;
            strValue = strValue + "~" + objOption.OptionShowTime + "|" + objOption.FlagShowTime + "~" + objOption.OptionHideTaxFiled + "|" + objOption.FlagHideTaxFiled;
            strValue = strValue + "~" + objOption.OptionHideLogoOnPrint + "|" + objOption.FlagHideLogoOnPrint + "~" + objOption.OptionShowDeptOnPrint + "|" + objOption.FlagShowDeptOnPrint;
            strValue = strValue + "~" + objOption.OptionIgnoreNonStockItem + "|" + objOption.FlagIgnoreNonStockItem + "~" + objOption.OptionPosCategoryVicePrint + "|" + objOption.FlagPosCategoryVicePrint + "~" + objOption.OptionHidePeaceBoxOnPrint  + "|" + objOption.FlagHidePeaceBoxOnPrint + "~" + objOption.OptionBarcodeSize + "|" + objOption.FlagBarcodeSize + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }

        #endregion

        #region SaveOption_Item

        public void SaveOption_Item()
        {
            objOption.OptionAlertExpiry = UD_AlertExpiry.Name;
            objOption.OptionAlertReorderItem = UD_AlertReorderItem.Name;
            objOption.OptionIssueOrderInvoice = UD_IssueOrderInvoice.Name;
            objOption.OptionAlertForReorders = chkAlertForReorders.Name;
            objOption.OptionDontIssueReorderInvoice = chkDontIssueReorderInvoice.Name;
            objOption.OptionHideItemSaleTimeInInvoice = chkHideItemSaleTimeInInvoice.Name;
            objOption.OptionHideItemCostInSales = chkHideItemCostInSales.Name;
            objOption.OptionHideItemNumber = chkHideItemNumber.Name;
            objOption.OptionDontTabToReorderandMaxpoint = chkDontTabToReorderandMaxpoint.Name;
            objOption.OptionDontAlertForExpiryInNotes = chkDontAlertForExpiryInNotes.Name;
            objOption.OptionQuitWithoutAsking = chkQuitWithoutAsking.Name;
            objOption.OptionSellExpiryWenNotEnough = chkSellExpiryWenNotEnough.Name;
            objOption.OptionAlertForMultiExpiry = chkAlertForMultiExpiry.Name;
            objOption.OptionUseExpiryDefaultInItemCard = chkUseExpiryDefaultInItemCard.Name;
            objOption.OptionHidePackageQuantity = chkHidePackageQuantity.Name;
            objOption.OptionMonitorReorderAndMaxpoint = chkMonitorReorderAndMaxpoint.Name;
            objOption.OptionPurchase_HideExpiryFiled = Chk_Purchase_HideExpiryFiled.Name;
            objOption.OptionSale_HideExpiryFiled = chkSale_HideExpiryFiled.Name;
            objOption.FlagAlertExpiry = UD_AlertExpiry.Value.ToString();
            objOption.FlagAlertReorderItem = UD_AlertReorderItem.Value.ToString();
            objOption.FlagIssueOrderInvoice = UD_IssueOrderInvoice.Value.ToString();
            objOption.OptionPurchase_DontUseExpiry = chkPurchaseDontUseExpiry.Name;
            objOption.OptionSale_DontUseExpiry = chkSaleDontUseExpiry.Name;
            objOption.OptionCHKAutoItemPrice = ckhAutoItemPrice.Name;
            objOption.OptionTxtAutoItemPrice = txtAutoItemPrice.Name;
            if (chkAlertForReorders.Checked == true)
            {
                objOption.FlagAlertForReorders = "Y";
            }
            else
            {
                objOption.FlagAlertForReorders = "N";
            }
            if (chkDontIssueReorderInvoice.Checked == true)
            {
                objOption.FlagDontIssueReorderInvoice = "Y";
            }
            else
            {
                objOption.FlagDontIssueReorderInvoice = "N";
            }
            if (chkHideItemSaleTimeInInvoice.Checked == true)
            {
                objOption.FlagHideItemSaleTimeInInvoice = "Y";
            }
            else
            {
                objOption.FlagHideItemSaleTimeInInvoice = "N";
            }
            if (chkHideItemCostInSales.Checked == true)
            {
                objOption.FlagHideItemCostInSales = "Y";
            }
            else
            {
                objOption.FlagHideItemCostInSales = "N";
            }
            if (chkHideItemNumber.Checked == true)
            {
                objOption.FlagHideItemNumber = "Y";
            }
            else
            {
                objOption.FlagHideItemNumber = "N";
            }
            if (chkDontTabToReorderandMaxpoint.Checked == true)
            {
                objOption.FlagDontTabToReorderandMaxpoint = "Y";
            }
            else
            {
                objOption.FlagDontTabToReorderandMaxpoint = "N";
            }
            if (chkDontAlertForExpiryInNotes.Checked == true)
            {
                objOption.FlagDontAlertForExpiryInNotes = "Y";
            }
            else
            {
                objOption.FlagDontAlertForExpiryInNotes = "N";
            }
            if (chkQuitWithoutAsking.Checked == true)
            {
                objOption.FlagQuitWithoutAsking = "Y";
            }
            else
            {
                objOption.FlagQuitWithoutAsking = "N";
            }
            if (chkSellExpiryWenNotEnough.Checked == true)
            {
                objOption.FlagSellExpiryWenNotEnough = "Y";
            }
            else
            {
                objOption.FlagSellExpiryWenNotEnough = "N";
            }
            if (chkAlertForMultiExpiry.Checked == true)
            {
                objOption.FlagAlertForMultiExpiry = "Y";
            }
            else
            {
                objOption.FlagAlertForMultiExpiry = "N";
            }
            if (chkUseExpiryDefaultInItemCard.Checked == true)
            {
                objOption.FlagUseExpiryDefaultInItemCard = "Y";
            }
            else
            {
                objOption.FlagUseExpiryDefaultInItemCard = "N";
            }
            if (chkHidePackageQuantity.Checked == true)
            {
                objOption.FlagHidePackageQuantity = "Y";
            }
            else
            {
                objOption.FlagHidePackageQuantity = "N";
            }
            if (chkMonitorReorderAndMaxpoint.Checked == true)
            {
                objOption.FlagMonitorReorderAndMaxpoint = "Y";
            }
            else
            {
                objOption.FlagMonitorReorderAndMaxpoint = "N";
            }
            if (Chk_HideExpiryFiled.Checked == true)
            {
                objOption.FlagPurchase_HideExpiryFiled = objOption.FlagSale_HideExpiryFiled = "Y";
                objOption.FlagPurchase_DontUseExpiry = objOption.FlagSale_DontUseExpiry = "Y";
            }
            else
            {
                objOption.FlagPurchase_HideExpiryFiled = objOption.FlagSale_HideExpiryFiled = "N";
                objOption.FlagPurchase_DontUseExpiry = objOption.FlagSale_DontUseExpiry = "N";
            }
            if (ckhAutoItemPrice.Checked)
            {
                objOption.FlagCHKAutoPriceItem = "Y";
                objOption.FlagTxtAutoPriceItem = txtAutoItemPrice.Text;
            }
            else
            {
                objOption.FlagCHKAutoPriceItem = "N";
                objOption.FlagTxtAutoPriceItem = "0";
            }

            strValue = "";
            strValue = objOption.OptionAlertExpiry + "|" + objOption.FlagAlertExpiry + "~" + objOption.OptionAlertReorderItem + "|" + objOption.FlagAlertReorderItem;
            strValue = strValue + "~" + objOption.OptionIssueOrderInvoice + "|" + objOption.FlagIssueOrderInvoice + "~" + objOption.OptionAlertForReorders + "|" + objOption.FlagAlertForReorders;
            strValue = strValue + "~" + objOption.OptionDontIssueReorderInvoice + "|" + objOption.FlagDontIssueReorderInvoice + "~" + objOption.OptionHideItemSaleTimeInInvoice + "|" + objOption.FlagHideItemSaleTimeInInvoice;
            strValue = strValue + "~" + objOption.OptionHideItemCostInSales + "|" + objOption.FlagHideItemCostInSales + "~" + objOption.OptionHideItemNumber + "|" + objOption.FlagHideItemNumber;
            strValue = strValue + "~" + objOption.OptionDontTabToReorderandMaxpoint + "|" + objOption.FlagDontTabToReorderandMaxpoint + "~" + objOption.OptionDontAlertForExpiryInNotes + "|" + objOption.FlagDontAlertForExpiryInNotes;
            strValue = strValue + "~" + objOption.OptionQuitWithoutAsking + "|" + objOption.FlagQuitWithoutAsking + "~" + objOption.OptionSellExpiryWenNotEnough + "|" + objOption.FlagSellExpiryWenNotEnough;
            strValue = strValue + "~" + objOption.OptionAlertForMultiExpiry + "|" + objOption.FlagAlertForMultiExpiry + "~" + objOption.OptionUseExpiryDefaultInItemCard + "|" + objOption.FlagUseExpiryDefaultInItemCard;
            strValue = strValue + "~" + objOption.OptionHidePackageQuantity + "|" + objOption.FlagHidePackageQuantity + "~" + objOption.OptionMonitorReorderAndMaxpoint + "|" + objOption.FlagMonitorReorderAndMaxpoint + "~";
            strValue = strValue + objOption.OptionPurchase_HideExpiryFiled + "|" + objOption.FlagPurchase_HideExpiryFiled + "~" + objOption.OptionSale_HideExpiryFiled + "|" + objOption.FlagSale_HideExpiryFiled + "~";
            strValue = strValue + objOption.OptionSale_DontUseExpiry + "|" + objOption.FlagSale_DontUseExpiry + "~" + objOption.OptionPurchase_DontUseExpiry + "|" + objOption.FlagPurchase_DontUseExpiry + "~";
            strValue = strValue + objOption.OptionCHKAutoItemPrice + "|" + objOption.FlagCHKAutoPriceItem + "~" + objOption.OptionTxtAutoItemPrice + "|" + objOption.FlagTxtAutoPriceItem + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }

        #endregion

        #region SaveOption_Backup
        public void SaveOption_Backup()
        {
            objOption.OptionAskWhenLeavingSystem = chkAskWhenLeavingSystem.Name;
            objOption.OptionAutomaticBackupWhenClosing = chkAutomaticBackupWhenClosing.Name;
            objOption.OptionAskWhenReplacingFile = chkAskWhenReplacingFile.Name;
            objOption.OptionSaveAutomaticBackupInAlternativePath = chkSaveAutomaticBackupInAlternativePath.Name;
            objOption.OptionSaveFilenameWithDatetime = chkSaveFilenameWithDatetime.Name;
            objOption.OptionAlertWhenNotMakingBackup = chkAlertWhenNotMakingBackup.Name;
            objOption.OptionAutomaticBackupDays = UD_AutomaticBackupDays.Name;
            objOption.OptionSaveBackup = Txt_SaveBackup.Name;
            objOption.OptionAlternativePath = Txt_AlternativePath.Name;
            objOption.OptionLastBackupDate = Txt_LastBackupDate.Name;

            if (chkAskWhenLeavingSystem.Checked == true)
            {
                objOption.FlagAskWhenLeavingSystem = "Y";
            }
            else
            {
                objOption.FlagAskWhenLeavingSystem = "N";
            }
            if (chkAutomaticBackupWhenClosing.Checked == true)
            {
                objOption.FlagAutomaticBackupWhenClosing = "Y";
            }
            else
            {
                objOption.FlagAutomaticBackupWhenClosing = "N";
            }
            if (chkAskWhenReplacingFile.Checked == true)
            {
                objOption.FlagAskWhenReplacingFile = "Y";
            }
            else
            {
                objOption.FlagAskWhenReplacingFile = "N";
            }
            if (chkSaveAutomaticBackupInAlternativePath.Checked == true)
            {
                objOption.FlagSaveAutomaticBackupInAlternativePath = "Y";
            }
            else
            {
                objOption.FlagSaveAutomaticBackupInAlternativePath = "N";
            }
            if (chkSaveFilenameWithDatetime.Checked == true)
            {
                objOption.FlagSaveFilenameWithDatetime = "Y";
            }
            else
            {
                objOption.FlagSaveFilenameWithDatetime = "N";
            }
            if (chkAlertWhenNotMakingBackup.Checked == true)
            {
                objOption.FlagAlertWhenNotMakingBackup = "Y";
            }
            else
            {
                objOption.FlagAlertWhenNotMakingBackup = "N";
            }
            objOption.FlagAutomaticBackupDays = UD_AutomaticBackupDays.Value.ToString();
            objOption.FlagSaveBackup = Txt_SaveBackup.Text;
            objOption.FlagAlternativePath = Txt_AlternativePath.Text;
            objOption.FlagLastBackupDate = Txt_LastBackupDate.Text;

            strValue = "";
            strValue = objOption.OptionAskWhenLeavingSystem + "|" + objOption.FlagAskWhenLeavingSystem + "~" + objOption.OptionAutomaticBackupWhenClosing + "|" + objOption.FlagAutomaticBackupWhenClosing;
            strValue = strValue + "~" + objOption.OptionAskWhenReplacingFile + "|" + objOption.FlagAskWhenReplacingFile + "~" + objOption.OptionSaveAutomaticBackupInAlternativePath + "|" + objOption.FlagSaveAutomaticBackupInAlternativePath;
            strValue = strValue + "~" + objOption.OptionSaveFilenameWithDatetime + "|" + objOption.FlagSaveFilenameWithDatetime + "~" + objOption.OptionAlertWhenNotMakingBackup + "|" + objOption.FlagAlertWhenNotMakingBackup;
            strValue = strValue + "~" + objOption.OptionAutomaticBackupDays + "|" + objOption.FlagAutomaticBackupDays + "~" + objOption.OptionSaveBackup + "|" + objOption.FlagSaveBackup;
            strValue = strValue + "~" + objOption.OptionAlternativePath + "|" + objOption.FlagAlternativePath + "~" + objOption.OptionLastBackupDate + "|" + objOption.FlagLastBackupDate + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }

        #endregion

        #region SaveOption_Peripherals
        public void SaveOption_Peripherals()
        {

            if (!PeripheralsValidation()) { isvalidation = false; return; }
            GeneralFunction.SetConfigValue("COMPort", Cmb_COMPort.Text != string.Empty ? Cmb_COMPort.Text : string.Empty);
            objOption.OptionUseCustomerDisplay = chkUseCustomerDisplay.Name;
            objOption.OptionFirstLineWelcomeNote = Txt_FirstLineWelcomeNote.Name;
            objOption.OptionSecondLineWelcomeNote = Txt_SecondLineWelcomeNote.Name;
            objOption.OptionUseCashDrawer = chkUseCashDrawer.Name;
            objOption.OptionDrawerTypeUSP = rbnDrawerTypeUSP.Name;
            objOption.OptionDrawerTypeCOM = rbnDrawerTypeCOM.Name;
            objOption.OptionDrawerTypeRJ11 = rbnDrawerTypeRJ11.Name;
            objOption.OptionDrawerOpenDirectlyAfterPrint = chkDrawerOpenDirectlyAfterPrint.Name;
            objOption.OptionDrawerProtectWithPassword = chkDrawerProtectWithPassword.Name;
            objOption.OptionPriceChecker = chkPriceCheckerActive.Name;
            objOption.OptionCashDrawerPassword = Txt_CashDrawerPassword.Name;
            objOption.OptionCashDrawerVerifyPassword = Txt_CashDrawerVerifyPassword.Name;


            if (chkUseCustomerDisplay.Checked == true)
            {
                objOption.FlagUseCustomerDisplay = "Y";
            }
            else
            {
                objOption.FlagUseCustomerDisplay = "N";
            }
            objOption.FlagFirstLineWelcomeNote = Txt_FirstLineWelcomeNote.Text;
            objOption.FlagSecondLineWelcomeNote = Txt_SecondLineWelcomeNote.Text;
            if (chkUseCashDrawer.Checked == true)
            {
                objOption.FlagUseCashDrawer = "Y";
            }
            else
            {
                objOption.FlagUseCashDrawer = "N";
            }
            if (rbnDrawerTypeUSP.Checked == true)
            {
                objOption.FlagDrawerTypeUSP = "Y";
            }
            else
            {
                objOption.FlagDrawerTypeUSP = "N";
            }
            if (rbnDrawerTypeCOM.Checked == true)
            {
                objOption.FlagDrawerTypeCOM = "Y";
            }
            else
            {
                objOption.FlagDrawerTypeCOM = "N";
            }
            if (rbnDrawerTypeRJ11.Checked == true)
            {
                objOption.FlagDrawerTypeRJ11 = "Y";
            }
            else
            {
                objOption.FlagDrawerTypeRJ11 = "N";
            }
            if (chkDrawerOpenDirectlyAfterPrint.Checked == true)
            {
                objOption.FlagDrawerOpenDirectlyAfterPrint = "Y";
            }
            else
            {
                objOption.FlagDrawerOpenDirectlyAfterPrint = "N";
            }
            if (chkDrawerProtectWithPassword.Checked == true)
            {
                objOption.FlagDrawerProtectWithPassword = "Y";
            }
            else
            {
                objOption.FlagDrawerProtectWithPassword = "N";
            }
            if (chkPriceCheckerActive.Checked == true)
            {
                objOption.FlagPriceChecker = "Y";
            }
            else
            {
                objOption.FlagPriceChecker = "N";
            }
            objOption.FlagCashDrawerPassword = Txt_CashDrawerPassword.Text;
            objOption.FlagCashDrawerVerifyPassword = Txt_CashDrawerVerifyPassword.Text;

            strValue = "";
            strValue = objOption.OptionUseCustomerDisplay + "|" + objOption.FlagUseCustomerDisplay + "~" + objOption.OptionFirstLineWelcomeNote + "|" + objOption.FlagFirstLineWelcomeNote;
            strValue = strValue + "~" + objOption.OptionSecondLineWelcomeNote + "|" + objOption.FlagSecondLineWelcomeNote + "~" + objOption.OptionUseCashDrawer + "|" + objOption.FlagUseCashDrawer;
            strValue = strValue + "~" + objOption.OptionDrawerTypeUSP + "|" + objOption.FlagDrawerTypeUSP + "~" + objOption.OptionDrawerTypeCOM + "|" + objOption.FlagDrawerTypeCOM;
            strValue = strValue + "~" + objOption.OptionDrawerTypeRJ11 + "|" + objOption.FlagDrawerTypeRJ11 + "~" + objOption.OptionDrawerOpenDirectlyAfterPrint + "|" + objOption.FlagDrawerOpenDirectlyAfterPrint;
            strValue = strValue + "~" + objOption.OptionDrawerProtectWithPassword + "|" + objOption.FlagDrawerProtectWithPassword + "~" + objOption.OptionCashDrawerPassword + "|" + objOption.FlagCashDrawerPassword;
            strValue = strValue + "~" + objOption.OptionCashDrawerVerifyPassword + "|" + objOption.FlagCashDrawerVerifyPassword + "~" + objOption.OptionPriceChecker + "|" + objOption.FlagPriceChecker + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }
        #endregion

        #region SaveOption_Tax
        public void SaveOption_Tax()
        {
            objOption.OptionTax1_TaxName = Txt_Tax1_TaxName.Name;
            objOption.OptionTax1_Percentage = UD_Tax1_Percentage.Name;
            objOption.OptionTax1_SubPercentage = UD_Tax1_SubPercentage.Name;
            objOption.OptionTax1_ShowTaxInvoice = Cmb_Tax1_ShowTaxInvoice.Name;
            objOption.OptionTax1_ApplySales = chkTax1_ApplySales.Name;
            objOption.OptionTax1_ApplyPurchase = chkTax1_ApplyPurchase.Name;
            objOption.OptionTax1_ApplyMaintains = chkTax1_ApplyMaintains.Name;
            objOption.OptionTax1_ApplyBeforeDiscount = chkTax1_ApplyBeforeDiscount.Name;
            objOption.OptionTax2_TaxName = Txt_Tax2_TaxName.Name;
            objOption.OptionTax2_Percentage = UD_Tax2_Percentage.Name;
            objOption.OptionTax2_SubPercentage = UD_Tax2_SubPercentage.Name;
            objOption.OptionTax2_ShowTaxInvoice = Cmb_Tax2_ShowTaxInvoice.Name;
            objOption.OptionTax2_ApplySales = chkTax2_ApplySales.Name;
            objOption.OptionTax2_ApplyPurchase = chkTax2_ApplyPurchase.Name;
            objOption.OptionTax2_ApplyMaintains = chkTax2_ApplyMaintains.Name;
            objOption.OptionTax2_ApplyBeforeDiscount = chkTax2_ApplyBeforeDiscount.Name;


            objOption.FlagTax1_TaxName = Txt_Tax1_TaxName.Text;
            objOption.FlagTax1_Percentage = UD_Tax1_Percentage.Value.ToString();
            objOption.FlagTax1_SubPercentage = UD_Tax1_SubPercentage.Value.ToString();
            objOption.FlagTax1_ShowTaxInvoice = Cmb_Tax1_ShowTaxInvoice.SelectedIndex.ToString();
            if (chkTax1_ApplySales.Checked == true)
            {
                objOption.FlagTax1_ApplySales = "Y";
            }
            else
            {
                objOption.FlagTax1_ApplySales = "N";
            }
            if (chkTax1_ApplyPurchase.Checked == true)
            {
                objOption.FlagTax1_ApplyPurchase = "Y";
            }
            else
            {
                objOption.FlagTax1_ApplyPurchase = "N";
            }
            if (chkTax1_ApplyMaintains.Checked == true)
            {
                objOption.FlagTax1_ApplyMaintains = "Y";
            }
            else
            {
                objOption.FlagTax1_ApplyMaintains = "N";
            }
            if (chkTax1_ApplyBeforeDiscount.Checked == true)
            {
                objOption.FlagTax1_ApplyBeforeDiscount = "Y";
            }
            else
            {
                objOption.FlagTax1_ApplyBeforeDiscount = "N";
            }
            objOption.FlagTax2_TaxName = Txt_Tax2_TaxName.Text;
            objOption.FlagTax2_Percentage = UD_Tax2_Percentage.Value.ToString();
            objOption.FlagTax2_SubPercentage = UD_Tax2_SubPercentage.Value.ToString();
            objOption.FlagTax2_ShowTaxInvoice = Cmb_Tax2_ShowTaxInvoice.SelectedIndex.ToString();
            if (chkTax2_ApplySales.Checked == true)
            {
                objOption.FlagTax2_ApplySales = "Y";
            }
            else
            {
                objOption.FlagTax2_ApplySales = "N";
            }
            if (chkTax2_ApplyPurchase.Checked == true)
            {
                objOption.FlagTax2_ApplyPurchase = "Y";
            }
            else
            {
                objOption.FlagTax2_ApplyPurchase = "N";
            }
            if (chkTax2_ApplyMaintains.Checked == true)
            {
                objOption.FlagTax2_ApplyMaintains = "Y";
            }
            else
            {
                objOption.FlagTax2_ApplyMaintains = "N";
            }
            if (chkTax2_ApplyBeforeDiscount.Checked == true)
            {
                objOption.FlagTax2_ApplyBeforeDiscount = "Y";
            }
            else
            {
                objOption.FlagTax2_ApplyBeforeDiscount = "N";
            }
            strValue = "";
            strValue = objOption.OptionTax1_TaxName + "|" + objOption.FlagTax1_TaxName + "~" + objOption.OptionTax1_Percentage + "|" + objOption.FlagTax1_Percentage;
            strValue = strValue + "~" + objOption.OptionTax1_SubPercentage + "|" + objOption.FlagTax1_SubPercentage + "~" + objOption.OptionTax1_ShowTaxInvoice + "|" + objOption.FlagTax1_ShowTaxInvoice;
            strValue = strValue + "~" + objOption.OptionTax1_ApplySales + "|" + objOption.FlagTax1_ApplySales + "~" + objOption.OptionTax1_ApplyPurchase + "|" + objOption.FlagTax1_ApplyPurchase;
            strValue = strValue + "~" + objOption.OptionTax1_ApplyMaintains + "|" + objOption.FlagTax1_ApplyMaintains + "~" + objOption.OptionTax1_ApplyBeforeDiscount + "|" + objOption.FlagTax1_ApplyBeforeDiscount;
            strValue = strValue + "~" + objOption.OptionTax2_TaxName + "|" + objOption.FlagTax2_TaxName + "~" + objOption.OptionTax2_Percentage + "|" + objOption.FlagTax2_Percentage;
            strValue = strValue + "~" + objOption.OptionTax2_SubPercentage + "|" + objOption.FlagTax2_SubPercentage + "~" + objOption.OptionTax2_ShowTaxInvoice + "|" + objOption.FlagTax2_ShowTaxInvoice;
            strValue = strValue + "~" + objOption.OptionTax2_ApplySales + "|" + objOption.FlagTax2_ApplySales + "~" + objOption.OptionTax2_ApplyPurchase + "|" + objOption.FlagTax2_ApplyPurchase;
            strValue = strValue + "~" + objOption.OptionTax2_ApplyMaintains + "|" + objOption.FlagTax2_ApplyMaintains + "~" + objOption.OptionTax2_ApplyBeforeDiscount + "|" + objOption.FlagTax2_ApplyBeforeDiscount + "~";

            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }

        #endregion

        #region SaveOption_Notification
        public void SaveOption_Notification()
        {
            if (Validation_ForNotifications() == true)
            {
                objOption.OptionLicenserenewal = Chk_Licenserenewal.Name;
                objOption.OptionLicenserenewalDate = DTP_LicenserenewalDate.Name;
                objOption.OptionLicenserenewalNotifyBefore = UD_LicenserenewalNotifyBefore.Name;
                objOption.OptionMedicalInsurance = Chk_MedicalInsurance.Name;
                objOption.OptionMedicalInsuranceDate = DTP_MedicalInsuranceDate.Name;
                objOption.OptionMedicalInsuranceNotifyBefore = UD_MedicalInsuranceNotifyBefore.Name;
                objOption.OptionCertificateofHealth = Chk_CertificateofHealth.Name;
                objOption.OptionCertificateofHealthDate = DTP_CertificateofHealthDate.Name;
                objOption.OptionCertificateofHealthNotifyBefore = UD_CertificateofHealthNotifyBefore.Name;
                objOption.OptionAttendancePermit = Chk_AttendancePermit.Name;
                objOption.OptionAttendancePermitDate = DTP_AttendancePermitDate.Name;
                objOption.OptionAttendancePermitNotifyBefore = UD_AttendancePermitNotifyBefore.Name;
                objOption.OptionTechnicalDisclosure = Chk_TechnicalDisclosure.Name;
                objOption.OptionTechnicalDisclosureDate = DTP_TechnicalDisclosureDate.Name;
                objOption.OptionTechnicalDisclosureNotifyBefore = UD_TechnicalDisclosureNotifyBefore.Name;
                objOption.OptionPricing = Chk_Pricing.Name;
                objOption.OptionPricingDate = DTP_PricingDate.Name;
                objOption.OptionPricingNotifyBefore = UD_PricingNotifyBefore.Name;
                objOption.OptionPayrent = Chk_Payrent.Name;
                objOption.OptionPayrentDate = DTP_PayrentDate.Name;
                objOption.OptionPayrentNotifyBefore = UD_PayrentNotifyBefore.Name;
                objOption.OptionDisbursementSalary = Chk_DisbursementSalary.Name;
                objOption.OptionDisbursementSalaryDate = DTP_DisbursementSalaryDate.Name;
                objOption.OptionDisbursementSalaryNotifyBefore = UD_DisbursementSalaryNotifyBefore.Name;
                objOption.OptionAnnualInventory = Chk_AnnualInventory.Name;
                objOption.OptionAnnualInventoryDate = DTP_AnnualInventoryDate.Name;
                objOption.OptionAnnualInventoryNotifyBefore = UD_AnnualInventoryNotifyBefore.Name;
                objOption.OptionZakat = Chk_Zakat.Name;
                objOption.OptionZakatDate = DTP_ZakatDate.Name;
                objOption.OptionZakatNotifyBefore = UD_ZakatNotifyBefore.Name;


                if (Chk_Licenserenewal.Checked == true)
                {
                    objOption.FlagLicenserenewal = "Y";
                }
                else
                {
                    objOption.FlagLicenserenewal = "N";
                }
                objOption.FlagLicenserenewalDate = Convert.ToDateTime(DTP_LicenserenewalDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagLicenserenewalDate = Convert.ToDateTime(DTP_LicenserenewalDate.Value.Date);
                objOption.FlagLicenserenewalNotifyBefore = int.Parse(UD_LicenserenewalNotifyBefore.Value.ToString());
                if (Chk_MedicalInsurance.Checked == true)
                {
                    objOption.FlagMedicalInsurance = "Y";
                }
                else
                {
                    objOption.FlagMedicalInsurance = "N";
                }
                objOption.FlagMedicalInsuranceDate = Convert.ToDateTime(DTP_MedicalInsuranceDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagMedicalInsuranceDate = Convert.ToDateTime(DTP_MedicalInsuranceDate.Value.Date);
                objOption.FlagMedicalInsuranceNotifyBefore = int.Parse(UD_MedicalInsuranceNotifyBefore.Value.ToString());
                if (Chk_CertificateofHealth.Checked == true)
                {
                    objOption.FlagCertificateofHealth = "Y";
                }
                else
                {
                    objOption.FlagCertificateofHealth = "N";
                }
                objOption.FlagCertificateofHealthDate = Convert.ToDateTime(DTP_CertificateofHealthDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagCertificateofHealthDate = Convert.ToDateTime(DTP_CertificateofHealthDate.Value.Date);
                objOption.FlagCertificateofHealthNotifyBefore = int.Parse(UD_CertificateofHealthNotifyBefore.Value.ToString());
                if (Chk_AttendancePermit.Checked == true)
                {
                    objOption.FlagAttendancePermit = "Y";
                }
                else
                {
                    objOption.FlagAttendancePermit = "N";
                }
                objOption.FlagAttendancePermitDate = Convert.ToDateTime(DTP_AttendancePermitDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagAttendancePermitDate = Convert.ToDateTime(DTP_AttendancePermitDate.Value.Date);
                objOption.FlagAttendancePermitNotifyBefore = int.Parse(UD_AttendancePermitNotifyBefore.Value.ToString());


                if (Chk_TechnicalDisclosure.Checked == true)
                {

                    objOption.FlagTechnicalDisclosure = "Y/" + Txt_TextBox1.Text.Trim() + "";
                }
                else
                {
                    objOption.FlagTechnicalDisclosure = (Txt_TextBox1.Text.Trim() != "") ? "N/" + Txt_TextBox1.Text.Trim() + "" : "N/";

                }
                objOption.FlagTechnicalDisclosureDate = Convert.ToDateTime(DTP_TechnicalDisclosureDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagTechnicalDisclosureDate = Convert.ToDateTime(DTP_TechnicalDisclosureDate.Value.Date);
                objOption.FlagTechnicalDisclosureNotifyBefore = int.Parse(UD_TechnicalDisclosureNotifyBefore.Value.ToString());
                if (Chk_Pricing.Checked == true)
                {
                    objOption.FlagPricing = "Y/" + Txt_TextBox2.Text.Trim() + "";
                }
                else
                {
                    objOption.FlagPricing = (Txt_TextBox2.Text.Trim() != "") ? "N/" + Txt_TextBox2.Text.Trim() + "" : "N/";
                }
                objOption.FlagPricingDate = Convert.ToDateTime(DTP_PricingDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagPricingDate = Convert.ToDateTime(DTP_PricingDate.Value.Date);
                objOption.FlagPricingNotifyBefore = int.Parse(UD_PricingNotifyBefore.Value.ToString());
                if (Chk_Payrent.Checked == true)
                {
                    objOption.FlagPayrent = "Y/" + Txt_TextBox3.Text.Trim() + "";
                }
                else
                {
                    objOption.FlagPayrent = (Txt_TextBox3.Text.Trim() != "") ? "N/" + Txt_TextBox3.Text.Trim() + "" : "N/";
                }

                objOption.FlagPayrentDate = Convert.ToDateTime(DTP_PayrentDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagPayrentDate = Convert.ToDateTime(DTP_PayrentDate.Value.Date);
                objOption.FlagPayrentNotifyBefore = int.Parse(UD_PayrentNotifyBefore.Value.ToString());
                if (Chk_DisbursementSalary.Checked == true)
                {
                    objOption.FlagDisbursementSalary = "Y/" + Txt_TextBox4.Text.Trim() + "";
                }
                else
                {
                    objOption.FlagDisbursementSalary = (Txt_TextBox4.Text.Trim() != "") ? "N/" + Txt_TextBox4.Text.Trim() + "" : "N/";
                }
                objOption.FlagDisbursementSalaryDate = Convert.ToDateTime(DTP_DisbursementSalaryDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagDisbursementSalaryDate = Convert.ToDateTime(DTP_DisbursementSalaryDate.Value.Date);
                objOption.FlagDisbursementSalaryNotifyBefore = int.Parse(UD_DisbursementSalaryNotifyBefore.Value.ToString());
                if (Chk_AnnualInventory.Checked == true)
                {
                    objOption.FlagAnnualInventory = "Y/" + Txt_TextBox5.Text.Trim() + "";
                }
                else
                {
                    objOption.FlagAnnualInventory = (Txt_TextBox5.Text.Trim() != "") ? "N/" + Txt_TextBox5.Text.Trim() + "" : "N/";
                }
                objOption.FlagAnnualInventoryDate = Convert.ToDateTime(DTP_AnnualInventoryDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagAnnualInventoryDate = Convert.ToDateTime(DTP_AnnualInventoryDate.Value.Date);
                objOption.FlagAnnualInventoryNotifyBefore = int.Parse(UD_AnnualInventoryNotifyBefore.Value.ToString());
                if (Chk_Zakat.Checked == true)
                {
                    objOption.FlagZakat = "Y";
                }
                else
                {
                    objOption.FlagZakat = "N";
                }
                objOption.FlagZakatDate = Convert.ToDateTime(DTP_ZakatDate.Value.Date);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FlagZakatDate = Convert.ToDateTime(DTP_ZakatDate.Value.Date);
                objOption.FlagZakatNotifyBefore = int.Parse(UD_ZakatNotifyBefore.Value.ToString());

                strValue = "";
                strValue = objOption.OptionLicenserenewal + "|" + objOption.FlagLicenserenewal + "~" + objOption.OptionLicenserenewalDate + "|" + objOption.FlagLicenserenewalDate;
                strValue = strValue + "~" + objOption.OptionLicenserenewalNotifyBefore + "|" + objOption.FlagLicenserenewalNotifyBefore + "~" + objOption.OptionMedicalInsurance + "|" + objOption.FlagMedicalInsurance;
                strValue = strValue + "~" + objOption.OptionMedicalInsuranceDate + "|" + objOption.FlagMedicalInsuranceDate + "~" + objOption.OptionMedicalInsuranceNotifyBefore + "|" + objOption.FlagMedicalInsuranceNotifyBefore;
                strValue = strValue + "~" + objOption.OptionCertificateofHealth + "|" + objOption.FlagCertificateofHealth + "~" + objOption.OptionCertificateofHealthDate + "|" + objOption.FlagCertificateofHealthDate;
                strValue = strValue + "~" + objOption.OptionCertificateofHealthNotifyBefore + "|" + objOption.FlagCertificateofHealthNotifyBefore + "~" + objOption.OptionAttendancePermit + "|" + objOption.FlagAttendancePermit;
                strValue = strValue + "~" + objOption.OptionAttendancePermitDate + "|" + objOption.FlagAttendancePermitDate + "~" + objOption.OptionAttendancePermitNotifyBefore + "|" + objOption.FlagAttendancePermitNotifyBefore;
                strValue = strValue + "~" + objOption.OptionTechnicalDisclosure + "|" + objOption.FlagTechnicalDisclosure + "~" + objOption.OptionTechnicalDisclosureDate + "|" + objOption.FlagTechnicalDisclosureDate;
                strValue = strValue + "~" + objOption.OptionTechnicalDisclosureNotifyBefore + "|" + objOption.FlagTechnicalDisclosureNotifyBefore + "~" + objOption.OptionPricing + "|" + objOption.FlagPricing;
                strValue = strValue + "~" + objOption.OptionPricingDate + "|" + objOption.FlagPricingDate + "~" + objOption.OptionPricingNotifyBefore + "|" + objOption.FlagPricingNotifyBefore;
                strValue = strValue + "~" + objOption.OptionPayrent + "|" + objOption.FlagPayrent + "~" + objOption.OptionPayrentDate + "|" + objOption.FlagPayrentDate;
                strValue = strValue + "~" + objOption.OptionPayrentNotifyBefore + "|" + objOption.FlagPayrentNotifyBefore + "~" + objOption.OptionDisbursementSalary + "|" + objOption.FlagDisbursementSalary;
                strValue = strValue + "~" + objOption.OptionDisbursementSalaryDate + "|" + objOption.FlagDisbursementSalaryDate + "~" + objOption.OptionDisbursementSalaryNotifyBefore + "|" + objOption.FlagDisbursementSalaryNotifyBefore;
                strValue = strValue + "~" + objOption.OptionAnnualInventory + "|" + objOption.FlagAnnualInventory + "~" + objOption.OptionAnnualInventoryDate + "|" + objOption.FlagAnnualInventoryDate;
                strValue = strValue + "~" + objOption.OptionAnnualInventoryNotifyBefore + "|" + objOption.FlagAnnualInventoryNotifyBefore + "~" + objOption.OptionZakat + "|" + objOption.FlagZakat;
                strValue = strValue + "~" + objOption.OptionZakatDate + "|" + objOption.FlagZakatDate + "~" + objOption.OptionZakatNotifyBefore + "|" + objOption.FlagZakatNotifyBefore + "~";


                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
                objOptionSettingHelper.SaveNotificationDatesHelper();
                SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
            }

        }
        #endregion

        #region SaveOption_Other
        public void SaveOption_Other()
        {
            objOption.OptionDontAskClosingSystem = chkDontAskClosingSystem.Name;
            objOption.Option24HourWorkSystem = chk24HourWorkSystem.Name;
            objOption.OptionStopDeptSellings = chkStopDeptSellings.Name;
            objOption.OptionHidePackageReport = chkHidePackageReport.Name;
            objOption.OptionShowTipDayWhenStart = chkShowTipDayWhenStart.Name;
            objOption.OptionBranchBuyswithCost = chkBranchBuyswithCost.Name;
            objOption.OptionUseItemPhoto = chkUseItemPhoto.Name;
            //   objOption.OptionUseRentingInvoice = chkUseRentingInvoice.Name;
            objOption.OptionUseRentingInvoice = "";
            objOption.OptionDontAlertOnSave = chkDontAlertOnSave.Name;
            objOption.OptionDontAlertDeleteItemFromInvoice = chkDontAlertDeleteItemFromInvoice.Name;
            objOption.OptionUnifyOptionForallWorkStations = chkUnifyOptionForallWorkStations.Name;
            objOption.OptionRoundPriceOnDiscount = Chk_RoundPriceOnDiscount.Name;
            objOption.OptionRoundPricesOnDiscountValue = Cmb_RoundPricesOnDiscountValue.Name;
            objOption.OptionAlertReorderItemsPerDay = UD_AlertReorderItemsPerDay.Name;
            objOption.OptionAlertExpiryPerDay = UD_AlertExpiryPerDay.Name;
            objOption.OptionAlertPayDatesBefore = UD_AlertPayDatesBefore.Name;
            objOption.OptionAlertPayDates = chkAlertPayDates.Name;
            objOption.OptionAlertWithSound = chkAlertWithSound.Name;
            objOption.OptionAlertSaleInvoice = chkAlertSaleInvoice.Name;
            //objOption.OptionHideRentingInvoice = chkHideRentingInvoice.Name;
            objOption.OptionHideRentingInvoice = "";
            //objOption.OptionHideKitchenWindow = Chk_HideKitchenWindow.Name;
            objOption.OptionHideKitchenWindow = "";
            objOption.OptionHidePOSScreen = chkHidePOSScreen.Name;
            objOption.OptionHidePOSShortcut = chkHidePOSShortcut.Name;
            objOption.OptionSale_HidePaidRefund = chkHidePaidRefund.Name;
            objOption.OptionDateFormat = cmbDateFormat.Name;//Added on 16-June-2014
            objOption.OptionResetPOSOrder = chkResetPOSOrder.Name;//added on 03mar2015
            objOption.OptionPOSOrderResetCount = txtResetPOSOrderCount.Name;
            objOption.FlagPOSOrderResetCount = txtResetPOSOrderCount.Text.Trim();
            objOption.EnableNetworkSaleControl = chkEnableNetworkSaleControl.Name;
            objOption.EnableConfirmEndShift = chkConfirmEndShift.Name;
            objOption.EnableOpenNewInvoice = ChkOpenNewInvoice.Name;
            if (chkResetPOSOrder.Checked)
            {
                objOption.FlagResetPOSOrder = "Y";
            }
            else
            {
                objOption.FlagResetPOSOrder = "N";
            }
            if (chkDontAskClosingSystem.Checked == true)
            {
                objOption.FlagDontAskClosingSystem = "Y";
            }
            else
            {
                objOption.FlagDontAskClosingSystem = "N";
            }
            if (chk24HourWorkSystem.Checked == true)
            {
                objOption.Flag24HourWorkSystem = "Y";
            }
            else
            {
                objOption.Flag24HourWorkSystem = "N";
            }
            if (chkStopDeptSellings.Checked == true)
            {
                objOption.FlagStopDeptSellings = "Y";
            }
            else
            {
                objOption.FlagStopDeptSellings = "N";
            }
            if (chkHidePackageReport.Checked == true)
            {
                objOption.FlagHidePackageReport = "Y";
            }
            else
            {
                objOption.FlagHidePackageReport = "N";
            }
            if (chkShowTipDayWhenStart.Checked == true)
            {
                objOption.FlagShowTipDayWhenStart = "Y";
            }
            else
            {
                objOption.FlagShowTipDayWhenStart = "N";
            }
            if (chkBranchBuyswithCost.Checked == true)
            {
                objOption.FlagBranchBuyswithCost = "Y";
            }
            else
            {
                objOption.FlagBranchBuyswithCost = "N";
            }
            if (chkUseItemPhoto.Checked == true)
            {
                objOption.FlagUseItemPhoto = "Y";
            }
            else
            {
                objOption.FlagUseItemPhoto = "N";
            }
            //if (Chk_UseRentingInvoice.Checked == true)
            //{
            objOption.FlagUseRentingInvoice = "Y";
            //}
            //else
            //{
            //    objOption.FlagUseRentingInvoice = "N";
            //}
            if (chkDontAlertOnSave.Checked == true)
            {
                objOption.FlagDontAlertOnSave = "Y";
            }
            else
            {
                objOption.FlagDontAlertOnSave = "N";
            }
            if (chkDontAlertDeleteItemFromInvoice.Checked == true)
            {
                objOption.FlagDontAlertDeleteItemFromInvoice = "Y";
            }
            else
            {
                objOption.FlagDontAlertDeleteItemFromInvoice = "N";
            }
            if (chkUnifyOptionForallWorkStations.Checked == true)
            {
                objOption.FlagUnifyOptionForallWorkStations = "Y";
            }
            else
            {
                objOption.FlagUnifyOptionForallWorkStations = "N";
            }
            if (Chk_RoundPriceOnDiscount.Checked == true)
            {
                objOption.FlagRoundPriceOnDiscount = "Y";
            }
            else
            {
                objOption.FlagRoundPriceOnDiscount = "N";
            }

            if (Cmb_RoundPricesOnDiscountValue.SelectedIndex >= 0)
            {
                objOption.FlagRoundPricesOnDiscountValue = Cmb_RoundPricesOnDiscountValue.SelectedIndex.ToString();
            }
            else
            {
                objOption.FlagRoundPricesOnDiscountValue = "0";
            }

            if (chkEnableNetworkSaleControl.Checked == true)
            {
                objOption.FlagEnableNetworkSaleControl = "Y";
            }
            else
            {
                objOption.FlagEnableNetworkSaleControl = "N";
            }
            if (chkConfirmEndShift.Checked == true)
            {
                objOption.FlagEnableConfirmEndShift = "Y";
            }
            else
            {
                objOption.FlagEnableConfirmEndShift = "N";
            }
            if (ChkOpenNewInvoice.Checked == true)
            {
                objOption.FlagEnableOpenNewInvoice = "Y";
            }
            else
            {
                objOption.FlagEnableOpenNewInvoice = "N";
            }

            objOption.FlagAlertReorderItemsPerDay = UD_AlertReorderItemsPerDay.Value.ToString();
            objOption.FlagAlertExpiryPerDay = UD_AlertExpiryPerDay.Value.ToString();
            objOption.FlagAlertPayDatesBefore = UD_AlertPayDatesBefore.Value.ToString();

            if (chkAlertPayDates.Checked == true)
            {
                objOption.FlagAlertPayDates = "Y";
            }
            else
            {
                objOption.FlagAlertPayDates = "N";
            }
            if (chkAlertWithSound.Checked == true)
            {
                objOption.FlagAlertWithSound = "Y";
            }
            else
            {
                objOption.FlagAlertWithSound = "N";
            }
            if (chkAlertSaleInvoice.Checked == true)
            {
                objOption.FlagAlertSaleInvoice = "Y";
            }
            else
            {
                objOption.FlagAlertSaleInvoice = "N";
            }

            objOption.FlagHideKitchenWindow = "Y";

            objOption.FlagHideRentingInvoice = "N";

            if (chkHidePOSShortcut.Checked == true)
            {
                objOption.FlagHidePOSShortcut = "Y";
            }
            else
            {
                objOption.FlagHidePOSShortcut = "N";
            }
            if (chkHidePOSScreen.Checked == true)
            {
                objOption.FlagHidePOSScreen = "Y";
            }
            else
            {
                objOption.FlagHidePOSScreen = "N";
            }
            if (chkHidePaidRefund.Checked == true)
            {
                objOption.FlagSale_HidePaidRefund = "Y";
            }
            else
            {
                objOption.FlagSale_HidePaidRefund = "N";
            }

            //******************Start Added on 16-June-2014 for Date Time format*****************************************
            if (cmbDateFormat.SelectedIndex >= 0)
            {
                objOption.FlagDateFormat = cmbDateFormat.SelectedItem.ToString();
            }
            else
            {
                objOption.FlagDateFormat = "yyyy/MM/dd";
            }

            if (ConfigurationSettings.AppSettings["DateFormat"].ToString() != cmbDateFormat.Text)
            {
                if (isRestart == true)
                {
                    GeneralFunction.SetConfigValue("DateFormat", cmbDateFormat.Text);
                }
                else
                {
                    if (GeneralFunction.Question("RestartToChangeDateFormat", "OptionSetting".ToString()) == DialogResult.Yes)
                    {
                        GeneralFunction.SetConfigValue("DateFormat", cmbDateFormat.Text);
                        isRestart = true;
                    }
                    else
                    {
                        cmbDateFormat.Text = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                        isRestart = false;
                    }
                }
            }
            //******************End Added on 16-June-2014 for Date Tim eformat*****************************************

            strValue = "";
            strValue = objOption.OptionDontAskClosingSystem + "|" + objOption.FlagDontAskClosingSystem + "~" + objOption.Option24HourWorkSystem + "|" + objOption.Flag24HourWorkSystem;
            strValue = strValue + "~" + objOption.OptionStopDeptSellings + "|" + objOption.FlagStopDeptSellings + "~" + objOption.OptionHidePackageReport + "|" + objOption.FlagHidePackageReport;
            strValue = strValue + "~" + objOption.OptionShowTipDayWhenStart + "|" + objOption.FlagShowTipDayWhenStart + "~" + objOption.OptionBranchBuyswithCost + "|" + objOption.FlagBranchBuyswithCost;
            strValue = strValue + "~" + objOption.OptionUseItemPhoto + "|" + objOption.FlagUseItemPhoto + "~" + objOption.OptionUseRentingInvoice + "|" + objOption.FlagUseRentingInvoice;
            strValue = strValue + "~" + objOption.OptionDontAlertOnSave + "|" + objOption.FlagDontAlertOnSave + "~" + objOption.OptionDontAlertDeleteItemFromInvoice + "|" + objOption.FlagDontAlertDeleteItemFromInvoice;
            strValue = strValue + "~" + objOption.OptionUnifyOptionForallWorkStations + "|" + objOption.FlagUnifyOptionForallWorkStations + "~" + objOption.OptionRoundPriceOnDiscount + "|" + objOption.FlagRoundPriceOnDiscount;
            strValue = strValue + "~" + objOption.OptionRoundPricesOnDiscountValue + "|" + objOption.FlagRoundPricesOnDiscountValue + "~" + objOption.OptionAlertReorderItemsPerDay + "|" + objOption.FlagAlertReorderItemsPerDay;
            strValue = strValue + "~" + objOption.OptionAlertExpiryPerDay + "|" + objOption.FlagAlertExpiryPerDay + "~" + objOption.OptionAlertPayDatesBefore + "|" + objOption.FlagAlertPayDatesBefore;
            strValue = strValue + "~" + objOption.OptionAlertPayDates + "|" + objOption.FlagAlertPayDates + "~" + objOption.OptionAlertWithSound + "|" + objOption.FlagAlertWithSound;
            strValue = strValue + "~" + objOption.OptionAlertSaleInvoice + "|" + objOption.FlagAlertSaleInvoice + "~" + objOption.OptionHideRentingInvoice + "|" + objOption.FlagHideRentingInvoice;
            strValue = strValue + "~" + objOption.OptionHideKitchenWindow + "|" + objOption.FlagHideKitchenWindow + "~" + objOption.OptionHidePOSShortcut + "|" + objOption.FlagHidePOSShortcut;
            strValue = strValue + "~" + objOption.OptionHidePOSScreen + "|" + objOption.FlagHidePOSScreen + "~" + objOption.OptionSale_HidePaidRefund + "|" + objOption.FlagSale_HidePaidRefund + "~" + objOption.OptionDateFormat + "|" + objOption.FlagDateFormat + "~";
            strValue = strValue + objOption.OptionResetPOSOrder + "|" + objOption.FlagResetPOSOrder + "~" + objOption.OptionPOSOrderResetCount + "|" + objOption.FlagPOSOrderResetCount + "~" + objOption.EnableNetworkSaleControl + "|" + objOption.FlagEnableNetworkSaleControl + "~" + objOption.EnableConfirmEndShift + "|" + objOption.FlagEnableConfirmEndShift + "~" + objOption.EnableOpenNewInvoice + "|" + objOption.FlagEnableOpenNewInvoice + "~";
            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionValue = strValue;
            //SaveEachTabValues(); //Added on 25-Nov-2014 for saving Each Tab Value by Seenivasan
        }
        #endregion

        #endregion

        #region Restore All Tabs


        #region RestoreOption_General
        public void RestoreOption_General()
        {
            //Txt_Companyname.Text = System.Environment.GetEnvironmentVariable("COMPUTERNAME");Commended By Meena.R On 16/10/2014 it show system name 
            Txt_Companyname.Text = string.Empty;
            Txt_Phone.Text = "";
            Txt_Cell.Text = "";
            Txt_Fax.Text = "";
            Txt_POBox.Text = "";
            Txt_Email.Text = "";
            Txt_Address.Text = "";
            Txt_SystemNote.Text = "";
            Txt_WorkNote.Text = "";
            Cmb_Langage.SelectedIndex = 0;
            Chk_HideDiscountWindow.Checked = true;
            Chk_HideWelcomeWindow.Checked = false;
            Chk_HideNoteFiled.Checked = false;
            Chk_ShowCompanyOnInvoice.Checked = false;
            Chk_ShowCompanyNameOnly.Checked = true;
            Chk_AutoStartwithWindow.Checked = false;
        }
        #endregion

        #region RestoreOption_Invoice
        public void RestoreOption_Invoice()
        {
            Chk_Purchase_HideExpiryFiled.Checked = false;
            chkPurchase_HideDevidingDiscountOnItem.Checked = false;
            chkPurchase_AddItemDirectlywithBarcode.Checked = false;
            Chk_TabToPrice.Checked = true;
            chkShowDiscountFiled.Checked = true;
            chkShowHidenItem.Checked = false;
            chkPurchase_SaveUsernameOnInvoice.Checked = true;
            chkHidePriceChangingButton.Checked = true;
            chkSalePriceReadonly.Checked = false;
            Chk_Sale_AddItemDirectlywithBarcode.Checked = false;
            chkOpenInvioceAfterClosing.Checked = false;
            chkSale_HideExpiryFiled.Checked = false;
            chkDevideDiscountBeforeClosingInvoice.Checked = false;
            chkAlterwhenSellingLessthanCost.Checked = true;
            chkShowSubTotalFiled.Checked = false;
            chkShowNonStockItem.Checked = false;
            chkSale_SaveUsernameOnInvoice.Checked = true;
            chkShowInvoiceCostFiled.Checked = false;
            chkDisableDiscountFiled.Checked = false;
            chkSale_HideDevidingDiscountOnItem.Checked = false;
        }
        #endregion

        #region RestoreOption_Print
        public void RestoreOption_Print()
        {
            Cmb_InvoiceTemplate.SelectedIndex = 2;
            Cmb_BarcodePaperSize.SelectedIndex = 0;
            Cmb_BarcodePrinter.SelectedIndex = 0;
            Cmb_PrintingLogo.SelectedIndex = 0;
            Cmb_ItemSorting.SelectedIndex = 2;
            UD_InvoiceCopies.Value = 1;
            UD_ReciptCopies.Value = 1;
            UD_Header.Value = 40;
            UD_Footer.Value = 30;
            Txt_LogoHeader.Text = "";
            Txt_LogoFooter.Text = "";
            //Pic_Footer.Image = null;
            //Pic_Header.Image = null;
            Txt_NoteSaleInvoice.Text = "";
            chkPrintAfterClosingInvoice.Checked = false;
            chkPrintAfterClosingRecipt.Checked = false;
            chkPrintTotalQuantity.Checked = true;
            chkHideDiscountFiledOnPrint.Checked = false;
            chkShowTime.Checked = true;
            chkHideTaxFiled.Checked = true;
            chkHideLogoOnPrint.Checked = false;
            chkHidePeaceBoxInPrint.Checked = true;
            chkShowDeptOnPrint.Checked = false;
            chkIgnoreNonStockItem.Checked = true;
            chkPosCategoryVicePrint.Checked = false;
        }
        #endregion

        #region RestoreOption_Item
        public void RestoreOption_Item()
        {
            UD_AlertExpiry.Value = 4;
            UD_AlertReorderItem.Value = 5;
            UD_IssueOrderInvoice.Value = 6;
            chkAlertForReorders.Checked = true;
            chkDontIssueReorderInvoice.Checked = true;
            chkHideItemSaleTimeInInvoice.Checked = false;
            chkHideItemCostInSales.Checked = true;
            chkHideItemNumber.Checked = true;
            chkDontTabToReorderandMaxpoint.Checked = true;
            chkDontAlertForExpiryInNotes.Checked = false;
            chkQuitWithoutAsking.Checked = false;
            chkSellExpiryWenNotEnough.Checked = true;
            chkAlertForMultiExpiry.Checked = false;
            chkUseExpiryDefaultInItemCard.Checked = false;
            chkHidePackageQuantity.Checked = false;
            chkMonitorReorderAndMaxpoint.Checked = true;
        }
        #endregion

        #region RestoreOption_Employee
        public void RestoreOption_Employee()
        {
            Cmb_CalculateSalary.SelectedIndex = 0;
            Cmb_Holiday.SelectedIndex = 6;
            chkCalculateSalaryFromStartDay.Checked = true;
            chkCutLatencyAutomatically.Checked = false;
            chkCountSalaryFromRegistrationPoint.Checked = true;
            chkCutDeficits.Checked = false;
            chkTrackUsers.Checked = true;
            chkCountSystemStarupMinutes.Checked = true;
            chkCountOverTimeAutomatically.Checked = false;
            chkCountOverTimeForHolidays.Checked = false;
            chkStopEmployeeCalculations.Checked = false;
        }
        #endregion

        #region RestoreOption_Backup
        public void RestoreOption_Backup()
        {
            chkAskWhenLeavingSystem.Checked = true;
            chkAutomaticBackupWhenClosing.Checked = true;
            chkAskWhenReplacingFile.Checked = true;
            chkSaveAutomaticBackupInAlternativePath.Checked = true;
            chkSaveFilenameWithDatetime.Checked = true;
            chkAlertWhenNotMakingBackup.Checked = true;
            UD_AutomaticBackupDays.Value = 4;
            Txt_SaveBackup.Text = "";
            Txt_AlternativePath.Text = "";
            Txt_LastBackupDate.Text = "";
        }
        #endregion

        #region RestoreOption_Peripherals
        public void RestoreOption_Peripherals()
        {
            chkUseCustomerDisplay.Checked = false;
            Txt_FirstLineWelcomeNote.Text = "";
            Txt_SecondLineWelcomeNote.Text = "";
            chkUseCashDrawer.Checked = false;
            rbnDrawerTypeUSP.Checked = false;
            rbnDrawerTypeCOM.Checked = false;
            rbnDrawerTypeRJ11.Checked = true;
            chkDrawerOpenDirectlyAfterPrint.Checked = true;
            chkDrawerProtectWithPassword.Checked = false;
            chkPriceCheckerActive.Checked = false;
            Txt_CashDrawerPassword.Text = "";
            Txt_CashDrawerVerifyPassword.Text = "";
        }
        #endregion

        #region RestoreOption_Tax
        public void RestoreOption_Tax()
        {
            Txt_Tax1_TaxName.Text = "";
            UD_Tax1_Percentage.Value = 0;
            UD_Tax1_SubPercentage.Value = 0;
            Cmb_Tax1_ShowTaxInvoice.SelectedIndex = -1;
            chkTax1_ApplySales.Checked = false;
            chkTax1_ApplyPurchase.Checked = false;
            chkTax1_ApplyMaintains.Checked = false;
            chkTax1_ApplyBeforeDiscount.Checked = false;
            Txt_Tax2_TaxName.Text = "";
            UD_Tax2_Percentage.Value = 0;
            UD_Tax2_SubPercentage.Value = 0;
            Cmb_Tax2_ShowTaxInvoice.SelectedIndex = -1;
            chkTax2_ApplySales.Checked = false;
            chkTax2_ApplyPurchase.Checked = false;
            chkTax2_ApplyMaintains.Checked = false;
            chkTax2_ApplyBeforeDiscount.Checked = false;
        }
        #endregion

        #region RestoreOption_Notification
        public void RestoreOption_Notification()
        {
            Chk_Licenserenewal.Checked = false;
            DTP_LicenserenewalDate.Value = DateTime.Now;
            UD_LicenserenewalNotifyBefore.Value = 30;
            Chk_MedicalInsurance.Checked = false;
            DTP_MedicalInsuranceDate.Value = DateTime.Now;
            UD_MedicalInsuranceNotifyBefore.Value = 30;
            Chk_CertificateofHealth.Checked = false;
            DTP_CertificateofHealthDate.Value = DateTime.Now;
            UD_CertificateofHealthNotifyBefore.Value = 30;
            Chk_AttendancePermit.Checked = false;
            DTP_AttendancePermitDate.Value = DateTime.Now;
            UD_AttendancePermitNotifyBefore.Value = 30;
            Chk_TechnicalDisclosure.Checked = false;
            DTP_TechnicalDisclosureDate.Value = DateTime.Now;
            UD_TechnicalDisclosureNotifyBefore.Value = 30;
            Chk_Pricing.Checked = false;
            DTP_PricingDate.Value = DateTime.Now;
            UD_PricingNotifyBefore.Value = 30;
            Chk_Payrent.Checked = false;
            DTP_PayrentDate.Value = DateTime.Now;
            UD_PayrentNotifyBefore.Value = 30;
            Chk_DisbursementSalary.Checked = false;
            DTP_DisbursementSalaryDate.Value = DateTime.Now;
            UD_DisbursementSalaryNotifyBefore.Value = 30;
            Chk_AnnualInventory.Checked = false;
            DTP_AnnualInventoryDate.Value = DateTime.Now;
            UD_AnnualInventoryNotifyBefore.Value = 30;
            Chk_Zakat.Checked = false;
            DTP_ZakatDate.Value = DateTime.Now;
            UD_ZakatNotifyBefore.Value = 30;
        }

        #endregion

        #region RestoreOption_Other
        public void RestoreOption_Other()
        {
            chkDontAskClosingSystem.Checked = false;
            chk24HourWorkSystem.Checked = false;
            chkStopDeptSellings.Checked = false;
            chkHidePackageReport.Checked = false;
            chkShowTipDayWhenStart.Checked = true;
            chkBranchBuyswithCost.Checked = true;
            chkUseItemPhoto.Checked = false;
            //  chkUseRentingInvoice.Checked = false;
            chkDontAlertOnSave.Checked = false;
            chkDontAlertDeleteItemFromInvoice.Checked = false;
            chkUnifyOptionForallWorkStations.Checked = false;
            Chk_RoundPriceOnDiscount.Checked = true;
            Cmb_RoundPricesOnDiscountValue.SelectedIndex = 0;
            UD_AlertReorderItemsPerDay.Value = 0;
            UD_AlertExpiryPerDay.Value = 0;
            UD_AlertPayDatesBefore.Value = 0;
            chkAlertPayDates.Checked = false;
            chkAlertWithSound.Checked = false;
            chkAlertSaleInvoice.Checked = false;
            // chkHideRentingInvoice.Checked = true;
            // chkHideKitchenWindow.Checked = true;
            chkHidePOSScreen.Checked = true;
            chkHidePOSShortcut.Checked = true;

        }

        #endregion





        #endregion

        #region PeripheralsValidation
        private bool PeripheralsValidation()
        {

            if (chkUseCashDrawer.Checked && !rbnDrawerTypeCOM.Checked && !rbnDrawerTypeRJ11.Checked && !rbnDrawerTypeUSP.Checked)
            {
                GeneralFunction.Information(("SelectCashDrawerType"), "OptionSetting".ToString());
                return false;
            }
            else if (chkDrawerProtectWithPassword.Checked && string.Compare(Txt_CashDrawerPassword.Text.Trim(), Txt_CashDrawerVerifyPassword.Text.Trim()) != 0)
            {
                GeneralFunction.Information(("PasswordMismatched"), "OptionSetting".ToString());
                Txt_CashDrawerPassword.Text = string.Empty;
                Txt_CashDrawerVerifyPassword.Text = string.Empty;
                Txt_CashDrawerPassword.Focus();
                return false;
            }
            else { return true; }


        }
        #endregion

        #region LoadUserGroup

        private void LoadUserGroup()
        {
            cmbUserGroup.SelectedIndexChanged -= new EventHandler(cmbUserGroup_SelectedIndexChanged);
            List<EmployeeObjectClass> lstUserGroup = objOptionSettingHelper.AddDefaultDataHelper();
            cmbUserGroup.DisplayMember = "UserGroupName";
            cmbUserGroup.ValueMember = "UserGrpId";
            cmbUserGroup.DataSource = lstUserGroup;
            cmbUserGroup.SelectedValue = GeneralFunction.UserGroupID;
            objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.UserGroupID = GeneralFunction.UserGroupID;
            cmbUserGroup.SelectedIndexChanged += new EventHandler(cmbUserGroup_SelectedIndexChanged);
            cmbUserGroup.SelectedValue = 101;
        }

        #endregion

        private void btnCleanDB_Click(object sender, EventArgs e)
        {
            try
            {
                Clear_DataBase_Information Frm_clear_items_from_system = new Clear_DataBase_Information();
                if (Frm_clear_items_from_system.ShowDialog() == DialogResult.OK)
                {
                    if ((Frm_clear_items_from_system.cleandboption == "rbnDeleteAll") || ((Frm_clear_items_from_system.cleandboption == "rbnKeepdata") && (Frm_clear_items_from_system.KeepUserInfo != 1)))
                    {
                        GeneralFunction.isApplnRestart = true;
                        //  GeneralFunction.SetConfigValue("Restart", "True");
                        Application.Restart();
                    }
                    else
                    {
                        GeneralFunction.GetOptionDatas();
                        GeneralFunction.NoofReceiptPrint = int.Parse(GeneralOptionSetting.FlagReciptCopies == string.Empty || GeneralOptionSetting.FlagReciptCopies == "0" ? "1" : GeneralOptionSetting.FlagReciptCopies);
                        GeneralFunction.NoofPrint = int.Parse(GeneralOptionSetting.FlagInvoiceCopies == string.Empty || GeneralOptionSetting.FlagInvoiceCopies == "0" ? "1" : GeneralOptionSetting.FlagInvoiceCopies);
                        //MasterDataBALClass ObjMasterDataBALClass = new MasterDataBALClass();this lines are Commended by Meena.R on 17/07/2014 
                        //GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
                        //GeneralObjectClass.BankList = ObjMasterDataBALClass.GetBankDetailsBal();
                        //GeneralObjectClass.BranchList = ObjMasterDataBALClass.BranchDetailsBal();
                        //GeneralObjectClass.CategoryList = ObjMasterDataBALClass.GetCategoryDetailsBal();
                        //GeneralObjectClass.CompanyList = ObjMasterDataBALClass.GetCompanyDetailsBal();
                        //GeneralObjectClass.ItemDetails = ObjMasterDataBALClass.ItemDetailsBal();
                        //GeneralObjectClass.UserList = ObjMasterDataBALClass.UserDetailsBal();
                        //GeneralObjectClass.UserGroupList = ObjMasterDataBALClass.UserGroupDetailsBal();
                        //GeneralObjectClass.DefaultUnitName = ObjMasterDataBALClass.GetItemUnitName();
                        MasterFrom frm = new MasterFrom();
                        frm.isFromCleanDB = true;
                        //frm.CleanDBReload();
                        //frm.ExpiryMessage();
                        ////frm.AppentNotes();
                        //frm.ResetScrollNotes = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control ctrl in this.CtrlTab_OptionSetting.Controls)
                {
                    if (ctrl is TabPage)
                    {
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                        foreach (Control ctl in ctrl.Controls)
                        {
                            if (ctl is GroupBox)
                            {
                                ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                foreach (Control con in ctl.Controls)
                                {
                                    if (con is Button || con is RadioButton || con is CheckBox || con is Label)
                                        con.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    else if (con is GroupBox)
                                    {
                                        con.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                        foreach (Control ct in con.Controls)
                                        {
                                            if (ct is Button || ct is RadioButton || ct is CheckBox || ct is Label)
                                                ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                        }

                                    }
                                }
                            }
                            else if (ctl is Button || ctl is RadioButton || ctl is CheckBox || ctl is Label)
                                ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);

                        }
                    }
                }
                foreach (Control control in this.Controls)
                {
                    if (control is Button || control is RadioButton || control is CheckBox || control is Label)
                        control.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

        #endregion

        private void btnAddedQuantity_Click(object sender, EventArgs e)
        {
            DB_Login ObjFrm = new DB_Login();
            ObjFrm.Text = Additional_Barcode.GetValueByResourceKey("AddRandomQuantity");
            ObjFrm.Tag = "Clean DB";
            if (GeneralFunction.Question("Doyouwanttoaddrandomquantitytotheitems", "OptionSetting") == DialogResult.Yes)
            {
                if (ObjFrm.ShowDialog() == DialogResult.Cancel) return;

                if (objOptionSettingHelper.AddedQuantities())
                {
                    GeneralFunction.Information("ItemQuantityUpdateSuccessfully", "OptionSetting");
                }
                else
                {

                }
            }
        }

        private void CtrlTab_OptionSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CtrlTab_OptionSetting.SelectedTab == Tab_General)
            {
                Txt_Companyname.Focus();
            }
        }

        private void Option_Seeting_Paint(object sender, PaintEventArgs e)
        {

            //For focusing the Company name textbox when open the first time done by PRaba on 28Oct
            if (CtrlTab_OptionSetting.SelectedTab == Tab_General && Loaded == true)
            {
                Txt_Companyname.Focus();
                Loaded = false;
            }
        }

        private void Tab_Tax_Click(object sender, EventArgs e)
        {

        }

        private void Option_Seeting_FormClosed(object sender, FormClosedEventArgs e)
        {
            //objOptionSettingHelper = null;
            //objOption = null;
            rkApp = null;
            //objOptionSettingHelper.lstOptions = null;
            //objOptionSettingHelper.lstLogo = null;
            this.Dispose();
        }

        /// <summary>
        /// Created on 25-Nov-2014 by Seenivasan to save All the tab control values on Apply Click
        /// </summary>
        private void SaveEachTabValues()
        {
            try
            {
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.HeaderLogo = Txt_LogoHeader.Text == string.Empty && Pic_Header.Image != null ? GeneralOptionSetting.HeaderLogo : objOptionSettingHelper.PathtoByte(Txt_LogoHeader.Text);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.FooterLogo = Txt_LogoFooter.Text == string.Empty && Pic_Footer.Image != null ? GeneralOptionSetting.FooterLogo : objOptionSettingHelper.PathtoByte(Txt_LogoFooter.Text);
                objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.UserId = GeneralFunction.UserId;
                objOptionSettingHelper.SaveOptionSettingDet();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import objimport = new Import();
            objimport.ShowDialog();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.Question("Doyouwanttoexportitems", "OptionSetting") == DialogResult.Yes)
                {
                    DB_Login dblog = new DB_Login();
                    if ((dblog.ShowDialog() == DialogResult.Cancel))
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                    else
                    {
                        //this.Cursor = Cursors.WaitCursor;
                        ExportItems();
                        //this.Cursor = Cursors.Arrow;
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Option Settings", "btnExport_Click");
            }
        }

        public void ExportItems()
        {
            DataTable dt = new DataTable();
            dt = objOptionSettingHelper.objOptionSettingsBAl.GetAllItems();
            if (dt != null && dt.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:/";
                saveFileDialog1.Title = "Save Results";
                saveFileDialog1.Filter = "Microsoft Office Excel Wookbook|.xlsx";
                saveFileDialog1.FileName = "ItemDetails";
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add();
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];
                    Microsoft.Office.Interop.Excel._Worksheet workSheet = application.ActiveSheet;
                    Font f = new Font("Simplified Arabic", 13.0f);
                    application.StandardFont = "Simplified Arabic";
                    application.StandardFontSize = 13.0f;
                    worksheet.Cells[1, 1] = "رقم";
                    worksheet.Cells[1, 2] = "اسم الصنف";
                    worksheet.Cells[1, 3] = "رقم الصنف";
                    worksheet.Cells[1, 4] = "باركود";
                    worksheet.Cells[1, 5] = "اسم المجموعة";
                    worksheet.Cells[1, 6] = "نوع الصنف";
                    worksheet.Cells[1, 7] = "مكان الصنف";
                    worksheet.Cells[1, 8] = "البيان";
                    worksheet.Cells[1, 9] = "اسم الشركة";
                    worksheet.Cells[1, 10] = "سعر الشراء";
                    worksheet.Cells[1, 11] = "العدد بالعبوة";
                    worksheet.Cells[1, 12] = "الصلاحية";
                    worksheet.Cells[1, 13] = "سعر البيع";
                    worksheet.Cells[1, 14] = "سعر بيع الجملة";
                    worksheet.Cells[1, 15] = "اقل سعر";
                    worksheet.Rows[1].Font.Bold = true;
                    //worksheet.Rows[1].Interior.Color = Color.SkyBlue;
                    //worksheet.Cells[1, 2].Interior.Color = Color.AntiqueWhite;
                    //worksheet.Cells[1, 5].Interior.Color = Color.AntiqueWhite;
                    ////worksheet.Cells[1, 4].Interior.Color = Color.AntiqueWhite;
                    //worksheet.Cells[1, 6].Interior.Color = Color.AntiqueWhite;
                    worksheet.Columns[2].ColumnWidth = 20;
                    worksheet.Columns[3].ColumnWidth = 20;
                    worksheet.Columns[4].ColumnWidth = 20;
                    worksheet.Cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[2].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[3].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    for (int i = 5; i <= 23; i++)
                    {
                        worksheet.Columns[i].ColumnWidth = 18;
                    }

                    Microsoft.Office.Interop.Excel.Range top = worksheet.Cells[2, 1];
                    Microsoft.Office.Interop.Excel.Range Bottom = worksheet.Cells[20249, 15];
                    Microsoft.Office.Interop.Excel.Range all = (Microsoft.Office.Interop.Excel.Range)worksheet.get_Range(top, Bottom);
                    string[,] arraydt = new string[dt.Rows.Count, dt.Columns.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                        for (int j = 0; j < dt.Columns.Count; j++)
                            arraydt[i, j] = dt.Rows[i][j].ToString();
                    all.Value2 = arraydt;



                    //    for (int i = 0; i < dt.Columns.Count; i++)
                    //    {
                    //        workSheet.Cells[1, (i + 1)] = dt.Columns[i].ColumnName;
                    //        if (dt.Columns[i].ColumnName.Trim().ToLower() == "باركود".Trim().ToLower())
                    //        {
                    //            workSheet.Cells[1, (i + 1)].EntireColumn.NumberFormat = "#######";
                    //            workSheet.Cells[1, (i + 1)].ColumnWidth = 15.0f;
                    //        }
                    //        if (dt.Columns[i].ColumnName.Trim().ToLower() == "سعر الشراء".Trim().ToLower() || dt.Columns[i].ColumnName.Trim().ToLower() == "سعر البيع".Trim().ToLower() || dt.Columns[i].ColumnName.Trim().ToLower() == "سعر بيع الجملة".Trim().ToLower() || dt.Columns[i].ColumnName.Trim().ToLower() == "اقل سعر".Trim().ToLower())
                    //        {
                    //            workSheet.Cells[1, (i + 1)].EntireColumn.NumberFormat = "#####0.00";
                    //        }
                    //        workSheet.Cells[1, (i + 1)].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    //        workSheet.Cells[1, (i + 1)].Font.Bold = true;
                    //    }
                    //    workSheet.Cells[1, 2].ColumnWidth = 25.0f;
                    //    for (int i = 0; i < dt.Rows.Count; i++)
                    //    {
                    //        for (int j = 0; j < dt.Columns.Count; j++)
                    //        {
                    //            workSheet.Cells[(i + 2), (j + 1)] = dt.Rows[i][j];
                    //        }
                    //    }
                    if (saveFileDialog1.FileName != null && saveFileDialog1.FileName != "")
                    {
                        workSheet.SaveAs(saveFileDialog1.FileName);
                        application.Quit();
                    }
                    GeneralFunction.Information("Itemsexportedsuccessfully", "OptionSetting");
                    this.Cursor = Cursors.Arrow;
                }
                saveFileDialog1.Dispose();
                saveFileDialog1 = null;
            }
            else
            { GeneralFunction.Information("NoDatetoExport", ActionType.Save.ToString()); }
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtResetPOSOrderCount.SelectedText == "" || !char.IsDigit(e.KeyChar))
            {
                if ((!char.IsDigit(e.KeyChar) || txtResetPOSOrderCount.Text.Length > 2) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void txtCount_Leave(object sender, EventArgs e)
        {
            if (txtResetPOSOrderCount.Text == string.Empty || Convert.ToInt32(txtResetPOSOrderCount.Text) <= 0)
                txtResetPOSOrderCount.Text = "100";
        }

        private void rbnDrawerTypeCOM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnDrawerTypeCOM.Checked)
            {
                CashDrawerSetting COMPortSetting = new CashDrawerSetting();
                COMPortSetting.ShowDialog();
            }
        }

        private void ckhAutoItemPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (ckhAutoItemPrice.Checked)
            {
                txtAutoItemPrice.Enabled = true;
                txtAutoItemPrice.Text = "0";
            }
            else
            {
                txtAutoItemPrice.Text = "";
                txtAutoItemPrice.Enabled = false;
            }
        }

        private void txtAutoItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((char.IsControl(e.KeyChar) == false) && (e.KeyChar != '.') && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                    e.Handled = true;
                }
                if ((e.KeyChar == 46) & (txtAutoItemPrice.Text.Contains(".") == true))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Option Item", "txtAutoItemPrice_KeyPress");
            }
        }

        private void chkSaleDontUseExpiry_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            PaymentTypesCharges form = new PaymentTypesCharges();
            form.ShowDialog();
        }

        private void Chk_ShowCompanyOnInvoice_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UD_Header_Leave(object sender, EventArgs e)
        {
            if (UD_Header.Value < 10)
            {
                GeneralFunction.Information("MinimumValue", "OptionSetting");
                UD_Header.Value = 10;
            }
        }

        private void UD_Footer_Leave(object sender, EventArgs e)
        {
            if (UD_Footer.Value < 10)
            {
                GeneralFunction.Information("MinimumValue", "OptionSetting");
                UD_Footer.Value = 10;
            }
        }

        private void btnPrinters_Click(object sender, EventArgs e)
        {
            PrinterSetup ps = new PrinterSetup();
            ps.ShowDialog();
        }

        private void Option_Seeting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Option_Seeting_KeyDown");
            }
        }

        private void txtBarcodeSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
            {
                GeneralFunction.Information("OnlyNumbersAllowed", "Sales Invoice");
                e.Handled = true;
            }
        }

        private void txtBarcodeSize_Leave(object sender, EventArgs e)
        {
            int Number = string.IsNullOrEmpty(txtBarcodeSize.Text) ? 0 : Convert.ToInt32(txtBarcodeSize.Text);
            if (Number < 75)
            {
                txtBarcodeSize.Text = "75";
            }
            else if (Number > 120)
            {
                txtBarcodeSize.Text = "120";
            }
        }
    }
}