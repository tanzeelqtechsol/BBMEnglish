using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;
using CommonHelper;

namespace DataBaseHelper.DALClass
{
    public class OptionSettingDAL
    {
        #region Constant Variables
        private const string SPNameSpGetOption = "SP_Get_Option";
        private const string SPNameSpGetLogo = "SP_Get_Logo";
        private const string SPNameSpSaveOption = "SP_Save_Option";
        private const string SPNameUpdateCashClientName = "SP_UpdateCashClient";
        private const string SPLogoutUser = "SP_Log_Out_User";
        private const string SPStartNewYear = "SP_Start_NewYear";
        private const string SPNameSaveNotificationDates = "SP_Save_NotificationDates";
        private const string SPSavDefaultOptionSettings = "Usp_Save_DefaultOptionSettings";
        private const string SPCheckStartNewYear = "usp_BBM_CheckStartNewYear";
        private const string SPNAMESAVEUSERUnlock = "SP_Save_UserUnLock";
        #endregion


        #region Methods
        public List<OptionSettingsObject> LoadOptions(OptionSettingsObject ObjOptionSettings)
        {
            List<OptionSettingsObject> lstOptions = new List<OptionSettingsObject>();
            try
            {
                var reader = SQLHelper.Instance.GetReader("select * from OptionDetails where UserGroupID =" + ObjOptionSettings.UserGroupID + "");
                while (reader.Read())
                {

                    lstOptions.Add(new OptionSettingsObject
                    {
                        //  OptionValue = reader[1].ToString(),
                        OptionFlag = reader[3].ToString(),
                        OptionDateNotify = Convert.ToDateTime(reader[4])
                    });
                }
            }
            catch
            {
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return lstOptions;
        }
        public void UpdateLoginStatus()
        {

            try
            {

                var reader = SQLHelper.Instance.ExecuteNonQueryWithParameter("Update WorkTimeAttendance Set Login=0,WorkStationID=0 ");

            }
            catch
            {
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }

        }
        public int UpdateLastBackupDate(int UserGroupID)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];

                sqlparam[0] = new SqlParameter("@USER_ID", UserGroupID);
                if ((SQLHelper.Instance.ExecuteNonQueryWithParameter("UPDATE OptionDetails SET [FLAG]=GetDate(),ModifiedDate=GetDate() WHERE UserGroupID=@USER_ID AND OptionID=96", sqlparam)) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex) { throw ex; }
        }


        public List<OptionSettingsObject> LoadLogo()
        {
            List<OptionSettingsObject> lstLogo = new List<OptionSettingsObject>();
            try
            {
                // SqlParameter[] param = new SqlParameter[0];
                var reader = SQLHelper.Instance.GetReader("select HeaderLogo as HeaderLogo,FooterLogo as FooterLogo from Logo");
                while (reader.Read())
                {

                    lstLogo.Add(new OptionSettingsObject
                    {

                        HeaderLogo = (byte[])reader[0],
                        FooterLogo = (byte[])reader[1]

                    });

                }
            }
            catch
            {
            }
            finally
            {
                if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
            }
            return lstLogo;
        }

        public int SaveOptionSettingDetails(OptionSettingsObject ObjOptionSettings)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];

            try
            {
                sqlparam[0] = new SqlParameter("@Optionstring", ObjOptionSettings.OptionValue);
                sqlparam[1] = new SqlParameter("@HeaderLogo", ObjOptionSettings.HeaderLogo);
                sqlparam[2] = new SqlParameter("@FooterLogo", ObjOptionSettings.FooterLogo);
                sqlparam[3] = new SqlParameter("@UserGroupID", ObjOptionSettings.UserGroupID);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSpSaveOption, sqlparam) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update_CashClientNameDetails(OptionSettingsObject ObjOptionSettings)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@Language", ObjOptionSettings.OptionLangage);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameUpdateCashClientName, sqlparam) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int LogOut_UserProcess(OptionSettingsObject ObjOptionSettings)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];

                sqlparam[0] = new SqlParameter("@USER_ID", ObjOptionSettings.UserId);
                if ((SQLHelper.Instance.ExecuteNonQueryWithParameter("UPDATE WorkTimeAttendance SET [Login]=0,WorkStationID=0 WHERE UserId=@USER_ID", sqlparam)) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public int StartNewYearProcess(int YearValue)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                // sqlparam[0] = new SqlParameter("@Language", ObjOptionSettings.OptionLangage);
                sqlparam[0] = new SqlParameter("@YearValue", YearValue);
                if (SQLHelper.Instance.ExecuteNonQuery(SPStartNewYear, sqlparam) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Check New Year 
        /// CreatedBY Meena.R
        /// </summary>
        /// <param name="objOption"></param>
        /// <returns></returns>
        /// 
        public object CheckStartNewYear(int YearValue)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@YearValue", YearValue);
                return SQLHelper.Instance.GetScalar(SPCheckStartNewYear, param);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int SaveNotificationDates(OptionSettingsObject objOption)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@LicenseRenewal", objOption.FlagLicenserenewalDate);
                param[1] = new SqlParameter("@MedicalInsurence", objOption.FlagMedicalInsuranceDate);
                param[2] = new SqlParameter("@CertificateHealth", objOption.FlagCertificateofHealthDate);
                param[3] = new SqlParameter("@AttenancePermit", objOption.FlagAttendancePermitDate);
                param[4] = new SqlParameter("@Zakat", objOption.FlagZakatDate);
                param[5] = new SqlParameter("@TechnicalDisclosure", objOption.FlagTechnicalDisclosureDate);
                param[6] = new SqlParameter("@PriceDate", objOption.FlagPricingDate);
                param[7] = new SqlParameter("@PaymentDate", objOption.FlagPayrentDate);
                param[8] = new SqlParameter("@DisbursementSalary", objOption.FlagDisbursementSalaryDate);
                param[9] = new SqlParameter("@AnnualInventory", objOption.FlagAnnualInventoryDate);
                param[10] = new SqlParameter("@UserGroupID", objOption.UserGroupID);
                if (SQLHelper.Instance.ExecuteNonQuery(SPNameSaveNotificationDates, param) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Boolean CleanDB(OptionSettingsObject objOption)
        {
            try
            {
                SqlParameter[] sqlprm = new SqlParameter[9];
                sqlprm[0] = new SqlParameter("@option", objOption.OptionDB);
                sqlprm[1] = new SqlParameter("@Itemandbarcode", objOption.Itemandbarcode);
                sqlprm[2] = new SqlParameter("@AgentInfo", objOption.AgentInfo);
                sqlprm[3] = new SqlParameter("@Spendings", objOption.Spendings);
                sqlprm[4] = new SqlParameter("@EmpInfo", objOption.EmpInfo);
                sqlprm[5] = new SqlParameter("@UserInfo", objOption.UserInfo);
                sqlprm[6] = new SqlParameter("@MoveCreditofAgents", objOption.MoveCreditofAgents);
                sqlprm[7] = new SqlParameter("@Description", objOption.Description == null ? string.Empty : objOption.Description);
                sqlprm[8] = new SqlParameter("@MoveStocktoInventory", objOption.MoveStocktoInventory);
                if (SQLHelper.Instance.ExecuteNonQuery("SP_CleanDB", sqlprm) > 0)
                    return true;
                else
                    return false;

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
        //public DataTable CompanyLogoDetails(OptionSettingsObject objOption)
        //{
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@UserId", objOption.UserGroupID);

        //        return SQLHelper.Instance.ExecuteQueryDatatable("USP_Get_CompanyLogo", param, "CompanyInfo");

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public Boolean AddRandomQuantity()
        {
            SqlParameter[] sqlprm = new SqlParameter[0];
            if (SQLHelper.Instance.ExecuteNonQuery("usp_BBM_AddItemQuantity", sqlprm) > 0)
                return true;
            else
                return false;
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

        #endregion
        public DataTable GetExportItem()
        {
            SqlParameter[] param = new SqlParameter[0];
            return SQLHelper.Instance.ExecuteQueryDatatable("SP_ExportData", param,"Items");
        }
    }
}
