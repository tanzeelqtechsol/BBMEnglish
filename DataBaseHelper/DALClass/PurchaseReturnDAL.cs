using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;

namespace DataBaseHelper.DALClass
{
    public class PurchaseReturnDAL
    {

        //public int GetReturnInvoiceNo()
        //{
        //    try
        //    {
        //        int PurchaseReturnId = -1;
        //        var Query = "SELECT ISNULL(MAX(PurchaseReturnID),0)+1 FROM [PurchaseReturn]";
        //        using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
        //        {
        //            SQLHelper.Instance.conn.Open();
        //            sqlCmd.CommandType = CommandType.Text;
        //            var result = sqlCmd.ExecuteReader();
        //            while (result.Read())
        //            {
        //                PurchaseReturnId = Convert.ToInt32(result[0]);
        //            }
        //        }
        //        return PurchaseReturnId;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        SQLHelper.Instance.conn.Close();
        //    }
        //}

        //public DataTable GetMinMaxID()
        //{
        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[0];
        //        ds = SQLHelper.Instance.ExecuteDatatableWithQuery(StoredProcedurers.GET_RETURN_MAXMIN_ID, param, "ReturnID");
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public DataTable GetReturnPurchaseInvoice(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            param[0].Value = ObjPurchase.FromDate;
            param[1] = new SqlParameter("@todate", SqlDbType.DateTime);
            param[1].Value = ObjPurchase.ToDate;
            param[2] = new SqlParameter("@alldate", ObjPurchase.SetStatus);
            param[3] = new SqlParameter("@agent", ObjPurchase.SupplierNo);
            param[4] = new SqlParameter("@item", ObjPurchase.ItemNo);

            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_RETURN_PURCHASEINVOICE, param, "PurchaseReturn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetReturnPurchaseInvoice_byinvoice(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            param[0].Value = ObjPurchase.FromDate;
            param[1] = new SqlParameter("@todate", SqlDbType.DateTime);
            param[1].Value = ObjPurchase.ToDate;
            param[2] = new SqlParameter("@alldate", ObjPurchase.SetStatus);
            param[3] = new SqlParameter("@agent", ObjPurchase.SupplierNo);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_PURCHASEDETAIL_BYINVOICE, param, "PurchaseReturn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPurchaseLoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[0];
              //  var Query = "Select * From PurchaseReturn Where PurchaseReturnID=(Select MaxId From KeySequence Where TableId=9)";Commended on 23/06/2014
                var Query = "Select TOP 1 ReturnID,PurchaseReturnID,AgentID,Year,YearSequenceNo From PurchaseReturn Where PurchaseReturnID=(Select MaxId From KeySequence Where TableId=9)";
                dt = SQLHelper.Instance.ExecuteDatatableWithQuery(Query, param, "ReturnInvoice");
                return dt;
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

        public Boolean Save_Return_Purchase_Invoice(PurchaseObjectClass ObjPurchase)
        {

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@PurchaseReturnID", ObjPurchase.PurchaseReturnID);
            param[1] = new SqlParameter("@PurchaseID", ObjPurchase.PurchaseID);
            param[2] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[3] = new SqlParameter("@AccountID", ObjPurchase.AccountID);
            param[4] = new SqlParameter("@ReturnDate", ObjPurchase.ReturnDate);
            param[5] = new SqlParameter("@Quantity", ObjPurchase.ItemQuantity);
            param[6] = new SqlParameter("@UnitPrice", ObjPurchase.ItemUnitPrice);
            param[7] = new SqlParameter("@Reason", ObjPurchase.Reason);
            param[8] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
            param[9] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
            param[10] = new SqlParameter("@Status", ObjPurchase.Status);
            param[11] = new SqlParameter("@Cost", ObjPurchase.ItemCost);
            param[12] = new SqlParameter("@Expiry", ObjPurchase.ItemExpiryDate == null || ObjPurchase.ItemExpiryDate == DateTime.MinValue ? DBNull.Value : (object)ObjPurchase.ItemExpiryDate);
            param[13] = new SqlParameter("@PurchaseDetailID", ObjPurchase.PurchaseDetailsId);
            param[14] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[15] = new SqlParameter("@Agent_ID", ObjPurchase.SupplierNo);
            param[16] = new SqlParameter("@NewCost", ObjPurchase.NewCost);
            try
            {
                if ((SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_PURCHASE_RETURN, param)) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public DataTable GetReturnInvoiceDetailsDAL(long ReturnInvoiceNo)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PurchaseReturnID", ReturnInvoiceNo);
                dt = SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_PURCHASE_RETURN_DETAIL, param, "PurchaseReturn");
                return dt;
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

        public DataTable GetItemNameCostInfo(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                param[1] = new SqlParameter("@Cost", ObjPurchase.ItemCost);
                param[2] = new SqlParameter("@expiry", ObjPurchase.ItemExpiryDate==null||ObjPurchase.ItemExpiryDate==DateTime.MinValue?null:ObjPurchase.ItemExpiryDate);
                DataTable dt = SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_ITEMSTOCK_COUNT, param, "StockCount");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReturnPurchase(long ReturnInvoiceNo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PurchaseReturnID", ReturnInvoiceNo);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.LOAD_PURCHASELIST, param, "PurchaseReturn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Close_Purchase_Return(PurchaseObjectClass Objpurchase)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@PurReturnID", Objpurchase.PurchaseReturnID);
            param[1] = new SqlParameter("@PurchaseID", Objpurchase.PurchaseID);
            param[2] = new SqlParameter("@ItemID", Objpurchase.ItemNo);
            param[3] = new SqlParameter("@AccountID", Objpurchase.AccountID);
            param[4] = new SqlParameter("@ReturnDate", Objpurchase.ReturnDate);
            param[5] = new SqlParameter("@Quantity", Objpurchase.ItemQuantity);
            param[6] = new SqlParameter("@UnitPrice", Objpurchase.ItemUnitPrice);
            param[7] = new SqlParameter("@Reason", Objpurchase.Reason);
            param[8] = new SqlParameter("@ModifiedBy", Objpurchase.ModifiedBy);
            param[9] = new SqlParameter("@Status", Objpurchase.Status);
            param[10] = new SqlParameter("@Cost", Objpurchase.ItemCost);
            param[11] = new SqlParameter("@Expiry", Objpurchase.ItemExpiryDate == null || Objpurchase.ItemExpiryDate == DateTime.MinValue ? DBNull.Value : (Object)Objpurchase.ItemExpiryDate);
            param[12] = new SqlParameter("@PurDetailID", Objpurchase.PurchaseDetailsId);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.CLOSE_INVOICE, param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean Modify_Purchase_Return(long PurchaseReturnID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PurchaseReturnID", PurchaseReturnID);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.RETURN_MODIFY_INVOICE, param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Boolean Undo_Purchase_Return(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@PurReturnID", ObjPurchase.PurchaseReturnID);
            param[1] = new SqlParameter("@PurchaseID", ObjPurchase.PurchaseID);
            param[2] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[3] = new SqlParameter("@Qty", ObjPurchase.ItemQuantity);
            param[4] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
            param[5] = new SqlParameter("@Update", ObjPurchase.Status);
            param[6] = new SqlParameter("@Cost", ObjPurchase.NewCost);
            param[7] = new SqlParameter("@Expiry",ObjPurchase.ItemExpiryDate==DateTime.MinValue||ObjPurchase.ItemExpiryDate==null?DBNull.Value:(object)ObjPurchase.ItemExpiryDate);
            param[8] = new SqlParameter("@PurDetailsID", ObjPurchase.PurchaseDetailsId);
            param[9] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[10] = new SqlParameter("@NewCost", ObjPurchase.NewCost);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.UNDO_RETURN_PURCHASE, param)>0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable BalanceCheck(long PurchaseReturnID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PurReturnID", PurchaseReturnID);
                DataTable dt = new DataTable();
                SqlDataReader result = SQLHelper.Instance.GetReader(StoredProcedurers.CHECK_BALANCE, param);
                //result.Read();
                dt.Load(result);
                return dt;
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

        public DataTable ReportValues(long InvoiceNo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@InvoiceID", InvoiceNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_PurchaseReturn", param, "SimpleInvoice");
        }
        public int GetPurchaseIdWithYearSequenceNo(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                int PurchaseID = 0;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Year", ObjPurchase.Year);
                param[1] = new SqlParameter("@YearSequenceNo", ObjPurchase.NewYearInvoiceID);
                var result = SQLHelper.Instance.GetReaderWithQuery("Select PurchaseInvoiceID From Purchase Where [Year]=@Year And YearSequenceNo=@YearSequenceNo", param);
                if (result.Read())
                {
                    PurchaseID = Convert.ToInt32(result["PurchaseInvoiceID"]);
                }
                return PurchaseID;
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
    }
}
