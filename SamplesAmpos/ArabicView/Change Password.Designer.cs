namespace BumedianBM.ArabicView
{
    partial class frmChangePassword
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(177, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(138, 42);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "الغاء الامر";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(12, 93);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtConfirmPassword.Size = new System.Drawing.Size(208, 30);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.Location = new System.Drawing.Point(226, 94);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblConfirmPassword.Size = new System.Drawing.Size(163, 31);
            this.lblConfirmPassword.TabIndex = 13;
            this.lblConfirmPassword.Tag = "ConPsw";
            this.lblConfirmPassword.Text = "تأكيد كلمة المرور\r\n";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNewPassword.Location = new System.Drawing.Point(226, 50);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNewPassword.Size = new System.Drawing.Size(163, 31);
            this.lblNewPassword.TabIndex = 12;
            this.lblNewPassword.Tag = "NewPsw";
            this.lblNewPassword.Text = "كلمة مرور جديدة\r\n";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPassword.Location = new System.Drawing.Point(220, 12);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPassword.Size = new System.Drawing.Size(169, 31);
            this.lblCurrentPassword.TabIndex = 9;
            this.lblCurrentPassword.Tag = "CurPsw";
            this.lblCurrentPassword.Text = "كلمة المرور الحالية\r\n";
            this.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtNewPassword.Location = new System.Drawing.Point(12, 50);
            this.txtNewPassword.MaxLength = 50;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewPassword.Size = new System.Drawing.Size(208, 30);
            this.txtNewPassword.TabIndex = 7;
            this.txtNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPassword_KeyPress);
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtCurrentPassword.Location = new System.Drawing.Point(12, 11);
            this.txtCurrentPassword.MaxLength = 50;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '•';
            this.txtCurrentPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCurrentPassword.Size = new System.Drawing.Size(208, 30);
            this.txtCurrentPassword.TabIndex = 6;
            this.txtCurrentPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentPassword_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubmit.Location = new System.Drawing.Point(33, 138);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSubmit.Size = new System.Drawing.Size(138, 42);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Tag = "Save";
            this.btnSubmit.Text = "حفظ";
            this.btnSubmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(394, 202);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Button btnSubmit;
    }
}