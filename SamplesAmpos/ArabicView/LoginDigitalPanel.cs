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

namespace BumedianBM.ArabicView
{
    public partial class LoginDigitalPanel : Form
    {

        #region Declaration

        int intCaps = 0;
        LoginObjectClass objLogin;
        bool UserFocused = true;
        bool PasswrdFocused = false;
        #endregion

        #region Constructor

        public LoginDigitalPanel()
        {
            InitializeComponent();
            objLogin = new LoginObjectClass();
            SetLanguage();
        }

        #endregion

        #region Events

        #region Button Click Events

        #region btn_Click

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                string strKeyValue = string.Empty;
                Button btn = new Button();
                btn = (Button)sender;
                strKeyValue = btn.Tag.ToString();
                if (lblCapsLockStatus.Tag.ToString() == "2")
                {
                    if (UserFocused == true)
                    {
                        txtUserName.Text = txtUserName.Text + strKeyValue.ToUpper();
                    }
                    else if (PasswrdFocused == true)
                    {
                        txtPassword.Text = txtPassword.Text + strKeyValue.ToUpper();
                    }
                }
                else if (lblCapsLockStatus.Tag.ToString() == "1")
                {
                    if (UserFocused == true)
                    {
                        txtUserName.Text = txtUserName.Text + strKeyValue;
                    }
                    else if (PasswrdFocused == true)
                    {
                        txtPassword.Text = txtPassword.Text + strKeyValue;
                    }
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btn_Click");

            }
        }

        #endregion

        #region btnEsc_Click
        private void btnEsc_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnEsc_Click");

            }
        }
        #endregion

        #region btnBackSpace_Click
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int TextLength = 0;

                if (UserFocused == true)
                {
                    TextLength = txtUserName.Text.Length;
                    if (TextLength != 0)
                    {
                        txtUserName.Text = txtUserName.Text.Remove(TextLength - 1, 1);
                    }
                }
                else if (PasswrdFocused == true)
                {
                    TextLength = txtPassword.Text.Length;
                    if (TextLength != 0)
                    {
                        txtPassword.Text = txtPassword.Text.Remove(TextLength - 1, 1);
                    }

                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnBackSpace_Click");

            }
        }
        #endregion

        #region btnCaps_Click
        private void btnCaps_Click(object sender, EventArgs e)
        {
            try
            {
                intCaps = intCaps + 1;
                lblCapsLockStatus.Tag = 1;
                if (intCaps == 2)
                {
                    lblCapsLockStatus.Text = " ";
                    lblCapsLockStatus.Tag = 1;
                    intCaps = 0;
                }
                else if (intCaps == 1)
                {
                    lblCapsLockStatus.Text = "CAPSLOCK ON";
                    lblCapsLockStatus.Tag = 2;
                    intCaps = 1;
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnCaps_Click");

            }
        }
        #endregion

        #region btnEnter_Click
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.DigiUserName = txtUserName.Text;
                GeneralFunction.DigiPassword = txtPassword.Text;
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnEnter_Click");

            }
        }
        #endregion

        #region btnSpace_Click
        private void btnSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserFocused == true)
                {
                    txtUserName.Text = txtUserName.Text + " ";
                }
                else if (PasswrdFocused == true)
                {
                    txtPassword.Text = txtPassword.Text + " ";
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnSpace_Click");

            }
        }
        #endregion




        #endregion

        #region Mouse Up Events

        #region txtUserName_MouseUp
        private void txtUserName_MouseUp(object sender, MouseEventArgs e)
        {
            UserFocused = true;
            PasswrdFocused = false;
        }
        #endregion

        #region txtPassword_MouseUp
        private void txtPassword_MouseUp(object sender, MouseEventArgs e)
        {
            UserFocused = false;
            PasswrdFocused = true;
        }
        #endregion

        #endregion

        #endregion

        #region Method

        #region SetLanguage
        public void SetLanguage()
        {
            lblUName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
        }
        #endregion

        #endregion

    }
}
