using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelper;


namespace AlmaqarPOS.English
{
    public partial class FrmNotes : Form
    {
        #region "Variables"


        #endregion

        #region "Constructor"

        public FrmNotes()
        {
            InitializeComponent();
        }

        #endregion

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            GeneralFunction.POSNotes = RTxt_Note.Text;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Events"

        #region "Button Click Events"



        #endregion

        #endregion

    }
}