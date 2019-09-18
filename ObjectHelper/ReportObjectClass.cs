using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class ReportObjectClass
    {
        public String AgentType  { get; set; }
        public DateTime  ?FromDate { get; set; }
        public DateTime ?ToDate { get; set; }
        public bool  CheckDateField { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string ItemName { get; set; }
        public int  ItemNo { get; set; }
        public int   ExpiryItem { get; set; }
        public string  AgentName { get; set; }
        public int  AgentID { get; set; }
        public string  CompanyName { get; set; }
        public int  CompanyID { get; set; }
        public string  CategoryName { get; set; }
        public int  CategoryID { get; set; }
    
        public int  UserId { get; set; }
        public string  BankName { get; set; }
        public int  BankID { get; set; }
        public int  NumberID { get; set; }
        public int  Number { get; set; }
        public string  SortingType { get; set; }
        public string  TypeOfView { get; set; }
        public bool   IncludeLogo { get; set; }
        public string  FromField { get; set; }
        public Boolean List { get; set; }
        public Boolean Table { get; set; }
        public Boolean Chart { get; set; }
        public Boolean Linear { get; set; }
        public int ItemType { get; set; }
        public string Flag { get; set; }
        public Boolean PrintPreviewChecked { get; set; }

    }
}
