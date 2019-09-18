namespace BumedianBM.ArabicView
{
    partial class frmSpending
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

            objSpendingHelperClass = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpending));
            this.txtNewYearNo = new System.Windows.Forms.MaskedTextBox();
            this.lblUName = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.lblStatusName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            this.lblExpensesDescription = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewYearNo
            // 
            this.txtNewYearNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtNewYearNo.Location = new System.Drawing.Point(204, 38);
            this.txtNewYearNo.Name = "txtNewYearNo";
            this.txtNewYearNo.Size = new System.Drawing.Size(86, 26);
            this.txtNewYearNo.TabIndex = 413;
            this.txtNewYearNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUName
            // 
            this.lblUName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUName.ForeColor = System.Drawing.Color.Tomato;
            this.lblUName.Location = new System.Drawing.Point(125, 293);
            this.lblUName.Name = "lblUName";
            this.lblUName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUName.Size = new System.Drawing.Size(191, 18);
            this.lblUName.TabIndex = 412;
            this.lblUName.Text = "admin";
            this.lblUName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.MistyRose;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(376, 119);
            this.txtValue.MaxLength = 17;
            this.txtValue.Name = "txtValue";
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValue.Size = new System.Drawing.Size(104, 27);
            this.txtValue.TabIndex = 1;
            this.txtValue.Text = "0.000";
            this.txtValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtValue_MouseClick);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.SystemColors.Info;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(140, 240);
            this.txtNote.MaxLength = 500;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNote.Size = new System.Drawing.Size(227, 27);
            this.txtNote.TabIndex = 3;
            this.txtNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNote_KeyPress);
            // 
            // txtDetails
            // 
            this.txtDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(137, 181);
            this.txtDetails.MaxLength = 500;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDetails.Size = new System.Drawing.Size(227, 27);
            this.txtDetails.TabIndex = 2;
            this.txtDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetails_KeyPress);
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBillNo.Location = new System.Drawing.Point(204, 37);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(86, 26);
            this.txtBillNo.TabIndex = 10;
            this.txtBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBillNo.TextChanged += new System.EventHandler(this.txtBillNo_TextChanged);
            this.txtBillNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillNo_KeyPress);
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNotes.Location = new System.Drawing.Point(137, 209);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNotes.Size = new System.Drawing.Size(227, 31);
            this.lblNotes.TabIndex = 411;
            this.lblNotes.Tag = "Notes";
            this.lblNotes.Text = "ملاحظات";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(6, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(52, 31);
            this.lblDate.TabIndex = 403;
            this.lblDate.Tag = "Date";
            this.lblDate.Text = "التاريخ\r\n";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Bold);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(7, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(113, 25);
            this.dtpDate.TabIndex = 13;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Image = global::BumedianBM.Properties.Resources.rew_32;
            this.btnPrevious.Location = new System.Drawing.Point(158, 28);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(40, 40);
            this.btnPrevious.TabIndex = 10;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblBillNo
            // 
            this.lblBillNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblBillNo.Location = new System.Drawing.Point(183, 4);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBillNo.Size = new System.Drawing.Size(134, 27);
            this.lblBillNo.TabIndex = 402;
            this.lblBillNo.Tag = "BillNo";
            this.lblBillNo.Text = "رقم الفاتورة \r\n";
            this.lblBillNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNext.Image = global::BumedianBM.Properties.Resources.forward_32;
            this.btnNext.Location = new System.Drawing.Point(296, 28);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 11;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grbStatus
            // 
            this.grbStatus.Controls.Add(this.lblStatusName);
            this.grbStatus.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.grbStatus.Location = new System.Drawing.Point(374, 12);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grbStatus.Size = new System.Drawing.Size(106, 74);
            this.grbStatus.TabIndex = 408;
            this.grbStatus.TabStop = false;
            this.grbStatus.Tag = "Status";
            this.grbStatus.Text = "الحالة\r\n";
            // 
            // lblStatusName
            // 
            this.lblStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblStatusName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatusName.Location = new System.Drawing.Point(3, 32);
            this.lblStatusName.Name = "lblStatusName";
            this.lblStatusName.Size = new System.Drawing.Size(100, 39);
            this.lblStatusName.TabIndex = 260;
            this.lblStatusName.Text = "a";
            this.lblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(372, 85);
            this.lblValue.Name = "lblValue";
            this.lblValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblValue.Size = new System.Drawing.Size(62, 31);
            this.lblValue.TabIndex = 407;
            this.lblValue.Tag = "Value";
            this.lblValue.Text = "قيمة\r\n";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(6, 288);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(116, 31);
            this.lblUserName.TabIndex = 406;
            this.lblUserName.Tag = "UName";
            this.lblUserName.Text = "اسم المستخدم ";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetails
            // 
            this.lblDetails.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDetails.Location = new System.Drawing.Point(133, 150);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDetails.Size = new System.Drawing.Size(194, 31);
            this.lblDetails.TabIndex = 405;
            this.lblDetails.Tag = "Details";
            this.lblDetails.Text = "التفاصيل\r\n";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDescription
            // 
            this.cmbDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDescription.DropDownHeight = 350;
            this.cmbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.IntegralHeight = false;
            this.cmbDescription.Location = new System.Drawing.Point(137, 119);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDescription.Size = new System.Drawing.Size(227, 28);
            this.cmbDescription.TabIndex = 0;
            this.cmbDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDescription_KeyDown);
            // 
            // lblExpensesDescription
            // 
            this.lblExpensesDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblExpensesDescription.Location = new System.Drawing.Point(133, 88);
            this.lblExpensesDescription.Name = "lblExpensesDescription";
            this.lblExpensesDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExpensesDescription.Size = new System.Drawing.Size(194, 31);
            this.lblExpensesDescription.TabIndex = 404;
            this.lblExpensesDescription.Tag = "SpendingDes";
            this.lblExpensesDescription.Text = "بيان الصرف \r\n";
            this.lblExpensesDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(2, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(128, 206);
            this.groupBox2.TabIndex = 4;
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
            this.btnNew.Location = new System.Drawing.Point(4, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNew.Size = new System.Drawing.Size(121, 40);
            this.btnNew.TabIndex = 7;
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
            this.btnSave.TabIndex = 5;
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
            this.btnPrint.TabIndex = 8;
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
            this.btnDelete.TabIndex = 9;
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
            this.btnClose.Location = new System.Drawing.Point(359, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(121, 42);
            this.btnClose.TabIndex = 12;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "خروج";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSpending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(492, 319);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblUName);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblBillNo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grbStatus);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.lblExpensesDescription);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.txtNewYearNo);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Spending";
            this.Text = "Spending";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSpending_FormClosed);
            this.Load += new System.EventHandler(this.Spending_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSpending_KeyDown);
            this.grbStatus.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtNewYearNo;
        private System.Windows.Forms.Label lblUName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox grbStatus;
        private System.Windows.Forms.Label lblStatusName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.ComboBox cmbDescription;
        private System.Windows.Forms.Label lblExpensesDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
       // private DataSet dataSet1;
    }
}