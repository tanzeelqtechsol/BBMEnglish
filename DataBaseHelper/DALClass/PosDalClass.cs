using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using CommonHelper;
using System.Data;
using System.Diagnostics;

namespace DataBaseHelper.DALClass
{
    public class PosDalClass
    {

        #region Constant Variables
        private const string SPSaveButton = "SP_Save_Button";
        private const string SPDeleteButton = "SP_Delete_Button";
        private const string SPGetNextID = "GetNextId";
        private const string SPSaveSaleInvoice = "SP_Save_SaleInvoice";
        private const string SPSaveSaleInvoiceDetails = "SP_Save_SaleInvoiceDetails";
        private const string SPUpdateSerialNo = "SP_Update_ItemSNo";
        private const string SP_Get_SaleDetails = "SP_Get_SaleInvoiceDetails";
        private const string SP_Delete_SaleInvoiceDetails = "SP_Delete_SaleInvoiceDetails";
        private const string SP_Update_ModifyDetails = "Sp_Modify_POS_Invoice";
        private const string SPGetAllPOSID = "usp_BBM_GetAllID_POSInvoice";
        private const string SPGetPOSReceipt = "usp_Report_PosReceipt";
        private const string SPSaveTable = "SP_Save_Table";
        private const string SPDeleteTable = "SP_Delete_Table";
        private const string SPGetSaleIDForTable = "usp_BBM_GetSaleID_Table";
        private const string SPUpdateSaleIDForTable = "usp_BBM_UpdateSaleID_Table";
        private const string SP_Get_ItemDetails = "Usp_GetItemDetailsOnInventory";
        private const string SP_NewGet_ItemDetails = "Usp_NewGetItemDetailsOnInventory";
        private const String SpNameGetBalanceSheet = "SP_Get_BalanceSheet";
        private const string SPGetAppliedDiscount = "usp_GetAppliedDiscount";

        #endregion

        #region Methods

        #region SaveButtonDetails
        public bool SaveButtonDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@ShortCut", objPos.ShortCut);
                param[1] = new SqlParameter("@ItemName", objPos.ItemName);
                param[2] = new SqlParameter("@ItemDescription", objPos.Discription);
                param[3] = new SqlParameter("@Photo", objPos.ImageByte);
                param[4] = new SqlParameter("@Addition", objPos.AdditionFlag);
                param[5] = new SqlParameter("@ImagePath", objPos.ImagePath);
                param[6] = new SqlParameter("@Status", objPos.Status);
                param[7] = new SqlParameter("@UserID", objPos.UserId);
                param[8] = new SqlParameter("@ItemID", objPos.ItemID);
                param[9] = new SqlParameter("@PricePopup", objPos.ShowPricePopup);
                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveButton, param) > 0)
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

        #region GetButtonDetails
        public List<POSObject> GetButtonDetails(POSObject objPos)
        {
            try
            {
                List<POSObject> lstButtonDetails = new List<POSObject>();
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@ShotcutFrom", objPos.ShortcutFrom);
                sqlParam[1] = new SqlParameter("@ShotcutTo", objPos.ShortcutTo);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT ShortCut,Item,ItemID,[Description],Photo,Addition,ImagePath,PricePopup  FROM  dbo.ButtonSelection Where (ShortCut BETWEEN @ShotcutFrom AND @ShotcutTo ) AND [Status]=1", sqlParam);
                while (ReaderResult.Read())
                {
                    string PricePopup = ReaderResult["PricePopup"].ToString();
                    if (!string.IsNullOrEmpty(PricePopup))
                    {
                        lstButtonDetails.Add(new POSObject
                        {
                            ShortCut = Convert.ToInt16(ReaderResult["ShortCut"]),
                            ItemName = Convert.ToString(ReaderResult["Item"]),
                            ItemID = Convert.ToInt16(ReaderResult["ItemID"] == DBNull.Value ? 0 : ReaderResult["ItemID"]),
                            Discription = Convert.ToString(ReaderResult["Description"]),
                            ImageByte = (byte[])(ReaderResult["Photo"]),
                            AdditionFlag = Convert.ToInt16(ReaderResult["Addition"]),
                            ImagePath = Convert.ToString(ReaderResult["ImagePath"]),
                            ShowPricePopup = Convert.ToBoolean(ReaderResult["PricePopup"]),

                        });
                    }
                    else
                    {
                        lstButtonDetails.Add(new POSObject
                        {
                            ShortCut = Convert.ToInt16(ReaderResult["ShortCut"]),
                            ItemName = Convert.ToString(ReaderResult["Item"]),
                            ItemID = Convert.ToInt16(ReaderResult["ItemID"] == DBNull.Value ? 0 : ReaderResult["ItemID"]),
                            Discription = Convert.ToString(ReaderResult["Description"]),
                            ImageByte = (byte[])(ReaderResult["Photo"]),
                            AdditionFlag = Convert.ToInt16(ReaderResult["Addition"]),
                            ImagePath = Convert.ToString(ReaderResult["ImagePath"]),
                            ShowPricePopup = false,


                        });
                    }

                }
                return lstButtonDetails;
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

        #region DeleteButtonDetails
        public bool DeleteButtonDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@Shortcut", objPos.ShortCut);
                sqlParam[1] = new SqlParameter("@Addition", objPos.AdditionFlag);
                if (SQLHelper.Instance.ExecuteNonQuery(SPDeleteButton, sqlParam) > 0)
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

        #region GetYearSequenceMaxID
        public List<long> GetYearSequenceMaxID()
        {
            List<long> InvoiceID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TableId", CommonHelper.Table.POSSaleID);
                param[1] = new SqlParameter("@Flag", "PosSale");
                var result = SQLHelper.Instance.GetReader(SPGetNextID, param);
                while (result.Read())
                {
                    InvoiceID.Add(Convert.ToInt64(result["PosSaleID"]));
                    //InvoiceID.Add(Convert.ToInt64(result["YearValue"]));
                    InvoiceID.Add((result["YearValue"] != DBNull.Value ? Convert.ToInt64(result["YearValue"]) : Convert.ToInt64(DateTime.Now.Year.ToString().Substring(2, 2))));
                    //InvoiceID.Add(Convert.ToInt64(result["YearMaxId"]));
                    InvoiceID.Add((result["YearMaxId"] != DBNull.Value ? Convert.ToInt64(result["YearMaxId"]) : 1));    // DB null exeception fixed on 21-Jun-2014 by Praba
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

        #region GetOrderNo
        public object GetOrderNo()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
               // var result = SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(MAX(OrderNo),0)+1 FROM Sales WHERE CAST(CONVERT(VARCHAR,SaleDate,101)AS DATETIME)=CAST(CONVERT(VARCHAR,GETDATE(),101)AS DATETIME)AND SaleType=2", param);
                var result = SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(MAX(OrderNo),0)+1 FROM Sales WHERE CAST(CONVERT(VARCHAR,SaleDate,101)AS DATETIME)=CAST(CONVERT(VARCHAR,GETDATE(),101)AS DATETIME)AND SaleType=2 AND SaleID=(Select MAX(SaleID)FROM Sales Where SaleType=2)", param);
                return result;
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

        #region SaveSaleInvoice
        public bool SaveSaleInvoice(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[21];
                param[0] = new SqlParameter("@AgentID", objPos.AgentId);
                param[1] = new SqlParameter("@AccountID", objPos.AccountId);
                param[2] = new SqlParameter("@SaleInvoice", objPos.SaleId);
                param[3] = new SqlParameter("@Balance", objPos.Balance);
                param[4] = new SqlParameter("@Tax", objPos.Tax1);
                param[5] = new SqlParameter("@Tax1", objPos.Tax2);
                param[6] = new SqlParameter("@SubTax", objPos.SubTax1);
                param[7] = new SqlParameter("@SubTax1", objPos.SubTax2);
                param[8] = new SqlParameter("@Gross", objPos.GrossAmount);
                param[9] = new SqlParameter("@Discount", objPos.Discount);
                param[10] = new SqlParameter("@NetAmount", objPos.NetAmount);
                param[11] = new SqlParameter("@PaymentCharges", objPos.PaymentCharges);
                param[12] = new SqlParameter("@CreatedBy", objPos.CreatdBy);
                param[13] = new SqlParameter("@ModifiedBy", objPos.ModifiedBy);
                param[14] = new SqlParameter("@Status", objPos.Status);
                param[15] = new SqlParameter("@SaleType", objPos.SaleType);
                param[16] = new SqlParameter("@OrderNo", objPos.OrderNo);
                param[17] = new SqlParameter("@SaleDate", objPos.SaleDate);
                param[18] = new SqlParameter("@PaidAmount", objPos.PaidAmount);
                param[19] = new SqlParameter("@PaymentTypeId", objPos.PaymentTypeId);
                param[20] = new SqlParameter("@TableNo", objPos.ShortCut);
                //sdf
                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleInvoice, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch(Exception ex)
            {
            }
            finally
            {
                Close();
            }

            return result;
        }
        #endregion

        #region SaveSaleInvoiceDetails
        public bool SaveSaleInvoiceDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                //GeneralFunction.Errorlogfile("=================POS Invoice Screen =====================", 1, "", "", true);
                //string TraceObj = "SaleID = " + objPos.SaleId + Environment.NewLine;
                //TraceObj += " BatchID = " + objPos.BatchId + Environment.NewLine;
                //TraceObj += " ItemID = " + objPos.ItemID + Environment.NewLine;
                //TraceObj += " Quantity = " + objPos.Qty + Environment.NewLine;
                //TraceObj += " Price = " + objPos.Price  + Environment.NewLine;
                //TraceObj += " Discount = " + objPos.Discount  + Environment.NewLine;
                //TraceObj += " ReturnQty = " + objPos.ReturnQty  + Environment.NewLine;
                //TraceObj += " ExpiryDate = " + objPos.ExpiryDate  + Environment.NewLine;
                //TraceObj += " SaleType = " + objPos.SaleType  + Environment.NewLine;
                //TraceObj += " Status = " + objPos.Status  + Environment.NewLine;
                //TraceObj += " ItemType = " + objPos.ItemType  + Environment.NewLine;
                //TraceObj += " ItemSerialNo = " + objPos.ItemSno  + Environment.NewLine;
                //TraceObj += " ItemCost = " + objPos.Cost  + Environment.NewLine;
                //TraceObj += " PackageQty = " + objPos.PackageQty  + Environment.NewLine;
                //TraceObj += " BarcodeID = " + objPos.BarcodeID  + Environment.NewLine;
                //TraceObj += " Box = " + objPos.Box  + Environment.NewLine;
                //TraceObj += " ActualPrice = " + objPos.ItemPackagePrice  + Environment.NewLine;
                //TraceObj += " ButtonID = " + objPos.ButtonId  + Environment.NewLine;
                //TraceObj += " ButtonitemID = " + objPos.ButtonItemId  + Environment.NewLine;
                //TraceObj += " ItemInsertionNo = " + objPos.ItemInsertionNo;
                //GeneralFunction.Errorlogfile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + Environment.NewLine + TraceObj, 1, "", "", true);

                SqlParameter[] param = new SqlParameter[23];
                param[0] = new SqlParameter("@SaleID", objPos.SaleId);
                

                param[1] = new SqlParameter("@BatchID", objPos.BatchId);
                param[2] = new SqlParameter("@ItemID", objPos.ItemID);
                param[3] = new SqlParameter("@Quantity", objPos.Qty);
                param[4] = new SqlParameter("@Price", objPos.Price);
                param[5] = new SqlParameter("@Discount", objPos.Discount);
                param[6] = new SqlParameter("@ReturnQuantity", objPos.ReturnQty);
                param[7] = new SqlParameter("@ExpiryDate", objPos.ExpiryDate);
                param[8] = new SqlParameter("@CreatedBy", objPos.CreatdBy);
                param[9] = new SqlParameter("@ModifiedBy", objPos.ModifiedBy);
                param[10] = new SqlParameter("@Status", objPos.Status);
                param[11] = new SqlParameter("@SaleType", objPos.SaleType);
                param[12] = new SqlParameter("@ItemType", objPos.ItemType);
                param[13] = new SqlParameter("@ItemSerialNo", objPos.ItemSno);
                param[14] = new SqlParameter("@ItemCost", objPos.Cost);
                param[15] = new SqlParameter("@Tax", (objPos.ItemType == Convert.ToInt16(PosItemType.AdditionalItem)) ? 0.000M : objPos.ItemTax);
                param[16] = new SqlParameter("@PackageQty", objPos.PackageQty);
                param[17] = new SqlParameter("@BarcodeID", objPos.BarcodeID);
                param[18] = new SqlParameter("@Box", objPos.Box);
                param[19] = new SqlParameter("@ActualPrice", objPos.ItemPackagePrice);
                param[20] = new SqlParameter("@ButtonId", objPos.ButtonId);
                param[21] = new SqlParameter("@ButtonItemID", objPos.ButtonItemId);
                param[22] = new SqlParameter("@ItemInsertionNo", objPos.ItemInsertionNo);
                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleInvoiceDetails, param) > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                

            }
            catch(Exception ex)
            {
            }
            finally
            {
                Close();
            }

            return result;
        }
        #endregion

        #region GetStockOnItem
        public object GetStockOnItem(POSObject objPos)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objPos.ItemID);
                var result = SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(StockInHand,0) AS StockInHand FROM  dbo.Stock WHERE ItemID=@ItemID ORDER BY StockInHand Desc", param);
                return result;
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

        #region UpdateSerialNo
        public bool UpdateSerialNo(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@SaleID", objPos.SaleId);
                param[1] = new SqlParameter("@ItemID", objPos.ItemID);
                param[2] = new SqlParameter("@ItemSNo", objPos.ItemSno);

                if (SQLHelper.Instance.ExecuteNonQuery(SPUpdateSerialNo, param) > 0)
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

        #region GetMaxSaleID
        public object GetMaxSaleID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetScalarQuery("SELECT (ISNULL(MAX(CONVERT(INT,SaleID)),0))AS SaleID FROM Sales WHERE SaleType=2", param);
                return result;
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

        #region GetSalesDetails
        public Dictionary<string, List<POSObject>> GetSalesDetails(POSObject objPos)
        {
            Dictionary<string, List<POSObject>> dicSaleDetails = new Dictionary<string, List<POSObject>>();
            List<POSObject> lstSale = new List<POSObject>();
            List<POSObject> lstSaleDetails = new List<POSObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleID", objPos.SaleId);

                var result = SQLHelper.Instance.GetReader(SP_Get_SaleDetails, param);

                while (result.Read())
                {
                    lstSale.Add(new POSObject
                    {
                        AgentId = Convert.ToInt16(result["AgentID"]),
                        SaleId = Convert.ToInt64(result["SaleID"]),
                        OrderNo = Convert.ToInt16(result["OrderNo"]),
                        SaleDate = Convert.ToDateTime(result["SaleDate"] != DBNull.Value ? result["SaleDate"] : DateTime.Now.ToString()),
                        Year = Convert.ToInt16(result["Year"] != DBNull.Value ? result["Year"] : 0),
                        YearSequenceNo = Convert.ToInt64(result["YearSequenceNo"] != DBNull.Value ? result["YearSequenceNo"] : 0),
                        Tax = Convert.ToDecimal(result["Tax"] != DBNull.Value ? result["Tax"] : 0),
                        Tax1 = Convert.ToDecimal(result["Tax1"] != DBNull.Value ? result["Tax1"] : 0),
                        SubTax1 = Convert.ToDecimal(result["TaxSub"] != DBNull.Value ? result["TaxSub"] : 0),
                        SubTax2 = Convert.ToDecimal(result["Tax1Sub"] != DBNull.Value ? result["Tax1Sub"] : 0),
                        PaidAmount = Convert.ToDecimal(result["PaidAmount"] != DBNull.Value ? result["PaidAmount"] : 0),
                        PaymentCharges = Convert.ToDecimal(result["PaymentCharges"] != DBNull.Value ? result["PaymentCharges"] : 0),
                        ShortCut = Convert.ToInt16(result["TableNO"]),
                        Status = Convert.ToInt16(result["Status"]),
                    });
                }
                result.NextResult();
                while (result.Read())
                {

                    lstSaleDetails.Add(new POSObject
                    {
                        ItemID = Convert.ToInt16(result["ItemID"] != DBNull.Value ? result["ItemID"] : 0),
                        ItemName = Convert.ToString(result["ItemName"] != DBNull.Value ? result["ItemName"] : ""),
                        AdditionItemName = Convert.ToString(result["AddedItemTextName"] != DBNull.Value ? result["AddedItemTextName"] : ""),
                        ItemType = Convert.ToInt16(result["ItemType"]),
                        Qty = Convert.ToInt16(result["Quantity"] != DBNull.Value ? result["Quantity"] : 0),
                        Price = Convert.ToDecimal(result["Price"] != DBNull.Value ? result["Price"] : 0),
                        Status = Convert.ToInt16(result["Status"]),
                        ItemSno = Convert.ToInt16(result["ItemSerialNo"]),
                        CategoryName = Convert.ToString(result["Category"] != DBNull.Value ? result["Category"] : ""),
                        PackageQty = Convert.ToInt16(result["PackageQty"] != DBNull.Value ? result["PackageQty"] : 1),
                        Box=Convert.ToInt32(result["Box"]),
                        ItemPackagePrice = Convert.ToDecimal(result["ActualPrice"]),
                        ButtonId = Convert.ToInt32(result["ButtonID"]),
                        ButtonItemId = Convert.ToInt32(result["ButtonItemID"]),
                        ItemInsertionNo = Convert.ToInt32(result["ItemInsertionNo"])
                    });

                }
                result.Close();
                dicSaleDetails.Add("Sales", lstSale);
                dicSaleDetails.Add("SalesDetails", lstSaleDetails);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return dicSaleDetails;
        }
        #endregion

        #region DeleteSaleInvoiceDetails
        public bool DeleteSaleInvoiceDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[12];
                sqlParam[0] = new SqlParameter("@ItemID", objPos.ItemID);
                sqlParam[1] = new SqlParameter("@SaleID", objPos.SaleId);
                sqlParam[2] = new SqlParameter("@SaleType", objPos.SaleType);
                sqlParam[3] = new SqlParameter("@ItemType", objPos.ItemType);
                sqlParam[4] = new SqlParameter("@NetAmount", objPos.NetAmount);
                sqlParam[5] = new SqlParameter("@ItemSNo", objPos.RowID);
                sqlParam[6] = new SqlParameter("@Tax", objPos.Tax);
                sqlParam[7] = new SqlParameter("@Tax1", objPos.Tax1);
                sqlParam[8] = new SqlParameter("@SubTax", objPos.SubTax1);
                sqlParam[9] = new SqlParameter("@SubTax1", objPos.SubTax2);
                sqlParam[10] = new SqlParameter("@ButtonID", objPos.ButtonId);
                sqlParam[11] = new SqlParameter("@GroupID", GeneralFunction.UserGroupID);

                if (SQLHelper.Instance.ExecuteNonQuery(SP_Delete_SaleInvoiceDetails, sqlParam) > 0)
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

        #region ModifySaleDetails
        public bool ModifySaleDetails(POSObject objPos)
        {
            bool result = false;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInv", objPos.SaleId);

                if (SQLHelper.Instance.ExecuteNonQuery(SP_Update_ModifyDetails, param) > 0)
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

        #region GetPOSID()
        public List<long> GetPOSID()
        {
            try
            {
                List<long> lstPOSID = new List<long>();
                SqlParameter[] sqlParam = new SqlParameter[0];

                var ReaderResult = SQLHelper.Instance.GetReader(SPGetAllPOSID, sqlParam);
                while (ReaderResult.Read())
                {
                    lstPOSID.Add(Convert.ToInt64(ReaderResult["ID"]));

                }

                return lstPOSID;
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

        #region GetPOSPrintReport
        public DataTable GetPOSPrintReport(POSObject objPos)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@InvoiceNo", objPos.SaleId);
                return SQLHelper.Instance.ExecuteQueryDatatable(SPGetPOSReceipt, Param, "ReportValues");
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

        #region Table Settings Methods

        #region SaveTableDetails
        public bool SaveTableDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ShortCut", objPos.ShortCutText);
                param[1] = new SqlParameter("@ItemDescription", objPos.Discription);
                param[2] = new SqlParameter("@SaleInvoiceNo", objPos.SaleId);
                param[3] = new SqlParameter("@Status", objPos.Status);
                param[4] = new SqlParameter("@UserID", objPos.UserId);

                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveTable, param) > 0)
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

        #region GetTableDetails
        public List<POSObject> GetTableDetails()
        {
            try
            {
                List<POSObject> lstTableDetails = new List<POSObject>();
                SqlParameter[] sqlParam = new SqlParameter[0];
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT ShortCut,[Description],SaleInvoiceID  FROM  dbo.TableSelection Where  [Status]=1", sqlParam);
                while (ReaderResult.Read())
                {
                    lstTableDetails.Add(new POSObject
                    {
                        ShortCut = Convert.ToInt16(ReaderResult["ShortCut"]),
                        Discription = Convert.ToString(ReaderResult["Description"]),
                        SaleId = Convert.ToInt64(ReaderResult["SaleInvoiceID"])
                    });

                }
                return lstTableDetails;
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

        #region DeleteTableDetails
        public bool DeleteTableDetails(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Shortcut", objPos.ShortCut);

                if (SQLHelper.Instance.ExecuteNonQuery(SPDeleteTable, sqlParam) > 0)
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

        #endregion

        #region Tables in POS

        #region GetSaleIDForTable
        public long GetSaleIDForTable(POSObject objPos)
        {
            try
            {
                long SaleID = 0;
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Shortcut", objPos.ShortCut);
                var ReaderResult = SQLHelper.Instance.GetReader(SPGetSaleIDForTable, sqlParam);
                if (ReaderResult.Read())
                {

                    SaleID = Convert.ToInt64(ReaderResult["SaleInvoiceID"]);
                }

                return SaleID;
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

        #region UpdateSaleIDForTable
        public bool UpdateSaleIDForTable(POSObject objPos)
        {
            bool result = false;

            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@SaleInvoiceID", objPos.SaleId);
                sqlParam[1] = new SqlParameter("@Shortcut", objPos.ShortCut);

                if (SQLHelper.Instance.ExecuteNonQuery(SPUpdateSaleIDForTable, sqlParam) > 0)
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

        #endregion

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

        #endregion

        #region GetStockDetails
        public List<POSObject> GetStockDetails(POSObject objPos)
        {
            try
            {
                List<POSObject> lstStockDetails = new List<POSObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@ItemID", objPos.ItemID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery(" SELECT Distinct  Expiry FROM dbo.Stock  WHERE ItemID = @ItemID AND [Status]=1", sqlParam);
                while (ReaderResult.Read())
                {
                    lstStockDetails.Add(new POSObject
                    {
                        //  ItemID = Convert.ToInt16(ReaderResult["ItemID"] == DBNull.Value ? 0 : ReaderResult["ItemID"]),
                        ExpiryDate = Convert.ToDateTime(ReaderResult["Expiry"] == DBNull.Value ? DateTime.MinValue : ReaderResult["Expiry"])
                    });

                }
                return lstStockDetails;
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

        #endregion

        #region GetItemDetails With package quantity
        public List<ItemCardObjectClass> GetItemDetails()
        {
            List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();

            SqlParameter[] param = new SqlParameter[0];
            //var result = SQLHelper.Instance.GetReader(SP_Get_ItemDetails, param);
            DataTable Dt = SQLHelper.Instance.ExecuteQueryDatatable(SP_Get_ItemDetails, param, "");
            try
            {
                //while (result.Read())

                foreach (DataRow result in Dt.Rows)
                {
                    lstItemDetails.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        Items = result["ItemName"].ToString(),
                        Barcode = result["Barcode"].ToString(),
                        //CategoryId = Convert.ToInt32(result["CategoryID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        //  ItemPlaceId = Convert.ToInt32(result["ItemPlaceID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemDescription = result["ItemDescription"].ToString(),
                        // Unit = Convert.ToInt32(result["Unit"] == DBNull.Value ? 0 : result["Unit"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        // CompId = Convert.ToInt32(result["CompanyID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"] == DBNull.Value ? 0.000m : result["ItemLastCost"]),
                        PackageQuantity = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 1 : result["PackageQty"]),
                        ExpiryDate = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"])),
                        //Reorder = Convert.ToInt32(result["Reorder"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        WholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                        Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        Maxorder = Convert.ToInt32(result["MaxOrder"]),
                        MinPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        AverageCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? null : result["AverageCost"]),
                        IsHide = Convert.ToBoolean(result["IsHide"] == DBNull.Value ? false : result["IsHide"]),
                        ItemNumber = result["ItemNumber"].ToString()
                       
                    });
                }


                var ObjListItemOne = (from p in lstItemDetails
                                      where p.ItemType == 1 //"Goods"
                                      orderby p.Items
                                      select p).Distinct().ToList();

                var ObjListItemTwo = (from p in lstItemDetails
                                      where p.ItemType == 4 //"Meal"
                                      orderby p.Items
                                      select p).Distinct().ToList();

                var ObjListItemThree = ObjListItemOne.Union(ObjListItemTwo);
                ObjListItemThree = ObjListItemThree.GroupBy(x => x.ItemId).Select(y => y.First());
                return ObjListItemThree.Distinct().ToList();

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


        public DataTable   NewGetItemDetails()
        {
            //List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();
            DataTable dtItemDtls;
            SqlParameter[] param = new SqlParameter[0];
            //var result = SQLHelper.Instance.GetReader(SP_Get_ItemDetails, param);
            
            try
            {

                 dtItemDtls = SQLHelper.Instance.ExecuteQueryDatatable(SP_NewGet_ItemDetails, param, "");
                //var ObjListItemOne = (from p in lstItemDetails
                //                      where p.ItemType == 1 //"Goods"
                //                      orderby p.Items
                //                      select p).Distinct().ToList();

                //var ObjListItemTwo = (from p in lstItemDetails
                //                      where p.ItemType == 4 //"Meal"
                //                      orderby p.Items
                //                      select p).Distinct().ToList();

                //var ObjListItemThree = ObjListItemOne.Union(ObjListItemTwo);
                //ObjListItemThree = ObjListItemThree.GroupBy(x => x.ItemId).Select(y => y.First());
                 return dtItemDtls;

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

        public List<POSObject> GetPackageQtyForItem(POSObject posobject, decimal i_Price = 0)
        {
            List<POSObject> lstSaleObject = new List<POSObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", posobject.ItemID);
                var result = SQLHelper.Instance.GetReader("usp_GetPackageQty_Item", param);
                int pack = -1;
                while (result.Read())
                {


                    if (pack != Convert.ToInt32(result["PackageQty"]))
                    {
                        if (i_Price != 0)
                        {
                            lstSaleObject.Add(new POSObject
                            {
                                BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                                PackageQty = Convert.ToInt32(result["PackageQty"]),
                                Price = i_Price//Convert.ToDecimal(result["Price"])
                            });
                        }
                        else
                        {
                            lstSaleObject.Add(new POSObject
                            {
                                BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                                PackageQty = Convert.ToInt32(result["PackageQty"]),
                                Price = Convert.ToDecimal(result["Price"])
                            });
                        }
                    }
                    pack = Convert.ToInt32(result["PackageQty"]);
                    
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

        #region getItemDetails
        public List<ItemCardObjectClass> GetAllItems(int itemId)
        {

            List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();

            if (itemId == 0)
            {
                itemId = -1;
            }
            SqlParameter[] param = new SqlParameter[1];
            SqlParameter objSqlPara = new SqlParameter("@ItemId", itemId);
            param[0] = objSqlPara;
            DataTable Dt = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_POSItemName", param, "");
            try
            {
                foreach (DataRow result in Dt.Rows)
                {
                    lstItemDetails.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        Items = result["ItemName"].ToString(),
                        Barcode = result["Barcode"].ToString(),
                        CategoryId = Convert.ToInt32(result["CategoryID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        //  ItemPlaceId = Convert.ToInt32(result["ItemPlaceID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemDescription = result["ItemDescription"].ToString(),
                        // Unit = Convert.ToInt32(result["Unit"] == DBNull.Value ? 0 : result["Unit"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        CompId = Convert.ToInt32(result["CompanyID"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        ItemCost = Convert.ToDecimal(result["ItemCost"] == DBNull.Value ? 0.000m : result["ItemCost"]),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"] == DBNull.Value ? 0.000m : result["ItemLastCost"]),
                        PackageQuantity = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 1 : result["PackageQty"]),
                        ExpiryDate = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"])),
                        //Reorder = Convert.ToInt32(result["Reorder"]),//Commented on 23-June-2014 for Avoiding Performance issue
                        WholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                        Price = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        Maxorder = Convert.ToInt32(result["MaxOrder"]),
                        MinPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        AverageCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? null : result["AverageCost"]),
                        IsHide = Convert.ToBoolean(result["IsHide"] == DBNull.Value ? false : result["IsHide"]),
                        ItemNumber = result["ItemNumber"].ToString()
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
            return lstItemDetails;
        }
        #endregion

        public bool ShowPricePopup(int ItemID, int BtnID)
        {
            bool Value = false;
            var Result = (dynamic)null;
            if (BtnID != null && BtnID != 0)
            {
                SqlParameter[] Params = new SqlParameter[1];
                Params[0] = new SqlParameter("@BtnID", BtnID);
                Result = SQLHelper.Instance.GetScalarQuery("select IsNull(PricePopup,0) from ButtonSelection where ButtonSelectionID = @BtnID", Params);
            }
            else
            {
                SqlParameter[] Params = new SqlParameter[1];
                Params[0] = new SqlParameter("@ItemID", ItemID);
                Result = SQLHelper.Instance.GetScalarQuery("select Top 1 IsNull(PricePopup,0) from ButtonSelection where ItemID = @ItemID", Params);
            }
            if(Result != null)
            {
                Value = Convert.ToBoolean(Result);
            }
            return Value;
        }

        #region getPOSItems
        public DataTable  GetPOSItems()
        {

            //List<ItemCardObjectClass> lstItemDetails = new List<ItemCardObjectClass>();
            DataTable DtItems;
            SqlParameter[] param = new SqlParameter[0];
           
            try
            {

                 DtItems = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_NewPOSItems", param, "");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return DtItems;
        }
        #endregion

        #region GetButtonItemId
        public int GetButtonItemId(string buttontxt)
        {

            try
            {
                //List<POSObject> lstButtonDetails = new List<POSObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Item", buttontxt);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("SELECT buttonselectionid  FROM  dbo.ButtonSelection Where item= @Item AND [Status]=1", sqlParam);
                int ButtonItemId = 0;
                while (ReaderResult.Read())
                {
                    //lstButtonDetails.Add(new POSObject
                    //{
                    ButtonItemId = Convert.ToInt16(ReaderResult["buttonselectionid"] == DBNull.Value ? 0 : ReaderResult["buttonselectionid"]);
                      

                    //});

                }
                return ButtonItemId;
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

        #endregion

        #region GetBalanceSheetDetails
        public List<POSObject> GetBalanceSheetDetails(POSObject objSaleObject)
        {

            List<POSObject> lstBalance = new List<POSObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@AgentID", objSaleObject.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objSaleObject.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objSaleObject.BalanceToDate;
                param[3] = new SqlParameter("@Status", objSaleObject.BalanceStatus);

                DataTable dt =  SQLHelper.Instance.ExecuteQueryDatatabledata("SP_Get_POSGrossAmount", param);//SQLHelper.Instance.ExecuteQueryDatatabledata(SpNameGetBalanceSheet, param);

                if (dt.Rows.Count > 0)
                {
                    lstBalance.Add(new POSObject
                    {

                        AmountRecieved = Convert.ToDecimal(dt.Compute("Sum(NetAmount)", string.Empty)),
                        NetAmount = Convert.ToDecimal(dt.Compute("Sum(AmtReceived)", string.Empty))

                    });
                }
                //var reader = SQLHelper.Instance.GetReader(SpNameGetBalanceSheet, param);
                //while (reader.Read())
                //{

                //    lstBalance.Add(new POSObject
                //    {

                //        AmountRecieved = Convert.ToDecimal(reader[4]),
                //        NetAmount = Convert.ToDecimal(reader[5])

                //    });

                //}
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


        public List<SaleObject> GetItemMinimumPrice(POSObject ObjPOSObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", ObjPOSObject.ItemID);
                param[1] = new SqlParameter("@BarcodeID", ObjPOSObject.BarcodeID);

                var result = SQLHelper.Instance.GetReader("Sp_Get_Minimumprice_A", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        ItemPrice = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                        ItemPackage = Convert.ToInt32(result["package"]),
                        ItemTotalStock = Convert.ToInt32(result["StockOnHand"]),
                        AvgCost = Convert.ToDecimal(result["cost"] == DBNull.Value ? 0 : result["cost"]),

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

        public int ResetOrderNo(long SaleID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SaleID",SaleID);
            return SQLHelper.Instance.ExecuteNonQuery("Sp_ReserOrderNo", param);
        }

        public float GetDiscountForAgent(POSObject ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@AgentID", ObjSale.ClientID);

                float Disount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("SELECT Discount FROM dbo.Agent WHERE AgentID=@AgentID", Param));
                return Disount;
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
        public float GetIsDiscountOrIncreaseForAgent(POSObject ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@AgentID", ObjSale.ClientID);

                float Disount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(IncreasePrice,0) FROM dbo.Agent WHERE AgentID=@AgentID", Param));
                return Disount;
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
        #region UpdateActiveUser
        public bool UpdateActiveUser(POSObject ObjSale)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ActiveUser", GeneralFunction.UserId);
                param[1] = new SqlParameter("@InvoiceNo", ObjSale.SaleId);
                if (SQLHelper.Instance.ExecuteNonQuery("activeuserPOSupdation", param) > 0)
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
        #region GetActiveUser
        public List<POSObject> GetActiveUser(POSObject objSaleObject)
        {
            List<POSObject> lstSaleObject = new List<POSObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.SaleId);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT ActiveUser FROM dbo.Sales WHERE SaleID=@InvoiceNo and SaleType=2", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new POSObject
                    {
                        Activuser = Convert.ToInt32(result["ActiveUser"] == DBNull.Value ? 0 : result["ActiveUser"])


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
        #region GetAppliedIncrease
        public DataTable GetAppliedIncrease(int CategoryID, int CompanyID, int ItemType, int ItemNo)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", ItemType);
            param[1] = new SqlParameter("@CategoryID", CategoryID);
            param[2] = new SqlParameter("@CompanyID", CompanyID);
            param[3] = new SqlParameter("@ItemID", ItemNo);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }

        #endregion
        public List<POSObject> GetCateComIDForItem(POSObject objPosObject)
        {
            List<POSObject> lstSaleObject = new List<POSObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objPosObject.ItemID);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT CategoryID,CompanyID FROM item WHERE ItemID=@ItemID", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new POSObject
                    {
                        CategoryId = Convert.ToInt32(result["CategoryID"]),
                        CompId = Convert.ToInt32(result["CompanyID"])
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

        public float GetAppliedDiscount(POSObject objPosObject)
        {
            float Discount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemType", objPosObject.ItemType);
                param[1] = new SqlParameter("@CategoryID", objPosObject.CategoryId);
                param[2] = new SqlParameter("@CompanyID", objPosObject.CompId);

                var ReaderResult = SQLHelper.Instance.GetReader(SPGetAppliedDiscount, param);
                if (ReaderResult.Read())
                {
                    Discount = Convert.ToInt32(ReaderResult["Discount"]);
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

            return Discount;
        }

        public DataTable GetAppliedIncrease(POSObject objPosObject)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", objPosObject.ItemType);
            param[1] = new SqlParameter("@CategoryID", objPosObject.CategoryId);
            param[2] = new SqlParameter("@CompanyID", objPosObject.CompId);
            param[3] = new SqlParameter("@ItemID", objPosObject.ItemID);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }

        public DataSet GetItemPrintInfoDal(POSObject objPosObject)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@InvoiceNo", objPosObject.SaleId);
            return SQLHelper.Instance.ExecuteQueryDataset("sp_Get_SaleItemPrintInfo", param, "PrintInfo");
        }
        
    }
}
