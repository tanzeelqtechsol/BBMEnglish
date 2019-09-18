using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class GeneralObjectClass
    {
        public static List<AgentDetailObjectClass> AgentDetails = new List<AgentDetailObjectClass>();
        public static List<AgentDetailObjectClass> DebtAgents = new List<AgentDetailObjectClass>();
       // public static List<PurchaseObjectClass> SupplierDetails = new List<PurchaseObjectClass>();//=SupplierDetails.Add(new PurchaseObjectClass{ SupplierNo=(from list in AgentDetails where list.AgentId==102)});
      //public static List<PurchaseObjectClass> SupplierDetails=SupplierDetails.Add(new PurchaseObjectClass{ SupplierNo=(from list in AgentDetails where list.AgentId==102)});
        public static List<AgentDetailObjectClass> SupplierDetails = new List<AgentDetailObjectClass>();// (from list in AgentDetails where list.AgentId == 102 orderby list.Name select list).ToList();
     //public static List<PurchaseObjectClass> SupplierDetails=new List<PurchaseObjectClass>(SupplierDetails.Add({ SupplierNo=(from list in AgentDetails where list.AgentId==102)});
        public static List<BankObjectClass> BankList = new List<BankObjectClass>();
        public static List<BankObjectClass> BranchList = new List<BankObjectClass>();
        public static List<ComCatObjectClass> CategoryList = new List<ComCatObjectClass>();
        public static List<ComCatObjectClass> CompanyList = new List<ComCatObjectClass>();
        public static List<ItemCardObjectClass> ItemDetails = new List<ItemCardObjectClass>();
        public static List<EmployeeObjectClass> UserList = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> ReturnPurchaseList = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> UserGroupList = new List<EmployeeObjectClass>();
        public static List<EmployeeObjectClass> ScreenLimitList = new List<EmployeeObjectClass>();
        public static List<ItemCardObjectClass> DefaultUnitName = new List<ItemCardObjectClass>();
        
    }
}
