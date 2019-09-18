using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.ViewHelper;

namespace BumedianBM.Interface
{
    public abstract class PurchaseViewAbstract
    {
        public static IPurchaseView GetPurchaseView(string viewType)
        {
            IPurchaseView purchaseView = null;
            switch (viewType)
            {
                case "PurchaseInvoice":
                   // purchaseView = new PurchaseInvoiceHelper();
                    break;
                case "tempo":
                 //   purchaseView = new PurchaseReturnInvoice();
                    break;
                case "Invoice1":
                   // purchaseView = new PurchaseInvoiceHelper();
                    break;
                case "tempo1":
                   // purchaseView = new PurchaseReturnInvoice();
                    break;
            }
            return purchaseView;
        }
    }
}
