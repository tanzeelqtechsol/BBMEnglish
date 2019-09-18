namespace BumedianBM.View
{
    partial class BalanceSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceSheet));
            this.dtp_fromtime = new System.Windows.Forms.DateTimePicker();
            this.Lbl_ToTime = new System.Windows.Forms.Label();
            this.Lbl_FromTime = new System.Windows.Forms.Label();
            this.Lbl_PageNo = new System.Windows.Forms.Label();
            this.Cmb_AgentName = new System.Windows.Forms.ComboBox();
            this.Dtp_FromDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_AgentNo = new System.Windows.Forms.Label();
            this.lbl_BSForAgent = new System.Windows.Forms.Label();
            this.Chk_All = new System.Windows.Forms.CheckBox();
            this.Cmb_AgentID = new System.Windows.Forms.ComboBox();
            this.dtp_totime = new System.Windows.Forms.DateTimePicker();
            this.Dtp_ToDate = new System.Windows.Forms.DateTimePicker();
            this.Lbl_ToDate = new System.Windows.Forms.Label();
            this.Lbl_FromDate = new System.Windows.Forms.Label();
            this.Dgv_BalanceSheet = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewYearNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_OpenRecipt = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_AgentDetails = new System.Windows.Forms.Button();
            this.Btn_Reports = new System.Windows.Forms.Button();
            this.Btn_EndOfTheDay = new System.Windows.Forms.Button();
            this.Btn_ReturnItems = new System.Windows.Forms.Button();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.Btn_OpenInvoice = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Txt_TotalPaid = new System.Windows.Forms.MaskedTextBox();
            this.Txt_Balance = new System.Windows.Forms.MaskedTextBox();
            this.Txt_TotalDiscounts = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_TotalDiscount = new System.Windows.Forms.Label();
            this.Txt_TotalRecived = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_TotalPayable = new System.Windows.Forms.Label();
            this.Lbl_TotalReceivable = new System.Windows.Forms.Label();
            this.Lbl_Balance = new System.Windows.Forms.Label();
            this.btnForward = new System.Windows.Forms.Button();
            this.Btn_PayMoneyRecipt = new System.Windows.Forms.Button();
            this.Btn_ReciveMoneyRecipt = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.Btn_Previous = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_BalanceSheet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_fromtime
            // 
            this.dtp_fromtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_fromtime.Location = new System.Drawing.Point(180, 86);
            this.dtp_fromtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_fromtime.Name = "dtp_fromtime";
            this.dtp_fromtime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp_fromtime.RightToLeftLayout = true;
            this.dtp_fromtime.Size = new System.Drawing.Size(161, 26);
            this.dtp_fromtime.TabIndex = 338;
            // 
            // Lbl_ToTime
            // 
            this.Lbl_ToTime.AutoSize = true;
            this.Lbl_ToTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_ToTime.Location = new System.Drawing.Point(502, 92);
            this.Lbl_ToTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_ToTime.Name = "Lbl_ToTime";
            this.Lbl_ToTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_ToTime.Size = new System.Drawing.Size(63, 19);
            this.Lbl_ToTime.TabIndex = 337;
            this.Lbl_ToTime.Text = "To Time";
            // 
            // Lbl_FromTime
            // 
            this.Lbl_FromTime.AutoSize = true;
            this.Lbl_FromTime.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_FromTime.Location = new System.Drawing.Point(91, 92);
            this.Lbl_FromTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_FromTime.Name = "Lbl_FromTime";
            this.Lbl_FromTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_FromTime.Size = new System.Drawing.Size(81, 19);
            this.Lbl_FromTime.TabIndex = 335;
            this.Lbl_FromTime.Text = "From Time";
            // 
            // Lbl_PageNo
            // 
            this.Lbl_PageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PageNo.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PageNo.Location = new System.Drawing.Point(776, 24);
            this.Lbl_PageNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_PageNo.Name = "Lbl_PageNo";
            this.Lbl_PageNo.Size = new System.Drawing.Size(156, 45);
            this.Lbl_PageNo.TabIndex = 330;
            this.Lbl_PageNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cmb_AgentName
            // 
            this.Cmb_AgentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_AgentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_AgentName.FormattingEnabled = true;
            this.Cmb_AgentName.Location = new System.Drawing.Point(180, 7);
            this.Cmb_AgentName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cmb_AgentName.Name = "Cmb_AgentName";
            this.Cmb_AgentName.Size = new System.Drawing.Size(271, 27);
            this.Cmb_AgentName.TabIndex = 315;
            // 
            // Dtp_FromDate
            // 
            this.Dtp_FromDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Dtp_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FromDate.Location = new System.Drawing.Point(180, 49);
            this.Dtp_FromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Dtp_FromDate.Name = "Dtp_FromDate";
            this.Dtp_FromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_FromDate.RightToLeftLayout = true;
            this.Dtp_FromDate.Size = new System.Drawing.Size(161, 26);
            this.Dtp_FromDate.TabIndex = 314;
            // 
            // Lbl_AgentNo
            // 
            this.Lbl_AgentNo.AutoSize = true;
            this.Lbl_AgentNo.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_AgentNo.Location = new System.Drawing.Point(459, 10);
            this.Lbl_AgentNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_AgentNo.Name = "Lbl_AgentNo";
            this.Lbl_AgentNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_AgentNo.Size = new System.Drawing.Size(108, 19);
            this.Lbl_AgentNo.TabIndex = 316;
            this.Lbl_AgentNo.Text = "Agent Number";
            // 
            // lbl_BSForAgent
            // 
            this.lbl_BSForAgent.AutoSize = true;
            this.lbl_BSForAgent.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lbl_BSForAgent.Location = new System.Drawing.Point(2, 10);
            this.lbl_BSForAgent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_BSForAgent.Name = "lbl_BSForAgent";
            this.lbl_BSForAgent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_BSForAgent.Size = new System.Drawing.Size(170, 19);
            this.lbl_BSForAgent.TabIndex = 310;
            this.lbl_BSForAgent.Text = "Balance Sheet for Agent";
            // 
            // Chk_All
            // 
            this.Chk_All.AutoSize = true;
            this.Chk_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_All.Location = new System.Drawing.Point(742, 51);
            this.Chk_All.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chk_All.Name = "Chk_All";
            this.Chk_All.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Chk_All.Size = new System.Drawing.Size(37, 17);
            this.Chk_All.TabIndex = 318;
            this.Chk_All.Text = "All";
            this.Chk_All.UseVisualStyleBackColor = true;
            // 
            // Cmb_AgentID
            // 
            this.Cmb_AgentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_AgentID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_AgentID.FormattingEnabled = true;
            this.Cmb_AgentID.Location = new System.Drawing.Point(573, 8);
            this.Cmb_AgentID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cmb_AgentID.MaxLength = 15;
            this.Cmb_AgentID.Name = "Cmb_AgentID";
            this.Cmb_AgentID.Size = new System.Drawing.Size(161, 27);
            this.Cmb_AgentID.TabIndex = 317;
            // 
            // dtp_totime
            // 
            this.dtp_totime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_totime.Location = new System.Drawing.Point(573, 86);
            this.dtp_totime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtp_totime.Name = "dtp_totime";
            this.dtp_totime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp_totime.RightToLeftLayout = true;
            this.dtp_totime.Size = new System.Drawing.Size(161, 26);
            this.dtp_totime.TabIndex = 336;
            // 
            // Dtp_ToDate
            // 
            this.Dtp_ToDate.CustomFormat = "MM/dd/yyyy";
            this.Dtp_ToDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Dtp_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_ToDate.Location = new System.Drawing.Point(573, 49);
            this.Dtp_ToDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Dtp_ToDate.Name = "Dtp_ToDate";
            this.Dtp_ToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_ToDate.RightToLeftLayout = true;
            this.Dtp_ToDate.Size = new System.Drawing.Size(161, 26);
            this.Dtp_ToDate.TabIndex = 312;
            // 
            // Lbl_ToDate
            // 
            this.Lbl_ToDate.AutoSize = true;
            this.Lbl_ToDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_ToDate.Location = new System.Drawing.Point(502, 55);
            this.Lbl_ToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_ToDate.Name = "Lbl_ToDate";
            this.Lbl_ToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_ToDate.Size = new System.Drawing.Size(61, 19);
            this.Lbl_ToDate.TabIndex = 313;
            this.Lbl_ToDate.Text = "To Date";
            // 
            // Lbl_FromDate
            // 
            this.Lbl_FromDate.AutoSize = true;
            this.Lbl_FromDate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_FromDate.Location = new System.Drawing.Point(91, 50);
            this.Lbl_FromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_FromDate.Name = "Lbl_FromDate";
            this.Lbl_FromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_FromDate.Size = new System.Drawing.Size(79, 19);
            this.Lbl_FromDate.TabIndex = 311;
            this.Lbl_FromDate.Text = "Form Date";
            // 
            // Dgv_BalanceSheet
            // 
            this.Dgv_BalanceSheet.AllowUserToAddRows = false;
            this.Dgv_BalanceSheet.AllowUserToDeleteRows = false;
            this.Dgv_BalanceSheet.AllowUserToResizeColumns = false;
            this.Dgv_BalanceSheet.AllowUserToResizeRows = false;
            this.Dgv_BalanceSheet.BackgroundColor = System.Drawing.Color.Beige;
            this.Dgv_BalanceSheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_BalanceSheet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_BalanceSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Account,
            this.NewYearNo,
            this.Receivable,
            this.Payable,
            this.Balance,
            this.Discription});
            this.Dgv_BalanceSheet.GridColor = System.Drawing.SystemColors.Control;
            this.Dgv_BalanceSheet.Location = new System.Drawing.Point(162, 130);
            this.Dgv_BalanceSheet.Name = "Dgv_BalanceSheet";
            this.Dgv_BalanceSheet.ReadOnly = true;
            this.Dgv_BalanceSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dgv_BalanceSheet.RowHeadersVisible = false;
            this.Dgv_BalanceSheet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Dgv_BalanceSheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_BalanceSheet.Size = new System.Drawing.Size(772, 469);
            this.Dgv_BalanceSheet.TabIndex = 350;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 10;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 65;
            // 
            // Account
            // 
            this.Account.DataPropertyName = "Account";
            this.Account.HeaderText = "Account Number";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // NewYearNo
            // 
            this.NewYearNo.DataPropertyName = "NewYearNo";
            this.NewYearNo.HeaderText = "Description";
            this.NewYearNo.Name = "NewYearNo";
            this.NewYearNo.ReadOnly = true;
            this.NewYearNo.Width = 250;
            // 
            // Receivable
            // 
            this.Receivable.DataPropertyName = "Receivable";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Receivable.DefaultCellStyle = dataGridViewCellStyle2;
            this.Receivable.HeaderText = " Receivable";
            this.Receivable.Name = "Receivable";
            this.Receivable.ReadOnly = true;
            // 
            // Payable
            // 
            this.Payable.DataPropertyName = "Payable";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Payable.DefaultCellStyle = dataGridViewCellStyle3;
            this.Payable.HeaderText = " Payable";
            this.Payable.Name = "Payable";
            this.Payable.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Balance.DataPropertyName = "Balance";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle4;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Discription
            // 
            this.Discription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Discription.DataPropertyName = "Discription";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Discription.DefaultCellStyle = dataGridViewCellStyle5;
            this.Discription.HeaderText = "Description";
            this.Discription.Name = "Discription";
            this.Discription.ReadOnly = true;
            this.Discription.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_OpenRecipt);
            this.groupBox2.Controls.Add(this.Btn_Close);
            this.groupBox2.Controls.Add(this.Btn_AgentDetails);
            this.groupBox2.Controls.Add(this.Btn_Reports);
            this.groupBox2.Controls.Add(this.Btn_EndOfTheDay);
            this.groupBox2.Controls.Add(this.Btn_ReturnItems);
            this.groupBox2.Controls.Add(this.Btn_Print);
            this.groupBox2.Controls.Add(this.Btn_OpenInvoice);
            this.groupBox2.Controls.Add(this.Btn_Search);
            this.groupBox2.Location = new System.Drawing.Point(0, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 477);
            this.groupBox2.TabIndex = 340;
            this.groupBox2.TabStop = false;
            // 
            // Btn_OpenRecipt
            // 
            this.Btn_OpenRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_OpenRecipt.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_OpenRecipt.Image = ((System.Drawing.Image)(resources.GetObject("Btn_OpenRecipt.Image")));
            this.Btn_OpenRecipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_OpenRecipt.Location = new System.Drawing.Point(6, 119);
            this.Btn_OpenRecipt.Name = "Btn_OpenRecipt";
            this.Btn_OpenRecipt.Size = new System.Drawing.Size(146, 46);
            this.Btn_OpenRecipt.TabIndex = 14;
            this.Btn_OpenRecipt.Text = "       Open Receipt";
            this.Btn_OpenRecipt.UseVisualStyleBackColor = false;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Close.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Close.Image = global::BumedianBM.Properties.Resources.close_32;
            this.Btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Close.Location = new System.Drawing.Point(6, 419);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(146, 46);
            this.Btn_Close.TabIndex = 13;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.UseVisualStyleBackColor = false;
            // 
            // Btn_AgentDetails
            // 
            this.Btn_AgentDetails.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_AgentDetails.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_AgentDetails.Image = global::BumedianBM.Properties.Resources.agents_32;
            this.Btn_AgentDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_AgentDetails.Location = new System.Drawing.Point(6, 269);
            this.Btn_AgentDetails.Name = "Btn_AgentDetails";
            this.Btn_AgentDetails.Size = new System.Drawing.Size(146, 46);
            this.Btn_AgentDetails.TabIndex = 10;
            this.Btn_AgentDetails.Text = "      Agent Details";
            this.Btn_AgentDetails.UseVisualStyleBackColor = false;
            // 
            // Btn_Reports
            // 
            this.Btn_Reports.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Reports.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Reports.Image = global::BumedianBM.Properties.Resources.reports2_32;
            this.Btn_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Reports.Location = new System.Drawing.Point(6, 319);
            this.Btn_Reports.Name = "Btn_Reports";
            this.Btn_Reports.Size = new System.Drawing.Size(146, 46);
            this.Btn_Reports.TabIndex = 8;
            this.Btn_Reports.Text = "Reports";
            this.Btn_Reports.UseVisualStyleBackColor = false;
            // 
            // Btn_EndOfTheDay
            // 
            this.Btn_EndOfTheDay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_EndOfTheDay.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_EndOfTheDay.Image = global::BumedianBM.Properties.Resources.end_of_day_32;
            this.Btn_EndOfTheDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_EndOfTheDay.Location = new System.Drawing.Point(6, 369);
            this.Btn_EndOfTheDay.Name = "Btn_EndOfTheDay";
            this.Btn_EndOfTheDay.Size = new System.Drawing.Size(146, 46);
            this.Btn_EndOfTheDay.TabIndex = 7;
            this.Btn_EndOfTheDay.Text = "       End of the day";
            this.Btn_EndOfTheDay.UseVisualStyleBackColor = false;
            // 
            // Btn_ReturnItems
            // 
            this.Btn_ReturnItems.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_ReturnItems.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_ReturnItems.Image = global::BumedianBM.Properties.Resources.return_item_32;
            this.Btn_ReturnItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_ReturnItems.Location = new System.Drawing.Point(6, 219);
            this.Btn_ReturnItems.Name = "Btn_ReturnItems";
            this.Btn_ReturnItems.Size = new System.Drawing.Size(146, 46);
            this.Btn_ReturnItems.TabIndex = 5;
            this.Btn_ReturnItems.Text = "      Return Items";
            this.Btn_ReturnItems.UseVisualStyleBackColor = false;
            // 
            // Btn_Print
            // 
            this.Btn_Print.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Print.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Print.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.Btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Print.Location = new System.Drawing.Point(6, 169);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(146, 46);
            this.Btn_Print.TabIndex = 4;
            this.Btn_Print.Text = "Print";
            this.Btn_Print.UseVisualStyleBackColor = false;
            // 
            // Btn_OpenInvoice
            // 
            this.Btn_OpenInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_OpenInvoice.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_OpenInvoice.Image = ((System.Drawing.Image)(resources.GetObject("Btn_OpenInvoice.Image")));
            this.Btn_OpenInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_OpenInvoice.Location = new System.Drawing.Point(6, 69);
            this.Btn_OpenInvoice.Name = "Btn_OpenInvoice";
            this.Btn_OpenInvoice.Size = new System.Drawing.Size(146, 46);
            this.Btn_OpenInvoice.TabIndex = 3;
            this.Btn_OpenInvoice.Text = "      Open Invoice";
            this.Btn_OpenInvoice.UseVisualStyleBackColor = false;
            // 
            // Btn_Search
            // 
            this.Btn_Search.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Search.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_Search.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Search.Image")));
            this.Btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Search.Location = new System.Drawing.Point(6, 19);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(146, 46);
            this.Btn_Search.TabIndex = 2;
            this.Btn_Search.Text = "Search";
            this.Btn_Search.UseVisualStyleBackColor = false;
            // 
            // Txt_TotalPaid
            // 
            this.Txt_TotalPaid.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_TotalPaid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_TotalPaid.Location = new System.Drawing.Point(463, 605);
            this.Txt_TotalPaid.Name = "Txt_TotalPaid";
            this.Txt_TotalPaid.ReadOnly = true;
            this.Txt_TotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_TotalPaid.Size = new System.Drawing.Size(93, 27);
            this.Txt_TotalPaid.TabIndex = 349;
            // 
            // Txt_Balance
            // 
            this.Txt_Balance.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_Balance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Balance.Location = new System.Drawing.Point(630, 605);
            this.Txt_Balance.Name = "Txt_Balance";
            this.Txt_Balance.ReadOnly = true;
            this.Txt_Balance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Balance.Size = new System.Drawing.Size(93, 27);
            this.Txt_Balance.TabIndex = 348;
            // 
            // Txt_TotalDiscounts
            // 
            this.Txt_TotalDiscounts.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_TotalDiscounts.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_TotalDiscounts.Location = new System.Drawing.Point(841, 605);
            this.Txt_TotalDiscounts.Name = "Txt_TotalDiscounts";
            this.Txt_TotalDiscounts.ReadOnly = true;
            this.Txt_TotalDiscounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_TotalDiscounts.Size = new System.Drawing.Size(93, 27);
            this.Txt_TotalDiscounts.TabIndex = 346;
            // 
            // Lbl_TotalDiscount
            // 
            this.Lbl_TotalDiscount.AutoSize = true;
            this.Lbl_TotalDiscount.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalDiscount.Location = new System.Drawing.Point(732, 609);
            this.Lbl_TotalDiscount.Name = "Lbl_TotalDiscount";
            this.Lbl_TotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalDiscount.Size = new System.Drawing.Size(104, 19);
            this.Lbl_TotalDiscount.TabIndex = 344;
            this.Lbl_TotalDiscount.Text = "Total Discount";
            // 
            // Txt_TotalRecived
            // 
            this.Txt_TotalRecived.BackColor = System.Drawing.SystemColors.Window;
            this.Txt_TotalRecived.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_TotalRecived.Location = new System.Drawing.Point(254, 605);
            this.Txt_TotalRecived.Name = "Txt_TotalRecived";
            this.Txt_TotalRecived.ReadOnly = true;
            this.Txt_TotalRecived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_TotalRecived.Size = new System.Drawing.Size(93, 27);
            this.Txt_TotalRecived.TabIndex = 341;
            // 
            // Lbl_TotalPayable
            // 
            this.Lbl_TotalPayable.AutoSize = true;
            this.Lbl_TotalPayable.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalPayable.Location = new System.Drawing.Point(359, 609);
            this.Lbl_TotalPayable.Name = "Lbl_TotalPayable";
            this.Lbl_TotalPayable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalPayable.Size = new System.Drawing.Size(101, 19);
            this.Lbl_TotalPayable.TabIndex = 343;
            this.Lbl_TotalPayable.Text = "Total Payable";
            // 
            // Lbl_TotalReceivable
            // 
            this.Lbl_TotalReceivable.AutoSize = true;
            this.Lbl_TotalReceivable.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_TotalReceivable.Location = new System.Drawing.Point(130, 609);
            this.Lbl_TotalReceivable.Name = "Lbl_TotalReceivable";
            this.Lbl_TotalReceivable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_TotalReceivable.Size = new System.Drawing.Size(124, 19);
            this.Lbl_TotalReceivable.TabIndex = 342;
            this.Lbl_TotalReceivable.Text = "Total Receivable ";
            // 
            // Lbl_Balance
            // 
            this.Lbl_Balance.AutoSize = true;
            this.Lbl_Balance.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_Balance.Location = new System.Drawing.Point(565, 609);
            this.Lbl_Balance.Name = "Lbl_Balance";
            this.Lbl_Balance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Lbl_Balance.Size = new System.Drawing.Size(61, 19);
            this.Lbl_Balance.TabIndex = 345;
            this.Lbl_Balance.Text = "Balance";
            // 
            // btnForward
            // 
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.ForeColor = System.Drawing.SystemColors.Control;
            this.btnForward.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnForward.Location = new System.Drawing.Point(853, 71);
            this.btnForward.Name = "btnForward";
            this.btnForward.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnForward.Size = new System.Drawing.Size(41, 49);
            this.btnForward.TabIndex = 351;
            this.btnForward.UseVisualStyleBackColor = true;
            // 
            // Btn_PayMoneyRecipt
            // 
            this.Btn_PayMoneyRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_PayMoneyRecipt.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_PayMoneyRecipt.Image = global::BumedianBM.Properties.Resources.pay_receipet_32;
            this.Btn_PayMoneyRecipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_PayMoneyRecipt.Location = new System.Drawing.Point(437, 638);
            this.Btn_PayMoneyRecipt.Name = "Btn_PayMoneyRecipt";
            this.Btn_PayMoneyRecipt.Size = new System.Drawing.Size(146, 46);
            this.Btn_PayMoneyRecipt.TabIndex = 339;
            this.Btn_PayMoneyRecipt.Text = "Pay Receipt";
            this.Btn_PayMoneyRecipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_PayMoneyRecipt.UseVisualStyleBackColor = false;
            // 
            // Btn_ReciveMoneyRecipt
            // 
            this.Btn_ReciveMoneyRecipt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_ReciveMoneyRecipt.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Btn_ReciveMoneyRecipt.Image = global::BumedianBM.Properties.Resources.receive_receipet_32;
            this.Btn_ReciveMoneyRecipt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_ReciveMoneyRecipt.Location = new System.Drawing.Point(619, 638);
            this.Btn_ReciveMoneyRecipt.Name = "Btn_ReciveMoneyRecipt";
            this.Btn_ReciveMoneyRecipt.Size = new System.Drawing.Size(146, 46);
            this.Btn_ReciveMoneyRecipt.TabIndex = 347;
            this.Btn_ReciveMoneyRecipt.Text = "  Receive   Receipt";
            this.Btn_ReciveMoneyRecipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_ReciveMoneyRecipt.UseVisualStyleBackColor = false;
            // 
            // Btn_Next
            // 
            this.Btn_Next.FlatAppearance.BorderSize = 0;
            this.Btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Next.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Next.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Next.Image = global::BumedianBM.Properties.Resources.last_32;
            this.Btn_Next.Location = new System.Drawing.Point(894, 71);
            this.Btn_Next.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(41, 49);
            this.Btn_Next.TabIndex = 332;
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // Btn_Previous
            // 
            this.Btn_Previous.FlatAppearance.BorderSize = 0;
            this.Btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Previous.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Previous.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Previous.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.Btn_Previous.Location = new System.Drawing.Point(812, 71);
            this.Btn_Previous.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Previous.Name = "Btn_Previous";
            this.Btn_Previous.Size = new System.Drawing.Size(41, 49);
            this.Btn_Previous.TabIndex = 331;
            this.Btn_Previous.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::BumedianBM.Properties.Resources.first_32;
            this.button1.Location = new System.Drawing.Point(771, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 49);
            this.button1.TabIndex = 352;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 687);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.Dgv_BalanceSheet);
            this.Controls.Add(this.Btn_PayMoneyRecipt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Txt_TotalPaid);
            this.Controls.Add(this.Txt_Balance);
            this.Controls.Add(this.Btn_ReciveMoneyRecipt);
            this.Controls.Add(this.Txt_TotalDiscounts);
            this.Controls.Add(this.Lbl_TotalDiscount);
            this.Controls.Add(this.Txt_TotalRecived);
            this.Controls.Add(this.Lbl_TotalPayable);
            this.Controls.Add(this.Lbl_TotalReceivable);
            this.Controls.Add(this.Lbl_Balance);
            this.Controls.Add(this.dtp_fromtime);
            this.Controls.Add(this.Lbl_ToTime);
            this.Controls.Add(this.Lbl_FromTime);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.Lbl_PageNo);
            this.Controls.Add(this.Btn_Previous);
            this.Controls.Add(this.Cmb_AgentName);
            this.Controls.Add(this.Dtp_FromDate);
            this.Controls.Add(this.Lbl_AgentNo);
            this.Controls.Add(this.lbl_BSForAgent);
            this.Controls.Add(this.Chk_All);
            this.Controls.Add(this.Cmb_AgentID);
            this.Controls.Add(this.dtp_totime);
            this.Controls.Add(this.Dtp_ToDate);
            this.Controls.Add(this.Lbl_ToDate);
            this.Controls.Add(this.Lbl_FromDate);
            this.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BalanceSheet";
            this.Text = "Balance Sheet";
            this.Load += new System.EventHandler(this.BalanceSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_BalanceSheet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_fromtime;
        private System.Windows.Forms.Label Lbl_ToTime;
        private System.Windows.Forms.Label Lbl_FromTime;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.Label Lbl_PageNo;
        private System.Windows.Forms.Button Btn_Previous;
        private System.Windows.Forms.ComboBox Cmb_AgentName;
        private System.Windows.Forms.DateTimePicker Dtp_FromDate;
        private System.Windows.Forms.Label Lbl_AgentNo;
        private System.Windows.Forms.Label lbl_BSForAgent;
        private System.Windows.Forms.CheckBox Chk_All;
        private System.Windows.Forms.ComboBox Cmb_AgentID;
        private System.Windows.Forms.DateTimePicker dtp_totime;
        private System.Windows.Forms.DateTimePicker Dtp_ToDate;
        private System.Windows.Forms.Label Lbl_ToDate;
        private System.Windows.Forms.Label Lbl_FromDate;
        private System.Windows.Forms.DataGridView Dgv_BalanceSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewYearNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discription;
        private System.Windows.Forms.Button Btn_PayMoneyRecipt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_OpenRecipt;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_AgentDetails;
        private System.Windows.Forms.Button Btn_Reports;
        private System.Windows.Forms.Button Btn_EndOfTheDay;
        private System.Windows.Forms.Button Btn_ReturnItems;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.Button Btn_OpenInvoice;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.MaskedTextBox Txt_TotalPaid;
        private System.Windows.Forms.MaskedTextBox Txt_Balance;
        private System.Windows.Forms.Button Btn_ReciveMoneyRecipt;
        private System.Windows.Forms.MaskedTextBox Txt_TotalDiscounts;
        private System.Windows.Forms.Label Lbl_TotalDiscount;
        private System.Windows.Forms.MaskedTextBox Txt_TotalRecived;
        private System.Windows.Forms.Label Lbl_TotalPayable;
        private System.Windows.Forms.Label Lbl_TotalReceivable;
        private System.Windows.Forms.Label Lbl_Balance;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button button1;
    }
}