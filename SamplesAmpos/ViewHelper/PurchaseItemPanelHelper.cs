using BALHelper;
using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BumedianBM.ViewHelper
{
    public class PurchaseItemPanelHelper
    {
        public PurchaseItemPanelBAL ObjBALClass = new PurchaseItemPanelBAL();
        public bool ItemNotSave = false;

        public DataSet GetAllItems()
        {
            return ObjBALClass.GetAllItemDetails();
        }

        public Boolean SaveItemCardDetail()
        {
            if (!Validation())
            {
                if (ObjBALClass.SaveItemCard())
                {
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjBALClass.Objitemcardobjectclass.ItemName.ToString(), "Purchase Item Panel", "Save item details", Convert.ToInt32(InvoiceAction.No));
                    return true;
                }
                else
                {
                    ItemNotSave = true;
                }
            }
            else
            {
                ItemNotSave = true;
            }

            return false;
        }

        public Boolean Validation()
        {
            if (ObjBALClass.Objitemcardobjectclass.ItemName == string.Empty)
            {

                GeneralFunction.Information(Constants.ITEMNAME, ActionType.Save.ToString());
                return true;
            }

            return false;
        }

        public bool GetItemDetails()
        {
            List<PurchaseItemPanelObectClass> lstItemInfo = new List<PurchaseItemPanelObectClass>();
            lstItemInfo = ObjBALClass.GetItemDetails();
            if (lstItemInfo.Count > 0)
            {
                // var v = dictItemInfo;
                ObjBALClass.Objitemcardobjectclass.ItemID = lstItemInfo[0].ItemID;
                ObjBALClass.Objitemcardobjectclass.ItemType = lstItemInfo[0].ItemType;
                ObjBALClass.Objitemcardobjectclass.Barcode = lstItemInfo[0].Barcode;
                ObjBALClass.Objitemcardobjectclass.IsHide = lstItemInfo[0].IsHide;
                ObjBALClass.Objitemcardobjectclass.ItemName = lstItemInfo[0].ItemName;
                ObjBALClass.Objitemcardobjectclass.CategoryID = lstItemInfo[0].CategoryID;
                ObjBALClass.Objitemcardobjectclass.CompanyID = lstItemInfo[0].CompanyID;
                ObjBALClass.Objitemcardobjectclass.ItemCost = lstItemInfo[0].ItemCost;

                ObjBALClass.Objitemcardobjectclass.Reorder = lstItemInfo[0].Reorder;
                ObjBALClass.Objitemcardobjectclass.Maxorder = lstItemInfo[0].Maxorder;
                ObjBALClass.Objitemcardobjectclass.PackageQuantity = lstItemInfo[0].PackageQuantity;
                ObjBALClass.Objitemcardobjectclass.Price = lstItemInfo[0].Price;

                ObjBALClass.Objitemcardobjectclass.WholeSalePrice = lstItemInfo[0].WholeSalePrice;
                ObjBALClass.Objitemcardobjectclass.MinPrice = lstItemInfo[0].MinPrice;
                ObjBALClass.Objitemcardobjectclass.ItemPlaceId = lstItemInfo[0].ItemPlaceId;

                ObjBALClass.Objitemcardobjectclass.ExpiryDate = lstItemInfo[0].ExpiryDate;

                ObjBALClass.Objitemcardobjectclass.StockInHand = lstItemInfo[0].StockInHand;
                ObjBALClass.Objitemcardobjectclass.Image = lstItemInfo[0].Image;
                ObjBALClass.Objitemcardobjectclass.ImgPath = lstItemInfo[0].ImgPath;
                ObjBALClass.Objitemcardobjectclass.UnitNameID = lstItemInfo[0].UnitNameID;
                ObjBALClass.Objitemcardobjectclass.ItemLastCost = lstItemInfo[0].ItemLastCost;
                ObjBALClass.Objitemcardobjectclass.AverageCost = lstItemInfo[0].AverageCost;
                ObjBALClass.Objitemcardobjectclass.ItemNumber = lstItemInfo[0].ItemNumber;
                ObjBALClass.Objitemcardobjectclass.BarcodeID = lstItemInfo[0].BarcodeID;
                ObjBALClass.Objitemcardobjectclass.TotalStock = lstItemInfo[0].TotalStock; 
                return true;
            }

            return false;
        }

        public DataTable GetAppliedIncreaseHelper()
        {
            return ObjBALClass.GetAppliedIncreaseBal();
        }

    }
}
