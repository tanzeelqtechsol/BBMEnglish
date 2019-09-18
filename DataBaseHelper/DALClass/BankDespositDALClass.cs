using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;
//Modified By G.Saradhaa
namespace DataBaseHelper.DALClass
{
    public class BankDespositDALClass
    {
        //  private const string SPNameSaveBankDepositDetails = "SP_Save_BankDepositDetails";
        //    private const string SPNameGetBankBalanceAmount = "SP_Get_BankBalanceByBankID";
        //  private const string SPNameGetDepositMaxMinNumber = "SP_Get_BankAndBranchListDeposit";
        //    private const string SPNameGetBankAndBranchList = "SP_Get_BankAndBranchList";
        // private const string SPNameGetDrawBankDetails = "SP_Get_DrawBankTransactionDetails";
        //  private const string SPNameGetDepoNY_MaxID = "SP_Get_BankAndBranchList_MaxNYNo";
        private const string SPNameInsertBankDepositDetails = "SP_Insert_BankDepositDetails";
        private const string SPNameDrawDeleteBankDepositDetails = "SP_DrawDelete_BankDepositDetails";
        // private const string SPGetDepositMaxMinID = "SP_Get_DepositMaxMinId";
        //   private const string SPGetDrawMaxMinID = "SP_Get_DrawMaxMinId";
        private const string SPDeleteDepositDetails = "SP_Delete_BankWithDrawDetails";
        private const string SPGetBankBalanceAmount = "SP_Get_BankBalanceByBankID";

        //  private const string SPNameGetDepositBankDetails = "SP_Get_DepositBankTransactionDetails";

        private void Close()
        { if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close(); }

        private List<BankObjectClass> getNewYearNo(Int16 TableID)
        {
            try
            {
                List<BankObjectClass> lstNewYrNo = new List<BankObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", TableID);
                var result = SQLHelper.Instance.GetReaderWithQuery("UPDATE dbo.KeySequence SET MaxId = MaxId + 1,YearMaxId = YearMaxId + 1 OUTPUT   INSERTED.MaxId-1 as  MaxId,INSERTED.YearMaxId-1 as YearMaxId,INSERTED.YearValue as YearValue WHERE TableId =@TableId", sqlParam);
                if (result.Read())
                {
                    lstNewYrNo.Add(new BankObjectClass
                                        {
                                            ReceiptNo = Convert.ToInt64(result["MaxId"]),
                                            YearSequenceNo = Convert.ToInt64(result["YearMaxId"]),
                                            //    Year = Convert.ToInt32(result["YearValue"])
                                        });
                }
                return lstNewYrNo;
            }

            catch (Exception ex)
            { throw ex; }

            finally
            { Close(); }

        }

        public long getDrawBankDetailID(BankObjectClass ObjBankObject)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[3];
                Param[0] = new SqlParameter("@ReceiptNo", ObjBankObject.ReceiptNo);
                Param[1] = new SqlParameter("@TransactionFlag", ObjBankObject.TransactionFlag);
                Param[2] = new SqlParameter("@Year", ObjBankObject.Year);
                long maxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("SELECT ISNULL(BankDetailID,0) FROM BankTransactionDetails WHERE Reason='MOVEACCOUNT' and ReceiptNo=@ReceiptNo AND TransactionFlag=@TransactionFlag and [Year]=@Year", Param));
                return maxID;
            }
            catch (Exception ex) { throw ex; }
        }
        //Pending to change the status to be received dynamically
        public bool DepositDel_BankDepositDetails(BankObjectClass ObjBankObject)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[2];
                Param[1] = new SqlParameter("@BankDetailId", ObjBankObject.BankDetailID);
                Param[0] = new SqlParameter("@ModifiedBy", ObjBankObject.ModifiedBy);
                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("update BankTransactionDetails set ModifiedDate=getdate(),ModifiedBy=@ModifiedBy,Status=0,ReasonId=0 WHERE BankDetailId=@BankDetailId", Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool DrawDel_BankDepositDetails(BankObjectClass ObjBankObject)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[2];
                Param[0] = new SqlParameter("@BankDetailId", ObjBankObject.BankDetailID);

                Param[1] = new SqlParameter("@ModifiedBy", ObjBankObject.ModifiedBy);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameDrawDeleteBankDepositDetails, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }



        public List<int> Get_MaxMinReceiptNo(BankObjectClass objBankObjectClass)
        {
            List<int> lstMinMax = new List<int>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT (isnull(min(ReceiptNo),1)) AS MinimumID,(isnull(max(ReceiptNo)+1,1)) AS MaximumID FROM BankTransactionDetails WHERE TransactionFlag=@TransactionFlag", param);
                if (result.Read())
                {
                    lstMinMax.Add(Convert.ToInt16(result[0]));
                    lstMinMax.Add(Convert.ToInt16(result[1]));
                }
                result.Close();
                return lstMinMax;
            }
            catch (Exception ex) { throw ex; }
        }

        public Dictionary<string, object> Get_TableByReceipt(BankObjectClass objBankObjectClass)
        {
            Dictionary<string, object> dicTable = new Dictionary<string, object>();
            //   List<object> lstBankDepositTable = new List<object>();
            try
            {
                SqlParameter[] Param = new SqlParameter[2];
                Param[0] = new SqlParameter("@ReceiptNo", objBankObjectClass.ReceiptNo);
                Param[1] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
                //  Param[2] = new SqlParameter("@Year", objBankObjectClass.Year);
                //    var result = SQLHelper.Instance.GetReaderWithQuery("SELECT BankDetailID,ReceiptNo,[Description],DoneBy,ReasonID,BankID,BranchID,BankToMove,BranchToMove,Amount,ProcessDate,Status,Year from BankTransactionDetails where TransactionFlag=@TransactionFlag and ReceiptNo=@ReceiptNo and [Year]=@Year", Param);
                var result = SQLHelper.Instance.GetReaderWithQuery("SELECT BankDetailID,ReceiptNo,[Description],DoneBy,ReasonID,BankID,BranchID,BankToMove,BranchToMove,Amount,ProcessDate,Status,Year from BankTransactionDetails where TransactionFlag=@TransactionFlag and ReceiptNo=@ReceiptNo", Param);
                if (result.Read())
                {
                    dicTable.Add("ID", result[0]);
                    dicTable.Add("ReceiptNo", result[1]);
                    dicTable.Add("Description", result[2]);
                    dicTable.Add("DoneBy", result[3]);
                    dicTable.Add("ReasonID", result[4]);
                    dicTable.Add("BankID", result[5]);
                    dicTable.Add("BranchID", result[6]);
                    dicTable.Add("BankToMove", result[7]);
                    dicTable.Add("BranchToMove", result[8]);
                    //  dicTable.Add("NewYearNo", result[9]);
                    dicTable.Add("Amount", result[9]);
                    dicTable.Add("ProcessDate", result[10]);
                    dicTable.Add("Status", result[11]);
                    dicTable.Add("Year", result[12]);
                }
                //    Int32[] keys = dict.Where(kvp => kvp.Value.Equals("SomeValue")).Select(kvp => kvp.Key).ToArray();
                //  var y=  dicTable.Values.ToList().FindIndex

                //   return dictionary.OrderBy(d => d.Key).Skip(startIndex).Take(endIndex - startIndex + 1).ToDictionary(k => k.Key, v => v.Value);
                //     var y = dicTable.Where(ID => ID.Value.Equals(3)).Select(dictTable => dictTable.Key);
                //       dic.GetIndex(s => s == KEY_STRING + testParam);
                //      int index =dicTable.Where(ID => ID.Value.Equals(3)).Select(dictTable => dictTable.Key));
                //    int index =dicTable.Where(ID => ID.Value.Equals(3)).Take(this).ToDictionary(t => t.Key, v => v.Value);
                //   Dictionary<string, object> dict = dicTable.Take(index).ToDictionary(t => t.Key, v => v.Value);

                //List<object> lst =new List<object>();
                //lst.Add(Convert.ToInt16(y));
                // int t = 0;
                // bool found=false;
                // var v=dicTable["ID"];
                //for(var vv in v)
                // { 
                //    if( dicTable["ID"].Equals(3))
                //    {
                //        found=true;
                //        break;
                //    }
                //        else
                //       t++;
                // }

                // if (found)
                // {
                //     Dictionary<string, object> dict = dicTable.Take(t).ToDictionary(k => k.Key, v => v.Value);
                // }
                result.Close();
            }
            catch (Exception ex) { throw ex; }

            //finally
            //{
            //    if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            //}


            return dicTable;
        }


        public List<decimal> getBankBalance(BankObjectClass ObjBankObject)
        {
            List<decimal> lstBankBalance = new List<decimal>();
            try
            {

                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = new SqlParameter("@BankID", ObjBankObject.BankNameID);
                Params[1] = new SqlParameter("@BranchID", ObjBankObject.BranchNameID);
                var result = SQLHelper.Instance.GetReader(SPGetBankBalanceAmount, Params);
                if (result.Read())
                {
                    lstBankBalance.Add(Convert.ToDecimal(result[0]));
                    lstBankBalance.Add(Convert.ToDecimal(result[1]));
                }
                result.Close();
                return lstBankBalance;
            }

            catch (Exception ex) { throw ex; }


        }

        //public DataTable Get_Bank2MoveBalance(BankObjectClass ObjBankObject)
        //{
        //    try
        //    {
        //        DataTable dtBankBalance = new DataTable();
        //        SqlParameter[] Params = new SqlParameter[2];
        //        Params[0] = new SqlParameter("@BankName", ObjBankObject.BankToMoveID);
        //        Params[1] = new SqlParameter("@BranchName", ObjBankObject.BranchToMoveID);
        //        dtBankBalance = SQLHelper.Instance.ExecuteDatatableWithQuery("SELECT isnull(sum(convert(decimal(12,3),Amount)),0) AS 'DEPOAMOUNT',(SELECT isnull(sum(convert(decimal(12,3),Amount)),0) FROM dbo.BankTransactionDetails WHERE BankID=@BankName AND BranchID=@BranchName AND TransactionFlag =2 AND status=1)AS 'DRAWAMOUNT' FROM dbo.BankTransactionDetails WHERE BankID=@BankName AND BranchID=@BranchName AND TransactionFlag  IN (1,3) AND status=1 ", Params, "BankBalance");
        //        return dtBankBalance;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public int Get_MaxNY(BankObjectClass objBankObjectClass)
        {


            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
            return Convert.ToInt16(SQLHelper.Instance.GetScalarQuery("select (isnull(max(NewYearNo )+1,1)) as NY_MaxID from BankTransactionDetails where TransactionFlag=@TransactionFlag and NewYearNo not like '%-%'", Param));

        }



        public int Insert_BankDepositDetails(BankObjectClass ObjBankObject)
        {
            try
            {
                SqlParameter[] Params = new SqlParameter[14];
                Params[0] = new SqlParameter("@ReceiptNo", ObjBankObject.ReceiptNo);
                Params[1] = new SqlParameter("@BankNameID", ObjBankObject.BankNameID);
                Params[2] = new SqlParameter("@BranchNameID", ObjBankObject.BranchNameID);
                Params[3] = new SqlParameter("@Description", ObjBankObject.Description);
                Params[4] = new SqlParameter("@DoneBy", ObjBankObject.DepositDoneBy);
                Params[5] = new SqlParameter("@Reason", ObjBankObject.Reason);
                Params[6] = new SqlParameter("@Amount", ObjBankObject.Amount);
                Params[7] = new SqlParameter("@TransactionFlag", ObjBankObject.TransactionFlag);
                Params[8] = new SqlParameter("@BankToMoveID", ObjBankObject.BankToMoveID);
                Params[9] = new SqlParameter("@BranchToMoveID", ObjBankObject.BranchToMoveID);
                Params[10] = new SqlParameter("@ProcessDate", ObjBankObject.ProcessDate);
                Params[11] = new SqlParameter("@ModifiedBy", ObjBankObject.ModifiedBy);
                Params[12] = new SqlParameter("@CreatedBy", ObjBankObject.CreatedBy);
                Params[13] = new SqlParameter("@ReasonId", ObjBankObject.ReasonId);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameInsertBankDepositDetails, Params) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }



        //  Getting Receipt with Year
        public bool getReceiptWithYear(BankObjectClass objBankObjectClass, out List<BankObjectClass> lstBankObject)
        {
            try
            {
                lstBankObject = new List<BankObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[3];
                sqlParam[0] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
                sqlParam[1] = new SqlParameter("@YearSequenceNo", objBankObjectClass.YearSequenceNo);
                sqlParam[2] = new SqlParameter("@Year", objBankObjectClass.Year);
                var readerResult = SQLHelper.Instance.GetReaderWithQuery(" SELECT BankDetailID,ReceiptNo,[Description],DoneBy,ReasonID,BankID,BranchID,BankToMove,BranchToMove,Amount,ProcessDate,[Status],[Year],YearSequenceNo,Reason from BankTransactionDetails where TransactionFlag=@TransactionFlag and YearSequenceNo=@YearSequenceNo and [Year]=@Year", sqlParam);
                if (readerResult.Read())
                {
                    lstBankObject.Add(new BankObjectClass
                                   {
                                       BankDetailID = Convert.ToInt64(readerResult["BankDetailID"]),
                                       ReceiptNo = Convert.ToInt64(readerResult["ReceiptNo"]),
                                       Description = readerResult["Description"].ToString(),
                                       DepositDoneBy = readerResult["DoneBy"].ToString(),
                                       ReasonId = Convert.ToInt32(readerResult["ReasonID"]),
                                       BankNameID = Convert.ToInt32(readerResult["BankID"]),
                                       BranchNameID = Convert.ToInt32(readerResult["BranchID"]),
                                       BankToMoveID = Convert.ToInt32(readerResult["BankToMove"]),
                                       BranchToMoveID = Convert.ToInt32(readerResult["BranchToMove"]),
                                       Amount = Convert.ToDecimal(readerResult["Amount"]),
                                       ProcessDate = Convert.ToDateTime(readerResult["ProcessDate"]),
                                       Status = Convert.ToInt16(readerResult["Status"]),
                                       Year = Convert.ToInt32(readerResult["Year"]),
                                       YearSequenceNo = Convert.ToInt64(readerResult["YearSequenceNo"]),
                                       Reason =readerResult ["Reason"].ToString()
                                   });
                    return true;
                }
                return false;
            }
            catch { throw; }
            finally
            {
                Close();
            }
        }

        public bool getRecordByReceiptID(BankObjectClass objBankObjectClass, out List<BankObjectClass> lstBankObject)
        {
            try
            {
                lstBankObject = new List<BankObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[2];
                sqlParam[0] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
                sqlParam[1] = new SqlParameter("@ReceiptNo", objBankObjectClass.ReceiptNo);
                var readerResult = SQLHelper.Instance.GetReaderWithQuery("SELECT BankDetailID,ReceiptNo,[Description],DoneBy,ReasonID,BankID,BranchID,BankToMove,BranchToMove,Amount,ProcessDate,[Status],Year,YearSequenceNo,Reason from BankTransactionDetails where TransactionFlag=@TransactionFlag and ReceiptNo=@ReceiptNo ", sqlParam);
                if (readerResult.Read())
                {
                    lstBankObject.Add(new BankObjectClass
                    {
                        BankDetailID = Convert.ToInt64(readerResult["BankDetailID"]),
                        ReceiptNo = Convert.ToInt64(readerResult["ReceiptNo"]),
                        Description = readerResult["Description"].ToString(),
                        DepositDoneBy = readerResult["DoneBy"].ToString(),
                        ReasonId = Convert.ToInt32(readerResult["ReasonID"]),
                        BankNameID = Convert.ToInt32(readerResult["BankID"]),
                        BranchNameID = Convert.ToInt32(readerResult["BranchID"]),
                        BankToMoveID = Convert.ToInt32(readerResult["BankToMove"]),
                        BranchToMoveID = Convert.ToInt32(readerResult["BranchToMove"]),
                        Amount = Convert.ToDecimal(readerResult["Amount"]),
                        ProcessDate = Convert.ToDateTime(readerResult["ProcessDate"]),
                        Status = Convert.ToInt16(readerResult["Status"]),
                        Year = Convert.ToInt32(readerResult["Year"]),
                        YearSequenceNo = Convert.ToInt64(readerResult["YearSequenceNo"]),
                        Reason = readerResult["Reason"].ToString(),
                        
                       
                       
                        
                    });
                    return true;
                }
                return false;
            }
            catch { throw; }
            finally
            {
                Close();
            }
        }

        // Getting Maximum ID
        //public long getMaximumRecptID(BankObjectClass objBankObjectClass)
        //{
        //    SqlParameter[] sqlParam = new SqlParameter[1];
        //    sqlParam[0] = new SqlParameter("@TableId", objBankObjectClass.TableID);
        //    return Convert.ToInt64(SQLHelper.Instance.GetScalarQuery("select ISNULL(YearMaxId-1,0) from KeySequence where TableId=@TableId", sqlParam));
        //}

        public long getMaximumRecptID(BankObjectClass objBankObjectClass)
        {
            SqlParameter[] sqlParam = new SqlParameter[1];
            sqlParam[0] = new SqlParameter("@TableId", objBankObjectClass.TableID);
            return Convert.ToInt64(SQLHelper.Instance.GetScalarQuery("select ISNULL(MaxId-1,0) as MaxID from KeySequence where TableId=@TableId", sqlParam));
        }

        //public long getMaximumRecptID(BankObjectClass objBankObjectClass)
        //{
        //    SqlParameter[] sqlParam = new SqlParameter[1];
        //    sqlParam[0] = new SqlParameter("@TableId", objBankObjectClass.TableID);
        //    return Convert.ToInt64(SQLHelper.Instance.GetScalarQuery("select ISNULL(MaxId-1,0) as MaxID from KeySequence where TableId=@TableId", sqlParam));
        //}

        public List<BankObjectClass> getMaxRecptIDWithYear(BankObjectClass objBankObjectClass)
        {
            try
            {
                List<BankObjectClass> lstReceiptWithYear = new List<BankObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TableId", objBankObjectClass.TableID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select ISNULL(MaxId,0) as MaxID,YearValue from KeySequence where TableId=@TableId", sqlParam);
                if (ReaderResult.Read())
                {
                    lstReceiptWithYear.Add(new BankObjectClass { ReceiptNo = Convert.ToInt64(ReaderResult["MaxID"]), Year = Convert.ToInt32(ReaderResult["YearValue"]) });

                }
                return lstReceiptWithYear;
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

        //Getting Minimum ID
        public int getMinRecptID(BankObjectClass objBankObjectClass)
        {
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@TransactionFlag", objBankObjectClass.TransactionFlag);
            return Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select isnull(min(ReceiptNo),0) from BankTransactionDetails where TransactionFlag=@TransactionFlag", Param));
        }

        ////////////////---------------Cash Capital--------------------//////////////////
        //Save,Delete,Minimum & maximum NO
        public bool Insert_BankTransactionDetails(BankObjectClass ObjBankObject)
        {
           
            try
            {
                SqlParameter[] Params = new SqlParameter[14];
                //  Params[0] = new SqlParameter("@ReceiptNo", ObjBankObject.ReceiptNo);
                Params[0] = new SqlParameter("@BankNameID", ObjBankObject.BankNameID);
                Params[1] = new SqlParameter("@BranchNameID", ObjBankObject.BranchNameID);
                Params[2] = new SqlParameter("@Description", ObjBankObject.Description);
                Params[3] = new SqlParameter("@DoneBy", ObjBankObject.DepositDoneBy);
                Params[4] = new SqlParameter("@Reason", ObjBankObject.Reason);
                Params[5] = new SqlParameter("@Amount", ObjBankObject.Amount);
                Params[6] = new SqlParameter("@TransactionFlag", ObjBankObject.TransactionFlag);
                Params[7] = new SqlParameter("@BankToMoveID", ObjBankObject.BankToMoveID);
                Params[8] = new SqlParameter("@BranchToMoveID", ObjBankObject.BranchToMoveID);
                Params[9] = new SqlParameter("@ProcessDate", ObjBankObject.ProcessDate);
              
                Params[10] = new SqlParameter("@CreatedBy", ObjBankObject.CreatedBy);
                Params[11] = new SqlParameter("@ReasonId", ObjBankObject.ReasonId);
                Params[12] = new SqlParameter("@Status", ObjBankObject.Status);
                Params[13] = new SqlParameter("@TableId", ObjBankObject.TableID);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameInsertBankDepositDetails, Params) > 0)
                {
                   
                    return true;
                }
                return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BankObjectClass> Get_MaxIdOfRecord(BankObjectClass bankobjectclass)
        {
            List<BankObjectClass> LoadListOfID = new List<BankObjectClass>();
            try
            {
                 SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@TypeOfTransaction",bankobjectclass.TableID);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select * from KeySequence where TableId=@TypeOfTransaction", sqlParam);
                if (ReaderResult.Read())
                {


                    LoadListOfID.Add(new BankObjectClass
                    {
                        ReceiptNo = Convert.ToInt32(ReaderResult["MaxId"]),

                        Year = Convert.ToInt32(ReaderResult["YearValue"]),
                        YearSequenceNo = Convert.ToInt32(ReaderResult["YearMaxId"]),

                    });
                }
                return LoadListOfID;
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

        public List<BankObjectClass> Get_RecordByID(BankObjectClass bankobjectclass)
        {
            try
            {
                List<BankObjectClass> List = new List<BankObjectClass>();
                SqlParameter[] sqlParam = new SqlParameter[2];

                sqlParam[0] = new SqlParameter("@ReceiptNo", bankobjectclass.ReceiptNo);
                sqlParam[1] = new SqlParameter("@TransactionFlag", bankobjectclass.TransactionFlag);
                var ReaderResult = SQLHelper.Instance.GetReaderWithQuery("select * from BankTransactionDetails where ReceiptNo=@ReceiptNo and TransactionFlag=@TransactionFlag", sqlParam);
                if (ReaderResult.Read())
                {
                    List.Add(new BankObjectClass
                    {
                        ReceiptNo=Convert.ToInt32( ReaderResult["ReceiptNo"]),
                        Description = ReaderResult["Description"].ToString(),
                        DepositDoneBy= ReaderResult["DoneBy"].ToString(),
                        Reason= ReaderResult["Reason"].ToString(),
                        Amount=Convert.ToDecimal( ReaderResult["Amount"]),
                        TransactionFlag =Convert.ToInt32( ReaderResult["TransactionFlag"]),
                         ProcessDate = (Convert.ToDateTime(ReaderResult["ProcessDate"] == DBNull.Value ? null : ReaderResult["ProcessDate"])),
                        Year = Convert.ToInt32(ReaderResult["Year"]),
                        YearSequenceNo =Convert.ToInt32( ReaderResult["YearSequenceNo"]),
                        TransactionType =Convert.ToInt32( ReaderResult["TransactionType"]),
                           Status = Convert.ToInt16(ReaderResult["Status"]),
                         CreatedBy = Convert.ToInt32(ReaderResult["CreatedBy"]),
                        ModifiedBy = Convert.ToInt32(ReaderResult["ModifiedBy"])

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
        public DataTable Get_BankWithDrawDetails(BankObjectClass bankobjectclass)
        {
            try
            {

                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ReceiptNo", bankobjectclass.ReceiptNo);
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_BankWithDrawDetails", Param, "BankWithDrawDetails");
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
        public DataTable Get_BankDepositDetails(BankObjectClass bankobjectclass)
        {
            try
            {

                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ReceiptNo", bankobjectclass.ReceiptNo);
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_BankDepositDetails", Param, "BankDepositDetails");
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
        public DataTable Get_BankCashCapital(BankObjectClass bankobjectclass)
        {
            try
            {

                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ReceiptNo", bankobjectclass.ReceiptNo);
                return SQLHelper.Instance.ExecuteQueryDatatable("USP_Report_CashCapitalDetails", Param, "CashCapitalDetails");
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
