using CommonHelper;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BALHelper
{
    public class PurchaseItemPanelBAL
    {
        #region Variables
        PurchaseItemPanelDAL ObjDALClass;
        public PurchaseItemPanelObectClass Objitemcardobjectclass = new PurchaseItemPanelObectClass();
        #endregion

        public PurchaseItemPanelBAL()
        {
            ObjDALClass = new PurchaseItemPanelDAL();
        }
        public DataSet GetAllItemDetails()
        {
            return StoredProcedurers.GetAllItems();
        }

        public Boolean SaveItemCard()
        {
            if (!ObjDALClass.Check_DuplicateItemName(Objitemcardobjectclass))
            {
                if (ObjDALClass.Save_ItemDetails(Objitemcardobjectclass) > 0)
                {
                    if (Objitemcardobjectclass.ItemID == 0)
                    {

                        DataTable GetMaxId = new DataTable();
                        GetMaxId = ObjDALClass.Get_MaxItemID();
                        if (GetMaxId.Rows.Count > 0)
                        {
                            Objitemcardobjectclass.ItemID = Convert.ToInt32(GetMaxId.Rows[0]["MaxItemId"]);
                        }
                    }

                    ObjDALClass.Save_AdditionalBarcode(Objitemcardobjectclass);
                    return true;
                }


            }
            else
            {
                GeneralFunction.Information(Constants.ITEMNO, "Item Card".ToString());

            }
            return false;
        }

        public List<PurchaseItemPanelObectClass> GetItemDetails()
        {

            //Objitemcardobjectclass.NumberOfBarcode = ObjDALClass.Get_NumberOfBarcodeCount(Objitemcardobjectclass);
            return ObjDALClass.Get_ItemDetails(Objitemcardobjectclass);

        }
        public DataTable GetAppliedIncreaseBal()
        {
            return ObjDALClass.GetAppliedIncrease(Objitemcardobjectclass);
        }
    }
}
