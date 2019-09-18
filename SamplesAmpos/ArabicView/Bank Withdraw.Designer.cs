namespace BumedianBM.ArabicView
{
    partial class Bank_Withdraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bank_Withdraw));
            this.lblStatusName = new System.Windows.Forms.Label();
            this.txtBankBalance = new System.Windows.Forms.TextBox();
            this.txtNewYear_No = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_UName = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblWithdrawDone = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtWithdrawDoneBy = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.Btn_Previous = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
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
            // lblStatusName
            // 
            this.lblStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStatusName.Location = new System.Drawing.Point(3, 32);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(100, 24);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBankBalance
            // 
            this.txtBankBalance.BackColor = System.Drawing.Color.White;
            this.txtBankBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBankBalance.Location = new System.Drawing.Point(394, 158);
            this.txtBankBalance.MaxLength = 17;
            this.txtBankBalance.Name = "txtBankBalance";
            this.txtBankBalance.ReadOnly = true;
            this.txtBankBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankBalance.Size = new System.Drawing.Size(108, 27);
            this.txtBankBalance.TabIndex = 433;
            this.txtBankBalance.Text = "0.000";
            // 
            // txtNewYear_No
            // 
            this.txtNewYear_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewYear_No.Location = new System.Drawing.Point(210, 32);
            this.txtNewYear_No.Name = "txtNewYear_No";
            this.txtNewYear_No.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewYear_No.Size = new System.Drawing.Size(86, 27);
            this.txtNewYear_No.TabIndex = 412;
            this.txtNewYear_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewYear_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewYear_No_KeyPress);
            this.txtNewYear_No.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewYear_No_KeyUp);
            // 
            // Lbl_UName
            // 
            this.Lbl_UName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_UName.ForeColor = System.Drawing.Color.Tomato;
            this.Lbl_UName.Location = new System.Drawing.Point(101, 287);
            this.Lbl_UName.Name = "Lbl_UName";
            this.Lbl_UName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_UName.Size = new System.Drawing.Size(170, 18);
            this.Lbl_UName.TabIndex = 432;
            this.Lbl_UName.Text = "admin";
            this.Lbl_UName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.DisplayMember = "BranchName";
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(222, 225);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBranch.Size = new System.Drawing.Size(165, 28);
            this.cmbBranch.TabIndex = 3;
            this.cmbBranch.ValueMember = "BranchID";
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.DisplayMember = "BankName";
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(219, 190);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBank.Size = new System.Drawing.Size(168, 28);
            this.cmbBank.TabIndex = 2;
            this.cmbBank.ValueMember = "BankID";
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            this.cmbBank.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyUp);
            // 
            // lblWithdrawDone
            // 
            this.lblWithdrawDone.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblWithdrawDone.Location = new System.Drawing.Point(146, 125);
            this.lblWithdrawDone.Name = "lblWithdrawDone";
            this.lblWithdrawDone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWithdrawDone.Size = new System.Drawing.Size(224, 31);
            this.lblWithdrawDone.TabIndex = 431;
            this.lblWithdrawDone.Tag = "WDDoneBy";
            this.lblWithdrawDone.Text = "تم السحب بواسطة \r\n";
            this.lblWithdrawDone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.MintCream;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(395, 96);
            this.txtAmount.MaxLength = 17;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(108, 27);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.Text = "0.000";
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // txtWithdrawDoneBy
            // 
            this.txtWithdrawDoneBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtWithdrawDoneBy.Location = new System.Drawing.Point(150, 158);
            this.txtWithdrawDoneBy.MaxLength = 100;
            this.txtWithdrawDoneBy.Name = "txtWithdrawDoneBy";
            this.txtWithdrawDoneBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWithdrawDoneBy.Size = new System.Drawing.Size(234, 27);
            this.txtWithdrawDoneBy.TabIndex = 1;
            this.txtWithdrawDoneBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWithdrawDoneBy_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(150, 96);
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
            this.lblDate.Location = new System.Drawing.Point(20, -4);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 423;
            this.lblDate.Text = "التاريخ\r\n";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(18, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(114, 24);
            this.dtpDate.TabIndex = 12;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.FlatAppearance.BorderSize = 0;
            this.Btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Previous.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Previous.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.Btn_Previous.Location = new System.Drawing.Point(159, 26);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Previous.Size = new System.Drawing.Size(40, 40);
            this.Btn_Previous.TabIndex = 10;
            this.Btn_Previous.UseVisualStyleBackColor = true;
            this.Btn_Previous.Click += new System.EventHandler(this.Btn_Previous_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.Location = new System.Drawing.Point(213, -2);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(81, 31);
            this.lblReceiptNo.TabIndex = 422;
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            this.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReceiptNo.Location = new System.Drawing.Point(210, 33);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiptNo.Size = new System.Drawing.Size(86, 27);
            this.txtReceiptNo.TabIndex = 418;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNo_KeyPress);
            // 
            // Btn_Next
            // 
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Next.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.Btn_Next.Location = new System.Drawing.Point(304, 26);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Next.Size = new System.Drawing.Size(40, 40);
            this.Btn_Next.TabIndex = 11;
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_Next_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(394, 7);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(106, 59);
            this.grpStatus.TabIndex = 429;
            this.grpStatus.TabStop = false;
            this.grpStatus.Tag = "Status";
            this.grpStatus.Text = "الحالة\r\n";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(394, 62);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAmount.Size = new System.Drawing.Size(108, 31);
            this.lblAmount.TabIndex = 428;
            this.lblAmount.Text = "القيمة\r\n";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBranch.Location = new System.Drawing.Point(150, 227);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBranch.Size = new System.Drawing.Size(42, 31);
            this.lblBranch.TabIndex = 427;
            this.lblBranch.Text = "الفرع\r\n";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBank.Location = new System.Drawing.Point(150, 193);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(63, 31);
            this.lblBank.TabIndex = 426;
            this.lblBank.Text = "المصرف\r\n";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(146, 62);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(221, 31);
            this.lblDescription.TabIndex = 425;
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(12, 283);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(83, 26);
            this.lblUserName.TabIndex = 424;
            this.lblUserName.Text = "اسم المستخدم \r\n";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(4, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(137, 202);
            this.groupBox2.TabIndex = 5;
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
            this.btnNew.Location = new System.Drawing.Point(8, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 40);
            this.btnNew.TabIndex = 7;
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
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(9, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 6;
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
            this.btnPrint.Location = new System.Drawing.Point(8, 111);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 40);
            this.btnPrint.TabIndex = 8;
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
            this.btnDelete.Location = new System.Drawing.Point(8, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(121, 40);
            this.btnDelete.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(372, 269);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(121, 40);
            this.btnClose.TabIndex = 13;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Bank_Withdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(505, 315);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtBankBalance);
            this.Controls.Add(this.Lbl_UName);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.lblWithdrawDone);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtWithdrawDoneBy);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.Btn_Previous);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtNewYear_No);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Bank_Withdraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Bank Withdraw";
            this.Text = "Bank Withdraw";
            this.Load += new System.EventHandler(this.Bank_Withdraw_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bank_Withdraw_KeyDown);
            this.grpStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatusName;
        private System.Windows.Forms.TextBox txtBankBalance;
        private System.Windows.Forms.MaskedTextBox txtNewYear_No;
        private System.Windows.Forms.Label Lbl_UName;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblWithdrawDone;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtWithdrawDoneBy;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button Btn_Previous;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.MaskedTextBox txtReceiptNo;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}