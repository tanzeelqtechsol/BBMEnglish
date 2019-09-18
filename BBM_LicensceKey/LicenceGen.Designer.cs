namespace BBM_LicensceGenerator
{
    partial class LicenceGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenceGen));
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.pnlChangePwd = new System.Windows.Forms.Panel();
            this.lblConfrimPassword = new System.Windows.Forms.Label();
            this.txtConfrimPassword = new System.Windows.Forms.TextBox();
            this.btnChangeUserPwd = new System.Windows.Forms.Button();
            this.btnCancelChangePwd = new System.Windows.Forms.Button();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtUserSerialNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUserSerialCopy = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlGenerateCode = new System.Windows.Forms.Panel();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.chkTrial = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnNode = new System.Windows.Forms.RadioButton();
            this.rbtnServer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserKey = new System.Windows.Forms.TextBox();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pnlChangePwd.SuspendLayout();
            this.pnlGenerateCode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(53, 17);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(94, 14);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Old Password";
            // 
            // pnlChangePwd
            // 
            this.pnlChangePwd.Controls.Add(this.lblConfrimPassword);
            this.pnlChangePwd.Controls.Add(this.txtConfrimPassword);
            this.pnlChangePwd.Controls.Add(this.btnChangeUserPwd);
            this.pnlChangePwd.Controls.Add(this.btnCancelChangePwd);
            this.pnlChangePwd.Controls.Add(this.lblNewPassword);
            this.pnlChangePwd.Controls.Add(this.txtNewPassword);
            this.pnlChangePwd.Controls.Add(this.txtOldPassword);
            this.pnlChangePwd.Controls.Add(this.lblOldPassword);
            this.pnlChangePwd.Enabled = false;
            this.pnlChangePwd.Location = new System.Drawing.Point(8, 10);
            this.pnlChangePwd.Name = "pnlChangePwd";
            this.pnlChangePwd.Size = new System.Drawing.Size(458, 148);
            this.pnlChangePwd.TabIndex = 0;
            this.pnlChangePwd.Visible = false;
            // 
            // lblConfrimPassword
            // 
            this.lblConfrimPassword.AutoSize = true;
            this.lblConfrimPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfrimPassword.Location = new System.Drawing.Point(26, 79);
            this.lblConfrimPassword.Name = "lblConfrimPassword";
            this.lblConfrimPassword.Size = new System.Drawing.Size(121, 14);
            this.lblConfrimPassword.TabIndex = 8;
            this.lblConfrimPassword.Text = "Confrim Password";
            // 
            // txtConfrimPassword
            // 
            this.txtConfrimPassword.Location = new System.Drawing.Point(153, 77);
            this.txtConfrimPassword.Name = "txtConfrimPassword";
            this.txtConfrimPassword.PasswordChar = '*';
            this.txtConfrimPassword.Size = new System.Drawing.Size(179, 20);
            this.txtConfrimPassword.TabIndex = 2;
            // 
            // btnChangeUserPwd
            // 
            this.btnChangeUserPwd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeUserPwd.Location = new System.Drawing.Point(220, 115);
            this.btnChangeUserPwd.Name = "btnChangeUserPwd";
            this.btnChangeUserPwd.Size = new System.Drawing.Size(137, 23);
            this.btnChangeUserPwd.TabIndex = 3;
            this.btnChangeUserPwd.Text = "Change Password";
            this.btnChangeUserPwd.UseVisualStyleBackColor = true;
            this.btnChangeUserPwd.Click += new System.EventHandler(this.button_click);
            // 
            // btnCancelChangePwd
            // 
            this.btnCancelChangePwd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelChangePwd.Location = new System.Drawing.Point(363, 115);
            this.btnCancelChangePwd.Name = "btnCancelChangePwd";
            this.btnCancelChangePwd.Size = new System.Drawing.Size(85, 23);
            this.btnCancelChangePwd.TabIndex = 4;
            this.btnCancelChangePwd.Text = "Cancel";
            this.btnCancelChangePwd.UseVisualStyleBackColor = true;
            this.btnCancelChangePwd.Click += new System.EventHandler(this.button_click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(46, 47);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(101, 14);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(153, 45);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(179, 20);
            this.txtNewPassword.TabIndex = 1;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(153, 15);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(179, 20);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtUserSerialNo
            // 
            this.txtUserSerialNo.BackColor = System.Drawing.Color.White;
            this.txtUserSerialNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserSerialNo.Location = new System.Drawing.Point(156, 106);
            this.txtUserSerialNo.Multiline = true;
            this.txtUserSerialNo.Name = "txtUserSerialNo";
            this.txtUserSerialNo.ReadOnly = true;
            this.txtUserSerialNo.Size = new System.Drawing.Size(411, 63);
            this.txtUserSerialNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Serial Number";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(404, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCance_Click);
            // 
            // btnUserSerialCopy
            // 
            this.btnUserSerialCopy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserSerialCopy.Location = new System.Drawing.Point(283, 265);
            this.btnUserSerialCopy.Name = "btnUserSerialCopy";
            this.btnUserSerialCopy.Size = new System.Drawing.Size(94, 33);
            this.btnUserSerialCopy.TabIndex = 3;
            this.btnUserSerialCopy.Text = "Copy";
            this.btnUserSerialCopy.UseVisualStyleBackColor = true;
            this.btnUserSerialCopy.Click += new System.EventHandler(this.btnUserSerialCopy_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(160, 265);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(94, 33);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pnlGenerateCode
            // 
            this.pnlGenerateCode.Controls.Add(this.txtMonth);
            this.pnlGenerateCode.Controls.Add(this.chkTrial);
            this.pnlGenerateCode.Controls.Add(this.panel1);
            this.pnlGenerateCode.Controls.Add(this.btnGenerate);
            this.pnlGenerateCode.Controls.Add(this.btnUserSerialCopy);
            this.pnlGenerateCode.Controls.Add(this.label4);
            this.pnlGenerateCode.Controls.Add(this.btnCancel);
            this.pnlGenerateCode.Controls.Add(this.txtUserKey);
            this.pnlGenerateCode.Controls.Add(this.label3);
            this.pnlGenerateCode.Controls.Add(this.txtUserSerialNo);
            this.pnlGenerateCode.Location = new System.Drawing.Point(8, 10);
            this.pnlGenerateCode.Name = "pnlGenerateCode";
            this.pnlGenerateCode.Size = new System.Drawing.Size(588, 313);
            this.pnlGenerateCode.TabIndex = 18;
            this.pnlGenerateCode.Visible = false;
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.White;
            this.txtMonth.Enabled = false;
            this.txtMonth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.Location = new System.Drawing.Point(156, 185);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(411, 23);
            this.txtMonth.TabIndex = 22;
            // 
            // chkTrial
            // 
            this.chkTrial.AutoSize = true;
            this.chkTrial.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.chkTrial.Location = new System.Drawing.Point(8, 187);
            this.chkTrial.Name = "chkTrial";
            this.chkTrial.Size = new System.Drawing.Size(144, 20);
            this.chkTrial.TabIndex = 21;
            this.chkTrial.Text = "Trial Period(days)";
            this.chkTrial.UseVisualStyleBackColor = true;
            this.chkTrial.CheckedChanged += new System.EventHandler(this.chkTrial_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnNode);
            this.panel1.Controls.Add(this.rbtnServer);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(156, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 34);
            this.panel1.TabIndex = 20;
            // 
            // rbtnNode
            // 
            this.rbtnNode.AutoSize = true;
            this.rbtnNode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.rbtnNode.Location = new System.Drawing.Point(157, 7);
            this.rbtnNode.Name = "rbtnNode";
            this.rbtnNode.Size = new System.Drawing.Size(59, 20);
            this.rbtnNode.TabIndex = 18;
            this.rbtnNode.TabStop = true;
            this.rbtnNode.Text = "Node";
            this.rbtnNode.UseVisualStyleBackColor = true;
            // 
            // rbtnServer
            // 
            this.rbtnServer.AutoSize = true;
            this.rbtnServer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic);
            this.rbtnServer.Location = new System.Drawing.Point(13, 7);
            this.rbtnServer.Name = "rbtnServer";
            this.rbtnServer.Size = new System.Drawing.Size(70, 20);
            this.rbtnServer.TabIndex = 19;
            this.rbtnServer.TabStop = true;
            this.rbtnServer.Text = "Server";
            this.rbtnServer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "User Key";
            // 
            // txtUserKey
            // 
            this.txtUserKey.BackColor = System.Drawing.Color.White;
            this.txtUserKey.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserKey.Location = new System.Drawing.Point(156, 23);
            this.txtUserKey.Multiline = true;
            this.txtUserKey.Name = "txtUserKey";
            this.txtUserKey.Size = new System.Drawing.Size(411, 70);
            this.txtUserKey.TabIndex = 0;
            this.txtUserKey.TextChanged += new System.EventHandler(this.txtUserKey_TextChanged);
            // 
            // ofd
            // 
            this.ofd.FileName = "UserInformation.zip";
            this.ofd.Filter = "(*.ZIP)|*.zip";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(60, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(76, 14);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(153, 26);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(179, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "admin";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(153, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(179, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(60, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 14);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(129, 107);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button_click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(363, 107);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Cancel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button_click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePwd.Location = new System.Drawing.Point(220, 107);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(137, 23);
            this.btnChangePwd.TabIndex = 2;
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.button_click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnChangePwd);
            this.pnlLogin.Controls.Add(this.btnExit);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUserName);
            this.pnlLogin.Controls.Add(this.lblUserName);
            this.pnlLogin.Location = new System.Drawing.Point(8, 10);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(458, 148);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Visible = false;
            // 
            // LicenceGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(608, 335);
            this.Controls.Add(this.pnlGenerateCode);
            this.Controls.Add(this.pnlChangePwd);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LicenceGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Almaqar POS Licence Key Generator";
            this.Load += new System.EventHandler(this.LicenceGen_Load);
            this.pnlChangePwd.ResumeLayout(false);
            this.pnlChangePwd.PerformLayout();
            this.pnlGenerateCode.ResumeLayout(false);
            this.pnlGenerateCode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Panel pnlChangePwd;
        private System.Windows.Forms.Label lblConfrimPassword;
        private System.Windows.Forms.TextBox txtConfrimPassword;
        private System.Windows.Forms.Button btnChangeUserPwd;
        private System.Windows.Forms.Button btnCancelChangePwd;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtUserSerialNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUserSerialCopy;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlGenerateCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserKey;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnNode;
        private System.Windows.Forms.RadioButton rbtnServer;
        private System.Windows.Forms.CheckBox chkTrial;
        private System.Windows.Forms.TextBox txtMonth;

    }
}

