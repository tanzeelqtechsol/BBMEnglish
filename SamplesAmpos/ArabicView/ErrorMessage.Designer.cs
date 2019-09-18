namespace BumedianBM.ArabicView
{
    partial class ErrorMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessage));
            this.lblerroemessage = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblerroemessage
            // 
            this.lblerroemessage.AutoSize = true;
            this.lblerroemessage.Location = new System.Drawing.Point(89, 21);
            this.lblerroemessage.Name = "lblerroemessage";
            this.lblerroemessage.Size = new System.Drawing.Size(0, 13);
            this.lblerroemessage.TabIndex = 0;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(43, 70);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnContinue.Size = new System.Drawing.Size(89, 40);
            this.btnContinue.TabIndex = 180;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Simplified Arabic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(158, 70);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUndo.Size = new System.Drawing.Size(89, 40);
            this.btnUndo.TabIndex = 181;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.ntnUndo_Click);
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(309, 118);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblerroemessage);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 156);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 156);
            this.Name = "ErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ErrorMessage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ErrorMessage_FormClosed);
            this.Load += new System.EventHandler(this.ErrorMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblerroemessage;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnUndo;
    }
}