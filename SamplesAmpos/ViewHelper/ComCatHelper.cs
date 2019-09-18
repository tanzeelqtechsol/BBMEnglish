using System;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using BALHelper;
using System.Data;
using CommonHelper;
using ObjectHelper;
using System.Collections.Generic;

namespace BumedianBM.ViewHelper
{
    public class ComCatHelper
    {
        #region Variable 
        
  
        internal string ID, Category, Field,Printer;
        internal int doubleclicktab;
        internal int tag;
        internal bool IsValueFromGrid = false;

        private ComCatBALClass balClass;
        #endregion
        public ComCatBALClass ObjbalClass
        {
            get { return balClass; }
            set { balClass = value; }
        }

        public ComCatHelper()
        {
           
            balClass = new ComCatBALClass();
            balClass.SetComCatObject();
          
        }
        #region Method
        
       
        public bool  SaveCategory()
        {
            balClass.ComcatObj.Company = "CAT";
            if (this.categoryvalidation())
            {
                if (!balClass.Check_ComCatName())
                {
                    if (balClass.Save_Category())
                        //GeneralFunction.Information (Constants.CategorySave, (ActionType.Save).ToString());
                        GeneralFunction.Information("SaveCategory", ActionType.Save.ToString());
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedSaveCategory", ActionType.Save.ToString());
                    /// return false;
                }

            }
         
            return false;
        }
        public bool  SaveCompany()
        {
            balClass.ComcatObj.Company = "COM";
            balClass.ComcatObj.Category = balClass.ComcatObj.CompanyName;
            if (this.Companyvalidation())
            {
                if (!balClass.Check_ComCatName())
                {
                    if (balClass.Save_Company())
                       // GeneralFunction.Information(Constants.CompanySave , (ActionType.Save).ToString());
                        GeneralFunction.Information("SaveCompany", ActionType.Save.ToString());
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedSaveCompany",ActionType.Save.ToString());
                }
            }
            return false;
        }
        public bool  SaveBankName()
        {
            balClass.ComcatObj.Company = "BANK";
            balClass.ComcatObj.Category =balClass.ComcatObj.BankName;
            if (this.BankValidation())
            {
                if (!balClass.Check_ComCatName())
                {
                    if (balClass.Save_Bank())
                        //GeneralFunction.Information(Constants.BankSave, (ActionType.Save).ToString());
                        GeneralFunction.Information("SaveBank",ActionType.Save.ToString());
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedSaveBank",ActionType.Save.ToString());
                   // GeneralFunction.Warning(Constants.BankAlreadyExits, ActionType.Save.ToString());
                   // PrimaryInfoForm.txtBankName.Focus();
                }

            }
            return false;
        }
        public bool  SaveBranchName()
        {
            balClass.ComcatObj.Company = "BRAN";
            balClass.ComcatObj.Category = balClass.ComcatObj.BranchName;
            if (Branchvalidation())
            {
                if (!balClass.Check_ComCatName())
                {
                    if (balClass.Save_Branch())
                        //CommonHelper.GeneralFunction.Information(Constants.BranchSave, (ActionType.Save).ToString());
                        GeneralFunction.Information("SaveBranch",ActionType.Save.ToString());
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedSaveBranch",ActionType.Save.ToString());

                }
            }
            return false;
        }
        public bool  SaveItemPlace()
        {
            balClass.ComcatObj.Company = "ITEM";
            balClass.ComcatObj.Category = balClass.ComcatObj.ItemPlace;
            if (ItemPlaceValidation())
            {

                if (!balClass.Check_ComCatName())
                {
                    if (balClass.Save_ItemPlace())
                        GeneralFunction.Information("SaveItemPlace",ActionType.Save.ToString());
                    return true;
                }
                else
                {
                    GeneralFunction.Information("FailedSaveItemPlace",ActionType.Save.ToString());
                }
            }
            return false;
        }
        public bool  SaveItemUnit()
        {
            if (ItemUnitValidation())
            {
                if (ObjbalClass.Save_ItemUnit())
                    GeneralFunction.Information("ItemUnitSave",ActionType.Save.ToString());
                    return true;
            }
                
                    return false;
            
        }
        public Boolean ItemUnitValidation()
        {
            if (ObjbalClass.ComcatObj.UnitName == string.Empty)
            {
                GeneralFunction.Information("UnitNameRequired", ActionType.Save.ToString());
              balClass.ComcatObj.FocusedControlName="txtUnitName";
                //PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else if (ObjbalClass.ComcatObj.UnitQuantity == string.Empty)
            {
                GeneralFunction.Information("UnitQuantityRequired", ActionType.Save.ToString());
               balClass.ComcatObj.FocusedControlName="txtUnitQuantity";
                //PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else return true;
        }
        public Boolean categoryvalidation()
        {
            if (balClass.ComcatObj.Category == string.Empty)
            {
                GeneralFunction.Information("CategoryNameisRequired" , ActionType.Save.ToString());
                //Control ctrl = new Control("txtCategoryName");
                //PrimaryInfo.ChangeProperties(ctrl);
                balClass.ComcatObj.FocusedControlName = "txtCategoryName";
                return false;
            }
            else
                return true;

        }
        public Boolean Companyvalidation()
        {
            if (balClass.ComcatObj.CompanyName == string.Empty)
            {
                GeneralFunction.Information ("CompanyNameIsRequired",ActionType.Save.ToString());
                balClass.ComcatObj.FocusedControlName="txtCompanyFieldName";
                //PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else
                return true;
        }
        public Boolean ItemPlaceValidation()
        {
            if (balClass.ComcatObj.ItemPlace == string.Empty)
            {
                CommonHelper.GeneralFunction.Information("ItemplaceNameisRequired", ActionType.Save.ToString());
               balClass.ComcatObj.FocusedControlName="txtItemPlace";
               // PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else
                return true;
        }
        public Boolean BankValidation()
        {
            if (balClass.ComcatObj.BankName == string.Empty)
            {
                CommonHelper.GeneralFunction.Information("BankNameisRequired", ActionType.Save.ToString());
              balClass.ComcatObj.FocusedControlName="txtBankName";
                //PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else
                return true;
        }
        public Boolean Branchvalidation()
        {
            if (balClass.ComcatObj.BranchName == string.Empty)
            {
                CommonHelper.GeneralFunction.Information("BranchNameisRequired", ActionType.Save.ToString());
              balClass.ComcatObj.FocusedControlName="txtBranchName";
               // PrimaryInfo.ChangeProperties(ctrl);
                return false;
            }
            else
                return true;
        }

        public List<object> BindCategory()
        {
            List<Object> BindCat = new List<object>();
          

                BindCat = balClass.Get_Category();
                return BindCat;
               
           
        }

        public List<object> BindCompany()
        {
            List<object> CompanyList = new List<object>();
           
                CompanyList = balClass.Get_Company();
                return CompanyList;
            

        }
        public List<object> BindItemPlace()
        {

            List<object> ItemList = new List<object>();
         
                ItemList = balClass.Get_ItemPlace();
               
                return ItemList;
            


        }
        public List<object> BindBank()
        {
            List<Object> BankList = new List<object>();
            BankList = balClass.Get_Bank();
                return BankList;
              

        }
        public List<object> BindBranch()
        {
            List<Object> BranchList=new List<object>();
             BranchList= balClass.Get_Branch();
                 return BranchList;
               
        }
        public List<Object> BindItemUnit()
        {
            List<Object> ItemUnit = new List<Object>();
            ItemUnit = ObjbalClass.Get_ItemUnit();
            return ItemUnit;
        }
        public bool  SaveClick()
        {
            bool status=false;
             this.SetCommonObject();
              //  balClass.ComcatObj = obj;
                
            switch ((Tabs)tag)
                {
                    case Tabs.Category:
                       status =  SaveCategory();
                        break;
                    case Tabs.Company:
                        status = SaveCompany();
                        break;
                    case Tabs.ItemPlace:
                        status = SaveItemPlace();
                        break;
                    case Tabs.Bank:
                        status = SaveBankName();
                        break;
                    case Tabs.Branch:
                        status = SaveBranchName();
                        break;
                    case Tabs.ItemUnit:
                        status = SaveItemUnit();
                        break;
                    default:
                        break;
                }
                return status ;
           
        }
           
            
         
        
     
       
        public void SetCommonObject()
        {
             ObjbalClass.ComcatObj.CreatedBy = GeneralFunction.UserId ;
                ObjbalClass.ComcatObj.ModifiedBy = GeneralFunction.UserId ;
  
             
           

        }
      
        public void SetValueFromGrid()
        {
            balClass.ComcatObj.CommonId = ID;
            switch ((Tabs)doubleclicktab)
            {

                case Tabs.Category:
              
                balClass.ComcatObj.CategoryID =Convert.ToInt32( ID);
                   balClass.ComcatObj.Category= Category;
                   balClass.ComcatObj.FieldCategory = Field;
                   balClass.ComcatObj.Printer = Printer;
                    break;
                case Tabs.Company:
                    balClass.ComcatObj.CompanyID  = Convert.ToInt32(ID);
                    balClass.ComcatObj.CompanyName = Category;
                    balClass.ComcatObj.FieldCompany = Field;
                    break;
                case Tabs.ItemPlace:
                    balClass.ComcatObj.ItemPlaceID  = Convert.ToInt32(ID);
                    balClass.ComcatObj.ItemPlace = Category;
                    break;
                case Tabs.Bank:
                    balClass.ComcatObj.BankID = Convert.ToInt32(ID);
                    balClass.ComcatObj.BankName= Category;
                    break;
                case Tabs.Branch:
                    balClass.ComcatObj.BranchID = Convert.ToInt32(ID);
                    balClass.ComcatObj.BranchName= Category;
                    break;
                case Tabs.ItemUnit:
                    balClass.ComcatObj.UnitName = Category.Replace("BoxOf(","").Replace(")","");
                    balClass.ComcatObj.UnitQuantity = Field;
                    break;
            }
         //  PrimaryInfoForm.SetControlFromObject();

        }
        public void Delete()
        {
           
                balClass.ComcatObj.Remove = 1;
                if (IsValueFromGrid)
                {
                    switch ((Tabs)tag)
                    {
                        case Tabs.Category:
                            if (balClass.ComcatObj.Category != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteCategory", "CategoryUsed");
                            }
                            else
                                GeneralFunction.Information("EmptyCategory", ActionType.Delete.ToString());
                            break;
                        case Tabs.Company:
                            if (balClass.ComcatObj.CompanyName != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteCompany", "CompanyExist");
                            }
                            else
                                GeneralFunction.Information("EmptyCompany", ActionType.Delete.ToString());
                            break;
                        case Tabs.ItemPlace:
                            if (balClass.ComcatObj.ItemPlace != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteItemPlace", "ItemPlaceExist");
                            }
                            else
                                GeneralFunction.Information("EmptyItemPlace", ActionType.Delete.ToString());
                            break;
                        case Tabs.Bank:

                            if (balClass.ComcatObj.BankName != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteBank", "Bank Details Does not Exist");
                            }
                            else
                                GeneralFunction.Information("EmptyBank", ActionType.Delete.ToString());

                            break;
                        case Tabs.Branch:
                            if (balClass.ComcatObj.BranchName != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteBranch", "Branch Details Does not Exist");
                            }
                            else
                                GeneralFunction.Information("EmptyBranch", ActionType.Delete.ToString());

                            break;
                        case Tabs.ItemUnit:
                            if (balClass.ComcatObj.UnitName != string.Empty)
                            {
                                ComCatDelete(ID, tag, "DeleteItemUnit", "ItemUnit Details Does not Exist");
                            }
                            else
                                GeneralFunction.Information("EmptyUnitName", ActionType.Delete.ToString());
                            break;
                    }

                }
                else
                    GeneralFunction.Warning("AgentInvalidOperation", ActionType.Delete.ToString());

            
        }

        private void ComCatDelete(string Id,int tag,string Info,string Warning)
        {
            //if (ID != "0")
            //{
                balClass.ComcatObj.CommonId = ID;
                bool returnval = false;
                switch ((Tabs)tag)
                {
                    case Tabs.Category:
                        returnval = balClass.Delete_Category();
                        break;
                    case Tabs.Company:
                        returnval = balClass.Delete_Company();
                        break;
                    case Tabs.ItemPlace:
                        returnval = balClass.Delete_ItemPlace();
                        break;
                    case Tabs.Bank:
                        returnval = balClass.Delete_Bank();
                        break;
                    case Tabs.Branch:
                        returnval = balClass.Delete_Branch();
                        break;
                    case Tabs.ItemUnit:
                        returnval = balClass.Delete_ItemUnit();
                        break;
                }
                if (returnval)
                    GeneralFunction.Information(Info, ActionType.Delete.ToString());
                else
                    GeneralFunction.Warning("CategoryUsed", ActionType.Delete.ToString());
            //}
            //else
            //    GeneralFunction.Warning(Warning, ActionType.Delete.ToString());
        }
        #endregion

    }
   
}
