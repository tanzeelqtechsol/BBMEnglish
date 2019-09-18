using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataBaseHelper.DALClass;
using ObjectHelper;

namespace BALHelper
{
    public class EmployeeBALClass
    {
        #region Variables
        public EmployeeDALClass ObjEmployeeDALClass = new EmployeeDALClass();
        public EmployeeObjectClass ObjEmployeeObjectClass;
        Dictionary<string, List<EmployeeObjectClass>> ObjempDictBAL = new Dictionary<string, List<EmployeeObjectClass>>();

        //List<EmployeeObjectClass> ObjempListBAL = new List<EmployeeObjectClass>();
        //List<EmployeeObjectClass> ObjempdrawBAL = new List<EmployeeObjectClass>();
        //List<EmployeeObjectClass> ObjEmpVariableList = new List<EmployeeObjectClass>();
        //List<EmployeeObjectClass> ObjempNotesBAL = new List<EmployeeObjectClass>();
        //List<EmployeeObjectClass> ObjUserListByOption = new List<EmployeeObjectClass>(); 
        //LoginObjectClass ObjempLoginDetails = new LoginObjectClass();
        //List<LoginObjectClass> ObjempUserdetailsList = new List<LoginObjectClass>();
        #endregion
        public EmployeeObjectClass ObjEmployeeObject
        {
            get { return ObjEmployeeObjectClass; }
            set { ObjEmployeeObjectClass = value; }
        }
        public void SetCommonObject()
        {
            ObjEmployeeObjectClass = new EmployeeObjectClass();
        }
        public List<EmployeeObjectClass> GetEmpNotesData()
        {
            //ObjempNotesBAL = ObjEmployeeDALClass.Get_EmpNotesDetailsAll();
            //return ObjempNotesBAL;
            return ObjEmployeeDALClass.Get_EmpNotesDetailsAll();
        }
        public List<EmployeeObjectClass> GetEmpDrawingsData()
        {
            //ObjempdrawBAL = ObjEmployeeDALClass.Get_EmpDrawingsDetailsAll();
            //return ObjempdrawBAL;
            return ObjEmployeeDALClass.Get_EmpDrawingsDetailsAll();
        }
        public List<EmployeeObjectClass> GetEmpVariablesData()
        {
            //return ObjEmpVariableList=(ObjEmployeeDALClass.Get_EmpVariablesDetailsAll());
            return (ObjEmployeeDALClass.Get_EmpVariablesDetailsAll());
        }
        public List<EmployeeObjectClass> GetEmpDetailsData()
        {
            //ObjempListBAL = ObjEmployeeDALClass.Get_EmpDetailsAll();
            //return ObjempListBAL;
            return ObjEmployeeDALClass.Get_EmpDetailsAll();
        }
        public Dictionary<string, List<EmployeeObjectClass>> GetComboBoxValues()
        {

            //ObjempDictBAL = ObjEmployeeDALClass.Get_EmpComboBoxValuesAll();
            //return ObjempDictBAL;
            return ObjEmployeeDALClass.Get_EmpComboBoxValuesAll();
        }

        public bool SaveDrawingDetails()
        {
            if (ObjEmployeeDALClass.SaveDrawingorVariable(ObjEmployeeObjectClass) > 0)
                return true;
            else
                return false;
        }
        public bool SaveNotesDetails()
        {
            if (ObjEmployeeDALClass.SaveNotesDetails(ObjEmployeeObjectClass) > 0)
                return true;
            else
                return false;
        }
        public List<EmployeeObjectClass> Get_UserNameListByOptionID()
        {
            //ObjUserListByOption = ObjEmployeeDALClass.Get_UserNameListByOptionID(ObjEmployeeObjectClass);
            //return ObjUserListByOption;
            return ObjEmployeeDALClass.Get_UserNameListByOptionID(ObjEmployeeObjectClass);
        }

        public bool SaveVariableDetails()
        {
            if (ObjEmployeeDALClass.SaveDrawingorVariable(ObjEmployeeObjectClass) > 0)
                return true;
            else
                return false;
        }
        public int FindMaxUserGroupIdBAL()
        {
            return (ObjEmployeeDALClass.FindMaxUserGroupIdDAL());
        }
        public int SaveEmployeeLimitationDetails(List<EmployeeObjectClass> EmpObject)
        {
            return (ObjEmployeeDALClass.SaveEmployeeDetailsLimitation(EmpObject));
            //return localdt;

        }
        public bool SaveEmployeeDetails()
        {
            if (ObjEmployeeDALClass.SaveEmployeeDetails(ObjEmployeeObjectClass))
                return true;
            else
                return false;
        }
        public bool SaveEmployeeSalaryDetails()
        {
            if (ObjEmployeeDALClass.SaveEmployeeSalaryDetails(ObjEmployeeObjectClass))
                return true;
            else
                return false;
        }

        //public EmployeeObjectClass GetEmployeeByIndex(NavButtonClicked navButtonClicked,int currindex)
        //{
        //    ObjEmployeeObjectClass.ItemIndex = currindex;
        //    ObjEmployeeObjectClass.GetNavIndexIndex(navButtonClicked, ObjEmployeeObjectClass.ItemIndex, GeneralObjectClass.UserGroupList.Count);
        //    var item = GeneralObjectClass.UserGroupList[ObjEmployeeObjectClass.ItemIndex];
        //    return item;
        //}
        public List<EmployeeObjectClass> Check_UserLogin()
        {
            //return ObjempNotesBAL = ObjEmployeeDALClass.Check_UserLoginDAL(ObjEmployeeObjectClass);

            return ObjEmployeeDALClass.Check_UserLoginDAL(ObjEmployeeObjectClass);
        }
        public int Save_UserLoginTimeDetails()
        {
            return ObjEmployeeDALClass.Save_UserLoginTimeDetails(ObjEmployeeObjectClass);
        }
        public int Save_UserLogoutTimeDetails()
        {
            return ObjEmployeeDALClass.Save_UserLogoutTimeDetails(ObjEmployeeObjectClass);
        }
        public int CheckUserhasActioninInvoice()
        {
            return ObjEmployeeDALClass.CheckUserhasActioninInvoice(ObjEmployeeObjectClass);
        }
        public int Delete_EmployeeFormList()
        {
            return ObjEmployeeDALClass.Delete_EmployeeFormList(ObjEmployeeObjectClass);
        }
        public int DeleteEmpParticulars()
        {
            return ObjEmployeeDALClass.DeleteEmpParticulars(ObjEmployeeObjectClass);

        }
        /// <summary>
        /// Included this method on 07/01/2014
        /// </summary>
        /// <returns></returns>
        public List<EmployeeObjectClass> Get_RememberPassword()
        {
            return ObjEmployeeDALClass.GetRemember_Password(ObjEmployeeObjectClass);
        }
        public List<EmployeeObjectClass> Get_EmployeeRunTimeScreenLimt()
        {
            return ObjEmployeeDALClass.Get_EmployeeRunTimeScreenLimt(ObjEmployeeObjectClass);
        }
        public DataTable Get_RegistrationWorkStation()
        {
            return ObjEmployeeDALClass.Get_WorkStation();
        }
    }
}
