using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BALHelper;
using ObjectHelper;
using CommonHelper;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using BumedianBM.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using BumedianBM.ArabicView;
using System.Drawing.Printing;
using System.Drawing;

namespace BumedianBM.ViewHelper
{
    public class BarcodePrintHelper
    {
        Dictionary<string, List<ItemCardObjectClass>> dictItemDetsBarcodeHelp = new Dictionary<string, List<ItemCardObjectClass>>();
        ItemCardBALClass ObjItemCardBALClass;
        List<ItemCardObjectClass> ObjStockDetails = new List<ItemCardObjectClass>();
        internal List<ItemCardObjectClass> ObjBarcodeLogo = new List<ItemCardObjectClass>();
        public static List<ItemCardObjectClass> objPrintGrid = new List<ItemCardObjectClass>();
        private ReportDocument summery = null;
        DataTable DT = new DataTable();
        DataRow dr;
        public BarcodePrintHelper()
        {
            ObjItemCardBALClass = new ItemCardBALClass();
            // ObjItemCardBALClass.SetCommonObject();
        }
        public ItemCardBALClass ObjItemCarBAL
        {
            get { return ObjItemCardBALClass; }
            set { ObjItemCardBALClass = value; }
        }
        public Dictionary<string, List<ItemCardObjectClass>> GetItemDetailsWithBarcodeHelp()
        {
            dictItemDetsBarcodeHelp = ObjItemCarBAL.GetItemDetailsWithBarcodeBAL();
            return dictItemDetsBarcodeHelp;
        }
        public int GetStockforItems()
        {
            ObjStockDetails = ObjItemCarBAL.GetItemDetails();
            //return ObjStockDetails[0].StockInHand; this line Commende by Meena.R to get the item stockinhand 06/06/2014
            //return ObjStockDetails.Sum(a => a.StockInHand);this line commended on 25/06/2014 to get the Total stock
            //This is changed to avoid exception when list has no record. Done By A.Manoj On July-14
            int stock = 0;
            if (ObjStockDetails.Count > 0)
                stock = ObjStockDetails[0].TotalStock;
            else
                stock = 0;
            return stock;
            //********************

        }
        public bool AddValidation()
        {
            if (ObjItemCarBAL.Objitemcardobjectclass.ItemId == -1)
            {
                GeneralFunction.Information("EmptyItemName", "Print Barcode");
                ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "cmbItemName";
                return false;
            }
            else if (ObjItemCarBAL.Objitemcardobjectclass.BarSelectedCount <= 0)
            {
                // GeneralFunction.Information("EmptyBarcode", "Print Barcode");
                GeneralFunction.Information("NoBarcodeDetailstoPrint", "Print Barcode"); // changed the barcode message 
                ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "cmbItemName";
                return false;
            }
            else if (ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty == 0)
            {
                GeneralFunction.Information("EmptyQty", "Print Barcode");
                ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "txtQty";
                return false;
            }
            //commented on 30 jun 2014 to avoid the validation for rows and column field 
            ////else if (ObjItemCarBAL.Objitemcardobjectclass.Rows == 0)
            ////{

            ////    GeneralFunction.Information("Rows and Column should not be zero", "Print Barcode");
            ////    ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "txtRow";
            ////    return false;
            ////}
            ////else if (ObjItemCarBAL.Objitemcardobjectclass.Columns == 0)
            ////{

            ////    GeneralFunction.Information("Rows and Column should not be zero", "Print Barcode");
            ////    ObjItemCardBALClass.Objitemcardobjectclass.ValidationString = "txtColumn";
            ////    return false;
            ////}

            else { return true; }
        }

        public DataTable AddData()
        {
            DataRow dr;
            if (GeneralFunction.AddDT.Columns.Count < 5)
            {
                GeneralFunction.AddDT.Columns.Clear();
                GeneralFunction.AddDT.Columns.Add("Id");
                GeneralFunction.AddDT.Columns["Id"].AutoIncrement = true;
                GeneralFunction.AddDT.Columns["Id"].AutoIncrementSeed = 1;
                GeneralFunction.AddDT.Columns["Id"].AutoIncrementStep = 1;
                GeneralFunction.AddDT.Columns.Add("Item");
                GeneralFunction.AddDT.Columns.Add("Barcode");
                GeneralFunction.AddDT.Columns.Add("Row");
                GeneralFunction.AddDT.Columns.Add("Column");
                GeneralFunction.AddDT.Columns.Add("Quantity", typeof(int));
            }
            dr = GeneralFunction.AddDT.NewRow();
            dr["Item"] = ObjItemCarBAL.Objitemcardobjectclass.ItemName;
            dr["Barcode"] = ObjItemCarBAL.Objitemcardobjectclass.Barcode;
            dr["Row"] = ObjItemCarBAL.Objitemcardobjectclass.Rows;
            dr["Column"] = ObjItemCarBAL.Objitemcardobjectclass.Columns;
            dr["Quantity"] = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty;
            GeneralFunction.AddDT.Rows.Add(dr);
            return (GeneralFunction.AddDT);
        }
        public void AddPrintDetails(List<ItemCardObjectClass> listobj)
        {
            List<ItemCardObjectClass> listprice;
            try
            {


                if (listobj.Count > 0)
                    objPrintGrid = listobj;
                decimal Count, Count1, Count2;
                string str, str1;
                char[] ch = { '.' };
                int Qty;
                Qty = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty;
                ObjBarcodeLogo = ObjItemCarBAL.GetBarcodeLogoBAL();
                DT = CommonHelper.ConvertionHelper.ConvertToDataTable<ItemCardObjectClass>(ObjBarcodeLogo);
                listprice = dictItemDetsBarcodeHelp["BarcodeDetails"].Where(a => a.ItemId == ObjItemCarBAL.Objitemcardobjectclass.ItemId).ToList();
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    var itemPrice = listprice.Where(a => (a.ItemId == ObjItemCarBAL.Objitemcardobjectclass.ItemId) && (a.Barcode == ObjItemCarBAL.Objitemcardobjectclass.Barcode));
                    Decimal price = (itemPrice.ToList())[0].Price;
                    DT.Rows[i]["Price"] = price;
                }///this loop added to fix the Issue same price for all the barcode added on 06/06/2014 by Meena.R
                //FileStream fs;
                //BinaryReader br;
                //byte[] imgbyte;
                //if (File.Exists(Convert.ToString(DT.Rows[0]["MTB_FLAG"])) == true)
                //{

                //    //fs = File.Open(DT.Rows[0]["MTB_FLAG"].ToString().Trim(),FileMode.Open ,FileAccess .ReadWrite ,FileShare.None);
                //    fs = new FileStream(Convert.ToString(DT.Rows[0]["MTB_FLAG"]).Trim(), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite) ;

                //    br = new BinaryReader(fs);
                //    imgbyte = new byte[fs.Length + 1];
                //    imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length));
                //    fs.Close();
                //    br.Close();
                //}
                //else
                //{
                //    imgbyte = new byte[1];
                //    imgbyte[0] = 0;
                //}

                if (GeneralFunction.BarcodeDetails.Columns.Count < 4)
                {
                    GeneralFunction.BarcodeDetails.Columns.Add("Id");
                    GeneralFunction.BarcodeDetails.Columns.Add("ItemName");
                    GeneralFunction.BarcodeDetails.Columns.Add("Barcode");
                    GeneralFunction.BarcodeDetails.Columns.Add("Price");
                    GeneralFunction.BarcodeDetails.Columns.Add("Bigprice");
                    GeneralFunction.BarcodeDetails.Columns.Add("NormalPrice");
                    GeneralFunction.BarcodeDetails.Columns.Add("Logo", typeof(byte[]));//System.Type.GetType("System.Byte[]"));
                    GeneralFunction.BarcodeDetails.Columns.Add("CompanyName");//System.Type.GetType("System.Byte[]"));

                }

                if (ObjItemCarBAL.Objitemcardobjectclass.Totalqty == string.Empty)
                {

                    if (ObjItemCarBAL.Objitemcardobjectclass.Rows == 1 && ObjItemCarBAL.Objitemcardobjectclass.Columns == 1)
                    {
                        Qty = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty;
                        GeneralFunction.Tempqty += ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty;
                    }
                    else
                    {
                        GeneralFunction.Tempqtybarcode = ((ObjItemCarBAL.Objitemcardobjectclass.Rows - 1) * ObjItemCarBAL.Objitemcardobjectclass.columncount) + ObjItemCarBAL.Objitemcardobjectclass.Columns - 1;
                        Qty = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty + GeneralFunction.Tempqtybarcode;
                        GeneralFunction.Tempqty += Qty;
                    }
                    for (int i = 0; i < Qty; i++)
                    {
                        if (GeneralFunction.Tempqtybarcode > i)
                        {
                            AddEmptyData("Empty", null);
                        }
                        else
                        {
                            AddEmptyData("Add", GeneralOptionSetting.HeaderLogo);
                        }
                    }
                }
                else
                {
                    int Rcount, Colcount, Totalcount;
                    Rcount = ObjItemCarBAL.Objitemcardobjectclass.Rows;
                    Colcount = ObjItemCarBAL.Objitemcardobjectclass.Columns;
                    Totalcount = ((Rcount - 1) * ObjItemCarBAL.Objitemcardobjectclass.columncount) + (Colcount - 1);
                    if (Totalcount == GeneralFunction.Tempqty)
                    {
                        for (int i = 0; i < Qty; i++)
                        {
                            AddEmptyData("Add", GeneralOptionSetting.HeaderLogo);

                        }
                        GeneralFunction.Tempqty += Qty;
                    }
                    else if (Totalcount > GeneralFunction.Tempqty)
                    {
                        GeneralFunction.Tempqtybarcode = Totalcount - GeneralFunction.Tempqty;
                        Qty = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty + GeneralFunction.Tempqtybarcode;
                        for (int i = 0; i < Qty; i++)
                        {
                            if (GeneralFunction.Tempqtybarcode > i)
                            {
                                AddEmptyData("Empty", null);
                            }
                            else
                            {
                                AddEmptyData("Add", GeneralOptionSetting.HeaderLogo);
                            }
                        }
                        GeneralFunction.Tempqty += Qty;
                    }
                    else
                    {
                        GeneralFunction.Tempqtybarcode = GeneralFunction.Tempqty - Totalcount;
                        Qty = ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty + Totalcount;
                        if (Qty <= GeneralFunction.Tempqty)
                        {
                            for (int i = Totalcount; i < Qty; i++)
                            {
                                AddandReplaceData(GeneralOptionSetting.HeaderLogo, i);
                            }

                        }
                        else
                        {
                            for (int i = Totalcount; i < Qty; i++)
                            {
                                if (GeneralFunction.BarcodeDetails.Rows.Count > i)
                                {
                                    AddandReplaceData(GeneralOptionSetting.HeaderLogo, i);
                                }
                                else
                                {
                                    AddEmptyData("Add", GeneralOptionSetting.HeaderLogo);
                                }
                            }
                            GeneralFunction.Tempqty = Qty;
                        }

                    }

                }

                GeneralFunction.Total += ObjItemCarBAL.Objitemcardobjectclass.BarcodeQty;
                ObjItemCarBAL.Objitemcardobjectclass.Totalqty = GeneralFunction.Total.ToString();
                if (GeneralFunction.Total != 0) ObjItemCarBAL.Objitemcardobjectclass.Totalpages = Convert.ToString(Math.Ceiling((Convert.ToDouble(GeneralFunction.Tempqty)) / ObjItemCarBAL.Objitemcardobjectclass.pagesize));
                else ObjItemCarBAL.Objitemcardobjectclass.Totalpages = string.Empty;


                Count = GeneralFunction.Tempqty; //+ int.Parse(Txt_Qty.Text);
                Count1 = Count / ObjItemCarBAL.Objitemcardobjectclass.columncount;
                Count2 = Count % ObjItemCarBAL.Objitemcardobjectclass.columncount;
                str = Convert.ToString(Math.Floor(Count1) + 1);
                str1 = Convert.ToString(Math.Floor(Count2) + 1);
                ObjItemCarBAL.Objitemcardobjectclass.Rows = Convert.ToInt32(str);
                ObjItemCarBAL.Objitemcardobjectclass.Columns = Convert.ToInt32(str1);
                //string[] str1 = str.Split(ch);
                //if (str1.Length > 1)
                //{
                //    Txt_Row.Text = Convert.ToString(int.Parse(str1[0].ToString()) + 1);
                //    Txt_Column.Text = Convert.ToString((int.Parse(str1[1].ToString()) / 2) + 1);

                //}
                //else
                //{
                //    Txt_Row.Text = Convert.ToString(int.Parse(str1[0].ToString()) + 1);
                //    Txt_Column.Text = "1";
                //}
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                listprice = null;
            }
        }

        private void AddandReplaceData(byte[] imgbyte, int index)
        {
            dr = GeneralFunction.BarcodeDetails.NewRow();
            dr["Id"] = objPrintGrid[GeneralFunction.AddDT.Rows.Count - 1].BarcodeId.ToString();
            dr["ItemName"] = Convert.ToString(DT.Rows[0]["Items"]);
            dr["Barcode"] = GeneralFunction.EAN13(ObjItemCarBAL.Objitemcardobjectclass.Barcode);
            dr["Price"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
            dr["Bigprice"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
            dr["NormalPrice"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
            dr["Logo"] = imgbyte;//Convert.ToString(DT.Rows[0]["MTB_FLAG"]);
            dr["CompanyName"] = GeneralOptionSetting.FlagCompanyName;

            GeneralFunction.BarcodeDetails.Rows.RemoveAt(index);
            GeneralFunction.BarcodeDetails.Rows.InsertAt(dr, index);

        }
        private void AddEmptyData(string empty, byte[] imgbyte)
        {

            if (empty == "Empty")
            {
                dr = GeneralFunction.BarcodeDetails.NewRow();
                dr["Id"] = "";
                dr["ItemName"] = "";
                dr["Barcode"] = "";
                dr["Price"] = "";
                dr["Bigprice"] = "";
                dr["NormalPrice"] = "";
                dr["Logo"] = null;
                dr["CompanyName"] = "";
                GeneralFunction.BarcodeDetails.Rows.Add(dr);

            }
            else
            {
                dr = GeneralFunction.BarcodeDetails.NewRow();
                dr["Id"] = objPrintGrid[GeneralFunction.AddDT.Rows.Count - 1].Id.ToString();
                dr["ItemName"] = Convert.ToString(DT.Rows[0]["Items"]);
                dr["Barcode"] = GeneralFunction.EAN13(ObjItemCarBAL.Objitemcardobjectclass.Barcode);
                dr["Price"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
                dr["Bigprice"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
                dr["NormalPrice"] = Convert.ToDouble(DT.Rows[0]["Price"]).ToString("####0.000");
                dr["Logo"] = imgbyte;//Convert.ToString(DT.Rows[0]["MTB_FLAG"]);
                dr["CompanyName"] = GeneralOptionSetting.FlagCompanyName;
                GeneralFunction.BarcodeDetails.Rows.Add(dr);
            }

        }

        internal void SaveBarcode()
        {

            string filename = string.Empty;
            List<DataTable> LstTable = new List<DataTable>();
            LstTable.Add(GeneralFunction.AddDT);
            LstTable.Add(GeneralFunction.BarcodeDetails);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML Files (*.xml)|*.xml";
            sfd.AddExtension = true;
            sfd.OverwritePrompt = true;
            sfd.Title = "Save Barcode";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                StreamWriter myWriter = new StreamWriter(filename, false);
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<DataTable>));
                mySerializer.Serialize(myWriter, LstTable);
                myWriter.Close();
            }
            else
            {
                return;
            }
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), "Barcode print", "BARCODE", "Save barcode print details", Convert.ToInt32(InvoiceAction.No));

        }

        internal void OpenBarcode()
        {

            string filename = string.Empty;
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Filter = "XML Files (*.xml)|*.xml";
            opfd.AddExtension = true;
            opfd.Title = "Open Barcode";
            if (opfd.ShowDialog() == DialogResult.OK)
            {
                GeneralFunction.AddDT.Rows.Clear();
                GeneralFunction.BarcodeDetails.Rows.Clear();
                List<DataTable> LstTable = new List<DataTable>();
                filename = opfd.FileName.ToString();
                StreamReader myReader = new StreamReader(filename, false);
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<DataTable>));
                LstTable = (List<DataTable>)mySerializer.Deserialize(myReader);
                GeneralFunction.AddDT = (DataTable)LstTable[0];
                GeneralFunction.BarcodeDetails = (DataTable)LstTable[1];
                myReader.Close();
            }

        }

        internal void GeneratePrint()
        {
            summery = new Rpt_Barcode();

            if (GeneralFunction.BarcodeDetails.Rows.Count <= 0)
            {
                GeneralFunction.Information("NoBarcodeDetailstoPrint", "Barcode print");
                return;
            }
            if (GeneralOptionSetting.FlagBarcodePrinter == "1")
            {
                summery = new Rpt_Barcode_BarcodePapper();
            }
            else if (GeneralOptionSetting.FlagBarcodePaperSize == "1")
            {
                summery = new Rpt_Barcode68();
            }
            else if (GeneralOptionSetting.FlagBarcodePaperSize == "2")
            {
                summery = new Rpt_Barcode145();
            }
            else
            {
                summery = new Rpt_Barcode();
            }
            CrystalDecisions.CrystalReports.Engine.ReportObject Logo = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject ItemName = null;
            //CrystalDecisions.CrystalReports.Engine.ReportObject NormalPrice = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Bigprice = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject Barcode = null;
            CrystalDecisions.CrystalReports.Engine.ReportObject CompanyName = null;
            DataTable BarcodeDetails1 = new DataTable();
            BarcodeDetails1.Merge(GeneralFunction.BarcodeDetails);

            if (GeneralOptionSetting.FlagBarcodePaperSize != "2" || GeneralOptionSetting.FlagBarcodePrinter == "1")
            {
                Logo = summery.ReportDefinition.Sections["Details"].ReportObjects["Logo1"];
                ItemName = summery.ReportDefinition.Sections["Details"].ReportObjects["ItemName1"];
                //NormalPrice = summery.ReportDefinition.Sections["Details"].ReportObjects["NormalPrice1"];
                Bigprice = summery.ReportDefinition.Sections["Details"].ReportObjects["BigPrice1"];
                Barcode = summery.ReportDefinition.Sections["Details"].ReportObjects["Barcode1"];
                CompanyName = summery.ReportDefinition.Sections["Details"].ReportObjects["CompanyName1"];
            }
            if (GeneralOptionSetting.FlagBarcodePaperSize == "0" || GeneralOptionSetting.FlagBarcodePrinter == "1")
            {
                if (!ObjItemCarBAL.Objitemcardobjectclass.PriceFlag)
                {
                    if (Bigprice != null) Bigprice.ObjectFormat.EnableSuppress = true;
                    if (Logo != null) Logo.Top += 100;
                    if (CompanyName != null) CompanyName.Top += 100;
                    if (ItemName != null) ItemName.Top += 100;
                    if (Barcode != null) Barcode.Top -= 100;
                }
            }
            else if (GeneralOptionSetting.FlagBarcodePaperSize == "1")
            {
                if (!ObjItemCarBAL.Objitemcardobjectclass.PriceFlag)
                {
                    if (Bigprice != null) Bigprice.ObjectFormat.EnableSuppress = true;
                }
            }
            else if (GeneralOptionSetting.FlagBarcodePaperSize == "2")
            {
                Bigprice = summery.ReportDefinition.Sections["Details"].ReportObjects["BigPrice1"];
                if (!ObjItemCarBAL.Objitemcardobjectclass.PriceFlag)
                {
                    if (Bigprice != null) Bigprice.ObjectFormat.EnableSuppress = true;

                }
            }
            if (GeneralOptionSetting.FlagBarcodePrinter == "1")
            {
                FieldObject field;
                field = summery.ReportDefinition.Sections["Details"].ReportObjects["Barcode1"] as FieldObject;
                Font ft = new Font(field.Font.FontFamily, Convert.ToInt32(GeneralOptionSetting.FlagBarcodeSize));
                field.ApplyFont(ft);

                if (ObjItemCarBAL.Objitemcardobjectclass.PriceFlag && ObjItemCarBAL.Objitemcardobjectclass.BigPriceFlag)
                {
                    FieldObject fieldP;
                    fieldP = summery.ReportDefinition.Sections["Details"].ReportObjects["BigPrice1"] as FieldObject;
                    Font ftP = new Font(fieldP.Font.FontFamily, 24, FontStyle.Bold);
                    fieldP.ApplyFont(ftP);
                }
            }

            ReportsView Obj_viewer = new ReportsView();
            Obj_viewer.Text = GeneralFunction.ChangeLanguageforCustomMsg("BarcodePrint");
            //summery.Refresh();
            Obj_viewer.CompLogo = false;
            BarcodeDetails1.TableName = "BarcodePrint";
            Obj_viewer.Report_Table = BarcodeDetails1;
            Obj_viewer.HTable.Clear();
            Obj_viewer.HTable.Add("IsBigPrice", ObjItemCarBAL.Objitemcardobjectclass.BigPriceFlag);
            Obj_viewer.HTable.Add("IsLogo",(ObjItemCarBAL.Objitemcardobjectclass.PrintLogoFlag));
            Obj_viewer.RptDoc = summery;
            Obj_viewer.IsReportFooter = false;
            Obj_viewer.LoadEvent();

            if (ObjItemCarBAL.Objitemcardobjectclass.PrintPreviewChecked)
            {
                Obj_viewer.ShowDialog();
            }
            else
            {
                // Printer Setup Handling Add these Lines
                CrystalDecisions.Shared.PrintLayoutSettings s = new CrystalDecisions.Shared.PrintLayoutSettings();
                s.Scaling = CrystalDecisions.Shared.PrintLayoutSettings.PrintScaling.Scale;
                s.Centered = true;
                PrinterSettings printerSettings = new PrinterSettings();
                printerSettings.PrinterName = GeneralFunction.PrinterName("Barcode");
                Obj_viewer.RptDoc.PrintToPrinter(printerSettings, new PageSettings(), false, s);
                // 
            }
            GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Print), "Barcode print", "BARCODE", "Print barcode print details", Convert.ToInt32(InvoiceAction.No));
        }
    }
}
