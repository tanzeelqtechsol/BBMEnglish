using DataBaseHelper.DALClass;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class FormQuery : Form
    {
        AddFavoriteUserQueryDALClass dataHelper = new AddFavoriteUserQueryDALClass();
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        public FormQuery()
        {
            InitializeComponent();
            SetLanguage();
            chkEnableDateFromTo.Checked = false;
            rdoPortrait.Checked = true;
        }

        #region custom methods
        // variables
        int printColumns = 0;
        float lastCell = 0;
        int rowcount = 0;
        int totalnumber = 0;//this is for total number of items of the list or array
        int itemperpage = 0;//this is for no of item per page 
        int pageNo = 0;
        float pageLocation = 0;
        int titleLocation = 0;
        bool IsFilterByDate = false;
        // public static 
        public static string query = "";
        public static string GetEmbeddedResourceMapping(string key)
        {

            string retVal = "";
            try
            {
                key = key.ToLower();
                #region keys 
                if (key == "salereturn")
                    key = "salesreturntable";
                else if (key == "salesreturndetails")
                    key = "salesreturnitemstable";
                else if (key == "expiredate")
                    key = "expirydate";
                else if (key == "startdate")
                    key = "sd";
                else if (key == "enddate")
                    key = "ed";
                else if (key == "employeename")
                    key = "empname";
                else if (key == "mobileno")
                    key = "mobno";
                else if (key == "passportno")
                    key = "passno";
                else if (key == "phoneno")
                    key = "phno";
                else if (key == "startworkhours")
                    key = "startworktime";
                else if (key == "endworkhours")
                    key = "endworktime";
                else if (key == "detail")
                    key = "details";
                else if (key == "totalamount")
                    key = "tamount";
                else if (key == "reasons")
                    key = "reason";
                else if (key == "breakhours")
                    key = "bt";
                else if (key == "dayofovertime")
                    key = "overtimebreak";
                else if (key == "dayofovertime")
                    key = "overtimebreak";
                else if (key == "dovertimeend")
                    key = "overtimeend";
                else if (key == "dovertimestart")
                    key = "overtimestart";
                else if (key == "stockinhand")
                    key = "stock";
                #endregion

                System.Resources.ResourceManager lResoruce;
                lResoruce = new System.Resources.ResourceManager("BumedianBM.ResourceFile.Resources", System.Reflection.Assembly.GetExecutingAssembly());

                var entry =
                lResoruce.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Key.ToString().ToLower() == key);
                if (entry.Key == null)
                    return "";
                retVal = Additional_Barcode.GetValueByResourceKey(entry.Key.ToString());
            }
            catch
            {
                return "";
            }
            return retVal;
        }
        // methods
        private void exportToPDF()
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(Dg_Custom.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int count = 0;
            //Adding Header row
            foreach (DataGridViewColumn column in Dg_Custom.Columns)
            {
                if (Dg_Custom.Columns[count].Visible == true)
                {

                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                ++count;
            }
            count = 0;
            //Adding DataRow
            foreach (DataGridViewRow row in Dg_Custom.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (Dg_Custom.Columns[count].Visible == true)
                        pdfTable.AddCell(cell.Value.ToString());
                    ++count;
                }
                count = 0;
            }

            //Exporting to PDF
            //string folderPath = "C:\\PDFs\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            using (FileStream stream = new FileStream(saveFileDialog2.FileName, FileMode.Create))
            //using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
        private void exportToTxt()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog2.FileName, false))
                //new FileStream(,FileMode.Create,FileAccess.Write,FileShare.Read)))
                {
                    String line = "";
                    for (int i = 0; i < Dg_Custom.Columns.Count; i++)
                    {
                        if (Dg_Custom.Columns[i].Visible == true)
                        {

                            string columnCaption = Dg_Custom.Columns[i].Name;
                            //Check for columns that start with special characters that spreadsheet programs treat differently than simply displaying them.
                            if (columnCaption.StartsWith("-") || columnCaption.StartsWith("="))
                            {
                                //Adding a space to the beginning of the cell will trick the spreadsheet program into not treating it uniquely.
                                columnCaption = " " + columnCaption;
                            }
                            line += columnCaption;
                            if (i < Dg_Custom.Columns.Count - 1)
                            {
                                line += "\t";
                            }
                        }
                    }
                    sw.WriteLine(line);

                    string cell;
                    for (int i = 0; i < Dg_Custom.Rows.Count; i++)
                    {
                        line = "";
                        for (int j = 0; j < Dg_Custom.Columns.Count; j++)
                        {
                            if (Dg_Custom.Columns[j].Visible == true)
                            {
                                cell = Dg_Custom.Rows[i].Cells[j].Value.ToString();
                                cell = cell.Replace("\r", "");
                                cell = cell.Replace("\n", "");
                                cell = cell.Replace("\t", "");
                                cell = cell.Replace("\"", "");
                                line += cell;
                                if (j < Dg_Custom.Columns.Count - 1)
                                {
                                    line += "\t";
                                }
                            }
                        }
                        sw.WriteLine(line);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show((this, "File in use by another program.  Close and try again."));
                return;
            }
        }
        private string stringToPrint;
        private string documentContents;

        private void executeQuery()
        {
            //Time span is added to search based on From date as well as from time. Done By A.Manoj On June-28
            TimeSpan TsFrom = new TimeSpan(dtpFromTime.Value.Hour, dtpFromTime.Value.Minute, dtpFromTime.Value.Second);
            DateTime FromDate = Convert.ToDateTime(dateFrom.Value.Date + TsFrom);
            TimeSpan TsTo = new TimeSpan(dtpToTime.Value.Hour, dtpToTime.Value.Minute, dtpToTime.Value.Second);
            DateTime ToDate = Convert.ToDateTime(dateTo.Value.Date + TsTo);

            string FD = FromDate.ToString("yyyy/MM/dd HH:mm:ss");
            string TD = ToDate.ToString("yyyy/MM/dd HH:mm:ss");

            string where = "";
            if (txtQuery.Text.ToLower().Contains("where"))
                where = " AND ";
            else
                where = "WHERE ";

            string startToEndDate = "";
            if (txtQuery.Text.ToLower().Contains("from sales"))
                startToEndDate = string.Format(" {0} SaleDate  >= '{1}' AND SaleDate  <='{2}'", where, FD, TD);
            else
                startToEndDate = string.Format(" {0} CREATEDDATE >= '{1}' AND CREATEDDATE <='{2}'", where, FD, TD);
            // txtQuery.Text += startToEndDate;
            //lblTitle.Text = Additional_Barcode.GetValueByResourceKey();
            // i was here 
            Dg_Custom.DataSource = null;
            if (Dg_Custom.Columns.Count > 0)
                Dg_Custom.Columns.Clear();
            if (Dg_Custom.Rows.Count > 0)
                Dg_Custom.Rows.Clear();

            string runQuery = txtQuery.Text;
            if (chkEnableDateFromTo.Checked)
            {
                runQuery = txtQuery.Text + startToEndDate;
                IsFilterByDate = true;
            }
            else
            {
                IsFilterByDate = false;
            }


            DataTable dt = dataHelper.UserQuery_ExecuteCustomQuery(runQuery);
            if (dt.Rows.Count > 0)
            {
                #region code

                Dg_Custom.DataSource = dt;

                // remove hide columns


                for (int i = 0; i < Dg_Custom.Columns.Count; i++)
                {

                    string colName = Dg_Custom.Columns[i].Name;
                    if (colName.ToLower() == "itemtype")
                    {
                        Dg_Custom.Columns.Remove("itemtype");
                        recreateColumnInGrid();
                    }

                    if (CustomReport.HideColumnsList.Contains(colName.ToLower()))
                    {
                        Dg_Custom.Columns[i].Visible = false;
                    }
                    else
                    {
                        if (txtQuery.Text.ToLower().Contains("from item") && colName.ToLower() == "expirydate")
                        {
                            Dg_Custom.Columns[i].Visible = false;
                            continue;

                        }

                        colName = GetEmbeddedResourceMapping(colName);
                        if (!string.IsNullOrEmpty(colName))
                        {

                            Dg_Custom.Columns[i].HeaderText = colName;
                            Dg_Custom.Columns[i].ToolTipText = colName;
                        }
                        if (Dg_Custom.Columns[i].ValueType.Name == "DateTime")
                        {
                            Dg_Custom.Columns[i].DefaultCellStyle.Format = "yyyy/MM/dd";
                        }
                    }
                    //Dg_Custom.Columns.Remove(Dg_Custom.Columns[i].Name);
                }


                //
                for (int i = 0; i < Dg_Custom.Rows.Count; i++)
                {
                    for (int j = 0; j < Dg_Custom.Columns.Count; j++)
                    {
                        if (dt.Columns.Contains("itemtype"))
                        {
                            string itemtype = dt.Rows[i].Field<int>("itemtype").ToString();
                            //string itemtype = Dg_Custom.Rows[i].Cells["itemtype"].Value.ToString();

                            if (itemtype == "1")
                                itemtype = Additional_Barcode.GetValueByResourceKey("Goods");
                            else if (itemtype == "2")
                                itemtype = Additional_Barcode.GetValueByResourceKey("SecondHand");
                            else if (itemtype == "3")
                                itemtype = Additional_Barcode.GetValueByResourceKey("Labour");
                            else if (itemtype == "4")
                                itemtype = Additional_Barcode.GetValueByResourceKey("Meal");
                            this.Dg_Custom.Rows[i].Cells["itemtype"].Value = itemtype;
                        }
                        string val = Dg_Custom.Rows[i].Cells[j].Value.ToString();
                        if (val.Contains('.'))
                        {
                            if (!string.IsNullOrEmpty(val))
                            {
                                double money = 0;
                                double.TryParse(val, out money);
                                if (money > 0)
                                    Dg_Custom.Rows[i].Cells[j].Value = money.ToString("#####0.000");
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                Dg_Custom.DataSource = null;
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("DataNotFound"));
            }

            if (!string.IsNullOrEmpty(ShowFavoritesUserQuery.selectedQueryName))
            {
                txtTitle.Text = ShowFavoritesUserQuery.selectedQueryName;

            }
            else txtTitle.Text = "";
            //for (int i = 6; i < Dg_Custom.Columns.Count; i++)
            //{
            //    Dg_Custom.Columns[]
            //}
        }
        private void recreateColumnInGrid()
        {
            DataGridViewTextBoxColumn isEdited = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCell txtcell = new DataGridViewTextBoxCell();
            isEdited.CellTemplate = txtcell;
            isEdited.Name = "itemtype";
            isEdited.HeaderText = "Item Type";
            isEdited.Visible = true;
            isEdited.ValueType = typeof(string);

            Dg_Custom.Columns.Add(isEdited);

        }
        private void invokeExecuteQuery()
        {
            txtQuery.Text = CustomReport.passQuery;
            if (!string.IsNullOrEmpty(txtQuery.Text))
                executeQuery();
        }
        private void printPrevPortrait()
        {
            printColumns = 5;
            titleLocation = 370;
            //pageLocation = 750;
            pageLocation = 600 + (float)30.1527252;
            pageNo = 0;
            itemperpage = totalnumber = 0;
            printPreviewDialog1.Document = printDocument2;
            //((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.RightToLeftLayout = true;
            this.printDocument2.DefaultPageSettings.Landscape = false;
            PrinterSettings ps = new PrinterSettings();
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
            printDocument2.DefaultPageSettings.PaperSize = sizeA4;
            //printDocument2.DefaultPageSettings.PaperSize = ps;
            printPreviewDialog1.ShowDialog();
        }
        private void printPrevLandscape()
        {
            printColumns = 7;
            titleLocation = 570;
            //pageLocation = 1000;

            pageLocation = 900 + (float)30.1527252;

            //here we are printing 50 numbers sequentially by using loop. 
            //For each button click event we have to reset below two variables to 0     
            // because every time  PrintPage event fires automatically. 
            pageNo = 0;
            itemperpage = totalnumber = 0;
            printPreviewDialog1.Document = printDocument2;

            //((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            this.printDocument2.DefaultPageSettings.Landscape = true;
            PrinterSettings ps = new PrinterSettings();
            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.Letter); // setting paper size to A4 size
            printDocument2.DefaultPageSettings.PaperSize = sizeA4;

            //printDocument2.DefaultPageSettings.PaperSize = ps;
            printPreviewDialog1.ShowDialog();

        }


        private string exportTemPrevFile()
        {
            string path = "D:\\TempPrev.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                //new FileStream(,FileMode.Create,FileAccess.Write,FileShare.Read)))
                {
                    String line = "";
                    for (int i = 0; i < Dg_Custom.Columns.Count; i++)
                    {
                        string columnCaption = Dg_Custom.Columns[i].Name;
                        //Check for columns that start with special characters that spreadsheet programs treat differently than simply displaying them.
                        if (columnCaption.StartsWith("-") || columnCaption.StartsWith("="))
                        {
                            //Adding a space to the beginning of the cell will trick the spreadsheet program into not treating it uniquely.
                            columnCaption = " " + columnCaption;
                        }
                        line += columnCaption;
                        if (i < Dg_Custom.Columns.Count - 1)
                        {
                            line += "\t";
                        }
                    }
                    sw.WriteLine(line);
                    string cell;
                    for (int i = 0; i < Dg_Custom.Rows.Count; i++)
                    {
                        line = "";
                        for (int j = 0; j < Dg_Custom.Columns.Count; j++)
                        {

                            cell = Dg_Custom.Rows[i].Cells[j].Value.ToString();

                            //cell = cell.Replace("\r", "");
                            //cell = cell.Replace("\n", "");
                            //cell = cell.Replace("\t", "");
                            //cell = cell.Replace("\"", "");
                            //line += cell;
                            //if (j < Dg_Custom.Columns.Count - 1)
                            //{
                            //    line += "\t";
                            //}
                        }
                        sw.WriteLine(line);
                    }
                }
            }
            catch
            {
                //MessageBox.Show((this, "File in use by another program.  Close and try again."));
            }
            return path;
        }
        private void ReadDocument()
        {
            //string path = "D:\\TempPrev.txt";
            string path = "D:\\TempPrev.txt";

            if (!File.Exists(path))
                return;
            FileInfo info = new FileInfo(path);
            printDocument2.DocumentName = info.Name;
            using (FileStream stream = new FileStream(info.FullName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        private void SetLanguage()
        {
            this.Text = Additional_Barcode.GetValueByResourceKey("Query");
            lblTo.Text = Additional_Barcode.GetValueByResourceKey("To");
            chkEnableDateFromTo.Text = Additional_Barcode.GetValueByResourceKey("EnableDate");
            lblSortHint.Text = Additional_Barcode.GetValueByResourceKey("HintSort");
            rdoPortrait.Text = Additional_Barcode.GetValueByResourceKey("Portrait");
            rdoLandscape.Text = Additional_Barcode.GetValueByResourceKey("Landscape");
            lblTitle.Text = Additional_Barcode.GetValueByResourceKey("Title");
            btnCopy.Text = Additional_Barcode.GetValueByResourceKey("Copy");
            btnExport.Text = Additional_Barcode.GetValueByResourceKey("Export");
            btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
            btnFavorites.Text = Additional_Barcode.GetValueByResourceKey("Favorites");
            btnAddtoFav.Text = Additional_Barcode.GetValueByResourceKey("AddFavorite");
            btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
            chkRightToLift.Text = Additional_Barcode.GetValueByResourceKey("RightToLeft");

            btnSubmitQuery.Text = Additional_Barcode.GetValueByResourceKey("SubmitQuery");
            btnPaste.Text = Additional_Barcode.GetValueByResourceKey("Paste");
            btnPrintPreview.Text = Additional_Barcode.GetValueByResourceKey("PrintPreview");
        }
        #endregion

        #region events 


        private void Dg_Sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormQuery_Load(object sender, EventArgs e)
        {
            dateFrom.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            dateTo.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
            chkRightToLift.Checked = true;
            invokeExecuteQuery();
        }

        private void Dg_Custom_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Dg_Custom_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnFavorites_Click(object sender, EventArgs e)
        {
            ShowFavoritesUserQuery form = new ShowFavoritesUserQuery();
            form.ShowDialog();
            invokeExecuteQuery();
        }

        private void btnAddtoFav_Click(object sender, EventArgs e)
        {
            if (Dg_Custom.Rows.Count > 0 && txtQuery.Text != "")
            {
                ShowFavoritesUserQuery.FavListID = 0;
                AddFavorite form = new AddFavorite();
                ShowFavoritesUserQuery.selectedQueryName = txtTitle.Text;
                query = txtQuery.Text;
                form.ShowDialog();
            }
            else
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("YouNeedToAddQueryFirst"));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuery.Text))
            {
                string selectedText = txtQuery.SelectedText;
                Clipboard.SetDataObject(selectedText);
            }
            else
                MessageBox.Show("There is nothing to copy");
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData;
            iData = Clipboard.GetDataObject();
            if (!string.IsNullOrEmpty((String)iData.GetData(DataFormats.Text)))
                txtQuery.Text = (String)iData.GetData(DataFormats.Text);
            else
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("NothingToPaste"));
        }

        private void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuery.Text))
            {
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("YouNeedToAddQueryFirst"));
                return;
            }
            executeQuery();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Dg_Custom.DataSource == null || Dg_Custom.Rows.Count < 1)
            {
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("NothingToExport"));
                return;
            }
            saveFileDialog2 = new SaveFileDialog();
            saveFileDialog2.AddExtension = true;
            saveFileDialog2.FileName = txtTitle.Text;
            saveFileDialog2.Filter = "Text files(*.txt)|*.txt|PDF Files(*.pdf)|*.pdf|Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
            saveFileDialog2.FilterIndex = 0;

            if (saveFileDialog2.ShowDialog() != DialogResult.OK)
                return;
            string filename = saveFileDialog2.FileName;
            if (filename.ToLower().Contains(".txt") || filename.ToLower().Contains(".xls"))
                exportToTxt();
            if (filename.ToLower().Contains(".pdf"))
                exportToPDF();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dg_Custom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (Dg_Custom.DataSource == null || Dg_Custom.Rows.Count < 1)
            {
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("NothingToPrint"));
                return;
            }
            if (rdoLandscape.Checked == true)
            {
                if (Dg_Custom.Columns.Count > 7)
                    MessageBox.Show(Additional_Barcode.GetValueByResourceKey("MsgLandScape"));
                printPrevLandscape();
            }
            else
            {
                if (Dg_Custom.Columns.Count > 5)
                    MessageBox.Show(Additional_Barcode.GetValueByResourceKey("MsgPortrat"));
                printPrevPortrait();
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            #region new code
            StringFormat DataRowformat = new StringFormat();
            DataRowformat.Alignment = chkRightToLift.Checked ? StringAlignment.Near : StringAlignment.Far;

            float[] ColumnsXLocation = new float[printColumns];
            string title = txtTitle.Text;
            if (string.IsNullOrEmpty(title))
                title = "";
            string header = title;
            string date = DateTime.Now.Date.ToString("MM/dd/yyyy");

            //string FromToDate = IsFilterByDate ? " " + Additional_Barcode.GetValueByResourceKey("From") + " : " + dateFrom.Text + "" + Additional_Barcode.GetValueByResourceKey("To") + " : " + dateTo.Text : "";

            int x = 0, y = 0, width = 130, height = 30;
            float xPadding;

            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            SizeF size;

            while (totalnumber < Dg_Custom.Rows.Count) // check the number of items
            {
                // for top info and columns header
                if (itemperpage == 0)
                {
                    if (printColumns == 7)
                        x = 900;
                    else
                        x = 600;

                    #region print first top line date,title and page no
                    y += 40;
                    e.Graphics.DrawString("", font, brush, 0 + pageLocation, y + 5);
                    ++pageNo;

                    width = 150;
                    // Here title is written, sets to top-middle position of the page
                    //size = g.MeasureString(header, font);
                    //xPadding = (width - size.Width) / 2;
                    //g.DrawString(header, font, brush, x + 370, y + 5);

                    // date in start
                    size = e.Graphics.MeasureString(date, font);
                    xPadding = (width - size.Width) / 2;
                    e.Graphics.DrawString(date, font, brush, 0 + (float)32.5364838, y + 5);
                    // title on center
                    size = e.Graphics.MeasureString(header, font);
                    xPadding = (width - size.Width) / 2;
                    e.Graphics.DrawString(header, font, brush, 0 + titleLocation, y + 5);

                    // page number in end
                    size = e.Graphics.MeasureString("Page: " + pageNo.ToString(), font);
                    xPadding = (width - size.Width) / 2;
                    e.Graphics.DrawString("Page: " + pageNo.ToString(), font, brush, pageLocation, y + 5);

                    font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                    if (printColumns == 7)
                        x = 900;
                    else
                        x = 600;
                    y += 30;

                    //    // horizental line
                    Pen penGray = new
                        Pen(Color.FromKnownColor
                        (System.Drawing.KnownColor.ControlDark), 1);
                    Pen penWhite = new Pen(Color.WhiteSmoke, 1);
                    int w = width * 9;
                    e.Graphics.DrawLine(penGray, 0, y, 0 + w, y);
                    e.Graphics.DrawLine(penWhite, 0, y + 5, 0 + w, y + 1);
                    //
                    #endregion

                    if (printColumns == 7)
                        x = 900;
                    else
                        x = 600;

                    y += 30;
                    int count = 0;
                    #region print columns header 
                    for (int i = 0; i < Dg_Custom.Columns.Count; i++)
                    {
                        if (Dg_Custom.Columns[i].Visible == true)
                        {
                            if (count == printColumns)
                                break;


                            string colName = Dg_Custom.Columns[i].HeaderText;
                            //StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                            //e.Graphics.DrawRectangle(pen, x, y, width, height);
                            size = e.Graphics.MeasureString(colName, font);
                            xPadding = (width - size.Width) / 2;
                            StringFormat format = new StringFormat();
                            //format.Alignment = StringAlignment.Center;
                            if (count == printColumns)
                            {
                                e.Graphics.DrawString(colName, font, brush, pageLocation, y + 5, format);
                                ColumnsXLocation[count] = pageLocation;
                            }
                            else
                            {
                                e.Graphics.DrawString(colName, font, brush, x + xPadding, y + 5, format);
                                ColumnsXLocation[count] = x + xPadding;
                            }
                            ++count;
                            //e.Graphics.DrawString(colName, Font, brush,e.MarginBounds, StringFormat.GenericTypographic);
                            //// Draws the string within the bounds of the page.
                            //e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,e.MarginBounds, StringFormat.GenericTypographic);
                            //x += width;
                            x -= width;
                            lastCell = x;
                        }

                    }
                    #endregion
                }

                y += 30;
                // Process each row and place each item under correct column.

                //rowcount = rowcount++;
                rowcount++;
                //rowcount = j;
                int colCounter = 0;
                int maxCol = 0;
                int lasty = 0;
                bool isFirstY = false;
                int countPrintedColumns = 0;
                float ylocation = 0;
                int maxYlocation = 0;
                for (int i = 0; i < Dg_Custom.Columns.Count; i++)
                //for (int i = Dg_Custom.Columns.Count - 1; i >= 0; i--)
                {
                    if (countPrintedColumns == printColumns)
                        break;
                    if (isFirstY == false)
                        lasty = y;
                    if (y > lasty)
                    {
                        maxYlocation = y;
                        y = lasty;
                    }
                    isFirstY = true;

                    #region code

                    if (Dg_Custom.Columns[i].Visible == false)
                        continue;
                    float xlocation = ColumnsXLocation[countPrintedColumns];
                    if (countPrintedColumns > 0)
                        xlocation += 5;
                    if (maxCol == printColumns)
                        break;
                    ++maxCol;

                    string lineSplit = "";
                    string cell = Dg_Custom.Rows[totalnumber].Cells[i].Value.ToString();
                    if (cell.Length > 15)
                    {
                        string[] spliter = cell.Split(' ');
                        for (int w = 0; w < spliter.Length; w++)
                        {
                            lineSplit += spliter[w] + " ";
                            if (lineSplit.Length > 13)
                            {
                                //e.Graphics.DrawRectangle(pen, x, y, xlocation, height);
                                size = e.Graphics.MeasureString(lineSplit, font);
                                e.Graphics.DrawString(lineSplit, font, brush, xlocation, y + 5, DataRowformat);
                                // x += width;
                                //x = 0;
                                y += 30;
                                lineSplit = "";
                            }
                        }
                        if (!string.IsNullOrEmpty(lineSplit))
                        {
                            //e.Graphics.DrawRectangle(pen, x, y, xlocation, height);
                            size = e.Graphics.MeasureString(lineSplit, font);
                            xPadding = (width - size.Width) / 2;
                            if (colCounter == printColumns)
                                xPadding = (float)32.5364838;

                            e.Graphics.DrawString(lineSplit, font, brush, xlocation, y + 5, DataRowformat);
                            //   x += width;
                            // x = 0;
                            y += 30;
                        }

                        //int countWords = cell.Split().Length; // 7

                    }
                    else
                    {
                        //  width = cell.Length;
                        //e.Graphics.DrawRectangle(pen, x, y, xlocation, height);
                        size = e.Graphics.MeasureString(cell, font);
                        xPadding = (width - size.Width) / 2;
                        if (colCounter == printColumns)
                            xPadding = (float)32.5364838;
                        e.Graphics.DrawString(cell, font, brush, xlocation, y + 5, DataRowformat);
                        //                        x += width;
                    }
                    //x += width;
                    #endregion
                    ++countPrintedColumns;
                }
                ++colCounter;
                if (maxYlocation > 0)
                    y = maxYlocation;
                else
                    y += 30;
                //

                //e.Graphics.DrawString(totalnumber.ToString(), DefaultFont, Brushes.Black, 50, currentY);//print each item
                //currentY += 20; // set a gap between every item
                totalnumber += 1; //increment count by 1
                if (itemperpage < 11) // check whether  the number of item(per page) is more than 20 or not
                {
                    itemperpage += 1; // increment itemperpage by 1
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added

                }
                else // if the number of item(per page) is more than 20 then add one page
                {
                    itemperpage = 0; //initiate itemperpage to 0 .
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    return;//It will call PrintPage event again

                }
            }
            #endregion
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (Dg_Custom.DataSource == null || Dg_Custom.Rows.Count < 1)
            {
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("NothingToPrint"));
                return;
            }
            if (rdoLandscape.Checked == true)
            {
                if (Dg_Custom.Columns.Count > 7)
                    MessageBox.Show(Additional_Barcode.GetValueByResourceKey("MsgLandScape"));
                //MessageBox.Show("In Landscape mode maximume columns are 7, others will be removed");
                printPrevLandscape();
            }
            else
            {
                if (Dg_Custom.Columns.Count > 5)
                    MessageBox.Show(Additional_Barcode.GetValueByResourceKey("MsgPortrat"));
                //MessageBox.Show("In Portrait mode maximume columns are 5, others will be removed");
                printPrevPortrait();
            }
            using (PrintDocument pd = new PrintDocument())
            {
                using (PrintDialog printDialog = new PrintDialog())
                {
                    if (printDialog.ShowDialog() == DialogResult.Yes)
                    {
                        pd.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
                        pd.Print();
                    }
                }
            }
        }



        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            txtTitle.Clear();
            if (ShowFavoritesUserQuery.isFromFav == false)
                ShowFavoritesUserQuery.selectedQueryName = "";
            else
                ShowFavoritesUserQuery.isFromFav = false;

        }

        private void btnPrintPrePortrait_Click(object sender, EventArgs e)
        {

        }

        private void chkEnableDateFromTo_CheckedChanged(object sender, EventArgs e)
        {
            dateFrom.Enabled = chkEnableDateFromTo.Checked;
            dateTo.Enabled = chkEnableDateFromTo.Checked;
            dtpFromTime.Enabled= chkEnableDateFromTo.Checked;
            dtpToTime.Enabled= chkEnableDateFromTo.Checked; 
        }
        #endregion
    }
}