namespace BumedianBM.ArabicView
{
    partial class TipOfDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipOfDay));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Tip = new System.Windows.Forms.Label();
            this.Pic_Tip = new System.Windows.Forms.PictureBox();
            this.RTxt_Tip = new System.Windows.Forms.RichTextBox();
            this.btnNextTip = new System.Windows.Forms.Button();
            this.chkShowTip = new System.Windows.Forms.CheckBox();
            this.btnPrevTip = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Tip)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(197, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(62, 58);
            this.panel2.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "ãæÇÝÞ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 39);
            this.label1.TabIndex = 31;
            this.label1.Text = "áÇ íãßä ÕÑÝ ÝÇÊæÑÉ áåÐÇ ÇáÚãíá \r\n\r\náÊÌÇæÒå ÓÞÝ ÇáÏíæä ÇáãÍÏÏ áå";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(9, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_Tip);
            this.groupBox1.Controls.Add(this.Pic_Tip);
            this.groupBox1.Controls.Add(this.RTxt_Tip);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(15, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_Tip
            // 
            this.Lbl_Tip.AutoSize = true;
            this.Lbl_Tip.BackColor = System.Drawing.Color.White;
            this.Lbl_Tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Lbl_Tip.Location = new System.Drawing.Point(196, 30);
            this.Lbl_Tip.Name = "Lbl_Tip";
            this.Lbl_Tip.Size = new System.Drawing.Size(112, 16);
            this.Lbl_Tip.TabIndex = 5;
            this.Lbl_Tip.Text = "Did you know...";
            // 
            // Pic_Tip
            // 
            this.Pic_Tip.BackColor = System.Drawing.Color.White;
            this.Pic_Tip.Image = ((System.Drawing.Image)(resources.GetObject("Pic_Tip.Image")));
            this.Pic_Tip.Location = new System.Drawing.Point(314, 22);
            this.Pic_Tip.Name = "Pic_Tip";
            this.Pic_Tip.Size = new System.Drawing.Size(32, 32);
            this.Pic_Tip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic_Tip.TabIndex = 4;
            this.Pic_Tip.TabStop = false;
            // 
            // RTxt_Tip
            // 
            this.RTxt_Tip.BackColor = System.Drawing.Color.White;
            this.RTxt_Tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTxt_Tip.Location = new System.Drawing.Point(5, 12);
            this.RTxt_Tip.MaxLength = 1000;
            this.RTxt_Tip.Name = "RTxt_Tip";
            this.RTxt_Tip.ReadOnly = true;
            this.RTxt_Tip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RTxt_Tip.Size = new System.Drawing.Size(354, 194);
            this.RTxt_Tip.TabIndex = 4;
            this.RTxt_Tip.Text = "\n\n\n       ";
            // 
            // btnNextTip
            // 
            this.btnNextTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNextTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextTip.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold);
            this.btnNextTip.Location = new System.Drawing.Point(136, 257);
            this.btnNextTip.Name = "btnNextTip";
            this.btnNextTip.Size = new System.Drawing.Size(121, 41);
            this.btnNextTip.TabIndex = 2;
            this.btnNextTip.Text = "&Next Tip";
            this.btnNextTip.UseVisualStyleBackColor = false;
            this.btnNextTip.Click += new System.EventHandler(this.Btn_NextTip_Click);
            // 
            // chkShowTip
            // 
            this.chkShowTip.AutoSize = true;
            this.chkShowTip.Checked = true;
            this.chkShowTip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkShowTip.Location = new System.Drawing.Point(248, 234);
            this.chkShowTip.Name = "chkShowTip";
            this.chkShowTip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowTip.Size = new System.Drawing.Size(126, 17);
            this.chkShowTip.TabIndex = 3;
            this.chkShowTip.Text = "&Show Tips on startup";
            this.chkShowTip.UseVisualStyleBackColor = true;
            // 
            // btnPrevTip
            // 
            this.btnPrevTip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrevTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevTip.Font = new System.Drawing.Font("Simplified Arabic Fixed", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrevTip.Location = new System.Drawing.Point(263, 257);
            this.btnPrevTip.Name = "btnPrevTip";
            this.btnPrevTip.Size = new System.Drawing.Size(121, 41);
            this.btnPrevTip.TabIndex = 5;
            this.btnPrevTip.Text = "&Prev Tip";
            this.btnPrevTip.UseVisualStyleBackColor = false;
            this.btnPrevTip.Click += new System.EventHandler(this.Btn_PrevTip_Click);
            // 
            // TipOfDay
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(395, 301);
            this.ControlBox = false;
            this.Controls.Add(this.btnPrevTip);
            this.Controls.Add(this.chkShowTip);
            this.Controls.Add(this.btnNextTip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipOfDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "TipOfDay";
            this.Text = "معلومة اليوم ";
            this.Load += new System.EventHandler(this.TipOfDay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Tip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNextTip;
        private System.Windows.Forms.RichTextBox RTxt_Tip;
        private System.Windows.Forms.CheckBox chkShowTip;
        private System.Windows.Forms.PictureBox Pic_Tip;
        private System.Windows.Forms.Label Lbl_Tip;
        private System.Windows.Forms.Button btnPrevTip;
    }
}