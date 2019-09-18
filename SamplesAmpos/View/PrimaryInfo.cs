using System;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using CommonHelper;

namespace BumedianBM.View
{
    public partial class PrimaryInfo : Form
    {

        ComCatHelper Obj_Helpers;
        ComCatObjectClass ObjSetData;
        #region Constructor
        public PrimaryInfo()
        {
            InitializeComponent();
            //Obj_Helpers = new ComCatHelper(this);
            ObjSetData = new ComCatObjectClass();
            dgvPrimaryInfo.Visible = false;
        }

        #endregion

        #region Method

        public void SetControlFromObject()
        {

            this.txtCategory.Text = Obj_Helpers.ObjbalClass.ComcatObj.Category;
            this.txtCategoryFieldName.Text = Obj_Helpers.ObjbalClass.ComcatObj.FieldCategory;
            this.txtCompany.Text = Obj_Helpers.ObjbalClass.ComcatObj.CompanyName;
            this.txtCompanyFieldName.Text = Obj_Helpers.ObjbalClass.ComcatObj.FieldCompany;
            this.txtItemPlace.Text = Obj_Helpers.ObjbalClass.ComcatObj.ItemPlace;
            this.txtBankName.Text = Obj_Helpers.ObjbalClass.ComcatObj.BankName;
            this.txtBranchName.Text = Obj_Helpers.ObjbalClass.ComcatObj.BranchName;
        }
        public void SetObjectFromControl()
        {

            Obj_Helpers.ObjbalClass.ComcatObj.Category = this.txtCategory.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.FieldCategory = this.txtCategoryFieldName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.CompanyName = this.txtCompany.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.FieldCompany = this.txtCompanyFieldName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.ItemPlace = this.txtItemPlace.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.BankName = this.txtBankName.Text.Trim();
            Obj_Helpers.ObjbalClass.ComcatObj.BranchName = this.txtBranchName.Text.Trim();

        }
        private void Clear()
        {
            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtCategoryFieldName.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCompanyFieldName.Text = string.Empty;
            txtItemPlace.Text = string.Empty;

        }
        #endregion

        #region Event

        private void PrimaryInfo_Load(object sender, EventArgs e)
        {
            tabPrimaryInfo.SelectTab(0);
            btnBack.Visible = false;
            txtCategoryFieldName.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Clear();
            ObjSetData = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
            Obj_Helpers.SaveClick();
            Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
           // Obj_Helpers.ViewMethod();
            tabPrimaryInfo.Visible = false;
            dgvPrimaryInfo.Visible = true;
            btnBack.Visible = true;
            btnClose.Visible = false;
            btnSave.Enabled = btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CommonHelper.GeneralFunction.Question("Do You Want to Close", ActionType.Confirmation.ToString()) == DialogResult.OK)
                this.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            Obj_Helpers.Delete();
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dgvPrimaryInfo.SendToBack();
            btnBack.Visible = false;
            btnClose.Visible = true;
            btnSave.Enabled = btnDelete.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void datagrid_doubleclick(object sender, EventArgs e)
        {

            //Obj_Helpers.DataGridDoubleClick();
            btnBack.Visible = false;
            btnClose.Visible = true;
            btnSave.Enabled = btnDelete.Enabled = true;
            tabPrimaryInfo.Visible = true;
            dgvPrimaryInfo.Visible = false;

        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Obj_Helpers.tag = tabPrimaryInfo.SelectedIndex;
            if (e.KeyChar == 13)
            {
                this.SetObjectFromControl();
                Obj_Helpers.SaveClick();
            }
        }


        #endregion

     

        }
      
    
}