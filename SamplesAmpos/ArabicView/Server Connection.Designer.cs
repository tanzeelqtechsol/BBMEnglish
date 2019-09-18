namespace BumedianBM.ArabicView
{
    partial class Server_Connection
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
            this.lblDB = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.btnTechConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDB
            // 
            this.lblDB.Location = new System.Drawing.Point(285, 132);
            this.lblDB.Name = "lblDB";
            this.lblDB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDB.Size = new System.Drawing.Size(99, 31);
            this.lblDB.TabIndex = 21;
            this.lblDB.Tag = "DB";
            this.lblDB.Text = "البيانات";
            this.lblDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(285, 92);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPassword.Size = new System.Drawing.Size(105, 31);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Tag = "Psw";
            this.lblPassword.Text = "كلمة المرور";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(285, 52);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(122, 31);
            this.lblUserName.TabIndex = 19;
            this.lblUserName.Tag = "UN";
            this.lblUserName.Text = "اسم المستخدم ";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(285, 10);
            this.lblServer.Name = "lblServer";
            this.lblServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblServer.Size = new System.Drawing.Size(70, 31);
            this.lblServer.TabIndex = 18;
            this.lblServer.Tag = "Server";
            this.lblServer.Text = "الخادم";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Image = global::BumedianBM.Properties.Resources.ok_32;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(287, 177);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOk.Size = new System.Drawing.Size(116, 41);
            this.btnOk.TabIndex = 15;
            this.btnOk.Tag = "K";
            this.btnOk.Text = "موافق";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(145, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(140, 41);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "الغاء الامر";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(2, 92);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(283, 27);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Location = new System.Drawing.Point(2, 52);
            this.txtUserName.MaxLength = 100;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(283, 27);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(2, 132);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDatabase.Size = new System.Drawing.Size(283, 28);
            this.cmbDatabase.TabIndex = 14;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServer_KeyDown);
            // 
            // cmbServer
            // 
            this.cmbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.ItemHeight = 20;
            this.cmbServer.Location = new System.Drawing.Point(2, 10);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbServer.Size = new System.Drawing.Size(283, 28);
            this.cmbServer.TabIndex = 11;
            this.cmbServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServer_KeyDown);
            // 
            // btnTechConn
            // 
            this.btnTechConn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTechConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTechConn.Image = global::BumedianBM.Properties.Resources.reset_321;
            this.btnTechConn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTechConn.Location = new System.Drawing.Point(3, 177);
            this.btnTechConn.Name = "btnTechConn";
            this.btnTechConn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnTechConn.Size = new System.Drawing.Size(140, 41);
            this.btnTechConn.TabIndex = 17;
            this.btnTechConn.Tag = "TechConn";
            this.btnTechConn.Text = "اختبار الاتصال";
            this.btnTechConn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTechConn.UseVisualStyleBackColor = false;
            this.btnTechConn.Click += new System.EventHandler(this.btn_Click);
            // 
            // Server_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(405, 223);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTechConn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.cmbServer);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Server_Connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Connection";
            this.Load += new System.EventHandler(this.Server_Connection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTechConn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.ComboBox cmbServer;

    }
}