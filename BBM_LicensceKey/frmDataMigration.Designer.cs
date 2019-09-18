namespace BBM_LicensceGenerator
{
    partial class frmDataMigration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataMigration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPasswordFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserNameFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServerFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPasswordTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserNameTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbServerTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.PGDataMigration = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPasswordTo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUserNameTo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbServerTo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(132, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(452, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Details";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.PGDataMigration);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnProcess);
            this.groupBox3.Location = new System.Drawing.Point(5, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(708, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
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
            this.PGDataMigration.Location = new System.Drawing.Point(9, 65);
            this.PGDataMigration.Name = "PGDataMigration";
            this.PGDataMigration.Size = new System.Drawing.Size(687, 25);
            this.PGDataMigration.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(157, 94);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(159, 35);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // frmDataMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataMigration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Migration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataMigration_FormClosing);
            this.Load += new System.EventHandler(this.frmDataMigration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar PGDataMigration;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblStatus;
    }
}