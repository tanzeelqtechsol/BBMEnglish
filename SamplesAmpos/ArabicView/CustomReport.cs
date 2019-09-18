using BumedianBM.ViewHelper;
using DataBaseHelper.DALClass;
using ObjectHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BumedianBM.ArabicView
{
    public partial class CustomReport : Form
    {

        CustomReportHelper ObjHelper;
        public CustomReport()
        {
            InitializeComponent();
            ObjHelper = new CustomReportHelper();
            SetLanguage();
        }

        #region variables and list
        List<string> listOfSelctedColumns = new List<string>();
        List<CustomReportObjectClass> dataList = new List<CustomReportObjectClass>();
        List<CustomReportObjectClass> tablesNamesList = new List<CustomReportObjectClass>();
        List<CustomReportObjectClass> columnsNamesList = new List<CustomReportObjectClass>();
        string and = "";
        string like = "";
        #region static hide columns/tables list
        public static List<string> HideTablesList = new List<string>(){
            "test", "renting",  "rentback", "renting" ,"rentingdetails","optiondetails","options","agentphonebook","logo","user","usergroup","screentable","tableselection","user","userdetails","workstation","account","userquery","agenttype","keysequence","itemtype","buttonselection","company","generalinfo","alertuser","agenttype","description","rentbackdetails","workstation","usergrouptable","employeex","batch","datalogs"
        };
        public static List<string> HideColumnsList = new List<string>(){
            "imagepath","itemimage",
               "agentid","accountid",
            "accountdetailid","agenttypeid","agentmailid","optionid","balancesheetid","bankdetailid","reasonid",
            "barcodeid","unittypesid","unitnameid","batchid","buttonselectionid","cashdetailid","saleid","receiptdetailid","receiptid",
            "descriptionid","discountid","salaryid","employeevariablesid","groupid","employeeid","socialid","expensesid","generaltypeid","generalid",
            "inventoryid","categoryid","itemplaceid","companyid","itemserialid","itemtypeid","tableid","notesid","orderid","orderdetailid",
            "paymentid","paymethodid","purchaseid","bankid","branchid","paymentdetailid","userid","paymentmethodid","purchaseinvoiceid",
            "purchasedetailid","itemid","returnid","purchasereturnid","rentbackid","rentingid","detailsid","variableid",
            "saledetailid","stockid","salereturnid","uniqueid",
            "salereturndetailid","screenid","spoiledinvoiceid","spoiledinvoicedetailsid","id","tableselectionid","saleinvoiceid","usergroupid",
            "userbreakid","userdetailid","defaultscreenid","expenseid","usertrackingid","workstationid","expiry"
            ,"payinvoice","hideagent","rentingclient","transactionflag","flag","hasincrease","drawingflag","isnote","ishide","isinvoiceaction","saleinvoice"
            ,"buttonid","unit","isitemprint","iteminsertionno","itemquantityprint","paymenttypeid","tableno","buttonitemid","username"
        #endregion
        };
        public static string passQuery = "";
        public static List<string> CondtionsList { get; set; }
        private string selectedTable = "";
        private string selectedColumns = "";
        private string where = " WHERE ";
        private string SQLQuery = "";
        #endregion

        #region custom methods
        private void handleAndLikeCondition(bool visible)
        {
            Cmb_ConditionColumn.Enabled = visible;
            txt_CondtionValue.Visible = visible;
            txt_NumericConditionValue.Visible = visible;
            txt_DateCondtionValue.Visible = visible;
            lbl_DataTypeHelp.Visible = visible;
            rdoNo.Visible = visible;
            rdoYes.Visible = visible;
            rdoNo.Checked = visible;
            rdoYes.Checked = visible;

        }
        private string trimExtraCommaInQuery(string value)
        {

            // value = columnsNamesList.Where(x => x.Name == value).FirstOrDefault().Value;
            //int findex = value.IndexOf(',');
            //if (findex == 0 || findex == 1)
            //    value = value.Remove(findex, 1);
            string retVal = "";
            if (!value.Contains(','))
                return value;
            string[] spliter = value.Split(',');
            for (int i = 0; i < spliter.Length; i++)
            {
                if (!string.IsNullOrEmpty(spliter[i]) && spliter[i] != " ")
                    retVal += spliter[i] + ",";
            }
            if (retVal.Contains(','))
            {
                int lastComma = retVal.LastIndexOf(',');
                retVal = retVal.Remove(lastComma, 1);
            }
            return retVal;
        }
        private void populateTables()
        {
            List<string> dataList = ObjHelper.ObjBALClass.GetAllTables();
            dataList.Sort();
            foreach (var item in dataList)
            {
                if (!HideTablesList.Contains(item.ToLower()))
                {
                    CustomReportObjectClass table = new CustomReportObjectClass();
                    if (item.ToLower() == "sales")
                    {

                    }
                    //string colName = FormQuery.GetEmbeddedResourceMapping(item);
                    //
                    string colName = "";
                    try
                    {
                        string name = item.ToString();
                        //name = name.ToLower();
                        #region keys 
                        if (name.ToLower() == "salereturn")
                            name = "SalesReturnTable";
                        else if (name.ToLower() == "salesreturndetails")
                            name = "SalesReturnItemsTable";
                        else if (name.ToLower() == "inventory")
                            name = "InventoryTable";
                        #endregion

                        colName = Additional_Barcode.GetValueByResourceKey(name.ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                    //
                    if (!string.IsNullOrEmpty(colName))
                    {
                        LB_Tables.Items.Add(colName);
                        table.Name = colName;
                    }
                    else
                    {
                        LB_Tables.Items.Add(item);
                        table.Name = item;
                    }
                    table.Value = item;
                    tablesNamesList.Add(table);
                }
            }
        }
        private void populateColumnsOnTable(string table)
        {
            //LB_Columns.DataSource = null;
            //Cmb_ConditionColumn.DataSource = null;
            LB_Columns.Items.Clear();
            Cmb_ConditionColumn.Items.Clear();
            dataList = ObjHelper.ObjBALClass.GetColumnsByTableName(table).OrderBy(x => x.Name).ToList();
            //            dataList.Sort();
            columnsNamesList = new List<CustomReportObjectClass>();
            foreach (var item in dataList)
            {
                if (!HideColumnsList.Contains(item.Name.ToLower()))
                {
                    if (table.ToLower() == "item" && item.Name.ToLower() == "expirydate")
                    {
                        continue;
                    }
                    item.Value = item.Name;

                    //string colName = FormQuery.GetEmbeddedResourceMapping(item.Name);
                    //
                    string colName = "";
                    string name = item.Name;
                    try
                    {
                        #region keys 
                        if (name.ToLower() == "expiredate")
                            name = "expirydate";
                        else if (name.ToLower() == "startdate")
                            name = "SD";
                        else if (name.ToLower() == "enddate")
                            name = "ED";
                        else if (name.ToLower() == "employeename")
                            name = "empname";
                        else if (name.ToLower() == "mobileno")
                            name = "mobno";
                        else if (name.ToLower() == "passportno")
                            name = "passno";
                        else if (name.ToLower() == "phoneno")
                            name = "phno";
                        else if (name.ToLower() == "startworkhours")
                            name = "startworktime";
                        else if (name.ToLower() == "endworkhours")
                            name = "endworktime";
                        else if (name.ToLower() == "detail")
                            name = "Details";
                        else if (name.ToLower() == "totalamount")
                            name = "TAmount";
                        else if (name.ToLower() == "reasons")
                            name = "Reason";
                        else if (name.ToLower() == "breakhours")
                            name = "BT";
                        else if (name.ToLower() == "dayofovertime")
                            name = "OverTimeBreak";
                        else if (name.ToLower() == "dayofovertime")
                            name = "overtimebreak";
                        else if (name.ToLower() == "dovertimeend")
                            name = "OverTimeEnd";
                        else if (name.ToLower() == "dovertimestart")
                            name = "OverTimeStart";
                        else if (name == "AgentPayDay")
                            name = "Agentpayday";
                        else if (name == "YearSequenceNo")
                            name = "Yearsequenceno";
                        else if (name == "ReceiptFor")
                            name = "Receiptfor";
                        else if (name == "AmountReceived")
                            name = "Amountreceived";
                        else if (name == "value")
                            name = "Value";
                        else if (name == "Reorder")
                            name = "ReOrder";
                        else if (name == "TotalHours")
                            name = "Totalhours";


                        #endregion

                        colName = Additional_Barcode.GetValueByResourceKey(name.ToString());
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            colName = Additional_Barcode.GetValueByResourceKey(name.ToLower().ToString());
                        }
                        catch
                        {

                        }
                    }
                    //
                    if (!string.IsNullOrEmpty(colName))
                        item.Name = colName;

                    columnsNamesList.Add(item);
                    Cmb_ConditionColumn.Items.Add(item);
                    LB_Columns.Items.Add(item);
                }
            }
            //Cmb_ConditionColumn.DataSource = columnsNamesList;
            Cmb_ConditionColumn.DisplayMember = "Name";
            Cmb_ConditionColumn.ValueMember = "Type";
            Cmb_ConditionColumn.SelectedIndex = 0;

            //          LB_Columns.DataSource = columnsNamesList;
            LB_Columns.DisplayMember = "Name";
            LB_Columns.ValueMember = "Type";
            Cmb_ConditionColumn.SelectedIndex = 0;

        }
        private void handleDataTypeColumn()
        {
            string colType = "";
            string colName = Cmb_ConditionColumn.GetItemText(Cmb_ConditionColumn.SelectedItem);

            var model = dataList.Where(x => x.Name == colName).FirstOrDefault();
            if (model != null)
                colType = model.Type;


            txt_CondtionValue.Clear();
            txt_NumericConditionValue.Clear();
            txt_DateCondtionValue.Text = null;
            txt_CondtionValue.Visible = false;
            txt_NumericConditionValue.Visible = false;
            txt_DateCondtionValue.Visible = false;
            lbl_DataTypeHelp.Visible = false;
            rdoNo.Visible = false;
            rdoYes.Visible = false;
            rdoNo.Checked = false;
            rdoYes.Checked = false;

            colType.ToLower();
            if (colType == "datetime")
                txt_DateCondtionValue.Visible = true;
            else if (colType == "nvarchar" || colType == "varchar")
                txt_CondtionValue.Visible = true;
            else if (colType == "bit")
            {
                rdoNo.Visible = true;
                rdoYes.Visible = true;
            }
            else if (colType == "decimal" || colType == "int" || colType == "smallint" || colType == "numeric" || colType == "money")
            {
                txt_NumericConditionValue.Visible = true;
                lbl_DataTypeHelp.Visible = true;
            }
        }
        private bool enableDisableBtn_Add()
        {
            bool retval = false;
            if (LB_Conditions.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(txt_CondtionValue.Text) || !string.IsNullOrEmpty(txt_DateCondtionValue.Text) || !string.IsNullOrEmpty(txt_NumericConditionValue.Text))
                    retval = true;
                else if (rdoNo.Checked == true || rdoYes.Checked == true)
                    retval = true;
            }
            else
                retval = false;
            btn_Add.Enabled = retval;
            return retval;
        }
        #endregion

        #region events 
        private void CustomReport_Load(object sender, EventArgs e)
        {
            txt_CondtionValue.Visible = false;
            txt_NumericConditionValue.Visible = false;
            txt_DateCondtionValue.Visible = false;
            lbl_DataTypeHelp.Visible = false;
            rdoNo.Visible = false;
            rdoYes.Visible = false;
            rdoNo.Checked = false;
            rdoYes.Checked = false;
            chkRightToLift.Checked = true;
            populateTables();
        }

        // select tab
        private void LB_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedColumns = "";
            selectedTable = "";
            ListConditionQuery.Items.Clear();
            LB_selectedColumns.Items.Clear();
            if (LB_Tables.SelectedItem != null)
            {
                //string selected = this.LB_Tables.GetItemText(this.LB_Columns.SelectedItem);
                string selected = LB_Tables.SelectedItem.ToString();
                selectedTable = tablesNamesList.Where(x => x.Name == selected).FirstOrDefault().Value;

                //selectedTable = LB_Tables.SelectedItem.ToString();
                populateColumnsOnTable(selectedTable);
                SQLQuery = string.Format("SELECT {0} FROM {1}", selectedColumns, selectedTable);
            }
            txtQuery.Text = SQLQuery;
        }
        // for the sake of the example, I defined a single List<int>
        List<int> listBox1_selection = new List<int>();
        List<string> selectedColumns_selection = new List<string>();

        private void TrackSelectionChange(ListBox lb, List<int> selection)
        {
            string name = lb.Text;
            ListBox.SelectedIndexCollection sic = lb.SelectedIndices;
            foreach (int index in sic)
                if (!selection.Contains(index))
                {
                    selection.Add(index);
                    string selected = lb.GetItemText(lb.SelectedItem);
                    selectedColumns_selection.Add(selected);
                }

            foreach (int index in new List<int>(selection))
                if (!sic.Contains(index))
                    selection.Remove(index);
        }
        private void LB_Columns_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selected = "";
            selected = LB_Columns.GetItemText(LB_Columns.SelectedItem);
            if (string.IsNullOrEmpty(selected))
                return;

            LB_selectedColumns.Items.Add(selected);
            LB_Columns.Items.Remove(LB_Columns.SelectedItem);
            selected = columnsNamesList.Where(x => x.Name == selected).FirstOrDefault().Value;
            selectedColumns += selected + ", ";

            // if (selectedColumns.Contains(','))
            // {
            //     int firstComma = selectedColumns.IndexOf(',');
            //     if (firstComma == 0)
            //         selectedColumns = selectedColumns.Remove(firstComma, 1);
            // }

            SQLQuery = string.Format("SELECT {0} FROM {1}", selectedColumns, selectedTable);
            txtQuery.Text = SQLQuery;
            //TrackSelectionChange((ListBox)sender, listBox1_selection);
            //ListBox lb = (ListBox)sender;

            //for (int i = 0; i < listBox1_selection.Count; i++)
            //{
            //    //LB_Columns.SelectedIndex = listBox1_selection[i];
            //    //int indexof = listBox1_selection[i];
            //    //LB_Columns.SelectedIndex = indexof;
            //    //selected = lb.selec;
            //}
            //selectedColumns = "";

            //string selected = "";
            //selected = LB_Columns.GetItemText(LB_Columns.SelectedItem);
            //
            //selected = columnsNamesList.Where(x => x.Name == selected).FirstOrDefault().Value;
            //selectedColumns += selected + ", ";
            //if (selectedColumns.Contains(','))
            //{
            //    int lastComma = selectedColumns.LastIndexOf(',');
            //    selectedColumns = selectedColumns.Remove(lastComma, 1);
            //}
            //
            //SQLQuery = string.Format("SELECT {0} FROM {1}", selectedColumns, selectedTable);
            //txtQuery.Text = SQLQuery;
        }

        // where tab
        private void Cmb_ConditionColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableBtn_Add();
            handleDataTypeColumn();


        }

        private void LB_Conditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableDisableBtn_Add();
            if (LB_Conditions.SelectedItem.ToString() == and || LB_Conditions.SelectedItem.ToString() == like)
            {
                handleAndLikeCondition(false);
                if (ListConditionQuery.Items.Count > 0)
                {


                    btn_Add.Enabled = true;
                }
                else
                    btn_Add.Enabled = false;

            }
            else if (LB_Conditions.SelectedItem.ToString() != and || LB_Conditions.SelectedItem.ToString() != like)
            {
                Cmb_ConditionColumn.Enabled = true;
                handleDataTypeColumn();
                //handleAndLikeCondition(true);
            }

        }

        private void txt_CondtionValue_KeyUp(object sender, KeyEventArgs e)
        {
            //SQLQuery = string.Format("SELECT {0} FROM {1}", selectedColumns, selectedTable);
            enableDisableBtn_Add();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {


            string selected = Cmb_ConditionColumn.GetItemText(Cmb_ConditionColumn.SelectedItem);


            if (LB_Conditions.GetItemText(LB_Conditions.SelectedItem) == like)
            {
                ListConditionQuery.Items.Add("Like");
                LB_Conditions.Text = "";
                return;
            }
            else if (LB_Conditions.GetItemText(LB_Conditions.SelectedItem) == and)
            {
                ListConditionQuery.Items.Add("AND");
                LB_Conditions.Text = "";
                return;
            }
            selected = columnsNamesList.Where(x => x.Name == selected).FirstOrDefault().Value;

            string conditionValue = "";
            string conditions = "";

            if (!string.IsNullOrEmpty(txt_CondtionValue.Text))
                conditionValue = txt_CondtionValue.Text;
            else if (!string.IsNullOrEmpty(txt_NumericConditionValue.Text))
                conditionValue = txt_NumericConditionValue.Text;
            else if (rdoYes.Checked == true)
                conditionValue = "1";
            else if (rdoNo.Checked == true)
                conditionValue = "0";
            else if (!string.IsNullOrEmpty(txt_DateCondtionValue.Text))
            {
                if (txt_DateCondtionValue.Visible == false)
                    return;
                conditionValue = string.Format("\'{0}\'", txt_DateCondtionValue.Text);
                selected = string.Format("cast({0} as dAte)", selected);
            }
            else
                return;

            conditions = string.Format("{0} {1} {2}", selected, LB_Conditions.SelectedItem, conditionValue);
            if (LB_Conditions.SelectedItem.ToString() == and)
                ListConditionQuery.Items.Add(and);
            else
                ListConditionQuery.Items.Add(conditions);

            Cmb_ConditionColumn.SelectedIndex = 0;
            conditionValue = "";
            txt_CondtionValue.Clear();
            txt_NumericConditionValue.Clear();
            //txt_DateCondtionValue.Text = "";
            Cmb_ConditionColumn.Text = "";

            //LB_Conditions.SelectedItem = null;
            //txtConditions.Text=
        }
        // 
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (LB_selectedColumns.Items.Count < 1 || LB_Tables.SelectedItems.Count < 1)
            {
                MessageBox.Show(Additional_Barcode.GetValueByResourceKey("YouNeedToSelectAtLeastOneColumn"));
                return;
            }
            if (txtQuery.Text.Contains(','))
            {
                int lastcomma = txtQuery.Text.LastIndexOf(',');
                txtQuery.Text = txtQuery.Text.Remove(lastcomma, 1);
            }
            passQuery = txtQuery.Text;
            where = "";
            if (ListConditionQuery.Items.Count > 0)
            {
                CondtionsList = new List<string>();
                for (int i = 0; i < ListConditionQuery.Items.Count; i++)
                {
                    string item = ListConditionQuery.Items[i].ToString();
                    if (item == and)
                        item = " AND ";
                    where += item + " ";
                }
                //if (where.Contains(','))
                //{
                //    int lastComma = where.LastIndexOf(',');
                //    where = where.Remove(lastComma, 1);
                //}

                passQuery += " where " + where;
            }
            FormQuery form = new FormQuery();
            form.ShowDialog();

        }

        private void SetLanguage()
        {
            lbl_DataTypeHelp.Text = Additional_Barcode.GetValueByResourceKey("NumericOnly");
            this.Text = Additional_Barcode.GetValueByResourceKey("CustomReport");
            //lblHint.Text = Additional_Barcode.GetValueByResourceKey("CustomReportHint");
            lblWhere.Text = Additional_Barcode.GetValueByResourceKey("Where");
            label1.Text = Additional_Barcode.GetValueByResourceKey("Table");
            label2.Text = Additional_Barcode.GetValueByResourceKey("Column");
            tabPage1.Text = Additional_Barcode.GetValueByResourceKey("Select");
            tabPage2.Text = Additional_Barcode.GetValueByResourceKey("Where");
            btnDel.Text = Additional_Barcode.GetValueByResourceKey("DeleteRow");
            btn_Add.Text = Additional_Barcode.GetValueByResourceKey("Add");
            btnClear.Text = Additional_Barcode.GetValueByResourceKey("Close");
            btnSubmit.Text = Additional_Barcode.GetValueByResourceKey("Ok");
            and = Additional_Barcode.GetValueByResourceKey("And");
            like = Additional_Barcode.GetValueByResourceKey("Like");
            lblSelectColumn.Text= Additional_Barcode.GetValueByResourceKey("SelectColumn");
            chkRightToLift.Text = Additional_Barcode.GetValueByResourceKey("RightToLeft");
            LB_Conditions.Items.Add(and);
            LB_Conditions.Items.Add(like);
            //D:\BumedianPOS\SamplesAmpos\ResourceFile\Resources.ar-sa.resx

            //label1.Text = Additional_Barcode.GetValueByResourceKey("AppDiscountOn");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListConditionQuery.SelectedItems.Count; i++)
            {
                ListConditionQuery.Items.Remove(ListConditionQuery.SelectedItems[i]);
            }
        }

        private void txt_NumericConditionValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_DateCondtionValue_ValueChanged(object sender, EventArgs e)
        {
            enableDisableBtn_Add();
        }

        private void txt_NumericConditionValue_KeyUp(object sender, KeyEventArgs e)
        {
            enableDisableBtn_Add();
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            enableDisableBtn_Add();
        }

        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            enableDisableBtn_Add();
        }
        #endregion

        private void btnAddSelected_Click(object sender, EventArgs e)
        {

        }

        private void LB_selectedColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = "";
            selected = LB_selectedColumns.GetItemText(LB_selectedColumns.SelectedItem);
            if (!string.IsNullOrEmpty(selected))
            {

                //selected = columnsNamesList.Where(x => x.Name == selected).FirstOrDefault().Value;

                //CustomReportObjectClass item = new CustomReportObjectClass();
                //item.Name = selected;
                //string colName = FormQuery.GetEmbeddedResourceMapping(item.Name);
                //if (!string.IsNullOrEmpty(colName))
                //    item.Name = colName;
                //columnsNamesList.Add(item);

                Cmb_ConditionColumn.Items.Add(selected);


                LB_Columns.Items.Add(selected);

                LB_selectedColumns.Items.Remove(LB_selectedColumns.SelectedItem);

                var model = columnsNamesList.Where(x => x.Name == selected).FirstOrDefault();
                selected = model == null ? selected : model.Value;
                if (string.IsNullOrEmpty(selected))
                    return;

                selectedColumns += ", " + selected;
                if (selectedColumns.Contains(selected))
                {
                    selectedColumns = selectedColumns.Replace(selected, "");
                    selectedColumns = trimExtraCommaInQuery(selectedColumns);
                }
                SQLQuery = string.Format("SELECT {0} FROM {1}", selectedColumns, selectedTable);
                txtQuery.Text = SQLQuery;
            }
        }

        private void chkRightToLift_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRightToLift.Checked)
            {
                LB_Tables.RightToLeft = RightToLeft.Yes;
                LB_Columns.RightToLeft = RightToLeft.Yes;
                LB_selectedColumns.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                LB_Tables.RightToLeft = RightToLeft.No;
                LB_Columns.RightToLeft = RightToLeft.No;
                LB_selectedColumns.RightToLeft = RightToLeft.No;
            }
        }
    }
}