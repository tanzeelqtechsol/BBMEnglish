using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseHelper.DALClass;
using ObjectHelper;
using CommonHelper;
using System.Data;

namespace BALHelper
{
    public class FindSaleInvoiceBAL
    {
        #region Declaration
        FindSaleInvoiceDAL objFindSaleInvoiceDAL;
        FindSaleInvoiceObject objFindSaleInvoiceObject;

        #endregion

        #region Constructor
        public FindSaleInvoiceBAL()
        {
            objFindSaleInvoiceDAL = new FindSaleInvoiceDAL();
            objFindSaleInvoiceObject = new FindSaleInvoiceObject();
        }

        #endregion

        #region FindSaleInvoiceObject
        public FindSaleInvoiceObject objFIndSaleInvObj
        {
            get { return objFindSaleInvoiceObject; }
            set { objFindSaleInvoiceObject = value; }
        }
        #endregion

        #region Database Methods

        #region GetUser
        public List<AgentDetailObjectClass> GetUser()
        {
            //List<AgentDetailObjectClass> lstClientDetails = GeneralObjectClass.AgentDetails;
            List<AgentDetailObjectClass> lstClientDetails = new List<AgentDetailObjectClass>();
            var str = "0|102|0|0";

            //lstClientDetails = (from a in lstClientDetails
            //                    where a.AgentType != str
            //                    //orderby a.Name //Commented on 30-June-2014 for  -> Already list is ordered from Database
            //                    select a).ToList();///////Commended By Meena.R to fix the hide agent issue
            lstClientDetails = GeneralObjectClass.AgentDetails.Where(a => ((a.AgentType.Contains("101")) || (a.AgentType.Contains("103"))) && (!a.AgentType.Contains("104"))).ToList();
            //lstClientDetails.Add(new AgentDetailObjectClass
            //{
            //    AgentId = 1001,
            //    Name = "CASH CLIENT",
            //    AgentType = "101|0|0|0"

            //});

            return lstClientDetails;

        }

        #endregion

        #region GetPaymentAgentName

        public List<FindSaleInvoiceObject> GetPaymentAgentName()
        {
            //List<FindSaleInvoiceObject> lstAgentPayment = FindSaleInvoiceDAL.lstAgentPayment;
            //return lstAgentPayment;
            return FindSaleInvoiceDAL.lstAgentPayment;
        }

        #endregion

        #region GetPaymentDate
        public List<FindSaleInvoiceObject> GetPaymentDate()
        {
            //List<FindSaleInvoiceObject> lstPaymentDate = FindSaleInvoiceDAL.lstPaymentDate;
            //return lstPaymentDate;

            return FindSaleInvoiceDAL.lstPaymentDate;
        }

        #endregion

        #region LoadNotesAndAlerts
        public void LoadNotesAndAlerts()
        {
            FindSaleInvoiceDAL.LoadNotesAndAlertsData();
        }
        #endregion

        #region GetInvoiceDetailsBal
        public List<FindSaleInvoiceObject> GetInvoiceDetailsBal()
        {

            return objFindSaleInvoiceDAL.GetInvoiceDetails(objFindSaleInvoiceObject);

        }
        #endregion

        #region GetAllInvoiceDetailsBal
        public List<FindSaleInvoiceObject> GetAllInvoiceDetailsBal()
        {

            return objFindSaleInvoiceDAL.GetAllInvoiceDetails(objFindSaleInvoiceObject);

        }
        #endregion

        #region GetInvoiceItemDetailsBal
        public List<FindSaleInvoiceObject> GetInvoiceItemDetailsBal()
        {

            return objFindSaleInvoiceDAL.GetInvoiceItemDetails(objFindSaleInvoiceObject);

        }
        #endregion

        #region GetReturnInvoiceItemDetailsBal
        public List<FindSaleInvoiceObject> GetReturnInvoiceItemDetailsBal()
        {

            return objFindSaleInvoiceDAL.GetReturnInvoiceItemDetails(objFindSaleInvoiceObject);

        }
        #endregion

        #region GetFindSalesPrintReportBal
        public DataTable GetFindSalesPrintReportBal(DateTime? FD, DateTime? TD, int AgentID, int UserID, int InvoiceNo, int Remarks, int Status)
        {

            return objFindSaleInvoiceDAL.GetFindSalesPrintReport(FD, TD, AgentID, UserID, InvoiceNo, Remarks, Status);

        }

        #endregion

        #region GetBalanceSheetDetailsBal
        public List<FindSaleInvoiceObject> GetBalanceSheetDetailsBal()
        {

            return objFindSaleInvoiceDAL.GetBalanceSheetDetails(objFindSaleInvoiceObject);

        }
        #endregion

        #region Logic Methods

        public List<FindSaleInvoiceObject> FilterInvoiceListBasedOnType(List<FindSaleInvoiceObject> lstInvDetails, int InvoiceTypeIndex, int UserId)
        {
            switch ((FindSaleInvoiceType)InvoiceTypeIndex)
            {

                case FindSaleInvoiceType.SaleInvoice:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 1 && a.InvoiceTypeTwo != 9 && a.UserId == UserId //Added on 7-May-2014 -->a.InvoiceTypeTwo != 9 for avoiding Invoice Type =1 from OrderTable [Because 1 is used in Order Table Remarks]
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 1 && a.InvoiceTypeTwo != 9 //Added on 7-May-2014 -->a.InvoiceTypeTwo != 9 for avoiding Invoice Type =1 from OrderTable [Because 1 is used in Order Table Remarks]
                                         select a).ToList();
                    }
                    break;
                case FindSaleInvoiceType.AllInvoices:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType > 0 && (a.InvoiceType <= 3 || a.InvoiceType == 10) && a.UserId == UserId
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType > 0 && (a.InvoiceType <= 3 || a.InvoiceType == 10)
                                         select a).ToList();
                    }
                    break;
                case FindSaleInvoiceType.New:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.Status == 1 && a.UserId == UserId
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.Status == 1
                                         select a).ToList();
                    }
                    break;

                case FindSaleInvoiceType.closed:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.Status == 2 && a.UserId == UserId
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.Status == 2
                                         select a).ToList();
                    }
                    break;
                case FindSaleInvoiceType.SpoiledInvoices:

                    //-->Added on 7-May-2014
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 1 && a.InvoiceTypeTwo == 9 && a.UserId == UserId
                                         select a).ToList(); //Added on 7-May-2014 -->a.InvoiceTypeTwo == 9 for Order Table Identification and a.InvoiceType == 1 for Spoiled Invoice Identification [In Order Table Spoiled Invoice Remark maintained as 1]
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 1 && a.InvoiceTypeTwo == 9
                                         select a).ToList();
                    }

                    break;

                case FindSaleInvoiceType.ReturnInvoice:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 10 && a.UserId == UserId
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 10
                                         select a).ToList();
                    }
                    break;
                case FindSaleInvoiceType.POS:
                    if (UserId != 0)
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 2 && a.InvoiceTypeTwo != 9 && a.UserId == UserId //Added on 7-May-2014 -->a.InvoiceTypeTwo != 9 for avoiding Invoice Type =2 from OrderTable [Because 2 is used in Order Table Remarks]
                                         select a).ToList();
                    }
                    else
                    {
                        lstInvDetails = (from a in lstInvDetails
                                         where a.InvoiceType == 2 && a.InvoiceTypeTwo != 9 //Added on 7-May-2014 -->a.InvoiceTypeTwo != 9 for avoiding Invoice Type =2 from OrderTable [Because 2 is used in Order Table Remarks]
                                         select a).ToList();
                    }
                    break;

                default:
                    lstInvDetails = (from a in lstInvDetails
                                     where a.UserId == UserId //Added on 17-Oct-2014 by Seenivasan for filtering based on User when InvoiceType is not selected 
                                     select a).ToList();
                    break;

            }
            return lstInvDetails;
        }

        #endregion

        #endregion


        public DataTable GetFindSalesDetailedReportBal()
        {
            return objFindSaleInvoiceDAL.GetFindSalesDetailedReport(objFindSaleInvoiceObject);
        }

        #region GetReturnInvoiceItemDetailsBal
        public List<FindSaleInvoiceObject> GetPOSInvoiceItemDetailsBal()
        {
            return objFindSaleInvoiceDAL.GetPOSInvoiceItemDetails(objFindSaleInvoiceObject);
        }
        #endregion
        #region GetReturnInvoiceItemDetailsBal
        public List<FindSaleInvoiceObject> GetSpoilesItemDetailsBal()
        {
            return objFindSaleInvoiceDAL.GetSpoiledInvoiceItemDetails(objFindSaleInvoiceObject);
        }
        #endregion

    }
}
