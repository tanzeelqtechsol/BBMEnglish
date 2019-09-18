using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class StockPassword : Form
    {
       
        public StockPassword()
        {
            InitializeComponent();
            this.Tag = Additional_Barcode.GetValueByResourceKey("enterpassword");//"password";
            this.Text = Additional_Barcode.GetValueByResourceKey("enterpassword");//"Password";
            btnOk.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
        }

     

        private void btnOk_Click(object sender, EventArgs e)
        {
            //String BackupPath = GeneralFunction._backuppath;
            //String GetBackupPath = "";
            
            //String GetBackupPath = GeneralFunction.BackupPath;
            //String GetAlternetBackup = GeneralFunction.AlternateBackupPath;

            GeneralFunction._backuppath = GeneralOptionSetting.FlagSaveBackup;
            string Pass = GeneratePassword();
            if (Txt_Password.Text == Pass)
            {

                string msg = "";
                if (GeneralFunction.BackupDBStock())
                {
                    msg = "stocksuccessmsg";
                }
                else
                {
                    msg = "stockfailedsmsg";
                }
                if (GeneralFunction.Question(msg, "Confirmation") == DialogResult.Yes)
                {
                    LoginViewHelper updstock = new LoginViewHelper();
                    bool res = updstock.UpdateWrongStock();
                    if (res == true || res == false)
                    {
                        GeneralFunction.Information("wrongstocksuccess", ActionType.Information.ToString());
                    }
                }


            }

            else
            {
               
                GeneralFunction.Information("wrongpassenter", ActionType.Information.ToString());
                this.DialogResult = DialogResult.None;
                Txt_Password.Text = "";

            }
        }
        
        private string GeneratePassword()
        {
            string Password = "";

            string sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            string dy = datevalue.Day.ToString();
            string mn = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            decimal dateMul = Convert.ToDecimal(dy) * Convert.ToDecimal(mn) * Convert.ToDecimal(yy);
            dateMul = dateMul / 7;
            dateMul = Math.Truncate(dateMul);
            Password = dateMul.ToString();
            return Password;
        }
    }
}
