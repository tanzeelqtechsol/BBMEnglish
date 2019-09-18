namespace BumedianBM.ArabicView
{
    partial class PaymentTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentTypes));
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCash.Image = global::BumedianBM.Properties.Resources.bill_48;
            this.btnCash.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCash.Location = new System.Drawing.Point(281, 12);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(126, 90);
            this.btnCash.TabIndex = 327;
            this.btnCash.Tag = "Cash";
            this.btnCash.Text = "Cash F1";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCard.Image = global::BumedianBM.Properties.Resources.credit_cards_48;
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCard.Location = new System.Drawing.Point(142, 12);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(126, 90);
            this.btnCard.TabIndex = 329;
            this.btnCard.Tag = "Card";
            this.btnCard.Text = "Card F2";
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Simplified Arabic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheck.Image = global::BumedianBM.Properties.Resources.check_48;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.Location = new System.Drawing.Point(12, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(119, 90);
            this.btnCheck.TabIndex = 328;
            this.btnCheck.Tag = "Check ";
            this.btnCheck.Text = "Check F3";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(136, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 41);
            this.btnCancel.TabIndex = 317;
            this.btnCancel.Tag = "Cancel";
            this.btnCancel.Text = "أغلق";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PaymentTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(419, 263);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Types";
            this.Load += new System.EventHandler(this.PaymentTypes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaymentTypes_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCard;
    }
}