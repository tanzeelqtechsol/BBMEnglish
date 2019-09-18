namespace BumedianBM.ArabicView
{
    partial class CustomReport
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkRightToLift = new System.Windows.Forms.CheckBox();
            this.lblSelectColumn = new System.Windows.Forms.Label();
            this.LB_selectedColumns = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Columns = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Tables = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblWhere = new System.Windows.Forms.Label();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.lbl_DataTypeHelp = new System.Windows.Forms.Label();
            this.txt_DateCondtionValue = new System.Windows.Forms.DateTimePicker();
            this.txt_NumericConditionValue = new System.Windows.Forms.MaskedTextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.ListConditionQuery = new System.Windows.Forms.ListBox();
            this.txt_CondtionValue = new System.Windows.Forms.MaskedTextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.LB_Conditions = new System.Windows.Forms.ListBox();
            this.Cmb_ConditionColumn = new System.Windows.Forms.ComboBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkRightToLift);
            this.tabPage1.Controls.Add(this.lblSelectColumn);
            this.tabPage1.Controls.Add(this.LB_selectedColumns);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.LB_Columns);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.LB_Tables);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تحديد";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // chkRightToLift
            // 
            this.chkRightToLift.AutoSize = true;
            this.chkRightToLift.Location = new System.Drawing.Point(16, 18);
            this.chkRightToLift.Name = "chkRightToLift";
            this.chkRightToLift.Size = new System.Drawing.Size(105, 22);
            this.chkRightToLift.TabIndex = 79;
            this.chkRightToLift.Text = "RigtToLeft";
            this.chkRightToLift.UseVisualStyleBackColor = true;
            this.chkRightToLift.CheckedChanged += new System.EventHandler(this.chkRightToLift_CheckedChanged);
            // 
            // lblSelectColumn
            // 
            this.lblSelectColumn.AutoSize = true;
            this.lblSelectColumn.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectColumn.Location = new System.Drawing.Point(590, 43);
            this.lblSelectColumn.Name = "lblSelectColumn";
            this.lblSelectColumn.Size = new System.Drawing.Size(123, 25);
            this.lblSelectColumn.TabIndex = 78;
            this.lblSelectColumn.Text = "Selected Columns";
            // 
            // LB_selectedColumns
            // 
            this.LB_selectedColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LB_selectedColumns.FormattingEnabled = true;
            this.LB_selectedColumns.ItemHeight = 18;
            this.LB_selectedColumns.Location = new System.Drawing.Point(535, 71);
            this.LB_selectedColumns.Name = "LB_selectedColumns";
            this.LB_selectedColumns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LB_selectedColumns.Size = new System.Drawing.Size(229, 400);
            this.LB_selectedColumns.TabIndex = 5;
            this.LB_selectedColumns.SelectedIndexChanged += new System.EventHandler(this.LB_selectedColumns_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(349, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "عمود";
            // 
            // LB_Columns
            // 
            this.LB_Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LB_Columns.FormattingEnabled = true;
            this.LB_Columns.ItemHeight = 18;
            this.LB_Columns.Location = new System.Drawing.Point(257, 71);
            this.LB_Columns.Name = "LB_Columns";
            this.LB_Columns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LB_Columns.Size = new System.Drawing.Size(229, 400);
            this.LB_Columns.TabIndex = 2;
            this.LB_Columns.SelectedIndexChanged += new System.EventHandler(this.LB_Columns_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(75, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 25);
            this.label1.TabIndex = 1;
            this.label1.Tag = "Table";
            this.label1.Text = "الطاولة";
            // 
            // LB_Tables
            // 
            this.LB_Tables.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LB_Tables.FormattingEnabled = true;
            this.LB_Tables.ItemHeight = 18;
            this.LB_Tables.Location = new System.Drawing.Point(6, 71);
            this.LB_Tables.Name = "LB_Tables";
            this.LB_Tables.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LB_Tables.Size = new System.Drawing.Size(229, 400);
            this.LB_Tables.TabIndex = 0;
            this.LB_Tables.SelectedIndexChanged += new System.EventHandler(this.LB_Tables_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblWhere);
            this.tabPage2.Controls.Add(this.rdoNo);
            this.tabPage2.Controls.Add(this.rdoYes);
            this.tabPage2.Controls.Add(this.lbl_DataTypeHelp);
            this.tabPage2.Controls.Add(this.txt_DateCondtionValue);
            this.tabPage2.Controls.Add(this.txt_NumericConditionValue);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.ListConditionQuery);
            this.tabPage2.Controls.Add(this.txt_CondtionValue);
            this.tabPage2.Controls.Add(this.btn_Add);
            this.tabPage2.Controls.Add(this.LB_Conditions);
            this.tabPage2.Controls.Add(this.Cmb_ConditionColumn);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "أين";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblWhere
            // 
            this.lblWhere.AutoSize = true;
            this.lblWhere.Font = new System.Drawing.Font("Simplified Arabic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhere.Location = new System.Drawing.Point(6, 17);
            this.lblWhere.Name = "lblWhere";
            this.lblWhere.Size = new System.Drawing.Size(29, 23);
            this.lblWhere.TabIndex = 166;
            this.lblWhere.Tag = "Table";
            this.lblWhere.Text = "حيث";
            this.lblWhere.Visible = false;
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Location = new System.Drawing.Point(382, 43);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(48, 22);
            this.rdoNo.TabIndex = 165;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "No";
            this.rdoNo.UseVisualStyleBackColor = true;
            this.rdoNo.Visible = false;
            this.rdoNo.CheckedChanged += new System.EventHandler(this.rdoNo_CheckedChanged);
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Location = new System.Drawing.Point(436, 43);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(54, 22);
            this.rdoYes.TabIndex = 164;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Yes";
            this.rdoYes.UseVisualStyleBackColor = true;
            this.rdoYes.Visible = false;
            this.rdoYes.CheckedChanged += new System.EventHandler(this.rdoYes_CheckedChanged);
            // 
            // lbl_DataTypeHelp
            // 
            this.lbl_DataTypeHelp.AutoSize = true;
            this.lbl_DataTypeHelp.Font = new System.Drawing.Font("Simplified Arabic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataTypeHelp.Location = new System.Drawing.Point(378, 17);
            this.lbl_DataTypeHelp.Name = "lbl_DataTypeHelp";
            this.lbl_DataTypeHelp.Size = new System.Drawing.Size(85, 23);
            this.lbl_DataTypeHelp.TabIndex = 163;
            this.lbl_DataTypeHelp.Tag = "Table";
            this.lbl_DataTypeHelp.Text = "Numeric only";
            this.lbl_DataTypeHelp.Visible = false;
            // 
            // txt_DateCondtionValue
            // 
            this.txt_DateCondtionValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_DateCondtionValue.Location = new System.Drawing.Point(382, 43);
            this.txt_DateCondtionValue.Name = "txt_DateCondtionValue";
            this.txt_DateCondtionValue.Size = new System.Drawing.Size(228, 24);
            this.txt_DateCondtionValue.TabIndex = 162;
            this.txt_DateCondtionValue.Visible = false;
            this.txt_DateCondtionValue.ValueChanged += new System.EventHandler(this.txt_DateCondtionValue_ValueChanged);
            // 
            // txt_NumericConditionValue
            // 
            this.txt_NumericConditionValue.BackColor = System.Drawing.SystemColors.Window;
            this.txt_NumericConditionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_NumericConditionValue.Location = new System.Drawing.Point(382, 43);
            this.txt_NumericConditionValue.Name = "txt_NumericConditionValue";
            this.txt_NumericConditionValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_NumericConditionValue.Size = new System.Drawing.Size(228, 24);
            this.txt_NumericConditionValue.TabIndex = 161;
            this.txt_NumericConditionValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NumericConditionValue_KeyPress);
            this.txt_NumericConditionValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_NumericConditionValue_KeyUp);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDel.Image = global::BumedianBM.Properties.Resources.delete_32;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.Location = new System.Drawing.Point(6, 421);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(166, 41);
            this.btnDel.TabIndex = 160;
            this.btnDel.Tag = "Close";
            this.btnDel.Text = "Delete Row";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // ListConditionQuery
            // 
            this.ListConditionQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListConditionQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.ListConditionQuery.FormattingEnabled = true;
            this.ListConditionQuery.ItemHeight = 18;
            this.ListConditionQuery.Location = new System.Drawing.Point(6, 267);
            this.ListConditionQuery.Name = "ListConditionQuery";
            this.ListConditionQuery.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListConditionQuery.Size = new System.Drawing.Size(795, 148);
            this.ListConditionQuery.TabIndex = 159;
            // 
            // txt_CondtionValue
            // 
            this.txt_CondtionValue.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CondtionValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_CondtionValue.Location = new System.Drawing.Point(382, 43);
            this.txt_CondtionValue.Name = "txt_CondtionValue";
            this.txt_CondtionValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_CondtionValue.Size = new System.Drawing.Size(228, 24);
            this.txt_CondtionValue.TabIndex = 157;
            this.txt_CondtionValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_CondtionValue_KeyUp);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Add.Image = global::BumedianBM.Properties.Resources.add_32;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.Location = new System.Drawing.Point(616, 43);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(146, 41);
            this.btn_Add.TabIndex = 158;
            this.btn_Add.Tag = "Close";
            this.btn_Add.Text = "Add";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // LB_Conditions
            // 
            this.LB_Conditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LB_Conditions.FormattingEnabled = true;
            this.LB_Conditions.ItemHeight = 18;
            this.LB_Conditions.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<=",
            "<>"});
            this.LB_Conditions.Location = new System.Drawing.Point(202, 43);
            this.LB_Conditions.Name = "LB_Conditions";
            this.LB_Conditions.Size = new System.Drawing.Size(174, 202);
            this.LB_Conditions.TabIndex = 138;
            this.LB_Conditions.SelectedIndexChanged += new System.EventHandler(this.LB_Conditions_SelectedIndexChanged);
            // 
            // Cmb_ConditionColumn
            // 
            this.Cmb_ConditionColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cmb_ConditionColumn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cmb_ConditionColumn.BackColor = System.Drawing.SystemColors.Window;
            this.Cmb_ConditionColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Cmb_ConditionColumn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Cmb_ConditionColumn.FormattingEnabled = true;
            this.Cmb_ConditionColumn.Location = new System.Drawing.Point(6, 43);
            this.Cmb_ConditionColumn.Name = "Cmb_ConditionColumn";
            this.Cmb_ConditionColumn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_ConditionColumn.Size = new System.Drawing.Size(190, 26);
            this.Cmb_ConditionColumn.TabIndex = 137;
            this.Cmb_ConditionColumn.SelectedIndexChanged += new System.EventHandler(this.Cmb_ConditionColumn_SelectedIndexChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtQuery.Location = new System.Drawing.Point(12, 530);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuery.Size = new System.Drawing.Size(625, 88);
            this.txtQuery.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Image = global::BumedianBM.Properties.Resources.close_b_32;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(678, 577);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(146, 41);
            this.btnClear.TabIndex = 75;
            this.btnClear.Tag = "Close";
            this.btnClear.Text = "أغلق";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSubmit.Image = global::BumedianBM.Properties.Resources.invoice_save_32;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.Location = new System.Drawing.Point(678, 530);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(146, 41);
            this.btnSubmit.TabIndex = 74;
            this.btnSubmit.Tag = "OK";
            this.btnSubmit.Text = "حسنا";
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // CustomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(837, 622);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقارير مخصصة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LB_Tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LB_Columns;
        private System.Windows.Forms.ComboBox Cmb_ConditionColumn;
        private System.Windows.Forms.ListBox LB_Conditions;
        private System.Windows.Forms.MaskedTextBox txt_CondtionValue;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox ListConditionQuery;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DateTimePicker txt_DateCondtionValue;
        private System.Windows.Forms.MaskedTextBox txt_NumericConditionValue;
        private System.Windows.Forms.Label lbl_DataTypeHelp;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.Label lblWhere;
        private System.Windows.Forms.ListBox LB_selectedColumns;
        private System.Windows.Forms.Label lblSelectColumn;
        private System.Windows.Forms.CheckBox chkRightToLift;
    }
}