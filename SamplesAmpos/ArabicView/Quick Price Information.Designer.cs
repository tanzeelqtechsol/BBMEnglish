namespace BumedianBM.ArabicView
{
    partial class Quick_Price_Information
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            System.GC.SuppressFinalize(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtWholesale = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblWholeSale = new System.Windows.Forms.Label();
            this.lblMinimumPrice = new System.Windows.Forms.Label();
            this.txtMinimumPrice = new System.Windows.Forms.TextBox();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.lblPrice = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.txtPrice.Location = new System.Drawing.Point(7, 135);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(205, 62);
            this.txtPrice.TabIndex = 254;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWholesale
            // 
            this.txtWholesale.BackColor = System.Drawing.Color.SeaShell;
            this.txtWholesale.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.txtWholesale.Location = new System.Drawing.Point(248, 135);
            this.txtWholesale.Name = "txtWholesale";
            this.txtWholesale.ReadOnly = true;
            this.txtWholesale.Size = new System.Drawing.Size(205, 62);
            this.txtWholesale.TabIndex = 253;
            this.txtWholesale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_128;
            this.btnClose.Location = new System.Drawing.Point(682, 135);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 115);
            this.btnClose.TabIndex = 252;
            this.btnClose.Tag = "Exit";
            this.btnClose.Text = "خروج";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtExpiry
            // 
            this.txtExpiry.BackColor = System.Drawing.SystemColors.Control;
            this.txtExpiry.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.txtExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.txtExpiry.Location = new System.Drawing.Point(7, 255);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.ReadOnly = true;
            this.txtExpiry.Size = new System.Drawing.Size(428, 62);
            this.txtExpiry.TabIndex = 251;
            this.txtExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(285, 212);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExpiry.Size = new System.Drawing.Size(150, 41);
            this.lblExpiry.TabIndex = 250;
            this.lblExpiry.Tag = "Expiry";
            this.lblExpiry.Text = "الصلاحية\r\n";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.txtStock.Location = new System.Drawing.Point(473, 255);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(196, 62);
            this.txtStock.TabIndex = 249;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(525, 211);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStock.Size = new System.Drawing.Size(144, 41);
            this.lblStock.TabIndex = 248;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون\r\n";
            // 
            // lblWholeSale
            // 
            this.lblWholeSale.AutoSize = true;
            this.lblWholeSale.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblWholeSale.Location = new System.Drawing.Point(335, 94);
            this.lblWholeSale.Name = "lblWholeSale";
            this.lblWholeSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWholeSale.Size = new System.Drawing.Size(118, 41);
            this.lblWholeSale.TabIndex = 247;
            this.lblWholeSale.Tag = "WholeSale";
            this.lblWholeSale.Text = "سعر الجملة \r\n";
            // 
            // lblMinimumPrice
            // 
            this.lblMinimumPrice.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblMinimumPrice.Location = new System.Drawing.Point(463, 94);
            this.lblMinimumPrice.Name = "lblMinimumPrice";
            this.lblMinimumPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMinimumPrice.Size = new System.Drawing.Size(206, 41);
            this.lblMinimumPrice.TabIndex = 246;
            this.lblMinimumPrice.Tag = "MinPrice";
            this.lblMinimumPrice.Text = "اقل سعر\r\n";
            this.lblMinimumPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMinimumPrice
            // 
            this.txtMinimumPrice.BackColor = System.Drawing.Color.Snow;
            this.txtMinimumPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.txtMinimumPrice.Location = new System.Drawing.Point(464, 135);
            this.txtMinimumPrice.Name = "txtMinimumPrice";
            this.txtMinimumPrice.ReadOnly = true;
            this.txtMinimumPrice.Size = new System.Drawing.Size(205, 62);
            this.txtMinimumPrice.TabIndex = 245;
            this.txtMinimumPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(12, 94);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrice.Size = new System.Drawing.Size(200, 41);
            this.lblPrice.TabIndex = 244;
            this.lblPrice.Tag = "Price";
            this.lblPrice.Text = "سعر الصنف\r\n";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 400;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(286, 52);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemNo.Size = new System.Drawing.Size(383, 39);
            this.cmbItemNo.TabIndex = 241;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItem_KeyPress);
            // 
            // lblItemNo
            // 
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(675, 52);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(104, 41);
            this.lblItemNo.TabIndex = 240;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف\r\n";
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.DropDownHeight = 450;
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.IntegralHeight = false;
            this.cmbItem.Location = new System.Drawing.Point(2, 7);
            this.cmbItem.MaxDropDownItems = 6;
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItem.Size = new System.Drawing.Size(667, 39);
            this.cmbItem.TabIndex = 239;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            this.cmbItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItem_KeyPress);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(675, 5);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(73, 41);
            this.lblItemName.TabIndex = 238;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "الصنف\r\n";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(318, 245);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 36);
            this.txtBarcode.TabIndex = 255;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // Quick_Price_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(806, 324);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtWholesale);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtExpiry);
            this.Controls.Add(this.lblExpiry);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblWholeSale);
            this.Controls.Add(this.lblMinimumPrice);
            this.Controls.Add(this.txtMinimumPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbItemNo);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quick_Price_Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "QuickPriceInformation";
            this.Text = "Quick Price Information";
            this.Load += new System.EventHandler(this.Quick_Price_Information_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quick_Price_Information_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtWholesale;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblWholeSale;
        private System.Windows.Forms.Label lblMinimumPrice;
        private System.Windows.Forms.TextBox txtMinimumPrice;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label lblItemName;
       // private DataSet dataSet1;
        private System.Windows.Forms.TextBox txtBarcode;

    }
}