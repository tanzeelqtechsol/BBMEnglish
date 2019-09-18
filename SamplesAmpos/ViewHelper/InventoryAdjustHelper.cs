using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using BumedianBM.ArabicView;
using CommonHelper;
using System.Windows.Forms;
using System.Xml.Linq;
using BumedianBM.CrystalReports;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace BumedianBM.ViewHelper
{
    public class InventoryAdjustHelper
    {
        public InventoryAdjustBALClass ObjInventAdjBALClass;
        List<InventAdjustObjectClass> objInventAdjlistHelp = new List<InventAdjustObjectClass>();
        // List<InventAdjustObjectClass> objInventAdjDetailsHelp = new List<InventAdjustObjectClass>();
        Dictionary<string, List<InventAdjustObjectClass>> InvAdjDictBal = new Dictionary<string, List<InventAdjustObjectClass>>();
        internal Item_Information ObjItemInfo;
        internal Boolean OnlyCostAdjust = false;
        public InventoryAdjustHelper()
        {
            ObjItemInfo = new Item_Information();
            ObjInventAdjBALClass = new InventoryAdjustBALClass();
            ObjInventAdjBALClass.SetCommonObject();
        }
        public InventoryAdjustBALClass ObjInventAdjBAL
        {
            get { return ObjInventAdjBALClass; }
            set { ObjInventAdjBALClass = value; }
        }
        public List<InventAdjustObjectClass> InventoryAdjustmentload()
        {
            decimal beforeTotal = 0, AfterTotal = 0;
            objInventAdjlistHelp = ObjInventAdjBAL.InventoryAdjustmentload().Where(i => i.IsHide == 0).ToList();
            ObjInventAdjBAL.ObjInvAdjObject.BeforeTotalValue = objInventAdjlistHelp.Sum(x => x.BeforeAdjust).ToString("######0.000");
            ObjInventAdjBAL.ObjInvAdjObject.AfterTotalValue = objInventAdjlistHelp.Sum(x => x.BeforeAdjust).ToString("######0.000");
            ObjInventAdjBAL.ObjInvAdjObject.AdjustDifference = (AfterTotal - beforeTotal).ToString("######0.000");
            return objInventAdjlistHelp;
        }
        public List<InventAdjustObjectClass> InventoryAdjustment_InvoiceNo()
        {
            decimal beforeTotal = 0, AfterTotal = 0, TotalDiffer = 0;
            objInventAdjlistHelp = ObjInventAdjBAL.InventAdjust_InvoiceNoBAL();

            ObjInventAdjBAL.ObjInvAdjObject.BeforeTotalValue = objInventAdjlistHelp.Sum(x => x.Original).ToString("######0.000");
            ObjInventAdjBAL.ObjInvAdjObject.AfterTotalValue = objInventAdjlistHelp.Sum(x => x.AfterAdjValue).ToString("######0.000");
            //  ObjInventAdjBAL.ObjInvAdjObject.AfterTotalValue = objInventAdjlistHelp.Sum(x => x.AdjustDiffer).ToString("######0.000");
            beforeTotal = objInventAdjlistHelp.Sum(x => x.Original);
            AfterTotal = objInventAdjlistHelp.Sum(x => x.AfterAdjValue);
            //           TotalDiffer=AfterTotal
            ObjInventAdjBAL.ObjInvAdjObject.AdjustDifference = (AfterTotal - beforeTotal).ToString("######0.000");

            return objInventAdjlistHelp;
        }

        public bool UpdateInventoryAdjustmentDetails(List<InventAdjustObjectClass> objInventAdjDetailsHelp)
        {
            int gg = 0; bool res = false;
            if (objInventAdjDetailsHelp != null)
            {
                var index = objInventAdjDetailsHelp.FindAll(x => x.Edit == "1");
                for (int i = 0; i < index.Count; i++)
                {
                    ObjInventAdjBAL.ObjInvAdjObject.ItemName = index[i].ItemName;
                    if (index[i].ItemName == null)
                    {
                        //ObjInventAdjBAL.ObjInvAdjObject.ExpiryDate = Convert.ToDateTime("01/01/1900");//Commented on 2-June-14 for Date Format Issues
                        ObjInventAdjBAL.ObjInvAdjObject.ExpiryDate = null;
                    }
                    else
                    {
                        if (index[i].ExpiryDate != DateTime.MinValue)
                        {
                            if (Convert.ToDateTime(index[i].StrExpiryDate).Date == index[i].ExpiryDate)
                            {
                                ObjInventAdjBAL.ObjInvAdjObject.ExpiryDate = index[i].ExpiryDate;
                            }
                            else
                                ObjInventAdjBAL.ObjInvAdjObject.ExpiryDate = Convert.ToDateTime(index[i].StrExpiryDate).Date;

                        }
                        else
                        {

                            ObjInventAdjBAL.ObjInvAdjObject.ExpiryDate = null;
                        }
                        ObjInventAdjBAL.ObjInvAdjObject.ItemId = index[i].ItemId;

                        ObjInventAdjBAL.ObjInvAdjObject.Cost = Convert.ToDecimal(index[i].Cost);
                        ObjInventAdjBAL.ObjInvAdjObject.Quantity = index[i].StockInHand;
                        ObjInventAdjBAL.ObjInvAdjObject.TotalPurchased = index[i].TotalPurchased;
                        ObjInventAdjBAL.ObjInvAdjObject.TotalSold = index[i].TotalSold;
                        ObjInventAdjBAL.ObjInvAdjObject.Spoiled = index[i].Spoiled;
                        //if (OnlyCostAdjust)
                        //{
                        ObjInventAdjBAL.ObjInvAdjObject.Adjustment = Convert.ToInt32(index[i].Quantity.ToString().Replace(".000", ""));
                        //}
                        //else
                        //{
                        //    ObjInventAdjBAL.ObjInvAdjObject.Adjustment = Convert.ToInt32(index[i].Quantity.ToString().Replace(".000", ""));
                        //}
                        ObjInventAdjBAL.ObjInvAdjObject.Reason = index[i].Reason;
                        // ObjInventAdjBAL.ObjInvAdjObject.Description = index[i].Description;
                        ObjInventAdjBAL.ObjInvAdjObject.Users = index[i].Users;
                        ObjInventAdjBAL.ObjInvAdjObject.CreatedDate = DateTime.Now;
                        //ObjInventAdjBAL.ObjInvAdjObject = index[i].Description;
                        ObjInventAdjBAL.ObjInvAdjObject.Users = index[i].Users;
                        ObjInventAdjBAL.ObjInvAdjObject.CreatedBY = GeneralFunction.UserId;
                        ObjInventAdjBAL.ObjInvAdjObject.OldCost = index[i].OldCost;
                        //   ObjInventAdjBAL.ObjInvAdjObject.TblID = 1;
                        ObjInventAdjBAL.ObjInvAdjObject.SerialNo = index[i].SerialNo;
                        ObjInventAdjBAL.ObjInvAdjObject.GridID = index[i].GridID;
                        ObjInventAdjBAL.ObjInvAdjObject.Edit = index[i].Edit;
                        //  if (dtupdated.Rows[k]["Edit"].ToString() == "1")
                        // { GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Update, "Adjust inventory" + " " + Obj_InvenProp.ItemName, "MTB_STOCK_ADJUST", "Update inventory adjust details"); }
                        //   Obj_InvenProp.UserS = NYMaxNO;
                        XElement xml = new XElement("NewDataSet",
                                   from p in objInventAdjDetailsHelp
                                   select new XElement("AllItemInfo",
                                       new XElement("ItemId", p.ItemId),
                                               new XElement("ItemName", p.ItemName),
                                               new XElement("Quantity", p.Quantity),
                                               new XElement("Cost", p.Cost),
                                               new XElement("CurrentQty", p.StockInHand),
                                               new XElement("OldCost", p.OldCost),
                                               new XElement("TotalPurchased", p.TotalPurchased),
                                               new XElement("TotalSold", p.TotalSold),
                                               new XElement("Spoiled", p.Spoiled),
                                               new XElement("SerialNo", p.SerialNo),
                                               new XElement("ID", p.GridID),
                                               new XElement("ExpiryDate", p.ExpiryDate),
                                               new XElement("Reason", p.Reason)
                                              ));
                        string TextInventoryAdjustment = xml.ToString();
                        ObjInventAdjBAL.ObjInvAdjObject.TextInventory = TextInventoryAdjustment;
                        if (ObjInventAdjBAL.UpdateInventoryAdjustmentDetailsHelp())
                        {
                            gg += 1;
                        }
                    }
                    if (gg == index.Count)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }

        public bool DescriptionValidation()
        {
            if (ObjInventAdjBAL.ObjInvAdjObject.Description == string.Empty)
            {
                GeneralFunction.Information("EmptyDescription", "InventoryAdjustment");
                return false;
            }
            return true;
        }

        public DataTable GetAllItems(int catID,int comID)
        {
            return ObjInventAdjBAL.GetAllitem(catID, comID);
        }
        #region GetCurrentYear
        public List<long> GetCurrentYear()
        {
            //List<long> currYear = ObjInventAdjBAL.GetMaxMinInvoiceID();
            //return currYear;
            return ObjInventAdjBAL.GetMaxMinInvoiceID();
        }

        #endregion
        #region GetCurrentYear
        public int GetInvoiveNewYearNoHelp()
        {
            //int NewYearNo = ObjInventAdjBAL.GetInvoiveNewYearNoBal();
            //return NewYearNo;

            return ObjInventAdjBAL.GetInvoiveNewYearNoBal();
        }

        #endregion
        #region
        public void Generate_Zakat()
        {
            Rpt_ZakatCalculationReport summery = new Rpt_ZakatCalculationReport();
            ReportsView RptView = new ReportsView();
            RptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("Zakat");
            DataSet ds = new DataSet();
            DataTable dtZakat = new DataTable("Zakat");

            ds = ObjInventAdjBAL.PayableReceivable();

            //if(ds)
            dtZakat = ds.Tables[0];
            float payable = 0;
            float receivable = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {
                float pa = 0.0f;
                float re = 0.0f;
                float paid = 0.0f;
                float rec = 0.0f;
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    if (float.Parse(ds.Tables[1].Rows[i]["Payable"].ToString()) > float.Parse(ds.Tables[1].Rows[i]["Receivable"].ToString()))
                    {
                        receivable += float.Parse(ds.Tables[1].Rows[i]["Payable"].ToString()) - float.Parse(ds.Tables[1].Rows[i]["Receivable"].ToString());
                    }
                    else
                    {
                        payable += float.Parse(ds.Tables[1].Rows[i]["Receivable"].ToString()) - float.Parse(ds.Tables[1].Rows[i]["Payable"].ToString());
                    }
                    //pa = pa + float.Parse(ds.Tables[1].Rows[i]["payable"].ToString());Changed On 03\04\2015
                    //re = re + float.Parse(ds.Tables[1].Rows[i]["receivable"].ToString());
                    //paid = paid + float.Parse(ds.Tables[1].Rows[i]["paid"].ToString());
                    //rec = rec + float.Parse(ds.Tables[1].Rows[i]["received"].ToString());
                }
               // payable = pa - paid;
               // receivable = re - rec;s

            }
            ds.Tables.Remove("Table");
            dtZakat.TableName = "Zakat";
            RptView.HTable.Clear();
            RptView.HTable.Add("Tot_Receivable", receivable);
            RptView.HTable.Add("Tot_Payable", payable);
            if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
            {
                RptView.HTable.Add("monthformat", 0);
                RptView.HTable.Add("dayformat", 0);
                RptView.HTable.Add("yearformat", 0);
                RptView.HTable.Add("seperatorformat", "/");
                RptView.HTable.Add("dateformat", 0);
            }
            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
            {
                RptView.HTable.Add("monthformat", 1);
                RptView.HTable.Add("dayformat", 1);
                RptView.HTable.Add("yearformat", 1);
                RptView.HTable.Add("seperatorformat", "/");
                RptView.HTable.Add("dateformat", 1);
            }
            else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
            {
                RptView.HTable.Add("monthformat", 1);
                RptView.HTable.Add("dayformat", 1);
                RptView.HTable.Add("yearformat", 1);
                RptView.HTable.Add("seperatorformat", "-");
                RptView.HTable.Add("dateformat", 0);
            }
            else
            {
                RptView.HTable.Add("monthformat", 1);
                RptView.HTable.Add("dayformat", 1);
                RptView.HTable.Add("yearformat", 1);
                RptView.HTable.Add("seperatorformat", "/");
                RptView.HTable.Add("dateformat", 0);
            }
            RptView.RptDoc = summery;
            RptView.IsReportFooter = false;
            ReportDocument Rpt = summery;
            Tables Tbl = Rpt.Database.Tables;
            RptView.Repnum = Tbl;
            RptView.Report_Table = dtZakat;
            RptView.LoadEvent();
            RptView.ShowDialog();
        }
        #endregion
    }
}
