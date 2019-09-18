using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using System.Windows.Forms;
using System.Drawing;
using CommonHelper;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace BumedianBM.ViewHelper
{
    class FindSaleInvoiceHelper
    {

        #region Declaration
        FindSaleInvoiceBAL objFindSaleInvoiceBAL;
        public List<AgentDetailObjectClass> lstUser;
        public List<FindSaleInvoiceObject> lstPaymentDate;
        public List<FindSaleInvoiceObject> lstAgentPayment;
        public List<FindSaleInvoiceObject> lstInvoiceDetails = new List<FindSaleInvoiceObject>();
        public List<FindSaleInvoiceObject> lstInvoiceItemDetails = new List<FindSaleInvoiceObject>();
        internal Item_Information ObjItemInfo;
        int AgentID, Status, Remarks, User, InvoiceNo;
        #endregion

        #region Constructor

        public FindSaleInvoiceHelper()
        {
            objFindSaleInvoiceBAL = new FindSaleInvoiceBAL();
            ObjItemInfo = new Item_Information();
        }

        public FindSaleInvoiceBAL objFIndSaleInvBal
        {
            get { return objFindSaleInvoiceBAL; }
            set { objFindSaleInvoiceBAL = value; }
        }

        #endregion

        #region UIDatabaseMethods

        #region Load
        public void Load()
        {
            lstUser = objFindSaleInvoiceBAL.GetUser();
            objFindSaleInvoiceBAL.LoadNotesAndAlerts();
            lstAgentPayment = objFindSaleInvoiceBAL.GetPaymentAgentName();
            lstPaymentDate = objFindSaleInvoiceBAL.GetPaymentDate();
        }
        #endregion

        #region GetInvoiceDetailsHelper
        public List<FindSaleInvoiceObject> GetInvoiceDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetInvoiceDetailsBal();

        }
        #endregion

        #region GetAllInvoiceDetailsHelper
        public List<FindSaleInvoiceObject> GetAllInvoiceDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetAllInvoiceDetailsBal();

        }
        #endregion

        #region GetInvoiceItemDetailsHelper
        public List<FindSaleInvoiceObject> GetInvoiceItemDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetInvoiceItemDetailsBal();

        }
        #endregion

        #region GetReturnInvoiceItemDetailsHelper
        public List<FindSaleInvoiceObject> GetReturnInvoiceItemDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetReturnInvoiceItemDetailsBal();

        }
        #endregion

        #region GetBalanceSheetDetailsHelper
        public List<FindSaleInvoiceObject> GetBalanceSheetDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetBalanceSheetDetailsBal();

        }
        #endregion


        #endregion

        #region UIHelperMethods

        #region GetBalance
        public void GetBalance()
        {
            #region OldCode commented on 10-Aipril-2014
            //GeneralFunction.AgentId.Clear();
            //GeneralFunction.AgentID.Add(objFIndSaleInvBal.objFIndSaleInvObj.clientid);
            //GeneralFunction.AgentDept();
            #endregion

            #region NewCode
            List<FindSaleInvoiceObject> lstBalance;
            try
            {
                decimal decAmt = 0, decRec = 0, decBalance = 0; //decBalTotal = 0,
                lstBalance = GetBalanceSheetDetailsHelper();

                if (lstBalance.Count > 0)
                {
                    for (int i = 0; i < lstBalance.Count; i++)
                    {
                        decAmt = decAmt + lstBalance[i].NetAmount;
                        decRec = decRec + lstBalance[i].AmountRecieved;

                        //if (dtBalance.Rows[i]["MTB_AMT_RECEIVED"].ToString() == "0.0000")
                        //{
                        //    decBalTotal = (decAmt + decRec);
                        //    decBalance = decBalTotal;
                        //}
                        //else
                        //{
                        //    decBalance = (decBalTotal - decRec);
                        //}
                    }
                    decBalance = decRec - decAmt;
                }
                objFindSaleInvoiceBAL.objFIndSaleInvObj.Balance = (decBalance != null ? decBalance : 0);
                //   objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Balance = (decBalance != null ? decBalance : 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstBalance = null;
            }
            #endregion

        }
        #endregion

        #region FindInvoice
        public void FindInvoice()
        {
            try
            {

                lstInvoiceDetails = (!objFindSaleInvoiceBAL.objFIndSaleInvObj.ChkAllChecked) ? GetInvoiceDetailsHelper() : GetAllInvoiceDetailsHelper();

                if (lstInvoiceDetails.Count > 0)
                {

                    lstInvoiceDetails = objFindSaleInvoiceBAL.FilterInvoiceListBasedOnType(lstInvoiceDetails, objFindSaleInvoiceBAL.objFIndSaleInvObj.InvoiceTypeSelectedIndex, objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedValue);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TotalCalculationHelper
        public void TotalCalculationHelper()
        {
            try
            {
                if (lstInvoiceDetails.Count > 0)
                {
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfTotalAmt = lstInvoiceDetails.Sum(a => a.Total);
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfNetAmt = lstInvoiceDetails.Sum(a => a.NetAmount);
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfPaidAmt = lstInvoiceDetails.Sum(a => a.Paid);
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfDiscountAmt = lstInvoiceDetails.Sum(a => a.Discount);
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.RemainingAmt = (objFindSaleInvoiceBAL.objFIndSaleInvObj.ClientSelectedIndex > -1) ? objFindSaleInvoiceBAL.objFIndSaleInvObj.Balance : (objFindSaleInvoiceBAL.objFIndSaleInvObj.NetAmount - objFindSaleInvoiceBAL.objFIndSaleInvObj.Paid);
                }
                else
                {
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfTotalAmt = 0.000M;
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfNetAmt = 0.000M;
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfPaidAmt = 0.000M;
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.SumOfDiscountAmt = 0.000M;
                    objFindSaleInvoiceBAL.objFIndSaleInvObj.RemainingAmt = 0.000M;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        private Color GridRowColor(string strStatus)
        {
            switch (strStatus)
            {

                case "NI":
                    return Color.Blue;
                case "CI":
                    return Color.Navy;
                case "RI":
                    return Color.DarkOrange;
                case "SI":
                    return Color.Red;
                case "POS":
                    return Color.Chocolate;
                case "Rent":
                    return Color.Magenta;
                default:
                    return Color.Blue;

            }
        }

        #region GridSource
        public void GridSource(DataGridView datagrid_saleinv1)
        {

            datagrid_saleinv1.AutoGenerateColumns = false;
            datagrid_saleinv1.DataSource = null;
            datagrid_saleinv1.Rows.Clear();
            datagrid_saleinv1.DataSource = lstInvoiceDetails;
            for (int i = 0; i < lstInvoiceDetails.Count; i++)
            {
                int InvoiceType = 0;

                if (lstInvoiceDetails[i].InvoiceType == 1 && lstInvoiceDetails[i].Status == 1 && lstInvoiceDetails[i].InvoiceTypeTwo != 9)
                {
                    InvoiceType = 2;//New Invoices
                }
                else if (lstInvoiceDetails[i].InvoiceType == 1 && lstInvoiceDetails[i].Status == 2 && lstInvoiceDetails[i].InvoiceTypeTwo != 9)
                {
                    InvoiceType = 3;//Closed Invoices
                }
                else if (lstInvoiceDetails[i].InvoiceType == 1 && lstInvoiceDetails[i].InvoiceTypeTwo == 9)
                {
                    InvoiceType = 5;//Spoiled Invoices
                }
                else if (lstInvoiceDetails[i].InvoiceType == 10)
                {
                    InvoiceType = 6;//Return Invoices
                }
                else if (lstInvoiceDetails[i].InvoiceType == 2 && lstInvoiceDetails[i].InvoiceTypeTwo != 9)
                {
                    InvoiceType = 7;//POS Invoices
                }
                datagrid_saleinv1.Rows[i].DefaultCellStyle.ForeColor = GetGridColor(InvoiceType);
            }

        }
        #endregion

        #region DataGridSelectionChangeHelper
        public void DataGridSelectionChangeHelper()
        {
            List<FindSaleInvoiceObject> lstInvoiceDet = new List<FindSaleInvoiceObject>();
            try
            {

                switch ((InvoiceTypeSelection)objFIndSaleInvBal.objFIndSaleInvObj.InvoiceType)
                {

                    case InvoiceTypeSelection.Normal:

                        lstInvoiceDet = GetInvoiceItemDetailsHelper();

                        break;
                    case InvoiceTypeSelection.POS:
                        lstInvoiceDet = GetPOSInvoiceItemDetailsHelper();
                        break;
                    case InvoiceTypeSelection.ReturnedInvoice:
                        lstInvoiceDet = GetReturnInvoiceItemDetailsHelper();
                        break;

                    case InvoiceTypeSelection.SpoiledInvoice:
                        lstInvoiceDet =objFIndSaleInvBal.GetSpoilesItemDetailsBal();// GetPOSInvoiceItemDetailsHelper();
                        break;

                    default:

                        break;
                }
                lstInvoiceItemDetails = lstInvoiceDet;

            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

        #region TotalInvoieItemsCalc
        public void TotalInvoieItemsCalc()
        {
            objFIndSaleInvBal.objFIndSaleInvObj.TotalSale = 0.000M;
            objFIndSaleInvBal.objFIndSaleInvObj.TotalCostAmt = 0.000M;
            objFIndSaleInvBal.objFIndSaleInvObj.TotalDiscount = 0.000M;
            objFIndSaleInvBal.objFIndSaleInvObj.TotalProfit = 0.000M;
            if (lstInvoiceItemDetails.Count > 0)
            {
                for (int i = 0; i < lstInvoiceItemDetails.Count; i++)
                {
                    objFIndSaleInvBal.objFIndSaleInvObj.TotalSale = objFIndSaleInvBal.objFIndSaleInvObj.TotalSale + (lstInvoiceItemDetails[i].Quantity * lstInvoiceItemDetails[i].Price);
                    if (lstInvoiceItemDetails[i].TotalCost != 0)
                    {
                        objFIndSaleInvBal.objFIndSaleInvObj.TotalCostAmt = objFIndSaleInvBal.objFIndSaleInvObj.TotalCostAmt + lstInvoiceItemDetails[i].TotalCost;
                    }
                }

                if (lstInvoiceItemDetails[0].Discount != 0)
                {
                    objFIndSaleInvBal.objFIndSaleInvObj.TotalDiscount = lstInvoiceItemDetails[0].Discount;
                }

                objFIndSaleInvBal.objFIndSaleInvObj.TotalProfit = objFIndSaleInvBal.objFIndSaleInvObj.TotalSale - objFIndSaleInvBal.objFIndSaleInvObj.TotalCostAmt;

            }
        }
        #endregion

        #region GoToInvoice
        public void GoToInvoice()
        {
            try
            {
                switch ((InvoiceTypeSelection)objFIndSaleInvBal.objFIndSaleInvObj.InvoiceType)
                {

                    case InvoiceTypeSelection.Normal:
                        if (UserScreenLimidations.SaleInvoice)
                        {
                            Sales_Invoice objSalesInvoice = new Sales_Invoice();
                            objSalesInvoice.find_saleinv = objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo.ToString();
                            objSalesInvoice.ShowDialog();

                        }
                        else
                            GeneralFunction.Information("GotoInvoice", "Find Sale Invoice");

                        break;
                    case InvoiceTypeSelection.POS:
                        if (UserScreenLimidations.PosScreen)
                        {
                            POS_Screen objPOSScreen = new POS_Screen();
                            objPOSScreen.FindPosInvoiceNo = objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo.ToString();
                            objPOSScreen.ShowDialog();
                        }
                        else
                            GeneralFunction.Information("GotoInvoice", "Find Sale Invoice");
                        break;
                    case InvoiceTypeSelection.ReturnedInvoice:

                        if (UserScreenLimidations.SaleReturnInvoice)
                        {
                            Sales_Return_Invoice objSaleReturn = new Sales_Return_Invoice();
                            objSaleReturn.FindReturnInvoice = objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo.ToString();
                            objSaleReturn.ShowDialog();
                        }
                        else
                            GeneralFunction.Information("GotoInvoice", "Find Sale Invoice");

                        break;

                    case InvoiceTypeSelection.SpoiledInvoice:

                        if (UserScreenLimidations.SpoiledItems)
                        {
                            Spoiled_Item objSpoiledItem = new Spoiled_Item();
                            objSpoiledItem.FindSpoiledNo = objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNo.ToString();
                            objSpoiledItem.ShowDialog();
                        }
                        else
                            GeneralFunction.Information("GotoInvoice", "Find Sale Invoice");

                        break;

                    default:

                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region GetGridColor
        public Color GetGridColor(int InvoiceTypeIndex)
        {

            switch ((FindSaleInvoiceType)InvoiceTypeIndex)
            {

                case FindSaleInvoiceType.New:

                    return Color.Blue;

                case FindSaleInvoiceType.closed:

                    return Color.Navy;

                case FindSaleInvoiceType.SpoiledInvoices:

                    return Color.Red;

                case FindSaleInvoiceType.ReturnInvoice:

                    return Color.DarkOrange;

                case FindSaleInvoiceType.POS:

                    return Color.Chocolate;

                default:

                    return Color.Blue;

            }

        }
        #endregion

        #region Print
        public void Print()
        {
            AgentID = Status = Remarks = User = InvoiceNo = 0;
            DateTime? FD, TD;
            string qry = "";
            Rpt_findsalereport summery = new Rpt_findsalereport();
            ReportsView frmView = new ReportsView();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("FindSaleInvoice");
            //summery.Refresh();

            //DataTable dt = new DataTable("FindSale");
            //dt = objFIndSaleInvBal.GetFindSalesPrintReportBal();

            if (objFIndSaleInvBal.objFIndSaleInvObj.clientid.ToString() != string.Empty && objFIndSaleInvBal.objFIndSaleInvObj.clientid.ToString() != "0")
            {
                qry = "AgentID='" + objFIndSaleInvBal.objFIndSaleInvObj.clientid.ToString() + "'";
                AgentID = Convert.ToInt32(objFIndSaleInvBal.objFIndSaleInvObj.clientid);
            }

            if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeText != "")
            {
                string type = "1";
                if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "0")
                    type = "1"; //"Normal";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "1")
                    type = "";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "2")
                    type = "1"; //"NI";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "3")
                    type = "2"; //"CI";
                //else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "4")
                //    type = "Rent";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "4")
                    //type = "SI";
                    type = "4";///commented on 16 july 2014 to get the particular sopiled record from the table 
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "5")
                    type = "10";//"RI";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "6")
                    type = "2"; //"POS";



                if (((objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "3") | (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "2")))
                {
                    qry = (qry == string.Empty) ? "status='" + type + "'" : qry + " and status='" + type + "'";
                    Status = Convert.ToInt32(type);
                }
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() != "1")
                {
                    qry = (qry == string.Empty) ? "remarks='" + type + "'" : qry + " and remarks='" + type + "'";
                    Remarks = Convert.ToInt32(type);
                }
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex.ToString() == "1")
                {
                    qry = (qry == string.Empty) ? "remarks  IN('1','2','10')" : qry + " and remarks  IN('1','2','10')";
                    Remarks = 0;
                }

            }
            else
            {
                qry = (qry == string.Empty) ? "remarks ='1'" : (qry + " and remarks ='1'");
                Remarks = 1;
            }
            if (objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedIndex > -1)
            {
                // qry = qry + " and users='" + objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedValue.ToString() + "'"; //Commented on 19-May-2014
                qry = qry + " and users='" + objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedText.ToString() + "'";//Added on 19-May-2014
                User = Convert.ToInt32(objFIndSaleInvBal.objFIndSaleInvObj.UserSelectedValue);
            }
            if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNoText != string.Empty)
            {
                qry = qry + " and SaleInvoice='" + objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNoText + "'";
                InvoiceNo = Convert.ToInt32(objFIndSaleInvBal.objFIndSaleInvObj.InvoiceNoText);
            }

            if (!objFIndSaleInvBal.objFIndSaleInvObj.ChkAllChecked)
            // { qry = qry + " and saledate >= '" + Convert.ToDateTime(dtp_fromdate.Value.ToShortDateString()) + "' and saledate <= '" + Convert.ToDateTime(dtp_Todate.Value.ToString()) + "'"; }// and saledate1<= '"+dtp_Todate.Value+"'";}
            {
                qry = qry + " and saledate >= '" + objFIndSaleInvBal.objFIndSaleInvObj.fromdate + "' and saledate <= '" + objFIndSaleInvBal.objFIndSaleInvObj.todate + "'";
                FD = objFIndSaleInvBal.objFIndSaleInvObj.fromdate;
                TD = objFIndSaleInvBal.objFIndSaleInvObj.todate;
            }// and saledate1<= '"+dtp_Todate.Value+"'";}
            else { FD = null; TD = null; }



            //dt.DefaultView.RowFilter = qry;
            DataTable dt = new DataTable("FindSale");
            dt = objFIndSaleInvBal.GetFindSalesPrintReportBal(FD, TD, AgentID, User, InvoiceNo, Remarks, Status);
            DataTable dtLocal = new DataTable("FindSale");
            if (dtLocal.Columns.Count < 19)
            {
                dtLocal.Columns.Add("SaleInvoice");
                dtLocal.Columns.Add("SaleDate", typeof(DateTime));
                dtLocal.Columns.Add("AgentName");
                dtLocal.Columns.Add("AgentID");
                dtLocal.Columns.Add("Total", typeof(int));
                dtLocal.Columns.Add("Discount", typeof(int));
                dtLocal.Columns.Add("ReturnQty", typeof(int));
                dtLocal.Columns.Add("Time", typeof(DateTime));
                dtLocal.Columns.Add("Net", typeof(int));
                dtLocal.Columns.Add("SaleDate1", typeof(DateTime));
                dtLocal.Columns.Add("Status");
                dtLocal.Columns.Add("Balance", typeof(int));

                dtLocal.Columns.Add("SaleID");
                dtLocal.Columns.Add("Users");
                dtLocal.Columns.Add("Paid", typeof(int));
                dtLocal.Columns.Add("Remarks");
                dtLocal.Columns.Add("ArabicAgentName");

            }


            if (dt.DefaultView.ToTable() == null || dt.DefaultView.ToTable().Rows.Count <= 0)
            {
                GeneralFunction.Information("NoRecordsFound", "FindSaleInvoice");
                return;
            }
            dt = dt.DefaultView.ToTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();

                drAdd["SaleInvoice"] = dt.Rows[i]["SaleInvoice"].ToString();
                drAdd["SaleDate"] = Convert.ToDateTime(dt.Rows[i]["saledate"]);
                drAdd["AgentName"] = dt.Rows[i]["AgentName"].ToString();
                //drAdd["AgentID"] = dt.Rows[i]["AgentID"].ToString();
                drAdd["AgentID"] = "";
                //  drAdd["Total"] = Convert.ToInt16(dt.Rows[i]["total"]);
                drAdd["Total"] = 0;
                //drAdd["Discount"] = Convert.ToInt16(dt.Rows[i]["discount"]);
                //drAdd["ReturnQty"] = Convert.ToInt16(dt.Rows[i]["returnqty"]);
                drAdd["Discount"] = 0;
                drAdd["ReturnQty"] = 0;
                drAdd["Time"] = Convert.ToDateTime(dt.Rows[i]["Time"]);
                drAdd["Net"] = Convert.ToInt16(dt.Rows[i]["net"] != DBNull.Value ? dt.Rows[i]["net"] : 0);
                drAdd["SaleDate1"] = Convert.ToDateTime(dt.Rows[i]["saledate1"]);
                //drAdd["Status"] = dt.Rows[i]["Status"].ToString();
                //drAdd["Balance"] = Convert.ToInt16(dt.Rows[i]["balance"]);
                drAdd["Status"] = dt.Rows[i]["Status"].ToString();
                drAdd["Balance"] = 0;
                drAdd["SaleID"] = dt.Rows[i]["saleid"].ToString();

                drAdd["Users"] = dt.Rows[i]["users"].ToString();
                //drAdd["Paid"] = dt.Rows[i]["paid"].ToString();
                drAdd["Paid"] = 0;
                //drAdd["Remarks"] = dt.Rows[i]["remarks"].ToString();
                drAdd["Remarks"] = "";
                drAdd["ArabicAgentName"] = dt.Rows[i]["ArabicAgentName"].ToString();
                dtLocal.Rows.Add(drAdd);
            }

            if (dtLocal.Rows.Count > 0)
            {

                frmView.Report_Table = dtLocal;
                // Obj_viewer.Dt = dt;
                frmView.HTable.Clear();
                frmView.HTable.Add("FromDate", objFIndSaleInvBal.objFIndSaleInvObj.fromdate);
                frmView.HTable.Add("ToDate", objFIndSaleInvBal.objFIndSaleInvObj.todate);
                if (objFIndSaleInvBal.objFIndSaleInvObj.ChkAllChecked)
                {
                    frmView.HTable.Add("HideDate", true);
                }
                else
                {
                    frmView.HTable.Add("HideDate", false);
                }
                frmView.RptDoc = summery;
                frmView.isReportFooter = true;
                ReportDocument rpt = summery;
                Tables tbl = rpt.Database.Tables;
                frmView.Repnum = tbl;
                frmView.LoadEvent();
                frmView.ShowDialog();
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "FindSaleInvoice");
            }



        }
        #endregion


        #endregion

        #region
        internal void DetailedReport()
        {
            Rpt_FindsaleDetail summery = new Rpt_FindsaleDetail();
            ReportsView frmView = new ReportsView();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("FindSaleInvoice");
            //summery.Refresh();
            DataTable dt = new DataTable("SaleDetailedReport");
            int clientNo = objFIndSaleInvBal.objFIndSaleInvObj.clientid;
            // clientNo = 104;
            dt = objFIndSaleInvBal.GetFindSalesDetailedReportBal();
            if (dt.Rows.Count > 0)
            {
                // if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeText != "")
                // {
                int type = -1; int status = -1;
                if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.SaleInvoice)
                    type = 1; //"Normal";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.AllInvoices)
                    type = 0;
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.New)
                {
                    type = 3; //"NI";
                    status = 1;
                }
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.closed)
                {
                    type = 4; //"CI";
                    status = 2;
                }
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.SpoiledInvoices)
                    type = 1;
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.ReturnInvoice)
                    type = 10;//"RI";
                else if (objFIndSaleInvBal.objFIndSaleInvObj.InvoiceTypeSelectedIndex == (int)FindSaleInvoiceType.POS)
                    type = 2; //"POS";
                else    // Nothing selected means type is normal by default
                    type = 0;
                DataTable tbls = new DataTable("SaleDetailedReport");
                switch (type)
                {
                    case (1):
                    case (2):
                    case (10):
                        {
                            //Commented on 29-Oct-2014*********
                            //tbls = (from DataRow dr in dt.Rows
                            //        where Convert.ToInt32(dr["client"].ToString()) == clientNo & Convert.ToInt32(dr["remarks"].ToString()) == type
                            //        select dr).CopyToDataTable();
                            //*********************************

                            //Added on 29-Oct-2014 because of above code giving Error when no data for filtered condition 
                            DataView dvData = new DataView(dt);
                            if(clientNo!=0)
                            dvData.RowFilter = "client = '" + clientNo + "' AND remarks = '" + type + "' ";
                            else
                                dvData.RowFilter = "remarks = '" + type + "' ";
                            tbls = dvData.ToTable();
                            //*********************************

                            break;
                        }
                    case (3):
                    case (4):
                        {
                            //Commented on 29-Oct-2014*********
                            //tbls = (from DataRow dr in dt.Rows
                            //        where Convert.ToInt32(dr["client"].ToString()) == clientNo & Convert.ToInt32(dr["status"].ToString()) == status
                            //        select dr).CopyToDataTable();
                            //*********************************

                            //Added on 29-Oct-2014 because of above code giving Error when no data for filtered condition 
                            DataView dvData = new DataView(dt);
                            dvData.RowFilter = "client = '" + clientNo + "' AND status = '" + status + "' ";
                            tbls = dvData.ToTable();
                            //*************************

                            break;
                        }
                    case (0): //All Invoice
                        {
                            //Commented on 29-Oct-2014*********
                            //tbls = (from DataRow dr in dt.Rows
                            //        where Convert.ToInt32(dr["client"].ToString()) == clientNo & (Convert.ToInt32(dr["remarks"].ToString()) == Convert.ToInt32(FindSaleInvoiceType.POS.ToString()) || Convert.ToInt32(dr["remarks"].ToString()) == Convert.ToInt32(FindSaleInvoiceType.SaleInvoice.ToString()))
                            //        select dr).CopyToDataTable();
                            //*********************************


                            //Added on 29-Oct-2014 because of above code giving Error when no data for filtered condition 
                            DataView dvData = new DataView(dt);

                            if (clientNo == 0)
                            {
                                //dvData.RowFilter = " remarks IN (  '" + ((int)FindSaleInvoiceType.POS).ToString() + "' , '" + ((int)FindSaleInvoiceType.SaleInvoice).ToString() + "' )";Commented by Meena.R unable to filter the data becoz this having remarks 1,2 but there is 0,6
                                // dvData.RowFilter = " remarks IN (  '" + 1 + "' , '" + 2 + "','"+10+"' )";
                            }
                            else
                                dvData.RowFilter = "client = '" + clientNo + "' AND  remarks IN (  '" + 1 + "' , '" + 2 + "' )";//1for Sales and 2 for POS 
                            tbls = dvData.ToTable();
                            //*************************
                            break;
                        }

                    //}


                }
                if (tbls.Rows.Count > 0)
                {
                    tbls.TableName = "SaleDetailedReport";
                    frmView.Report_Table = tbls;

                    // Obj_viewer.Dt = dt;
                    //     frmView.HTable.Clear();
                    //   frmView.HTable.Add("FromDate", objFIndSaleInvBal.objFIndSaleInvObj.fromdate);
                    //   frmView.HTable.Add("ToDate", objFIndSaleInvBal.objFIndSaleInvObj.todate);
                    //if (objFIndSaleInvBal.objFIndSaleInvObj.ChkAllChecked)
                    //{
                    //    frmView.HTable.Add("HideDate", true);
                    //}
                    //else
                    //{
                    //    frmView.HTable.Add("HideDate", false);
                    //}
                    frmView.RptDoc = summery;
                    frmView.isReportFooter = true;
                    ReportDocument rpt = summery;
                    Tables tbl = rpt.Database.Tables;
                    frmView.Repnum = tbl;
                    frmView.IsItemNo = GeneralOptionSetting.FlagHideItemNumber == "Y" ? true : false;
                    frmView.LoadEvent();
                    frmView.ShowDialog();
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "FindSaleInvoice");
                }
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "FindSaleInvoice");
            }
        }
        #endregion

        #region GetReturnInvoiceItemDetailsHelper
        public List<FindSaleInvoiceObject> GetPOSInvoiceItemDetailsHelper()
        {
            return objFindSaleInvoiceBAL.GetPOSInvoiceItemDetailsBal();
        }
        #endregion
    }
}
