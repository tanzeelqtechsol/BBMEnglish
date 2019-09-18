using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HSB_ObjectHelper;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;
using CommonHelper;

namespace DataBaseHelper.DALClass
{
    public class SaleReturnDAL
    {

        #region Constant Variables
        private const string GET_EXPIRY_DETAILS = "SP_Get_Expirydates";
        private const String SpNameGetBalanceSheet = "SP_Get_BalanceSheet";
        private const string SpGetSaleReturnDetails = "sp_saledetailsfor_return";
        private const string SpSaveSaleReturnDetails = "Sp_sale_returnitem_A";
        private const string SPGetNextID = "GetNextId";
        private const string SPGetYearSequence = "SP_Get_NewInvoiceNo";
        private const string SPGetReturnDetails = "Sp_Get_ReturnSaleDetails_A";
        private const string SPGetStockForUndo = "Sp_Stock_ForUndo";
        private const string SPUndoReturnPerItem = "Sp_Undoreturn_item_A";
        private const string SPUndoReturnAllQty = "Sp_Undoreturn_A";
        private const string SPSaveReturnSale = "Sp_Save_ReturnSale_A";
        private const string SPGetSaleID = "Sp_Get_Saleid_A_m";
        private const string SPModifyRetInvoice = "Sp_modify_returninv_A";
        private const string SPCheckBalance = "Sp_check_balance_SR_A";
        private const string SPGetMinMaxSaleReturnID = "USP_BBM_GetMinMax_SalesReturnInvoice";
        private const string SpNameSavePayReceipt = "SP_Save_PayReceipt";
        private const string SpNameGetSaleReturnReport = "usp_Reports_SaleReturn";
        #endregion

        #region Methods

        #region GetBalanceSheetDetails

        public List<SaleReturnObjectClass> GetBalanceSheetDetails(SaleReturnObjectClass objSaleReturn)
        {

            List<SaleReturnObjectClass> lstBalance = new List<SaleReturnObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@AgentID", objSaleReturn.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objSaleReturn.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objSaleReturn.BalanceToDate;
                param[3] = new SqlParameter("@Status", objSaleReturn.BalanceStatus);

                var reader = SQLHelper.Instance.GetReader(SpNameGetBalanceSheet, param);
                while (reader.Read())
                {

                    lstBalance.Add(new SaleReturnObjectClass
                    {

                        AmountRecieved = Convert.ToDecimal(reader[4]),
                        NetAmount = Convert.ToDecimal(reader[5])

                    });

                }
            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return lstBalance;
        }

        #endregion

        #region GetSaleReturnDetails

        public List<SaleReturnObjectClass> GetSaleReturnDetails(SaleReturnObjectClass objSaleReturn)
        {

            List<SaleReturnObjectClass> lstReturnDetails = new List<SaleReturnObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ItemId", objSaleReturn.itemno);
                param[1] = new SqlParameter("@FromDate", objSaleReturn.fromdate);
                param[2] = new SqlParameter("@ToDate", objSaleReturn.todate);
                param[3] = new SqlParameter("@Client", objSaleReturn.clientno);
                param[4] = new SqlParameter("@Invoice", objSaleReturn.invoiceno);
                param[5] = new SqlParameter("@All", objSaleReturn.all);

                var reader = SQLHelper.Instance.GetReader(SpGetSaleReturnDetails, param);
                while (reader.Read())
                {
                    lstReturnDetails.Add(new SaleReturnObjectClass
                    {
                        Year = Convert.ToInt16(reader["Year"]),
                        YearSequenceNo = Convert.ToInt64(reader["YearSequenceNo"]),
                        SaleDate = Convert.ToDateTime(reader["Date"] != DBNull.Value ? reader["Date"] : DateTime.MinValue),
                        ClientName = reader["Client"].ToString(),
                        package = Convert.ToInt16(reader["Package"]),
                        Quantity = Convert.ToInt16(reader["Quantity"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        expiry = Convert.ToDateTime(reader["Expiry"] != DBNull.Value ? reader["Expiry"] : DateTime.MinValue),
                        createdby = Convert.ToInt16(reader["Users"]),
                        returnquantity = Convert.ToInt16(reader["ReturnQty"]),
                        saleid = Convert.ToInt64(reader["SaleId"]),
                        ItemName = reader["ItemName"].ToString(),
                        itemno = Convert.ToInt16(reader["ItemID"]),
                        serialno = reader["SerialNo"] != DBNull.Value ? reader["SerialNo"].ToString() : "0",
                        saledetid = Convert.ToInt64(reader["SaleDetId"]),
                        Newexpr = Convert.ToDateTime(reader["NewExpr"] != DBNull.Value ? reader["NewExpr"] : DateTime.MinValue),
                        saleinv = Convert.ToInt64(reader["InvoiceNo"]),
                        ItemNumber = reader["ItemNumber"] != DBNull.Value ? reader["ItemNumber"].ToString() : string.Empty,
                        BarcodeID = Convert.ToInt32(reader["BarcodeID"] != DBNull.Value ? reader["BarcodeID"] : 0),
                        NewYearInvoiceNo = reader["NewYearInvoiceNo"].ToString()
                    });

                }
            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return lstReturnDetails;
        }

        #endregion

        #region GetYearSequenceMaxID
        public List<long> GetYearSequenceMaxID()
        {
            List<long> InvoiceID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TableId", CommonHelper.Table.SaleReturn);
                param[1] = new SqlParameter("@Flag", "SalesReturn");
                var result = SQLHelper.Instance.GetReader(SPGetNextID, param);
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
        #endregion

        #region SaveSaleReturnDetails

        public bool SaveSaleReturnDetails(SaleReturnObjectClass objSaleReturn)
        {
            bool result = false;

            try
            {

                SqlParameter[] param = new SqlParameter[18];

                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                param[1] = new SqlParameter("@SaleID", objSaleReturn.saleid);
                param[2] = new SqlParameter("@ItemID", objSaleReturn.itemno);
                param[3] = new SqlParameter("@AccountID", objSaleReturn.saledetid);
                param[4] = new SqlParameter("@Quantity", objSaleReturn.returnquantity);
                param[5] = new SqlParameter("@UnitPrice", objSaleReturn.unitprice);
                param[6] = new SqlParameter("@SaleReturnDate", objSaleReturn.returndate);
                param[7] = new SqlParameter("@Reason", objSaleReturn.QuickReturn == true ? "Quick Return" : "reason");
                param[8] = new SqlParameter("@UserID", objSaleReturn.user);
                param[9] = new SqlParameter("@Status", objSaleReturn.status);
                param[10] = new SqlParameter("@Expiry", objSaleReturn.expiry == DateTime.MinValue || objSaleReturn.expiry.ToString() == "1/1/1900" ? DBNull.Value : (object)objSaleReturn.expiry);
                param[11] = new SqlParameter("@SerialNo", objSaleReturn.serialno);
                param[12] = new SqlParameter("@SaleDetailID", objSaleReturn.saledetid);
                param[13] = new SqlParameter("@Updation", objSaleReturn.mtb_updation);
                param[14] = new SqlParameter("@Agent", objSaleReturn.clientno);
                // param[15] = new SqlParameter("@NewExpiry", objSaleReturn.Newexpr);
                param[15] = new SqlParameter("@CreatedBy", objSaleReturn.createdby);
                param[16] = new SqlParameter("@ModifiedBy", objSaleReturn.modifiedby);
                param[17] = new SqlParameter("@BarcodeID", objSaleReturn.BarcodeID);


                if (SQLHelper.Instance.ExecuteNonQuery(SpSaveSaleReturnDetails, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }


            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return result;

        }
        #endregion

        #region GetMinMaxSaleReturnId
        public List<long> GetMInMaxSaleReturnId()
        {
            List<long> ls = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var reader = SQLHelper.Instance.GetReaderWithQuery("SELECT ISNULL(MAX(CONVERT(INT,SaleReturnID)),0) as MaxSaleReturnID,ISNULL(MIN(CONVERT(INT,SaleReturnID)),0) as MinSaleReturnID FROM dbo.SaleReturn", param);
                while (reader.Read())
                {

                    ls.Add(Convert.ToInt64(reader["MinSaleReturnID"]));
                    ls.Add(Convert.ToInt64(reader["MaxSaleReturnID"]));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ls;
        }
        #endregion

        #region GetCurrentYear()
        public List<SaleReturnObjectClass> GetCurrentYear()
        {
            try
            {
                List<SaleReturnObjectClass> lstWithYear = new List<SaleReturnObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.SaleReturn);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select YearValue from KeySequence where TableId=@TableId", sqlParam);
                if (ReaderResult.Read())
                {
                    lstWithYear.Add(new SaleReturnObjectClass { CurrentYear = Convert.ToInt32(ReaderResult["YearValue"]) });

                }
                return lstWithYear;
            }
            catch
            {
                throw;
            }
            finally
            {
                Close();
            }
        }
        #endregion

        #region GetYearSequence
        public List<SaleReturnObjectClass> GetYearSequence(SaleReturnObjectClass objSaleObject)
        {
            List<SaleReturnObjectClass> lstSaleObject = new List<SaleReturnObjectClass>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.SaleReturnID);
                param[1] = new SqlParameter("@Flag", objSaleObject.Flag);
                var result = SQLHelper.Instance.GetReader(SPGetYearSequence, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleReturnObjectClass
                    {
                        Year = Convert.ToInt16(result["Year"]),
                        YearSequenceNo = Convert.ToInt64(result["YearSequenceNo"]),

                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

            return lstSaleObject;
        }
        #endregion

        #region GetReturnDetailsBasedOnInvoice

        public List<SaleReturnObjectClass> GetReturnDetailsBasedOnInvoice(SaleReturnObjectClass objSaleReturn)
        {

            List<SaleReturnObjectClass> lstReturnDetails = new List<SaleReturnObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.SaleReturnID);

                var reader = SQLHelper.Instance.GetReader(SPGetReturnDetails, param);
                while (reader.Read())
                {

                    lstReturnDetails.Add(new SaleReturnObjectClass
                    {
                        ItemName = reader["ItemName"].ToString(),
                        SaleReturnID = Convert.ToInt64(reader["SaleReturnID"]),
                        itemno = Convert.ToInt16(reader["ItemID"]),
                        status = Convert.ToInt16(reader["Status"]),
                        expiry = Convert.ToDateTime(reader["Expiry"] != DBNull.Value ? reader["Expiry"] : DateTime.MinValue),
                        package = Convert.ToInt16(reader["Package"]),

                        SaleDate = Convert.ToDateTime(reader["SaleReturnDate"] != DBNull.Value ? reader["SaleReturnDate"] : DateTime.MinValue),
                        Time = reader["Time"].ToString(),
                        Quantity = Convert.ToInt16(reader["Quantity"]),
                        ClientName = reader["Client"].ToString(),
                        clientno = Convert.ToInt16(reader["Clientid"]),
                        unitprice = Convert.ToDecimal(reader["UnitPrice"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Reason = reader["Reason"].ToString(),

                        Cost = Convert.ToDecimal(reader["Cost"]),
                        Discount = Convert.ToDecimal(reader["Discount"]),
                        Newexpr = Convert.ToDateTime(reader["Newexpr"] != DBNull.Value ? reader["Newexpr"] : DateTime.MinValue),
                        serialno = reader["serialno"] == DBNull.Value ? "0" : reader["serialno"].ToString(),
                        saledetid = Convert.ToInt64(reader["sale_det_id"]),
                        user = Convert.ToInt16(reader["UserId"]),
                        UserName = reader["UserName"].ToString(),
                        saleid = Convert.ToInt64(reader["SaleId"]),
                        saleinv = Convert.ToInt64(reader["SaleInvoice"]),
                        ItemNumber = reader["ItemNumber"].ToString(),
                        BarcodeID = Convert.ToInt32(reader["BarcodeID"]),


                    });

                }
            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return lstReturnDetails;
        }

        #endregion

        /// <summary>
        /// Creted On  : 20-Jan-14
        /// Created By : Seenivasan
        /// Methods    : GetStockForUndo , UndoReturnPerItem , UndoReturnAllQty
        /// </summary>
        /// <param name="objSaleObject"></param>
        /// <returns></returns>
        /// 

        #region GetStockForUndo
        public List<SaleReturnObjectClass> GetStockForUndo(SaleReturnObjectClass objSaleObject)
        {
            List<SaleReturnObjectClass> lstStockForUndo = new List<SaleReturnObjectClass>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@saledetid", objSaleObject.saledetid);
                var result = SQLHelper.Instance.GetReader(SPGetStockForUndo, param);
                while (result.Read())
                {
                    lstStockForUndo.Add(new SaleReturnObjectClass
                    {
                        Stock = Convert.ToInt16(result["Stock"]),
                        ItemType = Convert.ToInt16(result["Itemtype"]),

                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

            return lstStockForUndo;
        }
        #endregion

        #region UndoReturnPerItem

        public bool UndoReturnPerItem(SaleReturnObjectClass objSaleReturn)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                param[1] = new SqlParameter("@SaleDetailID", objSaleReturn.saledetid);
                param[2] = new SqlParameter("@ItemID", objSaleReturn.itemno);
                param[3] = new SqlParameter("@Quantity", objSaleReturn.returnquantity);

                if (SQLHelper.Instance.ExecuteNonQuery(SPUndoReturnPerItem, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return result;
        }

        #endregion

        #region UndoReturnAllQty

        public bool UndoReturnAllQty(SaleReturnObjectClass objSaleReturn)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                param[1] = new SqlParameter("@SaleDetailID", objSaleReturn.saledetid);
                param[2] = new SqlParameter("@ItemID", objSaleReturn.itemno);
                param[3] = new SqlParameter("@Quantity", objSaleReturn.returnquantity);

                if (SQLHelper.Instance.ExecuteNonQuery(SPUndoReturnAllQty, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Creted On  : 21-Jan-14
        /// Created By : Seenivasan
        /// Methods    : SaveReturnInvoice , GetSaleID 
        /// </summary>
        /// <param name="objSaleObject"></param>
        /// <returns></returns>
        /// 

        #region SaveReturnInvoice

        public bool SaveReturnInvoice(SaleReturnObjectClass objSaleReturn)
        {
            bool result = false;
            try
            {
                SqlParameter[] param = new SqlParameter[13];

                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                param[1] = new SqlParameter("@SaleID", objSaleReturn.saleid);
                param[2] = new SqlParameter("@ItemID", objSaleReturn.itemno);
                param[3] = new SqlParameter("@AccountID", objSaleReturn.saledetid);
                param[4] = new SqlParameter("@Quantity", objSaleReturn.returnquantity);
                param[5] = new SqlParameter("@UnitPrice", objSaleReturn.unitprice);
                param[6] = new SqlParameter("@SaleReturnDate", objSaleReturn.returndate);
                param[7] = new SqlParameter("@Reason", "reason");
                param[8] = new SqlParameter("@UserID", objSaleReturn.user);
                param[9] = new SqlParameter("@Status", objSaleReturn.status);
                param[10] = new SqlParameter("@Expiry", objSaleReturn.expiry);
                param[11] = new SqlParameter("@SerialNo", objSaleReturn.serialno);
                param[12] = new SqlParameter("@SaleDetailID", objSaleReturn.saledetid);

                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveReturnSale, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return result;

        }

        #endregion

        #region GetSaleID
        public List<long> GetSaleID(SaleReturnObjectClass objSaleReturn)
        {
            List<long> ls = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInvoice", objSaleReturn.saleid);
                var reader = SQLHelper.Instance.GetReader(SPGetSaleID, param);
                while (reader.Read())
                {

                    ls.Add(Convert.ToInt64(reader["SaleReturnID"]));
                    ls.Add(Convert.ToInt64(reader["SaleID"]));
                    ls.Add(Convert.ToInt64(reader["AgentID"]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ls;
        }
        #endregion

        #region ModifyReturnInvoice

        public bool ModifyReturnInvoice(SaleReturnObjectClass objSaleReturn)
        {
            bool result = false;
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);

                if (SQLHelper.Instance.ExecuteNonQuery(SPModifyRetInvoice, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return result;

        }

        #endregion

        #region CheckBalance
        public List<decimal> CheckBalance(SaleReturnObjectClass objSaleReturn)
        {
            List<decimal> lst = new List<decimal>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                var reader = SQLHelper.Instance.GetReader(SPCheckBalance, param);
                while (reader.Read())
                {

                    lst.Add(Convert.ToDecimal(reader["Net"] != DBNull.Value ? reader["Net"] : 0));
                    lst.Add(Convert.ToDecimal(reader["Paid"] != DBNull.Value ? reader["Paid"] : 0));
                    lst.Add(Convert.ToDecimal(reader["Bal"] != DBNull.Value ? reader["Bal"] : 0));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return lst;
        }
        #endregion

        #region GetMaxPaymentID
        public List<long> GetMaxPaymentID()
        {
            List<long> ls = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var reader = SQLHelper.Instance.GetReaderWithQuery("SELECT Convert(INT, isnull(max(Convert(INT, PaymentID)), 0)) + 1 FROM dbo.Payment 	WHERE ReceiptFor != 1", param);
                while (reader.Read())
                {

                    ls.Add(Convert.ToInt64(reader["PaymentID"]));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return ls;
        }
        #endregion

        #region SavePayReceiptDetails
        public bool SavePayReceiptDetails(SaleReturnObjectClass objSaleReturn)
        {
            SqlParameter[] param = new SqlParameter[20];
            try
            {
                param[0] = new SqlParameter("@PayMethodID", 101);
                param[1] = new SqlParameter("@AgentID", objSaleReturn.clientno);
                param[2] = new SqlParameter("@PurchaseID", objSaleReturn.saleid);
                param[3] = new SqlParameter("@PayInvoice", objSaleReturn.returninvoiceno);
                param[4] = new SqlParameter("@BalanceAmount", objSaleReturn.Balance);
                param[5] = new SqlParameter("@PaymentDate", objSaleReturn.returndate);
                /// param[6] = new SqlParameter("@CreatedDate", DateTime.Now);
                param[6] = new SqlParameter("@CreatedBy", objSaleReturn.createdby);
                ///  param[8] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[7] = new SqlParameter("@ModifiedBy", objSaleReturn.modifiedby);
                param[8] = new SqlParameter("@Status", objSaleReturn.status);
                param[9] = new SqlParameter("@Description", objSaleReturn.paydiscription);
                param[10] = new SqlParameter("@Reason", objSaleReturn.QuickReturn == true ? "Quick Return" : "ReturnedItem");
                param[11] = new SqlParameter("@BankID", Convert.ToInt32(0));
                param[12] = new SqlParameter("@BranchID", Convert.ToInt32(0));
                param[13] = new SqlParameter("@UserID", objSaleReturn.user);
                //param[14] = new SqlParameter("@GrossAmount", Convert.ToDecimal("0.000"));
                param[14] = new SqlParameter("@GrossAmount", objSaleReturn.totalreturnvalue);
                param[15] = new SqlParameter("@AmountPaid", objSaleReturn.totalreturnvalue);
                param[16] = new SqlParameter("@PaidDate", objSaleReturn.returndate);
                param[17] = new SqlParameter("@Remarks", "Save");
                param[18] = new SqlParameter("@ReceiptFor", (int)PayReceiptFor.SaleReturn);
                param[19] = new SqlParameter("@DescriptionArabic", "ÊÑÌíÚ ãÈíÚÇÊ " + " " + objSaleReturn.returninvoiceno.ToString());


                if (SQLHelper.Instance.ExecuteNonQuery(SpNameSavePayReceipt, param) > 0)
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
            finally
            {
                Close();
            }
        }
        #endregion

        #region UpdatePayReceiptDetails
        public bool UpdatePayReceiptDetails(SaleReturnObjectClass objSaleReturn)
        {
            SqlParameter[] param = new SqlParameter[2];
            try
            {
                param[0] = new SqlParameter("@SaleReturnID", objSaleReturn.returninvoiceno);
                param[1] = new SqlParameter("@SaleID", objSaleReturn.saleid);
                if (SQLHelper.Instance.ExecuteNonQuery("SP_Update_PaymentNDetails", param) > 0)
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
            finally
            {
                Close();
            }
        }
        #endregion

        #region GetSaleReturnPrintReport
        public DataTable GetSaleReturnPrintReport(SaleReturnObjectClass objPos)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@InvoiceNo", objPos.returninvoiceno);
                return SQLHelper.Instance.ExecuteQueryDatatable(SpNameGetSaleReturnReport, Param, "ReportValues");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

        }
        #endregion

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

        #endregion

        #endregion


        public List<SaleReturnObjectClass> DateForExpiredItem(SaleReturnObjectClass returnobjectclass)
        {
            //  Dictionary<int, dynamic> dictExpiryItemDets = new Dictionary<int, dynamic>();
            List<SaleReturnObjectClass> lstExpiryStackcount = new List<SaleReturnObjectClass>();
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {

                sqlparam[0] = new SqlParameter("@ItemID", returnobjectclass.itemno);
                var result = SQLHelper.Instance.GetReader("SP_Get_QuickRetrunExpirydates", sqlparam);//sp Changed By Meena.R on 18Nov2014
                                                                                                     //dictExpiryItemDets.Add(0, lstExpiryStackcount);

                while (result.Read())
                {
                    lstExpiryStackcount.Add(new SaleReturnObjectClass { expiry = Convert.ToDateTime(result["Expiry"] == null ? null : result["Expiry"]), ItemType = Convert.ToInt32(result["StockCount"]) });
                }


                return lstExpiryStackcount;
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
        public Dictionary<decimal, int> UnitPriceForItem(SaleReturnObjectClass ReturnObjectClass)
        {

            try
            {
                Dictionary<decimal, int> DicItemDetails = new Dictionary<decimal, int>();
                List<SaleReturnObjectClass> LstExpiry = new List<SaleReturnObjectClass>();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", ReturnObjectClass.itemno);
                param[1] = new SqlParameter("@BarcodeID", ReturnObjectClass.BarcodeID);

                var result = SQLHelper.Instance.GetReaderWithQuery("select  b.Price,B.PackageQty  from item I inner join barcode  B on b.ItemId=I.ItemId where I.Status=1 and B.status=1 and B.ItemID=@ItemID and b.BarcodeID=@BarcodeID", param);

                while (result.Read())
                {
                    DicItemDetails.Add(Convert.ToDecimal(result["Price"]), Convert.ToInt32(result["PackageQty"]));


                }
                return DicItemDetails;
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
        public int GetSalesDetailsIdOfItem(SaleReturnObjectClass ReturnObjectClass)
        {

            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ItemID", ReturnObjectClass.itemno);
                param[1] = new SqlParameter("@SalesID", ReturnObjectClass.saleid);
                param[2] = new SqlParameter("@Expirydate", ReturnObjectClass.expiry);
                param[3] = new SqlParameter("@UnitPrice", ReturnObjectClass.unitprice);

                var result = SQLHelper.Instance.GetScalar("GetSaleDetailsID", param);

                return Convert.ToInt32(result);
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
        public List<SaleReturnObjectClass> GetPackageQtyForItem(SaleReturnObjectClass objSalereturnObject)
        {
            List<SaleReturnObjectClass> lstSalereturnObject = new List<SaleReturnObjectClass>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSalereturnObject.itemno);
                var result = SQLHelper.Instance.GetReader("usp_GetPackageQtyForSpoiled", param);
                while (result.Read())
                {
                    lstSalereturnObject.Add(new SaleReturnObjectClass
                    {
                        BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                        package = Convert.ToInt32(result["PackageQty"]),


                    });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }

            return lstSalereturnObject;
        }
        public List<SaleReturnObjectClass> Get_SerialNo(SaleReturnObjectClass objSalereturnObject)
        {
            try
            {
                List<SaleReturnObjectClass> lstSalereturnObject = new List<SaleReturnObjectClass>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSalereturnObject.itemno);

                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_ITEM_SERIALNO, param);
                while (result.Read())
                {
                    lstSalereturnObject.Add(new SaleReturnObjectClass
                    {
                        serialno = result["SerialNo"].ToString(),
                        unitprice = Convert.ToDecimal(result["Price"])

                    });
                }
                return lstSalereturnObject;
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
        /// <summary>
        /// get the item type from the item  table on 20 may 2014
        /// </summary>
        /// <param name="objSalereturnObject"></param>
        /// <returns></returns>
        public int GetItemDetails(SaleReturnObjectClass objSalereturnObject)
        {
            try
            {
                //List<SaleReturnObjectClass> ItemDetailsList = new List<SaleReturnObjectClass>();
                int type = 0;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSalereturnObject.itemno);

                var result = SQLHelper.Instance.GetReaderWithQuery("select ItemType from Item where ItemId= @ItemID and Status=1", param);
                while (result.Read())
                {
                    type = Convert.ToInt32(result["ItemType"]);
                }


                return type;
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
        public List<SaleReturnObjectClass> GetPurchasedItemDetails(SaleReturnObjectClass objSalereturnObject)
        {
            try
            {
                List<SaleReturnObjectClass> ItemDetailsList = new List<SaleReturnObjectClass>();
                var result = SQLHelper.Instance.GetReader("Sp_Get_ReturnOrder_ItemStock", null);
                while (result.Read())
                {

                    ItemDetailsList.Add(new SaleReturnObjectClass
                    {
                        itemno = Convert.ToInt32(result["ItemID"]),
                        ItemNumber = result["ItemNumber"].ToString(),
                        ItemName = result["ItemName"].ToString()
                    });
                }
                return ItemDetailsList;
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
        public DataTable GetSaleReturnItem()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_ReturnOrder_ItemStock", param, "Return");
        }
        public int GetSalesDetailsItem(SaleReturnObjectClass objSalereturnObject, Boolean isPOS)
        {
            try
            {
                int countofitem = 0;
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@ItemID", objSalereturnObject.itemno);
                param[1] = new SqlParameter("@BarcodeID", objSalereturnObject.BarcodeID);
                param[2] = new SqlParameter("@AgentID", objSalereturnObject.clientno);
                param[3] = new SqlParameter("@Quantity", objSalereturnObject.returnquantity);
                param[4] = new SqlParameter("@ExpiryDate", objSalereturnObject.expiry == DateTime.MinValue || objSalereturnObject.expiry == null ? (object)DBNull.Value : objSalereturnObject.expiry);
                param[5] = new SqlParameter("@SerialNo", objSalereturnObject.serialno);
                param[6] = new SqlParameter("@IsPOS", isPOS);
                var result = SQLHelper.Instance.GetReader("usp_Check_UndoReturn", param);
                while (result.Read())
                {
                    countofitem = Convert.ToInt32(result["Count"]);
                }


                return countofitem;


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
        #region Get_MaxIdOfPaymentRecord
        public object Get_MaxIdOfPaymentRecord()
        {

            try
            {
                object PaymentMinID;
                string Query = "Select MaxId From KeySequence Where TableId=8";
                PaymentMinID = SQLHelper.Instance.GetScalar(Query);
                return PaymentMinID;
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
        #endregion
        /// <summary>
        /// For quick return order we can get the non stock item serial number 
        /// </summary>
        /// <param name="objSalereturnObject"></param>
        /// <returns></returns>
        public List<SaleReturnObjectClass> Get_QuickReturnSerialNo(SaleReturnObjectClass objSalereturnObject)
        {
            try
            {
                List<SaleReturnObjectClass> lstSalereturnObject = new List<SaleReturnObjectClass>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSalereturnObject.itemno);
                var result = SQLHelper.Instance.GetReader("Sp_Get_Serialno_QuickReturn", param);
                while (result.Read())
                {
                    lstSalereturnObject.Add(new SaleReturnObjectClass
                    {
                        serialno = result["SerialNo"].ToString(),
                        unitprice = Convert.ToDecimal(result["Price"])

                    });
                }
                return lstSalereturnObject;
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

        public int GetUndoStockDetails(SaleReturnObjectClass ObjSaleReturn)
        {
            try
            {
                int countofitem = 0;
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@BarcodeID", ObjSaleReturn.BarcodeID);
                param[1] = new SqlParameter("@ItemID", ObjSaleReturn.itemno);
                param[2] = new SqlParameter("@AgentID", ObjSaleReturn.clientno);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT COUNT(*) AS Count FROM dbo.SaleReturn WHERE BarcodeID=@BarcodeID AND ItemID=@ItemID AND AgentID=@AgentID", param);
                while (result.Read())
                {
                    countofitem = Convert.ToInt32(result["Count"]);
                }


                return countofitem;


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
        public int UndoQuickRetrunItem(SaleReturnObjectClass ObjSaleReturn)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ItemID", ObjSaleReturn.itemno);
            param[1] = new SqlParameter("@BarcodeID", ObjSaleReturn.BarcodeID);
            param[2] = new SqlParameter("@AgentID", ObjSaleReturn.clientno);
            return SQLHelper.Instance.ExecuteNonQuery("usp_unto_Quickretrun", param);
        }
        public int GetSaleIdWithYearSequenceNo(SaleReturnObjectClass ObjSaleRetrun)
        {
            try
            {
                int saleId = 0;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Year", ObjSaleRetrun.Year);
                param[1] = new SqlParameter("@YearSequenceNo", ObjSaleRetrun.YearSequenceNo);
                var result = SQLHelper.Instance.GetReaderWithQuery("Select SaleID from sales Where [Year]=@Year And YearSequenceNo=@YearSequenceNo AND SaleType=1", param);
                if (result.Read())
                {
                    saleId = Convert.ToInt32(result["SaleID"]);
                }
                return saleId;
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

        public int check_PaymentAndPaymentDetails(SaleReturnObjectClass objSaleReturn)
        {
            int paymentID = 0;

            try
            {
                SqlParameter[] param = new SqlParameter[0];
                //param[0] = new SqlParameter("@desc", "\'" + objSaleReturn.paydiscription + "\'");
                //param[1] = new SqlParameter("@purchaseID", objSaleReturn.saleid);
                //var result = SQLHelper.Instance.GetReaderWithQuery("sp_CheckIsAvailable_PaymentNDetails", param);
                var result = SQLHelper.Instance.GetReaderWithQuery("EXEC  sp_CheckIsAvailable_PaymentNDetails @desc = '" + objSaleReturn.paydiscription + "',@purchaseID =" + objSaleReturn.saleid + "", param);
                if (result.Read())
                {
                    paymentID = Convert.ToInt32(result["PaymentID"]);
                    return paymentID;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return paymentID;

        }
    }

}