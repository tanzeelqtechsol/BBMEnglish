namespace BumedianBM.ArabicView
{
    partial class PaymentTypesCharges
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
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPercentageCard = new System.Windows.Forms.MaskedTextBox();
            this.txtPercentageCheck = new System.Windows.Forms.MaskedTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(159, 169);
            this.btnClear.Name = "btnClear";
            this.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClear.Size = new System.Drawing.Size(146, 41);
            this.btnClear.TabIndex = 318;
            this.btnClear.Tag = "Close";
            this.btnClear.Text = "أغلق";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtPercentageCard
            // 
            this.txtPercentageCard.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercentageCard.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.txtPercentageCard.Location = new System.Drawing.Point(7, 118);
            this.txtPercentageCard.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtPercentageCard.Name = "txtPercentageCard";
            this.txtPercentageCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercentageCard.Size = new System.Drawing.Size(266, 32);
            this.txtPercentageCard.TabIndex = 328;
            // 
            // txtPercentageCheck
            // 
            this.txtPercentageCheck.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercentageCheck.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.txtPercentageCheck.Location = new System.Drawing.Point(7, 44);
            this.txtPercentageCheck.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtPercentageCheck.Name = "txtPercentageCheck";
            this.txtPercentageCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercentageCheck.Size = new System.Drawing.Size(266, 32);
            this.txtPercentageCheck.TabIndex = 327;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubmit.Image = global::BumedianBM.Properties.Resources.invoice_save_32;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.Location = new System.Drawing.Point(7, 169);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSubmit.Size = new System.Drawing.Size(146, 41);
            this.btnSubmit.TabIndex = 329;
            this.btnSubmit.Tag = "OK";
            this.btnSubmit.Text = "حسنا";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblCheck
            // 
            this.lblCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCheck.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCheck.Location = new System.Drawing.Point(12, 12);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(189, 28);
            this.lblCheck.TabIndex = 330;
            this.lblCheck.Tag = "Check";
            this.lblCheck.Text = "صك";
            // 
            // lblCard
            // 
            this.lblCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCard.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCard.Location = new System.Drawing.Point(13, 86);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(178, 28);
            this.lblCard.TabIndex = 331;
            this.lblCard.Tag = "Card";
            this.lblCard.Text = "بطاقة";
            // 
            // PaymentTypesCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(352, 233);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtPercentageCard);
            this.Controls.Add(this.txtPercentageCheck);
            this.Controls.Add(this.btnClear);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentTypesCharges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Types Charges";
            this.Load += new System.EventHandler(this.PaymentTypesCharges_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MaskedTextBox txtPercentageCard;
        private System.Windows.Forms.MaskedTextBox txtPercentageCheck;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblCard;
    }
}