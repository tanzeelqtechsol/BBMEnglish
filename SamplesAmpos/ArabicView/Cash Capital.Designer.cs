namespace BumedianBM.ArabicView
{
    partial class frmCashCapital
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashCapital));
            this.radBank = new System.Windows.Forms.RadioButton();
            this.radCash = new System.Windows.Forms.RadioButton();
            this.lblUName = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radBank
            // 
            this.radBank.AutoSize = true;
            this.radBank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.radBank.Location = new System.Drawing.Point(223, 206);
            this.radBank.Name = "radBank";
            this.radBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radBank.Size = new System.Drawing.Size(81, 35);
            this.radBank.TabIndex = 6;
            this.radBank.Text = "المصرف\r\n";
            this.radBank.UseVisualStyleBackColor = true;
            this.radBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radBank_KeyPress);
            // 
            // radCash
            // 
            this.radCash.AutoSize = true;
            this.radCash.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.radCash.Location = new System.Drawing.Point(145, 206);
            this.radCash.Name = "radCash";
            this.radCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radCash.Size = new System.Drawing.Size(53, 35);
            this.radCash.TabIndex = 7;
            this.radCash.Tag = "Cash";
            this.radCash.Text = "تقدا\r\n";
            this.radCash.UseVisualStyleBackColor = true;
            this.radCash.CheckedChanged += new System.EventHandler(this.radCash_CheckedChanged);
            this.radCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radCash_KeyPress);
            // 
            // lblUName
            // 
            this.lblUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUName.ForeColor = System.Drawing.Color.Blue;
            this.lblUName.Location = new System.Drawing.Point(126, 334);
            this.lblUName.Name = "lblUName";
            this.lblUName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUName.Size = new System.Drawing.Size(229, 18);
            this.lblUName.TabIndex = 459;
            this.lblUName.Text = "admin";
            this.lblUName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(223, 289);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBranch.Size = new System.Drawing.Size(176, 28);
            this.cmbBranch.TabIndex = 5;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(223, 247);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBank.Size = new System.Drawing.Size(176, 28);
            this.cmbBank.TabIndex = 4;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            // 
            // lblNotes
            // 
            this.lblNotes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNotes.Location = new System.Drawing.Point(142, 138);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNotes.Size = new System.Drawing.Size(56, 31);
            this.lblNotes.TabIndex = 458;
            this.lblNotes.Tag = "Notes";
            this.lblNotes.Text = "ملاحظة\r\n";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.MintCream;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(386, 107);
            this.txtAmount.MaxLength = 17;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(94, 27);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(145, 107);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.Size = new System.Drawing.Size(231, 27);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(7, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 450;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(9, 34);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(118, 26);
            this.dtpDate.TabIndex = 15;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnPrevious.Location = new System.Drawing.Point(155, 27);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrevious.Size = new System.Drawing.Size(40, 41);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.Location = new System.Drawing.Point(190, 2);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(93, 30);
            this.lblReceiptNo.TabIndex = 448;
            this.lblReceiptNo.Tag = "ReceiptNo";
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNext.Location = new System.Drawing.Point(284, 26);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNext.Size = new System.Drawing.Size(40, 41);
            this.btnNext.TabIndex = 14;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(376, 6);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(106, 68);
            this.grpStatus.TabIndex = 456;
            this.grpStatus.TabStop = false;
            this.grpStatus.Tag = "Status";
            this.grpStatus.Text = "الحالة\r\n";
            // 
            // lblStatusName
            // 
            this.lblStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(3, 32);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(100, 33);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(381, 81);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAmount.Size = new System.Drawing.Size(98, 30);
            this.lblAmount.TabIndex = 455;
            this.lblAmount.Tag = "Amount";
            this.lblAmount.Text = "القيمة\r\n";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBranch.Location = new System.Drawing.Point(145, 289);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBranch.Size = new System.Drawing.Size(33, 31);
            this.lblBranch.TabIndex = 454;
            this.lblBranch.Text = "فرع\r\n";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBank.Location = new System.Drawing.Point(145, 244);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(63, 31);
            this.lblBank.TabIndex = 453;
            this.lblBank.Text = "المصرف\r\n";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(139, 77);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(132, 30);
            this.lblDescription.TabIndex = 452;
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(15, 328);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(93, 31);
            this.lblUserName.TabIndex = 451;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "اسم المستخدم \r\n";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNotes.Location = new System.Drawing.Point(145, 169);
            this.txtNotes.MaxLength = 100;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNotes.Size = new System.Drawing.Size(231, 27);
            this.txtNotes.TabIndex = 2;
            this.txtNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotes_KeyPress);
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewYearNo.Location = new System.Drawing.Point(196, 36);
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewYearNo.Size = new System.Drawing.Size(86, 27);
            this.txtNewYearNo.TabIndex = 437;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReceiptNo.Location = new System.Drawing.Point(196, 36);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiptNo.Size = new System.Drawing.Size(86, 27);
            this.txtReceiptNo.TabIndex = 16;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNo_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(4, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(131, 222);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(5, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 41);
            this.btnNew.TabIndex = 6;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد\r\n";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnNew_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(5, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.TabIndex = 4;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ\r\n";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(5, 123);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 41);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(5, 170);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(121, 41);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(361, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(121, 40);
            this.btnClose.TabIndex = 17;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCashCapital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(486, 365);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radBank);
            this.Controls.Add(this.radCash);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtNewYearNo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashCapital";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Cash Capital";
            this.Text = "Cash Capital";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCashCapital_FormClosed);
            this.Load += new System.EventHandler(this.Cash_Capital_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCashCapital_KeyDown);
            this.grpStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radBank;
        private System.Windows.Forms.RadioButton radCash;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblStatusName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.MaskedTextBox txtNewYearNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;

    }
}