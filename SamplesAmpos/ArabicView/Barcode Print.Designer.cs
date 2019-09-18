namespace BumedianBM.ArabicView
{
    partial class Barcode_Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Barcode_Print));
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.radNormalPrice = new System.Windows.Forms.RadioButton();
            this.radBigPrice = new System.Windows.Forms.RadioButton();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.dgrBarcode = new System.Windows.Forms.DataGridView();
            this.Ids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.Txt_Totalpages = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.Txt_Totalqty = new System.Windows.Forms.TextBox();
            this.chkPrintlogo = new System.Windows.Forms.CheckBox();
            this.chkPrintprice = new System.Windows.Forms.CheckBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblCloumn = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPrintPreview = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.Dgv_PrintDetails = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrBarcode)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PrintDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 450;
            this.cmbItemNo.DropDownWidth = 150;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(405, 8);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(126, 28);
            this.cmbItemNo.TabIndex = 190;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            // 
            // radNormalPrice
            // 
            this.radNormalPrice.AutoSize = true;
            this.radNormalPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.radNormalPrice.Location = new System.Drawing.Point(389, 110);
            this.radNormalPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radNormalPrice.Name = "radNormalPrice";
            this.radNormalPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radNormalPrice.Size = new System.Drawing.Size(95, 35);
            this.radNormalPrice.TabIndex = 174;
            this.radNormalPrice.TabStop = true;
            this.radNormalPrice.Tag = "NormalPrice";
            this.radNormalPrice.Text = "سعر عادي\r\n";
            this.radNormalPrice.UseVisualStyleBackColor = true;
            // 
            // radBigPrice
            // 
            this.radBigPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.radBigPrice.Location = new System.Drawing.Point(264, 107);
            this.radBigPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radBigPrice.Name = "radBigPrice";
            this.radBigPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radBigPrice.Size = new System.Drawing.Size(95, 35);
            this.radBigPrice.TabIndex = 173;
            this.radBigPrice.TabStop = true;
            this.radBigPrice.Tag = "BigPrice";
            this.radBigPrice.Text = "سعر كبير";
            this.radBigPrice.UseVisualStyleBackColor = true;
            // 
            // lblBarcode
            // 
            this.lblBarcode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBarcode.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.Location = new System.Drawing.Point(550, 8);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBarcode.Size = new System.Drawing.Size(206, 31);
            this.lblBarcode.TabIndex = 189;
            this.lblBarcode.Text = "باركود \r\n";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrBarcode
            // 
            this.dgrBarcode.AllowUserToAddRows = false;
            this.dgrBarcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrBarcode.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgrBarcode.ColumnHeadersHeight = 25;
            this.dgrBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgrBarcode.ColumnHeadersVisible = false;
            this.dgrBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ids,
            this.Barcodes,
            this.ItemId});
            this.dgrBarcode.Location = new System.Drawing.Point(550, 35);
            this.dgrBarcode.Name = "dgrBarcode";
            this.dgrBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgrBarcode.RowHeadersVisible = false;
            this.dgrBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrBarcode.Size = new System.Drawing.Size(206, 111);
            this.dgrBarcode.TabIndex = 170;
            this.dgrBarcode.TabStop = false;
            // 
            // Ids
            // 
            this.Ids.DataPropertyName = "Ids";
            this.Ids.HeaderText = "ID";
            this.Ids.Name = "Ids";
            this.Ids.Visible = false;
            // 
            // Barcodes
            // 
            this.Barcodes.DataPropertyName = "Barcode";
            this.Barcodes.HeaderText = "Barcodes";
            this.Barcodes.Name = "Barcodes";
            this.Barcodes.ReadOnly = true;
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.Visible = false;
            // 
            // cmbItemName
            // 
            this.cmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItemName.DropDownHeight = 450;
            this.cmbItemName.DropDownWidth = 450;
            this.cmbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemName.IntegralHeight = false;
            this.cmbItemName.Location = new System.Drawing.Point(100, 8);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemName.Size = new System.Drawing.Size(215, 28);
            this.cmbItemName.TabIndex = 0;
            this.cmbItemName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbItemName_DrawItem);
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            this.cmbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalPages.Location = new System.Drawing.Point(147, 487);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalPages.Size = new System.Drawing.Size(111, 31);
            this.lblTotalPages.TabIndex = 188;
            this.lblTotalPages.Tag = "TPages";
            this.lblTotalPages.Text = "اجمالي الصفحات\r\n";
            // 
            // Txt_Totalpages
            // 
            this.Txt_Totalpages.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_Totalpages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Totalpages.Location = new System.Drawing.Point(264, 484);
            this.Txt_Totalpages.Name = "Txt_Totalpages";
            this.Txt_Totalpages.ReadOnly = true;
            this.Txt_Totalpages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Totalpages.Size = new System.Drawing.Size(115, 27);
            this.Txt_Totalpages.TabIndex = 187;
            this.Txt_Totalpages.TabStop = false;
            this.Txt_Totalpages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Totalpages_KeyPress);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalQty.Location = new System.Drawing.Point(529, 488);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalQty.Size = new System.Drawing.Size(91, 31);
            this.lblTotalQty.TabIndex = 186;
            this.lblTotalQty.Text = "اجمالي الكمية\r\n";
            // 
            // Txt_Totalqty
            // 
            this.Txt_Totalqty.BackColor = System.Drawing.Color.Cornsilk;
            this.Txt_Totalqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Totalqty.Location = new System.Drawing.Point(647, 484);
            this.Txt_Totalqty.Name = "Txt_Totalqty";
            this.Txt_Totalqty.ReadOnly = true;
            this.Txt_Totalqty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Totalqty.Size = new System.Drawing.Size(120, 27);
            this.Txt_Totalqty.TabIndex = 185;
            this.Txt_Totalqty.TabStop = false;
            this.Txt_Totalqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Totalqty_KeyPress);
            // 
            // chkPrintlogo
            // 
            this.chkPrintlogo.AutoSize = true;
            this.chkPrintlogo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkPrintlogo.Location = new System.Drawing.Point(131, 108);
            this.chkPrintlogo.Name = "chkPrintlogo";
            this.chkPrintlogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintlogo.Size = new System.Drawing.Size(111, 35);
            this.chkPrintlogo.TabIndex = 171;
            this.chkPrintlogo.Tag = "PrintLogo";
            this.chkPrintlogo.Text = "طباعة الشعار\r\n";
            this.chkPrintlogo.UseVisualStyleBackColor = true;
            // 
            // chkPrintprice
            // 
            this.chkPrintprice.AutoSize = true;
            this.chkPrintprice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkPrintprice.Location = new System.Drawing.Point(18, 110);
            this.chkPrintprice.Name = "chkPrintprice";
            this.chkPrintprice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintprice.Size = new System.Drawing.Size(107, 35);
            this.chkPrintprice.TabIndex = 172;
            this.chkPrintprice.Tag = "PrintPrice";
            this.chkPrintprice.Text = "طباعة السعر\r\n";
            this.chkPrintprice.UseVisualStyleBackColor = true;
            this.chkPrintprice.CheckedChanged += new System.EventHandler(this.chkPrintprice_CheckedChanged);
            // 
            // lblStock
            // 
            this.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(12, 79);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStock.Size = new System.Drawing.Size(63, 31);
            this.lblStock.TabIndex = 184;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون\r\n";
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtStock.Location = new System.Drawing.Point(100, 77);
            this.txtStock.Name = "txtStock";
            this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStock.Size = new System.Drawing.Size(126, 27);
            this.txtStock.TabIndex = 183;
            this.txtStock.TabStop = false;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // lblCloumn
            // 
            this.lblCloumn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCloumn.AutoSize = true;
            this.lblCloumn.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCloumn.Location = new System.Drawing.Point(321, 42);
            this.lblCloumn.Name = "lblCloumn";
            this.lblCloumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCloumn.Size = new System.Drawing.Size(48, 31);
            this.lblCloumn.TabIndex = 182;
            this.lblCloumn.Tag = "Column";
            this.lblCloumn.Text = "العمود\r\n";
            // 
            // lblRow
            // 
            this.lblRow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRow.AutoSize = true;
            this.lblRow.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblRow.Location = new System.Drawing.Point(321, 78);
            this.lblRow.Name = "lblRow";
            this.lblRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRow.Size = new System.Drawing.Size(50, 31);
            this.lblRow.TabIndex = 181;
            this.lblRow.Tag = "Row";
            this.lblRow.Text = "الصف\r\n";
            // 
            // lblQty
            // 
            this.lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblQty.Location = new System.Drawing.Point(12, 43);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQty.Size = new System.Drawing.Size(53, 31);
            this.lblQty.TabIndex = 180;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية \r\n";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQty.Location = new System.Drawing.Point(100, 42);
            this.txtQty.Name = "txtQty";
            this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQty.Size = new System.Drawing.Size(126, 27);
            this.txtQty.TabIndex = 1;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtColumn
            // 
            this.txtColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtColumn.Location = new System.Drawing.Point(405, 43);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtColumn.Size = new System.Drawing.Size(126, 27);
            this.txtColumn.TabIndex = 176;
            this.txtColumn.TextChanged += new System.EventHandler(this.txtColumn_TextChanged);
            this.txtColumn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColumn_KeyPress);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(7, 154);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpen.Size = new System.Drawing.Size(126, 40);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Tag = "Open";
            this.btnOpen.Text = "فتح\r\n";
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(12, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(82, 31);
            this.lblItemName.TabIndex = 177;
            this.lblItemName.Tag = "IName";
            this.lblItemName.Text = "اسم الصنف\r\n";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(7, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(126, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(7, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(126, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(321, 8);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(78, 31);
            this.lblItemNo.TabIndex = 178;
            this.lblItemNo.Tag = "INo";
            this.lblItemNo.Text = "رقم الصنف\r\n";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.Tmr_Barcode_Tick);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(7, 242);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(126, 40);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(7, 198);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(126, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(7, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(126, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Tag = "Add";
            this.btnAdd.Text = "اضافة\r\n";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPrintPreview);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Location = new System.Drawing.Point(2, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(142, 364);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            // 
            // chkPrintPreview
            // 
            this.chkPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPrintPreview.Location = new System.Drawing.Point(7, 329);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPreview.Size = new System.Drawing.Size(126, 29);
            this.chkPrintPreview.TabIndex = 261;
            this.chkPrintPreview.Tag = "PP";
            this.chkPrintPreview.Text = "معاينة قبل الطباعة";
            this.chkPrintPreview.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(7, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(126, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "جديد\r\n";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtRow.Location = new System.Drawing.Point(405, 77);
            this.txtRow.Name = "txtRow";
            this.txtRow.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRow.Size = new System.Drawing.Size(126, 27);
            this.txtRow.TabIndex = 175;
            this.txtRow.TextChanged += new System.EventHandler(this.txtRow_TextChanged);
            this.txtRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRow_KeyPress);
            // 
            // Dgv_PrintDetails
            // 
            this.Dgv_PrintDetails.AllowUserToAddRows = false;
            this.Dgv_PrintDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_PrintDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Dgv_PrintDetails.ColumnHeadersHeight = 30;
            this.Dgv_PrintDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Id,
            this.Barcode,
            this.Row,
            this.Column,
            this.Quantity});
            this.Dgv_PrintDetails.Location = new System.Drawing.Point(150, 149);
            this.Dgv_PrintDetails.Name = "Dgv_PrintDetails";
            this.Dgv_PrintDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dgv_PrintDetails.RowHeadersVisible = false;
            this.Dgv_PrintDetails.RowHeadersWidth = 15;
            this.Dgv_PrintDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_PrintDetails.Size = new System.Drawing.Size(617, 328);
            this.Dgv_PrintDetails.TabIndex = 179;
            this.Dgv_PrintDetails.TabStop = false;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "الصنف";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 80;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.FillWeight = 125F;
            this.Barcode.HeaderText = "باركود ";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // Row
            // 
            this.Row.DataPropertyName = "Row";
            this.Row.HeaderText = "الصف";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            // 
            // Column
            // 
            this.Column.DataPropertyName = "Column";
            this.Column.HeaderText = "العمود";
            this.Column.Name = "Column";
            this.Column.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "الكمية ";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(40, 171);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBarcode.Size = new System.Drawing.Size(40, 26);
            this.txtBarcode.TabIndex = 191;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // Barcode_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(777, 516);
            this.Controls.Add(this.cmbItemNo);
            this.Controls.Add(this.radNormalPrice);
            this.Controls.Add(this.radBigPrice);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.dgrBarcode);
            this.Controls.Add(this.cmbItemName);
            this.Controls.Add(this.lblTotalPages);
            this.Controls.Add(this.Txt_Totalpages);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.Txt_Totalqty);
            this.Controls.Add(this.chkPrintlogo);
            this.Controls.Add(this.chkPrintprice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblCloumn);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.Dgv_PrintDetails);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Barcode_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Barcode Print";
            this.Text = "Barcode Print";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Barcode_Print_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Barcode_Print_FormClosed);
            this.Load += new System.EventHandler(this.Barcode_Print_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcode_print_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgrBarcode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PrintDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.RadioButton radNormalPrice;
        private System.Windows.Forms.RadioButton radBigPrice;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.DataGridView dgrBarcode;
        private System.Windows.Forms.ComboBox cmbItemName;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.TextBox Txt_Totalpages;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.TextBox Txt_Totalqty;
        private System.Windows.Forms.CheckBox chkPrintlogo;
        private System.Windows.Forms.CheckBox chkPrintprice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblCloumn;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.DataGridView Dgv_PrintDetails;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ids;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.CheckBox chkPrintPreview;
    }
}