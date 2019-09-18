using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HSB_ObjectHelper;
using System.Data.SqlClient;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class PayReceiptDAL
    {
        #region Constant Variables

        private const String SpNameGetBalanceSheet = "SP_Get_BalanceSheet";
        private const string SpNameSavePayReceipt = "SP_Save_PayReceipt";
        private const string SpNameDeletePayReceipt = "SP_Delete_PayReceipt";
        private const string SpReportPayReceiptDetails = "Usp_Report_PayReceiptDetails";
        private const string SPNameInsertBankDepositDetails = "SP_Insert_BankDepositDetails";
        #endregion

        #region Methods

        #region GetBalanceSheetDetails
        public List<PayReceiptObject> GetBalanceSheetDetails(PayReceiptObject objPayReceiptObject)
        {

            List<PayReceiptObject> lstBalance = new List<PayReceiptObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@AgentID", objPayReceiptObject.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objPayReceiptObject.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objPayReceiptObject.BalanceToDate;
                param[3] = new SqlParameter("@Status", objPayReceiptObject.BalanceStatus);

                var reader = SQLHelper.Instance.GetReader(SpNameGetBalanceSheet, param);
                while (reader.Read())
                {

                    lstBalance.Add(new PayReceiptObject
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

        #region SavePayReceiptDetails
        public bool SavePayReceiptDetails(PayReceiptObject objPayReceipt)
        {
            SqlParameter[] param = new SqlParameter[20];
            List<PayReceiptObject> lstMaxId = new List<PayReceiptObject>();
            try
            
            {
                param[0] = new SqlParameter("@PayMethodID", objPayReceipt.PayMethod);
                param[1] = new SqlParameter("@AgentID", objPayReceipt.PayTo);
                param[2] = new SqlParameter("@PurchaseID", objPayReceipt.PayInvoiceID);
                param[3] = new SqlParameter("@PayInvoice", objPayReceipt.PayInvoiceNo);
                param[4] = new SqlParameter("@BalanceAmount", objPayReceipt.PayBalance);
                param[5] = new SqlParameter("@PaymentDate", objPayReceipt.PayPaymentDate);
                //param[6] = new SqlParameter("@CreatedDate", objPayReceipt.PayCreateDate);
                param[6] = new SqlParameter("@CreatedBy", objPayReceipt.PayCreatedBy);
                // param[8] = new SqlParameter("@ModifiedDate", objPayReceipt.PayModifiedDate);
                param[7] = new SqlParameter("@ModifiedBy", objPayReceipt.PayModifiedBy);
                param[8] = new SqlParameter("@Status", objPayReceipt.PayStatus);
                param[9] = new SqlParameter("@Description", objPayReceipt.PayDiscription);
                param[10] = new SqlParameter("@Reason", objPayReceipt.PayReason);
                param[11] = new SqlParameter("@BankID", objPayReceipt.BankID);
                param[12] = new SqlParameter("@BranchID", objPayReceipt.BranchID);
                param[13] = new SqlParameter("@UserID", objPayReceipt.PayUserId);
                param[14] = new SqlParameter("@GrossAmount", objPayReceipt.PayGross);
                param[15] = new SqlParameter("@AmountPaid", objPayReceipt.PayValue);
                param[16] = new SqlParameter("@PaidDate", objPayReceipt.PayDate);
                param[17] = new SqlParameter("@Remarks", objPayReceipt.PayRemarks);
                param[18] = new SqlParameter("@ReceiptFor", objPayReceipt.PayFlag);
                param[19] = new SqlParameter("@DescriptionArabic", objPayReceipt.PayDiscriptionArabic);

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

        public bool Insert_BankTransactionDetails(PayReceiptObject objReceiveReceipt, bool isEmptyRecord)
        {

            try
            {
                objReceiveReceipt.TempValue = 0;
                SqlParameter[] Params = new SqlParameter[14];
                SqlParameter[] ParamsEmpty = new SqlParameter[14];
                if (!isEmptyRecord)
                {
                    Params[0] = new SqlParameter("@BankNameID", objReceiveReceipt.BankID);
                    Params[1] = new SqlParameter("@BranchNameID", objReceiveReceipt.BranchID);
                    Params[2] = new SqlParameter("@Description", objReceiveReceipt.PayDiscription);
                    Params[3] = new SqlParameter("@DoneBy", objReceiveReceipt.PayDiscription);
                    Params[4] = new SqlParameter("@Reason", "Cash Sales");
                    Params[5] = new SqlParameter("@Amount", objReceiveReceipt.PayValue);
                    Params[6] = new SqlParameter("@TransactionFlag", 2);
                    Params[7] = new SqlParameter("@BankToMoveID", objReceiveReceipt.TempValue);
                    Params[8] = new SqlParameter("@BranchToMoveID", objReceiveReceipt.TempValue);
                    Params[9] = new SqlParameter("@ProcessDate", objReceiveReceipt.PayDate);

                    Params[10] = new SqlParameter("@CreatedBy", objReceiveReceipt.PayUserId);
                    Params[11] = new SqlParameter("@ReasonId", objReceiveReceipt.TempValue);
                    Params[12] = new SqlParameter("@Status", 1);
                    Params[13] = new SqlParameter("@TableId", 11);
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
                    Params[6] = new SqlParameter("@TransactionFlag", 2);
                    Params[7] = new SqlParameter("@BankToMoveID", objReceiveReceipt.TempValue);
                    Params[8] = new SqlParameter("@BranchToMoveID", objReceiveReceipt.TempValue);
                    Params[9] = new SqlParameter("@ProcessDate", DateTime.Now);

                    Params[10] = new SqlParameter("@CreatedBy", objReceiveReceipt.PayUserId);
                    Params[11] = new SqlParameter("@ReasonId", objReceiveReceipt.TempValue);
                    Params[12] = new SqlParameter("@Status", 1);
                    Params[13] = new SqlParameter("@TableId", 11);
                    if (SQLHelper.Instance.ExecuteNonQuery(SPNameInsertBankDepositDetails, Params) > 0)
                    {

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

            #region getMinMaxID
        private List<PayReceiptObject> getMinMaxID()
        {
            try
            {
                List<PayReceiptObject> lstMinMax = new List<PayReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Payment);
                var result = SQLHelper.Instance.GetReaderWithQuery("UPDATE dbo.KeySequence SET MaxId = MaxId + 1,YearMaxId = YearMaxId + 1 OUTPUT   INSERTED.MaxId-1 as  MaxId,INSERTED.YearMaxId-1 as YearMaxId,INSERTED.YearValue as YearValue WHERE TableId =@TableId", sqlParam);
                if (result.Read())
                {

                    lstMinMax.Add(new PayReceiptObject
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
        #endregion

        #region DeletePayReceiptDetails
        public bool DeletePayReceiptDetails(PayReceiptObject objPayReceipt)
        {
            SqlParameter[] param = new SqlParameter[9];

            try
            {
                param[0] = new SqlParameter("@PaymentID", objPayReceipt.PayReceiptNo);
                param[1] = new SqlParameter("@AgentID", objPayReceipt.PayTo);
                param[2] = new SqlParameter("@Description", objPayReceipt.PayDiscription);
                param[3] = new SqlParameter("@AmtPaid", objPayReceipt.PayValue);
                param[4] = new SqlParameter("@Reason", objPayReceipt.PayReason);
                param[5] = new SqlParameter("@ModifiedDate", objPayReceipt.PayModifiedDate);
                param[6] = new SqlParameter("@ModifiedBy", objPayReceipt.PayModifiedBy);
                param[7] = new SqlParameter("@Status", objPayReceipt.PayStatus);
                param[8] = new SqlParameter("@Remarks", objPayReceipt.PayRemarks);

                if (SQLHelper.Instance.ExecuteNonQuery(SpNameDeletePayReceipt, param) > 0)
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

        #region FetchLastRecord
        public bool FetchLastRecord(out  List<PayReceiptObject> lstLastRecord)
        {
            try
            {
                lstLastRecord = new List<PayReceiptObject>();
                //  var ReaderResult = SQLHelper.Instance.GetReader("");
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Payment);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery(" SELECT P.PaymentID,P.AgentID,P.[Description],PD.AmountPaid,P.BalanceAmount,P.Reason,P.[Year],P.YearSequenceNo,PD.PaidDate,P.PayMethodID,P.BankID,P.BranchID,PD.Remarks,P.[Status] FROM dbo.Payment  AS P INNER JOIN dbo.PaymentDetails AS PD ON P.PaymentID=PD.PaymentID WHERE ReceiptFor<>1 AND PaymentID=(SELECT ISNULL(MaxId,1)-1 FROM dbo.KeySequence WHERE TableId=@TableId) ORDER BY P.PaymentID", sqlParam);
                if (ReaderResult.Read())
                {
                    lstLastRecord.Add(new PayReceiptObject
                    {
                        PayReceiptNo = Convert.ToInt64(ReaderResult["PaymentID"]),
                        AgentID = Convert.ToInt16(ReaderResult["AgentID"]),
                        PayDiscription = ReaderResult["Description"].ToString(),
                        AmountPaid = Convert.ToDecimal(ReaderResult["AmountPaid"]),
                        BalanceAmount = Convert.ToDecimal(ReaderResult["BalanceAmount"] == DBNull.Value ? 0.000 : ReaderResult["BalanceAmount"]),
                        PayReason = ReaderResult["Reason"].ToString(),
                        Year = Convert.ToInt16(ReaderResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
                        PayDate = Convert.ToDateTime(ReaderResult["PaidDate"] == DBNull.Value ? null : ReaderResult["PaidDate"]),
                        PayMethodID = Convert.ToInt16(ReaderResult["PayMethodID"]),
                        BankID = Convert.ToInt16(ReaderResult["BankID"] == DBNull.Value ? null : ReaderResult["BankID"]),
                        BranchID = Convert.ToInt16(ReaderResult["BranchID"] == DBNull.Value ? null : ReaderResult["BranchID"]),
                        PayRemarks = ReaderResult["Remarks"].ToString(),
                        PayStatus = Convert.ToInt16(ReaderResult["Status"])
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
        #endregion

        #region GetPayRecord
        public bool GetPayRecord(PayReceiptObject objPayReceipt, out  List<PayReceiptObject> lstPrevRecord)
        {
            try
            {
                lstPrevRecord = new List<PayReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@PaymentID", objPayReceipt.PayReceiptNo);
               // var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT P.PaymentID,P.AgentID,P.[Description],PD.AmountPaid,P.BalanceAmount,P.Reason,P.[Year],P.YearSequenceNo,PD.PaidDate,P.PayMethodID,P.BankID,P.BranchID,PD.Remarks,P.[Status] FROM dbo.Payment  AS P  LEFT JOIN dbo.PaymentDetails AS PD ON P.PaymentID=PD.PaymentID WHERE ReceiptFor<>1 AND P.PaymentID=@PaymentID ORDER BY P.PaymentID", sqlParam);
                var ReaderResult = SQLHelper.Instance.GetReader("SpPayReceipt", sqlParam);
                if (ReaderResult.Read())
                {
                    lstPrevRecord.Add(new PayReceiptObject
                    {
                        PayReceiptNo = Convert.ToInt64(ReaderResult["PaymentID"]),
                        AgentID = Convert.ToInt16(ReaderResult["AgentID"]),
                        PayDiscription = ReaderResult["Description"].ToString(),
                        AmountPaid = ReaderResult["AmountPaid"] == DBNull.Value ? 0 : Convert.ToDecimal(ReaderResult["AmountPaid"]),
                        BalanceAmount = Convert.ToDecimal(ReaderResult["BalanceAmount"] == DBNull.Value ? 0.000 : ReaderResult["BalanceAmount"]),
                        PayReason = ReaderResult["Reason"].ToString(),
                        Year = Convert.ToInt16(ReaderResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
                        PayDate = Convert.ToDateTime(ReaderResult["PaidDate"] == DBNull.Value ? null : ReaderResult["PaidDate"]),
                        PayMethodID = Convert.ToInt16(ReaderResult["PayMethodID"]),
                        BankID = Convert.ToInt16(ReaderResult["BankID"] == DBNull.Value ? null : ReaderResult["BankID"]),
                        BranchID = Convert.ToInt16(ReaderResult["BranchID"] == DBNull.Value ? null : ReaderResult["BranchID"]),
                        PayRemarks = ReaderResult["Remarks"] == DBNull.Value ? "" : ReaderResult["Remarks"].ToString(),
                        PayStatus = Convert.ToInt16(ReaderResult["Status"])
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
        #endregion

        #region GetSearchedRecord
        public bool GetSearchedRecord(PayReceiptObject objPayReceipt, out  List<PayReceiptObject> lstSearchRecord)
        {
            try
            {
                lstSearchRecord = new List<PayReceiptObject>();
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@Year", objPayReceipt.Year);
                sqlParam[1] = new SqlParameter("@YearSequenceNo", objPayReceipt.YearSequenceNo);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery(" SELECT P.PaymentID,P.AgentID,P.[Description],PD.AmountPaid,P.BalanceAmount,P.Reason,P.[Year],P.YearSequenceNo,PD.PaidDate,P.PayMethodID,P.BankID,P.BranchID,PD.Remarks,P.[Status] FROM dbo.Payment  AS P INNER JOIN dbo.PaymentDetails AS PD ON P.PaymentID=PD.PaymentID WHERE ReceiptFor<>1 AND Year=@Year AND YearSequenceNo=@YearSequenceNo ", sqlParam);
                if (ReaderResult.Read())
                {
                    lstSearchRecord.Add(new PayReceiptObject
                    {

                        PayReceiptNo = Convert.ToInt64(ReaderResult["PaymentID"]),
                        AgentID = Convert.ToInt16(ReaderResult["AgentID"]),
                        PayDiscription = ReaderResult["Description"].ToString(),
                        AmountPaid = Convert.ToDecimal(ReaderResult["AmountPaid"]),
                        BalanceAmount = Convert.ToDecimal(ReaderResult["BalanceAmount"] == DBNull.Value ? 0.000 : ReaderResult["BalanceAmount"]),
                        PayReason = ReaderResult["Reason"].ToString(),
                        Year = Convert.ToInt16(ReaderResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
                        PayDate = Convert.ToDateTime(ReaderResult["PaidDate"] == DBNull.Value ? null : ReaderResult["PaidDate"]),
                        PayMethodID = Convert.ToInt16(ReaderResult["PayMethodID"]),
                        BankID = Convert.ToInt16(ReaderResult["BankID"] == DBNull.Value ? null : ReaderResult["BankID"]),
                        BranchID = Convert.ToInt16(ReaderResult["BranchID"] == DBNull.Value ? null : ReaderResult["BranchID"]),
                        PayRemarks = ReaderResult["Remarks"].ToString(),
                        PayStatus = Convert.ToInt16(ReaderResult["Status"])

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
        #endregion

        #region GetAllPaymentID
        public List<PayReceiptObject> GetAllPaymentID()
        {
            try
            {
                List<PayReceiptObject> lstAllPaymentId = new List<PayReceiptObject>();
                var ReaderResult = SQLHelper.Instance.GetReader(" SELECT Distinct P.PaymentID FROM dbo.Payment  AS P LEFT JOIN dbo.PaymentDetails AS PD ON P.PaymentID=PD.PaymentID WHERE ReceiptFor<>1  ORDER BY P.PaymentID");
                while (ReaderResult.Read())
                {
                    lstAllPaymentId.Add(new PayReceiptObject
                    {
                        PayReceiptNo = Convert.ToInt64(ReaderResult["PaymentID"]),

                    });

                }

                return lstAllPaymentId;
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

        #region GetCurrentYear()
        public object GetCurrentYear()
        {
            try
            {
                object CurrentYear;
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Payment);
                CurrentYear = SQLHelper.Instance.GetScalarQuery("SELECT YearValue FROM KeySequence WHERE TableId=@TableId", sqlParam);

                return CurrentYear;

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

        #region Get_MaxIdOfPaymentRecord
        public object Get_MaxIdOfPaymentRecord()
        {

            try
            {
                object PaymentMinID;
                string Query = "SELECT MaxId FROM KeySequence WHERE TableId=8";
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

        public object GetBankDeposit_MaxID()
        {
            try
            {
                object MaxId;
                string Query = "SELECT MaxId FROM keysequence WHERE TableId=11";
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
        #endregion

        #region GetPayReceiptPrintReport
        public DataTable GetPayReceiptPrintReport(PayReceiptObject objPayReceipt)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@PaymentID", objPayReceipt.PayReceiptNo);
                return SQLHelper.Instance.ExecuteQueryDatatable(SpReportPayReceiptDetails, Param, "ReportValues");
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


    }
}
