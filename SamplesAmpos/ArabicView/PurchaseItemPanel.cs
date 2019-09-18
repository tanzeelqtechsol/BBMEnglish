using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using SergeUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class PurchaseItemPanel : Form
    {
        #region Variables
        PurchaseItemPanelHelper ObjHelper;
        DataSet dataforItemPlace = new DataSet();
        DataTable dtAllItems = new DataTable();
        private DateTime? LocalDatime = DateTime.Now;
        List<ObjectHelper.PurchaseItemPanelObectClass> dictExpiryDetails = new List<ObjectHelper.PurchaseItemPanelObectClass>();
        Boolean IsLoadItemform;
        // 
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public bool IsSaved = false;
        public bool IsExpiry { get; set; }
        public DateTime ExpiryDate { get; set; }
        //

        #endregion

        public PurchaseItemPanel()
        {
            InitializeComponent();
            SetLanguage();
            ObjHelper = new PurchaseItemPanelHelper();
            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
            dtpExpiry.Format = DateTimePickerFormat.Custom;
            dtpExpiry.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpExpiry.Value = LocalDatime.Value;
            //***********Date Format Check*****************************************************//
        }

        #region Method
        public void SetLanguage()
        {
            lblBarcode.Text = Additional_Barcode.GetValueByResourceKey(lblBarcode.Tag.ToString());
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey(lblCategory.Tag.ToString());
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey(lblCompany.Tag.ToString());
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey(lblItemName.Tag.ToString());
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey(lblItemNo.Tag.ToString());
            lblItemPrice.Text = Additional_Barcode.GetValueByResourceKey(lblItemPrice.Tag.ToString());
            lblPackagePCs.Text = Additional_Barcode.GetValueByResourceKey(lblPackagePCs.Tag.ToString());
            chkExpiry.Text = Additional_Barcode.GetValueByResourceKey(chkExpiry.Tag.ToString());
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey("ExpiryDate");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey(btnSave.Tag.ToString());
            btnClose.Text = Additional_Barcode.GetValueByResourceKey(btnClose.Tag.ToString());
            this.Text= Additional_Barcode.GetValueByResourceKey("ItemPanel"); 
        }

        private void HideControls()
        {
            cmbItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            lblItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            lblPackagePCs.Visible = txtPackagePcs.Visible = GeneralOptionSetting.FlagHidePackageQuantity != "Y" ? true : false;
            chkExpiry.Visible = (GeneralOptionSetting.FlagPurchase_HideExpiryFiled != "Y" && GeneralOptionSetting.FlagSale_HideExpiryFiled != "Y");
            dtpExpiry.Visible = lblExpiry.Visible = (GeneralOptionSetting.FlagPurchase_DontUseExpiry == "Y") ? false : true;
        }

        public void AssignToControls()
        {
            dataforItemPlace = ObjHelper.GetAllItems();
            dtAllItems = dataforItemPlace.Tables[0];
            //dtAllPlace = dataforItemPlace.Tables[1];
            if (dtAllItems.Rows.Count > 0 && dtAllItems != null)
            {
                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemId";
                DataView dvfilter = new DataView(dtAllItems);
                dvfilter.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dvfilter.ToTable();
                cmbItemNo.SelectedIndex = -1;
                cmbItemName.BindingContext = new BindingContext();
                cmbItemName.DisplayMember = "Items";
                cmbItemName.ValueMember = "ItemId";
                cmbItemName.DataSource = dtAllItems;
                cmbItemName.SelectedIndex = -1;
            }
            else
            {
                //cmbItemNo.DataSource = null;
                cmbItemName.DataSource = null;
            }
            if (GeneralObjectClass.CategoryList.Count > 0 && GeneralObjectClass.CompanyList.Count > 0)
            {
                lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
                lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }

            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = ObjectHelper.GeneralObjectClass.CategoryList;

            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCompany.DataSource = ObjectHelper.GeneralObjectClass.CompanyList;
        }

        private Boolean CheckNumbericOnly(KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)ConsoleKey.Backspace) && (e.KeyChar != (char)ConsoleKey.Delete))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AssignFromControls()
        {
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemName = cmbItemName.Text.Trim();
            ObjHelper.ObjBALClass.Objitemcardobjectclass.Barcode = GeneralFunction.PurchaseBarcode;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.CategoryID = cmbCategory.SelectedIndex == -1 ? 1001 : Convert.ToInt32(cmbCategory.SelectedValue);
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemType = 1;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemPlaceId = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.CompanyID = cmbCompany.SelectedIndex == -1 ? 1001 : Convert.ToInt32(cmbCompany.SelectedValue);
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemCost = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemLastCost = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.PackageQuantity = txtPackagePcs.Text == string.Empty ? 0 : Convert.ToInt32(txtPackagePcs.Text);
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ExpiryDate = chkExpiry.Checked;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.Reorder = 1;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.WholeSalePrice = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.Price = txtPrice.Text == string.Empty ? 0 : Convert.ToDecimal(txtPrice.Text);
            ObjHelper.ObjBALClass.Objitemcardobjectclass.Maxorder = 100;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.MinPrice = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.AverageCost = 0;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ImgPath = "";
            ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemNumber = cmbItemNo.Text.Trim();
            ObjHelper.ObjBALClass.Objitemcardobjectclass.UnitNameID = 0;
            {
                byte[] itemimg = new byte[1];
                itemimg[0] = 0;
                ObjHelper.ObjBALClass.Objitemcardobjectclass.Image = itemimg;
            }
            ObjHelper.ObjBALClass.Objitemcardobjectclass.IsHide = false;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.Status = 1;
            ObjHelper.ObjBALClass.Objitemcardobjectclass.CreatedBy = ObjHelper.ObjBALClass.Objitemcardobjectclass.ModifiedBy = GeneralFunction.UserId;
        }

        private void AssignFromObjectToControls()
        {
            txtBarcodes.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.Barcode == "" ? txtBarcodes.Text : ObjHelper.ObjBALClass.Objitemcardobjectclass.Barcode;
            IsLoadItemform = true;
            cmbItemName.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemName;
            IsLoadItemform = false;
            cmbCategory.SelectedValue = Convert.ToInt32(ObjHelper.ObjBALClass.Objitemcardobjectclass.CategoryID);
            cmbCompany.SelectedValue = Convert.ToInt32(ObjHelper.ObjBALClass.Objitemcardobjectclass.CompanyID);
            IsLoadItemform = true;
            cmbItemNo.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemNumber.ToString();
            IsLoadItemform = false;
            txtPackagePcs.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.PackageQuantity.ToString();
            PriceValue();
            txtPurchasePrice.Text = txtPrice.Text;
            txtCost.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemCost.ToString("#########0.000");
            //CheckExpiry = 1;
            chkExpiry.Checked = ObjHelper.ObjBALClass.Objitemcardobjectclass.ExpiryDate;
            //CheckExpiry = 0;
            txtStock.Text = ObjHelper.ObjBALClass.Objitemcardobjectclass.TotalStock.ToString(); //Totalstock is added to display total stocks all package qty

        }

        private void PriceValue()
        {
            decimal actualprice = ObjHelper.ObjBALClass.Objitemcardobjectclass.Price;
            DataTable dt = ObjHelper.GetAppliedIncreaseHelper();
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
        #endregion

        private void PurchaseItemPanel_Load(object sender, EventArgs e)
        {
            cmbItemName.MatchingMethod = StringMatchingMethod.UseRegexs;
            IsLoadItemform = true;
            AssignToControls();
            HideControls();
            txtBarcodes.Text = GeneralFunction.PurchaseBarcode;
            IsLoadItemform = false;
            cmbItemName.Select();
            cmbItemName.Focus();
        }

        private void txtPackagePcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

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

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46) != true)
                e.Handled = true;

            if (e.KeyChar == 46 && (((TextBox)sender).Text.Contains('.')))
                e.Handled = true;
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {

                TextBox tx = (TextBox)sender;
                if (tx.Text != string.Empty && tx.Text != ".")
                {
                    tx.Text = Convert.ToDecimal(tx.Text).ToString("0.000");
                }
                else
                {
                    tx.Text = "0.000";
                }

                // Update Purchase Invoice Price
                txtPurchasePrice.Text = tx.Text;
                if(!chkExpiry.Visible)
                {
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.ErrorMessages(ex.Message, this.Tag.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter && cmbItemName.Text.Trim() != "")
                {
                    string name = ((MaskedTextBox)sender).Name;
                    switch (name)
                    {
                        case "txtCost":
                            if (txtCost.Text == ".")
                                return;
                            if (txtCost.Text != string.Empty && Decimal.Parse(txtCost.Text.ToString()) != 0 && Decimal.Parse(txtCost.Text.ToString()) > Convert.ToDecimal(txtPrice.Text.ToString()))
                            {
                                if (GeneralFunction.Question("CostGreaterthanSalePrice", "PurchaseInvoice") == DialogResult.Yes)
                                {
                                    if (GeneralOptionSetting.FlagTabToPrice == "Y")
                                    {
                                        txtPurchasePrice.Focus();
                                        txtPurchasePrice.SelectAll();
                                    }
                                    else
                                    {
                                        txtQuantity.Focus();
                                        txtQuantity.SelectAll();
                                    }
                                }
                                else
                                {
                                    txtCost.Focus();
                                    txtCost.SelectAll();
                                }
                            }
                            else
                            {
                                if (txtCost.Text.Trim() == string.Empty)
                                {
                                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("ItemCostGreaterthanZero"), "Purchase Invoice");
                                }
                                if (GeneralOptionSetting.FlagTabToPrice == "Y")
                                {
                                    txtPurchasePrice.Focus();
                                    txtPurchasePrice.SelectAll();
                                }
                                else
                                {
                                    txtQuantity.Focus();
                                    txtQuantity.SelectAll();
                                }
                            }
                            break;
                        case "txtPurchasePrice":
                            if (cmbItemName.Text.Trim() != "")
                            {
                                txtQuantity.Focus();
                                txtQuantity.SelectAll();
                            }
                            else
                                cmbItemName.Focus();
                            break;
                    }
                }
                else if (CheckNumbericOnly(e))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 46 && (((MaskedTextBox)sender).Text.Contains('.')))
                    e.Handled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtCost_Leave(object sender, EventArgs e)
        {
            // last code
            #region
            try
            {
                string name = ((MaskedTextBox)sender).Name;
                if (((MaskedTextBox)sender).Text == ".")
                    return;
                Decimal a = ((MaskedTextBox)sender).Text == string.Empty ? 0 : Convert.ToDecimal(((MaskedTextBox)sender).Text);
                switch (name)
                {
                    case "txtCost":
                        if (txtCost.Text != string.Empty && txtCost.Text != null && txtCost.Text.Length <= 9)
                        {
                            a = decimal.Parse(txtCost.Text);
                            txtCost.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                        }
                        else
                            txtCost.Text = "0.000";
                        break;
                    case "txtPurchasePrice":
                        if (txtPurchasePrice.Text != string.Empty && txtPurchasePrice.Text != null && txtPurchasePrice.Text.Length <= 9)
                            txtPurchasePrice.Text = (Math.Truncate(a * 1000m) / 1000m).ToString("#####0.000");
                        else
                            txtPrice.Text = "0.000";
                        break;
                    case "txtQuantity":
                        if (txtQuantity.Text == string.Empty && txtQuantity.Text != null && txtQuantity.Text.Length <= 8)
                            txtQuantity.Text = "0";
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            #endregion
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (cmbItemName.Text.Trim() != "")
                    {
                        if (dtpExpiry.Visible == true)
                        {
                            dtpExpiry.Focus();
                        }
                        else
                        {
                            //this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                            e.Handled = false;
                            btnSave.Focus();
                            //txtItemName.Focus();
                        }
                    }
                    else
                    {
                        cmbItemName.Focus();

                    }

                }
                else if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != '\u0008') && (e.KeyChar != '\u007f') || (txtQuantity.Text.Length > 7))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", "PurchaseInvoice");
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbItemName.Text.Trim() != "")
            {
                    int PackageQty = string.IsNullOrEmpty(txtPackagePcs.Text) ? 1 : Convert.ToInt32(txtPackagePcs.Text);
                    if (PackageQty > 1)
                    {
                        txtStock.Text = ((int.Parse(txtQuantity.Text != string.Empty ? txtQuantity.Text : "0")) + (0 / (PackageQty))).ToString();
                    }
                    else
                    {
                        txtStock.Text = Convert.ToString(int.Parse((txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0") + int.Parse((0).ToString()));
                    }
            }
        }

        private void dtpExpiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    //this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                }
                else if (CheckNumbericOnly(e) == true)
                {
                    e.Handled = true;
                    dtpExpiry.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AssignFromControls();
            // Save Item Info
            ObjHelper.SaveItemCardDetail();

            //
            ItemID = ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemID;
            Price = Convert.ToDecimal(txtPurchasePrice.Text);
            Cost = Convert.ToDecimal(txtCost.Text);
            ItemName = cmbItemName.Text.Trim();
            Quantity = Convert.ToInt32(txtQuantity.Text);
            IsExpiry = chkExpiry.Checked;
            ExpiryDate = dtpExpiry.Value;
            //

            if (!ObjHelper.ItemNotSave)
            {
                IsSaved = true;
                this.Close();
            }
            else
            {
                ObjHelper.ItemNotSave = false;
                cmbItemName.Focus();
            }
            
        }

        private void chkExpiry_Leave(object sender, EventArgs e)
        {
            txtCost.Focus();
            txtCost.SelectAll();
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbItemName.Text.Trim() != "")
                {
                    if (cmbItemNo.Visible)
                        cmbItemNo.Focus();
                    else
                        cmbCategory.Focus();
                }
            }
        }

        private void txtItemNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbCategory.Focus();
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbCategory_KeyDown");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PurchaseItemPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, e);
            }
        }

        private void cmbItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbItemName.Text.Trim() != "") 
                {
                    if (cmbItemNo.Visible)
                        cmbItemNo.Focus();
                    else
                        cmbCategory.Focus();
                }
            }
        }

        private void cmbItemName_DrawItem(object sender, DrawItemEventArgs e)
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

        private void cmbItemNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                cmbCategory.Focus();
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.ObjBALClass.Objitemcardobjectclass.ItemID = Convert.ToInt32(cmbItemName.SelectedValue);

                if (IsLoadItemform != true && cmbItemName.SelectedIndex != -1)
                {
                    if (ObjHelper.GetItemDetails())
                    {
                        //dictExpiryDetails = ObjItemCardHelper.GetExpiryItemDetails();
                        //CheckExpiry = 1;
                        //ischeck = true;
                        AssignFromObjectToControls();
                        //ischeck = false;
                        //CheckExpiry = 0;
                        //cmbCategory.Focus();
                    }

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemName_SelectedIndexChanged");
            }
        }
    }
}
