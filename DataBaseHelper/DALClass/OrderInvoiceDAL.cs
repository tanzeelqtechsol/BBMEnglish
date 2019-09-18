using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class OrderInvoiceDAL
    {
        public List<PurchaseObjectClass> GetOrderDetails()
        {
            List<PurchaseObjectClass> LoadList = new List<PurchaseObjectClass>();
            try
            {
                //string Query = "Select OrderID,OrderInvoice,AgentID,NetAmount,OrderDate,DeliveryDate,Discount,Remarks,DiscountType,SaleID,Year,YearSequenceNo,OriginalDiscount,Note,Status From dbo.[Order] Where OrderInvoice=(Select MaxId From KeySequence Where TableId=3) AND Remarks=3";
                string Query = "Select OrderInvoice,AgentID,Year,YearSequenceNo From dbo.[Order] Where OrderInvoice=(Select MaxId From KeySequence Where TableId=3) AND Remarks=3";
                var result = SQLHelper.Instance.GetReader(Query);
                FillOrderInvoiceDetailsinDropDown(LoadList, result);
                return LoadList;
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

        private void FillOrderInvoiceDetails(List<PurchaseObjectClass> LoadList, SqlDataReader result)
        {
            while (result.Read())
            {
                LoadList.Add(new PurchaseObjectClass
                {
                    OrderID = Convert.ToInt64(result["OrderID"]),
                    OrderInvoiceNo = Convert.ToInt32(result["OrderInvoice"]),
                    SupplierNo = Convert.ToInt32(result["AgentID"]),
                    ItemNet = Convert.ToDecimal(result["NetAmount"]),
                    OrderDate = Convert.ToDateTime(result["OrderDate"] == DBNull.Value ? null : result["OrderDate"]).Date,
                    OrderDeliveryDate = Convert.ToDateTime(result["DeliveryDate"] == DBNull.Value ? null : result["DeliveryDate"]).Date,
                    Discount = Convert.ToDecimal(result["Discount"] == DBNull.Value ? 0 : result["Discount"]),
                    Remarks = Convert.ToInt32(result["Remarks"]),
                    DiscountType = Convert.ToInt32(result["DiscountType"] == DBNull.Value ? null : result["DiscountType"]),
                    SaleID = Convert.ToInt32(result["SaleID"] == DBNull.Value ? 0 : result["SaleID"]),
                    Year = Convert.ToInt32(result["Year"]),
                    NewYearInvoiceID = Convert.ToInt32(result["YearSequenceNo"]),
                    originaldiscount = Convert.ToDecimal(result["OriginalDiscount"] == DBNull.Value ? 0 : result["OriginalDiscount"]),
                    OrderNote = result["Note"].ToString(),
                    Status = Convert.ToInt32(result["Status"])
                });
            }
        }


        private void FillOrderInvoiceDetailsinDropDown(List<PurchaseObjectClass> LoadList, SqlDataReader result)
        {
            while (result.Read())
            {
                LoadList.Add(new PurchaseObjectClass
                {
                    //OrderID = Convert.ToInt64(result["OrderID"]),
                    OrderInvoiceNo = Convert.ToInt32(result["OrderInvoice"]),
                    SupplierNo = Convert.ToInt32(result["AgentID"]),
                    //ItemNet = Convert.ToDecimal(result["NetAmount"]),
                    //OrderDate = Convert.ToDateTime(result["OrderDate"] == DBNull.Value ? null : result["OrderDate"]).Date,
                    //OrderDeliveryDate = Convert.ToDateTime(result["DeliveryDate"] == DBNull.Value ? null : result["DeliveryDate"]).Date,
                    //Discount = Convert.ToDecimal(result["Discount"] == DBNull.Value ? 0 : result["Discount"]),
                    //Remarks = Convert.ToInt32(result["Remarks"]),
                    //DiscountType = Convert.ToInt32(result["DiscountType"] == DBNull.Value ? null : result["DiscountType"]),
                    //SaleID = Convert.ToInt32(result["SaleID"] == DBNull.Value ? 0 : result["SaleID"]),
                    Year = Convert.ToInt32(result["Year"]),
                    NewYearInvoiceID = Convert.ToInt32(result["YearSequenceNo"]),
                    //originaldiscount = Convert.ToDecimal(result["OriginalDiscount"] == DBNull.Value ? 0 : result["OriginalDiscount"]),
                    //OrderNote = result["Note"].ToString(),
                    //Status = Convert.ToInt32(result["Status"])
                });
            }
        }

        public Boolean Save_Order_Invoice(PurchaseObjectClass objPurchase)
        {
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@OrderInvoice", objPurchase.OrderInvoiceNo);
            param[1] = new SqlParameter("@AgentID", objPurchase.SupplierNo);
            param[2] = new SqlParameter("@NetAmount", objPurchase.ItemNet);
            param[3] = new SqlParameter("@OrderDate", objPurchase.OrderDate);
            param[4] = new SqlParameter("@DeliveryDate", objPurchase.OrderDeliveryDate == null || objPurchase.OrderDeliveryDate == DateTime.MinValue ? DBNull.Value : (object)objPurchase.OrderDeliveryDate);
            param[5] = new SqlParameter("@CreatedBy", objPurchase.CreatedBy);
            param[6] = new SqlParameter("@ModifiedBy", objPurchase.ModifiedBy);
            param[7] = new SqlParameter("@Status", objPurchase.Status);

            param[8] = new SqlParameter("@ItemID", objPurchase.ItemNo);
            param[9] = new SqlParameter("@Quantity", objPurchase.ItemQuantity);
            param[10] = new SqlParameter("@Package", objPurchase.ItemPackage);
            param[11] = new SqlParameter("@UnitPrice", objPurchase.ItemUnitPrice);
            param[12] = new SqlParameter("@DemandDate", objPurchase.OrderDemandDate ==null ||objPurchase.OrderDemandDate==DateTime.MinValue? DBNull.Value : (object)objPurchase.OrderDemandDate);
            param[13] = new SqlParameter("@Remove", objPurchase.SetStatus);
            param[14] = new SqlParameter("@Remarks", objPurchase.Remarks);
            param[15] = new SqlParameter("@MTB_SERIALNO", objPurchase.ItemSerialNo == null ? "0" : objPurchase.ItemSerialNo);
            param[16] = new SqlParameter("@Note", string.IsNullOrEmpty(objPurchase.OrderNote) ? "" : objPurchase.OrderNote);
            param[17] = new SqlParameter("@BarcodeID", objPurchase.BarcodeID );
            param[18] = new SqlParameter("@ItemCost", objPurchase.ItemCost );
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_ORDER_INVOICE, param) > 0)
                    return true;
                else
                    return false;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetOrderInvoiceDetails(long InvoiceNo,int Remarks)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@OrderInvoice", InvoiceNo);
            param[1] = new SqlParameter("@Remarks",Remarks );
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.ORDER_INVOICE_DETAILS, param, "OrderInvoice");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object CheckDeliveryDate(PurchaseObjectClass ObjOrder)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Remarks", Convert.ToInt32(CommonHelper.OrderRemarks.OI));
            param[1] = new SqlParameter("@DeliveryDate", ObjOrder.OrderDeliveryDate);
            object o = SQLHelper.Instance.GetScalar("SP_Get_OrderInvoice", param);
            return o;
        }

        public Boolean Update_Order_Invoice(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@OrderInvoice", ObjPurchase.OrderInvoiceNo);
            param[1] = new SqlParameter("@DeliveryDate", ObjPurchase.OrderDeliveryDate);
            param[2] = new SqlParameter("@Remarks", Convert.ToInt32(CommonHelper.OrderRemarks.OI));
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_DeliveryDate", param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /////Spoiled Item Invoice \\\\\
        public List<PurchaseObjectClass> SpoiledInvoiceList()
        {
            try
            {
                List<PurchaseObjectClass> spoiledItemList = new List<PurchaseObjectClass>();
                string Query = "Select OrderID,OrderInvoice,AgentID,NetAmount,OrderDate,DeliveryDate,Discount,Remarks,DiscountType,SaleID,Year,YearSequenceNo,OriginalDiscount,Note,Status From dbo.[Order] Where OrderInvoice=(Select MaxId From KeySequence Where TableId=16) AND Remarks=1";
                var result = SQLHelper.Instance.GetReader(Query);
                FillOrderInvoiceDetails(spoiledItemList, result);
                return spoiledItemList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }

        public DataTable GetItemExpiry(string InvoiceFlag,int ItemID)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FLAG", InvoiceFlag);
            // new added on 23/04/2014
            param[1] = new SqlParameter("@ItemID", ItemID);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_ITEM_EXPIRY, param, "MTB_ORDER");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSerialNo(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                DataTable dt = new DataTable();
                dt = SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_ITEM_SERIALNO, param, "ItemSerialNo");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public DataTable SerialNoBasedonStock(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                param[1] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
                DataTable dt = new DataTable();
                dt = SQLHelper.Instance.ExecuteQueryDatatable("Sp_GetStock_basedserialno_A", param, "Purchase");
                return dt;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable get_stock_basedexpiry(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                param[1] = new SqlParameter("@Expiry", ObjPurchase.ItemExpiryDate==null||ObjPurchase.ItemExpiryDate==DateTime.MinValue?DBNull.Value:(object)ObjPurchase.ItemExpiryDate);
                param[2] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
                DataTable dt = new DataTable();
                dt = SQLHelper.Instance.ExecuteQueryDatatable("Sp_GetStock_basedexpiry_A", param, "Purchase");
                return dt;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DataTable Get_SpoiledItemDetails()
        {
            SqlParameter[] param=new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Get_SpoiledItems", param, "SpoiledItem");
        }
        /////Report Values\\\\\\\

        public DataTable GetReportValues(long InvoiceNo,int Remarks)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@InvoiceNo",InvoiceNo);
                param[1] = new SqlParameter("@Remarks", Remarks);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_Order_Inv", param, "Oreder");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public List<PurchaseObjectClass> GetPurchasedItem(PurchaseObjectClass ObjPurchase)
        {
            try
            {

                List<PurchaseObjectClass> listOfPurchasedItem = new List<PurchaseObjectClass>();
               var result=  SQLHelper.Instance.GetReader("usp_Get_SpoiledItemDetails", null);
                while (result.Read())
                {
                    listOfPurchasedItem.Add(new PurchaseObjectClass
                    {
                        ItemNo  = Convert.ToInt32(result["ItemID"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        BarcodeID  =Convert.ToInt32( result["BarcodeID"]),
                      
                        ItemName  = result["ItemName"].ToString(),
                      
                      
                        StockID   = Convert.ToInt32(result["ID"]),
                        ItemCost  = Convert.ToDecimal (result["Cost"]),
                        ItemExpiryDate   = Convert.ToDateTime (result["Expiry"]),
                        ItemSerialNo  = result["SerialNo"].ToString(),
                        Status  = Convert.ToInt32 (result["Status"]),
                        TotalStock =Convert.ToInt32(result["SumOfStock"]),
                        ItemNumber =result["ItemNumber"].ToString(),
                        ItemPackage =Convert.ToInt32( result["PackageQty"])


                    });

                }
                return listOfPurchasedItem;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public List<PurchaseObjectClass> Get_SpoiledItemDetailsLoad(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                List<PurchaseObjectClass> listOfSpoiledItem = new List<PurchaseObjectClass>();
                var result = SQLHelper.Instance.GetReader("Sp_Get_Itemno_Stock_m_A", null);
                while (result.Read())
                {
                    listOfSpoiledItem.Add(new PurchaseObjectClass
                    {
                        ItemNo = Convert.ToInt32(result["ItemID"]),
                        ItemName = result["ItemName"].ToString(),
                        ItemNumber  =result["ItemNumber"].ToString(),

                       
                    });
                  
                }
                  return listOfSpoiledItem;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public DataTable GetAllItemOnlyinStock()
        {
            SqlParameter[] param=new SqlParameter[0];
            DataTable dtItems = SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_Itemno_Stock_m_A", param, "AllItems");
            return dtItems;
        }
        public DataTable GetAllItemforOrder(int CatID,int ComID)
        {
            SqlParameter[] param=new SqlParameter[2];
            param[0] = new SqlParameter("@CategoryID", CatID);
            param[1] = new SqlParameter("@CompanyID", ComID);
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_OrderItemCategoryOrCompany", param, "AllItems");
            
        }
    }
}
