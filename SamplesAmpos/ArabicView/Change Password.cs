using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
//Created By :G.Saradhaa(28/11/2013)
namespace BumedianBM.ArabicView
{
    public partial class frmChangePassword : Form,IDisposable
    {
        LoginViewHelper objLoginViewHelper;
        public frmChangePassword()
        {
            objLoginViewHelper = new LoginViewHelper();
            InitializeComponent();
            SetLanguage();
        }

        public void SetLanguage()
        {
            lblConfirmPassword.Text = Additional_Barcode.GetValueByResourceKey("ConPsw");
            lblCurrentPassword.Text = Additional_Barcode.GetValueByResourceKey("CurPsw");
            lblNewPassword.Text = Additional_Barcode.GetValueByResourceKey("NewPsw");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnSubmit.Text = Additional_Barcode.GetValueByResourceKey("Save");
            this.Text = Additional_Barcode.GetValueByResourceKey("ChangePsw");
        }
        public bool ValidateControls()
        {
            if (txtCurrentPassword.Text == "")
            {
                CommonHelper.GeneralFunction.Warning("EmpCurPsw", "ChangePassword");
                txtCurrentPassword.Focus();
                return false;
            }
            if (txtNewPassword.Text == "")
            {
                CommonHelper.GeneralFunction.Warning("NewPasswordEmpty", "ChangePassword");
                txtNewPassword.Focus();
                return false;
            }
            if (txtConfirmPassword.Text == "")
            {
                CommonHelper.GeneralFunction.Warning("ConfirmPasswordEmpty", "ChangePassword");
                txtConfirmPassword.Focus();
                return false;
            }
            return true;
        }


        private void frmChangePassword_Load(object sender, EventArgs e)
        { txtCurrentPassword.Focus(); }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateControls() && objLoginViewHelper.CheckPassword(txtNewPassword.Text, txtConfirmPassword.Text))
            {
                if ((CommonHelper.GeneralFunction.Question("Are You Sure to Change Password", "ChangePassword") == DialogResult.Yes))
                {
                    objLoginViewHelper.balClass.ObjLoginObject.UName = CommonHelper.GeneralFunction.LoginUserName;
                    objLoginViewHelper.balClass.ObjLoginObject.UserId = CommonHelper.GeneralFunction.LoginUserId;
                    objLoginViewHelper.balClass.ObjLoginObject.Password = CommonHelper.GeneralFunction.Encrypt(txtCurrentPassword.Text);
                    objLoginViewHelper.balClass.ObjLoginObject.NewPassword = CommonHelper.GeneralFunction.Encrypt(txtNewPassword.Text);
                    if (objLoginViewHelper.ChangePassword())
                        txtCurrentPassword.Text = txtConfirmPassword.Text = txtNewPassword.Text = "";
                    else
                    {
                        txtCurrentPassword.SelectAll();
                        txtCurrentPassword.Focus();
                    }
                }
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!objLoginViewHelper.CheckPassword(txtNewPassword.Text, txtConfirmPassword.Text))
            {
                txtNewPassword.Text = txtConfirmPassword.Text = "";
                txtNewPassword.Focus();
            }

        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSubmit.Focus();
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtConfirmPassword.Focus();
        }

        private void txtCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNewPassword.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
