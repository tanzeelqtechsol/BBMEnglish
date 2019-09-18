using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using System.Data.SqlClient;

namespace DataBaseHelper.DALClass
{
    public class CleanDBInfoDAL
    {

        #region Constant Variables

        private const string SPNameCleanDB = "SP_CleanDB";
        
        #endregion

        #region Methods

        public int CleanDB(OptionSettingsObject ObjOptionSettings)
        {
            SqlParameter[] sqlprm = new SqlParameter[8];

            try
            {
                sqlprm[0] = new SqlParameter("@option", ObjOptionSettings.OptionDB);
                sqlprm[1] = new SqlParameter("@Itemandbarcode", ObjOptionSettings.Itemandbarcode);
                sqlprm[2] = new SqlParameter("@AgentInfo", ObjOptionSettings.AgentInfo);
                sqlprm[3] = new SqlParameter("@Spendings", ObjOptionSettings.Spendings);
                sqlprm[4] = new SqlParameter("@EmpInfo", ObjOptionSettings.EmpInfo);
                sqlprm[5] = new SqlParameter("@UserInfo", ObjOptionSettings.UserInfo);
                sqlprm[6] = new SqlParameter("@MoveCreditofAgents", ObjOptionSettings.MoveCreditofAgents);
                sqlprm[7] = new SqlParameter("@Description", ObjOptionSettings.Description);

                if (SQLHelper.Instance.ExecuteNonQuery(SPNameCleanDB, sqlprm) > 0)
                    return 1;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
