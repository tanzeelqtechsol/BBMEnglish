namespace BumedianBM.ArabicView
{
    partial class ExportMessage
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
            this.txt_CashClientName = new System.Windows.Forms.TextBox();
            this.lbl_CashClientName = new System.Windows.Forms.Label();
            this.ExportMessagePannel = new System.Windows.Forms.Panel();
            this.PurchaseImport = new System.Windows.Forms.Panel();
            this.chkOverrideSalePrice = new System.Windows.Forms.CheckBox();
            this.chkSameSalePrice = new System.Windows.Forms.CheckBox();
            this.btnExportInvoice = new System.Windows.Forms.Button();
            this.rbnSamePrice = new System.Windows.Forms.RadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rbnActualCost = new System.Windows.Forms.RadioButton();
            this.ExportMessagePannel.SuspendLayout();
            this.PurchaseImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_CashClientName
            // 
            this.txt_CashClientName.Font = new System.Drawing.Font("Simplified Arabic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CashClientName.Location = new System.Drawing.Point(147, 36);
            this.txt_CashClientName.Name = "txt_CashClientName";
            this.txt_CashClientName.Size = new System.Drawing.Size(209, 29);
            this.txt_CashClientName.TabIndex = 0;
            // 
            // lbl_CashClientName
            // 
            this.lbl_CashClientName.Font = new System.Drawing.Font("Simplified Arabic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CashClientName.Location = new System.Drawing.Point(4, 37);
            this.lbl_CashClientName.Name = "lbl_CashClientName";
            this.lbl_CashClientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_CashClientName.Size = new System.Drawing.Size(143, 26);
            this.lbl_CashClientName.TabIndex = 1;
            this.lbl_CashClientName.Tag = "CashClientName";
            this.lbl_CashClientName.Text = "Cash Client Name :";
            this.lbl_CashClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExportMessagePannel
            // 
            this.ExportMessagePannel.Controls.Add(this.PurchaseImport);
            this.ExportMessagePannel.Controls.Add(this.btnExportInvoice);
            this.ExportMessagePannel.Controls.Add(this.rbnSamePrice);
            this.ExportMessagePannel.Controls.Add(this.lblMessage);
            this.ExportMessagePannel.Controls.Add(this.rbnActualCost);
            this.ExportMessagePannel.Location = new System.Drawing.Point(3, 3);
            this.ExportMessagePannel.Name = "ExportMessagePannel";
            this.ExportMessagePannel.Size = new System.Drawing.Size(372, 173);
            this.ExportMessagePannel.TabIndex = 19;
            // 
            // PurchaseImport
            // 
            this.PurchaseImport.Controls.Add(this.chkOverrideSalePrice);
            this.PurchaseImport.Controls.Add(this.chkSameSalePrice);
            this.PurchaseImport.Location = new System.Drawing.Point(0, 0);
            this.PurchaseImport.Name = "PurchaseImport";
            this.PurchaseImport.Size = new System.Drawing.Size(372, 173);
            this.PurchaseImport.TabIndex = 252;
            // 
            // chkOverrideSalePrice
            // 
            this.chkOverrideSalePrice.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkOverrideSalePrice.Location = new System.Drawing.Point(8, 75);
            this.chkOverrideSalePrice.Name = "chkOverrideSalePrice";
            this.chkOverrideSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOverrideSalePrice.Size = new System.Drawing.Size(359, 41);
            this.chkOverrideSalePrice.TabIndex = 1;
            this.chkOverrideSalePrice.Text = "Overwrite the SalePrice with  Imported Price";
            this.chkOverrideSalePrice.UseVisualStyleBackColor = true;
            this.chkOverrideSalePrice.CheckedChanged += new System.EventHandler(this.chkOverrideSalePrice_CheckedChanged);
            // 
            // chkSameSalePrice
            // 
            this.chkSameSalePrice.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkSameSalePrice.Location = new System.Drawing.Point(7, 19);
            this.chkSameSalePrice.Name = "chkSameSalePrice";
            this.chkSameSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSameSalePrice.Size = new System.Drawing.Size(360, 50);
            this.chkSameSalePrice.TabIndex = 0;
            this.chkSameSalePrice.Text = "Keep SalePrice as it in Current SalePrice";
            this.chkSameSalePrice.UseVisualStyleBackColor = true;
            this.chkSameSalePrice.CheckedChanged += new System.EventHandler(this.chkOverrideSalePrice_CheckedChanged);
            // 
            // btnExportInvoice
            // 
            this.btnExportInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExportInvoice.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportInvoice.Image = global::BumedianBM.Properties.Resources.invoice_export_32;
            this.btnExportInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportInvoice.Location = new System.Drawing.Point(109, 122);
            this.btnExportInvoice.Name = "btnExportInvoice";
            this.btnExportInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExportInvoice.Size = new System.Drawing.Size(145, 41);
            this.btnExportInvoice.TabIndex = 251;
            this.btnExportInvoice.Tag = "ExportInv";
            this.btnExportInvoice.Text = "تصدير الفاتورة";
            this.btnExportInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportInvoice.UseVisualStyleBackColor = false;
            this.btnExportInvoice.Click += new System.EventHandler(this.btnExportInvoice_Click);
            // 
            // rbnSamePrice
            // 
            this.rbnSamePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnSamePrice.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.rbnSamePrice.Location = new System.Drawing.Point(40, 40);
            this.rbnSamePrice.Name = "rbnSamePrice";
            this.rbnSamePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnSamePrice.Size = new System.Drawing.Size(265, 29);
            this.rbnSamePrice.TabIndex = 4;
            this.rbnSamePrice.Text = "Export the Cost and Price as the Same";
            this.rbnSamePrice.UseVisualStyleBackColor = true;
            this.rbnSamePrice.CheckedChanged += new System.EventHandler(this.rbnSamePrice_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(90, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(221, 26);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Select any One Export Method:";
            // 
            // rbnActualCost
            // 
            this.rbnActualCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnActualCost.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.rbnActualCost.Location = new System.Drawing.Point(28, 71);
            this.rbnActualCost.Name = "rbnActualCost";
            this.rbnActualCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbnActualCost.Size = new System.Drawing.Size(277, 29);
            this.rbnActualCost.TabIndex = 5;
            this.rbnActualCost.TabStop = true;
            this.rbnActualCost.Text = "Export the actual Invoice Cost and Price";
            this.rbnActualCost.UseVisualStyleBackColor = true;
            this.rbnActualCost.CheckedChanged += new System.EventHandler(this.rbnSamePrice_CheckedChanged);
            // 
            // ExportMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(378, 176);
            this.Controls.Add(this.ExportMessagePannel);
            this.Controls.Add(this.txt_CashClientName);
            this.Controls.Add(this.lbl_CashClientName);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Message";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportMessage_FormClosed);
            this.Load += new System.EventHandler(this.ExportMessage_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExportMessage_KeyPress);
            this.ExportMessagePannel.ResumeLayout(false);
            this.PurchaseImport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_CashClientName;
        private System.Windows.Forms.Label lbl_CashClientName;
        public System.Windows.Forms.Panel ExportMessagePannel;
        public System.Windows.Forms.RadioButton rbnSamePrice;
        public System.Windows.Forms.Label lblMessage;
        public System.Windows.Forms.RadioButton rbnActualCost;
        private System.Windows.Forms.Button btnExportInvoice;
        private System.Windows.Forms.Panel PurchaseImport;
        private System.Windows.Forms.CheckBox chkOverrideSalePrice;
        private System.Windows.Forms.CheckBox chkSameSalePrice;

    }
}