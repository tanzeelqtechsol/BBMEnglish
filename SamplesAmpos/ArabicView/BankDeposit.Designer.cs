namespace BumedianBM.ArabicView
{
    partial class BankDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankDeposit));
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.lbl_UName = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.grpChooseBankBranch = new System.Windows.Forms.GroupBox();
            this.cmb_BanktoMove = new System.Windows.Forms.ComboBox();
            this.txtBalance2 = new System.Windows.Forms.TextBox();
            this.cmb_BranchtoMove = new System.Windows.Forms.ComboBox();
            this.lbl_Bank = new System.Windows.Forms.Label();
            this.Lbl_Branch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblDepositDoneBy = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtDepositDoneBy = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPreviousReciept = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.btnNextReciept = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtBalance1 = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.grpChooseBankBranch.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewYearNo.Location = new System.Drawing.Point(250, 28);
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewYearNo.Size = new System.Drawing.Size(86, 27);
            this.txtNewYearNo.TabIndex = 436;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewYearNo.Visible = false;
            this.txtNewYearNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewYearNo_KeyPress);
            this.txtNewYearNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewYearNo_KeyUp);
            // 
            // lbl_UName
            // 
            this.lbl_UName.AutoSize = true;
            this.lbl_UName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_UName.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_UName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_UName.Location = new System.Drawing.Point(216, 383);
            this.lbl_UName.Name = "lbl_UName";
            this.lbl_UName.Size = new System.Drawing.Size(62, 31);
            this.lbl_UName.TabIndex = 435;
            this.lbl_UName.Text = "admin";
            // 
            // cmbBranch
            // 
            this.cmbBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(270, 231);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBranch.Size = new System.Drawing.Size(225, 28);
            this.cmbBranch.TabIndex = 5;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranch_KeyDown);
            // 
            // grpChooseBankBranch
            // 
            this.grpChooseBankBranch.Controls.Add(this.cmb_BanktoMove);
            this.grpChooseBankBranch.Controls.Add(this.txtBalance2);
            this.grpChooseBankBranch.Controls.Add(this.cmb_BranchtoMove);
            this.grpChooseBankBranch.Controls.Add(this.lbl_Bank);
            this.grpChooseBankBranch.Controls.Add(this.Lbl_Branch);
            this.grpChooseBankBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpChooseBankBranch.Location = new System.Drawing.Point(147, 266);
            this.grpChooseBankBranch.Name = "grpChooseBankBranch";
            this.grpChooseBankBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpChooseBankBranch.Size = new System.Drawing.Size(471, 114);
            this.grpChooseBankBranch.TabIndex = 6;
            this.grpChooseBankBranch.TabStop = false;
            this.grpChooseBankBranch.Tag = "ChoBankBranch";
            this.grpChooseBankBranch.Text = "رجاء! اختر المصرف لتحويل المال منه";
            this.grpChooseBankBranch.Visible = false;
            // 
            // cmb_BanktoMove
            // 
            this.cmb_BanktoMove.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_BanktoMove.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_BanktoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_BanktoMove.FormattingEnabled = true;
            this.cmb_BanktoMove.Location = new System.Drawing.Point(123, 34);
            this.cmb_BanktoMove.Name = "cmb_BanktoMove";
            this.cmb_BanktoMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_BanktoMove.Size = new System.Drawing.Size(225, 28);
            this.cmb_BanktoMove.TabIndex = 439;
            this.cmb_BanktoMove.SelectedIndexChanged += new System.EventHandler(this.cmbBanktoMove_SelectedIndexChanged);
            this.cmb_BanktoMove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBanktoMove_KeyDown);
            // 
            // txtBalance2
            // 
            this.txtBalance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBalance2.Location = new System.Drawing.Point(355, 32);
            this.txtBalance2.MaxLength = 10;
            this.txtBalance2.Name = "txtBalance2";
            this.txtBalance2.ReadOnly = true;
            this.txtBalance2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance2.Size = new System.Drawing.Size(114, 27);
            this.txtBalance2.TabIndex = 438;
            this.txtBalance2.Text = "0.000";
            // 
            // cmb_BranchtoMove
            // 
            this.cmb_BranchtoMove.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_BranchtoMove.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_BranchtoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_BranchtoMove.FormattingEnabled = true;
            this.cmb_BranchtoMove.Location = new System.Drawing.Point(123, 78);
            this.cmb_BranchtoMove.Name = "cmb_BranchtoMove";
            this.cmb_BranchtoMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_BranchtoMove.Size = new System.Drawing.Size(225, 28);
            this.cmb_BranchtoMove.TabIndex = 1523;
            this.cmb_BranchtoMove.SelectedIndexChanged += new System.EventHandler(this.cmbBranchtoMove_SelectedIndexChanged);
            this.cmb_BranchtoMove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBranchtoMove_KeyDown);
            // 
            // lbl_Bank
            // 
            this.lbl_Bank.AutoSize = true;
            this.lbl_Bank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Bank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Bank.Location = new System.Drawing.Point(2, 31);
            this.lbl_Bank.Name = "lbl_Bank";
            this.lbl_Bank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Bank.Size = new System.Drawing.Size(63, 31);
            this.lbl_Bank.TabIndex = 356;
            this.lbl_Bank.Text = "المصرف\r\n";
            this.lbl_Bank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_Branch
            // 
            this.Lbl_Branch.AutoSize = true;
            this.Lbl_Branch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl_Branch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_Branch.Location = new System.Drawing.Point(3, 78);
            this.Lbl_Branch.Name = "Lbl_Branch";
            this.Lbl_Branch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Branch.Size = new System.Drawing.Size(42, 31);
            this.Lbl_Branch.TabIndex = 357;
            this.Lbl_Branch.Text = "الفرع\r\n";
            this.Lbl_Branch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBank.Location = new System.Drawing.Point(147, 191);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(63, 31);
            this.lblBank.TabIndex = 432;
            this.lblBank.Tag = "Bank";
            this.lblBank.Text = "المصرف\r\n";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbReason
            // 
            this.cmbReason.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReason.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReason.DropDownWidth = 350;
            this.cmbReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(271, 150);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbReason.Size = new System.Drawing.Size(346, 28);
            this.cmbReason.TabIndex = 3;
            this.cmbReason.SelectedIndexChanged += new System.EventHandler(this.cmbReason_SelectedIndexChanged);
            this.cmbReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbReason_KeyDown);
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBranch.Location = new System.Drawing.Point(147, 231);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBranch.Size = new System.Drawing.Size(42, 31);
            this.lblBranch.TabIndex = 433;
            this.lblBranch.Tag = "Branch";
            this.lblBranch.Text = "الفرع\r\n";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReason.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReason.Location = new System.Drawing.Point(147, 150);
            this.lblReason.Name = "lblReason";
            this.lblReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReason.Size = new System.Drawing.Size(50, 31);
            this.lblReason.TabIndex = 430;
            this.lblReason.Tag = "Reason";
            this.lblReason.Text = "السبب\r\n";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBank
            // 
            this.cmbBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(270, 191);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBank.Size = new System.Drawing.Size(225, 28);
            this.cmbBank.TabIndex = 4;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            // 
            // lblDepositDoneBy
            // 
            this.lblDepositDoneBy.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDepositDoneBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDepositDoneBy.Location = new System.Drawing.Point(146, 111);
            this.lblDepositDoneBy.Name = "lblDepositDoneBy";
            this.lblDepositDoneBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDepositDoneBy.Size = new System.Drawing.Size(120, 29);
            this.lblDepositDoneBy.TabIndex = 431;
            this.lblDepositDoneBy.Tag = "DepoDoneBy";
            this.lblDepositDoneBy.Text = "تم الايداع بواسطة\r\n";
            this.lblDepositDoneBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.MintCream;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(502, 111);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(114, 27);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "0.000";
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // txtDepositDoneBy
            // 
            this.txtDepositDoneBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDepositDoneBy.Location = new System.Drawing.Point(271, 112);
            this.txtDepositDoneBy.MaxLength = 50;
            this.txtDepositDoneBy.Name = "txtDepositDoneBy";
            this.txtDepositDoneBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDepositDoneBy.Size = new System.Drawing.Size(225, 27);
            this.txtDepositDoneBy.TabIndex = 1;
            this.txtDepositDoneBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepositDoneBy_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(271, 71);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.Size = new System.Drawing.Size(225, 27);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(495, 381);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(121, 41);
            this.btnClose.TabIndex = 15;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDate.Location = new System.Drawing.Point(7, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 423;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(57, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(118, 26);
            this.dtpDate.TabIndex = 14;
            // 
            // btnPreviousReciept
            // 
            this.btnPreviousReciept.FlatAppearance.BorderSize = 0;
            this.btnPreviousReciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousReciept.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPreviousReciept.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnPreviousReciept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousReciept.Location = new System.Drawing.Point(197, 19);
            this.btnPreviousReciept.Name = "btnPreviousReciept";
            this.btnPreviousReciept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPreviousReciept.Size = new System.Drawing.Size(40, 41);
            this.btnPreviousReciept.TabIndex = 12;
            this.btnPreviousReciept.UseVisualStyleBackColor = true;
            this.btnPreviousReciept.Click += new System.EventHandler(this.btnPreviousReciept_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReceiptNo.Location = new System.Drawing.Point(254, -4);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(81, 31);
            this.lblReceiptNo.TabIndex = 420;
            this.lblReceiptNo.Tag = "ReceiptNo";
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            // 
            // btnNextReciept
            // 
            this.btnNextReciept.FlatAppearance.BorderSize = 0;
            this.btnNextReciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextReciept.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNextReciept.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNextReciept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNextReciept.Location = new System.Drawing.Point(350, 19);
            this.btnNextReciept.Name = "btnNextReciept";
            this.btnNextReciept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNextReciept.Size = new System.Drawing.Size(39, 41);
            this.btnNextReciept.TabIndex = 13;
            this.btnNextReciept.UseVisualStyleBackColor = true;
            this.btnNextReciept.Click += new System.EventHandler(this.btnNextReciept_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(498, 5);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(123, 61);
            this.grpStatus.TabIndex = 428;
            this.grpStatus.TabStop = false;
            this.grpStatus.Tag = "Status";
            this.grpStatus.Text = "الحالة\r\n";
            // 
            // lblStatusName
            // 
            this.lblStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(3, 32);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(117, 26);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAmount.Location = new System.Drawing.Point(502, 71);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAmount.Size = new System.Drawing.Size(89, 32);
            this.lblAmount.TabIndex = 427;
            this.lblAmount.Tag = "Amount";
            this.lblAmount.Text = "القيمة\r\n";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(140, 201);
            this.groupBox2.TabIndex = 7;
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
            this.btnNew.Location = new System.Drawing.Point(12, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 41);
            this.btnNew.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(12, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.TabIndex = 8;
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
            this.btnPrint.Location = new System.Drawing.Point(12, 108);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 41);
            this.btnPrint.TabIndex = 10;
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
            this.btnDelete.Location = new System.Drawing.Point(12, 151);
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
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(147, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(46, 31);
            this.lblDescription.TabIndex = 426;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserName.Location = new System.Drawing.Point(19, 383);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(99, 31);
            this.lblUserName.TabIndex = 425;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "اسم المستخدم \r\n";
            // 
            // txtBalance1
            // 
            this.txtBalance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBalance1.Location = new System.Drawing.Point(504, 190);
            this.txtBalance1.MaxLength = 10;
            this.txtBalance1.Name = "txtBalance1";
            this.txtBalance1.ReadOnly = true;
            this.txtBalance1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance1.Size = new System.Drawing.Size(114, 27);
            this.txtBalance1.TabIndex = 437;
            this.txtBalance1.Text = "0.000";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReceiptNo.Location = new System.Drawing.Point(251, 27);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(86, 27);
            this.txtReceiptNo.TabIndex = 438;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNo_KeyPress);
            // 
            // BankDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(625, 425);
            this.Controls.Add(this.txtBalance1);
            this.Controls.Add(this.lbl_UName);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.grpChooseBankBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.lblDepositDoneBy);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtDepositDoneBy);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnPreviousReciept);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.btnNextReciept);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(this.txtNewYearNo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "BankDeposit";
            this.Text = "Bank Deposit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BankDeposit_FormClosed);
            this.Load += new System.EventHandler(this.BankDeposit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BankDeposit_KeyDown);
            this.grpChooseBankBranch.ResumeLayout(false);
            this.grpChooseBankBranch.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox txtNewYearNo;
        public System.Windows.Forms.Label lbl_UName;
        public System.Windows.Forms.ComboBox cmbBranch;
        public System.Windows.Forms.GroupBox grpChooseBankBranch;
        public System.Windows.Forms.ComboBox cmbReason;
        public System.Windows.Forms.ComboBox cmbBank;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.TextBox txtDepositDoneBy;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.Label lblReceiptNo;
        public System.Windows.Forms.GroupBox grpStatus;
        public System.Windows.Forms.Label lblAmount;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cmb_BranchtoMove;
        public System.Windows.Forms.Label lbl_Bank;
        public System.Windows.Forms.Label Lbl_Branch;
        public System.Windows.Forms.Label lblBank;
        public System.Windows.Forms.Label lblBranch;
        public System.Windows.Forms.Label lblReason;
        public System.Windows.Forms.Label lblDepositDoneBy;
        public System.Windows.Forms.Button btnPreviousReciept;
        public System.Windows.Forms.Button btnNextReciept;
        public System.Windows.Forms.Label lblStatusName;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.TextBox txtBalance1;
        public System.Windows.Forms.TextBox txtBalance2;
        private System.Windows.Forms.TextBox txtReceiptNo;
        public System.Windows.Forms.ComboBox cmb_BanktoMove;

    }
}