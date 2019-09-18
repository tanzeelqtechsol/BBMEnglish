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
using ObjectHelper;
using System.Threading;

namespace BumedianBM.ArabicView
{
    public partial class Item_Information : Form,IDisposable
    {

        internal int ItemNo;
        internal string ItemName;
        ItemInformationHelper objHelper;
        public List<PurchaseObjectClass> objList = new List<PurchaseObjectClass>();
        public List<DateTime> objExpiry = new List<DateTime>();
        public Item_Information()
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
            objHelper = new ItemInformationHelper();
          
        }

        private void Item_Information_Load(object sender, EventArgs e)
        {
            this.ClearItemInfo();
            LoadItemInfo();
        }

        public void SetLanguage()
        {
            lblAverage.Text = Additional_Barcode.GetValueByResourceKey("Average");
            lblCategory1.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany1.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblItemCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblItemLastCost.Text = Additional_Barcode.GetValueByResourceKey("LastCost");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNearestExpiry.Text = Additional_Barcode.GetValueByResourceKey("NearestExpiry");
            lblItemPackage.Text = Additional_Barcode.GetValueByResourceKey("Package");
            lblItemPlace.Text = Additional_Barcode.GetValueByResourceKey("ItemPlace");
            lblItemPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            lblItemStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblMinimum.Text = Additional_Barcode.GetValueByResourceKey("Min");
            lblWholeSale.Text = Additional_Barcode.GetValueByResourceKey("WholeSale");

            grpItemInformation.Text = Additional_Barcode.GetValueByResourceKey("ItemInfo");

            this.Text = Additional_Barcode.GetValueByResourceKey("ItemInfo");
        }
        public void LoadItemInfo()
        {
            try
            {
                objHelper.ObjBALClass.ObjPurchase.ItemNo = ItemNo;
                objHelper.ObjBALClass.ObjPurchase.ItemName = ItemName;
                if (objHelper.ObjBALClass.ObjPurchase.ItemName != string.Empty && objHelper.ObjBALClass.ObjPurchase.ItemNo != 0)
                {
                    List<PurchaseObjectClass> objList1 = new List<PurchaseObjectClass>();
                   // objList1 = objHelper.ObjBALClass.GetItemInfor();
                    objList = objHelper.ObjBALClass.GetItemInfor(); //objList1.Select(a => a.ItemPackage).Distinct().ToList();
                    objExpiry = objHelper.ObjBALClass.GetExpiryDates();
                }
                if (objList != null && objList.Count > 0)
                {
                    cmbPackage.SelectedIndexChanged -= new System.EventHandler(cmbPackage_SelectedIndexChanged);
                    cmbPackage.DisplayMember = "ItemPackage";
                    cmbPackage.ValueMember = "BarcodeID";
                    cmbPackage.DataSource = objList.Select(x=>x.ItemPackage).Distinct().ToList();
                    
                    cmbPackage.SelectedIndex = 0;
                    cmbPackage.SelectedIndexChanged += new System.EventHandler(cmbPackage_SelectedIndexChanged);
                    txtStock.Text = objList.Sum(x=>x.ItemTotalStock).ToString();//[0].ItemTotalStock.ToString();
                }
                AssignToControls(objList);
               
            }
     
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message,this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "LoadItemInfo");
            }
        }

        private void AssignToControls(List<PurchaseObjectClass> objList)
        {
            if (objList.Count > 0)
            {
                cmbPackage.SelectedIndexChanged -= new System.EventHandler(cmbPackage_SelectedIndexChanged);
                cmbPackage.Text = objList[0].ItemPackage.ToString();
                cmbPackage.SelectedIndexChanged += new System.EventHandler(cmbPackage_SelectedIndexChanged);
                txtItemName.Text = objList[0].ItemName;
                txtCategory.Text = objList[0].CategoryName;
                txtItemPlace.Text = objList[0].PlaceName;
                txtCompany.Text = objList[0].CompanyName;
                PriceValue(objList[0].ItemPrice, objList[0].CategoryNo, objList[0].CompanyNo, objList[0].ItemType, ItemNo);
                //txtPrice.Text = objList[0].ItemPrice.ToString("0.000");
                txtLastCost.Text = objList[0].ItemLastCost.ToString("0.000");
                txtCost.Text = objList[0].ItemCost.ToString("0.000");
                txtWholesale.Text = objList[0].ItemWholeSalePrice.ToString("0.000");
                txtLastCost.Text = objList[0].ItemLastCost.ToString("0.000");
                txtMinimum.Text = objList[0].ItemMinimumPrice.ToString("0.000");
                //
                //txtAverage.Text = objList[0].AvgCost.ToString("0.000");
                txtAverage.Text = Convert.ToDecimal(objList[0].AvgCost * (objList[0].ItemPackage != 0 ? objList[0].ItemPackage : 1)).ToString("####0.000");
                //
                //txtStock.Text = objList[0].ItemTotalStock.ToString();
                txtStock.Text = (objList.Where(a => a.ItemPackage == Convert.ToInt32(cmbPackage.Text)).ToList()).Sum(s => s.ItemTotalStock).ToString();//added on 23Aug2014
                cmbNearestExpiry.DataSource = objExpiry != null ? (objExpiry.Count > 0 ? objExpiry : null) : null;
            }
        }

        public void ClearItemInfo()
        {
            txtItemName.Text = txtCategory.Text = txtCompany.Text = txtPrice.Text = "";
            txtWholesale.Text = txtMinimum.Text = txtCost.Text = txtAverage.Text = "";
            txtLastCost.Text = txtStock.Text =  cmbNearestExpiry.Text = "";
            txtItemPlace.Text = "";
            cmbPackage.SelectedIndex = -1;
        }

        private void grpItemInformation_Enter(object sender, EventArgs e)
        {

        }

        private void Item_Information_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode==Keys.F11)
                this.Close();
        }

        #region
        private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (objList != null && objList.Count > 0)
                {
                    if (cmbPackage.SelectedIndex != -1)
                    {
                        List<PurchaseObjectClass> objpackagelist = new List<PurchaseObjectClass>();
                        //objpackagelist = objList.FindAll(x => x.ItemPackage == Convert.ToInt32(cmbPackage.Text.ToString()));
                        objpackagelist = objList.Where(x => x.ItemPackage == Convert.ToInt32(cmbPackage.Text.ToString())).ToList();
                        AssignToControls(objpackagelist);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "ItemInformation", "cmbPackage_SelectedIndexChanged");
            }
            
        }
        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in grpItemInformation.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox || cti is TabControl || cti is TabPage)
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

        private void PriceValue(decimal Price, int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            decimal actualprice = Price;
            DataTable dt = objHelper.ObjBALClass.GetAppliedIncreaseHelper(CategoryID,CompanyID,ItemType,ItemNo);
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
                        txtPrice.Text = actualprice.ToString("0.000");
                    }
                    else if (IncreaseType == 1)
                    {
                        actualprice = actualprice + ((itemcost * fltdiscount) / 100);
                        txtPrice.Text = actualprice.ToString("0.000");
                    }
                }
            }
            else
            {
                txtPrice.Text = actualprice.ToString("0.000");
            }
        }
        #endregion
    }
    }
