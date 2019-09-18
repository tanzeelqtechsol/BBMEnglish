namespace BumedianBM.ArabicView
{
    partial class Opening_Stock
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
            ObjStockHelper = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opening_Stock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBox = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.MaskedTextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.MaskedTextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.chkwithsupplier = new System.Windows.Forms.CheckBox();
            this.cmbSupplierNo = new System.Windows.Forms.ComboBox();
            this.lblSupno = new System.Windows.Forms.Label();
            this.btnBoxF9 = new System.Windows.Forms.Button();
            this.cmbSupplierName = new System.Windows.Forms.ComboBox();
            this.lblSupName = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnItemInformation = new System.Windows.Forms.Button();
            this.btnItemCard = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.MaskedTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalValue = new System.Windows.Forms.MaskedTextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.btnPayRecipt = new System.Windows.Forms.Button();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMStrip_Stock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TStrip_Btn_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.CMStrip_Stock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.96392F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.15562F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.916427F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 694);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.chkwithsupplier);
            this.panel1.Controls.Add(this.cmbSupplierNo);
            this.panel1.Controls.Add(this.lblSupno);
            this.panel1.Controls.Add(this.btnBoxF9);
            this.panel1.Controls.Add(this.cmbSupplierName);
            this.panel1.Controls.Add(this.lblSupName);
            this.panel1.Controls.Add(this.cmbItem);
            this.panel1.Controls.Add(this.lblItemNo);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.cmbItemNo);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Location = new System.Drawing.Point(195, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 167);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel2.Controls.Add(this.txtBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantity, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpExpiry, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblExpiry, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtStock, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblStock, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblQty, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCost, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCost, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 104);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(703, 63);
            this.tableLayoutPanel2.TabIndex = 300;
            // 
            // txtBox
            // 
            this.txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBox.FormattingEnabled = true;
            this.txtBox.Location = new System.Drawing.Point(594, 34);
            this.txtBox.Name = "txtBox";
            this.txtBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBox.Size = new System.Drawing.Size(106, 28);
            this.txtBox.TabIndex = 8;
            this.txtBox.SelectedIndexChanged += new System.EventHandler(this.txtBox_SelectedIndexChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.Location = new System.Drawing.Point(230, 34);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantity.Size = new System.Drawing.Size(106, 27);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Text = "1";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(454, 34);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpExpiry.RightToLeftLayout = true;
            this.dtpExpiry.Size = new System.Drawing.Size(134, 27);
            this.dtpExpiry.TabIndex = 7;
            this.dtpExpiry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpExpiry_KeyPress);
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(454, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExpiry.Size = new System.Drawing.Size(105, 31);
            this.lblExpiry.TabIndex = 290;
            this.lblExpiry.Tag = "Expiry";
            this.lblExpiry.Text = "الصلاحية";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtStock.Location = new System.Drawing.Point(342, 34);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStock.Size = new System.Drawing.Size(106, 27);
            this.txtStock.TabIndex = 278;
            this.txtStock.Text = "0";
            // 
            // lblStock
            // 
            this.lblStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(343, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStock.Size = new System.Drawing.Size(105, 31);
            this.lblStock.TabIndex = 289;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblQty.Location = new System.Drawing.Point(231, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQty.Size = new System.Drawing.Size(105, 31);
            this.lblQty.TabIndex = 288;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Location = new System.Drawing.Point(118, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.Size = new System.Drawing.Size(106, 27);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Text = "0.000";
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(119, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrice.Size = new System.Drawing.Size(105, 31);
            this.lblPrice.TabIndex = 291;
            this.lblPrice.Tag = "Price";
            this.lblPrice.Text = "السعر";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCost
            // 
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(3, 34);
            this.txtCost.Name = "txtCost";
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCost.Size = new System.Drawing.Size(109, 27);
            this.txtCost.TabIndex = 4;
            this.txtCost.Text = "0.000";
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtCost.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblCost
            // 
            this.lblCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCost.Location = new System.Drawing.Point(7, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCost.Size = new System.Drawing.Size(105, 31);
            this.lblCost.TabIndex = 287;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "سعر الشراء";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkwithsupplier
            // 
            this.chkwithsupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkwithsupplier.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkwithsupplier.Location = new System.Drawing.Point(599, 1);
            this.chkwithsupplier.Name = "chkwithsupplier";
            this.chkwithsupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkwithsupplier.Size = new System.Drawing.Size(192, 35);
            this.chkwithsupplier.TabIndex = 299;
            this.chkwithsupplier.Tag = "withSup";
            this.chkwithsupplier.Text = "تحديد مورد ";
            this.chkwithsupplier.UseVisualStyleBackColor = true;
            this.chkwithsupplier.CheckStateChanged += new System.EventHandler(this.chkwithsupplier_CheckStateChanged);
            // 
            // cmbSupplierNo
            // 
            this.cmbSupplierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierNo.DropDownHeight = 600;
            this.cmbSupplierNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierNo.FormattingEnabled = true;
            this.cmbSupplierNo.IntegralHeight = false;
            this.cmbSupplierNo.Location = new System.Drawing.Point(473, 5);
            this.cmbSupplierNo.Name = "cmbSupplierNo";
            this.cmbSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierNo.Size = new System.Drawing.Size(89, 28);
            this.cmbSupplierNo.TabIndex = 297;
            this.cmbSupplierNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbSupplierNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSupplierNo_KeyPress);
            // 
            // lblSupno
            // 
            this.lblSupno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSupno.AutoSize = true;
            this.lblSupno.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupno.Location = new System.Drawing.Point(396, 6);
            this.lblSupno.Name = "lblSupno";
            this.lblSupno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupno.Size = new System.Drawing.Size(72, 31);
            this.lblSupno.TabIndex = 298;
            this.lblSupno.Tag = "SupNo";
            this.lblSupno.Text = "رقم المورد";
            this.lblSupno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBoxF9
            // 
            this.btnBoxF9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoxF9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBoxF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoxF9.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBoxF9.Location = new System.Drawing.Point(717, 127);
            this.btnBoxF9.Name = "btnBoxF9";
            this.btnBoxF9.Size = new System.Drawing.Size(82, 39);
            this.btnBoxF9.TabIndex = 9;
            this.btnBoxF9.Tag = "BoxF9";
            this.btnBoxF9.Text = "علبة F9";
            this.btnBoxF9.UseVisualStyleBackColor = false;
            this.btnBoxF9.Click += new System.EventHandler(this.btnBoxF9_Click);
            // 
            // cmbSupplierName
            // 
            this.cmbSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierName.DropDownHeight = 600;
            this.cmbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierName.FormattingEnabled = true;
            this.cmbSupplierName.IntegralHeight = false;
            this.cmbSupplierName.Location = new System.Drawing.Point(86, 4);
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierName.Size = new System.Drawing.Size(291, 28);
            this.cmbSupplierName.TabIndex = 295;
            this.cmbSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // lblSupName
            // 
            this.lblSupName.AutoSize = true;
            this.lblSupName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupName.Location = new System.Drawing.Point(1, 5);
            this.lblSupName.Name = "lblSupName";
            this.lblSupName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSupName.Size = new System.Drawing.Size(41, 31);
            this.lblSupName.TabIndex = 296;
            this.lblSupName.Tag = "SupName";
            this.lblSupName.Text = "مورد";
            this.lblSupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbItem
            // 
            this.cmbItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.DropDownHeight = 600;
            this.cmbItem.DropDownWidth = 450;
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.IntegralHeight = false;
            this.cmbItem.Location = new System.Drawing.Point(86, 41);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItem.Size = new System.Drawing.Size(291, 28);
            this.cmbItem.TabIndex = 0;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            this.cmbItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItem_KeyPress);
            this.cmbItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyUp);
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(396, 41);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(78, 31);
            this.lblItemNo.TabIndex = 286;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(1, 42);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemName.Size = new System.Drawing.Size(55, 31);
            this.lblItemName.TabIndex = 285;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "الصنف";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 600;
            this.cmbItemNo.DropDownWidth = 250;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(474, 40);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(89, 28);
            this.cmbItemNo.TabIndex = 1;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(562, 42);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(87, 29);
            this.lblCategory.TabIndex = 283;
            this.lblCategory.Tag = "Cat";
            this.lblCategory.Text = "المجموعة ";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownHeight = 550;
            this.cmbCategory.DropDownWidth = 320;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Location = new System.Drawing.Point(649, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(150, 28);
            this.cmbCategory.TabIndex = 280;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownHeight = 550;
            this.cmbCompany.DropDownWidth = 320;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Location = new System.Drawing.Point(649, 74);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(150, 28);
            this.cmbCompany.TabIndex = 281;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCompany.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(563, 72);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(90, 37);
            this.lblCompany.TabIndex = 282;
            this.lblCompany.Tag = "Com";
            this.lblCompany.Text = "الشركة ";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(1, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescription.Size = new System.Drawing.Size(46, 31);
            this.lblDescription.TabIndex = 284;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "البيان";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(86, 74);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.Size = new System.Drawing.Size(474, 27);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.dtpTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 167);
            this.panel2.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(62, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(121, 26);
            this.dtpDate.TabIndex = 231;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(7, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 233;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(6, 43);
            this.lblTime.Name = "lblTime";
            this.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTime.Size = new System.Drawing.Size(52, 31);
            this.lblTime.TabIndex = 234;
            this.lblTime.Tag = "Time";
            this.lblTime.Text = "الوقت ";
            // 
            // dtpTime
            // 
            this.dtpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTime.CustomFormat = "hh:mm tt";
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(62, 43);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(121, 26);
            this.dtpTime.TabIndex = 232;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 466);
            this.panel3.TabIndex = 247;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnInsertItem);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnItemInformation);
            this.groupBox1.Controls.Add(this.btnItemCard);
            this.groupBox1.Controls.Add(this.btnReports);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnUndo);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, -12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 475);
            this.groupBox1.TabIndex = 248;
            this.groupBox1.TabStop = false;
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInsertItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnInsertItem.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertItem.Image")));
            this.btnInsertItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertItem.Location = new System.Drawing.Point(5, 13);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnInsertItem.Size = new System.Drawing.Size(167, 41);
            this.btnInsertItem.TabIndex = 10;
            this.btnInsertItem.Tag = "InserItemF6";
            this.btnInsertItem.Text = "اضافة صنف  F6";
            this.btnInsertItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertItem.UseVisualStyleBackColor = false;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(5, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(167, 41);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج      ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnItemInformation
            // 
            this.btnItemInformation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemInformation.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemInformation.Image = global::BumedianBM.Properties.Resources.item_info_32;
            this.btnItemInformation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemInformation.Location = new System.Drawing.Point(5, 307);
            this.btnItemInformation.Name = "btnItemInformation";
            this.btnItemInformation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemInformation.Size = new System.Drawing.Size(167, 41);
            this.btnItemInformation.TabIndex = 6;
            this.btnItemInformation.Tag = "ItemInfo";
            this.btnItemInformation.Text = "معلومات الصنف F11";
            this.btnItemInformation.UseVisualStyleBackColor = false;
            this.btnItemInformation.Click += new System.EventHandler(this.btnItemInformation_Click);
            // 
            // btnItemCard
            // 
            this.btnItemCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemCard.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemCard.Image = global::BumedianBM.Properties.Resources.item_card_32;
            this.btnItemCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemCard.Location = new System.Drawing.Point(5, 391);
            this.btnItemCard.Name = "btnItemCard";
            this.btnItemCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemCard.Size = new System.Drawing.Size(167, 41);
            this.btnItemCard.TabIndex = 8;
            this.btnItemCard.Tag = "ItemCard";
            this.btnItemCard.Text = "بطاقة الصنف";
            this.btnItemCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemCard.UseVisualStyleBackColor = false;
            this.btnItemCard.Click += new System.EventHandler(this.btnItemCard_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReports.Image = global::BumedianBM.Properties.Resources.reports2_32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReports.Location = new System.Drawing.Point(5, 349);
            this.btnReports.Name = "btnReports";
            this.btnReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReports.Size = new System.Drawing.Size(167, 41);
            this.btnReports.TabIndex = 7;
            this.btnReports.Tag = "Report";
            this.btnReports.Text = " التقارير";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(5, 265);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(167, 41);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Location = new System.Drawing.Point(5, 223);
            this.btnExport.Name = "btnExport";
            this.btnExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExport.Size = new System.Drawing.Size(167, 41);
            this.btnExport.TabIndex = 4;
            this.btnExport.Tag = "Export";
            this.btnExport.Text = "تصدير  ";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.Location = new System.Drawing.Point(5, 181);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUndo.Size = new System.Drawing.Size(167, 41);
            this.btnUndo.TabIndex = 3;
            this.btnUndo.Tag = "Undo";
            this.btnUndo.Text = "تراجع  ";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(5, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(167, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = " حفظ ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.invoice_modfy_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(5, 97);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNew.Size = new System.Drawing.Size(167, 41);
            this.btnNew.TabIndex = 1;
            this.btnNew.Tag = "ModifyItem";
            this.btnNew.Text = "تعديل فاتورة     ";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(5, 22);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBarcode.Size = new System.Drawing.Size(167, 23);
            this.txtBarcode.TabIndex = 260;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(5, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(167, 41);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء     ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(195, 648);
            this.panel4.Name = "panel4";
            this.panel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel4.Size = new System.Drawing.Size(803, 43);
            this.panel4.TabIndex = 248;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.697933F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.57075F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.32588F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.75419F));
            this.tableLayoutPanel3.Controls.Add(this.txtTotalValue, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblNote, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtNotes, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPayRecipt, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTotalValue, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(850, 50);
            this.tableLayoutPanel3.TabIndex = 261;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.BackColor = System.Drawing.Color.Snow;
            this.txtTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalValue.Location = new System.Drawing.Point(617, 3);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalValue.Size = new System.Drawing.Size(99, 27);
            this.txtTotalValue.TabIndex = 242;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(3, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNote.Size = new System.Drawing.Size(57, 50);
            this.lblNote.TabIndex = 244;
            this.lblNote.Tag = "Notes";
            this.lblNote.Text = "ملاحظة";
            this.lblNote.Click += new System.EventHandler(this.lblNote_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.Info;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNotes.Location = new System.Drawing.Point(66, 3);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(188, 44);
            this.txtNotes.TabIndex = 240;
            this.txtNotes.Text = "";
            // 
            // btnPayRecipt
            // 
            this.btnPayRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPayRecipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayRecipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayRecipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPayRecipt.Image = global::BumedianBM.Properties.Resources.pay_receipet_32;
            this.btnPayRecipt.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPayRecipt.Location = new System.Drawing.Point(260, 3);
            this.btnPayRecipt.Name = "btnPayRecipt";
            this.btnPayRecipt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPayRecipt.Size = new System.Drawing.Size(185, 44);
            this.btnPayRecipt.TabIndex = 241;
            this.btnPayRecipt.Tag = "PayReceipt";
            this.btnPayRecipt.Text = "ايصال صرف F8";
            this.btnPayRecipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayRecipt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPayRecipt.UseVisualStyleBackColor = false;
            this.btnPayRecipt.Click += new System.EventHandler(this.btnPayRecipt_Click);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(451, 0);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalValue.Size = new System.Drawing.Size(102, 31);
            this.lblTotalValue.TabIndex = 245;
            this.lblTotalValue.Tag = "TValue";
            this.lblTotalValue.Text = "القيمة الاجمالية";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvInventory);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(195, 176);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(803, 466);
            this.panel5.TabIndex = 249;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventory.ColumnHeadersHeight = 37;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemNo,
            this.ItemName,
            this.Description,
            this.ExpiryDate,
            this.Package,
            this.Quantity,
            this.Box,
            this.UnitPrice,
            this.Total,
            this.ItemPrice,
            this.Time,
            this.User,
            this.Cost,
            this.SerialNo,
            this.BarcodeID});
            this.dgvInventory.ContextMenuStrip = this.CMStrip_Stock;
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInventory.Location = new System.Drawing.Point(0, 0);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowHeadersWidth = 13;
            this.dgvInventory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(803, 466);
            this.dgvInventory.TabIndex = 247;
            // 
            // ItemId
            // 
            this.ItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ItemId.DataPropertyName = "ItemNumber";
            this.ItemId.HeaderText = "رقم الصنف";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Width = 103;
            // 
            // ItemNo
            // 
            this.ItemNo.DataPropertyName = "ItemNo";
            this.ItemNo.HeaderText = "ItemId";
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.ReadOnly = true;
            this.ItemNo.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ItemName.DefaultCellStyle = dataGridViewCellStyle21;
            this.ItemName.HeaderText = "اسم الصنف";
            this.ItemName.MinimumWidth = 100;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 107;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "ItemDescription";
            this.Description.HeaderText = "البيان";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ExpiryDate.DataPropertyName = "ItemExpiry";
            this.ExpiryDate.HeaderText = "الصلاحية";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            this.ExpiryDate.Width = 92;
            // 
            // Package
            // 
            this.Package.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Package.DataPropertyName = "ItemPackage";
            this.Package.HeaderText = "العبوة";
            this.Package.Name = "Package";
            this.Package.ReadOnly = true;
            this.Package.Width = 69;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Quantity.DataPropertyName = "ItemQuantity";
            this.Quantity.HeaderText = "الكمية ";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 72;
            // 
            // Box
            // 
            this.Box.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Box.DataPropertyName = "Box";
            this.Box.HeaderText = "Box";
            this.Box.Name = "Box";
            this.Box.ReadOnly = true;
            this.Box.Width = 70;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UnitPrice.DataPropertyName = "ItemUnitPrice";
            this.UnitPrice.HeaderText = "سعر الوحدة";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 105;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Total.DataPropertyName = "ItemTotal";
            this.Total.HeaderText = "الاجمالي";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 86;
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "ItemPrice";
            this.ItemPrice.HeaderText = "سعر الصنف";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "الوقت ";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 71;
            // 
            // User
            // 
            this.User.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.User.DataPropertyName = "User";
            this.User.HeaderText = "المستخدم";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 91;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "ItemCost";
            this.Cost.HeaderText = "سعر الشراء";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // SerialNo
            // 
            this.SerialNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SerialNo.DataPropertyName = "ItemSerialNo";
            this.SerialNo.HeaderText = "الرقم التسلسلي";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            this.SerialNo.Width = 123;
            // 
            // BarcodeID
            // 
            this.BarcodeID.DataPropertyName = "BarcodeID";
            this.BarcodeID.HeaderText = "BarcodeID";
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.ReadOnly = true;
            this.BarcodeID.Visible = false;
            // 
            // CMStrip_Stock
            // 
            this.CMStrip_Stock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMStrip_Stock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TStrip_Btn_Delete});
            this.CMStrip_Stock.Name = "CMStrip_Stock";
            this.CMStrip_Stock.Size = new System.Drawing.Size(113, 26);
            // 
            // TStrip_Btn_Delete
            // 
            this.TStrip_Btn_Delete.Name = "TStrip_Btn_Delete";
            this.TStrip_Btn_Delete.Size = new System.Drawing.Size(112, 22);
            this.TStrip_Btn_Delete.Text = "Delete";
            this.TStrip_Btn_Delete.Click += new System.EventHandler(this.TStrip_Btn_Delete_Click);
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.Timer_In_Tick);
            // 
            // Opening_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1001, 694);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Opening_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Opening_Stock_FormClosed);
            this.Load += new System.EventHandler(this.Opening_Stock_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.opening_stock_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.CMStrip_Stock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkwithsupplier;
        private System.Windows.Forms.ComboBox cmbSupplierNo;
        private System.Windows.Forms.Label lblSupno;
        private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.Label lblSupName;
        private System.Windows.Forms.Button btnBoxF9;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.MaskedTextBox txtStock;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.MaskedTextBox txtCost;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.MaskedTextBox txtDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnItemInformation;
        private System.Windows.Forms.Button btnItemCard;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.MaskedTextBox txtBarcode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MaskedTextBox txtTotalValue;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnPayRecipt;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.ContextMenuStrip CMStrip_Stock;
        private System.Windows.Forms.ToolStripMenuItem TStrip_Btn_Delete;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.ComboBox txtBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Package;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTotalValue;
    }
}
