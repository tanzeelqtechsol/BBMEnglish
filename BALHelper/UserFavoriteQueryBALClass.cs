using DataBaseHelper.DALClass;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BALHelper
{
    public class UserFavoriteQueryBALClass
    {
        AddFavoriteUserQueryDALClass ObjDALClass;
        FavoriteUserQueryObjectClass objFavoriteUserQuery;
        public UserFavoriteQueryBALClass()
        {
            ObjDALClass = new AddFavoriteUserQueryDALClass();
        }
        public void IninitializeObject()
        {
            objFavoriteUserQuery = new FavoriteUserQueryObjectClass();
        }
        public FavoriteUserQueryObjectClass ObjFavoriteUserQuery
        {
            get { return objFavoriteUserQuery; }
            set { objFavoriteUserQuery = value; }
        }

        public Boolean SaveFavoriteUserQuery()
        {
            if (ObjDALClass.Save_UserQuery(objFavoriteUserQuery))
                return true;
            else
                return false;
        }
        public Boolean UpdateFavoriteUserQuery()
        {
            if (ObjDALClass.Update_UserQuery(objFavoriteUserQuery))
                return true;
            else
                return false;
        }
        public Boolean DeleteFavoriteUserQuery(int id)
        {
            if (ObjDALClass.Delete_UserQuery(id))
                return true;
            else
                return false;
        }
        public FavoriteUserQueryObjectClass GetFavoriteUserQueryByID(int id)
        {
            objFavoriteUserQuery = new FavoriteUserQueryObjectClass();
            objFavoriteUserQuery = ObjDALClass.Get_UserQueryByID(id);

            return objFavoriteUserQuery;
        }
        public Boolean GetFavoriteUserQueryByDesc(string desc)
        {
            return ObjDALClass.Get_UserQueryByDesc(desc);
        }
        public DataTable GetFavoriteUserQuery()
        {
            DataTable dt = new DataTable();
            dt = ObjDALClass.Get_UserQuery();
            return dt;
        }
    }
}
