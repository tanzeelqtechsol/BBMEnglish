using System;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using CommonHelper;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Discount : Form, IDisposable
    {
        DiscountHelper ObjHelper;
        bool isBtnApplyDiscClick = false;
        public Discount()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjHelper = new DiscountHelper();
            cmbCategory.SelectedIndexChanged -= new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged -= new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "CategoryID";
            cmbCompany.DisplayMember = "Company";
            cmbCompany.ValueMember = "CompanyID";
            cmbCategory.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbCompany.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            cmbApplyDiscount.SelectedIndexChanged += new EventHandler(cmbCategory_SelectedIndexChanged);
            LoadDetails();
        }

        void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            ObjHelper.btnFindDiscount();
            AssignSourceforDiscount();
        }

        private void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("Discount");
            lblApplyDiscountOn.Text = Additional_Barcode.GetValueByResourceKey("AppDiscountOn");
            lblAverageProfit.Text = Additional_Barcode.GetValueByResourceKey("AvgProfit");
            lblCategory.Text = Additional_Barcode.GetValueByResourceKey("Category");
            lblCompany.Text = Additional_Barcode.GetValueByResourceKey("Company");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            lblDiscount1.Text = Additional_Barcode.GetValueByResourceKey("C1");//D1
            lblDiscount2.Text = Additional_Barcode.GetValueByResourceKey("C2");//D2
            lblDiscount3.Text = Additional_Barcode.GetValueByResourceKey("C3");//D3
            lblEndDate1.Text = Additional_Barcode.GetValueByResourceKey("ED");
            lblEndDate2.Text = Additional_Barcode.GetValueByResourceKey("ED");
            lblEndDate3.Text = Additional_Barcode.GetValueByResourceKey("ED");
            lblStartDate1.Text = Additional_Barcode.GetValueByResourceKey("SD");
            lblStartDate2.Text = Additional_Barcode.GetValueByResourceKey("SD");
            lblStartDate3.Text = Additional_Barcode.GetValueByResourceKey("SD");
            lblTtlAmtAfterDiscount.Text = Additional_Barcode.GetValueByResourceKey("TAmtAC");//TAmtAD
            lblTtlAmtBeforeDiscount.Text = Additional_Barcode.GetValueByResourceKey("TAmtBC");//TAmtBD
            lblAverageProfit.Text = Additional_Barcode.GetValueByResourceKey("AvgProfit");
            chkActivate1.Text = Additional_Barcode.GetValueByResourceKey("Active");
            chkActivate2.Text = Additional_Barcode.GetValueByResourceKey("Active");
            chkActivate3.Text = Additional_Barcode.GetValueByResourceKey("Active");
            chkIncrease.Text = Additional_Barcode.GetValueByResourceKey("PriceChange");
            btnApplyDiscount.Text = Additional_Barcode.GetValueByResourceKey("ApplyDiscount");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnFind.Text = Additional_Barcode.GetValueByResourceKey("Find");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnUndo.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            chkAllCategory.Text = Additional_Barcode.GetValueByResourceKey("All");
            chkAllCompany.Text = Additional_Barcode.GetValueByResourceKey("All");
            cmbApplyDiscount.Items.Add(Additional_Barcode.GetValueByResourceKey("AllItems"));
            cmbApplyDiscount.Items.Add(Additional_Barcode.GetValueByResourceKey("Goodsonly"));
            cmbApplyDiscount.Items.Add(Additional_Barcode.GetValueByResourceKey("MainOnly"));
            cmbApplyDiscount.Items.Add(Additional_Barcode.GetValueByResourceKey("MealOnly"));
            cmbIncrease.Items.Add(Additional_Barcode.GetValueByResourceKey("PurPrice"));
            cmbIncrease.Items.Add(Additional_Barcode.GetValueByResourceKey("CurPrice"));
            dgvItemDiscount.Columns["DiscountName"].HeaderText = dgvDiscount.Columns["DiscountName1"].HeaderText = Additional_Barcode.GetValueByResourceKey("CN");//DN
            dgvItemDiscount.Columns["DiscountPe"].HeaderText = dgvDiscount.Columns["Discount1"].HeaderText = Additional_Barcode.GetValueByResourceKey("ChangeP");//DiscountP
            dgvItemDiscount.Columns["StartDate"].HeaderText = dgvDiscount.Columns["StartDate1"].HeaderText = Additional_Barcode.GetValueByResourceKey("SD");
            dgvItemDiscount.Columns["EndDate"].HeaderText = dgvDiscount.Columns["EndDate1"].HeaderText = Additional_Barcode.GetValueByResourceKey("ED");
            dgvItemDiscount.Columns["ItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvItemDiscount.Columns["ItemName"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemName");
            dgvItemDiscount.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Quantity");
            dgvItemDiscount.Columns["Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("Price");
            dgvItemDiscount.Columns["Profit"].HeaderText = Additional_Barcode.GetValueByResourceKey("Profit");
            dgvItemDiscount.Columns["Category"].HeaderText = Additional_Barcode.GetValueByResourceKey("Category");
            dgvItemDiscount.Columns["Company"].HeaderText = Additional_Barcode.GetValueByResourceKey("Company");
            dgvItemDiscount.Columns["MinPrice"].HeaderText = Additional_Barcode.GetValueByResourceKey("MinPrice");
            dgvItemDiscount.Columns["WholeSale"].HeaderText = Additional_Barcode.GetValueByResourceKey("WholeSale");
            dgvItemDiscount.Columns["PriceAfterDis"].HeaderText = Additional_Barcode.GetValueByResourceKey("PriceAftChange"); //PriceAftDis
            dgvDiscount.Columns["Select"].HeaderText = Additional_Barcode.GetValueByResourceKey("Select");

        }

        private void SetObjectFromControl()
        {
            ObjHelper.ObjBALClass.ObjDiscount.DiscountFor = cmbApplyDiscount.SelectedIndex;
            ObjHelper.ObjBALClass.ObjDiscount.CategoryID = cmbCategory.SelectedValue == null ? 0 : (int)cmbCategory.SelectedValue;
            ObjHelper.ObjBALClass.ObjDiscount.CompanyID = cmbCompany.SelectedValue == null ? 0 : (int)cmbCompany.SelectedValue;
            ObjHelper.ObjBALClass.ObjDiscount.Discount1 = txtDiscount1.Text == string.Empty ? string.Empty : txtDiscount1.Text;
            ObjHelper.ObjBALClass.ObjDiscount.Discount2 = txtDiscount2.Text == string.Empty ? string.Empty : txtDiscount2.Text;
            ObjHelper.ObjBALClass.ObjDiscount.Discount3 = txtDiscount3.Text == string.Empty ? string.Empty : txtDiscount3.Text;
            ObjHelper.ObjBALClass.ObjDiscount.StartDate1 = chkIncrease.Checked==true? DateTime.Today.Date: dtpStartDate1.Value;
            ObjHelper.ObjBALClass.ObjDiscount.StartDate2 = dtpStartDate2.Value;
            ObjHelper.ObjBALClass.ObjDiscount.StartDate3 = dtpStartDate3.Value;
            ObjHelper.ObjBALClass.ObjDiscount.EndDate1 = chkIncrease.Checked == true ? DateTime.Today.AddYears(50): dtpEndDate1.Value ;
            ObjHelper.ObjBALClass.ObjDiscount.EndDate2 = dtpEndDate2.Value;
            ObjHelper.ObjBALClass.ObjDiscount.EndDate3 = dtpEndDate3.Value;
            ObjHelper.ObjBALClass.ObjDiscount.Active1 = chkActivate1.Checked == true ? true : false;
            ObjHelper.ObjBALClass.ObjDiscount.Active2 = chkActivate2.Checked != true ? false : true;
            ObjHelper.ObjBALClass.ObjDiscount.Active3 = chkActivate3.Checked != false ? true : false;
            ObjHelper.ObjBALClass.ObjDiscount.HasIncrease = chkIncrease.Checked;
            ObjHelper.ObjBALClass.ObjDiscount.IncreaseType = cmbIncrease.SelectedIndex;
        }

        private void SetControlFromObject()
        {
            txtAverageProfit.Text = ObjHelper.ObjBALClass.ObjDiscount.Profit.ToString("#####0.0000");
            txtTotalAmtAfterDiscount.Text = ObjHelper.ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString("#####0.0000");
            txtTotalAmtBeforeDiscount.Text = ObjHelper.ObjBALClass.ObjDiscount.TotalAmtBfDiscount.ToString("#####0.0000");
            cmbApplyDiscount.SelectedIndex = ObjHelper.GetStringItemType();
        }

        private void LoadDetails()
        {
            //***********Date Format for DatetimPicker control by Seenivasan on 15-Oct-2014************************//
            Dtp_Date.Format = DateTimePickerFormat.Custom;
            dtpEndDate1.Format = DateTimePickerFormat.Custom;
            dtpStartDate1.Format = DateTimePickerFormat.Custom;
            dtpEndDate2.Format = DateTimePickerFormat.Custom;
            dtpStartDate2.Format = DateTimePickerFormat.Custom;
            dtpEndDate3.Format = DateTimePickerFormat.Custom;
            dtpStartDate3.Format = DateTimePickerFormat.Custom;

            Dtp_Date.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpEndDate1.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpStartDate1.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpEndDate2.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpStartDate2.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpEndDate3.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dtpStartDate3.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            //***********Date Format Check*****************************************************//

            cmbCategory.DataSource = GeneralObjectClass.CategoryList;
            cmbCompany.DataSource = GeneralObjectClass.CompanyList;
            if (GeneralObjectClass.CategoryList.Count > 0)
               // lblCategory.Text = GeneralObjectClass.CategoryList[0].FieldCategory;
            if (GeneralObjectClass.CompanyList.Count > 0)
               // lblCompany.Text = GeneralObjectClass.CompanyList[0].FieldCompany;
            ObjHelper.btnFindDiscount();
            AssignSourceforDiscount();
            chkActivate1.CheckedChanged -= new EventHandler(chkActivate1_CheckedChanged);
            chkActivate2.CheckedChanged -= new EventHandler(chkActivate2_CheckedChanged);
            chkActivate3.CheckedChanged -= new EventHandler(chkActivate3_CheckedChanged);
            chkActivate1.Checked = true; //Added on 28-Oct-2014 by Seenivasan
            chkActivate2.Checked = false; //Added on 28-Oct-2014 by Seenivasan
            chkActivate3.Checked = false; //Added on 28-Oct-2014 by Seenivasan

            dtpEndDate1.Enabled = dtpStartDate1.Enabled = txtDiscount1.Enabled = true;
            dtpEndDate2.Enabled = dtpStartDate2.Enabled = txtDiscount2.Enabled = false;
            dtpEndDate3.Enabled = dtpStartDate3.Enabled = txtDiscount3.Enabled = false;

            chkActivate1.CheckedChanged += new EventHandler(chkActivate1_CheckedChanged);
            chkActivate2.CheckedChanged += new EventHandler(chkActivate2_CheckedChanged);
            chkActivate3.CheckedChanged += new EventHandler(chkActivate3_CheckedChanged);
        }

        private void Discount_Load(object sender, EventArgs e)
        {

        }

        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            isBtnApplyDiscClick = true;
            this.SetObjectFromControl();
            ObjHelper.btnApplyDiscount();
            if (ObjHelper.isProgressStatus)
                  AssignSourceforDiscount();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            ObjHelper.btnFindDiscount();
            AssignSourceforDiscount();
        }

        private void AssignSourceforDiscount()
        {
            ObjHelper.AssignDataSourceforDiscount(dgvDiscount);
            ObjHelper.AssignSourceforItem(dgvItemDiscount);
            this.SetControlFromObject();
            ClearInputs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDiscount.RowCount > 0)
                {
                    bool boolSelect = false;
                    string strDiscountId = string.Empty;
                    foreach (DataGridViewRow dgvr in dgvDiscount.Rows)
                    {
                        if (Convert.ToBoolean(dgvr.Cells["Select"].Value) == true)
                        {
                            boolSelect = true;
                            strDiscountId += (strDiscountId != string.Empty) ? "," + dgvr.Cells["DiscountId"].Value.ToString() : dgvr.Cells["DiscountId"].Value.ToString();
                        }
                    }
                    if (!boolSelect)
                    {
                        GeneralFunction.Information("SelectDiscount", "Discount");
                        return;
                    }
                    ObjHelper.ObjBALClass.ObjDiscount.DiscountID = (strDiscountId);
                    if (ObjHelper.btnDelete())
                        AssignSourceforDiscount();
                    else
                        return;
                }
                else
                {
                    GeneralFunction.Information("NoDiscount", "Discount");
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Txt_Discount1_Leave(object sender, EventArgs e)
        {
            try
            {
                Control str = ((TextBox)sender);
                if (str.Text != string.Empty)
                {
                    decimal val = Convert.ToDecimal(str.Text);
                    if (val > 100 || val == 100)
                    {
                        if (!chkIncrease.Checked)
                        {
                            GeneralFunction.Information("EnterDiscountLessthan", "Discount");
                            str.Select();
                            str.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Txt_Discount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = ((TextBox)sender).Text;
            e.Handled = (str.Contains(".") && (e.KeyChar == '.')) || (GeneralFunction.NumericOnly(e)) || ((str == string.Empty) && (e.KeyChar == '.'));
        }

        private void ClearInputs()
        {
            if (isBtnApplyDiscClick)
            {
                dtpStartDate1.Value = dtpEndDate1.Value = dtpStartDate2.Value = dtpEndDate2.Value = dtpStartDate3.Value = dtpEndDate3.Value = DateTime.Now;
                txtDiscount1.Text = txtDiscount2.Text = txtDiscount3.Text = string.Empty;
                chkActivate1.Checked = chkActivate2.Checked = chkActivate3.Checked = false;
                chkActivate2.Enabled = chkActivate3.Enabled= true;
                cmbIncrease.SelectedIndex = -1;
                chkIncrease.Checked = false;
            }
            isBtnApplyDiscClick = false;
        }

        private void discounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                Quick_Price_Information frmQuick = new Quick_Price_Information();
                frmQuick.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            ObjHelper.Print();
        }
        private void setFont()
        {
            var CulInfo = Thread.CurrentThread.CurrentUICulture;
            if (CulInfo.Name == "en-US")
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                    {
                        Control c = tableLayoutPanel1.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ctrl in c.Controls)
                            {
                                if (ctrl is Button || ctrl is Label || ctrl is RadioButton || ctrl is CheckBox)
                                    ctrl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ctrl is GroupBox || ctrl is Panel)
                                {
                                    foreach (Control ct in ctrl.Controls)
                                    {

                                        if (ct is Button || ct is Label || ct is RadioButton || ct is CheckBox)
                                            ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #region CheckBox Events
        /// <summary>
        /// //Added on 28-Oct-2014 by Seenivasan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkActivate1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIncrease.Checked){ txtDiscount1.Enabled = chkActivate1.Checked; }
                else { dtpEndDate1.Enabled = dtpStartDate1.Enabled = txtDiscount1.Enabled = chkActivate1.Checked; }
                if (!chkActivate1.Checked)
                {
                    dtpStartDate1.Value = dtpEndDate1.Value = DateTime.Now;
                    txtDiscount1.Text = string.Empty;
                    chkActivate1.Checked = false;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Discount", "chkActivate1_CheckedChanged");
            }
        }

        private void chkActivate2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpEndDate2.Enabled = dtpStartDate2.Enabled = txtDiscount2.Enabled = chkActivate2.Checked;
                if (!chkActivate2.Checked)
                {
                    dtpStartDate2.Value = dtpEndDate2.Value = DateTime.Now;
                    txtDiscount2.Text = string.Empty;
                    chkActivate2.Checked = false;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Discount", "chkActivate2_CheckedChanged");
            }
        }

        private void chkActivate3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtpEndDate3.Enabled = dtpStartDate3.Enabled = txtDiscount3.Enabled = chkActivate3.Checked;
                if (!chkActivate3.Checked)
                {
                    dtpStartDate3.Value = dtpEndDate3.Value = DateTime.Now;
                    txtDiscount3.Text = string.Empty;
                    chkActivate3.Checked = false;
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Discount", "chkActivate3_CheckedChanged");
            }
        }

        #endregion

        private void Discount_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjHelper.DiscountList = null;
            ObjHelper.DiscountedItem = null;
            ObjHelper = null;
            this.Dispose();
        }
        private void chkIncrease_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbIncrease.Enabled = chkIncrease.Checked;
                if (chkIncrease.Checked)
                {
                    chkActivate3.Enabled = false;
                    chkActivate2.Enabled = false;
                    chkActivate3.Checked = false;
                    chkActivate2.Checked = false;
                    dtpStartDate1.Enabled = false;
                    dtpEndDate1.Enabled = false;
                    chkActivate3_CheckedChanged(sender, e);
                    chkActivate2_CheckedChanged(sender, e);
                    cmbIncrease.SelectedIndex = 0;
                }
                else
                {
                    cmbIncrease.SelectedIndex = -1;
                    chkActivate3.Enabled = true;
                    chkActivate2.Enabled = true;
                    dtpStartDate1.Enabled = true;
                    dtpEndDate1.Enabled = true;
                    txtDiscount1.Text = string.Empty;
                }
            }
            catch (Exception ex)

            {

                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Discount", "chkIncreasee_CheckedChanged");
            }
        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
