namespace BumedianBM.ArabicView
{
    partial class Pay_Receipt
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
            lstPayReceipt = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pay_Receipt));
            this.Cmb_Reason = new System.Windows.Forms.TextBox();
            this.Txt_NewYear_No = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_User = new System.Windows.Forms.Label();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.MTxt_Discription = new System.Windows.Forms.MaskedTextBox();
            this.Cmb_Branch = new System.Windows.Forms.ComboBox();
            this.Cmb_Bank = new System.Windows.Forms.ComboBox();
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.MTxt_Balance = new System.Windows.Forms.MaskedTextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.MTxt_Value = new System.Windows.Forms.MaskedTextBox();
            this.Cmb_PayTo = new System.Windows.Forms.ComboBox();
            this.lblPayTo = new System.Windows.Forms.Label();
            this.Btn_Previous = new System.Windows.Forms.Button();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.MTxt_InvoiceNo = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPrintPreview = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.Dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.chkCard = new System.Windows.Forms.CheckBox();
            this.grbStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmb_Reason
            // 
            this.Cmb_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_Reason.Location = new System.Drawing.Point(220, 211);
            this.Cmb_Reason.Name = "Cmb_Reason";
            this.Cmb_Reason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cmb_Reason.Size = new System.Drawing.Size(231, 27);
            this.Cmb_Reason.TabIndex = 3;
            this.Cmb_Reason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // Txt_NewYear_No
            // 
            this.Txt_NewYear_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Txt_NewYear_No.Location = new System.Drawing.Point(232, 30);
            this.Txt_NewYear_No.Name = "Txt_NewYear_No";
            this.Txt_NewYear_No.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_NewYear_No.Size = new System.Drawing.Size(86, 27);
            this.Txt_NewYear_No.TabIndex = 418;
            this.Txt_NewYear_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_NewYear_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_NewYear_No_KeyPress);
            // 
            // Lbl_User
            // 
            this.Lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_User.ForeColor = System.Drawing.Color.Tomato;
            this.Lbl_User.Location = new System.Drawing.Point(122, 382);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_User.Size = new System.Drawing.Size(294, 18);
            this.Lbl_User.TabIndex = 417;
            this.Lbl_User.Text = "admin";
            // 
            // chkCheck
            // 
            this.chkCheck.Location = new System.Drawing.Point(453, 252);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCheck.Size = new System.Drawing.Size(89, 35);
            this.chkCheck.TabIndex = 5;
            this.chkCheck.Text = "صك\r\n";
            this.chkCheck.UseVisualStyleBackColor = true;
            this.chkCheck.CheckedChanged += new System.EventHandler(this.chkCheck_CheckedChanged);
            this.chkCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_Branch_KeyDown);
            // 
            // chkCash
            // 
            this.chkCash.Location = new System.Drawing.Point(268, 250);
            this.chkCash.Name = "chkCash";
            this.chkCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCash.Size = new System.Drawing.Size(93, 35);
            this.chkCash.TabIndex = 4;
            this.chkCash.Text = "نقد\r\n";
            this.chkCash.UseVisualStyleBackColor = true;
            this.chkCash.CheckedChanged += new System.EventHandler(this.chkCash_CheckedChanged);
            this.chkCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // lblReason
            // 
            this.lblReason.Location = new System.Drawing.Point(139, 207);
            this.lblReason.Name = "lblReason";
            this.lblReason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReason.Size = new System.Drawing.Size(73, 31);
            this.lblReason.TabIndex = 416;
            this.lblReason.Tag = "Reason";
            this.lblReason.Text = "السبب\r\n";
            this.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTxt_Discription
            // 
            this.MTxt_Discription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Discription.Location = new System.Drawing.Point(220, 133);
            this.MTxt_Discription.Name = "MTxt_Discription";
            this.MTxt_Discription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTxt_Discription.Size = new System.Drawing.Size(231, 27);
            this.MTxt_Discription.TabIndex = 1;
            this.MTxt_Discription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // Cmb_Branch
            // 
            this.Cmb_Branch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_Branch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_Branch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_Branch.FormattingEnabled = true;
            this.Cmb_Branch.Location = new System.Drawing.Point(211, 337);
            this.Cmb_Branch.Name = "Cmb_Branch";
            this.Cmb_Branch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cmb_Branch.Size = new System.Drawing.Size(231, 28);
            this.Cmb_Branch.TabIndex = 7;
            this.Cmb_Branch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_Branch_KeyDown);
            // 
            // Cmb_Bank
            // 
            this.Cmb_Bank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_Bank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_Bank.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_Bank.FormattingEnabled = true;
            this.Cmb_Bank.Location = new System.Drawing.Point(211, 298);
            this.Cmb_Bank.Name = "Cmb_Bank";
            this.Cmb_Bank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cmb_Bank.Size = new System.Drawing.Size(231, 28);
            this.Cmb_Bank.TabIndex = 6;
            this.Cmb_Bank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // grbStatus
            // 
            this.grbStatus.Controls.Add(this.LblStatus);
            this.grbStatus.Location = new System.Drawing.Point(431, 2);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbStatus.Size = new System.Drawing.Size(121, 69);
            this.grbStatus.TabIndex = 415;
            this.grbStatus.TabStop = false;
            this.grbStatus.Tag = "Status";
            this.grbStatus.Text = "الحالة\r\n";
            // 
            // LblStatus
            // 
            this.LblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblStatus.Location = new System.Drawing.Point(3, 32);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(115, 34);
            this.LblStatus.TabIndex = 0;
            this.LblStatus.Text = "a";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.Location = new System.Drawing.Point(448, 67);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(98, 31);
            this.lblBalance.TabIndex = 414;
            this.lblBalance.Tag = "Balance";
            this.lblBalance.Text = "الرصيد\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTxt_Balance
            // 
            this.MTxt_Balance.BackColor = System.Drawing.SystemColors.Info;
            this.MTxt_Balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Balance.ForeColor = System.Drawing.Color.Red;
            this.MTxt_Balance.Location = new System.Drawing.Point(453, 100);
            this.MTxt_Balance.Name = "MTxt_Balance";
            this.MTxt_Balance.ReadOnly = true;
            this.MTxt_Balance.Size = new System.Drawing.Size(104, 27);
            this.MTxt_Balance.TabIndex = 8;
            this.MTxt_Balance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // lblBranch
            // 
            this.lblBranch.Location = new System.Drawing.Point(139, 334);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBranch.Size = new System.Drawing.Size(78, 31);
            this.lblBranch.TabIndex = 413;
            this.lblBranch.Tag = "Branch";
            this.lblBranch.Text = "الفرع\r\n";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(139, 295);
            this.lblBank.Name = "lblBank";
            this.lblBank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBank.Size = new System.Drawing.Size(78, 31);
            this.lblBank.TabIndex = 412;
            this.lblBank.Tag = "Bank";
            this.lblBank.Text = "المصرف\r\n";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.Location = new System.Drawing.Point(136, 250);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPaymentMethod.Size = new System.Drawing.Size(152, 31);
            this.lblPaymentMethod.TabIndex = 411;
            this.lblPaymentMethod.Tag = "PayMethod";
            this.lblPaymentMethod.Text = "طريقة الدفع\r\n";
            this.lblPaymentMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(138, 129);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(114, 31);
            this.lblDescription.TabIndex = 410;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(2, 378);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(90, 26);
            this.lblUserName.TabIndex = 409;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "اسم المستخدم";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(139, 168);
            this.lblValue.Name = "lblValue";
            this.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue.Size = new System.Drawing.Size(50, 31);
            this.lblValue.TabIndex = 408;
            this.lblValue.Tag = "Value";
            this.lblValue.Text = "قيمة\r\n";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTxt_Value
            // 
            this.MTxt_Value.BackColor = System.Drawing.Color.Honeydew;
            this.MTxt_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_Value.Location = new System.Drawing.Point(219, 172);
            this.MTxt_Value.Name = "MTxt_Value";
            this.MTxt_Value.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MTxt_Value.Size = new System.Drawing.Size(231, 27);
            this.MTxt_Value.TabIndex = 2;
            this.MTxt_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MTxt_Value_KeyPress);
            this.MTxt_Value.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MTxt_Value_KeyUp);
            // 
            // Cmb_PayTo
            // 
            this.Cmb_PayTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_PayTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_PayTo.DropDownHeight = 400;
            this.Cmb_PayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_PayTo.FormattingEnabled = true;
            this.Cmb_PayTo.IntegralHeight = false;
            this.Cmb_PayTo.Location = new System.Drawing.Point(220, 99);
            this.Cmb_PayTo.Name = "Cmb_PayTo";
            this.Cmb_PayTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cmb_PayTo.Size = new System.Drawing.Size(231, 28);
            this.Cmb_PayTo.TabIndex = 0;
            this.Cmb_PayTo.SelectedIndexChanged += new System.EventHandler(this.Cmb_PayTo_SelectedIndexChanged);
            this.Cmb_PayTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_PayTo_KeyDown);
            // 
            // lblPayTo
            // 
            this.lblPayTo.Location = new System.Drawing.Point(137, 96);
            this.lblPayTo.Name = "lblPayTo";
            this.lblPayTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPayTo.Size = new System.Drawing.Size(84, 31);
            this.lblPayTo.TabIndex = 407;
            this.lblPayTo.Tag = "PayTo";
            this.lblPayTo.Text = "ادفع الى \r\n";
            this.lblPayTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.FlatAppearance.BorderSize = 0;
            this.Btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Previous.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.Btn_Previous.Location = new System.Drawing.Point(191, 28);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Previous.Size = new System.Drawing.Size(35, 30);
            this.Btn_Previous.TabIndex = 401;
            this.Btn_Previous.UseVisualStyleBackColor = true;
            this.Btn_Previous.Click += new System.EventHandler(this.Btn_Previous_Click);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Location = new System.Drawing.Point(236, -1);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(81, 31);
            this.lblReceiptNo.TabIndex = 405;
            this.lblReceiptNo.Tag = "ReceiptNo";
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            this.lblReceiptNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MTxt_InvoiceNo
            // 
            this.MTxt_InvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.MTxt_InvoiceNo.Location = new System.Drawing.Point(256, 31);
            this.MTxt_InvoiceNo.Name = "MTxt_InvoiceNo";
            this.MTxt_InvoiceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MTxt_InvoiceNo.Size = new System.Drawing.Size(61, 27);
            this.MTxt_InvoiceNo.TabIndex = 404;
            this.MTxt_InvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MTxt_InvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MTxt_InvoiceNo_KeyPress);
            // 
            // Btn_Next
            // 
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.Btn_Next.Location = new System.Drawing.Point(323, 28);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Next.Size = new System.Drawing.Size(35, 30);
            this.Btn_Next.TabIndex = 402;
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_Next_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPrintPreview);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(133, 231);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // chkPrintPreview
            // 
            this.chkPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.chkPrintPreview.Location = new System.Drawing.Point(5, 192);
            this.chkPrintPreview.Name = "chkPrintPreview";
            this.chkPrintPreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkPrintPreview.Size = new System.Drawing.Size(122, 26);
            this.chkPrintPreview.TabIndex = 262;
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
            this.btnNew.Location = new System.Drawing.Point(5, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 40);
            this.btnNew.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(5, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 10;
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
            this.btnPrint.Location = new System.Drawing.Point(5, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 40);
            this.btnPrint.TabIndex = 12;
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
            this.btnDelete.Location = new System.Drawing.Point(5, 146);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(121, 40);
            this.btnDelete.TabIndex = 13;
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
            this.btnClose.Location = new System.Drawing.Point(431, 371);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(121, 40);
            this.btnClose.TabIndex = 14;
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
            this.lblDate.Location = new System.Drawing.Point(10, -1);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 438;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Dtp_Date
            // 
            this.Dtp_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Dtp_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_Date.Location = new System.Drawing.Point(11, 30);
            this.Dtp_Date.Name = "Dtp_Date";
            this.Dtp_Date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_Date.Size = new System.Drawing.Size(121, 27);
            this.Dtp_Date.TabIndex = 437;
            // 
            // chkCard
            // 
            this.chkCard.Location = new System.Drawing.Point(364, 252);
            this.chkCard.Name = "chkCard";
            this.chkCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCard.Size = new System.Drawing.Size(84, 35);
            this.chkCard.TabIndex = 439;
            this.chkCard.Text = "بطاقة";
            this.chkCard.UseVisualStyleBackColor = true;
            this.chkCard.CheckedChanged += new System.EventHandler(this.chkCard_CheckedChanged);
            // 
            // Pay_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(561, 422);
            this.Controls.Add(this.chkCard);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.Dtp_Date);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Cmb_Reason);
            this.Controls.Add(this.Lbl_User);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.chkCash);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.MTxt_Discription);
            this.Controls.Add(this.Cmb_Branch);
            this.Controls.Add(this.Cmb_Bank);
            this.Controls.Add(this.grbStatus);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.MTxt_Balance);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.MTxt_Value);
            this.Controls.Add(this.Cmb_PayTo);
            this.Controls.Add(this.lblPayTo);
            this.Controls.Add(this.Btn_Previous);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.Txt_NewYear_No);
            this.Controls.Add(this.MTxt_InvoiceNo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pay_Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Receipt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pay_Receipt_FormClosed);
            this.Load += new System.EventHandler(this.Pay_Receipt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pay_recipt_KeyDown);
            this.grbStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Cmb_Reason;
        private System.Windows.Forms.MaskedTextBox Txt_NewYear_No;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.MaskedTextBox MTxt_Discription;
        private System.Windows.Forms.ComboBox Cmb_Branch;
        private System.Windows.Forms.ComboBox Cmb_Bank;
        private System.Windows.Forms.GroupBox grbStatus;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ComboBox Cmb_PayTo;
        private System.Windows.Forms.Label lblPayTo;
        private System.Windows.Forms.Button Btn_Previous;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.MaskedTextBox MTxt_InvoiceNo;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker Dtp_Date;
        public System.Windows.Forms.MaskedTextBox MTxt_Balance;
        public System.Windows.Forms.MaskedTextBox MTxt_Value;
        private System.Windows.Forms.CheckBox chkCard;
        private System.Windows.Forms.CheckBox chkPrintPreview;
    }
}