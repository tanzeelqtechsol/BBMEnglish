using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
//using HSB_ObjectHelper;


namespace BBM_LicensceGenerator
{
    public partial class LicenceGen : Form
    {
        LicensenceValidator _licValidator;
        private RegistryKey _objRegistry = Registry.LocalMachine;
        private string _currentPassword = string.Empty;
        private string formMode = "";

        public LicenceGen(string Mode)
        {
            InitializeComponent();
            _licValidator = new LicensenceValidator();
            formMode = Mode;
        }

        private string Decrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            string Password = "CSC";
            string DecryptedData;

            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);

                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }
            return DecryptedData;
        }

        private string Encrypt(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "CSC";
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);

            return EncryptedData;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string month = string.Empty;
            string UserKeyText = string.Empty;
            decimal m=0;
            if (!string.IsNullOrEmpty(txtUserKey.Text))
            {
               // UserKeyText = KeyDecrypt(txtUserKey.Text);
                UserKeyText = txtUserKey.Text; //KeyDecrypt(txtUserKey.Text);
                 if (string.IsNullOrEmpty(txtMonth.Text))
                 {
                     m = 0;
                 }
                 else
                 {
                     try
                     {                       
                         m = Convert.ToDecimal(txtMonth.Text);
                     }
                     catch (Exception ex)
                     {
                        MessageBox.Show("Please give valid Trial period. ");
                        return;
                     }
                     if (m > 12)
                         m = 12;                   
                 }
                 month = m.ToString();
                 month = month.Length > 1 ? month : "0" + month;
               
                //Add by thamil for Licence implementation On 3-March-2017
                 string[] str = UserKeyText.Split('-');
                if (str.Length != 2)
                {
                    MessageBox.Show("Activation key is Invalid. ");
                    return;
                }
                //txtUserSerialNo.Text = KeyEncrypt(_licValidator.GenerateSerialKey(UserKeyText, Convert.ToInt32(rbtnServer.Checked), month));

                txtUserSerialNo.Text = _licValidator.GenerateSerialKey(UserKeyText, Convert.ToInt32(rbtnServer.Checked), month);


            }
            else
            {
                MessageBox.Show("Activation key is empty. ");
            }
        }

        private void btnUserSerialCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, txtUserSerialNo.Text);
        }

        private void btnCance_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            PerformAction(((Button)sender).Name.Replace("btn", string.Empty));
        }

        void PerformAction(string option)
        {
            switch (option)
            {

                //Login Panel
                case "Login":
                    if (txtUserName.Text == "admin" && txtPassword.Text == _currentPassword)
                    {
                        pnlGenerateCode.BringToFront();
                        pnlGenerateCode.Visible = pnlGenerateCode.Enabled = true;
                        pnlLogin.SendToBack();
                        pnlChangePwd.SendToBack();
                    }
                    else MessageBox.Show("Invalid Password!!");
                    break;
                case "ChangePwd":
                    pnlGenerateCode.SendToBack();
                    pnlLogin.SendToBack();
                    pnlLogin.Visible = pnlLogin.Enabled = false;
                    pnlChangePwd.Visible = pnlChangePwd.Enabled = true;
                    pnlChangePwd.BringToFront();
                    txtOldPassword.Focus();
                    break;

                case "Exit":
                    Application.Exit();
                    break;

                // ChangePassword Panel
                case "ChangeUserPwd":
                    ChangePassword();
                    break;
                case "CancelChangePwd":
                    //pnlGenerateCode.SendToBack();
                    //pnlChangePwd.SendToBack();
                    //pnlChangePwd.Visible = pnlChangePwd.Enabled = false;
                    //pnlLogin.Visible = pnlLogin.Enabled = true ;
                    //pnlLogin.BringToFront();
                    //txtPassword.Focus();

                    this.Hide();
                    frmUserLogin frmUser = new frmUserLogin();
                    frmUser.Show();
                    break;

            }
        }

        private void LicenceGen_Load(object sender, EventArgs e)
        {
            InitialLoad(formMode);
        }

        //Based on form Mode the screen will appear done by Praba on 06-Jun-2014
        void InitialLoad(string formMode)
        {
            RegistryKey objKey = null;
            try
            {

                objKey = _objRegistry.OpenSubKey(@"SOFTWARE\ODBC\WAMPD");
                if (objKey == null)
                {
                    _objRegistry.CreateSubKey(@"SOFTWARE\ODBC\WAMPD"); WritePwdToRegistry("admin");
                }

                else _currentPassword = Decrypt(objKey.GetValue("").ToString());

                switch (formMode)
                {

                    case "ChangePwd":
                        pnlGenerateCode.SendToBack();
                        pnlLogin.SendToBack();
                        pnlLogin.Visible = pnlLogin.Enabled = false;
                        pnlChangePwd.Visible = pnlChangePwd.Enabled = true;
                        pnlChangePwd.BringToFront();
                        txtOldPassword.Focus();
                        break;

                    case "GenerateLicense":

                        pnlLogin.BringToFront();
                        pnlLogin.Visible = pnlLogin.Enabled = true;
                        pnlGenerateCode.SendToBack();
                        pnlChangePwd.SendToBack();

                        // New Code for Data Migration done by Praba on 06-Jun-2014
                        pnlGenerateCode.BringToFront();
                        pnlGenerateCode.Visible = pnlGenerateCode.Enabled = true;
                        pnlLogin.SendToBack();
                        pnlChangePwd.SendToBack();
                        break;

                }

            }
            catch (Exception ex) {

                if (ex.Message.Contains("WAMPD") || ex.Message.Contains("ODBC"))
                {
                MessageBox.Show("Application not Register");
                Application.Exit();
                }
                else
                {
                    MessageBox.Show("ErrOccured: \n\r" + ex.Message);
                }
            }
            finally { objKey = null; }

        }

        void WritePwdToRegistry(string _password)
        {
            RegistryKey objKey = null;
            try
            {
                objKey = _objRegistry.OpenSubKey(@"SOFTWARE\ODBC\WAMPD", true);
                objKey.SetValue("", Encrypt(_password));
                _currentPassword = Decrypt(objKey.GetValue("").ToString());
            }
            catch (Exception ex) { MessageBox.Show("Err Occured: \n\r" + ex.Message); }
            finally { objKey = null; }
        }

        void ChangePassword()
        {

            if (string.IsNullOrEmpty(txtOldPassword.Text))
            { MessageBox.Show("Old Password is empty"); txtOldPassword.Focus(); return; }

            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            { MessageBox.Show("New Password is empty"); txtNewPassword.Focus(); return; }

            else if (string.IsNullOrEmpty(txtConfrimPassword.Text))
            { MessageBox.Show("Confirm Password is empty"); txtConfrimPassword.Focus(); return; }

            if (txtOldPassword.Text == _currentPassword)
            {
                if (txtNewPassword.Text == txtConfrimPassword.Text)
                {
                    WritePwdToRegistry(txtNewPassword.Text);
                    PerformAction("CancelChangePwd");
                }
                else MessageBox.Show("Password confirmation failed.");
            }
            else MessageBox.Show("Old Password is wrong!!");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) PerformAction("Login");
        }

        private void txtUserKey_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserKey.Text))
            {
                string UserKeyText = KeyDecrypt(txtUserKey.Text);
                string[] str = UserKeyText.Split('-');
                if (str.Length == 2)
                {
                    string converterstring = str[1];
                    string isserver =converterstring.Substring(0,1);
                    if (isserver == "1")
                        rbtnServer.Checked = true;
                    else
                        rbtnNode.Checked = true;
                }
            }

        }      

        private void chkTrial_CheckedChanged(object sender, EventArgs e)
        {
            txtMonth.Enabled = chkTrial.Checked;
        }

        #region "Encryption and Decryption"

        private string KeyDecrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            string Password = "PTLIndia";
            string DecryptedData;

            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);

                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }
            return DecryptedData;
        }

        private string KeyEncrypt(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "PTLIndia";
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);

            return EncryptedData;
        }

        #endregion

      
    }
}