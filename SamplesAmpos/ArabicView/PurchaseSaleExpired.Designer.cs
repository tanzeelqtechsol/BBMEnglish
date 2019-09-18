namespace BumedianBM.ArabicView
{
    partial class PurchaseSaleExpired
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
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Lbl_PurchaseExpiredMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("Simplified Arabic", 29F, System.Drawing.FontStyle.Bold);
            this.Btn_Close.ForeColor = System.Drawing.Color.Black;
            this.Btn_Close.Location = new System.Drawing.Point(113, 200);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(162, 71);
            this.Btn_Close.TabIndex = 4;
            this.Btn_Close.Text = "موافق\r\n";
            this.Btn_Close.UseVisualStyleBackColor = false;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Lbl_PurchaseExpiredMsg
            // 
            this.Lbl_PurchaseExpiredMsg.Font = new System.Drawing.Font("Simplified Arabic", 40F, System.Drawing.FontStyle.Bold);
            this.Lbl_PurchaseExpiredMsg.ForeColor = System.Drawing.Color.Tomato;
            this.Lbl_PurchaseExpiredMsg.Location = new System.Drawing.Point(1, 0);
            this.Lbl_PurchaseExpiredMsg.Name = "Lbl_PurchaseExpiredMsg";
            this.Lbl_PurchaseExpiredMsg.Size = new System.Drawing.Size(380, 197);
            this.Lbl_PurchaseExpiredMsg.TabIndex = 3;
            this.Lbl_PurchaseExpiredMsg.Text = "انتهت صلاحية هذا الصنف لا يمكن شراءه";
            this.Lbl_PurchaseExpiredMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PurchaseSaleExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(380, 274);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Lbl_PurchaseExpiredMsg);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseSaleExpired";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنبيه! انتهاء صلاحية";
            this.Load += new System.EventHandler(this.PurchaseExpired_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PurchaseSaleExpired_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Label Lbl_PurchaseExpiredMsg;
    }
}