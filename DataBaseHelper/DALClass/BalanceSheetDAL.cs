using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ObjectHelper;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class BalanceSheetDAL
    {
        #region StoredProcedures
        private const string SPBalanceSheet = "SP_Get_BalanceSheet";
        #endregion

        #region ReaderCloseMethod
        private void Close()
        { if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close(); }
        #endregion

        #region -- Methods---

        public int getCurrentYear()
        {
            SqlParameter[] sqlParam = new SqlParameter[0];
            object YearValue = SQLHelper.Instance.GetScalarQuery("select YearValue from KeySequence where TableId=2", sqlParam);
            return Convert.ToInt32(YearValue == DBNull.Value ? "0" : YearValue);
        }

        public DataTable getBalanceSheet(BalanceSheetObjcetClass objBalanceSheetObjcetClass)
        {
            try
            {
                DataTable dt = new DataTable();
                //List<BalanceSheetObjcetClass> lstBalanceData = new List<BalanceSheetObjcetClass>();
                SqlParameter[] sqlparam = new SqlParameter[4];
                sqlparam[0] = new SqlParameter("@AgentID", objBalanceSheetObjcetClass.AgentID);
                sqlparam[1] = new SqlParameter("@FromDate", objBalanceSheetObjcetClass.BalanceFromDate);
                sqlparam[2] = new SqlParameter("@ToDate", objBalanceSheetObjcetClass.BalanceToDate);
                sqlparam[3] = new SqlParameter("@Status", objBalanceSheetObjcetClass.Status);
                dt = SQLHelper.Instance.ExecuteQueryDatatable(SPBalanceSheet, sqlparam, "");
                ////dynamic ReaderResult = SQLHelper.Instance.GetReader(SPBalanceSheet, sqlparam);
                ////while (ReaderResult.Read())
                ////{
                ////    lstBalanceData.Add(new BalanceSheetObjcetClass
                ////    {
                ////        ProcessDate = Convert.ToDateTime(ReaderResult["PurchaseDate"].ToString().Length == 0 ? null : ReaderResult["PurchaseDate"]),
                ////        YearSquenceNo = ReaderResult["NewYearNo"].ToString(),
                ////        AmountReceived = Convert.ToDecimal(ReaderResult["AmtReceived"]),
                ////        AmountPaid = Convert.ToDecimal(ReaderResult["NetAmount"]),
                ////        Year = Convert.ToInt32(ReaderResult["Year"]),
                ////        Description = ((string)ReaderResult["Description"]),
                ////        Discount = Convert.ToDecimal(ReaderResult["Discount"])
                ////    });
                ////}
                return dt;
            }
            catch
            { throw; }
            finally { Close(); }
        }

        public DataTable getBalanceSheetTotal(BalanceSheetObjcetClass objBalanceSheetObjcetClass)
        {
            try
            {
                DataTable dt = new DataTable();
                //List<BalanceSheetObjcetClass> lstBalanceData = new List<BalanceSheetObjcetClass>();
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@AgentID", objBalanceSheetObjcetClass.AgentID);
                dt = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_BalanceSheetTotals", sqlparam, "");
                return dt;
            }
            catch
            { throw; }
            finally { Close(); }
        }
        #endregion
        //public long   Get_SaleID(BalanceSheetObjcetClass objBalanceSheetObjcetClass)
        //{
        //    //try
        //    //{
        //    //    SqlParameter[] sqlParam = new SqlParameter[2];
        //    //      sqlParam[0] = new SqlParameter("@ID", objBalanceSheetObjcetClass.saleyearsequenceid );
        //    //    sqlParam[1] = new SqlParameter("@Year", objBalanceSheetObjcetClass.saleyear );

        //    //return  Convert.ToInt32( SQLHelper.Instance.GetScalarQuery("select SaleID from sales where YearSequenceNo=@ID and Year =@Year", sqlParam));
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    throw ex;
        //    //}

        //    return null;
        // }

        public static DataTable Get_AllAgentNames()
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@FLAG", "ALL");
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_ActiveAgents", sqlparam, "Details");
                return (dtLocal);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static bool Save_AgentDebt(BalanceSheetObjcetClass ObjBalance)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[10];
                sqlparam[0] = new SqlParameter("@AgentID", ObjBalance.AgentID);
                sqlparam[1] = new SqlParameter("@Payable", ObjBalance.AmountPaid);
                sqlparam[2] = new SqlParameter("@Receivable", ObjBalance.AmountReceived);
                sqlparam[3] = new SqlParameter("@Discount", ObjBalance.Discount);
                sqlparam[4] = new SqlParameter("@Balance", ObjBalance.Balance);
                sqlparam[5] = new SqlParameter("@Description", ObjBalance.Description);
                sqlparam[6] = new SqlParameter("@Date", ObjBalance.ProcessDate);
                sqlparam[7] = new SqlParameter("@CreatedBy", CommonHelper.GeneralFunction.UserId);
                sqlparam[8] = new SqlParameter("@ModifiedBy", CommonHelper.GeneralFunction.UserId);
                sqlparam[9] = new SqlParameter("@Status", ObjBalance.Status);
                return SQLHelper.Instance.ExecuteNonQuery("SP_Save_AgentDebt", sqlparam) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
