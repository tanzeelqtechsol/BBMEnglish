using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ViewHelper;
using System.Threading;

namespace BumedianBM
{
    public partial class Item_Serial_Number : Form, IDisposable
    {
        internal string ItemName;
        internal int ItemID;
        internal string SerialNo, XSerialNo;
        internal Boolean Status;
        internal ItemSerialNoHelper objHelper;
        //internal bool IsSaveorUpdate;
        public Item_Serial_Number()
        {
            InitializeComponent();
            SetLanguage();
            SetFont();
            objHelper = new ItemSerialNoHelper();
            //txtItemName.Text = ItemName;

        }

        private void SetLanguage()
        {
            lblItemName.Text = Additional_Barcode.GetValueByResourceKey("ItemName");
            lblSerialNo.Text = Additional_Barcode.GetValueByResourceKey("SerialNo");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            this.Text = Additional_Barcode.GetValueByResourceKey("ItemSerialNo");
            dgvItemSerialNO.Columns["Item"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemName");
            dgvItemSerialNO.Columns["ItemSerialNo"].HeaderText = Additional_Barcode.GetValueByResourceKey("ItemSerialNo");
        }

        private void SetObjectFromControl()
        {
            objHelper.ObjBALClass.ObjPurchase.ItemNo = ItemID;
            objHelper.ObjBALClass.ObjPurchase.ItemName = ItemName;
            //objHelper.ObjBALClass.ObjPurchase.ItemSerialNo = txtSerialNO.Text.Trim() == string.Empty ? string.Empty : txtSerialNO.Text.Trim().Replace(" ", "");Commended on 10/10/2014
            objHelper.ObjBALClass.ObjPurchase.ItemSerialNo = txtSerialNO.Text.Trim() == string.Empty ? string.Empty : txtSerialNO.Text.Trim();
            SerialNo = objHelper.ObjBALClass.ObjPurchase.ItemSerialNo;
        }

        private void FillSerialNoDetails()
        {
            SetObjectFromControl();
            List<PurchaseObjectClass> ItemSerial = objHelper.FillSerialNumber();
            dgvItemSerialNO.AutoGenerateColumns = false;
            //if (ItemSerial.Count > 0)
            //{
            //    if (ItemSerial.Contains(objHelper.ObjBALClass.ObjPurchase.ItemName))
            //    {
            //        dgvItemSerialNO.DataSource = ItemSerial;
            //    }
            //}
            dgvItemSerialNO.DataSource = ItemSerial;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetObjectFromControl();
            objHelper.SaveSerialNo();
            if (objHelper.Save == true)
            {
                Status = true;
                this.Close();
                objHelper.Save = false;
            }
        }

        private void Item_Serial_Number_Load(object sender, EventArgs e)
        {

            Status = false;
            FillSerialNoDetails();

            if (ItemName != null)
            {
                txtItemName.Text = ItemName;
                //Txt_ItemName.Focus();
                txtSerialNO.Text = " ";

            }
            txtSerialNO.Text = " ";
            txtSerialNO.SelectAll();
            txtSerialNO.Focus();



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItemSerialNO.Rows.Count > 0)
            {
                if (dgvItemSerialNO.SelectedRows[0].Cells["Item"].Value.ToString() != "")
                {
                    objHelper.ObjBALClass.ObjPurchase.ItemName = dgvItemSerialNO.SelectedRows[0].Cells["Item"].Value.ToString();
                    //objHelper.ObjBALClass.ObjPurchase.ItemSerialNo = Convert.ToInt64(dgvItemSerialNO.SelectedRows[0].Cells["ItemSerialNo"].Value);
                    objHelper.ObjBALClass.ObjPurchase.ItemSerialNo = dgvItemSerialNO.SelectedRows[0].Cells["ItemSerialNo"].Value.ToString();
                    objHelper.DeleteSerialNo();
                    if (objHelper.Save)
                    {
                        // dgvItemSerialNO.Rows.Clear();
                        FillSerialNoDetails();
                    }
                }
            }
            else
            {
                GeneralFunction.ErrInfo("Invalid To Delete", this.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // if(GeneralFunction.Question(CommonHelper.Constants.CLOSE,this.Text)==DialogResult.Yes)
            this.Close();
        }

        private void dgvItemSerialNO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvItemSerialNO.Rows.Count > 0)
                {
                    if (dgvItemSerialNO.SelectedRows.Count > 0)
                    {
                        txtItemName.Text = dgvItemSerialNO.SelectedRows[0].Cells["Item"].Value.ToString();
                        txtSerialNO.Text = dgvItemSerialNO.SelectedRows[0].Cells["ItemSerialNo"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSerialNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            }
            else if (e.KeyChar == (char)Keys.Space && txtSerialNO.Text.Length == 0)
                e.Handled = true;

        }

        private void Item_Serial_Number_KeyDown(object sender, KeyEventArgs e)
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
                throw ex;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            objHelper.btnPrint();
        }
        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    if (cti is Button || cti is Label || cti is CheckBox || cti is RadioButton || cti is GroupBox)
                        cti.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control btn in groupBox1.Controls)
                {
                    if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is GroupBox)
                        btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
            }
        }

    }
}
