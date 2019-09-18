using CommonHelper;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseHelper.DALClass
{
    public class CustomReportDALClass
    {
        public List<string> Get_Tables()
        {
            List<string> retList = new List<string>();
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_TablesName, param);
                while (result.Read())
                {
                    retList.Add(result[0].ToString());
                }
            }
            catch
            {

            }
            return retList;
        }
        public List<string> _Get_ColumnsByTable(string table)
        {
            List<string> retList = new List<string>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TableName", table);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_ColumnsName, param);
                while (result.Read())
                {
                    retList.Add(result[0].ToString());
                }
            }
            catch
            {

            }
            return retList;
        }
        public List<CustomReportObjectClass> Get_ColumnsByTable(string table)
        {

            List<CustomReportObjectClass> retList = new List<CustomReportObjectClass>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TableName", table);
                var result = SQLHelper.Instance.GetReader(StoredProcedurers.GET_ColumnsName, param);
                while (result.Read())
                {
                    CustomReportObjectClass model = new CustomReportObjectClass()
                    {
                        Name = result[0].ToString(),
                        Type = result[1].ToString(),
                    };
                    retList.Add(model);
                }
            }
            catch
            {

            }
            return retList;
        }
    }
}
