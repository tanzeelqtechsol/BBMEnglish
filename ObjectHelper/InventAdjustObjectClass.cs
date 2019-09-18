using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
 public class InventAdjustObjectClass
 {

     #region Numeric
     public int ItemId { get; set; }
     public int CategoryId { get; set; }
     public int AgentId { get; set; }
     public int CompanyId { get; set; }
     public int ItemType { get; set; }
     public int ItemPlaceId { get; set; }
     public int Status { get; set; }
     public int Quantity { get; set; }
     public int Unit { get; set; }
     public int Reorder { get; set; }
     public int Maxorder { get; set; }
     public int StockInHand { get; set; }
     public int StockID { get; set; }
     public int Adjustment { get; set; }
     
     public int ModifiedQty { get; set; }
     public int QtyAdjust { get; set; }
     //public int TotalPurchase { get; set; }
     public int TotalSold { get; set; }
     public int Spoiled { get; set; }
     public int RowIndex { get; set; }
     public int CurrentYear { get; set; }
     
     #endregion

     #region String
     public string ItemName { get; set; }
     public string CategoryName { get; set; }
     public string CompanyName { get; set; }
     public string AgentName { get; set; }
     public string Barcode { get; set; }
     public string Description { get; set; }
     public string Notes { get; set; }
     public string Reason { get; set; }
     public string SupplierName { get; set; }
     public string Users { get; set; }
     public string Edit { get; set; }
     public string PlaceName { get; set; }
     public string BeforeTotalValue { get; set; }
     public string AfterTotalValue { get; set; }
     public string AdjustDifference { get; set; }
     public string StrExpiryDate { get; set; }
     public string SerialNo { get; set; }
     #endregion

     #region boolean
     public bool Expired { get; set; }
     #endregion

     #region Decimal
     public decimal Cost { get; set; }
     public decimal Price { get; set; }
     public decimal OldCost { get; set; }
     public decimal UnitPrice { get; set; }
     public decimal total { get; set; }
     public decimal ItemLastCost { get; set; }
     public decimal PackageQty { get; set; }
     public decimal WholeSalePrice { get; set; }
     public decimal AverageCost { get; set; }
     public decimal MinPrice { get; set; }
     public decimal AdjustDiffer { get; set; }
     public decimal BeforeAdjust { get; set; }
     #endregion

     #region Datetime
     public DateTime? ExpiryDate { get; set; }
     public DateTime ProcessDate { get; set; }
     public DateTime ProcessTime { get; set; }
     public DateTime Time { get; set; }
     public DateTime CreatedDate { get; set; }
     #endregion

     public decimal ModifiedCost { get; set; }

     public int CreatedBY { get; set; }

     public int TblID { get; set; }

     public string TextInventory { get; set; }

     public int GridID { get; set; }

     public long StockInvoiceNo { get; set; }

     public int InvNo { get; set; }

     public int BatchID { get; set; }

     public DateTime AdjustedDate { get; set; }

     public int Flag { get; set; }

     public int CurrentQty { get; set; }

     public decimal AfterAdjValue { get; set; }

     public decimal Original { get; set; }

     public DateTime ModifiedDate { get; set; }

     public int TotalPurchased { get; set; }

     public int NewYearNo { get; set; }
     public string ItemNumber { get; set; }

     public string Quantity1 { get; set; }
     public int IsHide  { get; set; }
 }
}
