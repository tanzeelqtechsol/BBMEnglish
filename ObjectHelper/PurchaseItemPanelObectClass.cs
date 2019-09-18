using CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class PurchaseItemPanelObectClass : EntityBase
    {
        // Item Properties
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int ItemType { get; set; }
        public int ItemPlaceId { get; set; }
        public byte[] Image { get; set; }
        public int CompanyID { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemLastCost { get; set; }
        public int PackageQuantity { get; set; }
        public Boolean ExpiryDate { get; set; }
        public int Reorder { get; set; }
        public int Maxorder { get; set; }
        public decimal AverageCost { get; set; }
        public string ImgPath { get; set; }
        public Boolean IsHide { get; set; }
        public string ItemNumber { get; set; }

        public int BarcodeID { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public int UnitNameID { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal MinPrice { get; set; }
        public int StockInHand { get; set; }
        public int TotalStock { get; set; }

    }
}
