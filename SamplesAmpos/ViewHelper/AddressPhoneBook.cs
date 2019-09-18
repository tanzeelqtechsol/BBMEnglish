using System;
using ObjectHelper;
using BALHelper;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.View;
using System.Data;
using BumedianBM.Report;
using CrystalDecisions.CrystalReports.Engine;


namespace BumedianBM.ViewHelper
{
   public class AgentDetailHelper
    {
       AgentDetails agentForm;
       BALClass balAgentDetail;
       public AgentDetailHelper(AgentDetails form)
       {
           agentForm = form;
           balAgentDetail = new BALClass();
           balAgentDetail.SetAgentObject();
           

       }
       public void LoadData()
       {
           agentForm.cmb_agentname.DisplayMember = "NAME";
           agentForm.cmb_agentname.DataSource = balAgentDetail.GetAgentName();
           agentForm.cmb_agentname.SelectedIndex = -1;
           agentForm.cmb_company.DisplayMember = "COMPANY NAME";
           agentForm.cmb_company.DataSource = balAgentDetail.GetCompany();
           
           agentForm.cmb_company.SelectedIndex = -1;

       }
       public Boolean ValidatingAgentdetails()
       {

           if(balAgentDetail.AgentDetailObject.AgentName==string.Empty) 
           {
              MessageBox.Show("Agent Name Should not be Empty");
              agentForm.cmb_agentname.Focus();
               return false;
           }
           else if(balAgentDetail.AgentDetailObject.AgentPhone1==string.Empty)
           {
               MessageBox.Show("Phone No should not ne Empty");
               agentForm.Txt_Phone1.Focus();
               return false;
           }
           else if (balAgentDetail.AgentDetailObject.AgentCell1==string.Empty )
           {
               MessageBox.Show("Cell No Should not be Empty");
               agentForm.Txt_cell1.Focus();
               return false;
           }
           else if (balAgentDetail.AgentDetailObject.AgentMailId==string.Empty)
           {
            MessageBox.Show("Should Give a Valid EmailId");
            agentForm.Txt_email.Focus();
               return false;

           }
           else if (balAgentDetail.AgentDetailObject.WebId==string.Empty)
           {
               MessageBox.Show("Shoulg Give a Valid WebSite");
               agentForm.Txt_webaddress.Focus();
               return false;
           }
           else
           {
              return true;
           }
       }
       public void SaveMethod(AddressPhoneBookObjectClass ObjAgentDetail)
       {
           balAgentDetail.AgentDetailObject = ObjAgentDetail;
           if (this.ValidatingAgentdetails())
           {
               if (balAgentDetail.Save_AdrressPhone())
                   CommonHelper.GeneralFunction.Information("AgentDetails are Saved", ActionType.Save.ToString());
           }
       }
       public void ViewMethod()
       {
          agentForm.datagrid_addressphone.DataSource = balAgentDetail.PhoneBookDetails();
                 
       }
       public void print()
       {
           AddressPhoneBook rpt = new AddressPhoneBook();
           ReportDocument reportdocument = new ReportDocument();
           ReportViewer viewer = new ReportViewer();
           viewer.crystalReportViewer1.ReportSource = rpt;
           viewer.crystalReportViewer1.Refresh();
           viewer.ShowDialog();
       }
       public void SelectedIndexChange()
       {
           DataTable dt = new DataTable();
          balAgentDetail.AgentDetailObject.AgentName= agentForm.cmb_agentname.Text;
           if (balAgentDetail.AgentDetailObject.AgentName != null)
           {
                balAgentDetail.AgentDetailObject.Agentid=agentForm.cmb_agentname.Text;

               dt=balAgentDetail.GetAgentDetails();
               if (dt!=null && dt.Rows.Count > 0)
               {
                   balAgentDetail.AgentDetailObject.AgentPhone1 = dt.Rows[0]["PHONE1"].ToString();
                   balAgentDetail.AgentDetailObject.Agentphone2 = dt.Rows[0]["PHONE2"].ToString();
                   balAgentDetail.AgentDetailObject.AgentCell1  = dt.Rows[0]["CELL1"].ToString();
                   balAgentDetail.AgentDetailObject.AgentCell2 = dt.Rows[0]["CELL2"].ToString();
                   balAgentDetail.AgentDetailObject.AgentMailId = dt.Rows[0]["EMAIL"].ToString();
                   balAgentDetail.AgentDetailObject.PoBox = dt.Rows[0]["POST BOX"].ToString();
                   balAgentDetail.AgentDetailObject.AgentAddress1 = dt.Rows[0]["Address1"].ToString();
                   balAgentDetail.AgentDetailObject.AgentAddress2 = dt.Rows[0]["Address2"].ToString();
                   balAgentDetail.AgentDetailObject.WebId = dt.Rows[0]["webaddress"].ToString();
                   balAgentDetail.AgentDetailObject.CompanyName = dt.Rows[0]["COMPANYID"].ToString();
               }
               agentForm.SetControlFromObject(balAgentDetail.AgentDetailObject);     
           }
       }
       public void Delete(AddressPhoneBookObjectClass Obj)
       {
          balAgentDetail.AgentDetailObject = Obj;
          agentForm.datagrid_addressphone.Visible = false;
          if (balAgentDetail.AgentDetailObject.AgentName!=string.Empty)
           {
               balAgentDetail.AgentDetailObject.Agentid = balAgentDetail.AgentDetailObject.AgentName;

              if (balAgentDetail.DeleteData())
               {

                   CommonHelper.GeneralFunction.Information("Agent Details are Deleted", ActionType.Delete.ToString());
                   this.LoadData();
               }
              else
                  CommonHelper.GeneralFunction.Warning("Agent Details are Does not Exist", ActionType.Delete.ToString());
           }
          
       }
    }
}
