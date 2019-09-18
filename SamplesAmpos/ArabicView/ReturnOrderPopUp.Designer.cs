namespace BumedianBM.ArabicView
{
    partial class ReturnOrderPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnOrderPopUp));
            this.ReturnPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.cmbSerialNo = new System.Windows.Forms.ComboBox();
            this.cmb_Date = new System.Windows.Forms.ComboBox();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.txtPackageQty = new System.Windows.Forms.ComboBox();
            this.lbl_InvoiceNo = new System.Windows.Forms.Label();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.lbl_PackageQty = new System.Windows.Forms.Label();
            this.btnBox = new System.Windows.Forms.Button();
            this.cmbClientNo = new System.Windows.Forms.ComboBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReturnItem = new System.Windows.Forms.Button();
            this.cmbExpiryDate = new System.Windows.Forms.ComboBox();
            this.lblNearestExpiry = new System.Windows.Forms.Label();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbItemNo = new System.Windows.Forms.ComboBox();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblClientNo = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.ReturnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReturnPanel
            // 
            this.ReturnPanel.Controls.Add(this.btnDelete);
            this.ReturnPanel.Controls.Add(this.lblSerialNo);
            this.ReturnPanel.Controls.Add(this.cmbSerialNo);
            this.ReturnPanel.Controls.Add(this.cmb_Date);
            this.ReturnPanel.Controls.Add(this.lbl_Date);
            this.ReturnPanel.Controls.Add(this.txtPackageQty);
            this.ReturnPanel.Controls.Add(this.lbl_InvoiceNo);
            this.ReturnPanel.Controls.Add(this.txtbillno);
            this.ReturnPanel.Controls.Add(this.lbl_PackageQty);
            this.ReturnPanel.Controls.Add(this.btnBox);
            this.ReturnPanel.Controls.Add(this.cmbClientNo);
            this.ReturnPanel.Controls.Add(this.cmbClient);
            this.ReturnPanel.Controls.Add(this.btnClose);
            this.ReturnPanel.Controls.Add(this.btnReturnItem);
            this.ReturnPanel.Controls.Add(this.cmbExpiryDate);
            this.ReturnPanel.Controls.Add(this.lblNearestExpiry);
            this.ReturnPanel.Controls.Add(this.txt_Price);
            this.ReturnPanel.Controls.Add(this.lbl_Price);
            this.ReturnPanel.Controls.Add(this.lbl_Quantity);
            this.ReturnPanel.Controls.Add(this.txtQuantity);
            this.ReturnPanel.Controls.Add(this.cmbItemNo);
            this.ReturnPanel.Controls.Add(this.lblItemNo);
            this.ReturnPanel.Controls.Add(this.cmbItem);
            this.ReturnPanel.Controls.Add(this.lblItemName);
            this.ReturnPanel.Controls.Add(this.lblClientNo);
            this.ReturnPanel.Controls.Add(this.lblClient);
            this.ReturnPanel.Controls.Add(this.txtBarcode);
            this.ReturnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReturnPanel.Location = new System.Drawing.Point(0, 0);
            this.ReturnPanel.Name = "ReturnPanel";
            this.ReturnPanel.Size = new System.Drawing.Size(715, 261);
            this.ReturnPanel.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(12, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(101, 41);
            this.btnDelete.TabIndex = 447;
            this.btnDelete.Text = "الغاء";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSerialNo.Location = new System.Drawing.Point(434, 178);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(78, 31);
            this.lblSerialNo.TabIndex = 446;
            this.lblSerialNo.Tag = "SerialNo";
            this.lblSerialNo.Text = "المسلسل لا";
            // 
            // cmbSerialNo
            // 
            this.cmbSerialNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSerialNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSerialNo.DropDownWidth = 150;
            this.cmbSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSerialNo.FormattingEnabled = true;
            this.cmbSerialNo.IntegralHeight = false;
            this.cmbSerialNo.Location = new System.Drawing.Point(315, 179);
            this.cmbSerialNo.Name = "cmbSerialNo";
            this.cmbSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSerialNo.Size = new System.Drawing.Size(119, 28);
            this.cmbSerialNo.TabIndex = 7;
            this.cmbSerialNo.SelectedIndexChanged += new System.EventHandler(this.cmbSerialNo_SelectedIndexChanged);
            this.cmbSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // cmb_Date
            // 
            this.cmb_Date.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Date.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Date.DropDownHeight = 600;
            this.cmb_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_Date.FormattingEnabled = true;
            this.cmb_Date.IntegralHeight = false;
            this.cmb_Date.Items.AddRange(new object[] {
            "اليوم ",
            "أمس"});
            this.cmb_Date.Location = new System.Drawing.Point(212, 12);
            this.cmb_Date.Name = "cmb_Date";
            this.cmb_Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_Date.Size = new System.Drawing.Size(119, 28);
            this.cmb_Date.TabIndex = 1;
            this.cmb_Date.Visible = false;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Date.Location = new System.Drawing.Point(331, 11);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Date.Size = new System.Drawing.Size(45, 31);
            this.lbl_Date.TabIndex = 444;
            this.lbl_Date.Tag = "Date";
            this.lbl_Date.Text = "تاريخ";
            this.lbl_Date.Visible = false;
            // 
            // txtPackageQty
            // 
            this.txtPackageQty.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPackageQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPackageQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPackageQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPackageQty.FormattingEnabled = true;
            this.txtPackageQty.Location = new System.Drawing.Point(200, 134);
            this.txtPackageQty.Name = "txtPackageQty";
            this.txtPackageQty.Size = new System.Drawing.Size(124, 28);
            this.txtPackageQty.TabIndex = 0;
            this.txtPackageQty.SelectedIndexChanged += new System.EventHandler(this.txtPackageQty_SelectedIndexChanged);
            this.txtPackageQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // lbl_InvoiceNo
            // 
            this.lbl_InvoiceNo.AutoSize = true;
            this.lbl_InvoiceNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_InvoiceNo.Location = new System.Drawing.Point(534, 11);
            this.lbl_InvoiceNo.Name = "lbl_InvoiceNo";
            this.lbl_InvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_InvoiceNo.Size = new System.Drawing.Size(61, 31);
            this.lbl_InvoiceNo.TabIndex = 440;
            this.lbl_InvoiceNo.Tag = "InvoiceNo";
            this.lbl_InvoiceNo.Text = "فاتورة لا";
            this.lbl_InvoiceNo.Visible = false;
            // 
            // txtbillno
            // 
            this.txtbillno.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtbillno.Location = new System.Drawing.Point(414, 13);
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbillno.Size = new System.Drawing.Size(120, 27);
            this.txtbillno.TabIndex = 0;
            this.txtbillno.Visible = false;
            this.txtbillno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.txtbillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // lbl_PackageQty
            // 
            this.lbl_PackageQty.AutoSize = true;
            this.lbl_PackageQty.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_PackageQty.Location = new System.Drawing.Point(324, 133);
            this.lbl_PackageQty.Name = "lbl_PackageQty";
            this.lbl_PackageQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_PackageQty.Size = new System.Drawing.Size(88, 31);
            this.lbl_PackageQty.TabIndex = 437;
            this.lbl_PackageQty.Tag = "PackageQty";
            this.lbl_PackageQty.Text = "حزمة الكمية ";
            // 
            // btnBox
            // 
            this.btnBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBox.AutoSize = true;
            this.btnBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBox.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBox.Location = new System.Drawing.Point(212, 168);
            this.btnBox.Name = "btnBox";
            this.btnBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBox.Size = new System.Drawing.Size(81, 41);
            this.btnBox.TabIndex = 0;
            this.btnBox.Tag = "BoxF9";
            this.btnBox.Text = "علبة F9";
            this.btnBox.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBox.UseVisualStyleBackColor = false;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            this.btnBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // cmbClientNo
            // 
            this.cmbClientNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClientNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClientNo.DropDownHeight = 600;
            this.cmbClientNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbClientNo.FormattingEnabled = true;
            this.cmbClientNo.IntegralHeight = false;
            this.cmbClientNo.Location = new System.Drawing.Point(12, 49);
            this.cmbClientNo.Name = "cmbClientNo";
            this.cmbClientNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbClientNo.Size = new System.Drawing.Size(119, 28);
            this.cmbClientNo.TabIndex = 2;
            this.cmbClientNo.SelectedIndexChanged += new System.EventHandler(this.cmbClientNo_SelectedIndexChanged);
            this.cmbClientNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbClient_KeyDown);
            this.cmbClientNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClient.DropDownHeight = 600;
            this.cmbClient.DropDownWidth = 121;
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.IntegralHeight = false;
            this.cmbClient.ItemHeight = 20;
            this.cmbClient.Location = new System.Drawing.Point(212, 49);
            this.cmbClient.MaxDropDownItems = 50;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbClient.Size = new System.Drawing.Size(394, 28);
            this.cmbClient.TabIndex = 1;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            this.cmbClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbClient_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(12, 217);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(106, 41);
            this.btnClose.TabIndex = 10;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // btnReturnItem
            // 
            this.btnReturnItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnReturnItem.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnReturnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnItem.Image")));
            this.btnReturnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturnItem.Location = new System.Drawing.Point(553, 213);
            this.btnReturnItem.Name = "btnReturnItem";
            this.btnReturnItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnReturnItem.Size = new System.Drawing.Size(145, 41);
            this.btnReturnItem.TabIndex = 9;
            this.btnReturnItem.Tag = "ReturnItem";
            this.btnReturnItem.Text = "ترجيع بضاعة";
            this.btnReturnItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnItem.UseVisualStyleBackColor = false;
            this.btnReturnItem.Click += new System.EventHandler(this.btnReturnItem_Click);
            // 
            // cmbExpiryDate
            // 
            this.cmbExpiryDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbExpiryDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExpiryDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpiryDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbExpiryDate.FormattingEnabled = true;
            this.cmbExpiryDate.Location = new System.Drawing.Point(447, 134);
            this.cmbExpiryDate.Name = "cmbExpiryDate";
            this.cmbExpiryDate.Size = new System.Drawing.Size(159, 28);
            this.cmbExpiryDate.TabIndex = 0;
            this.cmbExpiryDate.TabStop = false;
            this.cmbExpiryDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            // 
            // lblNearestExpiry
            // 
            this.lblNearestExpiry.AutoSize = true;
            this.lblNearestExpiry.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNearestExpiry.Location = new System.Drawing.Point(606, 133);
            this.lblNearestExpiry.Name = "lblNearestExpiry";
            this.lblNearestExpiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNearestExpiry.Size = new System.Drawing.Size(98, 31);
            this.lblNearestExpiry.TabIndex = 330;
            this.lblNearestExpiry.Tag = "NearestExpiry";
            this.lblNearestExpiry.Text = "اقرب صلاحية \r\n";
            // 
            // txt_Price
            // 
            this.txt_Price.BackColor = System.Drawing.Color.MintCream;
            this.txt_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txt_Price.Location = new System.Drawing.Point(12, 135);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.ReadOnly = true;
            this.txt_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Price.Size = new System.Drawing.Size(119, 27);
            this.txt_Price.TabIndex = 0;
            this.txt_Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.txt_Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Price.Location = new System.Drawing.Point(131, 133);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Price.Size = new System.Drawing.Size(47, 31);
            this.lbl_Price.TabIndex = 327;
            this.lbl_Price.Tag = "Price";
            this.lbl_Price.Text = "السعر";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Quantity.Location = new System.Drawing.Point(616, 178);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Quantity.Size = new System.Drawing.Size(39, 31);
            this.lbl_Quantity.TabIndex = 326;
            this.lbl_Quantity.Tag = "Quantity";
            this.lbl_Quantity.Text = "كمية";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.Cornsilk;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtQuantity.Location = new System.Drawing.Point(516, 180);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(90, 27);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.Text = "1";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // cmbItemNo
            // 
            this.cmbItemNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemNo.DropDownHeight = 400;
            this.cmbItemNo.DropDownWidth = 150;
            this.cmbItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItemNo.FormattingEnabled = true;
            this.cmbItemNo.IntegralHeight = false;
            this.cmbItemNo.Location = new System.Drawing.Point(12, 89);
            this.cmbItemNo.Name = "cmbItemNo";
            this.cmbItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItemNo.Size = new System.Drawing.Size(119, 28);
            this.cmbItemNo.TabIndex = 0;
            this.cmbItemNo.SelectedIndexChanged += new System.EventHandler(this.cmbItemNo_SelectedIndexChanged);
            this.cmbItemNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbItemNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbItemNo_KeyPress);
            // 
            // lblItemNo
            // 
            this.lblItemNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblItemNo.AutoSize = true;
            this.lblItemNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemNo.Location = new System.Drawing.Point(131, 88);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemNo.Size = new System.Drawing.Size(78, 31);
            this.lblItemNo.TabIndex = 321;
            this.lblItemNo.Tag = "ItemNo";
            this.lblItemNo.Text = "رقم الصنف";
            // 
            // cmbItem
            // 
            this.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItem.DropDownHeight = 200;
            this.cmbItem.DropDownWidth = 450;
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.IntegralHeight = false;
            this.cmbItem.ItemHeight = 20;
            this.cmbItem.Location = new System.Drawing.Point(212, 89);
            this.cmbItem.MaxDropDownItems = 50;
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbItem.Size = new System.Drawing.Size(394, 28);
            this.cmbItem.TabIndex = 3;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            this.cmbItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyDown);
            this.cmbItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbItem_KeyUp);
            // 
            // lblItemName
            // 
            this.lblItemName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(606, 88);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblItemName.Size = new System.Drawing.Size(82, 31);
            this.lblItemName.TabIndex = 320;
            this.lblItemName.Tag = "ItemName";
            this.lblItemName.Text = "اسم الصنف";
            // 
            // lblClientNo
            // 
            this.lblClientNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClientNo.AutoSize = true;
            this.lblClientNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblClientNo.Location = new System.Drawing.Point(131, 48);
            this.lblClientNo.Name = "lblClientNo";
            this.lblClientNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblClientNo.Size = new System.Drawing.Size(74, 31);
            this.lblClientNo.TabIndex = 318;
            this.lblClientNo.Tag = "ClientNo";
            this.lblClientNo.Text = "رقم الزبون";
            // 
            // lblClient
            // 
            this.lblClient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblClient.Location = new System.Drawing.Point(606, 48);
            this.lblClient.Name = "lblClient";
            this.lblClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblClient.Size = new System.Drawing.Size(84, 31);
            this.lblClient.TabIndex = 317;
            this.lblClient.Tag = "ClientName";
            this.lblClient.Text = "اسم الزبون ";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Simplified Arabic", 8F);
            this.txtBarcode.Location = new System.Drawing.Point(485, 90);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBarcode.Size = new System.Drawing.Size(120, 25);
            this.txtBarcode.TabIndex = 441;
            this.txtBarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyUp);
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 250;
            this.tmrBarcode.Tick += new System.EventHandler(this.Tmr_Barcode_Tick);
            // 
            // ReturnOrderPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(715, 261);
            this.Controls.Add(this.ReturnPanel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnOrderPopUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "ReturnOrderPopUp";
            this.Text = "استرجاع صنف";
            this.Load += new System.EventHandler(this.ReturnOrderPopUp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnOrderPopUp_KeyDown);
            this.ReturnPanel.ResumeLayout(false);
            this.ReturnPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ReturnPanel;
        private System.Windows.Forms.Label lblClientNo;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbItemNo;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Label lbl_Price;
        public System.Windows.Forms.ComboBox cmbExpiryDate;
        public System.Windows.Forms.Label lblNearestExpiry;
        private System.Windows.Forms.Button btnReturnItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbClientNo;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Label lbl_PackageQty;
        private System.Windows.Forms.Label lbl_InvoiceNo;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox txtPackageQty;
        private System.Windows.Forms.ComboBox cmb_Date;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.ComboBox cmbSerialNo;
        private System.Windows.Forms.Button btnDelete;
    }
}