using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class BalanceSheetObjcetClass
    {
        //private string _balanceAgent, _balanceStatus, _agentid, _description, _status, _createdby, _modifiedby;
        private DateTime? _balanceFromDate, _balanceToDate;
           private DateTime? _date;
        //private decimal _receivable, _payable, _balance, _discount;
        public long PurchaseInvoiceID { get; set; }
        public string InvoiceNameID { get; set; }
        public string InvoiceNameYrNo { get; set; }
        public string YearSquenceNo { get; set; }
        public long PurchaseDate { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal NetAmount { get; set; }
        public int Status { get; set; }
        public decimal Discount { get; set; }
        public int AgentID { get; set; }
        public string AgentName { get; set; }
        public int Account { get; set; }
        public decimal Balance { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        //public string BalanceAgent
        //{
        //    get
        //    {
        //        return _balanceAgent;
        //    }
        //    set
        //    {
        //        _balanceAgent = value;
        //    }
        //}
        //public string BalanceStatus
        //{
        //    get
        //    {
        //        return _balanceStatus;
        //    }
        //    set
        //    {
        //        _balanceStatus = value;
        //    }
        //}
        //public string AgentId
        //{
        //    get
        //    {
        //        return _agentid;
        //    }
        //    set
        //    {
        //        _agentid = value;
        //    }
        //}
        //public string Description
        //{
        //    get
        //    {
        //        return _description;
        //    }
        //    set
        //    {
        //        _description = value;
        //    }
        //}
        //public string Status
        //{
        //    get
        //    {
        //        return _status;
        //    }
        //    set
        //    {
        //        _status = value;
        //    }
        //}
        //public string CreatedBy
        //{
        //    get
        //    {
        //        return _createdby;
        //    }
        //    set
        //    {
        //        _createdby = value;
        //    }
        //}
        //public string ModifiedBy
        //{
        //    get
        //    {
        //        return _modifiedby;
        //    }
        //    set
        //    {
        //        _modifiedby = value;
        //    }
        //}
        //public decimal Receivable
        //{
        //    get
        //    {
        //        return _receivable;
        //    }
        //    set
        //    {
        //        _receivable = value;
        //    }
        //}
        //public decimal Payable
        //{
        //    get
        //    {
        //        return _payable;
        //    }
        //    set
        //    {
        //        _payable = value;
        //    }
        //}
        //public decimal Balance
        //{
        //    get
        //    {
        //        return _balance;
        //    }
        //    set
        //    {
        //        _balance = value;
        //    }
        //}
        //public decimal Discount
        //{
        //    get
        //    {
        //        return _discount;
        //    }
        //    set
        //    {
        //        _discount = value;
        //    }
        //}
        public DateTime ? BalanceFromDate
        {
            get
            {
                return _balanceFromDate;
             }
            set
            {
                _balanceFromDate = value;
            }
        }
        public DateTime ? BalanceToDate
        {
            get
            {
                return _balanceToDate;
            }
            set
            {
                _balanceToDate = value;
            }
        }
        public DateTime ? ProcessDate
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
      
    }
}
