namespace BumedianBM.ArabicView
{
    partial class PurchaseItemPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.cmbItemName = new SergeUtils.EasyCompletionComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcodes = new System.Windows.Forms.TextBox();
            this.lblPackagePCs = new System.Windows.Forms.Label();
            this.txtPackagePcs = new System.Windows.Forms.TextBox();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.MaskedTextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.MaskedTextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.MaskedTextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmbItemNo);
            this.panel1.Controls.Add(this.cmbItemName);
            this.panel1.Controls.Add(this.lblBarcode);
            this.panel1.Controls.Add(this.txtBarcodes);
            this.panel1.Controls.Add(this.lblPackagePCs);
            this.panel1.Controls.Add(this.txtPackagePcs);
            this.panel1.Controls.Add(this.lblItemPrice);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.chkExpiry);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.lblItemNo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 111);
            this.panel1.TabIndex = 134;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 435;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(250, 9);
            this.cmbItemNo.MaxDropDownItems = 35;
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemNo.Size = new System.Drawing.Size(137, 28);
            this.cmbItemNo.TabIndex = 1;
            this.cmbItemNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItemNo_KeyUp);
            // 
            // cmbItemName
            // 
            this.cmbItemName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItemName.DropDownHeight = 400;
            this.cmbItemName.DropDownWidth = 474;
            this.cmbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.IntegralHeight = false;
            this.cmbItemName.ItemHeight = 20;
            this.cmbItemName.Location = new System.Drawing.Point(492, 11);
            this.cmbItemName.MaxDropDownItems = 15;
            this.cmbItemName.MaxLength = 200;
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemName.Size = new System.Drawing.Size(466, 26);
            this.cmbItemName.TabIndex = 0;
            this.cmbItemName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbItemName_DrawItem);
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            this.cmbItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemName_KeyPress);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(157, 9);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBarcode.Size = new System.Drawing.Size(87, 31);
            this.lblBarcode.TabIndex = 151;
            this.lblBarcode.Tag = "Barcode";
            this.lblBarcode.Text = "باركود \r\n";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcodes
            // 
            this.txtBarcodes.BackColor = System.Drawing.Color.FloralWhite;
            this.txtBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBarcodes.Location = new System.Drawing.Point(6, 11);
            this.txtBarcodes.MaxLength = 13;
            this.txtBarcodes.Name = "txtBarcodes";
            this.txtBarcodes.ReadOnly = true;
            this.txtBarcodes.Size = new System.Drawing.Size(147, 27);
            this.txtBarcodes.TabIndex = 152;
            // 
            // lblPackagePCs
            // 
            this.lblPackagePCs.Location = new System.Drawing.Point(368, 52);
            this.lblPackagePCs.Name = "lblPackagePCs";
            this.lblPackagePCs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPackagePCs.Size = new System.Drawing.Size(114, 28);
            this.lblPackagePCs.TabIndex = 146;
            this.lblPackagePCs.Tag = "PackagePiece";
            this.lblPackagePCs.Text = "عدد القطع بالعلبة";
            this.lblPackagePCs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackagePcs
            // 
            this.txtPackagePcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPackagePcs.Location = new System.Drawing.Point(288, 53);
            this.txtPackagePcs.MaxLength = 18;
            this.txtPackagePcs.Name = "txtPackagePcs";
            this.txtPackagePcs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPackagePcs.Size = new System.Drawing.Size(80, 27);
            this.txtPackagePcs.TabIndex = 4;
            this.txtPackagePcs.Text = "1";
            this.txtPackagePcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            this.txtPackagePcs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackagePcs_KeyPress);
            this.txtPackagePcs.Leave += new System.EventHandler(this.txtPackagePcs_Leave);
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Location = new System.Drawing.Point(183, 51);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemPrice.Size = new System.Drawing.Size(97, 28);
            this.lblItemPrice.TabIndex = 144;
            this.lblItemPrice.Tag = "ItemPrice";
            this.lblItemPrice.Text = "سعر الصنف";
            this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Location = new System.Drawing.Point(103, 53);
            this.txtPrice.MaxLength = 20;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(80, 26);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Text = "0.000";
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // chkExpiry
            // 
            this.chkExpiry.Location = new System.Drawing.Point(3, 53);
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkExpiry.Size = new System.Drawing.Size(94, 35);
            this.chkExpiry.TabIndex = 6;
            this.chkExpiry.Tag = "Expiry";
            this.chkExpiry.Text = "استخدام الصلاحية";
            this.chkExpiry.UseVisualStyleBackColor = true;
            this.chkExpiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            this.chkExpiry.Leave += new System.EventHandler(this.chkExpiry_Leave);
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Location = new System.Drawing.Point(670, 49);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCompany.Size = new System.Drawing.Size(121, 28);
            this.lblCompany.TabIndex = 143;
            this.lblCompany.Tag = "Company";
            this.lblCompany.Text = "الشركة";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DisplayMember = "CompanyName";
            this.cmbCompany.DropDownHeight = 350;
            this.cmbCompany.DropDownWidth = 350;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Location = new System.Drawing.Point(492, 51);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCompany.Size = new System.Drawing.Size(172, 28);
            this.cmbCompany.TabIndex = 3;
            this.cmbCompany.ValueMember = "CompanyID";
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Location = new System.Drawing.Point(965, 49);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCategory.Size = new System.Drawing.Size(97, 25);
            this.lblCategory.TabIndex = 142;
            this.lblCategory.Tag = "Category";
            this.lblCategory.Text = "المجموعة";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.DropDownHeight = 350;
            this.cmbCategory.DropDownWidth = 350;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Location = new System.Drawing.Point(797, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCategory.Size = new System.Drawing.Size(161, 28);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.ValueMember = "CategoryID";
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName.Location = new System.Drawing.Point(964, 11);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemName.Size = new System.Drawing.Size(97, 31);
            this.lblItemName.TabIndex = 141;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "اسم الصنف\r\n";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemNo
            // 
            this.lblItemNo.Location = new System.Drawing.Point(393, 11);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemNo.Size = new System.Drawing.Size(99, 31);
            this.lblItemNo.TabIndex = 140;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف\r\n";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblItemNo.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.Controls.Add(this.dtpExpiry, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblExpiry, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtStock, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblStock, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantity, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblQty, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPurchasePrice, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCost, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCost, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 117);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1068, 64);
            this.tableLayoutPanel2.TabIndex = 135;
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(3, 35);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpExpiry.RightToLeftLayout = true;
            this.dtpExpiry.Size = new System.Drawing.Size(248, 26);
            this.dtpExpiry.TabIndex = 11;
            this.dtpExpiry.Value = new System.DateTime(2013, 12, 3, 0, 0, 0, 0);
            this.dtpExpiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategory_KeyDown);
            this.dtpExpiry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpExpiry_KeyPress);
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(137, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExpiry.Size = new System.Drawing.Size(114, 31);
            this.lblExpiry.TabIndex = 428;
            this.lblExpiry.Tag = "Expiry";
            this.lblExpiry.Text = "الصلاحية";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtStock.Location = new System.Drawing.Point(257, 35);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStock.Size = new System.Drawing.Size(197, 27);
            this.txtStock.TabIndex = 10;
            this.txtStock.Text = "1";
            // 
            // lblStock
            // 
            this.lblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStock.AutoEllipsis = true;
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(357, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStock.Size = new System.Drawing.Size(97, 31);
            this.lblStock.TabIndex = 418;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.Location = new System.Drawing.Point(460, 35);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(197, 27);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.Text = "1";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            this.txtQuantity.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblQty
            // 
            this.lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQty.AutoEllipsis = true;
            this.lblQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblQty.Location = new System.Drawing.Point(558, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblQty.Size = new System.Drawing.Size(99, 31);
            this.lblQty.TabIndex = 417;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPurchasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPurchasePrice.Location = new System.Drawing.Point(663, 35);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPurchasePrice.Size = new System.Drawing.Size(197, 27);
            this.txtPurchasePrice.SkipLiterals = false;
            this.txtPurchasePrice.TabIndex = 8;
            this.txtPurchasePrice.Text = "0.000";
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtPurchasePrice.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(761, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrice.Size = new System.Drawing.Size(99, 31);
            this.lblPrice.TabIndex = 420;
            this.lblPrice.Tag = "Price";
            this.lblPrice.Text = "السعر";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCost
            // 
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(866, 35);
            this.txtCost.Name = "txtCost";
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCost.Size = new System.Drawing.Size(199, 27);
            this.txtCost.TabIndex = 7;
            this.txtCost.Text = "0.000";
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtCost.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCost.Location = new System.Drawing.Point(985, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCost.Size = new System.Drawing.Size(80, 31);
            this.lblCost.TabIndex = 416;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "سعر الشراء";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::BumedianBM.Properties.Resources.item_save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(901, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(170, 40);
            this.btnSave.TabIndex = 137;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n F5";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(126, 41);
            this.btnClose.TabIndex = 140;
            this.btnClose.Tag = "Exit";
            this.btnClose.Text = "اغلاق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PurchaseItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1073, 229);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseItemPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Item Panel";
            this.Load += new System.EventHandler(this.PurchaseItemPanel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PurchaseItemPanel_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblItemPrice;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.CheckBox chkExpiry;
        public System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.ComboBox cmbCompany;
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.ComboBox cmbCategory;
        public System.Windows.Forms.Label lblItemName;
        public System.Windows.Forms.Label lblItemNo;
        public System.Windows.Forms.Label lblPackagePCs;
        public System.Windows.Forms.TextBox txtPackagePcs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.MaskedTextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.MaskedTextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.MaskedTextBox txtCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblBarcode;
        public System.Windows.Forms.TextBox txtBarcodes;
        public SergeUtils.EasyCompletionComboBox cmbItemName;
        private System.Windows.Forms.ComboBox cmbItemNo;
    }
}