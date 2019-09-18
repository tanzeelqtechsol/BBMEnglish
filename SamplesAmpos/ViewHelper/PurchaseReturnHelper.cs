using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BumedianBM.Interface;
using BALHelper;
using CommonHelper;
using ObjectHelper;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Collections;
using System.Threading;
using System.Configuration;
using BumedianBM.CrystalReports;
namespace BumedianBM.ViewHelper
{
    public class PurchaseReturnHelper
    {
        PurchaseReturnBAL objPurReturnBal;
        internal List<PurchaseObjectClass> ItemListDetails = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> ReturnItemDetailsList = new List<PurchaseObjectClass>();
        internal List<PurchaseObjectClass> ReturnPurchaseList = new List<PurchaseObjectClass>();
        List<long> InvoiceIDDetails = new List<long>();
        internal List<long> ID = new List<long>();
        internal bool IsfromNewInv, isProcessTrue, isFromElse = false, isFromNewElse = false;
        public int IDFlag;
        ArrayList al = new ArrayList();
        public PurchaseReturnHelper()
        {
            objPurReturnBal = new PurchaseReturnBAL();
            objPurReturnBal.SetCommonObject();
            //ItemListDetails = ObjBALClass.GetItemList();
            ID = ObjBALClass.GetMaxMinInvoiceID();
        }

        public PurchaseReturnBAL ObjBALClass
        {
            get { return objPurReturnBal; }
            set { objPurReturnBal = value; }
        }

        public void InvoiceIDNewYearID()
        {
            InvoiceIDDetails = ObjBALClass.GetInvoiceID();
            ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = InvoiceIDDetails[0];
            ObjBALClass.ObjPurchaseReturn.Year = Convert.ToInt32(InvoiceIDDetails[1]);
            ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(InvoiceIDDetails[2]);
        }

        internal void FindReturnInvoice()
        {
            if (ObjBALClass.ObjPurchaseReturn.ItemName.Length != 0 && ObjBALClass.ObjPurchaseReturn.ItemNo != null)
            {
                if (ObjBALClass.ObjPurchaseReturn.CheckNote)
                    ReturnItemDetailsList = ObjBALClass.GetReturnDetailsByInvoice();
                else
                    ReturnItemDetailsList = ObjBALClass.GetReturnDetails();
                if (ReturnItemDetailsList.Count > 0)
                {

                }
                else
                {
                    GeneralFunction.Information("NoRecordsFound", "PurchaseReturnInvoice");
                    ReturnItemDetailsList.Clear();
                    return;
                }
            }
            else
            {
                GeneralFunction.Information("SelectItem", "PurchaseReturnInvoice");
                ReturnItemDetailsList.Clear();
                return;
            }

        }

        internal void btnNewInvoice()
        {
            ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[1];
            GetInvoiceRecordBasedOnID();
            if (ObjBALClass.ObjPurchaseReturn.Status == 2)
            {
                this.InvoiceIDNewYearID();
                IsfromNewInv = true;
                if (SavePurchaseReturnDetails())
                {
                    ID[1] = InvoiceIDDetails[0];
                    isProcessTrue = true;
                }
            }
            else
            {
                isProcessTrue = true;
                isFromNewElse = true;
            }
        }

        internal void btnReturnInvoice()
        {
            ObjBALClass.ObjPurchaseReturn.ItemStock = Convert.ToInt32(ObjBALClass.GetStockInCount());
            int index = ReturnItemDetailsList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemCost == ObjBALClass.ObjPurchaseReturn.ItemCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.NewCost == ObjBALClass.ObjPurchaseReturn.NewCost) && (a.PurchaseDetailsId == ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId));
            AssignListToObject(index);
            if (ObjBALClass.ObjPurchaseReturn.SupplierName == string.Empty)
            {
                ObjBALClass.ObjPurchaseReturn.SupplierName = ReturnItemDetailsList[index].SupplierName;
                var no = (from list in GeneralObjectClass.SupplierDetails where list.Name == ObjBALClass.ObjPurchaseReturn.SupplierName select list.AgentId).ToList();
                if (no.Count > 0)
                    ObjBALClass.ObjPurchaseReturn.SupplierNo = Convert.ToInt32(no[0]);
            }
            //ObjBALClass.ObjPurchaseReturn.SupplierName = ObjBALClass.ObjPurchaseReturn.SupplierName == string.Empty ? ReturnItemDetailsList[index].SupplierName : ObjBALClass.ObjPurchaseReturn.SupplierName;
            if (!ObjBALClass.ObjPurchaseReturn.CheckNote)
            {
                if (Validation())
                {
                    if (ReturnItemDetailsList[index].PurchaseQuantity > 0)
                    {
                        if (ReturnItemDetailsList[index].PurchaseQuantity >= ObjBALClass.ObjPurchaseReturn.ReturnQty)
                        {
                            if (ReturnItemDetailsList[index].SupplierName == ObjBALClass.ObjPurchaseReturn.SupplierName)
                            {
                                //ObjBALClass.ObjPurchaseReturn.ReturnQty = ReturnItemDetailsList[index].ReturnQty + ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                ObjBALClass.ObjPurchaseReturn.ItemQuantity = ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                if (ObjBALClass.SavePurchaseReturn())
                                {
                                    isProcessTrue = true;
                                    ReturnItemDetailsList[index].ReturnQty = ReturnItemDetailsList[index].ReturnQty + ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                    int QTY = ReturnItemDetailsList[index].PurchaseQuantity;
                                    ReturnItemDetailsList[index].PurchaseQuantity = QTY - ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                    ReturnItemDetailsList[index].ItemTotal = ReturnItemDetailsList[index].PurchaseQuantity * ReturnItemDetailsList[index].PurchaseCost;
                                    int i = -1;
                                    i = ReturnPurchaseList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemUnitPrice == ObjBALClass.ObjPurchaseReturn.PurchaseCost) && (a.ItemSerialNo == ObjBALClass.ObjPurchaseReturn.ItemSerialNo) && (a.PurchaseDetailsId == ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId));
                                    if (i != -1)
                                    {
                                        ReturnPurchaseList[i].ItemQuantity = ReturnPurchaseList[i].ItemQuantity + ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                        ReturnPurchaseList[i].ItemTotal = ReturnPurchaseList[i].ItemQuantity * ReturnPurchaseList[i].ItemUnitPrice;
                                    }
                                    if (i == -1)
                                        AddedValueToList();
                                    // ReturnItemDetailsList[index].ItemQuantity = ReturnItemDetailsList[index].ItemQuantity - ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                    // ReturnItemDetailsList[index].ItemTotal = ReturnItemDetailsList[index].ItemQuantity * ReturnItemDetailsList[index].PurchaseCost;
                                    ObjBALClass.ObjPurchaseReturn.ItemTotal = ReturnPurchaseList.Sum(a => a.ItemTotal);
                                }
                            }
                            else
                            {
                                GeneralFunction.Information("NotAllowDifferentSupplier", "PurchaseReturnInvoice");
                                return;
                            }
                        }
                        else
                        {
                            GeneralFunction.Information("ReturnQtyEqual", "PurchaseReturnInvoice");
                        }
                    }
                    else
                    {
                        GeneralFunction.Information("EmptyQuantity", "PurchaseReturnInvoice");
                    }

                }

            }
            else
            {
                if (ObjBALClass.ObjPurchaseReturn.CheckNote)
                {

                    if (ReturnItemDetailsList[index].InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo)
                    {
                        List<PurchaseObjectClass> tempList = ReturnItemDetailsList.Where(a => a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo).ToList();
                        for (int i = 0; i < tempList.Count; i++)
                        {
                            ObjBALClass.ObjPurchaseReturn.ItemNo = tempList[i].ItemNo;
                            ObjBALClass.ObjPurchaseReturn.ItemName = tempList[i].ItemName;
                            ObjBALClass.ObjPurchaseReturn.ItemPackage = tempList[i].ItemPackage;
                            ObjBALClass.ObjPurchaseReturn.ItemUnitPrice = tempList[i].PurchaseCost;
                            ObjBALClass.ObjPurchaseReturn.ItemCost = tempList[i].ItemCost;
                            //ObjBALClass.ObjPurchaseReturn.ItemTotal = ((ReturnItemDetailsList[index].ReturnQty + ObjBALClass.ObjPurchaseReturn.ReturnQty) * ReturnItemDetailsList[index].PurchaseCost);
                            ObjBALClass.ObjPurchaseReturn.InvoiceNo = tempList[i].InvoiceNo;
                            //ObjBALClass.ObjPurchaseReturn.SupplierName = ReturnItemDetailsList[index].SupplierName;
                            ObjBALClass.ObjPurchaseReturn.ItemSerialNo = tempList[i].ItemSerialNo;
                            ObjBALClass.ObjPurchaseReturn.PurchaseID = tempList[i].PurchaseID;
                            ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = tempList[i].PurchaseDetailsId;
                            ObjBALClass.ObjPurchaseReturn.NewCost = tempList[i].NewCost;
                            ObjBALClass.ObjPurchaseReturn.ModifiedBy = ObjBALClass.ObjPurchaseReturn.CreatedBy = GeneralFunction.UserId;
                            ObjBALClass.ObjPurchaseReturn.ReturnDate = DateTime.Now;
                            ObjBALClass.ObjPurchaseReturn.Reason = "PR";
                            ObjBALClass.ObjPurchaseReturn.ItemSerialNo = tempList[i].ItemSerialNo;
                            ObjBALClass.ObjPurchaseReturn.Status = 1;
                            ObjBALClass.ObjPurchaseReturn.PurchaseCost = tempList[i].PurchaseCost;
                            ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = tempList[i].ItemExpiryDate;
                            ObjBALClass.ObjPurchaseReturn.ItemNumber = tempList[i].ItemNumber;
                            ObjBALClass.ObjPurchaseReturn.ItemStock = Convert.ToInt32(ObjBALClass.GetStockInCount());
                            int availablereturnQty = 0;
                            availablereturnQty = (Convert.ToInt32(tempList[i].PurchaseQuantity) <= ObjBALClass.ObjPurchaseReturn.ItemStock) ? Convert.ToInt32((tempList[i].PurchaseQuantity)) : ObjBALClass.ObjPurchaseReturn.ItemStock;
                            if (availablereturnQty > 0)
                            {
                                if (Convert.ToInt32(tempList[i].PurchaseQuantity) > 0)
                                {
                                    if (tempList[i].SupplierName == ObjBALClass.ObjPurchaseReturn.SupplierName)
                                    {
                                        ObjBALClass.ObjPurchaseReturn.ItemQuantity = availablereturnQty;
                                        ObjBALClass.ObjPurchaseReturn.ReturnQty = availablereturnQty;
                                        //ReturnItemDetailsList[index].PurchaseQuantity = ReturnItemDetailsList[index].PurchaseQuantity - availablereturnQty;
                                        //-- ReturnItemDetailsList[index].ItemTotal = ReturnItemDetailsList[index].PurchaseQuantity * ReturnItemDetailsList[index].PurchaseCost;
                                        //ReturnItemDetailsList[index].ReturnQty = ReturnItemDetailsList[index].ReturnQty + availablereturnQty;
                                        if (ObjBALClass.SavePurchaseReturn())
                                        {
                                            AddedValueToList();
                                            int tempi = ReturnItemDetailsList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemCost == ObjBALClass.ObjPurchaseReturn.ItemCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.NewCost == ObjBALClass.ObjPurchaseReturn.NewCost) && (a.PurchaseDetailsId == ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId));
                                            ReturnItemDetailsList[tempi].PurchaseQuantity = ReturnItemDetailsList[tempi].PurchaseQuantity - availablereturnQty;
                                            ReturnItemDetailsList[tempi].ItemTotal = ReturnItemDetailsList[tempi].PurchaseQuantity * ReturnItemDetailsList[tempi].PurchaseCost;
                                            ReturnItemDetailsList[tempi].ReturnQty = ReturnItemDetailsList[tempi].ReturnQty + availablereturnQty;
                                            al.Add(tempi);
                                            isProcessTrue = true;
                                        }
                                    }
                                    else
                                    {
                                        GeneralFunction.Information("NotAllowDifferentSupplier", "PurchaseReturnInvoice");
                                        return;
                                    }
                                }
                                else
                                {
                                    GeneralFunction.Information("EmptyQty", "PurchaseReturnInvoice");
                                }
                            }
                            else
                            {
                               // GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoStockItem"), GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"));
                                GeneralFunction.Information("NoStockItem", "PurchaseReturnInvoice");
                            }
                        }
                    }
                    if (isProcessTrue)
                    {
                        // foreach (int i in al) { ReturnItemDetailsList.RemoveAt(i); } al.Clear();
                    }
                }
            }
        }

        private void AssignListToObject(int index)
        {
            ObjBALClass.ObjPurchaseReturn.ItemNo = ReturnItemDetailsList[index].ItemNo;
            ObjBALClass.ObjPurchaseReturn.ItemName = ReturnItemDetailsList[index].ItemName;
            ObjBALClass.ObjPurchaseReturn.ItemPackage = ReturnItemDetailsList[index].ItemPackage;
            ObjBALClass.ObjPurchaseReturn.ItemUnitPrice = ReturnItemDetailsList[index].PurchaseCost;
            //ObjBALClass.ObjPurchaseReturn.ItemTotal = ((ReturnItemDetailsList[index].ReturnQty + ObjBALClass.ObjPurchaseReturn.ReturnQty) * ReturnItemDetailsList[index].PurchaseCost);
            ObjBALClass.ObjPurchaseReturn.InvoiceNo = ReturnItemDetailsList[index].InvoiceNo;
            //ObjBALClass.ObjPurchaseReturn.SupplierName = ReturnItemDetailsList[index].SupplierName;
            ObjBALClass.ObjPurchaseReturn.ItemSerialNo = ReturnItemDetailsList[index].ItemSerialNo;
            ObjBALClass.ObjPurchaseReturn.PurchaseID = ReturnItemDetailsList[index].PurchaseID;
            ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = ReturnItemDetailsList[index].PurchaseDetailsId;
            ObjBALClass.ObjPurchaseReturn.NewCost = ReturnItemDetailsList[index].NewCost;
            ObjBALClass.ObjPurchaseReturn.ModifiedBy = ObjBALClass.ObjPurchaseReturn.CreatedBy = GeneralFunction.UserId;
            ObjBALClass.ObjPurchaseReturn.ReturnDate = DateTime.Now;
            ObjBALClass.ObjPurchaseReturn.Reason = "PR";
            ObjBALClass.ObjPurchaseReturn.ItemSerialNo = ReturnItemDetailsList[index].ItemSerialNo;
            ObjBALClass.ObjPurchaseReturn.Status = 1;
            ObjBALClass.ObjPurchaseReturn.PurchaseCost = ReturnItemDetailsList[index].PurchaseCost;
            ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = ReturnItemDetailsList[index].ItemExpiryDate;
            ObjBALClass.ObjPurchaseReturn.ItemNumber = ReturnItemDetailsList[index].ItemNumber;
        }

        internal void btnCloseInvoice()
        {
            if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
            {
                if (GeneralFunction.Question("AlertCloseInvoice", "PurchaseReturnInvoice") == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void AddedValueToList()
        {
            ReturnPurchaseList.Add(new PurchaseObjectClass
            {
                ItemNo = ObjBALClass.ObjPurchaseReturn.ItemNo,
                ItemName = ObjBALClass.ObjPurchaseReturn.ItemName,
                ItemPackage = ObjBALClass.ObjPurchaseReturn.ItemPackage,
                ItemQuantity = ObjBALClass.ObjPurchaseReturn.ReturnQty,
                ItemUnitPrice = Convert.ToDecimal(ObjBALClass.ObjPurchaseReturn.PurchaseCost.ToString("#####0.000")),
                //ItemCost = Convert.ToDecimal(ObjBALClass.ObjPurchaseReturn.PurchaseCost.ToString("#####0.000")),
                ItemCost = ObjBALClass.ObjPurchaseReturn.ItemCost,
                ItemTotal = ObjBALClass.ObjPurchaseReturn.ReturnQty * ObjBALClass.ObjPurchaseReturn.PurchaseCost,
                InvoiceNo = ObjBALClass.ObjPurchaseReturn.InvoiceNo,
                SupplierName = ObjBALClass.ObjPurchaseReturn.SupplierName,
                ItemSerialNo = ObjBALClass.ObjPurchaseReturn.ItemSerialNo,
                PurchaseID = ObjBALClass.ObjPurchaseReturn.PurchaseID,
                PurchaseDetailsId = ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId,
                NewCost = Convert.ToDecimal(ObjBALClass.ObjPurchaseReturn.NewCost.ToString("#####0.000")),
                ItemExpiry = ObjBALClass.ObjPurchaseReturn.ItemExpiryDate == DateTime.MinValue || ObjBALClass.ObjPurchaseReturn.ItemExpiryDate == null ? "-" : ObjBALClass.ObjPurchaseReturn.ItemExpiryDate.Value.ToString().Split(' ').Length > 2 ? ObjBALClass.ObjPurchaseReturn.ItemExpiryDate.Value.ToString().Split(' ')[1] : ObjBALClass.ObjPurchaseReturn.ItemExpiryDate.Value.ToString().Split(' ')[0],
                ItemExpiryDate = ObjBALClass.ObjPurchaseReturn.ItemExpiryDate,
                ItemNumber = ObjBALClass.ObjPurchaseReturn.ItemNumber,
                Time = DateTime.Now.TimeOfDay.ToString().Split('.')[0],
            });
            ObjBALClass.ObjPurchaseReturn.ItemTotal = ReturnPurchaseList.Sum(a => a.ItemTotal);
        }

        private Boolean Validation()
        {
            if (ObjBALClass.ObjPurchaseReturn.ReturnQty == 0)
            {
                GeneralFunction.Information("EmptyQty", "PurchaseReturnInvoice");
                return false;
            }
            if (Convert.ToInt32(ObjBALClass.ObjPurchaseReturn.ReturnQty) > Convert.ToInt32(ObjBALClass.ObjPurchaseReturn.ItemQuantity))
            {
                GeneralFunction.Information("ReturnQtyEqual", "PurchaseReturnInvoice");
                return false;
            }
            if (Convert.ToInt32(ObjBALClass.ObjPurchaseReturn.ReturnQty) > ObjBALClass.ObjPurchaseReturn.ItemStock)
            {
                if (ObjBALClass.ObjPurchaseReturn.ItemStock > 0)
                {
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("AvailabeQty") + "  " + ObjBALClass.ObjPurchaseReturn.ItemStock, GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"));
                    if (GeneralFunction.Question("Doyouwanttocontinue", "PurchaseReturnInvoice") == DialogResult.Yes)
                    {
                        ObjBALClass.ObjPurchaseReturn.ReturnQty = ObjBALClass.ObjPurchaseReturn.ItemStock;
                        return true;
                    }
                    else return false;
                }
                else
                {
                    GeneralFunction.Information("NoStockItem", "PurchaseReturnInvoice");
                    return false;
                }
            }
            return true;
        }

        private void Close()
        {
            if (ReturnPurchaseList.Count > 0)
            {
                for (int i = 0; i < ReturnPurchaseList.Count; i++)
                {
                    ObjBALClass.ObjPurchaseReturn.InvoiceNo = ReturnPurchaseList[i].InvoiceNo;
                    ObjBALClass.ObjPurchaseReturn.ItemName = ReturnPurchaseList[i].ItemName;
                    ObjBALClass.ObjPurchaseReturn.ItemNo = ReturnPurchaseList[i].ItemNo;
                    ObjBALClass.ObjPurchaseReturn.AccountID = 1;
                    //DateTime timeWithLocal = new DateTime(DTP_Date.Value.Year, DTP_Date.Value.Month, DTP_Date.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    //ObjBALClass.ObjPurchaseReturn.ReturnDate = timeWithLocal;
                    ObjBALClass.ObjPurchaseReturn.ItemQuantity = ReturnPurchaseList[i].ItemQuantity;
                    ObjBALClass.ObjPurchaseReturn.ItemUnitPrice = ReturnPurchaseList[i].ItemUnitPrice;
                    ObjBALClass.ObjPurchaseReturn.Reason = "PR";
                    ObjBALClass.ObjPurchaseReturn.ModifiedBy = GeneralFunction.UserId;
                    ObjBALClass.ObjPurchaseReturn.Status = 2;
                    ObjBALClass.ObjPurchaseReturn.ItemCost = ReturnPurchaseList[i].ItemCost;/// to fix the issue when close the invoice
                    //  ObjBALClass.ObjPurchaseReturn.ItemCost = (ReturnPurchaseList[i].ItemUnitPrice *(ReturnPurchaseList[i].ItemPackage==0||ReturnPurchaseList[i].ItemPackage==null?1:ReturnPurchaseList[i].ItemPackage));
                    //ObjBALClass.ObjPurchaseReturn.ItemCost = ReturnPurchaseList[i].ItemUnitPrice * ReturnPurchaseList[i].ItemQuantity; 
                    ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = ReturnPurchaseList[i].ItemExpiryDate;
                    ObjBALClass.ObjPurchaseReturn.PurchaseID = ReturnPurchaseList[i].PurchaseID;
                    ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = ReturnPurchaseList[i].PurchaseDetailsId;
                    if (ObjBALClass.CloseInvoice())
                    {
                        isProcessTrue = true;
                    }
                }
            }
        }

        internal void LoadInvoiceIDNewYearID()
        {
              List<PurchaseObjectClass> ReturnDetailsList ;
            try
            {
                ReturnDetailsList = ObjBALClass.GetInvoiceReturnDetailsID();
                if (ReturnDetailsList.Count > 0)
                {
                    //foreach (var list in ReturnDetailsList)
                    //{
                    //    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = list.PurchaseReturnID;
                    //    ObjBALClass.ObjPurchaseReturn.Year = list.Year;
                    //    ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = list.NewYearInvoiceID;
                    //}
                    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ReturnDetailsList[0].PurchaseReturnID;
                    ObjBALClass.ObjPurchaseReturn.Year = ReturnDetailsList[0].Year;
                    ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = ReturnDetailsList[0].NewYearInvoiceID;
                    GetInvoiceRecordBasedOnID();
                }
                else
                {
                    InvoiceIDNewYearID();
                    IsfromNewInv = isFromElse = true;
                    if (SavePurchaseReturnDetails())
                        ID[1] = InvoiceIDDetails[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReturnDetailsList = null;
            }
        }

        internal void GetInvoiceRecordBasedOnID()
        {
            ReturnPurchaseList.Clear();
            ReturnItemDetailsList.Clear();
            List<PurchaseObjectClass> objlist = ObjBALClass.GetReturnInvoiceList();
            if (objlist.Count > 0)
            {
                //foreach (var list in objlist)Commended on 23/06/2014 To fixed the Performance issue By Meena.R
                //{
                //    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = list.PurchaseReturnID;
                //    ObjBALClass.ObjPurchaseReturn.SupplierNo = list.SupplierNo;
                //    ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = list.NewYearInvoiceID;
                //    ObjBALClass.ObjPurchaseReturn.ReturnDate = list.ReturnDate;
                //    ObjBALClass.ObjPurchaseReturn.Year = list.Year;
                //    ObjBALClass.ObjPurchaseReturn.SupplierName = list.SupplierName;
                //    ObjBALClass.ObjPurchaseReturn.Status = list.Status;
                //    ReturnPurchaseList.Add(new PurchaseObjectClass
                //    {
                //        ItemNo = list.ItemNo,
                //        ItemName = list.ItemName,
                //        ItemExpiry = list.ItemExpiryDate == DateTime.MinValue ? "-" : list.ItemExpiryDate.Value.ToShortDateString(),
                //        ItemPackage = list.ItemPackage,
                //        ItemQuantity = list.ItemQuantity,
                //        ItemUnitPrice = Convert.ToDecimal(list.ItemUnitPrice.ToString("#####0.000")),
                //        ItemTotal = Convert.ToDecimal(list.ItemTotal.ToString("#####0.000")),
                //        InvoiceNo = list.InvoiceNo,
                //        PurchaseDetailsId = list.PurchaseDetailsId,
                //        PurchaseID = list.PurchaseID,
                //        ItemCost = Convert.ToDecimal(list.ItemCost.ToString("#####0.000")),
                //        ItemExpiryDate = list.ItemExpiryDate,
                //        ItemSerialNo = list.ItemSerialNo,
                //        NewCost = Convert.ToDecimal(list.NewCost.ToString("#####0.000")),
                //        User = list.User,
                //        ItemNumber = list.ItemNumber,
                //        Time = list.Time
                //    });
                //}
                ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = objlist[0].PurchaseReturnID;
                ObjBALClass.ObjPurchaseReturn.SupplierNo = objlist[0].SupplierNo;
                ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = objlist[0].NewYearInvoiceID;
                ObjBALClass.ObjPurchaseReturn.ReturnDate = objlist[0].ReturnDate;
                ObjBALClass.ObjPurchaseReturn.Year = objlist[0].Year;
                ObjBALClass.ObjPurchaseReturn.SupplierName = objlist[0].SupplierName;
                ObjBALClass.ObjPurchaseReturn.Status = objlist[0].Status;
                ReturnPurchaseList = objlist.ToList();
                ObjBALClass.ObjPurchaseReturn.ItemTotal = ReturnPurchaseList.Sum(a => a.ItemTotal);
                ReturnItemDetailsList = ObjBALClass.LoadPurchaseReturnList();
            }
            else
            {
                ObjBALClass.ObjPurchaseReturn.InvoiceFlag = "PurchaseReturnInvoice";
                List<long> ID = ObjBALClass.GetInvoiceNoForEmptyRecord();
                if (ID.Count > 0)
                {
                    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[0];
                    ObjBALClass.ObjPurchaseReturn.Year = Convert.ToInt32(ID[1]);
                    ObjBALClass.ObjPurchaseReturn.NewYearInvoiceID = Convert.ToInt32(ID[2]);
                    ObjBALClass.ObjPurchaseReturn.Status = 1;
                }
                else
                    GeneralFunction.ErrInfo("Recordnotfound", "PurchaseReturnInvoice");
            }
        }

        internal Boolean SavePurchaseReturnDetails()
        {
            if (IsfromNewInv)
            {
                ObjBALClass.ObjPurchaseReturn.ItemNo = 0;
                ObjBALClass.ObjPurchaseReturn.AccountID = 0;
                ObjBALClass.ObjPurchaseReturn.CreatedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchaseReturn.ModifiedBy = GeneralFunction.UserId;
                ObjBALClass.ObjPurchaseReturn.ReturnDate = DateTime.Now;
                ObjBALClass.ObjPurchaseReturn.Status = 1;
                ObjBALClass.ObjPurchaseReturn.Reason = String.Empty;
                ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = 0;
                ObjBALClass.ObjPurchaseReturn.NewCost = 0.0m;
                ObjBALClass.ObjPurchaseReturn.ItemQuantity = 0;
                ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = null;
                ObjBALClass.ObjPurchaseReturn.ItemUnitPrice = 0.0m;
                ObjBALClass.ObjPurchaseReturn.ItemCost = 0.0m;
                ObjBALClass.ObjPurchaseReturn.ItemSerialNo = "0";
                ObjBALClass.ObjPurchaseReturn.SupplierNo = 0;
                //ObjBALClass.ObjPurchaseReturn.SupplierName = 0;
                if (ObjBALClass.SavePurchaseReturn())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public void btnModifyInvoice()
        {
            if (GeneralFunction.Question("AlertModifyInvoice", "PurchaseReturnInvoice") == DialogResult.Yes)
            {
                if (ObjBALClass.ModifyInvoice())
                    isProcessTrue = true;
            }
            else
                return;
        }

        public void btnUndoReturn()
        {
            int iReturn = ReturnPurchaseList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemCost == ObjBALClass.ObjPurchaseReturn.ItemCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID));
            ObjBALClass.ObjPurchaseReturn.NewCost = ReturnPurchaseList[iReturn].NewCost;
            int iItem = ReturnItemDetailsList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (Convert.ToDecimal(((a.NewCost * 1000) / 1000m).ToString("#####0.000")) == ObjBALClass.ObjPurchaseReturn.NewCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID));
            if (ReturnPurchaseList[iReturn].ItemQuantity > 0)
            {
                if (ReturnPurchaseList[iReturn].ItemQuantity >= ObjBALClass.ObjPurchaseReturn.ReturnQty)
                {
                    UndoPurchaseReturn();
                    if (isProcessTrue)
                    {
                        if (!ObjBALClass.ObjPurchaseReturn.CheckNote)
                        {

                            ReturnPurchaseList[iReturn].ItemQuantity = ReturnPurchaseList[iReturn].ItemQuantity - ObjBALClass.ObjPurchaseReturn.ReturnQty;
                            ReturnPurchaseList[iReturn].ItemTotal = ReturnPurchaseList[iReturn].ItemQuantity * ReturnPurchaseList[iReturn].ItemUnitPrice;
                            ReturnItemDetailsList[iItem].PurchaseQuantity = ReturnItemDetailsList[iItem].PurchaseQuantity + ObjBALClass.ObjPurchaseReturn.ReturnQty;
                            ReturnItemDetailsList[iItem].ItemTotal = ReturnItemDetailsList[iItem].PurchaseQuantity * ReturnItemDetailsList[iItem].PurchaseCost;
                            ReturnItemDetailsList[iItem].ReturnQty = Convert.ToInt32(ReturnItemDetailsList[iItem].ReturnQty - ObjBALClass.ObjPurchaseReturn.ReturnQty);
                            if (ReturnPurchaseList[iReturn].ItemQuantity == 0)
                                ReturnPurchaseList.RemoveAt(iReturn);
                            ObjBALClass.ObjPurchaseReturn.ItemTotal = ReturnPurchaseList.Sum(a => a.ItemTotal);
                        }
                        else if (ObjBALClass.ObjPurchaseReturn.CheckNote)
                        {
                            // foreach (int a in al)
                            //  {
                            ReturnPurchaseList.Clear();
                            ObjBALClass.ObjPurchaseReturn.ItemTotal = 0.000m;
                            // }
                            //al.Clear();
                        }
                    }
                }
                else
                {
                    GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("UndoReturnQtylessthanReturnedQty"), GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"));
                }
            }
            else
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("ReturnQtyisZero"), GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"));
            }

        }

        private void UndoPurchaseReturn()
        {
            int index = ReturnPurchaseList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemCost == ObjBALClass.ObjPurchaseReturn.ItemCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID) && (a.PurchaseDetailsId == ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId));
            ObjBALClass.ObjPurchaseReturn.InvoiceNo = ReturnPurchaseList[index].InvoiceNo;
            ObjBALClass.ObjPurchaseReturn.ItemName = ReturnPurchaseList[index].ItemName;
            ObjBALClass.ObjPurchaseReturn.AccountID = ReturnPurchaseList[index].PurchaseDetailsId;
            ObjBALClass.ObjPurchaseReturn.ItemNumber = ReturnPurchaseList[index].ItemNumber;
            if (Convert.ToInt32(ObjBALClass.ObjPurchaseReturn.ReturnQty) < ReturnPurchaseList[index].ItemQuantity)
                ObjBALClass.ObjPurchaseReturn.Status = 2;//Update
            else
                ObjBALClass.ObjPurchaseReturn.Status = 3;//Delete
            if (ObjBALClass.ObjPurchaseReturn.CheckNote)
                ObjBALClass.ObjPurchaseReturn.Status = 3;
            ObjBALClass.ObjPurchaseReturn.ModifiedBy = GeneralFunction.UserId;
            ObjBALClass.ObjPurchaseReturn.ItemCost = ReturnPurchaseList[index].NewCost;
            //DataTable dt = (DataTable)Dgv_ReturnInvoice.DataSource;
            //ObjBALClass.ObjPurchaseReturn.NewCost = ReturnPurchaseList[index].NewCost;
            ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = ReturnPurchaseList[index].ItemExpiryDate;
            ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = ReturnPurchaseList[index].PurchaseDetailsId;
            ObjBALClass.ObjPurchaseReturn.ItemSerialNo = ReturnPurchaseList[index].ItemSerialNo;
            ObjBALClass.ObjPurchaseReturn.NewCost = ReturnPurchaseList[index].NewCost;
            if (!ObjBALClass.ObjPurchaseReturn.CheckNote)
            {
                if (ObjBALClass.ObjPurchaseReturn.ReturnQty > 0)
                {
                    ObjBALClass.ObjPurchaseReturn.ItemQuantity = ObjBALClass.ObjPurchaseReturn.ReturnQty;
                    if (ObjBALClass.ObjPurchaseReturn.ItemQuantity > 0)
                    {
                        if (ObjBALClass.UndoReturnPurchaseInvoice())
                            isProcessTrue = true;
                    }
                }
                else { GeneralFunction.Information("ReturnQtyisZero", "PurchaseReturnInvoice"); }
            }
            else
            {
                List<PurchaseObjectClass> UNDOLIST = ReturnPurchaseList.ToList();
                for (int i = 0; i < UNDOLIST.Count; i++)
                {
                    ObjBALClass.ObjPurchaseReturn.InvoiceNo = UNDOLIST[i].InvoiceNo;
                    ObjBALClass.ObjPurchaseReturn.ItemName = UNDOLIST[i].ItemName;
                    ObjBALClass.ObjPurchaseReturn.ItemNo = UNDOLIST[i].ItemNo;
                    ObjBALClass.ObjPurchaseReturn.ItemNumber = UNDOLIST[i].ItemNumber;
                    ObjBALClass.ObjPurchaseReturn.AccountID = UNDOLIST[i].PurchaseDetailsId;
                    ObjBALClass.ObjPurchaseReturn.ItemQuantity = UNDOLIST[i].ItemQuantity;
                    ObjBALClass.ObjPurchaseReturn.ReturnQty = UNDOLIST[i].ItemQuantity;
                    ObjBALClass.ObjPurchaseReturn.ItemExpiryDate = UNDOLIST[i].ItemExpiryDate;
                    ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId = UNDOLIST[i].PurchaseDetailsId;
                    ObjBALClass.ObjPurchaseReturn.ItemSerialNo = UNDOLIST[i].ItemSerialNo;
                    ObjBALClass.ObjPurchaseReturn.NewCost = UNDOLIST[i].NewCost;
                    ObjBALClass.ObjPurchaseReturn.PurchaseID = UNDOLIST[i].PurchaseID;
                    int add = ReturnItemDetailsList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (Convert.ToDecimal(((a.NewCost * 1000m) / 1000m).ToString("#####0.000")) == ObjBALClass.ObjPurchaseReturn.NewCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID) && (a.PurchaseDetailsId == ObjBALClass.ObjPurchaseReturn.PurchaseDetailsId));
                    if (ObjBALClass.ObjPurchaseReturn.ItemQuantity > 0)
                    {
                        if (ObjBALClass.UndoReturnPurchaseInvoice())
                        {
                            isProcessTrue = true;
                            int ri = ReturnPurchaseList.FindIndex(a => (a.ItemNo == ObjBALClass.ObjPurchaseReturn.ItemNo) && (a.ItemCost == ObjBALClass.ObjPurchaseReturn.ItemCost) && (a.InvoiceNo == ObjBALClass.ObjPurchaseReturn.InvoiceNo) && (a.PurchaseID == ObjBALClass.ObjPurchaseReturn.PurchaseID));
                            if (add > -1)
                            {
                                ReturnItemDetailsList[add].PurchaseQuantity = ReturnItemDetailsList[add].PurchaseQuantity + ObjBALClass.ObjPurchaseReturn.ReturnQty;
                                ReturnItemDetailsList[add].ItemTotal = ReturnItemDetailsList[add].PurchaseQuantity * ReturnItemDetailsList[add].PurchaseCost;
                                ReturnItemDetailsList[add].ReturnQty = Convert.ToInt32(ReturnItemDetailsList[add].ReturnQty - ObjBALClass.ObjPurchaseReturn.ReturnQty);
                            }
                            // al.Add(ri);
                        }
                    }
                }
            }

            //if (ObjBALClass.ObjPurchaseReturn.ItemQuantity > 0)
            //{
            //    if (ObjBALClass.UndoReturnPurchaseInvoice())
            //        isProcessTrue = true;

            //}
        }

        internal void NavigationEvent()
        {

            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:
                    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[0];
                    GetInvoiceRecordBasedOnID();
                    break;
                case InvoiceFlag.Next:
                    if (ObjBALClass.ObjPurchaseReturn.PurchaseReturnID != ID[1])
                    {
                        ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ObjBALClass.ObjPurchaseReturn.PurchaseReturnID + 1;
                        GetInvoiceRecordBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[1];
                        GetInvoiceRecordBasedOnID();
                    }
                    break;
                case InvoiceFlag.Last:
                    ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[1];
                    GetInvoiceRecordBasedOnID();
                    break;
                case InvoiceFlag.Previous:
                    if (ObjBALClass.ObjPurchaseReturn.PurchaseReturnID != ID[0])
                    {
                        ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ObjBALClass.ObjPurchaseReturn.PurchaseReturnID - 1;
                        GetInvoiceRecordBasedOnID();
                    }
                    else
                    {
                        ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = ID[0];
                        GetInvoiceRecordBasedOnID();
                    }
                    break;
                default:
                    long tempID = Convert.ToInt64(ObjBALClass.GetReturnInvoiceNoBasedID());
                    if (tempID != null && tempID != 0)
                    {
                        ObjBALClass.ObjPurchaseReturn.PurchaseReturnID = tempID;
                        GetInvoiceRecordBasedOnID();
                    }
                    else
                        GeneralFunction.Information("Recordnotfound", "PurchaseReturnInvoice");
                    break;
            }
        }

        internal void BalanceAmount()
        {
            GeneralFunction.AgentId.Clear();
            GeneralFunction.AgentId.Add(ObjBALClass.ObjPurchaseReturn.SupplierNo);
            GeneralFunction.AgentDept();
        }

        internal void btnReceiveReceipt()
        {
            List<float> list = ObjBALClass.CheckBalance();
            if (list[1] > 0)
            {
                Receive_Receipt objRec = new Receive_Receipt();
                objRec.NetAmt = list[1].ToString();
                objRec.Value = list[1].ToString();
                objRec.Tag = "PurchaseReturn";
                objRec.Description = "PurchaseReturn" + " " + ObjBALClass.ObjPurchaseReturn.PurchaseReturnID.ToString();
                objRec.ReceiptNo = ObjBALClass.ObjPurchaseReturn.PurchaseReturnID;
                objRec.Balance = list[1].ToString();
                objRec.ReceivedFrom = ObjBALClass.ObjPurchaseReturn.SupplierName;
                objRec.ReceiptNo = ObjBALClass.ObjPurchaseReturn.PurchaseReturnID;
                objRec.ShowDialog();
            }
        }

        public void printfunction()
        {
            try
            {
                ReportsView Obj_viewer = new ReportsView();
                CurrencyConverter ObjCC = new CurrencyConverter();
                Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice");
                decimal Total = 0.000M;
                //string qry = "Select * from View_Purchase_Return where InvoiceNo='" + Txt_ReturnInvoiceNo.Text + "'";
                DataTable dt = new DataTable("SimpleInvoice");
                dt = ObjBALClass.GetReportValue();
                DataTable dtLocal = SpoiledItemHelper.SimpleInvoiceDataTable();
                if (dt.Rows.Count > 0)
                {
                    dt = GeneralFunction.SortInvoiceDetails(dt, "itemName", "Total");
                    GeneralFunction.AgentId.Clear();
                    GeneralFunction.AgentId.Add(dt.Rows[0]["CustomerId"].ToString());
                    GeneralFunction.AgentDept();
                }
                //if (dtLocal.Columns.Count < 22)
                //{
                //    dtLocal.Columns.Add("InvoiceName");
                //    dtLocal.Columns.Add("InvoiceNo");
                //    dtLocal.Columns.Add("InvoiceDate");
                //    dtLocal.Columns.Add("CustomerId");
                //    dtLocal.Columns.Add("CustomerName");
                //    dtLocal.Columns.Add("ItemNo");
                //    dtLocal.Columns.Add("ItemName");
                //    dtLocal.Columns.Add("Expiry");
                //    dtLocal.Columns.Add("Quantity", typeof(int));
                //    dtLocal.Columns.Add("UnitPrice", typeof(decimal));
                //    dtLocal.Columns.Add("Total", typeof(decimal));
                //    dtLocal.Columns.Add("Tax1");
                //    dtLocal.Columns.Add("Tax2");
                //    dtLocal.Columns.Add("Discount", typeof(decimal));
                //    dtLocal.Columns.Add("MaxDept", typeof(decimal));
                //    dtLocal.Columns.Add("TotalDept", typeof(decimal));
                //    dtLocal.Columns.Add("Users");
                //    dtLocal.Columns.Add("TotalLetters");
                //    dtLocal.Columns.Add("Unit");
                //    dtLocal.Columns.Add("LastInvoiceDate", typeof(DateTime));
                //    dtLocal.Columns.Add("AmountDue", typeof(decimal));
                //    dtLocal.Columns.Add("StreetAddress");
                //    dtLocal.Columns.Add("Address2");
                //    dtLocal.Columns.Add("PhoneNo2");
                //    dtLocal.Columns.Add("Barcode");
                //    dtLocal.Columns.Add("DiscountPercentage", typeof(decimal));

                //}
                string tax1 = "0.000", tax2 = "0.000", paramtax1 = "0.000", paramtax2 = "0.000", actualtotal1, actualtotal2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drAdd;
                    drAdd = dtLocal.NewRow();

                    drAdd["InvoiceName"] = GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"); //"Sale Invoice";
                    drAdd["InvoiceNo"] = dt.Rows[i]["InvoiceNo"].ToString();
                    drAdd["InvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["InvoiceDate"].ToString()).ToShortDateString(); ;
                    drAdd["CustomerId"] = dt.Rows[i]["CustomerId"].ToString();
                    drAdd["CustomerName"] = (dt.Rows[i]["CustomerId"].ToString() == "101") ? GeneralFunction.ChangeLanguageforCustomMsg("CashClient") : dt.Rows[i]["CustomerName"].ToString();
                    drAdd["ItemNo"] = dt.Rows[i]["ItemNo"].ToString();
                    drAdd["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                    drAdd["Expiry"] = dt.Rows[i]["Expiry"].ToString();
                    drAdd["Quantity"] = dt.Rows[i]["Quantity"].ToString();
                    drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["Unitprice"].ToString());
                    drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                    drAdd["Tax1"] = Convert.ToDecimal(dt.Rows[i]["Tax1"].ToString());
                    drAdd["Tax2"] = Convert.ToDecimal(dt.Rows[i]["Tax2"].ToString());
                    //drAdd["Tax1"] = Convert.ToDecimal(dt.Rows[i]["mtb_tax"].ToString());
                    //drAdd["Tax2"] = Convert.ToDecimal(dt.Rows[i]["mtb_tax1"].ToString());
                    drAdd["Discount"] = Convert.ToDecimal(dt.Rows[i]["Discount"].ToString());
                    drAdd["MaxDept"] = Convert.ToDecimal((dt.Rows[i]["DebtLimit"] == DBNull.Value ? "0" : dt.Rows[i]["DebtLimit"]).ToString());
                    drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                    drAdd["Users"] = dt.Rows[i]["Users"].ToString();
                    drAdd["TotalLetters"] = "";
                    drAdd["Unit"] = "0";
                    drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"] == DBNull.Value ? null : (dt.Rows[i]["LastInvoiceDate"]));
                    drAdd["AmountDue"] = Convert.ToDecimal((dt.Rows[i]["LastInvoice"] == DBNull.Value ? "0" : dt.Rows[i]["LastInvoice"]).ToString());
                    //drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString();
                    drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                    drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();
                    drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                    //drAdd["DiscountPercentage"] = (Convert.ToDecimal(dt.Rows[i]["discount"].ToString()) /Total)*100;
                    Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());
                    if (Total == 0) { Total = 1; }
                    drAdd["DiscountPercentage"] = (Convert.ToDecimal(dt.Rows[i]["Discount"].ToString()) / Total) * 100;
                    drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["PackageQty"].ToString()) : 1);
                    dtLocal.Rows.Add(drAdd);
                }
                if (dtLocal.Rows.Count > 0)
                {
                    Obj_viewer.Report_Table = dtLocal;
                    Obj_viewer.HTable.Clear();
                    //if (GeneralOptionSetting.FlagInvoiceTemplate == "0" || GeneralOptionSetting.FlagInvoiceTemplate == "4" || GeneralOptionSetting.FlagInvoiceTemplate == "8" || GeneralOptionSetting.FlagInvoiceTemplate == "12" || GeneralOptionSetting.FlagInvoiceTemplate == "13")
                    //{
                    Obj_viewer.HTable.Add("note", "");

                    //}
                    //else
                    if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                    {
                        Obj_viewer.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000")));
                    }

                    Obj_viewer.HTable.Add("IncludeTax", "No");
                    Obj_viewer.HTable.Add("Tax1", "0.000");
                    Obj_viewer.HTable.Add("Tax2", "0.000");
                    Obj_viewer.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                    Obj_viewer.HTable.Add("InvoiceName", GeneralFunction.ChangeLanguageforCustomMsg("PurchaseReturnInvoice"));
                    if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                    {
                        Obj_viewer.HTable.Add("monthformat", 0);
                        Obj_viewer.HTable.Add("dayformat", 0);
                        Obj_viewer.HTable.Add("yearformat", 0);
                        Obj_viewer.HTable.Add("seperatorformat", "/");
                        Obj_viewer.HTable.Add("dateformat", 0);
                    }
                    else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                    {
                        Obj_viewer.HTable.Add("monthformat", 1);
                        Obj_viewer.HTable.Add("dayformat", 1);
                        Obj_viewer.HTable.Add("yearformat", 1);
                        Obj_viewer.HTable.Add("seperatorformat", "/");
                        Obj_viewer.HTable.Add("dateformat", 1);
                    }
                    else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                    {
                        Obj_viewer.HTable.Add("monthformat", 1);
                        Obj_viewer.HTable.Add("dayformat", 1);
                        Obj_viewer.HTable.Add("yearformat", 1);
                        Obj_viewer.HTable.Add("seperatorformat", "-");
                        Obj_viewer.HTable.Add("dateformat", 0);
                    }
                    else
                    {
                        Obj_viewer.HTable.Add("monthformat", 1);
                        Obj_viewer.HTable.Add("dayformat", 1);
                        Obj_viewer.HTable.Add("yearformat", 1);
                        Obj_viewer.HTable.Add("seperatorformat", "/");
                        Obj_viewer.HTable.Add("dateformat", 0);
                    }
                    Obj_viewer.HideLogo = false;
                    Obj_viewer.RptDoc = OrderInvoiceHelper.ReportSelection();
                    Obj_viewer.isInvoice = true;
                    if (Obj_viewer.RptDoc is Rpt_Invoice_80mm || Obj_viewer.RptDoc is Rpt_Invoice_63mm)
                    {
                        Obj_viewer.HTable.Remove("monthformat");
                        Obj_viewer.HTable.Remove("dayformat");
                        Obj_viewer.HTable.Remove("yearformat");
                        Obj_viewer.HTable.Remove("seperatorformat");
                        Obj_viewer.HTable.Remove("dateformat");
                        if (Obj_viewer.RptDoc is Rpt_Invoice_80mm)
                            Obj_viewer.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? true : false);
                    }
                    if (Obj_viewer.RptDoc is Rpt_InvTemplate1 || Obj_viewer.RptDoc is Rpt_InvTemplate2 || Obj_viewer.RptDoc is Rpt_InvTemplate3 || Obj_viewer.RptDoc is Rpt_InvTemplate4 || Obj_viewer.RptDoc is Rpt_InvTemplate5 || Obj_viewer.RptDoc is Rpt_InvTemplate6)// 10-12-2018 Tanzeel Dev 
                    {
                        Obj_viewer.HTable.Add("HideDiscount", true);
                        Obj_viewer.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);

                    }
                    Obj_viewer.HTable.Add("Paid", "0.00");
                    Obj_viewer.InvoiceName = "PurchaseReturnInvoice";
                    //ReportDocument rpt = summery;
                    //Tables tbl = rpt.Database.Tables;
                    //Obj_viewer.Repnum = tbl;
                    Obj_viewer.LoadEvent();
                    Obj_viewer.ShowDialog();

                    //Obj_viewer.LoadReport();
                    //summery.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                    //chk_hidelogo.Checked = chk_printpreview.Checked = false;
                }
                else { GeneralFunction.Information("NoRecordsFound", "PurchaseReturnInvoice"); }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetPurID()
        {
            return ObjBALClass.GetPurchaseID();
        }

        public void FindByInvoiceNo()
        {
            ObjBALClass.ObjPurchaseReturn.SetStatus = 1;
            ObjBALClass.ObjPurchaseReturn.SupplierNo = 1;
            ObjBALClass.ObjPurchaseReturn.FromDate = DateTime.Now;
            ObjBALClass.ObjPurchaseReturn.ToDate = DateTime.Now;
            ReturnItemDetailsList = ObjBALClass.GetReturnDetailsByInvoice();
        }
        public DataTable GetItemDetails()
        {
            DataTable dt= ObjBALClass.ReturnItems();
            if (GeneralOptionSetting.FlagShowHidenItem == "N")
            {
                DataView dataview = new DataView(dt);
                dataview.RowFilter = "IsHide='" + 0 + "'";
                return dataview.ToTable();
            }
            else
            {
                //dataview.RowFilter = "IsHide='" + 0 + "' OR IsHide='" + 1 + "'";
                //return dataview.ToTable();
                return dt;
            }

        }
    }
}
