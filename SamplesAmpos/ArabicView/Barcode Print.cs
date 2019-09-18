using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CrystalDecisions.CrystalReports.Engine;
using CommonHelper;
using System.Threading;
using BumedianBM.CrystalReports;
using System.Drawing.Printing;

namespace BumedianBM.ArabicView
{
    public partial class Barcode_Print : Form, IDisposable
    {
        #region Variables
        BarcodePrintHelper objBarPrintHelp;
        Dictionary<string, List<ItemCardObjectClass>> dictItemDetsBarcodeBAL = new Dictionary<string, List<ItemCardObjectClass>>();
        List<ItemCardObjectClass> objprintdetailgrid = new List<ItemCardObjectClass>();

        private ReportDocument summery = null;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false;
        private int ScannerCount = 0;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        int Timercount = 0;
        private int KeyboardmaxCount = 0;
        #endregion
        public Barcode_Print()
        {
            InitializeComponent();
            objBarPrintHelp = new BarcodePrintHelper();
            SetLanguage();
            setFont();
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgrBarcode.Rows.Clear();
                if (cmbItemName.SelectedIndex != -1 && !string.IsNullOrEmpty(cmbItemName.Text))
                {
                    int itemid = objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.ItemId = Convert.ToInt32(cmbItemName.SelectedValue.ToString());
                    var index = dictItemDetsBarcodeBAL["BarcodeDetails"].FindAll(x => x.ItemId == itemid);
                    if (index.Count > 0)
                    {
                        for (int i = 0; i < index.Count; i++)
                        {

                            dgrBarcode.Rows.Add();
                            dgrBarcode.Rows[i].Cells["Ids"].Value = index[i].BarcodeId.ToString();
                            dgrBarcode.Rows[i].Cells["Barcodes"].Value = index[i].Barcode;
                            dgrBarcode.Rows[i].Cells["ItemId"].Value = index[i].ItemId;
                            dgrBarcode.Refresh();
                        }
                    }
                    ////else
                    ////{
                    ////    GeneralFunction.Information("NoBarcodeDetailstoPrint", this.Tag.ToString());///double time show the validation messgae for without barcode item
                    ////}
                    if (cmbItemName.SelectedIndex != -1)
                    {
                        int stock = 0;
                        stock = objBarPrintHelp.GetStockforItems();
                        txtStock.Text = stock.ToString();  // This is added to avoid exception as index out of range exception. Done By: A.Manoj On July-01
                        //    Txt_Stock.Text = Obj_ItemDal.Get_Stock().ToString();
                        //    Cmb_ItemNo.SelectedIndex = -1;

                        //cmbItemNo.Text = cmbItemName.SelectedValue.ToString(); 
                        cmbItemNo.SelectedValue = cmbItemName.SelectedValue;

                    }

                    //Dgv_Barcode.DataSource = BarDt;

                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_ItemName_SelectedIndexChanged");
            }
        }

        private void Barcode_Print_Load(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = UserScreenLimidations.PrintBarcode;
                if (GeneralOptionSetting.FlagBarcodePaperSize == "0")
                {
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.pagesize = 65;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.columncount = 5;
                }
                else if (GeneralOptionSetting.FlagBarcodePaperSize == "1")
                {
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.pagesize = 68;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.columncount = 4;
                }
                else
                {
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.pagesize = 145;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.columncount = 5;
                }
                if (GeneralFunction.Column != 0)
                    txtColumn.Text = Convert.ToString(GeneralFunction.Column);
                else
                    txtColumn.Text = string.Empty;
                if (GeneralFunction.Row != 0)
                    txtRow.Text = Convert.ToString(GeneralFunction.Row);
                else txtRow.Text = string.Empty;
                if (GeneralFunction.TxtQty != 0)
                    txtQty.Text = Convert.ToString(GeneralFunction.TxtQty);
                else txtQty.Text = string.Empty;
                if (GeneralFunction.Totalpage != 0)
                    Txt_Totalpages.Text = Convert.ToString(GeneralFunction.Totalpage);
                else Txt_Totalpages.Text = string.Empty;
                if (GeneralFunction.TotalQty != 0)
                    Txt_Totalqty.Text = Convert.ToString(GeneralFunction.TotalQty);
                else Txt_Totalqty.Text = string.Empty;
                cmbItemName.SelectedIndex = GeneralFunction.ItemIndex;


                chkPrintprice.Checked = GeneralFunction.Chkprice;
                chkPrintlogo.Checked = GeneralFunction.Chklogo;
                radNormalPrice.Checked = GeneralFunction.Normalprice;
                radBigPrice.Checked = GeneralFunction.Bigprice;
                chkPrintPreview.Checked = true;

                if (GeneralFunction.BarcodeDetails != null && GeneralFunction.BarcodeDetails.Rows.Count > 0)
                {
                    for (int i = 0; i < GeneralFunction.BarcodeDetails.Rows.Count; i++)
                    {
                        GeneralFunction.BarcodeDetails.Rows[i]["Logo"] = GeneralOptionSetting.HeaderLogo;
                        GeneralFunction.BarcodeDetails.Rows[i]["CompanyName"] = GeneralOptionSetting.FlagCompanyName;
                    }
                }

                Dgv_PrintDetails.DataSource = GeneralFunction.AddDT;
                chkPrintprice.Checked = false;
                txtBarcode.Focus();
                chkPrintprice.Checked = false;
                radBigPrice.Visible = false;
                radNormalPrice.Visible = false;
                if (txtQty.Text == string.Empty) txtQty.Text = "1";

                ScanValue = "0";
                ScanTimingCheck = true;
                ScanLetterStartTime = DateTime.Now;
                FillItemNameComboBox();
                cmbItemNo.Visible = lblItemNo.Visible = (GeneralOptionSetting.FlagHideItemNumber == "Y") ? false : true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Barcode_Print_Load");
            }
        }

        private void FillItemNameComboBox()
        {
            dictItemDetsBarcodeBAL = objBarPrintHelp.GetItemDetailsWithBarcodeHelp();
            if (dictItemDetsBarcodeBAL != null)
            {
                this.cmbItemName.SelectedIndexChanged -= new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
                cmbItemNo.DisplayMember = "ItemNumber";
                cmbItemNo.ValueMember = "ItemId";
                cmbItemNo.DataSource = dictItemDetsBarcodeBAL["Items"].Where(i => i.ItemNumber != string.Empty).ToList();

                cmbItemNo.SelectedIndex = -1;

                cmbItemName.DisplayMember = "ItemName";
                cmbItemName.ValueMember = "ItemId";
                cmbItemName.DataSource = dictItemDetsBarcodeBAL["ItemDetail"].OrderBy(i => i.ItemName).ToList();
                cmbItemName.SelectedIndex = -1;
                this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);

            }
        }

        public void SetLanguage()
        {
            lblBarcode.Text = Additional_Barcode.GetValueByResourceKey("Barcode");
            lblCloumn.Text = Additional_Barcode.GetValueByResourceKey("Column");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("IName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("INo");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblRow.Text = Additional_Barcode.GetValueByResourceKey("Row");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblTotalPages.Text = Additional_Barcode.GetValueByResourceKey("TPages");
            lblTotalQty.Text = Additional_Barcode.GetValueByResourceKey("TQty");
            btnAdd.Text = Additional_Barcode.GetValueByResourceKey("Add");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnOpen.Text = Additional_Barcode.GetValueByResourceKey("Open");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            radBigPrice.Text = Additional_Barcode.GetValueByResourceKey("BigPrice");
            radNormalPrice.Text = Additional_Barcode.GetValueByResourceKey("NormalPrice");
            chkPrintlogo.Text = Additional_Barcode.GetValueByResourceKey("PrintLogo");
            chkPrintprice.Text = Additional_Barcode.GetValueByResourceKey("PrintPrice");

            Dgv_PrintDetails.Columns["Item"].HeaderText = Additional_Barcode.GetValueByResourceKey("Item");
            Dgv_PrintDetails.Columns["Id"].HeaderText = Additional_Barcode.GetValueByResourceKey("Id");
            Dgv_PrintDetails.Columns["Barcode"].HeaderText = Additional_Barcode.GetValueByResourceKey("Barcode");
            Dgv_PrintDetails.Columns["Row"].HeaderText = Additional_Barcode.GetValueByResourceKey("Row");
            Dgv_PrintDetails.Columns["Column"].HeaderText = Additional_Barcode.GetValueByResourceKey("Column");
            Dgv_PrintDetails.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            this.Text = Additional_Barcode.GetValueByResourceKey(this.Tag.ToString());
            chkPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PP");
        }

        #region"Draw Item"

        private void cmbItemName_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                if (e.Index <= -1) return;
                Graphics g = e.Graphics;
                List<ItemCardObjectClass> objItemNameList = (List<ItemCardObjectClass>)cmbItemName.DataSource;
                if (objItemNameList.Count < 0) return;
                string ItemName; bool BarcodeStatus;
                ItemName = objItemNameList[e.Index].ItemName;
                BarcodeStatus = objItemNameList[e.Index].BarcodeStatus;
                if (BarcodeStatus == false)
                {
                    e.DrawBackground();
                    e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 11, FontStyle.Bold), new SolidBrush(Color.Red), e.Bounds, new StringFormat(StringFormatFlags.DirectionRightToLeft));

                }
                else
                {

                    e.DrawBackground();
                    e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 11, FontStyle.Bold), new SolidBrush(Color.Black), e.Bounds, new StringFormat(StringFormatFlags.DirectionRightToLeft));

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_ItemName_DrawItem");
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControls();
                if (objBarPrintHelp.AddValidation())
                {
                    if (txtColumn.Text == string.Empty || txtRow.Text == string.Empty) txtQty_Leave(sender, e);
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Rows = (txtRow.Text != null && txtRow.Text.ToString().Trim() != string.Empty) ? Convert.ToInt32(txtRow.Text.ToString()) : 0;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Columns = (txtColumn.Text != null && txtColumn.Text.ToString().Trim() != string.Empty) ? Convert.ToInt32(txtColumn.Text.ToString()) : 0;
                    DataTable dt = objBarPrintHelp.AddData();
                    Dgv_PrintDetails.DataSource = dt;

                    // objprintdetailgrid = (List<ItemCardObjectClass>)Dgv_PrintDetails.DataSource;
                    objprintdetailgrid = CommonHelper.ConvertionHelper.ConvertToList<ItemCardObjectClass>(dt).ToList<ItemCardObjectClass>();

                    objBarPrintHelp.AddPrintDetails(objprintdetailgrid);
                    Txt_Totalpages.Text = objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Totalpages;
                    txtRow.Text = objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Rows.ToString();
                    txtColumn.Text = objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Columns.ToString();
                    Txt_Totalqty.Text = objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Totalqty;

                    //cmbItemNo.SelectedIndex = -1;
                    //cmbItemName.SelectedIndex = -1;
                    cmbItemNo.Text = string.Empty;
                    cmbItemName.Text = string.Empty;
                    //cmbItemName.SelectedIndex = -1;
                    if (txtRow.Text == string.Empty)
                    {
                        txtQty_Leave(sender, e);
                    }
                    cmbItemName.Focus();
                    cmbItemName.Select();
                    dgrBarcode.Rows.Clear();
                    txtStock.Text = string.Empty;
                }
                else
                {
                    ChangeProperties(objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.ValidationString);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnAdd_Click");
            }
        }
        private void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                this.Controls[ctrl].Focus();
                this.Controls[ctrl].Select();
            }

        }

        private void SetObjectFromControls()
        {
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty = (txtQty.Text.ToString().Trim() != string.Empty && txtQty.Text.ToString().Trim() != "0") ? Convert.ToInt32(txtQty.Text.ToString()) : 0;
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.BarSelectedCount = Convert.ToInt32(dgrBarcode.SelectedRows.Count);
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.ItemName = (cmbItemName.Text != null && cmbItemName.Text != string.Empty && cmbItemName.SelectedIndex != -1) ? cmbItemName.Text.ToString() : string.Empty;
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.ItemId = (cmbItemName.Text != null && cmbItemName.Text != string.Empty && cmbItemName.SelectedIndex != -1) ? Convert.ToInt32(cmbItemName.SelectedValue.ToString()) : -1;

            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Totalqty = Txt_Totalqty.Text.ToString();
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Barcode = dgrBarcode.Rows.Count > 0 ? dgrBarcode.SelectedRows[0].Cells["Barcodes"].Value.ToString() : string.Empty;
            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Rows = txtRow.Text == string.Empty ? 0 : Convert.ToInt32(txtRow.Text);


            objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.Columns = txtColumn.Text == string.Empty ? 0 : Convert.ToInt32(txtColumn.Text);
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text == string.Empty) return;
                if (Txt_Totalqty.Text == string.Empty)
                {
                    txtRow.Text = "1";
                    txtColumn.Text = "1";
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Qty_Leave");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (Dgv_PrintDetails.RowCount <= 0) { GeneralFunction.Information("EmptyBarcode", this.Tag.ToString()); return; }
                objBarPrintHelp.SaveBarcode();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnSave_Click");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                objBarPrintHelp.OpenBarcode();
                int count = 0;
                if (GeneralFunction.AddDT.Rows.Count > 0)
                {
                    Dgv_PrintDetails.DataSource = GeneralFunction.AddDT;
                    for (int i = 0; i < GeneralFunction.AddDT.Rows.Count; i++)
                    {
                        count += int.Parse(GeneralFunction.AddDT.Rows[i]["Quantity"].ToString());
                    }
                }

                decimal count1, count2;
                char[] ch = { '.' };
                count1 = count / objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.columncount;
                count2 = count % objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.columncount;
                string str = Convert.ToString(Math.Floor(count1) + 1);
                string str1 = Convert.ToString(Math.Floor(count2) + 1);
                txtRow.Text = str;
                txtColumn.Text = str1;
                Txt_Totalqty.Text = count.ToString();
                Txt_Totalpages.Text = Convert.ToString(Math.Ceiling(Convert.ToDecimal(Txt_Totalqty.Text) / Convert.ToDecimal(objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.pagesize)));
                GeneralFunction.Tempqty = count;
                GeneralFunction.TotalQty = count;
                GeneralFunction.Total = count;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnOpen_Click");
            }

        }
        bool isFirst = false;
        string appval = "";
        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                   // cmbItemName.AutoCompleteMode = AutoCompleteMode.None;
                    //SendKeys.Send("{TAB}");
                    //txtQty.SelectAll();
                    txtQty.Focus();
                }
                else
                {
                    //if (sender is ComboBox)  //This is added to avoid the exception as 
                    //{
                    //    if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
                    //(e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
                    //&& (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
                    //&& (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
                    //&& (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (((Control)sender).Name == "cmbItemName") && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
                    //    {
                    //        if (((ComboBox)sender).DataSource != null)
                    //        {
                    //            if (((ComboBox)sender).DroppedDown == true)
                    //                ((ComboBox)sender).DroppedDown = false;
                    //        }
                    //        if (((ComboBox)sender).Name == "cmbItemName" && cmbItemName.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
                    //        {
                    //            cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //            cmbItemName.SelectedText = ((char)e.KeyValue).ToString();
                    //            cmbItemName.DroppedDown = true;
                    //            isFirst = true;
                    //            appval = ((char)e.KeyValue).ToString();
                    //        }
                    //        else if (((ComboBox)sender).Name == "cmbItemName")
                    //        {
                    //            cmbItemName.DroppedDown = false;
                    //            if (isFirst)
                    //            {
                    //                cmbItemName.SelectedText = appval.Substring(0, 1);//+ ((char)e.KeyValue).ToString().Substring(0, 1);
                    //                isFirst = false;
                    //            }

                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message, this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_ItemName_KeyDown");
            }
        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemNo.SelectedItem != null)
                {
                    cmbItemName.SelectedValue = Convert.ToInt32(cmbItemNo.SelectedValue);
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Cmb_ItemNo_SelectedIndexChanged");
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtQty_Leave(sender, e);
                    btnAdd_Click(sender, e); 
                    cmbItemName.Focus();
                   // cmbItemName.Select();
                }
                else if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", this.Tag.ToString());
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Qty_KeyPress");
            }
        }

        private void txtRow_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", this.Tag.ToString());
                    e.Handled = true;
                }
                //e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Row_KeyPress");
            }
        }

        private void txtColumn_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                }
                else if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false))
                {
                    GeneralFunction.Information("OnlyNumbersAllowed", this.Tag.ToString());
                    e.Handled = true;
                }
                // e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Column_KeyPress");
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Stock_KeyPress");
            }
        }

        private void Txt_Totalpages_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Totalpages_KeyPress");
            }
        }

        private void Txt_Totalqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Totalqty_KeyPress");
            }
        }


        #region "Key Up Events"


        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBarcode.Text != string.Empty)
                {
                    Timercount = 0;
                    tmrBarcode.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Totalqty_KeyPress");
            }
        }


        #endregion

        #region"Key Down Events"

        private void barcode_print_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "barcode_print_KeyDown");
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.BarcodeDetails.Rows.Count > 0)
                {
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.PriceFlag = chkPrintprice.Checked;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.BigPriceFlag = radBigPrice.Checked;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.PrintLogoFlag = chkPrintlogo.Checked;
                    objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.PrintPreviewChecked = chkPrintPreview.Checked;

                    objBarPrintHelp.GeneratePrint();
                }
                else
                {
                    GeneralFunction.Information("NoBarcodeDetailstoPrint", this.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_Print_Click");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (Dgv_PrintDetails.RowCount > 0)
                {
                    if (Dgv_PrintDetails.SelectedRows.Count <= 0) { GeneralFunction.Information("SelectRowtodelete", this.Tag.ToString()); return; }
                    if (GeneralFunction.Question("AlertWantDeleteSelectedRow", this.Tag.ToString()) == DialogResult.Yes)
                    {

                        DataRow[] dr;
                        DataRow[] dr1;
                        dr = GeneralFunction.AddDT.Select("Id=" + Dgv_PrintDetails.SelectedRows[0].Cells["Id"].Value.ToString().Trim() + "");
                        dr1 = GeneralFunction.BarcodeDetails.Select("Id='" + Dgv_PrintDetails.SelectedRows[0].Cells["Id"].Value.ToString().Trim() + "'");
                        int qty;
                        qty = GeneralFunction.AddDT.Rows.IndexOf(dr[0]);

                        int rowcount = GeneralFunction.AddDT.Rows.Count;
                        txtColumn.Text = GeneralFunction.AddDT.Rows[rowcount - 1]["Column"].ToString();
                        txtRow.Text = GeneralFunction.AddDT.Rows[rowcount - 1]["Row"].ToString();

                        int DeleteQty = int.Parse(GeneralFunction.AddDT.Rows[qty]["Quantity"].ToString());
                        string column, row, column1, row1;
                        column = GeneralFunction.AddDT.Rows[qty]["Column"].ToString();
                        row = GeneralFunction.AddDT.Rows[qty]["Row"].ToString();
                        for (int i = qty; i < GeneralFunction.AddDT.Rows.Count - 1; i++)
                        {
                            column1 = GeneralFunction.AddDT.Rows[i + 1]["Column"].ToString();
                            row1 = GeneralFunction.AddDT.Rows[i + 1]["Row"].ToString();
                            GeneralFunction.AddDT.Rows[i + 1]["Column"] = column;
                            GeneralFunction.AddDT.Rows[i + 1]["Row"] = row;
                            column = column1;
                            row = row1;
                        }

                        for (int i = 0; i < dr.Length; i++)
                        {
                            GeneralFunction.AddDT.Rows.Remove(dr[i]);

                        }
                        for (int i = 0; i < dr1.Length; i++)
                        {
                            GeneralFunction.BarcodeDetails.Rows.Remove(dr1[i]);
                        }
                        //DeleteItemCount(dr);
                        if (GeneralFunction.AddDT.Rows.Count <= 0)
                        {
                            Btn_New_Click(sender, e);
                        }
                        else
                        {
                            Txt_Totalqty.Text = Convert.ToString(int.Parse(Txt_Totalqty.Text) - DeleteQty); GeneralFunction.Tempqty = int.Parse(Txt_Totalqty.Text); GeneralFunction.Total = int.Parse(Txt_Totalqty.Text);
                        }
                        if (Txt_Totalqty.Text != string.Empty && int.Parse(Txt_Totalqty.Text) > 0)
                        {
                            Txt_Totalpages.Text = Convert.ToString(Math.Ceiling(Convert.ToDecimal(Txt_Totalqty.Text) / Convert.ToDecimal(objBarPrintHelp.ObjItemCarBAL.Objitemcardobjectclass.pagesize)));
                        }
                        else { Txt_Totalpages.Text = string.Empty; }
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), "Barcode print", "BARCODE", "Delete barcode print details", Convert.ToInt32(InvoiceAction.No));
                    }
                }
                else
                {
                    GeneralFunction.Information("NoItemtoDelete", this.Tag.ToString());
                }


            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnDelete_Click");
            }
        }
        private void Btn_New_Click(object sender, EventArgs e)
        {
            try
            {
                ClearItems();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Btn_New_Click");
            }
        }

        private void ClearItems()
        {


            this.cmbItemName.SelectedIndexChanged -= new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            cmbItemName.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            GeneralFunction.AddDT.Rows.Clear();
            GeneralFunction.BarcodeDetails.Rows.Clear();
            dgrBarcode.Rows.Clear();
            txtStock.Text = string.Empty;
            foreach (System.Windows.Forms.Control ctr in this.Controls)
            {
                string str = Convert.ToString(ctr.GetType());
                if (str == "System.Windows.Forms.TextBox")
                {
                    ctr.Text = string.Empty;
                }
            }
            GeneralFunction.Total = 0;
            GeneralFunction.Tempqty = 0;
            GeneralFunction.Tempqtybarcode = 0;
            chkPrintlogo.Checked = false;
            chkPrintprice.Checked = false;
            radBigPrice.Checked = false;
            radNormalPrice.Checked = false;
            txtQty.Text = "1";
            //  if (BarDt != null) BarDt.Rows.Clear();
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            try
            {
                PrinterDetails();
                this.Close();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "btnClose_Click");

            }
        }

        private void PrinterDetails()
        {
            if (txtQty.Text != string.Empty) GeneralFunction.TxtQty = int.Parse(txtQty.Text); else GeneralFunction.TxtQty = 0;
            if (Txt_Totalqty.Text != string.Empty) GeneralFunction.TotalQty = int.Parse(Txt_Totalqty.Text); else GeneralFunction.TotalQty = 0;
            if (Txt_Totalpages.Text != string.Empty) GeneralFunction.Totalpage = int.Parse(Txt_Totalpages.Text); else GeneralFunction.Totalpage = 0;
            if (txtRow.Text != string.Empty) GeneralFunction.Row = int.Parse(txtRow.Text); else GeneralFunction.Row = 0;
            if (txtColumn.Text != string.Empty) GeneralFunction.Column = int.Parse(txtColumn.Text); else GeneralFunction.Column = 0;
            if (chkPrintlogo.Checked == true) GeneralFunction.Chklogo = true; else GeneralFunction.Chklogo = false;
            if (chkPrintprice.Checked == true) GeneralFunction.Chkprice = true; else GeneralFunction.Chkprice = false;
            if (radBigPrice.Checked == true) GeneralFunction.Bigprice = true; else GeneralFunction.Bigprice = false;
            if (radNormalPrice.Checked == true) GeneralFunction.Normalprice = true; else GeneralFunction.Normalprice = false;
            //GeneralFunction.tempprintbarcodedt = (DataTable)Dgv_PrintDetails.DataSource;

        }

        private void chkPrintprice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                radBigPrice.Visible = radNormalPrice.Visible = radBigPrice.Checked = radNormalPrice.Checked = chkPrintprice.Checked;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "chkPrintprice_CheckedChanged");
            }
        }

        #region Barcode
        #region KeyPress Events
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                //GeneralFunction.Trace("Barcode Start" + ScanValue);
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

        #region Timer Event
        private void Tmr_Barcode_Tick(object sender, EventArgs e)
        {
            try
            {
                ScannerCount += 1;
                if (lastFocusedControl != null)  // Purchase invoice scanning exception throws fixed by Praba on 30-Oct
                {
                    lastFocusedControl.Text = lastfocusedvalue;
                    lastFocusedControl = null;
                }
                if (ScannerCount == 1 && txtBarcode.Text != string.Empty)
                {
                    tmrBarcode.Enabled = false;
                    string barcode = Convert.ToString(txtBarcode.Text);
                    if (barcode.Length < 12)
                    {
                        barcode = ScanValue + barcode;
                    }

                    DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    {
                        cmbItemName.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                        ClearBarcodeValues();
                        txtQty.Text = "1";
                        txtQty.SelectAll();
                        txtQty.Focus();
                       
                    }
                    else
                    {

                        if (UserScreenLimidations.ItemCard == true)
                        {
                            if (GeneralFunction.Question("NotAvailableBarcode", "PurchaseInvoice") == DialogResult.Yes)
                            {
                                ItemCard frmItem = new ItemCard();
                                GeneralFunction.PurchaseBarcode = Convert.ToString(ScanValue + txtBarcode.Text);
                                frmItem.ShowDialog();
                                GeneralFunction.PurchaseBarcode = string.Empty;
                                ClearBarcodeValues();
                            }
                            else
                            {
                                txtBarcode.Text = "";
                                ClearBarcodeValues();
                                cmbItemName.Focus();//Added on 30-June-2014 by Seenivasan for BArcode scanning focus
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("ItemNotRegisteredInformAdmin", "PurchaseInvoice");
                            txtBarcode.Text = "";
                            cmbItemName.Focus();
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

        #region Keyup

        private void Txt_Barcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBarcode.Text != string.Empty)
                {
                    Timercount = 0;
                    tmrBarcode.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Txt_Barcode_KeyUp");
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
        }


        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is Button || ctl is Label || ctl is GroupBox || ctl is CheckBox || ctl is RadioButton)
                            ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                    foreach (Control btn in groupBox1.Controls)
                    {
                        if (btn is Button || btn is Label || btn is GroupBox || btn is CheckBox)
                            btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                }

            }

        }
        #endregion

        private void Barcode_Print_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                PrinterDetails();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), "Barcode_Print_FormClosing");
            }

        }

        private void Barcode_Print_FormClosed(object sender, FormClosedEventArgs e)
        {
            objBarPrintHelp.ObjBarcodeLogo = null;
            BarcodePrintHelper.objPrintGrid = null;
            this.Close();
        }

        private void txtColumn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
