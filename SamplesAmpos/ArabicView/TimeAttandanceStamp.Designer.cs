namespace BumedianBM.ArabicView
{
    partial class Entry_Time_Attandance
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entry_Time_Attandance));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAttandanceReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_EntryHour = new System.Windows.Forms.Label();
            this.lblEntryHrs = new System.Windows.Forms.Label();
            this.dgrTimeAttandance = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendTimeBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendOverTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendOverTimeBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendOverTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OverTimeTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDOverTimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDOverTimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDTimeBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendDOverTimeBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attend1Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.AttendanceTime = new System.Windows.Forms.DateTimePicker();
            this.btnStartTime = new System.Windows.Forms.Button();
            this.btnBreakTime = new System.Windows.Forms.Button();
            this.btnEndTime = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTimeAttandance)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAttandanceReport);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 419);
            this.panel3.TabIndex = 15;
            // 
            // btnAttandanceReport
            // 
            this.btnAttandanceReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAttandanceReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttandanceReport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnAttandanceReport.Image = global::BumedianBM.Properties.Resources.renteing_sheet_32;
            this.btnAttandanceReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttandanceReport.Location = new System.Drawing.Point(0, 154);
            this.btnAttandanceReport.Name = "btnAttandanceReport";
            this.btnAttandanceReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAttandanceReport.Size = new System.Drawing.Size(150, 50);
            this.btnAttandanceReport.TabIndex = 8;
            this.btnAttandanceReport.Tag = "AttReport";
            this.btnAttandanceReport.Text = "تقرير الحضور";
            this.btnAttandanceReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttandanceReport.UseVisualStyleBackColor = false;
            this.btnAttandanceReport.Click += new System.EventHandler(this.btnAttandanceReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(0, 104);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.Size = new System.Drawing.Size(150, 50);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 9;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lbl_EntryHour);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(160, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(857, 40);
            this.panel2.TabIndex = 14;
            // 
            // Lbl_EntryHour
            // 
            this.Lbl_EntryHour.AutoSize = true;
            this.Lbl_EntryHour.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_EntryHour.Location = new System.Drawing.Point(532, 20);
            this.Lbl_EntryHour.Name = "Lbl_EntryHour";
            this.Lbl_EntryHour.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_EntryHour.Size = new System.Drawing.Size(0, 18);
            this.Lbl_EntryHour.TabIndex = 145;
            // 
            // lblEntryHrs
            // 
            this.lblEntryHrs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEntryHrs.AutoSize = true;
            this.lblEntryHrs.Font = new System.Drawing.Font("Simplified Arabic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryHrs.Location = new System.Drawing.Point(3, 549);
            this.lblEntryHrs.Name = "lblEntryHrs";
            this.lblEntryHrs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEntryHrs.Size = new System.Drawing.Size(70, 23);
            this.lblEntryHrs.TabIndex = 146;
            this.lblEntryHrs.Tag = "EntryHrs";
            this.lblEntryHrs.Text = "ساعة الدخول ";
            // 
            // dgrTimeAttandance
            // 
            this.dgrTimeAttandance.AllowUserToAddRows = false;
            this.dgrTimeAttandance.AllowUserToResizeColumns = false;
            this.dgrTimeAttandance.AllowUserToResizeRows = false;
            this.dgrTimeAttandance.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrTimeAttandance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrTimeAttandance.ColumnHeadersHeight = 32;
            this.dgrTimeAttandance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.AttendUserName,
            this.AttendDate,
            this.AttendTimeStart,
            this.AttendTimeBreak,
            this.AttendTimeEnd,
            this.AttendOverTimeStart,
            this.AttendOverTimeBreak,
            this.AttendOverTimeEnd,
            this.OverTimeTotal,
            this.TotalTime,
            this.AttendDTimeStart,
            this.AttendDTimeEnd,
            this.AttendDOverTimeStart,
            this.AttendDOverTimeEnd,
            this.AttendDTimeBreak,
            this.AttendDOverTimeBreak,
            this.Attend1Date});
            this.dgrTimeAttandance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrTimeAttandance.Location = new System.Drawing.Point(160, 116);
            this.dgrTimeAttandance.Name = "dgrTimeAttandance";
            this.dgrTimeAttandance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgrTimeAttandance.RowHeadersVisible = false;
            this.dgrTimeAttandance.RowHeadersWidth = 15;
            this.dgrTimeAttandance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrTimeAttandance.Size = new System.Drawing.Size(857, 419);
            this.dgrTimeAttandance.TabIndex = 150;
            // 
            // User_ID
            // 
            this.User_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.User_ID.DataPropertyName = "UserId";
            this.User_ID.HeaderText = "رقم المستخدم ";
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Width = 120;
            // 
            // AttendUserName
            // 
            this.AttendUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AttendUserName.DataPropertyName = "UserName";
            this.AttendUserName.HeaderText = "الاسم";
            this.AttendUserName.Name = "AttendUserName";
            this.AttendUserName.ReadOnly = true;
            this.AttendUserName.Width = 69;
            // 
            // AttendDate
            // 
            this.AttendDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.AttendDate.DataPropertyName = "Date1";
            this.AttendDate.HeaderText = "التاريخ";
            this.AttendDate.Name = "AttendDate";
            this.AttendDate.ReadOnly = true;
            this.AttendDate.Width = 77;
            // 
            // AttendTimeStart
            // 
            this.AttendTimeStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendTimeStart.DataPropertyName = "TimeStart1";
            this.AttendTimeStart.HeaderText = "بداية العمل";
            this.AttendTimeStart.Name = "AttendTimeStart";
            this.AttendTimeStart.ReadOnly = true;
            this.AttendTimeStart.Width = 101;
            // 
            // AttendTimeBreak
            // 
            this.AttendTimeBreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendTimeBreak.DataPropertyName = "TimeBreak1";
            this.AttendTimeBreak.HeaderText = "استراحة";
            this.AttendTimeBreak.Name = "AttendTimeBreak";
            this.AttendTimeBreak.ReadOnly = true;
            this.AttendTimeBreak.Width = 83;
            // 
            // AttendTimeEnd
            // 
            this.AttendTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendTimeEnd.DataPropertyName = "TimeEnd1";
            this.AttendTimeEnd.HeaderText = "نهاية العمل";
            this.AttendTimeEnd.Name = "AttendTimeEnd";
            this.AttendTimeEnd.ReadOnly = true;
            this.AttendTimeEnd.Width = 103;
            // 
            // AttendOverTimeStart
            // 
            this.AttendOverTimeStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendOverTimeStart.DataPropertyName = "OverTimeStart1";
            this.AttendOverTimeStart.HeaderText = "بداية الوقت الاضافي";
            this.AttendOverTimeStart.Name = "AttendOverTimeStart";
            this.AttendOverTimeStart.ReadOnly = true;
            this.AttendOverTimeStart.Width = 156;
            // 
            // AttendOverTimeBreak
            // 
            this.AttendOverTimeBreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendOverTimeBreak.DataPropertyName = "OverTimeBreak1";
            this.AttendOverTimeBreak.HeaderText = "استراحة الوقت الاضافي";
            this.AttendOverTimeBreak.Name = "AttendOverTimeBreak";
            this.AttendOverTimeBreak.ReadOnly = true;
            this.AttendOverTimeBreak.Width = 173;
            // 
            // AttendOverTimeEnd
            // 
            this.AttendOverTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendOverTimeEnd.DataPropertyName = "OverTimeEnd1";
            this.AttendOverTimeEnd.HeaderText = "انتهاء الاضافي";
            this.AttendOverTimeEnd.Name = "AttendOverTimeEnd";
            this.AttendOverTimeEnd.ReadOnly = true;
            this.AttendOverTimeEnd.Width = 125;
            // 
            // OverTimeTotal
            // 
            this.OverTimeTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OverTimeTotal.DataPropertyName = "MTB_OVERTIME_TOTAL_HOURS";
            this.OverTimeTotal.HeaderText = "OverTime Total";
            this.OverTimeTotal.Name = "OverTimeTotal";
            this.OverTimeTotal.ReadOnly = true;
            this.OverTimeTotal.Visible = false;
            this.OverTimeTotal.Width = 159;
            // 
            // TotalTime
            // 
            this.TotalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TotalTime.DataPropertyName = "MTB_TOTAL_HOURS";
            this.TotalTime.HeaderText = "Total Work Hours";
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.ReadOnly = true;
            this.TotalTime.Visible = false;
            this.TotalTime.Width = 177;
            // 
            // AttendDTimeStart
            // 
            this.AttendDTimeStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDTimeStart.DataPropertyName = "DTimeStart";
            this.AttendDTimeStart.HeaderText = "MTB_DTIME_START";
            this.AttendDTimeStart.Name = "AttendDTimeStart";
            this.AttendDTimeStart.ReadOnly = true;
            this.AttendDTimeStart.Visible = false;
            this.AttendDTimeStart.Width = 198;
            // 
            // AttendDTimeEnd
            // 
            this.AttendDTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDTimeEnd.DataPropertyName = "DTimeEnd";
            this.AttendDTimeEnd.HeaderText = "MTB_DTIME_END";
            this.AttendDTimeEnd.Name = "AttendDTimeEnd";
            this.AttendDTimeEnd.ReadOnly = true;
            this.AttendDTimeEnd.Visible = false;
            this.AttendDTimeEnd.Width = 178;
            // 
            // AttendDOverTimeStart
            // 
            this.AttendDOverTimeStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDOverTimeStart.DataPropertyName = "DOverTimeStart";
            this.AttendDOverTimeStart.HeaderText = "MTB_DOVERTIME_START";
            this.AttendDOverTimeStart.Name = "AttendDOverTimeStart";
            this.AttendDOverTimeStart.ReadOnly = true;
            this.AttendDOverTimeStart.Visible = false;
            this.AttendDOverTimeStart.Width = 245;
            // 
            // AttendDOverTimeEnd
            // 
            this.AttendDOverTimeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDOverTimeEnd.DataPropertyName = "DOverTimeEnd";
            this.AttendDOverTimeEnd.HeaderText = "MTB_DOVERTIME_END";
            this.AttendDOverTimeEnd.Name = "AttendDOverTimeEnd";
            this.AttendDOverTimeEnd.ReadOnly = true;
            this.AttendDOverTimeEnd.Visible = false;
            this.AttendDOverTimeEnd.Width = 225;
            // 
            // AttendDTimeBreak
            // 
            this.AttendDTimeBreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDTimeBreak.DataPropertyName = "DTimeBreak";
            this.AttendDTimeBreak.HeaderText = "MTB_DTIME_BRAKE";
            this.AttendDTimeBreak.Name = "AttendDTimeBreak";
            this.AttendDTimeBreak.ReadOnly = true;
            this.AttendDTimeBreak.Visible = false;
            this.AttendDTimeBreak.Width = 202;
            // 
            // AttendDOverTimeBreak
            // 
            this.AttendDOverTimeBreak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AttendDOverTimeBreak.DataPropertyName = "DOverTimeBreak";
            this.AttendDOverTimeBreak.HeaderText = "MTB_DOVERTIME_BRAKE";
            this.AttendDOverTimeBreak.Name = "AttendDOverTimeBreak";
            this.AttendDOverTimeBreak.ReadOnly = true;
            this.AttendDOverTimeBreak.Visible = false;
            this.AttendDOverTimeBreak.Width = 249;
            // 
            // Attend1Date
            // 
            this.Attend1Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Attend1Date.DataPropertyName = "Date";
            this.Attend1Date.HeaderText = "MTB_DDATE";
            this.Attend1Date.Name = "Attend1Date";
            this.Attend1Date.Visible = false;
            this.Attend1Date.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.cmbUserName);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.AttendanceTime);
            this.panel1.Controls.Add(this.btnStartTime);
            this.panel1.Controls.Add(this.btnBreakTime);
            this.panel1.Controls.Add(this.btnEndTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(160, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 107);
            this.panel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(178, 2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(99, 31);
            this.lblUserName.TabIndex = 158;
            this.lblUserName.Tag = "UserName";
            this.lblUserName.Text = "اسم المستخدم ";
            // 
            // cmbUserName
            // 
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(281, 3);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbUserName.Size = new System.Drawing.Size(298, 28);
            this.cmbUserName.TabIndex = 1;
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.Cmb_UserName_SelectedIndexChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(182, 68);
            this.lblTime.Name = "lblTime";
            this.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTime.Size = new System.Drawing.Size(52, 31);
            this.lblTime.TabIndex = 157;
            this.lblTime.Tag = "Time";
            this.lblTime.Text = "الوقت ";
            // 
            // AttendanceTime
            // 
            this.AttendanceTime.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendanceTime.CustomFormat = "hh:mm tt";
            this.AttendanceTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.AttendanceTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttendanceTime.Location = new System.Drawing.Point(240, 68);
            this.AttendanceTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.AttendanceTime.Name = "AttendanceTime";
            this.AttendanceTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AttendanceTime.ShowUpDown = true;
            this.AttendanceTime.Size = new System.Drawing.Size(110, 26);
            this.AttendanceTime.TabIndex = 3;
            this.AttendanceTime.Value = new System.DateTime(2008, 9, 6, 0, 0, 0, 0);
            // 
            // btnStartTime
            // 
            this.btnStartTime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnStartTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnStartTime.Image = ((System.Drawing.Image)(resources.GetObject("btnStartTime.Image")));
            this.btnStartTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartTime.Location = new System.Drawing.Point(361, 34);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStartTime.Size = new System.Drawing.Size(108, 70);
            this.btnStartTime.TabIndex = 4;
            this.btnStartTime.Tag = "ST";
            this.btnStartTime.Text = "بداية العمل";
            this.btnStartTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartTime.UseVisualStyleBackColor = false;
            this.btnStartTime.Click += new System.EventHandler(this.btnStartTime_Click);
            // 
            // btnBreakTime
            // 
            this.btnBreakTime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBreakTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBreakTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBreakTime.Image = ((System.Drawing.Image)(resources.GetObject("btnBreakTime.Image")));
            this.btnBreakTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBreakTime.Location = new System.Drawing.Point(470, 34);
            this.btnBreakTime.Name = "btnBreakTime";
            this.btnBreakTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBreakTime.Size = new System.Drawing.Size(108, 70);
            this.btnBreakTime.TabIndex = 5;
            this.btnBreakTime.Tag = "BT";
            this.btnBreakTime.Text = "استراحة";
            this.btnBreakTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBreakTime.UseVisualStyleBackColor = false;
            this.btnBreakTime.Click += new System.EventHandler(this.btnBreakTime_Click);
            // 
            // btnEndTime
            // 
            this.btnEndTime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEndTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnEndTime.Image = ((System.Drawing.Image)(resources.GetObject("btnEndTime.Image")));
            this.btnEndTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndTime.Location = new System.Drawing.Point(579, 34);
            this.btnEndTime.Name = "btnEndTime";
            this.btnEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEndTime.Size = new System.Drawing.Size(108, 70);
            this.btnEndTime.TabIndex = 6;
            this.btnEndTime.Tag = "ET";
            this.btnEndTime.Text = "نهاية العمل";
            this.btnEndTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndTime.UseVisualStyleBackColor = false;
            this.btnEndTime.Click += new System.EventHandler(this.btnEndTime_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(186, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 156;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(240, 36);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(110, 26);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Value = new System.DateTime(2008, 9, 18, 0, 0, 0, 0);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.63741F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.3626F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgrTimeAttandance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEntryHrs, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.52055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.94521F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.70548F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 584);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Entry_Time_Attandance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1020, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Entry_Time_Attandance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Time Attandance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Entry_Time_Attandance_FormClosing);
            this.Load += new System.EventHandler(this.Entry_Time_Attandance_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTimeAttandance)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAttandanceReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_EntryHour;
        private System.Windows.Forms.Label lblEntryHrs;
        private System.Windows.Forms.DataGridView dgrTimeAttandance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker AttendanceTime;
        private System.Windows.Forms.Button btnStartTime;
        private System.Windows.Forms.Button btnBreakTime;
        private System.Windows.Forms.Button btnEndTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendTimeBreak;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendOverTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendOverTimeBreak;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendOverTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn OverTimeTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDOverTimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDOverTimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDTimeBreak;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendDOverTimeBreak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attend1Date;

    }
}