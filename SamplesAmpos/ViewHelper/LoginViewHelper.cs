using System;
using System.Collections.Generic;
using System.Linq;
using BumedianBM.View;
using System.Text;
using BALHelper;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using CommonHelper;
using System.Data;
using BumedianBM.CrystalReports;
using System.Configuration;
using ObjectHelper;

namespace BumedianBM.ViewHelper
{
    public class LoginViewHelper
    {
        private MasterFrom Login;
        private LoginBALHelper _loginBALHelper;
        internal string focus;
        public LoginBALHelper balClass
        {
            get { return _loginBALHelper; }
            set { _loginBALHelper = value; }
        }

        public LoginViewHelper(MasterFrom form)
        {
            Login = form;
            balClass = new LoginBALHelper();
            balClass.SetCommonObject();
        }

        public LoginViewHelper()
        {

            balClass = new LoginBALHelper();
            balClass.SetCommonObject();
        }

        public string LoginFunction()
        {
            string res = string.Empty;

            DataTable dt = new DataTable();
            string msg = string.Empty;
            dt = _loginBALHelper.Check_Userlogin();

            if (dt != null && dt.Rows.Count > 0)
            {
                if (_loginBALHelper.ObjLoginObject.LastUserId == 0) { }

                if ((dt.Rows[0]["Login"].ToString() == "False") | (dt.Rows[0]["WorkStationName"].ToString() == GeneralFunction.workstationName))
                {
                    if (balClass.ObjLoginObject.LastUserId != 0)
                    {
                        _loginBALHelper.LogOut_UserBAL(balClass.ObjLoginObject.LastUserId);
                        balClass.ObjLoginObject.LastUserId = 0; balClass.ObjLoginObject.LastUser = string.Empty;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Message"].ToString() != null && dt.Rows[i]["Message"].ToString() != string.Empty)
                        {
                            msg = msg + "\n\r\n\r" + dt.Rows[i]["Message"].ToString() + "\n" + "Date- " + Convert.ToDateTime(dt.Rows[i]["AlertDate"] == DBNull.Value ? null : dt.Rows[0]["AlertDate"]);
                        }
                    }
                    if (int.Parse(dt.Rows[0]["Status"].ToString()) == 1)
                    {
                        GeneralFunction.Status = true;
                    }
                    else
                    {
                        GeneralFunction.Status = false;
                    }
                    if (int.Parse(dt.Rows[0]["Status"].ToString()) == 1)
                    {
                        GeneralFunction.LoginUserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                        GeneralFunction.LoginUserName = dt.Rows[0]["UserName"].ToString();

                        GeneralFunction.UserId = int.Parse(dt.Rows[0]["UserId"].ToString());
                        GeneralFunction.UserName = dt.Rows[0]["FirstName"].ToString();
                        GeneralFunction.MessageDate = Convert.ToDateTime(dt.Rows[0]["AlertDate"] == DBNull.Value ? null : dt.Rows[0]["AlertDate"]);
                        GeneralFunction.Message = msg == string.Empty ? GeneralFunction.ChangeLanguageforCustomMsg("NoNotes") : msg;
                        // GeneralFunction.ScreenLimidations = dt.Rows[0]["MTB_SCREEN_ID"].ToString();
                        GeneralFunction.FlagCheck = dt.Rows[0]["LoginFlag"] == DBNull.Value ? string.Empty : dt.Rows[0]["LoginFlag"].ToString();
                        GeneralFunction.WeekEndDay = dt.Rows[0]["WeekEndDay"] == DBNull.Value ? string.Empty : dt.Rows[0]["WeekEndDay"].ToString();
                        GeneralFunction.UserGroupID = Convert.ToInt32(dt.Rows[0]["UserGroupID"].ToString());
                        GeneralFunction.StartWorkHrs = dt.Rows[0]["StartWorkHours"].ToString() != string.Empty ? Convert.ToDateTime(dt.Rows[0]["StartWorkHours"]) : DateTime.MinValue;
                        GeneralFunction.EndWorkHrs = dt.Rows[0]["EndWorkHours"].ToString() != string.Empty ? Convert.ToDateTime(dt.Rows[0]["EndWorkHours"]) : DateTime.MinValue;
                        CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.custom);
                        res = "True";
                    }
                    else
                    {
                        res = "SuspendUserError";
                    }
                }
                else
                {
                    //GeneralFunction.ErrInfo("User Already Logged In Another WorkStation", "Login");
                    GeneralFunction.ErrInfo(Additional_Barcode.GetValueByResourceKey("User Already Logged In Another WorkStation"), Additional_Barcode.GetValueByResourceKey("Login"));
                    res = "WorkStationError";
                }
            }
            else
            {
                // GeneralFunction.Warning("Enter the Valid UserName Password", "Login Status");
                res = "ValidUserNameError";
            }

            return res;
        }

        public bool CheckActiveConnectionHelp()
        {
            return (_loginBALHelper.CheckActiveConnectionBAL(GeneralFunction.Server, GeneralFunction.UserID.ToString(), GeneralFunction.Password));
        }
        public bool Validation()
        {

            if (balClass.ObjLoginObject.UName == null || balClass.ObjLoginObject.UName.Trim() == string.Empty)
            {
                //if(balClass.ObjLoginObject.Password==
                GeneralFunction.ErrInfo("UserName Is Required", "LoginStatus");
                focus = "UserName";
                return false;
            }
            else if (balClass.ObjLoginObject.Password == null || balClass.ObjLoginObject.Password.Trim() == string.Empty)
            {
                GeneralFunction.ErrInfo("Password is Required", "LoginStatus");
                focus = "Password";
                return false;
            }
            else
                return true;

        }
        //Included By G.Saradhaa(28/11/2013)
        internal bool CheckPassword(string newPsswrd, string confmPsswrd)
        {
            if (newPsswrd != confmPsswrd)
            {
                CommonHelper.GeneralFunction.Warning("PasswordMismatch ", "ChangePassword");
                return false;
            }
            else
                return true;
        }
        internal bool ChangePassword()
        {
            if (balClass.ChangeUserPassWord())
            {
                CommonHelper.GeneralFunction.Warning("PasswordChangedSuccessfully", "ChangePassword");
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Update), "Change password", "USER", "Update password details", Convert.ToInt32(InvoiceAction.No));
                return true;
            }
            else
            {
                CommonHelper.GeneralFunction.Warning("PasswordMismatchError", "ChangePassword");
                return false;
            }
        }
        public bool CheckBalanceHelp()
        {
            bool res = false; decimal balance = 0;
            balance = balClass.CheckBalanceBAL();
            if (balance > 0)
                res = true;
            return res;
        }
        public int GetBarcodeCountHelp()
        {
            return _loginBALHelper.GetBarcodeCountBAL();
        }
        public bool GetEmptyBarcodes()
        {
            return _loginBALHelper.GetEmptyBarcodes();
        }

        public bool UpdateWrongStock()
        {
            return _loginBALHelper.UpdateWrongStock();
        }

        internal void ShowExpiryList()
        {
            Rpt_ExpiryItems report = new Rpt_ExpiryItems();
            ReportsView frmView = new ReportsView();
            DataTable dt = new DataTable("ExpiryList");
            dt = _loginBALHelper.GetExpiredItems();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("ExpiryListatDate");
            if (dt.Rows.Count <= 0)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoRecordsFound"), "ExpiryList");
                return;
            }
            frmView.RptDoc = report;
            frmView.HTable.Add("ReportName", GeneralFunction.ChangeLanguageforCustomMsg("ExpiryListatDate"));
            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
            {
                frmView.HTable.Add("monthformat", 0);
                frmView.HTable.Add("dayformat", 0);
                frmView.HTable.Add("yearformat", 0);
                frmView.HTable.Add("seperatorformat", "/");
                frmView.HTable.Add("dateformat", 0);
            }
            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
            {
                frmView.HTable.Add("monthformat", 1);
                frmView.HTable.Add("dayformat", 1);
                frmView.HTable.Add("yearformat", 1);
                frmView.HTable.Add("seperatorformat", "/");
                frmView.HTable.Add("dateformat", 1);
            }
            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
            {
                frmView.HTable.Add("monthformat", 1);
                frmView.HTable.Add("dayformat", 1);
                frmView.HTable.Add("yearformat", 1);
                frmView.HTable.Add("seperatorformat", "-");
                frmView.HTable.Add("dateformat", 0);
            }
            else
            {
                frmView.HTable.Add("monthformat", 1);
                frmView.HTable.Add("dayformat", 1);
                frmView.HTable.Add("yearformat", 1);
                frmView.HTable.Add("seperatorformat", "/");
                frmView.HTable.Add("dateformat", 0);
            }
            frmView.Report_Table = dt;
            frmView.LoadEvent();
            frmView.ShowDialog();
        }
    }
}
