using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using BALHelper;
using ObjectHelper;
using System.Windows.Forms;
using System.Data;
using BumedianBM.CrystalReports;
using BumedianBM.ArabicView;
using CrystalDecisions.CrystalReports.Engine;

namespace BumedianBM.ViewHelper
{
    public class ItemSerialNoHelper
    {
        PurchaseBALClass objbalClass;
        public System.Data.DataSet ds = new DataSet();
        //internal long XSerialNo;
        internal string XSerialNo;
        internal Boolean Save;
        internal bool isSaveorUpdate;

        public ItemSerialNoHelper()
        {
            objbalClass = new PurchaseBALClass();
            objbalClass.SetCommonObject();

        }

        public PurchaseBALClass ObjBALClass
        {
            get { return objbalClass; }
            set { objbalClass = value; }
        }

        ///////SerialNo
        private Boolean CheckSerialNo()
        {
            if (ObjBALClass.ObjPurchase.ItemNo.ToString() == string.Empty)
            {
                GeneralFunction.ErrInfo("EmptyItemName", "ItemSerialNo");

                return false;
            }
            if (ObjBALClass.ObjPurchase.ItemSerialNo==string.Empty)
            {
                GeneralFunction.ErrInfo("EmptySerialNumber", "ItemSerialNo");

                return false;
            }
            return true;
        }

        public List<PurchaseObjectClass> FillSerialNumber()
        {
            List<PurchaseObjectClass> ItemSerialNo = ObjBALClass.GetSerialNo();
            return ItemSerialNo;

        }

        public void SaveSerialNo()
        {
            try
            {
                if (CheckSerialNo())
                {
                    objbalClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                    objbalClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                    objbalClass.ObjPurchase.Status = 1;
                    if (!isSaveorUpdate)
                    {
                        if (ObjBALClass.SerialNoSave())
                        {
                            Save = true;
                            GeneralFunction.Information("SaveSerialNo", "ItemSerialNo"); //if((MessageBox.Show("Item Serial Number Saved Successfully", "Item Serial Number", MessageBoxButtons.OK)) == DialogResult.OK)
                            // GeneralFunction.Save_UserTrackingActions(GeneralFunction.ActionType.Save, obj_Item.Items.ToString(), "MTB_ITEM_SERIALNO", "Save item serial number details");

                        }
                        else
                            Save = false;
                    }
                    else
                    {
                        if (ObjBALClass.UpdateSerialNo(XSerialNo))
                             Save = true;
                        else
                            Save = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSerialNo()
        {
            try
            {
                List<PurchaseObjectClass> StockCount = ObjBALClass.GetStockCount();
                if (StockCount.Count > 0)
                {
                    foreach (var List in StockCount)
                    {
                        if (List.ItemStock > 0)
                        {
                            GeneralFunction.ErrInfo("CantDeleteSerialNo", "ItemSerialNo");
                            return;
                        }
                    }
                }
                ObjBALClass.ObjPurchase.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchase.Status = 1;

                if (ObjBALClass.SerialNoSave())
                {
                    Save = true;
                    GeneralFunction.Information("SerialNoDeleted", "ItemSerialNo"); // if ((MessageBox.Show("Item Serial Number Deleted Successfully", "Item Serial Number", MessageBoxButtons.OK)) == DialogResult.OK)
                    //this.Close();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void btnPrint()
        {
            ReportsView obj_viewer = new ReportsView();
            obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("ItemSerialNo");
            Rpt_ItemSerialNumber summary = new Rpt_ItemSerialNumber();
            DataTable dtLocal = new DataTable("ItemSerialNo");
            dtLocal = ObjBALClass.ItemSerialNo();
            obj_viewer.Report_Table = dtLocal;
            obj_viewer.HTable.Clear();
            obj_viewer.RptDoc = summary;
            obj_viewer.LoadEvent();
            obj_viewer.ShowDialog();
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Item Serial No", "ItemserialNo", "Print item serial number details", Convert.ToInt32(InvoiceAction.No));
        }
    }
}
