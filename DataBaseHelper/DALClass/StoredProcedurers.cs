using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ObjectHelper;
using System.Threading;

namespace DataBaseHelper.DALClass
{
    public class StoredProcedurers
    {
        #region CommonFunction
        public static DataTable Get_NewYearNo(long InvoiceNo, string Flag)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("InvoiceNo", InvoiceNo);
                sqlparam[1] = new SqlParameter("Flag", Flag);
                dt = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_NewInvoiceNo", sqlparam, "InvoiceNo");
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static object GetInvoiceIDBasedonNewYearID(int Year, int NewYearInvoiceID, int TableId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Year", Year);
                param[1] = new SqlParameter("@YearSequence", NewYearInvoiceID);
                param[2] = new SqlParameter("@TableId", TableId);
                return SQLHelper.Instance.GetScalar(StoredProcedurers.GET_PURCHASEINVOICEID, param);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataSet GetItemDetails()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                DataSet ds = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_RETURN_ITEMLIST, param, "Item");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCommonItemDetails()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_ReturnPurchaseItem", param, "Items");
        }

        public static List<long> GetYearSequenceMaxID(int TableID)
        {
            List<long> InvoiceID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TableId", TableID);
                param[1] = new SqlParameter("@Flag", "Normal");
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_NEXT_ID, param);
                while (result.Read())
                {
                    InvoiceID.Add(Convert.ToInt64(result["MaxId"]));
                    InvoiceID.Add(Convert.ToInt64(result["YearValue"]));
                    InvoiceID.Add(Convert.ToInt64(result["YearMaxId"]));

                }
                return InvoiceID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }

        public static List<PurchaseObjectClass> GetItemNameInfo(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                List<PurchaseObjectClass> ItemInfoList = new List<PurchaseObjectClass>();
                using (SqlCommand sqlCmd = new SqlCommand(StoredProcedurers.GET_ITEMNAMEINFO, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }

                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        ItemInfoList.Add(new PurchaseObjectClass
                        {
                            ItemNo = Convert.ToInt32(result["ItemId"]),
                            ItemName = result["ItemName"].ToString(),
                            ItemBarcode = result["barcode"].ToString(),
                            CategoryNo = Convert.ToInt32(result["CategoryId"]),
                            ItemType = Convert.ToInt32(result["ItemType"]),
                            ItemPlaceID = Convert.ToInt32(result["ItemPlaceID"]),
                            ItemDescription = result["ItemDescription"].ToString(),
                            //ItemUnitPrice = Convert.ToDecimal(result["Unit"]),
                            CompanyNo = Convert.ToInt32(result["CompanyId"]),
                            SupplierNo = Convert.ToInt32((result["AgentId"]) == DBNull.Value ? 0 : result["AgentID"]),
                            ItemCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                            ItemLastCost = Convert.ToDecimal(result["ItemLastCost"] == DBNull.Value ? 0.000m : result["ItemLastCost"]),
                            ItemPackage = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                            ExpiryDate = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? 0 : result["ExpiryDate"])),
                            Reorder = Convert.ToInt32(result["Reorder"]),
                            ItemWholeSalePrice = Convert.ToDecimal(result["wholeSalePrice"] == DBNull.Value ? 0.0m : result["WholeSalePrice"]),
                            ItemPrice = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0.0m : result["Price"]),
                            MaxOrder = Convert.ToInt32(result["MaxOrder"]),
                            ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0.0m : result["MinPrice"]),
                            AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"]),
                            CreatedBy = Convert.ToInt32(result["CreatedBy"]),
                            ModifiedBy = Convert.ToInt32(result["ModifiedBy"]),
                            Status = Convert.ToInt32(result["Status"]),
                            IsHide = Convert.ToBoolean(result["IsHide"]),
                            ItemExpiryDate = Convert.ToDateTime((result["ExpiryDate1"] == DBNull.Value ? null : result["ExpiryDate1"])),
                            ItemTotalStock = Convert.ToInt32(result["StockInHand"]),
                            BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                            ItemNumber = result["ItemNumber"].ToString(),
                            ItemCardItemCost = Convert.ToDecimal(result["ItemCardItemCost"] == DBNull.Value ? 0.000 : result["ItemCardItemCost"]),
                            ItemCardPackageQty = Convert.ToInt32(result["ItemCardPackageQty"] == DBNull.Value ? 0.000 : result["ItemCardPackageQty"])
                        });


                    }

                }
                return ItemInfoList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }

        public static List<long> GetMinMaxID(int TableID)
        {
            List<long> MinMaxID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TableID", TableID);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_MAX_MIN_ID, param);
                while (result.Read())
                {
                    MinMaxID.Add(Convert.ToInt64(result["MinId"] == DBNull.Value ? 0 : result["MinId"]));
                    MinMaxID.Add(Convert.ToInt64(result["MaxId"] == DBNull.Value ? 0 : result["MaxId"]));
                    MinMaxID.Add(Convert.ToInt64(result["YearValue"] == DBNull.Value ? 0 : result["YearValue"]));
                }

                return MinMaxID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }
        public static List<long> GetMinMaxIDYearValue(int TableID)
        {
            List<long> MinMaxID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TableID", TableID);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_MAX_MIN_ID, param);
                while (result.Read())
                {
                    MinMaxID.Add(Convert.ToInt64(result["MinId"] == DBNull.Value ? 0 : result["MinId"]));
                    MinMaxID.Add(Convert.ToInt64(result["MaxId"] == DBNull.Value ? 0 : result["MaxId"]));
                    MinMaxID.Add(Convert.ToInt64(result["YearValue"] == DBNull.Value ? 0 : result["YearValue"]));
                    MinMaxID.Add(Convert.ToInt64(result["YearMaxId"] == DBNull.Value ? 0 : result["YearMaxId"]));
                }

                return MinMaxID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }

        public static int ModifyInvoice(long InvoiceNo, string Flag)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@InvoiceNo", InvoiceNo);
            param[1] = new SqlParameter("@InvoiceFlag", Flag);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.MODIFY_INVOICE, param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable GetItemBasedOnComCat(int CatComID, int Value)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ChangeID", CatComID);
            param[1] = new SqlParameter("@Value", Value);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_COMCAT_NAME, param, "CatComName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet Get_PackageItemDetails(int ItemID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemID", ItemID);
            return SQLHelper.Instance.ExecuteQueryDataset("usp_BBM_GetItemDetails", param, "Items");
        }

        public static DataTable GetItemsfromSale()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("Get_SaleReturnItem", param, "Item");
        }
        public static DataSet GetAllItems()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDataset("SP_Get_AllItemDetails", param, "ItemDetails");
        }
        public static DataSet GetItemListByCategoryORCompany(int CategoryNo, int CompanyNo)
        {
            DataSet dtLocal = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", CategoryNo);
                param[1] = new SqlParameter("@CompanyID", CompanyNo);
                using (dtLocal = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_ITEMDETAILSFORSTOCK, param, "ItemName"))
                    return dtLocal;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static DataTable GetPOSShortCutItem()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_POSShortCutItemName", param, "POSItem");
        }

        public static DataTable GetClientDetails()
        {
            SqlParameter[] param = new SqlParameter[0];
            DataTable dtcheck = new DataTable();
            dtcheck = SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_ClientDetails", param, "Client");
            DataTable client = new DataTable();
            if (client.Columns.Count == 0)
            {
                client.Columns.Add("AgentId");
                client.Columns.Add("Name");
            }
            foreach (DataRow row in dtcheck.Rows)
            {
                if (Convert.ToInt16(row[0]) == 1001)
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        row[1] = "CASH CLIENT";
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                        row[1] = "زبون نقدي";
                }
                client.ImportRow(row);
            }
            return client;
        }
        #endregion

        #region Purchase Invoice

        public const string SAVE_PURCHASE_INVOICE = "SP_Save_Purchase";
        public const string GET_MAX_MIN_ID = "usp_BBM_GetMinMax";
        public const string GET_PURCHASE_BALANCE = "SP_Get_PurchaseBalance";
        public const string GET_COMCAT_NAME = "usp_BBM_Get_CategoryItem";
        public const string GET_NEXT_ID = "GetNextId";
        public const string GET_PURCHASE_LOAD = "SP_GetPurchaseLoad";
        public const string SAVE_STOCK = "SP_Save_Stock";
        public const string GET_PURCHASEINVOICE_DETAILS = "SP_Get_PurchaseInvoiceDetails";


        public const string GET_ITEMNAMEINFO = "SP_Get_ItemNameInfo";
        public const string GET_EXPIRY_COUNT = "Sp_Get_ExpiryCount_A";
        public const string MODIFY_INVOICE = "SP_ModifyInvoice";
        public const string DELETE_STOCK = "SP_Delete_Stock";
        public const string CHECK_PAYMENTDATE = "usp_BBM_CheckPaymentDate";
        public const string SAVE_ITEM_SERIALNO = "SP_Save_Item_SerialNumber";
        public const string GETSTOCK_BASED_SERIALNO = "Sp_GetStock_basedserialno_A";
        public const string GET_ITEMINFO = "Get_Item_Info";
        public const string GET_PURCHASEINVOICEID = "usp_Get_PurchaesInvoiceID";
        #endregion

        #region Purchase Return Invoice

        public const string GET_RETURN_ITEMLIST = "SP_Get_DetailsforPurchase";
        public const string GET_RETURN_PURCHASEINVOICE = "SP_Get_Return_PurchaseInvoice";
        public const string SAVE_PURCHASE_RETURN = "SP_Save_PurchaseReturn";
        public const string GET_PURCHASE_RETURN_DETAIL = "SP_Get_ReturnInvoiceDetails";
        public const string GET_PURCHASEDETAIL_BYINVOICE = "SP_Get_Return_PurchaseInvoice_Byinvoice";
        public const string GET_RETURN_MAXMIN_ID = "Sp_Get_Min_Max_Returnno_A";
        public const string GET_ITEMSTOCK_COUNT = "SpNameGetItemNameCost_Info";
        public const string LOAD_PURCHASELIST = "SP_Get_ReturnPurchase";
        public const string CLOSE_INVOICE = "Sp_Close_PurchaseReturn";
        public const string RETURN_MODIFY_INVOICE = "Sp_Modify_PurchaseReturn";
        public const string UNDO_RETURN_PURCHASE = "SP_Undo_PurchaseReturn";
        public const string CHECK_BALANCE = "Sp_check_balance_Purchret_A";
        #endregion

        #region Order
        public const string SAVE_ORDER_INVOICE = "SP_Save_OrderInvoice_New";
        public const string ORDER_INVOICE_DETAILS = "SP_Get_OrderInvoiceDetails";
        #endregion

        #region Find Purchase Invoice
        public const string FIND_PURCHASEINVOICE_DATA = "SP_Get_Find_PurchaseInvoice";
        public const string FIND_RETURNINVOICE_DETAILs = "SP_Get_FindReturnInvoiceDetails";
        public const string FIND_ORDERINVOICE_DETAILS = "SP_Get_FindOrderInvoiceDetails";
        #endregion

        #region Stock
        public const string GET_ITEMDETAILSFORSTOCK = "SP_Get_ItemByCategoryOrCompany";
        public const string SAVE_STOCK_DETAILS = "SP_Save_InventoryDetailsList";
        public const string UNDO_INVENTORY_DETAILS = "SP_Undo_InventoryDetails";
        public const string UPDATE_INVENTORY_DETAILS = "SP_Update_InventoryDetails";
        public const string GET_INVENTORY_DETAILS = "SP_Get_IntventoryDetailsList_Extended";
        #endregion

        #region Spoiled
        public const string GET_ITEM_EXPIRY = "SP_Get_Expiry";
        public const string GET_ITEM_SERIALNO = "Sp_Get_Serialno_A";
        #endregion

        #region Discount
        public const string SAVE_DISCOUNT_DETAILS = "SP_Save_DiscountDetails";
        public const string CHECK_DISCOUNT_DETAILS = "SP_Check_DiscountDetails";
        public const string GET_DISCOUNT_DETAILS = "SP_Get_DiscountAppliedItems";
        public const string UNDO_DISCOUNT_DETAILS = "SP_Undo_DiscountDetails";
        #endregion

        #region Custom Report Form
        public const string GET_TablesName = "SP_Get_Tables";
        public const string GET_ColumnsName = "SP_Get_ColumnsOnTable";
        #endregion

        #region favorite user query
        public const string Save_UserQuery = "SP_Save_UserQuery";
        public const string Get_UserQuery = "SP_Get_UserQuery";
        public const string Get_UserQueryByID = "SP_Get_UserQueryByID";
        public const string Get_UserQueryByDesc = "SP_Get_UserQueryByDescripton";
        public const string Update_UserQuery = "SP_Update_UserQuery";
        public const string Delete_UserQuery = "SP_Delete_UserQuery";
        public const string UserQuery_ExecuteCustomQuery = "SP_ExecuteCustomQuery";
        #endregion

    }
}
