using System;
using System.Windows.Forms;
using CommonHelper;
using ObjectHelper;
using BumedianBM.ViewHelper;

namespace BumedianBM.View
{
    public partial class AgentDetail : Form
    {
        AgentDetailObjectClass ObjSetagentdetailobject;
        AgentDetailHelperClass Objagentdetailhelper;

        #region Constructor
        public AgentDetail()
        {
            InitializeComponent();
            //Objagentdetailhelper = new AgentDetailHelperClass(this);
            ObjSetagentdetailobject = new AgentDetailObjectClass();
           // Objagentdetailhelper.LoadAgentName();
        } 
        #endregion

        #region Method
       

        public void SetObjectFromControl()
        {
            ObjSetagentdetailobject.Name = Cmb_Name.Text.Trim();
            //ObjSetagentdetailobject.Number = Txt_Number.Text.Trim();
            ObjSetagentdetailobject.Phoneno = Txt_Phone.Text.Trim(); ;
            ObjSetagentdetailobject.Address = Txt_Address.Text.Trim(); ;
            ObjSetagentdetailobject.DebtLimt = Convert.ToDecimal(this.Txt_DebtLimit.Text.Trim());
            //ObjSetagentdetailobject.Discount = Txt_Discount.Text.Trim(); ;

        }

        public void setControlFromObject(AgentDetailObjectClass ObjGetagentdetailobject)
        {
            Cmb_Name.Text = ObjGetagentdetailobject.Name;
            //Txt_Number.Text = ObjGetagentdetailobject.Number;
            Txt_Phone.Text = ObjGetagentdetailobject.Phoneno;
            Txt_Address.Text = ObjGetagentdetailobject.Address;
            Txt_DebtLimit.Text = ObjGetagentdetailobject.DebtLimt.ToString();
            //Txt_Discount.Text = ObjGetagentdetailobject.Discount;
            Txt_AccPayable.Text = ObjGetagentdetailobject.AccountsPayable;
            Txt_AccRecivable.Text = ObjGetagentdetailobject.AccountsReceivable;
            Txt_LastInvoice.Text = ObjGetagentdetailobject.Lastinvoice;
        }

        public void Clear()
        {
            Cmb_Name.Text = string.Empty;
            Cmb_PaymentDay.Text = string.Empty;
            Txt_Number.Text = string.Empty;
            Txt_Phone.Text = string.Empty;
            Txt_Address.Text = string.Empty;
            Txt_DebtLimit.Text = string.Empty;
            Txt_Discount.Text = string.Empty;
            Txt_AccPayable.Text = string.Empty;
            Txt_AccRecivable.Text = string.Empty;
            Txt_LastPaymentDate.Text = string.Empty;
            Txt_LastInvoice.Text = string.Empty;
            Chk_Branch.Checked = false;
            Chk_Client.Checked = false;
            Chk_HideAgent.Checked = false;
            Chk_Supplier.Checked = false;
            
        } 
        #endregion

        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Clear();
            ObjSetagentdetailobject = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            Objagentdetailhelper.SaveMethod();
          
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        private void Cmb_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Objagentdetailhelper.AgentNameSelectedIndexChanged();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            Objagentdetailhelper.DeleteMethod();
            this.Clear();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (CommonHelper.GeneralFunction.Question("Do you Want to Close", ActionType.Confirmation.ToString()) == DialogResult.OK)
                this.Close();

        }

        public void Txt_DebtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.')&&(e.KeyChar!=(char)Keys.Back)&&(e.KeyChar!=(char)Keys.Delete))
            {
                CommonHelper.GeneralFunction.Warning(Constants.NUMERSONLYMESSAGE, ActionType.All.ToString());
                e.Handled = true;
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            Objagentdetailhelper.Print();
        }

        private void Btn_DebtList_Click(object sender, EventArgs e)
        {
            Objagentdetailhelper.DebtList();
        }
       

        #endregion

      

       
       

    }
}
