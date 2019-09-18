using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;
using DataBaseHelper;

namespace BALHelper
{
    public class LoginBALHelper
    {
        private LoginDAL loginDAL;
        private LoginObjectClass objLoginObject;
        public LoginBALHelper()
        {
            loginDAL = new LoginDAL();
        }
        public void SetCommonObject()
        {
            objLoginObject = new LoginObjectClass();
        }
        public LoginObjectClass ObjLoginObject
        {
            get { return objLoginObject; }
            set { objLoginObject = value; }
        }
        public DataTable Check_Userlogin()
        {
            try
            {
                var dt = new DataTable();
                return dt = loginDAL.Check_UserLogin(objLoginObject);
               

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public List<string> GetActiveServers()
        {
            return SQLHelper.Instance.GetActiveServers();
        }
        public List<string> GetServerDatabases(string server, string UserId, string password)
        {
            return SQLHelper.Instance.GetServerDatabases(server, UserId, password);
        }

        public bool CheckActiveConnection(string server, string UserId, string password)
        {
            return SQLHelper.Instance.CheckActiveConnection(server, UserId, password);
        }
        public bool ChangeUserPassWord()
        {
            return loginDAL.changePassword(objLoginObject);
        }
        public decimal CheckBalanceBAL()
        {
            return loginDAL.CheckBalanceDAL();
        }
        public bool CheckActiveConnectionBAL(string server, string UserId, string password)
        {
            return (SQLHelper.Instance.CheckActiveConnection(server,UserId, password));
        }
        public int GetBarcodeCountBAL()
        {
            return loginDAL.GetBarcodeCount();
        }
        public bool GetEmptyBarcodes()
        {
           return loginDAL.GetEmptyBarcodes();
        }
        public bool UpdateWrongStock()
        {
            bool WrongStock = loginDAL.UpdateWrongStock();
            bool WrongStockExpiry = loginDAL.UpdateWrongStockExpiry();
            if (WrongStock == true || WrongStockExpiry == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int LogOut_UserBAL(int UserId)
        {
            int i = 0;
            return i = loginDAL.LogOut_User(UserId);
        }
        public DataTable GetExpiredItems()
        {
            return loginDAL.Get_ExpiryItemList();
        }
    }
}
