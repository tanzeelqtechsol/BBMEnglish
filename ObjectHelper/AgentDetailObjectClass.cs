using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public class AgentDetailObjectClass : EntityBase
    {
        private string name, address, agentType, phoneno, paymentDay, clientstr, supplierstr, hideAgentstr, branchstr, newYearNo;

        private double increaseprice;
        private int agentid = 0, number;
        private decimal debitLimt;
        private string accountsPayable, accountsRecivable, lastinvoice;
        private DateTime lastpaymentdate;
        private Boolean _client, _supplier, _hideAgent, _rentingClient, _branch;
        private Double discount;
      

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int AgentId
        {
            get { return agentid; }
            set { agentid = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }

        }
        public string AgentType
        {
            get { return agentType; }
            set { agentType = value; }
        }
        public string PaymentDay
        {
            get { return paymentDay; }
            set { paymentDay = value; }
        }
        public Double Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Phoneno
        {
            get { return phoneno; }
            set { phoneno = value; }
        }
        public decimal DebtLimt
        {
            get { return debitLimt; }
            set { debitLimt = value; }
        }
        //public int Remove
        //{
        //    get { return remove; }
        //    set {remove = value; }
        //}
        //public string Status
        //{
        //    get { return status; }
        //    set { status = value; }
        //}

        public string AccountsPayable
        {
            get { return accountsPayable; }
            set { accountsPayable = value; }
        }
        public string AccountsReceivable
        {
            get { return accountsRecivable; }
            set { accountsRecivable = value; }
        }
        public string Lastinvoice
        {
            get { return lastinvoice; }
            set { lastinvoice = value; }
        }
        public string NewYearNo
        {
            get { return newYearNo; }
            set { newYearNo = value; }
        }

        public DateTime? Lastpaymentdate
        {
            get { return lastpaymentdate; }
            set { lastpaymentdate =Convert.ToDateTime(value).Date; }
        }

        public Boolean Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public Boolean Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public Boolean HideAgent
        {
            get { return _hideAgent; }
            set { _hideAgent = value; }
        }
        public Boolean RentingClient
        {
            get { return _rentingClient; }
            set { _rentingClient = value; }
        }
        public Boolean Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }


        public string AgtClient
        {
            get { return clientstr; }
            set { clientstr = value; }
        }
        public string AgtSupplier
        {
            get { return supplierstr; }
            set { supplierstr = value; }
        }
        public string AgtHideAgent
        {
            get { return hideAgentstr; }
            set { hideAgentstr = value; }
        }
        public string AgtBranch
        {
            get { return branchstr; }
            set { branchstr = value; }
        }

        public double IncreasePrice
        {
            get { return increaseprice; }
            set { increaseprice = value; }
        }


        ///////**********Debt Adjustment***********\\\\\\\\\\\\

        private int _tableID, _receiptID;
        private double _payable, _recivable, _balance;
        private string _clientstr, _supplierstr, _hideAgentstr, _rentingClientstr, _branchstr, _descrip;
        //private DateTime _receiptDate;

        public int TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        public int ReceiptID
        {
            get { return _receiptID; }
            set { _receiptID = value; }
        }
        public string Description
        {
            get { return _descrip; }
            set { _descrip = value; }
        }

        public double Payable
        {
            get { return _payable; }
            set { _payable = value; }
        }
        public double Receivable
        {
            get { return _recivable; }
            set { _recivable = value; }
        }
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public string Agt_Client
        {
            get { return _clientstr; }
            set { _clientstr = value; }
        }
        public string Agt_Supplier
        {
            get { return _supplierstr; }
            set { _supplierstr = value; }
        }
        public string Agt_HideAgent
        {
            get { return _hideAgentstr; }
            set { _hideAgentstr = value; }
        }
        public string Agt_RentingClient
        {
            get { return _rentingClientstr; }
            set { _rentingClientstr = value; }
        }
        public string Agt_Branch
        {
            get { return _branchstr; }
            set { _branchstr = value; }
        }

        public string DebtStatus { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public Double Amount { get; set; }

        public String PayType { get; set; }

        public int PayFlag { get; set; }

        public int Year { get; set; }

        public int YearSequenceNo { get; set; }
        
    }
}
