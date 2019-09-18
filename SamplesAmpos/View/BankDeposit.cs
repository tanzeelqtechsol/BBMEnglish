using System;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
//using CommonHelper.GeneralFunction;

namespace BumedianBM.View
{
    public partial class BankDeposit : Form
    {
        BankObjectClass SetBankObject;
        BankDepositHelperClass ObjBankDepositHelper;

        public BankDeposit()
        {
            InitializeComponent();
            SetBankObject = new BankObjectClass();
          // ObjBankDepositHelper = new BankDepositHelperClass(this);
        }

        private void BankDeposit_Load(object sender, EventArgs e)
        {
            //ObjBankDepositHelper.FillBankNameList();
            //ObjBankDepositHelper.FillMaxMinReceiptNumber();
            //Lbl_UserName.Text = CommonHelper.GeneralFunction.UserName;

        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            Clear();
            txtReceiptNo.Text = ObjBankDepositHelper.ReceiptMaxNo.ToString();
            txtDescription.Focus();
        }

        public void SetObjectFromControl()
        {
            SetBankObject.ProcessDate = dtpDate.Value;
            SetBankObject.Description = txtDescription.Text.Trim();
            SetBankObject.DepositDoneBy = txtDepositDoneBy.Text.Trim();
            SetBankObject.BankNameID = Convert.ToInt16(cmbBank.SelectedValue.ToString());
            SetBankObject.BranchNameID = Convert.ToInt16(cmbBranch.SelectedValue.ToString());
            SetBankObject.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
            SetBankObject.Reason = cmbReason.Text.ToString().Trim();
            SetBankObject.ReasonId = cmbReason.SelectedIndex;
            SetBankObject.ReceiptNo = Convert.ToInt16(txtReceiptNo.Text.Trim());
        }
        public void SetControlFromObject(BankObjectClass getBankObject)
        {
            txtReceiptNo.Text = (getBankObject.ReceiptNo).ToString();
            txtDescription.Text = getBankObject.Description;
            txtDepositDoneBy.Text = getBankObject.DepositDoneBy;
            cmbBank.SelectedValue = getBankObject.BankNameID.ToString();
            cmbBanktoMove.SelectedValue = getBankObject.BankToMoveID == 0 ? 0 : getBankObject.BankToMoveID;
            cmbBranch.SelectedValue = getBankObject.BranchNameID.ToString();
            cmbBranchtoMove.SelectedValue = getBankObject.BranchToMoveID == 0 ? 0 : getBankObject.BankToMoveID;
            txtAmount.Text = getBankObject.Amount.ToString();
            cmbReason.SelectedIndex = getBankObject.ReasonId;
        }

        public void Clear()
        {
            txtAmount.Text = "0.000";
            txtDepositDoneBy.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbBank.SelectedIndex = -1;
            cmbBanktoMove.SelectedIndex = -1;
            cmbBranch.SelectedIndex = -1;
            cmbBranchtoMove.SelectedIndex = -1;
            cmbReason.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            grpChooseBankBranch.Visible = false;
        }

        private void btnNextReciept_Click(object sender, EventArgs e)
        { //ObjBankDepositHelper.btnNextReciept_Click();
        }

        private void btnPreviousReciept_Click(object sender, EventArgs e)
        {// ObjBankDepositHelper.btnPreviousReciept_Click();
        }

        public void txtReceiptNo_TextChanged(object sender, EventArgs e)
        { 
          //  ObjBankDepositHelper.txtReceiptNo_TextChangeEvent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
           // ObjBankDepositHelper.btnSave_Click(SetBankObject);
        }
        public void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        { grpChooseBankBranch.Visible = (cmbReason.SelectedIndex == 2) ? true : false; }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            //ObjBankDepositHelper.btnDelete_Click(SetBankObject);
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBranch.SelectedIndex != -1)
                {
                    SetBankObject.BankNameID = Convert.ToInt16(cmbBank.SelectedValue.ToString());
                    SetBankObject.BranchNameID = Convert.ToInt16(cmbBranch.SelectedValue.ToString());
                  //  ObjBankDepositHelper.MoveToAnotherBank(SetBankObject);
                }
            }
            catch { }
        }
       

        private void cmbBranchtoMove_SelectedIndexChanged(object sender, EventArgs e)
        {
              if (cmbBranch.SelectedIndex != -1)
                {
                    SetBankObject.BankNameID = Convert.ToInt16(cmbBanktoMove.SelectedValue.ToString());
                    SetBankObject.BranchNameID = Convert.ToInt16(cmbBranchtoMove.SelectedValue.ToString());
                    //ObjBankDepositHelper.MoveToAnotherBranch(SetBankObject);
                }
        }
        private void btnClose_Click(object sender, EventArgs e)
        { this.Close(); }

        private void txtNewYearNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((char.IsControl(e.KeyChar) == false) && (char.IsDigit(e.KeyChar) == false));
        }

        private void txtNewYearNo_KeyUp(object sender, KeyEventArgs e)
        {
            txtReceiptNo.Text = ((txtNewYearNo.Text != string.Empty) && (txtNewYearNo.Text.Contains("-") == false)) ? txtNewYearNo.Text : txtReceiptNo.Text;
            txtReceiptNo.Text = (txtNewYearNo.Text == string.Empty) ? "1" : txtReceiptNo.Text;
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text != "")
            {
                decimal dec = Convert.ToDecimal(txtAmount.Text);
                txtAmount.Text = dec.ToString("########0.000");
            }
        }

        private void txtReceiptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (e.KeyChar == 13)
                {
                     txtReceiptNo_TextChanged(sender, e);
                }
                else
                {
                    if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                    {
                        e.Handled = true;
                        CommonHelper.GeneralFunction.ErrInfo("OnlyNumbersAllowed", this.Text);
                        txtReceiptNo.SelectAll();
                        txtReceiptNo.Focus();
                    }
                }
            }
        
    }
}
