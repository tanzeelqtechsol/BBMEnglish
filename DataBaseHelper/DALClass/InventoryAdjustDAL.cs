using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DataBaseHelper.DALClass
{
    public class InventoryAdjustDAL
    {
        #region Procedures
        private const string SPNAMEINVENTORYADJUSTLOAD = "SP_Get_InventoryAdjustItemList_All";
        private const string SPNameUpdateInventoryAdjustmentDetails = "SP_Update_InventoryAdjustmentDetails";
        private const string SPGetStkAdjustMaxNYNo = "SP_Get_StockAdjustment_MaxNYNo";
        private const string SP_Get_InventoryItemList_ByInvoiceNO = "SP_Get_InventoryAdjust_ByInvoiceNO_Extended";
        private const string Sppayablereceivable = "Sp_payable_receivable";

        public List<InventAdjustObjectClass> InvAdjListDal = new List<InventAdjustObjectClass>();
        public List<InventAdjustObjectClass> InvAdjListInvNo_DAL = new List<InventAdjustObjectClass>();
        int m = 0;
        //Dictionary<string, List<InventAdjustObjectClass>> InvAdjDictDal = new Dictionary<string, List<InventAdjustObjectClass>>();
        #endregion
        public List<InventAdjustObjectClass> InventoryAdjustmentload(InventAdjustObjectClass objInvAdjObect)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(SPNAMEINVENTORYADJUSTLOAD, param);
                decimal BeforAdjust = 0, adjustdiffer = 0;
                int i = 0;
                decimal pack;
                InvAdjListDal.Clear();
                while (result.Read())
                {
                    if ((result["PackageQty"] == DBNull.Value ? 0 : Convert.ToDecimal(result["PackageQty"])) == 0)
                    {
                        pack = 1;
                    }
                    else
                    {
                        pack = Convert.ToDecimal(result["PackageQty"]);
                    }
                    //if ((result["PackageQty"] == DBNull.Value ? 0 : Convert.ToDecimal(result["PackageQty"])) > 0 & Convert.ToDecimal(result["Cost"]) > 0)
                    //{
                    BeforAdjust = Convert.ToDecimal(result["Cost"].ToString()) / pack * ((result["StockInHand"] != string.Empty && result["StockInHand"] != null) ? Convert.ToDecimal(result["StockInHand"].ToString()) : 0);
                    adjustdiffer = (Convert.ToDecimal(result["Cost"]) / pack) * ((result["StockInHand"] != null && result["StockInHand"] != string.Empty) ? Convert.ToInt32(result["StockInHand"]) : 0);
                    //}
                    InvAdjListDal.Add(new InventAdjustObjectClass
                    {
                        RowIndex = i++,

                        ItemId = Convert.ToInt32(result["ItemID"]),
                        ItemName = result["ItemName"].ToString(),
                        //Expired = Convert.ToBoolean((result["Expired"] == DBNull.Value ? null : result["Expired"])),
                        Quantity = Convert.ToInt32(result["Quantity"]),
                        Quantity1 = result["Quantity"].ToString(),

                        Cost = Convert.ToDecimal(result["Cost"]),
                        ModifiedCost = Convert.ToDecimal(result["ModifiedCost"]),
                        OldCost = Convert.ToDecimal(result["OldCost"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        Description = result["ItemDescription"].ToString(),
                        Unit = result["Unit"] == DBNull.Value ? 0 : Convert.ToInt32(result["Unit"]),
                        Users = result["Users"].ToString(),
                        ItemLastCost = Convert.ToDecimal(result["ItemLastCost"]),
                        PackageQty = pack,
                        //       Reorder = Convert.ToInt32(result["Reorder"]),
                        WholeSalePrice = result["WholeSalePrice"] == DBNull.Value ? 0 : Convert.ToDecimal(result["WholeSalePrice"]),
                        AverageCost = Convert.ToDecimal(result["AverageCost"] == DBNull.Value ? null : result["AverageCost"]),
                        Price = result["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(result["Price"]),
                        Maxorder = Convert.ToInt32(result["MaxOrder"]),
                        MinPrice = result["MinPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(result["MinPrice"]),
                        StockInHand = (result["StockInHand"] != null && result["StockInHand"] != string.Empty) ? Convert.ToInt32(result["StockInHand"]) : 0,
                        StockID = Convert.ToInt32(result["ID"]),
                        GridID = Convert.ToInt32(result["ID"]),
                        Adjustment = Convert.ToInt32(result["Adjustment"]),
                        ExpiryDate = result["ExpiryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["ExpiryDate"]),
                        StrExpiryDate = result["ExpiryDate"] == DBNull.Value ? string.Empty : Convert.ToDateTime(result["ExpiryDate"]).ToShortDateString(),
                        SerialNo = result["SerialNo"].ToString(),
                        Reason = result["Reason"].ToString(),
                        Edit = result["Edit"].ToString(),
                        ModifiedQty = Convert.ToInt32(result["modifiedqty"]),

                        CategoryId = Convert.ToInt32(result["CategoryID"]),
                        CompanyId = Convert.ToInt32(result["CompanyID"]),
                        CategoryName = result["CategoryName"].ToString(),
                        CompanyName = result["CompanyName"].ToString(),
                        PlaceName = result["Reason"].ToString(),
                        QtyAdjust = Convert.ToInt32(result["QtyAdjust"]),
                        TotalPurchased = Convert.ToInt32(result["TotalPurchased"]),
                        TotalSold = Convert.ToInt32(result["TotalSold"]),
                        Spoiled = Convert.ToInt32(result["Spoiled"]),
                        BeforeAdjust = Convert.ToDecimal(BeforAdjust.ToString("0.000")),
                        AdjustDiffer = Convert.ToDecimal(adjustdiffer.ToString("0.000")),
                        ItemNumber = result["ItemNumber"].ToString(),
                        IsHide = Convert.ToInt32(result["IsHide"])

                    });
                }
            }

            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return InvAdjListDal;
        }

        public List<InventAdjustObjectClass> InventAdjust_InvoiceNoDAL(InventAdjustObjectClass objInvAdjObect)
        {
            try
            {
                //CommonHelper.GeneralFunction.Trace("Start");
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@InvoiceNo", objInvAdjObect.StockInvoiceNo);
                var result = SQLHelper.Instance.GetReader(SP_Get_InventoryItemList_ByInvoiceNO, param);
                decimal BeforAdjust = 0;
                int i = 0;
                InvAdjListInvNo_DAL.Clear();
              
                while (result.Read())
                {

                    var costValue = Convert.ToDecimal(result["Cost"].ToString());
                    var packValue = Convert.ToInt32(result["Pack"] == DBNull.Value || (Convert.ToInt32(result["Pack"]) == 0) ? 1 : result["Pack"]);
                    var currentQty = (result["CurrentQty"] != null ? Convert.ToDecimal(result["CurrentQty"].ToString()) : 0);
                    BeforAdjust = costValue / packValue * currentQty;

                    InvAdjListInvNo_DAL.Add(new InventAdjustObjectClass
                     {
                         RowIndex = i++,
                         BatchID = Convert.ToInt32(result["BatchID"]),
                         InvNo = Convert.ToInt32(result["InvoiceNo"]),
                         AdjustedDate = result["DateAdjusted"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["DateAdjusted"]),
                         Description = result["Description"].ToString(),
                         ModifiedDate = result["ModifiedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["ModifiedDate"]),
                         ItemId = Convert.ToInt32(result["ItemID"]),
                         ItemName = result["ItemName"].ToString(),
                         Flag = Convert.ToInt32(result["Flag"]),
                         Status = Convert.ToInt32(result["Status"]),
                         Notes = result["Notes"].ToString(),
                         ExpiryDate = result["ExpiryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result["ExpiryDate"]),
                         Quantity = Convert.ToInt32(result["Quantity"]),
                         Cost = costValue,
                         TotalPurchased = Convert.ToInt32(result["TotalPurchased"]),
                         TotalSold = Convert.ToInt32(result["TotalSold"]),
                         Spoiled = Convert.ToInt32(result["Spoiled"]),
                         CurrentQty = Convert.ToInt32(result["CurrentQty"]),
                         Adjustment = Convert.ToInt32(result["Adjustment"]),
                         Reason = result["Reason"].ToString(),
                         SerialNo = result["SerialNo"].ToString(),
                         Users = result["User"].ToString(),
                         OldCost = Convert.ToDecimal(result["OldCost"]),
                         ItemType = Convert.ToInt32(result["Type"]),
                         GridID = Convert.ToInt32(result["GridID"]),
                         Edit = result["Edit"].ToString(),
                         PackageQty = packValue,
                         AfterAdjValue = result["AfterAdjustment"] == DBNull.Value ? 0 : Convert.ToDecimal(result["AfterAdjustment"]),
                         Original = result["Original"] == DBNull.Value ? 0 : Convert.ToDecimal(result["Original"]),
                         BeforeAdjust = Convert.ToDecimal(BeforAdjust.ToString("0.000")),
                         //  AdjustDiffer = Convert.ToDecimal(adjustdiffer.ToString("0.000")),
                         //BeforeAdjust = Convert.ToDecimal(result["Original"]),
                         //AdjustDiffer = Convert.ToDecimal(result["AfterAdjustment"])
                     });
                }
                //CommonHelper.GeneralFunction.Trace("End");
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return InvAdjListInvNo_DAL;
        }
        public bool UpdateInventoryAdjustmentDetailsDAL(InventAdjustObjectClass ObjInventProp)
        {
            int i;
            try
            {
                SqlParameter[] Param = new SqlParameter[23];
                Param[0] = new SqlParameter("@ItemID", ObjInventProp.ItemId);
                Param[1] = new SqlParameter("@ItemCost", ObjInventProp.Cost);
                Param[2] = new SqlParameter("@StockInHand", ObjInventProp.Quantity);
                Param[3] = new SqlParameter("@ExpiryDate", ObjInventProp.ExpiryDate);
                Param[4] = new SqlParameter("@DateAdjusted", ObjInventProp.CreatedDate);
                Param[5] = new SqlParameter("@AdjustQty", ObjInventProp.Adjustment);
                Param[6] = new SqlParameter("@Reasons", ObjInventProp.Reason);
                Param[7] = new SqlParameter("@Description", ObjInventProp.Description);
                Param[8] = new SqlParameter("@ModifiedDate", ObjInventProp.CreatedDate);
                Param[9] = new SqlParameter("@ModifiedBy", ObjInventProp.CreatedBY);
                Param[10] = new SqlParameter("@AdjustCost", ObjInventProp.OldCost);
                Param[11] = new SqlParameter("@InvoiceNo", ObjInventProp.TblID);
                Param[12] = new SqlParameter("@OldQuantity", ObjInventProp.Quantity);
                Param[13] = new SqlParameter("@OldCost", ObjInventProp.OldCost);
                Param[14] = new SqlParameter("@TotalPurchased", ObjInventProp.TotalPurchased);
                Param[15] = new SqlParameter("@TotalSold", ObjInventProp.TotalSold);
                Param[16] = new SqlParameter("@Spoiled", ObjInventProp.Spoiled);
                Param[17] = new SqlParameter("@SerialNo", ObjInventProp.SerialNo);
                Param[18] = new SqlParameter("@ID", ObjInventProp.GridID);
                Param[19] = new SqlParameter("@Edit", ObjInventProp.Edit);
                Param[20] = new SqlParameter("@Notes", ObjInventProp.Notes);
                Param[21] = new SqlParameter("@TextInventory", ObjInventProp.TextInventory);
                Param[22] = new SqlParameter("@YearSequenceNo", ObjInventProp.NewYearNo);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameUpdateInventoryAdjustmentDetails, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }

        }
        #region GetCurrentYear()
        public int GetCurrentYear()
        {
            try
            {
                int CurrentYear = 0;
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.StockAdjustment);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select YearValue from KeySequence where TableId=@TableId", sqlParam);
                if (ReaderResult.Read())
                {
                    CurrentYear = Convert.ToInt32(ReaderResult["YearValue"]);
                }
                return CurrentYear;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        #endregion
        public int Get_Invoice_NewYearNo(InventAdjustObjectClass obj)
        {
            try
            {
                int NewYearNo = 0;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@InvoiceNo", obj.InvNo);
                param[1] = new SqlParameter("@Status", obj.Status);
                var result = SQLHelper.Instance.GetReader(SPGetStkAdjustMaxNYNo, param);
                if (result.Read())
                {
                    NewYearNo = Convert.ToInt32(result["YearValue"]);
                }
                return NewYearNo;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public DataSet Get_PayableReceivable()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[0];
                ds = SQLHelper.Instance.ExecuteQueryDataset("usp_Reports_ZakatCalculationReport", param, "Mtb_Sale");
                return ds;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

    }
}
