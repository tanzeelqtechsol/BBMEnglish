using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
//using SQLDMO;
using ObjectHelper;
using System.IO.Ports;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.OleDb;
using System.Globalization;
using System.Threading;
using System.Data.Sql;
using Microsoft.Win32;
using System.Drawing.Printing;
//using Utils.MessageBoxExLib;

//using Microsoft.VisualBasic.Compatibility.VB6;
//using BumedianBM;



namespace CommonHelper
{
    public class GeneralFunction
    {
        #region Variables
        public static bool IsServer;
        //public static int UserId;
        public static int workstationid = 0;
        public static string workstationName = string.Empty;
        public static string UserName;
        public static bool isApplnRestart = false;
        public static bool Status = false;
        public static bool isAutobackup = false;
        public static string FormName;
        public static int startInterval = 10;
        public static int endInterval = 22;
        public static int startInterval1 = 22;
        public static int endInterval1 = 100;//42
        public static int WorkStationID = 0;
        public static int NoofPrint = 1;
        public static int NoofReceiptPrint = 1;
        public static string Language = String.Empty;
        public static bool _showConnectionDialog = false;
        public static string _connectionstring = string.Empty;
        public static string _server;
        public static string _database;
        public static string _UserId;
        public static string _password;
        public static string _skinName;
        public static int LoginUserId;
        public static string LoginUserName;
        public static string LoginPassword;
        public static int UserId;
        public static DateTime UserLoginTime;
        public static string Message;
        public static DateTime MessageDate;
        public static string RegEditPath = @"SOFTWARE\\Classes\\{BBECB0AB-6805-4103-BFB5-B7987D93B4B3}";
        public static int DefaultTrailPeriod = 20;
        public static DateTime StartWorkHrs;
        public static DateTime EndWorkHrs;
        public static bool PosPrint;
        public static string FlagCheck;
        public static string WeekEndDay;
        public static string _backuppath = string.Empty;
        public static string _alternateBackuppath = string.Empty;
        public static int UserGroupID;
        public static decimal ClientDebt = 0.00M;
        public static bool isCleanDB = false;
        public static string CleanDBDescription = "";

        public static ArrayList Notes = new ArrayList();
        public static ArrayList OnlyNotes = new ArrayList();
        public static ArrayList OnlyPayDates = new ArrayList();
        public static ArrayList OnlyExpiryDate = new ArrayList();
        public static ArrayList OnlyReorder = new ArrayList();
        public static ArrayList AgentId = new ArrayList();
        public static List<int> AgentID = new List<int>();
        public static ArrayList OnlyPayDaysForSupplier = new ArrayList();

        public static String NotesInVisible = "NO";

        private static string strLanguage = "";
        private static string SPNameGetOptionAlertMessage = "SP_Get_OptionAlertMessage";
        private static string SPNameUSP_GetOptionDtl = "USP_GetOptionDtl";
        private static string SPNameUSP_CompLogo = "USP_GetComLogo";
        private static Dictionary<string, string> dicUserTracking;

        public static string DigiUserName = string.Empty;
        public static string DigiPassword = string.Empty;
        public static DateTime getTime;

        public static decimal Paid = Convert.ToDecimal(0.000);
        public static decimal Refund = Convert.ToDecimal(0.000);
        public static string POSNotes;
        public static int IsNote;
        public static bool isExpiryMonthChanged = false;
        public static List<string> lstTips = new List<string>();
        public static string CashClientName = string.Empty;
        public static Boolean IsPaidStamp = false; //Added on 15-July-2014 by Seenivasan 
        //Following two Variables for POS Table Selection for Orders
        public static bool IsTableSelected = false;
        public static int TableShortCut = 0;

        public static string BuildDate = "2019.September.11";

        //private static DMSoft .SkinCrafter    _skinObject;
        //public static DMSoft.SkinCrafter  SkinObject
        //{
        //    get
        //    { 
        //        return _skinObject;
        //    }
        //}
        // public static DMSoft.SkinCrafter SkinObject { get; set; }

        #endregion

        #region GeneralErrorMessage
        //Included By :G.Saradhaa
        public static void ErrorMessages(string ErrorMessage, string FormName, string MethodName)
        {
            // ErrInfo("Error Occured:\r\nCheck Error log file to solve this Error!.", FormName);
            Errorlogfile(ErrorMessage, GeneralFunction.UserId, FormName, MethodName);
        }
        #endregion

        static GeneralFunction()
        {
            dicUserTracking = new Dictionary<string, string>();
            InitUserTracking();

            _skinName = System.Configuration.ConfigurationManager.AppSettings["SkinName"];
            //Obj_Data = new Databaseconnection();


        }
        public static void ApplySkin()
        {
            ApplyChanges(SkinName);
        }
        public static void ApplyChanges(String SkinName)
        {
            if (SkinName == "Default")
            {
                //  SkinObject.RemoveSkin();
            }
            else
            {

                // SkinObject.LoadSkinFromFile(Environment.CurrentDirectory + "\\Resources\\Skins" + SkinName + ".skf");
                //  SkinObject.LoadSkinFromFile();

                // SkinObject.ApplySkin();
            }
            SetConfigValue("Skin", SkinName);
        }

        //GeneralFunction.SkinObject.LoadSkinFromFile("d:\\VistaStyle.skf");
        //GeneralFunction.SkinObject.LoadSkinFromFile(Environment.CurrentDirectory + "\\Resources\\Skins\\" + SkinName + ".skf");
        // GeneralFunction.SkinObject.LoadSkinFromFile(System.Windows.Forms.Application.StartupPath + "\\Skins\\" + SkinName);
        // GeneralFunction.SkinObject.ApplySkin();

        // GeneralFunction.SetConfigValue("SkinName", SkinName.ToString());

        public static void SetConfigValue(string key, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            XmlNodeList appSettingsNodes = xmlDoc.SelectNodes(@"configuration/appSettings/add");
            foreach (XmlNode appSettingsNode in appSettingsNodes)
            {
                if (string.Equals(key, appSettingsNode.Attributes["key"].Value))
                {
                    appSettingsNode.Attributes["value"].Value = value;
                    break;
                }
            }
            xmlDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }
        public static void SetConfigValue(Dictionary<string, string> dictionary)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            XmlNodeList appSettingsNodes = xmlDoc.SelectNodes(@"configuration/appSettings/add");
            foreach (XmlNode appSettingsNode in appSettingsNodes)
            {
                if (dictionary.ContainsKey(appSettingsNode.Attributes["key"].Value))
                {
                    appSettingsNode.Attributes["value"].Value = dictionary[appSettingsNode.Attributes["key"].Value];
                }
            }
            xmlDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }
        private static void InitUserTracking()
        {
            try
            {
                dicUserTracking.Add("Save additional barcode details", "حفظ بيانات باركود إضافي");
                dicUserTracking.Add("Delete additional barcode details", "إلغاء بيانات باركود إضافي");
                dicUserTracking.Add("Save phone book details", "حفظ بيانات دليل الهاتف");
                dicUserTracking.Add("Delete phone book details", "الغاء بيانات دليل الهاتف");
                dicUserTracking.Add("Print phone book details", "طباعة بيانات دليل الهاتف");
                dicUserTracking.Add("Save agent name details", "حفظ بيانات عميل");
                dicUserTracking.Add("Update agent name details", "تحديث بيانات عميل");
                dicUserTracking.Add("Delete agent name details", "إلغاء بيانات عميل");
                dicUserTracking.Add("Print agent details", "طباعة بيانات عميل");
                dicUserTracking.Add("Print balance sheet details", "طباعة كشف حساب");
                dicUserTracking.Add("save bank deposit details", "حفظ بيانات إيداع مصرفي");
                dicUserTracking.Add("Print bank deposit details", "طباعة بيانات إيداع مصرفي");
                dicUserTracking.Add("Delete bank deposit details", "إلغاء بيانات إيداع مصرفي");
                dicUserTracking.Add("Save bank withdraw details", "حفظ بيانات سحب مصرفي");
                dicUserTracking.Add("Print bank withdraw details", "طباعة بيانات سحب مصرفي");
                dicUserTracking.Add("Delete bank withdraw details", "إلغاء بيانات سحب مصرفي");
                dicUserTracking.Add("Delete barcode print details", "إلغاء بيانات طباعة الباركود");
                dicUserTracking.Add("Save cash capital details", "حفظ إيصال إيداع نقدي");
                dicUserTracking.Add("Print cash capital details", "طباعة إيصال إيداع نقدي");
                dicUserTracking.Add("Delete cash capital details", "إلغاء إيصال إيداع نقدي");
                dicUserTracking.Add("Update password details", "تحديث بيانات كلمة السر");
                dicUserTracking.Add("Save category details", "حفظ بيانات المجموعة ");
                dicUserTracking.Add("Save company details", "حفظ بيانات الشركة ");
                dicUserTracking.Add("Save Item place details", "حفظ بيانات مكان الصنف");
                dicUserTracking.Add("Save Bank details", "حفظ بيانات المصرف");
                dicUserTracking.Add("Save Branch details", "حفظ بيانات الفرع");
                dicUserTracking.Add("Delete Category details", "الغاء بيانات المجموعة ");
                dicUserTracking.Add("Delete Company details", "الغاء بيانات الشركة ");
                dicUserTracking.Add("Delete item place details", "الغاء بيانات مكان الصنف");
                dicUserTracking.Add("Delete bank details", "الغاء بيانات المصرف");
                dicUserTracking.Add("Delete branch details", "الغاء بيانات الفرع");
                dicUserTracking.Add("Print daily book journal details", "طباعة بيانات كشف الترحكات");
                dicUserTracking.Add("Save debt adjustment details", "حفظ بيانات تعديل الرصيد ");
                dicUserTracking.Add("save receivable debt adjustment details", "حفظ بيانات تعديل رصيد ( عليه)");
                dicUserTracking.Add("Save payable debt adjustment details", "حفظ بيانات تعديل رصيد (له)");
                dicUserTracking.Add("delete payable debt adjustment details", "حفظ بيانات تعديل رصيد ( عليه)");
                dicUserTracking.Add("print payable debt adjustment details", "طباعة بيانات تعديل أرصدة عميل");
                dicUserTracking.Add("Save discount 1 details", "(1) تطبيق تخفيض");
                dicUserTracking.Add("Save discount 2 details", "(2) تطبيق تخفيض");
                dicUserTracking.Add("Save discount 3 details", "(3) تطبيق تخفيض");
                dicUserTracking.Add("Update user details", "تحديث بيانات المستخدم ");
                dicUserTracking.Add("save user details", "حفظ بيانات المستخدم ");
                dicUserTracking.Add("Update inventory adjust details", "تحديث بيانات تعديل المخزون");
                dicUserTracking.Add("Print inventory adjust details", "طباعة بيانات تعديل المخزون");
                dicUserTracking.Add("Delete item details", "إلغاء بيانات صنف");
                dicUserTracking.Add("Print item details", "طباعة بيانات صنف");
                dicUserTracking.Add("Save item details", "حفظ بيانات صنف");
                dicUserTracking.Add("Save item serial number details", "حفظ بيانات الرقم التسلسلي");
                dicUserTracking.Add("Delete item serial number details", "الغاء بيانات الرقم التسلسلي");
                dicUserTracking.Add("Print item serial number details", "طباعة بيانات رقم تسلسلي");
                dicUserTracking.Add("Modify openning stock details", "تعديل بيانات بضاعة أول المدة ");
                dicUserTracking.Add("Save openning stock details", "حفظ بيانات بضاعة أول المدة");
                dicUserTracking.Add("Print openning stock details", "طباعة بيانات بضاعة أول المدة");
                dicUserTracking.Add("save option setting details", "حفظ بيانات الاعدادات و الخيارات");
                dicUserTracking.Add("New order invoice details", "فتح فاتورة طلب شراء");
                dicUserTracking.Add("Save(close) order invoice details", "حفظ فاتورة طلب شراء");
                dicUserTracking.Add("Print order invoice details", "طباعة فاتورة طلب شراء");
                dicUserTracking.Add("Delete order invoice details", "إلغاء فاتورة طلب شراء");
                dicUserTracking.Add("Modify order invoice details", "تعديل فاتورة طلب شراء");
                dicUserTracking.Add("Insert order invoice details", "إدراج صنف في فاتورة طلب شراء");
                dicUserTracking.Add("Save pay receipt details", "حفظ إيصال دفع");
                dicUserTracking.Add("Print pay receipt details", "طباعة إيصال دفع");
                dicUserTracking.Add("Delete pay receipt details", "إلغاء إيصال دفع");
                dicUserTracking.Add("Save POS shortcut button details", "حفظ بيانات إعدادات شاشة الاختصار");
                dicUserTracking.Add("New proforma invoice details", "فتح فاتورة مبدئية جديدة");
                dicUserTracking.Add("Save(close) performa invoice details", "حفظ بيانات فاتروة مبدئية ");
                dicUserTracking.Add("Print Performa invoice details", "طباعة فاتورة مبدئية ");
                dicUserTracking.Add("Delete performa invoice details", "الغاء صنف من فاتورة مبدئية ");
                dicUserTracking.Add("Modify Performa invoice details", "تعديل فاتورة مبدئية");
                dicUserTracking.Add("Insert performa invoice details", "ادراج صنف بفاتورة مبدئية ");
                dicUserTracking.Add("New purchase invoice details", "فتح فاتورة مشتريات");
                dicUserTracking.Add("Save(close) purchase invoice details", "حفظ فاتورة مشتريات");
                dicUserTracking.Add("Print Purchase invoice details", "طباعة فاتورة مشتريات");
                dicUserTracking.Add("Delete purchase invoice details", "إلغاء صنف من فاتورة مشتريات");
                dicUserTracking.Add("Modify Purchase invoice details", "تعديل فاتورة مشتريات");
                dicUserTracking.Add("Insert purchase invoice details", "إدراج صنف في فاتورة مشتريات");
                dicUserTracking.Add("Return purchase return invoice details", "إرجاع صنف بفاتورة إرجاع مشتريات");
                dicUserTracking.Add("New purchase return invoice details", "فتح فاتروة إرجاع مشتريات جديدة");
                dicUserTracking.Add("Save(close) purchase return invoice details", "إغلاق فاتورة إرجاع مشتريات");
                dicUserTracking.Add("Print Purchase return invoice details", "طباعة فاتورة إرجاع مشتريات");
                dicUserTracking.Add("Modify purchase return invoice details", "تعديل فاتورة إرجاع مشتريات");
                dicUserTracking.Add("Save receive receipt details", "حفظ إيصال قبض");
                dicUserTracking.Add("Delete receive receipt details", "إلغاء إيصال قبض");
                dicUserTracking.Add("Print receive receipt details", "طباعة إصال قبض");
                dicUserTracking.Add("Return rent return invoice details", "ارجاع صنف بفاتورة ارجاع تاجير");
                dicUserTracking.Add("New rent return invoice details", "فتح فاتورة ارجاع ايجار جديدة");
                dicUserTracking.Add("Save(close) rent return invoice details", "حفظ فاتورة ارجاع ايجار");
                dicUserTracking.Add("Print rent return invoice details", "طباعة فاتورة ارجاع ايجار");
                dicUserTracking.Add("Modify rent return invoice details", "تعديل فاتورة ارجاع ايجار");
                dicUserTracking.Add("New renting invoice details", "فتح فاتورة ايجار جديدة");
                dicUserTracking.Add("Save(close) renting invoice details", "حفظ فاتورة ايجار");
                dicUserTracking.Add("Print renting  invoice details", "طباعة فاتورة ايجار ");
                dicUserTracking.Add("Delete renting invoice details", "الغاء صنف من فاتورة ايجار ");
                dicUserTracking.Add("Modify renting invoice details", "تعديل فاتورة ايجار");
                dicUserTracking.Add("Insert renting invoice details", "ادراج صنف في فاتورة ايجار");
                dicUserTracking.Add("Print salary payment details", "طباعة صرف مرتب");
                dicUserTracking.Add("Insert salary payment details", "إدراج بيانات صرف مرتب");
                dicUserTracking.Add("Modify salary payment details", "تعديل صرف مرتب");
                dicUserTracking.Add("Save(close) sale invoice details", "إغلاق فاتورة مبيعات");
                dicUserTracking.Add("Save sale invoice details", "حفظ فاتورة مبيعات");
                dicUserTracking.Add("New sale invoice details", "فتح فاتورة مبيعات جديدة");
                dicUserTracking.Add("Insert sale invoice details", "إدراج صنف في فاتورة مبيعات");
                dicUserTracking.Add("Modify sale invoice details", "تعديل فاتورة مبيعات");
                dicUserTracking.Add("Delete sale invoice details", "إلغاء صنف من فاتورة مبيعات");
                dicUserTracking.Add("Print sale invoice details", "طباعة فاتورة مبيعات");
                dicUserTracking.Add("Return sale return invoice details", "إرجاع صنف بفاتورة إرجاع مبيعات");
                dicUserTracking.Add("New sale return invoice details", "فتح فاتورة إرجاع مبيعات");
                dicUserTracking.Add("Save(close) sale return invoice details", "حفظ فاتورة إرجاع مبيعات");
                dicUserTracking.Add("Print sale return invoice details", "طباعة فاتورة إرجاع مبيعات");
                dicUserTracking.Add("Modify sale return invoice details", "تعديل فاتورة إرجاع مبيعات");
                dicUserTracking.Add("Save spoiled invoice details", "حفظ فاتورة تالف");
                dicUserTracking.Add("Save(close) spoiled invoice details", "حفظ فاتورة تالف");
                dicUserTracking.Add("New spoiled invoice details", "فتح إيصال مصروفات");
                dicUserTracking.Add("Insert spoiled invoice details", "إدراج صنف بفاتورة تالف");
                dicUserTracking.Add("Modify spoiled invoice details", "تعديل فاتورة تالف");
                dicUserTracking.Add("Delete spoiled invoice details", "إلغاء صنف من فاتورة تالف");
                dicUserTracking.Add("Print spoiled invoice details", "طباعة فاتورة تالف");
                dicUserTracking.Add("Print time attendance list details", "طباعة كشف الحضور");
                dicUserTracking.Add("Print time attendance details", "طباعة كشف الحضور و الانصراف");
                dicUserTracking.Add("Insert", "ادراج");
                dicUserTracking.Add("Update", "تحديث");
                dicUserTracking.Add("Modify", "تعديل");
                dicUserTracking.Add("Item ExpiryDates", "تاريخ انتهاء الصلاحية ");
                dicUserTracking.Add("Print end of days details", "طباعة بيانات إغلاق حساب اليوم");
                dicUserTracking.Add("Save user drawing details", "حفظ بيانات مسحوبات موظف");
                dicUserTracking.Add("Save user variable details", "حفظ بيانات متغيرات مستخدم");
                dicUserTracking.Add("Save user notes details", "حفظ بيانات ملاحظات مستخدم");
                dicUserTracking.Add("pritnt the tracking user details", "طبعة بيانات تتبع حركة المستخمين");
                dicUserTracking.Add("Print find sale invoice details", "طباعة بيانات بحث عن فاتورة مبيعات ");
                dicUserTracking.Add("Print barcode print details", "طباعة باركود");
                dicUserTracking.Add("print spending details", "طباعة إيصال مصروفات");
                dicUserTracking.Add("Print the tracking User details", "طباعة بيانات تتبع المستخدم");
                dicUserTracking.Add("Save spending details", "حفظ إيصال مصروفات");
                dicUserTracking.Add("User Logged In", "تسجيل دخول المستخدم");
                dicUserTracking.Add("User Logged out", "تسجيل خروج المستخدم");
                dicUserTracking.Add("Undo purchase return invoice details", "تراجع عن إرجاع صنف بفاتورة إرجاع مشتريات");
                dicUserTracking.Add("Delete Opening Stock invoice details", "إلغاء بيانات بضاعة أول المدة");
                dicUserTracking.Add("Undo Opening Stock invoice details", "تراجع عن تعديل بيانات بضاعة أول المدة");
                dicUserTracking.Add("Print Client_AgentBalanceSheet details", "طباعة كشف حساب عميل ");
                dicUserTracking.Add("Print ItemPurchaseMovement details", "طباعة حركة شراء صنف ");
                dicUserTracking.Add("Print ItemSaleMovement details", "طباعة حركة بيع صنف  ");
                dicUserTracking.Add("Print PurchaseReturnMovement details", " طباعة حركة ارجاع مشتريات ");
                dicUserTracking.Add("Print SaleReturnMovement details", "طباعة حركة ترجيع مبيعات ");
                dicUserTracking.Add("Print TotalPurchaseReturning details", "طباعة اجمالي ترجيعات المشتريات ");
                dicUserTracking.Add("Print TotalSaleReturning details", "طباعة اجمالي ترجيعات المبيعات ");
                dicUserTracking.Add("Print PriceList details", "طباعة لائحة الأسعار ");
                dicUserTracking.Add("Print SecondHandPriceList details", "طباعة قائمة اسعار المستعمل ");
                dicUserTracking.Add("Print WellMovingItems details", "طباعة الاصناف الاكثر حركة ");
                dicUserTracking.Add("Print SpoiledItems details", "طباعة أصناف تالفة ");
                dicUserTracking.Add("Print Inventory details", "طباعة بضاعة اول المدة ");
                dicUserTracking.Add("Print InventoryAtDate details", "طباعة قائمة المخزون في تاريخ ");
                dicUserTracking.Add("Print ExpiryListToADate details", "طباعة قائمة انتهاء الصلاحية حتى التاريخ ");
                dicUserTracking.Add("Print ItemCardInOutStock details", "طباعة بطاقة صنف وارد-صادر-مخزون ");
                dicUserTracking.Add("Print HourlySales details", "طباعة مبيعات ساعة ");
                dicUserTracking.Add("Print MonthssComparison details", "طباعة مقارنة الاشهر ");
                dicUserTracking.Add("Print UserProductivity details", "طباعة انتاجية المستخدمين المبيعات والارباح عن التفرة الخاصة بالمستخدم ");
                dicUserTracking.Add("Print BestWorstSalesPeriod details", "طباعة أفضل أسواء فترات الحركة ");
                dicUserTracking.Add("Print Zakat details", "طباعة الزكاة ");
                dicUserTracking.Add("Print BranchBalanceSheet details", "طباعة كشف حساب فرع ");
                dicUserTracking.Add("Print Supplier_AgentBalanceSheet details", "طباعة كشف حساب عميل ");
                dicUserTracking.Add("Print Branch_BranchBalanceSheet details", "طباعة كشف حساب فرع ");
                dicUserTracking.Add("Print DebtsToBePaid details", "طباعة ديون مستحقة الدفع ");
                dicUserTracking.Add("Print BankStatement details", "طباعة كشف حساب مصرفي ");
                dicUserTracking.Add("Print NetProfit details", "طباعة صافي الربح ");
                dicUserTracking.Add("Print Receivables details", "طباعة المقبوضات ");
                dicUserTracking.Add("Print Payables details", "طباعة الديون المستحقة عليك ");
                dicUserTracking.Add("Print Spendings details", "طباعة المصاريف ");
                dicUserTracking.Add("Print DebtList details", "طباعة قائمة الديون ");
                dicUserTracking.Add("Print Drawings details", "طباعة مسحوبات ");
                dicUserTracking.Add("Print SaleInvoiceList details", "طباعة قائمة فواتير البيع ");
                dicUserTracking.Add("Print TotalDiscounts details", "طباعة مجموع الخصم ");
                dicUserTracking.Add("Print SaleMovementAccordingTo details", "طباعة حركة المبيعات حسب ");
                dicUserTracking.Add("Print ClientPaymentList details", "طباعة قائمة مدفوعات عميل ");
                dicUserTracking.Add("Print ClientList details", "طباعة قائمة العميل ");
                dicUserTracking.Add("Print TotalClientsMovement details", "طباعة مجموع حركة العملاء ");
                dicUserTracking.Add("Print TotalDiscountFromTheClients details", "طباعة مجموع الخصم من العملاء ");
                dicUserTracking.Add("Print TotalDiscountFromTheSupplier details", "طباعة مجموع الخصم من المورد ");
                dicUserTracking.Add("Print InventoryValue details", "طباعة قيمة المخزون ");
                dicUserTracking.Add("Print SuppliersList details", "طباعة قائمة الموردين ");
                dicUserTracking.Add("Print PurchaseInvoiceList details", "طباعة قائمة فواتير الشراء ");
                dicUserTracking.Add("Print SuppliersLatePayments details", "طباعة دفعات الموردين المتأخرة ");
                dicUserTracking.Add("Print ListOfSaleAndProfitOfEachClient details", "طباعة قائمة مشتريات و ارباح لكل عميل التفاصيل");
                dicUserTracking.Add("Print BranchReturningList details", "طباعة قائمة مرجعات فرع ");
                dicUserTracking.Add("Print TotalPurchaseOfABranch details", "طباعة اجمالي مشرتيات فرع ");
                dicUserTracking.Add("Print BranchesList details", "طباعة قائمة الفروع ");
                dicUserTracking.Add("Print BranchMovement details", "طباعة حركة الفرع ");
                dicUserTracking.Add("Print find purchase invoice details", "طباعة بيانات البحث عن فاتورة مشتريات");
                dicUserTracking.Add("Delete spending details", "إلغاء إيصال مصروفات");
                dicUserTracking.Add("Save POS shortcut table details", "حفظ فاتورة البيع السريع");
                dicUserTracking.Add("Save barcode print details", "حفظ بيانات باركود");
                dicUserTracking.Add("Print discount details", "طباعة بيانات تخفيض");
                dicUserTracking.Add("Delete POS shortcut button details", "إلغاء بيانات زر اعدادات البيع السريع");
                dicUserTracking.Add("Delete POS shortcut table button details", "إلغاء بيانات زر إعدادات اضافية من شاشة البيع السريع");
                dicUserTracking.Add("Report details", "التقارير التفاصيل");
                dicUserTracking.Add("Agent", "العملاء");
                dicUserTracking.Add("Barcode print", "طباعة باركود");
                dicUserTracking.Add("BARCODE", "باركود");
                dicUserTracking.Add("Debt adjustment", "تعديل ارصدة");
                dicUserTracking.Add("USER", "المستخدم");
                dicUserTracking.Add("EndofDay", "حساب آخر اليوم");
                dicUserTracking.Add("FindPurchaseInvoice", "بحث عن فاتورة مشتريات");
                dicUserTracking.Add("Adjust inventory", "تعديل بضاعة اول المدة");
                dicUserTracking.Add("STOCK_ADJUST", "المخزون تعديل");
                dicUserTracking.Add("Login Form", "تسجيل الدخول ");
                dicUserTracking.Add("MasterForm", " الشاشة الرئيسية");
                dicUserTracking.Add("OpeningStock", "بضاعة أول المدة");
                dicUserTracking.Add("Inventory", "بضاعة اول المدة");
                dicUserTracking.Add("Option", "إعدادات و خيارات");
                dicUserTracking.Add("OrderInvoice", "فاتورة طلب توريد");
                dicUserTracking.Add("Order", "طلب");
                dicUserTracking.Add("Qty-", "الكمية-");
                dicUserTracking.Add("InvNo-", "رقم الفاتورة-");
                dicUserTracking.Add("PayReceipt", "ايصال دفع");
                dicUserTracking.Add("RECEIPT", "ايصال");
                dicUserTracking.Add("button detail", "زر التفاصيل");
                dicUserTracking.Add("ButtonSelection", "زر انتقاء");
                dicUserTracking.Add("PurchaseInvoice", "فاتورة مشتريات");
                dicUserTracking.Add("Purchase", "مشتريات");
                dicUserTracking.Add("Purchase Return", "ارجاع مشتريات");
                dicUserTracking.Add("PurchaseReturnInvoice", "فاتورة ارجاع مشتريات");
                dicUserTracking.Add("ReceiveReceipt", "ايصال قبض");
                dicUserTracking.Add("Salary Payment", "صرف مرتبات");
                dicUserTracking.Add("USER_SALARY_PAYMENT", "المستخدم_راتب_دفع مال");
                dicUserTracking.Add("SaleInvoice", "فاتورة مبيعات");
                dicUserTracking.Add("Sales", "المبيعات");
                dicUserTracking.Add("Sale Return", "ارجاع مبيعات");
                dicUserTracking.Add("SALE_RETURN", "البيع_ارجاع");
                dicUserTracking.Add("SaleReturnInvoice", "ترجيع مبيعات");
                dicUserTracking.Add("EXPENSES", "مصاريف");
                dicUserTracking.Add("Spoiled Item", "اصناف تالفة الصنف");
                dicUserTracking.Add("Table detail", "جدول التفاصيل");
                dicUserTracking.Add("TableSelection", "جدول انتقاء");
                dicUserTracking.Add("BalanceSheet", "كشف الحساب");
                dicUserTracking.Add("CASH CAPITAL", "ايداع رأس المال");
                dicUserTracking.Add("Cash Capital Details", "ايداع رأس المال التفاصيل");
                dicUserTracking.Add("PAYMENT", "دفع مال");
                dicUserTracking.Add("Discount details", "التخفيض التفاصيل");
                dicUserTracking.Add("DISCOUNT", "التخفيض");
                dicUserTracking.Add("Employee Details", "القائم مقام موظف التفاصيل");
                dicUserTracking.Add("Item Card", "بطاقة صنف");
                dicUserTracking.Add("Additional Barcode", "باركود إضافي");
                dicUserTracking.Add("Item details", "الصنف التفاصيل");
                dicUserTracking.Add("Item Serial No", "الرقم التسلسلي");
                dicUserTracking.Add("Change password", "تغيير كلمة السر");
                dicUserTracking.Add("TimeAttendance", "قائمة ساعات الحضور");
                dicUserTracking.Add("UserTracking", "تتبع تحركات المستخدم");
            }
            catch (Exception ex)
            {
                Errorlogfile(ex.Message, UserId, "General Function", "InitUserTracking()");
            }
        }
        #region CompanyInfoLoad

        public static DataTable GetCompLogo()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserID", GeneralFunction.UserId);
                DataTable DT_CompanyInfo = ExecuteQueryDatatable("USP_Get_CompanyLogo", param, "CompanyInfo");
                return DT_CompanyInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        # endregion

        #region Enum
        public enum messageType { sale, custom, empty };

        #endregion

        #region Properties

        public static string Server
        { get { return _server; } }
        public static string Database
        { get { return _database; } }
        public static string UserID
        { get { return _UserId; } }
        public static string Password
        { get { return _password; } }
        public static string BackupPath
        { get { return _backuppath; } }
        public static string AlternateBackupPath
        { get { return _alternateBackuppath; } }
        public static string SkinName
        { get { return _skinName; } }
        public static string ConnectionString
        { get { return _connectionstring; } }
        //-------------------------sample vcalidation method-------------------------

        //public GeneralFunction() { }


        //public GeneralFunction(string errorMessage)
        //{
        //    ErrorMessage = errorMessage;
        //}

        public string ErrorMessage { get; set; }
        //--------------------------------------------------------------------------------


        //public static List<AgentDetailObjectClass> AgentList = new List<AgentDetailObjectClass>();

        #endregion

        #region ErrorLog Methods

        public static bool IsDebug
        {
            get
            {
#if (DEBUG)
                return true;
#else
                return false;
#endif
            }
        }

        public static void Trace(string message)
        {
            if (IsDebug)
                System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + ": " + message);
            else
                Errorlogfile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + ": " + message, 1, "", "", true);//::TODO check in release mode
            // WriteinErrorCode("Trace:", "Performance", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + ": " + message);//::TODO check in release mode
            // System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + ": " + message);
        }

        public static void Errorlogfile(string Errmsg, int UserId, string Formname, string Eventoccured, bool isTrace = false)
        {
            try
            {

                string Errorlog = " " + DateTime.Now + "\r\n" + " " + "\r\n" + " ErrorDescription:" + Errmsg + "\r\n";
                FileStream Fs;

                DirectoryInfo Dir = new DirectoryInfo((System.Windows.Forms.Application.StartupPath) + "\\ErrorLogFile");
                if (!Dir.Exists)
                {
                    Dir.Create();
                }
                string Filename;
                Filename = (System.Windows.Forms.Application.StartupPath) + "\\ErrorLogFile\\ErrorInfo.txt";
                FileInfo FileName = new FileInfo(Filename);
                if (!File.Exists(Filename))
                {
                    Fs = new FileStream(Filename, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                }
                else
                {
                    Fs = new FileStream(Filename, FileMode.Append, FileAccess.Write, FileShare.None);
                }
                StreamWriter Swriter = new StreamWriter(Fs, System.Text.Encoding.Default);
                Swriter.WriteLine();
                if (isTrace)
                {
                    Swriter.WriteLine(Errmsg);
                }
                else
                {

                    Swriter.WriteLine("------------------------------------------------------------------");
                    Swriter.WriteLine(Errorlog);
                    Swriter.WriteLine(" $$$ User Name: " + UserId + " $$$");
                    Swriter.WriteLine(" $$$ Form Name   : 24-12" + Formname + " $$$");
                    Swriter.WriteLine(" $$$ Event Occured: " + Eventoccured + " $$$");
                    Swriter.WriteLine(" $$$ Interface: " + Language + " $$$");
                    Swriter.WriteLine("------------------------------------------------------------------");
                }
                Swriter.WriteLine();
                Swriter.Flush();
                Swriter.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured Condact Admin to Solve this Error!", "Errorlog Function");
            }


        }


        public static DialogResult ErrInfo(string Message, string Caption)
        {
            try
            {


                return MessageBox.Show(Message, (Caption), MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //-------------------------sam,ple validation method-------------------------------


        //public static class ENTValidationErrorHelper
        //{

        //    public static void Add(this List<GeneralFunction> Errors, string Error)
        //    {

        //        Errors.Add(new GeneralFunction(Error));

        //    }

        //    //public static bool IsErrorAvailable(this List<ENTValidationError> Errors)
        //    //{
        //    //    return (Errors.Count > 0) ? true : false;

        //    //}

        //    public static void Add(this List<GeneralFunction> Errors, string Error, MessageType Msgtype)
        //    {

        //        Errors.Add(new GeneralFunction(Msgtype.ToString() + " : " + Error));

        //    }


        //    public static string GetAllMessages(this List<GeneralFunction> Errors)
        //    {

        //        return string.Join(Environment.NewLine, Errors.Select(e => e.ErrorMessage).ToArray());

        //    }


        //    public enum MessageType
        //    {

        //        Warning,

        //        Error

        //    }


        //}
        //-------------------------------------------------------------------------------

        #region MessageBox
        public static DialogResult Information(string Message, string Caption)
        {
            return MessageBox.Show(ChangeLanguageforCustomMsg(Message), ChangeLanguageforCustomMsg(Caption), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Warning(string Message, string Caption)
        {
            return MessageBox.Show(ChangeLanguageforCustomMsg(Message), ChangeLanguageforCustomMsg(Caption), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Question(string Message, string Caption)
        {
            return MessageBox.Show(ChangeLanguageforCustomMsg(Message), ChangeLanguageforCustomMsg(Caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult OKCancelMsg(string Message, string Caption)
        {
            return MessageBox.Show(ChangeLanguageforCustomMsg(Message), ChangeLanguageforCustomMsg(Caption), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        // return MessageBox.Show(Message, Caption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        #endregion

        #region GetValueByResourceKey
        public static string GetValueByResourceKey(string Key)
        {
            ResourceManager lResoruce;
            lResoruce = new ResourceManager("BumedianBM.ResourceFile.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            return lResoruce.GetString(Key);
        }
        #endregion

        #region SetGridColumn
        public static void SetGridColumn(DataTable dt, int noColumns, int[] width, DataGridView dg)
        {
            if (dt != null && dt.Rows.Count > 0)
            {

                dg.DataSource = dt;
                dg.Columns[0].Visible = false;
                for (int i = 1; i < noColumns; i++)
                {

                    var column = dg.Columns[i];
                    column.Width = width[i];
                    // column.HeaderText = header[i];

                }

            }
            else
            {
                GeneralFunction.Information("There is no record", ActionType.View.ToString());
            }
        }
        #endregion

        #region SetGridColumnSize
        public static void SetGridColumnSize(List<Object> list, int noColumns, int[] width, DataGridView dg)
        {
            if (list != null && list.Count > 0)
            {
                dg.DataSource = list;
                dg.Columns[0].Visible = false;
                for (int i = 1; i < noColumns; i++)
                {
                    var column = dg.Columns[i];
                    column.Width = width[i];
                    // column.HeaderText = header[i];

                }
            }
            else
            {
                dg.DataSource = null;
                GeneralFunction.Information("ThereisnoRecord", ActionType.View.ToString());
            }

        }
        #endregion

        #region SetDropdownControl
        public static void SetDropdownControl(ComboBox ctl, DataTable source, string displayMember, string valueMember)
        {
            ctl.DataSource = source;
            ctl.DisplayMember = displayMember;
            ctl.ValueMember = valueMember;
            ctl.SelectedIndex = -1;
        }
        #endregion

        #region DBUpdate
        public static void DBUpdate(SqlParameter[] sqlparam, string query)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = query;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    if (sqlparam != null && sqlparam.Length > 0)
                    {
                        sqlcmd.Parameters.AddRange(sqlparam);
                    }
                    sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }
            catch (Exception ex)
            {
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "General Function", "DBUpdate Function");
            }
        }
        #endregion



        #region SetConnection
        public static void SetConnection(string server, string UserID, string password, string datebase)
        {

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
                                                          "ConnectionString",
                                                          String.Format("DataSource={0};InitialCatalog={1};User ID={2};Password={3}",
                                                                         server, datebase, UserID, password)));
            //string con="Data Source=192.168.1.100\PROTEAMTFS;Initial Catalog=BBM;User ID=BBM-User;Password=ptl#123";
            //  config.ConnectionStrings.ConnectionStrings["BumedianConnectionString"].ConnectionString =@"Data Source=|Data|"


            //config.ConnectionStrings.ConnectionStrings["User ID"].ConnectionString = dictionary.Values.ToString();
            //config.ConnectionStrings.ConnectionStrings["DataSource"].ConnectionString = dictionary.ContainsKey("Server").ToString();
            //config.ConnectionStrings.ConnectionStrings["User ID"].ConnectionString = dictionary.ContainsKey("UserId").ToString();
            //config.ConnectionStrings.ConnectionStrings["Initial Catelog"].ConnectionString = dictionary.ContainsKey("Database").ToString();
            //config.ConnectionStrings.ConnectionStrings["Password"].ConnectionString = dictionary.ContainsKey("Password").ToString();
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

            config.Save(ConfigurationSaveMode.Modified);

        }
        #endregion

        #region "Encryption and Decryption"

        public static string Decrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();

            string Password = "PTLIndia";
            string DecryptedData;

            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);

                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }
            return DecryptedData;
        }

        public static string Encrypt(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "PTLIndia";
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object. 
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);

            return EncryptedData;
        }

        #endregion

        #region ChangeLanguageforCustomMsg
        public static string ChangeLanguageforCustomMsg(string Key)

        {
            //ResourceManager lResoruce;
            GeneralFunction.Language = System.Configuration.ConfigurationManager.AppSettings["Language"];
            ResourceManager resourceManager;
            if (ConfigurationSettings.AppSettings["Language"] == "Arabic")
            {

                resourceManager = new ResourceManager("CommonHelper.ResourceMessages.ArabicMessages", System.Reflection.Assembly.GetExecutingAssembly());
            }
            else
            {
                resourceManager = new ResourceManager("CommonHelper.ResourceMessages.EnglishMessages", System.Reflection.Assembly.GetExecutingAssembly());
            }
            string text = string.Empty;
            text = resourceManager.GetString(Key.Replace(" ", "").Replace("  ", "").Replace(".", ""));
            if (!string.IsNullOrEmpty(text))
            { return text; }
            else { return Key; }
            // }
            //else return Key;
        }
        #endregion

        #region RestoreDB
        public static string RestoreDB(string path)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BAK(*.bak)|*.bak";
            ofd.InitialDirectory = path;
            string restoreFile = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                restoreFile = ofd.FileName;
            }
            try
            {
                if (restoreFile != string.Empty)
                {
                    SqlParameter[] sqlparam = new SqlParameter[3];
                    sqlparam[0] = new SqlParameter("@FilePath", restoreFile);
                    sqlparam[1] = new SqlParameter("@Option", true);
                    sqlparam[2] = new SqlParameter("@DataBaseName", GeneralFunction.Database);
                    //  DataTable dtResult = objdata.ExecuteQueryDatatable("DB_BackupOrRestore", sqlparam, "DB_BackupOrRestore");
                    //var result = GetScalar("DB_BackupOrRestore", sqlparam);
                    // // calling function for Restoring the BBM database done by Praba on 19-Jun-2014
                    var result = GetRestoreDB(restoreFile);
                    //if (result.ToString() != "Success")
                    //{
                    //    return result;
                    //}
                    return result;
                }
                else
                    return "";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ChangeLanguageforCustomMsg("DbRestoreFailed"), "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Failed";
            }
            //SQLServer2Class server = new SQLServer2Class();
            //Restore2Class restore = new Restore2Class();

            //try
            //{
            //    string restoreFile = string.Empty;
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    server.LoginSecure = true;
            //    server.Connect(Server, UserId, Password);
            //    ofd.Filter = "BAK(*.bak)|*.bak";

            //    if (!string.IsNullOrEmpty(GeneralOptionSetting.FlagSaveBackup))
            //    {
            //        ofd.InitialDirectory = GeneralOptionSetting.FlagSaveBackup;
            //        //ofd.InitialDirectory = (Directory.GetDirectories(GeneralOptionSetting.FlagSaveBackup))[0].ToString();
            //    }
            //    else ofd.InitialDirectory = "D:\\";
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        restoreFile = ofd.FileName;

            //        Microsoft.SqlServer.Management.Smo.Restore sqlRestore = new Microsoft.SqlServer.Management.Smo.Restore();
            //        BackupDeviceItem deviceItem = new BackupDeviceItem(restoreFile, DeviceType.File);
            //        sqlRestore.Devices.Add(deviceItem);
            //        sqlRestore.Database = Database;
            //        ServerConnection connection = new ServerConnection(Server, UserId.ToString(), LoginPassword);
            //        Server sqlServer = new Server(connection);
            //        sqlServer.KillAllProcesses(Database);
            //        Microsoft.SqlServer.Management.Smo.Database db = sqlServer.Databases[Database];
            //        sqlRestore.Action = RestoreActionType.Database;
            //        sqlRestore.ReplaceDatabase = true;
            //        sqlRestore.SqlRestore(sqlServer);
            //        db = sqlServer.Databases[Database];
            //        db.SetOnline();
            //        sqlServer.Refresh();
            //       Information("DbRestoreSuccess", "Database Restore");

            //        try
            //        {
            //            SqlParameter[] sqlparam = new SqlParameter[0];
            //            DataTable dt=ExecuteQueryDatatable("Select * from MTB_SPOILED_INVOICE", sqlparam, "InitializingConnection");
            //        }
            //        catch (SqlException)
            //        {

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ChangeLanguageforCustomMsg("DbRestoreFailed"), "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    //server.ExecuteImmediate("ALTER DATABASE " + Database + " SET MULTI_USER", SQLDMO_EXEC_TYPE.SQLDMOExec_Default, 100);
            //    //server.DisConnect();
            //    //restore = null;
            //    //server = null;
            //}
        }
        #endregion

        #region BackupDB
        public static void BackupDB()
        {

            string FileName = string.Empty;
            string AlternateFileName = string.Empty;
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                string bcupPath = string.Empty;
                if (GeneralFunction._alternateBackuppath == "")
                    GeneralFunction._alternateBackuppath = GeneralOptionSetting.FlagAlternativePath;
                if (!string.IsNullOrEmpty(BackupPath))
                {
                    bcupPath = BackupPath;
                }
                else if (fbd.ShowDialog() == DialogResult.OK)
                {
                    bcupPath = fbd.SelectedPath;
                    string fieldname = string.Empty;
                    fieldname = (isAutobackup && GeneralOptionSetting.FlagSaveAutomaticBackupInAlternativePath == "Y") ? "Txt_AlternativePath" : "Txt_SaveBackup";
                    UpdateBackUpPath(bcupPath, fieldname);
                }
                else
                {
                    return;
                }

                if (GeneralOptionSetting.FlagSaveFilenameWithDatetime == "Y")
                {
                    FileName = (GeneralFunction.isAutobackup) ? bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_auto" + ".BAK" : bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".BAK";
                    if (GeneralFunction._alternateBackuppath != bcupPath && (GeneralFunction._alternateBackuppath != ""))
                        AlternateFileName = (GeneralFunction.isAutobackup) ? GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_auto" + ".BAK" : GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".BAK";
                    //backup.Files = FileName;
                }
                else
                {
                    FileName = (GeneralFunction.isAutobackup) ? bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyy") + "_auto" + ".BAK" : bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyy") + ".BAK";
                    if (GeneralFunction._alternateBackuppath != bcupPath && (GeneralFunction._alternateBackuppath != ""))
                        AlternateFileName = GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyy") + "_auto" + ".BAK";
                    //backup.Files = FileName;
                    //if (File.Exists(FileName))
                    //{                            
                    //    FileInfo fi = new FileInfo(FileName);
                    //    fi.Delete();
                    //}
                }

                if (GeneralOptionSetting.FlagAskWhenReplacingFile == "Y")
                {
                    if (File.Exists(FileName))
                    {
                        string message = ChangeLanguageforCustomMsg("AlreadyFileExists") + " " + FileName + "," + ChangeLanguageforCustomMsg("WouldYouReplace");
                        DialogResult res = MessageBox.Show(message, "Database Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (res != DialogResult.Yes) { return; }
                        //if (GeneralFunction.Question("Already this file Exists named " + FileName + ",Would you like to replace the existing file  ", "Database Backup") != DialogResult.Yes)
                        //{ return; }
                    }
                }

                try
                {
                    //Databaseconnection objdata = new Databaseconnection();
                    SqlParameter[] sqlparam = new SqlParameter[4];
                    sqlparam[0] = new SqlParameter("@FilePath", FileName);
                    sqlparam[1] = new SqlParameter("@AlternateFilePath", AlternateFileName);
                    sqlparam[2] = new SqlParameter("@Option", false);
                    sqlparam[3] = new SqlParameter("@DataBaseName", GeneralFunction.Database);
                    //  DataTable dtResult = objdata.ExecuteQueryDatatable("DB_BackupOrRestore", sqlparam, "DB_BackupOrRestore");
                    var result = GetScalar("DB_BackupOrRestore", sqlparam);
                    if (result.ToString() != "Success")
                    {
                        throw new Exception();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 3201)
                    {
                        Information("InvalidPath", GeneralFunction.isAutobackup ? "Automatic Database Backup" : "Database Backup");
                        //MessageBox.Show("Access is Denied, No Permission", GeneralFunction.isAutobackup ? "Automatic Database Backup" : "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ChangeLanguageforCustomMsg("DbBackUpFailed"), "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //MessageBox.Show("Inner Exception :" + ex.Message, "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                UpdateBackUpPath("Txt_LastBackupDate", DateTime.Now.ToString());
                if (isAutobackup)
                {
                    GeneralFunction.SetConfigValue("AutomaticLastBackupDate", DateTime.Now.ToString());
                    GeneralOptionSetting.FlagAutomaticLastBackupDate = ConfigurationSettings.AppSettings["AutomaticLastBackupDate"].ToString();
                }
                else
                {
                    Information("DbBackUpSuccess", "DatabaseBackup");
                    GeneralFunction.SetConfigValue("AutomaticLastBackupDate", DateTime.Now.ToString());
                    GeneralOptionSetting.FlagAutomaticLastBackupDate = ConfigurationSettings.AppSettings["AutomaticLastBackupDate"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ChangeLanguageforCustomMsg("DbBackUpFailed"), "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Outer Exception :"+ex.Message, "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //server.DisConnect();
                //backup = null;
                //server = null;
            }
        }
        #endregion


        public static bool BackupDBStock()
        {

            string FileName = string.Empty;
            string AlternateFileName = string.Empty;
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                string bcupPath = string.Empty;
                if (GeneralFunction._alternateBackuppath == "")
                    GeneralFunction._alternateBackuppath = GeneralOptionSetting.FlagAlternativePath;
                if (!string.IsNullOrEmpty(BackupPath))
                {
                    bcupPath = BackupPath;
                }
                else if (fbd.ShowDialog() == DialogResult.OK)
                {
                    bcupPath = fbd.SelectedPath;
                    string fieldname = string.Empty;
                    fieldname = (isAutobackup && GeneralOptionSetting.FlagSaveAutomaticBackupInAlternativePath == "Y") ? "Txt_AlternativePath" : "Txt_SaveBackup";
                    UpdateBackUpPath(bcupPath, fieldname);
                }
                else
                {
                    return false;
                }

                if (GeneralOptionSetting.FlagSaveFilenameWithDatetime == "Y")
                {
                    FileName = (GeneralFunction.isAutobackup) ? bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_auto" + ".BAK" : bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".BAK";
                    if (GeneralFunction._alternateBackuppath != bcupPath && (GeneralFunction._alternateBackuppath != ""))
                        AlternateFileName = (GeneralFunction.isAutobackup) ? GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "_auto" + ".BAK" : GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".BAK";
                    //backup.Files = FileName;
                }
                else
                {
                    FileName = (GeneralFunction.isAutobackup) ? bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyy") + "_auto" + ".BAK" : bcupPath + "\\" + DateTime.Now.ToString("ddMMyyyy") + ".BAK";
                    if (GeneralFunction._alternateBackuppath != bcupPath && (GeneralFunction._alternateBackuppath != ""))
                        AlternateFileName = GeneralFunction._alternateBackuppath + "\\" + DateTime.Now.ToString("ddMMyyyy") + "_auto" + ".BAK";
                    //backup.Files = FileName;
                    //if (File.Exists(FileName))
                    //{                            
                    //    FileInfo fi = new FileInfo(FileName);
                    //    fi.Delete();
                    //}
                }

                if (GeneralOptionSetting.FlagAskWhenReplacingFile == "Y")
                {
                    if (File.Exists(FileName))
                    {
                        string message = ChangeLanguageforCustomMsg("AlreadyFileExists") + " " + FileName + "," + ChangeLanguageforCustomMsg("WouldYouReplace");
                        DialogResult res = MessageBox.Show(message, "Database Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (res != DialogResult.Yes) { return false; }
                        //if (GeneralFunction.Question("Already this file Exists named " + FileName + ",Would you like to replace the existing file  ", "Database Backup") != DialogResult.Yes)
                        //{ return; }
                    }
                }
                var result = (dynamic)null;
                try
                {
                    //Databaseconnection objdata = new Databaseconnection();
                    SqlParameter[] sqlparam = new SqlParameter[4];
                    sqlparam[0] = new SqlParameter("@FilePath", FileName);
                    sqlparam[1] = new SqlParameter("@AlternateFilePath", "");
                    sqlparam[2] = new SqlParameter("@Option", false);
                    sqlparam[3] = new SqlParameter("@DataBaseName", GeneralFunction.Database);
                    //  DataTable dtResult = objdata.ExecuteQueryDatatable("DB_BackupOrRestore", sqlparam, "DB_BackupOrRestore");
                     result = GetScalar("DB_BackupOrRestore", sqlparam);
                    if (result.ToString() != "Success")
                    {
                        throw new Exception();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 3201)
                    {
                        Information("InvalidPath", GeneralFunction.isAutobackup ? "Automatic Database Backup" : "Database Backup");
                        //MessageBox.Show("Access is Denied, No Permission", GeneralFunction.isAutobackup ? "Automatic Database Backup" : "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ChangeLanguageforCustomMsg("DbBackUpFailed"), "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //MessageBox.Show("Inner Exception :" + ex.Message, "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }

                UpdateBackUpPath("Txt_LastBackupDate", DateTime.Now.ToString());
                if (isAutobackup)
                {
                    GeneralFunction.SetConfigValue("AutomaticLastBackupDate", DateTime.Now.ToString());
                    GeneralOptionSetting.FlagAutomaticLastBackupDate = ConfigurationSettings.AppSettings["AutomaticLastBackupDate"].ToString();
                }
                else
                {
                    Information("DbBackUpSuccess", "DatabaseBackup");
                    GeneralFunction.SetConfigValue("AutomaticLastBackupDate", DateTime.Now.ToString());
                    GeneralOptionSetting.FlagAutomaticLastBackupDate = ConfigurationSettings.AppSettings["AutomaticLastBackupDate"].ToString();

                }

                if (result.ToString() == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ChangeLanguageforCustomMsg("DbBackUpFailed"), "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Outer Exception :"+ex.Message, "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //server.DisConnect();
                //backup = null;
                //server = null;
            }

            return false;
        }


        #region UpdateBackUpPath
        public static void UpdateBackUpPath(string path, string filed)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@Flag", path);
            sqlparam[1] = new SqlParameter("@Option", filed);
            DBUpdate(sqlparam, "SP_Update_Option");

        }
        #endregion

        #region GetScalar
        public static object GetScalar(string procName, SqlParameter[] param)
        {
            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(procName, sqlcon))
                    {
                        if (param != null)
                        {
                            sqlCmd.CommandTimeout = 0;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Parameters.AddRange(param);
                        }
                        return sqlCmd.ExecuteScalar();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed) sqlcon.Close();
                }
            }
        }
        #endregion


        #region GetScalar
        // New Function for Restoring the BBM database done by Praba on 19-Jun-2014
        public static string GetRestoreDB(string filepath)
        {
            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, "Master", UserID, Password)))
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        string mycommand = "";

                        sqlCmd.Connection = sqlcon;
                        sqlCmd.CommandTimeout = 0;
                        sqlCmd.CommandType = CommandType.Text;
                        mycommand = "ALTER DATABASE [BBM] SET Single_User WITH Rollback Immediate";
                        mycommand += " USE MASTER RESTORE DATABASE BBM FROM DISK =   '" + filepath + "' WITH REPLACE";
                        mycommand += " ALTER DATABASE [BBM] SET Multi_User";
                        sqlCmd.CommandText = mycommand;
                        sqlCmd.ExecuteNonQuery();
                        return "Success";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (sqlcon.State != ConnectionState.Closed) sqlcon.Close();
                }
            }
        }

        public static List<string> CheckLocalInstance()
        {
            //DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            List<string> localconnection = new List<string>();
            //for (int i = 0; i < servers.Rows.Count; i++)
            //{
            //    //if ((servers.Rows["InstanceName"] as string) != null)
            //    //    localconnection.Add(servers.Rows["ServerName"] + "\\" + servers.Rows["InstanceName"]);
            //    //else
            //    //    localconnection.Add(servers.Rows["ServerName"]);

            //}
            var dt = SmoApplication.EnumAvailableSqlServers(true);
            //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names");
            foreach (DataRow dr in dt.Rows)
            {
                localconnection.Add(dr["Name"].ToString());
                MessageBox.Show(dr["Name"].ToString());
            }
            return localconnection;
        }
        #endregion

        #region CustomerMessage
        public static void CustomerMessage(string price, string total, messageType msgType)
        {

            string str = string.Empty;

            try
            {
                string portName = System.Configuration.ConfigurationManager.AppSettings["COMPort"].ToString();
                if (GeneralOptionSetting.FlagUseCustomerDisplay == "Y" && portName != string.Empty)
                {
                    SerialPort sp = new SerialPort();
                    sp.PortName = portName;
                    sp.BaudRate = 9600;
                    sp.Parity = Parity.None;
                    sp.DataBits = 8;
                    sp.StopBits = StopBits.One;
                    sp.Open();

                    switch (msgType)
                    {
                        case messageType.sale:
                            string strPrice, strTotal;
                            strPrice = "  Price : " + price;
                            strTotal = "  Total : " + total;
                            str = strTotal.PadRight(20, ' ') + strPrice.PadRight(20, ' ');
                            break;
                        case messageType.custom:

                            if (GeneralOptionSetting.FlagFirstLineWelcomeNote != string.Empty)
                            {
                                str = GeneralOptionSetting.FlagSecondLineWelcomeNote.PadRight(20, ' ') + GeneralOptionSetting.FlagFirstLineWelcomeNote.PadRight(20, ' ');
                            }
                            else
                            {
                                str = string.Empty.PadRight(20, ' ') + GeneralOptionSetting.FlagSecondLineWelcomeNote.PadRight(20, ' ');
                            }

                            break;
                        case messageType.empty:
                            str = string.Empty.PadRight(40, ' ');
                            break;
                    }

                    sp.WriteLine(((char)12).ToString());
                    sp.WriteLine(str);
                    sp.Close();
                    sp.Dispose();
                    sp = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Customer Display :" + ex.Message, "CustomerMessage Function", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "CustomerMessage Function", "CustomerMessage()");
            }
        }
        #endregion






        #region GetOptionDatas
        //New function for getting option details from SP done by Praba on 12-Jan
        public static DataTable GetOptionDetails(int UserGroupID)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@UserGroupID", UserGroupID);
                Dt = ExecuteQueryDatatable(SPNameUSP_GetOptionDtl, sqlparam, "OptionDtl");
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //New function for getting Company Logo from SP done by Praba on 12-Jan
        public static DataTable GetHeaderFooterLogo()
        {
            DataTable Dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[0];
            try
            {
                Dt = ExecuteQueryDatatable(SPNameUSP_CompLogo, sqlparam, "CompLogo");
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetOptionDatas()
        {
            DataTable data_dtOption = new DataTable();
            try
            {

                DataTable dtlogo = new DataTable();
                SqlParameter[] param = new SqlParameter[0];

                // data_dtOption = LoadOptions(UserGroupID);
                data_dtOption = GetOptionDetails(UserGroupID);

                // dtlogo = LoadLogo();

                dtlogo = GetHeaderFooterLogo();

                //List<ItemCardObjectClass> lst = new List();
                //  data_dtOption = sqlcon.ExecuteQueryDatatable(SPNameGetOptionDetails, param, "MTB_OPTIONS");
                //  dtlogo = sqlcon.ExecuteQueryDatatable(SPNameGetLogo, param, "Logo");
                byte[] _byte = new byte[1];
                _byte[0] = 0;
                if (dtlogo.Rows.Count > 0)
                {
                    GeneralOptionSetting.HeaderLogo = dtlogo.Rows[0]["HeaderLogo"] != DBNull.Value ? (byte[])dtlogo.Rows[0]["HeaderLogo"] : _byte;
                    GeneralOptionSetting.FooterLogo = dtlogo.Rows[0]["FooterLogo"] != DBNull.Value ? (byte[])dtlogo.Rows[0]["FooterLogo"] : _byte;
                }
                else
                {
                    GeneralOptionSetting.HeaderLogo = _byte;
                    GeneralOptionSetting.FooterLogo = _byte;
                }

                //********** public option settings *******************************************************

                if (data_dtOption.Rows.Count > 0)
                {
                    //----------General-----------------------------
                    GeneralOptionSetting.FlagCompanyName = data_dtOption.Rows[0][3].ToString();
                    GeneralOptionSetting.FlagPhone = data_dtOption.Rows[1][3].ToString();
                    GeneralOptionSetting.FlagCell = data_dtOption.Rows[2][3].ToString();
                    GeneralOptionSetting.FlagFax = data_dtOption.Rows[3][3].ToString();
                    GeneralOptionSetting.FlagPOBox = data_dtOption.Rows[4][3].ToString();
                    GeneralOptionSetting.FlagEmail = data_dtOption.Rows[5][3].ToString();
                    GeneralOptionSetting.FlagAddress = data_dtOption.Rows[6][3].ToString();
                    GeneralOptionSetting.FlagSystemNote = data_dtOption.Rows[7][3].ToString();
                    GeneralOptionSetting.FlagWorkNote = data_dtOption.Rows[8][3].ToString();
                    GeneralOptionSetting.FlagLangage = data_dtOption.Rows[9][3].ToString();
                    GeneralOptionSetting.FlagHideDiscountWindow = data_dtOption.Rows[10][3].ToString();
                    GeneralOptionSetting.FlagHideWelcomeWindow = data_dtOption.Rows[11][3].ToString();
                    GeneralOptionSetting.FlagHideNoteFiled = data_dtOption.Rows[12][3].ToString();
                    GeneralOptionSetting.FlagHideRentingInvoice = data_dtOption.Rows[13][3].ToString();
                    GeneralOptionSetting.FlagShowCompanyOnInvoice = data_dtOption.Rows[14][3].ToString();
                    GeneralOptionSetting.FlagHideKitchenWindow = data_dtOption.Rows[15][3].ToString();
                    GeneralOptionSetting.FlagShowCompanyNameOnly = data_dtOption.Rows[16][3].ToString();
                    GeneralOptionSetting.FlagAutoStartwithWindow = data_dtOption.Rows[17][3].ToString();
                    GeneralOptionSetting.FlagDateFormat = data_dtOption.Rows[177][3].ToString(); //Added on 28-May-2014 

                    //--------Invoice----------------------------
                    GeneralOptionSetting.FlagPurchase_HideExpiryFiled = data_dtOption.Rows[18][3].ToString();
                    GeneralOptionSetting.FlagPurchase_HideDevidingDiscountOnItem = data_dtOption.Rows[19][3].ToString();
                    GeneralOptionSetting.FlagPurchase_AddItemDirectlywithBarcode = data_dtOption.Rows[20][3].ToString();
                    GeneralOptionSetting.FlagTabToPrice = data_dtOption.Rows[21][3].ToString();
                    GeneralOptionSetting.FlagShowDiscountFiled = data_dtOption.Rows[22][3].ToString();
                    GeneralOptionSetting.FlagShowHidenItem = data_dtOption.Rows[23][3].ToString();
                    GeneralOptionSetting.FlagPurchase_SaveUsernameOnInvoice = data_dtOption.Rows[24][3].ToString();
                    GeneralOptionSetting.FlagHidePriceChangingButton = data_dtOption.Rows[25][3].ToString();
                    GeneralOptionSetting.FlagSalePriceReadonly = data_dtOption.Rows[26][3].ToString();
                    GeneralOptionSetting.FlagSale_AddItemDirectlywithBarcode = data_dtOption.Rows[27][3].ToString();
                    GeneralOptionSetting.FlagOpenInvioceAfterClosing = data_dtOption.Rows[28][3].ToString();
                    GeneralOptionSetting.FlagSale_HideExpiryFiled = data_dtOption.Rows[29][3].ToString();
                    GeneralOptionSetting.FlagDevideDiscountBeforeClosingInvoice = data_dtOption.Rows[30][3].ToString();
                    GeneralOptionSetting.FlagAlterwhenSellingLessthanCost = data_dtOption.Rows[31][3].ToString();
                    GeneralOptionSetting.FlagShowSubTotalFiled = data_dtOption.Rows[32][3].ToString();
                    GeneralOptionSetting.FlagShowNonStockItem = data_dtOption.Rows[33][3].ToString();
                    GeneralOptionSetting.FlagSale_SaveUsernameOnInvoice = data_dtOption.Rows[34][3].ToString();
                    GeneralOptionSetting.FlagShowInvoiceCostFiled = data_dtOption.Rows[35][3].ToString();
                    GeneralOptionSetting.FlagDisableDiscountFiled = data_dtOption.Rows[36][3].ToString();
                    GeneralOptionSetting.FlagSale_HideDevidingDiscountOnItem = data_dtOption.Rows[37][3].ToString();
                    GeneralOptionSetting.FlagSale_InsertItemIndividually = data_dtOption.Rows[175][3].ToString();
                    GeneralOptionSetting.FlagPurchase_HideImportExport = data_dtOption.Rows[178][3].ToString();
                    GeneralOptionSetting.FlagPurchase_DontUseExpiry = data_dtOption.Rows[179][3].ToString();
                    GeneralOptionSetting.FlagSale_DontUseExpiry = data_dtOption.Rows[180][3].ToString();
                    //--------Print-----------------------
                    GeneralOptionSetting.FlagInvoiceTemplate = data_dtOption.Rows[38][3].ToString();
                    GeneralOptionSetting.FlagBarcodePaperSize = data_dtOption.Rows[39][3].ToString();
                    GeneralOptionSetting.FlagBarcodePrinter = data_dtOption.Rows[40][3].ToString();
                    GeneralOptionSetting.FlagPrintingLogo = data_dtOption.Rows[41][3].ToString();
                    GeneralOptionSetting.FlagItemSorting = data_dtOption.Rows[42][3].ToString();
                    GeneralOptionSetting.FlagInvoiceCopies = data_dtOption.Rows[43][3].ToString();
                    GeneralOptionSetting.FlagReciptCopies = data_dtOption.Rows[44][3].ToString();
                    GeneralOptionSetting.FlagHeader = data_dtOption.Rows[45][3].ToString();
                    GeneralOptionSetting.FlagFooter = data_dtOption.Rows[46][3].ToString();
                    GeneralOptionSetting.FlagLogoHeader = data_dtOption.Rows[47][3].ToString();
                    GeneralOptionSetting.FlagLogoFooter = data_dtOption.Rows[48][3].ToString();
                    GeneralOptionSetting.FlagNoteSaleInvoice = data_dtOption.Rows[49][3].ToString();
                    GeneralOptionSetting.FlagPrintAfterClosingInvoice = data_dtOption.Rows[50][3].ToString();
                    GeneralOptionSetting.FlagPrintAfterClosingRecipt = data_dtOption.Rows[51][3].ToString();
                    GeneralOptionSetting.FlagPrintTotalQuantity = data_dtOption.Rows[52][3].ToString();
                    GeneralOptionSetting.FlagHideDiscountFiledOnPrint = data_dtOption.Rows[53][3].ToString();
                    GeneralOptionSetting.FlagShowTime = data_dtOption.Rows[54][3].ToString();
                    GeneralOptionSetting.FlagHideTaxFiled = data_dtOption.Rows[55][3].ToString();
                    GeneralOptionSetting.FlagHideLogoOnPrint = data_dtOption.Rows[56][3].ToString();
                    GeneralOptionSetting.FlagShowDeptOnPrint = data_dtOption.Rows[57][3].ToString();
                    GeneralOptionSetting.FlagIgnoreNonStockItem = data_dtOption.Rows[58][3].ToString();
                    GeneralOptionSetting.FlagPosCategoryVicePrint = data_dtOption.Rows[174][3].ToString();
                    GeneralOptionSetting.FlagHidePeaceBoxOnPrint = data_dtOption.Rows[189][3].ToString();

                    //--------Item-----------------------
                    GeneralOptionSetting.FlagAlertExpiry = data_dtOption.Rows[59][3].ToString();
                    GeneralOptionSetting.FlagAlertReorderItem = data_dtOption.Rows[60][3].ToString();
                    GeneralOptionSetting.FlagIssueOrderInvoice = data_dtOption.Rows[61][3].ToString();
                    GeneralOptionSetting.FlagAlertForReorders = data_dtOption.Rows[62][3].ToString();
                    GeneralOptionSetting.FlagDontIssueReorderInvoice = data_dtOption.Rows[63][3].ToString();
                    GeneralOptionSetting.FlagHideItemSaleTimeInInvoice = data_dtOption.Rows[64][3].ToString();
                    GeneralOptionSetting.FlagHideItemCostInSales = data_dtOption.Rows[65][3].ToString();
                    GeneralOptionSetting.FlagHideItemNumber = data_dtOption.Rows[66][3].ToString();
                    GeneralOptionSetting.FlagDontTabToReorderandMaxpoint = data_dtOption.Rows[67][3].ToString();
                    GeneralOptionSetting.FlagDontAlertForExpiryInNotes = data_dtOption.Rows[68][3].ToString();
                    GeneralOptionSetting.FlagQuitWithoutAsking = data_dtOption.Rows[69][3].ToString();
                    GeneralOptionSetting.FlagSellExpiryWenNotEnough = data_dtOption.Rows[70][3].ToString();
                    GeneralOptionSetting.FlagAlertForMultiExpiry = data_dtOption.Rows[71][3].ToString();
                    GeneralOptionSetting.FlagUseExpiryDefaultInItemCard = data_dtOption.Rows[72][3].ToString();
                    GeneralOptionSetting.FlagHidePackageQuantity = data_dtOption.Rows[73][3].ToString();
                    GeneralOptionSetting.FlagMonitorReorderAndMaxpoint = data_dtOption.Rows[74][3].ToString();
                    GeneralOptionSetting.FlagCHKAutoPriceItem = data_dtOption.Rows[183][3].ToString();
                    GeneralOptionSetting.FlagTxtAutoPriceItem = data_dtOption.Rows[184][3].ToString();
                    //GeneralOptionSetting.FlagTxtAutoPriceItem = data_dtOption.Rows[184][3].ToString();
                    GeneralOptionSetting.FlagtxtPaymentPercentageCheck = data_dtOption.Rows[185][3].ToString();
                    GeneralOptionSetting.FlagchkActivatePaymentType = data_dtOption.Rows[186][3].ToString();
                    GeneralOptionSetting.FlagtxtPaymentPercentageCard = data_dtOption.Rows[187][3].ToString();

                    //--------Employee-----------------------
                    //GeneralOptionSetting.FlagCalculateSalary = data_dtOption.Rows[75][2].ToString();
                    //GeneralOptionSetting.FlagHoliday = data_dtOption.Rows[76][2].ToString();
                    //GeneralOptionSetting.FlagCalculateSalaryFromStartDay = data_dtOption.Rows[77][2].ToString();
                    //GeneralOptionSetting.FlagCutLatencyAutomatically = data_dtOption.Rows[78][2].ToString();
                    //GeneralOptionSetting.FlagCountSalaryFromRegistrationPoint = data_dtOption.Rows[79][2].ToString();
                    //GeneralOptionSetting.FlagCutDeficits = data_dtOption.Rows[80][2].ToString();
                    //GeneralOptionSetting.FlagTrackUsers = data_dtOption.Rows[81][2].ToString();
                    //GeneralOptionSetting.FlagCountSystemStarupMinutes = data_dtOption.Rows[82][2].ToString();
                    //GeneralOptionSetting.FlagCountOverTimeAutomatically = data_dtOption.Rows[83][2].ToString();
                    //GeneralOptionSetting.FlagCountOverTimeForHolidays = data_dtOption.Rows[84][2].ToString();
                    //GeneralOptionSetting.FlagStopEmployeeCalculations = data_dtOption.Rows[85][2].ToString();

                    //--------Backup-----------------------
                    GeneralOptionSetting.FlagAskWhenLeavingSystem = data_dtOption.Rows[86][3].ToString();
                    GeneralOptionSetting.FlagAutomaticBackupWhenClosing = data_dtOption.Rows[87][3].ToString();
                    GeneralOptionSetting.FlagAskWhenReplacingFile = data_dtOption.Rows[88][3].ToString();
                    GeneralOptionSetting.FlagSaveAutomaticBackupInAlternativePath = data_dtOption.Rows[89][3].ToString();
                    GeneralOptionSetting.FlagSaveFilenameWithDatetime = data_dtOption.Rows[90][3].ToString();
                    GeneralOptionSetting.FlagAlertWhenNotMakingBackup = data_dtOption.Rows[91][3].ToString();
                    GeneralOptionSetting.FlagAutomaticBackupDays = data_dtOption.Rows[92][3].ToString();
                    GeneralOptionSetting.FlagSaveBackup = data_dtOption.Rows[93][3].ToString();
                    GeneralOptionSetting.FlagAlternativePath = data_dtOption.Rows[94][3].ToString();
                    GeneralOptionSetting.FlagLastBackupDate = data_dtOption.Rows[95][3].ToString();

                    //--------Peripherals-----------------------
                    GeneralOptionSetting.FlagUseCustomerDisplay = data_dtOption.Rows[96][3].ToString();
                    GeneralOptionSetting.FlagFirstLineWelcomeNote = data_dtOption.Rows[97][3].ToString();
                    GeneralOptionSetting.FlagSecondLineWelcomeNote = data_dtOption.Rows[98][3].ToString();
                    GeneralOptionSetting.FlagUseCashDrawer = data_dtOption.Rows[99][3].ToString();
                    GeneralOptionSetting.FlagDrawerTypeUSP = data_dtOption.Rows[100][3].ToString();
                    GeneralOptionSetting.FlagDrawerTypeCOM = data_dtOption.Rows[101][3].ToString();
                    GeneralOptionSetting.FlagDrawerTypeRJ11 = data_dtOption.Rows[102][3].ToString();
                    GeneralOptionSetting.FlagDrawerOpenDirectlyAfterPrint = data_dtOption.Rows[103][3].ToString();
                    GeneralOptionSetting.FlagDrawerProtectWithPassword = data_dtOption.Rows[104][3].ToString();
                    GeneralOptionSetting.FlagCashDrawerPassword = data_dtOption.Rows[105][3].ToString();
                    GeneralOptionSetting.FlagCashDrawerVerifyPassword = data_dtOption.Rows[106][3].ToString();
                    GeneralOptionSetting.FlagPriceChecker = data_dtOption.Rows[199][3].ToString();

                    //--------Tax-----------------------
                    GeneralOptionSetting.FlagTax1_TaxName = data_dtOption.Rows[107][3].ToString();
                    GeneralOptionSetting.FlagTax1_Percentage = data_dtOption.Rows[108][3].ToString();
                    GeneralOptionSetting.FlagTax1_SubPercentage = data_dtOption.Rows[109][3].ToString();
                    GeneralOptionSetting.FlagTax1_ShowTaxInvoice = data_dtOption.Rows[110][3].ToString();
                    GeneralOptionSetting.FlagTax1_ApplySales = data_dtOption.Rows[111][3].ToString();
                    GeneralOptionSetting.FlagTax1_ApplyPurchase = data_dtOption.Rows[112][3].ToString();
                    GeneralOptionSetting.FlagTax1_ApplyMaintains = data_dtOption.Rows[113][3].ToString();
                    GeneralOptionSetting.FlagTax1_ApplyBeforeDiscount = data_dtOption.Rows[114][3].ToString();
                    GeneralOptionSetting.FlagTax2_TaxName = data_dtOption.Rows[115][3].ToString();
                    GeneralOptionSetting.FlagTax2_Percentage = data_dtOption.Rows[116][3].ToString();
                    GeneralOptionSetting.FlagTax2_SubPercentage = data_dtOption.Rows[117][3].ToString();
                    GeneralOptionSetting.FlagTax2_ShowTaxInvoice = data_dtOption.Rows[118][3].ToString();
                    GeneralOptionSetting.FlagTax2_ApplySales = data_dtOption.Rows[119][3].ToString();
                    GeneralOptionSetting.FlagTax2_ApplyPurchase = data_dtOption.Rows[120][3].ToString();
                    GeneralOptionSetting.FlagTax2_ApplyMaintains = data_dtOption.Rows[121][3].ToString();
                    GeneralOptionSetting.FlagTax2_ApplyBeforeDiscount = data_dtOption.Rows[122][3].ToString();

                    #region -Notification code-
                    //--------Notification-----------------------
                    GeneralOptionSetting.FlagLicenserenewal = data_dtOption.Rows[123][3].ToString();
                    if (data_dtOption.Rows[124][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagLicenserenewalDate = Convert.ToDateTime(data_dtOption.Rows[124][3].ToString());
                    }
                    if (data_dtOption.Rows[125][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagLicenserenewalNotifyBefore = Convert.ToInt32(data_dtOption.Rows[125][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagLicenserenewalNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagMedicalInsurance = data_dtOption.Rows[126][3].ToString();
                    if (data_dtOption.Rows[127][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagMedicalInsuranceDate = Convert.ToDateTime(data_dtOption.Rows[127][3].ToString());
                    }
                    if (data_dtOption.Rows[128][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagMedicalInsuranceNotifyBefore = Convert.ToInt32(data_dtOption.Rows[128][3].ToString());
                    }
                    ////////////////Seenu//////
                    else
                    {
                        GeneralOptionSetting.FlagMedicalInsuranceNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagCertificateofHealth = data_dtOption.Rows[129][3].ToString();
                    if (data_dtOption.Rows[130][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagCertificateofHealthDate = Convert.ToDateTime(data_dtOption.Rows[130][3].ToString());
                    }
                    if (data_dtOption.Rows[131][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagCertificateofHealthNotifyBefore = Convert.ToInt32(data_dtOption.Rows[131][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagCertificateofHealthNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagAttendancePermit = data_dtOption.Rows[132][3].ToString();
                    if (data_dtOption.Rows[133][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagAttendancePermitDate = Convert.ToDateTime(data_dtOption.Rows[133][3].ToString());
                    }
                    if (data_dtOption.Rows[134][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagAttendancePermitNotifyBefore = Convert.ToInt32(data_dtOption.Rows[134][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagAttendancePermitNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagTechnicalDisclosure = data_dtOption.Rows[135][3].ToString();
                    if (data_dtOption.Rows[136][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagTechnicalDisclosureDate = Convert.ToDateTime(data_dtOption.Rows[136][3].ToString());
                    }
                    if (data_dtOption.Rows[137][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagTechnicalDisclosureNotifyBefore = Convert.ToInt32(data_dtOption.Rows[137][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagTechnicalDisclosureNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagPricing = data_dtOption.Rows[138][3].ToString();
                    if (data_dtOption.Rows[139][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagPricingDate = Convert.ToDateTime(data_dtOption.Rows[139][3].ToString());
                    }
                    if (data_dtOption.Rows[140][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagPricingNotifyBefore = Convert.ToInt32(data_dtOption.Rows[140][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagPricingNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagPayrent = data_dtOption.Rows[141][3].ToString();
                    if (data_dtOption.Rows[142][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagPayrentDate = Convert.ToDateTime(data_dtOption.Rows[142][3].ToString());
                    }
                    if (data_dtOption.Rows[143][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagPayrentNotifyBefore = Convert.ToInt32(data_dtOption.Rows[143][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagPayrentNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagDisbursementSalary = data_dtOption.Rows[144][3].ToString();
                    if (data_dtOption.Rows[145][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagDisbursementSalaryDate = Convert.ToDateTime(data_dtOption.Rows[145][3].ToString());
                    }
                    if (data_dtOption.Rows[146][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagDisbursementSalaryNotifyBefore = Convert.ToInt32(data_dtOption.Rows[146][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagDisbursementSalaryNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagAnnualInventory = data_dtOption.Rows[147][3].ToString();
                    if (data_dtOption.Rows[148][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagAnnualInventoryDate = Convert.ToDateTime(data_dtOption.Rows[148][3].ToString());
                    }
                    if (data_dtOption.Rows[149][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagAnnualInventoryNotifyBefore = Convert.ToInt32(data_dtOption.Rows[149][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagAnnualInventoryNotifyBefore = 0;
                    }
                    GeneralOptionSetting.FlagZakat = data_dtOption.Rows[150][3].ToString();
                    if (data_dtOption.Rows[151][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagZakatDate = Convert.ToDateTime(data_dtOption.Rows[151][3].ToString());
                    }
                    if (data_dtOption.Rows[152][3].ToString() != "")
                    {
                        GeneralOptionSetting.FlagZakatNotifyBefore = Convert.ToInt32(data_dtOption.Rows[152][3].ToString());
                    }
                    else
                    {
                        GeneralOptionSetting.FlagZakatNotifyBefore = 0;
                    }
                    #endregion

                    //--------Others-----------------------


                    GeneralOptionSetting.FlagDontAskClosingSystem = data_dtOption.Rows[153][3].ToString();
                    GeneralOptionSetting.Flag24HourWorkSystem = data_dtOption.Rows[154][3].ToString();
                    GeneralOptionSetting.FlagStopDeptSellings = data_dtOption.Rows[155][3].ToString();
                    GeneralOptionSetting.FlagHidePackageReport = data_dtOption.Rows[156][3].ToString();
                    GeneralOptionSetting.FlagShowTipDayWhenStart = data_dtOption.Rows[157][3].ToString();
                    GeneralOptionSetting.FlagBranchBuyswithCost = data_dtOption.Rows[158][3].ToString();
                    GeneralOptionSetting.FlagUseItemPhoto = data_dtOption.Rows[159][3].ToString();
                    GeneralOptionSetting.FlagUseRentingInvoice = data_dtOption.Rows[160][3].ToString();
                    GeneralOptionSetting.FlagDontAlertOnSave = data_dtOption.Rows[161][3].ToString();
                    GeneralOptionSetting.FlagDontAlertDeleteItemFromInvoice = data_dtOption.Rows[162][3].ToString();
                    GeneralOptionSetting.FlagUnifyOptionForallWorkStations = data_dtOption.Rows[163][3].ToString();
                    GeneralOptionSetting.FlagRoundPriceOnDiscount = data_dtOption.Rows[164][3].ToString();
                    GeneralOptionSetting.FlagRoundPricesOnDiscountValue = data_dtOption.Rows[165][3].ToString();
                    GeneralOptionSetting.FlagAlertReorderItemsPerDay = data_dtOption.Rows[166][3].ToString();
                    GeneralOptionSetting.FlagAlertExpiryPerDay = data_dtOption.Rows[167][3].ToString();
                    GeneralOptionSetting.FlagAlertPayDatesBefore = data_dtOption.Rows[168][3].ToString();
                    GeneralOptionSetting.FlagAlertPayDates = data_dtOption.Rows[169][3].ToString();
                    GeneralOptionSetting.FlagAlertWithSound = data_dtOption.Rows[170][3].ToString();
                    GeneralOptionSetting.FlagAlertSaleInvoice = data_dtOption.Rows[171][3].ToString();
                    GeneralOptionSetting.FlagHidePOSShortcut = data_dtOption.Rows[172][3].ToString();
                    GeneralOptionSetting.FlagHidePOSScreen = data_dtOption.Rows[173][3].ToString();
                    GeneralOptionSetting.FlagSale_HidePaidRefund = data_dtOption.Rows[176][3].ToString();
                    GeneralOptionSetting.FlagResetPOSOrder = data_dtOption.Rows[181][3].ToString();
                    GeneralOptionSetting.FlagPOSOrderResetCount = data_dtOption.Rows[182][3].ToString();
                    // Added on 13-Mar-2019 By T
                    GeneralOptionSetting.FlagEnableNetworkSaleControl = data_dtOption.Rows[188][3].ToString();
                    GeneralOptionSetting.FlagConfirmEndShift = data_dtOption.Rows[190][3].ToString();
                    GeneralOptionSetting.FlagOpenNewInvoice = data_dtOption.Rows[197][3].ToString();

                    GeneralOptionSetting.FlagPrinterDefault = data_dtOption.Rows[191][3].ToString();
                    GeneralOptionSetting.FlagPrinterInvoice = data_dtOption.Rows[192][3].ToString();
                    GeneralOptionSetting.FlagPrinterReport = data_dtOption.Rows[193][3].ToString();
                    GeneralOptionSetting.FlagPrinterPOS = data_dtOption.Rows[194][3].ToString();
                    GeneralOptionSetting.FlagPrinterReceipt = data_dtOption.Rows[195][3].ToString();
                    GeneralOptionSetting.FlagPrinterBarcode = data_dtOption.Rows[196][3].ToString();

                    GeneralOptionSetting.FlagBarcodeSize = data_dtOption.Rows[198][3].ToString();
                }


                //GeneralFunction.Trace("MakeNotificationArrayList Start");
                MakeNotificationArrayList();
                //GeneralFunction.Trace("MakeNotificationArrayList End");
                //*******************************************************************************************


            }
            catch (Exception ex) { GeneralOptionSetting.FlagMedicalInsuranceDate = DateTime.Now.Date; GeneralFunction.Errorlogfile(ex.Message, GeneralFunction.UserId, "GeneralFunction", "GetOptionDatas"); }
            return data_dtOption;
        }
        #endregion

        #region MakeNotificationArrayList
        private static void MakeNotificationArrayList()
        {
            string str1, str2, str3, str4, str5, str6, str7, str8, str9, str10 = "";
            try
            {
                // ArrayList NotifyNotes = new ArrayList();
                //GeneralFunction.Trace("Notes Start");
                Notes.Clear();
                OnlyNotes.Clear();
                #region MyRegion
                if (GeneralOptionSetting.FlagLicenserenewal == "Y")
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagLicenserenewalDate;
                    int FlagDay = GeneralOptionSetting.FlagLicenserenewalNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            if (GeneralFunction.Language == "English")
                            { str1 = "License Renewal  :" + FlagDate.ToShortDateString(); }
                            else
                            { str1 = "تجديد الترخيص :" + FlagDate.ToShortDateString(); }
                            Notes.Add(str1);
                            OnlyNotes.Add(str1);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If1");

                if (GeneralOptionSetting.FlagMedicalInsurance == "Y")
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagMedicalInsuranceDate;
                    int FlagDay = GeneralOptionSetting.FlagMedicalInsuranceNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            if (GeneralFunction.Language == "English")
                            { str2 = "Medical Insurance  :" + FlagDate.ToShortDateString(); }
                            else
                            { str2 = "تجديد التأمين الطبي :" + FlagDate.ToShortDateString(); }

                            Notes.Add(str2);
                            OnlyNotes.Add(str2);
                        }
                    }
                }

                //GeneralFunction.Trace("Notes If2");

                if (GeneralOptionSetting.FlagCertificateofHealth == "Y")
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagCertificateofHealthDate;
                    int FlagDay = GeneralOptionSetting.FlagCertificateofHealthNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            if (GeneralFunction.Language == "English")
                            { str3 = "Certificate of Health  :" + FlagDate.ToShortDateString(); }
                            else
                            { str3 = "تجديد الشهادة الصحية  :" + FlagDate.ToShortDateString(); }

                            Notes.Add(str3);
                            OnlyNotes.Add(str3);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If3");
                if (GeneralOptionSetting.FlagAttendancePermit == "Y")
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagAttendancePermitDate;
                    int FlagDay = GeneralOptionSetting.FlagAttendancePermitNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            if (GeneralFunction.Language == "English")
                            { str4 = "Attendance Permit  :" + FlagDate.ToShortDateString(); }
                            else
                            { str4 = "تجديد اذن المزاولة :" + FlagDate.ToShortDateString(); }

                            Notes.Add(str4);
                            OnlyNotes.Add(str4);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If4");
                if (GeneralOptionSetting.FlagTechnicalDisclosure.Contains("Y/"))
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagTechnicalDisclosureDate;
                    int FlagDay = GeneralOptionSetting.FlagTechnicalDisclosureNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            string strget1 = GeneralOptionSetting.FlagTechnicalDisclosure.Remove(0, 2);
                            str5 = "" + strget1 + "  :" + FlagDate.ToShortDateString();
                            Notes.Add(str5);
                            OnlyNotes.Add(str5);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If5");
                if (GeneralOptionSetting.FlagPricing.Contains("Y/"))
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagPricingDate;
                    int FlagDay = GeneralOptionSetting.FlagPricingNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            string strget2 = GeneralOptionSetting.FlagPricing.Remove(0, 2);
                            str6 = "" + strget2 + "  :" + FlagDate.ToShortDateString();
                            Notes.Add(str6);
                            OnlyNotes.Add(str6);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If6");
                if (GeneralOptionSetting.FlagPayrent.Contains("Y/"))
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagPayrentDate;
                    int FlagDay = GeneralOptionSetting.FlagPayrentNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            string strget3 = GeneralOptionSetting.FlagPayrent.Remove(0, 2);
                            str7 = "" + strget3 + "  :" + FlagDate.ToShortDateString();
                            Notes.Add(str7);
                            OnlyNotes.Add(str7);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If7");
                if (GeneralOptionSetting.FlagDisbursementSalary.Contains("Y/"))
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagDisbursementSalaryDate;
                    int FlagDay = GeneralOptionSetting.FlagDisbursementSalaryNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            string strget4 = GeneralOptionSetting.FlagDisbursementSalary.Remove(0, 2);
                            str8 = "" + strget4 + "  :" + FlagDate.ToShortDateString();
                            Notes.Add(str8);
                            OnlyNotes.Add(str8);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If8");
                if (GeneralOptionSetting.FlagAnnualInventory.Contains("Y/"))
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagAnnualInventoryDate;
                    int FlagDay = GeneralOptionSetting.FlagAnnualInventoryNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            string strget5 = GeneralOptionSetting.FlagAnnualInventory.Remove(0, 2);
                            str9 = "" + strget5 + " :" + FlagDate.ToShortDateString();
                            Notes.Add(str9);
                            OnlyNotes.Add(str9);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If9");
                if (GeneralOptionSetting.FlagZakat == "Y")
                {
                    DateTime FlagDate = GeneralOptionSetting.FlagZakatDate;
                    int FlagDay = GeneralOptionSetting.FlagZakatNotifyBefore;
                    if (DateTime.Now.Date <= FlagDate.Date)
                    {
                        TimeSpan diff;
                        diff = FlagDate - DateTime.Now;
                        if (FlagDay >= diff.Days)
                        {
                            if (GeneralFunction.Language == "English")
                            { str10 = "Zakat  :" + FlagDate.ToShortDateString(); }
                            else
                            { str10 = "موعد دفع الزكاة :" + FlagDate.ToShortDateString(); }

                            Notes.Add(str10);
                            OnlyNotes.Add(str10);
                        }
                    }
                }
                //GeneralFunction.Trace("Notes If10");
                #endregion


                //--------------Others tab notes area---------------------

                //DataSet dtabMSG = new DataSet();
                //DataTable dtab1 = new DataTable();
                //DataTable dtab2 = new DataTable();
                //DataTable dtab3 = new DataTable();

                //if (GeneralOptionSetting.FlagAlertPayDates == "Y")
                //{
                //    int FlagDay = Convert.ToInt16(GeneralOptionSetting.FlagAlertPayDatesBefore);
                //    DateTime BeforDate = DateTime.Now.AddDays(-FlagDay);
                //    int ExpMnth = Convert.ToInt16(GeneralOptionSetting.FlagAlertExpiry);
                //    DateTime ExpiryDate = DateTime.Now.AddMonths(ExpMnth);

                //    SqlParameter[] param = new SqlParameter[3];
                //    param[0] = new SqlParameter("@FromDate", BeforDate);
                //    param[1] = new SqlParameter("@ToDate", DateTime.Now);
                //    param[2] = new SqlParameter("@ExpiryDate", ExpiryDate);

                //    dtabMSG = ExecuteQueryDataset(SPNameGetOptionAlertMessage, param, "OptionMsg");

                //    if (dtabMSG.Tables.Count > 0)
                //    {
                //        dtab1 = dtabMSG.Tables[0];
                //        // dtab2 = dtabMSG.Tables[1];
                //        if (dtab1.Rows.Count > 0)
                //        {
                //            OnlyPayDates.Clear();

                //            // if (strLanguage.ToString() == "English") //Commented on 27-Oct-2014
                //            if (GeneralFunction.Language == "English") //Added on 27-Oct-2014
                //            {
                //                OnlyPayDates.Add("Today Payment Date For");
                //            }
                //            else
                //            {
                //                OnlyPayDates.Add("مواعيد الدفع لهذا اليوم لكل من");
                //            }

                //            for (int g = 0; g < dtab1.Rows.Count; g++)
                //            {
                //                Notes.Add(dtab1.Rows[g]["Message"].ToString());
                //                OnlyPayDates.Add(dtab1.Rows[g]["Message"].ToString());
                //            }

                //            // NotesInVisible = "YES";
                //        }
                //    }
                //}
                //GeneralFunction.Trace("Notes If11");
                //// int discunt= Convert.ToInt16(GeneralOptionSetting.FlagAlertReorderItemsPerDay);

                //// if (discunt >= GeneralOptionSetting.ReorderItemsDisplayCount)
                ////  {
                //if (GeneralOptionSetting.FlagAlertForReorders == "Y")
                //{
                //    if (dtabMSG.Tables.Count > 0)
                //    {
                //        dtab2 = dtabMSG.Tables[1];

                //        if (dtab2.Rows.Count > 0)
                //        {
                //            OnlyReorder.Clear();
                //            if (strLanguage.ToString() == "English")
                //            {
                //                OnlyReorder.Add("You have items   ");
                //                OnlyReorder.Add("need to be Reordered");
                //            }
                //            else
                //            {
                //                OnlyReorder.Add("لديك اصناف يجب");
                //                OnlyReorder.Add(" اعادة طلبها و توفيرها");
                //            }
                //            //OnlyReorder.Add("Reorder Items:");
                //            //for (int g = 0;g < dtab2.Rows.Count; g++)
                //            //{
                //            //    Notes.Add(dtab2.Rows[g]["Message"].ToString());
                //            //    OnlyReorder.Add(dtab2.Rows[g]["Message"].ToString());
                //            //}
                //        }
                //    }
                //}
                //GeneralFunction.Trace("Notes If12");
                //// }

                ////  int discuntExp = Convert.ToInt16(GeneralOptionSetting.FlagAlertExpiryPerDay);

                //// if (discuntExp >= GeneralOptionSetting.ExpiryDisplayCount)
                //// {                     
                //if (dtabMSG.Tables.Count > 0)
                //{
                //    dtab3 = dtabMSG.Tables[2];

                //    if (dtab3.Rows.Count > 0)
                //    {
                //        OnlyExpiryDate.Clear();
                //        //if (strLanguage.ToString() == "English")
                //        //{
                //        //    OnlyExpiryDate.Add("You have items will Expire on ");

                //        //}
                //        //else
                //        //{

                //        //    OnlyExpiryDate.Add("اصناف ستنتهي صلاحيتها في");
                //        //}
                //        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                //            OnlyExpiryDate.Add("You have items will Expire on ");
                //        else
                //            OnlyExpiryDate.Add("اصناف ستنتهي صلاحيتها في");
                //        for (int g = 0; g < dtab3.Rows.Count; g++)
                //        {
                //            string[] ExpSplit = dtab3.Rows[g]["Message"].ToString().Split(':');
                //            Notes.Add(ExpSplit[0].ToString());
                //            Notes.Add(ExpSplit[1].ToString());
                //            //OnlyExpiryDate.Add(ExpSplit[0].ToString());
                //            if (!OnlyExpiryDate.Contains(ExpSplit[1].ToString()))
                //            {
                //                OnlyExpiryDate.Add(ExpSplit[1].ToString());
                //            }
                //        }
                //    }
                //    else
                //        OnlyExpiryDate.Clear();
                //}

                //GeneralFunction.Trace("Notes If13");
                //Added below Message on 28-Oct-2014 by Seenivasan 

                #region Pay Day for Suppliers
                DataSet dsSupplierDay = new DataSet();
                SqlParameter[] paramss = new SqlParameter[1];
                paramss[0] = new SqlParameter("@SaleInvoice", DateTime.Now);
                dsSupplierDay = ExecuteQueryDataset("Sp_GetPayDayForSupplier", paramss, "SuppierDayMsg");
                if (dsSupplierDay.Tables.Count > 0)
                {
                    if (dsSupplierDay.Tables[0].Rows.Count > 0)
                    {
                        OnlyPayDaysForSupplier.Clear();

                        if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        {
                            OnlyPayDaysForSupplier.Add("Today Payment Day For Agents");
                        }
                        else
                        {
                            OnlyPayDaysForSupplier.Add("اليوم موعد الدفع ");
                        }

                        //if (dsSupplierDay.Tables[0].Rows.Count > 5)
                        //{
                        //    Notes.Add("");
                        //    OnlyPayDaysForSupplier.Add(dsSupplierDay.Tables[0].Rows.Count);
                        //}
                        //else
                        //{

                        for (int g = 0; g < dsSupplierDay.Tables[0].Rows.Count; g++)
                        {
                            string ExpSplit = dsSupplierDay.Tables[0].Rows[g]["AgentName"].ToString();
                            if (ExpSplit != "")
                            {
                                Notes.Add(ExpSplit);
                                OnlyPayDaysForSupplier.Add(ExpSplit);
                            }
                        }
                        // }

                    }
                }

                #endregion

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        #endregion

        public static void OtherNotification()
        {

            DataSet dtabMSG = new DataSet();
            DataTable dtab1 = new DataTable();
            DataTable dtab2 = new DataTable();
            DataTable dtab3 = new DataTable();

            if (GeneralOptionSetting.FlagAlertPayDates == "Y")
            {
                int FlagDay = Convert.ToInt16(GeneralOptionSetting.FlagAlertPayDatesBefore);
                DateTime BeforDate = DateTime.Now.AddDays(-FlagDay);
                int ExpMnth = Convert.ToInt16(GeneralOptionSetting.FlagAlertExpiry);
                DateTime ExpiryDate = DateTime.Now.AddMonths(ExpMnth);

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@FromDate", BeforDate);
                param[1] = new SqlParameter("@ToDate", DateTime.Now);
                param[2] = new SqlParameter("@ExpiryDate", ExpiryDate);

                dtabMSG = ExecuteQueryDataset(SPNameGetOptionAlertMessage, param, "OptionMsg");

                if (dtabMSG.Tables.Count > 0)
                {
                    dtab1 = dtabMSG.Tables[0];
                    // dtab2 = dtabMSG.Tables[1];
                    if (dtab1.Rows.Count > 0)
                    {
                        OnlyPayDates.Clear();

                        // if (strLanguage.ToString() == "English") //Commented on 27-Oct-2014
                        if (GeneralFunction.Language == "English") //Added on 27-Oct-2014
                        {
                            OnlyPayDates.Add("Today Payment Date For");
                        }
                        else
                        {
                            OnlyPayDates.Add("مواعيد الدفع لهذا اليوم لكل من");
                        }

                        for (int g = 0; g < dtab1.Rows.Count; g++)
                        {
                            Notes.Add(dtab1.Rows[g]["Message"].ToString());
                            OnlyPayDates.Add(dtab1.Rows[g]["Message"].ToString());
                        }

                        // NotesInVisible = "YES";
                    }
                }
            }
            //GeneralFunction.Trace("Notes If11");
            // int discunt= Convert.ToInt16(GeneralOptionSetting.FlagAlertReorderItemsPerDay);

            // if (discunt >= GeneralOptionSetting.ReorderItemsDisplayCount)
            //  {
            if (GeneralOptionSetting.FlagAlertForReorders == "Y")
            {
                if (dtabMSG.Tables.Count > 0)
                {
                    dtab2 = dtabMSG.Tables[1];

                    if (dtab2.Rows.Count > 0)
                    {
                        OnlyReorder.Clear();
                        if (strLanguage.ToString() == "English")
                        {
                            OnlyReorder.Add("You have items   ");
                            OnlyReorder.Add("need to be Reordered");
                        }
                        else
                        {
                            OnlyReorder.Add("لديك اصناف يجب");
                            OnlyReorder.Add(" اعادة طلبها و توفيرها");
                        }
                        //OnlyReorder.Add("Reorder Items:");
                        //for (int g = 0;g < dtab2.Rows.Count; g++)
                        //{
                        //    Notes.Add(dtab2.Rows[g]["Message"].ToString());
                        //    OnlyReorder.Add(dtab2.Rows[g]["Message"].ToString());
                        //}
                    }
                }
            }
            //GeneralFunction.Trace("Notes If12");
            // }

            //  int discuntExp = Convert.ToInt16(GeneralOptionSetting.FlagAlertExpiryPerDay);

            // if (discuntExp >= GeneralOptionSetting.ExpiryDisplayCount)
            // {                     
            if (dtabMSG.Tables.Count > 0)
            {
                dtab3 = dtabMSG.Tables[2];

                if (dtab3.Rows.Count > 0)
                {
                    OnlyExpiryDate.Clear();
                    //if (strLanguage.ToString() == "English")
                    //{
                    //    OnlyExpiryDate.Add("You have items will Expire on ");

                    //}
                    //else
                    //{

                    //    OnlyExpiryDate.Add("اصناف ستنتهي صلاحيتها في");
                    //}
                    if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                        OnlyExpiryDate.Add("You have items will Expire on ");
                    else
                        OnlyExpiryDate.Add("اصناف ستنتهي صلاحيتها في");
                    for (int g = 0; g < dtab3.Rows.Count; g++)
                    {
                        string[] ExpSplit = dtab3.Rows[g]["Message"].ToString().Split(':');
                        Notes.Add(ExpSplit[0].ToString());
                        Notes.Add(ExpSplit[1].ToString());
                        //OnlyExpiryDate.Add(ExpSplit[0].ToString());
                        if (!OnlyExpiryDate.Contains(ExpSplit[1].ToString()))
                        {
                            OnlyExpiryDate.Add(ExpSplit[1].ToString());
                        }
                    }
                }
                else
                    OnlyExpiryDate.Clear();
            }
        }

        #region LoadOptions
        public static DataTable LoadOptions(int UserGroupID)
        {
            SqlDataAdapter sqlda;
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
            {
                try
                {

                    if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("select * from OptionDetails where UserGroupID =" + UserGroupID + "", sqlcon))
                    {

                        sqlCmd.CommandType = CommandType.Text;
                        sqlda = new SqlDataAdapter();
                        sqlda.SelectCommand = sqlCmd;
                        sqlda.SelectCommand.CommandTimeout = 1800;
                        sqlda.Fill(dt);

                        return dt;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }


        }
        #endregion

        #region LoadLogo
        public static DataTable LoadLogo()
        {
            SqlDataAdapter sqlda;
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                    using (SqlCommand sqlCmd = new SqlCommand("select HeaderLogo as HeaderLogo,FooterLogo as FooterLogo from Logo", sqlcon))
                    {

                        sqlCmd.CommandType = CommandType.Text;
                        sqlda = new SqlDataAdapter();
                        sqlda.SelectCommand = sqlCmd;
                        sqlda.SelectCommand.CommandTimeout = 1800;

                        sqlda.Fill(dt);
                        return dt;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }


        }
        #endregion

        #region ExecuteQueryDatatableDataSet
        public static DataTable ExecuteQueryDatatable(string procedurename, SqlParameter[] sqlparam, string tablename)
        {
            SqlDataAdapter sqlda;
            SqlCommand sqlcmd;
            DataTable ds = new DataTable(tablename);

            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
            {
                try
                {
                    if (sqlcon.State != ConnectionState.Open) sqlcon.Open();
                    sqlcmd = new SqlCommand();
                    sqlcmd.CommandText = procedurename;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Connection = sqlcon;
                    sqlda = new SqlDataAdapter();
                    sqlda.SelectCommand = sqlcmd;
                    sqlda.SelectCommand.CommandTimeout = 1800;
                    if (sqlparam.Length > 0)
                    {
                        sqlda.SelectCommand.Parameters.AddRange(sqlparam);
                    }
                    sqlda.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public static DataSet ExecuteQueryDataset(string procedurename, SqlParameter[] sqlparam, string tablename)
        {
            SqlDataAdapter sqlda;
            SqlCommand sqlcmd;
            DataSet ds = new DataSet(tablename);
            using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
            {
                try
                {
                    sqlcmd = new SqlCommand();
                    sqlcmd.CommandText = procedurename;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Connection = sqlcon;
                    sqlda = new SqlDataAdapter();
                    sqlda.SelectCommand = sqlcmd;
                    sqlda.SelectCommand.CommandTimeout = 1800;
                    if (sqlparam.Length > 0)
                    {
                        sqlda.SelectCommand.Parameters.AddRange(sqlparam);
                    }
                    sqlda.Fill(ds);
                    return ds;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        #endregion

        #region Validation Methods
        public static Boolean NumericOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar > 57 || e.KeyChar < 48 & e.KeyChar != 13 & e.KeyChar != 8 & e.KeyChar != 46)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean IntegerOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar > 57 || e.KeyChar < 48 & e.KeyChar != 13 & e.KeyChar != 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean NumericOnly(string strInputvalue)
        {
            try
            {
                Convert.ToDecimal(strInputvalue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region DebtAdjustmentfor the Agent
        /// <summary>
        /// Purhcase Invoice DebtLimit Created By Meena.R
        /// </summary>
        /// <returns></returns>
        public static decimal AgentDept()
        {
            DataTable dt = new DataTable();
            try
            {
                decimal decBalance = 0, decAmt = 0, decRec = 0, decDiscount = 0;// decTotal = 0;
                ClientDebt = 0.0m;
                if (AgentId.Count <= 0) return 0.0M;
                for (int index = 0; index < AgentId.Count; index++)
                {
                    if (AgentId[index].ToString() != string.Empty)
                    {
                        using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
                        {
                            SqlParameter[] sqlparam = new SqlParameter[4];
                            int ID = Convert.ToInt32(AgentId[index]);
                            sqlparam[0] = new SqlParameter("@AgentID", ID);
                            sqlparam[1] = new SqlParameter("@FromDate", DateTime.Now);
                            sqlparam[2] = new SqlParameter("@ToDate", DateTime.Now);
                            sqlparam[3] = new SqlParameter("@Status", 1);

                            if (sqlcon.State == ConnectionState.Closed)
                            {
                                sqlcon.Open();
                            }
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = sqlcon;
                            sqlcmd.CommandText = "SP_Get_BalanceSheet";
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            if (sqlparam != null && sqlparam.Length > 0)
                            {
                                sqlcmd.Parameters.AddRange(sqlparam);
                            }
                            SqlDataAdapter read = new SqlDataAdapter(sqlcmd);
                            //read = sqlcmd.ExecuteReader();
                            //  read.Read();
                            read.Fill(dt);
                            // dt.Load(read);
                            sqlcon.Close();
                        }
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                decAmt = decAmt + Convert.ToDecimal(dt.Rows[i]["NetAmount"]);
                                decRec = decRec + Convert.ToDecimal(dt.Rows[i]["AmtReceived"]);
                                decDiscount = decDiscount + Convert.ToDecimal(dt.Rows[i]["Discount"]);

                            }
                            decBalance = decRec - decAmt;
                        }
                    }

                }
                return ClientDebt = decBalance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Static Method
        public static string RemoveApostrophe(string value)
        {
            if (value.Contains("'"))
            {
                return (value.Replace("'", "''"));
            }
            else
                return value;
        }
        #endregion

        ////Common Notes and Alerts Meena.R\\\\

        #region Save_UserTrackingActions
        public static void Save_UserTrackingActions(int actionType, string performedOn, string tableName, string action, int IsActionInvoice)
        {
            try
            {
                if (GeneralOptionSetting.FlagTrackUsers == "N") return;
                using (SqlConnection sqlcon = new SqlConnection(string.Format("server={0};database={1};uid={2};pwd={3};", Server, Database, UserID, Password)))
                {
                    SqlParameter[] sqlparam = new SqlParameter[9];
                    String getStr = actionType.ToString();
                    sqlparam[0] = new SqlParameter("@ActionType", actionType);
                    //Commented by Ritu on 17-10-2014
                    //sqlparam[1] = new SqlParameter("@PerformedOn", string.IsNullOrEmpty(performedOn) ? string.Empty : performedOn);
                    sqlparam[1] = new SqlParameter("@PerformedOn", GetUserTracking(performedOn));
                    sqlparam[2] = new SqlParameter("@TableName", tableName);
                    sqlparam[3] = new SqlParameter("@Action", action);
                    sqlparam[4] = new SqlParameter("@ActionArabic", GetUserTracking(action));
                    sqlparam[5] = new SqlParameter("@UserID", GeneralFunction.UserId);
                    sqlparam[6] = new SqlParameter("@UserName", GeneralFunction.UserName);
                    sqlparam[7] = new SqlParameter("@IsInvoiceAction", IsActionInvoice);
                    sqlparam[8] = new SqlParameter("@Status", 1);

                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcon;
                    sqlcmd.CommandText = "SP_Save_UserTrackingActions";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    if (sqlparam != null && sqlparam.Length > 0)
                    {
                        sqlcmd.Parameters.AddRange(sqlparam);
                    }
                    sqlcmd.ExecuteNonQuery();
                    sqlcon.Close();
                }

            }
            catch (Exception ex)
            {
                Errorlogfile(ex.Message, UserId, "General Function", "DBUpdate Function");
            }
        }



        #endregion

        #region GetUserTracking
        public static string GetUserTracking(string strKey)
        {
            try
            {
                return dicUserTracking[strKey.Trim()];
            }
            catch (Exception ex)
            {
                return strKey;
            }
        }
        #endregion

        //For Mulitlanguage Implementation//

        //***********Print Barcode **********************//
        public static int TotalQty = 0, Totalpage = 0, Row = 0, Column = 0, TxtQty = 0, ItemIndex = -1, Cleardb = 0;
        public static int Tempqty = 0, Tempqtybarcode = 0, Total = 0;
        public static DataTable AddDT = new DataTable("Add");
        public static DataTable tempprintbarcodedt = new DataTable();
        public static DataTable BarcodeDetails = new DataTable("Barcode");
        public static bool Chklogo = false, Chkprice = false, Bigprice = false, Normalprice = false;
        public static string PurchaseBarcode = string.Empty;


        public static string EAN13(string chaine)
        {
            //V 1.0
            //Paramètres : une chaine de 12 chiffres
            //Parameters : a 12 digits length string
            //Retour : * une chaine qui, affichée avec la police EAN13.TTF, donne le code barre
            //         * une chaine vide si paramètre fourni incorrect
            //Return : * a string which give the bar code when it is dispayed with EAN13.TTF font
            //         * an empty string if the supplied parameter is no good
            int i;
            int first;
            int checksum = 0;
            string CodeBarre = "";
            bool tableA;

            //Vérifier qu'il y a 12 caractères
            //Check for 12 characters
            //Et que ce sont bien des chiffres
            //And they are really digits
            if (Regex.IsMatch(chaine, "^\\d{13}$"))
            {
                // Calcul de la clé de contrôle
                // Calculation of the checksum

                //for (i = 1; i < 12; i += 2)
                //{
                //    System.Diagnostics.Debug.WriteLine(chaine.Substring(i, 1));
                //    checksum += Convert.ToInt32(chaine.Substring(i, 1));
                //}
                //checksum *= 3;
                //for (i = 0; i < 12; i += 2)
                //{
                //    checksum += Convert.ToInt32(chaine.Substring(i, 1));
                //}
                //chaine += (10 - checksum % 10) % 10;


                //Le premier chiffre est pris tel quel, le deuxième vient de la table A
                //The first digit is taken just as it is, the second one come from table A
                CodeBarre = chaine.Substring(0, 1) + (char)(65 + Convert.ToInt32(chaine.Substring(1, 1)));
                first = Convert.ToInt32(chaine.Substring(0, 1));
                for (i = 2; i <= 6; i++)
                {
                    tableA = false;
                    switch (i)
                    {
                        case 2:
                            if (first >= 0 && first <= 3) tableA = true;
                            break;
                        case 3:
                            if (first == 0 || first == 4 || first == 7 || first == 8) tableA = true;
                            break;
                        case 4:
                            if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) tableA = true;
                            break;
                        case 5:
                            if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) tableA = true;
                            break;
                        case 6:
                            if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) tableA = true;
                            break;
                    }

                    if (tableA)
                        CodeBarre += (char)(65 + Convert.ToInt32(chaine.Substring(i, 1)));
                    else
                        CodeBarre += (char)(75 + Convert.ToInt32(chaine.Substring(i, 1)));
                }
                CodeBarre += "*"; //Ajout séparateur central / Add middle separator

                for (i = 7; i <= 12; i++)
                {
                    CodeBarre += (char)(97 + Convert.ToInt32(chaine.Substring(i, 1)));
                }
                CodeBarre += "+"; //Ajout de la marque de fin / Add end mark
            }
            return CodeBarre;
        }



        public static void BlinkText(EventArgs e, RichTextBox RTxt_NoteAlerts)
        {
            if (RTxt_NoteAlerts.ForeColor == Color.Blue)
                RTxt_NoteAlerts.ForeColor = Color.Beige;
            else
                RTxt_NoteAlerts.ForeColor = Color.Blue;
        }
        public static void blinkLabel(EventArgs e, Label Label1)
        {
            if (Label1.ForeColor == Color.Blue)
            {
                Color clr = Color.FromArgb(243, 210, 131);
                Label1.ForeColor = clr;
            }
            else
                Label1.ForeColor = Color.Blue;
        }
        /// <summary>
        /// Check Barcode avaiable
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>

        public static DataTable GetBarcode(string barcode)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[1];
            try
            {
                sqlparam[0] = new SqlParameter("@Barcode", barcode);
                Dt = ExecuteQueryDatatable("usp_BBM_Check_BarcodeDetails", sqlparam, "CheckBarcode");
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetAllBarcode()
        {
            DataTable Dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[0];
            try
            {

                Dt = ExecuteQueryDatatable("usp_ALLBarcodeDetails", sqlparam, "CheckBarcode");
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable SortInvoiceDetails(DataTable dt, string ItemColumnName, string PriceColumnName)
        {
            try
            {
                switch (GeneralOptionSetting.FlagItemSorting)
                {
                    case "0":
                        dt.DefaultView.Sort = ItemColumnName;
                        break;
                    case "1":
                        dt.DefaultView.Sort = ItemColumnName + " " + "desc";
                        break;
                    case "4":
                        dt.DefaultView.Sort = PriceColumnName;
                        break;
                    case "3":
                        dt.DefaultView.Sort = PriceColumnName + " " + "desc";
                        break;
                    default:
                        return dt;
                }
                return dt.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CleanBarcodeDetails()
        {
            GeneralFunction.AddDT.Rows.Clear();
            GeneralFunction.BarcodeDetails.Rows.Clear();
            GeneralFunction.Tempqty = 0;
            GeneralFunction.Tempqtybarcode = 0;
            GeneralFunction.TotalQty = 0;
            GeneralFunction.Row = 0;
            GeneralFunction.Column = 0;
            GeneralFunction.TxtQty = 0;
            GeneralFunction.ItemIndex = -1;
            GeneralFunction.Total = 0;
            GeneralFunction.Cleardb = 1;

        }

        public static void LoadTips()
        {
            string filepath = System.Windows.Forms.Application.StartupPath + "\\Tips.*";
            // string filepath1 = System.Windows.Forms.Application.StartupPath + "\\Tips.xlsx";
            string strcmd = "select * from [sheet1$]";
            if (File.Exists(filepath))
            {
                lstTips = GetTipsDetails(filepath, strcmd);
            }
        }

        private static List<string> GetTipsDetails(string filepath, string strcmd)
        {
            List<string> lst = new List<string>();
            try
            {
                using (OleDbConnection con = new OleDbConnection(string.Format("provider=Microsoft.Jet.OLEDB.4.0; data source={0};Extended Properties=Excel 8.0;", filepath)))
                //using (OleDbConnection con = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=Excel 8.0; HDR=No; IMEX=1", filepath)))
                {
                    OleDbDataAdapter daAdapter = new OleDbDataAdapter(strcmd, con);
                    DataTable dt = new DataTable("Tips");
                    daAdapter.FillSchema(dt, SchemaType.Source);
                    daAdapter.Fill(dt);
                    con.Close();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow oRow in dt.Rows)
                        {
                            string item = string.Empty;
                            if (oRow[0].ToString() != string.Empty)
                            {
                                lst.Add(oRow[0].ToString());
                            }
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int TipsCount { get; set; }
        public static String GroupTranslation(int GroupID)
        {
            String GroupName;
            if (GroupID == 2)
                GroupName = GeneralFunction.ChangeLanguageforCustomMsg("Administrator");
            else if (GroupID == 3)
                GroupName = GeneralFunction.ChangeLanguageforCustomMsg("Accountant");
            else if (GroupID == 4)
                GroupName = GeneralFunction.ChangeLanguageforCustomMsg("Salesperson");
            else if (GroupID == 5)
                GroupName = GeneralFunction.ChangeLanguageforCustomMsg("Purchasesperson");
            else
                GroupName = string.Empty;
            return GroupName;
        }

        #region Printer Selection
        public static string PrinterName(string PrintScreen)
        {
            string PN = "";
            PrinterSettings settings = new PrinterSettings();
            switch (PrintScreen)
            {
                case "Invoice":
                    PN = GeneralOptionSetting.FlagPrinterInvoice == " " || GeneralOptionSetting.FlagPrinterInvoice == "N/A" ? GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault : GeneralOptionSetting.FlagPrinterInvoice;
                    break;
                case "POS":
                    PN = GeneralOptionSetting.FlagPrinterPOS == " " || GeneralOptionSetting.FlagPrinterPOS == "N/A" ? GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault : GeneralOptionSetting.FlagPrinterPOS;
                    break;
                case "Report":
                    PN = GeneralOptionSetting.FlagPrinterReport == " " || GeneralOptionSetting.FlagPrinterReport == "N/A" ? GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault : GeneralOptionSetting.FlagPrinterReport;
                    break;
                case "Receipt":
                    PN = GeneralOptionSetting.FlagPrinterReceipt == " " || GeneralOptionSetting.FlagPrinterReceipt == "N/A" ? GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault : GeneralOptionSetting.FlagPrinterReceipt;
                    break;
                case "Barcode":
                    PN = GeneralOptionSetting.FlagPrinterBarcode == " " || GeneralOptionSetting.FlagPrinterBarcode == "N/A" ? GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault : GeneralOptionSetting.FlagPrinterBarcode;
                    break;
                default:
                    PN = GeneralOptionSetting.FlagPrinterDefault == " " || GeneralOptionSetting.FlagPrinterDefault == "N/A" ? settings.PrinterName : GeneralOptionSetting.FlagPrinterDefault;
                    break;


            }
            return PN;
        }
        #endregion
    }

    #region CurrencyConverterEnglish
    public class CurrencyConverter
    {
        private static string oneWords = ",One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Eleven,Twelve,Thirteen,Fourteen,Fifteen,Sixteen,Seventeen,Eighteen,Nineteen";
        private string[] ones = oneWords.Split(',');
        private static string tenWords = ",Ten,Twenty,Thirty,Forty,Fifty,Sixty,Seventy,Eighty,Ninety";
        private string[] tens = tenWords.Split(',');

        public string Convert(string input)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                input = input.Replace("$", "").Replace(",", "").Replace("-", "");
                if (input.Length > 12)
                {
                    return "Error in input value";
                }
                string output = null;
                string dollars = null;
                string mills = null;
                string thous = null;
                string hunds = null;
                string cents = null;
                int mill = 0;
                int thou = 0;
                int hund = 0;
                int cent = 0;
                if (input.IndexOf(".") > 0)
                {
                    dollars = input.Substring(0, input.IndexOf(".")).PadLeft(9, '0');
                    cents = input.Substring(input.IndexOf(".") + 1).PadRight(2, '0');
                    if (cents == "00")
                    {
                        cents = "0";
                    }
                }
                else
                {
                    dollars = input.PadLeft(9, '0');
                    cents = "0";
                }
                mill = System.Convert.ToInt32(dollars.Substring(0, 3));
                mills = convertHundreds(mill);
                thou = System.Convert.ToInt32(dollars.Substring(3, 3));
                thous = convertHundreds(thou);
                hund = System.Convert.ToInt32(dollars.Substring(6, 3));
                hunds = convertHundreds(hund);
                cent = System.Convert.ToInt32(cents);
                cents = convertHundreds(cent);
                output = ((mills.Trim() == "") ? "" : mills + " Million ");
                output += ((thous.Trim() == "") ? "" : thous + " Thousand ");
                output += ((hunds.Trim() == "") ? "" : hunds);
                output = ((output.Length == 0) ? "Zero Rupees" : output + " Rupees");
                output = ((output == "One Dollars") ? "One Rupee" : output);
                if (!string.IsNullOrEmpty(cents))
                {
                    output += " and " + ((cents == "") ? "Zero" : cents) + " Cents";
                }
                return output;
            }
            else
            {
                CurrencyConverterArabic arabicconversion = new CurrencyConverterArabic();
                return arabicconversion.Convert(input);
            }
        }

        private string convertHundreds(int input)
        {
            string output = null;
            if (input <= 99)
            {
                output = (convertTens(input));
            }
            else
            {
                output = ones[(int)Math.Floor(input / 100.0)];
                output += " Hundred ";
                if (input - Math.Floor(input / 100.0) * 100 == 0)
                {
                    output += "";
                }
                else
                {
                    output += "" + convertTens(input - (int)Math.Floor(input / 100.0) * 100);
                }
            }
            return output;
        }

        private string convertTens(int input)
        {
            string output = null;
            if (input < 20)
            {
                output = ones[input];
                input = 0;
            }
            else
            {
                output = tens[(int)Math.Floor(input / 10.0)];
                input -= ((int)Math.Floor(input / 10.0)) * 10;
            }
            output = output + ((ones[input].Trim() == "") ? "" : "-" + ones[input]);
            return output;
        }
    }
    #endregion

    #region CurrencyConverterArabic
    public class CurrencyConverterArabic
    {
        public string Convert(string amount)
        {
            string[] money = amount.Split('.');
            string mantissa = string.Empty;
            if (amount.Contains(".")) mantissa = money[1];
            amount = money[0];

            double n1, n2, n3, n4, n5, n6;
            string n_ch, ch, ch1, ch2, ch3, ch4, ch5, ch6, ch1_1, ch3_3, ch5_5, and1 = string.Empty, and2 = string.Empty, and3 = string.Empty, and4 = string.Empty, and5 = string.Empty, fils = "درهم", only = "فقط", dinar = "دينار", thousand = "ألف", milion = string.Empty;
            string[] one = new string[100];
            string[] hund = new string[10];

            #region "Binding"

            one[0] = " ";
            one[1] = "واحد ";
            one[2] = "إثنان ";
            one[3] = "ثلاثة ";
            one[4] = "أربعة ";
            one[5] = "خمسة ";
            one[6] = "ستة ";
            one[7] = "سبعة ";
            one[8] = "ثمانية ";
            one[9] = "تسعة ";
            one[10] = "عشرة ";
            one[11] = "أحد عشر";
            one[12] = "إثنى عشر";
            one[13] = "ثلاثة عشر";
            one[14] = "أربعة عشر";
            one[15] = "خمسة عشر";
            one[16] = "ستة عشر";
            one[17] = "سبعة عشر";
            one[18] = "ثمانية عشر";
            one[19] = "تسعة عشر";
            one[20] = "عشرون";
            one[21] = "واحد وعشرون";
            one[22] = "إثنان وعشرون";
            one[23] = "ثلاثة وعشرون";
            one[24] = "أربعة وعشرون";
            one[25] = "خمسة وعشرون";
            one[26] = "ستة وعشرون";
            one[27] = "سبعة وعشرون";
            one[28] = "ثمانية وعشرون";
            one[29] = "تسعة وعشرون";
            one[30] = "ثلاثون";
            one[31] = "واحد وثلاثون";
            one[32] = "إثنان وثلاثون";
            one[33] = "ثلاثة وثلاثون";
            one[34] = "أربعة وثلاثون";
            one[35] = "خمسة وثلاثون";
            one[36] = "ستة وثلاثون";
            one[37] = "سبعة وثلاثون";
            one[38] = "ثمانية وثلاثون";
            one[39] = "تسعة وثلاثون";
            one[40] = "أربعون";
            one[41] = "واحد وأربعون";
            one[42] = "إثنان وأربعون";
            one[43] = "ثلاثة وأربعون";
            one[44] = "أربعة وأربعون";
            one[45] = "خمسة وأربعون";
            one[46] = "ستة وأربعون";
            one[47] = "سبعة وأربعون";
            one[48] = "ثمانية وأربعون";
            one[49] = "تسعة وأربعون";
            one[50] = "خمسون";
            one[51] = "واحد وخمسون";
            one[52] = "إثنان وخمسون";
            one[53] = "ثلاثة وخمسون";
            one[54] = "أربعة وخمسون";
            one[55] = "خمسة وخمسون";
            one[56] = "ستة وخمسون";
            one[57] = "سبعة وخمسون";
            one[58] = "ثمانية وخمسون";
            one[59] = "تسعة وخمسون";
            one[60] = "ستون";
            one[61] = "واحد وستون";
            one[62] = "إثنان وستون";
            one[63] = "ثلاثة وستون";
            one[64] = "أربعة وستون";
            one[65] = "خمسة وستون";
            one[66] = "ستة وستون";
            one[67] = "سبعة وستون";
            one[68] = "ثمانية وستون";
            one[69] = "تسعة وستون";
            one[70] = "سبعون";
            one[71] = "واحد وسبعون";
            one[72] = "إثنان وسبعون";
            one[73] = "ثلاثة وسبعون";
            one[74] = "أربعة وسبعون";
            one[75] = "خمسة وسبعون";
            one[76] = "ستة وسبعون";
            one[77] = "سبعة وسبعون";
            one[78] = "ثمانية وسبعون";
            one[79] = "تسعة وسبعون";
            one[80] = "ثمانون";
            one[81] = "واحد وثمانون";
            one[82] = "إثنان وثمانون";
            one[83] = "ثلاثة وثمانون";
            one[84] = "أربعة وثمانون";
            one[85] = "خمسة وثمانون";
            one[86] = "ستة وثمانون";
            one[87] = "سبعة وثمانون";
            one[88] = "ثمانية وثمانون";
            one[89] = "تسعة وثمانون";
            one[90] = "تسعون";
            one[91] = "واحد وتسعون";
            one[92] = "إثنان وتسعون";
            one[93] = "ثلاثة وتسعون";
            one[94] = "أربعة وتسعون";
            one[95] = "خمسة وتسعون";
            one[96] = "ستة وتسعون";
            one[97] = "سبعة وتسعون";
            one[98] = "ثمانية وتسعون";
            one[99] = "تسعة وتسعون";
            hund[0] = " ";
            hund[1] = "مائة";
            hund[2] = "مائتان";
            hund[3] = "ثلاثمائة";
            hund[4] = "أربعمائة";
            hund[5] = "خمسمائة";
            hund[6] = "ستمائة";
            hund[7] = "سبعمائة";
            hund[8] = "ثمانمائة";
            hund[9] = "تسعمائة";

            #endregion

            n_ch = amount.Trim().PadLeft(8, '0'); //n_ch =  lpad(to_char(trunc(n)),8,'00000000');
            n1 = double.Parse(n_ch.Substring(0, 2));    //n1 = nvl(to_number(substr(n_ch,1,2)),0);
            n2 = double.Parse(n_ch.Substring(2, 1));//n2 = nvl(to_number(substr(n_ch,3,1)),0);
            n3 = double.Parse(n_ch.Substring(3, 2));//n3 = nvl(to_number(substr(n_ch,4,2)),0);
            n4 = double.Parse(n_ch.Substring(5, 1));//n4 = nvl(to_number(substr(n_ch,6,1)),0);
            n5 = double.Parse(n_ch.Substring(6, 2));//n5 = nvl(to_number(substr(n_ch,7,2)),0);
            n6 = (double.Parse(amount) % 1); //n6 = nvl(mod(n,1),0);
            ch1 = one[(int)n1];//ch1 = one(n1);
            ch2 = hund[(int)n2];//ch2 = hund(n2);
            ch3 = one[(int)n3];//ch3 = one(n3);
            ch4 = hund[(int)n4];//ch4 = hund(n4);
            ch5 = one[(int)n5];//ch5 = one(n5);
            ch6 = (n6 * 1000).ToString().PadLeft(4, ' ').PadRight(5, ' '); //ch6 = lpad(rpad(to_char(n6*1000),4,' '),5,' ');

            if (n1 != 0 && (n2 != 0 || n3 != 0 || n4 != 0 || n5 != 0)) and1 = " و";
            if (n2 != 0 && (n3 != 0 || n4 != 0 || n5 != 0)) and2 = " و";
            if ((n3 != 0 || n2 != 0) && (n4 != 0 || n5 != 0)) and3 = " و";
            if (n4 != 0 && n5 != 0) and4 = " و";
            if (double.Parse(amount) != 0 && n6 != 0) and5 = " و";
            ch1_1 = ch1;
            ch3_3 = ch3;
            ch5_5 = ch5;

            if (double.Parse(amount) == 0)
            {
                only = " ";
                dinar = " ";
                thousand = " ";
            }

            if (n6 == 0)
            {
                fils = "";
                ch6 = "";
            }

            if (n3 == 1 && n2 == 0)
            {
                ch3_3 = "";
            }
            else if (n3 == 2 && n2 == 0)
            {
                thousand = "ألفين";
                ch3_3 = "";
            }
            else if (n3 >= 3 && n3 <= 10)
            {
                thousand = "ألاف";
            }

            if (n3 == 0 && n2 == 0 && (n4 != 0 || n5 != 0))
            {
                thousand = "";
            }
            if (n3 == 0)
            {
                and2 = "";
            }
            if (n1 == 0 && n2 == 0 && n3 == 0 && n4 == 0)
            {
                if (n5 == 1)
                {
                    ch5_5 = "دينار" + ch5;
                    thousand = "";
                    dinar = "";
                }
                else if (n5 == 2)
                {
                    ch5_5 = "دينارين";
                    thousand = "";
                    dinar = "";
                }
                else if (n5 >= 3 && n5 <= 10)
                {
                    ch5_5 = ch5 + "دنانير";
                    thousand = "";
                    dinar = "";
                }

            }
            if (n1 == 0 && n2 == 0 && n3 == 0 && n4 == 0 && n5 == 0)
            {
                thousand = "";
                dinar = "";
            }

            if (n1 == 1)
            {
                milion = "مليون";
                ch1_1 = "";
            }
            else if (n1 == 2)
            {
                milion = "مليونين";
                ch1_1 = "";
            }
            else if (n1 >= 3 && n1 <= 10)
            {
                milion = "ملايين";
            }
            else if (n1 != 0)
            {
                milion = "مليون";
            }

            if (double.Parse(mantissa) != 000)
            {
                ch = ch1_1 + " " + milion + and1 + ch2 + and2 + ch3_3 + " " + thousand + and3 +
                ch4 + and4 + ch5_5 + "  " + dinar + " و " + mantissa + "  درهم " + and5 + ch6 + fils + " " + only;
            }
            else
            {
                ch = ch1_1 + " " + milion + and1 + ch2 + and2 + ch3_3 + " " + thousand + and3 +
                ch4 + and4 + ch5_5 + " " + dinar + and5 + ch6 + fils + " " + only;
            }
            return (ch);

        }

    }
    #endregion

    #region
    public class HijriToGregs
    {
        CultureInfo enCul = new CultureInfo("en-US");
        private CultureInfo arCul;
        public string[] allFormats = { "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy" };
        private HijriCalendar h;
        private GregorianCalendar g;
        public HijriToGregs()
        {
            //cur = HttpContext.Current;

            arCul = new CultureInfo("ar-SA");
            enCul = new CultureInfo("en-US");

            h = new HijriCalendar();
            g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);

            arCul.DateTimeFormat.Calendar = g;

        }
        public DateTime ConvertAllDatetime(string dateString)
        {

            DateTime getdate = DateTime.ParseExact(dateString, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return getdate;
        }


    }
    #endregion

   


}




