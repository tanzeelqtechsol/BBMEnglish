namespace BumedianBM.ArabicView
{
    partial class expired_purcheses
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
            this.Lbl_PurchaseExpiredMsg = new System.Windows.Forms.Label();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_PurchaseExpiredMsg
            // 
            this.Lbl_PurchaseExpiredMsg.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PurchaseExpiredMsg.ForeColor = System.Drawing.Color.Red;
            this.Lbl_PurchaseExpiredMsg.Location = new System.Drawing.Point(12, 9);
            this.Lbl_PurchaseExpiredMsg.Name = "Lbl_PurchaseExpiredMsg";
            this.Lbl_PurchaseExpiredMsg.Size = new System.Drawing.Size(449, 255);
            this.Lbl_PurchaseExpiredMsg.TabIndex = 1;
            this.Lbl_PurchaseExpiredMsg.Text = "انتهت صلاحية هذا الصنف لا يمكن شراءه";
            this.Lbl_PurchaseExpiredMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.Btn_Close.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Close.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Close.Location = new System.Drawing.Point(159, 281);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(162, 71);
            this.Btn_Close.TabIndex = 2;
            this.Btn_Close.Text = "موافق\r\n";
            this.Btn_Close.UseVisualStyleBackColor = false;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // expired_purcheses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(468, 362);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Lbl_PurchaseExpiredMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "expired_purcheses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنبيه! انتهاء صلاحية";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_PurchaseExpiredMsg;
        private System.Windows.Forms.Button Btn_Close;
    }
}