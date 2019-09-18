using System;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.ViewHelper;
using ObjectHelper;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading;
using System.Drawing;
using System.Drawing.Printing;


namespace BumedianBM.ArabicView
{
    public partial class PrimaryInfo : Form, IDisposable
    {


        #region Object Initialization
        ComCatHelper Obj_Helpers;

        Boolean SelectGrid = false;
        List<char> ListofString = new List<char>();
        #endregion

        #region Constructor
        public PrimaryInfo()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            Obj_Helpers = new ComCatHelper();
            //ObjSetData = new ComCatObjectClass();
            
            dgvPrimaryInfo.Visible = false;
        }

        #endregion

        #region Form Load Event
        private void PrimaryInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsReciept == "Bank") {
                    tabPrimaryInfo.SelectTab(3);
                }
                else if (IsReciept == "Branch")
                {
                    tabPrimaryInfo.SelectTab(4);
                }
                else
                {
                    tabPrimaryInfo.SelectTab(0);
                }
                IsReciept = null;
                GetPrinterlist();///to get the network printer on 29july2014
                btnBack.Visible = false;
                txtCategoryName.Select();
                txtCategoryName.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "PrimaryInfo_Load");
            }

        }
        #endregion

        #region Method

        public void SetControlFromObject()
        {

            this.txtCategoryName.Text = Obj_Helpers.ObjbalClass.ComcatObj.Category;
            this.txtCategoryField.Text = Obj_Helpers.ObjbalClass.ComcatObj.FieldCategory;
            this.txtCompanyFieldName.Text = Obj_Helpers.ObjbalClass.ComcatObj.CompanyName;
            this.txtCompanyField.Text = Obj_Helpers.ObjbalClass.ComcatObj.FieldCompany;
            this.txtItemPlace.Text = Obj_Helpers.ObjbalClass.ComcatObj.ItemPlace;
            this.txtBankName.Text = Obj_Helpers.ObjbalClass.ComcatObj.BankName;
            this.txtBranchName.Text = Obj_Helpers.ObjbalClass.ComcatObj.BranchName;
            this.txtUnitName.Text = Obj_Helpers.ObjbalClass.ComcatObj.UnitName;
            this.txtUnitQuantity.Text = Obj_Helpers.ObjbalClass.ComcatObj.UnitQuantity;
            this.cmb_PrinterName.Text = Obj_Helpers.ObjbalClass.ComcatObj.Printer;

        }
        public void SetObjectFromControl()
        {
            Obj_Helpers.ObjbalClass.ComcatObj.Category = this.txtCategoryName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.FieldCategory = this.txtCategoryField.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.CompanyName = this.txtCompanyFieldName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.FieldCompany = this.txtCompanyField.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.ItemPlace = this.txtItemPlace.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.BankName = this.txtBankName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.BranchName = this.txtBranchName.Text.Trim();
            //Obj_Helpers.ObjbalClass.ComcatObj.UnitName =Additional_Barcode.GetValueByResourceKey("BoxOf")+"("+this.txtUnitName.Text.Trim()+")"; Commanded on 16/04/2014
            Obj_Helpers.ObjbalClass.ComcatObj.UnitName = this.txtUnitName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.UnitQuantity = this.txtUnitQuantity.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.CommonId = SelectGrid == true ? Obj_Helpers.ObjbalClass.ComcatObj.CommonId : "";
            Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
            Obj_Helpers.ObjbalClass.ComcatObj.Printer = cmb_PrinterName.Text.Trim().ToString();///Assign the name of printer to object on 30 july 2014
        }

        private void Clear()
        {
            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtCategoryField.Text = string.Empty;
            txtCompanyField.Text = string.Empty;
            txtCompanyFieldName.Text = string.Empty;
            txtItemPlace.Text = string.Empty;
            txtUnitName.Text = txtUnitQuantity.Text = string.Empty;
            SelectGrid = false;
            txtCategoryName.Focus();
            txtCompanyFieldName.Focus();
            txtBranchName.Focus();
            txtBankName.Focus();
            txtItemPlace.Focus();
            txtCompanyFieldName.Focus();
            txtCategoryName.Focus();
            cmb_PrinterName.SelectedIndex = 0;/////Included on 30 july 2014 to view the default values of N/A


        }
        public void SetLanguage()
        {

            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            btnBack.Text = Additional_Barcode.GetValueByResourceKey("Back");
            btnView.Text = Additional_Barcode.GetValueByResourceKey("View");
            lblBankName.Text = Additional_Barcode.GetValueByResourceKey("BName");
            lblBranchName.Text = Additional_Barcode.GetValueByResourceKey("BrName");
            lblCategoryName.Text = Additional_Barcode.GetValueByResourceKey("CatName");
            lblCompanyName.Text = Additional_Barcode.GetValueByResourceKey("ComName");
            lblFieldNam.Text = Additional_Barcode.GetValueByResourceKey("FieldName");
            lblFieldName.Text = Additional_Barcode.GetValueByResourceKey("ChangeCategory");
            lblPlaceName.Text = Additional_Barcode.GetValueByResourceKey("PlaceName");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            Tab_Category.Text = (Additional_Barcode.GetValueByResourceKey("Category"));
            Tab_Bank.Text = Additional_Barcode.GetValueByResourceKey("Bank");
            Tab_Branch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            Tab_Company.Text = Additional_Barcode.GetValueByResourceKey("Company");
            Tab_ItemPlace.Text = Additional_Barcode.GetValueByResourceKey("ItemPlace");
            Tab_ItemUnit.Text = Additional_Barcode.GetValueByResourceKey("ItemUnit");
            this.Text = Additional_Barcode.GetValueByResourceKey("PrimaryInfo");
            lblUnitName.Text = Additional_Barcode.GetValueByResourceKey("UnitName");
            lblUnitQuantity.Text = Additional_Barcode.GetValueByResourceKey("UnitQuantity");
            lbl_NoOfBoxesInCartoon.Text = Additional_Barcode.GetValueByResourceKey(lbl_NoOfBoxesInCartoon.Tag.ToString());
            lbl_NoOfPiecesInBox.Text = Additional_Barcode.GetValueByResourceKey(lbl_NoOfPiecesInBox.Tag.ToString());
            lbl_Printer.Text = Additional_Barcode.GetValueByResourceKey(lbl_Printer.Tag.ToString());//include this label for printer collection

        }
        private void dgbind_Category()
        {

            int noColumns = 4;
            int[] width = { 165, 165, 167, 167 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindCategory(), noColumns, width, dgvPrimaryInfo);
            if (dgvPrimaryInfo.Columns.Count > 3) //Added on 13-Oct-2014
            {
                dgvPrimaryInfo.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
        private void dgbind_Company()
        {


            int noColumns = 3;
            int[] width = { 165, 165, 167 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindCompany(), noColumns, width, dgvPrimaryInfo);



        }
        private void dgbind_Bank()
        {

            int noColumns = 2;
            int[] width = { 165, 233 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindBank(), noColumns, width, dgvPrimaryInfo);



        }
        private void dgbind_Branch()
        {


            int noColumns = 2;
            int[] width = { 165, 233 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindBranch(), noColumns, width, dgvPrimaryInfo);


        }
        private void dgbind_ItemPlace()
        {


            int noColumns = 2;
            int[] width = { 165, 233 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindItemPlace(), noColumns, width, dgvPrimaryInfo);


        }
        private void dgvbind_ItemUnit()
        {
            int noColumns = 3;
            int[] width = { 165, 165, 167 };
            CommonHelper.GeneralFunction.SetGridColumnSize(Obj_Helpers.BindItemUnit(), noColumns, width, dgvPrimaryInfo);

        }
        //public static void ChangeProperties(Control ctrl)
        //{
        //    ctrl.Select();
        //    ctrl.Focus();

        //}
        #endregion

        #region Event



        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
                Obj_Helpers.ObjbalClass.ComcatObj = new ComCatObjectClass();
                tabPrimaryInfo.Visible = true;
                dgvPrimaryInfo.Visible = false;
                btnBack.Visible = false;
                btnClose.Visible = true;
                btnSave.Enabled = btnDelete.Enabled = true;
                Obj_Helpers.IsValueFromGrid = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnNew_Click");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                if (Obj_Helpers.SaveClick())
                {
                    if (Obj_Helpers.tag == Convert.ToInt32(Tabs.ItemUnit))
                        txtUnitName.Focus();
                    Clear();
                }
                else { ChangeProperties(Obj_Helpers.ObjbalClass.ComcatObj.FocusedControlName); }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnSave_Click");
            }
        }
        public void ChangeProperties(string ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl))
            {
                TextBox txtbox = (TextBox)tabPrimaryInfo.SelectedTab.Controls[ctrl];
                txtbox.Focus();
                txtbox.Select();
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                tabPrimaryInfo.Visible = false;
                dgvPrimaryInfo.Visible = true;

                Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;

                Obj_Helpers.doubleclicktab = Obj_Helpers.tag;
                switch ((Tabs)Obj_Helpers.tag)
                {
                    case Tabs.Category:
                        dgbind_Category();
                        break;
                    case Tabs.Company:
                        dgbind_Company();
                        break;
                    case Tabs.ItemPlace:
                        dgbind_ItemPlace();
                        break;
                    case Tabs.Bank:
                        dgbind_Bank();
                        break;
                    case Tabs.Branch:
                        dgbind_Branch();
                        break;
                    case Tabs.ItemUnit:
                        dgvbind_ItemUnit();
                        break;
                }



                btnBack.Visible = true;
                btnClose.Visible = false;
                btnSave.Enabled = btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnView_Click");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CommonHelper.GeneralFunction.Question(Constants.CANCEL, ActionType.Confirmation.ToString()) == DialogResult.OK)
                this.Clear();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnCancel_Click");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                Obj_Helpers.Delete();
                Clear();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnDelete_Click");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPrimaryInfo.SendToBack();
                tabPrimaryInfo.Visible = true;
                btnBack.Visible = false;
                btnClose.Visible = true;
                btnSave.Enabled = btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnBack_Click");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //if ((CommonHelper.GeneralFunction.Question(Constants.CLOSE, ActionType.Confirmation.ToString()) == DialogResult.Yes))
                //{
                this.Close();
                //}
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " btnClose_Click");
            }
        }

        private void dgvPrimaryInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SelectGrid = true;
                if (dgvPrimaryInfo.SelectedRows.Count > 0)
                {
                    int cellcount = dgvPrimaryInfo.Columns.Count;
                    Obj_Helpers.ID = dgvPrimaryInfo.SelectedRows[0].Cells[0].Value.ToString();
                    Obj_Helpers.Category = dgvPrimaryInfo.SelectedRows[0].Cells[1].Value == null ? "" : dgvPrimaryInfo.SelectedRows[0].Cells[1].Value.ToString();
                    Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;///Included on 01 aus 2014 category tab only get the printer name from the grid 
                    if ((Tabs)Obj_Helpers.tag == Tabs.Category)
                    {
                        Obj_Helpers.Printer = dgvPrimaryInfo.SelectedRows[0].Cells[3].Value.ToString();
                    }
                    if (cellcount > 2)
                    {
                        Obj_Helpers.Field = dgvPrimaryInfo.SelectedRows[0].Cells[2].Value.ToString();
                    }
                    Obj_Helpers.SetValueFromGrid();
                    Obj_Helpers.IsValueFromGrid = true;
                    this.SetControlFromObject();
                }
                btnBack.Visible = false;
                btnClose.Visible = true;
                btnSave.Enabled = btnDelete.Enabled = true;
                tabPrimaryInfo.Visible = true;
                dgvPrimaryInfo.Visible = false;

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " dgvPrimaryInfo_DoubleClick");
            }

        }
        private void txtCategoryField_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{

            //    if (e.KeyChar == 13)
            //    {
            //        SendKeys.Send("{TAB}");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
            //    GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " txtCategoryField_KeyPress");
            //}
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar == 13)
            //    {
            //        e.Handled = false;
            //        btnSave_Click(sender, e);
            //        e.Handled = true;
            //    }

            //}
            //catch (Exception ex)
            //{

            //    GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
            //    GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " txtCategoryName_KeyPress");
            //}
        }

        private void PrimaryInfo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information priceinformation = new Quick_Price_Information();
                    priceinformation.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " PrimaryInfo_KeyDown");
            }
        }



        private void txtUnitName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //                        string RemoveBetween(string s, char begin, char end)
            //{

            //return regex.Replace(s, string.Empty);
            //}

            //string s = "Give [Me Some] Purple (And More) \\Elephants/ and .hats^";
            //s = RemoveBetween(s, '(', ')');
            //s = RemoveBetween(s, '[', ']');
            //s = RemoveBetween(s, '\\', '/');
            //s = RemoveBetween(s, '.', '^');
        }

        private void tabPrimaryInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
                switch ((Tabs)Obj_Helpers.tag)
                {
                    case Tabs.Category:
                        //txtCategoryField.Focus();commended By Meena.R on 28Oct2014
                        txtCategoryName.Focus();
                        break;
                    case Tabs.Company:
                        //txtCompanyField.Focus();commended By Meena.R on 28Oct2014
                        txtCompanyFieldName.Focus();
                        break;
                    case Tabs.ItemPlace:
                        txtItemPlace.Focus();
                        break;
                    case Tabs.Bank:
                        txtBankName.Focus();
                        break;
                    case Tabs.Branch:
                        txtBranchName.Focus();
                        break;
                    case Tabs.ItemUnit:
                        string name = txtUnitName.Text.ToString();
                        txtUnitName.Select(name.IndexOf("(") + 1, 5);
                        txtUnitName.Focus();
                        //tbPositionCursor.Select(tbPositionCursor.Text.Length, 0)

                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void txtUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 46) != true)
                {

                    e.Handled = true;
                }



                //else
                //{

                //    char s = e.KeyChar;
                //    char[] array = { e.KeyChar };
                //    ListofString.Add(s);
                //    //for (int i = 0; i < ListofString.Count; i++)
                //    //{

                //    //    j = j + ListofString[i];
                //    //}


                //    var getstring = (from t in ListofString
                //                     where char.IsDigit(t)
                //                     select t).ToArray();
                //    int getNumbers = (from t in array
                //                      where char.IsDigit(t)
                //                      select t).ToArray().Count();
                //    string sd = new string(getstring);


                //    if (ListofString.Count > 4)
                //    {
                //        txtUnitName.Text = string.Empty;
                //        txtUnitName.Text = "BoxOf(    )";
                //        string name=txtUnitName.Text.ToString();
                //        txtUnitName.Select(name.IndexOf("(") + 1, 5);
                //        txtUnitName.Focus();
                //        ListofString.Clear();
                //    }

                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void txtUnitName_TextChanged(object sender, EventArgs e)
        {
            //String  s = "ldfhklk234dhflkgh";
            //var getNumbers = (from t in s
            //                  where char.IsDigit(t)
            //                  select t).ToArray();
            ////Console.WriteLine(new string(getNumbers));
            //string charc = txtUnitName.Text;
            //Regex regex = new Regex(string.Format("[1-4]", "(", ")"));
            //System.Char.IsNumber(charc, charc.IndexOf("("));

        }

        private void txtCategoryField_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyValue == 13)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, " txtCategoryField_KeyDown");
            }
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox || cti is TabControl || cti is TabPage)
                        cti.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control btn in groupBox2.Controls)
                {
                    if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is GroupBox)
                        btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                lblCategoryName.Font = lblFieldName.Font = lblUnitName.Font = lblUnitQuantity.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
            }

        }
        //private void txt_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
        //    //if (e.KeyChar == 13)
        //    //{
        //    //    this.SetObjectFromControl();
        //    //    Obj_Helpers.SaveClick();
        //    //}
        //}


        #endregion
        /// <summary>
        /// to get the list of network printer 
        /// </summary>

        private void GetPrinterlist()
        {
            String InstalledPrinters;
            cmb_PrinterName.Items.Add("N/A");

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                InstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmb_PrinterName.Items.Add(InstalledPrinters);


            }
        }
    }
}
