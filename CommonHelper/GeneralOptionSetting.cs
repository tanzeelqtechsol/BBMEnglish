using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ObjectHelper;

namespace ObjectHelper
{
    public class GeneralOptionSetting
    {
        #region OptionSetting

        private static string _optionflag, _optionstatus, _optioncreatedby, _optionmodifiedby;
        private static DateTime _optioncreateddate, _optionmodifieddate;
        private static string _optionValue;
        public static int ReorderItemsDisplayCount = 1;
        public static int ExpiryDisplayCount = 1;


        #region String datatypes

        public static string OptionValue
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
        public static string OptionFlag
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
        public static string OptionStatus
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
        public static string OptionCreatedBy
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
        public static string OptionModifiedBy
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

        public static DateTime OptionCreatedDate
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
        public static DateTime OptionModifiedDate
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

        #endregion


        #endregion

        #region OptionSettings_General Fields

        private static string _optioncompanyname, _optionphone, _optioncell, _optionfax, _optionpobox, _optionemail, _optionaddress, _optionsystemnote, _optionworknote;
        private static string _optionlanguage, _optionHideDiscountWindow, _optionHideWelcomeWindow, _optionHideNoteFiled, _optionShowCompanyOnInvoice, _optionShowCompanyNameOnly, _optionAutoStartwithWindow, _UserId;

        #region String datatypes

        public static string OptionCompanyName
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
        public static string OptionPhone
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
        public static string OptionCell
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
        public static string OptionFax
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
        public static string OptionPOBox
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
        public static string OptionEmail
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
        public static string OptionAddress
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
        public static string OptionSystemNote
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
        public static string OptionWorkNote
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
        public static string OptionLangage
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
        public static string OptionHideDiscountWindow
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
        public static string OptionHideWelcomeWindow
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
        public static string OptionHideNoteFiled
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
        public static string OptionShowCompanyOnInvoice
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
        public static string OptionShowCompanyNameOnly
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
        public static string OptionAutoStartwithWindow
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
        public static string Option_UserId
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


        #endregion

        #endregion

        #region OptionSettings_Invoice Fields

        private static string optionPaymentTypePercentage_percentageValue, optionPurchase_DontUseExpiry, _optionPurchase_HideExpiryFiled, _optionPurchase_HideDevidingDiscountOnItem, _optionPurchase_AddItemDirectlywithBarcode, _optionTabToPrice, _optionShowDiscountFiled, _optionShowHidenItem, _optionPurchase_SaveUsernameOnInvoice, optionPurchase_HideImportExport;
        private static string optionSale_DontUseExpiry, _optionHidePriceChangingButton, _optionSalePriceReadonly, _optionSale_AddItemDirectlywithBarcode, _optionOpenInvioceAfterClosing, _optionSale_HideExpiryFiled, _optionDevideDiscountBeforeClosingInvoice, _optionAlterwhenSellingLessthanCost, _optionShowSubTotalFiled, _optionShowNonStockItem, _optionSale_SaveUsernameOnInvoice, _optionShowInvoiceCostFiled, _optionDisableDiscountFiled, _optionSale_HideDevidingDiscountOnItem;

        #region String datatypes

        public static string OptionPaymentTypePercentage_percentageValue
        {
            get
            {
                return optionPaymentTypePercentage_percentageValue;
            }
            set
            {
                optionPaymentTypePercentage_percentageValue = value;
            }

        }
        public static string OptionPurchase_HideExpiryFiled
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
        public static string OptionPurchase_HideDevidingDiscountOnItem
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
        public static string OptionPurchase_AddItemDirectlywithBarcode
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
        public static string OptionTabToPrice
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
        public static string OptionShowDiscountFiled
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
        public static string OptionShowHidenItem
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
        public static string OptionPurchase_SaveUsernameOnInvoice
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
        public static string OptionHidePriceChangingButton
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
        public static string OptionSalePriceReadonly
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
        public static string OptionSale_AddItemDirectlywithBarcode
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
        public static string OptionOpenInvioceAfterClosing
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
        public static string OptionSale_HideExpiryFiled
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
        public static string OptionDevideDiscountBeforeClosingInvoice
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
        public static string OptionAlterwhenSellingLessthanCost
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
        public static string OptionShowSubTotalFiled
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
        public static string OptionShowNonStockItem
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
        public static string OptionSale_SaveUsernameOnInvoice
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
        public static string OptionShowInvoiceCostFiled
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
        public static string OptionDisableDiscountFiled
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
        public static string OptionSale_HideDevidingDiscountOnItem
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

        private static string _optionInvoiceTemplate, _optionBarcodePaperSize, _optionBarcodePrinter, _optionPrintingLogo, _optionItemSorting, _optionInvoiceCopies, _optionReciptCopies, _optionHeader, _optionFooter;
        private static string _optionLogoHeader, _optionLogoFooter, _optionNoteSaleInvoice, _optionPrintAfterClosingInvoice, _optionPrintAfterClosingRecipt, _optionPrintTotalQuantity, _optionHideDiscountFiledOnPrint, _optionShowTime;
        private static string _optionHideTaxFiled, _optionHideLogoOnPrint, _optionShowDeptOnPrint, _optionIgnoreNonStockItem, _optionPosCategoryVicePrint;
        private static byte[] _headerlogo, _footerlogo;

        #region String datatypes


        public static string OptionInvoiceTemplate
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
        public static string OptionBarcodePaperSize
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
        public static string OptionBarcodePrinter
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
        public static string OptionPrintingLogo
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
        public static string OptionItemSorting
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
        public static string OptionInvoiceCopies
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
        public static string OptionReciptCopies
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
        public static string OptionHeader
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
        public static string OptionFooter
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
        public static string OptionLogoHeader
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
        public static string OptionLogoFooter
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
        public static string OptionNoteSaleInvoice
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
        public static string OptionPrintAfterClosingInvoice
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
        public static string OptionPrintAfterClosingRecipt
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
        public static string OptionPrintTotalQuantity
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
        public static string OptionHideDiscountFiledOnPrint
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
        public static string OptionShowTime
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
        public static string OptionHideTaxFiled
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
        public static string OptionHideLogoOnPrint
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
        public static string OptionShowDeptOnPrint
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
        public static string OptionIgnoreNonStockItem
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
        public static string OptionPosCategoryVicePrint
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
        public static byte[] HeaderLogo
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
        public static byte[] FooterLogo
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

        private static string _optionAlertExpiry, _optionAlertReorderItem, _optionIssueOrderInvoice, _optionAlertForReorders, _optionDontIssueReorderInvoice, _optionHideItemSaleTimeInInvoice, _optionHideItemCostInSales, _optionHideItemNumber, _optionchkautoitemprice, _optiontxtautoitemprice;
        private static string _optionDontTabToReorderandMaxpoint, _optionDontAlertForExpiryInNotes, _optionQuitWithoutAsking, _optionSellExpiryWenNotEnough, _optionAlertForMultiExpiry, _optionUseExpiryDefaultInItemCard, _optionHidePackageQuantity, _optionMonitorReorderAndMaxpoint;

        #region String datatypes
        public static string OptionAlertExpiry
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
        public static string OptionAlertReorderItem
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
        public static string OptionIssueOrderInvoice
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
        public static string OptionAlertForReorders
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
        public static string OptionDontIssueReorderInvoice
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
        public static string OptionHideItemSaleTimeInInvoice
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
        public static string OptionHideItemCostInSales
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
        public static string OptionHideItemNumber
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
        public static string OptionDontTabToReorderandMaxpoint
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
        public static string OptionDontAlertForExpiryInNotes
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
        public static string OptionQuitWithoutAsking
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
        public static string OptionSellExpiryWenNotEnough
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
        public static string OptionAlertForMultiExpiry
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
        public static string OptionUseExpiryDefaultInItemCard
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
        public static string OptionHidePackageQuantity
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
        public static string OptionMonitorReorderAndMaxpoint
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

        public static string OptionCHKAutoItemPrice
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

        public static string OptionTxtAutoItemPrice
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

        private static string _optionCalculateSalary, _optionHoliday, _optionCalculateSalaryFromStartDay, _optionCutLatencyAutomatically, _optionCountSalaryFromRegistrationPoint, _optionCutDeficits;
        private static string _optionTrackUsers, _optionCountSystemStarupMinutes, _optionCountOverTimeAutomatically, _optionCountOverTimeForHolidays, _optionStopEmployeeCalculations;

        #region String datatypes

        public static string OptionCalculateSalary
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
        public static string OptionHoliday
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
        public static string OptionCalculateSalaryFromStartDay
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
        public static string OptionCutLatencyAutomatically
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
        public static string OptionCountSalaryFromRegistrationPoint
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
        public static string OptionCutDeficits
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
        public static string OptionTrackUsers
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
        public static string OptionCountSystemStarupMinutes
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
        public static string OptionCountOverTimeAutomatically
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
        public static string OptionCountOverTimeForHolidays
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
        public static string OptionStopEmployeeCalculations
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
        private static ArrayList _notes;
        #region OptionSettings_Backup Fields

        private static string _optionAskWhenLeavingSystem, _optionAutomaticBackupWhenClosing, _optionAskWhenReplacingFile, _optionSaveAutomaticBackupInAlternativePath, _optionSaveFilenameWithDatetime;
        private static string _optionAlertWhenNotMakingBackup, _optionAutomaticBackupDays, _optionSaveBackup, _optionAlternativePath, _optionLastBackupDate;
        // _optionAutomaticLastBackupDate;
        public static ArrayList Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }

        }

        #region String datatypes

        public static string OptionAskWhenLeavingSystem
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
        public static string OptionAutomaticBackupWhenClosing
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
        public static string OptionAskWhenReplacingFile
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
        public static string OptionSaveAutomaticBackupInAlternativePath
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
        public static string OptionSaveFilenameWithDatetime
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
        public static string OptionAlertWhenNotMakingBackup
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
        public static string OptionAutomaticBackupDays
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
        public static string OptionSaveBackup
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
        public static string OptionAlternativePath
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
        public static string OptionLastBackupDate
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

        private static string _optionUseCustomerDisplay, _optionFirstLineWelcomeNote, _optionSecondLineWelcomeNote, _optionUseCashDrawer, _optionDrawerTypeUSP, _optionDrawerTypeCOM;
        private static string _optionDrawerTypeRJ11, _optionDrawerOpenDirectlyAfterPrint, _optionDrawerProtectWithPassword, _optionCashDrawerPassword, _optionCashDrawerVerifyPassword;

        #region String datatypes

        public static string OptionUseCustomerDisplay
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
        public static string OptionFirstLineWelcomeNote
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
        public static string OptionSecondLineWelcomeNote
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
        public static string OptionUseCashDrawer
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
        public static string OptionDrawerTypeUSP
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
        public static string OptionDrawerTypeCOM
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
        public static string OptionDrawerTypeRJ11
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
        public static string OptionDrawerOpenDirectlyAfterPrint
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
        public static string OptionDrawerProtectWithPassword
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
        public static string OptionCashDrawerPassword
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
        public static string OptionCashDrawerVerifyPassword
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

        private static string _optionTax1_TaxName, _optionTax1_Percentage, _optionTax1_SubPercentage, _optionTax1_ShowTaxInvoice, _optionTax1_ApplySales, _optionTax1_ApplyPurchase, _optionTax1_ApplyMaintains, _optionTax1_ApplyBeforeDiscount;
        private static string _optionTax2_TaxName, _optionTax2_Percentage, _optionTax2_SubPercentage, _optionTax2_ShowTaxInvoice, _optionTax2_ApplySales, _optionTax2_ApplyPurchase, _optionTax2_ApplyMaintains, _optionTax2_ApplyBeforeDiscount;

        #region String datatypes

        public static string OptionTax1_TaxName
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
        public static string OptionTax1_Percentage
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
        public static string OptionTax1_SubPercentage
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
        public static string OptionTax1_ShowTaxInvoice
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
        public static string OptionTax1_ApplySales
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
        public static string OptionTax1_ApplyPurchase
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
        public static string OptionTax1_ApplyMaintains
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
        public static string OptionTax1_ApplyBeforeDiscount
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
        public static string OptionTax2_TaxName
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
        public static string OptionTax2_Percentage
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
        public static string OptionTax2_SubPercentage
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
        public static string OptionTax2_ShowTaxInvoice
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
        public static string OptionTax2_ApplySales
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
        public static string OptionTax2_ApplyPurchase
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
        public static string OptionTax2_ApplyMaintains
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
        public static string OptionTax2_ApplyBeforeDiscount
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

        private static string _optionLicenserenewal, _optionMedicalInsurance, _optionCertificateofHealth, _optionAttendancePermit, _optionTechnicalDisclosure, _optionPricing, _optionPayrent, _optionDisbursementSalary, _optionAnnualInventory, _optionZakat;
        private static string _optionLicenserenewalDate, _optionMedicalInsuranceDate, _optionCertificateofHealthDate, _optionAttendancePermitDate, _optionTechnicalDisclosureDate, _optionPricingDate, _optionPayrentDate, _optionDisbursementSalaryDate, _optionAnnualInventoryDate, _optionZakatDate;
        private static string _optionLicenserenewalNotifyBefore, _optionMedicalInsuranceNotifyBefore, _optionCertificateofHealthNotifyBefore, _optionAttendancePermitNotifyBefore, _optionTechnicalDisclosureNotifyBefore, _optionPricingNotifyBefore, _optionPayrentNotifyBefore, _optionDisbursementSalaryNotifyBefore, _optionAnnualInventoryNotifyBefore, _optionZakatNotifyBefore;

        #region String datatypes

        public static string OptionLicenserenewal
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
        public static string OptionMedicalInsurance
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
        public static string OptionCertificateofHealth
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
        public static string OptionAttendancePermit
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
        public static string OptionTechnicalDisclosure
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
        public static string OptionPricing
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
        public static string OptionPayrent
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
        public static string OptionDisbursementSalary
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
        public static string OptionAnnualInventory
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
        public static string OptionZakat
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
        public static string OptionLicenserenewalDate
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
        public static string OptionMedicalInsuranceDate
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
        public static string OptionCertificateofHealthDate
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
        public static string OptionAttendancePermitDate
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
        public static string OptionTechnicalDisclosureDate
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
        public static string OptionPricingDate
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
        public static string OptionPayrentDate
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
        public static string OptionDisbursementSalaryDate
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
        public static string OptionAnnualInventoryDate
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
        public static string OptionZakatDate
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

        public static string OptionLicenserenewalNotifyBefore
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
        public static string OptionMedicalInsuranceNotifyBefore
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
        public static string OptionCertificateofHealthNotifyBefore
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
        public static string OptionAttendancePermitNotifyBefore
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
        public static string OptionTechnicalDisclosureNotifyBefore
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
        public static string OptionPricingNotifyBefore
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
        public static string OptionPayrentNotifyBefore
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
        public static string OptionDisbursementSalaryNotifyBefore
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
        public static string OptionAnnualInventoryNotifyBefore
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
        public static string OptionZakatNotifyBefore
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

        private static string _optionDontAskClosingSystem, _option24HourWorkSystem, _optionStopDeptSellings, _optionHidePackageReport, _optionShowTipDayWhenStart, _optionBranchBuyswithCost, _optionUseItemPhoto, _optionUseRentingInvoice, _optionDontAlertOnSave, _optionDontAlertDeleteItemFromInvoice;
        private static string _optionUnifyOptionForallWorkStations, _optionRoundPriceOnDiscount, _optionRoundPricesOnDiscountValue, _optionAlertReorderItemsPerDay, _optionAlertExpiryPerDay, _optionAlertPayDatesBefore, _optionAlertPayDates, _optionAlertWithSound, _optionAlertSaleInvoice;
        private static string _optionHidePOSShortcut, _optionHidePOSScreen, _optionHideRentingInvoice, _optionHideKitchenWindow;

        #region String datatypes

        public static string OptionDontAskClosingSystem
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
        public static string Option24HourWorkSystem
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
        public static string OptionStopDeptSellings
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
        public static string OptionHidePackageReport
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
        public static string OptionShowTipDayWhenStart
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
        public static string OptionBranchBuyswithCost
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
        public static string OptionUseItemPhoto
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
        public static string OptionUseRentingInvoice
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
        public static string OptionDontAlertOnSave
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
        public static string OptionDontAlertDeleteItemFromInvoice
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
        public static string OptionUnifyOptionForallWorkStations
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
        public static string OptionRoundPriceOnDiscount
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
        public static string OptionRoundPricesOnDiscountValue
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
        public static string OptionAlertReorderItemsPerDay
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
        public static string OptionAlertExpiryPerDay
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
        public static string OptionAlertPayDatesBefore
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
        public static string OptionAlertPayDates
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
        public static string OptionAlertWithSound
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
        public static string OptionAlertSaleInvoice
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
        public static string OptionHidePOSShortcut
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
        public static string OptionHidePOSScreen
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
        public static string OptionHideRentingInvoice
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
        public static string OptionHideKitchenWindow
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

        private static string _flagcompanyname, _flagphone, _flagcell, _flagfax, _flagpobox, _flagemail, _flagaddress, _flagsystemnote, _flagworknote;
        private static string _flaglanguage, _flagHideDiscountWindow, _flagHideWelcomeWindow, _flagHideNoteFiled, _flagShowCompanyOnInvoice, _flagShowCompanyNameOnly, _flagAutoStartwithWindow, _flagDateFormatValue;

        #region String datatypes

        public static string FlagCompanyName
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
        public static string FlagPhone
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
        public static string FlagCell
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
        public static string FlagFax
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
        public static string FlagPOBox
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
        public static string FlagEmail
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
        public static string FlagAddress
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
        public static string FlagSystemNote
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
        public static string FlagWorkNote
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
        public static string FlagLangage
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
        public static string FlagHideDiscountWindow
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
        public static string FlagHideWelcomeWindow
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
        public static string FlagHideNoteFiled
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
        public static string FlagShowCompanyOnInvoice
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
        public static string FlagShowCompanyNameOnly
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
        public static string FlagAutoStartwithWindow
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


        public static string FlagDateFormat //Added on 28-May-2014
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

        private static string _flagPurchase_DontUseExpiry, _flagPurchase_HideExpiryFiled, _flagPurchase_HideDevidingDiscountOnItem, _flagPurchase_AddItemDirectlywithBarcode, _flagTabToPrice, _flagShowDiscountFiled, _flagShowHidenItem, _flagPurchase_SaveUsernameOnInvoice, _flagPurchase_HideImportExport;
        private static string _flagSale_DontUseExpiry, _flagHidePriceChangingButton, _flagSalePriceReadonly, _flagSale_AddItemDirectlywithBarcode, _flagOpenInvioceAfterClosing, _flagSale_HideExpiryFiled, _flagDevideDiscountBeforeClosingInvoice, _flagAlterwhenSellingLessthanCost, _flagShowSubTotalFiled, _flagShowNonStockItem, _flagSale_SaveUsernameOnInvoice, _flagShowInvoiceCostFiled, _flagDisableDiscountFiled, _flagSale_HideDevidingDiscountOnItem, _flagSale_InsertItemIndividually;

        #region String datatypes

        public static string FlagPurchase_HideExpiryFiled
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
        public static string FlagPurchase_HideDevidingDiscountOnItem
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
        public static string FlagPurchase_AddItemDirectlywithBarcode
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
        public static string FlagTabToPrice
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
        public static string FlagShowDiscountFiled
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
        public static string FlagShowHidenItem
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
        public static string FlagPurchase_SaveUsernameOnInvoice
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
        public static string FlagHidePriceChangingButton
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
        public static string FlagSalePriceReadonly
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
        public static string FlagSale_AddItemDirectlywithBarcode
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
        public static string FlagOpenInvioceAfterClosing
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
        public static string FlagSale_HideExpiryFiled
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
        public static string FlagDevideDiscountBeforeClosingInvoice
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
        public static string FlagAlterwhenSellingLessthanCost
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
        public static string FlagShowSubTotalFiled
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
        public static string FlagShowNonStockItem
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
        public static string FlagSale_SaveUsernameOnInvoice
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
        public static string FlagShowInvoiceCostFiled
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
        public static string FlagDisableDiscountFiled
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
        public static string FlagSale_HideDevidingDiscountOnItem
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

        public static string FlagSale_InsertItemIndividually
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
        public static string FlagPurchase_HideImportExport
        {
            get { return _flagPurchase_HideImportExport; }
            set { _flagPurchase_HideImportExport = value; }
        }
        public static string FlagPurchase_DontUseExpiry
        {
            get { return _flagPurchase_DontUseExpiry; }
            set { _flagPurchase_DontUseExpiry = value; }
        }

        public static string FlagSale_DontUseExpiry
        {
            get { return _flagSale_DontUseExpiry; }
            set { _flagSale_DontUseExpiry = value; }
        }
        #endregion

        #endregion

        #region FlagSettings_Print Fields

        private static string _flagInvoiceTemplate, _flagBarcodePaperSize, _flagBarcodePrinter, _flagPrintingLogo, _flagItemSorting, _flagInvoiceCopies, _flagReciptCopies, _flagHeader, _flagFooter;
        private static string _flagLogoHeader, _flagLogoFooter, _flagNoteSaleInvoice, _flagPrintAfterClosingInvoice, _flagPrintAfterClosingRecipt, _flagPrintTotalQuantity, _flagHideDiscountFiledOnPrint, _flagShowTime;
        private static string _flagHideTaxFiled, _flagHideLogoOnPrint, _flagShowDeptOnPrint, _flagIgnoreNonStockItem, _flagPosCategoryVicePrint;

        #region String datatypes

        public static string FlagInvoiceTemplate
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
        public static string FlagBarcodePaperSize
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
        public static string FlagBarcodePrinter
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
        public static string FlagPrintingLogo
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
        public static string FlagItemSorting
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
        public static string FlagInvoiceCopies
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
        public static string FlagReciptCopies
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
        public static string FlagHeader
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
        public static string FlagFooter
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
        public static string FlagLogoHeader
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
        public static string FlagLogoFooter
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
        public static string FlagNoteSaleInvoice
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
        public static string FlagPrintAfterClosingInvoice
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
        public static string FlagPrintAfterClosingRecipt
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
        public static string FlagPrintTotalQuantity
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
        public static string FlagHideDiscountFiledOnPrint
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
        public static string FlagShowTime
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
        public static string FlagHideTaxFiled
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
        public static string FlagHideLogoOnPrint
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
        public static string FlagHidePeaceBoxOnPrint
        {
            get;
            set;
        }
        public static string FlagShowDeptOnPrint
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
        public static string FlagIgnoreNonStockItem
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
        public static string FlagPosCategoryVicePrint
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


        #endregion

        #endregion

        #region FlagSettings_Item Fields

        private static string _flagAlertExpiry, _flagAlertReorderItem, _flagIssueOrderInvoice, _flagAlertForReorders, _flagDontIssueReorderInvoice, _flagHideItemSaleTimeInInvoice, _flagHideItemCostInSales, _flagHideItemNumber, _flagCHKAutoPriceItem, _flagTxtAutoPriceItem, _flagtxtPaymentPercentageCheck, _flagtxtPaymentPercentageCard, _flagchkActivatePaymentType;
        private static string _flagDontTabToReorderandMaxpoint, _flagDontAlertForExpiryInNotes, _flagQuitWithoutAsking, _flagSellExpiryWenNotEnough, _flagAlertForMultiExpiry, _flagUseExpiryDefaultInItemCard, _flagHidePackageQuantity, _flagMonitorReorderAndMaxpoint;

        #region String datatypes
        public static string FlagAlertExpiry
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
        public static string FlagAlertReorderItem
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
        public static string FlagIssueOrderInvoice
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
        public static string FlagAlertForReorders
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
        public static string FlagDontIssueReorderInvoice
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
        public static string FlagHideItemSaleTimeInInvoice
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
        public static string FlagHideItemCostInSales
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
        public static string FlagHideItemNumber
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
        public static string FlagDontTabToReorderandMaxpoint
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
        public static string FlagDontAlertForExpiryInNotes
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
        public static string FlagQuitWithoutAsking
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
        public static string FlagSellExpiryWenNotEnough
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
        public static string FlagAlertForMultiExpiry
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
        public static string FlagUseExpiryDefaultInItemCard
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
        public static string FlagHidePackageQuantity
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
        public static string FlagMonitorReorderAndMaxpoint
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

        public static string FlagchkActivatePaymentType
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
        public static string FlagtxtPaymentPercentageCard
        {
            get
            {
                return _flagtxtPaymentPercentageCard;
            }
            set
            {
                _flagtxtPaymentPercentageCard = value;
            }
        }
        public static string FlagtxtPaymentPercentageCheck
        {
            get
            {
                return _flagtxtPaymentPercentageCheck;
            }
            set
            {
                _flagtxtPaymentPercentageCheck = value;
            }
        }
        public static string FlagCHKAutoPriceItem
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

        public static string FlagTxtAutoPriceItem
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

        private static string _flagCalculateSalary, _flagHoliday, _flagCalculateSalaryFromStartDay, _flagCutLatencyAutomatically, _flagCountSalaryFromRegistrationPoint, _flagCutDeficits;
        private static string _flagTrackUsers, _flagCountSystemStarupMinutes, _flagCountOverTimeAutomatically, _flagCountOverTimeForHolidays, _flagStopEmployeeCalculations;

        #region String datatypes

        public static string FlagCalculateSalary
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
        public static string FlagHoliday
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
        public static string FlagCalculateSalaryFromStartDay
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
        public static string FlagCutLatencyAutomatically
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
        public static string FlagCountSalaryFromRegistrationPoint
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
        public static string FlagCutDeficits
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
        public static string FlagTrackUsers
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
        public static string FlagCountSystemStarupMinutes
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
        public static string FlagCountOverTimeAutomatically
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
        public static string FlagCountOverTimeForHolidays
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
        public static string FlagStopEmployeeCalculations
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

        private static string _flagAskWhenLeavingSystem, _flagAutomaticBackupWhenClosing, _flagAskWhenReplacingFile, _flagSaveAutomaticBackupInAlternativePath, _flagSaveFilenameWithDatetime;
        private static string _flagAlertWhenNotMakingBackup, _flagAutomaticBackupDays, _flagSaveBackup, _flagAlternativePath, _flagLastBackupDate, _flagAutomaticLastBackupDate;

        #region String datatypes

        public static string FlagAskWhenLeavingSystem
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
        public static string FlagAutomaticBackupWhenClosing
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
        public static string FlagAskWhenReplacingFile
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
        public static string FlagSaveAutomaticBackupInAlternativePath
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
        public static string FlagSaveFilenameWithDatetime
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
        public static string FlagAlertWhenNotMakingBackup
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
        public static string FlagAutomaticBackupDays
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
        public static string FlagSaveBackup
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
        public static string FlagAlternativePath
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
        public static string FlagLastBackupDate
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
        public static string FlagAutomaticLastBackupDate
        {
            get
            {
                return _flagAutomaticLastBackupDate;
            }
            set
            {
                _flagAutomaticLastBackupDate = value;
            }

        }


        #endregion

        #endregion

        #region FlagSettings_Peripherals Fields

        private static string _flagUseCustomerDisplay, _flagFirstLineWelcomeNote, _flagSecondLineWelcomeNote, _flagUseCashDrawer, _flagDrawerTypeUSP, _flagDrawerTypeCOM;
        private static string _flagDrawerTypeRJ11, _flagDrawerOpenDirectlyAfterPrint, _flagDrawerProtectWithPassword, _flagCashDrawerPassword, _flagCashDrawerVerifyPassword;

        #region String datatypes

        public static string FlagUseCustomerDisplay
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
        public static string FlagFirstLineWelcomeNote
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
        public static string FlagSecondLineWelcomeNote
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
        public static string FlagUseCashDrawer
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
        public static string FlagDrawerTypeUSP
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
        public static string FlagDrawerTypeCOM
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
        public static string FlagDrawerTypeRJ11
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
        public static string FlagDrawerOpenDirectlyAfterPrint
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
        public static string FlagDrawerProtectWithPassword
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
        public static string FlagCashDrawerPassword
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
        public static string FlagCashDrawerVerifyPassword
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

        private static string _flagTax1_TaxName, _flagTax1_Percentage, _flagTax1_SubPercentage, _flagTax1_ShowTaxInvoice, _flagTax1_ApplySales, _flagTax1_ApplyPurchase, _flagTax1_ApplyMaintains, _flagTax1_ApplyBeforeDiscount;
        private static string _flagTax2_TaxName, _flagTax2_Percentage, _flagTax2_SubPercentage, _flagTax2_ShowTaxInvoice, _flagTax2_ApplySales, _flagTax2_ApplyPurchase, _flagTax2_ApplyMaintains, _flagTax2_ApplyBeforeDiscount;

        #region String datatypes

        public static string FlagTax1_TaxName
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
        public static string FlagTax1_Percentage
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
        public static string FlagTax1_SubPercentage
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
        public static string FlagTax1_ShowTaxInvoice
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
        public static string FlagTax1_ApplySales
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
        public static string FlagTax1_ApplyPurchase
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
        public static string FlagTax1_ApplyMaintains
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
        public static string FlagTax1_ApplyBeforeDiscount
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
        public static string FlagTax2_TaxName
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
        public static string FlagTax2_Percentage
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
        public static string FlagTax2_SubPercentage
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
        public static string FlagTax2_ShowTaxInvoice
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
        public static string FlagTax2_ApplySales
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
        public static string FlagTax2_ApplyPurchase
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
        public static string FlagTax2_ApplyMaintains
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
        public static string FlagTax2_ApplyBeforeDiscount
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

        private static string _flagLicenserenewal, _flagMedicalInsurance, _flagCertificateofHealth, _flagAttendancePermit, _flagTechnicalDisclosure, _flagPricing, _flagPayrent, _flagDisbursementSalary, _flagAnnualInventory, _flagZakat;
        private static DateTime _flagLicenserenewalDate, _flagMedicalInsuranceDate, _flagCertificateofHealthDate, _flagAttendancePermitDate, _flagTechnicalDisclosureDate, _flagPricingDate, _flagPayrentDate, _flagDisbursementSalaryDate, _flagAnnualInventoryDate, _flagZakatDate;
        private static int _flagLicenserenewalNotifyBefore, _flagMedicalInsuranceNotifyBefore, _flagCertificateofHealthNotifyBefore, _flagAttendancePermitNotifyBefore, _flagTechnicalDisclosureNotifyBefore, _flagPricingNotifyBefore, _flagPayrentNotifyBefore, _flagDisbursementSalaryNotifyBefore, _flagAnnualInventoryNotifyBefore, _flagZakatNotifyBefore;

        #region String datatypes

        public static string FlagLicenserenewal
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
        public static string FlagMedicalInsurance
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
        public static string FlagCertificateofHealth
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
        public static string FlagAttendancePermit
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
        public static string FlagTechnicalDisclosure
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
        public static string FlagPricing
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
        public static string FlagPayrent
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
        public static string FlagDisbursementSalary
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
        public static string FlagAnnualInventory
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
        public static string FlagZakat
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
        public static DateTime FlagLicenserenewalDate
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
        public static DateTime FlagMedicalInsuranceDate
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
        public static DateTime FlagCertificateofHealthDate
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
        public static DateTime FlagAttendancePermitDate
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
        public static DateTime FlagTechnicalDisclosureDate
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
        public static DateTime FlagPricingDate
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
        public static DateTime FlagPayrentDate
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
        public static DateTime FlagDisbursementSalaryDate
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
        public static DateTime FlagAnnualInventoryDate
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
        public static DateTime FlagZakatDate
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

        public static int FlagLicenserenewalNotifyBefore
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
        public static int FlagMedicalInsuranceNotifyBefore
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
        public static int FlagCertificateofHealthNotifyBefore
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
        public static int FlagAttendancePermitNotifyBefore
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
        public static int FlagTechnicalDisclosureNotifyBefore
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
        public static int FlagPricingNotifyBefore
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
        public static int FlagPayrentNotifyBefore
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
        public static int FlagDisbursementSalaryNotifyBefore
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
        public static int FlagAnnualInventoryNotifyBefore
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
        public static int FlagZakatNotifyBefore
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

        private static string _flagDontAskClosingSystem, _flag24HourWorkSystem, _flagStopDeptSellings, _flagHidePackageReport, _flagShowTipDayWhenStart, _flagBranchBuyswithCost, _flagUseItemPhoto, _flagUseRentingInvoice, _flagDontAlertOnSave, _flagDontAlertDeleteItemFromInvoice;
        private static string _flagUnifyOptionForallWorkStations, _flagRoundPriceOnDiscount, _flagRoundPricesOnDiscountValue, _flagAlertReorderItemsPerDay, _flagAlertExpiryPerDay, _flagAlertPayDatesBefore, _flagAlertPayDates, _flagAlertWithSound, _flagAlertSaleInvoice;
        private static string _flagHidePOSShortcut, _flagHidePOSScreen, _flagHideRentingInvoice, _flagHideKitchenWindow;

        #region String datatypes

        public static string FlagDontAskClosingSystem
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
        public static string Flag24HourWorkSystem
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
        public static string FlagStopDeptSellings
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
        public static string FlagHidePackageReport
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
        public static string FlagShowTipDayWhenStart
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
        public static string FlagBranchBuyswithCost
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
        public static string FlagUseItemPhoto
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
        public static string FlagUseRentingInvoice
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
        public static string FlagDontAlertOnSave
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
        public static string FlagDontAlertDeleteItemFromInvoice
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
        public static string FlagUnifyOptionForallWorkStations
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
        public static string FlagRoundPriceOnDiscount
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
        public static string FlagRoundPricesOnDiscountValue
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
        public static string FlagAlertReorderItemsPerDay
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
        public static string FlagAlertExpiryPerDay
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
        public static string FlagAlertPayDatesBefore
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
        public static string FlagAlertPayDates
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
        public static string FlagAlertWithSound
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
        public static string FlagAlertSaleInvoice
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
        public static string FlagHideRentingInvoice
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
        public static string FlagHideKitchenWindow
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
        public static string FlagHidePOSShortcut
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
        public static string FlagHidePOSScreen
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


        public static string FlagSale_HidePaidRefund { get; set; }
        public static string FlagResetPOSOrder { get; set; }
        public static string FlagPOSOrderResetCount { get; set; }
        public static string FlagEnableNetworkSaleControl { get; set; }
        public static string FlagConfirmEndShift { get; set; }
        public static string FlagOpenNewInvoice { get; set; }

        public static string FlagPrinterDefault { get; set; }
        public static string FlagPrinterInvoice { get; set; }
        public static string FlagPrinterPOS { get; set; }
        public static string FlagPrinterReceipt { get; set; }
        public static string FlagPrinterReport { get; set; }
        public static string FlagPrinterBarcode { get; set; }

        public static string FlagBarcodeSize { get; set; }
        public static string FlagPriceChecker { get; set; }

    }
}
