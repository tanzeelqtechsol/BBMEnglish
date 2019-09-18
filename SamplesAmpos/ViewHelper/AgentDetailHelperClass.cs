using System;
using BumedianBM.View;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Windows.Forms;
using System.Data;
using BumedianBM.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BumedianBM.ArabicView;
using System.Collections.Generic;
using BumedianBM.CrystalReports;
using System.Configuration;


namespace BumedianBM.ViewHelper
{
    public class AgentDetailHelperClass
    {
        //ConnectionInfo connectioninfo = new ConnectionInfo();
        //ReportDocument rptDOC = new ReportDocument();
        //ReportViewer Viewer = new ReportViewer();
        // BALClass bal = new BALClass();
        internal string AgentType, ControlName = string.Empty;
        internal bool isSaveSuccess;
        internal bool IsFromFormLoad;
        internal string agenttype;

        #region Object Initialization

        AgentDetailBALClass ObjAgentDetailBALClass;
        MasterDataBALClass ObjMasterDataBALClass;
        #endregion

        #region Constructor
        public AgentDetailHelperClass()
        {
            ObjMasterDataBALClass = new MasterDataBALClass();
            ObjAgentDetailBALClass = new AgentDetailBALClass();
            ObjAgentDetailBALClass.SetAgentDetailObject();

        }
        #endregion

        public AgentDetailBALClass ObjbalClass
        {
            get { return ObjAgentDetailBALClass; }
            set { ObjAgentDetailBALClass = value; }
        }

        //public void LoadAgentName()
        //{

        //    // ObjAgentDetailBALClass.GetAgentNameSeeniTest();//----Commented on 15/11/2013 by seenivasan for getting value from List
        //    ObjAgentDetailBALClass.GetAgentName();
        //    //AgentDetailForm.cmbName.DataSource = GeneralObjectClass.AgentDetails;  //Added on 15/11/2013 by seenivasan for getting value from List
        //    AgentDetailForm.cmbName.DataSource = GeneralObjectClass.AgentDetails;
        //    AgentDetailForm.cmbName.DisplayMember = "AgentName";
        //    AgentDetailForm.cmbName.ValueMember = "AgentID";
        //    //  AgentDetailForm.cmbName.DisplayMember = "Name";//Added on 15/11/2013 by seenivasan
        //    //  AgentDetailForm.cmbName.ValueMember = "AgentId";//Added on 15/11/2013 by seenivasan
        //    AgentDetailForm.cmbName.SelectedIndex = -1;
        //}

        public void SaveMethod()
        {
            //ObjAgentDetailBALClass.ObjAgentDetailObject = ObjAgentDetail;
            if (AgentDetailValidation())
            {
                //if (ObjAgentDetailBALClass.ObjAgentDetailObject.Agt_HideAgent.Contains== "104")
                //    ObjAgentDetailBALClass.ObjAgentDetailObject.Remove = 1;
                //else
                    ObjAgentDetailBALClass.ObjAgentDetailObject.Remove = 0;
                //  AgentTypeID();
                if (ObjAgentDetailBALClass.ObjAgentDetailObject.Number == 0)
                {
                    if (ObjAgentDetailBALClass.CheckAgentAvailable())
                    {
                        if (ObjAgentDetailBALClass.SaveAgentDetails())
                        {
                            //include this line on 28 april 2014 ,to reload the agentlist
                            GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
                            isSaveSuccess = true;
                            GeneralFunction.Information("SaveAgent", "AgentDetails");

                            //GeneralObjectClass.AgentDetails.Add(ObjAgentDetailBALClass.ObjAgentDetailObject);
                            //  return true;

                            //this.LoadAgentName();
                            //AgentDetailForm.Clear();
                        }
                    }
                    else
                        GeneralFunction.Information("ExistsAgentName", "AgentDetails");


                }
                else
                {
                    if (CommonHelper.GeneralFunction.Question("UpdateAgentDetails", "AgentDetails") == DialogResult.Yes)
                    {
                        if (ObjAgentDetailBALClass.SaveAgentDetails())
                        {
                            //include this line on 28 april 2014 ,to reload the agentlist
                            GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
                            isSaveSuccess = true;
                            CommonHelper.GeneralFunction.Information("AgentDetailsUpdated", "AgentDetails");
                            //return true;
                            //this.LoadAgentName();
                            //AgentDetailForm.Clear();
                        }
                    }
                }

            }
        }

        //private void AgentTypeID()
        //{

        //    if (AgentDetailForm.chkClient.Checked == true)
        //    {
        //        AgentType = "101"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtClient = "101";
        //    }
        //    else
        //    {
        //        AgentType = "0"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtClient = "0";
        //    }
        //    if (AgentDetailForm.chkSupplier.Checked == true)
        //    {
        //        AgentType = AgentType + "|" + "102"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtSupplier = "102";
        //    }
        //    else
        //    {
        //        AgentType = AgentType + "|" + "0"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtSupplier = "0";
        //    }
        //    if (AgentDetailForm.chkBranch.Checked == true)
        //    {
        //        AgentType = AgentType + "|" + "103"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtBranch = "103";
        //    }
        //    else
        //    {
        //        AgentType = AgentType + "|" + "0"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtBranch = "0";
        //    }
        //    if (AgentDetailForm.chkHideAgent.Checked == true)
        //    {
        //        AgentType = AgentType + "|" + "104"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtHideAgent = "104";
        //    }
        //    else
        //    {
        //        AgentType = AgentType + "|" + "0"; ObjAgentDetailBALClass.ObjAgentDetailObject.AgtHideAgent = "0";
        //    }
        //    ObjAgentDetailBALClass.ObjAgentDetailObject.AgentType = AgentType;
        //}

        public Boolean AgentDetailValidation()
        {
            if (ObjAgentDetailBALClass.ObjAgentDetailObject.Name == string.Empty)
            {
                GeneralFunction.Information("EmptyAgentName", "AgentDetails");
                ControlName = "cmbName";
                return false;
            }
            else if (AgentType == "0|0|0|0" || AgentType == "0|0|0|104")
            {
                GeneralFunction.Information("AtleastAgentType", "AgentDetails");
                ControlName = "grpAgentType";
                return false;

            }
            else
                return true;
        }

        //private bool CheckAgentType()
        //{
        //    System.Windows.Forms.CheckBox chkctrl;
        //    foreach (Control ctr in AgentDetailForm.grpAgentType.Controls)
        //    {
        //        if (ctr.GetType().ToString() == "System.Windows.Forms.CheckBox")
        //        {

        //            chkctrl = (System.Windows.Forms.CheckBox)ctr;
        //            if (chkctrl.Checked == true)
        //            {

        //                return true;
        //            }

        //        }
        //    }
        //    return false;

        //}

        public int AgentNameSelectedIndexChanged()
        {
            int RecordCount = 0;
            if (ObjAgentDetailBALClass.ObjAgentDetailObject.AgentId != null)
            {
                //DataTable dt = new DataTable();

                //if(AgentDetailForm.cmbName.SelectedIndex>-1)
                if (!IsFromFormLoad)
                {
                    //   ObjAgentDetailBALClass.ObjAgentDetailObject.AgentId = Convert.ToInt32(AgentDetailForm.cmbName.SelectedValue.ToString());
                    List<AgentDetailObjectClass> AgentDetails = ObjAgentDetailBALClass.GetAgentDetails();
                    if (AgentDetails != null && AgentDetails.Count > 0)
                    {
                        RecordCount = AgentDetails.Count;
                        foreach (var l in AgentDetails)
                        {

                            ObjAgentDetailBALClass.ObjAgentDetailObject.Name = l.Name;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Phoneno = l.Phoneno;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Address = l.Address;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Discount = l.Discount;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.IncreasePrice = l.IncreasePrice;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.PaymentDay = l.PaymentDay;
                            //ObjAgentDetailBALClass.ObjAgentDetailObject.PaymentDay = dt.Rows[0][""].ToString();
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Number = l.Number;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.DebtLimt = l.DebtLimt;
                            if (l.Lastpaymentdate.ToString() != string.Empty)
                            {
                                ObjbalClass.ObjAgentDetailObject.Lastpaymentdate = l.Lastpaymentdate;
                                //AgentDetailForm.txtLastPaymentDate.Text = dt.Rows[0]["LastPaymentDate"].ToString();
                            }
                            else
                                ObjbalClass.ObjAgentDetailObject.Lastpaymentdate = null;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Lastinvoice = l.Lastinvoice;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Payable = l.Payable;
                            ObjAgentDetailBALClass.ObjAgentDetailObject.Receivable = l.Receivable;
                            agenttype = l.AgentType;
                            //string[] AgentType = agenttype.Split('|');
                            //if (AgentType[0] == "101")
                            //{
                            //    AgentDetailForm.chkClient.Checked = true;
                            //}
                            //if (AgentType[1] == "102")
                            //{
                            //    AgentDetailForm.chkSupplier.Checked = true;
                            //}
                            //if (AgentType[2] == "103")
                            //{
                            //    AgentDetailForm.chkBranch.Checked = true;
                            //}
                            //if (AgentType[3] == "104")
                            //{
                            //    AgentDetailForm.chkHideAgent.Checked = true;
                            //}

                        }
                        // AgentDetailForm.setControlFromObject();
                    }
                }

            }
            return RecordCount;
        }

        public void DeleteMethod()
        {

            //ObjAgentDetailBALClass.ObjAgentDetailObject=ObjAgentDetail;
            //  ObjAgentDetailBALClass.ObjAgentDetailObject.AgentId = Convert.ToInt16(AgentDetailForm.cmbName.SelectedValue.ToString());
            ObjAgentDetailBALClass.ObjAgentDetailObject.Remove = 1;
            //  AgentTypeID();
            if (ObjAgentDetailBALClass.ObjAgentDetailObject.Number != 0)
            {
                if (GeneralFunction.Question("AlertDeleteAgent", "AgentDetails") == DialogResult.Yes)
                {
                    if (ObjbalClass.AgentInvolvedInInvoice())
                    {
                        if (ObjAgentDetailBALClass.DeleteAgentDetail())
                        {
                            //include this line on 28 april 2014 ,to reload the agentlist
                            GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
                            isSaveSuccess = true;
                            //CommonHelper.GeneralFunction.Information(Constants.AGENTDELETED, ActionType.Delete.ToString());
                            GeneralFunction.Information("DeleteAgent", "AgentDetails");
                            // GeneralObjectClass.AgentDetails.Remove(ObjAgentDetailBALClass.ObjAgentDetailObject);
                            // this.LoadAgentName();
                        }
                    }
                    else
                        GeneralFunction.Information("FailedDeleteAgent", "AgentDetails");
                }
                else
                {
                    return;
                }

            }
            else
                CommonHelper.GeneralFunction.ErrInfo(Constants.INVAILDTODELETE, ActionType.Delete.ToString());

        }

        public void Print()
        {
            Rpt_AgentDetail summery = new Rpt_AgentDetail();
            ReportsView frmView = new ReportsView();
            //PurchaseInvoiceDetails ObjInvoiceDetails = new PurchaseInvoiceDetails();
            //summery.Refresh();
            ReportDocument rptdoc = new ReportDocument();
            DataTable dt = new DataTable("AgentList");
            dt = ObjbalClass.ReportAgentDetails();

            if (dt.Rows.Count > 0)
            {
                //rptdoc = rpt;

                frmView.RptDoc = summery;
                // frmView.Repnum = rptdoc.Database.Tables;
                frmView.Report_Table = dt;
                frmView.HTable.Clear();
                frmView.RptDoc = summery;
                ReportDocument rpt = summery;
                Tables tbl = rpt.Database.Tables;
                frmView.Repnum = tbl;
                frmView.LoadEvent();
                frmView.ShowDialog();
            }
        }

        public void DebtList()
        {
            Rpt_DeptList rpt = new Rpt_DeptList();
            // ReportDocument rptDOC = new ReportDocument();
            ReportsView frmView = new ReportsView();
            DataTable dt = new DataTable("DeptList");
            dt = ObjbalClass.DebtList();
            //rptDOC = rpt;
            frmView.RptDoc = rpt;
            dt.Columns.Add("PaymentDate");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = Convert.ToDateTime(dt.Rows[i]["PaymentDateTime"] == DBNull.Value ? DateTime.MinValue : dt.Rows[i]["PaymentDateTime"]).Date.ToString(ConfigurationManager.AppSettings["DateFormat"].ToString());
                dt.Rows[i]["PaymentDate"] = str;
            }

            //frmView.Repnum = rptDOC.Database.Tables;
            frmView.Report_Table = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                frmView.LoadEvent();
                frmView.ShowDialog();
            }
            else
                GeneralFunction.Information("NoRecordsFound", "AgentDetails");
        }
    }
}
