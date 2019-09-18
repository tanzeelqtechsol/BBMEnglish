using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using ObjectHelper;
using BALHelper;
using System.Data;


namespace BumedianBM.ViewHelper
{
    public class QuickPriceHelper
    {
        ItemCardBALClass ObjBalClass;
        //DataSet ds = new DataSet();
        public System.Data.DataSet ds = new DataSet();
        internal Dictionary<string, List<ItemCardObjectClass>> dictItemLoad = new Dictionary<string, List<ItemCardObjectClass>>();
      //  DataTable dt1 = new DataTable();
        //    DataTable dt2=new DataTable();
        public QuickPriceHelper()
        {
            NewObject();


        }
        public ItemCardBALClass BalClass
        {
            get { return ObjBalClass; }
            set { ObjBalClass = value; }
        }

        public void LoadData()
        {

          //  dictItemLoad = ObjBalClass.GetLoadItem();
            //dictItemLoad = ObjBalClass.GetLoadData();Commented By meena.R on 12/01/2015 for barcode scanning

        }
        //public void itemnamechange()
        //{
        //    try
        //    {
        //        if (ObjBalClass.Objitemcardobjectclass.Items != string.Empty && BalClass.Objitemcardobjectclass.ItemId != 0)
        //        {
        //            DataTable ItemNodt = new DataTable();
        //            if (ItemNodt.Columns.Count < 5)
        //            {
        //                ItemNodt.Columns.Add("", System.Type.GetType("System.Byte[]"));
        //            }
        //            ItemNodt = ds.Tables[0];
        //            DataTable ItemCost = new DataTable();
        //            ItemCost = ObjBalClass.GetItemDetails();
        //            ObjBalClass.Objitemcardobjectclass.Items = ItemCost.Rows[0]["ItemName"].ToString();
        //            ObjBalClass.Objitemcardobjectclass.WholeSalePrice = Convert.ToDecimal(ItemCost.Rows[0]["WholeSalePrice"]);
        //            ObjBalClass.Objitemcardobjectclass.Price = Convert.ToDecimal(ItemCost.Rows[0]["Price"]);
        //            ObjBalClass.Objitemcardobjectclass.ExpiryDate = Convert.ToBoolean(ItemCost.Rows[0]["ExpiryDate"]);
        //            if (Convert.ToInt32(ObjBalClass.Objitemcardobjectclass.ExpiryDate) == 1)
        //            {
        //                ObjBalClass.Objitemcardobjectclass.ItemExpiry = Convert.ToDateTime(ItemCost.Rows[0]["ExpiryDate1"]==DBNull.Value?null:ItemCost.Rows[0]["ExpiryDate1"].ToString());
        //            }



        //            if (ItemCost.Rows.Count > 0)
        //            {

        //                ObjBalClass.Objitemcardobjectclass.ItemCost = Convert.ToDecimal(ItemCost.Rows[0]["ItemCost"]);
        //                ObjBalClass.Objitemcardobjectclass.PackageQuantity = int.Parse(ItemCost.Rows[0]["PackageQty"].ToString());

        //                if (int.Parse(ItemCost.Rows[0]["StockInHand"].ToString()) > 0)
        //                    ObjBalClass.Objitemcardobjectclass.StockInHand = int.Parse(ItemCost.Rows[0]["StockInHand"].ToString());
        //                else
        //                    ObjBalClass.Objitemcardobjectclass.StockInHand = 0;
        //            }

        //        }





        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        internal void NewObject()
        { ObjBalClass = new ItemCardBALClass(); }
        public void itemnamechange()
        {
            try
            {
                if (BalClass.Objitemcardobjectclass.ItemId != 0)
                {
                    DataTable ItemNodt = new DataTable();
                    if (ItemNodt.Columns.Count < 5)
                    {
                        ItemNodt.Columns.Add("", System.Type.GetType("System.Byte[]"));
                    }
                    ///ItemNodt = dictItemLoad
                    //   DataTable ItemCost = new DataTable();
                    List<ItemCardObjectClass> lstItemCost = new List<ItemCardObjectClass>();
                    lstItemCost = ObjBalClass.GetItemDetails();
                    if (lstItemCost.Count > 0)
                    {
                        ObjBalClass.Objitemcardobjectclass.Items = lstItemCost[0].Items;
                        ObjBalClass.Objitemcardobjectclass.WholeSalePrice = lstItemCost[0].WholeSalePrice;
                        ObjBalClass.Objitemcardobjectclass.Price = lstItemCost[0].Price;
                        ObjBalClass.Objitemcardobjectclass.ExpiryDate = lstItemCost[0].ExpiryDate;
                        ObjBalClass.Objitemcardobjectclass.ItemNumber = lstItemCost[0].ItemNumber;
                        ObjBalClass.Objitemcardobjectclass.ItemType = lstItemCost[0].ItemType;
                        ObjBalClass.Objitemcardobjectclass.CategoryId = lstItemCost[0].CategoryId;
                        ObjBalClass.Objitemcardobjectclass.CompId = lstItemCost[0].CompId;
                        if (ObjBalClass.Objitemcardobjectclass.ExpiryDate)
                        { ObjBalClass.Objitemcardobjectclass.ItemExpiry = lstItemCost[0].ItemExpiry == DateTime.MinValue ? null : lstItemCost[0].ItemExpiry; }

                        if (lstItemCost.Count > 0)
                        {
                            ObjBalClass.Objitemcardobjectclass.ItemCost = lstItemCost[0].ItemCost;
                            ObjBalClass.Objitemcardobjectclass.PackageQuantity = lstItemCost[0].PackageQuantity;
                            if (lstItemCost[0].StockInHand > 0)
                                ObjBalClass.Objitemcardobjectclass.StockInHand = lstItemCost[0].StockInHand;
                            else
                                ObjBalClass.Objitemcardobjectclass.StockInHand = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllItems()
        {
            DataSet ds = ObjBalClass.GetAllItemDetails();
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetAppliedIncreaseHelper()
        {
            return ObjBalClass.GetAppliedIncreaseBal();
        }


    }
}
