namespace BumedianBM.ArabicView
{
    partial class StockPassword
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(77, 93);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOk.Size = new System.Drawing.Size(118, 41);
            this.btnOk.TabIndex = 151;
            this.btnOk.Tag = "DC";
            this.btnOk.Text = "الغاء الامر\r\n";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(100, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 31);
            this.lblPassword.TabIndex = 152;
            this.lblPassword.Tag = "Psw";
            this.lblPassword.Text = "كلمة المرور\r\n";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Password.Location = new System.Drawing.Point(47, 51);
            this.Txt_Password.MaxLength = 50;
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.Size = new System.Drawing.Size(177, 26);
            this.Txt_Password.TabIndex = 150;
            this.Txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_Password.UseSystemPasswordChar = true;
            // 
            // StockPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(290, 146);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.Txt_Password);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "password";
            this.Text = "Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.TextBox Txt_Password;
    }
}