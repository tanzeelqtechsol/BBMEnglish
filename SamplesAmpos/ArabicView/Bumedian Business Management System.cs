using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using CommonHelper;

namespace BumedianBM.ArabicView
{
    public partial class Bumedian_Business_Management_System : Form,IDisposable
    {
        public Bumedian_Business_Management_System()
        {
            InitializeComponent();
            setLanguage();
            setFont();
            lblBuildDate.Text = Additional_Barcode.GetValueByResourceKey("ReleaseDate") + " " + GeneralFunction.BuildDate; 
            
            Lbl_Version.Text = Additional_Barcode.GetValueByResourceKey("Version2");

        }

        private void about_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {

                    OldQuickPriceInfo pric = new OldQuickPriceInfo();
                    pric.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrMsg(this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "about_KeyDown");
            }
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Llbl_Email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + "almaqarpos@gmail.com");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Llbl_WebMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", "www.almaqar.ly");
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrMsg(this.Text);
                //GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Llbl_WebMail_LinkClicked");
            }
        }

        private void Llbl_TermsAndCon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var CultureInfo = Thread.CurrentThread.CurrentUICulture;
                ReportsView rptView = new ReportsView();
                rptView.CompLogo = rptView.isInvoice = rptView.IsReportFooter = false;
                if (CultureInfo.Name == "en-US")
                {
                    Rpt_TermsandCondition summery = new Rpt_TermsandCondition();
                    rptView.RptDoc = summery;
                    //   ReportDocument rpt = summery;
                }
                else
                {
                    Rpt_TermsandConditions summery = new Rpt_TermsandConditions();
                    rptView.RptDoc = summery;
                }
                rptView.Repnum = null;
                rptView.LoadEvent();
                rptView.ShowDialog();

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
               
            }
        }

        private void setLanguage()
        {
            Lbl_AlmaqarInfoTech.Text = Additional_Barcode.GetValueByResourceKey("BBMSystem");
            Lbl_AddressName.Text=Additional_Barcode.GetValueByResourceKey("AlfatahUniversityRoad");
            Lbl_Addrress.Text = Additional_Barcode.GetValueByResourceKey("AddressColon");
            label1.Text = Additional_Barcode.GetValueByResourceKey("AlmaqarInfoTech");
            Llbl_TermsAndCon.Text = Additional_Barcode.GetValueByResourceKey("TermsConditions");
            Btn_Ok.Text = Additional_Barcode.GetValueByResourceKey("Close");
            Lbl_Email.Text = Additional_Barcode.GetValueByResourceKey("EMail");
            Lbl_WebSite.Text = Additional_Barcode.GetValueByResourceKey("WebSite");
            Lbl_Maintenance.Text = Additional_Barcode.GetValueByResourceKey("MaintenanceCenter");
            Lbl_TechSupport.Text = Additional_Barcode.GetValueByResourceKey("TechSupport");
            Lbl_ContactInfo.Text = Additional_Barcode.GetValueByResourceKey("ContactInfo");
            Lbl_ContactInfoName.Text = Additional_Barcode.GetValueByResourceKey("ContactName");
            Lbl_Version.Text = Additional_Barcode.GetValueByResourceKey("Version2");
            lblCN.Text = Additional_Barcode.GetValueByResourceKey("CompanyName");
            lblAIS.Text = Additional_Barcode.GetValueByResourceKey("AlmaqarInformationSystems");
        }

        private void setFont()
        {
            var CultureInfo = Thread.CurrentThread.CurrentUICulture;
            if (CultureInfo.Name == "en-US")
            {
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is Button || Ctrl is Label || Ctrl is TextBox || Ctrl is LinkLabel)
                        Ctrl.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                }
                Lbl_AlmaqarInfoTech.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            }
        }
    }
}
