using System;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;
using System.Collections.Generic;

namespace DataBaseHelper.DALClass
{
    public class ComCatDALClass
    {
        #region AssignProcedureName


        private const string SPNameCheckPrimeryNames = "SP_Check_PrimaryNames";
        private const string SpNameSaveCategory = "SP_Save_Category";
        private const string SPNameSaveCompany = "Sp_Save_Company";
        private const string SPNameSaveItemPlace = "Sp_Save_Itemplace";
        private const string SPNameSaveBank = "Sp_Save_Bank";
        private const string SPNameSaveBranch = "Sp_Save_Branch";
        private const string SPNameGetCategory = "Sp_Get_Category";
        private const string SPNameGetCompany = "Sp_Get_Company";
        private const string SPNameGetitemPlace = "Sp_Get_Itemplace";
        private const string SPNameGetBank = "Sp_Get_Bank";
        private const string SPNameGetBranch = "Sp_Get_Branch";
        #endregion

        MasterDataDALClass ObjMasterDAL = new MasterDataDALClass();

        #region Method

        public bool Check_PrimeryNames(ComCatObjectClass ComCatObj)
        {


            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Name", ComCatObj.Category);
                param[1] = new SqlParameter("@Option", ComCatObj.Company);
                param[2] = new SqlParameter("@ID", ComCatObj.CommonId);
                // dt = SQLHelper.Instance.ExecuteQueryDatatable(SPNameCheckPrimeryNames, param, "PrimeryNames");
                if (Convert.ToInt32(SQLHelper.Instance.GetScalar(SPNameCheckPrimeryNames, param)) > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int savecategory(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@CategoryID", ComCatObj.CategoryID);
                param[1] = new SqlParameter("@CategoryName", ComCatObj.Category);
                param[2] = new SqlParameter("@FieldName", ComCatObj.FieldCategory == string.Empty ? GeneralObjectClass.CategoryList[0].FieldCategory : ComCatObj.FieldCategory);
                param[3] = new SqlParameter("@CreatedBy", ComCatObj.CreatedBy);
                param[4] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);
                param[5] = new SqlParameter("@Status", 1);
                param[6] = new SqlParameter("@Printer", ComCatObj.Printer);


                if (SQLHelper.Instance.ExecuteNonQuery(SpNameSaveCategory, param) > 0)
                {
                    ObjMasterDAL.GetCategoryDetails();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }
        }
        public int DeleteCategory(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", ComCatObj.CategoryID);
                param[1] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);

                param[0].Value = ComCatObj.CategoryID;
                param[0].Direction = ParameterDirection.InputOutput;
                ComCatObj.CategoryID = SQLHelper.Instance.ExecuteNonQuery("USP_SP_DeleteCategoryDetails", param);
                if (ComCatObj.CategoryID > 0)
                {
                    ObjMasterDAL.GetCategoryDetails();
                    return 1;
                }
                else
                    return 0;

            }
            catch (Exception ex) { throw ex; }

        }
        public int DeleteCompany(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CompanyID", ComCatObj.CompanyID);
                param[1] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);

                param[0].Value = ComCatObj.CompanyID;
                param[0].Direction = ParameterDirection.InputOutput;
                ComCatObj.CompanyID = SQLHelper.Instance.ExecuteNonQuery("USP_SP_DeleteCompanyDetails", param);
                if (ComCatObj.CompanyID > 0)
                {
                    ObjMasterDAL.GetCompanyDetails();
                    return 1;
                }
                else return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int DeleteItemPlace(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ItemplaceID", ComCatObj.ItemPlaceID);
                param[1] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);


                if (SQLHelper.Instance.ExecuteNonQuery("USP_SP_DeleteItemPlaceDetails", param) > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int DeleteBank(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@BankID", ComCatObj.BankID);
                param[1] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);


                if (SQLHelper.Instance.ExecuteNonQuery("USP_SP_DeleteBankDetails", param) > 0)
                {
                    ObjMasterDAL.GetBankDetails();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int DeleteBranch(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@BranchID", ComCatObj.BranchID);
                param[1] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);

                if (SQLHelper.Instance.ExecuteNonQuery("USP_SP_DeleteBranchDetails", param) > 0)
                {
                    ObjMasterDAL.BranchDetails();
                    return 1;
                }
                return 0;

            }
            catch (Exception ex) { throw ex; }

        }
        public int savecompany(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@CompanyID", ComCatObj.CompanyID);
                param[1] = new SqlParameter("@CompanyName", ComCatObj.CompanyName);
                param[2] = new SqlParameter("@FieldName", ComCatObj.FieldCompany==string.Empty?GeneralObjectClass.CompanyList[0].FieldCompany:ComCatObj.FieldCompany);
                param[3] = new SqlParameter("@CreatedBy", ComCatObj.CreatedBy);
                param[4] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);
                param[5] = new SqlParameter("@Status", 1);


                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveCompany, param) > 0)
                {
                    ObjMasterDAL.GetCompanyDetails();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int saveitemplace(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PlaceName", ComCatObj.ItemPlace);
                param[1] = new SqlParameter("@CreatedBy", ComCatObj.CreatedBy);
                param[2] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);
                param[3] = new SqlParameter("@Status", 1);
                param[4] = new SqlParameter("@ItemPlaceID", ComCatObj.CommonId);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveItemPlace, param) > 0)
                {

                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int savebank(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@BankName", ComCatObj.BankName);
                param[1] = new SqlParameter("@CreatedBy", ComCatObj.CreatedBy);
                param[2] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);
                param[3] = new SqlParameter("@Status", 1);
                param[4] = new SqlParameter("@BankID", ComCatObj.CommonId);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveBank, param) > 0)
                {
                    ObjMasterDAL.GetBankDetails();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public int savebranch(ComCatObjectClass ComCatObj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@BranchName", ComCatObj.BranchName);
                param[1] = new SqlParameter("@CreatedBy", ComCatObj.CreatedBy);
                param[2] = new SqlParameter("@ModifiedBy", ComCatObj.ModifiedBy);
                param[3] = new SqlParameter("@Status", 1);
                param[4] = new SqlParameter("@BranchID", ComCatObj.CommonId);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveBranch, param) > 0)
                {
                    ObjMasterDAL.BranchDetails();
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public List<ComCatObjectClass> GetCategory()
        {
            List<ComCatObjectClass> GetCatList = new List<ComCatObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                //var result = SQLHelper.Instance.GetReader("select CategoryID as 'CategoryID',CategoryName AS 'CategoryName',FieldName AS 'FieldName' from Category WHERE CategoryID<>101  and Status<>0");
                var result = SQLHelper.Instance.GetReader("select CategoryID as 'CategoryID',CategoryName AS 'CategoryName',FieldName AS 'FieldName' ,Printer AS 'Printer'from Category WHERE CategoryID<>1001  and Status<>0");///Include the Printer name for particular category on 30 jluy 2014
                while (result.Read())
                {

                    GetCatList.Add(new ComCatObjectClass { CategoryID = Convert.ToInt32(result["CategoryID"]), Category = result["CategoryName"].ToString(), FieldCategory = result["FieldName"].ToString(),Printer =result["Printer"] .ToString()});
                }
                // dt = SQLHelper.Instance.ExecuteQueryDatatable(SPNameGetCategory, param, "Category");
                result.Close();
                return GetCatList;
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
        public List<ComCatObjectClass> GetCompany()
        {
            //  DataTable dt = new DataTable();
            List<ComCatObjectClass> ComList = new List<ComCatObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader("select CompanyID AS 'CompanyID',CompanyName AS 'CompanyName',FieldName AS 'FieldName'  from Company WHERE CompanyID<>1001 and Status<>0");
                while (result.Read())
                {
                    ComList.Add(new ComCatObjectClass { CompanyID = Convert.ToInt32(result["CompanyID"]), Company = result["CompanyName"].ToString(), FieldCompany = result["FieldName"].ToString() });
                }
                result.Close();
                return ComList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }

        }
        public List<ComCatObjectClass> GetItemplace()
        {
            List<ComCatObjectClass> ItemPlaceList = new List<ComCatObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader("select ItemPlaceID AS 'ItemPlaceID',PlaceName AS 'ItemPlaceName' from ItemPlace WHERE Status<>0 ");
                while (result.Read())
                {
                    ItemPlaceList.Add(new ComCatObjectClass { CompanyID = Convert.ToInt32(result["ItemPlaceID"]), ItemPlace = result["ItemPlaceName"].ToString() });
                }
                result.Close();
                return ItemPlaceList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public List<ComCatObjectClass> GetBank()
        {
            List<ComCatObjectClass> BankList = new List<ComCatObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader("select BankID AS 'BankID',BankName AS 'BankName' from Bank where Status<>0");
                while (result.Read())
                {
                    BankList.Add(new ComCatObjectClass { CompanyID = Convert.ToInt32(result["BankID"]), BankName = result["BankName"].ToString() });
                }
                result.Close();
                return BankList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public List<ComCatObjectClass> GetBranch()
        {
            List<ComCatObjectClass> BranchList = new List<ComCatObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader("select BranchID AS 'BranchID',BranchName AS 'BranchName' from Branch WHERE Status<>0");
                while (result.Read())
                {
                    BranchList.Add(new ComCatObjectClass { CompanyID = Convert.ToInt32(result["BranchID"]), BranchName = result["BranchName"].ToString() });

                }
                result.Close();
                return BranchList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public Boolean SaveItemUnit(ComCatObjectClass ObjComCat)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@UnitName", ObjComCat.UnitName+ "-" + ObjComCat.UnitQuantity);
            param[1] = new SqlParameter("@CreatedBy", ObjComCat.CreatedBy);
            param[2] = new SqlParameter("@ModifiedBy", ObjComCat.ModifiedBy);
            param[3] = new SqlParameter("@GeneralTypeID", ObjComCat.CommonId);
            if (SQLHelper.Instance.ExecuteNonQuery("usp_Save_ItemUnit", param) > 0)
            {
                ////ObjMasterDAL.UnitNameOfItem();
                return true;
            }
            else
                return false;
        }
        public List<ComCatObjectClass> GetItemUnit()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                List<ComCatObjectClass> ItemUnit = new List<ComCatObjectClass>();
                var result = SQLHelper.Instance.GetReader("Get_ItemUnit", param);
                while (result.Read())
                {
                    ItemUnit.Add(new ComCatObjectClass
                    {
                        GeneralTypeID = Convert.ToInt32(result["ID"]),
                        UnitName = result["UnitName"].ToString(),
                        UnitQuantity = result["UnitQuantity"].ToString()
                    });
                }
                result.Close();
                return ItemUnit;
            }
            catch (Exception)
            {
                throw;
            }
            finally { SQLHelper.Instance.conn.Close(); }
        }
        public bool DeleteItemUnit(ComCatObjectClass ObjComCat)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@GeneralID", ObjComCat.CommonId);
            param[1] = new SqlParameter("@GeneralName", ObjComCat.UnitName + "-" + ObjComCat.UnitQuantity);
            if (SQLHelper.Instance.ExecuteNonQuery("usp_Delete_ItemUnit", param) > 0)
            {
                ObjMasterDAL.UnitNameOfItem();
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
