using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;

namespace BBM_LicensceGenerator
{

    /// <summary>
    /// This form is used for authenticate the admin user to generate the license Key and Data migration done by Praba on 06-Jun-2014
    /// </summary>
    public partial class frmUserLogin : Form
    {

        private RegistryKey _objRegistry = Registry.LocalMachine;
        private string _currentPassword = string.Empty;

        public frmUserLogin()
        {
            InitializeComponent();
            this.Height = 255;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }


        void InitialLoad()
        {
            RegistryKey objKey = null;
            try
            {
                objKey = _objRegistry.OpenSubKey(@"SOFTWARE\ODBC\WAMPD");
                if (objKey == null)
                { _objRegistry.CreateSubKey(@"SOFTWARE\ODBC\WAMPD"); WritePwdToRegistry("admin"); }
                else _currentPassword = Decrypt(objKey.GetValue("").ToString());
            }
            catch (Exception ex) { MessageBox.Show("ErrOccured: \n\r" + ex.Message); }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtUserName.Text == "admin" && txtPassword.Text == _currentPassword)
                 {
                            this.Hide();
                            frmOptionSelection objOptionSel = new frmOptionSelection();
                            objOptionSel.Show();
                 }
                 else
                {
                    MessageBox.Show("Please enter the valid User Name / Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            InitialLoad();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);

            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

       
    }
}
