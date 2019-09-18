using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;
using System.Data;

namespace DataBaseHelper.DALClass
{
    public class SpendingDALClass
    {
        #region StoredProcedures
        private const string SPSaveExpensesDetails = "SP_Save_ExpensesDetails";
        private const string SPSaveDescription = "SP_Save_Description";
        #endregion

        #region Methods
        private void Close()
        { if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close(); }

        public long getMinValue()
        { return Convert.ToInt64(SQLHelper.Instance.GetScalar("select isnull(MIN(ExpensesID),0) as MinID from Expenses")); }

        //public long getMaxValue()
        //{
        //    SqlParameter[] sqlParam = new SqlParameter[1];
        //    sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Expenses);
        //    return Convert.ToInt64(SQLHelper.Instance.GetScalarQuery("select ISNULL( MaxID-1,0) from KeySequence where TableId=@TableId", sqlParam));
        //}

        public List<string> get_Description()
        {
            try
            {
                List<string> lstDescription = new List<string>();
                var result = SQLHelper.Instance.GetReader("select [Description] from [Description] order by [Description]");
                while (result.Read())
                {
                    lstDescription.Add(result[0].ToString());
                }
                return lstDescription;

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { Close(); }
        }
        public bool AddDescDB(SpendingObjectClass objSpendingObjectClass)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];
            sqlParam[0] = new SqlParameter("@Description", objSpendingObjectClass.Description);
            sqlParam[2] = new SqlParameter("@CreatedBy", objSpendingObjectClass.CreatedBy);
            sqlParam[1] = new SqlParameter("@ModifiedBy", objSpendingObjectClass.ModifiedBy);
            sqlParam[3] = new SqlParameter("@Status", objSpendingObjectClass.Status);
            if (SQLHelper.Instance.ExecuteNonQuery(SPSaveDescription, sqlParam) > 0)
            {
                return true;
            }
            else
                return false;
        }
        private List<SpendingObjectClass> getYearMaxID()
        {
            try
            {
                List<SpendingObjectClass> lstMinMax = new List<SpendingObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Expenses);
                var result = SQLHelper.Instance.GetReaderWithQuery("UPDATE dbo.KeySequence SET MaxId = MaxId + 1,YearMaxId = YearMaxId + 1 OUTPUT   INSERTED.MaxId-1 as  MaxId,INSERTED.YearMaxId-1 as YearMaxId,INSERTED.YearValue as YearValue WHERE TableId =@TableId", sqlParam);
                if (result.Read())
                {

                    lstMinMax.Add(new SpendingObjectClass
                    {
                        ExpensesID = Convert.ToInt64(result[0]),
                        YearSequence = Convert.ToInt32(result[1]),
                    });
                }
                return lstMinMax;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { Close(); }

        }

        public List<SpendingObjectClass> getExpensesTable(SpendingObjectClass objSpendingObjectClass)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@Year", objSpendingObjectClass.Year);
                sqlParam[1] = new SqlParameter("@YearSequenceNo", objSpendingObjectClass.YearSequence);
                List<SpendingObjectClass> lstExpenses = new List<SpendingObjectClass>();
                var result = SQLHelper.Instance.GetReaderWithQuery("select ExpensesID,[Description],Detail,value,ProcessDate,[Status],Notes,[Year],YearSequenceNo from Expenses where [Year]=@Year and YearSequenceNo=@YearSequenceNo", sqlParam);
                if (result.Read())
                {
                    lstExpenses.Add(new SpendingObjectClass
                    {
                        ExpensesID = Convert.ToInt64(result["ExpensesID"]),
                        Description = result["Description"].ToString(),
                        Details = result["Detail"].ToString(),
                        Value = Convert.ToDecimal(result["value"].ToString()),
                        CreatedDate = Convert.ToDateTime(result["ProcessDate"]),
                        Status = Convert.ToInt16(result["Status"]),
                        Notes = result["Notes"].ToString(),
                        Year = Convert.ToInt16(result["Year"]),
                        YearSequence = Convert.ToInt64(result["YearSequenceNo"]),
                    });
                }
                return lstExpenses;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { Close(); }

        }

        //public List<SpendingObjectClass> GetRecordById(SpendingObjectClass objSpendingObjectClass)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlParam = new SqlParameter[1];
        //        sqlParam[0] = new SqlParameter("@ExpensesID", objSpendingObjectClass.ExpensesID);
        //        List<SpendingObjectClass> lstExpenses = new List<SpendingObjectClass>();
        //        var result = SQLHelper.Instance.GetReaderWithQuery("select ExpensesID,[Description],Detail,value,ProcessDate,[Status],Notes,[Year],YearSequenceNo from Expenses where ExpensesID=@ExpensesID ", sqlParam);
        //        if (result.Read())
        //        {
        //            lstExpenses.Add(new SpendingObjectClass
        //            {
        //                ExpensesID = Convert.ToInt64(result["ExpensesID"]),
        //                Description = result["Description"].ToString(),
        //                Details = result["Detail"].ToString(),
        //                Value = Convert.ToDecimal(result["value"].ToString()),
        //                CreatedDate = Convert.ToDateTime(result["ProcessDate"]),
        //                Status = Convert.ToInt16(result["Status"]),
        //                Notes = result["Notes"].ToString(),
        //                Year = Convert.ToInt16(result["Year"]),
        //                YearSequence = Convert.ToInt64(result["YearSequenceNo"]),
        //            });
        //        }
        //        return lstExpenses;
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    finally
        //    { Close(); }
        //}
        public bool saveSpendings(SpendingObjectClass objSpendingObjectClass)
        {
            try
            {
                SqlParameter[] sqlParam = new SqlParameter[9];
                sqlParam[0] = new SqlParameter("@ExpensesID", objSpendingObjectClass.ExpensesID);
                sqlParam[1] = new SqlParameter("@Description", objSpendingObjectClass.Description);
                sqlParam[2] = new SqlParameter("@Detail", objSpendingObjectClass.Details);
                sqlParam[3] = new SqlParameter("@Notes", objSpendingObjectClass.Notes);
                sqlParam[4] = new SqlParameter("@value", objSpendingObjectClass.Value);
                sqlParam[5] = new SqlParameter("@ProcessDate", objSpendingObjectClass.ProcessDate);
                sqlParam[6] = new SqlParameter("@CreatedBy", objSpendingObjectClass.CreatedBy);
                sqlParam[7] = new SqlParameter("@Status", objSpendingObjectClass.Status);
                sqlParam[8] = new SqlParameter("@REMOVE", objSpendingObjectClass.Remove);
                if (SQLHelper.Instance.ExecuteNonQuery(SPSaveExpensesDetails, sqlParam) > 0)
                {
                       
                    return true;
                }
               
                    return false;
                
            }
            catch (Exception ex)
            { throw ex; }
        }

        public bool deleteInDB(SpendingObjectClass objSpendingObjectClass)
        {
            SqlParameter[] sqlParam = new SqlParameter[3];
            sqlParam[0] = new SqlParameter("@ExpensesID", objSpendingObjectClass.ExpensesID);
            sqlParam[1] = new SqlParameter("@CreatedBy", objSpendingObjectClass.CreatedBy);
            sqlParam[2] = new SqlParameter("@Status", objSpendingObjectClass.Status);
            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("UPDATE dbo.Expenses SET ModifiedDate = GETDATE(),ModifiedBy = @CreatedBy,[Status] =@Status WHERE ExpensesID = @ExpensesID", sqlParam) > 0)
                return true;
            else
                return false;
        }

        public List<SpendingObjectClass> getMaxRecptIDWithYear(SpendingObjectClass objSpendingObjectClass)
        {
            try
            {
                List<SpendingObjectClass> lstReceiptWithYear = new List<SpendingObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", objSpendingObjectClass.TableID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select ISNULL(MaxId,0) as MaxID,YearValue from KeySequence where TableId=@TableId", sqlParam);
                if (ReaderResult.Read())
                {
                    lstReceiptWithYear.Add(new SpendingObjectClass { ExpensesID = Convert.ToInt64(ReaderResult["MaxID"]), Year = Convert.ToInt32(ReaderResult["YearValue"]) });

                }
                return lstReceiptWithYear;
            }
            catch
            { throw; }
            finally
            { Close(); }
        }

        //public bool FetchLastRecord(out  List<SpendingObjectClass> lstLastRecord)
        //{
        //    try
        //    {
        //        lstLastRecord = new List<SpendingObjectClass>();
        //        SqlParameter[] sqlParam = new SqlParameter[1];
        //        sqlParam[0] = new SqlParameter("@TableId", CommonHelper.Table.Expenses);
        //        var ReaderResult = SQLHelper.Instance.GetReaderWithQuery(" select top(1) ExpensesID,[Description],Detail,value,ProcessDate,[Status],Notes,[Year],YearSequenceNo from Expenses order by ExpensesID desc", sqlParam);
        //        if (ReaderResult.Read())
        //        {
        //            lstLastRecord.Add(new SpendingObjectClass
        //                           {
        //                               ExpensesID = Convert.ToInt64(ReaderResult["ExpensesID"]),
        //                               Description = ReaderResult["Description"].ToString(),
        //                               Details = ReaderResult["Detail"].ToString(),
        //                               Value = Convert.ToDecimal(ReaderResult["value"].ToString()),
        //                               CreatedDate = Convert.ToDateTime(ReaderResult["ProcessDate"]),
        //                               Status = Convert.ToInt16(ReaderResult["Status"]),
        //                               Notes = ReaderResult["Notes"].ToString(),
        //                               Year = Convert.ToInt16(ReaderResult["Year"]),
        //                               YearSequence = Convert.ToInt64(ReaderResult["YearSequenceNo"]),
        //                           });
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //    finally
        //    { Close(); }
        //}
        #endregion






        public List<SpendingObjectClass> Get_MaxIdOfSpendingRecord()
        {
            List<SpendingObjectClass> LoadSpendingList = new List<SpendingObjectClass>();
            try
            {
                string Query = "Select * From KeySequence Where TableId=5";
                var result = SQLHelper.Instance.GetReader(Query);
              
                while (result.Read())
                {
                    LoadSpendingList.Add(new SpendingObjectClass
                    {
                        ExpensesID = Convert.ToInt32(result["MaxId"]),

                        Year = Convert.ToInt32(result["YearValue"]),
                        YearSequence = Convert.ToInt32(result["YearMaxId"]),

                    });
                }
                return LoadSpendingList;
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

        public List<SpendingObjectClass> Get_SpendingRecord(SpendingObjectClass objSpending)
        {
            List<SpendingObjectClass> List_SpendingRecord = new List<SpendingObjectClass>();
            try
            {
                 List<SpendingObjectClass> List = new List<SpendingObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@ExpensesId", objSpending.ExpensesID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select * from Expenses where ExpensesID=@ExpensesId", sqlParam);
                if (ReaderResult.Read())
                {
                    List.Add(new SpendingObjectClass { 
                       Description=ReaderResult["Description"].ToString(),
                       Details=ReaderResult["Detail"].ToString(),
                       Notes=ReaderResult["Notes"].ToString(),
                       Value=Convert.ToDecimal(ReaderResult["value"]),
                       ProcessDate=(Convert.ToDateTime(ReaderResult["ProcessDate"] == DBNull.Value ? null : ReaderResult["ProcessDate"]))  ,
                       Year=Convert.ToInt32( ReaderResult["Year"]),
                       YearSequence=Convert.ToInt32( ReaderResult["YearSequenceNo"]),
                       Status=Convert.ToInt16( ReaderResult["Status"]),
                       ExpensesID=Convert.ToInt32(  ReaderResult["ExpensesID"]),
                       CreatedBy=Convert.ToInt32(ReaderResult["CreatedBy"]),
                       ModifiedBy=Convert.ToInt32(ReaderResult["ModifiedBy"])
                      

                });
                
            }
                return List;
            

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
        public DataTable Get_ExpensesPrintdetails(SpendingObjectClass spendingobject)
        {

            try
            {

                SqlParameter[] Param = new SqlParameter[4];
                Param[0] = new SqlParameter("@ReceiptNo", spendingobject.ExpensesID);
                Param[1] = new SqlParameter("@UserID", 0);
                Param[2] = new SqlParameter("@StartDate", (object )null );
                Param[3] = new SqlParameter("@EndDate", (object )null );
               
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_ExpensesDetailList", Param, "Spending");
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


    }
}
