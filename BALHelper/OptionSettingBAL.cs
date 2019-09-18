using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using CommonHelper;
using System.Data;
using System.Collections;


namespace BALHelper
{
    public class OptionSettingBAL
    {
        OptionSettingDAL objOptionSettingDAL;
        OptionSettingsObject objOptionSettingsObjectClass;

        public OptionSettingBAL()
        {
            objOptionSettingDAL = new OptionSettingDAL();
            objOptionSettingsObjectClass = new OptionSettingsObject();
        }
        public OptionSettingsObject objOptionSettingsObject
        {
            get { return objOptionSettingsObjectClass; }
            set { objOptionSettingsObjectClass = value; }
        }
        public List<OptionSettingsObject> LoadOptions()
        {
            //List<OptionSettingsObject> lstOptions = objOptionSettingDAL.LoadOptions(objOptionSettingsObjectClass);
            //return lstOptions;
            return objOptionSettingDAL.LoadOptions(objOptionSettingsObjectClass);
        }


        public int UpdateLastBackupDate()
        {
            return objOptionSettingDAL.UpdateLastBackupDate(objOptionSettingsObjectClass.UserGroupID);

        }
        public void UpdateLoginStatus()
        {
            objOptionSettingDAL.UpdateLoginStatus();

        }

        public List<OptionSettingsObject> LoadLogo()
        {
            //List<OptionSettingsObject> lstLogo = objOptionSettingDAL.LoadLogo();
            //return lstLogo;
            return objOptionSettingDAL.LoadLogo();
        }


        public int SaveOptionSetting()
        {
            if (objOptionSettingDAL.SaveOptionSettingDetails(objOptionSettingsObjectClass) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public Boolean Update_CashClientName()
        {
            if (objOptionSettingDAL.Update_CashClientNameDetails(objOptionSettingsObjectClass) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean LogOut_User()
        {
            if (objOptionSettingDAL.LogOut_UserProcess(objOptionSettingsObjectClass) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean StartNewYear()
        {
            object Count = objOptionSettingDAL.CheckStartNewYear(objOptionSettingsObject.YearforStartNewYear);
            if (Convert.ToInt32(Count) == 0)
            {
                if (objOptionSettingDAL.StartNewYearProcess(objOptionSettingsObject.YearforStartNewYear) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                GeneralFunction.Information("Already Reseted", "StartNewYear");
                return false;
            }
        }

        public Boolean SaveNotificationDatesBal()
        {
            if (objOptionSettingDAL.SaveNotificationDates(objOptionSettingsObjectClass) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<EmployeeObjectClass> AddDefaultData()
        {
            EmployeeObjectClass obj = new EmployeeObjectClass();
            List<EmployeeObjectClass> lstUserGroup = new List<EmployeeObjectClass>();
            try
            {
                //***********Commented for Finalize the suggestion*****************//
                lstUserGroup.Add(new EmployeeObjectClass
                {
                    UserGrpId = Convert.ToInt32("101"),
                    UserGroupName = GeneralFunction.ChangeLanguageforCustomMsg("AllGroups")

                });

                if (GeneralObjectClass.UserGroupList.Count > 0)
                {
                    foreach (var lstUserGrb in GeneralObjectClass.UserGroupList)
                    {
                        String GroupName; int GroupID;
                        GroupID = Convert.ToInt32(lstUserGrb.UserGrpId);
                        GroupName = GeneralFunction.GroupTranslation(GroupID);
                        lstUserGroup.Add(new EmployeeObjectClass
                        {
                            UserGrpId = lstUserGrb.UserGrpId,
                            UserGroupName = (GroupName == string.Empty ? lstUserGrb.UserGroupName : GroupName)

                        });
                    }

                }
                //***********Commented for Finalize the suggestion*****************//
                //lstUserGroup = GeneralObjectClass.UserGroupList;
                var lst = from lstusrgrp in lstUserGroup
                          orderby lstusrgrp.UserGroupName
                          select lstusrgrp;


                return lst.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                lstUserGroup = null;
            }

        }
        public Boolean BALCleanDB()
        {
            if (objOptionSettingDAL.CleanDB(objOptionSettingsObject))
                return true;
            else
                return false;
        }
        //public DataTable Get_CompanyLogoDetails()
        //{

        // return    objOptionSettingDAL.CompanyLogoDetails(objOptionSettingsObjectClass);           

        //}
        public Boolean AddedQuantity()
        {
            if (objOptionSettingDAL.AddRandomQuantity())
                return true;
            else
                return false;
        }

        public int UpdateuserUnlock()
        {
            return objOptionSettingDAL.Save_UserUnLockDetails();
        }
        public void AgentDept()
        {
            BalanceSheetBAL objbalBAL = new BalanceSheetBAL();
            try
            {
                decimal decBalance = 0, decAmt = 0, decRec = 0, decDiscount = 0;// decTotal = 0;
                if (GeneralFunction.isCleanDB)
                { GetAgentId(); }
                if (GeneralFunction.AgentId.Count <= 0) return;
                for (int index = 0; index < GeneralFunction.AgentId.Count; index++)
                {
                    if (GeneralFunction.AgentId[index].ToString() != string.Empty)
                    {
                        objbalBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(GeneralFunction.AgentId[index]);
                        objbalBAL.objBalanceSheetObjcetClass.BalanceFromDate = DateTime.Now;
                        objbalBAL.objBalanceSheetObjcetClass.BalanceToDate = DateTime.Now;
                        objbalBAL.objBalanceSheetObjcetClass.Status = 1;
                        DataTable dtBalance = new DataTable();
                        dtBalance = objbalBAL.GetBalanceDetails();
                        if (dtBalance.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtBalance.Rows.Count; i++)
                            {
                                decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]);
                                decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]);
                                decDiscount = decDiscount + Convert.ToDecimal(dtBalance.Rows[i]["Discount"]);

                                //if (dtBalance.Rows[i]["MTB_AMT_RECEIVED"].ToString() == "0.0000")
                                //{
                                //    decTotal = (decAmt + decRec);
                                //    decBalance = decTotal;
                                //}
                                //else
                                //{
                                //    decBalance = (decTotal - decRec);
                                //}
                            }
                            decBalance = decRec - decAmt;

                            if (GeneralFunction.isCleanDB)
                            {
                                objbalBAL.objBalanceSheetObjcetClass.Balance = decBalance;
                                objbalBAL.objBalanceSheetObjcetClass.Discount = decDiscount;
                                objbalBAL.objBalanceSheetObjcetClass.AmountPaid = decAmt;
                                objbalBAL.objBalanceSheetObjcetClass.AmountReceived = decRec;
                                objbalBAL.objBalanceSheetObjcetClass.ProcessDate = DateTime.Now;
                                objbalBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(GeneralFunction.AgentId[index]);
                                objbalBAL.objBalanceSheetObjcetClass.Description = GeneralFunction.CleanDBDescription;
                                objbalBAL.objBalanceSheetObjcetClass.Status = 1;
                                BalanceSheetDAL.Save_AgentDebt(objbalBAL.objBalanceSheetObjcetClass);
                                decBalance = decAmt = decDiscount = decRec = 0.000M;

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objbalBAL = null;
            }
        }
        public static ArrayList GetAgentId()
        {
            try
            {
                GeneralFunction.AgentId.Clear();

                DataTable dtLocal = BalanceSheetDAL.Get_AllAgentNames();
                if (dtLocal != null && dtLocal.Rows.Count > 0)
                {
                    for (int i = 0; i < dtLocal.Rows.Count; i++)
                    {
                        GeneralFunction.AgentId.Add(dtLocal.Rows[i]["AGENTID"].ToString());
                    }
                }
                return GeneralFunction.AgentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllItems()
        {
            return objOptionSettingDAL.GetExportItem();
        }
    }
}
