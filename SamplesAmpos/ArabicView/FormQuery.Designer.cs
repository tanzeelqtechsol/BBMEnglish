namespace BumedianBM.ArabicView
{
    partial class FormQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuery));
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkRightToLift = new System.Windows.Forms.CheckBox();
            this.rdoLandscape = new System.Windows.Forms.RadioButton();
            this.chkEnableDateFromTo = new System.Windows.Forms.CheckBox();
            this.btnSubmitQuery = new System.Windows.Forms.Button();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.rdoPortrait = new System.Windows.Forms.RadioButton();
            this.btnAddtoFav = new System.Windows.Forms.Button();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnFavorites = new System.Windows.Forms.Button();
            this.Dg_Custom = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.MaskedTextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.lblSortHint = new System.Windows.Forms.Label();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Custom)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(274, 221);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(39, 25);
            this.lblTitle.TabIndex = 155;
            this.lblTitle.Tag = "Price";
            this.lblTitle.Text = "Title";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(1, 1);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(540, 205);
            this.txtQuery.TabIndex = 156;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFromTime);
            this.panel1.Controls.Add(this.dtpToTime);
            this.panel1.Controls.Add(this.chkRightToLift);
            this.panel1.Controls.Add(this.rdoLandscape);
            this.panel1.Controls.Add(this.chkEnableDateFromTo);
            this.panel1.Controls.Add(this.btnSubmitQuery);
            this.panel1.Controls.Add(this.dateTo);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.rdoPortrait);
            this.panel1.Controls.Add(this.btnAddtoFav);
            this.panel1.Controls.Add(this.dateFrom);
            this.panel1.Controls.Add(this.btnFavorites);
            this.panel1.Location = new System.Drawing.Point(547, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 205);
            this.panel1.TabIndex = 158;
            // 
            // chkRightToLift
            // 
            this.chkRightToLift.AutoSize = true;
            this.chkRightToLift.Location = new System.Drawing.Point(335, 151);
            this.chkRightToLift.Name = "chkRightToLift";
            this.chkRightToLift.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkRightToLift.Size = new System.Drawing.Size(114, 35);
            this.chkRightToLift.TabIndex = 170;
            this.chkRightToLift.Text = "RigtToLeft";
            this.chkRightToLift.UseVisualStyleBackColor = true;
            // 
            // rdoLandscape
            // 
            this.rdoLandscape.AutoSize = true;
            this.rdoLandscape.Location = new System.Drawing.Point(129, 152);
            this.rdoLandscape.Name = "rdoLandscape";
            this.rdoLandscape.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoLandscape.Size = new System.Drawing.Size(126, 35);
            this.rdoLandscape.TabIndex = 168;
            this.rdoLandscape.TabStop = true;
            this.rdoLandscape.Tag = "Landscap";
            this.rdoLandscape.Text = "الصفحة بالعرض";
            this.rdoLandscape.UseVisualStyleBackColor = true;
            // 
            // chkEnableDateFromTo
            // 
            this.chkEnableDateFromTo.AutoSize = true;
            this.chkEnableDateFromTo.Location = new System.Drawing.Point(321, 110);
            this.chkEnableDateFromTo.Name = "chkEnableDateFromTo";
            this.chkEnableDateFromTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkEnableDateFromTo.Size = new System.Drawing.Size(128, 35);
            this.chkEnableDateFromTo.TabIndex = 172;
            this.chkEnableDateFromTo.Text = "Enable Date";
            this.chkEnableDateFromTo.UseVisualStyleBackColor = true;
            this.chkEnableDateFromTo.CheckedChanged += new System.EventHandler(this.chkEnableDateFromTo_CheckedChanged);
            // 
            // btnSubmitQuery
            // 
            this.btnSubmitQuery.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSubmitQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmitQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitQuery.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSubmitQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubmitQuery.Image = global::BumedianBM.Properties.Resources.statistic_ok_32;
            this.btnSubmitQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmitQuery.Location = new System.Drawing.Point(3, 105);
            this.btnSubmitQuery.Name = "btnSubmitQuery";
            this.btnSubmitQuery.Size = new System.Drawing.Size(174, 41);
            this.btnSubmitQuery.TabIndex = 161;
            this.btnSubmitQuery.Tag = "Submit Query";
            this.btnSubmitQuery.Text = "تشغيل الاستعلام";
            this.btnSubmitQuery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubmitQuery.UseVisualStyleBackColor = false;
            this.btnSubmitQuery.Click += new System.EventHandler(this.btnSubmitQuery_Click);
            // 
            // dateTo
            // 
            this.dateTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTo.Enabled = false;
            this.dateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(194, 72);
            this.dateTo.Name = "dateTo";
            this.dateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTo.Size = new System.Drawing.Size(143, 26);
            this.dateTo.TabIndex = 170;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(309, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 25);
            this.lblTo.TabIndex = 171;
            this.lblTo.Tag = "Price";
            this.lblTo.Text = "To";
            // 
            // rdoPortrait
            // 
            this.rdoPortrait.AutoSize = true;
            this.rdoPortrait.Location = new System.Drawing.Point(3, 152);
            this.rdoPortrait.Name = "rdoPortrait";
            this.rdoPortrait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdoPortrait.Size = new System.Drawing.Size(120, 35);
            this.rdoPortrait.TabIndex = 167;
            this.rdoPortrait.TabStop = true;
            this.rdoPortrait.Tag = "Portrait";
            this.rdoPortrait.Text = "الصفحة بالطول";
            this.rdoPortrait.UseVisualStyleBackColor = true;
            // 
            // btnAddtoFav
            // 
            this.btnAddtoFav.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddtoFav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddtoFav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddtoFav.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnAddtoFav.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddtoFav.Image = global::BumedianBM.Properties.Resources.statistic_save_32;
            this.btnAddtoFav.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddtoFav.Location = new System.Drawing.Point(3, 58);
            this.btnAddtoFav.Name = "btnAddtoFav";
            this.btnAddtoFav.Size = new System.Drawing.Size(174, 41);
            this.btnAddtoFav.TabIndex = 158;
            this.btnAddtoFav.Tag = "Add to Favories";
            this.btnAddtoFav.Text = "إضافة  المفضلة";
            this.btnAddtoFav.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddtoFav.UseVisualStyleBackColor = false;
            this.btnAddtoFav.Click += new System.EventHandler(this.btnAddtoFav_Click);
            // 
            // dateFrom
            // 
            this.dateFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateFrom.Enabled = false;
            this.dateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(194, 9);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateFrom.Size = new System.Drawing.Size(143, 26);
            this.dateFrom.TabIndex = 169;
            // 
            // btnFavorites
            // 
            this.btnFavorites.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFavorites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorites.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnFavorites.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFavorites.Image = global::BumedianBM.Properties.Resources.Favoriets__5_;
            this.btnFavorites.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFavorites.Location = new System.Drawing.Point(3, 11);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Size = new System.Drawing.Size(174, 41);
            this.btnFavorites.TabIndex = 157;
            this.btnFavorites.Tag = "Favorites";
            this.btnFavorites.Text = "المفضلة";
            this.btnFavorites.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFavorites.UseVisualStyleBackColor = false;
            this.btnFavorites.Click += new System.EventHandler(this.btnFavorites_Click);
            // 
            // Dg_Custom
            // 
            this.Dg_Custom.AllowUserToAddRows = false;
            this.Dg_Custom.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dg_Custom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.Dg_Custom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dg_Custom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dg_Custom.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Dg_Custom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dg_Custom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_Custom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.Dg_Custom.ColumnHeadersHeight = 33;
            this.Dg_Custom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dg_Custom.EnableHeadersVisualStyles = false;
            this.Dg_Custom.Location = new System.Drawing.Point(12, 258);
            this.Dg_Custom.Name = "Dg_Custom";
            this.Dg_Custom.ReadOnly = true;
            this.Dg_Custom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_Custom.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.Dg_Custom.RowHeadersVisible = false;
            this.Dg_Custom.RowHeadersWidth = 15;
            this.Dg_Custom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dg_Custom.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dg_Custom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dg_Custom.Size = new System.Drawing.Size(1049, 481);
            this.Dg_Custom.TabIndex = 94;
            this.Dg_Custom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dg_Custom_CellContentClick);
            this.Dg_Custom.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Dg_Custom_DataError_1);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtTitle.Font = new System.Drawing.Font("Simplified Arabic", 11F, System.Drawing.FontStyle.Bold);
            this.txtTitle.Location = new System.Drawing.Point(1, 216);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(266, 32);
            this.txtTitle.TabIndex = 161;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Image = global::BumedianBM.Properties.Resources.printer_32;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(622, 745);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(146, 41);
            this.btnPrint.TabIndex = 164;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreview.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrintPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrintPreview.Image = global::BumedianBM.Properties.Resources.preview_32;
            this.btnPrintPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintPreview.Location = new System.Drawing.Point(431, 745);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(185, 41);
            this.btnPrintPreview.TabIndex = 165;
            this.btnPrintPreview.Tag = "Print Preview";
            this.btnPrintPreview.Text = "معاينة قبل الطباعة";
            this.btnPrintPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument2;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // lblSortHint
            // 
            this.lblSortHint.AutoSize = true;
            this.lblSortHint.Font = new System.Drawing.Font("Simplified Arabic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortHint.Location = new System.Drawing.Point(599, 216);
            this.lblSortHint.Name = "lblSortHint";
            this.lblSortHint.Size = new System.Drawing.Size(473, 23);
            this.lblSortHint.TabIndex = 169;
            this.lblSortHint.Tag = "Table";
            this.lblSortHint.Text = "Hint: To sort the table click on the columns header that you want the table sorte" +
    "d by";
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaste.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaste.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnPaste.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPaste.Image = global::BumedianBM.Properties.Resources.paste_32;
            this.btnPaste.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaste.Location = new System.Drawing.Point(169, 745);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(146, 41);
            this.btnPaste.TabIndex = 160;
            this.btnPaste.Tag = "Paste";
            this.btnPaste.Text = "معجون";
            this.btnPaste.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPaste.UseVisualStyleBackColor = false;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopy.Image = global::BumedianBM.Properties.Resources.copy_32;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.Location = new System.Drawing.Point(17, 745);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(146, 41);
            this.btnCopy.TabIndex = 159;
            this.btnCopy.Tag = "Copy";
            this.btnCopy.Text = "نسخ";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExport.Image = global::BumedianBM.Properties.Resources.Export_report__4_;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Location = new System.Drawing.Point(774, 745);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(146, 41);
            this.btnExport.TabIndex = 163;
            this.btnExport.Tag = "Export";
            this.btnExport.Text = "تصدير";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(926, 745);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 41);
            this.btnClose.TabIndex = 162;
            this.btnClose.Tag = "Close";
            this.btnClose.Text = "أغلق";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpToTime
            // 
            this.dtpToTime.CustomFormat = "hh:mm tt";
            this.dtpToTime.Enabled = false;
            this.dtpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToTime.Location = new System.Drawing.Point(343, 72);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.ShowUpDown = true;
            this.dtpToTime.Size = new System.Drawing.Size(115, 26);
            this.dtpToTime.TabIndex = 358;
            this.dtpToTime.Value = new System.DateTime(2009, 6, 1, 0, 0, 0, 0);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.CustomFormat = "hh:mm tt";
            this.dtpFromTime.Enabled = false;
            this.dtpFromTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromTime.Location = new System.Drawing.Point(343, 9);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.ShowUpDown = true;
            this.dtpFromTime.Size = new System.Drawing.Size(115, 26);
            this.dtpFromTime.TabIndex = 359;
            this.dtpFromTime.Value = new System.DateTime(2009, 6, 1, 0, 0, 0, 0);
            // 
            // FormQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1084, 789);
            this.Controls.Add(this.lblSortHint);
            this.Controls.Add(this.Dg_Custom);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Custom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddtoFav;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnSubmitQuery;
        private System.Windows.Forms.DataGridView Dg_Custom;
        private System.Windows.Forms.MaskedTextBox txtTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.RadioButton rdoPortrait;
        private System.Windows.Forms.RadioButton rdoLandscape;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.CheckBox chkEnableDateFromTo;
        private System.Windows.Forms.Label lblSortHint;
        private System.Windows.Forms.CheckBox chkRightToLift;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
    }
}