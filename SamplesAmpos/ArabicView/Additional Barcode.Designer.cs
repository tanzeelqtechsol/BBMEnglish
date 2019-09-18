namespace BumedianBM.ArabicView
{
    partial class Additional_Barcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Additional_Barcode));
            this.Lbl_Barcod = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvBarcode = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholeSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitTypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitTypesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.lbl_UnitName = new System.Windows.Forms.Label();
            this.lbl_PriceField = new System.Windows.Forms.Label();
            this.txt_ItemPrice = new System.Windows.Forms.TextBox();
            this.lbl_PackageQty = new System.Windows.Forms.Label();
            this.lbl_Cost = new System.Windows.Forms.Label();
            this.cmb_UnitName = new System.Windows.Forms.ComboBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.cmb_UnitQuantity = new System.Windows.Forms.ComboBox();
            this.lbl_UnitQuantity = new System.Windows.Forms.Label();
            this.cmb_Types = new System.Windows.Forms.ComboBox();
            this.lbl_UnitTypes = new System.Windows.Forms.Label();
            this.lbl_Types = new System.Windows.Forms.Label();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtBarcodes = new System.Windows.Forms.TextBox();
            this.lbl_WholeSale = new System.Windows.Forms.Label();
            this.txt_WholeSale = new System.Windows.Forms.TextBox();
            this.lbl_MinPrice = new System.Windows.Forms.Label();
            this.txt_MinPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Barcod
            // 
            this.Lbl_Barcod.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Lbl_Barcod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Barcod.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Barcod.Location = new System.Drawing.Point(4, 2);
            this.Lbl_Barcod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Barcod.Name = "Lbl_Barcod";
            this.Lbl_Barcod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Barcod.Size = new System.Drawing.Size(146, 30);
            this.Lbl_Barcod.TabIndex = 36;
            this.Lbl_Barcod.Tag = "Barcode";
            this.Lbl_Barcod.Text = "باركود \r\n";
            this.Lbl_Barcod.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(444, 370);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(150, 41);
            this.btnClose.TabIndex = 8;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(444, 327);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(150, 41);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(444, 284);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(150, 41);
            this.btnSave.TabIndex = 6;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            this.dgvBarcode.AllowUserToResizeColumns = false;
            this.dgvBarcode.AllowUserToResizeRows = false;
            this.dgvBarcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarcode.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBarcode.ColumnHeadersHeight = 25;
            this.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBarcode.ColumnHeadersVisible = false;
            this.dgvBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.ItemCost,
            this.WholeSalePrice,
            this.MinPrice,
            this.UnitName,
            this.PackageQuantity,
            this.Price,
            this.BarcodeID,
            this.UnitQuantity,
            this.UnitTypes,
            this.ItemId,
            this.UnitNameID,
            this.UnitTypesID});
            this.dgvBarcode.Location = new System.Drawing.Point(4, 32);
            this.dgvBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.RowHeadersVisible = false;
            this.dgvBarcode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarcode.Size = new System.Drawing.Size(433, 422);
            this.dgvBarcode.TabIndex = 34;
            this.dgvBarcode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellClick);
            // 
            // Barcode
            // 
            this.Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 145;
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Barcode.Width = 145;
            // 
            // ItemCost
            // 
            this.ItemCost.DataPropertyName = "ItemCost";
            this.ItemCost.HeaderText = "ItemCost";
            this.ItemCost.Name = "ItemCost";
            this.ItemCost.Visible = false;
            // 
            // WholeSalePrice
            // 
            this.WholeSalePrice.DataPropertyName = "WholeSalePrice";
            this.WholeSalePrice.HeaderText = "WholeSalePrice";
            this.WholeSalePrice.Name = "WholeSalePrice";
            this.WholeSalePrice.Visible = false;
            // 
            // MinPrice
            // 
            this.MinPrice.DataPropertyName = "MinPrice";
            this.MinPrice.HeaderText = "MinPrice";
            this.MinPrice.Name = "MinPrice";
            this.MinPrice.Visible = false;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "UnitName";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // PackageQuantity
            // 
            this.PackageQuantity.DataPropertyName = "PackageQuantity";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PackageQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.PackageQuantity.HeaderText = "PackageQty";
            this.PackageQuantity.Name = "PackageQuantity";
            this.PackageQuantity.ReadOnly = true;
            this.PackageQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BarcodeID
            // 
            this.BarcodeID.DataPropertyName = "BarcodeId";
            this.BarcodeID.HeaderText = "ID";
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.ReadOnly = true;
            this.BarcodeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BarcodeID.Visible = false;
            // 
            // UnitQuantity
            // 
            this.UnitQuantity.DataPropertyName = "UnitQuantity";
            this.UnitQuantity.HeaderText = "UnitQuantity";
            this.UnitQuantity.Name = "UnitQuantity";
            this.UnitQuantity.ReadOnly = true;
            this.UnitQuantity.Visible = false;
            // 
            // UnitTypes
            // 
            this.UnitTypes.DataPropertyName = "UnitTypes";
            this.UnitTypes.HeaderText = "UnitTypes";
            this.UnitTypes.Name = "UnitTypes";
            this.UnitTypes.ReadOnly = true;
            this.UnitTypes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitTypes.Visible = false;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemId.Visible = false;
            // 
            // UnitNameID
            // 
            this.UnitNameID.DataPropertyName = "UnitNameID";
            this.UnitNameID.HeaderText = "UnitNameID";
            this.UnitNameID.Name = "UnitNameID";
            this.UnitNameID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitNameID.Visible = false;
            // 
            // UnitTypesID
            // 
            this.UnitTypesID.DataPropertyName = "UnitTypesID";
            this.UnitTypesID.HeaderText = "UnitTypesID";
            this.UnitTypesID.Name = "UnitTypesID";
            this.UnitTypesID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UnitTypesID.Visible = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.Location = new System.Drawing.Point(607, 3);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBarcode.Size = new System.Drawing.Size(54, 31);
            this.lblBarcode.TabIndex = 35;
            this.lblBarcode.Tag = "Barcode";
            this.lblBarcode.Text = "باركود \r\n";
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBarcode.Image = global::BumedianBM.Properties.Resources.generate_barcode_321;
            this.btnBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarcode.Location = new System.Drawing.Point(444, 241);
            this.btnBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBarcode.Size = new System.Drawing.Size(150, 41);
            this.btnBarcode.TabIndex = 250;
            this.btnBarcode.Tag = "GenerateBarcode";
            this.btnBarcode.Text = "اصدار باركود ";
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // lbl_UnitName
            // 
            this.lbl_UnitName.AutoSize = true;
            this.lbl_UnitName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_UnitName.Location = new System.Drawing.Point(607, 42);
            this.lbl_UnitName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UnitName.Name = "lbl_UnitName";
            this.lbl_UnitName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_UnitName.Size = new System.Drawing.Size(68, 31);
            this.lbl_UnitName.TabIndex = 39;
            this.lbl_UnitName.Tag = "UnitName";
            this.lbl_UnitName.Text = "اسم وحدة";
            // 
            // lbl_PriceField
            // 
            this.lbl_PriceField.AutoSize = true;
            this.lbl_PriceField.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_PriceField.Location = new System.Drawing.Point(607, 123);
            this.lbl_PriceField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PriceField.Name = "lbl_PriceField";
            this.lbl_PriceField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_PriceField.Size = new System.Drawing.Size(47, 31);
            this.lbl_PriceField.TabIndex = 41;
            this.lbl_PriceField.Tag = "Price";
            this.lbl_PriceField.Text = "السعر";
            // 
            // txt_ItemPrice
            // 
            this.txt_ItemPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txt_ItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txt_ItemPrice.Location = new System.Drawing.Point(444, 125);
            this.txt_ItemPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ItemPrice.MaxLength = 13;
            this.txt_ItemPrice.Name = "txt_ItemPrice";
            this.txt_ItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_ItemPrice.Size = new System.Drawing.Size(158, 27);
            this.txt_ItemPrice.TabIndex = 3;
            this.txt_ItemPrice.Text = "0.00";
            this.txt_ItemPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            this.txt_ItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ItemPrice_KeyPress);
            // 
            // lbl_PackageQty
            // 
            this.lbl_PackageQty.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_PackageQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PackageQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_PackageQty.Location = new System.Drawing.Point(244, 2);
            this.lbl_PackageQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PackageQty.Name = "lbl_PackageQty";
            this.lbl_PackageQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_PackageQty.Size = new System.Drawing.Size(95, 30);
            this.lbl_PackageQty.TabIndex = 42;
            this.lbl_PackageQty.Tag = "PackageQty";
            this.lbl_PackageQty.Text = "حزمة الكمية";
            this.lbl_PackageQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Cost
            // 
            this.lbl_Cost.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_Cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Cost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Cost.Location = new System.Drawing.Point(339, 2);
            this.lbl_Cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Cost.Name = "lbl_Cost";
            this.lbl_Cost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Cost.Size = new System.Drawing.Size(98, 30);
            this.lbl_Cost.TabIndex = 43;
            this.lbl_Cost.Tag = "Price";
            this.lbl_Cost.Text = "السعر";
            this.lbl_Cost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmb_UnitName
            // 
            this.cmb_UnitName.DisplayMember = "Name";
            this.cmb_UnitName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnitName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_UnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_UnitName.FormattingEnabled = true;
            this.cmb_UnitName.Items.AddRange(new object[] {
            "Cartoon",
            "Box",
            "Piece"});
            this.cmb_UnitName.Location = new System.Drawing.Point(444, 43);
            this.cmb_UnitName.Name = "cmb_UnitName";
            this.cmb_UnitName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_UnitName.Size = new System.Drawing.Size(158, 28);
            this.cmb_UnitName.TabIndex = 1;
            this.cmb_UnitName.ValueMember = "ID";
            this.cmb_UnitName.SelectedIndexChanged += new System.EventHandler(this.cmb_UnitName_SelectedIndexChanged);
            this.cmb_UnitName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Clear.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(444, 413);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Clear.Size = new System.Drawing.Size(150, 41);
            this.btn_Clear.TabIndex = 50;
            this.btn_Clear.Tag = "Clear";
            this.btn_Clear.Text = "واضح";
            this.btn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // cmb_UnitQuantity
            // 
            this.cmb_UnitQuantity.DisplayMember = "UnitQuantity";
            this.cmb_UnitQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnitQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_UnitQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_UnitQuantity.FormattingEnabled = true;
            this.cmb_UnitQuantity.Items.AddRange(new object[] {
            "Cartoon",
            "Box",
            "Piece"});
            this.cmb_UnitQuantity.Location = new System.Drawing.Point(443, 83);
            this.cmb_UnitQuantity.Name = "cmb_UnitQuantity";
            this.cmb_UnitQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_UnitQuantity.Size = new System.Drawing.Size(158, 28);
            this.cmb_UnitQuantity.TabIndex = 2;
            this.cmb_UnitQuantity.ValueMember = "ID";
            this.cmb_UnitQuantity.SelectedIndexChanged += new System.EventHandler(this.cmb_UnitQuantity_SelectedIndexChanged);
            this.cmb_UnitQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // lbl_UnitQuantity
            // 
            this.lbl_UnitQuantity.AutoSize = true;
            this.lbl_UnitQuantity.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_UnitQuantity.Location = new System.Drawing.Point(605, 82);
            this.lbl_UnitQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UnitQuantity.Name = "lbl_UnitQuantity";
            this.lbl_UnitQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_UnitQuantity.Size = new System.Drawing.Size(80, 31);
            this.lbl_UnitQuantity.TabIndex = 54;
            this.lbl_UnitQuantity.Tag = "UnitQuantity";
            this.lbl_UnitQuantity.Text = "وحدة الكمية";
            // 
            // cmb_Types
            // 
            this.cmb_Types.DisplayMember = "Name";
            this.cmb_Types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Types.FormattingEnabled = true;
            this.cmb_Types.Location = new System.Drawing.Point(620, 358);
            this.cmb_Types.Name = "cmb_Types";
            this.cmb_Types.Size = new System.Drawing.Size(41, 37);
            this.cmb_Types.TabIndex = 51;
            this.cmb_Types.ValueMember = "ID";
            this.cmb_Types.Visible = false;
            // 
            // lbl_UnitTypes
            // 
            this.lbl_UnitTypes.AutoSize = true;
            this.lbl_UnitTypes.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_UnitTypes.Location = new System.Drawing.Point(604, 398);
            this.lbl_UnitTypes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UnitTypes.Name = "lbl_UnitTypes";
            this.lbl_UnitTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_UnitTypes.Size = new System.Drawing.Size(81, 31);
            this.lbl_UnitTypes.TabIndex = 53;
            this.lbl_UnitTypes.Tag = "UnitTypes";
            this.lbl_UnitTypes.Text = "أنواع وحدة ";
            this.lbl_UnitTypes.Visible = false;
            // 
            // lbl_Types
            // 
            this.lbl_Types.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_Types.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Types.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Types.Location = new System.Drawing.Point(149, 2);
            this.lbl_Types.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Types.Name = "lbl_Types";
            this.lbl_Types.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Types.Size = new System.Drawing.Size(96, 30);
            this.lbl_Types.TabIndex = 44;
            this.lbl_Types.Tag = "UnitName";
            this.lbl_Types.Text = "اسم وحدة";
            this.lbl_Types.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(444, 13);
            this.txtBarcode.MaxLength = 100;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(65, 20);
            this.txtBarcode.TabIndex = 133;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // txtBarcodes
            // 
            this.txtBarcodes.BackColor = System.Drawing.Color.FloralWhite;
            this.txtBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBarcodes.Location = new System.Drawing.Point(443, 5);
            this.txtBarcodes.MaxLength = 13;
            this.txtBarcodes.Name = "txtBarcodes";
            this.txtBarcodes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBarcodes.Size = new System.Drawing.Size(158, 27);
            this.txtBarcodes.TabIndex = 0;
            this.txtBarcodes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            // 
            // lbl_WholeSale
            // 
            this.lbl_WholeSale.AutoSize = true;
            this.lbl_WholeSale.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_WholeSale.Location = new System.Drawing.Point(607, 161);
            this.lbl_WholeSale.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_WholeSale.Name = "lbl_WholeSale";
            this.lbl_WholeSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_WholeSale.Size = new System.Drawing.Size(80, 31);
            this.lbl_WholeSale.TabIndex = 252;
            this.lbl_WholeSale.Tag = "WholeSale";
            this.lbl_WholeSale.Text = "سعر الجملة";
            // 
            // txt_WholeSale
            // 
            this.txt_WholeSale.BackColor = System.Drawing.Color.SeaShell;
            this.txt_WholeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txt_WholeSale.Location = new System.Drawing.Point(444, 163);
            this.txt_WholeSale.Margin = new System.Windows.Forms.Padding(4);
            this.txt_WholeSale.MaxLength = 13;
            this.txt_WholeSale.Name = "txt_WholeSale";
            this.txt_WholeSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_WholeSale.Size = new System.Drawing.Size(158, 27);
            this.txt_WholeSale.TabIndex = 4;
            this.txt_WholeSale.Text = "0.00";
            this.txt_WholeSale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            this.txt_WholeSale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ItemPrice_KeyPress);
            this.txt_WholeSale.Leave += new System.EventHandler(this.txt_WholeSale_Leave);
            // 
            // lbl_MinPrice
            // 
            this.lbl_MinPrice.AutoSize = true;
            this.lbl_MinPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_MinPrice.Location = new System.Drawing.Point(607, 197);
            this.lbl_MinPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MinPrice.Name = "lbl_MinPrice";
            this.lbl_MinPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_MinPrice.Size = new System.Drawing.Size(62, 31);
            this.lbl_MinPrice.TabIndex = 254;
            this.lbl_MinPrice.Tag = "MinPrice";
            this.lbl_MinPrice.Text = "اقل سعر";
            // 
            // txt_MinPrice
            // 
            this.txt_MinPrice.BackColor = System.Drawing.Color.Snow;
            this.txt_MinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txt_MinPrice.Location = new System.Drawing.Point(444, 199);
            this.txt_MinPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MinPrice.MaxLength = 13;
            this.txt_MinPrice.Name = "txt_MinPrice";
            this.txt_MinPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_MinPrice.Size = new System.Drawing.Size(158, 27);
            this.txt_MinPrice.TabIndex = 5;
            this.txt_MinPrice.Text = "0.00";
            this.txt_MinPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_Types_KeyDown);
            this.txt_MinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ItemPrice_KeyPress);
            this.txt_MinPrice.Leave += new System.EventHandler(this.txt_MinPrice_Leave);
            // 
            // Additional_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(725, 456);
            this.Controls.Add(this.lbl_MinPrice);
            this.Controls.Add(this.txt_MinPrice);
            this.Controls.Add(this.lbl_WholeSale);
            this.Controls.Add(this.txt_WholeSale);
            this.Controls.Add(this.txtBarcodes);
            this.Controls.Add(this.cmb_UnitQuantity);
            this.Controls.Add(this.lbl_UnitQuantity);
            this.Controls.Add(this.cmb_Types);
            this.Controls.Add(this.lbl_UnitTypes);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.cmb_UnitName);
            this.Controls.Add(this.lbl_Types);
            this.Controls.Add(this.lbl_Cost);
            this.Controls.Add(this.lbl_PackageQty);
            this.Controls.Add(this.lbl_PriceField);
            this.Controls.Add(this.txt_ItemPrice);
            this.Controls.Add(this.lbl_UnitName);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.Lbl_Barcod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Additional_Barcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "AdditionalBarCode";
            this.Text = "Additional Barcode";
            this.Load += new System.EventHandler(this.Additional_Barcode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Additional_Barcode_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Label Lbl_Barcod;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lbl_UnitName;
        private System.Windows.Forms.Label lbl_PriceField;
        private System.Windows.Forms.TextBox txt_ItemPrice;
        private System.Windows.Forms.Label lbl_PackageQty;
        private System.Windows.Forms.Label lbl_Cost;
        private System.Windows.Forms.ComboBox cmb_UnitName;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.ComboBox cmb_UnitQuantity;
        private System.Windows.Forms.Label lbl_UnitQuantity;
        private System.Windows.Forms.ComboBox cmb_Types;
        private System.Windows.Forms.Label lbl_UnitTypes;
        private System.Windows.Forms.Label lbl_Types;
        private System.Windows.Forms.Timer tmrBarcode;
        public System.Windows.Forms.TextBox txtBarcode;
        public System.Windows.Forms.TextBox txtBarcodes;
        private System.Windows.Forms.Label lbl_WholeSale;
        private System.Windows.Forms.TextBox txt_WholeSale;
        private System.Windows.Forms.Label lbl_MinPrice;
        private System.Windows.Forms.TextBox txt_MinPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholeSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitTypesID;
    }
}