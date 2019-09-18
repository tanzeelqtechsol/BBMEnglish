using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ArabicView;
using CommonHelper;

namespace BumedianBM
{
    public partial class ItemDetails : Form,IDisposable
    {
        internal string NameOfTheScreen;

        internal List<PurchaseObjectClass> Itempopup = new List<PurchaseObjectClass>();
        internal List<SaleObject> ObjectOfSales = new List<SaleObject>();
        internal List<Object> ItemBound = new List<Object>();
        public ItemDetails(string ScreenName)
        {
            NameOfTheScreen = ScreenName;
            InitializeComponent();
            SetLanguage();
        }
        private void SetLanguage()
        {
            dgvItem.Columns["ItemName"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemName");
            dgvItem.Columns["Expiry"].HeaderText = Additional_Barcode.GetValueByResourceKey("Expiry");
            dgvItem.Columns["PackageQty"].HeaderText = Additional_Barcode.GetValueByResourceKey("Package");
            dgvItem.Columns["Quantity"].HeaderText = Additional_Barcode.GetValueByResourceKey("Pieces");
            dgvItem.Columns["ItemNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemNo");
            dgvItem.Columns["UnitType"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitTypes");
            dgvItem.Columns["UnitName"].HeaderText = Additional_Barcode.GetValueByResourceKey("UnitName");
            dgvItem.Columns["Price"].HeaderText = Additional_Barcode.GetValueByResourceKey("Price");
            dgvItem.Columns["Cost"].HeaderText = Additional_Barcode.GetValueByResourceKey("Cost");
        }

        private void ItemDetails_Load(object sender, EventArgs e)
        {
            dgvItem.AutoGenerateColumns = false;
            if (NameOfTheScreen == "Purchase")
            {
                if (Itempopup.Count > 0)
                {
                    if (Itempopup[0].ItemType == 1)
                    {
                        
                        dgvItem.Columns["Expiry"].Visible = true;
                        dtpDate.Visible = true;
                        lbl_Date.Visible = true;
                    }
                    else
                    {
                        dgvItem.Columns["Expiry"].Visible = false;
                        dtpDate.Visible = false;
                        lbl_Date.Visible = false;
                    }
                    dgvItem.DataSource = Itempopup;
                }
            }
            else
            {
                if (ObjectOfSales.Count > 0)
                {

                    dgvItem.DataSource = ObjectOfSales;
                }

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SaleObject Obj_Sale = new SaleObject();

            if (NameOfTheScreen == "Sale")
            {

                foreach (DataRow dr in dgvItem.Rows)
                {
                    if (Convert.ToInt32(dr["Select"]) == 1)
                    {

                        ItemBound.Add(dgvItem.Rows);
                    }
                }
                if (ItemBound.Count > 0)
                {
                    Sales_Invoice.GetDetailsFromItem = ItemBound.ToList();
                }
                else
                {
                    CommonHelper.GeneralFunction.Information("Select the item to be inserted", "Sales");
                }

            }
            else
            {
                ItemBound.Clear();
                for (int i = 0; i < dgvItem.Rows.Count; i++)
                {
                    Boolean status = (Boolean)(dgvItem.Rows[i].Cells["Select"].Value == null ? false : true);
                    if (status)
                    {
                        if (Validation(i))
                            ItemBound.Add(dgvItem.Rows[i].DataBoundItem);
                        else
                            return;
                    }
                }
                this.Close();
            }
        }

        private void ItemDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count > 0)
            {
                string noww = DateTime.Now.ToShortDateString().ToString();
                string[] exp = dtpDate.Value.ToString().Split(' ');
                DateTime nowdt, exdt = new DateTime();
                nowdt = Convert.ToDateTime(noww);
                exdt = Convert.ToDateTime(exp[0]);
                int diffdt = exdt.CompareTo(nowdt);
                if (exp[0] != noww && diffdt > 0)
                {
                    dgvItem.SelectedRows[0].Cells["Expiry"].Value = exp[0];
                }
                else
                {
                    //GeneralFunction.Information("ItemExpired", "PurchaseInvoice");
                    PurchaseSaleExpired frmExpiry = new PurchaseSaleExpired();
                    frmExpiry.lblText = GeneralFunction.ChangeLanguageforCustomMsg("Thisproducthasexpiredcannotbuyit");
                    frmExpiry.ShowDialog();
                    dtpDate.Focus();
                }
            }
        }

        private void dgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool Validation(int i)
        {

            if (Convert.ToInt32(dgvItem.SelectedRows[0].Cells["Quantity"].Value) == 0)
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("ZeroQty"), ActionType.Insert.ToString());
                return false;
            }
            else if (dgvItem.SelectedRows[0].Cells["Expiry"].Value.ToString() == string.Empty)
            {
                if (dgvItem.SelectedRows[0].Cells["Expiry"].Visible != false)
                {
                    GeneralFunction.Information("EmptyExpiry", "PurchaseInvoice");
                    return false;
                }
            }
            else if (dgvItem.SelectedRows[0].Cells["Cost"].Value.ToString() == "0.000")
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("EmptyCost"), ActionType.Insert.ToString());
                return false;
            }
            return true;

        }
    }
}
