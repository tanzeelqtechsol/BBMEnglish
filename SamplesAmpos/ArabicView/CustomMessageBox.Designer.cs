namespace BumedianBM.ArabicView
{
    partial class CustomMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnPrintNew = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.btnPrintReceipt);
            this.panel1.Controls.Add(this.btnPrintNew);
            this.panel1.Controls.Add(this.btnPrintAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 124);
            this.panel1.TabIndex = 0;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.Location = new System.Drawing.Point(358, 8);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(156, 104);
            this.btnPrintReceipt.TabIndex = 0;
            this.btnPrintReceipt.Tag = "Print Receipt";
            this.btnPrintReceipt.Text = "طباعة إيصال الزبون";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnClickEvent_Click);
            // 
            // btnPrintNew
            // 
            this.btnPrintNew.BackColor = System.Drawing.Color.SandyBrown;
            this.btnPrintNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintNew.Location = new System.Drawing.Point(191, 8);
            this.btnPrintNew.Name = "btnPrintNew";
            this.btnPrintNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrintNew.Size = new System.Drawing.Size(156, 104);
            this.btnPrintNew.TabIndex = 0;
            this.btnPrintNew.Tag = "Print New";
            this.btnPrintNew.Text = "طباعة المضاف حديثا";
            this.btnPrintNew.UseVisualStyleBackColor = false;
            this.btnPrintNew.Click += new System.EventHandler(this.btnClickEvent_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.BackColor = System.Drawing.Color.Tomato;
            this.btnPrintAll.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintAll.Location = new System.Drawing.Point(22, 8);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrintAll.Size = new System.Drawing.Size(163, 104);
            this.btnPrintAll.TabIndex = 0;
            this.btnPrintAll.Tag = "Print All";
            this.btnPrintAll.Text = "طباعة الطلبية كاملة";
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnClickEvent_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblMsg.Location = new System.Drawing.Point(50, 18);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMsg.Size = new System.Drawing.Size(464, 31);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "ما الذي ترغب في طباعته؟";
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(530, 190);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnPrintNew;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Label lblMsg;
    }
}