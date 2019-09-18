using System;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;
using System.Windows.Forms;
using DataBaseHelper;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace BALHelper
{
    public class BALClass
    {
        private LoginDAL dal;
        private LoginObjectClass itemObject;
        private AddressPhoneBookObjectClass agentdetailobject;
        public string UserId;

        public LoginObjectClass ItemObject
        {
            get { return itemObject; }
            set { itemObject = value; }
        }
        public AddressPhoneBookObjectClass AgentDetailObject
        {
            get { return agentdetailobject; }
            set { agentdetailobject = value; }
        }
        public void SetAgentObject()
        {
            AgentDetailObject = new AddressPhoneBookObjectClass();
        }
        public BALClass()
        {
            dal = new LoginDAL();
        }

        public void SetItemObject()
        {
            ItemObject = new LoginObjectClass();
            AgentDetailObject = new AddressPhoneBookObjectClass();
        }

        public bool Check_Userlogin()
        {
            try
            {
                var dt = new DataTable();

            //    dt = dal.Check_UserLogin(ItemObject);
                if (dt != null && dt.Rows.Count > 0)
                {
                    UserId = dt.Rows[0]["MTB_USER_ID"].ToString();
                    return true;
                }
                else
                  return false;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool Save_AdrressPhone()
        {
            try
            {
                if (dal.savephonebook(AgentDetailObject) > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public DataTable PhoneBookDetails()
        {
            DataTable dt = new DataTable();
            dt = dal.getallagentdetails();
             return dt;
        
        }
        public DataTable GetCompany()
        {
            DataTable dt = new DataTable();
            dt=dal.getcompany();
            return dt;
        }
        public DataTable GetAgentName()
        {
            DataTable dt = new DataTable();
            dt=dal.setagentid();
            return dt;
        }
        public DataTable GetAgentDetails()
        {
            DataTable dt = new DataTable();
            dt = dal.getdetailsby_agentid(AgentDetailObject);
            return dt;
        }
        public bool DeleteData()
        {
            if (dal.deletedetails(AgentDetailObject)>0)
                return true;
            else
                return false;
        }
           public void SetDBLogonForReport(ConnectionInfo  connectionInfo, ReportDocument reportDocument)
            {

                Tables tables = reportDocument.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                {
                    TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                    SqlConnectionStringBuilder ConnectionBuilder =DataBaseHelper.SQLHelper.Instance.ReportConnectionString();
                    tableLogonInfo.ConnectionInfo.UserID  = ConnectionBuilder.UserID ;
                    tableLogonInfo.ConnectionInfo.ServerName = ConnectionBuilder.DataSource;
                    tableLogonInfo.ConnectionInfo.DatabaseName = ConnectionBuilder.InitialCatalog;
                    tableLogonInfo.ConnectionInfo.Password = ConnectionBuilder.Password;
                    table.ApplyLogOnInfo(tableLogonInfo);


                }
            }

         
        }
    }
