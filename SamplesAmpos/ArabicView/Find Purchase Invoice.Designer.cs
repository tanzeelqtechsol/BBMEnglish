namespace BumedianBM.ArabicView
{
     partial class Find_Purchase_Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Find_Purchase_Invoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSupplierNo = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.lblFromTime = new System.Windows.Forms.Label();
            this.lblToTime = new System.Windows.Forms.Label();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblSupplierNo = new System.Windows.Forms.Label();
            this.cmbSupplierName = new SergeUtils.EasyCompletionComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnGoToInvoice = new System.Windows.Forms.Button();
            this.btnItemInformation = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnPurchaseInvoice = new System.Windows.Forms.Button();
            this.btnDetailedReport = new System.Windows.Forms.Button();
            this.btnBalanceSheet = new System.Windows.Forms.Button();
            this.btnItemCard = new System.Windows.Forms.Button();
            this.btnEndOfTheDay = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.MaskedTextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.MaskedTextBox();
            this.lblProfit = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.MaskedTextBox();
            this.txtSale = new System.Windows.Forms.MaskedTextBox();
            this.lblSale = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvFindInvoice = new System.Windows.Forms.DataGridView();
            this.newinvno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.MaskedTextBox();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.MaskedTextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grbNotes = new System.Windows.Forms.GroupBox();
            this.RtxtNotesAndAlerts = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvFindItem = new System.Windows.Forms.DataGridView();
            this.itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exp_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPaid = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_Net = new System.Windows.Forms.Label();
            this.Lbl_Paid = new System.Windows.Forms.Label();
            this.Lbl_TotalDiscount = new System.Windows.Forms.Label();
            this.txtNet = new System.Windows.Forms.MaskedTextBox();
            this.txtTotalDiscount = new System.Windows.Forms.MaskedTextBox();
            this.txtTotal = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.Lbl_Remaining = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.MaskedTextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblFindInvoice = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindInvoice)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.grbNotes.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindItem)).BeginInit();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.48352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.51649F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1012, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.cmbSupplierNo);
            this.panel1.Controls.Add(this.lblSupplier);
            this.panel1.Controls.Add(this.lblFromDate);
            this.panel1.Controls.Add(this.dtpFromTime);
            this.panel1.Controls.Add(this.lblFromTime);
            this.panel1.Controls.Add(this.lblToTime);
            this.panel1.Controls.Add(this.dtpToTime);
            this.panel1.Controls.Add(this.dtpFromDate);
            this.panel1.Controls.Add(this.lblToDate);
            this.panel1.Controls.Add(this.lblSupplierNo);
            this.panel1.Controls.Add(this.cmbSupplierName);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Controls.Add(this.cmbUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(183, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 101);
            this.panel1.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(524, 68);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUser.Size = new System.Drawing.Size(88, 31);
            this.lblUser.TabIndex = 309;
            this.lblUser.Tag = "User";
            this.lblUser.Text = "المستخدم";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(628, 2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpToDate.Size = new System.Drawing.Size(122, 26);
            this.dtpToDate.TabIndex = 308;
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
            this.cmbSupplierNo.Location = new System.Drawing.Point(417, 73);
            this.cmbSupplierNo.Name = "cmbSupplierNo";
            this.cmbSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierNo.Size = new System.Drawing.Size(90, 28);
            this.cmbSupplierNo.TabIndex = 299;
            this.cmbSupplierNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierName_KeyDown);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(0, 77);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplier.Size = new System.Drawing.Size(41, 31);
            this.lblSupplier.TabIndex = 296;
            this.lblSupplier.Tag = "Supplier";
            this.lblSupplier.Text = "مورد\r\n";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(292, 8);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFromDate.Size = new System.Drawing.Size(67, 31);
            this.lblFromDate.TabIndex = 289;
            this.lblFromDate.Tag = "FD";
            this.lblFromDate.Text = "من تاريخ\r\n";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(374, 34);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(122, 26);
            this.dtpFromTime.TabIndex = 295;
            this.dtpFromTime.Value = new System.DateTime(2008, 10, 15, 16, 25, 0, 0);
            // 
            // lblFromTime
            // 
            this.lblFromTime.AutoSize = true;
            this.lblFromTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromTime.Location = new System.Drawing.Point(291, 37);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFromTime.Size = new System.Drawing.Size(77, 31);
            this.lblFromTime.TabIndex = 292;
            this.lblFromTime.Tag = "FT";
            this.lblFromTime.Text = "من الساعة\r\n";
            this.lblFromTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToTime
            // 
            this.lblToTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToTime.Location = new System.Drawing.Point(508, 33);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblToTime.Size = new System.Drawing.Size(114, 31);
            this.lblToTime.TabIndex = 294;
            this.lblToTime.Tag = "TT";
            this.lblToTime.Text = "حتى تاريخ \r\n";
            this.lblToTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpToTime
            // 
            this.dtpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(628, 38);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(122, 26);
            this.dtpToTime.TabIndex = 293;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(374, 5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFromDate.Size = new System.Drawing.Size(122, 26);
            this.dtpFromDate.TabIndex = 291;
            // 
            // lblToDate
            // 
            this.lblToDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(506, -3);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblToDate.Size = new System.Drawing.Size(114, 31);
            this.lblToDate.TabIndex = 290;
            this.lblToDate.Tag = "TD";
            this.lblToDate.Text = "حتى تاريخ \r\n";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSupplierNo
            // 
            this.lblSupplierNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupplierNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSupplierNo.Location = new System.Drawing.Point(316, 70);
            this.lblSupplierNo.Name = "lblSupplierNo";
            this.lblSupplierNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSupplierNo.Size = new System.Drawing.Size(111, 31);
            this.lblSupplierNo.TabIndex = 298;
            this.lblSupplierNo.Tag = "SupplierNo";
            this.lblSupplierNo.Text = "رقم المورد\r\n";
            this.lblSupplierNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSupplierName
            // 
            this.cmbSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSupplierName.DropDownHeight = 600;
            this.cmbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierName.FormattingEnabled = true;
            this.cmbSupplierName.IntegralHeight = false;
            this.cmbSupplierName.Location = new System.Drawing.Point(78, 73);
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSupplierName.Size = new System.Drawing.Size(212, 28);
            this.cmbSupplierName.TabIndex = 297;
            this.cmbSupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierName_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkAll.Location = new System.Drawing.Point(753, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAll.Size = new System.Drawing.Size(61, 35);
            this.chkAll.TabIndex = 305;
            this.chkAll.Text = "الكل \r\n";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DropDownHeight = 600;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Items.AddRange(new object[] {
            "All Categorys"});
            this.cmbCategory.Location = new System.Drawing.Point(79, 6);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(178, 28);
            this.cmbCategory.TabIndex = 304;
            this.cmbCategory.Visible = false;
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierName_KeyDown);
            // 
            // lblCategory
            // 
            this.lblCategory.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(-2, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(80, 29);
            this.lblCategory.TabIndex = 303;
            this.lblCategory.Tag = "Cat";
            this.lblCategory.Text = "المجموعة \r\n";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCategory.Visible = false;
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(-2, 41);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(80, 30);
            this.lblCompany.TabIndex = 302;
            this.lblCompany.Tag = "Com";
            this.lblCompany.Text = "الشركة \r\n";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCompany.Visible = false;
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DropDownHeight = 600;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Items.AddRange(new object[] {
            "All Companys"});
            this.cmbCompany.Location = new System.Drawing.Point(78, 39);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(178, 28);
            this.cmbCompany.TabIndex = 301;
            this.cmbCompany.Visible = false;
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierName_KeyDown);
            // 
            // cmbUser
            // 
            this.cmbUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUser.DropDownHeight = 506;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.DropDownWidth = 178;
            this.cmbUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.IntegralHeight = false;
            this.cmbUser.Location = new System.Drawing.Point(643, 71);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbUser.Size = new System.Drawing.Size(178, 28);
            this.cmbUser.TabIndex = 300;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.btnGoToInvoice);
            this.panel2.Controls.Add(this.btnItemInformation);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnReturnItem);
            this.panel2.Controls.Add(this.btnPurchaseInvoice);
            this.panel2.Controls.Add(this.btnDetailedReport);
            this.panel2.Controls.Add(this.btnBalanceSheet);
            this.panel2.Controls.Add(this.btnItemCard);
            this.panel2.Controls.Add(this.btnEndOfTheDay);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 536);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(4, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(166, 41);
            this.btnClose.TabIndex = 13;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.Location = new System.Drawing.Point(4, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFind.Size = new System.Drawing.Size(166, 41);
            this.btnFind.TabIndex = 2;
            this.btnFind.Tag = "Find";
            this.btnFind.Text = "ابحث ";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnGoToInvoice
            // 
            this.btnGoToInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGoToInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnGoToInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnGoToInvoice.Image")));
            this.btnGoToInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoToInvoice.Location = new System.Drawing.Point(4, 48);
            this.btnGoToInvoice.Name = "btnGoToInvoice";
            this.btnGoToInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGoToInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnGoToInvoice.TabIndex = 3;
            this.btnGoToInvoice.Tag = "GoToInvoice";
            this.btnGoToInvoice.Text = "انتقال الى فاتورة \r\n";
            this.btnGoToInvoice.UseVisualStyleBackColor = false;
            this.btnGoToInvoice.Click += new System.EventHandler(this.btnGoToInvoice_Click);
            // 
            // btnItemInformation
            // 
            this.btnItemInformation.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemInformation.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemInformation.Image = ((System.Drawing.Image)(resources.GetObject("btnItemInformation.Image")));
            this.btnItemInformation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemInformation.Location = new System.Drawing.Point(4, 224);
            this.btnItemInformation.Name = "btnItemInformation";
            this.btnItemInformation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemInformation.Size = new System.Drawing.Size(166, 41);
            this.btnItemInformation.TabIndex = 10;
            this.btnItemInformation.Tag = "ItemInfo";
            this.btnItemInformation.Text = "معلومات الصنف F11";
            this.btnItemInformation.UseVisualStyleBackColor = false;
            this.btnItemInformation.Click += new System.EventHandler(this.btnItemInformation_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(4, 92);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(166, 41);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItem.Image")));
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturnItem.Location = new System.Drawing.Point(4, 136);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReturnItem.Size = new System.Drawing.Size(166, 41);
            this.btnReturnItem.TabIndex = 5;
            this.btnReturnItem.Tag = "ReturnItem";
            this.btnReturnItem.Text = "ترجيع بضاعة \r\n";
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnPurchaseInvoice
            // 
            this.btnPurchaseInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPurchaseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseInvoice.Image = global::BumedianBM.Properties.Resources.purchases_32;
            this.btnPurchaseInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPurchaseInvoice.Location = new System.Drawing.Point(4, 356);
            this.btnPurchaseInvoice.Name = "btnPurchaseInvoice";
            this.btnPurchaseInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPurchaseInvoice.Size = new System.Drawing.Size(166, 41);
            this.btnPurchaseInvoice.TabIndex = 11;
            this.btnPurchaseInvoice.Tag = "PurInvoice";
            this.btnPurchaseInvoice.Text = "فاتورة مشتريات\r\n";
            this.btnPurchaseInvoice.UseVisualStyleBackColor = false;
            this.btnPurchaseInvoice.Click += new System.EventHandler(this.btnPurchaseInvoice_Click);
            // 
            // btnDetailedReport
            // 
            this.btnDetailedReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDetailedReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailedReport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDetailedReport.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailedReport.Image")));
            this.btnDetailedReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailedReport.Location = new System.Drawing.Point(4, 180);
            this.btnDetailedReport.Name = "btnDetailedReport";
            this.btnDetailedReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDetailedReport.Size = new System.Drawing.Size(166, 41);
            this.btnDetailedReport.TabIndex = 6;
            this.btnDetailedReport.Tag = "DetailedReport";
            this.btnDetailedReport.Text = "تقرير مفصل \r\n";
            this.btnDetailedReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetailedReport.UseVisualStyleBackColor = false;
            this.btnDetailedReport.Click += new System.EventHandler(this.btnDetailedReport_Click);
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceSheet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBalanceSheet.Image = global::BumedianBM.Properties.Resources.balance_sheet_32;
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBalanceSheet.Location = new System.Drawing.Point(4, 400);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBalanceSheet.Size = new System.Drawing.Size(166, 41);
            this.btnBalanceSheet.TabIndex = 12;
            this.btnBalanceSheet.Tag = "BalanceSheet";
            this.btnBalanceSheet.Text = "كشف الحساب\r\n";
            this.btnBalanceSheet.UseVisualStyleBackColor = false;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnItemCard
            // 
            this.btnItemCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemCard.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemCard.Image = ((System.Drawing.Image)(resources.GetObject("btnItemCard.Image")));
            this.btnItemCard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnItemCard.Location = new System.Drawing.Point(4, 444);
            this.btnItemCard.Name = "btnItemCard";
            this.btnItemCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnItemCard.Size = new System.Drawing.Size(166, 41);
            this.btnItemCard.TabIndex = 9;
            this.btnItemCard.Tag = "ItemCard";
            this.btnItemCard.Text = "بطاقة الصنف\r\n";
            this.btnItemCard.UseVisualStyleBackColor = false;
            this.btnItemCard.Click += new System.EventHandler(this.btnItemCard_Click);
            // 
            // btnEndOfTheDay
            // 
            this.btnEndOfTheDay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEndOfTheDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndOfTheDay.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnEndOfTheDay.Image = global::BumedianBM.Properties.Resources.end_of_day_32;
            this.btnEndOfTheDay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndOfTheDay.Location = new System.Drawing.Point(4, 312);
            this.btnEndOfTheDay.Name = "btnEndOfTheDay";
            this.btnEndOfTheDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEndOfTheDay.Size = new System.Drawing.Size(166, 41);
            this.btnEndOfTheDay.TabIndex = 7;
            this.btnEndOfTheDay.Tag = "EndofDay";
            this.btnEndOfTheDay.Text = "حساب اخر اليوم \r\n";
            this.btnEndOfTheDay.UseVisualStyleBackColor = false;
            this.btnEndOfTheDay.Click += new System.EventHandler(this.btnEndOfTheDay_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReport.Image = global::BumedianBM.Properties.Resources.reports2_32;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Location = new System.Drawing.Point(4, 268);
            this.btnReport.Name = "btnReport";
            this.btnReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReport.Size = new System.Drawing.Size(166, 41);
            this.btnReport.TabIndex = 8;
            this.btnReport.Tag = "Report";
            this.btnReport.Text = "تقرير\r\n";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Location = new System.Drawing.Point(183, 652);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(826, 37);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.69933F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.797327F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.3912F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.435207F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.Controls.Add(this.txtCost, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_UserName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtProfit, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblProfit, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtDiscount, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSale, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblSale, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblDiscount, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblCost, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblUserName, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(898, 33);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCost.Location = new System.Drawing.Point(10, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCost.Size = new System.Drawing.Size(80, 31);
            this.lblCost.TabIndex = 230;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "سعر الشراء\r\n";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(96, 3);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCost.Size = new System.Drawing.Size(70, 27);
            this.txtCost.TabIndex = 236;
            this.txtCost.Text = "0.000";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbl_UserName.Location = new System.Drawing.Point(769, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_UserName.Size = new System.Drawing.Size(126, 33);
            this.lbl_UserName.TabIndex = 239;
            this.lbl_UserName.Text = "admin";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_UserName.UseWaitCursor = true;
            this.lbl_UserName.Click += new System.EventHandler(this.lbl_UserName_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(696, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(67, 31);
            this.lblUserName.TabIndex = 238;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfit
            // 
            this.txtProfit.BackColor = System.Drawing.Color.MintCream;
            this.txtProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtProfit.Location = new System.Drawing.Point(605, 3);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.ReadOnly = true;
            this.txtProfit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProfit.Size = new System.Drawing.Size(79, 27);
            this.txtProfit.TabIndex = 229;
            this.txtProfit.Text = "0.000";
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblProfit.Location = new System.Drawing.Point(557, 0);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProfit.Size = new System.Drawing.Size(42, 31);
            this.lblProfit.TabIndex = 234;
            this.lblProfit.Tag = "Profit";
            this.lblProfit.Text = "الربح\r\n";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Location = new System.Drawing.Point(265, 3);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiscount.Size = new System.Drawing.Size(79, 27);
            this.txtDiscount.TabIndex = 231;
            this.txtDiscount.Text = "0.000";
            // 
            // txtSale
            // 
            this.txtSale.BackColor = System.Drawing.SystemColors.Window;
            this.txtSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtSale.Location = new System.Drawing.Point(435, 3);
            this.txtSale.Name = "txtSale";
            this.txtSale.ReadOnly = true;
            this.txtSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSale.Size = new System.Drawing.Size(79, 27);
            this.txtSale.TabIndex = 235;
            this.txtSale.Text = "0.000";
            // 
            // lblSale
            // 
            this.lblSale.AutoSize = true;
            this.lblSale.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSale.Location = new System.Drawing.Point(362, 0);
            this.lblSale.Name = "lblSale";
            this.lblSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSale.Size = new System.Drawing.Size(67, 31);
            this.lblSale.TabIndex = 232;
            this.lblSale.Tag = "Sales";
            this.lblSale.Text = "المبيعات \r\n";
            this.lblSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(193, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiscount.Size = new System.Drawing.Size(66, 31);
            this.lblDiscount.TabIndex = 233;
            this.lblDiscount.Tag = "Discount";
            this.lblDiscount.Text = "التخفيض\r\n";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.09091F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.90909F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(183, 110);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.82F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.18F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(826, 536);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgvFindInvoice);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 239);
            this.panel4.TabIndex = 0;
            // 
            // dgvFindInvoice
            // 
            this.dgvFindInvoice.AllowUserToAddRows = false;
            this.dgvFindInvoice.AllowUserToOrderColumns = true;
            this.dgvFindInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFindInvoice.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFindInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle85.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle85.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle85.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle85;
            this.dgvFindInvoice.ColumnHeadersHeight = 37;
            this.dgvFindInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.newinvno,
            this.date,
            this.supplier,
            this.total,
            this.discount,
            this.net,
            this.user,
            this.time,
            this.returned,
            this.status,
            this.Paid,
            this.Status1,
            this.invoiceno});
            this.dgvFindInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFindInvoice.GridColor = System.Drawing.SystemColors.Control;
            this.dgvFindInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgvFindInvoice.Name = "dgvFindInvoice";
            this.dgvFindInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvFindInvoice.RowHeadersWidth = 13;
            this.dgvFindInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle87.NullValue = null;
            this.dgvFindInvoice.RowsDefaultCellStyle = dataGridViewCellStyle87;
            this.dgvFindInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindInvoice.Size = new System.Drawing.Size(663, 239);
            this.dgvFindInvoice.TabIndex = 217;
            this.dgvFindInvoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFindInvoice_CellDoubleClick);
            this.dgvFindInvoice.SelectionChanged += new System.EventHandler(this.dgvFindInvoice_SelectionChanged);
            // 
            // newinvno
            // 
            this.newinvno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.newinvno.DataPropertyName = "NewYearInvoiceID";
            this.newinvno.HeaderText = "رقم الفاتورة";
            this.newinvno.Name = "newinvno";
            this.newinvno.Width = 103;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date.DataPropertyName = "PurchaseItemDate";
            this.date.HeaderText = "التاريخ\r\n";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 77;
            // 
            // supplier
            // 
            this.supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.supplier.DataPropertyName = "SupplierName";
            this.supplier.HeaderText = "مورد\r\n";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            this.supplier.Width = 66;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.total.DataPropertyName = "ItemTotal";
            this.total.HeaderText = "الاجمالي\r\n";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 86;
            // 
            // discount
            // 
            this.discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.discount.DataPropertyName = "Discount";
            this.discount.HeaderText = "التخفيض\r\n";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Width = 91;
            // 
            // net
            // 
            this.net.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.net.DataPropertyName = "ItemNet";
            this.net.HeaderText = "الصافي\r\n";
            this.net.Name = "net";
            this.net.ReadOnly = true;
            this.net.Width = 80;
            // 
            // user
            // 
            this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.user.DataPropertyName = "User";
            this.user.HeaderText = "المستخدم\r\n";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 91;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.time.DataPropertyName = "Time";
            this.time.HeaderText = "الوقت \r\n";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 77;
            // 
            // returned
            // 
            this.returned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.returned.DataPropertyName = "ReturnQty";
            this.returned.HeaderText = "المرجع \r\n";
            this.returned.Name = "returned";
            this.returned.ReadOnly = true;
            this.returned.Visible = false;
            this.returned.Width = 82;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "الحالة\r\n";
            this.status.Name = "status";
            // 
            // Paid
            // 
            this.Paid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "المدفوع \r\n";
            this.Paid.Name = "Paid";
            this.Paid.Visible = false;
            this.Paid.Width = 85;
            // 
            // Status1
            // 
            this.Status1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status1.DataPropertyName = "SetStatus";
            this.Status1.HeaderText = "Status1";
            this.Status1.Name = "Status1";
            this.Status1.Visible = false;
            // 
            // invoiceno
            // 
            this.invoiceno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.invoiceno.DataPropertyName = "InvoiceNo";
            dataGridViewCellStyle86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.invoiceno.DefaultCellStyle = dataGridViewCellStyle86;
            this.invoiceno.HeaderText = "رقم الفاتورة\r\n";
            this.invoiceno.Name = "invoiceno";
            this.invoiceno.ReadOnly = true;
            this.invoiceno.Visible = false;
            this.invoiceno.Width = 103;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblInvoiceNo);
            this.panel5.Controls.Add(this.txtInvoiceNo);
            this.panel5.Controls.Add(this.cmbInvoiceType);
            this.panel5.Controls.Add(this.lblInvoiceType);
            this.panel5.Controls.Add(this.txtBalance);
            this.panel5.Controls.Add(this.lblBalance);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(672, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 239);
            this.panel5.TabIndex = 1;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNo.Location = new System.Drawing.Point(4, 88);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInvoiceNo.Size = new System.Drawing.Size(132, 31);
            this.lblInvoiceNo.TabIndex = 224;
            this.lblInvoiceNo.Tag = "InvoiceNo";
            this.lblInvoiceNo.Text = "رقم الفاتورة\r\n";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtInvoiceNo.Location = new System.Drawing.Point(4, 119);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInvoiceNo.Size = new System.Drawing.Size(144, 27);
            this.txtInvoiceNo.TabIndex = 223;
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNo_KeyPress);
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(0, 182);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbInvoiceType.Size = new System.Drawing.Size(148, 28);
            this.cmbInvoiceType.TabIndex = 222;
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceType.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceType.Location = new System.Drawing.Point(6, 151);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInvoiceType.Size = new System.Drawing.Size(130, 31);
            this.lblInvoiceType.TabIndex = 221;
            this.lblInvoiceType.Tag = "IType";
            this.lblInvoiceType.Text = "نوع الفاتورة";
            this.lblInvoiceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.BackColor = System.Drawing.SystemColors.Info;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBalance.Location = new System.Drawing.Point(4, 59);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance.Size = new System.Drawing.Size(144, 27);
            this.txtBalance.TabIndex = 220;
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalance.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(4, 28);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(104, 31);
            this.lblBalance.TabIndex = 219;
            this.lblBalance.Tag = "Balance";
            this.lblBalance.Text = "الرصيد\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.grbNotes);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(672, 291);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(151, 242);
            this.panel7.TabIndex = 3;
            // 
            // grbNotes
            // 
            this.grbNotes.Controls.Add(this.RtxtNotesAndAlerts);
            this.grbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNotes.Font = new System.Drawing.Font("Simplified Arabic", 9F, System.Drawing.FontStyle.Bold);
            this.grbNotes.Location = new System.Drawing.Point(0, 0);
            this.grbNotes.Name = "grbNotes";
            this.grbNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbNotes.Size = new System.Drawing.Size(151, 242);
            this.grbNotes.TabIndex = 216;
            this.grbNotes.TabStop = false;
            this.grbNotes.Tag = "NotesAlerts";
            this.grbNotes.Text = "مواعيد وملاحظات\r\n";
            // 
            // RtxtNotesAndAlerts
            // 
            this.RtxtNotesAndAlerts.BackColor = System.Drawing.SystemColors.Info;
            this.RtxtNotesAndAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtxtNotesAndAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.RtxtNotesAndAlerts.Location = new System.Drawing.Point(3, 23);
            this.RtxtNotesAndAlerts.Name = "RtxtNotesAndAlerts";
            this.RtxtNotesAndAlerts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RtxtNotesAndAlerts.Size = new System.Drawing.Size(145, 216);
            this.RtxtNotesAndAlerts.TabIndex = 1;
            this.RtxtNotesAndAlerts.Text = "";
            this.RtxtNotesAndAlerts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RtxtNotesAndAlerts_MouseDoubleClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvFindItem);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 291);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(663, 242);
            this.panel6.TabIndex = 2;
            // 
            // dgvFindItem
            // 
            this.dgvFindItem.AllowUserToAddRows = false;
            this.dgvFindItem.AllowUserToOrderColumns = true;
            this.dgvFindItem.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFindItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle88.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle88.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle88.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle88.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle88.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFindItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle88;
            this.dgvFindItem.ColumnHeadersHeight = 37;
            this.dgvFindItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemno,
            this.ItemNumber,
            this.item,
            this.exp_date,
            this.package,
            this.quantity,
            this.UnitPrice,
            this.itemtotal,
            this.itemtime,
            this.created,
            this.returnqty,
            this.Sale,
            this.Cost});
            this.dgvFindItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFindItem.GridColor = System.Drawing.SystemColors.Control;
            this.dgvFindItem.Location = new System.Drawing.Point(0, 0);
            this.dgvFindItem.Name = "dgvFindItem";
            this.dgvFindItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvFindItem.RowHeadersWidth = 13;
            this.dgvFindItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFindItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindItem.Size = new System.Drawing.Size(663, 242);
            this.dgvFindItem.TabIndex = 196;
            // 
            // itemno
            // 
            this.itemno.DataPropertyName = "ItemNo";
            dataGridViewCellStyle89.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemno.DefaultCellStyle = dataGridViewCellStyle89;
            this.itemno.HeaderText = "رقم الصنف\r\n";
            this.itemno.Name = "itemno";
            this.itemno.Visible = false;
            this.itemno.Width = 85;
            // 
            // ItemNumber
            // 
            this.ItemNumber.DataPropertyName = "ItemNumber";
            this.ItemNumber.HeaderText = "ItemNumber";
            this.ItemNumber.Name = "ItemNumber";
            this.ItemNumber.Visible = false;
            // 
            // item
            // 
            this.item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.item.DataPropertyName = "ItemName";
            dataGridViewCellStyle90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.DefaultCellStyle = dataGridViewCellStyle90;
            this.item.HeaderText = "البيان\r\n";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 71;
            // 
            // exp_date
            // 
            this.exp_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.exp_date.DataPropertyName = "ItemExpiry";
            this.exp_date.HeaderText = "الصلاحية\r\n";
            this.exp_date.Name = "exp_date";
            this.exp_date.ReadOnly = true;
            this.exp_date.Width = 92;
            // 
            // package
            // 
            this.package.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.package.DataPropertyName = "ItemPackage";
            this.package.HeaderText = "العبوة\r\n";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 69;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.quantity.DataPropertyName = "ItemQuantity";
            this.quantity.HeaderText = "الكمية \r\n";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 78;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UnitPrice.DataPropertyName = "ItemUnitPrice";
            this.UnitPrice.HeaderText = "سعر الوحدة\r\n";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 105;
            // 
            // itemtotal
            // 
            this.itemtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.itemtotal.DataPropertyName = "ItemTotal";
            this.itemtotal.HeaderText = "الاجمالي\r\n";
            this.itemtotal.Name = "itemtotal";
            this.itemtotal.ReadOnly = true;
            this.itemtotal.Width = 86;
            // 
            // itemtime
            // 
            this.itemtime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.itemtime.DataPropertyName = "Time";
            this.itemtime.HeaderText = "الوقت \r\n";
            this.itemtime.Name = "itemtime";
            this.itemtime.ReadOnly = true;
            this.itemtime.Width = 77;
            // 
            // created
            // 
            this.created.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.created.DataPropertyName = "User";
            this.created.HeaderText = "المستخدم\r\n";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.Width = 91;
            // 
            // returnqty
            // 
            this.returnqty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.returnqty.DataPropertyName = "ReturnQty";
            this.returnqty.HeaderText = "المرجع \r\n";
            this.returnqty.Name = "returnqty";
            this.returnqty.ReadOnly = true;
            this.returnqty.Width = 82;
            // 
            // Sale
            // 
            this.Sale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sale.DataPropertyName = "SalePrice";
            this.Sale.HeaderText = "المبيعات \r\n";
            this.Sale.Name = "Sale";
            this.Sale.Width = 92;
            // 
            // Cost
            // 
            this.Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cost.DataPropertyName = "ItemCost";
            this.Cost.HeaderText = "سعر الشراء\r\n";
            this.Cost.Name = "Cost";
            this.Cost.Width = 105;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 248);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(663, 37);
            this.panel8.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 8;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.Controls.Add(this.txtPaid, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_Net, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_Paid, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_TotalDiscount, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtNet, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTotalDiscount, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtTotal, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.Lbl_Total, 7, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(657, 32);
            this.tableLayoutPanel4.TabIndex = 218;
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.Honeydew;
            this.txtPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPaid.Location = new System.Drawing.Point(588, 3);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPaid.Size = new System.Drawing.Size(66, 27);
            this.txtPaid.TabIndex = 214;
            this.txtPaid.Text = "0.000";
            // 
            // Lbl_Net
            // 
            this.Lbl_Net.AutoSize = true;
            this.Lbl_Net.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Net.Location = new System.Drawing.Point(383, 0);
            this.Lbl_Net.Name = "Lbl_Net";
            this.Lbl_Net.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Net.Size = new System.Drawing.Size(55, 31);
            this.Lbl_Net.TabIndex = 211;
            this.Lbl_Net.Text = "الصافي\r\n";
            this.Lbl_Net.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_Paid
            // 
            this.Lbl_Paid.AutoSize = true;
            this.Lbl_Paid.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Paid.Location = new System.Drawing.Point(522, 0);
            this.Lbl_Paid.Name = "Lbl_Paid";
            this.Lbl_Paid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Paid.Size = new System.Drawing.Size(60, 31);
            this.Lbl_Paid.TabIndex = 212;
            this.Lbl_Paid.Text = "المدفوع \r\n";
            this.Lbl_Paid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_TotalDiscount
            // 
            this.Lbl_TotalDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_TotalDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalDiscount.Location = new System.Drawing.Point(150, 0);
            this.Lbl_TotalDiscount.Name = "Lbl_TotalDiscount";
            this.Lbl_TotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_TotalDiscount.Size = new System.Drawing.Size(144, 32);
            this.Lbl_TotalDiscount.TabIndex = 210;
            this.Lbl_TotalDiscount.Text = "اجمالي التخفيض\r\n";
            this.Lbl_TotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNet
            // 
            this.txtNet.BackColor = System.Drawing.SystemColors.Window;
            this.txtNet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNet.ForeColor = System.Drawing.Color.Red;
            this.txtNet.Location = new System.Drawing.Point(444, 3);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNet.Size = new System.Drawing.Size(66, 27);
            this.txtNet.TabIndex = 207;
            this.txtNet.Text = "0.000";
            // 
            // txtTotalDiscount
            // 
            this.txtTotalDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalDiscount.Location = new System.Drawing.Point(300, 3);
            this.txtTotalDiscount.Name = "txtTotalDiscount";
            this.txtTotalDiscount.ReadOnly = true;
            this.txtTotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalDiscount.Size = new System.Drawing.Size(66, 27);
            this.txtTotalDiscount.TabIndex = 209;
            this.txtTotalDiscount.Text = "0.000";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Honeydew;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(78, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(66, 27);
            this.txtTotal.TabIndex = 213;
            this.txtTotal.Text = "0.000";
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Total.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Total.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Total.Size = new System.Drawing.Size(69, 32);
            this.Lbl_Total.TabIndex = 208;
            this.Lbl_Total.Text = "الاجمالي\r\n";
            this.Lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.Lbl_Remaining);
            this.panel9.Controls.Add(this.txtRemaining);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(672, 248);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(151, 37);
            this.panel9.TabIndex = 5;
            // 
            // Lbl_Remaining
            // 
            this.Lbl_Remaining.AutoSize = true;
            this.Lbl_Remaining.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Remaining.Location = new System.Drawing.Point(0, 8);
            this.Lbl_Remaining.Name = "Lbl_Remaining";
            this.Lbl_Remaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Remaining.Size = new System.Drawing.Size(55, 31);
            this.Lbl_Remaining.TabIndex = 224;
            this.Lbl_Remaining.Text = "المتبقي\r\n";
            this.Lbl_Remaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemaining
            // 
            this.txtRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemaining.BackColor = System.Drawing.Color.SeaShell;
            this.txtRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtRemaining.Location = new System.Drawing.Point(82, 5);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.ReadOnly = true;
            this.txtRemaining.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemaining.Size = new System.Drawing.Size(63, 27);
            this.txtRemaining.SkipLiterals = false;
            this.txtRemaining.TabIndex = 223;
            this.txtRemaining.Text = "0.000";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblFindInvoice);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(174, 101);
            this.panel10.TabIndex = 4;
            // 
            // lblFindInvoice
            // 
            this.lblFindInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFindInvoice.Location = new System.Drawing.Point(8, 4);
            this.lblFindInvoice.Name = "lblFindInvoice";
            this.lblFindInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFindInvoice.Size = new System.Drawing.Size(152, 31);
            this.lblFindInvoice.TabIndex = 289;
            this.lblFindInvoice.Text = "بحث عن فاتورة\r\n";
            // 
            // Find_Purchase_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1012, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find_Purchase_Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Purchase Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Find_Purchase_Invoice_FormClosed);
            this.Load += new System.EventHandler(this.Find_Purchase_Invoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Find_Purchase_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindInvoice)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.grbNotes.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindItem)).EndInit();
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.ComboBox cmbSupplierNo;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.Label lblFromTime;
        private System.Windows.Forms.Label lblToTime;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblSupplierNo;
       // private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPurchaseInvoice;
        private System.Windows.Forms.Button btnItemInformation;
        private System.Windows.Forms.Button btnItemCard;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnEndOfTheDay;
        private System.Windows.Forms.Button btnBalanceSheet;
        private System.Windows.Forms.Button btnDetailedReport;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnGoToInvoice;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.MaskedTextBox txtProfit;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.MaskedTextBox txtCost;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.MaskedTextBox txtDiscount;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.MaskedTextBox txtSale;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MaskedTextBox txtBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.MaskedTextBox txtInvoiceNo;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox grbNotes;
        private System.Windows.Forms.RichTextBox RtxtNotesAndAlerts;
        private System.Windows.Forms.DataGridView dgvFindItem;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.MaskedTextBox txtPaid;
        private System.Windows.Forms.MaskedTextBox txtTotal;
        private System.Windows.Forms.Label Lbl_Paid;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Label Lbl_Net;
        private System.Windows.Forms.Label Lbl_TotalDiscount;
        private System.Windows.Forms.MaskedTextBox txtTotalDiscount;
        private System.Windows.Forms.MaskedTextBox txtNet;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label Lbl_Remaining;
        private System.Windows.Forms.MaskedTextBox txtRemaining;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblFindInvoice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn exp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;

        private SergeUtils.EasyCompletionComboBox cmbSupplierName;
        private System.Windows.Forms.DataGridView dgvFindInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn newinvno;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn net;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceno;
    }
}