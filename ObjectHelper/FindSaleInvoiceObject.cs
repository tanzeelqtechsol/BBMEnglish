using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class FindSaleInvoiceObject
    {

        #region Fields

        private string _AgentName;
        // private decimal itemcost, itemlastcost, wholesaleprice, price, minprice;
        private DateTime _PaymentDate;
        // private int qty, reorder, maxorder;
        // private byte[] img;


        #endregion

        //    public string Category { get; set; }
        public string FirstName { get; set; }
        //public string UserId { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public int BalanceAgent { get; set; }
        public string BalanceStatus { get; set; }
        public decimal AmountRecieved { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceFromDate { get; set; }
        public DateTime BalanceToDate { get; set; }

        //   public string 


        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }

        public string AgentName
        {
            get { return _AgentName; }
            set { _AgentName = value; }

        }

        /// <summary>
        /// Created on 27-Jan-2014 
        /// </summary>
        #region OldObjects

        private DateTime _fromdate, _todate;
        private string   _typeinv, _fid, _user, _clientname;
        public Boolean _all;
        private int _clientid, _itemid;
        private long _saleinv;
        public DateTime fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }
        public Boolean all
        {
            get { return _all; }
            set { _all = value; }
        }
        public DateTime todate
        {
            get { return _todate; }
            set { _todate = value; }
        }
        public int clientid
        {
            get { return _clientid; }
            set { _clientid = value; }

        }
        public long saleinv
        {
            get { return _saleinv; }
            set { _saleinv = value; }
        }
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }
        public int itemid
        {
            get { return _itemid; }
            set { _itemid = value; }
        }
        public string typeinv
        {
            get { return _typeinv; }
            set { _typeinv = value; }
        }
        public string fid
        {
            get { return _fid; }
            set { _fid = value; }
        }



        public long InvoiceNo { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public int ReturnedQty { get; set; }
        public DateTime Time { get; set; }
        public int Status { get; set; }
        public long SaleID { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public decimal Paid { get; set; }
        public int InvoiceType { get; set; }
        public int InvoiceTypeTwo { get; set; }
        public Boolean ChkAllChecked { get; set; }
        public int InvoiceTypeSelectedIndex { get; set; }
        public string InvoiceTypeText { get; set; }
        public string InvoiceNoText { get; set; }
        public int UserSelectedIndex { get; set; }
        public int UserSelectedValue { get; set; }
        public string UserSelectedText { get; set; }
        public decimal SumOfTotalAmt { get; set; }
        public decimal SumOfNetAmt { get; set; }
        public decimal SumOfPaidAmt { get; set; }
        public decimal SumOfDiscountAmt { get; set; }
        public decimal RemainingAmt { get; set; }
        public int ClientSelectedIndex { get; set; }
        public int Year { get; set; }
        public long YearSequenceNo { get; set; }
        public string ItemDecsription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalCostAmt { get; set; }
        public decimal GrossAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string SerialNo { get; set; }
        public int PackageQty { get; set; }
        public long SaleDetailID { get; set; }
        public decimal Cost { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal TotalSale { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalProfit { get; set; }
        #endregion

        public int Remarks { get; set; }

        public string ItemNumber { get; set; }

        public string strExpiryDate { get; set; }

        public long OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public string NewYearSequenceNo { get; set; }
    }
}
