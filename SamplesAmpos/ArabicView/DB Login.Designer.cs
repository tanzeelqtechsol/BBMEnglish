namespace BumedianBM.ArabicView
{
    partial class DB_Login
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.Txt_UserName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(195, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(99, 31);
            this.lblUserName.TabIndex = 153;
            this.lblUserName.Tag = "UN";
            this.lblUserName.Text = "اسم المستخدم \r\n";
            // 
            // Txt_UserName
            // 
            this.Txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_UserName.Location = new System.Drawing.Point(12, 14);
            this.Txt_UserName.MaxLength = 100;
            this.Txt_UserName.Name = "Txt_UserName";
            this.Txt_UserName.Size = new System.Drawing.Size(177, 26);
            this.Txt_UserName.TabIndex = 0;
            this.Txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_UserName_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(150, 93);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogin.Size = new System.Drawing.Size(118, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Tag = "DL";
            this.btnLogin.Text = "تسجيل الدخول\r\n";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(26, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(118, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "DC";
            this.btnCancel.Text = "الغاء الامر\r\n";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(195, 48);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 31);
            this.lblPassword.TabIndex = 149;
            this.lblPassword.Tag = "Psw";
            this.lblPassword.Text = "كلمة المرور\r\n";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Password.Location = new System.Drawing.Point(12, 50);
            this.Txt_Password.MaxLength = 50;
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(177, 26);
            this.Txt_Password.TabIndex = 1;
            this.Txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_Password.UseSystemPasswordChar = true;
            this.Txt_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Password_KeyDown);
            // 
            // DB_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(290, 146);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.Txt_UserName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.Txt_Password);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DB_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "DBLogin";
            this.Text = "DB Login";
            this.Load += new System.EventHandler(this.DB_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.TextBox Txt_UserName;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.TextBox Txt_Password;
        //private DataSet dataSet1;
    }
}