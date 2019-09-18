using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseHelper.DALClass
{
    public class AddFavoriteUserQueryDALClass
    {
        // custom/dynamically query
        public DataTable UserQuery_ExecuteCustomQuery(string queryText)
        {
            DataTable retDt = new DataTable();
            retDt = SQLHelper.Instance.UserQuery_ExecuteCustomQueryFlyringQuery(queryText);
            return retDt;
        }
        public DataTable Get_UserQuery()
        {
            DataTable retDT = new DataTable();
            retDT.Columns.Add("ID");
            retDT.Columns.Add("IsReleased");
            retDT.Columns.Add("Description");
            retDT.Columns.Add("FileName");
            retDT.Columns.Add("QueryText");
            retDT.Columns.Add("IsSystemCreated");
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.Get_UserQuery, param);
                while (result.Read())
                {
                    string isreleased = "";
                    if ((bool)result["IsReleased"] == true)
                        isreleased = "X";
                    else
                        isreleased = "";
                    retDT.Rows.Add(result["ID"], isreleased, result["Description"], result["FileName"], result["QueryText"], result["IsSystemCreated"]);
                }
            }
            catch
            {

            }
            return retDT;
        }
        public bool Get_UserQueryByDesc(string desc)
        {
            bool retVal = true;
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Description", desc);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.Get_UserQueryByDesc, param);

                while (result.Read())
                {
                    string isFound = result[1].ToString();
                    if (!string.IsNullOrEmpty(isFound))
                        return true;
                }
                return false;
            }
            catch
            {

            }
            return retVal;
        }
        public FavoriteUserQueryObjectClass Get_UserQueryByID(int id)
        {
            FavoriteUserQueryObjectClass retObject = new FavoriteUserQueryObjectClass();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", id);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.Get_UserQueryByID, param);
                while (result.Read())
                {
                    retObject = new FavoriteUserQueryObjectClass()
                    {
                        Description = result[1].ToString(),
                        FileName = result[2].ToString(),
                        QueryText = result[3].ToString(),
                        IsReleased = (bool)result[4]
                    };
                }
            }
            catch
            {

            }
            return retObject;
        }
        public bool Save_UserQuery(FavoriteUserQueryObjectClass ObjFavoriteUserQuery)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@FileName", ObjFavoriteUserQuery.FileName);
                param[1] = new SqlParameter("@Description", ObjFavoriteUserQuery.Description);
                param[2] = new SqlParameter("@QueryText", ObjFavoriteUserQuery.QueryText);
                param[3] = new SqlParameter("@IsReleased", ObjFavoriteUserQuery.IsReleased);
                param[4] = new SqlParameter("@IsSystemCreated", ObjFavoriteUserQuery.IsSystemCreated);

                if ((SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.Save_UserQuery, param)) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool Update_UserQuery(FavoriteUserQueryObjectClass ObjFavoriteUserQuery)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ID", ObjFavoriteUserQuery.ID);
                param[1] = new SqlParameter("@FileName", ObjFavoriteUserQuery.FileName);
                param[2] = new SqlParameter("@Description", ObjFavoriteUserQuery.Description);
                param[3] = new SqlParameter("@QueryText", ObjFavoriteUserQuery.QueryText);
                param[4] = new SqlParameter("@IsReleased", ObjFavoriteUserQuery.IsReleased);

                if ((SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.Update_UserQuery, param)) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public bool Delete_UserQuery(int id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", id);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.Delete_UserQuery, param) > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
    }
}
