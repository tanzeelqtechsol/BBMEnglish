using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;


namespace DataBaseHelper.DALClass
{
    public class PurchaseDALClass
    {
        internal static object InvoiceNo;
        public List<PurchaseObjectClass> PurchaseItemList = new List<PurchaseObjectClass>();
        public List<int> MaxMinNo = new List<int>();
        public List<PurchaseObjectClass> PurchaseDetails = new List<PurchaseObjectClass>();
        MasterDataDALClass ObjMasterDAL = new MasterDataDALClass();

        public DataSet GetPurchaseLoad()
        {
            SqlParameter[] param = new SqlParameter[0];
            DataSet ds = new DataSet();
            try
            {
                //  ds = SQLHelper.Instance.ExecuteQueryDataset("SP_GetPurchaseLoad", param, "MTB_PURCHASE");

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseObjectClass> GetPurchaseLoadData()
        {
            List<PurchaseObjectClass> LoadList = new List<PurchaseObjectClass>();
            try
            {
                //string Query = "Select * From Purchase Where PurchaseInvoiceID=(Select MaxId From KeySequence Where TableId=2)";
                string Query = "Select PurchaseID,PurchaseInvoiceID,AgentID,Year,YearSequenceNo,ExchangeRate,ISNULL(InNo,'') as InNo  From Purchase Where PurchaseInvoiceID=(Select MaxId From KeySequence Where TableId=2)";
                var result = SQLHelper.Instance.GetReader(Query);
                while (result.Read())
                {
                    LoadList.Add(new PurchaseObjectClass
                    {
                        PurchaseID = Convert.ToInt32(result["PurchaseID"]),
                        InvoiceNo = Convert.ToInt32(result["PurchaseInvoiceID"]),
                        SupplierNo = Convert.ToInt32(result["AgentID"]),
                        //AccountID = Convert.ToInt32(result["AccountID"]),
                        //PurchaseItemDate = Convert.ToDateTime(result["PurchaseDate"]).Date,
                        //Balance = Convert.ToDecimal(result["Balance"]),
                        //ItemGrossAmt = Convert.ToDecimal(result["GrossAmount"]),
                        //Tax = Convert.ToDecimal(result["Tax"]),
                        //ItemNet = Convert.ToDecimal(result["NetAmount"]),
                        //Discount = Convert.ToDecimal(result["Discount"]),
                        //ItemPaymentDate = (Convert.ToDateTime(result["PaymentDate"] == DBNull.Value ? null : result["PaymentDate"])).Date,
                        //DiscountType = Convert.ToInt32(result["DiscountType"]),
                        //Tax1 = Convert.ToDecimal(result["Tax1"]),
                        Year = Convert.ToInt32(result["Year"]),
                        NewYearInvoiceID = Convert.ToInt32(result["YearSequenceNo"]),
                        //FlagTax1Percentage = Convert.ToDecimal(result["TaxPercentage"]),
                        //FlagTax1SubPercentage = Convert.ToDecimal(result["TaxSub"]),
                        //FlagTax2Percentage = Convert.ToDecimal(result["Tax1Percentage"]),
                        //FlagTax2SubPercentage = Convert.ToDecimal(result["Tax1Sub"]),
                        //originaldiscount = Convert.ToDecimal(result["OriginalDiscount"]),
                        //Note = result["Note"].ToString(),
                        //Status = Convert.ToInt32(result["Status"])
                        ExchangeRate = Convert.ToDecimal(result["ExchangeRate"] == DBNull.Value ? 0 : result["ExchangeRate"]),
                        InNo = result["InNo"].ToString()
                    });
                }
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

        //public List<long> GetYearSequenceMaxID()
        //{
        //    List<long> InvoiceID = new List<long>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@TableId", CommonHelper.Table.Purchase);
        //        param[1] = new SqlParameter("@Flag", "Normal");
        //        var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_NEXT_ID, param);
        //        while (result.Read())
        //        {
        //            InvoiceID.Add(Convert.ToInt64(result["MaxId"]));
        //            InvoiceID.Add(Convert.ToInt64(result["YearValue"]));
        //            InvoiceID.Add(Convert.ToInt64(result["YearMaxId"]));

        //        }
        //        return InvoiceID;
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

        public List<PurchaseObjectClass> LoadPurchaseData()
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("SP_GetPurchaseLoad", SQLHelper.Instance.conn))
                {
                    if (SQLHelper.Instance.OpenConnection())
                    {

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        var result = sqlCmd.ExecuteReader();
                        PurchaseItemLoad(PurchaseItemList, result);
                        //result.NextResult();
                        ////  PurchaseMaxMinNo(MaxMinNo, result);
                        ////  result.NextResult();
                        ////PurchaseDetailsList(PurchaseDetails, result);Commended on 23/06/2014 to fix the performance issue by Meena.R
                        //  result.NextResult();
                        //  while (result.Read())
                        //  {
                        //      InvoiceNo = result[0];
                        //  }
                    }

                }
                return PurchaseItemList;
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

        public List<PurchaseObjectClass> LoadNewPurchaseData()
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("SP_GetNewPurchaseLoad", SQLHelper.Instance.conn))
                {
                    if (SQLHelper.Instance.OpenConnection())
                    {

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        var result = sqlCmd.ExecuteReader();
                        PurchaseItemLoad(PurchaseItemList, result);
                    }

                }
                return PurchaseItemList;
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



        public DataTable LoadItem()
        {
            try
            {
                //DataTable dtItem = new DataTable();
                //using (SqlCommand sqlCmd = new SqlCommand("SELECT ItemID as ItemNo,ItemName FROM dbo.Item WHERE Status = 1", SQLHelper.Instance.conn))
                //{
                //    if (SQLHelper.Instance.OpenConnection())
                //    {
                //        sqlCmd.CommandType = CommandType.Text;
                //        SqlDataAdapter dr = new SqlDataAdapter(sqlCmd);
                //        dr.Fill(dtItem);
                //    }
                //}
                //return dtItem;
                SqlParameter[] param = new SqlParameter[0];
                return SQLHelper.Instance.ExecuteQueryDatatable("SP_GetNewPurchaseLoad", param, "Item");
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

        //public List<PurchaseObjectClass> PurchaseList(PurchaseObjectClass ObjPurchase)
        //{
        //    List<PurchaseObjectClass> PurchaseList = new List<PurchaseObjectClass>();
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@Invoice", ObjPurchase.InvoiceNo);
        //    var result = SQLHelper.Instance.GetReader("usp_BBM_Get_Purchase", param);
        //    PurchaseDetailsList(PurchaseDetailsList, result);

        //}
        /// <summary>
        /// this method created to fix the performance issue 
        /// Created Date:23/06/2014
        /// Created By :Meena.R
        /// </summary>
        /// <returns></returns>
        public List<PurchaseObjectClass> PurchaseInvoiceDetails()
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("SP_Get_PurchaseInvoice", SQLHelper.Instance.conn))
                {
                    if (SQLHelper.Instance.OpenConnection())
                    {

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        var result = sqlCmd.ExecuteReader();
                        PurchaseDetailsList(PurchaseDetails, result);
                    }
                }
                return PurchaseDetails;
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

        public List<PurchaseObjectClass> NewPurchaseInvoiceDetails()
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand("SP_GetNewPurchaseLoad", SQLHelper.Instance.conn))
                {
                    if (SQLHelper.Instance.OpenConnection())
                    {

                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        var result = sqlCmd.ExecuteReader();
                        PurchaseDetailsList(PurchaseDetails, result);
                    }
                }
                return PurchaseDetails;
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
        private static void PurchaseDetailsList(List<PurchaseObjectClass> PurchaseDetails, SqlDataReader result)
        {
            PurchaseDetails.Clear();
            while (result.Read())
            {
                PurchaseDetails.Add(new PurchaseObjectClass
                {
                    PurchaseID = Convert.ToInt32(result["PurchaseID"]),
                    InvoiceNo = Convert.ToInt32(result["PurchaseInvoiceID"]),
                    SupplierNo = Convert.ToInt32(result["AgentID"]),
                    AccountID = Convert.ToInt32(result["AccountID"]),
                    PurchaseItemDate = Convert.ToDateTime(result["PurchaseDate"]).Date,
                    Balance = Convert.ToDecimal(result["Balance"]),
                    ItemGrossAmt = Convert.ToDecimal(result["GrossAmount"]),
                    Tax = Convert.ToDecimal(result["Tax"]),
                    ItemNet = Convert.ToDecimal(result["NetAmount"]),
                    Discount = Convert.ToDecimal(result["Discount"]),
                    ItemPaymentDate = (Convert.ToDateTime(result["PaymentDate"] == DBNull.Value ? null : result["PaymentDate"])).Date,
                    DiscountType = Convert.ToInt32(result["DiscountType"]),
                    Tax1 = Convert.ToDecimal(result["Tax1"]),
                    NewYearInvoiceID = Convert.ToInt32(result["YearSequenceNo"]),
                    FlagTax1Percentage = Convert.ToDecimal(result["TaxPercentage"]),
                    FlagTax1SubPercentage = Convert.ToDecimal(result["TaxSub"]),
                    FlagTax2Percentage = Convert.ToDecimal(result["Tax1Percentage"]),
                    FlagTax2SubPercentage = Convert.ToDecimal(result["Tax1Sub"]),
                    originaldiscount = Convert.ToDecimal(result["OriginalDiscount"]),
                    Note = result["Note"].ToString()
                });
            }
        }

        public static List<int> PurchaseMaxMinNo(List<int> MaxMinNo, SqlDataReader result)
        {

            MaxMinNo.Clear();
            while (result.Read())
            {

                MaxMinNo.Add(Convert.ToInt32(result[0]));
                MaxMinNo.Add(Convert.ToInt32(result[1]));


            }
            return MaxMinNo;
        }

        public static List<PurchaseObjectClass> PurchaseItemLoad(List<PurchaseObjectClass> PurchaseList, SqlDataReader result)
        {
            PurchaseList.Clear();
            while (result.Read())
            {
                //PurchaseList.Add(new PurchaseObjectClass
                //{

                //    ItemNo = Convert.ToInt32(result[0]),
                //    ItemName = result[1].ToString(),
                //    CategoryNo = Convert.ToInt32(result[2]),
                //    CompanyNo = Convert.ToInt32(result[3]),
                //    Reorder = Convert.ToInt32(result[4]),
                //    PurchaseQuantity = Convert.ToInt32(result[5] == DBNull.Value ? 0 : result[5]),
                //    CategoryName = result[7].ToString(),
                //    CompanyName = result[8].ToString(),
                //    ItemNumber = result[9] == DBNull.Value ? string.Empty : result[9].ToString(),
                //    IsHide = Convert.ToBoolean(result[10] == DBNull.Value ? false : result[10])
                //});


                PurchaseList.Add(new PurchaseObjectClass
                {
                    ItemNo = Convert.ToInt32(result[0]),
                    ItemName = result[1].ToString(),
                    ItemNumber = result[2] == DBNull.Value ? string.Empty : result[2].ToString(),
                    IsHide = Convert.ToBoolean(result[3] == DBNull.Value ? false : result[3])
                });
            }
            return PurchaseList;
        }

        public DataSet GetItemDetails()
        {
            SqlParameter[] param = new SqlParameter[0];
            DataSet ds = new DataSet();
            try
            {
                ds = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_PURCHASE_LOAD, param, "MTB_PURCHASE");
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetSupllier()
        {

            var Query = "select AgentID,AgentName from Agent where AgentTypeID like '%102%'and Status=1 order by AgentName";
            //    //try
            //    //{
            //    //    Dictionary<int, string> list = new Dictionary<int, string>();
            //    //    //List<string> list=new List<string>();
            //    //    list = SQLHelper.Instance.Reader(Query, null);
            //    //    foreach (var value in list)
            //    //    {
            //    //        GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierNo = value.Key, SupplierName = value.Value });
            //    //    }
            //    //    //GeneralObjectClass.SupplierDetails = list;
            //    //}
            //    //var List = new List<PurchaseObjectClass>();

            //    //using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
            //    //{
            //    //    SQLHelper.Instance.conn.Open();
            //    //    sqlCmd.CommandType = CommandType.Text;
            //    //    var result = sqlCmd.ExecuteReader();



            //        while (result.Read())
            //        {
            //            //List.Add(new PurchaseObjectClass()
            //            // { 
            //            //     SupplierNo = result.GetInt32(result.GetOrdinal("AgentID")),
            //            //     SupplierName =result.GetString(result.GetOrdinal("AgentName")),
            //            // });
            //            //GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierNo = Convert.ToInt32(result[0]), SupplierName = result[1].ToString() });




            //    //foreach (DataRow dr in result)
            ////{
            ////    agent = new AgentDetailObjectClass();
            ////    agent.AgentId = (int)dr["AgentId"];
            ////    agentList.Add(agent);
            ////}
            ////agentList.Where(a => a.AgentId == 102) ;


            //    //SqlParameter[] sqlparam = new SqlParameter[0];
            ////dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_AllAgentNames", sqlparam, "Details");
            //////Following Codes are added to fill the AgentDropdwnList list on 15/11/2013 by seenivasan
            ////if (dtLocal != null && dtLocal.Rows.Count > 0)
            ////{
            ////    foreach (DataRow row in dtLocal.Rows)
            ////    {
            ////        int intAgentId = Convert.ToInt16(row["AgentID"].ToString());
            ////        GeneralObjectClass.AgentDropdwnList.Add(new AgentDetailObjectClass { Name = row["AgentName"].ToString(), AgentId = intAgentId });
            ////        DataView Filter;
            ////        Filter=new DataView(dtLocal);
            ////        GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierName = Filter.RowFilter = "AgentID==102"});
            ////    }
            ////}
            SqlDataReader result = ExecuteReader(Query);
            while (result.Read())
            {

            }


        }

        public object GetNewInvoiceNo()
        {
            SqlParameter[] param = new SqlParameter[0];
            try
            {
                return SQLHelper.Instance.GetScalar("SP_Get_NewPurchaseNo", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save_Purchase_Invoice(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[48];
                param[0] = new SqlParameter("@PurchaseInvID", ObjPurchase.InvoiceNo);
                param[1] = new SqlParameter("@AgentID", ObjPurchase.SupplierNo);
                param[2] = new SqlParameter("@AccountID", ObjPurchase.AccountID);
                param[3] = new SqlParameter("@PurchaseDate", ObjPurchase.PurchaseItemDate);
                param[4] = new SqlParameter("@Balance", ObjPurchase.ItemBalance);
                param[5] = new SqlParameter("@GrossAmt", ObjPurchase.ItemGrossAmt);
                param[6] = new SqlParameter("@Tax", ObjPurchase.Tax);
                param[7] = new SqlParameter("@NetAmt", ObjPurchase.ItemNet);
                param[8] = new SqlParameter("@Discount", ObjPurchase.Discount);
                param[9] = new SqlParameter("@PaymentDate", ObjPurchase.SetPaymentDate == true ? (object)ObjPurchase.ItemPaymentDate : DBNull.Value);
                param[10] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
                param[11] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
                param[12] = new SqlParameter("@Status", ObjPurchase.Status);
                param[13] = new SqlParameter("@SetStatus", ObjPurchase.SetStatus);
                param[14] = new SqlParameter("@BatchID", ObjPurchase.BatchID);
                param[15] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                param[16] = new SqlParameter("@Qty", ObjPurchase.ItemQuantity);
                param[17] = new SqlParameter("@UnitPrice", ObjPurchase.ItemUnitPrice);
                param[18] = new SqlParameter("@ExpiryDate", ObjPurchase.ItemExpiryDate == null ? DBNull.Value : (object)ObjPurchase.ItemExpiryDate);
                param[19] = new SqlParameter("@ItemCost", ObjPurchase.ItemCost);
                param[20] = new SqlParameter("@ItemLastCost", ObjPurchase.ItemCost);
                param[21] = new SqlParameter("@Price", ObjPurchase.ItemUnitPrice);
                param[22] = new SqlParameter("@SalePrice", ObjPurchase.SalePrice);
                param[23] = new SqlParameter("@Cost", ObjPurchase.PurchaseCost);
                param[24] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo == null || ObjPurchase.ItemSerialNo == string.Empty ? "0" : ObjPurchase.ItemSerialNo);
                param[25] = new SqlParameter("@DiscountType", ObjPurchase.DiscountType);
                param[26] = new SqlParameter("@Tax1", ObjPurchase.Tax1);
                param[27] = new SqlParameter("@ItemDiscount", ObjPurchase.ItemDiscount);
                param[28] = new SqlParameter("@ItemExtraCost", ObjPurchase.Extracost);
                param[29] = new SqlParameter("@DiscountCost", ObjPurchase.EachItemExtraCost);
                param[30] = new SqlParameter("@ItemTax1", ObjPurchase.ItemTax1);
                param[31] = new SqlParameter("@ItemTax2", ObjPurchase.ItemTax2);
                param[32] = new SqlParameter("@TaxPer", ObjPurchase.FlagTax1Percentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax1Percentage);
                param[33] = new SqlParameter("@TaxSub", ObjPurchase.FlagTax1SubPercentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax1SubPercentage);
                param[34] = new SqlParameter("@Tax1_Per", ObjPurchase.FlagTax2Percentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax2Percentage);
                param[35] = new SqlParameter("@Tax1_Sub", ObjPurchase.FlagTax2SubPercentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax2SubPercentage);
                param[36] = new SqlParameter("@OriginalDis", ObjPurchase.originaldiscount);
                param[37] = new SqlParameter("@Note", (ObjPurchase.Note != null) ? ObjPurchase.Note : "");
                param[38] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);///added to Purchase Different package quantity of Item on 30/04/2014
                param[39] = new SqlParameter("@Box", ObjPurchase.Box);//added on 16/05/2014     
                param[40] = new SqlParameter("@SubTax1", ObjPurchase.ItemTax1SubAmount);
                param[41] = new SqlParameter("@SubTax2", ObjPurchase.ItemTax2SubAmount);
                param[42] = new SqlParameter("@ActualUnitPrice", ObjPurchase.ActualUnitPrice);
                param[43] = new SqlParameter("@TotalAmount", ObjPurchase.ItemTotalAmount);
                param[44] = new SqlParameter("@YearSequenceNo", ObjPurchase.NewYearInvoiceID);
                param[45] = new SqlParameter("@ExchangeRate", ObjPurchase.ExchangeRate);
                param[46] = new SqlParameter("@PurchaseDetail_ID", ObjPurchase.PurchaseItemdDetail_ID);
                param[47] = new SqlParameter("@InNo", ObjPurchase.InNo);
                if ((SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_PURCHASE_INVOICE, param)) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {

                return 0;
            }
  
        }


        #region SaveSaleDetailsOnClosing
        public bool SaveSaleDetailOnCloseDT(DataTable dt)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Purchase", dt);

                if (SQLHelper.Instance.ExecuteNonQuery("uspUpdatePurchaseDetail", param) > 0)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public SqlDataReader ExecuteReader(string Query)
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    return result;
                }
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
        public DataTable GetPurchasePaidRemainingByID(PurchaseObjectClass ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@InvoiceNo", ObjSale.InvoiceNo);
                return SQLHelper.Instance.ExecuteQueryDatatable("Get_PaidAndRemainingAmountByPurchaseID", Param, "PaidRemaining");
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
                param[10] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo == string.Empty || ObjPurchase.ItemSerialNo == null ? "0" : ObjPurchase.ItemSerialNo);
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

        public int Update_PurchasePaymentDate(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PurchaseInvID", ObjPurchase.InvoiceNo);
            param[1] = new SqlParameter("@PaymentDate", ObjPurchase.ItemPaymentDate);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_PaymentDate", param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseObjectClass> GetPurchaseInvoiceDetails(PurchaseObjectClass ObjPurchase)
        {
            List<PurchaseObjectClass> InvoiceDetails = new List<PurchaseObjectClass>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PurchaseInvoiceID", ObjPurchase.InvoiceNo);
            try
            {
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_PURCHASEINVOICE_DETAILS, param);
                while (result.Read())
                {
                    InvoiceDetails.Add(new PurchaseObjectClass
                    {
                        
                        ExchangeRate = Convert.ToDecimal(result["ExchangeRate"] == DBNull.Value ? 0 : result["ExchangeRate"]),
                        InvoiceNo = Convert.ToInt32(result["PurchaseInvoiceID"]),
                        NewYearInvoiceID = Convert.ToInt32(result["YearSequenceNo"]),
                        Year = Convert.ToInt32(result["Year"]),
                        ItemNo = Convert.ToInt32(result["ItemID"]),
                        SupplierNo = Convert.ToInt32(result["AgentID"]),
                        SupplierName = result["AgentName"].ToString(),
                        ItemQuantity = Convert.ToInt32(result["Quantity"]),
                        ItemUnitPrice = Convert.ToDecimal(result["UnitPrice"]),
                        ItemTotal = Convert.ToDecimal(result["Total"]),
                        //ItemExpiryDate = Convert.ToDateTime(result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"]),
                        ItemExpiryDate = (Convert.ToDateTime(result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"])) == DateTime.MinValue ? (DateTime?)null : Convert.ToDateTime(result["ExpiryDate"]),
                        ItemExpiry = result["ExpiryDate"] == DBNull.Value ? "-" : Convert.ToDateTime(result["ExpiryDate"]).ToString().Split(' ').Length > 2 ? Convert.ToDateTime(result["ExpiryDate"]).ToString().Split()[1] : Convert.ToDateTime(result["ExpiryDate"]).ToString().Split()[0],
                        ReturnQty = Convert.ToInt32(result["ReturnQuantity"] == DBNull.Value ? 0 : result["ReturnQuantity"]),
                        Discount = Convert.ToDecimal(result["Discount"]),
                        ItemNet = Convert.ToDecimal(result["NetAmount"]),
                        ItemPaymentDate = Convert.ToDateTime(result["PaymentDate"] != DBNull.Value ? result["PaymentDate"] : null).Date,
                        Status = Convert.ToInt32(result["Status"]),
                        ItemName = result["ItemName"].ToString(),
                        ItemDescription = result["ItemName"].ToString(),
                        ItemPackage = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                        ItemPrice = Convert.ToDecimal(result["Price"]),
                        PurchaseCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                        CreatedBy = Convert.ToInt32(result["CreatedBy"] == DBNull.Value ? 101 : result["CreatedBy"]),
                        PurchaseItemDate = Convert.ToDateTime(result["PurchaseDate"]).Date,
                        SalePrice = Convert.ToDecimal(result["SalePrice"]),
                        ItemCost = Convert.ToDecimal(result["Cost"] == DBNull.Value ? 0.000m : result["Cost"]),
                        //ItemSerialNo = Convert.ToInt64(result["SerialNo"]),
                        ItemSerialNo = result["SerialNo"].ToString(),
                        DiscountType = Convert.ToInt32(result["DiscountType"]),
                        ItemGrossAmt = Convert.ToDecimal(result["GrossAmount"]),
                        ItemDiscount = Convert.ToDecimal(result["ItemDiscount"]),
                        NewCost = Convert.ToDecimal(result["NewCost"]),
                        ItemTax1 = Convert.ToDecimal(result["ItemTax1"]),
                        ItemTax2 = Convert.ToDecimal(result["ItemTax2"]),
                        originaldiscount = Convert.ToDecimal(result["OriginalDiscount"]),
                        Note = result["note"].ToString(),
                        ItemNumber = result["ItemNumber"].ToString(),
                        Time = result["Time"].ToString(),
                        BarcodeID = Convert.ToInt32(result["BarcodeID"] == DBNull.Value ? 0 : result["BarcodeID"]),
                        Box = Convert.ToInt32(result["Box"] == DBNull.Value ? 0 : result["Box"]),
                        ItemTax1SubAmount = Convert.ToDecimal(result["SubTax1"] == DBNull.Value ? 0 : result["SubTax1"]),
                        ItemTax2SubAmount = Convert.ToDecimal(result["SubTax2"] == DBNull.Value ? 0 : result["SubTax2"]),
                        PurchaseDetailsId = Convert.ToInt32(result["PurchaseDetailID"]),
                        InNo = result["InNo"].ToString(),
                    });
                }
                return InvoiceDetails;
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

        //public List<PurchaseObjectClass> GetItemNameInfo(PurchaseObjectClass ObjPurchase)
        //{
        //    try
        //    {
        //        List<PurchaseObjectClass> ItemInfoList = new List<PurchaseObjectClass>();
        //        using (SqlCommand sqlCmd = new SqlCommand(StoredProcedurers.GET_ITEMNAMEINFO, SQLHelper.Instance.conn))
        //        {
        //            SQLHelper.Instance.conn.Open();
        //            SqlParameter[] param = new SqlParameter[1];
        //            param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
        //            if (param != null)
        //            {
        //                sqlCmd.CommandType = CommandType.StoredProcedure;
        //                sqlCmd.Parameters.AddRange(param);
        //            }

        //            var result = sqlCmd.ExecuteReader();
        //            while (result.Read())
        //            {
        //                ItemInfoList.Add(new PurchaseObjectClass
        //                {
        //                    ItemNo = Convert.ToInt32(result["ItemID"]),
        //                    ItemName = result["ItemName"].ToString(),
        //                    ItemBarcode = result["Barcode"].ToString(),
        //                    CategoryNo = Convert.ToInt32(result["CategoryID"]),
        //                    ItemType = Convert.ToInt32(result["ItemType"]),
        //                    ItemPlaceID = Convert.ToInt32(result["ItemPlaceID"]),
        //                    ItemDescription = result["ItemDescription"].ToString(),
        //                    ItemUnitPrice = Convert.ToDecimal(result["Unit"]),
        //                    CompanyNo = Convert.ToInt32(result["CompanyID"]),
        //                    SupplierNo = Convert.ToInt32((result["AgentID"]) == DBNull.Value ? 0 : result["AgentID"]),
        //                    ItemCost = Convert.ToDecimal(result["ItemCost"]),
        //                    ItemLastCost = Convert.ToDecimal(result["ItemLastCost"]),
        //                    ItemPackage = Convert.ToInt32(result["PackageQty"]),
        //                    ExpiryDate = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? 0 : result["ExpiryDate"])),
        //                    Reorder = Convert.ToInt32(result["Reorder"]),
        //                    ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"]),
        //                    ItemPrice = Convert.ToDecimal(result["Price"]),
        //                    MaxOrder = Convert.ToInt32(result["MaxOrder"]),
        //                    ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"]),
        //                    AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"]),
        //                    CreatedBy = Convert.ToInt32(result["CreatedBy"]),
        //                    ModifiedBy = Convert.ToInt32(result["ModifiedBy"]),
        //                    Status = Convert.ToInt32(result["Status"]),
        //                    IsHide = Convert.ToBoolean(result["IsHide"]),
        //                    ItemExpiryDate = Convert.ToDateTime((result["ExpiryDate1"] == DBNull.Value ? null : result["ExpiryDate1"])),
        //                    ItemTotalStock = Convert.ToInt32(result["StockInHand"])
        //                });


        //            }

        //        }
        //        return ItemInfoList;

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

        public List<PurchaseObjectClass> checkforexpiry(PurchaseObjectClass ObjPurchase)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@itemid", ObjPurchase.ItemNo);
                List<PurchaseObjectClass> CheckExpiry = new List<PurchaseObjectClass>();
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_EXPIRY_COUNT, param);
                while (result.Read())
                {
                    CheckExpiry.Add(new PurchaseObjectClass
                    {
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"] == DBNull.Value ? null : result["Expiry"]),
                        ItemTotalStock = Convert.ToInt32(result["StockInHand"])
                    });

                }
                return CheckExpiry;
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

        //public int ModifyInvoice(PurchaseObjectClass ObjPurchase)
        //{
        //    SqlParameter[] param = new SqlParameter[2];
        //    param[0] = new SqlParameter("@InvoiceNo", ObjPurchase.InvoiceNo);
        //    param[1] = new SqlParameter("@InvoiceFlag", ObjPurchase.InvoiceFlag);
        //    try
        //    {
        //        if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.MODIFY_INVOICE, param) > 0)
        //            return 1;
        //        else
        //            return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public Object stock_for_Delete(PurchaseObjectClass ObjPurchase)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[1] = new SqlParameter("@Cost", ObjPurchase.ItemCost);
            param[2] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[3] = new SqlParameter("@ExpiryDate", ObjPurchase.ItemSerialNo == "0" ? ObjPurchase.ItemExpiryDate == null ? DBNull.Value : (object)ObjPurchase.ItemExpiryDate : DBNull.Value);
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

        public int Delete_Stock_Details(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[1] = new SqlParameter("@Quantity", ObjPurchase.ItemQuantity);
            param[2] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
            param[3] = new SqlParameter("@PurchaseID", ObjPurchase.InvoiceNo);
            param[4] = new SqlParameter("@ExpiryDate", ObjPurchase.ItemSerialNo == "0" ? ObjPurchase.ItemExpiryDate == null ? DBNull.Value : (object)ObjPurchase.ItemExpiryDate : DBNull.Value);
            param[5] = new SqlParameter("@UnitPrice", ObjPurchase.ItemUnitPrice);
            param[6] = new SqlParameter("@Status", ObjPurchase.Status);
            param[7] = new SqlParameter("@Cost", ObjPurchase.ItemCost);
            param[8] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[9] = new SqlParameter("@ProcessStatus", ObjPurchase.deletestatus);
            param[10] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
            param[11] = new SqlParameter("@Box", ObjPurchase.Box);
            try
            {
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.DELETE_STOCK, param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public DataSet GetMinMaxID(PurchaseObjectClass ObjPurchase)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[0];

        //        ds = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_MAX_MIN_ID, param, "Purchase");
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public DataTable CheckPayment(PurchaseObjectClass ObjPurchase)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PayDate", ObjPurchase.ItemPaymentDate);
                dt = SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.CHECK_PAYMENTDATE, param, "Purhcase");
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetPurchaseBalance(long InvoiceNo, int Flag)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PurchaseInvoiceID", SqlDbType.VarChar);
            param[0].Value = InvoiceNo;
            param[1] = new SqlParameter("@Flag", Flag);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_PURCHASE_BALANCE, param, "Purchase");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetItemBasedOnComCat(int CatComID, int Value)
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

        //public object GetInvoiceIDBasedonNewYearID(PurchaseObjectClass ObjPurchase)
        //{
        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@Year", ObjPurchase.Year);
        //    param[1] = new SqlParameter("@YearSequence", ObjPurchase.NewYearInvoiceID);
        //    param[2] = new SqlParameter("@TableId", Convert.ToInt32(CommonHelper.Table.Purchase));
        //    return SQLHelper.Instance.GetScalar(StoredProcedurers.GET_PURCHASEINVOICEID, param);
        //}


        ////////// ItemSerial No\\\\\\\\\\\\\\\\\\\\
        public List<PurchaseObjectClass> Get_ItemSerialNo_stock(int ItemID)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                List<PurchaseObjectClass> SerialNo = new List<PurchaseObjectClass>();
                sqlparam[0] = new SqlParameter("@ItemID", ItemID);
                var result = SQLHelper.Instance.GetReaderWithQuery("Select I.ItemName,S.SerialNo from Item I INNER JOIN ItemSerialNo S on I.ItemID=S.ItemID Where S.SerialNo IN(SELECT SerialNo FROM dbo.Stock (NOLOCK) WHERE StockInHand > 0) AND S.[Status]=1 AND I.ItemID=@ItemID", sqlparam);
                while (result.Read())
                {
                    SerialNo.Add(new PurchaseObjectClass
                    {
                        ItemName = result["ItemName"].ToString(),
                        //ItemSerialNo = Convert.ToInt64(result["SerialNo"])
                        ItemSerialNo = result["SerialNo"].ToString()
                    });

                }
                result.Close();
                return SerialNo;
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

        public int Save_ItemSerialNo(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                sqlparam[1] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
                sqlparam[2] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
                sqlparam[3] = new SqlParameter("@CreatedDate", DateTime.Now);
                sqlparam[4] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
                sqlparam[5] = new SqlParameter("@ModifiedDate", DateTime.Now);
                sqlparam[6] = new SqlParameter("@Status", ObjPurchase.Status);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_ITEM_SERIALNO, sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Update_ItemSerialNo(PurchaseObjectClass ObjPurchase, string SerialNo)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
                sqlparam[1] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
                sqlparam[2] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
                sqlparam[3] = new SqlParameter("@CreatedDate", DateTime.Now);
                sqlparam[4] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
                sqlparam[5] = new SqlParameter("@ModifiedDate", DateTime.Now);
                sqlparam[6] = new SqlParameter("@Status", ObjPurchase.Status);
                sqlparam[7] = new SqlParameter("@XSerialNo", SerialNo);
                if (SQLHelper.Instance.ExecuteNonQuery("usp_update_Item_SerialNumber", sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<PurchaseObjectClass> StockBasedSerialNo(PurchaseObjectClass objPurchase)
        {
            try
            {
                List<PurchaseObjectClass> SerialNoInfo = new List<PurchaseObjectClass>();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@itemid", objPurchase.ItemNo);
                param[1] = new SqlParameter("@serialno", objPurchase.ItemSerialNo);
                DataTable dt = new DataTable();
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GETSTOCK_BASED_SERIALNO, param);
                while (result.Read())
                {
                    SerialNoInfo.Add(new PurchaseObjectClass
                    {
                        ItemStock = Convert.ToInt32(result[0]),
                        ItemPrice = Convert.ToDecimal(result[1] == DBNull.Value ? 0.0m : result[1]),
                        ItemPackage = Convert.ToInt32(result[3] == DBNull.Value ? 0.0m : result[3])
                    });
                }
                result.Close();
                return SerialNoInfo;
            }
            catch (Exception ex)
            { throw ex; }
            finally { SQLHelper.Instance.conn.Close(); }
        }

        public int Save_ExportItemDetails(PurchaseObjectClass ObjPurchase, int OverWrite)
        {
            SqlParameter[] sqlparam = new SqlParameter[29];
            try
            {
                sqlparam[0] = new SqlParameter("@ItemID", SqlDbType.Int);
                sqlparam[0].Value = ObjPurchase.ItemNo;
                sqlparam[0].Direction = ParameterDirection.InputOutput;
                sqlparam[1] = new SqlParameter("@ItemName", ObjPurchase.ItemName);
                sqlparam[2] = new SqlParameter("@CategoryID ", ObjPurchase.CategoryNo);
                sqlparam[3] = new SqlParameter("@ItemType", ObjPurchase.ItemType);
                sqlparam[4] = new SqlParameter("@ItemPlaceID", ObjPurchase.ItemPlaceID);
                sqlparam[5] = new SqlParameter("@ItemDescription", "Product");// Obj_ItemProp.ItemDescription);
                sqlparam[6] = new SqlParameter("@Unit", ObjPurchase.ItemUnitPrice);//Obj_ItemProp.Unit );
                // sqlparam[7] = new SqlParameter("@ItemImage","");
                sqlparam[7] = new SqlParameter("@CompanyID", ObjPurchase.CompanyNo);
                sqlparam[8] = new SqlParameter("@ItemCost", ObjPurchase.ItemCost);
                sqlparam[9] = new SqlParameter("@ItemLastCost", 10);//Obj_ItemProp.ItemLastCost );
                sqlparam[10] = new SqlParameter("@PackageQty", ObjPurchase.ItemPackage);
                //sqlparam[11] = new SqlParameter("@ExpiryDate", ObjPurchase.ItemType == 1 ? 1 : 0);
                sqlparam[11] = new SqlParameter("@ExpiryDate", ObjPurchase.ExpiryDate);
                sqlparam[12] = new SqlParameter("@ItemReorder", ObjPurchase.Reorder);
                sqlparam[13] = new SqlParameter("@MaxOrder", ObjPurchase.MaxOrder);
                sqlparam[14] = new SqlParameter("@MinPrice", ObjPurchase.ItemMinimumPrice);
                sqlparam[15] = new SqlParameter("@Price", ObjPurchase.ItemPrice);
                sqlparam[16] = new SqlParameter("@WholeSalePrice", ObjPurchase.ItemWholeSalePrice);
                sqlparam[17] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
                sqlparam[18] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
                sqlparam[19] = new SqlParameter("@Status", ObjPurchase.Status);
                sqlparam[20] = new SqlParameter("@Barcode", ObjPurchase.ItemBarcode == string.Empty ? string.Empty : ObjPurchase.ItemBarcode);
                sqlparam[21] = new SqlParameter("@OldItemName", ObjPurchase.ItemName);
                sqlparam[22] = new SqlParameter("@ImagePath", "");
                sqlparam[23] = new SqlParameter("@CompanyName", ObjPurchase.CompanyName);
                sqlparam[24] = new SqlParameter("@CategoryName ", ObjPurchase.CategoryName);
                sqlparam[25] = new SqlParameter("@AdditionalBarcode", ObjPurchase.ItemBarcode);
                sqlparam[26] = new SqlParameter("@PlaceName", ObjPurchase.PlaceName);
                sqlparam[27] = new SqlParameter("@ItemSerialNo", (ObjPurchase.ItemSerialNo == null ? "0" : ObjPurchase.ItemSerialNo));
                sqlparam[28] = new SqlParameter("@OverWrite", OverWrite);
                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_ImportItemDetails", sqlparam) > 0)
                {
                    ObjMasterDAL.GetCategoryDetails();
                    ObjMasterDAL.GetCompanyDetails();
                    ObjMasterDAL.ItemDetails();
                    return ObjPurchase.ItemNo = Convert.ToInt32(sqlparam[0].Value);
                }
                else
                    return ObjPurchase.ItemNo = Convert.ToInt32(sqlparam[0].Value);//Changed on 04Mar2015

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_Stock_Details(PurchaseObjectClass ObjPurchase, decimal ItemCost, DateTime? ExpirDate, string SerialNo, int XBarcode, int XQty)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[17];
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
                param[11] = new SqlParameter("@XItemCost", ItemCost);
                param[12] = new SqlParameter("@XExpiry", (ExpirDate == null || ExpirDate == DateTime.MinValue) ? DBNull.Value : (object)ExpirDate);
                param[13] = new SqlParameter("@XSerialNo", SerialNo);
                param[14] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
                param[15] = new SqlParameter("@XBarcodeID", XBarcode);
                //param[13] = new SqlParameter("@MTB_ITEMDISCOUNT", objPurchase.ItemDiscount);
                param[16] = new SqlParameter("XQuantity", XQty);
                if (SQLHelper.Instance.ExecuteNonQuery("usp_update_Stock", param) > 0)
                    return 1;
                else
                    return 0;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddStockOnly(PurchaseObjectClass ObjPurchase, decimal ItemCost, DateTime? ExpirDate, string SerialNo, int XBarcode, int XQty, int AddQuantity)
        {
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@BatchID", ObjPurchase.BatchID);
            param[1] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[2] = new SqlParameter("@StockInHand", AddQuantity);
            param[3] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
            param[4] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
            param[5] = new SqlParameter("@Status", ObjPurchase.Status);
            param[6] = new SqlParameter("@Expiry", ObjPurchase.ItemType == 1 ? (object)ObjPurchase.ItemExpiryDate : DBNull.Value);
            param[7] = new SqlParameter("@ItemCost", ObjPurchase.ItemCost);
            param[8] = new SqlParameter("@ItemLastCost", ObjPurchase.ItemCost);
            param[9] = new SqlParameter("@Price", ObjPurchase.ItemPrice);
            param[10] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[11] = new SqlParameter("@XItemCost", ItemCost);
            param[12] = new SqlParameter("@XExpiry", (ExpirDate == null || ExpirDate == DateTime.MinValue) ? DBNull.Value : (object)ExpirDate);
            param[13] = new SqlParameter("@XSerialNo", SerialNo);
            param[14] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
            param[15] = new SqlParameter("@XBarcodeID", XBarcode);
            //param[13] = new SqlParameter("@MTB_ITEMDISCOUNT", objPurchase.ItemDiscount);
            param[16] = new SqlParameter("XQuantity", XQty);
            if (SQLHelper.Instance.ExecuteNonQuery("Sp_AddStockOnly", param) > 0)
                return 1;
            else
                return 0;
        }

        public DataSet CheckForUpdate(PurchaseObjectClass objPurchase, decimal ItemCost, DateTime? ExpirDate, string SerialNo, int XBarcode, int XQty)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ItemID", objPurchase.ItemNo);
            param[1] = new SqlParameter("@InvoiceNo", objPurchase.InvoiceNo);
            param[2] = new SqlParameter("@XItemCost", ItemCost);
            param[3] = new SqlParameter("@XExpiry", (ExpirDate == null || ExpirDate == DateTime.MinValue) ? DBNull.Value : (object)ExpirDate);
            param[4] = new SqlParameter("@XSerialNo", SerialNo);
            param[5] = new SqlParameter("@XBarcodeID", XBarcode);
            return SQLHelper.Instance.GetExecuteDataSet("Sp_CheckForUpdation", param);
        }
        public int Update_Purchase_Invoice(PurchaseObjectClass ObjPurchase, decimal Cost, DateTime? ExpiryDate, string SerialNo, int XBarcodeID, int XBox, int StockSold, int older_box, int ExpiryInsert, int DeleteItem)
        {

            SqlParameter[] param = new SqlParameter[55];
            param[0] = new SqlParameter("@PurchaseInvID", ObjPurchase.InvoiceNo);
            param[1] = new SqlParameter("@AgentID", ObjPurchase.SupplierNo);
            param[2] = new SqlParameter("@AccountID", ObjPurchase.AccountID);
            param[3] = new SqlParameter("@PurchaseDate", ObjPurchase.PurchaseItemDate);
            param[4] = new SqlParameter("@Balance", ObjPurchase.ItemBalance);
            param[5] = new SqlParameter("@GrossAmt", ObjPurchase.ItemGrossAmt);
            param[6] = new SqlParameter("@Tax", ObjPurchase.Tax);
            param[7] = new SqlParameter("@NetAmt", ObjPurchase.ItemNet);
            param[8] = new SqlParameter("@Discount", ObjPurchase.Discount);
            param[9] = new SqlParameter("@PaymentDate", ObjPurchase.SetPaymentDate == true ? (object)ObjPurchase.ItemPaymentDate : DBNull.Value);
            param[10] = new SqlParameter("@CreatedBy", ObjPurchase.CreatedBy);
            param[11] = new SqlParameter("@ModifiedBy", ObjPurchase.ModifiedBy);
            param[12] = new SqlParameter("@Status", ObjPurchase.Status);
            param[13] = new SqlParameter("@SetStatus", ObjPurchase.SetStatus);
            param[14] = new SqlParameter("@BatchID", ObjPurchase.BatchID);
            param[15] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            param[16] = new SqlParameter("@Qty", ObjPurchase.ItemQuantity);
            param[17] = new SqlParameter("@UnitPrice", ObjPurchase.ItemUnitPrice);
            param[18] = new SqlParameter("@ExpiryDate", ObjPurchase.ItemExpiryDate == null ? DBNull.Value : (object)ObjPurchase.ItemExpiryDate);
            param[19] = new SqlParameter("@ItemCost", ObjPurchase.ItemCost);
            param[20] = new SqlParameter("@ItemLastCost", ObjPurchase.ItemCost);
            param[21] = new SqlParameter("@Price", ObjPurchase.ItemUnitPrice);
            param[22] = new SqlParameter("@SalePrice", ObjPurchase.SalePrice);
            param[23] = new SqlParameter("@Cost", ObjPurchase.PurchaseCost);
            param[24] = new SqlParameter("@SerialNo", ObjPurchase.ItemSerialNo);
            param[25] = new SqlParameter("@DiscountType", ObjPurchase.DiscountType);
            param[26] = new SqlParameter("@Tax1", ObjPurchase.Tax1);
            param[27] = new SqlParameter("@ItemDiscount", ObjPurchase.ItemDiscount);
            param[28] = new SqlParameter("@ItemExtraCost", ObjPurchase.Extracost);
            param[29] = new SqlParameter("@DiscountCost", ObjPurchase.EachItemExtraCost);
            param[30] = new SqlParameter("@ItemTax1", ObjPurchase.ItemTax1);
            param[31] = new SqlParameter("@ItemTax2", ObjPurchase.ItemTax2);
            param[32] = new SqlParameter("@TaxPer", ObjPurchase.FlagTax1Percentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax1Percentage);
            param[33] = new SqlParameter("@TaxSub", ObjPurchase.FlagTax1SubPercentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax1SubPercentage);
            param[34] = new SqlParameter("@Tax1_Per", ObjPurchase.FlagTax2Percentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax2Percentage);
            param[35] = new SqlParameter("@Tax1_Sub", ObjPurchase.FlagTax2SubPercentage == null ? Convert.ToDecimal("0") : ObjPurchase.FlagTax2SubPercentage);
            param[36] = new SqlParameter("@OriginalDis", ObjPurchase.originaldiscount);
            param[37] = new SqlParameter("@Note", (ObjPurchase.Note != null) ? ObjPurchase.Note : "");
            param[38] = new SqlParameter("@XCost", Cost);
            param[39] = new SqlParameter("@XSerialNo", SerialNo);
            param[40] = new SqlParameter("@XExpiryDate", (ExpiryDate == null || ExpiryDate == DateTime.MinValue) ? DBNull.Value : (object)ExpiryDate);
            param[41] = new SqlParameter("@BarcodeID", ObjPurchase.BarcodeID);
            param[42] = new SqlParameter("@XBarcodeID", XBarcodeID);
            param[43] = new SqlParameter("@Box", ObjPurchase.Box);
            param[44] = new SqlParameter("@XBox", XBox);
            param[45] = new SqlParameter("@SubTax1", ObjPurchase.ItemTax1SubAmount);
            param[46] = new SqlParameter("@SubTax2", ObjPurchase.ItemTax2SubAmount);
            param[47] = new SqlParameter("@ActualUnitPrice", ObjPurchase.ActualUnitPrice);
            param[48] = new SqlParameter("@TotalAmount", ObjPurchase.ItemTotalAmount);
            param[49] = new SqlParameter("@PurchaseDetail_ID", ObjPurchase.PurchaseItemdDetail_ID);
            param[50] = new SqlParameter("@IsSold", StockSold);
            param[51] = new SqlParameter("@Older_box", older_box);
            param[52] = new SqlParameter("@ExpitryInsert",ExpiryInsert);
            param[53] = new SqlParameter("@DeleteItem", DeleteItem);
            param[54] = new SqlParameter("@InNo", ObjPurchase.InNo);
            if ((SQLHelper.Instance.ExecuteNonQuery("usp_update_Purchase", param)) > 0)
                return 1;
            else
                return 0;

        }

        /////******Item Information****\\\\\\\\\\\\
        public List<DateTime> getExpiryDates(PurchaseObjectClass objPurchase)
        {
            try
            {
                List<DateTime> lstExpiryLists = new List<DateTime>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objPurchase.ItemNo);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT distinct(Expiry)FROM dbo.Stock WHERE ItemID = @ItemID ", param);
                while (ReaderResult.Read())
                {
                    if (ReaderResult["Expiry"] != DBNull.Value)
                        lstExpiryLists.Add(Convert.ToDateTime(ReaderResult["Expiry"]));
                }
                return lstExpiryLists;
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

        #region GetAppliedIncrease
        public DataTable GetAppliedIncrease(int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType",ItemType);
            param[1] = new SqlParameter("@CategoryID",CategoryID);
            param[2] = new SqlParameter("@CompanyID", CompanyID);
            param[3] = new SqlParameter("@ItemID", ItemNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }
        #endregion

        public List<PurchaseObjectClass> GetItemInformation(PurchaseObjectClass ObjPurchase)
        {
            List<PurchaseObjectClass> ItemList = new List<PurchaseObjectClass>();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemID", ObjPurchase.ItemNo);
            try
            {
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_ITEMINFO, param);
                while (result.Read())
                {
                    ItemList.Add(new PurchaseObjectClass
                    {
                        ItemName = result["ItemName"].ToString(),
                        CategoryName = result["CategoryName"].ToString(),
                        CategoryNo = Convert.ToInt32(result["CategoryID"]),
                        CompanyName = result["CompanyName"].ToString(),
                        CompanyNo = Convert.ToInt32(result["CompanyID"]),
                        PlaceName = result["PlaceName"].ToString(),
                        ItemPrice = result["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(result["Price"]),
                        ItemType= Convert.ToInt32(result["ItemType"]),
                        ItemWholeSalePrice = result["WholeSalePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(result["WholeSalePrice"]),
                        ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        ItemCost = result["ItemCost"] == DBNull.Value ? 0 : Convert.ToDecimal(result["ItemCost"]),
                        AvgCost = result["AverageCost"] == DBNull.Value ? 0 : Convert.ToDecimal(result["AverageCost"]),
                        ItemLastCost = result["ItemLastCost"] == DBNull.Value ? 0 : Convert.ToDecimal(result["ItemLastCost"]),

                        ItemPackage = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                        ItemTotalStock = Convert.ToInt32(result["StockInHand"]),
                        //   ItemExpiryDate = Convert.ToDateTime(result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"])
                    });
                }
                return ItemList;
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

        //// Find Purchase Invoice\\\\\
        public DataTable GetFindPurchaseInvoice(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
            param[0].Value = ObjPurchase.FromDate;
            param[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
            param[1].Value = ObjPurchase.ToDate;
            param[2] = new SqlParameter("@ALLDATE", ObjPurchase.SetStatus);
            param[3] = new SqlParameter("@AgentID", ObjPurchase.SupplierNo);

            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.FIND_PURCHASEINVOICE_DATA, param, "FindPurchase");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetFindReturnInvoiceDetails(long InvoiceNo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PurchaseReturnID", SqlDbType.VarChar);
            param[0].Value = InvoiceNo;
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.FIND_RETURNINVOICE_DETAILs, param, "FindReturn");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetFindOrderInvoiceDetails(long InvoiceNo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@OrderID", SqlDbType.VarChar);
            param[0].Value = InvoiceNo;
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.FIND_ORDERINVOICE_DETAILS, param, "FindOrder");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool UpdateBarcode(int BarcodeId,string Barcode)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];

                sqlparam[0] = new SqlParameter("@BarcodeId", BarcodeId);
                sqlparam[1] = new SqlParameter("@Barcode", Barcode);
                if ((SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Barcode SET Barcode=@Barcode Where BarcodeID=@BarcodeId", sqlparam)) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable GetFindPurchaseInvoiceDetails(long InvoiceNo)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PurchaseInvoiceID", InvoiceNo);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.GET_PURCHASEINVOICE_DETAILS, param, "FindPurchase");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPurchaseReportValues(long InvoiceNo)
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@PurchaeInvID", InvoiceNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_PurchaseInvoice_No", Param, "ReportValues");
        }

        public DataTable GetBarcodeExist(PurchaseObjectClass ObjPurchase)
        {
            SqlParameter[] Param = new SqlParameter[3];
            Param[0] = new SqlParameter("@Barcode", ObjPurchase.ItemBarcode);
            Param[1] = new SqlParameter("@ItemId", ObjPurchase.ItemNo);
            Param[2] = new SqlParameter("@ItemName", ObjPurchase.ItemName);
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_Exist_Barcode", Param, "ReportValues");
        }
        public DataTable GetBarcode(int ItemID, int PackageQty, int BarcodeID)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ItemID", SqlDbType.VarChar);
            param[0].Value = ItemID;
            param[1] = new SqlParameter("@PackageQty", PackageQty);
            param[2] = new SqlParameter("@BarcodeID", BarcodeID);
            try
            {
                return SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_Barcode", param, "MTB_BARCODE");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetReportfotFind(PurchaseObjectClass objPurchase)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@AgentID", objPurchase.SupplierNo);
            param[1] = new SqlParameter("@FromDate", objPurchase.FromDate);
            param[2] = new SqlParameter("@ToDate", objPurchase.ToDate);
            param[3] = new SqlParameter("@InvoiceNo", objPurchase.InvoiceNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("use_Reports_FindPurchaseInvoice", param, "FindPurchaseInvoice");
        }

        public static DataTable GetReorderItems()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ReorderItems", param, "ReorderItem");
        }

        public DataTable DetailedPurchaseInvoice(string Remarks)
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Remarks", Remarks = string.Empty);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_DetailPurchaseInvoice", Param, "DetailPurchaseInvoice");
        }

        public DataTable GetItemSerialNo()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_ItemSerialNo", param, "ItemSerialNo");
        }

        public float IsIncreaseForAgent(PurchaseObjectClass objPurchase)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@AgentID", objPurchase.SupplierNo);

                float Disount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(IncreasePrice,0) FROM dbo.Agent WHERE AgentID=@AgentID", Param));
                return Disount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Check_DuplicateBarCode(string Barcode)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@Barcode", Barcode);
                if (Convert.ToInt32((SQLHelper.Instance.GetScalar("SP_Check_ItemBarcode", sqlparam))) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

    }
}
