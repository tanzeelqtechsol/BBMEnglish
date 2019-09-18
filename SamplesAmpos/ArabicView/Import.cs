using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ObjectHelper;
using BALHelper;
using CommonHelper;
using DataBaseHelper;
using System.Data;
using BumedianBM.ViewHelper;
using DataBaseHelper.DALClass;
namespace BumedianBM.ArabicView
{
    public partial class Import : Form
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;
        object[,] valueArray;
        ItemCardObjectClass itemCardObjectClass;
        ItemCardBALClass objItemCardBALClass;
        MasterDataDALClass objMasterDataDALClass;
        string Path = string.Empty;
        string Paths = string.Empty;
        public bool flag = false;
        bool Validation = false;
        int count = 0;
        decimal NetAmount = 0;
        decimal ExtraCost;
        decimal GrassAmount;
        public Import()
        {
            InitializeComponent();
            itemCardObjectClass = new ItemCardObjectClass();
            objItemCardBALClass = new ItemCardBALClass();
            objMasterDataDALClass = new MasterDataDALClass();
            SetLanguage();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog objOpenFileDialog = new OpenFileDialog();
                objOpenFileDialog.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
                objOpenFileDialog.AddExtension = true;
                objOpenFileDialog.ShowDialog();
                objOpenFileDialog.Title = "Browse Excel file";
                Path = objOpenFileDialog.FileName;
                txtFileName.Text = Path;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        private void Import_Load(object sender, EventArgs e)
        {

            cmbSupplierName.DisplayMember = "Name";
            cmbSupplierName.ValueMember = "AgentID";
            cmbSupplierName.DataSource = ObjectHelper.GeneralObjectClass.SupplierDetails;
            cmbSupplierName.SelectedIndex = -1;
            prgImport.Visible = false;

        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                NetAmount = 0;
                //ExtraCost = 0;
                //GrassAmount = 0;
                if (cmbchooseimport.Text == string.Empty)
                {

                    GeneralFunction.Information("ChooseImportOption", "Import");

                    cmbchooseimport.Focus();
                    return;
                }
                else if (cmbchooseimport.SelectedIndex == 1 && cmbSupplierName.Text == string.Empty)
                {
                    //MessageBox.Show("Please Choose Supplier name");
                    GeneralFunction.Information("EmptySupplierName", "Import");
                    cmbSupplierName.Focus();
                    return;
                }
                else if (Path == string.Empty)
                {
                    GeneralFunction.Information("BrowseFile", "Import");

                    btnBrowse.Focus();
                    return;
                }

                if (flag == false)
                {
                    //CommonHelper.GeneralFunction.Warning("", "AgentDetails");
                    //DialogResult dresult = MessageBox.Show("Please take a backup first", "", MessageBoxButtons.YesNo);
                    //DialogResult dresult = (GeneralFunction.Question("AlertDbBackUp", "BumedienBusinessManagement"));
                    //if (dresult == DialogResult.Yes)
                    //{
                    if (GeneralFunction.Question("BackupImport", "Import") == DialogResult.Yes)
                    {
                        DB_Login dblog = new DB_Login();
                        if ((dblog.ShowDialog() == DialogResult.Cancel))
                        {

                            this.DialogResult = DialogResult.Cancel;

                            return;
                        }
                        else
                        {
                            if (GeneralFunction.Question("AlertDbBackUp", "BumedienBusinessManagement") == DialogResult.Yes)
                            {
                                GeneralFunction._backuppath = GeneralOptionSetting.FlagSaveBackup;
                                GeneralFunction.isAutobackup = false;
                                GeneralFunction.BackupDB();
                                flag = true;
                                GeneralFunction.Information("ClickOnImportButton", "Import");
                                return;
                            }
                            else
                            {

                            }
                            //Option_Seeting ob = new Option_Seeting();
                            //ob.btnSave_Backup_Click(null, null);
                            //btnImport.Focus();
                        }
                    }
                    else
                    {
                        DB_Login dblog = new DB_Login();
                        if ((dblog.ShowDialog() == DialogResult.Cancel))
                        {

                            this.DialogResult = DialogResult.Cancel;

                            return;
                        }
                    }

                }
                //else
                //{
                //    return;
                //}
                //}
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(Path);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                valueArray = (object[,])xlRange.get_Value(
                Excel.XlRangeValueDataType.xlRangeValueDefault);

                //if (cmbchooseimport.Text == "Item Import")
                if (cmbchooseimport.SelectedIndex == 0)
                {
                    objItemCardBALClass.connopen();
                    SQLHelper.Instance.ExecuteQuerey("begin transaction t1");
                    // iterate through each cell and display the contents.
                    prgImport.Visible = true;
                    prgImport.Maximum = xlWorksheet.UsedRange.Rows.Count;
                    for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
                    {
                        prgImport.Value = row;
                        string[] ImportList = new string[xlWorksheet.UsedRange.Columns.Count + 1];
                        for (int col = 1; col <= xlWorksheet.UsedRange.Columns.Count; ++col)
                        {
                            if (valueArray[row, col] == null)
                            {
                                ImportList[col] = string.Empty;
                            }
                            else
                            {
                                ImportList[col] = valueArray[row, col].ToString();
                            }
                        }
                        if (row == 1)
                        {
                            if (ImportList[2].ToLower() == "اسم الصنف".ToLower() && ImportList[3].ToLower() == "رقم الصنف".ToLower() && ImportList[4].ToLower() == "باركود".ToLower() &&
                                ImportList[5].ToLower() == "اسم المجموعة".ToLower() && ImportList[6].ToLower() == "نوع الصنف".ToLower() &&
                                ImportList[7].ToLower().Trim() == "مكان الصنف".ToLower() && ImportList[8].ToLower() == "البيان".ToLower() && ImportList[9].ToLower() == "اسم الشركة".ToLower() &&
                                ImportList[10].ToLower() == "سعر الشراء".ToLower() && ImportList[11].ToLower() == "العدد بالعبوة".ToLower() && ImportList[12].ToLower() == "الصلاحية".ToLower() &&
                                ImportList[13].ToLower() == "سعر البيع".ToLower() && ImportList[15].ToLower() == "اقل سعر".ToLower())
                            {
                            }
                            else
                            {
                                GeneralFunction.Information("FileFormat", "Import");
                                //MessageBox.Show("choose correct file format");
                                xlWorkbook.Close(false);

                                Marshal.ReleaseComObject(xlWorkbook);
                                xlApp.Quit();
                                Marshal.FinalReleaseComObject(xlApp);
                                btnBrowse.Focus();
                                return;
                            }
                        }
                        if (xlWorksheet.UsedRange.Rows.Count == 1)
                        {
                            CloseExcel();
                            GeneralFunction.Information("NoRecordFound", "Import");
                            btnBrowse.Focus();
                            txtFileName.Text = string.Empty;
                            Path = string.Empty;
                            return;

                        }


                        if (row == 2)
                        {
                            if (ImportList[2] == String.Empty && ImportList[2] == String.Empty && ImportList[3] == String.Empty && ImportList[4] == String.Empty &&
                                  ImportList[5] == String.Empty && ImportList[6] == String.Empty &&
                                  ImportList[7] == String.Empty && ImportList[8] == String.Empty && ImportList[9] == String.Empty &&
                                  ImportList[10] == String.Empty && ImportList[11] == String.Empty && ImportList[12] == String.Empty &&
                                  ImportList[13] == String.Empty && ImportList[14] == String.Empty)
                            {
                                CloseExcel();
                                GeneralFunction.Information("NoRecordFound", "Import");
                                // MessageBox.Show("No Records Found");
                                btnBrowse.Focus();
                                txtFileName.Text = string.Empty;
                                Path = string.Empty;
                                return;

                            }

                        }
                        if (row != 1)
                        {

                            if (ImportList[2] == String.Empty && ImportList[2] == String.Empty && ImportList[3] == String.Empty && ImportList[4] == String.Empty &&
                               ImportList[5] == String.Empty && ImportList[6] == String.Empty &&
                               ImportList[7] == String.Empty && ImportList[8] == String.Empty && ImportList[9] == String.Empty &&
                               ImportList[10] == String.Empty && ImportList[11] == String.Empty && ImportList[12] == String.Empty &&
                               ImportList[13] == String.Empty && ImportList[14] == String.Empty)
                            {
                                SQLHelper.Instance.ExecuteQuerey("Commit transaction t1");
                                CloseExcel();
                                GeneralFunction.Information("ItemImportedSuccessfully", "Import");
                                objMasterDataDALClass.GetCategoryDetails();
                                objMasterDataDALClass.GetCompanyDetails();
                                objMasterDataDALClass.ItemDetails();

                                btnBrowse.Focus();
                                txtFileName.Text = string.Empty;
                                return;
                            }




                            if (ImportList[2] == string.Empty)
                            {
                                ErrorMessage objerr = new ErrorMessage();
                                objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "2  Column\n" + " " + "Error is:Item Name Empty";
                                objerr.ShowDialog();
                                if (objerr.sContinue == "YES")
                                {
                                    objerr.Close();
                                    goto next1;
                                }
                                if (objerr.sUndo == "YES")
                                {
                                    objerr.Close();
                                    SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                    SQLHelper.Instance.close();
                                    CloseExcel();
                                    txtFileName.Text = string.Empty;
                                    cmbchooseimport.Focus();

                                    return;
                                }
                            }

                            Double Barcode;
                            bool isBarcode = Double.TryParse(ImportList[4], out Barcode);
                            if (!isBarcode)
                            {

                            }
                            else
                            {
                                //if (ImportList[4].Length != 13)As per requirement we removed this validation on 19\05\2015
                                //{
                                //    ErrorMessage objerr = new ErrorMessage();
                                //    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  4  Column\n" + " " + "Error is:Barcode Error";
                                //    objerr.ShowDialog();
                                //    if (objerr.sContinue == "YES")
                                //    {
                                //        objerr.Close();
                                //        goto next1;
                                //    }
                                //    if (objerr.sUndo == "YES")
                                //    {
                                //        objerr.Close();
                                //        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                //        CloseExcel();
                                //        txtFileName.Text = string.Empty;
                                //        cmbchooseimport.Focus();
                                //        return;
                                //    }
                                //}
                            }

                            List<ComCatObjectClass> CompanyList = CompanyList = ObjectHelper.GeneralObjectClass.CompanyList;
                            itemCardObjectClass.ItemName = ImportList[2];
                            itemCardObjectClass.ItemNumber = ImportList[3];
                            itemCardObjectClass.Barcode = ImportList[4].ToString();
                            if (ImportList[5] == string.Empty)
                            {
                                itemCardObjectClass.CategoryName = "All Categories";
                            }
                            else
                            {
                                itemCardObjectClass.CategoryName = ImportList[5];
                            }

                            if (ImportList[6] == string.Empty)
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            else if (ImportList[6].ToLower() == ("Goods").ToLower())
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            else if (ImportList[6].ToLower() == ("Second Hand").ToLower())
                            {
                                itemCardObjectClass.ItemType = 2;
                            }
                            else if (ImportList[6].ToLower() == ("Labour").ToLower())
                            {
                                itemCardObjectClass.ItemType = 3;
                            }
                            else if (ImportList[6].ToLower() == ("Meal").ToLower())
                            {
                                itemCardObjectClass.ItemType = 4;
                            }
                            else
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            itemCardObjectClass.ItemPlaceName = ImportList[7];
                            itemCardObjectClass.ItemDescription = ImportList[8];

                            if (ImportList[9] == string.Empty)
                            {
                                itemCardObjectClass.CompanyName = "All Company";
                            }
                            else
                            {
                                itemCardObjectClass.CompanyName = ImportList[9];
                            }

                            if (ImportList[10] == string.Empty)
                            {
                                itemCardObjectClass.ItemCost = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                decimal ItemCost;
                                bool isItemCost = decimal.TryParse(ImportList[10], out ItemCost);
                                if (!isItemCost)
                                {
                                    itemCardObjectClass.ItemCost = Convert.ToDecimal("0.00");
                                }
                                else
                                {
                                    itemCardObjectClass.ItemCost = Convert.ToDecimal(ImportList[10]);
                                }

                            }
                            if (ImportList[11] == string.Empty)
                            {
                                itemCardObjectClass.PackageQuantity = 1;
                            }
                            else
                            {
                                itemCardObjectClass.PackageQuantity = Convert.ToInt32(ImportList[11]);
                            }

                            switch (ImportList[12].ToUpper())
                            {
                                case "NO":
                                    itemCardObjectClass.ExpiryDate = false;
                                    break;
                                case "YES":
                                    itemCardObjectClass.ExpiryDate = true;
                                    break;
                                case "TRUE":
                                    itemCardObjectClass.ExpiryDate = true;
                                    break;
                                case "FALSE":
                                    itemCardObjectClass.ExpiryDate = false;
                                    break;
                                default:
                                    itemCardObjectClass.ExpiryDate = false;
                                    break;
                            }

                            if (ImportList[13] == string.Empty)
                            {
                                itemCardObjectClass.Price = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                decimal price;
                                bool isprice = decimal.TryParse(ImportList[13], out price);
                                if (!isprice)
                                {
                                    itemCardObjectClass.Price = Convert.ToDecimal("0.00");
                                }
                                else
                                {
                                    itemCardObjectClass.Price = Convert.ToDecimal(ImportList[13]);
                                }
                            }
                            if (ImportList[14] == string.Empty)
                            {
                                itemCardObjectClass.WholeSalePrice = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                decimal WholeSalePrice;
                                bool isWholeSalePrice = decimal.TryParse(ImportList[14], out WholeSalePrice);
                                if (!isWholeSalePrice)
                                {
                                    itemCardObjectClass.WholeSalePrice = Convert.ToDecimal("0.00");
                                }
                                else
                                {

                                    itemCardObjectClass.WholeSalePrice = Convert.ToDecimal(ImportList[14]);
                                }

                            }

                            if (ImportList[15] == string.Empty)
                            {
                                itemCardObjectClass.MinPrice = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                decimal MinPrice;
                                bool isMinPrice = decimal.TryParse(ImportList[15], out MinPrice);
                                if (!isMinPrice)
                                {
                                    itemCardObjectClass.MinPrice = Convert.ToDecimal("0.00");
                                }
                                else
                                {
                                    itemCardObjectClass.MinPrice = Convert.ToDecimal(ImportList[15]);
                                }
                            }

                            itemCardObjectClass.CreatedBy = GeneralFunction.UserId;
                            itemCardObjectClass.ModifiedBy = GeneralFunction.UserId;
                            itemCardObjectClass.Status = 1;

                            //    itemCardObjectClass.Price = itemCardObjectClass.Price * Convert.ToInt32(txtRate.Text);
                            //    itemCardObjectClass.MinPrice = itemCardObjectClass.MinPrice * Convert.ToInt32(txtRate.Text);
                            //    itemCardObjectClass.UnitPrice = itemCardObjectClass.UnitPrice * Convert.ToInt32(txtRate.Text);
                            //itemCardObjectClass.ItemCost = itemCardObjectClass.ItemCost * Convert.ToInt32(txtRate.Text);
                            //itemCardObjectClass.WholeSalePrice = itemCardObjectClass.WholeSalePrice * Convert.ToInt32(txtRate.Text);


                        }
                        if (row != 1)
                        {
                            objItemCardBALClass.saveItemcardimport(itemCardObjectClass);
                        }

                    next1:
                        count++;

                    }
                    SQLHelper.Instance.ExecuteQuerey("Commit transaction t1");
                    CloseExcel();
                    GeneralFunction.Information("ItemImportedSuccessfully", "Import");

                    //   MessageBox.Show("imported successfully");
                    prgImport.Visible = false;
                    objMasterDataDALClass.GetCategoryDetails();
                    objMasterDataDALClass.GetCompanyDetails();
                    objMasterDataDALClass.ItemDetails();


                }
                //else if (cmbchooseimport.Text == "Purchase Invoice Import")
                else if (cmbchooseimport.SelectedIndex == 1)
                {
                    objItemCardBALClass.connopen();
                    SQLHelper.Instance.ExecuteQuerey("begin transaction t1");
                    // iterate through each cell and display the contents.
                    prgImport.Visible = true;
                    prgImport.Maximum = xlWorksheet.UsedRange.Rows.Count;

                    GetNetAmount();
                    if (Validation == true)
                    {
                        txtFileName.Text = string.Empty;
                        btnBrowse.Focus();
                        return;
                    }
                    DataTable objdt = new DataTable();
                    objdt = objItemCardBALClass.GetInvoice();
                    if (objdt.Rows.Count > 0)
                    {
                        itemCardObjectClass.Year = Convert.ToInt32(objdt.Rows[0]["YearValue"]);
                        itemCardObjectClass.PurchaseInvoiceId = Convert.ToInt32(objdt.Rows[0]["MaxId"]);
                        itemCardObjectClass.yearSequence = Convert.ToInt32(objdt.Rows[0]["YearMaxId"]);
                    }
                    itemCardObjectClass.CreatedBy = GeneralFunction.UserId;
                    itemCardObjectClass.ModifiedBy = GeneralFunction.UserId;
                    itemCardObjectClass.NetAmount = NetAmount;
                    itemCardObjectClass.AgentName = cmbSupplierName.Text;
                    itemCardObjectClass.GrassAmount = GrassAmount;

                    itemCardObjectClass.PurchaseID = objItemCardBALClass.savePurchase(itemCardObjectClass);
                    for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
                    {
                        prgImport.Value = row;
                        string[] ImportList = new string[xlWorksheet.UsedRange.Columns.Count + 1];
                        for (int col = 1; col <= xlWorksheet.UsedRange.Columns.Count; ++col)
                        {
                            if (row == 1)
                            {
                                flag = false;
                                if (valueArray[row, col] == null)
                                {
                                    ImportList[col] = string.Empty;
                                }
                                else
                                {
                                    ImportList[col] = valueArray[row, col].ToString();
                                }
                            }
                            else
                            {
                                flag = false;
                                if (valueArray[row, col] == null)
                                {
                                    ImportList[col] = string.Empty;
                                }
                                else
                                {
                                    ImportList[col] = valueArray[row, col].ToString();
                                }
                            }

                        }
                        if (row == 1)
                        {
                            if (ImportList[2].ToLower() == "اسم الصنف".ToLower() && ImportList[3].ToLower() == "رقم الصنف".ToLower() && ImportList[4].ToLower() == "باركود".ToLower() &&
                                ImportList[5].ToLower() == "قطعة".ToLower() && ImportList[6].ToLower() == "اسم المجموعة".ToLower() && ImportList[7].ToLower() == "نوع الصنف".ToLower()
                                && ImportList[10].ToLower() == "العدد بالعبوة".ToLower() && ImportList[11].ToLower() == "الصلاحية".ToLower() &&
                                ImportList[12].ToLower() == "تاريخ الصلاحية".ToLower() && ImportList[13].ToLower() == "سعر البيع".ToLower())
                            {
                            }
                            else
                            {
                                GeneralFunction.Information("FileFormat", "Import");
                                xlWorkbook.Close(false);

                                Marshal.ReleaseComObject(xlWorkbook);
                                xlApp.Quit();
                                Marshal.FinalReleaseComObject(xlApp);
                                btnBrowse.Focus();
                                return;
                            }
                        }

                        if (row != 1)
                        {

                            if (ImportList[2] == String.Empty && ImportList[2] == String.Empty && ImportList[3] == String.Empty && ImportList[4] == String.Empty &&
                               ImportList[5] == String.Empty && ImportList[6] == String.Empty &&
                               ImportList[7] == String.Empty && ImportList[8] == String.Empty && ImportList[9] == String.Empty &&
                               ImportList[10] == String.Empty && ImportList[11] == String.Empty && ImportList[12] == String.Empty &&
                               ImportList[13] == String.Empty && ImportList[14] == String.Empty)
                            {
                                SQLHelper.Instance.ExecuteQuerey("Commit transaction t1");
                                CloseExcel();
                                GeneralFunction.Information("PurchaseImportedSuccessfully", "Import");
                                objMasterDataDALClass.GetCategoryDetails();
                                objMasterDataDALClass.GetCompanyDetails();
                                objMasterDataDALClass.ItemDetails();

                                btnBrowse.Focus();
                                txtFileName.Text = string.Empty;
                                return;
                            }
                            if (ImportList[2] == string.Empty)
                            {
                                ErrorMessage objerror = new ErrorMessage();
                                objerror.error = "Error at" + " " + ImportList[1] + "  Row" + "2  Column\n" + " " + "Error is:Item Name Empty";
                                objerror.enable = false;
                                objerror.ShowDialog();

                                //if (objerr.sContinue == "YES")
                                //{
                                //    objerr.Close();
                                //    goto next;
                                //}
                                if (objerror.sUndo == "YES")
                                {
                                    objerror.Close();
                                    SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                    SQLHelper.Instance.close();
                                    CloseExcel();
                                    txtFileName.Text = string.Empty;
                                    cmbchooseimport.Focus();
                                    return;
                                }
                            }

                            Double Barcode;
                            bool isBarcode = Double.TryParse(ImportList[4], out Barcode);
                            if (!isBarcode)
                            {
                                itemCardObjectClass.Barcode = string.Empty;
                            }
                            else
                            {
                                if (ImportList[4].Length != 13)
                                {
                                    ErrorMessage objerr = new ErrorMessage();
                                    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  4  Column\n" + " " + "Error is:Barcode Error";
                                    objerr.enable = false;
                                    objerr.ShowDialog();
                                    if (objerr.sUndo == "YES")
                                    {
                                        objerr.Close();
                                        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                        CloseExcel();
                                        txtFileName.Text = string.Empty;
                                        cmbchooseimport.Focus();
                                        return;
                                    }
                                }
                            }
                            int UnitQuantity;
                            bool isUnitQuantity = int.TryParse(ImportList[5], out UnitQuantity);
                            if (!isUnitQuantity && UnitQuantity != 0)
                            {

                            }
                            else
                            {

                                if (ImportList[5] == string.Empty)
                                {
                                    ErrorMessage objerr = new ErrorMessage();
                                    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  5 Column\n" + " " + "Error is:Quantity";
                                    objerr.enable = false;
                                    objerr.ShowDialog();
                                    if (objerr.sUndo == "YES")
                                    {
                                        objerr.Close();
                                        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                        CloseExcel();
                                        txtFileName.Text = string.Empty;
                                        cmbchooseimport.Focus();
                                        return;
                                    }
                                }
                            }
                            //decimal Price;
                            //bool isPrice = decimal.TryParse(ImportList[6], out Price);
                            //if (!isPrice && Price <= 0 )
                            //{
                            //    itemCardObjectClass.Price = Convert.ToDecimal("0.00");
                            //}
                            //else
                            //{
                            //    if (ImportList[6] == string.Empty  )
                            //    {
                            //        ErrorMessage objerr = new ErrorMessage();
                            //        objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  6  Column\n" + " " + "Error is: Price";
                            //        objerr.enable = false;
                            //        objerr.ShowDialog();
                            //        if (objerr.sUndo == "YES")
                            //        {
                            //            objerr.Close();
                            //            SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                            //            CloseExcel();
                            //            txtFileName.Text = string.Empty;
                            //            cmbchooseimport.Focus();
                            //            return;
                            //        }
                            //    }

                            //}
                            decimal ItemCost;
                            bool isItemCost = decimal.TryParse(ImportList[9], out ItemCost);
                            if (!isItemCost && ItemCost != 0)
                            {

                            }
                            else
                            {
                                if (ImportList[9] == string.Empty)
                                {
                                    ErrorMessage objerr = new ErrorMessage();
                                    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  10 Column\n" + " " + "Error is :ItemCost";
                                    objerr.enable = false;
                                    objerr.ShowDialog();
                                    if (objerr.sUndo == "YES")
                                    {
                                        objerr.Close();
                                        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                        CloseExcel();
                                        txtFileName.Text = string.Empty;
                                        cmbchooseimport.Focus();
                                        return;
                                    }
                                }
                            }
                            decimal price;
                            bool isprice = decimal.TryParse(ImportList[13], out price);
                            if (!isprice && price != 0)
                            {
                                itemCardObjectClass.UnitPrice = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                if (ImportList[13] == string.Empty)
                                {
                                    ErrorMessage objerr = new ErrorMessage();
                                    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  14 Column\n" + " " + "Error is: Item Price";
                                    objerr.enable = false;
                                    objerr.ShowDialog();
                                    if (objerr.sUndo == "YES")
                                    {
                                        objerr.Close();
                                        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                        CloseExcel();
                                        txtFileName.Text = string.Empty;
                                        cmbchooseimport.Focus();
                                        return;
                                    }
                                }
                            }

                            // List<ComCatObjectClass> CompanyList = CompanyList = ObjectHelper.GeneralObjectClass.CompanyList;
                            itemCardObjectClass.ItemName = ImportList[2];
                            itemCardObjectClass.ItemNumber = ImportList[3];
                            itemCardObjectClass.Barcode = ImportList[4].ToString();
                            itemCardObjectClass.UnitQuantity = ImportList[5];
                            //itemCardObjectClass.UnitPrice = Convert.ToDecimal(ImportList[6]);
                            itemCardObjectClass.UnitPrice = Convert.ToDecimal(ImportList[9]) / (ImportList[10] == string.Empty || Convert.ToInt32(ImportList[10]) <= 0 ? 1 : Convert.ToInt32(ImportList[10]));
                            itemCardObjectClass.ItemCost = Convert.ToDecimal(ImportList[9]);
                            itemCardObjectClass.Price = Convert.ToDecimal(ImportList[13]);

                            if (ImportList[6] == string.Empty)
                            {
                                itemCardObjectClass.CategoryName = "All Categories";
                            }
                            else
                            {
                                itemCardObjectClass.CategoryName = ImportList[6];
                            }
                            if (ImportList[7] == string.Empty)
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            else if (ImportList[7].ToLower() == ("Goods").ToLower())
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            //else if (ImportList[8].ToLower() == ("Second Hand").ToLower())
                            //{
                            //    itemCardObjectClass.ItemType = 2;
                            //}
                            //else if (ImportList[8].ToLower() == ("Labour").ToLower())
                            //{
                            //    itemCardObjectClass.ItemType = 3;
                            //}
                            //else if (ImportList[8].ToLower() == ("Meal").ToLower())
                            //{
                            //    itemCardObjectClass.ItemType = 4;
                            //}
                            else
                            {
                                itemCardObjectClass.ItemType = 1;
                            }
                            itemCardObjectClass.ItemPlaceName = string.Empty;
                            itemCardObjectClass.ItemDescription = string.Empty;

                            if (ImportList[8] == string.Empty)
                            {
                                itemCardObjectClass.CompanyName = "All Company";
                            }
                            else
                            {
                                itemCardObjectClass.CompanyName = ImportList[8];
                            }


                            if (ImportList[10] == string.Empty || Convert.ToInt32(ImportList[10]) < 0)
                            {
                                itemCardObjectClass.PackageQuantity = 1;
                            }
                            else
                            {
                                itemCardObjectClass.PackageQuantity = Convert.ToInt32(ImportList[10]);
                            }

                            switch (ImportList[11].ToUpper())
                            {
                                case "NO":
                                    itemCardObjectClass.ExpiryDate = false;
                                    break;
                                case "YES":
                                    itemCardObjectClass.ExpiryDate = true;
                                    break;
                                default:
                                    itemCardObjectClass.ExpiryDate = false;
                                    break;
                            }
                            if (itemCardObjectClass.ExpiryDate == true)
                            {
                                DateTime Checkdate;
                                bool Verifydate = DateTime.TryParse(ImportList[12], out Checkdate);
                                int checkdate = DateTime.Compare(Checkdate, DateTime.Now);
                                if (ImportList[12] == string.Empty || Verifydate == false || checkdate == -1)
                                {
                                    ErrorMessage objerr = new ErrorMessage();
                                    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "14 Column\n" + " " + "Error is:Date ";
                                    objerr.enable = false;
                                    objerr.ShowDialog();
                                    if (objerr.sUndo == "YES")
                                    {
                                        objerr.Close();
                                        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                                        SQLHelper.Instance.close();
                                        CloseExcel();
                                        txtFileName.Text = string.Empty;
                                        cmbchooseimport.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (ImportList[12] == string.Empty)
                                    {
                                        itemCardObjectClass.ItemExpiry = Convert.ToDateTime("1900/01/01");
                                    }
                                    else
                                    {
                                        itemCardObjectClass.ItemExpiry = Convert.ToDateTime(ImportList[12]);
                                    }
                                }
                            }
                            else
                            {

                                itemCardObjectClass.ItemExpiry = Convert.ToDateTime("1900/01/01");

                            }

                            if (ImportList[14] == string.Empty)
                            {
                                itemCardObjectClass.WholeSalePrice = Convert.ToDecimal("0.00");
                            }
                            else
                            {

                                int WholeSalePrice;
                                bool isWholeSalePrice = int.TryParse(ImportList[14], out WholeSalePrice);
                                if (!isWholeSalePrice || WholeSalePrice < 0)
                                {
                                    itemCardObjectClass.WholeSalePrice = Convert.ToDecimal("0.00");
                                }
                                else
                                {

                                    itemCardObjectClass.WholeSalePrice = Convert.ToDecimal(ImportList[14]);
                                }

                            }

                            if (ImportList[15] == string.Empty)
                            {
                                itemCardObjectClass.MinPrice = Convert.ToDecimal("0.00");
                            }
                            else
                            {
                                int MinPrice;
                                bool isMinPrice = int.TryParse(ImportList[15], out MinPrice);
                                if (!isMinPrice || MinPrice < 0)
                                {
                                    itemCardObjectClass.MinPrice = Convert.ToDecimal("0.00");
                                }
                                else
                                {
                                    itemCardObjectClass.MinPrice = Convert.ToDecimal(ImportList[15]);
                                }

                            }
                            itemCardObjectClass.ExreaCost = ExtraCost;
                            itemCardObjectClass.CreatedBy = GeneralFunction.UserId;
                            itemCardObjectClass.ModifiedBy = GeneralFunction.UserId;
                            itemCardObjectClass.Status = 1;


                            //if (itemCardObjectClass.isForeignCurrency == true)
                            //{
                            if (chkApply.Checked == true)
                            {
                                if (txtRate.Text != string.Empty)
                                {
                                    //itemCardObjectClass.Price = itemCardObjectClass.Price * Convert.ToInt32(txtRate.Text);
                                    //itemCardObjectClass.MinPrice = itemCardObjectClass.MinPrice * Convert.ToInt32(txtRate.Text);
                                    //itemCardObjectClass.UnitPrice = itemCardObjectClass.UnitPrice * Convert.ToInt32(txtRate.Text);
                                    itemCardObjectClass.ItemCost = itemCardObjectClass.ItemCost * Convert.ToDecimal(txtRate.Text);
                                    //itemCardObjectClass.WholeSalePrice = itemCardObjectClass.WholeSalePrice * Convert.ToInt32(txtRate.Text);
                                    itemCardObjectClass.UnitPrice = itemCardObjectClass.ItemCost / (ImportList[10] == string.Empty || Convert.ToInt32(ImportList[10]) <= 0 ? 1 : Convert.ToInt32(ImportList[10]));
                                }
                            }

                        }

                        if (row != 1)
                        {
                            objItemCardBALClass.savePurchaseInvoceimport(itemCardObjectClass);
                        }
                    next:
                        count++;

                    }
                    SQLHelper.Instance.ExecuteQuerey("Commit transaction t1");
                    CloseExcel();
                    GeneralFunction.Information("PurchaseImportedSuccessfully", "Import");

                    // MessageBox.Show("imported successfully");
                    // DataImportedSuccessfully
                    prgImport.Visible = false;
                    objMasterDataDALClass.GetCategoryDetails();
                    objMasterDataDALClass.GetCompanyDetails();
                    objMasterDataDALClass.ItemDetails();

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        public void CloseExcel()
        {

            SQLHelper.Instance.close();
            // Close the Workbook.
            xlWorkbook.Close(false);
            // Relase COM Object by decrementing the reference count.
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            prgImport.Visible = false;
            cmbchooseimport.Focus();
        }


        private void cmbchooseimport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbchooseimport.SelectedIndex == 0)
            {
                cmbSupplierName.Enabled = false;
                lblExtracost.Enabled = false;
                txtExtraCost.Enabled = false;
                txtRate.Enabled = false;
                lblRate.Enabled = false;
                chkApply.Enabled = false;
                chkApply.Checked = false;
            }
            else if (cmbchooseimport.SelectedIndex == 1)
            {
                cmbSupplierName.Enabled = true;
                lblExtracost.Enabled = true;
                txtExtraCost.Enabled = true;
                txtRate.Enabled = false;
                lblRate.Enabled = true;
                chkApply.Enabled = true;

            }
        }

        public void GetNetAmount()
        {
            int count = 0;
            for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)
            {

                //prgImport.Value = row;
                string[] ImportList = new string[xlWorksheet.UsedRange.Columns.Count + 1];
                for (int col = 1; col <= xlWorksheet.UsedRange.Columns.Count; ++col)
                {
                    if (valueArray[row, col] == null)
                    {
                        //    if (col == 5 || col == 6)
                        //    {
                        //        ImportList[5] = "0.00";
                        //        ImportList[6] = "0.00";
                        //    }
                        //    else
                        //    {
                        ImportList[col] = string.Empty;
                        //}

                    }
                    else
                    {
                        ImportList[col] = valueArray[row, col].ToString();
                    }
                }

                if (row == 1)
                {
                    //if (ImportList[2] == "Item Name" && ImportList[3] == "Item Number" && ImportList[4] == "Barcode" &&
                    //    ImportList[5] == "Quantity" && ImportList[6] == "Unit Price" && ImportList[7] == "Category Name" && ImportList[8] == "Item Type"
                    //    && ImportList[11] == "Package Quantity" && ImportList[12] == "IsExpiry" &&
                    //    ImportList[13] == "Expiry Date" && ImportList[14] == "Item Price" && ImportList[17] == "ISForeign Currency")
                    //{
                    //}
                    if (ImportList[2].ToLower() == "اسم الصنف".ToLower() && ImportList[3].ToLower() == "رقم الصنف".ToLower() && ImportList[4].ToLower() == "باركود".ToLower() &&
                              ImportList[5].ToLower() == "قطعة".ToLower() && ImportList[6].ToLower() == "اسم المجموعة".ToLower() && ImportList[7].ToLower() == "نوع الصنف".ToLower()
                              && ImportList[10].ToLower() == "العدد بالعبوة".ToLower() && ImportList[11].ToLower() == "الصلاحية".ToLower() &&
                              ImportList[12].ToLower() == "تاريخ الصلاحية".ToLower() && ImportList[13].ToLower() == "سعر البيع".ToLower())
                    {
                    }

                    else
                    {
                        GeneralFunction.Information("FileFormat", "Import");
                        xlWorkbook.Close(false);

                        Marshal.ReleaseComObject(xlWorkbook);
                        xlApp.Quit();
                        Marshal.FinalReleaseComObject(xlApp);
                        btnBrowse.Focus();
                        Validation = true;
                        return;
                    }
                }
                if (row == 2)
                {
                    if (ImportList[2] == String.Empty && ImportList[2] == String.Empty && ImportList[3] == String.Empty && ImportList[4] == String.Empty &&
                         ImportList[5] == String.Empty && ImportList[5] == String.Empty &&
                        ImportList[6] == String.Empty && ImportList[7] == String.Empty && ImportList[8] == String.Empty &&
                        ImportList[9] == String.Empty && ImportList[10] == String.Empty && ImportList[11] == String.Empty &&
                        ImportList[12] == String.Empty && ImportList[13] == String.Empty)
                    {
                        CloseExcel();
                        GeneralFunction.Information("NoRecordFound", "Import");
                        btnBrowse.Focus();
                        txtFileName.Text = string.Empty;
                        Path = string.Empty;
                        Validation = true;
                        return;

                    }

                }
                if (row != 1)
                {
                    if (ImportList[2] == String.Empty && ImportList[3] == String.Empty && ImportList[4] == String.Empty &&
                                    ImportList[5] == String.Empty && ImportList[5] == String.Empty &&
                                   ImportList[6] == String.Empty && ImportList[7] == String.Empty && ImportList[8] == String.Empty &&
                                   ImportList[9] == String.Empty && ImportList[10] == String.Empty && ImportList[11] == String.Empty &&
                                   ImportList[12] == String.Empty && ImportList[13] == String.Empty)
                    {

                        return;
                    }

                    if (ImportList[2] == string.Empty)
                    {
                        ErrorMessage objerror = new ErrorMessage();
                        objerror.error = "Error at" + " " + ImportList[1] + "  Row" + "2  Column\n" + " " + "Error is:Item Name Empty";
                        objerror.enable = false;
                        objerror.ShowDialog();

                        //if (objerr.sContinue == "YES")
                        //{
                        //    objerr.Close();
                        //    goto next;
                        //}
                        if (objerror.sUndo == "YES")
                        {
                            objerror.Close();
                            SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                            SQLHelper.Instance.close();
                            CloseExcel();
                            txtFileName.Text = string.Empty;
                            cmbchooseimport.Focus();
                            Validation = true;
                            return;
                        }
                    }


                    int UnitQuantity;
                    bool isUnitQuantity = int.TryParse(ImportList[5], out UnitQuantity);
                    if (!isUnitQuantity || UnitQuantity < 0)
                    {
                        ErrorMessage objerr = new ErrorMessage();
                        objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  5 Column\n" + " " + "Error is:Quantity";
                        objerr.enable = false;
                        objerr.ShowDialog();
                        if (objerr.sUndo == "YES")
                        {
                            objerr.Close();
                            SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                            CloseExcel();
                            cmbchooseimport.Focus();
                            Validation = true;
                            return;
                        }
                    }
                    //decimal Price;
                    //bool isPrice = decimal.TryParse(ImportList[6], out Price);
                    //if (!isPrice || Price < 0)
                    //{
                    //    ErrorMessage objerr = new ErrorMessage();
                    //    objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  6  Column\n" + " " + "Error is: Price";
                    //    objerr.enable = false;
                    //    objerr.ShowDialog();
                    //    if (objerr.sUndo == "YES")
                    //    {
                    //        objerr.Close();
                    //        SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                    //        CloseExcel();
                    //        cmbchooseimport.Focus();
                    //        Validation = true;
                    //        return;
                    //    }
                    //}

                    decimal ItemCost;
                    bool isItemCost = decimal.TryParse(ImportList[9], out ItemCost);
                    if (!isItemCost || ItemCost < 0)
                    {


                        ErrorMessage objerr = new ErrorMessage();
                        objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  10 Column\n" + " " + "Error is :ItemCost";
                        objerr.enable = false;
                        objerr.ShowDialog();
                        if (objerr.sUndo == "YES")
                        {
                            objerr.Close();
                            SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                            CloseExcel();
                            txtFileName.Text = string.Empty;
                            cmbchooseimport.Focus();
                            return;
                        }
                    }
                    decimal price;
                    bool isprice = decimal.TryParse(ImportList[13], out price);
                    if (!isprice || price < 0)
                    {

                        ErrorMessage objerr = new ErrorMessage();
                        objerr.error = "Error at" + " " + ImportList[1] + "  Row" + "  14 Column\n" + " " + "Error is: Selling Price cann't be empty";
                        objerr.enable = false;
                        objerr.ShowDialog();
                        if (objerr.sUndo == "YES")
                        {
                            objerr.Close();
                            SQLHelper.Instance.ExecuteQuerey("Rollback transaction t1");
                            CloseExcel();
                            txtFileName.Text = string.Empty;
                            cmbchooseimport.Focus();
                            return;
                        }
                    }




                    count++;
                    if (chkApply.Checked == true)
                    {
                        if (txtRate.Text != string.Empty)
                        {
                            if (txtRate.Text != null)
                            {
                                // decimal foreigncurrency = (Convert.ToDecimal(ImportList[6]) * Convert.ToDecimal(txtRate.Text));
                                decimal foreigncurrency = ((Convert.ToDecimal(ImportList[9]) / (ImportList[10] == string.Empty || Convert.ToInt32(ImportList[10]) <= 0 ? 1 : Convert.ToInt32(ImportList[10]))) * Convert.ToDecimal(txtRate.Text));
                                NetAmount = NetAmount + (Convert.ToDecimal(ImportList[5]) * foreigncurrency);
                            }


                        }
                    }
                    else
                    {

                        NetAmount = NetAmount + (Convert.ToDecimal(ImportList[5]) * (Convert.ToDecimal(ImportList[9]) / (ImportList[10] == string.Empty || Convert.ToInt32(ImportList[10]) <= 0 ? 1 : Convert.ToInt32(ImportList[10]))));
                    }

                    if (txtExtraCost.Text != string.Empty)
                    {
                        if (txtRate.Text != null)
                        {
                            GrassAmount = Convert.ToDecimal(txtExtraCost.Text);
                            ExtraCost = Convert.ToDecimal(txtExtraCost.Text) / count;

                        }

                    }
                }

            }

            //if (txtExtraCost.Text != string.Empty)
            //{
            //    if (txtRate.Text != null)
            //    {
            //        GrassAmount = Convert.ToDecimal(txtExtraCost.Text);
            //        ExtraCost = Convert.ToDecimal(txtExtraCost.Text) / count;

            //    }

            //}
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Excel Files(.xls)|*.xls|Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";
            objOpenFileDialog.AddExtension = true;
            objOpenFileDialog.ShowDialog();
            objOpenFileDialog.Title = "Browse Excel file";
            Path = objOpenFileDialog.FileName;
            txtFileName.Text = Path;
        }
        private void SetLanguage()
        {
            lblImport.Text = Additional_Barcode.GetValueByResourceKey("ChooseImportOption");
            lblExtracost.Text = Additional_Barcode.GetValueByResourceKey("ExtraImportCost");
            lblSupplier.Text = Additional_Barcode.GetValueByResourceKey("ImportSupplier");
            lblRate.Text = Additional_Barcode.GetValueByResourceKey("Rate");
            lblFilename.Text = Additional_Barcode.GetValueByResourceKey("FileName");
            cmbchooseimport.Items.Add(Additional_Barcode.GetValueByResourceKey("ItemImport"));
            cmbchooseimport.Items.Add(Additional_Barcode.GetValueByResourceKey("PurchaseInvoiceImport"));
            btnBrowse.Text = Additional_Barcode.GetValueByResourceKey("Browse");
            btnImport.Text = Additional_Barcode.GetValueByResourceKey("Import");
            this.Text = Additional_Barcode.GetValueByResourceKey("Import");
            chkApply.Text = Additional_Barcode.GetValueByResourceKey("Apply");
        }

        private void chkApply_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApply.Checked)
                txtRate.Enabled = true;
            else
            {
                txtRate.Enabled = false;
                txtRate.Text = string.Empty;
            }
        }


    }
}

