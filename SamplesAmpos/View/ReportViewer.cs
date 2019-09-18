using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using BumedianBM.Report;

namespace BumedianBM.View
{
    public partial class ReportViewer : Form
    {
        AddressPhoneBook rpt = new AddressPhoneBook();
        ReportDocument reportdocument = new ReportDocument();
        public DataTable Dt = null;
        public System.Collections.Hashtable HTable;
        public ReportDocument RptDoc;
        public Tables Repnum;
        public ReportViewer()
        {
            InitializeComponent();
            HTable = new System.Collections.Hashtable();
        }
         
       private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
       
        }
    }
}
