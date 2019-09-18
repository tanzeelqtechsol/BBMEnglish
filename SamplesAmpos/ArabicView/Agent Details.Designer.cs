namespace BumedianBM.ArabicView
{
    partial class Agent_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agent_Details));
            this.lblNo = new System.Windows.Forms.Label();
            this.Grp_Button = new System.Windows.Forms.GroupBox();
            this.btnBalanceSheet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDebtList = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtLastPaymentDate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLastInvoice = new System.Windows.Forms.Label();
            this.Grp_AgentDetails = new System.Windows.Forms.GroupBox();
            this.chkdiscount = new System.Windows.Forms.CheckBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtDebtLimit = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPaymentDay = new System.Windows.Forms.Label();
            this.cmbName = new SergeUtils.EasyCompletionComboBox();
            this.cmbPayDay = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddrress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDebtLimit = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtAccRecivable = new System.Windows.Forms.TextBox();
            this.txtLastInvoice = new System.Windows.Forms.TextBox();
            this.lblAccReceivable = new System.Windows.Forms.Label();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.chkHideAgent = new System.Windows.Forms.CheckBox();
            this.chkBranch = new System.Windows.Forms.CheckBox();
            this.lblLastPayDate = new System.Windows.Forms.Label();
            this.txtAccPayable = new System.Windows.Forms.TextBox();
            this.lblAccPayable = new System.Windows.Forms.Label();
            this.grpAgentinfo = new System.Windows.Forms.GroupBox();
            this.grpAgentType = new System.Windows.Forms.GroupBox();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Grp_Button.SuspendLayout();
            this.Grp_AgentDetails.SuspendLayout();
            this.grpAgentinfo.SuspendLayout();
            this.grpAgentType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNo
            // 
            this.lblNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNo.Location = new System.Drawing.Point(313, 20);
            this.lblNo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNo.Size = new System.Drawing.Size(106, 31);
            this.lblNo.TabIndex = 179;
            this.lblNo.Tag = "No";
            this.lblNo.Text = "رقم العميل";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grp_Button
            // 
            this.Grp_Button.Controls.Add(this.btnBalanceSheet);
            this.Grp_Button.Controls.Add(this.btnCancel);
            this.Grp_Button.Controls.Add(this.btnDebtList);
            this.Grp_Button.Controls.Add(this.btnPrint);
            this.Grp_Button.Controls.Add(this.btnDelete);
            this.Grp_Button.Controls.Add(this.btnSave);
            this.Grp_Button.Controls.Add(this.btnNew);
            this.Grp_Button.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Grp_Button.Location = new System.Drawing.Point(1, -12);
            this.Grp_Button.Margin = new System.Windows.Forms.Padding(6);
            this.Grp_Button.Name = "Grp_Button";
            this.Grp_Button.Padding = new System.Windows.Forms.Padding(6);
            this.Grp_Button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grp_Button.Size = new System.Drawing.Size(149, 355);
            this.Grp_Button.TabIndex = 2;
            this.Grp_Button.TabStop = false;
            // 
            // btnBalanceSheet
            // 
            this.btnBalanceSheet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceSheet.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBalanceSheet.Image = global::BumedianBM.Properties.Resources.balance_sheet_32;
            this.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceSheet.Location = new System.Drawing.Point(5, 163);
            this.btnBalanceSheet.Margin = new System.Windows.Forms.Padding(6);
            this.btnBalanceSheet.Name = "btnBalanceSheet";
            this.btnBalanceSheet.Size = new System.Drawing.Size(139, 43);
            this.btnBalanceSheet.TabIndex = 3;
            this.btnBalanceSheet.Tag = "BalanceSheet";
            this.btnBalanceSheet.Text = "كشف الحساب";
            this.btnBalanceSheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalanceSheet.UseVisualStyleBackColor = false;
            this.btnBalanceSheet.Click += new System.EventHandler(this.btnBalanceSheet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(5, 303);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 43);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "الغاء الامر";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDebtList
            // 
            this.btnDebtList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDebtList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebtList.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDebtList.Image = global::BumedianBM.Properties.Resources.debts_32;
            this.btnDebtList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDebtList.Location = new System.Drawing.Point(5, 211);
            this.btnDebtList.Margin = new System.Windows.Forms.Padding(6);
            this.btnDebtList.Name = "btnDebtList";
            this.btnDebtList.Size = new System.Drawing.Size(139, 43);
            this.btnDebtList.TabIndex = 4;
            this.btnDebtList.Tag = "DebtList";
            this.btnDebtList.Text = "قائمة الديون";
            this.btnDebtList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDebtList.UseVisualStyleBackColor = false;
            this.btnDebtList.Click += new System.EventHandler(this.btnDebtList_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(5, 257);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 43);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
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
            this.btnDelete.Location = new System.Drawing.Point(5, 115);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 43);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "الغاء";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(5, 68);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(5, 21);
            this.btnNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(139, 43);
            this.btnNew.TabIndex = 1;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtLastPaymentDate
            // 
            this.txtLastPaymentDate.BackColor = System.Drawing.Color.White;
            this.txtLastPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtLastPaymentDate.Location = new System.Drawing.Point(377, 63);
            this.txtLastPaymentDate.Margin = new System.Windows.Forms.Padding(6);
            this.txtLastPaymentDate.Multiline = true;
            this.txtLastPaymentDate.Name = "txtLastPaymentDate";
            this.txtLastPaymentDate.ReadOnly = true;
            this.txtLastPaymentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastPaymentDate.Size = new System.Drawing.Size(116, 26);
            this.txtLastPaymentDate.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(369, 143);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(69, 31);
            this.label12.TabIndex = 191;
            this.label12.Text = "Plus %";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lblLastInvoice
            // 
            this.lblLastInvoice.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblLastInvoice.Location = new System.Drawing.Point(8, 59);
            this.lblLastInvoice.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastInvoice.Name = "lblLastInvoice";
            this.lblLastInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLastInvoice.Size = new System.Drawing.Size(125, 31);
            this.lblLastInvoice.TabIndex = 195;
            this.lblLastInvoice.Tag = "LastInvoice";
            this.lblLastInvoice.Text = "اخر فاتورة ";
            this.lblLastInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grp_AgentDetails
            // 
            this.Grp_AgentDetails.Controls.Add(this.label12);
            this.Grp_AgentDetails.Controls.Add(this.chkdiscount);
            this.Grp_AgentDetails.Controls.Add(this.txtDiscount);
            this.Grp_AgentDetails.Controls.Add(this.txtDebtLimit);
            this.Grp_AgentDetails.Controls.Add(this.txtNumber);
            this.Grp_AgentDetails.Controls.Add(this.txtAddress);
            this.Grp_AgentDetails.Controls.Add(this.lblNo);
            this.Grp_AgentDetails.Controls.Add(this.txtPhone);
            this.Grp_AgentDetails.Controls.Add(this.lblPaymentDay);
            this.Grp_AgentDetails.Controls.Add(this.cmbName);
            this.Grp_AgentDetails.Controls.Add(this.cmbPayDay);
            this.Grp_AgentDetails.Controls.Add(this.lblPhone);
            this.Grp_AgentDetails.Controls.Add(this.lblAddrress);
            this.Grp_AgentDetails.Controls.Add(this.lblName);
            this.Grp_AgentDetails.Controls.Add(this.lblDebtLimit);
            this.Grp_AgentDetails.Controls.Add(this.lblDiscount);
            this.Grp_AgentDetails.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Grp_AgentDetails.Location = new System.Drawing.Point(159, -11);
            this.Grp_AgentDetails.Margin = new System.Windows.Forms.Padding(6);
            this.Grp_AgentDetails.Name = "Grp_AgentDetails";
            this.Grp_AgentDetails.Padding = new System.Windows.Forms.Padding(6);
            this.Grp_AgentDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grp_AgentDetails.Size = new System.Drawing.Size(496, 177);
            this.Grp_AgentDetails.TabIndex = 0;
            this.Grp_AgentDetails.TabStop = false;
            this.Grp_AgentDetails.Enter += new System.EventHandler(this.Grp_AgentDetails_Enter);
            // 
            // chkdiscount
            // 
            this.chkdiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkdiscount.Location = new System.Drawing.Point(442, 140);
            this.chkdiscount.Margin = new System.Windows.Forms.Padding(6);
            this.chkdiscount.Name = "chkdiscount";
            this.chkdiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkdiscount.Size = new System.Drawing.Size(36, 33);
            this.chkdiscount.TabIndex = 5;
            this.chkdiscount.Tag = "Branch";
            this.chkdiscount.Text = "+";
            this.chkdiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdiscount.UseVisualStyleBackColor = true;
            this.chkdiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkdiscount_CheckedChanged);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.Ivory;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDiscount.Location = new System.Drawing.Point(61, 140);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiscount.Size = new System.Drawing.Size(86, 27);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebtLimit_KeyPress);
            // 
            // txtDebtLimit
            // 
            this.txtDebtLimit.BackColor = System.Drawing.Color.Linen;
            this.txtDebtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDebtLimit.Location = new System.Drawing.Point(263, 140);
            this.txtDebtLimit.Name = "txtDebtLimit";
            this.txtDebtLimit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDebtLimit.Size = new System.Drawing.Size(94, 27);
            this.txtDebtLimit.TabIndex = 4;
            this.txtDebtLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebtLimit_KeyPress);
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.White;
            this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtNumber.Location = new System.Drawing.Point(396, 22);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNumber.Size = new System.Drawing.Size(80, 27);
            this.txtNumber.TabIndex = 7;
            this.txtNumber.TabStop = false;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAddress.Location = new System.Drawing.Point(60, 103);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddress.Size = new System.Drawing.Size(412, 27);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPhone.Location = new System.Drawing.Point(59, 60);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.Size = new System.Drawing.Size(250, 27);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblPaymentDay
            // 
            this.lblPaymentDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPaymentDay.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPaymentDay.Location = new System.Drawing.Point(313, 61);
            this.lblPaymentDay.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPaymentDay.Name = "lblPaymentDay";
            this.lblPaymentDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPaymentDay.Size = new System.Drawing.Size(83, 31);
            this.lblPaymentDay.TabIndex = 192;
            this.lblPaymentDay.Text = "يوم الدفع";
            this.lblPaymentDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaymentDay.Visible = false;
            // 
            // cmbName
            // 
            this.cmbName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbName.DropDownHeight = 350;
            this.cmbName.DropDownWidth = 500;
            this.cmbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.IntegralHeight = false;
            this.cmbName.ItemHeight = 18;
            this.cmbName.Location = new System.Drawing.Point(59, 22);
            this.cmbName.Margin = new System.Windows.Forms.Padding(6);
            this.cmbName.MaxDropDownItems = 18;
            this.cmbName.Name = "cmbName";
            this.cmbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbName.Size = new System.Drawing.Size(250, 24);
            this.cmbName.TabIndex = 1;
            this.cmbName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbName_DrawItem);
            this.cmbName.SelectedIndexChanged += new System.EventHandler(this.cmbName_SelectedIndexChanged);
            this.cmbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbName_KeyDown);
            // 
            // cmbPayDay
            // 
            this.cmbPayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbPayDay.Location = new System.Drawing.Point(397, 58);
            this.cmbPayDay.Name = "cmbPayDay";
            this.cmbPayDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbPayDay.Size = new System.Drawing.Size(96, 28);
            this.cmbPayDay.TabIndex = 5;
            this.cmbPayDay.Visible = false;
            this.cmbPayDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayDay_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(1, 61);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPhone.Size = new System.Drawing.Size(53, 31);
            this.lblPhone.TabIndex = 181;
            this.lblPhone.Tag = "Phone";
            this.lblPhone.Text = "الهاتف";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddrress
            // 
            this.lblAddrress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddrress.AutoSize = true;
            this.lblAddrress.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAddrress.Location = new System.Drawing.Point(1, 104);
            this.lblAddrress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddrress.Name = "lblAddrress";
            this.lblAddrress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAddrress.Size = new System.Drawing.Size(58, 31);
            this.lblAddrress.TabIndex = 185;
            this.lblAddrress.Tag = "Address";
            this.lblAddrress.Text = "العنوان ";
            this.lblAddrress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(4, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblName.Name = "lblName";
            this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblName.Size = new System.Drawing.Size(44, 31);
            this.lblName.TabIndex = 178;
            this.lblName.Tag = "Name";
            this.lblName.Text = "الاسم";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDebtLimit
            // 
            this.lblDebtLimit.AutoSize = true;
            this.lblDebtLimit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDebtLimit.Location = new System.Drawing.Point(167, 143);
            this.lblDebtLimit.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDebtLimit.Name = "lblDebtLimit";
            this.lblDebtLimit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDebtLimit.Size = new System.Drawing.Size(88, 31);
            this.lblDebtLimit.TabIndex = 189;
            this.lblDebtLimit.Tag = "DebtLimit";
            this.lblDebtLimit.Text = "سقف الديون";
            this.lblDebtLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Location = new System.Drawing.Point(1, 142);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDiscount.Size = new System.Drawing.Size(51, 31);
            this.lblDiscount.TabIndex = 187;
            this.lblDiscount.Tag = "Discount";
            this.lblDiscount.Text = "التغيير";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccRecivable
            // 
            this.txtAccRecivable.BackColor = System.Drawing.Color.MintCream;
            this.txtAccRecivable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAccRecivable.Location = new System.Drawing.Point(135, 26);
            this.txtAccRecivable.Margin = new System.Windows.Forms.Padding(6);
            this.txtAccRecivable.Multiline = true;
            this.txtAccRecivable.Name = "txtAccRecivable";
            this.txtAccRecivable.ReadOnly = true;
            this.txtAccRecivable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccRecivable.Size = new System.Drawing.Size(95, 26);
            this.txtAccRecivable.TabIndex = 1;
            // 
            // txtLastInvoice
            // 
            this.txtLastInvoice.BackColor = System.Drawing.Color.White;
            this.txtLastInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtLastInvoice.Location = new System.Drawing.Point(135, 63);
            this.txtLastInvoice.Margin = new System.Windows.Forms.Padding(6);
            this.txtLastInvoice.Multiline = true;
            this.txtLastInvoice.Name = "txtLastInvoice";
            this.txtLastInvoice.ReadOnly = true;
            this.txtLastInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastInvoice.Size = new System.Drawing.Size(95, 26);
            this.txtLastInvoice.TabIndex = 3;
            this.txtLastInvoice.TextChanged += new System.EventHandler(this.txtLastInvoice_TextChanged);
            // 
            // lblAccReceivable
            // 
            this.lblAccReceivable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAccReceivable.Location = new System.Drawing.Point(7, 24);
            this.lblAccReceivable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAccReceivable.Name = "lblAccReceivable";
            this.lblAccReceivable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccReceivable.Size = new System.Drawing.Size(125, 31);
            this.lblAccReceivable.TabIndex = 191;
            this.lblAccReceivable.Tag = "AccReceivable";
            this.lblAccReceivable.Text = "مدين عليه";
            this.lblAccReceivable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkClient
            // 
            this.chkClient.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkClient.Location = new System.Drawing.Point(338, 16);
            this.chkClient.Margin = new System.Windows.Forms.Padding(6);
            this.chkClient.Name = "chkClient";
            this.chkClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkClient.Size = new System.Drawing.Size(95, 35);
            this.chkClient.TabIndex = 2;
            this.chkClient.Tag = "Client";
            this.chkClient.Text = "زبون";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClient_KeyPress);
            // 
            // chkHideAgent
            // 
            this.chkHideAgent.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkHideAgent.Location = new System.Drawing.Point(93, 46);
            this.chkHideAgent.Margin = new System.Windows.Forms.Padding(6);
            this.chkHideAgent.Name = "chkHideAgent";
            this.chkHideAgent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkHideAgent.Size = new System.Drawing.Size(144, 35);
            this.chkHideAgent.TabIndex = 4;
            this.chkHideAgent.TabStop = false;
            this.chkHideAgent.Tag = "HidenAgent";
            this.chkHideAgent.Text = "اخفاء العميل";
            this.chkHideAgent.UseVisualStyleBackColor = true;
            this.chkHideAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClient_KeyPress);
            // 
            // chkBranch
            // 
            this.chkBranch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkBranch.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkBranch.Location = new System.Drawing.Point(229, 18);
            this.chkBranch.Margin = new System.Windows.Forms.Padding(6);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkBranch.Size = new System.Drawing.Size(95, 33);
            this.chkBranch.TabIndex = 3;
            this.chkBranch.Tag = "Branch";
            this.chkBranch.Text = "فرع";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClient_KeyPress);
            // 
            // lblLastPayDate
            // 
            this.lblLastPayDate.AutoEllipsis = true;
            this.lblLastPayDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblLastPayDate.Location = new System.Drawing.Point(237, 60);
            this.lblLastPayDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastPayDate.Name = "lblLastPayDate";
            this.lblLastPayDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLastPayDate.Size = new System.Drawing.Size(134, 31);
            this.lblLastPayDate.TabIndex = 195;
            this.lblLastPayDate.Tag = "LastPayDate";
            this.lblLastPayDate.Text = "تاريخ اخر دفعة ";
            this.lblLastPayDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccPayable
            // 
            this.txtAccPayable.BackColor = System.Drawing.Color.Snow;
            this.txtAccPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtAccPayable.Location = new System.Drawing.Point(375, 24);
            this.txtAccPayable.Margin = new System.Windows.Forms.Padding(6);
            this.txtAccPayable.Multiline = true;
            this.txtAccPayable.Name = "txtAccPayable";
            this.txtAccPayable.ReadOnly = true;
            this.txtAccPayable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccPayable.Size = new System.Drawing.Size(116, 26);
            this.txtAccPayable.TabIndex = 0;
            // 
            // lblAccPayable
            // 
            this.lblAccPayable.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAccPayable.Location = new System.Drawing.Point(237, 22);
            this.lblAccPayable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAccPayable.Name = "lblAccPayable";
            this.lblAccPayable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccPayable.Size = new System.Drawing.Size(134, 31);
            this.lblAccPayable.TabIndex = 195;
            this.lblAccPayable.Tag = "AccPayable";
            this.lblAccPayable.Text = "دائن له ";
            this.lblAccPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAgentinfo
            // 
            this.grpAgentinfo.Controls.Add(this.txtLastPaymentDate);
            this.grpAgentinfo.Controls.Add(this.lblLastInvoice);
            this.grpAgentinfo.Controls.Add(this.txtAccRecivable);
            this.grpAgentinfo.Controls.Add(this.txtLastInvoice);
            this.grpAgentinfo.Controls.Add(this.lblAccReceivable);
            this.grpAgentinfo.Controls.Add(this.lblLastPayDate);
            this.grpAgentinfo.Controls.Add(this.txtAccPayable);
            this.grpAgentinfo.Controls.Add(this.lblAccPayable);
            this.grpAgentinfo.Enabled = false;
            this.grpAgentinfo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpAgentinfo.Location = new System.Drawing.Point(159, 246);
            this.grpAgentinfo.Margin = new System.Windows.Forms.Padding(6);
            this.grpAgentinfo.Name = "grpAgentinfo";
            this.grpAgentinfo.Padding = new System.Windows.Forms.Padding(6);
            this.grpAgentinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpAgentinfo.Size = new System.Drawing.Size(496, 98);
            this.grpAgentinfo.TabIndex = 199;
            this.grpAgentinfo.TabStop = false;
            this.grpAgentinfo.Tag = "AgentInfo";
            this.grpAgentinfo.Text = "معلومات العميل";
            // 
            // grpAgentType
            // 
            this.grpAgentType.Controls.Add(this.chkClient);
            this.grpAgentType.Controls.Add(this.chkHideAgent);
            this.grpAgentType.Controls.Add(this.chkBranch);
            this.grpAgentType.Controls.Add(this.chkSupplier);
            this.grpAgentType.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grpAgentType.Location = new System.Drawing.Point(159, 162);
            this.grpAgentType.Margin = new System.Windows.Forms.Padding(6);
            this.grpAgentType.Name = "grpAgentType";
            this.grpAgentType.Padding = new System.Windows.Forms.Padding(6);
            this.grpAgentType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpAgentType.Size = new System.Drawing.Size(496, 85);
            this.grpAgentType.TabIndex = 1;
            this.grpAgentType.TabStop = false;
            this.grpAgentType.Tag = "AgentType";
            this.grpAgentType.Text = "نوع العميل";
            // 
            // chkSupplier
            // 
            this.chkSupplier.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkSupplier.Location = new System.Drawing.Point(93, 16);
            this.chkSupplier.Margin = new System.Windows.Forms.Padding(6);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSupplier.Size = new System.Drawing.Size(124, 35);
            this.chkSupplier.TabIndex = 1;
            this.chkSupplier.Tag = "Supplier";
            this.chkSupplier.Text = "مورد";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chkSupplier_CheckedChanged);
            this.chkSupplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClient_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(514, 357);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(139, 42);
            this.btnClose.TabIndex = 198;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Agent_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(661, 411);
            this.Controls.Add(this.Grp_Button);
            this.Controls.Add(this.Grp_AgentDetails);
            this.Controls.Add(this.grpAgentinfo);
            this.Controls.Add(this.grpAgentType);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agent_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agent Details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Agent_Details_FormClosed);
            this.Load += new System.EventHandler(this.Agent_Details_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Agent_Details_KeyDown);
            this.Grp_Button.ResumeLayout(false);
            this.Grp_AgentDetails.ResumeLayout(false);
            this.Grp_AgentDetails.PerformLayout();
            this.grpAgentinfo.ResumeLayout(false);
            this.grpAgentinfo.PerformLayout();
            this.grpAgentType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.GroupBox Grp_Button;
        private System.Windows.Forms.Button btnBalanceSheet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDebtList;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLastInvoice;
        private System.Windows.Forms.GroupBox Grp_AgentDetails;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddrress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDebtLimit;
        private System.Windows.Forms.Label lblAccReceivable;
        private System.Windows.Forms.Label lblLastPayDate;
        private System.Windows.Forms.Label lblAccPayable;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtLastPaymentDate;
       // public System.Windows.Forms.ComboBox cmbName;
        public System.Windows.Forms.TextBox txtNumber;
        public System.Windows.Forms.TextBox txtAccRecivable;
        public System.Windows.Forms.TextBox txtLastInvoice;
        public System.Windows.Forms.CheckBox chkClient;
        public System.Windows.Forms.CheckBox chkHideAgent;
        public System.Windows.Forms.CheckBox chkBranch;
        public System.Windows.Forms.TextBox txtAccPayable;
        public System.Windows.Forms.CheckBox chkSupplier;
        public System.Windows.Forms.GroupBox grpAgentinfo;
        public System.Windows.Forms.GroupBox grpAgentType;
        private System.Windows.Forms.Label lblPaymentDay;
        private System.Windows.Forms.ComboBox cmbPayDay;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtDebtLimit;
        public System.Windows.Forms.CheckBox chkdiscount;

        private SergeUtils.EasyCompletionComboBox cmbName;
    }
}