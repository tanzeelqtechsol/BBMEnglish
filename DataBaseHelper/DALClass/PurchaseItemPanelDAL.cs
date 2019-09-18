using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseHelper.DALClass
{
    public class PurchaseItemPanelDAL
    {
        private const string CHECK_ITEM_NUMBER = "SP_Check_ItemNumber";
        private const string SAVE_ITEM_DETAILS = "SP_Save_ItemDetails";
        private const string GET_MAX_ITEMID = "SP_GetMaximumItemId";
        private const string SAVE_BARCODE_DETAILS = "SP_Save_Barcode";
        private const string GET_ITEM_DETAILS = "SP_Get_ItemNameInfo";

        public Boolean Check_DuplicateItemName(PurchaseItemPanelObectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemID);
                sqlparam[1] = new SqlParameter("@ItemName", ObjItemCard.ItemName);

                if (Convert.ToInt32((SQLHelper.Instance.GetScalar(CHECK_ITEM_NUMBER, sqlparam))) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Save_ItemDetails(PurchaseItemPanelObectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[21];

            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemID);
                sqlparam[1] = new SqlParameter("@ItemName", ObjItemCard.ItemName);
                sqlparam[2] = new SqlParameter("@CategoryId", ObjItemCard.CategoryID);
                sqlparam[3] = new SqlParameter("@ItemType", ObjItemCard.ItemType);
                sqlparam[4] = new SqlParameter("@ItemPlaceId", ObjItemCard.ItemPlaceId);
                sqlparam[5] = new SqlParameter("@ItemDescription", "product");
                sqlparam[6] = new SqlParameter("@ItemImage", ObjItemCard.Image);
                sqlparam[7] = new SqlParameter("@CompanyId", ObjItemCard.CompanyID);
                sqlparam[8] = new SqlParameter("@ItemCost", ObjItemCard.ItemCost);
                sqlparam[9] = new SqlParameter("@ItemLastCost", ObjItemCard.ItemLastCost);
                sqlparam[10] = new SqlParameter("@PacakageQty", ObjItemCard.PackageQuantity);
                sqlparam[11] = new SqlParameter("@ExpiryDate", ObjItemCard.ExpiryDate);
                sqlparam[12] = new SqlParameter("@Reorder", ObjItemCard.Reorder);
                sqlparam[13] = new SqlParameter("@MaxOrder", ObjItemCard.Maxorder);
                sqlparam[14] = new SqlParameter("@Averagecost", ObjItemCard.AverageCost);
                sqlparam[15] = new SqlParameter("@ImagePath", ObjItemCard.ImgPath);
                sqlparam[16] = new SqlParameter("@CreatedBy", ObjItemCard.CreatedBy);
                sqlparam[17] = new SqlParameter("@ModifiedBy", ObjItemCard.ModifiedBy);
                sqlparam[18] = new SqlParameter("@Status", ObjItemCard.Status);
                sqlparam[19] = new SqlParameter("@IsHide", ObjItemCard.IsHide);
                sqlparam[20] = new SqlParameter("@ItemNumber", ObjItemCard.ItemNumber);
                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_ITEM_DETAILS, sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_MaxItemID()
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[0];
            dt = SQLHelper.Instance.ExecuteQueryDatatable(GET_MAX_ITEMID, sqlparam, "Item");
            return dt;
        }

        public int Save_AdditionalBarcode(PurchaseItemPanelObectClass objItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            try
            {
                sqlparam[0] = new SqlParameter("@BarcodeID", objItemCard.BarcodeID);
                sqlparam[1] = new SqlParameter("@ItemID", objItemCard.ItemID);
                sqlparam[2] = new SqlParameter("@Barcode", objItemCard.Barcode.Trim());
                sqlparam[3] = new SqlParameter("@CreatedBy", objItemCard.CreatedBy);
                sqlparam[4] = new SqlParameter("@ModifiedBy", objItemCard.ModifiedBy);
                sqlparam[5] = new SqlParameter("@Status", objItemCard.Status);
                sqlparam[6] = new SqlParameter("@PackageQty", objItemCard.PackageQuantity);
                sqlparam[7] = new SqlParameter("@Price", objItemCard.Price);
                sqlparam[8] = new SqlParameter("@UnitNameID", objItemCard.UnitNameID);
                sqlparam[9] = new SqlParameter("@WholeSalePrice", objItemCard.WholeSalePrice);
                sqlparam[10] = new SqlParameter("@MinPrice", objItemCard.MinPrice);
                sqlparam[11] = new SqlParameter("@ItemCost", objItemCard.ItemCost);
                if (SQLHelper.Instance.ExecuteNonQuery(SAVE_BARCODE_DETAILS, sqlparam) > 0)
                    return 1;
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseItemPanelObectClass> Get_ItemDetails(PurchaseItemPanelObectClass objItemCard)
        {
            List<PurchaseItemPanelObectClass> lstItemInfo = new List<PurchaseItemPanelObectClass>();
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                DataTable dt = new DataTable();
                sqlparam[0] = new SqlParameter("@ItemID", objItemCard.ItemID);
                var result = SQLHelper.Instance.GetReader(GET_ITEM_DETAILS, sqlparam);

                if (result.Read())
                {
                    lstItemInfo.Add(new PurchaseItemPanelObectClass
                    {
                        ItemID = Convert.ToInt32(result["ItemID"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        Barcode = result["Barcode"].ToString(),
                        IsHide = Convert.ToBoolean(result["IsHide"]),
                        ItemName = result["ItemName"].ToString(),
                        CategoryID = Convert.ToInt32(result["CategoryID"]),
                        CompanyID = Convert.ToInt32(result["CompanyID"]),
                        Reorder = Convert.ToInt32(result["Reorder"]),
                        Maxorder = Convert.ToInt32(result["MaxOrder"]),
                        PackageQuantity = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                        Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0.0m : result["Price"]),
                        WholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0.0m : result["WholeSalePrice"]),
                        MinPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0.0m : result["MinPrice"]),
                        ItemPlaceId = Convert.ToInt32(result["ItemPlaceID"]),
                        ExpiryDate = Convert.ToBoolean(result["ExpiryDate"] == DBNull.Value ? false : result["ExpiryDate"]),
                        StockInHand = Convert.ToInt32(result["StockInHand"]),
                        Image = (byte[])(result["ItemImage"] == DBNull.Value ? null : result["ItemImage"]),
                        ImgPath = result["ImagePath"].ToString(),
                        ItemCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                        UnitNameID = Convert.ToInt32(result["UnitNameID"]),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"] == DBNull.Value ? 0.000m : result["ItemLastCost"]),
                        AverageCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0.0m : result["AverageCost"]),
                        ItemNumber = result["ItemNumber"].ToString(),
                        BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                        TotalStock = Convert.ToInt32(result["TotalStock"])  // This is added due to display total stock of all package qty
                    });

                }
                return lstItemInfo;

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close(); }
        }

        #region GetAppliedIncrease
        public DataTable GetAppliedIncrease(PurchaseItemPanelObectClass objItemCard)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", objItemCard.ItemType);
            param[1] = new SqlParameter("@CategoryID", objItemCard.CategoryID);
            param[2] = new SqlParameter("@CompanyID", objItemCard.CompanyID);
            param[3] = new SqlParameter("@ItemID", objItemCard.ItemID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }
        #endregion
    }
}
