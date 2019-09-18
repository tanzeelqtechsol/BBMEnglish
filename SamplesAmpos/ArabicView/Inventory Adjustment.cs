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
using System.Globalization;
using BumedianBM.CrystalReports;
using BumedianBM.View;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Inventory_Adjustment : Form, IDisposable
    {
        #region Variables
        List<InventAdjustObjectClass> objInventAdjDict = new List<InventAdjustObjectClass>();
        List<InventAdjustObjectClass> objInventAdjByInvNo = new List<InventAdjustObjectClass>();
        InventoryAdjustHelper ObjInventAdjHelp = new InventoryAdjustHelper();
        List<InventAdjustObjectClass> ObjInventGridList = new List<InventAdjustObjectClass>();
        HijriToGregs objhijri = new HijriToGregs();
        Dictionary<string, List<InventAdjustObjectClass>> InvAdjDictBal = new Dictionary<string, List<InventAdjustObjectClass>>();
        decimal BeTotValue = 0;
        decimal AfTotValue = 0;
        int MinNO = 0, MaxNO = 0, YearSeqNo = 0;
        int Adjust_count = 0;
        private string ScanValue = string.Empty;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private int KeyboardmaxCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        int RowIndex = 0;
        Boolean Save_Event = true;
        DataTable dtallBarcode;
        #endregion

        public Inventory_Adjustment()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
        }

        private void Inventory_Adjustment_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                Dtp_Date.Format = DateTimePickerFormat.Custom;
                Dtp_Date.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                //var dateString = "7/25/2013 4:12:18 PM";
                //DateTime dt = DateTime.ParseExact(dateString, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                FillCombo();
                Hide_TheControls();
                //  ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.CurrentYear= ObjInventAdjHelp.GetCurrentYear();
                List<long> MinMaxId = ObjInventAdjHelp.GetCurrentYear();
                ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.StockInvoiceNo = MinMaxId[1];
                MaxNO = Convert.ToInt32(MinMaxId[1]);
                MinNO = Convert.ToInt32(MinMaxId[0]);
                txtInvoiceNo.Text = string.Empty;
                txtInvoiceNo.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.StockInvoiceNo.ToString();
                // FillInventoryAdjustmentGrid();  //This  is commented since it is executed one more time in txtInvoiceno_textchanged. Done By Manoj On June 23
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                cmbItem.SelectedIndex = -1;
                cmbItemNo.SelectedIndex = -1;
                cmbItem.SelectAll();
                cmbItem.Focus();

                dtallBarcode = new DataTable();  //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
                dtallBarcode = GeneralFunction.GetAllBarcode(); //Added for Barcode Scanning Performance Tuning on 19-Nov-2014 by Seenivasan
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void Hide_TheControls()
        {
            btnFirst.Visible = btnPrevious.Visible = btnNext.Visible = btnLast.Visible = UserScreenLimidations.InvoiceNavigation;
            txtInvoiceNo.ReadOnly = UserScreenLimidations.InvoiceNavigation;
            lblItemNo.Visible = cmbItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            dgrInventoryList.Columns[0].Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            btnItemCard.Enabled = UserScreenLimidations.ItemCard;
            btnPrint.Enabled = UserScreenLimidations.Print;
            btnItemInformation.Enabled = UserScreenLimidations.ItemInfo;
            btnInventory.Enabled = UserScreenLimidations.OpeningStock;
            btnReports.Enabled = UserScreenLimidations.Reports;
            btnReturnItem.Enabled = UserScreenLimidations.SaleReturnInvoice || UserScreenLimidations.PurchaseReturnInvoice;
        }

        private void FillInventoryAdjustmentGrid()
        {
            BeTotValue = 0; AfTotValue = 0;
            int CatId = 0, CompId = 0;
            if (cmbCategory.SelectedIndex != -1)
                CatId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
            else
                CatId = 1001;
            if (cmbCompany.SelectedIndex != -1)
                CompId = Convert.ToInt32(cmbCompany.SelectedValue.ToString());
            else
                CompId = 1001;

            objInventAdjDict = ObjInventAdjHelp.InventoryAdjustmentload();
            dgrInventoryList.AutoGenerateColumns = false;
            this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
            this.dgrInventoryList.CellLeave -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellLeave);
            dgrInventoryList.DataSource = null;
            if (CatId == 1001 && CompId == 1001)
            {
                dgrInventoryList.DataSource = objInventAdjDict.FindAll(x => x.ItemType != 3 && x.ItemType != 4);
            }
            else if (CatId == 1001 && CompId != 1001)
            {
                dgrInventoryList.DataSource = objInventAdjDict.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CompanyId == CompId);
            }
            else if (CatId != 1001 && CompId == 1001)
            {
                dgrInventoryList.DataSource = objInventAdjDict.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId);
            }
            else
            {
                dgrInventoryList.DataSource = objInventAdjDict.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId && x.CompanyId == CompId);
            }
            //if (txtInvoiceNo.Text == MaxNO.ToString())
            //{
            //    dgrInventoryList.ReadOnly = false;
            //}
            //else
            //{
            //    dgrInventoryList.ReadOnly = true;
            //}

            //  dgrInventoryList.ReadOnly = (dgrInventoryList.BackgroundColor == Color.Gray) ? true : false;
            //dgrInventoryList.BackgroundColor = Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
            dgrInventoryList.BackgroundColor = Color.WhiteSmoke;
            dgrInventoryList.Columns["Cost"].ReadOnly = false;
            dgrInventoryList.Columns["Quantity1"].ReadOnly = false;

            dgrInventoryList.Columns["Reason"].ReadOnly = false; //This is added to reason field should be editable as per client feedback. Done By. A.M.K On July 03

            this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
            this.dgrInventoryList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellLeave);
            Txt_BeforeTotalValue.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.BeforeTotalValue;
            Txt_AfterTotalValue.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.BeforeTotalValue;
            Txt_AdjustDiff.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.AdjustDifference;
        }
        public void SetLanguage()
        {
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            btnItemInformation.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey("ReturnItem");
            this.Text = Additional_Barcode.GetValueByResourceKey("InventoryAdjust");
            lblAdjustDifference.Text = Additional_Barcode.GetValueByResourceKey("AdjustDiff");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblTime.Text = Additional_Barcode.GetValueByResourceKey("Time");
            lblTotalValueAfterAdjust.Text = Additional_Barcode.GetValueByResourceKey("TValueAfterAdjust");
            lblTotalValueBeforeAdjust.Text = Additional_Barcode.GetValueByResourceKey("TValueBeforeAdjust");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            lblInvoiceNo.Text = Additional_Barcode.GetValueByResourceKey("InvoiceNo");
            //btnExport.Text = Additional_Barcode.GetValueByResourceKey("Export");
            btnInventory.Text = Additional_Barcode.GetValueByResourceKey("Inventory");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnUndo.Text = Additional_Barcode.GetValueByResourceKey("Undo");
            btnZakat.Text = Additional_Barcode.GetValueByResourceKey("Zakat");

            dgrInventoryList.Columns["ItemID"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemId");
            dgrInventoryList.Columns["ItemName"].HeaderText = Additional_Barcode.GetValueByResourceKey("IName");
            dgrInventoryList.Columns["ExpiryDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            dgrInventoryList.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgrInventoryList.Columns["Quantity1"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgrInventoryList.Columns["Cost"].HeaderText = Additional_Barcode.GetValueByResourceKey("TCost");
            dgrInventoryList.Columns["TotalPurchased"].HeaderText = Additional_Barcode.GetValueByResourceKey("TotalPurchased");
            dgrInventoryList.Columns["TotalSold"].HeaderText = Additional_Barcode.GetValueByResourceKey("TotalSold");
            dgrInventoryList.Columns["Spoiled"].HeaderText = Additional_Barcode.GetValueByResourceKey("SpoiledInv");
            dgrInventoryList.Columns["CurrentQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("CurrentQty");
            dgrInventoryList.Columns["Adjustment"].HeaderText = Additional_Barcode.GetValueByResourceKey("Adjustment");
            dgrInventoryList.Columns["Reason"].HeaderText = Additional_Barcode.GetValueByResourceKey("Reason");
            dgrInventoryList.Columns["SerialNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
            dgrInventoryList.Columns["User"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgrInventoryList.Columns["OldCost"].HeaderText = Additional_Barcode.GetValueByResourceKey("OldCost");
            dgrInventoryList.Columns["pack"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pack");
            dgrInventoryList.Columns["Type"].HeaderText = Additional_Barcode.GetValueByResourceKey("Type");
            dgrInventoryList.Columns["GridID"].HeaderText = Additional_Barcode.GetValueByResourceKey("GridID");
            dgrInventoryList.Columns["Edit"].HeaderText = Additional_Barcode.GetValueByResourceKey("Edit");
            dgrInventoryList.Columns["RowIndex1"].HeaderText = Additional_Barcode.GetValueByResourceKey("RowIndex");
            dgrInventoryList.Columns["ModifiedCost"].HeaderText = Additional_Barcode.GetValueByResourceKey("ModifiedCost");
            dgrInventoryList.Columns["modifiedqty"].HeaderText = Additional_Barcode.GetValueByResourceKey("ModifiedQty");
            //dgrInventoryList.Columns["AfterAdjustment"].HeaderText = Additional_Barcode.GetValueByResourceKey("AfterAdjustment");
            dgrInventoryList.Columns["Original"].HeaderText = Additional_Barcode.GetValueByResourceKey("Original");
            dgrInventoryList.Columns["AdjustedDiff"].HeaderText = Additional_Barcode.GetValueByResourceKey("AdjustedDiff");
            dgrInventoryList.Columns["BeforeAdjust"].HeaderText = Additional_Barcode.GetValueByResourceKey("BeforeAdjust");
            dgrInventoryList.Columns["QtyAdjust"].HeaderText = Additional_Barcode.GetValueByResourceKey("QtyAdjust");
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrInventoryList.BackgroundColor != Color.Gray)
                {
                    if (txtInvoiceNo.Text != string.Empty)
                    {
                        int ValNo = Convert.ToInt16(txtInvoiceNo.Text);
                        int MaxiVal = Convert.ToInt16(MaxNO);
                        if (ValNo == MaxiVal)
                        {
                            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.InvNo = 0;
                            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Status = 0;
                            int NewYearId = ObjInventAdjHelp.GetInvoiveNewYearNoHelp();
                            txtNewYearNo.Text = NewYearId.ToString();
                            ClearTheGridControls();
                            FillInventoryAdjustmentGrid();
                        }
                    }
                }
                else
                {
                    GeneralFunction.Information("AlertInvoiceModified", this.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Methods
        public void FillCombo()
        {
            FillComboListDetails();
            FillItemComboBoxList_Item();
        }

        private void FillComboListDetails()
        {
            if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
            {
               // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
               // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }
            cmbCategory.SelectedIndexChanged -= new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = GeneralObjectClass.CategoryList;
            cmbCategory.SelectedIndex = -1;
            cmbCategory.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);

            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = GeneralObjectClass.CompanyList;
            cmbCompany.SelectedIndex = -1;


            //cmbItemNo.ValueMember = "ItemID";

        }

        private void FillItemComboBoxList_Item()
        {
            //********Category Id and Company Id is changed to 1001 since we have chaged default record for category id and company id as 1001. Done By Manoj On June-23-2014
            int CatId = 0, CompId = 0;
            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemNo";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";
            if (cmbCategory.SelectedIndex != -1)
                CatId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
            else
                CatId = 1001;
            if (cmbCompany.SelectedIndex != -1)
                CompId = Convert.ToInt32(cmbCompany.SelectedValue.ToString());
            else
                CompId = 1001;
            DataTable dtAllItem = ObjInventAdjHelp.GetAllItems(CatId, CompId);
            cmbItem.DataSource = dtAllItem;
            DataView dvfilter = new DataView(dtAllItem);
            dvfilter.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dvfilter.ToTable();
            //if (CatId == 1001 && CompId == 1001)
            //{
            //    cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            //    cmbItem.DataSource = GeneralObjectClass.ItemDetails.Where(x => x.ItemType != 3 && x.ItemType != 4).ToList().GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //    cmbItem.SelectedIndex = -1;
            //    cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);

            //    cmbItemNo.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4).Where(a => a.ItemNumber != string.Empty).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //}
            //else if (CatId == 1001 && CompId != 1001)
            //{
            //    cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            //    cmbItem.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CompId == CompId).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //    cmbItem.SelectedIndex = -1;
            //    cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);

            //    cmbItemNo.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CompId == CompId).Where(a => a.ItemNumber != string.Empty).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //}
            //else if (CatId != 1001 && CompId == 1001)
            //{
            //    cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            //    cmbItem.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList(); // This is changed to avoid the object class only binding instaed of its itemname in the itemname dropdown box. Done By A.Manoj on June-23
            //    cmbItem.SelectedIndex = -1;
            //    cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);

            //    cmbItemNo.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId).Where(a => a.ItemNumber != string.Empty).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //}
            //else
            //{
            //    cmbItem.SelectedIndexChanged -= new EventHandler(cmbItem_SelectedIndexChanged);
            //    cmbItem.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId && x.CompId == CompId).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //    cmbItem.SelectedIndex = -1;
            //    cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);

            //    cmbItemNo.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4 && x.CategoryId == CatId).Where(a => a.ItemNumber != string.Empty).GroupBy(a => a.ItemId).Select(grp => grp.First()).ToList();
            //}

            //cmbItemNo.DataSource = GeneralObjectClass.ItemDetails.FindAll(x => x.ItemType != 3 && x.ItemType != 4);
            //cmbItemNo.DisplayMember = "ItemID";

            //*****************
        }
        #endregion

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedIndex != -1)
                {
                    //if (Cmb_Category.Text != "System.Data.DataRowView")
                    //{

                    //if (txtInvoiceNo.Text == MaxNO)
                    //{

                    //cmbCompany.SelectedIndex = -1;
                    FillItemComboBoxList_Item();
                    FillInventoryAdjustmentGrid();
                    //}
                    //}
                }
               // cmbCategory.Text = string.Empty;
               // cmbItemNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    //if (cmbItem.SelectedValue != null)
                    //{
                    ObjInventAdjHelp.ObjItemInfo.ItemNo = Convert.ToInt32(cmbItem.SelectedValue);
                    cmbItemNo.SelectedValue = ObjInventAdjHelp.ObjItemInfo.ItemNo;
                    ObjInventAdjHelp.ObjItemInfo.ItemName = cmbItem.Text.ToString();
                    dgrInventoryList.ClearSelection();
                    FocusRowInGrid(cmbItem.Text);
                    //for (int i = 0; i < dgrInventoryList.Rows.Count; i++)
                    //{
                    //    if (ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.ItemId == Convert.ToInt32(dgrInventoryList.Rows[i].Cells["ItemID"].Value.ToString()))
                    //    {
                    //        dgrInventoryList.Rows[i].Selected = true;
                    //    }
                    //}
                    // }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnItemInformation_Click(object sender, EventArgs e)
        {
            try
            {

                if (ObjInventAdjHelp.ObjItemInfo.Visible == false)
                {
                    ButtonsEnabled();
                    int id = 0; string iname = string.Empty;
                    if (cmbItem.Text.ToString().Trim() == string.Empty)
                    {
                        if (dgrInventoryList.SelectedRows[0].Cells["Id"].Value != null && dgrInventoryList.SelectedRows[0].Cells["Id"].Value != string.Empty)
                        {
                            id = ObjInventAdjHelp.ObjItemInfo.ItemNo = Convert.ToInt32(dgrInventoryList.SelectedRows[0].Cells["Id"].Value.ToString());
                        }
                        else
                        {
                            id = ObjInventAdjHelp.ObjItemInfo.ItemNo = 0;
                        }
                        if (dgrInventoryList.SelectedRows[0].Cells["ItemName"].Value != null && dgrInventoryList.SelectedRows[0].Cells["ItemName"].Value != string.Empty)
                        {
                            iname = ObjInventAdjHelp.ObjItemInfo.ItemName = dgrInventoryList.SelectedRows[0].Cells["ItemName"].Value.ToString();
                        }
                        else
                        {
                            iname = ObjInventAdjHelp.ObjItemInfo.ItemName = string.Empty;
                        }
                    }
                    else
                    {
                        id = ObjInventAdjHelp.ObjItemInfo.ItemNo != null ? ObjInventAdjHelp.ObjItemInfo.ItemNo : 0;
                        iname = ObjInventAdjHelp.ObjItemInfo.ItemName != null ? ObjInventAdjHelp.ObjItemInfo.ItemName : string.Empty;
                    }
                    if (id != 0 && iname != string.Empty)
                    {
                        ObjInventAdjHelp.ObjItemInfo.ShowDialog();
                    }
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompany.SelectedIndex > 0)
                {
                    //if (Cmb_Category.Text != "System.Data.DataRowView")
                    //{

                    //if (txtInvoiceNo.Text == MaxNO)
                    //{

                    cmbCategory.SelectedIndex = -1;
                    FillItemComboBoxList_Item();
                    FillInventoryAdjustmentGrid();
                    //}
                    //}
                }
                cmbItem.Text = string.Empty;
                cmbItemNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void dgrInventoryList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrInventoryList.BackgroundColor == Color.Gray) return;
                if (dgrInventoryList.RowCount > 0)
                {
                    ObjInventAdjHelp.OnlyCostAdjust = false;
                    if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Quantity1")
                    {
                        string getQty = dgrInventoryList.CurrentRow.Cells["Quantity1"].EditedFormattedValue.ToString();
                        string OldQty = dgrInventoryList.CurrentRow.Cells["CurrentQty"].Value != null ? dgrInventoryList.CurrentRow.Cells["CurrentQty"].Value.ToString() : string.Empty;
                        string ModifiedQty = dgrInventoryList.CurrentRow.Cells["modifiedqty"].Value != null ? dgrInventoryList.CurrentRow.Cells["modifiedqty"].Value.ToString() : string.Empty;
                        if (getQty != string.Empty)
                        {
                            if (Convert.ToInt16(getQty) > -1)
                            {
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Quantity"].Value = getQty;
                                this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                                this.dgrInventoryList.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["modifiedqty"].Value = Convert.ToDecimal(getQty);

                                this.dgrInventoryList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                                this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                Adjust_count += 1;
                            }
                            else if (Convert.ToDecimal(ModifiedQty) != Convert.ToDecimal(OldQty))
                            {
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["modifiedqty"].Value = Convert.ToDecimal(OldQty);
                            }
                        }
                    }
                    if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Cost")
                    {
                        string getQty = dgrInventoryList.CurrentRow.Cells["Cost"].EditedFormattedValue.ToString();
                        string OldQty = dgrInventoryList.CurrentRow.Cells["OldCost"].EditedFormattedValue.ToString();
                        string ModifiedQty = dgrInventoryList.CurrentRow.Cells["ModifiedCost"].Value.ToString();

                        if (Convert.ToDecimal(getQty) != Convert.ToDecimal(OldQty))
                        {
                            this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                            this.dgrInventoryList.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                            //this.Dgv_InventoryList.CellLeave -= new System.Windows.Forms.DataGridViewCellValueEventHandler(this.Dgv_InventoryList_CellLeave);
                            dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                            dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                            dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                            dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                            dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                            dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["ModifiedCost"].Value = Convert.ToDecimal(getQty);
                            //this.Dgv_InventoryList.CellLeave+= new System.Windows.Forms.DataGridViewCellValueEventHandler(this.Dgv_InventoryList_CellLeave);
                            this.dgrInventoryList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                            this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                            Adjust_count += 1;
                            ObjInventAdjHelp.OnlyCostAdjust = true;
                        }
                        else if (Convert.ToDecimal(ModifiedQty) != Convert.ToDecimal(getQty))
                        {
                            dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["ModifiedCost"].Value = Convert.ToDecimal(getQty);
                        }
                    }
                    if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "ExpiryDate")
                    {
                        //CultureInfo enCul=new CultureInfo("en-US");
                        //string dateString = "2014/05/01";
                        //string[] allFormats = { "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy" };
                        //DateTime getdate = DateTime.ParseExact(dateString, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);

                        ////string format = @"mm/dd/yyyy";
                        //string dateString = @"2014/05/01";
                        //string[] allFormats ={ "yyyy/MM/dd", "yyyy/M/d" , "dd/MM/yyyy" , "d/M/yyyy" , "dd/M/yyyy" , "d/MM/yyyy" , "yyyy-MM-dd" , "yyyy-M-d" , "dd-MM-yyyy" , "d-M-yyyy" , "dd-M-yyyy" , "d-MM-yyyy" , "yyyy MM dd" , "yyyy M d" , "dd MM yyyy" , "d M yyyy" , "dd M yyyy" , "d MM yyyy" };
                        //DateTime getdate = DateTime.ParseExact(dateString, allFormats,
                        //    System.Globalization.CultureInfo.InvariantCulture);
                        //// DateTime getdate = DateTime.ParseExact(dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString(), format, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        //  //  DateTime Olddate = DateTime.ParseExact(dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString(), format, System.Globalization.DateTimeFormatInfo.InvariantInfo); 
                        //  string getdate = DateTime.ParseExact(dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString());
                        // DateTime Olddate =DateTime.Parse(dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString());
                        string getdate = dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString();
                        string Olddate = dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString();
                        if (getdate != "" & Olddate != "")
                        {
                            if (Convert.ToDateTime(getdate) != DateTime.Now)//removed ParseExact
                            {
                                ObjInventGridList = (List<InventAdjustObjectClass>)dgrInventoryList.DataSource;
                                this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                this.dgrInventoryList.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                                // this.Dgv_InventoryList.CellLeave -= new System.Windows.Forms.DataGridViewCellValueEventHandler(this.Dgv_InventoryList_CellLeave);
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                                if (dgrInventoryList.CurrentRow.Cells["Quantity1"].EditedFormattedValue.ToString() != string.Empty)
                                {
                                    ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].Quantity = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["CurrentQty"].Value);
                                    //ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].StockInHand = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Quantity"].Value);
                                }
                                else
                                {
                                    ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].Quantity = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["CurrentQty"].Value);
                                }
                                //this.Dgv_InventoryList.CellLeave += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.Dgv_InventoryList_CellLeave);
                                this.dgrInventoryList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                                this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                Adjust_count += 1;
                            }
                        }
                    }
                    if ((dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Cost") | (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Quantity1"))
                    {
                        ObjInventGridList = (List<InventAdjustObjectClass>)dgrInventoryList.DataSource;
                        int modqty = 0; decimal modcost = 0;
                        // if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Quantity")
                        //  {
                        modqty = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["modifiedqty"].Value.ToString());

                        //InventAdjustObjectClass obj = ObjInventGridList.Find(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex);
                        //if (obj != null)
                        //    obj.AdjustDiffer = 4;
                        ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList().ForEach(li => li.ModifiedQty = modqty);
                        if (dgrInventoryList.CurrentRow.Cells["Quantity1"].EditedFormattedValue.ToString() != string.Empty)
                        {
                            ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].Quantity = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["CurrentQty"].Value);
                            //ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].StockInHand = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Quantity"].Value);
                        }
                        else
                        {
                            ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList()[0].Quantity = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["CurrentQty"].Value);
                        }
                        // }
                        // if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Cost")
                        //  {
                        modcost = Convert.ToDecimal(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["ModifiedCost"].Value.ToString());
                        ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList().ForEach(li => li.ModifiedCost = modcost);
                        // }
                        int packs = Convert.ToInt32(dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["pack"].Value.ToString());
                        if (packs != 0 && modcost != 0)
                        {
                            decimal adjust = (modcost / packs) * modqty;
                            ObjInventGridList.Where(x => x.RowIndex == dgrInventoryList.CurrentCell.RowIndex).ToList().ForEach(li => li.AdjustDiffer = adjust);
                        }

                        CalculateTheTotalValue();
                    }
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Updatelist()
        {

        }

        private void CalculateTheTotalValue()
        {
            try
            {
                //if (!ismodified) return;
                decimal CulBeTotValue = 0, CulAdjTotValue = 0, CulAfTotValue = 0;
                decimal oldcost1, Aftercurrentcost = 0, BeforeAdjust = 0, BeforeAdjustDiffer = 0, AfterAdjustDiffer = 0;
                int oldqty, currentqty, pack1 = 0, Newqty = 0;
                BeforeAdjust = Convert.ToDecimal(ObjInventGridList.Sum(x => x.BeforeAdjust));  //adjust diffrence
                oldqty = Convert.ToInt32(ObjInventGridList.Sum(x => x.StockInHand));     // quantity
                BeforeAdjustDiffer = Convert.ToDecimal(ObjInventGridList.Sum(x => x.BeforeAdjust));

                Newqty = Convert.ToInt32(ObjInventGridList.Sum(x => x.ModifiedQty));     // quantity
                AfterAdjustDiffer = Convert.ToDecimal(ObjInventGridList.Sum(x => x.AdjustDiffer));  //Commended on 26062014 By Meena.R to get the Total
                // AfterAdjustDiffer=Convert.ToDecimal(ObjInventGridList.Sum(x=>x.ModifiedCost));
                Txt_AfterTotalValue.Text = AfterAdjustDiffer.ToString("######0.000");
                Txt_BeforeTotalValue.Text = BeforeAdjust.ToString("######0.000");
                Txt_AdjustDiff.Text = (AfterAdjustDiffer - BeforeAdjustDiffer).ToString("######0.000");

                // currentcost1 = (dgrInventoryList.Columns.Contains("Original")) ? Convert.ToDecimal(dgrInventoryList.Compute("sum(Original)", string.Empty)) : Convert.ToDecimal(pagingTables.Compute("sum(BeforeAdjust)", string.Empty));
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        private void dgrInventoryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgrInventoryList.BackgroundColor == Color.Gray) return;
                if (ScanValue.Length < 2 & ((DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds == 0) | (DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds > 20)))
                {
                    if (dgrInventoryList.RowCount > 0)
                    {
                        if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "ExpiryDate")
                        {
                            string getQty = dgrInventoryList.CurrentRow.Cells["Quantity1"].EditedFormattedValue.ToString();
                            if (getQty != string.Empty)
                            {
                                if (Convert.ToInt16(getQty) > -1)
                                {
                                    this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                    dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                                    dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                    dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                                    dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                                    dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                                    this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                    Adjust_count += 1;
                                }
                            }
                        }
                        if (dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "Quantity1")
                        {
                            string getQty = dgrInventoryList.CurrentRow.Cells["Cost"].EditedFormattedValue.ToString();
                            string OldQty = dgrInventoryList.CurrentRow.Cells["OldCost"].EditedFormattedValue.ToString();
                            if (Convert.ToDecimal(getQty) != Convert.ToDecimal(OldQty))
                            {
                                this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                                this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                Adjust_count += 1;
                            }
                        }
                        if (dgrInventoryList.CurrentCell.ColumnIndex == 2)
                        {
                            string getdate = dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString();
                            string Olddate = dgrInventoryList.CurrentRow.Cells["ExpiryDate"].EditedFormattedValue.ToString();
                            getdate = (getdate == string.Empty) ? DateTime.Now.AddDays(1).ToString() : getdate;
                            if (Convert.ToDateTime(getdate) != DateTime.Now)
                            {
                                this.dgrInventoryList.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.CurrentRow.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = "";
                                dgrInventoryList.Rows[dgrInventoryList.CurrentCell.RowIndex].Cells["Edit"].Value = 1;
                                this.dgrInventoryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrInventoryList_DataBindingComplete);
                                Adjust_count += 1;
                            }
                        }
                        CalculateTheTotalValue();
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        void Set_GridRowColor()
        {
            DataTable GetTab = new DataTable();
            try
            {
                if (dgrInventoryList.Rows.Count > 0)
                {
                    GetTab = CommonHelper.ConvertionHelper.ConvertToDataTable<InventAdjustObjectClass>((List<InventAdjustObjectClass>)dgrInventoryList.DataSource);
                    for (int i = 0; i < GetTab.Rows.Count; i++)
                    {
                        int CheckQTY = Convert.ToInt32(GetTab.Rows[i]["Quantity"].ToString());
                        decimal Cost = Convert.ToDecimal(GetTab.Rows[i]["Cost"].ToString());
                        decimal OldCost = Convert.ToDecimal(GetTab.Rows[i]["OldCost"].ToString());
                        string dateval = GetTab.Rows[i]["ExpiryDate"].ToString();
                        if (GetTab.Rows[i]["Edit"].ToString() == "1")
                        {
                            if (CheckQTY > 0)
                            {
                                dgrInventoryList.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.Rows[i].DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
                            if (Cost != OldCost)
                            {
                                dgrInventoryList.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.Rows[i].DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }

                            if (dateval != "")
                            {
                                dgrInventoryList.Rows[i].DefaultCellStyle.BackColor = Color.SlateGray;
                                dgrInventoryList.Rows[i].DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                dgrInventoryList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }


        }

        #region KeyPress Events
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    if (this.ActiveControl.Name == "txtBarcode")
        //    {
        //        //ScanValue = string.Empty;
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
        //        if (KeyboardmaxCount > 2 && ScanValue.Length > 1)
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = string.Empty;
        //            ScanValue = e.KeyChar.ToString();
        //            KeyboardmaxCount = 0; return;
        //        }
        //        // if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1))
        //        if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < 42 && ScanLetterEndTime.TotalMilliseconds > 22))
        //        {
        //            ScanLetterStartTime = DateTime.Now;
        //            ScanValue = ScanValue + e.KeyChar.ToString();
        //            KeyboardmaxCount = KeyboardmaxCount + 1;
        //        }
        //        else if ((ScanLetterEndTime.TotalMilliseconds < 22 && ScanLetterEndTime.TotalMilliseconds > 10))
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
        private void dgrInventoryList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgrInventoryList.BackgroundColor == Color.Gray) return;
                if (ScanValue.Length < 2 & ((DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds == 0) | (DateTime.Now.Subtract(ScanLetterStartTime).TotalMilliseconds > 20)))
                {
                    if (dgrInventoryList.SelectedRows.Count > 0)
                    {
                        if (dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value != null && dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value != "")
                        {
                            DateTime expdate = new DateTime();
                            expdate = DateTime.Now.AddDays(1);
                            if (Convert.ToDateTime(Convert.ToDateTime(dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value.ToString()).ToShortDateString()) < Convert.ToDateTime(expdate.ToShortDateString()))
                            {
                                dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value = expdate.ToShortDateString();
                                expired_purcheses obj_expiredpurchase = new expired_purcheses();
                                obj_expiredpurchase.ShowDialog();
                            }
                        }
                        if (dgrInventoryList.SelectedRows[0].Cells["Cost"].Value.ToString() != "")
                        {

                            string str = dgrInventoryList.SelectedRows[0].Cells["Cost"].Value.ToString();
                            decimal costval = str != "" ? Convert.ToDecimal(str) : 0;
                            this.dgrInventoryList.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                            dgrInventoryList.SelectedRows[0].Cells["Cost"].Value = costval.ToString("#########0.000");
                            this.dgrInventoryList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);

                        }
                        if (dgrInventoryList.SelectedRows[0].Cells["Quantity1"].EditedFormattedValue.ToString() != "")
                        {

                            string str = dgrInventoryList.SelectedRows[0].Cells["Quantity1"].EditedFormattedValue.ToString();
                            decimal costval = str != "" ? Convert.ToDecimal(str) : 0;
                            this.dgrInventoryList.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);
                            dgrInventoryList.SelectedRows[0].Cells["Quantity"].Value = costval.ToString();
                            this.dgrInventoryList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrInventoryList_CellValueChanged);

                        }

                        ReassignTheValue();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
                //if (ex.Message.ToString() == "String was not recognized as a valid DateTime.")
                //{
                //    GeneralFunction.InfoMsg("ValidDate", this.Text);
                //    Dgv_InventoryList.SelectedRows[0].Cells["ExpiryDate"].Value = DateTime.Now.AddDays(1).ToShortDateString();

                //}
                //else
                //{
                //    GeneralFunction.ErrMsg(this.Text);
                //    GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Dgv_InventoryList_CellValueChanged");
                //}
            }
        }

        private void ReassignTheValue()
        {
            try
            {
                if (dgrInventoryList.BackgroundColor == Color.Gray) return;
                if (RowIndex == 1)
                {
                    string chktype = dgrInventoryList.SelectedRows[0].Cells["Type"].Value.ToString();
                    string itemName = dgrInventoryList.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    //if (chktype.Trim() == "Second hand")
                    //{
                    //    if (serialcount > 0)
                    //    {
                    //        item_serialnumber item = new item_serialnumber();
                    //        item.strItem = itemName;
                    //        item.ShowDialog();
                    //        string getSnoval = item.strSerialNo;
                    //        if (getSnoval != null)
                    //        {
                    //            Dgv_InventoryList.SelectedRows[0].Cells["SerialNo"].Value = getSnoval.ToString();
                    //            serialcount = 0;
                    //        }
                    //    }
                    //}
                    RowIndex = 0;
                    if (dgrInventoryList.SelectedRows[0].Cells["Cost"].EditedFormattedValue.ToString() != "")
                    {
                        string getcst = dgrInventoryList.SelectedRows[0].Cells["Cost"].EditedFormattedValue.ToString();
                        decimal _val = (getcst != "") ? Convert.ToDecimal(getcst) : 0;
                        dgrInventoryList.SelectedRows[0].Cells["Cost"].Value = _val.ToString("#######0.000");
                    }
                }
                if (dgrInventoryList.SelectedRows.Count > 0)
                {
                    if (dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value != "" && dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value != null)
                    {
                        DateTime expdate = new DateTime();
                        expdate = DateTime.Now.AddDays(1);
                        if (Convert.ToDateTime(Convert.ToDateTime(dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value.ToString()).ToShortDateString()) < Convert.ToDateTime(expdate.ToShortDateString()))
                        {
                            dgrInventoryList.SelectedRows[0].Cells["ExpiryDate"].Value = expdate.ToShortDateString();
                            GeneralFunction.Information("Expired Item can not be purchased", "Inventory_Adjustment");
                            //expired_purcheses obj_expiredpurchase = new expired_purcheses();
                            //obj_expiredpurchase.ShowDialog();
                        }

                    }
                }
                CalculateTheTotalValue();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgrInventoryList.BackgroundColor == Color.Gray) return;
            int gg = 0;
            try
            {
                SetObjectFromControls();

                if (CheckValidation())
                {
                    if (ObjInventGridList.Count > 0)
                    {
                        if (ObjInventAdjHelp.UpdateInventoryAdjustmentDetails(ObjInventGridList))
                        {
                            txtInvoiceNo.Text = string.Empty;
                            //  ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.CurrentYear= ObjInventAdjHelp.GetCurrentYear();
                            List<long> MinMaxId = ObjInventAdjHelp.GetCurrentYear();
                            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.StockInvoiceNo = MinMaxId[1];
                            MaxNO = Convert.ToInt32(MinMaxId[1]);
                            MinNO = Convert.ToInt32(MinMaxId[0]);
                            txtInvoiceNo.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.StockInvoiceNo.ToString();
                            // FillInventoryAdjustmentGrid();  //This  is commented since it is executed one more time in txtInvoiceno_textchanged. Done By Manoj On June 23
                            FillComboListDetails();
                            txtDescription.Text = "";
                            Txt_NoteReason.Text = "";
                            Save_Event = false;
                            Adjust_count = 0;
                            //dtInventoryExtended = new DataTable();
                            // Txt_InvoiceNo.Text = MaxNO;
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("NoItemtoSave", this.Tag.ToString());
                    }
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private bool CheckValidation()
        {
            if (ObjInventAdjHelp.DescriptionValidation())
            {
                //*************** This is commented by Manoj since client has asked in the discussion as "Not neccessary Displaying Alert for Notes field "
                //if (ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Notes == string.Empty)
                //{
                //    if (GeneralFunction.Question("LiketoAddNote", this.Tag.ToString()) == DialogResult.Yes)
                //    {
                //        Txt_NoteReason.Focus();
                //        return false;
                //    }
                //    else
                //    {
                //    }
                //}
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SetObjectFromControls()
        {
            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Description = txtDescription.Text;
            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Notes = Txt_NoteReason.Text;
            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.TblID = Convert.ToInt32(txtInvoiceNo.Text.ToString());
        }


        //private void Txt_NewYear_No_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
        //}
        private void inventory_adjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dgrInventoryList.BackgroundColor == Color.Gray) return;
                if ((Save_Event == true) & (Adjust_count > 0))
                {
                    if (GeneralFunction.Question("DidntSaveInventoryDetails", this.Tag.ToString()) == DialogResult.Yes)
                    {

                        this.InvokeOnClick(btnSave, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputTexts();
            //txtInvoiceNo.Text = MaxNO;
            FillInventoryAdjustmentGrid();
            Dtp_Date.MaxDate = DateTime.Now.AddDays(1).AddSeconds(-1);
            Dtp_Date.Value = DateTime.Now;
            Dtp_Time.Value = DateTime.Now;
        }

        private void ClearInputTexts()
        {
            Txt_AfterTotalValue.Text = "0.000";
            Txt_BeforeTotalValue.Text = "0.000";
            Txt_AdjustDiff.Text = "0.000";
            cmbCategory.SelectedIndex = -1;
            cmbCompany.SelectedIndex = -1;
            cmbItem.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            Txt_NoteReason.Text = "";
            txtDescription.Text = "";
        }
        private void ButtonsEnabled()
        {
            try
            {
                if (ObjInventAdjHelp.ObjItemInfo.Visible == true)
                {
                    btnClose.Enabled = false;
                    btnInventory.Enabled = false;
                    btnItemCard.Enabled = false;
                    btnNew.Enabled = false;
                    btnPrint.Enabled = false;
                    btnReports.Enabled = false;
                    btnReturnItem.Enabled = false;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnZakat.Enabled = false;
                }
                else
                {
                    btnClose.Enabled = true;
                    btnInventory.Enabled = true;
                    btnItemCard.Enabled = true;
                    btnNew.Enabled = true;
                    btnPrint.Enabled = true;
                    btnReports.Enabled = true;
                    btnReturnItem.Enabled = true;
                    btnSave.Enabled = true;
                    btnUndo.Enabled = true;
                    btnZakat.Enabled = true;
                }
            }
            catch (Exception ex) { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (UserScreenLimidations.OpeningStock == true)
            {
                Opening_Stock opnStock = new Opening_Stock();
                opnStock.ShowDialog();
            }
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            if (UserScreenLimidations.ItemCard == true)
            {
                ItemCard itmcar = new ItemCard();
                itmcar.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmattention atten = new frmattention();
                atten.ShowDialog();

                string getval = atten.strFormName;
                if (getval.Trim() != "")
                {
                    if (getval.Trim() == "SALE")
                    {
                        if (UserScreenLimidations.SaleReturnInvoice)
                        {
                            Sales_Return_Invoice returnInvoice = new Sales_Return_Invoice();
                            returnInvoice.ShowDialog();
                        }
                    }
                    else
                    {
                        if (UserScreenLimidations.PurchaseReturnInvoice)
                        {
                            PurchaseReturnInvoice returnInvoice = new PurchaseReturnInvoice();
                            returnInvoice.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbItemNo.SelectedIndex > -1)
        //        {
        //            if (cmbItemNo.SelectedValue.ToString() != "")
        //            {
        //                if (cmbItemNo.SelectedValue != null)
        //                {

        //                    string ItmN = cmbItemNo.SelectedValue.ToString();
        //                    cmbItem.Text = ItmN;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //      //  GeneralFunction.ErrMsg(this.Text);
        //       // GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Cmb_Item_SelectedIndexChanged");
        //    }
        //}

        #region Barcode
        //private void tmrBarcode_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ScannerCount += 1;
        //        if (lastFocusedControl != null)
        //        {
        //            if (lastFocusedControl.GetType().ToString() == "System.Windows.Forms.DataGridViewTextBoxEditingControl")
        //            {
        //                dgrInventoryList.CurrentCell.Value = lastfocusedvalue;
        //                if ((dgrInventoryList.Columns[dgrInventoryList.CurrentCell.ColumnIndex].Name == "ExpiryDate") & (lastfocusedvalue == string.Empty))
        //                {
        //                    dgrInventoryList.CurrentCell.Value = 0;
        //                }
        //            }
        //            else
        //            {
        //                lastFocusedControl.Text = lastfocusedvalue;

        //            }
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
        //                //DataRow[] drow1=pagingTables.Select("RowIndex=1");
        //                // string s = "[ItemName]='" +GeneralFunction.RemoveApostrophe(dtBarcode.Rows[0]["MTB_ITEM_ID"].ToString())+"'";

        //                ////  int index=0;
        //                ////  if (drow.Length > 0)
        //                ////  {

        //                ////      index = (pagingTables.Rows.IndexOf(drow[0])) / 19;
        //                ///       //index = Convert.ToInt32(drow[0][18].ToString()) / 19;
        //                ////  }

        //                //////index=((Convert.ToInt32(drow[0][18].ToString()) % 19) > 0) ? (index + 1) : index;
        //                //// // Btn_NextP_Click(sender, e);
        //                //// // Paging obj_paging1 = new Paging(index);
        //                ////  SetPagingDataGirdView(pagingTables,index);
        //                ClearBarcodeValues();

        //            }
        //            else
        //            {
        //                if (GeneralFunction.Question("NotAvailableBarcode", this.Tag.ToString()) == DialogResult.Yes)
        //                {
        //                    ItemCard frmItem = new ItemCard();
        //                    GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                    frmItem.ShowDialog();
        //                    GeneralFunction.PurchaseBarcode = string.Empty;
        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", this.Tag.ToString());
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
                    //*********Commented for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    //DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());

                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    ClearBarcodeValues();

                    //}
                    //*********************************************************************************************

                    //*********Added for Performance Tuning on 19-Nov-2014 by Seenivasan*********//
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");//Added for Performance Tuning on 19-Nov-2014 by Seenivasan
                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            cmbItem.Text = row1["ItemName"].ToString();
                            ClearBarcodeValues();
                        }

                    }
                    //*********************************************************************************************
                    else
                    {
                        if (GeneralFunction.Question("NotAvailableBarcode", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            ItemCard frmItem = new ItemCard();
                            GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                            frmItem.ShowDialog();
                            GeneralFunction.PurchaseBarcode = string.Empty;
                            ClearBarcodeValues();
                            LoadNewItems();
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", this.Tag.ToString());
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

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            cmbItem.Focus();
        }

        private void LoadNewItems()
        {
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }

        private void txtbarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text != "")
                {
                    txtDescription.Text = string.Empty;
                    int ValNo = Convert.ToInt16(txtInvoiceNo.Text);
                    int MaxiVal = Convert.ToInt16(MaxNO);
                    if (ValNo == MaxiVal)
                    {
                        ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.InvNo = 0;
                        ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Status = 0;
                        int NewYearId = ObjInventAdjHelp.GetInvoiveNewYearNoHelp();
                        txtNewYearNo.Text = NewYearId.ToString();
                        ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.NewYearNo = NewYearId;
                        ClearTheGridControls();
                        FillInventoryAdjustmentGrid();
                        btnUndo.Enabled = true;
                        dgrInventoryList.Columns[26].Visible = true;
                    }
                    else
                    {
                        ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.InvNo = ValNo;
                        ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.Status = 1;
                        int NewYearId = ObjInventAdjHelp.GetInvoiveNewYearNoHelp();
                        txtNewYearNo.Text = NewYearId.ToString();
                        ClearTheGridControls();
                        FillGridDatasource_byInvoiceNO();
                        //FillInventoryAdjustmentGrid();

                        Set_GridRowColor();
                        btnUndo.Enabled = false;
                        dgrInventoryList.Columns[26].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void FillGridDatasource_byInvoiceNO()
        {
            objInventAdjByInvNo = null;
            ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.StockInvoiceNo = txtInvoiceNo.Text.ToString() != string.Empty ? Convert.ToInt32(txtInvoiceNo.Text.ToString()) : 0;
            objInventAdjByInvNo = ObjInventAdjHelp.InventoryAdjustment_InvoiceNo();
            if (objInventAdjByInvNo.Count > 0)
            {
                txtDescription.Text = objInventAdjByInvNo[0].Description;
                Txt_NoteReason.Text = objInventAdjByInvNo[0].Notes;
                int status = objInventAdjByInvNo[0].Status;
                //dgrInventoryList.BackgroundColor = (status == 3) ? Color.Gray : Color.NavajoWhite; ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgrInventoryList.BackgroundColor = (status == 3) ? Color.Gray : Color.WhiteSmoke;
                if (objInventAdjByInvNo[0].ModifiedDate != DateTime.MinValue)
                {
                    Dtp_Date.Text = Convert.ToDateTime(objInventAdjByInvNo[0].ModifiedDate).ToShortDateString();
                    Dtp_Time.Value = Convert.ToDateTime(objInventAdjByInvNo[0].ModifiedDate.ToString());
                }
                dgrInventoryList.DataSource = objInventAdjByInvNo;
                //if(txtInvoiceNo.Text.ToString()=MaxNO.ToString())
                //if (txtInvoiceNo.Text == MaxNO.ToString())
                //{
                //    dgrInventoryList.ReadOnly = false;
                //}
                //else
                //{
                //    dgrInventoryList.ReadOnly = true;
                //}

                dgrInventoryList.ReadOnly = (dgrInventoryList.BackgroundColor == Color.Gray) ? true : false;
                // Set_GridRowColor();
                if (cmbItem.SelectedIndex > -1) { FocusRowInGrid(cmbItem.Text); }


                Txt_BeforeTotalValue.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.BeforeTotalValue;
                Txt_AfterTotalValue.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.AfterTotalValue;
                Txt_AdjustDiff.Text = ObjInventAdjHelp.ObjInventAdjBAL.ObjInvAdjObject.AdjustDifference;
            }
        }
        private void FocusRowInGrid(string GetItemName)
        {
            try
            {
                List<InventAdjustObjectClass> objInventAdjGrid = new List<InventAdjustObjectClass>();
                objInventAdjGrid = (List<InventAdjustObjectClass>)dgrInventoryList.DataSource;
                int cmbItemId = cmbItem.SelectedIndex != -1 ? Convert.ToInt32(cmbItem.SelectedValue.ToString()) : -1;
                if (cmbItemId != -1)
                {
                    if (objInventAdjGrid!=null && objInventAdjGrid.Count > 0 )
                    {
                        for (int i = 0; i < objInventAdjGrid.Count; i++)
                        {
                            dgrInventoryList.Rows[i].Selected = false;
                            if (objInventAdjGrid[i].ItemId == cmbItemId)
                            {
                                dgrInventoryList.Rows[i].Selected = true;
                                dgrInventoryList.FirstDisplayedScrollingRowIndex = i;

                            }
                        }
                        dgrInventoryList.Update();

                    }
                }
            }
            catch (Exception ex) { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Rpt_InventoryAdjustment obj_InventAdjust = new Rpt_InventoryAdjustment();
                ReportsView RptView = new ReportsView();
                RptView.Text = GeneralFunction.ChangeLanguageforCustomMsg(this.Tag.ToString());
                DataTable dtLocal = new DataTable("InventoryAdjustment");
                if (dgrInventoryList.DataSource != null)
                {
                    dtLocal = CommonHelper.ConvertionHelper.ConvertToDataTable<InventAdjustObjectClass>((List<InventAdjustObjectClass>)dgrInventoryList.DataSource);
                    dtLocal.TableName = "InventoryAdjustment";
                    if (dtLocal != null)
                    {
                        for (int i = 0; i < dtLocal.Rows.Count; i++)
                        {
                            dtLocal.Rows[i]["strExpiryDate"] = dtLocal.Rows[i]["strExpiryDate"].ToString() != string.Empty ? Convert.ToDateTime(dtLocal.Rows[i]["strExpiryDate"]).Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]) : string.Empty;
                        }
                        RptView.HTable.Clear();
                        RptView.HTable.Add("Notes", Txt_NoteReason.Text.Replace("\n", " "));
                        RptView.HTable.Add("BeforeAdjustment", Txt_BeforeTotalValue.Text);
                        RptView.HTable.Add("AfterAdjustment", Txt_AfterTotalValue.Text);
                        RptView.HTable.Add("Difference", Txt_AdjustDiff.Text);
                        RptView.Report_Table = dtLocal;
                        RptView.RptDoc = obj_InventAdjust;
                        RptView.IsItemNo = true;
                        RptView.LoadEvent();
                        RptView.ShowDialog();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Adjust inventory", "STOCK_ADJUST", "Print inventory adjust details", Convert.ToInt32(InvoiceAction.Yes));
                    }
                    else
                    {
                        GeneralFunction.Information("NoRecordsFound", this.Tag.ToString());
                    }
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", this.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void ClearTheGridControls()
        {
            try
            {
                if (dgrInventoryList.DataSource != null)
                {
                    dgrInventoryList.DataSource = null;
                }
            }
            catch (Exception ex) { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtInvoiceNo.Text != "" && MinNO != 0)
                {
                    if (txtInvoiceNo.Text == MinNO.ToString())
                    { txtInvoiceNo.Text = MinNO.ToString(); }
                    else { txtInvoiceNo.Text = Convert.ToString((Convert.ToInt16(txtInvoiceNo.Text) - 1)); }
                    if (dgrInventoryList.BackgroundColor != Color.Gray)
                    {
                        Make_ExpiryDateReadOnly();
                        Make_Editable();
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                if (MinNO != 0)
                    txtInvoiceNo.Text = MinNO.ToString();
                if (dgrInventoryList.BackgroundColor != Color.Gray)
                {
                    Make_ExpiryDateReadOnly();
                    Make_Editable();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text != "")
                {
                    if (txtInvoiceNo.Text == MaxNO.ToString())
                    {
                        txtInvoiceNo.Text = MaxNO.ToString();
                    }
                    else
                    {
                        txtInvoiceNo.Text = Convert.ToString((Convert.ToInt16(txtInvoiceNo.Text) + 1));
                        //if (txtInvoiceNo.Text == MaxNO.ToString() || dgrInventoryList.BackgroundColor == Color.NavajoWhite) ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                        if (txtInvoiceNo.Text == MaxNO.ToString() || dgrInventoryList.BackgroundColor == Color.WhiteSmoke)
                        {
                            Dtp_Time.Value = DateTime.Now;
                        }
                    }
                    if (dgrInventoryList.BackgroundColor != Color.Gray)
                    {
                        Make_ExpiryDateReadOnly();
                        Make_Editable();
                        if (dgrInventoryList.SelectedRows.Count > 0) { dgrInventoryList.SelectedRows[0].Selected = false; }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceNo.Text = MaxNO.ToString();
                //if (txtInvoiceNo.Text == MaxNO.ToString() || dgrInventoryList.BackgroundColor == Color.NavajoWhite) ''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                if (txtInvoiceNo.Text == MaxNO.ToString() || dgrInventoryList.BackgroundColor == Color.WhiteSmoke)
                {
                    Dtp_Time.Value = DateTime.Now;
                    Dtp_Date.Value = DateTime.Now;
                }
                if (dgrInventoryList.BackgroundColor != Color.Gray)
                {
                    Make_ExpiryDateReadOnly();
                    Make_Editable();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void Make_ExpiryDateReadOnly()
        {
            try
            {
                //DataTable dtab = new DataTable();
                //if (dgrInventoryList.Rows.Count > 0)
                //{
                //    dtab = CommonHelper.ConvertionHelper.ConvertToDataTable<InventAdjustObjectClass>((List<InventAdjustObjectClass>)dgrInventoryList.DataSource);
                //    if (dtab != null && dtab.Rows.Count > 0)
                //    {
                //        for (int j = 0; j < dtab.Rows.Count; j++)
                //        {
                //            dgrInventoryList.Rows[j].ReadOnly = true;
                //            string checkDate = dtab.Rows[j]["ExpiryDate"].ToString();
                //            dgrInventoryList.Rows[j].Cells["Quantity1"].ReadOnly = dgrInventoryList.Rows[j].Cells["Cost"].ReadOnly = false;
                //            dgrInventoryList.Columns["Reason"].ReadOnly = false; //This is added to reason field should be editable as per client feedback. Done By. A.M.K On July 03
                //            if (checkDate == "")
                //            {
                //                dgrInventoryList.Rows[j].Cells["ExpiryDate"].ReadOnly = true;
                //            }
                //            else if (dgrInventoryList.BackgroundColor != Color.Gray)
                //            {
                //                dgrInventoryList.Rows[j].Cells["ExpiryDate"].ReadOnly = false;
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        void Make_Editable()
        {
            try
            {
                //DataTable dtab = new DataTable();
                //if (dgrInventoryList.Rows.Count > 0)
                //{
                //    dtab = CommonHelper.ConvertionHelper.ConvertToDataTable<InventAdjustObjectClass>((List<InventAdjustObjectClass>)dgrInventoryList.DataSource);

                //    if (dtab != null && dtab.Rows.Count > 0)
                //    {
                //        for (int j = 0; j < dtab.Rows.Count; j++)
                //        {
                //            dgrInventoryList.Rows[j].Cells["Quantity1"].ReadOnly = dgrInventoryList.Rows[j].Cells["Cost"].ReadOnly = false;
                //            dgrInventoryList.Columns["Reason"].ReadOnly = false; //This is added to reason field should be editable as per client feedback. Done By. A.M.K On July 03
                //            dgrInventoryList.Rows[j].Cells["ItemId"].ReadOnly = true;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnZakat_Click(object sender, EventArgs e)
        {
            try
            {
                ObjInventAdjHelp.Generate_Zakat();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (UserScreenLimidations.Reports == true)
            {
                Report rpts = new Report();
                rpts.ShowDialog();
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int itemno = Convert.ToInt32(cmbItemNo.SelectedValue);
                //cmbItem.SelectedValue = itemno;
                if (cmbItemNo.SelectedIndex > -1)
                {
                    int value = Convert.ToInt32(cmbItemNo.SelectedValue);
                    cmbItem.SelectedValue = value;
                    //cmbItem_SelectedIndexChanged(cmbItem, new EventArgs());

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemNo_SelectedIndexChanged");
            }
        }

        private void Inventory_Adjustment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 && btnItemInformation.Enabled == true)
            {
                btnItemInformation_Click(sender, e);
            }
            if (e.KeyData == Keys.F12)
            {
                Quick_Price_Information pric = new Quick_Price_Information();
                pric.ShowDialog();
            }
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
                foreach (Control ctl in Grp_Buttons.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox || ctl is TabControl || ctl is TabPage)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 13 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back && (e.KeyChar < 111 || e.KeyChar > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //    }

            //}

            if (e.KeyChar == 13)
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    txtDescription.Focus();
                    txtDescription.SelectAll();
                }
            }
        }

        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //    txtBarcode.Focus();
        }

        private void Inventory_Adjustment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgrInventoryList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
                e.Control.KeyPress += new KeyPressEventHandler(Control_Keypress);
        }

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }

        private void Control_Keypress(object sender, KeyPressEventArgs e)
        {
            if (dgrInventoryList.SelectedRows[0].Cells["Quantity1"].EditedFormattedValue.ToString() != "")
            {
                if ((!char.IsDigit(e.KeyChar))|| dgrInventoryList.SelectedRows[0].Cells["Quantity1"].EditedFormattedValue.ToString().Length > 8)
                    e.Handled = true;
            }
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
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
