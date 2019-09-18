namespace BumedianBM
{
    partial class ItemDetails
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.81375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.18625F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(738, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 281);
            this.panel1.TabIndex = 0;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToDeleteRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItem.ColumnHeadersHeight = 34;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNo,
            this.ItemName,
            this.UnitType,
            this.UnitName,
            this.PackageQty,
            this.Price,
            this.Cost,
            this.Quantity,
            this.Expiry,
            this.Select,
            this.SerialNO});
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.Location = new System.Drawing.Point(0, 0);
            this.dgvItem.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(728, 281);
            this.dgvItem.TabIndex = 0;
            // 
            // ItemNo
            // 
            this.ItemNo.DataPropertyName = "ItemNo";
            this.ItemNo.HeaderText = "ItemNo";
            this.ItemNo.Name = "ItemNo";
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // UnitType
            // 
            this.UnitType.DataPropertyName = "UnitType";
            this.UnitType.HeaderText = "UnitType";
            this.UnitType.Name = "UnitType";
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "UnitName";
            this.UnitName.Name = "UnitName";
            // 
            // PackageQty
            // 
            this.PackageQty.DataPropertyName = "ItemPackage";
            this.PackageQty.HeaderText = "PackageQty";
            this.PackageQty.Name = "PackageQty";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "ItemPrice";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "ItemCost";
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "ItemQuantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Expiry
            // 
            this.Expiry.DataPropertyName = "ItemExpiry";
            this.Expiry.HeaderText = "Expiry";
            this.Expiry.Name = "Expiry";
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Select ";
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // SerialNO
            // 
            this.SerialNO.DataPropertyName = "SerialNO";
            this.SerialNO.HeaderText = "SerialNO";
            this.SerialNO.Name = "SerialNO";
            this.SerialNO.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 302);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 40);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_Date);
            this.panel3.Controls.Add(this.dtpDate);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnInsert);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(728, 40);
            this.panel3.TabIndex = 0;
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Location = new System.Drawing.Point(7, 3);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(49, 31);
            this.lbl_Date.TabIndex = 3;
            this.lbl_Date.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Simplified Arabic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(62, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.Size = new System.Drawing.Size(115, 27);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(345, -1);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 41);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Image = global::BumedianBM.Properties.Resources.insert_item_32;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(185, -1);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(150, 41);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // ItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(738, 349);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemDetails";
            this.Load += new System.EventHandler(this.ItemDetails_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemDetails_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiry;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNO;

    }
}