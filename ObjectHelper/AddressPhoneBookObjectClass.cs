using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
   public class AddressPhoneBookObjectClass:EntityBase
    {
       public string AgentMailId{get; set;}
    
        public string Agentid{get; set;}
       
        public string AgentName{get; set;}
       
        public string AgentAddress1{get; set;}
      
        public string AgentAddress2{get; set;}
       
        public string AgentPhone1{get; set;}
      
        public string Agentphone2{get; set;}
       
        public string AgentCell1{get; set;}
       
        public string AgentCell2{get; set;}
      
        public string WebId{get; set;}
     
        public string PoBox{get; set;}
       
        public string PhoneBookId{get; set;}
       
        public string CompanyID{get; set;}
     
        public string CompanyName{get; set;}
         
    }
   [System.Xml.Serialization.XmlType("ObjectDetails")]
   public class AgentDetailObjects : EntityCollection<AddressPhoneBookObjectClass>
   {
       public override string ToString() { return "ObjectDetails"; }
   }
}
