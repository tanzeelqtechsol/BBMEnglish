using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using CommonHelper;
using System.Data;

namespace BALHelper
{
    public class ItemCardBALClass
    {
        #region Variable
        ItemCardDALClass ObjItemCardDALClass;
        public ItemCardObjectClass Objitemcardobjectclass = new ItemCardObjectClass();
        Dictionary<string, List<ItemCardObjectClass>> dictItemDetsBarcodeBAL = new Dictionary<string, List<ItemCardObjectClass>>();
       
        #endregion

        public ItemCardBALClass()
        {
            ObjItemCardDALClass = new ItemCardDALClass();
        }

        public int undoTrasaction()
        {
            return ObjItemCardDALClass.Undotransactiom();
        }
        public DataTable GetInvoice()
        {
            return ObjItemCardDALClass.getInvoideDetails();
        }
        public void connopen()
        {
            ObjItemCardDALClass.connopen();
        }
        public int savePurchase(ItemCardObjectClass objItemCardObjectClass)
        {
            return ObjItemCardDALClass.savePurchase(objItemCardObjectClass);
        }
        public int savePurchaseInvoceimport(ItemCardObjectClass objItemCardObjectClass)
        {
            return ObjItemCardDALClass.purchaseInvoceimport(objItemCardObjectClass);
        }
        public int saveItemcardimport(ItemCardObjectClass objItemCardObjectClass)
        {
            return ObjItemCardDALClass.itemcardimport(objItemCardObjectClass);
        }
        public Boolean SaveItemCard()
        {
            if (!ObjItemCardDALClass.Check_DuplicateItemName(Objitemcardobjectclass))
            {
                if (ObjItemCardDALClass.Save_ItemDetails(Objitemcardobjectclass) > 0)
                {
                    //if (!string.IsNullOrEmpty(Objitemcardobjectclass.Barcode))--------Commented on 17Mar2014(allow the without barcode item also save on barcode code table)
                  //  {
                        if (Objitemcardobjectclass.ItemId == 0)
                        {

                            DataTable GetMaxId = new DataTable();
                            GetMaxId = ObjItemCardDALClass.Get_MaxItemID();
                            if (GetMaxId.Rows.Count > 0)
                            {
                                Objitemcardobjectclass.ItemId = Convert.ToInt32(GetMaxId.Rows[0]["MaxItemId"]);
                                //Objitemcardobjectclass.OldBarcode = Objitemcardobjectclass.Barcode; Commented on 19march2014
                                
                            }
                        }
                        
                        ObjItemCardDALClass.Save_AdditionalBarcode(Objitemcardobjectclass);

                   // }
                    return true;
                }


            }
            else
            {
                GeneralFunction.Information (Constants.ITEMNO, "Item Card".ToString());

            }
            return false;
        }
       
        public List<ItemCardObjectClass> GetItemDetails()
        {

            Objitemcardobjectclass.NumberOfBarcode = ObjItemCardDALClass.Get_NumberOfBarcodeCount(Objitemcardobjectclass);
            return ObjItemCardDALClass.Get_ItemDetails(Objitemcardobjectclass);

        }
        public Dictionary<int, dynamic> GetExpiryItemDetail()
        {

          


            return ObjItemCardDALClass.Get_ExpiryItemDetails(Objitemcardobjectclass);
        }
       
        public Dictionary<string, List<ItemCardObjectClass>> GetLoadData()
        {


            return ObjItemCardDALClass.Get_LoadItemDetailsAll();
        }
        public DataSet GetAllItemDetails()
        {
            return StoredProcedurers.GetAllItems();
        }
        public DataTable GetAppliedIncreaseBal()
        {
            return ObjItemCardDALClass.GetAppliedIncrease(Objitemcardobjectclass);
        }
        public DataTable GetPriceCheckerData()
        {
            return ObjItemCardDALClass.GetPriceChecker(Objitemcardobjectclass);
        }
        public Boolean CheckDuplicateBarCode()
        {
            if (ObjItemCardDALClass.Check_DuplicateBarCode(Objitemcardobjectclass))
            {
                return true;

            }
            return false;

        }
      
        public List<ItemCardObjectClass> GetBarCodeDetail()
        { return ObjItemCardDALClass.Get_BarCodeDetails(Objitemcardobjectclass); }

     

        public Boolean SaveAdditionalBarCodeDetails()
        {
            if (ObjItemCardDALClass.Save_AdditionalBarcode(Objitemcardobjectclass) > 0)
            {
                return true;
            }


            return false;

        }
        public Boolean DeleteBarcodeDetails()
        {

            if (ObjItemCardDALClass.Delete_BarcodeDetails(Objitemcardobjectclass) > 0)
            {
                return true;
            }
            return false;
        }
        public Boolean DeleteItemDetails()
        {

            if (ObjItemCardDALClass.Delete_ItemDetails(Objitemcardobjectclass) > 0)
            {
                return true;
            }
            return false;
        }
        public Boolean CheckItemUnderInvoice()
        {

            if (ObjItemCardDALClass.Check_ItemUnderInvoice(Objitemcardobjectclass))
            {
                return true;
            }

            return false;
        }
     

        public Dictionary<string, List<ItemCardObjectClass>> GetLoadItem()
        {

            return ObjItemCardDALClass.getItemIDName();

        }

        public Dictionary<string, List<ItemCardObjectClass>> GetItemDetailsWithBarcodeBAL()
        {
            return ObjItemCardDALClass.GetItemDetailsWithBarcode(Objitemcardobjectclass);
        }
        public List<ItemCardObjectClass> GetBarcodeLogoBAL()
        {
            int itemid = Objitemcardobjectclass.ItemId;
            return ObjItemCardDALClass.GetBarcodeLogoDAL(itemid);
        }
        public DataTable GetInventoryList()
        {
            return ObjItemCardDALClass.InventoryListDetails();
        }
        public DataTable Get_GenerateBarcode()
        {

            return ObjItemCardDALClass.Get_GenerateBarcodeList();
        }
        public DataTable GetPrintItemList()
        {
            return ObjItemCardDALClass.Get_PrintItemList();
        }
        public DataTable GetItemStockHistory()
        {

            return ObjItemCardDALClass.Get_ItemInOutStockDetails(Objitemcardobjectclass);
        }
        public List<ItemCardObjectClass> DetailsOfUnitNameBarcode()
        {
            return ObjItemCardDALClass.Get_UnitNameBarcodeDetails(Objitemcardobjectclass);
        }
        
    }
}
