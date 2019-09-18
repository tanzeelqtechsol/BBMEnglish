namespace BumedianBM.ArabicView
{
    partial class ShowFavoritesUserQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.MaskedTextBox();
            this.btn_ShowHideText = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.Dg_FavQueries = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.chkWrapText = new System.Windows.Forms.CheckBox();
            this.panelShowText = new System.Windows.Forms.Panel();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_FavQueries)).BeginInit();
            this.panelShowText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 161;
            this.label1.Tag = "Search";
            this.label1.Text = "بحث";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(12, 41);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(258, 24);
            this.txtSearch.TabIndex = 160;
            this.txtSearch.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtSearch_MaskInputRejected);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btn_ShowHideText
            // 
            this.btn_ShowHideText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_ShowHideText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ShowHideText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowHideText.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btn_ShowHideText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ShowHideText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ShowHideText.Location = new System.Drawing.Point(331, 12);
            this.btn_ShowHideText.Name = "btn_ShowHideText";
            this.btn_ShowHideText.Size = new System.Drawing.Size(156, 41);
            this.btn_ShowHideText.TabIndex = 165;
            this.btn_ShowHideText.Tag = "Show Text";
            this.btn_ShowHideText.Text = "عرض النص";
            this.btn_ShowHideText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ShowHideText.UseVisualStyleBackColor = false;
            this.btn_ShowHideText.Click += new System.EventHandler(this.btn_ShowHideText_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(670, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 41);
            this.btnCancel.TabIndex = 167;
            this.btnCancel.Tag = "Close";
            this.btnCancel.Text = "أغلق";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.Image = global::BumedianBM.Properties.Resources.invoice_save_32;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(518, 530);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(146, 41);
            this.btnOk.TabIndex = 168;
            this.btnOk.Tag = "OK";
            this.btnOk.Text = "حسنا";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Image = global::BumedianBM.Properties.Resources.new__4_;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(321, 403);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(146, 41);
            this.btnNew.TabIndex = 169;
            this.btnNew.Tag = "New";
            this.btnNew.Text = "الجديد";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Image = global::BumedianBM.Properties.Resources.statistic_write_32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(169, 403);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(146, 41);
            this.btnEdit.TabIndex = 170;
            this.btnEdit.Tag = "Edit";
            this.btnEdit.Text = "تصحيح";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Image = global::BumedianBM.Properties.Resources.Delete_report__4_;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(5, 403);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 41);
            this.btnDelete.TabIndex = 171;
            this.btnDelete.Tag = "Delete";
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrid.Controls.Add(this.Dg_FavQueries);
            this.panelGrid.Controls.Add(this.btnEdit);
            this.panelGrid.Controls.Add(this.btnNew);
            this.panelGrid.Controls.Add(this.btnDelete);
            this.panelGrid.Location = new System.Drawing.Point(9, 75);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(478, 449);
            this.panelGrid.TabIndex = 172;
            // 
            // Dg_FavQueries
            // 
            this.Dg_FavQueries.AllowUserToAddRows = false;
            this.Dg_FavQueries.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dg_FavQueries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Dg_FavQueries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dg_FavQueries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dg_FavQueries.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Dg_FavQueries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dg_FavQueries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_FavQueries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.Dg_FavQueries.ColumnHeadersHeight = 33;
            this.Dg_FavQueries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dg_FavQueries.EnableHeadersVisualStyles = false;
            this.Dg_FavQueries.Location = new System.Drawing.Point(5, 3);
            this.Dg_FavQueries.MultiSelect = false;
            this.Dg_FavQueries.Name = "Dg_FavQueries";
            this.Dg_FavQueries.ReadOnly = true;
            this.Dg_FavQueries.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_FavQueries.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.Dg_FavQueries.RowHeadersVisible = false;
            this.Dg_FavQueries.RowHeadersWidth = 15;
            this.Dg_FavQueries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dg_FavQueries.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_FavQueries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg_FavQueries.Size = new System.Drawing.Size(469, 382);
            this.Dg_FavQueries.TabIndex = 167;
            this.Dg_FavQueries.SelectionChanged += new System.EventHandler(this.Dg_FavQueries_SelectionChanged);
            this.Dg_FavQueries.DoubleClick += new System.EventHandler(this.Dg_FavQueries_DoubleClick);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Location = new System.Drawing.Point(3, 63);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuery.Size = new System.Drawing.Size(317, 386);
            this.txtQuery.TabIndex = 2;
            // 
            // chkWrapText
            // 
            this.chkWrapText.AutoSize = true;
            this.chkWrapText.Location = new System.Drawing.Point(3, 3);
            this.chkWrapText.Name = "chkWrapText";
            this.chkWrapText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkWrapText.Size = new System.Drawing.Size(103, 35);
            this.chkWrapText.TabIndex = 174;
            this.chkWrapText.Tag = "Wrap text";
            this.chkWrapText.Text = "دوران النص";
            this.chkWrapText.UseVisualStyleBackColor = true;
            this.chkWrapText.CheckedChanged += new System.EventHandler(this.chkWrapText_CheckedChanged);
            // 
            // panelShowText
            // 
            this.panelShowText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelShowText.Controls.Add(this.chkWrapText);
            this.panelShowText.Controls.Add(this.txtQuery);
            this.panelShowText.Location = new System.Drawing.Point(493, 12);
            this.panelShowText.Name = "panelShowText";
            this.panelShowText.Size = new System.Drawing.Size(323, 508);
            this.panelShowText.TabIndex = 173;
            // 
            // ShowFavoritesUserQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(828, 583);
            this.Controls.Add(this.panelShowText);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn_ShowHideText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowFavoritesUserQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query Favorites";
            this.Load += new System.EventHandler(this.ShowFavoritesUserQuery_Load);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dg_FavQueries)).EndInit();
            this.panelShowText.ResumeLayout(false);
            this.panelShowText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtSearch;
        private System.Windows.Forms.Button btn_ShowHideText;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView Dg_FavQueries;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.CheckBox chkWrapText;
        private System.Windows.Forms.Panel panelShowText;
    }
}