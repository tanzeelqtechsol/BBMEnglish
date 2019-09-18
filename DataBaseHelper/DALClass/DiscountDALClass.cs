using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ObjectHelper;

namespace DataBaseHelper.DALClass
{
    public class DiscountDALClass
    {
        public Boolean Save_DiscountDetails(DiscountObjectClass ObjDiscount)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[12];
                Param[0] = new SqlParameter("@DiscountName", ObjDiscount.DiscountName);
                Param[1] = new SqlParameter("@CompanyID", ObjDiscount.CompanyID);
                Param[2] = new SqlParameter("@CategoryID", ObjDiscount.CategoryID);
                Param[3] = new SqlParameter("@Discount", ObjDiscount.Discount);
                Param[4] = new SqlParameter("@StartDate", ObjDiscount.StartDate);
                Param[5] = new SqlParameter("@EndDate", ObjDiscount.EndDate);
                Param[6] = new SqlParameter("@CreatedBy", ObjDiscount.CreatedBy);
                Param[7] = new SqlParameter("@ModifiedBy", ObjDiscount.ModifiedBy);
                Param[8] = new SqlParameter("@Status", ObjDiscount.Active);
                Param[9] = new SqlParameter("@DiscountFor", ObjDiscount.DiscountFor);
                Param[10] = new SqlParameter("@HasIncrease", ObjDiscount.HasIncrease); 
                 Param[11] = new SqlParameter("@IncreaseType", ObjDiscount.IncreaseType);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.SAVE_DISCOUNT_DETAILS, Param) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw ex; }
        }

        public Boolean Undo_DiscountDetails(DiscountObjectClass ObjDiscount)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                Param[0] = new SqlParameter("@DiscountID",ObjDiscount.DiscountID);
                if (SQLHelper.Instance.ExecuteNonQuery(StoredProcedurers.UNDO_DISCOUNT_DETAILS, Param) > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception ex) { throw ex; }
        }

        public DataSet Get_GridviewDetails(DiscountObjectClass ObjDiscount)
         {
            DataSet dtab = new DataSet();
            try
            {
                SqlParameter[] Param = new SqlParameter[3];
                Param[0] = new SqlParameter("@ItemType", ObjDiscount.DiscountFor);
                Param[1] = new SqlParameter("@CategoryID", ObjDiscount.CategoryID);
                Param[2] = new SqlParameter("@CompanyID", ObjDiscount.CompanyID);
                dtab = SQLHelper.Instance.ExecuteQueryDataset(StoredProcedurers.GET_DISCOUNT_DETAILS, Param, "Discount");
                return dtab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Check_DiscountDetails(DiscountObjectClass ObjDiscount)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] Param = new SqlParameter[5];
                Param[0] = new SqlParameter("@CompanyID", ObjDiscount.CompanyID);
                Param[1] = new SqlParameter("@CategoryID", ObjDiscount.CategoryID);
                Param[2] = new SqlParameter("@StartDate", ObjDiscount.StartDate);
                Param[3] = new SqlParameter("@EndDate", ObjDiscount.EndDate);
                Param[4] = new SqlParameter("@DiscountFor", ObjDiscount.DiscountFor);
                dt =SQLHelper.Instance.ExecuteQueryDatatable(StoredProcedurers.CHECK_DISCOUNT_DETAILS, Param, "Discount");
                return (dt.Rows.Count > 0) ? false : true;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
