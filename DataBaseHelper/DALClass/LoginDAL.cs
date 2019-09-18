using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataBaseHelper;
using ObjectHelper;
using CommonHelper;

namespace DataBaseHelper.DALClass
{
    public class LoginDAL
    {


      //  private SQLHelper Obj_Dbconnect;

        #region StoredProcedureName
        //private const string SPNameGetLoginDetails = "PROC_CheckUserLogin";
        private const string SpBankBalance = "SpBankBalance_A";
        private const string SPNameGetLoginDetails = "SP_Check_LoginUser";
        private const string SPNamePhoneBookDetails = "SP_SAVE_PHONEBOOK";
        private const string SPNameGetPhoneBookAgentDetails = "SP_GET_PHONEBOOK_AGENTDETAILS";
        private const string SPNameGetCompany = "SP_Get_Company";
        private const string SPNameGetAgentID = "SP_Get_PhoneBookNameAndIDs";
        private const string SPNameGetDetailsByAgentID = "Sp_GetDetails_Agentid";
        private const string SPNameDeletePhoneBookItem = "Sp_Delete_Phonebookitem";
        private const string SPNameGetEmployeeDetailsByUserName = "SP_Get_UserReminderDetails";
        private const string SP_UpdateUserPassword = "SP_Update_UserPassword";
        private const string CHECK_BARCODE = "SP_Check_ItemBarcode";



        //    public List<EmployeeObjectClass> UserLoginDetailsLis = new List<EmployeeObjectClass>();
        #endregion

        #region Constructor
        public LoginDAL()
        {
           // Obj_Dbconnect = new SQLHelper();

        } 
        #endregion

        #region DAL Method
        public DataTable Check_UserLogin(LoginObjectClass itemObject)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UserName", itemObject.UName);
                param[1] = new SqlParameter("@Password", itemObject.Password);
                dt = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetLoginDetails, param, "[User]");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Status"].ToString() == "1" && !string.IsNullOrEmpty(itemObject.UName))
                    {
                       // StampLoginTime(itemObject.UserId);
                    }
                }
                return dt;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StampLoginTime(int userID)
        {
            try { 
            SqlParameter[] InsertLogin = new SqlParameter[1];
            InsertLogin[0] = new SqlParameter("@UserID", userID);
                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into EndShiftDetails (Username , LoginTime , CreatedDate ,ModifiedDate) values( @Username ,GETDATE() ,GETDATE() ,GETDATE())", InsertLogin) > 0)
                {
                    // DateTime LoginTime = "";
                    SqlParameter[] GetLoginTime = new SqlParameter[0];
                    DateTime LoginTime = Convert.ToDateTime((SQLHelper.Instance.GetScalarQuery("select max(LoginTime) as LoginTime from EndShiftDetails", GetLoginTime)));
                    if (LoginTime != null)
                    {
                        GeneralFunction.UserLoginTime = LoginTime;

                    }
                }
            }
            catch
            {

            }
        }

        public DataTable Get_EmployeeDetailsByUserName(LoginObjectClass ItemObject)
        {
            try
            {
                DataTable dtLocal = new DataTable();
                SqlParameter[] Sqlparam = new SqlParameter[1];
                Sqlparam[0] = new SqlParameter("@MTB_USER_NAME", ItemObject.UName);
                dtLocal = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetEmployeeDetailsByUserName, Sqlparam, "EmpReminder");
                return dtLocal;
            }
            catch (Exception ex) { throw ex; }
        }

        public int savephonebook(AddressPhoneBookObjectClass AgentDetailsObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@DTB_AGENT_MAIL_ID", AgentDetailsObj.PhoneBookId);
                param[1] = new SqlParameter("@MTB_AGENT_ID", AgentDetailsObj.Agentid);
                param[2] = new SqlParameter("@DTB_CONTACT_NAME", AgentDetailsObj.AgentName);
                param[3] = new SqlParameter("@DTB_MAIL_ADDR1", AgentDetailsObj.AgentAddress1);
                param[4] = new SqlParameter("@DTB_MAIL_ADDR2", AgentDetailsObj.AgentAddress2);
                param[5] = new SqlParameter("@DTB_PHONE1", AgentDetailsObj.AgentPhone1);
                param[6] = new SqlParameter("@DTB_PHONE2", AgentDetailsObj.Agentphone2);
                param[7] = new SqlParameter("@DTB_CELL1", AgentDetailsObj.AgentCell1);
                param[8] = new SqlParameter("@DTB_CELL2", AgentDetailsObj.AgentCell2);
                param[9] = new SqlParameter("@DTB_EMAIL", AgentDetailsObj.AgentMailId);
                param[10] = new SqlParameter("@DTB_WEB_ADD", AgentDetailsObj.WebId);
                param[11] = new SqlParameter("DTB_PO_BOX", AgentDetailsObj.PoBox);
                param[12] = new SqlParameter("@DTB_DATE_CREATED", DateTime.Now);
                param[13] = new SqlParameter("@DTB_CREATED_BY", "Admin");
                param[14] = new SqlParameter("@DTB_DATE_MODIFIED", DateTime.Now);
                param[15] = new SqlParameter("@DTB_MODIFIED_BY", "Admin");
                param[16] = new SqlParameter("DTB_STATUS", "Y");
                param[17] = new SqlParameter("@DTB_COMPANYID", "000");
                if (SQLHelper.Instance.ExecuteNonQuery(SPNamePhoneBookDetails, param) > 0)
                    return 1;
                else
                    return 0;
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable getallagentdetails()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                dt =SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetPhoneBookAgentDetails, param, "DTB_AGENT_PHONEBOOK");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getcompany()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                dt =SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetCompany, param, "MTB_COMPANY");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public DataTable setagentid()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                dt = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetAgentID, param, "DTB_AGENT_PHONEBOOK");
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }
        public DataTable getdetailsby_agentid(AddressPhoneBookObjectClass ObjAgentDetail)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MTB_AGENT_ID", ObjAgentDetail.Agentid);
                dt = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetDetailsByAgentID, param, "DTB_AGENT_PHONEBOOK");
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }
        public int deletedetails(AddressPhoneBookObjectClass ObjAgentDetails)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MTB_AGENT_ID",ObjAgentDetails.Agentid);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameDeletePhoneBookItem, param) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }


        }

        public bool changePassword(LoginObjectClass objLoginObjectClass)
        {
            SqlParameter[] sqlParam = new SqlParameter[4];
            sqlParam[0] = new SqlParameter("@UserID", objLoginObjectClass.UserId);
            sqlParam[1] = new SqlParameter("@UserName", objLoginObjectClass.UName);
            sqlParam[2] = new SqlParameter("@OldPassword", objLoginObjectClass.Password);
            sqlParam[3] = new SqlParameter("@NewPassword", objLoginObjectClass.NewPassword);   
            if(SQLHelper.Instance.ExecuteNonQuery(SP_UpdateUserPassword, sqlParam) > 0)
                return true;
            else 
            return false;

        }
        public decimal CheckBalanceDAL()
        {
            try
            {
                decimal balance = 0;
                SqlParameter[] sqlparam = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(SpBankBalance, sqlparam);
                while (result.Read())
                {
                    balance = Convert.ToDecimal(result["balance"].ToString());
                }
                return balance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        #endregion
        public int GetBarcodeCount()
        {
            int barcount = 0;
            try
            {
                var Query = "SELECT ISNULL(COUNT(*),0) as count from Barcode WHERE [Status]=1 AND Barcode<>''";
                    using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                    {
                        SQLHelper.Instance.conn.Open();
                        sqlCmd.CommandType = CommandType.Text;
                        var result = sqlCmd.ExecuteReader();
                        while (result.Read())
                        {
                            barcount =Convert.ToInt32(result["count"].ToString());
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
            return barcount;
        }

        public DataTable GetWrongStock()
        {
            SqlParameter[] param = new SqlParameter[0];

            return SQLHelper.Instance.ExecuteQueryDatatable("UpdateWrongStock", param,"wrongstock");
        }

        public DataTable GetWrongStockExpiry()
        {
            SqlParameter[] param = new SqlParameter[0];

            return SQLHelper.Instance.ExecuteQueryDatatable("UpdateWrongStockExpiry", param, "wrongstock");
        }

        public bool UpdateWrongStock()
        {
            DataTable ItemID = new DataTable();
            ItemID = GetWrongStock();
            List<AllItems> AllItems = new List<AllItems>();
            for (int i = 0; i < ItemID.Rows.Count; i++)
            {
               // try
               // {
                    int PurchaseQuantity = 0;
                    int SaleQuantity = 0;
                    int BarcodeID = 0; //select BarcodeID from Barcode where ItemID = '4718'
                if(ItemID.Rows[i][0].ToString() == "266")
                {

                }
                    SqlParameter[] ParamsBarcode = new SqlParameter[1];
                    ParamsBarcode[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                    BarcodeID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select top 1 BarcodeID from Barcode where ItemID = @ItemID order by CreatedDate asc", ParamsBarcode));



                    //var Query2 = "select sum(Quantity) total from ( select Quantity from PurchaseDetails where ItemID = '" + ItemID.Rows[0][i] + "' union all select Quantity from Inventory where ItemID = '" + ItemID.Rows[0][i] + "') t";

                    // sum of purchase
                    SqlParameter[] Params = new SqlParameter[2];
                    Params[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                    Params[1] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                    PurchaseQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 union all select Quantity from Inventory where ItemID = @ItemID2) t", Params));
                    int AllPurchaseQuantity = PurchaseQuantity;

                    // var Query3 = "select sum(Quantity) as Sold from SaleDetails where ItemID = '" + ItemID.Rows[0][i] + "'";

                    // sum of sale
                    SqlParameter[] SaleParams = new SqlParameter[1];
                    SaleParams[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                    SaleQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity) - sum(ReturnQuantity),0) as Sold from SaleDetails where ItemID = @ItemID1", SaleParams));


                    // sum of Spoiled
                    SqlParameter[] SaleParamSpoiled = new SqlParameter[1];
                    SaleParamSpoiled[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                    int SpoiledQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity) ,0) as Spoiled from OrderDetails where ItemID = @ItemID1", SaleParamSpoiled));
                    if (SpoiledQuantity > 0)
                    {
                        SaleQuantity += SpoiledQuantity;
                    }

                    // purchase records
                    string Query = "select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity,Cost,ExpiryDate,CreatedDate OrderKey from PurchaseDetails where ItemID = @ItemID1 union select Quantity,UnitPrice as Cost,ExpiryDate, CreatedDate OrderKey from Inventory  where ItemID = @ItemID2 order by OrderKey ";


                    DataTable dt_PurchaseSum = new DataTable();
                    SqlParameter[] PurchaseParams = new SqlParameter[2];
                    PurchaseParams[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                    PurchaseParams[1] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                    dt_PurchaseSum = SQLHelper.Instance.ExecuteDatatableWithQuery(Query, PurchaseParams, "Purchase");

                    // purchase by cost

                    int StockRun = 0;
                    for (int j = 0; j < dt_PurchaseSum.Rows.Count; j++)
                    {
                        if (StockRun == 0)
                        {
                            int PurchaseSum = 0;
                            //if(ItemID.Rows[i][0].ToString() == "4138")
                            //{

                            //}
                            SqlParameter[] CostPurchase = new SqlParameter[4];
                            CostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                            CostPurchase[1] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                            CostPurchase[2] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                            CostPurchase[3] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                            PurchaseSum = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and UnitPrice = @Cost2) t", CostPurchase));
                            PurchaseSum += AllItems.Where(item => item.ItemID == ItemID.Rows[i][0].ToString()).Sum(item => item.Quantity);
                            if (PurchaseSum >= SaleQuantity)
                            {
                                int NewPurchase = 0;
                                SqlParameter[] LatestPurchaseCount = new SqlParameter[6];
                                LatestPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                LatestPurchaseCount[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                LatestPurchaseCount[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                LatestPurchaseCount[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                LatestPurchaseCount[4] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                LatestPurchaseCount[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                NewPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(COUNT(PurchaseDetailID),0) Purchase from ( select PurchaseDetailID from PurchaseDetails where ItemID = @ItemID1 and CreatedDate > @CreatedDate1 and Cost != @Cost1 union all select InventoryID from Inventory where ItemID = @ItemID2 and CreatedDate > @CreatedDate2 and UnitPrice != @Cost2) t", LatestPurchaseCount));
                                if (NewPurchase > 0)
                                {

                                    SqlParameter[] LatestPurchase = new SqlParameter[6];
                                    LatestPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    LatestPurchase[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                    LatestPurchase[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                    LatestPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    LatestPurchase[4] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                    LatestPurchase[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);


                                    DataTable dt_PurchaseNew = new DataTable();
                                    string NewPurQuery = "select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity, Cost from PurchaseDetails where ItemID = @ItemID1 and CreatedDate > @CreatedDate1 and Cost != @Cost1 union select Quantity,UnitPrice from Inventory where ItemID = @ItemID2 and CreatedDate > @CreatedDate2 and UnitPrice != @Cost2";
                                    dt_PurchaseNew = SQLHelper.Instance.ExecuteDatatableWithQuery(NewPurQuery, LatestPurchase, "NewPurchase");

                                    for (int k = 0; k < dt_PurchaseNew.Rows.Count; k++)
                                    {
                                        // updating latest stock which not sold
                                        SqlParameter[] UpdateNewStock = new SqlParameter[2];
                                        UpdateNewStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateNewStock[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
                                        //UpdateNewStock[2] = new SqlParameter("@Quantity", dt_PurchaseNew.Rows[k][0]);

                                        int StockCountNew = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateNewStock));

                                        int NewQuantity = 0;
                                        SqlParameter[] GetSameCost = new SqlParameter[4];
                                        GetSameCost[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                        GetSameCost[1] = new SqlParameter("@Cost1", dt_PurchaseNew.Rows[k][1]);
                                        GetSameCost[2] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                        GetSameCost[3] = new SqlParameter("@Cost2", dt_PurchaseNew.Rows[k][1]);
                                        NewQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select  (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and UnitPrice = @Cost2) t", GetSameCost));


                                        SqlParameter[] UpdateNewStock2 = new SqlParameter[3];
                                        UpdateNewStock2[0] = new SqlParameter("@Quantity", NewQuantity);
                                        UpdateNewStock2[1] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateNewStock2[2] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
                                        if (StockCountNew == 0)
                                        {
                                            //@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
                                            SqlParameter[] InsertNewStock = new SqlParameter[5];
                                            InsertNewStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                            InsertNewStock[1] = new SqlParameter("@Quantity", NewQuantity);
                                            InsertNewStock[2] = new SqlParameter("@Cost1", dt_PurchaseNew.Rows[k][1]);
                                            InsertNewStock[3] = new SqlParameter("@Cost2", dt_PurchaseNew.Rows[k][1]);
                                            InsertNewStock[4] = new SqlParameter("@Barcode", BarcodeID);
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,null ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock) > 0)
                                            {

                                            }
                                        }
                                        else if (StockCountNew > 1)
                                        {
                                            int MaxIDNew = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateNewStock2));

                                            SqlParameter[] UpdateMulStock = new SqlParameter[4];
                                            UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                            UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
                                            UpdateMulStock[2] = new SqlParameter("@Quantity", NewQuantity);
                                            UpdateMulStock[3] = new SqlParameter("@MaxID", MaxIDNew);
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID", UpdateMulStock) > 0)
                                            {
                                                SqlParameter[] UpdateMulStock2 = new SqlParameter[4];
                                                UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                                UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
                                                UpdateMulStock2[2] = new SqlParameter("@Quantity", NewQuantity);
                                                UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxIDNew);

                                                if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID", UpdateMulStock2) > 0)
                                                {

                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost", UpdateNewStock2) > 0)
                                            {

                                            }
                                        }
                                    }


                                    // update old stock
                                    int OldPurchase = 0;
                                    SqlParameter[] OldPurchaseCount = new SqlParameter[4];
                                    OldPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    OldPurchaseCount[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                    OldPurchaseCount[2] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    OldPurchaseCount[3] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                    OldPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and CreatedDate <= @CreatedDate1 union all select Quantity from Inventory where ItemID = @ItemID2 and CreatedDate <= @CreatedDate2) t", OldPurchaseCount));
                                    PurchaseQuantity = OldPurchase - SaleQuantity;


                                    SqlParameter[] SameCostPurchase = new SqlParameter[6];
                                    SameCostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    SameCostPurchase[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                    SameCostPurchase[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                    SameCostPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    SameCostPurchase[4] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                    SameCostPurchase[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                    PurchaseQuantity += Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and CreatedDate > @CreatedDate1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and CreatedDate > @CreatedDate2 and UnitPrice = @Cost2) t", SameCostPurchase));


                                    SqlParameter[] UpdateOldStock = new SqlParameter[3];
                                    UpdateOldStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                    int StockCount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock));

                                    SqlParameter[] UpdateOldStock2 = new SqlParameter[3];
                                    UpdateOldStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                    if (StockCount == 0)
                                    {
                                        //@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
                                        SqlParameter[] InsertNewStock2 = new SqlParameter[5];
                                        InsertNewStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        InsertNewStock2[1] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        InsertNewStock2[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[3] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[4] = new SqlParameter("@Barcode", BarcodeID);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,null ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock2) > 0)
                                        {

                                        }
                                    }

                                    else if (StockCount > 1)
                                    {
                                        int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2));

                                        SqlParameter[] UpdateMulStock = new SqlParameter[4];
                                        UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                        UpdateMulStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        UpdateMulStock[3] = new SqlParameter("@MaxID", MaxID);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID", UpdateMulStock) > 0)
                                        {
                                            SqlParameter[] UpdateMulStock2 = new SqlParameter[4];
                                            UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                            UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                            UpdateMulStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                            UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxID);
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID", UpdateMulStock2) > 0)
                                            {

                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2) > 0)
                                        {

                                        }
                                    }






                                }

                            else
                            {
                                // update old stock starts - 15 march

                                // update old stock
                                int FinalCount = j + 1;
                                if (FinalCount == dt_PurchaseSum.Rows.Count && StockRun == 0)
                                {
                                    // update old stock
                                    int OldPurchase = 0;
                                    SqlParameter[] OldPurchaseCount = new SqlParameter[4];
                                    OldPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    OldPurchaseCount[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                    OldPurchaseCount[2] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    OldPurchaseCount[3] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                    OldPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and CreatedDate <= @CreatedDate1 union all select Quantity from Inventory where ItemID = @ItemID2 and CreatedDate <= @CreatedDate2) t", OldPurchaseCount));
                                    PurchaseQuantity = OldPurchase - SaleQuantity;


                                    SqlParameter[] SameCostPurchase = new SqlParameter[6];
                                    SameCostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    SameCostPurchase[1] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][3]);
                                    SameCostPurchase[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                    SameCostPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    SameCostPurchase[4] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][3]);
                                    SameCostPurchase[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                    PurchaseQuantity += Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and CreatedDate > @CreatedDate1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and CreatedDate > @CreatedDate2 and UnitPrice = @Cost2) t", SameCostPurchase));


                                    SqlParameter[] UpdateOldStock = new SqlParameter[3];
                                    UpdateOldStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                    int StockCount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock));

                                    SqlParameter[] UpdateOldStock2 = new SqlParameter[3];
                                    UpdateOldStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                    if (StockCount == 0)
                                    {
                                        //@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
                                        SqlParameter[] InsertNewStock2 = new SqlParameter[5];
                                        InsertNewStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        InsertNewStock2[1] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        InsertNewStock2[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[3] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[4] = new SqlParameter("@Barcode", BarcodeID);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,null ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock2) > 0)
                                        {

                                        }
                                    }

                                    else if (StockCount > 1)
                                    {
                                        int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2));

                                        SqlParameter[] UpdateMulStock = new SqlParameter[4];
                                        UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                        UpdateMulStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        UpdateMulStock[3] = new SqlParameter("@MaxID", MaxID);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID", UpdateMulStock) > 0)
                                        {
                                            SqlParameter[] UpdateMulStock2 = new SqlParameter[4];
                                            UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                            UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                            UpdateMulStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                            UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxID);
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID", UpdateMulStock2) > 0)
                                            {

                                            }
                                        }

                                    }
                                    else
                                    {

                                        int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(ID,0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2));

                                        SqlParameter[] UpdateOldStock3 = new SqlParameter[3];
                                        UpdateOldStock3[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateOldStock3[1] = new SqlParameter("@ID", MaxID);
                                        UpdateOldStock3[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        // UpdateOldStock3[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);

                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and ID = @ID", UpdateOldStock3) > 0)
                                        {

                                        }
                                        SqlParameter[] UpdateOldStock4 = new SqlParameter[2];
                                        UpdateOldStock4[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateOldStock4[1] = new SqlParameter("@ID", MaxID);
                                        //UpdateOldStock3[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and ID != @ID", UpdateOldStock4) > 0)
                                        {

                                        }
                                    }

                                }
                                // update old stock ends - 15 march
                            }

                        }
                            else
                            {
                                AllItems InsertOld = new AllItems();
                                if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][0].ToString()))
                                {
                                    InsertOld.Quantity = Convert.ToInt32(dt_PurchaseSum.Rows[j][0]);
                                }
                                if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][1].ToString()))
                                {
                                    InsertOld.Cost = Convert.ToDecimal(dt_PurchaseSum.Rows[j][1]);
                                }
                                if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][3].ToString()))
                                {
                                    InsertOld.DateCreated = Convert.ToDateTime(dt_PurchaseSum.Rows[j][3]);
                                }
                                InsertOld.ItemID = ItemID.Rows[i][0].ToString();
                                AllItems.Add(InsertOld);
                            }

                            int StockQuantity = 0;
                            SqlParameter[] StockParams = new SqlParameter[1];
                            StockParams[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                            StockQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(StockInHand),0) from Stock where ItemID = @ItemID", StockParams));

                            if (StockQuantity == AllPurchaseQuantity - SaleQuantity)
                            {
                                StockRun = 1;
                            }

                        }
                    }



             //   }
               // catch (Exception ex)
              //  {
              //      throw ex;
              //  }
              //  finally
              //  {
                    SQLHelper.Instance.conn.Close();
             //   }
                
            }
            return true;
        }


        public bool UpdateWrongStockExpiry()
        {
            DataTable ItemID = new DataTable();
            ItemID = GetWrongStockExpiry();
            List<AllItems> AllItems = new List<AllItems>();
            for (int i = 0; i < ItemID.Rows.Count; i++)
            {
               //  try
               //   {
               if(ItemID.Rows[i][0].ToString() == "2163")
                {
                    
                }
                int PurchaseQuantity = 0;
                int SaleQuantity = 0;
                int BarcodeID = 0; //select BarcodeID from Barcode where ItemID = '4718'

                SqlParameter[] ParamsBarcode = new SqlParameter[1];
                ParamsBarcode[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                BarcodeID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select top 1 BarcodeID from Barcode where ItemID = @ItemID order by CreatedDate asc", ParamsBarcode));



                //var Query2 = "select sum(Quantity) total from ( select Quantity from PurchaseDetails where ItemID = '" + ItemID.Rows[0][i] + "' union all select Quantity from Inventory where ItemID = '" + ItemID.Rows[0][i] + "') t";

                // sum of purchase
                SqlParameter[] Params = new SqlParameter[2];
                Params[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                Params[1] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                PurchaseQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 union all select Quantity from Inventory where ItemID = @ItemID2) t", Params));

				int AllPurchaseQuantity = PurchaseQuantity;

				// var Query3 = "select sum(Quantity) as Sold from SaleDetails where ItemID = '" + ItemID.Rows[0][i] + "'";

				// sum of sale
				SqlParameter[] SaleParams = new SqlParameter[1];
                SaleParams[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                SaleQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity) - sum(ReturnQuantity),0) as Sold from SaleDetails where ItemID = @ItemID1", SaleParams));

                    // sum of Spoiled
                SqlParameter[] SaleParamSpoiled = new SqlParameter[1];
                SaleParamSpoiled[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
              int  SpoiledQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity) ,0) as Spoiled from OrderDetails where ItemID = @ItemID1", SaleParamSpoiled));
                    if(SpoiledQuantity > 0)
                    {
                        SaleQuantity += SpoiledQuantity;
                    }

                    // purchase records
                    string Query = "select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity,Cost,ExpiryDate,ExpiryDate OrderKey,CreatedDate from PurchaseDetails where ItemID = @ItemID1 union select Quantity,UnitPrice as Cost,ExpiryDate, ExpiryDate OrderKey,CreatedDate from Inventory  where ItemID = @ItemID2 order by OrderKey,CreatedDate ";


                DataTable dt_PurchaseSum = new DataTable();
                SqlParameter[] PurchaseParams = new SqlParameter[2];
                PurchaseParams[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                PurchaseParams[1] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                dt_PurchaseSum = SQLHelper.Instance.ExecuteDatatableWithQuery(Query, PurchaseParams, "Purchase");

				// purchase by cost

				int StockRun = 0;
				for (int j = 0; j < dt_PurchaseSum.Rows.Count; j++)
				{
					if (StockRun == 0)
					{
					
					int PurchaseSum = 0;
					//if (ItemID.Rows[i][0].ToString() == "4138")
					//{

					//}
					SqlParameter[] CostPurchase = new SqlParameter[6];
					CostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
					CostPurchase[1] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
					CostPurchase[2] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
					CostPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
					CostPurchase[4] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
					CostPurchase[5] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
					PurchaseSum = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and Cost = @Cost1 and ExpiryDate = @Expiry1 union all select Quantity from Inventory where ItemID = @ItemID2 and UnitPrice = @Cost2 and ExpiryDate = @Expiry2) t", CostPurchase));
					PurchaseSum += AllItems.Where(item => item.ItemID == ItemID.Rows[i][0].ToString()).Sum(item => item.Quantity);
					if (PurchaseSum >= SaleQuantity)
					{
						int NewPurchase = 0;
						SqlParameter[] LatestPurchaseCount = new SqlParameter[10];
						LatestPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
						LatestPurchaseCount[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
						LatestPurchaseCount[2] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
						LatestPurchaseCount[3] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
						LatestPurchaseCount[4] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][4]);
						LatestPurchaseCount[5] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
						LatestPurchaseCount[6] = new SqlParameter("@Expiry3", dt_PurchaseSum.Rows[j][2]);
						LatestPurchaseCount[7] = new SqlParameter("@Expiry4", dt_PurchaseSum.Rows[j][2]);
						LatestPurchaseCount[8] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
						LatestPurchaseCount[9] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][4]);
						NewPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(COUNT(PurchaseDetailID),0) Purchase from ( select PurchaseDetailID from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate > @Expiry1 OR (ExpiryDate = @Expiry2 AND Cost != @Cost1  AND CreatedDate > @CreatedDate1 and ItemID = @ItemID1) union all select InventoryID from Inventory where ItemID = @ItemID2 and ExpiryDate > @Expiry3  OR (ExpiryDate = @Expiry4 AND UnitPrice != @Cost2  AND CreatedDate > @CreatedDate2 and ItemID = @ItemID2)) t", LatestPurchaseCount));
						if (NewPurchase > 0)
						{

							SqlParameter[] LatestPurchase = new SqlParameter[10];
							LatestPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
							LatestPurchase[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
							LatestPurchase[2] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
							LatestPurchase[3] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
							LatestPurchase[4] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][4]);
							LatestPurchase[5] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
							LatestPurchase[6] = new SqlParameter("@Expiry3", dt_PurchaseSum.Rows[j][2]);
							LatestPurchase[7] = new SqlParameter("@Expiry4", dt_PurchaseSum.Rows[j][2]);
							LatestPurchase[8] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
							LatestPurchase[9] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][4]);


							DataTable dt_PurchaseNew = new DataTable();
							string NewPurQuery = "select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity, Cost , ExpiryDate from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate > @Expiry1 OR (ExpiryDate = @Expiry2 AND Cost != @Cost1 AND CreatedDate > @CreatedDate1 and ItemID = @ItemID1)  union select Quantity,UnitPrice, ExpiryDate from Inventory where ItemID = @ItemID2 and ExpiryDate > @Expiry3 OR (ExpiryDate = @Expiry4 AND UnitPrice != @Cost2  AND CreatedDate > @CreatedDate2 and ItemID = @ItemID2)";
							dt_PurchaseNew = SQLHelper.Instance.ExecuteDatatableWithQuery(NewPurQuery, LatestPurchase, "NewPurchase");

							for (int k = 0; k < dt_PurchaseNew.Rows.Count; k++)
							{
								// updating latest stock which not sold
								SqlParameter[] UpdateNewStock = new SqlParameter[3];
								UpdateNewStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
								UpdateNewStock[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
								UpdateNewStock[2] = new SqlParameter("@Expiry", dt_PurchaseNew.Rows[k][2]);
								//UpdateNewStock[2] = new SqlParameter("@Quantity", dt_PurchaseNew.Rows[k][0]);

								int StockCountNew = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateNewStock));

								int NewQuantity = 0;
								SqlParameter[] GetSameCost = new SqlParameter[6];
								GetSameCost[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
								GetSameCost[1] = new SqlParameter("@Cost1", dt_PurchaseNew.Rows[k][1]);
								GetSameCost[2] = new SqlParameter("@Expiry1", dt_PurchaseNew.Rows[k][2]);
								GetSameCost[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
								GetSameCost[4] = new SqlParameter("@Cost2", dt_PurchaseNew.Rows[k][1]);
								GetSameCost[5] = new SqlParameter("@Expiry2", dt_PurchaseNew.Rows[k][2]);
								NewQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) total from ( select  (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and Cost = @Cost1 and ExpiryDate = @Expiry1 union all select Quantity from Inventory where ItemID = @ItemID2 and UnitPrice = @Cost2 and ExpiryDate = @Expiry2) t", GetSameCost));


								SqlParameter[] UpdateNewStock2 = new SqlParameter[4];
								UpdateNewStock2[0] = new SqlParameter("@Quantity", NewQuantity);
								UpdateNewStock2[1] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
								UpdateNewStock2[2] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
								UpdateNewStock2[3] = new SqlParameter("@Expiry", dt_PurchaseNew.Rows[k][2]);
								if (StockCountNew == 0)
								{
									//@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
									SqlParameter[] InsertNewStock = new SqlParameter[6];
									InsertNewStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
									InsertNewStock[1] = new SqlParameter("@Quantity", NewQuantity);
									InsertNewStock[2] = new SqlParameter("@Cost1", dt_PurchaseNew.Rows[k][1]);
									InsertNewStock[3] = new SqlParameter("@Expiry", dt_PurchaseNew.Rows[k][2]);
									InsertNewStock[4] = new SqlParameter("@Cost2", dt_PurchaseNew.Rows[k][1]);
									InsertNewStock[5] = new SqlParameter("@Barcode", BarcodeID);
									if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,@Expiry ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock) > 0)
									{

									}
								}
								else if (StockCountNew > 1)
								{
									int MaxIDNew = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateNewStock2));

									SqlParameter[] UpdateMulStock = new SqlParameter[5];
									UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
									UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
									UpdateMulStock[2] = new SqlParameter("@Quantity", NewQuantity);
									UpdateMulStock[3] = new SqlParameter("@MaxID", MaxIDNew);
									UpdateMulStock[4] = new SqlParameter("@Expiry", dt_PurchaseNew.Rows[k][2]);
									if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID and Expiry = @Expiry", UpdateMulStock) > 0)
									{
										SqlParameter[] UpdateMulStock2 = new SqlParameter[5];
										UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
										UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseNew.Rows[k][1]);
										UpdateMulStock2[2] = new SqlParameter("@Quantity", NewQuantity);
										UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxIDNew);
										UpdateMulStock2[4] = new SqlParameter("@Expiry", dt_PurchaseNew.Rows[k][2]);

										if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID and Expiry = @Expiry", UpdateMulStock2) > 0)
										{

										}
									}

								}
								else
								{
									if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateNewStock2) > 0)
									{

									}
								}
							}


							// update old stock
							int OldPurchase = 0;
							SqlParameter[] OldPurchaseCount = new SqlParameter[10];
							OldPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
							OldPurchaseCount[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
							OldPurchaseCount[2] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
							OldPurchaseCount[3] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
							OldPurchaseCount[4] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][4]);
							OldPurchaseCount[5] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
							OldPurchaseCount[6] = new SqlParameter("@Expiry3", dt_PurchaseSum.Rows[j][2]);
							OldPurchaseCount[7] = new SqlParameter("@Expiry4", dt_PurchaseSum.Rows[j][2]);
							OldPurchaseCount[8] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
							OldPurchaseCount[9] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][4]);

							OldPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate < @Expiry1 OR (ExpiryDate = @Expiry2 AND Cost = @Cost1  AND CreatedDate <= @CreatedDate1 and ItemID = @ItemID1) union all select Quantity from Inventory where ItemID = @ItemID2 and ExpiryDate < @Expiry3 OR (ExpiryDate = @Expiry4 AND UnitPrice = @Cost2  AND CreatedDate <= @CreatedDate2 and ItemID = @ItemID2)) t", OldPurchaseCount));
							PurchaseQuantity = OldPurchase - SaleQuantity;


							SqlParameter[] SameCostPurchase = new SqlParameter[6];
							SameCostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
							SameCostPurchase[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
							SameCostPurchase[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
							SameCostPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
							SameCostPurchase[4] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
							SameCostPurchase[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
							// PurchaseQuantity += Convert.ToInt16(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate > @Expiry1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and ExpiryDate > @Expiry2 and UnitPrice = @Cost2) t", SameCostPurchase));


							SqlParameter[] UpdateOldStock = new SqlParameter[4];
							UpdateOldStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
							UpdateOldStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
							UpdateOldStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
							UpdateOldStock[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);

							int StockCount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateOldStock));

							SqlParameter[] UpdateOldStock2 = new SqlParameter[4];
							UpdateOldStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
							UpdateOldStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
							UpdateOldStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
							UpdateOldStock2[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
							if (StockCount == 0)
							{
								//@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
								SqlParameter[] InsertNewStock2 = new SqlParameter[6];
								InsertNewStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
								InsertNewStock2[1] = new SqlParameter("@Quantity", PurchaseQuantity);
								InsertNewStock2[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
								InsertNewStock2[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
								InsertNewStock2[4] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
								InsertNewStock2[5] = new SqlParameter("@Barcode", BarcodeID);
								if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,@Expiry ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock2) > 0)
								{

								}
							}

							else if (StockCount > 1)
							{
								int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2));

								SqlParameter[] UpdateMulStock = new SqlParameter[5];
								UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
								UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
								UpdateMulStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
								UpdateMulStock[3] = new SqlParameter("@MaxID", MaxID);
								UpdateMulStock[4] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
								if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID and Expiry = @Expiry", UpdateMulStock) > 0)
								{
									SqlParameter[] UpdateMulStock2 = new SqlParameter[5];
									UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
									UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
									UpdateMulStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
									UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxID);
									UpdateMulStock2[4] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
									if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID and Expiry = @Expiry", UpdateMulStock2) > 0)
									{

									}
								}

							}
							else
							{
								if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateOldStock2) > 0)
								{

								}
							}






						}
                        else
                            {
                                // update old stock starts - 15 march

                                // update old stock
                                int FinalCount = j + 1;
                                if (FinalCount == dt_PurchaseSum.Rows.Count && StockRun == 0)
                                {
                                    int OldPurchase = 0;
                                    SqlParameter[] OldPurchaseCount = new SqlParameter[10];
                                    OldPurchaseCount[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    OldPurchaseCount[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
                                    OldPurchaseCount[2] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
                                    OldPurchaseCount[3] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                    OldPurchaseCount[4] = new SqlParameter("@CreatedDate1", dt_PurchaseSum.Rows[j][4]);
                                    OldPurchaseCount[5] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    OldPurchaseCount[6] = new SqlParameter("@Expiry3", dt_PurchaseSum.Rows[j][2]);
                                    OldPurchaseCount[7] = new SqlParameter("@Expiry4", dt_PurchaseSum.Rows[j][2]);
                                    OldPurchaseCount[8] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                    OldPurchaseCount[9] = new SqlParameter("@CreatedDate2", dt_PurchaseSum.Rows[j][4]);

                                    OldPurchase = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate < @Expiry1 OR (ExpiryDate = @Expiry2 AND Cost = @Cost1  AND CreatedDate <= @CreatedDate1 and ItemID = @ItemID1) union all select Quantity from Inventory where ItemID = @ItemID2 and ExpiryDate < @Expiry3 OR (ExpiryDate = @Expiry4 AND UnitPrice = @Cost2  AND CreatedDate <= @CreatedDate2 and ItemID = @ItemID2)) t", OldPurchaseCount));
                                    PurchaseQuantity = OldPurchase - SaleQuantity;


                                    SqlParameter[] SameCostPurchase = new SqlParameter[6];
                                    SameCostPurchase[0] = new SqlParameter("@ItemID1", ItemID.Rows[i][0]);
                                    SameCostPurchase[1] = new SqlParameter("@Expiry1", dt_PurchaseSum.Rows[j][2]);
                                    SameCostPurchase[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                    SameCostPurchase[3] = new SqlParameter("@ItemID2", ItemID.Rows[i][0]);
                                    SameCostPurchase[4] = new SqlParameter("@Expiry2", dt_PurchaseSum.Rows[j][2]);
                                    SameCostPurchase[5] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                    // PurchaseQuantity += Convert.ToInt16(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(Quantity),0) OldPurchase from ( select (isnull(Quantity,0) - isnull(ReturnQuantity,0)) as Quantity from PurchaseDetails where ItemID = @ItemID1 and ExpiryDate > @Expiry1 and Cost = @Cost1 union all select Quantity from Inventory where ItemID = @ItemID2 and ExpiryDate > @Expiry2 and UnitPrice = @Cost2) t", SameCostPurchase));


                                    SqlParameter[] UpdateOldStock = new SqlParameter[4];
                                    UpdateOldStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                    UpdateOldStock[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);

                                    int StockCount = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(Count(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateOldStock));

                                    SqlParameter[] UpdateOldStock2 = new SqlParameter[4];
                                    UpdateOldStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                    UpdateOldStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                    UpdateOldStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                    UpdateOldStock2[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
                                    if (StockCount == 0)
                                    {
                                        //@ItemID,@RemainingQuantity,@Cost ,@Expiry ,0 ,@Cost
                                        SqlParameter[] InsertNewStock2 = new SqlParameter[6];
                                        InsertNewStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        InsertNewStock2[1] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        InsertNewStock2[2] = new SqlParameter("@Cost1", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
                                        InsertNewStock2[4] = new SqlParameter("@Cost2", dt_PurchaseSum.Rows[j][1]);
                                        InsertNewStock2[5] = new SqlParameter("@Barcode", BarcodeID);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Insert into Stock (BatchID ,  ItemID ,  StockInHand ,   Cost ,   Expiry , SerialNo ,  DiscountedCost ,  CreatedDate ,  CreatedBy ,  ModifiedDate , ModifiedBy ,  [Status] ,  BarcodeID )   values(  0 ,@ItemID,@Quantity,@Cost1 ,@Expiry ,0 ,@Cost2 ,GETDATE() ,101 ,GETDATE() ,101  ,1  ,@Barcode )", InsertNewStock2) > 0)
                                        {

                                        }
                                    }

                                    else if (StockCount > 1)
                                    {
                                        int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(MAX(ID),0) from Stock WHERE ItemID = @ItemID and Cost = @Cost", UpdateOldStock2));

                                        SqlParameter[] UpdateMulStock = new SqlParameter[5];
                                        UpdateMulStock[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateMulStock[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                        UpdateMulStock[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                        UpdateMulStock[3] = new SqlParameter("@MaxID", MaxID);
                                        UpdateMulStock[4] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and Cost = @Cost and ID = @MaxID and Expiry = @Expiry", UpdateMulStock) > 0)
                                        {
                                            SqlParameter[] UpdateMulStock2 = new SqlParameter[5];
                                            UpdateMulStock2[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                            UpdateMulStock2[1] = new SqlParameter("@Cost", dt_PurchaseSum.Rows[j][1]);
                                            UpdateMulStock2[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                            UpdateMulStock2[3] = new SqlParameter("@MaxID", MaxID);
                                            UpdateMulStock2[4] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);
                                            if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and Cost = @Cost and ID != @MaxID and Expiry = @Expiry", UpdateMulStock2) > 0)
                                            {

                                            }
                                        }

                                    }
                                    else
                                    {
                                        int MaxID = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(ID,0) from Stock WHERE ItemID = @ItemID and Cost = @Cost and Expiry = @Expiry", UpdateOldStock2));
                                        
                                        SqlParameter[] UpdateOldStock3 = new SqlParameter[3];
                                        UpdateOldStock3[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateOldStock3[1] = new SqlParameter("@ID", MaxID);
                                        UpdateOldStock3[2] = new SqlParameter("@Quantity", PurchaseQuantity);
                                       // UpdateOldStock3[3] = new SqlParameter("@Expiry", dt_PurchaseSum.Rows[j][2]);

                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=@Quantity WHERE ItemID = @ItemID and ID = @ID", UpdateOldStock3) > 0)
                                        {

                                        }
                                        SqlParameter[] UpdateOldStock4 = new SqlParameter[2];
                                        UpdateOldStock4[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
                                        UpdateOldStock4[1] = new SqlParameter("@ID", MaxID);
                                        //UpdateOldStock3[2] = new SqlParameter("@Quantity", PurchaseQuantity);

                                        if (SQLHelper.Instance.ExecuteNonQueryWithParameter("Update Stock SET StockInHand=0 WHERE ItemID = @ItemID and ID != @ID", UpdateOldStock4) > 0)
                                        {

                                        }
                                    }

                                }
                                // update old stock ends - 15 march
                            }
					}
					else
					{
						AllItems InsertOld = new AllItems();
						if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][0].ToString()))
						{
							InsertOld.Quantity = Convert.ToInt32(dt_PurchaseSum.Rows[j][0]);
						}
						if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][1].ToString()))
						{
							InsertOld.Cost = Convert.ToDecimal(dt_PurchaseSum.Rows[j][1]);
						}
						if (!string.IsNullOrEmpty(dt_PurchaseSum.Rows[j][3].ToString()))
						{
							InsertOld.Expiry = Convert.ToDateTime(dt_PurchaseSum.Rows[j][2]);
						}
						InsertOld.ItemID = ItemID.Rows[i][0].ToString();
						AllItems.Add(InsertOld);
					}
						int StockQuantity = 0;
						SqlParameter[] StockParams = new SqlParameter[1];
						StockParams[0] = new SqlParameter("@ItemID", ItemID.Rows[i][0]);
						StockQuantity = Convert.ToInt32(SQLHelper.Instance.GetScalarQuery("select ISNULL(sum(StockInHand),0) from Stock where ItemID = @ItemID", StockParams));

					if (StockQuantity == AllPurchaseQuantity - SaleQuantity)
					{
							StockRun = 1;
					}
					}
                }



              //   }
              //  catch (Exception ex)
              //  {
              //      throw ex;
             //   }
             //   finally
             //   {
                    SQLHelper.Instance.conn.Close();
              //  }
               
            }
            return true;
        }

        public class AllItems{
            public string ItemID { get; set; }
            public decimal Cost { get; set; }
            public DateTime Expiry { get; set; }
            public DateTime DateCreated { get; set; }
            public int Quantity { get; set; }
        }

        public bool GetEmptyBarcodes()
        {
            try
            {
                // for null
                //SqlParameter[] Param = new SqlParameter[1];
                //Param[0] = new SqlParameter("@Status", '1');
                // var result = SQLHelper.Instance.GetReaderWithQuery("select Barcode, BarcodeID from [dbo].[Barcode] where barcode is null or barcode =' '",Param);
                SqlParameter[] sqlParam = new SqlParameter[1];
                sqlParam[0] = new SqlParameter("@Duplicate", 2);
                DataTable Result = SQLHelper.Instance.ExecuteQueryDatatabledata("Sp_Get_BarcodeDuplication", sqlParam);
                SQLHelper.Instance.conn.Open();
                bool IsTrue = false;
                for (int i = 0; i < Result.Rows.Count; i++)
                {
                    var Barcode = Convert.ToString(Result.Rows[i][0]);
                    int BarcodeID = Convert.ToInt32(Result.Rows[i][1]);
                    string GenerateBarcode = GenerateBarCode();
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@BarcodeID", BarcodeID);
                    param[1] = new SqlParameter("@Barcode", GenerateBarcode);
                    if (SQLHelper.Instance.ExecuteNonQuery("Sp_Update_BarcodeDuplication", param) > 0)
                    {
                        IsTrue = true;
                    }
                    else
                    {
                        IsTrue = false;//lst = null;return false;
                    }
                }
                SqlParameter[] sqlParam2 = new SqlParameter[1];
                sqlParam2[0] = new SqlParameter("@Duplicate", 2);
                DataTable ResultRecursive = SQLHelper.Instance.ExecuteQueryDatatabledata("Sp_Get_BarcodeDuplication", sqlParam2);
                if (ResultRecursive.Rows.Count > 0)
                {
                    GetEmptyBarcodes();
                }

                if (IsTrue) { return IsTrue; }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }

            return false;
        }

        public void RemoveDuplicate()
        {
            // for duplicate
            try
            {
                SqlParameter[] Param2 = new SqlParameter[1];
                Param2[0] = new SqlParameter("@Status", '1');
                var result2 = SQLHelper.Instance.GetReaderWithQuery("select o.Barcode, o.BarcodeID from Barcode o inner join ( SELECT Barcode, COUNT(*) AS dupeCount FROM Barcode GROUP BY Barcode HAVING COUNT(*) > 1 ) oc on o.Barcode = oc.Barcode", Param2);

                while (result2.Read())
                {
                    var Barcode2 = Convert.ToString(result2["Barcode"]);
                    int BarcodeID2 = Convert.ToInt32(result2["BarcodeID"]);
                    var GenerateBarcode2 = GenerateBarCode();
                    var Query2 = "update [dbo].[Barcode] set Barcode = '" + GenerateBarcode2 + "' where BarcodeID = " + BarcodeID2 + "";
                    using (SqlCommand sqlCmd = new SqlCommand(Query2, SQLHelper.Instance.conn))
                    {

                        sqlCmd.CommandType = CommandType.Text;
                        var res = sqlCmd.ExecuteReader();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateBarCode()
        {
            string barcode;
            Random ran = new Random();
            barcode = GetBarcodeWithCheckSum("21"+Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999)));

            //ObjItemCardBALClass.Objitemcardobjectclass.Barcode = barcode;

            return barcode;
            //if (!Check_DuplicateBarCode(barcode))
            //{
            //    return  barcode;
            //}
            //else
            //{
            //    GeneralFunction.ErrInfo(Constants.BARCODE, Results.Error.ToString());

            //    return  string.Empty;
            //}


        }
        public Boolean Check_DuplicateBarCode(string barcode)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@Barcode", barcode);
                if (Convert.ToInt32((SQLHelper.Instance.GetScalar(CHECK_BARCODE, sqlparam))) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public string GetBarcodeWithCheckSum(string barcode)
        {

            int index, checksum = 0;
            for (index = 1; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }
            checksum *= 3;
            for (index = 0; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }

            return barcode += (10 - checksum % 10) % 10;

        }


        public int LogOut_User(int UserId)
        {
            int i=0;
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[0];
                var Query = "UPDATE WorkTimeAttendance SET [Login] = 0, WorkStationID = 0 WHERE UserId =" + UserId+"";
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.conn.Open();
                    sqlCmd.CommandType = CommandType.Text;
                    i = sqlCmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex) { throw ex; }
            return i;
        }
        public DataTable Get_ExpiryItemList()
        {
            SqlParameter[] param=new SqlParameter[1];
            param[0] = new SqlParameter("@DateDiff",Convert.ToInt32(GeneralOptionSetting.FlagAlertExpiry));
            return SQLHelper.Instance.ExecuteQueryDatatable("usp_BBM_ShowExpiryItem", param, "ExpiryList");
        }
    }
}
