namespace BumedianBM.ArabicView
{
    partial class LoadProgressForm
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
            this.bgwLoad = new System.ComponentModel.BackgroundWorker();
            this.pgbarLoad = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbarLoad
            // 
            this.pgbarLoad.Location = new System.Drawing.Point(109, 252);
            this.pgbarLoad.Name = "pgbarLoad";
            this.pgbarLoad.Size = new System.Drawing.Size(216, 23);
            this.pgbarLoad.Step = 1;
            this.pgbarLoad.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BumedianBM.Properties.Resources.almaqar_logo;
            this.pictureBox1.Location = new System.Drawing.Point(109, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LoadProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(452, 334);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pgbarLoad);
            this.Name = "LoadProgressForm";
            this.Text = "LoadProgressForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwLoad;
        private System.Windows.Forms.ProgressBar pgbarLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}