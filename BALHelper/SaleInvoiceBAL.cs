using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectHelper;
using DataBaseHelper.DALClass;
using System.Data;
using CommonHelper;

namespace BALHelper
{


    public class SaleInvoiceBAL
    {
        public SaleObject objSaleObject = new SaleObject();
        SaleInvoiceDALClass objSaleInvoiceDALClass;
        internal List<SaleObject> lstInvoiceDetails = new List<SaleObject>();
        public SaleInvoiceBAL()
        {

            objSaleInvoiceDALClass = new SaleInvoiceDALClass();
        }
        public List<object> Get_Grid()
        {
            return objSaleInvoiceDALClass.getSaleTable();
        }



        public List<AgentDetailObjectClass> LoadClientDetailsBal()
        {
            List<AgentDetailObjectClass> ObjListAgent = GeneralObjectClass.AgentDetails;

            if (GeneralOptionSetting.FlagStopDeptSellings == "Y")
            {
                ObjListAgent = (from p in ObjListAgent
                                where p.AgentId == Convert.ToInt16(CommonHelper.CashClientID.ID)
                                select p).ToList();
            }
            else
            {
                ObjListAgent = (from p in ObjListAgent
                                where (p.AgentType.Contains("101") || p.AgentType.Contains("103")) && (!p.AgentType.Contains("104"))
                                // orderby p.Name
                                select p).ToList();
            }


            return ObjListAgent;
        }
        public DataTable GetAllClients()
        {
            return StoredProcedurers.GetClientDetails();
        }


        public Dictionary<string, List<SaleObject>> Get_LoadDetails()
        {
            return objSaleInvoiceDALClass.getLoadDetails(objSaleObject);
        }
        
        //public List<SaleObject> getItemDetails()
        //{
        //    return objSaleInvoiceDALClass.getItemDetails();
        //}
        public DataTable getItemDetails()
        {
            return objSaleInvoiceDALClass.getItemDetails();
        }
        public List<int> GetSaleIdBal()
        {
            return objSaleInvoiceDALClass.GetSaleId();
        }

        public List<SaleObject> Get_ItemForCategory()
        {
            return objSaleInvoiceDALClass.getItemForCategoryWithStock(objSaleObject);
        }

        public List<SaleObject> Get_ItemForCategoryWithNonStock()
        {
            return objSaleInvoiceDALClass.getItemForCategoryWithNonStock(objSaleObject);
        }

        public List<SaleObject> GetItemNameInfoBal()
        {
            return objSaleInvoiceDALClass.GetItemNameInfo(objSaleObject);
        }

        public float GetDiscountForAgentBal()
        {
            return objSaleInvoiceDALClass.GetDiscountForAgent(objSaleObject);
        }
        public float GetIsDiscountOrIncreaseForAgentBal()
        {
            return objSaleInvoiceDALClass.GetIsDiscountOrIncreaseForAgent(objSaleObject);
        }

        public float GetPaymentChargesBal()
        {
            return objSaleInvoiceDALClass.GetPaymentCharges(objSaleObject);
        }
        
        public Dictionary<string, List<SaleObject>> GetPaymentDateBal()
        {
            return objSaleInvoiceDALClass.GetPaymentDate();
        }

        public List<SaleObject> GetSerialNoBal()
        {
            return objSaleInvoiceDALClass.GetSerialNo(objSaleObject);
        }

        public List<SaleObject> GetItemMinPriceBal()
        {
            return objSaleInvoiceDALClass.GetItemMinimumPrice(objSaleObject);
        }

        public List<SaleObject> GetStockBasedExpiryBal()
        {
            return objSaleInvoiceDALClass.GetStockBasedExpiry(objSaleObject);
        }

        public List<SaleObject> GetStockBasedSerialNoBal()
        {
            return objSaleInvoiceDALClass.GetStockBasedSerialNo(objSaleObject);
        }

        public List<SaleObject> GetStockBal()
        {
            return objSaleInvoiceDALClass.GetStock(objSaleObject);
        }

        public List<SaleObject> GetExpiryCountBal()
        {
            return objSaleInvoiceDALClass.GetExpiryCount(objSaleObject);
        }
        public List<SaleObject> GetExpiryForUpdate(int iID,DateTime? Exp)
        {
            return objSaleInvoiceDALClass.GetExpiryUpdate(iID, Exp);
        }
        public List<SaleObject> GetDebtLimitBal()
        {
            return objSaleInvoiceDALClass.GetDebtLimit(objSaleObject);
        }


        public List<SaleObject> GetActiveUserBal()
        {
            return objSaleInvoiceDALClass.GetActiveUser(objSaleObject);
        }


        public List<long> GetYearSequenceMaxIDBal()
        {
            List<long> list = objSaleInvoiceDALClass.GetYearSequenceMaxID();
            return list;
        }

        public bool SaveSalesBal()
        {
            bool Value = objSaleInvoiceDALClass.SaveSales(objSaleObject);
            return Value;
        }

        public bool SaveSalesOnCloseBal()
        {
            bool Value = objSaleInvoiceDALClass.SaveSalesOnClose(objSaleObject);
            return Value;
        }

        public bool SaveSaleDetailsBal()
        {
            bool Value = objSaleInvoiceDALClass.SaveSaleDetails(objSaleObject);
            return Value;
        }

        public bool SaveSaleDetailsOnClosingBal()
        {
            bool Value = objSaleInvoiceDALClass.SaveSaleDetailsOnClosing(objSaleObject);
            return Value;
        }

        public bool SaveSaleDetailOnCloseDT(DataTable dt)
        {
            bool Value = objSaleInvoiceDALClass.SaveSaleDetailOnCloseDT(dt);
            return Value;
        }

        public bool UpdateActiveUserBal()
        {
            bool Value = objSaleInvoiceDALClass.UpdateActiveUser(objSaleObject);
            return Value;
        }

        public List<SaleObject> GetSaleDetailsBal()
        {

            return objSaleInvoiceDALClass.GetSaleDetails(objSaleObject);
        }

        public List<SaleObject> GetSaleDetailsExtendedBal()
        {
            // return objSaleInvoiceDALClass.GetSaleDetailsExtended(objSaleObject);
            try
            {
                List<SaleObject> lstSaleDet = objSaleInvoiceDALClass.GetSaleDetailsExtended(objSaleObject);

                //lstSaleDet.Add(new SaleObject
                //{

                //    Totalcost = Convert.ToDecimal(list.Itemcost * list.quantity),
                //    Subtotal = Convert.ToDecimal((list.quantity / list.ItemPackage) * list.ActualPrice),
                //    Box = list.quantity / list.ItemPackage
                //});

                if (lstSaleDet.Count > 0)
                {
                    for (int i = 0; i <= lstSaleDet.Count - 1; i++)
                    {
                        //add by thamil
                        lstSaleDet[i].ItemCost = lstSaleDet[i].ItemCost == 0 ? Convert.ToDecimal(lstSaleDet[i].ItemCostPer) : lstSaleDet[i].ItemCost;
                        lstSaleDet[i].Totalcost = Convert.ToDecimal(lstSaleDet[i].ItemCostPer * (lstSaleDet[i].quantity != 0 ? lstSaleDet[i].quantity : 1));
                        //lstSaleDet[i].Subtotal = Convert.ToDecimal((lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1)) * lstSaleDet[i].ActualPrice);
                        lstSaleDet[i].Subtotal = Convert.ToDecimal((lstSaleDet[i].quantity * (lstSaleDet[i].itemunitprice + lstSaleDet[i].itemunitdiscount)));
                        //lstSaleDet[i].Box = lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1); //Commented on 22-May-2014 for Getting Box Calculation from DB
                        if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem == "Y" ||lstSaleDet[i].itemdiscount==0)
                        {
                            if (lstSaleDet[i].quantity % lstSaleDet[i].ItemPackage == 0) //Added on 28-Oct-2014
                            {
                                lstSaleDet[i].TotalPrice = (lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1)) * lstSaleDet[i].ActualPrice;
                                lstSaleDet[i].Subtotal = (((lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1)) * lstSaleDet[i].ActualPrice));//+ lstSaleDet[i].itemunitdiscount);//(Comment this discount on 02-July-2019 By T)// //this line added by meena.r on 07/11/2014

                                // this line added and commit above line on 26-April-2019 by T, fixed issue for modify invoice when price change
                                //lstSaleDet[i].TotalPrice = (lstSaleDet[i].quantity * (lstSaleDet[i].unitprice)); 
                                //lstSaleDet[i].Subtotal = ((lstSaleDet[i].quantity * (lstSaleDet[i].unitprice)) + lstSaleDet[i].itemunitdiscount);
                            }
                            else//added this by meena.R on 11/05/2014 to fix when closing the invoice it shows the 0.000
                            {
                                lstSaleDet[i].TotalPrice = (lstSaleDet[i].quantity * (lstSaleDet[i].unitprice));
                            }
                        }
                        else if (GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem != "Y"&& lstSaleDet[i].itemdiscount!=0)
                        {
                            //if (lstSaleDet[i].quantity % lstSaleDet[i].ItemPackage == 0) //Added on 28-Oct-2014
                            //{
                            //    lstSaleDet[i].TotalPrice = (lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1)) * lstSaleDet[i].ActualPrice;
                            //    lstSaleDet[i].Subtotal = (((lstSaleDet[i].quantity / (lstSaleDet[i].ItemPackage != 0 ? lstSaleDet[i].ItemPackage : 1)) * lstSaleDet[i].ActualPrice) + lstSaleDet[i].itemunitdiscount);//this line added by meena.r on 07/11/2014
                            //}
                            //else//added this by meena.R on 11/05/2014 to fix when closing the invoice it shows the 0.000
                            //{
                                lstSaleDet[i].TotalPrice = (lstSaleDet[i].quantity * (lstSaleDet[i].unitprice));
                            //}
                        }
                    }
                }

                return lstSaleDet;
            }
            catch (Exception)
            {

                throw;
            }


        }


        #region SortInvoiceDetailsBal
        public List<SaleObject> SortInvoiceDetailsBal(List<SaleObject> lstInvDetail, string SortColumnName, string SortOrder)
        {

            switch (SortOrder)
            {
                case "asc":
                    if (SortColumnName == "ItemDescription")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemDescription ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "ItemUnitPrice" || SortColumnName == "unitprice")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.unitprice ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    break;
                case "desc":
                    if (SortColumnName == "ItemDescription")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemDescription descending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "ItemUnitPrice" || SortColumnName == "unitprice")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.unitprice descending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    break;

                default:
                    return lstInvDetail;
            }


            return lstInvDetail;

        }
        #endregion

        public List<SaleObject> GetItemAvgCostBal()
        {

            return objSaleInvoiceDALClass.GetItemAvgCost(objSaleObject);

        }

        public DataTable GetSaleDetailIDBal()
        {

            return objSaleInvoiceDALClass.GetSaleDetailID(objSaleObject);

        }


        public List<SaleObject> GetYearSequenceBal()
        {

            return objSaleInvoiceDALClass.GetYearSequence(objSaleObject);

        }

        public List<SaleObject> GetStockBaseExpiryInvNoBal()
        {

            return objSaleInvoiceDALClass.GetStockBaseExpiryInvNo(objSaleObject);

        }


        public bool DeleteSaleItemBal()
        {

            return objSaleInvoiceDALClass.DeleteSaleItem(objSaleObject);

        }

        public List<SaleObject> GetItemNameForIDBal()
        {

            return objSaleInvoiceDALClass.GetItemNameForID(objSaleObject);

        }


        public List<SaleObject> GetClientNoBal()
        {

            return objSaleInvoiceDALClass.GetClientNo(objSaleObject);

        }

        public List<SaleObject> GetClientNameBal()
        {

            return objSaleInvoiceDALClass.GetClientName(objSaleObject);

        }

        public List<SaleObject> GetCurrentYearBal(int TableID)
        {

            return objSaleInvoiceDALClass.GetCurrentYear(TableID);

        }

        public List<int> GetMinMaxSaleIDBal()
        {

            return objSaleInvoiceDALClass.GetMinMaxSaleID();

        }

        public Decimal GetAgentDiscountBal()
        {

            return objSaleInvoiceDALClass.GetAgentDiscount(objSaleObject);

        }

        public float GetAppliedDiscountBal()
        {

            return objSaleInvoiceDALClass.GetAppliedDiscount(objSaleObject);

        }

        public DataTable GetAppliedIncreaseBal()
        {

            return objSaleInvoiceDALClass.GetAppliedIncrease(objSaleObject);

        }

        public int CheckEmptyInvoiceBal()
        {

            return objSaleInvoiceDALClass.CheckEmptyInvoice(objSaleObject);

        }

        public bool ModifyInvoiceBal()
        {

            return objSaleInvoiceDALClass.ModifyInvoice(objSaleObject);

        }

        public int CheckClosedInvoiceBal()
        {

            return objSaleInvoiceDALClass.CheckClosedInvoice(objSaleObject);

        }
        public bool CheckDateIsExpiryBal()
        {

            return objSaleInvoiceDALClass.CheckDateIsExpiry(objSaleObject);

        }

        public List<SaleObject> GetBalanceForSaleInvoiceBal()
        {

            return objSaleInvoiceDALClass.GetBalanceForSaleInvoice(objSaleObject);

        }

        public List<SaleObject> GetItemInfoExportBal()
        {

            return objSaleInvoiceDALClass.GetItemInfoExport(objSaleObject);

        }

        public bool SaveAgentDetails()
        {
            AgentDetailObjectClass Obj = new AgentDetailObjectClass();
            AgentDetailDAL ObjDAL = new AgentDetailDAL();
            try//Added try catch finally to release the "Obj" &  "ObjDAL" object for Performance Tuning on 18
            {
                Obj.Name = objSaleObject.CmbClientText;
                Obj.AgtSupplier = "0";
                Obj.AgentType = "101|0|0|0";
                Obj.CreatedBy = GeneralFunction.UserId;
                Obj.ModifiedBy = GeneralFunction.UserId;
                Obj.Address = string.Empty;
                Obj.AgtBranch = "0";
                Obj.AgtClient = "101";
                Obj.AgtHideAgent = "0";
                Obj.DebtLimt = 0;
                Obj.Phoneno = string.Empty;
                Obj.PaymentDay = string.Empty;
                List<object> AgentAvailable = ObjDAL.Check_AgentNameAvailable(Obj);
                if (AgentAvailable != null && AgentAvailable.Count > 0)
                {
                    GeneralFunction.Information("ExistsAgentName", "SaleInvoice");
                    return false;
                }
                else
                {
                    if (ObjDAL.SaveAgentdetails(Obj) > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Obj = null;
                ObjDAL = null;
            }
        }

        public object GetPurInvIDBasedOnNewYearID()
        {
            object Obj = objSaleInvoiceDALClass.GetInvoiceIDBasedonNewYearID(objSaleObject);
            return Obj;
        }

        public DataTable GetSalesPrintReportBal()
        {
            return objSaleInvoiceDALClass.GetSalesPrintReport(objSaleObject);
        }
        public DataTable GetSalesPaidRemainingBal()
        {
            return objSaleInvoiceDALClass.GetSalesPaidRemainingByID(objSaleObject);
        }
        public List<SaleObject> Get_ItemDetails()
        {
            return objSaleInvoiceDALClass.GetDetailsForItem(objSaleObject);
        }

        public List<long> GetSaleIDWithoutPOSBAl()
        {
            return objSaleInvoiceDALClass.GetSaleID();
        }
        public int GetSaleIDCountWithoutPOSBAl()
        {
            return objSaleInvoiceDALClass.GetSaleIDCount();
        }
        public List<SaleObject> GetPackageQtyForItemBal()
        {
            return objSaleInvoiceDALClass.GetPackageQtyForItem(objSaleObject);
        }

        public List<SaleObject> GetExpiryBasedPackageBal()
        {
            return objSaleInvoiceDALClass.GetExpiryBasedPackage(objSaleObject);
        }

        public List<SaleObject> GetSerialNoBasedPackageBal()
        {
            return objSaleInvoiceDALClass.GetSerialNoBasedPackage(objSaleObject);
        }

        public decimal GetPriceForPackageQtyBal()
        {
            return objSaleInvoiceDALClass.GetPriceForPackageQty(objSaleObject);
        }
        public List<long> InsertReceiptID()
        {

            List<long> list = StoredProcedurers.GetYearSequenceMaxID(Convert.ToInt32(CommonHelper.Table.CustomerReceipt));
            return list;
        }
        public object GetReceiptMaxId()
        {
            return objSaleInvoiceDALClass.GetReceipt_MaxID();

        }
        public bool Savecashclientreceipt()
        {
            return objSaleInvoiceDALClass.SaveCashClientReceiptDetails(objSaleObject);
        }
        public List<SaleObject> GetBalanceBal()
        {
            return objSaleInvoiceDALClass.GetBalanceSheetDetails(objSaleObject);

        }
        public decimal GetBalance() 
        {
            return objSaleInvoiceDALClass.GetBalanceSheet(objSaleObject);

        }
        public bool UpdateSalesDetails(int XStockInHand, decimal XPrice, int XBox, DateTime? XExpiryDate, string XSerialNo, int XBarcodeID)
        {
            return objSaleInvoiceDALClass.UpdateSalesDetails(objSaleObject, XStockInHand, XPrice, XBox, XExpiryDate, XSerialNo, XBarcodeID);
        }
        public List<SaleObject> GetCateComIDForItemBal()
        {
            return objSaleInvoiceDALClass.GetCateComIDForItem(objSaleObject);
        }
        public DataTable GetSaleItem()
        {
            return objSaleInvoiceDALClass.GetSaleItem();
        }
    }
}
