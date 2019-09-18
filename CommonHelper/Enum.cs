using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelper
{
    public enum NumericDataType { Decimal, Integer }
    public enum SerializerType { Xml, Binary, Soap }

    public enum Tabs
    {
        Category = 0,
        Company = 1,
        ItemPlace = 2,
        Bank = 3,
        Branch = 4,
        ItemUnit
    }
    public enum ActionType
    {
        Insert = 1,
        Update,
        Save,
        Delete,
        Modify,
        Return,
        New,
        View,
        Print,
        All,
        Close,
        Confirmation,
        AlterForExpiry,
        DBConnection,
        Information,
        Login,
        Logout,
        Undo
    }


    public enum Table
    {
        Sales = 1,
        Purchase = 2,
        Order = 3,
        BankDeposit,
        Expenses,
        StockAdjustment,
        CustomerReceipt,
        Payment,
        PurchaseReturn = 9,
        SaleReturn,
        BankWithdraw,
        CashCapital,
        NormalSaleID,
        DebitPayableReceivable,
        POSSaleID,
        SpoiledInvoice,
        PerformaInvoice

    }

    public enum TransactionType { Deposit = 1, WithDraw, Cash };
    public enum Results
    {
        Success,
        Warning,
        Error,
        WarningConfirmation
    }

    public enum ResultType
    {
        UI,
        BusinessLogic,
        DataLayer
    }
    public enum ControlTag
    {
        txtCategory = 0
    }
    public class Constant
    {
        public const int Comanpy = 0;
    }

    public enum Options
    {
        General = 0,
        Invoice = 1,
        Print = 2,
        Item = 3,
        // Employee = 4,
        Backup = 4,
        Peripherals = 5,
        Tax = 6,
        Notification = 7,
        Others = 8

    }

    public enum PayReceiptFor
    {
        Debt = 1,
        Purchase = 2,
        //PurchaseReturn = 9,
        Receipt,
        SaleReturn,
        OpenStock

    }

    public enum ReceiveReceiptFor
    {

         Receivable = 2,
        POS,
        PurchaseReturn,
        SaleInvoice,
        /// <summary>
        /// change the receipt for flag for balance sheeet receive receipt is 1to 7
        /// </summary>
        BalanceSheet = 7,
        ///commented on 22 april 2014 
        //ReceiveReceipt,
        //Debt
    }
    /// <summary>
    /// Navigation Identification Added By Meena.R
    /// </summary>
    public enum InvoiceFlag
    {
        First = 1,
        Next = 2,
        Previous = 3,
        Last = 4

    }

    public enum ItemType
    {
        Goods = 1,
        SecondHand,
        Labour,
        Meals

    }

    public enum SalesInvoiceType
    {
        NormalInvoice = 1,
        ClosedInvoice,
        ModifiedInvoice
    }

    public enum SalesDiscountType
    {
        Value = 1,
        Percentage
    }

    public enum SalesIncludeTax
    {
        Yes = 1,
        No = 0
    }

    public enum SalesType
    {
        Normal = 1,
        POS = 2
    }
    public enum WeekendDay
    {
        Work = 1,
        Holi = 2,
        Reg = 3
    }
    public enum InvoiceAction
    {
        Yes = 1,
        No = 0
    }
    public enum Optiontype
    {
        Notes = 1,
        Variable,
        Drawing
    }
    /// <summary>
    /// Remarks Of Order Invoice Added By Meena.R
    /// </summary>
    public enum OrderRemarks
    {
        SI = 1,
        PI,
        OI,
        RI
    }
    public enum BreakTimeFlag
    {
        StartBreak = 1,
        EndBreak,
        OTStartBreak,
        OTEndBreak
    }
    public enum InvoiceType
    {
        AllInvoices = 0,
        New,
        Closed,
        PurchaseInvoice,
        ReturnInvoice,
        OrderInvoice,
        InvoiceNo
    }
    public enum InvoiceStatus
    {
        NewInvoice = 1,
        CloseInvoice
    }

    //Added by Seenivasan.B for FindSale_InvioiceType
    public enum FindSaleInvoiceType
    {
        SaleInvoice = 0,
        AllInvoices,
        New,
        closed,
        //RentingInvoice,
        SpoiledInvoices,
        ReturnInvoice,
        POS
    }
 
    //Added by Seenivasan.B for FindSaleInvoice Grid Selection Changed 
    public enum InvoiceTypeSelection
    {
        Normal = 1,
        SpoiledInvoice = 9,
        POS = 2,
        ReturnedInvoice = 10
    }

    /// <summary>
    /// Added by Seenivasan.B for POS Item Type 
    /// </summary>
    public enum PosItemType
    {
        RegularItem = 5,
        AdditionalItem,
    }

    public enum LoadTableSettings
    {
        LoadAllSettings = 1,
        LoadSavedSetting

    }

    public enum DiscountType
    {
        Goods = 1,
        SecondHand = 2,
        Meals = 4,
        AllItems = 5
    }

    public enum DefaultUserGroup
    {
        Admin = 1,
        Administrator = 2,
        Accountant = 3,
        SalesPerson = 4,
        PurchasePerson = 5
    }

    public enum CashClientID
    {
        ID = 1001
        
    }
    public enum Admin
    {
        ID = 101
    }
    public enum CategoryId
    {
        Value = 1001
    }
    public enum CompanyId
    {
        Value = 1001
    }


}
