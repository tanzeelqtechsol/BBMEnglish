using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;
using System.Collections.Generic;
using System;

namespace BALHelper
{
   public class AgentDetailBALClass
    {

       AgentDetailDAL ObjagentdetailDAL;
       AgentDetailObjectClass ObjagentdetailObjectClass; 
       public AgentDetailBALClass()
       {
           ObjagentdetailDAL = new AgentDetailDAL();
       }
       public AgentDetailObjectClass ObjAgentDetailObject
       {
           get { return ObjagentdetailObjectClass; }
           set { ObjagentdetailObjectClass = value; }
       }
       public void SetAgentDetailObject()
       {
           ObjAgentDetailObject = new AgentDetailObjectClass();
       }
       public bool SaveAgentDetails()
       {
           if (ObjagentdetailDAL.SaveAgentdetails(ObjAgentDetailObject) > 0)
               return true;
           else
               return false;
       }
       public bool CheckAgentAvailable()
       {
           List<object> AgentAvailable;
           try
           {
               AgentAvailable = ObjagentdetailDAL.Check_AgentNameAvailable(ObjAgentDetailObject);
               if (AgentAvailable != null && AgentAvailable.Count > 0)
               {
                   return false;
               }
               else
                   return true;
           }
           catch (Exception ex)
           {

               throw ex;
           }
           finally
           {
               AgentAvailable = null;
           }
         
       }
       public bool DeleteAgentDetail()
       {
           if (ObjagentdetailDAL.Delete_AgentDetails(ObjAgentDetailObject) > 0)
               return true;
           else
               return false;
       }
       public bool AgentInvolvedInInvoice()
       {
           object obj= ObjagentdetailDAL.Get_AgentInvoiceCount(ObjAgentDetailObject.AgentId);
           if (Convert.ToInt32(obj) == 0 || obj==null)
               return true;
           else
               return false;
       }
       //public DataTable GetAgentName()
       //{
       //    DataTable dt = new DataTable();
       //    dt = ObjagentdetailDAL.Get_AllAgentNames();
       //    return dt;
       //}
       public List<AgentDetailObjectClass> GetAgentDetails()
       {
           List<AgentDetailObjectClass> agnetDetails = new List<AgentDetailObjectClass>();
           agnetDetails = ObjagentdetailDAL.Get_AgentdetailsByID(ObjagentdetailObjectClass);
           return agnetDetails;
       }
       public DataTable DebtList()
       {
           return ObjagentdetailDAL.getDebtReportValues(ObjAgentDetailObject.Number);
       }
       public DataTable ReportAgentDetails()
       {
           return ObjagentdetailDAL.Get_ReportValues(ObjAgentDetailObject.Number);
       }
      
       //public void get()
       //{
       //    ObjagentdetailDAL.GetAllAgentNames();
       //}
    }
}
