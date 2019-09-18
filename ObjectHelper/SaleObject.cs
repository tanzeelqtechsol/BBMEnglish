using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public class SaleObject : EntityBase
    {

        #region Variables

        private int _usergroid;

        #endregion

        #region String datatype property


        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }


        #endregion

        #region Numeric datatype property

        public int ClientIds { get; set; }
        public int ItemsId { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int Value { get; set; }
        public int SalesId { get; set; }
        public int SaleInvoice { get; set; }
        public int ClosedCount { get; set; }
        public string AgentType { get; set; }
        public string NetText { get; set; }
        public string TotalText { get; set; }
        
        public string DiscountText { get; set; }
        public Boolean PercentageChecked { get; set; }
        public Boolean ValueChecked { get; set; }
        public Boolean IncludeTaxChecked { get; set; }
        public Boolean PrintPreviewChecked { get; set; }
        public string ItemNumber { get; set; }
        public string PackageQtyText { get; set; }
        public string StrItemNo { get; set; }
        public string StrExpiryDate { get; set; }
        public int StockAll { get; set; }
        public int UserGroupID
        {
            get { return _usergroid; }
            set { _usergroid = value; }
        }

        public int BarcodeID { get; set; }
        public int PackageQuantity { get; set; }
        public decimal PackagePrice { get; set; }
        public decimal ItemDiscounts { get; set; }
        public decimal itemunitdiscount { get; set; }
        public decimal itemunitprice { get; set; }
        public decimal ActualUnitPrice { get; set; }
        public decimal SubTax1 { get; set; }
        public decimal SubTax2 { get; set; }
        public decimal ItemTax2 { get; set; }
        public decimal TotalAmount { get; set; }
        #endregion

        // public List<SaleObject> lstItemForCategory;


        private string _activeusertext, _clientselectedtext, _newinvoiceno, _flag, _remainingtext, _pricetext, _colorval, _serialselectedtext, _packagetext, _qtytext, _itemselectedtext, _itembarcode, _itemname, _clientname, _categoy, _company, _user, _commonid, _commonsaleid, _salecloseid, _receive_receiptid, _receiptdiscription, _receiptnote, _itemexpname, _secondhand, _agentdiscount, _branch, _newyearinvno, _note, _receiptdescriptionarabic, _serialno;
        private double _stock, _discount, _gross, _itemcost, _totalpercentage, _itempercentage, _itemdiscount, _itemtotal;
        private int _mtbreceiptfor, _receive_paymentmethod, _dgrrowcount, _clientselectedindex, _currentyear, _year, _serialnocount, _expirycount, _serialnoitemselectedindex, _clientnoitemselectedindex, _itemselectedindex, _saletype, _box, _returnqty, _includetax, _createdby, _modifiedby, _discounttype, _status, _accountid, _categoryno, _quantity, _companyno, _itemid, _package, _commonvalue, _id, _totalstock, _itemstock, _expirqty, _exprreturn, _serialstock, _performavalue, _performaexpiryvalue, _performaserialvalue, _expstock, _serialstockcon, _itemPackage, _Itemallstock, PaymentTypeID;
        private DateTime _expiryselectedval, _expiry, _invoicetime, _receive_receiptdate, _newexpr;
        private decimal _receive_amtreceived, _sumofsubtotal, _actualprice, _purchaseUnitPrice, _purchaseCost, _debtlimit, _netamount, _price, _balance, _totalcost, _subtotal, _sumoftotal;
        public Boolean _nonstockitem, _expitem, _nonstocklabourmeal;
        private Int32 _clientid, _activuser, _batchid;
        private long _maxsaleid, _saleid, _saleinv, _saledetid, _invoicenotext, _yearsequenceno;
        private object _itemselectedvalue, _clientnoselectedval;
        private ConsoleColor _grdbagroundcolor;
        private bool _ispackage, _itmnovisible, _serialnovisible, _dtpdatevisible;

        #region Tax
        public decimal _tax1, _tax, _tax1sub, _taxsub, _net, _total, _paymentCharges, _taxofitem, _actualdiscount;

        #endregion

        #region New Properties




        public int CurrentYear
        {
            get { return _currentyear; }
            set { _currentyear = value; }
        }

        public int itemid
        {
            get { return _itemid; }
            set { _itemid = value; }

        }
        public int includetax
        {
            get { return _includetax; }
            set { _includetax = value; }

        }
        public string note
        {
            get { return _note; }
            set { _note = value; }

        }

        public string NewYearInvoiceNo
        {
            get { return _newinvoiceno; }
            set { _newinvoiceno = value; }

        }

        public decimal net
        {
            get { return _net; }
            set { _net = value; }

        }
        public decimal actualdiscount
        {
            get { return _actualdiscount; }
            set { _actualdiscount = value; }

        }
        public int discounttype
        {
            get { return _discounttype; }
            set { _discounttype = value; }

        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }

        }

        public long YearSequenceNo
        {
            get { return _yearsequenceno; }
            set { _yearsequenceno = value; }

        }

        public decimal total
        {
            get { return _total; }
            set { _total = value; }
        }
        public decimal paymentCharges
        {
            get { return _paymentCharges; }
            set { _paymentCharges = value; }
        }
        public decimal tax1
        {
            get { return _tax1; }
            set { _tax1 = value; }

        }
        public decimal taxofitem
        {
            get { return _taxofitem; }
            set { _taxofitem = value; }

        }
        public decimal tax1sub
        {
            get { return _tax1sub; }
            set { _tax1sub = value; }

        }
        public decimal taxsub
        {
            get { return _taxsub; }
            set { _taxsub = value; }

        }
        public string branch
        {
            get { return _branch; }
            set { _branch = value; }

        }
        public string agentdiscount
        {
            get { return _agentdiscount; }
            set { _agentdiscount = value; }

        }
        public string serialno //Changed into string
        {
            get { return _serialno; }
            set { _serialno = value; }

        }
        public int serialstock
        {
            get { return _serialstock; }
            set { _serialstock = value; }

        }
        public int performaserialvalue
        {
            get { return _performaserialvalue; }
            set { _performaserialvalue = value; }

        }
        public int performaexpiryvalue
        {
            get { return _performaexpiryvalue; }
            set { _performaexpiryvalue = value; }

        }
        public int expstock
        {
            get { return _expstock; }
            set { _expstock = value; }

        }
        public int serialstockcon
        {
            get { return _serialstockcon; }
            set { _serialstockcon = value; }

        }
        public string secondhand
        {
            get { return _secondhand; }
            set { _secondhand = value; }

        }
        public string itemexpname
        {
            get { return _itemexpname; }
            set { _itemexpname = value; }

        }
        public string receiptdiscription
        {
            get { return _receiptdiscription; }
            set { _receiptdiscription = value; }

        }
        public string receiptdiscriptionarabic
        {
            get { return _receiptdescriptionarabic; }
            set { _receiptdescriptionarabic = value; }

        }
        public string receiptnote
        {
            get { return _receiptnote; }
            set { _receiptnote = value; }

        }
        public int mtbreceiptfor
        {
            get { return _mtbreceiptfor; }
            set { _mtbreceiptfor = value; }

        }

        public string receive_receiptid
        {
            get { return _receive_receiptid; }
            set { _receive_receiptid = value; }
        }
        public int receive_paymenttypeID
        {
            get { return PaymentTypeID; }
            set { PaymentTypeID = value; }
        }
        public int receive_paymentmethod
        {
            get { return _receive_paymentmethod; }
            set { _receive_paymentmethod = value; }
        }
        public DateTime receive_receiptdate
        {
            get { return _receive_receiptdate; }
            set { _receive_receiptdate = value; }
        }
        public DateTime Newexpr
        {
            get { return _newexpr; }
            set { _newexpr = value; }
        }
        public decimal receive_amtreceived
        {
            get { return _receive_amtreceived; }
            set { _receive_amtreceived = value; }
        }
        public double totalpercentage
        {
            get { return _totalpercentage; }
            set { _totalpercentage = value; }
        }
        public double itempercentage
        {
            get { return _itempercentage; }
            set { _itempercentage = value; }
        }
        public double itemdiscount
        {
            get { return _itemdiscount; }
            set { _itemdiscount = value; }
        }

        public double itemtotal
        {
            get { return _itemtotal; }
            set { _itemtotal = value; }
        }
        public string salecloseid
        {
            get { return _salecloseid; }
            set { _salecloseid = value; }

        }
        public string itemname
        {
            get { return _itemname; }
            set { _itemname = value; }

        }
        public Int32 ClientID
        {
            get { return _clientid; }
            set { _clientid = value; }

        }
        public string clientname
        {
            get { return _clientname; }
            set { _clientname = value; }

        }
        public string commonsaleid
        {
            get { return _commonsaleid; }
            set { _commonsaleid = value; }

        }
        public string category
        {
            get { return _categoy; }
            set { _categoy = value; }

        }
        public string company
        {
            get { return _company; }
            set { _company = value; }

        }
        public string user
        {
            get { return _user; }
            set { _user = value; }

        }
        public double stock
        {
            get { return _stock; }
            set { _stock = value; }

        }
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }

        }
        public decimal price
        {
            get { return _price; }
            set { _price = value; }

        }
        public decimal TotalPrice { get; set; }

        public int package
        {
            get { return _package; }
            set { _package = value; }

        }
        public int exprreturn
        {
            get { return _exprreturn; }
            set { _exprreturn = value; }

        }
        public int expirqty
        {
            get { return _expirqty; }
            set { _expirqty = value; }

        }
        public int itemstock
        {
            get { return _itemstock; }
            set { _itemstock = value; }

        }
        public int performavalue
        {
            get { return _performavalue; }
            set { _performavalue = value; }

        }
        public DateTime expiry
        {
            get { return _expiry; }
            set { _expiry = value; }

        }
        public DateTime invoicetime
        {
            get { return _invoicetime; }
            set { _invoicetime = value; }

        }
        public long saleid
        {
            get { return _saleid; }
            set { _saleid = value; }

        }
        public long maxsaleid
        {
            get { return _maxsaleid; }
            set { _maxsaleid = value; }

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
        public Int32 batchid
        {

            get { return _batchid; }
            set { _batchid = value; }

        }
        public double discount
        {
            get { return _discount; }
            set { _discount = value; }

        }
        public decimal ActualPrice
        {
            get { return _actualprice; }
            set { _actualprice = value; }

        }
        public int accountid
        {
            get { return _accountid; }
            set { _accountid = value; }


        }
        public long saleinv
        {
            get { return _saleinv; }
            set { _saleinv = value; }

        }
        public long InvoiceNumber
        {
            get { return _saleinv; }
            set { _saleinv = value; }

        }
        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public decimal tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        public double gross
        {
            get { return _gross; }
            set { _gross = value; }
        }
        public decimal netamount
        {
            get { return _netamount; }
            set { _netamount = value; }
        }
        public double itemcost
        {
            get { return _itemcost; }
            set { _itemcost = value; }
        }
        public long saledetid
        {
            get { return _saledetid; }
            set { _saledetid = value; }
        }
        public Boolean nonstockitem
        {
            get { return _nonstockitem; }
            set { _nonstockitem = value; }
        }
        public Boolean expitem
        {
            get { return _expitem; }
            set { _expitem = value; }

        }
        public Boolean nonstocklabourmeal
        {
            get { return _nonstocklabourmeal; }
            set { _nonstocklabourmeal = value; }

        }


        public int commonvalue
        {
            get { return _commonvalue; }
            set { _commonvalue = value; }
        }
        public int totalstock
        {
            get { return _totalstock; }
            set { _totalstock = value; }
        }
        public string commonid
        {
            get { return _commonid; }
            set { _commonid = value; }

        }
        public int status
        {
            get { return _status; }
            set { _status = value; }

        }
        public int id
        {
            get { return _id; }
            set { _id = value; }

        }
        public string newyearinvno
        {
            get { return _newyearinvno; }
            set { _newyearinvno = value; }

        }
        #endregion


        /// <summary>
        /// Created on 11-12-2013
        /// </summary>
        /// 

        public bool CmbItemNoVisible
        {
            get { return _itmnovisible; }
            set { _itmnovisible = value; }
        }

        public bool CmbSerialNoNoVisible
        {
            get { return _serialnovisible; }
            set { _serialnovisible = value; }
        }

        public bool DtpExpiryVisible
        {
            get { return _dtpdatevisible; }
            set { _dtpdatevisible = value; }
        }

        public string DgrBgColorValue
        {
            get { return _colorval; }
            set { _colorval = value; }
        }

        public string Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public int DtpExpiryCount
        {
            get { return _expirycount; }
            set { _expirycount = value; }
        }


        public DateTime ExpirySelectedVal
        {
            get { return _expiryselectedval; }
            set { _expiryselectedval = value; }
        }

        public long InvoiceNoText
        {
            get { return _invoicenotext; }
            set { _invoicenotext = value; }
        }

        public string PriceText
        {
            get { return _pricetext; }
            set { _pricetext = value; }
        }

        public bool IsPackage
        {
            get { return _ispackage; }
            set { _ispackage = value; }
        }

        public object ItemSelectedValue
        {
            get { return _itemselectedvalue; }
            set { _itemselectedvalue = value; }
        }

        public object ClientNoSelectedValue
        {
            get { return _clientnoselectedval; }
            set { _clientnoselectedval = value; }
        }

        public int ClientNoSelectedIndex
        {
            get { return _clientnoitemselectedindex; }
            set { _clientnoitemselectedindex = value; }
        }

        public int ClientSelectedIndex
        {
            get { return _clientselectedindex; }
            set { _clientselectedindex = value; }
        }

        public int DgrRowCount
        {
            get { return _dgrrowcount; }
            set { _dgrrowcount = value; }
        }

        public string ClientNoSelectedText
        {
            get { return _clientselectedtext; }
            set { _clientselectedtext = value; }
        }

        public string ActiveUserText
        {
            get { return _activeusertext; }
            set { _activeusertext = value; }
        }

        public int SerialNoSelectedIndex
        {
            get { return _serialnoitemselectedindex; }
            set { _serialnoitemselectedindex = value; }
        }

        public int SerialNoCount
        {
            get { return _serialnocount; }
            set { _serialnocount = value; }
        }

        public string SerialNoSelectedText
        {
            get { return _serialselectedtext; }
            set { _serialselectedtext = value; }
        }

        public string ItemSelectedText
        {
            get { return _itemselectedtext; }
            set { _itemselectedtext = value; }
        }

        public string QtyText
        {
            get { return _qtytext; }
            set { _qtytext = value; }
        }

        public string PackageText
        {
            get { return _packagetext; }
            set { _packagetext = value; }
        }

        public string RemainingText
        {
            get { return _remainingtext; }
            set { _remainingtext = value; }
        }


        public int ItemSelectedIndex
        {
            get { return _itemselectedindex; }
            set { _itemselectedindex = value; }
        }

        public int SaleType
        {
            get { return _saletype; }
            set { _saletype = value; }
        }

        public int Box
        {
            get { return _box; }
            set { _box = value; }
        }

        public decimal Totalcost
        {
            get { return _totalcost; }
            set { _totalcost = value; }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        public decimal SumOfTotal
        {
            get { return _sumoftotal; }
            set { _sumoftotal = value; }
        }

        public decimal SumOfSubTotal
        {
            get { return _sumofsubtotal; }
            set { _sumofsubtotal = value; }
        }

        public int ReturnQty
        {
            get { return _returnqty; }
            set { _returnqty = value; }
        }

        public int ItemNo
        {
            get
            {
                return _itemid;
            }
            set
            {
                _itemid = value;
            }
        }

        public string ItemBarcode
        {
            get
            {
                return _itembarcode;
            }
            set
            {
                _itembarcode = value;
            }
        }

        public int CategoryNo
        {
            get
            {
                return _categoryno;
            }
            set
            {
                _categoryno = value;
            }
        }
        public int CompanyNo
        {
            get
            {
                return _companyno;
            }
            set
            {
                _companyno = value;
            }
        }

        public int ItemType { get; set; }

        public int ItemPlaceID { get; set; }
        public int CmbItemNo { get; set; }
        public int Unit { get; set; }

        public string ItemDescription { get; set; }
        public string ItemPlaceName { get; set; }
        public string AgentName { get; set; }
        public string CmbClientText { get; set; }
        public string ItemAdditionalBarcode { get; set; }
        public string StrModifiedDate { get; set; }

        public decimal unitprice
        {
            get
            {
                return _purchaseUnitPrice;
            }
            set
            {
                _purchaseUnitPrice = value;
            }
        }

        public decimal ItemCostPer
        {
            get
            {
                return _purchaseCost;
            }
            set
            {
                _purchaseCost = value;
            }
        }

        public decimal ItemLastCost { get; set; }

        public int ItemPackage
        {
            get
            {
                return _itemPackage;
            }
            set
            {
                _itemPackage = value;
            }
        }

        public int ItemAllExpiryTotalStock
        {
            get
            {
                return _Itemallstock;
            }
            set
            {
                _Itemallstock = value;
            }
        }


        public string SerialNo
        {
            get { return _serialno; }
            set { _serialno = value; }
        }



        public decimal DebtLimit
        {
            get { return _debtlimit; }
            set { _debtlimit = value; }
        }



        public int Activuser
        {
            get { return _activuser; }
            set { _activuser = value; }
        }



        public float BoxPrice { get; set; }
        public bool ExpiryDate { get; set; }
        public bool HasExpiry { get; set; }
        public int ItemTotalStock { get; set; }
        public int Reorder { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemMinimumPrice { get; set; }
        public decimal AvgCost { get; set; }
        public bool IsHide { get; set; }
        public int MaxOrder { get; set; }
        public DateTime ItemExpiryDate { get; set; }
        public decimal ItemWholeSalePrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string RtxtNotes { get; set; }
        public string StockText { get; set; }
        public string BoxText { get; set; }
        public string InvoiceText { get; set; }
        public string NewYrInvoiceText { get; set; }
        public long OrderInvoiceNo { get; set; }
        public int SupplierNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public decimal ItemDiscount { get; set; }
        public int InvoiceType { get; set; }
        public DateTime OrderDemandDate { get; set; }
        public int SetStatus { get; set; }
        public decimal OriginalDiscount { get; set; }
        public decimal ItemDiscountOne { get; set; }
        public string SupplierName { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public DateTime DtpDate { get; set; }
        public DateTime DtpPerformDate { get; set; }
        public decimal TotalOne { get; set; }
        public decimal CostPrice { get; set; }
        public string NotesText { get; set; }
        public string ExpiryDateText { get; set; }
        public bool SaveFlag { get; set; }
        public bool ChkNoteChecked { get; set; }
        public bool HideLogChecked { get; set; }
        public bool HideDebtChecked { get; set; }

        public int GrdSelectedRowCount { get; set; }
        public int GrdSelectedItemID { get; set; }
        public DateTime GrdSelectedDemandDate { get; set; }
        public int OrderNo { get; set; }
        //public string DiscountText { get; set; }
        public string UnitType { get; set; }

        public string UnitName { get; set; }
        public decimal ItemCost { get; set; }

        public int ItemQuantity { get; set; }

        public DateTime ItemExpiry { get; set; }
        public int Select { get; set; }
        public long StockID { get; set; }
        public int BalanceAgent { get; set; }
        public DateTime BalanceFromDate { get; set; }
        public DateTime BalanceToDate { get; set; }
        public int BalanceStatus { get; set; }
        public decimal AmountRecieved { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ActualPackageprice { get; set; }//Added on 28-Oct-2014
        public string strItemExpiry { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }

        //13-Dec-2018
        public decimal netAmountPaymentcharges { get; set; }

        //08-Feb-2019
        public int PaymentMethodID { get; set; }
        public int ButtonClick { get; set; }
    }
}

