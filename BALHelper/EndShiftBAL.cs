using DataBaseHelper.DALClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BALHelper
{
    public class EndShiftBAL
    {
        private ShiftEndDAL EndShiftDAL;

        public EndShiftBAL()
        {
            EndShiftDAL = new ShiftEndDAL();
        }

        public DataTable GetShiftData(string endTime)
        {
            DataTable dt = new DataTable();
            dt = EndShiftDAL.GetUserData(endTime);
            return dt;
        }

        public DataTable GetReportValuesBAL()
        {
            return EndShiftDAL.Get_ReportValues();
        }

        public string[] SetLoginTime()
        {
           return EndShiftDAL.Set_LoginTime();
        }
    }
}
