namespace BumedianBM.View
{
    partial class Print_Barcode
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Barcode));
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrBarcode = new System.Windows.Forms.Timer(this.components);
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmb_ItemNo = new System.Windows.Forms.ComboBox();
            this.Rdb_NormalPrice = new System.Windows.Forms.RadioButton();
            this.Rdb_BigPrice = new System.Windows.Forms.RadioButton();
            this.Lbl_Barcode = new System.Windows.Forms.Label();
            this.Dgv_Barcode = new System.Windows.Forms.DataGridView();
            this.MTB_BARCODE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTB_BARCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTB_ITEM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmb_ItemName = new System.Windows.Forms.ComboBox();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lbl_TotalPages = new System.Windows.Forms.Label();
            this.Txt_Totalpages = new System.Windows.Forms.TextBox();
            this.Lbl_TotalQty = new System.Windows.Forms.Label();
            this.Txt_Totalqty = new System.Windows.Forms.TextBox();
            this.Chk_Printlogo = new System.Windows.Forms.CheckBox();
            this.Chk_PrintPrice = new System.Windows.Forms.CheckBox();
            this.Lbl_Stock = new System.Windows.Forms.Label();
            this.Txt_Stock = new System.Windows.Forms.TextBox();
            this.Lbl_Cloumn = new System.Windows.Forms.Label();
            this.Lbl_Row = new System.Windows.Forms.Label();
            this.Lbl_Qty = new System.Windows.Forms.Label();
            this.Txt_Qty = new System.Windows.Forms.TextBox();
            this.Txt_Column = new System.Windows.Forms.TextBox();
            this.Dgv_PrintDetails = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lbl_ItemName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Open = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.Txt_Row = new System.Windows.Forms.TextBox();
            this.Lbl_ItemNo = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PrintDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column
            // 
            this.Column.DataPropertyName = "Column";
            this.Column.HeaderText = "Column";
            this.Column.Name = "Column";
            this.Column.ReadOnly = true;
            // 
            // tmrBarcode
            // 
            this.tmrBarcode.Interval = 1000;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Cmb_ItemNo
            // 
            this.Cmb_ItemNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_ItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_ItemNo.FormattingEnabled = true;
            this.Cmb_ItemNo.Location = new System.Drawing.Point(407, 10);
            this.Cmb_ItemNo.Name = "Cmb_ItemNo";
            this.Cmb_ItemNo.Size = new System.Drawing.Size(96, 26);
            this.Cmb_ItemNo.TabIndex = 215;
            // 
            // Rdb_NormalPrice
            // 
            this.Rdb_NormalPrice.AutoSize = true;
            this.Rdb_NormalPrice.Location = new System.Drawing.Point(387, 105);
            this.Rdb_NormalPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Rdb_NormalPrice.Name = "Rdb_NormalPrice";
            this.Rdb_NormalPrice.Size = new System.Drawing.Size(116, 23);
            this.Rdb_NormalPrice.TabIndex = 199;
            this.Rdb_NormalPrice.TabStop = true;
            this.Rdb_NormalPrice.Text = "Normal Price";
            this.Rdb_NormalPrice.UseVisualStyleBackColor = true;
            // 
            // Rdb_BigPrice
            // 
            this.Rdb_BigPrice.AutoSize = true;
            this.Rdb_BigPrice.Location = new System.Drawing.Point(296, 105);
            this.Rdb_BigPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Rdb_BigPrice.Name = "Rdb_BigPrice";
            this.Rdb_BigPrice.Size = new System.Drawing.Size(87, 23);
            this.Rdb_BigPrice.TabIndex = 198;
            this.Rdb_BigPrice.TabStop = true;
            this.Rdb_BigPrice.Text = "Big Price";
            this.Rdb_BigPrice.UseVisualStyleBackColor = true;
            // 
            // Lbl_Barcode
            // 
            this.Lbl_Barcode.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Lbl_Barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Barcode.Location = new System.Drawing.Point(522, 1);
            this.Lbl_Barcode.Name = "Lbl_Barcode";
            this.Lbl_Barcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Barcode.Size = new System.Drawing.Size(136, 17);
            this.Lbl_Barcode.TabIndex = 214;
            this.Lbl_Barcode.Text = "Barcode";
            this.Lbl_Barcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dgv_Barcode
            // 
            this.Dgv_Barcode.AllowUserToAddRows = false;
            this.Dgv_Barcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Barcode.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Dgv_Barcode.ColumnHeadersHeight = 25;
            this.Dgv_Barcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Barcode.ColumnHeadersVisible = false;
            this.Dgv_Barcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MTB_BARCODE_ID,
            this.MTB_BARCODE,
            this.MTB_ITEM_ID});
            this.Dgv_Barcode.Location = new System.Drawing.Point(522, 18);
            this.Dgv_Barcode.Name = "Dgv_Barcode";
            this.Dgv_Barcode.RowHeadersVisible = false;
            this.Dgv_Barcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Barcode.Size = new System.Drawing.Size(136, 122);
            this.Dgv_Barcode.TabIndex = 195;
            this.Dgv_Barcode.TabStop = false;
            // 
            // MTB_BARCODE_ID
            // 
            this.MTB_BARCODE_ID.DataPropertyName = "MTB_BARCODE_ID";
            this.MTB_BARCODE_ID.HeaderText = "ID";
            this.MTB_BARCODE_ID.Name = "MTB_BARCODE_ID";
            this.MTB_BARCODE_ID.Visible = false;
            // 
            // MTB_BARCODE
            // 
            this.MTB_BARCODE.DataPropertyName = "MTB_BARCODE";
            this.MTB_BARCODE.HeaderText = "Barcode";
            this.MTB_BARCODE.Name = "MTB_BARCODE";
            this.MTB_BARCODE.ReadOnly = true;
            // 
            // MTB_ITEM_ID
            // 
            this.MTB_ITEM_ID.DataPropertyName = "MTB_ITEM_ID";
            this.MTB_ITEM_ID.HeaderText = "ItemId";
            this.MTB_ITEM_ID.Name = "MTB_ITEM_ID";
            this.MTB_ITEM_ID.Visible = false;
            // 
            // Cmb_ItemName
            // 
            this.Cmb_ItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_ItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_ItemName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Cmb_ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_ItemName.FormattingEnabled = true;
            this.Cmb_ItemName.Location = new System.Drawing.Point(92, 7);
            this.Cmb_ItemName.Name = "Cmb_ItemName";
            this.Cmb_ItemName.Size = new System.Drawing.Size(199, 25);
            this.Cmb_ItemName.TabIndex = 192;
            // 
            // Row
            // 
            this.Row.DataPropertyName = "Row";
            this.Row.HeaderText = "Row";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            // 
            // Lbl_TotalPages
            // 
            this.Lbl_TotalPages.AutoSize = true;
            this.Lbl_TotalPages.Location = new System.Drawing.Point(287, 481);
            this.Lbl_TotalPages.Name = "Lbl_TotalPages";
            this.Lbl_TotalPages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalPages.Size = new System.Drawing.Size(87, 19);
            this.Lbl_TotalPages.TabIndex = 213;
            this.Lbl_TotalPages.Text = "Total Pages";
            // 
            // Txt_Totalpages
            // 
            this.Txt_Totalpages.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_Totalpages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Totalpages.Location = new System.Drawing.Point(380, 477);
            this.Txt_Totalpages.Name = "Txt_Totalpages";
            this.Txt_Totalpages.ReadOnly = true;
            this.Txt_Totalpages.Size = new System.Drawing.Size(81, 26);
            this.Txt_Totalpages.TabIndex = 212;
            this.Txt_Totalpages.TabStop = false;
            // 
            // Lbl_TotalQty
            // 
            this.Lbl_TotalQty.AutoSize = true;
            this.Lbl_TotalQty.Location = new System.Drawing.Point(467, 481);
            this.Lbl_TotalQty.Name = "Lbl_TotalQty";
            this.Lbl_TotalQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalQty.Size = new System.Drawing.Size(104, 19);
            this.Lbl_TotalQty.TabIndex = 211;
            this.Lbl_TotalQty.Text = "Total Quantity";
            // 
            // Txt_Totalqty
            // 
            this.Txt_Totalqty.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_Totalqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Totalqty.Location = new System.Drawing.Point(577, 477);
            this.Txt_Totalqty.Name = "Txt_Totalqty";
            this.Txt_Totalqty.ReadOnly = true;
            this.Txt_Totalqty.Size = new System.Drawing.Size(81, 26);
            this.Txt_Totalqty.TabIndex = 210;
            this.Txt_Totalqty.TabStop = false;
            // 
            // Chk_Printlogo
            // 
            this.Chk_Printlogo.AutoSize = true;
            this.Chk_Printlogo.Location = new System.Drawing.Point(194, 105);
            this.Chk_Printlogo.Name = "Chk_Printlogo";
            this.Chk_Printlogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_Printlogo.Size = new System.Drawing.Size(98, 23);
            this.Chk_Printlogo.TabIndex = 196;
            this.Chk_Printlogo.Text = "Print Logo";
            this.Chk_Printlogo.UseVisualStyleBackColor = true;
            // 
            // Chk_PrintPrice
            // 
            this.Chk_PrintPrice.AutoSize = true;
            this.Chk_PrintPrice.Location = new System.Drawing.Point(92, 105);
            this.Chk_PrintPrice.Name = "Chk_PrintPrice";
            this.Chk_PrintPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_PrintPrice.Size = new System.Drawing.Size(98, 23);
            this.Chk_PrintPrice.TabIndex = 197;
            this.Chk_PrintPrice.Text = "Print Price";
            this.Chk_PrintPrice.UseVisualStyleBackColor = true;
            // 
            // Lbl_Stock
            // 
            this.Lbl_Stock.AutoSize = true;
            this.Lbl_Stock.Location = new System.Drawing.Point(40, 78);
            this.Lbl_Stock.Name = "Lbl_Stock";
            this.Lbl_Stock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Stock.Size = new System.Drawing.Size(46, 19);
            this.Lbl_Stock.TabIndex = 209;
            this.Lbl_Stock.Text = "Stock";
            // 
            // Txt_Stock
            // 
            this.Txt_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Stock.Location = new System.Drawing.Point(92, 77);
            this.Txt_Stock.Name = "Txt_Stock";
            this.Txt_Stock.Size = new System.Drawing.Size(95, 22);
            this.Txt_Stock.TabIndex = 208;
            this.Txt_Stock.TabStop = false;
            // 
            // Lbl_Cloumn
            // 
            this.Lbl_Cloumn.AutoSize = true;
            this.Lbl_Cloumn.Location = new System.Drawing.Point(342, 73);
            this.Lbl_Cloumn.Name = "Lbl_Cloumn";
            this.Lbl_Cloumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Cloumn.Size = new System.Drawing.Size(60, 19);
            this.Lbl_Cloumn.TabIndex = 207;
            this.Lbl_Cloumn.Text = "Column";
            // 
            // Lbl_Row
            // 
            this.Lbl_Row.AutoSize = true;
            this.Lbl_Row.Location = new System.Drawing.Point(360, 43);
            this.Lbl_Row.Name = "Lbl_Row";
            this.Lbl_Row.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Row.Size = new System.Drawing.Size(42, 19);
            this.Lbl_Row.TabIndex = 206;
            this.Lbl_Row.Text = "Row ";
            // 
            // Lbl_Qty
            // 
            this.Lbl_Qty.AutoSize = true;
            this.Lbl_Qty.Location = new System.Drawing.Point(20, 44);
            this.Lbl_Qty.Name = "Lbl_Qty";
            this.Lbl_Qty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Qty.Size = new System.Drawing.Size(66, 19);
            this.Lbl_Qty.TabIndex = 205;
            this.Lbl_Qty.Text = "Quantity";
            // 
            // Txt_Qty
            // 
            this.Txt_Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Qty.Location = new System.Drawing.Point(92, 44);
            this.Txt_Qty.Name = "Txt_Qty";
            this.Txt_Qty.Size = new System.Drawing.Size(95, 22);
            this.Txt_Qty.TabIndex = 193;
            // 
            // Txt_Column
            // 
            this.Txt_Column.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Column.Location = new System.Drawing.Point(408, 72);
            this.Txt_Column.Name = "Txt_Column";
            this.Txt_Column.Size = new System.Drawing.Size(95, 22);
            this.Txt_Column.TabIndex = 201;
            // 
            // Dgv_PrintDetails
            // 
            this.Dgv_PrintDetails.AllowUserToAddRows = false;
            this.Dgv_PrintDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_PrintDetails.BackgroundColor = System.Drawing.Color.Beige;
            this.Dgv_PrintDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_PrintDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Id,
            this.Barcode,
            this.Row,
            this.Column,
            this.Quantity});
            this.Dgv_PrintDetails.Location = new System.Drawing.Point(142, 143);
            this.Dgv_PrintDetails.Name = "Dgv_PrintDetails";
            this.Dgv_PrintDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dgv_PrintDetails.RowHeadersVisible = false;
            this.Dgv_PrintDetails.RowHeadersWidth = 15;
            this.Dgv_PrintDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_PrintDetails.Size = new System.Drawing.Size(515, 328);
            this.Dgv_PrintDetails.TabIndex = 204;
            this.Dgv_PrintDetails.TabStop = false;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 64;
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
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // Lbl_ItemName
            // 
            this.Lbl_ItemName.AutoSize = true;
            this.Lbl_ItemName.Location = new System.Drawing.Point(3, 10);
            this.Lbl_ItemName.Name = "Lbl_ItemName";
            this.Lbl_ItemName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_ItemName.Size = new System.Drawing.Size(83, 19);
            this.Lbl_ItemName.TabIndex = 202;
            this.Lbl_ItemName.Text = "Item Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Open);
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.Btn_Close);
            this.groupBox1.Controls.Add(this.Btn_Print);
            this.groupBox1.Controls.Add(this.Btn_Delete);
            this.groupBox1.Controls.Add(this.Btn_Add);
            this.groupBox1.Controls.Add(this.Btn_New);
            this.groupBox1.Location = new System.Drawing.Point(0, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 322);
            this.groupBox1.TabIndex = 194;
            this.groupBox1.TabStop = false;
            // 
            // Btn_Open
            // 
            this.Btn_Open.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Open.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Open.Image")));
            this.Btn_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Open.Location = new System.Drawing.Point(8, 144);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(121, 40);
            this.Btn_Open.TabIndex = 3;
            this.Btn_Open.Text = "     Open    ";
            this.Btn_Open.UseVisualStyleBackColor = false;
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Save.Image")));
            this.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Save.Location = new System.Drawing.Point(8, 101);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(121, 40);
            this.Btn_Save.TabIndex = 2;
            this.Btn_Save.Text = "    Save    ";
            this.Btn_Save.UseVisualStyleBackColor = false;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Close.Image")));
            this.Btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Close.Location = new System.Drawing.Point(8, 273);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(121, 40);
            this.Btn_Close.TabIndex = 6;
            this.Btn_Close.Text = "     Close    ";
            this.Btn_Close.UseVisualStyleBackColor = false;
            // 
            // Btn_Print
            // 
            this.Btn_Print.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Print.Image")));
            this.Btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Print.Location = new System.Drawing.Point(8, 230);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(121, 40);
            this.Btn_Print.TabIndex = 5;
            this.Btn_Print.Text = "    Print    ";
            this.Btn_Print.UseVisualStyleBackColor = false;
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Delete.Image")));
            this.Btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Delete.Location = new System.Drawing.Point(8, 187);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(121, 40);
            this.Btn_Delete.TabIndex = 4;
            this.Btn_Delete.Text = "     Delete    ";
            this.Btn_Delete.UseVisualStyleBackColor = false;
            // 
            // Btn_Add
            // 
            this.Btn_Add.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Add.Image")));
            this.Btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Add.Location = new System.Drawing.Point(8, 58);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(121, 40);
            this.Btn_Add.TabIndex = 0;
            this.Btn_Add.Text = "    Add    ";
            this.Btn_Add.UseVisualStyleBackColor = false;
            // 
            // Btn_New
            // 
            this.Btn_New.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_New.Image = ((System.Drawing.Image)(resources.GetObject("Btn_New.Image")));
            this.Btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_New.Location = new System.Drawing.Point(8, 15);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(121, 40);
            this.Btn_New.TabIndex = 1;
            this.Btn_New.Text = "    New    ";
            this.Btn_New.UseVisualStyleBackColor = false;
            // 
            // Txt_Row
            // 
            this.Txt_Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Row.Location = new System.Drawing.Point(408, 43);
            this.Txt_Row.Name = "Txt_Row";
            this.Txt_Row.Size = new System.Drawing.Size(95, 22);
            this.Txt_Row.TabIndex = 200;
            // 
            // Lbl_ItemNo
            // 
            this.Lbl_ItemNo.AutoSize = true;
            this.Lbl_ItemNo.Location = new System.Drawing.Point(307, 13);
            this.Lbl_ItemNo.Name = "Lbl_ItemNo";
            this.Lbl_ItemNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_ItemNo.Size = new System.Drawing.Size(95, 19);
            this.Lbl_ItemNo.TabIndex = 203;
            this.Lbl_ItemNo.Text = "Item number";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(28, 163);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(40, 26);
            this.txtBarcode.TabIndex = 216;
            // 
            // Print_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 520);
            this.Controls.Add(this.Cmb_ItemNo);
            this.Controls.Add(this.Rdb_NormalPrice);
            this.Controls.Add(this.Rdb_BigPrice);
            this.Controls.Add(this.Lbl_Barcode);
            this.Controls.Add(this.Dgv_Barcode);
            this.Controls.Add(this.Cmb_ItemName);
            this.Controls.Add(this.Lbl_TotalPages);
            this.Controls.Add(this.Txt_Totalpages);
            this.Controls.Add(this.Lbl_TotalQty);
            this.Controls.Add(this.Txt_Totalqty);
            this.Controls.Add(this.Chk_Printlogo);
            this.Controls.Add(this.Chk_PrintPrice);
            this.Controls.Add(this.Lbl_Stock);
            this.Controls.Add(this.Txt_Stock);
            this.Controls.Add(this.Lbl_Cloumn);
            this.Controls.Add(this.Lbl_Row);
            this.Controls.Add(this.Lbl_Qty);
            this.Controls.Add(this.Txt_Qty);
            this.Controls.Add(this.Txt_Column);
            this.Controls.Add(this.Dgv_PrintDetails);
            this.Controls.Add(this.Lbl_ItemName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Txt_Row);
            this.Controls.Add(this.Lbl_ItemNo);
            this.Controls.Add(this.txtBarcode);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Print_Barcode";
            this.Text = "Print Barcode";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_PrintDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
        private System.Windows.Forms.Timer tmrBarcode;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.ComboBox Cmb_ItemNo;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.RadioButton Rdb_NormalPrice;
        private System.Windows.Forms.RadioButton Rdb_BigPrice;
        private System.Windows.Forms.Label Lbl_Barcode;
        private System.Windows.Forms.DataGridView Dgv_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_BARCODE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_BARCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_ITEM_ID;
        private System.Windows.Forms.ComboBox Cmb_ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.Label Lbl_TotalPages;
        private System.Windows.Forms.TextBox Txt_Totalpages;
        private System.Windows.Forms.Label Lbl_TotalQty;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.TextBox Txt_Totalqty;
        private System.Windows.Forms.CheckBox Chk_Printlogo;
        private System.Windows.Forms.CheckBox Chk_PrintPrice;
        private System.Windows.Forms.Label Lbl_Stock;
        private System.Windows.Forms.TextBox Txt_Stock;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.Label Lbl_Cloumn;
        private System.Windows.Forms.Label Lbl_Row;
        private System.Windows.Forms.Label Lbl_Qty;
        private System.Windows.Forms.TextBox Txt_Qty;
        private System.Windows.Forms.TextBox Txt_Column;
        private System.Windows.Forms.DataGridView Dgv_PrintDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.Label Lbl_ItemName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.TextBox Txt_Row;
        private System.Windows.Forms.Label Lbl_ItemNo;
        private System.Windows.Forms.TextBox txtBarcode;

    }
}