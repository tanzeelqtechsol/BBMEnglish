using System;
using System.Collections.Generic;
using System.Text;

namespace HSB_ObjectHelper
{
    public class ReceiveReceiptObject
    {
        #region Variables
        private string _discription, _note, _receiptdetid, _username, _discriptionarabic, _agentname, _receivedfromstr, _currentyearstr;
        //private float _grossamount;
        private DateTime _receiptdate;
        private bool _checkchked;
        private int _currentyear,_bankselectedval, _branchselectedval, _UserId, _status, _year, _saletype, _agentid, _paymethodid, _bank, _branch, _receivedfrom;
        private decimal _netvalue, _balance, _grossamount, _amounreceived;
        private long _maxpayreceiptno, _yearsequenceno, _receiptid, _saleid, _saleinv;

        #endregion



        public string ReceivedFromName
        {
            get { return _receivedfromstr; }
            set { _receivedfromstr = value; }
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

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
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


        public int receivedfrom
        {
            get { return _receivedfrom; }
            set { _receivedfrom = value; }

        }
        public string discription
        {
            get
            { return _discription; }
            set { _discription = value; }
        }

        public string discriptionarabic
        {
            get
            { return _discriptionarabic; }
            set { _discriptionarabic = value; }
        }
        public int bank
        {
            get
            { return _bank; }
            set { _bank = value; }
        }
        public int branch
        {
            get
            { return _branch; }
            set { _branch = value; }
        }
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }


        }
        public decimal netvalue
        {
            get
            { return _netvalue; }
            set { _netvalue = value; }
        }
        public string note
        {
            get
            { return _note; }
            set { _note = value; }
        }
        public string username
        {
            get
            { return _username; }
            set { _username = value; }
        }
        public long saleid
        {
            get
            { return _saleid; }
            set { _saleid = value; }
        }
        public long saleinv
        {
            get
            { return _saleinv; }
            set { _saleinv = value; }
        }
        public DateTime receiptdate
        {
            get
            { return _receiptdate; }
            set { _receiptdate = value; }
        }
        public long receiptid
        {
            get { return _receiptid; }
            set { _receiptid = value; }

        }
        public string receiptdetid
        {
            get { return _receiptdetid; }
            set { _receiptdetid = value; }

        }
        public int paymethodid
        {
            get { return _paymethodid; }
            set { _paymethodid = value; }

        }
        public int saletype
        {
            get { return _saletype; }
            set { _saletype = value; }

        }
        public decimal grossamount
        {
            get { return _grossamount; }
            set { _grossamount = value; }
        }

        public string AgentName
        {
            get { return _agentname; }
            set { _agentname = value; }

        }

        public int AgentID
        {
            get { return _agentid; }
            set { _agentid = value; }
        }

        public decimal AmountReceived
        {
            get { return _amounreceived; }
            set { _amounreceived = value; }
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

        public int PaymentTypeID { get; set; }

        public double PaymentCharges { get; set; }
        public bool PrintPreviewChecked { get; set; }

    }





}

