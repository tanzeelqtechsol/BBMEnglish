using DataBaseHelper.DALClass;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BALHelper
{
    public class CustomReportBALLClass
    {
        CustomReportDALClass ObjDALClass;
        public CustomReportBALLClass()
        {
            ObjDALClass = new CustomReportDALClass();
        }
        public List<string> GetAllTables()
        {
            List<string> retList = new List<string>();
            retList = ObjDALClass.Get_Tables();
            return retList;
        }
        public List<CustomReportObjectClass> GetColumnsByTableName(string table)
        {
            List<CustomReportObjectClass> retList = new List<CustomReportObjectClass>();
            retList = ObjDALClass.Get_ColumnsByTable(table);
            return retList;
        }
    }
}
