namespace BumedianBM.ArabicView
{
    partial class Clear_DataBase_Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clear_DataBase_Information));
            this.grpClearDBOption = new System.Windows.Forms.GroupBox();
            this.rbnDeleteAll = new System.Windows.Forms.RadioButton();
            this.lblWillKeepItemNamesAndPrices = new System.Windows.Forms.Label();
            this.rbnKeepdata = new System.Windows.Forms.RadioButton();
            this.lblWillMakeTheDBClean = new System.Windows.Forms.Label();
            this.rbnDeleteAllMovements = new System.Windows.Forms.RadioButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Txt_Discription = new System.Windows.Forms.TextBox();
            this.chkKeepUser = new System.Windows.Forms.CheckBox();
            this.chkKeepEmployee = new System.Windows.Forms.CheckBox();
            this.chkSpendings = new System.Windows.Forms.CheckBox();
            this.chkKeepAgent = new System.Windows.Forms.CheckBox();
            this.chkMoveCreditAgents = new System.Windows.Forms.CheckBox();
            this.chkKeepItemBarcode = new System.Windows.Forms.CheckBox();
            this.chkStocktoInventory = new System.Windows.Forms.CheckBox();
            this.grpClearDBOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpClearDBOption
            // 
            this.grpClearDBOption.Controls.Add(this.rbnDeleteAll);
            this.grpClearDBOption.Controls.Add(this.lblWillKeepItemNamesAndPrices);
            this.grpClearDBOption.Controls.Add(this.rbnKeepdata);
            this.grpClearDBOption.Controls.Add(this.lblWillMakeTheDBClean);
            this.grpClearDBOption.Controls.Add(this.rbnDeleteAllMovements);
            this.grpClearDBOption.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.grpClearDBOption.Location = new System.Drawing.Point(4, -4);
            this.grpClearDBOption.Name = "grpClearDBOption";
            this.grpClearDBOption.Size = new System.Drawing.Size(427, 120);
            this.grpClearDBOption.TabIndex = 159;
            this.grpClearDBOption.TabStop = false;
            this.grpClearDBOption.Tag = "CDB";
            this.grpClearDBOption.Text = "خيارات افراغ قاعدة البيانات ";
            // 
            // rbnDeleteAll
            // 
            this.rbnDeleteAll.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.rbnDeleteAll.Location = new System.Drawing.Point(265, 28);
            this.rbnDeleteAll.Name = "rbnDeleteAll";
            this.rbnDeleteAll.Size = new System.Drawing.Size(148, 32);
            this.rbnDeleteAll.TabIndex = 2;
            this.rbnDeleteAll.TabStop = true;
            this.rbnDeleteAll.Tag = "DA";
            this.rbnDeleteAll.Text = "الغاء الكل\r\n";
            this.rbnDeleteAll.UseVisualStyleBackColor = true;
            this.rbnDeleteAll.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lblWillKeepItemNamesAndPrices
            // 
            this.lblWillKeepItemNamesAndPrices.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblWillKeepItemNamesAndPrices.Location = new System.Drawing.Point(0, 56);
            this.lblWillKeepItemNamesAndPrices.Name = "lblWillKeepItemNamesAndPrices";
            this.lblWillKeepItemNamesAndPrices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWillKeepItemNamesAndPrices.Size = new System.Drawing.Size(244, 25);
            this.lblWillKeepItemNamesAndPrices.TabIndex = 147;
            this.lblWillKeepItemNamesAndPrices.Tag = "WillKeep";
            this.lblWillKeepItemNamesAndPrices.Text = "سيتم الاحتفاظ باسماء الاصناف و الاسعار\r\n";
            this.lblWillKeepItemNamesAndPrices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbnKeepdata
            // 
            this.rbnKeepdata.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.rbnKeepdata.Location = new System.Drawing.Point(54, 84);
            this.rbnKeepdata.Name = "rbnKeepdata";
            this.rbnKeepdata.Size = new System.Drawing.Size(242, 32);
            this.rbnKeepdata.TabIndex = 3;
            this.rbnKeepdata.TabStop = true;
            this.rbnKeepdata.Tag = "KD";
            this.rbnKeepdata.Text = "الحفاظ على البيانات \r\n";
            this.rbnKeepdata.UseVisualStyleBackColor = true;
            this.rbnKeepdata.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lblWillMakeTheDBClean
            // 
            this.lblWillMakeTheDBClean.Font = new System.Drawing.Font("Simplified Arabic", 10F, System.Drawing.FontStyle.Bold);
            this.lblWillMakeTheDBClean.Location = new System.Drawing.Point(260, 56);
            this.lblWillMakeTheDBClean.Name = "lblWillMakeTheDBClean";
            this.lblWillMakeTheDBClean.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWillMakeTheDBClean.Size = new System.Drawing.Size(160, 25);
            this.lblWillMakeTheDBClean.TabIndex = 146;
            this.lblWillMakeTheDBClean.Tag = "WillMake";
            this.lblWillMakeTheDBClean.Text = "سيتم مسح كافة البيانات \r\n";
            this.lblWillMakeTheDBClean.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbnDeleteAllMovements
            // 
            this.rbnDeleteAllMovements.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.rbnDeleteAllMovements.Location = new System.Drawing.Point(5, 28);
            this.rbnDeleteAllMovements.Name = "rbnDeleteAllMovements";
            this.rbnDeleteAllMovements.Size = new System.Drawing.Size(219, 32);
            this.rbnDeleteAllMovements.TabIndex = 145;
            this.rbnDeleteAllMovements.TabStop = true;
            this.rbnDeleteAllMovements.Tag = "DAM";
            this.rbnDeleteAllMovements.Text = "مسح كافة التحركات\r\n";
            this.rbnDeleteAllMovements.UseVisualStyleBackColor = true;
            this.rbnDeleteAllMovements.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(235, 244);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(188, 31);
            this.lblDescription.TabIndex = 158;
            this.lblDescription.Tag = "MDes";
            this.lblDescription.Text = "بيان الترحيل";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnOk.Image = global::BumedianBM.Properties.Resources.ok_32;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(91, 344);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 39);
            this.btnOk.TabIndex = 157;
            this.btnOk.Tag = "K";
            this.btnOk.Text = "متابعة";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::BumedianBM.Properties.Resources.cancel_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(224, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 39);
            this.btnCancel.TabIndex = 156;
            this.btnCancel.Tag = "Can";
            this.btnCancel.Text = "الغاء الامر\r\n";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Txt_Discription
            // 
            this.Txt_Discription.Font = new System.Drawing.Font("Simplified Arabic", 10F);
            this.Txt_Discription.Location = new System.Drawing.Point(241, 275);
            this.Txt_Discription.MaxLength = 100;
            this.Txt_Discription.Name = "Txt_Discription";
            this.Txt_Discription.Size = new System.Drawing.Size(182, 30);
            this.Txt_Discription.TabIndex = 155;
            this.Txt_Discription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkKeepUser
            // 
            this.chkKeepUser.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkKeepUser.Location = new System.Drawing.Point(4, 278);
            this.chkKeepUser.Name = "chkKeepUser";
            this.chkKeepUser.Size = new System.Drawing.Size(270, 32);
            this.chkKeepUser.TabIndex = 154;
            this.chkKeepUser.Tag = "KU";
            this.chkKeepUser.Text = "الحفاظ على بيانات المستخدمين \r\n";
            this.chkKeepUser.UseVisualStyleBackColor = true;
            // 
            // chkKeepEmployee
            // 
            this.chkKeepEmployee.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkKeepEmployee.Location = new System.Drawing.Point(4, 246);
            this.chkKeepEmployee.Name = "chkKeepEmployee";
            this.chkKeepEmployee.Size = new System.Drawing.Size(270, 32);
            this.chkKeepEmployee.TabIndex = 153;
            this.chkKeepEmployee.Tag = "KEmp";
            this.chkKeepEmployee.Text = "الحفاظ على بيانات الموظفين \r\n";
            this.chkKeepEmployee.UseVisualStyleBackColor = true;
            // 
            // chkSpendings
            // 
            this.chkSpendings.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkSpendings.Location = new System.Drawing.Point(4, 214);
            this.chkSpendings.Name = "chkSpendings";
            this.chkSpendings.Size = new System.Drawing.Size(270, 32);
            this.chkSpendings.TabIndex = 152;
            this.chkSpendings.Tag = "KS";
            this.chkSpendings.Text = "المصاريف\r\n";
            this.chkSpendings.UseVisualStyleBackColor = true;
            // 
            // chkKeepAgent
            // 
            this.chkKeepAgent.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkKeepAgent.Location = new System.Drawing.Point(4, 182);
            this.chkKeepAgent.Name = "chkKeepAgent";
            this.chkKeepAgent.Size = new System.Drawing.Size(270, 32);
            this.chkKeepAgent.TabIndex = 151;
            this.chkKeepAgent.Tag = "KAgent";
            this.chkKeepAgent.Text = "الحفاظ على بيانات العملاء\r\n";
            this.chkKeepAgent.UseVisualStyleBackColor = true;
            // 
            // chkMoveCreditAgents
            // 
            this.chkMoveCreditAgents.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkMoveCreditAgents.Location = new System.Drawing.Point(4, 310);
            this.chkMoveCreditAgents.Name = "chkMoveCreditAgents";
            this.chkMoveCreditAgents.Size = new System.Drawing.Size(270, 32);
            this.chkMoveCreditAgents.TabIndex = 150;
            this.chkMoveCreditAgents.Tag = "MCA";
            this.chkMoveCreditAgents.Text = "ترحيل ارصدة العملاء\r\n";
            this.chkMoveCreditAgents.UseVisualStyleBackColor = true;
            this.chkMoveCreditAgents.CheckedChanged += new System.EventHandler(this.chkMoveCreditAgents_CheckedChanged);
            // 
            // chkKeepItemBarcode
            // 
            this.chkKeepItemBarcode.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkKeepItemBarcode.Location = new System.Drawing.Point(4, 150);
            this.chkKeepItemBarcode.Name = "chkKeepItemBarcode";
            this.chkKeepItemBarcode.Size = new System.Drawing.Size(270, 32);
            this.chkKeepItemBarcode.TabIndex = 149;
            this.chkKeepItemBarcode.Tag = "KBar";
            this.chkKeepItemBarcode.Text = "الحفاظ على الاصناف و الباركود\r\n";
            this.chkKeepItemBarcode.UseVisualStyleBackColor = true;
            // 
            // chkStocktoInventory
            // 
            this.chkStocktoInventory.Font = new System.Drawing.Font("Simplified Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.chkStocktoInventory.Location = new System.Drawing.Point(4, 119);
            this.chkStocktoInventory.Name = "chkStocktoInventory";
            this.chkStocktoInventory.Size = new System.Drawing.Size(270, 31);
            this.chkStocktoInventory.TabIndex = 160;
            this.chkStocktoInventory.Text = "Move Stock to Inventory";
            this.chkStocktoInventory.UseVisualStyleBackColor = true;
            this.chkStocktoInventory.CheckedChanged += new System.EventHandler(this.chkStocktoInventory_CheckedChanged);
            // 
            // Clear_DataBase_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(436, 390);
            this.Controls.Add(this.chkStocktoInventory);
            this.Controls.Add(this.grpClearDBOption);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Txt_Discription);
            this.Controls.Add(this.chkKeepUser);
            this.Controls.Add(this.chkKeepEmployee);
            this.Controls.Add(this.chkSpendings);
            this.Controls.Add(this.chkKeepAgent);
            this.Controls.Add(this.chkMoveCreditAgents);
            this.Controls.Add(this.chkKeepItemBarcode);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clear_DataBase_Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clear DataBase Information";
            this.Load += new System.EventHandler(this.Clear_DataBase_Information_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Clear_DataBase_Information_KeyDown);
            this.grpClearDBOption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClearDBOption;
        private System.Windows.Forms.RadioButton rbnDeleteAll;
        private System.Windows.Forms.Label lblWillKeepItemNamesAndPrices;
        private System.Windows.Forms.RadioButton rbnKeepdata;
        private System.Windows.Forms.Label lblWillMakeTheDBClean;
        private System.Windows.Forms.RadioButton rbnDeleteAllMovements;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox Txt_Discription;
        private System.Windows.Forms.CheckBox chkKeepUser;
        private System.Windows.Forms.CheckBox chkKeepEmployee;
        private System.Windows.Forms.CheckBox chkSpendings;
        private System.Windows.Forms.CheckBox chkKeepAgent;
        private System.Windows.Forms.CheckBox chkMoveCreditAgents;
        private System.Windows.Forms.CheckBox chkKeepItemBarcode;
        private System.Windows.Forms.CheckBox chkStocktoInventory;
    }
}