using System;
using System.Collections.Generic;
using System.Linq;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using BumedianBM.ArabicView;
using System.Windows.Forms;
using System.Drawing;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace BumedianBM.ViewHelper
{
    public class FindPurchaseInvoiceHelper
    {
        PurchaseBALClass objbalclass;
        internal Item_Information ObjItemInfo;

        internal List<PurchaseObjectClass> FindPurchaseList = new List<PurchaseObjectClass>();
        List<PurchaseObjectClass> FilterList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> PurchaseInvoiceDetails = new List<PurchaseObjectClass>();

        internal bool IsfromReturn = false, InvStatus = false;
        internal int CurrentYear;
        internal int InvoiceTypeIndex;
        string query = string.Empty;
        public FindPurchaseInvoiceHelper()
        {
            objbalclass = new PurchaseBALClass();
            objbalclass.SetCommonObject();
            ObjItemInfo = new Item_Information();
            GetYear();
        }

        public PurchaseBALClass ObjBALClass
        {
            get { return objbalclass; }
            set { objbalclass = value; }
        }

        private void GetYear()
        {
            List<long> ID = ObjBALClass.GetMaxMinInvoiceID();
            CurrentYear = Convert.ToInt32(ID[2]);
            ObjBALClass.ObjPurchase.Year = CurrentYear;
        }

        internal List<PurchaseObjectClass> FindPurchasList()
        {
            FilterList = ObjBALClass.FindPurchaseList();
            switch ((InvoiceType)InvoiceTypeIndex)
            {
                case InvoiceType.AllInvoices:
                    FindPurchaseList = FilterList.ToList();
                    break;

                case InvoiceType.New:
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID != 0)
                        FindPurchaseList = FilterList.Where(a => (a.Status == Convert.ToInt32(InvoiceStatus.NewInvoice)) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();///1=new invoiceno Status
                    else
                        FindPurchaseList = FilterList.Where(a => (a.Status == Convert.ToInt32(InvoiceStatus.NewInvoice))).ToList();
                    break;

                case InvoiceType.Closed:
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID == 0)
                        FindPurchaseList = FilterList.Where(a => a.Status == Convert.ToInt32(InvoiceStatus.CloseInvoice)).ToList();//2=CloseInvoice Status
                    else
                        FindPurchaseList = FilterList.Where(a => (a.Status == Convert.ToInt32(InvoiceStatus.CloseInvoice)) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
                    break;

                case InvoiceType.OrderInvoice:
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID == 0)
                        FindPurchaseList = FilterList.Where(a => a.SetStatus == Convert.ToInt32(OrderRemarks.OI)).ToList();
                    else
                        FindPurchaseList = FilterList.Where(a => (a.SetStatus == Convert.ToInt32(OrderRemarks.OI)) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
                    break;
                case InvoiceType.PurchaseInvoice:
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID != 0)
                        FindPurchaseList = FilterList.Where(a => (a.SetStatus == Convert.ToInt32(OrderRemarks.PI)) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
                    else
                        FindPurchaseList = FilterList.Where(a => (a.SetStatus == Convert.ToInt32(OrderRemarks.PI))).ToList();
                    break;

                case InvoiceType.ReturnInvoice:
                    IsfromReturn = true;
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID != 0)
                        FindPurchaseList = FilterList.Where(a => (a.SetStatus == Convert.ToInt32(OrderRemarks.RI)) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
                    else
                        FindPurchaseList = FilterList.Where(a => (a.SetStatus == Convert.ToInt32(OrderRemarks.RI))).ToList();
                    break;

                default:
                    if (ObjBALClass.ObjPurchase.NewYearInvoiceID != 0)
                        FindPurchaseList = FilterList.Where(a => (a.CreatedBy == ObjBALClass.ObjPurchase.UserId) && (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
                    else
                        FindPurchaseList = FilterList.Where(a => a.CreatedBy == ObjBALClass.ObjPurchase.UserId).ToList();
                    break;
            }
            if (FindPurchaseList.Count > 0)
            {
                CalculationForFind();
                return FindPurchaseList;
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "FindPurchaseInvoice");
                PurchaseInvoiceDetails.Clear();
                CalculationForFind();
                CalculationForItem();
                return FindPurchaseList;
            }
        }

        internal List<PurchaseObjectClass> InvoiceNoSearch()
        {
            // List<PurchaseObjectClass> list = FindPurchasList();
            FindPurchaseList = FindPurchaseList.Where(a => (a.NewYearInvoiceID == ObjBALClass.ObjPurchase.NewYearInvoiceID) && (a.Year == ObjBALClass.ObjPurchase.Year)).ToList();
            CalculationForFind();
            return FindPurchaseList;
        }

        internal void BalanceAmountofAgent()
        {
            GeneralFunction.AgentId.Clear();
            GeneralFunction.AgentId.Add(ObjBALClass.ObjPurchase.SupplierNo);
            GeneralFunction.AgentDept();
        }

        internal List<PurchaseObjectClass> GetFindItemInvoiceDetails()
        {
            switch ((OrderRemarks)ObjBALClass.ObjPurchase.SetStatus)
            {
                case OrderRemarks.OI:
                    InvStatus = true;
                    PurchaseInvoiceDetails = ObjBALClass.FindorderDetails();
                    break;
                case OrderRemarks.RI:
                    InvStatus = true;
                    PurchaseInvoiceDetails = ObjBALClass.FindReturnDetails();
                    break;
                default:
                    InvStatus = false;
                    PurchaseInvoiceDetails = ObjBALClass.FindPurchaseInvoiceDetails();
                    break;
            }
            CalculationForItem();
            return PurchaseInvoiceDetails;
        }

        //internal List<PurchaseObjectClass> GetOrderDetails()
        //{
        //    PurchaseInvoiceDetails = ObjBALClass.FindorderDetails();
        //    return PurchaseInvoiceDetails;
        //}

        //internal List<PurchaseObjectClass> GetReturnDetails()
        //{
        //    PurchaseInvoiceDetails = ObjBALClass.FindReturnDetails();
        //    return PurchaseInvoiceDetails;
        //}

        internal void GridCellDoubleClick()
        {
            switch ((OrderRemarks)ObjBALClass.ObjPurchase.SetStatus)
            {
                case OrderRemarks.PI:
                    if (UserScreenLimidations.PurchaseInvoice)
                    {
                        Purchase_Invoice frmPurchase = new Purchase_Invoice();
                        frmPurchase.IDFromBalanceSheet = ObjBALClass.ObjPurchase.InvoiceNo.ToString();
                        frmPurchase.ShowDialog();
                    }
                    break;
                case OrderRemarks.OI:
                    if (UserScreenLimidations.OrderInvoice)
                    {
                        Order_Invoice frmOrder = new Order_Invoice();
                        frmOrder.IDFromOthers = ObjBALClass.ObjPurchase.InvoiceNo.ToString();
                        frmOrder.ShowDialog();
                    }
                    break;
                case OrderRemarks.RI:
                    if (UserScreenLimidations.PurchaseReturnInvoice)
                    {
                        PurchaseReturnInvoice frmReturn = new PurchaseReturnInvoice();
                        frmReturn.IDFromOthers = ObjBALClass.ObjPurchase.InvoiceNo.ToString();
                        frmReturn.ShowDialog();
                    }
                    break;
            }
        }

        private void CalculationForFind()
        {
            if (FindPurchaseList.Count != 0)
            {
                decimal returnnetamount, purchasenetAmount,returnpaid,purchasepaid;
                //decimal _Total = 0, _Discount = 0, _Paid = 0;
                //for (int i = 0; i < FindPurchaseList.Count; i++)
                //{
                //    if (FindPurchaseList[i].ItemTotal!=0.0m)
                //    {
                //        _Total = _Total + Convert.ToDecimal(FindPurchaseList[i].ItemTotal);
                //        _Discount = _Discount + Convert.ToDecimal(FindPurchaseList[i].Discount);
                //        _Paid = _Paid + Convert.ToDecimal(FindPurchaseList[i].Paid);
                //    }
                //}
                //ObjBALClass.ObjPurchase.ItemTotal = _Total;
                //ObjBALClass.ObjPurchase.ItemDiscount = _Discount;
                //ObjBALClass.ObjPurchase.Paid = _Paid;
                //ObjBALClass.ObjPurchase.ItemNet = (_Total - _Discount);
                if (InvoiceTypeIndex == 0)
                {
                    returnnetamount = (FindPurchaseList.Where(a => a.SetStatus == 4).ToList()).Sum(s => s.ItemTotal);
                    purchasenetAmount = (FindPurchaseList.Where(a => a.SetStatus != 4).ToList()).Sum(s => s.ItemTotal);
                    ObjBALClass.ObjPurchase.ItemTotal = purchasenetAmount;
                    returnpaid = (FindPurchaseList.Where(a => a.SetStatus == 4).ToList()).Sum(s => s.Paid);
                    purchasepaid = (FindPurchaseList.Where(a => a.SetStatus != 4).ToList()).Sum(s => s.Paid);
                    ObjBALClass.ObjPurchase.Paid =purchasepaid;
                }
                else
                {
                    ObjBALClass.ObjPurchase.ItemTotal = FindPurchaseList.Sum(a => a.ItemTotal);
                    ObjBALClass.ObjPurchase.Paid = FindPurchaseList.Sum(a => a.Paid);
                }
                ObjBALClass.ObjPurchase.ItemDiscount = FindPurchaseList.Sum(a => a.Discount);
                ObjBALClass.ObjPurchase.ItemNet = ((Decimal.Parse(ObjBALClass.ObjPurchase.ItemTotal.ToString("#####0.000"))) - (Decimal.Parse(ObjBALClass.ObjPurchase.ItemDiscount.ToString("#####0.000"))));
                if (IsfromReturn)
                {
                    ObjBALClass.ObjPurchase.Remaining = ObjBALClass.ObjPurchase.ItemNet + ObjBALClass.ObjPurchase.Paid;
                    IsfromReturn = false;
                }
                else
                    ObjBALClass.ObjPurchase.Remaining = ObjBALClass.ObjPurchase.ItemNet - ObjBALClass.ObjPurchase.Paid;
            }
            else
            {
                ObjBALClass.ObjPurchase.ItemTotal = 0.000m;
                ObjBALClass.ObjPurchase.ItemDiscount = 0.000m;
                ObjBALClass.ObjPurchase.Paid = 0.000m;
                ObjBALClass.ObjPurchase.ItemNet = 0.000m;
                ObjBALClass.ObjPurchase.Remaining = 0.000m;
            }
        }

        private void CalculationForItem()
        {
            decimal Total = 0, Discount = 0.0m, Net = 0, Cost = 0, Sale = 0, Profit;
            if (!InvStatus)
            {
                if (PurchaseInvoiceDetails.Count > 0)
                {
                    for (int i = 0; i < PurchaseInvoiceDetails.Count; i++)
                    {
                        Total = Convert.ToDecimal(int.Parse(PurchaseInvoiceDetails[i].ItemQuantity.ToString()) / (PurchaseInvoiceDetails[i].ItemPackage == 0 ? 1 : (int.Parse(PurchaseInvoiceDetails[i].ItemPackage.ToString()))));
                        Cost = Cost + Convert.ToDecimal(decimal.Parse(PurchaseInvoiceDetails[i].ItemCost.ToString("#####0.000")) * Total);
                        Sale = Sale + Convert.ToDecimal(decimal.Parse(PurchaseInvoiceDetails[i].SalePrice.ToString("#####0.000")) * Total);
                       // Discount = Discount + PurchaseInvoiceDetails[i].Discount;//Added on 06/06/2014 Commended on 14Nov2014
                        Total = 0;
                    }
                    Discount = ObjBALClass.ObjPurchase.Discount = PurchaseInvoiceDetails[0].Discount;//Added pn 14Nov2014
                    ObjBALClass.ObjPurchase.Discount = Discount;
                    Net = Sale - (Cost - Discount);//Plus Symbol changed into - on 06/06/2014
                    //Profit = Convert.ToDecimal(Sale) - Convert.ToDecimal(Cost);commanded on 06/06/2014
                    Profit = Convert.ToDecimal(Sale) - Convert.ToDecimal(Cost - Discount);
                    ObjBALClass.ObjPurchase.ItemCost = Cost;
                    ObjBALClass.ObjPurchase.SalePrice = Sale;
                    ObjBALClass.ObjPurchase.ItemGrossAmt = Net;
                }
                else
                {
                    DefaultValues();
                }
            }
            else
            {
                DefaultValues();
                if (PurchaseInvoiceDetails.Count > 0)
                {
                    //for (int i = 0; i < PurchaseInvoiceDetails.Count; i++)
                    //{
                    //    Total = Convert.ToDecimal(int.Parse(PurchaseInvoiceDetails[i].ItemQuantity.ToString()) / int.Parse(PurchaseInvoiceDetails[i].ItemPackage.ToString()));
                    //    Cost = Cost + Convert.ToDecimal(decimal.Parse(PurchaseInvoiceDetails[i].ItemCost.ToString("#####0.000")) * Total);
                    //    Total = 0;
                    //}
                    ObjBALClass.ObjPurchase.ItemCost = PurchaseInvoiceDetails.Sum(a => a.ItemCost);
                }

            }


        }

        private void DefaultValues()
        {
            ObjBALClass.ObjPurchase.Discount = 0.000m;
            ObjBALClass.ObjPurchase.ItemCost = 0.000m;
            ObjBALClass.ObjPurchase.SalePrice = 0.000m;
            ObjBALClass.ObjPurchase.ItemGrossAmt = 0.000m;
        }

        internal void GridSource(DataGridView dgvFindInvoice)
        {
            dgvFindInvoice.AutoGenerateColumns = false;
            dgvFindInvoice.DataSource = null;
            dgvFindInvoice.Rows.Clear();
            dgvFindInvoice.DataSource = FindPurchaseList;
            for (int i = 0; i < FindPurchaseList.Count; i++)
            {
                if (FindPurchaseList[i].Status == 1)
                    dgvFindInvoice.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                else if (FindPurchaseList[i].SetStatus == Convert.ToInt32(OrderRemarks.OI))
                    dgvFindInvoice.Rows[i].DefaultCellStyle.ForeColor = Color.MediumVioletRed;
                else if (FindPurchaseList[i].SetStatus == Convert.ToInt32(OrderRemarks.RI))
                    dgvFindInvoice.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                else
                    dgvFindInvoice.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        internal void ItemGridSource(DataGridView dgvFindItem)
        {
            dgvFindItem.AutoGenerateColumns = false;
            dgvFindItem.DataSource = null;
            dgvFindItem.Rows.Clear();
            if (PurchaseInvoiceDetails.Count != 0)
            {
                dgvFindItem.DataSource = PurchaseInvoiceDetails;
                if (PurchaseInvoiceDetails[0].Status == 1)
                {
                    dgvFindItem.BackgroundColor = Color.Beige;
                    dgvFindItem.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgvFindItem.BackgroundColor = Color.Gray;
                    dgvFindItem.DefaultCellStyle.BackColor = Color.Gainsboro;
                }
            }
            else
            {
                dgvFindItem.BackgroundColor = Color.Beige;
                dgvFindItem.DefaultCellStyle.BackColor = Color.White;
                dgvFindItem.DataSource = null;
            }

        }

        internal void btnPrint()
        {
            switch ((InvoiceType)InvoiceTypeIndex)
            {
                case InvoiceType.Closed:
                    ObjBALClass.ObjPurchase.Status = 2;
                    break;
                case InvoiceType.New:
                    ObjBALClass.ObjPurchase.Status = 1;
                    break;
            }
            ReportsView Obj_viewer = new ReportsView();
            Rpt_FindPurchaseInvoice summery = new Rpt_FindPurchaseInvoice();
            Obj_viewer.HTable.Add("FromDate", ObjBALClass.ObjPurchase.FromDate == null ? DateTime.Now.Date : ObjBALClass.ObjPurchase.FromDate);
            Obj_viewer.HTable.Add("ToDate", ObjBALClass.ObjPurchase.ToDate == null ? DateTime.Now.Date : ObjBALClass.ObjPurchase.ToDate);
            Obj_viewer.HTable.Add("FromTime", ObjBALClass.ObjPurchase.FromTime == null ? DateTime.Now.ToShortTimeString() : (object)ObjBALClass.ObjPurchase.FromTime);
            Obj_viewer.HTable.Add("ToTime", ObjBALClass.ObjPurchase.ToTime == null ? DateTime.Now.ToShortTimeString() : (object)ObjBALClass.ObjPurchase.ToTime);
            if (ObjBALClass.ObjPurchase.SetStatus == 1)
            {
                Obj_viewer.HTable.Add("HideDate", true);
            }
            else
            {
                Obj_viewer.HTable.Add("HideDate", false);
            }
            DataTable dt = new DataTable("FindPurchaseInvoice");
            dt = ObjBALClass.FindReportDetails();
            if (dt != null && dt.Rows.Count > 0)
            {
                ReportDocument doc = summery;
                Obj_viewer.RptDoc = doc;
                Obj_viewer.Report_Table = dt;
                Obj_viewer.Repnum = doc.Database.Tables;
                Obj_viewer.LoadEvent();
                Obj_viewer.ShowDialog();
            }

            else { GeneralFunction.Information("NoRecordsFound", "FindPurchaseInvoice"); }
        }
        internal void DetailedPurchaseInvoice()
        {

            //if (ObjBALClass.ObjPurchase.Remarks == 2)
            //    ObjBALClass.ObjPurchase.Reason = CommonHelper.OrderRemarks.PI.ToString();
            //else if (ObjBALClass.ObjPurchase.Remarks == 4)
            //    ObjBALClass.ObjPurchase.Reason = CommonHelper.OrderRemarks.RI.ToString();
            ReportsView Obj_viewer = new ReportsView();
            Rpt_DetailPurchaseInvoice summery = new Rpt_DetailPurchaseInvoice();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("FindPurchaseInvoice");
            DataTable dt = new DataTable("DetailPurchaseInvoice");
            DataTable RoughDt = new DataTable();
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add("PurchaseInvoiceID");
                dt.Columns.Add("ItemID");
                dt.Columns.Add("AgentID");
                dt.Columns.Add("ItemDiscount");
                dt.Columns.Add("AgentName");
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("UnitPrice", typeof(decimal));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("Discount");
                dt.Columns.Add("Status");
                dt.Columns.Add("ItemName");
                dt.Columns.Add("PurchaseDate");
                dt.Columns.Add("CreatedBy");
                dt.Columns.Add("SalePrice", typeof(decimal));
                dt.Columns.Add("Cost", typeof(decimal));
                dt.Columns.Add("Flag");
                dt.Columns.Add("PackageQty", typeof(int));
            }
            RoughDt = ObjBALClass.FindPurchaseInvoice();
            query = string.Empty;
            for (int i = 0; i < FindPurchaseList.Count; i++)
            {
                //  remark = Dgv_Find_Invoice.Rows[i].Cells[11].Value.ToString();
                //strQry = (strQry != string.Empty) ? strQry + " OR " + "({View_DetailPurchaseInvoice.MTB_PURCHASE_INV_ID})='" + Dgv_Find_Invoice.Rows[i].Cells["invoiceno"].Value.ToString() + "' and {View_DetailPurchaseInvoice.FLAG}='" + remark + "'" : "({View_DetailPurchaseInvoice.MTB_PURCHASE_INV_ID})='" + Dgv_Find_Invoice.Rows[i].Cells["invoiceno"].Value.ToString() + "' and {View_DetailPurchaseInvoice.FLAG}='" + remark + "'";

                if (ObjBALClass.ObjPurchase.Remarks == 2)
                    ObjBALClass.ObjPurchase.Reason = CommonHelper.OrderRemarks.PI.ToString();
                else if (ObjBALClass.ObjPurchase.Remarks == 4)
                    ObjBALClass.ObjPurchase.Reason = CommonHelper.OrderRemarks.RI.ToString();
                else if(ObjBALClass.ObjPurchase.Remarks==3)
                    ObjBALClass.ObjPurchase.Reason = CommonHelper.OrderRemarks.OI.ToString();
                query = (query == string.Empty) ? "PurchaseInvoiceID='" + FindPurchaseList[i].InvoiceNo + "' and Flag='" + ObjBALClass.ObjPurchase.Reason + "'" : query + " OR " + " PurchaseInvoiceID ='" + FindPurchaseList[i].InvoiceNo + "' and Flag ='" + ObjBALClass.ObjPurchase.Reason + "'";

            }
            DataRow[] dr;
            dr = RoughDt.Select(query);
            foreach (DataRow ddrr in dr)
            {
                dt.NewRow();
                dt.ImportRow(ddrr);
                //RoughDt.Rows.Add(dr);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                Obj_viewer.Report_Table = dt;
                Obj_viewer.RptDoc = summery;
                Obj_viewer.IsItemNo = GeneralOptionSetting.FlagHideItemNumber == "Y" ? true : false;
                Obj_viewer.LoadEvent();
                Obj_viewer.ShowDialog();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "FindPurchaseInvoice", "", "Print find purchase invoice details", Convert.ToInt32(InvoiceAction.Yes));
            }
            else { GeneralFunction.Information("NoRecordsFound", "FindPurchaseInvoice"); }
        }

    }
}
