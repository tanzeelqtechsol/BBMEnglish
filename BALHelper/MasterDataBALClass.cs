using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper;
using DataBaseHelper.DALClass;

namespace BALHelper
{
    public class MasterDataBALClass
    {
        MasterDataDALClass ObjDALClass;
        public MasterDataBALClass()
        {
            ObjDALClass = new MasterDataDALClass();
        }

        //public List<PurchaseObjectClass> GetSupllierBal()
        //{
        //    List<PurchaseObjectClass> ObjListPurchase = ObjDALClass.GetSupllier();
        //    return ObjListPurchase;
        //}

        public List<AgentDetailObjectClass> GetAgentDetailsBal()
        {
            //List<AgentDetailObjectClass> ObjListAgent = ObjDALClass.GetAgentDetails();
            //return ObjListAgent;

            return ObjDALClass.GetAgentDetails();
        }

        public List<ComCatObjectClass> GetCategoryDetailsBal()
        {
            List<ComCatObjectClass> ObjListComCat = ObjDALClass.GetCategoryDetails();
            return ObjListComCat;
        }

        public List<ComCatObjectClass> GetCompanyDetailsBal()
        {
            List<ComCatObjectClass> ObjListComCat = ObjDALClass.GetCompanyDetails();
            return ObjListComCat;
        }

        public List<BankObjectClass> GetBankDetailsBal()
        {
            List<BankObjectClass> ObjListBank = ObjDALClass.GetBankDetails();
            return ObjListBank;
        }

        public List<BankObjectClass> BranchDetailsBal()
        {
            List<BankObjectClass> ObjListBank = ObjDALClass.BranchDetails();
            return ObjListBank;
        }


        public List<ItemCardObjectClass> ItemDetailsBal()
        {
            List<ItemCardObjectClass> ObjListItemCard = ObjDALClass.ItemDetails();
            return ObjListItemCard;
        }

        public List<EmployeeObjectClass> UserDetailsBal()
        {
            List<EmployeeObjectClass> ObjListItemCard = ObjDALClass.UserDetails();
            return ObjListItemCard;
        }

        public List<EmployeeObjectClass> UserGroupDetailsBal()
        {
            List<EmployeeObjectClass> ObjListUserGroup = ObjDALClass.UserGroupDetails();
            return ObjListUserGroup;
        }
        public List<ItemCardObjectClass> GetItemUnitName()
        {
            List<ItemCardObjectClass> ListOfUnitName = ObjDALClass.UnitNameOfItem();
            return ListOfUnitName;
        }

        public int UpdateuserUnlock()
        {
            return ObjDALClass.Save_UserUnLockDetails();
        }
    }
}
