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
using System.IO;
using ObjectHelper;
using System.Threading;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class ItemCard : Form, IDisposable
    {
        #region Variable
        ItemCardHelper ObjItemCardHelper;

        string ItemCardBarcode = string.Empty;

        public static int ItemCardUnitTyeID = 0;
        public static decimal ItemCardPrice = 0;
        public static bool IsFormClosing = false, isFirstcheck = false;

        public static int ItemCardBarcodeID = 0;

        Boolean IsLoadItemform;
        public static Boolean IsItemSave = false, ischeck = false;

        List<ObjectHelper.ItemCardObjectClass> dictExpiryDetails = new List<ObjectHelper.ItemCardObjectClass>();

        BindingList<ObjectHelper.ItemCardObjectClass> bd = new BindingList<ObjectHelper.ItemCardObjectClass>();
        int CheckExpiry = 0;
        enum ItemType { Goods, SecondHand, Labour, Meal }

        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, isFromCancel = false;
        int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        public static bool AdditionalBarcodeScreen = false;
        List<ItemCardObjectClass> ListParticularPackageDetails = new List<ItemCardObjectClass>();
        bool isFromBarcodeScan = false;
        DataSet dataforItemPlace = new DataSet();
        DataTable dtAllItems = new DataTable();
        DataTable dtAllPlace = new DataTable();
        #endregion

        #region Constructor
        public ItemCard()
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
            ObjItemCardHelper = new ItemCardHelper();


        }
        #endregion

        #region ItemCard_Load
        private void ItemCard_Load(object sender, EventArgs e)
        {
            try
            {
                cmbItemName.MatchingMethod = StringMatchingMethod.UseRegexs;
                IsLoadItemform = true;
                //ObjItemCardHelper.LoadItemDetails();Commented on 09jan2015
                AssignToControls();
                txtBarcodes.Text = GeneralFunction.PurchaseBarcode;
                txtBarcodes.Focus();
                txtBarcodes.Select();
                IsLoadItemform = false;
                cmbItemType.SelectedIndex = 0;

                cmbItemName.Select();
                cmbItemName.Focus();

                // cmbItemName.Text = string.Empty;
                chkExpiry.Checked = GeneralOptionSetting.FlagUseExpiryDefaultInItemCard == "Y" ? true : false; // on 03-11-2014 by Ritu, Expiry checked by default according to option settings.
                HideControls();
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ItemCard_Load");
            }


        }

        private void ReLoad()
        {
            try
            {
                IsLoadItemform = true;
                //ObjItemCardHelper.LoadItemDetails();Commented on 09jan2015
                AssignToControls();
                txtBarcodes.Text = GeneralFunction.PurchaseBarcode;
                txtBarcodes.Focus();
                txtBarcodes.Select();
                IsLoadItemform = false;
                //cmbItemType.SelectedIndex = 0;

                cmbItemName.Select();
                cmbItemName.Focus();

                // cmbItemName.Text = string.Empty;
                chkExpiry.Checked = GeneralOptionSetting.FlagUseExpiryDefaultInItemCard == "Y" ? true : false; // on 03-11-2014 by Ritu, Expiry checked by default according to option settings.
                HideControls();
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ItemCard_Load");
            }

        }

        private void HideControls()
        {
            txtMaxOrder.Visible = lblMaxOrder.Visible = GeneralOptionSetting.FlagDontTabToReorderandMaxpoint == "Y" ? false : true;
            txtReorder.Visible = lblReorder.Visible = GeneralOptionSetting.FlagDontTabToReorderandMaxpoint == "Y" ? false : true;
            cmbItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            lblItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            lblPackagePCs.Visible = txtPackagePcs.Visible = GeneralOptionSetting.FlagHidePackageQuantity != "Y" ? true : false;
            //picItem.Visible = GeneralOptionSetting.FlagUseItemPhoto != "Y" ? false : true;
            //btnBrowse.Visible = GeneralOptionSetting.FlagUseItemPhoto != "Y" ? false : true;
            //lblLoadPhoto.Visible = GeneralOptionSetting.FlagUseItemPhoto != "Y" ? false : true;
            chkExpiry.Visible = (GeneralOptionSetting.FlagPurchase_HideExpiryFiled != "Y" && GeneralOptionSetting.FlagSale_HideExpiryFiled != "Y");

        }

        private void focus(string Name)
        {
            //   string Name = "cmbItemName";
            foreach (Control ct in this.Controls)
            {
                if (ct.Name == Name)
                {

                    ct.Focus();
                    break;
                }
            }

        }
        #endregion

        #region Method

        public void AssignToControls()
        {
            dataforItemPlace = ObjItemCardHelper.GetAllItems();
            dtAllItems = dataforItemPlace.Tables[0];
            dtAllPlace = dataforItemPlace.Tables[1];
            //if (ObjItemCardHelper.dictLoad["ItemInfo"].Count > 0)
            //{Changed Condition on 09jan2015 for barcode scanning
            if (dtAllItems.Rows.Count > 0 && dtAllItems != null)
            {
                //  this.cmbItemName.SelectedIndexChanged -= new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
                //cmbItemNo.DataSource = null;

                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemId";
                /// cmbItemNo.DataSource = ObjItemCardHelper.dictLoad["ItemInfo"].Select(e => e.ItemId).ToList();
                DataView dvfilter = new DataView(dtAllItems);
                dvfilter.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dvfilter.ToTable(); //ObjItemCardHelper.dictLoad["ItemInfo"].Where(i => i.ItemNumber != string.Empty).ToList();
                cmbItemNo.SelectedIndex = -1;
                //   cmbItemName.DataSource = ObjItemCardHelper.dictLoad["ItemInfo"].Select(e => new { e.ItemId, e.Items }).ToList();
                // cmbItemName.DataSource = null;
                //cmbItemName.DataSource = new BindingSource();
                cmbItemName.BindingContext = new BindingContext();
                cmbItemName.DisplayMember = "Items";
                cmbItemName.ValueMember = "ItemId";
                cmbItemName.DataSource = dtAllItems; //ObjItemCardHelper.dictLoad["ItemInfo"];
                // cmbItemNo.DisplayMember = "ItemID";

                cmbItemName.SelectedIndex = -1;

                //this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            }
            else
            {
                cmbItemNo.DataSource = null;
                cmbItemName.DataSource = null;
            }
            if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
            {
               // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
               // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }

            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;

            // cmbCategory.SelectedIndex = -1;commended by Meena.R on 05Nov2014 default selection category

            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;

            //cmbCompany.SelectedIndex = -1;commended by Meena.R on 05Nov2014 default selection category
            //if (ObjItemCardHelper.dictLoad["ItemPlace"].Count > 0)
            //{Changed on 09jan2015 for barcode scanning
            if (dtAllPlace != null && dtAllPlace.Rows.Count > 0)
            {
                cmbItemPlace.DisplayMember = "PlaceName";
                cmbItemPlace.ValueMember = "ItemPlaceID";
                cmbItemPlace.DataSource = dtAllPlace; //ObjItemCardHelper.dictLoad["ItemPlace"];
                cmbItemPlace.SelectedIndex = -1;
            }
            this.cmbItemType.SelectedIndexChanged -= new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            cmbItemType.DisplayMember = "Items";
            cmbItemType.ValueMember = "ItemType";
            cmbItemType.DataSource = bd;
            // cmbItemType.SelectedIndex = -1;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
        }

        public void SetLanguage()
        {
            lblAvg.Text = Additional_Barcode.GetValueByResourceKey(lblAvg.Tag.ToString());
            lblBarcode.Text = Additional_Barcode.GetValueByResourceKey(lblBarcode.Tag.ToString());
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey(lblCategory.Tag.ToString());
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey(lblCompany.Tag.ToString());
            lblCost.Text = Additional_Barcode.GetValueByResourceKey(lblCost.Tag.ToString());
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey(lblItemName.Tag.ToString());
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey(lblItemNo.Tag.ToString());
            lblItemPlace.Text = Additional_Barcode.GetValueByResourceKey(lblItemPlace.Tag.ToString());
            lblItemPrice.Text = Additional_Barcode.GetValueByResourceKey(lblItemPrice.Tag.ToString());
            lblItemType.Text = Additional_Barcode.GetValueByResourceKey(lblItemType.Tag.ToString());
            lblLastCost.Text = Additional_Barcode.GetValueByResourceKey(lblLastCost.Tag.ToString());
            lblLoadPhoto.Text = Additional_Barcode.GetValueByResourceKey(lblLoadPhoto.Tag.ToString());
            lblMaxOrder.Text = Additional_Barcode.GetValueByResourceKey(lblMaxOrder.Tag.ToString());
            lblMinimumPrice.Text = Additional_Barcode.GetValueByResourceKey(lblMinimumPrice.Tag.ToString());
            lblNearestExpiry.Text = Additional_Barcode.GetValueByResourceKey(lblNearestExpiry.Tag.ToString());
            lblPackagePCs.Text = Additional_Barcode.GetValueByResourceKey(lblPackagePCs.Tag.ToString());
            lblProfitRate.Text = Additional_Barcode.GetValueByResourceKey(lblProfitRate.Tag.ToString());
            lblPurchase.Text = Additional_Barcode.GetValueByResourceKey(lblPurchase.Tag.ToString());
            lblReorder.Text = Additional_Barcode.GetValueByResourceKey(lblReorder.Tag.ToString());
            lblSpoiled.Text = Additional_Barcode.GetValueByResourceKey(lblSpoiled.Tag.ToString());
            lblStock.Text = Additional_Barcode.GetValueByResourceKey(lblStock.Tag.ToString());
            lblWholeSale.Text = Additional_Barcode.GetValueByResourceKey(lblWholeSale.Tag.ToString());
            chkHideItem.Text = Additional_Barcode.GetValueByResourceKey(chkHideItem.Tag.ToString());
            chkExpiry.Text = Additional_Barcode.GetValueByResourceKey(chkExpiry.Tag.ToString());
            btnBarcode.Text = Additional_Barcode.GetValueByResourceKey(btnBarcode.Tag.ToString()) + "F2";
            btnBrowse.Text = Additional_Barcode.GetValueByResourceKey(btnBrowse.Tag.ToString());
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey(btnCancel.Tag.ToString());
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey(btnDelete.Tag.ToString());
            btnGeneratebarcodeList.Text = Additional_Barcode.GetValueByResourceKey(btnGeneratebarcodeList.Tag.ToString());
            btnInventoryAdjustment.Text = Additional_Barcode.GetValueByResourceKey(btnInventoryAdjustment.Tag.ToString());
            btnInventorylist.Text = Additional_Barcode.GetValueByResourceKey(btnInventorylist.Tag.ToString());
            btnItemStock.Text = Additional_Barcode.GetValueByResourceKey(btnItemStock.Tag.ToString());
            btnNew.Text = Additional_Barcode.GetValueByResourceKey(btnNew.Tag.ToString()) + "F4";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey(btnPrint.Tag.ToString());
            btnPrintBarcode.Text = Additional_Barcode.GetValueByResourceKey(btnPrintBarcode.Tag.ToString());
            btnSave.Text = Additional_Barcode.GetValueByResourceKey(btnSave.Tag.ToString()) + "F5";
            btnAdditionalBarcode.Text = Additional_Barcode.GetValueByResourceKey(btnAdditionalBarcode.Tag.ToString()) + "F1";
            btnClose.Text = Additional_Barcode.GetValueByResourceKey(btnClose.Tag.ToString());
            grpItemInfo.Text = Additional_Barcode.GetValueByResourceKey(grpItemInfo.Tag.ToString());
            this.Text = Additional_Barcode.GetValueByResourceKey(this.Tag.ToString());
            bd.Add(new ObjectHelper.ItemCardObjectClass { Items = Additional_Barcode.GetValueByResourceKey("Goods"), ItemType = 1 });
            bd.Add(new ObjectHelper.ItemCardObjectClass { Items = Additional_Barcode.GetValueByResourceKey("SecondHand"), ItemType = 2 });
            bd.Add(new ObjectHelper.ItemCardObjectClass { Items = Additional_Barcode.GetValueByResourceKey("Labour"), ItemType = 3 });
            bd.Add(new ObjectHelper.ItemCardObjectClass { Items = Additional_Barcode.GetValueByResourceKey("Meal"), ItemType = 4 });
        }


        public void ClearTextField()
        {
            //chkExpiry.Leave -= new System.EventHandler(chkExpiry_Leave);
            ///  chkExpiry.CheckedChanged -= new System.EventHandler(chkExpiry_CheckedChanged);---commented on 15/03/2014
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass = new ObjectHelper.ItemCardObjectClass();

            // cmbItemNo.Text = string.Empty;
            cmbItemNo.SelectedIndex = -1;
            cmbItemNo.Text = string.Empty;
            // cmbItemType.SelectedIndex = 0;
            cmbItemName.SelectedIndex = -1;
            cmbItemName.Text = string.Empty;
            chkHideItem.Checked = false;
            if (!isFromBarcodeScan) //Added on 31-Oct-2014
            {
                txtBarcodes.Clear();
            }
            // lblCategory.Text = "Category";
            // lblCompany.Text = "Company";
            cmbCategory.SelectedIndex = -1;
            cmbCompany.SelectedIndex = -1;
            txtReorder.Text = "1";
            txtMaxOrder.Text = "100";
            txtPackagePcs.Text = "1";
            txtPrice.Text = "0.000";
            txtWholeSale.Text = "0.000";
            txtMinimumPrice.Text = "0.000";
            cmbItemPlace.SelectedIndex = -1;
            //chkExpiry.Checked = false;
            txtCost.Clear();
            txtLastCost.Clear();
            txtAverage.Clear();
            txtStock.Clear();
            txtProfitRate.Clear();
            txtLastPurchases.Clear();
            txtTotalSpoiled.Clear();
            cmbExpiryDate.Text = string.Empty;
            // cmbItemName.Focus();
            txtImgPath.Text = string.Empty;
            picItem.Image = null;
            chkExpiry.Leave += new System.EventHandler(chkExpiry_Leave);

            cmbExpiryDate.DataSource = null;
            // chkExpiry.CheckedChanged += new System.EventHandler(chkExpiry_CheckedChanged);
            //cmbItemName.AutoCompleteMode = AutoCompleteMode.Suggest;

            //Include on 22 april 2014 , to high light the  barcode button when having number of barcode

            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.NumberOfBarcode = 0;
            if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.NumberOfBarcode > 1)
            {
                btnAdditionalBarcode.BackColor = Color.Red;
            }
            else { btnAdditionalBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption; }
            cmbItemName.SelectAll();
            cmbItemName.Focus();
            chkExpiry.Checked = GeneralOptionSetting.FlagUseExpiryDefaultInItemCard == "Y" ? true : false;
            if (cmbItemType.SelectedIndex == 2 || cmbItemType.SelectedIndex == 3)
                txtPackagePcs.Enabled = false;
            else
                txtPackagePcs.Enabled = true;//added on 24jan2015

        }
        public void AssignFromControls()
        {
            //  ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = OldItemId == false ? 0 : ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldItemId;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Items = cmbItemName.Text.Trim();
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode = txtBarcodes.Text.Trim();
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CategoryId = cmbCategory.SelectedIndex == -1 ? 1001 : Convert.ToInt32(cmbCategory.SelectedValue);//line Changed By Meena.R default cat com ID 1001
            //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType =Convert.ToInt32(ObjItemCardHelper. GetItemTypeValue(cmbItemType.Text.ToString()));
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType = Convert.ToInt32(ObjItemCardHelper.GetItemTypeValue(cmbItemType.SelectedIndex.ToString()));
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemPlaceId = cmbItemPlace.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbItemPlace.SelectedValue);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CompId = cmbCompany.SelectedIndex == -1 ? 1001 : Convert.ToInt32(cmbCompany.SelectedValue);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemCost = txtCost.Text == string.Empty ? 0 : Convert.ToDecimal(txtCost.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost = txtLastCost.Text == string.Empty ? 0 : Convert.ToDecimal(txtLastCost.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = txtPackagePcs.Text == string.Empty ? 0 : Convert.ToInt32(txtPackagePcs.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = chkExpiry.Checked;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Reorder = txtReorder.Text == string.Empty ? 0 : Convert.ToInt32(txtReorder.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = txtWholeSale.Text == string.Empty ? 0 : Convert.ToDecimal(txtWholeSale.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price = txtPrice.Text == string.Empty ? 0 : Convert.ToDecimal(txtPrice.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Maxorder = txtMaxOrder.Text == string.Empty ? 0 : Convert.ToInt32(txtMaxOrder.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = txtMinimumPrice.Text == string.Empty ? 0 : Convert.ToDecimal(txtMinimumPrice.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost = txtAverage.Text == string.Empty ? 0 : Convert.ToDecimal(txtAverage.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ImgPath = txtImgPath.Text == string.Empty ? "" : txtImgPath.Text;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Unit = 0;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemNumber = cmbItemNo.Text.Trim();
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = 0;
            if (picItem.Image != null)
            {

                MemoryStream ms = new MemoryStream();
                picItem.Image.Save(ms, picItem.Image.RawFormat);
                byte[] itemimg = new byte[ms.Length];
                itemimg = ms.GetBuffer();
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Image = itemimg;

            }
            else
            {
                byte[] itemimg = new byte[1];
                itemimg[0] = 0;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Image = itemimg;
            }
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.IsHide = chkHideItem.Checked == true ? true : false;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Status = 1;

            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CreatedBy = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ModifiedBy = GeneralFunction.UserId;
            if (AdditionalBarcodeScreen == true && ListParticularPackageDetails.Count > 0)
            {

                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = ListParticularPackageDetails[0].MinPrice;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = ListParticularPackageDetails[0].WholeSalePrice;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price = ListParticularPackageDetails[0].Price;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = ListParticularPackageDetails[0].UnitNameID;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = ListParticularPackageDetails[0].PackageQuantity;
            }
        }
        private void AssignFromObjectToControls()
        {
            cmbItemType.Text = ObjItemCardHelper.GetItemType(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType);
            txtBarcodes.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
            chkHideItem.Checked = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.IsHide;
            IsLoadItemform = true;
            cmbItemName.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Items;
            IsLoadItemform = false;
            cmbCategory.SelectedValue = Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CategoryId);
            cmbCompany.SelectedValue = Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CompId);
            //   cmbItemNo.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId.ToString();
            IsLoadItemform = true;
            cmbItemNo.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemNumber.ToString();
            IsLoadItemform = false;

            txtReorder.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Reorder.ToString();
            txtMaxOrder.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Maxorder.ToString();
            txtPackagePcs.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity.ToString();
            //commented on 07april2014

            //txtPrice.TextChanged -= txtCost_TextChanged;
            //txtCost.TextChanged -= txtCost_TextChanged;

            //txtPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price.ToString("#########0.000");
            PriceValue();
            txtCost.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemCost.ToString("#########0.000");
            //txtPrice.TextChanged += txtCost_TextChanged;
            //txtCost.TextChanged += txtCost_TextChanged;

            txtWholeSale.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice.ToString("#########0.000");
            txtMinimumPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice.ToString("#########0.000");
            cmbItemPlace.SelectedValue = Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemPlaceId);
            CheckExpiry = 1;
            chkExpiry.Checked = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate;
            CheckExpiry = 0;

            txtStock.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.TotalStock.ToString(); //Totalstock is added to display total stocks all package qty
            txtLastPurchases.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase.ToString();
            txtLastCost.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost.ToString("#########0.000");
            //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost==Convert.ToDecimal("0.000"))
            //{ txtAverage.Text = "0.000"; }
            //else if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.StockInHand  > 0)
            //{
            //txtAverage.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost.ToString("############0.000");
            txtAverage.Text = Convert.ToDecimal(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost * (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity != 0 ? ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity : 1)).ToString("############0.000");
            //}
            //else txtAverage.Text = "0.000";


            //  txtAverage.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost.ToString("#########0.000");
            txtProfitRate.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ProfitPrice.ToString("#########0.000");

            txtTotalSpoiled.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemTotalSpoiled.ToString();
            //if (GetExpiryDate.Rows.Count > 0)
            //{
            //    cmbExpiryDate.DataSource = GetExpiryDate;
            //    cmbExpiryDate.DisplayMember = "Expiry";
            //    cmbExpiryDate.ValueMember = "Expiry";
            //}
            if (dictExpiryDetails.Count > 0)
            {
                cmbExpiryDate.DataSource = dictExpiryDetails.Select(e => e.ItemExpiry).ToList();
                //  cmbExpiryDate.DisplayMember = "Expiry";
                //cmbExpiryDate.ValueMember = lstExpiryDates[0];
            }
            else
            {

                cmbExpiryDate.DataSource = null;
            }
            if (!string.IsNullOrEmpty(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ImgPath))
            {


                byte[] b = (byte[])ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Image;

                if (b.Length > 1)
                {
                    MemoryStream stream = new MemoryStream(b, true);
                    Bitmap bmp = new Bitmap(stream);
                    picItem.Image = Image.FromStream(stream);
                }
                else
                {
                    picItem.Image = null;
                    //string Filename;
                    //Filename = Application.StartupPath + "\\Images\\almaqar_logo.png";
                    //Pic_Item.Image = Image.FromFile(Filename);
                }

            }

        }
        private void GetMoneyDetails()
        {
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price = txtPrice.Text == string.Empty ? 0 : Convert.ToDecimal(txtPrice.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemCost = Convert.ToDecimal(txtCost.Text.Length == 0 ? "0" : txtCost.Text);
        }
        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    //(from Control ctrl in cti.Controls
                    // select ctrl).ToList().ForEach(ctrl => ctrl.Font = new System.Drawing.Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
            }
        }
        #endregion

        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //txtCost.Focus();
                ClearTextField();
                ////cmbItemName.SelectAll();
                //cmbItemName.Focus();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnNew_Click");
            }
        }

        private void GenerateBarCode()
        {
            try
            {

                //if (!string.IsNullOrEmpty(cmbItemName.Text))
                //{
                //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = txtBarcodes.Text.Trim();
                ObjItemCardHelper.GenerateBarCode();
                txtBarcodes.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                if (GeneralOptionSetting.FlagHideItemNumber != "Y")
                {
                    cmbItemNo.Focus();
                }
                else
                {
                    cmbItemName.Focus();
                }
                //}
                //else
                //{

                //    GeneralFunction.ErrInfo(Constants.ITEMNAME, ActionType.Information.ToString());
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnBarcode_Click");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                if (cmbItemName.SelectedValue == null & cmbItemName.Text != string.Empty)
                {
                    string name = cmbItemName.Text.ToString();
                    DataRow[] drrow = dtAllItems.Select("Items='" + name + "'");
                    if (drrow.Length > 0)
                    {
                        foreach (DataRow dr in drrow)
                        {
                            cmbItemName.SelectedIndex = dr.Table.Rows.IndexOf(dr);
                        }
                    }
                    //cmbItemName.SelectedIndex = ObjItemCardHelper.dictLoad["ItemInfo"].FindIndex(j => j.Items == name);Commented on 09jan2015 for Barcode Performance Tuning
                    count = 1;
                    if (txtBarcodes.Text != "")
                    {
                    var IsAlreadyExist = ObjItemCardHelper.CheckBarcode(txtBarcodes.Text);

                    if (IsAlreadyExist && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CompId == 0)
                    {
                            CommonHelper.GeneralFunction.Information(Constants.ITEMBARCODE_DUP, ActionType.Save.ToString());
                           // MessageBox.Show("The barcode already exists please generate new barcode");
                            txtBarcodes.Text = "";
                            return;
                            //if (txtBarcodes.Text == "")
                            //{
                            //    if (!IsFormClosing)
                            //    {
                            //      // CommonHelper.GeneralFunction.Information(Constants.ITEMBARCODE, ActionType.Save.ToString());
                            //        MessageBox.Show("Barcode should not be empty");
                            //        return;
                            //    }

                            //}


                    }
                    }
                }

                AssignFromControls();
                //if(count == 0 || IsFormClosing == true)
               // {
                    if (txtBarcodes.Text == "")
                    {
                        //CommonHelper.GeneralFunction.Information(Constants.ITEMBARCODE_GEN, ActionType.Save.ToString());
                      // MessageBox.Show("Barcode Automatically Generated For This Item");
                        //return;
                        GenerateBarCode();
                    }
               // }

                if (count == 0 || cmbItemName.SelectedIndex == -1)
                {
                    
                  //  ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(cmbItemName.SelectedValue);
                    bool expiry = false;
                    
                    bool IsHide = false;
                    if (chkHideItem.Checked) {
                        IsHide = true;
                    }
                    if (chkExpiry.Checked)
                    {
                        expiry = true;
                    }
                    string Palace = "";
                    if (cmbItemPlace.SelectedValue != null) {
                        Palace = cmbItemPlace.SelectedValue.ToString();
                    }
                    if (cmbCategory.SelectedValue == null) { cmbCategory.SelectedValue = 1001; }
                    if (cmbItemName.SelectedValue == null) {
                        //ItemCard.IsFormClosing = false;
                        ObjItemCardHelper.SaveItemCardDetail();
                        IsLoadItemform = true;
                        AssignToControls();
                        IsLoadItemform = false;
                        ClearTextField();
                        IsItemSave = true;
                        ReLoad();
                    }

                    else if (ObjItemCardHelper.ChecktemDetails(cmbItemName.SelectedValue.ToString(), txtPrice.Text, txtBarcodes.Text, txtPrice.Text, txtPackagePcs.Text, cmbCategory.SelectedValue.ToString(), cmbCompany.SelectedValue.ToString(), cmbItemType.SelectedValue.ToString(), txtWholeSale.Text, txtMinimumPrice.Text, expiry, IsHide, Palace, cmbItemNo.Text.ToString()))
                    {
                        IsLoadItemform = true;
                        AssignToControls();
                        IsLoadItemform = false;
                        ClearTextField();
                        IsItemSave = true;
                    }
                    else
                    {
                        if (ObjItemCardHelper.SaveItemCardDetail())
                        {
                            //if (IsExist==1) {
                            //    MessageBox.Show("The Barcode generated against your item and saved");
                            //}

                            IsLoadItemform = true;
                            AssignToControls();
                            IsLoadItemform = false;
                            ClearTextField();
                            IsItemSave = true;
                        }
                        else
                        {
                            ChangeProperties(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ValidationString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }

        }
        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbItemType.SelectedIndex == 1)//SecondHand
                {
                    txtStock.Text = string.Empty;
                    txtStock.Enabled = false;
                    txtMaxOrder.Text = string.Empty;
                    txtMaxOrder.Enabled = false;
                    txtReorder.Text = string.Empty;
                    txtReorder.Enabled = false;
                    CheckExpiry = 1;
                    chkExpiry.Checked = false;
                    CheckExpiry = 0;
                    chkExpiry.Enabled = false;
                    txtAverage.Text = string.Empty;
                    txtAverage.ReadOnly = true;
                    txtLastPurchases.Text = string.Empty;
                    txtLastPurchases.Enabled = false;
                    txtTotalSpoiled.Text = string.Empty;
                    txtTotalSpoiled.Enabled = false;
                    txtPackagePcs.Text = "1";
                    txtPackagePcs.Enabled = false;
                    txtCost.Enabled = false;

                }
                else if (cmbItemType.SelectedIndex == 2)//Labour
                {
                    txtStock.Text = string.Empty;
                    txtStock.Enabled = false;
                    txtMaxOrder.Text = string.Empty;
                    txtMaxOrder.Enabled = false;
                    txtReorder.Text = string.Empty;
                    txtReorder.Enabled = false;
                    txtAverage.Text = string.Empty;
                    txtAverage.ReadOnly = false;
                    txtLastPurchases.Text = string.Empty;
                    txtLastPurchases.Enabled = false;
                    txtTotalSpoiled.Text = string.Empty;
                    txtTotalSpoiled.Enabled = false;
                    CheckExpiry = 1;
                    chkExpiry.Checked = false;
                    CheckExpiry = 0;
                    chkExpiry.Enabled = false;
                    txtPackagePcs.Text = "1";// string.Empty;
                    txtPackagePcs.Enabled = false;
                    txtCost.Enabled = true;
                }
                else if (cmbItemType.SelectedIndex == 3)//Meal
                {

                    txtStock.Text = string.Empty;
                    txtStock.Enabled = false;
                    txtMaxOrder.Text = string.Empty;
                    txtMaxOrder.Enabled = false;
                    txtReorder.Text = string.Empty;
                    txtReorder.Enabled = false;
                    CheckExpiry = 1;
                    chkExpiry.Checked = false;
                    CheckExpiry = 0;
                    chkExpiry.Enabled = false;
                    txtAverage.Text = string.Empty;
                    txtAverage.ReadOnly = false;
                    txtLastPurchases.Text = string.Empty;
                    txtLastPurchases.Enabled = false;
                    txtTotalSpoiled.Text = string.Empty;
                    txtTotalSpoiled.Enabled = false;
                    txtPackagePcs.Text = "1";// string.Empty;
                    txtPackagePcs.Enabled = false;
                    txtCost.Enabled = true;
                }
                else if (cmbItemType.SelectedIndex == 0)// Goods
                {

                    txtStock.Text = string.Empty;
                    txtStock.Enabled = false;
                    txtMaxOrder.Text = "100";
                    txtMaxOrder.Enabled = true;
                    txtReorder.Text = "1";
                    txtReorder.Enabled = true;
                    CheckExpiry = 1;
                    chkExpiry.Enabled = true;
                    CheckExpiry = 0;
                    txtAverage.Enabled = false;
                    txtLastPurchases.Enabled = false;
                    txtTotalSpoiled.Enabled = false;
                    txtPackagePcs.Text = "1";
                    txtPackagePcs.Enabled = true;
                    if (chkExpiry.Visible == true && GeneralOptionSetting.FlagUseExpiryDefaultInItemCard == "Y")
                    { chkExpiry.Checked = true; }
                    txtCost.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }

        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(cmbItemName.SelectedValue);

                if (IsLoadItemform != true && cmbItemName.SelectedIndex != -1)
                {
                    if (ObjItemCardHelper.GetItemDetails())
                    {
                        dictExpiryDetails = ObjItemCardHelper.GetExpiryItemDetails();
                        CheckExpiry = 1;
                        ischeck = true;
                        AssignFromObjectToControls();
                        ischeck = false;
                        CheckExpiry = 0;
                        cmbCategory.Focus();
                        //Include on 22 april 2014 , to high light the  barcode button when having number of barcode
                        if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.NumberOfBarcode > 1)
                        {
                            btnAdditionalBarcode.BackColor = Color.Red;
                        }
                        else { btnAdditionalBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption; }
                        if (Convert.ToInt32(txtStock.Text) > 0 || ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 2 || ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 3 || ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 4)//this Condition added on 12Nov2014 By Meena.R
                        {
                            txtPackagePcs.Enabled = false;
                        }
                        else
                        {
                            txtPackagePcs.Enabled = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemName_SelectedIndexChanged");
            }
        }


        private void btnAdditionalBarcode_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(cmbItemName.Text))
                {
                    if (cmbItemName.SelectedValue != null)
                    {
                        // ItemCardBarcode = txtBarcodes.Text;
                        //ItemCardPackageQty = Convert.ToInt32(txtPackagePcs.Text);
                        //ItemCardPrice = Convert.ToDecimal(txtPrice.Text);
                        ItemCardBarcodeID = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId;
                        Additional_Barcode additional_barcode = new Additional_Barcode(ObjItemCardHelper);
                        additional_barcode.Tag = cmbItemName.SelectedValue;
                        additional_barcode.ShowDialog();
                        IsAdditionboxClosed = "yes";
                        //txtBarcodes.Text = ItemCardBarcode.ToString();
                        //txtPackagePcs.Text = ItemCardPackageQty.ToString();
                        //txtPrice.Text = ItemCardPrice.ToString("###########.000");
                        // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode = ItemCardBarcode;
                        //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = 0;
                        if (additional_barcode.RemoveBarcode == ItemCardBarcodeID)
                        {
                            txtBarcodes.Text = string.Empty;
                        }
                        ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId = ItemCardBarcodeID;
                        //include the this condition on 15 may 2014 to get the details for the particular barcode id from barcode table 

                        ListParticularPackageDetails = ObjItemCardHelper.GetUnitNameBarcodeDetails();
                        // to clear and make it has a field to insert a new item on item card form on 28 april 2014 
                        AdditionalBarcodeScreen = true;
                        //btnSave_Click(sender, e);
                        AdditionalBarcodeScreen = false;
                        ListParticularPackageDetails.Clear();


                        additional_barcode = null;  //Performance fine tune by praba on 19-Nov
                        //;Commented on 20/03/2014
                        //if (additional_barcode.RemoveBarcode == string.Empty)
                        //{
                        //    txtBarcodes.Text = string.Empty;
                        //}

                    }
                    else
                    {
                        GeneralFunction.Information(Constants.AdditionalBarcode, ActionType.Information.ToString());
                    }
                }
                else
                {
                    GeneralFunction.Information(Constants.ITEMNAME, ActionType.Information.ToString());

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnAdditionalBarcode_Click");
            }


        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            try
            {

                //if (!string.IsNullOrEmpty(cmbItemName.Text))
                //{
                //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = txtBarcodes.Text.Trim();
                ObjItemCardHelper.GenerateBarCode();
                txtBarcodes.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                if (GeneralOptionSetting.FlagHideItemNumber != "Y")
                {
                    cmbItemNo.Focus();
                }
                else
                {
                    cmbItemName.Focus();
                }
                //}
                //else
                //{

                //    GeneralFunction.ErrInfo(Constants.ITEMNAME, ActionType.Information.ToString());
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnBarcode_Click");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbItemName.Text != string.Empty)
                {
                    OpenFileDialog fd;
                    fd = new OpenFileDialog();
                    fd.Title = "Open Image Files";
                    fd.Filter = "Image Files(JPEG,BMP,ICO,PNG,GIF)|*.jpg;*.bmp;*.ico;*.png;*.gif";
                    fd.ShowDialog();
                    if (fd.FileName != string.Empty)
                    {
                        picItem.Image = new Bitmap(fd.FileName);
                        picItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    txtImgPath.Text = fd.FileName;
                }
                else
                {
                    GeneralFunction.Information(Constants.ITEMNAME, ActionType.Information.ToString());
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnBrowse_Click");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ModifiedBy = GeneralFunction.UserId;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Status = 0;
                if (ObjItemCardHelper.DeleteItemDetails())
                {

                    ClearTextField();
                    IsLoadItemform = true;
                    // ObjItemCardHelper.LoadItemDetails();Commendted on 09jan2015 in this fun called in  AssignToControls();

                    AssignToControls();
                    IsLoadItemform = false;
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " btnDelete_Click");
            }
        }

        private void txtReorder_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtReorder.Text == string.Empty)
                {
                    txtReorder.Text = "1";
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtReorder_Leave");
            }
        }

        private void txtReorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                //if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar != 46) != true)
                //    e.Handled = true;Commended By Meena.R On 11Nov2014
                //else if (e.KeyChar == 13)
                //    SendKeys.Send("{TAB}");               
                if (GeneralFunction.NumericOnly(e) == true || e.KeyChar == 46) e.Handled = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtReorder_KeyPress");
            }
        }

        private void txtMaxOrder_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtMaxOrder.Text == string.Empty)
                {
                    txtMaxOrder.Text = "100";
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtMaxOrder_Leave");
            }
        }


        private void txtPackagePcs_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtPackagePcs.Text == string.Empty || Convert.ToDecimal(txtPackagePcs.Text) == 0)
                {
                    txtPackagePcs.Text = "1";
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtPackagePcs_Leave");
            }
        }

        private void txtWholeSale_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtWholeSale.Text != string.Empty && (txtWholeSale.Text != "."))
                {
                    if (Convert.ToDecimal(txtWholeSale.Text) > Convert.ToDecimal(txtWholeSale.Text))//this line changed on 28Aug2014 by meena.R removed vaildation with price
                    {
                        GeneralFunction.Information("WholeSalePriceLessthanPrice", this.Tag.ToString().ToString());
                        txtWholeSale.Focus();
                        txtWholeSale.SelectAll();
                    }
                    else
                    { txtWholeSale.Text = Convert.ToDecimal(txtWholeSale.Text).ToString("0.000"); }

                }
                { txtWholeSale.Text = Convert.ToDecimal(txtWholeSale.Text).ToString("0.000"); }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtWholeSale_Leave");
            }



        }

        private void txtMinimumPrice_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txtMinimumPrice.Text != string.Empty && (txtMinimumPrice.Text != "."))
                {
                    if (Convert.ToDecimal(txtMinimumPrice.Text) > Convert.ToDecimal(txtPrice.Text))
                    {
                        GeneralFunction.Information("EqualPrice", this.Tag.ToString());
                        txtMinimumPrice.Focus();
                        txtMinimumPrice.SelectAll();

                    }
                    else if (Convert.ToDecimal(txtMinimumPrice.Text) > Convert.ToDecimal(txtPrice.Text))
                    {
                        GeneralFunction.Information("MinimumPriceLessthanWholeSalePrice", this.Tag.ToString());
                        txtMinimumPrice.Focus();
                        txtMinimumPrice.SelectAll();

                    }
                    else
                    { txtMinimumPrice.Text = Convert.ToDecimal(txtMinimumPrice.Text).ToString("0.000"); }
                }
                { txtMinimumPrice.Text = Convert.ToDecimal(txtMinimumPrice.Text == string.Empty ? "0" : txtMinimumPrice.Text).ToString("0.000"); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtMinimumPrice_Leave");
            }

        }



        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemName_KeyDown");
            }
        }

        //private void txtPackagePcs_MouseMove(object sender, MouseEventArgs e)
        //{
        //    try
        //    {

        //        if (txtPackagePcs.Text.Length > 0 && int.Parse(txtPackagePcs.Text) <= 0)
        //        {
        //            GeneralFunction.Information("Packagepiecezero", this.Tag.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemName_DrawItem");
        //    }
        //}

        private void chkExpiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    //chkExpiry.Enabled = true;


                    InvokeOnClick(btnSave, EventArgs.Empty);
                    IsItemSave = true;
                    // QuestionExpiry = true;


                    // SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " chkExpiry_KeyPress");
            }
        }

        private void chkExpiry_Leave(object sender, EventArgs e)
        {
            //try
            //{

            //    if (IsItemSave == true)
            //    {
            //        //if (GeneralFunction.Question("WantSaveItem",this.Tag.ToString()) == DialogResult.Yes)
            //        //{
            //        //chkExpiry_CheckedChanged(sender, e);----------Commented on 15/03/2014
            //        InvokeOnClick(btnSave, EventArgs.Empty);
            //        // }

            //    }
            //    IsItemSave = false;
            //}
            //catch (Exception ex)
            //{

            //     GeneralFunction.ErrInfo(ex.Message.ToString(),this.Tag.ToString());
            //          GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId,this.Tag.ToString(), " chkExpiry_Leave");
            //}
        }
        //-------------------Commented on 15/03/2014-------------
        //-----As per the client suggestion to remove the popup messge for expiry date validation-------------------------
        //void chkExpiry_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (CheckExpiry == 0)
        //        {
        //            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Items = cmbItemName.Text;
        //            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = chkExpiry.Checked;
        //            if (!chkExpiry.Checked)
        //            {
        //                if (ObjItemCardHelper.CheckExpiryStatus())
        //                {
        //                    //   ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = true;
        //                    chkExpiry.CheckedChanged -= chkExpiry_CheckedChanged;
        //                    chkExpiry.Checked = true;
        //                    chkExpiry.CheckedChanged += chkExpiry_CheckedChanged;

        //                }
        //                //   else
        //                //   {
        //                ////       ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = false;
        //                //       chkExpiry.CheckedChanged -= chkExpiry_CheckedChanged;
        //                //       chkExpiry.Checked = false;
        //                //       chkExpiry.CheckedChanged += chkExpiry_CheckedChanged;

        //                //   }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //          GeneralFunction.ErrInfo(ex.Message.ToString(),this.Tag.ToString());
        //              GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId,this.Tag.ToString(), " chkExpiry_CheckedChanged");
        //    }


        //}
        //-----------------------------------------------------------------------------------------------

        private void cmbItemPlace_Leave(object sender, EventArgs e)
        {
            //    try
            //    {

            //        if (chkExpiry.Enabled == false && IsItemSave )
            //        {
            //            if (GeneralFunction.Question("WantSaveItem", this.Tag.ToString()) == DialogResult.Yes)
            //            { 
            //                btnSave_Click(sender, e); }

            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //                        GeneralFunction.ErrInfo(ex.Message.ToString(),this.Tag.ToString());
            //                        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId,this.Tag.ToString(), " cmbItemPlace_Leave");
            //    }
        }


        private void cmbItemName_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            try
            {

                Graphics g = e.Graphics;
                //List<ObjectHelper.ItemCardObjectClass> lstCombo = (List<ObjectHelper.ItemCardObjectClass>)cmbItemName.DataSource;
                DataTable dtDrawItem = (DataTable)cmbItemName.DataSource;
                if (cmbItemName.SelectedIndex < -1 || dtDrawItem.Rows.Count < 0) return;
                Boolean ItemHideStatus;
                string ItemName;
                //ItemHideStatus = ObjItemCardHelper.dictLoad["ItemInfo"][e.Index].IsHide;
                ItemHideStatus = Convert.ToBoolean(dtDrawItem.Rows[e.Index]["IsHide"]);
                ItemName = dtDrawItem.Rows[e.Index]["Items"].ToString(); //ObjItemCardHelper.dictLoad["ItemInfo"][e.Index].Items;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                if (ItemHideStatus == true)
                {
                    e.DrawBackground();
                    e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), new SolidBrush(Color.Red), e.Bounds, sf);
                }
                else
                {
                    e.DrawBackground();
                    e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), new SolidBrush(Color.Black), e.Bounds, sf);

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemName_DrawItem");
            }

        }

        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }


        bool isFirst = false;
        string appval = "";
        private void cmbItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                //if (e.KeyData == Keys.Enter)
                //{
                //  e.Handled = true;
                //cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
                //SendKeys.Send("{TAB}");

                //cmbCategory.SelectAll();
                //cmbCategory.Focus();
                ////}

                if (e.KeyCode == Keys.F4)
                    e.Handled = true;

                //To hide the two drop down in same time done by Praba on 28-Oct
                //if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))
                //{
                //    if (((ComboBox)sender).DataSource != null)
                //    {
                //        if (((ComboBox)sender).DroppedDown == true)
                //            ((ComboBox)sender).DroppedDown = false;
                //    }

                //}

                //  else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Alt) && (e.KeyCode != Keys.Tab) && (e.KeyValue < 111 || e.KeyValue > 126))
                //  {
                //      if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin) && sender is ComboBox)
                //      {
                //          if (((ComboBox)sender).DataSource != null) ///there is no item on item table no need to open the drop down list 
                //          {
                //              if (((ComboBox)sender).DroppedDown == true)
                //                  ((ComboBox)sender).DroppedDown = false;
                //              if (((ComboBox)sender).Name == "cmbItemName" && cmbItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //              {
                //                  cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //                  cmbItemName.SelectedText = ((char)e.KeyValue).ToString();
                //                  cmbItemName.DroppedDown = true;
                //                  isFirst = true;
                //                  appval = ((char)e.KeyValue).ToString();

                //              }
                //              else if (((ComboBox)sender).Name == "cmbItemName")
                //              {
                //                  cmbItemName.DroppedDown = false;
                //                  if (isFirst)
                //                  {
                //                      cmbItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //                      isFirst = false;
                //                  }
                //              }
                //          }
                //      }
                //  }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemNo_KeyDown");
            }
        }

        private void cmbCompany_Leave(object sender, EventArgs e)
        {

            try
            {

                ComboBox cmb = (ComboBox)sender;
                if (cmb.Items.Count > 0)
                {
                    if (cmb.Text == string.Empty || cmb.SelectedIndex == -1)
                    {
                        cmb.SelectedIndex = 0;
                        if (cmb.Name == "cmbCompany" && cmb.Text == string.Empty)
                            cmb.Text = GeneralObjectClass.CompanyList[0].Company;
                        else
                            cmb.Text = GeneralObjectClass.CategoryList[0].Category;
                    }
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbCompany_Leave");
            }

        }

        private void txtPackagePcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                //if ((e.KeyChar >= 57 && e.KeyChar < 48) & e.KeyChar != 8 & e.KeyChar != 13 & (e.KeyChar == 46))
                //{ e.Handled = true; }
                if (GeneralFunction.NumericOnly(e) == true || e.KeyChar == 46) e.Handled = true;
                if (txtPackagePcs.Text.Length > 7)
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtPackagePcs_KeyPress");

            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {

                TextBox tx = (TextBox)sender;
                if (tx.Text != string.Empty && tx.Text != ".")
                {
                    //  tx.TextChanged -= txtCost_TextChanged;
                    tx.Text = Convert.ToDecimal(tx.Text).ToString("0.000");
                    // tx.TextChanged += txtCost_TextChanged;

                }
                else
                {
                    tx.Text = "0.000";
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbItemPlace_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                { SendKeys.Send("{TAB}"); }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemPlace_KeyDown");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbItemName.Text))
                {
                    if (ObjectHelper.GeneralOptionSetting.FlagQuitWithoutAsking != "Y")
                    {
                        IsFormClosing = true;
                        isFromCancel = true;
                        btnSave_Click(sender, e);
                        if (IsItemSave) { this.Close(); }
                        else { IsFormClosing = false; }
                    }

                }
                else this.Close();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }








        #region Barcode
        #region "Timer Tick Event"
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


        //            tmrBarcode.Enabled = false;
        //            string barcode = Convert.ToString(txtBarcode.Text);
        //            //if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            //{
        //            //    barcode = ScanValue + barcode;
        //            //}

        //            if (barcode.Length < 12)
        //            {
        //                barcode = ScanValue + barcode;
        //            }

        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                if (GeneralFunction.Question("AvailabeBarcode", this.Tag.ToString()) == DialogResult.Yes)
        //                {
        //                    cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                    cmbItemName.SelectAll();
        //                    cmbItemName.Focus();


        //                }
        //                ClearBarcodeValues();

        //            }
        //            else
        //            {
        //                if (GeneralFunction.Question("BarcodeNotSaved", this.Tag.ToString()) == DialogResult.Yes)
        //                {
        //                    txtBarcodes.Text = ScanValue + txtBarcode.Text;
        //                    //Cmb_ItemNo.Focus(); 
        //                    cmbItemName.SelectAll();
        //                    cmbItemName.Focus();
        //                    // InvokeOnClick(btnSave, EventArgs.Empty);
        //                }
        //                else { txtBarcode.Text = ""; }
        //                ClearBarcodeValues();
        //                cmbItemName.Focus();
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
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " tmrBarcode_Tick");
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
                        if (barcode.Trim().Length != 13)//added By T on 25Mar2019 if  we can continue it shown not available lastfocus control value no add
                        {
                            barcode = lastfocusedvalue + ScanValue + Convert.ToString(txtBarcode.Text);
                        }
                    }

                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());

                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        if (GeneralFunction.Question("AvailabeBarcode", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                            cmbItemName.SelectAll();
                            cmbItemName.Focus();
                        }
                        ClearBarcodeValues();
                    }
                    else
                    {
                        if (GeneralFunction.Question("BarcodeNotSaved", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            txtBarcodes.Text = ScanValue + txtBarcode.Text;
                            //Cmb_ItemNo.Focus(); 
                            cmbItemName.SelectAll();
                            cmbItemName.Focus();
                            //Added on 31-Oct-2014 by Seenivasan*******
                            isFromBarcodeScan = true;
                            ClearTextField();
                            isFromBarcodeScan = false;
                            //***************************
                            // InvokeOnClick(btnSave, EventArgs.Empty);
                        }
                        else { txtBarcode.Text = ""; }
                        ClearBarcodeValues();
                        cmbItemName.Focus();
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
            // finally { GeneralFunction.Trace("ItemCard Barcode END"); }
        }

        #endregion

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            ScanLetterStartTime = DateTime.Now;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            //cmbItemName.Focus();

        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tmrBarcode.Enabled == false)  //Performance fine tune by praba on 19-Nov
                {
                    tmrBarcode.Enabled = true;
                }
                //if (e.KeyValue == 13)
                //{
                //    cmbCategory.Focus();
                //}
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " tmrBarcode_Tick");
            }
        }

        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    try
        //    {


        //        if (this.ActiveControl.Name == "txtBarcode") return;

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
        //            //  if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
        //            if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval) | ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1)))
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = ScanValue + e.KeyChar.ToString();
        //            }
        //            else
        //            {
        //                ScanLetterStartTime = DateTime.Now;
        //                ScanValue = string.Empty;
        //                ScanValue = e.KeyChar.ToString();
        //            }
        //        }
        //        if (ScanValue.Length == 6)
        //        {
        //            lastFocusedControl = this.ActiveControl;
        //            if (lastFocusedControl != null)
        //            { lastfocusedvalue = lastFocusedControl.Text.Replace(ScanValue.Substring(0, ScanValue.Length - 1), string.Empty); }
        //            txtBarcode.Focus();
        //            //e.Handled = true;
        //        }
        //        //Cal Event Again
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
                //GeneralFunction.Trace("ItemCard Barcode START");
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

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbItemNo.Text) && cmbItemNo.SelectedIndex > -1 && IsLoadItemform == false)
                {
                    int value = Convert.ToInt32(cmbItemNo.SelectedValue);
                    cmbItemName.SelectedValue = value;
                    //cmbItemName_SelectedIndexChanged(cmbItemName, new EventArgs());
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemNo_SelectedIndexChanged");
            }
        }
        #region Shortcuty key
        private void ItemCard_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information quickpriceinformation = new Quick_Price_Information();
                    quickpriceinformation.ShowDialog();
                }
                if (e.KeyData == Keys.F4)
                {
                    //this.InvokeOnClick(btnNew, EventArgs.Empty);
                    btnNew_Click(sender, e);
                    //cmbItemNo.SelectAll();
                    //cmbItemNo.Focus();
                }
                if (e.KeyData == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
                if (e.KeyData == Keys.F1)
                {
                    btnAdditionalBarcode_Click(sender, e);
                }
                if (e.KeyData == Keys.F2)
                {
                    btnBarcode_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ItemCard_KeyDown");
            }
        }
        #endregion

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            Barcode_Print barcodeprint;
            try
            {
                if (UserScreenLimidations.PrintBarcode == true)
                {
                    barcodeprint = new Barcode_Print();  //Performance fine tune by praba on 19-Nov
                    barcodeprint.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPrintBarcode_Click");
            }
            finally
            {
                barcodeprint = null;
            }
        }
        private void btnInventorylist_Click(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.GetInventoryListDetails();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnInventorylist_Click");
            }
        }

        private void btnInventoryAdjustment_Click(object sender, EventArgs e)
        {
            Inventory_Adjustment inventoryadjustment;
            try
            {
                if (UserScreenLimidations.InventoryAdjustment == true)
                {
                    inventoryadjustment = new Inventory_Adjustment();
                    inventoryadjustment.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnInventoryAdjustment_Click");
            }
            finally
            {
                inventoryadjustment = null;
            }
        }

        private void btnGeneratebarcodeList_Click(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.GetBarcodeListForItem();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnGeneratebarcodeList_Click");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.PrintingTheItem();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnPrint_Click");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTextField();
                cmbItemName.Focus();
                cmbItemName.Select();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnCancel_Click");
            }
        }

        private void ItemCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbItemName.Text) && isFromCancel == false)
                {
                    if (ObjectHelper.GeneralOptionSetting.FlagQuitWithoutAsking != "Y")
                    {
                        IsFormClosing = true;
                        e.Cancel = true;
                        btnSave_Click(sender, e);
                        if (!IsItemSave) { e.Cancel = true; }
                        else
                        { e.Cancel = false; }
                        IsItemSave = false;
                        IsFormClosing = false;
                    }
                }
                else { e.Cancel = false; }
            }

            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ItemCard_FormClosing");
            }

        }

        private void btnItemStock_Click(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.StockInOutDetails();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnItemStock_Click");
            }

        }
        #endregion

        //private void cmbItemName_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        //cmbItemName.SelectedIndexChanged  += new EventHandler( cmbItemName_SelectedIndexChanged );
        //        cmbItemName_SelectedIndexChanged(cmbItemName, new EventArgs());

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemName_DropDownClosed");
        //    }
        //}

        //private void cmbItemName_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbItemName.AutoCompleteMode = AutoCompleteMode.None;

        //        }

        //        //((System.Windows.Forms.ComboBox)(sender)).dropDown true
        //        // if((ComboBox )sender).drDroppedDown==true )
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemName_DropDown");
        //    }

        //}

        private void cmbItemName_TextChanged(object sender, EventArgs e)
        {
            //string g=cmbItemName.Text;

            //List<ItemCardObjectClass> Item = new List<ItemCardObjectClass>();
            //Item = ObjItemCardHelper.dictLoad["ItemInfo"].ToList();
            //Item.Find(Ite1m => Ite1m.ItemName == g);
            //cmbItemName.DataSource = Item;

        }

        private void chkExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (IsItemSave == true && e.KeyCode == Keys.Enter)
                {
                    //if (GeneralFunction.Question("WantSaveItem",this.Tag.ToString()) == DialogResult.Yes)
                    //{
                    //chkExpiry_CheckedChanged(sender, e);----------Commented on 15/03/2014
                    //InvokeOnClick(btnSave, EventArgs.Empty);
                    // }
                }
                IsItemSave = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " chkExpiry_KeyDown");
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetMoneyDetails();
                ObjItemCardHelper.ProfitCalculation();
                txtProfitRate.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ProfitPrice.ToString("0.000");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        //private void cmbItemNo_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (((System.Windows.Forms.ComboBox)(sender)).DroppedDown == false)
        //        {
        //            cmbItemNo.AutoCompleteMode = AutoCompleteMode.None;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemNo_DropDown");
        //    }

        //}

        //private void cmbItemNo_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbItemNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        //cmbItemName.SelectedIndexChanged  += new EventHandler( cmbItemName_SelectedIndexChanged );
        //        cmbItemNo_SelectedIndexChanged(cmbItemNo, new EventArgs());

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemNo_DropDownClosed");
        //    }
        //}

        private void cmbItemPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (chkExpiry.Enabled == false && IsItemSave)
                {
                    //if (GeneralFunction.Question("WantSaveItem", this.Tag.ToString()) == DialogResult.Yes) commented on 09 may 2014
                    //{
                    btnSave_Click(sender, e);
                    // }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemPlace_Leave");
            }
        }

        private void txtBarcodes_Leave(object sender, EventArgs e)
        {
            try
            {
                //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = txtBarcodes.Text.Trim();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " txtBarcodes_Leave");
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46) != true)
                e.Handled = true;

            if (e.KeyChar == 46 && (((TextBox)sender).Text.Contains('.')))
                e.Handled = true;
        }

        private void cmbItemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (cmbItemName.SelectedIndex > -1 || cmbItemName.Text.Trim() != "")
                {
                    cmbCategory.Focus();
                }
            }
        }

        private void chkExpiry_CheckedChanged(object sender, EventArgs e)
        {

            if (cmbItemName.SelectedIndex > -1 && ischeck != true)
            {

                if (Convert.ToInt32(txtStock.Text == string.Empty ? "0" : txtStock.Text) <= 0)
                {

                }
                else
                {
                    ischeck = true;
                    chkExpiry.Checked = chkExpiry.Checked == false ? true : false;
                    GeneralFunction.Information("ThisItemHavetheStockYouCantUpdate", "ItemCard");
                    ischeck = false;
                    return;
                }
                isFirstcheck = chkExpiry.Checked == false ? true : false;
                if (Convert.ToInt32(txtStock.Text == string.Empty ? "0" : txtStock.Text) <= 0 && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate == isFirstcheck)
                {

                    if (GeneralFunction.Question("DoYouWanttoUpdatetheDetails", "Item Card") == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        ischeck = true;
                        chkExpiry.Checked = isFirstcheck;
                        ischeck = false;
                        return;
                    }
                }
            }
            else
            {
                ischeck = false;
            }
        }

        private void cmbItemNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbItemName.Focus();
        }

        private void txtBarcodes_Leave_1(object sender, EventArgs e)
        {
            if (txtBarcodes.Text != "")
            {
                var IsAlreadyExist = ObjItemCardHelper.CheckBarcode(txtBarcodes.Text);

                if (IsAlreadyExist && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CompId == 0)
                {
                    CommonHelper.GeneralFunction.Information(Constants.ITEMBARCODE_DUP, ActionType.Save.ToString());
                    // MessageBox.Show("The barcode already exists please generate new barcode");
                    txtBarcodes.Text = "";
                    return;
                   
                }
            }
        }

        private void cmbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //if (cmbItemName.SelectedIndex > -1)
                //{
                if (cmbItemName.SelectedIndex > -1 || cmbItemName.Text.Trim() != "") // New Changes done by Praba on 19Nov for Barcode scanning
                {
                    cmbCategory.Focus();
                }
                //cmbCategory.Focus();
                //txtCost.SelectAll();
                //}
            }
        }

        private void lblLoadPhoto_Click(object sender, EventArgs e)
        {

        }

        private void ItemCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void PriceValue()
        {
            decimal actualprice = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price;
            DataTable dt = ObjItemCardHelper.GetAppliedIncreaseHelper();
            if (dt.Rows.Count > 0)
            {
                bool HasIncrease = Convert.ToBoolean(dt.Rows[0]["HasIncrease"]);
                int IncreaseType = Convert.ToInt32(dt.Rows[0]["IncreaseType"]);
                decimal itemcost = dt.Rows[0]["ItemCost"] == null ? 0 : Convert.ToDecimal(dt.Rows[0]["ItemCost"].ToString());
                decimal fltdiscount = Convert.ToDecimal(dt.Rows[0]["Discount"].ToString());
                if (HasIncrease)
                {
                    if (IncreaseType == 2)
                    {
                        actualprice = actualprice + ((actualprice * fltdiscount) / 100);
                        txtPrice.Text = actualprice.ToString("#########0.000");
                    }
                    else if (IncreaseType == 1)
                    {
                        actualprice = actualprice + ((itemcost * fltdiscount) / 100);
                        txtPrice.Text = actualprice.ToString("#########0.000");
                    }
                }
            }
            else
            {
                txtPrice.Text = actualprice.ToString("#########0.000");
            }
        }


        private bool isFormValuesChanged()
        {
            if(cmbItemType.Text != ObjItemCardHelper.GetItemType(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType)
            || txtBarcodes.Text != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode
            || chkHideItem.Checked != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.IsHide
            || IsLoadItemform != true
            ||  cmbItemName.Text != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Items
            || IsLoadItemform != false
            ||  cmbCategory.SelectedValue.ToString() != Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CategoryId).ToString()
            ||  cmbCompany.SelectedValue.ToString() != (Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CompId)).ToString()
            ||  IsLoadItemform != true
            ||  cmbItemNo.Text != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemNumber.ToString()
            ||  IsLoadItemform != false
            || txtReorder.Text.ToString() != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Reorder.ToString()
            || txtMaxOrder.Text.ToString() != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Maxorder.ToString()
            || txtPackagePcs.Text.ToString() != ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity.ToString()

                )
            {
               return true;
            }

            return false;
            
            
           
            //commented on 07april2014

            //txtPrice.TextChanged -= txtCost_TextChanged;
            //txtCost.TextChanged -= txtCost_TextChanged;

            //txtPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price.ToString("#########0.000");
            PriceValue();
            txtCost.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemCost.ToString("#########0.000");
            //txtPrice.TextChanged += txtCost_TextChanged;
            //txtCost.TextChanged += txtCost_TextChanged;

            txtWholeSale.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice.ToString("#########0.000");
            txtMinimumPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice.ToString("#########0.000");
            cmbItemPlace.SelectedValue = Convert.ToInt32(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemPlaceId);
            CheckExpiry = 1;
            chkExpiry.Checked = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate;
            CheckExpiry = 0;

            txtStock.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.TotalStock.ToString(); //Totalstock is added to display total stocks all package qty
            txtLastPurchases.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase.ToString();
            txtLastCost.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost.ToString("#########0.000");
            //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost==Convert.ToDecimal("0.000"))
            //{ txtAverage.Text = "0.000"; }
            //else if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.StockInHand  > 0)
            //{
            //txtAverage.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost.ToString("############0.000");
            txtAverage.Text = Convert.ToDecimal(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost * (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity != 0 ? ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity : 1)).ToString("############0.000");
            //}
            //else txtAverage.Text = "0.000";


            //  txtAverage.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.AverageCost.ToString("#########0.000");
            txtProfitRate.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ProfitPrice.ToString("#########0.000");

            txtTotalSpoiled.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemTotalSpoiled.ToString();
            //if (GetExpiryDate.Rows.Count > 0)
            //{
            //    cmbExpiryDate.DataSource = GetExpiryDate;
            //    cmbExpiryDate.DisplayMember = "Expiry";
            //    cmbExpiryDate.ValueMember = "Expiry";
            //}
            if (dictExpiryDetails.Count > 0)
            {
                cmbExpiryDate.DataSource = dictExpiryDetails.Select(e => e.ItemExpiry).ToList();
                //  cmbExpiryDate.DisplayMember = "Expiry";
                //cmbExpiryDate.ValueMember = lstExpiryDates[0];
            }
            else
            {

                cmbExpiryDate.DataSource = null;
            }
            if (!string.IsNullOrEmpty(ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ImgPath))
            {


                byte[] b = (byte[])ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Image;

                if (b.Length > 1)
                {
                    MemoryStream stream = new MemoryStream(b, true);
                    Bitmap bmp = new Bitmap(stream);
                    picItem.Image = Image.FromStream(stream);
                }
                else
                {
                    picItem.Image = null;
                    //string Filename;
                    //Filename = Application.StartupPath + "\\Images\\almaqar_logo.png";
                    //Pic_Item.Image = Image.FromFile(Filename);
                }

            }

        }
    }
}

