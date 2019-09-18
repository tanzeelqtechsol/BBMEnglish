using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System.Data;

namespace BALHelper
{
    public class DiscountBALClass
    {
        DiscountDALClass ObjDALClass;
        DiscountObjectClass objDiscount = new DiscountObjectClass();
        public DiscountBALClass()
        {
            ObjDALClass = new DiscountDALClass();
        }
        public void IninitializeObject()
        {
            objDiscount = new DiscountObjectClass();
        }
        public DiscountObjectClass ObjDiscount
        {
            get { return objDiscount; }
            set { objDiscount = value; }
        }
        public Boolean SaveApplyDiscount()
        {
            if (ObjDALClass.Save_DiscountDetails(ObjDiscount))
                return true;
            else
                return false;
        }
        public Boolean UndoDiscount()
        {
            if (ObjDALClass.Undo_DiscountDetails(ObjDiscount))
                return true;
            else
                return false;
        }
        public Dictionary<DataTable,List<DiscountObjectClass>> GetDiscountDetails()
        {
            List<DiscountObjectClass> list1 = new List<DiscountObjectClass>();
            Dictionary<DataTable, List<DiscountObjectClass>> DisocuntedDetails = new Dictionary<DataTable, List<DiscountObjectClass>>();
            DataSet ds = ObjDALClass.Get_GridviewDetails(ObjDiscount);
            DataTable dt1, dt2 = new DataTable();
            dt1 = ds.Tables[0];
            dt2 = ds.Tables[1];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                list1.Add(new DiscountObjectClass
                {
                    Active = Convert.ToBoolean(dt1.Rows[i]["Select"]),
                    DiscountID = dt1.Rows[i]["DiscountID"].ToString(),
                    Discount = Convert.ToDecimal(dt1.Rows[i]["Discount"]),
                    DiscountName = dt1.Rows[i]["DiscountName"].ToString(),
                    StartDate = Convert.ToBoolean(dt1.Rows[i]["HasIncrease"].ToString()) == true ? (DateTime?)null : Convert.ToDateTime(dt1.Rows[i]["StartDate"]).Date,
                    EndDate = Convert.ToBoolean(dt1.Rows[i]["HasIncrease"].ToString()) == true ? (DateTime?)null : Convert.ToDateTime(dt1.Rows[i]["EndDate"]).Date,
                });
            }
            DisocuntedDetails.Add(dt2,list1);
            ds.Tables.RemoveAt(1);
            return DisocuntedDetails;
        }

        public Boolean CheckAvaiability()
        {
            if (ObjDALClass.Check_DiscountDetails(ObjDiscount))
                return true;
            else
                return false;
        }
    }
}
