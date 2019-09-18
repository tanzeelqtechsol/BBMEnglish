namespace BumedianBM.View
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryInfo));
            this.dgvPrimaryInfo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtItemPlace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCompanyFieldName = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCategoryFieldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPrimaryInfo = new System.Windows.Forms.TabControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimaryInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPrimaryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPrimaryInfo
            // 
            this.dgvPrimaryInfo.AllowUserToAddRows = false;
            this.dgvPrimaryInfo.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvPrimaryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrimaryInfo.Location = new System.Drawing.Point(179, 22);
            this.dgvPrimaryInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvPrimaryInfo.Name = "dgvPrimaryInfo";
            this.dgvPrimaryInfo.ReadOnly = true;
            this.dgvPrimaryInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPrimaryInfo.RowHeadersVisible = false;
            this.dgvPrimaryInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrimaryInfo.Size = new System.Drawing.Size(354, 255);
            this.dgvPrimaryInfo.TabIndex = 272;
            this.dgvPrimaryInfo.VirtualMode = true;
            this.dgvPrimaryInfo.DoubleClick += new System.EventHandler(this.datagrid_doubleclick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Size = new System.Drawing.Size(168, 272);
            this.groupBox1.TabIndex = 268;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(6, 215);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 51);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(6, 11);
            this.btnNew.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(156, 51);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(6, 62);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 51);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnView.Image = global::BumedianBM.Properties.Resources.views_32;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(6, 113);
            this.btnView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(156, 51);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(6, 164);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 51);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.txtBranchName);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage5.Size = new System.Drawing.Size(369, 232);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Tag = "4";
            this.tabPage5.Text = "Branch";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtBranchName.Location = new System.Drawing.Point(41, 74);
            this.txtBranchName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBranchName.MaxLength = 50;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBranchName.Size = new System.Drawing.Size(316, 26);
            this.txtBranchName.TabIndex = 0;
            this.txtBranchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 265;
            this.label7.Text = "Branch Name";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.txtBankName);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage4.Size = new System.Drawing.Size(369, 232);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Tag = "3";
            this.tabPage4.Text = "Bank";
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtBankName.Location = new System.Drawing.Point(42, 79);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBankName.MaxLength = 50;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankName.Size = new System.Drawing.Size(316, 26);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 265;
            this.label6.Text = "Bank Name";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.txtItemPlace);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage3.Size = new System.Drawing.Size(369, 232);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "2";
            this.tabPage3.Text = "Item place";
            // 
            // txtItemPlace
            // 
            this.txtItemPlace.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtItemPlace.Location = new System.Drawing.Point(41, 79);
            this.txtItemPlace.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtItemPlace.MaxLength = 50;
            this.txtItemPlace.Name = "txtItemPlace";
            this.txtItemPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtItemPlace.Size = new System.Drawing.Size(316, 26);
            this.txtItemPlace.TabIndex = 0;
            this.txtItemPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(89, 19);
            this.label5.TabIndex = 265;
            this.label5.Text = "Place Name";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.txtCompanyFieldName);
            this.tabPage2.Controls.Add(this.txtCompany);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage2.Size = new System.Drawing.Size(369, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "1";
            this.tabPage2.Text = "Company ";
            // 
            // txtCompanyFieldName
            // 
            this.txtCompanyFieldName.BackColor = System.Drawing.Color.White;
            this.txtCompanyFieldName.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtCompanyFieldName.Location = new System.Drawing.Point(43, 63);
            this.txtCompanyFieldName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompanyFieldName.MaxLength = 100;
            this.txtCompanyFieldName.Name = "txtCompanyFieldName";
            this.txtCompanyFieldName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompanyFieldName.Size = new System.Drawing.Size(316, 26);
            this.txtCompanyFieldName.TabIndex = 0;
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.White;
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtCompany.Location = new System.Drawing.Point(43, 130);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompany.MaxLength = 100;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompany.Size = new System.Drawing.Size(316, 26);
            this.txtCompany.TabIndex = 1;
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 269;
            this.label3.Text = "Field Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 267;
            this.label4.Text = "Company Name";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.txtCategoryFieldName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCategory);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPage1.Size = new System.Drawing.Size(369, 232);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "0";
            this.tabPage1.Text = "Category";
            // 
            // txtCategoryFieldName
            // 
            this.txtCategoryFieldName.BackColor = System.Drawing.Color.White;
            this.txtCategoryFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryFieldName.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryFieldName.Location = new System.Drawing.Point(38, 63);
            this.txtCategoryFieldName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCategoryFieldName.MaxLength = 100;
            this.txtCategoryFieldName.Name = "txtCategoryFieldName";
            this.txtCategoryFieldName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCategoryFieldName.Size = new System.Drawing.Size(316, 22);
            this.txtCategoryFieldName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Field Name";
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.White;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(38, 130);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCategory.MaxLength = 100;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCategory.Size = new System.Drawing.Size(316, 22);
            this.txtCategory.TabIndex = 1;
            this.txtCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(34, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category Name";
            // 
            // tabPrimaryInfo
            // 
            this.tabPrimaryInfo.Controls.Add(this.tabPage1);
            this.tabPrimaryInfo.Controls.Add(this.tabPage2);
            this.tabPrimaryInfo.Controls.Add(this.tabPage3);
            this.tabPrimaryInfo.Controls.Add(this.tabPage4);
            this.tabPrimaryInfo.Controls.Add(this.tabPage5);
            this.tabPrimaryInfo.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.tabPrimaryInfo.Location = new System.Drawing.Point(179, 22);
            this.tabPrimaryInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabPrimaryInfo.Name = "tabPrimaryInfo";
            this.tabPrimaryInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPrimaryInfo.SelectedIndex = 0;
            this.tabPrimaryInfo.Size = new System.Drawing.Size(377, 264);
            this.tabPrimaryInfo.TabIndex = 269;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(213, 288);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 51);
            this.btnClose.TabIndex = 270;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(213, 288);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(156, 51);
            this.btnBack.TabIndex = 271;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PrimaryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(562, 344);
            this.Controls.Add(this.tabPrimaryInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPrimaryInfo);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimaryInfo";
            this.Text = "PrimaryInfo";
            this.Load += new System.EventHandler(this.PrimaryInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimaryInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPrimaryInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.DataGridView dgvPrimaryInfo;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnView;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TextBox txtBranchName;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TextBox txtBankName;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TextBox txtItemPlace;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox txtCompanyFieldName;
        public System.Windows.Forms.TextBox txtCompany;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox txtCategoryFieldName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabControl tabPrimaryInfo;




    }
}