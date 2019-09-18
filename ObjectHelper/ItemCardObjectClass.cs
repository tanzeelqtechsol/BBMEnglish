using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;


namespace ObjectHelper
{
   public class ItemCardObjectClass:EntityBase
    {
        #region Fields

       //private string itemid, item, olditemname, barcode, additionalbarcode, barcodeid, itemtypeid, itemcategoryid, itemcategoryname, itemplaceid, itemcompid, itemcompname, itemtype, itemtypedesc, itemdesc, unit, agentid, itemplacename, desc, expiry, status, imgpath, serialno;
       // private decimal itemcost, itemlastcost, wholesaleprice, price, minprice;
       // private DateTime createdon, modifiedon, expirydate;
       // private int qty, reorder, maxorder;
       // private byte[] img;

        private string itemSerialNo;
        #endregion

        #region String datatype property
      
       
        public string Items { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public string ItemPlaceName { get; set; }
        public string Barcode { get; set; }
     //   public string OldBarcode { get; set; }
        public string ItemDescription { get; set; }
        public int ItemType { get; set; }
        public string ImgPath { get; set; }
        public string ItemName { get; set; }
        public string Totalqty { get; set; }
        public byte[] Image { get; set; }
        public string ValidationString { get; set; }
      
        #endregion

        #region Datetime datatype property
        public  Boolean ExpiryDate { get; set; }
        public DateTime ?ItemExpiry{ get; set; }
        public int StockInHand { get; set; }

        #endregion

        #region Decimal datatype property
        public decimal ItemCost { get; set; }
        public decimal ItemLastCost { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal Price { get; set; }
        public decimal MinPrice { get; set; }
        public decimal AverageCost { get; set; }
        public decimal ProfitPrice { get; set; }

        #endregion

        #region Numeric datatype property

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string  ItemNumber { get; set; }
        public int ItemPlaceId { get; set; }
        public int Unit { get; set; }
        public int CompId { get; set; }
       // public int AgentId { get; set; }
        public int PackageQuantity { get; set; }
        public int Reorder { get; set; }
        public int Maxorder { get; set; }
        public Boolean IsHide { get; set; }
        public int BarcodeId { get; set; }
        public int ItemLastPurchase { get; set; }
        public int ItemTotalSpoiled { get; set; }
        public int BarcodeQty { get; set; }
        public int BarSelectedCount { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Id { get; set; }
        public int  UnitTypesID { get; set; }
        public int UnitNameID { get; set; }
        public string UnitTypes { get; set; }
        public string  UnitName { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int GeneralID { get; set; }
        public string  UnitQuantity { get; set; }
        //public int OldPackageQuantity { get; set; }
        //public decimal OldItemPrice { get; set; }
       // public int GeneralQuantity { get; set; }
        #endregion

        #region Boolean
        public bool BarcodeStatus { get; set; }
        #endregion

        #region DataImport
        public int PurchaseInvoiceId { get; set; }
        public int Year { get; set; }
        public int yearSequence { get; set; }
        public int PurchaseID { get; set; }
        public bool isForeignCurrency { get; set; }
        public string AgentName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ExreaCost { get; set; }
        public decimal GrassAmount { get; set; }

        #endregion

        public string flag { get; set; }

        public int pagesize { get; set; }

        public int columncount { get; set; }

        public string Totalpages { get; set; }

        public bool PriceFlag { get; set; }

        public bool BigPriceFlag { get; set; }

        public bool PrintLogoFlag { get; set; }
        public int NumberOfBarcode { get; set; }



        public int TotalStock { get; set; }
        public Boolean PrintPreviewChecked { get; set; }
    }
}
