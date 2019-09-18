using System;
using System.Windows.Forms;
using BumedianBM.View;
using BumedianBM.ViewHelper;
using CommonHelper;
using ObjectHelper;
using System.IO;

namespace BumedianBM.View
{
    public partial class ItemCard : Form
    {
    //    internal int len;

    //    ItemCardHelper ObjItemCardHelper;
    //    ItemCardObjectClass setItemCardObject;

    //    public ItemCard()
    //    {
    //        InitializeComponent();
    //        ObjItemCardHelper = new ItemCardHelper(null);
    //        setItemCardObject = new ItemCardObjectClass();
    //    }


    //    private void ItemCard_Load(object sender, EventArgs e)
    //    {
    //       // ObjItemCardHelper.LoadData("Y");
    //    }

       

    //    private void btnNew_Click(object sender, EventArgs e)
    //    {
    //        this.Clear();
    //        setItemCardObject = null;
    //        txtBarcodes.Focus();
    //    }

    //    public void SetObjectFromControl()
    //    {

    //        setItemCardObject.CategoryName = cmbCategory.Text.Trim();
    //        setItemCardObject.CompName = cmbCompany.Text.Trim();
    //        setItemCardObject.ItemId = cmbItemNo.Text.Trim();
    //        setItemCardObject.Barcode = txtBarcodes.Text.Trim();
    //        setItemCardObject.Items = cmbItemName.Text.Trim();
    //        setItemCardObject.OldItemName =cmbItemName.Text.Trim();
    //        len = setItemCardObject.Items.Length;
    //        setItemCardObject.ItemType = ObjItemCardHelper.GetItemType(cmbItemType.SelectedIndex);
    //        setItemCardObject.ItemPlaceId = Convert.ToString(cmbItemPlace.SelectedValue);
    //        setItemCardObject.ItemCost=0;
    //        if (chkExpiry.Enabled && chkExpiry.Checked == true) setItemCardObject.Expiry = "Y";
    //        else setItemCardObject.Expiry = "N";
    //        setItemCardObject.MinPrice = decimal.Parse(txtMinimumPrice.Text);
    //        setItemCardObject.Quantity = int.Parse(txtPackage.Text.Trim());
    //        setItemCardObject.Reorder = int.Parse(txtReorder.Text.Trim());
    //        setItemCardObject.Maxorder = int.Parse(txtMaxOrder.Text.Trim());
    //        setItemCardObject.Price = decimal.Parse(txtPrice.Text);
    //        setItemCardObject.WholeSalePrice = decimal.Parse(txtWholeSale.Text);
    //        setItemCardObject.CategoryId = Convert.ToString(cmbCategory.SelectedValue);
    //        setItemCardObject.CompId = Convert.ToString(cmbCompany.SelectedValue);
    //        if (picItemPhoto.Image!=null)
    //        {

    //            MemoryStream ms = new MemoryStream();
    //            this.picItemPhoto.Image.Save(ms,picItemPhoto.Image.RawFormat);
    //            byte[] itemimg = new byte[ms.Length];
    //            itemimg = ms.GetBuffer();
    //            setItemCardObject.Image = itemimg;

    //        }
    //        else
    //        {
    //            byte[] itemimg = new byte[1];
    //            itemimg[0] = 0;
    //            setItemCardObject.Image = itemimg;
    //        }
    //    }
          


        
    //    public void SetControlFromObject(ItemCardObjectClass getItemCardObject)
    //    {
          
       
    //        cmbItemName.Text = getItemCardObject.ItemId;
    //        cmbCategory.SelectedValue = getItemCardObject.CategoryId;
    //        cmbCompany.SelectedValue = getItemCardObject.CompId;
    //        cmbItemNo.SelectedValue = getItemCardObject.ItemId;
    //        txtBarcodes.Text = getItemCardObject.Barcode;
    //        cmbItemType.Text = getItemCardObject.ItemType;
    //        cmbItemPlace.SelectedValue = getItemCardObject.ItemPlaceId;
    //        txtCost.Text = getItemCardObject.ItemCost.ToString();
    //        if (getItemCardObject.Expiry == "True")
    //            chkExpiry.Checked = true;
    //        else
    //            chkExpiry.Checked = false;
    //        txtMinimumPrice.Text = getItemCardObject.MinPrice.ToString();
    //        txtPackage.Text = getItemCardObject.Quantity.ToString();
    //        txtReorder.Text = getItemCardObject.Reorder.ToString();
    //        txtMaxOrder.Text = getItemCardObject.Maxorder.ToString();
    //        txtPrice.Text = getItemCardObject.Price.ToString();
    //        txtWholeSale.Text = getItemCardObject.WholeSalePrice.ToString();
        
        
    //    }


      
    //   public void Clear()
    //    {
    //        cmbCategory.Text=string.Empty;
    //        cmbCompany.Text = string.Empty;
    //        cmbItemName.Text = string.Empty;
    //        cmbItemName.Text = string.Empty;
    //        cmbItemNo.SelectedIndex = -1;
    //        cmbItemPlace.Text = string.Empty;
    //        cmbItemPlace.SelectedIndex = -1;
    //        cmbItemNo.Focus();
    //        txtPackage.ReadOnly = false;
    //        txtBarcodes.Text = string.Empty;
    //        txtAverage.Text = string.Empty;
    //        txtCost.Text = string.Empty;
    //        txtLastCost.Text = string.Empty;
    //        txtStock.Text = string.Empty;
    //        txtTotalSpoiled.Text = string.Empty;
    //        txtProfitRate.Text = string.Empty;
    //        txtLastPurchases.Text = string.Empty;
    //        txtMaxOrder.Text = "100";
    //        txtPackage.Text = "1";
    //        txtReorder.Text = "1";
    //        txtMinimumPrice.Text = "0.000";
    //        txtPrice.Text = "0.000";
    //        txtWholeSale.Text = "0.000";
    //        chkHideItem.Checked = false;
           
        
            
    //    }

      

    //    private void btnSave_Click(object sender, EventArgs e)
    //    {
    //        this.SetObjectFromControl();
    //        ObjItemCardHelper.SaveItemDetail(setItemCardObject);
    //    }

    //    private void btnDelete_Click(object sender, EventArgs e)
    //    {
    //        ObjItemCardHelper.DeleteItemCard();
    //        this.Clear();
    //    }

    //    private void btnBrows_Click(object sender, EventArgs e)
    //    {
    //        ObjItemCardHelper.Browse();
    //    }

    //    private void btnClose_Click(object sender, EventArgs e)
    //    {
    //        if (GeneralFunction.Question(CommonHelper.Constants.CLOSE, ActionType.Close.ToString()) == DialogResult.OK)
    //            this.Close();

    //    }

    //    private void btnCancel_Click(object sender, EventArgs e)
    //    {
    //        this.Clear();
    //        txtBarcodes.Focus();
    //    }

    //    private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        ObjItemCardHelper.Cmb_ItemName_SelectedIndexChange();
    //    }

    //    public void txtPrice_Leave(object sender, EventArgs e)
    //    {

    //        try
    //        {
    //            if (txtPrice.Text!= string.Empty)
    //            {
    //                txtPrice.Text = Convert.ToDecimal(txtPrice.Text).ToString("0.000");
    //            }
    //            else
    //            {
    //                txtPrice.Text = "0.000";
    //            }
    //        }

    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //    private void txtMinimumPrice_Leave(object sender, EventArgs e)
    //    {

    //        if (txtMinimumPrice.Text != string.Empty)
    //        {
    //            if (Convert.ToDecimal(txtMinimumPrice.Text) > Convert.ToDecimal(txtPrice.Text))
    //            {
    //                GeneralFunction.Information("Minimum Price Should  be Lessthan or Equal to Price", this.Text + "Information");
    //                txtMinimumPrice.Focus();
    //                txtMinimumPrice.SelectAll();
    //            }
    //            else if (Convert.ToDecimal(txtMinimumPrice.Text) > Convert.ToDecimal(txtWholeSale.Text))
    //            {
    //                GeneralFunction.Information("Minimum Price Less than WholeSale Price", this.Text);
    //                txtMinimumPrice.Focus();
    //                txtMinimumPrice.SelectAll();
                    
    //            }
    //            else
    //            {
    //                txtMinimumPrice.Text = Convert.ToDecimal(txtMinimumPrice.Text).ToString("#####0.000");
    //            }
    //        }
    //        else
    //        {
    //            txtMinimumPrice.Text = "0.000";
    //        }


    //    }

    //   private void txtWholeSale_Leave(object sender, EventArgs e)
    //   {
    //        if (txtWholeSale.Text != string.Empty)
    //        {
    //            if (Convert.ToDecimal(txtWholeSale.Text) > Convert.ToDecimal(txtPrice.Text))
    //            {
    //                GeneralFunction.Information("WholeSale Price Less than Price", this.Text);
    //                txtWholeSale.Focus();
    //                txtWholeSale.SelectAll();

    //            }
    //            else
    //            {
    //                txtWholeSale.Text = Convert.ToDecimal(txtWholeSale.Text).ToString("#####0.000");
    //            }
    //        }
    //        else
    //        {
    //            txtWholeSale.Text = "0.000";
    //        }
    //    }
    //    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    //    {
    //        if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
    //        {
    //            GeneralFunction.Warning(Constants.NUMERSONLYMESSAGE, ActionType.All.ToString());
    //            e.Handled = true;
    //        }
    //    }
    //    private void txtReorder_KeyPress(object sender, KeyPressEventArgs e)
    //    {
    //        if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete)||(e.KeyChar=='.'))
    //        {
    //            e.Handled = true;
    //        }
    //    }

    //    private void btnPrintBarcode_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void btnGenerateBarcode_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void btnAdditionalBarcode_Click(object sender, EventArgs e)
    //    {

    //    }
    }
}
