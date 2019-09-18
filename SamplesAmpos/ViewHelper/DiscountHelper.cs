using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using BALHelper;
using DataBaseHelper;
using CommonHelper;
using System.Data;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using BumedianBM.CrystalReports;

namespace BumedianBM.ViewHelper
{
    public class DiscountHelper
    {
        DiscountBALClass objbalclass;
        internal bool isProgressStatus = false;
        internal List<DiscountObjectClass> DiscountList = new List<DiscountObjectClass>();
        internal DataTable DiscountedItem = new DataTable();
        DataTable Redtab = new DataTable("DiscountAppliedItems");
        DataTable dt = new DataTable();
        public DiscountHelper()
        {
            objbalclass = new DiscountBALClass();
        }
        public DiscountBALClass ObjBALClass
        {
            get { return objbalclass; }
            set { objbalclass = value; }
        }

        internal void btnApplyDiscount()
        {
            if (Validation())
            {
                ObjBALClass.ObjDiscount.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjDiscount.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjDiscount.IncreaseType = GetIncreaseType();
                if (ObjBALClass.ObjDiscount.Discount1.ToString() != string.Empty && decimal.Parse(ObjBALClass.ObjDiscount.Discount1) > 0)
                {
                    if (ObjBALClass.ObjDiscount.HasIncrease)
                    {
                        ObjBALClass.ObjDiscount.DiscountName = GeneralFunction.Language == "English" ? "Increase" : "زيادة";
                    }
                    else
                    {
                        ObjBALClass.ObjDiscount.DiscountName = GeneralFunction.Language == "English" ? "Discount": "تخفيض";
                    }
                    ObjBALClass.ObjDiscount.StartDate = ObjBALClass.ObjDiscount.StartDate1;
                    ObjBALClass.ObjDiscount.EndDate = ObjBALClass.ObjDiscount.EndDate1;
                    ObjBALClass.ObjDiscount.Discount = decimal.Parse(ObjBALClass.ObjDiscount.Discount1);
                    ObjBALClass.ObjDiscount.Active = ObjBALClass.ObjDiscount.Active1;
                    if (ObjBALClass.CheckAvaiability())
                    {
                        if (ObjBALClass.SaveApplyDiscount())
                        {
                            isProgressStatus = true;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjBALClass.ObjDiscount.Discount.ToString(), "Discount", "Save discount 1 details", Convert.ToInt32(InvoiceAction.No));
                        }
                    }
                    else { GeneralFunction.Information("ConflictDate", "Discount"); }

                }
                if (ObjBALClass.ObjDiscount.Discount2.ToString() != string.Empty && decimal.Parse(ObjBALClass.ObjDiscount.Discount2) > 0)
                {

                    ObjBALClass.ObjDiscount.DiscountName = GeneralFunction.Language == "English" ? "Discount" : "تخفيض";
                    ObjBALClass.ObjDiscount.Discount = decimal.Parse(ObjBALClass.ObjDiscount.Discount2);
                    ObjBALClass.ObjDiscount.StartDate = ObjBALClass.ObjDiscount.StartDate2;
                    ObjBALClass.ObjDiscount.EndDate = ObjBALClass.ObjDiscount.EndDate2;
                    ObjBALClass.ObjDiscount.Active = ObjBALClass.ObjDiscount.Active2;
                    if (ObjBALClass.CheckAvaiability())
                    {
                        if (ObjBALClass.SaveApplyDiscount())
                        {
                            isProgressStatus = true;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjBALClass.ObjDiscount.Discount.ToString(), "Discount", "Save discount 2 details", Convert.ToInt32(InvoiceAction.No));
                        }
                    }
                    else { GeneralFunction.Information("ConflictDate", "Discount"); }

                }
                if (ObjBALClass.ObjDiscount.Discount3.ToString() != string.Empty && decimal.Parse(ObjBALClass.ObjDiscount.Discount3) > 0)
                {

                    ObjBALClass.ObjDiscount.DiscountName = GeneralFunction.Language == "English" ? "Discount" : "تخفيض";
                    ObjBALClass.ObjDiscount.Discount = decimal.Parse(ObjBALClass.ObjDiscount.Discount3);
                    ObjBALClass.ObjDiscount.StartDate = ObjBALClass.ObjDiscount.StartDate3;
                    ObjBALClass.ObjDiscount.EndDate = ObjBALClass.ObjDiscount.EndDate3;
                    ObjBALClass.ObjDiscount.Active = ObjBALClass.ObjDiscount.Active3;
                    if (ObjBALClass.CheckAvaiability())
                    {
                        if (ObjBALClass.SaveApplyDiscount())
                        {
                            isProgressStatus = true;
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjBALClass.ObjDiscount.Discount.ToString(), "Discount", "Save discount 3 details", Convert.ToInt32(InvoiceAction.No));
                        }
                    }
                    else { GeneralFunction.Information("ConflictDate", "Discount"); }

                }
                if (isProgressStatus)
                {
                    GeneralFunction.Information("SaveDiscount", "Discount");
                    ObjBALClass.ObjDiscount.DiscountFor = GetStringItemType();
                    FillData();
                }
            }

        }

        private Boolean Validation()
        {
            try
            {
                if (ObjBALClass.ObjDiscount.DiscountFor == -1)
                {
                    GeneralFunction.Information("SelectItemsType", "Discount");
                    return false;
                }
                else
                {
                    ObjBALClass.ObjDiscount.DiscountFor = GetItemType();
                }
                if ((ObjBALClass.ObjDiscount.Discount1 == string.Empty) && (ObjBALClass.ObjDiscount.Discount2 == string.Empty) && (ObjBALClass.ObjDiscount.Discount3 == string.Empty))
                {
                    GeneralFunction.Information("AtleastOneDiscount", "Discount");

                    return false;
                }
                if (ObjBALClass.ObjDiscount.Discount1 != string.Empty)
                {
                    if (decimal.Parse(ObjBALClass.ObjDiscount.Discount1) <= 0)
                    {
                        GeneralFunction.Information("Discount1", "Discount");

                        return false;
                    }
                    else if (ObjBALClass.ObjDiscount.StartDate1 > ObjBALClass.ObjDiscount.EndDate1)
                    {
                        GeneralFunction.Information("Discount1Date", "Discount");
                        return false;
                    }

                }
                if (ObjBALClass.ObjDiscount.Discount2 != string.Empty)
                {
                    if (decimal.Parse(ObjBALClass.ObjDiscount.Discount2) <= 0)
                    {
                        GeneralFunction.Information("Discount2", "Discount");
                        return false;
                    }
                    else if (ObjBALClass.ObjDiscount.StartDate2 > ObjBALClass.ObjDiscount.EndDate2)
                    {
                        GeneralFunction.Information("Discount2Date", "Discount");
                        return false;
                    }

                }
                if (ObjBALClass.ObjDiscount.Discount3 != string.Empty)
                {
                    if (decimal.Parse(ObjBALClass.ObjDiscount.Discount3) <= 0)
                    {
                        GeneralFunction.Information("Discount3", "Discount");
                        return false;
                    }
                    else if (ObjBALClass.ObjDiscount.StartDate3 > ObjBALClass.ObjDiscount.EndDate3)
                    {
                        GeneralFunction.Information("Discount3Date", "Discount");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetItemType()
        {
            try
            {
                switch (ObjBALClass.ObjDiscount.DiscountFor)
                {
                    case 0:
                        return 5;//All Items
                    case 1:
                        return 1;//"Goods";
                    case 2:
                        return 2;//MaintanceOnly
                    case 3:
                        return 4;//Meals;
                    default:
                        return 5;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetStringItemType()
        {
            switch (ObjBALClass.ObjDiscount.DiscountFor)
            {
                case 5:
                    return 0; //"All Items";
                case 1:
                    return 1;//"Goods";
                case 2:
                    return 2;//"MaintanceOnly";
                case 4:
                    return 3;//"Meals Only";
                default:
                    return 0;
            }
        }
        public int GetIncreaseType()
        {
            try
            {
                switch (ObjBALClass.ObjDiscount.IncreaseType)
                {
                    case 0:
                        return 1;//"Purchases Price";
                    case 1:
                        return 2;//"Current Price";
                    default:
                        return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public int GetStringIncreasePrice()
        //{
        //    switch (ObjBALClass.ObjDiscount.IncreaseType)
        //    {
        //        case 1:
        //            return 0; //"Purchases Price";
        //        case 2:
        //            return 1;//"Current Price";
        //        default:
        //            return 0;
        //    }
        //}

        internal void btnFindDiscount()
        {
            //ObjBALClass.ObjDiscount.DiscountFor = GetItemType();
            //ObjBALClass.ObjDiscount.CategoryID = (ObjBALClass.ObjDiscount.CategoryID == null || ObjBALClass.ObjDiscount.CategoryID == 0) ? 101 : ObjBALClass.ObjDiscount.CategoryID;
            //ObjBALClass.ObjDiscount.CompanyID = (ObjBALClass.ObjDiscount.CompanyID == null || ObjBALClass.ObjDiscount.CompanyID == 0) ? 101 : ObjBALClass.ObjDiscount.CompanyID;
            //Dictionary<DataTable, List<DiscountObjectClass>> dtlist = new Dictionary<DataTable, List<DiscountObjectClass>>();
            // dtlist = ObjBALClass.GetDiscountDetails();
            FillData();
            //foreach (var key in dtlist.Keys)
            //{
            //    DiscountedItem = key;
            //}
            //foreach (var values in dtlist.Values)
            //{
            //    DiscountList = values;
            //}
            //for (int i = 0; i < DiscountList.Count; i++)
            //{
            //    ObjBALClass.ObjDiscount.DiscountFor = DiscountList[i].DiscountFor;
            //    DiscountList[i].DiscountName=GetStringItemType();
            //}
        }
        internal void AssignDataSourceforDiscount(DataGridView dgvgrid)
        {
            dgvgrid.AutoGenerateColumns = false;
            dgvgrid.DataSource = DiscountList;
        }
        internal void AssignSourceforItem(DataGridView dgvItemGrid)
        {
            dgvItemGrid.AutoGenerateColumns = false;
            dgvItemGrid.DataSource = DiscountedItem;
            dt = DiscountedItem;
        }

        private void FillData()
        {
            Dictionary<DataTable, List<DiscountObjectClass>> dtlist;
            try
            {
                DataColumn dcBeforeDiscount = new DataColumn("beforeTotal", typeof(decimal));
                DataColumn PriceAftDis = new DataColumn("PriceAftDis", typeof(decimal));
                DataColumn dcCost = new DataColumn("TotalCost", typeof(decimal));
                dcBeforeDiscount.Expression = "Price * Quantity";
                PriceAftDis.Expression = "DiscountPrice * Quantity";
                dcCost.Expression = "ItemCost * Quantity";

                ObjBALClass.ObjDiscount.DiscountFor = GetItemType();
                //ObjBALClass.ObjDiscount.CategoryID = (ObjBALClass.ObjDiscount.CategoryID == null || ObjBALClass.ObjDiscount.CategoryID == 0) ? 101 : ObjBALClass.ObjDiscount.CategoryID; //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                //ObjBALClass.ObjDiscount.CompanyID = (ObjBALClass.ObjDiscount.CompanyID == null || ObjBALClass.ObjDiscount.CompanyID == 0) ? 101 : ObjBALClass.ObjDiscount.CompanyID; //Commented on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan

                ObjBALClass.ObjDiscount.CategoryID = (ObjBALClass.ObjDiscount.CategoryID == null || ObjBALClass.ObjDiscount.CategoryID == 0) ? Convert.ToInt16(CommonHelper.CategoryId.Value) : ObjBALClass.ObjDiscount.CategoryID; //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan
                ObjBALClass.ObjDiscount.CompanyID = (ObjBALClass.ObjDiscount.CompanyID == null || ObjBALClass.ObjDiscount.CompanyID == 0) ? Convert.ToInt16(CommonHelper.CompanyId.Value) : ObjBALClass.ObjDiscount.CompanyID; //Added on 26-June-2014 for Changing Company ID and Category ID into 1001 instead of 101 by Seenivasan

                dtlist = new Dictionary<DataTable, List<DiscountObjectClass>>();
                dtlist = ObjBALClass.GetDiscountDetails();
                foreach (var key in dtlist.Keys)
                {
                    DiscountedItem = key;
                }
                foreach (var values in dtlist.Values)
                {
                    DiscountList = values;
                }
                if (DiscountedItem != null && DiscountedItem.Rows.Count > 0)
                {
                    DiscountedItem.Columns.Add(dcBeforeDiscount);
                    DiscountedItem.Columns.Add(PriceAftDis);
                    DiscountedItem.Columns.Add(dcCost);
                    Redtab = DiscountedItem;
                    ObjBALClass.ObjDiscount.TotalAmtBfDiscount = Convert.ToDecimal(DiscountedItem.Compute("SUM(beforeTotal)", string.Empty));
                    ObjBALClass.ObjDiscount.TotalAmtAftDiscount = Convert.ToDecimal(DiscountedItem.Compute("SUM(PriceAftDis)", string.Empty));
                    object totalCost = DiscountedItem.Compute("SUM(TotalCost)", string.Empty);

                    DiscountedItem.Columns.Remove(dcBeforeDiscount);
                    DiscountedItem.Columns.Remove(PriceAftDis);
                    DiscountedItem.Columns.Remove(dcCost);

                    //dgvDiscount.DataSource = dsDiscount.Tables[0];
                    //obj_Paging.Merge(dsDiscount.Tables[1]);
                    //obj_Paging.Row_Count = 13;
                    //this.InvokeOnClick(Btn_First, EventArgs.Empty);

                    decimal Profit = decimal.Parse(ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString()) - decimal.Parse(totalCost.ToString());
                    //ObjBALClass.ObjDiscount.Profit = (Profit / ((decimal.Parse(ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString())) > 0 ? decimal.Parse(ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString()) : 1)) / 100;
                    ObjBALClass.ObjDiscount.Profit = (Profit / ((decimal.Parse(ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString())) > 0 ? decimal.Parse(ObjBALClass.ObjDiscount.TotalAmtAftDiscount.ToString()) : 1)) * 100;
                    //Txt_TotalAmtBeforeDiscount.Text = (decimal.Parse(beforeDiscount.ToString())).ToString("######0.000");
                    //Txt_TotalAmtAfterDiscount.Text = (decimal.Parse(afterDiscount.ToString())).ToString("######0.000");
                    //Txt_AverageProfit.Text = avgProfit.ToString("####0.00");

                }
                else
                {
                    // Txt_TotalAmtBeforeDiscount.Text = Txt_TotalAmtAfterDiscount.Text = Txt_AverageProfit.Text = string.Empty;
                    //DataTable dtclear = Dgv_Discount.DataSource as DataTable;
                    //DataTable dtclear1 = dgvDiscount.DataSource as DataTable;
                    if (DiscountedItem != null)
                    {
                        DiscountedItem.Rows.Clear();
                    }
                    if (DiscountList != null)
                    {
                        DiscountList.Clear();
                    }
                    //Dgv_Discount.DataSource = dtclear;
                    //dgvDiscount.DataSource = dtclear1;
                    //Lbl_PageNo.Text = "1/1";
                }
                // ClearInputs();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                dtlist = null;
            }
        }

        internal Boolean btnDelete()
        {
            if (ObjBALClass.UndoDiscount())
            {
                GeneralFunction.Information("DeleteDiscount", "Discount");
                FillData();
                return true;
            }
            else
                return false;
        }
        internal void Print()
        {

            try
            {
                DataTable discounttable = new DataTable();
                Rpt_DiscountAppliedItems summery = new Rpt_DiscountAppliedItems();
                ReportsView RptView = new ReportsView();
                RptView.Text = GeneralFunction.ChangeLanguageforCustomMsg("DiscountedItems");
                //Redtab = DiscountedItem;
                Redtab.TableName = "DiscountAppliedItems";
                DataColumn PriceAftDis = new DataColumn("PriceAfterDis", typeof(decimal));
                PriceAftDis.Expression = "DiscountPrice * Quantity";
                //summery.Refresh();
                if ((Redtab != null) && (Redtab.Rows.Count > 0))
                {
                    // Redtab.Columns.Add(PriceAftDis);
                    Redtab = GeneralFunction.SortInvoiceDetails(Redtab, "ItemName", "ItemCost");
                    discounttable = dt;
                    discounttable.TableName = "DiscountAppliedItems";
                    RptView.Report_Table = discounttable;
                    RptView.IsItemNo = true;
                    RptView.RptDoc = summery;
                    RptView.LoadEvent();
                    RptView.ShowDialog();
                    RptView.DsCompLogo.Tables.Remove(RptView.Report_Table);
                    //  Redtab.Reset();
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Discount details", "DISCOUNT", "Print discount details", Convert.ToInt32(InvoiceAction.No));
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "Discount");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, CommonHelper.GeneralFunction.UserId, "General Discount", " Print-Functionality");
            }
        }
    }
}
