namespace BumedianBM.ArabicView
{
    partial class Time_Attandance_Sheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnUserTracking = new System.Windows.Forms.Button();
            this.btnUserAdmin = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPaySalary = new System.Windows.Forms.Button();
            this.txtWorkingHours = new System.Windows.Forms.TextBox();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.chkDateAll = new System.Windows.Forms.CheckBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalWorkingDiff = new System.Windows.Forms.Label();
            this.txtDailyAvarage = new System.Windows.Forms.TextBox();
            this.txtWorkingDifference = new System.Windows.Forms.TextBox();
            this.lblDailyAverage = new System.Windows.Forms.Label();
            this.lblTotalWorkingHrs = new System.Windows.Forms.Label();
            this.dgrAttendanceList = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreakTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTimeTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radUserAll = new System.Windows.Forms.RadioButton();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.radGroup = new System.Windows.Forms.RadioButton();
            this.radUser = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAttendanceList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnUserTracking);
            this.groupBox1.Controls.Add(this.btnUserAdmin);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnPaySalary);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(166, 383);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFind.Image = global::BumedianBM.Properties.Resources.binoculars_32;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(6, 40);
            this.btnFind.Name = "btnFind";
            this.btnFind.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFind.Size = new System.Drawing.Size(154, 45);
            this.btnFind.TabIndex = 0;
            this.btnFind.Tag = "Find";
            this.btnFind.Text = "ابحث ";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(6, 300);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(154, 45);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUserTracking
            // 
            this.btnUserTracking.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUserTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserTracking.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnUserTracking.Image = global::BumedianBM.Properties.Resources.user_tracking_32;
            this.btnUserTracking.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUserTracking.Location = new System.Drawing.Point(6, 248);
            this.btnUserTracking.Name = "btnUserTracking";
            this.btnUserTracking.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUserTracking.Size = new System.Drawing.Size(154, 45);
            this.btnUserTracking.TabIndex = 4;
            this.btnUserTracking.Tag = "UserTrack";
            this.btnUserTracking.Text = "تحركات المستخدم";
            this.btnUserTracking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserTracking.UseVisualStyleBackColor = false;
            this.btnUserTracking.Click += new System.EventHandler(this.btnUserTracking_Click);
            // 
            // btnUserAdmin
            // 
            this.btnUserAdmin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUserAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAdmin.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnUserAdmin.Image = global::BumedianBM.Properties.Resources.administrator_32;
            this.btnUserAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserAdmin.Location = new System.Drawing.Point(6, 196);
            this.btnUserAdmin.Name = "btnUserAdmin";
            this.btnUserAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUserAdmin.Size = new System.Drawing.Size(154, 45);
            this.btnUserAdmin.TabIndex = 3;
            this.btnUserAdmin.Tag = "UserAdmin";
            this.btnUserAdmin.Text = "ادارة الصلاحيات";
            this.btnUserAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserAdmin.UseVisualStyleBackColor = false;
            this.btnUserAdmin.Click += new System.EventHandler(this.btnUserAdmin_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(6, 92);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(154, 45);
            this.btnNew.TabIndex = 1;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "جديد";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPaySalary
            // 
            this.btnPaySalary.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPaySalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaySalary.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPaySalary.Image = global::BumedianBM.Properties.Resources.salary_32;
            this.btnPaySalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaySalary.Location = new System.Drawing.Point(6, 144);
            this.btnPaySalary.Name = "btnPaySalary";
            this.btnPaySalary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPaySalary.Size = new System.Drawing.Size(154, 45);
            this.btnPaySalary.TabIndex = 2;
            this.btnPaySalary.Tag = "PaySal";
            this.btnPaySalary.Text = "صرف المرتبات";
            this.btnPaySalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPaySalary.UseVisualStyleBackColor = false;
            this.btnPaySalary.Click += new System.EventHandler(this.btnPaySalary_Click);
            // 
            // txtWorkingHours
            // 
            this.txtWorkingHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtWorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtWorkingHours.Location = new System.Drawing.Point(357, 481);
            this.txtWorkingHours.Name = "txtWorkingHours";
            this.txtWorkingHours.ReadOnly = true;
            this.txtWorkingHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWorkingHours.Size = new System.Drawing.Size(184, 27);
            this.txtWorkingHours.TabIndex = 6;
            // 
            // cmbUserName
            // 
            this.cmbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(589, 59);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(205, 28);
            this.cmbUserName.TabIndex = 6;
            this.cmbUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cmb_UserName_KeyUp);
            // 
            // chkDateAll
            // 
            this.chkDateAll.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.chkDateAll.Location = new System.Drawing.Point(680, 5);
            this.chkDateAll.Name = "chkDateAll";
            this.chkDateAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDateAll.Size = new System.Drawing.Size(97, 35);
            this.chkDateAll.TabIndex = 2;
            this.chkDateAll.Tag = "All";
            this.chkDateAll.Text = "الكل ";
            this.chkDateAll.UseVisualStyleBackColor = true;
            this.chkDateAll.CheckedChanged += new System.EventHandler(this.Chk_DateAll_CheckedChanged);
            this.chkDateAll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Chk_DateAll_KeyPress);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM/dd/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(339, 11);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(116, 26);
            this.dtpFromDate.TabIndex = 0;
            this.dtpFromDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dtp_FromDate_KeyUp);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(461, 11);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblToDate.Size = new System.Drawing.Size(80, 31);
            this.lblToDate.TabIndex = 305;
            this.lblToDate.Tag = "TD";
            this.lblToDate.Text = "حتى تاريخ ";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(255, 10);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFromDate.Size = new System.Drawing.Size(67, 31);
            this.lblFromDate.TabIndex = 304;
            this.lblFromDate.Tag = "FD";
            this.lblFromDate.Text = "من تاريخ";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(772, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(122, 43);
            this.btnClose.TabIndex = 9;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "اغلاق";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM/dd/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(548, 11);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(116, 26);
            this.dtpToDate.TabIndex = 1;
            this.dtpToDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dtp_ToDate_KeyUp);
            // 
            // lblTotalWorkingDiff
            // 
            this.lblTotalWorkingDiff.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalWorkingDiff.Location = new System.Drawing.Point(522, 477);
            this.lblTotalWorkingDiff.Name = "lblTotalWorkingDiff";
            this.lblTotalWorkingDiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalWorkingDiff.Size = new System.Drawing.Size(220, 31);
            this.lblTotalWorkingDiff.TabIndex = 310;
            this.lblTotalWorkingDiff.Tag = "TWorkingDiff";
            this.lblTotalWorkingDiff.Text = "اجمالي فروقات العمل";
            this.lblTotalWorkingDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDailyAvarage
            // 
            this.txtDailyAvarage.BackColor = System.Drawing.SystemColors.Window;
            this.txtDailyAvarage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtDailyAvarage.Location = new System.Drawing.Point(357, 517);
            this.txtDailyAvarage.Name = "txtDailyAvarage";
            this.txtDailyAvarage.ReadOnly = true;
            this.txtDailyAvarage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDailyAvarage.Size = new System.Drawing.Size(184, 27);
            this.txtDailyAvarage.TabIndex = 8;
            // 
            // txtWorkingDifference
            // 
            this.txtWorkingDifference.BackColor = System.Drawing.Color.SeaShell;
            this.txtWorkingDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtWorkingDifference.Location = new System.Drawing.Point(748, 481);
            this.txtWorkingDifference.Name = "txtWorkingDifference";
            this.txtWorkingDifference.ReadOnly = true;
            this.txtWorkingDifference.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWorkingDifference.Size = new System.Drawing.Size(146, 27);
            this.txtWorkingDifference.TabIndex = 7;
            // 
            // lblDailyAverage
            // 
            this.lblDailyAverage.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDailyAverage.Location = new System.Drawing.Point(173, 517);
            this.lblDailyAverage.Name = "lblDailyAverage";
            this.lblDailyAverage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDailyAverage.Size = new System.Drawing.Size(165, 31);
            this.lblDailyAverage.TabIndex = 309;
            this.lblDailyAverage.Tag = "DailyAvg";
            this.lblDailyAverage.Text = "المعدل اليومي";
            this.lblDailyAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalWorkingHrs
            // 
            this.lblTotalWorkingHrs.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalWorkingHrs.Location = new System.Drawing.Point(167, 481);
            this.lblTotalWorkingHrs.Name = "lblTotalWorkingHrs";
            this.lblTotalWorkingHrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalWorkingHrs.Size = new System.Drawing.Size(173, 31);
            this.lblTotalWorkingHrs.TabIndex = 308;
            this.lblTotalWorkingHrs.Tag = "TWorkingHrs";
            this.lblTotalWorkingHrs.Text = "اجمالي ساعات العمل";
            this.lblTotalWorkingHrs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgrAttendanceList
            // 
            this.dgrAttendanceList.AllowUserToAddRows = false;
            this.dgrAttendanceList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgrAttendanceList.ColumnHeadersHeight = 37;
            this.dgrAttendanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.UserName,
            this.UserDate,
            this.Day,
            this.EntryTime,
            this.ExitTime,
            this.TotalHours,
            this.Difference,
            this.BreakTime,
            this.TotalDays,
            this.HolidayDays,
            this.UserId,
            this.OverTimeStart,
            this.OverTimeEnd,
            this.OTimeTotalHours});
            this.dgrAttendanceList.Location = new System.Drawing.Point(173, 100);
            this.dgrAttendanceList.Name = "dgrAttendanceList";
            this.dgrAttendanceList.ReadOnly = true;
            this.dgrAttendanceList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrAttendanceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgrAttendanceList.RowHeadersVisible = false;
            this.dgrAttendanceList.RowHeadersWidth = 15;
            this.dgrAttendanceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrAttendanceList.Size = new System.Drawing.Size(723, 374);
            this.dgrAttendanceList.TabIndex = 307;
            // 
            // Sno
            // 
            this.Sno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Sno.DataPropertyName = "Sno";
            this.Sno.HeaderText = "رقم تسلسلي";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 107;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "اسم المستخدم ";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 124;
            // 
            // UserDate
            // 
            this.UserDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserDate.DataPropertyName = "Date1";
            this.UserDate.HeaderText = "تاريخ المستخدم ";
            this.UserDate.Name = "UserDate";
            this.UserDate.ReadOnly = true;
            this.UserDate.Width = 133;
            // 
            // Day
            // 
            this.Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "يوم";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            this.Day.Width = 57;
            // 
            // EntryTime
            // 
            this.EntryTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EntryTime.DataPropertyName = "TimeStart1";
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.EntryTime.DefaultCellStyle = dataGridViewCellStyle73;
            this.EntryTime.HeaderText = "وقت الدخول ";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            this.EntryTime.Width = 114;
            // 
            // ExitTime
            // 
            this.ExitTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExitTime.DataPropertyName = "TimeEnd1";
            dataGridViewCellStyle74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ExitTime.DefaultCellStyle = dataGridViewCellStyle74;
            this.ExitTime.HeaderText = "وقت الخروج";
            this.ExitTime.Name = "ExitTime";
            this.ExitTime.ReadOnly = true;
            this.ExitTime.Width = 108;
            // 
            // TotalHours
            // 
            this.TotalHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TotalHours.DataPropertyName = "TotalHours";
            dataGridViewCellStyle75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TotalHours.DefaultCellStyle = dataGridViewCellStyle75;
            this.TotalHours.HeaderText = "اجمالي الساعات ";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.Width = 138;
            // 
            // Difference
            // 
            this.Difference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Difference.DataPropertyName = "Difference";
            dataGridViewCellStyle76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Difference.DefaultCellStyle = dataGridViewCellStyle76;
            this.Difference.HeaderText = "الفارق";
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            this.Difference.Width = 76;
            // 
            // BreakTime
            // 
            this.BreakTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BreakTime.DataPropertyName = "BreakTime";
            this.BreakTime.HeaderText = "Brake Time";
            this.BreakTime.Name = "BreakTime";
            this.BreakTime.ReadOnly = true;
            this.BreakTime.Visible = false;
            this.BreakTime.Width = 79;
            // 
            // TotalDays
            // 
            this.TotalDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TotalDays.DataPropertyName = "TotalDays";
            this.TotalDays.HeaderText = "Total Days";
            this.TotalDays.Name = "TotalDays";
            this.TotalDays.ReadOnly = true;
            this.TotalDays.Visible = false;
            this.TotalDays.Width = 77;
            // 
            // HolidayDays
            // 
            this.HolidayDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.HolidayDays.DataPropertyName = "HolidayDays";
            this.HolidayDays.HeaderText = "Holiday Days";
            this.HolidayDays.Name = "HolidayDays";
            this.HolidayDays.ReadOnly = true;
            this.HolidayDays.Visible = false;
            this.HolidayDays.Width = 87;
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "User ID";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            this.UserId.Width = 63;
            // 
            // OverTimeStart
            // 
            this.OverTimeStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OverTimeStart.DataPropertyName = "OverTimeStart";
            this.OverTimeStart.HeaderText = "MTB_OVERTIME_START";
            this.OverTimeStart.Name = "OverTimeStart";
            this.OverTimeStart.ReadOnly = true;
            this.OverTimeStart.Visible = false;
            this.OverTimeStart.Width = 159;
            // 
            // OverTimeEnd
            // 
            this.OverTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OverTimeEnd.DataPropertyName = "OverTimeEnd";
            this.OverTimeEnd.HeaderText = "MTB_OVERTIME_END";
            this.OverTimeEnd.Name = "OverTimeEnd";
            this.OverTimeEnd.ReadOnly = true;
            this.OverTimeEnd.Visible = false;
            this.OverTimeEnd.Width = 146;
            // 
            // OTimeTotalHours
            // 
            this.OTimeTotalHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OTimeTotalHours.DataPropertyName = "OTimeTotalHours";
            this.OTimeTotalHours.HeaderText = "MTB_OVERTIME_TOTAL_HOURS";
            this.OTimeTotalHours.Name = "OTimeTotalHours";
            this.OTimeTotalHours.ReadOnly = true;
            this.OTimeTotalHours.Visible = false;
            this.OTimeTotalHours.Width = 203;
            // 
            // radUserAll
            // 
            this.radUserAll.Location = new System.Drawing.Point(808, 56);
            this.radUserAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radUserAll.Name = "radUserAll";
            this.radUserAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radUserAll.Size = new System.Drawing.Size(87, 35);
            this.radUserAll.TabIndex = 7;
            this.radUserAll.Tag = "All";
            this.radUserAll.Text = "للجميع";
            this.radUserAll.UseVisualStyleBackColor = true;
            this.radUserAll.CheckedChanged += new System.EventHandler(this.Rbn_Notes_CheckedChanged);
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.DropDownWidth = 205;
            this.cmbGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(268, 61);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbGroup.MaxDropDownItems = 7;
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(205, 28);
            this.cmbGroup.TabIndex = 4;
            // 
            // radGroup
            // 
            this.radGroup.Location = new System.Drawing.Point(129, 56);
            this.radGroup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radGroup.Name = "radGroup";
            this.radGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGroup.Size = new System.Drawing.Size(135, 35);
            this.radGroup.TabIndex = 3;
            this.radGroup.Tag = "NFG";
            this.radGroup.Text = "مجموعة المستخدم";
            this.radGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radGroup.UseVisualStyleBackColor = true;
            this.radGroup.CheckedChanged += new System.EventHandler(this.Rbn_Notes_CheckedChanged);
            // 
            // radUser
            // 
            this.radUser.Location = new System.Drawing.Point(488, 59);
            this.radUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radUser.Name = "radUser";
            this.radUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radUser.Size = new System.Drawing.Size(93, 35);
            this.radUser.TabIndex = 5;
            this.radUser.Tag = "NFE";
            this.radUser.Text = "المستخدم ";
            this.radUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radUser.UseVisualStyleBackColor = true;
            this.radUser.CheckedChanged += new System.EventHandler(this.Rbn_Notes_CheckedChanged);
            // 
            // Time_Attandance_Sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(908, 556);
            this.Controls.Add(this.radUser);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.radGroup);
            this.Controls.Add(this.radUserAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtWorkingHours);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.chkDateAll);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblTotalWorkingDiff);
            this.Controls.Add(this.txtDailyAvarage);
            this.Controls.Add(this.txtWorkingDifference);
            this.Controls.Add(this.lblDailyAverage);
            this.Controls.Add(this.lblTotalWorkingHrs);
            this.Controls.Add(this.dgrAttendanceList);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Time_Attandance_Sheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Attandance Sheet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Time_Attandance_Sheet_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.time_attandance_rep_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAttendanceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnUserTracking;
        private System.Windows.Forms.Button btnUserAdmin;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPaySalary;
        private System.Windows.Forms.TextBox txtWorkingHours;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.CheckBox chkDateAll;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblTotalWorkingDiff;
        private System.Windows.Forms.TextBox txtDailyAvarage;
        private System.Windows.Forms.TextBox txtWorkingDifference;
        private System.Windows.Forms.Label lblDailyAverage;
        private System.Windows.Forms.Label lblTotalWorkingHrs;
        private System.Windows.Forms.DataGridView dgrAttendanceList;
        private System.Windows.Forms.RadioButton radUserAll;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.RadioButton radGroup;
        private System.Windows.Forms.RadioButton radUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolidayDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTimeTotalHours;
    }
}