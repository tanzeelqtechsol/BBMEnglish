using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using ObjectHelper;
using CommonHelper;
using BumedianBM.CrystalReports;
using CrystalDecisions.Shared;
using BumedianBM.ViewHelper;
using System.IO;
using System.Reflection;

namespace BumedianBM.ArabicView
{
    public partial class ReportsView : Form,IDisposable
    {
        #region Variables
        public System.Data.DataTable Report_Table;
        public bool CompLogo = true;
        public System.Collections.Hashtable HTable;
        public System.Data.DataSet DsCompLogo;
        public ReportDocument RptDoc;
        public bool IsReportFooter = true;
        public bool HideLogo;
        public bool HideDebt = false;
        public Tables Repnum;
        public bool IsPackage1 = false;
        public bool IsGroupHeader = false;
        public bool IsItemNo1 = false;
        public bool IsExpiry2 = false;
        public string InvoiceName = string.Empty;
        public bool isInvoice = false;
        public bool IsItemNo = false;

        public bool IsItemNo2 = false;
        public bool isPackage = false;

        public bool IsPackage2 = false;
        public bool IsExpiry = false;

        public bool IsList = false;
        public bool isChartType = false;
        public bool isSubReport = false;
        public System.Data.DataTable CompanyLogo_Table;
        public bool isReportFooter = true;


        #endregion
        public ReportsView()
        {
            InitializeComponent();
            HTable = new System.Collections.Hashtable();
            HideLogo = (GeneralOptionSetting.FlagHideLogoOnPrint == "Y") ? true : false;

            CompanyLogo_Table = new DataTable();
            CompanyLogo_Table = GeneralFunction.GetCompLogo();


        }


        public void LoadEvent()
        {
            //if (!(RptDoc is Rpt_InvTemplate1))//Added on 5-July-2014 by Seenivasan
            //{
            SetLanguageForReport();
            //  }
            LoadReport();
            //LoadStampImage();
        }
        public void SetLanguageForReport()
        {

            try
            {
                for (int i = 0; i < RptDoc.ReportDefinition.ReportObjects.Count; i++)
                {
                    if (RptDoc.ReportDefinition.ReportObjects[i].GetType().Name == "TextObject")
                    {
                        
                        TextObject EmployeeName = (TextObject)RptDoc.ReportDefinition.ReportObjects[i];
                        if (!EmployeeName.Name.StartsWith("Text"))
                        {
                            if ((!Report.isAllDateSelected) && EmployeeName.Name == "AllDatesMessage")
                            {
                                EmployeeName.Text = "";
                            }else
                            {
                                EmployeeName.Text = Additional_Barcode.GetValueByResourceKey(RptDoc.ReportDefinition.ReportObjects[i].Name.Replace("Obj_HL_", "").Replace("Obj_GH_", "").Replace("Obj_PH_", "").Replace("Obj_CL_", "").Replace("Obj_", "").Replace("Obj", "").ToString());//GeneralFunction.ChangeLanguageforCustomMsg(report_doc.ReportDefinition.ReportObjects[i].Name);
                            }
                            

                        }
                    }
                }

            }

            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, "Reports View", "SetLanguageForReport");
            }


        }



        public void LoadReport()
        {
            DsCompLogo = new System.Data.DataSet();
            DsCompLogo.Tables.Clear();
            if (Report_Table != null & CompanyLogo_Table != null)
            {
                // if (DsCompLogo.Tables.Contains("CompanyInfo") == false) { DsCompLogo.Tables.Add(CompanyLogo_Table); }
                // //DsCompLogo.Tables.Add(CompanyLogo_Table.Copy());
                //if( DsCompLogo.Tables.Contains(Report_Table.TableName )){ DsCompLogo.Tables.Remove(Report_Table.TableName );}
                //else{DsCompLogo.Tables.Add (Report_Table );}
                DsCompLogo.Tables.Add(CompanyLogo_Table);
                DsCompLogo.Tables.Add(Report_Table);

            }
            else if (Report_Table == null & CompanyLogo_Table != null)
            {
                DsCompLogo.Tables.Add(CompanyLogo_Table);
            }
            crystalReportViewer1.ToolPanelWidth = 100;//added on 28jan2015 to reduce toggle space
          
            if (isInvoice)
            {
                if (GeneralOptionSetting.FlagInvoiceTemplate == "12" || GeneralOptionSetting.FlagInvoiceTemplate == "13")
                {
                    CompLogo = IsReportFooter = false;
                    HTable.Add("CashierNo", GeneralFunction.UserId);
                    HTable.Add("CashierName", GeneralFunction.UserName);
                    LogoOptionfor80mm(RptDoc);

                }
                else
                {
                    //if (!(RptDoc is Rpt_InvTemplate1)) //Added on 5-July-2014 by Seenivasan
                    //{
                    InvoiceOption(RptDoc);
                    // }
                }
            }
            else
            {
                HideSomeData(RptDoc);

            }
            

            if (RptDoc is Rpt_TermsandConditions || RptDoc is Rpt_TermsandCondition) { }
          
            else
            {

                RptDoc.SetDataSource(DsCompLogo);

                foreach (string strparam in HTable.Keys)
                {
                    try
                    {
                        if (RptDoc is Rpt_InvTemplate7 && (strparam == "TotalLetters" || strparam == "Paid" || strparam == "Remaining" || strparam == "Tax1" || strparam == "Tax2" || strparam == "note" || strparam == "InvoiceName"))
                        {
                            RptDoc.SetParameterValue(strparam, HTable[strparam]);
                        }
                        else if (RptDoc is Rpt_InvTemplate7 )
                        {
                            
                        }
                        else
                        {
                            RptDoc.SetParameterValue(strparam, HTable[strparam]);
                        }
                        
                    }
                    catch (Exception ex)
                    { }
                }

            }

            if (CompLogo)
            {
                if (!((RptDoc is Rpt_InvTemplate1) || (RptDoc is Rpt_InvTemplate2) || (RptDoc is Rpt_InvTemplate3) || (RptDoc is Rpt_InvTemplate4) || (RptDoc is Rpt_InvTemplate5) || (RptDoc is Rpt_InvTemplate6 || (RptDoc is Rpt_InvTemplate7)))) //Added on 5-July-2014 by Seenivasan //this line Modified by Meena.R on30/07/2014 to added Invoice template
                {
                    LogoOption();
                }
            }
            if (RptDoc.Database.Tables != null)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table TblCurrent in RptDoc.Database.Tables)
                {

                    TableLogOnInfo TbllogonCurrent = TblCurrent.LogOnInfo;
                    TbllogonCurrent.ConnectionInfo.ServerName = GeneralFunction._server;
                    TbllogonCurrent.ConnectionInfo.DatabaseName = GeneralFunction._database;
                    TbllogonCurrent.ConnectionInfo.UserID = GeneralFunction._UserId;
                    TbllogonCurrent.ConnectionInfo.Password = GeneralFunction._password;
                    TblCurrent.ApplyLogOnInfo(TbllogonCurrent);
                }
            }
           /// RptDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            //RptDoc.PrintOptions.PageContentWidth = PaperSize.DefaultPaperSize; 
            crystalReportViewer1.ReportSource = RptDoc;
             
        }

        private void LogoOptionfor80mm(ReportDocument RptDoc)
        {
            #region "Logo Options"

            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderLogo = RptDoc.ReportDefinition.Sections["ReportHeader"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterLogo = RptDoc.ReportDefinition.Sections["FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterText = RptDoc.ReportDefinition.Sections["FooterText"];
            CrystalDecisions.CrystalReports.Engine.Section sectionCompLogo = RptDoc.ReportDefinition.Sections["CompLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject headerLogo = RptDoc.ReportDefinition.Sections["ReportHeader"].ReportObjects["Obj_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject compName = RptDoc.ReportDefinition.Sections["ReportHeader"].ReportObjects["CompName"];
            CrystalDecisions.CrystalReports.Engine.ReportObject footerLogo = RptDoc.ReportDefinition.Sections["FooterLogo"].ReportObjects["Obj_FooterLogo"];
            //CrystalDecisions.CrystalReports.Engine.ReportObject compLogo = RptDoc.ReportDefinition.Sections["CompLogo"].ReportObjects["ObjCompLogo"];
            FieldObject field;
            field = RptDoc.ReportDefinition.Sections["ReportHeader"].ReportObjects["CompName"] as FieldObject;
            Font = new System.Drawing.Font("Al-Kharashi 3", field.Font.Size, FontStyle.Bold);
            field.ApplyFont(Font);

            if (HideLogo)
            {

                if (headerLogo != null) headerLogo.Height = 0;
                if (compName != null) compName.Left = 0;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "0")
            {

                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "1")
            {
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "2")
            {
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (footerLogo != null) footerLogo.Height = 0;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "3")
            {
                if (headerLogo != null) headerLogo.Height = 0;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "4" &&(!(RptDoc is Rpt_Invoice_63mm || RptDoc is Rpt_Invoice_80mm)))
            {
                if (headerLogo != null) headerLogo.Height = 0;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;

            }
            else
            {
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                //if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;Commended By Meena.R on 15/12/2014
                if (footerLogo != null) footerLogo.Height = 0;

            }


            #endregion
        }

        private void InvoiceOption(ReportDocument RptDoc)
        {
            if (RptDoc is Rpt_InvTemplate1 || RptDoc is Rpt_InvTemplate2 || RptDoc is Rpt_InvTemplate3 || RptDoc is Rpt_InvTemplate4 || RptDoc is Rpt_InvTemplate5 || RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7)
            {
                goto PaidStamp;
            }
            int Exp; // itemno;
            CrystalDecisions.CrystalReports.Engine.Section sectionOptionNoteFooter = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject OptionNote = null;
            if ((GeneralOptionSetting.FlagInvoiceTemplate != "2") & (GeneralOptionSetting.FlagInvoiceTemplate != "3") & (GeneralOptionSetting.FlagInvoiceTemplate != "5") &
                (GeneralOptionSetting.FlagInvoiceTemplate != "7") & (GeneralOptionSetting.FlagInvoiceTemplate != "9") & (GeneralOptionSetting.FlagInvoiceTemplate != "10")
                & (GeneralOptionSetting.FlagInvoiceTemplate != "11") & (GeneralOptionSetting.FlagInvoiceTemplate != "1") & (GeneralOptionSetting.FlagInvoiceTemplate != "6"))
            {
                sectionOptionNoteFooter = RptDoc.ReportDefinition.Sections["OptionNoteFooter"];
            }
            else
            {
                OptionNote = RptDoc.ReportDefinition.Sections["SignFooter"].ReportObjects["OptionNote1"];
            }
            // CrystalDecisions.CrystalReports.Engine.Section sectionRentingFooter = RptDoc.ReportDefinition.Sections["RentingFooter"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineItemNo = RptDoc is Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount || RptDoc is Rpt_SimpleInvoiceWithoutDiscount_A4Landscape ? null : RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineItemNo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineExpiry = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineExpiry"];
            //new code for seperate line in details part
            CrystalDecisions.CrystalReports.Engine.ReportObject LineItemNo1 = RptDoc is Rpt_Purchase_Invoice_No_WithoutTax || RptDoc is Rpt_Purchase_Invoice_No_A4Landscape_WithoutDiscount ? null : RptDoc.ReportDefinition.Sections["Details"].ReportObjects["LineItemNo1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineExpiry1 = RptDoc is Rpt_Purchase_Invoice_No_WithoutTax ? null : RptDoc.ReportDefinition.Sections["Details"].ReportObjects["LineExpiry1"];
            //upto here
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjDescription = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Description"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjItemNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemNo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ItemNo = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemNo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjExpiry = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Expiry"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Expiry = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Expiry"];
            CrystalDecisions.CrystalReports.Engine.ReportObject BoxDetails = null, Linevertical1 = null, LineHorizondal1 = null, LineHorizondal2 = null, LineHorizondal3 = null, LineHorizondal4 = null, ObjTotalPeaces = null, ObjCustomerId = null, CustomerId = null, ObjLastInvDate = null, ObjDate = null, ObjAmtDue = null, ObjTotal = null, Qty = null, LastInvoiceDate = null, DataDate = null, AmountDue = null, ObjStreetAddress = null, StreetAddress = null, ObjPhoneNo = null, PhoneNo2 = null, ObjAddress2 = null, Address2 = null, TotalDebt1, LblDebt, InvoiceDate1, LblDate; //LineHorizondal5 = null,  TotalLetters = null,
            if (GeneralOptionSetting.FlagInvoiceTemplate != "0" && GeneralOptionSetting.FlagInvoiceTemplate != "4" && GeneralOptionSetting.FlagInvoiceTemplate != "8")
            {


                // ObjStreetAddress = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjStreetAddress"]; ;
                //StreetAddress = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["StreetAddress"]; ;
                ObjPhoneNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_PhNo"]; ;
                PhoneNo2 = RptDoc is Rpt_CompleteInvoice_A5_WithoutTaxDiscount ? null : RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["PhoneNo2"]; ;
                ObjAddress2 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Address"]; ;
                Address2 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Address2"]; ;

                BoxDetails = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["BoxDetails"];
                Linevertical1 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Linevertical1"];
                LineHorizondal1 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LineHorizondal1"];
                LineHorizondal2 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LineHorizondal2"];
                LineHorizondal3 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LineHorizondal3"];
                LineHorizondal4 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LineHorizondal4"];
                //LineHorizondal5 = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LineHorizondal5"];

                ObjTotalPeaces = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["TNP"];
                ObjCustomerId = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Obj_CusID"];
                ObjLastInvDate = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Obj_LastInv"];
                ObjDate = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Obj_Date"];
                ObjAmtDue = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Obj_Net"];
                ObjTotal = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["TinLetter"];
                //TotalLetters = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["TotalLetters"];

                Qty = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["Qty"];
                LastInvoiceDate = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["LastInvoiceDate"];
                DataDate = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["DataDate"];
                AmountDue = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["AmountDue"];
                CustomerId = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["CustomerId2"];
            }
            if ((InvoiceName == "RentingInvoice"))
            {
                Exp = Expiry.Width;
                ItemName.Width += Exp;
                if (Expiry != null) Expiry.ObjectFormat.EnableSuppress = true;
                if (ObjExpiry != null) ObjExpiry.ObjectFormat.EnableSuppress = true;
                if (LineExpiry != null) LineExpiry.ObjectFormat.EnableSuppress = true;
                if (LineExpiry1 != null) LineExpiry1.ObjectFormat.EnableSuppress = true;
            }
            else
            {
                // if (sectionRentingFooter != null) sectionRentingFooter.SectionFormat.EnableSuppress = true;
            }

            if ((InvoiceName != "SaleInvoice") & (InvoiceName != "PerformaInvoice") & (InvoiceName != "RentingInvoice"))
            {
                if (sectionOptionNoteFooter != null) sectionOptionNoteFooter.SectionFormat.EnableSuppress = true;

                if (OptionNote != null) OptionNote.ObjectFormat.EnableSuppress = true;
            }
            if (GeneralOptionSetting.FlagPrintTotalQuantity != "Y")
            {
                if (ObjTotalPeaces != null) ObjTotalPeaces.ObjectFormat.EnableSuppress = true;
                if (Qty != null) Qty.ObjectFormat.EnableSuppress = true;
            }
            if (GeneralOptionSetting.FlagHideItemNumber.Trim() == "Y")
            {
                if (LineItemNo != null) LineItemNo.ObjectFormat.EnableSuppress = true;
                if (LineItemNo1 != null) LineItemNo1.ObjectFormat.EnableSuppress = true;
                if (ItemNo != null) ItemNo.ObjectFormat.EnableSuppress = true;
                if (ObjItemNo != null) ObjItemNo.ObjectFormat.EnableSuppress = true;
                //ItemName.Left = ItemNo.Left;
                ItemName.Width += ItemNo.Width;
                //ItemNo.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
            }
            if ((InvoiceName == "PurchaseInvoice" && GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "Y") | (InvoiceName == "PurchaseReturnInvoice" && GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "Y") | (InvoiceName == "OrderInvoice" && GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "Y"))
            {
                if (LineExpiry != null) LineExpiry.ObjectFormat.EnableSuppress = true;
                if (LineExpiry1 != null) LineExpiry1.ObjectFormat.EnableSuppress = true;
                if (Expiry != null) Expiry.ObjectFormat.EnableSuppress = true;
                if (ObjExpiry != null) ObjExpiry.ObjectFormat.EnableSuppress = true;
                ItemName.Width += Expiry.Width;
                ItemName.Left = Expiry.Left;
            }
            if (((InvoiceName == "SaleInvoice") | (InvoiceName == "PerformaInvoice") | (InvoiceName == "SaleReturnInvoice")) && (GeneralOptionSetting.FlagSale_HideExpiryFiled.Trim() == "Y"))
            {
                if (LineExpiry != null) LineExpiry.ObjectFormat.EnableSuppress = true;
                if (LineExpiry1 != null) LineExpiry1.ObjectFormat.EnableSuppress = true;
                if (Expiry != null) Expiry.ObjectFormat.EnableSuppress = true;
                if (ObjExpiry != null) ObjExpiry.ObjectFormat.EnableSuppress = true;
                ItemName.Width += Expiry.Width;
                ItemName.Left = Expiry.Left;
            }
            if (GeneralOptionSetting.FlagInvoiceTemplate.Trim() == "2" || GeneralOptionSetting.FlagInvoiceTemplate.Trim() == "6" || GeneralOptionSetting.FlagInvoiceTemplate.Trim() == "10")
            {
                if (BoxDetails != null) BoxDetails.ObjectFormat.EnableSuppress = true;
                if (Linevertical1 != null) Linevertical1.ObjectFormat.EnableSuppress = true;
                if (LineHorizondal1 != null) LineHorizondal1.ObjectFormat.EnableSuppress = true;
                if (LineHorizondal2 != null) LineHorizondal2.ObjectFormat.EnableSuppress = true;
                if (LineHorizondal3 != null) LineHorizondal3.ObjectFormat.EnableSuppress = true;
                if (LineHorizondal4 != null) LineHorizondal4.ObjectFormat.EnableSuppress = true;
                //if (LineHorizondal5 != null) LineHorizondal5.ObjectFormat.EnableSuppress = true;

                if (ObjStreetAddress != null) ObjStreetAddress.ObjectFormat.EnableSuppress = true;
                if (StreetAddress != null) StreetAddress.ObjectFormat.EnableSuppress = true;
                if (ObjPhoneNo != null) ObjPhoneNo.ObjectFormat.EnableSuppress = true;
                if (PhoneNo2 != null) PhoneNo2.ObjectFormat.EnableSuppress = true;
                if (ObjAddress2 != null) ObjAddress2.ObjectFormat.EnableSuppress = true;
                if (Address2 != null) Address2.ObjectFormat.EnableSuppress = true;

                if (ObjCustomerId != null) ObjCustomerId.ObjectFormat.EnableSuppress = true;
                if (ObjLastInvDate != null) ObjLastInvDate.ObjectFormat.EnableSuppress = true;
                if (ObjDate != null) ObjDate.ObjectFormat.EnableSuppress = true;
                if (ObjAmtDue != null) ObjAmtDue.ObjectFormat.EnableSuppress = true;

                if (LastInvoiceDate != null) LastInvoiceDate.ObjectFormat.EnableSuppress = true;
                if (DataDate != null) DataDate.ObjectFormat.EnableSuppress = true;
                if (AmountDue != null) AmountDue.ObjectFormat.EnableSuppress = true;
                if (CustomerId != null) CustomerId.ObjectFormat.EnableSuppress = true;
            }
            if (GeneralOptionSetting.FlagShowDeptOnPrint != "Y" || HideDebt || InvoiceName == "SpoiledInvoice")
            {
                TotalDebt1 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["TotalDept1"]; //RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["TotalDebt1"];
                LblDebt = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["TotalDebt"];
                if (TotalDebt1 != null) TotalDebt1.ObjectFormat.EnableSuppress = true;
                if (LblDebt != null) LblDebt.ObjectFormat.EnableSuppress = true;
            }
            if (GeneralOptionSetting.FlagShowTime != "Y")
            {
                InvoiceDate1 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["InvoiceDate1"]; //RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["TotalDebt1"];
                LblDate = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Date"];
                if (InvoiceDate1 != null) InvoiceDate1.ObjectFormat.EnableSuppress = true;
                if (LblDate != null) LblDate.ObjectFormat.EnableSuppress = true;
            }
        //if (RptDoc is Rpt_InvTemplate1 || RptDoc is Rpt_InvTemplate2 || RptDoc is Rpt_InvTemplate3 || RptDoc is Rpt_InvTemplate4 || RptDoc is Rpt_InvTemplate5)
        //{
        //    goto PaidStamp;
        //}

        

            //if (RptDoc is Rpt_CompleteInvoice_A4Landscape || RptDoc is Rpt_InvTemplate1)
            //{
            if (!GeneralFunction.IsPaidStamp)
            {
                CrystalDecisions.CrystalReports.Engine.ReportObject PaidStampSubReport = RptDoc.ReportDefinition.Sections["DetailsFooter"].ReportObjects["PaidStampSubReport"];
                PaidStampSubReport.ObjectFormat.EnableSuppress = true;
            }
        PaidStamp:
        if (RptDoc is Rpt_InvTemplate1 || RptDoc is Rpt_InvTemplate2 || RptDoc is Rpt_InvTemplate3 || RptDoc is Rpt_InvTemplate4 || RptDoc is Rpt_InvTemplate5 || RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7)
        {
            InvTemplateOptions(RptDoc);
        }
         
            //}
        }

        private void InvTemplateOptions(ReportDocument rptDoc)
        {

            CrystalDecisions.CrystalReports.Engine.ReportObject LineExpiry = RptDoc is Rpt_InvTemplate6  ? null: rptDoc.ReportDefinition.Sections["InvoiceHeaderDetails"].ReportObjects["LineExpiry"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineExpiry1 = RptDoc is Rpt_InvTemplate6  ? null : rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["LineExpiry1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjExpiry = RptDoc is Rpt_InvTemplate6 ? null : rptDoc.ReportDefinition.Sections["InvoiceHeaderDetails"].ReportObjects["Obj_Expiry"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Expiry = RptDoc is Rpt_InvTemplate6  ? null : rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Expiry1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Obj_Description = RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7 ? null : rptDoc.ReportDefinition.Sections["InvoiceHeaderDetails"].ReportObjects["Obj_Description"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ItemName1 = RptDoc is Rpt_InvTemplate7 || RptDoc is Rpt_InvTemplate6 ? rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Unit1"] : rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["ItemName1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Discount =  rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Discount"];
            CrystalDecisions.CrystalReports.Engine.ReportObject DiscountPercentage1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["DiscountPercentage1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Tax = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Tax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Tax1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Tax1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineTax = RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7 ? null : rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["LineTax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineDiscount = RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7 ? null : rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["LineDiscount"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Net = RptDoc is Rpt_InvTemplate6 ? rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["rpt6GTotal"] : rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Net"];

            //
            CrystalDecisions.CrystalReports.Engine.ReportObject LinePaymentCharges = RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7  ? null : rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["LinePaymentCharges"];
            CrystalDecisions.CrystalReports.Engine.ReportObject LineNet = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject LinePaid = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Paid = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Paid1 = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Remaining = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Remaining1 = null;
            if (rptDoc is Rpt_InvTemplate1 || rptDoc is Rpt_InvTemplate2 || rptDoc is Rpt_InvTemplate3 || rptDoc is Rpt_InvTemplate4 || rptDoc is Rpt_InvTemplate5 || rptDoc is Rpt_InvTemplate6 || rptDoc is Rpt_InvTemplate7)
            {
                 LineNet   = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["LineNet"];
                 LinePaid  =rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["LinePaid"];
                 Paid      = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["rpt7Paid"];
                 Paid1     = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Paid1"];
                 Remaining = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["rpt7Remaining"];
                 Remaining1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Remaining1"];
            }
            

            CrystalDecisions.CrystalReports.Engine.ReportObject PaymentCharges =  rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["PaymentCharges"];
            CrystalDecisions.CrystalReports.Engine.ReportObject PaymentCharges1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["PaymentCharges1"];
            //
            CrystalDecisions.CrystalReports.Engine.ReportObject Balance1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Balance1"];
            //CrystalDecisions.CrystalReports.Engine.ReportObject Box = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Box7"];
            
            CrystalDecisions.CrystalReports.Engine.ReportObject Obj_TotalDebt;
            if (RptDoc is Rpt_InvTemplate6 || RptDoc is Rpt_InvTemplate7)
            {
                if (RptDoc is Rpt_InvTemplate6)
                {
                    Obj_TotalDebt  = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["rpt6TotalDebt"];
                }else
                {
                    Obj_TotalDebt = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["rpt7TotalDebts"];
                }
            }
            else 
            {
                Obj_TotalDebt = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["Obj_TotalDebt"];
            }
            CrystalDecisions.CrystalReports.Engine.ReportObject TotalDept1 = rptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["TotalDept1"];
            //CrystalDecisions.CrystalReports.Engine.ReportObject Obj_HeaderLogo = rptDoc.ReportDefinition.Sections["HeaderLogo"].ReportObjects["Obj_HeaderLogo"];
            //CrystalDecisions.CrystalReports.Engine.ReportObject Obj_FooterLogo = rptDoc.ReportDefinition.Sections["FooterLogo"].ReportObjects["Obj_FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderLogo =  rptDoc.ReportDefinition.Sections["HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterLogo = rptDoc.ReportDefinition.Sections["FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionCompanyInfo =  rptDoc.ReportDefinition.Sections["CompanyInfo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterCompanyInfo = rptDoc.ReportDefinition.Sections["FooterCompanyInfo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Obj_PH_HeaderLogo =rptDoc.ReportDefinition.Sections["CompanyInfo"].ReportObjects["Obj_PH_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Obj_FooterLogo = rptDoc.ReportDefinition.Sections["FooterLogo"].ReportObjects["Obj_FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Obj_HeaderLogo = rptDoc.ReportDefinition.Sections["HeaderLogo"].ReportObjects["Obj_HeaderLogo"];
            if (!GeneralFunction.IsPaidStamp)
            {
                CrystalDecisions.CrystalReports.Engine.ReportObject PaidStampSubReport = RptDoc.ReportDefinition.Sections["InvoiceFooterDetails"].ReportObjects["PaidStampSubReport"];
                PaidStampSubReport.ObjectFormat.EnableSuppress = true;
            }
            if (GeneralOptionSetting.FlagPurchase_HideExpiryFiled.Trim() == "Y")
            {
                if (LineExpiry != null)
                {
                    LineExpiry.ObjectFormat.EnableSuppress = true;
                    
                }
                if (LineExpiry1 != null)
                {
                    LineExpiry1.ObjectFormat.EnableSuppress = true;
                }
                if (ObjExpiry != null)
                {
                    ObjExpiry.ObjectFormat.EnableSuppress = true;
                }
                if (Expiry != null)
                {
                    Expiry.ObjectFormat.EnableSuppress = true;
                }
                if (Obj_Description != null && Expiry != null)
                {
                    // comented on 26 august for bbm english
                    //Obj_Description.Width = Obj_Description.Width + ObjExpiry.Width;
                    //Obj_Description.Left = ObjExpiry.Left;
                    //ObjExpiry.Width = 1;
                }
                if (ItemName1 != null && Expiry != null)
                {
                    // comented on 26 august for bbm english
                    //ItemName1.Width = ItemName1.Width + Expiry.Width;
                    //ItemName1.Left = Expiry.Left;
                }
            }
            if (GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y")
            {
                int tempTop = 0;
                if (Discount != null)
                {
                    Discount.ObjectFormat.EnableSuppress = true;
                }
                if (DiscountPercentage1 != null)
                {
                    DiscountPercentage1.ObjectFormat.EnableSuppress = true;
                }
                if (LineTax != null)
                {
                    LineTax.ObjectFormat.EnableSuppress = true;
                }
                if (Tax != null)
                {
                    tempTop = Tax.Top;
                    Tax.Top = Discount.Top;
                }
                if (Net != null)
                {
                    Net.Top = tempTop;
                }
                if (Tax1 != null)
                {
                    tempTop = Tax1.Top;
                    Tax1.Top = DiscountPercentage1.Top;
                }
                if (Balance1 != null)
                {
                    Balance1.Top = tempTop;
                }

              
            }
            if (GeneralOptionSetting.FlagHideTaxFiled == "Y")
            {
                if (Tax != null)
                {
                    Tax.ObjectFormat.EnableSuppress = true;
                }
                if (Tax1 != null)
                {
                    Tax1.ObjectFormat.EnableSuppress = true;
                }
                //if (LineTax != null)
                //{
                //    LineTax.ObjectFormat.EnableSuppress = true;
                //}
                //if (LineDiscount != null)
                //{
                //    LineDiscount.ObjectFormat.EnableSuppress = true;
                //}
                if (Remaining != null)
                {
                    Remaining.Top = Paid.Top;
                }
                if (Remaining1 != null)
                {
                    Remaining1.Top = Paid1.Top;
                }
                if (Paid != null)
                {
                    Paid.Top = Net.Top;
                }
                if (Paid1 != null)
                {
                    Paid1.Top = Balance1.Top;
                }
                if (Net != null)
                {
                    Net.Top = PaymentCharges == null ? Net.Top : PaymentCharges.Top;
                }
                if (Balance1 != null)
                {
                    Balance1.Top = PaymentCharges1.Top;
                }
                if (LinePaymentCharges != null)
                {
                    //LinePaymentCharges.ObjectFormat.EnableSuppress = true;
                }
                if (PaymentCharges != null)
                {
                    PaymentCharges.Top = Tax.Top;
                }
                if (PaymentCharges1 != null)
                {
                    PaymentCharges1.Top = Tax1.Top;
                }
                if (LinePaid != null)
                {
                    LinePaid.ObjectFormat.EnableSuppress = true;
                }
                
                
               
            }
            if (GeneralOptionSetting.FlagShowDeptOnPrint == "N"|| HideDebt )
            {
                if (Obj_TotalDebt != null)
                {
                    Obj_TotalDebt.ObjectFormat.EnableSuppress = true;
                }
                if (TotalDept1 != null)
                {
                    TotalDept1.ObjectFormat.EnableSuppress = true;
                }
            }
            Obj_PH_HeaderLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
            Obj_HeaderLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
            Obj_FooterLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.FooterLogo == null || GeneralOptionSetting.FooterLogo.Length <= 1;
            if (HideLogo || GeneralOptionSetting.FlagHideLogoOnPrint=="Y")
            {

                if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                if (Obj_HeaderLogo != null) Obj_HeaderLogo.Height = 0;
                if (Obj_FooterLogo != null) Obj_FooterLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "0")//N in Other Reports
            {
                if (sectionHeaderLogo != null)
                {
                    sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                }
                if (sectionFooterLogo != null)
                {
                    sectionFooterLogo.SectionFormat.EnableSuppress = true;
                }
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "1")//N In Other reports
            {
                if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "2")//N in Other Report
            {
                if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (Obj_FooterLogo != null) Obj_FooterLogo.Height = 0;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "3")//N in Other Report
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (Obj_PH_HeaderLogo != null) Obj_PH_HeaderLogo.Height = 0;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "4")//Y IN Other Reports
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (Obj_PH_HeaderLogo != null) Obj_PH_HeaderLogo.Height = 0;
            }
            else
            {
                if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                if (Obj_HeaderLogo != null) Obj_HeaderLogo.Height = 0;
                if (Obj_FooterLogo != null) Obj_FooterLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }
            if (GeneralOptionSetting.FlagShowCompanyNameOnly == "Y" )//Y IN Other Reports
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                //companyName.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                if (Obj_PH_HeaderLogo != null) Obj_PH_HeaderLogo.Height = 0;
            }

            #region ---- Old Code  Which Hide the Logo on reports --
            if (GeneralOptionSetting.FlagShowCompanyOnInvoice != "Y")//y in Other Report
            {
                if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                if (Obj_HeaderLogo != null) Obj_HeaderLogo.Height = 0;
                if (Obj_FooterLogo != null) Obj_FooterLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }
            #endregion

            #region Hide Peace and Box in Report Template 6 and 7
            if (GeneralOptionSetting.FlagHidePeaceBoxOnPrint == "Y")
            {
                if(RptDoc is Rpt_InvTemplate7 || RptDoc is Rpt_InvTemplate6)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportObject Line = rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Line5"];
                    CrystalDecisions.CrystalReports.Engine.ReportObject BoxLabel = rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["rpt7box"];
                    CrystalDecisions.CrystalReports.Engine.ReportObject PeaceLabel = rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["rpt7Peace"];
                    CrystalDecisions.CrystalReports.Engine.ReportObject BoxText = RptDoc is Rpt_InvTemplate7 ? rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Box2"] : rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Box3"];
                    CrystalDecisions.CrystalReports.Engine.ReportObject Quantity =rptDoc.ReportDefinition.Sections["Section3"].ReportObjects["Quantity1"];
                    

                    Line.ObjectFormat.EnableSuppress = true;
                    BoxLabel.ObjectFormat.EnableSuppress = true;
                    PeaceLabel.ObjectFormat.EnableSuppress = true;
                    BoxText.ObjectFormat.EnableSuppress = true;
                    Quantity.Left = RptDoc is Rpt_InvTemplate7 ? 8500 : 3600;
                }
            }
                #endregion

                //if (GeneralOptionSetting.FlagShowCompanyOnInvoice == "Y")//y in Other Report
                //{
                //    if (sectionCompanyInfo != null) sectionCompanyInfo.SectionFormat.EnableSuppress = true;
                //    if (sectionFooterCompanyInfo != null) sectionFooterCompanyInfo.SectionFormat.EnableSuppress = true;
                //    if (Obj_HeaderLogo != null) Obj_HeaderLogo.Height = 0;
                //    if (Obj_FooterLogo != null) Obj_FooterLogo.Height = 0;
                //    if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                //    if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
                //}

            }


        //string a = GeneralOptionSetting.FlagHideTaxFiled;


        private void HideSomeData(ReportDocument RptDoc)
        {
            CrystalDecisions.CrystalReports.Engine.ReportObject PackageTotal = null, ObjRemains = null, Remains = null,
                   ForRemains = null, LineExpiry3 = null, LineExpiry1 = null, LineExpiry2 = null,
                   LineItemNo = null, ObjItemNo = null, ItemNo = null, ObjItemName = null, ItemName = null, LineItemNo1 = null, LinePackage = null,
                   LinePackage2 = null, ObjPackage = null, Package = null, LinePackage1 = null, Supplier = null, ObjSupplier = null, ObjItemNo2 = null, ItemNo2 = null, LineItemNo3 = null, ObjItemNo3 = null, ItemNo3 = null, Expiry = null, Expiry2 = null, ObjExpiry = null, ObjExpiry2 = null, LineExpir = null, ReportBackgroundImageForPayReceiptHeader = null, ReportBackgroundImageForReceiveReceiptHeader = null, ReportBackgroundImageForPayReceiptFooter = null, ReportBackgroundImageForReceiveReceiptFooter = null
                   , OBJ_PayHeader = null, OBJ_ReceiveHeader = null, txtReceiveFromHeader = null, txtPayToHeader = null, OBJ_PayFooter = null, OBJ_ReceiveFooter = null, txtReceiveFromFooter = null, txtPayToFooter = null;
                   
            CrystalDecisions.CrystalReports.Engine.Section ReportFooter = null, ReportFooterSubreport = null;
            CrystalDecisions.CrystalReports.Engine.Section ReportHeadercharttype1 = null;
            CrystalDecisions.CrystalReports.Engine.Section ReportHeadercharttype2 = null;
            if (IsReportFooter)
            { 
                ReportFooter = RptDoc.ReportDefinition.Sections["ReportFooter"]; 
            }
            if (isSubReport)
            {
                ReportFooterSubreport = RptDoc.ReportDefinition.Sections["ReportFooterSubreport"];
            }
            if (IsItemNo)
            {
                LineItemNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineItemNo"];
                ObjItemNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemNo"];
                ItemNo = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemNo"];
                ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];
                ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemName"];
                ////should includeif (RptDoc is Rpt_ReorderItems || RptDoc is Rpt_OrderNotPurchased) LineItemNo1 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineItemNo1"];
            }
            else if (IsItemNo1)
            {
                if (IsGroupHeader)
                {
                    ObjItemNo = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_ItemNumber"];
                    ItemNo = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["ItemNo"];
                }
                else
                {
                    LineItemNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineItemNo1"];
                    LineItemNo1 = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["LineItemNo2"];
                    ObjItemNo = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjItemNo"];
                    ItemNo = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemNo"];
                    ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];
                    ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjItemName"];
                }
            }
            if (IsItemNo2)
            {
                if (IsGroupHeader)
                {
                    ObjItemNo2 = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_ItemNumber"];
                    ItemNo2 = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["ItemNumber"];

                }
                else
                {
                    ObjItemNo2 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemNumber"];
                    ItemNo2 = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ItemNumber"];
                }
            }
            if (isPackage)
            {
                LinePackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LinePackage"];
                ObjPackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Package"];
                Package = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Package"];
                ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];
                ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemName"];

            }
            else if (IsPackage1)
            {
                if (IsGroupHeader)
                {
                    LinePackage = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["LinePackage"];
                    ObjPackage = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_Package"];
                    ObjSupplier = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_Supplier"];
                    //Added on 25/04/2014--------
                    //PackageTotal = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["Obj_PackageQuantity"];this line commanded by Meena.R on 02/06/2014
                    //Commented on 11/03/2014 LinePackage1 = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["LinePackage1"];
                    //Commented on 11/03/2014  LinePackage2 = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["LinePackage2"];
                    //ObjItemName = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["ObjItemName"];

                }
                else
                {
                    LinePackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LinePackage"];
                    ObjPackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Package"];
                    if (RptDoc is Rpt_ItemSaleMovement)
                        ObjSupplier = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Customer"];
                    else
                        ObjSupplier = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Supplier"];
                    // ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjItemName"];
                    // ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];


                }
                //LinePackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LinePackage"];
                //  LinePackage1 = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["LinePackage"];
                //ObjPackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjPackage"];
                Package = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Package"];

                //ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjItemName"];
                Supplier = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Supplier"];
                // ObjSupplier = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["ObjSupplier"];
            }
            if (IsPackage2)
            {
                LinePackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LinePackage"];
                // LinePackage1 = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["LinePackage1"];
                ObjPackage = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Package"];
                Package = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Package"];
                Supplier = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Supplier"];
                ObjSupplier = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Supplier"];

            }

            if (GeneralOptionSetting.FlagHideItemNumber == "Y" && IsItemNo)
            {
                if (LineItemNo != null) LineItemNo.ObjectFormat.EnableSuppress = true;
                if (ObjItemNo != null) ObjItemNo.ObjectFormat.EnableSuppress = true;
                if (ItemNo != null) ItemNo.ObjectFormat.EnableSuppress = true;
                if (LineItemNo1 != null) LineItemNo1.ObjectFormat.EnableSuppress = true;
                ItemName.Width += ItemNo.Width;
                //ItemName.Left =( ItemNo.Left)-1500;
                //Commented by Ritu on 05-11-2014
                //ItemName.Left += 30;
                //ObjItemNo.Left += 30;
            }
            if (GeneralOptionSetting.FlagHideItemNumber == "Y" && IsItemNo2)
            {
                if (ObjItemNo2 != null) ObjItemNo2.ObjectFormat.EnableSuppress = true;
                if (ItemNo2 != null) ItemNo2.ObjectFormat.EnableSuppress = true;
                //////////if (RptDoc is Rpt_RentingMovement)
                //////////{
                //////////    if (ObjItemNo3 != null) ObjItemNo3.ObjectFormat.EnableSuppress = true;
                //////////    if (LineItemNo3 != null) LineItemNo3.ObjectFormat.EnableSuppress = true;
                //////////    if (LineItemNo1 != null) LineItemNo1.ObjectFormat.EnableSuppress = true;
                //////////    if (ItemNo3 != null) ItemNo3.ObjectFormat.EnableSuppress = true;
                //////////    ItemName.Width += ItemNo3.Width;
                //////////    ItemName.Left = ItemNo3.Left;
                //////////    ObjItemName.Left = ObjItemNo3.Left;
                //////////}

            }
            if (GeneralOptionSetting.FlagHideItemNumber == "Y" && IsItemNo1)
            {
                if (ObjItemNo != null) ObjItemNo.ObjectFormat.EnableSuppress = true;
                if (ItemNo != null) ItemNo.ObjectFormat.EnableSuppress = true;
                if (LineItemNo != null) LineItemNo.ObjectFormat.EnableSuppress = true;
                if (LineItemNo1 != null) LineItemNo1.ObjectFormat.EnableSuppress = true;
                if (ItemName != null) { ItemName.Width += ItemNo.Width; }
                if (ItemName != null) { ItemName.Left = ItemNo.Left; }
                if (ObjItemName != null) { ObjItemName.Left = ObjItemNo.Left; }
            }
            bool packageenable = false;
            packageenable = ((isPackage != false) || (IsPackage1 != false) || (IsPackage2 != false)) ? true : false;
            if (GeneralOptionSetting.FlagHidePackageReport == "Y" && packageenable)
            {
                if (LinePackage != null) LinePackage.ObjectFormat.EnableSuppress = true;
                if (LinePackage1 != null) LinePackage1.ObjectFormat.EnableSuppress = true;
                if (LinePackage2 != null) LinePackage2.ObjectFormat.EnableSuppress = true;
                if (ObjPackage != null) ObjPackage.ObjectFormat.EnableSuppress = true;
                if (Package != null) Package.ObjectFormat.EnableSuppress = true;
                if (PackageTotal != null) PackageTotal.ObjectFormat.EnableSuppress = true;
                if (ObjSupplier != null)
                {
                    Supplier.Width += Package.Width;
                    ObjSupplier.Width += ObjPackage.Width;
                    Supplier.Left -= Package.Width;
                    ObjSupplier.Left -= ObjPackage.Width;
                }
                else if (ObjItemName != null)
                {
                    ItemName.Width += Package.Width;
                    ObjItemName.Width += ObjPackage.Width;
                    ItemName.Left -= Package.Width;
                    ObjItemName.Left -= ObjPackage.Width;
                }

            }
            if (GeneralOptionSetting.FlagPrintTotalQuantity != "Y" && IsReportFooter)
            {
                if (!GeneralFunction.PosPrint)
                if (ReportFooter != null) ReportFooter.SectionFormat.EnableSuppress = true;
            }
            if ((!isInvoice) && (IsExpiry2 | IsExpiry) && (GeneralOptionSetting.FlagSale_HideExpiryFiled == "Y" | GeneralOptionSetting.FlagPurchase_HideExpiryFiled == "Y"))
            {
                if (IsExpiry2)
                {
                    ObjExpiry2 = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_Expiry"];
                    Expiry2 = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Expiry"];
                    LineExpir = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["LineExpiry"];
                    // Commented on 11/03/2014  LineExpiry1  = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["LineExpiry1"];
                    // Commented on 11/03/2014  LineExpiry2 = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["LineExpiry2"];

                    if (!(RptDoc is Rpt_ItemPurchaseMovement))// Add handling for Purchase Movement Report Break 06-Feb-2019
                    {
                        ObjRemains = RptDoc.ReportDefinition.Sections["GroupHeaderSection1"].ReportObjects["Obj_Remaining"];//Changed Remains to Remaining
                        Remains = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Remains"];
                        ForRemains = RptDoc.ReportDefinition.Sections["GroupFooterSection1"].ReportObjects["Remains1"];
                    }


                }
                else
                {
                    ObjExpiry = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Expiry"];
                    Expiry2 = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Expiry"];
                    LineExpir = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["LineExpiry"];
                    // Comment these lines on 06-Feb-2019
                    //if (RptDoc is Rpt_ItemPurchaseMovement || RptDoc is Rpt_ItemSaleMovement)
                    //{
                    //    ObjRemains = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_Remains"];
                    //    Remains = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["Remains"];

                    //}


                }

                if (ObjExpiry != null) ObjExpiry.ObjectFormat.EnableSuppress = true;
                if (ObjExpiry2 != null) ObjExpiry2.ObjectFormat.EnableSuppress = true;
                if (Expiry != null) Expiry.ObjectFormat.EnableSuppress = true;
                if (Expiry2 != null) Expiry2.ObjectFormat.EnableSuppress = true;
                if (LineExpir != null) LineExpir.ObjectFormat.EnableSuppress = true;
                if (LineExpiry1 != null) LineExpiry1.ObjectFormat.EnableSuppress = true;
                //  if (LineExpiry3 != null) LineExpiry3.ObjectFormat.EnableSuppress = false ; 

                if (LineExpiry2 != null) LineExpiry2.Left = 0;
                if (Remains != null) Remains.Left -= Expiry2.Width / 2;
                if (ObjRemains != null) ObjRemains.Left -= Expiry2.Width / 2;
                if (ForRemains != null) ForRemains.Left -= Expiry2.Width / 2;

                if ((ObjExpiry != null) && (IsPackage1 != false) && GeneralOptionSetting.FlagHidePackageReport == "Y")
                {
                    //Supplier.Width += Expiry2.Width;
                    //ObjSupplier.Width += ObjExpiry.Width;

                }
                else if ((ObjExpiry != null) && (IsPackage1 != false) && GeneralOptionSetting.FlagHidePackageReport != "Y")
                {
                    //Commented by ritu on 07-11-2014
                    //if (ObjPackage != null) ObjPackage.Width += ObjExpiry.Width;
                    //if (Package != null) Package.Width += Expiry2.Width;

                }
                if ((RptDoc is Rpt_SpoiledItems) || RptDoc is Rpt_ExpiredListbyDate || RptDoc is Rpt_PriceList)
                {
                    ItemName = RptDoc.ReportDefinition.Sections["Details"].ReportObjects["ItemName"];
                    ObjItemName = RptDoc.ReportDefinition.Sections["PageHeader"].ReportObjects["Obj_ItemName"];
                    //if (ObjItemName != null) ObjItemName.Left -= ObjExpiry.Width / 2;
                    //if (ItemName != null) ItemName.Left -= Expiry2.Width / 2;
                }
            }
            if (IsList)
            {
                ShowList(RptDoc);
            }
            if (isChartType)
            {
                ReportHeadercharttype1 = RptDoc.ReportDefinition.Sections["ReportHeaderSectionChartType"];
                ReportHeadercharttype2 = RptDoc.ReportDefinition.Sections["ReportHeaderSection2"];
                ReportHeadercharttype2.SectionFormat.EnableSuppress = true;
                ReportHeadercharttype1.SectionFormat.EnableSuppress = false;
            }
            if (isSubReport)
            {
                if (ReportFooterSubreport != null)
                {
                    ReportFooterSubreport.SectionFormat.EnableSuppress = false;
                }

            }
            //on 10-11-2014 by Ritu for changing the alignment of fields when tax is hided.
            if (RptDoc is Rpt_Receipt3)
            {
                if (GeneralOptionSetting.FlagHideTaxFiled == "Y")
                {
                    ReportObject tax = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Tax"];
                    ReportObject obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["NetAmt"];
                    int top = obj.Top;
                    obj.Top = obj.Top - (obj.Top - tax.Top);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_NetColon"];
                    obj.Top = obj.Top - (obj.Top - tax.Top);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["PaidAmt"];
                    int top1 = obj.Top;
                    obj.Top = obj.Top - (obj.Top - top);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_PaidColon"];
                    obj.Top = obj.Top - (obj.Top - top);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Refund"];
                    int top2 = obj.Top;
                    obj.Top = obj.Top - (obj.Top - top1);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_RefundColon"];
                    obj.Top = obj.Top - (obj.Top - top1);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["TotalSold1"];
                    obj.Top = obj.Top - (obj.Top - top2);
                    obj = RptDoc.ReportDefinition.Sections["ReportFooter"].ReportObjects["Obj_ItemSold1"];
                    obj.Top = obj.Top - (obj.Top - top2);
                }
            }

            if (RptDoc is Rpt_InvoiceReceipt && ReceiveReceiptHelper.isReceivedReceipt)
            {
                OBJ_PayHeader  = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_PayHeader"];
                OBJ_PayFooter  = RptDoc.ReportDefinition.Sections["ReportFooterSection1"].ReportObjects["OBJ_PayFooter"];
                txtPayToHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtPayToHeader"];
                txtPayToFooter = RptDoc.ReportDefinition.Sections["ReportFooterSection1"].ReportObjects["txtPayToFooter"];



                OBJ_PayHeader.ObjectFormat.EnableSuppress = true;
                OBJ_PayFooter.ObjectFormat.EnableSuppress = true;
                txtPayToHeader.ObjectFormat.EnableSuppress = true;
                txtPayToFooter.ObjectFormat.EnableSuppress = true;

                OBJ_ReceiveHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_ReceiveHeader"];
                OBJ_ReceiveFooter = RptDoc.ReportDefinition.Sections["ReportFooterSection1"].ReportObjects["OBJ_ReceiveFooter"];
                txtReceiveFromHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtReceiveFromHeader"];
                txtReceiveFromFooter = RptDoc.ReportDefinition.Sections["ReportFooterSection1"].ReportObjects["txtReceiveFromFooter"];

                OBJ_ReceiveHeader.ObjectFormat.EnableSuppress = false;
                OBJ_ReceiveFooter.ObjectFormat.EnableSuppress = false;
                txtReceiveFromHeader.ObjectFormat.EnableSuppress = false;
                txtReceiveFromFooter.ObjectFormat.EnableSuppress = false;

            }
            else if(RptDoc is Rpt_InvoiceReceipt && !(ReceiveReceiptHelper.isReceivedReceipt))
            {
                OBJ_ReceiveHeader    = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_ReceiveHeader"];
                OBJ_ReceiveFooter    = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_ReceiveFooter"];
                txtReceiveFromHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtReceiveFromHeader"];
                txtReceiveFromFooter = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtReceiveFromFooter"];

                OBJ_ReceiveHeader.ObjectFormat.EnableSuppress = true;
                OBJ_ReceiveFooter.ObjectFormat.EnableSuppress = true;
                txtReceiveFromHeader.ObjectFormat.EnableSuppress = true;
                txtReceiveFromFooter.ObjectFormat.EnableSuppress = true;

                OBJ_PayHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_PayHeader"];
                OBJ_PayFooter = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["OBJ_PayFooter"];
                txtPayToHeader = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtPayToHeader"];
                txtPayToFooter = RptDoc.ReportDefinition.Sections["PageHeaderSection2"].ReportObjects["txtPayToFooter"];


                OBJ_PayHeader.ObjectFormat.EnableSuppress =  false;
                OBJ_PayFooter.ObjectFormat.EnableSuppress =  false;
                txtPayToHeader.ObjectFormat.EnableSuppress = false;
                txtPayToFooter.ObjectFormat.EnableSuppress = false;


            }

        }


        private void LogoOption()
        {
            #region "Logo Options"


            CrystalDecisions.CrystalReports.Engine.Section sectionFooterText = RptDoc.ReportDefinition.Sections["CompanyFooterText"];
            CrystalDecisions.CrystalReports.Engine.ReportObject headerLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["HeaderLogo"].ReportObjects["Obj_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject footerLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["FooterLogo"].ReportObjects["Obj_FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject compLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Obj_PH_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject companyName = RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["CompanyName"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjFax = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Obj_Fax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Fax = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Fax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjCell = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Obj_Cell"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Cell = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Cell"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjPhone = RptDoc is Rpt_InvoiceReceipt ? RptDoc.ReportDefinition.Sections["FooterLogo1"].ReportObjects["Obj_Phone"] : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Obj_Phone"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Phone = RptDoc is Rpt_InvoiceReceipt ? RptDoc.ReportDefinition.Sections["FooterLogo1"].ReportObjects["Phone"] : RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["Phone"];
            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderLogo = RptDoc.ReportDefinition.Sections["HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderText = RptDoc.ReportDefinition.Sections["CompanyLogo"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterLogo = RptDoc.ReportDefinition.Sections["FooterLogo"];
            FieldObject field;
            field = RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["CompanyName"] as FieldObject;
            Font = new System.Drawing.Font("Al-Kharashi 3", field.Font.Size, FontStyle.Bold);
            field.ApplyFont(Font);
            if (RptDoc is Rpt_InvoiceReceipt) //Should include
            {
                CrystalDecisions.CrystalReports.Engine.ReportObject compLogo1 = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Obj_CL_HeaderLogo"];
                if (compLogo1 != null) { compLogo1.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1; }
            }

            if (compLogo != null && headerLogo != null && footerLogo != null)
            {
                compLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
                headerLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
                footerLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.FooterLogo == null || GeneralOptionSetting.FooterLogo.Length <= 1;

            }

            if (!(RptDoc is Rpt_EndOfDays) && !(RptDoc is Rpt_InvoiceReceipt))
            {
            if (HideLogo || GeneralOptionSetting.FlagHideLogoOnPrint == "Y")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                try
                {
                    if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                    if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
                }
                catch (Exception ex)
                {

                }
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "0")
            {
                //if (GeneralFunction.HideLogo == true)
                //{
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                //}
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "1")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "2")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (footerLogo != null) footerLogo.Height = 0;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "3")
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                //companyName.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                if (compLogo != null) compLogo.Height = 0;
                if (ObjFax != null) ObjFax.Height = 0;
                if (ObjCell != null) ObjCell.Height = 0;
                if (ObjPhone != null) ObjPhone.Height = 0;
                if (Fax != null) Fax.Height = 0;
                if (Cell != null) Cell.Height = 0;
                if (Phone != null) Phone.Height = 0;
                // companyName.Left = 360;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "4")
            {
                //if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                //if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
                if (compLogo != null) compLogo.Height = 0;
            }
            else
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader == null ? "1" : GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter == null ? "1" : GeneralOptionSetting.FlagFooter) * 25);
            }
            }
            else
            {
                if (RptDoc is Rpt_InvoiceReceipt)
                {
                    
                }
                else
                {
                    CrystalDecisions.CrystalReports.Engine.ReportObject companyname = RptDoc.ReportDefinition.Sections["Section2"].ReportObjects["CompName1"];

                    if (GeneralOptionSetting.FlagPrintingLogo == "4")
                    {
                        companyname.ObjectFormat.EnableSuppress = false;
                    }
                    else { companyname.ObjectFormat.EnableSuppress = true; }
                }
            } 
            

            if (GeneralOptionSetting.FlagShowCompanyNameOnly == "Y" && !(RptDoc is Rpt_EndOfDays))//if (GeneralOptionSetting.FlagShowCompanyNameOnly == "Y" || RptDoc is Rpt_EndOfDays)
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                //companyName.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                if (compLogo != null) compLogo.Height = 0;
                if (ObjFax != null) ObjFax.Height = 0;
                if (ObjCell != null) ObjCell.Height = 0;
                if (ObjPhone != null) ObjPhone.Height = 0;
                if (Fax != null) Fax.Height = 0;
                if (Cell != null) Cell.Height = 0;
                if (Phone != null) Phone.Height = 0;
                
                if (compLogo != null) compLogo.Height = 0;

                // i commit on  14-Jan-2019 issue section value
                //if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                //if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
                //

                //companyName.Left = 360;
            }

            if (GeneralOptionSetting.FlagShowCompanyOnInvoice != "Y" && !(RptDoc is Rpt_EndOfDays))//if (GeneralOptionSetting.FlagShowCompanyOnInvoice != "Y" || RptDoc is Rpt_EndOfDays)
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
                
            }
            //else if (GeneralOptionSetting.FlagShowCompanyOnInvoice == "Y")
            //{
            //    if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader)*25);
            //    if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter)*25);
            //    if (sectionHeaderLogo != null) headerLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader)*25);
            //    if (sectionFooterLogo != null) footerLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) *25);
            //}this condition temp commended.

            if (RptDoc is Rpt_InvoiceReceipt)
            {
                LogoOptionReceipt(RptDoc);
            }

            #endregion
        }
        private void LogoOptionReceipt(ReportDocument RptDoc)
        {
            #region "Logo Options"

            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderLogo =  RptDoc.ReportDefinition.Sections["HeaderLogo1"];
            CrystalDecisions.CrystalReports.Engine.Section sectionHeaderText =  RptDoc.ReportDefinition.Sections["CompanyLogo1"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterLogo =  RptDoc.ReportDefinition.Sections["FooterLogo1"];
            CrystalDecisions.CrystalReports.Engine.Section sectionFooterText =  RptDoc.ReportDefinition.Sections["CompanyFooterText1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject headerLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["HeaderLogo1"].ReportObjects["Obj_HL_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject footerLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["FooterLogo1"].ReportObjects["Obj_CL_FooterLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject compLogo = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Obj_CL_HeaderLogo"];
            CrystalDecisions.CrystalReports.Engine.ReportObject companyName =  RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["CompanyName1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjFax = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Obj_CL_Fax"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Fax = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Fax1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjCell = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Obj_CL_Cell"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Cell = RptDoc is Rpt_InvoiceReceipt ? null : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Cell1"];
            CrystalDecisions.CrystalReports.Engine.ReportObject ObjPhone = RptDoc is Rpt_InvoiceReceipt ? RptDoc.ReportDefinition.Sections["CompanyFooterText"].ReportObjects["Obj_CL_Phone"] : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Obj_CL_Phone"];
            CrystalDecisions.CrystalReports.Engine.ReportObject Phone = RptDoc is Rpt_InvoiceReceipt ? RptDoc.ReportDefinition.Sections["CompanyFooterText"].ReportObjects["Phone1"] : RptDoc.ReportDefinition.Sections["CompanyLogo1"].ReportObjects["Phone1"];
            FieldObject field;
            field = RptDoc.ReportDefinition.Sections["CompanyLogo"].ReportObjects["CompanyName"] as FieldObject;
            Font = new System.Drawing.Font("Al-Kharashi 3", field.Font.Size, FontStyle.Bold);
            if (compLogo != null && headerLogo != null && compLogo != null)
            {
                compLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
                headerLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.HeaderLogo == null || GeneralOptionSetting.HeaderLogo.Length <= 1;
                footerLogo.ObjectFormat.EnableSuppress = GeneralOptionSetting.FooterLogo == null || GeneralOptionSetting.FooterLogo.Length <= 1;
            }
            if (HideLogo)
            {

                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "0")
            {
                //if (GeneralFunction.HideLogo == true)
                //{
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (GeneralOptionSetting.FlagLogoHeader == null)
                {
                    compLogo.Height = 0;
                    companyName.Left = 0;
                }
                //}
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "1")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "2")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (footerLogo != null) footerLogo.Height = 0;

            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "3")
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                //companyName.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                if (compLogo != null) compLogo.Height = 0;
                if (ObjFax != null) ObjFax.Height = 0;
                if (ObjCell != null) ObjCell.Height = 0;
                if (ObjPhone != null) ObjPhone.Height = 0;
                if (Fax != null) Fax.Height = 0;
                if (Cell != null) Cell.Height = 0;
                if (Phone != null) Phone.Height = 0;
                companyName.Left = 360;
            }
            else if (GeneralOptionSetting.FlagPrintingLogo == "4")
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (compLogo != null) compLogo.Height = 0;
            }
            else
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }
            if (GeneralOptionSetting.FlagShowCompanyNameOnly == "Y")
            {
                if (sectionHeaderLogo != null) sectionHeaderLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterLogo != null) sectionFooterLogo.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                //companyName.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
                if (compLogo != null) compLogo.Height = 0;
                if (ObjFax != null) ObjFax.Height = 0;
                if (ObjCell != null) ObjCell.Height = 0;
                if (ObjPhone != null) ObjPhone.Height = 0;
                if (Fax != null) Fax.Height = 0;
                if (Cell != null) Cell.Height = 0;
                if (Phone != null) Phone.Height = 0;
                companyName.Left = 360;
            }

            if (GeneralOptionSetting.FlagShowCompanyOnInvoice != "Y")
            {
                if (sectionHeaderText != null) sectionHeaderText.SectionFormat.EnableSuppress = true;
                if (sectionFooterText != null) sectionFooterText.SectionFormat.EnableSuppress = true;
                if (headerLogo != null) headerLogo.Height = 0;
                if (footerLogo != null) footerLogo.Height = 0;
                if (sectionHeaderLogo != null) sectionHeaderLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagHeader) * 25);
                if (sectionFooterLogo != null) sectionFooterLogo.Height = (int)(int.Parse(GeneralOptionSetting.FlagFooter) * 25);
            }

            #endregion
        }
        private void ShowList(ReportDocument RptDoc)
        {

            foreach (ReportObject rptObj in RptDoc.ReportDefinition.ReportObjects)
            {
                if (rptObj.GetType().Name == "LineObject" && !rptObj.Name.Contains("H"))
                {
                    rptObj.ObjectFormat.EnableSuppress = true;
                }

            }
        }

        public void ReportsView_Load(object sender, EventArgs e)
        {

        }

        public void LoadStampImage()
        {
            // //         try
            // //{
            // //    FileStream fs = new FileStream(FilePath, 
            // //               System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // //    byte[] Image = new byte[fs.Length];
            // //    fs.Read(Image, 0, Convert.ToInt32(fs.Length));
            // //    fs.Close();
            // //    objDataRow[strImageField] = Image;
            // //}
            // //catch (Exception ex)
            // //{
            // //    Response.Write("<font color=red>" + ex.Message + "</font>");
            // //}

            // System.Drawing.Bitmap bitmap1 = BumedianBM.Properties.Resources.administrator_128;
            // //Assembly _assembly = Assembly.GetExecutingAssembly();
            // //Stream _imageStream =
            // //    _assembly.GetManifestResourceStream(
            // //    "ThumbnailPictureViewer.resources.Image1.bmp");
            // //Bitmap theDefaultImage = new Bitmap(_imageStream);
            // //.ReportSource = bitmap1;
            //// RptDoc.Load(bitmap1.ToString());
            //// string str=this.Server.Math
            //// ReportDocument crDoc = new ReportDocument();
            //// crDoc.Load(Server.MapPath("CrystalReport.rpt"));
            //// crDoc.SetDataSource(ds.Tables[0]);
            //// CrystalReportViewer1.ReportSource = crDoc;
            // DataTable dt = new DataTable();
            // dt.Columns.Add("Image");
            // DataRow dre;
            // dre = dt.NewRow();
            // dre["Image"] = bitmap1;
            // dt.Rows.Add(dre);
            // DsCompLogo.Tables.Add(Report_Table);
            ////this.Server.Mappath
            // RptDoc.SetDataSource(DsCompLogo);

            try
            {
                // here i have define a simple datatable inwhich image will recide 
                DataTable dt = new DataTable();
                // object of data row 
                DataRow drow;
                // add the column in table to store the image of Byte array type 
                dt.Columns.Add("Image", System.Type.GetType("System.Byte[]"));
                drow = dt.NewRow();
                // define the filestream object to read the image 
                FileStream fs;
                // define te binary reader to read the bytes of image 
                BinaryReader br;
                // check the existance of image 
                //OpenFileDialog fd = new OpenFileDialog();
                //fd.ShowDialog();
                //fs = new FileStream(@"C:",
                //    System.IO.FileMode.Open, System.IO.FileAccess.Read);
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "add_32.png"))
                {
                    // open image in file stream 
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "add_32.png", FileMode.Open, FileAccess.Read);
                }
                else
                {
                    // if phot does not exist show the nophoto.jpg file 
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "add_32.png", FileMode.Open);
                }
                // initialise the binary reader from file streamobject 
                br = new BinaryReader(fs);
                // define the byte array of filelength 
                byte[] imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader 
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
                drow[0] = imgbyte;
                // add the image in bytearray 
                dt.Rows.Add(drow);
                // add row into the datatable 
                br.Close();
                // close the binary reader 
                fs.Close();
                // close the file stream 

                // object of crystal report 
                RptDoc.SetDataSource(dt);
                // set the datasource of crystalreport object 
                //CrystalReportViewer1.ReportSource = rptobj;
                crystalReportViewer1.ReportSource = RptDoc;
                //set the report source 
            }
            catch (Exception ex)
            {
                // error handling 
                throw ex;
            }
        }
    }
}
