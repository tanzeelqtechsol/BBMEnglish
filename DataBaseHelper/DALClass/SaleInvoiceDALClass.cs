using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ObjectHelper;
using System.Data.SqlClient;
using CommonHelper;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace DataBaseHelper.DALClass
{
    public class SaleInvoiceDALClass
    {

        #region Constants Varibles

        //Sales invoice
        private const string SPLoadSalesDetails = "Sp_Sale_Load";
        private const String SpNameGetBalanceSheet = "SP_Get_BalanceSheet";
        private const String SpGetBalanceSheet = "SP_Get_BalanceSheet3";//added new sp for calculating balance amount by Prabhakaran.S
        private const string SPCategoryItemStock = "SP_CategoryItem_A";
        private const string SPCategoryItemNnonStock = "SP_CategoryItem_nonstockA";
        private const string SPGetItemInfo = "SP_Get_ItemNameInfo_A";
        private const string SPGetPaymentDate = "Sp_Get_PaymentDate_A";
        private const string SPGetSerialNo = "Sp_Get_Serialno_A";

        private const string SPGetMinimumPrice = "Sp_Get_Minimumprice_A";
        private const string SPGetStockBasedExpiry = "Sp_GetStock_basedexpiry_A";
        private const string SPGetStockBasedSerialNo = "Sp_GetStock_basedserialno_A";

        private const string SPGetStock = "Sp_Get_Stock_A";
        private const string SPGetExpiryCount = "Sp_Get_ExpiryCount_A";
        private const string SPGetDebtLimit = "Sp_Get_Debtlimit_A";
        private const string SPGetNextID = "GetNextId";
        private const string SPSaveSaleM = "Sp_Sale_m";
        private const string SPUpdateActiveUser = "activeuserupdation";
        private const string SPGetInvoiceDetails = "Sp_Invno_Details_A";
        private const string SPGetInvoiceDetailsExtended = "Sp_Invno_Details_A_Extended";
        private const string SPGetItemAverageCost = "SP_Get_ItemNameInfo";
        private const string SPSaveSaleDetail = "Sp_Sale_Det_insertion_m";
        private const string SPGetSaleDetID = "Sp_Get_Det_id_A_m";
        private const string SPGetYearSequence = "SP_Get_NewInvoiceNo";
        private const string SPGetStockBaseExpiryInvNo = "Sp_GetStock_basedexpiry_invnoA";
        private const string SPDeleteSaleItem = "Sp_Delete_SaleItem_A_m";
        private const string SPGetClientNo = "SP_Get_Clientno_A";
        private const string SPGetMinMaxSaleID = "usp_BBM_GetMinMax_SalesInvoice";
        private const string SPSaveSaleDetailOnClosing = "Sp_Sale_Det_m";
        private const string SPCheckEmptyInvoice = "Sp_ExistEmptyInv_A";
        private const string SPModifyInvoice = "Sp_modify_inv_A";
        private const string SPCheckBalance = "Sp_check_balance_A";
        private const string SPGetItemInfoExport = "Sp_Get_ItemInfoExport";
        private const string SPGetSalesInvoiceID = "usp_Get_SalesInvoiceID";
        private const string SPGetReportSaleInvoice = "usp_Report_SaleInvoice";
        private const string SPGetReportSaleInvoicePaidRemain = "Get_PaidAndRemainingAmountByinvoiceID";

        //Following are for Performa Invoice
        private const string SPGetItemInforForPerform = "SP_Get_ItemNameInfo";
        private const string SPGetExpiryDate = "SP_Get_ExpiryDate";
        private const string SPSavePerformaInvoice = "SP_Save_PerformaInvoice";
        private const string SPGetOrderInvoiceDetails = "SP_Get_OrderInvoiceDetails";
        private const string SPModifyPerformInvoice = "SP_ModifyInvoice";
        private const string SPGetPerformaValue = "Sp_Get_PerfomaValue_A";
        private const string SPSaveMoveToSale = "SP_SAVE_MOVETOSALE";
        private const string SPUpdatePerformInvoice = "Sp_Update_PerformaInvoice";
        private const string SPGetSaleIDWithoutPOS = "usp_BBM_GetAllID_SaleInvoice";
        private const string SPGetSaleIDCountWithoutPOS = "usp_BBM_GetIDCount_SaleInvoice";
        //SPGetSaleIDWithoutPOS
        private const string SPGetPackageQTyforItem = "usp_GetPackageQty_Item";
        private const string SPGetExpiryDates = "usp_GetExpiryDates_Sales";
        private const string SPCheckDateIsExpired = "usp_CheckDateIsExpiry";
        private const string SPGetAppliedDiscount = "usp_GetAppliedDiscount";
        private const string SPGetExpiryDateBaedOnPackage = "usp_GetExpiryDateBaseOnPackage";
        private const string SPGetSerialNoBaedOnPackage = "usp_GetSerialNoBaseOnPackage";
        private const string SPSaveCustomerReceipt = "Sp_Save_Customer_Receipt";
        #endregion

        #region getSaleTable
        public List<object> getSaleTable()
        {
            List<object> lstSaleTable = new List<object>();
            try
            {

                using (SqlCommand cmd = new SqlCommand("Sp_Sale_Load", SQLHelper.Instance.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SQLHelper.Instance.conn.Open();
                    var result = cmd.ExecuteReader();
                    for (int i = 0; i < 7; i++)
                    {
                        result.Read();
                        result.NextResult();
                    }
                    result.NextResult();
                    while (result.Read())
                    {
                        lstSaleTable.Add(result[0]);
                        lstSaleTable.Add(result[1]);
                        lstSaleTable.Add(result[2]);
                        lstSaleTable.Add(result[3]);
                        lstSaleTable.Add(result[4]);
                        lstSaleTable.Add(result[5]);
                        lstSaleTable.Add(result[6]);
                        lstSaleTable.Add(result[7]);
                        lstSaleTable.Add(result[8]);
                        lstSaleTable.Add(result[9]);
                        lstSaleTable.Add(result[10]);
                        lstSaleTable.Add(result[11]);
                        lstSaleTable.Add(result[12]);
                        lstSaleTable.Add(result[13]);
                        lstSaleTable.Add(result[14]);
                        lstSaleTable.Add(result[15]);
                        lstSaleTable.Add(result[16]);
                        lstSaleTable.Add(result[17]);
                    }
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
            return lstSaleTable;

        }
        #endregion

        #region getLoadDetails
        public Dictionary<string, List<SaleObject>> getLoadDetails(SaleObject objSaleObject)
        {
            Dictionary<string, List<SaleObject>> dicLoad = new Dictionary<string, List<SaleObject>>();
            List<SaleObject> lstSaleId = new List<SaleObject>();
            //List<SaleObject> lstItemIDName = new List<SaleObject>();
            try
            {

                int stock = 0;
                if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                    stock = 1;

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CreatedBy", GeneralFunction.UserId);
                param[1] = new SqlParameter("@UserGroupID", GeneralFunction.UserGroupID);
                param[2] = new SqlParameter("@stock", stock);
                var result = SQLHelper.Instance.GetReader("Sp_Sale_LoadWithStock", param);
                while (result.Read())
                {
                    lstSaleId.Add(new SaleObject { SalesId = Convert.ToInt32(result[0]) });
                }
                //result.NextResult();
                //while (result.Read())
                //{

                //    lstItemIDName.Add(new SaleObject
                //    {
                //        ItemsId = Convert.ToInt32(result[0]),
                //        ItemName = result[1].ToString(),
                //        ItemNumber = result[2].ToString(),
                //        stock = Convert.ToDouble(result[3]==DBNull.Value?0:result[3])
                //    });

                //}
                result.Close();
                dicLoad.Add("SaleId", lstSaleId);

                //dicLoad.Add("ItemIDName", lstItemIDName);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return dicLoad;
        }
        #endregion
        #region getItemDetails
        //public  List<SaleObject> getItemDetails()
        //{

        //    List<SaleObject> lstItemIDName = new List<SaleObject>();
        //    try
        //    {




        //        //var result = SQLHelper.Instance.GetReader("Sp_Get_Items");

        //        //while (result.Read())
        //        //{

        //        //    lstItemIDName.Add(new SaleObject
        //        //    {
        //        //        ItemsId = Convert.ToInt32(result[0]),
        //        //        ItemName = result[1].ToString(),
        //        //        ItemNumber = result[2].ToString(),
        //        //        stock = Convert.ToDouble(result[3] == DBNull.Value ? 0 : result[3])
        //        //    });

        //        //}
        //        //result.Close();
        //        DataTable dtallitem = new DataTable();
        //        SqlParameter[] param=new SqlParameter[0];
        //        dtallitem = SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_Items", param, "AllItems");
        //        foreach (DataRow row in dtallitem.Rows)
        //        {
        //            lstItemIDName.Add(new SaleObject
        //            {
        //                ItemsId = Convert.ToInt32(row[0]),
        //                ItemName = row[1].ToString(),
        //                ItemNumber = row[2].ToString(),
        //                stock = Convert.ToDouble(row[3])

        //            });
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Close();
        //    }
        //    return lstItemIDName;
        //}
        public DataTable getItemDetails()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_Items", param, "AllItems");
        }
        #endregion
        #region getItemForCategoryWithNonStock
        public List<SaleObject> getItemForCategoryWithNonStock(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(SPCategoryItemNnonStock, SQLHelper.Instance.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@ChangeID", objSaleObject.CategoryId);
                    param[1] = new SqlParameter("@Value", objSaleObject.Value);
                    cmd.Parameters.AddRange(param);
                    var result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        lstSaleObject.Add(new SaleObject
                        {
                            ItemsId = Convert.ToInt16(result[0]),
                            ItemName = result[1].ToString(),
                            ItemNumber = result[2].ToString()
                        });
                    }

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

        #region getItemForCategoryWithStock
        public List<SaleObject> getItemForCategoryWithStock(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(SPCategoryItemStock, SQLHelper.Instance.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@ChangeID", objSaleObject.CategoryId);
                    param[1] = new SqlParameter("@Value", objSaleObject.Value);
                    cmd.Parameters.AddRange(param);
                    var result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        lstSaleObject.Add(new SaleObject
                        {
                            ItemsId = Convert.ToInt16(result[0]),
                            ItemName = result[1].ToString(),
                            ItemNumber = result[2].ToString()
                        });
                    }


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

        #region SaleId
        public List<int> GetSaleId()
        {
            List<int> ls = new List<int>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var reader = SQLHelper.Instance.GetReader("Sp_Get_InvoiceNumber_A", param);
                while (reader.Read())
                {

                    ls.Add(Convert.ToInt32(reader[0]));
                    ls.Add(Convert.ToInt32(reader[1]));
                    ls.Add(Convert.ToInt32(reader[2]));

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

        #region GetItemNameInfo
        public List<SaleObject> GetItemNameInfo(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> ItemInfoList = new List<SaleObject>();
                using (SqlCommand sqlCmd = new SqlCommand(SPGetItemInfo, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ItemID", ObjSale.itemid);
                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }

                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        ItemInfoList.Add(new SaleObject
                        {
                            ItemNo = Convert.ToInt32(result["ItemID"]),
                            ItemName = result["ItemName"].ToString(),
                            ItemBarcode = (result["Barcode"] == DBNull.Value ? "0" : result["Barcode"].ToString()),
                            ItemType = Convert.ToInt32(result["ItemType"]),
                            ItemDescription = result["ItemDescription"].ToString(),
                            unitprice = Convert.ToDecimal(result["Unit"] == DBNull.Value ? 0 : result["Unit"]),
                            ItemCostPer = Convert.ToDecimal(result["ItemCost"]),
                            ItemLastCost = Convert.ToDecimal(result["ItemLastCost"]),
                            ItemPackage = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                            ExpiryDate = Convert.ToBoolean((result[9] == DBNull.Value ? 0 : result[9])),
                            AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"]),
                            Reorder = Convert.ToInt32(result["Reorder"]),
                            ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                            ItemPrice = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                            MaxOrder = Convert.ToInt32(result["MaxOrder"]),
                            ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),

                            category = result["CategoryName"].ToString(),
                            company = result["CompanyName"].ToString(),
                            ItemExpiryDate = Convert.ToDateTime((result[18] == DBNull.Value ? null : result[18])),
                            ItemPlaceName = (result["ItemPlace"] == DBNull.Value ? "" : result["ItemPlace"].ToString()),
                            ItemTotalStock = Convert.ToInt32(result["StockOnHand"] == DBNull.Value ? 0 : result["StockOnHand"]),
                            BarcodeID = Convert.ToInt32(result["BarcodeID"] == DBNull.Value ? 0 : result["BarcodeID"]),
                            //add by thamil
                            ItemCost = Convert.ToDecimal(result["ItemCost"]),
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
                Close();
            }
        }
        #endregion

        #region GetDiscountForAgent
        public float GetDiscountForAgent(SaleObject ObjSale)
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
        public float GetIsDiscountOrIncreaseForAgent(SaleObject ObjSale)
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
        #endregion

        #region Payment Charges
        public float GetPaymentCharges(SaleObject ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@SaleID", ObjSale.saleid);

                float Disount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("Select ISNULL(PaymentCharges,0) from Sales Where SaleID = @SaleID and PaymentTypeID Not In (0,1)", Param));
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
        #endregion
        #region GetPaymentDate
        public Dictionary<string, List<SaleObject>> GetPaymentDate()
        {
            Dictionary<string, List<SaleObject>> dicPaymentDate = new Dictionary<string, List<SaleObject>>();
            List<SaleObject> lstAgentName = new List<SaleObject>();
            List<SaleObject> lstPaymntDate = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(SPGetPaymentDate, param);
                while (result.Read())
                {
                    lstAgentName.Add(new SaleObject { AgentName = result[0].ToString() });
                }
                result.NextResult();
                while (result.Read())
                {

                    lstPaymntDate.Add(new SaleObject
                    {
                        PaymentDate = Convert.ToDateTime(result[0]),
                        AgentName = result[1].ToString()
                    });

                }
                result.Close();
                dicPaymentDate.Add("AgentNames", lstAgentName);
                dicPaymentDate.Add("PaymentDates", lstPaymntDate);

                return dicPaymentDate;
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

        #region GetSerialNo
        public List<SaleObject> GetSerialNo(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetSerialNo, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        StockID = Convert.ToInt64(result["StockID"]),//Added & Commented on 16-May-2014
                        SerialNo = result["SerialNo"].ToString(),
                        ItemPrice = Convert.ToDecimal(result["Price"]),
                        ItemTotalStock = Convert.ToInt32(result["totalstock"]),

                    });
                }
                result.NextResult();
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

        #region GetItemMinimumPrice
        public List<SaleObject> GetItemMinimumPrice(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);

                var result = SQLHelper.Instance.GetReader(SPGetMinimumPrice, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        ItemPrice = Convert.ToDecimal(result["Price"] == DBNull.Value ? 0 : result["Price"]),
                        ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                        ItemPackage = Convert.ToInt32(result["package"]),
                        ItemTotalStock = Convert.ToInt32(result["StockOnHand"]),
                        AvgCost = Convert.ToDecimal(result["cost"] == DBNull.Value ? 0 : result["cost"])

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

        #region GetStockBasedExpiry
        public List<SaleObject> GetStockBasedExpiry(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@Expiry", objSaleObject.expiry);
                param[2] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                var result = SQLHelper.Instance.GetReader(SPGetStockBasedExpiry, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        ItemTotalStock = Convert.ToInt32(result[0] == DBNull.Value ? 0 : result[0]),//changed index 0 to 2 on 06Aug2014 by Meena.R
                        ItemPackage = Convert.ToInt32(result[1] == DBNull.Value ? 0 : result[1]),
                        quantity = Convert.ToInt32(result[2] == DBNull.Value ? 0 : result[2]),
                        StockAll = Convert.ToInt32(result[2] == DBNull.Value ? 0 : result[2])
                        // itemstock = result["TotalStock"] == DBNull.Value ? 0 : Convert.ToInt32(result["TotalStock"].ToString())
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

        #region GetStockBasedSerialNo
        public List<SaleObject> GetStockBasedSerialNo(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@SerialNo", objSaleObject.SerialNo);
                param[2] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                var result = SQLHelper.Instance.GetReader(SPGetStockBasedSerialNo, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {


                        ItemTotalStock = Convert.ToInt32(result[0] == DBNull.Value ? 0 : result[0]),
                        ItemPrice = Convert.ToDecimal(result[1] == DBNull.Value ? 0 : result[1]),
                        ItemPackage = Convert.ToInt32(result[2] == DBNull.Value ? 1 : result[2]),

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

        #region GetStock
        public List<SaleObject> GetStock(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetStock, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        ItemPackage = Convert.ToInt32(result[0]),
                        ItemTotalStock = Convert.ToInt32(result[1]),

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

        #region GetExpiryCount
        public List<SaleObject> GetExpiryCount(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                //var result = SQLHelper.Instance.GetReader(SPGetExpiryCount, param);//Commented on 29-April-2014
                var result = SQLHelper.Instance.GetReader(SPGetExpiryDates, param);//Added on 29-April-2014
                while (result.Read())
                {

                    lstSaleObject.Add(new SaleObject
                    {

                        //StockID = Convert.ToInt64(result["StockID"]), //Added & Commented on 16-May-2014
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"]),
                        ItemTotalStock = Convert.ToInt32(result["StockInHand"]),
                        StockID = Convert.ToInt64(result["StockID"])
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
        public List<SaleObject> GetExpiryUpdate(int ItemID, DateTime? Expiry)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", ItemID);
                param[1] = new SqlParameter("@ExpiryDate", Expiry);
                //var result = SQLHelper.Instance.GetReader(SPGetExpiryCount, param);//Commented on 29-April-2014
                var result = SQLHelper.Instance.GetReader("usp_GetExpiryDatesUpdate", param);//Added on 29-April-2014
                while (result.Read())
                {

                    lstSaleObject.Add(new SaleObject
                    {

                        //StockID = Convert.ToInt64(result["StockID"]), //Added & Commented on 16-May-2014
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"]),
                        ItemTotalStock = Convert.ToInt32(result["StockInHand"]),
                        StockID = Convert.ToInt64(result["StockID"])
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

        #region GetDebtLimit
        public List<SaleObject> GetDebtLimit(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT ISNULL(DebtLimit,0) FROM dbo.Agent WHERE AgentID=@AgentID", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        DebtLimit = Convert.ToDecimal(result[0])

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

        #region GetActiveUser
        public List<SaleObject> GetActiveUser(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.saleinv);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT ActiveUser FROM dbo.Sales WHERE SaleID=@InvoiceNo and SaleType=1", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
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

        #region GetYearSequenceMaxID
        public List<long> GetYearSequenceMaxID()
        {
            List<long> InvoiceID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TableId", CommonHelper.Table.Sales);
                param[1] = new SqlParameter("@Flag", "SalesInvoice");
                var result = SQLHelper.Instance.GetReader(SPGetNextID, param);
                while (result.Read())
                {
                    InvoiceID.Add(Convert.ToInt64(result["MaxId"]));
                    InvoiceID.Add(Convert.ToInt64(result["YearValue"]));
                    InvoiceID.Add(Convert.ToInt64(result["YearMaxId"]));
                    InvoiceID.Add(Convert.ToInt64(result["SaleID"]));

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

        #region SaveSales
        public bool SaveSales(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[25];

            try
            {
                param[0] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[1] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[2] = new SqlParameter("@AccountID", objSaleObject.accountid);
                param[3] = new SqlParameter("@SaleInvoice", objSaleObject.saleid);
                param[4] = new SqlParameter("@SaleDate", objSaleObject.invoicetime);
                param[5] = new SqlParameter("@Balance", objSaleObject.balance);
                param[6] = new SqlParameter("@Tax", objSaleObject.tax);
                param[7] = new SqlParameter("@Gross", objSaleObject.gross);
                param[8] = new SqlParameter("@Discount", objSaleObject.discount);
                param[9] = new SqlParameter("@NetAmount", objSaleObject.netamount);
                param[10] = new SqlParameter("@PaymentCharges", objSaleObject.paymentCharges);
                param[11] = new SqlParameter("@CreatedDate", DateTime.Now);
                param[12] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[13] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[14] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[15] = new SqlParameter("@Status", objSaleObject.status);
                param[16] = new SqlParameter("@Tax1", objSaleObject.tax1);
                param[17] = new SqlParameter("@TaxSub", objSaleObject.taxsub);
                param[18] = new SqlParameter("@Tax1Sub", objSaleObject.tax1sub);
                param[19] = new SqlParameter("@Note", objSaleObject.note);
                param[20] = new SqlParameter("@ActualDiscount", objSaleObject.actualdiscount);
                param[21] = new SqlParameter("@DiscountType", objSaleObject.discounttype);
                param[22] = new SqlParameter("@IncludeTax", objSaleObject.includetax);
                param[23] = new SqlParameter("@SaleType", objSaleObject.SaleType);
                param[24] = new SqlParameter("@PaymentTypeID", objSaleObject.receive_paymenttypeID);

                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleM, param) > 0)
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

        #region SaveSalesOnClose
        public bool SaveSalesOnClose(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[25];

            try
            {
                param[0] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[1] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[2] = new SqlParameter("@AccountID", objSaleObject.accountid);
                param[3] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[4] = new SqlParameter("@SaleDate", objSaleObject.invoicetime);
                param[5] = new SqlParameter("@Balance", objSaleObject.balance);
                param[6] = new SqlParameter("@Tax", float.Parse(objSaleObject.tax.ToString()));
                param[7] = new SqlParameter("@Gross", objSaleObject.gross);
                param[8] = new SqlParameter("@Discount", objSaleObject.discount);
                param[9] = new SqlParameter("@NetAmount", objSaleObject.netamount);
                param[10] = new SqlParameter("@PaymentCharges", objSaleObject.paymentCharges);
                param[11] = new SqlParameter("@CreatedDate", objSaleObject.invoicetime);
                param[12] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[13] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[14] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[15] = new SqlParameter("@Status", objSaleObject.status);
                param[16] = new SqlParameter("@Tax1", float.Parse(objSaleObject.tax1.ToString()));
                param[17] = new SqlParameter("@TaxSub", float.Parse(objSaleObject.taxsub.ToString()));
                param[18] = new SqlParameter("@Tax1Sub", float.Parse(objSaleObject.tax1sub.ToString()));
                param[19] = new SqlParameter("@Note", objSaleObject.note);
                param[20] = new SqlParameter("@ActualDiscount", objSaleObject.actualdiscount);
                param[21] = new SqlParameter("@DiscountType", objSaleObject.discounttype);
                param[22] = new SqlParameter("@IncludeTax", objSaleObject.includetax);
                param[23] = new SqlParameter("@SaleType", objSaleObject.SaleType);
                param[24] = new SqlParameter("@PaymentTypeID", objSaleObject.receive_paymenttypeID);


                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleM, param) > 0)
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

        #region UpdateActiveUser
        public bool UpdateActiveUser(SaleObject objSaleObject)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ActiveUser", GeneralFunction.UserId);
                //param[1] = new SqlParameter("@InvoiceNo", objSaleObject.saleinv);
                param[1] = new SqlParameter("@InvoiceNo", objSaleObject.InvoiceNumber);
                if (SQLHelper.Instance.ExecuteNonQuery(SPUpdateActiveUser, param) > 0)
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


        //public List<SaleObject> GetSaleDetailsExample(SaleObject objSaleObject)
        //{
        //    List<SaleObject> lstSaleObject = new List<SaleObject>();
        //    try
        //    {

        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
        //        //var result = SQLHelper.Instance.GetReader(SPGetInvoiceDetails, param);
        //        var obj = SQLHelper.Instance.GetScalar(SPGetInvoiceDetails, param);
        //        if (obj != null)
        //        {
        //            DataTable table = obj as DataTable;
        //            if (table.Rows.Count > 0)
        //            {
        //                foreach (DataRow row in table.Rows)
        //                {
        //                    string ClientName = string.Empty;
        //                    if (Convert.ToInt32(CommonHelper.CashClientID.ID) == Convert.ToInt32(row["Client"]))
        //                    {
        //                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
        //                            ClientName = "CASH CLIENT";
        //                        else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
        //                            ClientName = "زبون نقدي";
        //                    }
        //                    else
        //                        ClientName = row["ClientName"].ToString();
        //                    lstSaleObject.Add(new SaleObject
        //                    {
        //                        note = row["Note"] == DBNull.Value ? string.Empty : row["Note"].ToString(),
        //                        ClientID = Convert.ToInt32(row["Client"]),
        //                        //ClientName = result["ClientName"].ToString(),
        //                        ClientName = ClientName,
        //                        netamount = Convert.ToDecimal(row["NetAmount"]),
        //                        total = Convert.ToDecimal(row["TotalAmount"]),
        //                        discount = Convert.ToDouble(row["Discount"]),
        //                        discounttype = Convert.ToInt32(row["DiscountType"]),
        //                        actualdiscount = Convert.ToDecimal(row["ActualDiscount"]),
        //                        includetax = Convert.ToInt16(row["includetax"]),
        //                        status = Convert.ToInt16(row["STATUS"]),
        //                        user = row["Users"].ToString(),
        //                        CreatedDate = Convert.ToDateTime(row["SDate"]),
        //                        Activuser = Convert.ToInt32(row["ActiveUser"] == DBNull.Value ? 0 : row["ActiveUser"]),
        //                        saleid = Convert.ToInt64(row["SaleID"]),
        //                        quantity = Convert.ToInt32(row["Qty"]),
        //                        price = Convert.ToDecimal(row["Price"]),
        //                        ItemPrice = Convert.ToDecimal(row["Total"]),
        //                        ItemExpiryDate = Convert.ToDateTime(row["Expiry"]),
        //                        balance = Convert.ToDecimal(row["Balance"]),
        //                        itemid = Convert.ToInt32(row["ItemNo"]),
        //                        ItemPackage = Convert.ToInt32(row["Package"]),
        //                        saledetid = Convert.ToInt64(row["SaleDetailID"]),
        //                        ReturnQty = Convert.ToInt32(row["ReturnQty"]),
        //                        ItemCostPer = Convert.ToDecimal(row["ItemCost"]),
        //                        //SerialNo = Convert.ToInt64(result["SerialNo"]),
        //                        SerialNo = row["SerialNo"].ToString(),
        //                        itemdiscount = Convert.ToDouble(row["ItemDiscount"]),
        //                        Newexpr = Convert.ToDateTime(row["NewExpiry"]),
        //                        ActualPrice = Convert.ToDecimal(row["ActualPrice"]),
        //                        tax = Convert.ToDecimal(row["ItemTax"]),



        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Close();
        //    }

        //    return lstSaleObject;
        //}

        #region GetSaleDetails
        public List<SaleObject> GetSaleDetails(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                SQLHelper Sale = new SQLHelper();
                var result = Sale.GetReader(SPGetInvoiceDetails, param);
                while (result.Read())
                {
                    string ClientName = string.Empty;
                    if (Convert.ToInt32(CommonHelper.CashClientID.ID) == Convert.ToInt32(result["Client"]))
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                            ClientName = "CASH CLIENT";
                        else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                            ClientName = "زبون نقدي";
                    }
                    else
                        ClientName = result["ClientName"].ToString();
                    var s = Convert.ToDecimal(result["PaymentCharges"]);
                    lstSaleObject.Add(new SaleObject
                    {
                        note = result["Note"] == DBNull.Value ? string.Empty : result["Note"].ToString(),
                        ClientID = Convert.ToInt32(result["Client"]),
                        //ClientName = result["ClientName"].ToString(),
                        ClientName = ClientName,
                        netamount = Convert.ToDecimal(result["NetAmount"]),
                        //paymentCharges= Convert.ToDecimal(result["PaymentCharges"]),
                        total = Convert.ToDecimal(result["TotalAmount"]),
                        paymentCharges = Convert.ToDecimal(result["PaymentCharges"]),
                        discount = Convert.ToDouble(result["Discount"]),
                        discounttype = Convert.ToInt32(result["DiscountType"]),
                        actualdiscount = Convert.ToDecimal(result["ActualDiscount"]),
                        includetax = Convert.ToInt16(result["includetax"]),
                        status = Convert.ToInt16(result["STATUS"]),
                        user = result["Users"].ToString(),
                        CreatedDate = Convert.ToDateTime(result["SDate"]),
                        Activuser = Convert.ToInt32(result["ActiveUser"] == DBNull.Value ? 0 : result["ActiveUser"]),
                        saleid = Convert.ToInt64(result["SaleID"]),
                        quantity = Convert.ToInt32(result["Qty"]),
                        price = Convert.ToDecimal(result["Price"]),
                        ItemPrice = Convert.ToDecimal(result["Total"]),
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"]),
                        balance = Convert.ToDecimal(result["Balance"]),
                        itemid = Convert.ToInt32(result["ItemNo"]),
                        ItemPackage = Convert.ToInt32(result["Package"]),
                        saledetid = Convert.ToInt64(result["SaleDetailID"]),
                        ReturnQty = Convert.ToInt32(result["ReturnQty"]),
                        ItemCostPer = Convert.ToDecimal(result["ItemCost"]),
                        //SerialNo = Convert.ToInt64(result["SerialNo"]),
                        SerialNo = result["SerialNo"].ToString(),
                        itemdiscount = Convert.ToDouble(result["ItemDiscount"]),
                        Newexpr = Convert.ToDateTime(result["NewExpiry"]),
                        ActualPrice = Convert.ToDecimal(result["ActualPrice"]),
                        tax = Convert.ToDecimal(result["ItemTax"]),
                        receive_paymenttypeID= Convert.ToInt32(result["PaymentTypeID"])



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

        #region GetSaleDetailsExtended
        public List<SaleObject> GetSaleDetailsExtended(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[1] = new SqlParameter("@UserGroupID", GeneralFunction.UserGroupID);
                var result = SQLHelper.Instance.GetReader(SPGetInvoiceDetailsExtended, param);


                while (result.Read())
                {

                    lstSaleObject.Add(new SaleObject
                    {
                        itemid = Convert.ToInt32(result["itemno"]),
                        ItemDescription = result["Discription"].ToString(),
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"] == DBNull.Value ? DateTime.MinValue : result["Expiry"]),
                        ItemPackage = Convert.ToInt32(result["Package"] == DBNull.Value ? 1 : result["Package"]),
                        quantity = Convert.ToInt32(result["Quantity"]),
                        unitprice = Convert.ToDecimal(result["UnitPrice"]),
                        TotalPrice = Convert.ToDecimal(result["Total"]),
                        ModifiedDate = Convert.ToDateTime(result["Time"] == DBNull.Value ? DateTime.MinValue : result["Time"]),
                        StrModifiedDate = (result["Time"] == DBNull.Value ? "00:00" : result["Time"].ToString()),
                        user = result["UserName"].ToString(),
                        ReturnQty = Convert.ToInt32(result["Returned"]),
                        ClientID = Convert.ToInt32(result["Agent"]),
                        saledetid = Convert.ToInt64(result["SaleDetailID"]),
                        saleid = Convert.ToInt64(result["SaleId"]),
                        //serialno = Convert.ToInt64(result["SerialNo"]),
                        serialno = result["SerialNo"].ToString(),
                        Newexpr = Convert.ToDateTime(result["NewExpr"] == DBNull.Value ? DateTime.MinValue : result["NewExpr"]),
                        ActualPrice = Convert.ToDecimal(result["actualprice"]),
                        tax = Convert.ToDecimal(result["itemtax"]),
                        ItemCostPer = Convert.ToDecimal(result["itemcost"]),
                        StrItemNo = result["ItemNumber"].ToString(),
                        StrExpiryDate = (result["Expiry"] == DBNull.Value ? "-" : Convert.ToDateTime(result["Expiry"]).ToString().Split(' ').Length > 2 ? Convert.ToDateTime(result["Expiry"]).ToString().Split(' ')[1] : Convert.ToDateTime(result["Expiry"]).ToString().Split(' ')[0]),
                        itemdiscount = float.Parse(result["Discount"].ToString()),
                        itemunitdiscount = Convert.ToDecimal(result["UnitDiscount"].ToString()),
                        itemunitprice = Convert.ToDecimal(result["ItemUnitPrice"].ToString()),
                        // BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                        BarcodeID = result["BarcodeID"] == DBNull.Value ? 0 : Convert.ToInt32(result["BarcodeID"]),
                        Box = Convert.ToInt32(result["Box"] == DBNull.Value ? 0 : Convert.ToInt32(result["Box"])),
                        ItemCost = Convert.ToDecimal(result["itemcost"]),
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

        #region GetItemAvgCost
        public List<SaleObject> GetItemAvgCost(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> ItemInfoList = new List<SaleObject>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", ObjSale.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetItemAverageCost, param);
                while (result.Read())
                {
                    ItemInfoList.Add(new SaleObject
                    {

                        AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"])

                    });

                }

                return ItemInfoList;

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

        #region SaveSaleDetails
        public bool SaveSaleDetails(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[34];

            try
            {
                //GeneralFunction.Errorlogfile("=================Sale Invoice Screen =====================", 1, "", "", true);
                //string TraceObj = "AgentID = " + objSaleObject.ClientID + Environment.NewLine;
                //TraceObj += " SaleDetailID = " + objSaleObject.saledetid + Environment.NewLine;
                //TraceObj += " SaleID = " + objSaleObject.saleid + Environment.NewLine;
                //TraceObj += " BatchID = " + objSaleObject.batchid + Environment.NewLine;
                //TraceObj += " ItemID = " + objSaleObject.itemid + Environment.NewLine;
                //TraceObj += " Quantity = " + objSaleObject.quantity + Environment.NewLine;
                //TraceObj += " Price = " + objSaleObject.price + Environment.NewLine;
                //TraceObj += " Discount = " + objSaleObject.itemdiscount + Environment.NewLine;
                //TraceObj += " Status = " + objSaleObject.status + Environment.NewLine;
                //TraceObj += " SaleInvoice = " + objSaleObject.saleinv + Environment.NewLine;
                //TraceObj += " Id = " + objSaleObject.id + Environment.NewLine;
                //TraceObj += " ReturnQty = " + objSaleObject.ReturnQty + Environment.NewLine;
                //TraceObj += " ExpiryDate = " + objSaleObject.expiry + Environment.NewLine;
                //TraceObj += " Cost = " + objSaleObject.ItemCost + Environment.NewLine;
                //TraceObj += " StockInHand = " + objSaleObject.stock + Environment.NewLine;
                //TraceObj += " SerialNo = " + objSaleObject.serialno + Environment.NewLine;
                //TraceObj += " SecondHand = " + objSaleObject.secondhand + Environment.NewLine;
                //TraceObj += " NonStock = " + objSaleObject.nonstocklabourmeal + Environment.NewLine;
                //TraceObj += " ActualPrice = " + objSaleObject.ActualPrice + Environment.NewLine;
                //TraceObj += " Total = " + objSaleObject.total + Environment.NewLine;
                //TraceObj += " Net = " + objSaleObject.net + Environment.NewLine;
                //TraceObj += " TaxofItem = " + objSaleObject.taxofitem + Environment.NewLine;
                //TraceObj += " PackageQty = " + objSaleObject.package + Environment.NewLine;
                //TraceObj += " ItemTax2 = " + objSaleObject.ItemTax2 + Environment.NewLine;
                //TraceObj += " SubTax1 = " + objSaleObject.SubTax1 + Environment.NewLine;
                //TraceObj += " SubTax2 = " + objSaleObject.SubTax2 + Environment.NewLine;
                //TraceObj += " ActualUnitPrice = " + objSaleObject.price + Environment.NewLine;
                //TraceObj += " BarcodeID = " + objSaleObject.BarcodeID + Environment.NewLine;
                //TraceObj += " Box = " + objSaleObject.Box + Environment.NewLine;
                //TraceObj += " TotalAmount = " + objSaleObject.TotalAmount;
                //GeneralFunction.Errorlogfile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + Environment.NewLine + TraceObj, 1, "", "", true);

                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID == 0 ? 1001 : objSaleObject.ClientID);
                param[1] = new SqlParameter("@SaleDetailID", objSaleObject.saledetid);
                param[2] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[3] = new SqlParameter("@BatchID", objSaleObject.batchid);
                param[4] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[5] = new SqlParameter("@Quantity", objSaleObject.quantity);
                param[6] = new SqlParameter("@Price", objSaleObject.price);
                param[7] = new SqlParameter("@Discount", objSaleObject.itemdiscount);
                param[8] = new SqlParameter("@CreatedDate", objSaleObject.invoicetime);
                param[9] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[10] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[11] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[12] = new SqlParameter("@Status", objSaleObject.status);
                param[13] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[14] = new SqlParameter("@Id", objSaleObject.id);
                param[15] = new SqlParameter("@ReturnQuantity", objSaleObject.ReturnQty);
                param[16] = new SqlParameter("@ExpiryDate", objSaleObject.expiry);
                param[17] = new SqlParameter("@Cost", objSaleObject.ItemCost);
                param[18] = new SqlParameter("@StockInHand", objSaleObject.stock);
                param[19] = new SqlParameter("@SerialNo", objSaleObject.serialno);
                param[20] = new SqlParameter("@SecondHand", objSaleObject.secondhand);
                param[21] = new SqlParameter("@NonStock", objSaleObject.nonstocklabourmeal);
                param[22] = new SqlParameter("@ActualPrice", objSaleObject.ActualPrice);
                param[23] = new SqlParameter("@Total", objSaleObject.total);
                param[24] = new SqlParameter("@Net", objSaleObject.net);
                param[25] = new SqlParameter("@taxofitem", objSaleObject.taxofitem);
                param[26] = new SqlParameter("@PackageQty", objSaleObject.package);
                param[27] = new SqlParameter("@ItemTax2", objSaleObject.ItemTax2);//all the code from this line Added on 19-May-2014
                param[28] = new SqlParameter("@SubTax1", objSaleObject.SubTax1);
                param[29] = new SqlParameter("@SubTax2", objSaleObject.SubTax2);
                param[30] = new SqlParameter("@ActualUnitPrice", objSaleObject.price);
                param[31] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                param[32] = new SqlParameter("@Box", objSaleObject.Box);
                param[33] = new SqlParameter("@TotalAmount", objSaleObject.TotalAmount);

                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleDetail, param) > 0)
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

        #region SaveSaleDetailsOnClosing
        public bool SaveSaleDetailsOnClosing(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[19];

            try
            {
                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[1] = new SqlParameter("@SaleDetailID", objSaleObject.saledetid);
                param[2] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[3] = new SqlParameter("@BatchID", objSaleObject.batchid);
                param[4] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[5] = new SqlParameter("@Quantity", objSaleObject.quantity);
                param[6] = new SqlParameter("@Price", objSaleObject.price);
                param[7] = new SqlParameter("@Discount", objSaleObject.itemdiscount);
                param[8] = new SqlParameter("@CreatedDate", objSaleObject.invoicetime);
                param[9] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[10] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[11] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[12] = new SqlParameter("@Status", objSaleObject.status);
                param[13] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[14] = new SqlParameter("@Id", objSaleObject.id);
                param[15] = new SqlParameter("@ReturnQuantity", objSaleObject.ReturnQty);
                param[16] = new SqlParameter("@ExpiryDate", objSaleObject.expiry);
                param[17] = new SqlParameter("@Cost", objSaleObject.ItemCostPer);
                param[18] = new SqlParameter("@taxofitem", objSaleObject.taxofitem);


                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveSaleDetailOnClosing, param) > 0)
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


        #region SaveSaleDetailsOnClosing
        public bool SaveSaleDetailOnCloseDT(DataTable dt)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Sales", dt);

                if (SQLHelper.Instance.ExecuteNonQuery("uspUpdateSaleDetail", param) > 0)
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

        #region GetSaleDetailID
        public DataTable GetSaleDetailID(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@AgentId", objSaleObject.ClientID);
                param[1] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                //var result = SQLHelper.Instance.GetReader(SPGetSaleDetID, param);
                //while (result.Read())
                //{
                //    lstSaleObject.Add(new SaleObject
                //    {

                //        saledetid = Convert.ToInt64(result["SaleDetailID"] == DBNull.Value ? 0 : result["SaleDetailID"]),
                //        saleid = Convert.ToInt64(result["saleid"] == DBNull.Value ? 0 : result["saleid"]),
                //        maxsaleid = Convert.ToInt64(result["maxsaleid"] == DBNull.Value ? 0 : result["maxsaleid"]),

                //    });
                //}
                return SQLHelper.Instance.ExecuteQueryDatatable(SPGetSaleDetID, param, "IDs");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }

            //return lstSaleObject;
        }
        #endregion

        #region GetYearSequence
        public List<SaleObject> GetYearSequence(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.saleinv);
                param[1] = new SqlParameter("@Flag", objSaleObject.Flag);
                var result = SQLHelper.Instance.GetReader(SPGetYearSequence, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
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

        #region GetStockBaseExpiryInvNo

        public List<SaleObject> GetStockBaseExpiryInvNo(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@Expiry", objSaleObject.expiry);
                var result = SQLHelper.Instance.GetReader(SPGetStockBaseExpiryInvNo, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        ItemTotalStock = Convert.ToInt32(result["ExpiryStock"] == DBNull.Value ? 0 : result["ExpiryStock"]),
                        ItemPackage = Convert.ToInt32(result["package"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),

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

        #region DeleteSaleItem
        public bool DeleteSaleItem(SaleObject objSaleObject)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[1] = new SqlParameter("@SaleDetailID", objSaleObject.saledetid);
                param[2] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[3] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[4] = new SqlParameter("@StockInHand", objSaleObject.stock);
                param[5] = new SqlParameter("@Expiry", objSaleObject.Newexpr);
                param[6] = new SqlParameter("@SerialNo", objSaleObject.serialno);
                param[7] = new SqlParameter("@SecondHand", objSaleObject.secondhand);
                param[8] = new SqlParameter("@Total", objSaleObject.TotalPrice);
                param[9] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                param[10] = new SqlParameter("@GroupID", GeneralFunction.UserGroupID);
                if (SQLHelper.Instance.ExecuteNonQuery(SPDeleteSaleItem, param) > 0)
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

        #region GetItemNameForID
        public List<SaleObject> GetItemNameForID(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT ItemID,ItemName FROM Item WHERE ItemID =@ItemID AND [Status]=1", param);
                if (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        itemname = result["ItemName"].ToString()

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

        #region GetClientNo
        public List<SaleObject> GetClientNo(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {
                if (objSaleObject.clientname.Contains("CASH CLIENT") || objSaleObject.clientname.Contains("زبون نقدي"))
                    objSaleObject.clientname = "CASH CLIENT";
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentName", objSaleObject.clientname);
                var result = SQLHelper.Instance.GetReader(SPGetClientNo, param);
                if (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        discount = Convert.ToDouble(result["Discount"]),
                        AgentName = result["AgentName"].ToString(),
                        ClientID = Convert.ToInt32(result["AgentID"]),
                        AgentType = result["type"].ToString(),
                        branch = result["branch"].ToString()

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

        #region GetClientName
        public List<SaleObject> GetClientName(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT AgentName FROM Agent (NOLOCK) WHERE AgentID=@AgentID AND [Status]=1", param);
                if (result.Read())
                {
                    string ClientName = string.Empty;
                    if (objSaleObject.ClientID == Convert.ToInt32(CommonHelper.CashClientID.ID))
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                            ClientName = "CASH CLIENT";
                        else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                            ClientName = "زبون نقدي";
                    }
                    else
                        ClientName = result["AgentName"].ToString();
                    lstSaleObject.Add(new SaleObject
                    {
                        // AgentName = result["AgentName"].ToString()
                        AgentName = ClientName

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

        #region GetCurrentYear()
        public List<SaleObject> GetCurrentYear(int TableID)
        {
            try
            {
                List<SaleObject> lstWithYear = new List<SaleObject>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", TableID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select YearValue from KeySequence where TableId=@TableId", sqlParam);
                if (ReaderResult.Read())
                {
                    lstWithYear.Add(new SaleObject { CurrentYear = Convert.ToInt32(ReaderResult["YearValue"]) });

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

        #region GetMinMaxSaleID()
        public List<int> GetMinMaxSaleID()
        {
            try
            {
                List<int> lstMinMaxID = new List<int>();
                SqlParameter[] sqlParam = new SqlParameter[0];

                var ReaderResult = SQLHelper.Instance.GetReader(SPGetMinMaxSaleID, sqlParam);
                if (ReaderResult.Read())
                {
                    lstMinMaxID.Add(Convert.ToInt32(ReaderResult["MinID"]));
                    lstMinMaxID.Add(Convert.ToInt32(ReaderResult["MaxID"]));

                }

                return lstMinMaxID;
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

        #region GetAgentDiscount
        public Decimal GetAgentDiscount(SaleObject objSaleObject)
        {
            Decimal Discount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT Discount FROM dbo.Agent (NOLOCK)	WHERE AgentID = @AgentID", param);
                if (result.Read())
                {
                    Discount = Convert.ToDecimal(result["Discount"]);
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
        #endregion

        #region CheckEmptyInvoice
        public int CheckEmptyInvoice(SaleObject objSaleObject)
        {
            int Count = 0;
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[1] = new SqlParameter("@SaleType", 1);
                var result = SQLHelper.Instance.GetReader(SPCheckEmptyInvoice, param);
                if (result.Read())
                {
                    Count = Convert.ToInt16(result[0]);
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

            return Count;
        }
        #endregion

        #region ModifyInvoice
        public bool ModifyInvoice(SaleObject objSaleObject)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInv", objSaleObject.saleinv);

                if (SQLHelper.Instance.ExecuteNonQuery(SPModifyInvoice, param) > 0)
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

        #region CheckClosedInvoice
        public int CheckClosedInvoice(SaleObject objSaleObject)
        {
            int Status = 1;
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT [Status] FROM dbo.Sales (NOLOCK) WHERE SaleInvoice=@SaleInvoice AND SaleType=1", param);
                if (result.Read())
                {
                    Status = Convert.ToInt16(result["Status"]);
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

            return Status;
        }
        #endregion

        #region GetBalanceForSaleInvoice
        public List<SaleObject> GetBalanceForSaleInvoice(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> lstBalance = new List<SaleObject>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SaleInvoice", ObjSale.saleinv);
                var result = SQLHelper.Instance.GetReader(SPCheckBalance, param);

                result.NextResult();
                result.NextResult();
                result.NextResult();
                result.NextResult();
                while (result.Read())
                {
                    lstBalance.Add(new SaleObject
                    {

                        balance = Convert.ToDecimal(result["bal"] == DBNull.Value ? 0 : result["bal"])

                    });

                }

                return lstBalance;

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

        #region GetItemInfoExport
        public List<SaleObject> GetItemInfoExport(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> ItemInfoList = new List<SaleObject>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", ObjSale.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetItemInfoExport, param);
                while (result.Read())
                {
                    ItemInfoList.Add(new SaleObject
                    {
                        ItemNo = Convert.ToInt32(result["ItemID"]),
                        ItemName = result["ItemName"].ToString(),
                        ItemBarcode = (result["Barcode"] == DBNull.Value ? "" : result["Barcode"].ToString()),
                        ItemAdditionalBarcode = (result["AdditionalBarcode"] == DBNull.Value ? "" : result["AdditionalBarcode"].ToString()),
                        CategoryId = Convert.ToInt32(result["CategoryID"]),
                        CategoryName = result["CategoryName"].ToString(),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        ItemPlaceID = Convert.ToInt32(result["ItemPlaceID"]),
                        ItemPlaceName = (result["PlaceName"] == DBNull.Value ? "" : result["PlaceName"].ToString()),
                        ItemDescription = result["ItemDescription"].ToString(),
                        Unit = Convert.ToInt32(result["Unit"] == DBNull.Value ? 0 : result["Unit"]),
                        CompanyId = Convert.ToInt32(result["CompanyID"]),
                        CompanyName = result["CompanyName"].ToString(),
                        ClientID = Convert.ToInt32(result["AgentID"] == DBNull.Value ? 0 : result["AgentID"]),
                        ItemCostPer = Convert.ToDecimal(result["ItemCost"]),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"]),
                        ItemPackage = Convert.ToInt32(result["PackageQty"]),
                        ExpiryDate = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? 0 : result["ExpiryDate"])),
                        Reorder = Convert.ToInt32(result["Reorder"]),
                        ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"] == DBNull.Value ? 0 : result["WholeSalePrice"]),
                        ItemPrice = Convert.ToDecimal(result["Price"]),
                        MaxOrder = Convert.ToInt32(result["MaxOrder"]),
                        ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0 : result["MinPrice"]),
                        Status = Convert.ToInt32(result["Status"]),
                        AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"]),


                    });


                }


                return ItemInfoList;

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

        #region GetInvoiceIDBasedonNewYearID
        public object GetInvoiceIDBasedonNewYearID(SaleObject ObjSale)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", ObjSale.Year);
            param[1] = new SqlParameter("@YearSequence", ObjSale.YearSequenceNo);
            return SQLHelper.Instance.GetScalar(SPGetSalesInvoiceID, param);
        }
        #endregion

        #region GetSalesPrintReport
        public DataTable GetSalesPrintReport(SaleObject ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@InvoiceNo", ObjSale.saleinv);
                return SQLHelper.Instance.ExecuteQueryDatatable(SPGetReportSaleInvoice, Param, "ReportValues");
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
        public DataTable GetSalesPaidRemainingByID(SaleObject ObjSale)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@InvoiceNo", ObjSale.saleinv);
                return SQLHelper.Instance.ExecuteQueryDatatable(SPGetReportSaleInvoicePaidRemain, Param,"PaidRemaining");
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

        #region Performance Invoice Methods

        #region GetItemInfoForPerform
        public List<SaleObject> GetItemInfoForPerform(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> ItemInfoList = new List<SaleObject>();
                using (SqlCommand sqlCmd = new SqlCommand(SPGetItemInforForPerform, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ItemID", ObjSale.ItemNo);
                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }

                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        ItemInfoList.Add(new SaleObject
                        {
                            ItemNo = Convert.ToInt32(result["ItemID"]),
                            ItemName = result["ItemName"].ToString(),
                            ItemBarcode = result["Barcode"].ToString(),
                            ItemType = Convert.ToInt32(result["ItemType"]),
                            ItemDescription = result["ItemDescription"].ToString(),
                            //unitprice = Convert.ToDecimal(result["Unit"]),
                            ItemCostPer = Convert.ToDecimal(result["ItemCost"]),
                            ItemLastCost = Convert.ToDecimal(result["ItemLastCost"]),
                            ItemPackage = Convert.ToInt32(result["PackageQty"]),
                            HasExpiry = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? 0 : result["ExpiryDate"])),
                            AvgCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? 0 : result["AverageCost"]),
                            Reorder = Convert.ToInt32(result["Reorder"]),
                            ItemWholeSalePrice = Convert.ToDecimal(result["WholeSalePrice"]),
                            ItemPrice = Convert.ToDecimal(result["Price"]),
                            MaxOrder = Convert.ToInt32(result["MaxOrder"]),
                            ItemMinimumPrice = Convert.ToDecimal(result["MinPrice"]),
                            ItemExpiryDate = Convert.ToDateTime((result["ExpiryDate1"] == DBNull.Value ? null : result["ExpiryDate1"])),
                            //ItemTotalStock = Convert.ToInt32(result["StockInHand"]),//Commented on 16-Oct-2014 by Seenivasan to take total Stock instead of particular Package task
                            ItemTotalStock = Convert.ToInt32(result["TotalStock"]),//Added on 16-Oct-2014 by Seenivasan 
                            BarcodeID = Convert.ToInt32(result["BarcodeID"])
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
                Close();
            }
        }
        #endregion

        #region GetExpiryDatesForItem
        public List<SaleObject> GetExpiryDatesForItem(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> ItemExpiryList = new List<SaleObject>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", ObjSale.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetExpiryDate, param);
                while (result.Read())
                {
                    ItemExpiryList.Add(new SaleObject
                    {
                        ItemExpiryDate = Convert.ToDateTime((result["ExpiryDate"] == DBNull.Value ? null : result["ExpiryDate"]))

                    });

                }

                return ItemExpiryList;

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

        #region GetMaxIDAndYearSequence
        public List<long> GetMaxIDAndYearSequence()
        {
            List<long> InvoiceID = new List<long>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@TableId", CommonHelper.Table.PerformaInvoice);
                param[1] = new SqlParameter("@Flag", "Normal");
                var result = SQLHelper.Instance.GetReader(SPGetNextID, param);
                if (result.Read())
                {
                    InvoiceID.Add(Convert.ToInt64(result["MaxId"]));
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

        #region SavePerformaInvoice
        public bool SavePerformaInvoice(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[25];

            try
            {
                param[0] = new SqlParameter("@OrderInvoice", objSaleObject.OrderInvoiceNo);
                param[1] = new SqlParameter("@AgentID", objSaleObject.SupplierNo);
                param[2] = new SqlParameter("@NetAmount", objSaleObject.netamount);

                param[3] = new SqlParameter("@OrderDate", objSaleObject.OrderDate);
                param[4] = new SqlParameter("@DeliveryDate", objSaleObject.OrderDeliveryDate);
                param[5] = new SqlParameter("@Remarks", objSaleObject.InvoiceType);
                param[6] = new SqlParameter("@CreatedDate", objSaleObject.CreatedDate);
                param[7] = new SqlParameter("@CreatedBy", objSaleObject.CreatedBy);
                param[8] = new SqlParameter("@ModifiedDate", objSaleObject.ModifiedDate);
                param[9] = new SqlParameter("@ModifiedBy", objSaleObject.ModifiedBy);
                param[10] = new SqlParameter("@Status", objSaleObject.Status);
                param[11] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[12] = new SqlParameter("@Quantity", objSaleObject.quantity);
                param[13] = new SqlParameter("@Package", objSaleObject.ItemPackage);
                param[14] = new SqlParameter("@UnitPrice", objSaleObject.unitprice);
                param[15] = new SqlParameter("@DemandDate", objSaleObject.OrderDemandDate);
                param[16] = new SqlParameter("@REMOVE", objSaleObject.SetStatus);
                param[17] = new SqlParameter("@Discount", objSaleObject.ItemDiscount);
                param[18] = new SqlParameter("@Price", objSaleObject.ItemPrice);
                param[19] = new SqlParameter("@DiscountType", objSaleObject.discounttype);
                param[20] = new SqlParameter("@Cost", objSaleObject.ItemCostPer);
                param[21] = new SqlParameter("@ItemDiscount", objSaleObject.ItemDiscountOne);
                param[22] = new SqlParameter("@OriginalDiscount", objSaleObject.OriginalDiscount);
                param[23] = new SqlParameter("@Note", objSaleObject.note);
                param[24] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);

                if (SQLHelper.Instance.ExecuteNonQuery(SPSavePerformaInvoice, param) > 0)
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

        #region GetOrderInvoiceDetails
        public List<SaleObject> GetOrderInvoiceDetails(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> OrderInfoList = new List<SaleObject>();
                using (SqlCommand sqlCmd = new SqlCommand(SPGetOrderInvoiceDetails, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@OrderInvoice", ObjSale.OrderInvoiceNo);
                    param[1] = new SqlParameter("@Remarks", ObjSale.InvoiceType);
                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }

                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        OrderInfoList.Add(new SaleObject
                        {

                            OrderInvoiceNo = Convert.ToInt64(result["OrderInvoice"]),
                            Year = Convert.ToInt16(result["Year"]),
                            YearSequenceNo = Convert.ToInt64(result["YearSequenceNo"]),
                            ItemNo = Convert.ToInt32(result["ItemID"]),
                            ItemDescription = result["ItemName"].ToString(),
                            ClientID = Convert.ToInt16(result["AgentID"]),
                            ClientName = result["AgentName"].ToString(),
                            quantity = Convert.ToInt16(result["Quantity"]),
                            unitprice = Convert.ToDecimal(result["UnitPrice"]),
                            TotalPrice = Convert.ToDecimal(result["Total"]),
                            OrderDemandDate = Convert.ToDateTime(result["DemandDate"]),
                            netamount = Convert.ToDecimal(result["NetAmount"]),
                            OrderDeliveryDate = Convert.ToDateTime(result["DeliveryDate"]),
                            actualdiscount = Convert.ToDecimal(result["Discount"]),
                            Status = Convert.ToInt16(result["Status"]),
                            package = Convert.ToInt16(result["Package"]),
                            price = Convert.ToDecimal(result["Price"]),
                            TotalOne = Convert.ToDecimal(result["TOTAL"]),
                            ItemCostPer = Convert.ToDecimal(result["ItemCost"]),
                            HasExpiry = Convert.ToBoolean((result["ExpiryDate"] == DBNull.Value ? false : result["ExpiryDate"])),
                            OrderDate = Convert.ToDateTime(result["OrderDate"]),
                            UserId = Convert.ToInt16(result["UserId"]),
                            user = result["CreatedBy"].ToString(),
                            discounttype = Convert.ToInt16(result["DiscountType"]),
                            CostPrice = Convert.ToDecimal(result["Cost"]),
                            ItemDiscount = Convert.ToDecimal(result["ItemDiscount"]),
                            Newexpr = Convert.ToDateTime(result["NewExpiry"]),
                            note = result["Note"].ToString(),
                            ItemNumber = result["ItemNumber"] == DBNull.Value ? string.Empty : result["ItemNumber"].ToString(),
                            BarcodeID = Convert.ToInt32(result["BarcodeID"])

                        });


                    }

                }
                return OrderInfoList;

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

        #region ModifyPerformInvoice
        public bool ModifyPerformInvoice(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[2];
            try
            {
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.OrderInvoiceNo);
                param[1] = new SqlParameter("@InvoiceFlag", "PERFORMA");
                if (SQLHelper.Instance.ExecuteNonQuery(SPModifyPerformInvoice, param) > 0)
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

        #region GetMaxOrderInvNo
        public long GetMaxOrderInvNo()
        {
            long OrderInvoiceNo = 1;
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT MaxId FROM KeySequence WHERE TableId=17", param);
                if (result.Read())
                {

                    OrderInvoiceNo = Convert.ToInt64(result["MaxId"]);

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
            return OrderInvoiceNo;
        }
        #endregion

        #region GetMinMaxOrderInvNo
        public List<long> GetMinMaxOrderInvNo()
        {
            try
            {
                List<long> lstMinMaxID = new List<long>();
                SqlParameter[] sqlParam = new SqlParameter[0];

                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT MIN(S.OrderInvoice) AS 'MinID',MAX(KS.MaxID) AS 'MaxID' FROM dbo.[Order] S ,dbo.KeySequence KS WHERE KS.TableId = 17 AND S.Remarks=2", sqlParam);
                if (result.Read())
                {
                    lstMinMaxID.Add(Convert.ToInt32(result["MinID"]));
                    lstMinMaxID.Add(Convert.ToInt32(result["MaxID"]));

                }

                return lstMinMaxID;
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

        #region GetPerformaValue
        public List<SaleObject> GetPerformaValue(SaleObject ObjSale)
        {
            try
            {
                List<SaleObject> OrderInfoList = new List<SaleObject>();
                using (SqlCommand sqlCmd = new SqlCommand(SPGetPerformaValue, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@ItemId", ObjSale.itemid);

                    if (param != null)
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddRange(param);
                    }

                    var result = sqlCmd.ExecuteReader();
                    if (result.Read())
                    {
                        OrderInfoList.Add(new SaleObject
                        {
                            ItemTotalStock = Convert.ToInt16(result["MTB_STOCK"]),

                        });

                    }

                }
                return OrderInfoList;

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

        #region GetSaleIdOfOrderInvoice
        public long GetSaleIdOfOrderInvoice(SaleObject ObjSale)
        {
            long SaleId = 1;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@OrderInvoice", ObjSale.OrderInvoiceNo);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT SaleID FROM [Order] WHERE OrderInvoice=@OrderInvoice AND Remarks=2", param);
                if (result.Read())
                {

                    SaleId = Convert.ToInt64(result["SaleID"] != DBNull.Value ? result["SaleID"] : 0);

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
            return SaleId;
        }
        #endregion

        #region SaveMovetoSales
        public bool SaveMovetoSales(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[34];
            try
            {
                param[0] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[1] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[2] = new SqlParameter("@AccountID", objSaleObject.accountid);
                param[3] = new SqlParameter("@SaleInvoice", objSaleObject.saleid);
                param[4] = new SqlParameter("@SaleDate", objSaleObject.invoicetime);
                param[5] = new SqlParameter("@Balance", float.Parse("0.0"));
                param[6] = new SqlParameter("@Tax", decimal.Parse("0.0"));
                param[7] = new SqlParameter("@Gross", objSaleObject.gross);
                param[8] = new SqlParameter("@Discount", objSaleObject.discount);
                param[9] = new SqlParameter("@NetAmount", objSaleObject.netamount);
                param[10] = new SqlParameter("@CreatedDate", DateTime.Now);
                param[11] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[12] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[13] = new SqlParameter("@ModifiedBy", objSaleObject.createdby);
                param[14] = new SqlParameter("@Status", objSaleObject.Status);
                param[15] = new SqlParameter("@SaleType", objSaleObject.SaleType);
                param[16] = new SqlParameter("@OrderNo", Convert.ToInt64(0));
                param[17] = new SqlParameter("@SaleDetailID", 1);
                param[18] = new SqlParameter("@BatchID", 1);
                param[19] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[20] = new SqlParameter("@Quantity", objSaleObject.quantity);
                param[21] = new SqlParameter("@Price", objSaleObject.price);
                param[22] = new SqlParameter("@ReturnQuantity", Convert.ToInt64(0));
                param[23] = new SqlParameter("@ExpiryDate", objSaleObject.ItemExpiryDate);
                param[24] = new SqlParameter("@ItemType", Convert.ToInt16(PosItemType.RegularItem));
                param[25] = new SqlParameter("@Cost", objSaleObject.ItemCostPer);
                param[26] = new SqlParameter("@ItemSerialNo", objSaleObject.SerialNo);
                param[27] = new SqlParameter("@ItemDiscount", objSaleObject.ItemDiscount);
                param[28] = new SqlParameter("@DiscountType", objSaleObject.discounttype);
                param[29] = new SqlParameter("@Year", objSaleObject.Year);
                param[30] = new SqlParameter("@YearSequenceNo", objSaleObject.YearSequenceNo);
                param[31] = new SqlParameter("@PackageQty", objSaleObject.package);
                param[32] = new SqlParameter("@Box", objSaleObject.Box);
                param[33] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveMoveToSale, param) > 0)
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

        #region UpdatePerformaInvoice
        public bool UpdatePerformaInvoice(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                param[0] = new SqlParameter("@OrderInvoiceNo", objSaleObject.OrderInvoiceNo);
                param[1] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[2] = new SqlParameter("@Status", objSaleObject.Status);

                if (SQLHelper.Instance.ExecuteNonQuery(SPUpdatePerformInvoice, param) > 0)
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

        #region GetYearSequenceForPerforma
        public List<SaleObject> GetYearSequenceForPerforma(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@InvoiceNo", objSaleObject.OrderInvoiceNo);
                param[1] = new SqlParameter("@Flag", objSaleObject.Flag);
                var result = SQLHelper.Instance.GetReader(SPGetYearSequence, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
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


        #endregion

        #region GetSaleIDwithoutPOS()
        public List<long> GetSaleID()
        {
            try
            {
                List<long> lstPOSID = new List<long>();
                SqlParameter[] sqlParam = new SqlParameter[0];

                var ReaderResult = SQLHelper.Instance.GetReader(SPGetSaleIDWithoutPOS, sqlParam);
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
        #region GetSaleIDCountwithoutPOS()
        public int GetSaleIDCount()
        {
            try
            {
                int POSIDCount = 0;
                SqlParameter[] sqlParam = new SqlParameter[0];

                var ReaderResult = SQLHelper.Instance.GetReader(SPGetSaleIDCountWithoutPOS, sqlParam);
                while (ReaderResult.Read())
                {
                    POSIDCount = Convert.ToInt32(ReaderResult["Total"]);

                }

                return POSIDCount;
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
        #region GetPackageQtyForItem
        public List<SaleObject> GetPackageQtyForItem(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                var result = SQLHelper.Instance.GetReader(SPGetPackageQTyforItem, param);
                int pack = -1;
                while (result.Read())
                {
                    if (pack != Convert.ToInt32(result["PackageQty"]) || Convert.ToInt32(result["ItemType"]) == 2)
                    {
                        lstSaleObject.Add(new SaleObject
                        {
                            BarcodeID = Convert.ToInt32(result["BarcodeID"]),
                            PackageQuantity = Convert.ToInt32(result["PackageQty"])

                        });
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
        #endregion

        #region GetPriceForPackageQty
        public decimal GetPriceForPackageQty(SaleObject ObjSale)
        {
            try
            {
                string column = "";
                column = ObjSale.ButtonClick == -1 ? "Price" : ObjSale.ButtonClick == 0 ? "WholeSalePrice" : ObjSale.ButtonClick == 2 ? "MinPrice" : "Price";
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@BarcodeID", ObjSale.BarcodeID);

                decimal Price = Convert.ToDecimal(SQLHelper.Instance.GetScalarQuery("SELECT " + column + " FROM dbo.Barcode WHERE BarcodeID=@BarcodeID", Param));
                return Price;
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

        #region GetDetailsForItem
        public List<SaleObject> GetDetailsForItem(SaleObject SalesObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            int itemid = SalesObject.itemid;
            DataSet ds = StoredProcedurers.Get_PackageItemDetails(itemid);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    SalesObject.ItemNo = Convert.ToInt32(dr["ItemID"]);
                    SalesObject.ItemName = Convert.ToInt32(dr["ItemName"]).ToString();
                    SalesObject.ItemPrice = Convert.ToDecimal(dr["Price"]);
                    SalesObject.ItemCost = Convert.ToInt32(dr["ItemCost"]);
                    SalesObject.UnitType = dr["UnitType"].ToString();
                    SalesObject.ItemPackage = Convert.ToInt32(dr["PackageQty"]);
                    SalesObject.UnitName = dr["UnitName"].ToString();
                    SalesObject.ItemExpiry = Convert.ToDateTime(dr["Expiry"]);
                    SalesObject.Select = 0;
                    //SalesObject.SerialNo = Convert.ToInt32(dr["SerialNO"]);
                    SalesObject.SerialNo = dr["SerialNO"].ToString();
                    lstSaleObject.Add(SalesObject);
                }
            }
            return lstSaleObject;

        }
        #endregion

        #region CheckDateIsExpiry
        public bool CheckDateIsExpiry(SaleObject objSaleObject)
        {
            bool Expiry = false;
            try
            {
                int num = 0;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Date", objSaleObject.expiry);
                var result = SQLHelper.Instance.GetReader(SPCheckDateIsExpired, param);
                if (result.Read())
                {
                    num = Convert.ToInt16(result[0]);
                }

                if (num == 1)
                {
                    Expiry = true;
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

            return Expiry;
        }
        #endregion

        #region GetAppliedDiscount
        public float GetAppliedDiscount(SaleObject objSaleObject)
        {
            float Discount = 0;
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@ItemType", objSaleObject.ItemType);
                param[1] = new SqlParameter("@CategoryID", objSaleObject.CategoryId);
                param[2] = new SqlParameter("@CompanyID", objSaleObject.CompanyId);

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
        #endregion

        #region GetAppliedIncrease
        public DataTable GetAppliedIncrease(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ItemType", objSaleObject.ItemType);
            param[1] = new SqlParameter("@CategoryID", objSaleObject.CategoryId);
            param[2] = new SqlParameter("@CompanyID", objSaleObject.CompanyId);
            param[3] = new SqlParameter("@ItemID", objSaleObject.itemid);
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_GetAppliedIncrease", param, "Discount");
        }
        #endregion

        #region GetExpiryBasedPackage
        public List<SaleObject> GetExpiryBasedPackage(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                var result = SQLHelper.Instance.GetReader(SPGetExpiryDateBaedOnPackage, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        ItemExpiryDate = Convert.ToDateTime(result["Expiry"]),
                        StockID = Convert.ToInt32(result["StockID"]),
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

        #region GetSerialNoBasedPackage
        public List<SaleObject> GetSerialNoBasedPackage(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[1] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                var result = SQLHelper.Instance.GetReader(SPGetSerialNoBaedOnPackage, param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {

                        StockID = Convert.ToInt64(result["StockID"]),//Added & Commented on 16-May-2014
                        SerialNo = result["SerialNo"].ToString()

                    });
                }
                result.NextResult();
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

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

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
        public bool SaveCashClientReceiptDetails(SaleObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[19];
            try
            {
                param[0] = new SqlParameter("@PayMethodID",objSaleObject.PaymentMethodID);// 101
                param[1] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[2] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                //param[3] = new SqlParameter("@BalanceAmount", objSaleObject.netamount);
                param[3] = new SqlParameter("@BalanceAmount", objSaleObject.netAmountPaymentcharges);
                param[4] = new SqlParameter("@ReceiptDate", DateTime.Now);
                // param[5] = new SqlParameter("@DateCreated", DateTime.Now);
                param[5] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                // param[7] = new SqlParameter("@DateModified", DateTime.Now);
                param[6] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[7] = new SqlParameter("@Status", objSaleObject.status);
                param[8] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[9] = new SqlParameter("@Bank", 0);
                param[10] = new SqlParameter("@Branch", 0);
                param[11] = new SqlParameter("@Discription", objSaleObject.receiptdiscription);
                param[12] = new SqlParameter("@Note", "");
                param[13] = new SqlParameter("@ReceiptFor", objSaleObject.mtbreceiptfor);
                param[14] = new SqlParameter("@DiscriptionArabic", objSaleObject.receiptdiscriptionarabic);
                param[15] = new SqlParameter("@GrossAmt", objSaleObject.receive_amtreceived);
                param[16] = new SqlParameter("@AmtReceived", objSaleObject.receive_amtreceived);
                param[17] = new SqlParameter("@ReceivedDate", DateTime.Now);
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


        }
        #region GetBalanceSheetDetails
        public List<SaleObject> GetBalanceSheetDetails(SaleObject objSaleObject)
        {

            List<SaleObject> lstBalance = new List<SaleObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@AgentID", objSaleObject.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objSaleObject.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objSaleObject.BalanceToDate;
                param[3] = new SqlParameter("@Status", objSaleObject.BalanceStatus);

                var reader = SQLHelper.Instance.GetReader(SpNameGetBalanceSheet, param);
                while (reader.Read())
                {

                    lstBalance.Add(new SaleObject
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
        //added new sp for getting balance amount 
        public decimal GetBalanceSheet(SaleObject objSaleObject)
        {
            decimal ListBalance = 0;
            //  List<SaleObject> lstBalance = new List<SaleObject>();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@AgentID", objSaleObject.BalanceAgent);
                param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                param[1].Value = objSaleObject.BalanceFromDate;
                param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                param[2].Value = objSaleObject.BalanceToDate;
                param[3] = new SqlParameter("@Status", objSaleObject.BalanceStatus);
                param[4] = new SqlParameter("@o_ListBalance", 0);
                param[4].Direction = ParameterDirection.Output;


                var reader = SQLHelper.Instance.GetReader(SpGetBalanceSheet, param);
                //while (reader.Read())
                //{

                //    lstBalance.Add(new SaleObject
                //    {

                //        AmountRecieved = Convert.ToDecimal(reader[2]),
                //        NetAmount = Convert.ToDecimal(reader[3])

                //    });

                //}
                ListBalance = Convert.ToDecimal(param[4].Value);

            }
            catch
            {
            }
            finally
            {
                Close();
            }

            return ListBalance;
        }
        public Boolean UpdateSalesDetails(SaleObject objSaleObject, int XStockInHand, decimal XPrice, int XBox, DateTime? XExpiryDate, string XSerialNo, int XBarcodeID)
        {
            SqlParameter[] param = new SqlParameter[40];

            try
            {
                param[0] = new SqlParameter("@AgentID", objSaleObject.ClientID);
                param[1] = new SqlParameter("@SaleDetailID", objSaleObject.saledetid);
                param[2] = new SqlParameter("@SaleID", objSaleObject.saleid);
                param[3] = new SqlParameter("@BatchID", objSaleObject.batchid);
                param[4] = new SqlParameter("@ItemID", objSaleObject.itemid);
                param[5] = new SqlParameter("@Quantity", objSaleObject.quantity);
                param[6] = new SqlParameter("@Price", objSaleObject.price);
                param[7] = new SqlParameter("@Discount", objSaleObject.itemdiscount);
                param[8] = new SqlParameter("@CreatedDate", objSaleObject.invoicetime);
                param[9] = new SqlParameter("@CreatedBy", objSaleObject.createdby);
                param[10] = new SqlParameter("@ModifiedDate", DateTime.Now);
                param[11] = new SqlParameter("@ModifiedBy", objSaleObject.modifiedby);
                param[12] = new SqlParameter("@Status", objSaleObject.status);
                param[13] = new SqlParameter("@SaleInvoice", objSaleObject.saleinv);
                param[14] = new SqlParameter("@Id", objSaleObject.id);
                param[15] = new SqlParameter("@ReturnQuantity", objSaleObject.ReturnQty);
                param[16] = new SqlParameter("@ExpiryDate", objSaleObject.expiry);
                param[17] = new SqlParameter("@Cost", objSaleObject.ItemCost);
                param[18] = new SqlParameter("@StockInHand", objSaleObject.stock);
                param[19] = new SqlParameter("@SerialNo", objSaleObject.serialno);
                param[20] = new SqlParameter("@SecondHand", objSaleObject.secondhand);
                param[21] = new SqlParameter("@NonStock", objSaleObject.nonstocklabourmeal);
                param[22] = new SqlParameter("@ActualPrice", objSaleObject.ActualPrice);
                param[23] = new SqlParameter("@Total", objSaleObject.total);
                param[24] = new SqlParameter("@Net", objSaleObject.net);
                param[25] = new SqlParameter("@taxofitem", objSaleObject.taxofitem);
                param[26] = new SqlParameter("@PackageQty", objSaleObject.package);
                param[27] = new SqlParameter("@ItemTax2", objSaleObject.ItemTax2);//all the code from this line Added on 19-May-2014
                param[28] = new SqlParameter("@SubTax1", objSaleObject.SubTax1);
                param[29] = new SqlParameter("@SubTax2", objSaleObject.SubTax2);
                param[30] = new SqlParameter("@ActualUnitPrice", objSaleObject.price);
                param[31] = new SqlParameter("@BarcodeID", objSaleObject.BarcodeID);
                param[32] = new SqlParameter("@Box", objSaleObject.Box);
                param[33] = new SqlParameter("@TotalAmount", objSaleObject.TotalAmount);
                param[34] = new SqlParameter("@XStockInHand", XStockInHand);
                param[35] = new SqlParameter("@XPrice", XPrice);
                param[36] = new SqlParameter("@XBox", XBox);
                param[37] = new SqlParameter("@XExpiryDate", XExpiryDate);
                param[38] = new SqlParameter("@XSerialNo", XSerialNo);
                param[39] = new SqlParameter("@XBarcodeID", XBarcodeID);
                if (SQLHelper.Instance.ExecuteNonQuery("usp_update_Sale_Det_insertion_m", param) > 0)
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

        #region GetCateComIDForItem
        /// <summary>
        /// Created on 26-Nov-2014 by Seenivasan
        /// </summary>
        /// <param name="objSaleObject"></param>
        /// <returns></returns>
        public List<SaleObject> GetCateComIDForItem(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ItemID", objSaleObject.itemid);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT CategoryID,CompanyID FROM item WHERE ItemID=@ItemID", param);
                while (result.Read())
                {
                    lstSaleObject.Add(new SaleObject
                    {
                        CategoryID = Convert.ToInt32(result["CategoryID"]),
                        CompanyID = Convert.ToInt32(result["CompanyID"])
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

        public DataTable GetSaleItem()
        {
            int stock = 0;
            if (GeneralOptionSetting.FlagShowNonStockItem != "Y")
                stock = 1;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@stock", stock);
            return SQLHelper.Instance.ExecuteQueryDatatable("Sp_Get_SaleItem", param, "Item");
        }
        #endregion


    }
}
