using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class SaleInvoiceObjectClass : SaleObject
    {
        public int Description { get; set; }
        public DateTime Expiry { get; set; }
        public int Package { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime Time { get; set; }
        public string UserName { get; set; }
        public decimal Returned { get; set; }
        public int Agent { get; set; }
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public decimal Discount { get; set; }
        public long SerialNo { get; set; }
        public DateTime NewExpire { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal ItemTax { get; set; }
        public decimal ItemCost { get; set; }

    }
}
