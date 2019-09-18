namespace BumedianBM.ArabicView
{
    partial class frmBalanceSheet
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

            objBalanceSheetHelper = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBalanceSheet));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBalanceSheet = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArabicDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewYrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenReceipt = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAgentDetails = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnEndOfTheDay = new System.Windows.Forms.Button();
            this.btnReturnItems = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOpenInvoice = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotalRecived = new System.Windows.Forms.MaskedTextBox();
            this.txtTotalDiscounts = new System.Windows.Forms.MaskedTextBox();
            this.txtTotalPaid = new System.Windows.Forms.MaskedTextBox();
            this.lblTotalPayable = new System.Windows.Forms.Label();
            this.lblTotalReceivable = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnPayMoneyRecipt = new System.Windows.Forms.Button();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.MaskedTextBox();
            this.btnReciveMoneyRecipt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.lblFromTime = new System.Windows.Forms.Label();
            this.lblToTime = new System.Windows.Forms.Label();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.lblBalanceSheet = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblBSForAgent = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cmbAgentID = new System.Windows.Forms.ComboBox();
            this.lblAgentNo = new System.Windows.Forms.Label();
            this.cmbAgentName = new SergeUtils.EasyCompletionComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceSheet)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.02409F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.9759F));
            this.tableLayoutPanel1.Controls.Add(this.dgvBalanceSheet, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.61837F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.38162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(996, 692);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvBalanceSheet
            // 
            this.dgvBalanceSheet.AllowUserToAddRows = false;
            this.dgvBalanceSheet.AllowUserToOrderColumns = true;
            this.dgvBalanceSheet.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBalanceSheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBalanceSheet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvBalanceSheet.ColumnHeadersHeight = 35;
            this.dgvBalanceSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Account,
            this.Description,
            this.ArabicDescription,
            this.Receivable,
            this.Payable,
            this.Balance,
            this.NewYrNo,
            this.Id,
            this.Year});
            this.dgvBalanceSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanceSheet.GridColor = System.Drawing.SystemColors.Control;
            this.dgvBalanceSheet.Location = new System.Drawing.Point(192, 151);
            this.dgvBalanceSheet.Name = "dgvBalanceSheet";
            this.dgvBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvBalanceSheet.RowHeadersVisible = false;
            this.dgvBalanceSheet.RowHeadersWidth = 13;
            this.dgvBalanceSheet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBalanceSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanceSheet.Size = new System.Drawing.Size(801, 426);
            this.dgvBalanceSheet.TabIndex = 26;
            this.dgvBalanceSheet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBalanceSheet_CellContentClick);
            this.dgvBalanceSheet.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBalanceSheet_CellDoubleClick);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "التاريخ\r\n";
            this.Date.MinimumWidth = 10;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 77;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "Account";
            this.Account.HeaderText = "الحساب";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "البيان";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // ArabicDescription
            // 
            this.ArabicDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ArabicDescription.DataPropertyName = "ArabicDescription";
            this.ArabicDescription.HeaderText = "ArabicDescription";
            this.ArabicDescription.Name = "ArabicDescription";
            this.ArabicDescription.Width = 180;
            // 
            // Receivable
            // 
            this.Receivable.DataPropertyName = "Receivable";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Receivable.DefaultCellStyle = dataGridViewCellStyle12;
            this.Receivable.HeaderText = "مدين \"عليه\"";
            this.Receivable.Name = "Receivable";
            this.Receivable.ReadOnly = true;
            // 
            // Payable
            // 
            this.Payable.DataPropertyName = "Payable";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Payable.DefaultCellStyle = dataGridViewCellStyle13;
            this.Payable.HeaderText = "دائن \"له\"";
            this.Payable.Name = "Payable";
            this.Payable.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle14;
            this.Balance.HeaderText = "الرصيد\r\n";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // NewYrNo
            // 
            this.NewYrNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NewYrNo.DataPropertyName = "NewYrNo";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.NewYrNo.DefaultCellStyle = dataGridViewCellStyle15;
            this.NewYrNo.HeaderText = "البيان\r\n";
            this.NewYrNo.Name = "NewYrNo";
            this.NewYrNo.ReadOnly = true;
            this.NewYrNo.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 426);
            this.panel1.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenReceipt);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnAgentDetails);
            this.groupBox2.Controls.Add(this.btnReports);
            this.groupBox2.Controls.Add(this.btnEndOfTheDay);
            this.groupBox2.Controls.Add(this.btnReturnItems);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnOpenInvoice);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Location = new System.Drawing.Point(0, -8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(181, 447);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // btnOpenReceipt
            // 
            this.btnOpenReceipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpenReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenReceipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnOpenReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenReceipt.Image")));
            this.btnOpenReceipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenReceipt.Location = new System.Drawing.Point(5, 106);
            this.btnOpenReceipt.Name = "btnOpenReceipt";
            this.btnOpenReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenReceipt.Size = new System.Drawing.Size(176, 41);
            this.btnOpenReceipt.TabIndex = 14;
            this.btnOpenReceipt.Tag = "OReceipt";
            this.btnOpenReceipt.Text = "فتح الايصال\r\n";
            this.btnOpenReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenReceipt.UseVisualStyleBackColor = false;
            this.btnOpenReceipt.Click += new System.EventHandler(this.btnOpenReceipt_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(5, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(176, 41);
            this.btnClose.TabIndex = 13;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAgentDetails
            // 
            this.btnAgentDetails.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgentDetails.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnAgentDetails.Image = global::BumedianBM.Properties.Resources.agents_32;
            this.btnAgentDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgentDetails.Location = new System.Drawing.Point(5, 244);
            this.btnAgentDetails.Name = "btnAgentDetails";
            this.btnAgentDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgentDetails.Size = new System.Drawing.Size(176, 41);
            this.btnAgentDetails.TabIndex = 10;
            this.btnAgentDetails.Tag = "AgentDetails";
            this.btnAgentDetails.Text = "بيانات العميل\r\n";
            this.btnAgentDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgentDetails.UseVisualStyleBackColor = false;
            this.btnAgentDetails.Click += new System.EventHandler(this.btnAgentDetails_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReports.Image = global::BumedianBM.Properties.Resources.reports2_32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(5, 290);
            this.btnReports.Name = "btnReports";
            this.btnReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReports.Size = new System.Drawing.Size(176, 41);
            this.btnReports.TabIndex = 8;
            this.btnReports.Tag = "Report";
            this.btnReports.Text = "التقارير\r\n";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnEndOfTheDay
            // 
            this.btnEndOfTheDay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEndOfTheDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndOfTheDay.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnEndOfTheDay.Image = global::BumedianBM.Properties.Resources.end_of_day_32;
            this.btnEndOfTheDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndOfTheDay.Location = new System.Drawing.Point(5, 336);
            this.btnEndOfTheDay.Name = "btnEndOfTheDay";
            this.btnEndOfTheDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEndOfTheDay.Size = new System.Drawing.Size(176, 41);
            this.btnEndOfTheDay.TabIndex = 7;
            this.btnEndOfTheDay.Tag = "EndOfDay";
            this.btnEndOfTheDay.Text = "حساب آخر اليوم\r\n";
            this.btnEndOfTheDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndOfTheDay.UseVisualStyleBackColor = false;
            this.btnEndOfTheDay.Click += new System.EventHandler(this.btnEndOfTheDay_Click);
            // 
            // btnReturnItems
            // 
            this.btnReturnItems.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnItems.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnItems.Image = global::BumedianBM.Properties.Resources.return_item_32;
            this.btnReturnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItems.Location = new System.Drawing.Point(5, 198);
            this.btnReturnItems.Name = "btnReturnItems";
            this.btnReturnItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReturnItems.Size = new System.Drawing.Size(176, 41);
            this.btnReturnItems.TabIndex = 5;
            this.btnReturnItems.Tag = "ReturnItem";
            this.btnReturnItems.Text = "ارجاع الاصناف\r\n";
            this.btnReturnItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnItems.UseVisualStyleBackColor = false;
            this.btnReturnItems.Click += new System.EventHandler(this.btnReturnItems_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(5, 152);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(176, 41);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOpenInvoice
            // 
            this.btnOpenInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpenInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnOpenInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenInvoice.Image")));
            this.btnOpenInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenInvoice.Location = new System.Drawing.Point(5, 60);
            this.btnOpenInvoice.Name = "btnOpenInvoice";
            this.btnOpenInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenInvoice.Size = new System.Drawing.Size(176, 41);
            this.btnOpenInvoice.TabIndex = 3;
            this.btnOpenInvoice.Tag = "OInvoice";
            this.btnOpenInvoice.Text = "فتح الفاتورة\r\n";
            this.btnOpenInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenInvoice.UseVisualStyleBackColor = false;
            this.btnOpenInvoice.Click += new System.EventHandler(this.btnOpenInvoice_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(5, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSearch.Size = new System.Drawing.Size(176, 41);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Tag = "Search";
            this.btnSearch.Text = "ابحث        \r\n";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(192, 583);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 106);
            this.panel2.TabIndex = 28;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel2.Controls.Add(this.txtTotalRecived, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTotalDiscounts, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTotalPaid, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalPayable, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalReceivable, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBalance, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPayMoneyRecipt, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalDiscount, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBalance, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnReciveMoneyRecipt, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.16129F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.83871F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(801, 106);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // txtTotalRecived
            // 
            this.txtTotalRecived.BackColor = System.Drawing.Color.Snow;
            this.tableLayoutPanel2.SetColumnSpan(this.txtTotalRecived, 2);
            this.txtTotalRecived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalRecived.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRecived.Location = new System.Drawing.Point(3, 31);
            this.txtTotalRecived.Name = "txtTotalRecived";
            this.txtTotalRecived.ReadOnly = true;
            this.txtTotalRecived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalRecived.Size = new System.Drawing.Size(214, 30);
            this.txtTotalRecived.TabIndex = 313;
            // 
            // txtTotalDiscounts
            // 
            this.txtTotalDiscounts.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.SetColumnSpan(this.txtTotalDiscounts, 2);
            this.txtTotalDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDiscounts.Location = new System.Drawing.Point(592, 31);
            this.txtTotalDiscounts.Name = "txtTotalDiscounts";
            this.txtTotalDiscounts.ReadOnly = true;
            this.txtTotalDiscounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalDiscounts.Size = new System.Drawing.Size(206, 30);
            this.txtTotalDiscounts.TabIndex = 22;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.BackColor = System.Drawing.Color.MintCream;
            this.tableLayoutPanel2.SetColumnSpan(this.txtTotalPaid, 2);
            this.txtTotalPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.Location = new System.Drawing.Point(223, 31);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalPaid.Size = new System.Drawing.Size(205, 30);
            this.txtTotalPaid.TabIndex = 311;
            // 
            // lblTotalPayable
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblTotalPayable, 2);
            this.lblTotalPayable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPayable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayable.Location = new System.Drawing.Point(223, 0);
            this.lblTotalPayable.Name = "lblTotalPayable";
            this.lblTotalPayable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalPayable.Size = new System.Drawing.Size(205, 28);
            this.lblTotalPayable.TabIndex = 312;
            this.lblTotalPayable.Text = "إجمالي دائن ";
            this.lblTotalPayable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalReceivable
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblTotalReceivable, 2);
            this.lblTotalReceivable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalReceivable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalReceivable.Location = new System.Drawing.Point(3, 0);
            this.lblTotalReceivable.Name = "lblTotalReceivable";
            this.lblTotalReceivable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalReceivable.Size = new System.Drawing.Size(214, 28);
            this.lblTotalReceivable.TabIndex = 314;
            this.lblTotalReceivable.Text = "إجمالي مدين";
            this.lblTotalReceivable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblBalance, 2);
            this.lblBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBalance.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(434, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(152, 28);
            this.lblBalance.TabIndex = 310;
            this.lblBalance.Tag = "Balance";
            this.lblBalance.Text = "الرصيد\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPayMoneyRecipt
            // 
            this.btnPayMoneyRecipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayMoneyRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.SetColumnSpan(this.btnPayMoneyRecipt, 2);
            this.btnPayMoneyRecipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayMoneyRecipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPayMoneyRecipt.Image = global::BumedianBM.Properties.Resources.pay_receipet_32;
            this.btnPayMoneyRecipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayMoneyRecipt.Location = new System.Drawing.Point(3, 65);
            this.btnPayMoneyRecipt.Name = "btnPayMoneyRecipt";
            this.btnPayMoneyRecipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPayMoneyRecipt.Size = new System.Drawing.Size(182, 38);
            this.btnPayMoneyRecipt.TabIndex = 30;
            this.btnPayMoneyRecipt.Tag = "PayReceipt";
            this.btnPayMoneyRecipt.Text = "ايصال صرف\r\n";
            this.btnPayMoneyRecipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayMoneyRecipt.UseVisualStyleBackColor = false;
            this.btnPayMoneyRecipt.Click += new System.EventHandler(this.MoneyReceipt_Click);
            // 
            // lblTotalDiscount
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblTotalDiscount, 2);
            this.lblTotalDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiscount.Location = new System.Drawing.Point(592, 0);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalDiscount.Size = new System.Drawing.Size(206, 28);
            this.lblTotalDiscount.TabIndex = 308;
            this.lblTotalDiscount.Text = "اجمالي التخفيض\r\n";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel2.SetColumnSpan(this.txtBalance, 2);
            this.txtBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(434, 31);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance.Size = new System.Drawing.Size(152, 30);
            this.txtBalance.TabIndex = 309;
            // 
            // btnReciveMoneyRecipt
            // 
            this.btnReciveMoneyRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.SetColumnSpan(this.btnReciveMoneyRecipt, 2);
            this.btnReciveMoneyRecipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReciveMoneyRecipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReciveMoneyRecipt.Image = global::BumedianBM.Properties.Resources.receive_receipet_32;
            this.btnReciveMoneyRecipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReciveMoneyRecipt.Location = new System.Drawing.Point(616, 65);
            this.btnReciveMoneyRecipt.Name = "btnReciveMoneyRecipt";
            this.btnReciveMoneyRecipt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReciveMoneyRecipt.Size = new System.Drawing.Size(182, 38);
            this.btnReciveMoneyRecipt.TabIndex = 31;
            this.btnReciveMoneyRecipt.Tag = "RecReceipt";
            this.btnReciveMoneyRecipt.Text = "ايصال قبض\r\n";
            this.btnReciveMoneyRecipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReciveMoneyRecipt.UseVisualStyleBackColor = false;
            this.btnReciveMoneyRecipt.Click += new System.EventHandler(this.MoneyReceipt_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dtpFromTime);
            this.panel3.Controls.Add(this.lblFromTime);
            this.panel3.Controls.Add(this.lblToTime);
            this.panel3.Controls.Add(this.dtpToTime);
            this.panel3.Controls.Add(this.lblBalanceSheet);
            this.panel3.Controls.Add(this.dtpToDate);
            this.panel3.Controls.Add(this.lblToDate);
            this.panel3.Controls.Add(this.lblFromDate);
            this.panel3.Controls.Add(this.lblBSForAgent);
            this.panel3.Controls.Add(this.chkAll);
            this.panel3.Controls.Add(this.cmbAgentID);
            this.panel3.Controls.Add(this.lblAgentNo);
            this.panel3.Controls.Add(this.cmbAgentName);
            this.panel3.Controls.Add(this.dtpFromDate);
            this.panel3.Location = new System.Drawing.Point(192, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(801, 139);
            this.panel3.TabIndex = 29;
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(205, 107);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(166, 26);
            this.dtpFromTime.TabIndex = 328;
            // 
            // lblFromTime
            // 
            this.lblFromTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFromTime.AutoSize = true;
            this.lblFromTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromTime.Location = new System.Drawing.Point(122, 110);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFromTime.Size = new System.Drawing.Size(77, 31);
            this.lblFromTime.TabIndex = 334;
            this.lblFromTime.Tag = "FT";
            this.lblFromTime.Text = "من الساعة\r\n";
            this.lblFromTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToTime
            // 
            this.lblToTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblToTime.AutoSize = true;
            this.lblToTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToTime.Location = new System.Drawing.Point(416, 108);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblToTime.Size = new System.Drawing.Size(80, 31);
            this.lblToTime.TabIndex = 335;
            this.lblToTime.Tag = "TT";
            this.lblToTime.Text = "حتى تاريخ \r\n";
            this.lblToTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpToTime
            // 
            this.dtpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(502, 105);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(160, 26);
            this.dtpToTime.TabIndex = 327;
            // 
            // lblBalanceSheet
            // 
            this.lblBalanceSheet.AutoSize = true;
            this.lblBalanceSheet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceSheet.Location = new System.Drawing.Point(258, 0);
            this.lblBalanceSheet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalanceSheet.Name = "lblBalanceSheet";
            this.lblBalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBalanceSheet.Size = new System.Drawing.Size(117, 19);
            this.lblBalanceSheet.TabIndex = 333;
            this.lblBalanceSheet.Tag = "BalanceSheet";
            this.lblBalanceSheet.Text = "كشف الحساب\r\n";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(502, 70);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpToDate.Size = new System.Drawing.Size(160, 26);
            this.dtpToDate.TabIndex = 322;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(416, 71);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblToDate.Size = new System.Drawing.Size(80, 31);
            this.lblToDate.TabIndex = 331;
            this.lblToDate.Tag = "TD";
            this.lblToDate.Text = "حتى تاريخ \r\n";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(122, 75);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFromDate.Size = new System.Drawing.Size(67, 31);
            this.lblFromDate.TabIndex = 330;
            this.lblFromDate.Tag = "FD";
            this.lblFromDate.Text = "من تاريخ\r\n";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBSForAgent
            // 
            this.lblBSForAgent.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBSForAgent.Location = new System.Drawing.Point(-12, 23);
            this.lblBSForAgent.Name = "lblBSForAgent";
            this.lblBSForAgent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBSForAgent.Size = new System.Drawing.Size(215, 31);
            this.lblBSForAgent.TabIndex = 329;
            this.lblBSForAgent.Tag = "BSForAgent";
            this.lblBSForAgent.Text = "حساب العميل\r\n";
            this.lblBSForAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkAll.Location = new System.Drawing.Point(679, 66);
            this.chkAll.Name = "chkAll";
            this.chkAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAll.Size = new System.Drawing.Size(61, 35);
            this.chkAll.TabIndex = 326;
            this.chkAll.Tag = "All";
            this.chkAll.Text = "الكل \r\n";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // cmbAgentID
            // 
            this.cmbAgentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAgentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAgentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAgentID.DisplayMember = "AgentID";
            this.cmbAgentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbAgentID.FormattingEnabled = true;
            this.cmbAgentID.Location = new System.Drawing.Point(574, 24);
            this.cmbAgentID.Name = "cmbAgentID";
            this.cmbAgentID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAgentID.Size = new System.Drawing.Size(200, 28);
            this.cmbAgentID.TabIndex = 325;
            this.cmbAgentID.Tag = "aaaa";
            this.cmbAgentID.ValueMember = "Name";
            this.cmbAgentID.DropDown += new System.EventHandler(this.cmbAgentID_DropDown);
            this.cmbAgentID.SelectedIndexChanged += new System.EventHandler(this.cmbAgentID_SelectedIndexChanged);
            this.cmbAgentID.DropDownClosed += new System.EventHandler(this.cmbAgentID_DropDownClosed);
            this.cmbAgentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAgentID_KeyDown);
            this.cmbAgentID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAgentID_KeyPress);
            // 
            // lblAgentNo
            // 
            this.lblAgentNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAgentNo.AutoSize = true;
            this.lblAgentNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAgentNo.Location = new System.Drawing.Point(463, 25);
            this.lblAgentNo.Name = "lblAgentNo";
            this.lblAgentNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAgentNo.Size = new System.Drawing.Size(71, 31);
            this.lblAgentNo.TabIndex = 332;
            this.lblAgentNo.Tag = "AgentNo";
            this.lblAgentNo.Text = "رقم العميل\r\n";
            this.lblAgentNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.DisplayMember = "Name";
            this.cmbAgentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.Location = new System.Drawing.Point(205, 26);
            this.cmbAgentName.MaxDropDownItems = 16;
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAgentName.Size = new System.Drawing.Size(195, 28);
            this.cmbAgentName.TabIndex = 324;
            this.cmbAgentName.ValueMember = "AgentID";
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            this.cmbAgentName.TextChanged += new System.EventHandler(this.cmbAgentName_TextChanged);
            this.cmbAgentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAgentName_KeyDown);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(205, 72);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFromDate.Size = new System.Drawing.Size(166, 26);
            this.dtpFromDate.TabIndex = 323;
            // 
            // frmBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(996, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBalanceSheet";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Balance Sheet";
            this.Text = "Balance Sheet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBalanceSheet_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBalanceSheet_FormClosed);
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBalanceSheet_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceSheet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvBalanceSheet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenReceipt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAgentDetails;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnEndOfTheDay;
        private System.Windows.Forms.Button btnReturnItems;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOpenInvoice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPayMoneyRecipt;
        private System.Windows.Forms.Button btnReciveMoneyRecipt;
        private System.Windows.Forms.MaskedTextBox txtBalance;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.MaskedTextBox txtTotalDiscounts;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.MaskedTextBox txtTotalPaid;
        private System.Windows.Forms.Label lblTotalPayable;
        private System.Windows.Forms.MaskedTextBox txtTotalRecived;
        private System.Windows.Forms.Label lblTotalReceivable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.Label lblFromTime;
        private System.Windows.Forms.Label lblToTime;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.Label lblBalanceSheet;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblBSForAgent;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cmbAgentID;
        private System.Windows.Forms.Label lblAgentNo;
        //private System.Windows.Forms.ComboBox cmbAgentName;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArabicDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewYrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private SergeUtils.EasyCompletionComboBox cmbAgentName;
    }
}
