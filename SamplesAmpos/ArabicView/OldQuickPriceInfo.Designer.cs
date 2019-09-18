namespace BumedianBM.ArabicView
{
    partial class OldQuickPriceInfo
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.ImgPhoto = new System.Windows.Forms.PictureBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtWholesale = new System.Windows.Forms.TextBox();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblWholeSale = new System.Windows.Forms.Label();
            this.lblMinimumPrice = new System.Windows.Forms.Label();
            this.txtMinimumPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblPhoto.Location = new System.Drawing.Point(741, 56);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPhoto.Size = new System.Drawing.Size(71, 41);
            this.lblPhoto.TabIndex = 275;
            this.lblPhoto.Tag = "Photo";
            this.lblPhoto.Text = "الصورة\r\n";
            // 
            // ImgPhoto
            // 
            this.ImgPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgPhoto.Location = new System.Drawing.Point(669, 85);
            this.ImgPhoto.Name = "ImgPhoto";
            this.ImgPhoto.Size = new System.Drawing.Size(196, 225);
            this.ImgPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgPhoto.TabIndex = 274;
            this.ImgPhoto.TabStop = false;
            this.ImgPhoto.Visible = false;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtPrice.Location = new System.Drawing.Point(12, 179);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(205, 30);
            this.txtPrice.TabIndex = 273;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWholesale
            // 
            this.txtWholesale.BackColor = System.Drawing.Color.SeaShell;
            this.txtWholesale.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtWholesale.Location = new System.Drawing.Point(240, 179);
            this.txtWholesale.Name = "txtWholesale";
            this.txtWholesale.ReadOnly = true;
            this.txtWholesale.Size = new System.Drawing.Size(205, 30);
            this.txtWholesale.TabIndex = 272;
            this.txtWholesale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 300;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_128;
            this.btnClose.Location = new System.Drawing.Point(669, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 115);
            this.btnClose.TabIndex = 271;
            this.btnClose.Tag = "Exit";
            this.btnClose.Text = "خروج";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // txtExpiry
            // 
            this.txtExpiry.BackColor = System.Drawing.Color.Snow;
            this.txtExpiry.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.txtExpiry.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtExpiry.Location = new System.Drawing.Point(12, 260);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.ReadOnly = true;
            this.txtExpiry.Size = new System.Drawing.Size(428, 30);
            this.txtExpiry.TabIndex = 270;
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(349, 222);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExpiry.Size = new System.Drawing.Size(91, 41);
            this.lblExpiry.TabIndex = 269;
            this.lblExpiry.Tag = "Expiry";
            this.lblExpiry.Text = "الصلاحية\r\n";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtStock.Location = new System.Drawing.Point(467, 260);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(196, 30);
            this.txtStock.TabIndex = 268;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(579, 224);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStock.Size = new System.Drawing.Size(85, 41);
            this.lblStock.TabIndex = 267;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون\r\n";
            // 
            // lblWholeSale
            // 
            this.lblWholeSale.AutoSize = true;
            this.lblWholeSale.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblWholeSale.Location = new System.Drawing.Point(327, 138);
            this.lblWholeSale.Name = "lblWholeSale";
            this.lblWholeSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWholeSale.Size = new System.Drawing.Size(118, 41);
            this.lblWholeSale.TabIndex = 266;
            this.lblWholeSale.Tag = "WholeSale";
            this.lblWholeSale.Text = "سعر الجملة \r\n";
            // 
            // lblMinimumPrice
            // 
            this.lblMinimumPrice.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblMinimumPrice.Location = new System.Drawing.Point(458, 138);
            this.lblMinimumPrice.Name = "lblMinimumPrice";
            this.lblMinimumPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMinimumPrice.Size = new System.Drawing.Size(206, 41);
            this.lblMinimumPrice.TabIndex = 265;
            this.lblMinimumPrice.Tag = "MinPrice";
            this.lblMinimumPrice.Text = "اقل سعر\r\n";
            this.lblMinimumPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMinimumPrice
            // 
            this.txtMinimumPrice.BackColor = System.Drawing.Color.Snow;
            this.txtMinimumPrice.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtMinimumPrice.Location = new System.Drawing.Point(458, 179);
            this.txtMinimumPrice.Name = "txtMinimumPrice";
            this.txtMinimumPrice.ReadOnly = true;
            this.txtMinimumPrice.Size = new System.Drawing.Size(205, 30);
            this.txtMinimumPrice.TabIndex = 264;
            this.txtMinimumPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(92, 138);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrice.Size = new System.Drawing.Size(125, 41);
            this.lblPrice.TabIndex = 263;
            this.lblPrice.Tag = "QPrice";
            this.lblPrice.Text = "سعر الصنف\r\n";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.Color.White;
            this.txtItem.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtItem.Location = new System.Drawing.Point(12, 95);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItem.Size = new System.Drawing.Size(652, 30);
            this.txtItem.TabIndex = 262;
            this.txtItem.Visible = false;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblItem.Location = new System.Drawing.Point(554, 54);
            this.lblItem.Name = "lblItem";
            this.lblItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItem.Size = new System.Drawing.Size(110, 41);
            this.lblItem.TabIndex = 261;
            this.lblItem.Tag = "ItemName";
            this.lblItem.Text = "اسم الصنف\r\n";
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.Location = new System.Drawing.Point(569, 22);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemNo.Size = new System.Drawing.Size(157, 31);
            this.cmbItemNo.TabIndex = 260;
            // 
            // lblItemNo
            // 
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(732, 15);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(104, 41);
            this.lblItemNo.TabIndex = 259;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف\r\n";
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(12, 22);
            this.cmbItem.MaxDropDownItems = 6;
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItem.Size = new System.Drawing.Size(459, 31);
            this.cmbItem.TabIndex = 258;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 18F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(476, 15);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(73, 41);
            this.lblItemName.TabIndex = 257;
            this.lblItemName.Tag = "Item";
            this.lblItemName.Text = "الصنف\r\n";
            // 
            // OldQuickPriceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(877, 446);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.ImgPhoto);
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
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.cmbItemNo);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.lblItemName);
            this.Name = "OldQuickPriceInfo";
            this.Text = "OldQuickPriceInfo";
            this.Load += new System.EventHandler(this.OldQuickPriceInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhoto;
       // private DataSet dataSet1;
        private System.Windows.Forms.PictureBox ImgPhoto;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtWholesale;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblWholeSale;
        private System.Windows.Forms.Label lblMinimumPrice;
        private System.Windows.Forms.TextBox txtMinimumPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label lblItemName;


    }
}