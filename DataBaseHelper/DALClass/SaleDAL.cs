using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ObjectHelper;
using DataBaseHelper.DALClass;

namespace DataBaseHelper.DALClass
{
    public class SaleDAL
    {
        DataTable dt = new DataTable();
        private const string SPLoadSalesDetails = "Sp_Sale_Load";

         

        public List<SaleObject> getLoadDetails(SaleObject objSaleObject)
        {
            List<SaleObject> lstItemForCategory = new List<SaleObject>();
            // SqlParameter[] param = new SqlParameter[0];
            using (SqlCommand cmd = new SqlCommand("Sp_Sale_Load", SQLHelper.Instance.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SQLHelper.Instance.conn.Open();
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    lstItemForCategory.Add(new SaleObject
                    {
                        SalesId = Convert.ToInt32(result[0])
                    });
                }
                result.NextResult();
                while (result.Read())
                {

                    lstItemForCategory.Add(new SaleObject
                    {
                        ItemsId = Convert.ToInt32(result[1]),
                        ItemName = result[0].ToString()
                    });

                }
                return lstItemForCategory;

            }
        }
        public List<SaleObject> getItemForCategory(SaleObject objSaleObject)
        {
            List<SaleObject> lstSaleObject = new List<SaleObject>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_CategoryItem_nonstockA", SQLHelper.Instance.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SQLHelper.Instance.conn.Open();
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@ChangeID", objSaleObject.CategoryId);
                    param[1] = new SqlParameter("@Value", objSaleObject.Value);
                    cmd.Parameters.AddRange(param);
                    var result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        lstSaleObject.Add(new SaleObject
                        {
                            ItemsId = Convert.ToInt16(result[0])
                        });
                    }
                    result.NextResult();
                    while (result.Read())
                    {

                        lstSaleObject.Add(new SaleObject
                        {
                            ItemName = result[0].ToString()
                        });

                    }

                }
            }
            catch
            {
            }
            finally
            {
                SQLHelper.Instance.conn.Close();
            }
            return lstSaleObject;
        }
        public void SaleId()
        {
 
        }

    }
}
