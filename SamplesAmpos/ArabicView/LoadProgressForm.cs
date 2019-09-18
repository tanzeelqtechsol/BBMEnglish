using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ObjectHelper;
using CommonHelper;
using BALHelper;
using BumedianBM.ViewHelper;

namespace BumedianBM.ArabicView
{
    public partial class LoadProgressForm : Form,IDisposable
    {
        AgentDetailBALClass ObjAgentDetailBALClass;
        MasterDataBALClass ObjMasterDataBALClass;

        DataTable dtload = new DataTable();

        public LoadProgressForm()
        {
            InitializeComponent();
            ObjAgentDetailBALClass = new AgentDetailBALClass();
            ObjMasterDataBALClass = new MasterDataBALClass();
            // lblStatus.Visible = true;
            bgwLoad.WorkerReportsProgress = true;
            bgwLoad.WorkerSupportsCancellation = true;
            bgwLoad.DoWork += new DoWorkEventHandler(bgwLoad_DoWork);
            bgwLoad.ProgressChanged += new ProgressChangedEventHandler(bgwLoad_ProgressChanged);
            bgwLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwLoad_RunWorkerCompleted);
            bgwLoad.RunWorkerAsync();
        }

        private void bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            //dtload = ObjAgentDetailBALClass.GetAgentName();
           // GeneralObjectClass.SupplierDetails = ObjMasterDataBALClass.GetSupllierBal();
            GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
            bgwLoad.ReportProgress(20);
            GeneralObjectClass.BankList = ObjMasterDataBALClass.GetBankDetailsBal();
            GeneralObjectClass.BranchList = ObjMasterDataBALClass.BranchDetailsBal();
            bgwLoad.ReportProgress(20);
            GeneralObjectClass.CategoryList = ObjMasterDataBALClass.GetCategoryDetailsBal();
            GeneralObjectClass.CompanyList = ObjMasterDataBALClass.GetCompanyDetailsBal();
            bgwLoad.ReportProgress(20);
            GeneralObjectClass.ItemDetails = ObjMasterDataBALClass.ItemDetailsBal();
            GeneralObjectClass.UserList = ObjMasterDataBALClass.UserDetailsBal();
            GeneralObjectClass.UserGroupList = ObjMasterDataBALClass.UserGroupDetailsBal();
            bgwLoad.ReportProgress(40);
           

            //for (int i = 0; i <= 10000; i++)
            //{
            //    bgwLoad.ReportProgress(i);
            //}

        }

        private void bgwLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbarLoad.Step = e.ProgressPercentage;
            pgbarLoad.PerformStep();
        }

        private void bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // lblStatus.Text = "Finished";
            // MessageBox.Show("done");
            this.Hide();
            MasterFrom frmMaster = new MasterFrom();
            frmMaster.Show();
           // frmSpending s = new frmSpending();
            //s.Show();
        }
    }
}
