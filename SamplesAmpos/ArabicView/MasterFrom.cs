using System;
using System.Drawing;
using System.Windows.Forms;
using CommonHelper;
using BumedianBM.ViewHelper;
using ObjectHelper;
using System.Threading;
using BALHelper;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Management;
using System.Diagnostics;
namespace BumedianBM.ArabicView
{
    public partial class MasterFrom : Form, IDisposable
    {
        #region Variable
        //HijriToGregs ObjGetDate;
        int SetPanelXY;
        string ToolName;
        string getTagValue;
        //string LastUser = "";
        //int LastUserId;
        //GeneralFunction Obj_CommonClass = new GeneralFunction();  //Performance fine tune by praba on 20-Nov
        //CommonClass Obj_CommonClass;
        EmployeeHelper objemphelper = new EmployeeHelper();
        bool ChangeUser = false;
        //EmployeeObjectClass objemp=new EmployeeObjectClass();
        LoginViewHelper loginViewHelper;
        //LoginObjectClass loginObjectHelper;
        //private Thread ScrollThread;
        string _ScrollNotes = string.Empty;
        public bool ResetScrollNotes = false;
        bool DisplayWorknote = false;
        private delegate void ScrollText();
        private delegate void LoginTimeText();
        MasterDataBALClass ObjMasterDataBALClass;
        //public static string User { set { toolStripStatusLabel2.Text = value; } get { return toolStripStatusLabel2.Text; } }
        public static String userId { set; get; }
        public static String Username { set; get; }
        public static String Password { set; get; }
        //Employee Obj_EmpProp;
        bool UserFocused = true;
        bool PasswrdFocused = false;
        int DisplayExpiryCount = 1;
        int DisplayReorderCount = 1;
        bool isFormClose = false;
        string appVersion = string.Empty;
        bool islogin = false;
        bool login = false;
        bool RegistrationVariable = false;
        //ServerConnViewHelper serverconnection;
        CustomNotesAlerts ObjMessage;
        public bool isFromCleanDB = false;
        public int trialDays = 1;
        OptionSettingHelper objOptionSettingHelper;
        private BackgroundWorker worker;
        public BackgroundWorker Worker
        {
            get
            {
                if (worker == null)
                    worker = new BackgroundWorker();
                return worker;
            }

        }
        #endregion
        public SalesInvoiceHelper objSaleInvoiceHelper = new SalesInvoiceHelper();
        public MasterFrom()
        {
            //    DateTime t = DateTime.MinValue;
            //   DateTime s = DateTime.MaxValue;
            //GeneralFunction.Trace("MasterFrom Const Start");
            InitializeComponent();
            Initializeobject();
            // ObjGetDate = new HijriToGregs();

            loginViewHelper = new LoginViewHelper(this);
            objOptionSettingHelper = new OptionSettingHelper();

            // Checking is Database Connected
            if (!loginViewHelper.CheckActiveConnectionHelp())
            {
                GeneralFunction.Information("serverisdisconnected", ActionType.DBConnection.ToString());
                Server_Connection ServerConn = new Server_Connection();

                if (ServerConn.ShowDialog() == DialogResult.OK)
                {
                    GeneralFunction.isApplnRestart = true;
                    //  GeneralFunction.SetConfigValue("Restart", "True");
                    Application.Restart();
                }
                ServerConn = null;
                Environment.Exit(0);
                return;
            }
            //
            ObjMasterDataBALClass = new MasterDataBALClass();
            GeneralFunction.Language = ConfigurationSettings.AppSettings["Language"].ToString();
            SetLanguage();
            string curFile = AppDomain.CurrentDomain.BaseDirectory + "IT.dat";
            if (File.Exists(curFile) == true)
            {
                GeneralFunction.IsServer = true;
            }
            else
            {
                GeneralFunction.IsServer = false;
            }
            if (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width == 1024 && System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 768)
            {
                this.toolStripStatusLabel7.Size = new Size(110, 17);
                this.toolStripStatusLabel4.Size = new Size(160, 17);
                this.toolStripStatusLabel2.Size = new Size(200, 17);
            }
            else if ((System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width == 1280 && System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 720) || (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width == 1280 && System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height == 768))
            {
                this.toolStripStatusLabel7.Size = new Size(120, 17);
                this.toolStripStatusLabel4.Size = new Size(200, 17);
                this.toolStripStatusLabel2.Size = new Size(320, 17);
            }
            LoadSubMenus("Login", 0, 0);
            objSaleInvoiceHelper.GetSaleDetailsHelper();//added on 9/01/16
            BGWork();
            //loginObjectHelper = new LoginObjectClass();
            //loginViewHelper = new LoginViewHelper(this); //Commented by Praba on 09-Jan-2015 for performance
           
            //loginViewHelper = new LoginViewHelper(this);
           
            // Purchase_Invoice obj = new Purchase_Invoice();
            // Obj_EmpProp = new Employee();
            //serverconnection = new ServerConnViewHelper();
            ObjMessage = new CustomNotesAlerts();
            GeneralFunction.workstationName = LicensenceObjectClass.GetMachineID();  // Due to MotherBoardID issue, we added the 3 type of Hardware ID to find the MachineID  Done by Praba on 21-Jun-2017
            GeneralFunction.Trace(GeneralFunction.workstationName);
            
        }


        //New function done by Praba on 12-Jan-2015 for Performance fine tune
        public void BGWork()
        {
            try
            {
               if (bgwMasterDataLoad!= null) bgwMasterDataLoad = new BackgroundWorker();
                bgwMasterDataLoad.WorkerReportsProgress = true;
                bgwMasterDataLoad.WorkerSupportsCancellation = true;
                bgwMasterDataLoad.DoWork += new DoWorkEventHandler(bgwMasterDataLoad_DoWork);
                bgwMasterDataLoad.ProgressChanged += new ProgressChangedEventHandler(bgwMasterDataLoad_ProgressChanged);
                bgwMasterDataLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwMasterDataLoad_RunWorkerCompleted);
                bgwMasterDataLoad.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetHDDAddress()
        {
            //string drive = "C";
            //ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            //dsk.Get();
            //string volumeSerial = dsk["VolumeSerialNumber"].ToString();
            //return volumeSerial;
            try
            {
                //GeneralFunction.Trace("GetHDDAddress Started");
                //var HDDNo = string.Empty;
                //ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
                //foreach (ManagementObject queryObj in searcher.Get())
                //{
                //    HDDNo = queryObj["SerialNumber"].ToString();
                //}
                //return HDDNo;
                ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection mcol = mangnmt.GetInstances();
                string result = "";
                foreach (ManagementObject strt in mcol)
                {
                    result = Convert.ToString(strt["VolumeSerialNumber"]);
                    break;
                }

                return result;
            }
            catch (Exception ex)
            {
                //GeneralFunction.Trace(ex.Message);
                return "";
            }
        }

        private void Initializeobject()
        {
            try
            {
                GeneralFunction._server = ConfigurationSettings.AppSettings["Server"].ToString();
                GeneralFunction._database = ConfigurationSettings.AppSettings["Database"].ToString();
                GeneralFunction._UserId = ConfigurationSettings.AppSettings["UserId"].ToString();
                GeneralFunction._password = GeneralFunction.Decrypt(ConfigurationSettings.AppSettings["Password"].ToString());
                GeneralOptionSetting.FlagAutomaticLastBackupDate = ConfigurationSettings.AppSettings["AutomaticLastBackupDate"].ToString();
                GeneralFunction.Language = ConfigurationSettings.AppSettings["Language"].ToString();
                GeneralFunction._showConnectionDialog = (ConfigurationSettings.AppSettings["ShowConnectionDialog"].ToString().Trim() == "Yes") ? true : false;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }


        #region Main Button Function

        private void VisibleLoginPanel()
        {
            flp_MainButtons.Visible = false;
        }
        private void LoadSubMenus(string StrType, int NoofSubMenus, int YLocation)
        {
            //41 -> Button Height, 6 -> Space between 2 Buttons 
            int layoutHeight = (NoofSubMenus * 41) + (NoofSubMenus * 6);

            //SetPanelXY = flp_MainButtons.Location.X - 185;////changed the y axis position from 185 to 210 on 14 july 2014
            SetPanelXY = flp_MainButtons.Location.X + 150; //- 218
            flpSubAgent.Visible = false;
            flpSubPurchase.Visible = false;
            flpSubStock.Visible = false;
            flpSubUserAdmin.Visible = false;
            flpSubAccounts.Visible = false;
            pnlSystemConfig.Visible = false;
            flpSubSale.Visible = false;

            switch (StrType)
            {
                case "Sales":
                    flpSubSale.Visible = true;
                    //flpSubSale.Size = new Size(185, layoutHeight);///Commented  on 14 july 2014 to oincerese the button widht
                    flpSubSale.Size = new Size(250, layoutHeight);
                    flpSubSale.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + YLocation));
                    HideVisibleControls();
                    break;
                case "Purchase":
                    flpSubPurchase.Visible = true;
                    flpSubPurchase.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + YLocation));
                    //flpSubPurchase.Size = new Size(185, layoutHeight);
                    flpSubPurchase.Size = new Size(250, layoutHeight);
                    btnPurchaseInvoice.Visible = UserScreenLimidations.PurchaseInvoice;
                    btnPurInvoiceFind.Visible = UserScreenLimidations.FindPurchaseInvoice;
                    btnPurInvoiceRtn.Visible = UserScreenLimidations.PurchaseReturnInvoice;
                    btnOrderInvoice.Visible = UserScreenLimidations.OrderInvoice;
                    break;
                case "Stock":
                    flpSubStock.Visible = true;
                    flpSubStock.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + YLocation));
                    //flpSubStock.Size = new Size(185, layoutHeight);
                    flpSubStock.Size = new Size(250, layoutHeight);

                    btnItemCard.Visible = UserScreenLimidations.ItemCard;
                    btnPrimaryInfo.Visible = UserScreenLimidations.PrimaryInfo;
                    btnPrintBarcode.Visible = UserScreenLimidations.GenPrintBarcode;
                    btnInventroyAdjusment.Visible = btnOpeningStock.Visible = UserScreenLimidations.InventoryAdjustment;
                    btnSpoiledItems.Visible = UserScreenLimidations.SpoiledItems;
                    btnOpeningStock.Visible = UserScreenLimidations.OpeningStock;
                    btnPriceChange.Visible= GeneralOptionSetting.FlagHideDiscountWindow != "Y" && UserScreenLimidations.GeneralDiscount == true;
                    break;
                case "Agent":
                    flpSubAgent.Visible = true;
                    flpSubAgent.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + YLocation));
                    //flpSubAgent.Size = new Size(185, layoutHeight);
                    flpSubAgent.Size = new Size(250, layoutHeight);

                    btnAgentFile.Visible = UserScreenLimidations.AgentFile;
                    btnDebts.Visible = UserScreenLimidations.Debts;
                    btnDebtAdjusment.Visible = UserScreenLimidations.DeptAdjustment;
                    //btnDebts.Visible = UserScreenLimidations.DeptModifying;
                    break;
                case "Account":
                    flpSubAccounts.Visible = true;
                    flpSubAccounts.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + btnStock.Location.Y));
                    //flpSubAccounts.Size = new Size(185, layoutHeight);
                    flpSubAccounts.Size = new Size(250, layoutHeight);


                    btnBalanceSheet.Visible = UserScreenLimidations.BalanceSheet;
                    btnDrawing.Visible = UserScreenLimidations.Drawings;
                    btnCashCapital.Visible = UserScreenLimidations.CashCapital;
                    btnBankWithdraw.Visible = (UserScreenLimidations.BankWithdraw && checkbalance());
                    btnBankDeposit.Visible = UserScreenLimidations.BankDeposit;
                    btnExpenses.Visible = UserScreenLimidations.Spending;
                    btnPayReceipt.Visible = UserScreenLimidations.PayReceipt;
                    btnReceiveReceipt.Visible = UserScreenLimidations.ReceiveReceipt;
                    break;
                case "User Admin":
                    flpSubUserAdmin.Visible = true;
                    flpSubUserAdmin.Location = new Point(SetPanelXY, (flp_MainButtons.Location.Y + YLocation));
                    //flpSubUserAdmin.Size = new Size(185, layoutHeight);
                    flpSubUserAdmin.Size = new Size(250, layoutHeight);
                    break;
                case "Login":
                    pnlLogin.Visible = true;
                    picLogo.Visible = false;
                    picNotes.Visible = false;
                    flp_MainButtons.Visible = false;
                    menuStrip1.Enabled = false;
                    toolStrip1.Enabled = false;
                    panel3.Visible = false;
                    statusStrip1.Visible = false;
                    lblNotes.Visible = false;
                    Screen screen = Screen.PrimaryScreen;
                    int S_width = screen.Bounds.Width;
                    int S_height = screen.Bounds.Height;
                    pnlLogin.Size = new Size(331, 220);
                    pnlLogin.Location = new Point((((S_width) / 2) - (pnlLogin.Size.Width / 2)), (((S_height - 20) / 2) - (pnlLogin.Size.Height / 2)));
                    // pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                    // pnlLogin.Location = new Point(this.Size.Width / 2-pnlLogin.Size.Width, this.Size.Height / 2-pnlLogin.Size.Height );
                    //pnlLogin.Location = new Point(this.Size.Width / 2, this.Size.Height / 4 - 60);
                    PnlScrollNotes.Visible = false;
                    lblUserNameDisplay.Visible = false;
                    txtUserName.Focus();
                    pgbarLoad.Location = new Point(this.Size.Width / 2, 500);//350
                    lblVersion.Location = new Point(230, 199);
                    lblRelease.Location = new Point(36, 204);
                    break;
                case "MouseOver":
                    pnlMainPanel.Visible = true;
                    break;
                default:
                    pnlLogin.Visible = false;
                    picLogo.Visible = true;
                    menuStrip1.Enabled = true;
                    toolStrip1.Enabled = true;
                    panel3.Visible = true;
                    flp_MainButtons.Visible = true;
                    picNotes.Visible = lblNotes.Visible = true;
                    statusStrip1.Visible = true;
                    //PnlScrollNotes.Visible = true;
                    //lblUserNameDisplay.Visible = true;Commended By Meena.R on 14/07/2014 Note appeared Based on Option Setting
                    lblUserNameDisplay.Text = GeneralFunction.UserName;
                    PnlScrollNotes.Visible = picNotes.Visible = lblNotes.Visible = lblUserNameDisplay.Visible = (GeneralOptionSetting.FlagHideNoteFiled != "Y");
                    toolStripStatusLabel2.Text = GeneralFunction.UserName.ToUpper();
                    toolStripStatusLabel2.Visible = toolStripStatusLabel4.Visible = toolStripStatusLabel5.Visible = toolStripStatusLabel7.Visible = true;
                    break;

            }

        }

        private bool checkbalance()
        {
            return (loginViewHelper.CheckBalanceHelp());
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            try
            {
                string Text = (((Button)sender).Tag).ToString();
                int location = Convert.ToInt16(((Button)sender).Location.Y);
                LoadSubMenus(Text, 8, location);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        void pnlMainPanel_MouseHover(object sender, System.EventArgs e)
        {
            try
            {
                this.LoadSubMenus("MouseOver", 0, 0);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        #endregion

        #region Button ClickEvent
        private void btnClick_Event(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.FormName = ToolName = ((Button)sender).Tag.ToString();
                this.AssignScreen(ToolName);
                this.LoadSubMenus("MouseOver", 0, 0);
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }


        #endregion

        #region Purchase Invoice

        #endregion

        #region Stock

        #endregion

        #region Agent

        private void btnDebts_Click(object sender, EventArgs e)
        {
            try
            {
                ShowingDebts();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Accounts Details

        #endregion

        #region User and Administrator

        #endregion

        #region Report

        #endregion

        #region OptionSetting

        #endregion

        #region SetLanguage
        public void SetLanguage()
        {
            btnSales.Text = Additional_Barcode.GetValueByResourceKey("Sales");
            btnPurchase.Text = Additional_Barcode.GetValueByResourceKey("Purchase");
            btnStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            btnAccounts.Text = Additional_Barcode.GetValueByResourceKey("Account");
            btnAgents.Text = Additional_Barcode.GetValueByResourceKey("Agent");
            btnAgentFile.Text = Additional_Barcode.GetValueByResourceKey("AgentFile");
            btnBalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            btnBankDeposit.Text = Additional_Barcode.GetValueByResourceKey("Bankde");
            btnBankWithdraw.Text = Additional_Barcode.GetValueByResourceKey("Bankwith");
            btnCancel.Text = Additional_Barcode.GetValueByResourceKey("Cancel"); ;
            btnCashCapital.Text = Additional_Barcode.GetValueByResourceKey("CashCapital");
            btnChangeUser.Text = Additional_Barcode.GetValueByResourceKey("ChangeUser");
            btnDebtAdjusment.Text = Additional_Barcode.GetValueByResourceKey("DebtAdjust");
            btnDebts.Text = Additional_Barcode.GetValueByResourceKey("Debts");
            btnDrawing.Text = Additional_Barcode.GetValueByResourceKey("Drawing");
            btnEmployeeFile.Text = Additional_Barcode.GetValueByResourceKey("UserAdminstrator");
            btnExit.Text = Additional_Barcode.GetValueByResourceKey("Exit");
            btnExpenses.Text = Additional_Barcode.GetValueByResourceKey("Spending");
            //btnOpeningStock.Text = Additional_Barcode.GetValueByResourceKey("Inventory");Commended on 25/06/2014
            btnOpeningStock.Text = Additional_Barcode.GetValueByResourceKey("OpeningStock");
            btnInventroyAdjusment.Text = Additional_Barcode.GetValueByResourceKey("InventoryAdjust");
            btnItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            btnPriceChange.Text = Additional_Barcode.GetValueByResourceKey("PriceChange");
            btnLogin.Text = Additional_Barcode.GetValueByResourceKey("Login");
            btnNoteAndAlert.Text = Additional_Barcode.GetValueByResourceKey("NotesAlerts");
            btnOptions.Text = Additional_Barcode.GetValueByResourceKey("Options"); ;
            btnOrderInvoice.Text = Additional_Barcode.GetValueByResourceKey("OrderInvoice");
            btnPayReceipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            btnPosScreen.Text = Additional_Barcode.GetValueByResourceKey("POSScreen");
            btnPosShortCut.Text = Additional_Barcode.GetValueByResourceKey("POSShortCut");
            btnPrimaryInfo.Text = Additional_Barcode.GetValueByResourceKey("PrimaryInfo");
            btnPrintBarcode.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            btnProformanceInvoice.Text = Additional_Barcode.GetValueByResourceKey("PerformanceInvoice");
            btnPurchase.Text = Additional_Barcode.GetValueByResourceKey("Purchase");
            btnPurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            btnPurInvoiceFind.Text = Additional_Barcode.GetValueByResourceKey("FindPurchaseInvoice");
            btnPurInvoiceRtn.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoices");
            btnReceiveReceipt.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceipt"); ;
            btnReports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            btnSalaryPayment.Text = Additional_Barcode.GetValueByResourceKey("SalaryPayment");
            btnSaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            btnSaleInvoiceFind.Text = Additional_Barcode.GetValueByResourceKey("FindSalesInvoice");
            btnSales.Text = Additional_Barcode.GetValueByResourceKey("Sales");
            btnSalesInvoiceRtn.Text = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
            btnSpoiledItems.Text = Additional_Barcode.GetValueByResourceKey("SpoiledItem");
            btnStock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            btnTimeAttendance.Text = Additional_Barcode.GetValueByResourceKey("TAttandance");
            btnUserAdmin.Text = Additional_Barcode.GetValueByResourceKey("UserAdminstrator");
            btnUserTracking.Text = Additional_Barcode.GetValueByResourceKey("UserTrack");
            tslUName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            tslTime.Text = Additional_Barcode.GetValueByResourceKey("Time");
            tslTTime.Text = Additional_Barcode.GetValueByResourceKey("TTime");
            MenuItem_Accounts.Text = Additional_Barcode.GetValueByResourceKey("Account");
            MenuItem_Agents.Text = Additional_Barcode.GetValueByResourceKey("Agent");
            MenuItem_File.Text = Additional_Barcode.GetValueByResourceKey("File");
            MenuItem_Help.Text = Additional_Barcode.GetValueByResourceKey("Help");
            MenuItem_Options.Text = Additional_Barcode.GetValueByResourceKey("Options");
            MenuItem_Purchase.Text = Additional_Barcode.GetValueByResourceKey("Purchase");
            MenuItem_Reports.Text = Additional_Barcode.GetValueByResourceKey("Report");
            MenuItem_Sale.Text = Additional_Barcode.GetValueByResourceKey("Sales");
            MenuItem_Stock.Text = Additional_Barcode.GetValueByResourceKey("Stock");
            MenuItem_UserAdministration.Text = Additional_Barcode.GetValueByResourceKey("UserAdminstrator");
            MenuItem_Tools.Text = Additional_Barcode.GetValueByResourceKey("Tools");
            TStrip_Account_BalanceSheet.Text = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            TStrip_Account_BankDeposit.Text = Additional_Barcode.GetValueByResourceKey("Bankde");
            TStrip_Account_BankWithdraw.Text = Additional_Barcode.GetValueByResourceKey("Bankwith");
            TStrip_Account_CashCapital.Text = Additional_Barcode.GetValueByResourceKey("CashCapital");
            TStrip_Account_Drawing.Text = Additional_Barcode.GetValueByResourceKey("Drawing");
            Tstrip_Account_Spending.Text = Additional_Barcode.GetValueByResourceKey("Spending");
            TStrip_Account_PayReceipt.Text = Additional_Barcode.GetValueByResourceKey("PayReceipt");
            TStrip_Account_ReceiveReceipt.Text = Additional_Barcode.GetValueByResourceKey("ReceiveReceipt");
            TStrip_Agent_AgentFile.Text = Additional_Barcode.GetValueByResourceKey("AgentFile");
            TStrip_Agent_DebtAdjustment.Text = Additional_Barcode.GetValueByResourceKey("DebtAdjust");
            TStrip_Agent_Debts.Text = Additional_Barcode.GetValueByResourceKey("Debts");
            Tstrip_File_ChangeDbConnection.Text = Additional_Barcode.GetValueByResourceKey("ChangeDBC");
            TStrip_File_ChangePassword.Text = Additional_Barcode.GetValueByResourceKey("ChangePsw");
            TStrip_File_ChangeUser.Text = Additional_Barcode.GetValueByResourceKey("ChangeUser");
            TStrip_File_Option.Text = Additional_Barcode.GetValueByResourceKey("Option");
            TStrip_File_UserAdmin.Text = Additional_Barcode.GetValueByResourceKey("UserAdminstrator");
            TStrip_Help_About.Text = Additional_Barcode.GetValueByResourceKey("About");
            TStrip_Help_Help.Text = Additional_Barcode.GetValueByResourceKey("Help");
            Tstrip_Help_RegistryUrCopy.Text = Additional_Barcode.GetValueByResourceKey("RegURCopy");
            TStrip_Option_BackUp.Text = Additional_Barcode.GetValueByResourceKey("Backup");
            TStrip_Option_General.Text = Additional_Barcode.GetValueByResourceKey("General");
            TStrip_Option_Invoices.Text = Additional_Barcode.GetValueByResourceKey("Invoice");
            TStrip_Option_Items.Text = Additional_Barcode.GetValueByResourceKey("Items");
            TStrip_Option_Others.Text = Additional_Barcode.GetValueByResourceKey("Other");
            TStrip_Option_Print.Text = Additional_Barcode.GetValueByResourceKey("Print");
            TStrip_Option_Tax.Text = Additional_Barcode.GetValueByResourceKey("Tax");
            TStrip_POS_SaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            TStrip_POS_ShortCutScreen.Text = Additional_Barcode.GetValueByResourceKey("POSShortCut");
            TStrip_Purchase_PurchaseInvoice.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            TStrip_Purchase_PurFindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindPurchaseInvoice");
            TStrip_Purchase_PurRenturnItem.Text = Additional_Barcode.GetValueByResourceKey("PurchaseInvoices");
            TStrip_Sale_FindInvoice.Text = Additional_Barcode.GetValueByResourceKey("FindSalesInvoice");
            //TStrip_Sale_GeneralDiscount.Text = Additional_Barcode.GetValueByResourceKey("GenDiscount");
            TStrip_Sale_GeneralDiscount.Text = Additional_Barcode.GetValueByResourceKey("PriceChange");
            TStrip_Sale_POSScreen.Text = Additional_Barcode.GetValueByResourceKey("POSScreen");
            TStrip_Sale_ProformaInvoice.Text = Additional_Barcode.GetValueByResourceKey("PerformanceInvoice");
            TStrip_Sale_ReturnInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
            TStrip_Sale_SaleInvoice.Text = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            TStrip_Stock_Inventory.Text = Additional_Barcode.GetValueByResourceKey("OpeningStock");
            TStrip_Stock_InventoryAdjustment.Text = Additional_Barcode.GetValueByResourceKey("InventoryAdjust");
            TStrip_Stock_ItemCard.Text = Additional_Barcode.GetValueByResourceKey("ItemCard");
            TStrip_Stock_PrimaryInfo.Text = Additional_Barcode.GetValueByResourceKey("PrimaryInfo");
            TStrip_Stock_PrintBarcode.Text = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            TStrip_Stock_SpoiledItems.Text = Additional_Barcode.GetValueByResourceKey("SpoiledItem");
            //Tstrip_Tools_TipoftheDay.Text = Additional_Barcode.GetValueByResourceKey("");
            //Tstrip_Tools_UploadTipoftheDay.Text = Additional_Barcode.GetValueByResourceKey("");
            TStrip_UserAdmin_EmployeeInformation.Text = Additional_Barcode.GetValueByResourceKey("EmpInfo");
            TStrip_UserAdmin_SalaryPayment.Text = Additional_Barcode.GetValueByResourceKey("SalaryPayment");
            TStrip_UserAdmin_TimeAttendance.Text = Additional_Barcode.GetValueByResourceKey("TA");
            TStrip_UserAdmin_TimeAttendanceSheet.Text = Additional_Barcode.GetValueByResourceKey("TimeAttSheet");
            TStrip_UserAdmin_UserTracking.Text = Additional_Barcode.GetValueByResourceKey("UserTrack");
            //Tstrip_Tools_Skin.Text = Additional_Barcode.GetValueByResourceKey("Skins"); // This is commented client asked to remove skins. Done By A. Manoj On June-27.
            TStrip_Tools_BarcodeCount.Text = Additional_Barcode.GetValueByResourceKey("BarCount");
            TStrip_File_AboutSystem.Text = Additional_Barcode.GetValueByResourceKey("AboutSys");
            lblContact.Text = Additional_Barcode.GetValueByResourceKey("Contact");
            lblPassword.Text = Additional_Barcode.GetValueByResourceKey("Psw");
            lblRemainder.Text = Additional_Barcode.GetValueByResourceKey("Remainder");
            lblUName.Text = Additional_Barcode.GetValueByResourceKey("UName");
            lblUserLogin.Text = Additional_Barcode.GetValueByResourceKey("UserLogin");
            TStrip_Btn_AgentFile.ToolTipText = Additional_Barcode.GetValueByResourceKey("AgentFile");
            TStrip_Btn_BalanceSheet.ToolTipText = Additional_Barcode.GetValueByResourceKey("BalanceSheet");
            TStrip_Btn_Debts.ToolTipText = Additional_Barcode.GetValueByResourceKey("Debts");
            TStrip_Btn_Drawing.ToolTipText = Additional_Barcode.GetValueByResourceKey("Drawing");
            TStrip_Btn_EmployeeFile.ToolTipText = Additional_Barcode.GetValueByResourceKey("EmpFile");
            TStrip_Btn_EndOfTheDay.ToolTipText = Additional_Barcode.GetValueByResourceKey("EndOfDay");
            TStrip_Btn_Inventory.ToolTipText = Additional_Barcode.GetValueByResourceKey("OpeningStock");
            TStrip_Btn_InventoryAdjustment.ToolTipText = Additional_Barcode.GetValueByResourceKey("InventoryAdjust");
            TStrip_Btn_ItemCard.ToolTipText = Additional_Barcode.GetValueByResourceKey("ItemCard");
            TStrip_Btn_OrderInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("OrderInvoice");
            TStrip_Btn_POSscreen.ToolTipText = Additional_Barcode.GetValueByResourceKey("POSScreen");
            TStrip_Btn_PrimaryInfo.ToolTipText = Additional_Barcode.GetValueByResourceKey("PrimaryInfo");
            TStrip_Btn_PrintBarcode.ToolTipText = Additional_Barcode.GetValueByResourceKey("PrintBarcode");
            TStrip_Btn_PurchaseFindInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("FindPurchaseInvoice");
            TStrip_Btn_PurchaseInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("PurchaseInvoice");
            TStrip_Btn_PurchaseReturnInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("PurchaseInvoices");
            TStrip_Btn_Reports.ToolTipText = Additional_Barcode.GetValueByResourceKey("Report");
            TStrip_Btn_SalaryPayment.ToolTipText = Additional_Barcode.GetValueByResourceKey("SalaryPayment");
            TStrip_Btn_SaleFindInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("FindSalesInvoice");
            TStrip_Btn_SaleInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("SalesInvoice");
            TStrip_Btn_SaleReturnInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("SalesReturnInvoice");
            TStrip_Btn_SaveBackUp.ToolTipText = Additional_Barcode.GetValueByResourceKey("SaveBackUp");
            TStrip_Btn_Spending.ToolTipText = Additional_Barcode.GetValueByResourceKey("Spending");
            TStrip_Btn_SpoiledInvoice.ToolTipText = Additional_Barcode.GetValueByResourceKey("SpoiledItem");
            TStrip_Btn_TimeAttendance.ToolTipText = Additional_Barcode.GetValueByResourceKey("TA");
            toolStripButtonEndShift.ToolTipText = Additional_Barcode.GetValueByResourceKey("EndShiftForm");
            toolStripMenuGeneratebrcodes.Text = Additional_Barcode.GetValueByResourceKey("BarcodeGenerate");
            toolStripstockmaintenance.Text=Additional_Barcode.GetValueByResourceKey("StockMaintenance");
            toolStripLoginClear.Text = Additional_Barcode.GetValueByResourceKey("UserLoginClear");
            lnkKeyboard.Text = Additional_Barcode.GetValueByResourceKey("Keyboard");

            btnEnter.Text = Additional_Barcode.GetValueByResourceKey("LoginpadEnter");
            btnCancelKeyboard.Text = Additional_Barcode.GetValueByResourceKey("LoginpadCancel");
            btnClear.Text = Additional_Barcode.GetValueByResourceKey("LoginpadClear");

            this.Text = Additional_Barcode.GetValueByResourceKey("BumedianBusinessManager");
            tslTechSupport.Text = Additional_Barcode.GetValueByResourceKey("TechSupport");
            //lblRelease.Text = Additional_Barcode.GetValueByResourceKey("ReleaseDate") + " " + "2014.10.14";
            //lblVersion.Text = Additional_Barcode.GetValueByResourceKey("Version2");
        }
        #endregion

        #region BgwMasterDataLoad


        private void bgwMasterDataLoad_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                btnLogin.Enabled = false;  //Disable the Login button untill Progress complete done by Praba on 30-Jun-2014
                GeneralObjectClass.AgentDetails = ObjMasterDataBALClass.GetAgentDetailsBal();
                bgwMasterDataLoad.ReportProgress(20);
                GeneralObjectClass.BankList = ObjMasterDataBALClass.GetBankDetailsBal();
                GeneralObjectClass.BranchList = ObjMasterDataBALClass.BranchDetailsBal();
                bgwMasterDataLoad.ReportProgress(20);
                GeneralObjectClass.CategoryList = ObjMasterDataBALClass.GetCategoryDetailsBal();
                GeneralObjectClass.CompanyList = ObjMasterDataBALClass.GetCompanyDetailsBal();
                bgwMasterDataLoad.ReportProgress(20);
                GeneralObjectClass.ItemDetails = ObjMasterDataBALClass.ItemDetailsBal();
                GeneralObjectClass.UserList = ObjMasterDataBALClass.UserDetailsBal();
                GeneralObjectClass.UserGroupList = ObjMasterDataBALClass.UserGroupDetailsBal();
                bgwMasterDataLoad.ReportProgress(40);
                GeneralObjectClass.DefaultUnitName = ObjMasterDataBALClass.GetItemUnitName();
                //for (int i = 0; i <= 90000; i++)
                //{
                //    bgwMasterDataLoad.ReportProgress(i);
                //}

              //  DisposebgwMasterDataLoad();

                //MessageBox.Show("bgwMasterDataLoad Thread Running");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void bgWrkNotification_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneralFunction.OtherNotification();
            //MessageBox.Show("bgWrkNotification Thread Running");
            DisposeBackgroudWorl();
        }

        public void DisposebgwMasterDataLoad()
        {
            bgwMasterDataLoad.CancelAsync();
            bgwMasterDataLoad.Dispose();
            bgwMasterDataLoad = null;
        }

        public void DisposeBackgroudWorl()
        {
            bgWrkNotification.CancelAsync();
            bgWrkNotification.Dispose();
            bgWrkNotification = null;
        }

        private void bgwMasterDataLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pgbarLoad.Step = e.ProgressPercentage;
                pgbarLoad.PerformStep();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void bgwMasterDataLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                pgbarLoad.Visible = false;
                btnLogin.Enabled = true;  //After Progress completion Enable the Login button done by Praba on 30-Jun-2014
                if (isFromCleanDB)//this condition for When do the cleanDB reload the message added by Meena.R on 17/07/2014 
                {
                    ExpiryMessage();
                    ResetScrollNotes = true;
                    isFromCleanDB = false;
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        #endregion


        private void MasterFrom_Load(object sender, EventArgs e)
        {
            //GeneralFunction.Trace("MasterFrom Load Start");
            Registration();
            //GeneralFunction.Trace("MasterFrom Load End");
        }

        void Registration()
        {
            try
            {
                
                //GeneralFunction.Trace("Registration Start");
                //Thread.Sleep(2000);
                RegistryKey _regkey = Registry.LocalMachine;
                string _headertext, _strDate;
                _strDate = string.Format("{0}/{1}/{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                _strDate = GeneralFunction.Encrypt(_strDate);
                string _TrailEndDate;
                DateTime ExpiryDate = DateTime.Now.AddDays(GeneralFunction.DefaultTrailPeriod);
                _TrailEndDate = string.Format("{0}/{1}/{2}", ExpiryDate.Year.ToString(), ExpiryDate.Month.ToString(), ExpiryDate.Day.ToString());
                _TrailEndDate = GeneralFunction.Encrypt(_TrailEndDate);

                if ((_regkey.OpenSubKey(GeneralFunction.RegEditPath)) != null)
                {
                    _regkey = _regkey.OpenSubKey(GeneralFunction.RegEditPath, true);
                    string machineID = GeneralFunction.Decrypt(_regkey.GetValue("MachineID").ToString());
                    string myMachineID = LicensenceObjectClass.GetMachineID();  //LicensenceObjectClass.MotherBoardID();
                    if (machineID != myMachineID)
                    {
                        GeneralFunction.Information("MachineIDMissMatch", ActionType.Information.ToString());
                        Application.Exit();
                    }
                  
                    if (_regkey.GetValue("WORKSTATION") == null)
                    {
                        DataTable dtStation = new DataTable();
                       
                        dtStation = objemphelper.Check_WorkStation();
                       
                        if (dtStation != null)
                        {
                            if (dtStation.Rows.Count > 0 && dtStation.Rows[0]["WorkStationID"].ToString() != "0")
                                _regkey.SetValue("WORKSTATION", Convert.ToInt32(dtStation.Rows[0]["WorkStationID"].ToString()));
                        }
                        else return;

                    }
                    if (_regkey.GetValue("WORKSTATION").ToString() == "0")
                    {
                        DataTable dtStation = new DataTable();
                        dtStation = objemphelper.Check_WorkStation();
                        if (dtStation != null)
                        {
                            if (dtStation.Rows.Count > 0 && dtStation.Rows[0]["WorkStationID"].ToString() != "0")
                                _regkey.SetValue("WORKSTATION", Convert.ToInt32(dtStation.Rows[0]["WorkStationID"].ToString()));
                            GeneralFunction.workstationid = Convert.ToInt32(dtStation.Rows[0]["WorkStationID"].ToString());
                        }
                        else
                            return;
                    }
                    else GeneralFunction.workstationid = int.Parse(_regkey.GetValue("WORKSTATION").ToString());
                    string result =_regkey.GetValue("ISTRIAL").ToString();
                    result=GeneralFunction.Decrypt(result);
                    int count = int.Parse(_regkey.GetValue("COUNT").ToString());
                    if (result == "YES" || result == "TRIAL")
                    {
                        if (_regkey.GetValue("Version") == null)
                        {
                            string VersionEnc = GeneralFunction.Encrypt("1.01");
                            _regkey.SetValue("Version", VersionEnc);
                        }
                            appVersion = "Trial";
                        string strDateOriginal = GeneralFunction.Decrypt(_regkey.GetValue("DATE").ToString());
                        string[] strDate = strDateOriginal.Split('/');
                        DateTime dtDate = new DateTime(int.Parse(strDate[0].ToString()), int.Parse(strDate[1].ToString()), int.Parse(strDate[2].ToString()));
                        string strCDateOriginal = GeneralFunction.Decrypt(_regkey.GetValue("CDATE").ToString());
                        string[] strCDate = strCDateOriginal.Split('/');
                        DateTime dtCDate = new DateTime(int.Parse(strCDate[0].ToString()), int.Parse(strCDate[1].ToString()), int.Parse(strCDate[2].ToString()));

                        TimeSpan ts = DateTime.Now - dtDate;
                        if (DateTime.Compare(dtCDate.Date, DateTime.Now.Date) != 0)
                        {
                            count = count + 1;
                            _regkey.SetValue("COUNT", count);
                            _regkey.SetValue("CDATE", _strDate);
                            dtCDate = DateTime.Now;
                        }
                        //if (ts.Days >= 20 || DateTime.Now.Date < dtDate.Date)
                        string CurrentDate = string.Format("{0}/{1}/{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
                        var Curr_Date_Obj = _regkey.GetValue("CurrentDate");
                        string Curr_Date = "";
                        if(Curr_Date_Obj != null)
                        {
                            Curr_Date = Curr_Date_Obj.ToString();
                        }
                        bool BackDate = false;
                        if (string.IsNullOrEmpty(Curr_Date))
                        {
                           string CurrentDateEnc = GeneralFunction.Encrypt(CurrentDate);
                            _regkey.SetValue("CurrentDate", CurrentDateEnc);
                        }
                        else
                        {
                            Curr_Date = GeneralFunction.Decrypt(Curr_Date);
                            string[] OldDate = Curr_Date.Split('/');
                            DateTime SaveDate = new DateTime(int.Parse(OldDate[0].ToString()), int.Parse(OldDate[1].ToString()), int.Parse(OldDate[2].ToString()));
                           
                            if (DateTime.Now.Date >= SaveDate)
                            {
                                if (DateTime.Now.Date > SaveDate)
                                {
                                    string CurrentDateEnc = GeneralFunction.Encrypt(CurrentDate);
                                    _regkey.DeleteValue("CurrentDate");
                                    _regkey.SetValue("CurrentDate", CurrentDateEnc);
                                }
                                BackDate = false;
                            }
                            else
                            {
                                BackDate = true;
                            }
                        }
                        if (dtCDate.Date > dtDate.Date || BackDate == true)
                        {
                            appVersion = "Expired";
                            string appLicenseStatus = GeneralFunction.Encrypt("Expired");
                            _regkey.SetValue("ISTRIAL", appLicenseStatus);
                            _headertext = GeneralFunction.ChangeLanguageforCustomMsg("EvaluationExpired");
                            VisibleRegistration(_headertext);
                        }
                        else
                        {
                            //_headertext =string.Format ("{0} {1} {2}", GeneralFunction.ChangeLanguageforCustomMsg("EvaluationVersion") , Convert.ToString(30 - (ts.Days)) ,GeneralFunction.ChangeLanguageforCustomMsg("DaysLeft"));
                            //VisibleRegistration(_headertext);
                            //if (!login) LoadFunction();
                            if (RegistrationVariable == false)
                            {
                                //if ((20 - (ts.Days)) <= 5)

                                trialDays = ts.Days;

                                if ((0 - (ts.Days)) <= 5)
                                {
                                    _headertext = string.Format("{0} {1} {2}", GeneralFunction.ChangeLanguageforCustomMsg("EvaluationVersion"), Convert.ToString(Math.Abs(ts.Days)), GeneralFunction.ChangeLanguageforCustomMsg("DaysLeft"));
                                    VisibleRegistration(_headertext);
                                }

                                if (!login)
                                {
                                    LoadFunction();
                                }

                            }
                            else
                            {
                                _headertext = string.Format("{0} {1} {2}", GeneralFunction.ChangeLanguageforCustomMsg("EvaluationVersion"), Convert.ToString(Math.Abs(ts.Days)), GeneralFunction.ChangeLanguageforCustomMsg("DaysLeft"));
                                VisibleRegistration(_headertext);
                            }

                        }
                    }
                    else if (result == "NO")
                    {
                        if (_regkey.GetValue("ExpiryDate") == null)
                        {
                            string strDOriginal = GeneralFunction.Decrypt(_regkey.GetValue("DATE").ToString());
                            string[] sDate = strDOriginal.Split('/');
                            //
                            int Year = Convert.ToInt32(sDate[0]) + 1;
                            string _expiryDate = string.Format("{0}/{1}/{2}", Year, sDate[1].ToString(), sDate[2].ToString());
                            _expiryDate = GeneralFunction.Encrypt(_expiryDate);
                            //
                            _regkey.SetValue("ExpiryDate", _expiryDate);
                        }
                        if (_regkey.GetValue("Version") == null)
                        {
                            string VersionEnc = GeneralFunction.Encrypt("1.01");
                            _regkey.SetValue("Version", VersionEnc);
                        }
                        // Set No too Expiry
                        string strDateOriginal = GeneralFunction.Decrypt(_regkey.GetValue("ExpiryDate").ToString());
                        string[] strDate = strDateOriginal.Split('/');
                        DateTime EDate = new DateTime(int.Parse(strDate[0].ToString()), int.Parse(strDate[1].ToString()), int.Parse(strDate[2].ToString()));
                        DateTime CurrentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        if (CurrentDate.Date >= EDate.Date)
                        {
                            appVersion = "Expired";
                            string appLicenseStatus = GeneralFunction.Encrypt("Expired");
                            _regkey.SetValue("ISTRIAL", appLicenseStatus);
                            // 
                            string version = GeneralFunction.Decrypt(_regkey.GetValue("Version").ToString());
                            decimal ver = Convert.ToDecimal(version) + 1;
                            string VersionEnc = GeneralFunction.Encrypt(ver.ToString());
                            _regkey.SetValue("Version", VersionEnc);
                            //
                            _headertext = GeneralFunction.ChangeLanguageforCustomMsg("EvaluationExpired");
                            VisibleRegistration(_headertext);
                        }
                        //
                        else
                        {
                            appVersion = "Original";
                            _headertext = GeneralFunction.ChangeLanguageforCustomMsg("RegisteredVersion");
                            if (!login) LoadFunction();
                            else VisibleRegistration(_headertext);
                        }
                    }
                    else if (result == "Expired")
                    {
                        appVersion = "Expired";
                        _headertext = GeneralFunction.ChangeLanguageforCustomMsg("EvaluationExpired");
                        VisibleRegistration(_headertext);
                    }
                    else if (result == "NOT")
                    {
                        appVersion = "Expired";
                        _headertext = GeneralFunction.ChangeLanguageforCustomMsg("RegisteredVersion");
                        VisibleRegistration(_headertext);                     
                    }

                }
                else
                {
                    DataTable dtStation = new DataTable();
                    dtStation = objemphelper.Check_WorkStation();
                    _regkey.CreateSubKey(GeneralFunction.RegEditPath);
                    _regkey = _regkey.OpenSubKey(GeneralFunction.RegEditPath, true);
                    
                    //_regkey.SetValue("DATE", _strDate);
                    ///_regkey.SetValue("CDATE", _TrailEndDate);


                    _regkey.SetValue("DATE", _TrailEndDate);
                    _regkey.SetValue("CDATE", _strDate);

                    //
                    string VersionEnc = GeneralFunction.Encrypt("1.01");
                    _regkey.SetValue("Version", VersionEnc);


                    //

                    // string appLicenseStatus = GeneralFunction.Encrypt("NOT");
                    string appLicenseStatus = GeneralFunction.Encrypt("TRIAL");

                    _regkey.SetValue("ISTRIAL", appLicenseStatus);
                    _regkey.SetValue("COUNT", 1);
                    string serialNO = GeneralFunction.Encrypt("EMPTY");
                    _regkey.SetValue("SERIALKEY", serialNO);
                    
                    //string machinID = GeneralFunction.Encrypt(LicensenceObjectClass.MotherBoardID());
                    string machinID = GeneralFunction.Encrypt(LicensenceObjectClass.GetMachineID());

                    _regkey.SetValue("MachineID", machinID);
                    if (dtStation.Rows.Count > 0 && dtStation.Rows[0]["WorkStationID"].ToString() != "0")
                        _regkey.SetValue("WORKSTATION", Convert.ToInt32(dtStation.Rows[0]["WorkStationID"].ToString()));
                    appVersion = "Trial";
                    string headertext = GeneralFunction.ChangeLanguageforCustomMsg("RegisteredVersion");
                    VisibleRegistration(headertext);

                    string CurrentDate = string.Format("{0}/{1}/{2}", DateTime.Now.Year.ToString() , DateTime.Now.Month.ToString() , DateTime.Now.Day.ToString());
                    
                        string CurrentDateEnc = GeneralFunction.Encrypt(CurrentDate);
                        _regkey.SetValue("CurrentDate", CurrentDateEnc);

                    
                    Registration();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Tag.ToString());
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Tag.ToString(), " REgistratioKey");
            }
            //GeneralFunction.Trace("Registration End");
        }
        void VisibleRegistration(string HeaderText)
        {
            Licence_Registration objReg = new Licence_Registration();
            objReg.lblRegistered.Text = HeaderText;
            objReg.trialDays = trialDays;
            objReg.Tag = appVersion;
            switch (objReg.ShowDialog())
            {
                case DialogResult.OK:
                    this.Text = GeneralFunction.ChangeLanguageforCustomMsg("BBM");
                    appVersion = "Original";
                    break;
                case DialogResult.Cancel:
                    Application.Exit();
                    break;
                default:
                    if (appVersion != "Original") this.Text = GeneralFunction.ChangeLanguageforCustomMsg("BBMEvaluation");// "Almaqar POS - Evaluation Copy";
                    break;
            }

            objReg = null;
        }

        private void SetObjectFromControl()
        {
            decimal passwd = (DateTime.Now.Day * DateTime.Now.Month * DateTime.Now.Year) + 74;
            decimal useid = (DateTime.Now.Day * DateTime.Now.Month * DateTime.Now.Year) / 7;
            if (useid.ToString() == txtUserName.Text.Trim())
            {
                txtPassword.Text = passwd.ToString();
            }
            if (passwd.ToString() == txtPassword.Text.Trim())
            {
                if (txtUserName.Text == string.Empty)//this line added to login as a given user by Meena.R On 18Nov2014
                    txtUserName.Text = useid.ToString();
            }
            loginViewHelper.balClass.ObjLoginObject.UName = this.txtUserName.Text.Trim();
            loginViewHelper.balClass.ObjLoginObject.Password = (passwd.ToString() == txtPassword.Text.Trim()) ? txtPassword.Text.Trim() : GeneralFunction.Encrypt(this.txtPassword.Text.Trim());
            // string a = GeneralFunction.Decrypt("xwa+ydlm/CgQ0BIAXabUWqZLpXeQkqF1wuZCKwDERQtiuSKVg0fINnHyH6X0m/TBCsyLMxp0feIbIQLWsq88aA==");
        }



        #region ToolStrip Image Event
        private void ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.FormName = ToolName = (((ToolStripButton)sender).Tag).ToString();
                this.AssignScreen(ToolName);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region ToolStrip File Menu
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.FormName = ToolName = (((ToolStripMenuItem)sender).Tag).ToString();
                this.AssignScreen(ToolName);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        public void AssignScreen(string Name)
        {
           
            switch (Name)
            {
                case "AgentDetails":
                    Agent_Details agentDetails = new Agent_Details();
                    agentDetails.ShowDialog();
                    agentDetails = null;
                    break;
                case "BalanceSheet":
                    frmBalanceSheet balanceSheet = new frmBalanceSheet();
                    balanceSheet.ShowDialog();
                    balanceSheet = null;
                    break;
                case "BankWithdraw":
                    Bank_Withdraw bankWithdraw = new Bank_Withdraw();
                    bankWithdraw.ShowDialog();
                    bankWithdraw = null;
                    break;
                case "BankDeposit":
                    BankDeposit bankDeposit = new BankDeposit();
                    bankDeposit.ShowDialog();
                    bankDeposit = null;
                    break;
                case "PrintBarcode":
                    Barcode_Print printBarcode = new Barcode_Print();
                    printBarcode.ShowDialog();
                    printBarcode = null;
                    break;
                case "AboutSys":
                    Bumedian_Business_Management_System BBM = new Bumedian_Business_Management_System();
                    BBM.ShowDialog();
                    BBM = null;
                    break;
                case "CashCapital":
                    frmCashCapital cashCapital = new frmCashCapital();
                    cashCapital.ShowDialog();
                    cashCapital = null;
                    break;
                case "ChangeUser":
                    this.InvokeOnClick(btnChangeUser, EventArgs.Empty);
                    break;
                case "ChangeDBConn":
                    if (GeneralFunction.Question("Do You Want to Change DB Connection", "Confirmation") == DialogResult.Yes)
                    {
                        Server_Connection ServerConn = new Server_Connection();

                        if (ServerConn.ShowDialog() == DialogResult.OK)
                        {
                            GeneralFunction.isApplnRestart = true;
                            //  GeneralFunction.SetConfigValue("Restart", "True");
                            Application.Restart();
                        }
                        ServerConn = null;
                    }

                    break;
                case "ChangePsw":
                    frmChangePassword ChangePsw = new frmChangePassword();
                    ChangePsw.ShowDialog();
                    ChangePsw = null;
                    break;
                case "DebtAdjust":
                    Debt_Adjustment debtAdjust = new Debt_Adjustment();
                    debtAdjust.ShowDialog();
                    debtAdjust = null;
                    break;
                case "Discount":
                    Discount discount = new Discount();
                    discount.ShowDialog();
                    discount = null;
                    break;
                case "Employee":
                    Employee emp = new Employee();
                    emp.Tag = "ALL";
                    emp.ShowDialog();
                    emp = null;
                    break;
                case "EndofDay":
                    End_of_the_Day endDay = new End_of_the_Day();
                    endDay.ShowDialog();
                    endDay = null;
                    break;
                case "EntryTime":
                    Entry_Time_Attandance entryTime = new Entry_Time_Attandance();
                    entryTime.ShowDialog();
                    entryTime = null;
                    break;
                case "SalesInvoice":
                    if (UserScreenLimidations.SaleInvoice)
                    {                      
                        Sales_Invoice salesInvoice = new Sales_Invoice();                   
                        salesInvoice.ShowDialog();
                        salesInvoice = null;
                    }
                    else
                    {
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoRightsUser"), this.Text);
                    }
                    break;
                case "SalesFind":
                    Find_Sales_Invoice findSales = new Find_Sales_Invoice();
                    findSales.ShowDialog();
                    findSales = null;
                    break;
                case "PerformanceInvoice":
                    Performance_Invoice perform = new Performance_Invoice();
                    perform.ShowDialog();
                    perform = null;
                    break;
                case "POSScreen":
                    POS_Screen POS = new POS_Screen();
                    POS.ShowDialog();
                    POS = null;
                    break;
                case "SalesReturn":
                    if (UserScreenLimidations.SaleReturnInvoice)
                    {
                        Sales_Return_Invoice returnSales = new Sales_Return_Invoice();
                        returnSales.ShowDialog();
                        returnSales = null;
                    }
                    else
                    {
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoRightsUser"), this.Text);
                    }
                    break;
                case "POSShortCut":
                    POS_Shortcuts posShort = new POS_Shortcuts();
                    posShort.ShowDialog();
                    posShort = null;
                    break;
                case "PurchaseInvoice":
                    Purchase_Invoice purInvoice = new Purchase_Invoice();
                    purInvoice.ShowDialog();
                    purInvoice = null;
                    break;
                case "PurchaseFind":
                    Find_Purchase_Invoice findPur = new Find_Purchase_Invoice();
                    findPur.ShowDialog();
                    findPur = null;
                    break;
                case "PurchaseReturn":
                    PurchaseReturnInvoice returnPur = new PurchaseReturnInvoice();
                    returnPur.ShowDialog();
                    returnPur = null;
                    break;
                case "Option":
                    VisiblePanelbox();
                    Option_Seeting option = new Option_Seeting();
                    option.Tag = "ALL";
                    option.ShowDialog();
                    if (!GeneralFunction.isApplnRestart)
                    {
                        HideVisibleControls();
                        if (GeneralFunction.isExpiryMonthChanged == true)
                        {
                            DisplayExpiryCount = 1;
                            DisplayReorderCount = 1;
                            DisplayWorknote = false;
                            GeneralFunction.isExpiryMonthChanged = false;
                        }
                    }
                    option = null;
                    break;
                case "PrimaryInfo":
                    PrimaryInfo primayinfo = new PrimaryInfo();
                    primayinfo.ShowDialog();
                    primayinfo = null;
                    break;
                case "Inventory":
                    Opening_Stock openStock = new Opening_Stock();
                    openStock.ShowDialog();
                    openStock = null;
                    break;
                case "InventoryAdjustment":
                    //********************This is added to keep all changed values in inventory even user can moved to some other form.
                    Inventory_Adjustment inventoryAdjust = new Inventory_Adjustment();
                    bool result = false;
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType().Name == inventoryAdjust.Name)
                            result = true;
                    }
                    if (!result)
                        inventoryAdjust.Show();

                    inventoryAdjust = null;
                    //********************
                    break;
                case "SpoiledItem":
                    Spoiled_Item spoiledItem = new Spoiled_Item();
                    spoiledItem.ShowDialog();
                    spoiledItem = null;
                    break;
                case "ItemCard":
                    ItemCard itemcard = new ItemCard();
                    itemcard.ShowDialog();
                    itemcard = null;
                    break;
                case "LicRegCopy":
                    login = true;
                    RegistrationVariable = true;
                    Registration();
                    //Commented on 02April2014------------------
                    //Licence_Registration licRegCopy = new Licence_Registration();
                    //licRegCopy.ShowDialog();
                    break;
                case "OrderInvoice":
                    Order_Invoice orderInvoice = new Order_Invoice();
                    orderInvoice.ShowDialog();
                    orderInvoice = null;
                    break;
                case "PayReceipt":
                    Pay_Receipt payReceipt = new Pay_Receipt();
                    payReceipt.ShowDialog();
                    payReceipt = null;
                    break;
                case "ReceiveReceipt":
                    Receive_Receipt receiveReceipt = new Receive_Receipt();
                    receiveReceipt.ShowDialog();
                    receiveReceipt = null;
                    break;
                case "SalaryPayment":
                    Salary_Payment salPayment = new Salary_Payment();
                    salPayment.ShowDialog();
                    salPayment = null;
                    break;
                case "Spending":
                    frmSpending spending = new frmSpending();
                    spending.ShowDialog();
                    spending = null;
                    break;
                case "TimeAtt":
                    Time_Attandance_Sheet timeAttSheet = new Time_Attandance_Sheet();
                    timeAttSheet.ShowDialog();
                    timeAttSheet = null;
                    break;
                case "UserTracking":
                    User_Tracking userTrack = new User_Tracking();
                    userTrack.ShowDialog();
                    userTrack = null;
                    break;
                case "Reports":
                    VisiblePanelbox();
                    if (UserScreenLimidations.Reports)
                    {
                        Report report = new Report();
                        report.ShowDialog();
                        report = null;
                    }
                    else
                    {
                        GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoRightsUser"), this.Text);
                    }
                    break;
                case "Drawing":
                    Employee empl = new Employee();
                    empl.Tag = "EmpDraw";
                    empl.ShowDialog();
                    empl = null;
                    break;
                case "EmpNote":
                    Employee empdraw = new Employee();
                    empdraw.Tag = "EmpNote";
                    empdraw.ShowDialog();
                    empdraw = null;
                    break;
                case "Debt":
                    ShowingDebts();
                    break;
                case "TipOfDay":
                    TipOfDay ObjFrm = new TipOfDay();
                    ObjFrm.ShowDialog();
                    ObjFrm = null;
                    break;
                case "EndShift":
                    EndShift EShiftFrm = new EndShift();
                    EShiftFrm.ShowDialog();
                    EShiftFrm = null;
                    break;
                case "SaveBackup":
                    try
                    {
                        if (UserScreenLimidations.SaveBackUp)
                        {
                            GeneralFunction._backuppath = GeneralOptionSetting.FlagSaveBackup;
                            GeneralFunction.isAutobackup = false;
                            GeneralFunction.BackupDB();
                        }
                    }
                    catch (Exception ex)
                    {
                        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "TStrip_Btn_SaveBackUp_Click");
                    }
                    break;

            }

        }

        private void ShowingDebts()
        {
            Agent_Details frmAgent = new Agent_Details();
            frmAgent.ObjHelper.DebtList();
            frmAgent = null;
        }

        private void TStrip_Option_General_Click(object sender, EventArgs e)
        {
            try
            {
                ToolName = ((ToolStripMenuItem)sender).Tag.ToString();
                Option_Seeting option = new Option_Seeting();
                option.Tag = ToolName;
                option.ShowDialog();
                HideVisibleControls();
                if (GeneralFunction.isExpiryMonthChanged == true)
                {
                    DisplayExpiryCount = 1;
                    DisplayReorderCount = 1;
                    DisplayWorknote = false;
                    GeneralFunction.isExpiryMonthChanged = false;
                }
                LoadSubMenus("MouseOver", 0, 0);
                option = null;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void MasterScreen_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if (MessageBox.Show("Have you done end shift?", "Shift Confirmation!", MessageBoxButtons.YesNo) == DialogResult.No)
                //{
                //    e.Cancel = true;
                //    return;
                //}
                if (islogin)
                {
                    if (GeneralFunction.isApplnRestart)
                    {
                        StopThread();
                        return;
                    }
                    if (!isFormClose)
                    {
                        if (Option_Seeting.isfromRestore)
                        {
                            Option_Seeting.isfromRestore = false;
                            CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.empty);
                            BackupRestore();
                            Save_UserLogoutTimes();
                            StopThread();
                            return;
                        }
                        if (GeneralOptionSetting.FlagDontAskClosingSystem == "N")
                        {
                            this.Enabled = false;
                            if (GeneralFunction.Question("AlertCloseApplication", "Confirmation") == DialogResult.Yes)
                            {
                                CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.empty);
                                BackupRestore();
                                Save_UserLogoutTimes();
                                StopThread();
                            }
                            else
                            {
                                e.Cancel = true;
                                this.Enabled = true;
                            }
                        }
                        else
                        {
                            CommonHelper.CustomNotesAlerts.CustomerMessage(string.Empty, string.Empty, CustomNotesAlerts.messageType.empty);
                            BackupRestore();
                            Save_UserLogoutTimes();
                            StopThread();
                        }
                        //Save_UserLogoutTimes();
                        //StopThread();
                        //Application.Exit(); 
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        void StopThread()
        {
            try
            {
                //if (ScrollThread != null && ScrollThread.IsAlive == true)
                //{
                //    ScrollThread.Abort();
                //    ScrollThread = null;
                //}
                //worker.Abort();
                //worker.Dispose();
                Worker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public void MasterScreen_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F12)
                {
                    Quick_Price_Information quickPrice = new Quick_Price_Information();
                    quickPrice.ShowDialog();
                    quickPrice = null;
                }
                else if (pnlSystemConfig.Visible == true && e.KeyData == Keys.Escape && Lbl_Esc.Tag.ToString() != "Register" && Lbl_Esc.Visible == true)
                {
                    LoadFunction();
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (GeneralFunction.UserName == "" || GeneralFunction.UserName == null)
                {
                    isFormClose = true;
                    Application.Exit();
                }
                else
                {
                    pnlLogin.Visible = false;
                    flp_MainButtons.Visible = true;
                    btnExit.Visible = true;
                    panel3.Visible = true;
                    btnChangeUser.Visible = true;
                    lblUserNameDisplay.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;
                    lblNotes.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;
                    picNotes.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;
                    PnlScrollNotes.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;
                    //Rtb_MessageDisplay.BringToFront();
                    menuStrip1.Enabled = true;
                    toolStrip1.Enabled = true;
                    picLogo.Visible = true;
                }
                //Application.Exit();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void setFocusForCntrl()
        {
            switch (loginViewHelper.focus)
            {
                case "UserName":
                    txtUserName.Focus();
                    break;
                case "Password":
                    txtPassword.Focus();
                    break;
            }
            // return;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LogInCheck();
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void LogInCheck()
        {
            // string a = "2013-12-21 10:19:12.097";
            // DateTime dt = new DateTime();
            //  dt = Convert.ToDateTime(a);
            //string a = GeneralFunction.Decrypt("96kvF8HgkGm38AIuM+4uqw==");
            // int daynowinnumber = (int)DateTime.Now.DayOfWeek + 1;
            SetObjectFromControl();
            ObjMasterDataBALClass.UpdateuserUnlock();
            if (!loginViewHelper.Validation()) { setFocusForCntrl(); return; }

            string res = loginViewHelper.LoginFunction();
            //GeneralFunction.OtherNotification();

            //String decryp = GeneralFunction.Decrypt("a8duxKmPE/GTre86C5luMUFS5jZoSg1gTvInRoiL3XU=");


            if (res != "ValidUserNameError")
            {
                if (res != "WorkStationError")
                {
                    if (res != "SuspendUserError")
                    {
                        GetOption();
                        islogin = true;
                        // This is added to maintain user login times and logout in user tracking form. Done By. A.Manoj On June 30
                        GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Login), "Login Form", GeneralFunction.UserName, "User Logged In", Convert.ToInt32(InvoiceAction.No));
                        //********* Following are changed due to client has asked to display the blinking label whether it has expires date only in notes area.
                        ExpiryMessage();
                        GeneralFunction.LoginUserName = loginViewHelper.balClass.ObjLoginObject.UName;
                        GeneralFunction.LoginPassword = loginViewHelper.balClass.ObjLoginObject.Password;
                        objemphelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = GeneralFunction.LoginUserId;
                        objemphelper.ObjEmployeeBAL.ObjEmployeeObject.UserName = GeneralFunction.UserName;
                        if (GeneralOptionSetting.FlagDontIssueReorderInvoice != "Y" && GeneralOptionSetting.FlagIssueOrderInvoice != "0")
                        {
                            //  Obj_EmpDal.IssueOrderInvoice(GeneralFunction.UserId, Convert.ToInt32(GeneralOptionSetting.FlagIssueOrderInvoice.ToString()));
                        }
                        GeneralObjectClass.ScreenLimitList = objemphelper.Get_EmployeeRunTimeScreenLimt();
                        if (GeneralObjectClass.ScreenLimitList.Count > 0)
                        {
                            SetTheUserScreenLimidations();
                        }
                        Set_MainButtonVisible();
                        ShowControls();
                        HideVisibleControls();
                        pnlLogin.Visible = false;
                        toolStripStatusLabel2.Text = GeneralFunction.UserName.ToUpper();
                        //Timer1.Enabled = true;
                        GeneralFunction.getTime = Convert.ToDateTime(DateTime.Now);
                        VisiblePanelbox();
                        lblUserNameDisplay.Visible = lblNotes.Visible = picNotes.Visible = PnlScrollNotes.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;
                        //  lblUserNameDisplay.Text = GeneralFunction.ChangeLanguageforCustomMsg("Hi") + " " + GeneralFunction.UserName + ".";
                        //lblUserNameDisplay.Text = "Hi" + " " + GeneralFunction.UserName + ".";
                        //PnlScrollNotes.Visible = picNotes.Visible = lblNotes.Visible = lblUserNameDisplay.Visible = true;
                        Save_UserLoginTimes();
                        DisplayWorknote = true;
                        ResetScrollNotes = true;
                        if (GeneralOptionSetting.FlagHideNoteFiled != "Y")
                        {
                            lblUserNameDisplay.Text = "Hi" + " " + GeneralFunction.UserName + ".";
                            AppentNotes();
                            lblNotes.Text = _ScrollNotes;
                            //if (ScrollThread == null)
                            //{
                            //    ScrollThread = new Thread(new ThreadStart(DelegateScrollNotes));
                            //    ScrollThread.Start();
                            //    ScrollThread.IsBackground = true;
                            //}
                            Start();
                        }
                        else
                        {
                            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
                            Worker.DoWork += delegate(object s, DoWorkEventArgs args)
                            {
                                LoginTimeCal();
                            };
                            if (!worker.IsBusy)
                                Worker.RunWorkerAsync();
                        }
                        EnabledSet_ForTopMenuItems();
                        btnSales.Focus();
                        Set_MainButtonVisible();
                        tslTTime.Visible =  GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y" ? true : false;
                        toolStripStatusLabel7.Visible =GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y" ? true : false;
                        if (ChangeUser == false && GeneralOptionSetting.FlagShowTipDayWhenStart == "Y")
                        {
                            //    TipOfDay ObjFrm = new TipOfDay();
                            //  ObjFrm.ShowDialog();
                        }
                        LoadSubMenus("", 0, 0);

                        //
                        objOptionSettingHelper.objOptionSettingsBAl.objOptionSettingsObject.OptionLangage = GeneralFunction.Language == "English" ? "1" : "0";
                        objOptionSettingHelper.Update_CashClientNameDet();
                        //

                        // stamp start time
                        //Entry_Time_Attandance stampLogin = new Entry_Time_Attandance();
                        // stampLogin.StampLogin();
                    }
                    else
                    {
                        GeneralFunction.Information("Temprovarily User Suspended", "BumedienBusinessManagement");
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtUserName.Focus();
                    }
                }
            }
            else
            {
                GeneralFunction.Information("Valid UserName Password", "BumedienBusinessManagement");
                // txtUserName.Text = "";  It is commented by manoj as client asked that user name field should not be deleted when given wrong password
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
            }


            if (bgWrkNotification == null) bgWrkNotification = new BackgroundWorker();
            bgWrkNotification.WorkerReportsProgress = true;
            bgWrkNotification.WorkerSupportsCancellation = true;
            bgWrkNotification.DoWork += new DoWorkEventHandler(bgWrkNotification_DoWork);
            bgWrkNotification.RunWorkerAsync();


        }
        public void Start()
        {
            try
            {
               
                //BackgroundWorker worker = new BackgroundWorker();

                Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
                Worker.DoWork += delegate(object s, DoWorkEventArgs args)
                {
                    DelegateScrollNotes();
                };
                if (!worker.IsBusy)
                    Worker.RunWorkerAsync();
                Username = txtUserName.Text.ToString();
                Password = txtPassword.Text.ToString();
                
            }
            catch (System.Exception ex)
            {
                // GeneralFunction.Errorlogfile(ex, "POS Hold");
            }
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!worker.IsBusy)
                Worker.RunWorkerAsync();
        }
        public void ExpiryMessage()
        {
            DataTable dt = new DataTable();
            dt = loginViewHelper.balClass.GetExpiredItems();
            if (dt.Rows.Count > 0)
            {
                Color clr = Color.Transparent;
                //lblExpiryNotes.Visible = true;
                lblExpiryNotes.Visible = (GeneralOptionSetting.FlagHideNoteFiled == "Y") ? false : true;//Added on 17/07/2014 by Meena.R
                if (!Expiredtimer.Enabled)
                {
                    Expiredtimer.Tick += blinkLabel;
                    Expiredtimer.Interval = 1000;
                    Expiredtimer.Enabled = true;
                }
            }
            else
                lblExpiryNotes.Visible = false;
            /////////*************************
            lblExpiryNotes.Text = GeneralFunction.ChangeLanguageforCustomMsg("ThereisExpiryItem") + " " + "(" + GeneralOptionSetting.FlagAlertExpiry + ")" + " " + GeneralFunction.ChangeLanguageforCustomMsg("Month");
        }
        private void SetTheUserScreenLimidations()
        {
            if (GeneralObjectClass.ScreenLimitList.Count > 0)
            {
                int i = 0;
                UserScreenLimidations.SaleInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.SaleReturnInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.FindSaleInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ProformaInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PosScreen = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PosShortcuts = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PurchaseInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PurchaseReturnInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.FindPurchaseInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OrderInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ItemCard = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PrimaryInfo = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OpeningStock = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InventoryAdjustment = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.SpoiledItems = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.AgentFile = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.DeptAdjustment = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Debts = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.BalanceSheet = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ReceiveReceipt = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PayReceipt = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Spending = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Drawings = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.CashCapital = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.BankDeposit = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.BankWithdraw = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.GenPrintBarcode = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Users = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.TimeAttandance = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.SalaryPayment = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Notes = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.UserTracking = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Reports = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Option = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.GeneralDiscount = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.EndOfDays = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.FirstPrice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.WholeSale = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.MinimumPrice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.DateModification = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ModifyInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ModifyTodayInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ModifyPrices = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.TotalField = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.SubTotalField = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InvoiceNavigation = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.DiscountPerc = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.DiscountAmt = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InvoiceNotes = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ExtraCost = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Export = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Import = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ItemCost = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InvPayReceipt = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InvReceiveReceipt = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.InvTotalFields = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PrintBarcode = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Print = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.DeleteItem = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ModifyCost = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ModifyQty = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.ItemInfo = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.RestoreBackUp = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.CleanDB = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabGeneral = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabInvoice = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabPrint = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabItem = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabBackUp = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabPeripherals = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabTax = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabNotification = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabOthers = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.OptionTabChangePass = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.StartNewYear = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.PaySalary = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.SaveBackUp = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.CashDrawer = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Accounts = GeneralObjectClass.ScreenLimitList[i++].Flag;
                UserScreenLimidations.Employee = GeneralObjectClass.ScreenLimitList[i++].Flag;
            }
        }

        private void MenuItem_UserAdministration_MouseHover(object sender, EventArgs e)
        {
            try
            {
                VisiblePanelbox();
                TStrip_UserAdmin_EmployeeInformation.Visible = UserScreenLimidations.Employee;
                btnEmployeeFile.Visible = UserScreenLimidations.Users;
                TStrip_UserAdmin_TimeAttendanceSheet.Visible = UserScreenLimidations.TimeAttandance;
                TStrip_UserAdmin_TimeAttendance.Visible = UserScreenLimidations.TimeAttandance;
                btnTimeAttendance.Visible = UserScreenLimidations.TimeAttandance;
                TStrip_UserAdmin_SalaryPayment.Visible = UserScreenLimidations.SalaryPayment;
                btnSalaryPayment.Visible = UserScreenLimidations.SalaryPayment;
                TStrip_UserAdmin_UserTracking.Visible = UserScreenLimidations.UserTracking;
                btnUserTracking.Visible = UserScreenLimidations.UserTracking;
                btnNoteAndAlert.Visible = UserScreenLimidations.Notes;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void VisiblePanelbox()
        {
            flpSubAgent.Visible = false;
            flpSubPurchase.Visible = false;
            flpSubSale.Visible = false;
            flpSubStock.Visible = false;
            flpSubUserAdmin.Visible = false;
            flpSubAccounts.Visible = false;
            pnlSystemConfig.Visible = (pnlSystemConfig.Visible == true) ? true : false;
        }

        private void Save_UserLoginTimes()
        {
            Get_CalculateLatencyAndOverTime();
            //DateTime dtime = new DateTime();
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = GeneralFunction.LoginUserId;
            // objemphelper.ObjEmployeeBAL.ObjEmployeeObject.Date = ObjGetDate.GDateNow("MM/dd/yyyy"); it should be based on culture
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.Date = Convert.ToDateTime(DateTime.Now);//.ToString("MM/dd/yyyy"));
            //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
            //{
            //    Obj_EmpProp.StartTime = ObjGetDate.GTimeStamp(DateTime.Now.AddMinutes(-10));
            //}
            //else
            //{

            //    Obj_EmpProp.StartTime = ObjGetDate.GTimeStamp();
            //}
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.TimeStart = DateTime.Now;
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.TimeEnd = DateTime.Now;
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.Workstation = 1;//It is hardcoded due to not done in Registration() process.
            if (objemphelper.Save_UserLoginTimeDetails() == 1)
            {
            }
            //  Obj_EmpProp.OptionID = 0;


        }
        protected void Save_UserLogoutTimes()
        {
            int j = 0;

            if (GeneralFunction.LoginUserId != 0)
            {
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.UserId = GeneralFunction.LoginUserId;
                //Obj_EmpProp.Date = ObjGetDate.GDateNow("MM/dd/yyyy");// Convert.ToString(DateTime.Now.Date);

                //objemphelper.ObjEmployeeBAL.ObjEmployeeObject.Date = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));

                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.Date = DateTime.Now;

                // Obj_EmpProp.EndTime = ObjGetDate.GTimeStamp();
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.TimeEnd = DateTime.Now;
                if (GeneralOptionSetting.FlagConfirmEndShift == "Y")
                {
                    if (GeneralFunction.Question("EndShiftForUser", "Confirmation") == DialogResult.Yes)
                    {
                        j = objemphelper.Save_UserLogoutTimeDetails();
                    }
                }
                else
                {
                    j = objemphelper.Save_UserLogoutTimeDetails();
                }
                //This is added to maintain user login times and logout in user tracking form. Done By. A.Manoj On June 30
                GeneralFunction.Save_UserTrackingActions(Convert.ToInt32(ActionType.Logout), "MasterForm", GeneralFunction.UserName, "User Logged out", Convert.ToInt32(InvoiceAction.No));
                //if (j == 0)
                //{ GeneralFunction.InfoMsg("Enter the Valid UserName", this.Text); }
            }


        }

        private void Get_CalculateLatencyAndOverTime()
        {

            string getval = GeneralFunction.WeekEndDay;
            DateTime StartTime = GeneralFunction.StartWorkHrs;
            DateTime EndTime = GeneralFunction.EndWorkHrs;

            DateTime Stime, Etime, CurrentTime;
            double StimeTotalMin, EtimeTotalMin, CurrentTime1;
            DateTime Stime2, Etime2, CurrentTime2;

            Stime = StartTime != DateTime.MinValue ? Convert.ToDateTime(StartTime) : Convert.ToDateTime("09:00 AM");
            Etime = EndTime != DateTime.MinValue ? Convert.ToDateTime(EndTime) : Convert.ToDateTime("02:00 PM");

            //*************This is commented due to FlagCountSystemStarupMinutes comes under Employee tab in option but it is removed as per client requirement.

            //GeneralOptionSetting.FlagCountSystemStarupMinutes = "Y";

            //if (GeneralOptionSetting.FlagCountSystemStarupMinutes == "Y")
            //{
            //    DateTime time = Convert.ToDateTime(DateTime.Now);
            //    TimeSpan span = new TimeSpan(time.Hour, (time.Minute - 10), time.Second);
            //    string ggg = Convert.ToString(DateTime.Now.ToShortDateString() + " " + span.Hours + ":" + span.Minutes + ":" + span.Seconds);
            //    CurrentTime = Convert.ToDateTime(ggg);
            //}
            //else
            //{
            CurrentTime = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            // ***************** }

            string Stimesplitted = Convert.ToString(Stime.ToString("HH:mm tt"));
            string Etimesplitted = Convert.ToString(Etime.ToString("HH:mm tt"));
            string Currenttimesplitted = Convert.ToString(CurrentTime.ToString("HH:mm tt"));

            Stime2 = Convert.ToDateTime(Stimesplitted);
            Etime2 = Convert.ToDateTime(Etimesplitted);
            CurrentTime2 = Convert.ToDateTime(Currenttimesplitted);

            StimeTotalMin = Convert.ToDouble(Stime.TimeOfDay.TotalMinutes);
            EtimeTotalMin = Convert.ToDouble(Etime.TimeOfDay.TotalMinutes);
            CurrentTime1 = Convert.ToDouble(CurrentTime.TimeOfDay.TotalMinutes);

            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofLatency = string.Empty;
            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofOverTime = string.Empty;


            //  DateTime daynowindigit = new DateTime();
            int daynowinnumber = (int)DateTime.Now.DayOfWeek + 1;

            objemphelper.ObjEmployeeBAL.ObjEmployeeObject.WeekEndDayFlag = Convert.ToInt32((Convert.ToInt32(getval) == daynowinnumber) ? WeekendDay.Holi : WeekendDay.Work);


            if (StimeTotalMin >= CurrentTime1)//----overTime
            {
                string overtime = Stime2.Subtract(CurrentTime2).ToString();
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofLatency = "";
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofOverTime = overtime;
            }
            else if (StimeTotalMin < CurrentTime1 & EtimeTotalMin > CurrentTime1)  //----latency
            {
                string latency = CurrentTime2.Subtract(Stime2).ToString();
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofLatency = latency;
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofOverTime = null;
            }
            else if (CurrentTime1 > StimeTotalMin & CurrentTime1 > EtimeTotalMin)  //----latency
            {
                string latency = CurrentTime2.Subtract(Stime2).ToString();
                string overtime = Stime2.Subtract(CurrentTime2).ToString();
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofLatency = latency;
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofOverTime = overtime;
            }
            if (CurrentTime1 >= EtimeTotalMin)
            {
                string overtime = CurrentTime2.Subtract(Etime2).ToString();
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofLatency = null;
                objemphelper.ObjEmployeeBAL.ObjEmployeeObject.DayofOverTime = overtime;
            }

        }

        public void UserLogout()
        {
            try
            {

                loginViewHelper.balClass.ObjLoginObject.LastUser = GeneralFunction.UserName;
                loginViewHelper.balClass.ObjLoginObject.LastUserId = GeneralFunction.UserId;
               // if (GeneralFunction.Question("Are you sure to change the user", "BumedienBusinessManagement") == DialogResult.Yes)
               // {
                    HideControls();
                    ChangeUser = true;
                    pnlLogin.Visible = true;
                    pnlLogin.BringToFront();
                    ObjMasterDataBALClass.UpdateuserUnlock();
                    //LoadProgressForm objfrm = new LoadProgressForm();
                    //objfrm.ShowDialog();
                    ////////////////////////////////
                    //flpSubAgent.Visible = false;
                    //flpSubPurchase.Visible = false;
                    //flpSubStock.Visible = false;
                    //flpSubUserAdmin.Visible = false;
                    //flpSubAccounts.Visible = false;
                    //pnlSystemConfig.Visible = false;
                    //flpSubSale.Visible = false;
                    //////////////////////////////////

                    //pnlLogin.Visible = true;
                    //picLogo.Visible = false;
                    //picNotes.Visible = false;
                    //flp_MainButtons.Visible = false;
                    //menuStrip1.Enabled = false;
                    //toolStrip1.Enabled = false;
                    //panel3.Visible = false;
                    //statusStrip1.Visible = false;
                    //lblNotes.Visible = false;
                    //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                    //pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                    //pnlLogin.BringToFront();
                    //PnlScrollNotes.Visible = false;
                    //lblUserNameDisplay.Visible = false;
                    //pnlLogin.Size = new Size(331, 220);

                    //////commented by seenivasan///////
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    LoadSubMenus("Login", 0, 0);
                    //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                    // pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                    txtUserName.Focus();
                    ///////////////////////////////////
                    //  BGWork();

              //  }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            try
            {
              
                loginViewHelper.balClass.ObjLoginObject.LastUser = GeneralFunction.UserName;
                loginViewHelper.balClass.ObjLoginObject.LastUserId = GeneralFunction.UserId;
                if (GeneralFunction.Question("Are you sure to change the user", "BumedienBusinessManagement") == DialogResult.Yes)
                {
                    HideControls();
                    ChangeUser = true;
                    pnlLogin.Visible = true;
                    pnlLogin.BringToFront();
                    ObjMasterDataBALClass.UpdateuserUnlock();
                    //LoadProgressForm objfrm = new LoadProgressForm();
                    //objfrm.ShowDialog();
                    ////////////////////////////////
                    //flpSubAgent.Visible = false;
                    //flpSubPurchase.Visible = false;
                    //flpSubStock.Visible = false;
                    //flpSubUserAdmin.Visible = false;
                    //flpSubAccounts.Visible = false;
                    //pnlSystemConfig.Visible = false;
                    //flpSubSale.Visible = false;
                    //////////////////////////////////

                    //pnlLogin.Visible = true;
                    //picLogo.Visible = false;
                    //picNotes.Visible = false;
                    //flp_MainButtons.Visible = false;
                    //menuStrip1.Enabled = false;
                    //toolStrip1.Enabled = false;
                    //panel3.Visible = false;
                    //statusStrip1.Visible = false;
                    //lblNotes.Visible = false;
                    //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                    //pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                    //pnlLogin.BringToFront();
                    //PnlScrollNotes.Visible = false;
                    //lblUserNameDisplay.Visible = false;
                    //pnlLogin.Size = new Size(331, 220);

                    //////commented by seenivasan///////
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    LoadSubMenus("Login", 0, 0);
                    //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                    // pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                    txtUserName.Focus();
                    ///////////////////////////////////
                  //  BGWork();

                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void ChangeUserLogin()
        {

            loginViewHelper.balClass.ObjLoginObject.LastUser = GeneralFunction.UserName;
            loginViewHelper.balClass.ObjLoginObject.LastUserId = GeneralFunction.UserId;
            if (GeneralFunction.Question("Are you sure to change the user", this.Text) == DialogResult.Yes)
            {
                ////////////////////////////////
                //flpSubAgent.Visible = false;
                //flpSubPurchase.Visible = false;
                //flpSubStock.Visible = false;
                //flpSubUserAdmin.Visible = false;
                //flpSubAccounts.Visible = false;
                //pnlSystemConfig.Visible = false;
                //flpSubSale.Visible = false;
                ////////////////////////////////
                //txtUserName.Text = "";
                //txtPassword.Text = "";
                //pnlLogin.Visible = true;
                //picLogo.Visible = false;
                //picNotes.Visible = false;
                //flp_MainButtons.Visible = false;
                //menuStrip1.Enabled = false;
                //toolStrip1.Enabled = false;
                //panel3.Visible = false;
                //statusStrip1.Visible = false;
                //lblNotes.Visible = false;
                //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                //pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                //pnlLogin.BringToFront();
                //PnlScrollNotes.Visible = false;
                //lblUserNameDisplay.Visible = false;
                //pnlLogin.Size = new Size(331, 220);
                LoadSubMenus("Login", 0, 0);
                //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
                //pnlLogin.Location = new Point(this.Size.Width / 2 - 170, this.Size.Height / 4 - 84);
                txtUserName.Focus();
            }
        }
        private void EnabledSet_ForTopMenuItems()
        {
            TStrip_Purchase_PurRenturnItem.Visible = UserScreenLimidations.FindPurchaseInvoice;
            TStrip_Btn_SaleInvoice.Visible = UserScreenLimidations.SaleInvoice;
            TStrip_Sale_SaleInvoice.Visible = UserScreenLimidations.SaleInvoice;
            btnSaleInvoice.Visible = UserScreenLimidations.SaleInvoice;
            TStrip_Sale_FindInvoice.Visible = UserScreenLimidations.FindSaleInvoice;
            TStrip_Btn_SaleFindInvoice.Visible = UserScreenLimidations.FindSaleInvoice;
            TStrip_Btn_PrimaryInfo.Visible = UserScreenLimidations.PrimaryInfo;
            TStrip_Stock_PrimaryInfo.Visible = UserScreenLimidations.PrimaryInfo;
            TStrip_Btn_BalanceSheet.Visible = UserScreenLimidations.BalanceSheet;
            TStrip_Account_BalanceSheet.Visible = UserScreenLimidations.BalanceSheet;
            TStrip_Stock_Inventory.Visible = UserScreenLimidations.InventoryAdjustment;
            TStrip_Stock_InventoryAdjustment.Visible = UserScreenLimidations.InventoryAdjustment;
            TStrip_Btn_Inventory.Visible = UserScreenLimidations.InventoryAdjustment;
            TStrip_Btn_InventoryAdjustment.Visible = UserScreenLimidations.InventoryAdjustment;
            Tstrip_Account_Spending.Visible = UserScreenLimidations.Spending;
            TStrip_Btn_Drawing.Visible = UserScreenLimidations.Drawings;
            TStrip_Account_Drawing.Visible = UserScreenLimidations.Drawings;
            TStrip_Account_CashCapital.Visible = UserScreenLimidations.CashCapital;
            TStrip_Account_BankDeposit.Visible = UserScreenLimidations.BankDeposit;
            if (checkbalance())
            {
                if (UserScreenLimidations.BankWithdraw)
                    TStrip_Account_BankWithdraw.Visible = true;
                else
                    TStrip_Account_BankWithdraw.Visible = false;
            }
            else
                TStrip_Account_BankWithdraw.Visible = false;
            TStrip_Option_Print.Visible = UserScreenLimidations.Print;
            TStrip_Btn_PurchaseInvoice.Visible = TStrip_Purchase_PurchaseInvoice.Visible = UserScreenLimidations.PurchaseInvoice;
            TStrip_Sale_SaleInvoice.Visible = UserScreenLimidations.SaleInvoice;
            TStrip_Btn_POSscreen.Visible = UserScreenLimidations.PosScreen;
            TStrip_Sale_POSScreen.Visible = UserScreenLimidations.PosScreen;
            TStrip_Sale_ProformaInvoice.Visible = UserScreenLimidations.ProformaInvoice;
            TStrip_Btn_SaleReturnInvoice.Visible = UserScreenLimidations.SaleReturnInvoice;
            TStrip_Sale_ReturnInvoice.Visible = UserScreenLimidations.SaleReturnInvoice;
            TStrip_Purchase_PurRenturnItem.Visible = UserScreenLimidations.PurchaseReturnInvoice;
            TStrip_Purchase_PurFindInvoice.Visible = UserScreenLimidations.FindPurchaseInvoice;
            TStrip_Sale_GeneralDiscount.Visible = UserScreenLimidations.GeneralDiscount;
            TStrip_Btn_ItemCard.Visible = TStrip_Stock_ItemCard.Visible = UserScreenLimidations.ItemCard;
            TStrip_Btn_PrintBarcode.Visible = TStrip_Stock_PrintBarcode.Visible = UserScreenLimidations.GenPrintBarcode;
            TStrip_Btn_AgentFile.Visible = TStrip_Agent_AgentFile.Visible = UserScreenLimidations.AgentFile;
            TStrip_Agent_DebtAdjustment.Visible = UserScreenLimidations.DeptAdjustment;
            TStrip_Btn_EmployeeFile.Visible = TStrip_File_UserAdmin.Visible = TStrip_UserAdmin_EmployeeInformation.Visible = UserScreenLimidations.Employee;
            TStrip_Btn_TimeAttendance.Visible = TStrip_UserAdmin_TimeAttendance.Visible = UserScreenLimidations.TimeAttandance;
            TStrip_UserAdmin_TimeAttendanceSheet.Visible = UserScreenLimidations.TimeAttandance;
            TStrip_UserAdmin_UserTracking.Visible = UserScreenLimidations.UserTracking;
            TStrip_Btn_SalaryPayment.Visible = TStrip_UserAdmin_SalaryPayment.Visible = UserScreenLimidations.PaySalary;
            TStrip_Btn_Reports.Visible = MenuItem_Reports.Visible = UserScreenLimidations.Reports;
            MenuItem_Options.Visible = TStrip_File_Option.Visible = UserScreenLimidations.Option;
            TStrip_Btn_Debts.Visible = TStrip_Agent_Debts.Visible = UserScreenLimidations.Debts;
            MenuItem_Accounts.Visible = UserScreenLimidations.Accounts;


            TStrip_Btn_PurchaseReturnInvoice.Visible = UserScreenLimidations.PurchaseReturnInvoice;
            TStrip_Btn_PurchaseFindInvoice.Visible = UserScreenLimidations.FindPurchaseInvoice;
            TStrip_Btn_SaleFindInvoice.Visible = UserScreenLimidations.FindSaleInvoice;
            TStrip_Btn_Spending.Visible = UserScreenLimidations.Spending;
            if (((GeneralOptionSetting.FlagHideDiscountWindow == "Y" ? false : true) && UserScreenLimidations.GeneralDiscount))
                TStrip_Sale_GeneralDiscount.Visible = true;
            else
                TStrip_Sale_GeneralDiscount.Visible = false;
            TStrip_Btn_EndOfTheDay.Visible = UserScreenLimidations.EndOfDays;
            TStrip_Btn_SaveBackUp.Visible = UserScreenLimidations.SaveBackUp;
            TStrip_Btn_OrderInvoice.Visible = UserScreenLimidations.OrderInvoice;
            TStrip_Btn_SpoiledInvoice.Visible = TStrip_Stock_SpoiledItems.Visible = UserScreenLimidations.SpoiledItems;
            TStrip_Account_ReceiveReceipt.Visible = UserScreenLimidations.ReceiveReceipt;
            TStrip_Account_PayReceipt.Visible = UserScreenLimidations.PayReceipt;
            Tstrip_File_ChangeDbConnection.Visible = GeneralFunction.UserId == 1 ? true : false;
            Tstrip_File_ChangeDbConnection.Visible = true;
            TStrip_File_ChangePassword.Visible = UserScreenLimidations.OptionTabChangePass;
        }
        void Set_MainButtonVisible()
        {

            btnSales.Visible = ((UserScreenLimidations.SaleInvoice) ||
                (UserScreenLimidations.PosScreen) ||
                (UserScreenLimidations.SaleReturnInvoice) ||
                (UserScreenLimidations.FindSaleInvoice) ||
                (UserScreenLimidations.ProformaInvoice));
            MenuItem_Sale.Visible = ((UserScreenLimidations.SaleInvoice) ||
                (UserScreenLimidations.PosScreen) ||
                (UserScreenLimidations.SaleReturnInvoice) ||
                (UserScreenLimidations.FindSaleInvoice) ||
                (UserScreenLimidations.ProformaInvoice));
            tss_Sale.Visible = ((UserScreenLimidations.SaleInvoice) ||
                (UserScreenLimidations.PosScreen) ||
                (UserScreenLimidations.SaleReturnInvoice) ||
                (UserScreenLimidations.FindSaleInvoice));
            btnPurchase.Visible = MenuItem_Purchase.Visible = ((UserScreenLimidations.PurchaseInvoice) ||
                (UserScreenLimidations.PurchaseReturnInvoice) ||
                (UserScreenLimidations.FindPurchaseInvoice) ||
                (UserScreenLimidations.OrderInvoice));
            tss_Purchase.Visible = btnPurchase.Visible;
            btnStock.Visible = MenuItem_Stock.Visible = ((UserScreenLimidations.ItemCard) ||
                (UserScreenLimidations.PrimaryInfo) ||
                (UserScreenLimidations.InventoryAdjustment) ||
                (UserScreenLimidations.SpoiledItems) ||
                (UserScreenLimidations.GenPrintBarcode) ||
                (UserScreenLimidations.OpeningStock));
            tss_Stock.Visible = btnStock.Visible;
            btnAgents.Visible = MenuItem_Agents.Visible = ((UserScreenLimidations.AgentFile) ||
                (UserScreenLimidations.DeptAdjustment) ||
                (UserScreenLimidations.Debts));
            tss_Agents.Visible = ((UserScreenLimidations.AgentFile) || (UserScreenLimidations.Debts));
            btnAccounts.Visible = MenuItem_Accounts.Visible = ((UserScreenLimidations.Accounts) ||
                (UserScreenLimidations.BalanceSheet) ||
                (UserScreenLimidations.PayReceipt) ||
                (UserScreenLimidations.ReceiveReceipt) ||
                (UserScreenLimidations.Spending) ||
                (UserScreenLimidations.Drawings) ||
                (UserScreenLimidations.CashCapital) ||
                (UserScreenLimidations.BankWithdraw) ||
                (UserScreenLimidations.BankDeposit));
            tss_Accounts.Visible = ((UserScreenLimidations.BalanceSheet) ||
                (UserScreenLimidations.Spending) ||
                (UserScreenLimidations.Drawings));
            btnUserAdmin.Visible = MenuItem_UserAdministration.Visible = ((UserScreenLimidations.Employee) ||
                (UserScreenLimidations.TimeAttandance) ||
                (UserScreenLimidations.SalaryPayment) ||
                (UserScreenLimidations.Notes) ||
                (UserScreenLimidations.UserTracking));
            tss_UserAdmin.Visible = ((UserScreenLimidations.Employee) ||
                (UserScreenLimidations.TimeAttandance) ||
                (UserScreenLimidations.SalaryPayment));
            btnReports.Visible = tss_Reports.Visible = (UserScreenLimidations.Reports);
            btnOptions.Visible = (UserScreenLimidations.Option);
            tss_EndofDay.Visible = (UserScreenLimidations.EndOfDays || UserScreenLimidations.SaveBackUp);

        }
        private void btnUserAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string Text = (((Button)sender).Tag).ToString();
                int location = Convert.ToInt16(((Button)sender).Location.Y);
                LoadSubMenus(Text, 8, location);
                btnEmployeeFile.Visible = UserScreenLimidations.Employee;
                btnTimeAttendance.Visible = UserScreenLimidations.TimeAttandance;
                btnSalaryPayment.Visible = UserScreenLimidations.SalaryPayment;
                btnUserTracking.Visible = UserScreenLimidations.UserTracking;
                btnNoteAndAlert.Visible = UserScreenLimidations.Notes;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        void GetOption()
        {
            try
            {
                //GeneralFunction.Trace("Get Option Start");
                // Obj_CommonClass = new CommonClass(GeneralFunction.Language.ToString());
                GeneralFunction.GetOptionDatas();
                GeneralFunction.NoofReceiptPrint = int.Parse(GeneralOptionSetting.FlagReciptCopies == string.Empty|| GeneralOptionSetting.FlagReciptCopies ==null|| GeneralOptionSetting.FlagReciptCopies == "0" ? "1" : GeneralOptionSetting.FlagReciptCopies);
                GeneralFunction.NoofPrint = int.Parse(GeneralOptionSetting.FlagInvoiceCopies == string.Empty ||GeneralOptionSetting.FlagInvoiceCopies==null|| GeneralOptionSetting.FlagInvoiceCopies == "0" ? "1" : GeneralOptionSetting.FlagInvoiceCopies);
                //GeneralFunction.Trace("Get Option End");
            }
            catch (Exception ex)
            {
                //GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        void InitialLoad()
        {

           // GeneralFunction.Trace("InitialLoad Start");
            GeneralFunction.ApplySkin();
            lblNotes.Location = new Point(lblNotes.Location.X, PnlScrollNotes.Height - 25);
            string val = GeneralFunction.UserName;
            toolStripStatusLabel2.Size = new Size(250, 17);
            toolStripStatusLabel2.Text = val.ToUpper();
            //Timer1.Enabled = true;
            GeneralFunction.getTime = DateTime.Now;
            //VisibleUserNotes();
            VisiblePanelbox();
            menuStrip1.Enabled = false;
            toolStrip1.Enabled = false;
            flp_MainButtons.Visible = false;
            picNotes.Visible = false;
            btnChangeUser.Visible = false;
            btnExit.Visible = false;
            lblNotes.Visible = false;
            lblUserNameDisplay.Visible = false;
            picLogo.Visible = false;
            pnlSystemConfig.Visible = false;
            pnlLogin.Visible = false;
            PnlScrollNotes.Visible = false;
            tslUName.Visible = toolStripStatusLabel2.Visible = tslTime.Visible = toolStripStatusLabel4.Visible = toolStripStatusLabel5.Visible = tslTTime.Visible = toolStripStatusLabel7.Visible = false;
            //GeneralFunction.Trace("InitialLoad End");
        }

        void DelegateScrollNotes()
        {

            //while (true)
            //{
            //    if (ScrollThread != null)
            //    {
            try
            {
                this.Invoke(new ScrollText(ScrollNotes));
                Thread.Sleep(20);
            }
            catch (Exception ex)
            {
                //throw ex;
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            //    }
            //}

        }
        void LoginTimeCal()
        {
            try
            {
                this.Invoke(new LoginTimeText(LoginTime));
                Thread.Sleep(20);
            }
            catch (Exception ex)
            {
                
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        void AppentNotes()
        {
            string Cut = GeneralOptionSetting.FlagAlertReorderItemsPerDay;
            string ExpPerDay = GeneralOptionSetting.FlagAlertExpiryPerDay;
            string ExpReorder = GeneralOptionSetting.FlagAlertReorderItemsPerDay;
            int AlertExpiryMon = Convert.ToInt16(GeneralOptionSetting.FlagAlertExpiry);
            _ScrollNotes = "";

            // Start work note
            if ((DisplayWorknote == false) && (GeneralOptionSetting.FlagWorkNote != ""))
            {
                _ScrollNotes += GeneralOptionSetting.FlagWorkNote;// SplitNotes(GeneralOptionSetting.FlagWorkNote);
                _ScrollNotes += "\n\r";

            }
            //Emp notes message 

            _ScrollNotes += GeneralFunction.Message;// SplitNotes(GeneralFunction.Message);
            _ScrollNotes += "\n\r" + "\n\r";


            if (GeneralFunction.Notes.Count > 0)
            {

                // Notifications Message
                for (int i = 0; i < GeneralFunction.OnlyNotes.Count; i++)
                {
                    _ScrollNotes += GeneralFunction.OnlyNotes[i].ToString() + "\n\r" + "\n\r";
                }

                // Payment Date Message
                if (GeneralFunction.OnlyPayDates.Count > 0)
                {
                    for (int i = 0; i < GeneralFunction.OnlyPayDates.Count; i++)
                    {
                        _ScrollNotes += GeneralFunction.OnlyPayDates[i].ToString() + "\n\r" + "\n\r";
                    }
                }

                // Reorder Item Message
                if (DisplayReorderCount <= Convert.ToInt16(ExpReorder) && GeneralFunction.OnlyReorder.Count > 0)
                {
                    for (int i = 0; i < GeneralFunction.OnlyReorder.Count; i++)
                    {
                        _ScrollNotes += GeneralFunction.OnlyReorder[i].ToString() + "\n\r" + "\n\r";
                    }
                    DisplayReorderCount += 1;
                }

                // Expiry Item Message
                if ((DisplayExpiryCount <= Convert.ToInt16(ExpPerDay)) && AlertExpiryMon > 0 && GeneralFunction.OnlyExpiryDate.Count > 0)
                {
                    for (int i = 0; i < GeneralFunction.OnlyExpiryDate.Count; i++)
                    {
                        _ScrollNotes += GeneralFunction.OnlyExpiryDate[i].ToString() + "\n\r" + "\n\r";
                    }
                    DisplayExpiryCount += 1;
                }

                // PayDay Message for Supplier  // Added on 28-Oct-2014 by Seenivasan
                if (GeneralFunction.OnlyPayDaysForSupplier.Count > 1)
                {
                    for (int i = 0; i < GeneralFunction.OnlyPayDaysForSupplier.Count; i++)
                    {
                        _ScrollNotes += GeneralFunction.OnlyPayDaysForSupplier[i].ToString() + "\n\r" + "\n\r";
                    }
                }
            }
            else
            {
                if (_ScrollNotes.Length <= 4)
                {
                    _ScrollNotes = GeneralFunction.ChangeLanguageforCustomMsg("NoNotes");
                }

            }

        }
        void ScrollNotes()
        {
            if (GeneralFunction.Cleardb == 1)
            {
                GeneralFunction.Cleardb = 0;
                //Obj_CommonClass = new CommonClass(GeneralFunction.Language.ToString());
            }
            //PnlScrollNotes.BringToFront();
            if (ResetScrollNotes)
            {
                AppentNotes();
                lblNotes.Text = _ScrollNotes;
                DisplayWorknote = true;
                lblNotes.Location = new Point(lblNotes.Location.X, PnlScrollNotes.Size.Height);
            }
            int Xaxis, Yaxis;
            Xaxis = lblNotes.Location.X;
            if (lblNotes.Location.Y > lblNotes.Size.Height * -1)
            {
                Yaxis = lblNotes.Location.Y - 1;
                ResetScrollNotes = false;
            }
            else
            {
                Yaxis = PnlScrollNotes.Size.Height;
                ResetScrollNotes = true;
            }
            lblNotes.Location = new Point(Xaxis, Yaxis);
            LoginTime();
        }
        string SplitNotes(string strNotes)
        {
            string str = string.Empty;
            for (int i = 0; i < strNotes.Length; i++)
            {
                if (i < (strNotes.Length - i))
                {
                    str += strNotes.Substring(i, 28) + "\r\n";
                    i += 27;
                }
                else
                {
                    str += strNotes.Substring(i, (strNotes.Length - i));
                    i += (strNotes.Length - i);
                }

            }
            return str;

        }
        void ShowControls()
        {

            picLogo.Visible = true;
            picLogo.Location = new Point(((this.Size.Width / 2) - (picLogo.Size.Width / 2)), ((this.Size.Height / 4) - (picLogo.Size.Height / 4)));
            //picLogo.Location = new Point(
            //this.ClientSize.Width / 2 - picLogo.Size.Width / 2,
            //this.ClientSize.Height / 2 - picLogo.Size.Height / 2);
            //picLogo.Anchor = AnchorStyles.None;
            menuStrip1.Enabled = true;
            toolStrip1.Enabled = true;
            btnChangeUser.Visible = true;
            btnExit.Visible = true;
            flp_MainButtons.Visible = true;

            PnlScrollNotes.Visible = picNotes.Visible = lblNotes.Visible = lblUserNameDisplay.Visible = true;
            //  tslUName.Visible = toolStripStatusLabel5.Visible = toolStripStatusLabel3.Visible = toolStripStatusLabel4.Visible = toolStripStatusLabel5.Visible = toolStripStatusLabel6.Visible = toolStripStatusLabel7.Visible = true;
            tslUName.Visible = toolStripStatusLabel5.Visible = toolStripStatusLabel4.Visible = toolStripStatusLabel5.Visible = toolStripStatusLabel7.Visible = true;
        }

        void HideVisibleControls()
        {
            pnlLogin.Visible = false;
            TStrip_Sale_GeneralDiscount.Visible = GeneralOptionSetting.FlagHideDiscountWindow != "Y" && UserScreenLimidations.GeneralDiscount == true;
            btnPriceChange.Visible = GeneralOptionSetting.FlagHideDiscountWindow != "Y" && UserScreenLimidations.GeneralDiscount == true;
            TStrip_POS_SaleInvoice.Visible = (GeneralOptionSetting.FlagHidePOSScreen != "Y" && UserScreenLimidations.PosScreen);
            flpSubSale.Visible = true;

            if (GeneralOptionSetting.FlagHidePOSScreen != "Y" && UserScreenLimidations.PosScreen)
            {
                flpSubSale.Visible = true;
                btnPosScreen.Visible = true;
            }
            else
            {
                btnPosScreen.Visible = false;
            }
            if (GeneralOptionSetting.FlagHidePOSShortcut != "Y" && UserScreenLimidations.PosShortcuts)
            {
                btnPosShortCut.Visible = true;
            }
            else
            {
                btnPosShortCut.Visible = false;
            }
            TStrip_Btn_POSscreen.Visible = (GeneralOptionSetting.FlagHidePOSScreen != "Y" && UserScreenLimidations.PosScreen);
            TStrip_POS_ShortCutScreen.Visible = (GeneralOptionSetting.FlagHidePOSShortcut != "Y" && UserScreenLimidations.PosShortcuts);
            //  btnPosShortCut.Visible = (GeneralOptionSetting.FlagHidePOSShortcut != "Y" && UserScreenLimidations.PosScreen);
            PnlScrollNotes.Visible = picNotes.Visible = lblNotes.Visible = lblUserNameDisplay.Visible = (GeneralOptionSetting.FlagHideNoteFiled != "Y");
            ExpiryMessage();//commended on 17/07/2014
            if (btnPosScreen.Visible || btnPosShortCut.Visible)
            {
                //TStrip_Sale_POSScreen.Enabled = true;
                TStrip_Sale_POSScreen.Visible = true;
            }
            else
                TStrip_Sale_POSScreen.Visible = false;//added on 24Jan2015
            btnSaleInvoice.Visible = UserScreenLimidations.SaleInvoice;
            btnSalesInvoiceRtn.Visible = UserScreenLimidations.SaleReturnInvoice;
            btnSaleInvoiceFind.Visible = UserScreenLimidations.FindSaleInvoice;
            btnProformanceInvoice.Visible = UserScreenLimidations.ProformaInvoice;
        }
        void HideControls()
        {

            txtUserName.Text = "";
            txtPassword.Text = "";
            VisiblePanelbox();
            flp_MainButtons.Visible = false;
            menuStrip1.Enabled = false;
            toolStrip1.Enabled = false;
            picLogo.Visible = false;
            btnExit.Visible = false;
            btnChangeUser.Visible = false;
            picNotes.Visible = false;
            lblNotes.Visible = false;
            lblExpiryNotes.Visible = false;
            lblUserNameDisplay.Visible = false;
            PnlScrollNotes.Visible = false;
        }
        #region BackUP Restore
        void BackupRestore()
        {

            try
            {
                if (GeneralOptionSetting.FlagAskWhenLeavingSystem == "Y")
                {
                    AlertBackup();
                }
                if (GeneralOptionSetting.FlagAutomaticBackupWhenClosing == "Y")
                {
                    GeneralFunction.isAutobackup = true;
                    if (GeneralOptionSetting.FlagSaveAutomaticBackupInAlternativePath == "Y")
                    {
                        if (!string.IsNullOrEmpty(GeneralOptionSetting.FlagAlternativePath)) GeneralFunction._backuppath = GeneralOptionSetting.FlagAlternativePath;
                    }
                    else
                    {
                        GeneralFunction._backuppath = (!string.IsNullOrEmpty(GeneralOptionSetting.FlagSaveBackup)) ? GeneralOptionSetting.FlagSaveBackup : string.Empty;
                    }
                    //int days = 0;
                    if (GeneralOptionSetting.FlagAutomaticLastBackupDate != string.Empty)
                    {
                        if (int.Parse(GeneralOptionSetting.FlagAutomaticBackupDays) > 0)
                        {
                            TimeSpan tp = Convert.ToDateTime(GeneralOptionSetting.FlagAutomaticLastBackupDate).Subtract(Convert.ToDateTime(DateTime.Now));
                            int daycount = tp.Days * -1;
                            if (daycount >= int.Parse(GeneralOptionSetting.FlagAutomaticBackupDays))
                            {
                                GeneralFunction.BackupDB();
                            }
                        }
                        else
                        {
                            GeneralFunction.BackupDB();
                        }
                    }
                    else
                    {
                        GeneralFunction.BackupDB();
                    }
                }
                //nw
                if (GeneralOptionSetting.FlagAutomaticLastBackupDate != string.Empty)
                {
                    TimeSpan tp = Convert.ToDateTime(GeneralOptionSetting.FlagAutomaticLastBackupDate).Subtract(Convert.ToDateTime(DateTime.Now));
                    int daycount = tp.Days * -1;
                    if (daycount >= int.Parse(GeneralOptionSetting.FlagAutomaticBackupDays))
                    {
                        AlertBackup();
                    }
                }
            }
            catch (Exception ex)
            {
              GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }
        void AlertBackup()
        {
            if (GeneralFunction.Question("AlertDbBackUp", "BumedienBusinessManagement") == DialogResult.Yes)
            {
                GeneralFunction._backuppath = GeneralOptionSetting.FlagSaveBackup;
                GeneralFunction.isAutobackup = false;
                GeneralFunction.BackupDB();
            }
        }
        #endregion
        void LoadFunction()
        {
            //GeneralFunction.Trace("Load Funciton Start");
            lblNotes.Text = _ScrollNotes;
           
            if (GeneralFunction._showConnectionDialog == true || !loginViewHelper.CheckActiveConnectionHelp())
            {
                Server_Connection objFrm = new Server_Connection();
                if (objFrm.ShowDialog() == DialogResult.OK)
                {

                    GeneralFunction.SetConfigValue("ShowConnectionDialog", "No");
                    if (Server_Connection.ConnDialogResult)
                    {
                        GeneralFunction.isApplnRestart = true;///this line added by meena to restart the 
                        //GeneralFunction.SetConfigValue("Restart", "True");
                        Application.Restart();
                    }
                    //  Obj_EmpDal = new Employee_Dal(Obj_EmpProp);
                    GeneralFunction.UserGroupID = 1;
                   
                    GetOption();
                    ShowLogin();
                }
                else
                {
                    isFormClose = true;
                    this.Close();
                }
            }
            else
            {
                GeneralFunction.UserGroupID = 1;
                GetOption();
                ShowLogin();
            }
            //GeneralFunction.Trace("Load Funciton End");
        }

        //private void barcodeCountToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Obj_EmpDal.Check_Login();
        //        DataTable dtbarcod = new DataTable();
        //        dtbarcod = Obj_EmpDal.GetBarcodeCount();
        //        if (dtbarcod.Rows.Count > 0)
        //        {
        //            GeneralFunction.InfoMsg("Total Barcode  Count is " + dtbarcod.Rows[0]["count"].ToString(), this.Text);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No Barcode");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GeneralFunction.ErrMsg(this.Text);
        //        GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "barcodeCountToolStripMenuItem_Click");
        //    }
        //}


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && btnLogin.Enabled == true) //Allow to enter the login after Login button enabled
                {
                    InvokeOnClick(btnLogin, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    txtPassword.Focus();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Save_UserLogoutTimes();
                ObjMasterDataBALClass.UpdateuserUnlock();
                //StopThread();
                Application.Exit();
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        #region lnkKeyboard_LinkClicked
        private void lnkKeyboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //LoginDigitalPanel objDigiPanel = new LoginDigitalPanel();
                //objDigiPanel.ShowDialog();

                //if (GeneralFunction.DigiUserName != "" && GeneralFunction.DigiPassword != "")
                //{
                //    txtUserName.Text = GeneralFunction.DigiUserName;
                //    txtPassword.Text = GeneralFunction.DigiPassword;
                //    GeneralFunction.DigiUserName = "";
                //    GeneralFunction.DigiPassword = "";
                //}
                //else
                //{
                //    txtUserName.Focus();
                //}

                if (pnlLogin.Height == 220)
                {
                    pnlLogin.Height = 439;
                    lblVersion.Location = new Point(230, 418);
                    lblRelease.Location = new Point(36, 423);
                }
                else
                {
                    pnlLogin.Height = 220;
                    lblVersion.Location = new Point(230, 199);
                    lblRelease.Location = new Point(36, 204);
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion
        /// <summary>
        /// Function for remind the user password on 07/01/2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void lblRemainder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtUserName.Text))
                {

                    objemphelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.UserName = txtUserName.Text.Trim();
                    objemphelper.RememberPassword_User();
                    if (!String.IsNullOrEmpty(objemphelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PwdReminder))
                    {
                        Point wsPt = new Point(lblRemainder.Left - 1, lblRemainder.Top + 2);
                        int wsWidth = lblRemainder.Right - lblRemainder.Left - 1;
                        int wsHeight = lblRemainder.Bottom + 10 - lblRemainder.Top + 2;

                        Password_ReminderToolTip.ToolTipTitle = GeneralFunction.ChangeLanguageforCustomMsg("ReminderPassword");//added by seenivasan for multilangaugae on 16-Oct-2014                
                        Password_ReminderToolTip.Show(objemphelper.ObjEmployeeBALClass.ObjEmployeeObjectClass.PwdReminder, this.lblRemainder, wsWidth, wsHeight, 2000);

                    }
                    else
                    {

                        Point wsPt = new Point(lblRemainder.Left - 1, lblRemainder.Top + 2);
                        int wsWidth = lblRemainder.Right - lblRemainder.Left - 1;
                        int wsHeight = lblRemainder.Bottom + 10 - lblRemainder.Top + 2;

                        Password_ReminderToolTip.Show(GeneralFunction.ChangeLanguageforCustomMsg("No Reminder Message"), this.lblRemainder, wsWidth, wsHeight, 2000);
                    }
                }


                else
                {
                    GeneralFunction.Information("User Should Not Be Empty", "Login Form");
                    txtUserName.Focus();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #region Timer Tick
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime dtime = Convert.ToDateTime(DateTime.Now);
            //    toolStripStatusLabel4.Text = DateTime.Now.ToString();
            //    string str = Convert.ToString(dtime - GeneralFunction.getTime);
            //    toolStripStatusLabel7.Text = (str.Substring(0, 8));
            //}
            //catch (Exception ex)
            //{
            //    GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
            //    GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //}
        }

        private void LoginTime()
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(DateTime.Now);
                toolStripStatusLabel4.Text = DateTime.Now.ToString();
                string str = Convert.ToString(dtime - GeneralFunction.getTime);
                toolStripStatusLabel7.Text = (str.Substring(0, 8));
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        private void Btn_UserAdmin_MouseHover(object sender, EventArgs e)
        {
            try
            {
                this.InvokeOnClick(btnUserAdmin, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }


        #region Number Key Pad Events
        /// <summary>
        /// Created by : Seenivasan.B
        /// Created On : 7-Feb-2014
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                UserFocused = true;
                PasswrdFocused = false;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void txtPassword_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                UserFocused = false;
                PasswrdFocused = true;
            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btn_NumberClick(object sender, EventArgs e)
        {
            try
            {
                string strKeyValue = string.Empty;
                Button btn = new Button();
                btn = (Button)sender;
                strKeyValue = btn.Tag.ToString();

                if (UserFocused == true)
                {
                    txtUserName.Text = txtUserName.Text + strKeyValue.ToUpper();
                }
                else if (PasswrdFocused == true)
                {
                    txtPassword.Text = txtPassword.Text + strKeyValue.ToUpper();
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnCancelKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                pnlLogin.Height = 220;
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Text = "";
                txtUserName.Text = "";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogin_Click(sender, e);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        void ShowLogin()
        {
            //GeneralFunction.Trace("Show Login Start");
            pnlLogin.Visible = true;
            pnlLogin.Size = new Size(331, 220);
            //pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
            // pnlLogin.Location = new Point(this.Size.Width / 2, this.Size.Height / 4 - 94);
            pnlSystemConfig.SendToBack();
            pnlSystemConfig.Visible = false;
            pnlLogin.BringToFront();
            txtUserName.Focus();


            //pnlLogin.Visible = true;
            //  picLogo.Visible = false;
            //  picNotes.Visible = false;
            //  flp_MainButtons.Visible = false;
            //  menuStrip1.Enabled = false;
            //  toolStrip1.Enabled = false;
            //  panel3.Visible = false;
            //  statusStrip1.Visible = false;
            //  lblNotes.Visible = false;
            //  pnlLogin.Location = new Point(((this.Size.Width / 2) - (pnlLogin.Size.Width / 2)), ((this.Size.Height / 2) - (pnlLogin.Size.Height / 2)));
            //  pnlLogin.Location = new Point(this.Size.Width / 2, this.Size.Height / 4 - 94);
            //  PnlScrollNotes.Visible = false;
            //  lblUserNameDisplay.Visible = false;
            //  pnlLogin.Size = new Size(331, 220);
            //  txtUserName.Focus();
            //  pgbarLoad.Location = new Point(this.Size.Width / 2, 350);
            //GeneralFunction.Trace("Show Login End");
        }
        private void barcodeCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obj_EmpDal.Check_Login();
                int barcount = 0;
                barcount = loginViewHelper.GetBarcodeCountHelp();
                if (barcount > 0)
                {
                    MessageBox.Show(GeneralFunction.ChangeLanguageforCustomMsg("TotalBarcodeCountis") + " " + barcount.ToString(), this.Text);
                }
                else
                {
                    MessageBox.Show("No Barcode");
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
            Bumedian_Business_Management_System objabt = new Bumedian_Business_Management_System();
            objabt.ShowDialog();
            objabt = null;
        }
        private void TStrip_Help_Help_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\\BumedianPOS.chm");
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            loginViewHelper.ShowExpiryList();
        }

        private void Tstrip_Tools_UploadTipoftheDay_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.Filter = "xls|*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    File.Copy(ofd.FileName, System.Windows.Forms.Application.StartupPath + "\\Tips.xlsx", true);
                    GeneralFunction.TipsCount = 0;
                    GeneralFunction.LoadTips();
                    GeneralFunction.Information("UploadFileSuccess", this.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "Tstrip_Tools_UploadTipoftheDay_Click");
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.ToolStripMenuItem TypesOfSkin;
                TypesOfSkin = (ToolStripMenuItem)sender;
                string jshgd = TypesOfSkin.Tag.ToString();
                GeneralFunction.ApplyChanges(TypesOfSkin.Tag.ToString());

            }
            catch (Exception ex)
            {

                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, this.Text, "defaultToolStripMenuItem_Click");
            }
        }

        private void MenuItem_Reports_Click(object sender, EventArgs e)
        {
            VisiblePanelbox();
            if (UserScreenLimidations.Reports)
            {
                Report report = new Report();
                report.ShowDialog();
                report = null;
            }
            else
            {
                GeneralFunction.ErrInfo(GeneralFunction.ChangeLanguageforCustomMsg("NoRightsUser"), this.Text);
            }
        }
        //********* Following are changed due to client has asked to display the blinking label whether it has expires date only in notes area.
        private void blinkLabel(object sender, EventArgs e)
        {
            //if (lblExpiryNotes.ForeColor == Color.Blue)
            //    lblExpiryNotes.ForeColor = Color.Beige;
            //else
            //    lblExpiryNotes.ForeColor = Color.Blue;
            GeneralFunction.blinkLabel(EventArgs.Empty, lblExpiryNotes);

            //LoginTime();Commented By Meena.R it need to all the time
        }

        private void toolStripMenuGeneratebrcodes_Click(object sender, EventArgs e)
        {
            bool res=loginViewHelper.GetEmptyBarcodes();
            if (res)
            {
                GeneralFunction.Information("GenerateItemBarcodes", ActionType.Information.ToString());
            }
            else
            {
                GeneralFunction.Information("NoDuplicateBarcode", ActionType.Information.ToString());
            }
        }

       
        private void toolStripstockmaintenance_Click(object sender, EventArgs e)
        {

            StockPassword show = new StockPassword();
            show.ShowDialog();
        }

        private void toolStripButtonEndShift_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralFunction.FormName = ToolName = (((ToolStripButton)sender).Tag).ToString();
                this.AssignScreen(ToolName);
            }
            catch (Exception ex)
            {
                GeneralFunction.ErrInfo(ex.Message.ToString(), this.Text);
                GeneralFunction.ErrorMessages(ex.Message, this.Text, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void toolStripLoginClear_Click(object sender, EventArgs e)
        {
            string FileName = System.Windows.Forms.Application.StartupPath + "\\" + "LoginClear.bat";
            System.Diagnostics.Process _process = new System.Diagnostics.Process();
            _process.StartInfo.FileName = System.Windows.Forms.Application.StartupPath + "\\" + "LoginClear.bat";
            if (File.Exists(_process.StartInfo.FileName))
            {
                _process.StartInfo.RedirectStandardError = false;
                _process.StartInfo.RedirectStandardOutput = false;
                _process.StartInfo.UseShellExecute = false;
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.Verb = "runas";
                Cursor.Current = Cursors.WaitCursor;
                _process.Start();
                _process.WaitForExit();
                //GeneralFunction.Information("DbRestoreSuccess", "Database Restore");
               
            }
        }








        //***********************************************************

        //public class AbortableBackgroundWorker : BackgroundWorker
        //{

        //    private Thread workerThread;

        //    protected override void OnDoWork(DoWorkEventArgs e)
        //    {
        //        workerThread = Thread.CurrentThread;
        //        try
        //        {
        //            base.OnDoWork(e);
        //        }
        //        catch (ThreadAbortException)
        //        {
        //            e.Cancel = true; //We must set Cancel property to true!
        //            Thread.ResetAbort(); //Prevents ThreadAbortException propagation
        //        }
        //    }


        //    public void Abort()
        //    {
        //        if (workerThread != null)
        //        {
        //            workerThread.Abort();
        //            workerThread = null;
        //        }
        //    }
        //}
    }


}




