using System;
using CommonHelper;
using BALHelper;
using BumedianBM.ArabicView;
using ObjectHelper;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Collections.Generic;
using BumedianBM.CrystalReports;
using System.Configuration;
using System.Diagnostics;   

namespace BumedianBM.ViewHelper
{
    public class ItemCardHelper
    {
        #region Variable

        Dictionary<int, dynamic> dictExpiryDetails = new Dictionary<int, dynamic>();
        internal Dictionary<string, List<ItemCardObjectClass>> dictLoad = new Dictionary<string, List<ItemCardObjectClass>>();
        public DataSet Loadds = new DataSet();
        DataSet ExpiryItemDetails = new DataSet();
        DataTable inventory = new DataTable();


        #endregion

        public ItemCardBALClass ObjItemCardBALClass = new ItemCardBALClass();
        public MasterDataBALClass ObjMasterDataBALClass = new MasterDataBALClass();

        public ItemCardHelper()
        {


        }

        public string GetItemType(int indexValue)
        {
            //switch (indexValue)
            //{
            //    case 0:
            //        return "Goods";
            //    case 1:
            //        return "Second Hand";              
            //    case 2:
            //        return "Labour";
            //    case 3:
            //        return "Meal";
            //    default:
            //        return "Goods";
            //}
            switch (indexValue)
            {
                case 1:
                    return Additional_Barcode.GetValueByResourceKey("Goods");
                case 2:
                    return Additional_Barcode.GetValueByResourceKey("SecondHand");
                case 3:
                    return Additional_Barcode.GetValueByResourceKey("Labour");
                case 4:
                    return Additional_Barcode.GetValueByResourceKey("Meal");
                default:
                    return Additional_Barcode.GetValueByResourceKey("Goods");
            }
        }

        public int GetItemTypeValue(string itemType)
        {
            //switch (itemType)
            //{
            //    case "Goods":
            //        return 0;
            //    case "Second Hand":
            //        return 1;

            //    case "Labour":
            //        return 2;
            //    case "Meal":
            //        return 3;
            //    default:
            //        return 0;

            //}
            switch (itemType)
            {
                case "0":
                    return 1;
                case "1":
                    return 2;
                case "2":
                    return 3;
                case "3":
                    return 4;
                default:
                    return 1;
            }
        }



        public Boolean SaveItemCardDetail()
        {
            bool save = true;
            if (ObjectHelper.GeneralOptionSetting.FlagDontAlertOnSave != "Y" || ItemCard.IsFormClosing == true)
            {
                if (ItemCard.AdditionalBarcodeScreen == false)
                {
                    if (GeneralFunction.Question("WantSaveItem", "Item Card") == DialogResult.Yes)
                    {
                        save = true;
                    }
                    else
                    {
                        save = false;
                        ItemCard.IsItemSave = true;
                    }
                }
                else
                {

                    save = true;

                }

            }

            if (save && !Validation())
            {
                if (ObjItemCardBALClass.SaveItemCard())
                {
                    GeneralObjectClass.ItemDetails.Clear();
                    GeneralObjectClass.ItemDetails = ObjMasterDataBALClass.ItemDetailsBal();
                    if (ItemCard.AdditionalBarcodeScreen == false) { CommonHelper.GeneralFunction.Information(Constants.ITEMSAVE, ActionType.Save.ToString()); }
                    GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), ObjItemCardBALClass.Objitemcardobjectclass.Items.ToString(), "Item Card", "Save item details", Convert.ToInt32(InvoiceAction.No));
                    if (GeneralOptionSetting.FlagPriceChecker == "Y")
                        UpdatePriceCheckerDbFile();
                    return true;
                }

            }

            return false;


        }
        public void UpdatePriceCheckerDbFile()
        {
            // Set Path for Update file
            string FilePath = "";
            string AppPath = "";
            if (Environment.Is64BitOperatingSystem)
            {
                FilePath = @"C:\Program Files (x86)\Scantech ID\SG_net\demo\sg_db.txt";
                AppPath = @"C:\Program Files (x86)\Scantech ID\SG_net\demo\sg_demo.exe";
            }
            else
            {
                FilePath = @"C:\Program Files\Scantech ID\SG_net\demo\sg_db.txt";
                AppPath = @"C:\Program Files\Scantech ID\SG_net\demo\sg_demo.exe";
            }
            //

            DataTable dt = ObjItemCardBALClass.GetPriceCheckerData();

            try
            {
                // Change the Encoding to what you need here (UTF8, Unicode, etc)
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(FilePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("@# TEST DATABASE FILE for the Demo_db application of the SG_Ethernet suite." + Environment.NewLine);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        writer.WriteLine(Environment.NewLine + "@>F" + dt.Rows[i]["Barcode"] + Environment.NewLine + "name:" + dt.Rows[i]["ItemName"] + Environment.NewLine + "info:" + dt.Rows[i]["Descr"] + Environment.NewLine + "price:" + dt.Rows[i]["Price"]);
                    }
                    writer.WriteLine(Environment.NewLine + "@>unknown" + Environment.NewLine + "name:Unknown barcode" + Environment.NewLine + "info:Sorry, no information <#13>for this article." + Environment.NewLine + "price:....");
                }
                if (Process.GetProcessesByName("sg_demo").Count() > 0)
                {
                    var process = Process.GetProcessesByName("sg_demo")[0];
                    process.Kill();
                }
                Process.Start(AppPath);
            }
            catch
            {

            }
        }
        public bool GetItemDetails()
        {
            List<ItemCardObjectClass> lstItemInfo = new List<ItemCardObjectClass>();
            lstItemInfo = ObjItemCardBALClass.GetItemDetails();
            if (lstItemInfo.Count > 0)
            {
                // var v = dictItemInfo;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemId = lstItemInfo[0].ItemId;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemType = lstItemInfo[0].ItemType;
                ObjItemCardBALClass.Objitemcardobjectclass.Barcode = lstItemInfo[0].Barcode;
                ObjItemCardBALClass.Objitemcardobjectclass.IsHide = lstItemInfo[0].IsHide;
                ObjItemCardBALClass.Objitemcardobjectclass.Items = lstItemInfo[0].Items;
                ObjItemCardBALClass.Objitemcardobjectclass.CategoryId = lstItemInfo[0].CategoryId;
                ObjItemCardBALClass.Objitemcardobjectclass.CompId = lstItemInfo[0].CompId;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemCost = lstItemInfo[0].ItemCost;

                ObjItemCardBALClass.Objitemcardobjectclass.Reorder = lstItemInfo[0].Reorder;
                ObjItemCardBALClass.Objitemcardobjectclass.Maxorder = lstItemInfo[0].Maxorder;
                ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = lstItemInfo[0].PackageQuantity;
                ObjItemCardBALClass.Objitemcardobjectclass.Price = lstItemInfo[0].Price;

                ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = lstItemInfo[0].WholeSalePrice;
                ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = lstItemInfo[0].MinPrice;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemPlaceId = lstItemInfo[0].ItemPlaceId;

                ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = lstItemInfo[0].ExpiryDate;

                ObjItemCardBALClass.Objitemcardobjectclass.StockInHand = lstItemInfo[0].StockInHand;
                ObjItemCardBALClass.Objitemcardobjectclass.Image = lstItemInfo[0].Image;
                ObjItemCardBALClass.Objitemcardobjectclass.ImgPath = lstItemInfo[0].ImgPath;
                ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID = lstItemInfo[0].UnitTypesID;
                ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = lstItemInfo[0].UnitNameID;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost = lstItemInfo[0].ItemLastCost;
                ObjItemCardBALClass.Objitemcardobjectclass.AverageCost = lstItemInfo[0].AverageCost;
                ObjItemCardBALClass.Objitemcardobjectclass.ItemNumber = lstItemInfo[0].ItemNumber;
                ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId = lstItemInfo[0].BarcodeId;
                ObjItemCardBALClass.Objitemcardobjectclass.TotalStock = lstItemInfo[0].TotalStock; // Totalstock is added to display total stocks all package qty
                ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase = lstItemInfo[0].ItemLastPurchase; // Totalstock is added to display total stocks all package qty
                return true;
            }

            return false;
        }

        /// <summary>
        /// CHECK IS VALUES ARE SAME OR DIFFERENT
        /// </summary>
        public bool ChecktemDetails(string selectedindex,string txtprice,string barcode,string txtPrice,string txtPackagePcs,string cmbCategory,string cmbCompany,string cmbItemType,string txtWholeSale,string txtMinimumPrice,bool chkExpiry,bool IsHiden, string cmbItemPlace,string ItemNumber)
        {
            List<ItemCardObjectClass> lstItemInfo = new List<ItemCardObjectClass>();
            lstItemInfo = ObjItemCardBALClass.GetItemDetails();
            if (lstItemInfo.Count > 0)
            {
                decimal Price = Convert.ToDecimal(txtPrice);
                int PackagePcs = Convert.ToInt32(txtPackagePcs);
                int Category = Convert.ToInt32(cmbCategory);
                int Company = Convert.ToInt32(cmbCompany);
                int ItemType = Convert.ToInt32(cmbItemType);
                int Palace = 0;
                if (cmbItemPlace!="") {
                    Palace = Convert.ToInt32(cmbItemPlace);
                }
                decimal WholeSale = Convert.ToDecimal(txtWholeSale);
                decimal MinimumPrice = Convert.ToDecimal(txtMinimumPrice);
                bool expiry = Convert.ToBoolean(chkExpiry);

                //string cmbCompany,string cmbItemType,string txtWholeSale,string txtMinimumPrice
                if (selectedindex == lstItemInfo[0].ItemId.ToString() && barcode == lstItemInfo[0].Barcode && Price == lstItemInfo[0].Price
                    && PackagePcs == lstItemInfo[0].PackageQuantity && Category == lstItemInfo[0].CategoryId && Company == lstItemInfo[0].CompId 
                    && ItemType == lstItemInfo[0].ItemType && WholeSale == lstItemInfo[0].WholeSalePrice
                    && MinimumPrice == lstItemInfo[0].MinPrice && expiry == lstItemInfo[0].ExpiryDate && IsHiden== lstItemInfo[0].IsHide && Palace== lstItemInfo[0].ItemPlaceId && ItemNumber==lstItemInfo[0].ItemNumber)
                {
                    return true;
                }
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemId = lstItemInfo[0].ItemId;
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemType = lstItemInfo[0].ItemType;
                //ObjItemCardBALClass.Objitemcardobjectclass.Barcode = lstItemInfo[0].Barcode;
                //ObjItemCardBALClass.Objitemcardobjectclass.IsHide = lstItemInfo[0].IsHide;
                //ObjItemCardBALClass.Objitemcardobjectclass.Items = lstItemInfo[0].Items;
                //ObjItemCardBALClass.Objitemcardobjectclass.CategoryId = lstItemInfo[0].CategoryId;
                //ObjItemCardBALClass.Objitemcardobjectclass.CompId = lstItemInfo[0].CompId;
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemCost = lstItemInfo[0].ItemCost;

                //ObjItemCardBALClass.Objitemcardobjectclass.Reorder = lstItemInfo[0].Reorder;
                //ObjItemCardBALClass.Objitemcardobjectclass.Maxorder = lstItemInfo[0].Maxorder;
                //ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity = lstItemInfo[0].PackageQuantity;
                //ObjItemCardBALClass.Objitemcardobjectclass.Price = lstItemInfo[0].Price;

                //ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice = lstItemInfo[0].WholeSalePrice;
                //ObjItemCardBALClass.Objitemcardobjectclass.MinPrice = lstItemInfo[0].MinPrice;
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemPlaceId = lstItemInfo[0].ItemPlaceId;

                //ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = lstItemInfo[0].ExpiryDate;

                //ObjItemCardBALClass.Objitemcardobjectclass.StockInHand = lstItemInfo[0].StockInHand;
                //ObjItemCardBALClass.Objitemcardobjectclass.Image = lstItemInfo[0].Image;
                //ObjItemCardBALClass.Objitemcardobjectclass.ImgPath = lstItemInfo[0].ImgPath;
                //ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID = lstItemInfo[0].UnitTypesID;
                //ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID = lstItemInfo[0].UnitNameID;
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemLastCost = lstItemInfo[0].ItemLastCost;
                //ObjItemCardBALClass.Objitemcardobjectclass.AverageCost = lstItemInfo[0].AverageCost;
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemNumber = lstItemInfo[0].ItemNumber;
                //ObjItemCardBALClass.Objitemcardobjectclass.BarcodeId = lstItemInfo[0].BarcodeId;
                //ObjItemCardBALClass.Objitemcardobjectclass.TotalStock = lstItemInfo[0].TotalStock; // Totalstock is added to display total stocks all package qty
                //ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase = lstItemInfo[0].ItemLastPurchase; // Totalstock is added to display total stocks all package qty
                //return true;
            }

            return false;
        }


        public List<ItemCardObjectClass> GetExpiryItemDetails()
        {

            dictExpiryDetails = ObjItemCardBALClass.GetExpiryItemDetail();
            ProfitCalculation();

            ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase = dictExpiryDetails[1];
            ObjItemCardBALClass.Objitemcardobjectclass.ItemTotalSpoiled = dictExpiryDetails[3];//Changed to 2 to 3 on 09/10/2014
            return dictExpiryDetails[0];

        }



        //private void ExpiryItemCalculation()
        //{
        //    int packageqty;
        //    decimal price;
        //    price = ObjItemCardBALClass.Objitemcardobjectclass.Price;
        //    packageqty = ObjItemCardBALClass.Objitemcardobjectclass.PackageQuantity;
        //    decimal cost = ObjItemCardBALClass.Objitemcardobjectclass.ItemCost;
        //    decimal profitcost = (price - cost);
        //    decimal actualcost = (cost > 0) ? cost : 1;
        //    ObjItemCardBALClass.Objitemcardobjectclass.ProfitPrice = Convert.ToDecimal((profitcost / actualcost) * 100);

        //    ObjItemCardBALClass.Objitemcardobjectclass.ItemLastPurchase = ExpiryItemDetails.Tables[1].Rows.Count > 0 ? Convert.ToInt32(ExpiryItemDetails.Tables[1].Rows[0]["P_Quantity"]) : 0;
        //    ObjItemCardBALClass.Objitemcardobjectclass.ItemTotalSpoiled = ExpiryItemDetails.Tables[2].Rows.Count > 0 ? Convert.ToInt32(ExpiryItemDetails.Tables[2].Rows[0]["O_Quantity"]) : 0;



        //}

        internal void ProfitCalculation()
        {

            decimal price;
            price = ObjItemCardBALClass.Objitemcardobjectclass.Price;
            decimal cost = ObjItemCardBALClass.Objitemcardobjectclass.ItemCost;
            decimal profitcost = (price - cost);
            decimal actualcost = (cost > 0) ? cost : 1;
            ObjItemCardBALClass.Objitemcardobjectclass.ProfitPrice = Convert.ToDecimal((profitcost / actualcost) * 100);
        }

        //-------------------Commented on 15/03/2014-------------
        //-----As per the client suggestion to remove the popup messge for expiry date validation-------------------------

        //void chkExpiry_CheckedChanged(object sender, EventArgs e)
        //public Boolean CheckExpiryStatus()
        //{

        //    if (!string.IsNullOrEmpty(ObjItemCardBALClass.Objitemcardobjectclass.Items))
        //    {
        //        if (ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate)
        //        {
        //            if (GeneralFunction.Question(Constants.ALTERFOREXPIRY, ActionType.AlterForExpiry.ToString()) == DialogResult.Yes)
        //            {
        //                ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = true;
        //                return true;
        //            }
        //            else
        //            {
        //                ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = false;
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (GeneralFunction.Question(Constants.REMOVEALTERFOREXPIRY, ActionType.AlterForExpiry.ToString()) == DialogResult.Yes)
        //            {
        //                ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = false;
        //                return false;
        //            }
        //            else
        //            {
        //                ObjItemCardBALClass.Objitemcardobjectclass.ExpiryDate = true;
        //                return true;
        //            }
        //        }

        //    }

        //    return false;oiuoio
        //}

        public string GenerateBarCode()
        {
            string barcode;
            Random ran = new Random();
            barcode = GetBarcodeWithCheckSum("21" + Convert.ToString(ran.Next(11111, 99999)) + Convert.ToString(ran.Next(11111, 99999)));
            //if (String.IsNullOrEmpty(ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode))
            //{
            //    ObjItemCardBALClass.Objitemcardobjectclass.OldBarcode = ObjItemCardBALClass.Objitemcardobjectclass.Barcode = barcode;

            //}
            //else
            //{
            ObjItemCardBALClass.Objitemcardobjectclass.Barcode = barcode;
            // }

            if (!ObjItemCardBALClass.CheckDuplicateBarCode())
            {
                return ObjItemCardBALClass.Objitemcardobjectclass.Barcode = barcode;
            }
            else
            {
                GeneralFunction.ErrInfo(Constants.BARCODE, Results.Error.ToString());

                return ObjItemCardBALClass.Objitemcardobjectclass.Barcode = string.Empty;
            }


        }

        public string GetBarcodeWithCheckSum(string barcode)
        {

            int index, checksum = 0;
            for (index = 1; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }
            checksum *= 3;
            for (index = 0; index < 12; index += 2)
            {
                checksum += Convert.ToInt32(barcode.Substring(index, 1));
            }

            return barcode += (10 - checksum % 10) % 10;

        }

        public List<ItemCardObjectClass> GetBarCodeDetails()
        { return ObjItemCardBALClass.GetBarCodeDetail(); }

        public Boolean SaveAdditionalBarcode()
        {
            //if ((ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 0 && ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID > 0) || (ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 0))
            //{ 
            //   GeneralFunction.Information("Should Select UnitTypes", ActionType.Save.ToString());
            //}
            //if (ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID == 0)
            //{

            //    GeneralFunction.Information("Should Select UnitNames", ActionType.Save.ToString());
            //}
            //else if ((ObjItemCardBALClass.Objitemcardobjectclass.UnitTypesID == 1 && ObjItemCardBALClass.Objitemcardobjectclass.UnitNameID == 0) )
            //{

            //    GeneralFunction.Information("Should Select UnitQuantity", ActionType.Save.ToString());
            //}



            if (ObjItemCardBALClass.SaveAdditionalBarCodeDetails())
            {
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Insert), ObjItemCardBALClass.Objitemcardobjectclass.Barcode, "Additional Barcode", "Save additional barcode details", Convert.ToInt32(InvoiceAction.No));
                return true;
            }

            return false;
        }
        public Boolean DeleteBarcodeDetails()
        {

            if (ObjItemCardBALClass.DeleteBarcodeDetails())
            {
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjItemCardBALClass.Objitemcardobjectclass.Barcode, "Additional Barcode", "Delete additional barcode details", Convert.ToInt32(InvoiceAction.No));
                return true;

            }
            return false;
        }

        public Boolean DeleteItemDetails()
        {
            if (GeneralFunction.Question("AlertDeleteItem", "Item Card") == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(ObjItemCardBALClass.Objitemcardobjectclass.Items))
                {
                    if (!ObjItemCardBALClass.CheckItemUnderInvoice())
                    {
                        if (ObjItemCardBALClass.DeleteItemDetails())
                        {
                            GeneralObjectClass.ItemDetails = ObjMasterDataBALClass.ItemDetailsBal();
                            GeneralFunction.Information(CommonHelper.Constants.DELETE, ActionType.Delete.ToString());
                            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Delete), ObjItemCardBALClass.Objitemcardobjectclass.Items.ToString(), "Item Card", "Delete item details", Convert.ToInt32(InvoiceAction.No));
                            return true;


                        }


                    }
                    else
                    {
                        GeneralFunction.Information(CommonHelper.Constants.ITEMUNDERINVOICE, ActionType.Delete.ToString());

                    }
                }
                else
                {
                    GeneralFunction.Information(CommonHelper.Constants.INVAILDTODELETE, ActionType.Delete.ToString());
                }
            }
            return false;

        }


        public Boolean Validation()
        {
            if (ObjItemCardBALClass.Objitemcardobjectclass.Items == string.Empty)
            {

                GeneralFunction.Information(Constants.ITEMNAME, ActionType.Save.ToString());
                ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "cmbItemName";

                return true;
            }

            return false;
        }



        public void LoadItemDetails()
        {
            // dictLoad.Clear();
            dictLoad = ObjItemCardBALClass.GetLoadData();

        }
        public DataSet GetAllItems()
        {
            return ObjItemCardBALClass.GetAllItemDetails();
        }
        public DataTable GetAppliedIncreaseHelper()
        {
            return ObjItemCardBALClass.GetAppliedIncreaseBal();
        }

        public void GetInventoryListDetails()
        {
            inventory = ObjItemCardBALClass.GetInventoryList();
            DataView DV = inventory.DefaultView;
            DV.RowFilter = "[Price] > 0";
            // DV.RowFilter = "[Qty]>0";/////to avoid the non stock item 
            inventory = DV.ToTable();
            if (inventory.Rows.Count > 0)
            {
                ReportsView reportview = new ReportsView();
                Rpt_ItemListPrint itemlistprice = new Rpt_ItemListPrint();

                for (int i = 0; i < inventory.Rows.Count; i++)
                {

                    inventory.Rows[i]["Barcode"] = GeneralFunction.EAN13(inventory.Rows[i]["Barcode"].ToString());
                }
                reportview.Report_Table = inventory;
                reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("InventoryList");
                reportview.HTable.Clear();
                reportview.RptDoc = itemlistprice;
                reportview.IsItemNo = true;
                reportview.LoadEvent();
                reportview.ShowDialog();
            }
            else
                GeneralFunction.Information("NoRecordsFound", "ItemCard");
        }
        public void GetBarcodeListForItem()
        {

            inventory = ObjItemCardBALClass.Get_GenerateBarcode();
            if (inventory.Rows.Count > 0)
            {
                ReportsView reportview = new ReportsView();
                Rpt_ItemList itemlist = new Rpt_ItemList();
                for (int i = 0; i < inventory.Rows.Count; i++)
                {

                    inventory.Rows[i]["BARCODE"] = GeneralFunction.EAN13(inventory.Rows[i]["BARCODE"].ToString());
                }

                reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("GeneratedBarcodeList");
                reportview.HTable.Clear();
                reportview.HTable.Add("ReportName", reportview.Text);
                reportview.Report_Table = inventory;
                reportview.RptDoc = itemlist;

                reportview.LoadEvent();
                reportview.ShowDialog();

            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "ItemCard");
            }

        }
        /// Check barcode
        public bool CheckBarcode(string barcode)
        {
            DataTable dt = new DataTable();
            dt = GeneralFunction.GetBarcode(barcode);
            int id = (from DataRow dr in dt.Rows
                      select (int)dr["ItemID"]).FirstOrDefault();
            if (id!= null && id > 0 ) {
                return true;
            }else
            {
                return false;
            }
                
        }
        /// 
        public void PrintingTheItem()
        {
            inventory = ObjItemCardBALClass.GetPrintItemList();
            DataView DV = inventory.DefaultView;
            //DV.RowFilter = "[STOCKINHAND1]>0";
            inventory = DV.ToTable();
            if (inventory.Rows.Count > 0)
            {
                ReportsView reportview = new ReportsView();
                Rpt_ItemList itemlist = new Rpt_ItemList();
                for (int i = 0; i < inventory.Rows.Count; i++)
                {

                    inventory.Rows[i]["BARCODE"] = GeneralFunction.EAN13(inventory.Rows[i]["BARCODE"].ToString());
                }

                reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("ItemList");

                reportview.Report_Table = inventory;
                reportview.HTable.Clear();
                reportview.HTable.Add("ReportName", reportview.Text);
                reportview.RptDoc = itemlist;
                reportview.LoadEvent();
                reportview.ShowDialog();
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Item details", "Item Card", "Print item details", Convert.ToInt32(InvoiceAction.No));
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "ItemCard");
            }

        }
        public void StockInOutDetails()
        {
            if (ObjItemCardBALClass.Objitemcardobjectclass.ItemId == 0)
            {
                GeneralFunction.Information(Constants.ITEMNAME, ActionType.Information.ToString());
            }
            else
            {
                int sum = 0;
                string itemname = "";
                inventory = ObjItemCardBALClass.GetItemStockHistory();
                if (inventory.Rows.Count > 0)
                    itemname = inventory.Rows[0]["ItemName"].ToString();
                for (int i = 0; i < inventory.Rows.Count; i++)
                {
                    if (itemname != inventory.Rows[i]["ItemName"].ToString())
                    {
                        sum = 0;
                        itemname = inventory.Rows[i]["ItemName"].ToString();
                    }
                    sum = sum + Convert.ToInt32(inventory.Rows[i]["CurrentStock"].ToString());
                    inventory.Rows[i]["CurrentStock"] = sum;

                }
                if (inventory.Rows.Count > 0)
                {
                    ReportsView reportview = new ReportsView();
                    Rpt_ItemCard summery = new Rpt_ItemCard();

                    reportview.Text = GeneralFunction.ChangeLanguageforCustomMsg("ItemcardInOutStock");

                    reportview.Report_Table = inventory;
                    reportview.HTable.Clear();
                    reportview.HTable.Add("WholeSalePrice", ObjItemCardBALClass.Objitemcardobjectclass.WholeSalePrice);
                    reportview.HTable.Add("MinPrice", ObjItemCardBALClass.Objitemcardobjectclass.MinPrice);

                    reportview.HTable.Add("Price", ObjItemCardBALClass.Objitemcardobjectclass.Price);
                    reportview.HTable.Add("ItemCost", ObjItemCardBALClass.Objitemcardobjectclass.ItemCost);
                    reportview.HTable.Add("HideDate", false);
                    if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                    {
                        reportview.HTable.Add("monthformat", 0);
                        reportview.HTable.Add("dayformat", 0);
                        reportview.HTable.Add("yearformat", 0);
                        reportview.HTable.Add("seperatorformat", "/");
                        reportview.HTable.Add("dateformat", 0);
                    }
                    else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                    {
                        reportview.HTable.Add("monthformat", 1);
                        reportview.HTable.Add("dayformat", 1);
                        reportview.HTable.Add("yearformat", 1);
                        reportview.HTable.Add("seperatorformat", "/");
                        reportview.HTable.Add("dateformat", 1);
                    }
                    else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                    {
                        reportview.HTable.Add("monthformat", 1);
                        reportview.HTable.Add("dayformat", 1);
                        reportview.HTable.Add("yearformat", 1);
                        reportview.HTable.Add("seperatorformat", "-");
                        reportview.HTable.Add("dateformat", 0);
                    }
                    else
                    {
                        reportview.HTable.Add("monthformat", 1);
                        reportview.HTable.Add("dayformat", 1);
                        reportview.HTable.Add("yearformat", 1);
                        reportview.HTable.Add("seperatorformat", "/");
                        reportview.HTable.Add("dateformat", 0);
                    }
                    reportview.RptDoc = summery;
                    reportview.IsReportFooter = false;
                    reportview.IsGroupHeader = true;
                    reportview.IsItemNo1 = true;
                    reportview.LoadEvent();
                    reportview.ShowDialog();
                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "ItemCard");
                }

            }
        }

        public List<ItemCardObjectClass> GetUnitNameBarcodeDetails()
        {


            return ObjItemCardBALClass.DetailsOfUnitNameBarcode();
        }







    }


}
