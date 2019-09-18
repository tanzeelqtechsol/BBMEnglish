namespace BumedianBM.ArabicView
{
    partial class Receive_Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receive_Receipt));
            this.Txt_NewYear_No = new System.Windows.Forms.MaskedTextBox();
            this.Cmb_ReceivedFrom = new System.Windows.Forms.ComboBox();
            this.MTxt_Discription = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_User = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.Txt_Reason = new System.Windows.Forms.MaskedTextBox();
            this.cmb_branch = new System.Windows.Forms.ComboBox();
            this.cmb_bank = new System.Windows.Forms.ComboBox();
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.MTxt_Balance = new System.Windows.Forms.MaskedTextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.MTxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.lblReceivedFrom = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.Dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.button_decrease = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.txt_receipt_no = new System.Windows.Forms.MaskedTextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrintPreview = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkCard = new System.Windows.Forms.CheckBox();
            this.grbStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_NewYear_No
            // 
            this.Txt_NewYear_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Txt_NewYear_No.Location = new System.Drawing.Point(256, 29);
            this.Txt_NewYear_No.Name = "Txt_NewYear_No";
            this.Txt_NewYear_No.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_NewYear_No.Size = new System.Drawing.Size(86, 27);
            this.Txt_NewYear_No.TabIndex = 420;
            this.Txt_NewYear_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_NewYear_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_NewYear_No_KeyPress);
            // 
            // Cmb_ReceivedFrom
            // 
            this.Cmb_ReceivedFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_ReceivedFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_ReceivedFrom.DropDownHeight = 400;
            this.Cmb_ReceivedFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_ReceivedFrom.FormattingEnabled = true;
            this.Cmb_ReceivedFrom.IntegralHeight = false;
            this.Cmb_ReceivedFrom.Location = new System.Drawing.Point(244, 81);
            this.Cmb_ReceivedFrom.Name = "Cmb_ReceivedFrom";
            this.Cmb_ReceivedFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cmb_ReceivedFrom.Size = new System.Drawing.Size(231, 28);
            this.Cmb_ReceivedFrom.TabIndex = 0;
            this.Cmb_ReceivedFrom.SelectedIndexChanged += new System.EventHandler(this.Cmb_ReceivedFrom_SelectedIndexChanged);
            this.Cmb_ReceivedFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_ReceivedFrom_KeyDown);
            // 
            // MTxt_Discription
            // 
            this.MTxt_Discription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Discription.Location = new System.Drawing.Point(244, 115);
            this.MTxt_Discription.Name = "MTxt_Discription";
            this.MTxt_Discription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTxt_Discription.Size = new System.Drawing.Size(231, 27);
            this.MTxt_Discription.TabIndex = 1;
            this.MTxt_Discription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTxt_Discription_KeyDown);
            // 
            // Lbl_User
            // 
            this.Lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_User.ForeColor = System.Drawing.Color.Tomato;
            this.Lbl_User.Location = new System.Drawing.Point(118, 349);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_User.Size = new System.Drawing.Size(266, 23);
            this.Lbl_User.TabIndex = 419;
            this.Lbl_User.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_User.Click += new System.EventHandler(this.Lbl_User_Click);
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNote.Location = new System.Drawing.Point(142, 186);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNote.Size = new System.Drawing.Size(80, 31);
            this.lblNote.TabIndex = 418;
            this.lblNote.Tag = "Note";
            this.lblNote.Text = "ملاحظة\r\n";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txt_Reason
            // 
            this.Txt_Reason.BackColor = System.Drawing.SystemColors.Info;
            this.Txt_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Txt_Reason.Location = new System.Drawing.Point(242, 187);
            this.Txt_Reason.Name = "Txt_Reason";
            this.Txt_Reason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Reason.Size = new System.Drawing.Size(231, 27);
            this.Txt_Reason.TabIndex = 3;
            this.Txt_Reason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTxt_Discription_KeyDown);
            // 
            // cmb_branch
            // 
            this.cmb_branch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_branch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_branch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_branch.FormattingEnabled = true;
            this.cmb_branch.Location = new System.Drawing.Point(233, 307);
            this.cmb_branch.Name = "cmb_branch";
            this.cmb_branch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_branch.Size = new System.Drawing.Size(231, 28);
            this.cmb_branch.TabIndex = 7;
            this.cmb_branch.Visible = false;
            this.cmb_branch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_branch_KeyDown);
            // 
            // cmb_bank
            // 
            this.cmb_bank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_bank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_bank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmb_bank.FormattingEnabled = true;
            this.cmb_bank.Location = new System.Drawing.Point(233, 266);
            this.cmb_bank.Name = "cmb_bank";
            this.cmb_bank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_bank.Size = new System.Drawing.Size(231, 28);
            this.cmb_bank.TabIndex = 6;
            this.cmb_bank.Visible = false;
            this.cmb_bank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_bank_KeyDown);
            // 
            // grbStatus
            // 
            this.grbStatus.Controls.Add(this.lblStatus);
            this.grbStatus.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grbStatus.Location = new System.Drawing.Point(468, -1);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbStatus.Size = new System.Drawing.Size(106, 57);
            this.grbStatus.TabIndex = 417;
            this.grbStatus.TabStop = false;
            this.grbStatus.Tag = "Status";
            this.grbStatus.Text = "الحالة\r\n";
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblStatus.Location = new System.Drawing.Point(3, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(100, 22);
            this.lblStatus.TabIndex = 250;
            this.lblStatus.Text = "a";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(473, 50);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(95, 31);
            this.lblBalance.TabIndex = 416;
            this.lblBalance.Tag = "Balance";
            this.lblBalance.Text = "الرصيد\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTxt_Balance
            // 
            this.MTxt_Balance.BackColor = System.Drawing.SystemColors.Info;
            this.MTxt_Balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Balance.Location = new System.Drawing.Point(478, 81);
            this.MTxt_Balance.Name = "MTxt_Balance";
            this.MTxt_Balance.ReadOnly = true;
            this.MTxt_Balance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTxt_Balance.Size = new System.Drawing.Size(107, 27);
            this.MTxt_Balance.TabIndex = 415;
            this.MTxt_Balance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MTxt_Balance_KeyDown);
            // 
            // lblBranch
            // 
            this.lblBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBranch.Location = new System.Drawing.Point(160, 304);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBranch.Size = new System.Drawing.Size(75, 31);
            this.lblBranch.TabIndex = 414;
            this.lblBranch.Tag = "Branch";
            this.lblBranch.Text = "فرع\r\n";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBranch.Visible = false;
            // 
            // lblBank
            // 
            this.lblBank.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBank.Location = new System.Drawing.Point(159, 266);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(105, 31);
            this.lblBank.TabIndex = 413;
            this.lblBank.Tag = "Bank";
            this.lblBank.Text = "المصرف\r\n";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBank.Visible = false;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethod.Location = new System.Drawing.Point(83, 220);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPaymentMethod.Size = new System.Drawing.Size(179, 31);
            this.lblPaymentMethod.TabIndex = 412;
            this.lblPaymentMethod.Tag = "PayMethod";
            this.lblPaymentMethod.Text = "طريقة الدفع\r\n";
            this.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCheck
            // 
            this.chkCheck.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkCheck.Location = new System.Drawing.Point(454, 220);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCheck.Size = new System.Drawing.Size(114, 35);
            this.chkCheck.TabIndex = 5;
            this.chkCheck.Text = "صك\r\n";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            this.chkCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCheck_KeyDown);
            // 
            // chkCash
            // 
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkCash.Location = new System.Drawing.Point(271, 220);
            this.chkCash.Name = "chkCash";
            this.chkCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCash.Size = new System.Drawing.Size(78, 35);
            this.chkCash.TabIndex = 4;
            this.chkCash.Text = "نقد\r\n";
            this.chkCash.UseVisualStyleBackColor = true;
            this.chkCash.CheckedChanged += new System.EventHandler(this.chkCash_CheckedChanged);
            this.chkCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCash_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(141, 112);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(148, 31);
            this.lblDescription.TabIndex = 411;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(6, 345);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(106, 31);
            this.lblUserName.TabIndex = 410;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "اسم المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(142, 148);
            this.lblValue.Name = "lblValue";
            this.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue.Size = new System.Drawing.Size(80, 31);
            this.lblValue.TabIndex = 409;
            this.lblValue.Tag = "Value";
            this.lblValue.Text = "قيمة\r\n";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTxt_Value
            // 
            this.MTxt_Value.BackColor = System.Drawing.Color.MintCream;
            this.MTxt_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Value.Location = new System.Drawing.Point(244, 148);
            this.MTxt_Value.Name = "MTxt_Value";
            this.MTxt_Value.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTxt_Value.Size = new System.Drawing.Size(231, 27);
            this.MTxt_Value.TabIndex = 2;
            this.MTxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MTxt_Value_KeyPress);
            this.MTxt_Value.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MTxt_Value_KeyUp);
            // 
            // lblReceivedFrom
            // 
            this.lblReceivedFrom.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceivedFrom.Location = new System.Drawing.Point(141, 81);
            this.lblReceivedFrom.Name = "lblReceivedFrom";
            this.lblReceivedFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReceivedFrom.Size = new System.Drawing.Size(136, 31);
            this.lblReceivedFrom.TabIndex = 408;
            this.lblReceivedFrom.Tag = "ReceiveFrom";
            this.lblReceivedFrom.Text = "استلم من\r\n";
            this.lblReceivedFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(1, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 407;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            // 
            // Dtp_Date
            // 
            this.Dtp_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Date.Location = new System.Drawing.Point(56, 26);
            this.Dtp_Date.Name = "Dtp_Date";
            this.Dtp_Date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_Date.Size = new System.Drawing.Size(122, 26);
            this.Dtp_Date.TabIndex = 406;
            // 
            // button_decrease
            // 
            this.button_decrease.FlatAppearance.BorderSize = 0;
            this.button_decrease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_decrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_decrease.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.button_decrease.Location = new System.Drawing.Point(215, 26);
            this.button_decrease.Name = "button_decrease";
            this.button_decrease.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_decrease.Size = new System.Drawing.Size(35, 35);
            this.button_decrease.TabIndex = 405;
            this.button_decrease.UseVisualStyleBackColor = true;
            this.button_decrease.Click += new System.EventHandler(this.button_decrease_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.Location = new System.Drawing.Point(258, -2);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(81, 31);
            this.lblReceiptNo.TabIndex = 404;
            this.lblReceiptNo.Tag = "ReceiptNo";
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            // 
            // txt_receipt_no
            // 
            this.txt_receipt_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txt_receipt_no.Location = new System.Drawing.Point(264, 29);
            this.txt_receipt_no.Name = "txt_receipt_no";
            this.txt_receipt_no.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_receipt_no.Size = new System.Drawing.Size(73, 27);
            this.txt_receipt_no.TabIndex = 403;
            this.txt_receipt_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNext.Location = new System.Drawing.Point(348, 29);
            this.btnNext.Name = "btnNext";
            this.btnNext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNext.Size = new System.Drawing.Size(31, 29);
            this.btnNext.TabIndex = 402;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(455, 340);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(121, 40);
            this.btnClose.TabIndex = 463;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrintPreview);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(6, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(130, 248);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // chkPrintPreview
            // 
            this.chkPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPrintPreview.Location = new System.Drawing.Point(3, 208);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPreview.Size = new System.Drawing.Size(122, 26);
            this.chkPrintPreview.TabIndex = 263;
            this.chkPrintPreview.Tag = "PP";
            this.chkPrintPreview.Text = "معاينة قبل الطباعة";
            this.chkPrintPreview.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(4, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 40);
            this.btnNew.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(4, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 0;
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
            this.btnPrint.Location = new System.Drawing.Point(4, 114);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 40);
            this.btnPrint.TabIndex = 2;
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
            this.btnDelete.Location = new System.Drawing.Point(4, 162);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(121, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء\r\n";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkCard
            // 
            this.chkCard.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkCard.Location = new System.Drawing.Point(367, 220);
            this.chkCard.Name = "chkCard";
            this.chkCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCard.Size = new System.Drawing.Size(85, 35);
            this.chkCard.TabIndex = 464;
            this.chkCard.Text = "بطاقة";
            this.chkCard.UseVisualStyleBackColor = true;
            this.chkCard.CheckedChanged += new System.EventHandler(this.chkCard_CheckedChanged);
            // 
            // Receive_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(599, 440);
            this.Controls.Add(this.chkCard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Txt_NewYear_No);
            this.Controls.Add(this.Cmb_ReceivedFrom);
            this.Controls.Add(this.MTxt_Discription);
            this.Controls.Add(this.Lbl_User);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.Txt_Reason);
            this.Controls.Add(this.cmb_branch);
            this.Controls.Add(this.cmb_bank);
            this.Controls.Add(this.grbStatus);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.MTxt_Balance);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.MTxt_Value);
            this.Controls.Add(this.lblReceivedFrom);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Dtp_Date);
            this.Controls.Add(this.button_decrease);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.txt_receipt_no);
            this.Controls.Add(this.btnNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Receive_Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "ReceiveReceipt";
            this.Text = "Receive Receipt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receive_Receipt_FormClosing);
            this.Load += new System.EventHandler(this.Receive_Receipt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recive_Recipt_KeyDown);
            this.grbStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox Txt_NewYear_No;
        public System.Windows.Forms.ComboBox Cmb_ReceivedFrom;
        public System.Windows.Forms.MaskedTextBox MTxt_Discription;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.Label lblNote;
        public System.Windows.Forms.MaskedTextBox Txt_Reason;
        private System.Windows.Forms.ComboBox cmb_branch;
        private System.Windows.Forms.ComboBox cmb_bank;
        private System.Windows.Forms.GroupBox grbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.MaskedTextBox MTxt_Balance;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblValue;
        public System.Windows.Forms.MaskedTextBox MTxt_Value;
        private System.Windows.Forms.Label lblReceivedFrom;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker Dtp_Date;
        private System.Windows.Forms.Button button_decrease;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.MaskedTextBox txt_receipt_no;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkCard;
        private System.Windows.Forms.CheckBox chkPrintPreview;
    }
}