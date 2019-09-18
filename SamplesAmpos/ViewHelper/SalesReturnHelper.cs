using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using System.Data;
using CommonHelper;
using System.Windows.Forms;
using BumedianBM.ArabicView;
using System.Configuration;
using BumedianBM.CrystalReports;

namespace BumedianBM.ViewHelper
{
    public class SalesReturnHelper
    {

        #region Declaration
        public SaleReturnInvoiceBAL objSaleReturnInvoiceBAL;
        public List<SaleReturnObjectClass> lstItem;
        public List<AgentDetailObjectClass> lstClient;
        public List<SaleReturnObjectClass> lstFindDetails;
        public List<SaleReturnObjectClass> lstReturnedDetails;
        internal List<long> InvoiceID = new List<long>();
        internal List<long> ID = new List<long>();
        internal int IDFlag;
        internal decimal RemainingReturnAmt = 0;
        public List<SaleReturnObjectClass> GetSerialNoList = new List<SaleReturnObjectClass>();
        public List<SaleReturnObjectClass> GetPackagQuantityList = new List<SaleReturnObjectClass>();
        public List<SaleReturnObjectClass> GetExpiryDate = new List<SaleReturnObjectClass>();
        public int TypeOfItem;
        #endregion

        #region Constructor
        public SalesReturnHelper()
        {
            objSaleReturnInvoiceBAL = new SaleReturnInvoiceBAL();

            lstReturnedDetails = new List<SaleReturnObjectClass>();
        }
        #endregion

        #region UIDatabaseMethods

        #region Load
        public void Load()
        {
            //lstItem = objSaleReturnInvoiceBAL.GetItemList();
            lstClient = objSaleReturnInvoiceBAL.GetUser();
        }
        #endregion

        #region GetSaleReturnDetailsBal
        public void GetSaleReturnDetailsHelper()
        {

            lstFindDetails = objSaleReturnInvoiceBAL.GetSaleReturnDetailsBal();

        }
        #endregion

        #region NewbtnYearInvoice
        public void NewbtnYearInvoice()
        {
            InvoiceID = objSaleReturnInvoiceBAL.GetYearSequenceMaxIDBal();
        }
        #endregion

        #region SaveSaleReturnDetailsBal
        public bool SaveSaleReturnDetailsHelper()
        {
            return objSaleReturnInvoiceBAL.SaveSaleReturnDetailsBal();

        }
        #endregion

        #region GetMInMaxSaleReturnIDHelper
        public List<long> GetMInMaxSaleReturnIDHelper()
        {
            //List<long> list = objSaleReturnInvoiceBAL.GetMInMaxSaleReturnIdBal();
            //return list;
            return objSaleReturnInvoiceBAL.GetMInMaxSaleReturnIdBal();
        }
        #endregion

        #region GetCurrentYearHelper
        public void GetCurrentYearHelper()
        {
            List<SaleReturnObjectClass> lstCurrentYear;
            try
            {
                lstCurrentYear = objSaleReturnInvoiceBAL.GetCurrentYearBal();
                if (lstCurrentYear.Count > 0)
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.CurrentYear = (lstCurrentYear[0].CurrentYear != null) ? lstCurrentYear[0].CurrentYear : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstCurrentYear = null;
            }

        }
        #endregion

        #region GetYearSequenceHelper
        public List<SaleReturnObjectClass> GetYearSequenceHelper()
        {
            return objSaleReturnInvoiceBAL.GetYearSequenceBal();

        }
        #endregion

        #region GetReturnDetailsBasedOnInvoiceHelpr
        public List<SaleReturnObjectClass> GetReturnDetailsBasedOnInvoiceHelpr()
        {

            return objSaleReturnInvoiceBAL.GetReturnDetailsBasedOnInvoiceBal();

        }
        #endregion

        #region UndoReturnPerItemHelper
        public bool UndoReturnPerItemHelper()
        {
            return objSaleReturnInvoiceBAL.UndoReturnPerItemBal();

        }
        #endregion

        #region GetReturnDetails
        public List<SaleReturnObjectClass> GetReturnDetails()
        {
            return GetReturnDetailsBasedOnInvoiceHelpr();

        }
        #endregion

        #region UndoReturnAllQtyHelper
        public bool UndoReturnAllQtyHelper()
        {
            return objSaleReturnInvoiceBAL.UndoReturnAllQtyBal();

        }
        #endregion

        #region GetStockForUndoHelper
        public List<SaleReturnObjectClass> GetStockForUndoHelper()
        {

            return objSaleReturnInvoiceBAL.GetStockForUndoBal();

        }
        #endregion

        #region SaveReturnInvoiceHelper
        public bool SaveReturnInvoiceHelper()
        {
            return objSaleReturnInvoiceBAL.SaveReturnInvoiceBal();

        }
        #endregion

        #region GetSaleIDHelper
        public List<long> GetSaleIDHelper()
        {
            List<long> list = objSaleReturnInvoiceBAL.GetSaleIDBal();
            return list;
        }
        #endregion

        #region ModifyReturnInvoiceHelper
        public bool ModifyReturnInvoiceHelper()
        {
            return objSaleReturnInvoiceBAL.ModifyReturnInvoiceBal();

        }
        #endregion

        #region CheckBalanceHelper
        public List<decimal> CheckBalanceHelper()
        {
            List<decimal> list = objSaleReturnInvoiceBAL.CheckBalanceBal();
            return list;
        }
        #endregion

        #region GetMaxPaymentIDHelper
        public List<long> GetMaxPaymentIDHelper()
        {
            List<long> list = objSaleReturnInvoiceBAL.GetMaxPaymentIDBal();
            return list;
        }
        #endregion

        #region SavePayReceiptDetailsHelper
        public bool SavePayReceiptDetailsHelper()
        {
            return objSaleReturnInvoiceBAL.SavePayReceiptDetailsBal();

        }
        #endregion
        #region UpdatePayReceiptDetailsHelper
        public bool UpdatePayReceiptDetailsHelper()
        {
            return objSaleReturnInvoiceBAL.UpdatePayReceiptDetailsBal();
        }
        #endregion

        #endregion

        #region UIHelperMethods

        #region GetBalance
        public void GetBalance()
        {
            try
            {
                decimal decTotal = 0, decRec = 0, decBalance = 0; //decBalTotal = 0,

                List<SaleReturnObjectClass> lstBalance = objSaleReturnInvoiceBAL.GetBalanceBal();

                if (lstBalance.Count > 0)
                {
                    for (int i = 0; i < lstBalance.Count; i++)
                    {
                        if (lstBalance[i].AmountRecieved == 0)
                        {
                            decTotal = decTotal + (Convert.ToDecimal(lstBalance[i].NetAmount));
                            decBalance = decTotal;
                        }
                        else
                        {
                            decTotal = decTotal - (Convert.ToDecimal(lstBalance[i].AmountRecieved));
                            decBalance = decTotal;

                        }

                        //if (dtBalance.Rows[i]["MTB_AMT_RECEIVED"].ToString() == "0.0000")
                        //{
                        //    decBalTotal = (decAmt + decRec);
                        //    decBalance = decBalTotal;
                        //}
                        //else
                        //{
                        //    decBalance = (decBalTotal - decRec);
                        //}
                    }

                }

                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Balance = (decBalance != null ? decBalance * Convert.ToDecimal(-1) : 0);

            }
            catch (Exception ex)
            { throw ex; }

        }

        #endregion

        #region GetSaleReturnDetail
        public void GetSaleReturnDetail()
        {
            //List<SaleReturnObjectClass> lstSaleReturnDet = GetSaleReturnDetailsHelper();

        }
        #endregion

        #region ValidateReturnItem

        public bool ValidateReturnItem()
        {

            try
            {
                int able = 1;
                if ((objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemSelectedVal != null) && (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemSelectedVal.ToString() != ""))
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = Convert.ToInt16(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemSelectedVal);
                }
                else
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = 0;
                }
                if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.RadInvoiceCheked == true)
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = 0;
                }

                //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.RadItemCheked == true) //Commented on 4-July-2014 by Seenivasan to check the below validation for Returning by Invoice also
                //{

                if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.dgrSelectedRowCount > 0)
                {
                    if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ReturnQtyText != "")
                    {
                        if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SelectedRowQty < Convert.ToInt32(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ReturnQtyText))
                        {
                            GeneralFunction.Information("QuantityValue", "SaleReturnInvoice");
                            able = 0;
                        }
                    }
                    else
                    {
                        able = 0;
                    }
                }
                else
                {
                    GeneralFunction.Information("NotSelectRowtoReturn", "SaleReturnInvoice");
                    able = 0;
                }

                //  }
                if (able == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex) { throw ex; }

        }

        #endregion

        #region ValidateUndoReturnItem

        public Boolean ValidateUndoReturnItem()
        {

            try
            {
                Boolean able = true;
                if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DgrReturnBacgrndColor != "Color [Gray]")
                {
                    if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DgrReturnSelectdRowCount > 0)
                    {
                        able = true;
                    }
                }
                else
                {
                    GeneralFunction.Information("CantModifyClosedInvoice", "SaleReturnInvoice");
                    able = false;
                }

                return able;
            }
            catch (Exception ex) { throw ex; }

        }

        #endregion

        #region FilterFindList
        public List<SaleReturnObjectClass> FilterFindList()
        {

            var lstFind = from lst in lstFindDetails
                          where lst.saleid == Convert.ToInt64(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SeletedInvoice)
                          select lst;


            return lstFind.ToList();

        }
        #endregion

        #region AddReturnedList

        public void AddReturnedListOnReturn()
        {

            lstReturnedDetails.Add(new SaleReturnObjectClass
            {
                itemno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno,
                ItemName = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName,
                expiry = (Expiryformat(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry.ToString()) == true) ? objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry : DateTime.MinValue,

                package = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.package,
                returnquantity = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity,
                unitprice = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice,
                Total = Convert.ToDecimal(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity),
                Time = DateTime.Now.Hour + ":" + DateTime.Now.Minute,
                user = GeneralFunction.UserId,
                Returned = "Returned",
                saleid = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid,
                SaleReturnID = 0,
                serialno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno,
                saledetid = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid,
                Newexpr = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Newexpr,
                ItemNumber = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemNumber, // This is added due to binding Item Number in the grid
                BarcodeID = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BarcodeID   // This is added due to binding Item Number in the grid

            });

        }

        public void AddReturnedListFromDB()
        {

            lstReturnedDetails.Add(new SaleReturnObjectClass
            {
                itemno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno,
                ItemName = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName,
                expiry = (Expiryformat(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry.ToString()) == true) ? objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry : DateTime.MinValue,

                package = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.package,
                returnquantity = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity,
                unitprice = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice,
                Total = Convert.ToDecimal(objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity),
                Time = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Time,
                user = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user,
                Returned = "Returned",
                saleid = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid,
                SaleReturnID = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaleReturnID,
                serialno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno,
                saledetid = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid,
                Newexpr = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Newexpr,
                ItemNumber = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemNumber,  // This is added due to binding Item Number in the grid
                BarcodeID = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BarcodeID,
                Reason = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Reason
            });

        }

        #endregion

        #region Expiryformat
        public bool Expiryformat(string dateformat)
        {
            try
            {
                char ch;
                if (dateformat.Contains("/"))
                    ch = '/';
                else if (dateformat.Contains("-"))
                    ch = '-';
                else if (dateformat.Contains("."))
                    ch = '.';
                //else if (dateformat.Contains("\"))
                //    ch = '\';
                else ch = ' ';
                string[] datesplit = dateformat.Split(ch);

                if (datesplit.Length >= 3)
                {
                    if ((datesplit[0] == "01") || (datesplit[0] == "1") || (datesplit[0] == "Jan") || (datesplit[0] == "00") || (datesplit[0] == "1900"))
                    {
                        if ((datesplit[1] == "01") || (datesplit[1] == "1") || (datesplit[1] == "Jan") || (datesplit[0] == "00") || (datesplit[0] == "1900"))
                        {
                            if ((datesplit[2].Contains("01")) || (datesplit[2].Contains("1")) || (datesplit[2].Contains("Jan")) || (datesplit[2].Contains("00")) || (datesplit[2].Contains("1900")))
                            {
                                return false;
                            }
                            else return true;
                        }
                        else return true;
                    }
                    else return true;


                }
                return true;


            }
            catch (Exception ex) { throw ex; }

        }
        #endregion

        #region SetNewYearInvoiceNo
        public void SetNewYearInvoiceNo()
        {
            List<SaleReturnObjectClass> lstYearSeq = new List<SaleReturnObjectClass>();
            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Flag = "SaleReturn";
            lstYearSeq = GetYearSequenceHelper();
            if (lstYearSeq.Count > 0)
            {
                if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.CurrentYear != lstYearSeq[0].Year)
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.NewYearInvoiceNo = lstYearSeq[0].Year + "-" + lstYearSeq[0].YearSequenceNo;
                }
                else
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.NewYearInvoiceNo = lstYearSeq[0].YearSequenceNo.ToString();
                }

            }
        }
        #endregion

        #region CloseInvoice
        public void CloseInvoice()
        {
            try
            {
                //Option Settings Checking
                if (lstReturnedDetails.Count == 0)
                {
                    return;
                }
                int enable = 0;
                if (GeneralOptionSetting.FlagDontAlertOnSave != "Y")
                {
                    if (GeneralFunction.Question("AlertCloseInvoice", "SaleReturnInvoice") == DialogResult.Yes)
                    {
                        enable = 1;
                    }
                    else
                        enable = 0;
                }
                else
                    enable = 1;
                if (enable == 0) return;

                // Upto Here //



                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue = 0;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaveReturnInvoice = false;

                if (lstReturnedDetails.Count > 0)
                {

                    for (int i = 0; i < lstReturnedDetails.Count; i++)
                    {
                        //**********Getting SerialNO*******************
                        if (lstReturnedDetails[i].serialno != null)
                        {
                            if ((lstReturnedDetails[i].serialno != "0"))  // "0" changed by manoj due to datatype for serial no is in nvarchar in db
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = lstReturnedDetails[i].serialno;
                            else
                                // objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = 0; // commented by manoj due to datatype for serial no is in nvarchar in db
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = "0";
                        }
                        else
                            //  objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = 0;  // commented by manoj due to datatype for serial no is in nvarchar in db
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.serialno = "0";
                        //*************Upto Here***********************

                        //Getting SalesInvoiceNo
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid = lstReturnedDetails[i].saleid;
                        //Upto Here

                        //*******Getting Client no***************                
                        List<long> lstSaleID = GetSaleIDHelper();//DB Method
                        long retid = 0;
                        if (lstSaleID.Count > 0)
                        {
                            retid = lstSaleID[0];
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno = Convert.ToInt16(lstSaleID[2]);
                        }
                        //**********Upto Here*********************

                        //***Getting Sale Return ID(Need Verification)****    
                        // retid = 1 + retid; //Need To verify for why increase the current Return Invoice Number
                        // objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = retid; //Need To verify for why increase the current Return Invoice Number
                        //********Upto Here************

                        //***********Getting SaleID,ItemNo,Expiry,ReturnQuantity*************************************
                        if (lstReturnedDetails[i].saleid != null)
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid = lstReturnedDetails[i].saleid;
                        if (lstReturnedDetails[i].itemno != null)
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno = lstReturnedDetails[i].itemno;
                        //if (lstReturnedDetails[i].Cells[1].Value != null)
                        //    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.item = lstReturnedDetails[i].Cells[1].Value.ToString();
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.accountid = "1";
                        //if (lstReturnedDetails[i].expiry == "-")
                        //    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = "01/01/1900";
                        //else
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.expiry = lstReturnedDetails[i].expiry == DateTime.MinValue ? null : lstReturnedDetails[i].expiry;

                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity = lstReturnedDetails[i].returnquantity;
                        //*************************Upto Here***************************************************************

                        if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity > 0)
                        {
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice = lstReturnedDetails[i].unitprice;
                            if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.DtpReturnedDateEnabled != true)
                            {
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returndate = DateTime.Now;
                            }

                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue += (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice * objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity);
                            // objSaleReturnInvoiceBAL.objSaleReturnObjectClass.client = txt_returnclient.Text;
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user = GeneralFunction.LoginUserId;
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = Convert.ToInt16(SalesInvoiceType.ClosedInvoice);
                            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saledetid = lstReturnedDetails[i].saledetid;

                            if (lstReturnedDetails[i].SaleReturnID == null)
                                // datagrid_salereturn2.Rows[i].Cells[11].Value = "";
                                lstReturnedDetails[i].SaleReturnID = 0;
                            if (lstReturnedDetails[i].SaleReturnID == 0)
                            {
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.createdby = GeneralFunction.UserId;
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.modifiedby = GeneralFunction.UserId;
                                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;
                                if (SaveReturnInvoiceHelper())//DB Method
                                {
                                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaveReturnInvoice = true;
                                    lstReturnedDetails[i].SaleReturnID = retid;

                                }
                                else
                                    GeneralFunction.Information("SaveInvoice", "SaleReturnInvoice");
                            }
                            else
                            {
                                GeneralFunction.Information("AlreadyInvoiceClosed", "SaleReturnInvoice");
                                goto end;
                            }


                        }
                        else
                        {
                            GeneralFunction.Information("ZeroQty", "SaleReturnInvoice");

                        }


                    }


                    if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SaveReturnInvoice)
                    {

                        if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno != null)
                        {
                            if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno == Convert.ToInt16(CommonHelper.CashClientID.ID))
                            {
                                //PayReceiptForCashClient();//Commented on 4-June-2014
                                //GetMaxIDOFPaymentDetails();//Added on 4-June-2014 // commented on 29/Oct/2018

                                // 29/Oct/2018

                                // here too
                                //objSaleReturnInvoiceBAL.objSaleReturnObjectClass.currentPaymentIDForUpdate = checkPaymentDetails();

                                GetMaxIDOFPaymentDetails();//Added on 4-June-2014
                                //
                            }
                        }


                    }

                }
                else
                {
                    GeneralFunction.Information("EmptyInvoiceList", "SaleReturnInvoice");

                }

                end:;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ModifyInvoice
        public void ModifyInvoice()
        {
            objSaleReturnInvoiceBAL.UpdatePayReceiptDetailsBal();
            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ModifyReturnInvoice = false;
            ////if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.SelectedRowCount != 0)
            ////{Commended by Meena.R on 03/02/2015
            if (ModifyReturnInvoiceHelper())
            {
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ModifyReturnInvoice = true;
                for (int i = 0; i < lstReturnedDetails.Count; i++)
                {
                    lstReturnedDetails[i].SaleReturnID = 0;
                }

            }
            // }

        }
        #endregion

        #region NavigationEvent
        public void NavigationEvent()
        {
            ID = GetMInMaxSaleReturnIDHelper();
            switch ((InvoiceFlag)IDFlag)
            {
                case InvoiceFlag.First:

                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = ID[0];

                    break;
                case InvoiceFlag.Next:
                    if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno != ID[1])
                    {
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno + 1;

                    }
                    else
                    {
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = ID[1];

                    }
                    break;
                case InvoiceFlag.Last:
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = ID[1];

                    break;
                case InvoiceFlag.Previous:
                    if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno != ID[0])
                    {
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno - 1;

                    }
                    else
                    {
                        objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = ID[0];

                    }
                    break;
                default:
                    // objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno = Convert.ToInt64(objSaleInvoiceBAL.GetPurInvIDBasedOnNewYearID());
                    break;
            }
        }
        #endregion

        #region PayReceipt
        public void PayReceipt()
        {
            Boolean ReceiptOpen = false;
            Pay_Receipt objPayReceipt = new Pay_Receipt();
            if (ValidateSaleReturn() != true) { GeneralFunction.Information("ReturnSaleInvoicePayReceipt", "SaleReturnInvoice"); return; }
            List<SaleReturnObjectClass> lstRetDetails = GetReturnDetailsBasedOnInvoiceHelpr();
            if (lstRetDetails.Count > 0)
            {

                objPayReceipt.strPayTo = lstRetDetails[0].ClientName;
                if (objPayReceipt.strPayTo == "CASH CLIENT")
                    ReceiptOpen = false;
                else
                    ReceiptOpen = true;
                objPayReceipt.strPayTo1 = lstRetDetails[0].clientno;
                objPayReceipt.strDiscription = GeneralFunction.ChangeLanguageforCustomMsg("SaleReturnNo") + " " + objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;
                objPayReceipt.strDiscriptionArabic = "ÊÑÌíÚ ãÈíÚÇÊ " + " " + objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;
                //pay.strDiscription1 = "SaleReturnInvoice" + " " + Txt_NewInvoiceNo.Text;
                objPayReceipt.strValue = RemainingReturnAmt.ToString(); //txt_totalreturnvalue.Text;
                objPayReceipt.strFromInvoice = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;//dt.Rows[0]["saleid"].ToString();
                objPayReceipt.strFromInvoiceID = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno; //dt.Rows[0]["saleid"].ToString();
                objPayReceipt.dtPaymentDate = Convert.ToDateTime(DateTime.Now);
                objPayReceipt.strFlag = (int)PayReceiptFor.SaleReturn;//"SaleReturn";
                goto end;

            }
            else
            {
                objPayReceipt.strPayTo = "";
                objPayReceipt.strPayTo1 = 0;
                objPayReceipt.strDiscription = "";
                objPayReceipt.strValue = "";
                objPayReceipt.strFromInvoice = 0;
                objPayReceipt.strFromInvoiceID = 0;
                objPayReceipt.dtPaymentDate = Convert.ToDateTime(DateTime.Now);
                objPayReceipt.strFlag = 0;

            }
            end:; if (ReceiptOpen == true)
                objPayReceipt.ShowDialog();
            else
                GeneralFunction.Information("InvoiceAlreadyAdded", "SaleReturnInvoice");

        }
        #endregion

        #region ValidateSaleReturn
        private Boolean ValidateSaleReturn()
        {
            try
            {
                List<decimal> lstCheckBal = CheckBalanceHelper();
                RemainingReturnAmt = 0;
                if (lstCheckBal.Count > 0)
                {
                    if (lstCheckBal[2] <= 0)
                        return false;
                    else
                    {
                        RemainingReturnAmt = lstCheckBal[2];
                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region PayReceiptForCashClient
        public void PayReceiptForCashClient()
        {
            try
            {

                GetBalance();
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.createdby = GeneralFunction.UserId;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.modifiedby = GeneralFunction.UserId;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returndate = DateTime.Now;
                if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.QuickReturn == false)
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.paydiscription = GeneralFunction.ChangeLanguageforCustomMsg("SaleReturnNo") + " " + objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;
                    //objSaleReturnInvoiceBAL.objSaleReturnObjectClass.totalreturnvalue = 0;///should assign the paying amount for pay receipt from sales return form ///Commented on 4-June-2014 for 
                }
                else
                {
                    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.paydiscription = "QuickReturn" + " " + objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returninvoiceno;

                }
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.user = GeneralFunction.UserId;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = 1;




                // here doing
                //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.currentPaymentIDForUpdate > 0)
                //{
                //    UpdatePayReceiptDetailsHelper();
                //}
                //else
                    SavePayReceiptDetailsHelper();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Print
        public void Print()
        {
            ReportsView frmView = new ReportsView();
            CurrencyConverter ObjCC = new CurrencyConverter();
            frmView.Text = GeneralFunction.ChangeLanguageforCustomMsg("SaleReturnInvoice");
            DataTable dt = new DataTable("SimpleInvoice");
            //objSaleObject.OrderInvoiceNo
            //  long InvoiceNo = Convert.ToInt64(objPerformBAL.objSalObjects.InvoiceText);
            // int Remarks = Convert.ToInt32(OrderRemarks.PI);

            dt = objSaleReturnInvoiceBAL.GetSaleReturnPrintReportBal();
            decimal Total = 0.000M;
            if (dt.Rows.Count > 0)
            {
                dt = GeneralFunction.SortInvoiceDetails(dt, "ItemName", "UnitPrice");
                GeneralFunction.AgentId.Clear();
                GeneralFunction.AgentId.Add(dt.Rows[0]["CustomerId"].ToString());
                GeneralFunction.AgentDept();
            }
            DataTable dtLocal = SpoiledItemHelper.SimpleInvoiceDataTable();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drAdd;
                drAdd = dtLocal.NewRow();
                drAdd["InvoiceName"] = GeneralFunction.ChangeLanguageforCustomMsg("SaleReturnInvoice");
                drAdd["InvoiceNo"] = dt.Rows[i]["newinvno"].ToString();
                drAdd["InvoiceDate"] = dt.Rows[i]["InvoiceDate"].ToString();
                drAdd["CustomerId"] = dt.Rows[i]["CustomerId"].ToString();
                drAdd["CustomerName"] = (dt.Rows[i]["CustomerId"].ToString() == Convert.ToInt16(CommonHelper.CashClientID.ID).ToString()) ? GeneralFunction.ChangeLanguageforCustomMsg("CashClient") : dt.Rows[i]["CustomerName"].ToString();
                drAdd["ItemNo"] = dt.Rows[i]["ItemNo"].ToString();
                drAdd["ItemName"] = dt.Rows[i]["ItemName"].ToString();
                drAdd["Expiry"] = (dt.Rows[i]["Expiry"] != DBNull.Value ? dt.Rows[i]["Expiry"].ToString() : "");
                drAdd["Quantity"] = dt.Rows[i]["Quantity"].ToString();
                drAdd["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"].ToString());
                drAdd["Total"] = Convert.ToDecimal(dt.Rows[i]["total"].ToString());
                drAdd["Tax1"] = Convert.ToDecimal(dt.Rows[i]["tax1"].ToString());
                drAdd["Tax2"] = Convert.ToDecimal(dt.Rows[i]["tax2"].ToString());
                drAdd["Discount"] = 0;// Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                drAdd["MaxDept"] = (dt.Rows[i]["debtlimit"].ToString() != "") ? Convert.ToDecimal(dt.Rows[i]["debtlimit"].ToString()) : 0;
                drAdd["TotalDept"] = GeneralFunction.ClientDebt;
                drAdd["Users"] = dt.Rows[i]["Users"].ToString();
                drAdd["TotalLetters"] = "";
                drAdd["Unit"] = "0";
                drAdd["LastInvoiceDate"] = Convert.ToDateTime(dt.Rows[i]["LastInvoiceDate"] != DBNull.Value ? dt.Rows[i]["LastInvoiceDate"].ToString() : DateTime.MinValue.ToString());
                drAdd["AmountDue"] = Convert.ToDecimal(0.0);
                //  drAdd["StreetAddress"] = dt.Rows[i]["StreetAddress"].ToString();
                // drAdd["Address2"] = dt.Rows[i]["Address2"].ToString();
                // drAdd["PhoneNo2"] = dt.Rows[i]["PhoneNo2"].ToString();

                drAdd["Barcode"] = GeneralFunction.EAN13(dt.Rows[i]["Barcode"].ToString());
                drAdd["DiscountPercentage"] = 0;//Convert.ToDecimal(dt.Rows[i]["MTB_DISCOUNT"].ToString());
                drAdd["Package"] = (Convert.ToInt32(dt.Rows[i]["Package"].ToString()) != 0 ? Convert.ToInt32(dt.Rows[i]["Package"].ToString()) : 1);
                Total += Convert.ToDecimal(dt.Rows[i]["Total"].ToString());

                dtLocal.Rows.Add(drAdd);
            }


            if (dtLocal.Rows.Count > 0)
            {
                frmView.Report_Table = dtLocal;
                frmView.HTable.Clear();

                frmView.HTable.Add("note", "");
                if (GeneralOptionSetting.FlagInvoiceTemplate != "12" && GeneralOptionSetting.FlagInvoiceTemplate != "13")
                { frmView.HTable.Add("TotalLetters", ObjCC.Convert(Total.ToString("####0.000"))); }
                frmView.HTable.Add("IncludeTax", "No");
                frmView.HTable.Add("Tax1", "0.000");
                frmView.HTable.Add("Tax2", "0.000");
                frmView.HTable.Add("OptionNote", GeneralOptionSetting.FlagNoteSaleInvoice);
                frmView.HTable.Add("InvoiceName", Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice"));
                if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yy/M/d")
                {
                    frmView.HTable.Add("monthformat", 0);
                    frmView.HTable.Add("dayformat", 0);
                    frmView.HTable.Add("yearformat", 0);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 0);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "dd/MM/yyyy")
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 1);
                }
                else if (ConfigurationManager.AppSettings["DateFormat"].ToString() == "yyyy-MM-dd")
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "-");
                    frmView.HTable.Add("dateformat", 0);
                }
                else
                {
                    frmView.HTable.Add("monthformat", 1);
                    frmView.HTable.Add("dayformat", 1);
                    frmView.HTable.Add("yearformat", 1);
                    frmView.HTable.Add("seperatorformat", "/");
                    frmView.HTable.Add("dateformat", 0);
                }
                frmView.HideLogo = false;
                //summery = rpt;
                frmView.RptDoc = OrderInvoiceHelper.ReportSelection();// summery;
                //ReportDocument rpt = summery;
                //Tables tbl = rpt.Database.Tables;
                // Obj_viewer.Repnum = tbl;
                frmView.isInvoice = true;
                frmView.InvoiceName = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
                if (frmView.RptDoc is Rpt_Invoice_80mm || frmView.RptDoc is Rpt_Invoice_63mm)
                {
                    frmView.HTable.Remove("monthformat");
                    frmView.HTable.Remove("dayformat");
                    frmView.HTable.Remove("yearformat");
                    frmView.HTable.Remove("seperatorformat");
                    frmView.HTable.Remove("dateformat");
                    if (frmView.RptDoc is Rpt_Invoice_80mm)
                        frmView.HTable.Add("TotalSold", GeneralOptionSetting.FlagPrintTotalQuantity == "Y" ? true : false);
                }
                if (frmView.RptDoc is Rpt_InvTemplate1 || frmView.RptDoc is Rpt_InvTemplate2 || frmView.RptDoc is Rpt_InvTemplate3 || frmView.RptDoc is Rpt_InvTemplate4 || frmView.RptDoc is Rpt_InvTemplate5 || frmView.RptDoc is Rpt_InvTemplate6) // 10-12-2018 Tanzeel Dev 
                {
                    frmView.HTable.Add("HideDiscount", true);
                    frmView.HTable.Add("HideField", GeneralOptionSetting.FlagHideDiscountFiledOnPrint == "Y" ? true : false);

                }

                frmView.HTable.Add("Paid", "0.00");
                frmView.LoadEvent();
                frmView.ShowDialog();
                //if (ObjBALClass.ObjOrder.SetStatus == 1)
                //{
                //    Obj_viewer.ShowDialog();
                //}
                //else
                //{
                //    /// Obj_viewer.LoadReport();
                //    Obj_viewer.RptDoc.PrintToPrinter(GeneralFunction.NoofPrint, true, 0, 0);
                //}
            }
            else
            {
                GeneralFunction.Information("NoRecordsFound", "SaleReturnInvoice");
            }


        }
        #endregion


        #endregion


        public Dictionary<decimal, int> GetUnitPriceForItem()
        {

            return objSaleReturnInvoiceBAL.ItemDetailsPrice();
        }
        public int GetSaleDetailsID()
        {

            return objSaleReturnInvoiceBAL.GetSaleDetailsID();
        }
        public bool ValidationQuickReturn()
        {
            if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.itemno == 0 || objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ItemName == string.Empty)
            {

                GeneralFunction.Information(Constants.ITEMNAME, ActionType.Return.ToString());
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString = "cmbItem";


                return false;
            }

            if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.returnquantity == 0)
            {
                GeneralFunction.Information("ReturnQuantityIsRequired", ActionType.Return.ToString());
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString = "txtQuantity";


                return false;
            }

            //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.unitprice == 0)
            //{
            //    GeneralFunction.Information("AmountisRequired", ActionType.Return.ToString());
            //    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString = "txt_Price";

            //    return false;
            //}
            //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.saleid == 0)
            //{
            //    GeneralFunction.Information("InvoiceNoIsRequired", ActionType.Return.ToString());
            //    objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString = "txtbillno";

            //    return false;
            //}
            if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno == 0 || objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ClientName == string.Empty)
            {
                GeneralFunction.Information("ClientNoIsRequired", ActionType.Return.ToString());
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.ValidationString = "cmbClient";
                return false;


            }
            return true;

        }


        public void GetItemInformation()
        {
            List<SaleReturnObjectClass> listofiteminformation = new List<SaleReturnObjectClass>();
            TypeOfItem = objSaleReturnInvoiceBAL.GetItemInformation();
            if (TypeOfItem == 2)
            {
                GetSerialNoList.Clear();
                GetSerialNoList = objSaleReturnInvoiceBAL.GetSerialNo();
            }
            else
            {
                GetExpiryDate.Clear();
                GetExpiryDate = objSaleReturnInvoiceBAL.Get_ExpiryDatesDetails();

            }
            GetPackagQuantityList = objSaleReturnInvoiceBAL.GetPackageQtyForItemBal();
        }
        public int checkPaymentDetails()
        {
            return objSaleReturnInvoiceBAL.check_PaymentAndPaymentDetails();
        }
        /// <summary>
        /// This method called only from quick retrun order 
        /// </summary>
        public void LoadItemDetails()
        {
            lstClient = objSaleReturnInvoiceBAL.GetUser();
            lstItem = objSaleReturnInvoiceBAL.GetItemPurchasedList();
        }
        public DataTable GetAllItemDetails()
        {
            return objSaleReturnInvoiceBAL.GetItemForReturn();
        }
        public int FindtheSalesItem(Boolean isfrompos)
        {
            return objSaleReturnInvoiceBAL.Get_CountOfSaleItem(isfrompos);
        }
        public void GetMaxIDOFPaymentDetails()
        {
            object GetMaxID;
            GetMaxID = objSaleReturnInvoiceBAL.GetMaxIdRecord();
            int CheckMaxId = Convert.ToInt32(GetMaxID);
            if (CheckMaxId == 0)
            {
                objSaleReturnInvoiceBAL.GetPayReceiptMaxID();
                CreateEmptyRecordOnPaymentDetails();
                //objSaleReturnInvoiceBAL.objSaleReturnObjectClass.Year = Convert.ToInt32(PayReceiptNo[1]);
                //objSaleReturnInvoiceBAL.objSaleReturnObjectClass.YearSequenceNo = PayReceiptNo[2];
                //objSaleReturnInvoiceBAL.objSaleReturnObjectClass.PayReceiptNo = PayReceiptNo[0];
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceAgent = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceFromDate = DateTime.Now;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceToDate = DateTime.Now;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceStatus = "1";
                PayReceiptForCashClient();
                CreateEmptyRecordOnPaymentDetails();
            }
            else
            {
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceAgent = objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceFromDate = DateTime.Now;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceToDate = DateTime.Now;
                objSaleReturnInvoiceBAL.objSaleReturnObjectClass.BalanceStatus = "1";
                PayReceiptForCashClient();
                CreateEmptyRecordOnPaymentDetails();
            }
            PayReceiptHelper printHelper = new PayReceiptHelper();
            printHelper.objPayReceiptBAL.objPayReceiptObject.PayReceiptNo = CheckMaxId;
            printHelper.objPayReceiptBAL.objPayReceiptObject.PayReason = "Quick Return";
            printHelper.IsFromQuickReturn = true;

            //printHelper.PrintReceipt(); //Commented on 27-Oct-2014 by Seenivasan
            if (GeneralOptionSetting.FlagPrintAfterClosingInvoice == "Y") //Added on 27-Oct-2014 by Seenivasan
            {
                printHelper.PrintReceipt();
            }//Commended By Meena.R on 28Oct2014
        }

        private void CreateEmptyRecordOnPaymentDetails()
        {
            //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.currentPaymentIDForUpdate < 1) // added on 31/10/2018 by mansoor
            objSaleReturnInvoiceBAL.GetPayReceiptMaxID();
            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.paydiscription = string.Empty;
            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.status = 1;
            objSaleReturnInvoiceBAL.objSaleReturnObjectClass.clientno = 0;
            //if (objSaleReturnInvoiceBAL.objSaleReturnObjectClass.currentPaymentIDForUpdate > 0)
            //{
            //    UpdatePayReceiptDetailsHelper();
            //}
            //else
                SavePayReceiptDetailsHelper();
        }
        public int UndoReturn()
        {
            return objSaleReturnInvoiceBAL.GetUndoStockCount();
        }
        public int RevertQucikReturn()
        {
            return objSaleReturnInvoiceBAL.UndoQuickRetrun();
        }
        public int SaleIDFromyearSequence()
        {
            return objSaleReturnInvoiceBAL.GetSaleID();
        }
        public List<SaleReturnObjectClass> SortInvoiceDetails(List<SaleReturnObjectClass> lstInvDetail, string ItemColumnName, string PriceColumnName)
        {
            try
            {
                switch (GeneralOptionSetting.FlagItemSorting)
                {
                    case "0":
                        // dt.DefaultView.Sort = ItemColumnName;
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "asc");
                        break;
                    case "1":
                        //dt.DefaultView.Sort = ItemColumnName + " " + "desc";
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, ItemColumnName, "desc");
                        break;
                    case "4":
                        // dt.DefaultView.Sort = PriceColumnName;
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "asc");
                        break;
                    case "3":
                        //dt.DefaultView.Sort = PriceColumnName + " " + "desc";
                        lstInvDetail = SortInvoiceDetailsBal(lstInvDetail, PriceColumnName, "desc");
                        break;
                    default:
                        return lstInvDetail;
                }
                return lstInvDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SaleReturnObjectClass> SortInvoiceDetailsBal(List<SaleReturnObjectClass> lstInvDetail, string SortColumnName, string SortOrder)
        {

            switch (SortOrder)
            {
                case "asc":
                    if (SortColumnName == "ItemName")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemName ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "Price" || SortColumnName == "unitprice")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.unitprice ascending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    break;
                case "desc":
                    if (SortColumnName == "ItemName")
                    {
                        var lstInvDet = from lst in lstInvDetail
                                        orderby lst.ItemName descending
                                        select lst;

                        return lstInvDet.ToList();
                    }
                    else if (SortColumnName == "Price" || SortColumnName == "unitprice")
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

        public DataTable GetItemLoadDetails()
        {
            return objSaleReturnInvoiceBAL.GetItemDetails();
        }
    }
}