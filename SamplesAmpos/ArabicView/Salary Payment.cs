using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ObjectHelper;
using BumedianBM.ViewHelper;
using BALHelper;
using CommonHelper;
using System.Threading;
using System.Configuration;
namespace BumedianBM.ArabicView
{
    public partial class Salary_Payment : Form, IDisposable
    {
        #region Variables
        Dictionary<string, List<EmployeeObjectClass>> ObjDicSalary = new Dictionary<string, List<EmployeeObjectClass>>();
        SalaryPaymentHelper ObjSalPayHelper;
        BindingSource BindSource;
        #endregion

        #region Construtor
        public Salary_Payment()
        {
            InitializeComponent();
            SetLanguage();
            setFont();
            HideShowControls();
            ObjSalPayHelper = new SalaryPaymentHelper();
        }

        private void HideShowControls()
        {
            btnVariables.Enabled = UserScreenLimidations.Users;
            btnPaySalary.Enabled = UserScreenLimidations.PaySalary;
        }
        #endregion

        #region Language
        public void SetLanguage()
        {
            try
            {
                lblPayEmp.Text = Additional_Barcode.GetValueByResourceKey("PayEmp");
                lblPaySalaryFromDate.Text = Additional_Barcode.GetValueByResourceKey("PayFromDate");
                lblTodate.Text = Additional_Barcode.GetValueByResourceKey("TD");
                lblTotalSalary.Text = Additional_Barcode.GetValueByResourceKey("TSalary");
                lblTotalSales.Text = Additional_Barcode.GetValueByResourceKey("TSale");
                btnClose.Text = Additional_Barcode.GetValueByResourceKey("Close");
                btnNew.Text = Additional_Barcode.GetValueByResourceKey("New");
                btnPaySalary.Text = Additional_Barcode.GetValueByResourceKey("PaySal");
                btnPrint.Text = Additional_Barcode.GetValueByResourceKey("Print");
                btnTimeAttendance.Text = Additional_Barcode.GetValueByResourceKey("TAttandance");
                btnUndoPayment.Text = Additional_Barcode.GetValueByResourceKey("Undopay");
                btnVariables.Text = Additional_Barcode.GetValueByResourceKey("Variables");
                btnView.Text = Additional_Barcode.GetValueByResourceKey("View");
                chkAllEmp.Text = Additional_Barcode.GetValueByResourceKey("All");
                this.Text = Additional_Barcode.GetValueByResourceKey("SalaryPayment");

                dgrSalaryPaymentList.Columns["Select"].HeaderText = Additional_Barcode.GetValueByResourceKey("Select");
                dgrSalaryPaymentList.Columns["EmployeeID"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpId");
                dgrSalaryPaymentList.Columns["EmployeeName"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpName");
                dgrSalaryPaymentList.Columns["CalType"].HeaderText = Additional_Barcode.GetValueByResourceKey("System");
                dgrSalaryPaymentList.Columns["BaseSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("BaseSalary");
                dgrSalaryPaymentList.Columns["OverTimeSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("OverTimeSalary");
                dgrSalaryPaymentList.Columns["HolidaySalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("HolidaySalary");
                dgrSalaryPaymentList.Columns["EmpSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpSalary");
                dgrSalaryPaymentList.Columns["EmpOverSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpOverSalary");
                dgrSalaryPaymentList.Columns["EmpHolidaySalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("EmpHolidaySalary");
                dgrSalaryPaymentList.Columns["Advances"].HeaderText = Additional_Barcode.GetValueByResourceKey("Adv");
                dgrSalaryPaymentList.Columns["Punishment"].HeaderText = Additional_Barcode.GetValueByResourceKey("Punish");
                dgrSalaryPaymentList.Columns["Neglet"].HeaderText = Additional_Barcode.GetValueByResourceKey("Neglect");
                dgrSalaryPaymentList.Columns["Reward"].HeaderText = Additional_Barcode.GetValueByResourceKey("Reward");
                dgrSalaryPaymentList.Columns["Incentives"].HeaderText = Additional_Barcode.GetValueByResourceKey("Incentives");
                dgrSalaryPaymentList.Columns["Others"].HeaderText = Additional_Barcode.GetValueByResourceKey("Others");
                dgrSalaryPaymentList.Columns["DrawingAmount"].HeaderText = Additional_Barcode.GetValueByResourceKey("DrawingAmount");
                dgrSalaryPaymentList.Columns["Latency"].HeaderText = Additional_Barcode.GetValueByResourceKey("Latency");
                dgrSalaryPaymentList.Columns["Average"].HeaderText = Additional_Barcode.GetValueByResourceKey("Average");
                dgrSalaryPaymentList.Columns["NetSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("NetSalary");
                //dgrSalaryPaymentList.Columns["TotalDays"].HeaderText = Additional_Barcode.GetValueByResourceKey("SalaryType");
                //dgrSalaryPaymentList.Columns["EmpPresentDays"].HeaderText = Additional_Barcode.GetValueByResourceKey("Status");
                //dgrSalaryPaymentList.Columns["OverTiming"].HeaderText = Additional_Barcode.GetValueByResourceKey("PassNo");
                //dgrSalaryPaymentList.Columns["HolidayOverTime"].HeaderText = Additional_Barcode.GetValueByResourceKey("SalaryType");
                //dgrSalaryPaymentList.Columns["PerDaySalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("Status");
                //dgrSalaryPaymentList.Columns["PerHourSalary"].HeaderText = Additional_Barcode.GetValueByResourceKey("PassNo");

                cmbPayEmployee.Items.Add(Additional_Barcode.GetValueByResourceKey("MonthlySal"));
                cmbPayEmployee.Items.Add(Additional_Barcode.GetValueByResourceKey("WeeklySal"));
                cmbPayEmployee.Items.Add(Additional_Barcode.GetValueByResourceKey("HourlySal"));
                cmbPayEmployee.Items.Add(Additional_Barcode.GetValueByResourceKey("PercentageSal"));
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        #endregion

        #region Load
        private void Salary_Payment_Load(object sender, EventArgs e)
        {
            try
            {
                //***********Date Format for DatetimPicker control by Seenivasan on 13-Oct-2014************************//
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.Format = DateTimePickerFormat.Custom;

                dtpToDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                dtpFromDate.CustomFormat = ConfigurationSettings.AppSettings["DateFormat"].ToString();
                //***********Date Format Check*****************************************************//
                LoadSalaryPaymentMethod();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Private Methods
        private void SetObjectsFromControls()
        {
            //ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.FromDate = Convert.ToDateTime(dtpFromDate.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            //ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.ToDate = Convert.ToDateTime(dtpToDate.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.FromDate = Convert.ToDateTime(dtpFromDate.Value);
            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.ToDate = Convert.ToDateTime(dtpToDate.Value);
            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.chkAllEmployee = chkAllEmp.Checked;
            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.cmbPayEmpOf = Convert.ToInt32(cmbPayEmployee.SelectedIndex.ToString());
        }

        private void LoadSalaryPaymentMethod()
        {
            DateTime dFirstDayOfThisMonth = DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
            DateTime dLastDayOfThisMonth = dFirstDayOfThisMonth.AddMonths(1).AddDays(-1);
            //dtpFromDate.Text = dFirstDayOfThisMonth.ToString();//Commented on 31-May-2014 for Date Format Issues
            //dtpToDate.Text = dLastDayOfThisMonth.ToString();//Commented on 31-May-2014 for Date Format Issues
            //dtpToDate.MaxDate = Convert.ToDateTime(dtpToDate.Text.ToString());//Commented on 31-May-2014 for Date Format Issues
            dtpFromDate.Value = dFirstDayOfThisMonth;
            dtpToDate.Value = dLastDayOfThisMonth;
            dtpToDate.MaxDate = Convert.ToDateTime(dtpToDate.Value);
            //Btn_PaySalary.Enabled = UserScreenLimidations.PaySalary == "YES" ? true : false;
            // Btn_Print.Enabled = UserScreenLimidations.Print == "YES" ? true : false;
        }
        #endregion

        #region Events
        #region PaySalary_Click
        private void btnPaySalary_Click(object sender, EventArgs e)
        {
            try
            {
                PaySalary();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region NewClick
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSalaryPaymentMethod();
                cmbPayEmployee.SelectedIndex = -1;
                btnPaySalary.Enabled = true;
                txtTotalSalary.Text = "0.000";
                txtTotalSales.Text = "0.000";
                dtpFromDate.Focus();
                chkAllEmp.Checked = false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region View Click
        private void btnView_Click(object sender, EventArgs e)
        {
            List<EmployeeObjectClass> lstsaldetails;
            try
            {
                SetObjectsFromControls();
                int ViewType = -1;
                if (!chkAllEmp.Checked)
                {
                    if (cmbPayEmployee.SelectedIndex != -1)
                        ViewType = cmbPayEmployee.SelectedIndex;
                }
                if (chkAllEmp.Checked)
                {
                    ViewType = 4;
                }
                lstsaldetails = new List<EmployeeObjectClass>();
                lstsaldetails.Clear();
                lstsaldetails = ObjSalPayHelper.GetEmpSalaryDetails(ViewType);
                // BindingSource bs = new BindingSource();//Added on 6-May-2014
                BindSource = new BindingSource();
                BindSource.DataSource = null;
                BindSource.DataSource = lstsaldetails;//Added on 6-May-2014
                dgrSalaryPaymentList.AutoGenerateColumns = false;
                dgrSalaryPaymentList.DataSource = null;
                //dgrSalaryPaymentList.DataSource = lstsaldetails;//Commented on 6-May-2014
                dgrSalaryPaymentList.DataSource = BindSource;
                // bs.DataSource = dgrSalaryPaymentList.DataSource;
                // List<EmployeeObjectClass> objlist = new List<EmployeeObjectClass>();
                //   List<EmployeeObjectClass> objlist = ((List<EmployeeObjectClass>)dgrSalaryPaymentList.DataSource).Cast<EmployeeObjectClass>().ToList();
                // objlist=

                txtTotalSalary.Text = ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.TotalSalaryText == null ? "0.000" : ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.TotalSalaryText.ToString();
                txtTotalSales.Text = ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.TotalSaleText == null ? "0.000" : ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.TotalSaleText.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstsaldetails = null;
            }
        }
        #endregion

        #region Variables Click
        private void btnVariables_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Tag = "EmpVariable";
            emp.ShowDialog();
        }
        #endregion

        #region TimeAttendance_Click
        private void btnTimeAttendance_Click(object sender, EventArgs e)
        {
            Time_Attandance_Sheet AttenRep = new Time_Attandance_Sheet();
            AttenRep.ShowDialog();
        }
        #endregion

        #region UndoPayment
        private void btnUndoPayment_Click(object sender, EventArgs e)
        {
            List<EmployeeObjectClass> listSalarygrid;
            try
            {
                //List<EmployeeObjectClass> objlist = ((List<EmployeeObjectClass>)BindSource.DataSource).Cast<EmployeeObjectClass>().ToList();
                //DTable = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>((List<EmployeeObjectClass>)objlist);

                listSalarygrid = ((List<EmployeeObjectClass>)BindSource.DataSource).Cast<EmployeeObjectClass>().ToList();
                // listSalarygrid = (List<EmployeeObjectClass>)dgrSalaryPaymentList.DataSource;
                bool result = ObjSalPayHelper.UndoPaymentHelper(listSalarygrid);
                if (result)
                {
                    ClearTheGridView();
                    //  btnPaySalary.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                listSalarygrid = null;
            }
        }

        private void ClearTheGridView()
        {
            dgrSalaryPaymentList.DataSource = null;
        }
        #endregion

        #endregion

        #region PaySalary
        private void PaySalary()
        {
            if (dgrSalaryPaymentList.DataSource != null)
            {
                int count = dgrSalaryPaymentList.Rows.Count;
                int rowChkcnt = 0; int countAdd = 0;
                for (int g = 0; g < count; g++)
                {
                    bool forchk = Convert.ToBoolean(dgrSalaryPaymentList.Rows[g].Cells[0].Value.ToString());
                    if (forchk == true)
                    { rowChkcnt += 1; }
                }
                if (rowChkcnt > 0)
                {
                    for (int k = 0; k < count; k++)
                    {
                        bool forchk = Convert.ToBoolean(dgrSalaryPaymentList.Rows[k].Cells[0].Value.ToString());
                        if (forchk == true)
                        {
                            DateTime PaidDate = DateTime.Now.Date;
                            decimal Advances, Punishment, Neglet, Reward, Incentives, Others;
                            Advances = (dgrSalaryPaymentList.Rows[k].Cells["Advances"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Advances"].Value.ToString()) : Convert.ToDecimal("0.000");
                            Punishment = (dgrSalaryPaymentList.Rows[k].Cells["Punishment"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Punishment"].Value.ToString()) : Convert.ToDecimal("0.000");
                            Neglet = (dgrSalaryPaymentList.Rows[k].Cells["Neglet"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Neglet"].Value.ToString()) : Convert.ToDecimal("0.000");
                            Reward = (dgrSalaryPaymentList.Rows[k].Cells["Reward"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Reward"].Value.ToString()) : Convert.ToDecimal("0.000");
                            Incentives = (dgrSalaryPaymentList.Rows[k].Cells["Incentives"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Incentives"].Value.ToString()) : Convert.ToDecimal("0.000");
                            Others = (dgrSalaryPaymentList.Rows[k].Cells["Others"].Value.ToString() != "") ? Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Others"].Value.ToString()) : Convert.ToDecimal("0.000");
                            decimal variableAmt = (Advances + Punishment + Neglet + Reward + Incentives + Others);
                            string AmountPaid = dgrSalaryPaymentList.Rows[k].Cells["NetSalary"].Value.ToString();

                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.UserId = Convert.ToInt32(dgrSalaryPaymentList.Rows[k].Cells["EmployeeID"].Value.ToString());
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.TotalAmount = Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["BaseSalary"].Value.ToString()) + Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["BaseSalary"].Value.ToString());

                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.VariableAmount = variableAmt;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.NetSalary = Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["NetSalary"].Value.ToString());
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.SalaryId = 0;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.DrawAmt = Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["DrawingAmount"].Value.ToString());
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.LatencyAmt = Convert.ToDecimal(dgrSalaryPaymentList.Rows[k].Cells["Latency"].Value.ToString());
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.AmountAbsence = 150;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.PaidDate = PaidDate;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.CreatedBy = Convert.ToInt32(dgrSalaryPaymentList.Rows[k].Cells["EmployeeID"].Value.ToString());
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.CreatedDate = PaidDate;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.Status = 1;
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.FromDate = Convert.ToDateTime(dtpFromDate.Value.Date);
                            ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.ToDate = Convert.ToDateTime(dtpToDate.Value.Date);
                            int i = ObjSalPayHelper.Save_PaySalaryDetails();
                            if (i > 0) { Salaryspending(); }
                            countAdd += i;
                        }
                    }
                    if (countAdd >= 1)
                    {
                        GeneralFunction.Information("SalaryPaidSuccess", this.Text);
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Save), "Salary Payment", "USER_SALARY_PAYMENT", "Insert salary payment details", Convert.ToInt32(InvoiceAction.No));
                        countAdd = 0;
                    }
                    else
                    { GeneralFunction.Information("AlreadyPaidSalary", this.Text); }
                }
                else
                {
                    GeneralFunction.Information("Select the Employee for Salary Payment", this.Text);
                }
            }
        }
        #endregion

        #region SalarySpending
        public void Salaryspending()
        {
            if (ObjSalPayHelper.ObjSalPay.ObjEmployeeObject.NetSalary != 0)
            {
                ObjSalPayHelper.SaveSpendings();
            }
        }
        #endregion

        #region "KeyPress Events"
        private void cmbPayEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.InvokeOnClick(btnView, EventArgs.Empty);
            }
        }
        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region KeyDown Events

        private void Salary_Payment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information pric = new Quick_Price_Information();
                    pric.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region "CheckBox Checked Changed Event"

        private void Chk_AllEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllEmp.Checked == true)
            {
                cmbPayEmployee.SelectedIndex = -1;
                cmbPayEmployee.Enabled = lblPayEmp.Enabled = false;
            }
            else
            {
                cmbPayEmployee.SelectedIndex = -1;
                cmbPayEmployee.Enabled = lblPayEmp.Enabled = true;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable DTable = new DataTable("SalaryPayment");
            List<EmployeeObjectClass> objlist;
            try
            {
                objlist = ((List<EmployeeObjectClass>)BindSource.DataSource).Cast<EmployeeObjectClass>().ToList();
                DTable = CommonHelper.ConvertionHelper.ConvertToDataTable<EmployeeObjectClass>((List<EmployeeObjectClass>)objlist);
                //DTable=CommonHelper.GeneralFunction.
                if (DTable != null)
                {
                    if (DTable.Rows.Count > 0)
                    {
                        // this.InvokeOnClick(btnView, EventArgs.Empty);
                        ObjSalPayHelper.Print(DTable);
                    }
                    else
                    { GeneralFunction.Information("NoRecordsFound", this.Text); }
                }
                else
                { GeneralFunction.Information("NoRecordsFound", this.Text); }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally
            {
                objlist = null;
            }
        }

        private List<EmployeeObjectClass> CAST<T1>()
        {
            throw new NotImplementedException();
        }

        private void setFont()
        {
            var Culture = Thread.CurrentThread.CurrentUICulture;
            if (Culture.Name == "en-US")
            {
                for (int i = 0; i <= this.tableLayoutPanel1.ColumnCount; i++)
                {
                    for (int j = 0; j <= this.tableLayoutPanel1.RowCount; j++)
                    {
                        Control c = this.tableLayoutPanel1.GetControlFromPosition(i, j);
                        if (c != null)
                        {
                            foreach (Control ct in c.Controls)
                            {
                                if (ct is Button || ct is Label || ct is CheckBox || ct is RadioButton || ct is TabControl || ct is TabPage)
                                    ct.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                else if (ct is GroupBox)
                                {
                                    foreach (Control btn in c.Controls)
                                    {
                                        if (btn is Button || btn is Label || btn is CheckBox || btn is RadioButton || btn is TabControl || btn is TabPage)
                                            btn.Font = new Font("Segoe UI", 10.25f, FontStyle.Bold);
                                    }
                                }
                            }
                            dgrSalaryPaymentList.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        private void Salary_Payment_FormClosed(object sender, FormClosedEventArgs e)
        {
            ObjSalPayHelper.DisposeListObject();
            this.Dispose();
        }
    }
}
