namespace BBM_LicensceGenerator
{
    partial class DataMigration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataMigration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPasswordFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserNameFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServerFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpServDtl = new System.Windows.Forms.GroupBox();
            this.txtPasswordTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserNameTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbServerTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpDBConversion = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.PGDataMigration = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpConfigMode = new System.Windows.Forms.GroupBox();
            this.rdoCustom = new System.Windows.Forms.RadioButton();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.btnRestore_Backup = new System.Windows.Forms.Button();
            this.grpRestoreDB = new System.Windows.Forms.GroupBox();
            this.lblRestoreDBMessgae = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureboxpanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.GrpServDtl.SuspendLayout();
            this.grpDBConversion.SuspendLayout();
            this.grpConfigMode.SuspendLayout();
            this.grpRestoreDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureboxpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPasswordFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserNameFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbServerFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(5, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(10, 10);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data From";
            this.groupBox1.Visible = false;
            // 
            // txtPasswordFrom
            // 
            this.txtPasswordFrom.Location = new System.Drawing.Point(6, 144);
            this.txtPasswordFrom.Name = "txtPasswordFrom";
            this.txtPasswordFrom.PasswordChar = '*';
            this.txtPasswordFrom.Size = new System.Drawing.Size(268, 31);
            this.txtPasswordFrom.TabIndex = 5;
            this.txtPasswordFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtUserNameFrom
            // 
            this.txtUserNameFrom.Location = new System.Drawing.Point(6, 94);
            this.txtUserNameFrom.Name = "txtUserNameFrom";
            this.txtUserNameFrom.Size = new System.Drawing.Size(268, 31);
            this.txtUserNameFrom.TabIndex = 3;
            this.txtUserNameFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // cmbServerFrom
            // 
            this.cmbServerFrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServerFrom.FormattingEnabled = true;
            this.cmbServerFrom.Location = new System.Drawing.Point(6, 40);
            this.cmbServerFrom.Name = "cmbServerFrom";
            this.cmbServerFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbServerFrom.Size = new System.Drawing.Size(268, 26);
            this.cmbServerFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name";
            // 
            // GrpServDtl
            // 
            this.GrpServDtl.Controls.Add(this.txtPasswordTo);
            this.GrpServDtl.Controls.Add(this.label4);
            this.GrpServDtl.Controls.Add(this.txtUserNameTo);
            this.GrpServDtl.Controls.Add(this.label5);
            this.GrpServDtl.Controls.Add(this.cmbServerTo);
            this.GrpServDtl.Controls.Add(this.label6);
            this.GrpServDtl.Enabled = false;
            this.GrpServDtl.Location = new System.Drawing.Point(307, 12);
            this.GrpServDtl.Name = "GrpServDtl";
            this.GrpServDtl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GrpServDtl.Size = new System.Drawing.Size(452, 185);
            this.GrpServDtl.TabIndex = 1;
            this.GrpServDtl.TabStop = false;
            this.GrpServDtl.Text = "Server Details";
            // 
            // txtPasswordTo
            // 
            this.txtPasswordTo.Location = new System.Drawing.Point(6, 147);
            this.txtPasswordTo.Name = "txtPasswordTo";
            this.txtPasswordTo.PasswordChar = '*';
            this.txtPasswordTo.Size = new System.Drawing.Size(270, 31);
            this.txtPasswordTo.TabIndex = 3;
            this.txtPasswordTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordTo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // txtUserNameTo
            // 
            this.txtUserNameTo.Location = new System.Drawing.Point(6, 97);
            this.txtUserNameTo.Name = "txtUserNameTo";
            this.txtUserNameTo.Size = new System.Drawing.Size(270, 31);
            this.txtUserNameTo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "User Name";
            // 
            // cmbServerTo
            // 
            this.cmbServerTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServerTo.FormattingEnabled = true;
            this.cmbServerTo.Location = new System.Drawing.Point(6, 43);
            this.cmbServerTo.Name = "cmbServerTo";
            this.cmbServerTo.Size = new System.Drawing.Size(270, 26);
            this.cmbServerTo.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Server Name";
            // 
            // grpDBConversion
            // 
            this.grpDBConversion.Controls.Add(this.lblStatus);
            this.grpDBConversion.Controls.Add(this.PGDataMigration);
            this.grpDBConversion.Controls.Add(this.btnCancel);
            this.grpDBConversion.Controls.Add(this.btnProcess);
            this.grpDBConversion.Location = new System.Drawing.Point(51, 257);
            this.grpDBConversion.Name = "grpDBConversion";
            this.grpDBConversion.Size = new System.Drawing.Size(708, 131);
            this.grpDBConversion.TabIndex = 2;
            this.grpDBConversion.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(10, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(686, 43);
            this.lblStatus.TabIndex = 3;
            // 
            // PGDataMigration
            // 
            this.PGDataMigration.Location = new System.Drawing.Point(9, 62);
            this.PGDataMigration.Name = "PGDataMigration";
            this.PGDataMigration.Size = new System.Drawing.Size(687, 25);
            this.PGDataMigration.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(157, 90);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(159, 35);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // grpConfigMode
            // 
            this.grpConfigMode.Controls.Add(this.rdoCustom);
            this.grpConfigMode.Controls.Add(this.rdoDefault);
            this.grpConfigMode.Location = new System.Drawing.Point(57, 12);
            this.grpConfigMode.Name = "grpConfigMode";
            this.grpConfigMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpConfigMode.Size = new System.Drawing.Size(240, 133);
            this.grpConfigMode.TabIndex = 3;
            this.grpConfigMode.TabStop = false;
            this.grpConfigMode.Text = "Configuration Mode";
            // 
            // rdoCustom
            // 
            this.rdoCustom.AutoSize = true;
            this.rdoCustom.Location = new System.Drawing.Point(115, 94);
            this.rdoCustom.Name = "rdoCustom";
            this.rdoCustom.Size = new System.Drawing.Size(109, 27);
            this.rdoCustom.TabIndex = 1;
            this.rdoCustom.Text = "Custom";
            this.rdoCustom.UseVisualStyleBackColor = true;
            this.rdoCustom.CheckedChanged += new System.EventHandler(this.rdoCustom_CheckedChanged);
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Checked = true;
            this.rdoDefault.Location = new System.Drawing.Point(115, 57);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(108, 27);
            this.rdoDefault.TabIndex = 0;
            this.rdoDefault.TabStop = true;
            this.rdoDefault.Text = "Default";
            this.rdoDefault.UseVisualStyleBackColor = true;
            this.rdoDefault.CheckedChanged += new System.EventHandler(this.rdoDefault_CheckedChanged);
            // 
            // btnRestore_Backup
            // 
            this.btnRestore_Backup.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRestore_Backup.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore_Backup.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore_Backup.Image")));
            this.btnRestore_Backup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore_Backup.Location = new System.Drawing.Point(488, 16);
            this.btnRestore_Backup.Name = "btnRestore_Backup";
            this.btnRestore_Backup.Size = new System.Drawing.Size(208, 43);
            this.btnRestore_Backup.TabIndex = 58;
            this.btnRestore_Backup.Text = "Restore BackUp";
            this.btnRestore_Backup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestore_Backup.UseVisualStyleBackColor = false;
            this.btnRestore_Backup.Click += new System.EventHandler(this.btnRestore_Backup_Click);
            // 
            // grpRestoreDB
            // 
            this.grpRestoreDB.Controls.Add(this.btnRestore_Backup);
            this.grpRestoreDB.Controls.Add(this.lblRestoreDBMessgae);
            this.grpRestoreDB.Location = new System.Drawing.Point(57, 197);
            this.grpRestoreDB.Name = "grpRestoreDB";
            this.grpRestoreDB.Size = new System.Drawing.Size(702, 65);
            this.grpRestoreDB.TabIndex = 4;
            this.grpRestoreDB.TabStop = false;
            this.grpRestoreDB.Visible = false;
            // 
            // lblRestoreDBMessgae
            // 
            this.lblRestoreDBMessgae.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestoreDBMessgae.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreDBMessgae.Location = new System.Drawing.Point(8, 16);
            this.lblRestoreDBMessgae.Name = "lblRestoreDBMessgae";
            this.lblRestoreDBMessgae.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRestoreDBMessgae.Size = new System.Drawing.Size(474, 43);
            this.lblRestoreDBMessgae.TabIndex = 59;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BBM_DataMigration.Properties.Resources.wait;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 236);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // pictureboxpanel
            // 
            this.pictureboxpanel.Controls.Add(this.pictureBox1);
            this.pictureboxpanel.Location = new System.Drawing.Point(273, 151);
            this.pictureboxpanel.Name = "pictureboxpanel";
            this.pictureboxpanel.Size = new System.Drawing.Size(240, 236);
            this.pictureboxpanel.TabIndex = 6;
            this.pictureboxpanel.Visible = false;
            // 
            // DataMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 405);
            this.Controls.Add(this.pictureboxpanel);
            this.Controls.Add(this.grpConfigMode);
            this.Controls.Add(this.grpDBConversion);
            this.Controls.Add(this.GrpServDtl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpRestoreDB);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataMigration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Migration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataMigration_FormClosing);
            this.Load += new System.EventHandler(this.frmDataMigration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GrpServDtl.ResumeLayout(false);
            this.GrpServDtl.PerformLayout();
            this.grpDBConversion.ResumeLayout(false);
            this.grpConfigMode.ResumeLayout(false);
            this.grpConfigMode.PerformLayout();
            this.grpRestoreDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureboxpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GrpServDtl;
        private System.Windows.Forms.ComboBox cmbServerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserNameFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPasswordTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserNameTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbServerTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpDBConversion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar PGDataMigration;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpConfigMode;
        private System.Windows.Forms.RadioButton rdoCustom;
        private System.Windows.Forms.RadioButton rdoDefault;
        private System.Windows.Forms.Button btnRestore_Backup;
        private System.Windows.Forms.GroupBox grpRestoreDB;
        private System.Windows.Forms.Label lblRestoreDBMessgae;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pictureboxpanel;
    }
}