using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using CommonHelper;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Spoiled_Item : Form, IDisposable
    {

        #region Declaration
        SpoiledItemHelper ObjHelper;

        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, check, iscount = false, isfrominsert = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        public string FindSpoiledNo = string.Empty;
        bool CheckPackageQty = false;
        DataTable dtallBarcode;
        DataTable dtItemForSpoiled = new DataTable();
        //  bool IsItemLoadEvent = false;
        #endregion

        #region Constructor
        public Spoiled_Item()
        {
            InitializeComponent();
            this.Activate();
            SetLanguage();
            setFont();
            ObjHelper = new SpoiledItemHelper();
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbItem.DisplayMember = "ItemName";
            cmbItemNo.ValueMember = cmbItem.ValueMember = "ItemsId";
            cmbItemNo.DisplayMember = "ItemNumber";
            LoadDetails();
            UserLimitation();
            timer1.Interval = 650;
            timer1.Tick += blinkTextbox;
            timer1.Enabled = true;
            // txtPack.SelectedIndex = 0;
        }
        #endregion

        #region Events

        #region Load Event
        private void Spoiled_Item_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                if (FindSpoiledNo.Length != 0 && FindSpoiledNo != null)
                {
                    txtNewInvoiceNo.Text = FindSpoiledNo;
                    SplitID();
                }
                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 20-Nov-2014 by Seenivasan
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 20-Nov-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Name, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Button Event
        private void btnItemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjHelper.ObjItemInfo.Visible == false)
                {
                    if (cmbItem.Text != string.Empty && cmbItem.Text != null)
                    {
                        ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt16(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
                        ObjHelper.ObjItemInfo.ItemName = cmbItem.Text;
                        ObjHelper.ObjItemInfo.ShowDialog();
                    }
                    else
                    {
                        if (dgvSpoiledItem.SelectedRows.Count > 0)
                        {
                            ObjHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgvSpoiledItem.SelectedRows[0].Cells["itemno"].Value);
                            ObjHelper.ObjItemInfo.ItemName = dgvSpoiledItem.SelectedRows[0].Cells["item_name"].Value.ToString();
                            ObjHelper.ObjItemInfo.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnClose_Click");
            }
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            try
            {
                ItemCard frmItemCard = new ItemCard();
                frmItemCard.ShowDialog();
                cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);

                //cmbItem.DataSource = cmbItemNo.DataSource = ObjHelper.GetItemDetails();//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                //cmbItem.DataSource = cmbItemNo.DataSource = ObjHelper.GetItemDetails().OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                ItemDetailsLoad();
                cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnItemCard_Click");

            }
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseReturnInvoice frmReturnInvoice = new PurchaseReturnInvoice();
                frmReturnInvoice.ShowDialog();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnReturnItem_Click");

            }
        }

        private void btnFindInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Find_Sales_Invoice frmFind = new Find_Sales_Invoice();
                frmFind.ShowDialog();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnFindInvoice_Click");

            }
        }

        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();//Added on 28-June-2014 by Seenivasan for Assigning Notes value to OrderNote object
                ObjHelper.IDFlag = Convert.ToInt32(((Button)sender).Tag);
                ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                ObjHelper.NavigationEvent();
                ObjHelper.AssignDataGridSource(dgvSpoiledItem);
                //setGridStatus();
                ClearAll();
                this.SetControlFromObject();
                cmbItem.SelectedIndex = cmbItemNo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ObjectHelper.PurchaseObjectClass obj = new PurchaseObjectClass();
            try
            {
                ObjHelper.btnNewInvoice();
                if (ObjHelper.isProcessTrue)
                {

                    // SetControlFromObject(); commeneted on 08 may 2014
                    ClearAll();
                    txtInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo.ToString();
                    if (ObjHelper.ObjBALClass.ObjOrder.Year == ObjHelper.CurrentYear)
                        txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString();
                    else
                        txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString() + '-' + ObjHelper.ObjBALClass.ObjOrder.Year.ToString();

                    ObjHelper.AssignDataGridSource(dgvSpoiledItem);
                    txtNote.Enabled = true;//Added on 28-June-2014 for Enabling Note field on New invoice
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.New), txtInvoiceNo.Text, "Order", "New spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                obj = null;
            }
        }

        private void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSpoiledItem.BackgroundColor != Color.Gray)
                {
                    SetObjectFromControl();//Added on 28-June-2014 by Seenivasan for assigning Notes value in OrderDate object
                    if (txtInvoiceNo.Text != string.Empty)
                    {
                        if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                        {
                            if (GeneralFunction.Question("AlertCloseInvoice", "SpoiledInvoice") == DialogResult.Yes)
                            {
                                ObjHelper.btnCloseInvoice();
                            }
                            else
                                return;
                        }
                        else
                            ObjHelper.btnCloseInvoice();
                        if (ObjHelper.isProcessTrue == true)
                        {
                            setGridStatus();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), txtInvoiceNo.Text, "Order", "Save(close) spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else { return; }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSpoiledItem.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    if (cmbItem.SelectedIndex > -1)
                        ObjHelper.btnAddItemInvoice();
                    if (ObjHelper.isProcessTrue)
                    {
                        ClearAll();
                        txtTotalAmount.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString();
                        ObjHelper.AssignDataGridSource(dgvSpoiledItem);
                        cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
                        isfrominsert = true;
                        cmbItem.Focus();
                        ObjHelper.isProcessTrue = false;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), cmbItem.Text, "Order", "Insert spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    }
                    else
                    {
                        if (ObjHelper.ControlName != string.Empty && ObjHelper.ControlName.Length != 0)
                        {
                            foreach (Control ctl in panel1.Controls)
                            {
                                if (ctl.Name == ObjHelper.ControlName)
                                    ctl.Focus();
                            }
                            ObjHelper.ControlName = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                txtQty.Text = (txtQty.Text != string.Empty) ? txtQty.Text : "0";
                if (ObjHelper.isPackage == false)
                {
                    this.SetObjectFromControl();

                    ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                    ObjHelper.isPackage = true;
                    // this.SetControlFromObject();
                    txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("#####0.000");
                    txtRemaining.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
                    if (ObjHelper.isPackage)
                        txtBox.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                    else
                        txtBox.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();


                }
                else
                {
                    this.SetObjectFromControl();
                    //ObjHelper.ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty ? "0" : txtCost.Text);
                    //ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(txtQty.Text == string.Empty ? "0" : txtQty.Text);
                    //ObjHelper.ObjBALClass.ObjOrder.ItemPackage = txtPack.Text == string.Empty ? 0 : Convert.ToInt32(txtPack.Text);
                    ObjHelper.BoxPieceAction();
                    btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                    ObjHelper.isPackage = false;
                    // this.SetControlFromObject();
                    txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("#####0.000");
                    txtRemaining.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
                    if (ObjHelper.isPackage)
                        txtBox.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                    else
                        txtBox.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();


                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnModifyInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserScreenLimidations.ModifyInvoice == true)
                    check = true;
                else if (UserScreenLimidations.ModifyTodayInvoice == true)
                {
                    if (DateTime.Compare(Convert.ToDateTime(dtpDate.Value), Convert.ToDateTime(DateTime.Now.ToShortDateString())) == 0)
                        check = true;
                    else
                        check = false;
                }
                else
                    check = false;
                if (check)
                {
                    //if (dgvSpoiledItem.BackgroundColor != Color.Beige) ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                    if (dgvSpoiledItem.BackgroundColor != Color.WhiteSmoke)
                    {
                        ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                        if (ObjHelper.btnModifyInvoice())
                        {
                            setGridStatus();
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Modify), txtInvoiceNo.Text, "Order", "Modify spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NotClosedInvoice"), this.Text);
                }
                else
                    GeneralFunction.Information("RightsModifyInvoice", "SpoiledInvoice");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSpoiledItem.BackgroundColor != Color.Gray)
                {
                    if (dgvSpoiledItem.Rows.Count > 0)
                    {
                        if (GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice != "Y")
                        {
                            if (GeneralFunction.Question("AlertDeleteSelectedRow", "SpoiledInvoice") == DialogResult.Yes)
                            {
                                SetSelectedGridData();
                            }
                            else if (GeneralFunction.Question("AlertDeleteWholeRow", "SpoiledInvoice") == DialogResult.Yes)
                            {
                                SetWholeGridData();
                            }

                        }
                        else
                        {
                            if (GeneralFunction.Question("AlertDeleteSelectedRow", "SpoiledInvoice") == DialogResult.Yes)
                            {
                                SetSelectedGridData();
                            }
                        }
                        txtTotalAmount.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), "Spoiled Item", "Order", "Delete spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                    }
                    else
                    {
                        GeneralFunction.Information("EmptyInvoiceList", "SpoiledInvoice");
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnDeleteItem_Click");

            }
        }
        #endregion

        private void txtNote_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                chkNote.Checked = true;
                txtNote.Enabled = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtNote_MouseClick");

            }
        }

        private void txtNewInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && UserScreenLimidations.InvoiceNavigation)
                    SplitID();
                else if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 8) && (e.KeyChar != 45))
                    e.Handled = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtNewInvoiceNo_KeyPress");

            }
        }

        #region IndexChanged Event

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.SelectedIndex != -1)
                {

                    // this.SetObjectFromControl(); commented on 08 may 2014
                    ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
                    ObjHelper.ObjBALClass.ObjOrder.ItemName = cmbItem.Text.ToString();
                    ObjHelper.ItemBinding();
                    //  ClearAll();commented on 08 may 2014
                    this.SetControlFromObject();
                    cmbItem.Text = ObjHelper.ObjBALClass.ObjOrder.ItemName;
                    //  btnBox_Click(sender , new EventArgs());
                    RTxt_NoteAlerts.Text = string.Empty;
                    if (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock <= ObjHelper.ObjBALClass.ObjOrder.Reorder)
                    {
                        CustomNotesAlerts.Set_ReorderItemsIn_NoteAlert(RTxt_NoteAlerts);
                    }
                    if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTxt_NoteAlerts); }
                    SetRowColor(cmbItem.Text);
                    //txtQty.Text = "1";
                    txtQty.Focus();
                }
                else
                {
                    ClearAll();
                    RTxt_NoteAlerts.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItem_SelectedIndexChanged");
            }
        }
        public void SetRowColor(string ComboItemName)
        {
            if (dgvSpoiledItem.Rows.Count == 0)
                return;
            for (int i = 0; i < dgvSpoiledItem.Rows.Count; i++)
            {
                dgvSpoiledItem.Rows[i].Selected = false;
                if (dgvSpoiledItem.Rows[i].Cells["item_name"].Value.ToString() == ComboItemName)
                {
                    dgvSpoiledItem.Rows[i].DefaultCellStyle.BackColor = SystemColors.MenuHighlight;
                    dgvSpoiledItem.FirstDisplayedScrollingRowIndex = i;
                }
            }

        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cmbCategory.SelectedIndex != -1 && cmbCategory.Text != string.Empty)
                //{
                //    ObjHelper.ObjBALClass.ObjOrder.CategoryNo = Convert.ToInt32(cmbCategory.SelectedValue);
                //    ObjHelper.FilterItemBasedonCategory();
                //    //cmbItem.DataSource = ObjHelper.FilterItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                //    cmbItem.DataSource = ObjHelper.FilterItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                //    cmbItemNo.DataSource = ObjHelper.FilterItemList.Where(a => a.ItemNumber != string.Empty).ToList();
                //    cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
                //}
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbCategory_SelectedIndexChanged");

            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cmbCompany.SelectedIndex != -1 && cmbCompany.Text != string.Empty)
                //{
                //    ObjHelper.ObjBALClass.ObjOrder.CompanyNo = (Convert.ToInt32(cmbCompany.SelectedValue));
                //    ObjHelper.FilterItemBasedonCompany();
                //    //cmbItem.DataSource = ObjHelper.FilterItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                //    cmbItem.DataSource = ObjHelper.FilterItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                //    cmbItemNo.DataSource = ObjHelper.FilterItemList.Where(a => a.ItemNumber != string.Empty).ToList();
                //    cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
                //}
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbCompany_SelectedIndexChanged");

            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemNo.SelectedIndex > -1)
                    //cmbItem.Text = cmbItemNo.SelectedValue.ToString();
                    cmbItem.SelectedValue = cmbItemNo.SelectedValue;
                else
                    ClearAll();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemNo_SelectedIndexChanged");

            }
        }

        private void chkSpolied_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSpolied.Checked)
                {
                    ObjHelper.OnlySpoiledItem();
                    //cmbItemNo.DataSource = cmbItem.DataSource = ObjHelper.FilterItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                    cmbItem.DataSource = cmbItemNo.DataSource = null;
                    cmbItem.DisplayMember = "ItemName";
                    cmbItemNo.ValueMember = cmbItem.ValueMember = "ItemNo";
                    cmbItemNo.DisplayMember = "ItemNumber";
                    cmbItem.DataSource = ObjHelper.FilterItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                    cmbItemNo.DataSource = ObjHelper.FilterItemList.Where(a => a.ItemNumber != null).ToList();
                    cmbItem.SelectedIndex = cmbItemNo.SelectedIndex = -1;
                }
                else
                {
                    //cmbItemNo.DataSource = cmbItem.DataSource = ObjHelper.ItemList;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                    cmbItem.DataSource = cmbItemNo.DataSource = null;
                    cmbItem.DisplayMember = "ItemName";
                    cmbItemNo.ValueMember = cmbItem.ValueMember = "ItemsId";
                    cmbItemNo.DisplayMember = "ItemNumber";
                    //cmbItem.DataSource = ObjHelper.ItemList.OrderBy(n => n.ItemName).ToList();//Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
                    //cmbItemNo.DataSource = ObjHelper.ItemList.Where(a => a.ItemNumber != string.Empty).ToList();
                    
                    DataView dvfilter = new DataView(dtItemForSpoiled);
                    dvfilter.RowFilter = "ItemNumber<>''";
                    cmbItem.DataSource = dtItemForSpoiled;
                    cmbItemNo.DataSource = dvfilter.ToTable();
                    cmbItem.SelectedIndex = cmbItemNo.SelectedIndex = -1;
                }
                if (chkSpolied.Checked)
                {
                    if ((GeneralFunction.Question("AddallSpoiledItems", "SpoiledInvoice")) == DialogResult.Yes)
                    {
                        if (dgvSpoiledItem.BackgroundColor != Color.Gray)
                        {
                            this.SetObjectFromControl();
                            ObjHelper.InsertSpoiledInvoice();
                            if (ObjHelper.isProcessTrue)
                            {
                                ClearAll();
                                txtTotalAmount.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString();
                                ObjHelper.AssignDataGridSource(dgvSpoiledItem);
                                cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
                                ObjHelper.isProcessTrue = false;
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), cmbItem.Text, "Order", "Insert spoiled invoice details", Convert.ToInt32(InvoiceAction.Yes));
                            }
                        }
                        else { GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CantModifyClosedInvoice"), this.Text); }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " chkSpolied_CheckedChanged");

            }

        }
        #endregion
        #endregion

        #region Methods
        private void LoadDetails()
        {
            cmbCategory.DataSource = GeneralObjectClass.CategoryList;
            cmbCategory.SelectedIndex = 0;
           // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
            cmbCompany.DataSource = GeneralObjectClass.CompanyList;
            cmbCompany.SelectedIndex = 0;
           // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            //---------------------Commented on 22 may 2014-----------Called another stored procedure to get the item stock > zero 
            //cmbItem.DataSource = ObjHelper.GetItemDetails();
            //cmbItem.SelectedIndex = -1;
            //cmbItemNo.BindingContext = new BindingContext();
            //cmbItemNo.DataSource = ObjHelper.GetItemDetails().Where(i => i.ItemNumber != string.Empty).ToList();
            //cmbItemNo.SelectedIndex = -1;


            List<PurchaseObjectClass> lstPurObj = new List<PurchaseObjectClass>();
            //cmbItem.DataSource = ObjHelper.GetItemDetails();
            //lstPurObj = ObjHelper.GetItemDetails();
            ItemDetailsLoad();

            //----------------------------------------------------
            ObjHelper.LoadSpoiledInvoiceData();
            ObjHelper.AssignDataGridSource(dgvSpoiledItem);
            //setGridStatus();
            SetControlFromObject();
            Lbl_user.Text = GeneralFunction.UserName;
            cmbItem.Focus();
            if (GeneralOptionSetting.FlagAlertPayDates == "Y") { CustomNotesAlerts.SetPaymentDateIn_NoteAlert(RTxt_NoteAlerts); }
            cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            cmbCategory.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged += new EventHandler(cmbCompany_SelectedIndexChanged);
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
            ScanValue = "0";
            ScanTimingCheck = true;
            ScanLetterStartTime = DateTime.Now;
        }

        private void ItemDetailsLoad()
        {
            dtItemForSpoiled = ObjHelper.GetAllItemInStock();

            //cmbItem.DataSource = lstPurObj;//Commented on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending
            cmbItem.DataSource = dtItemForSpoiled;//lstPurObj.OrderBy(n => n.ItemName).ToList(); //Added on 27-June-2017 by Seenivasan for Sorting teh ItemName ascending

            cmbItem.SelectedIndex = -1;
            DataView dvfilter = new DataView(dtItemForSpoiled);
            dvfilter.RowFilter = "ItemNumber<>''";
            cmbItemNo.BindingContext = new BindingContext();
            //cmbItemNo.DataSource = ObjHelper.GetItemDetails().Where(i => i.ItemNumber != string.Empty).ToList();
            cmbItemNo.DataSource = dvfilter.ToTable(); //lstPurObj.Where(i => i.ItemNumber != string.Empty).ToList();

            cmbItemNo.SelectedIndex = -1;
        }

        private void SetLanguage()
        {
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("PrintF6");
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnI");
            this.Text = Additional_Barcode.GetValueByResourceKey("SpoiledItem");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("NewInvoice");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblSerialno.Text = Additional_Barcode.GetValueByResourceKey("SerialNo");
            lblTotalAmount.Text = Additional_Barcode.GetValueByResourceKey("TAmount");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblRemaining.Text = Additional_Barcode.GetValueByResourceKey("Remaining");
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey("Expiry");
            btnAddItem.Text = Additional_Barcode.GetValueByResourceKey("ItemSpoiled");
            btnBox.Text = Additional_Barcode.GetValueByResourceKey("BoxF9");
            btnCloseInvoice.Text = Additional_Barcode.GetValueByResourceKey("CloseInvoice");
            btnDeleteItem.Text = Additional_Barcode.GetValueByResourceKey("DeleteF2");
            btnExpiryList.Text = Additional_Barcode.GetValueByResourceKey("ExpiryList");
            btnFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindInvoice");
            btnItemInfo.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11");
            btnModifyInvoice.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice");
            chkHideLogo.Text = Additional_Barcode.GetValueByResourceKey("HidenLogo");
            chkNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");
            chkSpolied.Text = Additional_Barcode.GetValueByResourceKey("Spoiled");
            grbNotesAndAlerts.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            dgvSpoiledItem.Columns["ItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvSpoiledItem.Columns["item_name"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
            dgvSpoiledItem.Columns["exp_date"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvSpoiledItem.Columns["package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvSpoiledItem.Columns["quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgvSpoiledItem.Columns["unit_Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvSpoiledItem.Columns["sub_total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvSpoiledItem.Columns["box"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            dgvSpoiledItem.Columns["in_time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgvSpoiledItem.Columns["user"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgvSpoiledItem.Columns["SerialNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
        }

        private void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim() == string.Empty ? "0" : txtInvoiceNo.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemName = cmbItem.Text.ToString();
            ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
            ObjHelper.ObjBALClass.ObjOrder.ItemNumber = cmbItemNo.Text;
            ObjHelper.ObjBALClass.ObjOrder.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty ? "0" : txtCost.Text);
            ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(txtQty.Text == string.Empty ? "0" : txtQty.Text);
            ObjHelper.ObjBALClass.ObjOrder.OrderNote = txtNote.Text.Trim();
            ObjHelper.ObjBALClass.ObjOrder.OrderDate = dtpDate.Value;
            if (ObjHelper.ObjBALClass.ObjOrder.ItemType == 1)
            {
                ObjHelper.ObjBALClass.ObjOrder.ItemExpiryDate = Convert.ToDateTime(cmbExpiry.SelectedValue).Date;
                ObjHelper.ObjBALClass.ObjOrder.ItemSerialNo = "0";
            }
            else
                ObjHelper.ObjBALClass.ObjOrder.ItemSerialNo = cmbSerialno.SelectedValue == null ? string.Empty : cmbSerialno.SelectedValue.ToString();
            //////ObjHelper.ObjBALClass.ObjOrder.ItemSerialNo = Convert.ToInt64(cmbSerialno.SelectedValue);
            //  ObjHelper.ObjBALClass.ObjOrder.ItemStock = Convert.ToInt32(txtBox.Text);
            if (ObjHelper.isPackage == false)
                ObjHelper.ItemCost = Convert.ToDecimal(txtCost.Text);
            else
                ObjHelper.ItemUnitPrice = Convert.ToDecimal(txtCost.Text);
            //ObjHelper.ObjBALClass.ObjOrder.BarcodeID = txtPack.SelectedIndex == -1 ? 0 : Convert.ToInt32(txtPack.SelectedValue);
            ObjHelper.ObjBALClass.ObjOrder.ItemPackage = txtPack.Text == string.Empty ? 0 : Convert.ToInt32(txtPack.Text);
        }

        private void SetControlFromObject()
        {
            txtInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo.ToString();
            if (ObjHelper.ObjBALClass.ObjOrder.Year == ObjHelper.CurrentYear)
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString();
            else
                txtNewInvoiceNo.Text = ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID.ToString() + '-' + ObjHelper.ObjBALClass.ObjOrder.Year.ToString();
            cmbItem.SelectedValue = ObjHelper.ObjBALClass.ObjOrder.ItemNo == null ? 0 : ObjHelper.ObjBALClass.ObjOrder.ItemNo;
            cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            cmbItemNo.SelectedValue = ObjHelper.ObjBALClass.ObjOrder.ItemNo.ToString() == "0" ? 0 : ObjHelper.ObjBALClass.ObjOrder.ItemNo;
            cmbItemNo.Text = ObjHelper.ObjBALClass.ObjOrder.ItemNumber == null ? string.Empty : ObjHelper.ObjBALClass.ObjOrder.ItemNumber.ToString();
            cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("#####0.000");
            txtRemaining.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
            txtNote.Text = ObjHelper.ObjBALClass.ObjOrder.OrderNote;
            if (ObjHelper.isPackage)
                txtBox.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
            else
                txtBox.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0 ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage)).ToString();

            txtTotalAmount.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotal.ToString();
            if (ObjHelper.ObjBALClass.ObjOrder.ItemType == 1)
            {
                cmbExpiry.Enabled = true;
                cmbSerialno.Visible = lblSerialno.Visible = false;
                cmbExpiry.ValueMember = cmbExpiry.DisplayMember = "ItemExpiryDate";
                cmbExpiry.DataSource = ObjHelper.Expiry.Select(i => i.ItemExpiryDate).Distinct().ToList();

            }
            else if (ObjHelper.ObjBALClass.ObjOrder.ItemType == 2)
            {
                cmbSerialno.Visible = true;
                lblSerialno.Visible = true;
                cmbSerialno.DisplayMember = cmbSerialno.ValueMember = "ItemSerialNo";
                cmbSerialno.DataSource = ObjHelper.Expiry;

                cmbExpiry.DataSource = null;
                cmbExpiry.Enabled = false;
            }
            dtpDate.Value = ObjHelper.ObjBALClass.ObjOrder.OrderDate.Value;
            if (ObjHelper.PackageQty.Count > 0)
            {

                txtPack.DisplayMember = "ItemPackage";
                txtPack.ValueMember = "BarcodeID";
                txtPack.DataSource = ObjHelper.PackageQty.Select(a => a.ItemPackage).Distinct().ToList();
                //txtPack.SelectedIndex = 0;
                CheckPackageQty = true;///to avoid the package qty selected index event 

            }
            else
                txtPack.DataSource = null;
            txtPack.Text = ObjHelper.ObjBALClass.ObjOrder.ItemPackage.ToString();
            CheckPackageQty = false;
        }

        private void SetSelectedGridData()
        {
            for (int i = 0; i < dgvSpoiledItem.SelectedRows.Count; i++)
            {
                ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(dgvSpoiledItem.SelectedRows[i].Cells["ItemNo"].Value);
                ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
                ObjHelper.ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(dgvSpoiledItem.SelectedRows[i].Cells["unit_price"].Value);
                ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(dgvSpoiledItem.SelectedRows[i].Cells["quantity"].Value);
                ObjHelper.ObjBALClass.ObjOrder.BarcodeID = Convert.ToInt32(dgvSpoiledItem.SelectedRows[i].Cells["BarcodeID"].Value);
                if (ObjHelper.btnDeleteInvoice())
                    ObjHelper.AssignDataGridSource(dgvSpoiledItem);
            }
        }

        private void SetWholeGridData()
        {
            //for (int i = 0; i <= dgvSpoiledItem.Rows.Count; i++)
            //{
            //    i = 0;
            //    dgvSpoiledItem.Rows[i].Selected = true;
            //    ObjHelper.ObjBALClass.ObjOrder.ItemNo = Convert.ToInt32(dgvSpoiledItem.Rows[i].Cells["ItemNo"].Value);
            //    ObjHelper.ObjBALClass.ObjOrder.OrderInvoiceNo = Convert.ToInt32(txtInvoiceNo.Text);
            //    ObjHelper.ObjBALClass.ObjOrder.ItemUnitPrice = Convert.ToDecimal(dgvSpoiledItem.Rows[i].Cells["unit_price"].Value);
            //    ObjHelper.ObjBALClass.ObjOrder.ItemQuantity = Convert.ToInt32(dgvSpoiledItem.Rows[i].Cells["quantity"].Value);
            ObjHelper.DeleteWholeData();
            if (ObjHelper.isProcessTrue)
                ObjHelper.AssignDataGridSource(dgvSpoiledItem);
        }

        private void setGridStatus()
        {
            if (ObjHelper.ObjBALClass.ObjOrder.Status == 2)
            {
                dgvSpoiledItem.BackgroundColor = Color.Gray;
                dgvSpoiledItem.DefaultCellStyle.BackColor = Color.Gainsboro;
                txtNote.Enabled = false;
            }
            else if (ObjHelper.ObjBALClass.ObjOrder.Status == 1)
            {
                //dgvSpoiledItem.BackgroundColor = Color.Beige; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgvSpoiledItem.BackgroundColor = Color.WhiteSmoke;
                dgvSpoiledItem.DefaultCellStyle.BackColor = Color.White;
                txtNote.Enabled = true;
            }
        }

        private void ClearAll()
        {
            dtpDate.Value = DateTime.Now;
            // cmbItem.SelectedValueChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);
            cmbItem.SelectedIndex = -1;
            //  cmbItemNo.SelectedIndexChanged -= new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            //cmbItemNo.SelectedIndex = -1;
            txtCost.Text = "0.000";
            txtQty.Text = "1";
            txtRemaining.Text = "0";
            txtBox.Text = string.Empty;
            //txtTotalAmount.Text = "0.000";
            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
            ObjHelper.isPackage = false;
            cmbSerialno.DataSource = null;
            cmbSerialno.Visible = false;
            lblSerialno.Visible = false;
            //commented on 07 may 2014---------------------
            //  txtPack.Text = "0";
            /// txtPack.DataSource = null;
            /// //-------------------------------
            //txtPack.SelectedIndex = -1;this line commended on 27Aug2014 to refresh the pack
            txtPack.DataSource = null;//added on 27Aug2014
            cmbExpiry.DataSource = null;
            txtNote.Text = string.Empty; //Added on 28-June-2014 by Seenivasan for Clearing the Notes value on New invoice generation
            //ObjHelper.ObjBALClass.ObjOrder.OrderNote = string.Empty; //Added on 28-June-2014 by Seenivasan for Clearing the Notes value on New invoice generation
            //cmbItemNo.SelectedIndexChanged += new EventHandler(this.cmbItemNo_SelectedIndexChanged);
            //cmbItem.SelectedValueChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
            //  cmbItem.Focus();
        }

        private void SplitID()
        {
            if (txtNewInvoiceNo.Text.Contains('-'))
            {
                string[] id = txtNewInvoiceNo.Text.Split('-');
                ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(id[1]);
                ObjHelper.ObjBALClass.ObjOrder.Year = Convert.ToInt32(id[0]);
            }
            else
            {
                ObjHelper.ObjBALClass.ObjOrder.NewYearInvoiceID = Convert.ToInt32(txtNewInvoiceNo.Text);
                ObjHelper.ObjBALClass.ObjOrder.Year = (int)ObjHelper.CurrentYear;
            }
            ObjHelper.IDFlag = 0;
            ObjHelper.NavigationEvent();
            ObjHelper.AssignDataGridSource(dgvSpoiledItem);
            ///setGridStatus();---this method moved into ObjHelper.AssignDataGridSource(dgvSpoiledItem)
            ClearAll();
            this.SetControlFromObject();
            cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
        }
        #endregion

        private void Spoiled_Item_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information frmQuick = new Quick_Price_Information();
                    frmQuick.ShowDialog();
                }
                if (e.KeyData == Keys.F11 && btnItemInfo.Enabled)
                {
                    InvokeOnClick(btnItemInfo, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F4 && btnNew.Enabled && (!e.Alt))
                {
                    InvokeOnClick(btnNew, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F3 && btnAddItem.Enabled)
                {
                    btnAddItem_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2 && btnDeleteItem.Enabled)
                {
                    InvokeOnClick(btnDeleteItem, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F5 && btnCloseInvoice.Enabled)
                {
                    InvokeOnClick(btnCloseInvoice, EventArgs.Empty);
                }
                else if (e.KeyCode == Keys.F9 && btnBox.Visible==true)
                {
                    btnBox_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6 && btnPrint.Enabled)
                {
                    InvokeOnClick(btnPrint, EventArgs.Empty);
                }

                else { }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " Spoiled_Item_KeyDown");

            }
        }
        bool isFirst = false;
        string appval = "";
        private void Enter_KeyEvent(Object sender, KeyEventArgs e)
        {
            try
            {
                if (sender is ComboBox)
                {
                    //    if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                    //     (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                    //     && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                    //     && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                    //     && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
                    //    {
                    //        if (((ComboBox)sender).DataSource != null)
                    //        {
                    //            if (((ComboBox)sender).DroppedDown == true)
                    //                ((ComboBox)sender).DroppedDown = false;
                    //            if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                    //            {
                    //                cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //                cmbItem.SelectedText = ((char)e.KeyValue).ToString();
                    //                cmbItem.DroppedDown = true;
                    //                isFirst = true;
                    //                appval = ((char)e.KeyValue).ToString();

                    //            }
                    //            else
                    //            {
                    //                cmbItem.DroppedDown = false;
                    //                if (isFirst)
                    //                {
                    //                    cmbItem.SelectedText = appval.Substring(0, 1);
                    //                    isFirst = false;
                    //                }

                    //            }
                    //        }

                    //    }

                }



                //if (e.KeyValue == 40 || e.KeyValue == 38)
                //    iscount = true;
                if (((((Control)sender).Name == "cmbItem") && (e.KeyValue == 13) && (cmbItem.SelectedIndex != -1)) || ((((Control)sender).Name == "cmbItemNo") && (e.KeyValue == 13) && (cmbItemNo.SelectedIndex != -1)))
                {

                    //if (cmbSerialno.Visible)
                    //{
                    //    cmbSerialno.Focus();
                    //    cmbSerialno.SelectAll();
                    //}
                    //else
                    //{
                    //    txtQty.Focus();
                    //    txtQty.SelectAll();
                    //}
                }
                else if (((((Control)sender).Name == "cmbItem") && (e.KeyValue == 13) && (cmbItem.SelectedIndex == -1)) || ((((Control)sender).Name == "cmbItemNo") && (e.KeyValue == 13) && (cmbItemNo.SelectedIndex == -1)))
                {
                    //txtBarcode.Focus();
                    //if (((ComboBox)sender).DroppedDown == true)
                    //    ((ComboBox)sender).DroppedDown = false;
                }
                if (((Control)sender).Name == "cmbSerialno" && (e.KeyValue == 13) && (cmbSerialno.SelectedIndex > -1))
                {
                    txtQty.Focus();
                    txtQty.SelectAll();
                }
                if ((((Control)sender).Name == "txtCost") && (e.KeyValue == 13))
                {
                    txtQty.Focus();
                    txtQty.Select(0, txtQty.Text.Length);
                }
                if ((((Control)sender).Name == "txtQty") && (e.KeyValue == 13))
                {
                    btnAddItem_Click(sender, e);
                }
                //if (((Control)sender).Name == "cmbCategory" && e.KeyValue == 13)
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}
                //if (((Control)sender).Name == "cmbCompany" && e.KeyValue == 13)
                //{
                //    if (((ComboBox)sender).DroppedDown == true)
                //        ((ComboBox)sender).DroppedDown = false;
                //}

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " Enter_KeyEvent");

            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != ((Char)Keys.Back) && e.KeyChar != ((Char)Keys.Delete) || e.KeyChar == 46 || (txtQty.Text.Length > 7))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtQty_KeyPress");

            }
        }

        private void cmbItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 13)
                {
                    if (e.KeyChar != 13 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && (e.KeyChar < 111 || e.KeyChar > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
                    {
                        if (((ComboBox)sender).DataSource != null)
                        {
                            if (((ComboBox)sender).DroppedDown == true)
                                ((ComboBox)sender).DroppedDown = false;
                        }

                    }
                }
                //if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Delete))
                //{
                //    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("OnlyNumbersAllowed"), this.Text);
                //    e.Handled = true;
                //}this condition commended to fix the allow alpha numeric on 22Aug2014
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemNo_KeyPress");

            }
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            ItemQuantityCheck();
        }

        private void ItemQuantityCheck()
        {
            try
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    if (ObjHelper.isPackage == false)
                    {
                        //MTxt_Remaining.Text = Convert.ToString(int.Parse(MTxt_Box.Text) - (int.Parse(MTxt_Qty.Text) * objPurchase.InfoItemPackage));

                        txtRemaining.Text = Math.Floor(Convert.ToDouble(ObjHelper.ObjBALClass.ObjOrder.ItemStock - Convert.ToInt32(txtQty.Text == string.Empty ? "0" : txtQty.Text))).ToString();
                        if (ObjHelper.ObjBALClass.ObjOrder.ItemStock < Convert.ToInt32(txtQty.Text == string.Empty ? "0" : txtQty.Text))
                        {
                            txtQty.Text = txtRemaining.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
                        }
                    }
                    else
                    {
                        txtRemaining.Text = Convert.ToString((ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock - Convert.ToDecimal(txtQty.Text == string.Empty ? "0" : txtQty.Text)));
                        if (ObjHelper.ObjBALClass.ObjOrder.ItemStock < (txtQty.Text == string.Empty ? 0 : Convert.ToInt32(txtQty.Text)))
                        {
                            txtQty.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
                            txtRemaining.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                // GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtQty_KeyUp");

            }
        }

        private void blinkTextbox(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.BlinkText(e, RTxt_NoteAlerts);
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " blinkTextbox");

            }
        }

        private void UserLimitation()
        {
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            btnPrint.Enabled = (UserScreenLimidations.Print == true) ? true : false;
            btnFindInvoice.Enabled = (UserScreenLimidations.FindSaleInvoice == true) ? true : false;
            btnReturnItem.Enabled = (UserScreenLimidations.SaleReturnInvoice == true) ? true : false;
            btnItemCard.Enabled = (UserScreenLimidations.ItemCard == true) ? true : false;
            btnModifyInvoice.Enabled = ((UserScreenLimidations.ModifyInvoice == true) || (UserScreenLimidations.ModifyTodayInvoice == true)) ? true : false;
            Btn_Next.Visible = Btn_Previous.Visible = Btn_First.Visible = Btn_Last.Visible = UserScreenLimidations.InvoiceNavigation == true ? true : false;
            txtInvoiceNo.ReadOnly = UserScreenLimidations.InvoiceNavigation == true ? false : true;
            txtInvoiceNo.BackColor = Color.White;
            dgvSpoiledItem.Columns["ItemNumber"].Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            dgvSpoiledItem.Columns["exp_date"].Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry == "Y") ? false : true;
            txtPack.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvSpoiledItem.Columns["package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            btnBox.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            btnItemInfo.Enabled = UserScreenLimidations.ItemInfo;
            btnDeleteItem.Enabled = UserScreenLimidations.DeleteItem;
        }

        #region "Barcode"

        #region KeyPress
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
        //    if (ScanValue.Length == 6)
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
            tmrBarcode.Enabled = true;
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
        //            string barcode = Convert.ToString(txtBarcode.Text);
        //            if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                txtPack.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
        //                ClearBarcodeValues();

        //            }
        //            else
        //            {

        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "SpoiledInvoice") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;
        //                        ClearBarcodeValues();
        //                    }
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "SpoiledInvoice");
        //                    ClearBarcodeValues();
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
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Spoiled Invoice", "timer1_Tick");
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
                    //*********Commented for Performance Tuning on 20-Nov-2014 by Seenivasan*********//
                    //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    txtPack.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
                    //    ClearBarcodeValues();
                    //}
                    //*********************************************************************************************

                    //*********Added for Performance Tuning on 20-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            cmbItem.Text = row1["ItemName"].ToString();
                            txtPack.Text = (row1["PackageQty"]).ToString();
                            ClearBarcodeValues();
                        }
                    }
                    //***************************************************************************
                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "SpoiledInvoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                                LoadNewItems();
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "SpoiledInvoice");
                            ClearBarcodeValues();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
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

        private void LoadNewItems()
        {
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }

        # endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.ObjOrder.SetStatus = chkHideLogo.Checked == true ? 1 : 0;
                ObjHelper.ObjBALClass.ObjOrder.CheckNote = chkNote.Checked == true ? true : false;
                ObjHelper.ObjBALClass.ObjOrder.Note = txtNote.Text;
                ObjHelper.ObjBALClass.ObjOrder.Status = chkPrintPreview.Checked == true ? 1 : 0;
                ObjHelper.sender = sender;
                ObjHelper.btnPrint();
                chkHideLogo.Checked = chkPrintPreview.Checked = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnPrint_Click");

            }
        }

        private void RTxt_NoteAlerts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string str = RTxt_NoteAlerts.SelectedText.Trim();
                Purchase_Invoice.ReorderandBalance(str);
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " RTxt_NoteAlerts_MouseDoubleClick");

            }
        }

        private void btnExpiryList_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ExpiryList();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnExpiryList_Click");

            }
        }

        //private void cmbItem_DropDown(object sender, EventArgs e)
        //{
        //    //((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //}

        //private void cmbItem_DropDownClosed(object sender, EventArgs e)
        //{
        //    //((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    switch (((ComboBox)sender).Name)
        //    {
        //        case "cmbItem":
        //            if (iscount)
        //                iscount = false;
        //            else
        //                cmbItem_SelectedIndexChanged(sender, EventArgs.Empty);
        //            break;
        //        case "cmbItemNo":
        //            if (iscount)
        //                iscount = false;
        //            else
        //                cmbItemNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //            break;

        //    }
        //}
        private void txtPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ObjHelper.ObjBALClass.ObjOrder.ItemType == 1)
                {
                    if (txtPack.Text != string.Empty && txtPack.SelectedIndex > -1 && CheckPackageQty == false)
                    {
                        var items = ObjHelper.PackageQty.Where(a => a.ItemPackage == Convert.ToInt32(txtPack.Text)).ToList();
                        if (items.Count > 0)
                        {
                            ObjHelper.ObjBALClass.ObjOrder.ItemPrice = items[0].ItemPrice;
                            ObjHelper.ObjBALClass.ObjOrder.BarcodeID = items[0].BarcodeID;
                            ObjHelper.ObjBALClass.ObjOrder.ItemPackage = items[0].ItemPackage;
                            ObjHelper.ObjBALClass.ObjOrder.ItemCost = items[0].PurchaseCost;
                            cmbExpiry.DataSource = null;
                            cmbExpiry.ValueMember = cmbExpiry.DisplayMember = "ItemExpiryDate";
                            cmbExpiry.DataSource = ObjHelper.Expiry.Where(a => a.ItemPackage == ObjHelper.ObjBALClass.ObjOrder.ItemPackage).ToList();
                        }

                        // var stock = ObjHelper.Expiry.Where(a => (a.ItemNo == ObjHelper.ObjBALClass.ObjOrder.ItemNo) && (a.BarcodeID == ObjHelper.ObjBALClass.ObjOrder.BarcodeID)).ToList();
                        Expiry();
                        ItemQuantityCheck();

                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtPack_SelectedIndexChanged");

            }
        }
        /// <summary>
        /// Created By:Meena.R
        /// Created Date:30/06/2014
        /// to bind the extract Expiry and their stock details
        /// </summary>
        private void Expiry()
        {
            var stock = ObjHelper.Expiry.Where(a => (a.ItemNo == ObjHelper.ObjBALClass.ObjOrder.ItemNo) && (a.BarcodeID == ObjHelper.ObjBALClass.ObjOrder.BarcodeID) && (a.ItemExpiryDate == Convert.ToDateTime(cmbExpiry.SelectedValue).Date)).ToList();
            if (stock.Count > 0)
            {
                ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = stock[0].ItemTotalStock; //this Line Command to Fix Piece can from a Package on 04Aug2014
                //ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = ObjHelper.Expiry.Sum(a => a.ItemTotalStock);
                ObjHelper.ObjBALClass.ObjOrder.Box = (ObjHelper.isPackage == false) ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock) / ((ObjHelper.ObjBALClass.ObjOrder.ItemPackage != 0) ? ObjHelper.ObjBALClass.ObjOrder.ItemPackage : 1))) : (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock);////////////include teh this line for to get the box qty for particular item 
                if (!ObjHelper.isPackage)
                    txtBox.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (stock[0].ItemPackage == 0 ? 1 : stock[0].ItemPackage)).ToString();
                else
                    txtBox.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
            }
            else
                txtBox.Text = "0";
            txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("########.000");
            txtRemaining.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemStock = Convert.ToInt32(txtBox.Text)).ToString();

            //// incluide this line on 24 jun 2014...change the package when the ispackage is true 
            ItemCostPieceCalculation();
        }
        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
                for (int i = 0; i <= this.tableLayoutPanel2.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel2.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel2.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is GroupBox || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
        }

        private void cmbExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Expiry();
            }
            catch (Exception ex)
            {


                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbExpiry_SelectedIndexChanged");

            }
        }

        private void ItemCostPieceCalculation()
        {
            if (ObjHelper.isPackage != false)
            {
                ObjHelper.ObjBALClass.ObjOrder.ItemStock = ((ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock != null) ? ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock : 0) - ObjHelper.ObjBALClass.ObjOrder.ItemQuantity;
                ObjHelper.piececost = ObjHelper.ObjBALClass.ObjOrder.ItemCost / ((ObjHelper.ObjBALClass.ObjOrder.ItemPackage == 0) ? 1 : ObjHelper.ObjBALClass.ObjOrder.ItemPackage);
                ObjHelper.piececost = Convert.ToDecimal(ObjHelper.piececost.ToString("#######0.000"));
                ObjHelper.ItemCost = ObjHelper.ObjBALClass.ObjOrder.ItemCost;
                txtCost.Text = ObjHelper.piececost.ToString("#####0.000");
                txtRemaining.Text = ObjHelper.ObjBALClass.ObjOrder.ItemStock.ToString();
                //  ObjHelper.isPackage = true ;
            }
        }

        private void cmbSerialno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjHelper.ObjBALClass.ObjOrder.ItemType == 2)
            {
                if (cmbSerialno.SelectedIndex > -1)
                {
                    var items = ObjHelper.Expiry.Where(a => a.ItemSerialNo == cmbSerialno.Text).ToList();
                    if (items.Count > 0)
                    {
                        ObjHelper.ObjBALClass.ObjOrder.ItemPrice = items[0].ItemPrice;
                        ObjHelper.ObjBALClass.ObjOrder.BarcodeID = items[0].BarcodeID;
                    }

                    // var stock = ObjHelper.Expiry.Where(a => (a.ItemNo == ObjHelper.ObjBALClass.ObjOrder.ItemNo) && (a.BarcodeID == ObjHelper.ObjBALClass.ObjOrder.BarcodeID)).ToList();
                    var stock = ObjHelper.Expiry.Where(a => (a.BarcodeID == ObjHelper.ObjBALClass.ObjOrder.BarcodeID) && (a.ItemSerialNo == cmbSerialno.Text)).ToList();
                    if (stock.Count > 0)
                    {
                        ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = stock[0].ItemTotalStock; //this Line Command to Fix Piece can from a Package on 04Aug2014
                        //ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock = ObjHelper.Expiry.Sum(a => a.ItemTotalStock);
                        ObjHelper.ObjBALClass.ObjOrder.Box = (ObjHelper.isPackage == false) ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock) / ((ObjHelper.ObjBALClass.ObjOrder.ItemPackage != 0) ? ObjHelper.ObjBALClass.ObjOrder.ItemPackage : 1))) : (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock);////////////include teh this line for to get the box qty for particular item 
                        if (!ObjHelper.isPackage)
                            txtBox.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock / (stock[0].ItemPackage == 0 ? 1 : stock[0].ItemPackage)).ToString();
                        else
                            txtBox.Text = ObjHelper.ObjBALClass.ObjOrder.ItemTotalStock.ToString();
                    }
                    else
                        txtBox.Text = "0";
                    txtCost.Text = ObjHelper.ObjBALClass.ObjOrder.ItemCost.ToString("########.000");
                    txtRemaining.Text = (ObjHelper.ObjBALClass.ObjOrder.ItemStock = Convert.ToInt32(txtBox.Text)).ToString();

                    //// incluide this line on 24 jun 2014...change the package when the ispackage is true 
                    ItemCostPieceCalculation();
                    ItemQuantityCheck();

                }
            }
        }

        private void dgvSpoiledItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbItem_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    if (isfrominsert == false)
            //        txtBarcode.Focus();
            //    else
            //        isfrominsert = false;
            //}

            if (e.KeyValue == 13)
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
            }
        }

        private void Spoiled_Item_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjHelper.SpoiledInvoiceList = null;
            ObjHelper.Expiry = null;
            ObjHelper.ItemList = null;
            ObjHelper.FilterItemList = null;
            ObjHelper.PackageQty = null;
            ObjHelper.ObjItemInfo = null;
            this.Dispose();
        }

        private void cmbCompany_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == "cmbCategory")
            {
                if ((cmbCategory.Text.Trim() != string.Empty && cmbCategory.SelectedIndex == -1) || cmbCategory.Text == string.Empty)
                {
                    cmbCategory.SelectedValue = 1001;
                }
            }
            else
            {
                if ((cmbCompany.Text.Trim() != string.Empty && cmbCompany.SelectedIndex == -1) || cmbCompany.Text == string.Empty)
                {
                    cmbCompany.SelectedValue = 1001;
                }
            }
        }


    }
}
