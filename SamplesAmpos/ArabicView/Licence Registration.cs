using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using Microsoft.Win32;
using CommonHelper;
using BumedianBM.ViewHelper;

namespace BumedianBM.ArabicView
{
    public partial class Licence_Registration : Form, IDisposable
    {
        private LicensenceObjectClass objLicenceValidator;
        EmployeeHelper objemphelper = new EmployeeHelper();
        public int trialDays =1;

        public Licence_Registration()
        {
            InitializeComponent();
            objLicenceValidator = new LicensenceObjectClass();
            SetLanguage();
        }

        #region "Private Members"
        private void SetLanguage()
        {

            this.Text = Additional_Barcode.GetValueByResourceKey(this.Tag.ToString());
            lblAboutDesc.Text = Additional_Barcode.GetValueByResourceKey(lblAboutDesc.Tag.ToString());

            lblWarning.Text = Additional_Barcode.GetValueByResourceKey(lblWarning.Tag.ToString());
            lblRegistered.Text = Additional_Barcode.GetValueByResourceKey(lblRegistered.Tag.ToString());
            lblCompanyName.Text = Additional_Barcode.GetValueByResourceKey(lblCompanyName.Tag.ToString());
            lblSerialNo.Text = Additional_Barcode.GetValueByResourceKey(lblSerialNo.Tag.ToString());
            lblActivationKey.Text = Additional_Barcode.GetValueByResourceKey(lblActivationKey.Tag.ToString());
            btnRegister.Text = Additional_Barcode.GetValueByResourceKey(btnRegister.Tag.ToString());
            btnActivationCopy.Text = Additional_Barcode.GetValueByResourceKey(btnActivationCopy.Tag.ToString());
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey(btnCancel.Tag.ToString());
            lbl_address.Text = Additional_Barcode.GetValueByResourceKey(lbl_address.Tag.ToString());
            lbl_InformationContact.Text = Additional_Barcode.GetValueByResourceKey(lbl_InformationContact.Tag.ToString());
            lbl_TechSupport.Text = Additional_Barcode.GetValueByResourceKey(lbl_TechSupport.Tag.ToString());
          //  lbl_MaintenanceCenter.Text = Additional_Barcode.GetValueByResourceKey(lbl_MaintenanceCenter.Tag.ToString());
            lbl_Email.Text = Additional_Barcode.GetValueByResourceKey(lbl_Email.Tag.ToString());
          //  lblAboutCompany.Text = Additional_Barcode.GetValueByResourceKey(lblAboutCompany.Tag.ToString());
            lblInformationDetails.Text = Additional_Barcode.GetValueByResourceKey(lblInformationDetails.Tag.ToString());
            lblAddressDetails.Text = Additional_Barcode.GetValueByResourceKey(lblAddressDetails.Tag.ToString());
            lblRegistrationDate.Text = Additional_Barcode.GetValueByResourceKey("RegistrationDate");
            btnContinue.Text = Additional_Barcode.GetValueByResourceKey(btnContinue.Tag.ToString());
        }

        void GetSysNumber()
        {

            string tempcode;
            //  string str;
            tempcode = objLicenceValidator.GenerateActivationKey();
           // txtActivationKey.Text = GeneralFunction.Encrypt(tempcode); 
             txtActivationKey.Text = tempcode; // AS per Hisham(Client) Request, changed from Encrypted Key to normal one done by Praba on  21-Jun-2017
        }

        #endregion



        #region "Events"



        #region"Button Click Events"

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult = (this.Tag.ToString() == "Expired") ? DialogResult.Cancel : DialogResult.No;
            System.Environment.Exit(1);
        }

        private void lblRegEmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + "almaqarpos@gmail.coms");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string SerialNoText = string.Empty;
            if (this.Tag.ToString() == "Original" || string.IsNullOrEmpty(txtSerialNo.Text)) 
                return;

            // SerialNoText = GeneralFunction.Decrypt(txtSerialNo.Text);
            if (checkAgree.Checked)
            {
                SerialNoText = txtSerialNo.Text; //GeneralFunction.Decrypt(txtSerialNo.Text);

                string[] str = SerialNoText.Split('-');
                if (str.Length != 2)
                    return;

                string TrialMonth = str[1].Substring(1, 2);
                string SerialNo = str[1].Remove(1, 2);
                SerialNo = str[0] + "-" + SerialNo;

                if (objLicenceValidator.ValidateSerialKey(SerialNo))
                {
                    RegistryKey _regkey = Registry.LocalMachine;
                    _regkey = _regkey.OpenSubKey(GeneralFunction.RegEditPath, true);
                    string OldserialNO = GeneralFunction.Decrypt(_regkey.GetValue("SERIALKEY").ToString());
                    string LicenseStatus = GeneralFunction.Decrypt(_regkey.GetValue("ISTRIAL").ToString());

                    if (SerialNo == OldserialNO && LicenseStatus != "NO")
                    {
                        GeneralFunction.Information("SerialKeyExist", ActionType.Information.ToString());
                        return;
                    }

                    DataTable dtStation = new DataTable();
                    dtStation = objemphelper.Check_WorkStation();


                    string appLicenseStatus = string.Empty;
                    if (TrialMonth == "00")
                    {
                        appLicenseStatus = GeneralFunction.Encrypt("NO");
                    }
                    else
                    {
                        int i = Convert.ToInt32(TrialMonth);
                        DateTime dt = DateTime.Now.AddDays(i);
                        string strDate = GeneralFunction.Encrypt(string.Format("{0}/{1}/{2}", dt.Year.ToString(), dt.Month.ToString(), dt.Day.ToString()));
                        _regkey.SetValue("DATE", strDate);
                        appLicenseStatus = GeneralFunction.Encrypt("YES");
                    }
                    _regkey.SetValue("ISTRIAL", appLicenseStatus);
                    string serialNO = GeneralFunction.Encrypt(SerialNoText);
                    _regkey.SetValue("SERIALKEY", serialNO);
                    GeneralFunction.Information("RegisteredSuccess", "Licence Registration");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    GeneralFunction.Information("Registration failed please enter the valid activation key and serial number", "Licence Registration");
                }
            }
            else
            {
               MessageBox.Show("يرجى التحقق من اتفاقية الترخيص");
                return;
            }
        }

        private void btnActivationCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtActivationKey.Text);
        }

        #endregion



        #endregion

        private void Licence_Registration_Copy_Load(object sender, EventArgs e)
        {

            try
            {
                richTextAgreement.Rtf = Properties.Resources.CDT_Content_End_User_License;
                richTextAgreement.SelectionAlignment = HorizontalAlignment.Center;

                RegistryKey _regkey = Registry.LocalMachine;
                _regkey = _regkey.OpenSubKey(GeneralFunction.RegEditPath, true);

                if (trialDays == 0)
                {
                    btnContinue.Enabled = false;
                }

                if (this.Tag.ToString() == "Original")
                {
                    lblWarning.Visible = false;
                    lblRegistered.Location = new Point(lblRegistered.Location.X, 65);
                    lblRegistered.BackColor = Color.DarkGreen;
                    lblRegistered.ForeColor = Color.WhiteSmoke;
                    txtCompanyName.Text = GeneralOptionSetting.FlagCompanyName;
                    txtCompanyName.Enabled = txtActivationKey.Enabled = txtSerialNo.Enabled = false;
                    string cdate = GeneralFunction.Decrypt(_regkey.GetValue("CDATE").ToString());
                    txtRegistrationDate.Text = cdate;//original version date
                }
                else
                {
                    GetSysNumber();
                    string cdate = GeneralFunction.Decrypt(_regkey.GetValue("DATE").ToString());
                    txtRegistrationDate.Text = cdate;//evaluvation date
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Licence_Registration_Copy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (trialDays != 0)
            {
                this.DialogResult = (this.Tag.ToString() == "Expired") ? DialogResult.Cancel : DialogResult.No;
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = (this.Tag.ToString() == "Expired") ? DialogResult.Cancel : DialogResult.No;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkAgree_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}