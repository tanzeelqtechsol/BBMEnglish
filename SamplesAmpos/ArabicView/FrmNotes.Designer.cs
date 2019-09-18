namespace AlmaqarPOS.English
{
    partial class FrmNotes
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
            this.RTxt_Note = new System.Windows.Forms.RichTextBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RTxt_Note
            // 
            this.RTxt_Note.BackColor = System.Drawing.Color.White;
            this.RTxt_Note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTxt_Note.Location = new System.Drawing.Point(25, 38);
            this.RTxt_Note.MaxLength = 2000;
            this.RTxt_Note.Name = "RTxt_Note";
            this.RTxt_Note.Size = new System.Drawing.Size(294, 139);
            this.RTxt_Note.TabIndex = 38;
            this.RTxt_Note.Text = "";// 30-01-2017  global::BumedianBM.ResourceFile.Resources_en_us.String1;
            // 
            // Btn_Send
            // 
            this.Btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Send.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Send.Location = new System.Drawing.Point(79, 197);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(96, 44);
            this.Btn_Send.TabIndex = 85;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Btn_Cancel.Location = new System.Drawing.Point(181, 197);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(97, 44);
            this.Btn_Cancel.TabIndex = 86;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // FrmNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(356, 262);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Send);
            this.Controls.Add(this.RTxt_Note);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTxt_Note;
        public System.Windows.Forms.Button Btn_Send;
        public System.Windows.Forms.Button Btn_Cancel;
    }
}