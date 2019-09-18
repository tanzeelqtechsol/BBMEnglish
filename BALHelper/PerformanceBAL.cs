using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;

namespace BALHelper
{
    public class PerformanceBAL
    {
        #region Declaration
        SaleInvoiceDALClass objSaleInvoiceDAL;
        SaleObject objSalesObject;
        #endregion

        #region Constructor
        public PerformanceBAL()
        {
            objSaleInvoiceDAL = new SaleInvoiceDALClass();
            objSalesObject = new SaleObject();
        }
        #endregion

        #region Getting Sale Object Class in BAL Class
        public SaleObject objSalObjects
        {
            get { return objSalesObject; }
            set { objSalesObject = value; }
        }
        #endregion

        #region Methods

        #region LoadClientDetailsBal
        public List<AgentDetailObjectClass> LoadClientDetailsBal()
        {
            //List<AgentDetailObjectClass> ObjListAgent = GeneralObjectClass.AgentDetails;
            List<AgentDetailObjectClass> ObjListAgent = new List<AgentDetailObjectClass>();
            //ObjListAgent = (from p in ObjListAgent
            //                where p.AgentType.Contains("101") || p.AgentType.Contains("103")
            //                orderby p.Name
            //                select p).ToList();Commended By Meena.R to the Hide agent issue  on 01/07/2014
            ObjListAgent = GeneralObjectClass.AgentDetails.Where(a =>((a.AgentType.Contains("101"))||(a.AgentType.Contains("103"))) && (!a.AgentType.Contains("104"))).ToList();
            //ObjListAgent.Add(new AgentDetailObjectClass
            //{
            //    AgentId = 1001,
            //    Name = "CASH CLIENT",
            //    AgentType = "101|0|0|0"

            //});


            return ObjListAgent;
        }
        #endregion

        #region LoadItemDetailsBal
        public List<ItemCardObjectClass> LoadItemDetailsBal()
        {
            List<ItemCardObjectClass> ObjListItem = GeneralObjectClass.ItemDetails;

            var ObjListItemOne = (from p in ObjListItem
                                  where p.ItemType == 1 //"Goods"
                                  orderby p.Items
                                  select p).ToList();

            var ObjListItemTwo = (from p in ObjListItem
                                  where p.ItemType == 2 //"SecondHand"
                                  orderby p.Items
                                  select p).ToList();

            var ObjListItemThree = (from p in ObjListItem
                                    where p.ItemType == 3 //"Labour"
                                    orderby p.Items
                                    select p).ToList();

            var ObjListItemfour = (from p in ObjListItem
                                   where p.ItemType == 4 //"Meal"
                                   orderby p.Items
                                   select p).ToList();


            var ObjListItemFive = ObjListItemOne.Union(ObjListItemTwo);
            var ObjListItemSix = ObjListItemFive.Union(ObjListItemThree);
            var ObjListItemSeven = ObjListItemSix.Union(ObjListItemfour);

            ObjListItemSeven = ObjListItemSeven.GroupBy(x => x.ItemId).Select(y => y.First());
            return ObjListItemSeven.Distinct().ToList();
            //return ObjListItemThree.ToList();
        }
        public DataTable GetItemDetails()
        {
            return StoredProcedurers.GetItemsfromSale();
        }
        #endregion

        #region GetItemInfoBal
        public List<SaleObject> GetItemInfoBal()
        {
            return objSaleInvoiceDAL.GetItemInfoForPerform(objSalesObject);
        }
        #endregion

        #region GetExpiryDatesForItemBal
        public List<SaleObject> GetExpiryDatesForItemBal()
        {
            return objSaleInvoiceDAL.GetExpiryDatesForItem(objSalesObject);
        }
        #endregion

        #region GetMaxIDAndYearSequenceBal
        public List<long> GetMaxIDAndYearSequenceBal()
        {
            return objSaleInvoiceDAL.GetMaxIDAndYearSequence();
        }
        #endregion

        #region SavePerformaInvoiceBal
        public bool SavePerformaInvoiceBal()
        {
            return objSaleInvoiceDAL.SavePerformaInvoice(objSalesObject);
        }
        #endregion

        #region GetOrderInvoiceDetailsBal
        public List<SaleObject> GetOrderInvoiceDetailsBal()
        {
            return objSaleInvoiceDAL.GetOrderInvoiceDetails(objSalesObject);
        }
        #endregion

        #region ModifyPerformInvoiceBal
        public bool ModifyPerformInvoiceBal()
        {
            return objSaleInvoiceDAL.ModifyPerformInvoice(objSalesObject);
        }
        #endregion

        #region GetMaxOrderInvNoBal
        public long GetMaxOrderInvNoBal()
        {
            return objSaleInvoiceDAL.GetMaxOrderInvNo();
        }
        #endregion

        #region GetMinMaxOrderInvNoBal
        public List<long> GetMinMaxOrderInvNoBal()
        {
            return objSaleInvoiceDAL.GetMinMaxOrderInvNo();
        }
        #endregion

        #region GetPerformaValueBal
        public List<SaleObject> GetPerformaValueBal()
        {
            return objSaleInvoiceDAL.GetPerformaValue(objSalesObject);
        }
        #endregion

        #region GetSaleIdOfOrderInvoiceBal
        public long GetSaleIdOfOrderInvoiceBal()
        {
            return objSaleInvoiceDAL.GetSaleIdOfOrderInvoice(objSalesObject);
        }
        #endregion

        #region SaveMovetoSalesBal
        public bool SaveMovetoSalesBal()
        {
            return objSaleInvoiceDAL.SaveMovetoSales(objSalesObject);
        }
        #endregion

        #region UpdatePerformaInvoiceBal
        public bool UpdatePerformaInvoiceBal()
        {
            return objSaleInvoiceDAL.UpdatePerformaInvoice(objSalesObject);
        }
        #endregion

        #region GetYearSequenceForPerformaBal
        public List<SaleObject> GetYearSequenceForPerformaBal()
        {
            return objSaleInvoiceDAL.GetYearSequenceForPerforma(objSalesObject);
        }
        #endregion

        #endregion
    }
}
