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
using System.Threading;

namespace BumedianBM.ArabicView
{
    public partial class ReturnOrderPopUp : Form, IDisposable
    {
        SalesReturnHelper salesreturnhelper = new SalesReturnHelper();

        PayReceiptHelper payreceipthelper = new PayReceiptHelper();

        Dictionary<int, int> DicOFSaleDetails = new Dictionary<int, int>();
        Dictionary<decimal, int> DicOFItemDetails = new Dictionary<decimal, int>();
        bool IsBox = false;
        bool IsFormLoad = false;
        int StockInHand = 0, BoxQuantity = 0, PieceQuantity = 0, PackageQuantity = 0;
        bool LastFocusedControls = false;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        int Timercount = 0;
        bool SaveQuestion = false;
        private int KeyboardmaxCount = 0;
        internal Boolean isfromPOS;
        public ReturnOrderPopUp()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            cmbItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
        }
        private void SetLanguage()
        {
            lblClient.Text = Additional_Barcode.GetValueByResourceKey(lblClient.Tag.ToString());
            lblClientNo.Text = Additional_Barcode.GetValueByResourceKey(lblClientNo.Tag.ToString());
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey(lblItemName.Tag.ToString());
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey(lblItemNo.Tag.ToString());
            lblNearestExpiry.Text = Additional_Barcode.GetValueByResourceKey(lblNearestExpiry.Tag.ToString());
            lbl_Quantity.Text = Additional_Barcode.GetValueByResourceKey(lbl_Quantity.Tag.ToString());
            lbl_Price.Text = Additional_Barcode.GetValueByResourceKey(lbl_Price.Tag.ToString());
            lbl_PackageQty.Text = Additional_Barcode.GetValueByResourceKey(lbl_PackageQty.Tag.ToString());
            lbl_InvoiceNo.Text = Additional_Barcode.GetValueByResourceKey(lbl_InvoiceNo.Tag.ToString());
            btnClose.Text = Additional_Barcode.GetValueByResourceKey(btnClose.Tag.ToString());
            btnReturnItem.Text = Additional_Barcode.GetValueByResourceKey(btnReturnItem.Tag.ToString());
            btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
            lblSerialNo.Text = Additional_Barcode.GetValueByResourceKey("SerialNo");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            // lbl_Date.Text = GeneralFunction.ChangeLanguageforCustomMsg(this.Tag.ToString());
            this.Text = GeneralFunction.ChangeLanguageforCustomMsg(this.Tag.ToString());  // changing resource as per client feedback On June-27. Done By A.Manoj
        }

        private void ReturnOrderPopUp_Load(object sender, EventArgs e)
        {
            try
            {
                IsFormLoad = true;
                salesreturnhelper.LoadItemDetails();
                FillDatasToControls();
                IsFormLoad = false;

                cmbItem.Select();
                cmbItem.Focus();
                cmb_Date.SelectedIndex = 0;
                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ReturnOrderPopUp_Load");

            }
        }
        private void FillDatasToControls()
        {
            DataTable dt = salesreturnhelper.GetAllItemDetails();
            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemID";
            cmbItem.DataSource = dt; //salesreturnhelper.lstItem.OrderBy(a => a.ItemName).ToList();
            cmbItem.SelectedIndex = -1;
            cmbItemNo.BindingContext = new BindingContext();
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemID";
            DataView dv = new DataView(dt);
            dv.RowFilter = "ItemNumber<>''";
            cmbItemNo.DataSource = dv.ToTable(); // salesreturnhelper.lstItem.Where(i => i.ItemNumber != string.Empty).ToList();
            cmbItemNo.SelectedIndex = -1;

            cmbClientNo.DisplayMember = "AgentId";
            cmbClientNo.ValueMember = "Name";
            cmbClientNo.DataSource = salesreturnhelper.lstClient;

            cmbClient.DisplayMember = "Name";
            cmbClient.ValueMember = "AgentId";

            cmbClient.DataSource = salesreturnhelper.lstClient;

            cmbExpiryDate.DisplayMember = "expiry";

            cmbClient.SelectedValue = 1001;
            //cmbClient.SelectedIndex = 0;
            //cmbClientNo.SelectedIndex =0;

        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && cmbItem.SelectedIndex != -1)
                {
                    // cmbItemNo.SelectedValue = cmbItem.SelectedValue;
                    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt32(cmbItem.SelectedValue.ToString());
                    cmbItemNo.SelectedValue = Convert.ToInt32(salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno);
                    AssignFromControlsToObject();
                    salesreturnhelper.GetItemInformation();

                    AssignFromObjectToControls();
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();





                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItem_SelectedIndexChanged");

            }

        }
        private void AssignFromControlsToObject()
        {
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt32(cmbItem.SelectedValue);
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName = cmbItem.Text.ToString();
            if (IsBox != false)
            {
                BoxQuantity = txtQuantity.Text == string.Empty ? 0 : Convert.ToInt32(txtQuantity.Text);
                if (PackageQuantity == 0)
                {
                    //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = 1;commented on  24/05/2014
                    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = 0;
                }
                else
                {
                    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = Convert.ToInt32(BoxQuantity * PackageQuantity);
                }

            }
            else
            {
                salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = txtQuantity.Text == string.Empty ? 0 : Convert.ToInt32(txtQuantity.Text);
            }
            if (salesreturnhelper.TypeOfItem == 2) ///avoid the box piece calculation for seconhad item on 01 july 2014
            {
                salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = txtQuantity.Text == string.Empty ? 0 : Convert.ToInt32(txtQuantity.Text);///to avoid the box piece calculation for seconhad hand item on 01 july 2014
            }
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returndate = Convert.ToDateTime(DateTime.Now);
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue = txt_Price.Text == string.Empty ? 0 : Convert.ToDecimal(txt_Price.Text);

            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user = GeneralFunction.UserId;
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.createdby = salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.modifiedby = GeneralFunction.UserId;
            //Commeted on 20/04/2014
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = cmbExpiryDate.Text == string.Empty ? (Nullable<DateTime>)null : Convert.ToDateTime(cmbExpiryDate.Text);
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = cmbExpiryDate.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(cmbExpiryDate.Text);
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno = cmbClientNo.Text == string.Empty ? 0 : Convert.ToInt32(cmbClientNo.Text);
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ClientName = cmbClient.Text.ToString();
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Newexpr = DateTime.Now;
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.QuickReturn = true;
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = 2;
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = cmbSerialNo.Text == string.Empty ? "0" : cmbSerialNo.Text.Trim();




            //  salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid =txtbillno.Text==string.Empty? 0:Convert.ToInt32(txtbillno.Text);
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice   = txt_Price.Text == string.Empty ? 0 : Convert.ToDecimal(txt_Price.Text);



        }
        private void AssignFromObjectToControls()
        {


            ///  StockInHand =ListOfExpiryDetails.Count==0?0: Convert.ToInt32(ListOfExpiryDetails[0].Stock ); commented on 30 april 2014
            //foreach(var  result in DicOFItemDetails )
            //{
            //    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice = Convert.ToDecimal(result.Key);
            //  PackageQuantity  =result.Value ;
            //}commented on 30 april 2014

            //txtPackageQty.Text = PackageQuantity.ToString();commented on 30 april 2014
            if (salesreturnhelper.GetExpiryDate.Count > 0)
            {
                cmbExpiryDate.DataSource = salesreturnhelper.GetExpiryDate.Select(i => i.expiry).ToList();//.Select(i => i.expiry).ToList();

                //cmbExpiryDate.Visible = true;
                //lblNearestExpiry.Visible = true;
                //lbl_PackageQty.Visible = txtPackageQty.Visible = true;
                //cmbSerialNo.Visible = lblSerialNo.Visible = false;
                cmbSerialNo.DataSource = null;


            }
            else { cmbExpiryDate.SelectedIndex = -1; }
            if (salesreturnhelper.GetSerialNoList.Count > 0)
            {
                cmbSerialNo.DisplayMember = "serialno";
                cmbSerialNo.ValueMember = "unitprice";
                //cmbSerialNo.Visible = true;
                //lblSerialNo.Visible = true;
                cmbSerialNo.DataSource = salesreturnhelper.GetSerialNoList.ToList();

                cmbExpiryDate.DataSource = null;
                //lblNearestExpiry.Visible = cmbExpiryDate.Visible = false;
                //lbl_PackageQty.Visible = txtPackageQty.Visible = false;
                cmbSerialNo.SelectedIndex = 0;


            }
            else { cmbSerialNo.SelectedIndex = -1; }
            VisibleOfControls();

            if (salesreturnhelper.GetPackagQuantityList.Count > 0)
            {

                txtPackageQty.DisplayMember = "package";
                txtPackageQty.ValueMember = "BarcodeID";
                txtPackageQty.DataSource = salesreturnhelper.GetPackagQuantityList.ToList();

                txtPackageQty.SelectedIndex = 0;
            }
            else { txtPackageQty.SelectedIndex = -1; }


            ///btnBox_Click(btnBox, new EventArgs()); Should include after 


        }

        private void VisibleOfControls()
        {
            if (salesreturnhelper.TypeOfItem == 1)
            {
                cmbExpiryDate.Visible = true;
                lblNearestExpiry.Visible = true;
                lbl_PackageQty.Visible = txtPackageQty.Visible = true;
                cmbSerialNo.Visible = lblSerialNo.Visible = false;
            }
            else
            {
                cmbSerialNo.Visible = true;
                lblSerialNo.Visible = true;
                lblNearestExpiry.Visible = cmbExpiryDate.Visible = false;
                lbl_PackageQty.Visible = txtPackageQty.Visible = false;
            }
        }

        private void btnReturnItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveQuestion == false)
                {
                    if (ObjectHelper.GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                    {

                        if (GeneralFunction.Question("DoYouWantToReturnTheItem", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            ReturnFunctionality();
                        }
                    }
                    else
                    {
                        ReturnFunctionality();
                    }
                }
                else
                {


                    ReturnFunctionality();
                }




            }

            catch (Exception ex)
            {


                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnReturnItem_Click");

            }


        }
        private void ReturnFunctionality()
        {

            AssignFromControlsToObject();
            GetRetrunInvoiceId();
            /// GetSaleDetailsID();commented on 16 may 2014
            if (salesreturnhelper.ValidationQuickReturn())
            {
                if (salesreturnhelper.FindtheSalesItem(isfromPOS) > 0)
                {
                    if (IsBox == true)//added to calculate the total return value
                    {
                        salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue = salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * (Convert.ToInt32(txtQuantity.Text) * (PackageQuantity == 0 ? 1 : PackageQuantity));
                    }
                    else
                    {
                        salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue = salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * (Convert.ToInt32(txtQuantity.Text));

                    }
                    if (salesreturnhelper.SaveSaleReturnDetailsHelper())
                    {

                        salesreturnhelper.GetMaxIDOFPaymentDetails();

                        GeneralFunction.Information(Constants.ReturnOrderItem, ActionType.Return.ToString());

                        //  salesreturnhelper.Print(); to avoid the print option on 27 jun 2014
                        this.Close();

                    }
                }
                else
                {
                    GeneralFunction.Information("Cant Return The Item", ActionType.Return.ToString());
                }

            }
            else
            {
                ChangeProperties(salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString);
            }
        }

        private void GetSaleDetailsID()
        {
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt32(cmbItem.SelectedValue);
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid = Convert.ToInt32(txtbillno.Text);
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry=cmbExpiryDate.Text == string.Empty ? (Nullable<DateTime>)null : Convert.ToDateTime(cmbExpiryDate.Text);
            //salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = txt_Price.Text == string.Empty ? 0 : Convert.ToDecimal(txt_Price.Text);

            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = salesreturnhelper.GetSaleDetailsID();


        }

        private void GetRetrunInvoiceId()
        {
            //List<long> lstMaxID = salesreturnhelper.GetMInMaxSaleReturnIDHelper();

            //if (lstMaxID.Count > 0)
            //{
            //    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt32((lstMaxID[1] > 0) ? lstMaxID[1].ToString() : "1");
            //}
            salesreturnhelper.NewbtnYearInvoice();
            salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt32(salesreturnhelper.InvoiceID[0]);
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            //BoxQuantity = 0;
            //StockInHand = 0;
            //PackageQuantity = 0;
            //PieceQuantity = 0;

            try
            {
                if (IsBox == false)
                {

                    if (!String.IsNullOrEmpty(txtPackageQty.Text))
                    {
                        ////BoxQuantity = Math.DivRem(StockInHand, PackageQuantity, out PieceQuantity);
                        ////txtQuantity.Text = (BoxQuantity * PackageQuantity).ToString();
                        ////txtQuantity.Text = BoxQuantity.ToString();
                        var price = Sales_Invoice.CommonRoundPrice(float.Parse(salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice.ToString()));
                        txt_Price.Text = price.ToString("###########.000");
                        btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                        //if (PackageQuantity != 0)
                        //{
                        //    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = (salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice / PackageQuantity);
                        //}

                        salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = Convert.ToDecimal((price / (PackageQuantity == 0 ? 1 : PackageQuantity)).ToString("#####0.000"));
                        IsBox = true;
                    }
                    else
                    {
                        btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                        IsBox = true;
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txtPackageQty.Text))
                    {
                        ////BoxQuantity = Math.DivRem(StockInHand, PackageQuantity, out PieceQuantity);
                        ////txtQuantity.Text = ((BoxQuantity * PackageQuantity) + PieceQuantity).ToString();
                        if (PackageQuantity != 0)
                        {
                            txt_Price.Text = Sales_Invoice.CommonRoundPrice(float.Parse((salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice / PackageQuantity).ToString())).ToString("#########.000");
                        }
                        btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                        salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = Convert.ToDecimal(txt_Price.Text);
                        IsBox = false;
                    }
                    else
                    {

                        btnBox.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                        IsBox = false;
                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnBox_Click");

            }

        }
        bool isFirst, isSuggFirst = false;
        string appval = "";
        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyData == Keys.Enter)
                //{
                //    e.Handled = true;
                //    SendKeys.Send("{TAB}");
                //}

                //Commented by Praba on 21-Oct-2014

                //       if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.RWin) && (e.KeyCode != Keys.LWin))
                //       {
                //           if (((ComboBox)sender).DroppedDown == true)
                //               ((ComboBox)sender).DroppedDown = false;
                //           if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                //           {

                //               cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                //               cmbItem.SelectedText = ((char)e.KeyValue).ToString();
                //               cmbItem.DroppedDown = true;
                //               isFirst = true;
                //               appval = ((char)e.KeyValue).ToString();
                //               //cmbItemName.SelectionStart = 1;
                //               isSuggFirst = true;
                //           }
                //           else
                //           {
                //               cmbItem.DroppedDown = false;
                //               if (isFirst)
                //               {
                //                   cmbItem.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                //                   isFirst = false;
                //               }
                //               isSuggFirst = false;
                //           }
                //       }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItem_KeyDown");

            }
        }

        private void btnReturnItem_Leave(object sender, EventArgs e)
        {
            try
            {

                if (LastFocusedControls == false)
                {
                    SaveQuestion = true;
                    if (ObjectHelper.GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                    {
                        if (GeneralFunction.Question("DoYouWantToReturnTheItem", this.Tag.ToString()) == DialogResult.Yes)
                        {
                            btnReturnItem_Click(sender, e);
                        }
                    }
                    else
                    {
                        btnReturnItem_Click(sender, e);
                    }
                    SaveQuestion = false;///////once ask the save validation question after set to be false 
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnReturnItem_Leave");

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
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnClose_Click");

            }
        }
        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                foreach (Control controls in ReturnPanel.Controls)
                {
                    if (controls.Name == ctrl)
                    {
                        LastFocusedControls = true;
                        controls.Select();
                        controls.Focus();
                        LastFocusedControls = false;

                        //    return;


                    }
                }

            }

        }



        private void ReturnOrderPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                if (e.KeyCode == Keys.F9)
                {
                    btnBox_Click(sender, new EventArgs());
                }
                if (e.KeyCode == Keys.F3)
                {
                    InvokeOnClick(btnReturnItem, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "ReturnOrderPopUp_KeyDown");

            }

        }


        private void cmbItemNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnReturnItem_Leave(sender, EventArgs.Empty);
                }
                //else if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46) != true)
                //    e.Handled = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " cmbItemNo_KeyPress");
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
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "OnkeyPress");
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
        //private void Tmr_Barcode_Tick(object sender, EventArgs e)
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

        //            if (ScanValue != "" & ScanValue.Length > 1)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode);
        //            tmrBarcode.Enabled = false;

        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();


        //                // pagingTables.Select(
        //                ClearBarcodeValues();
        //                txtQuantity.Focus();


        //            }
        //            else
        //            {
        //                GeneralFunction.Information("This Barcode is not availabe", this.Tag.ToString());
        //                //{
        //                //ItemCard frmItem = new ItemCard();
        //                //GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue );
        //                //frmItem.ShowDialog();
        //                //GeneralFunction.PurchaseBarcode = string.Empty;
        //                ClearBarcodeValues();
        //                //}
        //                //else
        //                //{
        //                //    ClearBarcodeValues();
        //                //}
        //            }

        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "ReturnOrderPopUp", "timer1_Tick");
        //        GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Tmr_Barcode_Tick");

        //    }

        //}


        private void Tmr_Barcode_Tick(object sender, EventArgs e)
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
                        // pagingTables.Select(
                        ClearBarcodeValues();
                        txtQuantity.Focus();
                    }
                    else
                    {
                        GeneralFunction.Information("This Barcode is not availabe", this.Tag.ToString());
                        //{
                        //ItemCard frmItem = new ItemCard();
                        //GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue );
                        //frmItem.ShowDialog();
                        //GeneralFunction.PurchaseBarcode = string.Empty;
                        ClearBarcodeValues();
                        //}
                        //else
                        //{
                        //    ClearBarcodeValues();
                        //}
                    }

                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
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
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //    if (txtBarcode.Text != string.Empty)
                //    {
                //        Timercount = 0;
                tmrBarcode.Enabled = true;
                //}
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtBarcode_KeyUp");
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int itemno = Convert.ToInt32(cmbItemNo.SelectedValue);
                if (!IsFormLoad && cmbItemNo.SelectedIndex != -1)
                {//cmbItem.SelectedValue = itemno;
                    if (cmbItemNo.SelectedIndex > -1)
                    {
                        int value = Convert.ToInt32(cmbItemNo.SelectedValue);
                        cmbItem.SelectedValue = value;
                        //cmbItem_SelectedIndexChanged(cmbItem, new EventArgs());

                    }
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbItemNo_SelectedIndexChanged");
            }
        }

        //private void cmbClient_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //    }
        //    catch (Exception ex)
        //    {


        //        GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Item_DropDown");
        //    }
        //}

        //private void cmbClient_DropDownClosed(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        switch (((ComboBox)sender).Name)
        //        {
        //            case "cmbClient":
        //                cmbClient_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;
        //            case "cmbClientNo":
        //                cmbClientNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;
        //            case "cmbItem":
        //                cmbItem_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;

        //            case "cmbItemNo":
        //                cmbItemNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //                break;



        //        }
        //    }
        //    catch (Exception ex)
        //    {


        //        GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_Item_DropDownClosed");
        //    }
        //}

        private void txtPackageQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && txtPackageQty.SelectedIndex != -1)
                {
                    salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BarcodeID = txtPackageQty.SelectedIndex == -1 ? 0 : Convert.ToInt32(salesreturnhelper.GetPackagQuantityList[txtPackageQty.SelectedIndex].BarcodeID);
                    DicOFItemDetails = salesreturnhelper.GetUnitPriceForItem();

                    foreach (var result in DicOFItemDetails)
                    {
                        salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice = Convert.ToDecimal(result.Key);
                        PackageQuantity = result.Value;
                    }
                    IsBox = false;
                    btnBox_Click(btnBox, new EventArgs());
                }

                //txt_Price.Text = salesreturnhelper.objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemPrice.ToString();


            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "txtPackageQty_SelectedIndexChanged");

            }
        }

        private void cmbSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbSerialNo.SelectedIndex != -1)
            //    {
            //        //  var items = ObjHelper.PackageQty.Where(a => a.ItemPackage == Convert.ToInt32(txtPackage.Text)).ToList();
            //       // string a=cmbSerialNo.SelectedValue.ToString();
            //        decimal price =salesreturnhelper.GetSerialNoList[cmbSerialNo.SelectedIndex].unitprice;
            //        txt_Price.Text = price.ToString("#############.000");
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        private void cmbClientNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && cmbClientNo.SelectedIndex != -1)
                {
                    cmbClient.SelectedIndex = salesreturnhelper.lstClient.FindIndex(i => i.AgentId == salesreturnhelper.lstClient[cmbClientNo.SelectedIndex].AgentId);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbClientNo_SelectedIndexChanged");
            }

        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsFormLoad == false && cmbClient.SelectedIndex != -1)
                {
                    cmbClientNo.SelectedIndex = salesreturnhelper.lstClient.FindIndex(i => i.AgentId == salesreturnhelper.lstClient[cmbClient.SelectedIndex].AgentId);
                }
            }


            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "cmbClient_SelectedIndexChanged");
            }

        }
        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control ctrl in ReturnPanel.Controls)
                {
                    if (ctrl is Button || ctrl is CheckBox || ctrl is Label || ctrl is RadioButton || ctrl is GroupBox)
                        ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }

            }
        }

        private void cmbItem_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //    txtBarcode.Focus();

            if (e.KeyValue == 13)
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
            }
        }

        private void cmbClient_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
            else //Added on 23-June-2014 for Avoiding Performance issue
            {
                if (((ComboBox)sender).DroppedDown == true)
                    ((ComboBox)sender).DroppedDown = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AssignFromControlsToObject();
            if (salesreturnhelper.ValidationQuickReturn())
            {
                if (salesreturnhelper.RevertQucikReturn() > 0)
                {
                    GeneralFunction.Information("Itemsarereturnsuccessfully", "ReturnOrderPopUp");
                    Clear();
                }
                else
                {
                    GeneralFunction.Information("Thereisnoiteminstock", "ReturnOrderPopUp");
                }
            }
            else
                return;
        }

        private void Clear()
        {

            cmbItemNo.SelectedIndex = cmbItem.SelectedIndex = -1;
            this.txt_Price.Text = string.Empty;
            txtPackageQty.DataSource = null;
            this.txtQuantity.Text = "1";
            cmbClientNo.SelectedIndex = cmbClient.SelectedIndex = -1;
            this.cmbExpiryDate.DataSource = null;
            this.cmbSerialNo.DataSource = null;

        }

    }
}

