namespace BumedianBM.View
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnNextReciept;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankDeposit));
            this.btnNew = new System.Windows.Forms.Button();
            this.txtBalance1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Lbl_UName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.txtBalance2 = new System.Windows.Forms.TextBox();
            this.grpChooseBankBranch = new System.Windows.Forms.GroupBox();
            this.cmbBranchtoMove = new System.Windows.Forms.ComboBox();
            this.cmbBanktoMove = new System.Windows.Forms.ComboBox();
            this.lblChooseBank = new System.Windows.Forms.Label();
            this.LblChooseBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.blBranch = new System.Windows.Forms.Label();
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
            this.txtReceiptNo = new System.Windows.Forms.MaskedTextBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Lbl_UserName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblU_Name = new System.Windows.Forms.Label();
            btnNextReciept = new System.Windows.Forms.Button();
            this.grpChooseBankBranch.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNextReciept
            // 
            btnNextReciept.FlatAppearance.BorderSize = 0;
            btnNextReciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNextReciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnNextReciept.Image = ((System.Drawing.Image)(resources.GetObject("btnNextReciept.Image")));
            btnNextReciept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            btnNextReciept.Location = new System.Drawing.Point(462, 5);
            btnNextReciept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnNextReciept.Name = "btnNextReciept";
            btnNextReciept.Size = new System.Drawing.Size(53, 59);
            btnNextReciept.TabIndex = 398;
            btnNextReciept.UseVisualStyleBackColor = true;
            btnNextReciept.Click += new System.EventHandler(this.btnNextReciept_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(7, 14);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(158, 51);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.Btn_New_Click);
            // 
            // txtBalance1
            // 
            this.txtBalance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance1.Location = new System.Drawing.Point(627, 204);
            this.txtBalance1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBalance1.MaxLength = 10;
            this.txtBalance1.Name = "txtBalance1";
            this.txtBalance1.Size = new System.Drawing.Size(148, 21);
            this.txtBalance1.TabIndex = 413;
            this.txtBalance1.Text = "0.000";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(7, 65);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 51);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatusName
            // 
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(2, 18);
            this.lblStatusName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(133, 38);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(7, 116);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 51);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // Lbl_UName
            // 
            this.Lbl_UName.AutoSize = true;
            this.Lbl_UName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Lbl_UName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_UName.Location = new System.Drawing.Point(37, 360);
            this.Lbl_UName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_UName.Name = "Lbl_UName";
            this.Lbl_UName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_UName.Size = new System.Drawing.Size(0, 13);
            this.Lbl_UName.TabIndex = 385;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(7, 167);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 51);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewYearNo.Location = new System.Drawing.Point(353, 24);
            this.txtNewYearNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewYearNo.Mask = " ";
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.Size = new System.Drawing.Size(113, 22);
            this.txtNewYearNo.TabIndex = 412;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewYearNo.Visible = false;
            this.txtNewYearNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewYearNo_KeyPress);
            this.txtNewYearNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewYearNo_KeyUp);
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(307, 240);
            this.cmbBranch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(306, 23);
            this.cmbBranch.TabIndex = 393;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            // 
            // txtBalance2
            // 
            this.txtBalance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance2.Location = new System.Drawing.Point(409, 27);
            this.txtBalance2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBalance2.MaxLength = 10;
            this.txtBalance2.Name = "txtBalance2";
            this.txtBalance2.Size = new System.Drawing.Size(148, 21);
            this.txtBalance2.TabIndex = 358;
            this.txtBalance2.Text = "0.000";
            // 
            // grpChooseBankBranch
            // 
            this.grpChooseBankBranch.Controls.Add(this.txtBalance2);
            this.grpChooseBankBranch.Controls.Add(this.cmbBranchtoMove);
            this.grpChooseBankBranch.Controls.Add(this.cmbBanktoMove);
            this.grpChooseBankBranch.Controls.Add(this.lblChooseBank);
            this.grpChooseBankBranch.Controls.Add(this.LblChooseBranch);
            this.grpChooseBankBranch.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.grpChooseBankBranch.Location = new System.Drawing.Point(213, 273);
            this.grpChooseBankBranch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpChooseBankBranch.Name = "grpChooseBankBranch";
            this.grpChooseBankBranch.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpChooseBankBranch.Size = new System.Drawing.Size(562, 102);
            this.grpChooseBankBranch.TabIndex = 394;
            this.grpChooseBankBranch.TabStop = false;
            this.grpChooseBankBranch.Text = "Choose the bank to Move Money From";
            this.grpChooseBankBranch.Visible = false;
            // 
            // cmbBranchtoMove
            // 
            this.cmbBranchtoMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchtoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranchtoMove.FormattingEnabled = true;
            this.cmbBranchtoMove.Location = new System.Drawing.Point(94, 58);
            this.cmbBranchtoMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBranchtoMove.Name = "cmbBranchtoMove";
            this.cmbBranchtoMove.Size = new System.Drawing.Size(306, 23);
            this.cmbBranchtoMove.TabIndex = 1;
            this.cmbBranchtoMove.SelectedIndexChanged += new System.EventHandler(this.cmbBranchtoMove_SelectedIndexChanged);
            // 
            // cmbBanktoMove
            // 
            this.cmbBanktoMove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanktoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBanktoMove.FormattingEnabled = true;
            this.cmbBanktoMove.Location = new System.Drawing.Point(94, 25);
            this.cmbBanktoMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBanktoMove.Name = "cmbBanktoMove";
            this.cmbBanktoMove.Size = new System.Drawing.Size(306, 23);
            this.cmbBanktoMove.TabIndex = 0;
            // 
            // lblChooseBank
            // 
            this.lblChooseBank.AutoSize = true;
            this.lblChooseBank.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblChooseBank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChooseBank.Location = new System.Drawing.Point(32, 26);
            this.lblChooseBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseBank.Name = "lblChooseBank";
            this.lblChooseBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblChooseBank.Size = new System.Drawing.Size(42, 19);
            this.lblChooseBank.TabIndex = 356;
            this.lblChooseBank.Text = "Bank";
            this.lblChooseBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblChooseBranch
            // 
            this.LblChooseBranch.AutoSize = true;
            this.LblChooseBranch.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.LblChooseBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblChooseBranch.Location = new System.Drawing.Point(32, 59);
            this.LblChooseBranch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblChooseBranch.Name = "LblChooseBranch";
            this.LblChooseBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblChooseBranch.Size = new System.Drawing.Size(55, 19);
            this.LblChooseBranch.TabIndex = 357;
            this.LblChooseBranch.Text = "Branch";
            this.LblChooseBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblBank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBank.Location = new System.Drawing.Point(186, 201);
            this.lblBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(46, 19);
            this.lblBank.TabIndex = 409;
            this.lblBank.Text = "Bank ";
            // 
            // cmbReason
            // 
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "Cash Sales",
            "Recieve Amount",
            "Moved to Another Account"});
            this.cmbReason.Location = new System.Drawing.Point(307, 160);
            this.cmbReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(306, 23);
            this.cmbReason.TabIndex = 391;
            this.cmbReason.SelectedIndexChanged += new System.EventHandler(this.cmbReason_SelectedIndexChanged);
            // 
            // blBranch
            // 
            this.blBranch.AutoSize = true;
            this.blBranch.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.blBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.blBranch.Location = new System.Drawing.Point(186, 241);
            this.blBranch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blBranch.Name = "blBranch";
            this.blBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.blBranch.Size = new System.Drawing.Size(55, 19);
            this.blBranch.TabIndex = 410;
            this.blBranch.Text = "Branch";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblReason.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReason.Location = new System.Drawing.Point(186, 161);
            this.lblReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReason.Size = new System.Drawing.Size(57, 19);
            this.lblReason.TabIndex = 407;
            this.lblReason.Text = "Reason";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(307, 200);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(306, 23);
            this.cmbBank.TabIndex = 392;
            // 
            // lblDepositDoneBy
            // 
            this.lblDepositDoneBy.AutoSize = true;
            this.lblDepositDoneBy.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDepositDoneBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDepositDoneBy.Location = new System.Drawing.Point(186, 123);
            this.lblDepositDoneBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepositDoneBy.Name = "lblDepositDoneBy";
            this.lblDepositDoneBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDepositDoneBy.Size = new System.Drawing.Size(119, 19);
            this.lblDepositDoneBy.TabIndex = 408;
            this.lblDepositDoneBy.Text = "Deposit done by";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(627, 121);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(148, 21);
            this.txtAmount.TabIndex = 390;
            this.txtAmount.Text = "0.000";
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // txtDepositDoneBy
            // 
            this.txtDepositDoneBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepositDoneBy.Location = new System.Drawing.Point(307, 122);
            this.txtDepositDoneBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDepositDoneBy.MaxLength = 50;
            this.txtDepositDoneBy.Name = "txtDepositDoneBy";
            this.txtDepositDoneBy.Size = new System.Drawing.Size(306, 21);
            this.txtDepositDoneBy.TabIndex = 389;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(307, 84);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(306, 21);
            this.txtDescription.TabIndex = 388;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(612, 380);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 51);
            this.btnClose.TabIndex = 396;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDate.Location = new System.Drawing.Point(13, 14);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(40, 19);
            this.lblDate.TabIndex = 402;
            this.lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(54, 9);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(137, 21);
            this.dtpDate.TabIndex = 399;
            // 
            // btnPreviousReciept
            // 
            this.btnPreviousReciept.FlatAppearance.BorderSize = 0;
            this.btnPreviousReciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousReciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousReciept.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousReciept.Image")));
            this.btnPreviousReciept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPreviousReciept.Location = new System.Drawing.Point(281, 6);
            this.btnPreviousReciept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreviousReciept.Name = "btnPreviousReciept";
            this.btnPreviousReciept.Size = new System.Drawing.Size(53, 59);
            this.btnPreviousReciept.TabIndex = 397;
            this.btnPreviousReciept.UseVisualStyleBackColor = true;
            this.btnPreviousReciept.Click += new System.EventHandler(this.btnPreviousReciept_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblReceiptNo.Location = new System.Drawing.Point(353, 0);
            this.lblReceiptNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(83, 19);
            this.lblReceiptNo.TabIndex = 401;
            this.lblReceiptNo.Text = "Receipt No";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(353, 25);
            this.txtReceiptNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(113, 22);
            this.txtReceiptNo.TabIndex = 400;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceiptNo.TextChanged += new System.EventHandler(this.txtReceiptNo_TextChanged);
            this.txtReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptNo_KeyPress);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(622, 6);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(141, 73);
            this.grpStatus.TabIndex = 406;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAmount.Location = new System.Drawing.Point(623, 86);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAmount.Size = new System.Drawing.Size(62, 19);
            this.lblAmount.TabIndex = 405;
            this.lblAmount.Text = "Amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 37);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(170, 225);
            this.groupBox2.TabIndex = 395;
            this.groupBox2.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescription.Location = new System.Drawing.Point(186, 86);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(85, 19);
            this.lblDescription.TabIndex = 404;
            this.lblDescription.Text = "Description";
            // 
            // Lbl_UserName
            // 
            this.Lbl_UserName.AutoSize = true;
            this.Lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_UserName.Location = new System.Drawing.Point(24, 511);
            this.Lbl_UserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_UserName.Name = "Lbl_UserName";
            this.Lbl_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_UserName.Size = new System.Drawing.Size(33, 15);
            this.Lbl_UserName.TabIndex = 403;
            this.Lbl_UserName.Text = "User";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(5, 416);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(33, 15);
            this.lblUserName.TabIndex = 414;
            this.lblUserName.Text = "User";
            // 
            // lblU_Name
            // 
            this.lblU_Name.AutoSize = true;
            this.lblU_Name.Location = new System.Drawing.Point(50, 413);
            this.lblU_Name.Name = "lblU_Name";
            this.lblU_Name.Size = new System.Drawing.Size(0, 19);
            this.lblU_Name.TabIndex = 415;
            // 
            // BankDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(775, 435);
            this.Controls.Add(this.lblU_Name);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtBalance1);
            this.Controls.Add(this.Lbl_UName);
            this.Controls.Add(this.txtNewYearNo);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.grpChooseBankBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.blBranch);
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
            this.Controls.Add(this.txtReceiptNo);
            this.Controls.Add(btnNextReciept);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.Lbl_UserName);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Deposit";
            this.Load += new System.EventHandler(this.BankDeposit_Load);
            this.grpChooseBankBranch.ResumeLayout(false);
            this.grpChooseBankBranch.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.TextBox txtBalance1;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lblStatusName;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Label Lbl_UName;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.MaskedTextBox txtNewYearNo;
        public System.Windows.Forms.ComboBox cmbBranch;
        public System.Windows.Forms.TextBox txtBalance2;
        public System.Windows.Forms.GroupBox grpChooseBankBranch;
        public System.Windows.Forms.ComboBox cmbBranchtoMove;
        public System.Windows.Forms.ComboBox cmbBanktoMove;
        public System.Windows.Forms.Label lblChooseBank;
        public System.Windows.Forms.Label LblChooseBranch;
        public System.Windows.Forms.Label lblBank;
        public System.Windows.Forms.ComboBox cmbReason;
        public System.Windows.Forms.Label blBranch;
        public System.Windows.Forms.Label lblReason;
        public System.Windows.Forms.ComboBox cmbBank;
        public System.Windows.Forms.Label lblDepositDoneBy;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.TextBox txtDepositDoneBy;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.Button btnPreviousReciept;
        public System.Windows.Forms.Label lblReceiptNo;
        public System.Windows.Forms.MaskedTextBox txtReceiptNo;
        public System.Windows.Forms.GroupBox grpStatus;
        public System.Windows.Forms.Label lblAmount;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Label Lbl_UserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblU_Name;

    }
}