using System;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using ObjectHelper;
using System.Drawing;
using CommonHelper;
using System.Threading;
using System.Configuration;

namespace BumedianBM.ArabicView
{
    public partial class Debt_Adjustment : Form, IDisposable
    {
        #region Initilization
        public DebtAdjustHelperClass ObjDebtHelper;
        public bool IsFromBalance = false;
        bool IsFromLoad, IsFromText = false, iscount = false;
        #endregion

        #region Constructor
        public Debt_Adjustment()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            ObjDebtHelper = new DebtAdjustHelperClass();
            AssignToComboBox();
            ObjDebtHelper.BindMaxIdToControls();
            SetButtons(3);
        }

        #endregion

        #region Load
        private void Debt_Adjustment_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//        
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//

                cmbAgentName.Select();
                cmbAgentName.Focus();
                if (IsFromBalance)
                {
                    ObjDebtHelper.GetDebtRecordByInvoice();
                    SetButtons(ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Status);
                    SetControlFromObject();
                }
            }
            catch (Exception ex)
            { GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "Debt_Adjustment", "Debt_Adjustment_Load"); }
        }
        #endregion

        #region Methods
        private void AssignMaxID()
        {
            ObjDebtHelper.LoadMaxMinNumber();
            txtReceiptNo.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString();
        }

        private void AssignToComboBox()
        {
            IsFromLoad = true;
            cmbAgentName.DisplayMember = "Name";
            cmbAgentName.ValueMember = "AgentID";
            cmbAgentName.DataSource = GeneralObjectClass.DebtAgents;
            cmbAgentName.SelectedIndex = -1;
            IsFromLoad = false;
        }

        public void SetLanguage()
        {
            lblAgentName.Text = Additional_Barcode.GetValueByResourceKey("AgentName");
            lblBalance.Text = Additional_Barcode.GetValueByResourceKey("Balance");
            lblPayable.Text = Additional_Barcode.GetValueByResourceKey("Payable");
            lblReceivable.Text = Additional_Barcode.GetValueByResourceKey("Receivable");
            lblDescription.Text = Additional_Barcode.GetValueByResourceKey("Description");
            lblReceiptNo.Text = Additional_Barcode.GetValueByResourceKey("ReceiptNo");
            lblUserName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            grpStatus.Text = Additional_Barcode.GetValueByResourceKey("Status");
            lblDate.Text = Additional_Barcode.GetValueByResourceKey("Date");
            this.Text = Additional_Barcode.GetValueByResourceKey("DebtAdjust");
        }

        public void SetObjectFromControl()
        {
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt32(txtReceiptNo.Text);
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Payable = Convert.ToDouble(txtPayable.Text==string.Empty?"0":txtPayable.Text);
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Receivable = Convert.ToDouble(txtReceivable.Text == string.Empty ? 0.000 : Convert.ToDouble(txtReceivable.Text));
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Balance = Convert.ToDouble(txtBalance.Text);
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.AgentId = Convert.ToInt32(cmbAgentName.SelectedValue == null ? 0 : cmbAgentName.SelectedValue);
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Description = txtDescription.Text;
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.DebtStatus = lblStatusName.Text;
            ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptDate = (DateTime.Now.Date);
        }

        public void SetControlFromObject()
        {
            txtPayable.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Payable.ToString();
            txtReceivable.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Receivable.ToString();
            if (ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Balance >= 0)
                txtBalance.ForeColor = Color.Green;
            else
                txtBalance.ForeColor = Color.Red;
            txtBalance.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Balance.ToString();
            IsFromText = true;
            //cmbAgentName.SelectedIndexChanged -= new EventHandler(this.cmbAgentName_SelectedIndexChanged);
            cmbAgentName.SelectedValue = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.AgentId;
            //cmbAgentName.SelectedIndexChanged += new EventHandler(this.cmbAgentName_SelectedIndexChanged);
            txtDescription.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.Description;
            if (ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Year == ObjDebtHelper.CurrentYear)
                txtNewYearNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.YearSequenceNo.ToString();
            else
                txtNewYearNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Year.ToString() + '-' + ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.YearSequenceNo.ToString();
            txtReceiptNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.ReceiptID.ToString();
            IsFromText = false;
        }

        public void Clear()
        {
            txtReceivable.Text = "0.000";
            txtPayable.Text = "0.000";
            lblStatusName.ForeColor = Color.Blue;
            lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
            cmbAgentName.Text = string.Empty;
            cmbAgentName.SelectedIndex = -1;
            txtBalance.Text = "0.000";
            txtBalance.ForeColor = Color.Black;
            cmbAgentName.Focus();
            txtDescription.Text = string.Empty;
        }

        private void SetButtons(int LabelType)
        {
            switch (LabelType)
            {
                case 3:
                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("New");
                    lblStatusName.ForeColor = Color.Blue;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = btnSave.Visible = true;
                    txtReceiptNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.ReceiptID.ToString();
                    if (ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Year == ObjDebtHelper.CurrentYear)
                        txtNewYearNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.YearSequenceNo.ToString();
                    else
                        txtNewYearNo.Text = ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Year.ToString() + '-' + ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.YearSequenceNo.ToString();
                    break;
                case 1:
                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                    lblStatusName.ForeColor = Color.Green;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                    break;
                case 0:
                    lblStatusName.Text = GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                    lblStatusName.ForeColor = Color.Red;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        #endregion

        #region buttonEvent
        private void Btn_Previous_Click(object sender, EventArgs e)
        {
            try
            {
                ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt16(txtReceiptNo.Text);
                ObjDebtHelper.LeftNavigation();
                this.Clear();
                SetButtons(ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Status);
                SetControlFromObject();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt16(txtReceiptNo.Text);
                ObjDebtHelper.RightNavigation();
                //txtReceiptNo.Text = ObjDebtHelper.objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString();
                //Clear();
                SetButtons(ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Status);
                SetControlFromObject();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                SetObjectFromControl();
                if (ObjDebtHelper.Save())
                {
                    Clear();
                    // AssignMaxID();
                    SetButtons(3);
                }
                else
                {
                    if (ObjDebtHelper.str != string.Empty && ObjDebtHelper.str != null)
                        this.Controls[ObjDebtHelper.str].Focus();
                }
            }
            catch (Exception ex)
            { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                //ObjDebtHelper.New();
                AssignMaxID();
                ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.ReceiptID = ObjDebtHelper.MaxID;
                txtReceiptNo.Text = ObjDebtHelper.MaxID.ToString();
                InvokeOnClick(Btn_Next, EventArgs.Empty);
            }
            catch (Exception ex)
            { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectFromControl();
                if (ObjDebtHelper.Delete())
                {
                    this.SetControlFromObject();
                    SetButtons(3);
                }
            }
            catch (Exception ex)
            { GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name); }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if ((GeneralFunction.Question(Constants.CLOSE, ActionType.Close.ToString())) == DialogResult.Yes)
            this.Close();
        }
        #endregion

        #region KeyEvent
        public void KeyPress_Event(object sender, KeyPressEventArgs e)
        {
            string str = ((TextBox)sender).Name;
            if (e.KeyChar == 13)
            {
                switch (str)
                {
                    case "txtReceivable":
                    case "txtPayable":
                        txtDescription.Focus();
                        break;
                }
            }
            else if ((!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete)))
            {
                CommonHelper.GeneralFunction.Warning("OnlyNumbersAllowed", "DebtAdjustment");
                e.Handled = true;
            }
        }

        private void txtNewYearNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtNewYearNo.Text.Length != 0)
                    {
                        ObjDebtHelper.GetRecordBasedonReceipt(txtNewYearNo.Text);
                        SetControlFromObject();
                        SetButtons(ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Status);
                    }
                }
                else if ((!char.IsDigit(e.KeyChar)) && (e.KeyChar != 45) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
                {
                    GeneralFunction.Warning("OnlyNumbersAllowed", "DebtAdjustment");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region Index Changed
        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsFromLoad)
                {
                    if (cmbAgentName.SelectedValue != null)
                    {
                        if (!IsFromText)
                            this.SetObjectFromControl();
                        ObjDebtHelper.Get_AgentBalance();
                        if (ObjDebtHelper.Balance >= 0)
                        {
                            txtBalance.ForeColor = Color.Green;
                            txtBalance.Text = ObjDebtHelper.Balance.ToString("0.000");
                        }
                        else if (ObjDebtHelper.Balance < 0)
                        {
                            txtBalance.ForeColor = Color.Red;
                            txtBalance.Text = ObjDebtHelper.Balance.ToString("0.000");
                        }

                        //txtBalance.ForeColor = (GeneralFunction.ClientDebt >= 0) ? Color.Green : Color.Red;
                        //txtBalance.Text = GeneralFunction.ClientDebt.ToString("########0.000");
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ObjDebtHelper.str = lblStatusName.Text;
                ObjDebtHelper.ObjBALClass.ObjDebtAdjustObject.Name = cmbAgentName.Text;
                ObjDebtHelper.btnPrint();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Debt adjustment", " ", "print payable debt adjustment details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbAgentName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 38 || e.KeyValue == 40)
            //    iscount = true;
            if (e.KeyData == Keys.Enter)
            {
                txtReceivable.Focus();
            }
            else
            {
                if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
                {
                    if (((ComboBox)sender).DataSource != null)
                    {
                        if (((ComboBox)sender).DroppedDown == true)
                            ((ComboBox)sender).DroppedDown = false;
                    }

                }
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && btnSave.Enabled == true)
            {
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            }
        }

        //private void cmbAgentName_DropDown(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //}

        //private void cmbAgentName_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    if (iscount)
        //        iscount = false;
        //    else
        //        cmbAgentName_SelectedIndexChanged(sender, EventArgs.Empty);

        //}

        private void txtReceivable_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (((Control)sender).Name == "txtReceivable")
                str = (Convert.ToDecimal(txtBalance.Text) + Convert.ToDecimal(txtReceivable.Text == string.Empty ? "0.000" : txtReceivable.Text)).ToString();
            else
                str = (Convert.ToDecimal(txtBalance.Text) - Convert.ToDecimal(txtPayable.Text == String.Empty ? "0.000" : txtPayable.Text)).ToString();
            // txtDescription.Text = Additional_Barcode.GetValueByResourceKey("Balance")+"-"+str; save remarks in arabic commented on 30 jun 2014
            txtDescription.Text = "Balance" + "-" + str;

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                Properties.Settings.Default.Save();
                foreach (Control cti in this.Controls)
                {
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is Button || ctl is Label || ctl is GroupBox || ctl is CheckBox || ctl is RadioButton)
                            ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                    foreach (Control btn in groupBox2.Controls)
                    {
                        if (btn is Button || btn is Label || btn is GroupBox || btn is CheckBox)
                            btn.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                    }
                }

            }
        }

        private void Debt_Adjustment_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjDebtHelper.objDebtBALClass = null;
            ObjDebtHelper.dtAgentNameID = null;
            ObjDebtHelper = null;
            this.Dispose();
        }

    }
}
