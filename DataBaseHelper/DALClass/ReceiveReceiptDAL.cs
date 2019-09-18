using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HSB_ObjectHelper;
using System.Data.SqlClient;
using ObjectHelper;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class ReceiveReceiptDAL
    {
        #region Constant Variables
        private const string SPNameSpGetOption = "SP_Get_Option";
        private const string SPSaveCustomerReceipt = "Sp_Save_Customer_Receipt";
        private const string SPDeleteCustomerReceipt = "Sp_Delete_Receipt_Direct_A";
        private const string SPNameInsertBankDepositDetails = "SP_Insert_BankDepositDetails";
        #endregion

        #region Methods

        public bool SaveReceiveReceiptDetails(ReceiveReceiptObject objReceiveReceipt)
        {
            SqlParameter[] param = new SqlParameter[19];
            List<ReceiveReceiptObject> lstMaxId = new List<ReceiveReceiptObject>();
            try
            {
                param[0] = new SqlParameter("@PayMethodID", objReceiveReceipt.paymethodid);
                param[1] = new SqlParameter("@SaleID", objReceiveReceipt.saleid);
                param[2] = new SqlParameter("@SaleInvoice", objReceiveReceipt.saleinv);
                param[3] = new SqlParameter("@BalanceAmount", objReceiveReceipt.balance);
                param[4] = new SqlParameter("@ReceiptDate", objReceiveReceipt.receiptdate);
                // param[5] = new SqlParameter("@DateCreated", DateTime.Now);
                param[5] = new SqlParameter("@CreatedBy", objReceiveReceipt.UserId);
                // param[7] = new SqlParameter("@DateModified", DateTime.Now);
                param[6] = new SqlParameter("@ModifiedBy", objReceiveReceipt.UserId);
                param[7] = new SqlParameter("@Status", objReceiveReceipt.Status);
                param[8] = new SqlParameter("@AgentID", objReceiveReceipt.receivedfrom);
                param[9] = new SqlParameter("@Bank", objReceiveReceipt.bank);
                param[10] = new SqlParameter("@Branch", objReceiveReceipt.branch);
                param[11] = new SqlParameter("@Discription", objReceiveReceipt.discription);
                param[12] = new SqlParameter("@Note", objReceiveReceipt.note);
                param[13] = new SqlParameter("@ReceiptFor", objReceiveReceipt.saletype);
                param[14] = new SqlParameter("@DiscriptionArabic", objReceiveReceipt.discriptionarabic);
                param[15] = new SqlParameter("@GrossAmt", objReceiveReceipt.grossamount);
                param[16] = new SqlParameter("@AmtReceived", objReceiveReceipt.netvalue);
                param[17] = new SqlParameter("@ReceivedDate", objReceiveReceipt.receiptdate);
                param[18] = new SqlParameter("@Remarks", "Save");


                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveCustomerReceipt, param) > 0)
                {
                    //lst = getMinMaxID();
                    return true;
                }
                else
                {
                    //lst = null;
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

        public bool Insert_BankTransactionDetails(ReceiveReceiptObject objReceiveReceipt,bool isEmptyRecord)
        {

            try
            {
                objReceiveReceipt.TempValue = 0;
                SqlParameter[] Params = new SqlParameter[14];
                SqlParameter[] ParamsEmpty = new SqlParameter[14];
                if (!isEmptyRecord)
                {
                    Params[0] = new SqlParameter("@BankNameID", objReceiveReceipt.bank);
                    Params[1] = new SqlParameter("@BranchNameID", objReceiveReceipt.branch);
                    Params[2] = new SqlParameter("@Description", objReceiveReceipt.discription);
                    Params[3] = new SqlParameter("@DoneBy", objReceiveReceipt.discription);
                    Params[4] = new SqlParameter("@Reason", "Cash Sales");
                    Params[5] = new SqlParameter("@Amount", objReceiveReceipt.netvalue);
                    Params[6] = new SqlParameter("@TransactionFlag", 1);
                    Params[7] = new SqlParameter("@BankToMoveID", objReceiveReceipt.TempValue);
                    Params[8] = new SqlParameter("@BranchToMoveID", objReceiveReceipt.TempValue);
                    Params[9] = new SqlParameter("@ProcessDate", objReceiveReceipt.receiptdate);

                    Params[10] = new SqlParameter("@CreatedBy", objReceiveReceipt.UserId);
                    Params[11] = new SqlParameter("@ReasonId", objReceiveReceipt.TempValue);
                    Params[12] = new SqlParameter("@Status", 1);
                    Params[13] = new SqlParameter("@TableId", 4);
                    if (SQLHelper.Instance.ExecuteNonQuery(SPNameInsertBankDepositDetails, Params) > 0)
                    {

                        return true;
                    }
                }
                else
                {
                    Params[0] = new SqlParameter("@BankNameID", objReceiveReceipt.TempValue);
                    Params[1] = new SqlParameter("@BranchNameID", objReceiveReceipt.TempValue);
                    Params[2] = new SqlParameter("@Description", "");
                    Params[3] = new SqlParameter("@DoneBy", "");
                    Params[4] = new SqlParameter("@Reason", "");
                    Params[5] = new SqlParameter("@Amount", objReceiveReceipt.TempValue);
                    Params[6] = new SqlParameter("@TransactionFlag", 1);
                    Params[7] = new SqlParameter("@BankToMoveID", objReceiveReceipt.TempValue);
                    Params[8] = new SqlParameter("@BranchToMoveID", objReceiveReceipt.TempValue);
                    Params[9] = new SqlParameter("@ProcessDate", DateTime.Now);

                    Params[10] = new SqlParameter("@CreatedBy", objReceiveReceipt.UserId);
                    Params[11] = new SqlParameter("@ReasonId", objReceiveReceipt.TempValue);
                    Params[12] = new SqlParameter("@Status", 1);
                    Params[13] = new SqlParameter("@TableId", 4);
                    if (SQLHelper.Instance.ExecuteNonQuery(SPNameInsertBankDepositDetails, Params) > 0)
                    {

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        private List<ReceiveReceiptObject> getMinMaxID()
        {
            try
            {
                List<ReceiveReceiptObject> lstMinMax = new List<ReceiveReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.CustomerReceipt);
                var result = SQLHelper.Instance.GetReaderWithQuery("UPDATE dbo.KeySequence SET MaxId = MaxId + 1,YearMaxId = YearMaxId + 1 OUTPUT   INSERTED.MaxId-1 as  MaxId,INSERTED.YearMaxId-1 as YearMaxId,INSERTED.YearValue as YearValue WHERE TableId =@TableId", sqlParam);
                if (result.Read())
                {

                    lstMinMax.Add(new ReceiveReceiptObject
                    {
                        MaxpayReceiptNo = Convert.ToInt64(result[0]),
                        YearSequenceNo = Convert.ToInt32(result[1]),
                        Year = Convert.ToInt32(result[2])
                    });
                }
                return lstMinMax;
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


        public bool UpdateSaleBalance(ReceiveReceiptObject objReceiveReceipt)
        {

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SaleInvoice", objReceiveReceipt.saleid);
                param[1] = new SqlParameter("@Balance", objReceiveReceipt.balance);

                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Sales SET Balance=@Balance WHERE SaleInvoice=@SaleInvoice", param) > 0)
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

        public bool UpdatePaymentType(ReceiveReceiptObject objReceiveReceipt)
        {

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SaleInvoice", objReceiveReceipt.saleid);
                param[1] = new SqlParameter("@PaymentTypeID", objReceiveReceipt.PaymentTypeID);

                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Sales SET PaymentTypeID=@PaymentTypeID WHERE SaleInvoice=@SaleInvoice", param) > 0)
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
        public bool UpdatePaymentCharges(ReceiveReceiptObject objReceiveReceipt)
        {

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SaleInvoice", objReceiveReceipt.saleid);
                param[1] = new SqlParameter("@PaymentCharges", objReceiveReceipt.PaymentCharges);

                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Sales SET PaymentCharges=@PaymentCharges WHERE SaleInvoice=@SaleInvoice", param) > 0)
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

        public bool GetPrevNextRecord(ReceiveReceiptObject objReceiveReceipt, out  List<ReceiveReceiptObject> lstPrevRecord)
        {
            try
            {
                lstPrevRecord = new List<ReceiveReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@ReceiptID", objReceiveReceipt.receiptid);
               // var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT a.AgentID,a.[Description] ,b.AmountReceived ,a.Note,a.BalanceAmount,a.[Status],a.PayMethodID ,a.BankID ,a.BranchID ,a.[Year],a.YearSequenceNo,a.ReceiptDate,a.SaleID FROM DBO.CustomerReceipt a (NOLOCK) LEFT  JOIN DBO.CustomerReceiptDetails b (NOLOCK) ON a.ReceiptID = b.ReceiptID  WHERE a.ReceiptID = @ReceiptID and ReceiptFor!=1", sqlParam);
                var ReaderResult = SQLHelper.Instance.GetReader("SpReceiveReceipt", sqlParam);
                if (ReaderResult.Read())
                {
                    lstPrevRecord.Add(new ReceiveReceiptObject
                    {
                        AgentID = Convert.ToInt16(ReaderResult["AgentID"]),
                        discription = ReaderResult["Description"].ToString(),
                        AmountReceived = ReaderResult["AmountReceived"] == DBNull.Value ? 0 : Convert.ToDecimal(ReaderResult["AmountReceived"]),
                        note = ReaderResult["Note"].ToString(),
                        balance = Convert.ToDecimal(ReaderResult["BalanceAmount"] == DBNull.Value ? 0.000 : ReaderResult["BalanceAmount"]),
                        Status = Convert.ToInt16(ReaderResult["Status"]),
                        paymethodid = Convert.ToInt16(ReaderResult["PayMethodID"]),
                        BankSelectedVal = Convert.ToInt16(ReaderResult["BankID"] == DBNull.Value ? null : ReaderResult["BankID"]),
                        BranchSelectedVal = Convert.ToInt16(ReaderResult["BranchID"] == DBNull.Value ? null : ReaderResult["BranchID"]),
                        Year = Convert.ToInt16(ReaderResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
                        receiptdate = Convert.ToDateTime(ReaderResult["ReceiptDate"]),
                        saleid=ReaderResult["SaleID"] == DBNull.Value ?0:Convert.ToInt32(ReaderResult["SaleID"])
                    });
                    return true;
                }

                else
                    return false;
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

        public bool GetAllReceiptID(out  List<ReceiveReceiptObject> lstAllReceiptId)
        {
            try
            {
                lstAllReceiptId = new List<ReceiveReceiptObject>();
                var ReaderResult = SQLHelper.Instance.GetReader("SELECT a.ReceiptID FROM DBO.CustomerReceipt a Where a.receiptFor<>1 Order By a.Receiptid");
                while (ReaderResult.Read())
                {
                    lstAllReceiptId.Add(new ReceiveReceiptObject
                    {
                        receiptid = Convert.ToInt64(ReaderResult["ReceiptID"]),

                    });

                }

                return true;
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

        public bool GetSearchedRecord(ReceiveReceiptObject objReceiveReceipt, out  List<ReceiveReceiptObject> lstPrevRecord)
        {
            try
            {
                lstPrevRecord = new List<ReceiveReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@Year", objReceiveReceipt.Year);
                sqlParam[1] = new SqlParameter("@YearSequenceNo", objReceiveReceipt.YearSequenceNo);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT AGT.AgentName AS AgentName,AGT.AgentID AS AgentID,a.[Description] ,b.AmountReceived ,a.Note,a.BalanceAmount,a.[Status],a.PayMethodID ,a.BankID ,a.BranchID ,a.[Year],a.YearSequenceNo,a.ReceiptDate FROM DBO.CustomerReceipt a (NOLOCK) INNER JOIN DBO.CustomerReceiptDetails b (NOLOCK) ON a.ReceiptID = b.ReceiptID LEFT JOIN DBO.Agent AGT (NOLOCK) ON AGT.AgentID = a.AgentID WHERE a.Year = @Year AND a.YearSequenceNo=@YearSequenceNo", sqlParam);
                if (ReaderResult.Read())
                {
                    lstPrevRecord.Add(new ReceiveReceiptObject
                    {
                        AgentName = ReaderResult["AgentName"].ToString(),
                        AgentID = Convert.ToInt16(ReaderResult["AgentID"]),
                        discription = ReaderResult["Description"].ToString(),
                        AmountReceived = Convert.ToDecimal(ReaderResult["AmountReceived"]),
                        note = ReaderResult["Note"].ToString(),
                        balance = Convert.ToDecimal(ReaderResult["BalanceAmount"] == DBNull.Value ? 0.000 : ReaderResult["BalanceAmount"]),
                        Status = Convert.ToInt16(ReaderResult["Status"]),
                        paymethodid = Convert.ToInt16(ReaderResult["PayMethodID"]),
                        BankSelectedVal = Convert.ToInt16(ReaderResult["BankID"] == DBNull.Value ? null : ReaderResult["BankID"]),
                        BranchSelectedVal = Convert.ToInt16(ReaderResult["BranchID"] == DBNull.Value ? null : ReaderResult["BranchID"]),
                        Year = Convert.ToInt16(ReaderResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
                        receiptdate = Convert.ToDateTime(ReaderResult["ReceiptDate"])
                    });
                    return true;
                }

                else
                    return false;
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

        public bool DeleteReceiptDetails(ReceiveReceiptObject objReceiveReceipt)
        {
            SqlParameter[] param = new SqlParameter[1];
            try
            {
                param[0] = new SqlParameter("@ReceiptID", objReceiveReceipt.receiptid);

                if (SQLHelper.Instance.ExecuteNonQuery(SPDeleteCustomerReceipt, param) > 0)
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

        #region GetCurrentYear()
        public object GetCurrentYear()
        {
            try
            {
                object Year;
                List<ReceiveReceiptObject> lstWithYear = new List<ReceiveReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.CustomerReceipt);
                Year = SQLHelper.Instance.GetScalarQuery("SELECT YearValue FROM KeySequence WHERE TableId=@TableId", sqlParam);

                return Year;
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

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

        #endregion
        #endregion

        public object GetReceipt_MaxID()
        {
            try
            {
                object MaxId;
                string Query = "SELECT MaxId FROM keysequence WHERE TableId=7";
                MaxId = SQLHelper.Instance.GetScalar(Query);
                return MaxId;
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

        public object GetBankDeposit_MaxID()
        {
            try
            {
                object MaxId;
                string Query = "SELECT MaxId FROM keysequence WHERE TableId=4";
                MaxId = SQLHelper.Instance.GetScalar(Query);
                return MaxId;
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

        public List<BankObjectClass> BranchDetails()
        {
            try
            {
                var Query = "SELECT BranchID,BranchName FROM Branch WHERE status=1 ORDER BY BranchName";
                GeneralObjectClass.BranchList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.BranchList.Add(new BankObjectClass
                        {
                            BranchNameID = Convert.ToInt32(result[0]),
                            BranchName = result[1].ToString()
                        });
                    }
                }
                return GeneralObjectClass.BranchList;
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
        public List<BankObjectClass> GetBankDetails()
        {
            try
            {
                var Query = "SELECT BankID,BankName from Bank WHERE Status=1 ORDER BY BankName";
                GeneralObjectClass.BankList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.BankList.Add(new BankObjectClass
                        {
                            BankNameID = Convert.ToInt32(result[0]),
                            BankName = result[1].ToString()
                        });
                    }
                }
                return GeneralObjectClass.BankList;
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
