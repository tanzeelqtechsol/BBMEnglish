namespace BumedianBM.ArabicView
{
    partial class EndShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndShift));
            this.lblUser = new System.Windows.Forms.Label();
            this.Txt_User = new System.Windows.Forms.TextBox();
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.Txt_LoginTime = new System.Windows.Forms.TextBox();
            this.llbHours = new System.Windows.Forms.Label();
            this.txt_HoursWokred = new System.Windows.Forms.TextBox();
            this.txt_TotalSales = new System.Windows.Forms.TextBox();
            this.lblTotalRecieved = new System.Windows.Forms.Label();
            this.txt_TotalRecieved = new System.Windows.Forms.TextBox();
            this.lblTotalPaid = new System.Windows.Forms.Label();
            this.txt_TotalPaid = new System.Windows.Forms.TextBox();
            this.lblNetCash = new System.Windows.Forms.Label();
            this.txt_NetCash1 = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEndShift = new System.Windows.Forms.Button();
            this.llbTotalSalesCash = new System.Windows.Forms.Label();
            this.msg1 = new System.Windows.Forms.Label();
            this.msg2 = new System.Windows.Forms.Label();
            this.msg = new System.Windows.Forms.Label();
            this.txt_NetCash = new System.Windows.Forms.TextBox();
            this.lblTotalSaleCard = new System.Windows.Forms.Label();
            this.txtTotalSaleCard = new System.Windows.Forms.TextBox();
            this.lblTotalSaleCheck = new System.Windows.Forms.Label();
            this.txtTotalSaleCheck = new System.Windows.Forms.TextBox();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.txtAllSale = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(91, 122);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUser.Size = new System.Drawing.Size(155, 31);
            this.lblUser.TabIndex = 157;
            this.lblUser.Tag = "UN";
            this.lblUser.Text = "User";
            // 
            // Txt_User
            // 
            this.Txt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_User.Location = new System.Drawing.Point(257, 119);
            this.Txt_User.MaxLength = 100;
            this.Txt_User.Name = "Txt_User";
            this.Txt_User.Size = new System.Drawing.Size(256, 26);
            this.Txt_User.TabIndex = 154;
            this.Txt_User.TextChanged += new System.EventHandler(this.Txt_UserName_TextChanged);
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblLoginTime.Location = new System.Drawing.Point(91, 155);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLoginTime.Size = new System.Drawing.Size(155, 31);
            this.lblLoginTime.TabIndex = 156;
            this.lblLoginTime.Tag = "Psw";
            this.lblLoginTime.Text = "Login Time";
            this.lblLoginTime.Click += new System.EventHandler(this.lblLoginTime_Click);
            // 
            // Txt_LoginTime
            // 
            this.Txt_LoginTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_LoginTime.Location = new System.Drawing.Point(257, 154);
            this.Txt_LoginTime.MaxLength = 50;
            this.Txt_LoginTime.Name = "Txt_LoginTime";
            this.Txt_LoginTime.Size = new System.Drawing.Size(256, 26);
            this.Txt_LoginTime.TabIndex = 155;
            // 
            // llbHours
            // 
            this.llbHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbHours.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.llbHours.Location = new System.Drawing.Point(90, 186);
            this.llbHours.Name = "llbHours";
            this.llbHours.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.llbHours.Size = new System.Drawing.Size(155, 31);
            this.llbHours.TabIndex = 161;
            this.llbHours.Tag = "UN";
            this.llbHours.Text = "hours worked";
            // 
            // txt_HoursWokred
            // 
            this.txt_HoursWokred.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HoursWokred.Location = new System.Drawing.Point(257, 190);
            this.txt_HoursWokred.MaxLength = 100;
            this.txt_HoursWokred.Name = "txt_HoursWokred";
            this.txt_HoursWokred.Size = new System.Drawing.Size(256, 26);
            this.txt_HoursWokred.TabIndex = 158;
            // 
            // txt_TotalSales
            // 
            this.txt_TotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalSales.Location = new System.Drawing.Point(257, 254);
            this.txt_TotalSales.MaxLength = 50;
            this.txt_TotalSales.Name = "txt_TotalSales";
            this.txt_TotalSales.Size = new System.Drawing.Size(256, 26);
            this.txt_TotalSales.TabIndex = 159;
            // 
            // lblTotalRecieved
            // 
            this.lblTotalRecieved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRecieved.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecieved.Location = new System.Drawing.Point(90, 354);
            this.lblTotalRecieved.Name = "lblTotalRecieved";
            this.lblTotalRecieved.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalRecieved.Size = new System.Drawing.Size(143, 31);
            this.lblTotalRecieved.TabIndex = 165;
            this.lblTotalRecieved.Tag = "UN";
            this.lblTotalRecieved.Text = "Total Recieved";
            // 
            // txt_TotalRecieved
            // 
            this.txt_TotalRecieved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalRecieved.Location = new System.Drawing.Point(257, 357);
            this.txt_TotalRecieved.MaxLength = 100;
            this.txt_TotalRecieved.Name = "txt_TotalRecieved";
            this.txt_TotalRecieved.Size = new System.Drawing.Size(256, 26);
            this.txt_TotalRecieved.TabIndex = 162;
            // 
            // lblTotalPaid
            // 
            this.lblTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPaid.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaid.Location = new System.Drawing.Point(90, 395);
            this.lblTotalPaid.Name = "lblTotalPaid";
            this.lblTotalPaid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalPaid.Size = new System.Drawing.Size(143, 31);
            this.lblTotalPaid.TabIndex = 164;
            this.lblTotalPaid.Tag = "Psw";
            this.lblTotalPaid.Text = "Total Paid";
            // 
            // txt_TotalPaid
            // 
            this.txt_TotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalPaid.Location = new System.Drawing.Point(257, 393);
            this.txt_TotalPaid.MaxLength = 50;
            this.txt_TotalPaid.Name = "txt_TotalPaid";
            this.txt_TotalPaid.Size = new System.Drawing.Size(256, 26);
            this.txt_TotalPaid.TabIndex = 163;
            // 
            // lblNetCash
            // 
            this.lblNetCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetCash.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblNetCash.Location = new System.Drawing.Point(90, 439);
            this.lblNetCash.Name = "lblNetCash";
            this.lblNetCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNetCash.Size = new System.Drawing.Size(163, 31);
            this.lblNetCash.TabIndex = 167;
            this.lblNetCash.Tag = "Psw";
            this.lblNetCash.Text = "Net cash in drawer";
            // 
            // txt_NetCash1
            // 
            this.txt_NetCash1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NetCash1.Location = new System.Drawing.Point(257, 430);
            this.txt_NetCash1.MaxLength = 50;
            this.txt_NetCash1.Multiline = true;
            this.txt_NetCash1.Name = "txt_NetCash1";
            this.txt_NetCash1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_NetCash1.Size = new System.Drawing.Size(256, 57);
            this.txt_NetCash1.TabIndex = 166;
            this.txt_NetCash1.TextChanged += new System.EventHandler(this.txt_NetCash_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(88, 514);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 69);
            this.btnPrint.TabIndex = 170;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.item_delete_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(377, 514);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 69);
            this.btnCancel.TabIndex = 171;
            this.btnCancel.Tag = "Delete";
            this.btnCancel.Text = "الغاء\r\n";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEndShift
            // 
            this.btnEndShift.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEndShift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEndShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndShift.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnEndShift.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEndShift.Image = global::BumedianBM.Properties.Resources.user_clock_32;
            this.btnEndShift.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEndShift.Location = new System.Drawing.Point(232, 514);
            this.btnEndShift.Name = "btnEndShift";
            this.btnEndShift.Size = new System.Drawing.Size(139, 69);
            this.btnEndShift.TabIndex = 172;
            this.btnEndShift.Tag = "Close";
            this.btnEndShift.Text = "اغلاق\r\n";
            this.btnEndShift.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEndShift.UseVisualStyleBackColor = false;
            this.btnEndShift.Click += new System.EventHandler(this.btnEndShift_Click);
            // 
            // llbTotalSalesCash
            // 
            this.llbTotalSalesCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbTotalSalesCash.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.llbTotalSalesCash.Location = new System.Drawing.Point(89, 253);
            this.llbTotalSalesCash.Name = "llbTotalSalesCash";
            this.llbTotalSalesCash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.llbTotalSalesCash.Size = new System.Drawing.Size(153, 31);
            this.llbTotalSalesCash.TabIndex = 173;
            this.llbTotalSalesCash.Tag = "UN";
            this.llbTotalSalesCash.Text = "Total Sale Cash";
            // 
            // msg1
            // 
            this.msg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msg1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.msg1.Location = new System.Drawing.Point(92, 41);
            this.msg1.Name = "msg1";
            this.msg1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msg1.Size = new System.Drawing.Size(511, 32);
            this.msg1.TabIndex = 174;
            this.msg1.Tag = "UN";
            this.msg1.Text = "Make sure to close all invoices , count cash";
            // 
            // msg2
            // 
            this.msg2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msg2.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.msg2.Location = new System.Drawing.Point(86, 73);
            this.msg2.Name = "msg2";
            this.msg2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msg2.Size = new System.Drawing.Size(505, 32);
            this.msg2.TabIndex = 175;
            this.msg2.Tag = "UN";
            this.msg2.Text = " in the box and don\'t forget to click end shift button.";
            // 
            // msg
            // 
            this.msg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.msg.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.msg.Location = new System.Drawing.Point(94, 0);
            this.msg.Name = "msg";
            this.msg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.msg.Size = new System.Drawing.Size(162, 29);
            this.msg.TabIndex = 176;
            this.msg.Tag = "UN";
            this.msg.Text = "To close account: ";
            // 
            // txt_NetCash
            // 
            this.txt_NetCash.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_NetCash.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NetCash.Location = new System.Drawing.Point(259, 440);
            this.txt_NetCash.Multiline = true;
            this.txt_NetCash.Name = "txt_NetCash";
            this.txt_NetCash.Size = new System.Drawing.Size(250, 33);
            this.txt_NetCash.TabIndex = 177;
            this.txt_NetCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalSaleCard
            // 
            this.lblTotalSaleCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSaleCard.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaleCard.Location = new System.Drawing.Point(90, 287);
            this.lblTotalSaleCard.Name = "lblTotalSaleCard";
            this.lblTotalSaleCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalSaleCard.Size = new System.Drawing.Size(161, 31);
            this.lblTotalSaleCard.TabIndex = 179;
            this.lblTotalSaleCard.Tag = "UN";
            this.lblTotalSaleCard.Text = "Total Sale Card";
            // 
            // txtTotalSaleCard
            // 
            this.txtTotalSaleCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleCard.Location = new System.Drawing.Point(257, 288);
            this.txtTotalSaleCard.MaxLength = 50;
            this.txtTotalSaleCard.Name = "txtTotalSaleCard";
            this.txtTotalSaleCard.Size = new System.Drawing.Size(256, 26);
            this.txtTotalSaleCard.TabIndex = 178;
            // 
            // lblTotalSaleCheck
            // 
            this.lblTotalSaleCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSaleCheck.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaleCheck.Location = new System.Drawing.Point(90, 321);
            this.lblTotalSaleCheck.Name = "lblTotalSaleCheck";
            this.lblTotalSaleCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalSaleCheck.Size = new System.Drawing.Size(161, 31);
            this.lblTotalSaleCheck.TabIndex = 181;
            this.lblTotalSaleCheck.Tag = "UN";
            this.lblTotalSaleCheck.Text = "Total Sale Check";
            // 
            // txtTotalSaleCheck
            // 
            this.txtTotalSaleCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSaleCheck.Location = new System.Drawing.Point(257, 322);
            this.txtTotalSaleCheck.MaxLength = 50;
            this.txtTotalSaleCheck.Name = "txtTotalSaleCheck";
            this.txtTotalSaleCheck.Size = new System.Drawing.Size(256, 26);
            this.txtTotalSaleCheck.TabIndex = 180;
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSale.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalSale.Location = new System.Drawing.Point(90, 221);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalSale.Size = new System.Drawing.Size(149, 31);
            this.lblTotalSale.TabIndex = 183;
            this.lblTotalSale.Tag = "UN";
            this.lblTotalSale.Text = "Total Sale";
            // 
            // txtAllSale
            // 
            this.txtAllSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllSale.Location = new System.Drawing.Point(257, 222);
            this.txtAllSale.MaxLength = 50;
            this.txtAllSale.Name = "txtAllSale";
            this.txtAllSale.Size = new System.Drawing.Size(256, 26);
            this.txtAllSale.TabIndex = 182;
            // 
            // EndShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(604, 653);
            this.Controls.Add(this.lblTotalSale);
            this.Controls.Add(this.txtAllSale);
            this.Controls.Add(this.lblTotalSaleCheck);
            this.Controls.Add(this.txtTotalSaleCheck);
            this.Controls.Add(this.lblTotalSaleCard);
            this.Controls.Add(this.txtTotalSaleCard);
            this.Controls.Add(this.txt_NetCash);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.msg2);
            this.Controls.Add(this.msg1);
            this.Controls.Add(this.llbTotalSalesCash);
            this.Controls.Add(this.btnEndShift);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblNetCash);
            this.Controls.Add(this.txt_NetCash1);
            this.Controls.Add(this.lblTotalRecieved);
            this.Controls.Add(this.txt_TotalRecieved);
            this.Controls.Add(this.lblTotalPaid);
            this.Controls.Add(this.txt_TotalPaid);
            this.Controls.Add(this.llbHours);
            this.Controls.Add(this.txt_HoursWokred);
            this.Controls.Add(this.txt_TotalSales);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.Txt_User);
            this.Controls.Add(this.lblLoginTime);
            this.Controls.Add(this.Txt_LoginTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndShift";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Shift End";
            this.Load += new System.EventHandler(this.EndShift_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.TextBox Txt_User;
        public System.Windows.Forms.Label lblLoginTime;
        public System.Windows.Forms.TextBox Txt_LoginTime;
        public System.Windows.Forms.Label llbHours;
        public System.Windows.Forms.TextBox txt_HoursWokred;
        public System.Windows.Forms.TextBox txt_TotalSales;
        public System.Windows.Forms.Label lblTotalRecieved;
        public System.Windows.Forms.TextBox txt_TotalRecieved;
        public System.Windows.Forms.Label lblTotalPaid;
        public System.Windows.Forms.TextBox txt_TotalPaid;
        public System.Windows.Forms.Label lblNetCash;
        public System.Windows.Forms.TextBox txt_NetCash1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEndShift;
        public System.Windows.Forms.Label llbTotalSalesCash;
        public System.Windows.Forms.Label msg1;
        public System.Windows.Forms.Label msg2;
        public System.Windows.Forms.Label msg;
        private System.Windows.Forms.TextBox txt_NetCash;
        public System.Windows.Forms.Label lblTotalSaleCard;
        public System.Windows.Forms.TextBox txtTotalSaleCard;
        public System.Windows.Forms.Label lblTotalSaleCheck;
        public System.Windows.Forms.TextBox txtTotalSaleCheck;
        public System.Windows.Forms.Label lblTotalSale;
        public System.Windows.Forms.TextBox txtAllSale;
    }
}