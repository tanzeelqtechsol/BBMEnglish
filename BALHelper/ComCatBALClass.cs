using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;
using System.Collections.Generic;

namespace BALHelper
{
  public class ComCatBALClass
    {
      private ComCatObjectClass comcatobj;
      private ComCatDALClass Com_Cat_Obj;
     
      public ComCatBALClass()
      {
          Com_Cat_Obj = new ComCatDALClass();
      }
      public ComCatObjectClass ComcatObj
      {
          get{return comcatobj;}
          set{comcatobj=value;}
      }
      public void SetComCatObject()
      {
         ComcatObj=new ComCatObjectClass();
      }
      #region Method
      
   
      public bool Check_ComCatName()
      {
          
          return Com_Cat_Obj.Check_PrimeryNames(ComcatObj);
         
        }

      public bool Save_Category()
      {
          if (Com_Cat_Obj.savecategory (ComcatObj)>0)
              return true;
          else
              return false;
      }
      public bool Delete_Category()
      {
          if (Com_Cat_Obj.DeleteCategory(ComcatObj) > 0)
              return true  ;
          else
              return false ;
      }
      public bool Save_Company()
      {
          if (Com_Cat_Obj.savecompany(comcatobj) > 0)
              return true;
          else
              return false;
      }
      public bool Delete_Company()
      {
          if (Com_Cat_Obj.DeleteCompany(ComcatObj) > 0)
              return true;
          else
              return false;
      }
      public bool Save_ItemPlace()
      {
          if (Com_Cat_Obj.saveitemplace(comcatobj) > 0)
              return true;
          else
              return false;
      }
      public bool Delete_ItemPlace()
      {
          if (Com_Cat_Obj.DeleteItemPlace(ComcatObj) > 0)
              return true;
          else
              return false;
      }
      public bool Save_Bank()
      {
          if (Com_Cat_Obj.savebank(comcatobj) > 0)
              return true;
          else
              return false;
      }
      public bool Delete_Bank()
      {
          if (Com_Cat_Obj.DeleteBank(ComcatObj) > 0)
              return true;
          else
              return false;
      }
      public bool Save_Branch()
      {
          if (Com_Cat_Obj.savebranch(comcatobj) > 0)
              return true;
          else
              return false;
      }
      public bool Delete_Branch()
      {
          if (Com_Cat_Obj.DeleteBranch(ComcatObj) > 0)
              return true;
          else
              return false;
      }

      public List<object> Get_Category()
      {
          List<object> CatList = new List<object>(); 
          foreach (var l in Com_Cat_Obj.GetCategory())
          {
              CatList.Add(new { l.CategoryID, l.Category, l.FieldCategory ,l.Printer });
          }
          return CatList;
      }
      public List<object> Get_Company()
      {
          List<object> ComList = new List<object>();
          foreach (var l in Com_Cat_Obj.GetCompany())
          {
              ComList.Add(new { l.CompanyID, l.Company, l.FieldCompany });
          }
          return ComList;
      }
      public List<object> Get_ItemPlace()
      {
          List<object> ItemPlace = new List<object>();
          foreach (var l in Com_Cat_Obj.GetItemplace())
          {
              ItemPlace.Add(new { l.CompanyID, l.ItemPlace });
          }
          return ItemPlace;
      }
      public List<object> Get_Bank()
      {
          List<object> BankList = new List<object>();
          foreach (var l in Com_Cat_Obj.GetBank())
          {
              BankList.Add(new { l.CompanyID, l.BankName });
          }
          return BankList;
      }
      public List<object> Get_Branch()
      {
          List<object> BranchList = new List<object>();
          foreach (var l in Com_Cat_Obj.GetBranch())
          {
              BranchList.Add(new { l.CompanyID,l.BranchName});
          }
          return BranchList;
      }
      public bool Save_ItemUnit()
      {
          if (Com_Cat_Obj.SaveItemUnit(ComcatObj))
              return true;
          else
              return false;
      }
      public List<object> Get_ItemUnit()
      {
          List<object> itemunit = new List<object>();
         
          foreach (var l in Com_Cat_Obj.GetItemUnit())
          {
              itemunit.Add(new { l.GeneralTypeID, l.UnitName, l.UnitQuantity});
          }
          return itemunit;

      }
      public bool Delete_ItemUnit()
      {
          if (Com_Cat_Obj.DeleteItemUnit(ComcatObj))
              return true;
          else
              return false;
      }
      #endregion
    }
}
