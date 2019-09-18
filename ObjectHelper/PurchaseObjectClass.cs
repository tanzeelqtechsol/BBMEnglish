using System;
using CommonHelper;

namespace ObjectHelper
{
    public class PurchaseObjectClass : EntityBase
    {

        #region Purchase
        private string purchaseSupplierName, purchaseItemName, purchaseCategory, purchaseCompany, purchaseSerialNo;
        private decimal purchasePrice, purchaseMinimumPrice, purchaseUnitPrice, purchaseCost, purchaseTotal, purchaseNet, purchaseExtraCost, purchaseBalance, purchaseGrossAmt, purchaseTax, purchaseDiscount, purchaseSalePrice, purchasePurchaseCost;
        private int purchaseSupplierNo, purchaseItemNo, purchaseCategoryNo, purchaseCompanyNo, purchaseQuantity, purchaseStock, purchaseTotalStock, itemPackage, purchaseSetStatus, purchasePurchaseDetailsId, purchaseStatusNo, purchaseBatchNo, purchaseAccountNo, purchaseValue;
        private long purchaseInvoiceNo;
        private DateTime purchaseSetPaymentDate, purchaseDate, purchasePaymentDate, purchaseExpiryDate;
        private string purchasePrintPreview, purchaseShowDept, purchaseHideLogo;
        private string purchaseChkNote, purchaseNote, purchasePercentage;
        private string purchaseCreatedBy, purchaseModifiedBy, purchaseExpiry, purchaseBarcode, deleteStatus;
        private decimal tax, tax1, clientdiscount, totalpercentage, discount, purchaseextracost, eachitemextracost, balance, extracost, itemTax1, itemTax2, originaldisc;
        public decimal FlagTax1Percentage;
        public decimal FlagTax1SubPercentage;
        public decimal FlagTax2Percentage;
        public decimal FlagTax2SubPercentage;
        private decimal exchangeRate;

        private Boolean purchaseIncludeTax;

        public int Reorder { get; set; }
        public int PurchaseQuantity { get; set; }
        #region String Datatype Fields

        public int SupplierNo
        {
            get
            {
                return purchaseSupplierNo;
            }
            set
            {
                purchaseSupplierNo = value;
            }
        }
        public string SupplierName
        {
            get
            {
                return purchaseSupplierName;
            }
            set
            {
                purchaseSupplierName = value;
            }
        }
        public long InvoiceNo
        {
            get
            {
                return purchaseInvoiceNo;
            }
            set
            {
                purchaseInvoiceNo = value;
            }
        }
        public int ItemNo
        {
            get
            {
                return purchaseItemNo;
            }
            set
            {
                purchaseItemNo = value;
            }
        }
        public string ItemName
        {
            get
            {
                return purchaseItemName;
            }
            set
            {
                purchaseItemName = value;
            }
        }
        public int CategoryNo
        {
            get
            {
                return purchaseCategoryNo;
            }
            set
            {
                purchaseCategoryNo = value;
            }
        }
        public int CompanyNo
        {
            get
            {
                return purchaseCompanyNo;
            }
            set
            {
                purchaseCompanyNo = value;
            }
        }
        public string CategoryName
        {
            get
            {
                return purchaseCategory;
            }
            set
            {
                purchaseCategory = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return purchaseCompany;
            }
            set
            {
                purchaseCompany = value;
            }
        }
        //public DateTime? SetPaymentDate
        //{
        //    get
        //    {
        //        return purchaseSetPaymentDate;
        //    }
        //    set
        //    {
        //        purchaseSetPaymentDate =Convert.ToDateTime(value);
        //    }
        //}
        public string PrintPreview
        {
            get
            {
                return purchasePrintPreview;
            }
            set
            {
                purchasePrintPreview = value;
            }
        }
        public Boolean IncludeTax
        {
            get
            {
                return purchaseIncludeTax;
            }
            set
            {
                purchaseIncludeTax = value;
            }
        }
        public string ShowDept
        {
            get
            {
                return purchaseShowDept;
            }
            set
            {
                purchaseShowDept = value;
            }
        }
        public string HideLogo
        {
            get
            {
                return purchaseHideLogo;
            }
            set
            {
                purchaseHideLogo = value;
            }
        }

        public string Note
        {
            get
            {
                return purchaseNote;
            }
            set
            {
                purchaseNote = value;
            }
        }
        public int DiscountType
        {
            get
            {
                return purchaseValue;
            }
            set
            {
                purchaseValue = value;
            }
        }
        public string DiscountPercentage
        {
            get
            {
                return purchasePercentage;
            }
            set
            {
                purchasePercentage = value;
            }
        }

        public int AccountID
        {
            get
            {
                return purchaseAccountNo;
            }
            set
            {
                purchaseAccountNo = value;
            }
        }
        public int BatchID
        {
            get
            {
                return purchaseBatchNo;
            }
            set
            {
                purchaseBatchNo = value;
            }
        }
        public int Status
        {
            get
            {
                return purchaseStatusNo;
            }
            set
            {
                purchaseStatusNo = value;
            }
        }

        public string ItemExpiry
        {
            get
            {
                return purchaseExpiry;
            }
            set
            {
                purchaseExpiry = value;
            }
        }

        public string ItemBarcode
        {
            get
            {
                return purchaseBarcode;
            }
            set
            {
                purchaseBarcode = value;
            }
        }

        public string ItemSerialNo
        {
            get
            {
                return purchaseSerialNo;
            }
            set
            {
                purchaseSerialNo = value;
            }
        }
        public string deletestatus
        {
            get
            {
                return deleteStatus;
            }
            set
            {
                deleteStatus = value;
            }
        }

        #endregion

        #region Decimal Datatype Fields

        public decimal ItemPrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
            }
        }
        public decimal ItemMinimumPrice
        {
            get
            {
                return purchaseMinimumPrice;
            }
            set
            {
                purchaseMinimumPrice = value;
            }
        }
        public decimal Tax
        {
            get
            {
                return tax;
            }
            set
            {
                tax = value;
            }
        }
        public decimal Tax1
        {
            get
            {
                return tax1;
            }
            set
            {
                tax1 = value;
            }
        }
        public decimal ItemTax1
        {
            get
            {
                return itemTax1;
            }
            set
            {
                itemTax1 = value;
            }
        }
        public decimal ItemTax2
        {
            get
            {
                return itemTax2;
            }
            set
            {
                itemTax2 = value;
            }
        }

        public int PurchaseItemdDetail_ID
        {
            get
            {
                return purchasePurchaseDetailsId;
            }
            set
            {
                purchasePurchaseDetailsId = value;
            }
        }

        public decimal ItemUnitPrice
        {
            get
            {
                return purchaseUnitPrice;
            }
            set
            {
                purchaseUnitPrice = value;
            }
        }
        public decimal ItemCost
        {
            get
            {
                return purchaseCost;
            }
            set
            {
                purchaseCost = value;
            }
        }
        public decimal ItemExtraCost
        {
            get
            {
                return purchaseExtraCost;
            }
            set
            {
                purchaseExtraCost = value;
            }
        }
        public decimal ItemTotal
        {
            get
            {
                return purchaseTotal;
            }
            set
            {
                purchaseTotal = value;
            }
        }
        public decimal ItemNet
        {
            get
            {
                return purchaseNet;
            }
            set
            {
                purchaseNet = value;
            }
        }
        public decimal ItemBalance
        {
            get
            {
                return purchaseBalance;
            }
            set
            {
                purchaseBalance = value;
            }
        }
        public decimal ItemGrossAmt
        {
            get
            {
                return purchaseGrossAmt;
            }
            set
            {
                purchaseGrossAmt = value;
            }
        }
        public decimal ItemTax
        {
            get
            {
                return purchaseTax;
            }
            set
            {
                purchaseTax = value;
            }
        }
        public decimal ItemDiscount
        {
            get
            {
                return purchaseDiscount;
            }
            set
            {
                purchaseDiscount = value;
            }
        }
        public decimal SalePrice
        {
            get
            {
                return purchaseSalePrice;
            }
            set
            {
                purchaseSalePrice = value;
            }
        }
        public decimal PurchaseCost
        {
            get
            {
                return purchasePurchaseCost;
            }
            set
            {
                purchasePurchaseCost = value;
            }
        }
        public decimal ClientDiscount
        {
            get
            {
                return clientdiscount;
            }
            set
            {
                clientdiscount = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
        public decimal TotalPercentage
        {
            get
            {
                return totalpercentage;
            }
            set
            {
                totalpercentage = value;
            }
        }
        public decimal PurchaseExtraCost
        {
            get
            {
                return purchaseextracost;
            }
            set
            {
                purchaseextracost = value;
            }
        }
        public decimal EachItemExtraCost
        {
            get
            {
                return eachitemextracost;
            }
            set
            {
                eachitemextracost = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
        public decimal Extracost
        {
            get
            {
                return extracost;
            }
            set
            {
                extracost = value;
            }
        }
        public decimal originaldiscount
        {
            get
            {
                return originaldisc;
            }
            set
            {
                originaldisc = value;
            }
        }

        #endregion

        #region Integer Datatype Fields

        public int ItemQuantity
        {
            get
            {
                return purchaseQuantity;
            }
            set
            {
                purchaseQuantity = value;
            }
        }
        public int ItemStock
        {
            get
            {
                return purchaseStock;
            }
            set
            {
                purchaseStock = value;
            }
        }
        public int ItemTotalStock
        {
            get
            {
                return purchaseTotalStock;
            }
            set
            {
                purchaseTotalStock = value;
            }
        }
        public int ItemPackage
        {
            get
            {
                return itemPackage;
            }
            set
            {
                itemPackage = value;
            }
        }
        public int SetStatus
        {
            get
            {
                return purchaseSetStatus;
            }
            set
            {
                purchaseSetStatus = value;
            }
        }
        public int PurchaseDetailsId
        {
            get
            {
                return purchasePurchaseDetailsId;
            }
            set
            {
                purchasePurchaseDetailsId = value;
            }
        }

        #endregion

        #region DateTime Datatype Fields

        public DateTime? ItemExpiryDate { get; set; }
        //{
        //    get
        //    {
        //        return purchaseExpiryDate;
        //    }
        //    set
        //    {
        //        purchaseExpiryDate =Convert.ToDateTime(value).Date;
        //    }
        //}
        public DateTime? PurchaseItemDate
        {
            get
            {
                return purchaseDate;
            }
            set
            {
                purchaseDate = Convert.ToDateTime(value);
            }
        }

        public decimal  ExchangeRate
        {
            get
            {
                return exchangeRate;
            }
            set
            {
                exchangeRate = value;
            }
        }

        
        public DateTime? ItemPaymentDate
        {
            get
            {
                return purchasePaymentDate;
            }
            set
            {
                purchasePaymentDate = Convert.ToDateTime(value);
            }
        }


        #endregion

        #endregion

        public int MaxNo { get; set; }
        public int Minno { get; set; }
        public int PurchaseID { get; set; }
        public int NewYearInvoiceID { get; set; }
        public int ItemType { get; set; }
        public int ItemPlaceID { get; set; }
        public int Box { get; set; }
        public int BarcodeID { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemLastCost { get; set; }

        public bool ExpiryDate { get; set; }
        public bool SetPaymentDate { get; set; }

        public decimal ItemWholeSalePrice { get; set; }
        public int MaxOrder { get; set; }
        public bool IsHide { get; set; }
        public decimal AvgCost { get; set; }
        public int ReturnQty { get; set; }
        public decimal NewCost { get; set; }
        public int Year { get; set; }
        public Boolean CheckNote { get; set; }
        public string PlaceName { get; set; }
        public string InvoiceFlag { get; set; }

        public string User { get; set; }
        public int UserId { get; set; }
        #region Datetime
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public String Time { get; set; }
        #endregion

        #region PurhcaseReturn

        public long ReturnInvoiceID { get; set; }
        public long PurchaseReturnID { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Reason { get; set; }
        #endregion

        #region Order Invoice

        private DateTime? _orderDeliveryDate, _orderDate, _orderDemandDate, _Newexpr;
        private string _ordernote;
        private long _orderInvoiceNo;

        #region String Datatypes
        public int Remarks { get; set; }
        public long OrderID { get; set; }
        public long OrderInvoiceNo
        {
            get
            {
                return _orderInvoiceNo;
            }
            set
            {
                _orderInvoiceNo = value;
            }
        }
        public string OrderNote
        {
            get
            {
                return _ordernote;
            }
            set
            {
                _ordernote = value;
            }
        }

        #endregion

        #region Datetime Datatypes

        public DateTime? OrderDeliveryDate
        {
            get
            {
                return _orderDeliveryDate;
            }
            set
            {
                _orderDeliveryDate = value;
            }
        }
        public DateTime? Newexpr
        {
            get
            {
                return _Newexpr;
            }
            set
            {
                _Newexpr = value;
            }
        }
        public DateTime? OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }
        public DateTime? OrderDemandDate
        {
            get
            {
                return _orderDemandDate;
            }
            set
            {
                _orderDemandDate = value;
            }
        }

        #endregion
        public int SaleID { get; set; }
        #endregion

        public Decimal Paid { get; set; }
        public Decimal Remaining { get; set; }
        public DateTime? ProcessDate { get; set; }

        public DateTime? FromTime { get; set; }

        public DateTime? ToTime { get; set; }
        public String UnitType { get; set; }
        public String UnitName { get; set; }
        public int UnitTypeID { get; set; }
        public string ItemNumber { get; set; }
        public Decimal ItemCardItemCost { get; set; }
        public int ItemCardPackageQty { get; set; }

        public decimal ItemTax1SubAmount { get; set; }
        public decimal ItemTax2SubAmount { get; set; }
        public decimal ActualUnitPrice { get; set; }
        public decimal ItemTotalAmount { get; set; }
        public int StockID { get; set; }
        public int TotalStock { get; set; }
        public int TotalPackageCount { get; set; }

        public string InNo { get; set; }
    }
}
