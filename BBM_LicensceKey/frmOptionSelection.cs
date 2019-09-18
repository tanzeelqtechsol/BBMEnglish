using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BBM_LicensceGenerator
{

    /// <summary>
    /// This form is used for selecting the option either user can generate the license Key or Data migration or Change the password done by Praba on 06-Jun-2014
    /// </summary>
    public partial class frmOptionSelection : Form
    {
        public frmOptionSelection()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmOptionSelection_Load(object sender, EventArgs e)
        {

        }

        private void frmOptionSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLicenseGenerator_Click(object sender, EventArgs e)
        {
            this.Hide();
            LicenceGen objLicense = new LicenceGen("GenerateLicense");
            objLicense.Show();

        }

        private void btnDataMigration_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDataMigration objLicense = new frmDataMigration();
            objLicense.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            LicenceGen objLicense = new LicenceGen("ChangePwd");
            objLicense.Show();
        }
    }
}
