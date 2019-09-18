using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using CommonHelper;

namespace BumedianBM.ArabicView
{
    public partial class TableSettings : Form,IDisposable
    {

        #region Declaration
        PosShortcutHelper objPosShortcutHelper;
        #endregion

        #region Constructor
        public TableSettings()
        {
            objPosShortcutHelper = new PosShortcutHelper();
            InitializeComponent();
            SetLanguage();
        }
        #endregion

        #region Events

        #region FormLoad

        private void TableSettings_Load(object sender, EventArgs e)
        {
            try
            {
                BindDetailsToButton(Convert.ToInt16(LoadTableSettings.LoadAllSettings));
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "TableSettings_Load");
            }

           
        }

        #endregion

        #region ButtonClickEvents

        #region BtnShortcuts_Click
        private void BtnShortcuts_Click(object sender, EventArgs e)
        {
            try
            {
                Control ctr = (Button)sender;
                string btnshortcut = ctr.Name.Replace("Btn", "").Trim();
                ClearInputs();
                Cmb_ShortCut.Text = btnshortcut;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "BtnShortcuts_Click");
            }
        }
        #endregion

        #region btnNew_Click
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearInputs();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnNew_Click");
            }
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectsFromControl();
                if (objPosShortcutHelper.ValidationOnSaveTable())
                {
                    if (objPosShortcutHelper.SaveTableDetailsHelper())
                    {
                        GeneralFunction.Information("Button details saved successfully", "TableShortcuts");
                        Cmb_ShortCut.Focus();
                        objPosShortcutHelper.GetTableDetailsHelper();
                        objPosShortcutHelper.FilterTableList();
                        ClearInputs();
                        BindDetailsToButton(Convert.ToInt16(LoadTableSettings.LoadSavedSetting));
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Save), "Table detail", "TableSelection", "Save POS shortcut table details", Convert.ToInt16(InvoiceAction.No));
                    }

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnSave_Click");
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectsFromControl();
                if (objPosShortcutHelper.DeleteTable())
                {
                    DeleteTableDetails(this.Controls, Cmb_ShortCut.Text.ToString());
                    ClearInputs();
                    objPosShortcutHelper.GetTableDetailsHelper();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "btnDelete_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region SelectedIndexChanged
        private void Cmb_ShortCut_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_ShortCut.SelectedIndex != -1 && Cmb_ShortCut.SelectedItem != null)
                {
                   
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = int.Parse(Cmb_ShortCut.Text);
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCutText = objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut;
                    FillData();

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "Cmb_ShortCut_SelectedIndexChanged");
            }

        }
        #endregion

        #region KeyDown Events

        #region Cmb_ShortCut_KeyDown
        private void Cmb_ShortCut_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Txt_Discription_KeyDown
        private void Txt_Discription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            }
        }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            try
            {
                btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
                this.Text = Additional_Barcode.GetValueByResourceKey("TableShortcuts");//Need to Inplement
                btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
                btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
                lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
                lblShotCut.Text = Additional_Barcode.GetValueByResourceKey("Shortcut");
                btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
                tabTable1.Text = Additional_Barcode.GetValueByResourceKey("TabTable1");
                tabTable2.Text = Additional_Barcode.GetValueByResourceKey("TabTable2");
            }
            catch (Exception ex)
            {
               
                GeneralFunction.ErrorMessages(ex.Message, this.Text, "SetLanguage");//Need to Inplement
            }


        }
        #endregion

        #region ClearInputs
        private void ClearInputs()
        {
            Cmb_ShortCut.SelectedIndex = -1;
            Cmb_ShortCut.Text = string.Empty;
            Txt_Discription.Text = string.Empty;
            Cmb_ShortCut.Focus();
        }
        #endregion

        #region SetObjectsFromControl
        private void SetObjectsFromControl()
        {
            try
            {
                //Binding Objects for Browsing the Image
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShorcutSelectedIndex = Cmb_ShortCut.SelectedIndex;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.Discription = Txt_Discription.Text;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCutText = (Cmb_ShortCut.SelectedIndex != -1 ? Convert.ToInt16(Cmb_ShortCut.Text) : 0);
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.SaleId = 0;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.Status = 1;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.UserId = GeneralFunction.UserId;


            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, "SetObjectsFromControl");
            }
        }
        #endregion

        #region BindDetailsToButton
        private void BindDetailsToButton(int flag)
        {
            Control.ControlCollection ctr = this.Controls;
            if (flag == Convert.ToInt16(LoadTableSettings.LoadAllSettings))
            {
                objPosShortcutHelper.GetTableDetailsHelper();
                for (int i = 0; i < objPosShortcutHelper.lstTableDetails.Count; i++)
                {
                    Control[] cn;
                    string str = "Btn" + objPosShortcutHelper.lstTableDetails[i].ShortCut;
                    System.Windows.Forms.Button Btn;
                    cn = ctr.Find(str, true);
                    Btn = (Button)cn[0];
                    Btn.Text = objPosShortcutHelper.lstTableDetails[i].Discription;
                }
            }
            else if (flag == Convert.ToInt16(LoadTableSettings.LoadSavedSetting))
            {
                Control[] cn;
                string str = "Btn" + objPosShortcutHelper.lstFilteredTableDetail[0].ShortCut;
                System.Windows.Forms.Button Btn;
                cn = ctr.Find(str, true);
                Btn = (Button)cn[0];
                Btn.Text = objPosShortcutHelper.lstFilteredTableDetail[0].Discription;
            }
        }

        #endregion

        #region FillData
        private void FillData()
        {
            objPosShortcutHelper.FilterTableList();
            if (objPosShortcutHelper.lstFilteredTableDetail.Count > 0)
            {
                Txt_Discription.Text = objPosShortcutHelper.lstFilteredTableDetail[0].Discription;
            }
            else
            {
                Txt_Discription.Text = string.Empty;
            }
        }

        #endregion

        #region DeleteTableDetails
        public void DeleteTableDetails(Control.ControlCollection ctr, string shortcut)
        {
            System.Windows.Forms.Button Btn;
            Control[] cn;
            string str;
            str = "Btn" + shortcut;
            cn = ctr.Find(str, true);
            Btn = (Button)cn[0];
            Btn.Text = shortcut;

        }
        #endregion

       
       

        #endregion

    }
}
