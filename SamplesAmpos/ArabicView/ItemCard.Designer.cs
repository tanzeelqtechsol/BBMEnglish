namespace BumedianBM.ArabicView
{
    partial class ItemCard
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
            ObjItemCardHelper = null;
            dictExpiryDetails = null;
            bd = null;
            ListParticularPackageDetails = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemCard));
            this.btnItemStock = new System.Windows.Forms.Button();
            this.cmbItemPlace = new System.Windows.Forms.ComboBox();
            this.chkHideItem = new System.Windows.Forms.CheckBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.grpItemInfo = new System.Windows.Forms.GroupBox();
            this.lblProfitRate = new System.Windows.Forms.Label();
            this.lblSpoiled = new System.Windows.Forms.Label();
            this.lblLastCost = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPurchase = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.cmbExpiryDate = new System.Windows.Forms.ComboBox();
            this.lblNearestExpiry = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.txtProfitRate = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtLastPurchases = new System.Windows.Forms.TextBox();
            this.txtLastCost = new System.Windows.Forms.TextBox();
            this.txtTotalSpoiled = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblMinimumPrice = new System.Windows.Forms.Label();
            this.txtMinimumPrice = new System.Windows.Forms.TextBox();
            this.txtWholeSale = new System.Windows.Forms.TextBox();
            this.lblWholeSale = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPackagePCs = new System.Windows.Forms.Label();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.lblItemPlace = new System.Windows.Forms.Label();
            this.txtPackagePcs = new System.Windows.Forms.TextBox();
            this.txtMaxOrder = new System.Windows.Forms.TextBox();
            this.lblMaxOrder = new System.Windows.Forms.Label();
            this.lblReorder = new System.Windows.Forms.Label();
            this.txtReorder = new System.Windows.Forms.TextBox();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbItemName = new SergeUtils.EasyCompletionComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcodes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnGeneratebarcodeList = new System.Windows.Forms.Button();
            this.btnInventoryAdjustment = new System.Windows.Forms.Button();
            this.btnInventorylist = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.Txt_ItemNo = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdditionalBarcode = new System.Windows.Forms.Button();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblLoadPhoto = new System.Windows.Forms.Label();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.grpItemInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnItemStock
            // 
            this.btnItemStock.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnItemStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemStock.Location = new System.Drawing.Point(274, 290);
            this.btnItemStock.Name = "btnItemStock";
            this.btnItemStock.Size = new System.Drawing.Size(320, 38);
            this.btnItemStock.TabIndex = 133;
            this.btnItemStock.Tag = "ItemStock";
            this.btnItemStock.Text = "بطاقة صنف - وارد - صادر - المخزون ";
            this.btnItemStock.UseVisualStyleBackColor = false;
            this.btnItemStock.Click += new System.EventHandler(this.btnItemStock_Click);
            // 
            // cmbItemPlace
            // 
            this.cmbItemPlace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemPlace.DisplayMember = "PlaceName";
            this.cmbItemPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemPlace.FormattingEnabled = true;
            this.cmbItemPlace.Location = new System.Drawing.Point(284, 256);
            this.cmbItemPlace.Name = "cmbItemPlace";
            this.cmbItemPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemPlace.Size = new System.Drawing.Size(148, 28);
            this.cmbItemPlace.TabIndex = 12;
            this.cmbItemPlace.ValueMember = "ItemPlaceID";
            this.cmbItemPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemPlace_KeyDown);
            this.cmbItemPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemPlace_KeyPress);
            this.cmbItemPlace.Leave += new System.EventHandler(this.cmbItemPlace_Leave);
            // 
            // chkHideItem
            // 
            this.chkHideItem.Location = new System.Drawing.Point(632, 53);
            this.chkHideItem.Name = "chkHideItem";
            this.chkHideItem.Size = new System.Drawing.Size(134, 35);
            this.chkHideItem.TabIndex = 20;
            this.chkHideItem.Tag = "HidenItem";
            this.chkHideItem.Text = "اخفاء الصنف \r\n";
            this.chkHideItem.UseVisualStyleBackColor = true;
            // 
            // lblItemType
            // 
            this.lblItemType.Location = new System.Drawing.Point(0, 17);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemType.Size = new System.Drawing.Size(80, 31);
            this.lblItemType.TabIndex = 128;
            this.lblItemType.Tag = "ItemType";
            this.lblItemType.Text = "نوع الصنف\r\n";
            // 
            // cmbItemType
            // 
            this.cmbItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.DropDownWidth = 140;
            this.cmbItemType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Location = new System.Drawing.Point(81, 15);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemType.Size = new System.Drawing.Size(145, 28);
            this.cmbItemType.TabIndex = 0;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            // 
            // grpItemInfo
            // 
            this.grpItemInfo.Controls.Add(this.lblProfitRate);
            this.grpItemInfo.Controls.Add(this.lblSpoiled);
            this.grpItemInfo.Controls.Add(this.lblLastCost);
            this.grpItemInfo.Controls.Add(this.lblStock);
            this.grpItemInfo.Controls.Add(this.lblPurchase);
            this.grpItemInfo.Controls.Add(this.lblCost);
            this.grpItemInfo.Controls.Add(this.cmbExpiryDate);
            this.grpItemInfo.Controls.Add(this.lblNearestExpiry);
            this.grpItemInfo.Controls.Add(this.lblPercentage);
            this.grpItemInfo.Controls.Add(this.lblAvg);
            this.grpItemInfo.Controls.Add(this.txtAverage);
            this.grpItemInfo.Controls.Add(this.txtProfitRate);
            this.grpItemInfo.Controls.Add(this.txtStock);
            this.grpItemInfo.Controls.Add(this.txtLastPurchases);
            this.grpItemInfo.Controls.Add(this.txtLastCost);
            this.grpItemInfo.Controls.Add(this.txtTotalSpoiled);
            this.grpItemInfo.Controls.Add(this.txtCost);
            this.grpItemInfo.Location = new System.Drawing.Point(211, 330);
            this.grpItemInfo.Name = "grpItemInfo";
            this.grpItemInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpItemInfo.Size = new System.Drawing.Size(578, 139);
            this.grpItemInfo.TabIndex = 125;
            this.grpItemInfo.TabStop = false;
            this.grpItemInfo.Tag = "ItemInfo";
            this.grpItemInfo.Text = "بيانات صنف \r\n";
            // 
            // lblProfitRate
            // 
            this.lblProfitRate.Location = new System.Drawing.Point(202, 69);
            this.lblProfitRate.Name = "lblProfitRate";
            this.lblProfitRate.Size = new System.Drawing.Size(77, 31);
            this.lblProfitRate.TabIndex = 99;
            this.lblProfitRate.Tag = "ProfitRate";
            this.lblProfitRate.Text = "نسبة الربح\r\n";
            this.lblProfitRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpoiled
            // 
            this.lblSpoiled.Location = new System.Drawing.Point(202, 102);
            this.lblSpoiled.Name = "lblSpoiled";
            this.lblSpoiled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSpoiled.Size = new System.Drawing.Size(86, 33);
            this.lblSpoiled.TabIndex = 444;
            this.lblSpoiled.Tag = "TotalSpoiled";
            this.lblSpoiled.Text = "اجمالي التالف\r\n";
            this.lblSpoiled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastCost
            // 
            this.lblLastCost.Location = new System.Drawing.Point(202, 34);
            this.lblLastCost.Name = "lblLastCost";
            this.lblLastCost.Size = new System.Drawing.Size(75, 31);
            this.lblLastCost.TabIndex = 97;
            this.lblLastCost.Tag = "LastCost";
            this.lblLastCost.Text = "اخر تكلفة ";
            this.lblLastCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(6, 64);
            this.lblStock.Name = "lblStock";
            this.lblStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStock.Size = new System.Drawing.Size(93, 31);
            this.lblStock.TabIndex = 96;
            this.lblStock.Tag = "Stock";
            this.lblStock.Text = "المخزون\r\n";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPurchase
            // 
            this.lblPurchase.Location = new System.Drawing.Point(5, 101);
            this.lblPurchase.Name = "lblPurchase";
            this.lblPurchase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPurchase.Size = new System.Drawing.Size(100, 31);
            this.lblPurchase.TabIndex = 95;
            this.lblPurchase.Tag = "LastPurchase";
            this.lblPurchase.Text = "اخر شراء \r\n";
            this.lblPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(7, 33);
            this.lblCost.Name = "lblCost";
            this.lblCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCost.Size = new System.Drawing.Size(95, 31);
            this.lblCost.TabIndex = 94;
            this.lblCost.Tag = "Cost";
            this.lblCost.Text = "تكلفة الصنف\r\n";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbExpiryDate
            // 
            this.cmbExpiryDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbExpiryDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExpiryDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpiryDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbExpiryDate.FormattingEnabled = true;
            this.cmbExpiryDate.Location = new System.Drawing.Point(468, 103);
            this.cmbExpiryDate.Name = "cmbExpiryDate";
            this.cmbExpiryDate.Size = new System.Drawing.Size(101, 28);
            this.cmbExpiryDate.TabIndex = 29;
            this.cmbExpiryDate.TabStop = false;
            // 
            // lblNearestExpiry
            // 
            this.lblNearestExpiry.Location = new System.Drawing.Point(375, 102);
            this.lblNearestExpiry.Name = "lblNearestExpiry";
            this.lblNearestExpiry.Size = new System.Drawing.Size(92, 31);
            this.lblNearestExpiry.TabIndex = 91;
            this.lblNearestExpiry.Tag = "NearestExpiry";
            this.lblNearestExpiry.Text = "اقرب صلاحية \r\n";
            this.lblNearestExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(377, 67);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPercentage.Size = new System.Drawing.Size(28, 31);
            this.lblPercentage.TabIndex = 82;
            this.lblPercentage.Text = "%";
            // 
            // lblAvg
            // 
            this.lblAvg.Location = new System.Drawing.Point(376, 34);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAvg.Size = new System.Drawing.Size(86, 31);
            this.lblAvg.TabIndex = 92;
            this.lblAvg.Tag = "Average";
            this.lblAvg.Text = "المتوسط \r\n";
            this.lblAvg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAverage
            // 
            this.txtAverage.BackColor = System.Drawing.SystemColors.Window;
            this.txtAverage.Enabled = false;
            this.txtAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAverage.Location = new System.Drawing.Point(468, 34);
            this.txtAverage.MaxLength = 30;
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(99, 27);
            this.txtAverage.TabIndex = 24;
            this.txtAverage.TabStop = false;
            // 
            // txtProfitRate
            // 
            this.txtProfitRate.BackColor = System.Drawing.Color.SeaShell;
            this.txtProfitRate.Enabled = false;
            this.txtProfitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtProfitRate.Location = new System.Drawing.Point(290, 70);
            this.txtProfitRate.MaxLength = 30;
            this.txtProfitRate.Name = "txtProfitRate";
            this.txtProfitRate.ReadOnly = true;
            this.txtProfitRate.Size = new System.Drawing.Size(83, 27);
            this.txtProfitRate.TabIndex = 26;
            this.txtProfitRate.TabStop = false;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.OldLace;
            this.txtStock.Enabled = false;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtStock.Location = new System.Drawing.Point(110, 68);
            this.txtStock.MaxLength = 30;
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(83, 27);
            this.txtStock.TabIndex = 25;
            this.txtStock.TabStop = false;
            // 
            // txtLastPurchases
            // 
            this.txtLastPurchases.BackColor = System.Drawing.SystemColors.Window;
            this.txtLastPurchases.Enabled = false;
            this.txtLastPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtLastPurchases.Location = new System.Drawing.Point(110, 104);
            this.txtLastPurchases.MaxLength = 30;
            this.txtLastPurchases.Name = "txtLastPurchases";
            this.txtLastPurchases.ReadOnly = true;
            this.txtLastPurchases.Size = new System.Drawing.Size(83, 27);
            this.txtLastPurchases.TabIndex = 27;
            this.txtLastPurchases.TabStop = false;
            // 
            // txtLastCost
            // 
            this.txtLastCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtLastCost.Enabled = false;
            this.txtLastCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtLastCost.Location = new System.Drawing.Point(290, 36);
            this.txtLastCost.MaxLength = 30;
            this.txtLastCost.Name = "txtLastCost";
            this.txtLastCost.ReadOnly = true;
            this.txtLastCost.Size = new System.Drawing.Size(83, 27);
            this.txtLastCost.TabIndex = 23;
            this.txtLastCost.TabStop = false;
            // 
            // txtTotalSpoiled
            // 
            this.txtTotalSpoiled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalSpoiled.Enabled = false;
            this.txtTotalSpoiled.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTotalSpoiled.Location = new System.Drawing.Point(290, 106);
            this.txtTotalSpoiled.MaxLength = 30;
            this.txtTotalSpoiled.Name = "txtTotalSpoiled";
            this.txtTotalSpoiled.ReadOnly = true;
            this.txtTotalSpoiled.Size = new System.Drawing.Size(83, 27);
            this.txtTotalSpoiled.TabIndex = 28;
            this.txtTotalSpoiled.TabStop = false;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.Color.Snow;
            this.txtCost.Enabled = false;
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCost.Location = new System.Drawing.Point(110, 35);
            this.txtCost.MaxLength = 30;
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(83, 27);
            this.txtCost.TabIndex = 22;
            this.txtCost.TabStop = false;
            this.txtCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);
            // 
            // lblMinimumPrice
            // 
            this.lblMinimumPrice.Location = new System.Drawing.Point(557, 215);
            this.lblMinimumPrice.Name = "lblMinimumPrice";
            this.lblMinimumPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMinimumPrice.Size = new System.Drawing.Size(112, 28);
            this.lblMinimumPrice.TabIndex = 124;
            this.lblMinimumPrice.Tag = "MinPrice";
            this.lblMinimumPrice.Text = "اقل سعر";
            this.lblMinimumPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMinimumPrice
            // 
            this.txtMinimumPrice.BackColor = System.Drawing.Color.Snow;
            this.txtMinimumPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtMinimumPrice.Location = new System.Drawing.Point(671, 216);
            this.txtMinimumPrice.MaxLength = 20;
            this.txtMinimumPrice.Name = "txtMinimumPrice";
            this.txtMinimumPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMinimumPrice.Size = new System.Drawing.Size(81, 26);
            this.txtMinimumPrice.TabIndex = 11;
            this.txtMinimumPrice.Text = "0.000";
            this.txtMinimumPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtMinimumPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtMinimumPrice.Leave += new System.EventHandler(this.txtMinimumPrice_Leave);
            // 
            // txtWholeSale
            // 
            this.txtWholeSale.BackColor = System.Drawing.Color.SeaShell;
            this.txtWholeSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtWholeSale.Location = new System.Drawing.Point(482, 218);
            this.txtWholeSale.MaxLength = 20;
            this.txtWholeSale.Name = "txtWholeSale";
            this.txtWholeSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWholeSale.Size = new System.Drawing.Size(70, 26);
            this.txtWholeSale.TabIndex = 10;
            this.txtWholeSale.Text = "0.000";
            this.txtWholeSale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtWholeSale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtWholeSale.Leave += new System.EventHandler(this.txtWholeSale_Leave);
            // 
            // lblWholeSale
            // 
            this.lblWholeSale.Location = new System.Drawing.Point(366, 217);
            this.lblWholeSale.Name = "lblWholeSale";
            this.lblWholeSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWholeSale.Size = new System.Drawing.Size(119, 28);
            this.lblWholeSale.TabIndex = 123;
            this.lblWholeSale.Tag = "WholeSale";
            this.lblWholeSale.Text = "سعر الجملة";
            this.lblWholeSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Location = new System.Drawing.Point(182, 220);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemPrice.Size = new System.Drawing.Size(97, 28);
            this.lblItemPrice.TabIndex = 122;
            this.lblItemPrice.Tag = "ItemPrice";
            this.lblItemPrice.Text = "سعر الصنف";
            this.lblItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.Honeydew;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Location = new System.Drawing.Point(284, 223);
            this.txtPrice.MaxLength = 20;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.Size = new System.Drawing.Size(80, 26);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.Text = "0.000";
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // lblPackagePCs
            // 
            this.lblPackagePCs.Location = new System.Drawing.Point(555, 177);
            this.lblPackagePCs.Name = "lblPackagePCs";
            this.lblPackagePCs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPackagePCs.Size = new System.Drawing.Size(114, 28);
            this.lblPackagePCs.TabIndex = 121;
            this.lblPackagePCs.Tag = "PackagePiece";
            this.lblPackagePCs.Text = "عدد القطع بالعلبة";
            this.lblPackagePCs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkExpiry
            // 
            this.chkExpiry.Location = new System.Drawing.Point(435, 252);
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkExpiry.Size = new System.Drawing.Size(170, 35);
            this.chkExpiry.TabIndex = 13;
            this.chkExpiry.Tag = "Expiry";
            this.chkExpiry.Text = "استخدام الصلاحية";
            this.chkExpiry.UseVisualStyleBackColor = true;
            this.chkExpiry.CheckedChanged += new System.EventHandler(this.chkExpiry_CheckedChanged);
            this.chkExpiry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkExpiry_KeyDown);
            this.chkExpiry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkExpiry_KeyPress);
            // 
            // lblItemPlace
            // 
            this.lblItemPlace.Location = new System.Drawing.Point(182, 253);
            this.lblItemPlace.Name = "lblItemPlace";
            this.lblItemPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemPlace.Size = new System.Drawing.Size(97, 31);
            this.lblItemPlace.TabIndex = 126;
            this.lblItemPlace.Tag = "ItemPlace";
            this.lblItemPlace.Text = "مكان الصنف\r\n";
            this.lblItemPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPackagePcs
            // 
            this.txtPackagePcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPackagePcs.Location = new System.Drawing.Point(671, 178);
            this.txtPackagePcs.MaxLength = 18;
            this.txtPackagePcs.Name = "txtPackagePcs";
            this.txtPackagePcs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPackagePcs.Size = new System.Drawing.Size(80, 27);
            this.txtPackagePcs.TabIndex = 4;
            this.txtPackagePcs.Text = "1";
            this.txtPackagePcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtPackagePcs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackagePcs_KeyPress);
            this.txtPackagePcs.Leave += new System.EventHandler(this.txtPackagePcs_Leave);
            // 
            // txtMaxOrder
            // 
            this.txtMaxOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtMaxOrder.Location = new System.Drawing.Point(481, 178);
            this.txtMaxOrder.MaxLength = 18;
            this.txtMaxOrder.Name = "txtMaxOrder";
            this.txtMaxOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaxOrder.Size = new System.Drawing.Size(71, 27);
            this.txtMaxOrder.TabIndex = 7;
            this.txtMaxOrder.Text = "100";
            this.txtMaxOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtMaxOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReorder_KeyPress);
            this.txtMaxOrder.Leave += new System.EventHandler(this.txtMaxOrder_Leave);
            // 
            // lblMaxOrder
            // 
            this.lblMaxOrder.Location = new System.Drawing.Point(366, 178);
            this.lblMaxOrder.Name = "lblMaxOrder";
            this.lblMaxOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaxOrder.Size = new System.Drawing.Size(120, 28);
            this.lblMaxOrder.TabIndex = 120;
            this.lblMaxOrder.Tag = "MaxOrder";
            this.lblMaxOrder.Text = "نقطة ايقاف الطلب";
            this.lblMaxOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReorder
            // 
            this.lblReorder.Location = new System.Drawing.Point(182, 178);
            this.lblReorder.Name = "lblReorder";
            this.lblReorder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReorder.Size = new System.Drawing.Size(98, 28);
            this.lblReorder.TabIndex = 119;
            this.lblReorder.Tag = "ReOrder";
            this.lblReorder.Text = "اعادة الطلب";
            this.lblReorder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReorder
            // 
            this.txtReorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReorder.Location = new System.Drawing.Point(283, 178);
            this.txtReorder.MaxLength = 18;
            this.txtReorder.Name = "txtReorder";
            this.txtReorder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReorder.Size = new System.Drawing.Size(69, 27);
            this.txtReorder.TabIndex = 6;
            this.txtReorder.Text = "1";
            this.txtReorder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.txtReorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReorder_KeyPress);
            this.txtReorder.Leave += new System.EventHandler(this.txtReorder_Leave);
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 435;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(285, 56);
            this.cmbItemNo.MaxDropDownItems = 35;
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemNo.Size = new System.Drawing.Size(299, 28);
            this.cmbItemNo.TabIndex = 0;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemNo_KeyDown);
            this.cmbItemNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItemNo_KeyUp);
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(452, 137);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompany.Size = new System.Drawing.Size(121, 28);
            this.lblCompany.TabIndex = 118;
            this.lblCompany.Tag = "Company";
            this.lblCompany.Text = "الشركة";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.DisplayMember = "CompanyName";
            this.cmbCompany.DropDownHeight = 350;
            this.cmbCompany.DropDownWidth = 350;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.IntegralHeight = false;
            this.cmbCompany.Location = new System.Drawing.Point(579, 138);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCompany.Size = new System.Drawing.Size(172, 28);
            this.cmbCompany.TabIndex = 3;
            this.cmbCompany.ValueMember = "CompanyID";
            this.cmbCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbCompany.Leave += new System.EventHandler(this.cmbCompany_Leave);
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(181, 138);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(98, 25);
            this.lblCategory.TabIndex = 117;
            this.lblCategory.Tag = "Category";
            this.lblCategory.Text = "المجموعة";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.DropDownHeight = 350;
            this.cmbCategory.DropDownWidth = 350;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Location = new System.Drawing.Point(283, 138);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCategory.Size = new System.Drawing.Size(161, 28);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.ValueMember = "CategoryID";
            this.cmbCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyDown);
            this.cmbCategory.Leave += new System.EventHandler(this.cmbCompany_Leave);
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
            this.cmbItemName.Location = new System.Drawing.Point(283, 104);
            this.cmbItemName.MaxDropDownItems = 15;
            this.cmbItemName.MaxLength = 200;
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbItemName.Size = new System.Drawing.Size(474, 26);
            this.cmbItemName.TabIndex = 1;
            this.cmbItemName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbItemName_DrawItem_1);
            this.cmbItemName.SelectedIndexChanged += new System.EventHandler(this.cmbItemName_SelectedIndexChanged);
            this.cmbItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemNo_KeyDown);
            this.cmbItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemName_KeyPress);
            this.cmbItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItemName_KeyUp);
            // 
            // lblItemName
            // 
            this.lblItemName.Location = new System.Drawing.Point(182, 101);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemName.Size = new System.Drawing.Size(97, 31);
            this.lblItemName.TabIndex = 116;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "اسم الصنف\r\n";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemNo
            // 
            this.lblItemNo.Location = new System.Drawing.Point(183, 53);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblItemNo.Size = new System.Drawing.Size(99, 31);
            this.lblItemNo.TabIndex = 115;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف\r\n";
            this.lblItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemNo.Visible = false;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Location = new System.Drawing.Point(222, 14);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBarcode.Size = new System.Drawing.Size(69, 31);
            this.lblBarcode.TabIndex = 114;
            this.lblBarcode.Tag = "Barcode";
            this.lblBarcode.Text = "باركود \r\n";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarcodes
            // 
            this.txtBarcodes.BackColor = System.Drawing.Color.FloralWhite;
            this.txtBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBarcodes.Location = new System.Drawing.Point(295, 15);
            this.txtBarcodes.MaxLength = 13;
            this.txtBarcodes.Name = "txtBarcodes";
            this.txtBarcodes.Size = new System.Drawing.Size(152, 27);
            this.txtBarcodes.TabIndex = 150;
            this.txtBarcodes.Leave += new System.EventHandler(this.txtBarcodes_Leave_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnGeneratebarcodeList);
            this.groupBox1.Controls.Add(this.btnInventoryAdjustment);
            this.groupBox1.Controls.Add(this.btnInventorylist);
            this.groupBox1.Controls.Add(this.btnPrintBarcode);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Location = new System.Drawing.Point(2, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 444);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(4, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(170, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "الغاء الامر\r\n";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(4, 346);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(170, 40);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnGeneratebarcodeList
            // 
            this.btnGeneratebarcodeList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGeneratebarcodeList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratebarcodeList.Image = global::BumedianBM.Properties.Resources.generated_barcode_list_32;
            this.btnGeneratebarcodeList.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGeneratebarcodeList.Location = new System.Drawing.Point(4, 300);
            this.btnGeneratebarcodeList.Name = "btnGeneratebarcodeList";
            this.btnGeneratebarcodeList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGeneratebarcodeList.Size = new System.Drawing.Size(170, 40);
            this.btnGeneratebarcodeList.TabIndex = 6;
            this.btnGeneratebarcodeList.Tag = "GenerateBarcodeList";
            this.btnGeneratebarcodeList.Text = "اصناف بدون باركود";
            this.btnGeneratebarcodeList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGeneratebarcodeList.UseVisualStyleBackColor = false;
            this.btnGeneratebarcodeList.Click += new System.EventHandler(this.btnGeneratebarcodeList_Click);
            // 
            // btnInventoryAdjustment
            // 
            this.btnInventoryAdjustment.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInventoryAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryAdjustment.Image = global::BumedianBM.Properties.Resources.inventory_adjustment_321;
            this.btnInventoryAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventoryAdjustment.Location = new System.Drawing.Point(4, 254);
            this.btnInventoryAdjustment.Name = "btnInventoryAdjustment";
            this.btnInventoryAdjustment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInventoryAdjustment.Size = new System.Drawing.Size(170, 40);
            this.btnInventoryAdjustment.TabIndex = 5;
            this.btnInventoryAdjustment.Tag = "InventoryAdjust";
            this.btnInventoryAdjustment.Text = "تعديل المخزون\r\n";
            this.btnInventoryAdjustment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventoryAdjustment.UseVisualStyleBackColor = false;
            this.btnInventoryAdjustment.Click += new System.EventHandler(this.btnInventoryAdjustment_Click);
            // 
            // btnInventorylist
            // 
            this.btnInventorylist.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInventorylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventorylist.Image = global::BumedianBM.Properties.Resources.inventory_list_32;
            this.btnInventorylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventorylist.Location = new System.Drawing.Point(4, 208);
            this.btnInventorylist.Name = "btnInventorylist";
            this.btnInventorylist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnInventorylist.Size = new System.Drawing.Size(170, 40);
            this.btnInventorylist.TabIndex = 4;
            this.btnInventorylist.Tag = "InventoryList";
            this.btnInventorylist.Text = "قائمة الجرد\r\n";
            this.btnInventorylist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventorylist.UseVisualStyleBackColor = false;
            this.btnInventorylist.Click += new System.EventHandler(this.btnInventorylist_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBarcode.Image = global::BumedianBM.Properties.Resources.print_barcode_323;
            this.btnPrintBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintBarcode.Location = new System.Drawing.Point(4, 162);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrintBarcode.Size = new System.Drawing.Size(170, 40);
            this.btnPrintBarcode.TabIndex = 3;
            this.btnPrintBarcode.Tag = "ItemPrintBarcode";
            this.btnPrintBarcode.Text = "إصدار باركود";
            this.btnPrintBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintBarcode.UseVisualStyleBackColor = false;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_item_321;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(4, 116);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(170, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::BumedianBM.Properties.Resources.item_save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(4, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(170, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n F5";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::BumedianBM.Properties.Resources.insert_item_323;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(4, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(170, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد\r\n F4";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Txt_ItemNo
            // 
            this.Txt_ItemNo.Location = new System.Drawing.Point(688, 10);
            this.Txt_ItemNo.MaxLength = 30;
            this.Txt_ItemNo.Name = "Txt_ItemNo";
            this.Txt_ItemNo.Size = new System.Drawing.Size(50, 36);
            this.Txt_ItemNo.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(502, 7);
            this.txtBarcode.MaxLength = 100;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(65, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBarcode.Image = global::BumedianBM.Properties.Resources.generate_barcode_32;
            this.btnBarcode.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBarcode.Location = new System.Drawing.Point(458, 7);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBarcode.Size = new System.Drawing.Size(156, 40);
            this.btnBarcode.TabIndex = 18;
            this.btnBarcode.Tag = "GenerateBarcode";
            this.btnBarcode.Text = "اصدار باركود F2";
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBarcode.UseVisualStyleBackColor = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(652, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(126, 41);
            this.btnClose.TabIndex = 17;
            this.btnClose.Tag = "Exit";
            this.btnClose.Text = "اغلاق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdditionalBarcode
            // 
            this.btnAdditionalBarcode.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdditionalBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdditionalBarcode.Image = global::BumedianBM.Properties.Resources.additional_barcode_32;
            this.btnAdditionalBarcode.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAdditionalBarcode.Location = new System.Drawing.Point(620, 7);
            this.btnAdditionalBarcode.Name = "btnAdditionalBarcode";
            this.btnAdditionalBarcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdditionalBarcode.Size = new System.Drawing.Size(156, 40);
            this.btnAdditionalBarcode.TabIndex = 19;
            this.btnAdditionalBarcode.Tag = "AdditionalBarCode";
            this.btnAdditionalBarcode.Text = "باركود اضافي\r\n F1";
            this.btnAdditionalBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdditionalBarcode.UseVisualStyleBackColor = false;
            this.btnAdditionalBarcode.Click += new System.EventHandler(this.btnAdditionalBarcode_Click);
            // 
            // txtImgPath
            // 
            this.txtImgPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtImgPath.Enabled = false;
            this.txtImgPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtImgPath.Location = new System.Drawing.Point(662, 256);
            this.txtImgPath.MaxLength = 30;
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.Size = new System.Drawing.Size(89, 24);
            this.txtImgPath.TabIndex = 0;
            this.txtImgPath.Visible = false;
            // 
            // picItem
            // 
            this.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem.Location = new System.Drawing.Point(643, 296);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(109, 28);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItem.TabIndex = 127;
            this.picItem.TabStop = false;
            this.picItem.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(607, 290);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(34, 37);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Tag = "Browse";
            this.btnBrowse.Text = "استعراض\r\n";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblLoadPhoto
            // 
            this.lblLoadPhoto.Location = new System.Drawing.Point(596, 253);
            this.lblLoadPhoto.Name = "lblLoadPhoto";
            this.lblLoadPhoto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLoadPhoto.Size = new System.Drawing.Size(57, 29);
            this.lblLoadPhoto.TabIndex = 130;
            this.lblLoadPhoto.Tag = "LoadPhoto";
            this.lblLoadPhoto.Text = "تحميل صورة \r\n";
            this.lblLoadPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoadPhoto.Visible = false;
            this.lblLoadPhoto.Click += new System.EventHandler(this.lblLoadPhoto_Click);
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.tmrBarcode_Tick);
            // 
            // ItemCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(786, 522);
            this.Controls.Add(this.btnItemStock);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.lblLoadPhoto);
            this.Controls.Add(this.cmbItemPlace);
            this.Controls.Add(this.chkHideItem);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.cmbItemType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.grpItemInfo);
            this.Controls.Add(this.lblMinimumPrice);
            this.Controls.Add(this.txtMinimumPrice);
            this.Controls.Add(this.txtWholeSale);
            this.Controls.Add(this.lblWholeSale);
            this.Controls.Add(this.lblItemPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPackagePCs);
            this.Controls.Add(this.chkExpiry);
            this.Controls.Add(this.picItem);
            this.Controls.Add(this.lblItemPlace);
            this.Controls.Add(this.txtPackagePcs);
            this.Controls.Add(this.txtMaxOrder);
            this.Controls.Add(this.lblMaxOrder);
            this.Controls.Add(this.lblReorder);
            this.Controls.Add(this.txtReorder);
            this.Controls.Add(this.cmbItemNo);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.btnAdditionalBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcodes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Txt_ItemNo);
            this.Controls.Add(this.txtImgPath);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "ItemCard";
            this.Text = "ItemCard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemCard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemCard_FormClosed);
            this.Load += new System.EventHandler(this.ItemCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemCard_KeyDown);
            this.grpItemInfo.ResumeLayout(false);
            this.grpItemInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnGeneratebarcodeList;
        private System.Windows.Forms.Button btnInventoryAdjustment;
        private System.Windows.Forms.Button btnInventorylist;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnItemStock;
        public System.Windows.Forms.Button btnBarcode;
        public System.Windows.Forms.ComboBox cmbItemPlace;
        public System.Windows.Forms.CheckBox chkHideItem;
        public System.Windows.Forms.Label lblItemType;
        public System.Windows.Forms.ComboBox cmbItemType;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.GroupBox grpItemInfo;
        public System.Windows.Forms.Label lblProfitRate;
        public System.Windows.Forms.Label lblSpoiled;
        public System.Windows.Forms.Label lblLastCost;
        public System.Windows.Forms.Label lblStock;
        public System.Windows.Forms.Label lblPurchase;
        public System.Windows.Forms.Label lblCost;
        public System.Windows.Forms.ComboBox cmbExpiryDate;
        public System.Windows.Forms.Label lblNearestExpiry;
        public System.Windows.Forms.Label lblPercentage;
        public System.Windows.Forms.Label lblAvg;
        public System.Windows.Forms.TextBox txtAverage;
        public System.Windows.Forms.TextBox txtProfitRate;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.TextBox txtLastCost;
        public System.Windows.Forms.TextBox txtLastPurchases;
        public System.Windows.Forms.TextBox txtTotalSpoiled;
        public System.Windows.Forms.TextBox txtCost;
        public System.Windows.Forms.Label lblMinimumPrice;
        public System.Windows.Forms.TextBox txtMinimumPrice;
        public System.Windows.Forms.TextBox txtWholeSale;
        public System.Windows.Forms.Label lblWholeSale;
        public System.Windows.Forms.Label lblItemPrice;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.Label lblPackagePCs;
        public System.Windows.Forms.CheckBox chkExpiry;
        public System.Windows.Forms.Label lblItemPlace;
        public System.Windows.Forms.TextBox txtPackagePcs;
        public System.Windows.Forms.TextBox txtMaxOrder;
        public System.Windows.Forms.Label lblMaxOrder;
        public System.Windows.Forms.Label lblReorder;
        public System.Windows.Forms.TextBox txtReorder;
        public System.Windows.Forms.Label lblCompany;
        public System.Windows.Forms.ComboBox cmbCompany;
        public System.Windows.Forms.Label lblCategory;
        public System.Windows.Forms.ComboBox cmbCategory;
        //public System.Windows.Forms.ComboBox cmbItemName;
        public SergeUtils.EasyCompletionComboBox cmbItemName;
        public System.Windows.Forms.Label lblItemName;
        public System.Windows.Forms.Label lblItemNo;
        public System.Windows.Forms.Button btnAdditionalBarcode;
        public System.Windows.Forms.Label lblBarcode;
        public System.Windows.Forms.TextBox txtBarcodes;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox Txt_ItemNo;
        public System.Windows.Forms.TextBox txtBarcode;
        public System.Windows.Forms.TextBox txtImgPath;
        public System.Windows.Forms.PictureBox picItem;
        public System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Label lblLoadPhoto;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.ComboBox cmbItemNo;
        public string IsAdditionboxClosed { get; set; }
    }
}