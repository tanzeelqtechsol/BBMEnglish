namespace BumedianBM.ArabicView
{
    partial class PrimaryInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryInfo));
            this.tabPrimaryInfo = new System.Windows.Forms.TabControl();
            this.Tab_Category = new System.Windows.Forms.TabPage();
            this.cmb_PrinterName = new System.Windows.Forms.ComboBox();
            this.lbl_Printer = new System.Windows.Forms.Label();
            this.txtCategoryField = new System.Windows.Forms.TextBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.Tab_Company = new System.Windows.Forms.TabPage();
            this.txtCompanyField = new System.Windows.Forms.TextBox();
            this.lblFieldNam = new System.Windows.Forms.Label();
            this.txtCompanyFieldName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.Tab_ItemPlace = new System.Windows.Forms.TabPage();
            this.txtItemPlace = new System.Windows.Forms.TextBox();
            this.lblPlaceName = new System.Windows.Forms.Label();
            this.Tab_Bank = new System.Windows.Forms.TabPage();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.Tab_Branch = new System.Windows.Forms.TabPage();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.Tab_ItemUnit = new System.Windows.Forms.TabPage();
            this.lbl_NoOfPiecesInBox = new System.Windows.Forms.Label();
            this.lbl_NoOfBoxesInCartoon = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.txtUnitQuantity = new System.Windows.Forms.TextBox();
            this.lblUnitQuantity = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvPrimaryInfo = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabPrimaryInfo.SuspendLayout();
            this.Tab_Category.SuspendLayout();
            this.Tab_Company.SuspendLayout();
            this.Tab_ItemPlace.SuspendLayout();
            this.Tab_Bank.SuspendLayout();
            this.Tab_Branch.SuspendLayout();
            this.Tab_ItemUnit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimaryInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPrimaryInfo
            // 
            this.tabPrimaryInfo.Controls.Add(this.Tab_Category);
            this.tabPrimaryInfo.Controls.Add(this.Tab_Company);
            this.tabPrimaryInfo.Controls.Add(this.Tab_ItemPlace);
            this.tabPrimaryInfo.Controls.Add(this.Tab_Bank);
            this.tabPrimaryInfo.Controls.Add(this.Tab_Branch);
            this.tabPrimaryInfo.Controls.Add(this.Tab_ItemUnit);
            this.tabPrimaryInfo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.tabPrimaryInfo.ItemSize = new System.Drawing.Size(70, 34);
            this.tabPrimaryInfo.Location = new System.Drawing.Point(139, 1);
            this.tabPrimaryInfo.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.tabPrimaryInfo.Name = "tabPrimaryInfo";
            this.tabPrimaryInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPrimaryInfo.RightToLeftLayout = true;
            this.tabPrimaryInfo.SelectedIndex = 0;
            this.tabPrimaryInfo.Size = new System.Drawing.Size(434, 261);
            this.tabPrimaryInfo.TabIndex = 264;
            this.tabPrimaryInfo.SelectedIndexChanged += new System.EventHandler(this.tabPrimaryInfo_SelectedIndexChanged);
            this.tabPrimaryInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // Tab_Category
            // 
            this.Tab_Category.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_Category.Controls.Add(this.cmb_PrinterName);
            this.Tab_Category.Controls.Add(this.lbl_Printer);
            this.Tab_Category.Controls.Add(this.txtCategoryField);
            this.Tab_Category.Controls.Add(this.lblFieldName);
            this.Tab_Category.Controls.Add(this.txtCategoryName);
            this.Tab_Category.Controls.Add(this.lblCategoryName);
            this.Tab_Category.Font = new System.Drawing.Font("Segoe UI", 134F, System.Drawing.FontStyle.Bold);
            this.Tab_Category.Location = new System.Drawing.Point(4, 38);
            this.Tab_Category.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Category.Name = "Tab_Category";
            this.Tab_Category.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Category.Size = new System.Drawing.Size(426, 219);
            this.Tab_Category.TabIndex = 0;
            this.Tab_Category.Tag = "0";
            this.Tab_Category.Text = "المجموعة \r\n";
            // 
            // cmb_PrinterName
            // 
            this.cmb_PrinterName.DropDownHeight = 435;
            this.cmb_PrinterName.DropDownWidth = 350;
            this.cmb_PrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_PrinterName.FormattingEnabled = true;
            this.cmb_PrinterName.IntegralHeight = false;
            this.cmb_PrinterName.Location = new System.Drawing.Point(70, 170);
            this.cmb_PrinterName.MaxDropDownItems = 35;
            this.cmb_PrinterName.Name = "cmb_PrinterName";
            this.cmb_PrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_PrinterName.Size = new System.Drawing.Size(299, 28);
            this.cmb_PrinterName.TabIndex = 2;
            this.cmb_PrinterName.Text = "N/A";
            this.cmb_PrinterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Printer.Location = new System.Drawing.Point(65, 136);
            this.lbl_Printer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Printer.Size = new System.Drawing.Size(263, 31);
            this.lbl_Printer.TabIndex = 4;
            this.lbl_Printer.Tag = "Printer";
            this.lbl_Printer.Text = "Printer";
            this.lbl_Printer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCategoryField
            // 
            this.txtCategoryField.BackColor = System.Drawing.Color.White;
            this.txtCategoryField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCategoryField.Location = new System.Drawing.Point(70, 38);
            this.txtCategoryField.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtCategoryField.MaxLength = 100;
            this.txtCategoryField.Name = "txtCategoryField";
            this.txtCategoryField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCategoryField.Size = new System.Drawing.Size(299, 27);
            this.txtCategoryField.TabIndex = 0;
            this.txtCategoryField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtCategoryField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryField_KeyPress);
            this.txtCategoryField.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnitName_Validating);
            // 
            // lblFieldName
            // 
            this.lblFieldName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFieldName.Location = new System.Drawing.Point(67, 7);
            this.lblFieldName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFieldName.Size = new System.Drawing.Size(364, 31);
            this.lblFieldName.TabIndex = 3;
            this.lblFieldName.Tag = "FName";
            this.lblFieldName.Text = "الوصف\r\n";
            this.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.Color.MintCream;
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCategoryName.Location = new System.Drawing.Point(70, 102);
            this.txtCategoryName.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtCategoryName.MaxLength = 100;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCategoryName.Size = new System.Drawing.Size(299, 27);
            this.txtCategoryName.TabIndex = 1;
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtCategoryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.Location = new System.Drawing.Point(65, 71);
            this.lblCategoryName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCategoryName.Size = new System.Drawing.Size(263, 31);
            this.lblCategoryName.TabIndex = 2;
            this.lblCategoryName.Tag = "CatName";
            this.lblCategoryName.Text = "اسم المجموعة\r\n";
            this.lblCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_Company
            // 
            this.Tab_Company.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_Company.Controls.Add(this.txtCompanyField);
            this.Tab_Company.Controls.Add(this.lblFieldNam);
            this.Tab_Company.Controls.Add(this.txtCompanyFieldName);
            this.Tab_Company.Controls.Add(this.lblCompanyName);
            this.Tab_Company.Location = new System.Drawing.Point(4, 38);
            this.Tab_Company.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Company.Name = "Tab_Company";
            this.Tab_Company.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Company.Size = new System.Drawing.Size(426, 219);
            this.Tab_Company.TabIndex = 1;
            this.Tab_Company.Tag = "1";
            this.Tab_Company.Text = "الشركة \r\n";
            // 
            // txtCompanyField
            // 
            this.txtCompanyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCompanyField.Location = new System.Drawing.Point(26, 63);
            this.txtCompanyField.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtCompanyField.MaxLength = 100;
            this.txtCompanyField.Name = "txtCompanyField";
            this.txtCompanyField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompanyField.Size = new System.Drawing.Size(293, 27);
            this.txtCompanyField.TabIndex = 0;
            this.txtCompanyField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtCompanyField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryField_KeyPress);
            // 
            // lblFieldNam
            // 
            this.lblFieldNam.Location = new System.Drawing.Point(26, 24);
            this.lblFieldNam.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFieldNam.Name = "lblFieldNam";
            this.lblFieldNam.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFieldNam.Size = new System.Drawing.Size(123, 31);
            this.lblFieldNam.TabIndex = 269;
            this.lblFieldNam.Tag = "FieldName";
            this.lblFieldNam.Text = "الوصف";
            this.lblFieldNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCompanyFieldName
            // 
            this.txtCompanyFieldName.BackColor = System.Drawing.Color.MintCream;
            this.txtCompanyFieldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtCompanyFieldName.Location = new System.Drawing.Point(26, 139);
            this.txtCompanyFieldName.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtCompanyFieldName.MaxLength = 100;
            this.txtCompanyFieldName.Name = "txtCompanyFieldName";
            this.txtCompanyFieldName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompanyFieldName.Size = new System.Drawing.Size(293, 27);
            this.txtCompanyFieldName.TabIndex = 1;
            this.txtCompanyFieldName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtCompanyFieldName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(26, 100);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCompanyName.Size = new System.Drawing.Size(151, 31);
            this.lblCompanyName.TabIndex = 267;
            this.lblCompanyName.Tag = "ComName";
            this.lblCompanyName.Text = "اسم الشركة ";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tab_ItemPlace
            // 
            this.Tab_ItemPlace.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_ItemPlace.Controls.Add(this.txtItemPlace);
            this.Tab_ItemPlace.Controls.Add(this.lblPlaceName);
            this.Tab_ItemPlace.Location = new System.Drawing.Point(4, 38);
            this.Tab_ItemPlace.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_ItemPlace.Name = "Tab_ItemPlace";
            this.Tab_ItemPlace.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_ItemPlace.Size = new System.Drawing.Size(426, 219);
            this.Tab_ItemPlace.TabIndex = 2;
            this.Tab_ItemPlace.Tag = "2";
            this.Tab_ItemPlace.Text = "مكان الصنف\r\n";
            // 
            // txtItemPlace
            // 
            this.txtItemPlace.BackColor = System.Drawing.Color.MintCream;
            this.txtItemPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtItemPlace.Location = new System.Drawing.Point(28, 88);
            this.txtItemPlace.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtItemPlace.MaxLength = 50;
            this.txtItemPlace.Name = "txtItemPlace";
            this.txtItemPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemPlace.Size = new System.Drawing.Size(301, 27);
            this.txtItemPlace.TabIndex = 0;
            this.txtItemPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtItemPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // lblPlaceName
            // 
            this.lblPlaceName.Location = new System.Drawing.Point(24, 56);
            this.lblPlaceName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPlaceName.Name = "lblPlaceName";
            this.lblPlaceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPlaceName.Size = new System.Drawing.Size(123, 31);
            this.lblPlaceName.TabIndex = 265;
            this.lblPlaceName.Tag = "PlaceName";
            this.lblPlaceName.Text = "اسم مكان الصنف";
            this.lblPlaceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_Bank
            // 
            this.Tab_Bank.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_Bank.Controls.Add(this.txtBankName);
            this.Tab_Bank.Controls.Add(this.lblBankName);
            this.Tab_Bank.Location = new System.Drawing.Point(4, 38);
            this.Tab_Bank.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Bank.Name = "Tab_Bank";
            this.Tab_Bank.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Bank.Size = new System.Drawing.Size(426, 219);
            this.Tab_Bank.TabIndex = 3;
            this.Tab_Bank.Tag = "3";
            this.Tab_Bank.Text = "المصرف\r\n";
            // 
            // txtBankName
            // 
            this.txtBankName.BackColor = System.Drawing.Color.MintCream;
            this.txtBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBankName.Location = new System.Drawing.Point(31, 92);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtBankName.MaxLength = 50;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankName.Size = new System.Drawing.Size(289, 27);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCategoryName_KeyPress);
            // 
            // lblBankName
            // 
            this.lblBankName.Location = new System.Drawing.Point(27, 56);
            this.lblBankName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBankName.Size = new System.Drawing.Size(105, 31);
            this.lblBankName.TabIndex = 265;
            this.lblBankName.Tag = "BName";
            this.lblBankName.Text = "اسم المصرف";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_Branch
            // 
            this.Tab_Branch.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_Branch.Controls.Add(this.txtBranchName);
            this.Tab_Branch.Controls.Add(this.lblBranchName);
            this.Tab_Branch.Location = new System.Drawing.Point(4, 38);
            this.Tab_Branch.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Branch.Name = "Tab_Branch";
            this.Tab_Branch.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Tab_Branch.Size = new System.Drawing.Size(426, 219);
            this.Tab_Branch.TabIndex = 4;
            this.Tab_Branch.Tag = "4";
            this.Tab_Branch.Text = "الفرع";
            // 
            // txtBranchName
            // 
            this.txtBranchName.BackColor = System.Drawing.Color.MintCream;
            this.txtBranchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBranchName.Location = new System.Drawing.Point(44, 89);
            this.txtBranchName.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtBranchName.MaxLength = 50;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchName.Size = new System.Drawing.Size(274, 27);
            this.txtBranchName.TabIndex = 0;
            this.txtBranchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            // 
            // lblBranchName
            // 
            this.lblBranchName.Location = new System.Drawing.Point(34, 56);
            this.lblBranchName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranchName.Size = new System.Drawing.Size(85, 31);
            this.lblBranchName.TabIndex = 265;
            this.lblBranchName.Tag = "BrName";
            this.lblBranchName.Text = "اسم الفرع ";
            this.lblBranchName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Tab_ItemUnit
            // 
            this.Tab_ItemUnit.BackColor = System.Drawing.Color.AliceBlue;
            this.Tab_ItemUnit.Controls.Add(this.lbl_NoOfPiecesInBox);
            this.Tab_ItemUnit.Controls.Add(this.lbl_NoOfBoxesInCartoon);
            this.Tab_ItemUnit.Controls.Add(this.txtUnitName);
            this.Tab_ItemUnit.Controls.Add(this.lblUnitName);
            this.Tab_ItemUnit.Controls.Add(this.txtUnitQuantity);
            this.Tab_ItemUnit.Controls.Add(this.lblUnitQuantity);
            this.Tab_ItemUnit.Location = new System.Drawing.Point(4, 38);
            this.Tab_ItemUnit.Name = "Tab_ItemUnit";
            this.Tab_ItemUnit.Size = new System.Drawing.Size(426, 219);
            this.Tab_ItemUnit.TabIndex = 5;
            this.Tab_ItemUnit.Text = "وحدة البند";
            // 
            // lbl_NoOfPiecesInBox
            // 
            this.lbl_NoOfPiecesInBox.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_NoOfPiecesInBox.Location = new System.Drawing.Point(8, 143);
            this.lbl_NoOfPiecesInBox.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_NoOfPiecesInBox.Name = "lbl_NoOfPiecesInBox";
            this.lbl_NoOfPiecesInBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_NoOfPiecesInBox.Size = new System.Drawing.Size(49, 31);
            this.lbl_NoOfPiecesInBox.TabIndex = 9;
            this.lbl_NoOfPiecesInBox.Tag = "NoOfPiecesInBox";
            this.lbl_NoOfPiecesInBox.Text = "(عدد من القطع في العبوة)";
            this.lbl_NoOfPiecesInBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_NoOfPiecesInBox.Visible = false;
            // 
            // lbl_NoOfBoxesInCartoon
            // 
            this.lbl_NoOfBoxesInCartoon.BackColor = System.Drawing.Color.Transparent;
            this.lbl_NoOfBoxesInCartoon.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_NoOfBoxesInCartoon.Location = new System.Drawing.Point(1, 64);
            this.lbl_NoOfBoxesInCartoon.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_NoOfBoxesInCartoon.Name = "lbl_NoOfBoxesInCartoon";
            this.lbl_NoOfBoxesInCartoon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_NoOfBoxesInCartoon.Size = new System.Drawing.Size(75, 31);
            this.lbl_NoOfBoxesInCartoon.TabIndex = 8;
            this.lbl_NoOfBoxesInCartoon.Tag = "NoOfBoxesInCartoon";
            this.lbl_NoOfBoxesInCartoon.Text = "(عدد من صناديق الكرتون و )";
            this.lbl_NoOfBoxesInCartoon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_NoOfBoxesInCartoon.Visible = false;
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.Color.MintCream;
            this.txtUnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtUnitName.Location = new System.Drawing.Point(86, 68);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtUnitName.MaxLength = 100;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnitName.Size = new System.Drawing.Size(251, 27);
            this.txtUnitName.TabIndex = 0;
            this.txtUnitName.TextChanged += new System.EventHandler(this.txtUnitName_TextChanged);
            this.txtUnitName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            // 
            // lblUnitName
            // 
            this.lblUnitName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUnitName.Location = new System.Drawing.Point(88, 37);
            this.lblUnitName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUnitName.Size = new System.Drawing.Size(194, 31);
            this.lblUnitName.TabIndex = 7;
            this.lblUnitName.Tag = "UnitName";
            this.lblUnitName.Text = "اسم وحدة";
            this.lblUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUnitQuantity
            // 
            this.txtUnitQuantity.BackColor = System.Drawing.Color.SeaShell;
            this.txtUnitQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtUnitQuantity.Location = new System.Drawing.Point(86, 143);
            this.txtUnitQuantity.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.txtUnitQuantity.MaxLength = 100;
            this.txtUnitQuantity.Name = "txtUnitQuantity";
            this.txtUnitQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnitQuantity.Size = new System.Drawing.Size(251, 27);
            this.txtUnitQuantity.TabIndex = 1;
            this.txtUnitQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryField_KeyDown);
            this.txtUnitQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitName_KeyPress);
            // 
            // lblUnitQuantity
            // 
            this.lblUnitQuantity.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUnitQuantity.Location = new System.Drawing.Point(87, 112);
            this.lblUnitQuantity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnitQuantity.Name = "lblUnitQuantity";
            this.lblUnitQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUnitQuantity.Size = new System.Drawing.Size(220, 31);
            this.lblUnitQuantity.TabIndex = 6;
            this.lblUnitQuantity.Tag = "UnitQuantity";
            this.lblUnitQuantity.Text = "وحدة الكمية";
            this.lblUnitQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(-3, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(141, 254);
            this.groupBox2.TabIndex = 263;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(5, 203);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(132, 40);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(4, 25);
            this.btnNew.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(132, 40);
            this.btnNew.TabIndex = 6;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد\r\n";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(5, 70);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(132, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnView.Image = global::BumedianBM.Properties.Resources.views_321;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(5, 114);
            this.btnView.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnView.Size = new System.Drawing.Size(132, 40);
            this.btnView.TabIndex = 3;
            this.btnView.Tag = "View";
            this.btnView.Text = "عرض\r\n";
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(5, 159);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(132, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "الغاء الامر\r\n";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvPrimaryInfo
            // 
            this.dgvPrimaryInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvPrimaryInfo.AllowDrop = true;
            this.dgvPrimaryInfo.AllowUserToAddRows = false;
            this.dgvPrimaryInfo.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvPrimaryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrimaryInfo.Location = new System.Drawing.Point(144, 23);
            this.dgvPrimaryInfo.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.dgvPrimaryInfo.Name = "dgvPrimaryInfo";
            this.dgvPrimaryInfo.ReadOnly = true;
            this.dgvPrimaryInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPrimaryInfo.RowHeadersVisible = false;
            this.dgvPrimaryInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrimaryInfo.Size = new System.Drawing.Size(421, 239);
            this.dgvPrimaryInfo.TabIndex = 267;
            this.dgvPrimaryInfo.VirtualMode = true;
            this.dgvPrimaryInfo.DoubleClick += new System.EventHandler(this.dgvPrimaryInfo_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(157, 270);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(132, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBack.Image = global::BumedianBM.Properties.Resources.back_32;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(157, 271);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBack.Size = new System.Drawing.Size(132, 40);
            this.btnBack.TabIndex = 7;
            this.btnBack.Tag = "Back";
            this.btnBack.Text = "رجوع\r\n";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PrimaryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(576, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabPrimaryInfo);
            this.Controls.Add(this.dgvPrimaryInfo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimaryInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrimaryInfo";
            this.Load += new System.EventHandler(this.PrimaryInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrimaryInfo_KeyDown);
            this.tabPrimaryInfo.ResumeLayout(false);
            this.Tab_Category.ResumeLayout(false);
            this.Tab_Category.PerformLayout();
            this.Tab_Company.ResumeLayout(false);
            this.Tab_Company.PerformLayout();
            this.Tab_ItemPlace.ResumeLayout(false);
            this.Tab_ItemPlace.PerformLayout();
            this.Tab_Bank.ResumeLayout(false);
            this.Tab_Bank.PerformLayout();
            this.Tab_Branch.ResumeLayout(false);
            this.Tab_Branch.PerformLayout();
            this.Tab_ItemUnit.ResumeLayout(false);
            this.Tab_ItemUnit.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimaryInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabPrimaryInfo;
        public System.Windows.Forms.TabPage Tab_Category;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TabPage Tab_Company;
        private System.Windows.Forms.Label lblFieldNam;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TabPage Tab_ItemPlace;
        private System.Windows.Forms.Label lblPlaceName;
        private System.Windows.Forms.TabPage Tab_Bank;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.TabPage Tab_Branch;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.TextBox txtCategoryField;
        public System.Windows.Forms.TextBox txtCategoryName;
        public System.Windows.Forms.TextBox txtCompanyField;
        public System.Windows.Forms.TextBox txtCompanyFieldName;
        public System.Windows.Forms.TextBox txtItemPlace;
        public System.Windows.Forms.TextBox txtBankName;
        public System.Windows.Forms.TextBox txtBranchName;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvPrimaryInfo;
        private System.Windows.Forms.TabPage Tab_ItemUnit;
        public System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label lblUnitName;
        public System.Windows.Forms.TextBox txtUnitQuantity;
        private System.Windows.Forms.Label lblUnitQuantity;
        private System.Windows.Forms.Label lbl_NoOfPiecesInBox;
        private System.Windows.Forms.Label lbl_NoOfBoxesInCartoon;
        private System.Windows.Forms.Label lbl_Printer;
        private System.Windows.Forms.ComboBox cmb_PrinterName;
        public string IsReciept { get; set; }

    }
}
