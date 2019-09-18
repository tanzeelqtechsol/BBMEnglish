using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using BALHelper;
using System.Data;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CommonHelper;
using BumedianBM.ArabicView;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Drawing.Printing;

namespace BumedianBM.ViewHelper
{
    public class ReportHelper
    {
        ReportBAL reportbal;
        ReportObjectClass obj_report;
        ReportsView Obj_viewer;

        DataTable Get_Details;
        DataTable Get_User;
        //ReportDocument reportdocument = new ReportDocument();
        //internal DataTable dt;
        decimal decTotal, decRec = 0, decAmt = 0;
        internal Boolean isfromdebt = false;
        public ReportDocument RptDoc;

        public ReportHelper(ReportObjectClass report_object)
        {

            obj_report = report_object;
            reportbal = new ReportBAL(obj_report);
            string str = GeneralFunction.Language;
        }
        public DataSet LoadReportDetails()
        {
            return reportbal.GetDefaultItemDetails();
        }

        public void SearchCondition(string Get_Option)
        {

            Obj_viewer = new ReportsView();
            Obj_viewer.IsList = obj_report.List;
            Obj_viewer.HideLogo = !obj_report.IncludeLogo;
            try
            {

                switch (Get_Option)
                {
                    case "":
                        return;
                        break;
                    case "ItemPurchaseMovement":
                        Get_Details = reportbal.Get_SearchPurchaseMovement();
                        
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            if (Get_Details.Rows[index]["Expiry"] != DBNull.Value && !Get_Details.Rows[index]["Expiry"].ToString().Contains('-'))
                            {
                                Get_Details.Rows[index]["Expiry"] = DateTime.ParseExact(Get_Details.Rows[index]["Expiry"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            }
                        }
                        DataView dv = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv.RowFilter = "ISHide=0";
                        Get_Details = dv.ToTable();

                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_ItemPurchaseMovement RPT_ItemPurchase = new Rpt_ItemPurchaseMovement();
                            Obj_viewer.Text = CommonHelper.GeneralFunction.ChangeLanguageforCustomMsg("ItemPurchaseMovement");

                            Obj_viewer.RptDoc = RPT_ItemPurchase;

                            Obj_viewer.HTable.Clear();

                            Obj_viewer.HTable.Add("AgentName1",MasterFrom.Username.ToString());
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));
                            Obj_viewer.IsReportFooter = false;
                            Obj_viewer.IsPackage1 = true;
                            Obj_viewer.IsGroupHeader = true;
                            Obj_viewer.IsItemNo1 = true;
                            Obj_viewer.IsExpiry2 = true;
                            
                         
                            

                        }
                        break;
                    case "ItemSaleMovement":

                        Get_Details = reportbal.Get_SearchItemSaleMovement();

                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            if (Get_Details.Rows[index]["Expiry"]!=DBNull.Value && !Get_Details.Rows[index]["Expiry"].ToString().Contains('-'))
                            {
                                Get_Details.Rows[index]["Expiry"] = DateTime.ParseExact(Get_Details.Rows[index]["Expiry"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            }
                        }
                        
                        DataView dv1 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv1.RowFilter = "ISHide=0";
                        Get_Details = dv1.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_ItemSaleMovement SaleMovement = new Rpt_ItemSaleMovement();
                            Obj_viewer.Text = CommonHelper.GeneralFunction.ChangeLanguageforCustomMsg("ItemSaleMovement");

                            Obj_viewer.RptDoc = SaleMovement;
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.HTable.Add("AgentName1", MasterFrom.Username.ToString());
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));
                            Obj_viewer.IsReportFooter = false;
                            Obj_viewer.IsPackage1 = true;
                            Obj_viewer.IsItemNo2 = true;
                            Obj_viewer.IsExpiry = true;

                           

                        }

                        break;

                    case "PurchaseReturnMovement":
                        Get_Details = reportbal.Get_SearchReturnMovement();
                        DataView dv2 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv2.RowFilter = "ISHide=0";
                        Get_Details = dv2.ToTable();

                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_PurchaseReturnMovement ReturnMovement = new Rpt_PurchaseReturnMovement();
                            Obj_viewer.Text = CommonHelper.GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnMovement");

                            Obj_viewer.HTable.Clear();


                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));

                            Obj_viewer.RptDoc = ReturnMovement;
                            Obj_viewer.IsReportFooter = false;
                            Obj_viewer.IsPackage1 = true;
                            Obj_viewer.IsItemNo2 = true;

                            
                        }


                        break;
                    case "SaleReturnMovement":

                        Get_Details = reportbal.Get_SearchSaleReturnMovement();
                        DataView dv3 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv3.RowFilter = "ISHide=0";
                        Get_Details = dv3.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_SaleReturnMovement SaleReturn = new Rpt_SaleReturnMovement();
                            Obj_viewer.Text = CommonHelper.GeneralFunction.ChangeLanguageforCustomMsg("SaleReturnMovement");


                            Obj_viewer.HTable.Clear();

                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));
                            Obj_viewer.RptDoc = SaleReturn;
                            Obj_viewer.IsReportFooter = false;
                            Obj_viewer.IsPackage2 = true;
                            Obj_viewer.IsItemNo2 = true;

                           
                        }


                        break;
                    case "TotalPurchaseReturning":

                        Get_Details = reportbal.Get_SearchReturnMovement();
                        DataView dv4 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv4.RowFilter = "ISHide=0";
                        Get_Details = dv4.ToTable();
                        Get_Details.TableName = "TotalPurchaseReturning";
                        if (Get_Details.Rows.Count > 0)
                        {

                            Rpt_TotalPurchaseReturning TotalReturningPurchase = new Rpt_TotalPurchaseReturning();
                            Obj_viewer.Text = CommonHelper.GeneralFunction.ChangeLanguageforCustomMsg("TotalPurchaseReturning");

                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));
                            Obj_viewer.RptDoc = TotalReturningPurchase;
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsReportFooter = false;


                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }



                        break;
                    case "TotalSaleReturning":
                        Get_Details = reportbal.Get_TotalSaleReturnMovement();
                        DataView dv5 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv5.RowFilter = "ISHide=0";
                        Get_Details = dv5.ToTable();
                        Get_Details.TableName = "TotalSaleReturning";
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_TotalSaleReturn TotalSaleReturning = new Rpt_TotalSaleReturn();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TotalReturningSale");

                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("HideTotal", (GeneralOptionSetting.FlagPrintTotalQuantity != "Y"));
                            Obj_viewer.RptDoc = TotalSaleReturning;
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsReportFooter = false;

                           

                        }
                        break;
                    case "PriceList":
                        //obj_report.ItemType = Convert.ToInt32(CommonHelper.ItemType.SecondHand);

                        Get_Details = reportbal.Get_SearchItemPriceList();
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            if (!Get_Details.Rows[index]["Expiry"].ToString().Contains('-') && !Get_Details.Rows[index]["Expiry"].ToString().Contains("Expired"))
                            {
                                Get_Details.Rows[index]["Expiry"] = DateTime.ParseExact(Get_Details.Rows[index]["Expiry"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            }
                        }
                        DataView dv6 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv6.RowFilter = "ISHide=0";
                        Get_Details = dv6.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_PriceList ItemPriceList = new Rpt_PriceList();

                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("PriceList");
                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //Get_Details.DefaultView.RowFilter = "[StockOnHand]> 0";
                            //Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;
                            Obj_viewer.RptDoc = ItemPriceList;
                            Obj_viewer.HTable.Clear();
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsExpiry = true;

                           

                        }
                        break;

                    case "PriceListBarcode":
                        //obj_report.ItemType = Convert.ToInt32(CommonHelper.ItemType.SecondHand);

                        Get_Details = reportbal.Get_SearchItemPriceList(true);
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            Get_Details.Rows[index]["Barcode"] = GeneralFunction.EAN13(Get_Details.Rows[index]["Barcode"].ToString());
                            if (!Get_Details.Rows[index]["Expiry"].ToString().Contains('-') && !Get_Details.Rows[index]["Expiry"].ToString().Contains("Expired"))
                            {
                                Get_Details.Rows[index]["Expiry"] = DateTime.ParseExact(Get_Details.Rows[index]["Expiry"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());

                            }
                        }
                        DataView dv6Barcode = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv6Barcode.RowFilter = "ISHide=0";
                        Get_Details = dv6Barcode.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_PriceListBarcode ItemPriceList = new Rpt_PriceListBarcode();

                            Obj_viewer.Text = Additional_Barcode.GetValueByResourceKey("PriceListBarcode");
                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //Get_Details.DefaultView.RowFilter = "[StockOnHand]> 0";
                            //Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;
                            Obj_viewer.RptDoc = ItemPriceList;
                            Obj_viewer.HTable.Clear();
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsExpiry = true;



                        }
                        break;
                    case "SecondHandPriceList":
                        obj_report.ItemType = Convert.ToInt32(CommonHelper.ItemType.SecondHand);

                        Get_Details = reportbal.Get_SearchItemPriceList();
                        DataView dv7 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv7.RowFilter = "ISHide=0";
                        Get_Details = dv7.ToTable();
                        Get_Details.TableName = "SecondHandPriceList";
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_SecondHandPriceLists ItemPriceList = new Rpt_SecondHandPriceLists();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SecondHandPriceList");

                            Obj_viewer.RptDoc = ItemPriceList;
                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //Get_Details.DefaultView.RowFilter = "[StockOnHand]> 0";
                            //Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;
                            Obj_viewer.HTable.Clear();
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                          
                        }

                        break;





                    case "WellMovingItems":
                        Get_Details = reportbal.Get_SearchWellMovingItem();
                        DataView dv8 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv8.RowFilter = "ISHide=0";
                        Get_Details = dv8.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_SlowQuickMovingItem SlowQuickMovingItem = new Rpt_SlowQuickMovingItem();
                            //SlowQuickMovingItem.Refresh();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("WellMovingItems");


                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"]));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.RptDoc = SlowQuickMovingItem;
                            Obj_viewer.HTable.Add("ReportName", Obj_viewer.Text);
                            Obj_viewer.IsItemNo = true;

                           

                        }
                        break;
                    case "SpoiledItems":
                        Get_Details = reportbal.Get_SearchSpoiledItem();
                        DataView dv9 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv9.RowFilter = "ISHide=0";
                        Get_Details = dv9.ToTable();
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            if (!Get_Details.Rows[index]["ExpiryDate"].ToString().Contains('-'))
                            {
                                Get_Details.Rows[index]["ExpiryDate"] = DateTime.ParseExact(Get_Details.Rows[index]["ExpiryDate"].ToString().Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            }
                        }
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_SpoiledItems SpoiledItem = new Rpt_SpoiledItems();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SpoiledItems");

                            Obj_viewer.RptDoc = SpoiledItem;

                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsExpiry = true;
                           

                        }
                        break;
                    case "Inventory":
                        Get_Details = reportbal.Get_SearchInventoryItem();
                        DataView dv10 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv10.RowFilter = "ISHide=0";
                        Get_Details = dv10.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_InventoryList InventoryList = new Rpt_InventoryList();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Inventory");
                            Obj_viewer.RptDoc = InventoryList;
                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //Get_Details.DefaultView.RowFilter = "[Quantity]> 0";
                            //Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;
                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                                Obj_viewer.HTable.Add("HideFromDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                                Obj_viewer.HTable.Add("HideFromDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("ReportName", Obj_viewer.Text);
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.isPackage = true;

                          

                        }
                        break;

                    case "InventoryAtDate":

                        Get_Details = reportbal.Get_SearchInventoryAtDate();
                        DataView dv11 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv11.RowFilter = "ISHide=0";
                        Get_Details = dv11.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_InventoryList InventoryAtDate = new Rpt_InventoryList();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("InventoryAtDate");

                            Obj_viewer.RptDoc = InventoryAtDate;

                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //Get_Details.DefaultView.RowFilter = "[Quantity]> 0";
                            //Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("HideDate", false);
                            Obj_viewer.HTable.Add("HideFromDate", true);
                            Obj_viewer.HTable.Add("ReportName", Obj_viewer.Text);
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.isPackage = true;
                        }
                        break;
                    case "ExpiryListToADate":
                        Get_Details = reportbal.Get_SearchExpiryListToADate();
                        Get_Details.Columns.Add("ExpDate", typeof(string));
                        DataView dv12 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv12.RowFilter = "ISHide=0";
                        Get_Details = dv12.ToTable();
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            // Get_Details.Rows[index]["ExpiryDate"] = Convert.ToDateTime(Get_Details.Rows[index]["ExpiryDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            Get_Details.Rows[index]["ExpDate"] = Convert.ToDateTime(Get_Details.Rows[index]["ExpiryDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                        }
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_ExpiredListbyDate ExpiryListTaDate = new Rpt_ExpiredListbyDate();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ExpiryListToADate");
                            Obj_viewer.RptDoc = ExpiryListTaDate;
                            Obj_viewer.HTable.Clear();

                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.IsItemNo = true;
                            Obj_viewer.IsExpiry = true;

                          



                        }
                        break;
                    case "ItemCardInOutStock":
                        Get_Details = reportbal.Get_SearchItemCardInOutStock();
                        int sum = 0;
                        string itemname = "";
                        if (Get_Details.Rows.Count > 0)
                            itemname = Get_Details.Rows[0]["ItemName"].ToString();
                        for (int i = 0; i < Get_Details.Rows.Count; i++)
                        {
                            if (itemname != Get_Details.Rows[i]["ItemName"].ToString())
                            {
                                sum = 0;
                                itemname = Get_Details.Rows[i]["ItemName"].ToString();
                            }
                            sum = sum + Convert.ToInt32(Get_Details.Rows[i]["CurrentStock"].ToString());
                            Get_Details.Rows[i]["CurrentStock"] = sum;

                        }
                        DataView dv13 = new DataView(Get_Details);///////Include this line to filter the hide item fromthe table 
                        dv13.RowFilter = "ISHide=0";
                        Get_Details = dv13.ToTable();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_ItemCard ItemCard = new Rpt_ItemCard();

                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ItemCardInOut");
                            //ItemCard.Refresh();
                            Obj_viewer.RptDoc = ItemCard;
                            Obj_viewer.HTable.Clear();

                            Obj_viewer.HTable.Add("WholeSalePrice", 0);
                            Obj_viewer.HTable.Add("MinPrice", 0);

                            Obj_viewer.HTable.Add("Price", 0);
                            Obj_viewer.HTable.Add("ItemCost", 0);
                            Obj_viewer.HTable.Add("HideDate", true);

                            //------------commented on 15 july 2014-------------------
                            //if (obj_report.CheckDateField)
                            //{
                            //    Obj_viewer.HTable.Add("FromDate", "");
                            //    Obj_viewer.HTable.Add("ToDate", "");
                            //    Obj_viewer.HTable.Add("HideDate", true);
                            //}
                            //else
                            //{
                            //    Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            //    Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            //    Obj_viewer.HTable.Add("HideDate", false);
                            //}
                            //------------------------------------------------------------
                            Obj_viewer.IsReportFooter = false;
                            Obj_viewer.IsGroupHeader = true;
                            Obj_viewer.IsItemNo1 = true;
                            //ReportDocument rpt = ItemCard;
                            //Tables tbl = rpt.Database.Tables;
                            ////Obj_viewer.Repnum = tbl;
                            ////Obj_viewer.ShowDialog();

                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        break;
                    case "HourlySales":
                        Get_Details = reportbal.Get_SearchHourlySalesBAL();
                        if (Get_Details.Rows.Count > 0)
                        {
                            RptChart_HourlySales HrsSales = new RptChart_HourlySales();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("HourlySales");
                            Obj_viewer.RptDoc = HrsSales;
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.isChartType = obj_report.Linear;
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("language", GeneralFunction.Language);

                            Obj_viewer.IsReportFooter = false;
                        }
                        break;
                    case "MonthssComparison":
                        Get_Details = reportbal.Get_SearchMonthlySalesBAL();
                        if (Get_Details.Rows.Count > 0)
                        {
                            if (ConfigurationSettings.AppSettings["Language"] == "Arabic") // Added this condition on 27-Nov-2014 by Seenivasan for Avoiding the Month Overlapping in English Lang
                            {
                                Get_Details.Rows[0]["Month"] = Additional_Barcode.GetValueByResourceKey("Jan");// GeneralFunction.ChangeLanguageforCustomMsg("Jan");
                                Get_Details.Rows[1]["Month"] = Additional_Barcode.GetValueByResourceKey("Feb");// GeneralFunction.ChangeLanguageforCustomMsg("Feb");
                                Get_Details.Rows[2]["Month"] = Additional_Barcode.GetValueByResourceKey("Mar");//GeneralFunction.ChangeLanguageforCustomMsg("Mar");
                                Get_Details.Rows[3]["Month"] = Additional_Barcode.GetValueByResourceKey("Apr");//GeneralFunction.ChangeLanguageforCustomMsg("Apr");
                                Get_Details.Rows[4]["Month"] = Additional_Barcode.GetValueByResourceKey("May");//GeneralFunction.ChangeLanguageforCustomMsg("May");
                                Get_Details.Rows[5]["Month"] = Additional_Barcode.GetValueByResourceKey("Jun");//GeneralFunction.ChangeLanguageforCustomMsg("Jun");
                                Get_Details.Rows[6]["Month"] = Additional_Barcode.GetValueByResourceKey("Jul");//GeneralFunction.ChangeLanguageforCustomMsg("Jul");
                                Get_Details.Rows[7]["Month"] = Additional_Barcode.GetValueByResourceKey("Aug");//GeneralFunction.ChangeLanguageforCustomMsg("Aug");
                                Get_Details.Rows[8]["Month"] = Additional_Barcode.GetValueByResourceKey("Sep");//GeneralFunction.ChangeLanguageforCustomMsg("Sep");
                                Get_Details.Rows[9]["Month"] = Additional_Barcode.GetValueByResourceKey("Oct");//GeneralFunction.ChangeLanguageforCustomMsg("Oct");
                                Get_Details.Rows[10]["Month"] = Additional_Barcode.GetValueByResourceKey("Nov");//GeneralFunction.ChangeLanguageforCustomMsg("Nov");
                                Get_Details.Rows[11]["Month"] = Additional_Barcode.GetValueByResourceKey("Dec");//GeneralFunction.ChangeLanguageforCustomMsg("Dec");
                            }
                            RptChat_MonthlySales MonthSales = new RptChat_MonthlySales();
                            //RptChart_HourlySales HrsSales = new RptChart_HourlySales();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("HourlySales");
                            Obj_viewer.RptDoc = MonthSales;
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.isChartType = obj_report.Linear;
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("language", GeneralFunction.Language);
                            Obj_viewer.IsReportFooter = false;
                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "HourlySales");
                            return;
                        }

                        break;
                    case "UserProductivity":
                        Get_Details = reportbal.Get_SearchUserProductivityBAL();
                        if (Get_Details.Rows.Count > 0)
                        {
                            RptChart_UserProductivity UsrProduct = new RptChart_UserProductivity();
                            //Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("UserProduct");
                            Obj_viewer.Text = Additional_Barcode.GetValueByResourceKey("UserProduct");
                            Obj_viewer.RptDoc = UsrProduct;
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.isChartType = obj_report.Linear;

                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("language", GeneralFunction.Language);
                            Obj_viewer.IsReportFooter = false;
                            ReportDocument rpt = UsrProduct;
                            Tables tbl = rpt.Database.Tables;
                            Obj_viewer.Repnum = tbl;
                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "HourlySales");
                            return;
                        }

                        break;
                    case "BestWorstSalesPeriod":
                        Get_Details = reportbal.Get_SearchBestWorstBAL();
                        if (Get_Details.Rows.Count > 0)
                        {
                            //updated by mahender
                            //Additional_Barcode.GetValueByResourceKey("Jan");
                            Get_Details.Rows[0]["Month"] = Additional_Barcode.GetValueByResourceKey("Jan");// GeneralFunction.ChangeLanguageforCustomMsg("Jan");
                            Get_Details.Rows[1]["Month"] = Additional_Barcode.GetValueByResourceKey("Feb");// GeneralFunction.ChangeLanguageforCustomMsg("Feb");
                            Get_Details.Rows[2]["Month"] = Additional_Barcode.GetValueByResourceKey("Mar");//GeneralFunction.ChangeLanguageforCustomMsg("Mar");
                            Get_Details.Rows[3]["Month"] = Additional_Barcode.GetValueByResourceKey("Apr");//GeneralFunction.ChangeLanguageforCustomMsg("Apr");
                            Get_Details.Rows[4]["Month"] = Additional_Barcode.GetValueByResourceKey("May");//GeneralFunction.ChangeLanguageforCustomMsg("May");
                            Get_Details.Rows[5]["Month"] = Additional_Barcode.GetValueByResourceKey("Jun");//GeneralFunction.ChangeLanguageforCustomMsg("Jun");
                            Get_Details.Rows[6]["Month"] = Additional_Barcode.GetValueByResourceKey("Jul");//GeneralFunction.ChangeLanguageforCustomMsg("Jul");
                            Get_Details.Rows[7]["Month"] = Additional_Barcode.GetValueByResourceKey("Aug");//GeneralFunction.ChangeLanguageforCustomMsg("Aug");
                            Get_Details.Rows[8]["Month"] = Additional_Barcode.GetValueByResourceKey("Sep");//GeneralFunction.ChangeLanguageforCustomMsg("Sep");
                            Get_Details.Rows[9]["Month"] = Additional_Barcode.GetValueByResourceKey("Oct");//GeneralFunction.ChangeLanguageforCustomMsg("Oct");
                            Get_Details.Rows[10]["Month"] = Additional_Barcode.GetValueByResourceKey("Nov");//GeneralFunction.ChangeLanguageforCustomMsg("Nov");
                            Get_Details.Rows[11]["Month"] = Additional_Barcode.GetValueByResourceKey("Dec");//GeneralFunction.ChangeLanguageforCustomMsg("Dec");
                            RptChart_BestWorstSalesPeriod bestWorstSal = new RptChart_BestWorstSalesPeriod();
                            Obj_viewer.Text = Additional_Barcode.GetValueByResourceKey("BestWorstSalesPeriod");// GeneralFunction.ChangeLanguageforCustomMsg("UserProduct");
                            Obj_viewer.RptDoc = bestWorstSal;
                            Obj_viewer.HTable.Clear();
                            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                            {
                                Obj_viewer.HTable.Add("monthformat", 0);
                                Obj_viewer.HTable.Add("dayformat", 0);
                                Obj_viewer.HTable.Add("yearformat", 0);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 1);
                            }
                            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "-");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("monthformat", 1);
                                Obj_viewer.HTable.Add("dayformat", 1);
                                Obj_viewer.HTable.Add("yearformat", 1);
                                Obj_viewer.HTable.Add("seperatorformat", "/");
                                Obj_viewer.HTable.Add("dateformat", 0);
                            }
                            Obj_viewer.HTable.Add("language", GeneralFunction.Language);
                            Obj_viewer.isChartType = obj_report.Linear;
                            Obj_viewer.IsReportFooter = false;
                            ReportDocument rpt = bestWorstSal;
                            Tables tbl = rpt.Database.Tables;
                            Obj_viewer.Repnum = tbl;
                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "HourlySales");
                            return;
                        }

                        break;
                    ///******Account Tab*****\\\\\\\
                    case "Zakat":
                        Rpt_ZakatCalculationReport summery = new Rpt_ZakatCalculationReport();
                        Obj_viewer = new ReportsView();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Zakat");
                        DataSet ds = new DataSet();
                        ds = reportbal.Get_Zakat();
                        DataTable dt = new DataTable("Zakat");
                        DataTable dt1 = new DataTable();
                        dt = ds.Tables[0];
                        dt.TableName = "Zakat";
                        dt1 = ds.Tables[1];
                        ds.Tables.Remove(ds.Tables[0]);
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        float payable = 0;
                        float receivable = 0;
                        if (dt.Rows.Count > 0)
                        {
                            float pa = 0.0f;
                            float re = 0.0f;
                            float paid = 0.0f;
                            float rec = 0.0f;
                            //pa = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Payable)", string.Empty).ToString()) : 0.0f;
                            //re = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Receivable)", string.Empty).ToString()) : 0.0f;
                            //paid = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Paid)", string.Empty).ToString()) : 0.0f;
                            //rec = (dt.Rows.Count > 0) ? float.Parse(dt1.Compute("sum(Received)", string.Empty).ToString()) : 0.0f;
                            //payable = pa - paid;
                            //receivable = re - rec;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (float.Parse(ds.Tables[0].Rows[i]["Payable"].ToString()) > float.Parse(ds.Tables[0].Rows[i]["Receivable"].ToString()))
                                {
                                    receivable += float.Parse(ds.Tables[0].Rows[i]["Payable"].ToString()) - float.Parse(ds.Tables[0].Rows[i]["Receivable"].ToString());
                                }
                                else
                                {
                                    payable += float.Parse(ds.Tables[0].Rows[i]["Receivable"].ToString()) - float.Parse(ds.Tables[0].Rows[i]["Payable"].ToString());
                                }
                            }
                        }
                        Obj_viewer.HTable.Clear();
                        Obj_viewer.HTable.Add("Tot_Receivable", receivable);
                        Obj_viewer.HTable.Add("Tot_Payable", payable);
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.RptDoc = summery;
                        Obj_viewer.IsReportFooter = false;
                        Get_Details = dt;
                        Obj_viewer.RptDoc = summery;
                        break;
                    case "BranchBalanceSheet":
                    case "AgentBalanceSheet":
                    case "Client_AgentBalanceSheet":
                    case "Supplier_AgentBalanceSheet":
                        //**********************Added  on 16-Oct-2014*******************************************************************************************
                        DataSet dsAgentList = new DataSet();
                        dsAgentList = LoadReportDetails();
                        DataTable dtBalanceDet = new DataTable();
                        dt = new DataTable("BalanceSheet");
                        dt.Columns.Clear();
                        if (dt.Columns.Count < 7)
                        {
                            dt.Columns.Add("Date");
                            dt.Columns.Add("Description");
                            dt.Columns.Add("AmountReceived", typeof(decimal));
                            dt.Columns.Add("NetAmt", typeof(decimal));
                            dt.Columns.Add("AgentID");
                            dt.Columns.Add("AgentName");
                            dt.Columns.Add("AgentType");
                        }

                        if (dsAgentList.Tables.Count > 4)
                        {
                            if (dsAgentList.Tables[4].Rows.Count > 0)
                            {
                                for (int i = 0; i < dsAgentList.Tables[4].Rows.Count; i++)
                                {
                                    BalanceSheetHelper objBalanceSheetHelper = new BalanceSheetHelper();
                                    objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.AgentID = Convert.ToInt32(dsAgentList.Tables[4].Rows[i]["AgentID"].ToString());
                                    if (obj_report.CheckDateField)
                                    {
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceFromDate = null;
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceToDate = null;
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = 1;
                                    }
                                    else
                                    {
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceFromDate = obj_report.FromDate;
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.BalanceToDate = obj_report.ToDate;
                                        objBalanceSheetHelper.objBalanceSheetBAL.objBalanceSheetObjcetClass.Status = 0;
                                    }

                                    dtBalanceDet = objBalanceSheetHelper.objBalanceSheetBAL.GetBalanceDetails();
                                    if (dtBalanceDet.Rows.Count > 0)
                                    {
                                        for (int j = 0; j < dtBalanceDet.Rows.Count; j++)
                                        {
                                            DataRow drAddNew;
                                            drAddNew = dt.NewRow();
                                            //var date = Convert.ToDateTime(dtBalanceDet.Rows[j]["Dates"]).Date.ToString().Split(' ')[1];//Added by Madhu on 15-Oct-2014
                                            var date = Convert.ToDateTime(dtBalanceDet.Rows[j]["Dates"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                                            drAddNew["Date"] = date;// Commented above line by Seenivasan & added this line On 13-Oct-2014

                                            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                                            {
                                                drAddNew["Description"] = dtBalanceDet.Rows[j]["Description"].ToString();
                                            }
                                            else if (Thread.CurrentThread.CurrentUICulture.Name == "ar-SA")
                                            {
                                                string[] strSplit = dtBalanceDet.Rows[j]["Description"].ToString().Split(' ');
                                                drAddNew["Description"] = (strSplit.Length > 1) ? GetInvoiceName(strSplit[0]) + " " + dtBalanceDet.Rows[j]["Description"].ToString().Substring(strSplit[0].Length, (dtBalanceDet.Rows[j]["Description"].ToString().Length - strSplit[0].Length)) : GetInvoiceName(strSplit[0]);
                                            }

                                            drAddNew["AmountReceived"] = Convert.ToDecimal(dtBalanceDet.Rows[j]["AmtReceived"]);
                                            drAddNew["NetAmt"] = Convert.ToDecimal(dtBalanceDet.Rows[j]["NetAmount"]);
                                            drAddNew["AgentName"] = dsAgentList.Tables[4].Rows[i]["AgentName"].ToString();
                                            drAddNew["AgentID"] = dtBalanceDet.Rows[j]["AgentID"].ToString();
                                            drAddNew["AgentType"] = dtBalanceDet.Rows[j]["AgentType"].ToString();
                                            dt.Rows.Add(drAddNew);
                                        }
                                    }
                                }
                            }
                        }
                        //***************************************************************************************************************************************************
                        decRec = decAmt = decTotal = 0;
                        Rpt_AgentBalanceSheet ABS = new Rpt_AgentBalanceSheet();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("AgentBalanceSheet");
                        //string reportname = "Agent Balance Sheet";
                        //on 13-10-2014 by Ritu, Changed the name of Agent Balance sheet according to the culture.
                        string reportname = GeneralFunction.ChangeLanguageforCustomMsg("AgentBalanceSheet");
                        //dt = new DataTable("BalanceSheet");//Commented on 16-Oct-2014
                        //dt = reportbal.Get_BalanceSheetBAL();//Commented on 16-Oct-2014
                        DataView dgv = new DataView(dt);
                        switch (Get_Option)
                        {
                            //case "AgentBalanceSheet":
                            //    qry = "Select * from View_AgentBalanceSheet";
                            //    break;
                            case "BranchBalanceSheet":
                                reportname = "Branch Balance Sheet";
                                dgv.RowFilter = "AgentType LIKE '%BRANCH%'";
                                dt = dgv.ToTable();
                                break;
                            case "Client_AgentBalanceSheet":
                                dgv.RowFilter = "AgentType LIKE '%CLIENT%'";
                                dt = dgv.ToTable();
                                break;
                            case "Supplier_AgentBalanceSheet":
                                dgv.RowFilter = "AgentType LIKE '%Supplier%'";
                                dt = dgv.ToTable();
                                break;
                            case "Branch_BranchBalanceSheet":
                                dgv.RowFilter = "AgentType LIKE '%BRANCH%'";
                                dt = dgv.ToTable();
                                reportname = "Branch Balance Sheet";
                                break;
                            //case "AgentBalanceSheet":

                            //  break;
                            default:
                                //qry = "Select * from View_AgentBalanceSheet";
                                break;
                        }

                        //if (!obj_report.CheckDateField)
                        //{
                        //    dgv.RowFilter = " Date >='" + obj_report.FromDate + "' and Date <='" + obj_report.ToDate + "'";
                        //    dt = dgv.ToTable();
                        //}

                        if (obj_report.AgentID != 0)
                        {
                            dgv.RowFilter = "AgentID='" + obj_report.AgentID + "'";
                            dt = dgv.ToTable();
                        }
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        // SortReportListDetails(ref dt);
                        DataTable dtLocal = new DataTable("BalanceSheet");
                        if (dtLocal.Columns.Count < 8)
                        {
                            dtLocal.Columns.Add("Date");
                            dtLocal.Columns.Add("Account");
                            dtLocal.Columns.Add("Description");
                            dtLocal.Columns.Add("Receivable", typeof(decimal));
                            dtLocal.Columns.Add("Payable", typeof(decimal));
                            dtLocal.Columns.Add("Balance", typeof(decimal));
                            dtLocal.Columns.Add("AgentID");
                            dtLocal.Columns.Add("AgentName");
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = dtLocal.NewRow();
                            //On 13-10-2014 by Ritu.Changed the datetime to date and applied the date format
                            //drAdd["Date"] = Convert.ToDateTime(dt.Rows[i]["Date"]).Date.ToString(ConfigurationSettings.AppSettings["DateFormat"].ToString()); //Ritu Changes On 13-Oct-2014
                            //var date = Convert.ToDateTime(dt.Rows[i]["Date"]).Date.ToString().Split(' ')[1];//Added by Madhu on 15-Oct-2014
                            // var date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString()).Date.ToString();
                            drAdd["Date"] = dt.Rows[i]["Date"].ToString();// Commented above line by Seenivasan & added this line On 13-Oct-2014
                            drAdd["Account"] = "1";
                            drAdd["Description"] = dt.Rows[i]["Description"].ToString();
                            drAdd["Receivable"] = Convert.ToDecimal(dt.Rows[i]["AmountReceived"].ToString());
                            drAdd["Payable"] = Convert.ToDecimal(dt.Rows[i]["NetAmt"].ToString());

                            decAmt = decAmt + Convert.ToDecimal(dt.Rows[i]["NetAmt"]);
                            decRec = decRec + Convert.ToDecimal(dt.Rows[i]["AmountReceived"]);


                            //if (dt.Rows[i]["AmountReceived"].ToString() == "0.0000") //Commented by Seenivasan on 16-Oct-2014 .Because this condition is not checking the Zero value properly & Leads to Wrong Balance Value
                            //{
                            if (Convert.ToDecimal(dt.Rows[i]["AmountReceived"]) == 0.0m)
                            {
                                decTotal = decTotal + (Convert.ToDecimal(dt.Rows[i]["NetAmt"]));
                                drAdd["Balance"] = decTotal;
                            }
                            else
                            {
                                decTotal = decTotal - (Convert.ToDecimal(dt.Rows[i]["AmountReceived"]));
                                drAdd["Balance"] = decTotal;
                            }

                            if (drAdd["Balance"].ToString().IndexOf("-") >= 0)
                            {
                                drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"].ToString().Remove(0, 1));
                            }
                            else { drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"]); }
                            drAdd["AgentID"] = dt.Rows[i]["AgentID"].ToString();
                            drAdd["AgentName"] = dt.Rows[i]["AgentName"].ToString();
                            dtLocal.Rows.Add(drAdd);
                        }
                        Get_Details = dtLocal;
                        Obj_viewer.HTable.Clear();
                        Obj_viewer.HTable.Add("ReportName", reportname);
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        if (obj_report.AgentName == string.Empty && obj_report.AgentName == null)
                        {
                            Obj_viewer.HTable.Add("HideAgent", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("HideAgent", false);
                        }
                        Obj_viewer.RptDoc = ABS;
                        break;
                    case "DebtsToBePaid":
                        Rpt_List_of_Debts_to_pay DebtToPay = new Rpt_List_of_Debts_to_pay();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("DebttobePaid");
                        dt = reportbal.Get_DebtsDetails();
                        dt.Columns.Add("PaymentDate");
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            GeneralFunction.AgentId.Clear();
                            GeneralFunction.AgentId.Add(dt.Rows[k]["AgentID"].ToString());
                            dt.Rows[k]["Balance"] = GeneralFunction.AgentDept();
                            if (dt.Rows[k]["PayDate"] != DBNull.Value)
                            {
                                dt.Rows[k]["PaymentDate"] = Convert.ToDateTime(dt.Rows[k]["PayDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            }
                        }
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }

                        Obj_viewer.RptDoc = DebtToPay;
                        ReportDocument RptDebtToPay = DebtToPay;
                        Tables tblDebtToPay = RptDebtToPay.Database.Tables;
                        Obj_viewer.Repnum = tblDebtToPay;
                        Get_Details = dt;
                        break;
                    case "BankStatement":
                        decTotal = 0;
                        Rpt_BankBalanceSheet BBS = new Rpt_BankBalanceSheet();
                        Obj_viewer = new ReportsView();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("BalanceSheet");
                        dt = new DataTable("BankBalanceSheet");
                        dt = reportbal.Get_BankBalanceSheet();
                        if (obj_report.BankName.Length != 0 && obj_report.BankName != null)
                        {
                            DataView dgvBBS = new DataView(dt);
                            dgvBBS.RowFilter = "BankName='" + obj_report.BankName + "'";
                            dt = dgvBBS.ToTable();
                        }
                        DataTable dtLocalBBS = new DataTable("BankBalanceSheet");
                        if (dtLocalBBS.Columns.Count < 6)
                        {
                            dtLocalBBS.Columns.Add("Date");
                            dtLocalBBS.Columns.Add("Description");
                            dtLocalBBS.Columns.Add("Users");
                            dtLocalBBS.Columns.Add("Deposite", typeof(decimal));
                            dtLocalBBS.Columns.Add("Withdraw", typeof(decimal));
                            dtLocalBBS.Columns.Add("Credit", typeof(decimal));
                            dtLocalBBS.Columns.Add("Bank");
                            dtLocalBBS.Columns.Add("Branch");
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = dtLocalBBS.NewRow();
                            drAdd["Date"] = Convert.ToDateTime(dt.Rows[i]["Date"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            drAdd["Description"] = dt.Rows[i]["Description"].ToString();
                            drAdd["Users"] = dt.Rows[i]["USERS"].ToString();
                            drAdd["Deposite"] = Convert.ToDecimal(dt.Rows[i]["Deposite"].ToString());
                            drAdd["Withdraw"] = Convert.ToDecimal(dt.Rows[i]["Withdraw"].ToString());
                            if (dt.Rows[i]["Withdraw"].ToString() == "0.0000")
                            {
                                decTotal = decTotal + (Convert.ToDecimal(dt.Rows[i]["Deposite"]));
                                drAdd["CREDIT"] = decTotal;
                            }
                            else
                            {
                                decTotal = decTotal - (Convert.ToDecimal(dt.Rows[i]["Withdraw"]));
                                drAdd["Credit"] = decTotal;
                            }

                            if (drAdd["Credit"].ToString().IndexOf("-") >= 0)
                            {
                                drAdd["Credit"] = Convert.ToDecimal(drAdd["Credit"].ToString().Remove(0, 1));
                            }
                            else { drAdd["Credit"] = Convert.ToDecimal(drAdd["Credit"]); }
                            drAdd["Bank"] = dt.Rows[i]["BankName"].ToString();
                            drAdd["Branch"] = dt.Rows[i]["BranchName"].ToString();

                            dtLocalBBS.Rows.Add(drAdd);
                        }
                        Obj_viewer.HTable.Clear();
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.RptDoc = BBS;
                        Get_Details = dtLocalBBS;

                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }


                        break;
                    case "TaxList":
                        Rpt_TaxList TaxList = new Rpt_TaxList();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TaxList");
                        dt = new DataTable("TaxList");
                        dt = reportbal.Get_TaxList();
                        if (dt == null || dt.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Obj_viewer.HTable.Clear();
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.RptDoc = TaxList;
                        Obj_viewer.IsReportFooter = false;
                        Get_Details = dt;

                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }


                        break;

                    case "NetProfit":
                        Rpt_NetProfit2 netProfit = new Rpt_NetProfit2();
                        DataSet DsNetProfit = new DataSet();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("NetProfit");
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            obj_report.Flag = "All";
                            obj_report.FromDate = obj_report.ToDate = DateTime.Now.Date;
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("HideDate", false);// Obj_BalSheetDal.GetNetProfit(Chk_AllDateTime.Checked ? DateTime.Now : FromDate, Chk_AllDateTime.Checked ? DateTime.Now : ToDate, Chk_AllDateTime.Checked ? "All" : "Selected");
                            obj_report.Flag = "";//on 06-11-2014 by Ritujeet, to not apply filter when all is checked
                        }
                        int novalue = 0;
                        DsNetProfit = reportbal.Get_NetProfit();
                        for (int j = 0; j < DsNetProfit.Tables.Count; j++)
                        {
                            for (int k = 0; k < DsNetProfit.Tables[j].Columns.Count; k++)
                            {
                                if (DsNetProfit.Tables[j].Rows[0][k].ToString() == string.Empty)
                                    DsNetProfit.Tables[j].Rows[0][k] = 0;
                                if (Convert.ToDecimal(DsNetProfit.Tables[j].Rows[0][k].ToString()) > 0)
                                {
                                    novalue = 1;
                                }
                            }

                        }
                        if (novalue == 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }

                        if (DsNetProfit != null && DsNetProfit.Tables.Count >= 4)
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString().Split(' ')[1]);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString().Split(' ')[1]);
                            Obj_viewer.HTable.Add("TotalSales", DsNetProfit.Tables[0].Rows[0]["TotalSales"]);
                            Obj_viewer.HTable.Add("SaleReturn", DsNetProfit.Tables[0].Rows[0]["SaleReturn"]);
                            Obj_viewer.HTable.Add("SaleCost", DsNetProfit.Tables[0].Rows[0]["SaleCost"]);
                            Obj_viewer.HTable.Add("SpoiledItems", DsNetProfit.Tables[1].Rows[0]["SpoiledItems"]);
                            Obj_viewer.HTable.Add("Salary", DsNetProfit.Tables[4].Rows[0]["Salary"]);
                            Obj_viewer.HTable.Add("Spending", DsNetProfit.Tables[2].Rows[0]["Spending"]);
                            Obj_viewer.HTable.Add("RentSpending", DsNetProfit.Tables[3].Rows[0]["RentSpending"]);
                            Obj_viewer.RptDoc = netProfit;
                            Obj_viewer.IsItemNo = false;
                            Obj_viewer.IsReportFooter = false;
                            Get_Details = DsNetProfit.Tables[0];
                            DsNetProfit.Tables.RemoveAt(0);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        break;
                    case "Receivables":
                        Rpt_ReceivedCash Receivable = new Rpt_ReceivedCash();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Receivables");
                        DataTable dtRec = new DataTable("Receivables");
                        dtRec = reportbal.Get_Receivables(); //Obj_BalSheetDal.Get_ReportValues(qry, "Receivables");
                        if (dtRec == null || dtRec.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        DataTable dtReceivables = new DataTable("Receivables");
                        if (dtReceivables.Columns.Count < 11)
                        {
                            dtReceivables.Columns.Add("Date");//, typeof(DateTime));
                            dtReceivables.Columns.Add("AgentID");
                            dtReceivables.Columns.Add("AgentName");
                            dtReceivables.Columns.Add("Description");
                            dtReceivables.Columns.Add("Payment");
                            dtReceivables.Columns.Add("BankName");
                            dtReceivables.Columns.Add("BranchName");
                            dtReceivables.Columns.Add("AmountReceived", typeof(decimal));
                        }
                        for (int i = 0; i < dtRec.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = dtReceivables.NewRow();
                            drAdd["Date"] = Convert.ToDateTime(dtRec.Rows[i]["Date"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            drAdd["AgentID"] = dtRec.Rows[i]["AgentID"].ToString();
                            drAdd["AgentName"] = dtRec.Rows[i]["AgentName"].ToString();
                            drAdd["Description"] = dtRec.Rows[i]["Description"].ToString();
                            drAdd["Payment"] = dtRec.Rows[i]["Payment"].ToString();
                            drAdd["BankName"] = dtRec.Rows[i]["BankName"].ToString();
                            drAdd["BranchName"] = dtRec.Rows[i]["BranchName"].ToString();
                            drAdd["AmountReceived"] = Convert.ToDecimal(dtRec.Rows[i]["AmountReceived"].ToString());
                            dtReceivables.Rows.Add(drAdd);
                        }
                        Get_Details = dtReceivables;
                        Obj_viewer.RptDoc = Receivable;
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }


                        break;
                    case "Payables":
                        Rpt_PaidCash Payable = new Rpt_PaidCash();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Payables");
                        DataTable dtpay = new DataTable("Payables");
                        dtpay = reportbal.Get_Payable();
                        if (dtpay == null || dtpay.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        DataTable Pay = new DataTable("Payables");
                        if (Pay.Columns.Count < 11)
                        {
                            Pay.Columns.Add("Date");//, typeof(DateTime));
                            Pay.Columns.Add("AgentID");
                            Pay.Columns.Add("AgentName");
                            Pay.Columns.Add("Description");
                            Pay.Columns.Add("Payment");
                            Pay.Columns.Add("BankName");
                            Pay.Columns.Add("BranchName");
                            Pay.Columns.Add("AmountPaid", typeof(decimal));
                            Pay.Columns.Add("PaymentID");
                            Pay.Columns.Add("Purchase");
                            Pay.Columns.Add("NewYearNo");
                        }
                        for (int i = 0; i < dtpay.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = Pay.NewRow();
                            //drAdd["Date"] = dtpay.Rows[i]["Date"].ToString().Split(' ')[1];
                            drAdd["Date"] = Convert.ToDateTime(dtpay.Rows[i]["Date"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            drAdd["AgentID"] = dtpay.Rows[i]["AgentID"].ToString();
                            drAdd["AgentName"] = dtpay.Rows[i]["AgentName"].ToString();
                            drAdd["Description"] = dtpay.Rows[i]["Description"].ToString();
                            drAdd["Payment"] = dtpay.Rows[i]["Payment"].ToString();
                            drAdd["BankName"] = dtpay.Rows[i]["BankName"].ToString();
                            drAdd["BranchName"] = dtpay.Rows[i]["BranchName"].ToString();
                            drAdd["AmountPaid"] = Convert.ToDecimal(dtpay.Rows[i]["AmountPaid"] == DBNull.Value ? "0.000" : dtpay.Rows[i]["AmountPaid"]);
                            drAdd["PaymentID"] = dtpay.Rows[i]["PaymentID"].ToString();
                            drAdd["Purchase"] = dtpay.Rows[i]["Purchase"].ToString();
                            drAdd["NewYearNo"] = dtpay.Rows[i]["NewYearNo"].ToString();
                            Pay.Rows.Add(drAdd);
                        }
                        Get_Details = Pay;
                        Obj_viewer.HTable.Clear();
                        if (obj_report.AgentName != string.Empty && obj_report.AgentName != null)
                            Obj_viewer.HTable.Add("AgentName", obj_report.AgentName);
                        else Obj_viewer.HTable.Add("AgentName", "");
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.RptDoc = Payable;
                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }


                        break;
                    //case 
                    case "Spendings":
                        Rpt_ExpensesDetails Expenses = new Rpt_ExpensesDetails();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Spending");
                        DataTable Spending = new DataTable("Spending");
                        Spending = reportbal.Get_ExpenseDetails();
                        if (Spending == null || Spending.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        else
                        {
                            //ChangeEngtoArabicWords(ref Spending);
                        }
                        Spending.Columns.Add("ProcessDate");
                        for (int i = 0; i < Spending.Rows.Count; i++)
                        {
                            string str = Convert.ToDateTime(Spending.Rows[i]["ProcessDateTime"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            Spending.Rows[i]["ProcessDate"] = str;
                        }
                        Get_Details = Spending;
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now.Date);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        Obj_viewer.RptDoc = Expenses;
                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }

                        break;
                    case "DebtList":
                        Agent_Details frm = new Agent_Details();
                        frm.ObjHelper.ObjbalClass.ObjAgentDetailObject.Number = obj_report.Number;
                        frm.ObjHelper.DebtList();
                        isfromdebt = true;
                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }

                        break;
                    case "Drawings":
                        Rpt_Drawing Drawing = new Rpt_Drawing();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("Drawing");
                        DataTable Draw = new DataTable("Drawing");
                        Draw = reportbal.Get_Drawing();
                        if (Draw == null || Draw.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Get_Details = Draw;
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        Obj_viewer.RptDoc = Drawing;
                        if (ArabicView.Report.isAllDateSelected)
                        {
                            Obj_viewer.HTable.Add("AllDates", "no time period is set, report is for all dates");
                        }
                        else { Obj_viewer.HTable.Add("AllDates", ""); }

                        break;
                    case "SaleInvoiceList":
                        Rpt_ListOfSales ListofSales = new Rpt_ListOfSales();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoiceList");
                        DataTable LS = new DataTable("ListOfSales");
                        LS = reportbal.Get_ListOfSales();
                        if (LS == null || LS.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now.Date);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now.Date);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        LS.Columns.Add("SaleDate");
                        for (int i = 0; i < LS.Rows.Count; i++)
                        {
                            string str = Convert.ToDateTime(LS.Rows[i]["SaleDateTime"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            LS.Rows[i]["SaleDate"] = str;
                        }
                        Get_Details = LS;
                        Obj_viewer.RptDoc = ListofSales;
                        break;
                    case "TotalDiscounts":
                        Rpt_TotalDiscounts TDiscount = new Rpt_TotalDiscounts();
                        DataSet TD = new DataSet();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TotalDiscount");
                        TD = reportbal.Get_TotalDiscount();
                        novalue = 0;
                        for (int j = 0; j < TD.Tables.Count; j++)
                        {
                            for (int k = 0; k < TD.Tables[j].Columns.Count; k++)
                            {
                                if (TD.Tables[j].Rows[0][k].ToString() == string.Empty)
                                    TD.Tables[j].Rows[0][k] = 0;

                                if (Convert.ToDecimal(TD.Tables[j].Rows[0][k].ToString()) > 0)
                                {
                                    novalue = 1;
                                }
                            }

                        }
                        if (novalue == 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        if (TD != null && TD.Tables.Count >= 3)
                        {
                            Obj_viewer.HTable.Clear();
                            Obj_viewer.HTable.Add("SaleIssued", TD.Tables[0].Rows[0]["SaleIssued"]);
                            Obj_viewer.HTable.Add("PurchaseIssued", TD.Tables[1].Rows[0]["PurchaseIssued"]);
                            Obj_viewer.HTable.Add("DiscountSaleIssued", TD.Tables[0].Rows[0]["DiscountSaleIssued"]);
                            Obj_viewer.HTable.Add("DiscountPurchaseIssued", TD.Tables[1].Rows[0]["DiscountPurchaseIssued"]);
                            Obj_viewer.HTable.Add("TotalSaleDiscount", TD.Tables[0].Rows[0]["TotalSaleDiscount"]);
                            Obj_viewer.HTable.Add("TotalPurchaseDiscount", TD.Tables[1].Rows[0]["TotalPurchaseDiscount"]);
                            Obj_viewer.HTable.Add("TotalRentingDiscount", TD.Tables[2].Rows[0]["TotalRentingDiscount"]);
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }
                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            Obj_viewer.RptDoc = TDiscount;
                            Obj_viewer.IsItemNo = false;
                            Obj_viewer.IsReportFooter = false;
                            Get_Details = TD.Tables[0];
                            TD.Tables.RemoveAt(0);
                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        break;
                    case "SaleMovementAccordingTo":
                        DataTable sale = new DataTable();
                        sale = reportbal.Get_SaleMovementAccordingTo();
                        if (sale.Rows.Count > 0)
                        {
                            Rpt_SalesAccordingToCCUT SalesAccordingTo = new Rpt_SalesAccordingToCCUT();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SaleInvoiceList");
                            Obj_viewer.RptDoc = SalesAccordingTo;
                            Obj_viewer.Report_Table = sale;
                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now.Date);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now.Date);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date);
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date);
                                Obj_viewer.HTable.Add("HideDate", false);
                            }
                            sale.Columns.Add("SaleDate");
                            for (int i = 0; i < sale.Rows.Count; i++)
                            {
                                string str = Convert.ToDateTime(sale.Rows[i]["SaleDateTime"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                                sale.Rows[i]["SaleDate"] = str;
                            }

                            Obj_viewer.IsItemNo = true;

                        }
                        Get_Details = sale;//on 06-11-2014 by Ritu

                        break;
                    case "ClientPaymentList":
                        Rpt_ClientPaymentList ClientPayment = new Rpt_ClientPaymentList();
                        Get_Details = reportbal.Get_ClintPaymentList();
                        Get_Details.Columns.Add("ReceiptDate");
                        for (int index = 0; index < Get_Details.Rows.Count; index++)
                        {
                            Get_Details.Rows[index]["ReceiptDate"] = Convert.ToDateTime(Get_Details.Rows[index]["Receipt_Date"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                        }
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now.Date);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now.Date);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.IsItemNo = false;
                        Obj_viewer.RptDoc = ClientPayment;
                        ReportDocument rept = ClientPayment;
                        Tables Clienttbl = rept.Database.Tables;
                        Obj_viewer.Repnum = Clienttbl;
                        break;
                    case "ClientList":
                        Rpt_ClientList Clientlst = new Rpt_ClientList();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ClientList");
                        Get_Details = reportbal.Get_ClintList();
                        Obj_viewer.HTable.Clear();
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = Clientlst;
                        ReportDocument reptClientlst = Clientlst;
                        Tables Clientlsttbl = reptClientlst.Database.Tables;
                        Obj_viewer.Repnum = Clientlsttbl;
                        break;
                    case "TotalClientsMovement":
                        Rpt_ClientsMovement ClientMove = new Rpt_ClientsMovement();
                        //Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ClientMovement");
                        DataTable dtbl = new DataTable();
                        dtbl = reportbal.Get_ClientMovement();
                        Get_Details = new DataTable("ClientsMovement");
                        if (Get_Details.Columns.Count < 11)
                        {
                            Get_Details.Columns.Add("ClientNo");
                            Get_Details.Columns.Add("ClientName");
                            Get_Details.Columns.Add("TotalPurchase", typeof(decimal));
                            Get_Details.Columns.Add("NoofInvoices");
                            Get_Details.Columns.Add("TotalDiscount", typeof(decimal));
                            Get_Details.Columns.Add("TotalReturned", typeof(decimal));
                            Get_Details.Columns.Add("PaidAmount", typeof(decimal));
                            Get_Details.Columns.Add("ReturnedAmount", typeof(decimal));
                            Get_Details.Columns.Add("TotalCost", typeof(decimal));
                            Get_Details.Columns.Add("Type");
                            Get_Details.Columns.Add("Debt", typeof(decimal));
                            Get_Details.Columns.Add("Profit", typeof(decimal));

                        }
                        for (int i = 0; i < dtbl.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = Get_Details.NewRow();
                            drAdd["ClientNo"] = dtbl.Rows[i]["ClientNo"].ToString();
                            drAdd["ClientName"] = dtbl.Rows[i]["ClientName"].ToString();
                            drAdd["TotalPurchase"] = Convert.ToDecimal(dtbl.Rows[i]["TotalPurchase"].ToString());
                            drAdd["NoofInvoices"] = dtbl.Rows[i]["NoofInvoices"].ToString();
                            drAdd["TotalDiscount"] = Convert.ToDecimal(dtbl.Rows[i]["TotalDiscount"].ToString());
                            drAdd["TotalReturned"] = Convert.ToDecimal(dtbl.Rows[i]["TotalReturned"].ToString());
                            drAdd["PaidAmount"] = Convert.ToDecimal(dtbl.Rows[i]["PaidAmount"].ToString());
                            drAdd["ReturnedAmount"] = Convert.ToDecimal(dtbl.Rows[i]["ReturnedAmount"].ToString());
                            drAdd["TotalCost"] = Convert.ToDecimal(dtbl.Rows[i]["TotalCost"].ToString());
                            drAdd["Type"] = dtbl.Rows[i]["Type"].ToString();
                            if (dtbl.Rows.Count > 0)
                            {
                                GeneralFunction.AgentId.Clear();
                                GeneralFunction.AgentId.Add(dtbl.Rows[i]["ClientNo"].ToString());
                                GeneralFunction.AgentDept();
                            }
                            drAdd["Debt"] = GeneralFunction.ClientDebt;
                            drAdd["Profit"] = dtbl.Rows[i]["Profit"].ToString();
                            Get_Details.Rows.Add(drAdd);
                        }
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = ClientMove;
                        ReportDocument reptClientMove = ClientMove;
                        Tables ClientMovetbl = reptClientMove.Database.Tables;
                        Obj_viewer.Repnum = ClientMovetbl;
                        break;
                    case "TotalDiscountFromTheClients":
                        Rpt_DiscountforClients DiscClient = new Rpt_DiscountforClients();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TotaldiscountfromClient");
                        Get_Details = reportbal.Get_DiscountFromClient();
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = DiscClient;
                        ReportDocument reptDiscClient = DiscClient;
                        Tables tblDiscClient = reptDiscClient.Database.Tables;
                        Obj_viewer.Repnum = tblDiscClient;
                        break;
                    case "TotalDiscountFromTheSupplier":
                        Rpt_TotalDiscount_provider TotDisProvider = new Rpt_TotalDiscount_provider();
                        //Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TotalDiscountfromSupplier");
                        Get_Details = reportbal.Get_DiscountProvider();
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("Fromdate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("Fromdate", obj_report.FromDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = TotDisProvider;
                        ReportDocument reptDiscProvi = TotDisProvider;
                        Tables tblreptDiscProvi = reptDiscProvi.Database.Tables;
                        Obj_viewer.Repnum = tblreptDiscProvi;
                        break;
                    case "InventoryValue":

                        DataTable dtBalance = new DataTable();
                        //comment by thami on 29 aug 2016
                        //decAmt = 0;
                        //decRec = 0;
                        //dtBalance = reportbal.GetPayableReceivable();

                        //if (dtBalance.Rows.Count > 0)
                        //{
                        //    decAmt = Convert.ToDecimal(dtBalance.Compute("SUM(Payable)", String.Empty)) - Convert.ToDecimal(dtBalance.Compute("SUM(Paid)", String.Empty));
                        //    decRec = Convert.ToDecimal(dtBalance.Compute("SUM(Receivable)", String.Empty)) - Convert.ToDecimal(dtBalance.Compute("SUM(Received)", String.Empty));
                        //}

                        //add by thamil 
                        dtBalance = reportbal.GetPayableReceivable();
                        // comment by tanzeel on 10 Dec 2018
                        //if (dtBalance == null || dtBalance.Rows.Count <= 0)
                        //{
                        //    GeneralFunction.Information("NoRecordsFound", "Reports");
                        //    return;
                        //}
                        float _payable = 0;
                        float _receivable = 0;
                        if (dtBalance.Rows.Count > 0)
                        {                         
                            for (int i = 0; i < dtBalance.Rows.Count; i++)
                            {
                                if (float.Parse(dtBalance.Rows[i]["Payable"].ToString()) > float.Parse(dtBalance.Rows[i]["Receivable"].ToString()))
                                {
                                    _receivable += float.Parse(dtBalance.Rows[i]["Payable"].ToString()) - float.Parse(dtBalance.Rows[i]["Receivable"].ToString());
                                }
                                else
                                {
                                    _payable += float.Parse(dtBalance.Rows[i]["Receivable"].ToString()) - float.Parse(dtBalance.Rows[i]["Payable"].ToString());
                                }
                            }
                        }

                       DataSet ds1= reportbal.Get_InventoryValue_Reports();
                       Get_Details = ds1.Tables[0];
                       DataTable dt_sub =ds1.Tables.Count >1?ds1.Tables[1]:null;
                        //comment by thamil sold and purchase value miss matchig
                       // Get_Details = reportbal.Get_InventoryValue();

                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_InventoryValue inventoryvalue = new Rpt_InventoryValue();
                            Obj_viewer.RptDoc = inventoryvalue;
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("InventoryValue");

                            // ----commented on 14/03/2014 no need to check the FlagShowNonStockItem----
                            //  Get_Details.DefaultView.RowFilter = "[Stock]> 0";
                            //  Get_Details = (GeneralOptionSetting.FlagShowNonStockItem == "Y") ? Get_Details.DefaultView.ToTable() : Get_Details;

                            DataTable sumoftotal = Get_Details.Clone();
                            DataRow dr = sumoftotal.NewRow();
                            for (int i = 1; i < Get_Details.Columns.Count; i++)
                            {
                                string columnname = Get_Details.Columns[i].ColumnName;
                                dr[columnname] = Get_Details.Compute("Sum(" + columnname + ")", "").ToString();
                            }
                            //comment by thamil sold and purchase value miss matchig
                            if (dt_sub !=null && dt_sub.Rows.Count > 0)
                            {
                                dr["TotalPurchase"] = dt_sub.Rows[0]["TotalPurchased"];
                                dr["TotalSales"] = dt_sub.Rows[0]["TotalSold"];
                            }

                            sumoftotal.Rows.Add(dr);
                            Get_Details = sumoftotal;
                            Obj_viewer.Report_Table = Get_Details;
                            Obj_viewer.HTable.Clear();
                            string category = obj_report.CategoryName;
                            string company = obj_report.CompanyName;
                            Obj_viewer.HTable.Add("Category", category);
                            Obj_viewer.HTable.Add("Company", company);
                            //Obj_viewer.HTable.Add("Payable", decAmt);
                            //Obj_viewer.HTable.Add("Receivable", decRec);
                            Obj_viewer.HTable.Add("Payable", _payable);
                            Obj_viewer.HTable.Add("Receivable", _receivable);
                            Obj_viewer.IsReportFooter = false;

                        }
                        break;

                    case "SuppliersList":
                        Rpt_SupplierList Suplst = new Rpt_SupplierList();
                        //Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SuppliersList");
                        Get_Details = reportbal.Get_SuppList();
                        Obj_viewer.HTable.Clear();
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = Suplst;
                        ReportDocument reptSuplst = Suplst;
                        Tables Suplsttbl = reptSuplst.Database.Tables;
                        Obj_viewer.Repnum = Suplsttbl;
                        break;
                    case "PurchaseInvoiceList":
                        Get_Details = reportbal.GetListOfPurchase();
                        if (Get_Details.Rows.Count > 0)
                        {
                            Rpt_ListOfPurchase listofpurchase = new Rpt_ListOfPurchase();
                            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("PurchaseInvoicelist");
                            Obj_viewer.RptDoc = listofpurchase;
                            Get_Details.Columns.Add("PurchaseDate");
                            for (int i = 0; i < Get_Details.Rows.Count; i++)
                            {
                                string str = Convert.ToDateTime(Get_Details.Rows[i]["PurchaseDateTime"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                                Get_Details.Rows[i]["PurchaseDate"] = str;
                            }
                            Obj_viewer.Report_Table = Get_Details;
                            Obj_viewer.HTable.Clear();
                            if (obj_report.CheckDateField)
                            {
                                Obj_viewer.HTable.Add("FromDate", DateTime.Now.Date);
                                Obj_viewer.HTable.Add("ToDate", DateTime.Now.Date);
                                Obj_viewer.HTable.Add("HideDate", true);
                            }

                            else
                            {
                                Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                                Obj_viewer.HTable.Add("HideDate", false);
                            }


                        }

                        break;
                    case "SuppliersLatePayments":
                        Rpt_Debt_Latency_of_Client1 DebtLateOfSupplier = new Rpt_Debt_Latency_of_Client1();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("SupplierLatePayment");
                        DataTable dtSupLatepay = new DataTable();
                        dtSupLatepay = reportbal.GetDebtsLatencySuppBal();
                        DataTable dtdebtlocal = new DataTable("SupplierDebt");
                        DataView dgview = new DataView(dtSupLatepay);
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {

                            //dgview.RowFilter = "LastSaleDate<= '" + Convert.ToDateTime(obj_report.ToDate) + "'";
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        dtSupLatepay = dgview.ToTable();
                        if (dtdebtlocal.Columns.Count < 10)
                        {
                            dtdebtlocal.Columns.Add("AgentID");
                            dtdebtlocal.Columns.Add("AgentName");
                            dtdebtlocal.Columns.Add("TotalPurchase", typeof(decimal));
                            dtdebtlocal.Columns.Add("LastPurchDate");
                            dtdebtlocal.Columns.Add("Debtlimit", typeof(decimal));
                            dtdebtlocal.Columns.Add("LastValue", typeof(decimal));
                            dtdebtlocal.Columns.Add("LastPayDate");
                            dtdebtlocal.Columns.Add("LastPayment", typeof(decimal));
                            dtdebtlocal.Columns.Add("Debt", typeof(decimal));
                            dtdebtlocal.Columns.Add("Discount", typeof(decimal));

                        }
                        for (int i = 0; i < dtSupLatepay.Rows.Count; i++)
                        {
                            DataRow drAdd;
                            drAdd = dtdebtlocal.NewRow();
                            drAdd["AgentId"] = dtSupLatepay.Rows[i]["AgentID"].ToString();
                            drAdd["AgentName"] = dtSupLatepay.Rows[i]["AgentName"].ToString();
                            drAdd["TotalPurchase"] = Convert.ToDecimal(dtSupLatepay.Rows[i]["TotalSale"].ToString());
                            drAdd["LastPurchDate"] = Convert.ToDateTime(dtSupLatepay.Rows[i]["LastSaleDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                            drAdd["Debtlimit"] = Convert.ToDecimal(dtSupLatepay.Rows[i]["DebtLimit"].ToString());
                            drAdd["LastValue"] = Convert.ToDecimal(dtSupLatepay.Rows[i]["LastValue"].ToString());
                            //drAdd["LastPayDate"] = dtSupLatepay.Rows[i]["LastPayDate"].ToString();
                            drAdd["LastPayDate"] = dtSupLatepay.Rows[i]["LastPayDate"] != DBNull.Value ? Convert.ToDateTime(dtSupLatepay.Rows[i]["LastPayDate"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString())
                                : "-";
                            drAdd["Lastpayment"] = Convert.ToDecimal(dtSupLatepay.Rows[i]["Lastpayment"].ToString());
                            drAdd["Discount"] = Convert.ToDecimal(dtSupLatepay.Rows[i]["Discount"].ToString());
                            if (dtSupLatepay.Rows.Count > 0)
                            {
                                GeneralFunction.AgentId.Clear();
                                GeneralFunction.AgentId.Add(dtSupLatepay.Rows[i]["AgentID"].ToString());
                                GeneralFunction.AgentDept();
                            }
                            drAdd["Debt"] = GeneralFunction.ClientDebt;
                            dtdebtlocal.Rows.Add(drAdd);
                        }
                        Get_Details = dtdebtlocal;
                        Obj_viewer.IsReportFooter = false;
                        Obj_viewer.RptDoc = DebtLateOfSupplier;
                        ReportDocument reptdebtlateProvi = DebtLateOfSupplier;
                        Tables tblreptdebtlateProvi = reptdebtlateProvi.Database.Tables;
                        Obj_viewer.Repnum = tblreptdebtlateProvi;
                        break;
                    case "ListOfSaleAndProfitOfEachClient":
                        Rpt_List_of_purchase_and_profit_of_each_client report = new Rpt_List_of_purchase_and_profit_of_each_client();
                        //Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ListOfSaleAndProfitOfEachClient");
                        Obj_viewer.Text = Additional_Barcode.GetValueByResourceKey("ListOfSaleAndProfitOfEachClient");
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        DataTable dtProfit = new DataTable("DiscountforClient");
                        dtProfit = reportbal.GetListofProfitClient();
                        if (dtProfit == null || dtProfit.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Get_Details = dtProfit;
                        Obj_viewer.RptDoc = report;
                        break;
                    case "BranchReturningList":
                        Rpt_BranchReturnList reportBranch = new Rpt_BranchReturnList();
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }

                        DataTable dtBranch = new DataTable("BranchReturnList");
                        dtBranch = reportbal.GetBranchReturnList();
                        if (dtBranch == null || dtBranch.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Get_Details = dtBranch;
                        Obj_viewer.RptDoc = reportBranch;
                        break;
                    case "TotalPurchaseOfABranch":
                        Rpt_TotalItemsTaken_By_Branch TotalItemByBranch = new Rpt_TotalItemsTaken_By_Branch();
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }

                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate);
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date);
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("TotalPurchaseofBranch");

                        DataTable dtItemByBranch = new DataTable("ItemTakenbyBranch");
                        dtItemByBranch = reportbal.GetItemByBranch();
                        if (dtItemByBranch == null || dtItemByBranch.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Get_Details = dtItemByBranch;
                        Obj_viewer.RptDoc = TotalItemByBranch;
                        break;
                    case "BranchesList":
                        Rpt_BranchLists BranchList = new Rpt_BranchLists();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("BranchList");
                        DataTable dtBranchesList = new DataTable("AgentList");
                        dtBranchesList = reportbal.GetBranchesList();
                        if (dtBranchesList == null || dtBranchesList.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }
                        Obj_viewer.HTable.Clear();
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        Obj_viewer.IsReportFooter = false;
                        Get_Details = dtBranchesList;
                        Obj_viewer.RptDoc = BranchList;

                        break;
                    case "BranchMovement":
                        Rpt_BranchMovement BranchMovement = new Rpt_BranchMovement();
                        Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("BranchMovement");
                        Obj_viewer.HTable.Clear();
                        if (obj_report.CheckDateField)
                        {
                            Obj_viewer.HTable.Add("FromDate", DateTime.Now);
                            Obj_viewer.HTable.Add("ToDate", DateTime.Now);
                            Obj_viewer.HTable.Add("HideDate", true);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("FromDate", obj_report.FromDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("ToDate", obj_report.ToDate.Value.Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString()));
                            Obj_viewer.HTable.Add("HideDate", false);
                        }
                        if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                        {
                            Obj_viewer.HTable.Add("monthformat", 0);
                            Obj_viewer.HTable.Add("dayformat", 0);
                            Obj_viewer.HTable.Add("yearformat", 0);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 1);
                        }
                        else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "-");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        else
                        {
                            Obj_viewer.HTable.Add("monthformat", 1);
                            Obj_viewer.HTable.Add("dayformat", 1);
                            Obj_viewer.HTable.Add("yearformat", 1);
                            Obj_viewer.HTable.Add("seperatorformat", "/");
                            Obj_viewer.HTable.Add("dateformat", 0);
                        }
                        DataTable dtBranchesMovement = new DataTable("BranchMovement");
                        dtBranchesMovement = reportbal.GetBranchesMovement();
                        if (dtBranchesMovement == null || dtBranchesMovement.Rows.Count <= 0)
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                            return;
                        }

                        Obj_viewer.IsReportFooter = false;
                        Get_Details = dtBranchesMovement;
                        Obj_viewer.RptDoc = BranchMovement;

                        break;
                }

                if (!isfromdebt)
                {
                    if (Get_Details != null)
                    {
                        if (Get_Details.Rows.Count > 0)
                        {
                            //Well Moving Items should not sort the default Sort.
                            if (Get_Option != "WellMovingItems")
                            {
                                DataTable dt = SortReportListDetails(Get_Details);
                                Get_Details = dt;
                            }
                            Obj_viewer.Report_Table = Get_Details;

                            Obj_viewer.LoadEvent();
                            if (obj_report.PrintPreviewChecked)
                            {
                                Obj_viewer.ShowDialog();
                            }
                            else
                            {
                                // Printer Setup Handling Add these Lines
                                PrinterSettings printerSettings = new PrinterSettings();
                                printerSettings.PrinterName = GeneralFunction.PrinterName("Report");
                                Obj_viewer.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false);
                                // 

                            }
                        }
                        else
                        {
                            GeneralFunction.Information("NoRecordsFound", "Reports");
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("NoRecordsFound", "Reports");
                    }

                }
                else
                {
                    isfromdebt = true;
                    isfromdebt = false;//
                    return;
                }
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Update), "Report details", "", "Print " + Get_Option + " details", Convert.ToInt32(InvoiceAction.No));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Obj_viewer = null;
            }
            //-------------------
            

        }
        private DataTable SortReportListDetails(DataTable DT_ArrangeSorting)
        {


            string getVale = obj_report.SortingType;
            DataView dv = DT_ArrangeSorting.DefaultView;
            switch (getVale)
            {
                case "All":
                    return dv.ToTable();
                case "A to Z": //A to z
                    if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Z to A": //Z to A
                    if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName Desc";
                    }
                    break;
                case "Date": //date 

                    if (DT_ArrangeSorting.Columns.Contains("Expiry"))
                    {
                        dv.Sort = "Expiry";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ExpiryDate"))
                    {
                        dv.Sort = "ExpiryDate";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("InvoiceDate"))
                    {
                        dv.Sort = "InvoiceDate";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("DeliveryDate"))
                    {
                        dv.Sort = "DeliveryDate";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ReturnDate"))
                    {
                        dv.Sort = "ReturnDate";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("Date"))
                    {
                        dv.Sort = "Date";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("PurchaseDate"))
                    {
                        dv.Sort = "PurchaseDate";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("SaleDate"))
                    {
                        dv.Sort = "SaleDate";
                    }
                    break;
                case "Time": //time
                    if (DT_ArrangeSorting.Columns.Contains("Time"))
                    {
                        dv.Sort = "Time";
                    }
                    break;
                case "Supplier": //supplier
                    if (DT_ArrangeSorting.Columns.Contains("AgentName"))
                    {
                        dv.Sort = "AgentName";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("Supplier"))
                    {
                        dv.Sort = "Supplier";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("SupplierName"))
                    {
                        dv.Sort = "SupplierName";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Category": //Category
                    if (DT_ArrangeSorting.Columns.Contains("CategoryName"))
                    {
                        dv.Sort = "CategoryName";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("CategoryID"))
                    {
                        dv.Sort = "CategoryID";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Company": //Company
                    if (DT_ArrangeSorting.Columns.Contains("CompanyName"))
                    {
                        dv.Sort = "CompanyName";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("CompanyID"))
                    {
                        dv.Sort = "CompanyID";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Client": //Client
                    if (DT_ArrangeSorting.Columns.Contains("AgentName"))
                    {
                        dv.Sort = "AgentName";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("Client"))
                    {
                        dv.Sort = "Client";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ClientName"))
                    {
                        dv.Sort = "ClientName";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Package": //Package
                    if (DT_ArrangeSorting.Columns.Contains("Package"))
                    {
                        dv.Sort = "Package";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("PackageQty"))
                    {
                        dv.Sort = "PackageQty";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Item place and A to Z": //Item place and A to z

                    if (DT_ArrangeSorting.Columns.Contains("ItemPlace"))
                    {
                        dv.Sort = "ItemPlace";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Balance": //Balance

                    if (DT_ArrangeSorting.Columns.Contains("BalanceAmt"))
                    {
                        dv.Sort = "BalanceAmt";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Quantity": //Quantity
                    if (DT_ArrangeSorting.Columns.Contains("MTB_QTY"))
                    {
                        dv.Sort = "MTB_QTY";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("Qty"))
                    {
                        dv.Sort = "Qty";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ReturnQty"))
                    {
                        dv.Sort = "ReturnQty";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("SaleQty"))
                    {
                        dv.Sort = "SaleQty";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("PurchaseQty"))
                    {
                        dv.Sort = "PurchaseQty";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Cost": //Cost
                    if (DT_ArrangeSorting.Columns.Contains("Cost"))
                    {
                        dv.Sort = "Cost";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("AvgCost"))
                    {
                        dv.Sort = "AvgCost";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Price": //Price
                    if (DT_ArrangeSorting.Columns.Contains("Price"))
                    {
                        dv.Sort = "Price";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("UnitPrice"))
                    {
                        dv.Sort = "UnitPrice";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Ceaper": //Ceaper
                    if (DT_ArrangeSorting.Columns.Contains("Cost"))
                    {
                        dv.Sort = "Cost";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("AvgCost"))
                    {
                        dv.Sort = "AvgCost";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                case "Most Expensive": //most expencive
                    if (DT_ArrangeSorting.Columns.Contains("Cost"))
                    {
                        dv.Sort = "Cost" + " " + "desc";
                    }

                    else if (DT_ArrangeSorting.Columns.Contains("AvgCost"))
                    {
                        dv.Sort = "AvgCost" + " " + "desc";
                    }
                    else if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
                default:

                    if (DT_ArrangeSorting.Columns.Contains("ItemName"))
                    {
                        dv.Sort = "ItemName";
                    }
                    break;
            }
            //   DT_ArrangeSorting = DT_ArrangeSorting.DefaultView.ToTable();



            return dv.ToTable();

        }

        private string GetInvoiceName(string strKey)
        {
            try
            {

                if (strKey.Contains("PurchaseInvoice"))
                    return "فاتورة مشتريات";
                else if (strKey.Contains("SaleInvoice"))
                    return "فاتورة مبيعات";
                else if (strKey.Contains("PurchaseReturnInvoice"))
                    return "ترجيع مشتريات ";
                else if (strKey.Contains("SaleReturnInvoice"))
                    return "ترجيع مبيعات ";
                else if (strKey.Contains("RentInvoice"))
                    return "فاتورة ايجار";
                else if (strKey.Contains("PayReceipt"))
                    return "ايصال صرف";
                else if (strKey.Contains("ReceiveReceipt"))
                    return "ايصال قبض";
                else if (strKey.Contains("Receivable"))
                    return "المقبوضات";
                else if (strKey.Contains("Payable"))
                    return "المدفوعات";
                else if (strKey.Contains("Balance"))
                {
                    string[] str = strKey.Split('-');
                    return "تعديل ارصدة" + "-" + str[1];
                }
                else if (strKey.Contains("DepositPayment"))
                    return "دفعة على الحساب";
                else if (strKey.Contains("OpeningStock"))
                    return "بضاعة اول المدة";
                else
                    return strKey;
            }

            catch (Exception ex)
            {
                return strKey;
            }
        }
        //void ChangeEngtoArabicWords(ref DataTable dtSource)
        //{
        //    Dictionary<string, string> dicSpending = new Dictionary<string, string>();

        //    dicSpending.Add("1", "AdministrativeSpending");
        //    dicSpending.Add("102", "RenewingtheLicense");
        //    dicSpending.Add("103", "UnionParticipation");
        //    dicSpending.Add("104", "Tickets");
        //    dicSpending.Add("105", "Tax");
        //    dicSpending.Add("106", "Cleaning");
        //    dicSpending.Add("107", "SalariesandWages");
        //    dicSpending.Add("108", "OtherStaff");
        //    dicSpending.Add("109", "Other");
        //    dicSpending.Add("110", "Stationary");
        //    dicSpending.Add("111", "FoodandBeverages");
        //    dicSpending.Add("112", "Transportation");
        //    dicSpending.Add("113", "Shipping");
        //    dicSpending.Add("114", "Travel");
        //    dicSpending.Add("115", "TravelingTickets");
        //    dicSpending.Add("116", "Residential");
        //    dicSpending.Add("117", "Renting");
        //    dicSpending.Add("118", "Security");
        //    dicSpending.Add("119", "Customs");
        //    dicSpending.Add("120", "Electricity");
        //    dicSpending.Add("121", "SocialSecurity");
        //    dicSpending.Add("122", "HealthInsurance");
        //    dicSpending.Add("123", "PersonalSpending");
        //    dicSpending.Add("124", "MarketingandPublications");
        //    dicSpending.Add("125", "MarketingPercentage");
        //    dicSpending.Add("126", "Percent");
        //    dicSpending.Add("127", "Phone");
        //    dicSpending.Add("128", "Workers");
        //    dicSpending.Add("129", "GovernmentPaper");
        //    dicSpending.Add("130", "Maintenance");
        //    dicSpending.Add("131", "Establishment");
        //    dicSpending.Add("132", "Internet");
        //    dicSpending.Add("133", "Tools");
        //    dicSpending.Add("134", "Fuel");

        //    for (int i = 0; i < dtSource.Rows.Count; i++)
        //    {

        //        if (dicSpending.ContainsKey(dtSource.Rows[i]["DescriptionID"].ToString()))
        //        {
        //            dtSource.Rows[i]["Description"] = GeneralFunction.ChangeLanguageforCustomMsg(dicSpending[dtSource.Rows[i]["DescriptionID"].ToString()]);
        //        }
        //    }

        //}
    }
}
