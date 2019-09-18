using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ObjectHelper;
using System.Data;
using CommonHelper;

namespace DataBaseHelper.DALClass
{
    public class AgentDetailDAL
    {
        private const string SPNameSaveAgentDetails = "SP_Save_AgentDetails";
        private const string SPNameCheckAgentName = "SP_Check_AgentName";
        // GeneralObjectClass objGeneral = new GeneralObjectClass();
        MasterDataDALClass ObjMasterDAL = new MasterDataDALClass();

        public int SaveAgentdetails(AgentDetailObjectClass ObjAgentDetails)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[17];
                sqlparam[0] = new SqlParameter("@AgentID", ObjAgentDetails.AgentId);
                sqlparam[1] = new SqlParameter("@AgentName", ObjAgentDetails.Name);
                sqlparam[2] = new SqlParameter("@AgentAddress", ObjAgentDetails.Address);
                sqlparam[3] = new SqlParameter("@AgentTypeID", ObjAgentDetails.AgentType);
                sqlparam[4] = new SqlParameter("@AgentPhone", ObjAgentDetails.Phoneno);
                sqlparam[5] = new SqlParameter("@DebtLimit", ObjAgentDetails.DebtLimt);
                sqlparam[6] = new SqlParameter("@Discount", ObjAgentDetails.Discount);
                //sqlparam[7] = new SqlParameter("@CreatedBy", ObjAgentDetails.CreatedBy);
                //sqlparam[8] = new SqlParameter("@ModifiedBy", ObjAgentDetails.ModifiedBy);
                sqlparam[7] = new SqlParameter("@CreatedBy", GeneralFunction.UserId);
                sqlparam[8] = new SqlParameter("@ModifiedBy", GeneralFunction.UserId);
                sqlparam[9] = new SqlParameter("@Status", 1);
                sqlparam[10] = new SqlParameter("@Remove", ObjAgentDetails.Remove);
                sqlparam[11] = new SqlParameter("@Client", ObjAgentDetails.AgtClient);
                sqlparam[12] = new SqlParameter("@Supplier", ObjAgentDetails.AgtSupplier);
                sqlparam[13] = new SqlParameter("@HideAgent", ObjAgentDetails.AgtHideAgent);
                sqlparam[14] = new SqlParameter("@Branch", ObjAgentDetails.AgtBranch);
                sqlparam[15] = new SqlParameter("@PayDay", ObjAgentDetails.PaymentDay==string.Empty?DBNull.Value:(object)ObjAgentDetails.PaymentDay);
                sqlparam[16] = new SqlParameter("@IncreasePrice", ObjAgentDetails.IncreasePrice);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveAgentDetails, sqlparam) > 0)
                {
                    GeneralObjectClass.AgentDetails.Clear();
                    ObjMasterDAL.GetAgentDetails(); return 1;
                }
                else
                { return 0; }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<object> Check_AgentNameAvailable(AgentDetailObjectClass ObjAgentDetails)
        {
            List<object> CheckAgent = new List<object>();
            try
            {

                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@AgentName", ObjAgentDetails.Name);
                sqlparam[1] = new SqlParameter("@AgentID", ObjAgentDetails.AgentId);
                // dtLocal = SQLHelper.Instance.ExecuteQueryDatatable(SPNameCheckAgentName, sqlparam, "Agent");
                var result = SQLHelper.Instance.GetReaderWithQuery("select AgentID,AgentName from Agent where AgentName=@AgentName and AgentID<>@AgentID and Status<>0", sqlparam);
                while (result.Read())
                {
                    CheckAgent.Add(result["AgentID"]);
                    CheckAgent.Add(result["AgentName"]);
                }
                result.Close();
                return CheckAgent;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
        }

        //public List<AgentDetailObjectClass> GetAllAgentNames()
        //{
        //    ///DataTable dtLocal = new DataTable();
        //    SqlParameter[] param = new SqlParameter[0];
        //    SqlDataReader result = SQLHelper.Instance.GetReader("Select AgentID,AgentName from Agent where Status<>0 and AgentID<>1001 order by AgentName asc");
        //    var agentList = new List<AgentDetailObjectClass>();
        //    //AgentDetailObjectClass agent;
        //    while (result.Read())
        //    {
        //        agentList.Add(new AgentDetailObjectClass { AgentId = Convert.ToInt32(result["AgentID"]), Name = result["AgentName"].ToString() });

        //    }// GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierName = Filter.RowFilter = "AgentID==102" });


        //    return agentList;

        //}

        //public DataTable Get_AllAgentNames()
        //{
        //    DataTable dtLocal = new DataTable();
        //    try
        //    {

        //        //var agentList = new List<AgentDetailObjectClass>();
        //        //AgentDetailObjectClass agent;
        //        //using (SqlCommand sqlCmd = new SqlCommand(procName, conn))
        //        //{
        //        //    if (param != null)
        //        //    {
        //        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        //        sqlCmd.Parameters.AddRange(param);
        //        //    }
        //        //    var result = sqlCmd.ExecuteReader();
        //        //    while (result.Read())
        //        //    {
        //        //        agentList.Add(new AgentDetailObjectClass()
        //        //        { 
        //        //            AgentId = result.GetInt32(result.GetOrdinal("ID")),
        //        //            Name = dr.GetString(dr.GetOrdinal("Name")),
        //        //            AgentType = dr.GetDateTime(dr.GetOrdinal("DateOfBirth"))
        //        //        });

        //        //    } 

        //        //}



        //        //foreach (DataRow dr in result)
        //        //{
        //        //    agent = new AgentDetailObjectClass();
        //        //    agent.AgentId = (int)dr["AgentId"];
        //        //    agentList.Add(agent);
        //        //}
        //        //agentList.Where(a => a.AgentId == 102) ;


        //        //SqlParameter[] sqlparam = new SqlParameter[0];
        //        //dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_AllAgentNames", sqlparam, "Details");
        //        ////Following Codes are added to fill the AgentDropdwnList list on 15/11/2013 by seenivasan
        //        //if (dtLocal != null && dtLocal.Rows.Count > 0)
        //        //{
        //        //    foreach (DataRow row in dtLocal.Rows)
        //        //    {
        //        //        int intAgentId = Convert.ToInt16(row["AgentID"].ToString());
        //        //        GeneralObjectClass.AgentDropdwnList.Add(new AgentDetailObjectClass { Name = row["AgentName"].ToString(), AgentId = intAgentId });
        //        //        DataView Filter;
        //        //        Filter=new DataView(dtLocal);
        //        //        GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass { SupplierName = Filter.RowFilter = "AgentID==102"});
        //        //    }
        //        //}
        //        return (dtLocal);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public List<AgentDetailObjectClass> Get_AgentdetailsByID(AgentDetailObjectClass ObjAgentDetail)
        {
            try
            {
                List<AgentDetailObjectClass> AgentDetails = new List<AgentDetailObjectClass>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", ObjAgentDetail.AgentId);
                var result = SQLHelper.Instance.GetReader("SP_Get_AgentDetailsByID", param);
                while (result.Read())
                {
                    AgentDetails.Add(new AgentDetailObjectClass
                    {
                        Number = Convert.ToInt32(result["AgentID"]),
                        Name = result["AgentName"].ToString(),
                        Address = result["AgentAddress"].ToString(),
                        AgentType = result["AgentTypeID"].ToString(),
                        Phoneno = result["AgentPhone"].ToString(),
                        PaymentDay=result["AgentPayDay"]==DBNull.Value?string.Empty:result["AgentPayDay"].ToString(),
                        DebtLimt = Convert.ToDecimal(result["DebtLimit"]),
                        Discount = Convert.ToDouble(result["Discount"]),
                        IncreasePrice = Convert.ToDouble(result["IncreasePrice"] == DBNull.Value ? 0 : result["IncreasePrice"]),
                        Payable = Convert.ToDouble(result["Payable"] == DBNull.Value ? null : result["Payable"]),
                        Receivable = Convert.ToDouble(result["Receivable"] == DBNull.Value ? null : result["Receivable"]),
                        Lastinvoice = result["LastInvoiceNo"].ToString(),
                        Lastpaymentdate = Convert.ToDateTime((result["LastPaymentDate"] == DBNull.Value ? null : result["LastPaymentDate"]))
                    });
                    
                }
                result.Close();
                return (AgentDetails);
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

        public int Delete_AgentDetails(AgentDetailObjectClass ObjAgentDetail)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];

                sqlparam[0] = new SqlParameter("@AgentID", ObjAgentDetail.AgentId);
                sqlparam[1] = new SqlParameter("@AgentName", ObjAgentDetail.Name);

                if ((SQLHelper.Instance.ExecuteNonQuery("SP_Delete_AgentDetailsByID", sqlparam)) > 0)
                {
                    GeneralObjectClass.AgentDetails.Clear();
                    ObjMasterDAL.GetAgentDetails(); return 1;
                }
                else
                { return 0; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Get_ReportValues(int AgentID)
        {
            DataTable dtLocal = new DataTable();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@AgentID", AgentID);
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_AgentDetailList", sqlparam, "AgentList");
                return (dtLocal);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public  DataTable getDebtReportValues(int AgentID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AgentID", AgentID);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_DeptList", param, "DeptList");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Object Get_AgentInvoiceCount(int AgentID)
        {
            SqlParameter[] param=new SqlParameter[1];
            param[0] = new SqlParameter("@AgentID", AgentID);
            return SQLHelper.Instance.GetScalar("SP_Check_Agent_ID", param);
        }

        ////////*******Debt Adjustment*******\\\\\\\\\\

        //public DataTable Get_AgentNameandID()
        //{
        //    try
        //    {
        //        SqlParameter[] sqlparam = new SqlParameter[0];
        //        DataTable dtAgentName = new DataTable();
        //        dtAgentName = SQLHelper.Instance.ExecuteDatatableWithQuery("Select AgentID,AgentName from Agent where HideAgent=0 and  Status <>0  order by AgentName asc ", sqlparam, "AgentName");
        //        return dtAgentName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<int> Get_MinMaxID()
        {
            List<int> MinMaxID = new List<int>();
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                //DataTable dtMinMaxID = new DataTable();
                var result = SQLHelper.Instance.GetReader("usp_GetMinMaxID", sqlparam);
                while (result.Read())
                {
                    MinMaxID.Add(Convert.ToInt32(result["MinID"]));
                }
                result.NextResult();
                while (result.Read())
                {
                    MinMaxID.Add(Convert.ToInt32(result["MaxID"]));
                    MinMaxID.Add(Convert.ToInt32(result["YearValue"]));
                }
                result.Close();
                return MinMaxID;
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

        //public DataSet Get_AllAgentNamesForDebts()
        //{
        //    DataSet dsLocal = new DataSet();
        //    try
        //    {
        //        SqlParameter[] sqlparam = new SqlParameter[0];

        //        dsLocal = SQLHelper.Instance.ExecuteQueryDataset("SP_Get_AllAgentNames_MaxMinIDForDebt", sqlparam, "Details");
        //        return (dsLocal);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public List<AgentDetailObjectClass> Get_MaxIDDebt()
        {
            List<AgentDetailObjectClass> DebtID = new List<AgentDetailObjectClass>();
            try
            {
                string Query = "Select * From KeySequence Where TableId=14";
                var result = SQLHelper.Instance.GetReader(Query);

                while (result.Read())
                {
                    DebtID.Add(new AgentDetailObjectClass
                    {
                        ReceiptID = Convert.ToInt32(result["MaxId"]),
                        Year = Convert.ToInt32(result["YearValue"]),
                        YearSequenceNo = Convert.ToInt32(result["YearMaxId"]),
                    });
                }
                return DebtID;
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

        public Boolean Save_DebtAdjustmentDetails_Receivable(AgentDetailObjectClass ObjDebt)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[9];

                sqlparam[0] = new SqlParameter("@AgentID", ObjDebt.AgentId);
                sqlparam[1] = new SqlParameter("@ReceivableAmount", ObjDebt.Receivable);
                sqlparam[2] = new SqlParameter("@BalanceAmount", ObjDebt.Balance);
                sqlparam[3] = new SqlParameter("@Description", ObjDebt.Description);
                sqlparam[4] = new SqlParameter("@ReceiptDate", ObjDebt.ReceiptDate);
                sqlparam[5] = new SqlParameter("@CreatedBy", ObjDebt.CreatedBy);
                sqlparam[6] = new SqlParameter("@ModifiedBy", ObjDebt.ModifiedBy);
                sqlparam[7] = new SqlParameter("@Status", ObjDebt.Status);
                sqlparam[8] = new SqlParameter("@ReceiptFor", ObjDebt.PayFlag );

                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_DebtAjustment_Receivable", sqlparam) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Save_DebtAdjustmentDetails_Payable(AgentDetailObjectClass ObjDebt)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[9];
              
                sqlparam[0] = new SqlParameter("@AgentID", ObjDebt.AgentId);
                sqlparam[1] = new SqlParameter("@PayableAmount", ObjDebt.Payable);
                sqlparam[2] = new SqlParameter("@BalanceAmount", ObjDebt.Balance);
                sqlparam[3] = new SqlParameter("@Description", ObjDebt.Description);
                sqlparam[4] = new SqlParameter("@PayDate", ObjDebt.ReceiptDate );
                sqlparam[5] = new SqlParameter("@CreatedBy", ObjDebt.CreatedBy);
                sqlparam[6] = new SqlParameter("@ModifiedBy", ObjDebt.ModifiedBy);
                sqlparam[7] = new SqlParameter("@ReceiptFor", ObjDebt.PayFlag);
                sqlparam[8] = new SqlParameter("@Status", ObjDebt.Status);
        
                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_DebtAjustment_Payable", sqlparam) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AgentDetailObjectClass> Get_DebtAdjustmentDetails(AgentDetailObjectClass ObjDebt)
        {
            List<AgentDetailObjectClass> DebtDetails = new List<AgentDetailObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ReceiptID", ObjDebt.ReceiptID);
                //dtLocal = SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_DebtAdjustmentDetails_ByReceiptID", param, "DebtDetails");
                var result = SQLHelper.Instance.GetReader("SP_Get_DebtAdjustmentDetails_ByReceiptID", param);
                while (result.Read())
                {
                    DebtDetails.Add(new AgentDetailObjectClass
                    {
                        ReceiptID = Convert.ToInt32(result["ReceiptID"]),
                        TableID = Convert.ToInt32(result[1]),
                        AgentId = Convert.ToInt32(result["AgentID"]),
                        Balance = Convert.ToDouble(result["BalanceAmount"] == DBNull.Value ? null : result["BalanceAmount"]),
                        Amount = Convert.ToDouble(result["Amount"]),
                        Description = result["Description"].ToString(),
                        ReceiptDate = Convert.ToDateTime(result["ReceiptDate"] == DBNull.Value ? null : result["ReceiptDate"]),
                        PayType = result["PayType"].ToString(),
                        Status = Convert.ToInt32(result["Status"]),
                        Year=Convert.ToInt32(result["Year"]),
                        YearSequenceNo=Convert.ToInt32(result["YearSequenceNo"])
                    });
                }
                result.Close();
                return DebtDetails;

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

        public List<AgentDetailObjectClass> GetBalanceSheet(AgentDetailObjectClass ObjDebt)
        {
            List<AgentDetailObjectClass> BalanceDetails = new List<AgentDetailObjectClass>();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@AgentID", ObjDebt.AgentId);
            param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            param[1].Value = ObjDebt.FromDate;
            param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            param[2].Value = ObjDebt.ToDate;
            param[3] = new SqlParameter("@Status", ObjDebt.Status);

            try
            {
                var result = SQLHelper.Instance.GetReader("SP_Get_BalanceSheet", param);
                while (result.Read())
                {
                    BalanceDetails.Add(new AgentDetailObjectClass
                    {
                        ReceiptID = Convert.ToInt32(result["PurchaseInvId"]),
                        ReceiptDate = Convert.ToDateTime(result["PurchaseDate"] == DBNull.Value ? null : result["PurchaseDate"]),
                        Description = result["Description"].ToString(),
                        NewYearNo = result["NewYearNo"].ToString(),
                        Receivable = Convert.ToDouble(result["AmtReceived"]),
                        Amount = Convert.ToInt32(result["NetAmount"]),
                        Discount = Convert.ToDouble(result["Discount"]),
                        AgentId = Convert.ToInt32(result["AgentID"])
                    });
                }
                result.Close();
                return BalanceDetails;
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

        public bool DebtDeleteReceipt(AgentDetailObjectClass ObjAgents)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ReceiptID", ObjAgents.ReceiptID);
            param[1] = new SqlParameter("@ModifiedBy", ObjAgents.ModifiedBy);
            param[2] = new SqlParameter("@Status", ObjAgents.Status);
            param[3] = new SqlParameter("@DebtFlag",Convert.ToInt32(ObjAgents.PayType));
            if (SQLHelper.Instance.ExecuteNonQuery("usp_BBM_DeleteDebtStatus", param) > 0)
                return true;
            else
                return false;
        }

        public DataTable DebtAdjustDetails(int ReceiptID)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@ReceiptID", ReceiptID);
                return SQLHelper.Instance.ExecuteQueryDatatable("usp_Reports_DebtAdjustmentList", Param, "DebtAdjustment");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DebtGetBalanceSheet(AgentDetailObjectClass ObjDebt)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@AgentID", ObjDebt.AgentId);
            param[1] = new SqlParameter("@FromDate", SqlDbType.DateTime);
            param[1].Value = ObjDebt.FromDate;
            param[2] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            param[2].Value = ObjDebt.ToDate;
            param[3] = new SqlParameter("@Status", ObjDebt.Status);
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_Get_BalanceSheet", param, "BalanceSheet");
        }
    }
}
