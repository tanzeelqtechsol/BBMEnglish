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
    public partial class Quick_Price_Information : Form, IDisposable
    {
        QuickPriceHelper ObjHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        bool IsFromLoad;
        DataTable dtAllItems = new DataTable();
        int index;
        public Quick_Price_Information()
        {
            InitializeComponent();
            SetLanguage();
            ObjHelper = new QuickPriceHelper();

        }

        public void SetControlFromObject()
        {
            txtExpiry.Text = ObjHelper.BalClass.Objitemcardobjectclass.ItemExpiry == null ? null : Convert.ToDateTime(ObjHelper.BalClass.Objitemcardobjectclass.ItemExpiry).ToShortDateString();
            IsFromLoad = true;
            cmbItem.Text = ObjHelper.BalClass.Objitemcardobjectclass.Items;
            IsFromLoad = false;
            txtMinimumPrice.Text = ObjHelper.BalClass.Objitemcardobjectclass.MinPrice.ToString("0.000");
            PriceValue();
            //txtPrice.Text = ObjHelper.BalClass.Objitemcardobjectclass.Price.ToString("0.000");
            txtStock.Text = ObjHelper.BalClass.Objitemcardobjectclass.StockInHand.ToString();
            txtWholesale.Text = ObjHelper.BalClass.Objitemcardobjectclass.WholeSalePrice.ToString("0.000");
            IsFromLoad = true;
            cmbItemNo.Text = ObjHelper.BalClass.Objitemcardobjectclass.ItemNumber == null ? string.Empty : ObjHelper.BalClass.Objitemcardobjectclass.ItemNumber;
            IsFromLoad = false;
        }

        public void SetObjectFromControl()
        {
            ObjHelper.BalClass.Objitemcardobjectclass.Items = cmbItem.Text;


        }
        public void SetLanguage()
        {
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey(lblExpiry.Tag.ToString());

            lblItemName.Text = Additional_Barcode.GetValueByResourceKey(lblItemName.Tag.ToString());
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey(lblItemNo.Tag.ToString());
            lblMinimumPrice.Text = Additional_Barcode.GetValueByResourceKey(lblMinimumPrice.Tag.ToString());
            //  lblPhoto.Text = Additional_Barcode.GetValueByResourceKey("Photo");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey(lblPrice.Tag.ToString());
            lblStock.Text = Additional_Barcode.GetValueByResourceKey(lblStock.Tag.ToString());
            lblWholeSale.Text = Additional_Barcode.GetValueByResourceKey(lblWholeSale.Tag.ToString());
            btnClose.Text = Additional_Barcode.GetValueByResourceKey(btnClose.Tag.ToString());
            this.Text = Additional_Barcode.GetValueByResourceKey(this.Tag.ToString());

        }

        public void GetItemInfo()
        {
             dtAllItems = ObjHelper.GetAllItems();
            //if (ObjHelper.dictItemLoad["ItemInfo"].Count > 0)
            //{
            if (dtAllItems != null && dtAllItems.Rows.Count > 0)
            {
                cmbItem.DisplayMember = "Items";
                cmbItem.ValueMember = "ItemId";
                cmbItem.DataSource = dtAllItems;//ObjHelper.dictItemLoad["ItemInfo"].OrderBy(a => a.ItemName).ToList();

                cmbItem.SelectedIndex = -1;
            }

            if (dtAllItems != null && dtAllItems.Rows.Count > 0)
            {

                cmbItemNo.BindingContext = new BindingContext();
                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemId";
                DataView dvfilter = new DataView(dtAllItems);
                dvfilter.RowFilter = "ItemNumber<>''";
                cmbItemNo.DataSource = dvfilter.ToTable(); //ObjHelper.dictItemLoad["ItemInfo"].Where(i => i.ItemNumber != string.Empty).ToList();
                cmbItemNo.SelectedIndex = -1;
            }

            txtPrice.Text = "0.000";
            txtWholesale.Text = "0.000";
            txtMinimumPrice.Text = "0.000";
            txtStock.Text = "0.000";
            //txtItem.Text = "";
            //IsFromLoad = true;



        }

        private void Quick_Price_Information_Load(object sender, EventArgs e)
        {
            try
            {
                IsFromLoad = true;
                ObjHelper.LoadData();
                GetItemInfo();
                cmbItemNo.Visible = lblItemNo.Visible = ObjectHelper.GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
                //IsFromLoad = false;
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                IsFromLoad = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " Quick_Price_Information_Load");
            }
        }

        private void Quick_Price_Information_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                if (e.KeyCode == Keys.F12)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " Quick_Price_Information_KeyDown");
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

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnClose_Click");
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsFromLoad)
                {
                    ObjHelper.BalClass.Objitemcardobjectclass.ItemId = Convert.ToInt32(cmbItem.SelectedValue);
                    SetObjectFromControl();
                    ObjHelper.itemnamechange();
                    SetControlFromObject();
                    ObjHelper.NewObject();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " cmbItem_SelectedIndexChanged");
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsFromLoad)
                {
                    if (cmbItemNo.SelectedItem != null)
                    {
                        //string value = cmbItemNo.SelectedValue.ToString();
                        DataRow[] drRow = dtAllItems.Select("ItemId='" + cmbItemNo.SelectedValue + "'");
                        //int index = ObjHelper.dictItemLoad["ItemInfo"].FindIndex(i => i.ItemId == Convert.ToInt32(cmbItemNo.SelectedValue));
                        foreach (DataRow dr in drRow)
                        {
                            index = dr.Table.Rows.IndexOf(dr);
                        }
                        cmbItem.SelectedIndex = index;
                        // cmbItem_SelectedIndexChanged(cmbItem, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " cmbItemNo_SelectedIndexChanged");
            }

        }

        #region Barcode

        #region KeyPress
        //protected override void OnKeyPress(KeyPressEventArgs e)
        //{
        //    try
        //    {
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
        //            //if (ScanLetterEndTime.TotalMilliseconds < GeneralFunction.endInterval && ScanLetterEndTime.TotalMilliseconds > GeneralFunction.startInterval)
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

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " OnKeyPress");
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

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tmrBarcode.Enabled = true;

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "pos_screen", "txtBarcode_KeyUp");
            }
        }

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
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                ClearBarcodeValues();

        //            }
        //            else
        //            {
        //                if (UserScreenLimidations.ItemCard == true)
        //                {
        //                    if (GeneralFunction.Question("NotAvailableBarcode", "QuickPriceInformation") == DialogResult.Yes)
        //                    {
        //                        ItemCard frmItem = new ItemCard();
        //                        GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
        //                        frmItem.ShowDialog();
        //                        GeneralFunction.PurchaseBarcode = string.Empty;

        //                    }
        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    GeneralFunction.Information("ItemNotRegisteredInformAdmin", "QuickPriceInformation");
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

        //        GeneralFunction.ErrInfo(ex.Message, this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Purchase Invoice", "timer1_Tick");
        //    }

        //}


        private void tmrBarcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null && lastFocusedControl.Name != "dtpExpiry")  // Purchase invoice scanning exception throws fixed by Praba on 30-Oct
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
                        cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                        ClearBarcodeValues();
                    }
                    else
                    {
                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "QuickPriceInformation") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                            }
                            ClearBarcodeValues();
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "QuickPriceInformation");
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
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Quick Price", "timer1_Tick");
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
        #endregion

        //private void cmbItem_DropDown(object sender, EventArgs e)
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
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItem_DropDown");
        //    }
        //}

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

        //private void cmbItem_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        //cmbItemName.SelectedIndexChanged  += new EventHandler( cmbItemName_SelectedIndexChanged );
        //        cmbItem_SelectedIndexChanged(cmbItem, new EventArgs());

        //    }
        //    catch (Exception ex)
        //    {

        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItem_DropDownClosed");
        //    }
        //}

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 13)
            //{
            //    if (((ComboBox)sender).DroppedDown == true)
            //        ((ComboBox)sender).DroppedDown = false;
            //}

            if (e.KeyChar == 13)
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    txtMinimumPrice.Focus();
                    txtMinimumPrice.SelectAll();
                }
            }
        }

        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    txtBarcode.Focus();
            //}
        }

        private void PriceValue()
        {
            decimal actualprice = ObjHelper.BalClass.Objitemcardobjectclass.Price;
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
    }
}
