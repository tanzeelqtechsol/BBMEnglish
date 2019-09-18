namespace BumedianBM
{
    partial class Item_Serial_Number
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
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSerialNO = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvItemSerialNO = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSerialNO)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblSerialNo.Location = new System.Drawing.Point(280, 32);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(98, 31);
            this.lblSerialNo.TabIndex = 65;
            this.lblSerialNo.Text = "الرقم التسلسلي\r\n";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtItemName.Location = new System.Drawing.Point(5, 4);
            this.txtItemName.MaxLength = 200;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(272, 30);
            this.txtItemName.TabIndex = 63;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblItemName.Location = new System.Drawing.Point(280, -1);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(82, 31);
            this.lblItemName.TabIndex = 64;
            this.lblItemName.Text = "اسم الصنف\r\n";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(75, 224);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(122, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "  خروج ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSerialNO
            // 
            this.txtSerialNO.BackColor = System.Drawing.SystemColors.Info;
            this.txtSerialNO.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.txtSerialNO.Location = new System.Drawing.Point(5, 38);
            this.txtSerialNO.MaxLength = 100;
            this.txtSerialNO.Name = "txtSerialNO";
            this.txtSerialNO.Size = new System.Drawing.Size(272, 30);
            this.txtSerialNO.TabIndex = 0;
            this.txtSerialNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNO_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(252, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 145);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(4, 105);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPrint.Size = new System.Drawing.Size(122, 37);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "  طباعة  \r\n";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(4, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(122, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "  الغاء   \r\n";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::BumedianBM.Properties.Resources.diskette_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(122, 37);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "  حفظ\r\n";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvItemSerialNO
            // 
            this.dgvItemSerialNO.AllowUserToAddRows = false;
            this.dgvItemSerialNO.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItemSerialNO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.ItemSerialNo});
            this.dgvItemSerialNO.Location = new System.Drawing.Point(6, 74);
            this.dgvItemSerialNO.MultiSelect = false;
            this.dgvItemSerialNO.Name = "dgvItemSerialNO";
            this.dgvItemSerialNO.RowHeadersVisible = false;
            this.dgvItemSerialNO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemSerialNO.Size = new System.Drawing.Size(243, 148);
            this.dgvItemSerialNO.TabIndex = 6;
            this.dgvItemSerialNO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemSerialNO_CellDoubleClick);
            // 
            // Item
            // 
            this.Item.DataPropertyName = "ItemName";
            this.Item.HeaderText = "اسم الصنف\r\n";
            this.Item.Name = "Item";
            this.Item.Width = 130;
            // 
            // ItemSerialNo
            // 
            this.ItemSerialNo.DataPropertyName = "ItemSerialNo";
            this.ItemSerialNo.HeaderText = "الرقم التسلسلي\r\n";
            this.ItemSerialNo.Name = "ItemSerialNo";
            this.ItemSerialNo.Width = 110;
            // 
            // Item_Serial_Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(382, 265);
            this.Controls.Add(this.lblSerialNo);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSerialNO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvItemSerialNO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Item_Serial_Number";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_Serial_Number";
            this.Load += new System.EventHandler(this.Item_Serial_Number_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Item_Serial_Number_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSerialNO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtSerialNO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvItemSerialNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemSerialNo;
    }
}