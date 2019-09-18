using System;
using System.Data;
using System.Windows.Forms;
using BumedianBM.ViewHelper;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace BumedianBM.View
{
    public partial class AgentDetails : Form
    {
        AgentDetailHelper ObjAgentDetailHelper;
        AddressPhoneBookObjectClass ObjSetAgentDetail;
        public AgentDetails()
        {
            InitializeComponent();
            ObjAgentDetailHelper = new AgentDetailHelper(this);
            ObjSetAgentDetail = new AddressPhoneBookObjectClass();
            this.Visible_ControlTrue();
            ObjAgentDetailHelper.LoadData();
        }
        public void SetControlFromObject(AddressPhoneBookObjectClass ObjGetAgentDetail)
        {
            Txt_Address.Text = ObjGetAgentDetail.AgentAddress1;
            Txt_address2.Text = ObjGetAgentDetail.AgentAddress2;
            Txt_cell1.Text = ObjGetAgentDetail.AgentCell1;
            Txt_cell2.Text = ObjGetAgentDetail.AgentCell2;
            Txt_email.Text = ObjGetAgentDetail.AgentMailId;
            cmb_agentname.Text = ObjGetAgentDetail.AgentName;
            Txt_Phone1.Text = ObjGetAgentDetail.AgentPhone1;
            Txt_phone2.Text = ObjGetAgentDetail.Agentphone2;
            cmb_company.Text = ObjGetAgentDetail.CompanyName;
            Txt_POBox.Text = ObjGetAgentDetail.PoBox;
            Txt_webaddress.Text = ObjGetAgentDetail.WebId;
        }
           
        public void SetObjectFromControl()
        {
            ObjSetAgentDetail.AgentAddress1 = Txt_Address.Text;
            ObjSetAgentDetail.AgentAddress2 = Txt_address2.Text;
            ObjSetAgentDetail.AgentCell1 = Txt_cell1.Text;
            ObjSetAgentDetail.AgentCell2 = Txt_cell2.Text;
            ObjSetAgentDetail.AgentMailId = Txt_email.Text;
            ObjSetAgentDetail.AgentName = cmb_agentname.Text;
            ObjSetAgentDetail.AgentPhone1 = Txt_Phone1.Text;
            ObjSetAgentDetail.Agentphone2 = Txt_phone2.Text;
            ObjSetAgentDetail.PoBox = Txt_POBox.Text;
            ObjSetAgentDetail.WebId = Txt_webaddress.Text;
            ObjSetAgentDetail.PhoneBookId = "000";
            ObjSetAgentDetail.Agentid = "000";
         
        }

    
        private void Btn_save_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
          
            ObjAgentDetailHelper.SaveMethod(ObjSetAgentDetail);
            this.Clear();

        }

        private void button_new_Click(object sender, EventArgs e)
        {
            this.Clear();
            ObjSetAgentDetail = null;
        }
    

        private void button_delete_Click(object sender, EventArgs e)
        {
            this.SetObjectFromControl();
            ObjAgentDetailHelper.Delete(ObjSetAgentDetail);
            this.Clear();
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            ObjAgentDetailHelper.ViewMethod();
            this.Visible_ControlFalse();

        }
        private void button_close_Click(object sender, EventArgs e)
        {
            if ((CommonHelper.GeneralFunction.Question("Do You Want to Close", ActionType.Confirmation.ToString())) == DialogResult.OK)
                this.Close();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            ObjAgentDetailHelper.print();

        }

        private void cmb_agentname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjAgentDetailHelper.SelectedIndexChange();
        }
        private void Visible_ControlFalse()
        {
            cmb_agentname.SendToBack();
            cmb_company.SendToBack();
            Lbl_Name.SendToBack();
            Lbl_Company.SendToBack();
            Lbl_Phone1.SendToBack();
            Lbl_WebSite.SendToBack();
            Lbl_Phone2.SendToBack();
            Lbl_Address2.SendToBack();
            Lbl_Cell1.SendToBack();
            Lbl_Address1.SendToBack();
            Lbl_Cell2.SendToBack();
            Lbl_Email.SendToBack();
            Lbl_POBox.SendToBack();
            Txt_webaddress.SendToBack();
            Txt_address2.SendToBack();
            Txt_Address.SendToBack();
            Txt_Phone1.SendToBack();
            Txt_phone2.SendToBack();
            Txt_cell2.SendToBack();
            Txt_POBox.SendToBack();
            Txt_cell1.SendToBack();
            Txt_email.SendToBack();
            button_close.SendToBack();

            cmb_agentname.Visible = false;
            cmb_company.Visible = false;
            Lbl_Name.Visible = false;
            Lbl_Company.Visible = false;
            Lbl_Phone1.Visible = false;
            Lbl_WebSite.Visible = false;
            Lbl_Phone2.Visible = false;
            Lbl_Address2.Visible = false;
            Lbl_Cell1.Visible = false;
            Lbl_Address1.Visible = false;
            Lbl_Cell2.Visible = false;
            Lbl_Email.Visible = false;
            Lbl_POBox.Visible = false;
            Txt_webaddress.Visible = false;
            Txt_address2.Visible = false;
            Txt_Address.Visible = false;
            Txt_Phone1.Visible = false;
            Txt_phone2.Visible = false;
            Txt_cell2.Visible = false;
            Txt_POBox.Visible = false;
            Txt_cell1.Visible = false;
            Txt_email.Visible = false;
            button_close.Visible = false;
            datagrid_addressphone.Visible = true;
            Btn_Back.Visible = true;

        }
        private void Visible_ControlTrue()
        {
            cmb_agentname.Visible = true;
            cmb_company.Visible = true;
            Lbl_Name.Visible = true;
            Lbl_Company.Visible = true;
            Lbl_Phone1.Visible = true;
            Lbl_WebSite.Visible = true;
            Lbl_Phone2.Visible = true;
            Lbl_Address2.Visible = true;
            Lbl_Cell1.Visible = true;
            Lbl_Address1.Visible = true;
            Lbl_Cell2.Visible = true;
            Lbl_Email.Visible = true;
            Lbl_POBox.Visible = true;
            Txt_webaddress.Visible = true;
            Txt_address2.Visible = true;
            Txt_Address.Visible = true;
            Txt_Phone1.Visible = true;
            Txt_phone2.Visible = true;
            Txt_cell2.Visible = true;
            Txt_POBox.Visible = true;
            Txt_cell1.Visible = true;
            Txt_email.Visible = true;
            button_close.Visible = true;
            datagrid_addressphone.Visible = false;
            Btn_Back.Visible = false;

            cmb_agentname.BringToFront();
            cmb_company.BringToFront();
            Lbl_Name.BringToFront();
            Lbl_Company.BringToFront();
            Lbl_Phone1.BringToFront();
            Lbl_WebSite.BringToFront();
            Lbl_Phone2.BringToFront();
            Lbl_Address2.BringToFront();
            Lbl_Cell1.BringToFront();
            Lbl_Address1.BringToFront();
            Lbl_Cell2.BringToFront();
            Lbl_Email.BringToFront();
            Lbl_POBox.BringToFront();
            Txt_webaddress.BringToFront();
            Txt_address2.BringToFront();
            Txt_Address.BringToFront();
            Txt_Phone1.BringToFront();
            Txt_phone2.BringToFront();
            Txt_cell2.BringToFront();
            Txt_POBox.BringToFront();
            Txt_cell1.BringToFront();
            Txt_email.BringToFront();
            button_close.BringToFront();

        }
        private void Clear()
        {
            Txt_Address.Text = string.Empty;
            Txt_address2.Text = string.Empty;
            Txt_cell1.Text = string.Empty;
            Txt_cell2.Text = string.Empty;
            Txt_email.Text = string.Empty;
            cmb_agentname.Text = string.Empty;
            cmb_company.Text = string.Empty;
            Txt_webaddress.Text = string.Empty;
            Txt_POBox.Text = string.Empty;
            Txt_Phone1.Text = string.Empty;
            Txt_phone2.Text = string.Empty;
        }
      
     }
}
