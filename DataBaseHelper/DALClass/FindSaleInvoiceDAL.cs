using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;
using System.Globalization;


namespace DataBaseHelper.DALClass
{
    public class FindSaleInvoiceDAL
    {

        #region Declaration
        FindSaleInvoiceDAL objFindSaleInvoiceDAL;
        public static List<FindSaleInvoiceObject> lstPaymentDate = new List<FindSaleInvoiceObject>();
        public static List<FindSaleInvoiceObject> lstAgentPayment = new List<FindSaleInvoiceObject>();
        #endregion

        #region Constant Variables
        private const string SPNameSpGetPaymentDateA = "Sp_Get_PaymentDate_A";
        private const string SpNameGetBalanceSheet = "SP_Get_BalanceSheet";
        private const string SPFindInvoice = "Sp_invoice_all_mod_A";
        private const string SPFindAllInvoice = "Sp_invoice_checkall_mod_A";
        private const string SPGetInvoiceItemDetails = "Sp_Invno_Details_A_m";
        private const string SPGetReturnInvoiceItemDetails = "Sp_Get_ReturnSaleDetails_A";
        private const string SPGetPOSInvoiceItemDetails = "Sp_POS_Details_A";
        private const string SPGetFindSalesReport = "sp_findsalereport";
        private const string SPGetSpoiledInvoiceItemDetails = "Sp_Spoiled_Details_A";
        
        #endregion

        #region Saradhaa Done
        public static void LoadNotesAndAlertsData()
        {

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(SPNameSpGetPaymentDateA, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    var result = sqlCmd.ExecuteReader();
                    AgentPaymentList(lstAgentPayment, result);
                    result.NextResult();
                    PaymentDateList(lstPaymentDate, result);

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


        private static void AgentPaymentList(List<FindSaleInvoiceObject> lstAgentPayment, SqlDataReader result)
        {

            while (result.Read())
            {
                lstAgentPayment.Add(new FindSaleInvoiceObject
                {
                    AgentName = result[0].ToString()


                });
            }
        }

        private static void PaymentDateList(List<FindSaleInvoiceObject> lstPaymentDate, SqlDataReader result)
        {

            while (result.Read())
            {
                lstPaymentDate.Add(new FindSaleInvoiceObject
                {

                    PaymentDate = Convert.ToDateTime(result[0]).Date,
                    AgentName = result[1].ToString()

                });
            }
        }

        #endregion

        #region Methods

        #region GetBalanceSheetDetails

        public List<FindSaleInvoiceObject> GetBalanceSheetDetails(FindSaleInvoiceObject objFindSale)
        {

            List<FindSaleInvoiceObject> lstBalance = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@AgentID", objFindSale.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objFindSale.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objFindSale.BalanceToDate;
                param[3] = new SqlParameter("@Status", objFindSale.BalanceStatus);

                var reader = SQLHelper.Instance.GetReader(SpNameGetBalanceSheet, param);
                while (reader.Read())
                {

                    lstBalance.Add(new FindSaleInvoiceObject
                    {

                        AmountRecieved = Convert.ToDecimal(reader[4]),
                        NetAmount = Convert.ToDecimal(reader[5])

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

            return lstBalance;
        }

        #endregion

        #region GetInvoiceDetails
        public List<FindSaleInvoiceObject> GetInvoiceDetails(FindSaleInvoiceObject objFindSale)
        {

            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Client", objFindSale.clientid);
                param[1] = new SqlParameter("@FromDate", objFindSale.fromdate);
                param[2] = new SqlParameter("@ToDate", objFindSale.todate);

                var reader = SQLHelper.Instance.GetReader(SPFindInvoice, param);
                while (reader.Read())
                {

                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        InvoiceNo = Convert.ToInt64(reader["InvoiceNo"]),
                        // SaleDate = Convert.ToDateTime(reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]).ToString("mm/dd/yy") : DateTime.MinValue.ToString("mm/dd/yy")),//Commented on 30-May-2014 for Restricting Other DateFormat like ("mm/dd/yy")
                        SaleDate = Convert.ToDateTime(reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]).Date : DateTime.MinValue).Date,//Added on 30-May-2014
                        ClientName = Convert.ToString(reader["Client"]),
                        Total = Convert.ToDecimal(reader["Total"] != DBNull.Value ? reader["Total"] : 0.000M),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        ReturnedQty = Convert.ToInt32(reader["Returned"] != DBNull.Value ? reader["Returned"] : 0),
                        Time = Convert.ToDateTime(reader["TIME"] != DBNull.Value ? reader["TIME"] : DateTime.MinValue),
                        NetAmount = Convert.ToDecimal(reader["net"] != DBNull.Value ? reader["net"] : 0.000M),
                        Status = Convert.ToInt32(reader["Status"]),
                        SaleID = Convert.ToInt64(reader["SaleID"]),
                        UserId = Convert.ToInt32(reader["User"]),
                        UserName = Convert.ToString(reader["username"]),
                        Paid = Convert.ToDecimal(reader["Paid"] != DBNull.Value ? reader["Paid"] : 0.000M),
                        InvoiceType = Convert.ToInt32(reader["InvoiceType"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        YearSequenceNo = Convert.ToInt64(reader["YearSequenceNo"]),
                        InvoiceTypeTwo = Convert.ToInt32(reader["InvoiceType2"]),
                        NewYearSequenceNo = reader["NewYearInvoice"].ToString()
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

            return lstInvoiceDet;
        }

        #endregion

        #region GetAllInvoiceDetails
        public List<FindSaleInvoiceObject> GetAllInvoiceDetails(FindSaleInvoiceObject objFindSale)
        {

            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Client", objFindSale.clientid);

                var reader = SQLHelper.Instance.GetReader(SPFindAllInvoice, param);
                while (reader.Read())
                {
                   // datetime
                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        InvoiceNo = Convert.ToInt64(reader["InvoiceNo"]),
                        SaleDate = Convert.ToDateTime(reader["Date"] != DBNull.Value ? reader["Date"] : DateTime.MinValue),
                      //  SaleDate = Convert.ToDateTime(DateTime.Now.ToString()),
                        ClientName = Convert.ToString(reader["Client"]),
                        Total = Convert.ToDecimal(reader["Total"] != DBNull.Value ? reader["Total"] : 0.000M),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        ReturnedQty = Convert.ToInt32(reader["Returned"] != DBNull.Value ? reader["Returned"] : 0),
                        Time = Convert.ToDateTime(reader["TIME"] != DBNull.Value ? reader["TIME"] : DateTime.MinValue),
                        NetAmount = Convert.ToDecimal(reader["net"] != DBNull.Value ? reader["net"] : 0.000M),
                        Status = Convert.ToInt32(reader["Status"]),
                        SaleID = Convert.ToInt64(reader["SaleID"]),
                        UserId = Convert.ToInt32(reader["User"]),
                        UserName = Convert.ToString(reader["username"]),
                        Paid = Convert.ToDecimal(reader["Paid"] != DBNull.Value ? reader["Paid"] : 0.000M),
                        InvoiceType = Convert.ToInt32(reader["InvoiceType"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        YearSequenceNo = Convert.ToInt64(reader["YearSequenceNo"]),
                        InvoiceTypeTwo = Convert.ToInt32(reader["InvoiceType2"]),
                        NewYearSequenceNo = reader["NewYearInvoice"].ToString()
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

            return lstInvoiceDet;
        }

        #endregion

        #region GetInvoiceItemDetails
        public List<FindSaleInvoiceObject> GetInvoiceItemDetails(FindSaleInvoiceObject objFindSale)
        {

            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInvoice", objFindSale.InvoiceNo);

                var reader = SQLHelper.Instance.GetReader(SPGetInvoiceItemDetails, param);
                while (reader.Read())
                {

                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        ItemDecsription = Convert.ToString(reader["ItemDescription"]),
                        itemid = Convert.ToInt32(reader["ItemID"]),
                        ItemNumber = reader["ItemNumber"] != DBNull.Value ? reader["ItemNumber"].ToString() : string.Empty,
                        Status = Convert.ToInt32(reader["Status"]),
                        SaleID = Convert.ToInt64(reader["SaleID"]),
                        clientid = Convert.ToInt32(reader["ClientID"]),
                        SaleDate = Convert.ToDateTime(reader["SaleDate"] != DBNull.Value ? reader["SaleDate"] : DateTime.MinValue),
                        ClientName = Convert.ToString(reader["ClientName"]),
                        Quantity = Convert.ToInt32(reader["Qty"]),
                        Price = Convert.ToDecimal(reader["Price"] != DBNull.Value ? reader["Price"] : 0.000M),
                        Total = Convert.ToDecimal(reader["Total"] != DBNull.Value ? reader["Total"] : 0.000M),
                        TotalCost = Convert.ToDecimal(reader["TotalCost"] != DBNull.Value ? reader["TotalCost"] : 0.000M),
                        ExpiryDate = Convert.ToDateTime(reader["Expiry"] != DBNull.Value ? reader["Expiry"] : DateTime.MinValue),
                        strExpiryDate = reader["Expiry"] != DBNull.Value? Convert.ToDateTime(reader["Expiry"]).Date.ToString() : "-", 
                        SerialNo = reader["SerialNo"] != DBNull.Value ? reader["SerialNo"].ToString() : "0",
                        NetAmount = Convert.ToDecimal(reader["NetAmount"] != DBNull.Value ? reader["NetAmount"] : 0.000M),
                        GrossAmount = Convert.ToDecimal(reader["GrossAmount"] != DBNull.Value ? reader["GrossAmount"] : 0.000M),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        Balance = Convert.ToDecimal(reader["Balance"] != DBNull.Value ? reader["Balance"] : 0.000M),
                        Time = Convert.ToDateTime(reader["Time"] != DBNull.Value ? reader["Time"] : DateTime.MinValue),
                        UserId = Convert.ToInt32(reader["User"]),
                        PackageQty = Convert.ToInt32(reader["Package"]),
                        SaleDetailID = Convert.ToInt64(reader["SaleDetailID"]),
                        ReturnedQty = Convert.ToInt32(reader["ReturnQty"] != DBNull.Value ? reader["ReturnQty"] : 0),
                        Cost = Convert.ToDecimal(reader["Cost"] != DBNull.Value ? reader["Cost"] : 0.000M),
                        ActualPrice = Convert.ToDecimal(reader["ActualPrice"] != DBNull.Value ? reader["ActualPrice"] : 0.000M),                     

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

            return lstInvoiceDet;
        }

        #endregion

        #region GetReturnInvoiceItemDetails
        public List<FindSaleInvoiceObject> GetReturnInvoiceItemDetails(FindSaleInvoiceObject objFindSale)
        {

            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleReturnID", objFindSale.InvoiceNo);

                var reader = SQLHelper.Instance.GetReader(SPGetReturnInvoiceItemDetails, param);
                while (reader.Read())
                {

                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        ItemDecsription = Convert.ToString(reader["ItemName"]),
                        itemid = Convert.ToInt16(reader["ItemID"]),
                        ItemNumber = reader["ItemNumber"] != DBNull.Value ? reader["ItemNumber"].ToString() : string.Empty,
                        Status = Convert.ToInt16(reader["Status"]),
                        SaleID = Convert.ToInt64(reader["SaleId"]),
                        ExpiryDate = Convert.ToDateTime(reader["Expiry"] != DBNull.Value ? reader["Expiry"] : DateTime.MinValue),
                        PackageQty = Convert.ToInt16(reader["Package"]),
                        SaleDate = Convert.ToDateTime(reader["SaleReturnDate"] != DBNull.Value ? reader["SaleReturnDate"] : DateTime.MinValue),
                        Time = Convert.ToDateTime(reader["Time"] != DBNull.Value ? reader["Time"] : DateTime.MinValue),
                        Quantity = Convert.ToInt16(reader["Quantity"]),
                        ClientName = Convert.ToString(reader["Client"]),
                        clientid = Convert.ToInt16(reader["Clientid"]),
                        Price = Convert.ToDecimal(reader["UnitPrice"] != DBNull.Value ? reader["UnitPrice"] : 0.000M),
                        Total = Convert.ToDecimal(reader["Total"] != DBNull.Value ? reader["Total"] : 0.000M),
                        Cost = Convert.ToDecimal(reader["Cost"] != DBNull.Value ? reader["Cost"] : 0.000M),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        SerialNo = reader["serialno"] != DBNull.Value ? reader["serialno"].ToString() : "0",
                        UserId = Convert.ToInt16(reader["UserId"]),    

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

            return lstInvoiceDet;
        }

        #endregion

        #region GetFindSalesPrintReport
        public DataTable GetFindSalesPrintReport(DateTime? FD, DateTime? TD, int AgentID, int UserID, int InvoiceNo, int Remarks, int Status)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[7];
                Param[0] = new SqlParameter("@Remarks", Remarks);
                Param[1] = new SqlParameter("@Users", UserID);
                Param[2] = new SqlParameter("@FromDate ", FD);
                Param[3] = new SqlParameter("@ToDate", TD);
                Param[4] = new SqlParameter("@AgentID", AgentID);
                Param[5] = new SqlParameter("@InvoiceNo", InvoiceNo);
                Param[6] = new SqlParameter("@Status", Status);
                return SQLHelper.Instance.ExecuteQueryDatatable(SPGetFindSalesReport, Param, "ReportValues");
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


        public DataTable GetFindSalesDetailedReport(FindSaleInvoiceObject ObjFindSale)
        {
            try
            {
                DataTable DT = new DataTable();
                //SqlParameter[] sqlparam = new SqlParameter[7];
                //sqlparam[0] = new SqlParameter("@FromDate", objFindSale.fromdate == null ? (object)string.Empty : objFindSale.fromdate);
                //sqlparam[1] = new SqlParameter("@ToDate", objFindSale.todate == null ? (object)string.Empty : objFindSale.todate);
                //sqlparam[2] = new SqlParameter("@User", objFindSale.UserSelectedValue);
                //sqlparam[3] = new SqlParameter("@InvType", objFindSale.);
                //sqlparam[4] = new SqlParameter("@Status", objFindSale.CompanyID);
                //sqlparam[5] = new SqlParameter("@AgentID", objFindSale.AgentID);

                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@FromDate",ObjFindSale.ChkAllChecked==true?null:(object)ObjFindSale.fromdate);
                sqlparam[1] = new SqlParameter("@ToDate", ObjFindSale.ChkAllChecked == true ? null : (object)ObjFindSale.todate);
                DT = SQLHelper.Instance.ExecuteQueryDatatable("usp_Report_FindSaleDetailed ", sqlparam, "SaleReturnMovement");
                return DT;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Get POS ItemDetails
        public List<FindSaleInvoiceObject> GetPOSInvoiceItemDetails(FindSaleInvoiceObject objFindSale)
        {
            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@saleinv", objFindSale.InvoiceNo);

                var reader = SQLHelper.Instance.GetReader(SPGetPOSInvoiceItemDetails, param);
                while (reader.Read())
                {

                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        ItemDecsription = Convert.ToString(reader["item"]),
                        itemid = Convert.ToInt32(reader["itemno"]),
                        ItemNumber = reader["itemnumber"] != DBNull.Value ? reader["itemnumber"].ToString() : string.Empty,
                        ExpiryDate = Convert.ToDateTime(reader["expiry"] != DBNull.Value ? reader["expiry"] : DateTime.MinValue),
                        strExpiryDate=reader["expiry"] == DBNull.Value?string.Empty:Convert.ToDateTime(reader["expiry"]).ToShortDateString(),
                        PackageQty = reader["package"] != DBNull.Value ? Convert.ToInt32(reader["package"]) : 0,
                        Quantity = reader["qty"] != DBNull.Value ? Convert.ToInt32(reader["qty"]) : 0,
                        Price = Convert.ToDecimal(reader["price"] != DBNull.Value ? reader["price"] : 0.000M),
                        Total = Convert.ToDecimal(reader["total"] != DBNull.Value ? reader["total"] : 0.000M),
                        UserId = Convert.ToInt32(reader["users"]),
                        ReturnedQty = reader["returnqty"] != DBNull.Value ? Convert.ToInt32(reader["returnqty"]) : 0,
                        Cost = Convert.ToDecimal(reader["cost"] != DBNull.Value ? reader["cost"] : 0.000M),
                        NetAmount = Convert.ToDecimal(reader["netamount"] != DBNull.Value ? reader["netamount"] : 0.000M),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        SaleDate = Convert.ToDateTime(reader["Date"] != DBNull.Value ? reader["Date"] : DateTime.MinValue),
                        TotalCost = Convert.ToDecimal(reader["totalcost"] != DBNull.Value ? reader["totalcost"] : 0.000M),
                        SerialNo = reader["serialno"] != DBNull.Value ? reader["serialno"].ToString() : string.Empty,
                        Status = Convert.ToInt32(reader["Status"]),
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

            return lstInvoiceDet;
        }
        #endregion

        #region  Get Spoiled Details

        public List<FindSaleInvoiceObject> GetSpoiledInvoiceItemDetails(FindSaleInvoiceObject objFindSale)
        {
            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@saleinv", objFindSale.InvoiceNo);

                var reader = SQLHelper.Instance.GetReader(SPGetSpoiledInvoiceItemDetails, param);
                while (reader.Read())
                {

                    lstInvoiceDet.Add(new FindSaleInvoiceObject
                    {
                        ItemDecsription = Convert.ToString(reader["item"]),
                        Quantity = reader["qty"] != DBNull.Value ? Convert.ToInt32(reader["qty"]) : 0,
                        OrderId = Convert.ToInt32(reader["OrderID"]),
                        Price = Convert.ToDecimal(reader["price"] != DBNull.Value ? reader["price"] : 0.000M),
                        Total = Convert.ToDecimal(reader["total"] != DBNull.Value ? reader["total"] : 0.000M),
                        PackageQty = reader["package"] != DBNull.Value ? Convert.ToInt32(reader["package"]) : 0,
                        UserId = Convert.ToInt32(reader["users"]),
                        itemid =Convert.ToInt32(reader["itemno"]),
                        Discount = Convert.ToDecimal(reader["Discount"] != DBNull.Value ? reader["Discount"] : 0.000M),
                        Cost = Convert.ToDecimal(reader["cost"] != DBNull.Value ? reader["cost"] : 0.000M),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"] != DBNull.Value ? reader["OrderDate"] : DateTime.MinValue),
                        Status = Convert.ToInt32(reader["Status"]),
                        ItemNumber = reader["itemnumber"] != DBNull.Value ? reader["itemnumber"].ToString() : string.Empty,
                        ExpiryDate = Convert.ToDateTime(reader["expiry"] != DBNull.Value ? reader["expiry"] : DateTime.MinValue),
                        strExpiryDate = reader["expiry"] == DBNull.Value ? string.Empty : Convert.ToDateTime(reader["expiry"]).Date.ToString(),
                        SerialNo = reader["serialno"] != DBNull.Value ? reader["serialno"].ToString() : string.Empty
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

            return lstInvoiceDet;
        }
        #endregion
    }
}
