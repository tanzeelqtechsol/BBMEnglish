namespace BumedianBM.ArabicView
{
    partial class Purchase_Invoice
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
            ObjHelper = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_Invoice));
            this.TableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPurchaseInvoiceData = new System.Windows.Forms.DataGridView();
            this.itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exp_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.in_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Newcost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemtax1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemtax2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grbNotesAndAlert = new System.Windows.Forms.GroupBox();
            this.RtxtNotesAndAlerts = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtInNo = new System.Windows.Forms.TextBox();
            this.lblInNo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalStock = new System.Windows.Forms.ComboBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.MaskedTextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.MaskedTextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.Btn_Pervious = new System.Windows.Forms.Button();
            this.Btn_First = new System.Windows.Forms.Button();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblSupplierNo = new System.Windows.Forms.Label();
            this.btnBox = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.btnSet = new System.Windows.Forms.Button();
            this.chkPaymentDate = new System.Windows.Forms.CheckBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.cmbSupplierNo = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.cmbItemName = new SergeUtils.EasyCompletionComboBox();
            this.cmbSupplierName = new SergeUtils.EasyCompletionComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.Btn_Last = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.txtNewInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUservalue = new System.Windows.Forms.Label();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblExtraCost = new System.Windows.Forms.Label();
            this.txtExtraCost = new System.Windows.Forms.MaskedTextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnPayReceipt = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.btnImportInvoice = new System.Windows.Forms.Button();
            this.txtNet = new System.Windows.Forms.MaskedTextBox();
            this.lblNet = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.MaskedTextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.MaskedTextBox();
            this.rbnPercentage = new System.Windows.Forms.RadioButton();
            this.rbnValue = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.btnNewInvoice = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCloseInvoice = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnItemInfo = new System.Windows.Forms.Button();
            this.btnItemCard = new System.Windows.Forms.Button();
            this.btnModifyInvoice = new System.Windows.Forms.Button();
            this.btnFindInvoice = new System.Windows.Forms.Button();
            this.btnBalanceSheet = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.chkHideLogo = new System.Windows.Forms.CheckBox();
            this.chkHideDebt = new System.Windows.Forms.CheckBox();
            this.chkPrintPerview = new System.Windows.Forms.CheckBox();
            this.chkIncludeTax = new System.Windows.Forms.CheckBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.TableLayout1.SuspendLayout();
            this.TableLayout2.SuspendLayout();
            this.TableLayout3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseInvoiceData)).BeginInit();
            this.panel3.SuspendLayout();
            this.grbNotesAndAlert.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayout1
            // 
            this.TableLayout1.ColumnCount = 2;
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.TableLayout1.Controls.Add(this.TableLayout2, 0, 0);
            this.TableLayout1.Controls.Add(this.panel1, 1, 0);
            this.TableLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout1.Location = new System.Drawing.Point(0, 0);
            this.TableLayout1.Name = "TableLayout1";
            this.TableLayout1.RowCount = 1;
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout1.Size = new System.Drawing.Size(987, 733);
            this.TableLayout1.TabIndex = 0;
            // 
            // TableLayout2
            // 
            this.TableLayout2.ColumnCount = 1;
            this.TableLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout2.Controls.Add(this.TableLayout3, 0, 1);
            this.TableLayout2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.TableLayout2.Controls.Add(this.panel4, 0, 2);
            this.TableLayout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout2.Location = new System.Drawing.Point(195, 3);
            this.TableLayout2.Name = "TableLayout2";
            this.TableLayout2.RowCount = 3;
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.88079F));
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.11921F));
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.TableLayout2.Size = new System.Drawing.Size(789, 727);
            this.TableLayout2.TabIndex = 2;
            // 
            // TableLayout3
            // 
            this.TableLayout3.AutoSize = true;
            this.TableLayout3.ColumnCount = 2;
            this.TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.27991F));
            this.TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.72009F));
            this.TableLayout3.Controls.Add(this.panel2, 1, 0);
            this.TableLayout3.Controls.Add(this.panel3, 0, 0);
            this.TableLayout3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout3.Location = new System.Drawing.Point(3, 262);
            this.TableLayout3.Name = "TableLayout3";
            this.TableLayout3.RowCount = 1;
            this.TableLayout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout3.Size = new System.Drawing.Size(783, 339);
            this.TableLayout3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dgvPurchaseInvoiceData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 333);
            this.panel2.TabIndex = 2;
            // 
            // dgvPurchaseInvoiceData
            // 
            this.dgvPurchaseInvoiceData.AllowUserToAddRows = false;
            this.dgvPurchaseInvoiceData.AllowUserToDeleteRows = false;
            this.dgvPurchaseInvoiceData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseInvoiceData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchaseInvoiceData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseInvoiceData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseInvoiceData.ColumnHeadersHeight = 34;
            this.dgvPurchaseInvoiceData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemno,
            this.ItemNumber,
            this.item_name,
            this.exp_date,
            this.package,
            this.quantity,
            this.box,
            this.unit_price,
            this.sub_total,
            this.in_time,
            this.user,
            this.back,
            this.SalePrice,
            this.Cost,
            this.SerialNo,
            this.ItemDiscount,
            this.Newcost,
            this.Itemtax1,
            this.Itemtax2,
            this.TotalTax2,
            this.TotalTax1,
            this.TotalCost,
            this.UnitCost});
            this.dgvPurchaseInvoiceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseInvoiceData.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPurchaseInvoiceData.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchaseInvoiceData.Name = "dgvPurchaseInvoiceData";
            this.dgvPurchaseInvoiceData.ReadOnly = true;
            this.dgvPurchaseInvoiceData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPurchaseInvoiceData.RowHeadersWidth = 13;
            this.dgvPurchaseInvoiceData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPurchaseInvoiceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseInvoiceData.Size = new System.Drawing.Size(627, 333);
            this.dgvPurchaseInvoiceData.TabIndex = 147;
            this.dgvPurchaseInvoiceData.DoubleClick += new System.EventHandler(this.dgvPurchaseInvoiceData_DoubleClick);
            // 
            // itemno
            // 
            this.itemno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.itemno.DataPropertyName = "ItemNo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemno.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemno.HeaderText = "رقم الصنف ";
            this.itemno.Name = "itemno";
            this.itemno.ReadOnly = true;
            this.itemno.Visible = false;
            this.itemno.Width = 109;
            // 
            // ItemNumber
            // 
            this.ItemNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "ItemNumber";
            this.ItemNumber.Name = "ItemNumber";
            this.ItemNumber.ReadOnly = true;
            this.ItemNumber.Visible = false;
            this.ItemNumber.Width = 133;
            // 
            // item_name
            // 
            this.item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.item_name.DataPropertyName = "ItemDescription";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.item_name.HeaderText = "البيان";
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            this.item_name.Width = 71;
            // 
            // exp_date
            // 
            this.exp_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.exp_date.DataPropertyName = "ItemExpiry";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = "-";
            this.exp_date.DefaultCellStyle = dataGridViewCellStyle4;
            this.exp_date.HeaderText = "الصلاحية";
            this.exp_date.MinimumWidth = 7;
            this.exp_date.Name = "exp_date";
            this.exp_date.ReadOnly = true;
            this.exp_date.Width = 92;
            // 
            // package
            // 
            this.package.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.package.DataPropertyName = "ItemPackage";
            this.package.HeaderText = "العبوة";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 69;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.quantity.DataPropertyName = "ItemQuantity";
            this.quantity.HeaderText = "الكمية ";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 78;
            // 
            // box
            // 
            this.box.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.box.DataPropertyName = "Box";
            this.box.HeaderText = "Box";
            this.box.Name = "box";
            this.box.ReadOnly = true;
            this.box.Width = 70;
            // 
            // unit_price
            // 
            this.unit_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.unit_price.DataPropertyName = "ItemUnitPrice";
            this.unit_price.HeaderText = "سعر الوحدة\r\n";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            this.unit_price.Width = 105;
            // 
            // sub_total
            // 
            this.sub_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sub_total.DataPropertyName = "ItemTotal";
            this.sub_total.HeaderText = "الاجمالي";
            this.sub_total.Name = "sub_total";
            this.sub_total.ReadOnly = true;
            this.sub_total.Width = 86;
            // 
            // in_time
            // 
            this.in_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.in_time.DataPropertyName = "Time";
            this.in_time.HeaderText = "الوقت ";
            this.in_time.Name = "in_time";
            this.in_time.ReadOnly = true;
            this.in_time.Visible = false;
            this.in_time.Width = 77;
            // 
            // user
            // 
            this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.user.DataPropertyName = "user";
            this.user.HeaderText = "المستخدم";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Visible = false;
            // 
            // back
            // 
            this.back.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.back.DataPropertyName = "back";
            this.back.HeaderText = "المرجع ";
            this.back.Name = "back";
            this.back.ReadOnly = true;
            this.back.Visible = false;
            // 
            // SalePrice
            // 
            this.SalePrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SalePrice.DataPropertyName = "SalePrice";
            this.SalePrice.HeaderText = "SalePrice";
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.ReadOnly = true;
            this.SalePrice.Visible = false;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cost.DataPropertyName = "ItemCost";
            this.Cost.HeaderText = "سعر الشراء";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Visible = false;
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
            // ItemDiscount
            // 
            this.ItemDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemDiscount.DataPropertyName = "ItemDiscount";
            this.ItemDiscount.HeaderText = "ItemDiscount";
            this.ItemDiscount.Name = "ItemDiscount";
            this.ItemDiscount.ReadOnly = true;
            this.ItemDiscount.Visible = false;
            // 
            // Newcost
            // 
            this.Newcost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Newcost.DataPropertyName = "Newcost";
            this.Newcost.HeaderText = "Newcost";
            this.Newcost.Name = "Newcost";
            this.Newcost.ReadOnly = true;
            this.Newcost.Visible = false;
            // 
            // Itemtax1
            // 
            this.Itemtax1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Itemtax1.DataPropertyName = "Itemtax1";
            this.Itemtax1.HeaderText = "Itemtax1";
            this.Itemtax1.Name = "Itemtax1";
            this.Itemtax1.ReadOnly = true;
            this.Itemtax1.Visible = false;
            // 
            // Itemtax2
            // 
            this.Itemtax2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Itemtax2.DataPropertyName = "Itemtax2";
            this.Itemtax2.HeaderText = "Itemtax2";
            this.Itemtax2.Name = "Itemtax2";
            this.Itemtax2.ReadOnly = true;
            this.Itemtax2.Visible = false;
            // 
            // TotalTax2
            // 
            this.TotalTax2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalTax2.DataPropertyName = "TotalTax2";
            this.TotalTax2.HeaderText = "TotalTax2";
            this.TotalTax2.Name = "TotalTax2";
            this.TotalTax2.ReadOnly = true;
            this.TotalTax2.Visible = false;
            // 
            // TotalTax1
            // 
            this.TotalTax1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalTax1.DataPropertyName = "TotalTax1";
            this.TotalTax1.HeaderText = "TotalTax1";
            this.TotalTax1.Name = "TotalTax1";
            this.TotalTax1.ReadOnly = true;
            this.TotalTax1.Visible = false;
            // 
            // TotalCost
            // 
            this.TotalCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalCost.DataPropertyName = "ItemTotal";
            this.TotalCost.HeaderText = "TotalCost";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.Visible = false;
            // 
            // UnitCost
            // 
            this.UnitCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitCost.DataPropertyName = "UnitCost";
            this.UnitCost.HeaderText = "UnitCost";
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.ReadOnly = true;
            this.UnitCost.Visible = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.grbNotesAndAlert);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(636, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(144, 333);
            this.panel3.TabIndex = 3;
            // 
            // grbNotesAndAlert
            // 
            this.grbNotesAndAlert.AutoSize = true;
            this.grbNotesAndAlert.Controls.Add(this.RtxtNotesAndAlerts);
            this.grbNotesAndAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNotesAndAlert.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.grbNotesAndAlert.Location = new System.Drawing.Point(0, 0);
            this.grbNotesAndAlert.Name = "grbNotesAndAlert";
            this.grbNotesAndAlert.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbNotesAndAlert.Size = new System.Drawing.Size(144, 333);
            this.grbNotesAndAlert.TabIndex = 154;
            this.grbNotesAndAlert.TabStop = false;
            this.grbNotesAndAlert.Tag = "NotesAlerts";
            this.grbNotesAndAlert.Text = "مواعيد وملاحظات";
            // 
            // RtxtNotesAndAlerts
            // 
            this.RtxtNotesAndAlerts.BackColor = System.Drawing.SystemColors.Info;
            this.RtxtNotesAndAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtxtNotesAndAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RtxtNotesAndAlerts.Location = new System.Drawing.Point(3, 26);
            this.RtxtNotesAndAlerts.Name = "RtxtNotesAndAlerts";
            this.RtxtNotesAndAlerts.ReadOnly = true;
            this.RtxtNotesAndAlerts.Size = new System.Drawing.Size(138, 304);
            this.RtxtNotesAndAlerts.TabIndex = 0;
            this.RtxtNotesAndAlerts.Text = "";
            this.RtxtNotesAndAlerts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RtxtNotesAndAlerts_MouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 253);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.txtInNo);
            this.panel5.Controls.Add(this.lblInNo);
            this.panel5.Controls.Add(this.tableLayoutPanel2);
            this.panel5.Controls.Add(this.Btn_Pervious);
            this.panel5.Controls.Add(this.Btn_First);
            this.panel5.Controls.Add(this.lblItemNo);
            this.panel5.Controls.Add(this.lblSupplierNo);
            this.panel5.Controls.Add(this.btnBox);
            this.panel5.Controls.Add(this.lblCategory);
            this.panel5.Controls.Add(this.cmbCategory);
            this.panel5.Controls.Add(this.dtpPaymentDate);
            this.panel5.Controls.Add(this.btnSet);
            this.panel5.Controls.Add(this.chkPaymentDate);
            this.panel5.Controls.Add(this.lblCompany);
            this.panel5.Controls.Add(this.cmbItemNo);
            this.panel5.Controls.Add(this.cmbSupplierNo);
            this.panel5.Controls.Add(this.cmbCompany);
            this.panel5.Controls.Add(this.lblInvoiceNo);
            this.panel5.Controls.Add(this.cmbItemName);
            this.panel5.Controls.Add(this.cmbSupplierName);
            this.panel5.Controls.Add(this.lblItemName);
            this.panel5.Controls.Add(this.lblSupplier);
            this.panel5.Controls.Add(this.Btn_Last);
            this.panel5.Controls.Add(this.Btn_Next);
            this.panel5.Controls.Add(this.txtNewInvoiceNo);
            this.panel5.Controls.Add(this.txtInvoiceNo);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(777, 247);
            this.panel5.TabIndex = 1;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // txtInNo
            // 
            this.txtInNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtInNo.Location = new System.Drawing.Point(633, 81);
            this.txtInNo.Name = "txtInNo";
            this.txtInNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInNo.Size = new System.Drawing.Size(136, 27);
            this.txtInNo.TabIndex = 441;
            this.txtInNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInNo_KeyPress);
            // 
            // lblInNo
            // 
            this.lblInNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblInNo.Location = new System.Drawing.Point(556, 78);
            this.lblInNo.Name = "lblInNo";
            this.lblInNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInNo.Size = new System.Drawing.Size(85, 31);
            this.lblInNo.TabIndex = 440;
            this.lblInNo.Tag = "Cat";
            this.lblInNo.Text = "فاتورة رقم";
            this.lblInNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel2.Controls.Add(this.txtTotalStock, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpExpiry, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblExpiry, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtStock, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblStock, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtQuantity, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblQty, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPrice, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPrice, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCost, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCost, 5, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(-3, 183);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 64);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // txtTotalStock
            // 
            this.txtTotalStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTotalStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalStock.FormattingEnabled = true;
            this.txtTotalStock.Location = new System.Drawing.Point(549, 35);
            this.txtTotalStock.Name = "txtTotalStock";
            this.txtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalStock.Size = new System.Drawing.Size(98, 28);
            this.txtTotalStock.TabIndex = 440;
            this.txtTotalStock.SelectedIndexChanged += new System.EventHandler(this.txtTotalStock_SelectedIndexChanged);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(419, 35);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpExpiry.RightToLeftLayout = true;
            this.dtpExpiry.Size = new System.Drawing.Size(124, 26);
            this.dtpExpiry.TabIndex = 6;
            this.dtpExpiry.Value = new System.DateTime(2013, 12, 3, 0, 0, 0, 0);
            this.dtpExpiry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpExpiry_KeyPress);
            this.dtpExpiry.Validating += new System.ComponentModel.CancelEventHandler(this.dtpExpiry_Validating);
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(419, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.txtStock.Location = new System.Drawing.Point(315, 35);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStock.Size = new System.Drawing.Size(98, 27);
            this.txtStock.TabIndex = 89;
            // 
            // lblStock
            // 
            this.lblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStock.AutoEllipsis = true;
            this.lblStock.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(315, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.txtQuantity.Location = new System.Drawing.Point(211, 35);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantity.Size = new System.Drawing.Size(98, 27);
            this.txtQuantity.TabIndex = 5;
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
            this.lblQty.Location = new System.Drawing.Point(211, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQty.Size = new System.Drawing.Size(98, 31);
            this.lblQty.TabIndex = 417;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Location = new System.Drawing.Point(107, 35);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.Size = new System.Drawing.Size(98, 27);
            this.txtPrice.SkipLiterals = false;
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "0.000";
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(107, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrice.Size = new System.Drawing.Size(98, 31);
            this.lblPrice.TabIndex = 420;
            this.lblPrice.Tag = "Price";
            this.lblPrice.Text = "السعر";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCost
            // 
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(3, 35);
            this.txtCost.Name = "txtCost";
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCost.Size = new System.Drawing.Size(98, 27);
            this.txtCost.TabIndex = 3;
            this.txtCost.TabStop = false;
            this.txtCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCost_KeyDown);
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCost_KeyUp);
            this.txtCost.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCost.Location = new System.Drawing.Point(3, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCost.Size = new System.Drawing.Size(80, 31);
            this.lblCost.TabIndex = 416;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "سعر الشراء";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Pervious
            // 
            this.Btn_Pervious.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Pervious.AutoSize = true;
            this.Btn_Pervious.FlatAppearance.BorderSize = 0;
            this.Btn_Pervious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Pervious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pervious.ForeColor = System.Drawing.Color.Black;
            this.Btn_Pervious.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Pervious.Image")));
            this.Btn_Pervious.Location = new System.Drawing.Point(156, 35);
            this.Btn_Pervious.Name = "Btn_Pervious";
            this.Btn_Pervious.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Pervious.Size = new System.Drawing.Size(38, 38);
            this.Btn_Pervious.TabIndex = 439;
            this.Btn_Pervious.Tag = "3";
            this.Btn_Pervious.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Btn_Pervious.UseVisualStyleBackColor = true;
            this.Btn_Pervious.Click += new System.EventHandler(this.Btn_First_Click);
            // 
            // Btn_First
            // 
            this.Btn_First.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_First.AutoSize = true;
            this.Btn_First.FlatAppearance.BorderSize = 0;
            this.Btn_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_First.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_First.Image = ((System.Drawing.Image)(resources.GetObject("Btn_First.Image")));
            this.Btn_First.Location = new System.Drawing.Point(115, 35);
            this.Btn_First.Name = "Btn_First";
            this.Btn_First.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_First.Size = new System.Drawing.Size(38, 38);
            this.Btn_First.TabIndex = 438;
            this.Btn_First.Tag = "1";
            this.Btn_First.UseVisualStyleBackColor = true;
            this.Btn_First.Click += new System.EventHandler(this.Btn_First_Click);
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(389, 113);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(78, 31);
            this.lblItemNo.TabIndex = 437;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplierNo
            // 
            this.lblSupplierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierNo.AutoSize = true;
            this.lblSupplierNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupplierNo.Location = new System.Drawing.Point(390, 77);
            this.lblSupplierNo.MinimumSize = new System.Drawing.Size(72, 32);
            this.lblSupplierNo.Name = "lblSupplierNo";
            this.lblSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplierNo.Size = new System.Drawing.Size(72, 32);
            this.lblSupplierNo.TabIndex = 436;
            this.lblSupplierNo.Tag = "SupNo";
            this.lblSupplierNo.Text = "رقم المورد";
            this.lblSupplierNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBox
            // 
            this.btnBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBox.AutoSize = true;
            this.btnBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBox.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBox.Location = new System.Drawing.Point(689, 201);
            this.btnBox.Name = "btnBox";
            this.btnBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBox.Size = new System.Drawing.Size(81, 43);
            this.btnBox.TabIndex = 435;
            this.btnBox.Tag = "BoxF9";
            this.btnBox.Text = "علبة F9";
            this.btnBox.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBox.UseVisualStyleBackColor = false;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(554, 109);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(73, 31);
            this.lblCategory.TabIndex = 434;
            this.lblCategory.Tag = "Cat";
            this.lblCategory.Text = "المجموعة ";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownHeight = 530;
            this.cmbCategory.DropDownWidth = 320;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Items.AddRange(new object[] {
            "ÇáãÌãæÚÉ"});
            this.cmbCategory.Location = new System.Drawing.Point(633, 111);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(140, 28);
            this.cmbCategory.TabIndex = 426;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(659, 43);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpPaymentDate.Size = new System.Drawing.Size(111, 26);
            this.dtpPaymentDate.TabIndex = 433;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.AutoSize = true;
            this.btnSet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.Location = new System.Drawing.Point(567, 32);
            this.btnSet.Name = "btnSet";
            this.btnSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSet.Size = new System.Drawing.Size(89, 43);
            this.btnSet.TabIndex = 432;
            this.btnSet.Tag = "Set";
            this.btnSet.Text = "تحديد";
            this.btnSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // chkPaymentDate
            // 
            this.chkPaymentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaymentDate.Checked = true;
            this.chkPaymentDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPaymentDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkPaymentDate.Location = new System.Drawing.Point(567, 3);
            this.chkPaymentDate.Name = "chkPaymentDate";
            this.chkPaymentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPaymentDate.Size = new System.Drawing.Size(182, 35);
            this.chkPaymentDate.TabIndex = 431;
            this.chkPaymentDate.Tag = "PayDate";
            this.chkPaymentDate.Text = "تحديد موعد الدفع \r\n";
            this.chkPaymentDate.UseVisualStyleBackColor = true;
            this.chkPaymentDate.CheckedChanged += new System.EventHandler(this.chkPaymentDate_CheckedChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(558, 142);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(75, 31);
            this.lblCompany.TabIndex = 430;
            this.lblCompany.Tag = "Com";
            this.lblCompany.Text = "الشركة ";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 530;
            this.cmbItemNo.DropDownWidth = 250;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.ItemHeight = 20;
            this.cmbItemNo.Location = new System.Drawing.Point(479, 110);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(74, 28);
            this.cmbItemNo.TabIndex = 427;
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbItemNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSupplierNo_KeyPress);
            // 
            // cmbSupplierNo
            // 
            this.cmbSupplierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierNo.FormattingEnabled = true;
            this.cmbSupplierNo.Location = new System.Drawing.Point(479, 78);
            this.cmbSupplierNo.Name = "cmbSupplierNo";
            this.cmbSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierNo.Size = new System.Drawing.Size(74, 28);
            this.cmbSupplierNo.TabIndex = 425;
            this.cmbSupplierNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbSupplierNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSupplierNo_KeyPress);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownHeight = 530;
            this.cmbCompany.DropDownWidth = 320;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Items.AddRange(new object[] {
            "ÇáãÌãæÚÉ"});
            this.cmbCompany.Location = new System.Drawing.Point(633, 142);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(138, 28);
            this.cmbCompany.TabIndex = 424;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            this.cmbCompany.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNo.Location = new System.Drawing.Point(196, 10);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInvoiceNo.Size = new System.Drawing.Size(112, 28);
            this.lblInvoiceNo.TabIndex = 419;
            this.lblInvoiceNo.Tag = "InvoiceNo";
            this.lblInvoiceNo.Text = "رقم الفاتورة";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInvoiceNo.Click += new System.EventHandler(this.lblInvoiceNo_Click);
            // 
            // cmbItemName
            // 
            this.cmbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.IntegralHeight = false;
            this.cmbItemName.ItemHeight = 20;
            this.cmbItemName.Location = new System.Drawing.Point(61, 112);
            this.cmbItemName.MaxDropDownItems = 25;
            this.cmbItemName.MinimumSize = new System.Drawing.Size(295, 0);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemName.Size = new System.Drawing.Size(295, 28);
            this.cmbItemName.TabIndex = 1;
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            this.cmbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemName_KeyPress);
            this.cmbItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyUp);
            // 
            // cmbSupplierName
            // 
            this.cmbSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplierName.DropDownHeight = 506;
            this.cmbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierName.FormattingEnabled = true;
            this.cmbSupplierName.IntegralHeight = false;
            this.cmbSupplierName.Location = new System.Drawing.Point(61, 78);
            this.cmbSupplierName.MaxDropDownItems = 25;
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierName.Size = new System.Drawing.Size(295, 28);
            this.cmbSupplierName.TabIndex = 0;
            this.cmbSupplierName.SelectedIndexChanged += new System.EventHandler(this.cmbSupplierName_SelectedIndexChanged);
            this.cmbSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbSupplierName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSupplierNo_KeyPress);
            this.cmbSupplierName.Leave += new System.EventHandler(this.cmbSupplierName_Leave);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(-2, 112);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(82, 31);
            this.lblItemName.TabIndex = 415;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "اسم الصنف";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(-3, 80);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplier.Size = new System.Drawing.Size(80, 31);
            this.lblSupplier.TabIndex = 414;
            this.lblSupplier.Tag = "Supplier";
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Last
            // 
            this.Btn_Last.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Last.AutoSize = true;
            this.Btn_Last.FlatAppearance.BorderSize = 0;
            this.Btn_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Last.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Last.Image")));
            this.Btn_Last.Location = new System.Drawing.Point(354, 35);
            this.Btn_Last.Name = "Btn_Last";
            this.Btn_Last.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Last.Size = new System.Drawing.Size(38, 38);
            this.Btn_Last.TabIndex = 413;
            this.Btn_Last.Tag = "4";
            this.Btn_Last.UseVisualStyleBackColor = true;
            this.Btn_Last.Click += new System.EventHandler(this.Btn_First_Click);
            // 
            // Btn_Next
            // 
            this.Btn_Next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Next.AutoSize = true;
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Next.Image")));
            this.Btn_Next.Location = new System.Drawing.Point(313, 35);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Next.Size = new System.Drawing.Size(38, 38);
            this.Btn_Next.TabIndex = 412;
            this.Btn_Next.Tag = "2";
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_First_Click);
            // 
            // txtNewInvoiceNo
            // 
            this.txtNewInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNewInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewInvoiceNo.Location = new System.Drawing.Point(197, 40);
            this.txtNewInvoiceNo.Name = "txtNewInvoiceNo";
            this.txtNewInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewInvoiceNo.Size = new System.Drawing.Size(113, 27);
            this.txtNewInvoiceNo.TabIndex = 422;
            this.txtNewInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewInvoiceNo.TextChanged += new System.EventHandler(this.txtNewInvoiceNo_TextChanged);
            this.txtNewInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewInvoiceNo_KeyPress);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(196, 41);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInvoiceNo.Size = new System.Drawing.Size(113, 24);
            this.txtInvoiceNo.TabIndex = 421;
            this.txtInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.lblUservalue);
            this.panel4.Controls.Add(this.chkNote);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Controls.Add(this.lblExtraCost);
            this.panel4.Controls.Add(this.txtExtraCost);
            this.panel4.Controls.Add(this.txtNote);
            this.panel4.Controls.Add(this.btnPayReceipt);
            this.panel4.Controls.Add(this.btnPrintBarcode);
            this.panel4.Controls.Add(this.btnImportInvoice);
            this.panel4.Controls.Add(this.txtNet);
            this.panel4.Controls.Add(this.lblNet);
            this.panel4.Controls.Add(this.lblDiscount);
            this.panel4.Controls.Add(this.txtDiscount);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.txtTotal);
            this.panel4.Controls.Add(this.rbnPercentage);
            this.panel4.Controls.Add(this.rbnValue);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 607);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(783, 117);
            this.panel4.TabIndex = 6;
            // 
            // lblUservalue
            // 
            this.lblUservalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUservalue.ForeColor = System.Drawing.Color.Black;
            this.lblUservalue.Location = new System.Drawing.Point(115, 86);
            this.lblUservalue.Name = "lblUservalue";
            this.lblUservalue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUservalue.Size = new System.Drawing.Size(204, 22);
            this.lblUservalue.TabIndex = 295;
            this.lblUservalue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkNote.Location = new System.Drawing.Point(6, 53);
            this.chkNote.Name = "chkNote";
            this.chkNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNote.Size = new System.Drawing.Size(65, 29);
            this.chkNote.TabIndex = 294;
            this.chkNote.Tag = "Note";
            this.chkNote.Text = "ملاحظة";
            this.chkNote.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(1, 86);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(84, 25);
            this.lblUserName.TabIndex = 293;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExtraCost
            // 
            this.lblExtraCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExtraCost.AutoSize = true;
            this.lblExtraCost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExtraCost.Location = new System.Drawing.Point(-3, 14);
            this.lblExtraCost.Name = "lblExtraCost";
            this.lblExtraCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExtraCost.Size = new System.Drawing.Size(93, 31);
            this.lblExtraCost.TabIndex = 292;
            this.lblExtraCost.Tag = "ExtraCost";
            this.lblExtraCost.Text = "تكلفة اضافية ";
            this.lblExtraCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExtraCost
            // 
            this.txtExtraCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtExtraCost.Location = new System.Drawing.Point(154, 11);
            this.txtExtraCost.Name = "txtExtraCost";
            this.txtExtraCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExtraCost.Size = new System.Drawing.Size(117, 27);
            this.txtExtraCost.TabIndex = 291;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.BackColor = System.Drawing.SystemColors.Info;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNote.Location = new System.Drawing.Point(115, 51);
            this.txtNote.MaxLength = 100;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.Size = new System.Drawing.Size(285, 27);
            this.txtNote.TabIndex = 290;
            // 
            // btnPayReceipt
            // 
            this.btnPayReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayReceipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPayReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayReceipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPayReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayReceipt.Location = new System.Drawing.Point(271, 6);
            this.btnPayReceipt.Name = "btnPayReceipt";
            this.btnPayReceipt.Size = new System.Drawing.Size(162, 41);
            this.btnPayReceipt.TabIndex = 289;
            this.btnPayReceipt.Tag = "PayReceiptF8";
            this.btnPayReceipt.Text = "ايصال صرفF8";
            this.btnPayReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPayReceipt.UseVisualStyleBackColor = false;
            this.btnPayReceipt.Click += new System.EventHandler(this.btnPayReceipt_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcode.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcode.Image")));
            this.btnPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintBarcode.Location = new System.Drawing.Point(626, 3);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrintBarcode.Size = new System.Drawing.Size(150, 41);
            this.btnPrintBarcode.TabIndex = 288;
            this.btnPrintBarcode.Tag = "PrintBarcode";
            this.btnPrintBarcode.Text = "طباعة باركود";
            this.btnPrintBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrintBarcode.UseVisualStyleBackColor = false;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // btnImportInvoice
            // 
            this.btnImportInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImportInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnImportInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnImportInvoice.Image")));
            this.btnImportInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportInvoice.Location = new System.Drawing.Point(626, 66);
            this.btnImportInvoice.Name = "btnImportInvoice";
            this.btnImportInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImportInvoice.Size = new System.Drawing.Size(150, 41);
            this.btnImportInvoice.TabIndex = 281;
            this.btnImportInvoice.Tag = "ImportInvoice";
            this.btnImportInvoice.Text = " توريد فاتورة";
            this.btnImportInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImportInvoice.UseVisualStyleBackColor = false;
            this.btnImportInvoice.Click += new System.EventHandler(this.btnImportInvoice_Click);
            // 
            // txtNet
            // 
            this.txtNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNet.BackColor = System.Drawing.SystemColors.Control;
            this.txtNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNet.Location = new System.Drawing.Point(501, 77);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNet.Size = new System.Drawing.Size(117, 27);
            this.txtNet.TabIndex = 280;
            this.txtNet.Text = "0.000";
            // 
            // lblNet
            // 
            this.lblNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNet.AutoSize = true;
            this.lblNet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(434, 78);
            this.lblNet.Name = "lblNet";
            this.lblNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNet.Size = new System.Drawing.Size(55, 31);
            this.lblNet.TabIndex = 279;
            this.lblNet.Tag = "Net";
            this.lblNet.Text = "الصافي";
            this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(434, 44);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDiscount.Size = new System.Drawing.Size(66, 31);
            this.lblDiscount.TabIndex = 278;
            this.lblDiscount.Tag = "Discount";
            this.lblDiscount.Text = "التخفيض";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Location = new System.Drawing.Point(501, 43);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiscount.Size = new System.Drawing.Size(117, 27);
            this.txtDiscount.TabIndex = 272;
            this.txtDiscount.Text = "0.000";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(434, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(61, 31);
            this.lblTotal.TabIndex = 277;
            this.lblTotal.Tag = "Total";
            this.lblTotal.Text = "الاجمالي";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(501, 9);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(117, 27);
            this.txtTotal.TabIndex = 276;
            this.txtTotal.Text = "0.000";
            // 
            // rbnPercentage
            // 
            this.rbnPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnPercentage.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.rbnPercentage.Location = new System.Drawing.Point(626, 45);
            this.rbnPercentage.Name = "rbnPercentage";
            this.rbnPercentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnPercentage.Size = new System.Drawing.Size(75, 21);
            this.rbnPercentage.TabIndex = 274;
            this.rbnPercentage.Tag = "Persentage";
            this.rbnPercentage.Text = "نسبة";
            this.rbnPercentage.UseVisualStyleBackColor = true;
            this.rbnPercentage.CheckedChanged += new System.EventHandler(this.rbnPercentage_CheckedChanged);
            // 
            // rbnValue
            // 
            this.rbnValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnValue.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.rbnValue.Location = new System.Drawing.Point(707, 41);
            this.rbnValue.Name = "rbnValue";
            this.rbnValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnValue.Size = new System.Drawing.Size(69, 29);
            this.rbnValue.TabIndex = 273;
            this.rbnValue.Tag = "Value";
            this.rbnValue.Text = "قيمة";
            this.rbnValue.UseVisualStyleBackColor = true;
            this.rbnValue.CheckedChanged += new System.EventHandler(this.rbnPercentage_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblExchangeRate);
            this.panel1.Controls.Add(this.txtExchangeRate);
            this.panel1.Controls.Add(this.btnNewInvoice);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnCloseInvoice);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.btnInsertItem);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnReturnItem);
            this.panel1.Controls.Add(this.btnItemInfo);
            this.panel1.Controls.Add(this.btnItemCard);
            this.panel1.Controls.Add(this.btnModifyInvoice);
            this.panel1.Controls.Add(this.btnFindInvoice);
            this.panel1.Controls.Add(this.btnBalanceSheet);
            this.panel1.Controls.Add(this.btnDeleteItem);
            this.panel1.Controls.Add(this.chkHideLogo);
            this.panel1.Controls.Add(this.chkHideDebt);
            this.panel1.Controls.Add(this.chkPrintPerview);
            this.panel1.Controls.Add(this.chkIncludeTax);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 727);
            this.panel1.TabIndex = 0;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExchangeRate.Location = new System.Drawing.Point(21, 664);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExchangeRate.Size = new System.Drawing.Size(87, 31);
            this.lblExchangeRate.TabIndex = 414;
            this.lblExchangeRate.Tag = "Total";
            this.lblExchangeRate.Text = "سعر الصرف";
            this.lblExchangeRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExchangeRate.Location = new System.Drawing.Point(15, 695);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExchangeRate.Size = new System.Drawing.Size(142, 36);
            this.txtExchangeRate.TabIndex = 413;
            this.txtExchangeRate.Leave += new System.EventHandler(this.txtExchangeRate_Leave);
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNewInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnNewInvoice.Image")));
            this.btnNewInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewInvoice.Location = new System.Drawing.Point(9, 46);
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnNewInvoice.TabIndex = 284;
            this.btnNewInvoice.Tag = "NewInvoice";
            this.btnNewInvoice.Text = "فاتورة جديدة F4";
            this.btnNewInvoice.UseVisualStyleBackColor = false;
            this.btnNewInvoice.Click += new System.EventHandler(this.btnNewInvoice_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(9, 132);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(166, 41);
            this.btnPrint.TabIndex = 285;
            this.btnPrint.Tag = "PrintF6";
            this.btnPrint.Text = "طباعة  F6";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCloseInvoice
            // 
            this.btnCloseInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCloseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCloseInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseInvoice.Image")));
            this.btnCloseInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseInvoice.Location = new System.Drawing.Point(9, 89);
            this.btnCloseInvoice.Name = "btnCloseInvoice";
            this.btnCloseInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCloseInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnCloseInvoice.TabIndex = 286;
            this.btnCloseInvoice.Tag = "CloseInvoice";
            this.btnCloseInvoice.Text = "اغلاق فاتورة F5";
            this.btnCloseInvoice.UseVisualStyleBackColor = false;
            this.btnCloseInvoice.Click += new System.EventHandler(this.btnCloseInvoice_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(9, 11);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 288;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(65, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 26);
            this.dtpDate.TabIndex = 289;
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInsertItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnInsertItem.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertItem.Image")));
            this.btnInsertItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertItem.Location = new System.Drawing.Point(9, 175);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnInsertItem.Size = new System.Drawing.Size(166, 41);
            this.btnInsertItem.TabIndex = 411;
            this.btnInsertItem.Tag = "InsertItemF3";
            this.btnInsertItem.Text = " ادراج صنف  F3";
            this.btnInsertItem.UseVisualStyleBackColor = false;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(9, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(166, 41);
            this.btnClose.TabIndex = 283;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItem.Image")));
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnItem.Location = new System.Drawing.Point(9, 390);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReturnItem.Size = new System.Drawing.Size(166, 41);
            this.btnReturnItem.TabIndex = 281;
            this.btnReturnItem.Tag = "ReturnItem";
            this.btnReturnItem.Text = "ترجيع بضاعة";
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnItemInfo
            // 
            this.btnItemInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemInfo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnItemInfo.Image")));
            this.btnItemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemInfo.Location = new System.Drawing.Point(9, 261);
            this.btnItemInfo.Name = "btnItemInfo";
            this.btnItemInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemInfo.Size = new System.Drawing.Size(166, 41);
            this.btnItemInfo.TabIndex = 280;
            this.btnItemInfo.Tag = "ItemInfoF11";
            this.btnItemInfo.Text = "معلومات الصنف F11";
            this.btnItemInfo.UseVisualStyleBackColor = false;
            this.btnItemInfo.Click += new System.EventHandler(this.btnItemInfo_Click);
            // 
            // btnItemCard
            // 
            this.btnItemCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemCard.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemCard.Image = ((System.Drawing.Image)(resources.GetObject("btnItemCard.Image")));
            this.btnItemCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemCard.Location = new System.Drawing.Point(9, 476);
            this.btnItemCard.Name = "btnItemCard";
            this.btnItemCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemCard.Size = new System.Drawing.Size(166, 41);
            this.btnItemCard.TabIndex = 279;
            this.btnItemCard.Tag = "ItemCard";
            this.btnItemCard.Text = "بطاقة الصنف";
            this.btnItemCard.UseVisualStyleBackColor = false;
            this.btnItemCard.Click += new System.EventHandler(this.btnItemCard_Click);
            // 
            // btnModifyInvoice
            // 
            this.btnModifyInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnModifyInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnModifyInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyInvoice.Image")));
            this.btnModifyInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyInvoice.Location = new System.Drawing.Point(9, 304);
            this.btnModifyInvoice.Name = "btnModifyInvoice";
            this.btnModifyInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnModifyInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnModifyInvoice.TabIndex = 278;
            this.btnModifyInvoice.Tag = "ModifyInvoice";
            this.btnModifyInvoice.Text = "تعديل فاتورة ";
            this.btnModifyInvoice.UseVisualStyleBackColor = false;
            this.btnModifyInvoice.Click += new System.EventHandler(this.btnModifyInvoice_Click);
            // 
            // btnFindInvoice
            // 
            this.btnFindInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFindInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFindInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnFindInvoice.Image")));
            this.btnFindInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFindInvoice.Location = new System.Drawing.Point(9, 347);
            this.btnFindInvoice.Name = "btnFindInvoice";
            this.btnFindInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFindInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnFindInvoice.TabIndex = 277;
            this.btnFindInvoice.Tag = "FindInvoice";
            this.btnFindInvoice.Text = "بحث عن فاتورة";
            this.btnFindInvoice.UseVisualStyleBackColor = false;
            this.btnFindInvoice.Click += new System.EventHandler(this.btnFindInvoice_Click);
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceSheet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBalanceSheet.Image = ((System.Drawing.Image)(resources.GetObject("btnBalanceSheet.Image")));
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBalanceSheet.Location = new System.Drawing.Point(9, 433);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBalanceSheet.Size = new System.Drawing.Size(166, 41);
            this.btnBalanceSheet.TabIndex = 282;
            this.btnBalanceSheet.Tag = "BalanceSheet";
            this.btnBalanceSheet.Text = "كشف الحساب";
            this.btnBalanceSheet.UseVisualStyleBackColor = false;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteItem.Location = new System.Drawing.Point(9, 218);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDeleteItem.Size = new System.Drawing.Size(166, 41);
            this.btnDeleteItem.TabIndex = 276;
            this.btnDeleteItem.Tag = "DeleteF2";
            this.btnDeleteItem.Text = "الغاء صنفF2";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // chkHideLogo
            // 
            this.chkHideLogo.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkHideLogo.Location = new System.Drawing.Point(27, 643);
            this.chkHideLogo.Name = "chkHideLogo";
            this.chkHideLogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideLogo.Size = new System.Drawing.Size(119, 27);
            this.chkHideLogo.TabIndex = 275;
            this.chkHideLogo.Tag = "HideLogo";
            this.chkHideLogo.Text = "اخفاء الشعار";
            this.chkHideLogo.UseVisualStyleBackColor = true;
            // 
            // chkHideDebt
            // 
            this.chkHideDebt.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkHideDebt.Location = new System.Drawing.Point(26, 613);
            this.chkHideDebt.Name = "chkHideDebt";
            this.chkHideDebt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideDebt.Size = new System.Drawing.Size(119, 28);
            this.chkHideDebt.TabIndex = 274;
            this.chkHideDebt.Tag = "HideDebt";
            this.chkHideDebt.Text = "اظهار الديون";
            this.chkHideDebt.UseVisualStyleBackColor = true;
            // 
            // chkPrintPerview
            // 
            this.chkPrintPerview.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPrintPerview.Location = new System.Drawing.Point(26, 561);
            this.chkPrintPerview.Name = "chkPrintPerview";
            this.chkPrintPerview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPerview.Size = new System.Drawing.Size(145, 26);
            this.chkPrintPerview.TabIndex = 272;
            this.chkPrintPerview.Tag = "PP";
            this.chkPrintPerview.Text = "معاينة قبل الطباعة";
            this.chkPrintPerview.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTax
            // 
            this.chkIncludeTax.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkIncludeTax.Location = new System.Drawing.Point(27, 587);
            this.chkIncludeTax.Name = "chkIncludeTax";
            this.chkIncludeTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIncludeTax.Size = new System.Drawing.Size(134, 27);
            this.chkIncludeTax.TabIndex = 273;
            this.chkIncludeTax.Tag = "IncludeTax";
            this.chkIncludeTax.Text = "تضمين الضريبة";
            this.chkIncludeTax.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(42, 53);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(131, 24);
            this.txtBarcode.TabIndex = 412;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // Purchase_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(987, 733);
            this.Controls.Add(this.TableLayout1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Purchase_Invoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Purchase_Invoice_FormClosed);
            this.Load += new System.EventHandler(this.Purchase_Invoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Purchase_Invoice_KeyDown);
            this.TableLayout1.ResumeLayout(false);
            this.TableLayout1.PerformLayout();
            this.TableLayout2.ResumeLayout(false);
            this.TableLayout2.PerformLayout();
            this.TableLayout3.ResumeLayout(false);
            this.TableLayout3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseInvoiceData)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grbNotesAndAlert.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout1;
        private System.Windows.Forms.TableLayoutPanel TableLayout2;
        private System.Windows.Forms.TableLayoutPanel TableLayout3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewInvoice;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCloseInvoice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnItemInfo;
        private System.Windows.Forms.Button btnItemCard;
        private System.Windows.Forms.Button btnModifyInvoice;
        private System.Windows.Forms.Button btnFindInvoice;
        private System.Windows.Forms.Button btnBalanceSheet;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.CheckBox chkHideLogo;
        private System.Windows.Forms.CheckBox chkHideDebt;
        private System.Windows.Forms.CheckBox chkPrintPerview;
        private System.Windows.Forms.CheckBox chkIncludeTax;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPurchaseInvoiceData;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grbNotesAndAlert;
        private System.Windows.Forms.RichTextBox RtxtNotesAndAlerts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btnImportInvoice;
        private System.Windows.Forms.MaskedTextBox txtNet;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.MaskedTextBox txtDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox txtTotal;
        private System.Windows.Forms.RadioButton rbnPercentage;
        private System.Windows.Forms.RadioButton rbnValue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button Btn_Pervious;
        private System.Windows.Forms.Button Btn_First;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblSupplierNo;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox chkPaymentDate;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.ComboBox cmbSupplierNo;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.MaskedTextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblCost;
        //private System.Windows.Forms.ComboBox cmbItemName;
       // private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Button Btn_Last;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.TextBox txtNewInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.MaskedTextBox txtCost;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox txtTotalStock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn exp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn box;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn in_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn back;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Newcost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemtax1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemtax2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTax2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTax1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCost;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.TextBox txtExchangeRate;

        private SergeUtils.EasyCompletionComboBox cmbSupplierName;
        private SergeUtils.EasyCompletionComboBox cmbItemName;
        private System.Windows.Forms.Label lblInNo;
        private System.Windows.Forms.TextBox txtInNo;
        private System.Windows.Forms.Label lblUservalue;
        private System.Windows.Forms.CheckBox chkNote;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblExtraCost;
        private System.Windows.Forms.MaskedTextBox txtExtraCost;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnPayReceipt;
    }
}