namespace BumedianBM.ArabicView
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.txtRate = new System.Windows.Forms.TextBox();
            this.cmbchooseimport = new System.Windows.Forms.ComboBox();
            this.cmbSupplierName = new System.Windows.Forms.ComboBox();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.prgImport = new System.Windows.Forms.ProgressBar();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtExtraCost = new System.Windows.Forms.TextBox();
            this.lblExtracost = new System.Windows.Forms.Label();
            this.chkApply = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.Color.White;
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtRate.Location = new System.Drawing.Point(168, 78);
            this.txtRate.MaxLength = 13;
            this.txtRate.Name = "txtRate";
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRate.Size = new System.Drawing.Size(170, 27);
            this.txtRate.TabIndex = 151;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // cmbchooseimport
            // 
            this.cmbchooseimport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbchooseimport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbchooseimport.DropDownHeight = 435;
            this.cmbchooseimport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbchooseimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbchooseimport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbchooseimport.FormattingEnabled = true;
            this.cmbchooseimport.IntegralHeight = false;
            this.cmbchooseimport.Location = new System.Drawing.Point(168, 5);
            this.cmbchooseimport.MaxDropDownItems = 35;
            this.cmbchooseimport.Name = "cmbchooseimport";
            this.cmbchooseimport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbchooseimport.Size = new System.Drawing.Size(246, 28);
            this.cmbchooseimport.TabIndex = 152;
            this.cmbchooseimport.SelectedIndexChanged += new System.EventHandler(this.cmbchooseimport_SelectedIndexChanged);
            // 
            // cmbSupplierName
            // 
            this.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierName.DropDownHeight = 435;
            this.cmbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbSupplierName.FormattingEnabled = true;
            this.cmbSupplierName.IntegralHeight = false;
            this.cmbSupplierName.Location = new System.Drawing.Point(168, 39);
            this.cmbSupplierName.MaxDropDownItems = 35;
            this.cmbSupplierName.Name = "cmbSupplierName";
            this.cmbSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSupplierName.Size = new System.Drawing.Size(246, 28);
            this.cmbSupplierName.TabIndex = 153;
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblImport.Location = new System.Drawing.Point(6, 8);
            this.lblImport.Name = "lblImport";
            this.lblImport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblImport.Size = new System.Drawing.Size(158, 19);
            this.lblImport.TabIndex = 154;
            this.lblImport.Tag = "Company";
            this.lblImport.Text = "Choose Import Option";
            this.lblImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.Location = new System.Drawing.Point(6, 43);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSupplier.Size = new System.Drawing.Size(109, 19);
            this.lblSupplier.TabIndex = 155;
            this.lblSupplier.Tag = "Company";
            this.lblSupplier.Text = "Supplier Name";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.Location = new System.Drawing.Point(9, 194);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBrowse.Size = new System.Drawing.Size(108, 42);
            this.btnBrowse.TabIndex = 179;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnImport.Location = new System.Drawing.Point(132, 194);
            this.btnImport.Name = "btnImport";
            this.btnImport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImport.Size = new System.Drawing.Size(108, 42);
            this.btnImport.TabIndex = 180;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtFileName.Location = new System.Drawing.Point(168, 148);
            this.txtFileName.MaxLength = 13;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFileName.Size = new System.Drawing.Size(246, 27);
            this.txtFileName.TabIndex = 181;
            // 
            // lblFilename
            // 
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblFilename.Location = new System.Drawing.Point(6, 148);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFilename.Size = new System.Drawing.Size(147, 28);
            this.lblFilename.TabIndex = 182;
            this.lblFilename.Tag = "Company";
            this.lblFilename.Text = "File Name";
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prgImport
            // 
            this.prgImport.Location = new System.Drawing.Point(27, 242);
            this.prgImport.Name = "prgImport";
            this.prgImport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prgImport.Size = new System.Drawing.Size(231, 23);
            this.prgImport.TabIndex = 183;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblRate.Location = new System.Drawing.Point(6, 82);
            this.lblRate.Name = "lblRate";
            this.lblRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRate.Size = new System.Drawing.Size(39, 19);
            this.lblRate.TabIndex = 184;
            this.lblRate.Tag = "";
            this.lblRate.Text = "Rate";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExtraCost
            // 
            this.txtExtraCost.BackColor = System.Drawing.Color.White;
            this.txtExtraCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtExtraCost.Location = new System.Drawing.Point(168, 115);
            this.txtExtraCost.MaxLength = 13;
            this.txtExtraCost.Name = "txtExtraCost";
            this.txtExtraCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExtraCost.Size = new System.Drawing.Size(246, 27);
            this.txtExtraCost.TabIndex = 185;
            this.txtExtraCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // lblExtracost
            // 
            this.lblExtracost.AutoSize = true;
            this.lblExtracost.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblExtracost.Location = new System.Drawing.Point(6, 119);
            this.lblExtracost.Name = "lblExtracost";
            this.lblExtracost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExtracost.Size = new System.Drawing.Size(76, 19);
            this.lblExtracost.TabIndex = 186;
            this.lblExtracost.Tag = "";
            this.lblExtracost.Text = "Extra Cost";
            this.lblExtracost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkApply
            // 
            this.chkApply.AutoSize = true;
            this.chkApply.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkApply.Location = new System.Drawing.Point(347, 78);
            this.chkApply.Name = "chkApply";
            this.chkApply.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkApply.Size = new System.Drawing.Size(63, 21);
            this.chkApply.TabIndex = 187;
            this.chkApply.Text = "Apply";
            this.chkApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApply.UseVisualStyleBackColor = true;
            this.chkApply.CheckedChanged += new System.EventHandler(this.chkApply_CheckedChanged);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(422, 270);
            this.Controls.Add(this.chkApply);
            this.Controls.Add(this.lblExtracost);
            this.Controls.Add(this.txtExtraCost);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.prgImport);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.cmbSupplierName);
            this.Controls.Add(this.cmbchooseimport);
            this.Controls.Add(this.txtRate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.ComboBox cmbchooseimport;
        private System.Windows.Forms.ComboBox cmbSupplierName;
        public System.Windows.Forms.Label lblImport;
        public System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnImport;
        public System.Windows.Forms.TextBox txtFileName;
        public System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.ProgressBar prgImport;
        public System.Windows.Forms.Label lblRate;
        public System.Windows.Forms.TextBox txtExtraCost;
        public System.Windows.Forms.Label lblExtracost;
        private System.Windows.Forms.CheckBox chkApply;
    }
}