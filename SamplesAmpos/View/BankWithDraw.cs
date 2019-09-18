using System;
using System.Windows.Forms;
using CommonHelper;


namespace BumedianBM.View
{
    public partial class BankWithDraw : Form
    {
         #region Constructor
        public BankWithDraw()
        {
            InitializeComponent();
        }
        #endregion

        #region Method

        public void ClearInputText()
        {
            cmbBank.Text = String.Empty;
            cmbBranch.Text = String.Empty;
            dtpDate.Text = String.Empty;
            txtAmount.Text = "0.000";
            txtBankBalance.Text = "0.000";
            txtDescription.Text = String.Empty;
            txtNewYearNo.Text = String.Empty;
            txtWithdrawDoneBy.Text = String.Empty;
        }

        #endregion

        #region Event
        private void BankWithDraw_Load(object sender, EventArgs e)
        {

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            this.ClearInputText();

        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CommonHelper.GeneralFunction.Question("Do you Want to Close", ActionType.Confirmation.ToString()) == DialogResult.OK)
                this.Close();
        }

        private void txtNewYearNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
        }


    }
}
