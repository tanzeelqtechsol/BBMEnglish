namespace BumedianBM.ArabicView
{
    partial class Sales_Invoice
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
            objSaleInvoiceHelper = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Invoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PriceTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.tmrBlinkNotes = new System.Windows.Forms.Timer(this.components);
            this.TableLayout2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPriceChangeF7 = new System.Windows.Forms.Button();
            this.btnF9 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtClientTotal = new System.Windows.Forms.MaskedTextBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblClientNo = new System.Windows.Forms.Label();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.cmbClientNo = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbPackageQty = new System.Windows.Forms.ComboBox();
            this.cmbSerialNo = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.MaskedTextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtRemaining = new System.Windows.Forms.MaskedTextBox();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtTotalStock = new System.Windows.Forms.MaskedTextBox();
            this.dtpExpiry = new System.Windows.Forms.ComboBox();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.MaskedTextBox();
            this.cmbItem = new SergeUtils.EasyCompletionComboBox();
            this.cmbClient = new SergeUtils.EasyCompletionComboBox();
            this.lblItemName1 = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtActiveUser = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtNewInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.TableLayout3 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grbNoteAndAlert = new System.Windows.Forms.GroupBox();
            this.rtxtNotesAndAlerts = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkShowHideInvoiceCost = new System.Windows.Forms.CheckBox();
            this.txtTotalSaleValue = new System.Windows.Forms.MaskedTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.closeInvLoader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgrSaleInvoice = new System.Windows.Forms.DataGridView();
            this.StrItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StrExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unitprices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpric = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Users = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saledetailid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Newexpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualPrices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcostprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPaymentCharges = new System.Windows.Forms.MaskedTextBox();
            this.lblPaymentCharges = new System.Windows.Forms.Label();
            this.chkPaymentsTypes = new System.Windows.Forms.CheckBox();
            this.radPercentage = new System.Windows.Forms.RadioButton();
            this.radValue = new System.Windows.Forms.RadioButton();
            this.txtNet = new System.Windows.Forms.MaskedTextBox();
            this.lblNet = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.MaskedTextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.MaskedTextBox();
            this.txtNote = new System.Windows.Forms.MaskedTextBox();
            this.chkNote = new System.Windows.Forms.CheckBox();
            this.btnReceiveReceipt = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnExportInvoice = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnReturnIQuicktem = new System.Windows.Forms.Button();
            this.btnNewInvoice = new System.Windows.Forms.Button();
            this.Chk_PrintCashClientName = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCloseInvoice = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnInsertItem = new System.Windows.Forms.Button();
            this.chkHideLogo = new System.Windows.Forms.CheckBox();
            this.chkIncludeTax = new System.Windows.Forms.CheckBox();
            this.chkPrintPreview = new System.Windows.Forms.CheckBox();
            this.chkHideDebt = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.btnItemInfo = new System.Windows.Forms.Button();
            this.btnItemCard = new System.Windows.Forms.Button();
            this.btnModifyInvoice = new System.Windows.Forms.Button();
            this.btnFindInvoice = new System.Windows.Forms.Button();
            this.btnBalanceSheet = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.TableLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TableLayout3.SuspendLayout();
            this.TableLayout4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grbNoteAndAlert.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.closeInvLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrSaleInvoice)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TableLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PriceTooltip
            // 
            this.PriceTooltip.AutoPopDelay = 5000;
            this.PriceTooltip.InitialDelay = 100;
            this.PriceTooltip.IsBalloon = true;
            this.PriceTooltip.ReshowDelay = 100;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // TableLayout2
            // 
            this.TableLayout2.ColumnCount = 1;
            this.TableLayout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout2.Controls.Add(this.panel2, 0, 0);
            this.TableLayout2.Controls.Add(this.TableLayout3, 0, 1);
            this.TableLayout2.Controls.Add(this.panel6, 0, 2);
            this.TableLayout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout2.Location = new System.Drawing.Point(182, 3);
            this.TableLayout2.Name = "TableLayout2";
            this.TableLayout2.RowCount = 3;
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.47F));
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.53F));
            this.TableLayout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.TableLayout2.Size = new System.Drawing.Size(817, 727);
            this.TableLayout2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btnPriceChangeF7);
            this.panel2.Controls.Add(this.btnF9);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.txtClientTotal);
            this.panel2.Controls.Add(this.lblItemNo);
            this.panel2.Controls.Add(this.lblClientNo);
            this.panel2.Controls.Add(this.cmbItemNo);
            this.panel2.Controls.Add(this.cmbClientNo);
            this.panel2.Controls.Add(this.lblCategory);
            this.panel2.Controls.Add(this.cmbCategory);
            this.panel2.Controls.Add(this.lblCompany);
            this.panel2.Controls.Add(this.cmbCompany);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.txtPackage);
            this.panel2.Controls.Add(this.cmbItem);
            this.panel2.Controls.Add(this.cmbClient);
            this.panel2.Controls.Add(this.lblItemName1);
            this.panel2.Controls.Add(this.lblClient);
            this.panel2.Controls.Add(this.txtActiveUser);
            this.panel2.Controls.Add(this.lblInvoiceNo);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.txtNewInvoiceNo);
            this.panel2.Controls.Add(this.txtInvoiceNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(811, 214);
            this.panel2.TabIndex = 0;
            // 
            // btnPriceChangeF7
            // 
            this.btnPriceChangeF7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPriceChangeF7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPriceChangeF7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceChangeF7.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.btnPriceChangeF7.Location = new System.Drawing.Point(731, 126);
            this.btnPriceChangeF7.Name = "btnPriceChangeF7";
            this.btnPriceChangeF7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPriceChangeF7.Size = new System.Drawing.Size(76, 37);
            this.btnPriceChangeF7.TabIndex = 346;
            this.btnPriceChangeF7.Tag = "PriceF7";
            this.btnPriceChangeF7.Text = "السعر F7";
            this.btnPriceChangeF7.UseVisualStyleBackColor = false;
            // 
            // btnF9
            // 
            this.btnF9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnF9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF9.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.btnF9.Location = new System.Drawing.Point(730, 163);
            this.btnF9.Name = "btnF9";
            this.btnF9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnF9.Size = new System.Drawing.Size(77, 37);
            this.btnF9.TabIndex = 345;
            this.btnF9.Tag = "BoxF9";
            this.btnF9.Text = "علبة F9";
            this.btnF9.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnReset.Location = new System.Drawing.Point(514, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReset.Size = new System.Drawing.Size(140, 41);
            this.btnReset.TabIndex = 344;
            this.btnReset.Tag = "ResetF10";
            this.btnReset.Text = "F10 اعادة ضبط";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // txtClientTotal
            // 
            this.txtClientTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientTotal.BackColor = System.Drawing.Color.Black;
            this.txtClientTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtClientTotal.ForeColor = System.Drawing.Color.GreenYellow;
            this.txtClientTotal.Location = new System.Drawing.Point(673, 13);
            this.txtClientTotal.Name = "txtClientTotal";
            this.txtClientTotal.ReadOnly = true;
            this.txtClientTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClientTotal.Size = new System.Drawing.Size(132, 27);
            this.txtClientTotal.TabIndex = 343;
            this.txtClientTotal.Text = "0";
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(368, 98);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(104, 31);
            this.lblItemNo.TabIndex = 342;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClientNo
            // 
            this.lblClientNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblClientNo.Location = new System.Drawing.Point(368, 63);
            this.lblClientNo.Name = "lblClientNo";
            this.lblClientNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblClientNo.Size = new System.Drawing.Size(104, 31);
            this.lblClientNo.TabIndex = 341;
            this.lblClientNo.Tag = "ClientNo";
            this.lblClientNo.Text = "رقم الزبون";
            this.lblClientNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 516;
            this.cmbItemNo.DropDownWidth = 200;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(472, 101);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(102, 28);
            this.cmbItemNo.TabIndex = 340;
            // 
            // cmbClientNo
            // 
            this.cmbClientNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClientNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClientNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClientNo.DropDownHeight = 600;
            this.cmbClientNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbClientNo.FormattingEnabled = true;
            this.cmbClientNo.IntegralHeight = false;
            this.cmbClientNo.Location = new System.Drawing.Point(472, 63);
            this.cmbClientNo.Name = "cmbClientNo";
            this.cmbClientNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbClientNo.Size = new System.Drawing.Size(102, 28);
            this.cmbClientNo.TabIndex = 337;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(572, 58);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(86, 34);
            this.lblCategory.TabIndex = 332;
            this.lblCategory.Tag = "Cat";
            this.lblCategory.Text = "Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.DropDownHeight = 540;
            this.cmbCategory.DropDownWidth = 320;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Items.AddRange(new object[] {
            "ÇáãÌãæÚÉ"});
            this.cmbCategory.Location = new System.Drawing.Point(661, 61);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(143, 28);
            this.cmbCategory.TabIndex = 330;
            this.cmbCategory.ValueMember = "CategoryID";
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCompany.Location = new System.Drawing.Point(571, 92);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(89, 36);
            this.lblCompany.TabIndex = 331;
            this.lblCompany.Tag = "Com";
            this.lblCompany.Text = "Company";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCompany
            // 
            this.cmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DisplayMember = "CompanyID";
            this.cmbCompany.DropDownHeight = 540;
            this.cmbCompany.DropDownWidth = 320;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Items.AddRange(new object[] {
            "ÇáãÌãæÚÉ"});
            this.cmbCompany.Location = new System.Drawing.Point(660, 98);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(144, 28);
            this.cmbCompany.TabIndex = 329;
            this.cmbCompany.ValueMember = "CompanyName";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.txtPrice, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbPackageQty, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbSerialNo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPrice, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPackage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblQty, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRemaining, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalStock, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRemaining, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblExpiry, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalStock, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpExpiry, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSerialNo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 132);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 68);
            this.tableLayoutPanel1.TabIndex = 317;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Location = new System.Drawing.Point(3, 35);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.Size = new System.Drawing.Size(101, 27);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Text = "0.000";
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyUp);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // cmbPackageQty
            // 
            this.cmbPackageQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPackageQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbPackageQty.FormattingEnabled = true;
            this.cmbPackageQty.Location = new System.Drawing.Point(522, 35);
            this.cmbPackageQty.Name = "cmbPackageQty";
            this.cmbPackageQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPackageQty.Size = new System.Drawing.Size(97, 28);
            this.cmbPackageQty.TabIndex = 4;
            this.cmbPackageQty.SelectedIndexChanged += new System.EventHandler(this.cmbPackageQty_SelectedIndexChanged);
            // 
            // cmbSerialNo
            // 
            this.cmbSerialNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSerialNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSerialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSerialNo.DropDownWidth = 100;
            this.cmbSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSerialNo.FormattingEnabled = true;
            this.cmbSerialNo.Location = new System.Drawing.Point(625, 35);
            this.cmbSerialNo.Name = "cmbSerialNo";
            this.cmbSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbSerialNo.Size = new System.Drawing.Size(97, 28);
            this.cmbSerialNo.TabIndex = 5;
            this.cmbSerialNo.SelectedIndexChanged += new System.EventHandler(this.cmbSerialNo_SelectedIndexChanged);
            this.cmbSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSerialNo_KeyDown);
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPrice.Location = new System.Drawing.Point(3, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPrice.Size = new System.Drawing.Size(93, 31);
            this.lblPrice.TabIndex = 323;
            this.lblPrice.Tag = "Price";
            this.lblPrice.Text = "السعر";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPackage
            // 
            this.lblPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPackage.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPackage.Location = new System.Drawing.Point(522, 0);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPackage.Size = new System.Drawing.Size(87, 31);
            this.lblPackage.TabIndex = 330;
            this.lblPackage.Tag = "Package";
            this.lblPackage.Text = "العبوة";
            this.lblPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.Location = new System.Drawing.Point(110, 35);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantity.Size = new System.Drawing.Size(97, 27);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "1";
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyUp);
            // 
            // lblQty
            // 
            this.lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblQty.Location = new System.Drawing.Point(110, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQty.Size = new System.Drawing.Size(97, 31);
            this.lblQty.TabIndex = 324;
            this.lblQty.Tag = "Qty";
            this.lblQty.Text = "الكمية ";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQty.Click += new System.EventHandler(this.lblQty_Click);
            // 
            // txtRemaining
            // 
            this.txtRemaining.BackColor = System.Drawing.Color.White;
            this.txtRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtRemaining.Location = new System.Drawing.Point(213, 35);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.ReadOnly = true;
            this.txtRemaining.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemaining.Size = new System.Drawing.Size(97, 27);
            this.txtRemaining.TabIndex = 321;
            this.txtRemaining.Text = "0";
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStock.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.Location = new System.Drawing.Point(316, 0);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalStock.Size = new System.Drawing.Size(97, 32);
            this.lblTotalStock.TabIndex = 329;
            this.lblTotalStock.Tag = "TotalStock";
            this.lblTotalStock.Text = "المخزون";
            this.lblTotalStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalStock.Click += new System.EventHandler(this.lblTotalStock_Click);
            // 
            // lblRemaining
            // 
            this.lblRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemaining.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblRemaining.Location = new System.Drawing.Point(213, 0);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRemaining.Size = new System.Drawing.Size(97, 31);
            this.lblRemaining.TabIndex = 320;
            this.lblRemaining.Tag = "Remaining";
            this.lblRemaining.Text = "المتبقي";
            this.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpiry.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpiry.Location = new System.Drawing.Point(419, 0);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExpiry.Size = new System.Drawing.Size(95, 31);
            this.lblExpiry.TabIndex = 325;
            this.lblExpiry.Tag = "Expiry";
            this.lblExpiry.Text = "الصلاحية";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalStock
            // 
            this.txtTotalStock.BackColor = System.Drawing.Color.OldLace;
            this.txtTotalStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalStock.Location = new System.Drawing.Point(316, 35);
            this.txtTotalStock.Name = "txtTotalStock";
            this.txtTotalStock.ReadOnly = true;
            this.txtTotalStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalStock.Size = new System.Drawing.Size(97, 27);
            this.txtTotalStock.TabIndex = 322;
            this.txtTotalStock.Text = "0";
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.BackColor = System.Drawing.Color.White;
            this.dtpExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpExpiry.DropDownWidth = 100;
            this.dtpExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.dtpExpiry.FormattingEnabled = true;
            this.dtpExpiry.Location = new System.Drawing.Point(419, 35);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpExpiry.Size = new System.Drawing.Size(97, 28);
            this.dtpExpiry.TabIndex = 3;
            this.dtpExpiry.SelectedIndexChanged += new System.EventHandler(this.dtpExpiry_SelectedIndexChanged);
            this.dtpExpiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpExpiry_KeyDown);
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerialNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSerialNo.Location = new System.Drawing.Point(625, 0);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSerialNo.Size = new System.Drawing.Size(97, 31);
            this.lblSerialNo.TabIndex = 332;
            this.lblSerialNo.Text = "المقاس";
            this.lblSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackage
            // 
            this.txtPackage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPackage.BackColor = System.Drawing.Color.White;
            this.txtPackage.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtPackage.Location = new System.Drawing.Point(183, 170);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.ReadOnly = true;
            this.txtPackage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPackage.Size = new System.Drawing.Size(90, 30);
            this.txtPackage.TabIndex = 326;
            this.txtPackage.Visible = false;
            // 
            // cmbItem
            // 
            this.cmbItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItem.DisplayMember = "ItemName";
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.IntegralHeight = false;
            this.cmbItem.ItemHeight = 20;
            this.cmbItem.Location = new System.Drawing.Point(90, 100);
            this.cmbItem.MaxDropDownItems = 25;
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItem.Size = new System.Drawing.Size(273, 28);
            this.cmbItem.TabIndex = 311;
            this.cmbItem.ValueMember = "ItemID";
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            this.cmbItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyUp);
            this.cmbItem.Leave += new System.EventHandler(this.cmbItem_Leave);
            this.cmbItem.MouseHover += new System.EventHandler(this.cmbItem_MouseHover);
            // 
            // cmbClient
            // 
            this.cmbClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClient.DisplayMember = "AgentName";
            this.cmbClient.DropDownHeight = 600;
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbClient.ForeColor = System.Drawing.Color.Black;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.IntegralHeight = false;
            this.cmbClient.Location = new System.Drawing.Point(90, 62);
            this.cmbClient.MaxDropDownItems = 25;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbClient.Size = new System.Drawing.Size(273, 28);
            this.cmbClient.TabIndex = 310;
            this.cmbClient.ValueMember = "AgentID";
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            this.cmbClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.client_keydown);
            this.cmbClient.Leave += new System.EventHandler(this.cmbClient_Leave);
            // 
            // lblItemName1
            // 
            this.lblItemName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemName1.AutoSize = true;
            this.lblItemName1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName1.Location = new System.Drawing.Point(2, 99);
            this.lblItemName1.Name = "lblItemName1";
            this.lblItemName1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName1.Size = new System.Drawing.Size(82, 31);
            this.lblItemName1.TabIndex = 313;
            this.lblItemName1.Tag = "ItemName";
            this.lblItemName1.Text = "اسم الصنف";
            this.lblItemName1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClient
            // 
            this.lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblClient.Location = new System.Drawing.Point(2, 62);
            this.lblClient.Name = "lblClient";
            this.lblClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblClient.Size = new System.Drawing.Size(83, 31);
            this.lblClient.TabIndex = 312;
            this.lblClient.Tag = "ClientName";
            this.lblClient.Text = "اسم الزبون ";
            this.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtActiveUser
            // 
            this.txtActiveUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtActiveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtActiveUser.Location = new System.Drawing.Point(6, 7);
            this.txtActiveUser.Name = "txtActiveUser";
            this.txtActiveUser.Size = new System.Drawing.Size(100, 27);
            this.txtActiveUser.TabIndex = 308;
            this.txtActiveUser.Visible = false;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceNo.Location = new System.Drawing.Point(293, -2);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInvoiceNo.Size = new System.Drawing.Size(78, 31);
            this.lblInvoiceNo.TabIndex = 303;
            this.lblInvoiceNo.Tag = "InvoiceNo";
            this.lblInvoiceNo.Text = "رقم الفاتورة";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.Black;
            this.btnPrevious.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnPrevious.Location = new System.Drawing.Point(233, 26);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrevious.Size = new System.Drawing.Size(36, 36);
            this.btnPrevious.TabIndex = 301;
            this.btnPrevious.Tag = "3";
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Image = global::BumedianBM.Properties.Resources.first_32;
            this.btnFirst.Location = new System.Drawing.Point(191, 26);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFirst.Size = new System.Drawing.Size(36, 36);
            this.btnFirst.TabIndex = 300;
            this.btnFirst.Tag = "1";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Image = global::BumedianBM.Properties.Resources.last_32;
            this.btnLast.Location = new System.Drawing.Point(437, 26);
            this.btnLast.Name = "btnLast";
            this.btnLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLast.Size = new System.Drawing.Size(36, 36);
            this.btnLast.TabIndex = 299;
            this.btnLast.Tag = "4";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNext.Location = new System.Drawing.Point(395, 26);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNext.Size = new System.Drawing.Size(36, 36);
            this.btnNext.TabIndex = 298;
            this.btnNext.Tag = "2";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNavigation_Click);
            // 
            // txtNewInvoiceNo
            // 
            this.txtNewInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNewInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewInvoiceNo.Location = new System.Drawing.Point(275, 29);
            this.txtNewInvoiceNo.Name = "txtNewInvoiceNo";
            this.txtNewInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewInvoiceNo.Size = new System.Drawing.Size(114, 27);
            this.txtNewInvoiceNo.TabIndex = 305;
            this.txtNewInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewInvoiceNo_KeyPress);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtInvoiceNo.Location = new System.Drawing.Point(275, 30);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInvoiceNo.Size = new System.Drawing.Size(114, 27);
            this.txtInvoiceNo.TabIndex = 295;
            this.txtInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TableLayout3
            // 
            this.TableLayout3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayout3.ColumnCount = 2;
            this.TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TableLayout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout3.Controls.Add(this.TableLayout4, 0, 0);
            this.TableLayout3.Controls.Add(this.panel5, 1, 0);
            this.TableLayout3.Location = new System.Drawing.Point(3, 223);
            this.TableLayout3.Name = "TableLayout3";
            this.TableLayout3.RowCount = 1;
            this.TableLayout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout3.Size = new System.Drawing.Size(811, 377);
            this.TableLayout3.TabIndex = 1;
            // 
            // TableLayout4
            // 
            this.TableLayout4.AutoSize = true;
            this.TableLayout4.ColumnCount = 1;
            this.TableLayout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayout4.Controls.Add(this.panel3, 0, 0);
            this.TableLayout4.Controls.Add(this.panel4, 0, 1);
            this.TableLayout4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout4.Location = new System.Drawing.Point(614, 3);
            this.TableLayout4.Name = "TableLayout4";
            this.TableLayout4.RowCount = 2;
            this.TableLayout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.13695F));
            this.TableLayout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.86305F));
            this.TableLayout4.Size = new System.Drawing.Size(194, 371);
            this.TableLayout4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.grbNoteAndAlert);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 295);
            this.panel3.TabIndex = 0;
            // 
            // grbNoteAndAlert
            // 
            this.grbNoteAndAlert.Controls.Add(this.rtxtNotesAndAlerts);
            this.grbNoteAndAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNoteAndAlert.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.grbNoteAndAlert.Location = new System.Drawing.Point(0, 0);
            this.grbNoteAndAlert.Name = "grbNoteAndAlert";
            this.grbNoteAndAlert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbNoteAndAlert.Size = new System.Drawing.Size(188, 295);
            this.grbNoteAndAlert.TabIndex = 153;
            this.grbNoteAndAlert.TabStop = false;
            this.grbNoteAndAlert.Tag = "NotesAlerts";
            this.grbNoteAndAlert.Text = "مواعيد وملاحظات";
            // 
            // rtxtNotesAndAlerts
            // 
            this.rtxtNotesAndAlerts.BackColor = System.Drawing.SystemColors.Info;
            this.rtxtNotesAndAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtNotesAndAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtNotesAndAlerts.Location = new System.Drawing.Point(3, 26);
            this.rtxtNotesAndAlerts.Name = "rtxtNotesAndAlerts";
            this.rtxtNotesAndAlerts.Size = new System.Drawing.Size(182, 266);
            this.rtxtNotesAndAlerts.TabIndex = 0;
            this.rtxtNotesAndAlerts.Text = "";
            this.rtxtNotesAndAlerts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rtxtNotesAndAlerts_MouseDoubleClick);
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.chkShowHideInvoiceCost);
            this.panel4.Controls.Add(this.txtTotalSaleValue);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 304);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 64);
            this.panel4.TabIndex = 1;
            // 
            // chkShowHideInvoiceCost
            // 
            this.chkShowHideInvoiceCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowHideInvoiceCost.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkShowHideInvoiceCost.Location = new System.Drawing.Point(3, 1);
            this.chkShowHideInvoiceCost.Name = "chkShowHideInvoiceCost";
            this.chkShowHideInvoiceCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowHideInvoiceCost.Size = new System.Drawing.Size(182, 26);
            this.chkShowHideInvoiceCost.TabIndex = 242;
            this.chkShowHideInvoiceCost.Tag = "ShowHideInvCost";
            this.chkShowHideInvoiceCost.Text = "عرض التكلفة";
            this.chkShowHideInvoiceCost.UseVisualStyleBackColor = true;
            this.chkShowHideInvoiceCost.CheckedChanged += new System.EventHandler(this.chkShowHideInvoiceCost_CheckedChanged);
            // 
            // txtTotalSaleValue
            // 
            this.txtTotalSaleValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSaleValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalSaleValue.Location = new System.Drawing.Point(5, 26);
            this.txtTotalSaleValue.Name = "txtTotalSaleValue";
            this.txtTotalSaleValue.ReadOnly = true;
            this.txtTotalSaleValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalSaleValue.Size = new System.Drawing.Size(149, 27);
            this.txtTotalSaleValue.TabIndex = 241;
            this.txtTotalSaleValue.Text = "0";
            this.txtTotalSaleValue.Visible = false;
            this.txtTotalSaleValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalSaleValue_KeyPress);
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.closeInvLoader);
            this.panel5.Controls.Add(this.dgrSaleInvoice);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(605, 371);
            this.panel5.TabIndex = 1;
            // 
            // closeInvLoader
            // 
            this.closeInvLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.closeInvLoader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.closeInvLoader.Controls.Add(this.pictureBox1);
            this.closeInvLoader.Location = new System.Drawing.Point(157, 62);
            this.closeInvLoader.Name = "closeInvLoader";
            this.closeInvLoader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.closeInvLoader.Size = new System.Drawing.Size(220, 173);
            this.closeInvLoader.TabIndex = 229;
            this.closeInvLoader.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Image = global::BumedianBM.Properties.Resources.Double_Ring_2_2s_200px;
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // dgrSaleInvoice
            // 
            this.dgrSaleInvoice.AllowUserToAddRows = false;
            this.dgrSaleInvoice.AllowUserToOrderColumns = true;
            this.dgrSaleInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrSaleInvoice.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgrSaleInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrSaleInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrSaleInvoice.ColumnHeadersHeight = 35;
            this.dgrSaleInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StrItemNo,
            this.ItemDesc,
            this.ItemNo,
            this.StrExpiryDate,
            this.ExpiryDate,
            this.Package,
            this.Qty,
            this.BoxQty,
            this.Unitprices,
            this.totalpric,
            this.DateModified,
            this.Users,
            this.ReturnQuantity,
            this.ClientsID,
            this.saledetailid,
            this.salesid,
            this.itemdisc,
            this.serialnumber,
            this.Newexpiry,
            this.ActualPrices,
            this.taxes,
            this.TotalCostPrice,
            this.SubTotalPrice,
            this.itemcostprice,
            this.BarcodeNumber});
            this.dgrSaleInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrSaleInvoice.GridColor = System.Drawing.SystemColors.Control;
            this.dgrSaleInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgrSaleInvoice.MultiSelect = false;
            this.dgrSaleInvoice.Name = "dgrSaleInvoice";
            this.dgrSaleInvoice.ReadOnly = true;
            this.dgrSaleInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrSaleInvoice.RowHeadersVisible = false;
            this.dgrSaleInvoice.RowHeadersWidth = 13;
            this.dgrSaleInvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrSaleInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrSaleInvoice.Size = new System.Drawing.Size(605, 371);
            this.dgrSaleInvoice.TabIndex = 228;
            this.dgrSaleInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrSaleInvoice_CellContentClick);
            this.dgrSaleInvoice.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgrSaleInvoice_RowsAdded);
            this.dgrSaleInvoice.DoubleClick += new System.EventHandler(this.dgrSaleInvoice_DoubleClick);
            // 
            // StrItemNo
            // 
            this.StrItemNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StrItemNo.DataPropertyName = "StrItemNo";
            this.StrItemNo.HeaderText = "ItemNumber";
            this.StrItemNo.Name = "StrItemNo";
            this.StrItemNo.ReadOnly = true;
            this.StrItemNo.Width = 133;
            // 
            // ItemDesc
            // 
            this.ItemDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemDesc.DataPropertyName = "ItemDescription";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemDesc.HeaderText = "البيان";
            this.ItemDesc.Name = "ItemDesc";
            this.ItemDesc.ReadOnly = true;
            this.ItemDesc.Width = 71;
            // 
            // ItemNo
            // 
            this.ItemNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ItemNo.DataPropertyName = "itemid";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemNo.HeaderText = "رقم الصنف ";
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.ReadOnly = true;
            this.ItemNo.Visible = false;
            this.ItemNo.Width = 109;
            // 
            // StrExpiryDate
            // 
            this.StrExpiryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StrExpiryDate.DataPropertyName = "StrExpiryDate";
            this.StrExpiryDate.HeaderText = "StrExpiry";
            this.StrExpiryDate.Name = "StrExpiryDate";
            this.StrExpiryDate.ReadOnly = true;
            this.StrExpiryDate.Width = 111;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ExpiryDate.DataPropertyName = "ItemExpiryDate";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = "-";
            this.ExpiryDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExpiryDate.HeaderText = "الصلاحية";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            this.ExpiryDate.Visible = false;
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
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Qty.DataPropertyName = "quantity";
            this.Qty.HeaderText = "الكمية ";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 78;
            // 
            // BoxQty
            // 
            this.BoxQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BoxQty.DataPropertyName = "Box";
            this.BoxQty.HeaderText = "Box";
            this.BoxQty.Name = "BoxQty";
            this.BoxQty.ReadOnly = true;
            this.BoxQty.Width = 70;
            // 
            // Unitprices
            // 
            this.Unitprices.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Unitprices.DataPropertyName = "unitprice";
            this.Unitprices.HeaderText = "سعر الوحدة\r\n";
            this.Unitprices.Name = "Unitprices";
            this.Unitprices.ReadOnly = true;
            this.Unitprices.Width = 105;
            // 
            // totalpric
            // 
            this.totalpric.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.totalpric.DataPropertyName = "TotalPrice";
            this.totalpric.HeaderText = "الاجمالي";
            this.totalpric.Name = "totalpric";
            this.totalpric.ReadOnly = true;
            this.totalpric.Width = 86;
            // 
            // DateModified
            // 
            this.DateModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DateModified.DataPropertyName = "StrModifiedDate";
            this.DateModified.HeaderText = "الوقت ";
            this.DateModified.Name = "DateModified";
            this.DateModified.ReadOnly = true;
            this.DateModified.Width = 77;
            // 
            // Users
            // 
            this.Users.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Users.DataPropertyName = "user ";
            this.Users.HeaderText = "المستخدم";
            this.Users.Name = "Users";
            this.Users.ReadOnly = true;
            this.Users.Visible = false;
            this.Users.Width = 91;
            // 
            // ReturnQuantity
            // 
            this.ReturnQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ReturnQuantity.DataPropertyName = "ReturnQty";
            this.ReturnQuantity.HeaderText = "المرجع ";
            this.ReturnQuantity.Name = "ReturnQuantity";
            this.ReturnQuantity.ReadOnly = true;
            this.ReturnQuantity.Width = 82;
            // 
            // ClientsID
            // 
            this.ClientsID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClientsID.DataPropertyName = "ClientID";
            this.ClientsID.HeaderText = "العملاء";
            this.ClientsID.Name = "ClientsID";
            this.ClientsID.ReadOnly = true;
            this.ClientsID.Visible = false;
            this.ClientsID.Width = 78;
            // 
            // saledetailid
            // 
            this.saledetailid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.saledetailid.DataPropertyName = "saledetid";
            this.saledetailid.HeaderText = "Sale_Det_Id";
            this.saledetailid.Name = "saledetailid";
            this.saledetailid.ReadOnly = true;
            this.saledetailid.Visible = false;
            this.saledetailid.Width = 132;
            // 
            // salesid
            // 
            this.salesid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.salesid.DataPropertyName = "saleid";
            this.salesid.HeaderText = "Sale id";
            this.salesid.Name = "salesid";
            this.salesid.ReadOnly = true;
            this.salesid.Visible = false;
            // 
            // itemdisc
            // 
            this.itemdisc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.itemdisc.DataPropertyName = "itemdiscount";
            this.itemdisc.HeaderText = "التخفيض";
            this.itemdisc.Name = "itemdisc";
            this.itemdisc.ReadOnly = true;
            this.itemdisc.Visible = false;
            this.itemdisc.Width = 91;
            // 
            // serialnumber
            // 
            this.serialnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.serialnumber.DataPropertyName = "serialno";
            this.serialnumber.HeaderText = "الرقم التسلسلي";
            this.serialnumber.Name = "serialnumber";
            this.serialnumber.ReadOnly = true;
            this.serialnumber.Width = 123;
            // 
            // Newexpiry
            // 
            this.Newexpiry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Newexpiry.DataPropertyName = "Newexpr";
            this.Newexpiry.HeaderText = "Newexpr";
            this.Newexpiry.Name = "Newexpiry";
            this.Newexpiry.ReadOnly = true;
            this.Newexpiry.Visible = false;
            this.Newexpiry.Width = 107;
            // 
            // ActualPrices
            // 
            this.ActualPrices.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ActualPrices.DataPropertyName = "ActualPrice";
            this.ActualPrices.HeaderText = "ActualPrice";
            this.ActualPrices.Name = "ActualPrices";
            this.ActualPrices.ReadOnly = true;
            this.ActualPrices.Visible = false;
            this.ActualPrices.Width = 129;
            // 
            // taxes
            // 
            this.taxes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.taxes.DataPropertyName = "tax";
            this.taxes.HeaderText = "Itemtax";
            this.taxes.Name = "taxes";
            this.taxes.ReadOnly = true;
            this.taxes.Visible = false;
            this.taxes.Width = 95;
            // 
            // TotalCostPrice
            // 
            this.TotalCostPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TotalCostPrice.DataPropertyName = "Totalcost";
            this.TotalCostPrice.HeaderText = "Totalcost";
            this.TotalCostPrice.Name = "TotalCostPrice";
            this.TotalCostPrice.ReadOnly = true;
            this.TotalCostPrice.Visible = false;
            this.TotalCostPrice.Width = 111;
            // 
            // SubTotalPrice
            // 
            this.SubTotalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SubTotalPrice.DataPropertyName = "Subtotal";
            this.SubTotalPrice.HeaderText = "Subtotal";
            this.SubTotalPrice.Name = "SubTotalPrice";
            this.SubTotalPrice.ReadOnly = true;
            this.SubTotalPrice.Visible = false;
            this.SubTotalPrice.Width = 104;
            // 
            // itemcostprice
            // 
            this.itemcostprice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.itemcostprice.DataPropertyName = "Itemcost";
            this.itemcostprice.HeaderText = "itemcost";
            this.itemcostprice.Name = "itemcostprice";
            this.itemcostprice.ReadOnly = true;
            this.itemcostprice.Visible = false;
            this.itemcostprice.Width = 105;
            // 
            // BarcodeNumber
            // 
            this.BarcodeNumber.DataPropertyName = "BarcodeID";
            this.BarcodeNumber.HeaderText = "Barcode";
            this.BarcodeNumber.Name = "BarcodeNumber";
            this.BarcodeNumber.ReadOnly = true;
            this.BarcodeNumber.Visible = false;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.lblUserName);
            this.panel6.Controls.Add(this.txtPaymentCharges);
            this.panel6.Controls.Add(this.lblPaymentCharges);
            this.panel6.Controls.Add(this.chkPaymentsTypes);
            this.panel6.Controls.Add(this.radPercentage);
            this.panel6.Controls.Add(this.radValue);
            this.panel6.Controls.Add(this.txtNet);
            this.panel6.Controls.Add(this.lblNet);
            this.panel6.Controls.Add(this.lblDiscount);
            this.panel6.Controls.Add(this.txtDiscount);
            this.panel6.Controls.Add(this.lblTotal);
            this.panel6.Controls.Add(this.txtTotal);
            this.panel6.Controls.Add(this.txtNote);
            this.panel6.Controls.Add(this.chkNote);
            this.panel6.Controls.Add(this.btnReceiveReceipt);
            this.panel6.Controls.Add(this.lblUser);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 606);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(811, 118);
            this.panel6.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(3, 89);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(54, 28);
            this.lblUserName.TabIndex = 272;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPaymentCharges
            // 
            this.txtPaymentCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPaymentCharges.Location = new System.Drawing.Point(703, 45);
            this.txtPaymentCharges.Name = "txtPaymentCharges";
            this.txtPaymentCharges.ReadOnly = true;
            this.txtPaymentCharges.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPaymentCharges.Size = new System.Drawing.Size(101, 27);
            this.txtPaymentCharges.TabIndex = 271;
            this.txtPaymentCharges.Text = "0";
            // 
            // lblPaymentCharges
            // 
            this.lblPaymentCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentCharges.AutoSize = true;
            this.lblPaymentCharges.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentCharges.Location = new System.Drawing.Point(569, 46);
            this.lblPaymentCharges.Name = "lblPaymentCharges";
            this.lblPaymentCharges.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPaymentCharges.Size = new System.Drawing.Size(130, 26);
            this.lblPaymentCharges.TabIndex = 270;
            this.lblPaymentCharges.Tag = "PaymentCharges";
            this.lblPaymentCharges.Text = "Payment Charges";
            this.lblPaymentCharges.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPaymentsTypes
            // 
            this.chkPaymentsTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaymentsTypes.AutoSize = true;
            this.chkPaymentsTypes.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPaymentsTypes.Location = new System.Drawing.Point(684, 78);
            this.chkPaymentsTypes.Name = "chkPaymentsTypes";
            this.chkPaymentsTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPaymentsTypes.Size = new System.Drawing.Size(83, 29);
            this.chkPaymentsTypes.TabIndex = 268;
            this.chkPaymentsTypes.Tag = "Payment Types";
            this.chkPaymentsTypes.Text = "طريقة الدفع";
            this.chkPaymentsTypes.UseVisualStyleBackColor = true;
            // 
            // radPercentage
            // 
            this.radPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radPercentage.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.radPercentage.Location = new System.Drawing.Point(577, 7);
            this.radPercentage.Name = "radPercentage";
            this.radPercentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radPercentage.Size = new System.Drawing.Size(79, 29);
            this.radPercentage.TabIndex = 267;
            this.radPercentage.Tag = "Persentage";
            this.radPercentage.Text = "نسبة";
            this.radPercentage.UseVisualStyleBackColor = true;
            // 
            // radValue
            // 
            this.radValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radValue.Checked = true;
            this.radValue.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.radValue.Location = new System.Drawing.Point(685, 6);
            this.radValue.Name = "radValue";
            this.radValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radValue.Size = new System.Drawing.Size(82, 29);
            this.radValue.TabIndex = 266;
            this.radValue.TabStop = true;
            this.radValue.Tag = "Value";
            this.radValue.Text = "قيمة";
            this.radValue.UseVisualStyleBackColor = true;
            // 
            // txtNet
            // 
            this.txtNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNet.Location = new System.Drawing.Point(451, 82);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNet.Size = new System.Drawing.Size(115, 27);
            this.txtNet.TabIndex = 260;
            this.txtNet.Text = "0";
            // 
            // lblNet
            // 
            this.lblNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNet.AutoSize = true;
            this.lblNet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNet.Location = new System.Drawing.Point(388, 81);
            this.lblNet.Name = "lblNet";
            this.lblNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNet.Size = new System.Drawing.Size(55, 31);
            this.lblNet.TabIndex = 259;
            this.lblNet.Tag = "Net";
            this.lblNet.Text = "الصافي";
            this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(385, 50);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDiscount.Size = new System.Drawing.Size(66, 31);
            this.lblDiscount.TabIndex = 258;
            this.lblDiscount.Tag = "Discount";
            this.lblDiscount.Text = "التخفيض";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Location = new System.Drawing.Point(451, 49);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiscount.Size = new System.Drawing.Size(115, 27);
            this.txtDiscount.TabIndex = 257;
            this.txtDiscount.Text = "0";
            this.txtDiscount.ValidatingType = typeof(int);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(387, 18);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(59, 31);
            this.lblTotal.TabIndex = 256;
            this.lblTotal.Tag = "Total";
            this.lblTotal.Text = "المجموع";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(451, 16);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.Size = new System.Drawing.Size(115, 27);
            this.txtTotal.TabIndex = 255;
            this.txtTotal.Text = "0";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.SystemColors.Info;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNote.Location = new System.Drawing.Point(81, 50);
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.Size = new System.Drawing.Size(299, 27);
            this.txtNote.TabIndex = 246;
            // 
            // chkNote
            // 
            this.chkNote.AutoSize = true;
            this.chkNote.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkNote.Location = new System.Drawing.Point(3, 50);
            this.chkNote.Name = "chkNote";
            this.chkNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNote.Size = new System.Drawing.Size(65, 29);
            this.chkNote.TabIndex = 237;
            this.chkNote.Tag = "Note";
            this.chkNote.Text = "ملاحظة";
            this.chkNote.UseVisualStyleBackColor = true;
            // 
            // btnReceiveReceipt
            // 
            this.btnReceiveReceipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReceiveReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveReceipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReceiveReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiveReceipt.Image")));
            this.btnReceiveReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReceiveReceipt.Location = new System.Drawing.Point(105, 3);
            this.btnReceiveReceipt.Name = "btnReceiveReceipt";
            this.btnReceiveReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReceiveReceipt.Size = new System.Drawing.Size(197, 41);
            this.btnReceiveReceipt.TabIndex = 238;
            this.btnReceiveReceipt.Tag = "ReceiveReceiptF8";
            this.btnReceiveReceipt.Text = "ايصال قبضF8";
            this.btnReceiveReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReceiveReceipt.UseVisualStyleBackColor = false;
            this.btnReceiveReceipt.Click += new System.EventHandler(this.btnReceiveReceipt_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(90, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUser.Size = new System.Drawing.Size(273, 26);
            this.lblUser.TabIndex = 247;
            this.lblUser.Text = "label1";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportInvoice
            // 
            this.btnExportInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExportInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnExportInvoice.Image = global::BumedianBM.Properties.Resources.invoice_export_32;
            this.btnExportInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportInvoice.Location = new System.Drawing.Point(5, 535);
            this.btnExportInvoice.Name = "btnExportInvoice";
            this.btnExportInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExportInvoice.Size = new System.Drawing.Size(165, 41);
            this.btnExportInvoice.TabIndex = 250;
            this.btnExportInvoice.Tag = "ExportInv";
            this.btnExportInvoice.Text = "تصدير الفاتورة";
            this.btnExportInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportInvoice.UseVisualStyleBackColor = false;
            this.btnExportInvoice.Click += new System.EventHandler(this.btnExportInvoice_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.btnReturnIQuicktem);
            this.panel1.Controls.Add(this.btnNewInvoice);
            this.panel1.Controls.Add(this.Chk_PrintCashClientName);
            this.panel1.Controls.Add(this.btnExportInvoice);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnCloseInvoice);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.btnInsertItem);
            this.panel1.Controls.Add(this.chkHideLogo);
            this.panel1.Controls.Add(this.chkIncludeTax);
            this.panel1.Controls.Add(this.chkPrintPreview);
            this.panel1.Controls.Add(this.chkHideDebt);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnReturnItem);
            this.panel1.Controls.Add(this.btnItemInfo);
            this.panel1.Controls.Add(this.btnItemCard);
            this.panel1.Controls.Add(this.btnModifyInvoice);
            this.panel1.Controls.Add(this.btnFindInvoice);
            this.panel1.Controls.Add(this.btnBalanceSheet);
            this.panel1.Controls.Add(this.btnDeleteItem);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 727);
            this.panel1.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Location = new System.Drawing.Point(3, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 277;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // btnReturnIQuicktem
            // 
            this.btnReturnIQuicktem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnIQuicktem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnIQuicktem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnIQuicktem.Image = global::BumedianBM.Properties.Resources.inventory_adjustment_32;
            this.btnReturnIQuicktem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnIQuicktem.Location = new System.Drawing.Point(4, 367);
            this.btnReturnIQuicktem.Name = "btnReturnIQuicktem";
            this.btnReturnIQuicktem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReturnIQuicktem.Size = new System.Drawing.Size(165, 41);
            this.btnReturnIQuicktem.TabIndex = 276;
            this.btnReturnIQuicktem.Tag = "ReturnItem";
            this.btnReturnIQuicktem.Text = "إرجاع سريع";
            this.btnReturnIQuicktem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnIQuicktem.UseVisualStyleBackColor = false;
            this.btnReturnIQuicktem.Click += new System.EventHandler(this.btnReturnIQuicktem_Click);
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNewInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnNewInvoice.Image")));
            this.btnNewInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewInvoice.Location = new System.Drawing.Point(3, 29);
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNewInvoice.Size = new System.Drawing.Size(165, 41);
            this.btnNewInvoice.TabIndex = 271;
            this.btnNewInvoice.Tag = "NewInvoice";
            this.btnNewInvoice.Text = "فاتورة جديدة F4";
            this.btnNewInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewInvoice.UseVisualStyleBackColor = false;
            this.btnNewInvoice.Click += new System.EventHandler(this.btnNewInvoice_Click);
            // 
            // Chk_PrintCashClientName
            // 
            this.Chk_PrintCashClientName.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.Chk_PrintCashClientName.Location = new System.Drawing.Point(4, 640);
            this.Chk_PrintCashClientName.Name = "Chk_PrintCashClientName";
            this.Chk_PrintCashClientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_PrintCashClientName.Size = new System.Drawing.Size(169, 29);
            this.Chk_PrintCashClientName.TabIndex = 275;
            this.Chk_PrintCashClientName.Tag = "CashClientPrint";
            this.Chk_PrintCashClientName.Text = "اخفاء الشعار";
            this.Chk_PrintCashClientName.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(4, 113);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(165, 41);
            this.btnPrint.TabIndex = 272;
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
            this.btnCloseInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCloseInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseInvoice.Image")));
            this.btnCloseInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseInvoice.Location = new System.Drawing.Point(4, 71);
            this.btnCloseInvoice.Name = "btnCloseInvoice";
            this.btnCloseInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCloseInvoice.Size = new System.Drawing.Size(165, 41);
            this.btnCloseInvoice.TabIndex = 273;
            this.btnCloseInvoice.Tag = "CloseInvoice";
            this.btnCloseInvoice.Text = "اغلاق فاتورة F5";
            this.btnCloseInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseInvoice.UseVisualStyleBackColor = false;
            this.btnCloseInvoice.Click += new System.EventHandler(this.btnCloseInvoice_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(57, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(110, 26);
            this.dtpDate.TabIndex = 270;
            // 
            // btnInsertItem
            // 
            this.btnInsertItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInsertItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnInsertItem.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertItem.Image")));
            this.btnInsertItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertItem.Location = new System.Drawing.Point(4, 155);
            this.btnInsertItem.Name = "btnInsertItem";
            this.btnInsertItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInsertItem.Size = new System.Drawing.Size(165, 41);
            this.btnInsertItem.TabIndex = 268;
            this.btnInsertItem.Tag = "InsertItemF3";
            this.btnInsertItem.Text = " ادراج صنف  F3";
            this.btnInsertItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInsertItem.UseVisualStyleBackColor = false;
            this.btnInsertItem.Click += new System.EventHandler(this.btnInsertItem_Click);
            // 
            // chkHideLogo
            // 
            this.chkHideLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHideLogo.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkHideLogo.Location = new System.Drawing.Point(4, 682);
            this.chkHideLogo.Name = "chkHideLogo";
            this.chkHideLogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideLogo.Size = new System.Drawing.Size(172, 29);
            this.chkHideLogo.TabIndex = 197;
            this.chkHideLogo.Tag = "HideLogo";
            this.chkHideLogo.Text = "اخفاء الشعار";
            this.chkHideLogo.UseVisualStyleBackColor = true;
            // 
            // chkIncludeTax
            // 
            this.chkIncludeTax.Checked = true;
            this.chkIncludeTax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeTax.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkIncludeTax.Location = new System.Drawing.Point(3, 704);
            this.chkIncludeTax.Name = "chkIncludeTax";
            this.chkIncludeTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIncludeTax.Size = new System.Drawing.Size(172, 29);
            this.chkIncludeTax.TabIndex = 195;
            this.chkIncludeTax.Tag = "IncludeTax";
            this.chkIncludeTax.Text = "تضمين الضريبة";
            this.chkIncludeTax.UseVisualStyleBackColor = true;
            // 
            // chkPrintPreview
            // 
            this.chkPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPrintPreview.Location = new System.Drawing.Point(5, 618);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPreview.Size = new System.Drawing.Size(169, 29);
            this.chkPrintPreview.TabIndex = 194;
            this.chkPrintPreview.Tag = "PP";
            this.chkPrintPreview.Text = "معاينة قبل الطباعة";
            this.chkPrintPreview.UseVisualStyleBackColor = true;
            // 
            // chkHideDebt
            // 
            this.chkHideDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHideDebt.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkHideDebt.Location = new System.Drawing.Point(4, 662);
            this.chkHideDebt.Name = "chkHideDebt";
            this.chkHideDebt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideDebt.Size = new System.Drawing.Size(156, 29);
            this.chkHideDebt.TabIndex = 196;
            this.chkHideDebt.Tag = "HideDebt";
            this.chkHideDebt.Text = "اخفاء الديون";
            this.chkHideDebt.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(5, 577);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(165, 41);
            this.btnClose.TabIndex = 193;
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
            this.btnReturnItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnItem.Image = global::BumedianBM.Properties.Resources.return_item_32;
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItem.Location = new System.Drawing.Point(4, 409);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReturnItem.Size = new System.Drawing.Size(165, 41);
            this.btnReturnItem.TabIndex = 191;
            this.btnReturnItem.Tag = "ReturnItem";
            this.btnReturnItem.Text = "فاتورة إرجاع";
            this.btnReturnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // btnItemInfo
            // 
            this.btnItemInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemInfo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnItemInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnItemInfo.Image")));
            this.btnItemInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnItemInfo.Location = new System.Drawing.Point(4, 240);
            this.btnItemInfo.Name = "btnItemInfo";
            this.btnItemInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnItemInfo.Size = new System.Drawing.Size(165, 41);
            this.btnItemInfo.TabIndex = 190;
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
            this.btnItemCard.Image = global::BumedianBM.Properties.Resources.item_card_323;
            this.btnItemCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItemCard.Location = new System.Drawing.Point(5, 493);
            this.btnItemCard.Name = "btnItemCard";
            this.btnItemCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnItemCard.Size = new System.Drawing.Size(165, 41);
            this.btnItemCard.TabIndex = 189;
            this.btnItemCard.Tag = "ItemCard";
            this.btnItemCard.Text = "بطاقة الصنف";
            this.btnItemCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnItemCard.UseVisualStyleBackColor = false;
            this.btnItemCard.Click += new System.EventHandler(this.btnItemCard_Click);
            // 
            // btnModifyInvoice
            // 
            this.btnModifyInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnModifyInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnModifyInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyInvoice.Image")));
            this.btnModifyInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyInvoice.Location = new System.Drawing.Point(4, 282);
            this.btnModifyInvoice.Name = "btnModifyInvoice";
            this.btnModifyInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModifyInvoice.Size = new System.Drawing.Size(165, 41);
            this.btnModifyInvoice.TabIndex = 188;
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
            this.btnFindInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFindInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnFindInvoice.Image")));
            this.btnFindInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindInvoice.Location = new System.Drawing.Point(4, 324);
            this.btnFindInvoice.Name = "btnFindInvoice";
            this.btnFindInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFindInvoice.Size = new System.Drawing.Size(165, 41);
            this.btnFindInvoice.TabIndex = 187;
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
            this.btnBalanceSheet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBalanceSheet.Image = ((System.Drawing.Image)(resources.GetObject("btnBalanceSheet.Image")));
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceSheet.Location = new System.Drawing.Point(5, 451);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBalanceSheet.Size = new System.Drawing.Size(165, 41);
            this.btnBalanceSheet.TabIndex = 192;
            this.btnBalanceSheet.Tag = "BalanceSheet";
            this.btnBalanceSheet.Text = "كشف الحساب";
            this.btnBalanceSheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalanceSheet.UseVisualStyleBackColor = false;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(4, 198);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDeleteItem.Size = new System.Drawing.Size(165, 41);
            this.btnDeleteItem.TabIndex = 186;
            this.btnDeleteItem.Tag = "DeleteF2";
            this.btnDeleteItem.Text = "الغاء صنفF2";
            this.btnDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(36, 48);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(128, 26);
            this.txtBarcode.TabIndex = 274;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // TableLayout1
            // 
            this.TableLayout1.ColumnCount = 2;
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.TableLayout1.Controls.Add(this.panel1, 1, 0);
            this.TableLayout1.Controls.Add(this.TableLayout2, 0, 0);
            this.TableLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout1.Location = new System.Drawing.Point(0, 0);
            this.TableLayout1.Name = "TableLayout1";
            this.TableLayout1.RowCount = 1;
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 796F));
            this.TableLayout1.Size = new System.Drawing.Size(1002, 733);
            this.TableLayout1.TabIndex = 0;
            // 
            // Sales_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1002, 733);
            this.Controls.Add(this.TableLayout1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sales_Invoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sales_Invoice_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sales_Invoice_FormClosed);
            this.Load += new System.EventHandler(this.Sales_Invoice_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sales_Invoice_KeyDown);
            this.TableLayout2.ResumeLayout(false);
            this.TableLayout2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TableLayout3.ResumeLayout(false);
            this.TableLayout3.PerformLayout();
            this.TableLayout4.ResumeLayout(false);
            this.TableLayout4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.grbNoteAndAlert.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.closeInvLoader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrSaleInvoice)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TableLayout1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip PriceTooltip;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.Timer tmrBlinkNotes;
        private System.Windows.Forms.TableLayoutPanel TableLayout2;
        private System.Windows.Forms.TableLayoutPanel TableLayout3;
        private System.Windows.Forms.TableLayoutPanel TableLayout4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grbNoteAndAlert;
        private System.Windows.Forms.RichTextBox rtxtNotesAndAlerts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkShowHideInvoiceCost;
        private System.Windows.Forms.MaskedTextBox txtTotalSaleValue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgrSaleInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Package;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unitprices;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalpric;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn Users;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn saledetailid;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesid;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Newexpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualPrices;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcostprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNumber;
        private System.Windows.Forms.Button btnExportInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewInvoice;
        private System.Windows.Forms.CheckBox Chk_PrintCashClientName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCloseInvoice;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnInsertItem;
        private System.Windows.Forms.CheckBox chkHideLogo;
        private System.Windows.Forms.CheckBox chkIncludeTax;
        private System.Windows.Forms.CheckBox chkPrintPreview;
        private System.Windows.Forms.CheckBox chkHideDebt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnItemInfo;
        private System.Windows.Forms.Button btnItemCard;
        private System.Windows.Forms.Button btnModifyInvoice;
        private System.Windows.Forms.Button btnFindInvoice;
        private System.Windows.Forms.Button btnBalanceSheet;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TableLayoutPanel TableLayout1;
        private System.Windows.Forms.Button btnReturnIQuicktem;
        private System.Windows.Forms.Panel closeInvLoader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.MaskedTextBox txtClientTotal;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblClientNo;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.ComboBox cmbClientNo;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbPackageQty;
        private System.Windows.Forms.ComboBox cmbSerialNo;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.MaskedTextBox txtQuantity;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.MaskedTextBox txtRemaining;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.MaskedTextBox txtTotalStock;
        private System.Windows.Forms.ComboBox dtpExpiry;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.MaskedTextBox txtPackage;
        private SergeUtils.EasyCompletionComboBox cmbItem;
        private SergeUtils.EasyCompletionComboBox cmbClient;
        private System.Windows.Forms.Label lblItemName1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtActiveUser;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtNewInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.MaskedTextBox txtPaymentCharges;
        private System.Windows.Forms.Label lblPaymentCharges;
        private System.Windows.Forms.CheckBox chkPaymentsTypes;
        private System.Windows.Forms.RadioButton radPercentage;
        private System.Windows.Forms.RadioButton radValue;
        private System.Windows.Forms.MaskedTextBox txtNet;
        private System.Windows.Forms.Label lblNet;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.MaskedTextBox txtDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MaskedTextBox txtTotal;
        private System.Windows.Forms.MaskedTextBox txtNote;
        private System.Windows.Forms.CheckBox chkNote;
        private System.Windows.Forms.Button btnReceiveReceipt;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnPriceChangeF7;
        private System.Windows.Forms.Button btnF9;
    }
}
