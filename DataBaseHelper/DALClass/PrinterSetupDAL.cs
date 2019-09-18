using ObjectHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseHelper.DALClass
{
    public class PrinterSetupDAL
    {
        #region Update Printer Setup
        public bool UpdatePrinterSetupDAL(PrinterSetupObject objSaleObject)
        {
            SqlParameter[] param = new SqlParameter[6];

            try
            {
                param[0] = new SqlParameter("@Default", objSaleObject.Default);
                param[1] = new SqlParameter("@Invoice", objSaleObject.Invoice);
                param[2] = new SqlParameter("@POS", objSaleObject.POS);
                param[3] = new SqlParameter("@Receipt", objSaleObject.Receipt);
                param[4] = new SqlParameter("@Report", objSaleObject.Report);
                param[5] = new SqlParameter("@Barcode", objSaleObject.Barcode);

                if (SQLHelper.Instance.ExecuteNonQuery("SP_Save_PrinterSetup", param) > 0)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }
        #endregion

        #region ConnectionClose
        public void Close()
        {
            if (SQLHelper.Instance.conn.State != System.Data.ConnectionState.Closed) SQLHelper.Instance.conn.Close();
        }

        #endregion
    }
}
