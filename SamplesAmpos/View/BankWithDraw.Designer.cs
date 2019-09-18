namespace BumedianBM.View
{
    partial class BankWithDraw
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
            this.btnNew = new System.Windows.Forms.Button();
            this.txtBankBalance = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblWithdrawDone = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_UName = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtWithdrawDoneBy = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.Txt_ReceiptNo = new System.Windows.Forms.MaskedTextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.grpButtonList = new System.Windows.Forms.GroupBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grpStatus.SuspendLayout();
            this.grpButtonList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(5, 13);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(146, 46);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtBankBalance
            // 
            this.txtBankBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtBankBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankBalance.Location = new System.Drawing.Point(540, 174);
            this.txtBankBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankBalance.MaxLength = 17;
            this.txtBankBalance.Name = "txtBankBalance";
            this.txtBankBalance.ReadOnly = true;
            this.txtBankBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBankBalance.Size = new System.Drawing.Size(128, 21);
            this.txtBankBalance.TabIndex = 411;
            this.txtBankBalance.Text = "0.000";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(5, 65);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 46);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblWithdrawDone
            // 
            this.lblWithdrawDone.AutoSize = true;
            this.lblWithdrawDone.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblWithdrawDone.Location = new System.Drawing.Point(157, 102);
            this.lblWithdrawDone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWithdrawDone.Name = "lblWithdrawDone";
            this.lblWithdrawDone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWithdrawDone.Size = new System.Drawing.Size(133, 19);
            this.lblWithdrawDone.TabIndex = 408;
            this.lblWithdrawDone.Text = "Withdraw done by";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(5, 117);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(146, 46);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(5, 169);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 46);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewYearNo.Location = new System.Drawing.Point(263, 19);
            this.txtNewYearNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.Size = new System.Drawing.Size(113, 22);
            this.txtNewYearNo.TabIndex = 410;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewYearNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewYearNo_KeyPress);
            // 
            // Lbl_UName
            // 
            this.Lbl_UName.AutoSize = true;
            this.Lbl_UName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_UName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Lbl_UName.Location = new System.Drawing.Point(44, 438);
            this.Lbl_UName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_UName.Name = "Lbl_UName";
            this.Lbl_UName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_UName.Size = new System.Drawing.Size(0, 13);
            this.Lbl_UName.TabIndex = 409;
            this.Lbl_UName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(293, 209);
            this.cmbBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(239, 23);
            this.cmbBranch.TabIndex = 393;
            // 
            // lblStatusName
            // 
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(7, 19);
            this.lblStatusName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(125, 35);
            this.lblStatusName.TabIndex = 0;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(293, 172);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(239, 23);
            this.cmbBank.TabIndex = 391;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(293, 137);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.MaxLength = 17;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(83, 21);
            this.txtAmount.TabIndex = 394;
            this.txtAmount.Text = "0.000";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWithdrawDoneBy
            // 
            this.txtWithdrawDoneBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWithdrawDoneBy.Location = new System.Drawing.Point(293, 102);
            this.txtWithdrawDoneBy.Margin = new System.Windows.Forms.Padding(4);
            this.txtWithdrawDoneBy.MaxLength = 100;
            this.txtWithdrawDoneBy.Name = "txtWithdrawDoneBy";
            this.txtWithdrawDoneBy.Size = new System.Drawing.Size(239, 21);
            this.txtWithdrawDoneBy.TabIndex = 390;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(293, 67);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 21);
            this.txtDescription.TabIndex = 389;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(522, 240);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 46);
            this.btnClose.TabIndex = 396;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(11, 19);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(40, 19);
            this.lblDate.TabIndex = 401;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(59, 17);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(135, 21);
            this.dtpDate.TabIndex = 399;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnPrevious.Location = new System.Drawing.Point(209, 8);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(53, 44);
            this.btnPrevious.TabIndex = 397;
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptNo.Location = new System.Drawing.Point(263, 0);
            this.lblReceiptNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(69, 15);
            this.lblReceiptNo.TabIndex = 400;
            this.lblReceiptNo.Text = "Receipt No";
            // 
            // Txt_ReceiptNo
            // 
            this.Txt_ReceiptNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ReceiptNo.Location = new System.Drawing.Point(268, 20);
            this.Txt_ReceiptNo.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_ReceiptNo.Name = "Txt_ReceiptNo";
            this.Txt_ReceiptNo.Size = new System.Drawing.Size(89, 22);
            this.Txt_ReceiptNo.TabIndex = 392;
            this.Txt_ReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNext.Location = new System.Drawing.Point(376, 1);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(53, 58);
            this.btnNext.TabIndex = 398;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(527, 2);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(4);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(4);
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(141, 58);
            this.grpStatus.TabIndex = 407;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(157, 138);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAmount.Size = new System.Drawing.Size(62, 19);
            this.lblAmount.TabIndex = 406;
            this.lblAmount.Text = "Amount";
            // 
            // grpButtonList
            // 
            this.grpButtonList.Controls.Add(this.btnNew);
            this.grpButtonList.Controls.Add(this.btnSave);
            this.grpButtonList.Controls.Add(this.btnPrint);
            this.grpButtonList.Controls.Add(this.btnDelete);
            this.grpButtonList.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.grpButtonList.Location = new System.Drawing.Point(-2, 40);
            this.grpButtonList.Margin = new System.Windows.Forms.Padding(4);
            this.grpButtonList.Name = "grpButtonList";
            this.grpButtonList.Padding = new System.Windows.Forms.Padding(4);
            this.grpButtonList.Size = new System.Drawing.Size(155, 222);
            this.grpButtonList.TabIndex = 395;
            this.grpButtonList.TabStop = false;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblBranch.Location = new System.Drawing.Point(157, 210);
            this.lblBranch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBranch.Size = new System.Drawing.Size(55, 19);
            this.lblBranch.TabIndex = 405;
            this.lblBranch.Text = "Branch";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblBank.Location = new System.Drawing.Point(157, 176);
            this.lblBank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(42, 19);
            this.lblBank.TabIndex = 404;
            this.lblBank.Text = "Bank";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(157, 68);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(85, 19);
            this.lblDescription.TabIndex = 403;
            this.lblDescription.Text = "Description";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(11, 271);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(33, 15);
            this.lblUserName.TabIndex = 402;
            this.lblUserName.Text = "User";
            // 
            // BankWithDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 290);
            this.Controls.Add(this.txtBankBalance);
            this.Controls.Add(this.lblWithdrawDone);
            this.Controls.Add(this.txtNewYearNo);
            this.Controls.Add(this.Lbl_UName);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtWithdrawDoneBy);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.Txt_ReceiptNo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.grpButtonList);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankWithDraw";
            this.Text = "Bank Withdraw";
            this.Load += new System.EventHandler(this.BankWithDraw_Load);
            this.grpStatus.ResumeLayout(false);
            this.grpButtonList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtBankBalance;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblWithdrawDone;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MaskedTextBox txtNewYearNo;
        private System.Windows.Forms.Label Lbl_UName;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblStatusName;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtWithdrawDoneBy;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.MaskedTextBox Txt_ReceiptNo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.GroupBox grpButtonList;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserName;
    }
}