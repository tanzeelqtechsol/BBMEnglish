using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectHelper
{
    public class OptionSettingsObject
    {

        #region OptionSetting

        private string _optionflag, _optionstatus, _optioncreatedby, _optionmodifiedby;
        private DateTime _optioncreateddate, _optionmodifieddate, __optiondatenotify;
        private string _optionValue;
        private int _UserId, _usergrpid;

        #region String datatypes

        public string OptionValue
        {
            get
            {
                return _optionValue;
            }
            set
            {
                _optionValue = value;
            }

        }
        public string OptionFlag
        {
            get
            {
                return _optionflag;
            }
            set
            {
                _optionflag = value;
            }

        }
        public string OptionStatus
        {
            get
            {
                return _optionstatus;
            }
            set
            {
                _optionstatus = value;
            }

        }
        public string OptionCreatedBy
        {
            get
            {
                return _optioncreatedby;
            }
            set
            {
                _optioncreatedby = value;
            }

        }
        public string OptionModifiedBy
        {
            get
            {
                return _optionmodifiedby;
            }
            set
            {
                _optionmodifiedby = value;
            }

        }
        #endregion

        #region Datetime datatypes

        public DateTime OptionCreatedDate
        {
            get
            {
                return _optioncreateddate;
            }
            set
            {
                _optioncreateddate = value;
            }
        }
        public DateTime OptionModifiedDate
        {
            get
            {
                return _optionmodifieddate;
            }
            set
            {
                _optionmodifieddate = value;
            }
        }

        public DateTime OptionDateNotify
        {
            get
            {
                return __optiondatenotify;
            }
            set
            {
                __optiondatenotify = value;
            }
        }

        #endregion

        #region Integer datatypes

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }

        }

        public int UserGroupID
        {
            get
            {
                return _usergrpid;
            }
            set
            {
                _usergrpid = value;
            }

        }
        public int YearforStartNewYear { get; set; }
        #endregion

        #endregion

        #region OptionSettings_General Fields

        private string _optioncompanyname, _optionphone, _optioncell, _optionfax, _optionpobox, _optionemail, _optionaddress, _optionsystemnote, _optionworknote;
        private string _optionlanguage, _optionHideDiscountWindow, _optionHideWelcomeWindow, _optionHideNoteFiled, _optionShowCompanyOnInvoice, _optionShowCompanyNameOnly, _optionAutoStartwithWindow, _optionDateFormatControl;


        #region String datatypes

        public string OptionCompanyName
        {
            get
            {
                return _optioncompanyname;
            }
            set
            {
                _optioncompanyname = value;
            }

        }
        public string OptionPhone
        {
            get
            {
                return _optionphone;
            }
            set
            {
                _optionphone = value;
            }

        }
        public string OptionCell
        {
            get
            {
                return _optioncell;
            }
            set
            {
                _optioncell = value;
            }

        }
        public string OptionFax
        {
            get
            {
                return _optionfax;
            }
            set
            {
                _optionfax = value;
            }

        }
        public string OptionPOBox
        {
            get
            {
                return _optionpobox;
            }
            set
            {
                _optionpobox = value;
            }

        }
        public string OptionEmail
        {
            get
            {
                return _optionemail;
            }
            set
            {
                _optionemail = value;
            }

        }
        public string OptionAddress
        {
            get
            {
                return _optionaddress;
            }
            set
            {
                _optionaddress = value;
            }

        }
        public string OptionSystemNote
        {
            get
            {
                return _optionsystemnote;
            }
            set
            {
                _optionsystemnote = value;
            }

        }
        public string OptionWorkNote
        {
            get
            {
                return _optionworknote;
            }
            set
            {
                _optionworknote = value;
            }

        }
        public string OptionLangage
        {
            get
            {
                return _optionlanguage;
            }
            set
            {
                _optionlanguage = value;
            }

        }
        public string OptionHideDiscountWindow
        {
            get
            {
                return _optionHideDiscountWindow;
            }
            set
            {
                _optionHideDiscountWindow = value;
            }

        }
        public string OptionHideWelcomeWindow
        {
            get
            {
                return _optionHideWelcomeWindow;
            }
            set
            {
                _optionHideWelcomeWindow = value;
            }

        }
        public string OptionHideNoteFiled
        {
            get
            {
                return _optionHideNoteFiled;
            }
            set
            {
                _optionHideNoteFiled = value;
            }

        }
        public string OptionShowCompanyOnInvoice
        {
            get
            {
                return _optionShowCompanyOnInvoice;
            }
            set
            {
                _optionShowCompanyOnInvoice = value;
            }

        }
        public string OptionShowCompanyNameOnly
        {
            get
            {
                return _optionShowCompanyNameOnly;
            }
            set
            {
                _optionShowCompanyNameOnly = value;
            }

        }
        public string OptionAutoStartwithWindow
        {
            get
            {
                return _optionAutoStartwithWindow;
            }
            set
            {
                _optionAutoStartwithWindow = value;
            }

        }

        public string OptionDateFormat
        {
            get
            {
                return _optionDateFormatControl;
            }
            set
            {
                _optionDateFormatControl = value;
            }

        }
        #endregion

        #endregion

        #region OptionSettings_Invoice Fields

        private string _optiontxtPercentageCard, _optiontxtPercentageCheck, _optionchkActivatePaymentType, _optionPurchase_HideExpiryFiled, _optionPurchase_HideDevidingDiscountOnItem, _optionPurchase_AddItemDirectlywithBarcode, _optionTabToPrice, _optionShowDiscountFiled, _optionShowHidenItem, _optionPurchase_SaveUsernameOnInvoice, optionPurchase_HideImportExport, optionPurchase_DontUseExpiry;

        private string _optionHidePriceChangingButton, _optionSalePriceReadonly, _optionSale_AddItemDirectlywithBarcode, _optionOpenInvioceAfterClosing, _optionSale_HideExpiryFiled, _optionDevideDiscountBeforeClosingInvoice, _optionAlterwhenSellingLessthanCost, _optionShowSubTotalFiled, _optionShowNonStockItem, _optionSale_SaveUsernameOnInvoice, optionSale_DontUseExpiry, _optionShowInvoiceCostFiled, _optionDisableDiscountFiled, _optionSale_HideDevidingDiscountOnItem, _optionSale_InsertItemIndividually;

        #region String datatypes

        public string OptiontxtPercentageCheck
        {
            get
            {
                return _optiontxtPercentageCheck;
            }
            set
            {
                _optiontxtPercentageCheck = value;
            }

        }
        public string OptiontxtPercentageCard
        {
            get
            {
                return _optiontxtPercentageCard;
            }
            set
            {
                _optiontxtPercentageCard = value;
            }

        }
        public string OptionchkActivatePaymentType
        {
            get
            {
                return _optionchkActivatePaymentType;
            }
            set
            {
                _optionchkActivatePaymentType = value;
            }

        }
        public string OptionPurchase_HideExpiryFiled
        {
            get
            {
                return _optionPurchase_HideExpiryFiled;
            }
            set
            {
                _optionPurchase_HideExpiryFiled = value;
            }

        }
        public string OptionPurchase_HideDevidingDiscountOnItem
        {
            get
            {
                return _optionPurchase_HideDevidingDiscountOnItem;
            }
            set
            {
                _optionPurchase_HideDevidingDiscountOnItem = value;
            }

        }
        public string OptionPurchase_AddItemDirectlywithBarcode
        {
            get
            {
                return _optionPurchase_AddItemDirectlywithBarcode;
            }
            set
            {
                _optionPurchase_AddItemDirectlywithBarcode = value;
            }

        }
        public string OptionTabToPrice
        {
            get
            {
                return _optionTabToPrice;
            }
            set
            {
                _optionTabToPrice = value;
            }

        }
        public string OptionShowDiscountFiled
        {
            get
            {
                return _optionShowDiscountFiled;
            }
            set
            {
                _optionShowDiscountFiled = value;
            }

        }
        public string OptionShowHidenItem
        {
            get
            {
                return _optionShowHidenItem;
            }
            set
            {
                _optionShowHidenItem = value;
            }

        }
        public string OptionPurchase_SaveUsernameOnInvoice
        {
            get
            {
                return _optionPurchase_SaveUsernameOnInvoice;
            }
            set
            {
                _optionPurchase_SaveUsernameOnInvoice = value;
            }

        }
        public string OptionHidePriceChangingButton
        {
            get
            {
                return _optionHidePriceChangingButton;
            }
            set
            {
                _optionHidePriceChangingButton = value;
            }

        }
        public string OptionSalePriceReadonly
        {
            get
            {
                return _optionSalePriceReadonly;
            }
            set
            {
                _optionSalePriceReadonly = value;
            }

        }
        public string OptionSale_AddItemDirectlywithBarcode
        {
            get
            {
                return _optionSale_AddItemDirectlywithBarcode;
            }
            set
            {
                _optionSale_AddItemDirectlywithBarcode = value;
            }

        }
        public string OptionOpenInvioceAfterClosing
        {
            get
            {
                return _optionOpenInvioceAfterClosing;
            }
            set
            {
                _optionOpenInvioceAfterClosing = value;
            }

        }
        public string OptionSale_HideExpiryFiled
        {
            get
            {
                return _optionSale_HideExpiryFiled;
            }
            set
            {
                _optionSale_HideExpiryFiled = value;
            }

        }
        public string OptionDevideDiscountBeforeClosingInvoice
        {
            get
            {
                return _optionDevideDiscountBeforeClosingInvoice;
            }
            set
            {
                _optionDevideDiscountBeforeClosingInvoice = value;
            }

        }
        public string OptionAlterwhenSellingLessthanCost
        {
            get
            {
                return _optionAlterwhenSellingLessthanCost;
            }
            set
            {
                _optionAlterwhenSellingLessthanCost = value;
            }

        }
        public string OptionShowSubTotalFiled
        {
            get
            {
                return _optionShowSubTotalFiled;
            }
            set
            {
                _optionShowSubTotalFiled = value;
            }

        }
        public string OptionShowNonStockItem
        {
            get
            {
                return _optionShowNonStockItem;
            }
            set
            {
                _optionShowNonStockItem = value;
            }

        }
        public string OptionSale_SaveUsernameOnInvoice
        {
            get
            {
                return _optionSale_SaveUsernameOnInvoice;
            }
            set
            {
                _optionSale_SaveUsernameOnInvoice = value;
            }

        }
        public string OptionShowInvoiceCostFiled
        {
            get
            {
                return _optionShowInvoiceCostFiled;
            }
            set
            {
                _optionShowInvoiceCostFiled = value;
            }

        }
        public string OptionDisableDiscountFiled
        {
            get
            {
                return _optionDisableDiscountFiled;
            }
            set
            {
                _optionDisableDiscountFiled = value;
            }

        }
        public string OptionSale_HideDevidingDiscountOnItem
        {
            get
            {
                return _optionSale_HideDevidingDiscountOnItem;
            }
            set
            {
                _optionSale_HideDevidingDiscountOnItem = value;
            }

        }
        public string OptionSale_InsertItemIndividually
        {
            get
            {
                return _optionSale_InsertItemIndividually;
            }
            set
            {
                _optionSale_InsertItemIndividually = value;
            }

        }
        public string OptionPurchase_HideImportExport
        {
            get { return optionPurchase_HideImportExport; }
            set { optionPurchase_HideImportExport = value; }

        }
        public string OptionPurchase_DontUseExpiry
        {
            get { return optionPurchase_DontUseExpiry; }
            set { optionPurchase_DontUseExpiry = value; }
        }
        public string OptionSale_DontUseExpiry
        {
            get { return optionSale_DontUseExpiry; }
            set { optionSale_DontUseExpiry = value; }
        }

        #endregion

        #endregion

        #region OptionSettings_Print Fields

        private string _optionInvoiceTemplate, _optionBarcodePaperSize, _optionBarcodePrinter, _optionPrintingLogo, _optionItemSorting, _optionInvoiceCopies, _optionReciptCopies, _optionHeader, _optionFooter;
        private string _optionLogoHeader, _optionLogoFooter, _optionNoteSaleInvoice, _optionPrintAfterClosingInvoice, _optionPrintAfterClosingRecipt, _optionPrintTotalQuantity, _optionHideDiscountFiledOnPrint, _optionShowTime;
        private string _optionHideTaxFiled, _optionHideLogoOnPrint, _optionShowDeptOnPrint, _optionIgnoreNonStockItem, _optionPosCategoryVicePrint;
        private byte[] _headerlogo, _footerlogo;

        #region String datatypes

        public string OptionInvoiceTemplate
        {
            get
            {
                return _optionInvoiceTemplate;
            }
            set
            {
                _optionInvoiceTemplate = value;
            }
        }
        public string OptionBarcodePaperSize
        {
            get
            {
                return _optionBarcodePaperSize;
            }
            set
            {
                _optionBarcodePaperSize = value;
            }
        }
        public string OptionBarcodePrinter
        {
            get
            {
                return _optionBarcodePrinter;
            }
            set
            {
                _optionBarcodePrinter = value;
            }
        }
        public string OptionPrintingLogo
        {
            get
            {
                return _optionPrintingLogo;
            }
            set
            {
                _optionPrintingLogo = value;
            }
        }
        public string OptionItemSorting
        {
            get
            {
                return _optionItemSorting;
            }
            set
            {
                _optionItemSorting = value;
            }
        }
        public string OptionInvoiceCopies
        {
            get
            {
                return _optionInvoiceCopies;
            }
            set
            {
                _optionInvoiceCopies = value;
            }
        }
        public string OptionReciptCopies
        {
            get
            {
                return _optionReciptCopies;
            }
            set
            {
                _optionReciptCopies = value;
            }
        }
        public string OptionHeader
        {
            get
            {
                return _optionHeader;
            }
            set
            {
                _optionHeader = value;
            }
        }
        public string OptionFooter
        {
            get
            {
                return _optionFooter;
            }
            set
            {
                _optionFooter = value;
            }
        }
        public string OptionLogoHeader
        {
            get
            {
                return _optionLogoHeader;
            }
            set
            {
                _optionLogoHeader = value;
            }
        }
        public string OptionLogoFooter
        {
            get
            {
                return _optionLogoFooter;
            }
            set
            {
                _optionLogoFooter = value;
            }
        }
        public string OptionNoteSaleInvoice
        {
            get
            {
                return _optionNoteSaleInvoice;
            }
            set
            {
                _optionNoteSaleInvoice = value;
            }
        }
        public string OptionPrintAfterClosingInvoice
        {
            get
            {
                return _optionPrintAfterClosingInvoice;
            }
            set
            {
                _optionPrintAfterClosingInvoice = value;
            }
        }
        public string OptionPrintAfterClosingRecipt
        {
            get
            {
                return _optionPrintAfterClosingRecipt;
            }
            set
            {
                _optionPrintAfterClosingRecipt = value;
            }
        }
        public string OptionPrintTotalQuantity
        {
            get
            {
                return _optionPrintTotalQuantity;
            }
            set
            {
                _optionPrintTotalQuantity = value;
            }
        }
        public string OptionHideDiscountFiledOnPrint
        {
            get
            {
                return _optionHideDiscountFiledOnPrint;
            }
            set
            {
                _optionHideDiscountFiledOnPrint = value;
            }
        }
        public string OptionShowTime
        {
            get
            {
                return _optionShowTime;
            }
            set
            {
                _optionShowTime = value;
            }
        }
        public string OptionHideTaxFiled
        {
            get
            {
                return _optionHideTaxFiled;
            }
            set
            {
                _optionHideTaxFiled = value;
            }
        }
        public string OptionHideLogoOnPrint
        {
            get
            {
                return _optionHideLogoOnPrint;
            }
            set
            {
                _optionHideLogoOnPrint = value;
            }
        }
        public string OptionHidePeaceBoxOnPrint{get;set;}

        public string OptionShowDeptOnPrint
        {
            get
            {
                return _optionShowDeptOnPrint;
            }
            set
            {
                _optionShowDeptOnPrint = value;
            }
        }
        public string OptionIgnoreNonStockItem
        {
            get
            {
                return _optionIgnoreNonStockItem;
            }
            set
            {
                _optionIgnoreNonStockItem = value;
            }
        }
        public string OptionPosCategoryVicePrint
        {
            get
            {
                return _optionPosCategoryVicePrint;
            }
            set
            {
                _optionPosCategoryVicePrint = value;
            }
        }
        public byte[] HeaderLogo
        {
            get
            {
                return _headerlogo;
            }
            set
            {
                _headerlogo = value;
            }
        }
        public byte[] FooterLogo
        {
            get
            {
                return _footerlogo;
            }
            set
            {
                _footerlogo = value;
            }
        }


        #endregion

        #endregion

        #region OptionSettings_Item Fields

        private string _optionAlertExpiry, _optionAlertReorderItem, _optionIssueOrderInvoice, _optionAlertForReorders, _optionDontIssueReorderInvoice, _optionHideItemSaleTimeInInvoice, _optionHideItemCostInSales, _optionHideItemNumber, _optionchkautoitemprice, _optiontxtautoitemprice;
        private string _optionDontTabToReorderandMaxpoint, _optionDontAlertForExpiryInNotes, _optionQuitWithoutAsking, _optionSellExpiryWenNotEnough, _optionAlertForMultiExpiry, _optionUseExpiryDefaultInItemCard, _optionHidePackageQuantity, _optionMonitorReorderAndMaxpoint;

        #region String datatypes
        public string OptionAlertExpiry
        {
            get
            {
                return _optionAlertExpiry;
            }
            set
            {
                _optionAlertExpiry = value;
            }

        }
        public string OptionAlertReorderItem
        {
            get
            {
                return _optionAlertReorderItem;
            }
            set
            {
                _optionAlertReorderItem = value;
            }

        }
        public string OptionIssueOrderInvoice
        {
            get
            {
                return _optionIssueOrderInvoice;
            }
            set
            {
                _optionIssueOrderInvoice = value;
            }

        }
        public string OptionAlertForReorders
        {
            get
            {
                return _optionAlertForReorders;
            }
            set
            {
                _optionAlertForReorders = value;
            }

        }
        public string OptionDontIssueReorderInvoice
        {
            get
            {
                return _optionDontIssueReorderInvoice;
            }
            set
            {
                _optionDontIssueReorderInvoice = value;
            }

        }
        public string OptionHideItemSaleTimeInInvoice
        {
            get
            {
                return _optionHideItemSaleTimeInInvoice;
            }
            set
            {
                _optionHideItemSaleTimeInInvoice = value;
            }

        }
        public string OptionHideItemCostInSales
        {
            get
            {
                return _optionHideItemCostInSales;
            }
            set
            {
                _optionHideItemCostInSales = value;
            }

        }
        public string OptionHideItemNumber
        {
            get
            {
                return _optionHideItemNumber;
            }
            set
            {
                _optionHideItemNumber = value;
            }

        }
        public string OptionDontTabToReorderandMaxpoint
        {
            get
            {
                return _optionDontTabToReorderandMaxpoint;
            }
            set
            {
                _optionDontTabToReorderandMaxpoint = value;
            }

        }
        public string OptionDontAlertForExpiryInNotes
        {
            get
            {
                return _optionDontAlertForExpiryInNotes;
            }
            set
            {
                _optionDontAlertForExpiryInNotes = value;
            }

        }
        public string OptionQuitWithoutAsking
        {
            get
            {
                return _optionQuitWithoutAsking;
            }
            set
            {
                _optionQuitWithoutAsking = value;
            }

        }
        public string OptionSellExpiryWenNotEnough
        {
            get
            {
                return _optionSellExpiryWenNotEnough;
            }
            set
            {
                _optionSellExpiryWenNotEnough = value;
            }

        }
        public string OptionAlertForMultiExpiry
        {
            get
            {
                return _optionAlertForMultiExpiry;
            }
            set
            {
                _optionAlertForMultiExpiry = value;
            }

        }
        public string OptionUseExpiryDefaultInItemCard
        {
            get
            {
                return _optionUseExpiryDefaultInItemCard;
            }
            set
            {
                _optionUseExpiryDefaultInItemCard = value;
            }

        }
        public string OptionHidePackageQuantity
        {
            get
            {
                return _optionHidePackageQuantity;
            }
            set
            {
                _optionHidePackageQuantity = value;
            }

        }
        public string OptionMonitorReorderAndMaxpoint
        {
            get
            {
                return _optionMonitorReorderAndMaxpoint;
            }
            set
            {
                _optionMonitorReorderAndMaxpoint = value;
            }

        }

        public string OptionCHKAutoItemPrice
        {
            get
            {
                return _optionchkautoitemprice;
            }
            set
            {
                _optionchkautoitemprice = value;
            }

        }

        public string OptionTxtAutoItemPrice
        {
            get
            {
                return _optiontxtautoitemprice;
            }
            set
            {
                _optiontxtautoitemprice = value;
            }

        }


        #endregion
        #endregion

        #region OptionSettings_Employee Fields

        private string _optionCalculateSalary, _optionHoliday, _optionCalculateSalaryFromStartDay, _optionCutLatencyAutomatically, _optionCountSalaryFromRegistrationPoint, _optionCutDeficits;
        private string _optionTrackUsers, _optionCountSystemStarupMinutes, _optionCountOverTimeAutomatically, _optionCountOverTimeForHolidays, _optionStopEmployeeCalculations;

        #region String datatypes

        public string OptionCalculateSalary
        {
            get
            {
                return _optionCalculateSalary;
            }
            set
            {
                _optionCalculateSalary = value;
            }

        }
        public string OptionHoliday
        {
            get
            {
                return _optionHoliday;
            }
            set
            {
                _optionHoliday = value;
            }

        }
        public string OptionCalculateSalaryFromStartDay
        {
            get
            {
                return _optionCalculateSalaryFromStartDay;
            }
            set
            {
                _optionCalculateSalaryFromStartDay = value;
            }

        }
        public string OptionCutLatencyAutomatically
        {
            get
            {
                return _optionCutLatencyAutomatically;
            }
            set
            {
                _optionCutLatencyAutomatically = value;
            }

        }
        public string OptionCountSalaryFromRegistrationPoint
        {
            get
            {
                return _optionCountSalaryFromRegistrationPoint;
            }
            set
            {
                _optionCountSalaryFromRegistrationPoint = value;
            }

        }
        public string OptionCutDeficits
        {
            get
            {
                return _optionCutDeficits;
            }
            set
            {
                _optionCutDeficits = value;
            }

        }
        public string OptionTrackUsers
        {
            get
            {
                return _optionTrackUsers;
            }
            set
            {
                _optionTrackUsers = value;
            }

        }
        public string OptionCountSystemStarupMinutes
        {
            get
            {
                return _optionCountSystemStarupMinutes;
            }
            set
            {
                _optionCountSystemStarupMinutes = value;
            }

        }
        public string OptionCountOverTimeAutomatically
        {
            get
            {
                return _optionCountOverTimeAutomatically;
            }
            set
            {
                _optionCountOverTimeAutomatically = value;
            }

        }
        public string OptionCountOverTimeForHolidays
        {
            get
            {
                return _optionCountOverTimeForHolidays;
            }
            set
            {
                _optionCountOverTimeForHolidays = value;
            }

        }
        public string OptionStopEmployeeCalculations
        {
            get
            {
                return _optionStopEmployeeCalculations;
            }
            set
            {
                _optionStopEmployeeCalculations = value;
            }

        }


        #endregion

        #endregion

        #region OptionSettings_Backup Fields

        private string _optionAskWhenLeavingSystem, _optionAutomaticBackupWhenClosing, _optionAskWhenReplacingFile, _optionSaveAutomaticBackupInAlternativePath, _optionSaveFilenameWithDatetime;
        private string _optionAlertWhenNotMakingBackup, _optionAutomaticBackupDays, _optionSaveBackup, _optionAlternativePath, _optionLastBackupDate;

        #region String datatypes

        public string OptionAskWhenLeavingSystem
        {
            get
            {
                return _optionAskWhenLeavingSystem;
            }
            set
            {
                _optionAskWhenLeavingSystem = value;
            }

        }
        public string OptionAutomaticBackupWhenClosing
        {
            get
            {
                return _optionAutomaticBackupWhenClosing;
            }
            set
            {
                _optionAutomaticBackupWhenClosing = value;
            }

        }
        public string OptionAskWhenReplacingFile
        {
            get
            {
                return _optionAskWhenReplacingFile;
            }
            set
            {
                _optionAskWhenReplacingFile = value;
            }

        }
        public string OptionSaveAutomaticBackupInAlternativePath
        {
            get
            {
                return _optionSaveAutomaticBackupInAlternativePath;
            }
            set
            {
                _optionSaveAutomaticBackupInAlternativePath = value;
            }

        }
        public string OptionSaveFilenameWithDatetime
        {
            get
            {
                return _optionSaveFilenameWithDatetime;
            }
            set
            {
                _optionSaveFilenameWithDatetime = value;
            }

        }
        public string OptionAlertWhenNotMakingBackup
        {
            get
            {
                return _optionAlertWhenNotMakingBackup;
            }
            set
            {
                _optionAlertWhenNotMakingBackup = value;
            }

        }
        public string OptionAutomaticBackupDays
        {
            get
            {
                return _optionAutomaticBackupDays;
            }
            set
            {
                _optionAutomaticBackupDays = value;
            }

        }
        public string OptionSaveBackup
        {
            get
            {
                return _optionSaveBackup;
            }
            set
            {
                _optionSaveBackup = value;
            }

        }
        public string OptionAlternativePath
        {
            get
            {
                return _optionAlternativePath;
            }
            set
            {
                _optionAlternativePath = value;
            }

        }
        public string OptionLastBackupDate
        {
            get
            {
                return _optionLastBackupDate;
            }
            set
            {
                _optionLastBackupDate = value;
            }

        }


        #endregion

        #endregion

        #region OptionSettings_Peripherals Fields

        private string _optionUseCustomerDisplay, _optionFirstLineWelcomeNote, _optionSecondLineWelcomeNote, _optionUseCashDrawer, _optionDrawerTypeUSP, _optionDrawerTypeCOM;
        private string _optionDrawerTypeRJ11, _optionDrawerOpenDirectlyAfterPrint, _optionDrawerProtectWithPassword, _optionCashDrawerPassword, _optionCashDrawerVerifyPassword;

        #region String datatypes

        public string OptionUseCustomerDisplay
        {
            get
            {
                return _optionUseCustomerDisplay;
            }
            set
            {
                _optionUseCustomerDisplay = value;
            }

        }
        public string OptionFirstLineWelcomeNote
        {
            get
            {
                return _optionFirstLineWelcomeNote;
            }
            set
            {
                _optionFirstLineWelcomeNote = value;
            }

        }
        public string OptionSecondLineWelcomeNote
        {
            get
            {
                return _optionSecondLineWelcomeNote;
            }
            set
            {
                _optionSecondLineWelcomeNote = value;
            }

        }
        public string OptionUseCashDrawer
        {
            get
            {
                return _optionUseCashDrawer;
            }
            set
            {
                _optionUseCashDrawer = value;
            }

        }
        public string OptionDrawerTypeUSP
        {
            get
            {
                return _optionDrawerTypeUSP;
            }
            set
            {
                _optionDrawerTypeUSP = value;
            }

        }
        public string OptionDrawerTypeCOM
        {
            get
            {
                return _optionDrawerTypeCOM;
            }
            set
            {
                _optionDrawerTypeCOM = value;
            }

        }
        public string OptionDrawerTypeRJ11
        {
            get
            {
                return _optionDrawerTypeRJ11;
            }
            set
            {
                _optionDrawerTypeRJ11 = value;
            }

        }
        public string OptionDrawerOpenDirectlyAfterPrint
        {
            get
            {
                return _optionDrawerOpenDirectlyAfterPrint;
            }
            set
            {
                _optionDrawerOpenDirectlyAfterPrint = value;
            }

        }
        public string OptionDrawerProtectWithPassword
        {
            get
            {
                return _optionDrawerProtectWithPassword;
            }
            set
            {
                _optionDrawerProtectWithPassword = value;
            }

        }
        public string OptionCashDrawerPassword
        {
            get
            {
                return _optionCashDrawerPassword;
            }
            set
            {
                _optionCashDrawerPassword = value;
            }

        }
        public string OptionCashDrawerVerifyPassword
        {
            get
            {
                return _optionCashDrawerVerifyPassword;
            }
            set
            {
                _optionCashDrawerVerifyPassword = value;
            }

        }

        #endregion

        #endregion

        #region OptionSettings_Tax Fields

        private string _optionTax1_TaxName, _optionTax1_Percentage, _optionTax1_SubPercentage, _optionTax1_ShowTaxInvoice, _optionTax1_ApplySales, _optionTax1_ApplyPurchase, _optionTax1_ApplyMaintains, _optionTax1_ApplyBeforeDiscount;
        private string _optionTax2_TaxName, _optionTax2_Percentage, _optionTax2_SubPercentage, _optionTax2_ShowTaxInvoice, _optionTax2_ApplySales, _optionTax2_ApplyPurchase, _optionTax2_ApplyMaintains, _optionTax2_ApplyBeforeDiscount;

        #region String datatypes

        public string OptionTax1_TaxName
        {
            get
            {
                return _optionTax1_TaxName;
            }
            set
            {
                _optionTax1_TaxName = value;
            }

        }
        public string OptionTax1_Percentage
        {
            get
            {
                return _optionTax1_Percentage;
            }
            set
            {
                _optionTax1_Percentage = value;
            }

        }
        public string OptionTax1_SubPercentage
        {
            get
            {
                return _optionTax1_SubPercentage;
            }
            set
            {
                _optionTax1_SubPercentage = value;
            }

        }
        public string OptionTax1_ShowTaxInvoice
        {
            get
            {
                return _optionTax1_ShowTaxInvoice;
            }
            set
            {
                _optionTax1_ShowTaxInvoice = value;
            }

        }
        public string OptionTax1_ApplySales
        {
            get
            {
                return _optionTax1_ApplySales;
            }
            set
            {
                _optionTax1_ApplySales = value;
            }

        }
        public string OptionTax1_ApplyPurchase
        {
            get
            {
                return _optionTax1_ApplyPurchase;
            }
            set
            {
                _optionTax1_ApplyPurchase = value;
            }

        }
        public string OptionTax1_ApplyMaintains
        {
            get
            {
                return _optionTax1_ApplyMaintains;
            }
            set
            {
                _optionTax1_ApplyMaintains = value;
            }

        }
        public string OptionTax1_ApplyBeforeDiscount
        {
            get
            {
                return _optionTax1_ApplyBeforeDiscount;
            }
            set
            {
                _optionTax1_ApplyBeforeDiscount = value;
            }

        }
        public string OptionTax2_TaxName
        {
            get
            {
                return _optionTax2_TaxName;
            }
            set
            {
                _optionTax2_TaxName = value;
            }

        }
        public string OptionTax2_Percentage
        {
            get
            {
                return _optionTax2_Percentage;
            }
            set
            {
                _optionTax2_Percentage = value;
            }

        }
        public string OptionTax2_SubPercentage
        {
            get
            {
                return _optionTax2_SubPercentage;
            }
            set
            {
                _optionTax2_SubPercentage = value;
            }

        }
        public string OptionTax2_ShowTaxInvoice
        {
            get
            {
                return _optionTax2_ShowTaxInvoice;
            }
            set
            {
                _optionTax2_ShowTaxInvoice = value;
            }

        }
        public string OptionTax2_ApplySales
        {
            get
            {
                return _optionTax2_ApplySales;
            }
            set
            {
                _optionTax2_ApplySales = value;
            }

        }
        public string OptionTax2_ApplyPurchase
        {
            get
            {
                return _optionTax2_ApplyPurchase;
            }
            set
            {
                _optionTax2_ApplyPurchase = value;
            }

        }
        public string OptionTax2_ApplyMaintains
        {
            get
            {
                return _optionTax2_ApplyMaintains;
            }
            set
            {
                _optionTax2_ApplyMaintains = value;
            }

        }
        public string OptionTax2_ApplyBeforeDiscount
        {
            get
            {
                return _optionTax2_ApplyBeforeDiscount;
            }
            set
            {
                _optionTax2_ApplyBeforeDiscount = value;
            }

        }

        #endregion

        #endregion

        #region OptionSettings_Notification Fields

        private string _optionLicenserenewal, _optionMedicalInsurance, _optionCertificateofHealth, _optionAttendancePermit, _optionTechnicalDisclosure, _optionPricing, _optionPayrent, _optionDisbursementSalary, _optionAnnualInventory, _optionZakat;
        private string _optionLicenserenewalDate, _optionMedicalInsuranceDate, _optionCertificateofHealthDate, _optionAttendancePermitDate, _optionTechnicalDisclosureDate, _optionPricingDate, _optionPayrentDate, _optionDisbursementSalaryDate, _optionAnnualInventoryDate, _optionZakatDate;
        private string _optionLicenserenewalNotifyBefore, _optionMedicalInsuranceNotifyBefore, _optionCertificateofHealthNotifyBefore, _optionAttendancePermitNotifyBefore, _optionTechnicalDisclosureNotifyBefore, _optionPricingNotifyBefore, _optionPayrentNotifyBefore, _optionDisbursementSalaryNotifyBefore, _optionAnnualInventoryNotifyBefore, _optionZakatNotifyBefore;

        #region String datatypes

        public string OptionLicenserenewal
        {
            get
            {
                return _optionLicenserenewal;
            }
            set
            {
                _optionLicenserenewal = value;
            }
        }
        public string OptionMedicalInsurance
        {
            get
            {
                return _optionMedicalInsurance;
            }
            set
            {
                _optionMedicalInsurance = value;
            }
        }
        public string OptionCertificateofHealth
        {
            get
            {
                return _optionCertificateofHealth;
            }
            set
            {
                _optionCertificateofHealth = value;
            }
        }
        public string OptionAttendancePermit
        {
            get
            {
                return _optionAttendancePermit;
            }
            set
            {
                _optionAttendancePermit = value;
            }
        }
        public string OptionTechnicalDisclosure
        {
            get
            {
                return _optionTechnicalDisclosure;
            }
            set
            {
                _optionTechnicalDisclosure = value;
            }
        }
        public string OptionPricing
        {
            get
            {
                return _optionPricing;
            }
            set
            {
                _optionPricing = value;
            }
        }
        public string OptionPayrent
        {
            get
            {
                return _optionPayrent;
            }
            set
            {
                _optionPayrent = value;
            }
        }
        public string OptionDisbursementSalary
        {
            get
            {
                return _optionDisbursementSalary;
            }
            set
            {
                _optionDisbursementSalary = value;
            }
        }
        public string OptionAnnualInventory
        {
            get
            {
                return _optionAnnualInventory;
            }
            set
            {
                _optionAnnualInventory = value;
            }
        }
        public string OptionZakat
        {
            get
            {
                return _optionZakat;
            }
            set
            {
                _optionZakat = value;
            }
        }

        #endregion

        #region Datetime datatypes
        public string OptionLicenserenewalDate
        {
            get
            {
                return _optionLicenserenewalDate;
            }
            set
            {
                _optionLicenserenewalDate = value;
            }
        }
        public string OptionMedicalInsuranceDate
        {
            get
            {
                return _optionMedicalInsuranceDate;
            }
            set
            {
                _optionMedicalInsuranceDate = value;
            }
        }
        public string OptionCertificateofHealthDate
        {
            get
            {
                return _optionCertificateofHealthDate;
            }
            set
            {
                _optionCertificateofHealthDate = value;
            }
        }
        public string OptionAttendancePermitDate
        {
            get
            {
                return _optionAttendancePermitDate;
            }
            set
            {
                _optionAttendancePermitDate = value;
            }
        }
        public string OptionTechnicalDisclosureDate
        {
            get
            {
                return _optionTechnicalDisclosureDate;
            }
            set
            {
                _optionTechnicalDisclosureDate = value;
            }
        }
        public string OptionPricingDate
        {
            get
            {
                return _optionPricingDate;
            }
            set
            {
                _optionPricingDate = value;
            }
        }
        public string OptionPayrentDate
        {
            get
            {
                return _optionPayrentDate;
            }
            set
            {
                _optionPayrentDate = value;
            }
        }
        public string OptionDisbursementSalaryDate
        {
            get
            {
                return _optionDisbursementSalaryDate;
            }
            set
            {
                _optionDisbursementSalaryDate = value;
            }
        }
        public string OptionAnnualInventoryDate
        {
            get
            {
                return _optionAnnualInventoryDate;
            }
            set
            {
                _optionAnnualInventoryDate = value;
            }
        }
        public string OptionZakatDate
        {
            get
            {
                return _optionZakatDate;
            }
            set
            {
                _optionZakatDate = value;
            }
        }

        #endregion

        #region Integer datatypes

        public string OptionLicenserenewalNotifyBefore
        {
            get
            {
                return _optionLicenserenewalNotifyBefore;
            }
            set
            {
                _optionLicenserenewalNotifyBefore = value;
            }
        }
        public string OptionMedicalInsuranceNotifyBefore
        {
            get
            {
                return _optionMedicalInsuranceNotifyBefore;
            }
            set
            {
                _optionMedicalInsuranceNotifyBefore = value;
            }
        }
        public string OptionCertificateofHealthNotifyBefore
        {
            get
            {
                return _optionCertificateofHealthNotifyBefore;
            }
            set
            {
                _optionCertificateofHealthNotifyBefore = value;
            }
        }
        public string OptionAttendancePermitNotifyBefore
        {
            get
            {
                return _optionAttendancePermitNotifyBefore;
            }
            set
            {
                _optionAttendancePermitNotifyBefore = value;
            }
        }
        public string OptionTechnicalDisclosureNotifyBefore
        {
            get
            {
                return _optionTechnicalDisclosureNotifyBefore;
            }
            set
            {
                _optionTechnicalDisclosureNotifyBefore = value;
            }
        }
        public string OptionPricingNotifyBefore
        {
            get
            {
                return _optionPricingNotifyBefore;
            }
            set
            {
                _optionPricingNotifyBefore = value;
            }
        }
        public string OptionPayrentNotifyBefore
        {
            get
            {
                return _optionPayrentNotifyBefore;
            }
            set
            {
                _optionPayrentNotifyBefore = value;
            }
        }
        public string OptionDisbursementSalaryNotifyBefore
        {
            get
            {
                return _optionDisbursementSalaryNotifyBefore;
            }
            set
            {
                _optionDisbursementSalaryNotifyBefore = value;
            }
        }
        public string OptionAnnualInventoryNotifyBefore
        {
            get
            {
                return _optionAnnualInventoryNotifyBefore;
            }
            set
            {
                _optionAnnualInventoryNotifyBefore = value;
            }
        }
        public string OptionZakatNotifyBefore
        {
            get
            {
                return _optionZakatNotifyBefore;
            }
            set
            {
                _optionZakatNotifyBefore = value;
            }
        }


        #endregion



        #endregion

        #region OptionSettings_Other Fields

        private string _optionDontAskClosingSystem, _option24HourWorkSystem, _optionStopDeptSellings, _optionHidePackageReport, _optionShowTipDayWhenStart, _optionBranchBuyswithCost, _optionUseItemPhoto, _optionUseRentingInvoice, _optionDontAlertOnSave, _optionDontAlertDeleteItemFromInvoice;
        private string _optionUnifyOptionForallWorkStations, _optionRoundPriceOnDiscount, _optionRoundPricesOnDiscountValue, _optionAlertReorderItemsPerDay, _optionAlertExpiryPerDay, _optionAlertPayDatesBefore, _optionAlertPayDates, _optionAlertWithSound, _optionAlertSaleInvoice;
        private string _optionHidePOSShortcut, _optionHidePOSScreen, _optionHideRentingInvoice, _optionHideKitchenWindow;

        #region String datatypes

        public string OptionDontAskClosingSystem
        {
            get
            {
                return _optionDontAskClosingSystem;
            }
            set
            {
                _optionDontAskClosingSystem = value;
            }

        }
        public string Option24HourWorkSystem
        {
            get
            {
                return _option24HourWorkSystem;
            }
            set
            {
                _option24HourWorkSystem = value;
            }

        }
        public string OptionStopDeptSellings
        {
            get
            {
                return _optionStopDeptSellings;
            }
            set
            {
                _optionStopDeptSellings = value;
            }

        }
        public string OptionHidePackageReport
        {
            get
            {
                return _optionHidePackageReport;
            }
            set
            {
                _optionHidePackageReport = value;
            }

        }
        public string OptionShowTipDayWhenStart
        {
            get
            {
                return _optionShowTipDayWhenStart;
            }
            set
            {
                _optionShowTipDayWhenStart = value;
            }

        }
        public string OptionBranchBuyswithCost
        {
            get
            {
                return _optionBranchBuyswithCost;
            }
            set
            {
                _optionBranchBuyswithCost = value;
            }

        }
        public string OptionUseItemPhoto
        {
            get
            {
                return _optionUseItemPhoto;
            }
            set
            {
                _optionUseItemPhoto = value;
            }

        }
        public string OptionUseRentingInvoice
        {
            get
            {
                return _optionUseRentingInvoice;
            }
            set
            {
                _optionUseRentingInvoice = value;
            }

        }
        public string OptionDontAlertOnSave
        {
            get
            {
                return _optionDontAlertOnSave;
            }
            set
            {
                _optionDontAlertOnSave = value;
            }

        }
        public string OptionDontAlertDeleteItemFromInvoice
        {
            get
            {
                return _optionDontAlertDeleteItemFromInvoice;
            }
            set
            {
                _optionDontAlertDeleteItemFromInvoice = value;
            }

        }
        public string OptionUnifyOptionForallWorkStations
        {
            get
            {
                return _optionUnifyOptionForallWorkStations;
            }
            set
            {
                _optionUnifyOptionForallWorkStations = value;
            }

        }
        public string OptionRoundPriceOnDiscount
        {
            get
            {
                return _optionRoundPriceOnDiscount;
            }
            set
            {
                _optionRoundPriceOnDiscount = value;
            }

        }
        public string OptionRoundPricesOnDiscountValue
        {
            get
            {
                return _optionRoundPricesOnDiscountValue;
            }
            set
            {
                _optionRoundPricesOnDiscountValue = value;
            }

        }
        public string OptionAlertReorderItemsPerDay
        {
            get
            {
                return _optionAlertReorderItemsPerDay;
            }
            set
            {
                _optionAlertReorderItemsPerDay = value;
            }

        }
        public string OptionAlertExpiryPerDay
        {
            get
            {
                return _optionAlertExpiryPerDay;
            }
            set
            {
                _optionAlertExpiryPerDay = value;
            }

        }
        public string OptionAlertPayDatesBefore
        {
            get
            {
                return _optionAlertPayDatesBefore;
            }
            set
            {
                _optionAlertPayDatesBefore = value;
            }

        }
        public string OptionAlertPayDates
        {
            get
            {
                return _optionAlertPayDates;
            }
            set
            {
                _optionAlertPayDates = value;
            }

        }
        public string OptionAlertWithSound
        {
            get
            {
                return _optionAlertWithSound;
            }
            set
            {
                _optionAlertWithSound = value;
            }

        }
        public string OptionAlertSaleInvoice
        {
            get
            {
                return _optionAlertSaleInvoice;
            }
            set
            {
                _optionAlertSaleInvoice = value;
            }

        }
        public string OptionHidePOSShortcut
        {
            get
            {
                return _optionHidePOSShortcut;
            }
            set
            {
                _optionHidePOSShortcut = value;
            }

        }
        public string OptionHidePOSScreen
        {
            get
            {
                return _optionHidePOSScreen;
            }
            set
            {
                _optionHidePOSScreen = value;
            }

        }
        public string OptionHideRentingInvoice
        {
            get
            {
                return _optionHideRentingInvoice;
            }
            set
            {
                _optionHideRentingInvoice = value;
            }

        }
        public string OptionHideKitchenWindow
        {
            get
            {
                return _optionHideKitchenWindow;
            }
            set
            {
                _optionHideKitchenWindow = value;
            }

        }
        #endregion

        #endregion


        #region FlagSettings_General Fields

        private string _flagcompanyname, _flagphone, _flagcell, _flagfax, _flagpobox, _flagemail, _flagaddress, _flagsystemnote, _flagworknote;
        private string _flaglanguage, _flagHideDiscountWindow, _flagHideWelcomeWindow, _flagHideNoteFiled, _flagShowCompanyOnInvoice, _flagShowCompanyNameOnly, _flagAutoStartwithWindow, _flagDateFormatValue;

        #region String datatypes

        public string FlagCompanyName
        {
            get
            {
                return _flagcompanyname;
            }
            set
            {
                _flagcompanyname = value;
            }

        }
        public string FlagPhone
        {
            get
            {
                return _flagphone;
            }
            set
            {
                _flagphone = value;
            }

        }
        public string FlagCell
        {
            get
            {
                return _flagcell;
            }
            set
            {
                _flagcell = value;
            }

        }
        public string FlagFax
        {
            get
            {
                return _flagfax;
            }
            set
            {
                _flagfax = value;
            }

        }
        public string FlagPOBox
        {
            get
            {
                return _flagpobox;
            }
            set
            {
                _flagpobox = value;
            }

        }
        public string FlagEmail
        {
            get
            {
                return _flagemail;
            }
            set
            {
                _flagemail = value;
            }

        }
        public string FlagAddress
        {
            get
            {
                return _flagaddress;
            }
            set
            {
                _flagaddress = value;
            }

        }
        public string FlagSystemNote
        {
            get
            {
                return _flagsystemnote;
            }
            set
            {
                _flagsystemnote = value;
            }

        }
        public string FlagWorkNote
        {
            get
            {
                return _flagworknote;
            }
            set
            {
                _flagworknote = value;
            }

        }
        public string FlagLangage
        {
            get
            {
                return _flaglanguage;
            }
            set
            {
                _flaglanguage = value;
            }

        }
        public string FlagHideDiscountWindow
        {
            get
            {
                return _flagHideDiscountWindow;
            }
            set
            {
                _flagHideDiscountWindow = value;
            }

        }
        public string FlagHideWelcomeWindow
        {
            get
            {
                return _flagHideWelcomeWindow;
            }
            set
            {
                _flagHideWelcomeWindow = value;
            }

        }
        public string FlagHideNoteFiled
        {
            get
            {
                return _flagHideNoteFiled;
            }
            set
            {
                _flagHideNoteFiled = value;
            }

        }
        public string FlagShowCompanyOnInvoice
        {
            get
            {
                return _flagShowCompanyOnInvoice;
            }
            set
            {
                _flagShowCompanyOnInvoice = value;
            }

        }
        public string FlagShowCompanyNameOnly
        {
            get
            {
                return _flagShowCompanyNameOnly;
            }
            set
            {
                _flagShowCompanyNameOnly = value;
            }

        }
        public string FlagAutoStartwithWindow
        {
            get
            {
                return _flagAutoStartwithWindow;
            }
            set
            {
                _flagAutoStartwithWindow = value;
            }

        }
        public string FlagDateFormat
        {
            get
            {
                return _flagDateFormatValue;
            }
            set
            {
                _flagDateFormatValue = value;
            }

        }


        #endregion

        #endregion

        #region FlagSettings_Invoice Fields

        private string _flagtxtPercentageCard, _flagtxtPercentageCheck, _flagchkActivatePaymentType, _flagPurchase_HideExpiryFiled, _flagPurchase_HideDevidingDiscountOnItem, _flagPurchase_AddItemDirectlywithBarcode, _flagTabToPrice, _flagShowDiscountFiled, _flagShowHidenItem, _flagPurchase_SaveUsernameOnInvoice, _flagPurchase_DontUseExpiry;
        private string _flagHidePriceChangingButton, _flagSalePriceReadonly, _flagSale_AddItemDirectlywithBarcode, _flagOpenInvioceAfterClosing, _flagSale_HideExpiryFiled, _flagDevideDiscountBeforeClosingInvoice, _flagAlterwhenSellingLessthanCost, _flagShowSubTotalFiled, _flagShowNonStockItem, _flagSale_SaveUsernameOnInvoice, _flagShowInvoiceCostFiled, _flagDisableDiscountFiled, _flagSale_HideDevidingDiscountOnItem, _flagSale_InsertItemIndividually, _flagPurchase_HideImportExport, _flagSale_DontUseExpiry;


        #region String datatypes

        public string FlagtxtPercentageCheck
        {
            get
            {
                return _flagtxtPercentageCheck;
            }
            set
            {
                _flagtxtPercentageCheck = value;
            }

        }
        public string FlagtxtPercentageCard
        {
            get
            {
                return _flagtxtPercentageCard;
            }
            set
            {
                _flagtxtPercentageCard = value;
            }

        }
        public string FlagchkActivatePaymentType
        {
            get
            {
                return _flagchkActivatePaymentType;
            }
            set
            {
                _flagchkActivatePaymentType = value;
            }

        }
        public string FlagPurchase_HideExpiryFiled
        {
            get
            {
                return _flagPurchase_HideExpiryFiled;
            }
            set
            {
                _flagPurchase_HideExpiryFiled = value;
            }

        }
        public string FlagPurchase_HideDevidingDiscountOnItem
        {
            get
            {
                return _flagPurchase_HideDevidingDiscountOnItem;
            }
            set
            {
                _flagPurchase_HideDevidingDiscountOnItem = value;
            }

        }
        public string FlagPurchase_AddItemDirectlywithBarcode
        {
            get
            {
                return _flagPurchase_AddItemDirectlywithBarcode;
            }
            set
            {
                _flagPurchase_AddItemDirectlywithBarcode = value;
            }

        }
        public string FlagTabToPrice
        {
            get
            {
                return _flagTabToPrice;
            }
            set
            {
                _flagTabToPrice = value;
            }

        }
        public string FlagShowDiscountFiled
        {
            get
            {
                return _flagShowDiscountFiled;
            }
            set
            {
                _flagShowDiscountFiled = value;
            }

        }
        public string FlagShowHidenItem
        {
            get
            {
                return _flagShowHidenItem;
            }
            set
            {
                _flagShowHidenItem = value;
            }

        }
        public string FlagPurchase_SaveUsernameOnInvoice
        {
            get
            {
                return _flagPurchase_SaveUsernameOnInvoice;
            }
            set
            {
                _flagPurchase_SaveUsernameOnInvoice = value;
            }

        }
        public string FlagHidePriceChangingButton
        {
            get
            {
                return _flagHidePriceChangingButton;
            }
            set
            {
                _flagHidePriceChangingButton = value;
            }

        }
        public string FlagSalePriceReadonly
        {
            get
            {
                return _flagSalePriceReadonly;
            }
            set
            {
                _flagSalePriceReadonly = value;
            }

        }
        public string FlagSale_AddItemDirectlywithBarcode
        {
            get
            {
                return _flagSale_AddItemDirectlywithBarcode;
            }
            set
            {
                _flagSale_AddItemDirectlywithBarcode = value;
            }

        }
        public string FlagOpenInvioceAfterClosing
        {
            get
            {
                return _flagOpenInvioceAfterClosing;
            }
            set
            {
                _flagOpenInvioceAfterClosing = value;
            }

        }
        public string FlagSale_HideExpiryFiled
        {
            get
            {
                return _flagSale_HideExpiryFiled;
            }
            set
            {
                _flagSale_HideExpiryFiled = value;
            }

        }
        public string FlagDevideDiscountBeforeClosingInvoice
        {
            get
            {
                return _flagDevideDiscountBeforeClosingInvoice;
            }
            set
            {
                _flagDevideDiscountBeforeClosingInvoice = value;
            }

        }
        public string FlagAlterwhenSellingLessthanCost
        {
            get
            {
                return _flagAlterwhenSellingLessthanCost;
            }
            set
            {
                _flagAlterwhenSellingLessthanCost = value;
            }

        }
        public string FlagShowSubTotalFiled
        {
            get
            {
                return _flagShowSubTotalFiled;
            }
            set
            {
                _flagShowSubTotalFiled = value;
            }

        }
        public string FlagShowNonStockItem
        {
            get
            {
                return _flagShowNonStockItem;
            }
            set
            {
                _flagShowNonStockItem = value;
            }

        }
        public string FlagSale_SaveUsernameOnInvoice
        {
            get
            {
                return _flagSale_SaveUsernameOnInvoice;
            }
            set
            {
                _flagSale_SaveUsernameOnInvoice = value;
            }

        }
        public string FlagShowInvoiceCostFiled
        {
            get
            {
                return _flagShowInvoiceCostFiled;
            }
            set
            {
                _flagShowInvoiceCostFiled = value;
            }

        }
        public string FlagDisableDiscountFiled
        {
            get
            {
                return _flagDisableDiscountFiled;
            }
            set
            {
                _flagDisableDiscountFiled = value;
            }

        }
        public string FlagSale_HideDevidingDiscountOnItem
        {
            get
            {
                return _flagSale_HideDevidingDiscountOnItem;
            }
            set
            {
                _flagSale_HideDevidingDiscountOnItem = value;
            }

        }

        public string FlagSale_InsertItemIndividually
        {
            get
            {
                return _flagSale_InsertItemIndividually;
            }
            set
            {
                _flagSale_InsertItemIndividually = value;
            }

        }
        public string FlagPurchase_HideImportExport
        {
            get { return _flagPurchase_HideImportExport; }
            set { _flagPurchase_HideImportExport = value; }
        }
        public string FlagPurchase_DontUseExpiry
        {
            get { return _flagPurchase_DontUseExpiry; }
            set { _flagPurchase_DontUseExpiry = value; }
        }

        public string FlagSale_DontUseExpiry
        {
            get { return _flagSale_DontUseExpiry; }
            set { _flagSale_DontUseExpiry = value; }
        }
        #endregion

        #endregion

        #region FlagSettings_Print Fields

        private string _flagInvoiceTemplate, _flagBarcodePaperSize, _flagBarcodePrinter, _flagPrintingLogo, _flagItemSorting, _flagInvoiceCopies, _flagReciptCopies, _flagHeader, _flagFooter;
        private string _flagLogoHeader, _flagLogoFooter, _flagNoteSaleInvoice, _flagPrintAfterClosingInvoice, _flagPrintAfterClosingRecipt, _flagPrintTotalQuantity, _flagHideDiscountFiledOnPrint, _flagShowTime;
        private string _flagHideTaxFiled, _flagHideLogoOnPrint, _flagShowDeptOnPrint, _flagIgnoreNonStockItem, _flagPosCategoryVicePrint;

        #region String datatypes

        public string FlagInvoiceTemplate
        {
            get
            {
                return _flagInvoiceTemplate;
            }
            set
            {
                _flagInvoiceTemplate = value;
            }
        }
        public string FlagBarcodePaperSize
        {
            get
            {
                return _flagBarcodePaperSize;
            }
            set
            {
                _flagBarcodePaperSize = value;
            }
        }
        public string FlagBarcodePrinter
        {
            get
            {
                return _flagBarcodePrinter;
            }
            set
            {
                _flagBarcodePrinter = value;
            }
        }
        public string FlagPrintingLogo
        {
            get
            {
                return _flagPrintingLogo;
            }
            set
            {
                _flagPrintingLogo = value;
            }
        }
        public string FlagItemSorting
        {
            get
            {
                return _flagItemSorting;
            }
            set
            {
                _flagItemSorting = value;
            }
        }
        public string FlagInvoiceCopies
        {
            get
            {
                return _flagInvoiceCopies;
            }
            set
            {
                _flagInvoiceCopies = value;
            }
        }
        public string FlagReciptCopies
        {
            get
            {
                return _flagReciptCopies;
            }
            set
            {
                _flagReciptCopies = value;
            }
        }
        public string FlagHeader
        {
            get
            {
                return _flagHeader;
            }
            set
            {
                _flagHeader = value;
            }
        }
        public string FlagFooter
        {
            get
            {
                return _flagFooter;
            }
            set
            {
                _flagFooter = value;
            }
        }
        public string FlagLogoHeader
        {
            get
            {
                return _flagLogoHeader;
            }
            set
            {
                _flagLogoHeader = value;
            }
        }
        public string FlagLogoFooter
        {
            get
            {
                return _flagLogoFooter;
            }
            set
            {
                _flagLogoFooter = value;
            }
        }
        public string FlagNoteSaleInvoice
        {
            get
            {
                return _flagNoteSaleInvoice;
            }
            set
            {
                _flagNoteSaleInvoice = value;
            }
        }
        public string FlagPrintAfterClosingInvoice
        {
            get
            {
                return _flagPrintAfterClosingInvoice;
            }
            set
            {
                _flagPrintAfterClosingInvoice = value;
            }
        }
        public string FlagPrintAfterClosingRecipt
        {
            get
            {
                return _flagPrintAfterClosingRecipt;
            }
            set
            {
                _flagPrintAfterClosingRecipt = value;
            }
        }
        public string FlagPrintTotalQuantity
        {
            get
            {
                return _flagPrintTotalQuantity;
            }
            set
            {
                _flagPrintTotalQuantity = value;
            }
        }
        public string FlagHideDiscountFiledOnPrint
        {
            get
            {
                return _flagHideDiscountFiledOnPrint;
            }
            set
            {
                _flagHideDiscountFiledOnPrint = value;
            }
        }
        public string FlagShowTime
        {
            get
            {
                return _flagShowTime;
            }
            set
            {
                _flagShowTime = value;
            }
        }
        public string FlagHideTaxFiled
        {
            get
            {
                return _flagHideTaxFiled;
            }
            set
            {
                _flagHideTaxFiled = value;
            }
        }
        public string FlagHideLogoOnPrint
        {
            get
            {
                return _flagHideLogoOnPrint;
            }
            set
            {
                _flagHideLogoOnPrint = value;
            }
        }
        public string FlagShowDeptOnPrint
        {
            get
            {
                return _flagShowDeptOnPrint;
            }
            set
            {
                _flagShowDeptOnPrint = value;
            }
        }
        public string FlagIgnoreNonStockItem
        {
            get
            {
                return _flagIgnoreNonStockItem;
            }
            set
            {
                _flagIgnoreNonStockItem = value;
            }
        }
        public string FlagPosCategoryVicePrint
        {
            get
            {
                return _flagPosCategoryVicePrint;
            }
            set
            {
                _flagPosCategoryVicePrint = value;
            }
        }

        public string FlagHidePeaceBoxOnPrint { get; set; }


        #endregion

        #endregion

        #region FlagSettings_Item Fields

        private string _flagAlertExpiry, _flagAlertReorderItem, _flagIssueOrderInvoice, _flagAlertForReorders, _flagDontIssueReorderInvoice, _flagHideItemSaleTimeInInvoice, _flagHideItemCostInSales, _flagHideItemNumber, _flagCHKAutoPriceItem, _flagTxtAutoPriceItem;
        private string _flagDontTabToReorderandMaxpoint, _flagDontAlertForExpiryInNotes, _flagQuitWithoutAsking, _flagSellExpiryWenNotEnough, _flagAlertForMultiExpiry, _flagUseExpiryDefaultInItemCard, _flagHidePackageQuantity, _flagMonitorReorderAndMaxpoint;

        #region String datatypes
        public string FlagAlertExpiry
        {
            get
            {
                return _flagAlertExpiry;
            }
            set
            {
                _flagAlertExpiry = value;
            }

        }
        public string FlagAlertReorderItem
        {
            get
            {
                return _flagAlertReorderItem;
            }
            set
            {
                _flagAlertReorderItem = value;
            }

        }
        public string FlagIssueOrderInvoice
        {
            get
            {
                return _flagIssueOrderInvoice;
            }
            set
            {
                _flagIssueOrderInvoice = value;
            }

        }
        public string FlagAlertForReorders
        {
            get
            {
                return _flagAlertForReorders;
            }
            set
            {
                _flagAlertForReorders = value;
            }

        }
        public string FlagDontIssueReorderInvoice
        {
            get
            {
                return _flagDontIssueReorderInvoice;
            }
            set
            {
                _flagDontIssueReorderInvoice = value;
            }

        }
        public string FlagHideItemSaleTimeInInvoice
        {
            get
            {
                return _flagHideItemSaleTimeInInvoice;
            }
            set
            {
                _flagHideItemSaleTimeInInvoice = value;
            }

        }
        public string FlagHideItemCostInSales
        {
            get
            {
                return _flagHideItemCostInSales;
            }
            set
            {
                _flagHideItemCostInSales = value;
            }

        }
        public string FlagHideItemNumber
        {
            get
            {
                return _flagHideItemNumber;
            }
            set
            {
                _flagHideItemNumber = value;
            }

        }
        public string FlagDontTabToReorderandMaxpoint
        {
            get
            {
                return _flagDontTabToReorderandMaxpoint;
            }
            set
            {
                _flagDontTabToReorderandMaxpoint = value;
            }

        }
        public string FlagDontAlertForExpiryInNotes
        {
            get
            {
                return _flagDontAlertForExpiryInNotes;
            }
            set
            {
                _flagDontAlertForExpiryInNotes = value;
            }

        }
        public string FlagQuitWithoutAsking
        {
            get
            {
                return _flagQuitWithoutAsking;
            }
            set
            {
                _flagQuitWithoutAsking = value;
            }

        }
        public string FlagSellExpiryWenNotEnough
        {
            get
            {
                return _flagSellExpiryWenNotEnough;
            }
            set
            {
                _flagSellExpiryWenNotEnough = value;
            }

        }
        public string FlagAlertForMultiExpiry
        {
            get
            {
                return _flagAlertForMultiExpiry;
            }
            set
            {
                _flagAlertForMultiExpiry = value;
            }

        }
        public string FlagUseExpiryDefaultInItemCard
        {
            get
            {
                return _flagUseExpiryDefaultInItemCard;
            }
            set
            {
                _flagUseExpiryDefaultInItemCard = value;
            }

        }
        public string FlagHidePackageQuantity
        {
            get
            {
                return _flagHidePackageQuantity;
            }
            set
            {
                _flagHidePackageQuantity = value;
            }

        }
        public string FlagMonitorReorderAndMaxpoint
        {
            get
            {
                return _flagMonitorReorderAndMaxpoint;
            }
            set
            {
                _flagMonitorReorderAndMaxpoint = value;
            }

        }

        public string FlagCHKAutoPriceItem
        {
            get
            {
                return _flagCHKAutoPriceItem;
            }
            set
            {
                _flagCHKAutoPriceItem = value;
            }
        }

        public string FlagTxtAutoPriceItem
        {
            get
            {
                return _flagTxtAutoPriceItem;
            }
            set
            {
                _flagTxtAutoPriceItem = value;
            }
        }


        #endregion
        #endregion

        #region FlagSettings_Employee Fields

        private string _flagCalculateSalary, _flagHoliday, _flagCalculateSalaryFromStartDay, _flagCutLatencyAutomatically, _flagCountSalaryFromRegistrationPoint, _flagCutDeficits;
        private string _flagTrackUsers, _flagCountSystemStarupMinutes, _flagCountOverTimeAutomatically, _flagCountOverTimeForHolidays, _flagStopEmployeeCalculations;

        #region String datatypes

        public string FlagCalculateSalary
        {
            get
            {
                return _flagCalculateSalary;
            }
            set
            {
                _flagCalculateSalary = value;
            }

        }
        public string FlagHoliday
        {
            get
            {
                return _flagHoliday;
            }
            set
            {
                _flagHoliday = value;
            }

        }
        public string FlagCalculateSalaryFromStartDay
        {
            get
            {
                return _flagCalculateSalaryFromStartDay;
            }
            set
            {
                _flagCalculateSalaryFromStartDay = value;
            }

        }
        public string FlagCutLatencyAutomatically
        {
            get
            {
                return _flagCutLatencyAutomatically;
            }
            set
            {
                _flagCutLatencyAutomatically = value;
            }

        }
        public string FlagCountSalaryFromRegistrationPoint
        {
            get
            {
                return _flagCountSalaryFromRegistrationPoint;
            }
            set
            {
                _flagCountSalaryFromRegistrationPoint = value;
            }

        }
        public string FlagCutDeficits
        {
            get
            {
                return _flagCutDeficits;
            }
            set
            {
                _flagCutDeficits = value;
            }

        }
        public string FlagTrackUsers
        {
            get
            {
                return _flagTrackUsers;
            }
            set
            {
                _flagTrackUsers = value;
            }

        }
        public string FlagCountSystemStarupMinutes
        {
            get
            {
                return _flagCountSystemStarupMinutes;
            }
            set
            {
                _flagCountSystemStarupMinutes = value;
            }

        }
        public string FlagCountOverTimeAutomatically
        {
            get
            {
                return _flagCountOverTimeAutomatically;
            }
            set
            {
                _flagCountOverTimeAutomatically = value;
            }

        }
        public string FlagCountOverTimeForHolidays
        {
            get
            {
                return _flagCountOverTimeForHolidays;
            }
            set
            {
                _flagCountOverTimeForHolidays = value;
            }

        }
        public string FlagStopEmployeeCalculations
        {
            get
            {
                return _flagStopEmployeeCalculations;
            }
            set
            {
                _flagStopEmployeeCalculations = value;
            }

        }


        #endregion

        #endregion

        #region FlagSettings_Backup Fields

        private string _flagAskWhenLeavingSystem, _flagAutomaticBackupWhenClosing, _flagAskWhenReplacingFile, _flagSaveAutomaticBackupInAlternativePath, _flagSaveFilenameWithDatetime;
        private string _flagAlertWhenNotMakingBackup, _flagAutomaticBackupDays, _flagSaveBackup, _flagAlternativePath, _flagLastBackupDate;

        #region String datatypes

        public string FlagAskWhenLeavingSystem
        {
            get
            {
                return _flagAskWhenLeavingSystem;
            }
            set
            {
                _flagAskWhenLeavingSystem = value;
            }

        }
        public string FlagAutomaticBackupWhenClosing
        {
            get
            {
                return _flagAutomaticBackupWhenClosing;
            }
            set
            {
                _flagAutomaticBackupWhenClosing = value;
            }

        }
        public string FlagAskWhenReplacingFile
        {
            get
            {
                return _flagAskWhenReplacingFile;
            }
            set
            {
                _flagAskWhenReplacingFile = value;
            }

        }
        public string FlagSaveAutomaticBackupInAlternativePath
        {
            get
            {
                return _flagSaveAutomaticBackupInAlternativePath;
            }
            set
            {
                _flagSaveAutomaticBackupInAlternativePath = value;
            }

        }
        public string FlagSaveFilenameWithDatetime
        {
            get
            {
                return _flagSaveFilenameWithDatetime;
            }
            set
            {
                _flagSaveFilenameWithDatetime = value;
            }

        }
        public string FlagAlertWhenNotMakingBackup
        {
            get
            {
                return _flagAlertWhenNotMakingBackup;
            }
            set
            {
                _flagAlertWhenNotMakingBackup = value;
            }

        }
        public string FlagAutomaticBackupDays
        {
            get
            {
                return _flagAutomaticBackupDays;
            }
            set
            {
                _flagAutomaticBackupDays = value;
            }

        }
        public string FlagSaveBackup
        {
            get
            {
                return _flagSaveBackup;
            }
            set
            {
                _flagSaveBackup = value;
            }

        }
        public string FlagAlternativePath
        {
            get
            {
                return _flagAlternativePath;
            }
            set
            {
                _flagAlternativePath = value;
            }

        }
        public string FlagLastBackupDate
        {
            get
            {
                return _flagLastBackupDate;
            }
            set
            {
                _flagLastBackupDate = value;
            }

        }


        #endregion

        #endregion

        #region FlagSettings_Peripherals Fields

        private string _flagUseCustomerDisplay, _flagFirstLineWelcomeNote, _flagSecondLineWelcomeNote, _flagUseCashDrawer, _flagDrawerTypeUSP, _flagDrawerTypeCOM;
        private string _flagDrawerTypeRJ11, _flagDrawerOpenDirectlyAfterPrint, _flagDrawerProtectWithPassword, _flagCashDrawerPassword, _flagCashDrawerVerifyPassword;

        #region String datatypes

        public string FlagUseCustomerDisplay
        {
            get
            {
                return _flagUseCustomerDisplay;
            }
            set
            {
                _flagUseCustomerDisplay = value;
            }

        }
        public string FlagFirstLineWelcomeNote
        {
            get
            {
                return _flagFirstLineWelcomeNote;
            }
            set
            {
                _flagFirstLineWelcomeNote = value;
            }

        }
        public string FlagSecondLineWelcomeNote
        {
            get
            {
                return _flagSecondLineWelcomeNote;
            }
            set
            {
                _flagSecondLineWelcomeNote = value;
            }

        }
        public string FlagUseCashDrawer
        {
            get
            {
                return _flagUseCashDrawer;
            }
            set
            {
                _flagUseCashDrawer = value;
            }

        }
        public string FlagDrawerTypeUSP
        {
            get
            {
                return _flagDrawerTypeUSP;
            }
            set
            {
                _flagDrawerTypeUSP = value;
            }

        }
        public string FlagDrawerTypeCOM
        {
            get
            {
                return _flagDrawerTypeCOM;
            }
            set
            {
                _flagDrawerTypeCOM = value;
            }

        }
        public string FlagDrawerTypeRJ11
        {
            get
            {
                return _flagDrawerTypeRJ11;
            }
            set
            {
                _flagDrawerTypeRJ11 = value;
            }

        }
        public string FlagDrawerOpenDirectlyAfterPrint
        {
            get
            {
                return _flagDrawerOpenDirectlyAfterPrint;
            }
            set
            {
                _flagDrawerOpenDirectlyAfterPrint = value;
            }

        }
        public string FlagDrawerProtectWithPassword
        {
            get
            {
                return _flagDrawerProtectWithPassword;
            }
            set
            {
                _flagDrawerProtectWithPassword = value;
            }

        }
        public string FlagCashDrawerPassword
        {
            get
            {
                return _flagCashDrawerPassword;
            }
            set
            {
                _flagCashDrawerPassword = value;
            }

        }
        public string FlagCashDrawerVerifyPassword
        {
            get
            {
                return _flagCashDrawerVerifyPassword;
            }
            set
            {
                _flagCashDrawerVerifyPassword = value;
            }

        }

        #endregion

        #endregion

        #region FlagSettings_Tax Fields

        private string _flagTax1_TaxName, _flagTax1_Percentage, _flagTax1_SubPercentage, _flagTax1_ShowTaxInvoice, _flagTax1_ApplySales, _flagTax1_ApplyPurchase, _flagTax1_ApplyMaintains, _flagTax1_ApplyBeforeDiscount;
        private string _flagTax2_TaxName, _flagTax2_Percentage, _flagTax2_SubPercentage, _flagTax2_ShowTaxInvoice, _flagTax2_ApplySales, _flagTax2_ApplyPurchase, _flagTax2_ApplyMaintains, _flagTax2_ApplyBeforeDiscount;

        #region String datatypes

        public string FlagTax1_TaxName
        {
            get
            {
                return _flagTax1_TaxName;
            }
            set
            {
                _flagTax1_TaxName = value;
            }

        }
        public string FlagTax1_Percentage
        {
            get
            {
                return _flagTax1_Percentage;
            }
            set
            {
                _flagTax1_Percentage = value;
            }

        }
        public string FlagTax1_SubPercentage
        {
            get
            {
                return _flagTax1_SubPercentage;
            }
            set
            {
                _flagTax1_SubPercentage = value;
            }

        }
        public string FlagTax1_ShowTaxInvoice
        {
            get
            {
                return _flagTax1_ShowTaxInvoice;
            }
            set
            {
                _flagTax1_ShowTaxInvoice = value;
            }

        }
        public string FlagTax1_ApplySales
        {
            get
            {
                return _flagTax1_ApplySales;
            }
            set
            {
                _flagTax1_ApplySales = value;
            }

        }
        public string FlagTax1_ApplyPurchase
        {
            get
            {
                return _flagTax1_ApplyPurchase;
            }
            set
            {
                _flagTax1_ApplyPurchase = value;
            }

        }
        public string FlagTax1_ApplyMaintains
        {
            get
            {
                return _flagTax1_ApplyMaintains;
            }
            set
            {
                _flagTax1_ApplyMaintains = value;
            }

        }
        public string FlagTax1_ApplyBeforeDiscount
        {
            get
            {
                return _flagTax1_ApplyBeforeDiscount;
            }
            set
            {
                _flagTax1_ApplyBeforeDiscount = value;
            }

        }
        public string FlagTax2_TaxName
        {
            get
            {
                return _flagTax2_TaxName;
            }
            set
            {
                _flagTax2_TaxName = value;
            }

        }
        public string FlagTax2_Percentage
        {
            get
            {
                return _flagTax2_Percentage;
            }
            set
            {
                _flagTax2_Percentage = value;
            }

        }
        public string FlagTax2_SubPercentage
        {
            get
            {
                return _flagTax2_SubPercentage;
            }
            set
            {
                _flagTax2_SubPercentage = value;
            }

        }
        public string FlagTax2_ShowTaxInvoice
        {
            get
            {
                return _flagTax2_ShowTaxInvoice;
            }
            set
            {
                _flagTax2_ShowTaxInvoice = value;
            }

        }
        public string FlagTax2_ApplySales
        {
            get
            {
                return _flagTax2_ApplySales;
            }
            set
            {
                _flagTax2_ApplySales = value;
            }

        }
        public string FlagTax2_ApplyPurchase
        {
            get
            {
                return _flagTax2_ApplyPurchase;
            }
            set
            {
                _flagTax2_ApplyPurchase = value;
            }

        }
        public string FlagTax2_ApplyMaintains
        {
            get
            {
                return _flagTax2_ApplyMaintains;
            }
            set
            {
                _flagTax2_ApplyMaintains = value;
            }

        }
        public string FlagTax2_ApplyBeforeDiscount
        {
            get
            {
                return _flagTax2_ApplyBeforeDiscount;
            }
            set
            {
                _flagTax2_ApplyBeforeDiscount = value;
            }

        }

        #endregion

        #endregion

        #region FlagSettings_Notification Fields

        private string _flagLicenserenewal, _flagMedicalInsurance, _flagCertificateofHealth, _flagAttendancePermit, _flagTechnicalDisclosure, _flagPricing, _flagPayrent, _flagDisbursementSalary, _flagAnnualInventory, _flagZakat;
        private DateTime _flagLicenserenewalDate, _flagMedicalInsuranceDate, _flagCertificateofHealthDate, _flagAttendancePermitDate, _flagTechnicalDisclosureDate, _flagPricingDate, _flagPayrentDate, _flagDisbursementSalaryDate, _flagAnnualInventoryDate, _flagZakatDate;
        private int _flagLicenserenewalNotifyBefore, _flagMedicalInsuranceNotifyBefore, _flagCertificateofHealthNotifyBefore, _flagAttendancePermitNotifyBefore, _flagTechnicalDisclosureNotifyBefore, _flagPricingNotifyBefore, _flagPayrentNotifyBefore, _flagDisbursementSalaryNotifyBefore, _flagAnnualInventoryNotifyBefore, _flagZakatNotifyBefore;

        #region String datatypes

        public string FlagLicenserenewal
        {
            get
            {
                return _flagLicenserenewal;
            }
            set
            {
                _flagLicenserenewal = value;
            }
        }
        public string FlagMedicalInsurance
        {
            get
            {
                return _flagMedicalInsurance;
            }
            set
            {
                _flagMedicalInsurance = value;
            }
        }
        public string FlagCertificateofHealth
        {
            get
            {
                return _flagCertificateofHealth;
            }
            set
            {
                _flagCertificateofHealth = value;
            }
        }
        public string FlagAttendancePermit
        {
            get
            {
                return _flagAttendancePermit;
            }
            set
            {
                _flagAttendancePermit = value;
            }
        }
        public string FlagTechnicalDisclosure
        {
            get
            {
                return _flagTechnicalDisclosure;
            }
            set
            {
                _flagTechnicalDisclosure = value;
            }
        }
        public string FlagPricing
        {
            get
            {
                return _flagPricing;
            }
            set
            {
                _flagPricing = value;
            }
        }
        public string FlagPayrent
        {
            get
            {
                return _flagPayrent;
            }
            set
            {
                _flagPayrent = value;
            }
        }
        public string FlagDisbursementSalary
        {
            get
            {
                return _flagDisbursementSalary;
            }
            set
            {
                _flagDisbursementSalary = value;
            }
        }
        public string FlagAnnualInventory
        {
            get
            {
                return _flagAnnualInventory;
            }
            set
            {
                _flagAnnualInventory = value;
            }
        }
        public string FlagZakat
        {
            get
            {
                return _flagZakat;
            }
            set
            {
                _flagZakat = value;
            }
        }

        #endregion

        #region Datetime datatypes
        public DateTime FlagLicenserenewalDate
        {
            get
            {
                return _flagLicenserenewalDate;
            }
            set
            {
                _flagLicenserenewalDate = value;
            }
        }
        public DateTime FlagMedicalInsuranceDate
        {
            get
            {
                return _flagMedicalInsuranceDate;
            }
            set
            {
                _flagMedicalInsuranceDate = value;
            }
        }
        public DateTime FlagCertificateofHealthDate
        {
            get
            {
                return _flagCertificateofHealthDate;
            }
            set
            {
                _flagCertificateofHealthDate = value;
            }
        }
        public DateTime FlagAttendancePermitDate
        {
            get
            {
                return _flagAttendancePermitDate;
            }
            set
            {
                _flagAttendancePermitDate = value;
            }
        }
        public DateTime FlagTechnicalDisclosureDate
        {
            get
            {
                return _flagTechnicalDisclosureDate;
            }
            set
            {
                _flagTechnicalDisclosureDate = value;
            }
        }
        public DateTime FlagPricingDate
        {
            get
            {
                return _flagPricingDate;
            }
            set
            {
                _flagPricingDate = value;
            }
        }
        public DateTime FlagPayrentDate
        {
            get
            {
                return _flagPayrentDate;
            }
            set
            {
                _flagPayrentDate = value;
            }
        }
        public DateTime FlagDisbursementSalaryDate
        {
            get
            {
                return _flagDisbursementSalaryDate;
            }
            set
            {
                _flagDisbursementSalaryDate = value;
            }
        }
        public DateTime FlagAnnualInventoryDate
        {
            get
            {
                return _flagAnnualInventoryDate;
            }
            set
            {
                _flagAnnualInventoryDate = value;
            }
        }
        public DateTime FlagZakatDate
        {
            get
            {
                return _flagZakatDate;
            }
            set
            {
                _flagZakatDate = value;
            }
        }

        #endregion

        #region Integer datatypes

        public int FlagLicenserenewalNotifyBefore
        {
            get
            {
                return _flagLicenserenewalNotifyBefore;
            }
            set
            {
                _flagLicenserenewalNotifyBefore = value;
            }
        }
        public int FlagMedicalInsuranceNotifyBefore
        {
            get
            {
                return _flagMedicalInsuranceNotifyBefore;
            }
            set
            {
                _flagMedicalInsuranceNotifyBefore = value;
            }
        }
        public int FlagCertificateofHealthNotifyBefore
        {
            get
            {
                return _flagCertificateofHealthNotifyBefore;
            }
            set
            {
                _flagCertificateofHealthNotifyBefore = value;
            }
        }
        public int FlagAttendancePermitNotifyBefore
        {
            get
            {
                return _flagAttendancePermitNotifyBefore;
            }
            set
            {
                _flagAttendancePermitNotifyBefore = value;
            }
        }
        public int FlagTechnicalDisclosureNotifyBefore
        {
            get
            {
                return _flagTechnicalDisclosureNotifyBefore;
            }
            set
            {
                _flagTechnicalDisclosureNotifyBefore = value;
            }
        }
        public int FlagPricingNotifyBefore
        {
            get
            {
                return _flagPricingNotifyBefore;
            }
            set
            {
                _flagPricingNotifyBefore = value;
            }
        }
        public int FlagPayrentNotifyBefore
        {
            get
            {
                return _flagPayrentNotifyBefore;
            }
            set
            {
                _flagPayrentNotifyBefore = value;
            }
        }
        public int FlagDisbursementSalaryNotifyBefore
        {
            get
            {
                return _flagDisbursementSalaryNotifyBefore;
            }
            set
            {
                _flagDisbursementSalaryNotifyBefore = value;
            }
        }
        public int FlagAnnualInventoryNotifyBefore
        {
            get
            {
                return _flagAnnualInventoryNotifyBefore;
            }
            set
            {
                _flagAnnualInventoryNotifyBefore = value;
            }
        }
        public int FlagZakatNotifyBefore
        {
            get
            {
                return _flagZakatNotifyBefore;
            }
            set
            {
                _flagZakatNotifyBefore = value;
            }
        }


        #endregion



        #endregion

        #region FlagSettings_Other Fields

        private string _flagDontAskClosingSystem, _flag24HourWorkSystem, _flagStopDeptSellings, _flagHidePackageReport, _flagShowTipDayWhenStart, _flagBranchBuyswithCost, _flagUseItemPhoto, _flagUseRentingInvoice, _flagDontAlertOnSave, _flagDontAlertDeleteItemFromInvoice;
        private string _flagUnifyOptionForallWorkStations, _flagRoundPriceOnDiscount, _flagRoundPricesOnDiscountValue, _flagAlertReorderItemsPerDay, _flagAlertExpiryPerDay, _flagAlertPayDatesBefore, _flagAlertPayDates, _flagAlertWithSound, _flagAlertSaleInvoice;
        private string _flagHidePOSShortcut, _flagHidePOSScreen, _flagHideRentingInvoice, _flagHideKitchenWindow;

        #region String datatypes

        public string FlagDontAskClosingSystem
        {
            get
            {
                return _flagDontAskClosingSystem;
            }
            set
            {
                _flagDontAskClosingSystem = value;
            }

        }
        public string Flag24HourWorkSystem
        {
            get
            {
                return _flag24HourWorkSystem;
            }
            set
            {
                _flag24HourWorkSystem = value;
            }

        }
        public string FlagStopDeptSellings
        {
            get
            {
                return _flagStopDeptSellings;
            }
            set
            {
                _flagStopDeptSellings = value;
            }

        }
        public string FlagHidePackageReport
        {
            get
            {
                return _flagHidePackageReport;
            }
            set
            {
                _flagHidePackageReport = value;
            }

        }
        public string FlagShowTipDayWhenStart
        {
            get
            {
                return _flagShowTipDayWhenStart;
            }
            set
            {
                _flagShowTipDayWhenStart = value;
            }

        }
        public string FlagBranchBuyswithCost
        {
            get
            {
                return _flagBranchBuyswithCost;
            }
            set
            {
                _flagBranchBuyswithCost = value;
            }

        }
        public string FlagUseItemPhoto
        {
            get
            {
                return _flagUseItemPhoto;
            }
            set
            {
                _flagUseItemPhoto = value;
            }

        }
        public string FlagUseRentingInvoice
        {
            get
            {
                return _flagUseRentingInvoice;
            }
            set
            {
                _flagUseRentingInvoice = value;
            }

        }
        public string FlagDontAlertOnSave
        {
            get
            {
                return _flagDontAlertOnSave;
            }
            set
            {
                _flagDontAlertOnSave = value;
            }

        }
        public string FlagDontAlertDeleteItemFromInvoice
        {
            get
            {
                return _flagDontAlertDeleteItemFromInvoice;
            }
            set
            {
                _flagDontAlertDeleteItemFromInvoice = value;
            }

        }
        public string FlagUnifyOptionForallWorkStations
        {
            get
            {
                return _flagUnifyOptionForallWorkStations;
            }
            set
            {
                _flagUnifyOptionForallWorkStations = value;
            }

        }
        public string FlagRoundPriceOnDiscount
        {
            get
            {
                return _flagRoundPriceOnDiscount;
            }
            set
            {
                _flagRoundPriceOnDiscount = value;
            }

        }
        public string FlagRoundPricesOnDiscountValue
        {
            get
            {
                return _flagRoundPricesOnDiscountValue;
            }
            set
            {
                _flagRoundPricesOnDiscountValue = value;
            }

        }
        public string FlagAlertReorderItemsPerDay
        {
            get
            {
                return _flagAlertReorderItemsPerDay;
            }
            set
            {
                _flagAlertReorderItemsPerDay = value;
            }

        }
        public string FlagAlertExpiryPerDay
        {
            get
            {
                return _flagAlertExpiryPerDay;
            }
            set
            {
                _flagAlertExpiryPerDay = value;
            }

        }
        public string FlagAlertPayDatesBefore
        {
            get
            {
                return _flagAlertPayDatesBefore;
            }
            set
            {
                _flagAlertPayDatesBefore = value;
            }

        }
        public string FlagAlertPayDates
        {
            get
            {
                return _flagAlertPayDates;
            }
            set
            {
                _flagAlertPayDates = value;
            }

        }
        public string FlagAlertWithSound
        {
            get
            {
                return _flagAlertWithSound;
            }
            set
            {
                _flagAlertWithSound = value;
            }

        }
        public string FlagAlertSaleInvoice
        {
            get
            {
                return _flagAlertSaleInvoice;
            }
            set
            {
                _flagAlertSaleInvoice = value;
            }

        }
        public string FlagHideRentingInvoice
        {
            get
            {
                return _flagHideRentingInvoice;
            }
            set
            {
                _flagHideRentingInvoice = value;
            }

        }
        public string FlagHideKitchenWindow
        {
            get
            {
                return _flagHideKitchenWindow;
            }
            set
            {
                _flagHideKitchenWindow = value;
            }

        }
        public string FlagHidePOSShortcut
        {
            get
            {
                return _flagHidePOSShortcut;
            }
            set
            {
                _flagHidePOSShortcut = value;
            }

        }
        public string FlagHidePOSScreen
        {
            get
            {
                return _flagHidePOSScreen;
            }
            set
            {
                _flagHidePOSScreen = value;
            }

        }
        #endregion

        #endregion

        #region Backup and Restore
        private byte _Itemandbarcode, _AgentInfo, _Spendings, _EmpInfo, _UserInfo, _moveCreditofAgents;
        private string _option, _Description;
        public byte Itemandbarcode
        {
            get { return _Itemandbarcode; }
            set { _Itemandbarcode = value; }
        }
        public byte AgentInfo
        {
            get { return _AgentInfo; }
            set { _AgentInfo = value; }
        }
        public byte Spendings
        {
            get { return _Spendings; }
            set { _Spendings = value; }
        }
        public byte EmpInfo
        {
            get { return _EmpInfo; }
            set { _EmpInfo = value; }
        }
        public byte UserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }
        public byte MoveCreditofAgents
        {
            get { return _moveCreditofAgents; }
            set { _moveCreditofAgents = value; }
        }
        public string OptionDB
        {
            get { return _option; }
            set { _option = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        #endregion

        public string OptionSale_HidePaidRefund { get; set; }

        public string FlagSale_HidePaidRefund { get; set; }
        public byte MoveStocktoInventory { get; set; }

        public string OptionResetPOSOrder { get; set; }
        public string FlagResetPOSOrder { get; set; }
        public string OptionPOSOrderResetCount { get; set; }
        public string FlagPOSOrderResetCount { get; set; }
        public string EnableNetworkSaleControl { get; set; }
        public string FlagEnableNetworkSaleControl { get; set; }
        public string EnableConfirmEndShift { get; set; }
        public string FlagEnableConfirmEndShift { get; set; }
        public string EnableOpenNewInvoice { get; set; }
        public string FlagEnableOpenNewInvoice { get; set; }
        public string OptionBarcodeSize { get; set; }
        public string FlagBarcodeSize { get; set; }

        public string OptionPriceChecker { get; set; }
        public string FlagPriceChecker { get; set; }
    }
}
