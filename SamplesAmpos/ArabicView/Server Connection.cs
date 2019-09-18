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
using System.Threading;

namespace BumedianBM.ArabicView
{
    public partial class Server_Connection : Form,IDisposable
    {

        ServerConnViewHelper ObjHelper;
        internal static Boolean ConnDialogResult = false;
        public Server_Connection()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjHelper = new ServerConnViewHelper();
        }
       

        private void Server_Connection_Load(object sender, EventArgs e)
        {
            InitialLoad();
        }

        public void SetObjectFromControl()
        {
            ObjHelper.ObjBalClass.ObjLoginObject.Server = cmbServer.Text.Trim();
            ObjHelper.ObjBalClass.ObjLoginObject.Password = txtPassword.Text.Trim();
            ObjHelper.ObjBalClass.ObjLoginObject.UName = txtUserName.Text.Trim();
            ObjHelper.ObjBalClass.ObjLoginObject.Database = cmbDatabase.Text.Trim();
            ObjHelper.server = ObjHelper.ObjBalClass.ObjLoginObject.Server;
            ObjHelper.password = ObjHelper.ObjBalClass.ObjLoginObject.Password;
            ObjHelper.UserId = ObjHelper.ObjBalClass.ObjLoginObject.UName;
        }
        public void SetLanguage()
        {
            lblDB.Text = Additional_Barcode.GetValueByResourceKey("DB");
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
            lblServer.Text = Additional_Barcode.GetValueByResourceKey("Server");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UN");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnOk.Text = Additional_Barcode.GetValueByResourceKey("K");
            btnTechConn.Text = Additional_Barcode.GetValueByResourceKey("TechConn");
            this.Text = Additional_Barcode.GetValueByResourceKey("ServerConn");
        }

        void InitialLoad()
        {

            cmbServer.Text = GeneralFunction.Server;
            cmbDatabase.Text = GeneralFunction.Database;
            txtUserName.Text = GeneralFunction.UserID;
            txtPassword.Text = GeneralFunction.Password;
            List<string> listServers = ObjHelper.GetActiveServers();
            cmbServer.Items.Clear();
            cmbServer.Items.AddRange(listServers.ToArray());

        }
        void PopulateInputs()
        {
            cmbDatabase.Items.Clear();
            cmbDatabase.Items.AddRange(ObjHelper.GetServerDatabases().ToArray());
        }
        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                PopulateInputs();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void btn_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                string Name = (((Button)sender).Name.ToString());
                
            
                 switch(Name)
                   {
                       case "btnOk":
                           if (ObjHelper.SaveConnection())
                           {
                               this.DialogResult = DialogResult.OK;
                               ConnDialogResult = true;
                           }
                           break;
                       case "btnCancel":
                           this.DialogResult = DialogResult.Cancel;
                           this.Close();
                           break;
                       case "btnTechConn":
                           ObjHelper.CheckTechConn();
                           break;

                   }

               }
               catch (Exception ex)
               {
                   throw ex;
               }
            }

        private void cmbServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                foreach (Control ct in this.Controls)
                {
                    if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                        ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }
    }
}
