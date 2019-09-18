using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BumedianBM.Interface
{
    public interface IPurchaseView
    {
        void CloseInvoice();
        void LoadItemInfo();
        void NewInvoiceNo();
        void FillDetails();
        void FillDetails(string tes);
        void Checkformoreexpiry();
        void Discount_adjust1();
        void LoadPurchaseInvoice();

       // void CloseInvoice();
    }
}
