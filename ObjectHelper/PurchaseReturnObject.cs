using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class PurchaseReturnObject
    {
        #region Private Variables
        private int returnInvoiceNo, _NewYearInvoiceNo, _ItemID, _PackageQty, _Quantity, _Serialno, _PurchaseInvoiceID, _AccountID, _Status, _StockInHand, _PurchaseID;
        private DateTime _ReturnDate, _ExpiryDate;
        private decimal _UnitPrice, _Total, _NewCost;
        private string _FirstName, _AgentName;
        private long _PurchaseReturnID;
        #endregion

        #region int variables
        public int ReturnInvoiceNo
        {
            get
            {
                return returnInvoiceNo;
            }
            set
            {
                returnInvoiceNo = value;
            }
        }
        public long PurchaseReturnID
        {
            get
            {
                return _PurchaseReturnID;
            }
            set
            {
                _PurchaseReturnID = value;
            }
        }
        public int NewYearInvoiceNo
        {
            get
            {
                return _NewYearInvoiceNo;
            }
            set
            {
                _NewYearInvoiceNo = value;
            }
        }
        public int ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                _ItemID = value;
            }
        }
        public int PackageQty
        {
            get
            {
                return _PackageQty;
            }
            set
            {
                _PackageQty = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }
        public int Serialno
        {
            get
            {
                return _Serialno;
            }
            set
            {
                _Serialno = value;
            }
        }
        public int PurchaseInvoiceID
        {
            get
            {
                return _PurchaseInvoiceID;
            }
            set
            {
                _PurchaseInvoiceID = value;
            }
        }
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
            }
        }
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public int StockInHand
        {
            get
            {
                return _StockInHand;
            }
            set
            {
                _StockInHand = value;
            }
        }
        public int PurchaseID
        {
            get
            {
                return _PurchaseID;
            }
            set
            {
                _PurchaseID = value;
            }
        }
        #endregion

        #region Datetime
        public DateTime ReturnDate
        {
            get
            {
                return _ReturnDate;
            }
            set
            {
                _ReturnDate = value;
            }
        }
        public DateTime ExpiryDate
        {
            get
            {
                return _ExpiryDate;
            }
            set
            {
                _ExpiryDate = value;
            }

        }
        #endregion

        #region Decimal Variables
        public Decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
            }
        }
        public Decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }
        public Decimal NewCost
        {
            get
            {
                return _NewCost;
            }
            set
            {
                _NewCost = value;
            }
        }
        #endregion

        #region String variables
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public string AgentName
        {
            get
            {
                return _AgentName;
            }
            set
            {
                _AgentName = value;
            }
        }

        #endregion




    }
}
