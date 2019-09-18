namespace BumedianBM
{
    partial class Form1
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
            this.Btn_Login = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Login.Location = new System.Drawing.Point(284, 236);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(95, 38);
            this.Btn_Login.TabIndex = 51;
            this.Btn_Login.Tag = "s";
            this.Btn_Login.Text = "Login";
            this.Btn_Login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(128, 174);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 50;
            this.label11.Text = "Password ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(128, 110);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 48;
            this.label12.Text = "User Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(284, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 52;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(284, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 53;
            this.textBox2.Text = "IfXS7p27aXewcoNUys5Bqw==";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(131, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 47);
            this.button1.TabIndex = 55;
            this.button1.Text = "Primary Information";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(485, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.label11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
       // private AlmaqarPOSDataSet almaqarPOSDataSet;
    }
}

