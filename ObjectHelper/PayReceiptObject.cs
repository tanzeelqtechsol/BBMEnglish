using System;
using System.Collections.Generic;
using System.Text;

namespace HSB_ObjectHelper
{
    public class PayReceiptObject
    {
        public string   _payDiscription, _payDiscriptionArabic, _payNote, _payBank, _payBranch;
        public string _payRemarks,  _payMethod, _payReason;
        public DateTime _payCreateDate, _payModifiedDate, _payPaymentDate, _payDate;
        public decimal _payValue, _payGross, _payBalance;
      
        private bool _checkchked;
        private int _currentyear,_payPayTo, _bankselectedval, _branchselectedval, _payCreatedBy, _payModifiedBy, _payStatus, _year, _agentid, _payMethodID, _bankID, _branchID, _payFlag;
        private Int64 _payUserId;
        private long _maxpayreceiptno, _yearsequenceno, _payReceiptNo, _payInvoiceNo, _payInvoiceID;


        #region Balance Variables
        private string _balanceAgent, _balanceStatus, _currentyearstr;
        private DateTime _balanceFromDate, _balanceToDate;
        public decimal _amntrecieved, _netamnt,_amntpaid,_balanceamnt;
        #endregion

        public int BankID
        {
            get { return _bankID; }
            set { _bankID = value; }
        }

        public int BranchID
        {
            get { return _branchID; }
            set { _branchID = value; }
        }
        
   
        public int PayMethodID
        {
            get { return _payMethodID; }
            set { _payMethodID = value; }
        }
        

        public decimal AmountPaid
        {
            get { return _amntpaid; }
            set { _amntpaid = value; }
        }


        public decimal BalanceAmount
        {
            get { return _balanceamnt; }
            set { _balanceamnt = value; }
        }

        public int AgentID
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        

        public long MaxpayReceiptNo
        {
            get { return _maxpayreceiptno; }
            set { _maxpayreceiptno = value; }
        }

        public long YearSequenceNo
        {
            get { return _yearsequenceno; }
            set { _yearsequenceno = value; }
        }

     
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        
        
        public int BankSelectedVal
        {
            get { return _bankselectedval; }
            set { _bankselectedval = value; }
        }

        public int BranchSelectedVal
        {
            get { return _branchselectedval; }
            set { _branchselectedval = value; }
        }              

        public bool CheckChecked
        {
            get { return _checkchked; }
            set { _checkchked = value; }
        }
        
        public decimal AmountRecieved
        {
            get { return _amntrecieved; }
            set { _amntrecieved = value; }
        }

        public decimal NetAmount
        {
            get { return _netamnt; }
            set { _netamnt = value; }
        }

        public long PayReceiptNo
        {
            get
            {
                return _payReceiptNo;
            }
            set
            {
                _payReceiptNo = value;
            }
        }
        public int PayTo
        {
            get
            {
                return _payPayTo;
            }
            set
            {
                _payPayTo = value;
            }
        }
        public string PayDiscription
        {
            get
            {
                return _payDiscription;
            }
            set
            {
                _payDiscription = value;
            }
        }
        public string PayDiscriptionArabic
        {
            get
            {
                return _payDiscriptionArabic;
            }
            set
            {
                _payDiscriptionArabic = value;
            }
        }
        public string PayNote
        {
            get
            {
                return _payNote;
            }
            set
            {
                _payNote = value;
            }
        }
        public string PayBank
        {
            get
            {
                return _payBank;
            }
            set
            {
                _payBank = value;
            }
        }
        public string PayBranch
        {
            get
            {
                return _payBranch;
            }
            set
            {
                _payBranch = value;
            }
        }
        public int PayStatus
        {
            get
            {
                return _payStatus;
            }
            set
            {
                _payStatus = value;
            }
        }
        public string PayRemarks
        {
            get
            {
                return _payRemarks;
            }
            set
            {
                _payRemarks = value;
            }
        }
        public int PayCreatedBy
        {
            get
            {
                return _payCreatedBy;
            }
            set
            {
                _payCreatedBy = value;
            }
        }
        public int PayModifiedBy
        {
            get
            {
                return _payModifiedBy;
            }
            set
            {
                _payModifiedBy = value;
            }
        }
        public string PayMethod
        {
            get
            {
                return _payMethod;
            }
            set
            {
                _payMethod = value;
            }
        }
        public long PayInvoiceNo
        {
            get
            {
                return _payInvoiceNo;
            }
            set
            {
                _payInvoiceNo = value;
            }
        }
        public long PayInvoiceID
        {
            get
            {
                return _payInvoiceID;
            }
            set
            {
                _payInvoiceID = value;
            }
        }
        public Int64 PayUserId
        {
            get
            {
                return _payUserId;
            }
            set
            {
                _payUserId = value;
            }
        }
        public string PayReason
        {
            get
            {
                return _payReason;
            }
            set
            {
                _payReason = value;
            }
        }
        public int PayFlag
        {
            get
            {
                return _payFlag;
            }
            set
            {
                _payFlag = value;
            }
        }

        public DateTime PayCreateDate
        {
            get
            {
                return _payCreateDate;
            }
            set
            {
                _payCreateDate = value;
            }
        }
        public DateTime PayModifiedDate
        {
            get
            {
                return _payModifiedDate;
            }
            set
            {
                _payModifiedDate = value;
            }
        }
        public DateTime PayPaymentDate
        {
            get
            {
                return _payPaymentDate;
            }
            set
            {
                _payPaymentDate = value;
            }
        }
        public DateTime PayDate
        {
            get
            {
                return _payDate;
            }
            set
            {
                _payDate = value;
            }
        }

        public decimal PayValue
        {
            get
            {
                return _payValue;
            }
            set
            {
                _payValue = value;
            }
        }
        public decimal PayGross
        {
            get
            {
                return _payGross;
            }
            set
            {
                _payGross = value;
            }
        }
        public decimal PayBalance
        {
            get
            {
                return _payBalance;
            }
            set
            {
                _payBalance = value;
            }
        }
        public string BalanceAgent
        {
            get { return _balanceAgent; }
            set { _balanceAgent = value; }
        }



        public string BalanceStatus
        {
            get { return _balanceStatus; }
            set { _balanceStatus = value; }
        }



        public DateTime BalanceFromDate
        {
            get { return _balanceFromDate; }
            set { _balanceFromDate = value; }
        }



        public DateTime BalanceToDate
        {
            get { return _balanceToDate; }
            set { _balanceToDate = value; }
        }


        public int CurrentYear
        {
            get { return _currentyear; }
            set { _currentyear = value; }
        }

        public string CurrentYearStr
        {
            get
            {
                return _currentyearstr;
            }
            set
            {
                _currentyearstr = value;
            }
        }
        public string ValidationString { get; set; }

        public int TempValue { get; set; }
        public bool PrintPreviewChecked { get; set; }

    }
}
