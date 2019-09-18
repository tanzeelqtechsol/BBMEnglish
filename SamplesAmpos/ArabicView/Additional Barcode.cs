using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using BumedianBM.ViewHelper;
using System.Threading;
using CommonHelper;
using ObjectHelper;
using DataBaseHelper;

namespace BumedianBM.ArabicView
{
    public partial class Additional_Barcode : Form, IDisposable
    {
        #region variable
        ItemCardHelper ObjItemCardHelper;
        public int RemoveBarcode;
        bool IsFormLoad;
        bool Validation = false;
        List<ObjectHelper.ItemCardObjectClass> lstunittypes = new List<ObjectHelper.ItemCardObjectClass>();
        private string lastfocusedvalue = "";
        private Control lastFocusedControl = null;
        private string ScanValue = string.Empty;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private bool ScanTimingCheck = false;
        int ScannerCount, DefaultPackage;
        decimal ItemPrice, MinimumPrice, WholePrice = 0;
        private int KeyboardmaxCount = 0;
        bool ScanningBarcode = false;// once sccaning the item set the packae qty as 1 
        bool GridEvent = false;

        #endregion
        #region Constructor
        public Additional_Barcode(ItemCardHelper itemcardhelper)
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
            ObjItemCardHelper = itemcardhelper;
        }
        #endregion
        #region LoadEvent
        private void Additional_Barcode_Load(object sender, EventArgs e)
        {

            // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(this.Tag);

            try
            {
                IsFormLoad = true;
                LoadBarCodeDetails();
                // cmb_Types.SelectedIndex = -1;
                cmb_UnitName.SelectedIndex = -1;
                //  cmb_UnitQuantity.SelectedIndex = -1;

                IsFormLoad = false;
                txtBarcodes.Focus();
                txtBarcodes.Select();
                //cmb_UnitName.SelectAll();
                //cmb_UnitName.Focus();
                ControlsHideOption();///iuncluded on 26 may 2014 for to disable the package qty for secohand item
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                DefaultPackage = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity;
                ItemPrice = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price;
                WholePrice = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice;
                MinimumPrice = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", " Additional_Barcode_Load");
            }

        }

        #endregion

        #region Method
        private void ControlsHideOption()
        {
            if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 2 || ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 3 || ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 4)
            {

                cmb_UnitName.SelectedIndex = -1;
                cmb_UnitName.Enabled = false;
                lbl_UnitName.Enabled = false;
                cmb_UnitQuantity.SelectedIndex = -1;
                cmb_UnitQuantity.Enabled = false;
                lbl_UnitQuantity.Enabled = false;
            }
            else
            {
                cmb_UnitName.SelectedIndex = -1;
                cmb_UnitName.Enabled = true;
                lbl_UnitName.Enabled = true;
                cmb_UnitQuantity.SelectedIndex = -1;
                cmb_UnitQuantity.Enabled = true;
                lbl_UnitQuantity.Enabled = true;

            }


        }
        public void SetLanguage()
        {
            lblBarcode.Text = GetValueByResourceKey(lblBarcode.Tag.ToString());
            Lbl_Barcod.Text = GetValueByResourceKey(Lbl_Barcod.Tag.ToString());
            btnBarcode.Text = GetValueByResourceKey(btnBarcode.Tag.ToString());
            btnClose.Text = GetValueByResourceKey(btnClose.Tag.ToString());
            btnDelete.Text = GetValueByResourceKey(btnDelete.Tag.ToString());
            btnSave.Text = GetValueByResourceKey(btnSave.Tag.ToString());
            this.Text = GetValueByResourceKey(this.Tag.ToString());
            //cmb_Types.Items.Clear();
            //cmb_Types.Items.Add(GetValueByResourceKey("Cartoon"));
            //cmb_Types.Items.Add(GetValueByResourceKey("Piece"));
            //cmb_Types.Items.Add(GetValueByResourceKey("Box"));
            lbl_Cost.Text = GetValueByResourceKey(lbl_Cost.Tag.ToString());
            lbl_PackageQty.Text = GetValueByResourceKey(lbl_PackageQty.Tag.ToString());
            lbl_Types.Text = GetValueByResourceKey(lbl_Types.Tag.ToString());
            lbl_UnitTypes.Text = GetValueByResourceKey(lbl_UnitTypes.Tag.ToString());
            lbl_UnitName.Text = GetValueByResourceKey(lbl_UnitName.Tag.ToString());

            lbl_PriceField.Text = GetValueByResourceKey(lbl_PriceField.Tag.ToString());
            lbl_UnitQuantity.Text = GetValueByResourceKey(lbl_UnitQuantity.Tag.ToString());
            btn_Clear.Text = GetValueByResourceKey(btn_Clear.Tag.ToString());
            lbl_MinPrice.Text = GetValueByResourceKey(lbl_MinPrice.Tag.ToString());
            lbl_WholeSale.Text = GetValueByResourceKey(lbl_WholeSale.Tag.ToString());

        }

        public static string GetValueByResourceKey(string Key)
        {
            ResourceManager lResoruce;
            lResoruce = new ResourceManager("BumedianBM.ResourceFile.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            return lResoruce.GetString(Key.Replace(" ", ""));
        }
        private void LoadBarCodeDetails()
        {

            List<ObjectHelper.ItemCardObjectClass> lstBarcodeDetails = ObjItemCardHelper.GetBarCodeDetails();
            List<ObjectHelper.ItemCardObjectClass> ListUnitName = UnitNameOfItem();
            //Commented on 17 april 2014 to remove the unit type functionality
            // cmb_Types.DisplayMember = "Name";
            //cmb_Types.ValueMember = "ID";
            // lstunittypes = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 11).ToList(); ;
            //cmb_Types.DataSource = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 11).ToList();
            cmb_UnitQuantity.DisplayMember = "UnitQuantity";
            cmb_UnitQuantity.ValueMember = "ID";
            cmb_UnitQuantity.DataSource = ListUnitName.Where(i => i.GeneralID == 10).ToList(); //ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 10).ToList();
            cmb_UnitQuantity.SelectedIndex = -1;
            cmb_UnitName.DisplayMember = "Name";
            cmb_UnitName.ValueMember = "ID";
            //cmb_UnitName.DataSource  = new BindingSource ();
            cmb_UnitName.DataSource = ListUnitName.Where(i => i.GeneralID == 10).ToList();//ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 10).ToList(); // ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 10).ToList();
            cmb_UnitName.SelectedIndex = -1;


            // var ab = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => { i.Name = i.Name.Contains('-') ? ObjectHelper.GeneralObjectClass.DefaultUnitName + "(" + i.Name.Substring(i.Name.IndexOf('B') + 1, i.Name.IndexOf("-") + 3) + ")" : i.Name; return i; }).ToList();
            // saleItem.saleMenuLJ.Select(a => { a.SeatName = a.SeatName.Contains('(') && a.SeatName.Contains(')') ? saleItem.mSaleList.TableName + "(" + a.SeatName.Substring(a.SeatName.IndexOf('(') + 1, a.SeatName.IndexOf(')') - a.SeatName.IndexOf('(') - 1) + ")" : saleItem.mSaleList.TableName + "(" + a.SeatName + ")"; a.ModifiedBy = GeneralFunction.UserId; a.SaleID = saleInfo.SaleID; a.ModifiedDate = BenseronEntityModels.GetLocalDateTime(); a.UploadTime = BenseronEntityModels.GetLocalDateTime(); return a; }).ToList();
            dgvBarcode.AutoGenerateColumns = false;
            if (lstBarcodeDetails.Count > 0)
            { dgvBarcode.DataSource = lstBarcodeDetails.Where(i => i.Barcode != string.Empty).ToList(); }
            else { dgvBarcode.DataSource = null; }

        }

        public List<ItemCardObjectClass> UnitNameOfItem()
        {
            try
            {
                GeneralObjectClass.DefaultUnitName.Clear();
                var result = SQLHelper.Instance.GetReader("Usp_GetCommonUnitName", null);

                while (result.Read())
                {
                    GeneralObjectClass.DefaultUnitName.Add(new ItemCardObjectClass
                    {
                        GeneralID = Convert.ToInt32(result[0]),
                        ID = Convert.ToInt32(result[1]),
                        Name = result[2].ToString(),
                        UnitQuantity = result[3].ToString(),

                    });
                }

                return GeneralObjectClass.DefaultUnitName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        private void LoadUnitNameAndQuantityDetails()
        {

            List<ObjectHelper.ItemCardObjectClass> lstBarcodeDetails = ObjItemCardHelper.GetBarCodeDetails();

            //Commented on 17 april 2014 to remove the unit type functionality
            // cmb_Types.DisplayMember = "Name";
            //cmb_Types.ValueMember = "ID";
            // lstunittypes = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 11).ToList(); ;
            //cmb_Types.DataSource = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 11).ToList();
            cmb_UnitQuantity.DisplayMember = "UnitQuantity";
            cmb_UnitQuantity.ValueMember = "ID";
            cmb_UnitQuantity.DataSource = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 10).ToList();
            cmb_UnitQuantity.SelectedIndex = -1;
            cmb_UnitName.DisplayMember = "Name";
            cmb_UnitName.ValueMember = "ID";
            //cmb_UnitName.DataSource  = new BindingSource ();
            cmb_UnitName.DataSource = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 10).ToList();
            cmb_UnitName.SelectedIndex = -1;


            // var ab = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => { i.Name = i.Name.Contains('-') ? ObjectHelper.GeneralObjectClass.DefaultUnitName + "(" + i.Name.Substring(i.Name.IndexOf('B') + 1, i.Name.IndexOf("-") + 3) + ")" : i.Name; return i; }).ToList();
            // saleItem.saleMenuLJ.Select(a => { a.SeatName = a.SeatName.Contains('(') && a.SeatName.Contains(')') ? saleItem.mSaleList.TableName + "(" + a.SeatName.Substring(a.SeatName.IndexOf('(') + 1, a.SeatName.IndexOf(')') - a.SeatName.IndexOf('(') - 1) + ")" : saleItem.mSaleList.TableName + "(" + a.SeatName + ")"; a.ModifiedBy = GeneralFunction.UserId; a.SaleID = saleInfo.SaleID; a.ModifiedDate = BenseronEntityModels.GetLocalDateTime(); a.UploadTime = BenseronEntityModels.GetLocalDateTime(); return a; }).ToList();
            dgvBarcode.AutoGenerateColumns = false;
            if (lstBarcodeDetails.Count > 0)
            { dgvBarcode.DataSource = lstBarcodeDetails.Where(i => i.Barcode != string.Empty).ToList(); }
            else { dgvBarcode.DataSource = null; }

        }

        private void AssignFromControls()
        {
            //List<String > unitypes = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.GeneralID == 11).ToList(); 

            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(this.Tag);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode = txtBarcodes.Text;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.CreatedBy = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ModifiedBy = CommonHelper.GeneralFunction.UserId;
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Status = 1;
            if (ScanningBarcode == true)
            {
                cmb_UnitName.SelectedIndex = -1;
                cmb_UnitQuantity.SelectedIndex = -1;
                if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 2) { txt_ItemPrice.Text = "0.000"; }
            }
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = cmb_UnitName.SelectedIndex == -1 ? 0 : ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitName.SelectedIndex].ID;
            // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID = cmb_Types.SelectedIndex == -1 ? 0 : lstunittypes[cmb_Types.SelectedIndex ].ID;
            //ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypes = cmb_Types.Text.ToString();
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price = txt_ItemPrice.Text == string.Empty || txt_ItemPrice.Text.Contains("0.00") ? cmb_UnitQuantity.SelectedIndex == -1 ? ItemPrice : Convert.ToDecimal(txt_ItemPrice.Text) : Convert.ToDecimal(txt_ItemPrice.Text);
            //  ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = cmb_UnitQuantity.Text;
            // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = cmb_UnitQuantity.Text == string.Empty ? 1 : Convert.ToInt32(cmb_UnitQuantity.Text);this line commended By Meena.R on 11Nov2014
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = cmb_UnitQuantity.Text == string.Empty ? DefaultPackage : Convert.ToInt32(cmb_UnitQuantity.Text);//added to added default Package qty
            if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemType == 2)
            {
               // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = 0; // Comment by T on 25-April-2019
            }
            // QuantityCalculation();
            ////// cmb_UnitName_SelectedIndexChanged(cmb_UnitName, new EventArgs()); commented on 26 may 2014 unnesccesarily call teh seletec index change event 
            //if (ScanningBarcode == true)
            //{
            //   // ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = 1;
            //    ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = string.Empty;
            //}
            if (GridEvent == false)///added on 14 may 2014
            { ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId = 0; }

            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = txt_MinPrice.Text == string.Empty || txt_MinPrice.Text.Contains("0.00") ? cmb_UnitQuantity.SelectedIndex == -1 ? MinimumPrice : Convert.ToDecimal(txt_MinPrice.Text): Convert.ToDecimal(txt_MinPrice.Text);
            ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = txt_WholeSale.Text == string.Empty || txt_WholeSale.Text.Contains("0.00") ?cmb_UnitQuantity.SelectedIndex==-1?WholePrice:Convert.ToDecimal(txt_WholeSale.Text) : Convert.ToDecimal(txt_WholeSale.Text);


        }
        private void QuantityCalculation()
        {
            //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 1 && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID>0)
            if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID > 0)
            {
                string unitname = cmb_UnitName.Text.ToString();
                var getnumber = (from t in unitname where char.IsDigit(t) select t).ToArray();


                // string splitqty = unitname.Substring((unitname.IndexOf("(")) + 1,i );
                string splitqty = new string(getnumber);
                int unitqty = Convert.ToInt32(splitqty);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? 1 : (Convert.ToInt32(ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity) * unitqty);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? "1" : (Convert.ToInt32(ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity) * unitqty).ToString();

            }
            //else if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 3 && cmb_UnitQuantity.SelectedIndex!=-1)
            else if (cmb_UnitQuantity.SelectedIndex != -1)
            {
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? 0 : Convert.ToInt32(ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? "0" : ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity.ToString();

            }
            //else if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 2) 
            else
            {
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? 1 : Convert.ToInt32(ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = cmb_UnitQuantity.SelectedIndex == -1 ? "1" : ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].UnitQuantity.ToString();
            }
            //string name = cmb_Types.Text;
            //if ((name == "Piece") || (name == "قطعة"))
            //{
            //    ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = 1;
            //    ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = "1";

            //}
            //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 0 && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID == 0)
            //{
            //    ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID = 2;

            //}
        }


        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox || cti is TabControl || cti is TabPage)
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }
        private void AssignToControls()
        {
            txtBarcodes.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode.ToString();
            txt_ItemPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price.ToString("#########.000");
            //txt_PackageQty.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity
            //cmb_Types.Text   = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypes;
            //cmb_UnitName.Text =  ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitName;
            // cmb_Types.SelectedIndex = ObjectHelper.GeneralObjectClass.DefaultUnitName.FindIndex(i => i.ID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID);
            // cmb_Types.SelectedIndex = lstunittypes.FindIndex(i => i.ID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID);
            cmb_UnitName.SelectedIndex = ObjectHelper.GeneralObjectClass.DefaultUnitName.FindIndex(i => i.ID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID);
            //  cmb_UnitQuantity.SelectedIndex = ObjectHelper.GeneralObjectClass.DefaultUnitName.FindIndex(i => i.ID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID);
            //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID == 0)
            //{
            //    cmb_UnitQuantity.SelectedIndex = -1;
            //    cmb_UnitQuantity.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity.ToString();
            //}
            //else
            //{
            //    cmb_UnitQuantity.SelectedIndex = lstunittypes.FindIndex(i => i.ID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID);
            //}
            txt_MinPrice.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice.ToString("##########.000");
            txt_WholeSale.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice.ToString("##########.000");

        }
        #endregion
        #region KeyEvent

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBarcodes.Text))
                {
                    AssignFromControls();

                    if (txtBarcodes.Text != "")
                    {
                        var IsAlreadyExist = ObjItemCardHelper.CheckBarcode(txtBarcodes.Text);
                        if (IsAlreadyExist && ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId == 0)
                        {
                            CommonHelper.GeneralFunction.Information(Constants.ITEMBARCODE_DUP, ActionType.Save.ToString());
                            //MessageBox.Show("The barcode already exists please generate new barcode");
                            txtBarcodes.Text = "";
                            return;
                        }
                    }
                    if (ObjItemCardHelper.SaveAdditionalBarcode())
                    {
                        //////////////////// if(dgvBarcode.Rows.Count!=0 && dgvBarcode.DataSource!=null )
                        //////////////////// {
                        ////////////////////// if (ItemCard.ItemCardPackageQty == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldPackageQuantity )//|| ItemCard.ItemCardPrice == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldItemPrice  )
                        ////////////////////     if (ItemCard.ItemCardBarcode == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode)
                        ////////////////////     {
                        ////////////////////         if (ScanningBarcode != true && ItemCard.ItemCardBarcode == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode)
                        ////////////////////         {
                        ////////////////////             ItemCard.ItemCardBarcode = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                        ////////////////////         }
                        ////////////////////         ItemCard.ItemCardPackageQty = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity;
                        ////////////////////         ItemCard.ItemCardPrice = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price;
                        ////////////////////     }

                        //////////////////// }
                        LoadBarCodeDetails();

                        ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = 0;

                        ClearTextField();
                        GridEvent = false;




                    }
                }
                else
                {

                    GeneralFunction.Information("BarcodeShouldNotBeEmpty", CommonHelper.ActionType.Information.ToString());
                    txtBarcodes.Focus();
                    txtBarcodes.SelectAll();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", " btnSave_Click");
            }


        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                //   ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = txtBarcodes.Text.Trim();


                ObjItemCardHelper.GenerateBarCode();
                //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode == ItemCard.ItemCardBarcode && dgvBarcode.DataSource !=null && dgvBarcode.Rows.Count!=0)
                //{
                //    ItemCard.ItemCardBarcode = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                //}
                txtBarcodes.Text = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                txtBarcodes.Focus();
                txtBarcodes.Select();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", " btnBarcode_Click");


            }
        }

        private void dgvBarcode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GridEvent = true;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId = Convert.ToInt32(dgvBarcode.SelectedRows[0].Cells["BarcodeID"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(dgvBarcode.SelectedRows[0].Cells["ItemID"].Value);
                ///Commented on 20/03/2014
                //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode == dgvBarcode.SelectedRows[0].Cells["Barcode"].Value.ToString())
                //{
                //    RemoveBarcode = string.Empty;
                //}
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode = dgvBarcode.SelectedRows[0].Cells["Barcode"].Value.ToString();
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = Convert.ToInt32(dgvBarcode.SelectedRows[0].Cells["PackageQuantity"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Price = Convert.ToDecimal(dgvBarcode.SelectedRows[0].Cells["Price"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID = Convert.ToInt32(dgvBarcode.SelectedRows[0].Cells["UnitTypesID"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = Convert.ToInt32(dgvBarcode.SelectedRows[0].Cells["UnitNameID"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitName = dgvBarcode.SelectedRows[0].Cells["UnitName"].Value.ToString();
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitTypes = dgvBarcode.SelectedRows[0].Cells["UnitTypes"].Value.ToString();
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.UnitQuantity = dgvBarcode.SelectedRows[0].Cells["PackageQuantity"].Value.ToString();
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = Convert.ToDecimal(dgvBarcode.SelectedRows[0].Cells["WholeSalePrice"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = Convert.ToDecimal(dgvBarcode.SelectedRows[0].Cells["MinPrice"].Value);
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ItemCost = Convert.ToDecimal(dgvBarcode.SelectedRows[0].Cells["ItemCost"].Value);
                AssignToControls();






            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", "GridViewCell_Click");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Status = 0;
                ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.ModifiedBy = CommonHelper.GeneralFunction.UserId;
                if (ObjItemCardHelper.DeleteBarcodeDetails())
                {
                    //if (ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode == ItemCard.ItemCardBarcode)
                    //{
                    //    ItemCard.ItemCardBarcode = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.Barcode;
                    //}
                    if (ItemCard.ItemCardBarcodeID == ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId)
                    {
                        RemoveBarcode = ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId;
                    }
                    LoadBarCodeDetails();
                    txtBarcodes.Text = string.Empty;

                    ClearTextField();
                    GridEvent = false;


                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");

                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", "btnDelete_Click");
            }

        }


        #endregion

        private void cmb_Types_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && cmb_Types.SelectedIndex != -1)
                {
                    if (lstunittypes[cmb_Types.SelectedIndex].ID == 2)
                    {
                        //if ((name == "Piece") || (name == "قطعة"))
                        //{
                        cmb_UnitQuantity.SelectedIndex = -1;
                        cmb_UnitName.SelectedIndex = -1;
                        cmb_UnitName.Enabled = false;
                        cmb_UnitQuantity.Enabled = false;
                        //}
                        //else
                        //{
                        //    cmb_UnitName.Enabled = true;
                        //    cmb_UnitQuantity.Enabled = true;
                        //}
                    }
                    else if (lstunittypes[cmb_Types.SelectedIndex].ID == 3)
                    {
                        cmb_UnitName.SelectedIndex = -1;
                        cmb_UnitQuantity.Enabled = true;
                        cmb_UnitName.Enabled = false;

                    }
                    else
                    {
                        cmb_UnitQuantity.Enabled = true;
                        cmb_UnitName.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");

                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", "cmb_Types_SelectedIndexChanged");
            }
        }

        private void cmb_UnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && Validation == false && cmb_UnitName.SelectedIndex != -1 && cmb_UnitName.Enabled == true)
                {
                    Validation = true;
                    cmb_UnitQuantity.SelectedIndex = ObjectHelper.GeneralObjectClass.DefaultUnitName.FindIndex(i => i.ID == ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitName.SelectedIndex].ID);
                    var getunitqty = ObjectHelper.GeneralObjectClass.DefaultUnitName.Where(i => i.ID == ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitName.SelectedIndex].ID).ToList();
                    if (getunitqty.Count >= 0)
                    {
                        ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = Convert.ToInt32(getunitqty[0].UnitQuantity);
                    }



                }
                Validation = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");

                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", "cmb_UnitName_SelectedIndexChanged");
            }
        }

        private void cmb_UnitQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && Validation == false && cmb_UnitQuantity.SelectedIndex != -1 && cmb_UnitName.Enabled == true)
                {
                    Validation = true;
                    cmb_UnitName.SelectedIndex = ObjectHelper.GeneralObjectClass.DefaultUnitName.FindIndex(i => i.ID == ObjectHelper.GeneralObjectClass.DefaultUnitName[cmb_UnitQuantity.SelectedIndex].ID);
                }
                Validation = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, "AdditionalBarcode");

                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "AdditionalBarcode", "cmb_UnitQuantity_SelectedIndexChanged");
            }
        }

        private void txt_ItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46) != true)
                    e.Handled = true;

                if (e.KeyChar == 46 && (((TextBox)sender).Text.Contains('.')))
                    e.Handled = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " txt_ItemPrice_KeyPress");
            }
        }

        private void cmb_Types_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyData == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " cmbItemNo_KeyDown");
            }
        }


        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTextField();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " btn_Clear_Click");
            }
        }

        private void ClearTextField()
        {
            txt_ItemPrice.Text = "0.000";
            cmb_Types.SelectedIndex = -1;
            cmb_UnitQuantity.SelectedIndex = -1;
            cmb_UnitName.SelectedIndex = -1;
            txtBarcodes.Text = string.Empty;
            txt_MinPrice.Text = "0.000";
            txt_WholeSale.Text = "0.000";
            txtBarcodes.Focus();
            txtBarcodes.SelectAll();
            GridEvent = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {


                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " btnClose_Click");
            }
        }
        #region Barcode
        #region "Timer Tick Event"
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
                    string barcode = ScanValue + txtBarcode.Text.Trim();
                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode);

                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        GeneralFunction.Information("Thisbarcodealreadyavailable", "AdditionalBarcode");

                        ClearBarcodeValues();
                        txtBarcodes.Focus();
                        txt_ItemPrice.Text = "0.000";

                    }
                    else
                    {
                        ScanningBarcode = true;
                        //  ObjItemCardHelper.ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = string.Empty;
                        txtBarcodes.Text = barcode;

                        //Cmb_ItemNo.Focus(); 
                        //cmb_UnitName.Focus();
                        InvokeOnClick(btnSave, EventArgs.Empty);

                        //else { txtBarcode.Text = ""; }
                        ScanningBarcode = false;
                        ClearBarcodeValues();
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
                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " tmrBarcode_Tick");
            }
        }
        #endregion

        void ClearBarcodeValues()
        {
            ScanValue = string.Empty;
            ScanLetterStartTime = DateTime.Now;
            txtBarcode.Text = string.Empty;
            ScannerCount = 0;
            KeyboardmaxCount = 0;
            // cmb_UnitName.Focus();

        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " tmrBarcode_Tick");
            }
        }

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
                    return;
                }
                ScanLetterEndTime = DateTime.Now.Subtract(ScanLetterStartTime);
                if (ScanTimingCheck && ScanValue.Length < 7)
                {
                    //  if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
                    //if ((ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval) | ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1)))
                    //{
                    if (KeyboardmaxCount > 4 && ScanValue.Length > 1)
                    {
                        ScanLetterStartTime = DateTime.Now;
                        ScanValue = string.Empty;
                        ScanValue = e.KeyChar.ToString();
                        KeyboardmaxCount = 0; return;
                        // ScanValue = ScanValue + e.KeyChar.ToString();
                    }
                    if ((ScanLetterEndTime.TotalMilliseconds == 0) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval1 && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval1) | (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds < GeneralFunction.startInterval))
                    {
                        // listBox1.Items.Add(ScanValue + " " + "From KeyboardCount" + ScanLetterEndTime.TotalMilliseconds);
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
                        // ScanValue = e.KeyChar.ToString();
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " OnKeyPress Event");
            }
        }

        #endregion

        private void Additional_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F2)
                {
                    btnBarcode_Click(sender, e);

                    txtBarcodes.Focus();
                    txtBarcodes.SelectAll();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), "AdditionalBarcode");
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " Additional_Barcode_KeyDown");

            }
        }

        private void txt_MinPrice_Leave(object sender, EventArgs e)
        {
            try
            {

                if (txt_MinPrice.Text != string.Empty && txt_MinPrice.Text != ".")
                {
                    if (Convert.ToDecimal(txt_MinPrice.Text) > Convert.ToDecimal(txt_ItemPrice.Text))
                    {
                        GeneralFunction.Information("EqualPrice", "AdditionalBarcode");
                        txt_MinPrice.Focus();
                        txt_MinPrice.SelectAll();

                    }
                    else if (Convert.ToDecimal(txt_MinPrice.Text) > Convert.ToDecimal(txt_ItemPrice.Text))
                    {
                        GeneralFunction.Information("MinimumPriceLessthanWholeSalePrice", "AdditionalBarcode");
                        txt_MinPrice.Focus();
                        txt_MinPrice.SelectAll();

                    }
                    else
                    { txt_MinPrice.Text = Convert.ToDecimal(txt_MinPrice.Text).ToString("0.000"); }

                }
                else
                { txt_MinPrice.Text = "0.000"; }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " txt_MinPrice_Leave");
            }
        }


        private void txt_WholeSale_Leave(object sender, EventArgs e)
        {

            try
            {

                if (txt_WholeSale.Text != string.Empty && txt_WholeSale.Text != ".")
                {
                    if (Convert.ToDecimal(txt_WholeSale.Text) > Convert.ToDecimal(txt_WholeSale.Text))
                    {
                        GeneralFunction.Information("WholeSalePriceLessthanPrice", "AdditionalBarcode");
                        txt_WholeSale.Focus();
                        txt_WholeSale.SelectAll();
                    }
                    else
                    { txt_WholeSale.Text = Convert.ToDecimal(txt_WholeSale.Text).ToString("0.000"); }

                }
                else
                { txt_WholeSale.Text = "0.000"; }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "AdditionalBarcode", " txtWholeSale_Leave");
            }
        }
    }

}