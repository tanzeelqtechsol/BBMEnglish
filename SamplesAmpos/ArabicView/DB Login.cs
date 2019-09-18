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

namespace BumedianBM.ArabicView
{
    public partial class DB_Login : Form,IDisposable
    {
        #region "Variables"

        //   Employee_Dal Obj_Dal;
        DBLoginHelper objDBLoginHelper;
        LoginObjectClass ObjLoginObjectClass;

        #endregion

        #region  Constructor
        public DB_Login()
        {
            InitializeComponent();
            ObjLoginObjectClass = new LoginObjectClass();
            objDBLoginHelper = new DBLoginHelper();
            SetLanguage();
        }
        #endregion


        private void DB_Login_Load(object sender, EventArgs e)
        {
            try
            {
                //Txt_UserName.Text = GeneralFunction.UserName;
                Txt_UserName.Focus();
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "DB_Login", "DB_Login_Load");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Tag.ToString() == "Enter")
                {
                    if (GeneralOptionSetting.FlagCashDrawerPassword != Txt_Password.Text.Trim())
                    {
                        GeneralFunction.Information("ValidUserNamePassword","DBLogin");
                        Txt_Password.Text = string.Empty;
                        Txt_Password.Focus();
                        this.DialogResult = DialogResult.None;
                    }
                }
                else
                {
                    if (Validation())
                    {
                        DataTable dt = new DataTable();
                        objDBLoginHelper.objDBLoginBAL.objEmployeeObjectClass.UserName = Txt_UserName.Text;
                        objDBLoginHelper.objDBLoginBAL.objEmployeeObjectClass.Password = GeneralFunction.Encrypt(Txt_Password.Text);
                        List<EmployeeObjectClass> lstUser = objDBLoginHelper.GetUser();
                        if (lstUser.Count > 0)
                        {
                            if (lstUser[0].Status != 1)
                            {
                                GeneralFunction.Information("TemprovarilyUserSuspended", "DBLogin");
                                Txt_Password.Text = string.Empty;
                                Txt_UserName.Text = string.Empty;
                                Txt_UserName.Focus();
                                this.DialogResult = DialogResult.None;
                            }
                            else if ((lstUser[0].GroupID != GeneralFunction.UserGroupID) || (GeneralFunction.UserId != lstUser[0].UserId)) // This is changed to check Login User has  rights for cleaning db.
                            {
                                if (!UserScreenLimidations.CleanDB)
                                {
                                    GeneralFunction.Information("NoAdminRights", "DBLogin");
                                    Txt_Password.Text = string.Empty;
                                    Txt_UserName.Text = string.Empty;
                                    Txt_UserName.Focus();
                                    this.DialogResult = DialogResult.None;
                                }

                            }

                        }
                        else
                        {
                            GeneralFunction.Information("ValidUserNamePassword", "DBLogin");
                            Txt_Password.Text = string.Empty;
                            Txt_UserName.Text = string.Empty;
                            Txt_UserName.Focus();
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "DB_Login", "btnLogin_Click");
            }
        }

        #region"Key Down Events"

        private void Txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    this.InvokeOnClick(btnLogin, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "DB_Login", "Txt_KeyDown");
            }
        }

        private void Txt_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "DB_Login", "Txt_UserName_KeyDown");
            }
        }

        #endregion

        #region "Methods"

        private bool Validation()
        {
            try
            {
                if (Txt_UserName.Text == string.Empty)
                {
                    GeneralFunction.Information("EmptyUser", "DBLogin");
                    Txt_UserName.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetLanguage()
        {
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UN");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("DC");
            btnLogin.Text = Additional_Barcode.GetValueByResourceKey("DL");
            this.Text = Additional_Barcode.GetValueByResourceKey("DBLogin");
        }

        #endregion

    }
}
