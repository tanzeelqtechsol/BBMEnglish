using System;
using System.Windows.Forms;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ViewHelper;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using SergeUtils;

namespace BumedianBM.ArabicView
{
    public partial class Agent_Details : Form,IDisposable
    {


        #region object Initialization

        public AgentDetailHelperClass ObjHelper;
        bool iscount = false;
        #endregion

        #region Variables
        //  public bool IsFromFormLoad;
        List<AgentDetailObjectClass> AgentDetails = new List<AgentDetailObjectClass>();
        BalanceSheetHelper BalanceSheetHelper = new BalanceSheetHelper();
        #endregion

        #region Constructor
        public Agent_Details()
        {
            InitializeComponent();
            this.SetLanguage();
            this.SetFont();
            ObjHelper = new AgentDetailHelperClass();
            ObjHelper.IsFromFormLoad = true;
            LoadAgentName();
            ObjHelper.IsFromFormLoad = false;
            btnDebtList.Enabled = UserScreenLimidations.Debts == true ? true : false;
            btnBalanceSheet.Enabled = UserScreenLimidations.BalanceSheet == true ? true : false;
            btnPrint.Enabled = UserScreenLimidations.Print == true ? true : false;
        }
        #endregion

        #region Method

        public void SetObjectFromControl()
        {

            ObjHelper.ObjbalClass.ObjAgentDetailObject.Name = cmbName.Text == string.Empty ? "" : cmbName.Text;
            ObjHelper.ObjbalClass.ObjAgentDetailObject.Number = txtNumber.Text == string.Empty ? 0 : Convert.ToInt32(txtNumber.Text.ToString());
            ObjHelper.ObjbalClass.ObjAgentDetailObject.Phoneno = txtPhone.Text.Trim(); ;
            ObjHelper.ObjbalClass.ObjAgentDetailObject.Address = txtAddress.Text.Trim();
            ObjHelper.ObjbalClass.ObjAgentDetailObject.DebtLimt = (this.txtDebtLimit.Text == string.Empty) ? 0 : Convert.ToDecimal(txtDebtLimit.Text);
            //
            if (chkdiscount.Checked == true)
                ObjHelper.ObjbalClass.ObjAgentDetailObject.IncreasePrice = 1;
            else
                ObjHelper.ObjbalClass.ObjAgentDetailObject.IncreasePrice = 0;
            //
            ObjHelper.ObjbalClass.ObjAgentDetailObject.Discount = txtDiscount.Text.Trim() == string.Empty ? 0 : Convert.ToDouble(txtDiscount.Text);
            if (chkSupplier.Checked == true)
                ObjHelper.ObjbalClass.ObjAgentDetailObject.PaymentDay = cmbPayDay.Text;
            else
                ObjHelper.ObjbalClass.ObjAgentDetailObject.PaymentDay = string.Empty;
            AgentTypeID();
        }

        public  void setControlFromObject()
        {
            cmbName.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Name;
            txtNumber.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Number.ToString();
            txtPhone.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Phoneno;
            txtAddress.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Address;
            txtDebtLimit.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.DebtLimt.ToString();
            txtDiscount.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Discount.ToString();
            //
            if (ObjHelper.ObjbalClass.ObjAgentDetailObject.IncreasePrice == 1)
                chkdiscount.Checked = true;
            else
                chkdiscount.Checked = false;
            //
            txtAccPayable.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Payable.ToString();
            txtAccRecivable.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Receivable.ToString();
            txtLastInvoice.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Lastinvoice;
            cmbPayDay.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.PaymentDay;
            txtLastPaymentDate.Text = ObjHelper.ObjbalClass.ObjAgentDetailObject.Lastpaymentdate.ToString();
        }

        private void Clear()
        {
            cmbName.Text = string.Empty;
            txtNumber.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDebtLimit.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtAccPayable.Text = string.Empty;
            txtAccRecivable.Text = string.Empty;
            txtLastPaymentDate.Text = string.Empty;
            txtLastInvoice.Text = string.Empty;
            chkBranch.Checked = false;
            chkClient.Checked = false;
            chkHideAgent.Checked = false;
            chkSupplier.Checked = false;
            cmbPayDay.Text = string.Empty;
            cmbName.Focus();
            chkdiscount.Checked = false;
        }

        private void SetLanguage()
        {
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnDebtList.Text = Additional_Barcode.GetValueByResourceKey("DebtList");
            btnDelete.Text = Additional_Barcode.GetValueByResourceKey("Delete");
            btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnSave.Text = Additional_Barcode.GetValueByResourceKey("Save");
            lblAccPayable.Text = Additional_Barcode.GetValueByResourceKey("AccPayable");
            lblAccReceivable.Text = Additional_Barcode.GetValueByResourceKey("AccReceivable");
            lblAddrress.Text = Additional_Barcode.GetValueByResourceKey("Address");
            lblDebtLimit.Text = Additional_Barcode.GetValueByResourceKey("DebtLimit");
            lblDiscount.Text = Additional_Barcode.GetValueByResourceKey("Change");//Discount
            lblLastInvoice.Text = Additional_Barcode.GetValueByResourceKey("LastInv");
            lblLastPayDate.Text = Additional_Barcode.GetValueByResourceKey("LastPayDate");
            lblName.Text = Additional_Barcode.GetValueByResourceKey("Name");
            lblNo.Text = Additional_Barcode.GetValueByResourceKey("AgentNo");
            lblPhone.Text = Additional_Barcode.GetValueByResourceKey("Phone");
            chkBranch.Text = Additional_Barcode.GetValueByResourceKey("Branch");
            chkClient.Text = Additional_Barcode.GetValueByResourceKey("Client");
            chkHideAgent.Text = Additional_Barcode.GetValueByResourceKey("HidenAgent");
            chkSupplier.Text = Additional_Barcode.GetValueByResourceKey("Supplier");
            grpAgentinfo.Text = Additional_Barcode.GetValueByResourceKey("AgentInfo");
            grpAgentType.Text = Additional_Barcode.GetValueByResourceKey("AgentType");
            lblPaymentDay.Text = Additional_Barcode.GetValueByResourceKey("PayDay");
            this.Text = Additional_Barcode.GetValueByResourceKey("AgentDetails");
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Sat"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Sun"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Mon"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Tus"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Wed"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Tur"));
            cmbPayDay.Items.Add(Additional_Barcode.GetValueByResourceKey("Fri"));
        }

        private void LoadAgentName()
        {
            cmbName.DataSource = null;
            AgentDetails = GeneralObjectClass.AgentDetails.Where(a => a.AgentId != 1001).ToList();
            //foreach (var item in AgentDetails.Where(a => a.AgentType.Contains("104")).ToList())
            //{
            //    int i = AgentDetails.FindIndex(a => a.Number == item.Number);
            //    // AgentDetails.Select(c=>(Color)c.GetType(
            //}
            cmbName.DisplayMember = "Name";
            cmbName.ValueMember = "AgentID";
            cmbName.DataSource = AgentDetails;
            cmbName.SelectedIndex = -1;
        }

        private void AgentTypeID()
        {

            if (chkClient.Checked == true)
            {
                ObjHelper.AgentType = "101"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtClient = "101";
            }
            else
            {
                ObjHelper.AgentType = "0"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtClient = "0";
            }
            if (chkSupplier.Checked == true)
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "102"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtSupplier = "102";
            }
            else
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "0"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtSupplier = "0";
            }
            if (chkBranch.Checked == true)
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "103"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtBranch = "103";
            }
            else
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "0"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtBranch = "0";
            }
            if (chkHideAgent.Checked == true)
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "104"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtHideAgent = "104";
            }
            else
            {
                ObjHelper.AgentType = ObjHelper.AgentType + "|" + "0"; ObjHelper.ObjbalClass.ObjAgentDetailObject.AgtHideAgent = "0";
            }
            ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentType = ObjHelper.AgentType;
        }


        #endregion

        #region Event

        private void Agent_Details_Load(object sender, EventArgs e)
        {
            cmbName.MatchingMethod = StringMatchingMethod.UseRegexs;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Clear();
            ObjHelper.ObjbalClass.ObjAgentDetailObject = new AgentDetailObjectClass();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetObjectFromControl();
                ObjHelper.SaveMethod();
                if (ObjHelper.isSaveSuccess)
                {
                    //cmbName.DataSource = null;
                    this.LoadAgentName();
                    if (txtNumber.Text == string.Empty)
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjHelper.ObjbalClass.ObjAgentDetailObject.Name, "Agent", "Save agent name details", Convert.ToInt32(InvoiceAction.No));
                    else
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Update), ObjHelper.ObjbalClass.ObjAgentDetailObject.Name, "Agent", "Update agent name details", Convert.ToInt32(InvoiceAction.No));
                    this.Clear();
                    ObjHelper.ObjbalClass.SetAgentDetailObject();
                    ObjHelper.isSaveSuccess = false;
                }
                else
                {
                    if (ObjHelper.ControlName.Contains("cmb"))
                    {
                        foreach (ComboBox ctl in Grp_AgentDetails.Controls.OfType<ComboBox>())
                        {
                            if (ctl.Name == ObjHelper.ControlName)
                                ctl.Focus();
                        }
                        ObjHelper.ControlName = string.Empty;
                    }
                    //else if (ObjHelper.ControlName.Contains("grp"))
                    //    chkSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ObjHelper.IsFromFormLoad)
            {
                if (cmbName.SelectedValue != null)
                {
                    ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId = Convert.ToInt32(cmbName.SelectedValue);
                    ObjHelper.AgentNameSelectedIndexChanged();
                    AgentFileSplit();//split  this method on 04 july 2014 

                    this.setControlFromObject();
/////---------------------Include the agent balance calcualtion on 10 july 2014---------------------------------------
                    BalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId;
                    
                    BalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status  = 1 ;
                    BalanceSheetHelper.AgentForm= true;
              

                    BalanceSheetHelper.Search();
                    BalanceSheetHelper.AgentForm = false ;//avoid the balance validation message 

                  if(BalanceSheetHelper.TotalBalance >=0)
                  {


                      txtAccRecivable.Text = BalanceSheetHelper.TotalBalance.ToString("#######0.000");
                        txtAccPayable.Text = "0.000";
                    }
                    else
                    {
                        txtAccRecivable.Text = "0.000";
                        txtAccPayable.Text = BalanceSheetHelper.TotalBalance.ToString("#######0.000");
                    }

////----------------------------------------------------------------------------

                }
            }
        }

        public  void AgentFileSplit()
        {
            string[] AgentType = ObjHelper.agenttype.Split('|');
            chkClient.Checked = chkSupplier.Checked = chkBranch.Checked = chkHideAgent.Checked = false;

            if (AgentType[0] == "101")
            {
                chkClient.Checked = true;
            }
            if (AgentType[1] == "102")
            {
                chkSupplier.Checked = true;
            }
            if (AgentType[2] == "103")
            {
                chkBranch.Checked = true;
            }
            if (AgentType[3] == "104")
            {
                chkHideAgent.Checked = true;
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbName.SelectedIndex <= -1)
                    //GeneralFunction.ErrInfo(Constants.INVALIDOPERATION, ActionType.Delete.ToString());
                    return;
                else
                {
                    this.SetObjectFromControl();
                    ObjHelper.DeleteMethod();
                    if (ObjHelper.isSaveSuccess)
                    {
                        // GeneralObjectClass.AgentDetails.RemoveAt(ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId);
                        // cmbName.DataSource = null;
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjHelper.ObjbalClass.ObjAgentDetailObject.Name, "AGENT", "Delete agent name details", Convert.ToInt32(InvoiceAction.No));
                        this.LoadAgentName();
                        this.Clear();
                        ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId = 0;
                    }
                }
            }
            catch (Exception EX)
            {
                GeneralFunction.ErrorMessages(EX.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // if (CommonHelper.GeneralFunction.Question(Constants.CLOSE, ActionType.Confirmation.ToString()) == DialogResult.Yes)
            this.Close();

        }

        public void txtDebtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string name = ((TextBox)(sender)).Name;
                switch (name)
                {
                    case "txtDebtLimit":
                        SendKeys.Send("{TAB}");
                        break;
                    case "txtDiscount":
                        SendKeys.Send("{TAB}");
                        break;
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                CommonHelper.GeneralFunction.Warning("OnlyNumbersAllowed", "AgentDetails");
                e.Handled = true;
            }
            else if (((TextBox)(sender)).Text.Length >8)
            {
                e.Handled = true;
            }
        }

        private void txtPrint_Click(object sender, EventArgs e)
        {
            ObjHelper.Print();
        }

        private void btnDebtList_Click(object sender, EventArgs e)
        {
            ObjHelper.DebtList();
        }

        private void btnBalanceSheet_Click(object sender, System.EventArgs e)
        {
            frmBalanceSheet objbalanceSheet = new frmBalanceSheet();
            if (txtNumber.Text.Length != 0 && cmbName.Text.Length != 0)
            {
                objbalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(txtNumber.Text);
                objbalanceSheet.objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentName = cmbName.Text;
                objbalanceSheet.BringToFront();
                objbalanceSheet.ShowDialog();
            }
            else
                objbalanceSheet.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ObjHelper.Print();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), ObjHelper.ObjbalClass.ObjAgentDetailObject.Name, "AGENT", "Print agent details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception EX)
            {
              GeneralFunction.ErrorMessages(EX.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtAddress.Focus();
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete) && (e.KeyChar != '+'))
            {
                CommonHelper.GeneralFunction.Warning("OnlyNumbersAllowed", "AgentDetails");
                e.Handled = true;
            }
        }
        #endregion

        private void chkSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupplier.Checked == false)
            {
                lblPaymentDay.Visible = false;
                cmbPayDay.Visible = false;
                chkHideAgent.Focus();
            }
            else
            {
                lblPaymentDay.Visible = true;
                cmbPayDay.Visible = true;
                cmbPayDay.Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cmbName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == 38 || e.KeyValue == 40)
            //    iscount = true;
            //if (e.KeyValue == 13 && ((ComboBox)sender).DroppedDown == true)
            //    ((ComboBox)sender).DroppedDown = false;
            if (e.KeyValue == 13)
                SendKeys.Send("{TAB}");
            //else
            //{
            //    if (e.KeyValue != 13 && e.KeyValue != (char)Keys.Delete && e.KeyValue != (char)Keys.Back && (e.KeyValue < 111 || e.KeyValue > 126))//this Line Modified to fix the Drop Down Expend on 2Aug2014 By Meena.R
            //    {
            //        if (((ComboBox)sender).DataSource != null)
            //        {
            //            if (((ComboBox)sender).DroppedDown == true)
            //                ((ComboBox)sender).DroppedDown = false;
            //        }

            //    }
            //}

        }

        private void chkClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((((CheckBox)(sender)).Name).ToString() == "chkSupplier" && e.KeyChar == 13)
                SendKeys.Send("{TAB}");
            if ((((CheckBox)(sender)).Name.ToString()) == "chkBranch" && e.KeyChar == 13)
                this.InvokeOnClick(btnSave, EventArgs.Empty);
            if ((((((CheckBox)(sender)).Name).ToString() == "chkClient")) && (e.KeyChar == 13))
                SendKeys.Send("{TAB}");
            if ((((((CheckBox)(sender)).Name).ToString() == "chkHideAgent")) && (e.KeyChar == 13))
                SendKeys.Send("{TAB}");

        }

        private void Agent_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F12)
            {
                Quick_Price_Information objPrice = new Quick_Price_Information();
                objPrice.ShowDialog();
            }
        }

        private void cmbPayDay_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                //chkHideAgent.Focus();//commended on 28Aug2014 by Meena.R
                chkClient.Focus();
            }

        }

        //private void cmbName_DropDown(object sender, EventArgs e)
        //{
        //    //((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.None;
        //}

        //private void cmbName_DropDownClosed(object sender, EventArgs e)
        //{
        //    ((ComboBox)sender).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    if (iscount)
        //        iscount = false;
        //    else
        //        cmbName_SelectedIndexChanged(sender, EventArgs.Empty);
        //}

        private void cmbName_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            List<ObjectHelper.AgentDetailObjectClass> lstCombo = (List<ObjectHelper.AgentDetailObjectClass>)cmbName.DataSource;
            if (cmbName.SelectedIndex < -1 || lstCombo.Count < 0) return;
            Boolean ItemHideStatus;
            string ItemName;
            ItemHideStatus = AgentDetails[e.Index].AgentType.Contains("104") == true ? true : false;
            ItemName = AgentDetails[e.Index].Name;
            //StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.Far;
            if (ItemHideStatus == true)
            {
                e.DrawBackground();
                e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), new SolidBrush(Color.Red), e.Bounds, new StringFormat(StringFormatFlags.DirectionRightToLeft));
                //e.DrawFocusRectangle();
            }
            else
            {
                e.DrawBackground();
                e.Graphics.DrawString(ItemName, new Font("Microsoft Sans Serif", 12, FontStyle.Bold), new SolidBrush(Color.Black), e.Bounds, new StringFormat(StringFormatFlags.DirectionRightToLeft));
            }

        }

        private void SetFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            //Agent_Details agent;

            if (Culture.Name == "en-US")
            {

                Properties.Settings.Default.Save();
                foreach (Control ctl in Grp_AgentDetails.Controls.OfType<Label>())
                {
                    ctl.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control checkbox in grpAgentType.Controls.OfType<CheckBox>())
                {
                    checkbox.Font = new Font("Segoe UI", 10.25f, System.Drawing.FontStyle.Bold);
                }
                foreach (Control btn in Grp_Button.Controls)
                {
                    btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                foreach (Control lbl in grpAgentinfo.Controls.OfType<Label>())
                {
                    lbl.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                }
                btnClose.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                grpAgentinfo.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                grpAgentType.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);

                //List<Control> control=new List<Control>();
                //control = (from Control ctrl in Controls
                //               select ctrl).ToList();
                //var selectedControl = control.Where(a => (a.Controls == a.Controls.OfType<Button>()) || (a.Controls == a.Controls.OfType<Label>()) || (a.Controls == a.Controls.OfType<CheckBox>()));
            }
        }

        private void Agent_Details_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!ObjHelper.IsFromFormLoad)
                {
                    if (!string.IsNullOrEmpty(txtNumber.Text))
                    {
                        ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId = Convert.ToInt32(txtNumber.Text);
                        int RecordCount = ObjHelper.AgentNameSelectedIndexChanged();
                        if (RecordCount == 0)
                        {
                            string message = Additional_Barcode.GetValueByResourceKey("AgentNotExist");
                            MessageBox.Show(message + "," + txtNumber.Text);
                            if (string.IsNullOrEmpty(ObjHelper.agenttype))
                                return;
                        }

                        AgentFileSplit();//split  this method on 04 july 2014 

                        this.setControlFromObject();
                        /////---------------------Include the agent balance calcualtion on 10 july 2014---------------------------------------
                        BalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = ObjHelper.ObjbalClass.ObjAgentDetailObject.AgentId;

                        BalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = 1;
                        BalanceSheetHelper.AgentForm = true;


                        BalanceSheetHelper.Search();
                        BalanceSheetHelper.AgentForm = false;//avoid the balance validation message 

                        if (BalanceSheetHelper.TotalBalance >= 0)
                        {


                            txtAccRecivable.Text = BalanceSheetHelper.TotalBalance.ToString("#######0.000");
                            txtAccPayable.Text = "0.000";
                        }
                        else
                        {
                            txtAccRecivable.Text = "0.000";
                            txtAccPayable.Text = BalanceSheetHelper.TotalBalance.ToString("#######0.000");
                        }

                        ////----------------------------------------------------------------------------

                    }
                }
            }
            else if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                //CommonHelper.GeneralFunction.Warning("OnlyNumbersAllowed", "AgentDetails");
                e.Handled = true;
            }
        }

        private void chkdiscount_CheckedChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount.Focus();

            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtLastInvoice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grp_AgentDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
