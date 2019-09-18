using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using CommonHelper;
using System.IO;
using System.Threading;

namespace BumedianBM.ArabicView
{
    public partial class POS_Shortcuts : Form, IDisposable
    {

        #region Declaration
        PosShortcutHelper objPosShortcutHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        #endregion

        #region Constructor
        public POS_Shortcuts()
        {
            objPosShortcutHelper = new PosShortcutHelper();
            InitializeComponent();
            SetLanguage();
            setFont();
        }
        #endregion

        #region Events

        #region Form Load
        private void POS_Shortcuts_Load(object sender, EventArgs e)
        {
            try
            {
                AssignToComboBox();
                LoadItem();
                objPosShortcutHelper.TabIndex = 1;
                BindDetailsToButton("N");
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                Cmb_Item.Select();
                Cmb_Item.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "POS_Shortcuts_Load");
            }
        }
        #endregion

        #region IndexChanged

        #region Tab_ShortCut_SelectedIndexChanged
        private void Tab_ShortCut_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objPosShortcutHelper.TabIndex = Tab_ShortCut.SelectedIndex + 1;
                BindDetailsToButton("N");
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "Tab_ShortCut_SelectedIndexChanged");
            }

        }
        #endregion

        #region Combobox_SelectedItemChanged
        private void Combobox_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {

                ComboBox cmbbox = (ComboBox)sender;
                switch (cmbbox.Name)
                {
                    case "Cmb_ShortCut":
                        if (Cmb_ShortCut.SelectedIndex != -1 && Cmb_ShortCut.SelectedItem != null) FillData(int.Parse(Cmb_ShortCut.Text), "N");
                        ClearInputSeparate("Y");
                        break;
                    case "Cmb_AdditionShortcut":
                        if (Cmb_AdditionShortcut.SelectedIndex != -1 && Cmb_AdditionShortcut.SelectedItem != null) FillData(int.Parse(Cmb_AdditionShortcut.Text), "Y");
                        ClearInputSeparate("N");
                        break;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "Combobox_SelectedItemChanged");
            }

        }
        #endregion

        #endregion

        #region Button Click

        #region Btn_Browse_Click
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectsFromControl();
                objPosShortcutHelper.BrowseImage();
                if (objPosShortcutHelper.Bmp != null)
                {
                    PicImage.Image = objPosShortcutHelper.Bmp;
                    PicImage.Image.Save(objPosShortcutHelper.Ms, PicImage.Image.RawFormat);
                    objPosShortcutHelper.ButtonImage = new byte[objPosShortcutHelper.Ms.Length];
                    objPosShortcutHelper.ButtonImage = objPosShortcutHelper.Ms.GetBuffer();
                }
                txtImagePath.Text = objPosShortcutHelper.ImagePath;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "Btn_Browse_Click");
            }

        }
        #endregion

        #region lblRemove_LinkClicked
        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                objPosShortcutHelper.ButtonImage = new byte[0];
                PicImage.Image = null;
                txtImagePath.Text = string.Empty;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "lblRemove_LinkClicked");
            }

        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectsFromControl();
                if (objPosShortcutHelper.ValidationOnSave())
                {
                    PopulateInputs();
                    if (objPosShortcutHelper.SaveButtonDetailsHelper())
                    {
                        GeneralFunction.Information("Button details saved successfully", "POS Shortcuts");
                        varPrice.Checked = false;
                        Cmb_ShortCut.Focus();
                        LoadItem();

                        if (Cmb_ShortCut.SelectedItem == null)
                        {
                            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = Convert.ToInt16(Cmb_AdditionShortcut.Text);
                            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 1;
                            objPosShortcutHelper.FilterButtonList();
                            ClearInputSeparate("Y");
                        }
                        else
                        {
                            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = Convert.ToInt16(Cmb_ShortCut.Text);
                            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 0;
                            objPosShortcutHelper.FilterButtonList();
                            ClearInputSeparate("N");
                        }
                        BindDetailsToButton("Y");
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt16(ActionType.Save), "button detail", "ButtonSelection", "Save POS shortcut button details", Convert.ToInt16(InvoiceAction.No));
                    }
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectsFromControl();
                if (objPosShortcutHelper.DeleteButton())
                {
                    if (Cmb_ShortCut.SelectedItem != null)
                    {
                        objPosShortcutHelper.DeleteButtondetails(Tab_ShortCut.Controls, Cmb_ShortCut.Text.ToString(), "N");
                        ClearInputSeparate("N");
                        LoadItem();
                    }
                    else
                    {
                        objPosShortcutHelper.DeleteButtondetails(Grb_AdditionButton.Controls, Cmb_AdditionShortcut.Text.ToString(), "Y");
                        ClearInputSeparate("Y");
                        LoadItem();
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "btnDelete_Click");
            }
        }
        #endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "btnNew_Click");
            }
        }
        #endregion

        #region ShortcutButtons Click
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

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "BtnShortcuts_Click");
            }

        }
        #endregion

        #region ButtonAddition_Click
        private void ButtonAddition_Click(object sender, EventArgs e)
        {
            try
            {
                Control ctr = (Button)sender;
                string btnshortcut = ctr.Name.Replace("Btn_Add", "").Trim();
                Cmb_AdditionShortcut.Text = btnshortcut;

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "ButtonAddition_Click");
            }
        }
        #endregion

        #region btnTables_Click
        private void btnTables_Click(object sender, EventArgs e)
        {
            try
            {
                TableSettings objTableSetting = new TableSettings();
                objTableSetting.ShowDialog();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "btnTables_Click");
            }

        }
        #endregion

        #endregion

        #region KeyDown Events
        private void Cmb_ShortCut_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
        }
        bool isFirst = false;
        string appval = "";
        private void Cmb_Item_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    ////Cmb_Item.AutoCompleteMode = AutoCompleteMode.None;
            //    //SendKeys.Send("{TAB}");
            //    //txtBarcode.Focus();
            //    //if(txtBarcode.Text==string.Empty)
            //    Txt_Discription.Focus();
            //}


            //if (e.KeyValue == 13)
            //{
            //    txtBarcode.Focus();
            //    return;
            //}


            //To hide the two drop down in same time done by Praba on 28-Oct
            //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }

            //}
            //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //        (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //        && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //        && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //        && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (((Control)sender).Name == "Cmb_Item") && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
            //{
            //    if (((ComboBox)sender).DroppedDown == true)
            //        ((ComboBox)sender).DroppedDown = false;
            //    if (((ComboBox)sender).Name == "Cmb_Item" && Cmb_Item.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            //    {
            //        Cmb_Item.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //        Cmb_Item.SelectedText = ((char)e.KeyValue).ToString();
            //        Cmb_Item.DroppedDown = true;
            //        isFirst = true;
            //        appval = ((char)e.KeyValue).ToString();

            //    }
            //    else
            //    {
            //        Cmb_Item.DroppedDown = false;
            //        if (isFirst)
            //        {
            //            Cmb_Item.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
            //            isFirst = false;
            //        }

            //    }
            //}

        }

        private void Txt_Discription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //SendKeys.Send("{TAB}");
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            }
        }

        private void Cmb_AdditionShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
            if ((e.KeyCode != Keys.Tab) && ((int)e.KeyValue != 13) && (e.KeyValue != 120) && (e.KeyValue != 18) && (e.KeyValue != 114) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back))//Added on 25-June-2014 for Avoiding Dropped Down when Clik F9 shortcut
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
        }

        private void Txt_AdditionDiscription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            }
        }

        #endregion

        #endregion

        #region Methods

        #region SetLanguage
        public void SetLanguage()
        {
            try
            {
                btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
                this.Text = Additional_Barcode.GetValueByResourceKey("POSShortCut");
                btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
                btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
                lblAdditionalItems.Text = Additional_Barcode.GetValueByResourceKey("AdditionalItems");
                lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
                lblDescription2.Text = Additional_Barcode.GetValueByResourceKey("Description");
                lblPhoto.Text = Additional_Barcode.GetValueByResourceKey("Photo");
                lblRegularItems.Text = Additional_Barcode.GetValueByResourceKey("RegularItems");
                lblRemove.Text = Additional_Barcode.GetValueByResourceKey("Remove");
                lblShotCut.Text = Additional_Barcode.GetValueByResourceKey("Shortcut");
                lblShotCut2.Text = Additional_Barcode.GetValueByResourceKey("Shortcut");
                lblItem.Text = Additional_Barcode.GetValueByResourceKey("Item");
                btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");

                tabPage1.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage2.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage3.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage4.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage5.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage6.Text = Additional_Barcode.GetValueByResourceKey("Items");
                tabPage7.Text = Additional_Barcode.GetValueByResourceKey("Items");

                btnTables.Text = Additional_Barcode.GetValueByResourceKey("Tables");

                varPrice.Text = Additional_Barcode.GetValueByResourceKey("VariablePrice");

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "SetLanguage");
            }


        }
        #endregion

        #region SetObjectsFromControl
        private void SetObjectsFromControl()
        {
            try
            {
                //Binding Objects for Browsing the Image
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShorcutSelectedIndex = Cmb_ShortCut.SelectedIndex;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionShorcutSelectedIndex = Cmb_AdditionShortcut.SelectedIndex;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ItemSelectedIndex = Cmb_Item.SelectedIndex;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionDescText = Txt_AdditionDiscription.Text;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCutText = (Cmb_ShortCut.SelectedIndex != -1 ? Convert.ToInt16(Cmb_ShortCut.Text) : 0);
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionShortCutText = (Cmb_AdditionShortcut.SelectedIndex != -1 ? Convert.ToInt16(Cmb_AdditionShortcut.Text) : 0);
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShowPricePopup = varPrice.Checked ? true : false;

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrorMessages(ex.Message, "POS Shortcuts", "SetObjectsFromControl");
            }
        }
        #endregion

        #region AssignToComboBox
        private void AssignToComboBox()
        {
           // GeneralObjectClass.ItemDetails = objPosShortcutHelper.LoadItemDetails();
            DataTable dtItems = objPosShortcutHelper.GetItem();
            Cmb_Item.DisplayMember = "ItemName";
            Cmb_Item.ValueMember = "ItemID";
            Cmb_Item.DataSource = dtItems;// GeneralObjectClass.ItemDetails;
            Cmb_Item.SelectedIndex = -1;

        }
        #endregion

        #region PopulateInputs
        private void PopulateInputs()
        {
            try
            {

                if (Cmb_ShortCut.SelectedItem != null)
                {
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = int.Parse(Cmb_ShortCut.Text.ToString());
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ItemName = Cmb_Item.Text;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ItemID = Convert.ToInt16(Cmb_Item.SelectedValue);
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.Discription = Txt_Discription.Text;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 0; //"N";
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ImagePath = txtImagePath.Text.Trim();
                    if (PicImage.Image != null)
                    {
                        objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ImageByte = objPosShortcutHelper.ButtonImage;

                    }
                    else
                    {

                        objPosShortcutHelper.ButtonImage = new byte[1];
                        objPosShortcutHelper.ButtonImage[0] = 0;
                        objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ImageByte = objPosShortcutHelper.ButtonImage;
                    }

                }
                else
                {
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = int.Parse(Cmb_AdditionShortcut.Text.ToString());
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ItemName = Txt_AdditionDiscription.Text;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ItemID = Convert.ToInt16(Cmb_Item.SelectedValue);
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 1; // "Y";
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ImagePath = string.Empty;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.Discription = string.Empty;
                    objPosShortcutHelper.ButtonImage = new byte[1];
                    objPosShortcutHelper.ButtonImage[0] = 0;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ImageByte = objPosShortcutHelper.ButtonImage;
                }
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.Status = 1;
                objPosShortcutHelper.objPOSShortCutBal.objPOSObject.UserId = GeneralFunction.UserId;

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region LoadItem
        private void LoadItem()
        {
            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom = (Tab_ShortCut.SelectedIndex * 18) + 1;
            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutTo = objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom + 18;
            objPosShortcutHelper.GetButtonDetailsHelper();
        }
        #endregion

        #region ClearInputs
        private void ClearInputs()
        {
            try
            {
                Cmb_ShortCut.SelectedIndex = Cmb_AdditionShortcut.SelectedIndex = Cmb_Item.SelectedIndex = -1;
                Cmb_ShortCut.Text = string.Empty;
                Cmb_Item.Text = string.Empty;
                Txt_Discription.Text = string.Empty;
                PicImage.Image = null;
                txtImagePath.Text = string.Empty;
                ImgLstPosShortCut.Images.Clear();
                Cmb_ShortCut.Focus();
                Txt_AdditionDiscription.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region ClearInputSeparate
        private void ClearInputSeparate(string flag)
        {
            try
            {
                if (flag == "Y")
                {
                    //this.Cmb_AdditionShortcut.SelectedIndexChanged -= new System.EventHandler(this.Combobox_SelectedItemChanged);
                    Cmb_AdditionShortcut.SelectedItem = null;
                    Cmb_AdditionShortcut.Text = string.Empty;
                    Txt_AdditionDiscription.Text = string.Empty;
                    // this.Cmb_AdditionShortcut.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedItemChanged);
                }
                else
                {
                    //this.Cmb_ShortCut.SelectedIndexChanged -= new System.EventHandler(this.Combobox_SelectedItemChanged);
                    Cmb_ShortCut.SelectedItem = null;
                    Cmb_Item.SelectedItem = null;
                    Txt_Discription.Text = string.Empty;
                    Cmb_ShortCut.Text = string.Empty;
                    Cmb_Item.Text = string.Empty;
                    PicImage.Image = null;
                    txtImagePath.Text = string.Empty;
                    ImgLstPosShortCut.Images.Clear();

                    // this.Cmb_ShortCut.SelectedIndexChanged += new System.EventHandler(this.Combobox_SelectedItemChanged);
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region BindDetailsToButton
        private void BindDetailsToButton(string flag)
        {
            Control.ControlCollection ctr = ((TabPage)Tab_ShortCut.Controls["tabpage" + objPosShortcutHelper.TabIndex]).Controls;
            Control.ControlCollection addctr = Grb_AdditionButton.Controls;
            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom = (Tab_ShortCut.SelectedIndex * 18) + 1;
            objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutTo = objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortcutFrom + 17;
            objPosShortcutHelper.GetButtonDetailsHelper();
            int btnindex = 0;

            if (objPosShortcutHelper.lstButtonDetailsOne.Count > 0)
            {
                if (flag == "N")
                {
                    objPosShortcutHelper.AddImage("N", ImgLstButton);
                    for (int i = 0; i < objPosShortcutHelper.lstButtonDetailsOne.Count; i++)
                    {
                        if (objPosShortcutHelper.lstButtonDetailsOne[i].AdditionFlag == 0)
                        {

                            Control[] cn;
                            string str = "Btn" + objPosShortcutHelper.lstButtonDetailsOne[i].ShortCut;
                            System.Windows.Forms.Button Btn;
                            cn = ctr.Find(str, true);
                            Btn = (Button)cn[0];
                            if (objPosShortcutHelper.lstButtonDetailsOne[i].Discription == string.Empty) Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName; else Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].Discription;
                            byte[] imgbyte = objPosShortcutHelper.lstButtonDetailsOne[i].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])objPosShortcutHelper.lstButtonDetailsOne[i].ImageByte : new byte[0];
                            if (imgbyte.Length > 1)
                            {
                                Btn.ImageList = ImgLstButton;
                                Btn.ImageList.ImageSize = new Size(75, 50);
                                Btn.ImageAlign = ContentAlignment.TopCenter;
                                Btn.ImageIndex = btnindex;
                                btnindex += 1;
                            }

                        }
                        else
                        {
                            Control[] cn;
                            string str = "Btn_Add" + objPosShortcutHelper.lstButtonDetailsOne[i].ShortCut;
                            System.Windows.Forms.Button Btn;
                            cn = addctr.Find(str, true);
                            Btn = (Button)cn[0];
                            Btn.Text = objPosShortcutHelper.lstButtonDetailsOne[i].ItemName;
                        }
                    }
                }

                else
                {
                    objPosShortcutHelper.AddImage("Y", ImgLstButton);

                    if (objPosShortcutHelper.lstFilteredButtonDetail[0].AdditionFlag == 0)
                    {

                        Control[] cn;
                        string str = "Btn" + objPosShortcutHelper.lstFilteredButtonDetail[0].ShortCut;
                        System.Windows.Forms.Button Btn;
                        cn = ctr.Find(str, true);
                        Btn = (Button)cn[0];
                        if (objPosShortcutHelper.lstFilteredButtonDetail[0].Discription == string.Empty) Btn.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].ItemName; else Btn.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].Discription;
                        byte[] imgbyte = objPosShortcutHelper.lstFilteredButtonDetail[0].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])objPosShortcutHelper.lstFilteredButtonDetail[0].ImageByte : new byte[0];
                        if (imgbyte.Length > 1)
                        {
                            Btn.ImageList = ImgLstButton;
                            Btn.ImageList.ImageSize = new Size(75, 50);
                            Btn.ImageAlign = ContentAlignment.TopCenter;
                            Btn.ImageIndex = ImgLstButton.Images.Count - 1;
                        }
                        else
                        {
                            Btn.ImageList = null;
                        }

                    }
                    else
                    {
                        Control[] cn;
                        string str = "Btn_Add" + objPosShortcutHelper.lstFilteredButtonDetail[0].ShortCut;
                        System.Windows.Forms.Button Btn;
                        cn = addctr.Find(str, true);
                        Btn = (Button)cn[0];
                        Btn.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].ItemName;
                    }
                }

            }

        }
        #endregion

        #region FillData
        private void FillData(int ButtonNo, string AdditionFlag)
        {
            try
            {

                ButtonSelection(ButtonNo, AdditionFlag);
                if (AdditionFlag == "Y")
                {
                    ButtonSelection(ButtonNo, AdditionFlag);

                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = ButtonNo;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 1;
                    objPosShortcutHelper.FilterButtonList();
                    if (objPosShortcutHelper.lstFilteredButtonDetail.Count > 0)
                    {
                        Txt_AdditionDiscription.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].ItemName;
                    }
                    else
                    {
                        Txt_AdditionDiscription.Text = string.Empty;
                    }
                }
                else
                {
                    ButtonSelection(ButtonNo, AdditionFlag);
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.ShortCut = ButtonNo;
                    objPosShortcutHelper.objPOSShortCutBal.objPOSObject.AdditionFlag = 0;
                    objPosShortcutHelper.FilterButtonList();
                    if (objPosShortcutHelper.lstFilteredButtonDetail.Count > 0)
                    {
                        Cmb_Item.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].ItemName;
                        Txt_Discription.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].Discription;

                        objPosShortcutHelper.ButtonImage = objPosShortcutHelper.lstFilteredButtonDetail[0].ImageByte.GetType() != typeof(System.DBNull) ? (byte[])objPosShortcutHelper.lstFilteredButtonDetail[0].ImageByte : new byte[0];
                        if (objPosShortcutHelper.ButtonImage.Length > 1)
                        {
                            Bitmap bmp;
                            MemoryStream ms = new MemoryStream(objPosShortcutHelper.ButtonImage, true);
                            bmp = (Bitmap)Image.FromStream(ms);
                            PicImage.Image = bmp;
                            txtImagePath.Text = objPosShortcutHelper.lstFilteredButtonDetail[0].ImagePath;
                        }
                        else
                        {
                            PicImage.Image = null;
                            txtImagePath.Text = string.Empty;
                        }
                        if (objPosShortcutHelper.lstFilteredButtonDetail[0].ShowPricePopup)
                        {
                            varPrice.Checked = true;
                        }
                        else
                        {
                            varPrice.Checked = false;
                        }
                    }
                    else
                    {
                        PicImage.Image = null;
                        txtImagePath.Text = string.Empty;
                        Cmb_Item.SelectedItem = null;
                        Txt_Discription.Text = string.Empty;
                    }

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region ButtonSelection
        private void ButtonSelection(int ButtonNo, string AdditionFlag)
        {
            try
            {
                Control.ControlCollection ctrcol;
                if (AdditionFlag == "Y")
                {
                    ctrcol = Grb_AdditionButton.Controls;
                    string buttonname = "Btn_Add" + ButtonNo.ToString();
                    Control ctr = (Button)ctrcol.Find(buttonname, true)[0];
                    ctr.Select();
                }
                else
                {
                    double index = Math.Ceiling(Convert.ToDouble(ButtonNo) / 18);
                    Tab_ShortCut.SelectedIndex = int.Parse((index - 1).ToString());
                    ctrcol = Tab_ShortCut.SelectedTab.Controls;
                    string buttonname = "Btn" + ButtonNo.ToString();
                    Control ctr = (Button)ctrcol.Find(buttonname, true)[0];
                    ctr.Select();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion






        #endregion

        #region "Barcode"

        #region KeyPress
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode") return;

        //    if (ScanValue == string.Empty || ScanValue.Length == 0)
        //    {
        //        //Enable to Timecheck
        //        ScanTimingCheck = true;
        //        ScanLetterStartTime = DateTime.Now;
        //        ScanValue = ScanValue + e.KeyChar.ToString();
        //        return;
        //    }
        //    ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //    if (ScanTimingCheck && ScanValue.Length < 7)
        //    {
        //        //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //        if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //        if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            KeyboardmaxCount = KeyboardmaxCount + 1;
        //        }
        //        else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //        }
        //        else
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //    }
        //    if (ScanValue.Length > 6)
        //    {
        //        lastFocusedControl = this.ActiveControl;
        //        if (lastFocusedControl != null)
        //        { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

        //        txtBarcode.Focus();
        //        //e.Handled = true;
        //    }
        //    //Cal Event Again
        //    base.OnKeyPress(e);
        //}

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode")
        //    {
        //        return;
        //    }

        //    if (ScanValue == string.Empty || ScanValue.Length == 0)
        //    {
        //        //Enable to Timecheck
        //        ScanTimingCheck = true;
        //        ScanLetterStartTime = DateTime.Now;
        //        ScanValue = ScanValue + e.KeyChar.ToString();
        //        return;
        //    }
        //    ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //    if (ScanTimingCheck && ScanValue.Length < 7)
        //    {
        //        //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //        if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //        if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            KeyboardmaxCount = KeyboardmaxCount + 1;
        //        }
        //        else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //        }
        //        else
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //    }
        //    if (ScanValue.Length> 6)
        //    {
        //        lastFocusedControl = this.ActiveControl;
        //        if (lastFocusedControl != null)
        //        { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

        //        txtBarcode.Focus();
        //        //e.Handled = true;
        //    }
        //    //Cal Event Again
        //    base.OnKeyPress(e);
        //}


        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{

        //    try
        //    {
        //        if (this.ActiveControl.Name == "txtBarcode") return;

        //        if (this.ActiveControl.Name == "txtBarcode")
        //        {
        //            ScanValue = string.Empty;
        //            return;
        //        }
        //        if (ScanValue == string.Empty || ScanValue.Length == 0)
        //        {
        //            //Enable to Timecheck
        //            ScanTimingCheck = true;
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            return;
        //        }
        //        ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
        //        if (ScanTimingCheck && ScanValue.Length < 7)
        //        {
        //            if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //                KeyboardmaxCount = 0; return;
        //            }
        //            if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //                KeyboardmaxCount = KeyboardmaxCount + 1;
        //            }
        //            else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //            }
        //            else
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //                KeyboardmaxCount = 0; return;
        //            }
        //        }
        //        if (ScanValue.Length == 6)
        //        {
        //            //qtyEnter = false;
        //            lastFocusedControl = this.ActiveControl;
        //            if (lastFocusedControl != null)
        //            { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }
        //            // txtBarcode.Text = ScanValue;
        //            txtBarcode.Focus();

        //            //e.Handled = true;
        //        }



        //        base.OnKeyPress(e);
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " OnKeyPress Event");
        //    }
        //}

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (this.ActiveControl.Name == "txtBarcode") return;

                if (ScanValue == string.Empty || ScanValue.Length == 0)
                {
                    //Enable to Timecheck
                    ScanTimingCheck = true;
                    ScanLetterStartTime = DateTime.Now;
                    ScanValue = ScanValue + e.KeyChar.ToString();
                    KeyboardmaxCount = 0;
                    return;
                }
                ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
                if (ScanTimingCheck && ScanValue.Length < 7)
                {
                    //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
                    if (KeyboardmaxCount > 4 && ScanValue.Length > 1)
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                    //if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
                    if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds < GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                        KeyboardmaxCount = KeyboardmaxCount + 1;
                    }
                    else if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval))
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = ScanValue + e.KeyChar.ToString();
                    }
                    else
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                    }
                }
                if (ScanValue.Length == 6)
                {
                    lastFocusedControl = this.ActiveControl;
                    if (lastFocusedControl != null)
                    { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }

                    txtBarcode.Focus();
                    //e.Handled = true;
                }
                //Cal Event Again
                base.OnKeyPress(e);

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " OnKeyPress Event");
            }
        }
        #endregion

        #region "KeyUPEvents"
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrMsg(this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "pos Shortcut screen", "txtBarcode_KeyUp");
            }
        }
        #endregion

        #region Timer Tick Event

        //private void tmrBarcode_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ScannerCount += 1;
        //        if (lastFocusedControl != null)
        //        {
        //            lastFocusedControl.Text = lastfocusedvalue;
        //            lastFocusedControl = null;
        //        }
        //        if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
        //        {

        //            string barcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //            barcode = barcode.Replace("\r", "");
        //            barcode = barcode.Replace("~", "");
        //            if (barcode.Length > 13)
        //            {
        //                barcode = barcode.Substring(1, barcode.Length - 1);
        //            }

        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                Txt_Discription.Text = string.Empty;
        //                ClearBarcodeValues();
        //                Cmb_Item.Focus();

        //            }
        //            else
        //            {
        //                if (GeneralFunction.Question("NotAvailableBarcode", "POS Shortcuts") == DialogResult.Yes)
        //                {
        //                    ItemCard frmItem = new ItemCard();
        //                    GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                    frmItem.ShowDialog();
        //                    GeneralFunction.PurchaseBarcode = string.Empty;
        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    ClearBarcodeValues();
        //                    Cmb_Item.Focus();
        //                }
        //            }

        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //        }
        //        KeyboardmaxCount = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        //GeneralFunction.ErrMsg(this.Text);
        //        GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }

        //}


        private void tmrBarcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null)
                {
                    lastFocusedControl.Text = lastfocusedvalue;
                    lastFocusedControl = null;
                }
                if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
                {
                    tmrBarcode.Enabled = false;
                    string barcode = Convert.ToString(txtBarcode.Text);
                    //if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
                    //{
                    //    barcode = ScanValue + barcode;
                    //}

                    if (barcode.Length < 12)
                    {
                        barcode = ScanValue + barcode;
                    }

                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());

                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        Cmb_Item.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                        Txt_Discription.Text = string.Empty;
                        ClearBarcodeValues();
                        Cmb_Item.Focus();

                    }
                    else
                    {
                        if (GeneralFunction.Question("NotAvailableBarcode", "POS Shortcuts") == DialogResult.Yes)
                        {
                            ItemCard frmItem = new ItemCard();
                            GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                            frmItem.ShowDialog();
                            GeneralFunction.PurchaseBarcode = string.Empty;
                            ClearBarcodeValues();
                        }
                        else
                        {
                            ClearBarcodeValues();
                            Cmb_Item.Focus();
                        }
                    }

                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
                }
                KeyboardmaxCount = 0;
            }
            catch (Exception ex)
            {
                tmrBarcode.Enabled = false;
                ClearBarcodeValues();
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "POS Shortcuts", "timer1_Tick");
                throw ex;
            }
        }
        #endregion

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
        }

        # endregion

        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button || ctrl is Label || ctrl is CheckBox || ctrl is RadioButton || ctrl is TabControl)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

        private void Grb_AdditionButton_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cmb_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Cmb_Item.SelectedIndex > -1)
                {
                    Txt_Discription.Focus();
                    Txt_Discription.SelectAll();
                }
            }
        }

        private void Cmb_Item_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (Cmb_Item.SelectedIndex > -1)
                {
                    Txt_Discription.Focus();
                    Txt_Discription.SelectAll();
                }
            }
        }

        private void POS_Shortcuts_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPosShortcutHelper.lstButtonDetailsOne = null;
            objPosShortcutHelper.lstFilteredButtonDetail = null;
            objPosShortcutHelper.lstTableDetails = null;
            objPosShortcutHelper.lstFilteredTableDetail = null;
            this.Dispose();
        }

    }
}
