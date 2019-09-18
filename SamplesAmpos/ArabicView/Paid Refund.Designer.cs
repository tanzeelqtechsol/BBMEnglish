namespace BumedianBM.ArabicView
{
    partial class Paid_Refund
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
            this.Txt_Refund = new System.Windows.Forms.MaskedTextBox();
            this.Txt_Paid = new System.Windows.Forms.MaskedTextBox();
            this.lblRefund = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.Txt_Total = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Equal = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_One = new System.Windows.Forms.Button();
            this.Btn_Dot = new System.Windows.Forms.Button();
            this.Btn_Nine = new System.Windows.Forms.Button();
            this.Btn_Zero = new System.Windows.Forms.Button();
            this.btn_Two = new System.Windows.Forms.Button();
            this.btnExactAmount = new System.Windows.Forms.Button();
            this.Btn_Eight = new System.Windows.Forms.Button();
            this.btn_Three = new System.Windows.Forms.Button();
            this.Btn_Seven = new System.Windows.Forms.Button();
            this.Btn_Four = new System.Windows.Forms.Button();
            this.Btn_Six = new System.Windows.Forms.Button();
            this.Btn_Five = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_Refund
            // 
            this.Txt_Refund.BackColor = System.Drawing.Color.SeaShell;
            this.Txt_Refund.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Refund.Location = new System.Drawing.Point(1, 226);
            this.Txt_Refund.Name = "Txt_Refund";
            this.Txt_Refund.ReadOnly = true;
            this.Txt_Refund.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Refund.Size = new System.Drawing.Size(188, 50);
            this.Txt_Refund.TabIndex = 128;
            this.Txt_Refund.TextChanged += new System.EventHandler(this.Txt_Refund_TextChanged);
            // 
            // Txt_Paid
            // 
            this.Txt_Paid.BackColor = System.Drawing.Color.Honeydew;
            this.Txt_Paid.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold);
            this.Txt_Paid.Location = new System.Drawing.Point(1, 132);
            this.Txt_Paid.Name = "Txt_Paid";
            this.Txt_Paid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Paid.Size = new System.Drawing.Size(188, 50);
            this.Txt_Paid.TabIndex = 127;
            this.Txt_Paid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Paid_KeyPress);
            this.Txt_Paid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Paid_KeyUp);
            // 
            // lblRefund
            // 
            this.lblRefund.AutoSize = true;
            this.lblRefund.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefund.Location = new System.Drawing.Point(192, 231);
            this.lblRefund.Name = "lblRefund";
            this.lblRefund.Size = new System.Drawing.Size(63, 34);
            this.lblRefund.TabIndex = 126;
            this.lblRefund.Tag = "Refund";
            this.lblRefund.Text = "المرجع \r\n";
            // 
            // lblPaid
            // 
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaid.Location = new System.Drawing.Point(192, 136);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(64, 34);
            this.lblPaid.TabIndex = 125;
            this.lblPaid.Tag = "Paid";
            this.lblPaid.Text = "المدفوع \r\n";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(191, 48);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 34);
            this.lblTotal.TabIndex = 124;
            this.lblTotal.Tag = "Total";
            this.lblTotal.Text = "الاجمالي\r\n";
            // 
            // Txt_Total
            // 
            this.Txt_Total.BackColor = System.Drawing.Color.Snow;
            this.Txt_Total.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Total.Location = new System.Drawing.Point(1, 42);
            this.Txt_Total.Name = "Txt_Total";
            this.Txt_Total.ReadOnly = true;
            this.Txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Total.Size = new System.Drawing.Size(188, 50);
            this.Txt_Total.TabIndex = 123;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Equal);
            this.groupBox1.Controls.Add(this.Btn_Clear);
            this.groupBox1.Controls.Add(this.Btn_One);
            this.groupBox1.Controls.Add(this.Btn_Dot);
            this.groupBox1.Controls.Add(this.Btn_Nine);
            this.groupBox1.Controls.Add(this.Btn_Zero);
            this.groupBox1.Controls.Add(this.btn_Two);
            this.groupBox1.Controls.Add(this.btnExactAmount);
            this.groupBox1.Controls.Add(this.Btn_Eight);
            this.groupBox1.Controls.Add(this.btn_Three);
            this.groupBox1.Controls.Add(this.Btn_Seven);
            this.groupBox1.Controls.Add(this.Btn_Four);
            this.groupBox1.Controls.Add(this.Btn_Six);
            this.groupBox1.Controls.Add(this.Btn_Five);
            this.groupBox1.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(267, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 317);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            // 
            // Btn_Equal
            // 
            this.Btn_Equal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Equal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Equal.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Equal.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Equal.Location = new System.Drawing.Point(244, 170);
            this.Btn_Equal.Name = "Btn_Equal";
            this.Btn_Equal.Size = new System.Drawing.Size(74, 69);
            this.Btn_Equal.TabIndex = 54;
            this.Btn_Equal.Text = "=";
            this.Btn_Equal.UseVisualStyleBackColor = false;
            this.Btn_Equal.Click += new System.EventHandler(this.Btn_Equal_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Clear.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Clear.Location = new System.Drawing.Point(244, 20);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(74, 143);
            this.Btn_Clear.TabIndex = 53;
            this.Btn_Clear.Text = "C";
            this.Btn_Clear.UseVisualStyleBackColor = false;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_One
            // 
            this.Btn_One.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_One.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_One.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_One.ForeColor = System.Drawing.Color.Navy;
            this.Btn_One.Location = new System.Drawing.Point(4, 169);
            this.Btn_One.Name = "Btn_One";
            this.Btn_One.Size = new System.Drawing.Size(74, 69);
            this.Btn_One.TabIndex = 52;
            this.Btn_One.Text = "1";
            this.Btn_One.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_One.UseVisualStyleBackColor = false;
            this.Btn_One.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Dot
            // 
            this.Btn_Dot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Dot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Dot.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Dot.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Dot.Location = new System.Drawing.Point(4, 244);
            this.Btn_Dot.Name = "Btn_Dot";
            this.Btn_Dot.Size = new System.Drawing.Size(74, 69);
            this.Btn_Dot.TabIndex = 42;
            this.Btn_Dot.Text = ".";
            this.Btn_Dot.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Dot.UseVisualStyleBackColor = false;
            this.Btn_Dot.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Nine
            // 
            this.Btn_Nine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Nine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Nine.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Nine.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Nine.Location = new System.Drawing.Point(164, 20);
            this.Btn_Nine.Name = "Btn_Nine";
            this.Btn_Nine.Size = new System.Drawing.Size(74, 69);
            this.Btn_Nine.TabIndex = 43;
            this.Btn_Nine.Text = "9";
            this.Btn_Nine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nine.UseVisualStyleBackColor = false;
            this.Btn_Nine.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Zero
            // 
            this.Btn_Zero.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Zero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Zero.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Zero.Location = new System.Drawing.Point(84, 245);
            this.Btn_Zero.Name = "Btn_Zero";
            this.Btn_Zero.Size = new System.Drawing.Size(74, 68);
            this.Btn_Zero.TabIndex = 41;
            this.Btn_Zero.Text = "0";
            this.Btn_Zero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Zero.UseVisualStyleBackColor = false;
            this.Btn_Zero.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // btn_Two
            // 
            this.btn_Two.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Two.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Two.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Two.ForeColor = System.Drawing.Color.Navy;
            this.btn_Two.Location = new System.Drawing.Point(84, 170);
            this.btn_Two.Name = "btn_Two";
            this.btn_Two.Size = new System.Drawing.Size(74, 69);
            this.btn_Two.TabIndex = 51;
            this.btn_Two.Text = "2";
            this.btn_Two.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Two.UseVisualStyleBackColor = false;
            this.btn_Two.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // btnExactAmount
            // 
            this.btnExactAmount.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnExactAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExactAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExactAmount.ForeColor = System.Drawing.Color.Navy;
            this.btnExactAmount.Location = new System.Drawing.Point(164, 245);
            this.btnExactAmount.Name = "btnExactAmount";
            this.btnExactAmount.Size = new System.Drawing.Size(154, 69);
            this.btnExactAmount.TabIndex = 40;
            this.btnExactAmount.Tag = "ExactAmount";
            this.btnExactAmount.Text = "ادخال";
            this.btnExactAmount.UseVisualStyleBackColor = false;
            this.btnExactAmount.Click += new System.EventHandler(this.btnExactAmount_Click);
            // 
            // Btn_Eight
            // 
            this.Btn_Eight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Eight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eight.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Eight.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Eight.Location = new System.Drawing.Point(84, 20);
            this.Btn_Eight.Name = "Btn_Eight";
            this.Btn_Eight.Size = new System.Drawing.Size(74, 69);
            this.Btn_Eight.TabIndex = 44;
            this.Btn_Eight.Text = "8";
            this.Btn_Eight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eight.UseVisualStyleBackColor = false;
            this.Btn_Eight.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // btn_Three
            // 
            this.btn_Three.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_Three.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Three.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_Three.ForeColor = System.Drawing.Color.Navy;
            this.btn_Three.Location = new System.Drawing.Point(164, 169);
            this.btn_Three.Name = "btn_Three";
            this.btn_Three.Size = new System.Drawing.Size(74, 69);
            this.btn_Three.TabIndex = 50;
            this.btn_Three.Text = "3";
            this.btn_Three.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Three.UseVisualStyleBackColor = false;
            this.btn_Three.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Seven
            // 
            this.Btn_Seven.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Seven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Seven.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Seven.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Seven.Location = new System.Drawing.Point(4, 20);
            this.Btn_Seven.Name = "Btn_Seven";
            this.Btn_Seven.Size = new System.Drawing.Size(74, 69);
            this.Btn_Seven.TabIndex = 45;
            this.Btn_Seven.Text = "7";
            this.Btn_Seven.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Seven.UseVisualStyleBackColor = false;
            this.Btn_Seven.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Four
            // 
            this.Btn_Four.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Four.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Four.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Four.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Four.Location = new System.Drawing.Point(4, 95);
            this.Btn_Four.Name = "Btn_Four";
            this.Btn_Four.Size = new System.Drawing.Size(74, 69);
            this.Btn_Four.TabIndex = 49;
            this.Btn_Four.Text = "4";
            this.Btn_Four.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Four.UseVisualStyleBackColor = false;
            this.Btn_Four.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Six
            // 
            this.Btn_Six.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Six.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Six.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Six.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Six.Location = new System.Drawing.Point(164, 94);
            this.Btn_Six.Name = "Btn_Six";
            this.Btn_Six.Size = new System.Drawing.Size(74, 69);
            this.Btn_Six.TabIndex = 47;
            this.Btn_Six.Text = "6";
            this.Btn_Six.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Six.UseVisualStyleBackColor = false;
            this.Btn_Six.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // Btn_Five
            // 
            this.Btn_Five.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Btn_Five.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Five.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Five.ForeColor = System.Drawing.Color.Navy;
            this.Btn_Five.Location = new System.Drawing.Point(84, 95);
            this.Btn_Five.Name = "Btn_Five";
            this.Btn_Five.Size = new System.Drawing.Size(74, 69);
            this.Btn_Five.TabIndex = 48;
            this.Btn_Five.Text = "5";
            this.Btn_Five.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Five.UseVisualStyleBackColor = false;
            this.Btn_Five.Click += new System.EventHandler(this.Button_NumberClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.BackgroundImage = global::BumedianBM.Properties.Resources.close_b_128;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(241, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 90);
            this.btnCancel.TabIndex = 131;
            this.btnCancel.Text = "الغاء الامر\r\n";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.BackgroundImage = global::BumedianBM.Properties.Resources.printer_128;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Location = new System.Drawing.Point(16, 335);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 90);
            this.btnPrint.TabIndex = 130;
            this.btnPrint.Tag = "Print";
            this.btnPrint.Text = "طباعة\r\n";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClose.BackgroundImage = global::BumedianBM.Properties.Resources.invoice_save_128;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Simplified Arabic", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(469, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 90);
            this.btnClose.TabIndex = 129;
            this.btnClose.Text = "اغلاق\r\n";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Paid_Refund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(590, 433);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Txt_Refund);
            this.Controls.Add(this.Txt_Paid);
            this.Controls.Add(this.lblRefund);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.Txt_Total);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Simplified Arabic", 13F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Paid_Refund";
            this.Text = "Paid Refund";
            this.Load += new System.EventHandler(this.Paid_Refund_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaidRefund_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MaskedTextBox Txt_Refund;
        public System.Windows.Forms.MaskedTextBox Txt_Paid;
        private System.Windows.Forms.Label lblRefund;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.MaskedTextBox Txt_Total;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Equal;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_One;
        private System.Windows.Forms.Button Btn_Dot;
        private System.Windows.Forms.Button Btn_Nine;
        private System.Windows.Forms.Button Btn_Zero;
        private System.Windows.Forms.Button btn_Two;
        private System.Windows.Forms.Button btnExactAmount;
        private System.Windows.Forms.Button Btn_Eight;
        private System.Windows.Forms.Button btn_Three;
        private System.Windows.Forms.Button Btn_Seven;
        private System.Windows.Forms.Button Btn_Four;
        private System.Windows.Forms.Button Btn_Six;
        private System.Windows.Forms.Button Btn_Five;
    }
}