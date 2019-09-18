using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class ErrorMessage : Form
    {
        public string sContinue="";
        public string sUndo="";
        public bool enable=true;
       
        public string error="";
        public ErrorMessage()
        {
            InitializeComponent();
            SetLanguage();
        }

        private void ErrorMessage_Load(object sender, EventArgs e)
        {
            lblerroemessage.Text = error;
            btnContinue.Enabled = enable;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            sContinue = "YES";
            this.Close();
        }

        private void ntnUndo_Click(object sender, EventArgs e)
        {
            sUndo = "YES";
            this.Close();
        }

        private void ErrorMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            sUndo = "YES";
            this.Close();
        }
     public void SetLanguage()
        {
            btnContinue.Text = Additional_Barcode.GetValueByResourceKey("Continue");
            btnUndo.Text = Additional_Barcode.GetValueByResourceKey("Undo");
           
        }
    }
}
