namespace BumedianBM.ArabicView
{
    partial class User_Tracking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Tracking));
            this.Btn_Last = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.Lbl_PageNo = new System.Windows.Forms.Label();
            this.Cmb_Action = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDetailedReport = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.chkAllDate = new System.Windows.Forms.CheckBox();
            this.dgrTrackingUser = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionArabic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PerformedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.lblToTime = new System.Windows.Forms.Label();
            this.lblFromTime = new System.Windows.Forms.Label();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkAllUser = new System.Windows.Forms.CheckBox();
            this.Btn_First = new System.Windows.Forms.Button();
            this.Btn_Previous = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTrackingUser)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Last
            // 
            this.Btn_Last.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Last.FlatAppearance.BorderSize = 0;
            this.Btn_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Last.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Last.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Last.Image = global::BumedianBM.Properties.Resources.last_32;
            this.Btn_Last.Location = new System.Drawing.Point(97, 72);
            this.Btn_Last.Name = "Btn_Last";
            this.Btn_Last.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_Last.Size = new System.Drawing.Size(37, 33);
            this.Btn_Last.TabIndex = 306;
            this.Btn_Last.UseVisualStyleBackColor = false;
            this.Btn_Last.Visible = false;
            // 
            // Btn_Next
            // 
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Next.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Next.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.Btn_Next.Location = new System.Drawing.Point(85, 72);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(30, 33);
            this.Btn_Next.TabIndex = 305;
            this.Btn_Next.UseVisualStyleBackColor = true;
            this.Btn_Next.Visible = false;
            // 
            // Lbl_PageNo
            // 
            this.Lbl_PageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PageNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_PageNo.Location = new System.Drawing.Point(4, 38);
            this.Lbl_PageNo.Name = "Lbl_PageNo";
            this.Lbl_PageNo.Size = new System.Drawing.Size(151, 31);
            this.Lbl_PageNo.TabIndex = 304;
            this.Lbl_PageNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lbl_PageNo.Visible = false;
            // 
            // Cmb_Action
            // 
            this.Cmb_Action.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cmb_Action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmb_Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Cmb_Action.FormattingEnabled = true;
            this.Cmb_Action.Location = new System.Drawing.Point(648, 83);
            this.Cmb_Action.Name = "Cmb_Action";
            this.Cmb_Action.Size = new System.Drawing.Size(202, 28);
            this.Cmb_Action.TabIndex = 303;
            this.Cmb_Action.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Action_KeyPress);
            // 
            // lblAction
            // 
            this.lblAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblAction.Location = new System.Drawing.Point(586, 86);
            this.lblAction.Name = "lblAction";
            this.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAction.Size = new System.Drawing.Size(56, 31);
            this.lblAction.TabIndex = 302;
            this.lblAction.Tag = "Action";
            this.lblAction.Text = "الحركة ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExit);
            this.groupBox4.Controls.Add(this.btnDetailedReport);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Controls.Add(this.btnFind);
            this.groupBox4.Location = new System.Drawing.Point(4, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(139, 242);
            this.groupBox4.TabIndex = 301;
            this.groupBox4.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnExit.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(3, 194);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 39);
            this.btnExit.TabIndex = 13;
            this.btnExit.Tag = "Exit";
            this.btnExit.Text = "خروج";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDetailedReport
            // 
            this.btnDetailedReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDetailedReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailedReport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDetailedReport.Image = global::BumedianBM.Properties.Resources.reports_32;
            this.btnDetailedReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailedReport.Location = new System.Drawing.Point(3, 150);
            this.btnDetailedReport.Name = "btnDetailedReport";
            this.btnDetailedReport.Size = new System.Drawing.Size(131, 39);
            this.btnDetailedReport.TabIndex = 6;
            this.btnDetailedReport.Tag = "DetailedReport";
            this.btnDetailedReport.Text = "تقرير مفصل ";
            this.btnDetailedReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetailedReport.UseVisualStyleBackColor = false;
            this.btnDetailedReport.Click += new System.EventHandler(this.btnDetailedReport_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 108);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(131, 39);
            this.btnNew.TabIndex = 5;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(3, 65);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(131, 39);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFind.Image = global::BumedianBM.Properties.Resources.binoculars_32;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(3, 21);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(131, 39);
            this.btnFind.TabIndex = 2;
            this.btnFind.Tag = "Find";
            this.btnFind.Text = "ابحث";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(543, 7);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(110, 26);
            this.dtpToDate.TabIndex = 300;
            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dtp_ToDate_KeyPress);
            // 
            // chkAllDate
            // 
            this.chkAllDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAllDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkAllDate.Location = new System.Drawing.Point(659, 5);
            this.chkAllDate.Name = "chkAllDate";
            this.chkAllDate.Size = new System.Drawing.Size(87, 35);
            this.chkAllDate.TabIndex = 299;
            this.chkAllDate.Text = "الكل ";
            this.chkAllDate.UseVisualStyleBackColor = true;
            this.chkAllDate.CheckedChanged += new System.EventHandler(this.Chk_AllDate_CheckedChanged);
            this.chkAllDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Chk_AllDate_KeyPress);
            // 
            // dgrTrackingUser
            // 
            this.dgrTrackingUser.AllowUserToAddRows = false;
            this.dgrTrackingUser.AllowUserToOrderColumns = true;
            this.dgrTrackingUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrTrackingUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrTrackingUser.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgrTrackingUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrTrackingUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrTrackingUser.ColumnHeadersHeight = 37;
            this.dgrTrackingUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.Date,
            this.Time,
            this.Action,
            this.ActionArabic,
            this.UserName,
            this.TableName,
            this.PerformedOn,
            this.ActionType,
            this.UserId});
            this.dgrTrackingUser.GridColor = System.Drawing.SystemColors.Control;
            this.dgrTrackingUser.Location = new System.Drawing.Point(148, 118);
            this.dgrTrackingUser.Name = "dgrTrackingUser";
            this.dgrTrackingUser.RowHeadersVisible = false;
            this.dgrTrackingUser.RowHeadersWidth = 13;
            this.dgrTrackingUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgrTrackingUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrTrackingUser.Size = new System.Drawing.Size(726, 376);
            this.dgrTrackingUser.TabIndex = 298;
            this.dgrTrackingUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTrackingUser_CellContentClick);
            // 
            // Sno
            // 
            this.Sno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sno.DataPropertyName = "Sno";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Sno.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sno.HeaderText = "ر.ت";
            this.Sno.MinimumWidth = 100;
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Date.DataPropertyName = "strDate";
            this.Date.HeaderText = "التاريخ";
            this.Date.MinimumWidth = 50;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 77;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Time.DataPropertyName = "strTime";
            this.Time.HeaderText = "الوقت ";
            this.Time.MinimumWidth = 50;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 71;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Action.DataPropertyName = "Action";
            this.Action.HeaderText = "الحركة ";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // ActionArabic
            // 
            this.ActionArabic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionArabic.DataPropertyName = "ActionArabic";
            this.ActionArabic.HeaderText = "الحركة ";
            this.ActionArabic.MinimumWidth = 100;
            this.ActionArabic.Name = "ActionArabic";
            this.ActionArabic.ReadOnly = true;
            this.ActionArabic.Visible = false;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "المستخدم";
            this.UserName.MinimumWidth = 50;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 91;
            // 
            // TableName
            // 
            this.TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "اسم الجدول";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.Visible = false;
            this.TableName.Width = 105;
            // 
            // PerformedOn
            // 
            this.PerformedOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PerformedOn.DataPropertyName = "PerformedOn";
            this.PerformedOn.HeaderText = "تم في ";
            this.PerformedOn.MinimumWidth = 65;
            this.PerformedOn.Name = "PerformedOn";
            this.PerformedOn.ReadOnly = true;
            // 
            // ActionType
            // 
            this.ActionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionType.DataPropertyName = "ActionType";
            this.ActionType.HeaderText = "Action Type";
            this.ActionType.Name = "ActionType";
            this.ActionType.ReadOnly = true;
            this.ActionType.Visible = false;
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(239, 86);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUser.Size = new System.Drawing.Size(66, 31);
            this.lblUser.TabIndex = 296;
            this.lblUser.Text = "المستخدم";
            // 
            // cmbUserName
            // 
            this.cmbUserName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(311, 84);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(185, 28);
            this.cmbUserName.TabIndex = 297;
            this.cmbUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbUserName_KeyUp);
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(225, 11);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFromDate.Size = new System.Drawing.Size(67, 31);
            this.lblFromDate.TabIndex = 288;
            this.lblFromDate.Text = "من تاريخ";
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromTime.CustomFormat = "hh:mm tt";
            this.dtpFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(311, 45);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(110, 26);
            this.dtpFromTime.TabIndex = 294;
            this.dtpFromTime.Value = new System.DateTime(2008, 9, 9, 0, 0, 0, 0);
            this.dtpFromTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dtp_FromTime_KeyPress);
            // 
            // lblToTime
            // 
            this.lblToTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblToTime.AutoSize = true;
            this.lblToTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToTime.Location = new System.Drawing.Point(457, 48);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblToTime.Size = new System.Drawing.Size(80, 31);
            this.lblToTime.TabIndex = 291;
            this.lblToTime.Text = "حتى تاريخ ";
            // 
            // lblFromTime
            // 
            this.lblFromTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFromTime.AutoSize = true;
            this.lblFromTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromTime.Location = new System.Drawing.Point(225, 48);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFromTime.Size = new System.Drawing.Size(77, 31);
            this.lblFromTime.TabIndex = 293;
            this.lblFromTime.Text = "من الساعة";
            // 
            // dtpToTime
            // 
            this.dtpToTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToTime.CustomFormat = "hh:mm tt";
            this.dtpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToTime.Location = new System.Drawing.Point(543, 43);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(110, 26);
            this.dtpToTime.TabIndex = 292;
            this.dtpToTime.Value = new System.DateTime(2008, 9, 9, 23, 59, 0, 0);
            this.dtpToTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dtp_ToTime_KeyPress);
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(457, 11);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblToDate.Size = new System.Drawing.Size(80, 31);
            this.lblToDate.TabIndex = 290;
            this.lblToDate.Text = "حتى تاريخ ";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(311, 7);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 26);
            this.dtpFromDate.TabIndex = 289;
            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dtp_FromDate_KeyPress);
            // 
            // chkAllUser
            // 
            this.chkAllUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAllUser.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkAllUser.Location = new System.Drawing.Point(498, 80);
            this.chkAllUser.Name = "chkAllUser";
            this.chkAllUser.Size = new System.Drawing.Size(78, 35);
            this.chkAllUser.TabIndex = 295;
            this.chkAllUser.Text = "الكل ";
            this.chkAllUser.UseVisualStyleBackColor = true;
            this.chkAllUser.CheckedChanged += new System.EventHandler(this.Chk_AllUser_CheckedChanged);
            this.chkAllUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Chk_AllUser_KeyPress);
            // 
            // Btn_First
            // 
            this.Btn_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_First.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_First.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_First.Image = global::BumedianBM.Properties.Resources.first_32;
            this.Btn_First.Location = new System.Drawing.Point(3, 71);
            this.Btn_First.Name = "Btn_First";
            this.Btn_First.Size = new System.Drawing.Size(35, 33);
            this.Btn_First.TabIndex = 308;
            this.Btn_First.UseVisualStyleBackColor = true;
            this.Btn_First.Visible = false;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.FlatAppearance.BorderSize = 0;
            this.Btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Previous.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Previous.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Previous.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.Btn_Previous.Location = new System.Drawing.Point(44, 72);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.Size = new System.Drawing.Size(31, 33);
            this.Btn_Previous.TabIndex = 307;
            this.Btn_Previous.UseVisualStyleBackColor = true;
            this.Btn_Previous.Visible = false;
            // 
            // User_Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(879, 497);
            this.Controls.Add(this.Btn_First);
            this.Controls.Add(this.Btn_Previous);
            this.Controls.Add(this.Btn_Last);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.Lbl_PageNo);
            this.Controls.Add(this.Cmb_Action);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.chkAllDate);
            this.Controls.Add(this.dgrTrackingUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromTime);
            this.Controls.Add(this.lblToTime);
            this.Controls.Add(this.lblFromTime);
            this.Controls.Add(this.dtpToTime);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.chkAllUser);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User_Tracking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "User Tracking";
            this.Text = "User Tracking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.User_Tracking_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.User_Tracking_FormClosed);
            this.Load += new System.EventHandler(this.User_Tracking_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tracking_users_KeyDown);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrTrackingUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Last;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.Label Lbl_PageNo;
        private System.Windows.Forms.ComboBox Cmb_Action;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDetailedReport;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.CheckBox chkAllDate;
        private System.Windows.Forms.DataGridView dgrTrackingUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.Label lblToTime;
        private System.Windows.Forms.Label lblFromTime;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkAllUser;
        private System.Windows.Forms.Button Btn_First;
        private System.Windows.Forms.Button Btn_Previous;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionArabic;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PerformedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
    }
}