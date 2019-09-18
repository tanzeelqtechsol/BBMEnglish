using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ObjectHelper;
using System.Data;

namespace DataBaseHelper.DALClass
{

    public class ItemCardDALClass
    {


        private const string CHECK_ITEM_NUMBER = "SP_Check_ItemNumber";
        private const string CHECK_BARCODE = "SP_Check_ItemBarcode";
        private const string SAVE_ITEM_DETAILS = "SP_Save_ItemDetails";

        private const string DELETE_ITEM_DETAILS = "SP_Delete_Item";
        private const string GET_LOAD_DETAILS = "SP_Get_DetailsforItem";

        private const string GET_ITEM_DETAILS = "SP_Get_ItemNameInfo";
        private const string GET_BARCODE_DETAILS = "SP_Get_Barcodedetails";
        private const string SAVE_BARCODE_DETAILS = "SP_Save_Barcode";
        private const string GET_EXPIRY_DETAILS = "SP_Get_Expirydates";
        private const string GET_MAX_ITEMID = "SP_GetMaximumItemId";
        private const string DELETE_BARCODE_DETAILS = "SP_Delete_Barcode";
        private const string CHECK_ITEM_UNDER_INVOICE = "SP_Check_ItemUnderInvoice";
        private const string GETITEMDETAILSWITHBARCODE = "SP_Get_DetailsforItemWithBarcode";
        private const string SPGETPRINTBARCODE = "SP_Get_PrintBarcode";

        MasterDataDALClass objMasterDataDALClass = new MasterDataDALClass();
        public int Undotransactiom()
        {
            if (SQLHelper.Instance.ExecuteNonQuery("SP_Itemcard_import", null) > 0)
            {               
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void connopen()
        {
            SQLHelper.Instance.conopen();
        }
        public DataTable getInvoideDetails()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TableId", 2);
            param[1] = new SqlParameter("@Flag", "Normal");
            return SQLHelper.Instance.ExecuteQueryDatatabledata("GetNextId", param);

        }

        public int savePurchase( ItemCardObjectClass objItemCardObjectClass)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0] = new SqlParameter("@NetAmt", objItemCardObjectClass.NetAmount);
            sqlparam[1] = new SqlParameter("@AgentName", objItemCardObjectClass.AgentName);
            sqlparam[2] = new SqlParameter("@CreatedBy", objItemCardObjectClass.CreatedBy);
            sqlparam[3] = new SqlParameter("@ModifiedBy", objItemCardObjectClass.ModifiedBy);
            sqlparam[4] = new SqlParameter("@Year", objItemCardObjectClass.Year);
            sqlparam[5] = new SqlParameter("@yearSequence", objItemCardObjectClass.yearSequence);
            sqlparam[6] = new SqlParameter("@PurchaseInvoiceId", objItemCardObjectClass.PurchaseInvoiceId);
             sqlparam[7] = new SqlParameter("@GrassAmount", objItemCardObjectClass.GrassAmount);
          

            return  SQLHelper.Instance.ExecuteScalar("SP_Save_PurchaseImport", sqlparam);
        }
        public int purchaseInvoceimport(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[22];

            //sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
            sqlparam[0] = new SqlParameter("@ItemName", ObjItemCard.ItemName);
            sqlparam[1] = new SqlParameter("@BarCode", ObjItemCard.Barcode);
            //sqlparam[2] = new SqlParameter("@CategoryId", ObjItemCard.CategoryId);
            sqlparam[2] = new SqlParameter("@ItemType", ObjItemCard.ItemType);
            sqlparam[3] = new SqlParameter("@ItemPlaceName", ObjItemCard.ItemPlaceName);// Obj_ItemProp.ItemDescription);
            sqlparam[4] = new SqlParameter("@ItemDescription", ObjItemCard.ItemDescription);//Obj_ItemProp.Unit );
            //  sqlparam[7] = new SqlParameter("@Unit", ObjItemCard.Unit);
            ///  sqlparam[6] = new SqlParameter("@ItemImage", ObjItemCard.Image);
            sqlparam[5] = new SqlParameter("@CompanyName", ObjItemCard.CompanyName);
            sqlparam[6] = new SqlParameter("@CategoryName", ObjItemCard.CategoryName);
            sqlparam[7] = new SqlParameter("@ItemCost", ObjItemCard.ItemCost);
            //  sqlparam[9] = new SqlParameter("@ItemLastCost", ObjItemCard.ItemLastCost);
            sqlparam[8] = new SqlParameter("@PacakageQty", ObjItemCard.PackageQuantity);
            sqlparam[9] = new SqlParameter("@ExpiryDate", ObjItemCard.ExpiryDate);

            sqlparam[10] = new SqlParameter("@ItemExpiry", ObjItemCard.ItemExpiry);
            // sqlparam[12] = new SqlParameter("@Reorder", ObjItemCard.Reorder);
            sqlparam[11] = new SqlParameter("@WholeSalePrice", ObjItemCard.WholeSalePrice);
            sqlparam[12] = new SqlParameter("@Price", ObjItemCard.Price);
            //sqlparam[13] = new SqlParameter("@MaxOrder", ObjItemCard.Maxorder);
            sqlparam[13] = new SqlParameter("@MinPrice", ObjItemCard.MinPrice);
            // sqlparam[14] = new SqlParameter("@Averagecost", ObjItemCard.AverageCost);
            //sqlparam[15] = new SqlParameter("@ImagePath", ObjItemCard.ImgPath);
            sqlparam[14] = new SqlParameter("@CreatedBy", ObjItemCard.CreatedBy);
            sqlparam[15] = new SqlParameter("@ModifiedBy", ObjItemCard.ModifiedBy);
            sqlparam[16] = new SqlParameter("@Status", ObjItemCard.Status);
            //   sqlparam[19] = new SqlParameter("@IsHide", ObjItemCard.IsHide);
            sqlparam[17] = new SqlParameter("@ItemNumber", ObjItemCard.ItemNumber);
            sqlparam[18] = new SqlParameter("@UnitQuantity",Convert.ToInt32(ObjItemCard.UnitQuantity));
            sqlparam[19] = new SqlParameter("@UnitPrice", ObjItemCard.UnitPrice);
             sqlparam[20] = new SqlParameter("@PurchaseID", ObjItemCard.PurchaseID);

             sqlparam[21] = new SqlParameter("@ExreaCost", ObjItemCard.ExreaCost);


             if (SQLHelper.Instance.ExecuteNon("SP_PurchaseInvoce_import", sqlparam) > 0)
             {
              
                 return 1;
             }
             else
             {
                 return 0;
             }
        }
        public int itemcardimport(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];

            //sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
            sqlparam[0] = new SqlParameter("@ItemName", ObjItemCard.ItemName);
             sqlparam[1] = new SqlParameter("@BarCode", ObjItemCard.Barcode);
            //sqlparam[2] = new SqlParameter("@CategoryId", ObjItemCard.CategoryId);
             sqlparam[2] = new SqlParameter("@ItemType", ObjItemCard.ItemType);
            sqlparam[3] = new SqlParameter("@ItemPlaceName", ObjItemCard.ItemPlaceName);// Obj_ItemProp.ItemDescription);
            sqlparam[4] = new SqlParameter("@ItemDescription", ObjItemCard.ItemDescription);//Obj_ItemProp.Unit );
            //  sqlparam[7] = new SqlParameter("@Unit", ObjItemCard.Unit);
          ///  sqlparam[6] = new SqlParameter("@ItemImage", ObjItemCard.Image);
            sqlparam[5] = new SqlParameter("@CompanyName", ObjItemCard.CompanyName);
            sqlparam[6] = new SqlParameter("@CategoryName", ObjItemCard.CategoryName);
            sqlparam[7] = new SqlParameter("@ItemCost", ObjItemCard.ItemCost);
          //  sqlparam[9] = new SqlParameter("@ItemLastCost", ObjItemCard.ItemLastCost);
            sqlparam[8] = new SqlParameter("@PacakageQty", ObjItemCard.PackageQuantity);
            sqlparam[9] = new SqlParameter("@ExpiryDate", ObjItemCard.ExpiryDate);

            sqlparam[10] = new SqlParameter("@ItemExpiry",DateTime.Now);
            // sqlparam[12] = new SqlParameter("@Reorder", ObjItemCard.Reorder);
            sqlparam[11] = new SqlParameter("@WholeSalePrice", ObjItemCard.WholeSalePrice);
             sqlparam[12] = new SqlParameter("@Price", ObjItemCard.Price);
           //sqlparam[13] = new SqlParameter("@MaxOrder", ObjItemCard.Maxorder);
             sqlparam[13] = new SqlParameter("@MinPrice", ObjItemCard.MinPrice);
           // sqlparam[14] = new SqlParameter("@Averagecost", ObjItemCard.AverageCost);
            //sqlparam[15] = new SqlParameter("@ImagePath", ObjItemCard.ImgPath);
            sqlparam[14] = new SqlParameter("@CreatedBy", ObjItemCard.CreatedBy);
            sqlparam[15] = new SqlParameter("@ModifiedBy", ObjItemCard.ModifiedBy);
            sqlparam[16] = new SqlParameter("@Status", ObjItemCard.Status);
         //   sqlparam[19] = new SqlParameter("@IsHide", ObjItemCard.IsHide);
            sqlparam[17] = new SqlParameter("@ItemNumber", ObjItemCard.ItemNumber);

            if (SQLHelper.Instance.ExecuteNon("SP_Itemcard_import", sqlparam) > 0)

                return 1;
            else
                return 0;

        }

        public Boolean Check_DuplicateItemName(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
                sqlparam[1] = new SqlParameter("@ItemName", ObjItemCard.Items);

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
        public int Save_ItemDetails(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[21];

            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
                sqlparam[1] = new SqlParameter("@ItemName", ObjItemCard.Items);
                // sqlparam[2] = new SqlParameter("@BarCode", ObjItemCard.Barcode);
                sqlparam[2] = new SqlParameter("@CategoryId", ObjItemCard.CategoryId);
                sqlparam[3] = new SqlParameter("@ItemType", ObjItemCard.ItemType);
                sqlparam[4] = new SqlParameter("@ItemPlaceId", ObjItemCard.ItemPlaceId);// Obj_ItemProp.ItemDescription);
                sqlparam[5] = new SqlParameter("@ItemDescription", "product");//Obj_ItemProp.Unit );
                //  sqlparam[7] = new SqlParameter("@Unit", ObjItemCard.Unit);
                sqlparam[6] = new SqlParameter("@ItemImage", ObjItemCard.Image);
                sqlparam[7] = new SqlParameter("@CompanyId", ObjItemCard.CompId);

                sqlparam[8] = new SqlParameter("@ItemCost", ObjItemCard.ItemCost);
                sqlparam[9] = new SqlParameter("@ItemLastCost", ObjItemCard.ItemLastCost);
                sqlparam[10] = new SqlParameter("@PacakageQty", ObjItemCard.PackageQuantity);
                sqlparam[11] = new SqlParameter("@ExpiryDate", ObjItemCard.ExpiryDate);
                sqlparam[12] = new SqlParameter("@Reorder", ObjItemCard.Reorder);
                //sqlparam[15] = new SqlParameter("@WholeSalePrice", ObjItemCard.WholeSalePrice);
                // sqlparam[16] = new SqlParameter("@Price", ObjItemCard.Price);
                sqlparam[13] = new SqlParameter("@MaxOrder", ObjItemCard.Maxorder);
                //  sqlparam[18] = new SqlParameter("@MinPrice", ObjItemCard.MinPrice);
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




        public List<ItemCardObjectClass> Get_ItemDetails(ItemCardObjectClass objItemCard)
        {
            List<ItemCardObjectClass> lstItemInfo = new List<ItemCardObjectClass>();
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                DataTable dt = new DataTable();
                sqlparam[0] = new SqlParameter("@ItemID", objItemCard.ItemId);
                var result = SQLHelper.Instance.GetReader(GET_ITEM_DETAILS, sqlparam);

                if (result.Read())
                {
                    lstItemInfo.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        Barcode = result["Barcode"].ToString(),
                        IsHide = Convert.ToBoolean(result["IsHide"]),
                        Items = result["ItemName"].ToString(),
                        CategoryId = Convert.ToInt32(result["CategoryID"]),
                        CompId = Convert.ToInt32(result["CompanyID"]),
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
                        ItemExpiry = Convert.ToDateTime(result["ExpiryDate1"] == DBNull.Value ? null : result["ExpiryDate1"]).Date,
                        ItemCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                        UnitNameID = Convert.ToInt32(result["UnitNameID"]),

                        UnitTypesID = Convert.ToInt32(result["UnitTypesID"]),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"] == DBNull.Value ? 0.000m : result["ItemLastCost"]),
                        AverageCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0.0m : result["AverageCost"]),
                        ItemNumber = result["ItemNumber"].ToString(),
                        BarcodeId = Convert.ToInt32(result["BarcodeID"]),
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
        public DataTable GetAppliedIncrease(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", objItemCard.ItemType);
            param[1] = new SqlParameter("@CategoryID", objItemCard.CategoryId);
            param[2] = new SqlParameter("@CompanyID", objItemCard.CompId);
            param[3] = new SqlParameter("@ItemID", objItemCard.ItemId);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }
        #endregion
        #region GetPriceChecker
        public DataTable GetPriceChecker(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_PriceChecker_Data", param, "Discount");
        }
        #endregion
        public int Get_NumberOfBarcodeCount(ItemCardObjectClass objItemCard)
        {

            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                int countofbarode = 0;
                sqlparam[0] = new SqlParameter("@ItemID", objItemCard.ItemId);

                return countofbarode = Convert.ToInt32(SQLHelper.Instance.GetScalar("USP_GetNumberOfBarcodeCount", sqlparam));
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close(); }
        }

        public Dictionary<int, dynamic> Get_ExpiryItemDetails(ItemCardObjectClass objItemCard)
        {
            Dictionary<int, dynamic> dictExpiryItemDets = new Dictionary<int, dynamic>();
            List<ItemCardObjectClass> lstExpiryStackcount = new List<ItemCardObjectClass>();

            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                // System.Data.DataSet ds = new DataSet();
                sqlparam[0] = new SqlParameter("@ItemID", objItemCard.ItemId);
                var result = SQLHelper.Instance.GetReader(GET_EXPIRY_DETAILS, sqlparam);
                dictExpiryItemDets.Add(0, lstExpiryStackcount);
                while (result.Read())
                {
                    lstExpiryStackcount.Add(new ItemCardObjectClass { ItemExpiry = Convert.ToDateTime(result["Expiry"] == null ? null : result["Expiry"]), StockInHand = Convert.ToInt32(result["StockCount"]) });
                }

                result.NextResult();
                if (result.Read())
                {
                    dictExpiryItemDets.Add(1, Convert.ToInt32(result[0]));
                }
                else
                    dictExpiryItemDets.Add(1, 0);
                if (result.Read())
                {
                    dictExpiryItemDets.Add(2, Convert.ToInt32(result[0]));
                }
                else
                    dictExpiryItemDets.Add(2, 0);
                result.NextResult();
                result.NextResult();
                if (result.Read())
                {
                    dictExpiryItemDets.Add(3, Convert.ToInt32(result["Spoiled"]));
                }
                else
                {
                    dictExpiryItemDets.Add(3, 0);
                }
                result.Close();
                return dictExpiryItemDets;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public Dictionary<string, List<ItemCardObjectClass>> GetItemDetailsWithBarcode(ItemCardObjectClass objItemCard)
        {
            Dictionary<string, List<ItemCardObjectClass>> dictItemDetsWithBarcode = new Dictionary<string, List<ItemCardObjectClass>>();
            List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();
            List<ItemCardObjectClass> lstItemBasicDetails = new List<ItemCardObjectClass>();
            List<ItemCardObjectClass> lstBarcodeDetails = new List<ItemCardObjectClass>();
            SqlParameter[] sqlparam = new SqlParameter[0];
            try
            {
                var result = SQLHelper.Instance.GetReader(GETITEMDETAILSWITHBARCODE, sqlparam);
                while (result.Read())
                {
                    lstItemDetails.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        ItemName = result["ItemName"] == null ? string.Empty : result["ItemName"].ToString(),
                        Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        Barcode = result["Barcode"] == DBNull.Value ? "0" : result["Barcode"].ToString(),
                        BarcodeStatus = Convert.ToBoolean(result["BarcodeStatus"]),

                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    lstItemBasicDetails.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        ItemName = result["ItemName"] == null ? string.Empty : result["ItemName"].ToString(),
                        Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        Barcode = result["Barcode"] == DBNull.Value ? "0" : result["Barcode"].ToString(),
                        ItemNumber = result["ItemNumber"] == null ? string.Empty : result["ItemNumber"].ToString(),
                    });

                }

                result.NextResult();

                //****************This is changed to avoiding null exception. Done By Manoj On June 21
                while (result.Read())
                {
                    lstBarcodeDetails.Add(new ItemCardObjectClass
                    {
                        BarcodeId = result["BarcodeID"] == DBNull.Value ? 0 : Convert.ToInt32(result["BarcodeID"]),
                        ItemId = result["ItemID"] == DBNull.Value ? 0 : Convert.ToInt32(result["ItemID"]),
                        Barcode = result["Barcode"] == DBNull.Value ? string.Empty : result["Barcode"].ToString(),
                        Price = result["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(result["Price"])
                    });

                }
                //********************
                result.Close();
                dictItemDetsWithBarcode.Add("Items", lstItemBasicDetails);
                dictItemDetsWithBarcode.Add("ItemDetail", lstItemDetails);
                dictItemDetsWithBarcode.Add("BarcodeDetails", lstBarcodeDetails);
                return dictItemDetsWithBarcode;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }


        public Boolean Check_DuplicateBarCode(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@Barcode", objItemCard.Barcode);
                if (Convert.ToInt32((SQLHelper.Instance.GetScalar(CHECK_BARCODE, sqlparam))) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public List<ItemCardObjectClass> Get_BarCodeDetails(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            List<ItemCardObjectClass> lstBarcodeDetails = new List<ItemCardObjectClass>();
            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", objItemCard.ItemId);
                var ReaderResult = SQLHelper.Instance.GetReader("Usp_GetBarcodeDetails", sqlparam);
                while (ReaderResult.Read())
                {
                    lstBarcodeDetails.Add(new ItemCardObjectClass
                    {
                        BarcodeId = Convert.ToInt32(ReaderResult["BarcodeID"]),
                        ItemId = Convert.ToInt32(ReaderResult["ItemID"]),
                        Barcode = ReaderResult["Barcode"].ToString(),
                        PackageQuantity = Convert.ToInt32(ReaderResult["PackageQty"] == DBNull.Value ? 0 : ReaderResult["PackageQty"]),
                        Price = Convert.ToDecimal(ReaderResult["Price"] == DBNull.Value ? 0.0m : ReaderResult["Price"]),

                        UnitTypesID = Convert.ToInt32(ReaderResult["UnitTypesID"]),
                        UnitNameID = Convert.ToInt32(ReaderResult["UnitNameID"]),
                        UnitName = ReaderResult["UnitName"].ToString(),
                        UnitTypes = ReaderResult["UnitTypes"].ToString(),
                        UnitQuantity = ReaderResult["UnitQuantity"].ToString(),
                        MinPrice = Convert.ToDecimal(ReaderResult["MinPrice"] == DBNull.Value ? 0.0m : ReaderResult["MinPrice"]),
                        WholeSalePrice = Convert.ToDecimal(ReaderResult["WholeSalePrice"] == DBNull.Value ? 0 : ReaderResult["WholeSalePrice"]),
                        ItemCost=Convert.ToDecimal(ReaderResult["ItemCost"]==DBNull.Value?0:ReaderResult["ItemCost"])
                    });
                }
                return lstBarcodeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public int Save_AdditionalBarcode(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            try
            {
                sqlparam[0] = new SqlParameter("@BarcodeID", objItemCard.BarcodeId);
                sqlparam[1] = new SqlParameter("@ItemID", objItemCard.ItemId);
                // sqlparam[2] = new SqlParameter("@OldBarcode", objItemCard.OldBarcode == null ? string.Empty : objItemCard.OldBarcode);

                sqlparam[2] = new SqlParameter("@Barcode", objItemCard.Barcode.Trim());
                sqlparam[3] = new SqlParameter("@CreatedBy", objItemCard.CreatedBy);
                sqlparam[4] = new SqlParameter("@ModifiedBy", objItemCard.ModifiedBy);
                sqlparam[5] = new SqlParameter("@Status", objItemCard.Status);
                sqlparam[6] = new SqlParameter("@PackageQty", objItemCard.PackageQuantity);
                sqlparam[7] = new SqlParameter("@Price", objItemCard.Price);
                //sqlparam[9] = new SqlParameter("@UnitTypesID", objItemCard.UnitTypesID );
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
        public int Delete_BarcodeDetails(ItemCardObjectClass objItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            try
            {
                sqlparam[0] = new SqlParameter("@BarcodeId", objItemCard.BarcodeId);
                sqlparam[1] = new SqlParameter("@ItemId", objItemCard.ItemId);
                // sqlparam[2] = new SqlParameter("@Barcode", objItemCard.Barcode);
                sqlparam[2] = new SqlParameter("@ModifiedBy", objItemCard.ModifiedBy);
                sqlparam[3] = new SqlParameter("@Status", objItemCard.Status);
                if (SQLHelper.Instance.ExecuteNonQuery(DELETE_BARCODE_DETAILS, sqlparam) > 0)
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
        public int Delete_ItemDetails(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
                sqlparam[1] = new SqlParameter("@ModifiedBy", ObjItemCard.ModifiedBy);
                sqlparam[2] = new SqlParameter("@Status", ObjItemCard.Status);
                if (SQLHelper.Instance.ExecuteNonQuery(DELETE_ITEM_DETAILS, sqlparam) > 0)
                { return 1; }
                else
                { return 0; }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean Check_ItemUnderInvoice(ItemCardObjectClass ObjItemCard)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemId", ObjItemCard.ItemId);
                if (Convert.ToInt32((SQLHelper.Instance.GetScalar(CHECK_ITEM_UNDER_INVOICE, sqlparam))) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }



        public Dictionary<string, List<ItemCardObjectClass>> Get_LoadItemDetailsAll()
        {

            try
            {
                Dictionary<string, List<ItemCardObjectClass>> dictLoad = new Dictionary<string, List<ItemCardObjectClass>>();
                List<ItemCardObjectClass> lstItemInfo = new List<ItemCardObjectClass>();
                List<ItemCardObjectClass> lstCategoryInfo = new List<ItemCardObjectClass>();
                List<ItemCardObjectClass> lstCompanyInfo = new List<ItemCardObjectClass>();
                List<ItemCardObjectClass> lstItemPlaceInfo = new List<ItemCardObjectClass>();
                var result = SQLHelper.Instance.GetReader(GET_LOAD_DETAILS);
                while (result.Read())
                {
                    lstItemInfo.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result[0]),
                        Items = result[1].ToString(),
                        IsHide = Convert.ToBoolean(result[2] == DBNull.Value ? false : result[2]),
                        ItemNumber = result[3] == DBNull.Value ? string.Empty : result[3].ToString()
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    lstCategoryInfo.Add(new ItemCardObjectClass
                    {
                        CategoryId = Convert.ToInt32(result[0]),
                        CategoryName = result[1].ToString()

                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    lstCompanyInfo.Add(new ItemCardObjectClass
                    {
                        CompId = Convert.ToInt32(result[0]),
                        CompanyName = result[1].ToString()
                    });
                }
                result.NextResult();
                while (result.Read())
                {
                    lstItemPlaceInfo.Add(new ItemCardObjectClass
                    {
                        ItemPlaceId = Convert.ToInt32(result[0]),
                        ItemPlaceName = result[1].ToString()
                    });
                }

                //----------------This is added by manoj to display all items based on sorted ascending
                lstItemInfo.Sort(delegate(ItemCardObjectClass Item1, ItemCardObjectClass Item2)
       {
           return Item1.Items.CompareTo(Item2.Items);
       });
                //---------------------------------------

                dictLoad.Add("ItemInfo", lstItemInfo);
                dictLoad.Add("ComInfo", lstCompanyInfo);
                dictLoad.Add("CatInfo", lstCategoryInfo);
                dictLoad.Add("ItemPlace", lstItemPlaceInfo);
                return dictLoad;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }








        public Dictionary<string, List<ItemCardObjectClass>> getItemIDName()
        {
            try
            {
                Dictionary<string, List<ItemCardObjectClass>> dictItemDetails = new Dictionary<string, List<ItemCardObjectClass>>();
                List<ItemCardObjectClass> lstItemName = new List<ItemCardObjectClass>();
                List<ItemCardObjectClass> lstItemNo = new List<ItemCardObjectClass>();

                var result = SQLHelper.Instance.GetReader("select  ItemID,ItemName  from Item where Status=1 or Status=2 order by ItemName");
                while (result.Read())
                {
                    lstItemName.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result[0]),
                        Items = result[1].ToString()
                    });
                }
                result.Close();
                var result1 = SQLHelper.Instance.GetReader("select  ItemID,ItemName from Item where Status<>'' and Status=1 or  Status=2 ");
                while (result1.Read())
                {
                    lstItemNo.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result1[0]),
                        Items = result1[1].ToString()
                    });
                }
                result1.Close();
                dictItemDetails.Add("ItemName", lstItemName);
                dictItemDetails.Add("ItemNo", lstItemNo);
                return dictItemDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<ItemCardObjectClass> GetBarcodeLogoDAL(int ItemId)
        {
            List<ItemCardObjectClass> objBarcodeLogo = new List<ItemCardObjectClass>();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@ItemId", ItemId);
                var result = SQLHelper.Instance.GetReader(SPGETPRINTBARCODE, sqlparam);
                //  var result = SQLHelper.Instance.GetReader("select a.Flag ,b.ItemName,b.Price,b.MinPrice from Item b cross join Options a where b.ItemID=" + ItemId +"and" +"a.OptionName="+Txt_LogoHeader+);
                // var query = "SELECT COUNT(*) from dbo.UserTracking where UserId=" + objEmp.UserId + "" +" and "+ "IsInvoiceAction=" + objEmp.InvoiceAction+"";
                while (result.Read())
                {
                    objBarcodeLogo.Add(new ItemCardObjectClass
                    {
                        flag = result["Flag"] != DBNull.Value ? result["Flag"].ToString().Trim() : string.Empty,
                        Items = result["ItemName"] != DBNull.Value ? result["ItemName"].ToString().Trim() : string.Empty,
                        Price = result["Price"] != DBNull.Value ? Convert.ToDecimal(result["Price"].ToString()) : 0,
                        MinPrice = result["MinPrice"] != DBNull.Value ? Convert.ToDecimal(result["MinPrice"].ToString()) : 0
                    });
                }
                result.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return objBarcodeLogo;
        }

        public DataTable InventoryListDetails()
        {

            try
            {
                SqlParameter[] param = new SqlParameter[0];
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_Item_List_Print", param, "ItemCardInventoryList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Get_GenerateBarcodeList()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Barcode_List", param, "GenerateBarcodeList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Get_PrintItemList()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Item_List_Print", param, "GenerateBarcodeList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Get_ItemInOutStockDetails(ItemCardObjectClass objectitemcard)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", DBNull.Value);
                param[1] = new SqlParameter("@ToDate", DBNull.Value);
                param[2] = new SqlParameter("@ItemID", objectitemcard.ItemId);
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_GetItemStockHistory", param, "ItemCardInOutStock");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //included on 15 may 2014 to get the particular barcode id details this one commaon between item card form and additional barcode form 
        public List<ItemCardObjectClass> Get_UnitNameBarcodeDetails(ItemCardObjectClass objitemcarddetails)
        {
            try
            {
                List<ItemCardObjectClass> listitemdetails = new List<ItemCardObjectClass>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@BarcodeID", objitemcarddetails.BarcodeId);

                var result = SQLHelper.Instance.GetReaderWithQuery("select MinPrice,WholeSalePrice,Price,UnitNameID ,PackageQty from Barcode where Status=1 and BarcodeID=@BarcodeID", param);
                if (result.Read())
                {
                    listitemdetails.Add(new ItemCardObjectClass
                                        {
                                            MinPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                                            WholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                                            Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                                            UnitNameID = Convert.ToInt32(result["UnitNameID"]),
                                            PackageQuantity = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),

                                        });
                }
                return listitemdetails;
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
    }
}


