namespace BumedianBM.ArabicView
{
    partial class Order_Invoice
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
            ObjHelper = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Invoice));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpSetDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSet = new System.Windows.Forms.Button();
            this.chkSetDeliveryDate = new System.Windows.Forms.CheckBox();
            this.btnOrderNext = new System.Windows.Forms.Button();
            this.btnOrderEnd = new System.Windows.Forms.Button();
            this.btnOrderStrat = new System.Windows.Forms.Button();
            this.btnOrderPrevious = new System.Windows.Forms.Button();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.txtNewInvoiceNo = new System.Windows.Forms.MaskedTextBox();
            this.txtOrderInvoiceNo = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPackage = new System.Windows.Forms.ComboBox();
            this.txtCost = new System.Windows.Forms.MaskedTextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.MaskedTextBox();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lblPackage = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnBox = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbItemName = new System.Windows.Forms.ComboBox();
            this.cmbSupplierName = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.cmbSupplierNo = new System.Windows.Forms.ComboBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblSupplierNo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grpNoteAndAlert = new System.Windows.Forms.GroupBox();
            this.RTX_Notes = new System.Windows.Forms.RichTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvOrderInvoice = new System.Windows.Forms.DataGridView();
            this.itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.grpShowItems = new System.Windows.Forms.GroupBox();
            this.Txt_ItemLessthan = new System.Windows.Forms.TextBox();
            this.rbnItemLessthan = new System.Windows.Forms.RadioButton();
            this.rbnReorderItems = new System.Windows.Forms.RadioButton();
            this.rbnShowAll = new System.Windows.Forms.RadioButton();
            this.txtNote = new System.Windows.Forms.MaskedTextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtOrderTotal = new System.Windows.Forms.MaskedTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnItemInfo = new System.Windows.Forms.Button();
            this.btnPurchaseInvoice = new System.Windows.Forms.Button();
            this.btnModifyInvoice = new System.Windows.Forms.Button();
            this.btnFindInvoice = new System.Windows.Forms.Button();
            this.btnBalanceSheet = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCloseInvoice = new System.Windows.Forms.Button();
            this.btnNewInvoice = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkPrintPreview = new System.Windows.Forms.CheckBox();
            this.chkHideLogo = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grpNoteAndAlert.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInvoice)).BeginInit();
            this.panel6.SuspendLayout();
            this.grpShowItems.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.50988F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.49012F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.40462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.71098F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0289F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 716);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpSetDeliveryDate);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.chkSetDeliveryDate);
            this.panel1.Controls.Add(this.btnOrderNext);
            this.panel1.Controls.Add(this.btnOrderEnd);
            this.panel1.Controls.Add(this.btnOrderStrat);
            this.panel1.Controls.Add(this.btnOrderPrevious);
            this.panel1.Controls.Add(this.lblOrderNo);
            this.panel1.Controls.Add(this.txtNewInvoiceNo);
            this.panel1.Controls.Add(this.txtOrderInvoiceNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(181, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 68);
            this.panel1.TabIndex = 0;
            // 
            // dtpSetDeliveryDate
            // 
            this.dtpSetDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSetDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSetDeliveryDate.Location = new System.Drawing.Point(12, 33);
            this.dtpSetDeliveryDate.Name = "dtpSetDeliveryDate";
            this.dtpSetDeliveryDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpSetDeliveryDate.Size = new System.Drawing.Size(113, 26);
            this.dtpSetDeliveryDate.TabIndex = 242;
            this.dtpSetDeliveryDate.Value = new System.DateTime(2014, 1, 11, 10, 2, 0, 0);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Image = global::BumedianBM.Properties.Resources.set_payment_date_32;
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.Location = new System.Drawing.Point(133, 28);
            this.btnSet.Name = "btnSet";
            this.btnSet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSet.Size = new System.Drawing.Size(87, 33);
            this.btnSet.TabIndex = 241;
            this.btnSet.Tag = "Set";
            this.btnSet.Text = "تحديد";
            this.btnSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // chkSetDeliveryDate
            // 
            this.chkSetDeliveryDate.AutoSize = true;
            this.chkSetDeliveryDate.Location = new System.Drawing.Point(3, -3);
            this.chkSetDeliveryDate.Name = "chkSetDeliveryDate";
            this.chkSetDeliveryDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSetDeliveryDate.Size = new System.Drawing.Size(193, 35);
            this.chkSetDeliveryDate.TabIndex = 240;
            this.chkSetDeliveryDate.Tag = "SetDeliDate";
            this.chkSetDeliveryDate.Text = "تحديد موعد احضار الطلبية ";
            this.chkSetDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // btnOrderNext
            // 
            this.btnOrderNext.FlatAppearance.BorderSize = 0;
            this.btnOrderNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnOrderNext.Location = new System.Drawing.Point(572, 24);
            this.btnOrderNext.Name = "btnOrderNext";
            this.btnOrderNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOrderNext.Size = new System.Drawing.Size(36, 36);
            this.btnOrderNext.TabIndex = 237;
            this.btnOrderNext.Tag = "2";
            this.btnOrderNext.UseVisualStyleBackColor = true;
            this.btnOrderNext.Click += new System.EventHandler(this.btnOrderStrat_Click);
            // 
            // btnOrderEnd
            // 
            this.btnOrderEnd.FlatAppearance.BorderSize = 0;
            this.btnOrderEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderEnd.Image = global::BumedianBM.Properties.Resources.last_32;
            this.btnOrderEnd.Location = new System.Drawing.Point(614, 24);
            this.btnOrderEnd.Name = "btnOrderEnd";
            this.btnOrderEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOrderEnd.Size = new System.Drawing.Size(36, 36);
            this.btnOrderEnd.TabIndex = 236;
            this.btnOrderEnd.Tag = "4";
            this.btnOrderEnd.UseVisualStyleBackColor = true;
            this.btnOrderEnd.Click += new System.EventHandler(this.btnOrderStrat_Click);
            // 
            // btnOrderStrat
            // 
            this.btnOrderStrat.FlatAppearance.BorderSize = 0;
            this.btnOrderStrat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderStrat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderStrat.Image = global::BumedianBM.Properties.Resources.first_32;
            this.btnOrderStrat.Location = new System.Drawing.Point(376, 24);
            this.btnOrderStrat.Name = "btnOrderStrat";
            this.btnOrderStrat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOrderStrat.Size = new System.Drawing.Size(36, 36);
            this.btnOrderStrat.TabIndex = 235;
            this.btnOrderStrat.Tag = "1";
            this.btnOrderStrat.UseVisualStyleBackColor = true;
            this.btnOrderStrat.Click += new System.EventHandler(this.btnOrderStrat_Click);
            // 
            // btnOrderPrevious
            // 
            this.btnOrderPrevious.FlatAppearance.BorderSize = 0;
            this.btnOrderPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderPrevious.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnOrderPrevious.Location = new System.Drawing.Point(418, 24);
            this.btnOrderPrevious.Name = "btnOrderPrevious";
            this.btnOrderPrevious.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOrderPrevious.Size = new System.Drawing.Size(36, 36);
            this.btnOrderPrevious.TabIndex = 234;
            this.btnOrderPrevious.Tag = "3";
            this.btnOrderPrevious.UseVisualStyleBackColor = true;
            this.btnOrderPrevious.Click += new System.EventHandler(this.btnOrderStrat_Click);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(444, -3);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderNo.Size = new System.Drawing.Size(140, 31);
            this.lblOrderNo.TabIndex = 239;
            this.lblOrderNo.Tag = "OrderNo";
            this.lblOrderNo.Text = "رقم الطلب";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNewInvoiceNo
            // 
            this.txtNewInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewInvoiceNo.Location = new System.Drawing.Point(460, 29);
            this.txtNewInvoiceNo.Name = "txtNewInvoiceNo";
            this.txtNewInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewInvoiceNo.Size = new System.Drawing.Size(106, 27);
            this.txtNewInvoiceNo.TabIndex = 243;
            this.txtNewInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderInvoiceNo_KeyPress);
            // 
            // txtOrderInvoiceNo
            // 
            this.txtOrderInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtOrderInvoiceNo.Location = new System.Drawing.Point(460, 30);
            this.txtOrderInvoiceNo.Name = "txtOrderInvoiceNo";
            this.txtOrderInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrderInvoiceNo.Size = new System.Drawing.Size(106, 27);
            this.txtOrderInvoiceNo.TabIndex = 238;
            this.txtOrderInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.dtpOrderDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 68);
            this.panel2.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(-2, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 189;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(50, 29);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.RightToLeftLayout = true;
            this.dtpOrderDate.Size = new System.Drawing.Size(113, 26);
            this.dtpOrderDate.TabIndex = 188;
            this.dtpOrderDate.Value = new System.DateTime(2009, 10, 6, 0, 0, 0, 0);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(181, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.1893F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.8107F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(828, 528);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Controls.Add(this.lblCompany);
            this.panel3.Controls.Add(this.btnBox);
            this.panel3.Controls.Add(this.cmbCategory);
            this.panel3.Controls.Add(this.lblCategory);
            this.panel3.Controls.Add(this.cmbCompany);
            this.panel3.Controls.Add(this.cmbItemName);
            this.panel3.Controls.Add(this.cmbSupplierName);
            this.panel3.Controls.Add(this.lblItemName);
            this.panel3.Controls.Add(this.lblSupplier);
            this.panel3.Controls.Add(this.cmbItemNo);
            this.panel3.Controls.Add(this.cmbSupplierNo);
            this.panel3.Controls.Add(this.lblItemNo);
            this.panel3.Controls.Add(this.lblSupplierNo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 142);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.txtPackage, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtCost, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblStock, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCost, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblQty, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtStock, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtQuantity, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblPackage, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(724, 64);
            this.tableLayoutPanel3.TabIndex = 261;
            // 
            // txtPackage
            // 
            this.txtPackage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPackage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPackage.FormattingEnabled = true;
            this.txtPackage.Location = new System.Drawing.Point(546, 33);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPackage.Size = new System.Drawing.Size(175, 28);
            this.txtPackage.TabIndex = 261;
            this.txtPackage.SelectedIndexChanged += new System.EventHandler(this.txtPackage_SelectedIndexChanged);
            // 
            // txtCost
            // 
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(3, 33);
            this.txtCost.Name = "txtCost";
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCost.Size = new System.Drawing.Size(175, 27);
            this.txtCost.TabIndex = 234;
            this.txtCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            this.txtCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCost_KeyPress);
            this.txtCost.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblStock
            // 
            this.lblStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStock.Location = new System.Drawing.Point(365, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStock.Size = new System.Drawing.Size(105, 29);
            this.lblStock.TabIndex = 241;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Location = new System.Drawing.Point(3, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCost.Size = new System.Drawing.Size(122, 29);
            this.lblCost.TabIndex = 239;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "سعر الشراء";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQty.Location = new System.Drawing.Point(184, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQty.Size = new System.Drawing.Size(175, 29);
            this.lblQty.TabIndex = 240;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtStock.Location = new System.Drawing.Point(365, 33);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStock.Size = new System.Drawing.Size(175, 27);
            this.txtStock.TabIndex = 242;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.Location = new System.Drawing.Point(184, 33);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantity.Size = new System.Drawing.Size(175, 27);
            this.txtQuantity.TabIndex = 235;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtCost_Leave);
            // 
            // lblPackage
            // 
            this.lblPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPackage.Location = new System.Drawing.Point(546, 0);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPackage.Size = new System.Drawing.Size(89, 29);
            this.lblPackage.TabIndex = 252;
            this.lblPackage.Tag = "Package";
            this.lblPackage.Text = "العبوة";
            this.lblPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Location = new System.Drawing.Point(590, 33);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(71, 35);
            this.lblCompany.TabIndex = 260;
            this.lblCompany.Tag = "Com";
            this.lblCompany.Text = "الشركة ";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBox
            // 
            this.btnBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBox.Location = new System.Drawing.Point(732, 94);
            this.btnBox.Name = "btnBox";
            this.btnBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBox.Size = new System.Drawing.Size(81, 39);
            this.btnBox.TabIndex = 252;
            this.btnBox.Tag = "BoxF9";
            this.btnBox.Text = "علبة F9";
            this.btnBox.UseVisualStyleBackColor = false;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
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
            "All Categories"});
            this.cmbCategory.Location = new System.Drawing.Point(662, 4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(149, 28);
            this.cmbCategory.TabIndex = 259;
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Location = new System.Drawing.Point(589, 1);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(72, 35);
            this.lblCategory.TabIndex = 258;
            this.lblCategory.Tag = "Cat";
            this.lblCategory.Text = "المجموعة ";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            "All Companies"});
            this.cmbCompany.Location = new System.Drawing.Point(662, 38);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(149, 28);
            this.cmbCompany.TabIndex = 257;
            this.cmbCompany.Leave += new System.EventHandler(this.cmbCategory_Leave);
            // 
            // cmbItemName
            // 
            this.cmbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemName.DropDownHeight = 540;
            this.cmbItemName.DropDownWidth = 450;
            this.cmbItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.IntegralHeight = false;
            this.cmbItemName.ItemHeight = 20;
            this.cmbItemName.Location = new System.Drawing.Point(115, 42);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemName.Size = new System.Drawing.Size(216, 28);
            this.cmbItemName.TabIndex = 233;
            this.cmbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            this.cmbItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyUp);
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
            this.cmbSupplierName.Location = new System.Drawing.Point(115, 6);
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierName.Size = new System.Drawing.Size(216, 28);
            this.cmbSupplierName.TabIndex = 238;
            this.cmbSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            // 
            // lblItemName
            // 
            this.lblItemName.Location = new System.Drawing.Point(6, 42);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(97, 31);
            this.lblItemName.TabIndex = 237;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "اسم الصنف";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(3, 5);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplier.Size = new System.Drawing.Size(104, 31);
            this.lblSupplier.TabIndex = 236;
            this.lblSupplier.Tag = "Supplier";
            this.lblSupplier.Text = "مورد";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 540;
            this.cmbItemNo.DropDownWidth = 250;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(422, 38);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(162, 28);
            this.cmbItemNo.TabIndex = 248;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            this.cmbItemNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
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
            this.cmbSupplierNo.Location = new System.Drawing.Point(422, 3);
            this.cmbSupplierNo.Name = "cmbSupplierNo";
            this.cmbSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierNo.Size = new System.Drawing.Size(162, 28);
            this.cmbSupplierNo.TabIndex = 247;
            this.cmbSupplierNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveNext_KeyDown);
            this.cmbSupplierNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemNo.Location = new System.Drawing.Point(335, 38);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(83, 31);
            this.lblItemNo.TabIndex = 246;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplierNo
            // 
            this.lblSupplierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierNo.Location = new System.Drawing.Point(334, 3);
            this.lblSupplierNo.Name = "lblSupplierNo";
            this.lblSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplierNo.Size = new System.Drawing.Size(89, 31);
            this.lblSupplierNo.TabIndex = 245;
            this.lblSupplierNo.Tag = "SupNo";
            this.lblSupplierNo.Text = "رقم المورد";
            this.lblSupplierNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grpNoteAndAlert);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(823, 151);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 374);
            this.panel5.TabIndex = 178;
            // 
            // grpNoteAndAlert
            // 
            this.grpNoteAndAlert.Controls.Add(this.RTX_Notes);
            this.grpNoteAndAlert.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.grpNoteAndAlert.Location = new System.Drawing.Point(6, 3);
            this.grpNoteAndAlert.Name = "grpNoteAndAlert";
            this.grpNoteAndAlert.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpNoteAndAlert.Size = new System.Drawing.Size(152, 355);
            this.grpNoteAndAlert.TabIndex = 208;
            this.grpNoteAndAlert.TabStop = false;
            this.grpNoteAndAlert.Tag = "NotesAlerts";
            this.grpNoteAndAlert.Text = "مواعيد وملاحظات";
            // 
            // RTX_Notes
            // 
            this.RTX_Notes.BackColor = System.Drawing.SystemColors.Info;
            this.RTX_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.RTX_Notes.Location = new System.Drawing.Point(1, 28);
            this.RTX_Notes.Name = "RTX_Notes";
            this.RTX_Notes.ReadOnly = true;
            this.RTX_Notes.Size = new System.Drawing.Size(144, 320);
            this.RTX_Notes.TabIndex = 2;
            this.RTX_Notes.Text = "";
            this.RTX_Notes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RTX_Notes_MouseDoubleClick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvOrderInvoice);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 151);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(814, 374);
            this.panel8.TabIndex = 179;
            // 
            // dgvOrderInvoice
            // 
            this.dgvOrderInvoice.AllowUserToAddRows = false;
            this.dgvOrderInvoice.AllowUserToDeleteRows = false;
            this.dgvOrderInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderInvoice.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrderInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderInvoice.ColumnHeadersHeight = 36;
            this.dgvOrderInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemno,
            this.BarcodeID,
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
            this.back});
            this.dgvOrderInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderInvoice.GridColor = System.Drawing.SystemColors.Control;
            this.dgvOrderInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderInvoice.Name = "dgvOrderInvoice";
            this.dgvOrderInvoice.ReadOnly = true;
            this.dgvOrderInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvOrderInvoice.RowHeadersWidth = 13;
            this.dgvOrderInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOrderInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderInvoice.Size = new System.Drawing.Size(814, 374);
            this.dgvOrderInvoice.TabIndex = 178;
            // 
            // itemno
            // 
            this.itemno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.itemno.DataPropertyName = "ItemNo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemno.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemno.HeaderText = "رقم الصنف";
            this.itemno.Name = "itemno";
            this.itemno.ReadOnly = true;
            this.itemno.Visible = false;
            this.itemno.Width = 103;
            // 
            // BarcodeID
            // 
            this.BarcodeID.DataPropertyName = "BarcodeID";
            this.BarcodeID.HeaderText = "BarcodeID";
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.ReadOnly = true;
            this.BarcodeID.Visible = false;
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
            this.item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_name.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.item_name.HeaderText = "البيان";
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            // 
            // exp_date
            // 
            this.exp_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.exp_date.DataPropertyName = "ItemExpiry";
            this.exp_date.HeaderText = "الصلاحية";
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
            this.user.HeaderText = "المستخدم";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Visible = false;
            // 
            // back
            // 
            this.back.HeaderText = "المرجع ";
            this.back.Name = "back";
            this.back.ReadOnly = true;
            this.back.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblUser);
            this.panel6.Controls.Add(this.lblUserName);
            this.panel6.Controls.Add(this.chkNote);
            this.panel6.Controls.Add(this.grpShowItems);
            this.panel6.Controls.Add(this.txtNote);
            this.panel6.Controls.Add(this.lblTotal);
            this.panel6.Controls.Add(this.txtOrderTotal);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(181, 611);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(828, 102);
            this.panel6.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(597, 67);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUser.Size = new System.Drawing.Size(215, 28);
            this.lblUser.TabIndex = 244;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(472, 67);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(119, 28);
            this.lblUserName.TabIndex = 243;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkNote.Location = new System.Drawing.Point(838, 2);
            this.chkNote.Name = "chkNote";
            this.chkNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkNote.Size = new System.Drawing.Size(70, 32);
            this.chkNote.TabIndex = 241;
            this.chkNote.Tag = "Note";
            this.chkNote.Text = "ملاحظة";
            this.chkNote.UseVisualStyleBackColor = true;
            // 
            // grpShowItems
            // 
            this.grpShowItems.Controls.Add(this.Txt_ItemLessthan);
            this.grpShowItems.Controls.Add(this.rbnItemLessthan);
            this.grpShowItems.Controls.Add(this.rbnReorderItems);
            this.grpShowItems.Controls.Add(this.rbnShowAll);
            this.grpShowItems.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.grpShowItems.Location = new System.Drawing.Point(0, -3);
            this.grpShowItems.Name = "grpShowItems";
            this.grpShowItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpShowItems.Size = new System.Drawing.Size(196, 103);
            this.grpShowItems.TabIndex = 236;
            this.grpShowItems.TabStop = false;
            this.grpShowItems.Tag = "ShowItem";
            this.grpShowItems.Text = "عرض لاصناف ...";
            // 
            // Txt_ItemLessthan
            // 
            this.Txt_ItemLessthan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Txt_ItemLessthan.Location = new System.Drawing.Point(6, 76);
            this.Txt_ItemLessthan.MaxLength = 100;
            this.Txt_ItemLessthan.Name = "Txt_ItemLessthan";
            this.Txt_ItemLessthan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_ItemLessthan.Size = new System.Drawing.Size(109, 27);
            this.Txt_ItemLessthan.TabIndex = 228;
            this.Txt_ItemLessthan.Text = "1";
            this.Txt_ItemLessthan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_ItemLessthan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_ItemLessthan_KeyPress);
            // 
            // rbnItemLessthan
            // 
            this.rbnItemLessthan.Location = new System.Drawing.Point(3, 44);
            this.rbnItemLessthan.Name = "rbnItemLessthan";
            this.rbnItemLessthan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnItemLessthan.Size = new System.Drawing.Size(154, 30);
            this.rbnItemLessthan.TabIndex = 228;
            this.rbnItemLessthan.TabStop = true;
            this.rbnItemLessthan.Tag = "ItemLessthan";
            this.rbnItemLessthan.Text = "الاصناف اقل من \r\n";
            this.rbnItemLessthan.UseVisualStyleBackColor = true;
            // 
            // rbnReorderItems
            // 
            this.rbnReorderItems.Location = new System.Drawing.Point(92, 22);
            this.rbnReorderItems.Name = "rbnReorderItems";
            this.rbnReorderItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnReorderItems.Size = new System.Drawing.Size(92, 30);
            this.rbnReorderItems.TabIndex = 1;
            this.rbnReorderItems.TabStop = true;
            this.rbnReorderItems.Tag = "Reorder";
            this.rbnReorderItems.Text = "النواقص";
            this.rbnReorderItems.UseVisualStyleBackColor = true;
            // 
            // rbnShowAll
            // 
            this.rbnShowAll.Location = new System.Drawing.Point(3, 22);
            this.rbnShowAll.Name = "rbnShowAll";
            this.rbnShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnShowAll.Size = new System.Drawing.Size(90, 30);
            this.rbnShowAll.TabIndex = 0;
            this.rbnShowAll.TabStop = true;
            this.rbnShowAll.Tag = "All";
            this.rbnShowAll.Text = "الكل ";
            this.rbnShowAll.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.SystemColors.Info;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNote.Location = new System.Drawing.Point(500, 5);
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.Size = new System.Drawing.Size(332, 27);
            this.txtNote.TabIndex = 240;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(230, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(61, 31);
            this.lblTotal.TabIndex = 239;
            this.lblTotal.Tag = "Total";
            this.lblTotal.Text = "الاجمالي";
            // 
            // txtOrderTotal
            // 
            this.txtOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtOrderTotal.Location = new System.Drawing.Point(297, 6);
            this.txtOrderTotal.Name = "txtOrderTotal";
            this.txtOrderTotal.ReadOnly = true;
            this.txtOrderTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderTotal.Size = new System.Drawing.Size(117, 27);
            this.txtOrderTotal.TabIndex = 238;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 77);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(172, 528);
            this.panel7.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnReturnItem);
            this.groupBox5.Controls.Add(this.btnItemInfo);
            this.groupBox5.Controls.Add(this.btnPurchaseInvoice);
            this.groupBox5.Controls.Add(this.btnModifyInvoice);
            this.groupBox5.Controls.Add(this.btnFindInvoice);
            this.groupBox5.Controls.Add(this.btnBalanceSheet);
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.btnAddItem);
            this.groupBox5.Controls.Add(this.btnPrint);
            this.groupBox5.Controls.Add(this.btnCloseInvoice);
            this.groupBox5.Controls.Add(this.btnNewInvoice);
            this.groupBox5.Controls.Add(this.txtBarcode);
            this.groupBox5.Location = new System.Drawing.Point(3, -13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(170, 521);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(164, 41);
            this.btnClose.TabIndex = 11;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnItem.Image = global::BumedianBM.Properties.Resources.return_item_32;
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItem.Location = new System.Drawing.Point(0, 354);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReturnItem.Size = new System.Drawing.Size(164, 41);
            this.btnReturnItem.TabIndex = 8;
            this.btnReturnItem.Tag = "ReturnItem";
            this.btnReturnItem.Text = "استرجاع صنف";
            this.btnReturnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnItemInfo
            // 
            this.btnItemInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemInfo.Image = global::BumedianBM.Properties.Resources.item_info_32;
            this.btnItemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemInfo.Location = new System.Drawing.Point(0, 228);
            this.btnItemInfo.Name = "btnItemInfo";
            this.btnItemInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemInfo.Size = new System.Drawing.Size(164, 41);
            this.btnItemInfo.TabIndex = 5;
            this.btnItemInfo.Tag = "ItemInfoF11";
            this.btnItemInfo.Text = "معلومات الصنف F11";
            this.btnItemInfo.UseVisualStyleBackColor = false;
            this.btnItemInfo.Click += new System.EventHandler(this.btnItemInfo_Click);
            // 
            // btnPurchaseInvoice
            // 
            this.btnPurchaseInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPurchaseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseInvoice.Image = global::BumedianBM.Properties.Resources.purchases_32;
            this.btnPurchaseInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseInvoice.Location = new System.Drawing.Point(0, 438);
            this.btnPurchaseInvoice.Name = "btnPurchaseInvoice";
            this.btnPurchaseInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPurchaseInvoice.Size = new System.Drawing.Size(164, 41);
            this.btnPurchaseInvoice.TabIndex = 10;
            this.btnPurchaseInvoice.Tag = "PurchaseInvoice";
            this.btnPurchaseInvoice.Text = "فاتورة مشتريات";
            this.btnPurchaseInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPurchaseInvoice.UseVisualStyleBackColor = false;
            this.btnPurchaseInvoice.Click += new System.EventHandler(this.btnPurchaseInvoice_Click);
            // 
            // btnModifyInvoice
            // 
            this.btnModifyInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnModifyInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyInvoice.Image = global::BumedianBM.Properties.Resources.invoice_modfy_32;
            this.btnModifyInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyInvoice.Location = new System.Drawing.Point(0, 270);
            this.btnModifyInvoice.Name = "btnModifyInvoice";
            this.btnModifyInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModifyInvoice.Size = new System.Drawing.Size(164, 41);
            this.btnModifyInvoice.TabIndex = 6;
            this.btnModifyInvoice.Tag = "ModifyInvoice";
            this.btnModifyInvoice.Text = "تعديل فاتورة ";
            this.btnModifyInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModifyInvoice.UseVisualStyleBackColor = false;
            this.btnModifyInvoice.Click += new System.EventHandler(this.btnModifyInvoice_Click);
            // 
            // btnFindInvoice
            // 
            this.btnFindInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFindInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindInvoice.Image = global::BumedianBM.Properties.Resources.invoice_find_32;
            this.btnFindInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindInvoice.Location = new System.Drawing.Point(0, 312);
            this.btnFindInvoice.Name = "btnFindInvoice";
            this.btnFindInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFindInvoice.Size = new System.Drawing.Size(164, 41);
            this.btnFindInvoice.TabIndex = 7;
            this.btnFindInvoice.Tag = "FindInvoice";
            this.btnFindInvoice.Text = "بحث عن فاتورة";
            this.btnFindInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFindInvoice.UseVisualStyleBackColor = false;
            this.btnFindInvoice.Click += new System.EventHandler(this.btnFindInvoice_Click);
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceSheet.Image = global::BumedianBM.Properties.Resources.balance_sheet_32;
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceSheet.Location = new System.Drawing.Point(0, 396);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBalanceSheet.Size = new System.Drawing.Size(164, 41);
            this.btnBalanceSheet.TabIndex = 9;
            this.btnBalanceSheet.Tag = "BalanceSheet";
            this.btnBalanceSheet.Text = "كشف الحساب";
            this.btnBalanceSheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalanceSheet.UseVisualStyleBackColor = false;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(0, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(164, 41);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Tag = "DeleteF2";
            this.btnDelete.Text = "الغاء صنف  F2";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Image = global::BumedianBM.Properties.Resources.insert_item_32;
            this.btnAddItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.Location = new System.Drawing.Point(0, 144);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddItem.Size = new System.Drawing.Size(164, 41);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Tag = "AddItem";
            this.btnAddItem.Text = " ادراج صنف  F3";
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(0, 102);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(164, 41);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Tag = "PrintF6";
            this.btnPrint.Text = "طباعة  F6";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCloseInvoice
            // 
            this.btnCloseInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCloseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInvoice.Image = global::BumedianBM.Properties.Resources.invoice_save_322;
            this.btnCloseInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseInvoice.Location = new System.Drawing.Point(0, 60);
            this.btnCloseInvoice.Name = "btnCloseInvoice";
            this.btnCloseInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCloseInvoice.Size = new System.Drawing.Size(164, 41);
            this.btnCloseInvoice.TabIndex = 2;
            this.btnCloseInvoice.Tag = "CloseInvoice";
            this.btnCloseInvoice.Text = "اغلاق فاتورة F5";
            this.btnCloseInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseInvoice.UseVisualStyleBackColor = false;
            this.btnCloseInvoice.Click += new System.EventHandler(this.btnCloseInvoice_Click);
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewInvoice.Image = global::BumedianBM.Properties.Resources.invoice_new_321;
            this.btnNewInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewInvoice.Location = new System.Drawing.Point(0, 18);
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNewInvoice.Size = new System.Drawing.Size(164, 41);
            this.btnNewInvoice.TabIndex = 1;
            this.btnNewInvoice.Tag = "NewInvoice";
            this.btnNewInvoice.Text = "فاتورة جديدة F4";
            this.btnNewInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewInvoice.UseVisualStyleBackColor = false;
            this.btnNewInvoice.Click += new System.EventHandler(this.btnNewInvoice_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(34, 20);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 36);
            this.txtBarcode.TabIndex = 239;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkPrintPreview);
            this.panel4.Controls.Add(this.chkHideLogo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 611);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(172, 102);
            this.panel4.TabIndex = 5;
            // 
            // chkPrintPreview
            // 
            this.chkPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkPrintPreview.Location = new System.Drawing.Point(10, 4);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPreview.Size = new System.Drawing.Size(148, 32);
            this.chkPrintPreview.TabIndex = 237;
            this.chkPrintPreview.Tag = "PP";
            this.chkPrintPreview.Text = "معاينة قبل الطباعة";
            this.chkPrintPreview.UseVisualStyleBackColor = true;
            // 
            // chkHideLogo
            // 
            this.chkHideLogo.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkHideLogo.Location = new System.Drawing.Point(10, 29);
            this.chkHideLogo.Name = "chkHideLogo";
            this.chkHideLogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideLogo.Size = new System.Drawing.Size(118, 32);
            this.chkHideLogo.TabIndex = 242;
            this.chkHideLogo.Tag = "HidenLogo";
            this.chkHideLogo.Text = "اخفاء الشعار";
            this.chkHideLogo.UseVisualStyleBackColor = true;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // Order_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1012, 716);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Order_Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Order_Invoice_FormClosed);
            this.Load += new System.EventHandler(this.Order_Invoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Order_Invoice_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.grpNoteAndAlert.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInvoice)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.grpShowItems.ResumeLayout(false);
            this.grpShowItems.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtNewInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtpSetDeliveryDate;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox chkSetDeliveryDate;
        private System.Windows.Forms.MaskedTextBox txtOrderInvoiceNo;
        private System.Windows.Forms.Button btnOrderNext;
        private System.Windows.Forms.Button btnOrderEnd;
        private System.Windows.Forms.Button btnOrderStrat;
        private System.Windows.Forms.Button btnOrderPrevious;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.MaskedTextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.MaskedTextBox txtCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.ComboBox cmbItemName;
        private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.ComboBox cmbSupplierNo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblSupplierNo;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grpShowItems;
        private System.Windows.Forms.TextBox Txt_ItemLessthan;
        private System.Windows.Forms.RadioButton rbnItemLessthan;
        private System.Windows.Forms.RadioButton rbnReorderItems;
        private System.Windows.Forms.RadioButton rbnShowAll;
        private System.Windows.Forms.CheckBox chkHideLogo;
        private System.Windows.Forms.CheckBox chkPrintPreview;
        private System.Windows.Forms.CheckBox chkNote;
        private System.Windows.Forms.MaskedTextBox txtNote;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox txtOrderTotal;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnItemInfo;
        private System.Windows.Forms.Button btnPurchaseInvoice;
        private System.Windows.Forms.Button btnModifyInvoice;
        private System.Windows.Forms.Button btnFindInvoice;
        private System.Windows.Forms.Button btnBalanceSheet;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCloseInvoice;
        private System.Windows.Forms.Button btnNewInvoice;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.GroupBox grpNoteAndAlert;
        private System.Windows.Forms.RichTextBox RTX_Notes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvOrderInvoice;
        private System.Windows.Forms.Label lblUser;
       // private DataSet dataSet1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.ComboBox txtPackage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeID;
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
    }
}