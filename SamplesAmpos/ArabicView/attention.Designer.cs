namespace BumedianBM.ArabicView
{
    partial class frmattention
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
            this.btnSaleRtnItem = new System.Windows.Forms.Button();
            this.btnPurchaseRtn = new System.Windows.Forms.Button();
            this.lblOneRtnInvoice = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaleRtnItem
            // 
            this.btnSaleRtnItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaleRtnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleRtnItem.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnSaleRtnItem.ForeColor = System.Drawing.Color.Navy;
            this.btnSaleRtnItem.Location = new System.Drawing.Point(22, 68);
            this.btnSaleRtnItem.Name = "btnSaleRtnItem";
            this.btnSaleRtnItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaleRtnItem.Size = new System.Drawing.Size(122, 49);
            this.btnSaleRtnItem.TabIndex = 12;
            this.btnSaleRtnItem.Text = "ارجاع مبيعات ";
            this.btnSaleRtnItem.UseVisualStyleBackColor = false;
            this.btnSaleRtnItem.Click += new System.EventHandler(this.Btn_SaleRtnItem_Click);
            // 
            // btnPurchaseRtn
            // 
            this.btnPurchaseRtn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPurchaseRtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRtn.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseRtn.ForeColor = System.Drawing.Color.Navy;
            this.btnPurchaseRtn.Location = new System.Drawing.Point(180, 68);
            this.btnPurchaseRtn.Name = "btnPurchaseRtn";
            this.btnPurchaseRtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPurchaseRtn.Size = new System.Drawing.Size(122, 49);
            this.btnPurchaseRtn.TabIndex = 11;
            this.btnPurchaseRtn.Text = "ارجاع مشتريات ";
            this.btnPurchaseRtn.UseVisualStyleBackColor = false;
            this.btnPurchaseRtn.Click += new System.EventHandler(this.Btn_PurchaseRtnItem_Click);
            // 
            // lblOneRtnInvoice
            // 
            this.lblOneRtnInvoice.Font = new System.Drawing.Font("Simplified Arabic", 19F, System.Drawing.FontStyle.Bold);
            this.lblOneRtnInvoice.ForeColor = System.Drawing.Color.Tomato;
            this.lblOneRtnInvoice.Location = new System.Drawing.Point(2, 3);
            this.lblOneRtnInvoice.Name = "lblOneRtnInvoice";
            this.lblOneRtnInvoice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOneRtnInvoice.Size = new System.Drawing.Size(323, 52);
            this.lblOneRtnInvoice.TabIndex = 13;
            this.lblOneRtnInvoice.Text = "رجاء! اختر احدى فواتير الترجيع ";
            this.lblOneRtnInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Navy;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(106, 132);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(122, 49);
            this.btnClose.TabIndex = 337;
            this.btnClose.Text = "اغلاق";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // frmattention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(318, 187);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblOneRtnInvoice);
            this.Controls.Add(this.btnSaleRtnItem);
            this.Controls.Add(this.btnPurchaseRtn);
            this.Name = "frmattention";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اختر فاتورة الارجاع ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaleRtnItem;
        private System.Windows.Forms.Button btnPurchaseRtn;
        private System.Windows.Forms.Label lblOneRtnInvoice;
        private System.Windows.Forms.Button btnClose;
    }
}