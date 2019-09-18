using System;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.ViewHelper;
using System.Drawing;
using ObjectHelper;
using System.Runtime.InteropServices;
using System.Data;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;

namespace BumedianBM.ArabicView
{
    public partial class Opening_Stock : Form, IDisposable
    {

        #region Initialization
        OpeningStockHelper ObjStockHelper;
        private DateTime ScanLetterStartTime = DateTime.Now;
        private TimeSpan ScanLetterEndTime;
        private string ScanValue = string.Empty;
        private bool ScanTimingCheck = false, iscount = false, isfrominsert = false, IsAfterInsertItem = false;
        private int ScannerCount = 0;
        private Control lastFocusedControl = null;
        private string lastfocusedvalue = "";
        private int KeyboardmaxCount = 0;
        bool IsFormLoad = false;
        private DateTime? localDateTime = DateTime.Now;
        DataTable dtallBarcode;
        #endregion

        #region Constructor
        public Opening_Stock()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjStockHelper = new OpeningStockHelper();
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbSupplierNo.ValueMember = cmbSupplierName.DisplayMember = "Name";
            cmbSupplierNo.DisplayMember = cmbSupplierName.ValueMember = "AgentId";
            cmbItem.DisplayMember = cmbItemNo.ValueMember = "ItemName";
            cmbItem.ValueMember = cmbItemNo.DisplayMember = "ItemNo";
            cmbItemNo.DisplayMember = "ItemNumber";
            cmbItemNo.ValueMember = "ItemNo";

            IsFormLoad = true;

            Loaddetails();

            IsFormLoad = false;
            Hide_TheFromControls();
        }
        #endregion

        #region Events
        #region Changing Event
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbItem.Text != string.Empty && cmbItem.SelectedIndex > -1) && IsFormLoad != true)
            {
                //            if (cmbItem.SelectedIndex > 0)
                //{
                //  cmbItemNo.Text  = cmbItem.SelectedValue.ToString();
                // cmbItemNo.SelectedValue = cmbItem.SelectedValue.ToString();
                this.SetObjectFromControl();
                ObjStockHelper.ItemNameSelectedIndexChange();
                if (ObjStockHelper.ObjBALClass.ObjStock.ExpiryDate == true)
                {
                    dtpExpiry.Enabled = true;
                    ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = localDateTime.Value;
                }
                else
                {
                    dtpExpiry.Enabled = false;
                    dtpExpiry.Value = localDateTime.Value;
                }
                this.SetControlFromObject();
                txtQuantity.Text = "1";
                btnBoxF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                ObjStockHelper.HighligntText(dgvInventory);
                ObjStockHelper.isPackage = false;
                if (ObjStockHelper.PackageQty.Count > 0)
                {
                    txtBox.DataSource = null;
                    txtBox.DisplayMember = "ItemPackage";
                    txtBox.ValueMember = "BarcodeID";
                    txtBox.BindingContext = new BindingContext();
                    txtBox.DataSource = ObjStockHelper.PackageQty.Select(a => a.ItemPackage).Distinct().ToList();
                }
                HighLightItem();
                txtCost.Focus();
                txtCost.SelectAll();
            }

        }

        private void cmbItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cmbItem.SelectedValue = cmbItemNo.SelectedIndex > -1 ? cmbItemNo.SelectedValue.ToString() : string.Empty;
            if (cmbItemNo.SelectedIndex >-1 && IsFormLoad != true)
            {
                //cmbItemNo.Text = string.Empty;
                int value = Convert.ToInt32(cmbItemNo.SelectedValue);
                cmbItem.SelectedValue = value;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjStockHelper.ObjBALClass.ObjStock.CategoryNo = cmbCategory.SelectedIndex != -1 ? Convert.ToInt32(cmbCategory.SelectedValue) : 0;
            ObjStockHelper.ObjBALClass.ObjStock.CompanyNo = cmbCompany.SelectedIndex != -1 ? Convert.ToInt32(cmbCompany.SelectedValue) : 0;
            if (ObjStockHelper.ObjBALClass.ObjStock.CompanyNo == Convert.ToInt32(CompanyId.Value) && ObjStockHelper.ObjBALClass.ObjStock.CategoryNo == Convert.ToInt32(CategoryId.Value)) //  1001 to 1001 is changed due to default records are changed to 1001 for category and company id. Done by Manoj On June-24
            {
                AssignItemSource();
                //cmbItem.DataSource =ObjStockHelper.ItemList.Where(i => i.IsHide == false).ToList();
                //cmbItemNo.DataSource =ObjStockHelper.ItemList.Where(a => ((a.ItemNumber != string.Empty) & (a.IsHide == false))).ToList();
            }
            else
            {

                DataTable dt = ObjStockHelper.FilterItemUsingComCat();
                DataView dvfilted = new DataView(dt);
                dvfilted.RowFilter = "ItemNumber<>''";
                cmbItem.DataSource = dt; //ObjStockHelper.FilterItem.Where(i => i.IsHide == false).ToList(); ;
                cmbItemNo.DataSource = dvfilted.ToTable(); //ObjStockHelper.FilterItem.Where(a => ((a.ItemNumber != string.Empty) & (a.IsHide == false))).ToList();
            }
        }

        private void chkwithsupplier_CheckStateChanged(object sender, EventArgs e)
        {
            btnPayRecipt.Enabled = lblSupName.Enabled = lblSupName.Enabled = lblSupno.Enabled = cmbSupplierName.Enabled = cmbSupplierNo.Enabled = chkwithsupplier.Checked == true ? true : false;
            if (!chkwithsupplier.Checked)

                cmbSupplierNo.SelectedIndex = cmbSupplierName.SelectedIndex = -1;
        }

        #endregion

        #region Load Event
        private void Opening_Stock_Load(object sender, EventArgs e)
        {
            //// ComCatList(); 

            //objOpeningStockHelper.GridContent();
            //FillGrid();
            ////  objOpeningStockHelper.GetControlDetails();

            //objOpeningStockHelper.ComCatList();

            //FillCatDetails();

            //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpExpiry.Format = DateTimePickerFormat.Custom;

            dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpExpiry.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//

            cmbItem.Focus();
            chkwithsupplier_CheckStateChanged(sender, e);

            dtallBarcode = new DataTable();
            dtallBarcode = GeneralFunction.GetAllBarcode();
            ////     txtBox.Text = "0";
        }
        #endregion

        #region Button Event
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ObjStockHelper.btnPrint();
        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard frmItem = new ItemCard();
            frmItem.ShowDialog();
            ObjStockHelper.SetItemDetailsToList();
            cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);
            AssignItemSource();
            cmbItem.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
            //AssignNewItemSource();
            frmItem = null;

        }

        private void AssignNewItemSource()
        {
            cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);
            ObjStockHelper.SetItemDetailsToList();
            cmbItem.DataSource = ObjStockHelper.ItemList.Where(i => i.IsHide == false).ToList();
            cmbItemNo.DataSource = ObjStockHelper.ItemList.Where(i => ((i.ItemNumber != string.Empty) & (i.IsHide == false))).ToList();
            cmbItem.SelectedIndex = -1;
            cmbItemNo.SelectedIndex = -1;
            cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
            dtallBarcode = GeneralFunction.GetAllBarcode();
        }

        private void btnBoxF9_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.Text = (txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0";
                if (ObjStockHelper.isPackage == false)
                {
                    this.SetObjectFromControl();
                    ObjStockHelper.BoxPieceAction();
                    btnBoxF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Piece");
                    ObjStockHelper.isPackage = true;
                    this.SetControlFromObject();
                }
                else
                {
                    this.SetObjectFromControl();
                    ObjStockHelper.BoxPieceAction();
                    btnBoxF9.Text = GeneralFunction.ChangeLanguageforCustomMsg("Box");
                    ObjStockHelper.isPackage = false;
                    this.SetControlFromObject();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInsertItem_Click(object sender, EventArgs e)
        {
            if (dgvInventory.BackgroundColor != Color.Gray)
            {
                this.SetObjectFromControl();
                if (cmbItem.SelectedIndex > -1)
                    ObjStockHelper.btnInsertInvoice();
                if (ObjStockHelper.ProgressStatus)
                {
                    ObjStockHelper.AssignDataSource(dgvInventory);
                    this.ClearControls();
                    txtTotalValue.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemTotal.ToString();
                    ObjStockHelper.ProgressStatus = false;
                    isfrominsert = true;
                    cmbItem.Focus();
                    isfrominsert = false;
                    IsAfterInsertItem = true;
                }
                else
                {
                    if (ObjStockHelper.ControlName != null && ObjStockHelper.ControlName != String.Empty)
                    {
                        foreach (Control ctl in panel1.Controls)
                        {
                            if (ctl is TableLayoutPanel)
                            {
                                foreach (Control c in tableLayoutPanel2.Controls)
                                {
                                    if (c.Name == ObjStockHelper.ControlName)
                                        c.Focus();
                                }
                            }
                            else
                            {
                                if (ctl.Name == ObjStockHelper.ControlName)
                                    ctl.Focus();
                            }
                        }
                        ObjStockHelper.ControlName = string.Empty;
                    }
                }
            }
            else
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("CantInsertafterClosingInvoice"), this.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    ObjStockHelper.btnSaveInventory();
                    if (ObjStockHelper.ProgressStatus)
                    {
                        DataGridStatus();
                        ObjStockHelper.ProgressStatus = false;
                        chkwithsupplier.Enabled = false;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), "OpeningStock", "Inventory", "Save openning stock details", Convert.ToInt32(InvoiceAction.Yes));
                        cmbItem.Focus();
                        // txtDescription.Text = string.Empty;
                    }
                    else
                    {
                        if (ObjStockHelper.ControlName != null && ObjStockHelper.ControlName != String.Empty)
                        {
                            foreach (Control ctl in panel1.Controls)
                            {
                                if (ctl.Name == ObjStockHelper.ControlName)
                                    ctl.Focus();
                            }
                            ObjStockHelper.ControlName = string.Empty;
                        }
                    }
                }
                else { GeneralFunction.Information("AlreadySavedItemDetails", this.Text); }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.BackgroundColor == Color.Gray)
                {
                    if (GeneralFunction.Question("AlertInventoryAdj", ActionType.Confirmation.ToString()) == DialogResult.Yes)
                    {
                        if (ObjStockHelper.btnModifyInvoice())
                        {
                            DataGridStatus();
                            chkwithsupplier.Enabled = true;
                            chkwithsupplier.Checked = false;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Modify), "Opening Stock", "Inventory", "Modify openning stock details", Convert.ToInt32(InvoiceAction.Yes));
                        }
                    }
                    else
                        return;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UndoDelete();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Undo), ObjStockHelper.ObjBALClass.ObjStock.ItemName + " " + "Qty-" +
            ObjStockHelper.ObjBALClass.ObjStock.ItemQuantity, "Opening Stock", "Undo Opening Stock invoice details", Convert.ToInt32(InvoiceAction.Yes));
        }

        private void UndoDelete()
        {
            try
            {
                if (dgvInventory.BackgroundColor != Color.Gray)
                {
                    this.SetObjectFromControl();
                    if (dgvInventory.SelectedRows.Count > 0)
                    {
                        if (GeneralFunction.Question("AlertDeleteSelectedRow", ActionType.Confirmation.ToString()) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dgvInventory.SelectedRows.Count; i++)
                            {
                                ObjStockHelper.ObjBALClass.ObjStock.ItemNo = Convert.ToInt32(dgvInventory.SelectedRows[i].Cells["ItemNo"].Value);
                                ObjStockHelper.ObjBALClass.ObjStock.ItemQuantity = Convert.ToInt32(dgvInventory.SelectedRows[i].Cells["Quantity"].Value);
                                // ObjStockHelper.ObjBALClass.ObjStock.ItemSerialNo = Convert.ToInt64(dgvInventory.SelectedRows[i].Cells["SerialNo"].Value);
                                ObjStockHelper.ObjBALClass.ObjStock.ItemSerialNo = dgvInventory.SelectedRows[i].Cells["SerialNo"].Value.ToString();
                                if (dgvInventory.SelectedRows[i].Cells["ExpiryDate"].Value.ToString() == "-")
                                    ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = null;
                                else
                                    //ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = DateTime.Parse(dgvInventory.SelectedRows[i].Cells["ExpiryDate"].Value.ToString());//Commented on 2-June-14 for Date Format Issues
                                    ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = Convert.ToDateTime(dgvInventory.SelectedRows[i].Cells["ExpiryDate"].Value);
                                ObjStockHelper.ObjBALClass.ObjStock.ItemUnitPrice = Convert.ToDecimal(dgvInventory.SelectedRows[i].Cells["UnitPrice"].Value);
                                ObjStockHelper.ObjBALClass.ObjStock.BarcodeID = Convert.ToInt32(dgvInventory.SelectedRows[i].Cells["BarcodeID"].Value);
                                ObjStockHelper.btnUndoInventory();
                            }
                            if (ObjStockHelper.ProgressStatus)
                            {
                                ObjStockHelper.AssignDataSource(dgvInventory);
                                txtTotalValue.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemTotal.ToString();
                            }
                        }
                    }
                    else
                    { GeneralFunction.Information("NoItemtoDelete.", ActionType.Delete.ToString()); }

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
                if (ObjStockHelper.ObjItemInfo.Visible == false)
                {
                    if (cmbItem.Text != string.Empty && cmbItem.Text != null)
                    {
                        ObjStockHelper.ObjItemInfo.ItemNo = Convert.ToInt16(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
                        ObjStockHelper.ObjItemInfo.ItemName = cmbItem.Text;
                        ObjStockHelper.ObjItemInfo.ShowDialog();
                    }
                    else
                    {
                        if (dgvInventory.SelectedRows.Count > 0)
                        {
                            ObjStockHelper.ObjItemInfo.ItemNo = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ItemNo"].Value);
                            ObjStockHelper.ObjItemInfo.ItemName = dgvInventory.SelectedRows[0].Cells["ItemName"].Value.ToString();
                            ObjStockHelper.ObjItemInfo.ShowDialog();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UndoDelete();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjStockHelper.ObjBALClass.ObjStock.ItemName + " " + "Qty-" +
            ObjStockHelper.ObjBALClass.ObjStock.ItemQuantity + " " + "InvNo-" + ObjStockHelper.ObjBALClass.ObjStock.InvoiceNo.ToString(), "Opening Stock", "Delete Opening Stock invoice details", Convert.ToInt32(InvoiceAction.Yes));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.Rows.Count != 0)
                {
                    ObjStockHelper.datatable = (System.Data.DataTable)dgvInventory.DataSource;
                    ObjStockHelper.btnExport();
                }

            }
            catch (COMException ce)
            {
                GeneralFunction.ErrInfo(ce.Message + GeneralFunction.ChangeLanguageforCustomMsg("CloseOpenedFile"), "OpeningStock");
            }
        }

        private void TStrip_Btn_Delete_Click(object sender, EventArgs e)
        {
            if (dgvInventory.BackgroundColor.Name != "Gray")
            {
                InvokeOnClick(btnUndo, EventArgs.Empty);
            }
        }

        private void btnPayRecipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventory.BackgroundColor.Name == "Gray")
                {
                    this.SetObjectFromControl();
                    ObjStockHelper.btnPayReceipt();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                Report frmReport = new Report();
                frmReport.ShowDialog();
                frmReport = null;
            }
            catch (Exception ex)
            { GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Opening Stock", "btnReports_Click"); }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region DataGrid Event
        private void dgvInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                ObjStockHelper.ObjBALClass.ObjStock.ItemNo = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["ItemNo"].Value);
                ObjStockHelper.ObjBALClass.ObjStock.ItemName = dgvInventory.SelectedRows[0].Cells["ItemName"].Value.ToString();
                ObjStockHelper.GridCellDoubleClick();
            }
        }
        #endregion

        #region Key Event
        private void opening_stock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F11 && btnItemInformation.Enabled == true)
                {
                    InvokeOnClick(btnItemInformation, EventArgs.Empty);
                }
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information frmQuick = new Quick_Price_Information();
                    frmQuick.ShowDialog();
                    frmQuick = null;
                }
                if (e.KeyCode == Keys.F8)
                {
                    Pay_Receipt frmPay = new Pay_Receipt();
                    frmPay.ShowDialog();
                    frmPay = null;
                }

                if (e.KeyCode == Keys.F9)
                {
                    this.InvokeOnClick(btnBoxF9, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F6)
                {
                    this.InvokeOnClick(btnInsertItem, EventArgs.Empty);
                }
                if (e.KeyCode == Keys.F8 && btnPayRecipt.Enabled)
                {
                    btnPayRecipt_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodInfo.GetCurrentMethod().Name);
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string str = ((MaskedTextBox)sender).Name;
                switch (str)
                {
                    case "txtCost":
                        if (GeneralOptionSetting.FlagTabToPrice == "Y")
                        {
                            txtPrice.SelectAll();
                            txtPrice.Focus();
                        }
                        else
                        {
                            txtQuantity.SelectAll();
                            txtQuantity.Focus();
                        }
                        break;
                    case "txtPrice":
                        if (e.KeyChar == 13)
                        {
                            txtQuantity.SelectAll();
                            txtQuantity.Focus();
                        }
                        break;
                    case "txtQuantity":
                        if (dtpExpiry.Enabled == true)
                        {
                            dtpExpiry.Focus();
                            dtpExpiry.Select();
                        }
                        else
                        {
                            InvokeOnClick(btnInsertItem, EventArgs.Empty);
                        }
                        break;
                }
            }
            else
            {
                //if ((((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true) || !(Char.IsDigit(e.KeyChar)))
                //{
                //    GeneralFunction.Information("OnlyNumbersAllowed", ActionType.Information.ToString());
                //    e.Handled = true;
                //}
                if (((MaskedTextBox)sender).Name != "txtQuantity")
                {
                    if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)ConsoleKey.Backspace) && (e.KeyChar != (char)ConsoleKey.Delete))
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == 46 && (((MaskedTextBox)sender).Text.Contains('.')))
                        e.Handled = true;
                }
                else if (((MaskedTextBox)sender).Name == "txtQuantity")
                {
                    if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)ConsoleKey.Backspace) && (e.KeyChar != (char)ConsoleKey.Delete) || (txtQuantity.Text.Length > 8) || e.KeyChar == 46)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // txtCost.SelectAll();
                //txtCost.Focus();
                btnInsertItem.Focus();
            }
        }

        private void dtpExpiry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                InvokeOnClick(btnInsertItem, EventArgs.Empty);
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if ((cmbItem.Text != string.Empty) && (cmbItem.SelectedIndex > -1))
            {
                if (ObjStockHelper.isPackage == false)
                {
                    txtStock.Text = ((int.Parse(txtQuantity.Text != string.Empty ? txtQuantity.Text : "0")) + (ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock / (ObjStockHelper.ObjBALClass.ObjStock.ItemPackage != 0 ? ObjStockHelper.ObjBALClass.ObjStock.ItemPackage : 1))).ToString();
                }
                else
                {
                    txtStock.Text = Convert.ToString(int.Parse((txtQuantity.Text != string.Empty) ? txtQuantity.Text : "0") + int.Parse((ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock).ToString()));
                }
            }
        }
        bool isFirst = false;
        string appval = "";
        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            ///((ComboBox)sender).DroppedDown = true; //This is added due to avoid one more window when entering text in itemname. Done By Manoj on June 24 this line Commended By meena.R to fix the Drop Down issue
            string str = ((ComboBox)sender).Name;
            //if (e.KeyValue == 38 || e.KeyValue == 40)
            //    iscount = true;
            if (e.KeyValue == 13)
            {
                switch (str)
                {
                    case "cmbItem":
                        //if (e.KeyValue == 13)
                        //    IsAfterInsertItem = false;
                        //    //SendKeys.Send("{TAB}");
                        //    cmbItem.AutoCompleteMode = AutoCompleteMode.None;
                        //    txtBarcode.Focus();
                        //    txtCost.SelectAll();
                        //    txtCost.Focus();
                        break;
                    case "cmbItemNo":
                        txtCost.SelectAll();
                        txtCost.Focus();
                        break;
                    case "cmbSupplierNo":
                        cmbItem.Focus();
                        break;
                    case "cmbSupplierName":
                        cmbItem.Focus();
                        break;
                }
            }
            //else if (((int)e.KeyValue != 13) && (e.KeyCode != Keys.Tab) && (e.KeyCode != Keys.Escape) &&
            //        (e.KeyValue != 18) && (e.KeyCode != Keys.Up) && (e.KeyCode != Keys.Down) && (e.KeyCode != Keys.Right)
            //        && (e.KeyCode != Keys.Left) && (e.KeyCode != Keys.End) && (e.KeyCode != Keys.Home) && (e.KeyValue < 111 || e.KeyValue > 126) && (e.KeyCode != Keys.Space) && (e.KeyCode != Keys.ShiftKey)
            //        && (e.KeyCode != Keys.Shift) && (e.KeyCode != Keys.Delete) && (e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Control)
            //        && (e.KeyCode != Keys.ControlKey) && (e.KeyCode != Keys.CapsLock) && (e.KeyCode != Keys.LWin) && (e.KeyCode != Keys.RWin))
            //{
            //    if (((ComboBox)sender).DataSource != null)
            //    {
            //        if (((ComboBox)sender).DroppedDown == true)
            //            ((ComboBox)sender).DroppedDown = false;
            //        if (((ComboBox)sender).Name == "cmbItem" && cmbItem.AutoCompleteMode != AutoCompleteMode.SuggestAppend)
            //        {
            //            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //            cmbItem.SelectedText = ((char)e.KeyValue).ToString();
            //            cmbItem.DroppedDown = true;
            //            isFirst = true;
            //            appval = ((char)e.KeyValue).ToString();

            //        }
            //        else
            //        {
            //            cmbItem.DroppedDown = false;
            //            if (isFirst)
            //            {
            //                cmbItem.SelectedText = appval.Substring(0, 1);
            //                isFirst = false;
            //            }

            //        }
            //    }

            //}
        }
        private void cmbSupplierNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string name = ((ComboBox)sender).Name;
                switch (name)
                {
                    case "cmbSupplierNo":
                        if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back))
                        {
                            GeneralFunction.Information("OnlyNumbersAllowed", ActionType.Information.ToString());
                            e.Handled = true;
                        }
                        break;
                    case "cmbItemNo":
                        if ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false) && (e.KeyChar != (char)Keys.Delete))
                        {
                            GeneralFunction.Information("OnlyNumbersAllowed", ActionType.Information.ToString());
                            e.Handled = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Leave Event
        private void txtCost_Leave(object sender, EventArgs e)
        {
            string str = ((MaskedTextBox)sender).Name;
            switch (str)
            {
                case "txtCost":
                    if (txtCost.Text != string.Empty && cmbItem.SelectedIndex > -1)
                    {
                        Decimal decCost = Decimal.Parse(txtCost.Text);
                        Decimal decPrice = Decimal.Parse(txtPrice.Text);
                        if (decCost > decPrice)
                        {
                            // if (GeneralFunction.Information("LessthanSellingPricethanCost", ActionType.Information.ToString()) == DialogResult.Yes)
                            GeneralFunction.Information("LessthanSellingPricethanCost", ActionType.Information.ToString());
                            if (GeneralFunction.Question("Doyouwanttocontinue", ActionType.Confirmation.ToString()) == DialogResult.Yes)
                            {
                                // ItemCard frmform = new ItemCard();
                                //frmform.ShowDialog();
                                txtPrice.SelectAll();
                                txtPrice.Focus();
                            }
                            else
                            {
                                txtCost.SelectAll();
                                txtCost.Focus();
                            }
                        }
                        else
                        { txtCost.Text = (Math.Truncate(decCost * 1000m) / 1000m).ToString("######0.000"); }
                    }
                    break;
                case "txtPrice":
                    if (txtPrice.Text != string.Empty)
                    {
                        decimal decPrice = Convert.ToDecimal(txtPrice.Text);
                        txtPrice.Text = (Math.Truncate(decPrice * 1000m) / 1000m).ToString("######0.000");
                    }
                    break;
            }
        }
        #endregion
        #endregion

        #region Method
        public void SetLanguage()
        {
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit") + "        ";
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard") + "        ";
            btnItemInformation.Text = Additional_Barcode.GetValueByResourceKey("ItemInfoF11") + "        ";
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print") + "        ";
            btnReports.Text = Additional_Barcode.GetValueByResourceKey("Report") + "        ";
            this.Text = Additional_Barcode.GetValueByResourceKey("OpeningStock");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblTime.Text = Additional_Barcode.GetValueByResourceKey("Time");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblItemNo.Text = Additional_Barcode.GetValueByResourceKey("ItemNo");
            btnExport.Text = Additional_Barcode.GetValueByResourceKey("Export") + "       ";
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("ModifyInvoice") + "        ";
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save") + "        ";
            btnUndo.Text = Additional_Barcode.GetValueByResourceKey("Undo") + "        ";
            chkwithsupplier.Text = Additional_Barcode.GetValueByResourceKey("WithSup");
            btnBoxF9.Text = Additional_Barcode.GetValueByResourceKey("BoxF9") + "     ";
            btnInsertItem.Text = Additional_Barcode.GetValueByResourceKey("InsertItemF6") + "        ";
            lblCost.Text = Additional_Barcode.GetValueByResourceKey("Cost");
            lblExpiry.Text = Additional_Barcode.GetValueByResourceKey("Expiry");
            lblStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblPrice.Text = Additional_Barcode.GetValueByResourceKey("Price");
            lblQty.Text = Additional_Barcode.GetValueByResourceKey("Qty");
            lblTotalValue.Text = Additional_Barcode.GetValueByResourceKey("TValue");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete") + "        ";
            lblSupName.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            lblSupno.Text = Additional_Barcode.GetValueByResourceKey("SupplierNo");
            btnPayRecipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceiptF8");
            dgvInventory.Columns["ItemName"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemName");
            dgvInventory.Columns["ExpiryDate"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvInventory.Columns["Package"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvInventory.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgvInventory.Columns["UnitPrice"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitPrice");
            dgvInventory.Columns["Total"].HeaderText = Additional_Barcode.GetValueByResourceKey("Total");
            dgvInventory.Columns["SerialNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("SerialNo");
            dgvInventory.Columns["Box"].HeaderText = Additional_Barcode.GetValueByResourceKey("Box");
            dgvInventory.Columns["Time"].HeaderText = Additional_Barcode.GetValueByResourceKey("Time");
            dgvInventory.Columns["User"].HeaderText = Additional_Barcode.GetValueByResourceKey("User");
            dgvInventory.Columns["ItemPrice"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemPrice");
            dgvInventory.Columns["ItemId"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvInventory.Columns["Cost"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemCost");
            dgvInventory.Columns["Description"].HeaderText = Additional_Barcode.GetValueByResourceKey("Description");
        }

        private void Loaddetails()
        {
            cmbCategory.DataSource = GeneralObjectClass.CategoryList;
            if (GeneralObjectClass.CategoryList.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
               // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
            }
            cmbCompany.DataSource = GeneralObjectClass.CompanyList;
            if (GeneralObjectClass.CategoryList.Count > 0)
            {
                cmbCompany.SelectedIndex = 0;
               // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            }
            cmbSupplierNo.DataSource = cmbSupplierName.DataSource = GeneralObjectClass.SupplierDetails;
            cmbSupplierNo.SelectedIndex = cmbSupplierName.SelectedIndex = -1;
            //cmbItem.DataSource = ObjStockHelper.ItemList.Where(i => i.IsHide == false).ToList();
            AssignItemSource();
            cmbItemNo.SelectedIndex = -1;
            cmbItem.SelectedIndex = -1;
            cmbCategory.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbItem.SelectedIndexChanged += new EventHandler(cmbItem_SelectedIndexChanged);
            ObjStockHelper.SetDataGridData();
            ObjStockHelper.AssignDataSource(dgvInventory);
            DataGridStatus();
            this.SetControlFromObject();
            dgvInventory.CellDoubleClick += new DataGridViewCellEventHandler(dgvInventory_CellDoubleClick);
            cmbItemNo.SelectedIndexChanged += new EventHandler(cmbItemNo_SelectedIndexChanged);
            cmbSupplierNo.SelectedIndexChanged += new EventHandler(cmbSupplierNo_SelectedIndexChanged);
            cmbSupplierName.SelectedIndexChanged += new EventHandler(cmbSupplierName_SelectedIndexChanged);
            ScanValue = "0";
            ScanTimingCheck = true;
            ScanLetterStartTime = DateTime.Now;
        }

        private void AssignItemSource()
        {
            cmbItem.DataSource = ObjStockHelper.ItemDetails;
            DataView dvfilter = new DataView(ObjStockHelper.ItemDetails);
            dvfilter.RowFilter = "ItemNumber<>''";
            //cmbItemNo.DataSource = ObjStockHelper.ItemList.Where(i => ((i.ItemNumber != string.Empty) & (i.IsHide == false))).ToList();
            cmbItemNo.DataSource = dvfilter.ToTable();
        }

        void cmbSupplierNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplierNo.SelectedIndex > -1)
                cmbSupplierName.Text = cmbSupplierNo.SelectedValue.ToString();

        }
        void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplierName.SelectedIndex > -1)
                cmbSupplierNo.Text = cmbSupplierName.SelectedValue.ToString();
        }
        private void SetObjectFromControl()
        {
            ObjStockHelper.ObjBALClass.ObjStock.ItemName = cmbItem.Text.ToString();
            // ObjStockHelper.ObjBALClass.ObjStock.ItemNo = Convert.ToInt32(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
            ObjStockHelper.ObjBALClass.ObjStock.ItemNo = Convert.ToInt32(cmbItem.SelectedValue == null ? "0" : cmbItem.SelectedValue);
            ObjStockHelper.ObjBALClass.ObjStock.SupplierName = cmbSupplierName.Text.ToString();
            ObjStockHelper.ObjBALClass.ObjStock.SupplierNo = Convert.ToInt32(cmbSupplierNo.Text == string.Empty ? "0" : cmbSupplierNo.Text);
            ObjStockHelper.chkSupplier = chkwithsupplier.Checked == true ? true : false;
            ObjStockHelper.ObjBALClass.ObjStock.CategoryNo = cmbCategory.SelectedIndex != -1 ? Convert.ToInt32(cmbCategory.SelectedValue) : 0;
            ObjStockHelper.ObjBALClass.ObjStock.CompanyNo = cmbCompany.SelectedIndex != -1 ? Convert.ToInt32(cmbCompany.SelectedValue) : 0;
            ObjStockHelper.ObjBALClass.ObjStock.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty ? "0" : txtCost.Text);
            if (ObjStockHelper.ObjBALClass.ObjStock.ItemType == 1)
            {
                localDateTime = ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = (Convert.ToDateTime(dtpExpiry.Value)).Date;
                ObjStockHelper.ObjBALClass.ObjStock.ItemExpiry = dtpExpiry.Value.ToShortDateString();
            }
            else
            {
                ObjStockHelper.ObjBALClass.ObjStock.ItemExpiryDate = null;
                ObjStockHelper.ObjBALClass.ObjStock.ItemExpiry = null;
            }
            ObjStockHelper.ObjBALClass.ObjStock.ItemQuantity = Convert.ToInt32(txtQuantity.Text == string.Empty ? "0" : txtQuantity.Text);
            ObjStockHelper.ObjBALClass.ObjStock.ItemStock = Convert.ToInt32(txtStock.Text == String.Empty ? "0" : txtStock.Text);
            ObjStockHelper.ObjBALClass.ObjStock.ItemPrice = Convert.ToDecimal(txtPrice.Text == String.Empty ? "0" : txtPrice.Text);
            ObjStockHelper.ObjBALClass.ObjStock.ItemPackage = txtBox.Text == string.Empty ? 0 : Convert.ToInt32(txtBox.Text);
            ObjStockHelper.ObjBALClass.ObjStock.ItemDescription = txtDescription.Text;
            ObjStockHelper.ObjBALClass.ObjStock.Note = txtNotes.Text;
            ObjStockHelper.ObjBALClass.ObjStock.ProcessDate = dtpDate.Value.Date;
            ObjStockHelper.ObjBALClass.ObjStock.ItemNumber = cmbItemNo.Text.ToString();
            if (ObjStockHelper.isPackage == false)
            {
                ObjStockHelper.ItemCost = Convert.ToDecimal(txtCost.Text == string.Empty ? "0" : txtCost.Text);
                //ObjHelper.ItemUnitPrice = 0.000m;
            }
            else
            {
                ObjStockHelper.ItemUnitPrice = Convert.ToDecimal(txtCost.Text);
                // ObjHelper.ItemCost = 0.000m;
            }
            //added on 05 may 2014
            //  ObjStockHelper.ObjBALClass.ObjStock.BarcodeID = txtBox.SelectedIndex != -1 ? Convert.ToInt32(txtBox.SelectedValue):0;
        }

        private void SetControlFromObject()
        {
            // cmbItemNo.SelectedValue = ObjStockHelper.ObjBALClass.ObjStock.ItemNo == null ? 0 : ObjStockHelper.ObjBALClass.ObjStock.ItemNo;
            cmbItemNo.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemNumber == null ? string.Empty : ObjStockHelper.ObjBALClass.ObjStock.ItemNumber;
            cmbItem.SelectedValue = ObjStockHelper.ObjBALClass.ObjStock.ItemNo == null ? 0 : ObjStockHelper.ObjBALClass.ObjStock.ItemNo;
            cmbSupplierName.Text = ObjStockHelper.ObjBALClass.ObjStock.SupplierName == null ? string.Empty : ObjStockHelper.ObjBALClass.ObjStock.SupplierName;
            cmbSupplierNo.Text = ObjStockHelper.ObjBALClass.ObjStock.SupplierNo.ToString() == string.Empty ? "0" : ObjStockHelper.ObjBALClass.ObjStock.SupplierNo == 0 ? string.Empty : ObjStockHelper.ObjBALClass.ObjStock.SupplierNo.ToString();
            txtCost.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemCost.ToString("#####0.000");
            txtQuantity.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemQuantity.ToString();
            txtStock.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemStock.ToString();
            PriceValue();
            //txtPrice.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemPrice.ToString("#####0.000");
            txtBox.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemPackage.ToString();
            // cmbItemNo.Text = string.Empty;

            txtTotalValue.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemTotal.ToString("#####0.000");
            //if (IsFormLoad == true)
            //{ txtDescription.Text = string.Empty; }

            //else { txtDescription.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemDescription; }//Commended to show the Description On 28/04/2014
            txtDescription.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemDescription;
            txtNotes.Text = ObjStockHelper.ObjBALClass.ObjStock.Note;
        }

        private void ClearControls()
        {
            try
            {
                txtCost.Text = "0.000";
                txtPrice.Text = "0.000";
                txtQuantity.Text = "1";
                txtStock.Text = "0";
                //dtpExpiry.Text = Convert.ToString(DateTime.Now.Date);
                dtpExpiry.Value = localDateTime.Value;
                txtNotes.Text = "";
                //txtBox.Text = "0";
                txtBox.DataSource = null;
                // txtDescription.Text = "";Commanded on 23-05-2014 to fix the description cant delete
                txtBarcode.Text = "";
                cmbItemNo.SelectedIndex = -1;
                cmbItem.SelectedIndex = -1;
            }
            catch (Exception ex) { throw ex; }
        }

        private void DataGridStatus()
        {
            if (ObjStockHelper.ObjBALClass.ObjStock.Status == 2)
            {
                dgvInventory.BackgroundColor = Color.Gray;
                dgvInventory.DefaultCellStyle.BackColor = Color.Gainsboro;
            }
            else
            {
                //dgvInventory.BackgroundColor = Color.Beige;''Commented on 27 Feb 2017 based on client requirements to change the color on the grid
                dgvInventory.BackgroundColor = Color.WhiteSmoke; 
                dgvInventory.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void Hide_TheFromControls()
        {
            lblItemNo.Visible = cmbItemNo.Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            btnBoxF9.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            txtBox.Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dtpExpiry.Visible = dgvInventory.Columns["ExpiryDate"].Visible = lblExpiry.Visible = (GeneralOptionSetting.FlagPurchase_HideExpiryFiled == "Y") ? false : true;
            dgvInventory.Columns["Package"].Visible = (GeneralOptionSetting.FlagHidePackageQuantity == "Y") ? false : true;
            dgvInventory.Columns["ItemId"].Visible = GeneralOptionSetting.FlagHideItemNumber == "Y" ? false : true;
            btnItemCard.Enabled = UserScreenLimidations.ItemCard == true ? true : false;
            btnPrint.Enabled = UserScreenLimidations.Print == true ? true : false;
            btnExport.Enabled = UserScreenLimidations.Export;
            btnItemInformation.Enabled = UserScreenLimidations.ItemInfo;
            btnReports.Enabled = UserScreenLimidations.Reports;
            btnDelete.Enabled = UserScreenLimidations.DeleteItem;
        }
        #endregion

        #region Barcode
        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tmrBarcode.Enabled == false)  //Performance fine tune by praba on 20-Nov
                {
                    tmrBarcode.Enabled = true;
                }
                //if (e.KeyValue == 13)
                //    txtCost.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void Timer_In_Tick(object sender, EventArgs e)
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
        //            if (ScanValue != "" & ScanValue.Length > 1 && txtBarcode.Text.Trim().Length != 13)
        //            {
        //                barcode = ScanValue + barcode;
        //            }
        //            DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
        //            if (dtBarcode != null && dtBarcode.Rows.Count > 0)
        //            {
        //                cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
        //                txtBox.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
        //                //SelectItem(Cmb_Item.Text.Trim());
        //                txtCost.Focus();
        //                ClearBarcodeValues();
        //            }
        //            else
        //            {
        //                if (GeneralFunction.Question("NotAvailableBarcode", ActionType.Confirmation.ToString()) == DialogResult.Yes)
        //                {
        //                    ItemCard frmItem = new ItemCard();
        //                    GeneralFunction.PurchaseBarcode = ScanValue + txtBarcode.Text.Trim();
        //                    frmItem.ShowDialog();
        //                    // FillItemComboBoxList_Item();
        //                    GeneralFunction.PurchaseBarcode = string.Empty;
        //                    ClearBarcodeValues();
        //                }
        //                else
        //                {
        //                    txtBarcode.Text = string.Empty;
        //                    ClearBarcodeValues();
        //                    //ClearDefaultValue();
        //                    //DefaultValue();
        //                }
        //            }
        //        }
        //        else if (ScannerCount > 1)
        //        {
        //            tmrBarcode.Enabled = false;
        //            ClearBarcodeValues();
        //            //ClearDefaultValue();
        //        }
        //        KeyboardmaxCount = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        tmrBarcode.Enabled = false;
        //        ClearBarcodeValues();
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Inventory(Opening_Stock)", "Timer_In_Tick");
        //        //throw ex;
        //    }
        //}


        private void Timer_In_Tick(object sender, EventArgs e)
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

                    //Performance fine tune by praba on 20-Nov
                    ////DataTable dtBarcode = GeneralFunction.GetBarcode(barcode.Trim());
                    //if (dtBarcode != null && dtBarcode.Rows.Count > 0)
                    //{
                    //    cmbItem.Text = dtBarcode.Rows[0]["ItemName"].ToString();
                    //    txtBox.Text = (dtBarcode.Rows[0]["PackageQty"]).ToString();
                    //    //SelectItem(Cmb_Item.Text.Trim());
                    //    txtCost.Focus();
                    //    ClearBarcodeValues();
                    //}

                    //Performance fine tune by praba on 20-Nov
                    DataRow[] DRBarcode = dtallBarcode.Select("Barcode='" + barcode.Trim() + "'");

                    if (DRBarcode != null && DRBarcode.Count() > 0)
                    {
                        foreach (DataRow row1 in DRBarcode)
                        {
                            cmbItem.Text = row1["ItemName"].ToString();
                            txtBox.Text = row1["PackageQty"].ToString();
                            //SelectItem(Cmb_Item.Text.Trim());
                            txtCost.Focus();
                            ClearBarcodeValues();
                        }

                    }
                    else
                    {
                        if (GeneralFunction.Question("NotAvailableBarcode", ActionType.Confirmation.ToString()) == DialogResult.Yes)
                        {
                            ItemCard frmItem = new ItemCard();
                            GeneralFunction.PurchaseBarcode = ScanValue + txtBarcode.Text.Trim();
                            frmItem.ShowDialog();
                            // FillItemComboBoxList_Item();
                            GeneralFunction.PurchaseBarcode = string.Empty;
                            ClearBarcodeValues();
                           // AssignNewItemSource();
                            ObjStockHelper.SetItemDetailsToList();
                            cmbItem.SelectedIndexChanged -= new EventHandler(this.cmbItem_SelectedIndexChanged);
                            AssignItemSource();
                            cmbItem.SelectedIndex = -1;
                            cmbItemNo.SelectedIndex = -1;
                            cmbItem.SelectedIndexChanged += new EventHandler(this.cmbItem_SelectedIndexChanged);
                            frmItem = null;
                        }
                        else
                        {
                            txtBarcode.Text = string.Empty;
                            ClearBarcodeValues();
                            //ClearDefaultValue();
                            //DefaultValue();
                        }
                    }
                }
                else if (ScannerCount > 1)
                {
                    tmrBarcode.Enabled = false;
                    ClearBarcodeValues();
                    //ClearDefaultValue();
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
            // cmbItem.Focus();Commended on Oct08

        }
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
        //            // listBox1.Items.Add(ScanValue+" "+ScanLetterEndTime.TotalMilliseconds);
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

        //private void cmbItem_DropDown(object sender, EventArgs e)
        //{
        //    if (((ComboBox)(sender)).DroppedDown == false)
        //    {
        //        ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //    }
        //}

        //private void cmbItem_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
        //        case "cmbSupplierName":
        //            if (iscount)
        //                iscount = false;
        //            else
        //                cmbSupplierName_SelectedIndexChanged(sender, EventArgs.Empty);
        //            break;
        //        case "cmbSupplierNo":
        //            if (iscount)
        //                iscount = false;
        //            else
        //                cmbSupplierNo_SelectedIndexChanged(sender, EventArgs.Empty);
        //            break;
        //    }
        //}

        private void txtBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBox.SelectedIndex > -1 && txtBox.Text != string.Empty)
            {
                var ItemPrice = ObjStockHelper.PackageQty.Where(a => a.ItemPackage == Convert.ToInt32(txtBox.Text)).ToList();// == string.Empty ? "0" : txtTotalStock.Text)).ToList();
                if (ItemPrice.Count > 0)
                {
                    PriceValue();
                    //txtPrice.Text = ItemPrice[0].ItemPrice.ToString();
                    ObjStockHelper.ObjBALClass.objOpeningStockObject.BarcodeID = ItemPrice[0].BarcodeID;
                    //ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock = ItemPrice[0].ItemTotalStock;//this line Commended to fix Piece from a Package on 20Aug2014 by Meena.R
                    ObjStockHelper.ObjBALClass.ObjStock.ItemPackage = ItemPrice[0].ItemPackage;//this line added on 20Aug2014
                    ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock = ObjStockHelper.PackageQty.Sum(a => a.ItemTotalStock);//this line added on 20Aug2014
                    decimal UnitItemCost = Convert.ToDecimal((((ObjStockHelper.ObjBALClass.ObjStock.ItemCardItemCost / (ObjStockHelper.ObjBALClass.ObjStock.ItemCardPackageQty == 0 ? 1 : ObjStockHelper.ObjBALClass.ObjStock.ItemCardPackageQty)) * 1000m) / 1000m).ToString("#####0.000"));
                    if (!ObjStockHelper.isPackage)
                    {
                        if (ObjStockHelper.ObjBALClass.ObjStock.ItemCardPackageQty == Convert.ToInt32(txtBox.Text))
                            txtCost.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemCardItemCost.ToString();
                        else
                            txtCost.Text = (UnitItemCost * (Convert.ToInt32(txtBox.Text) == 0 ? 1 : Convert.ToInt32(txtBox.Text))).ToString();
                        txtStock.Text = (ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock / (ItemPrice[0].ItemPackage == 0 ? 1 : ItemPrice[0].ItemPackage)).ToString();
                    }
                    else
                    {
                        txtCost.Text = UnitItemCost.ToString();
                        txtStock.Text = ObjStockHelper.ObjBALClass.ObjStock.ItemTotalStock.ToString();
                    }
                    txtQuantity_KeyUp(null, null);
                }
                else
                    txtStock.Text = "0";
            }
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                //foreach (Control cti in panel1.Controls)
                //{
                //    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox || cti is TabControl || cti is TabPage)
                //        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                //}
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
                foreach (Control ctl in groupBox1.Controls)
                {
                    if (ctl is Button || ctl is Label || ctl is CheckBox || ctl is RadioButton || ctl is GroupBox || ctl is TabControl || ctl is TabPage)
                        ctl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                dgvInventory.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            }
        }

        private void lblTotalValue_Click(object sender, EventArgs e)
        {

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

        private void cmbItem_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 13)
            //{
            //    //if (isfrominsert == false)
            //    //    txtBarcode.Focus();
            //    //else
            //    //    isfrominsert = false;
            //    if (isfrominsert == false && IsAfterInsertItem == false)
            //        txtBarcode.Focus();
            //    else
            //    {
            //        isfrominsert = false;
            //        IsAfterInsertItem = false;
            //        cmbItem.Focus();
            //    }
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

        private void cmbItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (cmbItem.SelectedIndex > -1)
                {
                    txtCost.Focus();
                    txtCost.SelectAll();
                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNote_Click(object sender, EventArgs e)
        {

        }

        private void HighLightItem()
        {
            DataTable objInventAdjGrid = new DataTable();
            objInventAdjGrid = (DataTable)(dgvInventory.DataSource);
            int cmbItemId = cmbItem.SelectedIndex != -1 ? Convert.ToInt32(cmbItem.SelectedValue.ToString()) : -1;
            if (cmbItemId != -1)
            {
                if (objInventAdjGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < objInventAdjGrid.Rows.Count; i++)
                    {
                        dgvInventory.Rows[i].Selected = false;
                        if (Convert.ToInt32(objInventAdjGrid.Rows[i]["ItemNo"]) == cmbItemId)
                        {
                            dgvInventory.Rows[i].Selected = true;
                            dgvInventory.FirstDisplayedScrollingRowIndex = i;

                        }
                    }
                    dgvInventory.Update();

                }
            }

        }

        private void Opening_Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void PriceValue()
        {
            decimal actualprice = ObjStockHelper.ObjBALClass.ObjStock.ItemPrice;
            if (ObjStockHelper.ObjBALClass.ObjStock.ItemNo != 0)
            {
                DataTable dt = ObjStockHelper.GetAppliedIncreaseHelper();
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
                            txtPrice.Text = actualprice.ToString("#####0.000");
                        }
                        else if (IncreaseType == 1)
                        {
                            actualprice = actualprice + ((itemcost * fltdiscount) / 100);
                            txtPrice.Text = actualprice.ToString("#####0.000");
                        }
                    }
                }
                else
                {
                    txtPrice.Text = actualprice.ToString("#####0.000");
                }
            }
            else
            {
                txtPrice.Text = actualprice.ToString("#####0.000");
            }
        }
    }
}
