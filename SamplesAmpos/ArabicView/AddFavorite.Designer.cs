namespace BumedianBM.ArabicView
{
    partial class AddFavorite
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
            this.txtTitle = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.chkReleased = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExtportFileName = new System.Windows.Forms.MaskedTextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTitle.Location = new System.Drawing.Point(13, 41);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(257, 24);
            this.txtTitle.TabIndex = 158;
            this.txtTitle.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtTitle_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 25);
            this.label1.TabIndex = 159;
            this.label1.Tag = "Title";
            this.label1.Text = "عنوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 161;
            this.label2.Tag = "Query Text";
            this.label2.Text = "نص الاستعلام";
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtQuery.Location = new System.Drawing.Point(13, 128);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuery.Size = new System.Drawing.Size(517, 351);
            this.txtQuery.TabIndex = 162;
            // 
            // chkReleased
            // 
            this.chkReleased.AutoSize = true;
            this.chkReleased.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkReleased.Location = new System.Drawing.Point(18, 75);
            this.chkReleased.Name = "chkReleased";
            this.chkReleased.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkReleased.Size = new System.Drawing.Size(55, 22);
            this.chkReleased.TabIndex = 167;
            this.chkReleased.Tag = "Relased";
            this.chkReleased.Text = "صدر";
            this.chkReleased.UseVisualStyleBackColor = true;
            this.chkReleased.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 171;
            this.label3.Tag = "Export File Name";
            this.label3.Text = "اسم ملف التصدير";
            // 
            // txtExtportFileName
            // 
            this.txtExtportFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtExtportFileName.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtportFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtExtportFileName.Location = new System.Drawing.Point(13, 514);
            this.txtExtportFileName.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtExtportFileName.Name = "txtExtportFileName";
            this.txtExtportFileName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExtportFileName.Size = new System.Drawing.Size(212, 24);
            this.txtExtportFileName.TabIndex = 170;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Add.Image = global::BumedianBM.Properties.Resources.invoice_save_32;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.Location = new System.Drawing.Point(233, 511);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(146, 41);
            this.btn_Add.TabIndex = 169;
            this.btn_Add.Tag = "OK";
            this.btn_Add.Text = "حسنا";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click_1);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Location = new System.Drawing.Point(385, 511);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(146, 41);
            this.btn_Cancel.TabIndex = 168;
            this.btn_Cancel.Tag = "Close";
            this.btn_Cancel.Text = "أغلق";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click_1);
            // 
            // AddFavorite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(541, 564);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExtportFileName);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.chkReleased);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFavorite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صدر";
            this.Load += new System.EventHandler(this.AddFavorite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.CheckBox chkReleased;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtExtportFileName;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
    }
}