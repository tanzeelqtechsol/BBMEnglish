namespace BumedianBM.ArabicView
{
    partial class Debt_Adjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Debt_Adjustment));
            this.Lbl_User = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtPayable = new System.Windows.Forms.TextBox();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.txtReceivable = new System.Windows.Forms.TextBox();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblReceivable = new System.Windows.Forms.Label();
            this.lblPayable = new System.Windows.Forms.Label();
            this.cmbAgentName = new System.Windows.Forms.ComboBox();
            this.lblAgentName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.Btn_Previous = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
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
            // Lbl_User
            // 
            this.Lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_User.ForeColor = System.Drawing.Color.Tomato;
            this.Lbl_User.Location = new System.Drawing.Point(122, 295);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_User.Size = new System.Drawing.Size(239, 18);
            this.Lbl_User.TabIndex = 413;
            this.Lbl_User.Text = "admin";
            this.Lbl_User.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(5, 289);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(99, 31);
            this.lblUserName.TabIndex = 412;
            this.lblUserName.Text = "اسم المستخدم \r\n";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNewYearNo.Location = new System.Drawing.Point(328, 33);
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewYearNo.Size = new System.Drawing.Size(96, 27);
            this.txtNewYearNo.TabIndex = 411;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewYearNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewYearNo_KeyPress);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.Color.OldLace;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtBalance.Location = new System.Drawing.Point(219, 176);
            this.txtBalance.MaxLength = 17;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(94, 27);
            this.txtBalance.TabIndex = 409;
            this.txtBalance.Text = "0.000";
            this.txtBalance.TextChanged += new System.EventHandler(this.txtBalance_TextChanged);
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Event);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBalance.Location = new System.Drawing.Point(144, 179);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBalance.Size = new System.Drawing.Size(53, 31);
            this.lblBalance.TabIndex = 410;
            this.lblBalance.Tag = "Balance";
            this.lblBalance.Text = "الرصيد\r\n";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPayable
            // 
            this.txtPayable.BackColor = System.Drawing.Color.MintCream;
            this.txtPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPayable.Location = new System.Drawing.Point(219, 134);
            this.txtPayable.MaxLength = 17;
            this.txtPayable.Name = "txtPayable";
            this.txtPayable.Size = new System.Drawing.Size(94, 27);
            this.txtPayable.TabIndex = 396;
            this.txtPayable.Text = "0.000";
            this.txtPayable.TextChanged += new System.EventHandler(this.txtReceivable_TextChanged);
            this.txtPayable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Event);
            // 
            // lblStatusName
            // 
            this.lblStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(3, 32);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatusName.Size = new System.Drawing.Size(100, 39);
            this.lblStatusName.TabIndex = 289;
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReceivable
            // 
            this.txtReceivable.BackColor = System.Drawing.Color.Snow;
            this.txtReceivable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReceivable.Location = new System.Drawing.Point(402, 133);
            this.txtReceivable.MaxLength = 17;
            this.txtReceivable.Name = "txtReceivable";
            this.txtReceivable.Size = new System.Drawing.Size(94, 27);
            this.txtReceivable.TabIndex = 395;
            this.txtReceivable.Text = "0.000";
            this.txtReceivable.TextChanged += new System.EventHandler(this.txtReceivable_TextChanged);
            this.txtReceivable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Event);
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceiptNo.Location = new System.Drawing.Point(335, 1);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceiptNo.Size = new System.Drawing.Size(81, 31);
            this.lblReceiptNo.TabIndex = 408;
            this.lblReceiptNo.Tag = "ReceiptNo";
            this.lblReceiptNo.Text = "رقم الايصال\r\n";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatusName);
            this.grpStatus.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(145, 1);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpStatus.Size = new System.Drawing.Size(106, 74);
            this.grpStatus.TabIndex = 407;
            this.grpStatus.TabStop = false;
            this.grpStatus.Tag = "Status";
            this.grpStatus.Text = "الحالة\r\n";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(5, 2);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 406;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(5, 35);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(121, 26);
            this.dtpDate.TabIndex = 393;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(221, 219);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(267, 27);
            this.txtDescription.TabIndex = 397;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // lblReceivable
            // 
            this.lblReceivable.AutoSize = true;
            this.lblReceivable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblReceivable.Location = new System.Drawing.Point(316, 134);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblReceivable.Size = new System.Drawing.Size(94, 31);
            this.lblReceivable.TabIndex = 405;
            this.lblReceivable.Tag = "Receivable";
            this.lblReceivable.Text = "مدين \" عليه\" ";
            this.lblReceivable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPayable
            // 
            this.lblPayable.AutoSize = true;
            this.lblPayable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPayable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPayable.Location = new System.Drawing.Point(144, 136);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPayable.Size = new System.Drawing.Size(70, 31);
            this.lblPayable.TabIndex = 403;
            this.lblPayable.Tag = "Payable";
            this.lblPayable.Text = "دائن \" له\"";
            this.lblPayable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAgentName
            // 
            this.cmbAgentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAgentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAgentName.DropDownHeight = 350;
            this.cmbAgentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbAgentName.FormattingEnabled = true;
            this.cmbAgentName.IntegralHeight = false;
            this.cmbAgentName.Location = new System.Drawing.Point(227, 87);
            this.cmbAgentName.Name = "cmbAgentName";
            this.cmbAgentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAgentName.Size = new System.Drawing.Size(267, 28);
            this.cmbAgentName.TabIndex = 394;
            this.cmbAgentName.Tag = "1";
            this.cmbAgentName.SelectedIndexChanged += new System.EventHandler(this.cmbAgentName_SelectedIndexChanged);
            this.cmbAgentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAgentName_KeyDown);
            // 
            // lblAgentName
            // 
            this.lblAgentName.AutoSize = true;
            this.lblAgentName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAgentName.Location = new System.Drawing.Point(136, 90);
            this.lblAgentName.Name = "lblAgentName";
            this.lblAgentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAgentName.Size = new System.Drawing.Size(75, 31);
            this.lblAgentName.TabIndex = 402;
            this.lblAgentName.Tag = "AgentName";
            this.lblAgentName.Text = "اسم العميل\r\n";
            this.lblAgentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(137, 219);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(46, 31);
            this.lblDescription.TabIndex = 404;
            this.lblDescription.Tag = "Description";
            this.lblDescription.Text = "البيان\r\n";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.FlatAppearance.BorderSize = 0;
            this.Btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Previous.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Previous.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.Btn_Previous.Location = new System.Drawing.Point(279, 24);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Previous.Size = new System.Drawing.Size(40, 40);
            this.Btn_Previous.TabIndex = 399;
            this.Btn_Previous.UseVisualStyleBackColor = true;
            this.Btn_Previous.Click += new System.EventHandler(this.Btn_Previous_Click);
            // 
            // Btn_Next
            // 
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Next.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.Btn_Next.Location = new System.Drawing.Point(430, 24);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Btn_Next.Size = new System.Drawing.Size(40, 40);
            this.Btn_Next.TabIndex = 398;
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Click += new System.EventHandler(this.Btn_Next_Click);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtReceiptNo.Location = new System.Drawing.Point(328, 33);
            this.txtReceiptNo.MaxLength = 30;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiptNo.Size = new System.Drawing.Size(96, 27);
            this.txtReceiptNo.TabIndex = 392;
            this.txtReceiptNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(3, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(135, 216);
            this.groupBox2.TabIndex = 398;
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
            this.btnNew.Location = new System.Drawing.Point(7, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 40);
            this.btnNew.TabIndex = 2;
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
            this.btnSave.Location = new System.Drawing.Point(7, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(121, 40);
            this.btnSave.TabIndex = 1;
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
            this.btnPrint.Location = new System.Drawing.Point(7, 118);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(121, 40);
            this.btnPrint.TabIndex = 213;
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
            this.btnDelete.Location = new System.Drawing.Point(7, 166);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(121, 40);
            this.btnDelete.TabIndex = 214;
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
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(380, 276);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(121, 42);
            this.btnClose.TabIndex = 462;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Debt_Adjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(507, 322);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Lbl_User);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtNewYearNo);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.txtPayable);
            this.Controls.Add(this.txtReceivable);
            this.Controls.Add(this.lblReceiptNo);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblReceivable);
            this.Controls.Add(this.lblPayable);
            this.Controls.Add(this.cmbAgentName);
            this.Controls.Add(this.lblAgentName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.Btn_Previous);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.txtReceiptNo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Debt_Adjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debt Adjustment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Debt_Adjustment_FormClosed);
            this.Load += new System.EventHandler(this.Debt_Adjustment_Load);
            this.grpStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        public System.Windows.Forms.Label Lbl_User;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.MaskedTextBox txtNewYearNo;
        public System.Windows.Forms.TextBox txtBalance;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.TextBox txtPayable;
        public System.Windows.Forms.Label lblStatusName;
        public System.Windows.Forms.TextBox txtReceivable;
        public System.Windows.Forms.Label lblReceiptNo;
        public System.Windows.Forms.GroupBox grpStatus;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label lblReceivable;
        public System.Windows.Forms.Label lblPayable;
        public System.Windows.Forms.Label lblAgentName;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.Button Btn_Previous;
        public System.Windows.Forms.Button Btn_Next;
        public System.Windows.Forms.TextBox txtReceiptNo;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ComboBox cmbAgentName;

    }
}