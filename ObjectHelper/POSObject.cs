using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class POSObject
    {

        #region "Variable Declaration"
        private int _shortcut, _qty, _returnqty, _stockonhand, _orderno, _itemsno, _additionflag, _agentid, _accountid, _saletype, _itemtype,_createdby, _modifiedby, _batchid, _buttonId,_buttonitemId, _iteminsertionno;
        private string _itemname, _discription, _status, _itemid, _kitchenstatus, _notes, _isnote, _imgpath, _additionitemname;
        private byte[] _imgbyte;
        private DateTime _expdate, _saledate;
        private decimal _price, _netamount, _paymentCharges, _grossamount, _tax1, _tax2, _subTax1, _subTax2, _tax, _discount, _cost, _paidamount, _balance;
        // private float _balance;
        private byte _remove;
        private long _saleid;
        private int _paymentTypeId;
        #endregion

        #region "Properties"
        public string ItemName
        {
            get { return _itemname; }
            set { _itemname = value; }
        }
        public string AdditionItemName
        {
            get { return _additionitemname; }
            set { _additionitemname = value; }
        }
        public int ButtonId
        {
            get { return _buttonId; }
            set { _buttonId = value; }
        }
        public int ButtonItemId
        {
            get { return _buttonitemId; }
            set { _buttonitemId = value; }
        }
        public int ItemInsertionNo
        {
            get { return _iteminsertionno; }
            set { _iteminsertionno = value; }
        }
        public string ImagePath
        {
            get { return _imgpath; }
            set { _imgpath = value; }
        }
        public string Discription
        {
            get { return _discription; }
            set { _discription = value; }
        }
        public int AdditionFlag
        {
            get { return _additionflag; }
            set { _additionflag = value; }
        }
        public int SaleType
        {
            get { return _saletype; }
            set { _saletype = value; }
        }
        public int ItemType
        {
            get { return _itemtype; }
            set { _itemtype = value; }
        }
        public long SaleId
        {
            get { return _saleid; }
            set { _saleid = value; }
        }
        public int BatchId
        {
            get { return _batchid; }
            set { _batchid = value; }
        }
        public int AgentId
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        public int AccountId
        {
            get { return _accountid; }
            set { _accountid = value; }
        }
        public int CreatdBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        public int ModifiedBy
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }
        public string KitchenStatus
        {
            get { return _kitchenstatus; }
            set { _kitchenstatus = value; }
        }
      

        public int OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        public int ShortCut
        {
            get { return _shortcut; }
            set { _shortcut = value; }
        }
        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public int ReturnQty
        {
            get { return _returnqty; }
            set { _returnqty = value; }
        }
        public int ItemSno
        {
            get { return _itemsno; }
            set { _itemsno = value; }
        }
        public int StockOnHand
        {
            get { return _stockonhand; }
            set { _stockonhand = value; }
        }
        public DateTime SaleDate
        {
            get { return _saledate; }
            set { _saledate = value; }
        }
        public DateTime ExpiryDate
        {
            get { return _expdate; }
            set { _expdate = value; }
        }
        public Decimal Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        public Decimal Tax1
        {
            get { return _tax1; }
            set { _tax1 = value; }
        }
        public Decimal Tax2
        {
            get { return _tax2; }
            set { _tax2 = value; }
        }
        public Decimal SubTax1
        {
            get { return _subTax1; }
            set { _subTax1 = value; }
        }
        public Decimal SubTax2
        {
            get { return _subTax2; }
            set { _subTax2 = value; }
        }
        public Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Decimal GrossAmount
        {
            get { return _grossamount; }
            set { _grossamount = value; }
        }
        public Decimal NetAmount
        {
            get { return _netamount; }
            set { _netamount = value; }
        }
        public Decimal PaymentCharges
        {
            get { return _paymentCharges; }
            set { _paymentCharges = value; }
        }
        public Decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        public Decimal Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public Decimal PaidAmount
        {
            get { return _paidamount; }
            set { _paidamount = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public byte[] ImageByte
        {
            get { return _imgbyte; }
            set { _imgbyte = value; }
        }
        public byte Remove
        {
            get { return _remove; }
            set { _remove = value; }
        }
        public int PaymentTypeId
        {
            get { return _paymentTypeId; }
            set { _paymentTypeId = value; }
        }

        #region New Objects
        public int ShorcutSelectedIndex { get; set; }
        public int AdditionShorcutSelectedIndex { get; set; }
        public int ItemSelectedIndex { get; set; }
        public string AdditionDescText { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public int ShortcutFrom { get; set; }
        public int ShortcutTo { get; set; }
        public int ItemID { get; set; }
        public int ShortCutText { get; set; }
        public int AdditionShortCutText { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemTax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ItemPackagePrice { get; set; }
        public string TaxText { get; set; }
        public string TotalText { get; set; }
        public string GridBgColor { get; set; }
        public int CurrentQty { get; set; }
        public List<ItemCardObjectClass> lstSelectedItemDetails { get; set; }
        public string QtyText { get; set; }
        public int RowID { get; set; }
        public int ClientID { get; set; }
        public string PosDate { get; set; }
        public string RefundText { get; set; }
        public string PaidText { get; set; }
        public int GridRowCount { get; set; }
        public int GridCurrentRowIndex { get; set; }
        public int Year { get; set; }
        public long YearSequenceNo { get; set; }
        public string CategoryName { get; set; }
        public string NewInvoiceNoText { get; set; }
        public int ClientSelectedVal { get; set; }
        public bool BtnReceiptEnabled { get; set; }
        public bool DialogueResultOK { get; set; }
        public bool EnableButton { get; set; }
        public bool RegularItemFlag { get; set; }
        public bool DeleteItemFlag { get; set; }
        public bool QtyGreaterZero { get; set; }
        public string CmbClientText { get; set; }
        public int IsNotes { get; set; }
        public string Notes { get; set; }
        public bool ShowPricePopup { get; set; }
        #endregion



        #endregion


        public string Barcode { get; set; }

        public int CategoryId { get; set; }

        public int ItemplaceId { get; set; }

        public string ItemDescription { get; set; }

        public int Unit { get; set; }

        public int CompId { get; set; }

        public decimal ItemCost { get; set; }

        public decimal ItemLastCost { get; set; }

        public decimal ScannedPrice { get; set; }

        public int ScannedPackageQty { get; set; }

        public int ScannedQuantity { get; set; }

        public int Box { get; set; }

        public int Piece { get; set; }

        public int PackageQty { get; set; }

        public bool Expiry { get; set; }
        public decimal  AmountRecieved { get; set; }
        public int BalanceAgent { get; set; }
        public DateTime BalanceFromDate { get; set; }
        public DateTime  BalanceToDate { get; set; }
        public int BalanceStatus { get; set; }
        public int BarcodeID { get; set; }

        public int Activuser { get; set; }
    }
}
