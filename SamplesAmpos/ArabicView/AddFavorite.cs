using BALHelper;
using BumedianBM.ViewHelper;
using DataBaseHelper;
using DataBaseHelper.DALClass;
using ObjectHelper;
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
    public partial class AddFavorite : Form
    {

        UserFavoriteQueryHelper ObjHelper;

        public AddFavorite()
        {
            InitializeComponent();
            SetLanguage();
            ObjHelper = new UserFavoriteQueryHelper();
        }

        #region custom methods
        private bool Update_UserQuery()
        {
            FavoriteUserQueryObjectClass ObjFavoriteUserQuery = new FavoriteUserQueryObjectClass()
            {
                ID = ShowFavoritesUserQuery.FavListID,
                Description = txtTitle.Text,
                FileName = txtExtportFileName.Text,
                QueryText = txtQuery.Text,
                IsReleased = chkReleased.Checked,
            };
            ObjHelper.ObjBALClass.ObjFavoriteUserQuery = ObjFavoriteUserQuery;
            return ObjHelper.ObjBALClass.UpdateFavoriteUserQuery();
        }
        private void populateData()
        {
            FavoriteUserQueryObjectClass favoriteUserQueryObjecy = new FavoriteUserQueryObjectClass();
            favoriteUserQueryObjecy = ObjHelper.ObjBALClass.GetFavoriteUserQueryByID(ShowFavoritesUserQuery.FavListID);
            if (favoriteUserQueryObjecy != null)
            {
                txtTitle.Text = favoriteUserQueryObjecy.Description;
                txtExtportFileName.Text = favoriteUserQueryObjecy.FileName;
                txtQuery.Text = favoriteUserQueryObjecy.QueryText;
                chkReleased.Checked = favoriteUserQueryObjecy.IsReleased;
            }
        }
        private bool Save_UserQuery(string desc, bool isReleased, string queryText, string filename)
        {

            FavoriteUserQueryObjectClass ObjFavoriteUserQuery = new FavoriteUserQueryObjectClass()
            {
                Description = desc,
                IsReleased = isReleased,
                QueryText = queryText,
                FileName = filename,
                IsSystemCreated = false

            };

            ObjHelper.ObjBALClass.ObjFavoriteUserQuery = ObjFavoriteUserQuery;
            return ObjHelper.ObjBALClass.SaveFavoriteUserQuery();
        }
        private bool Get_UserQueryByDesc(string desc)
        {

            return ObjHelper.ObjBALClass.GetFavoriteUserQueryByDesc(desc);
        }
        string succeessMsg = "";
        string errorMsg = "";
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddFavorite_Load(object sender, EventArgs e)
        {
            txtTitle.Text = ShowFavoritesUserQuery.selectedQueryName;
            if (ShowFavoritesUserQuery.FavListID > 0)
                populateData();
            else
                txtQuery.Text = FormQuery.query;
        }
        private void SetLanguage()
        {
            succeessMsg = Additional_Barcode.GetValueByResourceKey("SuccessSaveMsg");
            this.Text = Additional_Barcode.GetValueByResourceKey("Released");
            label1.Text = Additional_Barcode.GetValueByResourceKey("Title");
            chkReleased.Text = Additional_Barcode.GetValueByResourceKey("Released");
            label3.Text = Additional_Barcode.GetValueByResourceKey("ExportFileName");
            btn_Add.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            btn_Cancel.Text = Additional_Barcode.GetValueByResourceKey("Close");
            label2.Text = Additional_Barcode.GetValueByResourceKey("QueryText");
        }

        private void txtTitle_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtQuery.Text) /*&& !string.IsNullOrEmpty(txtExtportFileName.Text)*/)
            {


                if (ShowFavoritesUserQuery.FavListID > 0)
                {
                    if (Update_UserQuery())
                    {

                        MessageBox.Show(succeessMsg);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Failed");
                }
                else
                {
                    if (Get_UserQueryByDesc(txtTitle.Text))
                    {
                        MessageBox.Show(label1.Text + " is already exist with that name");
                        return;
                    }
                    if (Save_UserQuery(txtTitle.Text, chkReleased.Checked, txtQuery.Text, txtExtportFileName.Text))
                    {
                        MessageBox.Show(succeessMsg);
                        ShowFavoritesUserQuery.selectedQueryName = txtTitle.Text;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Failed");
                }
            }
        }

        private void btn_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


