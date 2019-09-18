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
using BumedianBM.ViewHelper;
using System.IO;

namespace BumedianBM.ArabicView
{
    public partial class Clear_DataBase_Information : Form, IDisposable
    {
        public string cleandboption = string.Empty;
        public byte KeepUserInfo;
        OptionSettingsObject objOption;
        OptionSettingHelper ObjHelper;

        public Clear_DataBase_Information()
        {
            InitializeComponent();
            SetLanguage();
            objOption = new OptionSettingsObject();
            ObjHelper = new OptionSettingHelper();
        }

        public void SetLanguage()
        {
            grpClearDBOption.Text = Additional_Barcode.GetValueByResourceKey("CDB");
            chkKeepAgent.Text = Additional_Barcode.GetValueByResourceKey("KAgent");
            chkKeepEmployee.Text = Additional_Barcode.GetValueByResourceKey("KEmp");
            chkKeepItemBarcode.Text = Additional_Barcode.GetValueByResourceKey("KBar");
            chkKeepUser.Text = Additional_Barcode.GetValueByResourceKey("KU");
            chkMoveCreditAgents.Text = Additional_Barcode.GetValueByResourceKey("MCA");
            chkSpendings.Text = Additional_Barcode.GetValueByResourceKey("KS");
            rbnDeleteAll.Text = Additional_Barcode.GetValueByResourceKey("DA");
            rbnDeleteAllMovements.Text = Additional_Barcode.GetValueByResourceKey("DAM");
            rbnKeepdata.Text = Additional_Barcode.GetValueByResourceKey("KD");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("MDes");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnOk.Text = Additional_Barcode.GetValueByResourceKey("K");
            lblWillKeepItemNamesAndPrices.Text = Additional_Barcode.GetValueByResourceKey("WillKeep");
            lblWillMakeTheDBClean.Text = Additional_Barcode.GetValueByResourceKey("WillMake");
            this.Text = Additional_Barcode.GetValueByResourceKey("ClearDI");
            chkStocktoInventory.Text = Additional_Barcode.GetValueByResourceKey("MoveStocktoInventory");
        }

        private void Clear_DataBase_Information_Load(object sender, EventArgs e)
        {
            rbnDeleteAll.Checked = true;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton Rdb = (RadioButton)sender;
                cleandboption = Rdb.Name.ToString();
                HideOption();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbnKeepdata.Checked && chkMoveCreditAgents.Checked == true && chkKeepAgent.Checked != true)
            {
                GeneralFunction.Information("CheckAgentInfo", "Clean DB");
                return;
            }
            //This is commented due to client asked that "When check Move stock to Inventory, KeepItemnameandbarcode should be disabled by default"
            //if (rbnKeepdata.Checked && chkStocktoInventory.Checked == true && chkKeepItemBarcode.Checked != true)
            //{
            //    GeneralFunction.Information("CheckItemBarcode", "CleanDB");
            //    return;
            //}
            DB_Login ObjFrm = new DB_Login();
            ObjFrm.Tag = "Clean DB";
            if ((ObjFrm.ShowDialog() == DialogResult.Cancel))
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            if (GeneralFunction.OKCancelMsg("InsCleanDb", "CleanDB") == DialogResult.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            if (GeneralFunction.Question("AlertCleanDb", "CleanDB") == DialogResult.Yes)
            {
                switch (cleandboption)
                {
                    case "rbnDeleteAllMovements":
                        CleanDB("rbnDeleteAllMovements");
                        break;
                    case "rbnDeleteAll":
                        //CleanDB("rbnDeleteAll");Commended By Meena.R To Run the script 
                        string FileName = System.Windows.Forms.Application.StartupPath + "\\" + "script.bat";
                        System.Diagnostics.Process _process = new System.Diagnostics.Process();
                        _process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\" + "script.bat";
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
                        }
                        else
                        {
                            return;
                        }
                        Cursor.Current = Cursors.Default;
                        break;
                    case "rbnKeepdata":
                        if (chkMoveCreditAgents.Checked)
                        {
                            GeneralFunction.isCleanDB = true;
                            GeneralFunction.CleanDBDescription = Txt_Discription.Text;
                            ObjHelper.objOptionSettingsBAl.AgentDept();
                            GeneralFunction.isCleanDB = true;
                        }
                        CleanDB("rbnKeepdata");
                        break;
                }
                this.DialogResult = DialogResult.OK;
            }

        }

        void CleanDB(string option)
        {
            try
            {
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionDB = option;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.Itemandbarcode = (byte)chkStocktoInventory.CheckState == (byte)1 ? (byte)chkStocktoInventory.CheckState : (byte)chkKeepItemBarcode.CheckState;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.AgentInfo = (byte)chkKeepAgent.CheckState;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.Spendings = (byte)chkSpendings.CheckState;
                KeepUserInfo = ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.UserInfo = (byte)chkKeepUser.CheckState;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.MoveCreditofAgents = (byte)chkMoveCreditAgents.CheckState;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.EmpInfo = (byte)chkKeepEmployee.CheckState;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.Description = Txt_Discription.Text;
                ObjHelper.objOptionSettingsBAl.objOptionSettingsObject.MoveStocktoInventory = (byte)chkStocktoInventory.CheckState;
                if (ObjHelper.CleanDB())
                { GeneralFunction.Information("CleanDbSuccess", "Clean DB"); this.Close(); }
                //else { GeneralFunction.InfoMsg("FailedCleanDb", this.Text); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void HideOption()
        {
            chkKeepAgent.Checked = rbnKeepdata.Checked;
            chkKeepEmployee.Checked = rbnKeepdata.Checked;
            // chkKeepItemBarcode.Checked = rbnKeepdata.Checked; //This is commented due to client asked that "When check Move stock to Inventory, KeepItemnameandbarcode should be disabled by default"
            chkKeepUser.Checked = rbnKeepdata.Checked;
            chkSpendings.Checked = rbnKeepdata.Checked;
            chkMoveCreditAgents.Checked = rbnKeepdata.Checked;
            chkKeepAgent.Visible = rbnKeepdata.Checked;
            chkKeepEmployee.Visible = rbnKeepdata.Checked;
            chkKeepItemBarcode.Visible = rbnKeepdata.Checked;
            chkKeepUser.Visible = rbnKeepdata.Checked;
            chkSpendings.Visible = rbnKeepdata.Checked;
            chkMoveCreditAgents.Visible = rbnKeepdata.Checked;
            Txt_Discription.Visible = rbnKeepdata.Checked;
            lblDescription.Visible = rbnKeepdata.Checked;
            chkStocktoInventory.Checked = chkStocktoInventory.Visible = rbnKeepdata.Checked;
        }

        private void Clear_DataBase_Information_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                Quick_Price_Information frmQuick = new Quick_Price_Information();
                frmQuick.ShowDialog();
            }
        }

        //This is added due to client asked that "When check Move stock to Inventory, KeepItemnameandbarcode should be disabled by default"
        #region
        private void chkStocktoInventory_CheckedChanged(object sender, EventArgs e)
        {
            chkKeepItemBarcode.Enabled = chkKeepItemBarcode.Checked = chkStocktoInventory.Checked == true ? true : false;
            chkKeepItemBarcode.Enabled  = chkStocktoInventory.Checked == true ? false : true;
        }
        #endregion

        private void chkMoveCreditAgents_CheckedChanged(object sender, EventArgs e)
        {
            chkKeepAgent.Enabled = chkKeepAgent.Checked = chkMoveCreditAgents.Checked == true ? true : false;
            chkKeepAgent.Enabled  = chkMoveCreditAgents.Checked == true ? false : true;
        }
    }
}
