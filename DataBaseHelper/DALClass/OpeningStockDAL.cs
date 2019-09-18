using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ObjectHelper;


namespace DataBaseHelper.DALClass
{
    public class OpeningStockDAL
    {

        DataTable dt;
        DataSet ds;
        //public DataSet getComCatList()
        //{
        // SqlParameter[] sqlparam=new SqlParameter[0];
        // ds = SQLHelper.Instance.ExecuteQueryDataset("SP_Get_CATEGORYandCOMPANY_New", sqlparam, "ComCatList");
        // return ds;
        //}
        public DataSet getComCatList()
        {

            SqlParameter[] sqlparam = new SqlParameter[0];
            using (ds = SQLHelper.Instance.ExecuteQueryDataset("SP_Get_CATEGORYandCOMPANY_New", sqlparam, "ComCatList"))
                return ds;
        }
        public DataTable getGridList()
        {

            SqlParameter[] sqlparam = new SqlParameter[0];
            using (dt = SQLHelper.Instance.ExecuteDatatableWithQuery(" select ItemID[ItemNo],ItemName [ItemName],Description [Description],ExpiryDate [ExpiryDate],PackageQty [Package],Quantity [Quantity],Convert(decimal(18,3),isnull(ItemCost,0)) [Cost],Convert(decimal(18,3),isnull(UnitPrice,0)) [UnitPrice],Convert(decimal(18,3),isnull(ItemPrice,0))[ItemPrice],Convert(decimal(18,3),isnull(Total,0))[Total],Convert(varchar,Time,8)[Time],UserId[User],SerialNo[SerialNo] from Inventory order by InventoryID ", sqlparam, "GridTable"))
                return dt;
        }
        public DataTable getControlDetails()
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            using (dt = SQLHelper.Instance.ExecuteDatatableWithQuery(" select * from Inventory", sqlparam, "GridTable"))
                return dt;
        }

        public DataSet GetItemListByCategoryORCompany(PurchaseObjectClass ObjStock)
        {
            DataSet dtLocal = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", ObjStock.CategoryNo);
                param[1] = new SqlParameter("@CompanyID", ObjStock.CompanyNo);
                using (dtLocal = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_ITEMDETAILSFORSTOCK, param, "ItemName"))
                    return dtLocal;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Boolean Save_InventoryDetailsList(PurchaseObjectClass ObjStock)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[22];
                Param[0] = new SqlParameter("@ItemName", SqlDbType.NVarChar);
                Param[0].Value = ObjStock.ItemName;
                Param[1] = new SqlParameter("@Description", ObjStock.ItemDescription);
                Param[2] = new SqlParameter("@ExpiryDate", ObjStock.ItemExpiryDate);
                Param[3] = new SqlParameter("@PackageQty", ObjStock.ItemPackage);
                Param[4] = new SqlParameter("@Quantity", ObjStock.ItemQuantity);
                Param[5] = new SqlParameter("@ItemCost", ObjStock.ItemCost);
                Param[6] = new SqlParameter("@UnitPrice", ObjStock.ItemUnitPrice);
                Param[7] = new SqlParameter("@ItemPrice", ObjStock.ItemPrice);
                Param[8] = new SqlParameter("@Total", ObjStock.ItemTotal);
                //Param[9] = new SqlParameter("@Time",Convert.ToDateTime(ObjStock.Time));//Commented on 2-June-2014 for Date Format Issues
                Param[9] = new SqlParameter("@Time", DateTime.Now);//Added on 2-June-2014 
                Param[10] = new SqlParameter("@User", ObjStock.CreatedBy);
                Param[11] = new SqlParameter("@CreatedBy", ObjStock.CreatedBy);
                Param[12] = new SqlParameter("@Status", ObjStock.Status);
                Param[13] = new SqlParameter("@Remove", ObjStock.Remove);
                Param[14] = new SqlParameter("@ItemID", ObjStock.ItemNo);
                Param[15] = new SqlParameter("@Expiry", ObjStock.ExpiryDate);
                Param[16] = new SqlParameter("@SerialNo", ObjStock.ItemSerialNo);
                Param[17] = new SqlParameter("@CategoryID", ObjStock.CategoryNo);
                Param[18] = new SqlParameter("@CompanyID", ObjStock.CompanyNo);
                Param[19] = new SqlParameter("@Notes", ObjStock.Note);
                Param[20] = new SqlParameter("@Supplier", ObjStock.SupplierNo);
                Param[21] = new SqlParameter("@BarcodeID", ObjStock.BarcodeID);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_STOCK_DETAILS, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }

        }

        public Boolean Undo_InventoryDetails(PurchaseObjectClass ObjStock)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[12];
                Param[0] = new SqlParameter("@Item", ObjStock.ItemNo);
                Param[1] = new SqlParameter("@ItemCost", ObjStock.ItemCost);
                Param[2] = new SqlParameter("@Price", ObjStock.ItemPrice);
                Param[3] = new SqlParameter("@StockInHand", ObjStock.ItemQuantity);
                Param[4] = new SqlParameter("@ExpiryDate", ObjStock.ItemExpiryDate);
                Param[5] = new SqlParameter("@DateAdjusted", ObjStock.ProcessDate);
                Param[6] = new SqlParameter("@Reasons", ObjStock.Note);
                Param[7] = new SqlParameter("@Expiry", ObjStock.ExpiryDate);
                Param[8] = new SqlParameter("@Description", ObjStock.ItemDescription);
                Param[9] = new SqlParameter("@ModifiedBy", ObjStock.ModifiedBy);
                Param[10] = new SqlParameter("@SerialNo", ObjStock.ItemSerialNo);
                Param[11] = new SqlParameter("@BarcodeID", ObjStock.BarcodeID);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.UNDO_INVENTORY_DETAILS, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }

        }

        public Object stock_for_Delete(PurchaseObjectClass ObjStock)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemID", ObjStock.ItemNo);
            param[1] = new SqlParameter("@Cost", ObjStock.ItemCost);
            param[2] = new SqlParameter("@SerialNo", ObjStock.ItemSerialNo);
            param[3] = new SqlParameter("@ExpiryDate", ObjStock.ItemSerialNo == "0" ? ObjStock.ItemExpiryDate == null ? DBNull.Value : (object)ObjStock.ItemExpiryDate : DBNull.Value);
            try
            {
                object result = SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(SUM(StockInHand),0)as Stock FROM dbo.Stock WHERE ItemID=@ItemID AND Cost=@Cost AND SerialNo=@SerialNo AND ((SUBSTRING(CONVERT(VARCHAR, @ExpiryDate, 101), 0, 11)  is NULL) or (Expiry= SUBSTRING(CONVERT(VARCHAR, @ExpiryDate, 101), 0, 11) ))AND((SUBSTRING(CONVERT(VARCHAR, @ExpiryDate, 101), 0, 11)  is not NULL )or(Expiry is null)) ", param);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean Update_InventoryDetails(PurchaseObjectClass ObjStock)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[12];
                Param[0] = new SqlParameter("@ItemID", ObjStock.ItemNo);
                Param[1] = new SqlParameter("@ItemCost", ObjStock.ItemCost);
                Param[2] = new SqlParameter("@Price", ObjStock.ItemPrice);
                Param[3] = new SqlParameter("@StockInHand", ObjStock.ItemQuantity);
                Param[4] = new SqlParameter("@ExpiryDate", ObjStock.ItemExpiryDate);
                Param[5] = new SqlParameter("@DateAdjusted", ObjStock.ProcessDate);
                Param[6] = new SqlParameter("@Reasons", ObjStock.Note);
                Param[7] = new SqlParameter("@Expiry", ObjStock.ExpiryDate);
                Param[8] = new SqlParameter("@Description", ObjStock.ItemDescription);
                Param[9] = new SqlParameter("@ModifiedBy", ObjStock.ModifiedBy);
                Param[10] = new SqlParameter("@SerialNo", ObjStock.ItemSerialNo);
                Param[11] = new SqlParameter("@AgentID", ObjStock.SupplierNo);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.UPDATE_INVENTORY_DETAILS, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }

        }

        public int Save_Stock_Details(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@BatchID", ObjPurchase.BatchID);
                param[1] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                param[2] = new SqlParameter("@StockInHand", ObjPurchase.ItemQuantity);
                param[3] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
                param[4] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
                param[5] = new SqlParameter("@Status", ObjPurchase.Status);
                param[6] = new SqlParameter("@Expiry", ObjPurchase.ItemType == 1 ? (object)ObjPurchase.ItemExpiryDate : DBNull.Value);
                param[7] = new SqlParameter("@ItemCost", ObjPurchase.ItemCost);
                param[8] = new SqlParameter("@ItemLastCost", ObjPurchase.ItemCost);
                param[9] = new SqlParameter("@Price", ObjPurchase.ItemPrice);
                param[10] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
                param[11] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
                //param[13] = new SqlParameter("@MTB_ITEMDISCOUNT", objPurchase.ItemDiscount);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_STOCK, param) > 0)
                    return 1;
                else
                    return 0;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable Get_All_InventoryofItemList_Extended(PurchaseObjectClass ObjStock)
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", ObjStock.CategoryNo);
                param[1] = new SqlParameter("@CompanyID", ObjStock.CompanyNo);
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_INVENTORY_DETAILS, param, "Inventory");
                return dtLocal;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable GetDetailsforExport()
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            try
            {
                //string query = "select * from [dbo].[VW_ExportOpeningStock]";

                dt = SQLHelper.Instance.ExecuteDatatableWithQuery("usp_BBM_ExportOpeningStock", param, "Inventory");
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }

        #region GetAppliedIncrease
        public DataTable GetAppliedIncrease(PurchaseObjectClass objItemCard)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", objItemCard.ItemType);
            param[1] = new SqlParameter("@CategoryID", objItemCard.CategoryNo);
            param[2] = new SqlParameter("@CompanyID", objItemCard.CompanyNo);
            param[3] = new SqlParameter("@ItemID", objItemCard.ItemNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }
        #endregion
    }
}
