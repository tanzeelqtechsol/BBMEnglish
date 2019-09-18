namespace BumedianBM.View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_User = new System.Windows.Forms.Label();
            this.Cmb_UserName = new System.Windows.Forms.ComboBox();
            this.Chk_DateAll = new System.Windows.Forms.CheckBox();
            this.Dtp_FromDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_ToDate = new System.Windows.Forms.Label();
            this.Lbl_FromDate = new System.Windows.Forms.Label();
            this.Dtp_ToDate = new System.Windows.Forms.DateTimePicker();
            this.Chk_UserAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Find = new System.Windows.Forms.Button();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.Btn_UserTracking = new System.Windows.Forms.Button();
            this.Btn_UserAdmin = new System.Windows.Forms.Button();
            this.Btn_New = new System.Windows.Forms.Button();
            this.Btn_PaySalary = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Dgv_AttendanceList = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrakeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HolidayDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTB_OVERTIME_START = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTB_OVERTIME_END = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTB_OVERTIME_TOTAL_HOURS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Txt_WorkingHours = new System.Windows.Forms.TextBox();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Lbl_TotalWorkingDiff = new System.Windows.Forms.Label();
            this.Txt_DailyAvarage = new System.Windows.Forms.TextBox();
            this.Txt_WorkingDifference = new System.Windows.Forms.TextBox();
            this.Lbl_DailyAverage = new System.Windows.Forms.Label();
            this.Lbl_TotalWorkingHrs = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_AttendanceList)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 751F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.91586F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.12298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.78202F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 618);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lbl_User);
            this.panel1.Controls.Add(this.Cmb_UserName);
            this.panel1.Controls.Add(this.Chk_DateAll);
            this.panel1.Controls.Add(this.Dtp_FromDate);
            this.panel1.Controls.Add(this.Lbl_ToDate);
            this.panel1.Controls.Add(this.Lbl_FromDate);
            this.panel1.Controls.Add(this.Dtp_ToDate);
            this.panel1.Controls.Add(this.Chk_UserAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(150, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 80);
            this.panel1.TabIndex = 0;
            // 
            // Lbl_User
            // 
            this.Lbl_User.AutoSize = true;
            this.Lbl_User.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_User.Location = new System.Drawing.Point(192, 45);
            this.Lbl_User.Name = "Lbl_User";
            this.Lbl_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_User.Size = new System.Drawing.Size(39, 19);
            this.Lbl_User.TabIndex = 348;
            this.Lbl_User.Text = "User";
            // 
            // Cmb_UserName
            // 
            this.Cmb_UserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Cmb_UserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_UserName.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Cmb_UserName.FormattingEnabled = true;
            this.Cmb_UserName.Location = new System.Drawing.Point(236, 42);
            this.Cmb_UserName.Name = "Cmb_UserName";
            this.Cmb_UserName.Size = new System.Drawing.Size(269, 27);
            this.Cmb_UserName.TabIndex = 344;
            // 
            // Chk_DateAll
            // 
            this.Chk_DateAll.AutoSize = true;
            this.Chk_DateAll.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Chk_DateAll.Location = new System.Drawing.Point(511, 11);
            this.Chk_DateAll.Name = "Chk_DateAll";
            this.Chk_DateAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_DateAll.Size = new System.Drawing.Size(46, 23);
            this.Chk_DateAll.TabIndex = 343;
            this.Chk_DateAll.Text = "All";
            this.Chk_DateAll.UseVisualStyleBackColor = true;
            // 
            // Dtp_FromDate
            // 
            this.Dtp_FromDate.CustomFormat = "MM/dd/yyyy";
            this.Dtp_FromDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Dtp_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FromDate.Location = new System.Drawing.Point(236, 9);
            this.Dtp_FromDate.Name = "Dtp_FromDate";
            this.Dtp_FromDate.Size = new System.Drawing.Size(96, 26);
            this.Dtp_FromDate.TabIndex = 341;
            // 
            // Lbl_ToDate
            // 
            this.Lbl_ToDate.AutoSize = true;
            this.Lbl_ToDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_ToDate.Location = new System.Drawing.Point(346, 12);
            this.Lbl_ToDate.Name = "Lbl_ToDate";
            this.Lbl_ToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_ToDate.Size = new System.Drawing.Size(61, 19);
            this.Lbl_ToDate.TabIndex = 347;
            this.Lbl_ToDate.Text = "To Date";
            // 
            // Lbl_FromDate
            // 
            this.Lbl_FromDate.AutoSize = true;
            this.Lbl_FromDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_FromDate.Location = new System.Drawing.Point(152, 12);
            this.Lbl_FromDate.Name = "Lbl_FromDate";
            this.Lbl_FromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_FromDate.Size = new System.Drawing.Size(79, 19);
            this.Lbl_FromDate.TabIndex = 346;
            this.Lbl_FromDate.Text = "From Date";
            // 
            // Dtp_ToDate
            // 
            this.Dtp_ToDate.CustomFormat = "MM/dd/yyyy";
            this.Dtp_ToDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Dtp_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_ToDate.Location = new System.Drawing.Point(410, 9);
            this.Dtp_ToDate.Name = "Dtp_ToDate";
            this.Dtp_ToDate.Size = new System.Drawing.Size(95, 26);
            this.Dtp_ToDate.TabIndex = 342;
            // 
            // Chk_UserAll
            // 
            this.Chk_UserAll.AutoSize = true;
            this.Chk_UserAll.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Chk_UserAll.Location = new System.Drawing.Point(511, 44);
            this.Chk_UserAll.Name = "Chk_UserAll";
            this.Chk_UserAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_UserAll.Size = new System.Drawing.Size(46, 23);
            this.Chk_UserAll.TabIndex = 345;
            this.Chk_UserAll.Text = "All";
            this.Chk_UserAll.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 415);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Find);
            this.groupBox1.Controls.Add(this.Btn_Print);
            this.groupBox1.Controls.Add(this.Btn_UserTracking);
            this.groupBox1.Controls.Add(this.Btn_UserAdmin);
            this.groupBox1.Controls.Add(this.Btn_New);
            this.groupBox1.Controls.Add(this.Btn_PaySalary);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-4, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 300);
            this.groupBox1.TabIndex = 334;
            this.groupBox1.TabStop = false;
            // 
            // Btn_Find
            // 
            this.Btn_Find.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Find.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Find.Image = global::BumedianBM.Properties.Resources.views_32;
            this.Btn_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Find.Location = new System.Drawing.Point(5, 9);
            this.Btn_Find.Name = "Btn_Find";
            this.Btn_Find.Size = new System.Drawing.Size(133, 46);
            this.Btn_Find.TabIndex = 0;
            this.Btn_Find.Text = "Find";
            this.Btn_Find.UseVisualStyleBackColor = false;
            // 
            // Btn_Print
            // 
            this.Btn_Print.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Print.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Print.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.Btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Print.Location = new System.Drawing.Point(5, 249);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(133, 46);
            this.Btn_Print.TabIndex = 5;
            this.Btn_Print.Text = "Print";
            this.Btn_Print.UseVisualStyleBackColor = false;
            // 
            // Btn_UserTracking
            // 
            this.Btn_UserTracking.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_UserTracking.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_UserTracking.Image = global::BumedianBM.Properties.Resources.user_tracking_32;
            this.Btn_UserTracking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_UserTracking.Location = new System.Drawing.Point(5, 201);
            this.Btn_UserTracking.Name = "Btn_UserTracking";
            this.Btn_UserTracking.Size = new System.Drawing.Size(133, 46);
            this.Btn_UserTracking.TabIndex = 4;
            this.Btn_UserTracking.Text = "User Tracking";
            this.Btn_UserTracking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_UserTracking.UseVisualStyleBackColor = false;
            // 
            // Btn_UserAdmin
            // 
            this.Btn_UserAdmin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_UserAdmin.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_UserAdmin.Image = global::BumedianBM.Properties.Resources.administrator_32;
            this.Btn_UserAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_UserAdmin.Location = new System.Drawing.Point(5, 153);
            this.Btn_UserAdmin.Name = "Btn_UserAdmin";
            this.Btn_UserAdmin.Size = new System.Drawing.Size(133, 46);
            this.Btn_UserAdmin.TabIndex = 3;
            this.Btn_UserAdmin.Text = "User Admin";
            this.Btn_UserAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_UserAdmin.UseVisualStyleBackColor = false;
            // 
            // Btn_New
            // 
            this.Btn_New.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_New.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_New.Image = global::BumedianBM.Properties.Resources.add_32;
            this.Btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_New.Location = new System.Drawing.Point(5, 57);
            this.Btn_New.Name = "Btn_New";
            this.Btn_New.Size = new System.Drawing.Size(133, 46);
            this.Btn_New.TabIndex = 1;
            this.Btn_New.Text = "New";
            this.Btn_New.UseVisualStyleBackColor = false;
            // 
            // Btn_PaySalary
            // 
            this.Btn_PaySalary.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_PaySalary.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_PaySalary.Image = global::BumedianBM.Properties.Resources.salary_32;
            this.Btn_PaySalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_PaySalary.Location = new System.Drawing.Point(5, 105);
            this.Btn_PaySalary.Name = "Btn_PaySalary";
            this.Btn_PaySalary.Size = new System.Drawing.Size(133, 46);
            this.Btn_PaySalary.TabIndex = 2;
            this.Btn_PaySalary.Text = "Salary Payment";
            this.Btn_PaySalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_PaySalary.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Dgv_AttendanceList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(150, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(745, 415);
            this.panel3.TabIndex = 2;
            // 
            // Dgv_AttendanceList
            // 
            this.Dgv_AttendanceList.AllowUserToAddRows = false;
            this.Dgv_AttendanceList.BackgroundColor = System.Drawing.Color.Beige;
            this.Dgv_AttendanceList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_AttendanceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_AttendanceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.UserName,
            this.UserDate,
            this.Day,
            this.EntryTime,
            this.ExitTime,
            this.TotalHours,
            this.UserId,
            this.Difference,
            this.BrakeTime,
            this.TotalDays,
            this.HolidayDays,
            this.MTB_OVERTIME_START,
            this.MTB_OVERTIME_END,
            this.MTB_OVERTIME_TOTAL_HOURS});
            this.Dgv_AttendanceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_AttendanceList.Location = new System.Drawing.Point(0, 0);
            this.Dgv_AttendanceList.Name = "Dgv_AttendanceList";
            this.Dgv_AttendanceList.ReadOnly = true;
            this.Dgv_AttendanceList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dgv_AttendanceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Dgv_AttendanceList.RowHeadersVisible = false;
            this.Dgv_AttendanceList.RowHeadersWidth = 15;
            this.Dgv_AttendanceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_AttendanceList.Size = new System.Drawing.Size(745, 415);
            this.Dgv_AttendanceList.TabIndex = 342;
            // 
            // Sno
            // 
            this.Sno.DataPropertyName = "Sno";
            this.Sno.HeaderText = "S.No";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sno.Width = 40;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "MTB_USER_NAME";
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserDate
            // 
            this.UserDate.DataPropertyName = "MTB_Date";
            this.UserDate.HeaderText = "UserDate";
            this.UserDate.Name = "UserDate";
            this.UserDate.ReadOnly = true;
            this.UserDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Day
            // 
            this.Day.DataPropertyName = "MTB_DAY";
            this.Day.HeaderText = "Day";
            this.Day.Name = "Day";
            this.Day.ReadOnly = true;
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Day.Width = 105;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "MTB_TIME_START";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.EntryTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.EntryTime.HeaderText = "EntryTime";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            this.EntryTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExitTime
            // 
            this.ExitTime.DataPropertyName = "MTB_TIME_END";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ExitTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExitTime.HeaderText = "ExitTime";
            this.ExitTime.Name = "ExitTime";
            this.ExitTime.ReadOnly = true;
            this.ExitTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalHours
            // 
            this.TotalHours.DataPropertyName = "MTB_TOTAL_TIME";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.TotalHours.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalHours.HeaderText = "Totalhours";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "MTB_USER_ID";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserId.Visible = false;
            // 
            // Difference
            // 
            this.Difference.DataPropertyName = "MTB_DIFFERENCE";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Difference.DefaultCellStyle = dataGridViewCellStyle4;
            this.Difference.HeaderText = "Difference";
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            this.Difference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Difference.Width = 95;
            // 
            // BrakeTime
            // 
            this.BrakeTime.DataPropertyName = "MTB_TIME_BRAKE";
            this.BrakeTime.HeaderText = "BrakeTime";
            this.BrakeTime.Name = "BrakeTime";
            this.BrakeTime.ReadOnly = true;
            this.BrakeTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BrakeTime.Visible = false;
            // 
            // TotalDays
            // 
            this.TotalDays.DataPropertyName = "TotalDays";
            this.TotalDays.HeaderText = "TotalDays";
            this.TotalDays.Name = "TotalDays";
            this.TotalDays.ReadOnly = true;
            this.TotalDays.Visible = false;
            // 
            // HolidayDays
            // 
            this.HolidayDays.DataPropertyName = "MTB_Holiday";
            this.HolidayDays.HeaderText = "HolidayDays";
            this.HolidayDays.Name = "HolidayDays";
            this.HolidayDays.ReadOnly = true;
            this.HolidayDays.Visible = false;
            // 
            // MTB_OVERTIME_START
            // 
            this.MTB_OVERTIME_START.DataPropertyName = "MTB_OVERTIME_START";
            this.MTB_OVERTIME_START.HeaderText = "MTB_OVERTIME_START";
            this.MTB_OVERTIME_START.Name = "MTB_OVERTIME_START";
            this.MTB_OVERTIME_START.ReadOnly = true;
            this.MTB_OVERTIME_START.Visible = false;
            // 
            // MTB_OVERTIME_END
            // 
            this.MTB_OVERTIME_END.DataPropertyName = "MTB_OVERTIME_END";
            this.MTB_OVERTIME_END.HeaderText = "MTB_OVERTIME_END";
            this.MTB_OVERTIME_END.Name = "MTB_OVERTIME_END";
            this.MTB_OVERTIME_END.ReadOnly = true;
            this.MTB_OVERTIME_END.Visible = false;
            // 
            // MTB_OVERTIME_TOTAL_HOURS
            // 
            this.MTB_OVERTIME_TOTAL_HOURS.DataPropertyName = "MTB_OVERTIME_TOTAL_HOURS";
            this.MTB_OVERTIME_TOTAL_HOURS.HeaderText = "MTB_OVERTIME_TOTALHOURS";
            this.MTB_OVERTIME_TOTAL_HOURS.Name = "MTB_OVERTIME_TOTAL_HOURS";
            this.MTB_OVERTIME_TOTAL_HOURS.ReadOnly = true;
            this.MTB_OVERTIME_TOTAL_HOURS.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Txt_WorkingHours);
            this.panel4.Controls.Add(this.Btn_Close);
            this.panel4.Controls.Add(this.Lbl_TotalWorkingDiff);
            this.panel4.Controls.Add(this.Txt_DailyAvarage);
            this.panel4.Controls.Add(this.Txt_WorkingDifference);
            this.panel4.Controls.Add(this.Lbl_DailyAverage);
            this.panel4.Controls.Add(this.Lbl_TotalWorkingHrs);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(150, 510);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(745, 105);
            this.panel4.TabIndex = 3;
            // 
            // Txt_WorkingHours
            // 
            this.Txt_WorkingHours.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_WorkingHours.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Txt_WorkingHours.Location = new System.Drawing.Point(142, 1);
            this.Txt_WorkingHours.Name = "Txt_WorkingHours";
            this.Txt_WorkingHours.ReadOnly = true;
            this.Txt_WorkingHours.Size = new System.Drawing.Size(100, 26);
            this.Txt_WorkingHours.TabIndex = 345;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Close.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Close.Image = global::BumedianBM.Properties.Resources.close_32;
            this.Btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Close.Location = new System.Drawing.Point(539, 1);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(133, 46);
            this.Btn_Close.TabIndex = 348;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.UseVisualStyleBackColor = false;
            // 
            // Lbl_TotalWorkingDiff
            // 
            this.Lbl_TotalWorkingDiff.AutoSize = true;
            this.Lbl_TotalWorkingDiff.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalWorkingDiff.Location = new System.Drawing.Point(257, 6);
            this.Lbl_TotalWorkingDiff.Name = "Lbl_TotalWorkingDiff";
            this.Lbl_TotalWorkingDiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalWorkingDiff.Size = new System.Drawing.Size(174, 19);
            this.Lbl_TotalWorkingDiff.TabIndex = 351;
            this.Lbl_TotalWorkingDiff.Text = "Total working difference";
            // 
            // Txt_DailyAvarage
            // 
            this.Txt_DailyAvarage.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_DailyAvarage.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Txt_DailyAvarage.Location = new System.Drawing.Point(142, 34);
            this.Txt_DailyAvarage.Name = "Txt_DailyAvarage";
            this.Txt_DailyAvarage.ReadOnly = true;
            this.Txt_DailyAvarage.Size = new System.Drawing.Size(100, 26);
            this.Txt_DailyAvarage.TabIndex = 347;
            // 
            // Txt_WorkingDifference
            // 
            this.Txt_WorkingDifference.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_WorkingDifference.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Txt_WorkingDifference.Location = new System.Drawing.Point(433, 3);
            this.Txt_WorkingDifference.Name = "Txt_WorkingDifference";
            this.Txt_WorkingDifference.ReadOnly = true;
            this.Txt_WorkingDifference.Size = new System.Drawing.Size(100, 26);
            this.Txt_WorkingDifference.TabIndex = 346;
            // 
            // Lbl_DailyAverage
            // 
            this.Lbl_DailyAverage.AutoSize = true;
            this.Lbl_DailyAverage.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_DailyAverage.Location = new System.Drawing.Point(35, 37);
            this.Lbl_DailyAverage.Name = "Lbl_DailyAverage";
            this.Lbl_DailyAverage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_DailyAverage.Size = new System.Drawing.Size(104, 19);
            this.Lbl_DailyAverage.TabIndex = 350;
            this.Lbl_DailyAverage.Text = "Daily Average";
            // 
            // Lbl_TotalWorkingHrs
            // 
            this.Lbl_TotalWorkingHrs.AutoSize = true;
            this.Lbl_TotalWorkingHrs.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalWorkingHrs.Location = new System.Drawing.Point(-3, 4);
            this.Lbl_TotalWorkingHrs.Name = "Lbl_TotalWorkingHrs";
            this.Lbl_TotalWorkingHrs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalWorkingHrs.Size = new System.Drawing.Size(143, 19);
            this.Lbl_TotalWorkingHrs.TabIndex = 349;
            this.Lbl_TotalWorkingHrs.Text = "Total working hours";
            // 
            // Time_Attandance_Sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Time_Attandance_Sheet";
            this.Text = "Time Attandance Sheet";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_AttendanceList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_User;
        private System.Windows.Forms.ComboBox Cmb_UserName;
        private System.Windows.Forms.CheckBox Chk_DateAll;
        private System.Windows.Forms.DateTimePicker Dtp_FromDate;
        private System.Windows.Forms.Label Lbl_ToDate;
        private System.Windows.Forms.Label Lbl_FromDate;
        private System.Windows.Forms.DateTimePicker Dtp_ToDate;
        private System.Windows.Forms.CheckBox Chk_UserAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Find;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.Button Btn_UserTracking;
        private System.Windows.Forms.Button Btn_UserAdmin;
        private System.Windows.Forms.Button Btn_New;
        private System.Windows.Forms.Button Btn_PaySalary;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Dgv_AttendanceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrakeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn HolidayDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_OVERTIME_START;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_OVERTIME_END;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTB_OVERTIME_TOTAL_HOURS;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Txt_WorkingHours;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Label Lbl_TotalWorkingDiff;
        private System.Windows.Forms.TextBox Txt_DailyAvarage;
        private System.Windows.Forms.TextBox Txt_WorkingDifference;
        private System.Windows.Forms.Label Lbl_DailyAverage;
        private System.Windows.Forms.Label Lbl_TotalWorkingHrs;
	}
}