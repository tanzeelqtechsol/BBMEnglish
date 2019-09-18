namespace BBM_LicensceGenerator
{
    partial class frmOptionSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptionSelection));
            this.btnLicenseGenerator = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLicenseGenerator
            // 
            this.btnLicenseGenerator.Location = new System.Drawing.Point(2, 2);
            this.btnLicenseGenerator.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnLicenseGenerator.Name = "btnLicenseGenerator";
            this.btnLicenseGenerator.Size = new System.Drawing.Size(341, 94);
            this.btnLicenseGenerator.TabIndex = 0;
            this.btnLicenseGenerator.Text = "&License Generator";
            this.btnLicenseGenerator.UseVisualStyleBackColor = true;
            this.btnLicenseGenerator.Click += new System.EventHandler(this.btnLicenseGenerator_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(2, 198);
            this.btnExit.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(341, 94);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(2, 100);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(341, 94);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "&Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // frmOptionSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 295);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLicenseGenerator);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptionSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptionSelection_FormClosing);
            this.Load += new System.EventHandler(this.frmOptionSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLicenseGenerator;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePassword;
    }
}