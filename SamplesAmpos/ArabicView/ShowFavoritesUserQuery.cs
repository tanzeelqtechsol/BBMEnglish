using BumedianBM.ViewHelper;
using DataBaseHelper;
using DataBaseHelper.DALClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class ShowFavoritesUserQuery : Form
    {
        UserFavoriteQueryHelper ObjHelper;
        public ShowFavoritesUserQuery()
        {
            InitializeComponent();
            hideText();
            SetLanguage();
            ObjHelper = new UserFavoriteQueryHelper();
        }

        #region custom methdos
        string succeessMsg = "";
        string EditMessage = "";
        string DeleteMessage = "";
        public static string selectedQueryName = "";
        public static bool isFromFav = true;
        public static int FavListID = 0;
        private void populateGrid()
        {
            DataTable dt = ObjHelper.ObjBALClass.GetFavoriteUserQuery();
            if (dt.Rows.Count > 0)
            {
                Dg_FavQueries.DataSource = dt;
                Dg_FavQueries.Columns[0].Visible = false;
                Dg_FavQueries.Columns[3].Visible = false;
                Dg_FavQueries.Columns[4].Visible = false;
                Dg_FavQueries.Columns[5].Visible = false;
            }
            else
                Dg_FavQueries.DataSource = null;

            for (int i = 0; i < Dg_FavQueries.Columns.Count; i++)
            {
                string colName = Dg_FavQueries.Columns[i].Name;
                colName = FormQuery.GetEmbeddedResourceMapping(colName);
                if (!string.IsNullOrEmpty(colName))
                    Dg_FavQueries.Columns[i].HeaderText = colName;
            }

        }
        private int getSelectedID()
        {
            int retval = 0;
            if (Dg_FavQueries.Rows.Count < 1)
                return 0;
            if (Dg_FavQueries.SelectedRows[0].Cells[0].Value != null)
            {
                retval = 0;
                int.TryParse(Dg_FavQueries.SelectedRows[0].Cells[0].Value.ToString(), out retval);
            }
            return retval;
        }
        private string getSelectedQuery()
        {
            string retval = "";
            if (Dg_FavQueries.Rows.Count < 1)
                return "";
            if (Dg_FavQueries.SelectedRows[0].Cells[0].Value != null)
            {
                retval = Dg_FavQueries.SelectedRows[0].Cells[4].Value.ToString();
                selectedQueryName = Dg_FavQueries.SelectedRows[0].Cells[2].Value.ToString();
            }
            return retval;
        }
        public bool DeletefavListItem()
        {
            return ObjHelper.ObjBALClass.DeleteFavoriteUserQuery(FavListID);
        }
        private void showText()
        {
            this.Size = new Size(844, 622);
            this.CenterToScreen();
            btn_ShowHideText.Text = Additional_Barcode.GetValueByResourceKey("HideText");
            this.btn_ShowHideText.Image = global::BumedianBM.Properties.Resources.folder_32;
            //btn_ShowHideText.Text = "Hide Text";
            panelShowText.Visible = true;
            //chkWrapText.Visible = true;
            //btnOk.Location = new Point(910, 731);
            //btnCancel.Location = new Point(1062, 731);
            //panelGrid.Size = new Size(618, 642);
        }
        private void hideText()
        {
            //this.Size = new Size(690, 823);
            this.Size = new Size(507, 622);
            this.CenterToScreen();
            btn_ShowHideText.Text = Additional_Barcode.GetValueByResourceKey("ShowText");
            this.btn_ShowHideText.Image = global::BumedianBM.Properties.Resources.files_32;
            //btn_ShowHideText.Text = "Show Text";
            panelShowText.Visible = false;
            //chkWrapText.Visible = false;
            //btnOk.Location = new Point(329, 731);
            //btnCancel.Location = new Point(481, 731);

            //panelGrid.Size = new Size(618, 642);
        }
        #endregion

        private void ShowFavoritesUserQuery_Load(object sender, EventArgs e)
        {
            populateGrid();
            chkWrapText.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isSystemCreated = string.IsNullOrEmpty(Dg_FavQueries.SelectedRows[0].Cells[5].Value.ToString()) ? false : Convert.ToBoolean(Dg_FavQueries.SelectedRows[0].Cells[5].Value);
            if (isSystemCreated != true)
            {
                FavListID = getSelectedID();
                if (FavListID > 0)
                {

                    DialogResult result = MessageBox.Show(Additional_Barcode.GetValueByResourceKey("DeleteConfirmMsg"), "Confirm", MessageBoxButtons.YesNo);
                    {
                        if (result == DialogResult.Yes)
                        {
                            if (DeletefavListItem())
                            {
                                MessageBox.Show(succeessMsg);
                                populateGrid();
                            }
                            else
                                MessageBox.Show("error");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(DeleteMessage);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool isSystemCreated = string.IsNullOrEmpty(Dg_FavQueries.SelectedRows[0].Cells[5].Value.ToString()) ? false : Convert.ToBoolean(Dg_FavQueries.SelectedRows[0].Cells[5].Value);
            if (isSystemCreated != true)
            {
                FavListID = getSelectedID();
                AddFavorite form = new AddFavorite();
                form.ShowDialog();
                populateGrid();
            }
            else
            {
                MessageBox.Show(EditMessage);
            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FavListID = 0;
            AddFavorite form = new AddFavorite();
            form.ShowDialog();
            populateGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                for (int i = 0; i < Dg_FavQueries.Rows.Count; i++)
                {
                    Dg_FavQueries.Rows[i].Visible = true;
                }
            }
            else
            {
                for (int i = 0; i < Dg_FavQueries.Rows.Count; i++)
                {
                    string desc = Dg_FavQueries.Rows[i].Cells[2].Value.ToString();
                    if (!string.IsNullOrEmpty(desc) && desc.ToLower().Contains(txtSearch.Text.ToLower()))
                        Dg_FavQueries.Rows[i].Visible = true;
                    else
                        Dg_FavQueries.Rows[i].Visible = false;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CustomReport.passQuery = getSelectedQuery();
            isFromFav = true;
            this.Close();
            //FormQuery form = new FormQuery();
            //form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dg_FavQueries_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtQuery.Text = getSelectedQuery();
            }
            catch
            {

            }
        }

        private void btn_ShowHideText_Click(object sender, EventArgs e)
        {
            //    this.btn_ShowHideText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            if (btn_ShowHideText.Text == Additional_Barcode.GetValueByResourceKey("ShowText"))
                showText();
            else
                hideText();
        }

        private void chkWrapText_CheckedChanged(object sender, EventArgs e)
        {
            txtQuery.WordWrap = chkWrapText.Checked;
        }
        private void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("Favorites");
            chkWrapText.Text = Additional_Barcode.GetValueByResourceKey("TextWrap");
            btnEdit.Text = Additional_Barcode.GetValueByResourceKey("Edit");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            label1.Text = Additional_Barcode.GetValueByResourceKey("Search");
            btnOk.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Close");
            succeessMsg = Additional_Barcode.GetValueByResourceKey("SuccessSaveMsg");
            EditMessage = Additional_Barcode.GetValueByResourceKey("QueryEditMessage");
            DeleteMessage = Additional_Barcode.GetValueByResourceKey("QueryDeleteMessage");
            //D:\BumedianPOS\SamplesAmpos\ResourceFile\Resources.ar-sa.resx

            //label1.Text = Additional_Barcode.GetValueByResourceKey("AppDiscountOn");
        }

        private void txtSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Dg_FavQueries_DoubleClick(object sender, EventArgs e)
        {
            CustomReport.passQuery = getSelectedQuery();
            isFromFav = true;
            this.Close();
        }
    }
}
