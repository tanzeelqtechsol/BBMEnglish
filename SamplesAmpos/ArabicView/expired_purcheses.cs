using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonHelper;

namespace BumedianBM.ArabicView
{
    public partial class expired_purcheses : Form,IDisposable
    {
        public expired_purcheses()
        {
            InitializeComponent();
            //GeneralFunction.SetLanguage(this, this);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {            
                this.Close();
           
        }     
    }
}