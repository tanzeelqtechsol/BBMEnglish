using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using ObjectHelper;
using System.Collections.Generic;
using CommonHelper;
using System.Diagnostics;

namespace DataBaseHelper.DALClass
{
    public class MasterDataDALClass
    {

        private const string SPNAMESAVEUSERUnlock = "SP_Save_UserUnLock";

        //public List<PurchaseObjectClass> GetSupllier()
        //{
        //    try
        //    {
        //        var Query = "select AgentID,AgentName from Agent where AgentTypeID like '%102%'and Status=1 order by AgentName";
        //        using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
        //        {
        //            SQLHelper.Instance.conn.Open();
        //            sqlCmd.CommandType = CommandType.Text;
        //            var result = sqlCmd.ExecuteReader();
        //            while (result.Read())
        //            {
        //                GeneralObjectClass.SupplierDetails.Add(new PurchaseObjectClass
        //                {
        //                    SupplierNo = Convert.ToInt32(result[0]),
        //                    SupplierName = result[1].ToString()
        //                });
        //            }
        //        }
        //        return GeneralObjectClass.SupplierDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        SQLHelper.Instance.conn.Close();
        //    }
        //}

        public List<AgentDetailObjectClass> GetAgentDetails()
        {
            try
            {
                GeneralObjectClass.AgentDetails.Clear();
                GeneralObjectClass.SupplierDetails.Clear();
                GeneralObjectClass.DebtAgents.Clear();
                //var Query = "Select AgentID,AgentName,AgentTypeID from Agent where status<>0 Order By AgentName";
                //using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                //{
                //    SQLHelper.Instance.conn.Open();
                //    sqlCmd.CommandType = CommandType.Text;
                //    var result = sqlCmd.ExecuteReader();
                //    while (result.Read())
                //    {
                //        GeneralObjectClass.AgentDetails.Add(new AgentDetailObjectClass
                //        {
                //            AgentId = Convert.ToInt32(result[0]),
                //            Name = result[1].ToString(),
                //            AgentType = result[2].ToString()

                //        });

                //    }
                //}

                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader("SP_Get_AllAgent", param);

                //This is added to display dynamic cash client
                string lang = System.Configuration.ConfigurationManager.AppSettings["Language"];
                string client = string.Empty; string name = string.Empty;
                if (lang == "Arabic")
                {
                    client = "زبون نقدي";
                    //Additional_Barcode.GetValueByResourceKey("CashClient");

                }
                else
                {
                    client = "CASH CLIENT";
                }
                while (result.Read())
                {
                    int AgntId = Convert.ToInt32(result[0]);
                    if (AgntId == Convert.ToInt16(CommonHelper.CashClientID.ID))
                        name = client;
                    else
                        name = result[1].ToString();
                    GeneralObjectClass.AgentDetails.Add(new AgentDetailObjectClass
                    {
                        AgentId = Convert.ToInt32(result[0]),
                        Name = name,
                        AgentType = result[2].ToString(),
                        Discount = Convert.ToInt32(result[3])
                    });

                }


                GeneralObjectClass.SupplierDetails = (from list in GeneralObjectClass.AgentDetails where list.AgentType.Contains("102") && (!list.AgentType.Contains("104")) orderby list.Name select list).ToList();
                //GeneralObjectClass.SupplierDetails = GeneralObjectClass.AgentDetails.Where(a => a.AgentType.Contains("102") && (!a.AgentType.Contains("104"))).ToList().OrderBy(a => a.Name).ToList();
                GeneralObjectClass.DebtAgents = (from list in GeneralObjectClass.AgentDetails where (!list.AgentType.Contains("104")) && list.AgentId != 1001 orderby list.Name select list).ToList();
                return GeneralObjectClass.AgentDetails;
            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<ComCatObjectClass> GetCategoryDetails()
        {
            try
            {
                // var Query = "select CategoryID,CategoryName,FieldName from Category where Status<>0 Order By CategoryID";
                // var Query = "select CategoryID,CategoryName,FieldName,Printer from Category where Status<>0 Order By CategoryID";//////Include the name of the [printer assign to categhory on 30 jlu y 2014
                var Query = "select CategoryID,CategoryName,FieldName,Printer from Category where Status<>0 and CategoryID = 1001 union select CategoryID,CategoryName,FieldName,Printer from Category where Status<>0 and CategoryID != 1001";
                GeneralObjectClass.CategoryList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.CategoryList.Add(new ComCatObjectClass
                        {
                            CategoryID = Convert.ToInt32(result[0]),
                            Category = result[1].ToString(),
                            FieldCategory = result[2].ToString(),
                            Printer = result[3].ToString()
                        });
                    }
                }
                return GeneralObjectClass.CategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<ComCatObjectClass> GetCompanyDetails()
        {
            try
            {
                var Query = "select CompanyID,CompanyName,FieldName from Company where status<>0 and CompanyID = 1001 union select CompanyID,CompanyName,FieldName from Company where status<>0 and CompanyID != 1001";
                GeneralObjectClass.CompanyList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.CompanyList.Add(new ComCatObjectClass
                        {
                            CompanyID = Convert.ToInt32(result[0]),
                            Company = result[1].ToString(),
                            FieldCompany = result[2].ToString()
                        });
                    }
                }
                return GeneralObjectClass.CompanyList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<BankObjectClass> GetBankDetails()
        {
            try
            {
                var Query = "SELECT BankID,BankName from Bank WHERE Status=1 ORDER BY BankName";
                GeneralObjectClass.BankList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.BankList.Add(new BankObjectClass
                        {
                            BankNameID = Convert.ToInt32(result[0]),
                            BankName = result[1].ToString()
                        });
                    }
                }
                return GeneralObjectClass.BankList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<BankObjectClass> BranchDetails()
        {
            try
            {
                var Query = "SELECT BranchID,BranchName FROM Branch WHERE status=1 ORDER BY BranchName";
                GeneralObjectClass.BranchList.Clear();
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.BranchList.Add(new BankObjectClass
                        {
                            BranchNameID = Convert.ToInt32(result[0]),
                            BranchName = result[1].ToString()
                        });
                    }
                }
                return GeneralObjectClass.BranchList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<ItemCardObjectClass> ItemDetails()
        {
            try
            {
                GeneralObjectClass.ItemDetails.Clear();

                // var Query = "SELECT ItemID,ItemName,Barcode,CategoryID,ItemType,ItemPlaceID,ItemDescription,Unit,CompanyID,ItemCost,ItemLastCost,PackageQty,ExpiryDate,Reorder,WholeSalePrice,Price,MaxOrder,MinPrice,AverageCost,IsHide,ItemNumber from Item Where Status<>0 ORDER BY ITemName";
                //using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                //{

                //    SQLHelper.Instance.conn.Open();
                //    sqlCmd.CommandType = CommandType.Text;
                // var result = SQLHelper.Instance.GetReader("Get_ItemLoadDetails",null);

                //Login Performance issue fixed by Praba on 27-Jun-2014
                DataTable dt = SQLHelper.Instance.ExecuteQueryDatatable("Get_ItemLoadDetails", null, "item2");
                //DataTable dt = new DataTable();
                //dt.Load(result);
                //return (List<ItemCardObjectClass>)ConvertionHelper.ConvertToList<ItemCardObjectClass>(dt);

                //while (result.Read())
                foreach (DataRow result in dt.Rows)
                {
                    GeneralObjectClass.ItemDetails.Add(new ItemCardObjectClass
                    {
                        ItemId = Convert.ToInt32(result["ItemID"]),
                        Items = result["ItemName"].ToString(),
                        Barcode = result["Barcode"] == DBNull.Value ? string.Empty : result["Barcode"].ToString(),
                        CategoryId = Convert.ToInt32(result["CategoryID"]),
                        ItemType = Convert.ToInt32(result["ItemType"]),
                        ItemPlaceId = Convert.ToInt32(result["ItemPlaceID"]),
                        ItemDescription = result["ItemDescription"].ToString(),
                        // Unit = Convert.ToInt32(result["Unit"]),
                        CompId = Convert.ToInt32(result["CompanyID"]),
                        ItemCost = result["ItemCost"] == DBNull.Value ? 0.000m : Convert.ToDecimal(result["ItemCost"]),
                        ItemLastCost = result["ItemLastCost"] == DBNull.Value ? 0.000m : Convert.ToDecimal(result["ItemLastCost"]),
                        PackageQuantity = Convert.ToInt32(result["PackageQty"] == DBNull.Value ? 0 : result["PackageQty"]),
                        ExpiryDate = Convert.ToBoolean(result["ExpiryDate"]),
                        Reorder = Convert.ToInt32(result["Reorder"]),
                        WholeSalePrice = result["WholeSalePrice"] == DBNull.Value ? 0.000m : Convert.ToDecimal(result["WholeSalePrice"]),
                        Price = result["Price"] == DBNull.Value ? 0.000m : Convert.ToDecimal(result["Price"]),
                        Maxorder = Convert.ToInt32(result["MaxOrder"]),
                        MinPrice = Convert.ToDecimal(result["MinPrice"] == DBNull.Value ? 0.000m : result["MinPrice"]),
                        AverageCost = result["AverageCost"] == DBNull.Value ? 0.000m : Convert.ToDecimal(result["AverageCost"]),
                        IsHide = Convert.ToBoolean(result["IsHide"] == DBNull.Value ? false : result["IsHide"]),
                        ItemNumber = result["ItemNumber"].ToString(),
                        BarcodeId = Convert.ToInt32(result["BarcodeID"])
                    });
                }


                //----------------This is added by manoj to display all items based on sorted ascending
                GeneralObjectClass.ItemDetails.Sort(delegate(ItemCardObjectClass Item1, ItemCardObjectClass Item2)
                {
                    return Item1.Items.CompareTo(Item2.Items);
                });
                //------------------------------------
                return GeneralObjectClass.ItemDetails;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public List<EmployeeObjectClass> UserDetails()
        {
            try
            {
                // var Query = "select UserId,FirstName from [User] where status=1";
                GeneralObjectClass.UserList.Clear();
                var Query = " select UserId,FirstName,UserName,[Password],UserGroupID,[Status],EmployeeUserFlag from [User]";
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.UserList.Add(new EmployeeObjectClass
                        {
                            UserId = Convert.ToInt32(result[0]),
                            FirstName = result[1].ToString(),
                            UserName = result[2].ToString(),
                            Password = result[3].ToString(),
                            GroupID = Convert.ToInt32(result[4] == DBNull.Value ? 0 : result[4]),
                            Status = Convert.ToInt32(result[5]),
                            EmployeeUserFlag = Convert.ToInt32(result[6])
                        });
                    }
                }
                return GeneralObjectClass.UserList;
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

        private int itemIndex = 0;
        public List<EmployeeObjectClass> UserGroupDetails()
        {
            try
            {

                // var Query = "select UserId,FirstName from [User] where status=1";
                GeneralObjectClass.UserGroupList.Clear();
                var Query = "SELECT Distinct [UserGroupID],[UserGroupName]  FROM [dbo].[UserGroup]  WHERE  Status=1";
                using (SqlCommand sqlCmd = new SqlCommand(Query, SQLHelper.Instance.conn))
                {
                    SQLHelper.Instance.OpenConnection();
                    sqlCmd.CommandType = CommandType.Text;
                    var result = sqlCmd.ExecuteReader();
                    while (result.Read())
                    {
                        GeneralObjectClass.UserGroupList.Add(new EmployeeObjectClass
                        {
                            UserGrpId = Convert.ToInt32(result[0]),
                            UserGroupName = result[1].ToString()

                        });
                    }
                }
                return GeneralObjectClass.UserGroupList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }
        public List<ItemCardObjectClass> UnitNameOfItem()
        {
            try
            {
                GeneralObjectClass.DefaultUnitName.Clear();
                var result = SQLHelper.Instance.GetReader("Usp_GetCommonUnitName", null);

                while (result.Read())
                {
                    GeneralObjectClass.DefaultUnitName.Add(new ItemCardObjectClass
                    {
                        GeneralID = Convert.ToInt32(result[0]),
                        ID = Convert.ToInt32(result[1]),
                        Name = result[2].ToString(),
                        UnitQuantity = result[3].ToString(),

                    });
                }

                return GeneralObjectClass.DefaultUnitName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
        }

        public int Save_UserUnLockDetails()
        {
            try
            {
                SqlParameter[] Sqlparam = new SqlParameter[1];
                Sqlparam[0] = new SqlParameter("@WORKSTATIONNAME", GeneralFunction.workstationName);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNAMESAVEUSERUnlock, Sqlparam) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
