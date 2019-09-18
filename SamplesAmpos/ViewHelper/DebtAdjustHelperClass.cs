using System;
using System.Collections.Generic;
using CommonHelper;
using BALHelper;
using ObjectHelper;
using System.Data;
using System.Windows.Forms;
using BumedianBM.Interface;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using BumedianBM.ArabicView;

namespace BumedianBM.ViewHelper
{
    public class DebtAdjustHelperClass : IAccountView
    {
        //  Debt_Adjustment debtAdjust;
        public DebtAdjustBALClass objDebtBALClass;
        public DataTable dtAgentNameID = new DataTable();
        DataTable dtGetMinMax = new DataTable();
        DataTable dt = new DataTable();
        internal int MaxID, CurrentYear; internal int MinID;
        decimal decAmt, decRec, decTotal, decDiscount;
        internal decimal Balance;
        internal string str;
        public DebtAdjustHelperClass()
        {
            // TODO: Complete member initialization
            objDebtBALClass = new DebtAdjustBALClass();
            objDebtBALClass.SetComObject();
            objDebtBALClass.ObjDebtAdjustObject.PayFlag = Convert.ToInt32(PayReceiptFor.Debt);

        }

        public DebtAdjustBALClass ObjBALClass
        {
            get { return objDebtBALClass; }
            set { objDebtBALClass = value; }
        }

        internal void BindMaxIdToControls()
        {
            List<AgentDetailObjectClass> listDebt;
            try
            {
                listDebt = new List<AgentDetailObjectClass>();
                listDebt = ObjBALClass.IDForDebt();
                int CheckMaxId = Convert.ToInt32(listDebt[0].ReceiptID);
                if (CheckMaxId != 0)
                {
                    ObjBALClass.ObjDebtAdjustObject.ReceiptID = listDebt[0].ReceiptID;
                    ObjBALClass.ObjDebtAdjustObject.Year = listDebt[0].Year;
                    ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = listDebt[0].YearSequenceNo;
                    GetDebtRecordByInvoice();
                    LoadMaxMinNumber();
                }
                else
                {
                    CreateEmptyRecord();
                    LoadMaxMinNumber();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                listDebt = null;
            }
        }

        public void GetDebtRecordByInvoice()
        {
            //List<AgentDetailObjectClass> DebtRecord = ObjBALClass.GetDebtRecord();
            //AssignListsToObject(DebtRecord);
            AssignListsToObject(ObjBALClass.GetDebtRecord());
        }

        private void AssignListsToObject(List<AgentDetailObjectClass> tempRecord)
        {
            try
            {
                if (tempRecord.Count > 0)
                {
                    ObjBALClass.ObjDebtAdjustObject.ReceiptID = tempRecord[0].ReceiptID;
                    ObjBALClass.ObjDebtAdjustObject.TableID = tempRecord[0].TableID;
                    ObjBALClass.ObjDebtAdjustObject.AgentId = tempRecord[0].AgentId;
                    ObjBALClass.ObjDebtAdjustObject.Balance = tempRecord[0].Balance;
                    ObjBALClass.ObjDebtAdjustObject.Amount = tempRecord[0].Amount;
                    ObjBALClass.ObjDebtAdjustObject.Description = tempRecord[0].Description;
                    ObjBALClass.ObjDebtAdjustObject.ReceiptDate = tempRecord[0].ReceiptDate;
                    //ObjBALClass.ObjDebtAdjustObject.PayType = tempRecord[0].PayFlag.ToString();
                    ObjBALClass.ObjDebtAdjustObject.Status = tempRecord[0].Status;
                    ObjBALClass.ObjDebtAdjustObject.Year = tempRecord[0].Year;
                    ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = tempRecord[0].YearSequenceNo;
                    if (tempRecord[0].PayType.ToString() == "REC")
                    {
                        ObjBALClass.ObjDebtAdjustObject.Payable = 0.0;
                        ObjBALClass.ObjDebtAdjustObject.Receivable = ObjBALClass.ObjDebtAdjustObject.Amount;
                    }
                    else
                    {
                        ObjBALClass.ObjDebtAdjustObject.Payable = ObjBALClass.ObjDebtAdjustObject.Amount;
                        ObjBALClass.ObjDebtAdjustObject.Receivable = 0.0;
                    }

                }
                else
                {
                    List<int> IDs = ObjBALClass.GetYearandYearValue();
                    if (IDs.Count > 0)
                    {
                        ObjBALClass.ObjDebtAdjustObject.Year = IDs[0];
                        ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = IDs[1];
                    }
                    //else
                    //{
                    //    GeneralFunction.Information("Recordnotfound", "DebtAdjustment");
                    //}
                    ObjBALClass.ObjDebtAdjustObject.AgentId = 0;
                    ObjBALClass.ObjDebtAdjustObject.Description = string.Empty;
                    ObjBALClass.ObjDebtAdjustObject.Balance = ObjBALClass.ObjDebtAdjustObject.Receivable = ObjBALClass.ObjDebtAdjustObject.Payable = 0.000;
                    ObjBALClass.ObjDebtAdjustObject.Status = 3;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                tempRecord = null;
            }

        }

        internal void CreateEmptyRecord()
        {
            List<long> ID = new List<long>();
            ID = ObjBALClass.GetDebtKeySequenceID();
            ObjBALClass.ObjDebtAdjustObject.ReceiptID = Convert.ToInt32(ID[0]);
            MaxID = ObjBALClass.ObjDebtAdjustObject.ReceiptID;
            ObjBALClass.ObjDebtAdjustObject.Year = Convert.ToInt32(ID[1]);
            ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = Convert.ToInt32(ID[2]);
            ObjBALClass.ObjDebtAdjustObject.AgentId = 0;
            ObjBALClass.ObjDebtAdjustObject.Description = string.Empty;
            ObjBALClass.ObjDebtAdjustObject.ReceiptDate = DateTime.Now;
            ObjBALClass.ObjDebtAdjustObject.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjDebtAdjustObject.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjDebtAdjustObject.Status = 1;
            ObjBALClass.ObjDebtAdjustObject.Balance = 0;
            ObjBALClass.ObjDebtAdjustObject.PayFlag = Convert.ToInt32(PayReceiptFor.Debt);
            ObjBALClass.DebtSavePayable();
            ObjBALClass.DebtSaveReceivable();
        }

        //public void LoadEvent()
        //{ dtAgentNameID = objDebtBALClass.GetAgentNameandID(); }

        public void LoadMaxMinNumber()
        {
            List<int> ID = objDebtBALClass.GetMinMaxID();

            MinID = ID[0];
            MaxID = ID[1];
            CurrentYear = ID[2];

        }

        public bool Save()
        {
            bool saved = false;
            if (Validation())
            {
                objDebtBALClass.ObjDebtAdjustObject.CreatedBy = GeneralFunction.UserId;
                objDebtBALClass.ObjDebtAdjustObject.ModifiedBy = GeneralFunction.UserId;
                objDebtBALClass.ObjDebtAdjustObject.Status = 1;
                ObjBALClass.ObjDebtAdjustObject.PayFlag = Convert.ToInt32(PayReceiptFor.Debt);
                if (objDebtBALClass.ObjDebtAdjustObject.Payable > 0)
                {
                    if (objDebtBALClass.DebtSavePayable())
                    {
                        saved = true;
                        CreateEmptyRecord();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString(), "PAYMENT", "Save payable debt adjustment details", Convert.ToInt32(InvoiceAction.No));
                    }
                }
                else
                {
                    if (objDebtBALClass.DebtSaveReceivable())
                    {
                        saved = true;
                        CreateEmptyRecord();
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString(), "CUSTOMER_RECEIPT", "save receivable debt adjustment details", Convert.ToInt32(InvoiceAction.No));
                    }
                }
                if (saved)
                {
                    //New();
                    GeneralFunction.Information("SaveDebtAdj", "DebtAdjustment");
                    return true;
                }
                else
                {
                    GeneralFunction.Information("DetailsNotSaved", "DebtAdjustment");
                    return false;
                }
            }
            else
                return false;
        }

        public void New()
        { objDebtBALClass.ObjDebtAdjustObject = new AgentDetailObjectClass(); }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            bool Deleted = false;
            if ((GeneralFunction.Question("AlertDeleteReceipt", "DebtAdjustment")) == DialogResult.Yes)
            {
                if ((objDebtBALClass.ObjDebtAdjustObject.ReceiptID != MaxID) && (objDebtBALClass.ObjDebtAdjustObject.DebtStatus != GeneralFunction.ChangeLanguageforCustomMsg("New")) && (objDebtBALClass.ObjDebtAdjustObject.DebtStatus != GeneralFunction.ChangeLanguageforCustomMsg("Delete")))
                {
                    if (Validation())
                    {
                        ObjBALClass.ObjDebtAdjustObject.Status = 0;
                        ObjBALClass.ObjDebtAdjustObject.ModifiedBy = GeneralFunction.UserId;
                        if (objDebtBALClass.ObjDebtAdjustObject.Payable > 0)
                        {
                            //ObjBALClass.ObjDebtAdjustObject.PayFlag = 0;
                            ObjBALClass.ObjDebtAdjustObject.PayType = "0";
                            if (objDebtBALClass.DeleteDebtRecord())
                            {
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString(), "PAYMENT", "Save payable debt adjustment details", Convert.ToInt32(InvoiceAction.No));
                                Deleted = true;
                            }
                        }
                        else
                        {
                            //ObjBALClass.ObjDebtAdjustObject.PayFlag = 1;
                            ObjBALClass.ObjDebtAdjustObject.PayType = "1";
                            if (objDebtBALClass.DeleteDebtRecord())
                            {
                                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString(), "CUSTOMER_RECEIPT", "Save receivable debt adjustment details", Convert.ToInt32(InvoiceAction.No));
                                Deleted = true;
                            }
                        }
                        if (Deleted)
                        {
                            New();
                            BindMaxIdToControls();
                            GeneralFunction.Information("DeleteDebtAdj", "DebtAdjustment");
                            return true;
                        }
                        else
                        {
                            GeneralFunction.Information("DeleteDebtAdj", "DebtAdjustment");
                            return false;
                        }
                    }
                }
                else
                {
                    GeneralFunction.Warning("Selectaitemtobedeleted", "DebtAdjustment");
                    return false;
                }
            }
            return true;
        }

        public bool RightNavigation()
        {
            if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID != 0)
            {
                if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID == MaxID)
                {
                    objDebtBALClass.ObjDebtAdjustObject.ReceiptID = MaxID;
                    BindMaxIdToControls();
                }
                else
                {
                    objDebtBALClass.ObjDebtAdjustObject.ReceiptID = objDebtBALClass.ObjDebtAdjustObject.ReceiptID + 1;
                    ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = ObjBALClass.ObjDebtAdjustObject.YearSequenceNo + 1;
                }
                GetDebtRecordByInvoice();
                return true;
            }
            return false;
        }

        public void LeftNavigation()
        {
            if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID != 0)
            {
                if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID == MinID)
                {
                    objDebtBALClass.ObjDebtAdjustObject.ReceiptID = MinID;
                }
                else
                {
                    objDebtBALClass.ObjDebtAdjustObject.ReceiptID = objDebtBALClass.ObjDebtAdjustObject.ReceiptID - 1;
                    ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = ObjBALClass.ObjDebtAdjustObject.YearSequenceNo - 1;
                }
                GetDebtRecordByInvoice();
            }

        }

        public string TextChanged()
        {
            List<AgentDetailObjectClass> Details;
            try
            {
                if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID.ToString() != string.Empty)
                {
                    Details = objDebtBALClass.GetDetailsByID();
                    if (Details.Count > 0)
                    {

                        foreach (var detail in Details)
                        {
                            objDebtBALClass.ObjDebtAdjustObject.AgentId = detail.AgentId;
                            string Flag = detail.PayType;
                            if (Flag == "PAY")
                            {
                                objDebtBALClass.ObjDebtAdjustObject.Payable = detail.Amount;
                                objDebtBALClass.ObjDebtAdjustObject.Receivable = 0.000;
                            }
                            else
                            {
                                objDebtBALClass.ObjDebtAdjustObject.Receivable = detail.Amount;
                                objDebtBALClass.ObjDebtAdjustObject.Payable = 0.000;
                            }

                            objDebtBALClass.ObjDebtAdjustObject.ReceiptDate = detail.ReceiptDate;
                            objDebtBALClass.ObjDebtAdjustObject.Description = detail.Description;
                            objDebtBALClass.ObjDebtAdjustObject.Status = detail.Status;
                        }
                        if (objDebtBALClass.ObjDebtAdjustObject.Status == 1)
                        {
                            return GeneralFunction.ChangeLanguageforCustomMsg("Saved");
                        }
                        else
                        {
                            return GeneralFunction.ChangeLanguageforCustomMsg("Deleted");
                        }
                    }
                    else
                    {
                        return GeneralFunction.ChangeLanguageforCustomMsg("New");
                    }
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Details = null;
            }
        }

        public bool Validation()
        {
            if (objDebtBALClass.ObjDebtAdjustObject.ReceiptID == 0)
            {
                GeneralFunction.Information("EmptyReceiptNo", "DebtAdjustment");
                return false;
            }
            if (objDebtBALClass.ObjDebtAdjustObject.AgentId == 0)
            {
                GeneralFunction.Information("EmptyAgentName", "DebtAdjustment");
                str = "cmbAgentName";
                return false;
            }

            if ((objDebtBALClass.ObjDebtAdjustObject.Payable == 0.000 && objDebtBALClass.ObjDebtAdjustObject.Receivable == 0.000))
            {
                GeneralFunction.Information("EnterPayaleReceivable", "DebtAdjustment");
                str = "txtPayable";
                return false;
            }

            if (objDebtBALClass.ObjDebtAdjustObject.Description == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", "DebtAdjustment");
                str = "txtDescription";
                return false;
            }

            if ((objDebtBALClass.ObjDebtAdjustObject.Payable > 0) && (objDebtBALClass.ObjDebtAdjustObject.Receivable > 0))
            {
                GeneralFunction.Information("SaveanyonePayableReceivable", "DebtAdjustment");
                str = "txtReceivable";
                return false;
            }
            return true;
        }

        public void Get_AgentBalance()
        {
            try
            {
                ////GeneralFunction.AgentID.Clear();
                ////GeneralFunction.AgentID.Add(ObjBALClass.ObjDebtAdjustObject.AgentId);
                ////GeneralFunction.AgentDept();
                decRec = 0;
                decAmt = 0;
                decTotal = 0;
                Balance = 0.0m;
                DataTable dtAdd;
                DataTable dtBalance = new DataTable();
                DataSet dsBalance = new DataSet();
                //dsBalance =
                ObjBALClass.ObjDebtAdjustObject.FromDate = DateTime.Now;
                ObjBALClass.ObjDebtAdjustObject.ToDate = DateTime.Now;
                ObjBALClass.ObjDebtAdjustObject.Status = 1;
                dtBalance = ObjBALClass.DebtBalanceSheet();
                if (dtBalance.Rows.Count > 0)
                {
                    dtAdd = new DataTable();
                    if (dtAdd.Columns.Count < 6)
                    {
                        dtAdd.Columns.Add("Date");
                        dtAdd.Columns.Add("Account");
                        dtAdd.Columns.Add("Discription");
                        dtAdd.Columns.Add("Receivable");
                        dtAdd.Columns.Add("Payable");
                        dtAdd.Columns.Add("Balance");
                    }
                    for (int i = 0; i < dtBalance.Rows.Count; i++)
                    {
                        DataRow drAdd;
                        drAdd = dtAdd.NewRow();
                        drAdd["Date"] = dtBalance.Rows[i]["PurchaseDate"].ToString();
                        drAdd["Account"] = "1";
                        drAdd["Discription"] = dtBalance.Rows[i]["Description"].ToString();
                        drAdd["Receivable"] = Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"].ToString()).ToString("0.000");
                        drAdd["Payable"] = Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"].ToString()).ToString("0.000");

                        decAmt = decAmt + Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]);
                        decRec = decRec + Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]);
                        decDiscount = decDiscount + Convert.ToDecimal(dtBalance.Rows[i]["Discount"]);

                        if (dtBalance.Rows[i]["AmtReceived"].ToString() == "0.0000")
                        {
                            decTotal = decTotal + (Convert.ToDecimal(dtBalance.Rows[i]["NetAmount"]));
                            drAdd["Balance"] = decTotal;
                        }
                        else
                        {
                            decTotal = decTotal - (Convert.ToDecimal(dtBalance.Rows[i]["AmtReceived"]));
                            drAdd["Balance"] = decTotal;
                        }

                        if (drAdd["Balance"].ToString().IndexOf("-") >= 0)
                        {
                            drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"].ToString().Remove(0, 1)).ToString("0.000");
                        }
                        else { drAdd["Balance"] = Convert.ToDecimal(drAdd["Balance"]).ToString("0.000"); }

                        dtAdd.Rows.Add(drAdd);

                    }

                    Balance = (decRec - decAmt);
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public void LoadEvent()
        {
            // throw new NotImplementedException();
        }

        internal void GetRecordBasedonReceipt(string txtNewYearNo)
        {
            if (txtNewYearNo.Contains("-"))
            {
                string[] str = txtNewYearNo.Split('-');
                ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = Convert.ToInt32(str[0]);
                ObjBALClass.ObjDebtAdjustObject.Year = Convert.ToInt32(str[1]);
            }
            else
                ObjBALClass.ObjDebtAdjustObject.YearSequenceNo = Convert.ToInt32(txtNewYearNo);
            int ID = Convert.ToInt32(ObjBALClass.GetReceiptIDBasedonyearvalue());
            if (ID != 0 && ID != null)
            {
                ObjBALClass.ObjDebtAdjustObject.ReceiptID = ID;
                GetDebtRecordByInvoice();
            }
            else
                GeneralFunction.ErrInfo("Enter a Valid ReceiptID", GeneralFunction.ChangeLanguageforCustomMsg("DebtAdjustment"));
        }

        internal void btnPrint()
        {
            Rpt_DebtAdjustmentList report = new Rpt_DebtAdjustmentList();
            ReportsView frmView = new ReportsView();
            //ReportDocument rptdoc = new ReportDocument();
            DataTable dt = new DataTable("DebtAdjustment");
            if (str == GeneralFunction.ChangeLanguageforCustomMsg("New"))
                ObjBALClass.ObjDebtAdjustObject.ReceiptID = 0;
            dt = ObjBALClass.GetDebtAdjustReport();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("DebtAdjustmentList");
            if (dt.Rows.Count <= 0)
            {
                GeneralFunction.Information("NoRecordsFound", "Debt Adjustment");
                return;
            }
            //rptdoc = report;
            frmView.RptDoc = report;
            // frmView.Repnum = rptdoc.Database.Tables;
            frmView.HTable.Add("Agent_Name", ObjBALClass.ObjDebtAdjustObject.Name);
            frmView.Report_Table = dt;
            frmView.LoadEvent();
            frmView.ShowDialog();
        }
    }
}

