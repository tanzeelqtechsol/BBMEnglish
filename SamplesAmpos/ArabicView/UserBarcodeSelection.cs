using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class UserBarcodeSelection : Form
    {
        DataTable BarcodeDt = new DataTable();
        string Barcode = string.Empty;
        string ExportItem = string.Empty;
        public int BarcodeId = 0;
        public bool IsClose = false;
        public UserBarcodeSelection(DataTable dt,string Barcode,string ExportItem)
        {
            InitializeComponent();
            BarcodeDt = dt;
            this.Barcode = Barcode;
            this.ExportItem = ExportItem;
            SetLanguage();
            
        }

        private void UserBarcodeSelection_Load(object sender, EventArgs e)
        {
            lblBarcodeNo.Text = Barcode;
            int y = 5;
            Label lbl = new Label();
            lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lbl.AutoSize = false;
            lbl.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Location = new System.Drawing.Point(338, y);
            lbl.Name = "lblItemBarcode";
            lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lbl.Size = new System.Drawing.Size(218, 25);
            lbl.TabIndex = 444;
            lbl.Text = Additional_Barcode.GetValueByResourceKey("BarcodeItemImport");
            this.pnlBarcodeItems.Controls.Add(lbl);

            y += 30;

            RadioButton rdo = new RadioButton();
            rdo.Location = new System.Drawing.Point(20, y);
            rdo.Name = "0";
            rdo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            rdo.Size = new System.Drawing.Size(525, 33);
            rdo.TabIndex = 445;
            rdo.TabStop = true;
            rdo.Text = ExportItem;
            rdo.UseVisualStyleBackColor = true;
            rdo.Checked = true;
            rdo.Click += new EventHandler(radio_Click);
            this.pnlBarcodeItems.Controls.Add(rdo);

            y += 43;

            Label lbl2 = new Label();
            lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lbl2.AutoSize = false;
            lbl2.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            lbl2.ForeColor = System.Drawing.Color.Black;
            lbl2.Location = new System.Drawing.Point(338, y);
            lbl2.Name = "lblBarcodeItemImport";
            lbl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            lbl2.Size = new System.Drawing.Size(218, 25);
            lbl2.TabIndex = 444;
            lbl2.Text = Additional_Barcode.GetValueByResourceKey("BarcodeItemSame");
            this.pnlBarcodeItems.Controls.Add(lbl2);

            for (int i = 0; i < BarcodeDt.Rows.Count; i++)
            {
                y += 43;
                RadioButton rdo1 = new RadioButton();
                rdo1.Location = new System.Drawing.Point(20, y);
                rdo1.Name = BarcodeDt.Rows[i][1].ToString();
                rdo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                rdo1.Size = new System.Drawing.Size(525, 33);
                rdo1.TabIndex = 445;
                rdo1.TabStop = true;
                rdo1.Text = BarcodeDt.Rows[i][2].ToString(); 
                rdo1.UseVisualStyleBackColor = true;
                rdo1.Click += new EventHandler(radio_Click);
                this.pnlBarcodeItems.Controls.Add(rdo1);
                
            }
            IsClose = false;
        }

        private void SetLanguage()
        {
            lblBarcode.Text = Additional_Barcode.GetValueByResourceKey("Barcode");
            btnAssign.Text = Additional_Barcode.GetValueByResourceKey("Assign");
            lblAttention.Text = Additional_Barcode.GetValueByResourceKey("Attention");
            lblSelection.Text = Additional_Barcode.GetValueByResourceKey("BarcodeSelectionNote");
            lblNote.Text = Additional_Barcode.GetValueByResourceKey("Note");
            lblNoteText.Text = Additional_Barcode.GetValueByResourceKey("BarcodeNote");
            btnClose.Text= Additional_Barcode.GetValueByResourceKey("Cancel"); 
            this.Text= Additional_Barcode.GetValueByResourceKey("BarcodeHeading"); 

        }

        void radio_Click(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Name != "0")
            {
                BarcodeId = Convert.ToInt32(r.Name);
            }
            else
            {
                BarcodeId = 0;
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            IsClose = true;
        }
    }
}
