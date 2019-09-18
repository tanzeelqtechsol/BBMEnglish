using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class SaleReturnObjectClass
    {
        public int currentPaymentIDForUpdate = 0;
        public int ID { get; set; }
        public long SaleReturnID { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Reason { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public string UserName { get; set; }
        public string NewYearInvoiceNo { get; set; }
        public int Stock { get; set; }
        public int ItemType { get; set; }
        public string DgrReturnBacgrndColor { get; set; }
        public int DgrReturnSelectdRowCount { get; set; }
        public Boolean DtpReturnedDateEnabled { get; set; }
        public Boolean SaveReturnInvoice { get; set; }
        public Boolean ModifyReturnInvoice { get; set; }
        public int SelectedRowCount { get; set; }
        #region Old Properties

        private DateTime _fromdate, _todate, _returndate, _balanceFromDate, _balanceToDate, _saledate, _Newexpr, _expiry;
        public int _mtb_status, _currentyear, _status, _modifiedby, _mtb_updation, _package, _balanceAgent, _year, _itemno, _clientno, _quantity, _createdby, _returnquantity, rowcount, selectedrowqty, _user;
        private string _client, _item, _returnclient, _accountid, _type, _all, _serialno;
        public string _paymentid, _paydiscription, _balanceStatus, returnqtytext;
        private float _balance, _totalreturnquantity;
        public Boolean nonstockitem, radinvoicecheked, raditemcheked;
        private decimal _amntrecieved, _netamnt, _balanceamt, total, _unitprice, _totalreturnvalue;
        private long _yearsequenceno, _invoiceno, _saleid, _saleinv, _sale_det_id, _returninvoiceno;
        private object itemselectedval;

        public DateTime fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }

        public DateTime? expiry { get; set; }
        //public DateTime ?expiry
        //{
        //    get { return _expiry; }
        //    set { _expiry = value; }
        //}
        public DateTime todate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        public DateTime returndate
        {
            get { return _returndate; }
            set { _returndate = value; }
        }

        public DateTime Newexpr
        {
            get { return _Newexpr; }
            set { _Newexpr = value; }
        }
        public int clientno
        {
            get { return _clientno; }
            set { _clientno = value; }
        }
        public int mtb_updation
        {
            get { return _mtb_updation; }
            set { _mtb_updation = value; }
        }
        public long saledetid
        {
            get { return _sale_det_id; }
            set { _sale_det_id = value; }
        }

        public string serialno
        {
            get { return _serialno; }
            set { _serialno = value; }
        }
        public string paymentid
        {
            get { return _paymentid; }
            set { _paymentid = value; }
        }
        public string paydiscription
        {
            get { return _paydiscription; }
            set { _paydiscription = value; }
        }
        public string ClientName
        {
            get { return _client; }
            set { _client = value; }
        }
        public int itemno
        {
            get { return _itemno; }
            set { _itemno = value; }
        }
        public string ValidationString { get; set; }
        public string ItemName
        {
            get { return _item; }
            set { _item = value; }
        }
        public int Status
        {
            get { return _mtb_status; }
            set { _mtb_status = value; }
        }
        public int createdby
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        public int modifiedby
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }
        public long invoiceno
        {
            get { return _invoiceno; }
            set { _invoiceno = value; }
        }
        public long returninvoiceno
        {
            get { return _returninvoiceno; }
            set { _returninvoiceno = value; }
        }
        public string returnclient
        {
            get { return _returnclient; }
            set { _returnclient = value; }
        }
        public float balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public int returnquantity
        {
            get { return _returnquantity; }
            set { _returnquantity = value; }
        }
        public decimal totalreturnvalue
        {
            get { return _totalreturnvalue; }
            set { _totalreturnvalue = value; }
        }
        public float totalreturnquantity
        {
            get { return _totalreturnquantity; }
            set { _totalreturnquantity = value; }
        }
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int package
        {
            get { return _package; }
            set { _package = value; }
        }
        public long saleid
        {
            get { return _saleid; }
            set { _saleid = value; }
        }

        public long saleinv
        {
            get { return _saleinv; }
            set { _saleinv = value; }
        }
        public string accountid
        {
            get { return _accountid; }
            set { _accountid = value; }
        }

        public decimal unitprice
        {
            get { return _unitprice; }
            set { _unitprice = value; }
        }
        public int user
        {
            get { return _user; }
            set { _user = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string all
        {
            get { return _all; }
            set { _all = value; }
        }

        //Created on 2-1-2014

        public int BalanceAgent
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

        public DateTime SaleDate
        {
            get { return _saledate; }
            set { _saledate = value; }
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

        public decimal Balance
        {
            get { return _balanceamt; }
            set { _balanceamt = value; }
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

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public object ItemSelectedVal
        {
            get { return itemselectedval; }
            set { itemselectedval = value; }
        }

        public Boolean RadInvoiceCheked
        {
            get { return radinvoicecheked; }
            set { radinvoicecheked = value; }
        }

        public Boolean RadItemCheked
        {
            get { return raditemcheked; }
            set { raditemcheked = value; }
        }

        public int dgrSelectedRowCount
        {
            get { return rowcount; }
            set { rowcount = value; }
        }

        public string ReturnQtyText
        {
            get { return returnqtytext; }
            set { returnqtytext = value; }
        }

        public int SelectedRowQty
        {
            get { return selectedrowqty; }
            set { selectedrowqty = value; }
        }

        public string SeletedInvoice
        {
            get;
            set;
        }

        public string SeletedDetailID
        {
            get;
            set;
        }

        public string Time
        {
            get;
            set;
        }
        public string Returned
        {
            get;
            set;
        }

        public int CurrentYear
        {
            get { return _currentyear; }
            set { _currentyear = value; }
        }
        public decimal ItemPrice { get; set; }
        #endregion


        public string ItemNumber { get; set; }
        public int BarcodeID { get; set; }
        public bool QuickReturn { get; set; }
        public long PayReceiptNo { get; set; }
        public bool IsHide { get; set; }

    }

}
